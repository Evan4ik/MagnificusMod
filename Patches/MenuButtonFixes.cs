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
using MagnificusMod;

namespace MagnificusMod
{

    class MenuButtonFixes
    {
		public static bool viewingDeck = false;

		[HarmonyPatch(typeof(MenuController), "Start")]
		public class MenuButoon
		{
			public static void Prefix(ref MenuController __instance)
			{
				if (string.IsNullOrEmpty(SavedVars.LearnedMechanics))
				{
					SavedVars.LearnedMechanics = "";
					SaveManager.SaveToFile(false);
				}
				if (SceneLoader.ActiveSceneName == "Start")
				{
					if (KayceeStorage.IsMagRun)
					{
						KayceeStorage.IsMagRun = false;
					}

					GameObject cardRow = __instance.transform.Find("CardRow").gameObject;
					bool doesAscensionCardExist = cardRow.GetComponent<StartMenuAscensionCardInitializer>().menuCards.Count >= 6;

					float xPosition = doesAscensionCardExist ? 1.603f : 1.373f;
					if (Harmony.HasAnyPatches("arackulele.inscryption.grimoramod"))
					{
						xPosition = doesAscensionCardExist ? 2.063f : 1.603f;
					}
					MenuCard menuCardMagnificus = GameObject.Instantiate(
						ResourceBank.Get<MenuCard>("Prefabs/StartScreen/StartScreenMenuCard"),
						new Vector3(xPosition, -0.77f, 0),
						Quaternion.identity,
						cardRow.transform
					);
					menuCardMagnificus.name = "MenuCard_Magnificus";

					Sprite sprite = new Sprite();
					Texture2D image = Tools.getImage("menucard_magnificus.png");
					sprite = Sprite.Create(image, new Rect(0f, 0f, 42f, 56f), new Vector2(0.5f, 0.5f));
					menuCardMagnificus.GetComponent<SpriteRenderer>().sprite = sprite;
					menuCardMagnificus.menuAction = MenuAction.Continue;
					menuCardMagnificus.titleText = "New Magnificus Run";

					if (doesAscensionCardExist)
					{
						xPosition -= 0.22f;//1.383 -0.77 0
					}
					//menuCardMagnificus.transform.position = new Vector3(3, -0.77f, 0);
					__instance.cards.Add(menuCardMagnificus);
				}
				else if (SceneLoader.ActiveSceneName == "finale_magnificus")
				{
					if (true)
					{
						var libraryCard = __instance.cards.Single(card => card.menuAction == MenuAction.Library);
						GameObject.Destroy(libraryCard.transform.Find("GlitchedVersion").gameObject);
						libraryCard.name = "MenuCard_Deck";
						libraryCard.GetComponent<SpriteRenderer>().enabled = true;
						libraryCard.menuAction = MenuAction.Options;
						libraryCard.lockBeforeStoryEvent = false;
						libraryCard.lockAfterStoryEvent = false;
						libraryCard.permanentlyLocked = false;
						libraryCard.glitchedCard = null;
						libraryCard.storyEvent = StoryEvent.BasicTutorialCompleted;
						libraryCard.lockedTitleSprite = null;
						libraryCard.titleSprite = null;
						libraryCard.titleText = "VIEW DECK";
						libraryCard.defaultBorderColor = GameColors.instance.darkLimeGreen;
					}
				}
			}
		}

		[HarmonyPatch(typeof(MenuController), "ActivateDeckBuildingUI")]
		public class deckBuildingisforNEERDS
		{
			public static bool Prefix(ref MenuController __instance)
			{
				if (SceneLoader.ActiveSceneName != "finale_magnificus")
				{
					return true;
				}
				__instance.cardLibraryUI.SetActive(true);
				Singleton<GBC.CollectionUI>.Instance.Initialize(RunState.Run.playerDeck.Cards, GBC.CollectionUI.CardDisplayMode.Showcase);
				__instance.DisplayMenuCardTitle(null);
				return false;
			}
		}


