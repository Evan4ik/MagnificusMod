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
using MagnificusMod;

namespace MagnificusMod
{
    class CardPileFixes
    {

		public static bool setUpSacrificeMarker = false;

		[HarmonyPatch(typeof(Deck), "ChooseCard")]
		public class tutorfix
		{
			public static void Prefix(out Deck __state, ref Deck __instance)
			{
				__state = __instance;
			}

			public static IEnumerator Postfix(IEnumerator enumerator, Deck __state, Action<CardInfo> cardSelectedCallback)
			{
				if (SceneLoader.ActiveSceneName == "finale_magnificus")
				{

					GameObject cardSelector = Singleton<BoardManager>.Instance.cardSelector.gameObject;

					if (cardSelector.GetComponent<SelectableCardPairArray>() != null)
					{
						GameObject.DestroyImmediate(cardSelector.GetComponent<SelectableCardPairArray>());
						cardSelector.AddComponent<SelectableCardArray>().selectableCardPrefab = Singleton<SelectableCardArray>.Instance.selectableCardPrefab;
					}

					Singleton<ViewManager>.Instance.SwitchToView(View.Default, false, true);
					SelectableCard selectedCard = null;
					cardSelector.transform.localPosition = new Vector3(-0.72f, 6.685f, 4.059f);
					Tween.LocalPosition(cardSelector.transform, new Vector3(-0.72f, 2.5f, 4.059f), 1.75f, (0.1f * __state.CardsInDeck));
					Tween.LocalRotation(cardSelector.transform, Quaternion.Euler(290, 0, 0), 0.5f, (0.1f * __state.CardsInDeck));
					Singleton<BoardManager>.Instance.cardSelector = cardSelector.GetComponent<SelectableCardArray>();

					yield return cardSelector.GetComponent<SelectableCardArray>().SelectCardFrom(__state.cards, (Singleton<CardDrawPiles>.Instance as CardDrawPiles3D).Pile, delegate (SelectableCard x)
					{
						selectedCard = x;
					});
					Tween.LocalRotation(cardSelector.transform, Quaternion.Euler(0, 0, 0), 0.5f, 0f);
					Tween.Position(selectedCard.transform, selectedCard.transform.position + Vector3.back * 4f, 0.1f, 0f, Tween.EaseIn, Tween.LoopType.None, null, null, true);
					UnityEngine.Object.Destroy(selectedCard.gameObject, 0.1f);
					cardSelectedCallback(selectedCard.Info);
				}
				else
				{
					Singleton<ViewManager>.Instance.SwitchToView(View.DeckSelection, false, true);
					SelectableCard selectedCard = null;
					yield return Singleton<BoardManager>.Instance.CardSelector.SelectCardFrom(__state.cards, (Singleton<CardDrawPiles>.Instance as CardDrawPiles3D).Pile, delegate (SelectableCard x)
					{
						selectedCard = x;
					}, null, true);
					Tween.Position(selectedCard.transform, selectedCard.transform.position + Vector3.back * 4f, 0.1f, 0f, Tween.EaseIn, Tween.LoopType.None, null, null, true);
					UnityEngine.Object.Destroy(selectedCard.gameObject, 0.1f);
					cardSelectedCallback(selectedCard.Info);
				}
				yield break;
			}
		}

		[HarmonyPatch(typeof(CardDrawPiles), "ExhaustedSequence")]
		public class starvationfix1
		{
			public static void Prefix(out CardDrawPiles __state, ref CardDrawPiles __instance)
			{
				__state = __instance;
			}

