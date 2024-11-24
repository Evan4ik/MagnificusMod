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

namespace MagnificusMod
{
	public static class SigilPatches
	{
		[HarmonyPatch(typeof(RandomAbility), "AddMod")]
		public class AmorphousFix
		{
			public static bool Prefix(ref RandomAbility __instance)
			{
				if (SceneLoader.ActiveSceneName == "finale_magnificus")
				{
					__instance.Card.Status.hiddenAbilities.Add(__instance.Ability);
					List<Ability> learnedAbilities = AbilitiesUtil.GetLearnedAbilities(false, 0, 5, AbilityMetaCategory.MagnificusRulebook);
					var instance = __instance;
					List<Ability> bannedAbilites = new List<Ability> { Ability.EdaxioArms, Ability.EdaxioHead, Ability.EdaxioLegs, Ability.EdaxioTorso, Ability.VirtualReality, Ability.GainGemBlue, Ability.GainGemGreen, Ability.GainGemOrange, Ability.DropRubyOnDeath, Ability.GemsDraw };
					if (__instance.Card.Info.HasTrait(Trait.EatsWarrens)) { bannedAbilites.Add(Ability.Tutor); }
					learnedAbilities.RemoveAll((Ability x) => x == Ability.RandomAbility || instance.Card.HasAbility(x) || bannedAbilites.Contains(x) || AbilitiesUtil.GetInfo(x).activated || AbilitiesUtil.GetInfo(x).powerLevel > 5);
					Ability result = Ability.Sharp;
					if (learnedAbilities.Count > 0)
					{
						result = learnedAbilities[SeededRandom.Range(0, learnedAbilities.Count, Environment.TickCount)];
					}
					CardModificationInfo cardModificationInfo = new CardModificationInfo(result);
					CardModificationInfo cardModificationInfo2 = __instance.Card.TemporaryMods.Find((CardModificationInfo x) => x.HasAbility(instance.Ability));
					if (cardModificationInfo2 == null)
					{
						cardModificationInfo2 = __instance.Card.Info.Mods.Find((CardModificationInfo x) => x.HasAbility(instance.Ability));
					}
					if (cardModificationInfo2 != null)
					{
						cardModificationInfo.fromTotem = cardModificationInfo2.fromTotem;
						cardModificationInfo.fromCardMerge = cardModificationInfo2.fromCardMerge;
					}
					__instance.Card.AddTemporaryMod(cardModificationInfo);
					return false;
				}
				return true;
			}
		}

		[HarmonyPatch(typeof(DrawRabbits), "CardToDraw", MethodType.Getter)]
		public class RabbitFix
		{
			public static bool Prefix(ref DrawRabbits __instance, ref CardInfo __result)
			{
				if (SceneLoader.ActiveSceneName != "finale_magnificus") { return true; }
				List<string> cardToGet = new List<string>();
				MagCurrentNode.GetSideDeck();
				string text = File.ReadAllText(SaveManager.SaveFolderPath + "MagnificusModSave.gwsave");
				string[] array3 = text.Split('R');
				array3 = array3[1].Split(',');
				for (int j = 0; j < int.Parse(array3[0]); j++)
				{ cardToGet.Add("mag_orangemoxrabbit"); }
				for (int k = 0; k < int.Parse(array3[1]); k++)
				{ cardToGet.Add("mag_greenmoxrabbit"); }
				for (int l = 0; l < int.Parse(array3[2]); l++)
				{ cardToGet.Add("mag_moxrabbit"); }
				CardInfo cardByName = CardLoader.GetCardByName(cardToGet[UnityEngine.Random.RandomRangeInt(0, cardToGet.Count)]);
				cardByName.Mods.AddRange(__instance.GetNonDefaultModsFromSelf(new Ability[]
				{
				__instance.Ability
				}));
				__result = cardByName;
				return false;
			}
		}

