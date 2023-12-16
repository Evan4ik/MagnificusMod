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
    class TurnManagerStuff
    {
		//rotate the nodes


		[HarmonyPatch(typeof(TurnManager), "ScalesTippedToOpponent")]
		public class PlauerWinFix
		{
			public static bool Prefix(ref bool __result)
			{
				if (SceneLoader.ActiveSceneName == "finale_magnificus")
				{
					__result = Singleton<MagnificusLifeManager>.Instance.opponentLife < 1;
					return false;
				}
				__result = Singleton<LifeManager>.Instance.Balance >= 5;
				return true;
			}
		}
		[HarmonyPatch(typeof(TurnManager), "GameIsOver")]
		public class IsGameOver
		{
			public static bool Prefix(ref bool __result, ref TurnManager __instance)
			{
				if (SceneLoader.ActiveSceneName == "finale_magnificus")
				{
					__result = __instance.PlayerIsWinner() || Singleton<MagnificusLifeManager>.Instance.playerLife < 1 || __instance.PlayerSurrendered;
					if (Singleton<MagnificusLifeManager>.Instance.playerLife < 1)
					{
						__instance.PlayerSurrendered = true;
					}
					return false;
				}
				__result = __instance.PlayerIsWinner() || Singleton<LifeManager>.Instance.Balance <= -5 || __instance.opponent.Surrendered || __instance.PlayerSurrendered;
				return true;
			}
		}


		[HarmonyPatch(typeof(TurnManager), "CleanupPhase")]
		public class IsGameOver23
		{
			public static void Prefix()
			{
				if (SceneLoader.ActiveSceneName == "finale_magnificus")
				{
					GameObject portraitSlots = GameObject.Find("OpponentSlots");
					GameObject.Find("GameTable").transform.Find("CardBattle_Magnificus").Find("CombatBell_Magnificus").transform.Find("Anim").localPosition = new Vector3(0, 0, 0);
					for (int i = 0; i < portraitSlots.transform.childCount; i++)
					{
						if (portraitSlots.transform.GetChild(i).Find("QueuedCardFrame").gameObject.activeSelf)
						{
							Vector3 originPos = portraitSlots.transform.GetChild(i).Find("QueuedCardFrame").position;
							Vector3 upPos = originPos;
							upPos.y += 15;
							Tween.Position(portraitSlots.transform.GetChild(i).Find("QueuedCardFrame"), upPos, 0.75f, 0f);
							Tween.Position(portraitSlots.transform.GetChild(i).Find("QueuedCardFrame"), originPos, 0.001f, 0.751f);
							Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(MagnificusMod.Generation.WaitThenDisable(portraitSlots.transform.GetChild(i).Find("QueuedCardFrame").gameObject, 0.752f));
						}
					}
				}
			}
		}

		[HarmonyPatch(typeof(GameFlowManager), "PlayerLostBattleSequence")]
		public class IsGameOver235
		{
			public static void Prefix(ref GameFlowManager __instance, Opponent opponent)
			{
				if (SceneLoader.ActiveSceneName == "finale_magnificus")
				{
					Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(PlayerLoss(__instance, opponent));
				}

			}
		}
		public static IEnumerator PlayerLoss(GameFlowManager instance, Opponent opponent)
		{
			int displayedLives = RunState.Run.playerLives;
			RunState.Run.playerLives--;
			if (RunState.Run.playerLives <= 0)
            {
				MagSave.SaveLayout("lbozo");
				MagSave.SaveNode("x4 y11");
				RunState.Run.regionTier = 972;
			}
			SaveManager.SaveToFile();
			if (instance.SpecialSequencer != null)
			{
				yield return instance.SpecialSequencer.CardBattleLost();
			}
			Singleton<InteractionCursor>.Instance.InteractionDisabled = true;
			if (Singleton<CandleHolder>.Instance != null)
			{
				yield return Singleton<CandleHolder>.Instance.BlowOutCandleSequence(false);
			}
			if (RunState.Run.regionTier == 0 || config.isometricMode)
			{
				Singleton<ViewManager>.Instance.SwitchToView(View.Candles);
			}
			yield return new WaitForSeconds(1f);
			if (instance.SpecialSequencer != null)
			{
				//yield return instance.SpecialSequencer.CandleBlownOut();
			}
			if (RunState.Run.playerLives > 0 && Singleton<TextDisplayer>.Instance != null)
			{
				Singleton<ViewManager>.Instance.SwitchToView(View.Candles);
				GameObject lifeCounter = GameObject.Find("GameTable").transform.Find("LifePainting").gameObject;
				lifeCounter.SetActive(true);
				lifeCounter.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = Tools.getImage("lifepainting" + displayedLives + ".png");
				Vector3 pos = lifeCounter.transform.position;
				Vector3 tPos = pos;
				tPos.y -= 10;
				Tween.Position(lifeCounter.transform, tPos, 1.5f, 0);
				Singleton<TextDisplayer>.Instance.Clear();
				if (!SavedVars.LearnedMechanics.Contains("lifelost;") && !SaveManager.saveFile.ascensionActive)
				{
					Singleton<ViewManager>.Instance.SwitchToView(View.Candles);
					yield return new WaitForSeconds(1.49f);
					Singleton<FirstPersonController>.Instance.LookAtDirection(LookDirection.North);
					lifeCounter.GetComponent<SineWaveMovement>().originalPosition = lifeCounter.transform.localPosition;
					lifeCounter.GetComponent<SineWaveMovement>().enabled = true;
					yield return new WaitForSeconds(0.5f);//It seems that you lost.
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("It seems that you lost..", 0f, 0f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("See this portrait?", 0f, 0f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("This portrait will act as your life counter.", 0f, 0f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Once all the [c:g1]m[c:][c:g2]o[c:][c:g3]x[c:] [c:g1]g[c:][c:g2]e[c:][c:g3]m[c:][c:g1]s[c:] go out.. You lose the game.", 0f, 0f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Since you lost.. I will have to remove one gem.", -0.5f, 0f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
					Tween.Rotation(lifeCounter.transform, Quaternion.Euler(0, 225, 0), 0.8f, 0);
					Tween.Rotation(lifeCounter.transform, Quaternion.Euler(0, 45, 0), 1.2f, 0.88f);
					yield return new WaitForSeconds(0.8f);
					displayedLives -= 1;
					AudioController.Instance.PlaySound2D("magnificus_brush_splatter_bleach", MixerGroup.None, 0.5f, 0f, null, null, null, null, false);
					lifeCounter.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = Tools.getImage("lifepainting" + displayedLives + ".png");
					yield return new WaitForSeconds(1.4f);
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("The deed has been done.", -0f, 0f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
					yield return new WaitForSeconds(0.65f);
					SavedVars.LearnedMechanics += "lifelost;";
				}
				else
				{
					Singleton<ViewManager>.Instance.SwitchToView(View.Candles);
					yield return new WaitForSeconds(1.49f);
					Singleton<FirstPersonController>.Instance.LookAtDirection(LookDirection.North);
					lifeCounter.GetComponent<SineWaveMovement>().originalPosition = lifeCounter.transform.localPosition;
					lifeCounter.GetComponent<SineWaveMovement>().enabled = true;
					if (RunState.Run.regionTier == 0)
					{
						RunState.Run.playerLives = 0;
						displayedLives = 1;
					}
					if (displayedLives == 3)
					{
						if (UnityEngine.Random.RandomRangeInt(0, 100) >= 50)
						{
							yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Looks like you have been knocked down by your opponent.", -0.5f, 0f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
							yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Stand tall, and continue forth.", 0f, 0f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
						}
						else
						{
							yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("It seems as though you should study up on mox.", -0.5f, 0f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
							yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Though you should not lose hope, as you still have 2 more lives.", 0f, 0f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
						}
					}
					else if (displayedLives == 2)
					{
						if (UnityEngine.Random.RandomRangeInt(0, 100) >= 50)
						{
							yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("You make a last effort to succeed, yet fail. It seems you lose, again.", -0.5f, 0f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
							yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("You shall continue forward.", 0f, 0f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
						}
						else
						{
							yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("It takes just one more blow for you to fall to the ground.", -0.5f, 0f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
							yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Losing a life, you must continue forward.", 0f, 0f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
						}
					}
					else if (displayedLives == 1 && RunState.Run.currentNodeId < 101)
					{
						MagSave.SaveLayout("lbozo");
						yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("It seems the show shall end… for now..", -1.5f, 0f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
					}
					yield return new WaitForSeconds(0.5f);
					Tween.Rotation(lifeCounter.transform, Quaternion.Euler(0, 225, 0), 0.8f, 0);
					Tween.Rotation(lifeCounter.transform, Quaternion.Euler(0, 45, 0), 1.2f, 0.88f);
					yield return new WaitForSeconds(0.8f);
					displayedLives -= 1;
					AudioController.Instance.PlaySound2D("magnificus_brush_splatter_bleach", MixerGroup.None, 0.5f, 0f, null, null, null, null, false);
					lifeCounter.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = Tools.getImage("lifepainting" + displayedLives + ".png");
					yield return new WaitForSeconds(1.75f);
				}
				Vector3 tpos2 = lifeCounter.transform.localPosition;
				tpos2.y = 16.72f;
				lifeCounter.GetComponent<SineWaveMovement>().enabled = false;
				Tween.LocalPosition(lifeCounter.transform, tpos2, 1.5f, 0);
				lifeCounter.GetComponent<SineWaveMovement>().originalPosition = tpos2;
				yield return new WaitForSeconds(1.51f);
				lifeCounter.SetActive(false);
			}
			if (RunState.Run.playerLives <= 0)
			{
				if (RunState.Run.currentNodeId < 101)
				{
					RunState.Run.currentNodeId = RunState.Run.regionTier;
				}
				RunState.Run.causeOfDeath = new RunState.CauseOfDeath(opponent.OpponentType);
				AudioController.Instance.FadeOutLoop(3f, Array.Empty<int>());
				yield return new WaitForSeconds(0.5f);
				yield return opponent.DefeatedPlayerSequence();
				Singleton<ViewManager>.Instance.SwitchToView(View.Default, false, false);
				yield return MagnificusMod.Generation.transition("depths", "unspin");
				yield break;
			}
			Singleton<InteractionCursor>.Instance.InteractionDisabled = false;
			Singleton<ViewManager>.Instance.SwitchToView(View.FirstPerson, false, false);
			yield return MagnificusMod.Generation.WaitThenEnablePlayer(0.5f);
			SaveManager.SaveToFile();
			yield break;
		}

		[HarmonyPatch(typeof(TurnManager), "LifeLossConditionsMet")]
		public class IsGameOver2
		{
			public static bool Prefix(ref bool __result, ref TurnManager __instance)
			{
				if (SceneLoader.ActiveSceneName == "finale_magnificus")
				{
					if (Singleton<MagnificusLifeManager>.Instance.playerLife < 1)
					{
						__instance.PlayerSurrendered = true;
					}
					__result = Mathf.Abs(Singleton<MagnificusLifeManager>.Instance.opponentLife) < 1 || __instance.PlayerSurrendered;
					return false;
				}
				__result = Mathf.Abs(Singleton<LifeManager>.Instance.Balance) >= 5 || __instance.opponent.Surrendered || __instance.PlayerSurrendered;
				return true;
			}
		}

		[HarmonyPatch(typeof(CombatPhaseManager3D), "VisualizeCardAttackingDirectly")]
		public class iwantTeeth
		{
			public static void Prefix(out CombatPhaseManager3D __state, ref CombatPhaseManager3D __instance)
			{
				__state = __instance;
			}

			public static IEnumerator Postfix(IEnumerator enumerator, CombatPhaseManager3D __state, CardSlot attackingSlot, CardSlot targetSlot, int damage)
			{
				List<Transform> newWeights = new List<Transform>();
				for (int i = 0; i < Mathf.Min(20, damage); i++)
				{
					GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(__state.weightPrefab);
					if (SceneLoader.ActiveSceneName == "Part1_Cabin")
					{
						gameObject = GameObject.Instantiate(GameObject.Find("CurrencyBowl").transform.Find("Weights").Find("Weight").gameObject);
						WeightUtil.part1Prefab = GameObject.Find("CurrencyBowl").transform.Find("Weights").Find("Weight").gameObject;
					}
					Vector3 b = new Vector3(0f, 0f, attackingSlot.IsPlayerSlot ? 0.75f : -0.75f);
					gameObject.transform.position = targetSlot.transform.position + b + new Vector3((float)i * 0.1f, 0f, (float)i * 0.1f);
					gameObject.transform.eulerAngles = UnityEngine.Random.insideUnitSphere;
					newWeights.Add(gameObject.transform);
				}
				__state.damageWeights.AddRange(newWeights);
				attackingSlot.Card.Anim.PlayAttackAnimation(true, targetSlot, delegate ()
				{
					if (Singleton<TableVisualEffectsManager>.Instance != null)
					{
						Singleton<TableVisualEffectsManager>.Instance.ThumpTable(0.075f * (float)Mathf.Min(10, damage));
					}
					foreach (Transform transform in newWeights)
					{
						if (transform != null)
						{
							transform.gameObject.SetActive(true);
							transform.GetComponent<Rigidbody>().AddForce(Vector3.up * 4f, ForceMode.VelocityChange);
						}
					}
				});
				yield break;
			}
		}

		[HarmonyPatch(typeof(TurnManager), "OnCombatBellRang")]
		public class bellTest
		{
			public static void Prefix(ref TurnManager __instance)
			{
				if (SceneLoader.ActiveSceneName != "finale_magnificus")
                {
					return;
                }
				bool boss = (GameObject.Find("GameTable").transform.Find("Goober").gameObject.activeSelf || GameObject.Find("GameTable").transform.Find("Espeara").gameObject.activeSelf || GameObject.Find("GameTable").transform.Find("LonelyMage").gameObject.activeSelf || RunState.Run.regionTier == 4 || GameObject.Find("goranjPainting") != null || GameObject.Find("orluPainting") != null || GameObject.Find("bleenePainting") != null);
				int turns = boss ? 12 : 6;
				if (SaveManager.saveFile.ascensionActive && MagnificusMod.Generation.challenges.Contains("TurnWipeout") && __instance.TurnNumber > turns)
				{
					ChallengeActivationUI.TryShowActivation(KayceeFixes.ChallengeManagement.TurnWipeout);
					__instance.StartCoroutine(Singleton<MagnificusLifeManager>.Instance.ShowLifeLoss(true, 1));
				}
			}
		}

		[HarmonyPatch(typeof(TurnManager), "PlayerTurn")]
		public class MasterMagnusPatch
		{
			public static void Prefix(ref TurnManager __instance)
			{
				if (SceneLoader.ActiveSceneName != "finale_magnificus")
				{
					return;
				}
				bool boss = (GameObject.Find("GameTable").transform.Find("Goober").gameObject.activeSelf || GameObject.Find("GameTable").transform.Find("Espeara").gameObject.activeSelf || GameObject.Find("GameTable").transform.Find("LonelyMage").gameObject.activeSelf);
				if (!boss && SaveManager.saveFile.ascensionActive && MagnificusMod.Generation.challenges.Contains("MasterMagnus") && __instance.TurnNumber == 2 && RunState.Run.regionTier >= 1 && RunState.Run.regionTier <= 3)
				{
					__instance.StartCoroutine(SpawnMagnus());
				}
			}
		}

		public static IEnumerator SpawnMagnus()
        {
			while (Singleton<TurnManager>.Instance.PlayerPhase != TurnManager.PlayerTurnPhase.Main)
            {
				yield return new WaitForSeconds(0.25f);
			}
			yield return new WaitForSeconds(0.25f);
			CardSlot moonCardSlot = Singleton<BoardManager>.Instance.OpponentSlotsCopy.Find((CardSlot x) => x.Card == null);
			CardInfo cardInfo = CardLoader.GetCardByName("mag_mastertriple" + RunState.Run.regionTier);
			if (moonCardSlot == null)
			{
				CardSlot randomSlot = Singleton<BoardManager>.Instance.OpponentSlotsCopy[UnityEngine.Random.Range(0, Singleton<BoardManager>.Instance.OpponentSlotsCopy.Count)];
				yield return randomSlot.Card.Die(false, null, true);
				yield return new WaitForSeconds(0.25f);
			}
			yield return Singleton<BoardManager>.Instance.CreateCardInSlot(cardInfo, moonCardSlot, 0.1f);
			ChallengeActivationUI.TryShowActivation(KayceeFixes.ChallengeManagement.MasterMagnus);
			if (!SavedVars.LearnedMechanics.Contains("mastermagnus;"))
			{
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Just what is going on here?", -0.25f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("'Master Magnus'..", 0f, 0.5f, Emotion.Curious, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("There is [c:g2]NO[c:] such master!", -1.5f, 0.5f, Emotion.Anger, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Argh.. I guess, if you truly wish to play with such additions, I am truly unable to stop you.", -0.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Though, I do NOT approve of this.", -0.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
				SavedVars.LearnedMechanics += "mastermagnus;";
			} else
            {
				int rand = UnityEngine.Random.Range(0, 5);
				if (rand == 0)
                {
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("It appears that the ficticious Master Magnus has showed itself.", -0.25f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
				} else if (rand == 1)
                {
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("That horrid [c:g1]thing[c:] rears it's ugly head.", -0.25f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
				} else if (rand == 2)
                {
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("The released Master Magnus approaches.", -0.25f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
				} else if (rand == 3)
                {
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Careful. That horrible master is here.", -0.25f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
				} else if (rand == 4)
				{
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Master Magnus has arrived. Be cautious.", -0.25f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
				}
			}
		}

        [HarmonyPatch(typeof(CombatPhaseManager), "DoCombatPhase")]
		public class hopefullyFinalPatch
		{
			public static void Prefix(out CombatPhaseManager __state, ref CombatPhaseManager __instance)
			{
				__state = __instance;
			}

			public static IEnumerator Postfix(IEnumerator enumerator, CombatPhaseManager __state, bool playerIsAttacker, SpecialBattleSequencer specialSequencer)
			{
				MagnificusMod.Generation.damageDoneThisTurn = 0;
				List<CardSlot> attackingSlots = playerIsAttacker ? Singleton<BoardManager>.Instance.PlayerSlotsCopy : Singleton<BoardManager>.Instance.OpponentSlotsCopy;
				attackingSlots.RemoveAll((CardSlot x) => x.Card == null || x.Card.Attack == 0);
				bool atLeastOneAttacker = attackingSlots.Count > 0;
				yield return __state.InitializePhase(attackingSlots, playerIsAttacker);
				if (specialSequencer != null)
				{
					if (playerIsAttacker)
					{
						yield return specialSequencer.PlayerCombatStart();
					}
					else
					{
						yield return specialSequencer.OpponentCombatStart();
					}
				}
				if (atLeastOneAttacker)
				{
					bool attackedWithSquirrel = false;
					foreach (CardSlot cardSlot in attackingSlots)
					{
						cardSlot.Card.AttackedThisTurn = false;
						if (cardSlot.Card.Info.IsOfTribe(Tribe.Squirrel))
						{
							attackedWithSquirrel = true;
						}
					}
					for (int i = 0; i < attackingSlots.Count; i++)
					{
						if (attackingSlots[i].Card != null && !attackingSlots[i].Card.AttackedThisTurn)
						{
							attackingSlots[i].Card.AttackedThisTurn = true;
							yield return __state.SlotAttackSequence(attackingSlots[i]);
						}
					}
					List<CardSlot>.Enumerator enumerator2 = default(List<CardSlot>.Enumerator);
					if (specialSequencer != null && playerIsAttacker)
					{
						yield return specialSequencer.PlayerCombatPostAttacks();
					}
					if (MagnificusMod.Generation.damageDoneThisTurn > 0)
					{
						yield return new WaitForSeconds(0.1f);
						yield return __state.VisualizeDamageMovingToScales(playerIsAttacker);
						if (SceneLoader.ActiveSceneName != "finale_magnificus")
						{
							Singleton<ViewManager>.Instance.SwitchToView(View.Scales);
						}
						int excessDamage = 0;
						if (playerIsAttacker)
						{
							//5 - 2 = 3 - 2 = 1 - 2
							//5 - 2 = -3
							if (SceneLoader.ActiveSceneName == "finale_magnificus")
							{
								excessDamage = Singleton<MagnificusLifeManager>.Instance.opponentLife - MagnificusMod.Generation.damageDoneThisTurn;
								excessDamage = -excessDamage;
								if (MagnificusMod.Generation.damageDoneThisTurn >= 10 && SaveManager.saveFile.ascensionActive)
								{
									AchievementManager.Unlock(MagnificusMod.Achievements.BlueEyesWhiteDragon);
								}
							}
							else

							{
								excessDamage = Singleton<LifeManager>.Instance.Balance + MagnificusMod.Generation.damageDoneThisTurn - 5;
							}
							if (attackedWithSquirrel && excessDamage >= 0)
							{
								AchievementManager.Unlock(Achievement.PART1_SPECIAL1);
							}
							excessDamage = Mathf.Max(0, excessDamage);
						}
						int damage = MagnificusMod.Generation.damageDoneThisTurn - excessDamage;
						
						if (SaveManager.saveFile.ascensionActive && MagnificusMod.Generation.challenges.Contains("ShieldedMox") && damage > 4 && playerIsAttacker && SceneLoader.ActiveSceneName == "finale_magnificus")
						{
							excessDamage = Singleton<MagnificusLifeManager>.Instance.opponentLife - 4;
							excessDamage = -excessDamage;
							ChallengeActivationUI.TryShowActivation(KayceeFixes.ChallengeManagement.ShieldedMox);
							damage = 4;
						}
						if (SaveManager.saveFile.ascensionActive && MagnificusMod.Generation.challenges.Contains("DyingBreath") && playerIsAttacker && SceneLoader.ActiveSceneName == "finale_magnificus" && !Generation.didDyingBreath)
						{
							if (Singleton<MagnificusLifeManager>.Instance.opponentLife - damage < 1)
							{
								excessDamage = 0;
								damage += Singleton<MagnificusLifeManager>.Instance.opponentLife - damage;
								damage -= 1;
								Generation.didDyingBreath = true;
								ChallengeActivationUI.TryShowActivation(KayceeFixes.ChallengeManagement.DyingBreath);
							}
						}
						if (MagnificusMod.Generation.damageDoneThisTurn >= 666)
						{
							AchievementManager.Unlock(Achievement.PART2_SPECIAL2);
						}
						if (!(specialSequencer != null) || !specialSequencer.PreventDamageAddedToScales)
						{
							yield return Singleton<Scales3D>.Instance.AddDamage(damage, damage, !playerIsAttacker, null);
						}
						if (specialSequencer != null)
						{
							yield return specialSequencer.DamageAddedToScale(damage + excessDamage, playerIsAttacker);
						}

						if ((!(specialSequencer != null) || !specialSequencer.PreventDamageAddedToScales) && excessDamage > 0 && Singleton<TurnManager>.Instance.Opponent.NumLives == 1 && Singleton<TurnManager>.Instance.Opponent.GiveCurrencyOnDefeat)
						{
							if (SceneLoader.ActiveSceneName == "finale_magnificus")
							{
								yield return Singleton<TurnManager>.Instance.Opponent.TryRevokeSurrender();
								RunState.Run.currency += excessDamage;//-12.7205 10.815 -7.0875
																	  //yield return __state.VisualizeExcessLethalDamage(excessDamage, specialSequencer);
								List<GameObject> summonedWeights = new List<GameObject>();
								yield return new WaitForSeconds(0.5f);
								List<GameObject> manaTypes = new List<GameObject> { GameObject.Find("mana"), GameObject.Find("mana1"), GameObject.Find("mana2") };
								for (int i = 0; i < excessDamage; i++)
								{
									GameObject weightLol = GameObject.Instantiate(manaTypes[UnityEngine.Random.RandomRangeInt(0, manaTypes.Count)]);
									summonedWeights.Add(weightLol);
									weightLol.transform.parent = GameObject.Find("GameTable").transform;
									weightLol.transform.localPosition = new Vector3(0 + UnityEngine.Random.RandomRangeInt(-3, 3), 8.76f + UnityEngine.Random.RandomRangeInt(-3, 3), 5.08f + UnityEngine.Random.RandomRangeInt(-3, 3));
									weightLol.AddComponent<BoxCollider>();
									weightLol.GetComponent<BoxCollider>().size = new Vector3(0.3f, 0.3f, 0.3f);
									weightLol.AddComponent<Rigidbody>();
									AudioController.Instance.PlaySound3D("metal_drop", MixerGroup.TableObjectsSFX, weightLol.transform.position, 1f, 0f, new AudioParams.Pitch(0.7f), null, new AudioParams.Randomization(true), null, false);
									yield return new WaitForSeconds(0.1f);
								}
								yield return new WaitForSeconds(0.75f);
								foreach (GameObject weight in summonedWeights)
								{
									GameObject.Destroy(weight);
								}
								yield return MagnificusMod.Generation.currencyTutorial();
							}
							else
							{
								if (SceneLoader.ActiveSceneName != "finale_grimora")
								{
									yield return Singleton<TurnManager>.Instance.Opponent.TryRevokeSurrender();
									RunState.Run.currency += excessDamage;
									yield return __state.VisualizeExcessLethalDamage(excessDamage, specialSequencer);
								}
							}
						}
					}
					yield return new WaitForSeconds(0.15f);
					foreach (CardSlot cardSlot3 in attackingSlots)
					{
						if (cardSlot3.Card != null && cardSlot3.Card.TriggerHandler.RespondsToTrigger(Trigger.AttackEnded, Array.Empty<object>()))
						{
							yield return cardSlot3.Card.TriggerHandler.OnTrigger(Trigger.AttackEnded, Array.Empty<object>());
						}
					}
					enumerator2 = default(List<CardSlot>.Enumerator);
				}
				if (specialSequencer != null)
				{
					if (playerIsAttacker)
					{
						yield return specialSequencer.PlayerCombatEnd();
					}
					else
					{
						yield return specialSequencer.OpponentCombatEnd();
					}
				}
				Singleton<ViewManager>.Instance.Controller.LockState = ViewLockState.Unlocked;
				if (atLeastOneAttacker)
				{
					yield return new WaitForSeconds(0.15f);
				}
				yield break;
			}
		}

		[HarmonyPatch(typeof(LifeManager), "DamageUntilPlayerWin", MethodType.Getter)]
		public class PlayerWin
		{
			public static bool Prefix(ref int __result, ref LifeManager __instance)
			{
				if (SceneLoader.ActiveSceneName == "finale_magnificus")
				{
					__result = Singleton<MagnificusLifeManager>.Instance.opponentLife;
					return false;
				}
				return true;
			}
		}
	}
}
