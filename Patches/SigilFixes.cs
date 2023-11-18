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
using MagSave = MagnificusMod.Plugin.MagCurrentNode;
using SavedVars = MagnificusMod.SaveVariables;
using KayceeStorage = MagnificusMod.KayceeStorage;

namespace MagnificusMod
{
    class SigilFixes
    {
		[HarmonyPatch(typeof(DrawCopyOnDeath), "OnDie")]
		public class ourofix
		{
			public static void Prefix(out DrawCopyOnDeath __state, ref DrawCopyOnDeath __instance)
			{
				__state = __instance;
			}

			public static IEnumerator Postfix(IEnumerator enumerator, DrawCopyOnDeath __state, bool wasSacrifice, PlayableCard killer)
			{
				if (__state.Card.Info.name == "Ouroboros")
				{
					List<GemType> baseCost = __state.Card.Info.gemsCost;
					CardModificationInfo mod = new CardModificationInfo();
					List<GemType> newGem = new List<GemType>();
					mod.nullifyGemsCost = true;
					switch (baseCost[0])
					{
						case GemType.Blue:
							newGem = new List<GemType> { GemType.Orange };
							break;
						case GemType.Orange:
							newGem = new List<GemType> { GemType.Green };
							break;
						case GemType.Green:
							newGem = new List<GemType> { GemType.Blue };
							break;
					}
					CardInfo info = __state.Card.Info;
					mod.addGemCost = newGem;

					List<CardModificationInfo> modList = new List<CardModificationInfo> { mod };
					info.mods.Add(mod);

					yield return Singleton<CardSpawner>.Instance.SpawnCardToHand(info, modList, 0.25f, null);
				}
				else
				{
					yield return __state.CreateDrawnCard();
				}
				yield break;
			}
		}

		[HarmonyPatch(typeof(PlayerHand), "AddCardToHand")]
		public class ourofix2
		{
			public static void Prefix(out PlayerHand __state, ref PlayerHand __instance)
			{
				__state = __instance;
			}

			public static IEnumerator Postfix(IEnumerator enumerator, PlayerHand __state, PlayableCard card, Vector3 spawnOffset, float onDrawnTriggerDelay)
			{
				if (card.Info.name == "Ouroboros")
				{
					switch (card.Info.gemsCost[0])
					{
						case GemType.Blue:
							card.renderInfo.portraitOverride = Tools.getPortraitSprite("mag_oroborous2.png");
							break;
						case GemType.Orange:
							card.renderInfo.portraitOverride = Tools.getPortraitSprite("mag_oroborous1.png");
							break;
						case GemType.Green:
							card.renderInfo.portraitOverride = Tools.getPortraitSprite("mag_oroborous.png");
							break;
					}
				}
				int cardsDrawnThisTurn = __state.CardsDrawnThisTurn;
				__state.CardsDrawnThisTurn = cardsDrawnThisTurn + 1;
				__state.ParentCardToHand(card, spawnOffset);
				yield return new WaitForSeconds(onDrawnTriggerDelay);
				if (card.TriggerHandler.RespondsToTrigger(Trigger.Drawn, Array.Empty<object>()))
				{
					yield return card.TriggerHandler.OnTrigger(Trigger.Drawn, Array.Empty<object>());
				}
				yield return Singleton<GlobalTriggerHandler>.Instance.TriggerAll(Trigger.OtherCardDrawn, false, new object[]
				{
				card
				});
				__state.cardsInHand.Add(card);
				__state.OnCardInspected(card);
				__state.SetCardPositions();
				__state.PlayCardAddedToHandSound(card);
				yield break;
			}
		}

		[HarmonyPatch(typeof(HammerItem), "OnValidTargetSelected")]
		public class ourofix3
		{
			public static void Prefix(out HammerItem __state, ref HammerItem __instance)
			{
				__state = __instance;
			}

