using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using APIPlugin;
using InscryptionAPI.Card;
using InscryptionCommunityPatch.Card;
using BepInEx;
using DiskCardGame;
using HarmonyLib;
using Pixelplacement;
using UnityEngine;
using UnityEngine.UIElements;
using System.Reflection;
using UnityEngine.UI;
using Tools = MagnificusMod.Tools;
using Random = UnityEngine.Random;
using MagSave = MagnificusMod.MagCurrentNode;
using SavedVars = MagnificusMod.SaveVariables;
using KayceeStorage = MagnificusMod.KayceeStorage;
using InscryptionAPI.Helpers.Extensions;

namespace MagnificusMod
{
	class FinaleBattleFixes
	{
		//rotate the nodes


		[HarmonyPatch(typeof(WizardBattlePortraitSlot), "OnOtherCardResolve")]
		public class FinaleSlotFix11
		{
			public static void Prefix(out WizardBattlePortraitSlot __state, ref WizardBattlePortraitSlot __instance)
			{
				__state = __instance;
			}

			public static IEnumerator Postfix(IEnumerator enumerator, WizardBattlePortraitSlot __state, PlayableCard otherCard)
			{
				if (otherCard.HasTrait(Trait.EatsWarrens))
				{
					MagnificusMod.Plugin.spellsPlayed++;
				}
				if (otherCard.Dead || otherCard.HasTrait(Trait.EatsWarrens) && otherCard.Info.GetExtendedPropertyAsBool("PhysicalSpell") == null)
				{
					AudioController.Instance.PlaySound2D("card_death", MixerGroup.None, 0.6f, 0f, null, null, null, null, false);
					if (otherCard.HasTrait(Trait.EatsWarrens))
					{
						if (!otherCard.slot.IsPlayerSlot && otherCard.OriginatedFromQueue)
						{
							GameObject.Find("OpponentSlots").transform.GetChild(otherCard.slot.Index).transform.Find("QueuedCardFrame").gameObject.SetActive(false);

							if (otherCard.Info.GetExtendedPropertyAsBool("TargetedSpell") == true)
							{
								object[] targetArgs = new object[] { otherCard.slot, otherCard };
								yield return otherCard.TriggerHandler.OnTrigger(Trigger.SlotTargetedForAttack, targetArgs);
							}
						}
						yield return new WaitForSeconds(0.3f);
						if (otherCard.Info.HasTrait(Trait.EatsWarrens))
						{
							yield return otherCard.Die(false);
						}
					}
				}
				else
				{
					View oldView = View.Default;
					if (__state.cardSlot.IsPlayerSlot)
					{
						Singleton<MagnificusDuelDisk>.Instance.OnCardPlayed();
						oldView = Singleton<ViewManager>.Instance.CurrentView;
						/*
						if (KayceeStorage.IsKaycee && MagnificusMod.Generation.challenges.Contains("FadingMox"))
						{
							if (otherCard.Info.name == "mag_randommox" || otherCard.Info.name == "MoxRuby" || otherCard.Info.name == "MoxEmerald" || otherCard.Info.name == "MoxSapphire")
							{
								CardModificationInfo fadingMod = new CardModificationInfo();
								fadingMod.abilities.Add(MagnificusMod.SigilCode.FadingA.ability);
								otherCard.AddTemporaryMod(fadingMod);
							}
						}*/
					}

					if (!otherCard.slot.IsPlayerSlot)
					{
						Singleton<ViewManager>.Instance.SwitchToView(View.OpponentQueue, false, __state.cardSlot.IsPlayerSlot);
					}
					__state.SummonPortraitForCard(otherCard);
					if (!otherCard.slot.IsPlayerSlot)
					{ yield return new WaitForSeconds(0.65f); }
					else { yield return new WaitForSeconds(0.15f); }
					if (__state.cardSlot.IsPlayerSlot)
					{
						Singleton<ViewManager>.Instance.Controller.LockState = ViewLockState.Unlocked;
					}
				}
				yield break;
			}
		}

		[HarmonyPatch(typeof(HandModelChooser), "ConfigureHandModel")]
		public class FixThumbPokingOut
		{
			public static bool Prefix(ref HandModelChooser __instance)
			{
				if (SceneLoader.ActiveSceneName != "finale_magnificus")
				{
					return true;
				}
				if (__instance.activeHandRenderer == null)
				{
					CompositeFigurine.FigurineType avatarHead = SaveManager.SaveFile.AvatarHead;
					Color value = __instance.handColorMid;
					switch (avatarHead)
					{
						case CompositeFigurine.FigurineType.SettlerMan:

							value = __instance.handColorLight;
							break;
						case CompositeFigurine.FigurineType.SettlerWoman:

							value = __instance.handColorDark;
							break;
						case CompositeFigurine.FigurineType.Chief:

							value = __instance.handColorMid;
							break;
						case CompositeFigurine.FigurineType.Wildling:

							value = __instance.handColorMid;
							break;
						case CompositeFigurine.FigurineType.Prospector:

							value = __instance.handColorDark;
							break;
						case CompositeFigurine.FigurineType.Enchantress:

							value = __instance.handColorLight;
							break;
						case CompositeFigurine.FigurineType.Gravedigger:

							value = __instance.handColorLight;
							break;
						case CompositeFigurine.FigurineType.Robot:
							value = __instance.handColorDark;
							break;
					}
					__instance.maleHand.SetActive(true);
					__instance.femaleHand.SetActive(false);
					__instance.activeHandRenderer = __instance.maleHandRenderer;
					GameObject gameObject = __instance.maleHand;
					__instance.handSubRenderers = new List<Renderer>();
					foreach (Renderer renderer in gameObject.GetComponentsInChildren<Renderer>(true))
					{
						if (renderer != __instance.activeHandRenderer)
						{
							__instance.handSubRenderers.Add(renderer);
						}
					}
					MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
					__instance.activeHandRenderer.GetPropertyBlock(materialPropertyBlock);
					materialPropertyBlock.SetColor("_MainColor", value);
					__instance.activeHandRenderer.SetPropertyBlock(materialPropertyBlock);
					__instance.Anim = __instance.maleHand.GetComponent<Animator>();
					if (__instance.destroyUnusedModel)
					{
						GameObject.DestroyImmediate(__instance.femaleHand);
					}
					if (__instance.dependentAnimator != null)
					{
						__instance.dependentAnimator.Rebind();
					}
				}
				return false;
			}
		}

