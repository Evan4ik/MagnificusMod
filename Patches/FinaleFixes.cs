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
				float num = 0f;
				bool flag = RunState.Run.regionTier == 4;
				if (flag)
				{
					num = 9.72f;
				}
				bool flag2 = Singleton<PlayerHand>.Instance != null && Singleton<PlayerHand>.Instance is PlayerHand3D;
				if (flag2)
				{
					transform = Singleton<PlayerHand>.Instance.transform;
					if (view == View.WizardBattleUnits)
					{
						__instance.SwitchToView(View.Default);
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
						bool flag5 = view == View.Default && __instance.CurrentView == View.WizardBattleHand;
						if (flag5)
						{
							num2 *= 0.8f;
						}
					}
					else if (__instance.CurrentView == View.Default)
					{
						num2 *= 0.8f;
					}
					ViewInfo viewInfo = ViewManager.GetViewInfo(view);
					bool flag7 = transform != null;
					if (flag7)
					{
						if (view == View.OpponentQueue || view == View.WizardBattleHand)
						{
							Singleton<BoardManager3D>.Instance.OnViewChangedFromBoard();
						}
						if (RunState.Run.regionTier == 4) { num += 2.58f; }
						if (view != View.WizardBattleHand)
						{
							bool flag10 = view == View.WizardBattleSlots || view == View.WizardBattleUnits || view == View.WizardBattlePiles;
							if (flag10)
							{
								if (__instance.CurrentView == View.Default)
								{
									if (RunState.Run.regionTier == 4) { num += 0.58f; }
									transform.position = new Vector3(GameObject.Find("GameTable").transform.position.x + 1f, 13.75f + num, GameObject.Find("GameTable").transform.position.z - 5.15f);
								}
								Tween.Position(transform, new Vector3(GameObject.Find("GameTable").transform.position.x + 1f, 13.75f + num, GameObject.Find("GameTable").transform.position.z - 7.9f), 0.6f, 0f, Tween.EaseInOut, Tween.LoopType.None, null, null, true);
							}
							else if (view != View.WizardBattleHand)
							{
								Tween.Position(transform, new Vector3(GameObject.Find("GameTable").transform.position.x + 1f, 12.7f + num, GameObject.Find("GameTable").transform.position.z - 5.15f), 0.6f, 0f, Tween.EaseInOut, Tween.LoopType.None, null, null, true);
							}
						}
						else
						{
							Tween.Position(transform, new Vector3(GameObject.Find("GameTable").transform.position.x + 1f, 13.64f + num, GameObject.Find("GameTable").transform.position.z - 7.59f), num2, 0f, Tween.EaseInOut, Tween.LoopType.None, null, null, true);
						}
						Tween.Rotation(transform, viewInfo.handRotation, num2, 0f, Tween.EaseInOut, Tween.LoopType.None, null, null, true);
					}
					if (view == View.Board)
					{
						Singleton<ViewManager>.Instance.SwitchToView(View.Default);
					}
					float offSet = RunState.Run.regionTier == 4 ? 12.5f : 0f;
					float ZoffSet = RunState.Run.regionTier == 4 ? -12f : 0f;
					if (view == View.OpponentQueue)
					{
						if (RunState.Run.regionTier == 4) { offSet += 5; } else { offSet = 1; };
						float queuePos = RunState.Run.regionTier == 4 ? -22 : GameObject.Find("Player").transform.position.z + 2;
						Tween.Position(GameObject.Find("Player").transform, new Vector3(GameObject.Find("Player").transform.position.x,9.5f + offSet, queuePos), 0.3f, 0);
					}
					if (__instance.CurrentView == View.OpponentQueue && view != View.OpponentQueue)
					{
						Tween.Position(GameObject.Find("Player").transform, new Vector3(GameObject.Find("Player").transform.position.x, 9.5f + offSet, GameObject.Find("Player").GetComponent<FirstPersonController>().currentZone.transform.position.z + ZoffSet), 0.3f, 0);
					}
					bool flag11 = __instance.cameraParent != null;
					if (flag11)
					{
						Tween.LocalPosition(__instance.cameraParent, viewInfo.camPosition, num2, 0f, Tween.EaseInOut, Tween.LoopType.None, null, null, true);
						Tween.LocalRotation(__instance.cameraParent, viewInfo.camRotation, num2, 0f, Tween.EaseInOut, Tween.LoopType.None, null, null, true);
					}
					bool flag12 = __instance.pixelCamera != null;
					if (flag12)
					{
						Tween.FieldOfView(__instance.pixelCamera, viewInfo.fov, num2, 0f, Tween.EaseInOut, Tween.LoopType.None, null, null, true);
					}
					bool flag13 = !immediate && __instance.enabled;
					if (flag13)
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
				GameObject disk;
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
					float pos = RunState.Run.regionTier == 4 ? 26.5f : 13.9624f;
					switch (newView)
					{
						case View.Default:
							Tween.Position(GameObject.Find("WizardBattleDuelDisk").transform, new Vector3(GameObject.Find("GameTable").transform.position.x + 0.89f, pos, GameObject.Find("GameTable").transform.position.z - 4.8576f), 0.3f, 0f, Tween.EaseInOut, Tween.LoopType.None, null, null, true);
							break;
						case View.WizardBattleSlots:
							Tween.Position(GameObject.Find("WizardBattleDuelDisk").transform, new Vector3(GameObject.Find("GameTable").transform.position.x + 0.89f, pos, GameObject.Find("GameTable").transform.position.z - 5.7575f), 0.3f, 0f, Tween.EaseInOut, Tween.LoopType.None, null, null, true);
							break;
						case View.WizardBattleHand:
							Tween.Position(GameObject.Find("WizardBattleDuelDisk").transform, new Vector3(GameObject.Find("GameTable").transform.position.x + 0.89f, pos, GameObject.Find("GameTable").transform.position.z - 6.0375f), 0.3f, 0f, Tween.EaseInOut, Tween.LoopType.None, null, null, true);
							break;
						case View.WizardBattlePiles:
							if (Singleton<SpellPile>.Instance.spellList.Count > 0)
							{
								pos = RunState.Run.regionTier == 4 ? 4.5f : 3.9624f;
								GameObject spellBook = GameObject.Find("spellBook");
								Tween.Rotation(spellBook.transform, Quaternion.Euler(0, 299, 0), 0f, 0.6f);
								Tween.LocalPosition(spellBook.transform, new Vector3(0f, -0.24f, 0), 0f, 0.6f);
								Tween.LocalPosition(GameObject.Find("WizardBattleDuelDisk").transform, new Vector3(-0.0699f, pos, -6.7901f), 0.3f, 0f, Tween.EaseInOut, Tween.LoopType.None, null, null, true);
								if (!SavedVars.LearnedMechanics.Contains("spellbook;"))
								{
									Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(MagnificusMod.Generation.spellBookTutorial());
								}
							}
							break;
					}
				}
				return false;
			}
		}

		[HarmonyPatch(typeof(CardDrawPiles3D), "Exhausted", MethodType.Getter)]
		public class fixStarvation
		{
			public static bool Prefix(ref CardDrawPiles3D __instance, ref bool __result)
			{
				if (SceneLoader.ActiveSceneName == "finale_magnificus")
				{
					__result = __instance.Deck.CardsInDeck == 0 && __instance.SideDeck.CardsInDeck == 0 && Singleton<SpellPile>.Instance.spellList.Count == 0;
					return false;
				}
				else
				{
					return true;
				}
			}
		}
	}
}
