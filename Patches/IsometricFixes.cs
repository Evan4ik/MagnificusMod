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
				GameObject.Find("PixelCameraParent").transform.localRotation = Quaternion.Euler(40f, 0, 0);
				GameObject.Find("PixelCameraParent").transform.localPosition = new Vector3(0, 45, -50);
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

					string[] pos = zone.name.Split('y');
					int xPos = Convert.ToInt32(pos[0].Split('x')[1]);
					int yPos = Convert.ToInt32(pos[1]);
					float rotation = (float)Singleton<FirstPersonController>.Instance.LookDirection * 90;
					if (rotation == 0) { yPos += 1; }
					else if (rotation == 90) { xPos -= 1; }
					else if (rotation == 180) { yPos -= 1; }
					else if (rotation == 270) { xPos += 1; }

					try
					{
						if (GameObject.Find("x" + xPos + " y" + yPos + " cover") != null)
						{
							if (GameObject.Find("WallFigure").transform.Find("VisibleParent").transform.localPosition == new Vector3(0, 0, -1)) { __instance.StartCoroutine(showUiFigure(uiFigure.transform.Find("Header").Find("IconSprite").gameObject, true)); }
						}
						else
						{
							if (GameObject.Find("WallFigure").transform.Find("VisibleParent").transform.localPosition == new Vector3(0, 0, 1)) { __instance.StartCoroutine(showUiFigure(uiFigure.transform.Find("Header").Find("IconSprite").gameObject, false)); }

						}
					} catch {
						if (GameObject.Find("WallFigure").transform.Find("VisibleParent").transform.localPosition == new Vector3(0, 0, 1)) { __instance.StartCoroutine(showUiFigure(uiFigure.transform.Find("Header").Find("IconSprite").gameObject, false)); }
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

		public static Vector3 getRayDirection(float dir)
        {
			if (dir == 270) { return new Vector3(1, 1, -1f); }
			else if (dir == 180) { return new Vector3(1, 1, 1); }
			else if (dir == 90) { return new Vector3(-1, 1, 1); }
			return new Vector3(-1, 1, -1f);
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
			GameObject.Find("Player").transform.Find("clickGrid").Find("gridtile-1").gameObject.SetActive(true);
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

				if (Singleton<UIManager>.Instance.rightHintShown) Singleton<UIManager>.Instance.SetControlsHintShown(false, true);

				bool delete = false;
				foreach (NavigationEvent navigationEvent in __instance.events)
				{
					if (__instance.ValidEvent(navigationEvent) && navigationEvent.triggerOnEnter)
					{
						Singleton<UIManager>.Instance.SetControlsHintShown(shown: false);
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
				GameObject.Find("PixelCameraParent").transform.localRotation = Quaternion.Euler(40f, 0f, 0);
				GameObject.Find("PixelCameraParent").transform.localPosition = new Vector3(0, 45, -50);
				return false;
			}
		}

		public static bool enableNorth = false;

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
						Tween.LocalPosition(GameObject.Find("PixelCameraParent").transform, new Vector3(0, 45, -50), 0.25f, 0);
						Tween.LocalRotation(GameObject.Find("PixelCameraParent").transform, Quaternion.Euler(40, 0, 0), 0.25f, 0);
					}
				}
				List<string> directions = new List<string> { "North", "East", "South", "West" };
				if (__instance.PrerequisitesMet)
				{
					enableNorth = true;
					for (int i = 0; i < directions.Count; i++)
					{GameObject.Find("click" + directions[i]).GetComponent<BoxCollider>().enabled = false;}
					Singleton<InteractionCursor>.Instance.ClearForcedCursorType();
				}
				if (!__instance.PrerequisitesMet && enableNorth)
                {
					enableNorth = false;
					for (int i = 0; i < directions.Count; i++)
					{ GameObject.Find("click" + directions[i]).GetComponent<BoxCollider>().enabled = true; }
				}
				return false;
			}
		}

		[HarmonyPatch(typeof(ZoomInteractable), "SetZoomed")]
		public class fixZoom
		{
			public static void Prefix(ref ZoomInteractable __instance, bool zoomed, bool toAnotherZoom = false, float zoomDuration = 0.2f)
			{
				if (config.isometricMode == false || SceneLoader.ActiveSceneName != "finale_magnificus") { return; }
				if (zoomed)
				{
					Generation.lastView = Singleton<FirstPersonController>.Instance.LookDirection;
					Tween.LocalRotation(GameObject.Find("Player").transform, Quaternion.Euler(0, 0, 0), 0.2f, 0);
				} else
                {
					Tween.FieldOfView(GameObject.Find("PixelCameraParent").transform.Find("Pixel Camera").gameObject.GetComponent<Camera>(), 65f, 0.05f, 0);
					Tween.LocalRotation(GameObject.Find("Player").transform, Quaternion.Euler(0, (float)Generation.lastView * 90, 0), 0.2f, 0);
					Generation.lastView = LookDirection.North; 

				}
			}
		}

		[HarmonyPatch(typeof(FirstPersonController), "UpdateViewOffset")]
		public class RemoveviewOffset
		{
			public static bool Prefix(float transitionDuration)
			{
				if (config.isometricMode == false) { return true; }
				GameObject.Find("PixelCameraParent").transform.localPosition = new Vector3(0, 45f, -50);
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
					Tween.Rotation(playerIcon.transform.Find("Header").Find("IconSprite"), Quaternion.Euler(0, 0, 270 + getMapRotationOffset((float)Singleton<FirstPersonController>.Instance.LookDirection * 90)), 0.25f, 0);
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
					Tween.Rotation(playerIcon.transform.Find("Header").Find("IconSprite"), Quaternion.Euler(0, 0, 90 + getMapRotationOffset((float)Singleton<FirstPersonController>.Instance.LookDirection * 90)), 0.25f, 0);
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
					Tween.Rotation(playerIcon.transform.Find("Header").Find("IconSprite"), Quaternion.Euler(0, 0, 180 + getMapRotationOffset((float)Singleton<FirstPersonController>.Instance.LookDirection * 90)), 0.25f, 0);
				}
			}
		}

		public static float getMapRotationOffset(float currentRotation)
		{
			if (currentRotation == 90) { return -90;}
			else if (currentRotation == 270) { return 90; }
			else if (currentRotation == 180){return 180;}
			return 0;
		}

		public static bool rotating = false;

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
						Tween.Rotation(playerIcon.transform.Find("Header").Find("IconSprite"), Quaternion.Euler(0, 0, 0 + getMapRotationOffset((float)Singleton<FirstPersonController>.Instance.LookDirection * 90)), 0.25f, 0);
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
				if (Input.GetKeyDown(KeyCode.Q) && !rotating)
				{
					Tween.LocalRotation(GameObject.Find("Player").transform, Quaternion.Euler(0, ((float)Singleton<FirstPersonController>.Instance.LookDirection * 90) - 90, 0), 0.2f, 0);
					if (config.gridActive) {
						float gridRot = ((float)Singleton<FirstPersonController>.Instance.LookDirection * 90) + 90;
						if (((float)Singleton<FirstPersonController>.Instance.LookDirection * 90) - 90 == 0)
						{ gridRot = 0; }
						else if (((float)Singleton<FirstPersonController>.Instance.LookDirection * 90) - 90 == 180)
						{ gridRot = 180; }
						Tween.LocalRotation(GameObject.Find("clickGrid").transform, Quaternion.Euler(0, gridRot, 0), 0.2f, 0);
					}
					Singleton<FirstPersonController>.Instance.LookLeft();
					__instance.StartCoroutine(rotateNodes());
				}
				if (Input.GetKeyDown(KeyCode.E) && !rotating)
				{
					Tween.LocalRotation(GameObject.Find("Player").transform, Quaternion.Euler(0, ((float)Singleton<FirstPersonController>.Instance.LookDirection * 90) + 90, 0), 0.2f, 0);
					if (config.gridActive) {
						float gridRot = ((float)Singleton<FirstPersonController>.Instance.LookDirection * 90) - 90;
						if (((float)Singleton<FirstPersonController>.Instance.LookDirection * 90) + 90 == 0 || ((float)Singleton<FirstPersonController>.Instance.LookDirection * 90) + 90 == 360)
						{ gridRot = 0; } 
						else if (((float)Singleton<FirstPersonController>.Instance.LookDirection * 90) + 90 == 180) 
						{gridRot = 180;}
						Tween.LocalRotation(GameObject.Find("clickGrid").transform, Quaternion.Euler(0, gridRot, 0), 0.2f, 0);
					}
					Singleton<FirstPersonController>.Instance.LookRight();
					__instance.StartCoroutine(rotateNodes());
				}
				__result = null;
				return false;
			}
		}

		public static IEnumerator rotateNodes()
        {
			if (Singleton<UIManager>.Instance.leftHintShown && !SavedVars.LearnedMechanics.Contains("isometricTutorial"))
			{
				SavedVars.LearnedMechanics += "isometricTutorial;";
				Singleton<UIManager>.Instance.SetControlsHintShown(false, false);
			}

			rotating = true;
			foreach (GameObject gameObject in MagnificusMod.Generation.nodes)
			{
				if (gameObject == null) { continue; }
				if (gameObject.name.Contains("nodeIcon"))
				{
					Tween.LocalRotation (gameObject.transform, Quaternion.Euler(30, (float)Singleton<FirstPersonController>.Instance.LookDirection * 90, 0), 0.2f, 0);
					if (NavigationGrid.instance.GetZoneInDirection((LookDirection)((int)(Singleton<FirstPersonController>.Instance.LookDirection + 2) % 4), gameObject.transform.GetParent().gameObject.GetComponent<NavigationZone>()) == null)
					{
						string[] pos = gameObject.transform.GetParent().gameObject.name.Split('y');
						int xPos = Convert.ToInt32(pos[0].Split('x')[1]);
						int yPos = Convert.ToInt32(pos[1]);
						float rotation = (float)Singleton<FirstPersonController>.Instance.LookDirection * 90;
						if (rotation == 0) { yPos += 1; }
						else if (rotation == 90) { xPos -= 1; }
						else if (rotation == 180) { yPos -= 1; }
						else if (rotation == 270) { xPos += 1; }
						try
						{
							if (GameObject.Find("x" + xPos + " y" + yPos + " cover") != null)
							{
								Tween.LocalPosition(gameObject.transform, new Vector3(1f, 32.72f, 0), 0.2f, 0);
							}
							else
							{
								Tween.LocalPosition(gameObject.transform, new Vector3(1f, 22.72f, 0), 0.2f, 0);
							}
						}
						catch { Tween.LocalPosition(gameObject.transform, new Vector3(1f, 22.72f, 0), 0.2f, 0); }
					} else
                    {Tween.LocalPosition(gameObject.transform, new Vector3(1f, 22.72f, 0), 0.2f, 0);}
				}
			}
			yield return new WaitForSeconds(0.2f);
			rotating = false;
			yield break;
		}

	}
}
