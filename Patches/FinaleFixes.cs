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
using SavedVars = MagnificusMod.SaveVariables;
using KayceeStorage = MagnificusMod.KayceeStorage;
using MagnificusMod;

namespace MagnificusMod
{
    class FinaleFixes
    {

		[HarmonyPatch(typeof(ViewManager), "SwitchToView")]
		public class handfix
		{
			public static bool Prefix(ref ViewManager __instance, ref View view, bool immediate = false, bool lockAfter = false)
			{
				if (SceneLoader.ActiveSceneName != "finale_magnificus")
				{
					return true;
				}
				Transform transform = null;
				if (Singleton<PlayerHand>.Instance != null && Singleton<PlayerHand>.Instance is PlayerHand3D)
				{
					transform = Singleton<PlayerHand>.Instance.transform;
					if (view == View.Default)
					{
						__instance.SwitchToView(View.WizardBattleUnits);
						return false;
					}
					if (view == View.Board)
					{
						__instance.SwitchToView(View.OpponentQueue);
						return false;
					}
					//Tween.Position(transform, new Vector3(GameObject.Find("GameTable").transform.position.x + 1f, 12.7f + num, GameObject.Find("GameTable").transform.position.z - 5f), 0.5f, 0f, null, Tween.LoopType.None, null, null, true);
				}
				if (__instance.CurrentView != view)
				{
					float num2 = immediate ? 0f : 0.2f;
					if (view != View.WizardBattleHand)
					{
						if (view == View.WizardBattleUnits && __instance.CurrentView == View.WizardBattleHand)
						{
							num2 *= 0.8f;
						}
					}
					else if (__instance.CurrentView == View.WizardBattleUnits || view == View.WizardBattlePiles)
					{
						num2 *= 0.8f;
					}
					ViewInfo viewInfo = ViewManager.GetViewInfo(view);
					if (transform != null)
					{
						if (view == View.OpponentQueue || view == View.WizardBattleHand)
						{
							Singleton<BoardManager3D>.Instance.OnViewChangedFromBoard();
						}
						Tween.LocalPosition(transform, viewInfo.handPosition, num2, 0f, Tween.EaseInOut);
						Tween.Rotation(transform, viewInfo.handRotation, num2, 0f, Tween.EaseInOut, Tween.LoopType.None, null, null, true);
					}
					if (view == View.Board)
					{
						Singleton<ViewManager>.Instance.SwitchToView(View.WizardBattleUnits);
					}
					if (__instance.cameraParent != null)
					{
						Tween.LocalPosition(__instance.cameraParent, viewInfo.camPosition, num2, 0f, Tween.EaseInOut, Tween.LoopType.None, null, null, true);
						Tween.LocalRotation(__instance.cameraParent, viewInfo.camRotation, num2, 0f, Tween.EaseInOut, Tween.LoopType.None, null, null, true);
					}
					if (__instance.pixelCamera != null)
					{
						Tween.FieldOfView(__instance.pixelCamera, viewInfo.fov, num2, 0f, Tween.EaseInOut, Tween.LoopType.None, null, null, true);
					}
					if (!immediate && __instance.enabled)
					{
						FirstPersonController.PlayLookWhooshSound();
					}
					Action<View, View> viewChanged = __instance.ViewChanged;
					bool flag14 = viewChanged != null;
					if (flag14)
					{
						viewChanged(view, __instance.CurrentView);
					}
					__instance.UpdateViewControlsHintsForView(view);
					__instance.CurrentView = view;
				}
				if (lockAfter)
				{
					__instance.Controller.LockState = ViewLockState.Locked;
				}
				return false;
			}
		}