			public static IEnumerator Postfix(IEnumerator enumerator, CardDrawPiles __state)
			{
				Singleton<ViewManager>.Instance.SwitchToView(View.CardPiles, false, true);
				yield return new WaitForSeconds(1f);
				if (Singleton<SpellPile>.Instance != null && SceneLoader.ActiveSceneName == "finale_magnificus")
					Singleton<SpellPile>.Instance.setBook(true);
				if (__state.turnsSinceExhausted == 0)
				{
					yield return __state.PlayExhaustedDialogue();
				}
				Singleton<ViewManager>.Instance.Controller.LockState = ViewLockState.Unlocked;
				Singleton<ViewManager>.Instance.SwitchToView(View.Default, false, false);
				yield return new WaitForSeconds(0.1f);
				if (SceneLoader.ActiveSceneName == "finale_magnificus")
                {
					Singleton<CardDrawPiles3D>.Instance.sidePile.gameObject.transform.GetChild(1).gameObject.SetActive(false);
					Singleton<CardDrawPiles3D>.Instance.pile.gameObject.transform.GetChild(1).gameObject.SetActive(false);
				}
				if (RunState.Run.regionTier == 4 && SceneLoader.ActiveSceneName == "finale_magnificus")
                {
					if (!Generation.challenges.Contains("MasterBosses"))
					{
						if (Singleton<MagnificusMod.BossOpponents.MagnificusOpponnent>.Instance.NumLives < 2 && !Singleton<MagnificusMod.BossOpponents.MagnificusOpponnent>.Instance.outOfCardsLine)
						{
							Singleton<MagnificusMod.BossOpponents.MagnificusOpponnent>.Instance.outOfCardsLine = true;
							yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Out of cards..", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
							yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Dissapointing. I had high hopes for you.", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
						}
					} else
                    {
						if (Singleton<MagnificusMod.BossOpponents.MagnusOpponent>.Instance.NumLives < 2 && !Singleton<MagnificusMod.BossOpponents.MagnusOpponent>.Instance.outOfCardsLine)
						{
							Singleton<MagnificusMod.BossOpponents.MagnusOpponent>.Instance.outOfCardsLine = true;
							yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Such a tiny collection of cards..", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
							yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("I highly doubt you will win.", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
						}
					}
					yield break;
				}
				CardSlot moonCardSlot = Singleton<BoardManager>.Instance.OpponentSlotsCopy.Find((CardSlot x) => x.Card == null);
				if (moonCardSlot == null)
				{
					CardSlot randomSlot = Singleton<BoardManager>.Instance.OpponentSlotsCopy[UnityEngine.Random.Range(0, Singleton<BoardManager>.Instance.OpponentSlotsCopy.Count)];
					yield return randomSlot.Card.Die(false, null, true);
					yield return new WaitForSeconds(0.25f);
					moonCardSlot = randomSlot;
					randomSlot = null;
				}
				CardInfo cardInfo = CardLoader.GetCardByName("Starvation");
				CardModificationInfo mod = new CardModificationInfo(__state.turnsSinceExhausted, __state.turnsSinceExhausted);
				if (__state.turnsSinceExhausted >= 4)
				{
					mod.abilities.Add(Ability.Flying);
				}
				if (__state.turnsSinceExhausted >= 8 && SceneLoader.ActiveSceneName == "finale_magnificus")
				{
					yield return Singleton<MagnificusLifeManager>.Instance.ShowLifeLoss(true, 1);
				} else if (__state.turnsSinceExhausted >= 8)
                {
					yield return Singleton<LifeManager>.Instance.ShowDamageSequence(1, 1, true, 0.125f, null, 0f, true);
				}
				cardInfo.Mods.Add(mod);
				yield return Singleton<BoardManager>.Instance.CreateCardInSlot(cardInfo, moonCardSlot, 0.1f);
				moonCardSlot = null;
				cardInfo = null;
				mod = null;
				Singleton<ViewManager>.Instance.SwitchToView(View.Default, false, false);
				Singleton<ViewManager>.Instance.Controller.LockState = ViewLockState.Unlocked;
				__state.turnsSinceExhausted++;
				yield break;
			}
		}