		[HarmonyPatch(typeof(MenuController), "OnCardReachedSlot")]
		public class MenuButooon
		{
			public static bool Prefix(ref MenuController __instance, MenuCard card, bool skipTween = false)
			{
				if (card.titleText == "New Magnificus Run")
				{
					if (SaveManager.saveFile.currentScene == "finale_magnificus")
                    {
						string option = "Yes. Erase save.";
						string option2 = "No. Keep save.";
						if (Localization.CurrentLanguage == Language.Spanish || Localization.CurrentLanguage == Language.French || Localization.CurrentLanguage == Language.BrazilianPortuguese || Localization.CurrentLanguage == Language.Italian)
						{
							option = "Yes";
							option2 = "No";
						}
						__instance.Shake(0.01f, 0.25f);
						var instance = __instance;
						bool stop = false;
						__instance.StartCoroutine(Singleton<GBC.TextBox>.Instance.ShowUntilInput("Erase save data and start New Magnificus Run?", GBC.TextBox.Style.Neutral, null, GBC.TextBox.ScreenPosition.OppositeOfPlayer, 0f, true, false, new GBC.TextBox.Prompt(option, option2, delegate (int choice)
						{
							if (choice == 0)
							{
								Plugin.unlockMost();

								MagnificusMod.Generation.minimap = true;
								SavedVars.HasMap = true;
								SavedVars.HasMapIcons = false;
								SaveManager.saveFile.ouroborosDeaths = 0;
								RunState.Run.regionTier = 0;
								File.WriteAllText(SaveManager.SaveFolderPath + "MagnificusModSave.gwsave", SaveManager.ToJSON(MagSave.GetNodeStuff(true, true)));
								MagSave.SaveNode("x4 y7");
								MagSave.SaveLayout("1");
								File.WriteAllText(SaveManager.SaveFolderPath + "MagnificusModSave.gwsave", SaveManager.ToJSON(MagSave.GetNodeStuff(false, false)));
								//__instance.DoingCardTransition = false;
								CustomCoroutine.instance.StartCoroutine(MagnificusMod.Generation.StartGameMagnificus.GetIn());
								stop = true;
							}
							if (!stop)
							{
								instance.Shake(0.01f, 0.25f);
								instance.ResetToDefaultState();
							}
						}), true, Emotion.Neutral));
						SaveManager.saveFile.currentScene = "finale_magnificus";
						return false;
					}
					if (MagnificusMod.Generation.minimap)
					{
						MagnificusMod.Generation.minimap = true;
						SavedVars.HasMapIcons = false;
						SaveManager.SaveToFile();
					}
					RunState.Run.regionTier = 0;
					File.WriteAllText(SaveManager.SaveFolderPath + "MagnificusModSave.gwsave", SaveManager.ToJSON(MagSave.GetNodeStuff(true, true)));
					MagSave.SaveNode("x4 y7");
					MagSave.SaveLayout("1");
					File.WriteAllText(SaveManager.SaveFolderPath + "MagnificusModSave.gwsave", SaveManager.ToJSON(MagSave.GetNodeStuff(false, false)));
					//__instance.DoingCardTransition = false;
					card.transform.parent = __instance.menuSlot.transform;
					card.SetBorderColor(__instance.slottedBorderColor);

					AudioController.Instance.PlaySound2D("crunch_short#1", MixerGroup.None, 0.6f);//1.05

					__instance.Shake(0.015f, 0.3f);
					Tween.Position(card.transform, new Vector3(0, 0.21f, 0), 5f, 0);

					CustomCoroutine.instance.StartCoroutine(MagnificusMod.Generation.StartGameMagnificus.GetIn());
					return true;
				}
				else if (card.titleText == "VIEW DECK")
				{
					AudioController.Instance.PlaySound2D("crunch_short#1", MixerGroup.None, 0.6f, 0f, null, null, null, null, false);
					__instance.Shake(0.01f, 0.25f);
					__instance.StartCoroutine(ViewDeckbutton(card));
					return false;
				}

				return true;
			}
		}


