using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using APIPlugin;
using InscryptionAPI.Card;
using InscryptionCommunityPatch.Card;
using BepInEx.Bootstrap;
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
using PackManager = Infiniscryption.PackManagement.PackManager;
using GBC;
using Infiniscryption.PackManagement;
using InscryptionAPI.Ascension;
using InscryptionAPI.Guid;


namespace MagnificusMod
{
    class KayceeFixes
    {
		public static CardTemple currentState = KayceeStorage.ScreenState;

		[HarmonyPatch(typeof(AscensionMenuScreens), "TransitionToGame")]
		[HarmonyPrefix]
		private static void FixStarters(bool newRun)
		{
			if (newRun && AscensionUnlockSchedule.NumStarterDecksUnlocked(AscensionSaveData.Data.challengeLevel) <= 1)
			{
				AscensionSaveData.Data.currentStarterDeck = (KayceeStorage.IsMagRun ? StarterDecks.DEFAULT_STARTER_DECK : "Vanilla");
			}
		}

		/*public static void Kill(CardTemple temple)
		{
			if (BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey("zorro.inscryption.infiniscryption.packmanager"))
			{
				List<string> list = new List<string>
				{
					"BlueMage",
					"BlueMage_Fused",
					"FlyingMage",
					"ForceMage",
					"PracticeMage",
					"GemFiend",
					"MageKnight",
					"JuniorSage",
					"MarrowMage",
					"GreenMage",
					"MasterOrlu",
					"MasterGoranj",
					"MasterBleene",
					"MoxDualGO",
					"MoxDualBG",
					"MoxDualOB",
					"MoxEmerald",
					"MoxRuby",
					"MoxSapphire",
					"MoxTriple",
					"OrangeMage",
					"MuscleMage",
					"StimMage",
					"PracticeMageSmall",
					"Pupil",
					"RubyGolem"
				};
				foreach (string text in list)
				{
					CardInfo cardInfo = CardExtensions.CardByName(CardManager.BaseGameCards, text);
					cardInfo.temple = temple;
				}
			}
		}*/

		public static IEnumerator magChallengePos0()
		{
			yield return new WaitForSeconds(0.25f);
			ChallengeManagement.setUpMagChallengePos();
			yield break;
		}


		public static IEnumerator showP03Button()
		{
			yield return new WaitForSeconds(0.5f);
			AdjustAscensionMenuItemsSpacing itemsSpacing = GameObject.FindObjectOfType<AdjustAscensionMenuItemsSpacing>();
			AscensionMenuInteractable menuText = itemsSpacing.menuItems[0].GetComponent<AscensionMenuInteractable>();
			AscensionMenuScreenTransition transitionController = Singleton<AscensionMenuScreens>.Instance.startScreen.GetComponent<AscensionMenuScreenTransition>();
			List<GameObject> onEnableRevealedObjects = transitionController.onEnableRevealedObjects;
			GameObject p03Button = Enumerable.Single<GameObject>(onEnableRevealedObjects, (GameObject obj) => obj.name == "Menu_New_P03");
			bool hasp3 = false;
			foreach (Transform item in itemsSpacing.menuItems)
			{
				if (item.gameObject.name == "Menu_New_P03")
				{
					hasp3 = true;
				}
				else
				{
					if (item.gameObject.name == "Continue")
					{
						item.localPosition = new Vector3(0f, -0.33f, 0f);
					}
				}
			}
			if (!hasp3)
			{
				itemsSpacing.menuItems.Insert(1, p03Button.transform);
			}
			yield break;
		}

		public static void GetChallenges()
		{
			KayceeStorage.ActiveChallenges = "";
			if (AscensionSaveData.Data.ChallengeIsActive(ChallengeManagement.RandomSidedeck))
			{
				KayceeStorage.ActiveChallenges += "RandomSidedeck,";
			}
			if (AscensionSaveData.Data.ChallengeIsActive(ChallengeManagement.WeakBleach))
			{
				KayceeStorage.ActiveChallenges += "WeakBleach,";
			}
			if (AscensionSaveData.Data.ChallengeIsActive(ChallengeManagement.TurnWipeout))
			{
				KayceeStorage.ActiveChallenges += "TurnWipeout,";
			}
			if (AscensionSaveData.Data.ChallengeIsActive(ChallengeManagement.MoreHpOpponent))
			{
				KayceeStorage.ActiveChallenges += "MoreHpOpponent,";
			}
			if (AscensionSaveData.Data.ChallengeIsActive(ChallengeManagement.DyingBreath))
			{
				KayceeStorage.ActiveChallenges += "DyingBreath,";
			}
			if (AscensionSaveData.Data.ChallengeIsActive(ChallengeManagement.MasterMagnus))
			{
				KayceeStorage.ActiveChallenges += "MasterMagnus,";
			}
			if (AscensionSaveData.Data.ChallengeIsActive(ChallengeManagement.MasterBosses))
			{
				KayceeStorage.ActiveChallenges += "MasterBosses,";
			}
			if (AscensionSaveData.Data.ChallengeIsActive(ChallengeManagement.GemDependantDeck))
			{
				KayceeStorage.ActiveChallenges += "GemDependantDeck,";
			}
			if (AscensionSaveData.Data.ChallengeIsActive(ChallengeManagement.ShieldedMox))
			{
				KayceeStorage.ActiveChallenges += "ShieldedMox,";
			}
			if (AscensionSaveData.Data.ChallengeIsActive(ChallengeManagement.FadingMox))
			{
				KayceeStorage.ActiveChallenges += "FadingMox,";
			}
			if (AscensionSaveData.Data.ChallengeIsActive(ChallengeManagement.IronMaiden))
			{
				KayceeStorage.ActiveChallenges += "IronMaiden,";
			}
			if (AscensionSaveData.Data.ChallengeIsActive(ChallengeManagement.PaintedSigils))
			{
				KayceeStorage.ActiveChallenges += "PaintedSigils,";
			}
			if (AscensionSaveData.Data.ChallengeIsActive(ChallengeManagement.ItemSpells))
			{
				KayceeStorage.ActiveChallenges += "SmallSpellbook,";
			}
			if (AscensionSaveData.Data.activeChallenges.Count < 1)
			{
				KayceeStorage.ActiveChallenges = "none,";
			}
		}

		private const string PluginGuid = "silenceman.inscryption.magnificusmodstarterdecks";

		private const string MagModGuid = "silenceman.inscryption.MagnificusMod";

		private const string PluginName = "MagnificusModstarterdecks";

		private const string PluginVersion = "1.0.0";

		[HarmonyAfter(new string[]
		{
			"arackulele.inscryption.grimoramod",
			"zorro.inscryption.infiniscryption.p03kayceerun"
		})]
		[HarmonyPatch]
		public static class StarterDecks
		{
			public static string DEFAULT_STARTER_DECK { get; private set; }

			public static StarterDeckInfo CreateStarterDeckInfo(string title, string path, params string[] cards)
			{
				StarterDeckInfo starterDeckInfo = ScriptableObject.CreateInstance<StarterDeckInfo>();
				starterDeckInfo.iconSprite = Tools.getSprite(path);
				starterDeckInfo.title = title;
				starterDeckInfo.name = "Magnificus_" + title;
				starterDeckInfo.cards = Enumerable.ToList<CardInfo>(Enumerable.Select<string, CardInfo>(cards, new Func<string, CardInfo>(CardLoader.GetCardByName)));
				return starterDeckInfo;
			}