		[HarmonyPatch(typeof(WizardBattlePortraitSlot), "ShowQueueCardFrame")]
		public class fixQueueCardBack
		{
			public static bool Prefix(ref WizardBattlePortraitSlot __instance, PlayableCard card)
			{
				__instance.frameGlowQuad.gameObject.SetActive(false);
				__instance.queueCardParent.gameObject.SetActive(true);
				MaterialPropertyBlock propertyBlock = new MaterialPropertyBlock();
				__instance.frameGlowRenderers[0].GetPropertyBlock(propertyBlock);
				propertyBlock.SetColor("_EmissionColor", new Color(0f, 0f, 0.001f));
				__instance.frameGlowRenderers.ForEach(delegate (Renderer x)
				{
					x.SetPropertyBlock(propertyBlock);
				});
				__instance.queueCardAnim.Play("idle", 0, 0f);
				if (card.Info.appearanceBehaviour.Count < 1)
				{
					__instance.queueCard.renderInfo.baseTextureOverride = Singleton<CardDisplayer3D>.Instance.defaultCardBackground;
				}
				__instance.queueCard.SetInfo(card.Info);
				if (!card.Info.appearanceBehaviour.Contains(CardAppearanceBehaviour.Appearance.TerrainLayout))
				{
					__instance.queueCard.renderInfo.hiddenAttack = false;
					__instance.queueCard.renderInfo.hiddenHealth = false;
					__instance.queueCard.renderInfo.healthTextOffset = new Vector2(0f, 0f);
					__instance.queueCard.RenderCard();
				}
				__instance.queueCard.renderInfo.portraitOverride = card.renderInfo.portraitOverride;
				Vector3 position = __instance.queueCardParent.position;
				__instance.queueCardParent.position += Vector3.up * 30f;
				Tween.Position(__instance.queueCardParent, position, 1.5f, 0f, Tween.EaseOutStrong, Tween.LoopType.None, null, null, true);
				return false;
			}
		}

		[HarmonyPatch(typeof(CombatPhaseManager), "SlotAttackSequence")]
		public class nrexrtaherfipa23
		{
			public static void Prefix(out CombatPhaseManager __state, ref CombatPhaseManager __instance)
			{
				__state = __instance;
			}
			public static IEnumerator Postfix(IEnumerator enumerator, CombatPhaseManager __state, CardSlot slot)
			{
				List<CardSlot> opposingSlots = slot.Card.GetOpposingSlots();
				if (!slot.Card.HasAbility(Ability.Sniper) && SceneLoader.ActiveSceneName == "finale_magnificus" || SceneLoader.ActiveSceneName != "finale_magnificus")
					Singleton<ViewManager>.Instance.SwitchToView(Singleton<BoardManager>.Instance.CombatView, false, false);
				Singleton<ViewManager>.Instance.Controller.LockState = ViewLockState.Locked;
				if (slot.Card.HasAbility(Ability.Sniper) && slot.IsPlayerSlot)
				{
					if (SceneLoader.ActiveSceneName == "finale_magnificus")
					{
						Generation.SetBigOpponentSlotHitboxes(true, GameObject.Find("BoardManager"));
					}
					opposingSlots.Clear();
					int numAttacks = 1;
					if (slot.Card.HasTriStrike())
					{
						numAttacks = 3;
					}
					else if (slot.Card.HasAbility(Ability.SplitStrike))
					{
						numAttacks = 2;
					}
					if (SceneLoader.ActiveSceneName != "finale_magnificus")
					{
						Singleton<ViewManager>.Instance.Controller.SwitchToControlMode(Singleton<BoardManager>.Instance.ChoosingSlotViewMode);
					}
					else
					{
						Singleton<ViewManager>.Instance.SwitchToView(View.OpponentQueue, false, false);
					}
					Singleton<ViewManager>.Instance.Controller.LockState = ViewLockState.Unlocked;
					for (int i = 0; i < numAttacks; i++)
					{
						__state.VisualizeStartSniperAbility(slot);
						CardSlot cardSlot = Singleton<InteractionCursor>.Instance.CurrentInteractable as CardSlot;
						if (cardSlot != null && opposingSlots.Contains(cardSlot))
						{
							__state.VisualizeAimSniperAbility(slot, cardSlot);
						}
						yield return Singleton<BoardManager>.Instance.ChooseTarget(Singleton<BoardManager>.Instance.OpponentSlotsCopy, Singleton<BoardManager>.Instance.OpponentSlotsCopy, delegate (CardSlot s)
						{
							opposingSlots.Add(s);
							__state.VisualizeConfirmSniperAbility(s);
						}, null, delegate (CardSlot s)
						{
							__state.VisualizeAimSniperAbility(slot, s);
						}, () => false, CursorType.Target);
					}
					Singleton<ViewManager>.Instance.Controller.SwitchToControlMode(Singleton<BoardManager>.Instance.DefaultViewMode);
					Singleton<ViewManager>.Instance.Controller.LockState = ViewLockState.Locked;
					if (SceneLoader.ActiveSceneName == "finale_magnificus")
					{
						Generation.SetBigOpponentSlotHitboxes(false, GameObject.Find("BoardManager"));
					}
				}
				float j = 0;
				bool strongPull = Singleton<BoardManager>.Instance.GetSlots(false).Find((CardSlot x) => x.Card != null && x.Card.HasAbility(SigilCode.StrongPull.ability)) != null && slot.IsPlayerSlot;
                bool strongPullOpp = Singleton<BoardManager>.Instance.GetSlots(true).Find((CardSlot x) => x.Card != null && x.Card.HasAbility(SigilCode.StrongPull.ability)) != null && slot.IsOpponentSlot();

                foreach (CardSlot opposingSlot in opposingSlots)
				{
					if (strongPull)
					{
						Singleton<ViewManager>.Instance.SwitchToView(Singleton<BoardManager>.Instance.CombatView, false, false);
						yield return __state.SlotAttackSlot(slot, Singleton<BoardManager>.Instance.GetSlots(false).Find((CardSlot x) => x.Card != null && x.Card.HasAbility(SigilCode.StrongPull.ability)), j);
						j += 0.01f;
						continue;
					} else if (strongPullOpp)
                    {
                        Singleton<ViewManager>.Instance.SwitchToView(Singleton<BoardManager>.Instance.CombatView, false, false);
                        yield return __state.SlotAttackSlot(slot, Singleton<BoardManager>.Instance.GetSlots(true).Find((CardSlot x) => x.Card != null && x.Card.HasAbility(SigilCode.StrongPull.ability)), j);
                        j += 0.01f;
                        continue;
                    }
                    Singleton<ViewManager>.Instance.SwitchToView(Singleton<BoardManager>.Instance.CombatView, false, false);
					yield return __state.SlotAttackSlot(slot, opposingSlot, j);//(opposingSlots.Count > 1) ? 0.1f : 0f);
					j += 0.01f;
				}
                yield break;
			}
		}

