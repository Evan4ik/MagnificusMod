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
    class DraftFixes
    {
		[HarmonyPatch(typeof(TradePeltsSequencer), "TradePelts")]
		public class DraftFix0
		{
			public static void Prefix(out TradePeltsSequencer __state, ref TradePeltsSequencer __instance)
			{
				__state = __instance;
			}

			public static IEnumerator Postfix(IEnumerator enumerator, TradePeltsSequencer __state, TradePeltsNodeData nodeData)
			{
				if (SceneLoader.ActiveSceneName != "finale_magnificus")
				{
					Singleton<ViewManager>.Instance.SwitchToView(View.Default, false, true);
					yield return new WaitForSeconds(0.25f);
					__state.tradeCrates.SetActive(true);
					yield return new WaitForSeconds(0.5f);
					if (RunState.Run.regionTier >= 3)
					{
						yield return Singleton<TextDisplayer>.Instance.PlayDialogueEvent("TraderFinalZoneIntro", TextDisplayer.MessageAdvanceMode.Input, TextDisplayer.EventIntersectMode.Wait, null, null);
					}
					else
					{
						if (!ProgressionData.LearnedMechanic(MechanicsConcept.TradingPelts))
						{
							yield return Singleton<TextDisplayer>.Instance.PlayDialogueEvent("TutorialTradePeltsIntro", TextDisplayer.MessageAdvanceMode.Input, TextDisplayer.EventIntersectMode.Wait, null, null);
						}
						LeshyAnimationController.Instance.PutOnMask(LeshyAnimationController.Mask.Trader, true);
						yield return new WaitForSeconds(1.25f);
						yield return Singleton<TextDisplayer>.Instance.PlayDialogueEvent("TraderIntro", TextDisplayer.MessageAdvanceMode.Input, TextDisplayer.EventIntersectMode.Wait, null, null);
					}
					yield return new WaitForSeconds(0.5f);
					List<int> tradingTiers = __state.GetTradingTiers();
					bool hasPelts = tradingTiers.Count > 0;
					bool flag;
					if (hasPelts)
					{
						flag = RunState.Run.playerDeck.Cards.Exists((CardInfo x) => x.name == "Lice");
					}
					else
					{
						flag = false;
					}
					bool hasLice = flag;
					if (hasPelts && !hasLice)
					{
						Singleton<ViewManager>.Instance.SwitchToView(View.TradingTopDown, false, true);
						yield return new WaitForSeconds(0.15f);
						yield return __state.deckPile.SpawnCards(RunState.DeckList.Count, 0.75f);
						bool tutorialDialogueShown = false;
						foreach (int tier in tradingTiers)
						{
							__state.tradeCards.Clear();
							__state.peltCards.Clear();
							yield return new WaitForSeconds(0.15f);
							yield return __state.CreatePeltCards(tier);
							bool hasMergedPelt = __state.peltCards.Exists((SelectableCard x) => x.Info.Mods.Exists((CardModificationInfo m) => m.fromDuplicateMerge));
							if (RunState.Run.regionTier < 2)
							{
								string eventId = "TraderPelts" + __state.GetTierName(tier);
								if (hasMergedPelt)
								{
									eventId = "TraderPeltsMerged";
								}
								yield return Singleton<TextDisplayer>.Instance.PlayDialogueEvent(eventId, TextDisplayer.MessageAdvanceMode.Input, TextDisplayer.EventIntersectMode.Wait, null, null);
							}
							yield return new WaitForSeconds(0.15f);
							yield return __state.CreateTradeCards(__state.GetTradeCardInfos(tier, hasMergedPelt), 4, tier == 2);
							Singleton<TableRuleBook>.Instance.SetOnBoard(true);
							if (!tutorialDialogueShown && !ProgressionData.LearnedMechanic(MechanicsConcept.TradingPelts))
							{
								tutorialDialogueShown = true;
								yield return Singleton<TextDisplayer>.Instance.PlayDialogueEvent("TutorialTradePeltsCards", TextDisplayer.MessageAdvanceMode.Input, TextDisplayer.EventIntersectMode.Wait, null, null);
								yield return new WaitForSeconds(0.25f);
							}
							foreach (SelectableCard selectableCard in __state.tradeCards)
							{
								selectableCard.SetEnabled(true);
								selectableCard.SetInteractionEnabled(true);
								selectableCard.CursorSelectStarted = (Action<MainInputInteractable>)Delegate.Combine(selectableCard.CursorSelectStarted, new Action<MainInputInteractable>(delegate (MainInputInteractable c)
								{
									__state.OnCardSelected(c as SelectableCard);
								}));
							}
							yield return new WaitForSeconds(0.25f);
							Singleton<ViewManager>.Instance.Controller.LockState = ViewLockState.Unlocked;
							__state.EnableViewDeck(ViewController.ControlMode.TradePelts, __state.transform.position);
							yield return new WaitUntil(() => __state.peltCards.Count == 0);
							Singleton<ViewManager>.Instance.Controller.LockState = ViewLockState.Locked;
							__state.DisableViewDeck();
							yield return new WaitForSeconds(0.15f);
							foreach (SelectableCard selectableCard2 in __state.tradeCards)
							{
								selectableCard2.SetEnabled(false);
							}
							yield return __state.CleanupTradeCards(__state.tradeCards);
							yield return new WaitForSeconds(0.1f);
							yield return __state.deckPile.DestroyCards(0.5f);
						}
						List<int>.Enumerator er = default(List<int>.Enumerator);
					}
					else
					{
						yield return new WaitForSeconds(1f);
						yield return Singleton<CurrencyBowl>.Instance.ShowGain(5, false, true);
						RunState.Run.currency += 5;
						yield return new WaitForSeconds(0.2f);
					}
					Singleton<TableRuleBook>.Instance.SetOnBoard(false);
					Singleton<ViewManager>.Instance.SwitchToView(View.Default, false, false);
					yield return new WaitForSeconds(0.25f);
					if (RunState.Run.regionTier < 2)
					{
						if (hasPelts && !hasLice)
						{
							yield return Singleton<TextDisplayer>.Instance.PlayDialogueEvent("TraderOutro", TextDisplayer.MessageAdvanceMode.Input, TextDisplayer.EventIntersectMode.Wait, null, null);
						}
						yield return LeshyAnimationController.Instance.TakeOffMask();
					}
					yield return new WaitForSeconds(0.25f);
					__state.tradeCrates.GetComponentInChildren<Animator>().Play("exit", 0, 0f);
					CustomCoroutine.WaitThenExecute(0.5f, delegate
					{
						__state.tradeCrates.SetActive(false);
					}, false);
					ProgressionData.SetMechanicLearned(MechanicsConcept.TradingPelts);
					yield return new WaitForSeconds(1f);
					if (Singleton<GameFlowManager>.Instance != null)
					{
						Singleton<GameFlowManager>.Instance.TransitionToGameState(GameState.Map, null);
					}
				}
				else
				{
					List<int> list = new List<int>();
					for (int i = 0; i < 1; i++)
					{
						if (RunState.DeckList.Exists((CardInfo x) => x.name == "mag_obelisk"))
						{
							list.Add(i);
						}
					}
					List<int> tradingTiers = list;
					bool hasPelts = tradingTiers.Count > 0;
					if (hasPelts)
					{
						Singleton<ViewManager>.Instance.SwitchToView(View.TradingTopDown, false, true);
						yield return new WaitForSeconds(0.15f);
						foreach (int tier in tradingTiers)
						{
							__state.tradeCards.Clear();
							__state.peltCards.Clear();
							yield return new WaitForSeconds(0.15f);
							yield return __state.CreatePeltCards(tier);
							bool hasMergedPelt = __state.peltCards.Exists((SelectableCard x) => x.Info.Mods.Exists((CardModificationInfo m) => m.fromDuplicateMerge));
							yield return new WaitForSeconds(0.15f);

							List<CardInfo> unlockedCards;
							int numCards;
							if (tier != 2)
							{
								unlockedCards = CardLoader.GetUnlockedCards(CardMetaCategory.TraderOffer, CardTemple.Nature);
								if (SceneLoader.ActiveSceneName == "finale_magnificus")
								{
									unlockedCards = CardLoader.GetUnlockedCards(CardMetaCategory.ChoiceNode, CardTemple.Wizard);
								}
								numCards = 8;
							}
							else
							{
								unlockedCards = CardLoader.GetUnlockedCards(CardMetaCategory.Rare, CardTemple.Nature);
								if (SceneLoader.ActiveSceneName == "finale_magnificus")
								{
									unlockedCards = CardLoader.GetUnlockedCards(CardMetaCategory.Rare, CardTemple.Wizard);
								}
								numCards = 4;
							}
							List<CardInfo> list2 = new List<CardInfo>();
							int seed = Random.RandomRangeInt(0, 10000);
							while (list2.Count < numCards && unlockedCards.Count > 0)
							{
								CardInfo cardInfo = unlockedCards[SeededRandom.Range(0, unlockedCards.Count, seed++)];
								CardInfo cardInfo2 = CardLoader.Clone(cardInfo);
								list2.Add(cardInfo2);
								unlockedCards.Remove(cardInfo);
							}

							yield return __state.CreateTradeCards(list2, 4, tier == 2);
							//Singleton<TableRuleBook>.Instance.SetOnBoard(true);
							foreach (SelectableCard selectableCard in __state.tradeCards)
							{
								selectableCard.SetEnabled(true);
								selectableCard.SetInteractionEnabled(true);
								selectableCard.CursorSelectStarted = (Action<MainInputInteractable>)Delegate.Combine(selectableCard.CursorSelectStarted, new Action<MainInputInteractable>(delegate (MainInputInteractable c)
								{
									__state.OnCardSelected(c as SelectableCard);
								}));
							}
							yield return new WaitForSeconds(0.25f);
							Singleton<ViewManager>.Instance.Controller.LockState = ViewLockState.Unlocked;
							__state.EnableViewDeck(ViewController.ControlMode.TradePelts, __state.transform.position);
							yield return new WaitUntil(() => __state.peltCards.Count == 0);
							Singleton<ViewManager>.Instance.Controller.LockState = ViewLockState.Locked;
							__state.DisableViewDeck();
							yield return new WaitForSeconds(0.15f);
							foreach (SelectableCard selectableCard2 in __state.tradeCards)
							{
								selectableCard2.SetEnabled(false);
							}
							yield return __state.CleanupTradeCards(__state.tradeCards);
							yield return new WaitForSeconds(0.1f);
							yield return __state.deckPile.DestroyCards(0.5f);
						}
						List<int>.Enumerator er = default(List<int>.Enumerator);
					}
					else
					{
						yield return new WaitForSeconds(1f);
						if (!SavedVars.LearnedMechanics.Contains("nopelts;"))
                        {
							yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Curious. You enter a trading depot without any obelisks to trade in.", -0.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
							yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("What do you expect to gain from this?", -0.5f, 0.5f, Emotion.Curious, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
							SavedVars.LearnedMechanics += "nopelts;";
						}
					}
					Singleton<ViewManager>.Instance.SwitchToView(View.Default, false, true);
					bool flag3 = Singleton<GameFlowManager>.Instance != null;
					if (flag3)
					{
						Singleton<GameFlowManager>.Instance.TransitionToGameState(GameState.Map, null);
					}
					SaveManager.SaveToFile(true);
				}
				yield break;
			}
		}

		[HarmonyPatch(typeof(TradePeltsSequencer), "CreatePeltCards")]
		public class DraftFix1
		{
			public static void Prefix(out TradePeltsSequencer __state, ref TradePeltsSequencer __instance)
			{
				__state = __instance;
			}

			public static IEnumerator Postfix(IEnumerator enumerator, TradePeltsSequencer __state, int tier)
			{
				if (SceneLoader.ActiveSceneName != "finale_magnificus")
				{
					List<CardInfo> cardInfos = RunState.DeckList.FindAll((CardInfo x) => x.name == CardLoader.PeltNames[tier]);
					int numPelts = Mathf.Min((tier == 2) ? 4 : 8, cardInfos.Count);
					int num;
					for (int i = 0; i < numPelts; i = num + 1)
					{
						__state.deckPile.Draw();
						yield return new WaitForSeconds(0.15f);
						num = i;
					}
					for (int i = 0; i < numPelts; i = num + 1)
					{
						GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(__state.selectableCardPrefab, __state.transform);
						gameObject.gameObject.SetActive(true);
						gameObject.name = "peltymcpeltface";
						SelectableCard component = gameObject.GetComponent<SelectableCard>();
						component.SetInfo(cardInfos[i]);
						Vector3 vector = __state.PELT_CARDS_ANCHOR + __state.PELT_CARD_SPACING * (float)i;
						vector.x = __state.PELT_CARDS_ANCHOR.x + __state.PELT_CARD_SPACING.x * (float)(i % 4);
						component.transform.position = vector + Vector3.back * 4f;
						Tween.Position(component.transform, vector, 0.15f, 0f, Tween.EaseOut, Tween.LoopType.None, null, null, true);
						component.Anim.PlayRiffleSound();
						__state.peltCards.Add(component);
						component.SetEnabled(false);
						component.SetInteractionEnabled(false);
						yield return new WaitForSeconds(0.15f);
						num = i;
					}
				}
				else
				{
					List<CardInfo> cardInfos = RunState.DeckList.FindAll((CardInfo x) => x.name == "mag_obelisk");
					int numPelts = Mathf.Min((tier == 2) ? 4 : 8, cardInfos.Count);
					int num;
					for (int i = 0; i < numPelts; i = num + 1)
					{
						__state.deckPile.Draw();
						yield return new WaitForSeconds(0.15f);
						num = i;
					}
					for (int i = 0; i < numPelts; i = num + 1)
					{
						GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(__state.selectableCardPrefab, __state.transform);
						gameObject.gameObject.SetActive(true);
						gameObject.name = "peltymcpeltface";
						SelectableCard component = gameObject.GetComponent<SelectableCard>();
						component.SetInfo(cardInfos[i]);
						Vector3 vector = __state.PELT_CARDS_ANCHOR + __state.PELT_CARD_SPACING * (float)i;
						vector.x = __state.PELT_CARDS_ANCHOR.x + __state.PELT_CARD_SPACING.x * (float)(i % 4);
						component.transform.position = vector + Vector3.back * 4f;
						component.transform.localPosition = new Vector3(4.3226f, 5.03f, -0.1602f);
						Tween.LocalPosition(component.transform, vector, 0.15f, 0f, Tween.EaseOut, Tween.LoopType.None, null, null, true);
						component.Anim.PlayRiffleSound();
						__state.peltCards.Add(component);
						component.SetEnabled(false);
						component.SetInteractionEnabled(false);
						yield return new WaitForSeconds(0.15f);
						num = i;
					}
				}
				yield break;
			}
		}

		[HarmonyPatch(typeof(TradePeltsSequencer), "CreateTradeCards")]
		public class DraftFix2
		{
			public static void Prefix(out TradePeltsSequencer __state, ref TradePeltsSequencer __instance)
			{
				__state = __instance;
			}

			public static IEnumerator Postfix(IEnumerator enumerator, TradePeltsSequencer __state, List<CardInfo> cards, int cardsPerRow, bool rareCards)
			{
				int j;
				for (int i = 0; i < cards.Count; i = j + 1)
				{
					int num = i % cardsPerRow;
					int num2 = (i >= cardsPerRow) ? 0 : 1;
					GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(__state.selectableCardPrefab, __state.transform);
					gameObject.gameObject.SetActive(true);
					gameObject.name = "tradecardmctradeyface";
					SelectableCard component = gameObject.GetComponent<SelectableCard>();
					component.SetInfo(cards[i]);
					SpecialCardBehaviour[] components = gameObject.GetComponents<SpecialCardBehaviour>();
					Vector3 vector = __state.CARDS_ANCHOR + new Vector3(__state.CARD_SPACING.x * (float)num, 0f, __state.CARD_SPACING.y * (float)num2);
					if (rareCards)
					{
						vector.z = -2f;
					}
					Vector3 vector2 = new Vector3(90f, 90f, 90f);
					component.transform.position = vector + new Vector3(0f, 0.25f, 3f);
					component.transform.eulerAngles = vector2 + new Vector3(0f, 0f, -7.5f + UnityEngine.Random.value * 7.5f);
					if (SceneLoader.ActiveSceneName != "finale_magnificus")
					{
						Tween.Position(component.transform, vector, 0.15f, 0f, Tween.EaseOut, Tween.LoopType.None, null, null, true);
					}
					else
					{
						component.transform.localPosition = new Vector3(4.3226f, 5.03f, -0.1602f);
						component.SetCardback(Tools.getImage("magcardback.png"));
						Tween.LocalPosition(component.transform, vector, 0.15f, 0f, Tween.EaseOut, Tween.LoopType.None, null, null, true);
					}
					Tween.Rotation(component.transform, vector2, 0.15f, 0f, Tween.EaseOut, Tween.LoopType.None, null, null, true);
					__state.tradeCards.Add(component);
					component.SetEnabled(false);
					component.Anim.PlayQuickRiffleSound();
					yield return new WaitForSeconds(0.05f);
					j = i;
				}
				yield break;
			}
		}
	}
}
