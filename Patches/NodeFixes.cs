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
using MagSave = MagnificusMod.MagCurrentNode;
using SavedVars = MagnificusMod.SaveVariables;
using KayceeStorage = MagnificusMod.KayceeStorage;

namespace MagnificusMod
{
    class NodeFixes
    {
		//rotate the nodes


		[HarmonyPatch(typeof(NavigationZone3D), "OnLook")]
		public class NodesLol
		{
			public static void Prefix()
			{
				if (SceneLoader.ActiveSceneName == "finale_magnificus")
				{
					foreach (GameObject gameObject in MagnificusMod.Generation.nodes)
					{
						if (gameObject == null) { return; }
						if (gameObject.name.Contains("nodeIcon") && config.isometricMode == true)
						{
							//gameObject.transform.localRotation = Quaternion.Euler(30, 45 + (float)Singleton<FirstPersonController>.Instance.LookDirection * 90, 0);
							continue;
						}
						float oldRot = gameObject.transform.eulerAngles.y;
						float xRot = gameObject.transform.eulerAngles.x;
						float zRot = gameObject.transform.eulerAngles.z;
						gameObject.transform.LookAt(2f * gameObject.transform.position - GameObject.Find("Player").GetComponent<FirstPersonController>().currentZone.gameObject.transform.position);
						float newRot = gameObject.transform.eulerAngles.y;
						if (gameObject.name != "pedestalMox" && gameObject.name != "GooWizardBottle")
						{
							gameObject.transform.localRotation = Quaternion.Euler(xRot, oldRot, zRot);
							Tween.Rotation(gameObject.transform, Quaternion.Euler(xRot, newRot, zRot), 0.25f, 0);
						}
						else
						{
							gameObject.transform.rotation = Quaternion.Euler(xRot, newRot, zRot);
						}
						//bool flag = gameObject.transform.parent.name == "x17 y4" && GameObject.Find("Player").GetComponent<FirstPersonController>().currentZone.gameObject.name == "x17 y4" && GameObject.Find("Player").GetComponent<FirstPersonController>().LookDirection == LookDirection.North;
						//gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
					}
					if (MagnificusMod.Generation.minimap && RunState.Run.regionTier > 0)
					{
						float rotation = 0;
						switch (Singleton<FirstPersonController>.Instance.LookDirection)
						{
							case LookDirection.South:
								rotation = 180;
								break;
							case LookDirection.East:
								rotation = 270;
								break;
							case LookDirection.West:
								rotation = 90;
								break;

						}
						if (config.isometricMode == true)
                        {
							rotation = Singleton<FirstPersonController>.Instance.gameObject.transform.Find("figure").localRotation.eulerAngles.y + IsometricStuff.getMapRotationOffset((float)Singleton<FirstPersonController>.Instance.LookDirection * 90);

						}
						GameObject playerIcon = GameObject.Find("playerMapNode");
						Tween.Rotation(playerIcon.transform.Find("Header").Find("IconSprite"), Quaternion.Euler(0, 0, rotation), 0.25f, 0);
					}
				}
			}
		}

