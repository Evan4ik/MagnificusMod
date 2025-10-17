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
    class BattleTransitionFixes
    {
		[HarmonyPatch(typeof(GameFlowManager), "TransitionTo")]
		public class MapFixJR
		{
			public static bool Prefix(ref GameFlowManager __instance, ref GameState gameState)
			{
				if (SceneLoader.ActiveSceneName == "finale_magnificus" && RunState.Run.regionTier == 2) {GameObject.Find("lanterns").transform.position = new Vector3(0, 35, 0); }
				if (SceneLoader.ActiveSceneName == "finale_magnificus" && RunState.Run.regionTier == 3) { GameObject.Find("GameTable").transform.Find("light").Find("floorLight").gameObject.SetActive(true); }
				if (gameState == GameState.Map && SceneLoader.ActiveSceneName == "finale_magnificus")
				{
					__instance.SceneSpecificTransitionTo(GameState.Map, false);
					return false;
				}

				return true;
			}
		}

		[HarmonyPatch(typeof(GameFlowManager), "SceneSpecificTransitionTo")]
		public class MapFix
		{
			public static bool Prefix(ref GameState gameState, ref GameFlowManager __instance)
			{
				if (SceneLoader.ActiveSceneName != "finale_magnificus")
				{
					return true;
				}
				if (gameState == GameState.Map)
				{
					MenuButtonFixes.viewingDeck = false;

					SaveManager.saveFile.randomSeed += 3;
					MagSave.GetSideDeck();
					GameObject gameObject = GameObject.Find("Player");
					NavigationZone3D currentZone = gameObject.GetComponentInChildren<FirstPersonController>().currentZone;
					string name = currentZone.name;

					GameObject.Find(name).GetComponent<NavigationZone3D>().events.Clear();
					List<string> list = new List<string>
					{
						"Wizard3DPortrait_JuniorSage",
						"Wizard3DPortrait_OrangeMage",
						"Wizard3DPortrait_BlueMage",
						"Wizard3DPortrait_RubyGolem"
					};

					foreach (string n in list)
					{
						bool flag2 = GameObject.Find("GameTable").transform.Find(n) != null;
						if (flag2)
						{
							GameObject npc = GameObject.Find("GameTable").transform.Find(n).gameObject;
							if (npc.transform.position.y > 1)
							{
								float why = npc.transform.position.y;
								if (why > -1)
								{
									Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(MagnificusMod.Generation.SpinThisMan(npc, npc.transform.rotation.eulerAngles.y));
								}

							}
							else
							{
								npc.transform.position = new Vector3(0, -900, 0);
							}
						}
					}

					bool flag3 = GameObject.Find(name).transform.Find("nodeIcon") != null;
					if (flag3)
					{
						MagnificusMod.Generation.nodes.Remove(GameObject.Find(name).transform.Find("nodeIcon").gameObject);
						GameObject.Destroy(GameObject.Find(name).transform.Find("nodeIcon").gameObject);
					}
					Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(MagnificusMod.Generation.WaitThenEnablePlayer(2f));

					Singleton<MagnificusLifeManager>.Instance.PlayerCounter.gameObject.SetActive(false);
					Singleton<MagnificusLifeManager>.Instance.OpponentCounter.gameObject.SetActive(false);

					bool battleRoom = false;
					try
					{
						if (GameObject.Find("battlebg").activeSelf)
						{
							battleRoom = true;
						}
					}
					catch { }
					if (config.isometricMode == true)
					{
						Singleton<FirstPersonController>.Instance.enabled = false;
						float delay = battleRoom ? 1.25f : 0.4f;
						__instance.StartCoroutine(Generation.unIsometricTransition(delay));
          }
          if (battleRoom)
					{
						if (SaveManager.saveFile.ascensionActive && MagnificusMod.Generation.challenges.Contains("FadingMox"))
						{
							KayceeStorage.FleetingLife = Singleton<MagnificusLifeManager>.Instance.playerLife;
						}

						if (Singleton<SpellPile>.Instance != null)
							Singleton<SpellPile>.Instance.senableCards(false);
            

            GameObject.Find("NavigationGrid").transform.position = Vector3.zero;
          
            for (int i = 0; i < GameObject.Find("scenery").transform.childCount; i++) {
              GameObject.Find("scenery").transform.GetChild(i).gameObject.SetActive(true);
            }


            Tween.LocalScale(GameObject.Find("battlebg").transform,  new Vector3(500, 500, 500), 2.5f, 0f, Tween.EaseOut);
						GameObject.Find("GameEnvironment").transform.Find("walls").gameObject.SetActive(true);
						//GameObject.Find("GameEnvironment").transform.Find("walls").position = new Vector3(GameObject.Find("walls").transform.position.x, 70.5f, GameObject.Find("walls").transform.position.z);
						Tween.Position(GameObject.Find("walls").transform, new Vector3(GameObject.Find("walls").transform.position.x, 0, GameObject.Find("walls").transform.position.z), 0.75f, 0.2f);
						Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(MagnificusMod.Generation.WaitThenDestroy(GameObject.Find("battlebg").gameObject, 2.65f));
						if (RunState.Run.regionTier == 0)
						{
							GameObject.Find("GameEnvironment").transform.Find("walls layer 2").gameObject.SetActive(true);
							GameObject.Find("GameEnvironment").transform.Find("roof").gameObject.SetActive(true);
							GameObject.Find("GameEnvironment").transform.Find("floor").gameObject.SetActive(true);
						}
					}
					if (RunState.Run.regionTier == 2)
					{
						Singleton<FirstPersonController>.Instance.GetComponentInChildren<Camera>().farClipPlane = 325f - Generation.getClippingPlaneQualityAdjustment();
						GameObject.Find("lanterns").transform.position = new Vector3(0, 0, 0);
						GameObject.Find("GameTable").transform.Find("light").Find("deckLight").gameObject.GetComponent<Light>().intensity = 0;
						GameObject.Find("GameTable").transform.Find("light").gameObject.GetComponent<Light>().intensity = 0;
					}
					else if (RunState.Run.regionTier == 1)
					{
						Singleton<FirstPersonController>.Instance.GetComponentInChildren<Camera>().farClipPlane = 320f - Generation.getClippingPlaneQualityAdjustment();
					} else if (RunState.Run.regionTier == 3) 
					{ 
						GameObject.Find("GameTable").transform.Find("light").Find("floorLight").gameObject.SetActive(false); 
					}
					Tween.Position(GameObject.Find("GameTable").transform, new Vector3(GameObject.Find("GameTable").transform.position.x, -20f, GameObject.Find("GameTable").transform.position.z), 0.6f, 1.21f, null, Tween.LoopType.None, null, null, true);
					Tween.LocalPosition(GameObject.Find("tbPillar").transform, new Vector3(0, -5.01f, 0), 0.6f, 0.2f, null, Tween.LoopType.None, null, null, true);

					
					MagSave.ClearNode(name);

					if (GameObject.Find(name).transform.childCount > 0 && GameObject.Find(name).transform.GetChild(0).gameObject.name.Contains("nodeIconBL"))
					{
						string[] theSplit = GameObject.Find(name).transform.GetChild(0).gameObject.name.Split(';');
						for (int i = 1; i < 9; i++)
						{
							try
							{
								GameObject.Find(theSplit[0] + ";N" + i).transform.parent.gameObject.GetComponent<NavigationZone3D>().events.Clear();
								GameObject.Destroy(GameObject.Find(theSplit[0] + ";N" + i));
								MagSave.ClearNode(GameObject.Find(theSplit[0] + ";N" + i).transform.parent.gameObject.name);
							}
							catch { }
						}
					}
					GameObject.Find("Player").transform.Find("Directional Light").gameObject.SetActive(true);
					MagSave.SaveNode(name);
					File.WriteAllText(SaveManager.SaveFolderPath + "MagnificusModSave.gwsave", SaveManager.ToJSON(MagSave.GetNodeStuff(false, false)));
					SaveManager.SaveToFile();

					if (RunState.Run.regionTier != 0 && !GameObject.Find("GameTable").transform.Find("CardBattle_Magnificus").gameObject.activeSelf)
					{
						SavedVars.NodesCleared++;
						if (SavedVars.HasMapIcons && SavedVars.HasMap) { Generation.CreateMiniMap(true); }
					}

					if (GameObject.Find("GameTable").transform.Find("CardBattle_Magnificus").gameObject.activeSelf)
					{
						for (int i = 0; i < 4; i++)
						{
							if (GameObject.Find("OpponentSlots").transform.GetChild(i).childCount > 5)
							{
								for (int b = GameObject.Find("OpponentSlots").transform.GetChild(i).childCount - 1; b > 4; b--)
								{
									GameObject.DestroyImmediate(GameObject.Find("OpponentSlots").transform.GetChild(i).GetChild(b).gameObject);
								}
							}
							if (GameObject.Find("PlayerSlots").transform.GetChild(i).childCount > 5)
							{
								for (int b = GameObject.Find("PlayerSlots").transform.GetChild(i).childCount - 1; b > 4; b--)
								{
									GameObject.DestroyImmediate(GameObject.Find("PlayerSlots").transform.GetChild(i).GetChild(b).gameObject);
								}
							}
						}

						try
						{
							GameObject.Find("CombatBell_Magnificus").transform.Find("Anim").gameObject.SetActive(false);
							GameObject.Find("CombatBell_Magnificus").SetActive(false);
							GameObject.Find("WizardBattleDuelDisk").SetActive(false);
							GameObject.Find("Hand").SetActive(false);
							Generation.updateDuelDiskGems(true);
							Singleton<MagnificusResourcesManager>.Instance.gems = new List<GemType>();
						}
						catch { }
					}

					try
					{
						Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(MagnificusMod.Generation.WaitThenDisable(GameObject.Find("CardBattle_Magnificus"), 2.5f));
					}
					catch { }
					if (GameObject.Find("walls").transform.position == new Vector3(0, -90, 9))
					{
						string nodeName = Singleton<FirstPersonController>.Instance.currentZone.gameObject.name;
						string[] x1 = nodeName.Split('x');
						string[] x2 = x1[1].Split(' ');
						int x = int.Parse(x2[0]);
						string[] y = x2[1].Split('y');
						x -= 21;
						Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(MagnificusMod.Generation.warp("x" + x + " y" + y[1], "whiteout"));
						MagSave.SaveNode("x" + x + " y" + y[1]);
						File.WriteAllText(SaveManager.SaveFolderPath + "MagnificusModSave.gwsave", SaveManager.ToJSON(MagSave.GetNodeStuff(false, false)));
						SaveManager.SaveToFile();
					}
					if (RunState.Run.regionTier == 0 && MagSave.layout.Contains("3") && !SavedVars.LearnedMechanics.Contains("druid;") && !SaveManager.saveFile.ascensionActive)
					{
						if (Singleton<ViewManager>.Instance.CurrentView != View.Candles)
						{
							Singleton<FirstPersonController>.Instance.LookAtDirection(LookDirection.South);
							Singleton<FirstPersonController>.Instance.enabled = false;
							Singleton<ViewManager>.Instance.SwitchToView(View.Default, false, true);
							MagSave.SaveNode("x4 y7");
							File.WriteAllText(SaveManager.SaveFolderPath + "MagnificusModSave.gwsave", SaveManager.ToJSON(MagSave.GetNodeStuff(false, false)));
							SaveManager.SaveToFile();
                            Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(Generation.leshyCardGetSequence());
						}
					} else if (RunState.Run.regionTier == 0 && MagSave.layout.Contains("2"))
					{
						if (Singleton<ViewManager>.Instance.CurrentView != View.Candles)
						{
							Singleton<FirstPersonController>.Instance.enabled = false;
							MagSave.SaveNode("x4 y2");
							File.WriteAllText(SaveManager.SaveFolderPath + "MagnificusModSave.gwsave", SaveManager.ToJSON(MagSave.GetNodeStuff(false, false)));
							SaveManager.SaveToFile();
							Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(Generation.dummyWinSequence());
						}
					}

					if (RunState.Run.playerDeck.Cards.Count > 4 && !SavedVars.LearnedMechanics.Contains("tabviewdeck"))
                    {
						Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(showControlHint());
					}

				}
				bool flag9 = StoryEventsData.EventCompleted(StoryEvent.UhOhSpaghettiOh) && RunState.Run.bonelordPuzzleActive;
				if (flag9)
				{
					Singleton<TextDisplayer>.Instance.ShowMessage("whats up", Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
				}
				return false;
			}
		}

		public static IEnumerator showControlHint()
        {
			yield return new WaitForSeconds(2.5f);
			GameObject.Find("ControlsHint_Right").GetComponent<AnimatingSprite>().frames = new List<Sprite> { Plugin.ControlsHintFrames[0], Plugin.ControlsHintFrames[1] };
			Singleton<UIManager>.Instance.SetControlsHintShown(shown: true);
			yield break;
        }


	}
}