		[HarmonyPatch(typeof(CombatPhaseManager), "SlotAttackSlot")]
		public class FinaleAttackFix
		{
			public static bool Prefix(out CombatPhaseManager __state, ref CombatPhaseManager __instance, CardSlot attackingSlot, CardSlot opposingSlot, float waitAfter = 0f)
			{
				__state = __instance;
				if (SceneLoader.ActiveSceneName == "finale_magnificus")
				{
					PlayableCard attacker = attackingSlot.Card;
					string slotName = attackingSlot.IsPlayerSlot ? "PlayerSlots" : "OpponentSlots";
					string opponentSlotName = attackingSlot.IsPlayerSlot ? "OpponentSlots" : "PlayerSlots";
					if (GameObject.Find(slotName).transform.GetChild(attackingSlot.Index).childCount <= 5)
					{
						return false;
					}
					GameObject realCard = GameObject.Find(slotName).transform.GetChild(attackingSlot.Index).GetChild(5).gameObject;
					GameObject opponentSlot = GameObject.Find(opponentSlotName).transform.GetChild(opposingSlot.Index).gameObject;
					GameObject mox = GameObject.Find("rubyMoxPref");
					bool flightBlocker = false;
					if (opponentSlot.transform.childCount > 5 && opposingSlot.Card != null)
					{
						if (opposingSlot.Card.HasAbility(Ability.Reach))
						{
							flightBlocker = true;
						}
					}
					bool flyer = attacker.HasAbility(Ability.Flying);
					if (attacker.temporaryMods.Count > 0)
					{
						foreach (CardModificationInfo mod in attacker.temporaryMods)
						{
							if (mod.abilities.Contains(Ability.Flying))
							{
								flyer = true;
							}
						}
					}
					bool isMoon = false;
					if (RunState.Run.regionTier == 4)
					{
						CardSlot moonCardSlot = Singleton<BoardManager>.Instance.GetSlots(false).Find((CardSlot x) => x.Card != null && x.Card.Info.HasTrait(Trait.Giant));
						if (moonCardSlot != null) { isMoon = true; }
					}

					GemType attacking = GemType.Green;
					bool mana = false;

					if (attacker.Info.gemsCost.Count > 0)
					{
						attacking = attacker.Info.gemsCost[0];
						switch (attacker.Info.gemsCost[0])
						{
							case GemType.Green:
								mox = GameObject.Instantiate(GameObject.Find("emeraldMoxPref"));
								break;
							case GemType.Orange:
								mox = GameObject.Instantiate(GameObject.Find("rubyMoxPref"));
								break;
							case GemType.Blue:
								mox = GameObject.Instantiate(GameObject.Find("sapphireMoxPref"));
								break;
						}
					}
					else if (attacker.Info.HasTrait(Trait.Gem))
					{
						if (attacker.HasAbility(Ability.GainGemGreen))
						{
							mox = GameObject.Instantiate(GameObject.Find("emeraldMoxPref"));
						}
						else if (attacker.HasAbility(Ability.GainGemOrange))
						{
							attacking = GemType.Orange;
							mox = GameObject.Instantiate(GameObject.Find("rubyMoxPref"));
						}
						else if (attacker.HasAbility(Ability.GainGemBlue))
						{
							attacking = GemType.Blue;
							mox = GameObject.Instantiate(GameObject.Find("sapphireMoxPref"));
						}
						else
						{
							attacking = GemType.Orange;
							mox = GameObject.Instantiate(GameObject.Find("rubyMoxPref"));
							mox.transform.Find("Gem").gameObject.GetComponent<MeshRenderer>().material.mainTexture = Tools.getImage("manashard.png");
						}
					}
					else if (attacker.Info.BloodCost > 0 || attacker.Info.BonesCost > 0 || attacker.Info.BloodCost == 0)
					{
						mana = true;
						attacking = GemType.Orange;
						mox = GameObject.Instantiate(GameObject.Find("rubyMoxPref"));
						mox.transform.Find("Gem").gameObject.GetComponent<MeshRenderer>().material.mainTexture = Tools.getImage("manashard.png");
					}
					if (opponentSlot.transform.childCount > 5 && opposingSlot.Card != null && !flyer && !opposingSlot.Card.HasAbility(Ability.Submerge) && !opposingSlot.Card.HasAbility(MagnificusMod.SigilCode.submergekraken.ability))
					{
						Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(MagnificusMod.Generation.FlashCard(opponentSlot.transform.GetChild(5).gameObject, 0.4f, attacking, mana));

					}
					else if (flyer && flightBlocker)
					{
						Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(MagnificusMod.Generation.FlashCard(opponentSlot.transform.GetChild(5).gameObject, 0.4f, attacking, mana));
					}
					else if (isMoon && GameObject.Find(opponentSlotName).transform.GetChild(0).childCount > 5)
					{
						Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(MagnificusMod.Generation.FlashCard(GameObject.Find(opponentSlotName).transform.GetChild(0).gameObject.transform.GetChild(5).gameObject, 0.4f, attacking, mana));
					}


					AudioController.Instance.PlaySound3D("card_attack_creature", MixerGroup.TableObjectsSFX, realCard.transform.position, 0.35f, 0f, new AudioParams.Pitch(AudioParams.Pitch.Variation.Small), null, new AudioParams.Randomization(noRepeating: false)).spatialBlend = 0.05f;


					mox.transform.parent = realCard.transform.parent;
					mox.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
					mox.transform.position = realCard.transform.position;
					if (realCard.GetComponent<Card>().Info.HasTrait(Trait.Giant))
					{
						mox.transform.localScale = new Vector3(1, 1, 1);
					}
					float isEnemy = attackingSlot.IsPlayerSlot ? 0 : 1.5f;
					/*
					float isBiStrike = 0;
					if (attacker.Info.HasAbility(Ability.SplitStrike) || attacker.Info.ModAbilities.Contains(Ability.SplitStrike) || attacker.Info.HasAbility(Ability.TriStrike) || attacker.Info.ModAbilities.Contains(Ability.TriStrike))
					{
						isBiStrike = -2f;

						List<CardSlot> opponentSlots = attacker.slot.IsPlayerSlot ? Singleton<BoardManager>.Instance.OpponentSlotsCopy : Singleton<BoardManager>.Instance.PlayerSlotsCopy;
						if (attacker.slot.Index == 0)
						{
							isBiStrike = 2f;
							if (opponentSlots[1].Card != null)
							{
								MagnificusMod.Generation.damageDoneThisTurn -= attackingSlot.Card.Attack;
							}
						}
						else if (attacker.slot.Index == 3 && opponentSlots[2].Card != null)
						{
							MagnificusMod.Generation.damageDoneThisTurn -= attackingSlot.Card.Attack;
						}
						else if (attacker.slot.Index == 2 && waitAfter == 0f || attacker.slot.Index == 1 && waitAfter == 0f)
						{
							int id = attackingSlot.Index;
							if (opponentSlots[id - 1].Card != null)
							{
								MagnificusMod.Generation.damageDoneThisTurn -= attackingSlot.Card.Attack;
							}
							if (opponentSlots[id + 1].Card != null)
							{
								MagnificusMod.Generation.damageDoneThisTurn -= attackingSlot.Card.Attack;
							}
						}
					}

					if (isBiStrike == -2 && waitAfter == 0.01f)
					{
						isBiStrike = 2;
					}
					else if (isBiStrike == -2 && waitAfter == 0.02f)
					{
						isBiStrike = 0;
					}*/
					if (!realCard.GetComponent<Card>().Info.HasTrait(Trait.Giant))
					{
						Tween.LocalPosition(mox.transform, new Vector3(0, 5 + isEnemy, 0), 0.15f, 0);
					}
					else
					{
						Tween.LocalPosition(mox.transform, new Vector3(12.1f, 8.5f + isEnemy, 0), 0.15f, 0);
					}
					isEnemy = attackingSlot.IsPlayerSlot ? 0 : 180f;
					Tween.LocalRotation(mox.transform, Quaternion.Euler(270, isEnemy, 0), 0.15f, 0.2f);
					Vector3 flyingStuff = new Vector3(opponentSlot.transform.position.x, opponentSlot.transform.position.y, opponentSlot.transform.position.z);
					if (flyer && !flightBlocker)
					{
						flyingStuff = new Vector3(opponentSlot.transform.position.x, 16.4488f, opponentSlot.transform.position.z);
					}
					Tween.Position(mox.transform, flyingStuff, 0.15f, 0.35f);
					Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(MagnificusMod.Generation.WaitThenDestroy(mox, 0.55f));

				}
				return true;
			}

