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
using BossBlueprints = MagnificusMod.BossBlueprints;

namespace MagnificusMod
{
    class BossOpponents
    {
		[HarmonyPatch(typeof(TurnManager), "StartGame", new Type[]
{
			typeof(CardBattleNodeData)
})]


		[HarmonyPatch(typeof(TurnManager), "StartGame", new Type[]
{
			typeof(CardBattleNodeData)
})]

		[HarmonyPatch(typeof(TurnManager), "StartGame", new Type[]
{
			typeof(CardBattleNodeData)
})]

		[HarmonyPatch(typeof(TurnManager), "StartGame", new Type[]
{
			typeof(CardBattleNodeData)
})]
		

		[HarmonyPatch(typeof(Opponent), "SpawnOpponent", new Type[]
		{
			typeof(EncounterData)
		})]
		public class SpawnOpponentPatch
		{
			public static bool Prefix(TurnManager __instance, ref Opponent __result, EncounterData encounterData)
			{
				bool flag = encounterData.opponentType == (Opponent.Type)101;
				bool flag2 = flag;
				bool result;
				if (flag2)
				{
					GameObject gameObject = new GameObject();
					gameObject.name = "Opponent";
					Opponent.Type opponentType = GoobertOpponnent.FullOpponent.Id;
					Part1BossOpponent part1BossOpponent = gameObject.AddComponent<GoobertOpponnent>();
					string text = encounterData.aiId;
					bool flag3 = string.IsNullOrEmpty(text);
					bool flag4 = flag3;
					if (flag4)
					{
						text = "AI";
					}
					part1BossOpponent.AI = (Activator.CreateInstance(CustomType.GetType("DiskCardGame", text)) as AI);
					part1BossOpponent.NumLives = part1BossOpponent.StartingLives;
					part1BossOpponent.OpponentType = opponentType;
					part1BossOpponent.TurnPlan = part1BossOpponent.ModifyTurnPlan(encounterData.opponentTurnPlan);
					part1BossOpponent.Blueprint = encounterData.Blueprint;
					part1BossOpponent.Difficulty = encounterData.Difficulty;
					part1BossOpponent.ExtraTurnsToSurrender = SeededRandom.Range(0, 3, SaveManager.SaveFile.GetCurrentRandomSeed());
					__result = part1BossOpponent;
					result = false;
				}
				else
				{
					result = true;
				}
				return result;
			}
		}

		[HarmonyPatch(typeof(Opponent), "SpawnOpponent", new Type[]
		{
			typeof(EncounterData)
		})]
		public class SpawnOpponentPatch2
		{
			public static bool Prefix(TurnManager __instance, ref Opponent __result, EncounterData encounterData)
			{
				bool flag = encounterData.opponentType == (Opponent.Type)102;
				bool flag2 = flag;
				bool result;
				if (flag2)
				{
					GameObject gameObject = new GameObject();
					gameObject.name = "Opponent";
					Opponent.Type opponentType = encounterData.opponentType;
					Part1BossOpponent part1BossOpponent = gameObject.AddComponent<EspeararaOpponnent>();
					string text = encounterData.aiId;
					bool flag3 = string.IsNullOrEmpty(text);
					bool flag4 = flag3;
					if (flag4)
					{
						text = "AI";
					}
					part1BossOpponent.AI = (Activator.CreateInstance(CustomType.GetType("DiskCardGame", text)) as AI);
					part1BossOpponent.NumLives = part1BossOpponent.StartingLives;
					part1BossOpponent.OpponentType = opponentType;
					part1BossOpponent.TurnPlan = part1BossOpponent.ModifyTurnPlan(encounterData.opponentTurnPlan);
					part1BossOpponent.Blueprint = encounterData.Blueprint;
					part1BossOpponent.Difficulty = encounterData.Difficulty;
					part1BossOpponent.ExtraTurnsToSurrender = SeededRandom.Range(0, 3, SaveManager.SaveFile.GetCurrentRandomSeed());
					__result = part1BossOpponent;
					result = false;
				}
				else
				{
					result = true;
				}
				return result;
			}
		}

		[HarmonyPatch(typeof(Opponent), "SpawnOpponent", new Type[]
		{
			typeof(EncounterData)
		})]
		public class SpawnOpponentPatch3
		{
			public static bool Prefix(TurnManager __instance, ref Opponent __result, EncounterData encounterData)
			{
				bool flag = encounterData.opponentType == (Opponent.Type)103;
				bool flag2 = flag;
				bool result;
				if (flag2)
				{
					GameObject gameObject = new GameObject();
					gameObject.name = "Opponent";
					Opponent.Type opponentType = encounterData.opponentType;
					Part1BossOpponent part1BossOpponent = gameObject.AddComponent<LonelyMageOpponnent>();
					string text = encounterData.aiId;
					bool flag3 = string.IsNullOrEmpty(text);
					bool flag4 = flag3;
					if (flag4)
					{
						text = "AI";
					}
					part1BossOpponent.AI = (Activator.CreateInstance(CustomType.GetType("DiskCardGame", text)) as AI);
					part1BossOpponent.NumLives = part1BossOpponent.StartingLives;
					part1BossOpponent.OpponentType = opponentType;
					part1BossOpponent.TurnPlan = part1BossOpponent.ModifyTurnPlan(encounterData.opponentTurnPlan);
					part1BossOpponent.Blueprint = encounterData.Blueprint;
					part1BossOpponent.Difficulty = encounterData.Difficulty;
					part1BossOpponent.ExtraTurnsToSurrender = SeededRandom.Range(0, 3, SaveManager.SaveFile.GetCurrentRandomSeed());
					__result = part1BossOpponent;
					result = false;
				}
				else
				{
					result = true;
				}
				return result;
			}
		}

		[HarmonyPatch(typeof(Opponent), "SpawnOpponent", new Type[]
		{
			typeof(EncounterData)
		})]
		public class SpawnOpponentPatch4
		{
			public static bool Prefix(TurnManager __instance, ref Opponent __result, EncounterData encounterData)
			{
				bool flag = encounterData.opponentType == (Opponent.Type)104;
				bool flag2 = flag;
				bool result;
				if (flag2)
				{
					GameObject gameObject = new GameObject();
					gameObject.name = "Opponent";
					Opponent.Type opponentType = encounterData.opponentType;
					Part1BossOpponent part1BossOpponent = gameObject.AddComponent<MagnificusOpponnent>();
					string text = encounterData.aiId;
					bool flag3 = string.IsNullOrEmpty(text);
					bool flag4 = flag3;
					if (flag4)
					{
						text = "AI";
					}
					part1BossOpponent.AI = (Activator.CreateInstance(CustomType.GetType("DiskCardGame", text)) as AI);
					part1BossOpponent.NumLives = part1BossOpponent.StartingLives;
					part1BossOpponent.OpponentType = opponentType;
					part1BossOpponent.TurnPlan = part1BossOpponent.ModifyTurnPlan(encounterData.opponentTurnPlan);
					part1BossOpponent.Blueprint = encounterData.Blueprint;
					part1BossOpponent.Difficulty = encounterData.Difficulty;
					part1BossOpponent.ExtraTurnsToSurrender = SeededRandom.Range(0, 3, SaveManager.SaveFile.GetCurrentRandomSeed());
					__result = part1BossOpponent;
					result = false;
				}
				else
				{
					result = true;
				}
				return result;
			}
		}

		[HarmonyPatch(typeof(TurnManager), "UpdateSpecialSequencer", new Type[]
		{
			typeof(string)
		})]
		public class SequencerPatch : TurnManager
		{
			public static bool Prefix(TurnManager __instance, string specialBattleId)
			{
				bool flag = specialBattleId == "GoobertSequencer";
				bool flag2 = flag;
				bool result;
				if (flag2)
				{
					GameObject.Destroy(__instance.SpecialSequencer);
					__instance.GetType().GetProperty("SpecialSequencer").SetValue(__instance, __instance.gameObject.AddComponent(typeof(GoobertSequencer)));
					result = false;
				}
				else
				{
					result = true;
				}
				return result;
			}
		}

		[HarmonyPatch(typeof(TurnManager), "UpdateSpecialSequencer", new Type[]
		{
			typeof(string)
		})]
		public class SequencerPatch2 : TurnManager
		{
			public static bool Prefix(TurnManager __instance, string specialBattleId)
			{
				bool flag = specialBattleId == "EspeararaSequencer";
				bool flag2 = flag;
				bool result;
				if (flag2)
				{
					GameObject.Destroy(__instance.SpecialSequencer);
					__instance.GetType().GetProperty("SpecialSequencer").SetValue(__instance, __instance.gameObject.AddComponent(typeof(EspeararaSequencer)));
					result = false;
				}
				else
				{
					result = true;
				}
				return result;
			}
		}

		[HarmonyPatch(typeof(TurnManager), "UpdateSpecialSequencer", new Type[]
		{
			typeof(string)
		})]
		public class SequencerPatch3 : TurnManager
		{
			public static bool Prefix(TurnManager __instance, string specialBattleId)
			{
				bool flag = specialBattleId == "LonelyMageSequencer";
				bool flag2 = flag;
				bool result;
				if (flag2)
				{
					GameObject.Destroy(__instance.SpecialSequencer);
					__instance.GetType().GetProperty("SpecialSequencer").SetValue(__instance, __instance.gameObject.AddComponent(typeof(LonelyMageSequencer)));
					result = false;
				}
				else
				{
					result = true;
				}
				return result;
			}
		}

		[HarmonyPatch(typeof(TurnManager), "UpdateSpecialSequencer", new Type[]
		{
			typeof(string)
		})]
		public class SequencerPatch4 : TurnManager
		{
			public static bool Prefix(TurnManager __instance, string specialBattleId)
			{
				bool flag = specialBattleId == "MagnificusSequencer";
				bool flag2 = flag;
				bool result;
				if (flag2)
				{
					GameObject.Destroy(__instance.SpecialSequencer);
					__instance.GetType().GetProperty("SpecialSequencer").SetValue(__instance, __instance.gameObject.AddComponent(typeof(MagnificusSequencer)));
					result = false;
				}
				else
				{
					result = true;
				}
				return result;
			}
		}
		public class GoobertOpponnent : Part1BossOpponent
		{
			public static readonly InscryptionAPI.Encounters.OpponentManager.FullOpponent FullOpponent = InscryptionAPI.Encounters.OpponentManager.Add(MagnificusMod.Plugin.PluginGuid, "GoobertOpponnent", GoobertSequencer.ID, typeof(GoobertOpponnent));
			public static readonly Opponent.Type ID = InscryptionAPI.Encounters.OpponentManager.Add(MagnificusMod.Plugin.PluginGuid, "GoobertOpponnent", GoobertSequencer.ID, typeof(GoobertOpponnent)).Id;
			public override string DefeatedPlayerDialogue
			{
				get
				{
					return "Goobert, you have made me proud. You've proven yourself worthy of joining the Deck of Magicks.";
				}
			}

			public override IEnumerator IntroSequence(EncounterData encounter)
			{
				Singleton<TextDisplayer>.Instance.gameObject.SetActive(false);
				GameObject.Find("PerspectiveUICamera").transform.Find("TextDisplayer").gameObject.SetActive(true);
				AudioController.Instance.FadeOutLoop(0.75f, Array.Empty<int>());
				yield return base.IntroSequence(encounter);
				yield return new WaitForSeconds(0.75f);
				this.SetSceneEffectsShown(true);
				Singleton<ViewManager>.Instance.SwitchToView(View.Default, false, true);
				yield return new WaitForSeconds(1.55f);
				GameObject.Find("GameTable").transform.Find("Goober").transform.localPosition = new Vector3(0, 6, 26);
				GameObject.Find("GameTable").transform.Find("Goober").transform.rotation = Quaternion.Euler(0, 180, 0);
				GameObject.Find("GameTable").transform.Find("Goober").gameObject.SetActive(true);
				GameObject.Find("deckLight").transform.parent.gameObject.GetComponent<Light>().intensity = 3.5f;
				GameObject.Find("deckLight").transform.parent.gameObject.GetComponent<Light>().color = new Color(0.8f, 1, 0.2f, 1);
				yield return new WaitForSeconds(0.75f);
				Singleton<ViewManager>.Instance.SwitchToView(View.BossCloseup, false, true);
				base.StartCoroutine(GameObject.Find("TextDisplayer").GetComponent<TextDisplayer>().ShowThenClear("ARRGH!!!", 1.5f, 0f, Emotion.Anger, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Goo, null));
				yield return new WaitForSeconds(0.7f);
				AudioController.Instance.SetLoopAndPlay("Goo_Mage", 0, true, true);
				AudioController.Instance.SetLoopVolume(0.3f, 4f, 1, true);
				yield return new WaitForSeconds(0.81f);
				Plugin.setBaseTextDisplayerOn(false);
				Singleton<ViewManager>.Instance.SwitchToView(View.Default, false, false);
				yield return new WaitForSeconds(0.75f);
				yield break;
			}

