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
using Infiniscryption.PackManagement;
using Random = UnityEngine.Random;
using Cards = MagnificusMod.Cards;
using Sigils = MagnificusMod.MagSigils;
using SavedVars = MagnificusMod.SaveVariables;
using KayceeStorage = MagnificusMod.KayceeStorage;

namespace MagnificusMod
{
	[BepInPlugin(PluginGuid, PluginName, PluginVersion)]
	[BepInDependency("cyantist.inscryption.api", BepInDependency.DependencyFlags.HardDependency)]
	[BepInDependency("zorro.inscryption.infiniscryption.achievements")]
	public class Plugin : BaseUnityPlugin
	{

		public readonly static SpecialTriggeredAbility ManaTutorial = SpecialTriggeredAbilityManager.Add(PluginGuid, "Mana Cost", typeof(SpecialAbilities.ManaCost)).Id;
		public readonly static SpecialTriggeredAbility Romance = SpecialTriggeredAbilityManager.Add(PluginGuid, "Lesbians", typeof(SpecialAbilities.Lesbiane)).Id;
		public readonly static SpecialTriggeredAbility OuroChange = SpecialTriggeredAbilityManager.Add(PluginGuid, "Ouro Random", typeof(SpecialAbilities.OuroRandomize)).Id;
		public readonly static SpecialTriggeredAbility CustomPortrait = SpecialTriggeredAbilityManager.Add(PluginGuid, "Custom Portrait", typeof(SpecialAbilities.CustomPortraited)).Id;
		public readonly static SpecialTriggeredAbility PotionStuff = SpecialTriggeredAbilityManager.Add(PluginGuid, "PotionStuff", typeof(SpecialAbilities.Potion)).Id;
		public readonly static SpecialTriggeredAbility DeathCardPortrait = SpecialTriggeredAbilityManager.Add(PluginGuid, "DeathCardPortrait", typeof(SpecialAbilities.MagDeathCard)).Id;
		public static int spellsPlayed = 0;
		public static Sprite[] GBCmanaCostTextures = new Sprite[5];
		private void Start()
        {
			if (BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey("zorro.inscryption.infiniscryption.packmanager"))
			{
				CreatePack();
			}
		}	

