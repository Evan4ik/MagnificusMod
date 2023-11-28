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
using System.Linq;
using UnityEngine.UI;
using Tools = MagnificusMod.Tools;
using Random = UnityEngine.Random;
using MagSave = MagnificusMod.Plugin.MagCurrentNode;
using SavedVars = MagnificusMod.SaveVariables;
using KayceeStorage = MagnificusMod.KayceeStorage;

namespace MagnificusMod
{
    class SelectFixes
    {
		//rotate the nodes

		[HarmonyPatch(typeof(CardChoicesSequencer), "ChooseCards")]
		public class SelectFix0
		{
			// Token: 0x06000103 RID: 259 RVA: 0x00019361 File Offset: 0x00017561
			public static void Prefix(out CardChoicesSequencer __state, ref CardChoicesSequencer __instance)
			{
				__state = __instance;
			}

			public static IEnumerator Postfix(IEnumerator enumerator, CardChoicesSequencer __state, SpecialNodeData choicesData)
			{
				if (__state.gamepadGrid != null)
				{
					__state.gamepadGrid.enabled = true;
				}
				if (SceneLoader.ActiveSceneName == "finale_magnificus")
				{
					Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(__state.deckPile.SpawnCards(SaveManager.SaveFile.CurrentDeck.Cards.Count, 1f));
					Singleton<ViewManager>.Instance.SwitchToView(__state.choicesView, false, true);
					float pauseTime = CardPile.GetPauseBetweenCardTime(SaveManager.SaveFile.CurrentDeck.Cards.Count) * 1;
					yield return new WaitForSeconds(pauseTime + 0.015f);
					for (int i = 2; i < SaveManager.SaveFile.CurrentDeck.Cards.Count + 2; i++)
					{
						__state.deckPile.transform.GetChild(i).Find("BendableCard").Find("Mesh").gameObject.GetComponent<SkinnedMeshRenderer>().materials[1].mainTexture = Tools.getImage("magcardback.png");
						yield return new WaitForSeconds(pauseTime + 0.015f);
					}
					yield return __state.CardSelectionSequence(choicesData);
					if (__state.gamepadGrid != null)
					{
						__state.gamepadGrid.enabled = false;
					}
					yield return new WaitForSeconds(0.75f);
					yield return __state.deckPile.DestroyCards(0.5f);
					Singleton<TextDisplayer>.Instance.Clear();
					if (Singleton<GameFlowManager>.Instance != null)
					{
						Singleton<GameFlowManager>.Instance.TransitionToGameState(GameState.Map, null);
					}
				}
				else
				{
					Singleton<TableRuleBook>.Instance.SetOnBoard(true);
					__state.StartCoroutine(__state.deckPile.SpawnCards(SaveManager.SaveFile.CurrentDeck.Cards.Count, 1f));
					Singleton<ViewManager>.Instance.SwitchToView(__state.choicesView, false, true);
					yield return __state.CardSelectionSequence(choicesData);
					if (__state.gamepadGrid != null)
					{
						__state.gamepadGrid.enabled = false;
					}
					yield return new WaitForSeconds(0.75f);
					yield return __state.deckPile.DestroyCards(0.5f);
					Singleton<TextDisplayer>.Instance.Clear();
					if (Singleton<GameFlowManager>.Instance != null)
					{
						Singleton<GameFlowManager>.Instance.TransitionToGameState(GameState.Map, null);
					}
					yield break;
				}
				yield break;
			}
		}

		[HarmonyPatch(typeof(CardSingleChoicesSequencer), "SpawnMushroom")]
		public class SelectFixBonus
		{
			public static bool Prefix()
			{
				if (SceneLoader.ActiveSceneName == "finale_magnificus")
				{
					return false;
				}
				return true;
			}
		}