		public static IEnumerator ViewDeckbutton(MenuCard optionsCard, bool ignoreCard = false)
		{
			if (!SavedVars.LearnedMechanics.Contains("tabviewdeck")) { SavedVars.LearnedMechanics += "tabviewdeck;"; SaveManager.SaveToFile(); }

      if (Singleton<RuleBookController>.Instance.rigParent.activeSelf) {
        Singleton<RuleBookController>.Instance.SetShown(false, false);
      }


			Singleton<UIManager>.Instance.SetControlsHintShown(shown: false);
			Singleton<UIManager>.Instance.SetControlsHintShown(shown: false, right: false);
			if (!ignoreCard)
			{
				Singleton<MenuController>.Instance.DoingCardTransition = true;
				float cardPos = SaveManager.saveFile.ascensionActive ? -1.268f : -1.038f;
				yield return Singleton<MenuController>.Instance.TransitionToSlottedState(optionsCard, cardPos, false);
				Singleton<MenuController>.Instance.DoingCardTransition = false;
				Singleton<MenuController>.Instance.DisplayMenuCardTitle(optionsCard);
				Singleton<MenuController>.Instance.ResetToDefaultState();
				GameObject.Find("PauseMenu").GetComponent<PauseMenu3D>().SetPaused(false);
			} else { PauseMenu.pausingDisabled = true; }
			if (Singleton<ViewManager>.Instance.CurrentView == View.FirstPerson && RunState.Run.regionTier < 5 && GameObject.Find("GameTable").transform.position.y < 1 && Singleton<FirstPersonController>.Instance.enabled)
			{

				viewingDeck = true;
				Singleton<ViewManager>.Instance.SwitchToView(View.MapDeckReview);
				MagnificusMod.Generation.lastView = GameObject.Find("Player").GetComponent<FirstPersonController>().LookDirection;
				SaveManager.saveFile.randomSeed += 5;
				MagnificusMod.MagNodes.CustomNodeDeck triggeringNodeData2 = new MagnificusMod.MagNodes.CustomNodeDeck();
				GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().LookAtDirection(LookDirection.North, true);
				GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().enabled = false;
				GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().LookAtDirection(LookDirection.North, true);
				GameObject.Find("Player").GetComponentInChildren<ViewManager>().enabled = true;
				GameObject.Find("Player").GetComponentInChildren<ViewController>().enabled = true;
				GameObject.Find("GameTable").transform.position = new Vector3(GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().currentZone.transform.position.x, -9.72f, GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().currentZone.transform.position.z);
				Tween.Position(GameObject.Find("GameTable").transform, new Vector3(GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().currentZone.transform.position.x, 9.72f, GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().currentZone.transform.position.z), 0.5f, 0.1f, null, Tween.LoopType.None, null, null, true);
				Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(Singleton<MagnificusGameFlowManager>.Instance.TransitionTo(GameState.SpecialCardSequence, triggeringNodeData2, true, true));
				NavigationZone3D currentZone2 = GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().currentZone;
				if (config.isometricMode == true)
				{
					Tween.LocalRotation(GameObject.Find("Player").transform, Quaternion.Euler(0, 0, 0), 0.2f, 0);
					IsometricStuff.moveDisabled = false;
					GameObject.Find("Player").transform.Find("figure").gameObject.SetActive(false);
					GameObject.Find("WallFigure").transform.Find("VisibleParent").Find("Header").Find("IconSprite").gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
				}
			}
			else if (viewingDeck && GameObject.Find("GameTable").transform.position.y > 0)
			{
				viewingDeck = false;
				Singleton<ViewManager>.Instance.SwitchToView(View.MapDeckReview);
				GameObject lifeCounter = GameObject.Find("GameTable").transform.Find("LifePainting").gameObject;
				lifeCounter.GetComponent<SineWaveMovement>().enabled = false;
				lifeCounter.transform.localPosition = new Vector3(7.5f, 16.72f, 3.5f);
				lifeCounter.GetComponent<SineWaveMovement>().originalPosition = new Vector3(7.5f, 16.72f, 3.5f);
				lifeCounter.SetActive(false);
				if (Singleton<DeckSpellBook>.Instance != null)
					GameObject.Destroy(Singleton<DeckSpellBook>.Instance.gameObject);
				GameObject.Find("Player").GetComponentInChildren<ViewManager>().CurrentView = View.FirstPerson;
				Tween.FieldOfView(GameObject.Find("PixelCameraParent").transform.Find("Pixel Camera").gameObject.GetComponent<Camera>(), 65f, 0.5f, 0);
				Tween.Position(GameObject.Find("GameTable").transform, new Vector3(GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().currentZone.transform.position.x, -20f, GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().currentZone.transform.position.z), 0.2f, 0.2f, null, Tween.LoopType.None, null, null, true);
				Tween.LocalPosition(GameObject.Find("tbPillar").transform, new Vector3(0, -5.01f, 0), 0.4f, 0.25f, null, Tween.LoopType.None, null, null, true);
				if (config.isometricMode)
				{
					Singleton<FirstPersonController>.Instance.LookLocked = true;
					Tween.LocalPosition(GameObject.Find("PixelCameraParent").transform, new Vector3(0, 45, -50), 0.25f, 0.4f);
					Tween.LocalRotation(GameObject.Find("PixelCameraParent").transform, Quaternion.Euler(40, 0, 0), 0.25f, 0.4f);
					Tween.LocalRotation(GameObject.Find("Player").transform, Quaternion.Euler(0, (float)Generation.lastView * 90, 0), 0.2f, 0);
				}
				else
                {
					float x = GameObject.Find("PixelCameraParent").transform.position.x;
					float z = GameObject.Find("PixelCameraParent").transform.position.z;
					GameObject.Find("Player").transform.Find("PixelCameraParent").transform.localPosition = new Vector3(0, 7, -6.86f);
					Tween.LocalPosition(GameObject.Find("PixelCameraParent").transform, new Vector3(0, 7, -6.86f), 0f, 0f, null, Tween.LoopType.None, null, null, true);
				}
				Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(enablePlayer());
				if (RunState.Run.regionTier == 2)
				{
					GameObject.Find("lanterns").transform.position = new Vector3(0, 0, 0);
				}
			}
			yield return new WaitForSeconds(1f);
			PauseMenu.pausingDisabled = false;
			yield break;
        }