			public static IEnumerator Postfix(IEnumerator enumerator, CombatPhaseManager __state, CardSlot attackingSlot, CardSlot opposingSlot, float waitAfter = 0f)
			{
				if (SceneLoader.ActiveSceneName == "finale_magnificus")
				{

					yield return Singleton<GlobalTriggerHandler>.Instance.TriggerCardsOnBoard(Trigger.SlotTargetedForAttack, false, new object[]
					{
					opposingSlot,
					attackingSlot.Card
					});
					yield return new WaitForSeconds(0.025f);
					if (attackingSlot.Card != null)
					{
						bool hasStrongPull = false;
						int dex = 0;
						List<CardSlot> cardSlots = attackingSlot.IsPlayerSlot ? Singleton<BoardManager>.Instance.OpponentSlotsCopy : Singleton<BoardManager>.Instance.PlayerSlotsCopy;
						if (RunState.Run.regionTier == 4)
						{
							foreach (CardSlot slot in cardSlots)
							{
								if (slot.Card != null)
								{
									if (slot.Card.HasAbility(SigilCode.StrongPull.ability))
									{
										dex = slot.Index;
										hasStrongPull = true;
									}
								}
							}
						}
						if (attackingSlot.Card.Anim.DoingAttackAnimation)
						{
							yield return new WaitUntil(() => !attackingSlot.Card.Anim.DoingAttackAnimation);
							yield return new WaitForSeconds(0.25f);
						}
						if (opposingSlot.Card != null && attackingSlot.Card.AttackIsBlocked(opposingSlot))
						{
							ProgressionData.SetAbilityLearned(Ability.PreventAttack);
							yield return __state.ShowCardBlocked(attackingSlot.Card);
						}
						else if (attackingSlot.Card.CanAttackDirectly(opposingSlot) && !hasStrongPull)
						{
							MagnificusMod.Generation.damageDoneThisTurn += attackingSlot.Card.Attack;
							if (attackingSlot.Card.TriggerHandler.RespondsToTrigger(Trigger.DealDamageDirectly, new object[]
							{
						attackingSlot.Card.Attack
							}))
							{
								yield return attackingSlot.Card.TriggerHandler.OnTrigger(Trigger.DealDamageDirectly, new object[]
								{
							attackingSlot.Card.Attack
								});
							}
						}
						else
						{
							float heightOffset = (opposingSlot.Card == null) ? 0f : opposingSlot.Card.SlotHeightOffset;
							if (heightOffset > 0f)
							{
								Tween.Position(attackingSlot.Card.transform, attackingSlot.Card.transform.position + Vector3.up * heightOffset, 0.05f, 0f, Tween.EaseInOut, Tween.LoopType.None, null, null, true);
							}
							//attackingSlot.Card.Anim.PlayAttackAnimation(attackingSlot.Card.IsFlyingAttackingReach(), opposingSlot, null);
							yield return new WaitForSeconds(0.07f);
							//attackingSlot.Card.Anim.SetAnimationPaused(true);
							PlayableCard attackingCard = attackingSlot.Card;
							yield return Singleton<GlobalTriggerHandler>.Instance.TriggerCardsOnBoard(Trigger.CardGettingAttacked, false, new object[]
							{
						opposingSlot.Card
							});
							if (attackingCard != null && attackingCard.Slot != null)
							{
								CardSlot opposeSlot = opposingSlot;
								if (hasStrongPull)
								{
									opposeSlot = cardSlots[dex];
								}
								//attackingSlot = attackingCard.Slot;
								//if (attackingSlot.Card.IsFlyingAttackingReach())
								//{
								//opposingSlot.Card.Anim.PlayJumpAnimation();
								//yield return new WaitForSeconds(0.3f);
								//attackingSlot.Card.Anim.PlayAttackInAirAnimation();
								//}
								//attackingSlot.Card.Anim.SetAnimationPaused(false);
								yield return new WaitForSeconds(0.05f);
								int overkillDamage = attackingSlot.Card.Attack - opposeSlot.Card.Health;
								yield return opposeSlot.Card.TakeDamage(attackingSlot.Card.Attack, attackingSlot.Card);
								yield return __state.DealOverkillDamage(overkillDamage, attackingSlot, opposeSlot);
								if (attackingSlot.Card != null && heightOffset > 0f)
								{
									yield return Singleton<BoardManager>.Instance.AssignCardToSlot(attackingSlot.Card, attackingSlot.Card.Slot, 0.1f, null, false);
								}
							}
							attackingCard = null;
						}
						yield return new WaitForSeconds(waitAfter);
					}
				}
				else
				{
					yield return Singleton<GlobalTriggerHandler>.Instance.TriggerCardsOnBoard(Trigger.SlotTargetedForAttack, false, new object[]
	{
		opposingSlot,
		attackingSlot.Card
	});
					yield return new WaitForSeconds(0.025f);
					if (attackingSlot.Card != null)
					{
						if (attackingSlot.Card.Anim.DoingAttackAnimation)
						{
							yield return new WaitUntil(() => !attackingSlot.Card.Anim.DoingAttackAnimation);
							yield return new WaitForSeconds(0.25f);
						}
						if (opposingSlot.Card != null && attackingSlot.Card.AttackIsBlocked(opposingSlot))
						{
							ProgressionData.SetAbilityLearned(Ability.PreventAttack);
							yield return __state.ShowCardBlocked(attackingSlot.Card);
						}
						else if (attackingSlot.Card.CanAttackDirectly(opposingSlot))
						{
							MagnificusMod.Generation.damageDoneThisTurn += attackingSlot.Card.Attack;
							yield return __state.VisualizeCardAttackingDirectly(attackingSlot, opposingSlot, attackingSlot.Card.Attack);
							if (attackingSlot.Card.TriggerHandler.RespondsToTrigger(Trigger.DealDamageDirectly, new object[]
							{
				attackingSlot.Card.Attack
							}))
							{
								yield return attackingSlot.Card.TriggerHandler.OnTrigger(Trigger.DealDamageDirectly, new object[]
								{
					attackingSlot.Card.Attack
								});
							}
						}
						else
						{
							float heightOffset = (opposingSlot.Card == null) ? 0f : opposingSlot.Card.SlotHeightOffset;
							if (heightOffset > 0f)
							{
								Tween.Position(attackingSlot.Card.transform, attackingSlot.Card.transform.position + Vector3.up * heightOffset, 0.05f, 0f, Tween.EaseInOut, Tween.LoopType.None, null, null, true);
							}
							attackingSlot.Card.Anim.PlayAttackAnimation(attackingSlot.Card.IsFlyingAttackingReach(), opposingSlot, null);
							yield return new WaitForSeconds(0.07f);
							attackingSlot.Card.Anim.SetAnimationPaused(true);
							PlayableCard attackingCard = attackingSlot.Card;
							yield return Singleton<GlobalTriggerHandler>.Instance.TriggerCardsOnBoard(Trigger.CardGettingAttacked, false, new object[]
							{
				opposingSlot.Card
							});
							if (attackingCard != null && attackingCard.Slot != null)
							{
								attackingSlot = attackingCard.Slot;
								if (attackingSlot.Card.IsFlyingAttackingReach())
								{
									opposingSlot.Card.Anim.PlayJumpAnimation();
									yield return new WaitForSeconds(0.3f);
									attackingSlot.Card.Anim.PlayAttackInAirAnimation();
								}
								attackingSlot.Card.Anim.SetAnimationPaused(false);
								yield return new WaitForSeconds(0.05f);
								int overkillDamage = attackingSlot.Card.Attack - opposingSlot.Card.Health;
								yield return opposingSlot.Card.TakeDamage(attackingSlot.Card.Attack, attackingSlot.Card);
								yield return __state.DealOverkillDamage(overkillDamage, attackingSlot, opposingSlot);
								if (attackingSlot.Card != null && heightOffset > 0f)
								{
									yield return Singleton<BoardManager>.Instance.AssignCardToSlot(attackingSlot.Card, attackingSlot.Card.Slot, 0.1f, null, false);
								}
							}
							attackingCard = null;
						}
						yield return new WaitForSeconds(waitAfter);
					}
				}
				yield break;
			}

		}

