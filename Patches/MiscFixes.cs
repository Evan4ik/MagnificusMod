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
    class MiscFixes
    {
		//rotate the nodes


		[HarmonyPatch(typeof(OilPaintingPuzzle), "RespondsToOtherCardAssignedToSlot")]
		public class oilPainting
		{
			public static bool Prefix(ref bool __result, PlayableCard otherCard)
			{
				__result = false;
				return false;
			}
		}

		[HarmonyPatch(typeof(CardInfo), "HasConduitAbility")]
		public class weirderror
		{
			public static bool Prefix(ref bool __result)
			{
				if (SceneLoader.ActiveSceneName == "finale_magnificus")
				{
					__result = false;
					return false;
				}
				return true;
			}
		}


		[HarmonyPatch(typeof(CardInfo), "HasCellAbility")]
		public class weirderror2
		{
			public static bool Prefix(ref bool __result)
			{
				if (SceneLoader.ActiveSceneName == "finale_magnificus")
				{
					__result = false;
					return false;
				}
				return true;
			}
		}

		[HarmonyPatch(typeof(RuleBookController), "WaitThenDisableRig")]
		public class weirdrulebookshtuff
		{
			public static void Prefix()
			{
				if (SceneLoader.ActiveSceneName == "finale_magnificus")
				{
					Tween.LocalPosition(GameObject.Find("PixelCameraParent").transform, new Vector3(0, 8.9f, -3.2f), 0.25f, 0.25f);
				}
			}
		}

		[HarmonyPatch(typeof(HammerItem), "SelectionView", MethodType.Getter)]
		public class hammerFix
		{
			public static bool Prefix(ref View __result)
			{
				if (SceneLoader.ActiveSceneName != "finale_magnificus")
				{
					return true;
				}
				__result = View.WizardBattleSlots;
				return false;
			}
		}

		[HarmonyPatch(typeof(HammerItem), "FirstPersonItemPos", MethodType.Getter)]
		public class hammerFix2
		{
			public static bool Prefix(ref Vector3 __result)
			{
				if (SceneLoader.ActiveSceneName != "finale_magnificus")
				{
					return true;
				}
				__result = new Vector3(0, 0.75f, 0);
				return false;
			}
		}

		[HarmonyPatch(typeof(HammerItem), "FirstPersonItemEulers", MethodType.Getter)]
		public class hammerFix2andaHalf
		{
			public static bool Prefix(ref Vector3 __result)
			{
				if (SceneLoader.ActiveSceneName != "finale_magnificus")
				{
					return true;
				}
				__result = new Vector3(0, 0.75f, 0);
				return false;
			}
		}

		[HarmonyPatch(typeof(CombatPhaseManager3D), "VisualizeCardAttackingDirectly")]
		public class attackDirectlyFix
		{
			public static bool Prefix()
			{
				if (SceneLoader.ActiveSceneName == "finale_magnificus")
				{
					return false;
				}
				return true;
			}
		}

		[HarmonyPatch(typeof(FinaleWizardBattleOpponent), "TemplateToTurn")]
		public class fixDanielsCode3TheMovieTheGame
		{
			public static bool Prefix(ref FinaleWizardBattleOpponent __instance, ref List<CardInfo> __result, List<string> turnTemplate)
			{
				List<CardInfo> list = new List<CardInfo>();
				foreach (string text in turnTemplate)
				{
					bool flag = text == "#GEM";
					if (flag)
					{
						float value = UnityEngine.Random.value;
						bool flag2 = value > 0.33f;
						if (flag2)
						{
							list.Add(CardLoader.GetCardByName("mag_greenmox"));
						}
						else
						{
							bool flag3 = value > 0.66f;
							if (flag3)
							{
								list.Add(CardLoader.GetCardByName("mag_rubymox"));
							}
							else
							{
								list.Add(CardLoader.GetCardByName("mag_bluemox"));
							}
						}
					}
					else
					{
						list.Add(CardLoader.GetCardByName(text));
					}
				}
				__result = list;
				__instance.turnTemplates = new List<List<string>>
				{
					new List<string>
					{
						"mag_orangemage"
					},
					new List<string>
					{
						"mag_orangemage"
					},
					new List<string>
					{
						"mag_rubygolem"
					},
					new List<string>
					{
						"mag_jrsage"
					},
					new List<string>
					{
						"#GEM",
						"mag_orangemage"
					},
					new List<string>
					{
						"#GEM",
						"mag_jrsage"
					},
					new List<string>
					{
						"#GEM"
					}
				};
				__instance.turnTemplatesPhase2 = new List<List<string>>
				{
					new List<string>
					{
						"mag_orangemage"
					},
					new List<string>
					{
						"mag_gemfiend"
					},
					new List<string>
					{
						"#GEM",
						"mag_orangemage"
					},
					new List<string>
					{
						"#GEM",
						"mag_gemfiend"
					},
					new List<string>
					{
						"#GEM"
					},
					new List<string>
					{
						"#GEM",
						"#GEM"
					}
				};
				return false;
			}
		}

		[HarmonyPatch(typeof(FinaleWizardBattleOpponent), "ExtendTurnPlan")]
		public class DanielMullinsIFuckingHate2
		{
			public static bool Prefix()
			{
				return false;
			}
		}

		[HarmonyPatch(typeof(EncounterBuilder), "BuildTerrainCondition")]
		public class dumbasserror
		{
			public static bool Prefix(ref EncounterData.StartCondition __result)
			{
				if (SceneLoader.ActiveSceneName == "finale_magnificus")
				{
					__result = new EncounterData.StartCondition();
					return false;
				}
				return true;
			}
		}

		[HarmonyPatch(typeof(ConduitCircuitManager), "GetConduitsForSlot")]
		public class dumbasserror2
		{
			public static bool Prefix(ref List<PlayableCard> __result)
			{
				if (SceneLoader.ActiveSceneName == "finale_magnificus")
				{
					__result = new List<PlayableCard>();
					return false;
				}
				return true;
			}
		}

		[HarmonyPatch(typeof(ConduitCircuitManager), "UpdateCircuits")]
		public class dumbasserror2andahalf
		{
			public static bool Prefix()
			{
				if (SceneLoader.ActiveSceneName == "finale_magnificus")
				{
					return false;
				}
				return true;
			}
		}

				[HarmonyPatch(typeof(ConduitCircuitManager), "UpdateCircuitsForSlots")]
		public class dumbasserror3
		{
			public static bool Prefix()
			{
				if (SceneLoader.ActiveSceneName == "finale_magnificus")
				{
					return false;
				}
				return true;
			}
		}

		[HarmonyPatch(typeof(ViewController), "SwitchToControlMode")]
		public class SwitchViewStuff
		{
			public static bool Prefix(ref ViewController __instance, ViewController.ControlMode mode, bool immediate = false)
			{
				bool flag = mode == ViewController.ControlMode.WizardBattleDefault || mode == ViewController.ControlMode.WizardBattleChooseDraw;
				bool result;
				if (flag)
				{
					__instance.allowedViews = new List<View>
					{
						View.WizardBattleHand,
						View.WizardBattleSlots,
						View.Default,
						View.OpponentQueue
					};
					__instance.altTransitionInputs = new List<ViewController.ViewTransitionInput>
					{
						new ViewController.ViewTransitionInput(View.WizardBattleSlots, View.WizardBattlePiles, Button.LookRight),
						new ViewController.ViewTransitionInput(View.WizardBattleHand, View.WizardBattlePiles, Button.LookRight),
						new ViewController.ViewTransitionInput(View.WizardBattlePiles, View.WizardBattleSlots, Button.LookLeft),
						new ViewController.ViewTransitionInput(View.WizardBattlePiles, View.WizardBattleSlots, Button.LookDown),
						new ViewController.ViewTransitionInput(View.OpponentQueue, View.Default, Button.LookDown),
						new ViewController.ViewTransitionInput(View.Default, View.OpponentQueue, Button.LookUp)
					};
					result = false;
				}
				else
				{
					bool flag2 = mode == ViewController.ControlMode.MapNoDeckReview && SceneLoader.ActiveSceneName == "finale_magnificus";
					if (flag2)
					{
						__instance.allowedViews = new List<View>
						{
							View.MapDeckReview,
							View.Candles
						};
						__instance.altTransitionInputs = new List<ViewController.ViewTransitionInput>
						{
							new ViewController.ViewTransitionInput(View.MapDeckReview, View.Candles, Button.LookRight),
							new ViewController.ViewTransitionInput(View.Candles, View.MapDeckReview, Button.LookLeft)
						};
						result = false;
					}
					else
					{
						result = true;
					}
				}
				return result;
			}
		}
	}
}