			public static void RegisterStarterDecks()
			{
				StarterDeckManager.FullStarterDeck starterDeck = StarterDeckManager.Add("silenceman.inscryption.magnificusmodstarterdecks", StarterDecks.CreateStarterDeckInfo("MagVanilla;0", "starterdeck_icon_vanilla.png", new string[]
				{
					"JuniorSage",
					"RubyGolem",
					"FlyingMage",
					"Pupil"
				}), 0);
				StarterDecks.DEFAULT_STARTER_DECK = starterDeck.Info.name;
				StarterDeckManager.FullStarterDeck emeraldDeck = StarterDeckManager.Add("silenceman.inscryption.magnificusmodstarterdecks", StarterDecks.CreateStarterDeckInfo("Goranj;1", "starterdeck_icon_emerald.png", new string[]
				{
					"MuscleMage",
					"mag_alchemist",
					"OrangeMage",
					"RubyGolem"
				}), 0);
				StarterDeckManager.FullStarterDeck rubyDeck = StarterDeckManager.Add("silenceman.inscryption.magnificusmodstarterdecks", StarterDecks.CreateStarterDeckInfo("Orlu;1", "starterdeck_icon_ruby.png", new string[]
				{
					"MageKnight",
					"mag_snipesage",
					"mag_magimorph",
					"ForceMage"
				}), 0);
				StarterDeckManager.FullStarterDeck sapphireDeck = StarterDeckManager.Add("silenceman.inscryption.magnificusmodstarterdecks", StarterDecks.CreateStarterDeckInfo("Bleene;1", "starterdeck_icon_sapphire.png", new string[]
				{
					"GemFiend",
					"BlueMage",
					"GreenMage",
					"mag_emeraldfiend"
				}), 0);
				StarterDeckManager.FullStarterDeck manaDeck = StarterDeckManager.Add("silenceman.inscryption.magnificusmodstarterdecks", StarterDecks.CreateStarterDeckInfo("Mana;2", "starterdeck_icon_mana.png", new string[]
				{
					"mag_erraticscholar",
					"mag_gemabsorber",
					"mag_gemboundripper",
					"mag_crystalsage"
				}), 0);
				StarterDeckManager.FullStarterDeck spellDeck = StarterDeckManager.Add("silenceman.inscryption.magnificusmodstarterdecks", StarterDecks.CreateStarterDeckInfo("Spell;2", "starterdeck_icon_spell.png", new string[]
				{
					"mag_spellcaster",
					"mag_rubyfiend",
					"mag_bunnymage",
					"mag_gnomespell"
				}), 0);
				StarterDeckManager.FullStarterDeck freeDeck = StarterDeckManager.Add("silenceman.inscryption.magnificusmodstarterdecks", StarterDecks.CreateStarterDeckInfo("Free;3", "starterdeck_icon_free.png", new string[]
				{
					"Pupil",
					"mag_homunculus",
					"mag_moxlarva",
					"mag_maux"
				}), 0);
				StarterDeckManager.FullStarterDeck triMoxDeck = StarterDeckManager.Add("silenceman.inscryption.magnificusmodstarterdecks", StarterDecks.CreateStarterDeckInfo("Trimox;4", "starterdeck_icon_obelisk.png", new string[]
				{
					"mag_multiplymage",
					"mag_multiplymage",
					"mag_jester",
					"mag_erraticscholar"
				}), 0);
				StarterDeckManager.ModifyDeckList += delegate (List<StarterDeckManager.FullStarterDeck> decks)
				{
					CardTemple acceptableTemple = KayceeStorage.ScreenState;
					if (acceptableTemple == CardTemple.Wizard)
					{
						decks.RemoveAll((StarterDeckManager.FullStarterDeck info) => info.Info.cards.FirstOrDefault((CardInfo ci) => ci.temple == acceptableTemple) == null);
						if (config.kayceeProgression == true)
						{
							for (int i = 0; i < decks.Count; i++)
							{
								int level = int.Parse(decks[i].Info.title.Split(';')[1]);

								if (level > KayceeStorage.ChallengeLevel)
								{
									decks.Remove(decks[i]);
									i--;
								}
							}
							if (KayceeStorage.ChallengeLevel < 1)
							{
								decks = new List<StarterDeckManager.FullStarterDeck> { starterDeck };
							}
						}
					}

					return decks;
				};
			}
		}

		[HarmonyPatch]
		public class ChallengeManagement
		{
			public static AscensionChallenge RandomSidedeck { get; private set; }

			public static AscensionChallenge WeakBleach { get; private set; }

			public static AscensionChallenge TurnWipeout { get; private set; }

			public static AscensionChallenge MoreHpOpponent { get; private set; }

			public static AscensionChallenge ItemSpells { get; private set; }

			public static AscensionChallenge DyingBreath { get; private set; }

			public static AscensionChallenge MasterMagnus { get; private set; }

			public static AscensionChallenge MasterBosses { get; private set; }
			public static AscensionChallenge ShieldedMox { get; private set; }

			public static AscensionChallenge FadingMox { get; private set; }

			public static AscensionChallenge GemDependantDeck { get; private set; }

			public static AscensionChallenge IronMaiden { get; private set; }

			public static AscensionChallenge PaintedSigils { get; private set; }

			[HarmonyPatch(typeof(AscensionIconInteractable), "AssignInfo")]
			[HarmonyPostfix]
			private static void ColorsPlease(ref AscensionIconInteractable __instance, AscensionChallengeInfo info)
			{
				if (currentState == CardTemple.Wizard || SceneLoader.ActiveSceneName == "finale_magnificus")
                {
					Color color = new Color(0.75f, 0, 1, 1);
					ColorUtility.TryParseHtmlString("#BF00FF", out color);
					__instance.iconRenderer.color = color;
					__instance.blinkEffect.blinkOffColor = color;
				}
			}