		[HarmonyPatch(typeof(MagnificusCombatPhaseManager), "DealOverkillDamage")]
		public class overkillfix
		{
			public static void Prefix(ref MagnificusCombatPhaseManager __state, ref MagnificusCombatPhaseManager __instance)
			{
				__state = __instance;
			}

			public static IEnumerator Postfix(IEnumerator enumerator, MagnificusCombatPhaseManager __state, int damage, CardSlot attackingSlot, CardSlot opposingSlot)
			{
				if (attackingSlot.Card != null && attackingSlot.IsPlayerSlot && damage > 0)
				{
					PlayableCard queuedCard = Singleton<BoardManager>.Instance.GetCardQueuedForSlot(opposingSlot);
					if (opposingSlot.Card != null && opposingSlot.Card.HasShield() || opposingSlot.Card != null)
					{
						yield break;
					}
					if (queuedCard != null)
					{
						yield return new WaitForSeconds(0.1f);
						Singleton<ViewManager>.Instance.SwitchToView(Singleton<BoardManager>.Instance.QueueView, false, false);
						yield return new WaitForSeconds(0.3f);
						if (queuedCard.HasAbility(Ability.PreventAttack) || queuedCard.HasTrait(Trait.EatsWarrens))
						{
							yield return __state.ShowCardBlocked(attackingSlot.Card);
						}
						else
						{
							yield return __state.PreOverkillDamage(queuedCard);
							yield return queuedCard.TakeDamage(damage, attackingSlot.Card);
							yield return __state.PostOverkillDamage(queuedCard);
							queuedCard.RenderCard();
							if (queuedCard.Health <= 0)
							{
								GameObject portraitSlots = GameObject.Find("OpponentSlots");
								int dex = opposingSlot.Index;
								Vector3 originPos = portraitSlots.transform.GetChild(dex).Find("QueuedCardFrame").position;
								Vector3 upPos = new Vector3(originPos.x, originPos.y, originPos.z);
								upPos.y += 1f;
								Tween.Position(portraitSlots.transform.GetChild(dex).Find("QueuedCardFrame"), upPos, 0.5f, 0f);
								GameObject quad = portraitSlots.transform.GetChild(dex).Find("QueuedCardFrame").gameObject.GetComponentInChildren<CanvasRenderStatsLayer>().gameObject.transform.Find("Quad").gameObject;
								quad.gameObject.SetActive(true);
								quad.GetComponent<MeshRenderer>().material.color = new Color(0.9333f, 0.9569f, 0.7765f, 0);
								for (int i = 0; i < 25; i++)
								{
									float modify = i * 4;
									modify /= 100;
									quad.GetComponent<MeshRenderer>().material.color = new Color(0.9333f, 0.9569f, 0.7765f, modify);
									yield return new WaitForSeconds(0.01f);
								}
								yield return new WaitForSeconds(0.1f);
								portraitSlots.transform.GetChild(dex).Find("QueuedCardFrame").gameObject.SetActive(false);
								portraitSlots.transform.GetChild(dex).Find("QueuedCardFrame").position = originPos;

							}
						}
					}
				}
				yield break;
			}
		}

		[HarmonyPatch(typeof(PlayableCard), "CanAttackDirectly")]
		public class attackdirectlyfix
		{
			public static bool Prefix(ref PlayableCard __instance, ref bool __result, CardSlot opposingSlot)
			{
				__result = opposingSlot.Card == null || (__instance.HasAbility(Ability.Flying) && !opposingSlot.Card.HasAbility(Ability.Reach)) || opposingSlot.Card.HasAbility(Ability.Submerge) || opposingSlot.Card.HasAbility(MagnificusMod.SigilCode.submergekraken.ability);
				return false;
			}
		}

		[HarmonyPatch(typeof(WizardBattle3DPortrait), "Awake")]
		public class solvemyproblems
		{
			public static bool Prefix()
			{
				return false;
			}
		}

		[HarmonyPatch(typeof(WizardBattlePortraitSlot), "ShowStatsPanel")]
		public class solvemyproblems2
		{
			public static bool Prefix()
			{
				return false;
			}
		}

		[HarmonyPatch(typeof(ScreenGlitchEffect), "SetIntensity")]
		public class solvemyproblems4returnoftheglitches
		{
			public static bool Prefix(ref ScreenGlitchEffect __instance, float intensity, float transitionDuration)
			{
				__instance.glitchSprite.gameObject.SetActive(false);
				return false;
			}
		}