		[HarmonyPatch(typeof(CardSingleChoicesSequencer), "TutorialTextSequence")]
		public class SelectFix
		{
			// Token: 0x06000103 RID: 259 RVA: 0x00019361 File Offset: 0x00017561
			public static void Prefix(out CardSingleChoicesSequencer __state, ref CardSingleChoicesSequencer __instance)
			{
				__state = __instance;
			}

			// Token: 0x06000104 RID: 260 RVA: 0x00019368 File Offset: 0x00017568
			public static IEnumerator Postfix(IEnumerator enumerator, SelectableCard card, CardSingleChoicesSequencer __state)
			{
				bool flag = !string.IsNullOrEmpty(card.Info.description) && !ProgressionData.IntroducedCard(card.Info);
				if (flag)
				{
					
					List<string> intros = new List<string>
					{
						"You glance at a " + card.Info.displayedName + ". ",
						"A " + card.Info.displayedName + " appears from within the portrait. ",
						"You gaze at a " + card.Info.displayedName + ". "
					};
					string introDialogue = intros[UnityEngine.Random.Range(0, intros.Count)];
					if (card.Info.displayedName == "--~~--~~--" || card.Info.displayedName == "~-~-~-~-~-~" || card.Info.displayedName == "~~--~~--~~" || card.Info.name == "mag_mastergo" || card.Info.name == "mag_masterbg" || card.Info.name == "mag_masterob" || card.Info.name == "mag_masterkraken" || card.Info.name == "mag_goobert" || card.Info.name == "mag_espearara" || card.Info.name == "mag_lonelymage" || card.Info.HasTrait(Trait.EatsWarrens))
					{
						introDialogue = "";
					}
					else
					{
						if (card.Info.displayedName.ToLower()[0] == 'a' || card.Info.displayedName.ToLower()[0] == 'e' || card.Info.displayedName.ToLower()[0] == 'o' || card.Info.displayedName.ToLower()[0] == 'i' || card.Info.displayedName.ToLower()[0] == 'u')
						{
							intros = new List<string>
							{
								"You glance at an " + card.Info.displayedName + ". ",
								"An " + card.Info.displayedName + " appears from within the portrait. ",
								"You gaze at an " + card.Info.displayedName + ". "
							};
							introDialogue = intros[UnityEngine.Random.Range(0, intros.Count)];
						}

					}
					
					if (SceneLoader.ActiveSceneName == "finale_magnificus")
					{
						yield return __state.ExamineCardWithDialogue(card, introDialogue + card.Info.description);
					}
					else
					{
						yield return __state.ExamineCardWithDialogue(card, card.Info.description);
					}
					ProgressionData.SetCardIntroduced(card.Info);
					intros = null;
					introDialogue = null;
				}
				yield break;
			}
		}

		[HarmonyPatch(typeof(CardSingleChoicesSequencer), "CardSelectionSequence")]
		public class SelectFix2
		{
			public static void Prefix(out CardSingleChoicesSequencer __state, ref CardSingleChoicesSequencer __instance)
			{
				__state = __instance;
			}