		[HarmonyPatch(typeof(DeckReviewSequencer), "ArrayDeck")]
		public class deckReviewArray
		{
			public static bool Prefix(ref DeckReviewSequencer __instance, List<CardInfo> cards, Action<SelectableCard> selectedCallback = null, bool lockView = false)
			{
				Singleton<ViewManager>.Instance.Controller.LockState = ViewLockState.Unlocked;
				__instance.StartCoroutine(__instance.cardArray.DisplayUntilCancelled(cards, null, () => Singleton<ViewManager>.Instance.CurrentView != View.MapDeckReview && Singleton<ViewManager>.Instance.CurrentView != View.Candles, delegate
				{
					Singleton<ViewManager>.Instance.Controller.LockState = (lockView ? ViewLockState.Locked : ViewLockState.Unlocked);
				}, selectedCallback));
				return false;
			}
		}


            [HarmonyPatch(typeof(MagnificusCardDrawPiles), "Awake")]
		public class cardPilesFix
		{
			public static bool Prefix(ref MagnificusCardDrawPiles __instance)
			{
					
				if (!setUpSacrificeMarker)
                {
					setUpSacrificeMarker = true;
					GameObject sacrificeMarker = GameObject.Find("MagSacrificeMarker");
					
					sacrificeMarker.transform.parent = Singleton<CardSpawner>.Instance.PlayableCardPrefab.transform.GetChild(0).GetChild(0);
					sacrificeMarker.transform.localPosition = new Vector3(0, 0f, -0.04f);
					sacrificeMarker.transform.localRotation = Quaternion.Euler(0, 0, 0);
					sacrificeMarker.transform.GetChild(0).gameObject.SetActive(false);
					sacrificeMarker.transform.GetChild(1).gameObject.SetActive(false);
					sacrificeMarker.AddComponent<LerpAlpha>().speed = 10;
					sacrificeMarker.GetComponent<LerpAlpha>().intendedAlpha = 0;

					sacrificeMarker.SetActive(false);
				}
				__instance.pile.cardbackPrefab.gameObject.transform.Find("StaticCard").gameObject.GetComponent<MeshRenderer>().material.mainTexture = Tools.getImage("magcardback.png");
				__instance.sidePile.cardbackPrefab.gameObject.transform.Find("StaticCard").gameObject.GetComponent<MeshRenderer>().material.mainTexture = Tools.getImage("magcardback.png");
				List<CardInfo> nospellsallowed = new List<CardInfo>();
				List<CardInfo> onlyspellsallowed = new List<CardInfo>();

				List<CardInfo> overallDeck = new List<CardInfo>();

				for (int i = 0; i < RunState.Run.playerDeck.Cards.Count; i++)
				{
					if (!RunState.Run.playerDeck.Cards[i].HasTrait(Trait.EatsWarrens))
					{
						nospellsallowed.Add(RunState.Run.playerDeck.Cards[i]);
					}
					else
					{
						onlyspellsallowed.Add(RunState.Run.playerDeck.Cards[i]);
					}
					overallDeck.Add(RunState.Run.playerDeck.Cards[i]);
				}
				//deck.RemoveAll((CardInfo x) => x.HasTrait(Trait.EatsWarrens));
				__instance.deckList = nospellsallowed;
				__instance.sideDeckList = new List<CardInfo>();

				string text = File.ReadAllText(SaveManager.SaveFolderPath + "MagnificusModSave.gwsave");
				string[] array = text.Split(new char[]
				{
					'R'
				});
				array = array[1].Split(new char[]
				{
					','
				});
				string[] array2 = array[2].Split(new char[]
				{
					'L'
				});

				for (int i = 0; i < int.Parse(array[0]); i++)
				{
					__instance.sideDeckList.Add(CardLoader.GetCardByName("MoxRuby"));
				}
				for (int j = 0; j < int.Parse(array[1]); j++)
				{
					__instance.sideDeckList.Add(CardLoader.GetCardByName("MoxEmerald"));
				}
				for (int k = 0; k < int.Parse(array2[0]); k++)
				{
					__instance.sideDeckList.Add(CardLoader.GetCardByName("MoxSapphire"));
				}

				bool spellPileExists = false;
				try
				{
					if (GameObject.Find("GameTable").transform.Find("CardBattle_Magnificus").Find("SpellPile").gameObject.activeSelf)
					{
						spellPileExists = true;
					}
				}
				catch { }

				if (MagnificusMod.Generation.challenges.Contains("RandomSidedeck") && SaveManager.saveFile.ascensionActive)
				{
					__instance.sideDeckList = new List<CardInfo>();
					for (int i = 0; i < 10; i++)
					{
						__instance.sideDeckList.Add(CardLoader.GetCardByName("mag_randommox"));
					}
				}

				if (!spellPileExists && onlyspellsallowed.Count > 0)
				{
					GameObject spellCardDrawPile = new GameObject("SpellPile");
					spellCardDrawPile.gameObject.AddComponent<MagnificusMod.SpellPile>();
					spellCardDrawPile.transform.parent = GameObject.Find("GameTable").transform.Find("CardBattle_Magnificus");
					spellCardDrawPile.transform.localPosition = new Vector3(8.75f, 5.5f, 5.55f);
					spellCardDrawPile.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
					spellCardDrawPile.transform.localRotation = Quaternion.Euler(0, 35, 0);

					spellCardDrawPile.GetComponent<SpellPile>().initializeItems();
				}


				if (onlyspellsallowed.Count > 0)
				{
					__instance.StartCoroutine(GameObject.Find("GameTable").transform.Find("CardBattle_Magnificus").Find("SpellPile").gameObject.GetComponent<SpellPile>().initialize(new Vector3(8.75f, 5.5f, 5.55f)));
					GameObject.Find("GameTable").transform.Find("CardBattle_Magnificus").Find("SpellPile").gameObject.GetComponent<SpellPile>().refreshSpellBookCards(onlyspellsallowed);
				}

				var instance = __instance;
				CardPile pile = instance.pile;

				if (pile.gameObject.transform.childCount >= 23)
				{
					for (int i = 22; i < pile.gameObject.transform.childCount; i++)
					{
						pile.gameObject.transform.GetChild(i).GetChild(0).gameObject.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1, 0);
					}
				}