			public static void UpdateMagnificusChallenges()
			{
				ChallengeManagement.RandomSidedeck = GuidManager.GetEnumValue<AscensionChallenge>("silenceman.inscryption.magnificusmodstarterdecks", "RandomSidedeck");
				ChallengeManagement.WeakBleach = GuidManager.GetEnumValue<AscensionChallenge>("silenceman.inscryption.magnificusmodstarterdecks", "WeakBleach");
				ChallengeManagement.TurnWipeout = GuidManager.GetEnumValue<AscensionChallenge>("silenceman.inscryption.magnificusmodstarterdecks", "TurnWipeout");
				ChallengeManagement.MoreHpOpponent = GuidManager.GetEnumValue<AscensionChallenge>("silenceman.inscryption.magnificusmodstarterdecks", "MoreHpOpponent");
				ChallengeManagement.ItemSpells = GuidManager.GetEnumValue<AscensionChallenge>("silenceman.inscryption.magnificusmodstarterdecks", "ItemSpells");
				ChallengeManagement.DyingBreath = GuidManager.GetEnumValue<AscensionChallenge>("silenceman.inscryption.magnificusmodstarterdecks", "DyingBreath");
				ChallengeManagement.ShieldedMox = GuidManager.GetEnumValue<AscensionChallenge>("silenceman.inscryption.magnificusmodstarterdecks", "ShieldedMox");
				ChallengeManagement.FadingMox = GuidManager.GetEnumValue<AscensionChallenge>("silenceman.inscryption.magnificusmodstarterdecks", "FadingMox");
				ChallengeManagement.GemDependantDeck = GuidManager.GetEnumValue<AscensionChallenge>("silenceman.inscryption.magnificusmodstarterdecks", "GemDependantDeck");
				ChallengeManagement.IronMaiden = GuidManager.GetEnumValue<AscensionChallenge>("silenceman.inscryption.magnificusmodstarterdecks", "IronMaiden");
				ChallengeManagement.PaintedSigils = GuidManager.GetEnumValue<AscensionChallenge>("silenceman.inscryption.magnificusmodstarterdecks", "PaintedSigils");
				ChallengeManagement.MasterMagnus = GuidManager.GetEnumValue<AscensionChallenge>("silenceman.inscryption.magnificusmodstarterdecks", "MasterMagnus");
				ChallengeManagement.MasterBosses = GuidManager.GetEnumValue<AscensionChallenge>("silenceman.inscryption.magnificusmodstarterdecks", "MasterBosses");
				ChallengeManagement.PatchedChallengesReference = new Dictionary<AscensionChallenge, AscensionChallengeInfo>();
				ChallengeManagement.PatchedChallengesReference.Add(AscensionChallenge.NoHook, new AscensionChallengeInfo
				{
					challengeType = ChallengeManagement.RandomSidedeck,
					title = "Blank Mox",
					description = "Your sidedeck's mox is completely random.",
					iconSprite = Tools.getSprite("challenge_randommox.png"),
					activatedSprite = Tools.getSprite("challenge_base_active.png"),
					pointValue = 15
				});
				ChallengeManagement.PatchedChallengesReference.Add(AscensionChallenge.LessConsumables, new AscensionChallengeInfo
				{
					challengeType = ChallengeManagement.WeakBleach,
					title = "Weaker Bleach",
					description = "The Bleaching Event can no longer remove negative sigils.",
					iconSprite = Tools.getSprite("challenge_bleach.png"),
					activatedSprite = Tools.getSprite("challenge_base_active.png"),
					pointValue = 10
				});
				ChallengeManagement.PatchedChallengesReference.Add(AscensionChallenge.StartingDamage, new AscensionChallengeInfo
				{
					challengeType = ChallengeManagement.TurnWipeout,
					title = "Turn Wipeout",
					description = "When you ring the bell past turn 6 (12 on bosses) you take 1 damage.",
					iconSprite = Tools.getSprite("challenge_turnwipeout.png"),
					activatedSprite = Tools.getSprite("challenge_morehpopponent_active.png"),
					pointValue = 20
				});
				ChallengeManagement.PatchedChallengesReference.Add(AscensionChallenge.BossTotems, new AscensionChallengeInfo
				{
					challengeType = ChallengeManagement.MoreHpOpponent,
					title = "Stronger Opponent",
					description = "Your battle opponent starts with 5 extra health points.",
					iconSprite = Tools.getSprite("challenge_morehpopponent.png"),
					activatedSprite = Tools.getSprite("challenge_morehpopponent_active.png"),
					pointValue = 15
				});
				ChallengeManagement.PatchedChallengesReference.Add(AscensionChallenge.NoClover, new AscensionChallengeInfo
				{
					challengeType = ChallengeManagement.ItemSpells,
					title = "Tiny Spellbook",
					description = "Your spellbook can only hold 4 spells instead of 8.",
					iconSprite = Tools.getSprite("challenge_itemspells.png"),
					activatedSprite = Tools.getSprite("challenge_base_active.png"),
					pointValue = 10
				});
				ChallengeManagement.PatchedChallengesReference.Add(AscensionChallenge.ExpensivePelts, new AscensionChallengeInfo
				{
					challengeType = ChallengeManagement.DyingBreath,
					title = "Displeased Spirits",
					description = "The enchanted grounds will always be displeased.",
					iconSprite = Tools.getSprite("challenge_dyingbreath.png"),
					activatedSprite = Tools.getSprite("challenge_base_active.png"),
					pointValue = 15
				});
				ChallengeManagement.PatchedChallengesReference.Add(AscensionChallenge.AllTotems, new AscensionChallengeInfo
				{
					challengeType = ChallengeManagement.ShieldedMox,
					title = "Armored Shell",
					description = "Your opponent cant take more than 4 damage per turn.",
					iconSprite = Tools.getSprite("challenge_shieldedmox.png"),
					activatedSprite = Tools.getSprite("challenge_base_active.png"),
					pointValue = 20
				});
				ChallengeManagement.PatchedChallengesReference.Add(AscensionChallenge.WeakStarterDeck, new AscensionChallengeInfo
				{
					challengeType = ChallengeManagement.IronMaiden,
					title = "Iron Maiden",
					description = "Every turn, each mox on your side of the board takes 1 damage.",
					iconSprite = Tools.getSprite("challenge_ironmaiden.png"),
					activatedSprite = Tools.getSprite("challenge_base_active.png"),
					pointValue = 30
				});
				ChallengeManagement.PatchedChallengesReference.Add(AscensionChallenge.LessLives, new AscensionChallengeInfo
				{
					challengeType = ChallengeManagement.PaintedSigils,
					title = "Magickal Paint",
					description = "Queued cards will occasionally get additional sigils painted on them.",
					iconSprite = Tools.getSprite("challenge_paintedsigils.png"),
					activatedSprite = Tools.getSprite("challenge_paintedsigils_active.png"),
					pointValue = 25
				});
				ChallengeManagement.PatchedChallengesReference.Add(AscensionChallenge.SubmergeSquirrels, new AscensionChallengeInfo
				{
					challengeType = ChallengeManagement.FadingMox,
					title = "Fleeting Life",
					description = "You have 75 health, but it does not replenish inbetween battles.",
					iconSprite = Tools.getSprite("challenge_fadingmox.png"),
					activatedSprite = Tools.getSprite("challenge_fadingmox_active.png"),
					pointValue = 30
				});
				ChallengeManagement.PatchedChallengesReference.Add(AscensionChallenge.GrizzlyMode, new AscensionChallengeInfo
				{
					challengeType = ChallengeManagement.MasterMagnus,
					title = "Intrusive Presence",
					description = "An unwelcome prescence will follow you into card battles.",
					iconSprite = Tools.getSprite("challenge_2lives.png"),
					activatedSprite = Tools.getSprite("challenge_2lives_active.png"),
					pointValue = 40
				});
				ChallengeManagement.PatchedChallengesReference.Add(AscensionChallenge.FinalBoss, new AscensionChallengeInfo
				{
					challengeType = ChallengeManagement.MasterBosses,
					title = "Master Bosses",
					description = "Every bossfight is replaced with one of the Mox Masters.",
					iconSprite = Tools.getSprite("challenge_masterbosses.png"),
					activatedSprite = Tools.getSprite("challenge_base_active.png"),
					pointValue = 50
				});
				ChallengeManagement.PatchedChallengesReference.Add(AscensionChallenge.NoBossRares, new AscensionChallengeInfo
				{
					challengeType = ChallengeManagement.GemDependantDeck,
					title = "Gem Dependant Starters",
					description = "Cards in your starting deck have the gem dependant sigil.",
					iconSprite = Tools.getSprite("challenge_gemdependant.png"),
					activatedSprite = Tools.getSprite("challenge_base_active.png"),
					pointValue = 20
				});
				ChallengeManagement.ValidChallenges = new List<AscensionChallenge>
				{
					ChallengeManagement.RandomSidedeck,
					ChallengeManagement.WeakBleach,
					ChallengeManagement.TurnWipeout,
					ChallengeManagement.MoreHpOpponent,
					ChallengeManagement.ItemSpells,
					ChallengeManagement.DyingBreath,
					ChallengeManagement.MasterMagnus,
					ChallengeManagement.MasterBosses,
					ChallengeManagement.ShieldedMox,
					ChallengeManagement.FadingMox,
					ChallengeManagement.GemDependantDeck,
					ChallengeManagement.IronMaiden,
					ChallengeManagement.PaintedSigils

				};
				ChallengeManager.ModifyChallenges += delegate (List<ChallengeManager.FullChallenge> challenges)
				{
					bool isMagRun = KayceeStorage.IsMagRun;
					if (isMagRun)
					{
						for (int i = 0; i < challenges.Count; i++)
						{
							if (ChallengeManagement.PatchedChallengesReference.ContainsKey(challenges[i].Challenge.challengeType))
							{
								bool level2 = (challenges[i].Challenge.challengeType == AscensionChallenge.NoClover && KayceeStorage.ChallengeLevel < 2) || (challenges[i].Challenge.challengeType == AscensionChallenge.ExpensivePelts && KayceeStorage.ChallengeLevel < 2);
								bool level3 = (challenges[i].Challenge.challengeType == AscensionChallenge.BossTotems && KayceeStorage.ChallengeLevel < 3) || (challenges[i].Challenge.challengeType == AscensionChallenge.StartingDamage && KayceeStorage.ChallengeLevel < 3);
								bool level4 = (challenges[i].Challenge.challengeType == AscensionChallenge.AllTotems && KayceeStorage.ChallengeLevel < 4) || (challenges[i].Challenge.challengeType == AscensionChallenge.NoBossRares && KayceeStorage.ChallengeLevel < 4);
								bool level5 = (challenges[i].Challenge.challengeType == AscensionChallenge.WeakStarterDeck && KayceeStorage.ChallengeLevel < 5) || (challenges[i].Challenge.challengeType == AscensionChallenge.LessLives && KayceeStorage.ChallengeLevel < 5) || (challenges[i].Challenge.challengeType == AscensionChallenge.GrizzlyMode && KayceeStorage.ChallengeLevel < 5) || (challenges[i].Challenge.challengeType == AscensionChallenge.SubmergeSquirrels && KayceeStorage.ChallengeLevel < 5);
								bool level6 = (challenges[i].Challenge.challengeType == AscensionChallenge.FinalBoss && KayceeStorage.ChallengeLevel < 6);
								if (!level2 && !level3 && !level4 && !level5 && !level6 || config.kayceeProgression == true)
								{
									challenges[i] = new ChallengeManager.FullChallenge
									{
										Challenge = ChallengeManagement.PatchedChallengesReference[challenges[i].Challenge.challengeType],
										AppearancesInChallengeScreen = 1,
										UnlockLevel = challenges[i].UnlockLevel
										
									};
								}
							}
						}
					}
					return challenges;
				};
			}