		[HarmonyPatch(typeof(WizardCardAnimationController), "PlayAttackAnimation")]
		public class solvemyproblems5itreturns
		{
			public static bool Prefix()
			{
				return false;
			}
		}

		[HarmonyPatch(typeof(WizardBattle3DPortrait), "PlaySpawnAnimation")]
		public class solvemyproblems3butnotlazy
		{
			public static void Prefix(ref WizardBattle3DPortrait __instance)
			{
				__instance.gameObject.transform.position = new Vector3(0, -100, 0);
			}
		}

		//OnBellPressed
		[HarmonyPatch(typeof(CombatBell3D), "OnBellPressed")]
		public class BellLol
		{
			public static void Prefix()
			{
				if (SceneLoader.ActiveSceneName == "finale_magnificus")
				{
					GameObject.Find("CombatBell_Magnificus").transform.Find("Anim").transform.localPosition = new Vector3(0, 0, 0);
					Singleton<ViewManager>.Instance.SwitchToView(View.Default, false, true);
				}
			}
		}

		[HarmonyPatch(typeof(WizardBattlePortraitSlot), "SummonAnimation")]
		public class FinaleSlotFix2
		{
			public static void Prefix(ref WizardBattlePortraitSlot __instance, PlayableCard card)
			{
				if (card != null && (!card.HasTrait(Trait.EatsWarrens) || card.Info.GetExtendedPropertyAsBool("PhysicalSpell") != null) && !card.Dead)
				{
					__instance.glitched = true;
					GameObject cardModel = __instance.queueCard.gameObject;
					bool queuedCardSummon = card.OpponentCard && card.OriginatedFromQueue;
					GameObject cardModel2;
					cardModel2 = GameObject.Instantiate(GameObject.Find("OpponentSlots").transform.Find("3DPortraitSlot").Find("QueuedCardFrame").Find("Anim").Find("SineWaveMovement").GetChild(0).gameObject);


					if (!config.oldCardDesigns)
					{
						GameObject goodCardFrame = GameObject.Instantiate(card.gameObject.GetComponentInChildren<MagCardFrame>().gameObject);
						goodCardFrame.name = "cardFrame";
						goodCardFrame.transform.parent = cardModel2.transform.Find("RenderStatsLayer");
						goodCardFrame.transform.localRotation = Quaternion.Euler(0, 180, 0);
						goodCardFrame.transform.localScale = new Vector3(0.1785f, 0.105f, 0.05f);
						goodCardFrame.transform.localPosition = new Vector3(-0.01f, 0.0125f, 0);
					}

					cardModel2.SetActive(true);
					cardModel2.GetComponent<Card>().Info = card.Info;
					cardModel2.GetComponent<Card>().renderInfo = new CardRenderInfo();
					cardModel2.GetComponent<Card>().renderInfo.baseInfo = card.Info;
					cardModel2.GetComponent<Card>().renderInfo.attack = card.Attack;
					cardModel2.GetComponent<Card>().renderInfo.health = card.Health;
					cardModel2.GetComponent<Card>().renderInfo.baseInfo = card.renderInfo.baseInfo;
					cardModel2.GetComponent<Card>().renderInfo.temporaryMods = new List<CardModificationInfo>();
					cardModel2.GetComponent<Card>().RenderCard();
					cardModel2.transform.Find("RenderStatsLayer").Find("Quad").gameObject.SetActive(false);
					cardModel2.transform.Find("RenderStatsLayer").gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
					cardModel2.transform.parent = __instance.queueCardParent.parent;

					Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(MagnificusMod.Generation.SummonGoodCard(__instance, card, cardModel2, queuedCardSummon));
				}
			}
		}

		[HarmonyPatch(typeof(WizardBattlePortraitSlot), "RespondsToOtherCardDie")]
		public class FinaleSlotFix3
		{
			public static bool Prefix(ref WizardBattlePortraitSlot __instance, ref bool __result, PlayableCard card, CardSlot deathSlot, bool fromCombat, PlayableCard killer)
			{
				bool isReal;
				if (!card.Slot.IsPlayerSlot)
				{
					isReal = GameObject.Find("3DPortraitSlots").transform.Find("OpponentSlots").transform.GetChild(card.Slot.Index).childCount > 5;
				}
				else
				{
					isReal = GameObject.Find("3DPortraitSlots").transform.Find("PlayerSlots").transform.GetChild(card.Slot.Index).childCount > 5;
				}
				__result = card.Slot == __instance.cardSlot && isReal && card != null;
				return false;
			}
		}

		[HarmonyPatch(typeof(PlayableCard), "UpdateHandPosition")]
		public class FinaleHandFix
		{
			public static void Prefix(ref PlayableCard __instance, ref Vector3 handPos)
			{
				if (SceneLoader.ActiveSceneName != "finale_magnificus" || config.oldCardDesigns) return;
				int index = Singleton<PlayerHand>.Instance.cardsInHand.IndexOf(__instance);
				int mult = (index != 0 && __instance.transform.parent.GetChild(index - 1).localPosition.z < __instance.transform.localPosition.z) ? 1 : -1;
				if (Singleton<BoardManager>.Instance.ChoosingSlot && index == Singleton<PlayerHand>.Instance.cardsInHand.Count - 1) mult = 2;
				__instance.transform.Find("Quad").Find("CardBase").Find("RenderStatsLayer").localPosition = Vector3.Lerp(__instance.transform.Find("Quad").Find("CardBase").Find("RenderStatsLayer").localPosition, new Vector3(0, 0, (index * 0.0025f) * mult), Time.deltaTime * 8f);
			}
		}


		[HarmonyPatch(typeof(WizardBattlePortraitSlot), "OnOtherCardDie")]
		public class FinaleSlotFix3andahalf
		{
			public static void Prefix(out WizardBattlePortraitSlot __state, ref WizardBattlePortraitSlot __instance)
			{
				__state = __instance;
			}

			public static IEnumerator Postfix(IEnumerator enumerator, WizardBattlePortraitSlot __state, PlayableCard card, CardSlot deathSlot, bool fromCombat, PlayableCard killer)
			{
				if (card.HasTrait(Trait.EatsWarrens) && card.Info.GetExtendedPropertyAsBool("PhysicalSpell") == null) { yield break; }

				Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(MagnificusMod.Generation.WizardDeathAnim(__state.transform.GetChild(5).gameObject));
				__state.FlashGlowQuad(0.3f);
				__state.transform.GetComponentInChildren<WizardBattle3DPortrait>().PlayDeathAnimation(0.3f);
				yield return new WaitForSeconds(0.71f);
				if (__state.gameObject.transform.childCount > 5)
				{
					for (int b = __state.gameObject.transform.childCount - 1; b > 4; b--)
					{
						GameObject.Destroy(__state.gameObject.transform.GetChild(b).gameObject);
					}
				}
				yield break;
			}
		}


		[HarmonyPatch(typeof(TurnManager), "SetupPhase")]
		public class SpeedUpBattleIntro
		{
			public static void Prefix(out TurnManager __state, ref TurnManager __instance)
			{
				__state = __instance;
			}