				pile.CursorEntered = (Action<MainInputInteractable>)Delegate.Combine(pile.CursorEntered, new Action<MainInputInteractable>(delegate (MainInputInteractable m)
				{
					instance.OnPileCursorEnter(true);
				}));
				CardPile pile2 = instance.pile;
				pile2.CursorExited = (Action<MainInputInteractable>)Delegate.Combine(pile2.CursorExited, new Action<MainInputInteractable>(delegate (MainInputInteractable m)
				{
					instance.OnPileCursorExit(true);
				}));
				CardPile sidePile = instance.sidePile;
				sidePile.CursorEntered = (Action<MainInputInteractable>)Delegate.Combine(sidePile.CursorEntered, new Action<MainInputInteractable>(delegate (MainInputInteractable m)
				{
					instance.OnPileCursorEnter(false);
				}));
				CardPile sidePile2 = instance.sidePile;
				sidePile2.CursorExited = (Action<MainInputInteractable>)Delegate.Combine(sidePile2.CursorExited, new Action<MainInputInteractable>(delegate (MainInputInteractable m)
				{
					instance.OnPileCursorExit(false);
				}));

				__instance.pileIconDefaultColor = __instance.mainPileLitRenderer.material.GetColor("_EmissionColor");

				try
				{
					Singleton<CardDrawPiles3D>.Instance.pile.DestroyCardsImmediate();
					Singleton<CardDrawPiles3D>.Instance.sidePile.DestroyCardsImmediate();

					Singleton<MagnificusCardDrawPiles>.Instance.Deck.cards = nospellsallowed;
					Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(Singleton<CardDrawPiles3D>.Instance.pile.SpawnCards(nospellsallowed.Count, 0.01f));

					Singleton<MagnificusCardDrawPiles>.Instance.SideDeck.cards = __instance.sideDeckList;
					Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(Singleton<CardDrawPiles3D>.Instance.sidePile.SpawnCards(__instance.sideDeckList.Count, 0.01f));


				}
				catch { }
				for (int i = 0; i < Singleton<BoardManager>.Instance.gameObject.transform.Find("PlayerSlots").childCount; i++)
                {
					if (Singleton<BoardManager>.Instance.gameObject.transform.Find("PlayerSlots").GetChild(i).childCount > 2)
                    {
						GameObject.Destroy(Singleton<BoardManager>.Instance.gameObject.transform.Find("PlayerSlots").GetChild(i).GetChild(1).gameObject);
					}
                }
				for (int i = 0; i < 3; i++)
				{
					if (Singleton<BoardManager>.Instance.gameObject.transform.Find("OpponentSlots").GetChild(i).childCount > 2)
					{
						GameObject.Destroy(Singleton<BoardManager>.Instance.gameObject.transform.Find("OpponentSlots").GetChild(i).GetChild(1).gameObject);
					}
				}

