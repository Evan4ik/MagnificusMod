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
					Singleton<ViewManager>.Instance.SwitchToView(View.Default, false, true);
					SelectableCard selectedCard = null;
					GameObject.Find("SelectableCardArray").transform.localPosition = new Vector3(-0.72f, 6.685f, 4.059f);
					Tween.LocalPosition(GameObject.Find("SelectableCardArray").transform, new Vector3(-0.72f, 2.5f, 4.059f), 1.25f, 0f);
					Tween.LocalRotation(GameObject.Find("SelectableCardArray").transform, Quaternion.Euler(290, 0, 0), 0.5f, (0.1f * __state.CardsInDeck));
					yield return Singleton<BoardManager>.Instance.CardSelector.SelectCardFrom(__state.cards, (Singleton<CardDrawPiles>.Instance as CardDrawPiles3D).Pile, delegate (SelectableCard x)
					{
						selectedCard = x;
					}, null, true);
					Tween.LocalRotation(GameObject.Find("SelectableCardArray").transform, Quaternion.Euler(0, 0, 0), 0.5f, 0f);
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
				if (__state.turnsSinceExhausted == 0)
				{
					yield return __state.PlayExhaustedDialogue();
				}
				Singleton<ViewManager>.Instance.Controller.LockState = ViewLockState.Unlocked;
				Singleton<ViewManager>.Instance.SwitchToView(View.Default, false, false);
				yield return new WaitForSeconds(0.1f);
				if (RunState.Run.regionTier == 4)
                {
					if (Singleton<MagnificusMod.BossOpponents.MagnificusOpponnent>.Instance.NumLives < 2 && !Singleton<MagnificusMod.BossOpponents.MagnificusOpponnent>.Instance.outOfCardsLine)
                    {
						Singleton<MagnificusMod.BossOpponents.MagnificusOpponnent>.Instance.outOfCardsLine = true;
						yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Out of cards..", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
						yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Dissapointing. I had high hopes for you.", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
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
					__instance.sideDeckList.Add(CardLoader.GetCardByName("mag_rubymox"));
				}
				for (int j = 0; j < int.Parse(array[1]); j++)
				{
					__instance.sideDeckList.Add(CardLoader.GetCardByName("mag_greenmox"));
				}
				for (int k = 0; k < int.Parse(array2[0]); k++)
				{
					__instance.sideDeckList.Add(CardLoader.GetCardByName("mag_bluemox"));
				}

				bool spellPileExists = false;
				try
				{
					if (__instance.gameObject.transform.Find("SpellPile").gameObject.activeSelf)
					{
						spellPileExists = true;
					}
				}
				catch { }

				if (MagnificusMod.Generation.challenges.Contains("RandomSidedeck") && KayceeStorage.IsKaycee)
				{
					__instance.sideDeckList = new List<CardInfo>();
					for (int i = 0; i < 10; i++)
					{
						__instance.sideDeckList.Add(CardLoader.GetCardByName("mag_randommox"));
					}
				}
				if (!spellPileExists)
				{
					__instance.gameObject.AddComponent<MagnificusMod.SpellPile>();
					GameObject spellCardDrawPile = GameObject.Instantiate(Singleton<MagnificusCardDrawPiles>.Instance.gameObject.transform.Find("GemPile").gameObject);
					spellCardDrawPile.name = "SpellPile";
					spellCardDrawPile.transform.parent = Singleton<MagnificusCardDrawPiles>.Instance.gameObject.transform;
					spellCardDrawPile.transform.localPosition = new Vector3(1.4566f, 0.605f, 1.2469f);
					spellCardDrawPile.gameObject.GetComponent<Collider>().enabled = true;
					Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(__instance.gameObject.GetComponent<SpellPile>().Initialize());
					spellCardDrawPile.gameObject.GetComponent<BoxCollider>().size = new Vector3(2f, 1.25f, 2.75f);
					GameObject spellBook = GameObject.Instantiate(Resources.Load("prefabs/rulebook/TableRuleBook") as GameObject);
					GameObject.Destroy(spellBook.gameObject.GetComponent<TableRuleBook>());
					spellBook.transform.parent = spellCardDrawPile.transform;
					spellBook.name = "spellBook";
					spellBook.transform.Find("Interactable").gameObject.SetActive(false);
					spellBook.transform.localPosition = new Vector3(0f, -0.24f, 0);
					spellBook.transform.rotation = Quaternion.Euler(0, 270, 0);

					spellBook.AddComponent<SineWaveMovement>();
					spellBook.GetComponent<SineWaveMovement>().originalPosition = spellBook.transform.localPosition;
					spellBook.GetComponent<SineWaveMovement>().speed = 0.5f;
					spellBook.GetComponent<SineWaveMovement>().yMagnitude = 0.25f;
					spellBook.GetComponent<SineWaveMovement>().enabled = false;
					spellBook.transform.Find("BookCover01").gameObject.GetComponent<MeshRenderer>().material.mainTexture = Tools.getImage("spellbook.png");
					if (onlyspellsallowed.Count > 0)
					{
						spellBook.SetActive(true);

						Tween.Rotation(spellBook.transform, Quaternion.Euler(0, 299, 0), 0f, 3);
						Tween.LocalPosition(spellBook.transform, new Vector3(0f, -0.24f, 0), 0f, 3);
					}
				}

				SpellPile spellData = __instance.gameObject.GetComponent<SpellPile>();
				CardPile spellPile = __instance.gameObject.transform.Find("SpellPile").gameObject.GetComponent<CardPile>();


				if (onlyspellsallowed.Count > 0)
				{
					spellData.spellData.Clear();
					Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(spellData.Initialize());
					spellData.spellList = new List<CardInfo>();
					spellPile.DestroyCardsImmediate();
					spellPile.SetEnabled(true);
					spellPile.CreateCards(onlyspellsallowed.Count, 15f);

					for (int i = 0; i < onlyspellsallowed.Count; i++)
					{
						spellData.spellData.Add(onlyspellsallowed[i]);
						spellData.spellList.Add(onlyspellsallowed[i]);
					}
					spellData.refreshDeck(spellData.spellList);
				}

				var instance = __instance;
				CardPile pile = instance.pile;
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
				CardPile spellPile2 = spellPile;
				spellPile2.CursorSelectEnded = (Action<MainInputInteractable>)Delegate.Combine(spellPile2.CursorSelectEnded, new Action<MainInputInteractable>(delegate (MainInputInteractable m)
				{ }));

				__instance.pileIconDefaultColor = __instance.mainPileLitRenderer.material.GetColor("_EmissionColor");

				try
				{
					Singleton<CardDrawPiles3D>.Instance.pile.DestroyCardsImmediate();
					Singleton<MagnificusCardDrawPiles>.Instance.Deck.cards = nospellsallowed;
					Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(Singleton<CardDrawPiles3D>.Instance.pile.SpawnCards(__instance.deckList.Count, 0.5f));

					Singleton<CardDrawPiles3D>.Instance.sidePile.DestroyCardsImmediate();
					Singleton<MagnificusCardDrawPiles>.Instance.SideDeck.cards = __instance.sideDeckList;
					Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(Singleton<CardDrawPiles3D>.Instance.sidePile.SpawnCards(__instance.sideDeckList.Count, 0.5f));
				}
				catch { }
				//spellPile.gameObject.SetActive(false);
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
				CardPile spellPile = null;
				CardPile selectedPile = null;

				if (SceneLoader.ActiveSceneName == "finale_magnificus")
				{
					try
					{
						__state.gameObject.transform.Find("SpellPile").gameObject.SetActive(true);
						if (Singleton<SpellPile>.Instance.spellList.Count > 0)
						{
							__state.gameObject.transform.Find("SpellPile").Find("spellBook").gameObject.SetActive(true);
							__state.gameObject.transform.Find("SpellPile").Find("spellBook").localPosition = new Vector3(0f, -0.24f, 0);
							__state.gameObject.transform.Find("SpellPile").Find("spellBook").rotation = Quaternion.Euler(0, 299, 0);
							Tween.Rotation(__state.gameObject.transform.Find("SpellPile").Find("spellBook"), Quaternion.Euler(0, 299, 0), 0f, 1);
							__state.gameObject.transform.Find("SpellPile").Find("spellBook").gameObject.GetComponent<SineWaveMovement>().enabled = true;
						}
						spellPile = __state.gameObject.transform.Find("SpellPile").gameObject.GetComponent<CardPile>();

						if (__state.pile.gameObject.transform.childCount >= 23)
						{
							for (int i = 22; i < __state.pile.gameObject.transform.childCount; i++)
							{
								__state.pile.gameObject.transform.GetChild(i).GetChild(0).gameObject.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1, 0);
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
				if (spellPile != null && __state.gameObject.GetComponent<SpellPile>().spellList.Count > 0)
				{
					spellPile.gameObject.GetComponent<Collider>().enabled = true;
					spellPile.CanDrawFromPile = true;
					spellPile.CursorSelectEnded = (Action<MainInputInteractable>)Delegate.Combine(spellPile.CursorSelectEnded, new Action<MainInputInteractable>(delegate (MainInputInteractable i)
					{
						selectedPile = spellPile;
					}));
				}
				/*
				if (SceneLoader.ActiveSceneName == "finale_magnificus")
                {
					CardPile spellPile = __state.gameObject.transform.Find("SpellPile").gameObject.GetComponent<CardPile>();
					Debug.Log(__state.gameObject.GetComponent<SpellPile>().spellList.Count);
					if (__state.gameObject.GetComponent<SpellPile>().spellList.Count > 0)
                    {
						spellPile.CanDrawFromPile = true;
						CardPile cardPile3 = spellPile;
						cardPile3.CursorSelectEnded = (Action<MainInputInteractable>)Delegate.Combine(cardPile3.CursorSelectEnded, new Action<MainInputInteractable>(delegate (MainInputInteractable i)
						{
							selectedPile = spellPile;
						}));
					}
                }*/
				if (numDrawnThisPhase == 1 && Singleton<BoonsHandler>.Instance.HasBoonOfType(BoonData.Type.DoubleDraw))
				{
					yield return Singleton<BoonsHandler>.Instance.PlayBoonAnimation(BoonData.Type.DoubleDraw);
				}
				yield return new WaitUntil(() => selectedPile != null);

				__state.ClearPileDelegates();
				__state.pile.CanDrawFromPile = (__state.sidePile.CanDrawFromPile = false);

				if (selectedPile == __state.sidePile)
				{
					if (MagnificusMod.Generation.challenges.Contains("RandomSidedeck") && KayceeStorage.IsKaycee)
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
				if (selectedPile == spellPile)
					{
						__state.gameObject.transform.Find("SpellPile").gameObject.GetComponent<CardPile>().Draw();
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
				else if (selectedPile == spellPile)
				{
					yield return __state.gameObject.GetComponent<SpellPile>().DrawFromSpellPile();
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
					if (__instance.gameObject.name == "SpellPile" && Singleton<SpellPile>.Instance.spellData.Count > 1)
					{
						transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1, 0);
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

	}
}
