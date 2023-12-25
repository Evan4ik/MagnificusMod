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
    class LifeFixes
    {
		[HarmonyPatch(typeof(MagnificusLifeManager), "Initialize")]
		public class fixLifeManager
		{
			public static void Prefix(out MagnificusLifeManager __state, ref MagnificusLifeManager __instance)
			{
				__state = __instance;
			}
			public static IEnumerator Postfix(IEnumerator enumerator, MagnificusLifeManager __state)
			{
				Singleton<ViewManager>.Instance.SwitchToView(View.Default, false, true);
				Generation.didDyingBreath = false;
				yield return new WaitForSeconds(0.2f);
				__state.playerLifeCounter.gameObject.SetActive(true);
				__state.opponentLifeCounter.gameObject.SetActive(true);
				__state.playerLife = 10;
				__state.opponentLife = 10;
				__state.playerLifeCounter.ShowValue(10);
				__state.opponentLifeCounter.ShowValue(10);
				if (SaveManager.saveFile.ascensionActive && MagnificusMod.Generation.challenges.Contains("MoreHpOpponent"))
				{
					ChallengeActivationUI.TryShowActivation(KayceeFixes.ChallengeManagement.MoreHpOpponent);
					__state.opponentLife = 15;
					__state.opponentLifeCounter.ShowValue(15);
				}
				if (SaveManager.saveFile.ascensionActive && MagnificusMod.Generation.challenges.Contains("FadingMox"))
                {
					ChallengeActivationUI.TryShowActivation(KayceeFixes.ChallengeManagement.FadingMox);
					__state.playerLife = KayceeStorage.FleetingLife;
					__state.playerLifeCounter.ShowValue(KayceeStorage.FleetingLife);
				}
				__state.opponentLifeCounter.transform.localPosition = new Vector3(12.5f, 20, 46);
				__state.transform.localPosition = new Vector3(0, 0, 0);
				Vector3 position = __state.transform.position;
				__state.transform.position += Vector3.up * 30f;
				position -= new Vector3(0, 13, 0);
				Tween.Position(__state.transform, position, 5f, 0f, Tween.EaseOutStrong, Tween.LoopType.None, null, null, true);
				Tween.Shake(__state.playerLifeCounter.transform, __state.playerLifeCounter.transform.localPosition, Vector3.one * 0.05f, 5f, 0f, Tween.LoopType.None, null, null, true);
				Tween.Shake(__state.opponentLifeCounter.transform, __state.opponentLifeCounter.transform.localPosition, Vector3.one * 0.05f, 5f, 0f, Tween.LoopType.None, null, null, true);
				yield return new WaitForSeconds(3.5f);
				if (!SavedVars.LearnedMechanics.Contains("liferace;") && !SaveManager.saveFile.ascensionActive)
				{
					SavedVars.LearnedMechanics += "liferace;";
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("You are a simpleton for expecting scales.", -1f, 0.6f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("This is a simple race to 0.", -1f, 0.6f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
					yield return new WaitForSeconds(1.5f);
					Tween.Position(GameObject.Find("Hand").transform, new Vector3(GameObject.Find("GameTable").transform.position.x + 1f, 12.75f, GameObject.Find("GameTable").transform.position.z - 5.1f), 0.6f, 0f, Tween.EaseInOut, Tween.LoopType.None, null, null, true);
					Singleton<ViewManager>.Instance.SwitchToView(View.Default);
				}
				Singleton<ViewManager>.Instance.Controller.LockState = ViewLockState.Unlocked;
				MagnificusMod.Plugin.spellsPlayed = 0;
				Singleton<ViewController>.Instance.SwitchToControlMode(ViewController.ControlMode.WizardBattleDefault);
				yield break;
			}
		}

		[HarmonyPatch(typeof(LifeTotalCounter3D), "ShowValue")]
		public class fixLifeManager2
		{
			public static bool Prefix(ref LifeTotalCounter3D __instance, ref int value, bool immediate = true)
			{
				value = Mathf.Clamp(value, 0, 999);
				int num = value / 100;
				int num2 = (value - num * 100) / 10;
				int index = value - num * 100 - num2 * 10;
				__instance.numerals[0].transform.gameObject.SetActive(true);
				__instance.numerals[0].mesh = __instance.numeralMeshes[num];
				__instance.numerals[0].transform.gameObject.SetActive(false);
				__instance.numerals[1].mesh = __instance.numeralMeshes[num2];
				__instance.numerals[2].mesh = __instance.numeralMeshes[index];
				if (!immediate)
				{
					Tween.Cancel(__instance.transform.GetInstanceID());
					Tween.Shake(__instance.transform, __instance.transform.localPosition, Vector3.one * 0.075f, 0.5f, 0f, Tween.LoopType.None, null, null, true);
					AudioController.Instance.PlaySound3D("stone_object_hit", MixerGroup.TableObjectsSFX, __instance.transform.position, 1f, 0f, new AudioParams.Pitch(AudioParams.Pitch.Variation.Small), null, new AudioParams.Randomization(false), null, false).spatialBlend = 0.05f;
				}
				return false;
			}
		}
	}
}