				return false;
			}
		}


		[HarmonyPatch(typeof(CardDrawPiles3D), "ChooseDraw")]
		public class cardPilesAddSpell
		{
			public static void Prefix(out CardDrawPiles3D __state, ref CardDrawPiles3D __instance)
			{
				__state = __instance;
			}

			public static IEnumerator Postfix(IEnumerator enumerator, CardDrawPiles3D __state, int numDrawnThisPhase)
			{
				CardPile selectedPile = null;

				if (SceneLoader.ActiveSceneName == "finale_magnificus")
				{
					try
					{
						
						if (__state.pile.gameObject.transform.childCount >= 23)
						{
							for (int i = 22; i < __state.pile.gameObject.transform.childCount; i++)
							{
								if (!__state.pile.gameObject.transform.GetChild(i).gameObject.activeSelf) continue;
								__state.pile.gameObject.transform.GetChild(i).GetChild(0).gameObject.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1, 0);
								if (!config.oldCardDesigns) __state.pile.gameObject.transform.GetChild(i).Find("cardBackFrame").gameObject.SetActive(false);
							}
						}
						if (__state.pile.gameObject.transform.childCount > 1 && __state.Deck.CardsInDeck <= 0)
                        {
							__state.pile.gameObject.transform.GetChild(1).gameObject.SetActive(false);
							for (int i = 1; i < __state.pile.gameObject.transform.childCount; i++)
							{
								if (!__state.pile.gameObject.transform.GetChild(i).gameObject.activeSelf) continue;
								__state.pile.gameObject.transform.GetChild(i).GetChild(0).gameObject.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1, 0);
								if (!config.oldCardDesigns) __state.pile.gameObject.transform.GetChild(i).Find("cardBackFrame").gameObject.SetActive(false);
							}
						} else if (__state.Deck.CardsInDeck <= 0)
                        {
							__state.pile.gameObject.transform.GetChild(1).gameObject.SetActive(false);
						}
						if (__state.sidePile.gameObject.transform.childCount > 1 && __state.SideDeck.CardsInDeck < 1)
						{
							__state.sidePile.gameObject.transform.GetChild(1).gameObject.SetActive(false);
							for (int i = 1; i < __state.sidePile.gameObject.transform.childCount; i++)
							{
								if (!__state.sidePile.gameObject.transform.GetChild(i).gameObject.activeSelf) continue;
								__state.sidePile.gameObject.transform.GetChild(i).GetChild(0).gameObject.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1, 0);
								if (!config.oldCardDesigns) __state.sidePile.gameObject.transform.GetChild(i).Find("cardBackFrame").gameObject.SetActive(false);
							}
						}
					}
					catch { }
				} else
                {
					Singleton<ViewManager>.Instance.Controller.LockState = ViewLockState.Unlocked;
					Singleton<ViewManager>.Instance.Controller.SwitchToControlMode(__state.viewMode, false);
					Singleton<ViewManager>.Instance.SwitchToView(__state.pilesView, false, false);
					__state.ClearPileDelegates();
					if (__state.Deck.CardsInDeck > 0)
					{
						__state.pile.CanDrawFromPile = true;
						CardPile cardPile = __state.pile;
						cardPile.CursorSelectEnded = (Action<MainInputInteractable>)Delegate.Combine(cardPile.CursorSelectEnded, new Action<MainInputInteractable>(delegate (MainInputInteractable i)
						{
							selectedPile = __state.pile;
						}));
					}
					if (__state.SideDeck.CardsInDeck > 0)
					{
						__state.sidePile.CanDrawFromPile = true;
						CardPile cardPile2 = __state.sidePile;
						cardPile2.CursorSelectEnded = (Action<MainInputInteractable>)Delegate.Combine(cardPile2.CursorSelectEnded, new Action<MainInputInteractable>(delegate (MainInputInteractable i)
						{
							selectedPile = __state.sidePile;
						}));
					}
					if (numDrawnThisPhase == 1 && Singleton<BoonsHandler>.Instance.HasBoonOfType(BoonData.Type.DoubleDraw))
					{
						yield return Singleton<BoonsHandler>.Instance.PlayBoonAnimation(BoonData.Type.DoubleDraw);
					}
					yield return new WaitUntil(() => selectedPile != null);
					__state.ClearPileDelegates();
					__state.pile.CanDrawFromPile = (__state.sidePile.CanDrawFromPile = false);
					if (selectedPile == __state.sidePile)
					{
						__state.sidePile.Draw();
						yield return new WaitForSeconds(0.1f);
					}
					else if (!Singleton<BoonsHandler>.Instance.HasBoonOfType(BoonData.Type.TutorDraw))
					{
						__state.pile.Draw();
						yield return new WaitForSeconds(0.1f);
					}
					if (numDrawnThisPhase + 1 == __state.NumDrawPhaseDraws)
					{
						__state.AssignHintActionToPiles();
						Singleton<ViewManager>.Instance.Controller.SwitchToControlMode(Singleton<BoardManager>.Instance.DefaultViewMode, false);
					}
					if (selectedPile == __state.sidePile)
					{
						yield return __state.DrawFromSidePile();
					}
					else if (Singleton<BoonsHandler>.Instance.HasBoonOfType(BoonData.Type.TutorDraw))
					{
						__state.StartCoroutine(Singleton<BoonsHandler>.Instance.PlayBoonAnimation(BoonData.Type.TutorDraw));
						yield return __state.Deck.Tutor();
					}
					else
					{
						yield return __state.DrawCardFromDeck(null, null);
					}
					if (__state.Exhausted)
					{
						__state.ClearPileDelegates();
					}
					yield break;
				}