		public static IEnumerator enablePlayer()
        {
			yield return new WaitForSeconds(0.651f);
			GameObject.Find("Player").GetComponentInChildren<ViewController>().allowedViews = new List<View>();
			Singleton<FirstPersonController>.Instance.LookAtDirection(MagnificusMod.Generation.lastView, false); MagnificusMod.Generation.lastView = LookDirection.North;
			GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().enabled = true;
			Tween.FieldOfView(GameObject.Find("PixelCameraParent").transform.Find("Pixel Camera").gameObject.GetComponent<Camera>(), 65f, 0.05f, 0);
			if (config.isometricMode == true)
			{
				IsometricStuff.moveDisabled = false;
				GameObject.Find("Player").transform.Find("figure").gameObject.SetActive(true);
			}
			yield break;
        }

		[HarmonyPatch(typeof(PauseMenu), "LateUpdate")]
		public class ViewDeckKeybind
		{
			public static bool Prefix(ref PauseMenu __instance)
			{
				if (SceneLoader.ActiveSceneName != "finale_magnificus") { return true; }
				if (!PauseMenu.pausingDisabled && !(Singleton<InteractionCursor>.Instance && !Singleton<InteractionCursor>.Instance.gameObject.activeSelf))
				{
					if (!__instance.Paused)
					{
						if (InputButtons.GetButtonDown(Button.Menu))
						{
							__instance.SetPaused(true);
							return false;
						} else if (InputButtons.GetButtonDown(Button.AltMenu))
                        {
							__instance.StartCoroutine(ViewDeckbutton(null, true));
							return false;
                        }
					}
					else if (!__instance.Unpausing && !__instance.menuController.TransitioningToScene)
					{
						if (InputButtons.GetButtonDown(Button.Menu) || InputButtons.GetButtonDown(Button.AltMenu) || InputButtons.GetButtonDown(Button.Cancel))
						{
							__instance.UnPause();
						}
						__instance.closeMenuInteractable.gameObject.SetActive(!__instance.menuController.CardInSlot);
						if (InputButtons.GetButtonDown(Button.Select) && __instance.ActivePauseCursor.CurrentInteractable == __instance.closeMenuInteractable)
						{
							__instance.UnPause();
						}
					}
				}
				return false;
			}
		}