		[HarmonyPatch(typeof(AbilityBehaviour), "GetNonDefaultModsFromSelf")]
		public class RabbitFix2
		{
			public static bool Prefix(ref AbilityBehaviour __instance, ref List<CardModificationInfo> __result, params Ability[] exclude)
			{
				if (SceneLoader.ActiveSceneName != "finale_magnificus") { return true; }
				List<Ability> abilities = __instance.Card.Info.Abilities;
				foreach (CardModificationInfo cardModificationInfo in __instance.Card.TemporaryMods)
				{
					abilities.AddRange(cardModificationInfo.abilities);
				}
				foreach (Ability item in __instance.Card.Info.DefaultAbilities)
				{
					abilities.Remove(item);
				}
				foreach (Ability item2 in exclude)
				{
					abilities.Remove(item2);
				}
				if (abilities.Count == 0)
				{
					__result = new List<CardModificationInfo>();
					return false;
				}
				CardModificationInfo cardModificationInfo2 = new CardModificationInfo();
				if (SceneLoader.ActiveSceneName != "finale_magnificus") { cardModificationInfo2.fromCardMerge = true; }
				cardModificationInfo2.abilities.AddRange(abilities);
				__result = new List<CardModificationInfo>
				{
					cardModificationInfo2
				};
				return false;
			}
		}


		[HarmonyPatch(typeof(ExplodeOnDeath), "BombCard")]
		public class ExplodeFix
		{
			public static void Prefix(ref ExplodeOnDeath __instance, out ExplodeOnDeath __state)
			{
				__state = __instance;
			}

			public static IEnumerator Postfix(IEnumerator enumerator, ExplodeOnDeath __state, PlayableCard target, PlayableCard attacker)
			{
				GameObject bomb = SceneLoader.ActiveSceneName == "finale_magnificus" ? GameObject.Instantiate(GameObject.Find("sapphireMoxPref")) : GameObject.Instantiate(__state.bombPrefab);
				if (SceneLoader.ActiveSceneName != "finale_magnificus")
				{
					bomb.transform.position = attacker.transform.position + Vector3.up * 0.1f;
					Tween.Position(bomb.transform, target.transform.position + Vector3.up * 0.1f, 0.5f, 0f, Tween.EaseLinear);
				} else
                {
					bomb.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
					bomb.transform.Find("Gem").gameObject.GetComponent<MeshRenderer>().material = (Resources.Load("art/assets3d/gametable/robomodules/Unlit_Gems") as Material);

					GameObject slotCard = GameObject.Find(attacker.slot.IsPlayerSlot ? "PlayerSlots" : "OpponentSlots").transform.GetChild(attacker.slot.Index).gameObject; 
					bomb.transform.position = slotCard.transform.position + Vector3.up * 0.95f;
					GameObject oppCard = GameObject.Find(target.slot.IsPlayerSlot ? "PlayerSlots" : "OpponentSlots").transform.GetChild(target.slot.Index).gameObject;
					Tween.Position(bomb.transform, oppCard.transform.position + Vector3.up * 0.75f, 0.5f, 0f, Tween.EaseLinear);
				}
				yield return new WaitForSeconds(0.5f);
				target.Anim.PlayHitAnimation();
				GameObject.Destroy(bomb);
				yield return target.TakeDamage(10, attacker);
				yield break;
			}
		}


		[HarmonyPatch(typeof(TailOnHit), "OnCardGettingAttacked")]
		public class skinkFix
		{
			public static void Prefix(out TailOnHit __state, ref TailOnHit __instance)
			{
				__state = __instance;
			}

