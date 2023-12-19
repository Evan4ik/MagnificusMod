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
	class IsometricStuff
	{
		public static string lastDir = "none";

		public static bool moveDisabled = false;

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

		[HarmonyPatch(typeof(FirstPersonController), "SetZone")]
		public class playMoveAnim
		{
			public static void Prefix(ref FirstPersonController __instance, NavigationZone3D zone, bool immediate = false)
			{
				if (config.isometricMode && zone != null)
                {
					if (zone.events != null && zone.events.Contains(Generation.mirrorClose))
					{
						string[] coords = zone.gameObject.name.Split(' ');
						string x = coords[0].Split('x')[1];
						string y = coords[1].Split('y')[1];
						if (GameObject.Find("NavigationGrid").GetComponent<NavigationGrid>().GetAdjacentZones(Convert.ToInt32(x), Convert.ToInt32(y))[0].gameObject.name == "mirror" && GameObject.Find("Player").transform.Find("figure").transform.localEulerAngles.y == 270){return;}
					} else if (zone.events != null && zone.events.Contains(Generation.mirrorIn)) { return; }
					Tween.LocalPosition(GameObject.Find("Player").transform.Find("figure"), new Vector3(0, -6.5f + UnityEngine.Random.Range(-0.50f, 0.50f), 0), 0.1f, 0);
					Tween.LocalPosition(GameObject.Find("Player").transform.Find("figure"), new Vector3(0, -10f, 0), 0.1f, 0.1f);
					GameObject uiFigure = GameObject.Find("WallFigure").transform.Find("VisibleParent").gameObject;
					if (Physics.Raycast(zone.gameObject.transform.position + new Vector3(0, -20, 0), new Vector3(-1, 1f, -1f), 45, 1))
					{
                           if (GameObject.Find("WallFigure").transform.Find("VisibleParent").transform.localPosition == new Vector3(0, 0, -1)){__instance.StartCoroutine(showUiFigure(uiFigure.transform.Find("Header").Find("IconSprite").gameObject, true)); }
					} else 
					{
						if (GameObject.Find("WallFigure").transform.Find("VisibleParent").transform.localPosition == new Vector3(0, 0, 1)) {__instance.StartCoroutine(showUiFigure(uiFigure.transform.Find("Header").Find("IconSprite").gameObject, false));}
					}
					if (lastDir != "none")
                    {
						if (Generation.checkIfShouldDisplayPointIcon(lastDir, zone)) { Singleton<InteractionCursor>.Instance.ForceCursorType(CursorType.Point); }
						else if (!Generation.checkIfShouldDisplayPointIcon(lastDir, zone)) { Singleton<InteractionCursor>.Instance.ClearForcedCursorType(); }
					}
					if (config.gridActive) { __instance.StartCoroutine(gridTiles(zone)); }
				}
			}
		}

		public static List<GameObject> gridTileObj = new List<GameObject>();
		public static int gridMove = 0;
		public static IEnumerator gridTiles(NavigationZone zone)
        {
			for (float j = 0f; j <= 10f; j++)
			{
				foreach (GameObject gridTile in gridTileObj)
				{
					float modify = (j / 10) * 7.5f;
					if (gridMove > 0) { 
						gridMove = 2;
						gridTile.transform.localScale = new Vector3(0, 0, 1);
						continue;
					}
					gridTile.transform.localScale = new Vector3(7.5f - modify, 7.5f - modify, 1);
				}
				yield return new WaitForSeconds(0.01f);
			}
			foreach (GameObject gridTile in gridTileObj)
			{
				if (gridTile.name == "gridtile-1") { continue; }
				GridTile gridComp = gridTile.GetComponent<GridTile>();
				NavigationZone check = gridComp.getZoneToCheckFrom(zone);
				gridTile.SetActive(NavigationGrid.instance.GetZoneInDirection(gridComp.direction, check) != null);
			}
			if (gridMove < 1){gridMove = 1;}
			for (float j = 0f; j < 10f; j++)
			{
				foreach(GameObject gridTile in gridTileObj)
				{
					if (gridMove > 1) {
						gridTile.transform.localScale = new Vector3(0, 0, 1);
						gridMove = 0;
						yield return new WaitForSeconds(0.20f);
						yield break;
					}
					float modify = (j / 10) * 7.5f;
					gridTile.transform.localScale = new Vector3(modify, modify, 1);
				}
				yield return new WaitForSeconds(0.01f);
			}
			gridMove = 0;
			GameObject.Find("clickGrid").transform.Find("gridtile-1").gameObject.SetActive(true);
		}

		public static IEnumerator showUiFigure(GameObject uiFigure, bool enable)
        {
			yield return new WaitForSeconds(0.1f);
			if (enable) { 
				GameObject.Find("WallFigure").transform.Find("VisibleParent").transform.localPosition = new Vector3(0, 0, 1);
				uiFigure.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
			} else
            {
				GameObject.Find("WallFigure").transform.Find("VisibleParent").transform.localPosition = new Vector3(0, 0, -1);
				uiFigure.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
			}
			yield break;
		}

        [HarmonyPatch(typeof(NavigationZone3D), "OnEnter")]
		public class playTransition
		{
			public static bool Prefix(ref NavigationZone3D __instance)
			{
				if (config.isometricMode == false || SceneLoader.ActiveSceneName != "finale_magnificus") { return true; }
				bool delete = false;
				foreach (NavigationEvent navigationEvent in __instance.events)
				{
					if (__instance.ValidEvent(navigationEvent) && navigationEvent.triggerOnEnter)
					{
						float delay = 0;
						if (Generation.nodeEvents.Contains(navigationEvent))
                        {
							Texture nodeIcon = Generation.battleTex;
							if (GameObject.Find(__instance.gameObject.name).transform.childCount >= 1)
							{
								nodeIcon = GameObject.Find(__instance.gameObject.name).transform.GetChild(0).Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture;
								Tween.LocalPosition(GameObject.Find(__instance.gameObject.name).transform.GetChild(0), new Vector3(1, 90, 0), 0.65f, 0);

							}
							delay = 0.25f;
							__instance.StartCoroutine(Generation.isometricTransition(nodeIcon));
							IsometricStuff.moveDisabled = true;
							delete = true;
						}
						__instance.StartCoroutine(delayTrigger(navigationEvent, delay));
						if (navigationEvent.forceLookInDirection)
						{
							Singleton<FirstPersonController>.Instance.LookAtDirection(navigationEvent.direction, false);
						}
					}
				}
				if (delete)
                {
					__instance.events = new List<NavigationEvent>();
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


		[HarmonyPatch(typeof(ZoomInteractable), "ManagedUpdate")]
		public class fixZoomInteractable
		{
			public static bool Prefix(ref ZoomInteractable __instance)
			{
				if (config.isometricMode == false || SceneLoader.ActiveSceneName != "finale_magnificus") { return true; }
				if (__instance.Zoomed && (__instance.discoverableObjectChild == null || !__instance.discoverableObjectChild.Discovering))
				{
					if (InputButtons.GetButtonUp(Button.LookDown) || InputButtons.GetButtonUp(Button.LookLeft) || InputButtons.GetButtonUp(Button.LookRight))
					{
						__instance.SetZoomed(false, false, 0.2f);
						Singleton<FirstPersonController>.Instance.LookLocked = true;
						Tween.LocalPosition(GameObject.Find("PixelCameraParent").transform, new Vector3(-40, 47.5f, -40), 0.25f, 0);
						Tween.LocalRotation(GameObject.Find("PixelCameraParent").transform, Quaternion.Euler(30, 45, 0), 0.25f, 0);
					}
				}
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
				if (moveDisabled) { return false; }
				if (InputButtons.GetButtonDown(Button.LookUp) || InputButtons.GetButtonDown(Button.DirUp))
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
				if (InputButtons.GetButtonDown(Button.LookDown) || InputButtons.GetButtonDown(Button.DirDown))
				{
					__result = NavigationGrid.instance.GetZoneInDirection(__instance.GetOppositeDirection(__instance.LookDirection), __instance.currentZone) as NavigationZone3D;
					Tween.LocalRotation(GameObject.Find("Player").transform.Find("figure").transform, Quaternion.Euler(0, 180, 0), 0.15f, 0);
					return false;
				}
				if (InputButtons.GetButtonDown(Button.DirRight) || InputButtons.GetButtonDown(Button.LookRight))
				{
					__result = NavigationGrid.instance.GetZoneInDirection(__instance.GetRightOfDirection(__instance.LookDirection), __instance.currentZone) as NavigationZone3D;
					Tween.LocalRotation(GameObject.Find("Player").transform.Find("figure").transform, Quaternion.Euler(0, 90, 0), 0.15f, 0);
					return false;
				}
				if (InputButtons.GetButtonDown(Button.DirLeft) || InputButtons.GetButtonDown(Button.LookLeft))
				{
					__result = NavigationGrid.instance.GetZoneInDirection(__instance.GetLeftOfDirection(__instance.LookDirection), __instance.currentZone) as NavigationZone3D;
					Tween.LocalRotation(GameObject.Find("Player").transform.Find("figure").transform, Quaternion.Euler(0, 270, 0), 0.15f, 0);
					return false;
				}
				__result = null;
				return false;
			}
		}

	}
}