			public static string GetGameObjectPath(GameObject obj)
			{
				string text = "/" + obj.name;
				while (obj.transform.parent != null)
				{
					obj = obj.transform.parent.gameObject;
					text = "/" + obj.name + text;
				}
				return text;
			}

			public override void SetSceneEffectsShown(bool showEffects)
			{

				if (showEffects)
				{
					Color darkLimeGreen = GameColors.Instance.darkLimeGreen;
					darkLimeGreen.a = 0.5f;
					foreach (CardSlot cardSlot in Singleton<BoardManager>.Instance.AllSlots)
					{
						cardSlot.SetColors(darkLimeGreen, GameColors.Instance.limeGreen, GameColors.Instance.darkLimeGreen);
					}
				}
				else
				{
					foreach (CardSlot cardSlot in Singleton<BoardManager>.Instance.AllSlots)
					{
						cardSlot.ResetColors();
					}
				}
			}

			public override IEnumerator StartNewPhaseSequence()
			{
				Singleton<MagnificusLifeManager>.Instance.opponentLife = 10;
				Singleton<MagnificusLifeManager>.Instance.opponentLifeCounter.ShowValue(10);
				if (KayceeStorage.IsKaycee && MagnificusMod.Generation.challenges.Contains("MoreHpOpponent"))
				{
					Singleton<MagnificusLifeManager>.Instance.opponentLife = 15;
					Singleton<MagnificusLifeManager>.Instance.opponentLifeCounter.ShowValue(15);
				}
				Singleton<ViewManager>.Instance.Controller.LockState = ViewLockState.Locked;
				yield return this.StrikeGoldSequence();
				yield return base.ClearQueue();
				base.Blueprint = ScriptableObject.CreateInstance<BossBlueprints.GoobertP2Blueprint>();
				if (RunState.Run.regionTier > 1)
				{
					base.Blueprint = ScriptableObject.CreateInstance<BossBlueprints.GoobertP2BlueprintBUFF>();
				}
				List<List<CardInfo>> plan = EncounterBuilder.BuildOpponentTurnPlan(base.Blueprint, 0, false);
				base.ReplaceAndAppendTurnPlan(plan);
				Singleton<ViewManager>.Instance.Controller.LockState = ViewLockState.Unlocked;
				yield break;
			}

			public IEnumerator StrikeGoldSequence()
			{
				base.TurnPlan.Clear();
				int num = 0;
				foreach (CardSlot cardSlot2 in Singleton<BoardManager>.Instance.PlayerSlotsCopy)
				{
					bool flag = cardSlot2.Card != null;
					if (flag)
					{
						int num2 = num;
						num = num2 + 1;
					}
				}
				List<CardSlot>.Enumerator enumerator = default(List<CardSlot>.Enumerator);
				bool flag2 = num > 0;
				if (flag2)
				{
					for (int i = 0; i < GameObject.Find("OpponentSlots").transform.childCount; i++)
					{
						GameObject.Find("OpponentSlots").transform.GetChild(i).transform.Find("QueuedCardFrame").gameObject.SetActive(false);
					}
					Singleton<ViewManager>.Instance.SwitchToView(View.OpponentQueue);
					Plugin.setBaseTextDisplayerOn(true);
					yield return GameObject.Find("TextDisplayer").GetComponent<TextDisplayer>().ShowUntilInput("Don't you think those cards are a little too powerful?", -0.65f, 0.4f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Goo, null, true);
					foreach (CardSlot cardSlot in Singleton<BoardManager>.Instance.PlayerSlotsCopy)
					{
						bool flag3 = cardSlot.Card != null;
						if (flag3)
						{
							CardModificationInfo cardModificationInfo = new CardModificationInfo();
							cardModificationInfo.nonCopyable = true;
							cardModificationInfo.singletonId = "goodebuff";
							if (cardSlot.Card.Attack > 0)
							{
								cardModificationInfo.attackAdjustment = -1;
							}
							cardModificationInfo.healthAdjustment = 0;
							cardSlot.Card.AddTemporaryMod(cardModificationInfo);
							int dex = cardSlot.Index;
							GameObject model = GameObject.Find("PlayerSlots").transform.GetChild(dex).GetChild(5).gameObject;
							model.GetComponent<Card>().RenderCard();
						}
					}
					AudioController.Instance.PlaySound2D("magnificus_brush_splatter_bleach", MixerGroup.None, 0.5f, 0f, null, null, null, null, false);
					yield return new WaitForSeconds(0.25f);
					AudioController.Instance.PlaySound2D("Footsteps_Goo#5", MixerGroup.None, 0.5f, 0f, null, null, null, null, false);
					List<CardSlot>.Enumerator enumerator2 = default(List<CardSlot>.Enumerator);
					yield return new WaitForSeconds(0.1f);
					yield return GameObject.Find("TextDisplayer").GetComponent<TextDisplayer>().ShowUntilInput("Thats better.", -0.65f, 0.4f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Goo, null, true);
					yield return new WaitForSeconds(0.1f);
					Plugin.setBaseTextDisplayerOn(false);
					List<CardSlot> list = Singleton<BoardManager>.Instance.OpponentSlotsCopy.FindAll((CardSlot x) => x.opposingSlot.Card == null);
					foreach (CardSlot slot in list)
					{
						yield return Singleton<BoardManager>.Instance.CreateCardInSlot(CardLoader.GetCardByName("mag_goo"), slot, 0.2f, true);
						yield return new WaitForSeconds(0.25f);
						GameObject.Find("OpponentSlots").transform.GetChild(slot.Index).transform.Find("QueuedCardFrame").gameObject.SetActive(false);
					}
					List<CardSlot>.Enumerator enumerator3 = default(List<CardSlot>.Enumerator);
					list = null;
				}
				yield break;
			}

			private CardModificationInfo mod;
		}

		public class EspeararaOpponnent : Part1BossOpponent
		{
			public static readonly InscryptionAPI.Encounters.OpponentManager.FullOpponent FullOpponent = InscryptionAPI.Encounters.OpponentManager.Add(MagnificusMod.Plugin.PluginGuid, "EspeararaOpponnent", EspeararaSequencer.ID, typeof(EspeararaOpponnent));
			public static readonly Opponent.Type ID = InscryptionAPI.Encounters.OpponentManager.Add(MagnificusMod.Plugin.PluginGuid, "EspeararaOpponnent", EspeararaSequencer.ID, typeof(EspeararaOpponnent)).Id;
			public override string DefeatedPlayerDialogue
			{
				get
				{
					return "Amber, I shall congratulate you. You have fared well.";
				}
			}

			public static IEnumerator paintTheFloor()
            {
				for (float i = 0; i < 100; i++)
				{
					float modify = i / 400f;
					GameObject.Find("DungeonFloor").transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.color = new Color(0.25f + modify, 0.25f - modify, 0.25f - modify, 1);
					yield return new WaitForSeconds(0.01f);
				}
				//GameObject.Find("DungeonFloor").transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.color = new Color(0.5f, 0, 0, 1);
				yield break;
            }

			public override IEnumerator IntroSequence(EncounterData encounter)
			{
				AudioController.Instance.FadeOutLoop(0.75f, Array.Empty<int>());
				yield return base.IntroSequence(encounter);
				Singleton<ViewManager>.Instance.SwitchToView(View.Default, false, true);

				GameObject.Find("Player").transform.Find("PixelCameraParent").Find("Pixel Camera").gameObject.GetComponent<Camera>().backgroundColor = new Color(0.4f, 0, 0);

				Plugin.switchToSpeakerStyle(1);
				yield return new WaitForSeconds(1.55f);
				GameObject.Find("GameTable").transform.Find("Espeara").transform.localPosition = new Vector3(0, -10f, 36f);
				GameObject.Find("GameTable").transform.Find("Espeara").transform.localScale = new Vector3(5, 0, 5);
				GameObject.Find("GameTable").transform.Find("Espeara").transform.localRotation = Quaternion.Euler(1, 270, 320);
				GameObject.Find("GameTable").transform.Find("Espeara").gameObject.SetActive(true);
				Tween.LocalScale(GameObject.Find("GameTable").transform.Find("Espeara"), new Vector3(5, 6.5f, 5), 0.75f, 0f);
				Tween.LocalScale(GameObject.Find("GameTable").transform.Find("Espeara"), new Vector3(5, 5, 5), 0.2f, 0.751f);
				Tween.LocalRotation(GameObject.Find("GameTable").transform.Find("Espeara"), Quaternion.Euler(1, 270, 400), 0.3f, 0.351f);
				Tween.LocalRotation(GameObject.Find("GameTable").transform.Find("Espeara"), Quaternion.Euler(1, 270, 360), 0.5f, 0.651f);
				yield return new WaitForSeconds(0.75f);
				this.SetSceneEffectsShown(true);
				Singleton<ViewManager>.Instance.SwitchToView(View.BossCloseup, false, true);
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Just imagine.. You are an ice cube, slowly melting in a hot pan..", -2f, 0f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);

				AudioController.Instance.SetLoopAndPlay("gbc_battle_wizard", 0, true, true);
				AudioController.Instance.SetLoopVolume(0.25f, 4f, 1, true);

				yield return new WaitForSeconds(1f);
				Plugin.switchToSpeakerStyle(0);
				Singleton<ViewManager>.Instance.SwitchToView(View.Default, false, false);
				GameObject.Find("GameTable").transform.Find("Espeara").gameObject.AddComponent<SineWaveRotation>();
				GameObject.Find("GameTable").transform.Find("Espeara").gameObject.GetComponent<SineWaveRotation>().originalRotation = new Vector3(1, 270, 0);
				GameObject.Find("GameTable").transform.Find("Espeara").gameObject.GetComponent<SineWaveRotation>().xMagnitude = -2f;
				GameObject.Find("GameTable").transform.Find("Espeara").gameObject.GetComponent<SineWaveRotation>().speed = 1;
				base.StartCoroutine(paintTheFloor());
				yield return new WaitForSeconds(0.75f);
				yield break;
			}

			public static string GetGameObjectPath(GameObject obj)
			{
				string text = "/" + obj.name;
				while (obj.transform.parent != null)
				{
					obj = obj.transform.parent.gameObject;
					text = "/" + obj.name + text;
				}
				return text;
			}

			public override void SetSceneEffectsShown(bool showEffects)
			{
				if (showEffects)
				{
					Color brownOrange = GameColors.Instance.brownOrange;
					brownOrange.a = 0.5f;
					foreach (CardSlot cardSlot in Singleton<BoardManager>.Instance.AllSlots)
					{
						cardSlot.SetColors(GameColors.Instance.orange, brownOrange, GameColors.Instance.orange);
					}
				}
				else
				{
					/*
					if (!KayceeStorage.IsKaycee)
					{
						Singleton<TextDisplayer>.Instance.ShowMessage("its over!!");
						Singleton<TableVisualEffectsManager>.Instance.ResetTableColors();
					}
					else
					{
						base.StartCoroutine(KayceeEnd());
					}
					*/
					foreach (CardSlot cardSlot in Singleton<BoardManager>.Instance.AllSlots)
					{
						cardSlot.ResetColors();
					}
				}
			}