		private void Awake()
		{
			Achievements.addAchievements();
			WallTextures.getImages();
			base.Logger.LogInfo("Loaded MagnificusMod!");
			Plugin.Directory = base.Info.Location.Replace("MagnificusMod.dll", "");
			Harmony harmony = new Harmony("silenceman.inscryption.magnificusmod");
			harmony.PatchAll();

			config.bindConfig();

			Sigils.ChangeMox();
			Sigils.LIFEUP();
			Sigils.Bleene();
			Sigils.SharkoHit();
			Sigils.BMDraw();
			Sigils.DropRuby();
			Sigils.DropEmerald();
			Sigils.DropSpear();
			Sigils.GemGuard();
			Sigils.GemAbsorb();
			Sigils.ImprovedTrap();
			Sigils.KrakenSubmerge();
			Sigils.Familiar();
			Sigils.Fading();
			Sigils.ReRoll();
			Sigils.LootOrlu();
			Sigils.Stimulate();
			Sigils.StimulateHP();
			Sigils.Goobert();
			Sigils.SpellBookSigil();
			Sigils.MagGainGemTriple();

			Sigils.Displacement();
			Sigils.MoxCycle();
			Sigils.DittoAbility();
			Sigils.MidasTouch();
			Sigils.MadeOfGold();
			Sigils.Purity();
			Sigils.Brewery();
			Sigils.FecundityCycleAbility();
			Sigils.SummonRunes();
			Sigils.Ignition();
			Sigils.MoxStrf();
			Sigils.PlatingWork();
			Sigils.Animator();
			Sigils.AddLifeSteal();

			SigilCode.CounterBatteryPower.InitStatIconAndAbility();
			SigilCode.SpellPower.InitStatIconAndAbility();
			SigilCode.KillSquid.InitStatIconAndAbility();
			SigilCode.CandleSquid.InitStatIconAndAbility();
			SigilCode.HealthForAnts.InitStatIconAndAbility();
			SigilCode.MoxHp.InitStatIconAndAbility();

			//this.RemoveAll();
			Cards.ChangeSquirrel();
			Cards.AddObelisk();
			Cards.AddAlmondCookie();
			Cards.AddAlchemist();
			Cards.AddBellMage();
			Cards.AddBlueMage();
			Cards.AddBlueSporeMage();
			//Cards.AddBoneSquid();
			//Cards.AddCandleSquid();
			Cards.AddKillSquid();
			Cards.AddSpellSquid();
			Cards.AddCounterbatterySquid();
			Cards.AddDunceMage();
			Cards.AddEmeraldMox();
			//Cards.AddEspearara();
			Cards.AddForceMage();
			//Cards.AddLonelyMage();
			Cards.AddGemFiend();
			Cards.AddGemFriend();
			Cards.AddMuscleMage();
			//Cards.AddSharko();
			Cards.AddHoverMage();
			Cards.AddInvisibleMage();/*
			Cards.ChangeDireWolf();
			Cards.ChangeCuckoo();
			Cards.ChangeRaccoon();*/
			Cards.AddMagePupil();
			Cards.AddOrangeMage();
			Cards.AddPracticeMage();
			//Cards.AddMasterKraken();
			Cards.AddRubyGolem();
			Cards.AddJrSage();
			Cards.AddKnightMage();
			Cards.AddGreenMage();
			//Cards.AddGoobert();
			Cards.AddMoxLarva();
			Cards.AddMoxBeast();
			Cards.AddGOMox();
			Cards.AddBGMox();
			Cards.AddBOMox();
			Cards.AddMasterGO();
			Cards.AddMasterBG();
			Cards.AddMasterOB();
			Cards.AddMagnusMox();

			Cards.AddMasterMagnus();
			Cards.AddMasterMagnus2();
			Cards.AddMasterMagnus3();
			Cards.AddFinalMagnus();
			Cards.AddHydras();

			Cards.AddRubyMox();
			Cards.AddSapphireMox();
			Cards.AddStimMage();
			Cards.AddStimMachine();
			Cards.AddSkeleMagus();
			Cards.AddSkeleSage();
			Cards.AddSpearCard();
			Cards.AddSwordSage();
			//Cards.AddUrayuliWizard();
			Cards.ChangeWolf();
			Cards.tailreplacement();
			Cards.ChangeRingWorm();

			Cards.ChangeStoat();
			Cards.AddPortraitMage();

			Cards.ChangeStinkbug();
			Cards.ChangeOuroboros();
			Cards.AddDruid();
			Cards.ChangeBullFrog();
			Cards.ChangePackrat();
			//Cards.ChangeAmalgam();
			Cards.AddBossExclusive();
			Cards.AddBossValkyrie();
			Cards.AddBleeneBooks();
			Sigils.ChangeMox();
			Sigils.DropRuby();
			Sigils.DropEmerald();
			Sigils.DropSpear();
			Cards.AddGemAbsorber();
			Cards.AddGemDetonator();
			Cards.AddGemShielder();
			Cards.Addhim();
			Cards.AddHomunculus();
			Cards.AddAuspex();
			Cards.AddMagimorph();
			Cards.AddMismagius();
			Cards.AddMultiplyMage();
			Cards.AddJester();
			Cards.AddRubyDaemon();
			Cards.AddEmeraldFiend();
			Cards.AddPerformer();
			Cards.AddMoxRabbit();
			Cards.AddGreenMoxRabbit();
			Cards.AddOrangeMoxRabbit();
			Cards.AddRunes();
			Cards.AddRuneMage();
			Cards.AddSnipeSage();
			Cards.AddMaux();

			Cards.AddRascalPack();
			Cards.AddRascal();
			Cards.AddGemboundRipper();
			Cards.AddMoxMage();
			Cards.AddErraticScholar();
			Cards.AddValkyrie();

			/*
			ChangeStump();
			ChangeTree();
			ChangeSnowTree();
			ChangeBoulder();
			*/
			Cards.AddGnome();
			Cards.AddScubaGnome();

			Sigils.HPSpellAbility();
			Sigils.ATKSpellAbility();
			Sigils.FrozenAbility();
			Sigils.FrostSpellAbility();
			Sigils.TargetFrostSpellAbility();
			Sigils.GoldSpellAbility();
			Sigils.WindSpellAbility();
			Sigils.WhirlwindSpellAbility();
			Sigils.WaterSpellAbility();
			Sigils.FlameSpellAbility();
			Sigils.TargetFlameSpellAbility();
			Sigils.MagnusSpellAbility();
			Sigils.VaseofGreedAbility();
			Sigils.GnomeAbility();
			Sigils.CursedAbility();
			Sigils.InspirationAbility();
			Sigils.FireballAbility();
			Sigils.RageAbility();
			Sigils.CalculusAbility();

			Cards.AddHPspell();
			Cards.AddATKspell();
			Cards.AddFrostspell();
			Cards.AddTargetFrostSpell();
			Cards.AddGoldspell();
			Cards.AddWindspell();
			Cards.AddWaterspell();
			Cards.AddFlamespell();
			Cards.AddTargetFlameSpell();
			Cards.AddMagnusspell();
			Cards.AddVaseofgreed();
			Cards.AddTrasmogification();
			Cards.AddCursedSkull();
			Cards.AddOrluSpell();
			Cards.AddGoranjSpell();
			Cards.AddBleeneSpell();
			Cards.AddFireball();

			Cards.AddPotion();

			Cards.AddSeniorSage();
			Cards.AddWhiteSmith();
			Cards.AddPuppeteer();
			Cards.AddCoffeMage();//<3
			Cards.AddTeaMage();//<3
			Cards.AddSodaMage();

			Cards.AddDrake();
			Cards.AddPheonix();
			Cards.AddBleenehound();
			Cards.AddFire();

			Cards.AddEdaxioLegs();
			Cards.AddEdaxioTorso();
			Cards.AddEdaxioArms();
			Cards.AddEdaxioHead();

			Sigils.FrostyAbility();
			Sigils.StrongPullAbility();

			Cards.AddMoon();
			Cards.AddMoonShards();
			Cards.AddVenus();
			Cards.AddMars();
			Cards.AddNeptune();
			Cards.AddMercury();
			Cards.AddJupiter();
			Cards.AddSaturn();
			Cards.AddEarth();

			Cards.AddDeathCard();
			try
			{
				bool isAscension = SaveFile.IsAscension;
				if (isAscension)
				{
					KayceeStorage.IsKaycee = true;
				}
				else
				{
					KayceeStorage.IsKaycee = false;
				}
			}
			catch
			{
			}
			
			KayceeFixes.ChallengeManagement.UpdateMagnificusChallenges();
			KayceeFixes.StarterDecks.RegisterStarterDecks();
			Generation.GetResources();

			Sprite mana1 = Tools.getSprite("mana_pixel cost 1.png");
			Sprite mana2 = Tools.getSprite("mana_pixel cost 2.png");
			GBCmanaCostTextures = new Sprite[5];
			GBCmanaCostTextures[1] = mana1;
			GBCmanaCostTextures[2] = mana2;
			GBCmanaCostTextures[3] = mana2;
			GBCmanaCostTextures[4] = mana2;

		}
		public static bool specialBossSequence = false;