			public static IEnumerator Postfix(IEnumerator enumerator, TurnManager __state, EncounterData encounterData)
			{
				__state.IsSetupPhase = true;
				Singleton<PlayerHand>.Instance.PlayingLocked = true;
				if (__state.SpecialSequencer != null)
				{
					yield return __state.SpecialSequencer.PreBoardSetup();
				}
				yield return new WaitForSeconds(0.15f);
				if (SceneLoader.ActiveSceneName == "finale_magnificus" && SavedVars.LearnedMechanics.Contains("liferace;") || SceneLoader.ActiveSceneName == "finale_magnificus" && SaveManager.saveFile.ascensionActive) { __state.StartCoroutine(Singleton<LifeManager>.Instance.Initialize(__state.SpecialSequencer == null || __state.SpecialSequencer.ShowScalesOnStart)); }
				else { yield return Singleton<LifeManager>.Instance.Initialize(__state.SpecialSequencer == null || __state.SpecialSequencer.ShowScalesOnStart); }
				if (ProgressionData.LearnedMechanic(MechanicsConcept.Rulebook) && Singleton<TableRuleBook>.Instance != null)
				{
					Singleton<TableRuleBook>.Instance.SetOnBoard(onBoard: true);
				}
				__state.StartCoroutine(Singleton<BoardManager>.Instance.Initialize());
				__state.StartCoroutine(Singleton<ResourcesManager>.Instance.Setup());
				yield return new WaitForSeconds(0.2f);
				yield return __state.opponent.IntroSequence(encounterData);
				__state.StartCoroutine(__state.PlacePreSetCards(encounterData));
				if (Singleton<BoonsHandler>.Instance != null)
				{
					yield return Singleton<BoonsHandler>.Instance.ActivatePreCombatBoons();
				}
				if (__state.SpecialSequencer != null)
				{
					yield return __state.SpecialSequencer.PreDeckSetup();
				}
				Singleton<PlayerHand>.Instance.Initialize();
				yield return Singleton<CardDrawPiles>.Instance.Initialize();
				if (__state.SpecialSequencer != null)
				{
					yield return __state.SpecialSequencer.PreHandDraw();
				}
				yield return Singleton<CardDrawPiles>.Instance.DrawOpeningHand(__state.GetFixedHand());
				if (__state.opponent.QueueFirstCardBeforePlayer)
				{
					yield return __state.opponent.QueueNewCards(doTween: true, changeView: false);
				}
				if (AscensionSaveData.Data.ChallengeIsActive(AscensionChallenge.StartingDamage))
				{
					ChallengeActivationUI.TryShowActivation(AscensionChallenge.StartingDamage);
					yield return Singleton<LifeManager>.Instance.ShowDamageSequence(1, 1, toPlayer: true, 0.125f, null, 0f, changeView: false);
				}
				__state.IsSetupPhase = false;
			}
		}

		[HarmonyPatch(typeof(WizardBattle3DPortrait), "PlayDeathAnimation")]
		public class FixAnnoyingErrorMessage
		{
			public static bool Prefix(ref WizardBattle3DPortrait __instance, float shrinkDelay)
			{
				CustomCoroutine.WaitThenExecute(0.7f, new Action(__instance.CleanUpAndDestroy), false);
				return false;
			}
		}

		[HarmonyPatch(typeof(Card), "ExitBoard")]
		public class FixCleanupCardBack
		{
			public static void Prefix(ref Card __instance)
			{
				if (SceneLoader.ActiveSceneName == "finale_magnificus")
				{
					try
					{
						__instance.SetCardback(Tools.getImage("magcardback.png"));
					}
					catch { }
				}
			}
		}

		[HarmonyPatch(typeof(Card), "UpdateAppearanceBehaviours")]
		public class FinaleAbilityFixAAAAA
		{
			public static bool Prefix(ref Card __instance)
			{
				if (SceneLoader.ActiveSceneName == "finale_magnificus")
				{
					return false;
				}
				return true;
			}
		}


		[HarmonyPatch(typeof(WizardBattlePortraitSlot), "ManagedUpdate")]
		public class FinaleRenderFix
		{
			public static bool Prefix(ref WizardBattlePortraitSlot __instance)
			{
				if (__instance.cardSlot.Card != null && __instance.gameObject.transform.childCount > 5)
				{
					//string slotName = Singleton<WizardPortraitSlotManager>.Instance.playerSlots.Contains(__instance) ? "PlayerSlots" : "OpponentSlots";
					//int dex = slotName == "PlayerSlots" ? Singleton<WizardPortraitSlotManager>.Instance.playerSlots.IndexOf(__instance) : Singleton<WizardPortraitSlotManager>.Instance.opponentSlots.IndexOf(__instance);
					if (__instance.gameObject.transform.GetChild(5).gameObject.name != "Wizard3DPortrait_Glitched(Clone)" && __instance.gameObject.transform.GetChild(5).gameObject.name != "ProjectileImpactEffects(Clone)")
					{
						string slotName = Singleton<WizardPortraitSlotManager>.Instance.playerSlots.Contains(__instance) ? "PlayerSlots" : "OpponentSlots";
						int dex = slotName == "PlayerSlots" ? Singleton<WizardPortraitSlotManager>.Instance.playerSlots.IndexOf(__instance) : Singleton<WizardPortraitSlotManager>.Instance.opponentSlots.IndexOf(__instance);
						PlayableCard cardLol = Singleton<MagnificusBoardManager>.Instance.transform.Find(slotName).GetChild(dex).GetChild(1).gameObject.GetComponent<PlayableCard>();
						GameObject card = __instance.gameObject.transform.GetChild(5).gameObject;
						if (card.name == "Wizard3DPortrait_Glitched(Clone)") { card = __instance.gameObject.transform.GetChild(6).gameObject; }

						MeshRenderer cardRender = card.transform.Find("RenderStatsLayer").gameObject.GetComponent<MeshRenderer>();

						renderCardTexture(cardLol, cardRender, true);

					}


				}

				if (__instance.cardSlot != null && Singleton<WizardPortraitSlotManager>.Instance.opponentSlots.Contains(__instance) && __instance.transform.Find("QueuedCardFrame").gameObject.activeSelf)
				{
					MeshRenderer queuedCardRender = __instance.transform.Find("QueuedCardFrame").gameObject.GetComponentInChildren<CanvasRenderStatsLayer>().gameObject.GetComponent<MeshRenderer>();
					int dex = Singleton<WizardPortraitSlotManager>.Instance.opponentSlots.IndexOf(__instance);

					if (Singleton<MagnificusBoardManager>.Instance.transform.Find("OpponentSlots").GetChild(dex + 4).childCount <= 0) return false;

					PlayableCard cardLol = (Singleton<MagnificusBoardManager>.Instance.transform.Find("OpponentSlots").GetChild(dex + 4).childCount > 1) ? Singleton<MagnificusBoardManager>.Instance.transform.Find("OpponentSlots").GetChild(dex + 4).GetChild(1).gameObject.GetComponent<PlayableCard>() : Singleton<MagnificusBoardManager>.Instance.transform.Find("OpponentSlots").GetChild(dex).gameObject.GetComponentInChildren<PlayableCard>();


					renderCardTexture(cardLol, queuedCardRender);
				}
				return false;
			}
		}