			public static void setUpMagChallengePos()
			{

				GameObject gameObject = GameObject.Find("Screens").transform.Find("ChallengesScreen").transform.Find("Icons").Find("ChallengeIconGrid").gameObject;
				gameObject.transform.Find("BottomRow").Find("Icon_15").localPosition = new Vector3(1.8f, 0.24f, 0);
				gameObject.transform.Find("BottomRow").Find("Icon_15").gameObject.SetActive(true);
				if (KayceeFixes.currentState == CardTemple.Wizard)
				{
					gameObject.transform.Find("TopRow").Find("Icon_5").gameObject.SetActive(true);
					gameObject.transform.Find("TopRow").Find("Icon_6").gameObject.SetActive(true);
					gameObject.transform.Find("BottomRow").Find("Icon_12").gameObject.SetActive(true);
					gameObject.transform.Find("TopRow").Find("Icon_6").transform.localPosition = new Vector3(1.1f, 0.51f, 0f);
					gameObject.transform.Find("BottomRow").Find("Icon_13").transform.localPosition = new Vector3(1.1f, -0.01f, 0f);
					gameObject.transform.Find("TopRow").Find("Icon_7").transform.localPosition = new Vector3(1.65f, 0.51f, 0f);
					gameObject.transform.Find("BottomRow").Find("Icon_14").transform.localPosition = new Vector3(1.65f, -0.01f, 0f);
					gameObject.transform.Find("BottomRow").Find("Icon_12").localPosition = new Vector3(0.55f, -0.01f, 0);
					gameObject.transform.Find("TopRow").Find("Icon_6").transform.localPosition = new Vector3(0.55f, 0.51f, 0f);
					gameObject.transform.Find("BottomRow").Find("Icon_13").transform.localPosition = new Vector3(0.55f, -0.01f, 0f);
					gameObject.transform.Find("TopRow").Find("Icon_7").transform.localPosition = new Vector3(1.1f, 0.51f, 0f);
					gameObject.transform.Find("BottomRow").Find("Icon_14").transform.localPosition = new Vector3(1.1f, -0.01f, 0f);
					gameObject.transform.Find("TopRow").Find("Icon_5").gameObject.SetActive(false);
					gameObject.transform.Find("BottomRow").Find("Icon_12").gameObject.SetActive(false);
					if (KayceeStorage.ChallengeLevel >= 5 || config.kayceeProgression == true)
                    {
						gameObject.transform.Find("BottomRow").Find("Icon_15").gameObject.SetActive(true);//1.7 0.165 0
						gameObject.transform.Find("BottomRow").Find("Icon_15").localPosition = new Vector3(1.7f, 0.24f, 0);
					} else
                    {
						gameObject.transform.Find("BottomRow").Find("Icon_15").gameObject.SetActive(false);
					}
					if (KayceeFixes.setUpMagPos)
					{
						gameObject.transform.Find("TopRow").Find("Icon_6").gameObject.SetActive(false);
						gameObject.transform.Find("BottomRow").Find("Icon_12").gameObject.SetActive(true);
						gameObject.transform.Find("BottomRow").Find("Icon_12").localPosition = new Vector3(0.55f, 0.51f, 0);
						KayceeFixes.setUpMagPos = false;
						return;
					}
					KayceeFixes.setUpMagPos = true;
				} else if (KayceeFixes.currentState != CardTemple.Wizard)
                {
					gameObject.transform.Find("BottomRow").Find("Icon_13").transform.localPosition = new Vector3(0.75f, -0.01f, 0);
					gameObject.transform.Find("BottomRow").Find("Icon_14").transform.localPosition = new Vector3(1.25f, -0.01f, 0f);
					gameObject.transform.Find("BottomRow").Find("Icon_12").localPosition = new Vector3(0.25f, -0.01f, 0);
					gameObject.transform.Find("TopRow").Find("Icon_6").transform.localPosition = new Vector3(0.75f, 0.51f, 0);
					gameObject.transform.Find("TopRow").Find("Icon_7").transform.localPosition = new Vector3(1.25f, 0.51f, 0f);
					gameObject.transform.Find("TopRow").Find("Icon_5").gameObject.SetActive(true);
					gameObject.transform.Find("BottomRow").Find("Icon_12").gameObject.SetActive(true);
					KayceeFixes.setUpMagPos = false;
				}
			}




			[HarmonyPostfix]
			[HarmonyPatch(typeof(AscensionUnlockSchedule), "ChallengeIsUnlockedForLevel")]
			[HarmonyAfter(new string[]
			{
				"cyantist.inscryption.api"
			})]
			public static void ValidMagnificusChallenges(ref bool __result, AscensionChallenge challenge, int level)
			{
				if (KayceeStorage.ScreenState == CardTemple.Wizard || KayceeStorage.IsMagRun)
				{
					__result = ChallengeManagement.ValidChallenges.Contains(challenge);
				}
			}

			public static Dictionary<AscensionChallenge, AscensionChallengeInfo> PatchedChallengesReference;

			public static List<AscensionChallenge> ValidChallenges;

			public static List<AscensionChallenge> AntiChallenges;
		}