			public static IEnumerator Postfix(IEnumerator enumerator, TailOnHit __state)
			{
				CardSlot slot = __state.Card.Slot;
				CardSlot toLeft = Singleton<BoardManager>.Instance.GetAdjacent(__state.Card.Slot, true);
				CardSlot toRight = Singleton<BoardManager>.Instance.GetAdjacent(__state.Card.Slot, false);
				bool flag = toLeft != null && toLeft.Card == null;
				bool toRightValid = toRight != null && toRight.Card == null;
				bool flag2 = flag || toRightValid;
				if (flag2)
				{
					yield return __state.PreSuccessfulTriggerSequence();
					yield return new WaitForSeconds(0.2f);
					bool flag3 = toRightValid;
					if (flag3)
					{
						yield return Singleton<BoardManager>.Instance.AssignCardToSlot(__state.Card, toRight, 0.2f, null, true);
					}
					else
					{
						yield return Singleton<BoardManager>.Instance.AssignCardToSlot(__state.Card, toLeft, 0.2f, null, true);
					}
					__state.Card.Anim.StrongNegationEffect();
					__state.Card.Status.hiddenAbilities.Add(__state.Ability);
					__state.Card.RenderCard();
					__state.SetTailLost(true);
					yield return new WaitForSeconds(0.2f);
					CardInfo info;
					if (__state.Card.Info.tailParams != null)
					{
						info = (__state.Card.Info.tailParams.tail.Clone() as CardInfo);
					}
					else
					{
						info = TailParams.GetDefaultTail(__state.Card.Info);
					}
					PlayableCard tail = CardSpawner.SpawnPlayableCardWithCopiedMods(info, __state.Card, Ability.TailOnHit);
					tail.transform.position = slot.transform.position + Vector3.back * 2f + Vector3.up * 2f;
					tail.transform.rotation = Quaternion.Euler(110f, 90f, 90f);
					yield return Singleton<BoardManager>.Instance.ResolveCardOnBoard(tail, slot, 0.1f, null, true);
					Singleton<ViewManager>.Instance.SwitchToView(View.Board, false, false);
					yield return new WaitForSeconds(0.2f);
					tail.Anim.StrongNegationEffect();
					yield return __state.StartCoroutine(__state.LearnAbility(0.5f));
					yield return new WaitForSeconds(0.2f);
				}
				yield break;
			}
		}

		[HarmonyPatch(typeof(BoardManager), "AssignCardToSlot")]
		public class StrafeFix
		{
			public static void Prefix(out BoardManager __state, ref BoardManager __instance)
			{
				__state = __instance;
			}

			public static IEnumerator Postfix(IEnumerator enumerator, BoardManager __state, PlayableCard card, CardSlot slot, float transitionDuration = 0.1f, Action tweenCompleteCallback = null, bool resolveTriggers = true)
			{
				CardSlot slot2 = card.Slot;
				if (card.Slot != null)
				{
					card.Slot.Card = null;
				}
				if (slot.Card != null)
				{
					slot.Card.Slot = null;
				}
				card.SetEnabled(false);
				slot.Card = card;
				card.Slot = slot;
				card.RenderCard();
				if (!slot.IsPlayerSlot)
				{
					card.SetIsOpponentCard(true);
				}
				card.transform.parent = slot.transform;
				card.Anim.PlayRiffleSound();
				string slotName = slot.IsPlayerSlot ? "PlayerSlots" : "OpponentSlots";
				if (SceneLoader.ActiveSceneName == "finale_magnificus" && !card.HasTrait(Trait.Giant) && slot2 != slot)
				{
					try
					{
						if (GameObject.Find(slotName).transform.GetChild(slot2.Index).childCount > 5 && GameObject.Find(slotName).transform.GetChild(slot2.Index).GetChild(5).gameObject != null)
						{
							GameObject WizardCardBoy = GameObject.Find(slotName).transform.GetChild(slot2.Index).GetChild(5).gameObject;
							Vector3 slotPos = new Vector3(GameObject.Find(slotName).transform.GetChild(slot.Index).position.x, WizardCardBoy.transform.position.y, WizardCardBoy.transform.position.z);
							Tween.Position(WizardCardBoy.transform, slotPos, 0.25f, 0.05f);
						}
					}
					catch { }
				}

				Tween.LocalPosition(card.transform, Vector3.up * (0.025f + card.SlotHeightOffset), transitionDuration, 0.05f, Tween.EaseOut, Tween.LoopType.None, null, delegate ()
				{
					Action tweenCompleteCallback2 = tweenCompleteCallback;
					if (tweenCompleteCallback2 != null)
					{
						tweenCompleteCallback2();
					}
					card.Anim.PlayRiffleSound();
				}, true);
				if (SceneLoader.ActiveSceneName != "finale_magnificus") { Tween.Rotation(card.transform, slot.transform.GetChild(0).rotation, transitionDuration, 0f, Tween.EaseOut, Tween.LoopType.None, null, null, true); }
				else { Tween.LocalRotation(card.transform, Quaternion.Euler(90, 0, 0), transitionDuration, 0f, Tween.EaseOut, Tween.LoopType.None, null, null, true); }
				if (resolveTriggers && slot2 != card.Slot)
				{
					yield return Singleton<GlobalTriggerHandler>.Instance.TriggerCardsOnBoard(Trigger.OtherCardAssignedToSlot, false, new object[]
					{
					card
					});
				}
				if (SceneLoader.ActiveSceneName == "finale_magnificus" && !card.HasTrait(Trait.Giant) && slot2 != slot)
				{
					try
					{
						if (GameObject.Find(slotName).transform.GetChild(slot2.Index).childCount > 5 && GameObject.Find(slotName).transform.GetChild(slot2.Index).GetChild(5).gameObject != null)
						{
							GameObject.Find(slotName).transform.GetChild(slot2.Index).GetChild(5).parent = GameObject.Find(slotName).transform.GetChild(slot.Index);
							GameObject.Find(slotName).transform.GetChild(slot2.Index).GetChild(5).parent = GameObject.Find(slotName).transform.GetChild(slot.Index);
						}
					}
					catch { }
				}
				yield break;
			}
		}