				Singleton<ViewManager>.Instance.Controller.LockState = ViewLockState.Unlocked;
				Singleton<ViewManager>.Instance.Controller.SwitchToControlMode(__state.viewMode, false);
				Singleton<ViewManager>.Instance.SwitchToView(__state.pilesView, false, false);
				__state.ClearPileDelegates();
				if (__state.Deck.CardsInDeck > 0)
				{
					__state.pile.CanDrawFromPile = true;
					CardPile cardPile = __state.pile;
					cardPile.CursorSelectEnded = (Action<MainInputInteractable>)Delegate.Combine(cardPile.CursorSelectEnded, new Action<MainInputInteractable>(delegate (MainInputInteractable i)
					{
						selectedPile = __state.pile;
					}));
				}
				if (__state.SideDeck.CardsInDeck > 0)
				{
					__state.sidePile.CanDrawFromPile = true;
					CardPile cardPile2 = __state.sidePile;
					cardPile2.CursorSelectEnded = (Action<MainInputInteractable>)Delegate.Combine(cardPile2.CursorSelectEnded, new Action<MainInputInteractable>(delegate (MainInputInteractable i)
					{
						selectedPile = __state.sidePile;
					}));
				}

				if (numDrawnThisPhase == 1 && Singleton<BoonsHandler>.Instance.HasBoonOfType(BoonData.Type.DoubleDraw))
				{
					yield return Singleton<BoonsHandler>.Instance.PlayBoonAnimation(BoonData.Type.DoubleDraw);
				}
				yield return new WaitUntil(() => selectedPile != null);

				if (Singleton<SpellPile>.Instance != null && SceneLoader.ActiveSceneName == "finale_magnificus")
					Singleton<SpellPile>.Instance.setBook(true);

				__state.ClearPileDelegates();
				__state.pile.CanDrawFromPile = (__state.sidePile.CanDrawFromPile = false);

