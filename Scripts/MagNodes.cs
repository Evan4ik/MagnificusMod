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
using MagModGeneration = MagnificusMod.Generation;
using MagCurrentNode = MagnificusMod.MagCurrentNode;
using static InscryptionAPI.Slots.SlotModificationManager;
using System.ComponentModel;

namespace MagnificusMod
{
    class MagNodes
    {
		[HarmonyPatch(typeof(ConsumableItemSlot), "OnCursorStay")]
		public class fixAnnoyingError
		{
			public static bool Prefix(ref ConsumableItemSlot __instance)
			{
				if (__instance.gameObject.name.ToLower().Contains("brush")) { return false; }
				return true;
			}
		}

		[HarmonyPatch(typeof(ConsumableItemSlot), "OnCursorSelectStart")]
		public class fixAnnoyingError2
		{
			public static bool Prefix(ref ConsumableItemSlot __instance)
			{
				if (__instance.gameObject.name.ToLower().Contains("brush")) { return false; }
				return true;
			}
		}

		[HarmonyPatch(typeof(ConsumableItemSlot), "CursorType", MethodType.Getter)]
		public class fixAnnoyingError3
		{
			public static bool Prefix(ref ConsumableItemSlot __instance, ref CursorType __result)
			{
				if (__instance.gameObject.name.ToLower().Contains("brush")) {
					__result = CursorType.Pickup;
					return false; 
				}
				if (!__instance.Consumable.CanActivate())
				{
					__result = CursorType.Default;
				}
				__result = CursorType.Pickup;
				return true;
			}
		}

		[HarmonyPatch(typeof(InteractableBase), "CursorType", MethodType.Getter)]
		public class FixNewGameCursor
		{
			public static bool Prefix(ref ConsumableItemSlot __instance, ref CursorType __result)
			{
				if (__instance.gameObject.name.Contains("newGameCard"))
				{
					__result = CursorType.Pickup;
					return false;
				}
				__result = CursorType.Default;
				return true;
			}
		}

		[HarmonyPatch(typeof(CardSingleChoicesSequencer), "CostChoiceChosen")]
		public class Patch
		{
			public static IEnumerator Postfix(IEnumerator enumerator, SelectableCard card)
			{
				CardInfo cardInfo;
				if (SceneLoader.ActiveSceneName == "finale_magnificus")
				{
					if (card.ChoiceInfo.resourceType == ResourceType.Blood)
					{
						GemType gemType = GemType.Green;
						switch (card.ChoiceInfo.resourceAmount)
						{
							case 1:
								gemType = GemType.Orange;
								break;
							case 2:
								gemType = GemType.Green;
								break;
							case 3:
								gemType = GemType.Blue;
								break;
						}
						List<CardInfo> list = CardLoader.GetUnlockedCards(CardMetaCategory.ChoiceNode, CardTemple.Wizard).FindAll((CardInfo x) => x.gemsCost.Count == 1 && x.gemsCost[0] == gemType );
						cardInfo = list.Count <= 0 ? null : CardLoader.Clone(list[SeededRandom.Range(0, list.Count, Environment.TickCount)]);
					}
					else
					{
						List<CardInfo> list = CardLoader.GetUnlockedCards(CardMetaCategory.ChoiceNode, CardTemple.Wizard).FindAll((CardInfo x) => x.BloodCost > 0 && x.GetExtendedProperty("ManaCost") != null);
						cardInfo = list.Count == 0 ? null : CardLoader.Clone(list[SeededRandom.Range(0, list.Count, Environment.TickCount)]);
					}

					if (cardInfo == null)
					{
						cardInfo = CardLoader.GetCardByName("mag_he");
					}
				}
				else
				{
					if (card.ChoiceInfo.resourceType == ResourceType.Blood)
					{
						cardInfo = CardLoader.GetRandomChoosableCardWithCost(SaveManager.SaveFile.GetCurrentRandomSeed(), card.ChoiceInfo.resourceAmount);
					}
					else
					{
						cardInfo = CardLoader.GetRandomChoosableBonesCard(SaveManager.SaveFile.GetCurrentRandomSeed());
					}

					if (cardInfo == null)
					{
						cardInfo = CardLoader.GetCardByName("Geck");
					}
				}
				card.SetInfo(cardInfo);
				card.SetFaceDown(false, false);
				card.SetInteractionEnabled(false);
				if (SceneLoader.ActiveSceneName == "finale_magnificus")
				{
					card.SetCardback(Tools.getImage("magcardback.png"));
				}
				yield return new WaitUntil(() => !InputButtons.GetButton(Button.Select));
				bool cardTaken = false;
				card.SetEnabled(true);
				card.SetInteractionEnabled(true);
				card.CursorSelectEnded = (Action<MainInputInteractable>)Delegate.Combine(card.CursorSelectEnded, new Action<MainInputInteractable>(delegate (MainInputInteractable i)
				{
					cardTaken = true;
				}));
				yield return new WaitUntil(() => cardTaken);
				card.SetEnabled(false);
				card.SetInteractionEnabled(false);
				yield break;
			}
		}

		[HarmonyPatch(typeof(CardSingleChoicesSequencer), "GetCardbackTexture")]
		public class BackTexturePatch
		{
			public static bool Prefix(CardChoice choice, ref CardSingleChoicesSequencer __instance, ref Texture __result)
			{
				if (SceneLoader.ActiveSceneName != "finale_magnificus")
				{
					return true;
				}
				if (choice.resourceType == ResourceType.Blood)
				{
					Texture2D texture2D = Tools.getImage("card_" + choice.resourceAmount.ToString() + "mox.png");
					__result = texture2D;
				} else if (choice.resourceType == ResourceType.Bone)
				{
					choice.resourceType = ResourceType.Bone;
					__result = Tools.getImage("card_manamox.png");
				}
				return false;
			}
		}


		[HarmonyPatch(typeof(SpecialNodeHandler), "StartSpecialNodeSequence")]
		public class MapGenerator_patch4
		{
			public static bool Prefix(ref SpecialNodeHandler __instance, SpecialNodeData nodeData)
			{
				bool flag = nodeData is CustomNode3;
				bool result;
				if (flag)
				{
					bool flag2 = __instance.gameObject.GetComponent<MapGenerator_patch4.bleachnpaint>() == null;
					if (flag2)
					{
						__instance.gameObject.AddComponent<MapGenerator_patch4.bleachnpaint>();
					}
					__instance.StartCoroutine(__instance.gameObject.GetComponent<MapGenerator_patch4.bleachnpaint>().sequencer(nodeData as CustomNode3));
					result = false;
				}
				else
				{
					result = true;
				}
				return result;
			}


			[HarmonyPatch(typeof(SpecialNodeHandler), "StartSpecialNodeSequence")]
			public class MapGenerator_mergenode
			{
				public static bool Prefix(ref SpecialNodeHandler __instance, SpecialNodeData nodeData)
				{
					bool flag = nodeData is MergeNode;
					bool result;
					if (flag)
					{
						bool flag2 = __instance.gameObject.GetComponent<merge>() == null;
						if (flag2)
						{
							__instance.gameObject.AddComponent<merge>();
						}
						__instance.StartCoroutine(__instance.gameObject.GetComponent<merge>().sequencer(nodeData as MergeNode));
						result = false;
					}
					else
					{
						result = true;
					}
					return result;
				}
			}


			[HarmonyPatch(typeof(SpecialNodeHandler), "StartSpecialNodeSequence")]
			public class MapGenerator_copynode
			{
				public static bool Prefix(ref SpecialNodeHandler __instance, SpecialNodeData nodeData)
				{
					bool flag = nodeData is CopyNode;
					bool result;
					if (flag)
					{
						bool flag2 = __instance.gameObject.GetComponent<copycard>() == null;
						if (flag2)
						{
							__instance.gameObject.AddComponent<copycard>();
						}
						__instance.StartCoroutine(__instance.gameObject.GetComponent<copycard>().sequencer(nodeData as CopyNode));
						result = false;
					}
					else
					{
						result = true;
					}
					return result;
				}
			}

			[HarmonyPatch(typeof(SpecialNodeHandler), "StartSpecialNodeSequence")]
			public class MapGenerator_cauldron
			{
				public static bool Prefix(ref SpecialNodeHandler __instance, SpecialNodeData nodeData)
				{
					bool flag = nodeData is Cauldron;
					bool result;
					if (flag)
					{
						bool flag2 = __instance.gameObject.GetComponent<cauldron>() == null;
						if (flag2)
						{
							__instance.gameObject.AddComponent<cauldron>();
						}
						__instance.StartCoroutine(__instance.gameObject.GetComponent<cauldron>().sequencer(nodeData as Cauldron));
						result = false;
					}
					else
					{
						result = true;
					}
					return result;
				}
			}

			[HarmonyPatch(typeof(SpecialNodeHandler), "StartSpecialNodeSequence")]
			public class MapGenerator_patch3
			{
				public static bool Prefix(ref SpecialNodeHandler __instance, SpecialNodeData nodeData)
				{
					bool flag = nodeData is CustomNode2;
					bool result;
					if (flag)
					{
						bool flag2 = __instance.gameObject.GetComponent<MapGenerator_patch4.cardshop>() == null;
						if (flag2)
						{
							__instance.gameObject.AddComponent<MapGenerator_patch4.cardshop>();
						}
						__instance.StartCoroutine(__instance.gameObject.GetComponent<MapGenerator_patch4.cardshop>().sequencer(nodeData as CustomNode2));
						result = false;
					}
					else
					{
						result = true;
					}
					return result;
				}

				private Texture2D duplicateTexture(Texture2D source)
				{
					RenderTexture temporary = RenderTexture.GetTemporary(source.width, source.height, 0, RenderTextureFormat.Default, RenderTextureReadWrite.Linear);
					Graphics.Blit(source, temporary);
					RenderTexture active = RenderTexture.active;
					RenderTexture.active = temporary;
					Texture2D texture2D = new Texture2D(source.width, source.height);
					texture2D.ReadPixels(new Rect(0f, 0f, (float)temporary.width, (float)temporary.height), 0, 0);
					texture2D.Apply();
					RenderTexture.active = active;
					RenderTexture.ReleaseTemporary(temporary);
					return texture2D;
				}

				[HarmonyPatch(typeof(SpecialNodeHandler), "StartSpecialNodeSequence")]
				public class MapGenerator_patch7
				{
					public static bool Prefix(ref SpecialNodeHandler __instance, SpecialNodeData nodeData)
					{
						bool flag = nodeData is CustomNode1;
						bool result;
						if (flag)
						{
							bool flag2 = __instance.gameObject.GetComponent<changecost>() == null;
							if (flag2)
							{
								__instance.gameObject.AddComponent<changecost>();
							}
							__instance.StartCoroutine(__instance.gameObject.GetComponent<changecost>().sequencer(nodeData as CustomNode1));
							result = false;
						}
						else
						{
							result = true;
						}
						return result;
					}
				}

				[HarmonyPatch(typeof(SpecialNodeHandler), "StartSpecialNodeSequence")]
				public class MapGenerator_patch11
				{
					public static bool Prefix(ref SpecialNodeHandler __instance, SpecialNodeData nodeData)
					{
						bool flag = nodeData is CustomNode14;
						bool result;
						if (flag)
						{
							bool flag2 = __instance.gameObject.GetComponent<enchant>() == null;
							if (flag2)
							{
								__instance.gameObject.AddComponent<enchant>();
							}
							__instance.StartCoroutine(__instance.gameObject.GetComponent<enchant>().sequencer(nodeData as CustomNode14));
							result = false;
						}
						else
						{
							result = true;
						}
						return result;
					}
				}


				[HarmonyPatch(typeof(SpecialNodeHandler), "StartSpecialNodeSequence")]
				public class MapGenerator_patcdeathcard
				{
					public static bool Prefix(ref SpecialNodeHandler __instance, SpecialNodeData nodeData)
					{
						bool flag = nodeData is DeathCardEvent;
						bool result;
						if (flag)
						{
							bool flag2 = __instance.gameObject.GetComponent<paintdeathcard>() == null;
							if (flag2)
							{
								__instance.gameObject.AddComponent<paintdeathcard>();
							}
							__instance.StartCoroutine(__instance.gameObject.GetComponent<paintdeathcard>().sequencer(nodeData as CustomNode14));
							result = false;
						}
						else
						{
							result = true;
						}
						return result;
					}
				}

				[HarmonyPatch(typeof(SpecialNodeHandler), "StartSpecialNodeSequence")]
				public class MapGenerator_patch12
				{
					public static bool Prefix(ref SpecialNodeHandler __instance, SpecialNodeData nodeData)
					{
						bool flag = nodeData is CustomNodeDeck;
						bool result;
						if (flag)
						{
							bool flag2 = __instance.gameObject.GetComponent<magdeck>() == null;
							if (flag2)
							{
								__instance.gameObject.AddComponent<magdeck>();
							}
							__instance.StartCoroutine(__instance.gameObject.GetComponent<magdeck>().sequencer(nodeData as CustomNodeDeck));
							result = false;
						}
						else
						{
							result = true;
						}
						return result;
					}
				}

				[HarmonyPatch(typeof(SpecialNodeHandler), "StartSpecialNodeSequence")]
				public class MapGenerator_patchpainting
				{
					public static bool Prefix(ref SpecialNodeHandler __instance, SpecialNodeData nodeData)
					{
						bool flag = nodeData is PaintingEvent;
						bool result;
						if (flag)
						{
							bool flag2 = __instance.gameObject.GetComponent<painting>() == null;
							if (flag2)
							{
								__instance.gameObject.AddComponent<painting>();
							}
							__instance.StartCoroutine(__instance.gameObject.GetComponent<painting>().sequencer(nodeData as PaintingEvent));
							result = false;
						}
						else
						{
							result = true;
						}
						return result;
					}
				}


				[HarmonyPatch(typeof(SpecialNodeHandler), "StartSpecialNodeSequence")]
				public class MapGenerator_patchEDAXIO
				{
					public static bool Prefix(ref SpecialNodeHandler __instance, SpecialNodeData nodeData)
					{
						bool flag = nodeData is EdaxioNode;
						bool result;
						if (flag)
						{
							bool flag2 = __instance.gameObject.GetComponent<magedaxio>() == null;
							if (flag2)
							{
								__instance.gameObject.AddComponent<magedaxio>();
							}
							__instance.StartCoroutine(__instance.gameObject.GetComponent<magedaxio>().sequencer(nodeData as EdaxioNode));
							result = false;
						}
						else
						{
							result = true;
						}
						return result;
					}
				}
				[HarmonyPatch(typeof(SpecialNodeHandler), "StartSpecialNodeSequence")]
				public class MapGenerator_patchESPEARA
				{
					public static bool Prefix(ref SpecialNodeHandler __instance, SpecialNodeData nodeData)
					{
						bool flag = nodeData is UpgradeSpellNode;
						bool result;
						if (flag)
						{
							bool flag2 = __instance.gameObject.GetComponent<espearaspell>() == null;
							if (flag2)
							{
								__instance.gameObject.AddComponent<espearaspell>();
							}
							__instance.StartCoroutine(__instance.gameObject.GetComponent<espearaspell>().sequencer(nodeData as UpgradeSpellNode));
							result = false;
						}
						else
						{
							result = true;
						}
						return result;
					}
				}

				[HarmonyPatch(typeof(SpecialNodeHandler), "StartSpecialNodeSequence")]
				public class MapGenerator_patch13
				{
					public static bool Prefix(ref SpecialNodeHandler __instance, SpecialNodeData nodeData)
					{
						bool flag = nodeData is SpellCardChoice;
						bool result;
						if (flag)
						{
							bool flag2 = __instance.gameObject.GetComponent<spellchoice>() == null;
							if (flag2)
							{
								__instance.gameObject.AddComponent<spellchoice>();
							}
							__instance.StartCoroutine(__instance.gameObject.GetComponent<spellchoice>().sequencer(nodeData as SpellCardChoice));
							result = false;
						}
						else
						{
							result = true;
						}
						return result;
					}
				}
			}






			public class bleachnpaint : CardChoicesSequencer
			{
				public bool bleached = false;
				public ConfirmStoneButton confirmStone { get; set; }

				public void removeselectablecardfromdeck(SelectableCard component)
				{
					base.StartCoroutine(this.removeselectablecardfromdeckie(component, true));
				}

				public void cardpickingupscropt(SelectableCard component)
				{
					//bool flag = component.Info.HasModFromCardMerge();
					if (component.Anim.FaceDown)
                    {
						return;
                    }
					if (bleached)
					{
						component.ExitBoard(0.3f, new Vector3(-1f, -1f, 6f));
						this.confirmStone.Exit();
						Destroy(GameObject.Find("pottery"));
						Destroy(GameObject.Find("TESTSTONE"));
						Singleton<GameFlowManager>.Instance.TransitionToGameState(GameState.Map, null);
					}
					else
					{
						Tween.LocalPosition(GameObject.Find("pottery").transform, new Vector3(-2, 5, 1), 0.25f, 0);
						this.cd = 0;
						component.ExitBoard(0.3f, new Vector3(-1f, -1f, 6f));
						GameObject.Find("TESTSTONE").GetComponent<BoxCollider>().size = new Vector3(0f, 0f, 0f);
						GameObject.Find("TESTSTONE").SetActive(false);
						GameObject.Find("Player").GetComponentInChildren<ViewManager>().SwitchToView(View.Choices, false, false);
						List<CardInfo> list = new List<CardInfo>(RunState.DeckList);
						list.RemoveAll((CardInfo x) => x.SpecialAbilities.Contains(SpecialTriggeredAbility.RandomCard) || x.traits.Contains(Trait.Pelt) || x.traits.Contains(Trait.EatsWarrens) || x.name.Contains("edaxio"));
						list.RemoveAll((CardInfo x) => x.abilities.Count < 1 || x.Abilities.Count < 1);
						GameObject theDeck = Singleton<DeckReviewSequencer>.Instance.gameObject;
						theDeck.transform.parent = GameObject.Find("GameTable").transform;
						theDeck.transform.localScale = new Vector3(1, 1, 1);
						theDeck.transform.localPosition = new Vector3(0, 5.01f, -2f);
						Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(Singleton<DeckReviewSequencer>.Instance.cardArray.SelectCardFrom(list, null, new Action<SelectableCard>(this.removeselectablecardfromdeck)));
						for (int i = 0; i < theDeck.transform.childCount; i++)
						{
							this.cardpickedfromdeck.Add(theDeck.transform.GetChild(i).gameObject.GetComponent<SelectableCard>());
						}
					}
				}