		[HarmonyPatch(typeof(AscensionSaveData), "Initialize")]
		public class BoardManager3D_Initialize
		{
			public static void Prefix()
			{
				KayceeStorage.IsKaycee = true;
				SaveManager.SaveToFile(false);
			}
		}
		//Singleton<AscensionMenuScreens>.Instance.StartCoroutine(magChallengePos0());
		[HarmonyPatch(typeof(AscensionMenuScreens), "Start")]
		public class aaahhhh
		{
			public static void Prefix()
			{
				setUpMagPos = false;
				KayceeStorage.IsKaycee = true;
				//Kill(CardTemple.Undead);
			}
		}


		public static bool setUpMagPos = false;

		[HarmonyPatch(typeof(AscensionChallengeScreen), "OnEnable")]
		public class ChallengePoseFix
		{
			public static void Prefix()
			{
				Singleton<AscensionMenuScreens>.Instance.StartCoroutine(magChallengePos0());
			}
		}

		[HarmonyPatch(typeof(AscensionStartScreen), "OnNewRunSelected")]
		public class StarterDeckScreenFix
		{
			public static bool Prefix(ref AscensionStartScreen __instance)
			{
				CommandLineTextDisplayer.PlayCommandLineClickSound();
				if (__instance.RunExists)
				{
					Singleton<AscensionMenuScreens>.Instance.SwitchToScreen(AscensionMenuScreens.Screen.NewRunConfirm);
					__instance.newRunConfirmButton.screenToReturnTo = ( (AscensionUnlockSchedule.NumStarterDecksUnlocked(1) > 0 || KayceeStorage.ScreenState == CardTemple.Wizard) ? AscensionMenuScreens.Screen.StarterDeckSelect : AscensionMenuScreens.Screen.SelectChallenges);
					return false;
				}
				if (AscensionUnlockSchedule.NumStarterDecksUnlocked(1) > 0 || KayceeStorage.ScreenState == CardTemple.Wizard)
				{
					Singleton<AscensionMenuScreens>.Instance.SwitchToScreen(AscensionMenuScreens.Screen.StarterDeckSelect);
					return false;
				}
				Singleton<AscensionMenuScreens>.Instance.SwitchToScreen(AscensionMenuScreens.Screen.SelectChallenges);
				return false;
			}
		}

