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
    class ManaFixes
    {
		[HarmonyPatch(typeof(WeightUtil), "WeightPrefab", MethodType.Getter)]
		public class MANASCALES
		{
			public static void Prefix()
			{
				WeightUtil.part1Prefab = ResourceBank.Get<GameObject>("Prefabs/Environment/ScaleWeights/Weight");
				if (SceneLoader.ActiveSceneName == "finale_magnificus")
				{
					WeightUtil.part1Prefab = ResourceBank.Get<GameObject>("Prefabs/Environment/ScaleWeights/Weight");

					bool flag2 = GameObject.Find("mana") == null;
					GameObject gameObject;
					if (flag2)
					{
						GameObject.Instantiate(Resources.Load("prefabs/finalemagnificus/Wizard3DPortrait_MoxRuby")).name = "rox";
						gameObject = GameObject.Find("rox").transform.Find("SineWaveMove").Find("Anim").Find("Gem").gameObject;
						gameObject.transform.parent = GameObject.Find("MagnificusEnvironment").transform;
						GameObject.Destroy(GameObject.Find("rox"));
						gameObject.GetComponent<MeshRenderer>().material.mainTexture = Tools.getImage("mana.png");
						gameObject.transform.position = new Vector3(0f, -85f, 0f);
						gameObject.name = "mana";
					}
					else
					{
						gameObject = GameObject.Find("mana");
					}
					WeightUtil.part1Prefab.gameObject.GetComponent<MeshFilter>().mesh = gameObject.gameObject.GetComponent<MeshFilter>().mesh;
					WeightUtil.part1Prefab.gameObject.GetComponent<MeshRenderer>().material = gameObject.GetComponent<MeshRenderer>().material;
					WeightUtil.part1Prefab.gameObject.GetComponent<BoxCollider>().size = new Vector3(0.3f, 0.3f, 0.3f);
					WeightUtil.part1Prefab.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
				}
			}
		}

		[HarmonyPatch(typeof(WeightUtil), "DropWeight")]
		public class MANASCALES2
		{
			public static IEnumerator Postfix(IEnumerator enumerator, GameObject weight)
			{
				weight.GetComponent<Rigidbody>().useGravity = false;
				yield return new WaitForSeconds(0.12f);
				weight.GetComponent<Rigidbody>().useGravity = true;
				weight.GetComponent<Rigidbody>().AddForce(UnityEngine.Random.onUnitSphere * 7f);
				weight.GetComponent<Rigidbody>().AddForce(Vector3.down * 10f, ForceMode.Impulse);
				yield break;
			}
		}

		[HarmonyPatch(typeof(CurrencyBowl), "ShowGain")]
		public class overkilldmgfix
		{
			// Token: 0x060000D6 RID: 214 RVA: 0x0000DA96 File Offset: 0x0000BC96
			public static void Prefix(out CurrencyBowl __state, ref CurrencyBowl __instance)
			{
				__state = __instance;
			}

			// Token: 0x060000D7 RID: 215 RVA: 0x0000DA9D File Offset: 0x0000BC9D
			public static IEnumerator Postfix(IEnumerator enumerator, CurrencyBowl __state, int amount, bool enterFromAbove = false, bool noTutorial = false)
			{
				Vector3 scalePos2 = new Vector3(__state.NEAR_SCALES_POS.x + GameObject.Find("GameTable").transform.position.x, __state.NEAR_SCALES_POS.y + 9.72f, __state.NEAR_SCALES_POS.z + GameObject.Find("GameTable").transform.position.z);
				__state.MoveIntoPlace(scalePos2, __state.NEAR_SCALES_ROT, Tween.EaseInOutStrong, enterFromAbove);
				yield return __state.DropWeightsIn(amount);
				yield return new WaitForSeconds(0.75f);
				bool flag = !noTutorial && !ProgressionData.LearnedMechanic(MechanicsConcept.GainCurrency) && (StoryEventsData.EventCompleted(StoryEvent.TutorialRunCompleted) || StoryEventsData.EventCompleted(StoryEvent.ProspectorDefeated));
				if (flag && SceneLoader.ActiveSceneName == "finale_magnificus")
				{
					ProgressionData.SetMechanicLearned(MechanicsConcept.GainCurrency);
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("With a blaze of Magick, you end the battle. You managed to deal more damage than needed.", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
					__state.StartCoroutine(Singleton<TextDisplayer>.Instance.ShowUntilInput("The excess Magick you cast turns into [c:g3] Crystals. [c:] You may spend them at the meek store behind you.", -2.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true));
				}
				__state.MoveAway(scalePos2);
				yield break;
			}
		}
	}
}