			public static IEnumerator KayceeEnd()
			{
				yield return new WaitForSeconds(1f);
				if (MagnificusMod.Generation.minimap)
				{
					MagnificusMod.Generation.minimap = false;
					MagnificusMod.SaveVariables.HasMap = false;
					SavedVars.HasMapIcons = false;
					Destroy(GameObject.Find("MapParent"));
				}
				Singleton<UIManager>.Instance.Effects.GetEffect<ScreenColorEffect>().SetColor(GameColors.Instance.nearBlack);
				Singleton<UIManager>.Instance.Effects.GetEffect<ScreenColorEffect>().SetIntensity(1f, float.MaxValue);
				AudioController.Instance.StopAllLoops();
				Singleton<InteractionCursor>.Instance.SetHidden(true);
				yield return new WaitForSeconds(3f);
				SceneLoader.Load("Ascension_Configure");
				yield break;
			}
			public override IEnumerator StartNewPhaseSequence()
			{
				Singleton<MagnificusLifeManager>.Instance.opponentLife = 10;
				Singleton<MagnificusLifeManager>.Instance.opponentLifeCounter.ShowValue(10);
				if (KayceeStorage.IsKaycee && MagnificusMod.Generation.challenges.Contains("MoreHpOpponent"))
				{
					Singleton<MagnificusLifeManager>.Instance.opponentLife = 15;
					Singleton<MagnificusLifeManager>.Instance.opponentLifeCounter.ShowValue(15);
				}
				Singleton<ViewManager>.Instance.Controller.LockState = ViewLockState.Locked;
				yield return base.ClearQueue();
				yield return this.StrikeGoldSequence();
				base.Blueprint = ScriptableObject.CreateInstance<BossBlueprints.EspeararaP2Blueprint>();
				List<List<CardInfo>> plan = EncounterBuilder.BuildOpponentTurnPlan(base.Blueprint, 0, false);
				base.ReplaceAndAppendTurnPlan(plan);
				Singleton<ViewManager>.Instance.Controller.LockState = ViewLockState.Unlocked;
				yield break;
			}

			public IEnumerator StrikeGoldSequence()
			{
				Singleton<ViewManager>.Instance.SwitchToView(View.OpponentQueue, false, true);
				base.TurnPlan.Clear();
				int num = 0;
				foreach (CardSlot cardSlot2 in Singleton<BoardManager>.Instance.OpponentSlotsCopy)
				{
					bool flag = cardSlot2.Card == null;
					if (flag)
					{
						int num2 = num;
						num = num2 + 1;
					}
				}
				List<CardSlot>.Enumerator enumerator = default(List<CardSlot>.Enumerator);
				bool flag2 = num > 0;
				if (flag2)
				{
					yield return new WaitForSeconds(0.1f);
					foreach (CardSlot cardSlot in Singleton<BoardManager>.Instance.OpponentSlotsCopy)
					{
						bool flag3 = cardSlot.Card == null;
						if (flag3)
						{
							yield return new WaitForSeconds(0.1f);
							yield return Singleton<BoardManager>.Instance.CreateCardInSlot(CardLoader.GetCardByName("mag_BOSStrapspear"), cardSlot, 0.1f, true);
						}
					}
					List<CardSlot>.Enumerator enumerator2 = default(List<CardSlot>.Enumerator);
					Singleton<ViewManager>.Instance.SwitchToView(View.OpponentQueue, false, true);
					Plugin.switchToSpeakerStyle(1);
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("These enchanted spears won't just damage your cards..", 1.5f, 0.4f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
					yield return new WaitForSeconds(0.5f);
					Plugin.switchToSpeakerStyle(0);
					Singleton<ViewManager>.Instance.SwitchToView(View.Default, false, false);
				}
				yield break;
			}
		}

		public class LonelyMageOpponnent : Part1BossOpponent
		{
			public static readonly InscryptionAPI.Encounters.OpponentManager.FullOpponent FullOpponent = InscryptionAPI.Encounters.OpponentManager.Add(MagnificusMod.Plugin.PluginGuid, "LonelyMageOpponnent", LonelyMageSequencer.ID, typeof(LonelyMageOpponnent));
			public static readonly Opponent.Type ID = InscryptionAPI.Encounters.OpponentManager.Add(MagnificusMod.Plugin.PluginGuid, "LonelyMageOpponnent", LonelyMageSequencer.ID, typeof(LonelyMageOpponnent)).Id;
			public override string DefeatedPlayerDialogue
			{
				get
				{
					return "My Lonely Mage, you seem worthy of joining my deck, for you have defeated your opponent. ";
				}
			}

			public int phase = 1;

			public bool TurnTimerDialogue = false;