		[HarmonyPatch(typeof(Strafe), "MoveToSlot")]
		public class StrafeFix2
		{
			public static void Prefix(out Strafe __state, ref Strafe __instance)
			{
				__state = __instance;
			}

			public static IEnumerator Postfix(IEnumerator enumerator, Strafe __state, CardSlot destination, bool destinationValid)
			{
				__state.Card.RenderInfo.SetAbilityFlipped(__state.Ability, __state.movingLeft);
				__state.Card.RenderInfo.flippedPortrait = (__state.movingLeft && __state.Card.Info.flipPortraitForStrafe);
				__state.Card.RenderCard();
				if (destination != null && destinationValid)
				{
					CardSlot oldSlot = __state.Card.Slot;
					yield return Singleton<BoardManager>.Instance.AssignCardToSlot(__state.Card, destination, 0.11f, null, true);
					yield return __state.PostSuccessfulMoveSequence(oldSlot);
					yield return new WaitForSeconds(0.25f);
					oldSlot = null;
				}
				else
				{
					__state.Card.Anim.StrongNegationEffect();
					yield return new WaitForSeconds(0.15f);
				}
				yield break;
			}
		}

		[HarmonyPatch(typeof(GemDependant), "OnResolveOnBoard")]
		public class gemDependantResolveFix
		{
			public static void Prefix(out GemDependant __state, ref GemDependant __instance)
			{
				__state = __instance;
			}
			public static IEnumerator Postfix(IEnumerator enumerator, GemDependant __state)
			{
				yield return __state.PreSuccessfulTriggerSequence();
				if (!__state.Card.slot.IsPlayerSlot && __state.Card.OriginatedFromQueue)
				{
					GameObject.Find("OpponentSlots").transform.GetChild(__state.Card.slot.Index).transform.Find("QueuedCardFrame").gameObject.SetActive(false);
				}
				yield return __state.Card.Die(false, null, true);
				yield return __state.LearnAbility(0.25f);
				yield break;
			}
		}

		[HarmonyPatch(typeof(DrawCreatedCard), "CreateDrawnCard")]
		public class nerfPotions
		{
			public static void Prefix(out DrawCreatedCard __state, ref DrawCreatedCard __instance)
			{
				__state = __instance;
			}
			public static IEnumerator Postfix(IEnumerator enumerator, DrawCreatedCard __state)
			{
				List<CardModificationInfo> tempMods = __state.CardToDrawTempMods;
				if (Singleton<ViewManager>.Instance.CurrentView != __state.DrawCardView)
				{
					yield return new WaitForSeconds(0.2f);
					Singleton<ViewManager>.Instance.SwitchToView(__state.DrawCardView);
					yield return new WaitForSeconds(0.2f);
				}
				if (__state.CardToDraw.name == "mag_potion" && __state.CardToDraw.BloodCost < 3 && SaveManager.saveFile.ascensionActive)
				{
					CardModificationInfo increaseCost = new CardModificationInfo();
					increaseCost.bloodCostAdjustment = 1;
					if (tempMods != null)
					{ tempMods.Add(increaseCost); }
					else
					{ tempMods = new List<CardModificationInfo> { increaseCost }; }
				}
				yield return Singleton<CardSpawner>.Instance.SpawnCardToHand(__state.CardToDraw, tempMods);
				yield return new WaitForSeconds(0.45f);
				yield return __state.LearnAbility(0.1f);
			}
		}