			public static IEnumerator Postfix(IEnumerator enumerator, SpecialNodeData nodeData, CardSingleChoicesSequencer __state)
			{
				yield return new WaitForSeconds(0.6f);
				CardChoicesNodeData choicesData = nodeData as CardChoicesNodeData;
				bool flag = !SavedVars.LearnedMechanics.Contains("cardchoice;");
				__state.chosenReward = null;
				int randomSeed = SaveManager.SaveFile.GetCurrentRandomSeed();
				while (__state.chosenReward == null)
				{
					randomSeed -= 8;
					if (randomSeed < 0)
					{
						SaveManager.SaveFile.randomSeed = -SaveManager.SaveFile.randomSeed;
						randomSeed = -randomSeed;
					}
					List<CardChoice> choices = __state.choiceGenerator.GenerateChoices(choicesData, randomSeed);
					float x = (float)(choices.Count - 1) * 0.5f * -1.5f;
					yield return (object)new WaitForSeconds(0.2f);
					List<int> moxTypes = new List<int>();
					((CardChoicesSequencer)__state).selectableCards = ((CardChoicesSequencer)__state).SpawnCards(choices.Count, ((Component)__state).transform, new Vector3(x, 5.01f, 1f), 1.5f);
					for (int i = 0; i < choices.Count; i++)
					{
						CardChoice cardChoice = choices[i];
						SelectableCard card = ((CardChoicesSequencer)__state).selectableCards[i];
						((Component)card).gameObject.SetActive(true);
						card.SetParticlesEnabled(false);
						((InteractableBase)card).SetEnabled(false);
						card.ChoiceInfo = cardChoice;
						if (cardChoice.CardInfo != null)
						{
							card.Initialize(cardChoice.CardInfo, (Action<SelectableCard>)__state.OnRewardChosen, (Action<SelectableCard>)__state.OnCardFlipped, true, (Action<SelectableCard>)((CardChoicesSequencer)__state).OnCardInspected);
						}
						else if ((int)cardChoice.resourceType > 0)
						{
							if (SceneLoader.ActiveSceneName == "finale_magnificus")
							{
								cardChoice.resourceType = ResourceType.Blood;
								if (moxTypes.IndexOf((int)cardChoice.resourceAmount) < 0)
								{
									moxTypes.Add((int)cardChoice.resourceAmount);
								}
								else
								{
									List<int> possible = new List<int> { 1, 2, 3 };
									possible.RemoveAll((int x) => moxTypes.IndexOf(x) > -1);
									cardChoice.resourceAmount = possible[0];
									cardChoice.resourceType = ResourceType.Blood;
								}
							}
							card.Initialize(__state.GetCardbackTexture(cardChoice), (Action<SelectableCard>)__state.OnRewardChosen, (Action<SelectableCard>)__state.OnCardFlipped, (Action<SelectableCard>)((CardChoicesSequencer)__state).OnCardInspected);
						}
						else if ((int)cardChoice.tribe > 0)
						{
							card.Initialize(__state.GetCardbackTexture(cardChoice), (Action<SelectableCard>)__state.OnRewardChosen, (Action<SelectableCard>)__state.OnCardFlipped, (Action<SelectableCard>)((CardChoicesSequencer)__state).OnCardInspected);
						}
						if (cardChoice.isDeathcardChoice)
						{
							((Card)card).SetCardback(ResourceBank.Get<Texture>("Art/Cards/card_back_deathcard"));
						}
						((Card)card).SetFaceDown(true, true);
						Vector3 positio2n = card.transform.position;
						card.transform.position = card.transform.position + Vector3.forward * 5f + new Vector3(9.5f, 0f, 0f);
						Tween.Position(((Component)card).transform, positio2n, 0.3f, 0f, Tween.EaseInOut, 0, null, null, true);
						Tween.Rotate(((Component)card).transform, new Vector3(0f, 0f, UnityEngine.Random.value * 1.5f), (Space)1, 0.4f, 0f, Tween.EaseOut, 0, (Action)null, (Action)null, true);
						yield return (object)new WaitForSeconds(0.2f);
						((Component)card).GetComponentInChildren<ParticleSystem>();
					}
					yield return (object)new WaitForSeconds(0.2f);
					if ((int)choicesData.choicesType == 1 && !ProgressionData.LearnedMechanic((MechanicsConcept)3))
					{
						yield return Singleton<TextDisplayer>.Instance.PlayDialogueEvent("TutorialCost__statedChoice", TextDisplayer.MessageAdvanceMode.Input, 0, (string[])null, null);
						yield return (object)new WaitForSeconds(0.2f);
					}
					else if ((int)choicesData.choicesType == 2 && !ProgressionData.LearnedMechanic((MechanicsConcept)2))
					{
						yield return Singleton<TextDisplayer>.Instance.PlayDialogueEvent("TutorialTribe__statedChoice", TextDisplayer.MessageAdvanceMode.Input, 0, (string[])null, null);
						yield return (object)new WaitForSeconds(0.2f);
					}
					else if ((int)choicesData.choicesType == 3 && !ProgressionData.LearnedMechanic((MechanicsConcept)60))
					{
						yield return Singleton<TextDisplayer>.Instance.PlayDialogueEvent("TutorialDeathcardChoice", TextDisplayer.MessageAdvanceMode.Input, 0, (string[])null, null);
						yield return (object)new WaitForSeconds(0.2f);
						ProgressionData.SetMechanicLearned((MechanicsConcept)60);
					}
					if (flag && SceneLoader.ActiveSceneName == "finale_magnificus" && !SaveManager.saveFile.ascensionActive)
					{
						SavedVars.LearnedMechanics += "cardchoice;";
						yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Through this maze of paintings and illusions, there may be some that deign to join your deck.\nChoose carefully.", -2.5f, 0.5f, (Emotion)0, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Magnificus, (string[])null, true);
					}
					((CardChoicesSequencer)__state).SetCollidersEnabled(true);
					__state.choicesRerolled = false;
					((CardChoicesSequencer)__state).EnableViewDeck(__state.viewControlMode, __state.basePosition);
					yield return (object)new WaitUntil((Func<bool>)(() => __state.chosenReward != null || __state.choicesRerolled));
					((CardChoicesSequencer)__state).DisableViewDeck();
					__state.CleanUpCards(true);
				}
				__state.CleanUpRerollItem();
				yield return __state.RewardChosenSequence(__state.chosenReward);
				__state.AddChosenCardToDeck();
				Singleton<TextDisplayer>.Instance.Clear();
			}
		}