			public static IEnumerator Postfix(IEnumerator enumerator, HammerItem __state, CardSlot targetSlot, GameObject firstPersonItem)
			{
				firstPersonItem.GetComponentInChildren<Animator>().SetTrigger("hit");
				yield return new WaitForSeconds(0.166f);
				Tween.Position(firstPersonItem.transform, firstPersonItem.transform.position + Vector3.back * 4f, 0.15f, 0.2f, Tween.EaseOut, Tween.LoopType.None, null, delegate ()
				{
					firstPersonItem.gameObject.SetActive(false);
				}, true);
				bool isOuro = false;
				bool uncuttable = false;
				if (targetSlot.Card != null)
				{
					if (targetSlot.Card.Info.name == "mag_ouro") { isOuro = true; }
					else if (targetSlot.Card.Info.HasTrait(Trait.Uncuttable)) { uncuttable = true; }
					yield return targetSlot.Card.TakeDamage(100, null);
				}
				yield return new WaitForSeconds(0.65f);
				if (isOuro)
				{
					GameObject.Find("hammerStuff").GetComponent<SineWaveMovement>().enabled = false;
					Tween.LocalPosition(GameObject.Find("hammerStuff").transform, new Vector3(3.74f, -20.7636f, 5.1599f), 2.5f, 0);
					if (!SavedVars.LearnedMechanics.Contains("ourohammer;"))
					{
						SavedVars.LearnedMechanics += "ourohammer;";
						yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("You humor me challenger..", 0.5f, 0f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
						yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Did you expect your measely [c:g1]hammer[c:] to work on such a creature as the [c:g1]ouroberyl[c:]?", 1.5f, 0f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
						yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("How foolish.", 0.5f, 0f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
						yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Your hammer is now [c:g1]broken[c:], and may not be used for the remainder of the battle.", 1.5f, 0f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
					}
				} else if (uncuttable)
                {
					GameObject.Find("hammerStuff").GetComponent<SineWaveMovement>().enabled = false;
					Tween.LocalPosition(GameObject.Find("hammerStuff").transform, new Vector3(3.74f, -20.7636f, 5.1599f), 2.5f, 0);
				}
				yield break;
			}
		}

		[HarmonyPatch(typeof(DrawRandomCardOnDeath), "CardToDraw", MethodType.Getter)]
		public class getrandomcardtodrawfix
		{
			public static bool Prefix(ref DrawRandomCardOnDeath __instance, ref CardInfo __result)
			{
				__instance.wasGoodFish = false;
				if (!__instance.IsAngler)
				{
					List<CardInfo> list = ScriptableObjectLoader<CardInfo>.AllData.FindAll((CardInfo x) => x.metaCategories.Contains(CardMetaCategory.ChoiceNode) && x.temple == CardTemple.Wizard);
					__result = list[SeededRandom.Range(0, list.Count, __instance.GetRandomSeed())];
					return false;
				}
				int num = SeededRandom.Range(0, 4, __instance.GetRandomSeed());
				if (num == 0)
				{
					__result = CardLoader.GetCardByName("Angler_Fish_More");
					return false;
				}
				if (num != 1)
				{
					__result = CardLoader.GetCardByName("Angler_Fish_Bad");
					return false;
				}
				__instance.wasGoodFish = true;
				__result = CardLoader.GetCardByName("Angler_Fish_Good");
				return false;
			}
		}

		[HarmonyPatch(typeof(Submerge), "OnTurnEnd")]
		public class submergefix
		{
			public static void Prefix(out Submerge __state, ref Submerge __instance)
			{
				__state = __instance;
			}

			public static IEnumerator Postfix(IEnumerator enumerator, Submerge __state, bool playerTurnEnd)
			{
				Singleton<ViewManager>.Instance.SwitchToView(View.OpponentQueue, false, true);
				yield return new WaitForSeconds(0.15f);
				if (SceneLoader.ActiveSceneName == "finale_magnificus")
				{
					__state.Card.SetCardback(Tools.getImage("magsubmergecard.png"));
					string slotName = __state.Card.slot.IsPlayerSlot ? "PlayerSlots" : "OpponentSlots";
					Tween.LocalPosition(GameObject.Find(slotName).transform.GetChild(__state.Card.slot.Index).GetChild(5), new Vector3(GameObject.Find(slotName).transform.GetChild(__state.Card.slot.Index).GetChild(5).localPosition.x, -5f, GameObject.Find(slotName).transform.GetChild(__state.Card.slot.Index).GetChild(5).localPosition.z), 0.75f, 0);
				}
				else
				{
					__state.Card.SetCardbackSubmerged();
				}
				__state.Card.SetFaceDown(true, false);
				yield return new WaitForSeconds(0.3f);
				yield return __state.LearnAbility(0f);
				__state.triggerPriority = int.MaxValue;
				yield break;
			}
		}

		[HarmonyPatch(typeof(Submerge), "OnUpkeep")]
		public class submergefix2
		{
			public static void Prefix(out Submerge __state, ref Submerge __instance)
			{
				__state = __instance;
			}

			public static IEnumerator Postfix(IEnumerator enumerator, Submerge __state, bool playerUpkeep)
			{
				Singleton<ViewManager>.Instance.SwitchToView(View.Board, false, true);
				yield return new WaitForSeconds(0.15f);
				yield return __state.PreSuccessfulTriggerSequence();
				__state.Card.SetFaceDown(false, false);
				if (SceneLoader.ActiveSceneName == "finale_magnificus")
				{
					string slotName = __state.Card.slot.IsPlayerSlot ? "PlayerSlots" : "OpponentSlots";
					float why = __state.Card.slot.IsPlayerSlot ? 1.435f : 4.435f;
					Tween.LocalPosition(GameObject.Find(slotName).transform.GetChild(__state.Card.slot.Index).GetChild(5), new Vector3(GameObject.Find(slotName).transform.GetChild(__state.Card.slot.Index).GetChild(5).localPosition.x, why, GameObject.Find(slotName).transform.GetChild(__state.Card.slot.Index).GetChild(5).localPosition.z), 0.75f, 0);
				}
				__state.Card.UpdateFaceUpOnBoardEffects();
				__state.OnResurface();
				yield return new WaitForSeconds(0.3f);
				__state.triggerPriority = int.MinValue;
				yield break;
			}
		}

		[HarmonyPatch(typeof(GuardDog), "OnOtherCardResolve")]
		public class guardogfix
		{
			public static void Prefix(out GuardDog __state, ref GuardDog __instance)
			{
				__state = __instance;
			}

			public static IEnumerator Postfix(IEnumerator enumerator, GuardDog __state, PlayableCard otherCard)
			{
				Singleton<ViewManager>.Instance.SwitchToView(View.Board, false, false);
				yield return new WaitForSeconds(0.15f);
				CardSlot targetSlot = otherCard.Slot.opposingSlot;
				if (targetSlot.Card != null)
				{
					__state.Card.Anim.StrongNegationEffect();
					yield return new WaitForSeconds(0.3f);
				}
				else
				{
					yield return __state.PreSuccessfulTriggerSequence();
					Vector3 a = (__state.Card.Slot.transform.position + targetSlot.transform.position) / 2f;
					Tween.Position(__state.Card.transform, a + Vector3.up * 0.5f, 0.1f, 0f, Tween.EaseIn, Tween.LoopType.None, null, null, true);
					yield return Singleton<BoardManager>.Instance.AssignCardToSlot(__state.Card, targetSlot, 0.2f, null, true);
					yield return new WaitForSeconds(0.3f);
					yield return __state.LearnAbility(0.1f);
				}
				yield break;
			}
		}

		[HarmonyPatch(typeof(WhackAMole), "OnSlotTargetedForAttack")]
		public class whackamolefix
		{
			public static void Prefix(out WhackAMole __state, ref WhackAMole __instance)
			{
				__state = __instance;
			}

			public static IEnumerator Postfix(IEnumerator enumerator, WhackAMole __state, CardSlot slot, PlayableCard attacker)
			{
				Singleton<ViewManager>.Instance.SwitchToView(View.Board, false, false);
				yield return new WaitForSeconds(0.05f);
				yield return __state.PreSuccessfulTriggerSequence();
				Vector3 a = __state.Card.Slot.IsPlayerSlot ? Vector3.back : Vector3.forward;
				Tween.Position(__state.Card.transform, __state.Card.transform.position + a * 2f + Vector3.up * 0.25f, 0.15f, 0f, Tween.EaseOut, Tween.LoopType.None, null, null, true);
				yield return new WaitForSeconds(0.15f);
				Tween.Position(__state.Card.transform, new Vector3(slot.transform.position.x, __state.Card.transform.position.y, __state.Card.transform.position.z), 0.1f, 0f, null, Tween.LoopType.None, null, null, true);
				yield return new WaitForSeconds(0.1f);
				yield return Singleton<BoardManager>.Instance.AssignCardToSlot(__state.Card, slot, 0.2f, null, true);
				yield return new WaitForSeconds(0.05f);
				yield return __state.LearnAbility(0f);
				yield break;
			}
		}
	}
}