		public static List<CardSlot> GetAffectedSlots(this CardSlot slot, PlayableCard card)
		{
			if (card.HasAbility(Ability.AllStrike))
				return Singleton<BoardManager>.Instance.AllSlotsCopy.FindAll(s => IsValidTarget(s, card));

			List<CardSlot> retval = new();

			retval.Add(slot);

			retval.Sort((CardSlot a, CardSlot b) => a.Index - b.Index);
			return retval;
		}
		public static bool IsValidTarget(this CardSlot slot, PlayableCard card, bool checkSingleSlot = false)
		{
			if (checkSingleSlot)
			{
				if (card.TriggerHandler.RespondsToTrigger(Trigger.ResolveOnBoard, Array.Empty<object>()))
					return true;

				if (card.TriggerHandler.RespondsToTrigger(Trigger.SlotTargetedForAttack, new object[] { slot, card }))
					return true;

				return false;
			}
			else
			{
				// We need to test all possible slots
				return GetAffectedSlots(slot, card).Exists(subSlot => IsValidTarget(subSlot, card, true));
			}
		}
		public static bool HasValidTarget(this PlayableCard card)
		{
			List<CardSlot> allSlots = Singleton<BoardManager>.Instance.AllSlotsCopy;
			foreach (CardSlot slot in allSlots)
			{
				if (IsValidTarget(slot, card))
				{
					return true; // There is at least one slot that responds to this trigger, so leave the result as-is
				}
			}

			// If we got this far without finding a slot that the card responds to, then...no good
			return false;
		}



		[HarmonyPatch(typeof(CreateCardsAdjacent), "ModifySpawnedCard")]
		public class AdjacentCardsFix
		{
			public static bool Prefix(ref CreateCardsAdjacent __instance, CardInfo card)
			{
				List<Ability> abilities = __instance.Card.Info.Abilities;
				var instance = __instance;
				foreach (CardModificationInfo cardModificationInfo in __instance.Card.TemporaryMods)
				{
					abilities.AddRange(cardModificationInfo.abilities);
				}
				abilities.RemoveAll((Ability x) => x == instance.Ability);
				if (abilities.Count > 4)
				{
					abilities.RemoveRange(3, abilities.Count - 4);
				}
				CardModificationInfo cardModificationInfo2 = new CardModificationInfo();
				if (SceneLoader.ActiveSceneName != "finale_magnificus") { cardModificationInfo2.fromCardMerge = true; }
				cardModificationInfo2.abilities = abilities;
				card.Mods.Add(cardModificationInfo2);
				return false;
			}
		}