		public static IEnumerator leshyInterveneDialogue()
        {
			if (SceneLoader.ActiveSceneName != "finale_magnificus")
			{
				foreach (CardInfo card in CardLoader.allData)
				{
					if (card.name.Contains("mag_"))
					{
						card.temple = CardTemple.Wizard;
					}
					if (card.appearanceBehaviour.Contains(CardAppearanceBehaviour.Appearance.RareCardBackground))
                    {
						card.metaCategories.Add(CardMetaCategory.Rare);
                    } else if (card.HasTrait(Trait.EatsWarrens))
                    {
						card.metaCategories.Add(Plugin.SpellPool);
                    } 
				}
				if (!SavedVars.LearnedMechanics.Contains("wrongdimension;"))
				{
					yield return new WaitForSeconds(1f);
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Just what is going on here..?", -1.5f, 0.5f, Emotion.Curious, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("These cards,", -0.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Did that [c:g2]foul little..[c:] get in here..?", -0.5f, 0.5f, Emotion.Anger, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("I believe you are in the wrong place, challenger.", -0.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Hold still.", -0.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
					KayceeStorage.IsMagRun = true;
					KayceeStorage.IsKaycee = true;
					SavedVars.LearnedMechanics += "wrongdimension;";
					Singleton<UIManager>.Instance.Effects.GetEffect<ScreenColorEffect>().SetColor(GameColors.Instance.nearBlack);
					Singleton<UIManager>.Instance.Effects.GetEffect<ScreenColorEffect>().SetIntensity(1f, float.MaxValue);
					SaveManager.SaveToFile(false);
					LoadingScreenManager.LoadScene("finale_magnificus");
				}
				else
				{
					KayceeStorage.IsMagRun = true;
					KayceeStorage.IsKaycee = true;
					Singleton<UIManager>.Instance.Effects.GetEffect<ScreenColorEffect>().SetColor(GameColors.Instance.nearBlack);
					Singleton<UIManager>.Instance.Effects.GetEffect<ScreenColorEffect>().SetIntensity(1f, float.MaxValue);
					SaveManager.SaveToFile(false);
					LoadingScreenManager.LoadScene("finale_magnificus");
				}
			}
			yield break;
        }

		[HarmonyPatch(typeof(Part1GameFlowManager), "Awake")]
		public class FixLeshy
		{
			public static void Prefix(ref Part1GameFlowManager __instance)
			{
				if (SceneLoader.ActiveSceneName == "Part1_Cabin")
                {
					int magicCards = 0;
					foreach(CardInfo card in RunState.Run.playerDeck.Cards)
                    {
						if (card.temple == CardTemple.Wizard || card.name.Contains("mag_")) { magicCards++; }
                    }
					if (magicCards > RunState.Run.playerDeck.Cards.Count / 2)
                    {
						__instance.StartCoroutine(leshyInterveneDialogue());

					}

					GameObject liveRenderer = Singleton<CardRenderCamera>.Instance.liveCardCameraPrefab.gameObject;
					liveRenderer.transform.Find("EmissionRenderCamera").gameObject.SetActive(true);
					liveRenderer.transform.Find("CardsPlane").GetChild(0).GetChild(0).gameObject.GetComponent<CardDisplayer>().enabled = true;
					liveRenderer.transform.Find("CardsPlane").GetChild(0).gameObject.SetActive(true);


				}
			}
		}

		[HarmonyPatch(typeof(SaveFile), "CurrentDeck", MethodType.Getter)]
		[HarmonyPrefix]
		public static bool SaveFile_CurrentDeck(ref DeckInfo __result)
		{
			if (KayceeStorage.IsMagRun)
			{
				if (SaveFile.IsAscension)
				{
					__result = SaveManager.saveFile.ascensionData.currentRun.playerDeck;
				}
				else
				{
					__result = RunState.Run.playerDeck;
				}
				return false;
			}

			return true;
		}

	

		[HarmonyPatch(typeof(AscensionSaveData), "NewRun")]
		public class DraftObeliskFix
		{
			public static bool Prefix(ref AscensionSaveData __instance, List<CardInfo> starterDeck)
			{
				__instance.currentRunSeed = Environment.TickCount;
				__instance.currentOuroborosDeaths = 0;
				__instance.currentRun = new RunState();
				__instance.currentRun.Initialize();
				//__instance.oilPaintingState.TryAdvanceRewardIndex();
				//__instance.oilPaintingState.puzzleSolution = OilPaintingPuzzle.GenerateSolution(true);
				__instance.currentRun.playerDeck = new DeckInfo();
				foreach (CardInfo cardInfo in starterDeck)
				{
					__instance.currentRun.playerDeck.AddCard(CardLoader.GetCardByName(cardInfo.name));
				}
				if (__instance.numRunsSinceReachedFirstBoss == 0 && KayceeStorage.ScreenState == CardTemple.Nature)
				{
					__instance.currentRun.playerDeck.AddCard(CardLoader.GetCardByName("PeltHare"));
					__instance.currentRun.playerDeck.AddCard(CardLoader.GetCardByName("PeltHare"));
				}
				else if (__instance.numRunsSinceReachedFirstBoss == 1 && KayceeStorage.ScreenState == CardTemple.Nature)
				{
					__instance.currentRun.playerDeck.AddCard(CardLoader.GetCardByName("Opossum"));
					__instance.currentRun.playerDeck.AddCard(CardLoader.GetCardByName("PeltHare"));
				} else if (__instance.numRunsSinceReachedFirstBoss > 1 && KayceeStorage.ScreenState == CardTemple.Nature)
				{
					__instance.currentRun.playerDeck.AddCard(CardLoader.GetCardByName("Opossum"));
					__instance.currentRun.playerDeck.AddCard(CardLoader.GetCardByName("RingWorm"));
				} 
				if (KayceeStorage.ScreenState != CardTemple.Wizard)
				{
					__instance.currentRun.consumables.Add("SquirrelBottle");
					if (__instance.GetNumChallengesOfTypeActive(AscensionChallenge.LessConsumables) < 2)
					{
						__instance.currentRun.consumables.Add("Pliers");
					}
					if (!__instance.ChallengeIsActive(AscensionChallenge.NoHook))
					{
						if (__instance.currentRun.consumables.Count == __instance.currentRun.MaxConsumables)
						{
							__instance.currentRun.consumables.RemoveAt(__instance.currentRun.consumables.Count - 1);
						}
						__instance.currentRun.consumables.Add("FishHook");
					}
					if (__instance.ChallengeIsActive(AscensionChallenge.LessLives))
					{
						__instance.currentRun.maxPlayerLives = (__instance.currentRun.playerLives = 1);
					}
				}
				else
				{
					SaveManager.saveFile.ascensionActive = true;
					__instance.currentRun.maxPlayerLives = (__instance.currentRun.playerLives = 3);
					if (__instance.ChallengeIsActive(ChallengeManagement.GemDependantDeck))
					{
						CardModificationInfo cardModificationInfo = new CardModificationInfo();
						cardModificationInfo.abilities.Add(Ability.GemDependant);
						for (int i = 0; i < __instance.currentRun.playerDeck.Cards.Count; i++)
						{
							__instance.currentRun.playerDeck.ModifyCard(__instance.currentRun.playerDeck.Cards[i], cardModificationInfo);
						}
					}
				}
				return false;
			}
		}

		[HarmonyAfter(new string[]
		{
			"arackulele.inscryption.grimoramod",
			"zorro.inscryption.infiniscryption.p03kayceerun"
		})]
		[HarmonyPatch(typeof(AscensionMenuScreens), "Start")]
		public class makedemmenubuttons
		{
			public static void Prefix(ref AscensionMenuScreens __instance)
			{
				KayceeStorage.IsKaycee = true;
				AdjustAscensionMenuItemsSpacing adjustAscensionMenuItemsSpacing = GameObject.FindObjectOfType<AdjustAscensionMenuItemsSpacing>();
				AscensionMenuInteractable menuText = adjustAscensionMenuItemsSpacing.menuItems[0].GetComponent<AscensionMenuInteractable>();
				AscensionMenuScreenTransition component = Singleton<AscensionMenuScreens>.Instance.startScreen.GetComponent<AscensionMenuScreenTransition>();
				List<GameObject> onEnableRevealedObjects = component.onEnableRevealedObjects;
				List<MainInputInteractable> screenInteractables = component.screenInteractables;
				int num = 0;
				if (Harmony.HasAnyPatches("zorro.inscryption.infiniscryption.p03kayceerun") && !Harmony.HasAnyPatches("arackulele.inscryption.grimoramod"))
				{
					__instance.StartCoroutine(showP03Button());
					num = 1;
				}
				if (!Harmony.HasAnyPatches("arackulele.inscryption.grimoramod") && !Harmony.HasAnyPatches("zorro.inscryption.infiniscryption.p03kayceerun"))
				{
					menuText.GetComponentInChildren<PixelText>().SetText("- NEW LESHY RUN -", false);
				}
				AscensionMenuInteractable ascensionMenuInteractable = GameObject.Instantiate<AscensionMenuInteractable>(menuText, menuText.transform.parent);
				ascensionMenuInteractable.name = "Menu_New_Magnificus";
				ascensionMenuInteractable.CursorSelectStarted = (Action<MainInputInteractable>)Delegate.Combine(ascensionMenuInteractable.CursorSelectStarted, new Action<MainInputInteractable>(delegate (MainInputInteractable i)
				{
					KayceeStorage.ScreenState = CardTemple.Wizard;
					KayceeFixes.currentState = CardTemple.Wizard;
					KayceeStorage.IsMagRun = true;
					menuText.CursorSelectStart();
				}));
				ascensionMenuInteractable.GetComponentInChildren<PixelText>().SetText("- NEW MAGNIFICUS RUN -", false);
				AscensionMenuInteractable ascensionMenuInteractable2 = ascensionMenuInteractable;
				onEnableRevealedObjects.Insert(onEnableRevealedObjects.IndexOf(menuText.gameObject) + (1 + num), ascensionMenuInteractable2.gameObject);
				screenInteractables.Insert(screenInteractables.IndexOf(menuText) + (1 + num), ascensionMenuInteractable2);
				adjustAscensionMenuItemsSpacing.menuItems.Insert(1 + num, ascensionMenuInteractable2.transform);
				using (List<MainInputInteractable>.Enumerator enumerator = screenInteractables.FindAll((MainInputInteractable b) => b.gameObject.GetComponentInChildren<PixelText>().Text.StartsWith("- NEW") && b.gameObject.GetComponentInChildren<PixelText>().Text.EndsWith("RUN -")).GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						MainInputInteractable button = enumerator.Current;
						MainInputInteractable button2 = button;
						button2.CursorSelectStarted = (Action<MainInputInteractable>)Delegate.Combine(button2.CursorSelectStarted, new Action<MainInputInteractable>(delegate (MainInputInteractable interactable)
						{
							string text = button.GetComponentInChildren<PixelText>().Text.Replace("- NEW ", "").Replace(" RUN -", "");
							string text2 = text;
							string a = text2;
							switch(a)
                            {
								case "GRIMORA":
									KayceeStorage.ScreenState = CardTemple.Undead;
									KayceeFixes.currentState = CardTemple.Undead;
									KayceeStorage.IsMagRun = false;
									break;
								case "P03":
									KayceeStorage.ScreenState = CardTemple.Tech;
									KayceeFixes.currentState = CardTemple.Tech;
									KayceeStorage.IsMagRun = false;
									break;
								case "LESHY":
									KayceeStorage.ScreenState = CardTemple.Nature;
									KayceeFixes.currentState = CardTemple.Nature;
									KayceeStorage.IsMagRun = false;
									break;
								case "MAGNIFICUS":
									Plugin.unlockMost();

									KayceeStorage.ScreenState = CardTemple.Wizard;
									KayceeFixes.currentState = CardTemple.Wizard;
									KayceeStorage.IsMagRun = true;
									KayceeStorage.IsKaycee = true;
									SaveManager.SaveToFile(false);
									ChallengeManager.SyncChallengeList();
									break;

							}

							ChallengeManager.SyncChallengeList();
						}));
					}
				}
				for (int i = 1; i < adjustAscensionMenuItemsSpacing.menuItems.Count; i++)
				{
					Transform transform = adjustAscensionMenuItemsSpacing.menuItems[i];
					transform.localPosition = new Vector2(transform.localPosition.x, (float)i * -0.11f);
				}
				if (Harmony.HasAnyPatches("zorro.inscryption.infiniscryption.p03kayceerun"))
				{
					StarterDecks.RegisterStarterDecks();
				}
			}
		}

		[HarmonyPatch(typeof(ConceptProgressionTree), "CardUnlocked")]
		public class unlockallmagcards
		{
			public static void Postfix(ref bool __result, CardInfo card, bool andAbilitiesLearned = false)
			{
				bool res = __result;
				if (SceneLoader.ActiveSceneName == "finale_magnificus") { res = true; }
				__result = res;
			}
		}