		public static void renderCardTexture(PlayableCard cardLol, MeshRenderer cardRender, bool reRenderAbilityIcons = false)
		{
			if (cardLol == null) return;

			if (cardRender.transform.parent.gameObject.GetComponent<Card>().renderInfo.temporaryMods.FindAll((CardModificationInfo x) => cardLol.renderInfo.temporaryMods.Contains(x)).Count != cardLol.renderInfo.temporaryMods.Count)
			{
				cardRender.transform.parent.gameObject.GetComponent<Card>().renderInfo.temporaryMods = new List<CardModificationInfo>(cardLol.renderInfo.temporaryMods);
				cardRender.transform.parent.gameObject.GetComponent<Card>().RenderCard();

				if (reRenderAbilityIcons) { renderAbilityIcons(cardLol, cardRender.gameObject); }
			}

			SkinnedMeshRenderer cardTex = cardLol.GetComponentInChildren<SkinnedMeshRenderer>();
			if (cardLol != null && cardTex != null && cardTex.material != null && cardTex.material.mainTexture != null && cardTex.material.mainTexture.width == cardRender.material.mainTexture.width && cardTex.material.mainTexture != cardRender.material.mainTexture)
				Graphics.CopyTexture_Full(cardTex.material.mainTexture, cardRender.material.mainTexture);
		}

		public static void renderAbilityIcons(PlayableCard cardLol, GameObject cardRender)
		{
			List<AbilityIconInteractable> abilityIcons = cardRender.transform.parent.gameObject.GetComponentInChildren<CardAbilityIcons>().abilityIcons;
			List<AbilityIconInteractable> trueAbilityIcons = cardLol.GetComponentInChildren<CardAbilityIcons>().abilityIcons;

			for (int i = 0; i < abilityIcons.Count; i++)
			{
				if (trueAbilityIcons.Count <= i) continue;
				if (abilityIcons[i].Ability != trueAbilityIcons[i].Ability) abilityIcons[i].Ability = trueAbilityIcons[i].Ability;
			}

		}

		[HarmonyPatch(typeof(Opponent), "QueueCard")]
		public class FinaleQueueFix
		{
			public static void Prefix(out Opponent __state, ref Opponent __instance)
			{
				__state = __instance;
			}

			public static IEnumerator Postfix(IEnumerator enumerator, Opponent __state, CardInfo cardInfo, CardSlot slot, bool doTween = true, bool changeView = true, bool setStartPosition = true)
			{
				if (changeView) Singleton<ViewManager>.Instance.SwitchToView(Singleton<BoardManager>.Instance.QueueView);
				yield return new WaitForSeconds(0.05f);
				PlayableCard playableCard = __state.CreateCard(cardInfo);
				Singleton<BoardManager>.Instance.QueueCardForSlot(playableCard, slot, 0.25f, doTween, setStartPosition);
				__state.Queue.Add(playableCard);
				if (SceneLoader.ActiveSceneName == "finale_magnificus")
				{
					playableCard.transform.parent = Singleton<BoardManager>.Instance.transform.Find("OpponentSlots").GetChild(slot.Index + 4);
					if (SaveManager.saveFile.ascensionActive && Generation.challenges.Contains("PaintedSigils") && Singleton<TurnManager>.Instance.TurnNumber % 2 == 0 && Singleton<TurnManager>.Instance.TurnNumber > 1)
					{
						List<Ability> modAbilites = new List<Ability> { Ability.BuffGems, Ability.ExplodeGems, Ability.ExplodeOnDeath,Ability.Reach, Ability.BuffNeighbours, Ability.DrawRabbits, SigilCode.GemGuardianFix.ability, SigilCode.Stimulation.ability,
						SigilCode.MoxStrafe.ability, Ability.StrafePush, Ability.MoveBeside, Ability.DrawRandomCardOnDeath, Ability.Submerge, Ability.MadeOfStone, SigilCode.MoxCycling.ability, SigilCode.LifeUpOmega.ability, SigilCode.GoobertDebuff.ability,
						SigilCode.MagDropSpear.ability, Ability.Sharp, SigilCode.OrluHit.ability, Ability.DeathShield};

						List<Ability> attackingAbilites = new List<Ability> { Ability.Flying, SigilCode.LifeSteal.ability, SigilCode.FrostyA.ability, Ability.Deathtouch, Ability.SwapStats };

						if (playableCard.Attack > 0) modAbilites.AddRange(attackingAbilites);

						CardModificationInfo sigilMod = new CardModificationInfo();
						sigilMod.abilities = new List<Ability> { modAbilites[Random.RandomRangeInt(0, modAbilites.Count)] };
						if (Random.RandomRangeInt(0, 100) > 100 - (RunState.Run.regionTier * 10) + (SavedVars.NodesCleared * 2f)) sigilMod.abilities.Add(modAbilites[Random.RandomRangeInt(0, modAbilites.Count)]);
						playableCard.AddTemporaryMod(sigilMod);
						ChallengeActivationUI.TryShowActivation(KayceeFixes.ChallengeManagement.PaintedSigils);
					}
				}
				yield break;
			}
		}


		[HarmonyPatch(typeof(ResourcesManager), "ForceGemsUpdate")]
		public class DuelDiskGemsFix
		{
			public static bool Prefix(ref ResourcesManager __instance)
			{
				if (SceneLoader.ActiveSceneName != "finale_magnificus") { return true; }
                __instance.gems.Clear();
                foreach (CardSlot cardSlot in Singleton<BoardManager>.Instance.GetSlots(true))
                {
					if (cardSlot.Card == null || cardSlot.Card.Dead) continue;

                    
                    foreach (Ability ability in cardSlot.Card.Info.Abilities)
                    {
						if (ability == Ability.GainGemBlue || ability == Ability.GainGemTriple || ability == SigilCode.MagGainGemTriple.ability) { __instance.gems.Add(GemType.Blue); }
                        if (ability == Ability.GainGemGreen || ability == Ability.GainGemTriple || ability == SigilCode.MagGainGemTriple.ability) { __instance.gems.Add(GemType.Green); }
                        if (ability == Ability.GainGemOrange || ability == Ability.GainGemTriple || ability == SigilCode.MagGainGemTriple.ability) { __instance.gems.Add(GemType.Orange); }
                    }
                    
                }
                for (int j = 0; j < 3; j++)
                {
                    __instance.SetGemOnImmediate((GemType)j, __instance.gems.Contains((GemType)j));
                }

                Generation.updateDuelDiskGems();
				return false;
            }
		}
	}
}