		public static CardMetaCategory SpellPool = (CardMetaCategory)InscryptionAPI.Guid.GuidManager.GetEnumValue<CardMetaCategory>(PluginGuid, "MagSpellPool");

		public static void CreatePack()
		{
			PackInfo incrediPack = PackManager.GetPackInfo("mag");
			incrediPack.Title = "Inscryption: Magickal Card Expansion Pack";
			incrediPack.SetTexture(Tools.getImage("wizardcardpack.png"));
			incrediPack.Description = "Harness the might of the moxen to summon forth apprentices and fight in the most honorable of duels. (Magnificus Mod Cards)";
			incrediPack.ValidFor.Add(PackInfo.PackMetacategory.MagnificusPack);

		}
		private void Update()
		{
			try
			{
				bool flag = SceneLoader.ActiveSceneName == "finale_magnificus";
				bool flag2 = flag;
				if (flag2)
				{
					bool flag3 = !Generation.allcardssummoned;
					bool flag4 = flag3;
					List<Ability> bannedAbilites = new List<Ability> { Ability.QuadrupleBones, Ability.StrafePush, Ability.Strafe, Ability.Sentry, Ability.PermaDeath, Ability.CellTriStrike, Ability.CellDrawRandomCardOnDeath, Ability.CellBuffSelf, Ability.ConduitSpawnGems, Ability.ShieldGems, Ability.Transformer, Ability.DeleteFile, Ability.LatchBrittle, Ability.LatchDeathShield, Ability.LatchExplodeOnDeath, Ability.FileSizeDamage, Ability.GainBattery, Ability.ConduitNull, Ability.ConduitBuffAttack };
					if (flag4)
					{
						Generation.allcardssummoned = true;
						List<RuleBookPageInfo> list = new List<RuleBookPageInfo>();
						try
						{
							foreach (PageRangeInfo pageRangeInfo in Singleton<RuleBookController>.Instance.bookInfo.pageRanges.FindAll((PageRangeInfo info) => info.type == PageRangeType.Abilities))
							{
								List<int> customAbilities = (from x in ScriptableObjectLoader<AbilityInfo>.AllData
															 select (int)x.ability).ToList<int>();
								int startIndex = customAbilities.AsQueryable<int>().Min<int>();
								int num = customAbilities.AsQueryable<int>().Max<int>();
								PageRangeInfo pageRangeInfo2 = pageRangeInfo;
								pageRangeInfo2.type = PageRangeType.Abilities;
								Func<int, bool> doAddPageFunc = (int index) => (customAbilities.Contains(index) && bannedAbilites.IndexOf(AbilitiesUtil.GetInfo((Ability)index).ability) < 0 && !AbilitiesUtil.GetInfo((Ability)index).metaCategories.Contains(AbilityMetaCategory.MagnificusRulebook) && AbilitiesUtil.GetInfo((Ability)index).metaCategories.Contains(AbilityMetaCategory.Part1Rulebook)) || (customAbilities.Contains(index) && bannedAbilites.IndexOf(AbilitiesUtil.GetInfo((Ability)index).ability) < 0 && AbilitiesUtil.GetInfo((Ability)index).metaCategories.Contains(AbilityMetaCategory.Part3Rulebook)) || (customAbilities.Contains(index) && bannedAbilites.IndexOf(AbilitiesUtil.GetInfo((Ability)index).ability) < 0 && AbilitiesUtil.GetInfo((Ability)index).metaCategories.Contains(AbilityMetaCategory.Part1Modular)) || (customAbilities.Contains(index) && bannedAbilites.IndexOf(AbilitiesUtil.GetInfo((Ability)index).ability) < 0 && AbilitiesUtil.GetInfo((Ability)index).metaCategories.Contains(AbilityMetaCategory.Part3Modular));

								list.AddRange(Singleton<RuleBookController>.Instance.bookInfo.ConstructPages(pageRangeInfo2, num + 1, startIndex, doAddPageFunc, new Action<RuleBookPageInfo, PageRangeInfo, int>(Singleton<RuleBookController>.Instance.bookInfo.FillAbilityPage), Localization.Translate("l")));
							}
							Singleton<RuleBookController>.Instance.PageData.AddRange(list);
						}
						finally
						{
						}
					}
				}
			}
			catch (NullReferenceException)
			{
			}
			/*if (SceneLoader.ActiveSceneName == "finale_magnificus")
			{
				int b = 0;
				b++;
				bool flag5 = b != 0;
				if (flag5)
				{
					foreach (Light light in GameObject.FindObjectsOfType<Light>())
					{
						light.color = new Color(0.9137255f, 0.9137255f, 0.9137255f, 1f);
					}
					b = 0;
				}
			}*/
		}

