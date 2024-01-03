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
    class TableRuleBookHostageFixes
    {
		//rotate the nodes




		[HarmonyPatch(typeof(TableRuleBook), "MoveOnBoard")]
		public class FixRedText1
		{
			public static void Prefix(out TableRuleBook __state, ref TableRuleBook __instance)
			{
				__state = __instance;
			}

			public static IEnumerator Postfix(IEnumerator enumerator, TableRuleBook __state)
			{
				if (SceneLoader.ActiveSceneName == "finale_magnificus") { yield break; }
				__state.transform.position = __state.defaultPosition + __state.OFF_TABLE_OFFSET;
				__state.transform.eulerAngles = __state.defaultRotation + __state.ROTATION_OFFSET;
				Tween.Position(__state.transform, __state.defaultPosition, 0.25f, 0f, null, Tween.LoopType.None, null, new Action(__state.PlayPlacedSound), true);
				Tween.Rotation(__state.transform, __state.defaultRotation, 0.25f, 0f, Tween.EaseInOut, Tween.LoopType.None, null, null, true);
				yield return new WaitForSeconds(0.05f);
				__state.openRulebookInteractable.SetEnabled(true);
				yield break;
			}
		}

		[HarmonyPatch(typeof(TableRuleBook), "MoveOffBoard")]
		public class FixRedText2
		{
			public static void Prefix(out TableRuleBook __state, ref TableRuleBook __instance)
			{
				__state = __instance;
			}

			public static IEnumerator Postfix(IEnumerator enumerator, TableRuleBook __state)
			{
				if (SceneLoader.ActiveSceneName == "finale_magnificus") { yield break; }
				Tween.Position(__state.transform, __state.defaultPosition + __state.OFF_TABLE_OFFSET, 0.2f, 0f, Tween.EaseIn, Tween.LoopType.None, null, null, true);
				Tween.Rotation(__state.transform, __state.defaultRotation + __state.ROTATION_OFFSET, 0.2f, 0f, Tween.EaseInOut, Tween.LoopType.None, null, null, true);
				__state.openRulebookInteractable.SetEnabled(false);
				yield return new WaitForSeconds(0.2f);
				__state.SetHidden(true);
				yield break;
			}
		}
	}
}