        [HarmonyPatch(typeof(MagnificusDuelDisk), "OnViewChanged")]
		public class DuelDiskFix
		{
			public static bool Prefix(ref MagnificusDuelDisk __instance, View newView, View oldView)
			{
				try
				{
					if (!GameObject.Find("WizardBattleDuelDisk").activeSelf)
					{
						return false;
					}
				}
				catch
				{
					return false;
				}
				if (__instance == null)
				{
					return false;
				}
				if (newView != oldView)
				{
					float pos = 4.5f;
					switch (newView)
					{
						case View.WizardBattleUnits:
						case View.OpponentQueue:
							Tween.LocalRotation(GameObject.Find("WizardBattleDuelDisk").transform, Quaternion.Euler(0, 0, 0), 0.35f, 0f, Tween.EaseInOut);
							Tween.LocalPosition(GameObject.Find("WizardBattleDuelDisk").transform, new Vector3(0.9f, pos, -5.45f), 0.3f, 0f, Tween.EaseInOut, Tween.LoopType.None, null, null, true);

							if (Singleton<SpellPile>.Instance != null && !Singleton<SpellPile>.Instance.gameObject.GetComponent<SineWaveMovement>().enabled && !Singleton<SpellPile>.Instance.initializing)
							{
								Singleton<SpellPile>.Instance.gameObject.GetComponent<SineWaveMovement>().originalPosition = new Vector3(8.75f, 5.5f, 5.55f);
								Singleton<SpellPile>.Instance.transform.localRotation = Quaternion.Euler(0, 40, 0);
								Tween.LocalRotation(Singleton<SpellPile>.Instance.transform, Quaternion.Euler(0, 35f, 0), 0.3f, 0f);//7.75 6.455 7.5
								Tween.LocalPosition(Singleton<SpellPile>.Instance.transform, new Vector3(8.75f, 5.5f, 5.55f), 0.3f, 0f, Tween.EaseInOut, Tween.LoopType.None, null, new Action(delegate {
									Singleton<SpellPile>.Instance.gameObject.GetComponent<SineWaveMovement>().enabled = true;
								}));
							}

							break;
						case View.WizardBattleHand:
						case View.WizardBattleSlots:
							Tween.LocalRotation(GameObject.Find("WizardBattleDuelDisk").transform, Quaternion.Euler(335, 0, 0), 0.25f, 0.05f, Tween.EaseInOut);
							Tween.LocalPosition(GameObject.Find("WizardBattleDuelDisk").transform, new Vector3(0.9f, pos - 1.05f, -3.6f), 0.2f, 0.0f, Tween.EaseInOut, Tween.LoopType.None, null, null);

							break;
						case View.Consumables:
							if (Singleton<SpellPile>.Instance != null && !Singleton<SpellPile>.Instance.initializing)
							{
								Singleton<SpellPile>.Instance.gameObject.GetComponent<SineWaveMovement>().enabled = false;
								Tween.LocalPosition(Singleton<SpellPile>.Instance.transform, new Vector3(5.5f, 7f, 5f), 0.3f, 0f, Tween.EaseInOut);
								Tween.LocalRotation(Singleton<SpellPile>.Instance.transform, Quaternion.Euler(0, 45f, 0), 0.3f, 0f);
							}

							break;
						case View.WizardBattlePiles:
							Tween.LocalRotation(GameObject.Find("WizardBattleDuelDisk").transform, Quaternion.Euler(0, 0, 0), 0.35f, 0f, Tween.EaseInOut);
							Tween.LocalPosition(GameObject.Find("WizardBattleDuelDisk").transform, new Vector3(0f, 3.9624f, -5f), 0.3f, 0f, Tween.EaseInOut, Tween.LoopType.None, null, null, true);
							break;
					}
				}
				return false;
			}
		}

		[HarmonyPatch(typeof(ViewManager), "GetViewInfo")]
		public class BattleViewFixes
		{
			public static void Postfix(ref ViewInfo __result, View view)
            {
				ViewInfo viewInfo = __result;//0 7.65 -4
				switch (view) {
					case View.WizardBattleUnits:
						viewInfo.camPosition = new Vector3(0f, 7.65f, -6.86f);
						viewInfo.camRotation = new Vector3(17.4f, 0f, 0f);
						viewInfo.fov = 60f;
						viewInfo.handPosition = new Vector3(1f, 3.23f, -5.4f);
						break;
					case View.WizardBattlePiles:
						viewInfo.camPosition = new Vector3(2f, 7.6f, -7.25f);
						viewInfo.camRotation = new Vector3(60f, 40f, 2f);
						viewInfo.fov = 60f;
						viewInfo.handPosition = new Vector3(1f, 4.03f, -7.9f);
						viewInfo.handRotation = new Vector3(30f, 0f, 0f);//Tween.LocalPosition(transform, new Vector3( 1f, 12.7f + num, -2.35f), 0.6f, 0f, Tween.EaseInOut, Tween.LoopType.None, null, null, true);
						break;
					case View.WizardBattleSlots:
						viewInfo.camPosition = new Vector3(0f, 7.65f, -6f);
						viewInfo.camRotation = new Vector3(35f, 0f, 0f);
						viewInfo.fov = 60f;
						viewInfo.handPosition = new Vector3(1, 2.75f, -5.15f);
						viewInfo.handRotation = new Vector3(50f, 0f, 0f);
						break;
					case View.WizardBattleHand:
						viewInfo.camPosition = new Vector3(0f, 7.3f, -6f);
						viewInfo.camRotation = new Vector3(45f, 0f, 0f);
						viewInfo.fov = 60f;
						viewInfo.handPosition = new Vector3(1f, 3.7f, -5.25f);
						viewInfo.handRotation = new Vector3(50f, 0f, 0f);
						break;
					case View.OpponentQueue:
						if (SceneLoader.ActiveSceneName != "finale_magnificus") { break; }

						viewInfo.camPosition = new Vector3(0.475f, RunState.Run.regionTier != 4 ? 10.71f : 13.75f, 0.86f);
						viewInfo.camRotation = new Vector3(RunState.Run.regionTier != 4 ? 60f : 45f, 0f, 0f);
						viewInfo.fov = 55f;
						break;
					case View.Consumables:
						if (SceneLoader.ActiveSceneName != "finale_magnificus") { break; }

						viewInfo.camPosition = new Vector3(0.475f, 10.71f, 0.86f);
						viewInfo.camRotation = new Vector3(35f, 45f, 0);


						break;
				}
				__result = viewInfo;
			}
        }



		[HarmonyPatch(typeof(SelectableCardArray), "CreateAndPlaceCard")]
		public class arrayCardThickness
		{
			public static void Postfix(ref SelectableCardArray __instance, ref SelectableCard __result, CardInfo info, Vector3 cardPos, float zRot, bool tiltCard)
			{
				if (SceneLoader.ActiveSceneName != "finale_magnificus" || config.oldCardDesigns || __result.gameObject.GetComponentInChildren<MagCardFrame>() == null) return;
				SelectableCard inst = __result;
				inst.gameObject.GetComponentInChildren<MagCardFrame>().transform.localScale = new Vector3(0.1785f, 0.1045f, 0.0015f);
				__result = inst;
			}
		}
	}
}