		[HarmonyPatch(typeof(AscensionChallengeScreen), "OnContinuePressed")]
		public class setupgamevars
		{
			public static void Prefix()
			{
				if ((AscensionSaveData.Data.ChallengeLevelIsMet() && KayceeStorage.IsMagRun) || (AscensionSaveData.Data.challengeLevel >= 5 && KayceeStorage.IsMagRun))
				{
					GetChallenges();
					File.WriteAllText(SaveManager.SaveFolderPath + "MagnificusModSave.gwsave", SaveManager.ToJSON(MagSave.GetNodeStuff(true, true)));
					MagSave.SaveNode("x4 y7");
					MagSave.SaveLayout("1");
					File.WriteAllText(SaveManager.SaveFolderPath + "MagnificusModSave.gwsave", SaveManager.ToJSON(MagSave.GetNodeStuff(false, false)));
				}
			}
		}//CardUnlocked


		[HarmonyPatch(typeof(AscensionChallengeConfirmScreen), "Start")]
		public class setupgamevars2
		{
			public static bool Prefix(ref AscensionChallengeConfirmScreen __instance)
			{
				AscensionMenuInteractable continueButton = __instance.continueButton;
				continueButton.CursorSelectStarted = (Action<MainInputInteractable>)Delegate.Combine(continueButton.CursorSelectStarted, new Action<MainInputInteractable>(delegate (MainInputInteractable i)
				{
					bool isMagRun = KayceeStorage.IsMagRun;
					if (isMagRun)
					{
						GetChallenges();
						File.WriteAllText(SaveManager.SaveFolderPath + "MagnificusModSave.gwsave", SaveManager.ToJSON(MagSave.GetNodeStuff(true, true)));
						MagSave.SaveNode("x4 y7");
						MagSave.SaveLayout("1");
						File.WriteAllText(SaveManager.SaveFolderPath + "MagnificusModSave.gwsave", SaveManager.ToJSON(MagSave.GetNodeStuff(false, false)));
					}
					Singleton<AscensionMenuScreens>.Instance.TransitionToGame(true);
				}));
				return false;
			}
		}

		[HarmonyAfter(new string[]
		{
			"zorro.inscryption.infiniscryption.packmanager"
		})]
		[HarmonyPatch(typeof(AscensionMenuScreens), "TransitionToGame")]
		public class aaahhhh3
		{
			public static void Prefix(ref AscensionMenuScreens __instance, bool newRun = true)
			{
				if (newRun)
				{
					if (KayceeStorage.ScreenState == CardTemple.Wizard)
					{
						KayceeStorage.IsMagRun = true;
						SaveManager.SaveToFile(false);
					}
					else
					{
						KayceeStorage.IsMagRun = false;
					}
				}
				bool isMagRun = KayceeStorage.IsMagRun;
				if (isMagRun)
				{
					KayceeStorage.ScreenState = CardTemple.Wizard;
					KayceeFixes.currentState = CardTemple.Wizard;
				}
			}
		}

		[HarmonyPatch(typeof(ChallengeLevelText), "UpdateText")]
		public class FixChallengeText
		{
			public static bool Prefix(ref ChallengeLevelText __instance)
			{
				if (KayceeStorage.ScreenState == CardTemple.Wizard)
				{
					int challengeLevel = KayceeStorage.ChallengeLevel;
					if (KayceeStorage.ChallengeLevel <= 0)
					{
						KayceeStorage.ChallengeLevel = 1;
						challengeLevel = 1;
					}
					int activeChallengePoints = AscensionSaveData.Data.GetActiveChallengePoints();
					string magChalllengeLevel;
					if (challengeLevel <= 5)
					{
						string theChallengeThingManIdk = "<color=#eef4c6>" + challengeLevel.ToString() + "</color>";
						if (activeChallengePoints > AscensionSaveData.GetChallengePointsForLevel(challengeLevel))
						{
							theChallengeThingManIdk += " " + Localization.Translate("(EXCEEDED!)");
						}
						magChalllengeLevel = string.Format(Localization.Translate("Magnificus Challenge Level: {0}"), theChallengeThingManIdk);
					}
					else
					{
						magChalllengeLevel = Localization.Translate("ALL CHALLENGE LEVELS CLEARED!");
					}
					string challengePoints = "<color=#eef4c6>" + activeChallengePoints.ToString() + "</color>";
					if (challengeLevel <= 5)
					{
						challengePoints += "/" + AscensionSaveData.GetChallengePointsForLevel(challengeLevel).ToString();
					}
					string challengeAgain = string.Format(Localization.Translate("Magnificus Challenge Points: {0}"), challengePoints);
					__instance.headerPointsLines.ShowText(0.1f, new string[]
					{
						magChalllengeLevel,
						challengeAgain
					}, false);
					return false;
				}
				return true;
			}
		}

		[HarmonyPatch(typeof(AscensionSaveData), "ChallengeLevelIsMet")]
		public class FixChallengeRequirement
		{
			public static bool Prefix(ref AscensionSaveData __instance, ref bool __result)
			{
				if (KayceeStorage.ScreenState == CardTemple.Wizard)
				{
					__result = (__instance.GetActiveChallengePoints() >= AscensionSaveData.GetChallengePointsForLevel(KayceeStorage.ChallengeLevel));
					return false;
				}
				else
				{
					__result = (__instance.GetActiveChallengePoints() >= AscensionSaveData.GetChallengePointsForLevel(__instance.challengeLevel));
					return false;
				}
				return true;
			}
		}

		[HarmonyPatch(typeof(CombatPhaseManager), "DoCombatPhase")]
		public class MostDamageDealtFix
		{
			public static void Prefix(bool playerIsAttacker, SpecialBattleSequencer specialSequencer, ref CombatPhaseManager __instance)
			{
				List<CardSlot> list = playerIsAttacker ? Singleton<BoardManager>.Instance.PlayerSlotsCopy : Singleton<BoardManager>.Instance.OpponentSlotsCopy;
				list.RemoveAll((CardSlot x) => x.Card == null || x.Card.Attack == 0);
				if (list.Count > 0)
				{
					if (__instance.DamageDealtThisPhase > 0)
					{
						AscensionStatsData.TryIncreaseStat(AscensionStat.Type.MostDamageDealt, __instance.DamageDealtThisPhase);
					}
				}
			}
		}

		[HarmonyPatch(typeof(MenuController), "LoadGameFromMenu")]
		public class KayceeGameStart
		{
			public static bool Prefix(bool newGameGBC)
			{
				if (!newGameGBC && SaveManager.saveFile.ascensionActive && KayceeStorage.IsMagRun)
				{
					SaveManager.LoadFromFile();
					LoadingScreenManager.LoadScene("finale_magnificus");
					SaveManager.savingDisabled = false;
					return false;
				}
				return true;
			}
		}

		[HarmonyPatch(typeof(GameFlowManager), "PlayerLostBattleSequence")]
		public class deathfix
		{
			public static void Prefix(ref GameFlowManager __instance)
			{
				if (SaveManager.saveFile.ascensionActive && SceneLoader.ActiveSceneName == "finale_magnificus")
				{
					if (RunState.Run.playerLives <= 1)
					{
						AscensionMenuScreens.ReturningFromFailedRun = true;
						AscensionStatsData.TryIncrementStat(AscensionStat.Type.Losses);
						KayceeStorage.IsMagRun = false;
						SaveManager.SaveToFile(true);
						AscensionMenuScreens.ReturningFromFailedRun = true;
					}
				}
			}
		}

		