			[HarmonyPatch(typeof(DeckInfo), "InitializeAsPlayerDeck")]
		public class InitializeDeck
		{
			public static bool Prefix(ref DeckInfo __instance)
			{
				if (SaveManager.saveFile.currentScene == "finale_magnificus" || SceneLoader.ActiveSceneName == "finale_magnificus")
				{
					/*if (SavedVars.LearnedMechanics.Contains("druid;"))
					{
						__instance.AddCard(CardLoader.GetCardByName("mag_druid"));
					}
					else
					{
						__instance.AddCard(CardLoader.GetCardByName("mag_wolf"));
					}*/
					__instance.AddCard(CardLoader.GetCardByName("JuniorSage"));
					__instance.AddCard(CardLoader.GetCardByName("RubyGolem"));
					__instance.AddCard(CardLoader.GetCardByName("FlyingMage"));
					__instance.AddCard(CardLoader.GetCardByName("Pupil"));
					return false;
				}
				return true;
			}
		}

		[HarmonyPatch(typeof(GBC.OptionsUI), "OnApplyGraphicsButtonPressed")]
		public class changeClippingPlaneonApply
		{
			public static void Prefix(ref GBC.OptionsUI __instance)
			{
				if (SceneLoader.ActiveSceneName == "finale_magnificus")
                {
					if (RunState.Run.regionTier == 1)
					{
						Singleton<FirstPersonController>.Instance.GetComponentInChildren<Camera>().farClipPlane = 320f - Generation.getClippingPlaneQualityAdjustment(__instance.qualityField.value);
					}
					else if (RunState.Run.regionTier == 2)
					{
						Singleton<FirstPersonController>.Instance.GetComponentInChildren<Camera>().farClipPlane = 325f - Generation.getClippingPlaneQualityAdjustment(__instance.qualityField.value);
					}
					else if (RunState.Run.regionTier == 3)
					{
						Singleton<FirstPersonController>.Instance.GetComponentInChildren<Camera>().farClipPlane = 175f - (Generation.getClippingPlaneQualityAdjustment(__instance.qualityField.value) / 2);
					}
				}
			}
		}
		/* maybe one day this will work
		[HarmonyPatch(typeof(StartScreenThemeSetter), "Start")]
		public class addMagnificusTheme
		{
			public static bool Prefix(ref StartScreenThemeSetter __instance)
			{
				if (SaveManager.saveFile.currentScene != "finale_magnificus") return true;
				
				var magTheme = __instance.themes[3];
				magTheme.fillColor = new Color(0.752f, 0.2f, 0.427f);

				magTheme.bgSpriteWide = Tools.getSprite("startscreen_background_magnificus.png");
				magTheme.bgSpriteBottom = magTheme.bgSpriteWide;
				magTheme.bgSpriteTop = magTheme.bgSpriteWide;
				magTheme.slotSpriteDefault = Tools.getSprite("startscreen_slot_magnificus.png");
				magTheme.slotSpriteMediumlight = Tools.getSprite("startscreen_slot_mediumlighted_magnificus.png");
				magTheme.slotSpriteHighlight = Tools.getSprite("startscreen_slot_highlighted_magnificus.png");

				__instance.SetTheme(magTheme);
				return false;
			}
		}*/
	}
}
