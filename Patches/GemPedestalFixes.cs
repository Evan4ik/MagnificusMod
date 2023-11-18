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
using MagnificusMod;

namespace MagnificusMod
{
	class GemPedestalFixes
	{
		//rotate the nodes



		[HarmonyPatch(typeof(GemPedestal3D), "TeleportSequence")]
		public class tpToBossRoomFix
		{
			public static void Prefix(out GemPedestal3D __state, ref GemPedestal3D __instance)
			{
				__state = __instance;
			}

			public static IEnumerator Postfix(IEnumerator enumerator, GemPedestal3D __state)
			{
				Singleton<FirstPersonController>.Instance.MoveLocked = (Singleton<FirstPersonController>.Instance.LookLocked = true);
				Singleton<InteractionCursor>.Instance.InteractionDisabled = true;
				__state.zoomInteractable.enabled = false;
				__state.zoomInteractable.SetEnabled(false);
				Singleton<CameraEffects>.Instance.Shake(0.05f, 0.3f);
				AudioController.Instance.PlaySound3D("giant_stones_falling", MixerGroup.ExplorationSFX, __state.transform.position, 0.75f, 0f, null, null, null, null, false);
				yield return new WaitForSeconds(0.5f);
				__state.zoomInteractable.SetZoomed(false, false, 0.2f);
				Singleton<FirstPersonController>.Instance.MoveLocked = (Singleton<FirstPersonController>.Instance.LookLocked = true);
				Singleton<InteractionCursor>.Instance.InteractionDisabled = true;
				__state.gemAnim.Play("activate", 0, 0f);
				__state.gemRenderer.material.EnableKeyword("_EMISSION");
				__state.gemRenderer.material.SetColor("_EmissionColor", Color.black);
				Tween.ShaderColor(__state.gemRenderer.material, "_EmissionColor", Color.white, 2f, 0f, Tween.EaseIn, Tween.LoopType.None, null, null, true);
				yield return new WaitForSeconds(0.25f);
				AudioController.Instance.PlaySound2D("reverse_shorter", MixerGroup.None, 1f, 0f, null, null, null, null, false);
				yield return new WaitForSeconds(1.25f);
				Singleton<UIManager>.Instance.Effects.GetEffect<ScreenColorEffect>().SetColor(GameColors.Instance.nearWhite);
				Singleton<UIManager>.Instance.Effects.GetEffect<ScreenColorEffect>().SetAlpha(0f);
				Singleton<UIManager>.Instance.Effects.GetEffect<ScreenColorEffect>().SetIntensity(1f, 20f);
				if (RunState.Run.regionTier == 3)
                {
					GameObject.Find("DungeonFloor").transform.Find("BrickGround").gameObject.SetActive(false);
					Singleton<FirstPersonController>.Instance.GetComponentInChildren<Camera>().farClipPlane = 75f;
					GameObject.Find("Player").transform.Find("Directional Light").gameObject.GetComponent<Light>().intensity = 0;
				}
				yield return new WaitForSeconds(0.25f);
				float x = GameObject.Find("PixelCameraParent").transform.position.x;
				float z = GameObject.Find("PixelCameraParent").transform.position.z;
				GameObject.Find("PixelCameraParent").transform.position = new Vector3(x, 7f, z);
				Tween.Position(GameObject.Find("PixelCameraParent").transform, new Vector3(x, 7f, z), 0.1f, 0.5f);
				Tween.Rotation(GameObject.Find("PixelCameraParent").transform, Quaternion.Euler(0, 0, 0), 0.1f, 0.5f);
				//__state.gooRoom.SetActive(true);
				Singleton<FirstPersonController>.Instance.SetZone(__state.teleportTarget, true);
				MagSave.SaveNode(__state.teleportTarget.gameObject.name);
				File.WriteAllText(SaveManager.SaveFolderPath + "MagnificusModSave.gwsave", SaveManager.ToJSON(MagSave.GetNodeStuff(false, false)));
				SaveManager.SaveToFile();
				Singleton<FirstPersonController>.Instance.MoveLocked = (Singleton<FirstPersonController>.Instance.LookLocked = false);
				Singleton<InteractionCursor>.Instance.InteractionDisabled = false;
				AudioController.Instance.SetLoopVolumeImmediate(0f, 0);
				__state.gemAnim.Play("idle", 0, 0f);
				__state.gemRenderer.material.DisableKeyword("_EMISSION");
				__state.enabled = true;
				__state.zoomInteractable.enabled = true;
				__state.zoomInteractable.SetEnabled(true);
				Singleton<UIManager>.Instance.Effects.GetEffect<ScreenColorEffect>().SetIntensity(0f, 1f);
				yield break;
			}
		}

		[HarmonyPatch(typeof(GemPedestal3D), "PuzzleIsSolved")]
		public class pedestalSolutionFix
		{
			public static bool Prefix(ref GemPedestal3D __instance, ref bool __result)
			{
				for (int i = 0; i < __instance.gameObject.GetComponent<BossTeleporter3D>().rotators2.Count; i++)
				{
					if (__instance.gameObject.GetComponent<BossTeleporter3D>().rotators2[i].IconIndex != __instance.gameObject.GetComponent<BossTeleporter3D>().Solution[i])
					{
						__result = false;
						return false;
					}
				}
				__result = true;
				return false;
			}
		}

		public static bool Playing = false;
		public static bool SetUp = false;

		[HarmonyPatch(typeof(GemPedestal3D), "ManagedUpdate")]
		public class showTutorial
		{
			public static void Prefix(ref GemPedestal3D __instance)
			{
				if (!SetUp && __instance.zoomInteractable.Zoomed)
                {
					SetUp = true;
					foreach (BossPedestalRotator rotator in __instance.gameObject.GetComponent<BossTeleporter3D>().rotators2)
                    {
						__instance.StartCoroutine(rotator.deleteTheUseless(rotator.gameObject));

					}
				}
				if (!SavedVars.LearnedMechanics.Contains("pedestal;") && __instance.zoomInteractable.Zoomed && !Playing)
				{
					Playing = true;
					Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(MagnificusMod.Generation.pedestalDialogue());
				}
            }
        }

		[HarmonyPatch(typeof(GemPedestal3D), "Start")]
		public class shutUpWeHaveNewRotators
		{
			public static bool Prefix(ref GemPedestal3D __instance)
			{
				SetUp = false;
				if (SceneLoader.ActiveSceneName == "finale_magnifcius") { return false; }
				return true;
			}

		}

    }
}
