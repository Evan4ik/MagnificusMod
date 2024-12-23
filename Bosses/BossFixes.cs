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
    class BossFixes
    {

		[HarmonyPatch(typeof(Part1BossOpponent), "IntroSequence")]
		public class bossIntro
		{
			public static void Prefix(out Part1BossOpponent __state, ref Part1BossOpponent __instance)
			{
				__state = __instance;
			}
			public static IEnumerator Postfix(IEnumerator enumerator, Part1BossOpponent __state)
			{
				//yield return __state.ReducePlayerLivesSequence();
				if (SceneLoader.ActiveSceneName == "finale_magnificus")
				{
					yield return new WaitForSeconds(0.25f);
					Singleton<ViewManager>.Instance.SwitchToView(View.BossSkull);
					GameObject bossLife = GameObject.Instantiate(GameObject.Find("GameTable").transform.Find("LifePainting").gameObject);
					bossLife.name = "bossPainting";
					bossLife.SetActive(true);
					bossLife.transform.parent = GameObject.Find("GameTable").transform;
					bossLife.transform.localPosition = new Vector3(-3.7f, 16.43f, 8.5f);
					float xOffset = 0;
					float zOffset = 0;
					float yOffset = 0;
					if (RunState.Run.regionTier == 4)
                    {
						xOffset = -18.3f;
						zOffset = 32f;
						yOffset = -2;
						bossLife.transform.localPosition = new Vector3(-22, 16.43f, 40.5f);
						bossLife.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
					}
					bossLife.transform.rotation = Quaternion.Euler(0, 325, 0);
					bossLife.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material = new Material(Shader.Find("Standard"));
					bossLife.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = Tools.getImage("goobert2life.png");
					if (RunState.Run.regionTier == 2)
					{
						bossLife.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = Tools.getImage("espeara2life.png");
					} else if (RunState.Run.regionTier == 3)
					{
						bossLife.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = Tools.getImage("lonely2life.png");
					}
					else if (RunState.Run.regionTier == 4)
					{
						bossLife.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = Tools.getImage("magnificus3life.png");
					}
					Tween.LocalPosition(bossLife.transform, new Vector3(-3.7f + xOffset, 6.5f + yOffset, 8.5f + zOffset), 1f, 0);
					yield return new WaitForSeconds(1f);
					bossLife.GetComponent<SineWaveMovement>().enabled = false;
					bossLife.GetComponent<SineWaveMovement>().originalPosition = new Vector3(-3.7f + xOffset, 5.43f + yOffset, 8.5f + zOffset);
					yield return new WaitForSeconds(0.5f);
					bossLife.GetComponent<SineWaveMovement>().enabled = false;
					Singleton<ViewManager>.Instance.SwitchToView(View.Default);
					yield return new WaitForSeconds(0.1f);
					bossLife.GetComponent<SineWaveMovement>().enabled = true;
					bossLife.GetComponent<SineWaveMovement>().originalPosition = new Vector3(-3.7f + xOffset, 6.43f + yOffset, 8.5f + zOffset);
					yield break;
				}
				else
				{
					RunState.CurrentMapRegion.FadeOutAmbientAudio();
					yield return __state.ReducePlayerLivesSequence();
					yield return new WaitForSeconds(0.25f);
					Singleton<ViewManager>.Instance.SwitchToView(View.BossSkull, false, true);
					yield return new WaitForSeconds(0.5f);
					GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(ResourceBank.Get<GameObject>("Prefabs/CardBattle/BossSkull"), __state.transform);
					__state.bossSkull = gameObject.GetComponent<BossSkull>();
					yield return new WaitForSeconds(0.166f);
					__state.SetSceneEffectsShown(true);
					yield break;
				}
			}
		}

		[HarmonyPatch(typeof(Part1BossOpponent), "OutroSequence")]
		public class bossOutro
		{
			public static void Prefix(out Part1BossOpponent __state, ref Part1BossOpponent __instance)
			{
				__state = __instance;
			}
			public static IEnumerator Postfix(IEnumerator enumerator, Part1BossOpponent __state, bool wasDefeated)
			{
				if (!wasDefeated)
				{
					RunState.Run.currentNodeId = 100;
					RunState.Run.currentNodeId += RunState.Run.regionTier;
					RunState.Run.playerLives = 1;
					yield return Singleton<TextDisplayer>.Instance.ShowMessage(__state.DefeatedPlayerDialogue);
					if (RunState.Run.regionTier == 1)
					{
						Tween.LocalPosition(GameObject.Find("bgStarParent").transform, new Vector3(0, 0, 0), 5f, 0);
					}
					Tween.Position(GameObject.Find("bossPainting").transform, new Vector3(-3.7f, 16.43f, 8.5f), 1f, 0);
					yield return new WaitForSeconds(1f);
					GameObject.Destroy(GameObject.Find("bossPainting"));
				}
				yield break;
			}
		}

		[HarmonyPatch(typeof(Part1BossOpponent), "DefeatedPlayerSequence")]
		public class bossPlayerDie
		{
			public static bool Prefix()
			{
				return false;
			}
		}

		[HarmonyPatch(typeof(Part1BossOpponent), "LifeLostSequence")]
		public class bossPhaseTransition
		{
			public static void Prefix(out Part1BossOpponent __state, ref Part1BossOpponent __instance)
			{
				__state = __instance;
			}
			public static IEnumerator Postfix(IEnumerator enumerator, Part1BossOpponent __state)
			{
				if (SceneLoader.ActiveSceneName == "finale_magnificus")
				{
					Singleton<InteractionCursor>.Instance.InteractionDisabled = true;
					yield return new WaitForSeconds(0.25f);
					Singleton<ViewManager>.Instance.SwitchToView(View.BossSkull, false, true);
					yield return new WaitForSeconds(1f);
					GameObject bossLife = GameObject.Find("bossPainting");
					bossLife.GetComponent<SineWaveMovement>().enabled = false;
					yield return new WaitForSeconds(0.5f);
					Tween.Rotation(bossLife.transform, Quaternion.Euler(0, 145, 0), 0.8f, 0);
					Tween.Rotation(bossLife.transform, Quaternion.Euler(0, 325, 0), 1.2f, 0.88f);
					yield return new WaitForSeconds(0.8f);
					AudioController.Instance.PlaySound2D("magnificus_brush_splatter_bleach", MixerGroup.None, 0.5f, 0f, null, null, null, null, false);
					string boss = "";
					switch (RunState.Run.regionTier)
					{
						case 1:
							boss = "goobert";
							break;
						case 2:
							boss = "espeara";
							break;
						case 3:
							boss = "lonely";
							break;
						case 4:
							boss = "magnificus";
							break;
					}
					if (__state.NumLives > 0)
					{
						bossLife.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = Tools.getImage(boss + __state.NumLives + "life.png");
					}
					else
					{
						bossLife.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = Tools.getImage("bossdefeated.png");
					}

					yield return new WaitForSeconds(1.2f);
					float xOffset = 0;
					float zOffset = 0;
					float yOffset = 0;
					if (RunState.Run.regionTier == 4)
					{
						xOffset = -18.3f;
						zOffset = 32f;
						yOffset = -2;

					}
					if (__state.NumLives == 0)
					{
						yield return new WaitForSeconds(0.25f);
						Singleton<ViewManager>.Instance.SwitchToView(View.BossSkull, false, true);
						yield return new WaitForSeconds(0.5f);
						Tween.LocalPosition(bossLife.transform, new Vector3(-3.7f + xOffset, 16.43f, 8.5f + zOffset), 1f, 0);
						yield return new WaitForSeconds(1.2f);
						yield return __state.BossDefeatedSequence();
					}
					else
					{
						//Tween.LocalPosition(bossLife.transform, new Vector3(-3.7f, 6.43f, 8.5f), 1f, 0);
						yield return new WaitForSeconds(0.1f);
						bossLife.GetComponent<SineWaveMovement>().enabled = true;
						bossLife.GetComponent<SineWaveMovement>().originalPosition = new Vector3(-3.7f + xOffset, 6.43f + yOffset, 8.5f + zOffset);
					}
					Singleton<ViewManager>.Instance.Controller.LockState = ViewLockState.Unlocked;
					Singleton<InteractionCursor>.Instance.InteractionDisabled = false;
				}
				else
				{
					Singleton<InteractionCursor>.Instance.InteractionDisabled = true;
					yield return new WaitForSeconds(0.25f);
					Singleton<ViewManager>.Instance.SwitchToView(View.BossSkull, false, true);
					yield return new WaitForSeconds(1f);
					__state.bossSkull.BlowOutCandle(__state.NumLives, null);
					if (!ProgressionData.LearnedMechanic(MechanicsConcept.BossMultipleLives))
					{
						yield return new WaitForSeconds(0.5f);
						yield return Singleton<TextDisplayer>.Instance.PlayDialogueEvent("TutorialBossBattleBossLives", TextDisplayer.MessageAdvanceMode.Input, TextDisplayer.EventIntersectMode.Wait, null, null);
						ProgressionData.SetMechanicLearned(MechanicsConcept.BossMultipleLives);
					}
					yield return new WaitForSeconds(0.25f);
					if (__state.NumLives == 0)
					{
						yield return new WaitForSeconds(0.25f);
						Singleton<ViewManager>.Instance.SwitchToView(View.BossSkull, false, true);
						yield return new WaitForSeconds(0.5f);
						__state.bossSkull.PlayExitAnimation();
						yield return new WaitForSeconds(1.2f);
						yield return __state.BossDefeatedSequence();
					}
					Singleton<ViewManager>.Instance.Controller.LockState = ViewLockState.Unlocked;
					Singleton<InteractionCursor>.Instance.InteractionDisabled = false;
				}
				yield break;
			}
		}

		public static IEnumerator dissapearSlots()
        {
			for (int i = 0; i < GameObject.Find("OpponentSlots").transform.childCount; i++)
            {
				GameObject.Find("OpponentSlots").transform.GetChild(i).gameObject.SetActive(false);
				yield return new WaitForSeconds(0.25f);
			}
			for (int i = 0; i < GameObject.Find("PlayerSlots").transform.childCount; i++)
			{
				GameObject.Find("PlayerSlots").transform.GetChild(i).gameObject.SetActive(false);
				yield return new WaitForSeconds(0.25f);

			}
			yield break;
        }

		[HarmonyPatch(typeof(Part1BossOpponent), "BossDefeatedSequence")]
		public class bossDie
		{
			public static void Prefix(out Part1BossOpponent __state, ref Part1BossOpponent __instance)
			{
				__state = __instance;
			}

			public static IEnumerator Postfix(IEnumerator enumerator, Part1BossOpponent __state)
			{
				if (SceneLoader.ActiveSceneName != "finale_magnificus")
                {
					LeshyAnimationController.Instance.SetMaskShown(false);
					__state.DestroyScenery();
					__state.SetSceneEffectsShown(false);
					AudioController.Instance.StopAllLoops();
					yield return new WaitForSeconds(0.75f);
					__state.CleanUpBossBehaviours();
					CustomCoroutine.WaitThenExecute(1f, new Action(LeshyAnimationController.Instance.HideArms), false);
					if (ScriptDefines.STEAM_DEMO)
					{
						yield return __state.SteamDemoEnd();
					}
					if (ScriptDefines.BITSUMMIT_DEMO)
					{
						yield return __state.BitSummitDemoEnd();
					}
					Singleton<ViewManager>.Instance.SwitchToView(View.Default, false, true);
					yield return new WaitForSeconds(0.8f);
					if (RunState.Run.maxPlayerLives > 1)
					{
						yield return Singleton<TextDisplayer>.Instance.PlayDialogueEvent("ReplenishLives", TextDisplayer.MessageAdvanceMode.Input, TextDisplayer.EventIntersectMode.Wait, null, null);
						yield return new WaitForSeconds(0.25f);
						if (Random.value > 0.8f)
						{
							Singleton<VideoCameraRig>.Instance.PlayCameraAnim("refocus_quick");
						}
						yield return Singleton<CandleHolder>.Instance.ReplenishFlamesSequence(0.25f);
						RunState.Run.playerLives = RunState.Run.maxPlayerLives;
					}
					Singleton<TurnManager>.Instance.PostBattleSpecialNode = new ChooseRareCardNodeData();
					yield break;
				}
				if (SaveManager.saveFile.ascensionActive && MagnificusMod.Generation.challenges.Contains("FadingMox"))
				{
					KayceeStorage.FleetingLife = Singleton<MagnificusLifeManager>.Instance.playerLife;
				}
				AudioController.Instance.FadeOutLoop(0.5f);
				yield return new WaitForSeconds(0.75f);
				Singleton<ViewManager>.Instance.SwitchToView(View.Default, false, true);
				if (RunState.Run.regionTier == 1 && Generation.challenges.Contains("MasterBosses"))
                {
					Singleton<BossOpponents.GoranjSequencer>.Instance.CleanupTargetIcons();
					yield return new WaitForSeconds(0.25f);
                }
				GameObject portraitSlots = GameObject.Find("OpponentSlots");
				GameObject.Find("CombatBell_Magnificus").transform.Find("Anim").localPosition = new Vector3(0, 0, 0);
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
				__state.CleanUpBossBehaviours();
				__state.SetSceneEffectsShown(false);
				GameObject npc = GameObject.Find("GameEnvironment");
				Tween.LocalPosition(GameObject.Find("CombatBell_Magnificus").transform, new Vector3(-7.64f, 27.1583f, 6.42f), 5f, 0);
				Tween.LocalPosition(GameObject.Find("LifeManager").transform, new Vector3(0f, 20, 0), 5f, 0);

				Tween.LocalRotation(GameObject.Find("WizardBattleDuelDisk").transform, new Vector3(0, 75, 0), 1.25f, 0);
				Tween.LocalPosition(GameObject.Find("WizardBattleDuelDisk").transform, new Vector3(0.9f, 4.5f, -12.5f), 1.5f, 0.15f);

				Tween.LocalPosition(Singleton<PlayerHand3D>.Instance.transform, new Vector3(1, -0.5445f, -5.4f), 1.5f, 0.15f);

				if (Singleton<SpellPile>.Instance != null) { Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(Singleton<SpellPile>.Instance.disappear()); }
				Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(BossFixes.dissapearSlots());
				switch (RunState.Run.regionTier)
				{
					case 1:
						if (SaveManager.saveFile.ascensionActive && SavedVars.NodesCleared <= 3)
                        {
							AchievementManager.Unlock(MagnificusMod.Achievements.RushRecklessly);
						}
						int rand = Random.RandomRangeInt(0, 100);
						if (!Generation.challenges.Contains("MasterBosses") || !SaveManager.saveFile.ascensionActive)
						{
							if (Singleton<BossOpponents.GoobertOpponnent>.Instance.NumLives == 0 && SaveManager.saveFile.ascensionActive && !Singleton<BossOpponents.GoobertOpponnent>.Instance.gooedCards)
							{
								AchievementManager.Unlock(MagnificusMod.Achievements.HumanoidSlime);
							}
							if (!SavedVars.LearnedMechanics.Contains("beatgoobert;"))
								SavedVars.LearnedMechanics += "beatgoobert;";
							npc = GameObject.Find("Goober");
							Tween.Rotation(npc.transform, Quaternion.Euler(0, 0, 0), 5f, 0);
							Vector3 npcPos = npc.transform.localPosition;
							npcPos.y = -8f;
							Tween.LocalPosition(npc.transform, npcPos, 5f, 0);
							Tween.LocalPosition(GameObject.Find("bgStarParent").transform, new Vector3(0, 0, 0), 5f, 0);
							yield return new WaitForSeconds(4.5f);
							if (rand <= 33)
							{
								yield return Singleton<TextDisplayer>.Instance.ShowMessage("My [c:g1]Goo Mage[c:] falls by your hands.. I expected more from him..");
							}
							else if (rand <= 66)
							{
								yield return Singleton<TextDisplayer>.Instance.ShowMessage("Hmph.. My [c:g1]Goo Mage[c:] dissapoints me again..");
							}
							else if (rand <= 101)
							{
								yield return Singleton<TextDisplayer>.Instance.ShowMessage("Yet again, my pathetic [c:g1]Goo Mage[c:] falls..");
							}
						} else
                        {
							npc = GameObject.Find("goranjPainting");
							Vector3 npcPos = npc.transform.localPosition;
							npc.GetComponent<SineWaveMovement>().enabled = false;
							Tween.LocalPosition(GameObject.Find("bgStarParent").transform, new Vector3(0, 0, 0), 5f, 0);
							CustomTextDisplayerStuff.switchToSpeakerStyle(3);
							if (rand <= 33)
							{
								yield return Singleton<TextDisplayer>.Instance.ShowMessage("[c:g1]What..?[c:] [c:g2]Me,[c:] [c:g1]defeated..?[c:]", Emotion.Anger, TextDisplayer.LetterAnimation.WavyJitter);
							}
							else if (rand <= 66)
							{
								yield return Singleton<TextDisplayer>.Instance.ShowMessage("[c:g1]Blargh..[c:] [c:g2]I've[c:] [c:g1]been[c:] [c:g2]taken[c:] [c:g1]out[c:] [c:g2]by[c:] [c:g1]you??[c:] ", Emotion.Anger, TextDisplayer.LetterAnimation.WavyJitter);
							}
							else if (rand <= 101)
							{
								yield return Singleton<TextDisplayer>.Instance.ShowMessage("[c:g1]Impossible..[c:] [c:g2]I've[c:] [c:g1]been[c:] [c:g2]defeated..[c:]", Emotion.Anger, TextDisplayer.LetterAnimation.WavyJitter);
							}
							Tween.LocalPosition(npc.transform, new Vector3(0, 7f, 13.5f), 3.75f, 0);
							Tween.LocalPosition(npc.transform, new Vector3(0, -6.5f, 13.5f), 0.25f, 4.25f);
							yield return new WaitForSeconds(4.75f);
						}
						break;
					case 2:
						if (!Generation.challenges.Contains("MasterBosses") || !SaveManager.saveFile.ascensionActive)
						{
							if (Singleton<BossOpponents.EspeararaOpponnent>.Instance.NumLives == 0 && SaveManager.saveFile.ascensionActive && !Singleton<BossOpponents.EspeararaOpponnent>.Instance.triggeredEnchantedSpear)
							{
								AchievementManager.Unlock(MagnificusMod.Achievements.HeadlessKnight);
							}
							if (!SavedVars.LearnedMechanics.Contains("beatamber;"))
							{
								SavedVars.LearnedMechanics += "beatamber;";
							}
							npc = GameObject.Find("Espeara");
							Tween.LocalPosition(npc.transform, new Vector3(0, -35f, 36f), 4f, 0.375f);
							Tween.Rotation(npc.transform, Quaternion.Euler(0, 0, 0), 4f, 0.375f);
							yield return new WaitForSeconds(4.5f);
							GameObject.Destroy(GameObject.Find("ceiling"));
							rand = Random.RandomRangeInt(0, 100);
							if (rand <= 33)
							{
								yield return Singleton<TextDisplayer>.Instance.ShowMessage("Ahh.. I see you've defeated my [c:g2]Pike Mage[c:]..");
							}
							else if (rand <= 66)
							{
								yield return Singleton<TextDisplayer>.Instance.ShowMessage("My [c:g2]Pike Mage[c:] falls.. Dissapointing.");
							}
							else if (rand <= 101)
							{
								yield return Singleton<TextDisplayer>.Instance.ShowMessage("I'll admit challenger.. You've gotten farther than most.");
							}
						} else
                        {
							rand = Random.RandomRangeInt(0, 100);
							npc = GameObject.Find("orluPainting");
							Vector3 npcPos = npc.transform.localPosition;
							npc.GetComponent<SineWaveMovement>().enabled = false;
							CustomTextDisplayerStuff.switchToSpeakerStyle(4);
							if (rand <= 33)
							{
								yield return Singleton<TextDisplayer>.Instance.ShowMessage("[c:g2]A[c:] [c:g3]fantastic[c:] [c:g2]duel[c:] [c:g3]we[c:] [c:g2]had![c:]", Emotion.Curious, TextDisplayer.LetterAnimation.WavyJitter, DialogueEvent.Speaker.Single);
							}
							else if (rand <= 66)
							{
								yield return Singleton<TextDisplayer>.Instance.ShowMessage("[c:g2]'Twas[c:] [c:g3]an[c:] [c:g2]excellent[c:] [c:g3]battle.[c:]", Emotion.Curious, TextDisplayer.LetterAnimation.WavyJitter, DialogueEvent.Speaker.Single);
							}
							else if (rand <= 101)
							{
								yield return Singleton<TextDisplayer>.Instance.ShowMessage("[c:g2]Great[c:] [c:g3]fighting,[c:] [c:g2]young[c:] [c:g3]mage.[c:]", Emotion.Curious, TextDisplayer.LetterAnimation.WavyJitter, DialogueEvent.Speaker.Single);
							}
							Tween.LocalPosition(npc.transform, new Vector3(0, 4.5f, 13.5f), 3.75f, 0);
							Tween.LocalPosition(npc.transform, new Vector3(0, 15.5f, 13.5f), 0.25f, 4.25f);
							yield return new WaitForSeconds(4.75f);
						}
						break;
					case 3:
						if (!Generation.challenges.Contains("MasterBosses") || !SaveManager.saveFile.ascensionActive)
						{
							if (Singleton<BossOpponents.LonelyMageOpponnent>.Instance.NumLives == 0 && SaveManager.saveFile.ascensionActive && Singleton<BossOpponents.LonelyMageOpponnent>.Instance.TurnTimerTriggered <= 0)
							{
								AchievementManager.Unlock(MagnificusMod.Achievements.QuickSummon);
							} else if (Singleton<BossOpponents.LonelyMageOpponnent>.Instance.NumLives == 0 && SaveManager.saveFile.ascensionActive && Singleton<BossOpponents.LonelyMageOpponnent>.Instance.TurnTimerTriggered >= 5)
							{
								AchievementManager.Unlock(MagnificusMod.Achievements.MischiefOfTheTimeGoddess);
							}
							if (!SavedVars.LearnedMechanics.Contains("beatlonely;"))
							{
								SavedVars.LearnedMechanics += "beatlonely;";
							}
							if (!SavedVars.LearnedMechanics.Contains("hushlonely;"))
							{
								CustomTextDisplayerStuff.switchToSpeakerStyle(2);
								yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("WHAT? BUT DON'T I GET TO LEAVE?", -0.5f, 0f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
								yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("I STILL HAVE SO MUCH STIMULATION TO GET!!", -0.5f, 0f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
								yield return Singleton<TextDisplayer>.Instance.ShowThenClear("[c:g2]PLEASE, CHALLENGER,[c:] YOU HAVE TO GET ME-", 1f, 0f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
								CustomTextDisplayerStuff.switchToSpeakerStyle(0);
								yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Hush.", -0.5f, 0f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
								SavedVars.LearnedMechanics += "hushlonely;";
							}
							/*
							if (!SavedVars.LearnedMechanics.Contains("died"))//THIS IS PART OF THE ITS OVER THING
							{
								SavedVars.LearnedMechanics += "died;";
							}
							if (!KayceeStorage.IsKaycee)
							{
								Singleton<TextDisplayer>.Instance.ShowMessage("its over!!");
							}
							else
							{
								yield return new WaitForSeconds(1f);
								if (MagnificusMod.Generation.minimap)
								{
									MagnificusMod.Generation.minimap = false;
									MagnificusMod.SaveVariables.HasMap = false;
									GameObject.Destroy(GameObject.Find("MapParent"));
								}
								Singleton<UIManager>.Instance.Effects.GetEffect<ScreenColorEffect>().SetColor(GameColors.Instance.nearBlack);
								Singleton<UIManager>.Instance.Effects.GetEffect<ScreenColorEffect>().SetIntensity(1f, float.MaxValue);
								AudioController.Instance.StopAllLoops();
								Singleton<InteractionCursor>.Instance.SetHidden(true);
								yield return new WaitForSeconds(3f);
								SceneLoader.Load("Ascension_Configure");
								yield break;
							}
							yield break;*/
							npc = GameObject.Find("LonelyMage");
							Tween.LocalScale(npc.transform.GetChild(2).GetChild(0).GetChild(0).GetChild(1).Find("LeftEye"), new Vector3(1, 1, 0), 3, 1f);
							Tween.LocalScale(npc.transform.GetChild(2).GetChild(0).GetChild(0).GetChild(2).Find("RightEye"), new Vector3(-1, 0, -1), 3, 1f);
							Tween.LocalPosition(npc.transform, new Vector3(0, -7, 15), 1, 4);

							for (int i = 0; i < 100; i++)
							{
								npc.GetComponent<Animator>().speed = 1 - (i / 100f);
								yield return new WaitForSeconds(0.01f);
							}
							yield return new WaitForSeconds(3f);
							rand = Random.RandomRangeInt(0, 100);
							if (rand <= 33)
							{
								yield return Singleton<TextDisplayer>.Instance.ShowMessage("Well challenger.. Now that you have defeated the [c:g3]Lonely Mage[c:]. You may now face me.");
							}
							else if (rand <= 66)
							{
								yield return Singleton<TextDisplayer>.Instance.ShowMessage("You've defeated all my students.. I will await your arrival.");
							}
							else if (rand <= 101)
							{
								yield return Singleton<TextDisplayer>.Instance.ShowMessage("My [c:g3]Lonely Mage[c:] falls.. this is unexpected.. But now, I await your arrival.");
							}
						} else
						{
							npc = GameObject.Find("bleenePainting");
							Vector3 npcPos = npc.transform.localPosition;
							npc.GetComponent<SineWaveMovement>().enabled = false;
							rand = Random.RandomRangeInt(0, 100);
							CustomTextDisplayerStuff.switchToSpeakerStyle(5);
							if (rand <= 33)
							{
								yield return Singleton<TextDisplayer>.Instance.ShowMessage("[c:g3]An[c:] [c:g1]excellent[c:] [c:g3]fight![c:]", Emotion.Anger, TextDisplayer.LetterAnimation.WavyJitter);
							}
							else if (rand <= 66)
							{
								yield return Singleton<TextDisplayer>.Instance.ShowMessage("[c:g3]Despite[c:] [c:g1]my[c:] [c:g3]deadliest[c:] [c:g1]books,[c:] [c:g3]you[c:] [c:g1]still[c:] [c:g3]won![c:]", Emotion.Anger, TextDisplayer.LetterAnimation.WavyJitter);
							}
							else if (rand <= 101)
							{
								yield return Singleton<TextDisplayer>.Instance.ShowMessage("[c:g3]You[c:] [c:g1]managed[c:] [c:g3]to[c:] [c:g1]overcome[c:] [c:g3]my[c:] [c:g1]deadliest[c:] [c:g3]tomes,[c:] [c:g1]impressive![c:]", Emotion.Anger, TextDisplayer.LetterAnimation.WavyJitter);
							}
							Tween.LocalPosition(npc.transform, new Vector3(0, 7f, 13.5f), 3.75f, 0);
							Tween.LocalPosition(npc.transform, new Vector3(0, -6.5f, 13.5f), 0.25f, 4.25f);
							yield return new WaitForSeconds(4.75f);
						}
						break;
				}
				foreach (GemType gem in Singleton<MagnificusResourcesManager>.Instance.gems)
				{
					Singleton<MagnificusResourcesManager>.Instance.SetGemLit(gem, false);
				}
				Singleton<MagnificusResourcesManager>.Instance.gems = new List<GemType>();
				GameObject.Find("WizardBattleDuelDisk").SetActive(false);
				Singleton<MagnificusLifeManager>.Instance.PlayerCounter.gameObject.SetActive(false);
				Singleton<MagnificusLifeManager>.Instance.OpponentCounter.gameObject.SetActive(false);
				GameObject.Find("Hand").SetActive(false);

				GameObject.Find("GameTable").transform.Find("CardBattle_Magnificus").Find("CombatBell_Magnificus").gameObject.SetActive(false);
				GameObject.Find("GameTable").transform.Find("CardBattle_Magnificus").Find("CombatBell_Magnificus").transform.Find("Anim").localPosition = new Vector3(0, 0, 0);


				if (GameObject.Find("GameTable").transform.Find("CardBattle_Magnificus").gameObject.activeSelf)
				{
					for (int i = 0; i < 4; i++)
					{
						if (GameObject.Find("OpponentSlots").transform.GetChild(i).childCount > 5)
						{
							for (int b = GameObject.Find("OpponentSlots").transform.GetChild(i).childCount - 1; b > 4; b--)
							{
								GameObject.Destroy(GameObject.Find("OpponentSlots").transform.GetChild(i).GetChild(b).gameObject);
							}
						}
						if (GameObject.Find("PlayerSlots").transform.GetChild(i).childCount > 5)
						{
							for (int b = GameObject.Find("PlayerSlots").transform.GetChild(i).childCount - 1; b > 4; b--)
							{
								GameObject.Destroy(GameObject.Find("PlayerSlots").transform.GetChild(i).GetChild(b).gameObject);
							}
						}
					}
				}


				Singleton<ViewManager>.Instance.SwitchToView(View.Default, false, true);
				//yield return new WaitForSeconds(1.5f);
				if (npc.name != "GameEnvironment")
				{
					npc.SetActive(false);
				}
				Singleton<TurnManager>.Instance.PostBattleSpecialNode = new ChooseRareCardNodeData();
				yield break;
			}
		}


		[HarmonyPatch(typeof(Opponent), "ClearQueue")]
		public class clearQueueFix
		{
			public static void Prefix(out Opponent __state, ref Opponent __instance)
			{
				__state = __instance;
			}
			public static IEnumerator Postfix(IEnumerator enumerator, Part1BossOpponent __state)
			{
				foreach (PlayableCard playableCard in __state.Queue)
				{
					playableCard.ExitBoard(0.4f, Vector3.zero);
					yield return new WaitForSeconds(0.1f);
				}
				if (SceneLoader.ActiveSceneName == "finale_magnificus")
				{
					for (int i = 0; i < GameObject.Find("OpponentSlots").transform.childCount; i++)
					{
						GameObject.Find("OpponentSlots").transform.GetChild(i).transform.Find("QueuedCardFrame").gameObject.SetActive(false);
					}
				}
				__state.Queue.Clear();
				yield break;
			}
		}

		[HarmonyPatch(typeof(RareCardChoicesSequencer), "ChooseRareCard")]
		public class rareCardChange
		{
			public static void Prefix(out RareCardChoicesSequencer __state, ref RareCardChoicesSequencer __instance)
			{
				__state = __instance;
			}
			public static IEnumerator Postfix(IEnumerator enumerator, RareCardChoicesSequencer __state)
			{
				if (SceneLoader.ActiveSceneName!= "finale_magnificus")
                {
					Singleton<ViewManager>.Instance.Controller.LockState = ViewLockState.Locked;
					Singleton<ViewManager>.Instance.SwitchToView(View.Default, false, false);
					yield return new WaitForSeconds(1f);
					Singleton<TableRuleBook>.Instance.SetOnBoard(true);
					__state.deckPile.gameObject.SetActive(true);
					__state.StartCoroutine(__state.deckPile.SpawnCards(RunState.DeckList.Count, 1f));
					Vector3 vector = new Vector3(__state.box.position.x, __state.box.position.y, 0.5f);
					Vector3 startPos = new Vector3(vector.x, vector.y, 9f);
					__state.box.position = startPos;
					__state.box.gameObject.SetActive(true);
					AudioController.Instance.PlaySound3D("woodbox_slide", MixerGroup.TableObjectsSFX, vector, 1f, 0f, null, null, null, null, false);
					Tween.Position(__state.box, vector, 0.3f, 0f, Tween.EaseOut, Tween.LoopType.None, null, null, true);
					yield return new WaitForSeconds(0.3f);
					yield return new WaitForSeconds(0.5f);
					if (!SaveFile.IsAscension || !DialogueEventsData.EventIsPlayed("ChallengeNoBossRares"))
					{
						yield return Singleton<TextDisplayer>.Instance.PlayDialogueEvent("RareCardsIntro", TextDisplayer.MessageAdvanceMode.Input, TextDisplayer.EventIntersectMode.Wait, null, null);
					}
					__state.selectableCards = __state.SpawnCards(3, __state.box.transform, new Vector3(-1.55f, 0.2f, 0f), 1.5f);
					List<CardChoice> list;
					if (AscensionSaveData.Data.ChallengeIsActive(AscensionChallenge.NoBossRares))
					{
						list = __state.choiceGenerator.GenerateChoices(new CardChoicesNodeData(), SaveManager.SaveFile.GetCurrentRandomSeed());
					}
					else
					{
						list = __state.rareChoiceGenerator.GenerateChoices(SaveManager.SaveFile.GetCurrentRandomSeed());
					}
					for (int i = 0; i < __state.selectableCards.Count; i++)
					{
						__state.selectableCards[i].gameObject.SetActive(true);
						__state.selectableCards[i].ChoiceInfo = list[i];
						__state.selectableCards[i].Initialize(list[i].CardInfo, new Action<SelectableCard>(__state.OnRewardChosen), new Action<SelectableCard>(__state.OnCardFlipped), true, new Action<SelectableCard>(__state.OnCardInspected));
						__state.selectableCards[i].SetEnabled(false);
						__state.selectableCards[i].SetFaceDown(true, true);
						SpecialCardBehaviour[] components = __state.selectableCards[i].GetComponents<SpecialCardBehaviour>();
						for (int j = 0; j < components.Length; j++)
						{
							components[j].OnShownForCardChoiceNode();
						}
					}
					__state.box.GetComponentInChildren<Animator>().Play("open", 0, 0f);
					AudioController.Instance.PlaySound3D("woodbox_open", MixerGroup.TableObjectsSFX, __state.box.transform.position, 1f, 0f, null, null, null, null, false);
					yield return new WaitForSeconds(2f);
					Singleton<ViewManager>.Instance.SwitchToView(__state.choicesView, false, false);
					ChallengeActivationUI.TryShowActivation(AscensionChallenge.NoBossRares);
					if (AscensionSaveData.Data.ChallengeIsActive(AscensionChallenge.NoBossRares) && !DialogueEventsData.EventIsPlayed("ChallengeNoBossRares"))
					{
						yield return new WaitForSeconds(0.5f);
						yield return Singleton<TextDisplayer>.Instance.PlayDialogueEvent("ChallengeNoBossRares", TextDisplayer.MessageAdvanceMode.Input, TextDisplayer.EventIntersectMode.Wait, null, null);
					}
					Singleton<InteractionCursor>.Instance.InteractionDisabled = false;
					__state.SetCollidersEnabled(true);
					__state.gamepadGrid.enabled = true;
					__state.EnableViewDeck(__state.viewControlMode, __state.basePosition);
					__state.chosenReward = null;
					yield return new WaitUntil(() => __state.chosenReward != null);
					__state.DisableViewDeck();
					__state.chosenReward.transform.parent = null;
					Singleton<RuleBookController>.Instance.SetShown(false, true);
					__state.gamepadGrid.enabled = false;
					__state.deckPile.MoveCardToPile(__state.chosenReward, true, 0.25f, 1.15f);
					__state.AddChosenCardToDeck();
					__state.CleanupMushrooms();
					yield return new WaitForSeconds(0.5f);
					Singleton<ViewManager>.Instance.SwitchToView(View.Default, false, false);
					yield return new WaitForSeconds(0.5f);
					__state.box.GetComponentInChildren<Animator>().Play("close", 0, 0f);
					AudioController.Instance.PlaySound3D("woodbox_close", MixerGroup.TableObjectsSFX, __state.box.transform.position, 1f, 0f, null, null, null, null, false);
					yield return new WaitForSeconds(0.6f);
					__state.CleanUpCards(false);
					Tween.Position(__state.box, startPos, 0.3f, 0f, Tween.EaseInOut, Tween.LoopType.None, null, null, true);
					yield return new WaitForSeconds(0.3f);
					__state.box.gameObject.SetActive(false);
					yield return __state.StartCoroutine(__state.deckPile.DestroyCards(0.5f));
					__state.deckPile.gameObject.SetActive(false);
					ProgressionData.SetMechanicLearned(MechanicsConcept.RareCards);
					if (RunState.Run.eyeState == EyeballState.Missing)
					{
						Singleton<GameFlowManager>.Instance.TransitionToGameState(GameState.SpecialCardSequence, new ChooseEyeballNodeData());
					}
					else
					{
						Singleton<GameFlowManager>.Instance.TransitionToGameState(GameState.Map, null);
					}
					yield break;
				}
				SavedVars.GeneratedEvents = "";
				yield return MagnificusMod.Generation.WaitThenDisable(GameObject.Find("CardBattle_Magnificus"), 0.5f);
				GameObject.Destroy(GameObject.Find("bossPainting"));
				Tween.LocalPosition(GameObject.Find("tbPillar").transform, new Vector3(0.88f, -5f, -1), 0.75f, 0);
				__state.box.gameObject.SetActive(false);
				Singleton<ViewManager>.Instance.SwitchToView(View.Default, false, false);
				Singleton<ViewManager>.Instance.Controller.LockState = ViewLockState.Locked;
				Singleton<ViewManager>.Instance.SwitchToView(View.Default, false, false);
				yield return new WaitForSeconds(0.3f);
				yield return new WaitForSeconds(0.5f);
				AudioController.Instance.StopAllLoops();
				AudioController.Instance.SetLoopAndPlay("School_of_Magicks", 0, true, true);
				AudioController.Instance.SetLoopVolumeImmediate(0.55f);
				yield return new WaitForSeconds(1f);
				CustomTextDisplayerStuff.switchToSpeakerStyle(0);
				if (RunState.Run.playerLives > -1)
				{
					if (!SavedVars.LearnedMechanics.Contains("beatbosswithdamage;") && RunState.Run.playerLives != RunState.Run.maxPlayerLives)
					{
						SavedVars.LearnedMechanics += "beatbosswithdamage;";
						yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Hmm?", 0f, 0f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
						yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Did you expect me to restore your [c:g1]life painting[c:]?", 0.5f, 0f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
						yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Hmm.. That's not how it works here, challenger..", 0f, 0f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
						yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Bleach is not easily restorable.", 0f, 0f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
						yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("You may only pick a [c:g3]rare card[c:].", 0.5f, 0f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
					}
					else
					{
						yield return Singleton<TextDisplayer>.Instance.ShowThenClear("Choose wisely.", 2f, 0f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
					}
					yield return new WaitForSeconds(0.5f);
					__state.selectableCards = __state.SpawnCards(3, GameObject.Find("GameTable").transform, new Vector3(-1.55f, 5.01f, 0.5f), 1.5f);
					int randomSeed = SaveManager.saveFile.GetCurrentRandomSeed();
					List<CardChoice> list = new List<CardChoice>();
					for (int i = 0; i < 3; i++)
					{
						List<CardInfo> unlockedCards = CardLoader.GetUnlockedCards(CardMetaCategory.Rare, CardTemple.Wizard);
						unlockedCards.RemoveAll((CardInfo x) => x.name == "MoxTriple" && x.HasTrait(Trait.Gem));

						CardInfo card = CardLoader.Clone(unlockedCards[SeededRandom.Range(0, unlockedCards.Count, SaveManager.saveFile.randomSeed)]);
						if (unlockedCards.Count >= 3)
						{
							SaveManager.saveFile.randomSeed++;
							while (list.Exists((CardChoice x) => x.CardInfo.name == card.name))
							{
								card = CardLoader.Clone(unlockedCards[SeededRandom.Range(0, unlockedCards.Count, SaveManager.saveFile.randomSeed)]);
								SaveManager.saveFile.randomSeed++;
							}
						}
						list.Add(new CardChoice
						{
							CardInfo = card
						});
					}
					int num;
					for (int i = 0; i < __state.selectableCards.Count; i = num + 1)
					{
						__state.selectableCards[i].gameObject.SetActive(true);
						__state.selectableCards[i].ChoiceInfo = list[i];
						__state.selectableCards[i].Initialize(list[i].CardInfo, new Action<SelectableCard>(__state.OnRewardChosen), new Action<SelectableCard>(__state.OnCardFlipped), true, new Action<SelectableCard>(__state.OnCardInspected));
						__state.selectableCards[i].SetEnabled(false);
						__state.selectableCards[i].SetFaceDown(true, true);
						num = i;
					}
					Singleton<ViewManager>.Instance.SwitchToView(View.OpponentQueueCentered, false, false);
					Singleton<InteractionCursor>.Instance.InteractionDisabled = false;
					__state.SetCollidersEnabled(true);
					__state.gamepadGrid.enabled = true;
					__state.chosenReward = null;
				}
				else
				{
					if (!SavedVars.LearnedMechanics.Contains("beatbosswithdamage;") && !SaveManager.saveFile.ascensionActive)
					{
						SavedVars.LearnedMechanics += "beatbosswithdamage;";
						yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Hmm?", 0.5f, 0f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
						yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Did you expect me to restore your [c:g1]life painting[c:]?", 1.5f, 0f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
						yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Hmm.. That's not how it works here, challenger..", 0.5f, 0f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
						yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Bleach is not easily restorable.", 1f, 0f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
						yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("You may only pick a [c:g3]rare card[c:].", 2f, 0f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
					}
					else
					{
						yield return Singleton<TextDisplayer>.Instance.ShowThenClear("Choose wisely.", 2f, 0f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
					}
					yield return new WaitForSeconds(0.5f);
					Singleton<ViewManager>.Instance.SwitchToView(View.OpponentQueueCentered, false, false);
					GameObject lifePainting = GameObject.Find("GameTable").transform.Find("LifePainting").gameObject;
					lifePainting.SetActive(true);
					lifePainting.transform.localPosition = new Vector3(1.45f, 7.54f, -0.4f);
					Tween.LocalRotation(lifePainting.transform, Quaternion.Euler(71, 0, 0), 0.5f, 0);
					yield return new WaitForSeconds(0.6f);
					CardInfo cardLol = CardLoader.GetCardByName("JuniorSage");
					for (int i = 0; i < 2; i++)
					{
						yield return new WaitForSeconds(Time.deltaTime);
						yield return new WaitForSeconds(Time.deltaTime);
						GameObject gameObject = GameObject.Instantiate<GameObject>(Singleton<SelectableCardArray>.Instance.selectableCardPrefab);
						gameObject.transform.SetParent(GameObject.Find("GameTable").transform);
						SelectableCard component = gameObject.GetComponent<SelectableCard>();
						component.Initialize(cardLol, new Action<SelectableCard>(Singleton<SelectableCardArray>.Instance.OnCardSelected), null, false, new Action<SelectableCard>(Singleton<SelectableCardArray>.Instance.OnCardInspected));
						component.SetEnabled(false);
						component.SetCardback(Tools.getImage("magcardback.png"));
						component.Anim.SetFaceDown(true, true);
						Singleton<SelectableCardArray>.Instance.displayedCards.Add(component);
						float x = -1.5f;
						Tween.LocalPosition(lifePainting.transform, new Vector3(1.45f, 5.54f, -0.4f), 0.25f, 0);
						if (i == 1)
						{
							x = 1.5f;
						}
						Singleton<SelectableCardArray>.Instance.TweenInCard(component.transform, new Vector3(x, 5.3f, 1), 0f, false);
						component.Anim.PlayQuickRiffleSound();
						component.Initialize(cardLol, new Action<SelectableCard>(MagnificusMod.Generation.chooseBetweenLifeandRare), null, false, null);
						component.SetCardback(Tools.getImage("magcardback.png"));
						component.Anim.SetFaceDown(true, true);
						component.GetComponent<Collider>().enabled = true;
						if (i == 1)
						{
							component.name = "lifePaintingJr";
						}
						else
						{
							component.name = "rareChoice";
						}
					}
				}
				yield return new WaitUntil(() => __state.chosenReward != null);
				__state.chosenReward.transform.parent = null;
				Singleton<RuleBookController>.Instance.SetShown(false, true);
				__state.gamepadGrid.enabled = false;
				if (__state.chosenReward.Info.name != "JuniorSage")
				{
					__state.deckPile.MoveCardToPile(__state.chosenReward, true, 0.25f, 1f);
					__state.AddChosenCardToDeck();
				}
				else
				{
					GameObject.Destroy(__state.chosenReward.gameObject);
					Tween.LocalPosition(GameObject.Find("LifePainting").transform, new Vector3(1f, 27.5f, 1), 0.5f, 0);
					yield return MagnificusMod.Generation.WaitThenDisable(GameObject.Find("LifePainting"), 0.6f);
				}
				__state.CleanupMushrooms();
				yield return new WaitForSeconds(0.5f);
				Singleton<ViewManager>.Instance.SwitchToView(View.Default, false, false);
				yield return new WaitForSeconds(0.5f);
				__state.CleanUpCards(false);
				yield return new WaitForSeconds(0.3f);
				yield return __state.StartCoroutine(__state.deckPile.DestroyCards(0.5f));
				__state.deckPile.gameObject.SetActive(false);
				ProgressionData.SetMechanicLearned(MechanicsConcept.RareCards);
				Tween.Position(GameObject.Find("GameTable").transform, new Vector3(GameObject.Find("GameTable").transform.position.x, -5.5f, GameObject.Find("GameTable").transform.position.z), 0.5f, 0);
				Singleton<ViewManager>.Instance.SwitchToView(View.FirstPerson, false, false);
				if (RunState.Run.regionTier == 1)
				{
					Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(MagnificusMod.Generation.WaitThenDestroy(GameObject.Find("bgStarParent"), 4f));
					Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(MagnificusMod.Generation.WaitThenDestroy(GameObject.Find("gooOrbSpawner1"), 4f));
					Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(MagnificusMod.Generation.WaitThenDestroy(GameObject.Find("gooOrbSpawner2"), 4f));
				}
				else if (RunState.Run.regionTier == 2)
				{
					Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(MagnificusMod.Generation.WaitThenDestroy(GameObject.Find("lavaOrbSpawner1"), 4f));
				}
				int regionTier = RunState.Run.regionTier;
				if (regionTier < 3)
				{
					AscensionSaveData.Data.currentOuroborosDeaths = 0;
					SaveManager.saveFile.ouroborosDeaths = 0;
					MagnificusMod.Plugin.spellsPlayed = 0;
				}
				regionTier++;
				MagSave.clearedNode = new List<string>();
				MagSave.SaveLayout(regionTier.ToString());
				RunState.Run.regionTier = 0;
				File.WriteAllText(SaveManager.SaveFolderPath + "MagnificusModSave.gwsave", SaveManager.ToJSON(MagSave.GetNodeStuff(false, false)));
				Tween.Position(GameObject.Find("Player").transform, new Vector3(GameObject.Find("Player").transform.position.x, 12.5f, GameObject.Find("Player").transform.position.z), 0.5f, 0);
				yield return new WaitForSeconds(0.55f);
				yield return MagnificusMod.Generation.transition("tower", "spin");
			}
		}

	}
}