		[HarmonyPatch(typeof(PlayableCard), "CanPlay")]
		public class TargetSpellsMustHaveValidTarget
		{
			public static void Postfix(ref bool __result, ref PlayableCard __instance)
			{

				if (__instance.Info.HasTrait(Trait.EatsWarrens) && __instance.Info.GetExtendedPropertyAsBool("TargetedSpell") == true || __instance.Info.name == "mag_potion")
				{
					int boardCards = 0;
					foreach (CardSlot card in Singleton<BoardManager>.Instance.PlayerSlotsCopy)
					{
						if (card.Card != null) { boardCards++; }
					}
					__result = (boardCards >= __instance.Info.BloodCost);
					return;
				}
				if (!__result) // Don't do anything if the result's already false
					return;
				if (__instance.Info.GetExtendedPropertyAsBool("TargetedSpell") == true && !HasValidTarget(__instance))
					__result = false;
			}
		}
		[HarmonyPatch(typeof(PlayerHand), "SelectSlotForCard")]
		public class SpellsResolveDifferently
		{
			public static IEnumerator Postfix(IEnumerator sequenceResult, PlayableCard card)
			{
				if (card != null && card.Info.GetExtendedPropertyAsBool("TargetedSpell") == null)
				{
					while (sequenceResult.MoveNext())
						yield return sequenceResult.Current;

					yield break;
				}

				// The rest of this comes from the original code in PlayerHand.SelectSlotForCard
				Singleton<PlayerHand>.Instance.CardsInHand.ForEach(delegate (PlayableCard x)
				{
					x.SetEnabled(enabled: false);
				});
				yield return new WaitWhile(() => Singleton<PlayerHand>.Instance.ChoosingSlot);

				Singleton<PlayerHand>.Instance.OnSelectSlotStartedForCard(card);

				if (Singleton<RuleBookController>.Instance != null)
					Singleton<RuleBookController>.Instance.SetShown(shown: false);

				Singleton<BoardManager>.Instance.CancelledSacrifice = false;

				Singleton<PlayerHand>.Instance.choosingSlotCard = card;

				if (card != null && card.Anim != null)
					card.Anim.SetSelectedToPlay(selected: true);

				Singleton<BoardManager>.Instance.ShowCardNearBoard(card, showNearBoard: true);

				if (Singleton<TurnManager>.Instance.SpecialSequencer != null)
					yield return Singleton<TurnManager>.Instance.SpecialSequencer.CardSelectedFromHand(card);

				bool cardWasPlayed = false;
				bool requiresSacrifices = card.Info.BloodCost > 0;
				if (requiresSacrifices)
				{
					List<CardSlot> validSlots = Singleton<BoardManager>.Instance.PlayerSlotsCopy.FindAll((CardSlot x) => x.Card != null);
					yield return Singleton<BoardManager>.Instance.ChooseSacrificesForCard(validSlots, card);
				}

				// All card slots
				List<CardSlot> allSlots = Singleton<BoardManager>.Instance.AllSlotsCopy;

				if (card.Info.GetExtendedPropertyAsBool("TargetAllSpell") != null)
				{
					Generation.SetBigOpponentSlotHitboxes(true, GameObject.Find("BoardManager"), true);
					Singleton<ViewController>.Instance.LockState = ViewLockState.Unlocked;
					Singleton<ViewManager>.Instance.SwitchToView(View.OpponentQueue, false, false);
				}

				if (!Singleton<BoardManager>.Instance.CancelledSacrifice)
				{
					IEnumerator chooseSlotEnumerator = Singleton<BoardManager>.Instance.ChooseSlot(allSlots, !requiresSacrifices);
					chooseSlotEnumerator.MoveNext();

					// Mark which slots can be targeted before letting the code continue
					foreach (CardSlot slot in allSlots)
					{
						bool isValidTarget = (card.Info.GetExtendedPropertyAsBool("TargetedSpell") == true) ? IsValidTarget(slot, card) : true;

						slot.SetEnabled(isValidTarget);
						slot.ShowState(isValidTarget ? HighlightedInteractable.State.Interactable : HighlightedInteractable.State.NonInteractable);
						slot.Chooseable = isValidTarget;
					}

					yield return chooseSlotEnumerator.Current;
					// Run through the rest of the code to determine what slot has been targeted
					while (chooseSlotEnumerator.MoveNext())
						yield return chooseSlotEnumerator.Current;


					if (!Singleton<BoardManager>.Instance.cancelledPlacementWithInput)// && Singleton<ViewManager>.Instance.CurrentView == View.OpponentQueue))
					{
						cardWasPlayed = true;
						card.Anim.SetSelectedToPlay(false);
						// Now we take care of actually playing the card
						if (Singleton<PlayerHand>.Instance.CardsInHand.Contains(card))
						{
							if (card.Info.BonesCost > 0)
								yield return Singleton<ResourcesManager>.Instance.SpendBones(card.Info.BonesCost);

							if (card.EnergyCost > 0)
								yield return Singleton<ResourcesManager>.Instance.SpendEnergy(card.EnergyCost);

							Singleton<PlayerHand>.Instance.RemoveCardFromHand(card);

							// PlayFromHand
							if (card.TriggerHandler.RespondsToTrigger(Trigger.PlayFromHand, Array.Empty<object>()))
								yield return card.TriggerHandler.OnTrigger(Trigger.PlayFromHand, Array.Empty<object>());

							// ResolveOnBoard - recreates full behaviour
							if (card.TriggerHandler.RespondsToTrigger(Trigger.ResolveOnBoard, Array.Empty<object>()))
							{
								List<CardSlot> resolveSlots;
								if (card.Info.GetExtendedPropertyAsBool("TargetedSpell") == true)
									resolveSlots = GetAffectedSlots(Singleton<BoardManager>.Instance.LastSelectedSlot, card);
								else
									resolveSlots = new List<CardSlot>() { null }; // For global spells, just resolve once, globally

								foreach (CardSlot slot in resolveSlots)
								{
									card.Slot = slot;

									IEnumerator resolveTrigger = card.TriggerHandler.OnTrigger(Trigger.ResolveOnBoard, Array.Empty<object>());
									for (bool active = true; active;)
									{
										try // Catch exceptions only on executing/resuming the iterator function
										{
											active = resolveTrigger.MoveNext();
										}
										catch (Exception ex)
										{
											Debug.Log("IteratorFunction() threw exception: " + ex);
										}

										if (active) // Yielding and other loop logic is moved outside of the try-catch
											yield return resolveTrigger.Current;
									}

									card.Slot = null;
								}
							}


							// SlotTargetedForAttack (targeted spells only)
							if (card.Info.GetExtendedPropertyAsBool("TargetedSpell") == true)
							{
								foreach (CardSlot targetSlot in GetAffectedSlots(Singleton<BoardManager>.Instance.LastSelectedSlot, card))
								{
									object[] targetArgs = new object[] { targetSlot, card };
									yield return card.TriggerHandler.OnTrigger(Trigger.SlotTargetedForAttack, targetArgs);
								}
							}

							card.Dead = true;
							card.Anim.PlayDeathAnimation(false);

							// Die
							object[] diedArgs = new object[] { true, null };
							if (card.TriggerHandler.RespondsToTrigger(Trigger.Die, diedArgs))
								yield return card.TriggerHandler.OnTrigger(Trigger.Die, diedArgs);



							yield return new WaitUntil(() => Singleton<GlobalTriggerHandler>.Instance.StackSize == 0);

							if (Singleton<TurnManager>.Instance.IsPlayerTurn)
							{
								Singleton<BoardManager>.Instance.playerCardsPlayedThisRound.Add(card.Info);
							}

							Singleton<InteractionCursor>.Instance.ClearForcedCursorType();
							Singleton<ViewController>.Instance.LockState = ViewLockState.Unlocked;
							Singleton<ViewManager>.Instance.SwitchToView(View.WizardBattleUnits, false, false);
							if (card.Info.GetExtendedPropertyAsBool("TargetAllSpell") != null)
							{
								Generation.SetBigOpponentSlotHitboxes(false, GameObject.Find("BoardManager"), true);
							}
							yield return new WaitForSeconds(0.6f);
							GameObject.Destroy(card.gameObject, 0.5f);
							Singleton<ViewManager>.Instance.SwitchToView(View.WizardBattleUnits);
						}
					}
				}
				if (card.Info.GetExtendedPropertyAsBool("TargetAllSpell") != null)
				{
					Singleton<ViewController>.Instance.LockState = ViewLockState.Unlocked;
					Singleton<ViewManager>.Instance.SwitchToView(View.WizardBattleUnits, false, false);
					Generation.SetBigOpponentSlotHitboxes(false, GameObject.Find("BoardManager"), true);
				}
				if (!cardWasPlayed)
				{
					Singleton<BoardManager>.Instance.ShowCardNearBoard(card, false);
					Singleton<ViewController>.Instance.LockState = ViewLockState.Unlocked;
				}
				else
				{
					Plugin.spellsPlayed++;
				}

				Singleton<PlayerHand>.Instance.choosingSlotCard = null;

				if (card != null && card.Anim != null)
					card.Anim.SetSelectedToPlay(false);

				Singleton<PlayerHand>.Instance.CardsInHand.ForEach(delegate (PlayableCard x)
				{
					x.SetEnabled(true);
				});

				// Enable every slot
				foreach (CardSlot slot in allSlots)
				{
					slot.SetEnabled(true);
					slot.ShowState(HighlightedInteractable.State.Interactable);
					slot.Chooseable = false;
				}


				yield break;
			}
		}