		[HarmonyPatch(typeof(CardSingleChoicesSequencer), "CardExaminePosition", MethodType.Getter)]
		public class SelectFix3
		{
			public static bool Prefix(ref Vector3 __result, ref CardSingleChoicesSequencer __instance)
			{
				if (SceneLoader.ActiveSceneName != "finale_magnificus")
				{
					return true;
				}
				__result = new Vector3(__instance.transform.position.x, 15.6f, __instance.transform.position.z - 0.5f);
				return false;
			}
		}

		[HarmonyPatch(typeof(RareCardChoicesSequencer), "CardExaminePosition", MethodType.Getter)]
		public class SelectFix4
		{
			public static bool Prefix(ref Vector3 __result, ref CardSingleChoicesSequencer __instance)
			{
				if (SceneLoader.ActiveSceneName != "finale_magnificus")
				{
					return true;
				}
				__result = new Vector3(__instance.transform.position.x, 15.6f, __instance.transform.position.z);
				return false;
			}
		}

		[HarmonyPatch(typeof(Part1CardChoiceGenerator), "GenerateDirectChoices")]
		public class SelectFix5
		{
			public static bool Prefix(ref List<CardChoice> __result, ref CardSingleChoicesSequencer __instance, int randomSeed)
			{
				if (SceneLoader.ActiveSceneName != "finale_magnificus")
				{
					return true;
				}
				List<CardChoice> list = new List<CardChoice>();
				List<CardInfo> allChoices = CardLoader.GetUnlockedCards(CardMetaCategory.ChoiceNode, CardTemple.Wizard);
				if (SaveManager.saveFile.part3Data.bountyHunterMods.Count > 0 && !SaveManager.saveFile.ascensionActive)
                {
					List<string> modNames = new List<string>();
					List<List<CardModificationInfo>> modList = RunState.Run.playerDeck.cardIdModInfos.Values.ToList();

					foreach(List<CardModificationInfo> mods in modList)//verry messi
					{
						if (mods.Count > 0)
                        {
							foreach (CardModificationInfo mod in mods)//messi
							{
								if (mod.nameReplacement != null && mod.nameReplacement != "")
								{
									if (mod.decalIds != null && mod.decalIds.Count > 0)
									{
										if (mod.decalIds[0] == "MAGNIFICUSDEATHCARD")
										{
											modNames.Add(mod.nameReplacement);
										}
									}
								}
							}
						}
					}

					foreach(CardModificationInfo mod in SaveManager.saveFile.part3Data.bountyHunterMods)
                    {
						if (mod.decalIds != null)
                        {
							if (mod.decalIds.Count < 1) { continue; }
							if (mod.decalIds[0] == "MAGNIFICUSDEATHCARD" && !modNames.Contains(mod.nameReplacement)) 
							{
								CardInfo DeathCard = CardLoader.GetCardByName("mag_deathcardbase");
								DeathCard.mods.Add(mod);
								allChoices.Add(DeathCard);
							}
                        }
                    }
                }
				while (list.Count < 3)
				{
					CardInfo card = allChoices[SeededRandom.Range(0, allChoices.Count, randomSeed++)];
					while (list.Exists((CardChoice x) => x.CardInfo.name == card.name))
					{
						card = allChoices[SeededRandom.Range(0, allChoices.Count, randomSeed++)];
					}
					if (card.name != "mag_deathcardbase")
					{
						card.mods = new List<CardModificationInfo>();
					}
					list.Add(new CardChoice
					{
						CardInfo = card
					});
				}
				__result = list;
				return false;
			}
		}