			public override IEnumerator IntroSequence(EncounterData encounter)
			{
				phase = 1;
				TurnTimerDialogue = false;
				Plugin.specialBossSequence = true;
				Plugin.switchToSpeakerStyle(2);
				AudioController.Instance.FadeOutLoop(0.75f, Array.Empty<int>());
				yield return base.IntroSequence(encounter);
				Singleton<ViewManager>.Instance.SwitchToView(View.Default, false, true);
				AudioController.Instance.SetLoopAndPlay("gbc_battle_wizard", 0, true, true);
				AudioController.Instance.SetLoopVolume(0.25f, 4f, 1, true);
				GameObject.Find("GameTable").transform.Find("LonelyMage").transform.localPosition = new Vector3(0, 1, 15);
				GameObject.Find("GameTable").transform.Find("LonelyMage").gameObject.SetActive(true);
				GameObject.Find("GameTable").transform.Find("LonelyMage").transform.GetChild(2).GetChild(0).GetChild(0).GetChild(1).Find("LeftEye").localScale = new Vector3(1, 1, 1);
				GameObject.Find("GameTable").transform.Find("LonelyMage").transform.GetChild(2).GetChild(0).GetChild(0).GetChild(2).Find("RightEye").localScale = new Vector3(-1, -1, -1);
				GameObject.Find("GameTable").transform.Find("LonelyMage").GetComponent<Animator>().speed = 1;
				yield return new WaitForSeconds(2f);
				this.SetSceneEffectsShown(true);
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("W-What? A challenger?", -0.5f, 0f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
				yield return new WaitForSeconds(0.26f);
				Singleton<ViewManager>.Instance.SwitchToView(View.BossCloseup, false, true);
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("FINALLY!! STIMULATION!", -1f, 0f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
				yield return new WaitForSeconds(1f);
				Plugin.switchToSpeakerStyle(0);
				Singleton<ViewManager>.Instance.SwitchToView(View.Default, false, false);
				yield return new WaitForSeconds(0.15f);
				yield break;
			}

			public static string GetGameObjectPath(GameObject obj)
			{
				string text = "/" + obj.name;
				while (obj.transform.parent != null)
				{
					obj = obj.transform.parent.gameObject;
					text = "/" + obj.name + text;
				}
				return text;
			}

			public override void SetSceneEffectsShown(bool showEffects)
			{

				if (showEffects)
				{
					foreach (CardSlot cardSlot in Singleton<BoardManager>.Instance.AllSlots)
					{
						cardSlot.SetColors(new Color(0, 0.3f, 0.8f, 0.5f), new Color(0, 0.3f, 0.8f, 1), new Color(0, 0.8f, 0.8f, 1));
					}
				}
				else
				{
					foreach (CardSlot cardSlot in Singleton<BoardManager>.Instance.AllSlots)
					{
						cardSlot.ResetColors();
					}
				}
			}

			

			public override IEnumerator StartNewPhaseSequence()
			{
				phase = 2;
				Singleton<MagnificusLifeManager>.Instance.opponentLife = 10;
				Singleton<MagnificusLifeManager>.Instance.opponentLifeCounter.ShowValue(10);
				if (KayceeStorage.IsKaycee && MagnificusMod.Generation.challenges.Contains("MoreHpOpponent"))
				{
					Singleton<MagnificusLifeManager>.Instance.opponentLife = 15;
					Singleton<MagnificusLifeManager>.Instance.opponentLifeCounter.ShowValue(15);
				}
				Singleton<ViewManager>.Instance.SwitchToView(View.OpponentQueue, false, true);
				Singleton<ViewManager>.Instance.Controller.LockState = ViewLockState.Locked;
				yield return new WaitForSeconds(0.5f);
				yield return this.StrikeGoldSequence();
				base.Blueprint = ScriptableObject.CreateInstance<BossBlueprints.LonelyMageP2BlueprintNERF>();
				if (RunState.Run.regionTier > 0)
				{
					base.Blueprint = ScriptableObject.CreateInstance<BossBlueprints.LonelyMageP2Blueprint>();
				}
				List<List<CardInfo>> plan = EncounterBuilder.BuildOpponentTurnPlan(base.Blueprint, 0, false);
				base.ReplaceAndAppendTurnPlan(plan);
				Singleton<ViewManager>.Instance.Controller.LockState = ViewLockState.Unlocked;
				yield break;
			}

			public IEnumerator StrikeGoldSequence()
			{
				base.TurnPlan.Clear();
				Plugin.switchToSpeakerStyle(2);
				Singleton<ViewManager>.Instance.SwitchToView(View.OpponentQueue, false, true);
				yield return new WaitForSeconds(0.15f);
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("I'M STILL NOT STIMULATED ENOUGH!!", 0f, 0f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("I HAVE THE URGE TO SEARCH A CARD PILE!", 0f, 0f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
				yield return Singleton<LonelyMageSequencer>.Instance.shuffleBoard();
				yield return new WaitForSeconds(0.5f);
				Plugin.switchToSpeakerStyle(0);
				
				yield break;
			}
		}

		public class MagnificusOpponnent : Part1BossOpponent
		{
			public static readonly InscryptionAPI.Encounters.OpponentManager.FullOpponent FullOpponent = InscryptionAPI.Encounters.OpponentManager.Add(MagnificusMod.Plugin.PluginGuid, "MagnificusOpponnent", MagnificusSequencer.ID, typeof(MagnificusOpponnent));
			public static readonly Opponent.Type ID = InscryptionAPI.Encounters.OpponentManager.Add(MagnificusMod.Plugin.PluginGuid, "MagnificusOpponnent", MagnificusSequencer.ID, typeof(MagnificusOpponnent)).Id;
			public override string DefeatedPlayerDialogue
			{
				get
				{
					return "You got so far.....";
				}
			}

			public override int StartingLives
			{
				get
				{
					return 3;
				}
			}

			public override bool GiveCurrencyOnDefeat
			{
				get
				{
					return false;
				}
			}

			public override IEnumerator IntroSequence(EncounterData encounter)
			{
				edaxioSummoned = false;
				Plugin.specialBossSequence = false;
				AudioController.Instance.FadeOutLoop(0.75f, Array.Empty<int>());
				yield return base.IntroSequence(encounter);
				Singleton<ViewManager>.Instance.SwitchToView(View.Default, false, true);
				AudioController.Instance.SetLoopAndPlay("TheArtOfMagicks", 0, true, true);//"RapSong"
				AudioController.Instance.SetLoopVolume(0.25f, 4f, 1, true);
				yield return new WaitForSeconds(1.55f);
				this.SetSceneEffectsShown(true);
				yield return new WaitForSeconds(0.5f);
				//this.bossSkull.EnterHand();
				//this.bignificus();
				yield break;
			}

			public override IEnumerator LifeLostSequence()
			{
				bool flag = base.NumLives == 0;
				if (flag)
				{
					Singleton<InteractionCursor>.Instance.InteractionDisabled = true;
					yield return new WaitForSeconds(0.5f);
					Singleton<ViewManager>.Instance.SwitchToView(View.BossSkull, false, true);
					yield return new WaitForSeconds(1.5f);
					GameObject bossLife = GameObject.Find("bossPainting");
					bossLife.GetComponent<SineWaveMovement>().enabled = false;
					yield return new WaitForSeconds(0.5f);
					Tween.Rotation(bossLife.transform, Quaternion.Euler(0, 145, 0), 0.8f, 0);
					Tween.Rotation(bossLife.transform, Quaternion.Euler(0, 325, 0), 1.2f, 0.88f);
					yield return new WaitForSeconds(0.8f);
					AudioController.Instance.PlaySound2D("magnificus_brush_splatter_bleach", MixerGroup.None, 0.5f, 0f, null, null, null, null, false);
					bossLife.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = Tools.getImage("bossdefeated.png");
					yield return new WaitForSeconds(2f);
					Singleton<UIManager>.Instance.Effects.GetEffect<ScreenColorEffect>().SetColor(GameColors.Instance.nearBlack);
					Singleton<UIManager>.Instance.Effects.GetEffect<ScreenColorEffect>().SetIntensity(1f, float.MaxValue);
					AudioController.Instance.StopAllLoops();
					Singleton<InteractionCursor>.Instance.SetHidden(true);
					yield return new WaitForSeconds(0.5f);
					yield return new WaitForSeconds(3f);
					if (SaveFile.IsAscension)
					{
						AscensionMenuScreens.ReturningFromSuccessfulRun = true;
						AscensionStatsData.TryIncrementStat(AscensionStat.Type.Victories);
						AscensionStatsData.TryIncrementStat(AscensionStat.Type.BossesDefeated);
						foreach (AscensionChallenge item in AscensionSaveData.Data.activeChallenges)
						{
							bool flag2 = !AscensionSaveData.Data.conqueredChallenges.Contains(item);
							if (flag2)
							{
								AscensionSaveData.Data.conqueredChallenges.Add(item);
							}
						}
						bool flag3 = !string.IsNullOrEmpty(AscensionSaveData.Data.currentStarterDeck) && !AscensionSaveData.Data.conqueredStarterDecks.Contains(AscensionSaveData.Data.currentStarterDeck);
						if (flag3)
						{
							AscensionSaveData.Data.conqueredStarterDecks.Add(AscensionSaveData.Data.currentStarterDeck);
						}
						KayceeStorage.IsMagRun = false;
						SaveManager.SaveToFile(false);
						SceneLoader.Load("Ascension_Configure");
					}
					else
					{
						int regionTier = RunState.Run.regionTier;
						regionTier++;
						MagSave.clearedNode = new List<string>();
						MagSave.SaveLayout(regionTier.ToString());
						RunState.Run.regionTier = 0;
						File.WriteAllText(SaveManager.SaveFolderPath + "MagnificusModSave.gwsave", SaveManager.ToJSON(MagSave.GetNodeStuff(false, false)));
						Tween.Position(GameObject.Find("Player").transform, new Vector3(GameObject.Find("Player").transform.position.x, 12.5f, GameObject.Find("Player").transform.position.z), 0.5f, 0);
						yield return new WaitForSeconds(0.55f);
						yield return MagnificusMod.Generation.transition("tower", "none");
					}
				}
				else
				{
					yield return base.LifeLostSequence();
				}
				yield break;
			}

			public static string GetGameObjectPath(GameObject obj)
			{
				string text = "/" + obj.name;
				while (obj.transform.parent != null)
				{
					obj = obj.transform.parent.gameObject;
					text = "/" + obj.name + text;
				}
				return text;
			}

			public override void SetSceneEffectsShown(bool showEffects)
			{
				if (showEffects)
				{
					foreach (CardSlot cardSlot in Singleton<BoardManager>.Instance.AllSlots)
					{
						cardSlot.SetColors(GameColors.Instance.darkPurple, GameColors.Instance.darkPurple, GameColors.Instance.purple);
					}
				}
				else
				{
					foreach (CardSlot cardSlot in Singleton<BoardManager>.Instance.AllSlots)
					{
						cardSlot.ResetColors();
					}
				}
			}

			public bool edaxioSummoned = false;
			public List<CardSlot> BuffedAtkSlots = new();
			public List<CardSlot> BuffedHpSlots = new List<CardSlot>();
			public override IEnumerator StartNewPhaseSequence()
			{
				Singleton<MagnificusLifeManager>.Instance.opponentLife = 10;
				Singleton<MagnificusLifeManager>.Instance.opponentLifeCounter.ShowValue(10);
				if (KayceeStorage.IsKaycee && MagnificusMod.Generation.challenges.Contains("MoreHpOpponent"))
				{
					Singleton<MagnificusLifeManager>.Instance.opponentLife = 15;
					Singleton<MagnificusLifeManager>.Instance.opponentLifeCounter.ShowValue(15);
				}
				if (Singleton<MagnificusLifeManager>.Instance.playerLife < 5) {
					Singleton<MagnificusLifeManager>.Instance.playerLife = 5;
					Singleton<MagnificusLifeManager>.Instance.playerLifeCounter.ShowValue(5);
				}
				int numLives = base.NumLives;
				if (numLives >= 2)
                {
					Singleton<ViewManager>.Instance.SwitchToView(View.OpponentQueue, false, true);
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Perhaps I am slowing down with age..", 0f, 0f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("I must use the brush to my advantage yet again.", 0f, 0f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);

					foreach (CardSlot slot in Singleton<BoardManager>.Instance.OpponentSlotsCopy)
                    {
						CardModificationInfo tempMod = new CardModificationInfo();
						if (slot.Index % 2 == 0)
						{
							BuffedAtkSlots.Add(slot);
							AudioController.Instance.PlaySound2D("magnificus_brush_splatter_color", MixerGroup.None, 0.5f, 0f, null, null, null, null, false);
							GameObject.Find("OpponentSlots").transform.GetChild(slot.Index).Find("Border").gameObject.GetComponent<MeshRenderer>().material.mainTexture = Tools.getImage("1atkslot.png");
							GameObject.Find("OpponentSlots").transform.GetChild(slot.Index).Find("Border").rotation = Quaternion.Euler(90, 0, 0);
							if (slot.Card != null)
                            {
								tempMod.attackAdjustment = 1;
								slot.Card.renderInfo.attackTextColor = new Color(0.41f, 1f, 0.62f, 1f);
								slot.Card.AddTemporaryMod(tempMod);
							}
						} else
                        {
							BuffedHpSlots.Add(slot);
							AudioController.Instance.PlaySound2D("magnificus_brush_splatter_color", MixerGroup.None, 0.5f, 0f, null, null, null, null, false);
							GameObject.Find("OpponentSlots").transform.GetChild(slot.Index).Find("Border").gameObject.GetComponent<MeshRenderer>().material.mainTexture = Tools.getImage("2hpslot.png");
							if (slot.Card != null)
							{
								tempMod.healthAdjustment = 2;
								slot.Card.renderInfo.healthTextColor = new Color(1f, 0.24f, 0.435f, 1f);
								slot.Card.AddTemporaryMod(tempMod);
							}
						}
						yield return new WaitForSeconds(0.5f);
                    }

					Singleton<ViewController>.Instance.LockState = ViewLockState.Unlocked;
					Singleton<ViewManager>.Instance.SwitchToView(View.Default, false, false);
				} else if (numLives < 2)
                {
					outOfCardsLine = false;
					bool hasEdaxio = Singleton<BoardManager>.Instance.GetSlots(true).Find((CardSlot x) => x.Card != null && x.Card.Info.HasAbility(Ability.EdaxioArms)) != null && Singleton<BoardManager>.Instance.GetSlots(true).Find((CardSlot x) => x.Card != null && x.Card.Info.HasAbility(Ability.EdaxioLegs)) != null && Singleton<BoardManager>.Instance.GetSlots(true).Find((CardSlot x) => x.Card != null && x.Card.Info.HasAbility(Ability.EdaxioTorso)) != null && Singleton<BoardManager>.Instance.GetSlots(true).Find((CardSlot x) => x.Card != null && x.Card.Info.HasAbility(Ability.EdaxioHead)) != null; 
					Singleton<ViewManager>.Instance.SwitchToView(View.Default, false, true);
					Singleton<MagnificusSequencer>.Instance.killedPlanets = -1;
					if (!hasEdaxio)
					{
						yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("You have impressed me, you truly have..", 0f, 0f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
						yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("2 lives down now.", 0f, 0f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
						yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Unfortunately for you, I still have a few tricks up my sleeve.", 0f, 0f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
					} else
                    {
						edaxioSummoned = true;
						Singleton<MagnificusSequencer>.Instance.killedPlanets = -5;
						yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("You've cheated me..", 0f, 0f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
						yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Summoning that [c:g1]tyrant[c:].", 0f, 0f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
						yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("You give me no option but to also cheat..", 0f, 0f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);

					}
					GameObject MagnificusColum = GameObject.Find("MarbleColumn_Opponent");
					GameObject Magnificus = GameObject.Find("MagnificusAnim");
					Tween.LocalRotation(Magnificus.transform, Quaternion.Euler(0, 0, 0), 2.5f, 0);
					yield return new WaitForSeconds(2.5f);
					GameObject painting = GameObject.Instantiate<GameObject>(GameObject.Find("nodeIconBase"));
					painting.transform.position = new Vector3(80.757f, 35, 18);
					painting.transform.localScale = new Vector3(0.5f, 0.35f, 0.3f);
					painting.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().lightmapIndex = 0;
					GameObject.Find("MagnificusEnvironment").transform.Find("RenderCamera").parent = painting.transform;
					painting.transform.Find("RenderCamera").gameObject.SetActive(true);
					painting.transform.Find("RenderCamera").localPosition = new Vector3(0, 0, 0);
					painting.transform.Find("RenderCamera").localScale = new Vector3(4, 4, 4);
					painting.AddComponent<GiantPaintingAnim>().frame = painting.transform.Find("Frame").gameObject;
					painting.GetComponent<GiantPaintingAnim>().moon = painting.transform.Find("RenderCamera").GetChild(0).Find("Moon").gameObject.GetComponent<SpriteRenderer>();
					painting.GetComponent<GiantPaintingAnim>().dustParticles = painting.transform.Find("RenderCamera").GetChild(0).Find("Dust").gameObject;
					painting.GetComponent<GiantPaintingAnim>().blackStreaks = new List<SpriteRenderer>();
					for (int i = 0; i < painting.transform.Find("RenderCamera").GetChild(0).Find("Streaks").childCount; i++)
                    {
						painting.GetComponent<GiantPaintingAnim>().blackStreaks.Add(painting.transform.Find("RenderCamera").GetChild(0).Find("Streaks").GetChild(i).gameObject.GetComponent<SpriteRenderer>());
					}
					painting.GetComponent<GiantPaintingAnim>().moonGlowRenderers = new List<Renderer> { painting.transform.Find("Frame").Find("Glow_Edge_Right").gameObject.GetComponent<MeshRenderer>(), painting.transform.Find("Frame").Find("Glow_Edge_Left").gameObject.GetComponent<MeshRenderer>() };
					painting.GetComponent<GiantPaintingAnim>().starStreakParents = new List<Transform> { painting.transform.Find("RenderCamera").GetChild(0).Find("Stars_Streak1"), painting.transform.Find("RenderCamera").GetChild(0).Find("Stars_Streak2"), painting.transform.Find("RenderCamera").GetChild(0).Find("Stars_Streak3") };

					painting.name = "MoonPainting";
					GiantPaintingAnim giantPainting = painting.GetComponent<GiantPaintingAnim>();
					MagnificusAnimationController magnificusAnimationController = Magnificus.GetComponent<MagnificusAnimationController>();
					if (hasEdaxio)
					{
						GameObject.Find("Moon").GetComponent<SpriteRenderer>().material = painting.transform.Find("RenderCamera").GetChild(0).Find("Streaks").GetChild(3).gameObject.GetComponent<SpriteRenderer>().material;
						GameObject.Find("Moon").GetComponent<SpriteRenderer>().sprite = Tools.getSprite("earth_portrait.png");
						GameObject.Find("Moon").transform.localScale = new Vector3(4.5f, 4.5f, 4.5f);
						GameObject.Find("Moon").GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
					}
					yield return new WaitForSeconds(1.5f);
					giantPainting.Show();
					yield return new WaitForSeconds(4f);
					magnificusAnimationController.SetHeadTrigger("brush_vertical_1");
					giantPainting.PaintBlackStreak(0);
					yield return new WaitForSeconds(1.25f);
					magnificusAnimationController.SetHeadTrigger("brush_vertical_2");
					giantPainting.PaintBlackStreak(1);
					yield return new WaitForSeconds(1.25f);
					magnificusAnimationController.SetHeadTrigger("brush_vertical_3");
					giantPainting.PaintBlackStreak(2);
					yield return new WaitForSeconds(1.25f);
					magnificusAnimationController.SetHeadTrigger("brush_vertical_4");
					giantPainting.PaintBlackStreak(3);
					yield return new WaitForSeconds(0.75f);
					magnificusAnimationController.SetHeadTrigger("brush_vertical_1");
					giantPainting.PaintBlackStreak(4);
					yield return new WaitForSeconds(0.75f);
					magnificusAnimationController.SetHeadTrigger("brush_vertical_2");
					giantPainting.PaintBlackStreak(5);
					yield return new WaitForSeconds(1.5f);
					magnificusAnimationController.SetHeadTrigger("brush_vertical_3");
					giantPainting.PaintStarStreak(0);
					yield return new WaitForSeconds(1.5f);
					magnificusAnimationController.SetHeadTrigger("brush_vertical_4");
					giantPainting.PaintStarStreak(1);
					yield return new WaitForSeconds(1.5f);
					magnificusAnimationController.SetHeadTrigger("brush_vertical_1");
					giantPainting.PaintStarStreak(2);
					yield return new WaitForSeconds(0.75f);
					magnificusAnimationController.SetHeadTrigger("brush_vertical_2");
					giantPainting.PaintMoon();
					if (!hasEdaxio)
					{
						GameObject.Find("THE MOOON(Clone)").SetActive(false);
					}
					yield return new WaitForSeconds(3.5f);
					foreach (CardSlot slot in Singleton<BoardManager>.Instance.OpponentSlotsCopy)
					{
						CardModificationInfo tempMod = new CardModificationInfo();
						BuffedAtkSlots = new List<CardSlot>();
						BuffedHpSlots = new List<CardSlot>();
						GameObject.Find("OpponentSlots").transform.GetChild(slot.Index).Find("Border").gameObject.GetComponent<MeshRenderer>().material.mainTexture = GameObject.Find("PlayerSlots").transform.GetChild(0).Find("Border").gameObject.GetComponent<MeshRenderer>().material.mainTexture;
					}
					foreach (CardSlot slot in Singleton<BoardManager>.Instance.OpponentSlotsCopy)
					{
						if (slot.Card != null)
                        {
							yield return slot.Card.Die(false);
                        }
					}
					yield return base.ClearQueue();
					base.TurnPlan.Clear();
					Tween.Position(painting.transform, new Vector3(80.757f, 5, 18), 1f, 0);
					Tween.Rotation(Magnificus.transform, Quaternion.Euler(0, 180, 0), 0.65f, 0);
					Singleton<ViewController>.Instance.LockState = ViewLockState.Unlocked;
					Singleton<ViewManager>.Instance.SwitchToView(View.Default, false, false);
					yield return new WaitForSeconds(0.4f);
					painting.transform.Find("RenderCamera").localScale = new Vector3(0, 0, 0);
					if (!hasEdaxio)
					{
						yield return Singleton<BoardManager>.Instance.CreateCardInSlot(CardLoader.GetCardByName("mag_giantmoon"), Singleton<BoardManager>.Instance.OpponentSlotsCopy[0], 0.1f, true);
					} else
                    {
						yield return Singleton<BoardManager>.Instance.CreateCardInSlot(CardLoader.GetCardByName("mag_giantearth"), Singleton<BoardManager>.Instance.OpponentSlotsCopy[0], 0.1f, true);
					}
					yield return new WaitForSeconds(0.65f);
					GameObject.Destroy(painting);
					MagnificusAnimationController.Instance.SetHeadTrigger("idle");
					MagnificusAnimationController.Instance.GetComponentInChildren<Animator>().updateMode = AnimatorUpdateMode.Normal;
				}
				yield break;
			}

			public IEnumerator StrikeGoldSequence()
			{
				base.TurnPlan.Clear();
				bool doneDat = false;
				List<CardSlot> list = Singleton<BoardManager>.Instance.opponentSlots.FindAll((CardSlot x) => x.opposingSlot.Card != null);
				foreach (CardSlot slot in list)
				{
					bool flag = !doneDat;
					if (flag)
					{
						yield return Singleton<BoardManager>.Instance.CreateCardInSlot(CardLoader.GetCardByName("mag_BOSSgoobert"), slot, 0.2f, true);
						doneDat = true;
						yield return new WaitForSeconds(0.25f);
						base.StartCoroutine(Singleton<TextDisplayer>.Instance.ShowThenClear("You managed to defeat my students once, but can you do it twice?", 1.5f, 0f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null));
						yield return new WaitForSeconds(1.5f);
					}
				}
				List<CardSlot>.Enumerator enumerator = default(List<CardSlot>.Enumerator);
				yield break;
			}

			public IEnumerator bignificus()
			{
				AudioController.Instance.SetLoopAndPlay("finalemagnificus", 0, true, true);
				AudioController.Instance.SetLoopVolume(0.25f, 4f, 1, true);
				yield return new WaitForSeconds(0.2f);
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Lets see how you face off against your own deck.", 1.5f, 0.4f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
				yield return new WaitForSeconds(1.5f);
				List<CardSlot> list = Singleton<BoardManager>.Instance.OpponentSlotsCopy.FindAll((CardSlot x) => x.opposingSlot.Card != null);
				foreach (CardSlot slot2 in list)
				{
					PlayableCard yourCard = slot2.opposingSlot.Card;
					yield return Singleton<BoardManager>.Instance.CreateCardInSlot(yourCard.Info, slot2, 0.2f, true);
					CardModificationInfo cardModificationInfo = new CardModificationInfo();
					List<Ability> ability = new List<Ability>();
					ability.Add(Ability.Reach);
					cardModificationInfo.nonCopyable = true;
					cardModificationInfo.singletonId = "zeroout";
					cardModificationInfo.attackAdjustment = 1;
					cardModificationInfo.healthAdjustment = slot2.opposingSlot.Card.Attack;
					cardModificationInfo.abilities = ability;
					slot2.Card.AddTemporaryMod(cardModificationInfo);
					this.mod = new CardModificationInfo();
					this.mod.nonCopyable = true;
					this.mod.singletonId = "statswap";
					this.mod.attackAdjustment = 0;
					this.mod.healthAdjustment = 0;
					slot2.Card.SetInfo(slot2.Card.Info);
					slot2.Card.AddTemporaryMod(this.mod);
					yield return new WaitForSeconds(0.25f);
					yourCard = null;
					cardModificationInfo = null;
					ability = null;
				}
				List<CardSlot>.Enumerator enumerator = default(List<CardSlot>.Enumerator);
				List<CardSlot> list2 = Singleton<BoardManager>.Instance.OpponentSlotsCopy.FindAll((CardSlot x) => x.opposingSlot.Card == null);
				foreach (CardSlot slot3 in list2)
				{
					yield return Singleton<BoardManager>.Instance.CreateCardInSlot(CardLoader.GetCardByName("mag_BOSSmagnusmox"), slot3, 0.2f, true);
				}
				List<CardSlot>.Enumerator enumerator2 = default(List<CardSlot>.Enumerator);
				base.Blueprint = ScriptableObject.CreateInstance<BossBlueprints.MagnificusFinalBlueprint>();
				List<List<CardInfo>> plan = EncounterBuilder.BuildOpponentTurnPlan(base.Blueprint, 0, false);
				base.ReplaceAndAppendTurnPlan(plan);
				yield break;
				yield break;
			}


			public bool outOfCardsLine = false;
			private CardModificationInfo mod;
		}

		public class GoobertSequencer : Part1BossBattleSequencer
		{
			public static readonly string ID = InscryptionAPI.Encounters.SpecialSequenceManager.Add(MagnificusMod.Plugin.PluginGuid, "GoobertSequencer", typeof(GoobertSequencer)).Id;
			public override Opponent.Type BossType
			{
				get
				{
					return (Opponent.Type)101;
				}
			}

			public override StoryEvent DefeatedStoryEvent
			{
				get
				{
					return (StoryEvent)1001;
				}
			}

			public override bool RespondsToOtherCardResolve(PlayableCard otherCard)
			{
				return true;
			}

			public override IEnumerator OnOtherCardResolve(PlayableCard otherCard)
			{
				bool flag = otherCard.Info.name == "mag_goobert";
				if (flag)
				{
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("[c:g1]How did you get that?[c:]", -0.65f, 0.4f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
					yield return new WaitForSeconds(0.1f);
				}
				yield break;
			}

			public override bool RespondsToUpkeep(bool playerUpkeep)
			{
				return true;
			}

			public override EncounterData BuildCustomEncounter(CardBattleNodeData nodeData)
			{
				EncounterData encounterData = base.BuildCustomEncounter(nodeData);
				EncounterBlueprintData blueprint = ScriptableObject.CreateInstance<BossBlueprints.GoobertP1Blueprint>();
				if (RunState.Run.regionTier > 1)
				{
					blueprint = ScriptableObject.CreateInstance<BossBlueprints.GoobertP1BlueprintBUFF>();
				}
				encounterData.Blueprint = blueprint;
				encounterData.opponentType = GoobertOpponnent.FullOpponent.Id;
				encounterData.opponentTurnPlan = EncounterBuilder.BuildOpponentTurnPlan(blueprint, 15 + 3, false);
				return encounterData;
			}
		}

		/*
		[HarmonyPatch(typeof(Daus), "StickyNoteSolved")]
		public class ArgLol
		{
			public static bool Prefix(ref Daus __instance, ref bool __result)
			{
				__result = (__instance.CardAtIndex(0, "mag_practicemage") && __instance.CardAtIndex(1, "mag_almondcookie") && __instance.CardAtIndex(2, "Squirrel") && __instance.CardAtIndex(3, "mag_BellMage"));
				return false;
			}
		}

		[HarmonyPatch(typeof(Daus), "OnOtherCardAssignedToSlot")]
		public class ArgLol2
		{
			public static void Prefix(out Daus __state, ref Daus __instance)
			{
				__state = __instance;
			}

			public static IEnumerator Postfix(IEnumerator enumerator, Daus __state)
			{
				AudioController.Instance.PlaySound2D("creepy_rattle_lofi", MixerGroup.None, 0.5f, 0f, null, null, null, null, false);
				__state.StartCoroutine(Singleton<TextDisplayer>.Instance.ShowUntilInput("What was that..?", -2.5f, 0.5f, Emotion.Anger, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true));
				List<CardSlot> slots = Singleton<BoardManager>.Instance.GetSlots(true);
				slots[0].Card.RenderInfo.nameOverride = "see";
				slots[1].Card.RenderInfo.nameOverride = "the";
				slots[2].Card.RenderInfo.nameOverride = "footprints";
				slots[3].Card.RenderInfo.nameOverride = "in the cave?";
				slots.ForEach(delegate (CardSlot x)
				{
					x.Card.RenderCard();
				});
				yield break;
			}
		}
		*/
		public class EspeararaSequencer : Part1BossBattleSequencer
		{
			public static readonly string ID = InscryptionAPI.Encounters.SpecialSequenceManager.Add(MagnificusMod.Plugin.PluginGuid, "EspeararaSequencer", typeof(EspeararaSequencer)).Id;
			public override Opponent.Type BossType
			{
				get
				{
					return (Opponent.Type)102;
				}
			}
			
			public override StoryEvent DefeatedStoryEvent
			{
				get
				{
					return (StoryEvent)1002;
				}
			}


			public override bool RespondsToOtherCardDie(PlayableCard card, CardSlot deathSlot, bool fromCombat, PlayableCard killer)
			{
				return (card.Info.name == "mag_scarecrow" && (deathSlot.Card == null || deathSlot.Card.Dead)) || (card.Info.name == "mag_triplescarecrow" && (deathSlot.Card == null || deathSlot.Card.Dead)) || (card.Info.name == "mag_BOSStrapspear" && (deathSlot.Card == null || deathSlot.Card.Dead));
			}


			public override IEnumerator OnOtherCardDie(PlayableCard card, CardSlot deathSlot, bool fromCombat, PlayableCard killer)
			{
				if (card.Info.name != "mag_BOSStrapspear")
				{
					CardInfo cardByName = CardLoader.GetCardByName("mag_BOSSspear");
					yield return Singleton<BoardManager>.Instance.CreateCardInSlot(cardByName, deathSlot, 0.1f, true);
					yield return new WaitForSeconds(0.25f);
					yield return new WaitForSeconds(0.1f);
					cardByName = null;
				}
				else
				{
					yield return new WaitForSeconds(0.1f);
					Singleton<ViewManager>.Instance.SwitchToView(View.Default);
					yield return Singleton<MagnificusLifeManager>.Instance.ShowLifeLoss(true, 1);
				}
				yield break;
			}

			public override bool RespondsToOtherCardResolve(PlayableCard otherCard)
			{
				return true;
			}

			public override IEnumerator OnOtherCardResolve(PlayableCard otherCard)
			{
				if (otherCard.Info.mods.Count > 0 && otherCard.Info.HasTrait(Trait.EatsWarrens))
				{
					Plugin.switchToSpeakerStyle(1);
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Hah! Using one of my own spells against me?", -0.65f, 0.4f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
					yield return new WaitForSeconds(0.1f);
					Plugin.switchToSpeakerStyle(0);
				}
				yield break;
			}

			public override bool RespondsToUpkeep(bool playerUpkeep)
			{
				return true;
			}

			public override EncounterData BuildCustomEncounter(CardBattleNodeData nodeData)
			{
				EncounterData encounterData = base.BuildCustomEncounter(nodeData);
				EncounterBlueprintData blueprint = ScriptableObject.CreateInstance<BossBlueprints.EspeararaP1Blueprint>();
				if (RunState.Run.regionTier < 1)
				{
					blueprint = ScriptableObject.CreateInstance<BossBlueprints.EspeararaP1BlueprintNERF>();
				}
				else if (RunState.Run.regionTier > 1)
				{
					EncounterData.StartCondition startCondition = new EncounterData.StartCondition();
					startCondition.cardsInOpponentSlots[0] = CardLoader.GetCardByName("mag_BOSSspear");
					encounterData.startConditions.Add(startCondition);
				}
				encounterData.Blueprint = blueprint;
				encounterData.opponentType = EspeararaOpponnent.FullOpponent.Id;
				encounterData.opponentTurnPlan = EncounterBuilder.BuildOpponentTurnPlan(blueprint, 15 + 3, false);
				return encounterData;
			}
		}

		public class LonelyMageSequencer : Part1BossBattleSequencer
		{
			public static readonly string ID = InscryptionAPI.Encounters.SpecialSequenceManager.Add(MagnificusMod.Plugin.PluginGuid, "LonelyMageSequencer", typeof(LonelyMageSequencer)).Id;
			public override Opponent.Type BossType
			{
				get
				{
					return (Opponent.Type)103;
				}
			}

			public static int turnsSinceDeckKill = 0;

			public override StoryEvent DefeatedStoryEvent
			{
				get
				{
					return (StoryEvent)1003;
				}
			}

			public override bool RespondsToTurnEnd(bool playerTurnEnd)
			{
				return !playerTurnEnd && Singleton<LonelyMageOpponnent>.Instance.phase > 1;
			}

			public override IEnumerator OnTurnEnd(bool playerTurnEnd)
			{
				
				yield return new WaitForSeconds(0.75f);
				if (turnsSinceDeckKill % 3 == 0 && turnsSinceDeckKill > 0)
                {
					bool hasEmptySlot = false;
					foreach(CardSlot slot in Singleton<BoardManager>.Instance.OpponentSlotsCopy)
                    {
						if (slot.Card == null) { hasEmptySlot = true; }
                    }
					if (hasEmptySlot)
					{
						Plugin.switchToSpeakerStyle(2);
						yield return shuffleBoard(false);
						Plugin.switchToSpeakerStyle(0);
					}
				}
				turnsSinceDeckKill++;
				base.StartCoroutine(bellTimer());
				yield break;
			}

			public IEnumerator fixCardBacks()
            {
				yield return new WaitForSeconds(0.1f * Singleton<Deck>.Instance.CardsInDeck);
				for (int i = 0; i < GameObject.Find("SelectableCardArray").transform.childCount; i++)
				{
					GameObject.Find("SelectableCardArray").transform.GetChild(i).gameObject.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].mainTexture = Tools.getImage("magcardback.png");
					GameObject.Find("SelectableCardArray").transform.GetChild(i).gameObject.GetComponent<BoxCollider>().size = new Vector3(0, 0, 0);
				}
				yield break;
            }

			public IEnumerator shuffleBoard(bool firstTime = true)
			{
				turnsSinceDeckKill = 0;
				Singleton<ViewManager>.Instance.SwitchToView(View.Default, false, true);
				SelectableCard selectedCard = null;
				float yPos = firstTime ? 2.5f : 75f;
				GameObject.Find("SelectableCardArray").transform.localPosition = new Vector3(-0.72f, 6.685f, 4.059f);
				GameObject.Find("SelectableCardArray").transform.localRotation = Quaternion.Euler(0, 180, 0);
				Tween.LocalPosition(GameObject.Find("SelectableCardArray").transform, new Vector3(-0.72f, yPos, 4.059f), 1.25f, 0f);
				Tween.LocalRotation(GameObject.Find("SelectableCardArray").transform, Quaternion.Euler(70, 0, 0), 0.5f, (0.1f * Singleton<Deck>.Instance.CardsInDeck));
				base.StartCoroutine(fixCardBacks());
				base.StartCoroutine(Singleton<BoardManager>.Instance.CardSelector.SelectCardFrom(Singleton<Deck>.Instance.cards, (Singleton<CardDrawPiles>.Instance as CardDrawPiles3D).Pile, delegate (SelectableCard x)
				{
					selectedCard = x;
				}, null, true));
				float waitTime = firstTime ? 1.5f : 0.25f;
				yield return new WaitForSeconds((0.1f * Singleton<Deck>.Instance.CardsInDeck) + waitTime);
				//Tween.LocalRotation(GameObject.Find("SelectableCardArray").transform, Quaternion.Euler(0, 0, 0), 0.5f, 0f);
				selectedCard = GameObject.Find("SelectableCardArray").transform.GetChild(Random.RandomRangeInt(0, Singleton<Deck>.Instance.CardsInDeck)).gameObject.GetComponentInChildren<SelectableCard>();
				Vector3 selectedCardPos = firstTime ? selectedCard.transform.position : new Vector3(GameObject.Find("SelectableCardArray").transform.position.x, 2.5f, GameObject.Find("SelectableCardArray").transform.transform.position.z);
				Tween.Position(selectedCard.transform, selectedCardPos + Vector3.back * -2f, 0.5f, 0f, Tween.EaseIn, Tween.LoopType.None, null, null, true);
				selectedCard.transform.parent = Singleton<BoardManager>.Instance.transform;
				if (firstTime) { Tween.LocalPosition(GameObject.Find("SelectableCardArray").transform, new Vector3(-0.72f, -75f, 4.059f), 5f, 0.4f);  
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("WOW! COOL CARD!!", 0f, 0f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null); }
				//GameObject.Destroy(GameObject.Find("SelectableCardArray"));
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("FINDERS KEEPERS!", 0f, 0f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
				UnityEngine.Object.Destroy(selectedCard.gameObject, 0.1f);
				int emptySlot = -1;
				foreach(CardSlot slot in Singleton<BoardManager>.Instance.OpponentSlotsCopy)
                {
					if (slot.Card == null)
                    {
						emptySlot = slot.Index;
						break;
                    }
                }
				CardInfo urCard = selectedCard.Info;
				CardModificationInfo tempMod = new CardModificationInfo();
				tempMod.singletonId = "DECKCARD";
				if (emptySlot < 0)
				{
					bool isDeckCard = false;
					foreach (CardModificationInfo mod in Singleton<BoardManager>.Instance.OpponentSlotsCopy[emptySlot].Card.TemporaryMods)
					{
						if (mod.singletonId == null) { continue; }
						if (mod.singletonId == "DECKCARD")
						{
							isDeckCard = true;
						}
					}
					int slot = isDeckCard ? 3 : 0;
					yield return Singleton<BoardManager>.Instance.opponentSlots[slot].Card.Die(false);
					yield return Singleton<BoardManager>.Instance.CreateCardInSlot(urCard, Singleton<BoardManager>.Instance.OpponentSlotsCopy[slot], 0.1f, true);
					Singleton<BoardManager>.Instance.OpponentSlotsCopy[slot].Card.AddTemporaryMod(tempMod);
				} else
                {
					yield return Singleton<BoardManager>.Instance.CreateCardInSlot(urCard, Singleton<BoardManager>.Instance.OpponentSlotsCopy[emptySlot], 0.1f, true);
					Singleton<BoardManager>.Instance.OpponentSlotsCopy[emptySlot].Card.AddTemporaryMod(tempMod);
				}
				if ((Singleton<CardDrawPiles>.Instance as CardDrawPiles3D).Pile != null)
				{
					Singleton<Deck>.Instance.cards.Remove(urCard);
					base.StartCoroutine((Singleton<CardDrawPiles>.Instance as CardDrawPiles3D).Pile.SpawnCards(Singleton<Deck>.Instance.cards.Count, 1f));
				}
				yield break;
			}

			public static IEnumerator bellTimer()
            {
				while (Singleton<TurnManager>.Instance.PlayerPhase != TurnManager.PlayerTurnPhase.Main)
				{
					yield return new WaitForSeconds(0.25f);
				}
				if (GameObject.Find("BellTime") is null)
                {
					GameObject BellTimer = GameObject.Instantiate(GameObject.Find("PlayerLife"));
					BellTimer.name = "BellTime";
					BellTimer.transform.parent = GameObject.Find("PlayerLife").transform.parent;
					BellTimer.transform.localScale = new Vector3(0.3f, 0.25f, 0.25f);
					BellTimer.transform.localPosition = new Vector3(-2.25f, 22.575f, 18.3f);
					BellTimer.transform.GetChild(1).gameObject.SetActive(false);
					BellTimer.transform.GetChild(2).gameObject.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 1, 1);
				}
				for (int i = 0; i < 8; i++)
                {
					GameObject.Find("BellTime").GetComponent<LifeTotalCounter3D>().ShowValue(8 - i);
					yield return new WaitForSeconds(1f);
					if (!Singleton<TurnManager>.Instance.IsPlayerTurn)
					{
						yield break;
					}
					if (!Singleton<CombatBell>.Instance.Pressable)
                    {
						i -= 1;
					}
				}
				GameObject.Find("BellTime").GetComponent<LifeTotalCounter3D>().ShowValue(0);
				if (Singleton<CombatBell>.Instance.Pressable && Singleton<TurnManager>.Instance.IsPlayerTurn)
				{
					Singleton<CombatBell>.Instance.OnCursorSelectStart();
					if (!Singleton<LonelyMageOpponnent>.Instance.TurnTimerDialogue)
					{
						Singleton<LonelyMageOpponnent>.Instance.TurnTimerDialogue = true;
						Plugin.switchToSpeakerStyle(2);
						yield return new WaitForSeconds(0.5f);
						yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("I'M GROWING IMPATIENT!\nI NEED MORE STIMULATION!!", -0.65f, 0.4f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
						Plugin.switchToSpeakerStyle(0);
					}
				}
				yield break;
            }

			public override bool RespondsToOtherCardResolve(PlayableCard otherCard)
			{
				return true;
			}

			public override IEnumerator OnOtherCardResolve(PlayableCard otherCard)
			{
				bool flag = otherCard.Info.name == "mag_lonelymage";
				if (flag)
				{
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("[c:g3]STIMULATION!!!!!![c:]", -0.65f, 0.4f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
					yield return new WaitForSeconds(0.1f);
				}
				yield break;
			}

			public override bool RespondsToOtherCardDie(PlayableCard card, CardSlot deathSlot, bool fromCombat, PlayableCard killer)
			{
				bool isDeckCard = false;
				if (deathSlot != null)
                {
					if (deathSlot.IsPlayerSlot) { return false; }
					foreach(CardModificationInfo mod in card.TemporaryMods)
                    {
						if (mod.singletonId == null) { continue; }
						if (mod.singletonId == "DECKCARD")
                        {
							isDeckCard = true;
						}
                    }
                }
				return isDeckCard && (deathSlot.Card == null || deathSlot.Card.Dead);
			}

			public override IEnumerator OnOtherCardDie(PlayableCard card, CardSlot deathSlot, bool fromCombat, PlayableCard killer)
			{
				yield return new WaitForSeconds(0.2f);
				yield return Singleton<CardSpawner>.Instance.SpawnCardToHand(card.Info, 0.25f);
				yield return new WaitForSeconds(0.45f);
				yield break;
			}

			public override bool RespondsToUpkeep(bool playerUpkeep)
			{
				return true;
			}

			public override EncounterData BuildCustomEncounter(CardBattleNodeData nodeData)
			{
				EncounterData encounterData = base.BuildCustomEncounter(nodeData);
				EncounterBlueprintData blueprint = ScriptableObject.CreateInstance<BossBlueprints.LonelyMageP1Blueprint>();
				if (RunState.Run.regionTier > 0)
				{
					EncounterData.StartCondition startCondition = new EncounterData.StartCondition();
					startCondition.cardsInOpponentSlots[3] = CardLoader.GetCardByName("mag_stimmage");
					encounterData.startConditions.Add(startCondition);
				}
				else
				{
					blueprint = ScriptableObject.CreateInstance<BossBlueprints.LonelyMageP1BlueprintNERF>();
				}
				encounterData.Blueprint = blueprint;
				encounterData.opponentTurnPlan = EncounterBuilder.BuildOpponentTurnPlan(blueprint, 15 + 3, false);
				encounterData.opponentType = LonelyMageOpponnent.FullOpponent.Id;
				return encounterData;
			}
		}

		public class MagnificusSequencer : Part1BossBattleSequencer
		{
			public static readonly string ID = InscryptionAPI.Encounters.SpecialSequenceManager.Add(MagnificusMod.Plugin.PluginGuid, "MagnificusSequencer", typeof(MagnificusSequencer)).Id;
			public override Opponent.Type BossType
			{
				get
				{
					return (Opponent.Type)104;
				}
			}

			public override StoryEvent DefeatedStoryEvent
			{
				get
				{
					return (StoryEvent)1004;
				}
			}

			/*
			public override bool RespondsToOtherCardDrawn(PlayableCard card)
			{
				return card != null;
			}

			public override IEnumerator OnOtherCardDrawn(PlayableCard card)
			{
				bool flag = !card.Info.HasTrait(Trait.Gem);
				if (flag)
				{
					AudioController.Instance.PlaySound2D("magnificus_brush_splatter_bleach", MixerGroup.None, 0.5f, 0f, null, null, null, null, false);
					List<Ability> none = new List<Ability>();
					CardModificationInfo negateMod = new CardModificationInfo();
					CardInfo cardInfo = card.Info.Clone() as CardInfo;
					bool flag2 = card.Info.name != "!DEATHCARD_BASE";
					if (flag2)
					{
						bool flag3 = card.Info.ModAbilities.Count > 0;
						if (flag3)
						{
							cardInfo = CardLoader.GetCardByName(card.Info.name);
						}
						foreach (CardModificationInfo mod in card.Info.mods)
						{
							bool flag4 = mod.abilities.Count < 1;
							if (flag4)
							{
								cardInfo.mods.Add(mod);
							}
						}
						List<CardModificationInfo>.Enumerator enumerator = default(List<CardModificationInfo>.Enumerator);
						negateMod.negateAbilities = card.Info.Abilities;
						cardInfo.Mods.Add(negateMod);
						card.SetInfo(cardInfo);
					}
					else
					{
						foreach (CardModificationInfo mod2 in card.Info.mods)
						{
							mod2.abilities = new List<Ability>();
						}
						List<CardModificationInfo>.Enumerator enumerator2 = default(List<CardModificationInfo>.Enumerator);
					}
					yield return new WaitForSeconds(0.5f);
					AudioController.Instance.PlaySound2D("magnificus_brush_splatter_color", MixerGroup.None, 0.5f, 0f, null, null, null, null, false);
					List<Ability> ability = new List<Ability>
					{
						Ability.DrawRabbits,
						Ability.GemDependant,
						Ability.SplitStrike,
						SigilCode.GemGuardianFix.ability,
						SigilCode.GemAbsorber.ability,
						Ability.BuffGems,
						Ability.BuffNeighbours,
						Ability.Sharp,
						SigilCode.BlueMageDraw.ability,
						SigilCode.MagDropRubyOnDeath.ability,
						SigilCode.MagDropEmeraldOnDeath.ability,
						SigilCode.LifeUpOmega.ability,
						Ability.GemDependant,
						Ability.Reach,
						Ability.QuadrupleBones,
						SigilCode.RandomPower.ability,
						Ability.MoveBeside
					};
					Ability randomAbility = ability[UnityEngine.Random.Range(0, ability.Count)];
					CardModificationInfo cardModificationInfo = new CardModificationInfo(randomAbility);
					card.AddTemporaryMod(cardModificationInfo);
					(Singleton<PlayerHand>.Instance as PlayerHand3D).MoveCardAboveHand(card);
				}
				yield break;
			}
			*/
			/*public override bool RespondsToOtherCardDie(PlayableCard card, CardSlot deathSlot, bool fromCombat, PlayableCard killer)
			{
				return (card.Info.name == "mag_BOSSmagnusmox" && fromCombat && (deathSlot.Card == null || deathSlot.Card.Dead));
			}

			public override IEnumerator OnOtherCardDie(PlayableCard card, CardSlot deathSlot, bool fromCombat, PlayableCard killer)
			{
				if (card.Info.name == "mag_BOSSmagnusmox")
                {
					yield return GameObject.Find("TextDisplayer").GetComponent<TextDisplayer>().ShowUntilInput("Impressive. You managed to destroy that mox.", -0.65f, 0.4f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Goo, null, true);
				}
				yield break;
			}*/

			public override bool RespondsToOtherCardResolve(PlayableCard otherCard)
			{
				return !otherCard.slot.IsPlayerSlot && Singleton<MagnificusOpponnent>.Instance.NumLives <= 2 && !otherCard.HasTrait(Trait.Giant) || otherCard.slot.IsPlayerSlot && (otherCard.HasAbility(Ability.EdaxioHead) || otherCard.HasAbility(Ability.EdaxioArms) || otherCard.HasAbility(Ability.EdaxioLegs) || otherCard.HasAbility(Ability.EdaxioTorso));
			}

			public override IEnumerator OnOtherCardResolve(PlayableCard otherCard)
			{
				if (!otherCard.slot.IsPlayerSlot)
				{
					CardModificationInfo tempMod = new CardModificationInfo();
					if (Singleton<MagnificusOpponnent>.Instance.BuffedAtkSlots.Contains(otherCard.slot))
					{
						tempMod.attackAdjustment = 1;
						otherCard.renderInfo.attackTextColor = new Color(0.41f, 1f, 0.62f, 1f);
					}
					else if (Singleton<MagnificusOpponnent>.Instance.BuffedHpSlots.Contains(otherCard.slot))
					{
						tempMod.healthAdjustment = 2;
						otherCard.renderInfo.healthTextColor = new Color(1f, 0.24f, 0.435f, 1f);
					}
					otherCard.AddTemporaryMod(tempMod);
				} else//spaghetti
                {
					if (otherCard.HasAbility(Ability.EdaxioLegs))
                    {
						otherCard.renderInfo.nameOverride = "Free Legs";
						foreach(CardSlot slot in Singleton<BoardManager>.Instance.PlayerSlotsCopy)
                        {
							if (slot.Card != null && slot.Card.HasAnyOfAbilities(Ability.EdaxioArms, Ability.EdaxioHead, Ability.EdaxioTorso))
                            {
								CardModificationInfo tempMod = new CardModificationInfo();
								tempMod.attackAdjustment = 3;
								slot.Card.AddTemporaryMod(tempMod);
							}
                        }
						yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Just what do you think you're doing?", 1.5f, 0.4f, Emotion.Curious, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
					} else if (otherCard.HasAbility(Ability.EdaxioTorso))
					{
						otherCard.renderInfo.nameOverride = "Unsealed Body";
						foreach (CardSlot slot in Singleton<BoardManager>.Instance.PlayerSlotsCopy)
						{
							if (slot.Card != null && slot.Card.HasAnyOfAbilities(Ability.EdaxioArms, Ability.EdaxioHead, Ability.EdaxioLegs))
							{
								CardModificationInfo tempMod = new CardModificationInfo();
								tempMod.healthAdjustment = 5;
								slot.Card.AddTemporaryMod(tempMod);
							}
						}
						yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Do not.", 1.5f, 0.4f, Emotion.Anger, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
					}
					else if (otherCard.HasAbility(Ability.EdaxioArms))
					{
						otherCard.renderInfo.nameOverride = "Released Arms";
						foreach (CardSlot slot in Singleton<BoardManager>.Instance.PlayerSlotsCopy)
						{
							if (slot.Card != null && slot.Card.HasAnyOfAbilities(Ability.EdaxioTorso, Ability.EdaxioHead, Ability.EdaxioLegs))
							{
								CardModificationInfo tempMod = new CardModificationInfo();
								tempMod.healthAdjustment = 2;
								tempMod.attackAdjustment = 1;
								slot.Card.AddTemporaryMod(tempMod);
							}
						}
						yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Trying to pull a trick as dirty as that..", 1.5f, 0.4f, Emotion.Quiet, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
					}
					else if (otherCard.HasAbility(Ability.EdaxioHead))
					{
						otherCard.renderInfo.nameOverride = "Unleashed Tyrant";
						foreach (CardSlot slot in Singleton<BoardManager>.Instance.PlayerSlotsCopy)
						{
							if (slot.Card != null && slot.Card.HasAbility(Ability.EdaxioArms))
							{
								CardModificationInfo tempMod = new CardModificationInfo();
								tempMod.abilities = new List<Ability> { Ability.DoubleStrike };
								slot.Card.AddTemporaryMod(tempMod);
							} else if (slot.Card != null && slot.Card.HasAbility(Ability.EdaxioTorso))
							{
								CardModificationInfo tempMod = new CardModificationInfo();
								tempMod.abilities = new List<Ability> { Ability.DeathShield };
								slot.Card.AddTemporaryMod(tempMod);
							}
							else if (slot.Card != null && slot.Card.HasAbility(Ability.EdaxioLegs))
							{
								CardModificationInfo tempMod = new CardModificationInfo();
								tempMod.abilities = new List<Ability> { Ability.GainAttackOnKill };
								slot.Card.AddTemporaryMod(tempMod);
							}
						}
						yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("...", 1.5f, 0.4f, Emotion.Quiet, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
					}
					bool hasArms = !otherCard.HasAbility(Ability.EdaxioArms) && Singleton<BoardManager>.Instance.GetSlots(true).Find((CardSlot x) => x.Card != null && x.Card.Info.HasAbility(Ability.EdaxioArms)) != null;
					bool hasLegs = !otherCard.HasAbility(Ability.EdaxioLegs) && Singleton<BoardManager>.Instance.GetSlots(true).Find((CardSlot x) => x.Card != null && x.Card.Info.HasAbility(Ability.EdaxioLegs)) != null;
					bool hasTorso = !otherCard.HasAbility(Ability.EdaxioTorso) && Singleton<BoardManager>.Instance.GetSlots(true).Find((CardSlot x) => x.Card != null && x.Card.Info.HasAbility(Ability.EdaxioTorso)) != null;
					bool hasHead = !otherCard.HasAbility(Ability.EdaxioHead) && Singleton<BoardManager>.Instance.GetSlots(true).Find((CardSlot x) => x.Card != null && x.Card.Info.HasAbility(Ability.EdaxioHead)) != null;
					bool hasEdaxio = false;
					if (hasArms)
                    {
						CardModificationInfo tempMod = new CardModificationInfo();
						tempMod.attackAdjustment = 1;
						tempMod.healthAdjustment = 1;
						otherCard.AddTemporaryMod(tempMod);
						if (hasLegs && hasTorso && hasHead) { hasEdaxio = true; }
					}
					if (hasLegs)
					{
						CardModificationInfo tempMod = new CardModificationInfo();
						tempMod.attackAdjustment = 2;
						otherCard.AddTemporaryMod(tempMod);
						if (hasArms && hasTorso && hasHead) { hasEdaxio = true; }
					}
					if (hasTorso)
					{
						CardModificationInfo tempMod = new CardModificationInfo();
						tempMod.healthAdjustment = 3;
						otherCard.AddTemporaryMod(tempMod);
						if (hasLegs && hasArms && hasHead) { hasEdaxio = true; }
					}
					if (hasHead)
					{
						if (otherCard.HasAbility(Ability.EdaxioArms))
						{
							CardModificationInfo tempMod = new CardModificationInfo();
							tempMod.abilities = new List<Ability> { Ability.DoubleStrike };
							otherCard.AddTemporaryMod(tempMod);
						}
						else if (otherCard.HasAbility(Ability.EdaxioTorso))
						{
							CardModificationInfo tempMod = new CardModificationInfo();
							tempMod.abilities = new List<Ability> { Ability.DeathShield };
							otherCard.AddTemporaryMod(tempMod);
						}
						else if (otherCard.HasAbility(Ability.EdaxioLegs))
						{
							CardModificationInfo tempMod = new CardModificationInfo();
							tempMod.abilities = new List<Ability> { Ability.GainAttackOnKill };
							otherCard.AddTemporaryMod(tempMod);
						}
						if (hasLegs && hasTorso && hasArms) { hasEdaxio = true; }
					}
					List<CardSlot> list = Singleton<BoardManager>.Instance.GetSlots(true);
					string slotName = "PlayerSlots";
					foreach (CardSlot slot in list)
					{
						if (slot.Card != null && slot.Card.Info != otherCard.Info)
						{
							int dex;
							dex = slot.Index;
							if (GameObject.Find(slotName).transform.GetChild(dex).childCount > 6)
							{
								GameObject model = GameObject.Find(slotName).transform.GetChild(dex).GetChild(5).gameObject;
								model.GetComponent<Card>().RenderCard();
							}
						}
					}
					if (hasEdaxio && Singleton<MagnificusOpponnent>.Instance.NumLives < 2)
                    {
						yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Unfortunately though.. you are already too late.", 1.5f, 0.4f, Emotion.Laughter, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
						yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("That trick wont do anything against me now.", 1.5f, 0.4f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
						planets = new List<string> { "mag_neptune", "mag_mercury", "mag_jupiter", "mag_saturn" };
						killedPlanets = 0;
					}
				}
				yield break;
			}

			public override bool RespondsToOtherCardDie(PlayableCard card, CardSlot deathSlot, bool fromCombat, PlayableCard killer)
			{
				return card.Info.name == "mag_giantmoon" && (deathSlot.Card == null || deathSlot.Card.Dead) || card.Info.name == "mag_giantearth" && (deathSlot.Card == null || deathSlot.Card.Dead) || Singleton<MagnificusOpponnent>.Instance.NumLives < 2 && killedPlanets < 2 && killedPlanets >= 0 && !deathSlot.IsPlayerSlot;
			}

			public static List<string> planets = new List<string> { "mag_neptune", "mag_mercury" };
			public int killedPlanets = -1;

			public override IEnumerator OnOtherCardDie(PlayableCard card, CardSlot deathSlot, bool fromCombat, PlayableCard killer)
			{
				if (card.Info.name == "mag_giantmoon")
				{
					yield return new WaitForSeconds(0.2f);
					planets = new List<string> { "mag_neptune", "mag_mercury", "mag_jupiter", "mag_saturn" };
					killedPlanets = 0;
					yield return Singleton<BoardManager>.Instance.CreateCardInSlot(CardLoader.GetCardByName("mag_giantmoonshards"), Singleton<BoardManager>.Instance.OpponentSlotsCopy[0], 0.1f, true);
					yield return Singleton<BoardManager>.Instance.CreateCardInSlot(CardLoader.GetCardByName("mag_giantmoonshards2"), Singleton<BoardManager>.Instance.OpponentSlotsCopy[3], 0.1f, true);
					Singleton<BoardManager>.Instance.OpponentSlotsCopy[3].Card.renderInfo.flippedPortrait = true;
					Singleton<ViewManager>.Instance.SwitchToView(View.OpponentQueue, false, true);
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("I could never allow myself to go down that easily.", 1.5f, 0.4f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
					yield return Singleton<BoardManager>.Instance.CreateCardInSlot(CardLoader.GetCardByName("mag_venus"), Singleton<BoardManager>.Instance.OpponentSlotsCopy[1], 0.1f, true);
					yield return Singleton<BoardManager>.Instance.CreateCardInSlot(CardLoader.GetCardByName("mag_mars"), Singleton<BoardManager>.Instance.OpponentSlotsCopy[2], 0.1f, true);
					yield return new WaitForSeconds(1.5f);
					Singleton<ViewController>.Instance.LockState = ViewLockState.Unlocked;
					Singleton<ViewManager>.Instance.SwitchToView(View.Default, false, false);
					yield return new WaitForSeconds(0.25f);
					yield return new WaitForSeconds(0.1f);
				} else if (card.Info.name != "mag_giantearth")
                {
					yield return new WaitForSeconds(0.2f);
					int planetId = UnityEngine.Random.RandomRangeInt(0, planets.Count);
					killedPlanets++;
					yield return Singleton<BoardManager>.Instance.CreateCardInSlot(CardLoader.GetCardByName(planets[planetId]), deathSlot, 0.1f, true);
					planets.RemoveAt(planetId);
					yield return new WaitForSeconds(0.25f);
				} else
                {
					AudioController.Instance.StopAllLoops();
					Singleton<ViewManager>.Instance.SwitchToView(View.Default, false, true);
					yield return new WaitForSeconds(0.5f);
					GameObject ruins = GameObject.Find("Ruins");
					ruins.GetComponent<SineWaveMovement>().enabled = false;
					ruins.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
					ruins.transform.position = new Vector3(80.575f, 8.6187f, 34.8342f);
					ruins.transform.localRotation = Quaternion.Euler(5f, 69f, 0);
					GameObject MagnificusColum = GameObject.Find("MarbleColumn_Opponent");
					GameObject Magnificus = GameObject.Find("MagnificusAnim");
					Magnificus.transform.parent = MagnificusColum.transform;
					Tween.Rotation(MagnificusColum.transform, Quaternion.Euler(15, 21, 12), 3f, 0);
					Tween.Position(MagnificusColum.transform, new Vector3(80.5f, -32, 52), 15, 0);
					Tween.Rotation(Singleton<MagnificusLifeManager>.Instance.gameObject.transform, Quaternion.Euler(25, 12, 52), 3.5f, 0);
					Tween.LocalPosition(Singleton<MagnificusLifeManager>.Instance.gameObject.transform, new Vector3(40f, -32f, -6), 15, 0);
					GameObject.Find("bossPainting").GetComponent<SineWaveMovement>().enabled = false;
					Tween.Position(GameObject.Find("bossPainting").transform, new Vector3(44.5f, 18.6f, -33.5f), 9f, 0);
					Tween.Position(GameObject.Find("CombatBell_Magnificus").transform, new Vector3(-9.95f, 21.25f, 6.4f), 6f, 0);
					Tween.Position(Singleton<MagnificusDuelDisk>.Instance.gameObject.transform, new Vector3(0.89f, -15.5f, -4.85f), 4f, 0);
					GameObject.Find("CardBattle_Magnificus").transform.Find("Hand").position = new Vector3(0, -900, 0);
					Tween.Rotation(GameObject.Find("tbPillar").transform, Quaternion.Euler(5.2f, 4.3f, 7.5f), 1.25f, 0);
					Tween.Position(GameObject.Find("tbPillar").transform, new Vector3(80f, -5.3f, -13.5f), 9f, 0);
					Tween.Position(GameObject.Find("3DPortraitSlots").transform, new Vector3(80f, -3.1383f, -14f), 9f, 0);
					Tween.LocalRotation(GameObject.Find("Player").transform, Quaternion.Euler(3.8f, 4.7f, -7.35f), 2f, 0.1f);
					Tween.Position(GameObject.Find("Player").transform, new Vector3(112.2f, 22f, -32f), 60f, 0);
					GameObject.Find("crates").transform.position = new Vector3(104.76f, 13.85f, 47.85f);
					GameObject.Find("swordModel").transform.rotation = Quaternion.Euler(55f, 12.3f, 10.82f);
					GameObject.Find("swordModel").transform.position = new Vector3(26.9f, 13.85f, 41f);
					GameObject.Find("floatingBook").transform.position = new Vector3(84.7f, 18.14f, 112.5f);
					GameObject.Find("PikeModel").transform.position = new Vector3(125.3f, 37.3f, 58);
					GameObject.Find("PikeModel").transform.rotation = Quaternion.Euler(350.8f, 354.2f, 90);
					GameObject.Find("cloth3D").transform.position = new Vector3(80.575f, 41.8f, 28.25f);
					GameObject.Find("cloth3D").transform.rotation = Quaternion.Euler(0, 90, 0);
					GameObject.Find("cloth3D").transform.localScale = new Vector3(1, 1, 1);
					GameObject.Find("easel").transform.position = new Vector3(106, 13.85f, -9.3f);
					GameObject.Find("easel").transform.Find("Easel").Find("EaselAnim").GetChild(3).gameObject.GetComponent<BoxCollider>().size = new Vector3(0, 0, 0);
					GameObject.Find("easel").transform.Find("Easel").Find("EaselAnim").GetChild(3).Find("Quad").Find("CardBase").Find("RenderStatsLayer").Find("BendableCard").Find("Mesh").gameObject.GetComponent<SkinnedMeshRenderer>().materials[0].mainTexture = Tools.getImage("magcardbackground.png");
					GameObject.Find("easel").transform.Find("Easel").Find("EaselAnim").GetChild(3).Find("Quad").Find("CardBase").Find("RenderStatsLayer").Find("BendableCard").Find("Mesh").gameObject.GetComponent<SkinnedMeshRenderer>().materials[1].mainTexture = Tools.getImage("magcardback.png");
					GameObject.Find("MagnificusEnvironment").transform.Find("gooBottle").gameObject.SetActive(true);
					GameObject.Find("MagnificusEnvironment").transform.Find("gooBottle").position = new Vector3(112.6f, 13.85f, -17.57f);
					base.StartCoroutine(Singleton<TextDisplayer>.Instance.ShowUntilInput(".. I may have not thought this through..", 1.5f, 0.4f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true));
					yield return new WaitForSeconds(60f);
					Singleton<TextDisplayer>.Instance.Clear();
					GameObject newGame = Instantiate(Resources.Load("prefabs/environment/sanctum/NewGameCard_Sanctum") as GameObject);
					newGame.name = "newGameCard";
					newGame.transform.position = new Vector3(112.2f, 37f, -27.8f);
					newGame.transform.localRotation = Quaternion.Euler(0, 0, 0);
					newGame.transform.Find("RectangleParticles").gameObject.SetActive(false);
					newGame.AddComponent<BoxCollider>().size = new Vector3(0.5f, 0.75f, 2);
					newGame.AddComponent<MainInputInteractable>().CursorSelectStarted = (Action<MainInputInteractable>)Delegate.Combine(newGame.AddComponent<MainInputInteractable>().CursorSelectStarted, new Action<MainInputInteractable>(delegate (MainInputInteractable i)
					{
						StoryEventsData.SetEventCompleted(StoryEvent.StartScreenNewGameUnlocked, true, false);
						newGame.GetComponent<BoxCollider>().size = new Vector3(0, 0, 0);
						AudioController.Instance.PlaySound3D("newgame_card_taken", MixerGroup.ExplorationSFX, newGame.transform.position, 1f, 0f, null, null, null, null, false);
						newGame.transform.Find("RectangleParticles").gameObject.SetActive(true);
						SaveManager.SaveToFile();
					}));
					Tween.Position(newGame.transform, new Vector3(112.2f, 28.5f, -27.8127f), 5f, 0);
					while (true)
                    {
						if (newGame.transform.Find("RectangleParticles").gameObject.activeSelf)
                        {
							yield return new WaitForSeconds(0.5f);
							newGame.SetActive(false);
                        }
						yield return new WaitForSeconds(1f);
                    }
				}
				yield break;
			}

			public override EncounterData BuildCustomEncounter(CardBattleNodeData nodeData)
			{
				EncounterData encounterData = base.BuildCustomEncounter(nodeData);
				EncounterBlueprintData blueprint = ScriptableObject.CreateInstance<BossBlueprints.MagnificusP1Blueprint>();
				encounterData.Blueprint = blueprint;
				encounterData.opponentTurnPlan = EncounterBuilder.BuildOpponentTurnPlan(blueprint, 15 + 3, false);
				encounterData.opponentType = MagnificusOpponnent.FullOpponent.Id;
				EncounterData.StartCondition startCondition = new EncounterData.StartCondition();
				startCondition.cardsInOpponentSlots[0] = CardLoader.GetCardByName("mag_BOSSmagnusmox");
				encounterData.startConditions.Add(startCondition);
				return encounterData;
			}
		}

		[HarmonyPatch(typeof(CardSpawner), "SpawnPlayableCard")]
		public class FixGiantCard
		{
			public static bool Prefix(ref PlayableCard __result, CardInfo info)
			{
				GameObject gameObject;
				if (info.HasTrait(Trait.Giant) && SceneLoader.ActiveSceneName != "finale_magnificus")
				{
					gameObject = GameObject.Instantiate<GameObject>(Singleton<CardSpawner>.Instance.GiantPlayableCardPrefab);
				}
				else
				{
					gameObject = GameObject.Instantiate<GameObject>(Singleton<CardSpawner>.Instance.PlayableCardPrefab);
				}
				PlayableCard component = gameObject.GetComponent<PlayableCard>();
				component.SetInfo(info);
				__result = component;
				return false;
			}
		}
	}
}