		[HarmonyPatch(typeof(StatIconInteractable), "OnAlternateSelectStarted")]
		public class finallyMakeStatIconsRuleBookWork
		{
			public static bool Prefix(ref StatIconInteractable __instance)
			{
				if (SceneLoader.ActiveSceneName != "finale_magnificus") { return true; }
				Singleton<RuleBookController>.Instance.OpenToAbilityPage(StatIconInfo.GetIconInfo(__instance.statIcon).gbcDescription, __instance.card);
				return false;
			}
		}

		[HarmonyPatch(typeof(BoardManager), "ChooseSlot")]
		public class SpellsAlsoChooseSlotsDifferently
		{
			public static void Prefix(out BoardManager __state, ref BoardManager __instance)
			{
				__state = __instance;
			}
			public static IEnumerator Postfix(IEnumerator sequenceResult, BoardManager __state, List<CardSlot> validSlots, bool canCancel)
			{
				__state.ChoosingSlot = true;
				Singleton<InteractionCursor>.Instance.ForceCursorType(CursorType.Place);
				if (!canCancel)
				{
					Singleton<ViewManager>.Instance.Controller.SwitchToControlMode(__state.choosingSlotViewMode);
				}
				bool targetedSpell = Singleton<PlayerHand>.Instance.ChoosingSlotCard != null ? Singleton<PlayerHand>.Instance.ChoosingSlotCard.Info.GetExtendedPropertyAsBool("TargetAllSpell") == true : false;
				Singleton<ViewManager>.Instance.SwitchToView(targetedSpell ? View.OpponentQueue : __state.boardView);
				__state.cancelledPlacementWithInput = false;
				__state.currentValidSlots = validSlots;
				__state.LastSelectedSlot = null;
				foreach (CardSlot opponentSlot in __state.opponentSlots)
				{
					opponentSlot.SetEnabled(enabled: false);
					opponentSlot.ShowState(HighlightedInteractable.State.NonInteractable);
				}
				__state.SetQueueSlotsEnabled(slotsEnabled: false);
				foreach (CardSlot validSlot in validSlots)
				{
					validSlot.Chooseable = true;
				}
				yield return new WaitUntil(() => __state.LastSelectedSlot != null || (canCancel && __state.cancelledPlacementWithInput || targetedSpell && Singleton<ViewManager>.Instance.CurrentView != View.OpponentQueue));
				if (canCancel && __state.cancelledPlacementWithInput || targetedSpell && Singleton<ViewManager>.Instance.CurrentView != View.OpponentQueue)
				{
					Singleton<ViewManager>.Instance.SwitchToView(__state.defaultView);
				} else
                {
					__state.cancelledPlacementWithInput = false;
                }
				foreach (CardSlot opponentSlot2 in __state.opponentSlots)
				{
					opponentSlot2.SetEnabled(enabled: true);
					opponentSlot2.ShowState(HighlightedInteractable.State.Interactable);
				}
				__state.SetQueueSlotsEnabled(slotsEnabled: true);
				foreach (CardSlot validSlot2 in validSlots)
				{
					validSlot2.Chooseable = false;
				}
				Singleton<ViewManager>.Instance.Controller.SwitchToControlMode(__state.defaultViewMode);
				__state.ChoosingSlot = false;
				Singleton<InteractionCursor>.Instance.ClearForcedCursorType();
			}
		}
	}
}