		[HarmonyAfter(new string[] { "cyantist.inscryption.api" })]
		[HarmonyPatch(typeof(Part1CardChoiceGenerator), "GenerateCostChoices")]
		public class SelectFix6
		{
			public static bool Prefix(ref List<CardChoice> __result, ref CardSingleChoicesSequencer __instance, int randomSeed)
			{
				if (SceneLoader.ActiveSceneName != "finale_magnificus")
				{
					return true;
				}
				List<CardChoice> list = new List<CardChoice>();
				for (int i = 1; i <= 3; i++)
				{
					list.Add(new CardChoice
					{
						resourceType = ResourceType.Blood,
						resourceAmount = i
					});
				}
				__result = list;
				return false;
			}
		}

		[HarmonyPatch(typeof(CardChoicesSequencer), "OnViewChanged")]
		public class DeckFix
		{
			// Token: 0x06000106 RID: 262 RVA: 0x00019390 File Offset: 0x00017590
			public static void Prefix(ref CardChoicesSequencer __instance, ref View newView, ref View oldView)
			{
				if (SceneLoader.ActiveSceneName == "finale_magnificus")
				{
					bool flag = newView != View.MapDeckReview;
					if (flag)
					{//DeckReviewCardArray
						__instance.SetCollidersEnabled(true);
						Vector3 endValue = new Vector3(GameObject.Find("GameTable").transform.position.x, 9.72f, GameObject.Find("GameTable").transform.position.z - 2f);
						Tween.Position(__instance.transform, endValue, 0.2f, 0.2f, null, Tween.LoopType.None, null, null, true);
					}
					if (newView == View.MapDeckReview)
					{
						GameObject theDeck = GameObject.Find("DeckReviewCardArray");
						theDeck.transform.parent = GameObject.Find("GameTable").transform;
						theDeck.transform.localPosition = new Vector3(0, 5.01f, 1.5f);
						__instance.SetCollidersEnabled(false);
						Vector3 endValue = new Vector3(GameObject.Find("GameTable").transform.position.x - 5f, 9.72f, GameObject.Find("GameTable").transform.position.z - 2f);
						Tween.Position(__instance.transform, endValue, 0.2f, 0.2f, null, Tween.LoopType.None, null, null, true);
					}
					if (newView == View.TradingTopDown)
                    {
						Tween.LocalPosition(GameObject.Find("TradePeltsSequencer").transform, new Vector3(0, 0, 0), 0.01f, 0.35f);
						//GameObject.Find("TradePeltsSequencer").transform.localPosition = new Vector3(0, 0, 0);
                    }
				}
			}
		}
	}
}