		[HarmonyPatch(typeof(AscensionRunEndScreen), "Initialize")]
		public class deathscreenfix
		{
			public static void Postfix(ref AscensionRunEndScreen __instance, bool victory)
			{
				bool isKaycee = KayceeStorage.IsKaycee;
				if (isKaycee)
				{
					__instance.backgroundSpriteRenderer.sprite = (victory ? Tools.getSprite("ascension_endscreen_victory.png") : Tools.getSprite("ascension_endscreen_defeat.png"));
				}
			}
		}

		[HarmonyPatch(typeof(RunInfoUIBar), "UpdateText")]
		public class FixTheTinyInsignificantMapText
		{
			public static bool Prefix(ref RunInfoUIBar __instance)
			{
				if (SceneLoader.ActiveSceneName != "finale_magnificus")
                {
					return true;
                }
				string dungeonName = "TOWER OF MAGICKS";
				switch(RunState.Run.regionTier)
                {
					case 0:
						dungeonName = "TOWER OF MAGICKS";
						break;
					case 1:
						dungeonName = "GOO DUNGEON";
						break;
					case 2:
						dungeonName = "LAVA DUNGEON";
						break;
					case 3:
						dungeonName = "VOID DUNGEON";
						break;
					default:
						dungeonName = "???";
						break;
				}
				__instance.mapIndexText.SetText(Localization.Translate(dungeonName), false);
				return false;
			}
		}

		[HarmonyPatch(typeof(PauseMenu3D), "Start")]
		public class FixKcPauseMenu
		{
			public static bool Prefix(ref PauseMenu3D __instance)
			{
				if (SceneLoader.ActiveSceneName != "finale_magnificus")
				{
					return true;
				}
				if (SaveFile.IsAscension)
				{
					__instance.modifyDeckCard.SetActive(true);
					__instance.modifyDeckCard.GetComponent<MenuCard>().StartPosition = new Vector2(0.46f, 0);
					__instance.modifyDeckCard.GetComponent<MenuCard>().targetPosition = new Vector2(0.46f, 0);
					__instance.modifyDeckCard.GetComponent<MenuCard>().InitializePosition(new Vector2(0.46f, 0));
					__instance.modifyDeckCard.transform.localPosition = new Vector3(0.46f, 0, 0);
					__instance.endRunCard.GetComponent<MenuCard>().StartPosition = new Vector2(0.92f, 0);
					__instance.endRunCard.GetComponent<MenuCard>().targetPosition = new Vector2(0.92f, 0);
					__instance.endRunCard.GetComponent<MenuCard>().InitializePosition(new Vector2(0.92f, 0));
					__instance.endRunCard.transform.localPosition = new Vector3(0.92f, 0, 0);
					__instance.endRunCard.SetActive(true);
					__instance.ascensionRunInfoBar.SetActive(true);
					__instance.ascensionChallengeArray.gameObject.SetActive(true);
					__instance.menuController.transform.localPosition = new Vector3(0f, __instance.ascensionMenuYOffset, 0f);
					__instance.optionsUIPanel.transform.localPosition = new Vector3(0f, -__instance.ascensionMenuYOffset, 0f);
					__instance.endRunCard.transform.parent.Find("CardsFrame").gameObject.GetComponent<SpriteRenderer>().sprite = Tools.getSprite("bigpausemenu.png");
					__instance.endRunCard.transform.parent.Find("CardsFrame").GetChild(0).localPosition = new Vector3(0.71f, 0.455f, 0f);
					__instance.endRunCard.transform.parent.Find("CardsFrame").localPosition = new Vector3(0.23f, 0, 0);
					GameObject.Find("PauseMenu").transform.Find("MenuParent").Find("CloseMenuInteractable").localPosition = new Vector3(0.5f, 0, 0);
					__instance.endRunCard.transform.parent.localPosition = new Vector3(-0.23f, 0, 0);
					GameObject.Find("PauseMenu").transform.Find("MenuParent").Find("Menu").Find("MenuSlot").localPosition = new Vector3(-1.268f, 0, 0);
				}
				return false;
			}
		}

		[HarmonyPatch(typeof(AscensionMenuScreens), "ConfigurePostGameScreens")]
		public class victoryScreenFix
		{
			public static bool Prefix(ref AscensionMenuScreens __instance)
			{
				if (AscensionMenuScreens.ReturningFromFailedRun || AscensionMenuScreens.ReturningFromSuccessfulRun)
				{
					if (KayceeStorage.ScreenState != CardTemple.Wizard)
					{
						return true;
					}
					__instance.startScreen.gameObject.SetActive(false);
					__instance.runEndScreen.gameObject.SetActive(!AscensionMenuScreens.ReturningFromCredits);
					__instance.runEndScreen.GetComponent<AscensionRunEndScreen>().Initialize(AscensionMenuScreens.ReturningFromSuccessfulRun);
					if (AscensionMenuScreens.ReturningFromSuccessfulRun && AscensionSaveData.Data.GetActiveChallengePoints() >= AscensionSaveData.GetChallengePointsForLevel(KayceeStorage.ChallengeLevel) && KayceeStorage.ChallengeLevel <= 12)
					{
						KayceeStorage.ChallengeLevel++;
					}
					AscensionMenuScreens.ReturningFromCredits = false;
					AscensionMenuScreens.ReturningFromSuccessfulRun = false;
					AscensionMenuScreens.ReturningFromFailedRun = false;
					AscensionSaveData.Data.EndRun();
					Generation.nodes = new List<GameObject>();
					GetChallenges();
					File.WriteAllText(SaveManager.SaveFolderPath + "MagnificusModSave.gwsave", SaveManager.ToJSON(MagSave.GetNodeStuff(true, true)));
					MagSave.SaveNode("x4 y7");
					MagSave.SaveLayout("1");
					File.WriteAllText(SaveManager.SaveFolderPath + "MagnificusModSave.gwsave", SaveManager.ToJSON(MagSave.GetNodeStuff(false, false)));
				}
				return false;
			}
		}

		[HarmonyPatch(typeof(MenuController), "OnCardReachedSlot")]
		public class MenuButooon2
		{
			public static void Prefix(ref MenuController __instance, MenuCard card, bool skipTween = false)
			{

				if (card.TitleText == "New Magnificus Run")
				{
					Plugin.unlockMost();
					KayceeStorage.IsKaycee = false;
					AscensionSaveData.Data.currentRun = null;
					SaveManager.SaveFile.NewPart1Run();
					SaveManager.SaveFile.deathCardMods = DefaultDeathCards.CreateDefaultCardMods();
					SaveManager.SaveFile.currentRun.maxPlayerLives = 3;
					SaveManager.SaveFile.currentRun.playerLives = 3;
				}
			}
		}

		[HarmonyPatch(typeof(RunState), "InitializeStarterDeckAndItems")]
		public class fixShitBeingInsertedIntoDeckMaybe
		{
			public static bool Prefix()
			{
				if (SceneLoader.ActiveSceneName == "finale_magnificus") { return false; }
				return true;
			}
		}

		[HarmonyPatch(typeof(AscensionMenuScreens), "ExitAscension")]
		public class aaahhhh2
		{
			public static void Prefix()
			{
				KayceeStorage.IsKaycee = false;
				//Kill(CardTemple.Wizard);
			}
		}

		[HarmonyPatch(typeof(OilPaintingPuzzle), "GenerateSolution")]
		public class aaahhhh2241
		{
			public static bool Prefix()
			{
				return false;
			}
		}


		/*
		[HarmonyPatch(typeof(Infiniscryption.PackManagement.PackManager), "ScreenState", MethodType.Getter))]
		public class zzzzzzzzzzzzzzzzzzzzzzzzzzzzonesimpletrick
		{
			public static bool Prefix(ref CardTemple __result)
			{
				__result = KayceeStorage.ScreenState;
				return false;
			}
		}
		*/
	}
}