				public IEnumerator removeselectablecardfromdeckie(SelectableCard component, bool run)
				{
					this.cardpickedfromdeck.Remove(component);
					this.cd = 0;
					GameObject table = GameObject.Find("GameTable");
					Tween.Position(component.transform, new Vector3(table.transform.position.x, 14.75f, -1f + table.transform.position.z), 0.15f, 0.1f, null, Tween.LoopType.None, null, null, true);
					Tween.LocalPosition(GameObject.Find("pottery").transform, new Vector3(-1.5f, 5f, -0.75f), 0.15f, 0.1f);
					yield return new WaitForSeconds(0.2f);
					GameObject.Instantiate(Resources.Load("prefabs\\specialnodesequences\\ConfirmStoneButton")).name = "TESTSTONE";
					GameObject.Find("TESTSTONE").AddComponent<BoxCollider>().size = new Vector3(1.4f, 0.2f, 2.1f);
					GameObject.Find("TESTSTONE").transform.Find("Anim").Find("model").Find("ConfirmButton").Find("Quad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = (Resources.Load("art/cards/copycard_button") as Texture2D);
					GameObject.Find("TESTSTONE").transform.Find("Anim").Find("model").Find("ConfirmButton").Find("Quad").gameObject.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1, 1);
					this.confirmStone = GameObject.Find("TESTSTONE").GetComponentInChildren<ConfirmStoneButton>();
					confirmStone.currentHighlightedColor = new Color(0.85f, 0.85f, 0.85f, 1);
					confirmStone.currentInteractableColor = new Color(1f, 1, 1, 1);
					GameObject.Find("TESTSTONE").transform.position = new Vector3(table.transform.position.x, 25.75f, -2.6f + table.transform.position.z);
					Tween.Position(GameObject.Find("TESTSTONE").transform, new Vector3(table.transform.position.x, 14.75f, -2.6f + table.transform.position.z), 0.15f, 0.1f, null, Tween.LoopType.None, null, null, true);
					foreach (SelectableCard VARIABLE in this.cardpickedfromdeck)
					{
						VARIABLE.ExitBoard(0.3f, new Vector3(-1f, -1f, 6f));
					}
					List<SelectableCard>.Enumerator enumerator = default(List<SelectableCard>.Enumerator);
					component.gameObject.GetComponent<BoxCollider>().enabled = true;
					component.Initialize(component.Info, new Action<SelectableCard>(this.cardpickingupscropt), null, false, null);
					this.confirmStone.Enter();
					yield return this.confirmStone.WaitUntilConfirmation();
					bool failBleach = false;
					this.confirmStone.Unpress();
					component.SetCardback(Tools.getImage("magcardback.png"));
					component.Anim.SetFaceDown(true);
					yield return new WaitForSeconds(0.03f);
					CardModificationInfo componentInfoShite = new CardModificationInfo();

					if (component.Info.Abilities.Count > 0)
					{
						List<Ability> toNegate = component.Info.Abilities;
						componentInfoShite.negateAbilities = toNegate.Count == 1 ? toNegate : new List<Ability> { toNegate[UnityEngine.Random.Range(0, toNegate.Count)] };

						bool unbleachableAbility = false;
						foreach (Ability negate in componentInfoShite.negateAbilities)
						{
							if (AbilitiesUtil.GetInfo(negate).powerLevel < 0) { unbleachableAbility = true; break; }
						}
						if (unbleachableAbility && MagModGeneration.challenges.Contains("WeakBleach") && SaveManager.saveFile.ascensionActive)
						{
							failBleach = true;
							componentInfoShite.negateAbilities = new List<Ability>();
						}
					}

					//componentInfoShite.fromCardMerge = true;
					RunState.Run.playerDeck.ModifyCard(component.Info, componentInfoShite);

					AbilityInfo bleachedAbility = (!failBleach) ? AbilitiesUtil.GetInfo(componentInfoShite.negateAbilities[0]) : AbilitiesUtil.GetInfo(Ability.Flying);
					component.SetInfo(component.Info);
					component.Anim.FaceDown = true;
					AudioController.Instance.PlaySound2D("magnificus_brush_splatter_bleach", MixerGroup.None, 0.5f, 0f, null, null, null, null, false);
					yield return new WaitForSeconds(0.5f);
					AudioController.Instance.PlaySound2D("magnificus_brush_splatter_color", MixerGroup.None, 0.5f, 0f, null, null, null, null, false);
					component.Anim.SetFaceDown(false);
					component.coll.enabled = false;
					bleached = true;

					this.confirmStone.Disable();
					Tween.Position(GameObject.Find("TESTSTONE").transform, new Vector3(table.transform.position.x - 10f, 30.75f, -2.6f + table.transform.position.z), 0.15f, 0.1f, null, Tween.LoopType.None, null, null, true);

					component.Anim.FaceDown = false;
					GameObject.Find("TESTSTONE").GetComponent<BoxCollider>().size = new Vector3(0f, 0f, 0f);

					yield return new WaitForSeconds(0.25f);
					if (!failBleach)
					{
						yield return Singleton<TextDisplayer>.Instance.ShowUntilInput(  String.Format("Your {0} is now free of its {1}...", component.Info.displayedName, bleachedAbility.rulebookName), -2.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
						yield return new WaitForSeconds(0.25f);
						if (bleachedAbility.powerLevel < 0)
						{
							component.Anim.StrongNegationEffect();
							yield return new WaitForSeconds(0.55f);
							yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Hmm.. The essence of that sigil does not resonate with your card..", -0.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);

						}
						else
                        {
							component.Anim.PlaySacrificeParticles();
							bool hasAttackIcon = component.Info.specialStatIcon != SpecialStatIcon.None && StatIconInfo.GetIconInfo(component.Info.specialStatIcon).appliesToAttack;
							bool hasHealthIcon = component.Info.specialStatIcon != SpecialStatIcon.None && StatIconInfo.GetIconInfo(component.Info.specialStatIcon).appliesToHealth;


							bool boostAttack = component.Info.Attack <= component.Info.Health + Random.RandomRangeInt(-1, 1) && !hasAttackIcon;
							bool boostHealth = (component.Info.Health <= component.Info.Attack + Random.RandomRangeInt(-1, 1) || !boostAttack) && !hasHealthIcon;

							int attack = (boostAttack) ? Convert.ToInt32(Math.Ceiling( bleachedAbility.powerLevel / 2.5f)) : 0;
							int health = (boostHealth) ? Convert.ToInt32(Math.Ceiling((bleachedAbility.powerLevel + 1.0f) / 2.0f)) : 0;
							health -= Convert.ToInt32(Math.Floor(attack * 1.5f));
							if (health < 0) { health = 0; }

							string describe = "power";
							if (boostHealth && !boostAttack) { describe = "gourd"; }
							else if(!boostHealth && boostAttack) { describe = "strength"; }

							CardModificationInfo statMod = new CardModificationInfo(attack, health);
							RunState.Run.playerDeck.ModifyCard(component.Info, statMod);
							component.SetInfo(component.Info);
							yield return new WaitForSeconds(0.525f);
							yield return Singleton<TextDisplayer>.Instance.ShowUntilInput( (health == 0 && attack == 0) ? ".. It appears nothing was gained" : String.Format("The essence of the sigil has imbued the card with more {0}.", describe), -0.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);

						}
					}
					else
					{
						ChallengeActivationUI.TryShowActivation(KayceeFixes.ChallengeManagement.WeakBleach);
						if (!KayceeStorage.DialogueEvent2)
						{
							yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Hmph.. My bleach.. failed?", -2.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
							yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Was this your doing, challenger?", -2.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
							KayceeStorage.DialogueEvent2 = true;
						}
						else
						{
							yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Hmph..", -2.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
						}
					}
					component.coll.enabled = true;

					yield break;
				}

				public IEnumerator sequencer(CustomNode3 tradeCardsData)
				{
					bleached = false;
					this.cd = 0;
					GameObject.Find("Player").GetComponentInChildren<ViewManager>().SwitchToView(View.Choices, false, false);
					yield return new WaitForSeconds(1f);
					List<CardInfo> listOfCards = new List<CardInfo>(RunState.Run.playerDeck.Cards);
					listOfCards.RemoveAll((CardInfo x) => x.SpecialAbilities.Contains(SpecialTriggeredAbility.RandomCard) || x.traits.Contains(Trait.Pelt) || x.traits.Contains(Trait.EatsWarrens) || x.name.Contains("edaxio"));
					listOfCards.RemoveAll((CardInfo x) => x.abilities.Count < 1 && x.Abilities.Count < 1);
					GameObject pot = Instantiate(Resources.Load("prefabs/items/BleachPotItem") as GameObject);
					pot.name = "pottery";
					pot.GetComponent<Animator>().enabled = false;
					pot.transform.parent = base.transform;
					pot.transform.localPosition = new Vector3(-2f, 5, 1);
					GameObject theDeck = Singleton<DeckReviewSequencer>.Instance.gameObject;
					theDeck.transform.parent = GameObject.Find("GameTable").transform;
					theDeck.transform.localScale = new Vector3(1, 1, 1);
					theDeck.transform.localPosition = new Vector3(0, 5.01f, -2f);
					Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(Singleton<DeckReviewSequencer>.Instance.cardArray.SelectCardFrom(listOfCards, null, new Action<SelectableCard>(this.removeselectablecardfromdeck)));
					for (int i = 0; i < theDeck.transform.childCount; i++)
					{
						this.cardpickedfromdeck.Add(theDeck.transform.GetChild(i).gameObject.GetComponent<SelectableCard>());
					}

					if (SavedVars.LearnedMechanics.Contains("bleaching"))
					{
						base.StartCoroutine(Singleton<TextDisplayer>.Instance.ShowUntilInput("Select a card to imbue with a lost sigils strength..", -0.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true));
					} else
                    {
						SavedVars.LearnedMechanics += "bleaching;";
						yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Here I will allow you to [c:g1]bleach[c:] a card of one of its sigils..", -2.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
						yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("When bleached, the card will imbue the power of its lost sigil,", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
						yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("and get much [c:g2]stronger[c:] depending on the sigils raw strength.", -0.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);



					}
					yield break;
				}

				public int i = 0;

				public int card = 0;

				public int cd = 0;

				public int selectingoptions = 3;

				public List<SelectableCard> cardpicked = new List<SelectableCard>();

				public List<SelectableCard> cardpickedfromdeck = new List<SelectableCard>();

				public List<SelectableCard> created = new List<SelectableCard>();
			}


			public class cardshop : CardChoicesSequencer
			{
				CardPile deckPile2;
				GameObject deckObject;

				CardPile sideDeckPile;
				GameObject sideDeckObject;

				bool clickEnabled = false;

				public IEnumerator sequencer(CustomNode2 tradeCardsData)
				{

					clickEnabled = false;

					if (config.isometricMode == true)
					{
						Singleton<FirstPersonController>.Instance.enabled = false;
						Tween.LocalPosition(Singleton<FirstPersonController>.Instance.transform, new Vector3(Singleton<FirstPersonController>.Instance.transform.localPosition.x, 9.72f, Singleton<FirstPersonController>.Instance.transform.localPosition.z), 0.3f, 0);
						
					}
					Singleton<ViewManager>.Instance.SwitchToView(View.BoardCentered, false, true);



					if (!SavedVars.LearnedMechanics.Contains("shoptutorial"))
						yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("You step foot into a small store.." + ((RunState.Run.regionTier > 0) ? " A brief respite from your winding travels." : "."), -0.5f, 0.15f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);


					GameObject shopObjects = GameObject.Instantiate<GameObject>(new GameObject());
					shopObjects.transform.parent = base.transform;
					shopObjects.name = "shopObjects";
					shopObjects.transform.localPosition = new Vector3(0, 0, 0);
					GameObject table = GameObject.Find("GameTable");
					deckObject = Instantiate(Singleton<CardPile>.Instance.gameObject);
					deckPile2 = deckObject.GetComponent<CardPile>();
					deckObject.transform.parent = shopObjects.transform;
					deckObject.transform.localPosition = new Vector3(3.05f, 5.01f, 0.55f);

					deckPile2.cardbackPrefab.gameObject.transform.Find("StaticCard").gameObject.GetComponent<MeshRenderer>().material.mainTexture = Tools.getImage("magcardback.png");
					deckPile2.cardbackPrefab.gameObject.transform.Find("StaticCard").gameObject.SetActive(true);
					deckPile2.cardbackPrefab.gameObject.transform.Find("BendableCard").gameObject.SetActive(false);//THIS IS IT
					Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(deckPile2.SpawnCards(RunState.Run.playerDeck.Cards.Count, 0f));//this
					deckPile2.CursorSelectStarted = (Action<MainInputInteractable>)Delegate.Combine(deckPile2.CursorSelectStarted, new Action<MainInputInteractable>(delegate (MainInputInteractable i)
					{
						this.deckAction(false);
					}));
					//GlitchOutAssetEffect.GlitchModel(GameObject.Find("MagnificusAnim").transform, false, true);
					//ChallengeActivationUI.TryShowActivation(KayceeFixes.ChallengeManagement.MasterBosses);

					if (!SavedVars.LearnedMechanics.Contains("shoptutorial"))
						yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Your [c:g1]deck[c:] is stored in this pile.. ", -0.5f, 0.15f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);


					sideDeckObject = Instantiate(Singleton<CardPile>.Instance.gameObject);
					sideDeckPile = sideDeckObject.GetComponent<CardPile>();
					sideDeckObject.transform.parent = shopObjects.transform;
					sideDeckObject.transform.localPosition = new Vector3(3.05f, 5.01f, -1.3f);
					sideDeckObject.name = "ShopDeck1";
					deckObject.name = "ShopDeck2";

					GameObject sidePrefab = Instantiate(sideDeckPile.cardbackPrefab.gameObject);
					sidePrefab.transform.Find("StaticCard").gameObject.GetComponent<MeshRenderer>().material.mainTexture = Tools.getImage("moxcardback.png");
					sideDeckPile.cardbackPrefab = sidePrefab;
					sideDeckPile.cardbackPrefab.gameObject.transform.Find("StaticCard").gameObject.SetActive(true);
					sideDeckPile.cardbackPrefab.gameObject.transform.Find("BendableCard").gameObject.SetActive(false);//THIS IS IT
					Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(sideDeckPile.SpawnCards(10, 0f));//this
					sideDeckPile.CursorSelectStarted = (Action<MainInputInteractable>)Delegate.Combine(sideDeckPile.CursorSelectStarted, new Action<MainInputInteractable>(delegate (MainInputInteractable i)
					{
						this.deckAction(true);
					}));

					if (!SavedVars.LearnedMechanics.Contains("shoptutorial"))
					{
						yield return Singleton<TextDisplayer>.Instance.ShowUntilInput(".. And your [c:g1]side deck[c:] is stored here, where you can adjust it as you see fit. ", -1f, 0.2f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
					}

					if (MagModGeneration.challenges.Contains("RandomSidedeck") && SaveManager.saveFile.ascensionActive)
					{
						GlitchOutAssetEffect.GlitchModel(sideDeckObject.transform, false, true);
						ChallengeActivationUI.TryShowActivation(KayceeFixes.ChallengeManagement.RandomSidedeck);
						if (!SavedVars.LearnedMechanics.Contains("shoptutorial"))
						{
							yield return new WaitForSeconds(0.5f);
							yield return Singleton<TextDisplayer>.Instance.ShowUntilInput(".. Hmmph, I guess it was not meant to be..", -0.25f, 0.2f, Emotion.Anger, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
						}
					}

					
					yield return new WaitForSeconds(1f);

					if (!SavedVars.LearnedMechanics.Contains("shoptutorial"))
						SavedVars.LearnedMechanics += "shoptutorial;";

					createCard("MoxSapphire", shopObjects.transform, new Vector3(-2.5f, 5.01f, 0.5f), 5, true, "Cardpack sapphire", "cardpack_sapphire.png");
					createCard("MoxRuby", shopObjects.transform, new Vector3(-1f, 5.01f, 0.5f), 5, true, "Cardpack ruby", "cardpack_ruby.png");
					createCard("MoxEmerald", shopObjects.transform, new Vector3(0.5f, 5.01f, 0.5f), 5, true, "Cardpack emerald", "cardpack_emerald.png");

					List<string> masterMox = new List<string>
					{
						"MoxDualGO",
						"MoxDualOB",
						"MoxDualBG"
					};
					int masterDex = RunState.Run.regionTier != 0 && RunState.Run.regionTier < 4 ? RunState.Run.regionTier - 1 : Random.RandomRangeInt(0, masterMox.Count);
					if (RunState.Run.regionTier == 0 && MagSave.layout.Contains("2")) masterDex = 2;
					else if (RunState.Run.regionTier == 0 && MagSave.layout.Contains("3")) masterDex = 1;
					else if (RunState.Run.regionTier == 4 || RunState.Run.regionTier == 0 && MagSave.layout.Contains("1")) masterDex = 0;

					float x4 = -0.25f;
					if (RunState.Run.regionTier > 0 && RunState.Run.regionTier != 4 && !MagModGeneration.minimap || RunState.Run.regionTier > 0 && RunState.Run.regionTier != 4 && SavedVars.HasMap == true && SavedVars.HasMapIcons == false) { x4 = 0.5f; }

					createCard(masterMox[masterDex], shopObjects.transform, new Vector3(x4, 5.01f, -1.5f), 9, false);

					createCard("Squirrel", shopObjects.transform, new Vector3(1.82f, 5.01f, -0.62f), 0, false, "n", "exitshop.png", "exitShop");

					float x8 = -1.85f;
					if (RunState.Run.regionTier > 0 && RunState.Run.regionTier != 4 && !MagModGeneration.minimap || RunState.Run.regionTier > 0 && RunState.Run.regionTier != 4 && SavedVars.HasMap == true && SavedVars.HasMapIcons == false) { x8 = -1f; }
					createCard("mag_magnusspell", shopObjects.transform, new Vector3(x8, 5.01f, -1.5f), 4, false, "Ethereal Gems");

					if (RunState.Run.regionTier > 0 && RunState.Run.regionTier != 4 && SavedVars.HasMap == true && SavedVars.HasMapIcons == false)
                    {
						createCard("Squirrel", shopObjects.transform, new Vector3(-2.5f, 5.01f, -1.5f), 4, false, "Fill In Minimap", "minimap.png");
					}

					createCard("Squirrel", GameObject.Find("GameTable").transform, new Vector3(2.24f, 4.01f, 0.5999f), 0, false, "n", "backarrow.png", "sidedeckBack");
					yield return new WaitForSeconds(0.25f);
					shopObjects.transform.localPosition = new Vector3(0, 0, 0);
					clickEnabled = true;

					Singleton<TextDisplayer>.Instance.ShowMessage(string.Format("[c:g3]~ {0} Crystal{1} ~[c:]", RunState.Run.currency, (RunState.Run.currency > 1) ? "s" : ""),Emotion.Laughter, TextDisplayer.LetterAnimation.WavyJitter);

					yield break;
				}

				public void AddPricetag(SelectableCard card, int priceIndex, float tweenDelay)
				{
					GameObject gameObject = GameObject.Instantiate<GameObject>(Singleton<BuyPeltsSequencer>.Instance.pricetagPrefab);
					gameObject.transform.SetParent(card.transform);
					gameObject.transform.localPosition = new Vector3(-0.4f + UnityEngine.Random.value * 0.1f, 0.95f, -0.085f);
					gameObject.transform.localEulerAngles = new Vector3(-90f, -90f, 90f);
					gameObject.name = "pricetag";
					gameObject.GetComponentInChildren<Renderer>().material.mainTexture = Singleton<BuyPeltsSequencer>.Instance.pricetagTextures[priceIndex];
					Tween.LocalRotation(gameObject.transform, new Vector3(290f + Random.RandomRangeInt(5, -5), 90f, 270f), 0.25f, tweenDelay, Tween.EaseOut, Tween.LoopType.None, null, null, true);
				}

				public void createCard(string cardName, Transform parent, Vector3 position, int price, bool faceDown = true, string displayName = "", string image = "", string nameOverride ="")
                {
					CardInfo dinfo = CardLoader.GetCardByName(cardName);
					if (image != "" && !faceDown) {
						dinfo.SetPortrait(Tools.getImage(image));
					}

					GameObject gameObject = GameObject.Instantiate<GameObject>(Singleton<SelectableCardArray>.Instance.selectableCardPrefab);
					gameObject.transform.SetParent(parent);
					SelectableCard component = gameObject.GetComponent<SelectableCard>();
					component.SetEnabled(false);
					if(displayName == "n") {
						dinfo.displayedName = "";
						component.renderInfo.hiddenAttack = true;
						component.renderInfo.hiddenHealth = true;
						component.renderInfo.baseTextureOverride = Tools.getImage( (!config.oldCardDesigns) ? "finalecardbacknobars.png" : "spellcardback.png");
						if (!config.oldCardDesigns)
						{
							component.gameObject.GetComponentInChildren<MagCardFrame>().setCardBars(false);
							component.gameObject.GetComponentInChildren<MagCardFrame>().setTheme("spell");
						}
					}
					else if (displayName != "") { dinfo.displayedName = displayName; }
					if (image != "" && faceDown) { 
						component.SetCardback(Tools.getImage(image));
						if (!config.oldCardDesigns) component.gameObject.GetComponentInChildren<MagCardFrame>().gameObject.SetActive(false); 
					} 
					Singleton<SelectableCardArray>.Instance.TweenInCard(component.transform, position, 0f, false);
					component.Anim.PlayQuickRiffleSound();
					component.Initialize(dinfo, new Action<SelectableCard>(this.action), null, false, null);
					component.GetComponent<Collider>().enabled = true;
					this.created.Add(component);
					if (price > 0) { this.AddPricetag(component, price, 0.25f); }
					component.Anim.SetFaceDown(faceDown, true);
					if (nameOverride != "") { component.name = nameOverride; }


					component.CursorEntered = (Action<MainInputInteractable>)Delegate.Combine(component.CursorEntered, new Action<MainInputInteractable>(delegate (MainInputInteractable m)
					{
						Tween.LocalRotation(component.transform, new Vector3(90, 3, 0), 0.1f, 0);
					}));

					component.CursorExited = (Action<MainInputInteractable>)Delegate.Combine(component.CursorExited, new Action<MainInputInteractable>(delegate (MainInputInteractable m)
					{
						Tween.LocalRotation(component.transform, new Vector3(90, 0, 0), 0.1f, 0);
					}));

				}

				public IEnumerator cardpackOpen(SelectableCard component, string type)
				{
					Singleton<ViewController>.Instance.LockState = ViewLockState.Locked;
					yield return new WaitForSeconds(0.76f);
					Vector3 packpos = component.gameObject.transform.localPosition;
					AudioController.Instance.PlaySound2D("gbc_pack_open", MixerGroup.None, 0.5f, 0f, null, null, null, null, false);
					for (int i = 0; i < 3; i++)
					{
						packpos.x = 0.1f;
						Tween.LocalPosition(component.gameObject.transform, packpos, 0.2f, 0);
						yield return new WaitForSeconds(0.11f);
						packpos.x = 0.3f;
						Tween.LocalPosition(component.gameObject.transform, packpos, 0.1f, 0);
						if (i == 2)
						{
							component.SetCardback(Tools.getImage("cardpack_" + type + "1.png"));
						}
						yield return new WaitForSeconds(0.11f);
					}
					packpos.x = 0.2f;
					cardPackCards = new List<SelectableCard>();
					Tween.LocalPosition(component.gameObject.transform, packpos, 0.1f, 0);
					packpos.y -= 5;
					yield return new WaitForSeconds(0.2f);
					for (int i = 0; i < 5; i++)
					{
						GameObject gameObject = GameObject.Instantiate<GameObject>(Singleton<SelectableCardArray>.Instance.selectableCardPrefab);
						gameObject.transform.SetParent(base.transform);
						SelectableCard component2 = gameObject.GetComponent<SelectableCard>();
						GemType gemType = GemType.Green;
						switch (type)
						{
							case "ruby":
								gemType = GemType.Orange;
								break;
							case "emerald":
								gemType = GemType.Green;
								break;
							case "sapphire":
								gemType = GemType.Blue;
								break;
						}
						int random = Random.RandomRangeInt(0, 100);

						List<CardInfo> list = (i < 3) ? CardLoader.GetUnlockedCards((i == 1 && random < 89 || i != 1) ? CardMetaCategory.ChoiceNode : CardMetaCategory.Rare, CardTemple.Wizard).FindAll((CardInfo x) => x.gemsCost.Count > 0 && x.gemsCost[0] == gemType && (x.gemsCost.Count == 1 || x.gemsCost.Count > 1 && x.gemsCost[0] == x.gemsCost[1])) : CardLoader.GetUnlockedCards((i == 1 && random < 89 || i != 1) ? CardMetaCategory.ChoiceNode : CardMetaCategory.Rare, CardTemple.Wizard);
						CardInfo packCard = list.Count <= 0 ? CardLoader.GetCardByName("Geck") : CardLoader.Clone(list[SeededRandom.Range(0, list.Count, Environment.TickCount)]);

						component2.Initialize(packCard, new Action<SelectableCard>(Singleton<SelectableCardArray>.Instance.OnCardSelected), null, false, new Action<SelectableCard>(Singleton<SelectableCardArray>.Instance.OnCardInspected));
						component2.SetEnabled(false);
						Singleton<SelectableCardArray>.Instance.displayedCards.Add(component2);
						if (i < 3)
						{
							Singleton<SelectableCardArray>.Instance.TweenInCard(component2.transform, new Vector3(-1.5f + (1.5f * i), 5.01f, 0.5f), 0.2f);
						}
						else
						{
							Singleton<SelectableCardArray>.Instance.TweenInCard(component2.transform, new Vector3(-0.75f + (1.5f * (i - 3)), 5.01f, -1.45f), 0.2f);
						}
						component2.Anim.PlayQuickRiffleSound();
						component2.Initialize(packCard, new Action<SelectableCard>(this.getdeckcard), null, false, null);
						component2.GetComponent<Collider>().enabled = true;
						cardPackCards.Add(component2);
						yield return new WaitForSeconds(0.1f);
					}
					Tween.LocalPosition(component.gameObject.transform, packpos, 0.1f, 0);
					yield return new WaitForSeconds(0.11f);
					switch (type)
					{
						case "emerald":
							component.gameObject.transform.localPosition = new Vector3(0.5f, 5.01f, 0.5f);
							break;
						case "ruby":
							component.gameObject.transform.localPosition = new Vector3(-1f, 5.01f, 0.5f);
							break;
						case "sapphire":
							component.gameObject.transform.localPosition = new Vector3(-2.5f, 5.01f, 0.5f);
							break;
					}
					component.SetCardback(Tools.getImage("cardpack_" + type + ".png"));
					component.gameObject.transform.Find("pricetag").gameObject.SetActive(true);
					yield break;
				}

				public void getdeckcard(SelectableCard component)
				{
					openingCardPack = false;
					RunState.Run.playerDeck.AddCard(component.Info);
					component.ExitBoard(0.25f, new Vector3(0, 1, 1));
					base.StartCoroutine(removeOtherCardPackCards());
					Tween.LocalPosition(GameObject.Find("shopObjects").transform, new Vector3(0, 0, 0), 0.01f, 0.25f);
				}

				public IEnumerator removeOtherCardPackCards()
                {
					yield return new WaitForSeconds(0.25f);
					Singleton<ViewController>.Instance.LockState = ViewLockState.Unlocked;
					foreach (SelectableCard info in cardPackCards)
					{
						info.ExitBoard(0f, new Vector3(0, 0, 0));
					}
					yield break;
				}

				public void action(SelectableCard component)
				{
					if (openingCardPack || !clickEnabled)
					{
						return;
					}

					int oldCurrency = RunState.Run.currency;

					if (component.Info.displayedName.Contains("Cardpack"))
					{
						if (RunState.Run.currency >= 5)
						{
							Vector3 packpos = component.gameObject.transform.localPosition;
							GameObject.Find("shopObjects").transform.localPosition = new Vector3(0f, -9f, 0f);
							packpos.y += 9f;
							component.gameObject.transform.localPosition = packpos;
							string type = component.Info.DisplayedNameEnglish.Split(' ')[1];
							Tween.LocalPosition(component.gameObject.transform, new Vector3(0.2f, 5.11f + 9f, -0.55f), 0.75f, 0f);
							component.gameObject.transform.Find("pricetag").gameObject.SetActive(false);
							openingCardPack = true;
							base.StartCoroutine(cardpackOpen(component, type));
							RunState.Run.currency -= 5;
						} 
					}
					else if (component.Info.name == "MoxSapphire" && component.Info.mods.Count < 1)
					{
						component.Anim.PlayTransformAnimation();
						List<CardInfo> list3 = new List<CardInfo>();
						MagCurrentNode.editSideDeck(1, 0, -1);
						component.SetInfo(CardLoader.GetCardByName("MoxRuby"));
						return;
					}
					else if (component.Info.name == "MoxRuby" && component.Info.mods.Count < 1)
					{
						component.Anim.PlayTransformAnimation();
						List<CardInfo> list4 = new List<CardInfo>();
						MagCurrentNode.editSideDeck(-1, 1, 0);
						component.SetInfo(CardLoader.GetCardByName("MoxEmerald"));
						return;
					}
					else if (component.Info.name == "MoxEmerald" && component.Info.mods.Count < 1)
					{
						component.Anim.PlayTransformAnimation();
						List<CardInfo> list5 = new List<CardInfo>();
						MagCurrentNode.editSideDeck(0, -1, 1);
						component.SetInfo(CardLoader.GetCardByName("MoxSapphire"));
						return;
					}
					else if (component.gameObject.name == "sidedeckBack")
					{
						Singleton<ViewManager>.Instance.SwitchToView(View.BoardCentered, false, true);
						GameObject.Find("sidedeckBack").transform.position = new Vector3(342.24f, 13.73f, -339.4001f);
						GameObject.Find("shopObjects").transform.position = new Vector3(GameObject.Find("GameTable").transform.position.x, 9.72f, GameObject.Find("GameTable").transform.position.z);
						foreach (SelectableCard selectableCard in this.MoxDeck)
						{
							selectableCard.ExitBoard(0.3f, new Vector3(-1f, -1f, 6f));
						}
						foreach (SelectableCard selectableCard2 in this.Deck)
						{
							selectableCard2.ExitBoard(0.3f, new Vector3(-1f, -1f, 6f));
						}
						File.WriteAllText(SaveManager.SaveFolderPath + "MagnificusModSave.gwsave", SaveManager.ToJSON(MagCurrentNode.GetNodeStuff(false, true)));
						return;
					}
					else if (component.Info.name.Contains("MoxDual"))
					{
						if (RunState.Run.currency >= 9)
						{
							RunState.Run.currency -= 9;
							component.ExitBoard(0.3f, new Vector3(-1f, -1f, 6f));
							RunState.Run.playerDeck.AddCard(CardLoader.GetCardByName(component.Info.name));
							SaveManager.SaveToFile();
						}
						else
						{
							component.Anim.StrongNegationEffect();
						}


					}
					else if (component.Info.name == "mag_magnusspell")
					{
						if (RunState.Run.playerDeck.Cards.FindAll((CardInfo x) => x.HasTrait(Trait.EatsWarrens)).Count >= ((SaveManager.saveFile.ascensionActive && Generation.challenges.Contains("SmallSpellbook")) ? 4 : 8) )
                        {
							base.StartCoroutine(fullSpellBook());
							return;
                        }
						if (RunState.Run.currency >= 4)
						{
							RunState.Run.currency -= 4;
							RunState.Run.playerDeck.AddCard(CardLoader.GetCardByName("mag_magnusspell"));
							Singleton<ItemsManager>.Instance.UpdateItems(false);
							component.ExitBoard(0.3f, new Vector3(-1f, -1f, 6f));
						}
						else
						{
							component.Anim.StrongNegationEffect();
						}
					}
					else if (component.Info.displayedName == "Fill In Minimap")
					{
						if (RunState.Run.currency >= 4)
						{
							GameObject.DestroyImmediate(GameObject.Find("MapParent"));
							MagModGeneration.minimap = true;
							SavedVars.HasMapIcons = true;
							SaveManager.SaveToFile();
							MagModGeneration.CreateMiniMap(true);
							RunState.Run.currency -= 4;
							component.ExitBoard(0.3f, new Vector3(-1f, -1f, 6f));
						}
						else
						{
							component.Anim.StrongNegationEffect();
						}
					}
					else if (component.gameObject.name == "exitShop")
					{
						if (Singleton<GameFlowManager>.Instance != null)
						{
							Singleton<TextDisplayer>.Instance.Clear();
							foreach (SelectableCard selectableCard3 in this.created)
							{
								selectableCard3.ExitBoard(0.3f, new Vector3(-1f, -1f, 6f));
							}
							GameObject gameObject3 = GameObject.Find("Player");
							NavigationZone3D shopZone = GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().currentZone;
							if (GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().currentZone.transform.Find("nodeIcon") != null)
							{
								float nodeDelay = config.isometricMode ? 0.75f : 0f;
								base.StartCoroutine(showNodeIcon(nodeDelay, GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().currentZone));
							}
							if (RunState.Run.regionTier == 0)
							{
								GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().currentZone = GameObject.Find("x4 y7").GetComponent<NavigationZone3D>();
								MagCurrentNode.SaveNode("x4 y7");
							}
							else
							{
								string currentNode = GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().currentZone.gameObject.name;
								string[] y = currentNode.Split('y');
								int y1 = int.Parse(y[1]);
								y1 -= 1;
								string newCords = y[0] + "y" + y1;
								GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().currentZone = GameObject.Find(newCords).GetComponent<NavigationZone3D>();
								MagCurrentNode.SaveNode(newCords);
							}
							float delay = config.isometricMode ? 0.4f : 0.1f;
							Tween.Position(GameObject.Find("GameTable").transform, new Vector3(GameObject.Find("GameTable").transform.position.x, -110f, GameObject.Find("GameTable").transform.position.z), 0.15f, delay, null, Tween.LoopType.None, null, null, true);
							GameObject.Destroy(GameObject.Find("shopObjects"));
							SaveManager.SaveToFile(false);
							GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().LookAtDirection(LookDirection.North, false);
							if (config.isometricMode == false)
							{
								Singleton<ViewManager>.Instance.SwitchToView(View.FirstPerson, false, true);
								GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().LookAtDirection(LookDirection.North, false);
								GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().enabled = true;
								GameObject.Find("Player").GetComponentInChildren<ViewController>().allowedViews = new List<View>();
								Tween.FieldOfView(GameObject.Find("PixelCameraParent").transform.Find("Pixel Camera").gameObject.GetComponent<Camera>(), 65f, 0.5f, 0);
								GameObject.Find("Player").transform.Find("PixelCameraParent").transform.localPosition = new Vector3(0, 7, -6.86f);
							} else {
								Singleton<ViewManager>.Instance.SwitchToView(View.Default, false, true);
								shopZone.events.Add(Generation.shop);
								base.StartCoroutine(Generation.unIsometricTransition());
							}
							File.WriteAllText(SaveManager.SaveFolderPath + "MagnificusModSave.gwsave", SaveManager.ToJSON(MagCurrentNode.GetNodeStuff(false, true)));
							if (RunState.Run.regionTier == 2)
							{
								GameObject.Find("lanterns").transform.position = new Vector3(0, 0, 0);
							}
							return;
						}

					}

					if (RunState.Run.currency != oldCurrency) 
						Singleton<TextDisplayer>.Instance.ShowMessage(string.Format("[c:g3]~ {0} Crystal{1} ~[c:]", RunState.Run.currency, (RunState.Run.currency > 1) ? "s" : ""), Emotion.Laughter, TextDisplayer.LetterAnimation.WavyJitter); 

				}

				public IEnumerator fullSpellBook()
                {
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Ah, but your [c:g1]spell book[c:] is full...", -0.15f, 0.15f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
					Singleton<TextDisplayer>.Instance.ShowMessage(string.Format("[c:g3]~ {0} Crystal{1} ~[c:]", RunState.Run.currency, (RunState.Run.currency > 1) ? "s" : ""), Emotion.Laughter, TextDisplayer.LetterAnimation.WavyJitter);

				}

				public IEnumerator showNodeIcon(float delay, NavigationZone3D currentZone)
				{ 
					currentZone.transform.Find("nodeIcon").transform.localScale = new Vector3(0, 0, 0);
					yield return new WaitForSeconds(delay);
					currentZone.transform.Find("nodeIcon").transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
					currentZone.transform.Find("nodeIcon").transform.position = new Vector3(currentZone.transform.position.x, 13f, currentZone.transform.position.z);
				}
				public void deckAction(bool side)
				{
					if (!clickEnabled) { return; }
					Singleton<ViewManager>.Instance.SwitchToView(View.MapDeckReview, false, true);
					if (!side)
					{
						this.Deck = new List<SelectableCard>();
						GameObject.Find("sidedeckBack").transform.localPosition = new Vector3(4.45f, 5.01f, 1);
						GameObject.Find("shopObjects").transform.position = new Vector3(0f, -9f, 0f);


						List<CardInfo> cards = new List<CardInfo>(RunState.Run.playerDeck.Cards);
						cards.RemoveAll((CardInfo x) => x.HasTrait(Trait.EatsWarrens));


						GameObject theDeck = Singleton<DeckReviewSequencer>.Instance.gameObject;
						theDeck.transform.parent = GameObject.Find("GameTable").transform;
						theDeck.transform.localPosition = new Vector3(-0.35f, 5.01f, 1.15f);

						Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(Singleton<DeckReviewSequencer>.Instance.cardArray.DisplayUntilCancelled(cards, null, () => GameObject.Find("shopObjects").transform.position.y >= 0, null, null));

						/*for (int i = 0; i < theDeck.transform.childCount; i++)
						{
							this.Deck.Add(theDeck.transform.GetChild(i).gameObject.GetComponent<SelectableCard>());
						}*/
					}
					else
					{
						this.MoxDeck = new List<SelectableCard>();
						GameObject.Find("sidedeckBack").transform.localPosition = new Vector3(4.45f, 5.01f, 1);
						GameObject.Find("shopObjects").transform.position = new Vector3(0f, -9f, 0f);
						MagCurrentNode.GetSideDeck();

						List<CardInfo> cards = new List<CardInfo>();

						string text = File.ReadAllText(SaveManager.SaveFolderPath + "MagnificusModSave.gwsave");
						string[] array3 = text.Split(new char[]
						{
									'R'
						});
						array3 = array3[1].Split(new char[]
						{
									','
						});
						for (int j = 0; j < int.Parse(array3[0]); j++)
						{
							CardInfo cardByName = CardLoader.GetCardByName("MoxRuby");
							cards.Add(cardByName);
						}
						for (int k = 0; k < int.Parse(array3[1]); k++)
						{
							CardInfo cardByName2 = CardLoader.GetCardByName("MoxEmerald");
							cards.Add(cardByName2);
						}
						for (int l = 0; l < int.Parse(array3[2]); l++)
						{
							CardInfo cardByName3 = CardLoader.GetCardByName("MoxSapphire");
							cards.Add(cardByName3);
						}

						int[] amts = { 0, 0, 0 };
						foreach (CardInfo card in cards)
						{
							int idx = 0;
							if (card.name == "MoxEmerald") { idx = 1; }
							else if (card.name == "MoxSapphire") { idx = 2; }

							if (!SaveManager.saveFile.grimoraData.deck.cardIdModInfos.ContainsKey(card.name + "#" + amts[idx])) { continue; }

							card.mods.AddRange(SaveManager.saveFile.grimoraData.deck.cardIdModInfos[card.name + "#" + amts[idx]]);
                            card.SetPortrait(MagCurrentNode.getMixPortrait(card.mods[0].nameReplacement));
                            amts[idx]++;
						}

						for (int i = 0; i < cards.Count; i++)
						{
							GameObject gameObject = GameObject.Instantiate<GameObject>(Singleton<SelectableCardArray>.Instance.selectableCardPrefab);
							gameObject.transform.SetParent(GameObject.Find("GameTable").transform);
							SelectableCard component2 = gameObject.GetComponent<SelectableCard>();
							component2.Initialize(cards[i], new Action<SelectableCard>(this.action), null, false);
							component2.SetEnabled(false);
							component2.SetInfo(cards[i]);
							Singleton<SelectableCardArray>.Instance.displayedCards.Add(component2);//component2.transform.position = new Vector3(1.3f * num4 - 2.5f - num4 / 5 * 6.5f, 5.01f, 0.5f + num4 / 5 * 2);

							float layer = i % 5;

							component2.transform.localPosition = new Vector3(-3.35f + (1.5f * layer), 5.25f, (i < 5) ? 2.15f : 0f);
							component2.Anim.PlayQuickRiffleSound();

							component2.SetCardback(Tools.getImage("magcardback.png"));

							Tween.LocalPosition(component2.transform, new Vector3(component2.transform.localPosition.x, 5.01f + (0.02f * layer), component2.transform.localPosition.z), 0.1f, (i / 35.0f));

							component2.GetComponent<Collider>().enabled = true;

							component2.CursorEntered = (Action<MainInputInteractable>)Delegate.Combine(component2.CursorEntered, new Action<MainInputInteractable>(delegate (MainInputInteractable m)
							{
								if (!component2.FaceDown)
									Tween.LocalPosition(component2.transform.Find("Quad").Find("CardBase"), new Vector3(0, 0, -0.1f), 0.1f, 0);
							}));

							component2.CursorExited = (Action<MainInputInteractable>)Delegate.Combine(component2.CursorExited, new Action<MainInputInteractable>(delegate (MainInputInteractable m)
							{
								Tween.LocalPosition(component2.transform.Find("Quad").Find("CardBase"), Vector3.zero, 0.1f, 0);
							}));

							this.MoxDeck.Add(component2);
						}
					}
				}

				public List<SelectableCard> MoxDeck = new List<SelectableCard>();

				public static bool openingCardPack = false;

				public List<SelectableCard> Deck = new List<SelectableCard>();

				public List<SelectableCard> cardPackCards = new List<SelectableCard>();

				public List<SelectableCard> created = new List<SelectableCard>();
			}
		}

		public class magdeck : CardChoicesSequencer
		{
			public ConfirmStoneButton confirmStone { get; set; }

			public IEnumerator sequencer(CustomNodeDeck tradeCardsData)
			{
				yield return new WaitForSeconds(0.75f);

				if (RunState.Run.playerDeck.Cards.FindAll((CardInfo x) => x.HasTrait(Trait.EatsWarrens)).Count > 0)
				{
					GameObject spellBook = new GameObject("DeckSpellBook");
					spellBook.gameObject.AddComponent<MagnificusMod.DeckSpellBook>();
					spellBook.transform.parent = GameObject.Find("GameTable").transform;
					spellBook.transform.localPosition = new Vector3(4.5f, 27.5f, 3f);
					spellBook.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
					spellBook.transform.localRotation = Quaternion.Euler(0, 35, 0);

					spellBook.GetComponent<DeckSpellBook>().initializeItems();
					Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(spellBook.GetComponent<DeckSpellBook>().initialize(new Vector3(4.5f, 7.5f, 3f), 1.1f));
					spellBook.GetComponent<DeckSpellBook>().refreshSpellBookCards(RunState.Run.playerDeck.Cards.FindAll((CardInfo x) => x.HasTrait(Trait.EatsWarrens)));
				}

				GameObject lifeCounter = GameObject.Find("GameTable").transform.Find("LifePainting").gameObject;
				lifeCounter.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = Tools.getImage("lifepainting" + RunState.Run.playerLives + ".png");
				lifeCounter.SetActive(true);
				lifeCounter.GetComponent<SineWaveMovement>().enabled = false;
				lifeCounter.GetComponent<SineWaveMovement>().originalPosition = new Vector3(7.75f, 6.72f, 0.8f);
				lifeCounter.transform.localRotation = Quaternion.Euler(0, 65, 0);
				Tween.LocalPosition(lifeCounter.transform, new Vector3(7.75f, 6.72f, 0.8f), 0.15f, 0);
				GameObject theDeck = Singleton<DeckReviewSequencer>.Instance.gameObject;
				Singleton<ViewController>.Instance.LockState = ViewLockState.Unlocked;
				//Singleton<ViewController>.Instance.back = ViewLockState.Unlocked;
				Singleton<ViewController>.Instance.controlMode = ViewController.ControlMode.MapNoDeckReview;
				theDeck.transform.parent = GameObject.Find("GameTable").transform;
				theDeck.transform.localPosition = new Vector3(0, 5.01f, 1.5f);
				theDeck.transform.localScale = new Vector3(1, 1, 1);

				List<CardInfo> cards = new List<CardInfo> (RunState.Run.playerDeck.Cards);
				cards.RemoveAll((CardInfo x) => x.HasTrait(Trait.EatsWarrens));

                Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(Singleton<DeckReviewSequencer>.Instance.cardArray.DisplayUntilCancelled(cards, null, () => Singleton<ViewManager>.Instance.CurrentView != View.MapDeckReview && Singleton<ViewManager>.Instance.CurrentView != View.Candles, null, null));
				
				Singleton<ViewManager>.Instance.Controller.LockState = ViewLockState.Unlocked;
				float pauseTime = CardPile.GetPauseBetweenCardTime(RunState.Run.playerDeck.Cards.Count);
				pauseTime *= RunState.Run.playerDeck.Cards.Count;
				yield return new WaitForSeconds(pauseTime + 0.15f);
				lifeCounter.GetComponent<SineWaveMovement>().enabled = true;
				Singleton<ViewController>.Instance.LockState = ViewLockState.Unlocked;
				Singleton<ViewController>.Instance.SwitchToControlMode(ViewController.ControlMode.MapNoDeckReview);
				yield break;
			}

			public int i = 0;

			public int card = 0;

			public int cd = 0;

			public int selectingoptions = 3;

			public List<SelectableCard> cardpicked = new List<SelectableCard>();

			public List<SelectableCard> cardpickedfromdeck = new List<SelectableCard>();

			public List<SelectableCard> created = new List<SelectableCard>();
		}

		public class painting : CardChoicesSequencer
		{
			public ConfirmStoneButton confirmStone { get; set; }
			public ConfirmStoneButton confirmedStone { get; set; }
			public void pickUpEdaxio(SelectableCard component)
			{
				onCard = true;
				base.StartCoroutine(draw());
			}

			public static bool onCard = false;
			float size = 2f;
			public IEnumerator draw()
            {
				if (canTakeIt)
				{
					RunState.Run.playerDeck.AddCard(GameObject.Find("cardel").GetComponent<SelectableCard>().Info);
					GameObject.Find("Splotches").transform.parent = GameObject.Find("cardel").transform;
					GameObject.Find("cardel").GetComponent<SelectableCard>().ExitBoard(0.5f, new Vector3(0, 0.5f, 0));
					yield return new WaitForSeconds(0.5f);
					Destroy(GameObject.Find("PaintingEvent"));
					Destroy(GameObject.Find("Splotches"));
					Destroy(GameObject.Find("TESTSTONE"));
					Destroy(GameObject.Find("CONFIRMSTONE"));
					Singleton<GameFlowManager>.Instance.TransitionToGameState(GameState.Map, null);
				}
					if (confirmed) { yield break; }
				while (Input.GetMouseButton(0) && onCard && splotches.Count < 501)
				{
					paintSplotch.transform.localScale = new Vector3(size * 0.1f, size * 0.1f, size * 0.1f);
					GameObject splotch = Instantiate(paintSplotch);
					
					splotch.name = "splotch";
					splotch.transform.parent = GameObject.Find("Splotches").transform;
					if (size < 2)
					{
						splotch.GetComponent<SpriteRenderer>().sprite = Tools.getSprite("smallpaint.png");
					}
					int colorId = 0;
					switch(selectedColor)
                    {
						case "gem":
							splotch.GetComponent<SpriteRenderer>().color = color;
							break;
						case "black":
							colorId = 1;
							splotch.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1);
							break;
						case "white":
							colorId = 2;
							splotch.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
							break;
					}
					GameObject cursor = GameObject.Find("Cursor");
					splotch.transform.localRotation = Quaternion.Euler(0, 0, UnityEngine.Random.RandomRangeInt(0, 180));
					splotch.transform.localPosition = new Vector3(cursor.transform.position.x, cursor.transform.position.y + 6.1f, -2.61f - (0.01f * colorId));
					splotchData.Add(Math.Round(splotch.transform.localPosition.x, 2) + "," + Math.Round(splotch.transform.localPosition.y, 2) + "," + size + "," + colorId);
					splotches.Add(splotch);
					yield return new WaitForSeconds(0.025f);
				}
				if (splotches.Count >= 501 && !playedPaintWarning)
                {
					playedPaintWarning = true;
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Hmm.. You're out of paint.", -0.25f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("You can bleach your drawing.. or consider it finished.", -0.25f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
				}
				if (GameObject.Find("CONFIRMSTONE").transform.position.y > 18)
				{
					base.StartCoroutine(enableConfirm(true));
				}
				yield break;
			}

			public IEnumerator enableConfirm(bool enable)
            {
				this.confirmedStone.SetEnabled(enable);
				GameObject.Find("CONFIRMSTONE").GetComponent<BoxCollider>().enabled = false;
				float pos = enable ? 14.72f : 18.72f;
				float antiPos = !enable ? 14.72f : 18.72f;
				if (pos < 15)
				{
					GameObject.Find("CONFIRMSTONE").transform.position = new Vector3(GameObject.Find("GameTable").transform.position.x, antiPos, -4f + GameObject.Find("GameTable").transform.position.z);
				}
				Tween.Position(GameObject.Find("CONFIRMSTONE").transform, new Vector3(GameObject.Find("GameTable").transform.position.x, pos, -4f + GameObject.Find("GameTable").transform.position.z), 0.25f, 0);
				yield return new WaitForSeconds(0.251f);
				GameObject.Find("CONFIRMSTONE").GetComponent<BoxCollider>().enabled = true;
				if (pos > 15)
				{
					GameObject.Find("CONFIRMSTONE").transform.position = new Vector3(GameObject.Find("GameTable").transform.position.x, pos, -5f + GameObject.Find("GameTable").transform.position.z);
				}
				yield break;
			}

			public Color color = new Color(1, 1, 1, 1);
			public string selectedColor = "gem";
			public List<string> splotchData = new List<string>();
			public bool playedPaintWarning = false;
			public IEnumerator sequencer(PaintingEvent tradeCardsData)
			{
				Singleton<ViewManager>.Instance.SwitchToView(View.Default, false, true);
				GameObject sequencer = Instantiate(new GameObject());
				sequencer.name = "PaintingEvent";
				sequencer.transform.parent = base.transform;
				sequencer.transform.localPosition = new Vector3(0, 0, 0);
				if (SaveManager.saveFile.ascensionActive && MagnificusMod.Generation.challenges.Contains("FadingMox"))
				{
					Singleton<MagnificusLifeManager>.Instance.playerLife = KayceeStorage.FleetingLife;
				}
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("A neccesary part of each student's training is art..", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Let's start with the portrait..", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
				splotchData = new List<string>();
				confirmed = false;
				canTakeIt = false;
				playedPaintWarning = false;
				yield return new WaitForSeconds(0.75f);
				GameObject gameObject = GameObject.Instantiate<GameObject>(Singleton<SelectableCardArray>.Instance.selectableCardPrefab);
				gameObject.transform.SetParent(sequencer.transform);
				SelectableCard component = gameObject.GetComponent<SelectableCard>();
				component.SetInfo(CardLoader.GetCardByName("mag_portraitmage"));
				component.renderInfo.hiddenAttack = true;
				component.renderInfo.hiddenHealth = true;
				component.SetEnabled(false);
				Singleton<SelectableCardArray>.Instance.displayedCards.Add(component);
				Singleton<SelectableCardArray>.Instance.TweenInCard(component.transform, new Vector3(0, 7.55f, -2.6f), 0, false);
				component.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
				component.Anim.PlayQuickRiffleSound();
				component.Initialize(component.Info, new Action<SelectableCard>(this.pickUpEdaxio), null, false, null);
				gameObject.name = "cardel";
				paintSplotch = Instantiate(new GameObject());
				paintSplotch.AddComponent<SpriteRenderer>().sprite = Tools.getSprite("paint.png");
				paintSplotch.name = "paintSplotch";
				paintSplotch.transform.parent = sequencer.transform;
				List<Color> random = new List<Color>();
				foreach(CardInfo card in RunState.Run.playerDeck.Cards)
                {
					if (card.gemsCost.Count > 0)
                    {
						switch(card.gemsCost[0])
                        {
							case GemType.Blue:
								random.Add(new Color(0, 0.5f, 1, 1));
								break;
							case GemType.Green:
								random.Add(new Color(0, 1, 0.1f, 1));
								break;
							case GemType.Orange:
								random.Add(new Color(1, 0.5f, 0, 1));
								break;
						}
                    }
                }
				if (random.Count > 0)
				{
					color = random[UnityEngine.Random.RandomRangeInt(0, random.Count)];
				} else
                {
					color = new Color(0, 1, 0.1f, 1);
                }
				paintSplotch.GetComponent<SpriteRenderer>().color = color;
				paintSplotch.transform.position = new Vector3(0, 0, 0);
				paintSplotch.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);

				GameObject splotchid = Instantiate(new GameObject());
				splotchid.name = "Splotches";
				splotchid.transform.parent = sequencer.transform;
				splotchid.transform.localPosition = new Vector3(0, 0, 0);

				splotches = new List<GameObject>();
				yield return new WaitForSeconds(Time.deltaTime);
				component.GetComponent<Collider>().enabled = true;
				yield return new WaitForSeconds(Time.deltaTime * 0f);
				this.cardpickedfromdeck.Add(component);
				yield return new WaitForSeconds(Time.deltaTime);
				Tween.LocalPosition(component.gameObject.transform, new Vector3(0f, 6.55f, -2.6f), 0.2f, 0);

				GameObject easel = Instantiate(GameObject.Find("CopyCardSequencer").transform.Find("EaselWithSlot").gameObject);
				easel.transform.GetChild(1).gameObject.SetActive(false);
				easel.transform.GetChild(2).gameObject.SetActive(false);
				easel.transform.parent = sequencer.transform;
				easel.transform.localPosition = new Vector3(0f, 6.42f, -2.15f);
				easel.transform.GetChild(0).localRotation = Quaternion.Euler(0, 180, 0);
				easel.transform.GetChild(0).GetChild(0).Find("main").gameObject.SetActive(false);
				easel.transform.localRotation = Quaternion.Euler(0, 355.75f, 0);
				easel.SetActive(true);

				GameObject.Instantiate(Resources.Load("prefabs\\specialnodesequences\\ConfirmStoneButton")).name = "TESTSTONE";
				GameObject.Find("TESTSTONE").AddComponent<BoxCollider>().size = new Vector3(1.4f, 0.2f, 2.1f);
				GameObject.Find("TESTSTONE").transform.Find("Anim").Find("model").Find("ConfirmButton").Find("Quad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = (Resources.Load("art/cards/copycard_button") as Texture2D);
				GameObject.Find("TESTSTONE").transform.Find("Anim").Find("model").Find("ConfirmButton").Find("Quad").gameObject.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1, 1);
				GameObject.Find("TESTSTONE").transform.Find("Anim").Find("model").localScale = new Vector3(0.01f, 0.01f, 0.01f);
				GameObject.Find("TESTSTONE").transform.Find("Anim").Find("model").Find("ConfirmButton").gameObject.GetComponent<BoxCollider>().size = new Vector3(75, 50, 75);
				this.confirmStone = GameObject.Find("TESTSTONE").GetComponentInChildren<ConfirmStoneButton>();
				confirmStone.currentHighlightedColor = new Color(0.85f, 0.85f, 0.85f, 1);
				confirmStone.currentInteractableColor = new Color(1f, 1, 1, 1);
				GameObject.Find("TESTSTONE").transform.localRotation = Quaternion.Euler(335f, 315f, 0);
				this.confirmStone = GameObject.Find("TESTSTONE").GetComponentInChildren<ConfirmStoneButton>();
				GameObject.Find("TESTSTONE").transform.position = new Vector3(GameObject.Find("GameTable").transform.position.x - 2, 14.8f, -2.6f + GameObject.Find("GameTable").transform.position.z);
				GameObject.Find("TESTSTONE").transform.localScale = new Vector3(0.75f, 2f, 0.75f);
				bool deleting = false;
				this.confirmStone.confirmView = View.Default;
				this.confirmStone.ResetAnimTriggers();
				this.confirmStone.anim.gameObject.SetActive(true);
				this.confirmStone.SetButtonInteractable();
				this.confirmStone.cursorType = CursorType.Pickup;

				GameObject pot = Instantiate(Resources.Load("prefabs/items/BleachPotItem") as GameObject);
				pot.name = "pottery";
				pot.GetComponent<Animator>().enabled = false;
				pot.transform.parent = sequencer.transform;
				pot.transform.localPosition = new Vector3(-2, 5, -2.6f);

				component.CursorExited = (Action<MainInputInteractable>)Delegate.Combine(component.CursorExited, new Action<MainInputInteractable>(delegate (MainInputInteractable i)
				{
					onCard = false;
				}));
				confirmStone.CursorSelectStarted = (Action<MainInputInteractable>)Delegate.Combine(confirmStone.CursorSelectStarted, new Action<MainInputInteractable>(delegate (MainInputInteractable i)
				{
					if (!deleting)
                    {
						base.StartCoroutine(enableConfirm(false));
						deleting = true;
						this.confirmStone.ShowPressed();
						base.StartCoroutine(bleachShake());
						AudioController.Instance.PlaySound2D("magnificus_brush_splatter_bleach", MixerGroup.None, 0.5f, 0f, null, null, null, null, false);
						for (int j = 0; j < splotches.Count; j++)
                        {
							DestroyImmediate(splotches[j]);
                        }
						this.confirmStone.ResetAnimTriggers();
						splotches = new List<GameObject>();
						splotchData = new List<string>();
						playedPaintWarning = false;
						deleting = false;
                    }
				}));

				Singleton<Part3ItemsManager>.Instance.hammerSlot.InitializeHammer();
				GameObject smallBrush = Instantiate(Singleton<Part3ItemsManager>.Instance.hammerSlot.gameObject);
				smallBrush.transform.parent = sequencer.transform;
				smallBrush.transform.localPosition = new Vector3(1.8f, 5.1f, -4.3f);
				smallBrush.transform.GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(false);
				smallBrush.name = "Brush";
				smallBrush.GetComponent<BoxCollider>().center = new Vector3(-0.5f, 0, 0);
				smallBrush.GetComponent<BoxCollider>().size = new Vector3(1f, 0.5f, 2.75f);
				GameObject brushModel = Instantiate(GameObject.Find("MagnificusBrush"));
				brushModel.name = "brushsmall";
				brushModel.transform.parent = smallBrush.transform.GetChild(0).GetChild(0);
				brushModel.transform.localPosition = new Vector3(0, 0, 0);
				brushModel.transform.localRotation = Quaternion.Euler(90, 0, 0);
				brushModel.transform.localScale = new Vector3(0.5f, 0.7f, 0.5f);
				brushModel.SetActive(false);
				GameObject brushModel2 = Instantiate(brushModel);
				brushModel2.name = "brushbig";
				brushModel2.transform.parent = smallBrush.transform.GetChild(0).GetChild(0);
				brushModel2.transform.localScale = new Vector3(1f, 1f, 1f);
				brushModel2.transform.localPosition = new Vector3(0, 0, 0);
				brushModel2.transform.localRotation = Quaternion.Euler(90, 0, 0);
				brushModel2.SetActive(true);
				if (smallBrush.transform.childCount > 1)
				{
					smallBrush.transform.GetChild(1).gameObject.SetActive(false);
				}

				smallBrush.GetComponent<ConsumableItemSlot>().CursorEntered = (Action<MainInputInteractable>)Delegate.Combine(smallBrush.GetComponent<ConsumableItemSlot>().CursorEntered, new Action<MainInputInteractable>(delegate (MainInputInteractable i)
				{
					Tween.LocalPosition(smallBrush.transform.GetChild(0).GetChild(0).Find("brushsmall"), new Vector3(0, -0.1f, 0f), 0.1f, 0);
					Tween.LocalRotation(smallBrush.transform.GetChild(0).GetChild(0).Find("brushsmall"), new Vector3(90, -15f, 0f), 0.1f, 0);
					Tween.LocalPosition(smallBrush.transform.GetChild(0).GetChild(0).Find("brushbig"), new Vector3(0, -0.1f, 0f), 0.1f, 0);
					Tween.LocalRotation(smallBrush.transform.GetChild(0).GetChild(0).Find("brushbig"), new Vector3(90, -15f, 0f), 0.1f, 0);
				}));

				smallBrush.GetComponent<ConsumableItemSlot>().CursorExited = (Action<MainInputInteractable>)Delegate.Combine(smallBrush.GetComponent<ConsumableItemSlot>().CursorExited, new Action<MainInputInteractable>(delegate (MainInputInteractable i)
				{
					Tween.LocalPosition(smallBrush.transform.GetChild(0).GetChild(0).Find("brushsmall"), new Vector3(0, 0f, 0f), 0.1f, 0);
					Tween.LocalRotation(smallBrush.transform.GetChild(0).GetChild(0).Find("brushsmall"), new Vector3(90, 0f, 0f), 0.1f, 0);
					Tween.LocalPosition(smallBrush.transform.GetChild(0).GetChild(0).Find("brushbig"), new Vector3(0, 0f, 0f), 0.1f, 0);
					Tween.LocalRotation(smallBrush.transform.GetChild(0).GetChild(0).Find("brushbig"), new Vector3(90, 0f, 0f), 0.1f, 0);
				}));

				smallBrush.GetComponent<ConsumableItemSlot>().CursorSelectStarted = (Action<MainInputInteractable>)Delegate.Combine(smallBrush.GetComponent<ConsumableItemSlot>().CursorSelectStarted, new Action<MainInputInteractable>(delegate (MainInputInteractable i)
				{
					AudioController.Instance.PlaySound2D("wardrobe_slider", MixerGroup.None, 0.5f, 0f, null, null, null, null, false);
					bool selectedSmall = smallBrush.transform.GetChild(0).GetChild(0).Find("brushsmall").gameObject.activeSelf ? true : false;
					smallBrush.transform.GetChild(0).GetChild(0).Find("brushsmall").gameObject.SetActive(!selectedSmall);
					smallBrush.transform.GetChild(0).GetChild(0).Find("brushbig").gameObject.SetActive(selectedSmall);
					smallBrush.SetActive(false);
					smallBrush.SetActive(true);
					size = selectedSmall ? 2f : 1f;
				}));

				GameObject brushColors = Instantiate(Singleton<Part3ItemsManager>.Instance.hammerSlot.gameObject);
				brushColors.transform.parent = sequencer.transform;
				brushColors.transform.localPosition = new Vector3(3.7f, 5.1f, 1.2f);
				brushColors.transform.localRotation = Quaternion.Euler(0, 333, 0);
				brushColors.transform.GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(false);
				brushColors.name = "BrushColors";
				brushColors.GetComponent<BoxCollider>().center = new Vector3(-0.5f, 0, 0);
				brushColors.GetComponent<BoxCollider>().size = new Vector3(1f, 0.5f, 2.75f);
				GameObject BlackBrush = Instantiate(pot.transform.GetChild(0).GetChild(1).gameObject);
				BlackBrush.name = "brush.black";
				BlackBrush.transform.parent = brushColors.transform.GetChild(0).GetChild(0);
				BlackBrush.transform.localRotation = Quaternion.Euler(0, 0, 0);
				BlackBrush.transform.localPosition = new Vector3(0, 0, 0);
				BlackBrush.GetComponent<MeshRenderer>().material.mainTexture = Tools.getImage("blackbrush.png");
				BlackBrush.SetActive(false);
				GameObject WhiteBrush = Instantiate(pot.transform.GetChild(0).GetChild(1).gameObject);
				WhiteBrush.name = "brush.white";
				WhiteBrush.transform.parent = brushColors.transform.GetChild(0).GetChild(0);
				WhiteBrush.transform.localPosition = new Vector3(0, 0, 0);
				WhiteBrush.transform.localRotation = Quaternion.Euler(0, 0, 0);
				WhiteBrush.SetActive(false);
				GameObject GemBrush = Instantiate(brushModel);
				GemBrush.name = "brush.gem";
				GemBrush.transform.parent = brushColors.transform.GetChild(0).GetChild(0);
				GemBrush.transform.localScale = new Vector3(1f, 1f, 1f);
				GemBrush.transform.localPosition = new Vector3(0, 0, 0);
				GemBrush.transform.localRotation = Quaternion.Euler(90, 0, 0);
				GemBrush.SetActive(true);
				if (brushColors.transform.childCount > 1)
				{
					brushColors.transform.GetChild(1).gameObject.SetActive(false);
				}

				brushColors.GetComponent<ConsumableItemSlot>().CursorEntered = (Action<MainInputInteractable>)Delegate.Combine(brushColors.GetComponent<ConsumableItemSlot>().CursorEntered, new Action<MainInputInteractable>(delegate (MainInputInteractable i)
				{
					Tween.LocalPosition(brushColors.transform.GetChild(0).GetChild(0).Find("brush.black"), new Vector3(0, -0.1f, 0f), 0.1f, 0);
					Tween.LocalRotation(brushColors.transform.GetChild(0).GetChild(0).Find("brush.black"), new Vector3(0, -15f, 0f), 0.1f, 0);
					Tween.LocalPosition(brushColors.transform.GetChild(0).GetChild(0).Find("brush.white"), new Vector3(0, -0.1f, 0f), 0.1f, 0);
					Tween.LocalRotation(brushColors.transform.GetChild(0).GetChild(0).Find("brush.white"), new Vector3(0, -15f, 0f), 0.1f, 0);
					Tween.LocalPosition(brushColors.transform.GetChild(0).GetChild(0).Find("brush.gem"), new Vector3(0, -0.1f, 0f), 0.1f, 0);
					Tween.LocalRotation(brushColors.transform.GetChild(0).GetChild(0).Find("brush.gem"), new Vector3(90, -15f, 0f), 0.1f, 0);
				}));

				brushColors.GetComponent<ConsumableItemSlot>().CursorExited = (Action<MainInputInteractable>)Delegate.Combine(brushColors.GetComponent<ConsumableItemSlot>().CursorExited, new Action<MainInputInteractable>(delegate (MainInputInteractable i)
				{
					Tween.LocalPosition(brushColors.transform.GetChild(0).GetChild(0).Find("brush.black"), new Vector3(0, 0, 0f), 0.1f, 0);
					Tween.LocalRotation(brushColors.transform.GetChild(0).GetChild(0).Find("brush.black"), new Vector3(0, 0f, 0f), 0.1f, 0);
					Tween.LocalPosition(brushColors.transform.GetChild(0).GetChild(0).Find("brush.white"), new Vector3(0, 0f, 0f), 0.1f, 0);
					Tween.LocalRotation(brushColors.transform.GetChild(0).GetChild(0).Find("brush.white"), new Vector3(0, 0f, 0f), 0.1f, 0);
					Tween.LocalPosition(brushColors.transform.GetChild(0).GetChild(0).Find("brush.gem"), new Vector3(0, 0f, 0f), 0.1f, 0);
					Tween.LocalRotation(brushColors.transform.GetChild(0).GetChild(0).Find("brush.gem"), new Vector3(90, 0f, 0f), 0.1f, 0);
				}));

				brushColors.GetComponent<ConsumableItemSlot>().CursorSelectStarted = (Action<MainInputInteractable>)Delegate.Combine(brushColors.GetComponent<ConsumableItemSlot>().CursorSelectStarted, new Action<MainInputInteractable>(delegate (MainInputInteractable j)
				{
					AudioController.Instance.PlaySound2D("wardrobe_slider", MixerGroup.None, 0.5f, 0f, null, null, null, null, false);
					string brushType = "gem";
					List<string> brushTypes = new List<string> { "black", "white", "gem" };
					for (int i = 1; i < brushColors.transform.GetChild(0).GetChild(0).childCount; i++)
                    {
						if (brushColors.transform.GetChild(0).GetChild(0).GetChild(i).gameObject.activeSelf)
                        {
							brushType = brushColors.transform.GetChild(0).GetChild(0).GetChild(i).gameObject.name.Split('.')[1];
						}
                    }
					string nextType = "black";
					if (brushType != "gem") { nextType = brushTypes[brushTypes.IndexOf(brushType) + 1]; }
					brushColors.transform.GetChild(0).GetChild(0).Find("brush." + brushType).gameObject.SetActive(false);
					brushColors.transform.GetChild(0).GetChild(0).Find("brush." + nextType).gameObject.SetActive(true);
					brushColors.SetActive(false);
					brushColors.SetActive(true);
					selectedColor = nextType;
				}));

				if (!SavedVars.LearnedMechanics.Contains("cardpainting"))
				{
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("You can use the bleach on the left to wipe your work..", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("You are currently holding a [c:g1]replica brush[c:].. If you feel you need a smaller one, you can grab the one on the right.", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Use that brush in the back to change your color.", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
					SavedVars.LearnedMechanics += "cardpainting;";
				}

				GameObject.Instantiate(Resources.Load("prefabs\\specialnodesequences\\ConfirmStoneButton")).name = "CONFIRMSTONE";
				GameObject.Find("CONFIRMSTONE").AddComponent<BoxCollider>().size = new Vector3(1.4f, 0.2f, 2.1f);
				GameObject.Find("CONFIRMSTONE").transform.Find("Anim").Find("model").Find("ConfirmButton").Find("Quad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = (Resources.Load("art/cards/copycard_button") as Texture2D);
				GameObject.Find("CONFIRMSTONE").transform.Find("Anim").Find("model").Find("ConfirmButton").Find("Quad").gameObject.GetComponent<MeshRenderer>().material.color = new Color(0, 1, 0.5f, 1);
				this.confirmedStone = GameObject.Find("CONFIRMSTONE").GetComponentInChildren<ConfirmStoneButton>();
				confirmedStone.currentHighlightedColor = new Color(0.5f, 1f, 0.5f, 1);
				confirmedStone.currentInteractableColor = new Color(0.2f, 1, 0.2f, 1);
				this.confirmedStone = GameObject.Find("CONFIRMSTONE").GetComponentInChildren<ConfirmStoneButton>();
				GameObject.Find("CONFIRMSTONE").transform.position = new Vector3(GameObject.Find("GameTable").transform.position.x, 18.72f, -5f + GameObject.Find("GameTable").transform.position.z);

				this.confirmedStone.confirmView = View.Default;
				this.confirmedStone.Enter();
				this.confirmedStone.SetEnabled(false);
				yield return this.confirmedStone.WaitUntilConfirmation();
				confirmed = true;
				Tween.LocalPosition(smallBrush.transform, new Vector3(7.8f, 10.8f, -4.3f), 0.2f, 0);
				Tween.LocalPosition(brushColors.transform, new Vector3(7.7f, 10.8f, 1.2f), 0.2f, 0);
				Tween.LocalPosition(GameObject.Find("TESTSTONE").transform, new Vector3(GameObject.Find("GameTable").transform.position.x - 6, 20.52f, -2.6f + GameObject.Find("GameTable").transform.position.z), 0.2f, 0);
				Tween.LocalPosition(GameObject.Find("pottery").transform, new Vector3(-6, 10.8f, -2.6f), 0.2f, 0);

				CardModificationInfo mod = new CardModificationInfo();
				mod.decalIds = splotchData;
				List<Color> allColors = new List<Color> { new Color(1, 0.5f, 0, 1), new Color(0, 0.5f, 1, 1), new Color(0, 1, 0.1f, 1) };
				List<GemType> colorGem = new List<GemType> { GemType.Orange, GemType.Blue, GemType.Green };
				mod.addGemCost = new List<GemType> { colorGem[allColors.IndexOf(color)] };
				component.Info.mods.Add(mod);

				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("My pupil's portraits never fail to amuse me..", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);

				Tween.LocalPosition(GameObject.Find("CONFIRMSTONE").transform, new Vector3(GameObject.Find("GameTable").transform.position.x - 2, 20.52f, -5f + GameObject.Find("GameTable").transform.position.z), 0.2f, 0.5f);
				Tween.LocalPosition(easel.transform, new Vector3(0, 6.42f, -0.7f), 0.85f, 0.5f);
				Tween.LocalPosition(component.gameObject.transform, new Vector3(0f, 6.55f, -1.16f), 0.85f, 0.5f);
				Tween.LocalPosition(splotchid.transform, new Vector3(0f, 0, 1.44f), 0.85f, 0.5f);
				yield return new WaitForSeconds(0.6f);
				Singleton<ViewManager>.Instance.SwitchToView(View.Choices);
				yield return new WaitForSeconds(1.5f);
				
				List<CardInfo> deck = new List<CardInfo>();

				List<CardInfo> killedCards = CardLoader.GetUnlockedCards(CardMetaCategory.ChoiceNode, CardTemple.Wizard);

				for (int i = 0; i < killedCards.Count; i++) {
					int inDex = Random.RandomRangeInt(0, killedCards.Count);

					CardInfo card = killedCards[inDex];

					killedCards.RemoveAt(inDex);
					deck.Add(card);
                }
				deck.RemoveAll((CardInfo x) => x.HasTrait(Trait.EatsWarrens) || x.SpecialStatIcon != SpecialStatIcon.None);
				cardChoice = new List<SelectableCard>();
				for (int i = 0; i < 3; i++)
				{
					if (deck.Count < 1)
					{
						foreach (CardInfo deckCard in presetCards)
						{
							deck.Add(deckCard);
						}
					}
					GameObject cardObject = GameObject.Instantiate<GameObject>(Singleton<SelectableCardArray>.Instance.selectableCardPrefab);
					cardObject.transform.SetParent(base.transform);
					SelectableCard component2 = cardObject.GetComponent<SelectableCard>();
					int rand = UnityEngine.Random.RandomRangeInt(0, deck.Count);
					
					component2.Initialize(deck[rand], new Action<SelectableCard>(Singleton<SelectableCardArray>.Instance.OnCardSelected), null, false, new Action<SelectableCard>(Singleton<SelectableCardArray>.Instance.OnCardInspected));
					component2.SetEnabled(false);
					Singleton<SelectableCardArray>.Instance.displayedCards.Add(component2);
					Singleton<SelectableCardArray>.Instance.TweenInCard(component2.transform, new Vector3(-1.8f + (1.8f * i), 5.1f, -2.9f), 0f, false);
					if (i == 0) { component2.transform.localRotation = Quaternion.Euler(90, 15, 0); }
					else if (i == 2) { component2.transform.localRotation = Quaternion.Euler(90, -15, 0); }
					component2.Anim.PlayQuickRiffleSound();
					component2.Initialize(deck[rand], new Action<SelectableCard>(this.imbueStats), null, false, null);
					component2.GetComponent<Collider>().enabled = true;
					cardChoice.Add(component2);
					deck.RemoveAt(rand);
				}
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Now let's choose which card's [c:g1]stats[c:] to imbue.", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
				yield break;
			}

			public void imbueStats(SelectableCard card)
            {
				SelectableCard component = GameObject.Find("cardel").GetComponent<SelectableCard>();
				component.Info.mods[0].attackAdjustment = card.Info.Attack;
				component.Info.mods[0].healthAdjustment = card.Info.Health;
				component.renderInfo.attack = card.Info.Attack;
				component.renderInfo.health = card.Info.Health;
				component.renderInfo.hiddenAttack = false;
				component.renderInfo.hiddenHealth = false;
				component.renderInfo.healthTextColor = new Color(0, 0, 0, 1);
				component.RenderCard();
				AudioController.Instance.PlaySound2D("magnificus_brush_splatter_color", MixerGroup.None, 0.5f, 0f, null, null, null, null, false);
				card.SetCardback(Tools.getImage("magcardback.png"));
				card.Anim.PlayTransformAnimation();
				string[] killedCards = SavedVars.KilledCards.Split(';');
				selectedCard = Array.IndexOf(killedCards, card.Info.name);
				SaveManager.SaveToFile();
				base.StartCoroutine(startSigilCards(card.Info));
				base.StartCoroutine(clearCrads(card));
			}

			public void imbueSigils(SelectableCard card)
			{
				SelectableCard component = GameObject.Find("cardel").GetComponent<SelectableCard>();
				component.Info.mods[0].abilities = card.Info.abilities;
				foreach (Ability modability in card.Info.ModAbilities)
				{
					component.Info.mods[0].abilities.Add(modability);
				}
				component.renderInfo.temporaryMods.Add(component.Info.mods[0]);
				component.RenderCard();
				AudioController.Instance.PlaySound2D("magnificus_brush_splatter_color", MixerGroup.None, 0.5f, 0f, null, null, null, null, false);
				card.SetCardback(Tools.getImage("magcardback.png"));
				card.Anim.PlayTransformAnimation();
				SaveManager.SaveToFile();
				base.StartCoroutine(clearCrads(card));
				base.StartCoroutine(endTheNode());
			}

			public IEnumerator clearCrads(SelectableCard card)
            {
				foreach (SelectableCard crad in cardChoice)
				{
					if (crad == card) {
						base.StartCoroutine(killThisOne(crad));
						continue;
					}
					Tween.LocalPosition(crad.transform, new Vector3(crad.transform.position.x, 5.1f, 2.9f), 0.5f, 0.75f);
				}
				yield break;
            }

			public IEnumerator endTheNode()
			{
				yield return new WaitForSeconds(0.5f);
				Singleton<ViewManager>.Instance.SwitchToView(View.Default);
				canTakeIt = true;
				yield break;
			}

			public IEnumerator killThisOne(SelectableCard crad)
            {
				yield return new WaitForSeconds(0.55f);
				crad.Anim.PlayDeathAnimation();
				Tween.LocalPosition(crad.transform, new Vector3(crad.transform.position.x, 5.1f, 2.9f), 0.5f, 0.25f);
				yield break;
			}

			public IEnumerator startSigilCards(CardInfo exclude)
            {
				yield return new WaitForSeconds(1f);
				List<CardInfo> deck = new List<CardInfo>();

				List<CardInfo> killedCards = CardLoader.GetUnlockedCards(CardMetaCategory.ChoiceNode, CardTemple.Wizard);

				for (int i = 0; i < killedCards.Count; i++)
				{
					int inDex = Random.RandomRangeInt(0, killedCards.Count);

					CardInfo card = killedCards[inDex];

					killedCards.RemoveAt(inDex);
					deck.Add(card);
				}

				deck.RemoveAll((CardInfo x) => x.HasTrait(Trait.EatsWarrens) || x.abilities.Count <= 0 || x.HasAbility(Ability.PreventAttack));
				cardChoice = new List<SelectableCard>();
				for (int i = 0; i < 3; i++)
				{
					if (deck.Count < 1)
                    {
						foreach(CardInfo deckCard in presetCards)
                        {
							deck.Add(deckCard);
                        }
                    }
					GameObject cardObject = GameObject.Instantiate<GameObject>(Singleton<SelectableCardArray>.Instance.selectableCardPrefab);
					cardObject.transform.SetParent(base.transform);
					SelectableCard component2 = cardObject.GetComponent<SelectableCard>();
					int rand = UnityEngine.Random.RandomRangeInt(0, deck.Count);

					component2.Initialize(deck[rand], new Action<SelectableCard>(Singleton<SelectableCardArray>.Instance.OnCardSelected), null, false, new Action<SelectableCard>(Singleton<SelectableCardArray>.Instance.OnCardInspected));
					component2.SetEnabled(false);
					Singleton<SelectableCardArray>.Instance.displayedCards.Add(component2);
					Singleton<SelectableCardArray>.Instance.TweenInCard(component2.transform, new Vector3(-1.8f + (1.8f * i), 5.1f, -2.9f), 0f, false);
					if (i == 0) { component2.transform.localRotation = Quaternion.Euler(90, 15, 0); }
					else if (i == 2) { component2.transform.localRotation = Quaternion.Euler(90, -15, 0); }
					component2.Anim.PlayQuickRiffleSound();
					component2.Initialize(deck[rand], new Action<SelectableCard>(this.imbueSigils), null, false, null);
					component2.GetComponent<Collider>().enabled = true;
					cardChoice.Add(component2);
					deck.RemoveAt(rand);
				}
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Now, the [c:g1]sigils[c:].", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);

				yield break;
            }

			public IEnumerator bleachShake()
            {
				
				Tween.Shake(GameObject.Find("pottery").transform, GameObject.Find("pottery").transform.localPosition, new Vector3(0.16f, 0f, 0.16f), 0.3f, 0);
				yield return new WaitForSeconds(0.31f);
				GameObject.Find("pottery").transform.localPosition = new Vector3(-2, 5, -2.6f);
				yield break;
            }

			public int selectedCard = -1;

			public List<CardInfo> presetCards = new List<CardInfo> { CardLoader.GetCardByName("MuscleMage"), CardLoader.GetCardByName("FlyingMage"), CardLoader.GetCardByName("mag_BOSSstimmage"), CardLoader.GetCardByName("RubyGolem"), CardLoader.GetCardByName("mag_scarecrow") };

			public bool canTakeIt = false;

			public GameObject paintSplotch;

			public int i = 0;

			public bool confirmed = false;

			public int card = 0;

			public int cd = 0;

			public int selectingoptions = 3;

			public List<SelectableCard> cardChoice = new List<SelectableCard>();

			public List<GameObject> splotches = new List<GameObject>();

			public List<SelectableCard> cardpicked = new List<SelectableCard>();

			public List<SelectableCard> cardpickedfromdeck = new List<SelectableCard>();

			public List<SelectableCard> created = new List<SelectableCard>();
		}

		public class magedaxio : CardChoicesSequencer
		{
			public ConfirmStoneButton confirmStone { get; set; }

			public static bool took = false;

			public void pickUpEdaxio(SelectableCard component)
			{
				if (!took)
				{
					took = true;
					RunState.Run.playerDeck.AddCard(component.Info);
					component.gameObject.GetComponent<SineWaveMovement>().enabled = false;
					component.ExitBoard(0.3f, Vector3.zero);
					Singleton<GameFlowManager>.Instance.TransitionToGameState(GameState.Map, null);
				}
			}
			public IEnumerator sequencer(EdaxioNode tradeCardsData)
			{
				yield return new WaitForSeconds(0.5f);
				Tween.Position(GameObject.Find("Player").transform, new Vector3(GameObject.Find("Player").transform.position.x, 9.5f, GameObject.Find("Player").transform.position.z), 0.15f, 0);
				took = false;
				GameObject.Find("GameTable").transform.Find("light").gameObject.SetActive(false);
				Singleton<ViewManager>.Instance.SwitchToView(View.Default, false, true);
				yield return new WaitForSeconds(0.75f);
				GameObject gameObject = GameObject.Instantiate<GameObject>(Singleton<SelectableCardArray>.Instance.selectableCardPrefab);
				gameObject.transform.SetParent(base.transform);
				SelectableCard component = gameObject.GetComponent<SelectableCard>();
				component.SetInfo(CardLoader.GetCardByName("mag_edaxiolegs"));
				if (RunState.Run.regionTier == 2)
				{
					component.SetInfo(CardLoader.GetCardByName("mag_edaxiotorso"));
				}
				else if(RunState.Run.regionTier == 3)
				{
					component.SetInfo(CardLoader.GetCardByName("mag_edaxioarms"));
				}
				else if (RunState.Run.regionTier == 4)
				{
					component.SetInfo(CardLoader.GetCardByName("mag_edaxiohead"));
				}
				component.Initialize(component.Info, new Action<SelectableCard>(Singleton<SelectableCardArray>.Instance.OnCardSelected), null, false, new Action<SelectableCard>(Singleton<SelectableCardArray>.Instance.OnCardInspected));
				component.SetEnabled(false);
				Singleton<SelectableCardArray>.Instance.displayedCards.Add(component);
				Singleton<SelectableCardArray>.Instance.TweenInCard(component.transform, new Vector3(0.2601f, 9.91f, -2.6f), 0, false);
				component.gameObject.transform.rotation = Quaternion.Euler(45, 0, 0);
				component.GetComponent<Collider>().enabled = false;
				component.Anim.PlayQuickRiffleSound();
				component.Initialize(component.Info, new Action<SelectableCard>(this.pickUpEdaxio), null, false, null);
				yield return new WaitForSeconds(Time.deltaTime * 0f);
				this.cardpickedfromdeck.Add(component);
				yield return new WaitForSeconds(Time.deltaTime);
				Tween.LocalPosition(component.gameObject.transform, new Vector3(0.26f, 5.91f, -2.6f), 0.75f, 0);
				yield return new WaitForSeconds(0.8f);
				component.GetComponent<Collider>().enabled = true;
				component.gameObject.AddComponent<SineWaveMovement>();
				component.gameObject.GetComponent<SineWaveMovement>().originalPosition = new Vector3(0.26f, 6.41f, -2.6f);
				component.gameObject.GetComponent<SineWaveMovement>().speed = 0.7f;
				component.gameObject.GetComponent<SineWaveMovement>().yMagnitude = 0.5f;
				if (RunState.Run.regionTier == 4)
                {
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("So, you truly wish to release that tyrant..", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("I hope you understand the type of power you are dealing with..", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
				}
				yield break;
			}

			public int i = 0;

			public int card = 0;

			public int cd = 0;

			public int selectingoptions = 3;

			public List<SelectableCard> cardpicked = new List<SelectableCard>();

			public List<SelectableCard> cardpickedfromdeck = new List<SelectableCard>();

			public List<SelectableCard> created = new List<SelectableCard>();
		}

		public class espearaspell : CardChoicesSequencer
		{
			public ConfirmStoneButton confirmStone { get; set; }

			public void upgradeSpell(SelectableCard component)
			{
				base.StartCoroutine(this.upgradeSpellIE(component));
			}
			public IEnumerator upgradeSpellIE(SelectableCard component)
			{
				this.cardpickedfromdeck.Remove(component);
				GameObject table = GameObject.Find("GameTable");
				Tween.Position(component.transform, new Vector3(table.transform.position.x, 14.75f, -1f + table.transform.position.z), 0.15f, 0.1f, null, Tween.LoopType.None, null, null, true);
				yield return new WaitForSeconds(0.2f);
				GameObject.Instantiate(Resources.Load("prefabs\\specialnodesequences\\ConfirmStoneButton")).name = "TESTSTONE";
				GameObject.Find("TESTSTONE").AddComponent<BoxCollider>().size = new Vector3(1.4f, 0.2f, 2.1f);
				GameObject.Find("TESTSTONE").transform.Find("Anim").Find("model").Find("ConfirmButton").Find("Quad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = Tools.getImage("wand_button.png");
				this.confirmStone = GameObject.Find("TESTSTONE").GetComponentInChildren<ConfirmStoneButton>();
				confirmStone.currentHighlightedColor = new Color(0.85f, 0.35f, 0f, 1);
				confirmStone.currentInteractableColor = new Color(1f, 0.5f, 0, 1);
				Tween.Position(GameObject.Find("TESTSTONE").transform, new Vector3(table.transform.position.x, 14.75f, -2.6f + table.transform.position.z), 0.15f, 0.1f, null, Tween.LoopType.None, null, null, true);
				foreach (SelectableCard VARIABLE in this.cardpickedfromdeck)
				{
					VARIABLE.ExitBoard(0.3f, new Vector3(-1f, -1f, 6f));
				}
				List<SelectableCard>.Enumerator enumerator = default(List<SelectableCard>.Enumerator);
				component.gameObject.GetComponent<BoxCollider>().enabled = true;
				component.Initialize(component.Info, new Action<SelectableCard>(this.tookCardWingMan), null, false, null);
				this.confirmStone.Enter();
				yield return this.confirmStone.WaitUntilConfirmation();
				component.coll.enabled = false;
				this.confirmStone.Unpress();
				component.SetCardback(Tools.getImage("magcardback.png"));
				component.Anim.SetFaceDown(true);
				yield return new WaitForSeconds(0.03f);
				CardModificationInfo componentInfoShite = new CardModificationInfo();
				componentInfoShite.healthAdjustment = 1;
				componentInfoShite.nameReplacement = "~" + component.Info.DisplayedNameLocalized + "~";
				if (component.Info.name == "mag_potion") { componentInfoShite.healthAdjustment = 2; }
				if (component.Info.name == "mag_magnusspell") { componentInfoShite.bloodCostAdjustment = 1; }
				RunState.Run.playerDeck.ModifyCard(component.Info, componentInfoShite);
				component.SetInfo(component.Info);
				component.gameObject.GetComponent<TerrainLayout>().ApplyAppearance();
				component.RenderCard();
				component.FaceDown = true;
				AudioController.Instance.PlaySound2D("wizard_cast", MixerGroup.None, 0.5f, 0f, null, null, null, null, false);
				yield return new WaitForSeconds(0.5f);
				AudioController.Instance.PlaySound2D("dueldisk_snap_shut", MixerGroup.None, 0.5f, 0f, null, null, null, null, false);
				upgraded = true;
				component.Anim.SetFaceDown(false);
				component.FaceDown = false;
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Now your spell will last forever..", -2.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
				this.confirmStone.Disable();
				component.coll.enabled = true;
				Tween.Position(GameObject.Find("TESTSTONE").transform, new Vector3(table.transform.position.x - 10f, 30.75f, -2.6f + table.transform.position.z), 0.15f, 0.1f, null, Tween.LoopType.None, null, null, true);
				GameObject.Find("TESTSTONE").GetComponent<BoxCollider>().size = new Vector3(0f, 0f, 0f);
				
				yield break;
			}
			public IEnumerator sequencer(UpgradeSpellNode tradeCardsData)
			{
				Singleton<ViewManager>.Instance.SwitchToView(View.Default);
				CustomTextDisplayerStuff.switchToSpeakerStyle(1);
				this.cardpickedfromdeck = new List<SelectableCard>();
				upgraded = false;
				if (SaveManager.saveFile.ascensionActive && MagnificusMod.Generation.challenges.Contains("FadingMox"))
				{
					Singleton<MagnificusLifeManager>.Instance.playerLife = KayceeStorage.FleetingLife;
				}
				yield return new WaitForSeconds(1.55f);
				GameObject.Find("GameTable").transform.Find("Espeara").transform.localPosition = new Vector3(0, -10f, 36f);
				GameObject.Find("GameTable").transform.Find("Espeara").transform.localScale = new Vector3(5, 0, 5);
				GameObject.Find("GameTable").transform.Find("Espeara").transform.localRotation = Quaternion.Euler(1, 270, 320);
				GameObject.Find("GameTable").transform.Find("Espeara").gameObject.SetActive(true);
				Tween.LocalScale(GameObject.Find("GameTable").transform.Find("Espeara"), new Vector3(5, 6.5f, 5), 0.75f, 0f);
				Tween.LocalScale(GameObject.Find("GameTable").transform.Find("Espeara"), new Vector3(5, 5, 5), 0.2f, 0.751f);
				Tween.LocalRotation(GameObject.Find("GameTable").transform.Find("Espeara"), Quaternion.Euler(1, 270, 400), 0.3f, 0.351f);
				Tween.LocalRotation(GameObject.Find("GameTable").transform.Find("Espeara"), Quaternion.Euler(1, 270, 360), 0.5f, 0.651f);
				yield return new WaitForSeconds(0.25f);
				AudioController.Instance.PlaySound2D("pikespawn", MixerGroup.None, 0.5f, 0f, null, null, null, null, false);
				yield return new WaitForSeconds(0.52f);
				GameObject.Find("GameTable").transform.Find("Espeara").transform.localRotation = Quaternion.Euler(1, 270, 0);
				GameObject.Find("GameTable").transform.Find("Espeara").gameObject.AddComponent<SineWaveRotation>();
				GameObject.Find("GameTable").transform.Find("Espeara").gameObject.GetComponent<SineWaveRotation>().originalRotation = new Vector3(1, 270, 0);
				GameObject.Find("GameTable").transform.Find("Espeara").gameObject.GetComponent<SineWaveRotation>().xMagnitude = -2f;
				GameObject.Find("GameTable").transform.Find("Espeara").gameObject.GetComponent<SineWaveRotation>().speed = 1;
				switch (RunState.Run.regionTier)
				{
					case 2:
						if (!SavedVars.LearnedMechanics.Contains("beatamber") && !SavedVars.LearnedMechanics.Contains("amberf2"))
						{
							SavedVars.LearnedMechanics += "amberf2;";
							yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Oh.. Greetings... I don't believe we've been introduced..", -1f, 0.5f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
							yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("I've been force- er.. asked to train my spellcasting here.", -1f, 0.5f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
							yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Why don't you give me some of your [c:g1]spells[c:]?", -1f, 0.5f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
						}
						else if (!SavedVars.LearnedMechanics.Contains("beatamber") && SavedVars.LearnedMechanics.Contains("amberf2"))
						{
							yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Hm? Oh, hello again.. We still haven't been formally introduced.", -1f, 0.5f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
							yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("I'll need one of your [c:g1]spells[c:] for my training..", -1f, 0.5f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
						}
						else if (!SavedVars.LearnedMechanics.Contains("amberf2"))
						{
							SavedVars.LearnedMechanics += "amberf2;";
							yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Oh.. Hello there.", -1f, 0.5f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
							yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("The master asked me to practice my spellcasting..", -1f, 0.5f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
							yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Why don't you give me some of your [c:g1]spells[c:]?", -1f, 0.5f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
						}
						else
						{
							yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Oh.. Spellcasting. Right..", -1f, 0.5f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
							yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Give me one of your [c:g1]spells[c:].", -1f, 0.5f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
						}
						break;
					case 3:
						if (!SavedVars.LearnedMechanics.Contains("amberf3"))
						{
							SavedVars.LearnedMechanics += "amberf3;";
							yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("What? Oh.. This must be.. [c:g3]his[c:] area..", -1f, 0.5f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
							yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Well, anyway.. The master asked me to train my spellcasting.", -1f, 0.5f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
							yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Why don't you give me some of your [c:g1]spells[c:]?", -1f, 0.5f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
						}
						else
						{
							if (Generation.challenges.Contains("MasterBosses"))
							{
								yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Hmm..?", -1f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Goo, null, true);
								yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Here already? We haven't even battled..", -1f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Goo, null, true);
								yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Well anyways, just hand over a [c:g1]spell[c:].", -1f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Goo, null, true);
							}
							else
							{
								yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Greetings..", -1f, 0.5f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
								yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Give me one of your [c:g1]spells[c:]", -1f, 0.5f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
							}
						}
						break;
					case 1:
						if (!SavedVars.LearnedMechanics.Contains("amberf1"))
						{
							SavedVars.LearnedMechanics += "amberf1;";
							yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Eurgh.. This place is disgusting..", -1f, 0.5f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
							yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Seems like I'm forced to train spellcasting in here.", -1f, 0.5f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
							yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Give me a [c:g1]spell[c:] of yours, and make it quick.", -1f, 0.5f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
							yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Give me a [c:g1]spell[c:] of yours, and make it quick.", -1f, 0.5f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
						}
						else
						{
							yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Greetings..", -1f, 0.5f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
							yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Give me one of your [c:g1]spells[c:]", -1f, 0.5f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
						}
						break;
				}
				Singleton<ViewManager>.Instance.SwitchToView(View.MapDefault, false, true);
				yield return new WaitForSeconds(0.5f);
				this.card = 0;
				List<CardInfo> deck = new List<CardInfo>();
				foreach (CardInfo card in RunState.Run.playerDeck.Cards)
				{
					deck.Add(card);
				}
				int modCount = 0;
				deck.RemoveAll((CardInfo x) => !x.HasTrait(Trait.EatsWarrens) || x.mods.Count > modCount || x.name == "mag_goldspell");
				int dength = deck.Count;
				if (dength > 0)
				{
					GameObject theDeck = Singleton<DeckReviewSequencer>.Instance.gameObject;
					theDeck.transform.parent = GameObject.Find("GameTable").transform;
					theDeck.transform.localPosition = new Vector3(0, 5.01f, -2f);
					theDeck.transform.localScale = new Vector3(1, 1, 1);
					Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(Singleton<DeckReviewSequencer>.Instance.cardArray.SelectCardFrom(deck, null, new Action<SelectableCard>(this.upgradeSpell)));
					for (int i = 0; i < theDeck.transform.childCount; i++)
					{
						this.cardpickedfromdeck.Add(theDeck.transform.GetChild(i).gameObject.GetComponent<SelectableCard>());
					}
				} else
                {
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Oh.. You don't have any spells?", -1f, 0.5f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("I guess I could give you one of my upgraded ones.. Hopefully they're good.", -1f, 0.5f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
					Singleton<ViewManager>.Instance.SwitchToView(View.Choices);
					List<CardInfo> spellCards = new List<CardInfo>();
					foreach (CardInfo carde in CardLoader.allData)
					{
						if (carde.HasTrait(Trait.EatsWarrens) && carde.HasCardMetaCategory(Plugin.SpellPool))
						{
							spellCards.Add(CardLoader.GetCardByName(carde.name));
						}
					}
					List<CardInfo> selectedCards = new List<CardInfo>();
					for (int i = 0; i < 3; i++)
					{
						int selected = Random.RandomRangeInt(0, spellCards.Count);
						CardInfo spell = spellCards[selected];
						CardModificationInfo upgradeSpell = new CardModificationInfo();
						upgradeSpell.nameReplacement = "~" + spell.displayedName + "~";
						upgradeSpell.healthAdjustment = 1;
						spell.mods.Add(upgradeSpell);
						selectedCards.Add(spell);
						spellCards.Remove(spellCards[selected]);
					}
					yield return new WaitForSeconds(0.2f);
					for (int i = 0; i < 3; i++)
					{
						float a = 1.5f;
						a *= i;
						yield return new WaitForSeconds(Time.deltaTime);
						yield return new WaitForSeconds(Time.deltaTime);
						GameObject gameObject = GameObject.Instantiate<GameObject>(Singleton<SelectableCardArray>.Instance.selectableCardPrefab);
						gameObject.transform.SetParent(base.transform);
						SelectableCard component = gameObject.GetComponent<SelectableCard>();
						component.Anim.SetFaceDown(true);
						component.Initialize(selectedCards[i], new Action<SelectableCard>(Singleton<SelectableCardArray>.Instance.OnCardSelected), null, false, new Action<SelectableCard>(Singleton<SelectableCardArray>.Instance.OnCardInspected));
						component.SetEnabled(false);
						component.Anim.PlayQuickRiffleSound();
						component.Initialize(selectedCards[i], new Action<SelectableCard>(this.cardpickingupscropt), null, false, null);
						yield return new WaitForSeconds(Time.deltaTime);
						component.GetComponent<Collider>().enabled = true;
						Singleton<SelectableCardArray>.Instance.displayedCards.Add(component);
						component.Anim.SetFaceDown(true);
						component.SetCardback(Tools.getImage("magcardback.png"));
						yield return new WaitForSeconds(0.1f);
						Singleton<SelectableCardArray>.Instance.TweenInCard(component.transform, new Vector3(-1.5f + a, 5.03f, -1.5f), 0, true);
						yield return new WaitForSeconds(Time.deltaTime * 0f);
						this.cardpickedfromdeck.Add(component);
						yield return new WaitForSeconds(Time.deltaTime);
						this.cd++;
						gameObject = null;
						component = null;
					}
				}
				yield break;
			}
			public static IEnumerator NodeOutroSequence()
			{
				GameObject npc = GameObject.Find("Espeara");
				Tween.LocalPosition(npc.transform, new Vector3(0, -37f, 36f), 3.75f, 0.375f);
				Tween.Rotation(npc.transform, Quaternion.Euler(0, 0, 0), 4f, 0.375f);
				yield return new WaitForSeconds(4.5f);
				npc.SetActive(false);
				yield break;
			}

			public void cardpickingupscropt(SelectableCard component)
			{
				if (component.Anim.FaceDown)
				{
					component.Anim.SetFaceDown(false);
					if (!string.IsNullOrEmpty(component.Info.description) && !ProgressionData.IntroducedCard(component.Info))
					{
						ProgressionData.SetCardIntroduced(component.Info);
					}
				}
				else
				{
					upgraded = true;
					RunState.Run.playerDeck.AddCard(component.Info);
					cardpickedfromdeck.Remove(component);
					foreach (SelectableCard component2 in cardpickedfromdeck)
					{
						if (component2 != component)
						{
							component2.ExitBoard(0.3f, new Vector3(0f, 0f, 6f));
						}
						
					}
					base.StartCoroutine(tookCard(component));
				}

			}

			public void tookCardWingMan(SelectableCard component)
			{
				base.StartCoroutine(tookCard(component));
			}

			public IEnumerator tookCard(SelectableCard component)
			{
				if (!component.FaceDown)
				if (!upgraded)
                {
					Destroy(GameObject.Find("TESTSTONE"));
					component.ExitBoard(0.3f, new Vector3(0f, 0f, 6f));
					yield return new WaitForSeconds(0.25f);
					Singleton<ViewManager>.Instance.SwitchToView(View.MapDefault, false, true);
					this.cardpickedfromdeck = new List<SelectableCard>();
					List<CardInfo> deck = new List<CardInfo>();
					foreach (CardInfo card in RunState.Run.playerDeck.Cards)
					{
						deck.Add(card);
					}
					deck.RemoveAll((CardInfo x) => !x.HasTrait(Trait.EatsWarrens) || x.mods.Count > 0);
					GameObject theDeck = Singleton<DeckReviewSequencer>.Instance.gameObject;
					theDeck.transform.parent = GameObject.Find("GameTable").transform;
					theDeck.transform.localPosition = new Vector3(0, 5.01f, -2f);
					theDeck.transform.localScale = new Vector3(1, 1, 1);
					Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(Singleton<DeckReviewSequencer>.Instance.cardArray.SelectCardFrom(deck, null, new Action<SelectableCard>(this.upgradeSpell)));
					for (int i = 0; i < theDeck.transform.childCount; i++)
					{
						this.cardpickedfromdeck.Add(theDeck.transform.GetChild(i).gameObject.GetComponent<SelectableCard>());
					}
					yield break;
				}
				component.Anim.SetFaceDown(true);
				Tween.LocalPosition(component.transform, new Vector3(0, 5.65f, -2f), 0.1f, 0);
				yield return new WaitForSeconds(0.5f);
				Tween.LocalPosition(component.transform, new Vector3(0, 15f, 5f), 0.35f, 0);
				yield return new WaitForSeconds(0.36f);
				component.ExitBoard(0.3f, new Vector3(0f, 0f, -6f));
				Singleton<ViewManager>.Instance.SwitchToView(View.Default, false, true);
				CustomTextDisplayerStuff.switchToSpeakerStyle(0);
				yield return NodeOutroSequence();
				bool flag3 = Singleton<GameFlowManager>.Instance != null;
				if (flag3)
				{
					Singleton<GameFlowManager>.Instance.TransitionToGameState(GameState.Map, null);
				}
				SaveManager.SaveToFile(true);
				yield break;
			}

			public static bool upgraded = false;


			public int i = 0;

			public int card = 0;

			public int cd = 0;

			public int selectingoptions = 3;

			public List<SelectableCard> cardpicked = new List<SelectableCard>();

			public List<SelectableCard> cardpickedfromdeck = new List<SelectableCard>();

			public List<SelectableCard> created = new List<SelectableCard>();
		}

		public class changecost : CardChoicesSequencer
		{
			public ConfirmStoneButton confirmStone { get; set; }

			public void removeselectablecardfromdeck(SelectableCard component)
			{
				base.StartCoroutine(this.removeselectablecardfromdeckie(component));
			}

			public void cardpickingupscropt(SelectableCard component)
			{
				bool flag = !component.Anim.FaceDown;
				if (flag)
				{
					bool flag2 = this.done;
					if (flag2)
					{
						GameObject.Find("TESTSTONE").GetComponent<BoxCollider>().size = new Vector3(0f, 0f, 0f);
						GameObject.Find("TESTSTONE").SetActive(false);
						component.ExitBoard(0.3f, new Vector3(-1f, -1f, 6f));
						Singleton<ViewManager>.Instance.SwitchToView(View.Default, false, true);
						this.confirmStone.Exit();
						bool flag3 = Singleton<GameFlowManager>.Instance != null;
						if (flag3)
						{
							Singleton<GameFlowManager>.Instance.TransitionToGameState(GameState.Map, null);
						}
						SaveManager.SaveToFile(true);
					}
					else
					{
						Singleton<ViewManager>.Instance.SwitchToView(View.Choices, false, true);
						component.ExitBoard(0.3f, new Vector3(-1f, -1f, 6f));
						GameObject.Find("TESTSTONE").GetComponent<BoxCollider>().size = new Vector3(0f, 0f, 0f);
						Destroy(GameObject.Find("TESTSTONE"));
						List<CardInfo> listOfCards = new List<CardInfo>();
						foreach (CardInfo card in RunState.Run.playerDeck.Cards)
						{
							listOfCards.Add(card);
						}
						listOfCards.RemoveAll((CardInfo x) => x.SpecialAbilities.Contains(SpecialTriggeredAbility.RandomCard) || x.traits.Contains(Trait.Pelt) || x.traits.Contains(Trait.EatsWarrens));
						listOfCards.RemoveAll((CardInfo x) => x.gemsCost.Count < 1);
						listOfCards.RemoveAll((CardInfo x) => x.gemsCost.Count > 2);
						GameObject theDeck = Singleton<DeckReviewSequencer>.Instance.gameObject;
						theDeck.transform.parent = GameObject.Find("GameTable").transform;
						theDeck.transform.localPosition = new Vector3(0, 5.01f, -2f);
						Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(Singleton<DeckReviewSequencer>.Instance.cardArray.SelectCardFrom(listOfCards, null, new Action<SelectableCard>(this.removeselectablecardfromdeck)));
						for (int i = 0; i < theDeck.transform.childCount; i++)
						{
							this.cardpickedfromdeck.Add(theDeck.transform.GetChild(i).gameObject.GetComponent<SelectableCard>());
						}
					}
				}
			}

			public IEnumerator removeselectablecardfromdeckie(SelectableCard component)
			{
				this.cardpickedfromdeck.Remove(component);
				this.cd = 0;
				GameObject table = GameObject.Find("GameTable");
				Tween.Position(component.transform, new Vector3(table.transform.position.x, 14.75f, -1f + table.transform.position.z), 0.15f, 0.1f, null, Tween.LoopType.None, null, null, true);
				yield return new WaitForSeconds(0.2f);
				GameObject.Instantiate(Resources.Load("prefabs\\specialnodesequences\\ConfirmStoneButton")).name = "TESTSTONE";
				GameObject.Find("TESTSTONE").AddComponent<BoxCollider>().size = new Vector3(1.4f, 0.2f, 2.1f);
				this.confirmStone = GameObject.Find("TESTSTONE").GetComponentInChildren<ConfirmStoneButton>();
				GameObject.Find("TESTSTONE").transform.position = new Vector3(table.transform.position.x, 25.75f, -2.6f + table.transform.position.z);
				Tween.Position(GameObject.Find("TESTSTONE").transform, new Vector3(table.transform.position.x, 14.75f, -2.6f + table.transform.position.z), 0.35f, 0.1f, null, Tween.LoopType.None, null, null, true);
				GameObject.Find("TESTSTONE").transform.Find("Anim").Find("model").Find("ConfirmButton").Find("Quad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = (Resources.Load("art/cards/copycard_button") as Texture2D);
				Color gemColor = new Color(1, 1, 1, 1);
				Color gemColor2 = new Color(1, 1, 1, 1);
				switch (component.Info.gemsCost[0])
				{
					case GemType.Green:
						gemColor = new Color(0, 0.5f, 1, 1);
						gemColor2 = new Color(0, 0.25f, 0.75f, 1);
						break;
					case GemType.Blue:
						gemColor = new Color(1, 0.5f, 0, 1);
						gemColor2 = new Color(0.75f, 0.25f, 0, 1);
						break;
					case GemType.Orange:
						gemColor = new Color(0, 1f, 0f, 1);
						gemColor2 = new Color(0, 0.75f, 0f, 1);
						break;
				}
				GameObject.Find("TESTSTONE").transform.Find("Anim").Find("model").Find("ConfirmButton").gameObject.GetComponent<ConfirmStoneButton>().defaultColor = gemColor2;
				GameObject.Find("TESTSTONE").transform.Find("Anim").Find("model").Find("ConfirmButton").gameObject.GetComponent<ConfirmStoneButton>().currentInteractableColor = gemColor2;
				GameObject.Find("TESTSTONE").transform.Find("Anim").Find("model").Find("ConfirmButton").gameObject.GetComponent<ConfirmStoneButton>().highlightedColor = gemColor;
				foreach (SelectableCard VARIABLE in this.cardpickedfromdeck)
				{
					VARIABLE.ExitBoard(0.3f, new Vector3(-1f, -1f, 6f));
				}
				component.gameObject.GetComponent<BoxCollider>().enabled = true;
				component.Initialize(component.Info, new Action<SelectableCard>(this.cardpickingupscropt), null, false, null);
				component.SetCardback(Tools.getImage("magcardback.png"));
				this.confirmStone.Enter();
				yield return this.confirmStone.WaitUntilConfirmation();
				CardModificationInfo cardModificationInfo = new CardModificationInfo();
				List<GemType> noCost = new List<GemType>();
				bool flag = component.Info.name == "mag_BellMage" && component.Info.HasModFromCardMerge();
				if (flag)
				{
					List<Texture> nothin = new List<Texture>();
					component.Info.gemsCost = noCost;
					component.Info.decals = nothin;
					cardModificationInfo.bloodCostAdjustment = 1;
					nothin = null;
				}
				bool flag2 = component.Info.gemsCost.Count > 0;
				if (flag2)
				{
					List<GemType> orange = new List<GemType>();
					orange.Add(GemType.Orange);
					List<GemType> green = new List<GemType>();
					green.Add(GemType.Green);
					List<GemType> blue = new List<GemType>();
					blue.Add(GemType.Blue);
					bool flag3 = component.Info.gemsCost.Count == 2;
					if (flag3)
					{
						orange.Add(GemType.Green);
						green.Add(GemType.Blue);
						blue.Add(GemType.Orange);
					}
					cardModificationInfo.nullifyGemsCost = true;
					if (component.Info.gemsCost.Count == 1)
					{
						switch (component.Info.gemsCost[0])
						{
							case GemType.Green:
								cardModificationInfo.addGemCost = blue;
								break;
							case GemType.Blue:
								cardModificationInfo.addGemCost = orange;
								break;
							case GemType.Orange:
								cardModificationInfo.addGemCost = green;
								break;
						}
					}
					else
					{
						if (component.Info.gemsCost.Contains(GemType.Green) && component.Info.gemsCost.Contains(GemType.Orange))
						{
							cardModificationInfo.addGemCost = blue;
						}
						else if (component.Info.gemsCost.Contains(GemType.Blue) && component.Info.gemsCost.Contains(GemType.Orange))
						{
							cardModificationInfo.addGemCost = green;
						}
						else if (component.Info.gemsCost.Contains(GemType.Blue) && component.Info.gemsCost.Contains(GemType.Green))
						{
							cardModificationInfo.addGemCost = orange;
						}

						if (component.Info.gemsCost[0] == component.Info.gemsCost[1])
						{
							GemType doubleC = component.Info.gemsCost[0];
							switch (doubleC)
							{
								case GemType.Green:
									cardModificationInfo.addGemCost = new List<GemType> { GemType.Blue, GemType.Blue };
									break;
								case GemType.Blue:
									cardModificationInfo.addGemCost = new List<GemType> { GemType.Orange, GemType.Orange };
									break;
								case GemType.Orange:
									cardModificationInfo.addGemCost = new List<GemType> { GemType.Green, GemType.Green };
									break;
							}
						}

					}
				}
				component.Anim.SetFaceDown(true, false);
				yield return new WaitForSeconds(0.25f);
				RunState.Run.playerDeck.ModifyCard(component.Info, cardModificationInfo);
				component.SetInfo(component.Info);
				component.Anim.FaceDown = true;
				AudioController.Instance.PlaySound2D("magnificus_brush_splatter_bleach", MixerGroup.None, 0.5f, 0f, null, null, null, null, false);
				yield return new WaitForSeconds(0.25f);
				AudioController.Instance.PlaySound2D("magnificus_brush_splatter_color", MixerGroup.None, 0.5f, 0f, null, null, null, null, false);
				component.Anim.SetFaceDown(false, false);
				this.done = true;
				component.Anim.FaceDown = false;
				yield return new WaitForSeconds(0.25f);
				base.StartCoroutine(Singleton<TextDisplayer>.Instance.ShowUntilInput("Your card's cost has been changed..", -2.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true));
				this.confirmStone.Disable();
				yield break;
			}

			public IEnumerator sequencer(CustomNode1 tradeCardsData)
			{
				this.done = false;
				GameObject.Find("Player").GetComponentInChildren<ViewManager>().SwitchToView(View.Choices, false, false);
				yield return new WaitForSeconds(1f);
				List<CardInfo> listOfCards = new List<CardInfo>();
				foreach (CardInfo card in RunState.Run.playerDeck.Cards)
				{
					listOfCards.Add(card);
				}
				listOfCards.RemoveAll((CardInfo x) => x.SpecialAbilities.Contains(SpecialTriggeredAbility.RandomCard) || x.traits.Contains(Trait.Pelt) || x.traits.Contains(Trait.EatsWarrens));
				listOfCards.RemoveAll((CardInfo x) => x.gemsCost.Count < 1);
				listOfCards.RemoveAll((CardInfo x) => x.gemsCost.Count > 2);
				GameObject theDeck = Singleton<DeckReviewSequencer>.Instance.gameObject;
				theDeck.transform.parent = GameObject.Find("GameTable").transform;
				theDeck.transform.localPosition = new Vector3(0, 5.01f, -2f);
				theDeck.transform.localScale = new Vector3(1, 1, 1);
				Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(Singleton<DeckReviewSequencer>.Instance.cardArray.SelectCardFrom(listOfCards, null, new Action<SelectableCard>(this.removeselectablecardfromdeck)));
				for (int i = 0; i < theDeck.transform.childCount; i++)
				{
					this.cardpickedfromdeck.Add(theDeck.transform.GetChild(i).gameObject.GetComponent<SelectableCard>());
				}
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Do you have a card that has a cost you are unsatisfied with?", -2.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
				if (listOfCards.Count < 1)
				{
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("No. It appears not.", -2.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
					Singleton<GameFlowManager>.Instance.TransitionToGameState(GameState.Map, null);
				}
				yield break;
			}

			public int i = 0;

			public int cd = 0;

			public int card = 0;

			public int selectingoptions = 3;

			public List<SelectableCard> cardpicked = new List<SelectableCard>();

			public List<SelectableCard> cardpickedfromdeck = new List<SelectableCard>();

			public List<SelectableCard> created = new List<SelectableCard>();

			public bool done = false;
		}

		public class cauldron : CardChoicesSequencer
		{
			public ConfirmStoneButton confirmStone { get; set; }

			bool done = false;

			bool doing = false;
			public void removeselectablecardfromdeck(SelectableCard component)
			{
				base.StartCoroutine(this.removeselectablecardfromdeckie(component, true));
			}
			public IEnumerator WaitThenDisable(GameObject whotokill, float wait)
			{
				yield return new WaitForSeconds(wait);
				whotokill.SetActive(false);
				yield break;
			}

			public IEnumerator NodeOutroSequence()
			{
				CustomTextDisplayerStuff.switchToSpeakerStyle(0);
				GameObject npc = GameObject.Find("LonelyMage");
				Tween.LocalScale(npc.transform.GetChild(2).GetChild(0).GetChild(0).GetChild(1).Find("LeftEye"), new Vector3(1, 1, 0), 3, 1f);
				Tween.LocalScale(npc.transform.GetChild(2).GetChild(0).GetChild(0).GetChild(2).Find("RightEye"), new Vector3(-1, 0, -1), 3, 1f);
				Tween.LocalPosition(npc.transform, new Vector3(0, -7, 15), 1, 4);

				for (int i = 0; i < 100; i++)
				{
					npc.GetComponent<Animator>().speed = 1 - (i / 100f);
					yield return new WaitForSeconds(0.01f);
				}
				yield return new WaitForSeconds(4.5f);
				CustomTextDisplayerStuff.switchToSpeakerStyle(0);
				npc.SetActive(false);
				
				Singleton<GameFlowManager>.Instance.TransitionToGameState(GameState.Map, null);

				GameObject.Destroy(GameObject.Find("EventCauldron"));
				yield break;
			}

			public void tradeCard(SelectableCard component)
			{
				Singleton<ViewManager>.Instance.SwitchToView(View.Default);
				component.ExitBoard(0.3f, new Vector3(0f, 0f, -6f));
				potion.ExitBoard(0.3f, new Vector3(0f, 0f, -6f));
				RunState.Run.playerDeck.RemoveCard(component.Info);
				Tween.LocalPosition(Singleton<DeckSpellBook>.Instance.transform, new Vector3(0.75f, 5.65f, -7f), 0.55f, 0.35f, Tween.EaseInOut);
				base.StartCoroutine(this.NodeOutroSequence());
			}

			public void cardpickingupscropt(SelectableCard component)
			{
				if (doing) { return; }
				if (done)
				{
					this.confirmStone.Exit();
					Destroy(GameObject.Find("TESTSTONE"));

					if (RunState.Run.playerDeck.Cards.FindAll((CardInfo x) => x.HasTrait(Trait.EatsWarrens)).Count >= ((SaveManager.saveFile.ascensionActive && Generation.challenges.Contains("SmallSpellbook")) ? 4 : 8))
					{
						base.StartCoroutine(tradeSequence(component));
						return;
					}

					choice2.gameObject.GetComponent<SineWaveMovement>().enabled = false;
					choice2.ExitBoard(0.3f, new Vector3(-1f, -1f, 6f));



					base.StartCoroutine(this.NodeOutroSequence());
				}
				else
				{
					cardsChosen = 0;
					if (choice1 != null)
					{
						choice1.gameObject.GetComponent<SineWaveMovement>().enabled = false;
						choice1.ExitBoard(0.3f, new Vector3(-1f, -1f, 6f));
					}

					choice2.gameObject.GetComponent<SineWaveMovement>().enabled = false;
					choice2.ExitBoard(0.3f, new Vector3(-1f, -1f, 6f));

					Destroy(GameObject.Find("TESTSTONE"));

					int num = RunState.Run.playerDeck.Cards.Count;
					Singleton<ViewManager>.Instance.SwitchToView(View.MapDefault, false, true);
					base.StartCoroutine(spawnCards());
				}
			}

			public SelectableCard potion;

			public IEnumerator tradeSequence(SelectableCard component)
			{
				Vector3 savePosition = component.transform.position;
				component.transform.parent = GameObject.Find("GameTable").transform;
				component.transform.position = savePosition;
				component.coll.enabled = false;

				Tween.LocalPosition(GameObject.Find("EventCauldron").transform, new Vector3(0.0327f, 5.88f, 3f), 1f, 0);

				GameObject spellBook = new GameObject("DeckSpellBook");
				spellBook.gameObject.AddComponent<MagnificusMod.DeckSpellBook>();
				spellBook.transform.parent = GameObject.Find("GameTable").transform;
				spellBook.transform.localPosition = new Vector3(4.5f, 27.5f, 3f);
				spellBook.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
				spellBook.transform.localRotation = Quaternion.Euler(65, 358, 0);

				spellBook.GetComponent<DeckSpellBook>().initializeItems();
				Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(spellBook.GetComponent<DeckSpellBook>().initialize(new Vector3(0f, 5.65f, 3.5f), 0.1f, false));
				spellBook.GetComponent<DeckSpellBook>().refreshSpellBookCards(RunState.Run.playerDeck.Cards.FindAll((CardInfo x) => x.HasTrait(Trait.EatsWarrens)));

				CustomTextDisplayerStuff.switchToSpeakerStyle(2);
				Singleton<ViewManager>.Instance.SwitchToView(View.TradingTopDown);
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("WAIT!! YOUR SPELLBOOK IS FULL", -0.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
				Tween.LocalPosition(component.transform, new Vector3(-1.8f, 5.75f, -2.15f), 0.13f, 0f, Tween.EaseInOut);
				Tween.LocalRotation(component.transform, Quaternion.Euler(90, 0, 0), 0.13f, 0);
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("GET RID OF ONE OF YOUR SPELLS, OR YOU WONT BE ABLE TO TAKE OUR POTION!!", -0.25f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
				yield return new WaitForSeconds(0.15f);
				Tween.LocalPosition(Singleton<DeckSpellBook>.Instance.transform, new Vector3(0.75f, 5.65f, -1.75f), 0.35f, 0.15f, Tween.EaseIn);
				yield return new WaitForSeconds(0.35f);

				GameObject spellCards = Singleton<DeckSpellBook>.Instance.transform.Find("selectableSpells").gameObject;
				potion = component;
				component.coll.enabled = false;
				for (int i = 0; i < spellCards.transform.childCount; i++)
				{
					SelectableCard component2 = spellCards.transform.GetChild(i).gameObject.GetComponent<SelectableCard>();

					component2.Initialize(component2.Info, new Action<SelectableCard>(this.tradeCard), null, false, null);
				}

				yield break;
			}

			public IEnumerator spawnCards()
            {


                List<CardInfo> deck = new List<CardInfo>();

                string text = File.ReadAllText(SaveManager.SaveFolderPath + "MagnificusModSave.gwsave");
                string[] array3 = text.Split(new char[]
                {
                                    'R'
                });
                array3 = array3[1].Split(new char[]
                {
                                    ','
                });
                for (int j = 0; j < int.Parse(array3[0]); j++)
                {
                    CardInfo cardByName = CardLoader.GetCardByName("MoxRuby");
                    deck.Add(cardByName);
                }
                for (int k = 0; k < int.Parse(array3[1]); k++)
                {
                    CardInfo cardByName2 = CardLoader.GetCardByName("MoxEmerald");
                    deck.Add(cardByName2);
                }
                for (int l = 0; l < int.Parse(array3[2]); l++)
                {
                    CardInfo cardByName3 = CardLoader.GetCardByName("MoxSapphire");
                    deck.Add(cardByName3);
                }

				deck.RemoveAll((CardInfo x) => x.Abilities.Count > 1);

				Tween.LocalPosition(GameObject.Find("EventCauldron").transform, new Vector3(0, 5.88f, 2.5f), 0.5f, 0);

				GameObject theDeck = Singleton<DeckReviewSequencer>.Instance.gameObject;
				theDeck.transform.parent = GameObject.Find("GameTable").transform;
				theDeck.transform.localPosition = new Vector3(0, 5.01f, -1f);
				theDeck.transform.localScale = new Vector3(1, 1, 1);
				Singleton<DeckReviewSequencer>.Instance.cardArray.InitializeGamepadGrid();
				yield return Singleton<DeckReviewSequencer>.Instance.cardArray.SpawnAndPlaceCards(deck, null, 2, false, true);
				yield return new WaitForSeconds(0.15f);
				Singleton<DeckReviewSequencer>.Instance.cardArray.SetCardsEnabled(true);
				Singleton<DeckReviewSequencer>.Instance.cardArray.selectedCard = null;
				for (int i = 0; i < theDeck.transform.childCount; i++)
				{
					this.cardpickedfromdeck.Add(theDeck.transform.GetChild(i).gameObject.GetComponent<SelectableCard>());
					theDeck.transform.GetChild(i).gameObject.GetComponent<SelectableCard>().CursorEntered = null;
				}
				yield return new WaitUntil(() => Singleton<DeckReviewSequencer>.Instance.cardArray.selectedCard != null);
				if (Singleton<DeckReviewSequencer>.Instance.cardArray.selectedCard != null)
				{
					Singleton<DeckReviewSequencer>.Instance.cardArray.displayedCards.Remove(Singleton<DeckReviewSequencer>.Instance.cardArray.selectedCard);
					Singleton<DeckReviewSequencer>.Instance.cardArray.selectedCard.SetLocalPosition(Vector3.zero, 30f, false);
				}
				if (Singleton<DeckReviewSequencer>.Instance.cardArray.selectedCard != null)
				{
					deck.Remove(Singleton<DeckReviewSequencer>.Instance.cardArray.selectedCard.Info);
					new Action<SelectableCard>(this.removeselectablecardfromdeck)(Singleton<DeckReviewSequencer>.Instance.cardArray.selectedCard);
				}
				Singleton<DeckReviewSequencer>.Instance.cardArray.selectedCard = null;
				for (int i = 0; i < theDeck.transform.childCount; i++)
				{
					theDeck.transform.GetChild(i).gameObject.GetComponent<SelectableCard>().CursorEntered = null;
				}
				yield return new WaitUntil(() => Singleton<DeckReviewSequencer>.Instance.cardArray.selectedCard != null);
				Singleton<DeckReviewSequencer>.Instance.cardArray.SetCardsEnabled(false);
				if (Singleton<DeckReviewSequencer>.Instance.cardArray.selectedCard != null)
				{
					Singleton<DeckReviewSequencer>.Instance.cardArray.displayedCards.Remove(Singleton<DeckReviewSequencer>.Instance.cardArray.selectedCard);
					Singleton<DeckReviewSequencer>.Instance.cardArray.selectedCard.SetLocalPosition(Vector3.zero, 30f, false);
				}
				yield return Singleton<DeckReviewSequencer>.Instance.cardArray.CleanUpCards();
				if (Singleton<DeckReviewSequencer>.Instance.cardArray.selectedCard != null)
				{
					deck.Remove(Singleton<DeckReviewSequencer>.Instance.cardArray.selectedCard.Info);
					new Action<SelectableCard>(this.removeselectablecardfromdeck)(Singleton<DeckReviewSequencer>.Instance.cardArray.selectedCard);
				}
				yield break;
			}

			public static SelectableCard choice1;
			public static SelectableCard choice2;

			public IEnumerator removeselectablecardfromdeckie(SelectableCard component, bool run)
			{
				if (cardsChosen < 1)
                {
					cardsChosen++;
					choice1 = component;
					component.gameObject.GetComponent<BoxCollider>().size = new Vector3(0, 0, 0);
					Tween.LocalPosition(component.transform, new Vector3(0, 2.6f, 1), 0.25f, 0);
					yield return new WaitForSeconds(0.25f);
					Tween.Rotation(component.transform, Quaternion.Euler(0, 0, 0), 0.15f, 0);
					yield return new WaitForSeconds(0.15f);
					Tween.LocalPosition(component.transform, new Vector3(0, 2.6f, 3.75f), 0.25f, 0);
					yield return new WaitForSeconds(0.25f);
					Tween.LocalScale(component.transform, new Vector3(0.75f, 0.75f, 0.75f), 0.1f, 0.1f);
					Tween.LocalPosition(component.transform, new Vector3(0, 0f, 3.75f), 0.15f, 0);
					yield return new WaitForSeconds(0.25f);
					component.transform.parent = GameObject.Find("EventCauldron").transform;
					Tween.LocalPosition(component.transform, new Vector3(-0.26f, 1f, -0.28f), 0.35f, 0);
					component.transform.rotation = Quaternion.Euler(10, 22.5f, 357.25f);
					yield return new WaitForSeconds(0.35f);
					component.gameObject.AddComponent<SineWaveMovement>().originalPosition = new Vector3(-0.26f, 0.8f, -0.28f);
					component.gameObject.GetComponent<SineWaveMovement>().speed = 0.5f;
					component.gameObject.GetComponent<SineWaveMovement>().yMagnitude = 0.2f;
					yield break;
				} else
                {
					choice2 = component;
					Tween.LocalPosition(component.transform, new Vector3(0, 2.6f, 1), 0.25f, 0);
					yield return new WaitForSeconds(0.25f);
					Tween.Rotation(component.transform, Quaternion.Euler(0, 0, 0), 0.15f, 0);
					yield return new WaitForSeconds(0.15f);
					Tween.LocalPosition(component.transform, new Vector3(0, 2.6f, 3.75f), 0.25f, 0);
					yield return new WaitForSeconds(0.25f);
					Tween.LocalScale(component.transform, new Vector3(0.75f, 0.75f, 0.75f), 0.1f, 0.1f);
					Tween.LocalPosition(component.transform, new Vector3(0, 0f, 3.75f), 0.15f, 0);
					yield return new WaitForSeconds(0.25f);
					component.transform.parent = GameObject.Find("EventCauldron").transform;
					Tween.LocalPosition(component.transform, new Vector3(0.14f, 1.13f, 0.25f), 0.25f, 0);
					component.transform.rotation = Quaternion.Euler(9.9f, 337.5f, 356.1f);
					yield return new WaitForSeconds(0.25f);
					component.gameObject.AddComponent<SineWaveMovement>().originalPosition = new Vector3(0.14f, 0.93f, 0.25f);
					component.gameObject.GetComponent<SineWaveMovement>().speed = 0.5f;
					component.gameObject.GetComponent<SineWaveMovement>().yMagnitude = 0.2f;
					Tween.LocalPosition(GameObject.Find("EventCauldron").transform, new Vector3(0f, 5.88f, -0.5f), 0.75f, 0);
					component.gameObject.GetComponent<BoxCollider>().enabled = true;
					component.Initialize(component.Info, new Action<SelectableCard>(this.cardpickingupscropt), null, false, null);
				}
				GameObject.Instantiate(Resources.Load("prefabs\\specialnodesequences\\ConfirmStoneButton")).name = "TESTSTONE";
				GameObject.Find("TESTSTONE").AddComponent<BoxCollider>().size = new Vector3(1.4f, 0.2f, 2.1f);
				this.confirmStone = GameObject.Find("TESTSTONE").GetComponentInChildren<ConfirmStoneButton>();
				GameObject.Find("TESTSTONE").transform.Find("Anim").Find("model").Find("ConfirmButton").Find("Quad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = Tools.getImage("wand_button.png");
				GameObject.Find("TESTSTONE").transform.parent = GameObject.Find("GameTable").transform;
				Tween.LocalPosition(GameObject.Find("TESTSTONE").transform, new Vector3(0, 5.03f, -2.6f), 0.15f, 0.1f, null, Tween.LoopType.None, null, null, true);
				this.confirmStone.Enter();
				yield return this.confirmStone.WaitUntilConfirmation();
				component.gameObject.GetComponent<BoxCollider>().enabled = false;
				choice1.gameObject.GetComponent<SineWaveMovement>().enabled = false;
				Tween.LocalPosition(choice1.transform, new Vector3(-0.26f, -0.25f, -0.28f), 0.3f, 0);
				choice2.gameObject.GetComponent<SineWaveMovement>().enabled = false;
				Tween.LocalPosition(choice2.transform, new Vector3(0.14f, -0.25f, 0.25f), 0.3f, 0);
				yield return new WaitForSeconds(0.3f);
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("NOW ITS TIME FOR ME TO PRACTICE MY MIXING MAGICKS!!", -0.5f, 0f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);

				Tween.LocalRotation(GameObject.Find("EventCauldron").transform, Quaternion.Euler(0, 180, 10), 0.2f, 0);
				Tween.Shake(GameObject.Find("EventCauldron").transform, GameObject.Find("EventCauldron").transform.localPosition, new Vector3(0.3f, 0f, 0.25f), 1.5f, 0.1f);
				AudioController.Instance.PlaySound2D("card_attack_creature", MixerGroup.None, 0.5f, 0f, null, null, null, null, false);
				AudioController.Instance.PlaySound2D("card_attack_damage", MixerGroup.None, 0.5f, 0f, null, null, null, null, false);
				yield return new WaitForSeconds(0.5f);
				AudioController.Instance.PlaySound2D("sacrifice_mark", MixerGroup.None, 0.5f, 0f, null, null, null, null, false);
				AudioController.Instance.PlaySound2D("card_attack_directly", MixerGroup.None, 0.5f, 0f, null, null, null, null, false);
				yield return new WaitForSeconds(0.5f);
				AudioController.Instance.PlaySound2D("wizard_projectileimpact", MixerGroup.None, 0.5f, 0f, null, null, null, null, false);
				Tween.LocalRotation(GameObject.Find("EventCauldron").transform, Quaternion.Euler(0, 180, 350), 0.2f, 0);
				Tween.Shake(GameObject.Find("EventCauldron").transform, GameObject.Find("EventCauldron").transform.localPosition, new Vector3(0.25f, 0f, 0.3f), 1.5f, 0.1f);
				yield return new WaitForSeconds(0.3f);
				AudioController.Instance.PlaySound2D("camera_pickup", MixerGroup.None, 0.5f, 0f, null, null, null, null, false);
				yield return new WaitForSeconds(0.3f);
				AudioController.Instance.PlaySound2D("giant_arm_retracting", MixerGroup.None, 0.5f, 0f, null, null, null, null, false);
				yield return new WaitForSeconds(0.4f);
				AudioController.Instance.PlaySound2D("wizard_cast", MixerGroup.None, 0.5f, 0f, null, null, null, null, false);
				yield return new WaitForSeconds(0.3f);
				AudioController.Instance.PlaySound2D("dueldisk_card_played", MixerGroup.None, 0.5f, 0f, null, null, null, null, false);
				yield return new WaitForSeconds(0.3f);
				Tween.LocalRotation(GameObject.Find("EventCauldron").transform, Quaternion.Euler(0, 180, 0), 0.2f, 0);
				yield return new WaitForSeconds(0.6f);
				Tween.LocalPosition(component.transform, new Vector3(0,-0.25f, 0.15f), 0.1f, 0);
				Tween.LocalRotation(component.transform, Quaternion.Euler(0, 180, 0), 0.1f, 0);

				if (choice2.Info.HasAbility(Ability.GainGemOrange)) { MagCurrentNode.editSideDeck(-1, 0, 0); }
				else if (choice2.Info.HasAbility(Ability.GainGemGreen)) { MagCurrentNode.editSideDeck(0, -1, 0); }
				else if (choice2.Info.HasAbility(Ability.GainGemBlue)) { MagCurrentNode.editSideDeck(0, 0, -1); }

                File.WriteAllText(SaveManager.SaveFolderPath + "MagnificusModSave.gwsave", SaveManager.ToJSON(MagCurrentNode.GetNodeStuff(false, true)));
				
                CardInfo potion = CardLoader.GetCardByName(choice1.Info.name);
				CardModificationInfo potionMod = new CardModificationInfo();

				string nameReplacement = "";

				if (choice1.Info.HasAbility(Ability.GainGemGreen) || choice2.Info.HasAbility(Ability.GainGemGreen) && (choice1.Info.HasAbility(Ability.GainGemOrange) || choice2.Info.HasAbility(Ability.GainGemOrange))) { nameReplacement = "Goranj"; }
                if (choice1.Info.HasAbility(Ability.GainGemOrange) || choice2.Info.HasAbility(Ability.GainGemOrange) && (choice1.Info.HasAbility(Ability.GainGemBlue) || choice2.Info.HasAbility(Ability.GainGemBlue))) { nameReplacement = "Orlu"; }
                if (choice1.Info.HasAbility(Ability.GainGemBlue) || choice2.Info.HasAbility(Ability.GainGemBlue) && (choice1.Info.HasAbility(Ability.GainGemGreen) || choice2.Info.HasAbility(Ability.GainGemGreen))) { nameReplacement = "Bleene"; }

				if (choice1.Info.name == choice2.Info.name)
                    nameReplacement = choice1.Info.DisplayedNameEnglish.Split(' ')[0];

                potionMod.nameReplacement = nameReplacement + " Mix";
				potionMod.abilities = choice2.Info.abilities;
				component.SetInfo(potion);
				component.Info.mods.Add(potionMod);
				component.Info.SetPortrait(MagCurrentNode.getMixPortrait(nameReplacement));
				component.RenderCard();


				int amts = 0;
				foreach (string modName in SaveManager.saveFile.grimoraData.deck.cardIdModInfos.Keys)
				{
					if (modName == choice1.Info.name)
						amts++;
				}
                SaveManager.saveFile.grimoraData.deck.cardIdModInfos[choice1.Info.name + "#" + amts] = new List<CardModificationInfo>() { potionMod }; // Shitty hack but I dont know where else to store this information without it being needlessly complex

				GameObject.Destroy(choice1.gameObject);

				Tween.LocalPosition(component.transform, new Vector3(0, 2.2f, 0.15f), 0.5f, 0);
				Singleton<ViewManager>.Instance.SwitchToView(View.Default);
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("IT IS DONE!!! GO TAKE IT!!", -0.5f, 0f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
				if (!SavedVars.LearnedMechanics.Contains("stimmyf3n;"))
				{
					SavedVars.LearnedMechanics += "stimmyf3n;";
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("GO!!", -0.5f, 0f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("[c:g2]GET OUT OF HERE!![c:]", -0.5f, 0f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
				}
				CustomTextDisplayerStuff.switchToSpeakerStyle(0);
				done = true;
				component.gameObject.GetComponent<BoxCollider>().enabled = true;
				yield break;
			}

			public IEnumerator sequencer(Cauldron tradeCardsData)
			{
				doing = false;
				done = false;
				if (SaveManager.saveFile.ascensionActive && MagnificusMod.Generation.challenges.Contains("FadingMox"))
				{
					Singleton<MagnificusLifeManager>.Instance.playerLife = KayceeStorage.FleetingLife;
				}
				GameObject cauldron = Instantiate(GameObject.Find("cauldron"));
				cauldron.name = "EventCauldron";
				cauldron.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
				cauldron.transform.parent = GameObject.Find("GameTable").transform;
				cauldron.transform.localPosition = new Vector3(0, 5.88f, 0);
				cauldron.transform.localRotation = Quaternion.Euler(0, 180, 0);
				Singleton<ViewManager>.Instance.SwitchToView(View.Default);
				yield return new WaitForSeconds(1.55f);
				CustomTextDisplayerStuff.switchToSpeakerStyle(2);
				Singleton<ViewManager>.Instance.SwitchToView(View.Default, false, true);
				GameObject.Find("GameTable").transform.Find("LonelyMage").transform.localPosition = new Vector3(0f, 1f, 7.5f);
				GameObject.Find("GameTable").transform.Find("LonelyMage").gameObject.SetActive(true);
				GameObject.Find("GameTable").transform.Find("LonelyMage").transform.GetChild(2).GetChild(0).GetChild(0).GetChild(1).Find("LeftEye").localScale = new Vector3(1, 1, 1);
				GameObject.Find("GameTable").transform.Find("LonelyMage").transform.GetChild(2).GetChild(0).GetChild(0).GetChild(2).Find("RightEye").localScale = new Vector3(-1, -1, -1);
				GameObject.Find("GameTable").transform.Find("LonelyMage").GetComponent<Animator>().speed = 1;

				yield return new WaitForSeconds(2f);

				if (RunState.Run.regionTier == 3)
				{
					if (!SavedVars.LearnedMechanics.Contains("stimmyf3n"))
					{
						yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("W-What? Am I finally free?", -0.5f, 0f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
						yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("A break from that endless darkness?", -1f, 0f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
						yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Nevermind.. It's just alchemy..", -1f, 0f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
						yield return new WaitForSeconds(0.26f);
						if (SavedVars.LearnedMechanics.Contains("beatlonely"))
						{ yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Oh, Hi Challenger!!", -1f, 0f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);} 
						else { yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Wow, someone new!!", -1f, 0f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null); }
						yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Just give me two mox cards of yours and we'll mix them together!!", -1f, 0f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
						yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Come on!! It will be fun!!", -1f, 0f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
						yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("And stimulating..", -1f, 0f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
						yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("So stimulating", -1f, 0f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
					}
					else
					{
						yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Hello there challenger!!", -1f, 0f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
						yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("You know how this works now", -1f, 0f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
						yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Just give me two mox and we'll mix em together!!", -1f, 0f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
					}
				} else
                {
					if (!SavedVars.LearnedMechanics.Contains("stimmyf2n"))
					{
						yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Woah.. What.. Is this place?", -0.5f, 0f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
						yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("So bright..", -1f, 0f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
						yield return new WaitForSeconds(0.26f);
						yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Oh, Hi there!!", -1f, 0f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
						yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Let's make some mox mixes!!", -1f, 0f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
						yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Just hand over two mox cards and we'll be done with it..", -1f, 0f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
						yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Come on!! It will be fun!!", -1f, 0f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
						SavedVars.LearnedMechanics += "stimmyf2n;";
					}
					else
					{
						yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Hello there challenger!!", -1f, 0f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
						yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("You know how this works now", -1f, 0f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
						yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Just give me two mox and we'll mix em together!!", -1f, 0f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
					}
				}
				yield return new WaitForSeconds(1f);
				Singleton<ViewManager>.Instance.SwitchToView(View.MapDefault, false, true);
				yield return new WaitForSeconds(0.5f);
				cardsChosen = 0;
				yield return this.spawnCards();
				yield break;
			}

			public SelectableCard mainComponent;
			public SelectableCard copiedCard;
			public int cardsChosen = 0;

			public int card = 0;

			public int cd = 0;

			public List<List<int>> chosenOnes = new List<List<int>> { new List<int> { 0, 0, 0 }, new List<int> { 0, 0, 0 }, new List<int> { 0, 0, 0 } };
			public List<SelectableCard> cardpicked = new List<SelectableCard>();
			public List<List<CardInfo>> colours = new List<List<CardInfo>> { new List<CardInfo>(), new List<CardInfo>(), new List<CardInfo>() };
			public List<GameObject> createdGroups = new List<GameObject>();

			public List<SelectableCard> cardpickedfromdeck = new List<SelectableCard>();

			public List<SelectableCard> created = new List<SelectableCard>();
		}

		public class copycard : CardChoicesSequencer
		{
			public ConfirmStoneButton confirmStone { get; set; }

			bool done = false;

			bool doing = false;
			public void removeselectablecardfromdeck(SelectableCard component)
			{
				base.StartCoroutine(this.removeselectablecardfromdeckie(component, true));
			}
			public IEnumerator WaitThenDisable(GameObject whotokill, float wait)
			{
				yield return new WaitForSeconds(wait);
				whotokill.SetActive(false);
				yield break;
			}

			public IEnumerator NodeOutroSequence()
			{

				GameObject npc = GameObject.Find("Goober");
				Tween.Rotation(npc.transform, Quaternion.Euler(0, 0, 0), 5f, 0);
				Vector3 npcPos = npc.transform.localPosition;
				npcPos.y = -8f;
				Tween.LocalPosition(npc.transform, npcPos, 5f, 0);
				yield return new WaitForSeconds(4.5f);
				npc.SetActive(false);
				Singleton<GameFlowManager>.Instance.TransitionToGameState(GameState.Map, null);
				copiedCard.gameObject.transform.localPosition = new Vector3(0.1396f, 1.2338f, 1.2726f);
				GameObject.Find("CopyCardSequencer").transform.Find("EaselWithCard").Find("Easel").Find("EaselAnim").GetChild(3).gameObject.name = "SelectableCard";
				GameObject.Find("CopyCardSequencer").transform.Find("EaselWithCard").Find("Easel").Find("EaselAnim").GetChild(3).gameObject.GetComponent<SelectableCard>().SetInfo(CardLoader.GetCardByName("JuniorSage"));
				GameObject.Find("CopyCardSequencer").transform.Find("EaselWithCard").Find("Easel").Find("EaselAnim").GetChild(3).gameObject.GetComponent<SelectableCard>().renderInfo.baseInfo.abilities = new List<Ability>();
				GameObject.Find("CopyCardSequencer").transform.Find("EaselWithCard").Find("Easel").Find("EaselAnim").GetChild(3).gameObject.GetComponent<SelectableCard>().renderInfo.baseInfo.displayedName = "";
				GameObject.Find("CopyCardSequencer").transform.Find("EaselWithCard").Find("Easel").Find("EaselAnim").GetChild(3).gameObject.GetComponent<SelectableCard>().renderInfo.hidePortrait = true;
				GameObject.Find("CopyCardSequencer").transform.Find("EaselWithCard").Find("Easel").Find("EaselAnim").GetChild(3).gameObject.GetComponent<SelectableCard>().renderInfo.hiddenAttack = true;
				GameObject.Find("CopyCardSequencer").transform.Find("EaselWithCard").Find("Easel").Find("EaselAnim").GetChild(3).gameObject.GetComponent<SelectableCard>().renderInfo.hiddenCost = true;
				GameObject.Find("CopyCardSequencer").transform.Find("EaselWithCard").Find("Easel").Find("EaselAnim").GetChild(3).gameObject.GetComponent<SelectableCard>().renderInfo.hiddenHealth = true;
				GameObject.Find("CopyCardSequencer").transform.Find("EaselWithCard").Find("Easel").Find("EaselAnim").GetChild(3).gameObject.GetComponent<SelectableCard>().RenderCard();
				
				yield break;
			}

			public void cardpickingupscropt(SelectableCard component)
			{
				if (doing) { return; }
				if (done)
				{
					mainComponent.ExitBoard(0.3f, new Vector3(0, 0.5f, 0f));
					Tween.LocalPosition(copiedCard.transform, new Vector3(16, 16, 0), 0.3f, 0);
					this.confirmStone.Exit();
					Destroy(GameObject.Find("TESTSTONE"));

					base.StartCoroutine(this.WaitThenDisable(GameObject.Find("CopyCardSequencer").transform.Find("EaselWithSlot").gameObject, 0.45f));
					base.StartCoroutine(this.WaitThenDisable(GameObject.Find("CopyCardSequencer").transform.Find("EaselWithCard").gameObject, 0.45f));
					base.StartCoroutine(this.NodeOutroSequence());
				}
				else
				{
					mainComponent.ExitBoard(0.3f, new Vector3(-1f, -1f, 6f));

					Destroy(GameObject.Find("TESTSTONE"));
					GameObject.Find("CopyCardSequencer").transform.Find("EaselWithSlot").gameObject.SetActive(false);
					GameObject.Find("CopyCardSequencer").transform.Find("EaselWithCard").gameObject.SetActive(false);

					int num = RunState.Run.playerDeck.Cards.Count;
					bool flag4 = num > 12;
					if (flag4)
					{
						num = 12;
					}
					Singleton<ViewManager>.Instance.SwitchToView(View.MapDefault, false, true);
					List<CardInfo> deck = new List<CardInfo>();
					foreach (CardInfo card in RunState.Run.playerDeck.Cards)
					{
						deck.Add(card);
					}
					deck.RemoveAll((CardInfo x) => x.HasTrait(Trait.EatsWarrens));

					GameObject theDeck = Singleton<DeckReviewSequencer>.Instance.gameObject;
					theDeck.transform.parent = GameObject.Find("GameTable").transform;
					theDeck.transform.localPosition = new Vector3(0, 5.01f, -1f);
					theDeck.transform.localScale = new Vector3(1, 1, 1);
					Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(Singleton<DeckReviewSequencer>.Instance.cardArray.SelectCardFrom(deck, null, new Action<SelectableCard>(this.removeselectablecardfromdeck)));
					for (int i = 0; i < theDeck.transform.childCount; i++)
					{
						this.cardpickedfromdeck.Add(theDeck.transform.GetChild(i).gameObject.GetComponent<SelectableCard>());
					}
				}
			}

			public IEnumerator removeselectablecardfromdeckie(SelectableCard component, bool run)
			{
				doing = false;
				mainComponent = component;
				this.cardpickedfromdeck.Remove(component);
				this.cd = 0;
				GameObject table = GameObject.Find("GameTable");
				foreach (SelectableCard VARIABLE in this.cardpickedfromdeck)
				{
					VARIABLE.ExitBoard(0.3f, new Vector3(-1f, -1f, 6f));
					yield return new WaitForSeconds(0.075f);
				}
				GameObject.Find("CopyCardSequencer").transform.Find("EaselWithCard").localPosition = new Vector3(-2.07f, 6.55f, -0.39f);
				GameObject.Find("CopyCardSequencer").transform.Find("EaselWithCard").localRotation = Quaternion.Euler(0, 0, 0);
				GameObject.Find("CopyCardSequencer").transform.Find("EaselWithSlot").localPosition = new Vector3(1.69f, 6.55f, -0.39f);
				GameObject.Find("CopyCardSequencer").transform.Find("EaselWithSlot").localRotation = Quaternion.Euler(0, 0, 0);
				GameObject.Find("CopyCardSequencer").transform.Find("EaselWithSlot").gameObject.SetActive(true);
				GameObject.Find("EaselWithSlot").transform.Find("SelectionSlot").localPosition = new Vector3(-0.175f, 0.25f, -0.3f);
				GameObject.Find("EaselWithSlot").transform.Find("SelectionSlot").gameObject.GetComponent<SelectCardFromDeckSlot>().SetShown(true, true);
				GameObject.Find("CopyCardSequencer").transform.Find("EaselWithCard").gameObject.SetActive(true);
				if (GameObject.Find("CopyCardSequencer").transform.Find("EaselWithCard").Find("Easel").Find("EaselAnim").GetChild(3).gameObject.name == "SelectableCard")
				{
					GameObject.Find("CopyCardSequencer").transform.Find("EaselWithCard").Find("Easel").Find("EaselAnim").Find("SelectableCard").Find("Quad").Find("CardBase").Find("RenderStatsLayer").Find("BendableCard").Find("Mesh").gameObject.GetComponent<SkinnedMeshRenderer>().materials[0].mainTexture = Tools.getImage("finalecardback.png");
					GameObject.Find("CopyCardSequencer").transform.Find("EaselWithCard").Find("Easel").Find("EaselAnim").Find("SelectableCard").Find("Quad").Find("CardBase").Find("RenderStatsLayer").Find("BendableCard").Find("Mesh").gameObject.GetComponent<SkinnedMeshRenderer>().materials[1].mainTexture = Tools.getImage("finalecardbacknobars.png");
				}
				component.transform.parent = GameObject.Find("EaselWithSlot").transform.Find("SelectionSlot");
				component.transform.rotation = Quaternion.Euler(90, 0, 0);
				yield return new WaitForSeconds(0.25f);
				GameObject.Find("EaselWithSlot").transform.Find("SelectionSlot").gameObject.GetComponent<SelectCardFromDeckSlot>().SetShown(false);
				Tween.Rotation(component.transform, Quaternion.Euler(8.9117f, 36.0984f, 1.2628f), 0.15f, 0f);
				Tween.LocalPosition(component.transform, new Vector3(0, 0, 0), 0.15f, 0.1f, null, Tween.LoopType.None, null, null, true);
				yield return new WaitForSeconds(0.2f);
				GameObject.Instantiate(Resources.Load("prefabs\\specialnodesequences\\ConfirmStoneButton")).name = "TESTSTONE";
				this.confirmStone = GameObject.Find("TESTSTONE").GetComponentInChildren<ConfirmStoneButton>();
				confirmStone.currentHighlightedColor = new Color(0.3321f, 1f, 0.154f, 1);
				confirmStone.currentInteractableColor = new Color(0.3321f, 0.5472f, 0.154f, 1);
				GameObject.Find("TESTSTONE").transform.Find("Anim").Find("model").Find("ConfirmButton").Find("Quad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = (Resources.Load("art/cards/copycard_button") as Texture2D);
				GameObject.Find("TESTSTONE").AddComponent<BoxCollider>().size = new Vector3(1.4f, 0.2f, 2.1f);
				Tween.Position(GameObject.Find("TESTSTONE").transform, new Vector3(table.transform.position.x, 14.75f, -2.6f + table.transform.position.z), 0.15f, 0.1f, null, Tween.LoopType.None, null, null, true);
				List<SelectableCard>.Enumerator enumerator = default(List<SelectableCard>.Enumerator);
				component.gameObject.GetComponent<BoxCollider>().enabled = true;
				component.Initialize(component.Info, new Action<SelectableCard>(this.cardpickingupscropt), null, false, null);
				this.confirmStone.Enter();
				yield return this.confirmStone.WaitUntilConfirmation();
				Singleton<ViewManager>.Instance.SwitchToView(View.Default);
				doing = true;
				// 0.1298 6.49 3.43    215
				// 1.69 6.55 4.5499    112
				GameObject.Find("TESTSTONE").GetComponent<BoxCollider>().size = new Vector3(0f, 0f, 0f);
				Tween.LocalPosition(GameObject.Find("CopyCardSequencer").transform.Find("EaselWithCard"), new Vector3(0.1298f, 6.55f, 3.43f), 1f, 0);
				Tween.LocalRotation(GameObject.Find("CopyCardSequencer").transform.Find("EaselWithCard"), new Vector3(0, 215, 0), 1f, 0);
				Tween.LocalPosition(GameObject.Find("CopyCardSequencer").transform.Find("EaselWithSlot"), new Vector3(1.69f, 6.55f, 4.5499f), 1f, 0);
				Tween.LocalRotation(GameObject.Find("CopyCardSequencer").transform.Find("EaselWithSlot"), new Vector3(0, 112, 0), 1f, 0);
				yield return new WaitForSeconds(0.75f);
				if (component.Info.name != "mag_goobert")
				{
					yield return GameObject.Find("TextDisplayer").GetComponent<TextDisplayer>().ShowUntilInput("LETS SEE HERE..", -1f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Goo, null, true);
				}
				else
				{
					yield return GameObject.Find("TextDisplayer").GetComponent<TextDisplayer>().ShowUntilInput("HMM?", -1f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Goo, null, true);
				}
				GameObject.Find("CopyCardSequencer").transform.Find("EaselWithCard").Find("Easel").Find("EaselAnim").GetChild(3).gameObject.GetComponent<SelectableCard>().renderInfo.hidePortrait = false;
				GameObject.Find("CopyCardSequencer").transform.Find("EaselWithCard").Find("Easel").Find("EaselAnim").GetChild(3).gameObject.GetComponent<SelectableCard>().renderInfo.hiddenAttack = false;
				GameObject.Find("CopyCardSequencer").transform.Find("EaselWithCard").Find("Easel").Find("EaselAnim").GetChild(3).gameObject.GetComponent<SelectableCard>().renderInfo.hiddenCost = false;
				GameObject.Find("CopyCardSequencer").transform.Find("EaselWithCard").Find("Easel").Find("EaselAnim").GetChild(3).gameObject.GetComponent<SelectableCard>().renderInfo.hiddenHealth = false;
				CardModificationInfo mod = new CardModificationInfo();
				int random = Random.RandomRangeInt(0, 100);
				bool changedGemCost = false;
				bool gemfriend = false;
				for (int i = 0; i < 2 + Random.RandomRangeInt(0, 3); i++)
				{
					random = Random.RandomRangeInt(0, 100);
					if (random < 25)
					{
						random = Random.RandomRangeInt(0, 100);
						if (random < 55 || component.Info.Attack < 1 && mod.attackAdjustment < 1)
						{
							mod.attackAdjustment += 1;
						}
						else if (component.Info.Attack > 1||component.Info.Attack == 0 && mod.attackAdjustment > 0)
						{
							mod.attackAdjustment += -1;
						}
					}
					else if (random < 45)
					{
						random = Random.RandomRangeInt(0, 100);
						if (random < 60 || component.Info.Health < 2 && mod.healthAdjustment < 2)
						{
							mod.healthAdjustment += Random.RandomRangeInt(1, 2);
						}
						else if (component.Info.Health > 1 || component.Info.Health == 1 && mod.healthAdjustment > 0)
						{
							mod.healthAdjustment += -1;
						}
					}
					else if (random < 65)
					{
						random = Random.RandomRangeInt(0, 100);
						if (random < 55 && component.Info.abilities.Count > 0 || component.Info.abilities.Count + mod.abilities.Count >= 4)
						{
							mod.negateAbilities.Add(component.Info.abilities[Random.RandomRangeInt(0, component.Info.abilities.Count)]);
						}
						else
						{
							List<Ability> abilities = new List<Ability> { Ability.Sharp, Ability.Flying, Ability.Reach, SigilCode.GemGuardianFix.ability, Ability.BuffNeighbours, Ability.DebuffEnemy, SigilCode.MagDropRubyOnDeath.ability, SigilCode.MagDropEmeraldOnDeath.ability, Ability.ExplodeOnDeath, Ability.SwapStats, SigilCode.MoxCycling.ability, Ability.GemDependant, SigilCode.FamiliarA.ability, Ability.GuardDog, Ability.DrawRabbits, Ability.RandomAbility };
							mod.abilities.Add(abilities[Random.RandomRangeInt(0, abilities.Count)]);
							if (!changedGemCost && component.Info.gemsCost.Count > 0)
							{
								random = Random.RandomRangeInt(0, 100);
								if (random > 85)
								{
									changedGemCost = true;
									mod.nullifyGemsCost = true;
									int gem = Random.RandomRangeInt(0, 3);
									mod.addGemCost = new List<GemType> { (GemType)gem };
									if (component.Info.gemsCost.Count == 2)
									{
										int gem2 = Random.RandomRangeInt(0, 3);
										mod.addGemCost = new List<GemType> { (GemType)gem, (GemType)gem2 };
									}
								}

							}
						}
						if (component.Info.name == "GemFiend" && !gemfriend)
						{
							random = Random.RandomRangeInt(0, 100);
							if (random > 45)
							{
								gemfriend = true;
							}
						}
					}
					random = Random.RandomRangeInt(0, 100);
					if (random < 51)
					{
						AudioController.Instance.PlaySound2D("magnificus_brush_splatter_bleach", MixerGroup.None, 0.5f, 0f, null, null, null, null, false);
					}
					else
					{
						AudioController.Instance.PlaySound2D("magnificus_brush_splatter_color", MixerGroup.None, 0.5f, 0f, null, null, null, null, false);
					}
					yield return new WaitForSeconds(0.5f);
				}
				mainComponent = component;
				if (!gemfriend)
				{
					RunState.Run.playerDeck.AddCard(component.Info);
					RunState.Run.playerDeck.ModifyCard(component.Info, mod);
					GameObject.Find("CopyCardSequencer").transform.Find("EaselWithCard").Find("Easel").gameObject.GetComponentInChildren<SelectableCard>().SetInfo(component.Info);
					GameObject.Find("CopyCardSequencer").transform.Find("EaselWithCard").Find("Easel").gameObject.GetComponentInChildren<SelectableCard>().Initialize(component.Info, new Action<SelectableCard>(this.cardpickingupscropt), null, false, null);
					copiedCard = GameObject.Find("CopyCardSequencer").transform.Find("EaselWithCard").Find("Easel").gameObject.GetComponentInChildren<SelectableCard>();
				}
				else
				{
					CardInfo cardiff = new CardInfo();
					cardiff = CardLoader.GetCardByName("mag_gemfriend");
					RunState.Run.playerDeck.AddCard(cardiff);
					GameObject.Find("CopyCardSequencer").transform.Find("EaselWithCard").Find("Easel").gameObject.GetComponentInChildren<SelectableCard>().SetInfo(cardiff);
					GameObject.Find("CopyCardSequencer").transform.Find("EaselWithCard").Find("Easel").gameObject.GetComponentInChildren<SelectableCard>().Initialize(cardiff, new Action<SelectableCard>(this.cardpickingupscropt), null, false, null);
					copiedCard = GameObject.Find("CopyCardSequencer").transform.Find("EaselWithCard").Find("Easel").gameObject.GetComponentInChildren<SelectableCard>();
				}
				yield return new WaitForSeconds(0.5f);
				doing = false;
				Tween.LocalPosition(GameObject.Find("CopyCardSequencer").transform.Find("EaselWithCard"), new Vector3(-2.07f, 6.55f, -0.39f), 0.4f, 0);
				Tween.LocalRotation(GameObject.Find("CopyCardSequencer").transform.Find("EaselWithCard"), new Vector3(0, 0, 0), 0.4f, 0);
				Tween.LocalPosition(GameObject.Find("CopyCardSequencer").transform.Find("EaselWithSlot"), new Vector3(1.69f, 6.55f, -0.39f), 0.4f, 0);
				Tween.LocalRotation(GameObject.Find("CopyCardSequencer").transform.Find("EaselWithSlot"), new Vector3(0, 0, 0), 0.4f, 0);
				random = Random.RandomRangeInt(0, 100);
				if (random < 22)
				{
					yield return GameObject.Find("TextDisplayer").GetComponent<TextDisplayer>().ShowUntilInput("WHAT DO YOU THINK?", -1f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Goo, null, true);
				}
				else if (random < 44)
				{
					yield return GameObject.Find("TextDisplayer").GetComponent<TextDisplayer>().ShowUntilInput("WELL?", -1f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Goo, null, true);
				}
				else if (random < 66)
				{
					yield return GameObject.Find("TextDisplayer").GetComponent<TextDisplayer>().ShowUntilInput("WHAT WOULD THE MASTER THINK?", -1f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Goo, null, true);
				}
				else if (random < 88)
				{
					yield return GameObject.Find("TextDisplayer").GetComponent<TextDisplayer>().ShowUntilInput("WOULD THE MASTER BE PROUD?", -1f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Goo, null, true);
				}
				else if (random < 101)
				{
					yield return GameObject.Find("TextDisplayer").GetComponent<TextDisplayer>().ShowUntilInput("IS IT GOOD?", -1f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Goo, null, true);
				}
				done = true;
				CustomTextDisplayerStuff.setBaseTextDisplayerOn(false);
				yield break;
			}

			public IEnumerator sequencer(CopyNode tradeCardsData)
			{
				doing = false;
				done = false;
				Singleton<ViewManager>.Instance.SwitchToView(View.Default);
				if (SaveManager.saveFile.ascensionActive && MagnificusMod.Generation.challenges.Contains("FadingMox"))
				{
					Singleton<MagnificusLifeManager>.Instance.playerLife = KayceeStorage.FleetingLife;
				}
				yield return new WaitForSeconds(1.55f);
				CustomTextDisplayerStuff.setBaseTextDisplayerOn(true);
				GameObject.Find("GameTable").transform.Find("Goober").transform.localPosition = new Vector3(0, 6, 26);
				GameObject.Find("GameTable").transform.Find("Goober").transform.rotation = Quaternion.Euler(0, 180, 0);
				GameObject.Find("GameTable").transform.Find("Goober").gameObject.SetActive(true);
				yield return new WaitForSeconds(0.75f);
				Singleton<ViewManager>.Instance.SwitchToView(View.BossCloseup, false, true);
				base.StartCoroutine(GameObject.Find("TextDisplayer").GetComponent<TextDisplayer>().ShowThenClear("GRRAHH!!", 1.5f, 0f, Emotion.Anger, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Goo, null));
				yield return new WaitForSeconds(2f);
				Singleton<ViewManager>.Instance.SwitchToView(View.Default, false, true);
				yield return GameObject.Find("TextDisplayer").GetComponent<TextDisplayer>().ShowUntilInput("GRREETINGS CHALLENGER!", -1f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Goo, null, true);
				if (RunState.Run.regionTier == 2)
				{
					if (Generation.challenges.Contains("MasterBosses"))
                    {
						yield return GameObject.Find("TextDisplayer").GetComponent<TextDisplayer>().ShowUntilInput("YOU'RE ALREADY HERE?", -1f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Goo, null, true);
						yield return GameObject.Find("TextDisplayer").GetComponent<TextDisplayer>().ShowUntilInput("I DON'T REALLY RECALL US BATTLING..", -1f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Goo, null, true);
						yield return GameObject.Find("TextDisplayer").GetComponent<TextDisplayer>().ShowUntilInput("WELL ANYWAYS.. WHAT CARD WHOULD I PRACTICE ON?", -1f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Goo, null, true);
					} else if (!SavedVars.LearnedMechanics.Contains("goobertf2"))
					{
						SavedVars.LearnedMechanics += "goobertf2;";
						yield return GameObject.Find("TextDisplayer").GetComponent<TextDisplayer>().ShowUntilInput("IT WOULD SEEM THAT YOU HAVE DISGRACED ME!", -1f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Goo, null, true);
						yield return GameObject.Find("TextDisplayer").GetComponent<TextDisplayer>().ShowUntilInput("BUT IT IS ALRIGHT, I FORGIVE YOU.", -1f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Goo, null, true);
						yield return GameObject.Find("TextDisplayer").GetComponent<TextDisplayer>().ShowUntilInput("SAY, CHALLENGER, I WOULD LIKE TO PRACTICE MY [c:g2]ART[c:]..", -1f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Goo, null, true);
						yield return GameObject.Find("TextDisplayer").GetComponent<TextDisplayer>().ShowUntilInput("ONE DAY I MIGHT EVEN BE AS GOOD AS THE MASTER!", -1f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Goo, null, true);
						yield return GameObject.Find("TextDisplayer").GetComponent<TextDisplayer>().ShowUntilInput("YOU WOULDN'T MIND GIVING ME ONE OF YOUR THERE CARDS, RIGHT?", -1f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Goo, null, true);
					}
					else
					{
						yield return GameObject.Find("TextDisplayer").GetComponent<TextDisplayer>().ShowUntilInput("WHAT CARD SHOULD I PRACTICE ON?", -1f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Goo, null, true);
					}
				}
				else if (RunState.Run.regionTier ==3)
				{
					
					yield return GameObject.Find("TextDisplayer").GetComponent<TextDisplayer>().ShowUntilInput("I'LL NEED A CARD TO HONE MY SKILLS ON.", -1f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Goo, null, true);
					
				}
				else if (RunState.Run.regionTier == 1)
				{
					if (!SavedVars.LearnedMechanics.Contains("goobertf1"))
					{
						SavedVars.LearnedMechanics += "goobertf1;";
						yield return GameObject.Find("TextDisplayer").GetComponent<TextDisplayer>().ShowUntilInput("I DON'T THINK WE'VE MET BEFORE!", -1f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Goo, null, true);
						yield return GameObject.Find("TextDisplayer").GetComponent<TextDisplayer>().ShowUntilInput("SAY, CHALLENGER, I WOULD LIKE TO PRACTICE MY [c:g2]ART[c:]..", -1f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Goo, null, true);
						yield return GameObject.Find("TextDisplayer").GetComponent<TextDisplayer>().ShowUntilInput("ONE DAY I MIGHT EVEN BE AS GOOD AS THE MASTER!", -1f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Goo, null, true);
						yield return GameObject.Find("TextDisplayer").GetComponent<TextDisplayer>().ShowUntilInput("YOU WOULDN'T MIND GIVING ME ONE OF YOUR THERE CARDS, RIGHT?", -1f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Goo, null, true);
					}
					else
					{
						yield return GameObject.Find("TextDisplayer").GetComponent<TextDisplayer>().ShowUntilInput("YOU ARENT SUPPOSED TO SEE ME UNTILL LATER, BUT..", -1f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Goo, null, true);
						yield return GameObject.Find("TextDisplayer").GetComponent<TextDisplayer>().ShowUntilInput("YOU WOULDN'T MIND GIVING ME ONE OF YOUR THERE CARDS, RIGHT?", -1f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Goo, null, true);
					}
				}
				Singleton<ViewManager>.Instance.SwitchToView(View.MapDefault, false, true);
				yield return new WaitForSeconds(0.5f);
				this.card = 0;
				List<CardInfo> deck = new List<CardInfo>();
				foreach (CardInfo card in RunState.Run.playerDeck.Cards)
				{
					deck.Add(card);
				}
				deck.RemoveAll((CardInfo x) => x.HasTrait(Trait.EatsWarrens));
				GameObject theDeck = Singleton<DeckReviewSequencer>.Instance.gameObject;
				theDeck.transform.parent = GameObject.Find("GameTable").transform;
				theDeck.transform.localPosition = new Vector3(0, 5.01f, -1f);
				theDeck.transform.localScale = new Vector3(1, 1, 1);
				Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(Singleton<DeckReviewSequencer>.Instance.cardArray.SelectCardFrom(deck, null, new Action<SelectableCard>(this.removeselectablecardfromdeck)));
				for (int i = 0; i < theDeck.transform.childCount; i++)
				{
					this.cardpickedfromdeck.Add(theDeck.transform.GetChild(i).gameObject.GetComponent<SelectableCard>());
				}
				yield break;
			}

			public SelectableCard mainComponent;
			public SelectableCard copiedCard;
			public int i = 0;

			public int card = 0;

			public int cd = 0;

			public List<List<int>> chosenOnes = new List<List<int>> { new List<int> { 0, 0, 0 }, new List<int> { 0, 0, 0 }, new List<int> { 0, 0, 0 } };
			public List<SelectableCard> cardpicked = new List<SelectableCard>();
			public List<List<CardInfo>> colours = new List<List<CardInfo>> { new List<CardInfo>(), new List<CardInfo>(), new List<CardInfo>() };
			public List<GameObject> createdGroups = new List<GameObject>();

			public List<SelectableCard> cardpickedfromdeck = new List<SelectableCard>();

			public List<SelectableCard> created = new List<SelectableCard>();
		}

		public class merge : CardChoicesSequencer
		{
			public ConfirmStoneButton confirmStone { get; set; }

			bool done = false;
			public void removeselectablecardfromdeck(SelectableCard component)
			{
				base.StartCoroutine(this.removeselectablecardfromdeckie(component, true));
			}

			public void selectstatscard(SelectableCard component)
			{
				base.StartCoroutine(this.selectstatscardie(component));
			}
			public static IEnumerator WaitThenDestroy(GameObject whotokill, float wait)
			{
				yield return new WaitForSeconds(wait);
				Destroy(whotokill);
				yield break;
			}

			public void cardpickingupscropt(SelectableCard component)
			{
				//bool flag = component.Info.HasModFromCardMerge();
				if (done)
				{
					component.ExitBoard(0.3f, new Vector3(0, 0.5f, 0f));
					base.StartCoroutine(WaitThenDestroy(GameObject.Find("magMushrooms"), 0.5f));
					Singleton<GameFlowManager>.Instance.TransitionToGameState(GameState.Map, null);
				}
				else
				{
					this.cd = 0;
					Tween.LocalPosition(GameObject.Find("magMushrooms").transform, new Vector3(0, 0, 2), 0.15f, 0f);
					firstComponent.ExitBoard(0.3f, new Vector3(-1f, -1f, 6f));
					otherComponent.ExitBoard(0.3f, new Vector3(-1f, -1f, 6f));
					GameObject.Find("TESTSTONE").GetComponent<BoxCollider>().size = new Vector3(0f, 0f, 0f);
					Destroy(GameObject.Find("TESTSTONE"));
					GameObject.Find("Player").GetComponentInChildren<ViewManager>().SwitchToView(View.Choices, false, false);

					List<CardInfo> listOfCards = new List<CardInfo>();
					foreach (CardInfo card in RunState.Run.playerDeck.Cards)
					{
						listOfCards.Add(card);
					}
					listOfCards.RemoveAll((CardInfo x) => x.traits.Contains(Trait.Pelt) || x.traits.Contains(Trait.EatsWarrens) );
					GameObject theDeck = Singleton<DeckReviewSequencer>.Instance.gameObject;
					theDeck.transform.parent = GameObject.Find("GameTable").transform;
					theDeck.transform.localPosition = new Vector3(0, 5.01f, -2f);
					theDeck.transform.localScale = new Vector3(1, 1, 1);
					Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(Singleton<DeckReviewSequencer>.Instance.cardArray.SelectCardFrom(listOfCards, null, new Action<SelectableCard>(this.selectstatscard)));
					for (int i = 0; i < theDeck.transform.childCount; i++)
					{
						this.cardpickedfromdeck.Add(theDeck.transform.GetChild(i).gameObject.GetComponent<SelectableCard>());
					}
				}
			}

			public List<CardInfo> mixMatchInfo(CardInfo baseCard)
			{
                List<CardInfo> listOfCards = new List<CardInfo>();
                foreach (CardInfo card in RunState.Run.playerDeck.Cards)
                {
                    listOfCards.Add(card);
                }
                listOfCards.RemoveAll((CardInfo x) => x.traits.Contains(Trait.Pelt) || x.traits.Contains(Trait.EatsWarrens) || x == baseCard || x.gemsCost.Count > 1 || (x.gemsCost.Count > 0 && baseCard.gemsCost.Contains(x.gemsCost[0])) || (x.BloodCost > 0 && baseCard.gemsCost.Count > 0) || (baseCard.BloodCost > 0 && x.gemsCost.Count > 0));
				return listOfCards;
            }
            public IEnumerator selectstatscardie(SelectableCard component)
            {
                this.cardpickedfromdeck.Remove(component);
                firstComponent = component;
				GameObject table = GameObject.Find("GameTable");
				Tween.Position(component.transform, new Vector3(table.transform.position.x - 0.7f, 14.75f, 1 + table.transform.position.z), 0.15f, 0.1f, null, Tween.LoopType.None, null, null, true);
				List<CardInfo> listOfCards = mixMatchInfo(component.Info);
				GameObject theDeck = Singleton<DeckReviewSequencer>.Instance.gameObject;
				theDeck.transform.parent = GameObject.Find("GameTable").transform;
				theDeck.transform.localPosition = new Vector3(0, 5.01f, -2f);
				theDeck.transform.localScale = new Vector3(1, 1, 1);
				Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(Singleton<DeckReviewSequencer>.Instance.cardArray.SelectCardFrom(listOfCards, null, new Action<SelectableCard>(this.removeselectablecardfromdeck)));
				for (int i = 0; i < theDeck.transform.childCount; i++)
				{
					this.cardpickedfromdeck.Add(theDeck.transform.GetChild(i).gameObject.GetComponent<SelectableCard>());
				}
				//yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Now the mushrooms require a card that they will attach.. Increasing the stats of the host.", -0.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);

				yield break;
			}

			public IEnumerator removeselectablecardfromdeckie(SelectableCard component, bool run)
			{
				/*
				foreach (GameObject group in createdGroups)
				{
					if (group.name != component.gameObject.transform.parent.gameObject.name)
					{
						Destroy(group);
					}
				}*/
				otherComponent = component;
				this.cardpickedfromdeck.Remove(component);
				this.cd = 0;
				GameObject table = GameObject.Find("GameTable");
				Tween.Position(component.transform, new Vector3(table.transform.position.x + 0.85f, 14.75f, table.transform.position.z), 0.15f, 0.1f, null, Tween.LoopType.None, null, null, true);
				Tween.Position(firstComponent.transform, new Vector3(table.transform.position.x - 0.7f, 14.75f, table.transform.position.z), 0.15f, 0.1f, null, Tween.LoopType.None, null, null, true);
				Tween.LocalPosition(GameObject.Find("magMushrooms").transform, new Vector3(0, 0, 1), 0.15f, 0.1f);
				yield return new WaitForSeconds(0.2f);
				GameObject.Instantiate(Resources.Load("prefabs\\specialnodesequences\\ConfirmStoneButton")).name = "TESTSTONE";
				GameObject.Find("TESTSTONE").AddComponent<BoxCollider>().size = new Vector3(1.4f, 0.2f, 2.1f);
				this.confirmStone = GameObject.Find("TESTSTONE").GetComponentInChildren<ConfirmStoneButton>();
				GameObject.Find("TESTSTONE").transform.Find("Anim").Find("model").Find("ConfirmButton").Find("Quad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = Tools.getImage("mushroom_button.png");
				Tween.Position(GameObject.Find("TESTSTONE").transform, new Vector3(table.transform.position.x, 14.75f, -2.6f + table.transform.position.z), 0.15f, 0.1f, null, Tween.LoopType.None, null, null, true);
				this.confirmStone = GameObject.Find("TESTSTONE").GetComponentInChildren<ConfirmStoneButton>();
				confirmStone.currentHighlightedColor = new Color(1, 0.666f, 0.05f, 1);
				confirmStone.currentInteractableColor = new Color(0.75f, 0.666f, 0.05f, 1);
				component.gameObject.GetComponent<BoxCollider>().enabled = true;
				component.Initialize(component.Info, new Action<SelectableCard>(this.cardpickingupscropt));
				firstComponent.gameObject.GetComponent<BoxCollider>().enabled = true;
				firstComponent.Initialize(firstComponent.Info, new Action<SelectableCard>(this.cardpickingupscropt));
				this.confirmStone.Enter();
				yield return this.confirmStone.WaitUntilConfirmation();
				Singleton<ViewManager>.Instance.SwitchToView(View.TableStraightDown);
				yield return new WaitForSeconds(0.5f);
				int atk = component.Info.Attack;
				int health = component.Info.Health;
				CardModificationInfo merger = new CardModificationInfo();
				merger.attackAdjustment = atk;
				merger.healthAdjustment = health;
				if (atk > 2) { merger.attackAdjustment--; }
				if (health > 2) { merger.healthAdjustment--; }
				int totalStats = firstComponent.Info.Attack + firstComponent.Info.Health;
				totalStats += merger.attackAdjustment;
				totalStats += merger.healthAdjustment / 2;
				if (totalStats > 4)
				{
					if (firstComponent.Info.abilities.Count < 4)
					{
						if (!firstComponent.Info.HasAbility(Ability.GemDependant))
						{
							merger.abilities.Add(Ability.GemDependant);
						}
						else if (firstComponent.Info.HasAbility(Ability.GemDependant) && !firstComponent.Info.HasAbility(SigilCode.FamiliarA.ability))
						{
							merger.abilities.Add(SigilCode.FamiliarA.ability);
						}
					}
				}
				RunState.Run.playerDeck.RemoveCard(component.Info);
				Tween.Position(firstComponent.transform, new Vector3(table.transform.position.x, 14.75f, -1f + table.transform.position.z), 0.15f, 0f, null, Tween.LoopType.None, null, null, true);
				if (firstComponent.Info.name == "BlueMage" && component.Info.name == "BlueMage")
				{
					RunState.Run.playerDeck.RemoveCard(firstComponent.Info);
					CardModificationInfo mods = new CardModificationInfo();
					foreach (Ability ability in firstComponent.Info.abilities)
					{
						if (ability != SigilCode.BlueMageDraw.ability)
						{
							mods.abilities.Add(ability);
						}
					}
					firstComponent.SetInfo(CardLoader.GetCardByName("BlueMage_Fused"));
					RunState.Run.playerDeck.AddCard(firstComponent.Info);
					RunState.Run.playerDeck.ModifyCard(firstComponent.Info, mods);
					firstComponent.SetInfo(firstComponent.Info);
				}
				else
				{
					RunState.Run.playerDeck.ModifyCard(firstComponent.Info, merger);
					firstComponent.SetInfo(firstComponent.Info);
				}
				Destroy(component.gameObject);
				AudioController.Instance.PlaySound2D("wizard_opponent_summon", MixerGroup.TableObjectsSFX, 1f, 0f, null, null, null, null, false);
				yield return new WaitForSeconds(0.5f);
				AudioController.Instance.PlaySound2D("resocket_eyeball", MixerGroup.TableObjectsSFX, 1f, 0f, null, null, null, null, false);
				AudioController.Instance.PlaySound2D("wizard_projectileimpact", MixerGroup.TableObjectsSFX, 1f, 0f, null, null, null, null, false);
				yield return new WaitForSeconds(1.5f);
				Singleton<ViewManager>.Instance.SwitchToView(View.CardMergeConfirm);
				
				this.confirmStone.Disable();
				this.confirmStone.Exit();
				done = true;
				GameObject.Find("TESTSTONE").GetComponent<BoxCollider>().size = new Vector3(0f, 0f, 0f);
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Twisted and warped by the fungi, a new card emerges. Only through pain can one grow…", -2.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
				yield return new WaitForSeconds(0.3f);
				this.confirmStone = null;
				Destroy(GameObject.Find("TESTSTONE"));
				yield break;
			}

			public IEnumerator sequencer(MergeNode tradeCardsData)
			{
				done = false;
				this.cd = 0;
				GameObject.Find("Player").GetComponentInChildren<ViewManager>().SwitchToView(View.Choices, false, false);
				yield return new WaitForSeconds(1f);
				List<CardInfo> listOfCards = new List<CardInfo>();
				foreach (CardInfo card in RunState.Run.playerDeck.Cards)
				{
					if (mixMatchInfo(card).Count < 1) continue;
					listOfCards.Add(card);
				}
				listOfCards.RemoveAll((CardInfo x) => x.traits.Contains(Trait.Pelt) || x.traits.Contains(Trait.EatsWarrens));
				GameObject theDeck = Singleton<DeckReviewSequencer>.Instance.gameObject;
				theDeck.transform.parent = GameObject.Find("GameTable").transform;
				theDeck.transform.localPosition = new Vector3(0, 5.01f, -2f);
				theDeck.transform.localScale = new Vector3(1, 1, 1);
				Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(Singleton<DeckReviewSequencer>.Instance.cardArray.SelectCardFrom(listOfCards, null, new Action<SelectableCard>(this.selectstatscard)));
				for (int i = 0; i < theDeck.transform.childCount; i++)
				{
					this.cardpickedfromdeck.Add(theDeck.transform.GetChild(i).gameObject.GetComponent<SelectableCard>());
				}

				GameObject slotMushrooms = Instantiate(GameObject.Find("SlotMushrooms"));
				slotMushrooms.name = "magMushrooms";
				slotMushrooms.transform.parent = base.transform;
				slotMushrooms.transform.localPosition = new Vector3(0, 0, 2);

				for (int i = 0; i < slotMushrooms.transform.childCount; i++)
				{
					slotMushrooms.transform.GetChild(i).gameObject.SetActive(true);
					yield return new WaitForSeconds(0.15f);
				}
				if (!SavedVars.LearnedMechanics.Contains("mushrooms") && !SaveManager.saveFile.ascensionActive)
				{
					SavedVars.LearnedMechanics += "mushrooms;";

					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("You encounter the abnormally disgusting fungi that infests this dungeon.", -2.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("It is said to possess strange properties..", -2.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("The mushrooms yearn for two cards they can [c:g1]merge[c:] together..", -2.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Using some.. highly forbidden means.", -2.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
					
				}
				else
				{
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("You encounter the disgusting fungi yet again..", -2.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("The fungi yearn for a card they can use as a [c:g1]host[c:].. to attach to.", -2.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
				}
				if (listOfCards.Count < 2)
				{
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Yet... It seems you do not have two cards worthy of the fungi's touch. Wearisome.", -2.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
					base.StartCoroutine(WaitThenDestroy(GameObject.Find("magMushrooms"), 0.5f));
					Singleton<GameFlowManager>.Instance.TransitionToGameState(GameState.Map, null);
				}
				yield break;
			}

			public int i = 0;

			public int card = 0;

			public int cd = 0;

			public SelectableCard firstComponent;
			public SelectableCard otherComponent;
			public List<SelectableCard> cardpicked = new List<SelectableCard>();
			public List<List<CardInfo>> colours = new List<List<CardInfo>> { new List<CardInfo>(), new List<CardInfo>(), new List<CardInfo>() };
			public List<GameObject> createdGroups = new List<GameObject>();

			public List<SelectableCard> cardpickedfromdeck = new List<SelectableCard>();

			public List<SelectableCard> created = new List<SelectableCard>();
		}

	

		public class enchant : CardChoicesSequencer
		{
			public List<List<Ability>> tier1 = new List<List<Ability>> { new List<Ability> { Ability.Flying, Ability.Reach, SigilCode.GemGuardianFix.ability, Ability.DebuffEnemy, SigilCode.MagDropRubyOnDeath.ability, SigilCode.MagDropEmeraldOnDeath.ability, SigilCode.MoxStrafe.ability }, new List<Ability> { Ability.ExplodeOnDeath, Ability.BuffEnemy, Ability.ExplodeGems, Ability.Submerge, Ability.MoveBeside, Ability.StrafePush, Ability.SwapStats, Ability.EdaxioTorso } };
			public List<List<Ability>> tier2 = new List<List<Ability>> { new List<Ability> { Ability.Sharp, Ability.Sniper, Ability.Flying, Ability.Reach, SigilCode.GemGuardianFix.ability, Ability.BuffNeighbours, Ability.DebuffEnemy, SigilCode.MagDropRubyOnDeath.ability, SigilCode.MagDropEmeraldOnDeath.ability, SigilCode.BoneMarrow.ability }, new List<Ability> { Ability.ExplodeOnDeath, Ability.SwapStats, Ability.EdaxioLegs, SigilCode.MoxCycling.ability, Ability.GemDependant, SigilCode.FamiliarA.ability, SigilCode.RandomPower.ability, Ability.EdaxioTorso, Ability.RandomAbility } };
			public List<List<Ability>> tier3 = new List<List<Ability>> { new List<Ability> { Ability.Sharp, Ability.Sniper, SigilCode.GemGuardianFix.ability, Ability.BuffGems, SigilCode.MagDropEmeraldOnDeath.ability, SigilCode.MagDropSapphireOnDeath.ability, Ability.EdaxioHead, SigilCode.FecundityCycle.ability, SigilCode.BoneMarrow.ability }, new List<Ability> { Ability.EdaxioLegs, Ability.SwapStats, SigilCode.GemAbsorber.ability, SigilCode.MoxCycling.ability, SigilCode.MagDropSpear.ability, SigilCode.RandomPower.ability, Ability.RandomAbility } };
			public List<List<Ability>> tier4 = new List<List<Ability>> { new List<Ability> { SigilCode.BoneMarrow.ability, Ability.Sniper, SigilCode.BlueMageDraw.ability, SigilCode.OrluHit.ability, Ability.Deathtouch, Ability.EdaxioHead, SigilCode.FecundityCycle.ability, Ability.BuffGems, SigilCode.AstralProjection.ability, SigilCode.FrostyA.ability, SigilCode.MoxSelect.ability }, new List<Ability> { SigilCode.MidasTouchA.ability, Ability.EdaxioArms, SigilCode.GemAbsorber.ability, Ability.Sacrificial, SigilCode.MagDropSpear.ability, SigilCode.GoobertDebuff.ability, SigilCode.RandomPower.ability, SigilCode.WhirlwindSpell.ability, Ability.SwapStats } };
			public List<List<Ability>> tier5 = new List<List<Ability>> { new List<Ability> { Ability.SplitStrike, SigilCode.LifeSteal.ability, Ability.Tutor, SigilCode.OrluHit.ability, SigilCode.FrostyA.ability, SigilCode.FecundityCycle.ability, SigilCode.AstralProjection.ability, SigilCode.MoxSelect.ability }, new List<Ability> { SigilCode.MidasTouchA.ability, Ability.Sacrificial, SigilCode.MagDropSpear.ability, SigilCode.GoobertDebuff.ability, SigilCode.WhirlwindSpell.ability, SigilCode.RandomPower.ability, SigilCode.GemAbsorber.ability } };

			public List<Ability> selected = new List<Ability>();
			public ConfirmStoneButton confirmStone { get; set; }

			public ConfirmStoneButton confirmStoneTwo { get; set; }

			public string sacrificingWho = "idk";

			public bool doneSacrifice = false;
			public void removeselectablecardfromdeck(SelectableCard component)
			{
				base.StartCoroutine(this.removeselectablecardfromdeckie(component));
			}

			public void cardpickingupscropt(SelectableCard component)
			{
				GameObject fireSlot = GameObject.Find("enchantmentSlot");
				if (timesDone > 0)
				{
					Destroy(fireSlot);
					Destroy(GameObject.Find("TBruins"));
					confirmStone.Disable();
					confirmStoneTwo.Disable();
					Destroy(base.transform.Find("TESTSTONE").gameObject);
					Destroy(base.transform.Find("TESTTWO").gameObject);
					component.ExitBoard(0.3f, new Vector3(-1f, -1f, 6f));
					Singleton<ViewManager>.Instance.SwitchToView(View.Default, false, true);
					//base.StartCoroutine(LeshyAnimationController.Instance.TakeOffMask());
					bool flag3 = Singleton<GameFlowManager>.Instance != null;
					if (flag3)
					{
						Singleton<GameFlowManager>.Instance.TransitionToGameState(GameState.Map, null);
					}
					SaveManager.SaveToFile(true);
				}
				else
				{
					Singleton<ViewManager>.Instance.SwitchToView(View.MapDefault);
					Tween.LocalPosition(fireSlot.transform, new Vector3(0.6001f, 5f, 2.46f), 0.3f, 0.2f, null, Tween.LoopType.None, null, null, true);
					Tween.LocalPosition(GameObject.Find("TBruins").transform, new Vector3(0, 0, 0), 0.3f, 0.2f, null, Tween.LoopType.None, null, null, true);
					component.ExitBoard(0.3f, new Vector3(-1f, -1f, 6f));
					if (!doneSacrifice)
					{
						GameObject.Find("TESTSTONE").GetComponent<BoxCollider>().size = new Vector3(0f, 0f, 0f);
						GameObject.Find("TESTSTONE").SetActive(false);
					}
					GameObject.Find("TESTTWO").GetComponent<BoxCollider>().size = new Vector3(0f, 0f, 0f);
					GameObject.Find("TESTTWO").SetActive(false);
					List<CardInfo> deck = new List<CardInfo>(RunState.DeckList);
					deck.RemoveAll((CardInfo x) => x.Abilities.Count >= 4 || x.HasTrait(Trait.EatsWarrens));
					this.cardpickedfromdeck = new List<SelectableCard>();
					GameObject theDeck = Singleton<DeckReviewSequencer>.Instance.gameObject;
					theDeck.transform.parent = GameObject.Find("GameTable").transform;
					theDeck.transform.localPosition = new Vector3(0, 5.01f, -1f);
					theDeck.transform.localScale = new Vector3(1, 1, 1);
					Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(Singleton<DeckReviewSequencer>.Instance.cardArray.SelectCardFrom(deck, null, new Action<SelectableCard>(this.removeselectablecardfromdeck)));
					for (int i = 0; i < theDeck.transform.childCount; i++)
					{
						this.cardpickedfromdeck.Add(theDeck.transform.GetChild(i).gameObject.GetComponent<SelectableCard>());
					}
					if (deck.Count < 1)
					{
						base.StartCoroutine(getOutOfHere());
					}
				}
			}

			public IEnumerator getOutOfHere()
            {
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput(".. It appears you have nothing else to offer..", -2.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
				SaveManager.SaveToFile();
				Destroy(GameObject.Find("enchantmentSlot"));
				Destroy(GameObject.Find("TBruins"));
				confirmStone.Disable();
				confirmStoneTwo.Disable();
				Destroy(base.transform.Find("TESTSTONE").gameObject);
				Destroy(base.transform.Find("TESTTWO").gameObject);
				Singleton<ViewManager>.Instance.SwitchToView(View.Default, false, true);
				Singleton<GameFlowManager>.Instance.TransitionToGameState(GameState.Map, null);
				yield break;
            }

			public void ApplyMod(CardInfo card, int attack, int health, Ability modAbility, bool nullify = false)
			{
				CardModificationInfo cardModificationInfo = new CardModificationInfo();
				cardModificationInfo.healthAdjustment = health;
				cardModificationInfo.attackAdjustment = attack;
				cardModificationInfo.abilities.Add(modAbility);
				if (nullify)
				{
					cardModificationInfo.nullifyGemsCost = true;
					cardModificationInfo.bloodCostAdjustment = -card.BloodCost;
				}
				RunState.Run.playerDeck.ModifyCard(card, cardModificationInfo);
			}

			public IEnumerator waitforsacrifice(SelectableCard component)
			{
				sacrificingWho = component.Info.name;
				yield return confirmStone.WaitUntilConfirmation();
				if (sacrificingWho != component.Info.name)
				{
					yield break;
				}
				doneSacrifice = true;
				sacValue++;
				foreach (Ability ability in component.Info.abilities)
                {
					if (AbilitiesUtil.GetInfo(ability).powerLevel > 0) { sacValue++; }
					if (AbilitiesUtil.GetInfo(ability).powerLevel >= 4) { sacValue++; }
				}
				if (component.Info.Attack > 1){sacValue++;}

				if (component.Info.Health > 1) { sacValue++; }

				if (component.Info.metaCategories.Contains(CardMetaCategory.Rare)){sacValue += 2;}

				if (component.Info.ModAbilities.Count > 0){sacValue++;}

				if (component.Info.name == "mag_obelisk") { sacValue += 2; }

				GameObject fireSlot = GameObject.Find("enchantmentSlot");

				generateAbilities(sacValue);

				bool displeased = SaveManager.saveFile.ascensionActive && MagnificusMod.Generation.challenges.Contains("DyingBreath");
				fireSlot.GetComponent<Light>().intensity = 2;

				Color color = new Color(1, 1, 1, 1);
				string description = "";

				if (displeased) ChallengeActivationUI.TryShowActivation(KayceeFixes.ChallengeManagement.DyingBreath);
				if (sacValue > 5) sacValue = 5;
				switch (sacValue)
				{
					case 2:
						description = !displeased ? "seem to be slightly improved." : "are unsatisfied..";
						color = !displeased ? new Color(0.65f, 1f, 1f, 1) : new Color(1, 0.175f, 0.175f, 1);
						break;
					case 3:
						description = !displeased ? "dimly light up with sacrifical energy." : "are displeased..";
						color = !displeased ? new Color(0.45f, 1f, 1f, 1) : new Color(1f, 0.125f, 0.125f, 1);
						break;
					case 4:
						description = !displeased ? "light up with supernatural energy." : "are angered..";
						color = !displeased ? new Color(0.25f, 1f, 1f, 1) : new Color(1f, 0.075f, 0.075f, 1);
						break;
					case 5:
						description = !displeased ? "The Enchanted Grounds are absolutely bursting with sacrifical energy." : "The Enchanted Grounds are furious.";
						color = !displeased ? new Color(0f, 1f, 1f, 1) : new Color(1f, 0f, 0f, 1);
						break;
				}

				base.StartCoroutine(Singleton<TextDisplayer>.Instance.ShowUntilInput(string.Format("The Enchanted Grounds {0}", description), -0.25f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true));
				fireSlot.transform.Find("Quad").gameObject.GetComponent<MeshRenderer>().material.color = color;
				fireSlot.transform.Find("FireAnim").gameObject.GetComponent<MeshRenderer>().material.color = color;
				fireSlot.GetComponent<Light>().color = color;

				List<CardModificationInfo> mods = component.Info.mods;
				RunState.Run.playerDeck.RemoveCard(component.Info);

				component.Anim.PlayDeathAnimation();
				confirmStone.Exit();
				confirmStoneTwo.Exit();
				GameObject.Find("TESTSTONE").SetActive(false);
				yield return new WaitForSeconds(0.65f);
				cardpickingupscropt(component);
				yield break;

			}
			public IEnumerator removeselectablecardfromdeckie(SelectableCard component)
			{
				GameObject fireSlot = GameObject.Find("enchantmentSlot");
				this.cardpickedfromdeck.Remove(component);
				this.cd = 0;
				Tween.LocalPosition(fireSlot.transform, new Vector3(0.32f, 5, -0.75f), 0.2f, 0.2f, null, Tween.LoopType.None, null, null, true);
				Tween.LocalPosition(GameObject.Find("TBruins").transform, new Vector3(-0.2195F, 0, -3f), 0.2f, 0.2f, null, Tween.LoopType.None, null, null, true);
				Tween.LocalPosition(component.transform, new Vector3(0.3f, 0.01f, 0.25f), 0.4f, 0.2f, null, Tween.LoopType.None, null, null, true);
				yield return new WaitForSeconds(0.2f);
				bool tutorialDone = SavedVars.LearnedMechanics.Contains("enchantment");
				//ProgressionData.SetMechanicLearned((MechanicsConcept)220);
				bool isTestStone = false;
				if (!doneSacrifice)
				{
					try
					{
						if (!base.transform.Find("TESTSTONE").gameObject.activeSelf)
						{
							isTestStone = true;
						}
					}
					catch { }
					if (!isTestStone)
					{
						GameObject.Instantiate(Resources.Load("prefabs\\specialnodesequences\\ConfirmStoneButton")).name = "TESTSTONE";
						GameObject.Find("TESTSTONE").AddComponent<BoxCollider>().size = new Vector3(1.4f, 0.2f, 2.1f);
					}
					else
					{
						base.transform.Find("TESTSTONE").gameObject.SetActive(true);

					}//0.7 0.0377 0 1
					this.confirmStone = GameObject.Find("TESTSTONE").GetComponentInChildren<ConfirmStoneButton>();
					confirmStone.currentHighlightedColor = new Color(0.5717f, 0, 0, 1);
					confirmStone.currentInteractableColor = new Color(1f, 0, 0, 1);
					GameObject.Find("TESTSTONE").transform.parent = base.transform;
					foreach (SelectableCard VARIABLE in this.cardpickedfromdeck)
					{
						VARIABLE.ExitBoard(0.3f, new Vector3(0.5662f, 4.999f, 2.12f));
					}
					List<SelectableCard>.Enumerator enumerator = default(List<SelectableCard>.Enumerator);
					this.confirmStone.Enter();
					float onex = component.Info.HasTrait(Trait.EatsWarrens) ? 0.25f : -0.4f;
					GameObject.Find("TESTSTONE").transform.localPosition = new Vector3(onex, 10, -2.3f);
					Tween.LocalPosition(GameObject.Find("TESTSTONE").transform, new Vector3(onex, 5, -2.3f), 0.15f, 0.25f);
					this.confirmStone.SetEnabled(true);
				}
				isTestStone = false;
				try
				{
					if (!base.transform.Find("TESTTWO").gameObject.activeSelf)
					{
						isTestStone = true;
					}
				}
				catch { }
				if (!isTestStone)
				{
					GameObject.Instantiate(Resources.Load("prefabs\\specialnodesequences\\ConfirmStoneButton")).name = "TESTTWO";
					GameObject.Find("TESTTWO").AddComponent<BoxCollider>().size = new Vector3(1.4f, 0.2f, 2.1f);
				}
				else
				{
					base.transform.Find("TESTTWO").gameObject.SetActive(true);

				}//0.7 0.0377 0 1
				GameObject.Find("TESTTWO").transform.Find("Anim").Find("model").Find("ConfirmButton").Find("Quad").gameObject.GetComponent<MeshRenderer>().material.color = new Color(1f, 0.66f, 0.134f, 1);
				GameObject.Find("TESTTWO").transform.Find("Anim").Find("model").Find("ConfirmButton").Find("Quad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = (Resources.Load("art/cards/statboost_button") as Texture2D);
				this.confirmStoneTwo = GameObject.Find("TESTTWO").GetComponentInChildren<ConfirmStoneButton>();
				confirmStoneTwo.currentHighlightedColor = new Color(0.6917f, 0.4838f, 0, 1);
				confirmStoneTwo.currentInteractableColor = new Color(1f, 0.5936f, 0, 1);
				GameObject.Find("TESTTWO").transform.parent = base.transform;
				foreach (SelectableCard VARIABLE in this.cardpickedfromdeck)
				{
					VARIABLE.ExitBoard(0.3f, new Vector3(0.5662f, 4.999f, 2.12f));
				}
				if (!component.Info.HasTrait(Trait.EatsWarrens))
				{
					this.confirmStoneTwo.Enter();
					float twox = 1;
					if (doneSacrifice) { twox = 0.28f; }
					GameObject.Find("TESTTWO").transform.localPosition = new Vector3(twox, 10, -2.3f);
					Tween.LocalPosition(GameObject.Find("TESTTWO").transform, new Vector3(twox, 5, -2.3f), 0.15f, 0.25f);
					this.confirmStoneTwo.SetEnabled(true);
				} else
                {
					GameObject.Find("TESTTWO").transform.localPosition = new Vector3(0, -10, -2.3f);
				}
				if (!tutorialDone)
				{
					SavedVars.LearnedMechanics += "enchantment;";
					SavedVars.LearnedMechanics += "sacrificesigils;";
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Your " + component.Info.DisplayedNameLocalized + " sits on the enchanted grounds...\nYou could either leave it there, to enchant it..", -0.25f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Or you can slaughter it to improve the enchantment, dictated by the [c:g1]Ethereal Sigils[c:].", -1.0f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("The choice is yours.", -0.25f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);// The choice is yours.
					
				}
				else if (!SavedVars.LearnedMechanics.Contains("sacrificesigils;"))
				{
					SavedVars.LearnedMechanics += "sacrificesigils;";
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("[c:g1]Ethereal Sigils[c:] hover around the grounds.", -1.0f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("You may use them to predict a possible outcome..", -1.0f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
				}
				component.gameObject.GetComponent<BoxCollider>().enabled = true;
				component.Initialize(component.Info, new Action<SelectableCard>(this.cardpickingupscropt), null, false, null);
				base.StartCoroutine(waitforsacrifice(component));
				yield return confirmStoneTwo.WaitUntilConfirmation();
				if (component == null) yield break;

				component.gameObject.GetComponent<BoxCollider>().enabled = true;
				CardModificationInfo cardModificationInfo = new CardModificationInfo();
				//cardModificationInfo.fromCardMerge = true;
				this.confirmStoneTwo.Unpress();
				Tween.LocalPosition(this.confirmStoneTwo.transform.parent.parent.parent, new Vector3(10f, 30.75f, -2.6f), 0.15f, 0.1f, null, Tween.LoopType.None, null, null, true);
				Tween.LocalPosition(this.confirmStone.transform.parent.parent.parent, new Vector3(10f, 30.75f, -2.6f), 0.15f, 0.1f, null, Tween.LoopType.None, null, null, true);

				List<Ability> bannedAbilities = new List<Ability>();
				if (component.Info.SpecialStatIcon != SpecialStatIcon.None) { bannedAbilities.AddRange(new List<Ability> { Ability.EdaxioArms, Ability.EdaxioHead, Ability.EdaxioLegs, Ability.EdaxioTorso, Ability.SwapStats }); }
				if (component.Info.Attack < 1) { bannedAbilities.AddRange(new List<Ability> { Ability.Sniper, Ability.Flying, Ability.SplitStrike, SigilCode.OrluHit.ability, SigilCode.FrostyA.ability, SigilCode.MidasTouchA.ability, Ability.SwapStats  }); }
				List<Ability> modifySelected = new List<Ability>(selected);
				for (int i = 0; i < modifySelected.Count; i++)
                {
					if (bannedAbilities.Contains(modifySelected[i])) { modifySelected.RemoveAt(i); i--; }
                }
				if (modifySelected.Count < 1) { modifySelected = selected; }
				int abilityIdx = SeededRandom.Range(0, modifySelected.Count, SaveManager.SaveFile.GetCurrentRandomSeed());
				Ability selectedAbility = modifySelected[abilityIdx];
				abilityIdx = selected.IndexOf(selectedAbility);
				bool isCurse = (abilityIdx > 1 || SaveManager.saveFile.ascensionActive && MagnificusMod.Generation.challenges.Contains("DyingBreath"));
				int hpChange = 0;
				int atkChange = 0;
				bool nullifyCost = false;

				int curHp = component.Info.Health;
				int curAtk = component.Info.Attack;
				if (selectedAbility == Ability.EdaxioLegs && curHp > 1 || selectedAbility == Ability.EdaxioTorso && curAtk < 1 && curHp > 1)
				{
					selectedAbility = Ability.None;

					curHp -= 1;
					atkChange = curHp;
					curHp = -curHp;
					hpChange = curHp;
					base.StartCoroutine(Singleton<TextDisplayer>.Instance.ShowUntilInput("Your " + component.Info.DisplayedNameLocalized + " has been burdened with Glass Cannon!", -0.25f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true));
				}
				else if (selectedAbility == Ability.EdaxioTorso && curAtk > 0 || selectedAbility == Ability.EdaxioLegs && curHp < 2 && curAtk > 0)
				{
					selectedAbility = Ability.None;

					curAtk -= 1;
					hpChange = curAtk;
					curAtk = -curAtk;
					atkChange = curAtk;
					base.StartCoroutine(Singleton<TextDisplayer>.Instance.ShowUntilInput("Your " + component.Info.DisplayedNameLocalized + " has been burdened with Tank!", -0.25f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true));
				}
				else if (selectedAbility == Ability.EdaxioHead || selectedAbility == Ability.EdaxioLegs || selectedAbility == Ability.EdaxioTorso)
				{
					selectedAbility = Ability.None;
					bool doHp = (Random.RandomRangeInt(0, 100) > 45 || component.Info.name == "ForceMage");
					hpChange = doHp ? 2 : 0;
					atkChange = !doHp ? 1 : 0;
					base.StartCoroutine(Singleton<TextDisplayer>.Instance.ShowUntilInput("Your " + component.Info.DisplayedNameLocalized + " has been blessed!", -0.25f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true));
				}
				else if (selectedAbility == Ability.EdaxioArms)
				{
					selectedAbility = Ability.None;

					curHp -= 1;
					atkChange = curHp + 2;
					curHp = -curHp;
					hpChange = curHp;
					base.StartCoroutine(Singleton<TextDisplayer>.Instance.ShowUntilInput("Your " + component.Info.DisplayedNameLocalized + " has been burdened with Glass Cannon!", -0.25f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true));
				}
				else if (selectedAbility == Ability.GemDependant || selectedAbility == SigilCode.FamiliarA.ability)
				{
					if (component.Info.HasAbility(Ability.GemDependant) && selectedAbility == Ability.GemDependant) { selectedAbility = SigilCode.FamiliarA.ability; }
					else if (component.Info.HasAbility(SigilCode.FamiliarA.ability) && selectedAbility == SigilCode.FamiliarA.ability) { selectedAbility = Ability.GemDependant; }
					if (sacValue > 1)
					{
						hpChange = 1;
						atkChange = (component.Info.name != "ForceMage") ? 1 : 0;
					}
					base.StartCoroutine(Singleton<TextDisplayer>.Instance.ShowUntilInput("Your " + component.Info.DisplayedNameLocalized + " has been burdened!", -0.25f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true));

				}
				else if (selectedAbility == Ability.Sacrificial)
				{
					nullifyCost = true;
					if (component.Info.HasAbility(SigilCode.FamiliarA.ability)) { selectedAbility = Ability.GemDependant; }
					else if (component.Info.HasAbility(Ability.GemDependant)) { selectedAbility = SigilCode.FamiliarA.ability; }
					else
					{
						if (Random.RandomRangeInt(0, 100) > 50) { selectedAbility = Ability.GemDependant; }
						else { selectedAbility = SigilCode.FamiliarA.ability; }
					}
					base.StartCoroutine(Singleton<TextDisplayer>.Instance.ShowUntilInput("Your " + component.Info.DisplayedNameLocalized + " is now free.. But more unstable..", -0.25f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true));

				}
				else
				{
					string abilityName = AbilitiesUtil.GetInfo(selectedAbility).rulebookName;
					base.StartCoroutine(Singleton<TextDisplayer>.Instance.ShowUntilInput( String.Format("Your " + component.Info.DisplayedNameLocalized + " has been {0} with {1}!", (!isCurse) ? "blessed" : "burdened", abilityName), -0.25f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true));
				}

				GameObject abilityIconsParent = GameObject.Find("abilityIconsParent");
				for (int i = 0; i < abilityIconsParent.transform.childCount; i++)
				{
					if (i == abilityIdx)
                    {
						Tween.LocalPosition(abilityIconsParent.transform.GetChild(i), new Vector3(-0.05f, 2f, 0.45f), 0.2f, 0, Tween.EaseInOutStrong);
						continue;
                    }
					Tween.LocalScale(abilityIconsParent.transform.GetChild(i), Vector3.zero, 0.25f, 0f, Tween.EaseIn);
				}
				timesDone++;
				component.SetCardback(Tools.getImage("magcardback.png"));
				component.Anim.PlayTransformAnimation();
				this.ApplyMod(component.Info, atkChange, hpChange, selectedAbility, nullifyCost);
				component.SetInfo(component.Info);
				component.gameObject.GetComponent<BoxCollider>().enabled = true;

				yield break;
			}

			public IEnumerator sequencer(CustomNode14 tradeCardsData)
			{
				doneSacrifice = false;
				sacValue = 1;
				Singleton<ViewManager>.Instance.SwitchToView(View.MapDefault);
				GameObject ruins = GameObject.Instantiate(new GameObject());
				ruins.transform.parent = base.transform;
				ruins.name = "TBruins";
				ruins.transform.localPosition = new Vector3(0, 0, 0);
				GameObject arch1 = GameObject.Instantiate(GameObject.Find("AncientRuins_ArchBroken"));
				arch1.transform.parent = ruins.transform;
				arch1.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
				arch1.transform.localPosition = new Vector3(0.4f, 5f, 3.82f);
				GameObject collumn = GameObject.Instantiate(GameObject.Find("AncientRuins_FullColumn"));
				collumn.transform.parent = ruins.transform;
				collumn.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
				collumn.transform.localPosition = new Vector3(1.5f, 5f, 1.28f);
				collumn.transform.localRotation = Quaternion.Euler(270.1519f, 296.6658f, -0.0019f);
				GameObject fireSlot = GameObject.Instantiate(Singleton<CardStatBoostSequencer>.Instance.selectionSlot.gameObject);
				fireSlot.name = "enchantmentSlot";
				fireSlot.transform.parent = base.transform;
				fireSlot.AddComponent<Light>().intensity = 0;
				fireSlot.GetComponent<Light>().range = 35;
				this.timesDone = 0;
				fireSlot.transform.localPosition = new Vector3(0.6001f, 5f, 2.46f);
				fireSlot.GetComponent<SelectCardFromDeckSlot>().Disable();
				Plugin p = new Plugin();
				Texture2D fire = Tools.getImage("sacrifice.png");
				Texture2D slot = Tools.getImage("fireSlot.png");
				fireSlot.transform.Find("Quad").gameObject.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1, 1);
				fireSlot.transform.Find("FireAnim").gameObject.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1, 1);
				fireSlot.SetActive(true);
				AnimatingSprite spritet = fireSlot.GetComponentInChildren<AnimatingSprite>();
				int num;
				for (int z = 0; z < spritet.textureFrames.Count; z = num + 1)
				{
					spritet.textureFrames[z] = fire;
					num = z;
				}
				fireSlot.GetComponentInChildren<SelectCardFromDeckSlot>().specificRenderers[0].material.mainTexture = slot;
				fireSlot.GetComponent<SelectCardFromDeckSlot>().SetColors(GameColors.Instance.brightBlue, GameColors.Instance.darkBlue, GameColors.Instance.seafoam);

				GameObject abilityIconsParent = new GameObject("abilityIconsParent");
				abilityIconsParent.transform.parent = fireSlot.transform;
				abilityIconsParent.transform.localPosition = Vector3.zero;

				GameObject abilityIconInstance = GameObject.Instantiate(GameObject.Find("CardElements").transform.Find("CardAbilityIcons_Part3").Find("DefaultIcons_1Ability").gameObject); abilityIconInstance.name = "sacrificeAbility0";
				abilityIconInstance.layer = 0;
				abilityIconInstance.SetActive(true);
				abilityIconInstance.transform.parent = abilityIconsParent.transform;
				abilityIconInstance.transform.localPosition = new Vector3(-0.75f, 1.5f, 0.45f);
				abilityIconInstance.transform.localRotation = Quaternion.Euler(35, 350, 0);
				abilityIconInstance.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1, 0.5f);
				abilityIconInstance.GetComponent<AbilityIconInteractable>().AssignAbility(Ability.BeesOnHit, CardLoader.GetCardByName("JuniorSage"), null);
				for (int i = 1; i < 4; i++)
                {
					GameObject iconInstance = GameObject.Instantiate(abilityIconInstance);
					iconInstance.name = "sacrificeAbility" + i;
					iconInstance.transform.parent = abilityIconsParent.transform;
					float xMod = (i < 2) ? -0.75f : -1.0f;
					xMod += (i % 2 != 0) ? 1 : 0;
					if (i == 3) xMod += 0.5f;
					iconInstance.transform.localPosition = new Vector3(xMod, 1.5f, (i < 2) ? 0.45f: -1);
					iconInstance.transform.localRotation = Quaternion.Euler((i < 2) ? 35 : 55, (i % 2 != 0) ? 10 : 350, 0);
				}
				abilityIconsParent.AddComponent<SineWaveMovement>().speed = 0.5f;
				abilityIconsParent.GetComponent<SineWaveMovement>().xMagnitude = 0.025f;
				abilityIconsParent.GetComponent<SineWaveMovement>().yMagnitude = 0.05f;
				generateAbilities(0);
				base.StartCoroutine(Singleton<TextDisplayer>.Instance.ShowUntilInput("The [c:g1]Sacrifical Grounds[c:] stand before you.\nLegends tell of cards growing exponentially in power here, under the right circumstances..", -2.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true));
				yield return new WaitForSeconds(1.25f);
				this.card = 0;
				List<CardInfo> deck = new List<CardInfo>();
				foreach (CardInfo card in RunState.Run.playerDeck.Cards)
				{
					deck.Add(card);
				}

				deck.RemoveAll((CardInfo x) => x.Abilities.Count >= 4 || x.HasTrait(Trait.EatsWarrens));
				GameObject theDeck = Singleton<DeckReviewSequencer>.Instance.gameObject;
				theDeck.transform.parent = GameObject.Find("GameTable").transform;
				theDeck.transform.localPosition = new Vector3(0, 5.01f, -1f);
				theDeck.transform.localScale = new Vector3(1, 1, 1);
				Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(Singleton<DeckReviewSequencer>.Instance.cardArray.SelectCardFrom(deck, null, new Action<SelectableCard>(this.removeselectablecardfromdeck)));
				for (int i = 0; i < theDeck.transform.childCount; i++)
				{
					this.cardpickedfromdeck.Add(theDeck.transform.GetChild(i).gameObject.GetComponent<SelectableCard>());
				}
				if (deck.Count < 1)
				{
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput(".. However, it appears that you don't have anything to offer to the enchanted grounds..", -2.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
					Destroy(fireSlot);
					Destroy(ruins);
					Singleton<ViewManager>.Instance.SwitchToView(View.Default, false, true);
					Singleton<GameFlowManager>.Instance.TransitionToGameState(GameState.Map, null);
				}
				yield break;
			}

			public void generateAbilities(int sacValue)
            {
				List<List<Ability>> tier = tier1;

				if (sacValue > 5) sacValue = 5;
				bool displeased = SaveManager.saveFile.ascensionActive && MagnificusMod.Generation.challenges.Contains("DyingBreath");

				switch (sacValue)
				{
					case 1:
						tier = tier1;
						break;
					case 2:
						tier = tier2;
						break;
					case 3:
						tier = tier3;
						break;
					case 4:
						tier = tier4;
						break;
					case 5:
						tier = tier5;
						break;
				}
				List<Ability> bannedAbilities = new List<Ability>();

				selected = new List<Ability>();

				for (int i = 0; i < 4; i++)
                {
					int pool = (i < 2 && !displeased) ? 0 : 1;
					int card = SeededRandom.Range(0, tier[pool].Count, SaveManager.SaveFile.GetCurrentRandomSeed());
					selected.Add(tier[pool][card]);
					tier[pool].RemoveAt(card);
                }
				GameObject abilityIconsParent = GameObject.Find("abilityIconsParent");
				for (int i = 0; i < abilityIconsParent.transform.childCount; i++)
                {
					abilityIconsParent.transform.GetChild(i).gameObject.GetComponent<AbilityIconInteractable>().AssignAbility(selected[i], CardLoader.GetCardByName("JuniorSage"), null);
					abilityIconsParent.transform.GetChild(i).gameObject.GetComponent<AbilityIconInteractable>().Ability = selected[i];
					abilityIconsParent.transform.GetChild(i).gameObject.SetActive(true);
				}
			}

			public int i = 0;

			public int cd = 0;

			public int selectingoptions = 3;

			public int timesDone = 0;

			public int sacValue = 1;

			public bool dead = false;

			public List<SelectableCard> cardpicked = new List<SelectableCard>();

			public List<SelectableCard> cardpickedfromdeck = new List<SelectableCard>();

			public List<SelectableCard> created = new List<SelectableCard>();

			public int card;

		}

		public class paintdeathcard : CardChoicesSequencer
		{

			public ConfirmStoneButton confirmStone { get; set; }

			public ConfirmStoneButton confirmStoneTwo { get; set; }

			public string sacrificingWho = "idk";

			public bool doneSacrifice = false;
			public void imbueStats(SelectableCard card)
			{
				SelectableCard component = GameObject.Find("DeathCard").GetComponent<SelectableCard>();
				component.SetInfo(CardLoader.GetCardByName("mag_deathcardbase"));
				component.gameObject.name = "DeathCard";
				CardModificationInfo statsMod = new CardModificationInfo();
				component.Info.mods.Add(statsMod);
				component.Info.mods[0].attackAdjustment = card.Info.Attack;
				component.Info.mods[0].healthAdjustment = card.Info.Health;
				component.renderInfo.attack = card.Info.Attack;
				component.renderInfo.health = card.Info.Health;
				component.renderInfo.hiddenAttack = false;
				component.renderInfo.hiddenHealth = false;
				component.renderInfo.healthTextColor = new Color(0, 0, 0, 1);
				component.RenderCard();
				card.gameObject.GetComponent<BoxCollider>().size = new Vector3(0, 0, 0);
				card.gameObject.GetComponent<SineWaveMovement>().enabled = false;
				AudioController.Instance.PlaySound2D("magnificus_brush_splatter_color", MixerGroup.None, 0.5f, 0f, null, null, null, null, false);
				card.SetCardback(Tools.getImage("magcardback.png"));
				card.Anim.PlayTransformAnimation();
				statCard = card.Info;
				SaveManager.SaveToFile();
				base.StartCoroutine(startSigilCards(card.Info));
				base.StartCoroutine(clearCrads(card));
			}

			public void imbueSigils(SelectableCard card)
			{
				SelectableCard component = GameObject.Find("DeathCard").GetComponent<SelectableCard>();
				foreach (Ability ability in card.Info.abilities)
				{
					component.Info.abilities.Add(ability);
				}
				foreach (Ability modability in card.Info.ModAbilities)
				{
					component.Info.mods[0].abilities.Add(modability);
				}
				component.renderInfo.temporaryMods.Add(component.Info.mods[0]);
				component.RenderCard();
				AudioController.Instance.PlaySound2D("magnificus_brush_splatter_color", MixerGroup.None, 0.5f, 0f, null, null, null, null, false);
				card.SetCardback(Tools.getImage("magcardback.png"));
				card.Anim.PlayTransformAnimation();
				SaveManager.SaveToFile();
				base.StartCoroutine(clearCrads(card));
				base.StartCoroutine(this.namingSequence());
			}

			public IEnumerator namingSequence()
            {
				yield return new WaitForSeconds(1f);
				Singleton<ViewManager>.Instance.SwitchToView(View.Default, false, true);
				yield return new WaitForSeconds(0.65f);
				Tween.Position(GameObject.Find("Player").transform, new Vector3(61.75f, 9.5f, -65), 0.7f, 0);
				Tween.LocalRotation(GameObject.Find("MagnificusAnim").transform, Quaternion.Euler(0, 320, 0), 1f, 0.5f);
				yield return new WaitForSeconds(0.7f);
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("You have the honours of naming it.", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
				GameObject keyBoard = new GameObject("keyboar");
				keyBoard.AddComponent<KeyboardInputHandler>().maxInputLength = 16;
				keyBoard.GetComponent<KeyboardInputHandler>().allowPasteClipboard = false;
				keyboardInput = keyBoard.GetComponent<KeyboardInputHandler>();
				yield return this.EnterNameForCard(GameObject.Find("DeathCard").GetComponent<SelectableCard>(), GameObject.Find("DeathCard").GetComponent<SelectableCard>().Info.mods[0]);
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Finished?", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("The [c:g1]cost[c:] and [c:g2]portrait[c:] I will handle myself..", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
				Tween.Position(GameObject.Find("Player").transform, new Vector3(80f, 9.5f, -65), 1f, 0);
				Tween.Position(GameObject.Find("easel(Clone)").transform, new Vector3(80.575f, 11f, -93f), 0.75f, 0.5f);
				Tween.LocalRotation(GameObject.Find("easel(Clone)").transform, Quaternion.Euler(0, 210, 0), 1f, 0.5f);
				Tween.LocalRotation(GameObject.Find("MagnificusAnim").transform, Quaternion.Euler(0, 180, 0), 1f, 0.5f);
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("It was nice meeting you, my student.", -1.5f, 0.5f, Emotion.Quiet, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("But this is where we say farewell..", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Just hold still for a second.", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
				MagnificusAnimationController magnificusAnimationController = GameObject.Find("MagnificusAnim").GetComponent<MagnificusAnimationController>();

				List<GemType> possibleGemTypes = new List<GemType> { GemType.Green };
				foreach(CardInfo card in RunState.Run.playerDeck.Cards)
                {
					if (card.gemsCost.Count > 0)
                    {
						possibleGemTypes.Add(card.gemsCost[0]);
                    }
                }
				SelectableCard component = GameObject.Find("DeathCard").GetComponent<SelectableCard>();
				component.Info.mods[0].addGemCost = new List<GemType> { possibleGemTypes[UnityEngine.Random.RandomRangeInt(0, possibleGemTypes.Count)] };
				component.Info.mods[0].buildACardPortraitInfo = new BuildACardPortraitInfo();
				component.Info.mods[0].buildACardPortraitInfo.spriteIndices = new int[3];
				component.Info.mods[0].buildACardPortraitInfo.spriteIndices[0] = ((int)RunState.Run.playerAvatarHead);
				component.Info.mods[0].buildACardPortraitInfo.spriteIndices[1] = ((int)RunState.Run.playerAvatarBody);
				component.Info.mods[0].buildACardPortraitInfo.spriteIndices[2] = ((int)RunState.Run.playerAvatarArms);
				component.Info.mods[0].decalIds.Add("MAGNIFICUSDEATHCARD");
				SaveManager.saveFile.part3Data.bountyHunterMods.Add(component.Info.mods[0]);
				if (!SavedVars.LearnedMechanics.Contains("died"))
				{
					SavedVars.LearnedMechanics += "died;";
				}
				SaveManager.SaveToFile();
				yield return new WaitForSeconds(1.5f);
				magnificusAnimationController.SetHeadTrigger("brush_vertical_1");
				AudioController.Instance.PlaySound2D("magnificus_brush_splatter_color", MixerGroup.None, 0.125f, 0f, null, null, null, null, false);
				yield return new WaitForSeconds(1.25f);
				magnificusAnimationController.SetHeadTrigger("brush_vertical_2");
				AudioController.Instance.PlaySound2D("magnificus_brush_splatter_bleach", MixerGroup.None, 0.125f, 0f, null, null, null, null, false);
				yield return new WaitForSeconds(1.25f);
				magnificusAnimationController.SetHeadTrigger("brush_vertical_3");
				AudioController.Instance.PlaySound2D("magnificus_brush_splatter_color", MixerGroup.None, 0.125f, 0f, null, null, null, null, false);
				yield return new WaitForSeconds(1.25f);
				magnificusAnimationController.SetHeadTrigger("brush_vertical_4");
				AudioController.Instance.PlaySound2D("magnificus_brush_splatter_bleach", MixerGroup.None, 0.15f, 0f, null, null, null, null, false);
				yield return new WaitForSeconds(0.75f);
				magnificusAnimationController.SetHeadTrigger("brush_vertical_1");
				AudioController.Instance.PlaySound2D("magnificus_brush_splatter_bleach", MixerGroup.None, 0.15f, 0f, null, null, null, null, false);
				yield return new WaitForSeconds(0.75f);
				magnificusAnimationController.SetHeadTrigger("brush_vertical_2");
				AudioController.Instance.PlaySound2D("magnificus_brush_splatter_color", MixerGroup.None, 0.15f, 0f, null, null, null, null, false);
				yield return new WaitForSeconds(1.5f);
				magnificusAnimationController.SetHeadTrigger("brush_vertical_3");
				AudioController.Instance.PlaySound2D("magnificus_brush_splatter_color", MixerGroup.None, 0.15f, 0f, null, null, null, null, false);
				File.WriteAllText(SaveManager.SaveFolderPath + "MagnificusModSave.gwsave", SaveManager.ToJSON(MagSave.GetNodeStuff(true, true)));
				AudioController.Instance.StopAllLoops();
				Singleton<InteractionCursor>.Instance.SetHidden(true);
				Singleton<UIManager>.Instance.Effects.GetEffect<ScreenColorEffect>().SetColor(GameColors.Instance.nearBlack);
				Singleton<UIManager>.Instance.Effects.GetEffect<ScreenColorEffect>().SetIntensity(1f, float.MaxValue);
				yield return new WaitForSeconds(0.9f);
				Generation.ResetMagRun();
				yield break;
            }

			private KeyboardInputHandler keyboardInput = new KeyboardInputHandler();

			private IEnumerator EnterNameForCard(SelectableCard card, CardModificationInfo mod)
			{
				keyboardInput = keyboardInput.GetComponent<KeyboardInputHandler>();
				while (!this.keyboardInput.EnteredInput)
				{
					string b = this.keyboardInput.KeyboardInput;
					if (mod.nameReplacement != b)
					{
						AudioController.Instance.PlaySound3D("map_pen", MixerGroup.ExplorationSFX, card.transform.position, 0.6f, 0.5f, new AudioParams.Pitch(AudioParams.Pitch.Variation.VerySmall), null, new AudioParams.Randomization(true), null, false);
					}
					RunState.Run.deathcardName = (mod.nameReplacement = this.keyboardInput.KeyboardInput);
					yield return this.RenderCardWithName(card, mod, Mathf.Sin(Time.time * 10f) > 0f);
				}
				base.StartCoroutine(this.RenderCardWithName(card, mod, false));
				yield break;
			}

			private IEnumerator RenderCardWithName(SelectableCard card, CardModificationInfo mod, bool withIBeam)
			{
				string str = withIBeam ? "I" : "<color=#00000000>I</color>";
				string preRenderName = mod.nameReplacement;
				mod.nameReplacement += str;
				card.RenderCard();
				card.SetInteractionEnabled(false);
				yield return new WaitForEndOfFrame();
				yield return new WaitForEndOfFrame();
				yield return new WaitForEndOfFrame();
				mod.nameReplacement = preRenderName;
				yield break;
			}

			public IEnumerator startSigilCards(CardInfo exclude)
			{
				yield return new WaitForSeconds(1f);
				List<CardInfo> deck = new List<CardInfo>();
				foreach (CardInfo card in RunState.Run.playerDeck.Cards)
				{
					if (card != statCard)
					{
						deck.Add(card);
					}
				}
				deck.RemoveAll((CardInfo x) => x.HasTrait(Trait.EatsWarrens) || x.name.Contains("edaxio"));
				cardChoice = new List<SelectableCard>();
				for (int i = 0; i < 3; i++)
				{
					GameObject cardObject = GameObject.Instantiate<GameObject>(Singleton<SelectableCardArray>.Instance.selectableCardPrefab);
					cardObject.transform.SetParent(base.transform);
					SelectableCard component2 = cardObject.GetComponent<SelectableCard>();
					int rand = UnityEngine.Random.RandomRangeInt(0, deck.Count);

					component2.Initialize(deck[rand], new Action<SelectableCard>(Singleton<SelectableCardArray>.Instance.OnCardSelected), null, false, new Action<SelectableCard>(Singleton<SelectableCardArray>.Instance.OnCardInspected));
					component2.SetEnabled(false);
					Singleton<SelectableCardArray>.Instance.displayedCards.Add(component2);
					Singleton<SelectableCardArray>.Instance.TweenInCard(component2.transform, new Vector3(-1.8f + (1.8f * i), 5.1f, -2.9f), 0f, false);
					component2.transform.localRotation = Quaternion.Euler(90, 0, 0);
					if (i == 0) { component2.transform.localRotation = Quaternion.Euler(90, 15, 0); }
					else if (i == 2) { component2.transform.localRotation = Quaternion.Euler(90, -15, 0); }
					component2.Anim.PlayQuickRiffleSound();
					component2.Initialize(deck[rand], new Action<SelectableCard>(this.imbueSigils), null, false, null);
					component2.GetComponent<Collider>().enabled = true;
					cardChoice.Add(component2);
					deck.RemoveAt(rand);
					yield return new WaitForSeconds(0.1f);
					component2.gameObject.AddComponent<SineWaveMovement>().originalPosition = new Vector3(-1.8f + (1.8f * i), 3.6f, -2.9f);
					component2.gameObject.GetComponent<SineWaveMovement>().yMagnitude = 0.2f;
					component2.gameObject.GetComponent<SineWaveMovement>().speed = 0.1f;
				}
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("The [c:g1]sigils[c:].", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);

				yield break;
			}

			public void cardpickingupscropt(SelectableCard component)
			{
				component.ExitBoard(0.3f, new Vector3(-1f, -1f, 6f));
				Singleton<ViewManager>.Instance.SwitchToView(View.Default, false, true);
				//base.StartCoroutine(LeshyAnimationController.Instance.TakeOffMask());
				bool flag3 = Singleton<GameFlowManager>.Instance != null;
				
			}

			public void ApplyMod(CardInfo card, int attack, int health, Ability modAbility, bool nullify = false)
			{
				CardModificationInfo cardModificationInfo = new CardModificationInfo();
				cardModificationInfo.healthAdjustment = health;
				cardModificationInfo.attackAdjustment = attack;
				cardModificationInfo.abilities.Add(modAbility);
				if (nullify)
				{
					cardModificationInfo.nullifyGemsCost = true;
					cardModificationInfo.bloodCostAdjustment = -card.BloodCost;
				}
				RunState.Run.playerDeck.ModifyCard(card, cardModificationInfo);
			}

	
			public IEnumerator imbueStatsie(SelectableCard component)
			{
				GameObject fireSlot = GameObject.Find("enchantmentSlot");
				this.cardpickedfromdeck.Remove(component);
				this.cd = 0;
				Tween.LocalPosition(fireSlot.transform, new Vector3(0.32f, 5, -0.75f), 0.2f, 0.2f, null, Tween.LoopType.None, null, null, true);
				Tween.LocalPosition(GameObject.Find("TBruins").transform, new Vector3(-0.2195F, 0, -3f), 0.2f, 0.2f, null, Tween.LoopType.None, null, null, true);
				Tween.LocalPosition(component.transform, new Vector3(0.3f, 0.01f, 0.25f), 0.4f, 0.2f, null, Tween.LoopType.None, null, null, true);
				yield return new WaitForSeconds(0.2f);
				yield break;
			}

			public IEnumerator sequencer(CustomNode14 tradeCardsData)
			{
				AudioController.Instance.Start();
				doneSacrifice = false;
				sacValue = 1;
				Singleton<ViewManager>.Instance.SwitchToView(View.Choices, false, true);
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("I will base it off of cards in your deck.", -2.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("First, the stats.", -2.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);

				yield return new WaitForSeconds(1.25f);
				this.card = 0;
				List<CardInfo> deck = new List<CardInfo>();
				foreach (CardInfo card in RunState.Run.playerDeck.Cards)
				{
					deck.Add(card);
				}
				deck.RemoveAll((CardInfo x) => x.HasTrait(Trait.EatsWarrens));
				for (int i = 0; i < 3; i++)
				{
					GameObject cardObject = GameObject.Instantiate<GameObject>(Singleton<SelectableCardArray>.Instance.selectableCardPrefab);
					cardObject.transform.SetParent(base.transform);
					SelectableCard component2 = cardObject.GetComponent<SelectableCard>();
					int rand = UnityEngine.Random.RandomRangeInt(0, deck.Count);

					component2.Initialize(deck[rand], new Action<SelectableCard>(Singleton<SelectableCardArray>.Instance.OnCardSelected), null, false, new Action<SelectableCard>(Singleton<SelectableCardArray>.Instance.OnCardInspected));
					component2.SetEnabled(false);
					Singleton<SelectableCardArray>.Instance.displayedCards.Add(component2);
					Singleton<SelectableCardArray>.Instance.TweenInCard(component2.transform, new Vector3(-1.8f + (1.8f * i), 5.1f, -2.9f), 0f, false);
					component2.transform.localRotation = Quaternion.Euler(90, 0, 0);
					if (i == 0) { component2.transform.localRotation = Quaternion.Euler(90, 15, 0); }
					else if (i == 2) { component2.transform.localRotation = Quaternion.Euler(90, -15, 0); }
					component2.Anim.PlayQuickRiffleSound();
					component2.Initialize(deck[rand], new Action<SelectableCard>(this.imbueStats), null, false, null);
					component2.GetComponent<Collider>().enabled = true;
					cardChoice.Add(component2);
					deck.RemoveAt(rand);
					yield return new WaitForSeconds(0.1f);
					component2.gameObject.AddComponent<SineWaveMovement>().originalPosition = new Vector3(-1.8f + (1.8f * i), 3.6f, -2.9f);
					component2.gameObject.GetComponent<SineWaveMovement>().yMagnitude = 0.2f;
					component2.gameObject.GetComponent<SineWaveMovement>().speed = 0.1f;
				}
				yield break;
			}

			public IEnumerator clearCrads(SelectableCard card)
			{
				foreach (SelectableCard crad in cardChoice)
				{
					crad.gameObject.GetComponent<SineWaveMovement>().enabled = false;
					if (crad == card)
					{
						base.StartCoroutine(killThisOne(crad));
						continue;
					}
					Tween.LocalPosition(crad.transform, new Vector3(crad.transform.position.x, 5.1f, 2.9f), 0.5f, 0.75f);
				}
				yield break;
			}

			public IEnumerator killThisOne(SelectableCard crad)
			{
				yield return new WaitForSeconds(0.55f);
				crad.Anim.PlayDeathAnimation();
				Tween.LocalPosition(crad.transform, new Vector3(crad.transform.position.x, 5.1f, 2.9f), 0.5f, 0.25f);
				yield break;
			}

			public int i = 0;

			public int cd = 0;

			public int selectingoptions = 3;

			public int timesDone = 0;

			public int sacValue = 1;

			public bool dead = false;

			public CardInfo statCard;

			public List<SelectableCard> cardChoice = new List<SelectableCard>();

			public List<SelectableCard> cardpickedfromdeck = new List<SelectableCard>();

			public List<SelectableCard> created = new List<SelectableCard>();

			public int card;

		}
		public class spellchoice : CardChoicesSequencer
		{

			public ConfirmStoneButton confirmStone { get; set; }

			public ConfirmStoneButton confirmStoneTwo { get; set; }

			public void cardpickingupscropt(SelectableCard component)
			{
				if (component.Anim.FaceDown)
				{
					Tween.LocalRotation(component.transform, new Vector3(90, 0, 0), 0.1f, 0);
					component.SetFaceDown(false);
					if (!string.IsNullOrEmpty(component.Info.description) && !ProgressionData.IntroducedCard(component.Info))
					{
						ProgressionData.SetCardIntroduced(component.Info);
					}
				}
				else
				{
					ViewManager instance = Singleton<ViewManager>.Instance;
					instance.ViewChanged = (Action<View, View>)Delegate.Remove(instance.ViewChanged, new Action<View, View>(ViewChanged));

					Singleton<ViewController>.Instance.LockState = ViewLockState.Locked;
					Singleton<ViewController>.Instance.allowedViews = new List<View>();
					component.coll.enabled = false;
					cardpickedfromdeck.Remove(component);

					if (RunState.Run.playerDeck.Cards.FindAll((CardInfo x) => x.HasTrait(Trait.EatsWarrens)).Count >= ( (SaveManager.saveFile.ascensionActive && Generation.challenges.Contains("SmallSpellbook")) ? 4 : 8) )
					{
						base.StartCoroutine(tradeSequence(component));
						return;
					}
					Singleton<ViewManager>.Instance.SwitchToView(View.Choices);

					if (Singleton<DeckSpellBook>.Instance != null) 
						GameObject.Destroy(Singleton<DeckSpellBook>.Instance.gameObject);
					RunState.Run.playerDeck.AddCard(component.Info);
					foreach (SelectableCard component2 in cardpickedfromdeck)
					{
						component2.ExitBoard(0.3f, new Vector3(0f, 0f, 6f));
					}
					base.StartCoroutine(tookCard(component));
				}

			}

			public static IEnumerator tutorialtext(SelectableCard component)
			{
				float savedPos = component.transform.localPosition.x;
				component.coll.enabled = false;
				Tween.LocalPosition(component.transform, new Vector3(0, 6.45f, -2.5f), 0.1f, 0);
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput(component.Info.description, -1.5f, 0.4f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
				Tween.LocalPosition(component.transform, new Vector3(savedPos, 5.01f, -1.5f), 0.1f, 0);
				component.coll.enabled = true;
			}

			public IEnumerator tradeSequence(SelectableCard component)
			{
				foreach (SelectableCard component2 in cardpickedfromdeck)
				{
					component2.ExitBoard(0.3f, new Vector3(0f, 0f, 6f));
				}

	

				Singleton<ViewManager>.Instance.SwitchToView(View.TradingTopDown);
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Ah, but your spell book is full..", -0.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
				Tween.LocalPosition(component.transform, new Vector3(-1.8f, 5.75f, -2.15f), 0.13f, 0f, Tween.EaseInOut);
				if (!SavedVars.LearnedMechanics.Contains("spelltrade"))
                {
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Either discard this one...", -0.25f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
				}
				yield return new WaitForSeconds(0.15f);
				Tween.LocalPosition(Singleton<DeckSpellBook>.Instance.transform, new Vector3(0.75f, 5.65f, -1.75f), 0.35f, 0.15f, Tween.EaseIn);
				yield return new WaitForSeconds(0.35f);
				if (!SavedVars.LearnedMechanics.Contains("spelltrade"))
				{
					SavedVars.LearnedMechanics += "spelltrade;";
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Or, remove one of your spells..", -0.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
				}

				GameObject spellCards = Singleton<DeckSpellBook>.Instance.transform.Find("selectableSpells").gameObject;

				component.coll.enabled = true;
				component.Initialize(component.Info, new Action<SelectableCard>(this.tradeCard), null, false, null);
				toTake = component;
				for (int i = 0; i < spellCards.transform.childCount; i++)
				{
					SelectableCard component2 = spellCards.transform.GetChild(i).gameObject.GetComponent<SelectableCard>();

					component2.Initialize(component2.Info, new Action<SelectableCard>(this.tradeCard), null, false, null);
				}

				yield break;
			}

			public SelectableCard toTake;

			public void tradeCard(SelectableCard component)
            {
				bool isReplace = component != toTake;
				if (!isReplace) {

					Tween.LocalPosition(Singleton<DeckSpellBook>.Instance.transform, new Vector3(0.75f, 5.65f, -7f), 0.35f, 0f, Tween.EaseInOut);
					base.StartCoroutine(tookCard(toTake, false));
					return;
				}
				component.ExitBoard(0.3f, new Vector3(0f, 0f, -6f));
				RunState.Run.playerDeck.AddCard(toTake.Info);
				RunState.Run.playerDeck.RemoveCard(component.Info);
				Tween.LocalPosition(Singleton<DeckSpellBook>.Instance.transform, new Vector3(0.75f, 5.65f, -7f), 0.55f, 0.35f, Tween.EaseInOut);
				base.StartCoroutine(tookCard(toTake, false, true));
			}

			public static IEnumerator tookCard(SelectableCard component, bool didTake = true, bool didDidTake = false)
			{
				component.coll.enabled = false;
				component.SetFaceDown(true);
				component.gameObject.GetComponent<BoxCollider>().size = new Vector3(0, 0, 0);
				if (didDidTake) { yield return new WaitForSeconds(0.7f); }
				if (didTake)
					Tween.LocalPosition(component.transform, new Vector3(0, 5.65f, -2f), 0.1f, 0);
					yield return new WaitForSeconds(0.5f);
					Tween.LocalPosition(component.transform, new Vector3(0, 15f, 5f), 0.35f, 0);
				yield return new WaitForSeconds(0.36f);
				if (Singleton<DeckSpellBook>.Instance != null)
					GameObject.Destroy(Singleton<DeckSpellBook>.Instance.gameObject);
				component.ExitBoard(0.3f, new Vector3(0f, 0f, -6f));
				Singleton<ViewManager>.Instance.SwitchToView(View.Default, false, true);
				if (Singleton<GameFlowManager>.Instance != null)
					Singleton<GameFlowManager>.Instance.TransitionToGameState(GameState.Map, null);
				SaveManager.SaveToFile(true);
			}

			public IEnumerator sequencer(SpellCardChoice tradeCardsData)
			{
				//Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine((Singleton<CardDrawPiles>.Instance as CardDrawPiles3D).Pile.SpawnCards(RunState.Run.playerDeck.Cards.Count, 1f));
				Singleton<ViewManager>.Instance.SwitchToView(View.Choices, false, true);
				yield return new WaitForSeconds(1f);

				if (RunState.Run.playerDeck.Cards.FindAll((CardInfo x) => x.HasTrait(Trait.EatsWarrens)).Count > 0)
				{
					Singleton<ViewManager>.Instance.Controller.SwitchToControlMode(ViewController.ControlMode.CardChoice);
					Singleton<ViewManager>.Instance.Controller.LockState = ViewLockState.Unlocked;
					ViewManager instance = Singleton<ViewManager>.Instance;
					instance.ViewChanged = (Action<View, View>)Delegate.Combine(instance.ViewChanged, new Action<View, View>(ViewChanged));

					GameObject spellBook = new GameObject("DeckSpellBook");
					spellBook.gameObject.AddComponent<MagnificusMod.DeckSpellBook>();
					spellBook.transform.parent = GameObject.Find("GameTable").transform;
					spellBook.transform.localPosition = new Vector3(4.5f, 27.5f, 3f);
					spellBook.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
					spellBook.transform.localRotation = Quaternion.Euler(65, 358, 0);

					spellBook.GetComponent<DeckSpellBook>().initializeItems();
					Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(spellBook.GetComponent<DeckSpellBook>().initialize(new Vector3(0f, 5.65f, 3.5f), 0.1f, false));
					spellBook.GetComponent<DeckSpellBook>().refreshSpellBookCards(RunState.Run.playerDeck.Cards.FindAll((CardInfo x) => x.HasTrait(Trait.EatsWarrens)));
				}

				//float pauseTime = 0.25f;
				List<CardInfo> spellCards = new List<CardInfo>();
				foreach (CardInfo carde in CardLoader.allData)
				{
					if (carde.HasTrait(Trait.EatsWarrens) && carde.HasCardMetaCategory(Plugin.SpellPool))
					{
						spellCards.Add(CardLoader.GetCardByName(carde.name));
					}
				}
				List<CardInfo> selectedCards = new List<CardInfo>();
				for (int i = 0; i < 3; i++)
				{
					int selected = Random.RandomRangeInt(0, spellCards.Count);
					if (spellCards.Count < 1)
                    {
						spellCards.Add(CardLoader.GetCardByName("mag_frostspell"));
						selected = 0;
                    }
					selectedCards.Add(spellCards[selected]);
					spellCards.Remove(spellCards[selected]);
				}

				CardInfo card = CardLoader.GetCardByName("JuniorSage");//Singleton<SelectableCardArray>.Instance.TweenInCard(component.transform, new Vector3(-1.5f + a, 5.03f, -1.5f), 0, true);
				for (int i = 0; i < 3; i++)
				{
					float a = 1.5f;
					a *= i;

					GameObject gameObject = GameObject.Instantiate<GameObject>(Singleton<SelectableCardArray>.Instance.selectableCardPrefab);
					gameObject.transform.SetParent(base.transform);
					SelectableCard component = gameObject.GetComponent<SelectableCard>();
					component.Initialize(selectedCards[i], new Action<SelectableCard>(Singleton<SelectableCardArray>.Instance.OnCardSelected), null, false, new Action<SelectableCard>(Singleton<SelectableCardArray>.Instance.OnCardInspected));
					component.SetEnabled(false);
					component.Anim.PlayQuickRiffleSound();
					component.Initialize(selectedCards[i], new Action<SelectableCard>(this.cardpickingupscropt), null, false, null);

					component.GetComponent<Collider>().enabled = true;
					Singleton<SelectableCardArray>.Instance.displayedCards.Add(component);

					component.SetFaceDown(true);
					component.FaceDown = true;
					component.SetCardback(Tools.getImage("magcardback.png"));
					yield return new WaitForSeconds(0.1f);
					Singleton<SelectableCardArray>.Instance.TweenInCard(component.transform, new Vector3(-1.5f + a, 5.03f, -1.5f), 0, true);
					this.cardpickedfromdeck.Add(component);
					this.cd++;

					component.CursorEntered = (Action<MainInputInteractable>)Delegate.Combine(component.CursorEntered, new Action<MainInputInteractable>(delegate (MainInputInteractable m)
					{
						if (component.FaceDown)
						{
							Tween.LocalRotation(component.transform, new Vector3(90, 3, 0), 0.1f, 0);
						}
						else
						{
							Tween.LocalPosition(component.transform.Find("Quad").Find("CardBase"), new Vector3(0, 0, -0.1f), 0.1f, 0);
						}
					}));

					component.CursorExited = (Action<MainInputInteractable>)Delegate.Combine(component.CursorExited, new Action<MainInputInteractable>(delegate (MainInputInteractable m)
					{
						Tween.LocalRotation(component.transform, new Vector3(90, 0, 0), 0.1f, 0);
						Tween.LocalPosition(component.transform.Find("Quad").Find("CardBase"), Vector3.zero, 0.1f, 0);
					}));

				}
				yield break;
			}

			private void ViewChanged(View newView, View oldView)
			{
				if (Singleton<DeckSpellBook>.Instance == null) return;
				if (newView != View.MapDeckReview)
				{
					Tween.LocalPosition(Singleton<DeckSpellBook>.Instance.transform, new Vector3(0f, 5.65f, 3.5f), 0.3f, 0);
				}
				else
				{
					Tween.LocalPosition(Singleton<DeckSpellBook>.Instance.transform, new Vector3(0f, 5.65f, 1.75f), 0.3f, 0);
				}
			}


			public int i = 0;

			public int cd = 0;

			public bool dead = false;

			public List<SelectableCard> cardpicked = new List<SelectableCard>();

			public List<SelectableCard> cardpickedfromdeck = new List<SelectableCard>();

			public List<SelectableCard> created = new List<SelectableCard>();

		}

		[HarmonyPatch(typeof(ConfirmStoneButton), "PressButton")]
		public class PressButtonFix
		{
			public static bool Prefix(ref ConfirmStoneButton __instance)
			{
				AudioController.Instance.PlaySound3D("card_death", MixerGroup.TableObjectsSFX, __instance.transform.position, 1f, 0f, null, null, null, null, false);
				__instance.ShowPressed();
				__instance.Disable();
				if (SceneLoader.ActiveSceneName != "finale_magnificus")
				{
					Singleton<TableVisualEffectsManager>.Instance.ThumpTable(0.2f);
				}
				return false;
			}
		}


		[HarmonyPatch(typeof(CardInfo), "GemsCost", MethodType.Getter)]
		public class DanielMullinsWriteBetterCode
		{
			public static bool Prefix(ref List<GemType> __result, ref CardInfo __instance)
			{
				foreach (CardModificationInfo cardModificationInfo in __instance.mods)
				{
					bool flag = cardModificationInfo.addGemCost.Count > 0;
					if (flag)
					{
						List<GemType> list = new List<GemType>();
						for (int i = 0; i < cardModificationInfo.addGemCost.Count; i++)
						{
							try
							{
								list.Add(cardModificationInfo.addGemCost[i]);
								__instance.gemsCost = list;
							}
							catch
							{
							}
						}
						__instance.gemsCost = list;
					}
					if (cardModificationInfo.addGemCost.Count == 0 && cardModificationInfo.nullifyGemsCost)
					{
						__instance.gemsCost = new List<GemType>();
					}
				}
				__result = __instance.gemsCost;
				return false;
			}
		}
		/*
		[HarmonyPatch(typeof(CardInfo), "Decals", MethodType.Getter)]
		public class FixingDanielsDecals
		{
			public static bool Prefix(ref List<Texture> __result, ref CardInfo __instance)
			{
				if (SceneLoader.ActiveSceneName !="finale_magnificus") { return false; }
				__instance.get_decals.Clear();
				Plugin p = new Plugin();
				List<Texture> list = new List<Texture>();
				bool flag = __instance.decals.Count > 1;
				if (flag && __instance.name != "AquaSquirrel")
				{
					bool flag2 = __instance.mods.Count < 1 || (__instance.HasModFromCardMerge() && __instance.mods.Count < 2 && __instance.name != "AquaSquirrel");
					if (flag2 && __instance.name != "AquaSquirrel")
					{
						switch (__instance.gemsCost[0])
						{
							case GemType.Green:
								{
									bool flag3 = __instance.gemsCost.Count != 2;
									Texture2D image;
									if (flag3)
									{
										image = Tools.getImage("green mox.png");
									}
									else
									{
										image = Tools.getImage("gorange mox.png");
									}
									list.Add(image);
									break;
								}
							case GemType.Orange:
								{
									bool flag4 = __instance.gemsCost.Count != 2;
									Texture2D image2;
									if (flag4)
									{
										image2 = Tools.getImage("orange mox.png");
									}
									else
									{
										image2 = Tools.getImage("orlu mox.png");
									}
									list.Add(image2);
									break;
								}
							case GemType.Blue:
								{
									bool flag5 = __instance.gemsCost.Count != 2;
									Texture2D image3;
									if (flag5)
									{
										image3 = Tools.getImage("blue mox.png");
									}
									else
									{
										image3 = Tools.getImage("bleene mox.png");
									}
									list.Add(image3);
									break;
								}
						}
						__instance.decals = list;
					}
				}
				__instance.get_decals.AddRange(__instance.decals);
				__instance.get_decals.AddRange(__instance.temporaryDecals);
				foreach (CardModificationInfo cardModificationInfo in __instance.Mods)
				{
					foreach (string str in cardModificationInfo.DecalIds)
					{
						__instance.get_decals.Add(ResourceBank.Get<Texture>("Art/Cards/Decals/" + str));
					}
				}
				__result = __instance.get_decals;
				return false;
			}
		}*/

		public class CustomNode3 : SpecialNodeData
		{
			public CardChoicesType choicesType { get; set; }

			public List<CardChoice> overrideChoices { get; set; }

			public bool gemifyChoices { get; set; }

			public override string PrefabPath
			{
				get
				{
					return "Prefabs/Map/MapNodesPart1/MapNode_Empty";
				}
			}

			public string name = "bleachnpaint";
		}

		public class CustomNodeDeck : SpecialNodeData
		{
			public CardChoicesType choicesType { get; set; }
			public List<CardChoice> overrideChoices { get; set; }
			public bool gemifyChoices { get; set; }
			public override string PrefabPath
			{
				get
				{
					return "Prefabs/Map/MapNodesPart1/MapNode_Empty";
				}
			}

			public string name = "magdeck";
		}

		public class PaintingEvent : SpecialNodeData
		{
			public CardChoicesType choicesType { get; set; }
			public List<CardChoice> overrideChoices { get; set; }
			public bool gemifyChoices { get; set; }
			public override string PrefabPath
			{
				get
				{
					return "Prefabs/Map/MapNodesPart1/MapNode_Empty";
				}
			}

			public string name = "painting";
		}

		public class EdaxioNode : SpecialNodeData
		{
			public CardChoicesType choicesType { get; set; }
			public List<CardChoice> overrideChoices { get; set; }
			public bool gemifyChoices { get; set; }
			public override string PrefabPath
			{
				get
				{
					return "Prefabs/Map/MapNodesPart1/MapNode_Empty";
				}
			}

			public string name = "magedaxio";
		}

		public class UpgradeSpellNode : SpecialNodeData
		{
			public CardChoicesType choicesType { get; set; }
			public List<CardChoice> overrideChoices { get; set; }
			public bool gemifyChoices { get; set; }
			public override string PrefabPath
			{
				get
				{
					return "Prefabs/Map/MapNodesPart1/MapNode_Empty";
				}
			}

			public string name = "upgradespellnode";
		}

		public class Cauldron : SpecialNodeData
		{
			public CardChoicesType choicesType { get; set; }
			public List<CardChoice> overrideChoices { get; set; }
			public bool gemifyChoices { get; set; }
			public override string PrefabPath
			{
				get
				{
					return "Prefabs/Map/MapNodesPart1/MapNode_Empty";
				}
			}

			public string name = "cauldron";
		}

		public class CustomNode2 : SpecialNodeData
		{
			public CardChoicesType choicesType { get; set; }

			public List<CardChoice> overrideChoices { get; set; }

			public bool gemifyChoices { get; set; }

			public override string PrefabPath
			{
				get
				{
					return "Prefabs/Map/MapNodesPart1/MapNode_Empty";
				}
			}

			public override List<NodeData.SelectionCondition> GenerationPrerequisiteConditions
			{
				get
				{
					return new List<NodeData.SelectionCondition>
					{
						new NodeData.PreviousNodesContent(typeof(BuyPeltsNodeData), false),
						new NodeData.PreviousNodesContent(typeof(CardBattleNodeData), true)
					};
				}
			}

			public string name = "cardshop";
		}

		public class CustomNode1 : SpecialNodeData
		{
			public CardChoicesType choicesType { get; set; }

			public List<CardChoice> overrideChoices { get; set; }

			public bool gemifyChoices { get; set; }

			public override string PrefabPath
			{
				get
				{
					return "Prefabs/Map/MapNodesPart1/MapNode_Empty";
				}
			}

			public override List<NodeData.SelectionCondition> GenerationPrerequisiteConditions
			{
				get
				{
					return new List<NodeData.SelectionCondition>
					{
						new NodeData.PreviousNodesContent(typeof(BuyPeltsNodeData), false),
						new NodeData.PreviousNodesContent(typeof(CardBattleNodeData), true)
					};
				}
			}

			public string name = "changecost";
		}
		public class CustomNode14 : SpecialNodeData//SpellCardChoice
		{
			public CardChoicesType choicesType { get; set; }

			public List<CardChoice> overrideChoices { get; set; }
			public bool gemifyChoices { get; set; }
			public override string PrefabPath
			{
				get
				{
					return "Prefabs/Map/MapNodesPart1/MapNode_Empty";
				}
			}

			public string name = "enchant";
		}

		public class DeathCardEvent : SpecialNodeData
		{
			public CardChoicesType choicesType { get; set; }

			public List<CardChoice> overrideChoices { get; set; }
			public bool gemifyChoices { get; set; }
			public override string PrefabPath
			{
				get
				{
					return "Prefabs/Map/MapNodesPart1/MapNode_Empty";
				}
			}

			public string name = "paintdeathcard";
		}

		public class SpellCardChoice : SpecialNodeData//SpellCardChoice
		{
			public CardChoicesType choicesType { get; set; }

			public List<CardChoice> overrideChoices { get; set; }
			public bool gemifyChoices { get; set; }
			public override string PrefabPath
			{
				get
				{
					return "Prefabs/Map/MapNodesPart1/MapNode_Empty";
				}
			}

			public string name = "spellchoice";
		}

		public class MergeNode : SpecialNodeData//SpellCardChoice
		{
			public CardChoicesType choicesType { get; set; }

			public List<CardChoice> overrideChoices { get; set; }
			public bool gemifyChoices { get; set; }
			public override string PrefabPath
			{
				get
				{
					return "Prefabs/Map/MapNodesPart1/MapNode_Empty";
				}
			}

			public string name = "mergecard";
		}

		public class CopyNode : SpecialNodeData//SpellCardChoice
		{
			public CardChoicesType choicesType { get; set; }

			public List<CardChoice> overrideChoices { get; set; }
			public bool gemifyChoices { get; set; }
			public override string PrefabPath
			{
				get
				{
					return "Prefabs/Map/MapNodesPart1/MapNode_Empty";
				}
			}

			public string name = "copycard";
		}
	}
}
