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

		public readonly static SpecialTriggeredAbility OuroChange = SpecialTriggeredAbilityManager.Add(PluginGuid, "Ouro Random", typeof(SpecialAbilities.OuroRandomize)).Id;
		public readonly static SpecialTriggeredAbility CustomPortrait = SpecialTriggeredAbilityManager.Add(PluginGuid, "Custom Portrait", typeof(SpecialAbilities.CustomPortraited)).Id;
		public readonly static SpecialTriggeredAbility PotionStuff = SpecialTriggeredAbilityManager.Add(PluginGuid, "PotionStuff", typeof(SpecialAbilities.Potion)).Id;
		public readonly static SpecialTriggeredAbility DeathCardPortrait = SpecialTriggeredAbilityManager.Add(PluginGuid, "DeathCardPortrait", typeof(SpecialAbilities.MagDeathCard)).Id;
		public static int spellsPlayed = 0;
		public static Sprite[] GBCmanaCostTextures = new Sprite[5];
		public static Sprite[] ControlsHintFrames = new Sprite[2];
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
			Sigils.DropSapphire();
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
			Sigils.ProjectorSigil();
			Sigils.AddLifeSteal();
			Sigils.BoneMarrows();
			Sigils.SelectMox();
			Sigils.GemReckoning();
			Sigils.ScholarSigil();

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
			Cards.AddSapphireMech();
			Cards.AddMidasCard();
			Cards.AddJoker();

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
			Cards.AddGourmage();

			//Cards.AddRascalPack();
			//Cards.AddRascal();
			Cards.AddDefaultAstralProjection();
			Cards.AddAstralSorcererProjection();
			Cards.AddAstralProjector();
			Cards.AddGemboundRipper();
			Cards.AddMoxMage();
			Cards.AddErraticScholar();
			Cards.AddValkyrie();
			Cards.AddPrismaticShards();
			Cards.AddTutorWorm();
			Cards.AddRubyMenace();
			Cards.AddBleenesMonster();
			Cards.AddOrcUnderling();
			Cards.AddCrystalSage();

			/*
			ChangeStump();
			ChangeTree();
			ChangeSnowTree();
			ChangeBoulder();
			*/
			Cards.AddGnome();
			Cards.AddMushroomMage();
			//Cards.AddScubaGnome();

			Sigils.FlameSpellAbility();
			Sigils.HPSpellAbility();
			Sigils.ATKSpellAbility();
			Sigils.FrozenAbility();
			Sigils.FrostSpellAbility();
			Sigils.WindSpellAbility();
			Sigils.WhirlwindSpellAbility();
			Sigils.WaterSpellAbility();
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
			Cards.AddWindspell();
			Cards.AddWaterspell();
			Cards.AddTargetFlameSpell();
			Cards.AddFlameSpell();
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
			Cards.AddCoffeMage();//cider
			Cards.AddTeaMage();//brewery
			Cards.AddSodaMage();
			Cards.AddMasterKraken();

			Cards.AddChaosMage();
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
			Cards.AddUranus();
			Cards.AddPluto();
			Cards.AddEarth();



			Cards.AddDeathCard();
			try
			{
				KayceeStorage.IsKaycee = SaveFile.IsAscension;
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
			GBCmanaCostTextures[0] = null;
			GBCmanaCostTextures[1] = mana1;
			GBCmanaCostTextures[2] = mana2;
			GBCmanaCostTextures[3] = mana2;
			GBCmanaCostTextures[4] = mana2;

			ControlsHintFrames = new Sprite[4];
			ControlsHintFrames[0] = Tools.getSprite("controlshint_tab.png");
			ControlsHintFrames[1] = Tools.getSprite("controlshint_tab_faded.png");
			ControlsHintFrames[2] = Tools.getSprite("controlshint_qe.png");
			ControlsHintFrames[3] = Tools.getSprite("controlshint_qe_faded.png");

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
				if (SceneLoader.ActiveSceneName != "finale_magnificus") { return; }
				if (Generation.allcardssummoned) { return; }

				List<Ability> bannedAbilites = new List<Ability> { Ability.QuadrupleBones, Ability.BeesOnHit, Ability.Sentry, Ability.PermaDeath, Ability.CellTriStrike, Ability.CellDrawRandomCardOnDeath, Ability.CellBuffSelf, Ability.ConduitSpawnGems, SigilCode.GemGuardianFix.ability, Ability.Transformer, Ability.DeleteFile, Ability.LatchBrittle, Ability.LatchDeathShield, Ability.LatchExplodeOnDeath, Ability.FileSizeDamage, Ability.GainBattery, Ability.ConduitNull, Ability.ConduitBuffAttack, Ability.GemsDraw, Ability.DropRubyOnDeath };

                foreach (AbilityInfo ability in ScriptableObjectLoader<AbilityInfo>.AllData)
				{
					if (ability.ability != Ability.GainGemBlue && ability.ability != Ability.GainGemGreen && ability.ability != Ability.GainGemOrange) { continue; }
					ability.canStack = true;
				}


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

		
		public static void unlockMost()
        {
			GameProgressConfig.SetPhase(GameProgressConfig.GamePhase.Part1Completed);
			SaveManager.SaveFile.ResetGBCSaveData();
			StoryEventsData.SetEventCompleted(StoryEvent.StartScreenNewGameUsed);
			foreach (CardInfo cardInfo in CardLoader.allData)
			{
				ProgressionData.SetCardLearned(cardInfo);
			}
			SaveManager.saveFile.currentScene = "finale_magnificus";
		}


		public const string PluginGuid = "silenceman.inscryption.magnificusmod";

		public const string PluginName = "MagnificusMod";

		public const string PluginVersion = "3.6.0";

		public static string lastMox = "";

		public static string Directory;



		
	}
}
