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

		public readonly static SpecialTriggeredAbility ManaTutorial = SpecialTriggeredAbilityManager.Add(PluginGuid, "Mana Cost", typeof(ManaCost)).Id;
		public readonly static SpecialTriggeredAbility Romance = SpecialTriggeredAbilityManager.Add(PluginGuid, "Lesbians", typeof(Lesbiane)).Id;
		public readonly static SpecialTriggeredAbility OuroChange = SpecialTriggeredAbilityManager.Add(PluginGuid, "Ouro Random", typeof(OuroRandomize)).Id;
		public readonly static SpecialTriggeredAbility CustomPortrait = SpecialTriggeredAbilityManager.Add(PluginGuid, "Custom Portrait", typeof(CustomPortraited)).Id;
		public readonly static SpecialTriggeredAbility PotionStuff = SpecialTriggeredAbilityManager.Add(PluginGuid, "PotionStuff", typeof(Potion)).Id;
		public readonly static SpecialTriggeredAbility DeathCardPortrait = SpecialTriggeredAbilityManager.Add(PluginGuid, "DeathCardPortrait", typeof(MagDeathCard)).Id;
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
			WallTextures.GetTextures();
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
			Cards.ChangeGeck();
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

		//save stuff (Stop)
		public class MagCurrentNode
		{
			public static void getCleared()
			{
				string text;
				try
				{
					text = File.ReadAllText(SaveManager.SaveFolderPath + "MagnificusModSave.gwsave");
				}
				catch
				{
					Plugin.MagCurrentNode.SaveNode("x4 y7");
					File.WriteAllText(SaveManager.SaveFolderPath + "MagnificusModSave.gwsave", SaveManager.ToJSON(Plugin.MagCurrentNode.GetNodeStuff(false, true)));
					text = File.ReadAllText(SaveManager.SaveFolderPath + "MagnificusModSave.gwsave");
				}
				string[] array = text.Split(new char[]
				{
					'x'
				}, 2);
				string text2 = "x" + array[1];
				string[] array2 = text2.Split(new char[]
				{
					'C'
				});
				string[] array3 = array2[1].Split(new char[]
				{
					','
				});
				for (int i = 0; i < array3.Length; i++)
				{
					bool flag = !Utility.IsNullOrWhiteSpace(array3[i]);
					if (flag)
					{
						Plugin.MagCurrentNode.clearedNode.Add(array3[i]);
					}
				}
			}
			public static string GetCoords()
            {
				string text;
				try
				{
					text = File.ReadAllText(SaveManager.SaveFolderPath + "MagnificusModSave.gwsave");
				}
				catch
				{
					Plugin.MagCurrentNode.SaveNode("x4 y7");
					File.WriteAllText(SaveManager.SaveFolderPath + "MagnificusModSave.gwsave", SaveManager.ToJSON(Plugin.MagCurrentNode.GetNodeStuff(false, true)));
					text = File.ReadAllText(SaveManager.SaveFolderPath + "MagnificusModSave.gwsave");
				}
				string[] array = text.Split(new char[]
				{
					'x'
				}, 2);
				string text2 = "x" + array[1];
				string[] array2 = text2.Split(new char[]
				{
					'C'
				});
				string[] array3 = array2[0].Split(new char[]
				{
					','
				});
				MagCurrentNode.SaveNode(array3[0]);
				return array3[0];
			}

			public static string GetLayout()
			{
				string text = File.ReadAllText(SaveManager.SaveFolderPath + "MagnificusModSave.gwsave");
				string[] array = text.Split(new char[]
				{
					'L'
				});
				string roomreturn = array[1];
				layout = roomreturn;
				string[] test;
				string elArray = array[1];
				if (elArray.Contains('\\'))
				{
					test = array[1].Split('\\');
					layout = test[0];
					roomreturn = test[0];
				}
				return roomreturn;
			}

			public static void GetSideDeck()
			{
				string text = File.ReadAllText(SaveManager.SaveFolderPath + "MagnificusModSave.gwsave");
				string[] array = text.Split(new char[]
				{
					'R'
				});
				array = array[1].Split(new char[]
				{
					','
				});
				string[] array2 = array[2].Split(new char[]
				{
					'"'
				});
				Plugin.MagCurrentNode.sideDeck[0] = int.Parse(array[0]);
				Plugin.MagCurrentNode.sideDeck[1] = int.Parse(array[1]);
				Plugin.MagCurrentNode.sideDeck[2] = int.Parse(array2[0]);
			}

			public static void GetRoomLayout()
			{
				string text = File.ReadAllText(SaveManager.SaveFolderPath + "MagnificusModSave.gwsave");
				string[] array = text.Split(new char[]
				{
					'L'
				});
				string[] array2 = array[2].Split(new char[]
				{
					'"'
				});
				Plugin.MagCurrentNode.layout = array2[0];
			}

			public static void SaveLayout(string layout)
			{
				Plugin.MagCurrentNode.layout = layout;
			}

			public static void SaveNode(string nodeName)
			{
				Plugin.MagCurrentNode.currentNodeName = nodeName;
			}

			public static void ClearNode(string nodeName)
			{
				Plugin.MagCurrentNode.clearedNode.Add(nodeName);
			}

			public static void editSideDeck(int r, int g, int b)
			{
				List<int> list = Plugin.MagCurrentNode.sideDeck;
				list[0] = list[0] + r;
				list = Plugin.MagCurrentNode.sideDeck;
				list[1] = list[1] + g;
				list = Plugin.MagCurrentNode.sideDeck;
				list[2] = list[2] + b;
			}

			public static string GetNodeStuff(bool clear, bool clearSideDeck = true)
			{
				string text = Plugin.MagCurrentNode.currentNodeName;
				text += "C";
				string result;
				if (clear)
				{
					Plugin.MagCurrentNode.clearedNode = new List<string>();
					if (clearSideDeck)
					{
						Plugin.MagCurrentNode.sideDeck = new List<int>
						{
							3,
							4,
							3
						};
						text = "x4 y7CR3,4,3,L";
					}
					else
					{
						text = "x4 y7CR";
						for (int i = 0; i < Plugin.MagCurrentNode.sideDeck.Count; i++)
						{
							text = text + Plugin.MagCurrentNode.sideDeck[i].ToString() + ",";
						}
						text += "L";
					}
					result = text;
				}
				else
				{
					string text2 = "";
					for (int j = 0; j < Plugin.MagCurrentNode.clearedNode.Count; j++)
					{
						bool flag = !Utility.IsNullOrWhiteSpace(Plugin.MagCurrentNode.clearedNode[j]) && Plugin.MagCurrentNode.clearedNode[j].ToLower().Contains('x') && !text2.ToLower().Contains(Plugin.MagCurrentNode.clearedNode[j].ToLower());
						if (flag)
						{
							text2 = text2 + Plugin.MagCurrentNode.clearedNode[j] + ",";
							text = text + Plugin.MagCurrentNode.clearedNode[j] + ",";
						}
					}
					text += "R";
					for (int k = 0; k < Plugin.MagCurrentNode.sideDeck.Count; k++)
					{
						text = text + Plugin.MagCurrentNode.sideDeck[k].ToString() + ",";
					}
					text += "L" + layout;
					result = text;
				}
				return result;
			}

			[SerializeField]
			public static string currentNodeName = "";

			[SerializeField]
			public static string layout = "";

			[SerializeField]
			public static List<string> clearedNode = new List<string>();

			[SerializeField]
			public static List<int> sideDeck = new List<int>
			{
				3,
				4,
				3
			};
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

		public int i = 0;

		public int b = 0;

		/*
		[HarmonyPatch(typeof(TextDisplayer), "Start")]
		public class BoardManager3D_Initialize
		{
			public static void Prefix()
			{
				bool flag = !GameObject.Find("TextDisplayer_Magnificus(Clone)");
				if (flag)
				{
					GameObject.Instantiate(Resources.Load("prefabs/ui/TextDisplayer_Magnificus"));
					GameObject.Find("TextDisplayer").GetComponent<TextDisplayer>().voiceSoundIdPrefix = GameObject.Find("TextDisplayer_Magnificus(Clone)").GetComponent<TextDisplayer>().voiceSoundIdPrefix;
					GameObject.Find("TextDisplayer").GetComponent<TextDisplayer>().continuePressed = GameObject.Find("TextDisplayer_Magnificus(Clone)").GetComponent<TextDisplayer>().continuePressed;
					GameObject.Find("TextDisplayer").GetComponent<TextDisplayer>().defaultStyle = GameObject.Find("TextDisplayer_Magnificus(Clone)").GetComponent<TextDisplayer>().defaultStyle;
					GameObject.Find("TextDisplayer").GetComponent<TextDisplayer>().textAnimation = GameObject.Find("TextDisplayer_Magnificus(Clone)").GetComponent<TextDisplayer>().textAnimation;
					GameObject.Find("TextDisplayer").GetComponent<TextDisplayer>().textMesh = GameObject.Find("TextDisplayer_Magnificus(Clone)").GetComponent<TextDisplayer>().textMesh;
					GameObject.Find("TextDisplayer").GetComponent<TextDisplayer>().textShadow = GameObject.Find("TextDisplayer_Magnificus(Clone)").GetComponent<TextDisplayer>().textShadow;
					GameObject.Find("TextDisplayer").GetComponent<TextDisplayer>().triangleImage = GameObject.Find("TextDisplayer_Magnificus(Clone)").GetComponent<TextDisplayer>().triangleImage;
					GameObject.Find("TextDisplayer").GetComponent<TextDisplayer>().alternateSpeakerStyles = GameObject.Find("TextDisplayer_Magnificus(Clone)").GetComponent<TextDisplayer>().alternateSpeakerStyles;
				}
			}
		}
		*/


		[HarmonyPatch(typeof(SexyGoat), "ApplyAppearance")]
		public class sussyGoat
		{
			public static bool Prefix(ref SexyGoat __instance)
			{
				bool flag = __instance.Card.Info.name == "Goat";
				if (flag)
				{
					bool flag2 = RunState.Run.eyeState == EyeballState.Goat;
					if (flag2)
					{

						Texture2D texture2D = Tools.GetTexture("mognus mox.png");

						List<Texture> list = new List<Texture>();
						list.Add(texture2D);
						__instance.Card.Info.decals = list;
					}
				}
				else
				{
					if (__instance.Card.Info.name == "mag_invisimage" && RunState.Run.eyeState == EyeballState.Wizard)
					{
						__instance.Card.renderInfo.portraitOverride = Tools.getPortraitSprite("visiinvisimage.png");
					}
				}
				return false;
			}
		}

		/*
		[HarmonyPatch(typeof(BoardManager3D), "Start")]
		public class slotPatch
		{
			private static void Prefix(ref BoardManager3D __instance)
			{
				foreach (CardSlot cardSlot in __instance.AllSlotsCopy)
				{
					cardSlot.GetComponentInChildren<MeshRenderer>().material.mainTexture = (Resources.Load("art/cards/card_slot_wizard") as Texture);
				}
				Color gray = GameColors.Instance.gray;
				gray.a = 0.5f;
				Singleton<TableVisualEffectsManager>.Instance.ChangeTableColors(GameColors.Instance.nearWhite, GameColors.Instance.nearWhite, GameColors.Instance.nearWhite, gray, GameColors.Instance.nearWhite, GameColors.Instance.nearWhite, GameColors.Instance.gray, GameColors.instance.nearWhite, GameColors.instance.nearWhite);
				__instance.HideAllSlots();
				__instance.Bell.SetBesideBoard(false, true);
				ViewManager instance = Singleton<ViewManager>.Instance;
				instance.ViewChanged = (Action<View, View>)Delegate.Combine(instance.ViewChanged, new Action<View, View>(__instance.OnViewChanged));
			}
		}
		*/

		[HarmonyPatch(typeof(TailOnHit), "OnCardGettingAttacked")]
		public class skinkFix
		{
			public static void Prefix(out TailOnHit __state, ref TailOnHit __instance)
			{
				__state = __instance;
			}

			public static IEnumerator Postfix(IEnumerator enumerator, TailOnHit __state)
			{
				CardSlot slot = __state.Card.Slot;
				CardSlot toLeft = Singleton<BoardManager>.Instance.GetAdjacent(__state.Card.Slot, true);
				CardSlot toRight = Singleton<BoardManager>.Instance.GetAdjacent(__state.Card.Slot, false);
				bool flag = toLeft != null && toLeft.Card == null;
				bool toRightValid = toRight != null && toRight.Card == null;
				bool flag2 = flag || toRightValid;
				if (flag2)
				{
					yield return __state.PreSuccessfulTriggerSequence();
					yield return new WaitForSeconds(0.2f);
					bool flag3 = toRightValid;
					if (flag3)
					{
						yield return Singleton<BoardManager>.Instance.AssignCardToSlot(__state.Card, toRight, 0.2f, null, true);
					}
					else
					{
						yield return Singleton<BoardManager>.Instance.AssignCardToSlot(__state.Card, toLeft, 0.2f, null, true);
					}
					__state.Card.Anim.StrongNegationEffect();
					__state.Card.Status.hiddenAbilities.Add(__state.Ability);
					__state.Card.RenderCard();
					__state.SetTailLost(true);
					yield return new WaitForSeconds(0.2f);
					CardInfo info;
					if (__state.Card.Info.tailParams != null)
					{
						info = (__state.Card.Info.tailParams.tail.Clone() as CardInfo);
					}
					else
					{
						info = TailParams.GetDefaultTail(__state.Card.Info);
					}
					PlayableCard tail = CardSpawner.SpawnPlayableCardWithCopiedMods(info, __state.Card, Ability.TailOnHit);
					tail.transform.position = slot.transform.position + Vector3.back * 2f + Vector3.up * 2f;
					tail.transform.rotation = Quaternion.Euler(110f, 90f, 90f);
					yield return Singleton<BoardManager>.Instance.ResolveCardOnBoard(tail, slot, 0.1f, null, true);
					Singleton<ViewManager>.Instance.SwitchToView(View.Board, false, false);
					yield return new WaitForSeconds(0.2f);
					tail.Anim.StrongNegationEffect();
					yield return __state.StartCoroutine(__state.LearnAbility(0.5f));
					yield return new WaitForSeconds(0.2f);
				}
				yield break;
			}
		}


		public class ManaCost : SpecialCardBehaviour
		{
			public override bool RespondsToDrawn()
			{
				return !SavedVars.LearnedMechanics.Contains("mana;");
			}

			public override IEnumerator OnDrawn()
			{
				(Singleton<PlayerHand>.Instance as PlayerHand3D).MoveCardAboveHand(base.PlayableCard);
				Singleton<ViewManager>.Instance.SwitchToView(View.Default);
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Ah.. It appears you have drawn a card with a [c:g3]special cost[c:].", -1.5f, 0f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("These cards require [c:g1]mana shards[c:] to play..", -1.5f, 0f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("[c:g1]Mana shards[c:] are gained from 'Sacrificing' mox cards..", -3.5f, 0f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput(".. So, when played you will need to destroy " + base.Card.Info.BloodCost + " mox.", -3.5f, 0f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("It's all quite simple..", -1.5f, 0f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
				yield return new WaitForSeconds(0.4f);
				SavedVars.LearnedMechanics += "mana;";
				yield break;
			}
		}

		public class Lesbiane : SpecialCardBehaviour
		{
			public override bool RespondsToResolveOnBoard()
			{
				return true;
			}

			public override IEnumerator OnResolveOnBoard()
			{
				List<CardSlot> slots = Singleton<BoardManager>.Instance.PlayerSlotsCopy;
				for (int i = 0; i < slots.Count; i++)
                {
					if (slots[i].Card != null)
                    {
						if (slots[i].Card.Info.name == "mag_teamage" && base.PlayableCard.Info.name == "mag_coffeemage" || slots[i].Card.Info.name == "mag_coffeemage" && base.PlayableCard.Info.name == "mag_teamage")
                        {
							string partnerWhere = "idk";
							if (slots[i].Index == 0 && slots[1].Card == null)
							{
								yield return Singleton<BoardManager>.Instance.AssignCardToSlot(base.PlayableCard, slots[1], 0.11f, null, true);
								partnerWhere = "left";
								yield return new WaitForSeconds(0.2f);
							}
							else if (slots[i].Index == 0 && slots[1].Card != null)
							{
								CardSlot baseSlot = base.PlayableCard.slot;
								yield return Singleton<BoardManager>.Instance.AssignCardToSlot(base.PlayableCard, slots[1], 0.11f, null, true);
								yield return Singleton<BoardManager>.Instance.AssignCardToSlot(slots[1].Card, baseSlot, 0.11f, null, true);
								partnerWhere = "left";
							}
								
							if (slots[i].Index == 3 && slots[2].Card == null)
							{
								partnerWhere = "right";
								yield return Singleton<BoardManager>.Instance.AssignCardToSlot(base.PlayableCard, slots[2], 0.11f, null, true);
								yield return new WaitForSeconds(0.2f);
							}
							else if (slots[i].Index == 3 && slots[2].Card != null)
							{
								partnerWhere = "right";
								CardSlot baseSlot = base.PlayableCard.slot;
								yield return Singleton<BoardManager>.Instance.AssignCardToSlot(slots[2].Card, baseSlot, 0.11f, null, true);
								yield return Singleton<BoardManager>.Instance.AssignCardToSlot(base.PlayableCard, slots[2], 0.11f, null, true);
								yield return new WaitForSeconds(0.2f);
							}

							if (slots[i].Index != 3 && slots[i].Index != 0)
                            {
								int dex = slots[i].Index;
								if (slots[dex - 1].Card != null && slots[dex + 1].Card == null)
                                {
									partnerWhere = "left";
									yield return Singleton<BoardManager>.Instance.AssignCardToSlot(base.PlayableCard, slots[dex + 1], 0.11f, null, true);
								} else if (slots[dex - 1].Card == null && slots[dex + 1].Card != null)
                                {
									partnerWhere = "right";
									yield return Singleton<BoardManager>.Instance.AssignCardToSlot(base.PlayableCard, slots[dex - 1], 0.11f, null, true);
								}
								else if (slots[dex - 1].Card != null && slots[dex + 1].Card != null)
								{
									partnerWhere = "right";
									CardSlot baseSlot = base.PlayableCard.slot;
									yield return Singleton<BoardManager>.Instance.AssignCardToSlot(slots[dex - 1].Card, baseSlot, 0.11f, null, true);
									yield return Singleton<BoardManager>.Instance.AssignCardToSlot(base.PlayableCard, slots[dex - 1], 0.11f, null, true);
									yield return new WaitForSeconds(0.2f);
								}

							}

							if (base.PlayableCard.Info.name == "mag_coffeemage" && partnerWhere == "left")
                            {
								base.PlayableCard.renderInfo.flippedPortrait = true;
								slots[base.PlayableCard.slot.Index - 1].Card.renderInfo.flippedPortrait = true;
                            } else if (base.PlayableCard.Info.name == "mag_teamage" && partnerWhere == "right")
							{
								base.PlayableCard.renderInfo.flippedPortrait = true;
								slots[base.PlayableCard.slot.Index + 1].Card.renderInfo.flippedPortrait = true;
							}
						}
                    }
                }
				yield break;
			}
		}

	

		public class OuroRandomize : SpecialCardBehaviour
		{
			public override bool RespondsToDrawn()
			{
				return true;
			}
			public override IEnumerator OnDrawn()
			{
				AddMod();
				yield break;
			}

			private void AddMod()
			{
				List<GemType> baseCosts = new List<GemType> { GemType.Green, GemType.Orange, GemType.Blue };
				CardModificationInfo mod = new CardModificationInfo();
				List<GemType> newGem = new List<GemType>();
				mod.nullifyGemsCost = true;
				GemType rand = baseCosts[Random.RandomRangeInt(0, baseCosts.Count)];
				switch (rand)
				{
					case GemType.Blue:
						newGem = new List<GemType> { GemType.Orange };
						base.PlayableCard.renderInfo.portraitOverride = Tools.getPortraitSprite("mag_oroborous1.png");
						break;
					case GemType.Orange:
						newGem = new List<GemType> { GemType.Green };
						base.PlayableCard.renderInfo.portraitOverride = Tools.getPortraitSprite("mag_oroborous.png");
						break;
					case GemType.Green:
						newGem = new List<GemType> { GemType.Blue };
						base.PlayableCard.renderInfo.portraitOverride = Tools.getPortraitSprite("mag_oroborous2.png");
						break;
				}
				mod.addGemCost = newGem;

				List<CardModificationInfo> whoToKill = new List<CardModificationInfo>();

				foreach(CardModificationInfo modinfo in base.PlayableCard.Info.mods)
                {
					if (modinfo.nullifyGemsCost)
                    {
						whoToKill.Add(modinfo);
                    }
                }

				foreach(CardModificationInfo modinfo in whoToKill)
                {
					base.PlayableCard.Info.mods.Remove(modinfo);
                }

				base.PlayableCard.Info.mods.Add(mod);
				base.PlayableCard.RenderCard();
			}
		}

		public class Potion : SpecialCardBehaviour
		{
			public void Awake()
            {
				if (base.Card.Info.mods.Count > 0)
				{
					Sprite portraitOverride;
					switch (base.Card.Info.mods[0].decalIds[0])
                    {
						default:
							portraitOverride = Tools.getSprite("potion_green.png");
							break;
						case "mana":
							portraitOverride = Tools.getSprite("potion_mana.png");
							break;
						case "blue":
							portraitOverride = Tools.getSprite("potion_blue.png");
							break;
						case "orange":
							portraitOverride = Tools.getSprite("potion_orange.png");
							break;
					}
					base.Card.renderInfo.portraitOverride = portraitOverride;
					base.Card.RenderCard();
				}
			}

			public override bool RespondsToSlotTargetedForAttack(CardSlot slot, PlayableCard attacker)
			{
				if (slot.Card != null)
				{
					return slot.Card != null && slot.IsPlayerSlot;
				}

				return false;
			}

			public override IEnumerator OnSlotTargetedForAttack(CardSlot slot, PlayableCard attacker)
			{
				if (slot.Card != null)
				{
					AudioController.Instance.PlaySound2D("wizard_opponent_summon", MixerGroup.TableObjectsSFX, 1f, 0f, null, null, null, null, false);
					CardModificationInfo tempMod = new CardModificationInfo();
					tempMod.abilities.AddRange(base.PlayableCard.Info.Abilities);
					tempMod.attackAdjustment = base.Card.Info.Attack;
					tempMod.healthAdjustment = base.Card.Info.Health;
					slot.Card.AddTemporaryMod(tempMod);
					if (!slot.Card.Dead)
					{
						slot.Card.RenderCard();
						int dex;
						dex = slot.Index;
						string slotName = slot.IsPlayerSlot ? "PlayerSlots" : "OpponentSlots";
						if (GameObject.Find(slotName).transform.GetChild(dex).childCount > 5)
						{
							GameObject model = GameObject.Find(slotName).transform.GetChild(dex).GetChild(5).gameObject;
							model.GetComponent<Card>().RenderCard();
						}
					}
				}
				yield break;
			}
		}

		public class MagDeathCard : SpecialCardBehaviour
		{
			public void Awake()
			{
				if (base.Card.Info.mods.Count > 0)
				{
					GameObject headTex = GameObject.Instantiate(new GameObject());
					headTex.name = "head";
					headTex.transform.parent = base.Card.gameObject.transform;
					headTex.transform.localPosition = new Vector3(0f, -0.01f, 0.2f);
					headTex.transform.localScale = new Vector3(0.75f, 0.85f, 1f);
					headTex.transform.localRotation = Quaternion.Euler(0, 0, 0);

					if (base.Card.gameObject.transform.GetChild(0).gameObject.name == "DustParticles")
					{
						headTex.transform.parent = base.Card.gameObject.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(0).GetChild(0);
						headTex.transform.localRotation = Quaternion.Euler(270, 180, 0);
						headTex.transform.localPosition = new Vector3(0f, -0.01f, 0.2f);
					}
					else if (base.Card.gameObject.GetComponent<WizardBattle3DPortrait>() == null)
					{
						headTex.transform.parent = base.Card.gameObject.transform.GetChild(0).GetChild(0);
						headTex.transform.localRotation = Quaternion.Euler(0, 180, 0);
						headTex.transform.localPosition = new Vector3(0f, 0.1f, -0.01f);
					}
					else
					{
						headTex.transform.localRotation = Quaternion.Euler(0, 180, 0);
						headTex.transform.localPosition = new Vector3(0, 0.2f, -0.01f);
					}
					headTex.AddComponent<SpriteRenderer>().sprite = Tools.getSprite("deathcardhead" + base.Card.Info.mods[0].buildACardPortraitInfo.spriteIndices[0] + ".png");

					GameObject bodyTex = GameObject.Instantiate(headTex);
					bodyTex.name = "body";
					bodyTex.transform.parent = headTex.transform.parent;
					bodyTex.transform.localScale = headTex.transform.localScale;
					bodyTex.transform.localRotation = headTex.transform.localRotation;
					if (base.Card.gameObject.transform.GetChild(0).gameObject.name == "DustParticles")
					{
						bodyTex.transform.localPosition = new Vector3(0f, -0.01f, 0.1575f);
					} else if (base.Card.gameObject.GetComponent<WizardBattle3DPortrait>() == null)
					{
						bodyTex.transform.localPosition = new Vector3(0, 0.085f, -0.001f);
					}
					else
					{
						bodyTex.transform.localPosition = new Vector3(0f, 0.16f, -0.001f);
					}

					bodyTex.GetComponent<SpriteRenderer>().sprite = Tools.getSprite("deathcardbody" + base.Card.Info.mods[0].buildACardPortraitInfo.spriteIndices[1] + ".png");
				}
			}

		}

		public class CustomPortraited : SpecialCardBehaviour
		{
			public void Awake()
			{
				GameObject paintSplotch = Instantiate(new GameObject());
				paintSplotch.AddComponent<SpriteRenderer>().sprite = Tools.getSprite("paint.png");
				paintSplotch.name = "paintSplotch";
				List<Color> random = new List<Color> { new Color(1, 0.5f, 0, 1), new Color(0, 0.5f, 1, 1), new Color(0, 1, 0.1f, 1) };
				List<GemType> gemTypes = new List<GemType> { GemType.Orange, GemType.Blue, GemType.Green };

				paintSplotch.GetComponent<SpriteRenderer>().color = random[gemTypes.IndexOf(base.Card.Info.mods[0].addGemCost[0])];
				paintSplotch.transform.position = new Vector3(0, 0, 0);
				paintSplotch.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
				GameObject splotches = Instantiate(new GameObject());
				splotches.name = "splotches";
				splotches.transform.parent = base.Card.gameObject.transform;
				splotches.transform.localPosition = new Vector3(0, -0.25f, 0f);

				if (base.Card.gameObject.transform.GetChild(0).gameObject.name == "DustParticles")
				{
					splotches.transform.parent = base.Card.gameObject.transform.GetChild(1).GetChild(0);
				}
				else if (base.Card.gameObject.GetComponent<WizardBattle3DPortrait>() == null)
				{
					splotches.transform.parent = base.Card.gameObject.transform.GetChild(0).GetChild(0);
				}
				else
				{
					splotches.transform.localRotation = Quaternion.Euler(270, 0, 0);
					splotches.transform.localPosition = new Vector3(0f, -0.25f, -0.01f);
				}
				Sprite smallSplotch = Tools.getSprite("smallpaint.png");

				for (int i = 0; i < base.Card.Info.mods[0].decalIds.Count; i++)
				{
					string[] splotchData = base.Card.Info.mods[0].decalIds[i].Split(',');
					if (splotchData.Length == 5)
                    {
						string[] newSplotchData = new string[4];
						newSplotchData[0] = splotchData[0];
						newSplotchData[1] = Convert.ToString(float.Parse(splotchData[1]) + (float.Parse(splotchData[2]) / 100f));
						if (splotchData[1][0] == '-') { newSplotchData[1] = Convert.ToString(-float.Parse(newSplotchData[1])); }
						newSplotchData[2] = splotchData[3];
						newSplotchData[3] = splotchData[4];
						int yDecimalIdx = 2;
						if (float.Parse(newSplotchData[1]) > 8)
						{ 
							newSplotchData[0] = Convert.ToString(float.Parse(splotchData[0]) + (float.Parse(splotchData[1]) / 100f));
							newSplotchData[1] = splotchData[2];
							yDecimalIdx = 1;
						}
						if (splotchData[yDecimalIdx].Length < 2)
                        {
							string newDecimal = splotchData[yDecimalIdx] + '0';
							if (yDecimalIdx == 2) { newSplotchData[1] = Convert.ToString(float.Parse(splotchData[1]) + (float.Parse(newDecimal) / 100f)); }
							else { Convert.ToString(float.Parse(splotchData[0]) + (float.Parse(newDecimal) / 100f)); }
						}
						splotchData = newSplotchData;
					} else if (splotchData.Length == 6)
					{
						string[] newSplotchData = new string[4];
						newSplotchData[0] = Convert.ToString(float.Parse(splotchData[0]) + (float.Parse(splotchData[1]) / 100f));
						if (splotchData[0][0] == '-') { newSplotchData[0] = Convert.ToString(-float.Parse(newSplotchData[0])); }
						newSplotchData[1] = Convert.ToString(float.Parse(splotchData[2]) + (float.Parse(splotchData[3]) / 100f));
						if (splotchData[2][0] == '-') { newSplotchData[1] = Convert.ToString(-float.Parse(newSplotchData[1])); }
						newSplotchData[2] = splotchData[4];
						newSplotchData[3] = splotchData[5];
						if (splotchData[3].Length < 2)
						{
							string newDecimal = splotchData[3] + '0';
							newSplotchData[1] = Convert.ToString(float.Parse(splotchData[2]) + (float.Parse(newDecimal) / 100f));
						}
						splotchData = newSplotchData;
					}
					paintSplotch.transform.localScale = new Vector3(Convert.ToInt32(splotchData[2]) * 0.1f, Convert.ToInt32(splotchData[2]) * 0.1f, Convert.ToInt32(splotchData[2]) * 0.1f);
					if (Convert.ToInt32(splotchData[2]) > 2)
					{
						paintSplotch.transform.localScale = new Vector3(2 * 0.1f, 2 * 0.1f, 2 * 0.1f);
					}
					GameObject splotch = Instantiate(paintSplotch);

					splotch.name = "splotch";
					if (Convert.ToInt32(splotchData[2]) < 2)
					{
						splotch.GetComponent<SpriteRenderer>().sprite = smallSplotch;
					}
					switch (splotchData[3])
					{
						case "0":
							splotch.GetComponent<SpriteRenderer>().color = random[gemTypes.IndexOf(base.Card.Info.mods[0].addGemCost[0])];
							break;
						case "1":
							splotch.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1);
							break;
						case "2":
							splotch.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
							break;
					}
					splotch.transform.parent = splotches.transform;
					splotch.transform.localRotation = Quaternion.Euler(90, 0, UnityEngine.Random.RandomRangeInt(0, 180));
					splotch.transform.localPosition = new Vector3(float.Parse(splotchData[0]), 0.01f + (0.01f * Convert.ToInt32(splotchData[3])), (float.Parse(splotchData[1]) - 6.1f));
				}
				splotches.transform.localPosition = new Vector3(0, -0.25f, -0.01f);
			}
		}

		[HarmonyPatch(typeof(GemDependant), "OnResolveOnBoard")]
		public class gemDependantResolveFix
		{
			public static void Prefix(out GemDependant __state, ref GemDependant __instance)
			{
				__state = __instance;
			}
			public static IEnumerator Postfix(IEnumerator enumerator, GemDependant __state)
			{
				yield return __state.PreSuccessfulTriggerSequence();
				if (!__state.Card.slot.IsPlayerSlot && __state.Card.OriginatedFromQueue)
				{
					GameObject.Find("OpponentSlots").transform.GetChild(__state.Card.slot.Index).transform.Find("QueuedCardFrame").gameObject.SetActive(false);
				}
				yield return __state.Card.Die(false, null, true);
				yield return __state.LearnAbility(0.25f);
				yield break;
			}
		}

		[HarmonyPatch(typeof(CardPile), "CursorType", MethodType.Getter)]
		public class FixCursorSprite
		{
			public static bool Prefix(ref CardPile __instance, ref CursorType __result)
			{
				if (SceneLoader.ActiveSceneName != "finale_magnificus") { return true; }
				if (__instance.gameObject.transform.parent == null) { return true; }
				if (__instance.gameObject.transform.parent.gameObject.name != "shopObjects") { return true; }
				if (!__instance.ClickEventAssigned && __instance.gameObject.transform.parent.name != "shopObjects")
				{
					__result = __instance.CursorType;
					return false;
				}
				__result = CursorType.Pickup;
				return false;
			}
		}

		public static IEnumerator fixTheTringleByForce()
		{
			yield return new WaitForSeconds(1f);
			GameObject.Find("PerspectiveUICamera").transform.Find("TextDisplayer").gameObject.GetComponent<TextDisplayer>().baseTrianglePos = new Vector2(0, 5.1f);
			try
			{
				GameObject.Find("PerspectiveUICamera").transform.Find("TextDisplayer_Magnificus").gameObject.GetComponent<TextDisplayer>().baseTrianglePos = new Vector2(0, 4.9f);
				GameObject.Find("PerspectiveUICamera").transform.Find("TextDisplayer_Magnificus").Find("TextCanvas").Find("DialogueTriangle").transform.localPosition = new Vector3(0, 4.9f, 0);
				GameObject.Find("PerspectiveUICamera").transform.Find("TextDisplayer_Magnificus").Find("TextCanvas").Find("DialogueTriangle").gameObject.SetActive(false);
            }
            catch {
				Singleton<TextDisplayer>.Instance.gameObject.GetComponent<TextDisplayer>().baseTrianglePos = new Vector2(0, 5.3f);
			}
			yield break;
		}
		public static void setBaseTextDisplayerOn(bool on)
		{
			if (on)
			{
				Singleton<TextDisplayer>.Instance.gameObject.SetActive(false);
				GameObject.Find("PerspectiveUICamera").transform.Find("TextDisplayer").gameObject.SetActive(true);
				GameObject.Find("PerspectiveUICamera").transform.Find("TextDisplayer").gameObject.GetComponent<TextDisplayer>().baseTrianglePos = new Vector2(0, 5.1f);
			}
			else
			{
				GameObject.Find("TextDisplayer").SetActive(false);
				GameObject.Find("PerspectiveUICamera").transform.Find("TextDisplayer_Magnificus").gameObject.SetActive(true);
				GameObject.Find("PerspectiveUICamera").transform.Find("TextDisplayer_Magnificus").gameObject.GetComponent<TextDisplayer>().baseTrianglePos = new Vector2(0, 4.9f);
			}
			Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(fixTheTringleByForce());
		}

		public static void switchToSpeakerStyle(int styled)//0 - base, 1 - espeara, 2 - stimmy
		{
			TextDisplayer.SpeakerTextStyle style = new TextDisplayer.SpeakerTextStyle();
			switch (styled)
			{
				case 0:
					style = GameObject.Find("TextDisplayer_Magnificus").GetComponent<TextDisplayer>().defaultStyle;
					break;
				case 1:
					style = new TextDisplayer.SpeakerTextStyle();
					style.voiceSoundIdPrefix = "amber";
					style.voiceSoundVolume = 1f;
					style.color = new Color(1, 0.6f, 0.23f);
					style.font = GameObject.Find("AmberFont").GetComponent<UnityEngine.UI.Text>().font;
					style.fontSizeChange = 10;
					style.speaker = DialogueEvent.Speaker.Single;
					style.triangleSprite = Tools.getSprite("dialogue_triangle.png");
					break;
				case 2:
					style = new TextDisplayer.SpeakerTextStyle();
					style.voiceSoundIdPrefix = "stimmy";
					style.voiceSoundVolume = 1f;
					style.color = new Color(0, 0.7f, 1f);
					style.font = GameObject.Find("StimmyFont").GetComponent<UnityEngine.UI.Text>().font;
					style.fontSizeChange = 10;
					style.speaker = DialogueEvent.Speaker.Single;
					style.triangleSprite = Tools.getSprite("dialogue_triangle.png");
					break;
			}
			GameObject.Find("TextDisplayer_Magnificus").GetComponent<TextDisplayer>().alternateSpeakerStyles = new List<TextDisplayer.SpeakerTextStyle>();
			GameObject.Find("TextDisplayer_Magnificus").GetComponent<TextDisplayer>().alternateSpeakerStyles.Add(style);
			GameObject.Find("TextDisplayer_Magnificus").GetComponent<TextDisplayer>().SetTextStyle(style);
		}


		
	}
}