		private void RemoveAll()
		{
			List<string> list = new List<string>
			{
				"Wolf",
				"RingWorm",
				"Ant",
				"AntQueen",
				"Adder",
				"Adder",
				"Alpha",
				"Amoeba",
				"Bat",
				"Bee",
				"Beaver",
				"Beehive",
				"Bloodhound",
				"Cat",
				"Cockroach",
				"Coyote",
				"Daus",
				"Elk",
				"ElkCub",
				"FieldMouse",
				"Goat",
				"Grizzly",
				"JerseyDevil",
				"Kingfisher",
				"Maggots",
				"Magpie",
				"Mantis",
				"MantisGod",
				"Mole",
				"MoleMan",
				"Moose",
				"Mothman_Stage1",
				"Opossum",
				"Otter",
				"Porcupine",
				"Pronghorn",
				"RatKing",
				"Rattler",
				"Raven",
				"RavenEgg",
				"Shark",
				"Skink",
				"Skunk",
				"Snapper",
				"Snelk",
				"Sparrow",
				"SquidCards",
				"SquidBell",
				"SquidMirror",
				"Urayuli",
				"Vulture",
				"Warren",
				"WolfCub",
				"PeltHare",
				"PeltWolf",
				"PeltGolden",
				"Stinkbug_Talking",
				"Stoat_Talking",
				"Wolf_Talking",
				"Geck",
				"AquaSquirrel",
				"Bull",
				"DireWolfCub",
				"Hodag",
				"Hydra",
				"Lammergeier",
				"Lice",
				"MealWorm",
				"MudTurtle",
				"Raccoon",
				"RedHart",
				"Wolverine",
				"Stoat",
				"Skink",
				"Kraken"
			};
			for (int i = 0; i < list.Count; i++)
			{
				List<CardMetaCategory> metaCategories = new List<CardMetaCategory>();
				CardInfo card = InscryptionAPI.Card.CardManager.BaseGameCards.CardByName(list[i]);
				card.metaCategories = metaCategories;
			}
		}


		



		public const string PluginGuid = "silenceman.inscryption.magnificusmod";

		public const string PluginName = "MagnificusMod";

		public const string PluginVersion = "3.0.1";

		public static string lastMox = "";

		public static string Directory;



		
	}
}
