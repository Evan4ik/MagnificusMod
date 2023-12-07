﻿using System;
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
	class IsometricStuff
	{

		[HarmonyPatch(typeof(FirstPersonController), "LookAtDirection")]
		public class fixLook
		{
			public static bool Prefix(ref FirstPersonController __instance, LookDirection dir, bool immediate = false)
			{
				if (config.isometricMode == false || SceneLoader.ActiveSceneName != "finale_magnificus") { return true; }
				GameObject.Find("PixelCameraParent").transform.localRotation = Quaternion.Euler(30f, 45f, 0);
				GameObject.Find("PixelCameraParent").transform.localPosition = new Vector3(-40, 47.5f, -40);
				if (__instance.currentZone != null)
				{
					__instance.currentZone.OnLook(dir);
				}
				return false;
			}
		}

		[HarmonyPatch(typeof(NavigationZone3D), "OnEnter")]
		public class playTransition
		{
			public static bool Prefix(ref NavigationZone3D __instance)
			{
				if (config.isometricMode == false || SceneLoader.ActiveSceneName != "finale_magnificus") { return true; }
				foreach (NavigationEvent navigationEvent in __instance.events)
				{
					if (__instance.ValidEvent(navigationEvent) && navigationEvent.triggerOnEnter)
					{
						float delay = 0;
						if (navigationEvent == Generation.cardBattle)
                        {
							Texture nodeIcon = Generation.battleTex;
							Debug.Log(__instance.gameObject);
							if (GameObject.Find(__instance.gameObject.name).transform.Find("nodeIcon") != null)
							{
								nodeIcon = GameObject.Find(__instance.gameObject.name).transform.Find("nodeIcon").Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture;

							}
							Tween.LocalPosition(GameObject.Find(__instance.gameObject.name).transform.Find("nodeIcon"), new Vector3(1, 90, 0), 0.65f, 0);
							delay = 1f;
							__instance.StartCoroutine(Generation.isometricTransition(nodeIcon));
						}
						__instance.StartCoroutine(delayTrigger(navigationEvent, delay));
						if (navigationEvent.forceLookInDirection)
						{
							Singleton<FirstPersonController>.Instance.LookAtDirection(navigationEvent.direction, false);
						}
					}
				}
				Action entered = __instance.Entered;
				if (entered == null)
				{
					return false;
				}
				entered();
				return false;
			}
		}

		public static IEnumerator delayTrigger(NavigationEvent navigationEvent, float delay = 0f)
        {
			yield return new WaitForSeconds(delay);
			navigationEvent.eventToTrigger();
			yield break;
        }

		[HarmonyPatch(typeof(FirstPersonController), "UpdateRotation")]
		public class rotation
		{
			public static bool Prefix()
			{
				if (config.isometricMode == false || SceneLoader.ActiveSceneName != "finale_magnificus") { return true; }
				GameObject.Find("PixelCameraParent").transform.localRotation = Quaternion.Euler(30f, 45f, 0);
				GameObject.Find("PixelCameraParent").transform.localPosition = new Vector3(-40, 47.5f, -40);
				return false;
			}
		}

		[HarmonyPatch(typeof(FirstPersonController), "UpdateViewOffset")]
		public class RemoveviewOffset
		{
			public static bool Prefix(float transitionDuration)
			{
				if (config.isometricMode == false) { return true; }
				GameObject.Find("PixelCameraParent").transform.localPosition = new Vector3(-40, 47.5f, -40);
				return false;
			}
		}

		[HarmonyPatch(typeof(FirstPersonController), "GetRightOfDirection")]
		public class mapright
		{
			public static void Prefix(LookDirection dir)
			{
				if (config.isometricMode == true && MagnificusMod.Generation.minimap && RunState.Run.regionTier > 0 && SceneLoader.ActiveSceneName == "finale_magnificus") 
				{
					GameObject playerIcon = GameObject.Find("playerMapNode");
					Tween.Rotation(playerIcon.transform.Find("Header").Find("IconSprite"), Quaternion.Euler(0, 0, 270), 0.25f, 0);
				}
			}
		}

		[HarmonyPatch(typeof(FirstPersonController), "GetLeftOfDirection")]
		public class mapleft
		{
			public static void Prefix(LookDirection dir)
			{
				if (config.isometricMode == true && MagnificusMod.Generation.minimap && RunState.Run.regionTier > 0 && SceneLoader.ActiveSceneName == "finale_magnificus")
				{
					GameObject playerIcon = GameObject.Find("playerMapNode");
					Tween.Rotation(playerIcon.transform.Find("Header").Find("IconSprite"), Quaternion.Euler(0, 0, 90), 0.25f, 0);
				}
			}
		}

		[HarmonyPatch(typeof(FirstPersonController), "GetOppositeDirection")]
		public class mapdown
		{
			public static void Prefix(LookDirection dir)
			{
				if (config.isometricMode == true && MagnificusMod.Generation.minimap && RunState.Run.regionTier > 0 && SceneLoader.ActiveSceneName == "finale_magnificus")
				{
					GameObject playerIcon = GameObject.Find("playerMapNode");
					Tween.Rotation(playerIcon.transform.Find("Header").Find("IconSprite"), Quaternion.Euler(0, 0, 180), 0.25f, 0);
				}
			}
		}

		[HarmonyPatch(typeof(FirstPersonController), "GetZoneFromInput")]
		public class getzone
		{
			public static bool Prefix(ref FirstPersonController __instance, ref NavigationZone3D __result)
			{
				if (config.isometricMode == false || SceneLoader.ActiveSceneName != "finale_magnificus") { return true; }
				if (InputButtons.GetButtonDown(Button.LookUp))
				{
					__result = NavigationGrid.instance.GetZoneInDirection(__instance.LookDirection, __instance.currentZone) as NavigationZone3D;
					Tween.LocalRotation(GameObject.Find("Player").transform.Find("figure").transform, Quaternion.Euler(0, 0, 0), 0.15f, 0);
					if (MagnificusMod.Generation.minimap && RunState.Run.regionTier > 0)
					{
						GameObject playerIcon = GameObject.Find("playerMapNode");
						Tween.Rotation(playerIcon.transform.Find("Header").Find("IconSprite"), Quaternion.Euler(0, 0, 0), 0.25f, 0);
					}
					return false;
				}
				if (InputButtons.GetButtonDown(Button.LookDown))
				{
					__result = NavigationGrid.instance.GetZoneInDirection(__instance.GetOppositeDirection(__instance.LookDirection), __instance.currentZone) as NavigationZone3D;
					Tween.LocalRotation(GameObject.Find("Player").transform.Find("figure").transform, Quaternion.Euler(0, 180, 0), 0.15f, 0);
					return false;
				}
				if (InputButtons.GetButtonDown(Button.DirUp))
				{
					__result = NavigationGrid.instance.GetZoneInDirection(__instance.LookDirection, __instance.currentZone) as NavigationZone3D;
					Tween.LocalRotation(GameObject.Find("Player").transform.Find("figure").transform, Quaternion.Euler(0, 0, 0), 0.15f, 0);
					if (MagnificusMod.Generation.minimap && RunState.Run.regionTier > 0)
					{
						GameObject playerIcon = GameObject.Find("playerMapNode");
						Tween.Rotation(playerIcon.transform.Find("Header").Find("IconSprite"), Quaternion.Euler(0, 0, 0), 0.25f, 0);
					}
					return false;
				}
				if (InputButtons.GetButtonDown(Button.DirRight))
				{
					__result = NavigationGrid.instance.GetZoneInDirection(__instance.GetRightOfDirection(__instance.LookDirection), __instance.currentZone) as NavigationZone3D;
					Tween.LocalRotation(GameObject.Find("Player").transform.Find("figure").transform, Quaternion.Euler(0, 90, 0), 0.15f, 0);
					return false;
				}
				if (InputButtons.GetButtonDown(Button.DirLeft))
				{
					__result = NavigationGrid.instance.GetZoneInDirection(__instance.GetLeftOfDirection(__instance.LookDirection), __instance.currentZone) as NavigationZone3D;
					Tween.LocalRotation(GameObject.Find("Player").transform.Find("figure").transform, Quaternion.Euler(0, 270, 0), 0.15f, 0);
					return false;
				}
				if (InputButtons.GetButtonDown(Button.LookRight))
				{
					__result = NavigationGrid.instance.GetZoneInDirection(__instance.GetRightOfDirection(__instance.LookDirection), __instance.currentZone) as NavigationZone3D;
					Tween.LocalRotation(GameObject.Find("Player").transform.Find("figure").transform, Quaternion.Euler(0, 90, 0), 0.15f, 0);
					return false;
				}
				if (InputButtons.GetButtonDown(Button.LookLeft))
				{
					__result = NavigationGrid.instance.GetZoneInDirection(__instance.GetLeftOfDirection(__instance.LookDirection), __instance.currentZone) as NavigationZone3D;
					Tween.LocalRotation(GameObject.Find("Player").transform.Find("figure").transform, Quaternion.Euler(0, 270, 0), 0.15f, 0);
					return false;
				}
				if (InputButtons.GetButtonDown(Button.DirDown))
				{
					__result = NavigationGrid.instance.GetZoneInDirection(__instance.GetOppositeDirection(__instance.LookDirection), __instance.currentZone) as NavigationZone3D;
					Tween.LocalRotation(GameObject.Find("Player").transform.Find("figure").transform, Quaternion.Euler(0, 180, 0), 0.15f, 0);
					return false;
				}
				__result = null;
				return false;
			}
		}

	}
}