		[HarmonyPatch(typeof(NavigationZone3D), "OnEnter")]
		public class NodesLol2
		{
			public static void Prefix(ref NavigationZone3D __instance)
			{
				if (SceneLoader.ActiveSceneName == "finale_magnificus")
				{
					if (Singleton<UIManager>.Instance.leftHintShown || Singleton<UIManager>.Instance.rightHintShown) { 
						foreach (NavigationEvent navigationEvent in __instance.events)
						{
							if (__instance.ValidEvent(navigationEvent) && navigationEvent.triggerOnEnter)
							{
								Singleton<UIManager>.Instance.SetControlsHintShown(shown: false);
								Singleton<UIManager>.Instance.SetControlsHintShown(shown: false, right: false);
							}
						}
					}

					foreach (GameObject gameObject in MagnificusMod.Generation.nodes)
					{
						if (gameObject == null) { return; }
						if (gameObject.name.Contains("nodeIcon") && config.isometricMode == true)
						{
							gameObject.transform.localRotation = Quaternion.Euler(30, (float)Singleton<FirstPersonController>.Instance.LookDirection * 90, 0);
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
										gameObject.transform.localPosition = new Vector3(1f, 32.72f, 0);
                                    } else
                                    {
										gameObject.transform.localPosition = new Vector3(1f, 22.72f, 0);
									}
                                }
                                catch { gameObject.transform.localPosition = new Vector3(1f, 22.72f, 0); }
							} else
							{ gameObject.transform.localPosition = new Vector3(1f, 22.72f, 0); }
							continue;
						} 
						float oldRot = gameObject.transform.eulerAngles.y;
						float xRot = gameObject.transform.eulerAngles.x;
						float zRot = gameObject.transform.eulerAngles.z;
						gameObject.transform.LookAt(2f * gameObject.transform.position - GameObject.Find("Player").GetComponent<FirstPersonController>().currentZone.gameObject.transform.position);
						float newRot = gameObject.transform.eulerAngles.y;
						if (gameObject.name != "pedestalMox" && gameObject.name != "GooWizardBottle")
						{
							gameObject.transform.localRotation = Quaternion.Euler(xRot, oldRot, zRot);
							Tween.Rotation(gameObject.transform, Quaternion.Euler(xRot, newRot, zRot), 0.25f, 0);
						}
						else
						{
							Tween.Rotation(gameObject.transform, Quaternion.Euler(xRot, newRot, zRot), 0, 0.45f);
						}
						//bool flag = gameObject.transform.parent.name == "x17 y4" && GameObject.Find("Player").GetComponent<FirstPersonController>().currentZone.gameObject.name == "x17 y4" && GameObject.Find("Player").GetComponent<FirstPersonController>().LookDirection == LookDirection.North;
						//gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
					}
					GameObject.Find("Player").GetComponentInChildren<ViewManager>().CurrentView = View.FirstPerson;
					float x = GameObject.Find("PixelCameraParent").transform.position.x;
					float z = GameObject.Find("PixelCameraParent").transform.position.z;
					GameObject.Find("PixelCameraParent").transform.position = new Vector3(x, 16.5f, z);
					Tween.Position(GameObject.Find("PixelCameraParent").transform, new Vector3(x, 16.5f, z), 0f, 0f, null, Tween.LoopType.None, null, null, true);
					GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().enabled = true;
					GameObject.Find("Player").GetComponentInChildren<ViewController>().allowedViews = new List<View>();
					if (MagnificusMod.Generation.minimap && RunState.Run.regionTier > 0)
					{
						string nodeName = Singleton<FirstPersonController>.Instance.currentZone.gameObject.name;
						if (nodeName == "mirror")
						{
							nodeName = GameObject.Find("NavigationGrid").GetComponentInChildren<OcclusionArea>().gameObject.name;
						}
						string[] x1 = nodeName.Split('x');
						string[] x2 = x1[1].Split(' ');
						int xP = int.Parse(x2[0]);
						string[] y2 = x2[1].Split('y');
						int yP = int.Parse(y2[1]);
						xP /= 7;
						yP /= 7;
						float yPos2 = 0.15f * yP;
						float xPos2 = 0.15f * xP;
						GameObject playerIcon = GameObject.Find("playerMapNode");
						Tween.LocalPosition(playerIcon.transform.Find("Header").Find("IconSprite"), new Vector3(-0.15f + xPos2, 0.15f - yPos2, 0), 0.25f, 0);
					}
				}
			}
		}


		[HarmonyPatch(typeof(DeckReviewSequencer), "OnEnterDeckView")]
		public class DeckReviewFix
		{
			public static bool Prefix(ref DeckReviewSequencer __instance, bool lockViewOnEnter = false)
			{
				List<CardInfo> cards = new List<CardInfo>(SaveManager.SaveFile.CurrentDeck.Cards);
				if (SceneLoader.ActiveSceneName == "finale_magnificus")
					cards.RemoveAll((CardInfo x) => x.HasTrait(Trait.EatsWarrens));
				__instance.ArrayDeck(cards, null, lockViewOnEnter);
				return false;
			}
		}
	}
}