				if (selectedPile == __state.sidePile)
				{
					if (MagnificusMod.Generation.challenges.Contains("RandomSidedeck") && SaveManager.saveFile.ascensionActive)
					{
						ChallengeActivationUI.TryShowActivation(KayceeFixes.ChallengeManagement.RandomSidedeck);
					}
					__state.sidePile.Draw();
					yield return new WaitForSeconds(0.1f);
				}
				else if (selectedPile == __state.pile)
				{
					__state.pile.Draw();
					yield return new WaitForSeconds(0.1f);
				}
				
				if (numDrawnThisPhase + 1 == __state.NumDrawPhaseDraws)
				{
					__state.AssignHintActionToPiles();
					Singleton<ViewManager>.Instance.Controller.SwitchToControlMode(Singleton<BoardManager>.Instance.DefaultViewMode, false);
				}
				if (selectedPile == __state.sidePile)
				{
					yield return __state.DrawFromSidePile();
				}
				else if (Singleton<BoonsHandler>.Instance.HasBoonOfType(BoonData.Type.TutorDraw))
				{
					__state.StartCoroutine(Singleton<BoonsHandler>.Instance.PlayBoonAnimation(BoonData.Type.TutorDraw));
					yield return __state.Deck.Tutor();
				}
				else if (selectedPile == __state.sidePile)
				{
					yield return __state.DrawFromSidePile();
				}
				else if (selectedPile == __state.pile)
				{
					yield return __state.DrawCardFromDeck(null, null);
				}
				if (__state.Exhausted)
				{
					__state.ClearPileDelegates();
				}
				yield break;
			}
		}

		[HarmonyPatch(typeof(CardPile), "Draw")]
		public class fixInvisibleDraw
		{
			public static bool Prefix(ref CardPile __instance)
			{
				if (__instance.cards.Count > 0)
				{
					Transform transform = __instance.cards[__instance.cards.Count - 1];
					if (transform.childCount > 0)
					{
						transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1, 1);
					}
					Tween.Position(transform, transform.transform.position + __instance.drawCardFlyOffDirection, 0.5f, 0f, Tween.EaseInOut, Tween.LoopType.None, null, null, true);
					Tween.Rotation(transform, __instance.drawCardFlyOffRotation, 0.5f, 0f, Tween.EaseInOut, Tween.LoopType.None, null, null, true);
					__instance.cards.Remove(transform);
					__instance.TryUpdateColliderSize();
					GameObject.Destroy(transform.gameObject, 2f);
					if (__instance.cards.Count == 0)
					{
						__instance.shadow.SetActive(false);
					}
					__instance.drawSoundEvent.Play(__instance.transform);
				}
				return false;
			}
		}

		[HarmonyPatch(typeof(MagnificusCardDrawPiles), "RefillDeck")]
		public class cardPilesFix2
		{
			public static bool Prefix(ref MagnificusCardDrawPiles __instance)
			{
				return false;
			}
		}

		[HarmonyPatch(typeof(MagnificusCardDrawPiles), "RefillSideDeck")]
		public class cardPilesFix3
		{
			public static bool Prefix(ref MagnificusCardDrawPiles __instance)
			{
				return false;
			}
		}



		[HarmonyPatch(typeof(Deck), "GetFairHand")]
		public class fairHandStuff
		{
			public static bool Prefix(ref Deck __instance, ref List<CardInfo> __result, int numCards, bool includeTier0Card = true, List<CardInfo> existingHand = null)
			{
				if (SceneLoader.ActiveSceneName != "finale_magnificus") { return true; }
				List<CardInfo> list = new List<CardInfo>(__instance.cards);
				List<CardInfo> hand = new List<CardInfo>();

				Dictionary<string, GemType> gemTypes = new Dictionary<string, GemType> { { "MoxEmerald", GemType.Green }, { "MoxRuby", GemType.Blue }, { "MoxSapphire", GemType.Blue } };
				GemType drawnGem = existingHand.Count > 0 && gemTypes.ContainsKey(existingHand[0].name) ? gemTypes[existingHand[0].name] : gemTypes.ElementAt(Random.RandomRangeInt(0, 2)).Value;

				if (existingHand != null)
				{
					list.RemoveAll((CardInfo x) => existingHand.Contains(x));
					hand.AddRange(existingHand);
				}
				if (includeTier0Card)
				{
					List<CardInfo> list2 = list.FindAll((CardInfo x) => x.CostTier == 0 && !x.HasAbility(Ability.GemDependant));
					if (list2.Count > 0)
					{
						CardInfo item = list2[SeededRandom.Range(0, list2.Count, SaveManager.saveFile.randomSeed++)];
						hand.Add(item);
						list.Remove(item);
					}
				}


				List<CardInfo> monoCost = new List<CardInfo>(list);
				monoCost.RemoveAll((CardInfo x) => x.gemsCost.Count != 1 && x.BloodCost < 1);

				if (monoCost.Count > 0)
                {
					List<CardInfo> gemCost = new List<CardInfo>(monoCost);
					gemCost.RemoveAll((CardInfo x) => x.gemsCost.Count < 1 ||  x.gemsCost[0] != drawnGem || x.HasSpecialAbility(Plugin.OuroChange));

					if (gemCost.Count > 0)
                    {
						CardInfo item2 = gemCost[SeededRandom.Range(0, gemCost.Count, SaveManager.saveFile.randomSeed++)];
						hand.Add(item2);

						monoCost.Remove(item2);
						list.Remove(item2);
					}
				}

				while (hand.Count < numCards - 1)
				{
					List<CardInfo> pool = monoCost.Count > 0 ? new List<CardInfo>(monoCost) : new List<CardInfo>(list);

					CardInfo item2 = pool[SeededRandom.Range(0, pool.Count, SaveManager.saveFile.randomSeed++)];
					hand.Add(item2);

					monoCost.Remove(item2);
					list.Remove(item2);
				}


				var instance = __instance;
				if (!hand.Exists((CardInfo x) => instance.CardCanBePlayedByTurn2WithHand(x, hand) && x.CostTier > 0 && !x.HasTrait(Trait.Pelt)))
				{
					List<CardInfo> list3 = list.FindAll((CardInfo x) => instance.CardCanBePlayedByTurn2WithHand(x, hand) && x.CostTier > 0 && !x.HasTrait(Trait.Pelt));

					if (list3.FindAll((CardInfo x) => x.gemsCost.Count == 1 && x.gemsCost[0] != drawnGem).Count > 0)
						list3.RemoveAll((CardInfo x) => x.gemsCost.Count == 1 && x.gemsCost[0] == drawnGem);//to not arouse suspicion

					if (list3.Count > 0)
					{
						CardInfo item3 = list3[SeededRandom.Range(0, list3.Count, SaveManager.saveFile.randomSeed++)];
						hand.Add(item3);
						list.Remove(item3);
					}
				}
				if (hand.Count < numCards && list.Count > 0)
				{
					CardInfo item4 = list[SeededRandom.Range(0, list.Count, SaveManager.saveFile.randomSeed++)];
					hand.Add(item4);
					list.Remove(item4);
				}

				__result = hand;
				return false;
			}
		 }


		[HarmonyPatch(typeof(Deck), "CardCanBePlayedByTurn2WithHand")]
		public class gemCanBePlayedByTurn2
		{
			public static bool Prefix(ref bool __result, CardInfo card, List<CardInfo> hand)
			{
				List<CardInfo> list = hand.FindAll((CardInfo x) => x.CostTier == 0 && x.Sacrificable);
				int count = hand.FindAll((CardInfo x) => x.CostTier == 0 && x.HasAbility(Ability.Brittle)).Count;
				bool bone = card.BonesCost == 0 || count >= card.BonesCost;
				bool blood = card.BloodCost == 0 || card.BloodCost <= list.Count;
				bool energy = card.EnergyCost <= 2;
				bool mox = true;
				__result = bone && blood && energy && mox;
				return false;
			}
		}

        }
    }
