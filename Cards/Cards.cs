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
using MagMod = MagnificusMod.Plugin;
using SigilCode = MagnificusMod.SigilCode;

namespace MagnificusMod
{
    class Cards
    {
		public static void ChangeSquirrel()
		{

			List<CardMetaCategory> list = new List<CardMetaCategory>();

			List<GemType> gemCost = new List<GemType> { GemType.Orange };
			CardInfo myCard = CardManager.New("mag", "mag_randommox", "Mox", 0, 1, "its a me moxio")
					.SetPortrait(Tools.getImage("blank mox.png"))
					.AddTraits(Trait.Gem)
					.AddAppearances(CardAppearanceBehaviour.Appearance.TerrainBackground)
					.AddAbilities(SigilCode.MoxRandom.ability);
			myCard.temple = CardTemple.Wizard;
			myCard.metaCategories = list;
		}
		/*
		public static void ChangeAquaSquirrel()
		{

			List<Ability> list = new List<Ability>();
			List<Trait> list2 = new List<Trait>();
			list2.Add(Trait.Gem);
			list2.Add(Trait.Terrain);
			list.Add(SigilCode.MoxRandom.ability);
			list.Add(Ability.Submerge);
			byte[] data = File.ReadAllBytes(Path.Combine(base.Info.Location.Replace("SigilCode.dll", ""), "blank mox.png"));
			Texture2D texture2D = new Texture2D(2, 2);
			texture2D.LoadImage(data);
			List<Texture> list3 = new List<Texture>();
			list3.Add(texture2D);
			byte[] data2 = File.ReadAllBytes(Path.Combine(base.Info.Location.Replace("SigilCode.dll", ""), "invisible card.png"));
			Texture2D texture2D2 = new Texture2D(2, 2);
			texture2D2.LoadImage(data2);
			CardInfo customCard = InscryptionAPI.Card.CardManager.BaseGameCards.CardByName("AquaSquirrel");
			customCard.displayedName = "Mox";
			customCard.baseAttack = 0;
			customCard.abilities = list;
			customCard.decals = list3;
			customCard.SetPortrait(texture2D2);
			customCard.traits = list2;
			customCard.SetAltPortrait(texture2D2);
		}
		
		public static void ChangeBee()
		{
			List<Ability> list = new List<Ability>();
			List<Trait> list2 = new List<Trait>();
			list2.Add(Trait.Gem);
			list2.Add(Trait.Terrain);
			list.Add(SigilCode.MoxRandom.ability);
			list.Add(Ability.Sharp);
			byte[] data = File.ReadAllBytes(Path.Combine(base.Info.Location.Replace("SigilCode.dll", ""), "blank mox.png"));
			Texture2D texture2D = new Texture2D(2, 2);
			texture2D.LoadImage(data);
			List<Texture> list3 = new List<Texture>();
			list3.Add(texture2D);
			byte[] data2 = File.ReadAllBytes(Path.Combine(base.Info.Location.Replace("SigilCode.dll", ""), "invisible card.png"));
			Texture2D texture2D2 = new Texture2D(2, 2);
			texture2D2.LoadImage(data2);
			CardInfo customCard = InscryptionAPI.Card.CardManager.BaseGameCards.CardByName("Bee");
			customCard.displayedName = "Mox";
			customCard.baseAttack = 0;
			customCard.abilities = list;
			customCard.decals = list3;
			customCard.SetPortrait(texture2D2);
			customCard.traits = list2;
			customCard.SetAltPortrait(texture2D2);
		}

		*/
		public static void AddRubyMox()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();

			CardInfo myCard = CardManager.BaseGameCards.CardByName("MoxRuby")
					.SetCost(bloodCost: 0)
					.SetPortrait(Tools.getImage("red mox card.png"))
					.SetAffectedByTidalLock(true)
					.AddAppearances(CardAppearanceBehaviour.Appearance.TerrainBackground);
			myCard.traits = new List<Trait> { Trait.Gem };
			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddEmeraldMox()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();

			CardInfo myCard = CardManager.BaseGameCards.CardByName("MoxEmerald")
					.SetCost(bloodCost: 0)
					.SetPortrait(Tools.getImage("green mox card.png"))
                    .SetAffectedByTidalLock(true)
                    .AddAppearances(CardAppearanceBehaviour.Appearance.TerrainBackground);
			myCard.traits = new List<Trait> { Trait.Gem };
			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddSapphireMox()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();

			CardInfo myCard = CardManager.BaseGameCards.CardByName("MoxSapphire")
					.SetCost(bloodCost: 0)
					.SetPortrait(Tools.getImage("blue mox card.png"))
                    .SetAffectedByTidalLock(true)
                    .AddAppearances(CardAppearanceBehaviour.Appearance.TerrainBackground);
			myCard.traits = new List<Trait> { Trait.Gem };
			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddSpearCard()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> ();

			CardInfo myCard = CardManager.New("mag", "mag_spear", "Spear", 0, 3, "ayo")
					.SetCost(bloodCost: 0)
					.SetPortrait(Tools.getImage("mag_spear.png"))
					.AddAbilities(Ability.Sharp);
			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddMagePupil()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			list.Add(CardMetaCategory.ChoiceNode);
			CardInfo myCard = CardManager.BaseGameCards.CardByName("Pupil")
				.SetCost()
				.SetPortrait(Tools.getImage("magepupil.png"))
				.AddMetaCategories(list[0]);
			myCard.description = "Though weak, it can always be useful in the right situation.";
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddJrSage()
		{
			List<CardMetaCategory> metaCategories = new List<CardMetaCategory> { CardMetaCategory.ChoiceNode };

			CardInfo myCard = CardManager.BaseGameCards.CardByName("JuniorSage")
					.SetPortrait(Tools.getImage("juniorsage.png"))
					.SetEvolve("mag_srsage", 1)
					.AddMetaCategories(metaCategories[0]);
			myCard.description = "Although simple, it can prove itself to be useful.";
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddMuscleMage()
		{
			List<CardMetaCategory> metaCategories = new List<CardMetaCategory> {CardMetaCategory.ChoiceNode};
			CardInfo myCard = CardManager.BaseGameCards.CardByName("MuscleMage")
					.SetPortrait(Tools.getImage("musclemage.png"))
					.AddMetaCategories(metaCategories[0]);
			myCard.description = "An abomination of muscles, developed from drinking too many potions of the alchemist..";
			if (!config.classicCardBalance) myCard.abilities = new List<Ability> { Ability.GainAttackOnKill };
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddGreenMage()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { CardMetaCategory.ChoiceNode };

			CardInfo myCard = CardManager.BaseGameCards.CardByName("GreenMage")
					.SetPortrait(Tools.getImage("green mage.png"))
					.AddMetaCategories(list[0]);
			myCard.specialAbilities = new List<SpecialTriggeredAbility> { SigilCode.HealthForAnts.FullSpecial.Id };
			myCard.specialStatIcon = SigilCode.HealthForAnts.FullStatIcon.Id;
			myCard.description = "It draws its power from the mana of the mox on the board.";
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddBlueMage()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			list.Add(CardMetaCategory.ChoiceNode);

			CardInfo myCard = CardManager.BaseGameCards.CardByName("BlueMage")// "Never doubt its utility.")
					.SetPortrait(Tools.getImage("BlueMage.png"))
					.SetBaseAttackAndHealth(0, (config.classicCardBalance) ? 1 : 2)
					.AddMetaCategories(list[0]);
			myCard.description = "Never doubt its utility.";
			myCard.abilities = new List<Ability> { SigilCode.BlueMageDraw.ability };
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddBlueSporeMage()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { };

			CardInfo myCard = CardManager.BaseGameCards.CardByName("BlueMage_Fused")
					.SetPortrait(Tools.getImage("BlueMageFused.png"))
					.AddAppearances(CardAppearanceBehaviour.Appearance.RareCardBackground);
			myCard.abilities = new List<Ability> { SigilCode.BlueMageDraw.ability, SigilCode.BlueMageDraw.ability };
			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;

		}

		public static void AddForceMage()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { CardMetaCategory.ChoiceNode };

			CardInfo myCard = CardManager.BaseGameCards.CardByName("ForceMage")
					.SetPortrait(Tools.getImage("ForceMage.png"))
					.AddMetaCategories(list[0]);
			myCard.temple = CardTemple.Wizard;
			myCard.description = "A mage, proficient in a martial stance which allows it block nearly anything..";
		}

		public static void AddGemFiend()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { CardMetaCategory.ChoiceNode };

			CardInfo myCard = CardManager.BaseGameCards.CardByName("GemFiend")
					.SetPortrait(Tools.getImage("GemFeind.png"))
					.AddMetaCategories(list[0]);
			myCard.description = "A wretched, unstable creature of gems. It can tear through anything.";
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddHoverMage()
		{

			List<CardMetaCategory> list = new List<CardMetaCategory> { CardMetaCategory.ChoiceNode };

			CardInfo myCard = CardManager.BaseGameCards.CardByName("FlyingMage")
					.SetBaseAttackAndHealth(1, (config.classicCardBalance) ? 1 : 2)
					.SetPortrait(Tools.getImage("FlyingMage.png"));
			myCard.description = "Using its spells it soars high to hit directly";
			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddKnightMage()
		{

			List<CardMetaCategory> list = new List<CardMetaCategory> { CardMetaCategory.ChoiceNode };

			CardInfo myCard = CardManager.BaseGameCards.CardByName("MageKnight")
					.SetPortrait(Tools.getImage("KnightMage.png"))
					.SetBaseAttackAndHealth(1, (config.classicCardBalance) ? 3 : 4)
					.AddMetaCategories(list[0]);
			myCard.description = "An intimidating and towering defense, however requiring gems to stay stable.";
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddOrangeMage()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { CardMetaCategory.ChoiceNode };

			CardInfo myCard = CardManager.BaseGameCards.CardByName("OrangeMage")
					.SetPortrait(Tools.getImage("OrangeMage.png"))
					.SetBaseAttackAndHealth(0, (config.classicCardBalance) ? 1 : 2)
					.AddMetaCategories(list[0]);
			myCard.temple = CardTemple.Wizard;
			myCard.description = "Using its spells, it boosts the damage of all gems.";
		}

		public static void AddPracticeMage()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { CardMetaCategory.ChoiceNode };

			CardInfo myCard = CardManager.BaseGameCards.CardByName("PracticeMage")//CardManager.New("mag", "PracticeMage", "Practice Mage", 0, 3, "It stands tall enough to block any target.")
					.SetPortrait(Tools.getImage("PracticeMage.png"))
					.AddMetaCategories(list[0]);
			myCard.temple = CardTemple.Wizard;
			if (!config.classicCardBalance) myCard.abilities = new List<Ability> { Ability.Reach };
			myCard.description = "A lifeless practice target.. standing tall enough to block any attacks.";
		}

		public static void AddRubyGolem()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { CardMetaCategory.ChoiceNode };

			CardInfo myCard = CardManager.BaseGameCards.CardByName("RubyGolem")
					.SetPortrait(Tools.getImage("RubyGolem.png"));
			
			myCard.description = "A construct powered by Mox.As it perishes it leaves behind parts of itself.";
			myCard.abilities = new List<Ability> { SigilCode.MagDropRubyOnDeath.ability };
			myCard.temple = CardTemple.Wizard;
			myCard.metaCategories = list;
		}


		public static void AddMagnusMox()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { };

			CardInfo myCard = CardManager.New("mag", "mag_BOSSmagnusmox", "Magnus Mox", 0, 9, "is the return of bin laden")
					.SetPortrait(Tools.getImage("Mox Triple.png"))
					.AddTraits(Trait.Gem)
					.AddAbilities(Ability.GainGemBlue, Ability.GainGemGreen, Ability.GainGemOrange);
			myCard.temple = CardTemple.Wizard;
			myCard.metaCategories = list;
		}


		public static void ChangeWolf()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { CardMetaCategory.ChoiceNode };
			List<Ability> list2 = new List<Ability>();
			list2.Add(SigilCode.FamiliarA.ability);

			CardInfo myCard = CardManager.New("mag", "mag_wolf", "Wolf Familiar", 2,1, "It rips into its enemies with little to no remorse.")
					.SetPixelPortrait(Tools.getImage("mag_wizwolf_pixel.png"))
					.SetPortrait(Tools.getImage("mag_wizwolf.png"))
					.SetCost(bloodCost: 1)
					.AddAbilities(list2[0]);
			myCard.SetExtendedProperty("ManaCost", true);
			myCard.temple = CardTemple.Wizard;
			myCard.metaCategories = list;
		}

		public static void AddObelisk()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { };

			CardInfo myCard = CardManager.New("mag", "mag_obelisk", "Trading Obelisk", 0, 1, "draft token aka pelt no way jose")
					.SetPortrait(Tools.getImage("obelisk.png"))
					.SetPixelPortrait(Tools.getImage("pixelportrait_obelisk.png"))
					.AddAppearances(CardAppearanceBehaviour.Appearance.TerrainBackground);
			myCard.temple = CardTemple.Wizard;
			myCard.metaCategories = list;
		}

		public static void ChangeRingWorm()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();

			CardInfo myCard = CardManager.New("mag", "mag_crystalworm", "Crystal Worm", 0, 2, "Its body is made out of pure mana.. Gleaming and transforming into other gems.")
					.SetPortrait(Tools.getImage("GemWorm.png"))
					.SetPixelPortrait(Tools.getSprite("pixelportrait_gemworm.png"))
					.SetTraits(Trait.Gem)
					.AddMetaCategories(CardMetaCategory.ChoiceNode)
					.SetCost(bloodCost: 1)
					.AddAppearances(CardAppearanceBehaviour.Appearance.TerrainBackground)
					.AddAbilities(SigilCode.MoxSelect.ability);
			myCard.SetExtendedProperty("ManaCost", true);
			myCard.temple = CardTemple.Wizard;

			CardInfo myCard2 = CardManager.New("mag", "mag_crystalworm_orange", "Crystal Worm", 0, 2, "")
					.SetPortrait(Tools.getImage("GemWorm_orange.png"))
					.SetTraits(Trait.Gem)
					.AddAbilities(Ability.GainGemOrange)
					.AddAppearances(CardAppearanceBehaviour.Appearance.TerrainBackground)
					.SetCost(gemsCost: new List<GemType> { GemType.Orange });
			myCard2.metaCategories = list;
			myCard2.temple = CardTemple.Wizard;

			CardInfo myCard3 = CardManager.New("mag", "mag_crystalworm_green", "Crystal Worm", 0, 2, "")
					.SetPortrait(Tools.getImage("GemWorm_green.png"))
					.SetTraits(Trait.Gem)
					.AddAbilities(Ability.GainGemGreen)
					.AddAppearances(CardAppearanceBehaviour.Appearance.TerrainBackground)
					.SetCost(gemsCost: new List<GemType> { GemType.Green });
			myCard3.metaCategories = list;
			myCard3.temple = CardTemple.Wizard;

			CardInfo myCard4 = CardManager.New("mag", "mag_crystalworm_blue", "Crystal Worm", 0, 2, "")
					.SetPortrait(Tools.getImage("GemWorm_blue.png"))
					.SetTraits(Trait.Gem)
					.AddAbilities(Ability.GainGemBlue)
					.AddAppearances(CardAppearanceBehaviour.Appearance.TerrainBackground)
					.SetCost(gemsCost: new List<GemType> { GemType.Blue });
			myCard4.metaCategories = list;
			myCard4.temple = CardTemple.Wizard;
		}
		public static void AddMoxLarva()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			List<Ability> list2 = new List<Ability>();
			list2.Add(Ability.GemDependant);
			list2.Add(Ability.Evolve);

			string text = "mag_moxlarva";
			string text2 = "Mox Larva";
			int num = 0;
			int num2 = 1;
			List<CardMetaCategory> list3 = list;
			CardComplexity cardComplexity = CardComplexity.Simple;
			CardTemple cardTemple = CardTemple.Nature;
			string text3 = "";
			bool flag = false;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			List<GemType> list4 = null;

			CardInfo myCard = CardManager.New("mag", text, text2, num, num2, text3).SetEvolve("mag_moxbeast", 1)

					.SetCost()
					.SetPortrait(Tools.getImage("GemLarva.png"))
					.SetPixelPortrait(Tools.getSprite("pixelportrait_gemlarva.png"))
					.AddAbilities(list2[0], list2[1])
					.AddMetaCategories();
			myCard.metaCategories = new List<CardMetaCategory>();
		}

		public static void AddMoxBeast()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			List<Ability> list2 = new List<Ability>();
			list2.Add(SigilCode.MagDropRubyOnDeath.ability);

			string text = "mag_moxbeast";
			string text2 = "Mox Beast";
			int num = 2;
			int num2 = 2;
			List<CardMetaCategory> list3 = list;
			CardComplexity cardComplexity = CardComplexity.Simple;
			CardTemple cardTemple = CardTemple.Nature;
			string text3 = "";
			bool flag = false;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			List<GemType> list4 = null;
			SpecialStatIcon specialStatIcon = SpecialStatIcon.None;
			List<Tribe> list5 = null;
			List<Trait> list6 = null;

			CardInfo myCard = CardManager.New("mag", text, text2, num, num2, text3)

					.SetCost()
					.SetPortrait(Tools.getImage("MoxBeast.png"))
					.AddAbilities(list2[0])
					.AddMetaCategories();
			myCard.metaCategories = new List<CardMetaCategory>();
		}

		/*
		public static void ChangeCuckoo()
		{
			List<Tribe> list = new List<Tribe>();
			List<GemType> list2 = new List<GemType>();
			list2.Add(GemType.Orange);
			List<Ability> list5 = new List<Ability>();
			list5.Add(Ability.Submerge);
			Sprite pixelTex = Tools.getSprite("molluscmage_pixel.png");
			CardInfo customCard = CardManager.BaseGameCards.CardByName("Cuckoo");
			customCard.displayedName = "Mollusk Mage";
			customCard.baseHealth = 1;
			customCard.baseAttack = 2;
			customCard.cost = 0;
			customCard.tribes = list;
			customCard.gemsCost = list2;
			customCard.description = "It is an apprentice to Master Cephalo.";
			customCard.abilities = list5;
			customCard.SetPortrait(Tools.getImage("mollusc mage.png"));
			customCard.SetPixelPortrait(pixelTex);
			customCard.metaCategories = new List<CardMetaCategory> { CardMetaCategory.ChoiceNode };
			customCard.temple = CardTemple.Wizard;
		}
		
		public static void ChangeRaccoon()
		{
			List<Tribe> list = new List<Tribe>();
			List<GemType> list2 = new List<GemType>();
			list2.Add(GemType.Green);

			List<Ability> list5 = new List<Ability>();
			list5.Add(Ability.QuadrupleBones);

			Sprite pixelTex = Tools.getSprite("multiplymage_pixel.png");
			CardInfo customCard = CardManager.BaseGameCards.CardByName("Raccoon");
			customCard.displayedName = "Multiply Mage";
			customCard.baseHealth = 3;
			customCard.baseAttack = 0;
			customCard.cost = 0;
			customCard.tribes = list;
			customCard.gemsCost = list2;
			customCard.description = "The clumsy Multiply Mage. It cast a spell to quadruple itself.";
			customCard.abilities = list5;
			customCard.SetPortrait(Tools.getImage("multiplymage.png"));
			customCard.SetPixelPortrait(pixelTex);
			customCard.metaCategories = new List<CardMetaCategory> { CardMetaCategory.ChoiceNode };
			customCard.temple = CardTemple.Wizard;
		}

		public static void ChangeDireWolf()
		{
			List<CardMetaCategory> metacategories = new List<CardMetaCategory> { CardMetaCategory.Rare };
			List<Tribe> list = new List<Tribe>();
			List<GemType> list2 = new List<GemType>();
			list2.Add(GemType.Orange);


			Sprite pixelTex = Tools.getSprite("wiztwo_pixel.png");
			CardInfo customCard = CardManager.BaseGameCards.CardByName("DireWolf");
			customCard.displayedName = "Wiz Sr.";
			customCard.baseHealth = 1;
			customCard.baseAttack = 2;
			customCard.cost = 0;
			customCard.tribes = list;
			customCard.gemsCost = list2;
			customCard.description = "It learned how to control its split vision, and now bears special spectacles to use its [c:g3]''Double Wizion''.[c:]";
			customCard.SetPortrait(Tools.getImage("two wiz.png"));
			customCard.SetPixelPortrait(pixelTex);
			customCard.SetRare();
			customCard.metaCategories = metacategories;
			customCard.temple = CardTemple.Wizard;

		}*/


		public static void ChangeSnowTree()
		{
			CardInfo customCard = CardManager.BaseGameCards.CardByName("Tree_SnowCovered");
			customCard.displayedName = "Arch";
			customCard.SetPortrait(Tools.getImage("arch.png"));
		}

		public static void ChangeTree()
		{
			CardInfo customCard = CardManager.BaseGameCards.CardByName("Tree");
			customCard.displayedName = "Pillar";
			customCard.SetPortrait(Tools.getImage("pillar.png"));
		}

		public static void ChangeStump()
		{
			CardInfo customCard = CardManager.BaseGameCards.CardByName("Stump");
			customCard.displayedName = "Ruined Pillar";
			customCard.SetPortrait(Tools.getImage("broken pillar.png"));
		}

		public static void ChangeBoulder()
		{
			CardInfo customCard = CardManager.BaseGameCards.CardByName("Boulder");
			customCard.displayedName = "Ruined Arch";
			customCard.SetPortrait(Tools.getImage("broken arch.png"));
		}


		public static void ChangeStoat()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();

			List<GemType> gemCost = new List<GemType> { GemType.Green };
			CardInfo myCard = CardManager.New("mag", "mag_stoat", "Techno Mage", 1, 3, "sponsored by me")

					.SetPortrait(Tools.getImage("techno mage.png"))
					.SetCost(bloodCost: 0, gemsCost: gemCost);
			myCard.metaCategories = list;
		}

		public static void ChangeStinkbug()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();

			CardInfo myCard = CardManager.New("mag", "mag_stinkbug", "Necro Mage", 1, 2, "sponsored by me again")
					.AddAbilities(Ability.DebuffEnemy)
					.SetPortrait(Tools.getImage("necro mage.png"))
					.SetCost(bloodCost: 1);
			myCard.SetExtendedProperty("ManaCost", true);
			myCard.metaCategories = list;
		}
		/*
		public static void AddTrapperTrader()
		{
			CardInfo myCard = CardManager.New("mag", "mag_talkingtrapper", "Trapper", 1, 3, "Graaahhh im the trapper")

					.SetPortrait(Tools.getImage("rubymenace.png"))
					.AddSpecialAbilities(SpecialTriggeredAbility.TalkingCardChooser)
					.AddAppearances(CardAppearanceBehaviour.Appearance.AnimatedPortrait)
					.AddAbilities(SigilCode.ImprovedSteelTrap.ability)
					.SetCost(bloodCost:1);
			myCard.SetExtendedProperty("ManaCost", true);
			myCard.metaCategories = new List<CardMetaCategory>();
		}*/

		public static void ChangeOuroboros()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { CardMetaCategory.Rare };
			List<Ability> list2 = new List<Ability> { Ability.DrawCopyOnDeath };

			List<GemType> gemCost = new List<GemType> { GemType.Green };
			CardInfo myCard = CardManager.New("mag", "mag_ouro", "Ouroberyl", 1, 1, "It gleams and takes different forms.. How majestic..")
					.AddAppearances(CardAppearanceBehaviour.Appearance.RareCardBackground)
					.SetPortrait(Tools.getImage("mag_oroborous.png"))
					.SetCost(bloodCost: 0, gemsCost: gemCost)
					.AddSpecialAbilities(SpecialTriggeredAbility.Ouroboros, MagMod.OuroChange)
					.AddAbilities(list2[0]);
			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}

		/*public static void ChangeGeck()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			List<GemType> list2 = new List<GemType>();
			list2.Add(GemType.Blue);
			List<Tribe> tribes = new List<Tribe>();

			Sprite pixelTex = Tools.getSprite("wizgeck_pixel.png");
			CardInfo customCard = CardManager.BaseGameCards.CardByName("Geck");
			customCard.displayedName = "Wiz-Geck";
			customCard.description = "What? How did [c:g2]his[c:] cards get in here?";
			customCard.SetPixelPortrait(pixelTex);
			customCard.SetPortrait(Tools.getImage("wizgeck.png"));
		}*/


		public static void ChangePackrat()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { CardMetaCategory.Rare };
			List<Ability> list2 = new List<Ability> { SigilCode.DrawSpell.ability };

			List<GemType> gemCost = new List<GemType> { GemType.Blue };
			CardInfo myCard = CardManager.New("mag", "mag_spellcaster", "Spellcaster", 1, 2, "It reads out spells from its book and casts them directly to your hand.")
					.AddAppearances(CardAppearanceBehaviour.Appearance.RareCardBackground)
					.SetPixelPortrait(Tools.getSprite("pixelportrait_spellcaster.png"))
					.SetPortrait(Tools.getImage("pack mage.png"))
					.SetCost(bloodCost: 0, gemsCost: gemCost)
					.AddAbilities(list2[0]);
			myCard.temple = CardTemple.Wizard;
			myCard.metaCategories = list;

		}

		public static void AddChaosMage()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { CardMetaCategory.Rare };
			List<Ability> list2 = new List<Ability> { SigilCode.WhirlwindSpell.ability };

			List<GemType> gemCost = new List<GemType> { GemType.Green };
			CardInfo myCard = CardManager.New("mag", "mag_chaosmage", "Chaos Magician", 1, 2, "A scholar proficient in Chaos Theory, channeling a scramble unto the entire board.")
					.AddAppearances(CardAppearanceBehaviour.Appearance.RareCardBackground)
					.SetPortrait(Tools.getImage("ChaosMage.png"))
					.SetCost(bloodCost: 0, gemsCost: gemCost)
					.AddAbilities(list2[0]);
			myCard.temple = CardTemple.Wizard;
			myCard.metaCategories = list;

		}

		public static void tailreplacement()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();

			CardInfo myCard = CardManager.New("mag", "mag_magicspell", "Magic Spell", 0, 2, "")

					.SetCost()
					.SetPortrait(Tools.getImage("magic spell.png"))
					.AddMetaCategories();
			myCard.metaCategories = new List<CardMetaCategory>();
		}



		public static void AddGemDetonator()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			list.Add(CardMetaCategory.ChoiceNode);
			List<Ability> list2 = new List<Ability>();
			list2.Add(Ability.ExplodeGems);
			CardInfo myCard = CardManager.New("mag", "mag_gemdetonator", "Gem Detonator", 1, 2, "It went berserk after hearing mysterious whispers in a crypt.")

					.SetCost(bloodCost: 1)
					.SetPortrait(Tools.getImage("mag_gemexploder.png"))
					.AddAbilities(list2[0]);
			myCard.SetExtendedProperty("ManaCost", true);
			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}

		public static void Addhim()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			List<Ability> list2 = new List<Ability>();
			list2.Add(Ability.PreventAttack);
			CardInfo myCard = CardManager.New("mag", "mag_he", "he", 2, 2, "its he.")

					.SetCost(bloodCost: 1)
					.SetPortrait(Tools.getImage("him.png"))
					.AddAbilities(list2[0]);
			myCard.metaCategories = list;
		}

		public static void AddHomunculus()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { CardMetaCategory.ChoiceNode };
			List<Ability> list2 = new List<Ability>();
			list2.Add(SigilCode.FamiliarA.ability);
			CardInfo myCard = CardManager.New("mag", "mag_homunculus", "Homunculus", 1, 1, "A strange, to say the least creature.")

					.SetPortrait(Tools.getImage("homunculus.png"))
					.SetPixelPortrait(Tools.getSprite("pixelportrait_homonculus.png"))
					.AddAbilities(list2[0]);
			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddMismagius()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { CardMetaCategory.ChoiceNode };
			List<Ability> list2 = new List<Ability>();
			list2.Add(SigilCode.Ditto.ability);
			CardInfo myCard = CardManager.New("mag", "mag_mismagius", "Mimagius", 0, 0, "It distorts itself into the form of the opposing card.")

					.SetPortrait(Tools.getImage("mismagius.png"))
					.SetCost(bloodCost: 1)
					.AddAbilities(list2[0]);
			myCard.SetExtendedProperty("ManaCost", true);
			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddDeflector()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { CardMetaCategory.ChoiceNode };
			List<Ability> list2 = new List<Ability>();
			list2.Add(Ability.Sharp);
			list2.Add(Ability.Deathtouch);
			List<GemType> gemCost = new List<GemType> { GemType.Blue };
			CardInfo myCard = CardManager.New("mag", "mag_deflector", "Deflector", 0, 2, "You would not want to end up on the wrong side of it..")

					.SetPortrait(Tools.getImage("deflector.png"))
					.SetCost(bloodCost: 0, gemsCost: gemCost)
					.AddAbilities(list2[0], list2[1]);
			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddAuspex()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { CardMetaCategory.ChoiceNode };
			List<Ability> list2 = new List<Ability>();
			list2.Add(Ability.Tutor);
			List<GemType> gemCost = new List<GemType> { GemType.Blue };
			CardInfo myCard = CardManager.New("mag", "mag_auspex", "Auspex", 0, 1, "It harnesses the power of the stars for you..")

					.SetPortrait(Tools.getImage("auspex.png"))
					.SetCost(bloodCost: 0, gemsCost: gemCost)
					.AddAbilities(list2[0]);
			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddAstralProjector()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { CardMetaCategory.ChoiceNode };

			CardInfo myCard = CardManager.New("mag", "mag_astralprojector", "Astral Sorcerer", 0, 2, "A sorcerer proficient in summoning astral projections to protect itself when in danger.")
					.SetCost(bloodCost: 0, gemsCost: new List<GemType> { GemType.Blue })
					.SetPortrait(Tools.getImage("astralsorcerer_projecting.png"))
					.SetTail("mag_astralsorcererprojection", Tools.getImage("astralsorcerer.png"))
					.SetLostTailPortrait(Tools.getImage("astralsorcerer.png"))
					.AddAbilities(SigilCode.AstralProjection.ability);
			myCard.temple = CardTemple.Wizard;
			myCard.metaCategories = list;
		}

		public static void AddAstralSorcererProjection()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> ();

			CardInfo myCard = CardManager.New("mag", "mag_astralsorcererprojection", "Astral Projection", 1,2, "real")
					.SetCost(bloodCost: 0, gemsCost: new List<GemType> { GemType.Blue })
					.SetPortrait(Tools.getImage("astralprojection.png"));
			myCard.temple = CardTemple.Wizard;
			myCard.metaCategories = list;
		}

		public static void AddDefaultAstralProjection()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> ();

			CardInfo myCard = CardManager.New("mag", "mag_defaultastralprojection", "Astral Projection", 0, 2, "real")
					.SetCost(bloodCost: 0, gemsCost: new List<GemType> { GemType.Blue })
					.SetPortrait(Tools.getImage("defaultastralprojection.png"));
			myCard.temple = CardTemple.Wizard;
			myCard.metaCategories = list;
		}

		public static void AddRascal()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { CardMetaCategory.ChoiceNode };
			List<Ability> list2 = new List<Ability>();
			list2.Add(Ability.TailOnHit);
			list2.Add(Ability.DrawRandomCardOnDeath);
			List<GemType> gemCost = new List<GemType> { GemType.Blue };
			CardInfo myCard = CardManager.New("mag", "mag_rascal", "Trinket Bearer", 0, 1, "A mischevious little goblin creature. It carries around valueables in its backpack.")

					.SetPortrait(Tools.getImage("rascal.png"))
					.SetPixelPortrait(Tools.getImage("pixelportrait_rascal.png"))
					.SetTail("mag_rascalpack", Tools.getImage("rascal1.png"))
					.SetLostTailPortrait(Tools.getImage("rascal1.png"))
					.SetCost(bloodCost: 0, gemsCost: gemCost)
					.AddAbilities(list2[0], list2[1]);
			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddRascalPack()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			List<Ability> list2 = new List<Ability>();
			list2.Add(Ability.DrawRandomCardOnDeath);
			List<GemType> gemCost = new List<GemType> { GemType.Blue };
			CardInfo myCard = CardManager.New("mag", "mag_rascalpack", "Backpack", 0, 1, "fhqwghads")

					.SetPortrait(Tools.getImage("rascalpack.png"))
					.SetCost(bloodCost: 0)
					.AddAbilities(list2[0]);
			myCard.metaCategories = list;
		}

		public static void AddStimMachine()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { CardMetaCategory.Rare };
			List<Ability> list2 = new List<Ability>();
			list2.Add(SigilCode.StimulationHP.ability);
			List<GemType> gemCost = new List<GemType> { GemType.Orange };
			CardInfo myCard = CardManager.New("mag", "mag_stimmachine", "Stimbot", 1, 2, "Powered by stimulation, and steam..")

					.SetPortrait(Tools.getImage("stim machine.png"))
					.SetCost(bloodCost: 0, gemsCost: gemCost)
					.AddAppearances(CardAppearanceBehaviour.Appearance.RareCardBackground)
					.AddAbilities(list2[0], Ability.GemDependant);
			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddMagimorph()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { CardMetaCategory.ChoiceNode };
			List<Ability> list2 = new List<Ability>();
			list2.Add(Ability.RandomAbility);
			List<GemType> gemCost = new List<GemType> { GemType.Blue };
			CardInfo myCard = CardManager.New("mag", "mag_magimorph", "Magimorph", 1, 1, "Its disgusting gooey body warps and distorts into distant forms. It's wonderous if you look at it right.")
					.SetPixelPortrait(Tools.getImage("pixelportrait_magimorph.png"))
					.SetPortrait(Tools.getImage("magimorph.png"))
					.SetCost(bloodCost: 0, gemsCost: gemCost)
					.AddAbilities(list2[0]);
			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}


		
		public static void AddPerformer()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { CardMetaCategory.ChoiceNode };
			List<Ability> list2 = new List<Ability>();
			list2.Add(Ability.DrawRabbits);
			List<GemType> gemCost = new List<GemType> { GemType.Blue };
			CardInfo myCard = CardManager.New("mag", "mag_bunnymage", "Performer", 1, 1, "Watch it create a rabbit out of its wand..")

					.SetPortrait(Tools.getImage("bnuymage.png"))
					.SetPixelPortrait(Tools.getImage("pixelportrait_bunnymage.png"))
					.SetCost(bloodCost: 0, gemsCost: gemCost)
					.AddAbilities(list2[0]);
			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddSeniorSage()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { CardMetaCategory.Rare };
			List<Ability> list2 = new List<Ability>();
			list2.Add(Ability.DoubleStrike);
			List<GemType> gemCost = new List<GemType> { GemType.Green, GemType.Green };
			CardInfo myCard = CardManager.New("mag", "mag_srsage", "Senior Sage", 2, 1, "A Junior Sage that has mastered the art of Magicks.")
					.AddAppearances(CardAppearanceBehaviour.Appearance.RareCardBackground)
					.SetPortrait(Tools.getImage("two wiz.png"))
					.SetCost(bloodCost: 0, gemsCost: gemCost)
					.AddAbilities(list2[0]);
			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddSapphireMech()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { CardMetaCategory.ChoiceNode };

			CardInfo myCard = CardManager.New("mag", "mag_sapphiremech", "Sapphire Mech", 0, 2, "A mage-like automaton piloted by a sapphire mox.. Admirable.")

					.SetPortrait(Tools.getImage("SapphireMech.png"))
					.AddTraits(Trait.Terrain)
					.AddAppearances(CardAppearanceBehaviour.Appearance.TerrainBackground)
					.AddAbilities(Ability.Sharp, SigilCode.MagDropSapphireOnDeath.ability)
					.SetCost(bloodCost: 1);
			myCard.SetExtendedProperty("ManaCost", true);
			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddRubyMenace()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { CardMetaCategory.ChoiceNode };
			List<GemType> gemCost = new List<GemType> { GemType.Orange, GemType.Orange };

			CardInfo myCard = CardManager.New("mag", "mag_rubymenace", "Ruby Titan", 2, 4, "A perfected construct of a ruby golem, a monstrous machine of destruction.")

					.SetPortrait(Tools.getImage("rubytitan.png"))
					.SetCost(bloodCost: 0, gemsCost: gemCost);
			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}
		public static void AddBleenesMonster()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { CardMetaCategory.ChoiceNode };
			List<GemType> gemCost = new List<GemType> { GemType.Blue, GemType.Green };

			CardInfo myCard = CardManager.New("mag", "mag_bleenesmonster", "Bleene's Scholar", 1, 5, "A scholar in training, currently studying the works of Master Bleene.")

					.SetPortrait(Tools.getImage("BleeneScholar.png"))
					.AddAbilities(SigilCode.DrawBook.ability)
					.SetCost(bloodCost: 0, gemsCost: gemCost);
			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddOrcUnderling()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { CardMetaCategory.ChoiceNode };
			List<GemType> gemCost = new List<GemType> { GemType.Orange, GemType.Green };

			CardInfo myCard = CardManager.New("mag", "mag_orcunderling", "Goranj's Warrior", 1, 3, "A foe mentored by Master Goranj, proficient at dual striking.")
					.AddAbilities(Ability.SplitStrike)
					.SetPortrait(Tools.getImage("orcunderling.png"))
					.SetCost(bloodCost: 0, gemsCost: gemCost);
			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}

    
    public static void AddGrazer()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { CardMetaCategory.ChoiceNode };
			List<Ability> list2 = new List<Ability>();
			list2.Add(SigilCode.FrostyA.ability);
			List<GemType> gemCost = new List<GemType> { GemType.Blue, GemType.Blue };
			CardInfo myCard = CardManager.New("mag", "mag_gazer", "The Gazer", 1, 2, "A quiet mage with a cold, piercing gaze.")

					.SetPortrait(Tools.getImage("gazer.png"))
					.SetCost(bloodCost: 0, gemsCost: gemCost)
					.AddAbilities(list2[0]);
			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddCoffeMage()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { CardMetaCategory.ChoiceNode };
			List<Ability> list2 = new List<Ability>();
			list2.Add(SigilCode.NullifySigils.ability);
			List<GemType> gemCost = new List<GemType> { GemType.Orange, GemType.Orange };
			CardInfo myCard = CardManager.New("mag", "mag_coffeemage", "Cider Mage", 1, 2, "This mage has a secret formula of cider that nullifies the opponents spells..")

					.SetPortrait(Tools.getImage("coffeemage.png"))
					.SetCost(bloodCost: 0, gemsCost: gemCost)
					.AddAbilities(list2[0]);
			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddTeaMage()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { CardMetaCategory.ChoiceNode };
			List<Ability> list2 = new List<Ability>();
			list2.Add(SigilCode.DrawMoxFromSideDeck.ability);
			List<GemType> gemCost = new List<GemType> { GemType.Blue, GemType.Blue };
			CardInfo myCard = CardManager.New("mag", "mag_teamage", "Brewer Sage", 0, 4, "A sage, sitting still and perfecting his art of brewing..")

					.SetPortrait(Tools.getImage("teamage.png"))
					.SetCost(bloodCost: 0, gemsCost: gemCost)
					.AddAbilities(list2[0]);
			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddSodaMage()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { CardMetaCategory.ChoiceNode };
			List<Ability> list2 = new List<Ability> { SigilCode.GoobertDebuff.ability, SigilCode.GoobertDebuff.ability };
			List<GemType> gemCost = new List<GemType> { GemType.Green, GemType.Green };
			CardInfo myCard = CardManager.New("mag", "mag_sodamage", "Soda Mage", 1, 3, "This pathetic mage melted away from drinking too much carbonated liquid..")

					.SetPortrait(Tools.getImage("sodermage.png"))
					.SetCost(bloodCost: 0, gemsCost: gemCost)
					.AddAbilities(list2[0], list2[1]);
			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddWhiteSmith()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { CardMetaCategory.ChoiceNode };
			List<Ability> list2 = new List<Ability>();
			list2.Add(SigilCode.PlatingWork.ability);
			List<GemType> gemCost = new List<GemType> { GemType.Orange, GemType.Orange };
			CardInfo myCard = CardManager.New("mag", "mag_whitesmith", "Whitesmith", 0, 4, "Their life's work was dedicated to reinforcing gems.")

					.SetPortrait(Tools.getImage("whitesmith.png"))
					.SetCost(bloodCost: 0, gemsCost: gemCost)
					.AddAbilities(list2[0]);
			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddPuppeteer()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { CardMetaCategory.ChoiceNode };
			List<Ability> list2 = new List<Ability>();
			list2.Add(SigilCode.Animator.ability);
			List<GemType> gemCost = new List<GemType> { GemType.Blue, GemType.Blue };
			CardInfo myCard = CardManager.New("mag", "mag_puppeteer", "Puppeteer", 1, 3, "Its mastery of control magicks lets even Practice Wizards contribute.")

					.SetPortrait(Tools.getImage("puppeteer.png"))
					.SetCost(bloodCost: 0, gemsCost: gemCost)
					.AddAbilities(list2[0]);
			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}


		public static void AddJester()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { CardMetaCategory.ChoiceNode };
			List<Ability> list2 = new List<Ability>();
			list2.Add(SigilCode.MoxCycling.ability);
			CardInfo myCard = CardManager.New("mag", "mag_jester", "Juggler", 0, 3, "It juggles around your mox cards, as if they were juggling balls..")

					.SetPortrait(Tools.getImage("jester.png"))
					.SetPixelPortrait(Tools.getImage("pixelportrait_jester.png"))
					.SetCost(bloodCost: 1)
					.AddAbilities(list2[0]);
			myCard.SetExtendedProperty("ManaCost", true);
			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddJoker()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { CardMetaCategory.ChoiceNode };

			CardInfo myCard = CardManager.New("mag", "mag_joker", "Joker", 0, 3, "Dedicated to the art of fun.. though most only find it annoying.")

					.SetPortrait(Tools.getImage("joker.png"))
					.SetCost(bloodCost: 0, gemsCost: new List<GemType> { GemType.Orange })
					.AddAbilities(Ability.DrawRandomCardOnDeath, Ability.BuffEnemy);
			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddValkyrie()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { CardMetaCategory.ChoiceNode };
			List<GemType> gemCost = new List<GemType> { GemType.Orange, GemType.Blue };
			CardInfo myCard = CardManager.New("mag", "mag_valkyrie", "Valkyrie", 2, 1, "A student that has trained under Master Orlu. It has become an expert in airborne magicks.")

					.SetPortrait(Tools.getImage("valkyrie.png"))
					.SetCost(bloodCost: 0, gemsCost: gemCost)
					.AddAbilities(Ability.Flying);
			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}
		public static void AddBossValkyrie()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			List<GemType> gemCost = new List<GemType> { GemType.Blue };
			CardInfo myCard = CardManager.New("mag", "mag_BOSSvalkyrie", "Valkyrie Thief", 1, 2, "liar liar chicken friar.")

					.SetPortrait(Tools.getImage("valkyriethief.png"))
					.SetCost(bloodCost: 0, gemsCost: gemCost)
					.AddAbilities(Ability.Flying);
			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddEmeraldFiend()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { CardMetaCategory.ChoiceNode };
			List<GemType> gemCost = new List<GemType> { GemType.Green };
			CardInfo myCard = CardManager.New("mag", "mag_emeraldfiend", "Emerald Maniac", 2, 0, "A crazed maniac.. Drawing out health from the mox..")
					.SetPixelPortrait(Tools.getImage("emeraldfiend_pixel.png"))
					.SetPortrait(Tools.getImage("emeraldfiend.png"))
					.SetSpecialAbilities(SigilCode.MoxHp.FullSpecial.Id)
					.SetCost(bloodCost: 0, gemsCost: gemCost);
			myCard.metaCategories = list;
			myCard.specialStatIcon = SigilCode.MoxHp.FullStatIcon.Id;
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddRubyDaemon()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { CardMetaCategory.ChoiceNode };
			List<GemType> gemCost = new List<GemType> { GemType.Orange };
			CardInfo myCard = CardManager.New("mag", "mag_rubyfiend", "Ruby Daemon", 2, 1, "If not properly sustained, it will destroy your hand to fuel itself..")
					.SetPixelPortrait(Tools.getImage("rubyfiend_pixel.png"))
					.SetPortrait(Tools.getImage("rubyfiend.png"))
					.AddAbilities(SigilCode.DiscardCards.ability)
					.SetCost(bloodCost: 0, gemsCost: gemCost);
			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddGemFriend()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			CardInfo myCard = CardManager.New("mag", "mag_gemfriend", "Gem Friend", 1, 3, "fren")

					.SetPortrait(Tools.getImage("GemFriend.png"))
					.AddAbilities(SigilCode.FamiliarA.ability)
					.SetCost(bloodCost: 0, gemsCost: new List<GemType> { GemType.Blue });
			myCard.metaCategories = list;
		}

		public static void AddDruid()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			List<GemType> gemCost = new List<GemType> { GemType.Orange };
			CardInfo myCard = CardManager.New("mag", "mag_druid", "Druid", 2, 2, "Just look at what you've done..")

					.SetCost(gemsCost: gemCost)
					.SetPortrait(Tools.getImage("druid.png"));
			myCard.metaCategories = list;
		}

		public static void AddEdaxioLegs()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			List<Ability> list2 = new List<Ability>();
			list2.Add(Ability.EdaxioLegs);
			List<GemType> gemCost = new List<GemType> { GemType.Green };
			CardInfo myCard = CardManager.New("mag", "mag_edaxiolegs", "Chained Legs", 2, 1, "")

					.SetPortrait(Tools.getImage("edaxio_legs.png"))
					.SetCost(bloodCost: 0, gemsCost: gemCost)
					.AddAbilities(list2[0]);
			myCard.metaCategories = list;
		}

		public static void AddEdaxioTorso()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			List<Ability> list2 = new List<Ability>();
			list2.Add(Ability.EdaxioTorso);
			List<GemType> gemCost = new List<GemType> { GemType.Orange };
			CardInfo myCard = CardManager.New("mag", "mag_edaxiotorso", "Sealed Body", 0, 5, "")

					.SetPortrait(Tools.getImage("edaxio_body.png"))
					.SetCost(bloodCost: 0, gemsCost: gemCost)
					.AddAbilities(list2[0]);
			myCard.metaCategories = list;
		}

		public static void AddEdaxioArms()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			List<Ability> list2 = new List<Ability>();
			list2.Add(Ability.EdaxioArms);
			List<GemType> gemCost = new List<GemType> { GemType.Blue };
			CardInfo myCard = CardManager.New("mag", "mag_edaxioarms", "Bound Arms", 1, 4, "")

					.SetPortrait(Tools.getImage("edaxio_arms.png"))
					.SetCost(bloodCost: 0, gemsCost: gemCost)
					.AddAbilities(list2[0]);
			myCard.metaCategories = list;
		}

		public static void AddEdaxioHead()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			List<Ability> list2 = new List<Ability>();
			list2.Add(Ability.EdaxioHead);
			CardInfo myCard = CardManager.New("mag", "mag_edaxiohead", "Imprisoned Tyrant", 2, 2, "")

					.SetPortrait(Tools.getImage("edaxio_head.png"))
					.SetCost(bloodCost: 1)
					.AddAbilities(list2[0]);
			myCard.SetExtendedProperty("ManaCost", true);
			myCard.metaCategories = list;
		}

		public static void AddMultiplyMage()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { CardMetaCategory.ChoiceNode };
			List<Ability> list2 = new List<Ability>();
			list2.Add(SigilCode.FecundityCycle.ability);
			CardInfo myCard = CardManager.New("mag", "mag_multiplymage", "Multiplication mage", 1, 1, "This cycle can go on forever..")

					.SetCost(bloodCost: 0, gemsCost: new List<GemType> { GemType.Blue })
					.SetPortrait(Tools.getImage("multiplymage.png"))
					.SetPixelPortrait(Tools.getImage("multiplymage_pixel.png"))
					.AddSpecialAbilities(MagMod.OuroChange)
					.AddAbilities(list2[0]);
			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddInvisibleMage()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { CardMetaCategory.ChoiceNode };

			CardInfo myCard = CardManager.New("mag", "mag_invisimage", "Invisible mage", 1, 1, "It drank the wrong potion and ended up invisible. How clumsy.")

					.SetCost(bloodCost: 1)
					.SetPortrait(Tools.getImage("invisible mage.png"))
					.AddAppearances(CardAppearanceBehaviour.Appearance.SexyGoat)
					.AddAbilities(Ability.Flying, Ability.Submerge);
			myCard.metaCategories = list;
			myCard.SetExtendedProperty("ManaCost", true);
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddCrystalSage()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { CardMetaCategory.ChoiceNode };

			CardInfo myCard = CardManager.New("mag", "mag_crystalsage", "Crystal Sage", 1, 2, "A young scholar, profoundly studying mana crystals.")

					.SetCost(bloodCost: 1)
					.SetPixelPortrait(Tools.getImage("pixelportrait_crystalsage.png"))
					.SetPortrait(Tools.getImage("CrystalSage.png"));
			myCard.metaCategories = list;
			myCard.SetExtendedProperty("ManaCost", true);
			myCard.temple = CardTemple.Wizard;
		}

		/*
		public static void AddMultiplyMage()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			list.Add(CardMetaCategory.ChoiceNode);
			
			List<GemType> list2 = new List<GemType>();
			list2.Add(GemType.Green);
			List<Ability> list3 = new List<Ability>();
			list3.Add(SigilCode.Multiplication.ability);
			List<Texture> list4 = new List<Texture>();
			byte[] data = File.ReadAllBytes(Path.Combine(base.Info.Location.Replace("SigilCode.dll", ""), "green mox.png"));
			Texture2D texture2D = new Texture2D(2, 2);
			texture2D.LoadImage(data);
			list4.Add(texture2D);
			byte[] data2 = File.ReadAllBytes(Path.Combine(base.Info.Location.Replace("SigilCode.dll", ""), "invisible mage.png"));
			Texture2D texture2D2 = new Texture2D(2, 2);
			texture2D2.LoadImage(data2);
			string text = "mag_multiplymage";
			string text2 = "Multiplying Mage";
			int num = 0;
			int num2 = 1;
			List<CardMetaCategory> list5 = list;
			CardComplexity cardComplexity = CardComplexity.Simple;
			CardTemple cardTemple = CardTemple.Nature;
			string text3 = "When placed, it casts a spell that creates a clone. The clone casts a spell that creates a clone. The clone casts a spell...";
			bool flag = false;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			List<GemType> list6 = list2;
			SpecialStatIcon specialStatIcon = SpecialStatIcon.None;
			List<Tribe> list7 = null;
			List<Trait> list8 = null;
			List<SpecialTriggeredAbility> list9 = null;
			Texture2D texture2D3 = texture2D2;
			List<Texture> list10 = list4;
			//NewCard.Add(text, text2, num, num2, list5, cardComplexity, cardTemple, text3, flag, num3, num4, num5, list6, specialStatIcon, list7, list8, list9, list3, null, null, null, null, null, null, false, false, null, texture2D3, null, null, null, null, null, list10, null, null, null);
		}

		*/
		public static void AddGemShielder()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { CardMetaCategory.ChoiceNode };
			List<Ability> list2 = new List<Ability>();
			list2.Add(SigilCode.GemGuardianFix.ability);
			CardInfo myCard = CardManager.New("mag", "mag_gemshield", "Gem Guardian", 0, 3, "The inverse of the Gem Detonator, this one seeks to protect all mox.")

						.SetCost(bloodCost: 1)
						.SetPortrait(Tools.getImage("mag_gemshielder.png"))
						.AddAbilities(list2[0]);
			myCard.SetExtendedProperty("ManaCost", true);
			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddGemboundRipper()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { CardMetaCategory.ChoiceNode };
			CardInfo myCard = CardManager.New("mag", "mag_gemboundripper", "Gembound Ripper", 3, 2, "It is unstable, but such is the price for unending power.")

						.SetCost(bloodCost: 2)
						.SetPixelPortrait(Tools.getSprite("pixelportrait_gemboundripper.png"))
						.SetPortrait(Tools.getImage("gemboundripper.png"))
						.AddAbilities(Ability.GemDependant);
			myCard.SetExtendedProperty("ManaCost", true);
			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}


		public static void AddGemAbsorber()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			list.Add(CardMetaCategory.ChoiceNode);

			List<Ability> list2 = new List<Ability>();
			list2.Add(SigilCode.GemAbsorber.ability);
			CardInfo myCard = CardManager.New("mag", "mag_gemabsorber", "Gem Absorber", 0, 1, "It seeks out to consume all mana within Mox to grow stronger.")

						.SetCost(bloodCost: 1)
						.SetPortrait(Tools.getImage("mag_gemabsorber.png"))
						.SetPixelPortrait(Tools.getSprite("pixelportrait_gemabsorber.png"))
						.AddAbilities(list2[0]);
			myCard.SetExtendedProperty("ManaCost", true);
			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}


		public static void AddSkeleMagus()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			list.Add(CardMetaCategory.ChoiceNode);

			List<Ability> list2 = new List<Ability>();
			list2.Add(Ability.Brittle);
			list2.Add(Ability.GemDependant);

			Sprite pixelTex = Tools.getSprite("pixelportrait_skeletonmage.png");
			CardInfo myCard = CardManager.New("mag", "mag_skelemage", "Skelemagus", 3, 1, "Great power for a few, fleeting moments..")

							.SetCost(bloodCost: 1)
							.SetPortrait(Tools.getImage("mag_skelemagus.png"))
							.SetPixelPortrait(Tools.convertToSprite(Resources.Load("art/gbc/cards/pixelportraits/pixelportrait_skeletonmage") as Texture2D))
							.AddAbilities(list2[0], list2[1])
							.SetPixelPortrait(pixelTex)
							.AddMetaCategories(list[0]);
			myCard.SetExtendedProperty("ManaCost", true);
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddSkeleSage()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			list.Add(CardMetaCategory.ChoiceNode);

			List<Ability> list2 = new List<Ability>();
			list2.Add(SigilCode.MagDropEmeraldOnDeath.ability);
			CardInfo myCard = CardManager.New("mag", "mag_skelejrsage", "Skelesage", 1, 3, "One of my own Junior Sages, lost and revived.")

							.SetCost(bloodCost: 2)
							.SetPortrait(Tools.getImage("mag_skelejrsage.png"))
							.AddAbilities(list2[0])
							.AddMetaCategories(list[0]);
			myCard.SetExtendedProperty("ManaCost", true);
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddErraticScholar()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			list.Add(CardMetaCategory.ChoiceNode);

			List<Ability> list2 = new List<Ability>();
			list2.Add(SigilCode.MoxStrafe.ability);
			CardInfo myCard = CardManager.New("mag", "mag_erraticscholar", "Erratic Scholar", 1, 1, "A panicked scholar.. Always running from its problems..")

							.SetCost(bloodCost: 1)
							.SetPixelPortrait(Tools.getSprite("pixelportrait_erraticscholar.png"))
							.SetPortrait(Tools.getImage("erraticscholar.png"))
							.AddAbilities(list2[0])
							.AddMetaCategories(list[0]);
			myCard.SetExtendedProperty("ManaCost", true);
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddMoxMage()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();

			CardInfo myCard = CardManager.New("mag", "mag_moxmage", "Mox Mage", 1, 3, "A Mox disguised as a mage.. It's not going to fool anyone.")

							.SetBloodCost(bloodCost: 1)
							.AddTraits(Trait.Gem)
							.SetPortrait(Tools.getImage("moxmage.png"))
							.AddAppearances(CardAppearanceBehaviour.Appearance.RareCardBackground)
							.AddAbilities(Ability.GainGemOrange, SigilCode.MoxCycling.ability)
							.AddMetaCategories(CardMetaCategory.Rare);
			myCard.SetExtendedProperty("ManaCost", true);
			myCard.temple = CardTemple.Wizard;

			CardInfo myCard2 = CardManager.New("mag", "mag_moxmage_emerald", "Mox Mage", 1, 3, "A Mox disguised as a mage.. It's not going to fool anyone.")

							.SetBloodCost(bloodCost: 1)
							.AddTraits(Trait.Gem)
							.SetPortrait(Tools.getImage("moxmage_emerald.png"))
							.AddAppearances(CardAppearanceBehaviour.Appearance.RareCardBackground)
							.AddAbilities(Ability.GainGemGreen, SigilCode.MoxCycling.ability);
			myCard2.metaCategories = list;
			myCard2.SetExtendedProperty("ManaCost", true);
			myCard2.temple = CardTemple.Wizard;

			CardInfo myCard3 = CardManager.New("mag", "mag_moxmage_sapphire", "Mox Mage", 1, 3, "A Mox disguised as a mage.. It's not going to fool anyone.")

							.SetBloodCost(bloodCost: 1)
							.AddTraits(Trait.Gem)
							.SetPortrait(Tools.getImage("moxmage_sapphire.png"))
							.AddAppearances(CardAppearanceBehaviour.Appearance.RareCardBackground)
							.AddAbilities(Ability.GainGemBlue, SigilCode.MoxCycling.ability);
			myCard3.metaCategories = list;
			myCard3.SetExtendedProperty("ManaCost", true);
			myCard3.temple = CardTemple.Wizard;
		}

		public static void AddMidasCard()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();

			CardInfo myCard = CardManager.New("mag", "mag_midas", "Aurumtact", 1, 3, "An elder scholar, cursed for his greed, entombing anything he touches in pure gold.")

							.SetBloodCost(bloodCost: 2)
							.SetPortrait(Tools.getImage("midas.png"))
							.AddAppearances(CardAppearanceBehaviour.Appearance.RareCardBackground)
							.AddAbilities(SigilCode.MidasTouchA.ability)
							.AddMetaCategories(CardMetaCategory.Rare);
			myCard.SetExtendedProperty("ManaCost", true);
			myCard.temple = CardTemple.Wizard;
		}

			public static void AddPrismaticShards()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			list.Add(CardMetaCategory.Rare);

			CardInfo myCard = CardManager.New("mag", "mag_prismaticshards", "Chained Mox", 0, 2, "A collection of 3 moxen, tangled together, combining their mana energy.")

							.SetCost(bloodCost: 0)
							.SetBloodCost(bloodCost: 2)
							.AddTraits(Trait.Gem)
							.SetPortrait(Tools.getImage("moxochain.png"))
							.AddAppearances(CardAppearanceBehaviour.Appearance.RareCardBackground)
							.AddAbilities(Ability.GainGemGreen, Ability.GainGemBlue, Ability.GainGemOrange)
							.AddMetaCategories(list[0]);
			myCard.SetExtendedProperty("ManaCost", true);
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddMaux()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			list.Add(CardMetaCategory.ChoiceNode);

			CardInfo myCard = CardManager.New("mag", "mag_maux", "Maux", 0, 1, "In all my years, I have NEVER seen an imitation cruder than this.")
							.SetBloodCost(bloodCost: 0)
							.AddTraits(Trait.Gem)
                            .SetAffectedByTidalLock(true)
                            .SetPortrait(Tools.getImage("maux.png"))
							.SetPixelPortrait(Tools.getImage("pixelportrait_maux.png"))
							.AddAppearances(CardAppearanceBehaviour.Appearance.TerrainBackground)
							.AddMetaCategories(list[0]);
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddStimMage()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			list.Add(CardMetaCategory.ChoiceNode);

			CardInfo myCard = CardManager.BaseGameCards.CardByName("StimMage")// "It strives to grow stronger, disregarding its own wellbeing..")
							.SetPortrait(Tools.getImage("StimMage.png"))
							.SetBaseAttackAndHealth(0, 1)
							.AddMetaCategories(list[0]);
			myCard.temple = CardTemple.Wizard;
			myCard.abilities = new List<Ability> { SigilCode.Stimulation.ability };
			myCard.description = "It strives to grow stronger, disregarding its own wellbeing..";
		}

		public static void AddGourmage()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			list.Add(CardMetaCategory.ChoiceNode);

			CardInfo myCard = CardManager.BaseGameCards.CardByName("MarrowMage")
							.SetPortrait(Tools.getImage("gourmage.png"))
							.AddMetaCategories(list[0]);
			myCard.abilities = new List<Ability> { SigilCode.BoneMarrow.ability };
			myCard.description = "A gluttonous mage who devours the corpses of your fallen to grow stroner.. Disgusting.";
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddDunceMage()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			list.Add(CardMetaCategory.ChoiceNode);

			CardInfo myCard = CardManager.New("mag", "mag_duncemage", "Dunce", 1, 1, "This one can never seem to hit its target..")

							.SetCost(bloodCost: 0, gemsCost: new List<GemType> { GemType.Green })
							.SetPortrait(Tools.getImage("the wiz.png"))
							.AddAbilities(Ability.SplitStrike)
							.AddMetaCategories(list[0]);

			myCard.temple = CardTemple.Wizard;
		}

		public static void AddSwordSage()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			list.Add(CardMetaCategory.ChoiceNode);

			CardInfo myCard = CardManager.New("mag", "mag_sabesage", "Grootslang", 1, 2, "The mere graze of its fangs is enough to kill any creature. No matter the size.")

							.SetCost(bloodCost: 1)
							.SetPortrait(Tools.getImage("SaberSage.png"))
							.AddAbilities(Ability.Deathtouch, SigilCode.FamiliarA.ability)
							.AddMetaCategories(list[0]);
			myCard.SetExtendedProperty("ManaCost", true);
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddTutorWorm()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { CardMetaCategory.ChoiceNode };
			CardInfo myCard = CardManager.New("mag", "mag_tutorworm", "Bookworm", 1, 1, "A rare kind of insect that absorbs knowledge out of books.")

					.SetPortrait(Tools.getImage("tutorworm.png"))
					.SetAffectedByTidalLock(true)
					.SetCost(bloodCost: 1)
					.AddAbilities(Ability.Tutor, SigilCode.FamiliarA.ability);
			myCard.metaCategories = list;
			myCard.SetExtendedProperty("ManaCost", true);
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddAlchemist()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			list.Add(CardMetaCategory.ChoiceNode);

			List<GemType> list2 = new List<GemType>();
			list2.Add(GemType.Green);
			List<Ability> list4 = new List<Ability>();
			list4.Add(Ability.MoveBeside);
			list4.Add(Ability.BuffNeighbours);

			CardInfo myCard = CardManager.New("mag", "mag_alchemist", "Alchemist", 0, 1, "A supporting one. It brews potions to empower your cards.")

					.SetCost(bloodCost: 0, gemsCost: list2)
					.SetPixelPortrait(Tools.getSprite("pixelportrait_alchemist.png"))
					.SetPortrait(Tools.getImage("alchemist.png"))
					.AddAbilities(list4[0], list4[1])
					.AddMetaCategories(list[0]);
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddBellMage()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			list.Add(CardMetaCategory.Rare);
			List<GemType> list2 = new List<GemType>();
			list2.Add(GemType.Orange);
			List<CardAppearanceBehaviour.Appearance> list3 = new List<CardAppearanceBehaviour.Appearance>();
			list3.Add(CardAppearanceBehaviour.Appearance.RareCardBackground);
			List<SpecialTriggeredAbility> list4 = new List<SpecialTriggeredAbility>();
			list4.Add(SpecialTriggeredAbility.Daus);
			List<Ability> list6 = new List<Ability>();
			list6.Add(Ability.CreateBells);

			string text = "mag_BellMage";
			string text2 = "Chime Mage";
			int num = 0;
			int num2 = 2;
			string text3 = "Its chime can prove to be quite annoying..";
			List<Ability> list12 = list6;
			List<CardAppearanceBehaviour.Appearance> list13 = list3;
			CardInfo myCard = CardManager.New("mag", text, text2, num, num2, text3)

					.SetCost(bloodCost: 0, gemsCost: list2)
					.SetPortrait(Tools.getImage("mag_chimemage.png"))
					.AddSpecialAbilities(list4[0])
					.AddAbilities(list6[0], Ability.BuffNeighbours)
					.AddAppearances(CardAppearanceBehaviour.Appearance.RareCardBackground)
					.AddMetaCategories(list[0]);
			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;

			CardInfo customCard = InscryptionAPI.Card.CardManager.BaseGameCards.CardByName("DausBell");
			customCard.SetAffectedByTidalLock(true);
			customCard.appearanceBehaviour = new List<CardAppearanceBehaviour.Appearance> { CardAppearanceBehaviour.Appearance.TerrainBackground };
		}

		public static void AddAlmondCookie()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			list.Add(CardMetaCategory.ChoiceNode);
			List<Ability> list2 = new List<Ability>();
			list2.Add(SigilCode.LifeUpOmega.ability);

			CardInfo myCard = CardManager.New("mag", "mag_almondcookie", "Revivor", 0, 3, "It brings a mage back from the dead, at the cost of its own health.")

								.SetCost(bloodCost: 1)
								.SetPortrait(Tools.getImage("almond cookie.png"))
								.AddAbilities(list2[0])
								.AddMetaCategories(list[0]);
			myCard.SetExtendedProperty("ManaCost", true);
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddRuneMage()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			list.Add(CardMetaCategory.ChoiceNode);
			List<Ability> list2 = new List<Ability>();
			list2.Add(SigilCode.SummonRunes.ability);

			CardInfo myCard = CardManager.New("mag", "mag_runemage", "Rune Mage", 1, 2, "It conjures explosive runes alongside it when summoned. Not a good idea, I must say.")
								.SetCost(bloodCost: 1)
								.SetPortrait(Tools.getImage("runemage.png"))
								.AddAbilities(list2[0])
								.AddMetaCategories(list[0]);
			myCard.SetExtendedProperty("ManaCost", true);
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddKillSquid()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			list.Add(CardMetaCategory.ChoiceNode);

			CardInfo myCard = CardManager.New("mag", "mag_killsquid", "--~~--~~--", 0, 2, "So it arrives.")
								.SetGemsCost(new List<GemType> { GemType.Orange })
								.SetPortrait(Tools.getImage("squid_kill.png"))
								.AddSpecialAbilities(SigilCode.KillSquid.FullSpecial.Id)
								.AddMetaCategories(list[0]);
			myCard.specialStatIcon = SigilCode.KillSquid.FullStatIcon.Id;
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddSpellSquid()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			list.Add(CardMetaCategory.ChoiceNode);

			CardInfo myCard = CardManager.New("mag", "mag_spellsquid", "~~--~~--~~", 0, 3, "I foresaw its arrival.")
								.SetGemsCost(new List<GemType> { GemType.Blue })
								.SetPortrait(Tools.getImage("spelltentacle.png"))
								.AddSpecialAbilities(SigilCode.SpellPower.FullSpecial.Id)
								.AddMetaCategories(list[0]);
			myCard.specialStatIcon = SigilCode.SpellPower.FullStatIcon.Id;
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddCounterbatterySquid()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			list.Add(CardMetaCategory.ChoiceNode);

			CardInfo myCard = CardManager.New("mag", "mag_counterbatterysquid", "~-~-~-~-~-~", 0, 1, "At last, it is here.")
								.SetGemsCost(new List<GemType> { GemType.Green })
								.SetPortrait(Tools.getImage("squid_counterbattery.png"))
								.AddSpecialAbilities(SigilCode.CounterBatteryPower.FullSpecial.Id)
								.AddMetaCategories(list[0]);
			myCard.specialStatIcon = SigilCode.CounterBatteryPower.FullStatIcon.Id;
			myCard.temple = CardTemple.Wizard;
		}


		public static void AddSnipeSage()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			list.Add(CardMetaCategory.ChoiceNode);
			List<Ability> list2 = new List<Ability>();
			list2.Add(Ability.Sniper);

			CardInfo myCard = CardManager.New("mag", "mag_snipesage", "Sniper Sage", 1, 1, "A mage whose training allows it to cast spells from afar.")

								.SetGemsCost(new List<GemType> { GemType.Orange })
								.SetPortrait(Tools.getImage("snipesage.png"))
								.SetPixelPortrait(Tools.getImage("pixelportrait_snipesage.png"))
								.AddAbilities(list2[0])
								.AddMetaCategories(list[0]);
			myCard.temple = CardTemple.Wizard;
		}


		public static void AddRunes()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			List<Ability> list2 = new List<Ability>();
			list2.Add(SigilCode.Runic.ability);

			CardInfo myCard = CardManager.New("mag", "mag_runes", "Rune", 0, 1, "This is the last call, for alcohol.")
								.AddAppearances(CardAppearanceBehaviour.Appearance.TerrainBackground)
								.SetCost(bloodCost: 0)
								.SetPortrait(Tools.getImage("runeexplosive.png"))
								.AddAbilities(list2[0]);
			myCard.temple = CardTemple.Wizard;
			myCard.metaCategories = new List<CardMetaCategory>();
		}

		public static void AddFire()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			List<Ability> list2 = new List<Ability>();
			list2.Add(Ability.BuffEnemy);

			CardInfo myCard = CardManager.New("mag", "mag_orluflame", "Flame", 0, 1, "This is the last call, for alcohol.")
								.SetCost(bloodCost: 0)
								.SetPortrait(Tools.getImage("orluflame.png"))
								.AddAbilities(list2[0]);
			myCard.temple = CardTemple.Wizard;
			myCard.metaCategories = new List<CardMetaCategory>();
		}

		public static void AddMoxRabbit()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			List<Ability> list2 = new List<Ability>();
			list2.Add(Ability.GainGemBlue);

			CardInfo myCard = CardManager.New("mag", "mag_moxrabbit", "Rabbit", 0, 1, "This is the last call, for alcohol.")
								.SetCost(bloodCost: 0)
								.SetAffectedByTidalLock(true)
								.SetPortrait(Tools.getImage("moxrabbit.png"))
								.AddTraits(Trait.Gem)
								.AddAppearances(CardAppearanceBehaviour.Appearance.TerrainBackground)
								.AddAbilities(list2[0]);
			myCard.temple = CardTemple.Wizard;
			myCard.metaCategories = new List<CardMetaCategory>();
		}

		public static void AddGreenMoxRabbit()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			List<Ability> list2 = new List<Ability>();
			list2.Add(Ability.GainGemGreen);

			CardInfo myCard = CardManager.New("mag", "greenmoxrabbit", "Rabbit", 0, 1, "This is the last call, for booze.")
								.SetCost(bloodCost: 0)
                                .SetAffectedByTidalLock(true)
                                .SetPortrait(Tools.getImage("moxrabbitgreen.png"))
								.AddTraits(Trait.Gem)
								.AddAppearances(CardAppearanceBehaviour.Appearance.TerrainBackground)
								.AddAbilities(list2[0]);
			myCard.temple = CardTemple.Wizard;
			myCard.metaCategories = new List<CardMetaCategory>();
		}

		public static void AddOrangeMoxRabbit()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			List<Ability> list2 = new List<Ability>();
			list2.Add(Ability.GainGemOrange);

			CardInfo myCard = CardManager.New("mag", "mag_orangemoxrabbit", "Rabbit", 0, 1, "This is the last call, for ale.")
								.SetCost(bloodCost: 0)
                                .SetAffectedByTidalLock(true)
                                .SetPortrait(Tools.getImage("moxrabbitorange.png"))
								.AddTraits(Trait.Gem)
								.AddAppearances(CardAppearanceBehaviour.Appearance.TerrainBackground)
								.AddAbilities(list2[0]);
			myCard.temple = CardTemple.Wizard;
			myCard.metaCategories = new List<CardMetaCategory>();
		}




		public static void AddMasterGO()
		{
			List<CardMetaCategory> metaCategories = new List<CardMetaCategory> { CardMetaCategory.Rare };

			CardInfo myCard = CardManager.BaseGameCards.CardByName("MasterGoranj")// CardManager.New("mag", "MasterGoranj", "Master Goranj", 2, 6, "The towering Master Goranj. Not only a caster of fearsome Magicks, but possessed of a sturdy poise as well.")
					.SetPortrait(Tools.getImage("MasterGO.png"))
					.AddAppearances(CardAppearanceBehaviour.Appearance.RareCardBackground)
					.AddMetaCategories(metaCategories[0]);
			myCard.description = "The towering Master Goranj. Not only a caster of fearsome Magicks, but possessed of a sturdy poise as well.";
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddMasterBG()
		{

			List<CardMetaCategory> metaCategories = new List<CardMetaCategory> { CardMetaCategory.Rare };

			CardInfo myCard = CardManager.BaseGameCards.CardByName("MasterBleene")
					.SetPortrait(Tools.getImage("MasterBG.png"))
					.AddAppearances(CardAppearanceBehaviour.Appearance.RareCardBackground)
					.AddMetaCategories(metaCategories[0]);
			myCard.description = "The selfless Master Bleene. It shall help you in times of dire need… At the cost of its own ability to defend itself. Admirable.";
			myCard.abilities = new List<Ability> { SigilCode.BleeneDraw.ability };
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddMasterOB()
		{
			List<CardMetaCategory> metaCategories = new List<CardMetaCategory> { CardMetaCategory.Rare };

			CardInfo myCard = CardManager.BaseGameCards.CardByName("MasterOrlu")
					.SetPortrait(Tools.getImage("MasterOB.png"))
					.SetBaseAttackAndHealth(1, (config.classicCardBalance) ? 1 : 3)
					.AddAppearances(CardAppearanceBehaviour.Appearance.RareCardBackground)
					.AddMetaCategories(metaCategories[0]);
			myCard.description = "The great Master Orlu, soaring on pale wings, it attacks from above and draws in cards from below..";
			myCard.abilities = new List<Ability> { SigilCode.OrluHit.ability, Ability.Flying };
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddMasterMagnus()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();

			List<CardAppearanceBehaviour.Appearance> list3 = new List<CardAppearanceBehaviour.Appearance>();
			list3.Add(CardAppearanceBehaviour.Appearance.RareCardBackground);
			CardInfo myCard = CardManager.New("mag", "mag_mastertriple1", "Master Magnus", 1, 1, "my name is.. Shake-Zula! The Mic rula! The Old Schoola! You want a trip? I'll bring it to ya...")

					.SetPortrait(Tools.getImage("MasterMagnus_1.png"))
					.SetCost(bloodCost: 0, gemsCost: new List<GemType> { GemType.Green })
					.SetTraits(Trait.Gem)
					.AddAppearances(list3[0])
					.AddAbilities(SigilCode.MagGainGemTriple.ability);

			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddMasterMagnus2()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();

			List<CardAppearanceBehaviour.Appearance> list3 = new List<CardAppearanceBehaviour.Appearance>();
			list3.Add(CardAppearanceBehaviour.Appearance.RareCardBackground);
			CardInfo myCard = CardManager.New("mag", "mag_mastertriple2", "Master Magnus", 2, 1, "Frylock yeah Im on top rock you like a cop, meatwad you're up next with your knock knock!")

					.SetPortrait(Tools.getImage("MasterMagnus_2.png"))
					.SetCost(bloodCost: 0, gemsCost: new List<GemType> { GemType.Orange })
					.SetTraits(Trait.Gem)
					.AddAppearances(list3[0])
					.AddAbilities(SigilCode.MagGainGemTriple.ability, Ability.RandomAbility);

			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddMasterMagnus3()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			List<Ability> list2 = new List<Ability>();
			list2.Add(SigilCode.MagGainGemTriple.ability);
			list2.Add(Ability.MadeOfStone);
			list2.Add(Ability.RandomAbility);
			List<CardAppearanceBehaviour.Appearance> list3 = new List<CardAppearanceBehaviour.Appearance>();
			list3.Add(CardAppearanceBehaviour.Appearance.RareCardBackground);
			CardInfo myCard = CardManager.New("mag", "mag_mastertriple3", "Master Magnus", 2, 1, "Meatwad get the money, see. Meatwad get the honeys, G. ")

					.SetPortrait(Tools.getImage("MasterMagnus_3.png"))
					.SetCost(bloodCost: 0, gemsCost: new List<GemType> { GemType.Blue })
					.SetTraits(Trait.Gem)
					.AddAppearances(list3[0])
					.AddAbilities(SigilCode.MagGainGemTriple.ability, Ability.RandomAbility, Ability.RandomAbility);

			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddPheonix()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { CardMetaCategory.Rare };

			List<CardAppearanceBehaviour.Appearance> list3 = new List<CardAppearanceBehaviour.Appearance>();
			list3.Add(CardAppearanceBehaviour.Appearance.RareCardBackground);
			CardInfo myCard = CardManager.New("mag", "mag_pheonix", "Phoenix", 1, 2, "Majestic avian, rumoured to have been an accomplice to Master Orlu...")

					.SetPortrait(Tools.getImage("orlu pheonix.png"))
					.SetCost(bloodCost: 0, gemsCost: new List<GemType> { GemType.Blue, GemType.Blue })
					.AddAppearances(list3[0])
					.AddAbilities(SigilCode.Ignite.ability, Ability.Flying);

			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddBleenehound()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { CardMetaCategory.Rare };

			List<CardAppearanceBehaviour.Appearance> list3 = new List<CardAppearanceBehaviour.Appearance>();
			list3.Add(CardAppearanceBehaviour.Appearance.RareCardBackground);
			CardInfo myCard = CardManager.New("mag", "mag_bleenehound", "Bleenehound", 3, 2, "Loyalist canine, rumoured to have been Master Bleene's loyal companion.")

					.SetPortrait(Tools.getImage("bleenehound.png"))
					.SetCost(bloodCost: 0, gemsCost: new List<GemType> { GemType.Green, GemType.Blue })
					.AddAppearances(list3[0])
					.AddAbilities(Ability.GuardDog);

			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddBleeneBooks()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();

			CardInfo alchemy = CardManager.New("mag", "mag_bleenebookalchemy", "Alchemy 101", 0, 2, "[c:g2]Alchemy IOI[c:]\n[c:g3]I[c:] [c:g1]never[c:] [c:g3]was[c:] [c:g1]that[c:] [c:g3]great[c:] [c:g1]at[c:] [c:g3]alchemy..[c:]")

					.SetPortrait(Tools.getImage("bleenebook_alchemy.png"))
					.SetCost(bloodCost: 0, gemsCost: new List<GemType> { GemType.Green })
					.AddAbilities(Ability.BuffNeighbours);
			alchemy.metaCategories = list;
			CardInfo buffgems = CardManager.New("mag", "mag_bleenebookbuffgems", "Guide to Attack", 1, 1, "[c:g2]Guide to Attack[c:]\n[c:g3]One[c:] [c:g1]of[c:] [c:g3]the[c:] [c:g1]first[c:] [c:g3]books[c:] [c:g1]I[c:] [c:g3]ever[c:] [c:g1]read.[c:]")

					.SetPortrait(Tools.getImage("bleenebook_buffgems.png"))
					.SetCost(bloodCost: 0, gemsCost: new List<GemType> { GemType.Orange })
					.AddAbilities(Ability.BuffGems);
			buffgems.metaCategories = list;
			CardInfo impaled = CardManager.New("mag", "mag_bleenebookimpaled", "Art of Surprise", 1, 1, "[c:g2]The art of Surprise[c:]\n[c:g3]Looks[c:] [c:g1]like[c:] [c:g3]a[c:] [c:g1]frustrated[c:] [c:g3]mage[c:] [c:g1]stabbed[c:] [c:g3]it.[c:]")

					.SetPortrait(Tools.getImage("bleenebook_impaled.png"))
					.SetCost(bloodCost: 0, gemsCost: new List<GemType> { GemType.Orange })
					.AddAbilities(SigilCode.MagDropSpear.ability);
			impaled.metaCategories = list;
			CardInfo repulsive = CardManager.New("mag", "mag_bleenebookrepulsive", " Forbidden Secrets", 0, 1, "[c:g2]The Tome of Forbidden Secrets[c:]\n[c:g3]Quite[c:] [c:g1]tough[c:] [c:g3]to[c:] [c:g1]open.[c:]")

					.SetPortrait(Tools.getImage("bleenebook_repulsive.png"))
					.SetCost(bloodCost: 0, gemsCost: new List<GemType> { GemType.Blue })
					.AddAbilities(Ability.PreventAttack, Ability.GemDependant);
			repulsive.metaCategories = list;
			CardInfo revivor = CardManager.New("mag", "mag_bleenebookrevivor", "Life and Death", 0, 3, "[c:g2]The Secrets of Life and Death[c:]\n[c:g3]A[c:] [c:g1]forbidden[c:] [c:g3]book,[c:] [c:g1]I[c:] [c:g3]had[c:] [c:g1]to[c:] [c:g3]read[c:] [c:g1]it[c:] [c:g3]in[c:] [c:g1]secret![c:]")

					.SetPortrait(Tools.getImage("bleenebook_revivor.png"))
					.SetCost(bloodCost: 1)
					.AddAbilities(SigilCode.LifeUpOmega.ability);
			revivor.metaCategories = list;
			CardInfo sharp = CardManager.New("mag", "mag_bleenebooksharp", "Book of War", 1, 2, "[c:g2]Book of War[c:]\n[c:g3]A[c:] [c:g1]painful,[c:] [c:g3]yet[c:] [c:g1]informative[c:] [c:g3]read.[c:]")

					.SetPortrait(Tools.getImage("bleenebook_sharp.png"))
					.SetCost(bloodCost: 0, gemsCost: new List<GemType> { GemType.Orange })
					.AddAbilities(Ability.Sharp);
			sharp.metaCategories = list;
			CardInfo gold = CardManager.New("mag", "mag_bleenebookgold", "Gilded Codex", 0, 4, "[c:g2]Gold-Encrusted Codex[c:]\n[c:g3]Possibly[c:] [c:g1]the[c:] [c:g3]most[c:] [c:g1]valueable[c:] [c:g3]book[c:] [c:g1]I[c:] [c:g3]own.[c:]")

					.SetPortrait(Tools.getImage("bleenebook_gold.png"))
					.SetCost(bloodCost: 0, gemsCost: new List<GemType> { GemType.Orange })
					.AddAbilities(SigilCode.DropMana.ability);
			gold.metaCategories = list;
			CardInfo runes = CardManager.New("mag", "mag_bleenebookrunes", "Introduction to Runes", 0, 1, "[c:g2]Introduction to Runes[c:]\n[c:g3]'Twas[c:] [c:g1]an[c:] [c:g3]absolute[c:] [c:g1]nightmare[c:] [c:g3]learning[c:] [c:g1]all[c:] [c:g3]those[c:] [c:g1]runes.[c:]")

					.SetPortrait(Tools.getImage("bleenebook_runes.png"))
					.SetCost(bloodCost: 0, gemsCost: new List<GemType> { GemType.Blue })
					.AddAbilities(Ability.ExplodeOnDeath);
			runes.metaCategories = list;
			CardInfo slime = CardManager.New("mag", "mag_bleenebookslime", "Gooey Book", 0, 2, "[c:g2]A Brief Hist-[c:] [c:g3]Wait[c:] [c:g1]a[c:] [c:g3]minute..[c:] [c:g1]Some[c:] [c:g3]vandal[c:] [c:g1]ruined[c:] [c:g3]this[c:] [c:g1]one![c:]")

					.SetPortrait(Tools.getImage("bleenebook_slime.png"))
					.SetCost(bloodCost: 0, gemsCost: new List<GemType> { GemType.Green })
					.AddAbilities(SigilCode.GoobertDebuff.ability);
			slime.metaCategories = list;
			CardInfo stinky = CardManager.New("mag", "mag_bleenebookstinky", "Bogbound Spells", 1, 2, "[c:g2]Bogbound Spells[c:]\n[c:g3]Eurgh,[c:] [c:g1]it's[c:] [c:g3]in[c:] [c:g1]way[c:] [c:g3]worse[c:] [c:g1]condition[c:] [c:g3]than[c:] [c:g1]I[c:] [c:g3]remember.[c:]")

					.SetPortrait(Tools.getImage("bleenebook_stinky.png"))
					.SetCost(bloodCost: 0, gemsCost: new List<GemType> { GemType.Green })
					.AddAbilities(Ability.DebuffEnemy);
			stinky.metaCategories = list;
			CardInfo familiar = CardManager.New("mag", "mag_bleenebookfamiliar", "Taming Familiars", 0, 5, "[c:g2]Guide to Taming Familiars[c:]\n[c:g3]Borrowed[c:] [c:g1]this[c:] [c:g3]one[c:] [c:g1]from[c:] [c:g3]a[c:] [c:g1]friend[c:] [c:g3]in[c:] [c:g1]the[c:] [c:g3]wood.[c:]")

					.SetPortrait(Tools.getImage("bleenebook_familiar.png"))
					.SetCost(bloodCost: 0, gemsCost: new List<GemType> { GemType.Blue });
			familiar.metaCategories = list;
			CardInfo horde = CardManager.New("mag", "mag_bleenebookhorde", "Raising the Horde", 0, 4, "[c:g2]Raising the Horde[c:]\n[c:g3]I[c:] [c:g1]had[c:] [c:g3]to[c:] [c:g1]sneak[c:] [c:g3]into[c:] [c:g1]a[c:] [c:g3]crypt[c:] [c:g1]to[c:] [c:g3]get[c:] [c:g1]this[c:] [c:g3]one![c:]")

					.SetPortrait(Tools.getImage("bleenebook_skelemage.png"))
					.SetCost(bloodCost: 0)
					.AddTraits(Trait.Gem)
					.AddAbilities(Ability.GainGemTriple, SigilCode.LifeUpOmega.ability);
			horde.metaCategories = list;
			CardInfo animator = CardManager.New("mag", "mag_bleenebookanimator", "Art of Possesion", 0, 5, "[c:g2]The Art of Possesion[c:]\n[c:g3]Animating[c:] [c:g1]other[c:] [c:g3]mages[c:] [c:g1]was[c:] [c:g3]considered[c:] [c:g1]taboo[c:] [c:g3]back[c:] [c:g1]when[c:] [c:g3]I[c:] [c:g1]was[c:] [c:g3]around.[c:]")

					.SetPortrait(Tools.getImage("bleenebook_animator.png"))
					.AddAbilities(SigilCode.Animator.ability)
					.SetCost(bloodCost: 0, gemsCost: new List<GemType> { GemType.Blue });
			animator.metaCategories = list;
		}

		public static void AddMoon()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			List<Ability> list2 = new List<Ability>();
			CardInfo myCard = CardManager.New("mag", "mag_giantmoon", "The Moon", 1, 7, "OH THE MOON O HTHEMOON OH THE MOON O H THE MOON.")

					.SetPortrait(Tools.getImage("moon_portrait.png"))
					.SetCost(bloodCost: 0)
					.AddTraits(Trait.Giant)
					.AddSpecialAbilities(SpecialTriggeredAbility.GiantCard)
					.AddAbilities(Ability.Reach, Ability.AllStrike, Ability.MadeOfStone);

			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddEarth()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			List<Ability> list2 = new List<Ability>();
			CardInfo myCard = CardManager.New("mag", "mag_giantearth", "The Earth", 2, 55, "The urth.")

					.SetPortrait(Tools.getImage("earth_portrait.png"))
					.SetCost(bloodCost: 0)
					.AddTraits(Trait.Giant)
					.AddSpecialAbilities(SpecialTriggeredAbility.GiantCard)
					.AddAbilities(Ability.Reach, Ability.AllStrike, Ability.MadeOfStone);

			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddFinalMagnus()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			List<Ability> list2 = new List<Ability>();
			CardInfo myCard = CardManager.New("mag", "mag_giantmagnus", "Master Magnus", 1, 10, "Cause we are the aqua teens, make the homies say ho and the girlies wanna scream")

					.SetPortrait(Tools.getImage("MasterMagnus_4.png"))
					.SetCost(bloodCost: 1)
					.AddTraits(Trait.Giant)
					.AddSpecialAbilities(SpecialTriggeredAbility.GiantCard)
					.AddAbilities(Ability.Reach, Ability.AllStrike, Ability.MadeOfStone, SigilCode.MagGainGemTriple.ability);

			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddHydras()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			CardInfo green = CardManager.New("mag", "mag_hydragreen", "Head of Emerald", 0, 3, "trogdor")

					.SetPortrait(Tools.getImage("hydragreen.png"))
					.SetCost(gemsCost: new List<GemType> { GemType.Green })
					.AddAbilities(Ability.Reach, Ability.DebuffEnemy, Ability.WhackAMole);
			green.metaCategories = list;
			CardInfo orange = CardManager.New("mag", "mag_hydraorange", "Head of Ruby", 2, 4, "haha goarnj")

					.SetPortrait(Tools.getImage("hydraorange.png"))
					.SetCost(gemsCost: new List<GemType> { GemType.Orange })
					.AddAbilities(Ability.Reach, Ability.GuardDog, Ability.BuffGems);
			orange.metaCategories = list;
			CardInfo blue = CardManager.New("mag", "mag_hydrablue", "Head of Sapphire", 1, 4, "mind gaames")

					.SetPortrait(Tools.getImage("hydrablue.png"))
					.SetCost(gemsCost: new List<GemType> { GemType.Blue })
					.AddAbilities(Ability.Reach, Ability.AllStrike, Ability.MadeOfStone);
			blue.metaCategories = list;
			CardInfo black = CardManager.New("mag", "mag_hydrablack", "Heads of Void", 0, 5, "evil")

					.SetPortrait(Tools.getImage("hydrablack.png"))
					.SetCost(bloodCost: 1)
					.AddTraits(Trait.Gem)
					.AddAbilities(Ability.Reach, Ability.Sharp, Ability.MadeOfStone, Ability.SplitStrike);
			black.metaCategories = list;
		}

		public static void AddMoonShards()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			List<Ability> list2 = new List<Ability>();
			CardInfo myCard = CardManager.New("mag", "mag_giantmoonshards", "Moon Shards", 0, 3, "OH THE MOON O HTHEMOON OH THE MOON O H THE MOON.")

					.SetPortrait(Tools.getImage("moonshards.png"))
					.SetCost(bloodCost: 0)
					.AddAbilities(Ability.Reach, Ability.BuffGems);

			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;

			List<CardMetaCategory> list3 = new List<CardMetaCategory>();
			CardInfo myCard2 = CardManager.New("mag", "mag_giantmoonshards2", "Moon Shards", 0, 3, "OH THE MOON O HTHEMOON OH THE MOON O H THE MOON.")

					.SetPortrait(Tools.getImage("moonshards.png"))
					.SetCost(bloodCost: 0)
					.AddAbilities(Ability.Reach, Ability.DeathShield);

			myCard.metaCategories = list3;
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddVenus()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			List<Ability> list2 = new List<Ability>();
			CardInfo myCard = CardManager.New("mag", "mag_venus", "Venus", 1, 3, "Its a me venus!")

					.SetPortrait(Tools.getImage("venus.png"))
					.AddTraits(Trait.Gem)
					.SetCost(bloodCost: 0)
					.AddAppearances(CardAppearanceBehaviour.Appearance.TerrainBackground)
					.AddAbilities(Ability.Reach, Ability.Sharp);

			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}
		public static void AddMars()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			List<Ability> list2 = new List<Ability>();
			CardInfo myCard = CardManager.New("mag", "mag_mars", "Mars", 1, 2, "Its a me mars!")

					.SetPortrait(Tools.getImage("mars.png"))
					.AddAppearances(CardAppearanceBehaviour.Appearance.TerrainBackground)
					.AddTraits(Trait.Gem)
					.SetCost(bloodCost: 0)
					.AddAbilities(Ability.Reach, Ability.GainAttackOnKill);

			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddMercury()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			List<Ability> list2 = new List<Ability>();
			CardInfo myCard = CardManager.New("mag", "mag_mercury", "Mercury", 2, 2, "Its a me mercury!")

					.SetPortrait(Tools.getImage("mercury.png"))
					.AddTraits(Trait.Gem)
					.SetCost(bloodCost: 0)
					.AddAppearances(CardAppearanceBehaviour.Appearance.TerrainBackground)
					.AddAbilities(Ability.Deathtouch);

			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}
		public static void AddNeptune()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			List<Ability> list2 = new List<Ability>();
			CardInfo myCard = CardManager.New("mag", "mag_neptune", "Neptune", 1, 3, "Its a me neptune!")

					.SetPortrait(Tools.getImage("neptune.png"))
					.AddTraits(Trait.Gem)
					.AddAppearances(CardAppearanceBehaviour.Appearance.TerrainBackground)
					.SetCost(bloodCost: 0)
					.AddAbilities(SigilCode.FrostyA.ability);

			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}

        public static void AddUranus()
        {
            List<CardMetaCategory> list = new List<CardMetaCategory>();
            List<Ability> list2 = new List<Ability>();
            CardInfo myCard = CardManager.New("mag", "mag_uranus", "Uranus", 0, 4, "Its a funny one!")

                    .SetPortrait(Tools.getImage("uranus.png"))
                    .AddTraits(Trait.Gem)
                    .AddAppearances(CardAppearanceBehaviour.Appearance.TerrainBackground)
                    .SetCost(bloodCost: 0)
                    .AddAbilities(Ability.SquirrelOrbit);

            myCard.metaCategories = list;
            myCard.temple = CardTemple.Wizard;
        }

        public static void AddJupiter()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			List<Ability> list2 = new List<Ability>();
			CardInfo myCard = CardManager.New("mag", "mag_jupiter", "Jupiter", 0, 5, "Its a me jupiter!")

					.SetPortrait(Tools.getImage("jupiter.png"))
					.SetCost(bloodCost: 0)
					.AddAbilities(Ability.Reach, SigilCode.StrongPull.ability);

			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddSaturn()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			List<Ability> list2 = new List<Ability>();
			CardInfo myCard = CardManager.New("mag", "mag_saturn", "Saturn", 1, 3, "Its a me saturn!")

					.SetPortrait(Tools.getImage("saturn.png"))
					.SetCost(bloodCost: 0)
					.AddAbilities(Ability.AllStrike);

			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}

        public static void AddPluto()
        {
            List<CardMetaCategory> list = new List<CardMetaCategory>();
            List<Ability> list2 = new List<Ability>();
            CardInfo myCard = CardManager.New("mag", "mag_pluto", "Pluto", 1, 2, "Little Guy comin' through")

                    .SetPortrait(Tools.getImage("pluto.png"))
                    .AddTraits(Trait.Gem)
                    .AddAppearances(CardAppearanceBehaviour.Appearance.TerrainBackground)
                    .SetCost(bloodCost: 0)
                    .AddAbilities(Ability.StrafeSwap);

            myCard.metaCategories = list;
            myCard.temple = CardTemple.Wizard;
        }


        public static void AddMasterKraken()
		{

			List<CardMetaCategory> list = new List<CardMetaCategory> { CardMetaCategory.Rare };

			List<CardAppearanceBehaviour.Appearance> list3 = new List<CardAppearanceBehaviour.Appearance>();
			list3.Add(CardAppearanceBehaviour.Appearance.RareCardBackground);
			CardInfo myCard = CardManager.New("mag", "mag_masterkraken", "The Horven", 1, 1, "A terrible creature of the sea.. Posessing 3 strange and powerful appendages.")

					.SetPortrait(Tools.getImage("master kraken.png"))
					.SetCost(bloodCost: 1)
					.AddAppearances(list3[0])
					.AddAbilities(SigilCode.submergekraken.ability);
			myCard.SetExtendedProperty("ManaCost", true);
			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}


		/*
		public static void AddSharko()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			list.Add(CardMetaCategory.ChoiceNode);
			List<GemType> list2 = new List<GemType>();
			list2.Add(GemType.Blue);
			List<Texture> list4 = new List<Texture>();
			byte[] data = File.ReadAllBytes(Path.Combine(base.Info.Location.Replace("SigilCode.dll", ""), "blue mox.png"));
			Texture2D texture2D = new Texture2D(2, 2);
			texture2D.LoadImage(data);
			list4.Add(texture2D);
			List<Ability> list5 = new List<Ability>();
			list5.Add(sharkoKick.ability);
			Texture2D texture2D2 = Tools.getImage("sharko.png");
			string text = "mag_sharko";
			string text2 = "Sea Beast";
			int num = 1;
			int num2 = 2;
			List<CardMetaCategory> list6 = list;
			CardComplexity cardComplexity = CardComplexity.Simple;
			CardTemple cardTemple = CardTemple.Nature;
			string text3 = "One of Master Cephalo's sea beasts. This one has to be one of the strangest ones.";
			bool flag = false;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			List<GemType> list7 = list2;
			SpecialStatIcon specialStatIcon = SpecialStatIcon.None;
			List<Tribe> list8 = null;
			List<Trait> list9 = null;
			List<SpecialTriggeredAbility> list10 = null;
			List<Ability> list11 = list5;
			EvolveParams evolveParams = null;
			string text4 = null;
			TailParams tailParams = null;
			IceCubeParams iceCubeParams = null;
			bool flag2 = false;
			bool flag3 = false;
			Texture2D texture2D3 = texture2D2;
			List<Texture> list14 = list4;
			CardInfo myCard = CardManager.New("mag", text, text2, num, num2, text3)
					
					.SetCost(bloodCost: 0, gemsCost: list2)
					.SetPortrait(texture2D2)
					.AddAbilities(list5[0])
					.AddDecal(list4[0])
					.AddMetaCategories(list[0]);
						
		}

		*/
		public static void AddBGMox()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();

			CardInfo myCard = CardManager.BaseGameCards.CardByName("MoxDualBG")
					.SetPortrait(Tools.getImage("MoxGB.png"))
					.AddAppearances(CardAppearanceBehaviour.Appearance.RareCardBackground);
			myCard.traits = new List<Trait> { Trait.Gem };
			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddGOMox()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();

			CardInfo myCard = CardManager.BaseGameCards.CardByName("MoxDualGO")
					.SetPortrait(Tools.getImage("MoxGO.png"))
					.AddAppearances(CardAppearanceBehaviour.Appearance.RareCardBackground);
			myCard.traits = new List<Trait> { Trait.Gem };
			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddBOMox()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();

			CardInfo myCard = CardManager.BaseGameCards.CardByName("MoxDualOB")
					.SetPortrait(Tools.getImage("MoxBO.png"))
					.AddAppearances(CardAppearanceBehaviour.Appearance.RareCardBackground);
			myCard.traits = new List<Trait> { Trait.Gem };
			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddGoobert()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			list.Add(CardMetaCategory.Rare);
			List<GemType> list2 = new List<GemType>();
			list2.Add(GemType.Green);
			List<CardAppearanceBehaviour.Appearance> list3 = new List<CardAppearanceBehaviour.Appearance>();
			list3.Add(CardAppearanceBehaviour.Appearance.RareCardBackground);

			List<Ability> list5 = new List<Ability>();
			list5.Add(SigilCode.GoobertDebuff.ability);

			string text = "mag_goobert";
			string text2 = "Goobert";
			int num = 1;
			int num2 = 3;
			List<CardMetaCategory> list6 = list;
			CardComplexity cardComplexity = CardComplexity.Simple;
			CardTemple cardTemple = CardTemple.Nature;
			string text3 = "A replica of my goo mage.. Its loyalty is only matched by its suffering.";
			bool flag = false;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			List<GemType> list7 = list2;
			SpecialStatIcon specialStatIcon = SpecialStatIcon.None;
			List<Tribe> list8 = null;
			List<Trait> list9 = null;
			List<SpecialTriggeredAbility> list10 = null;
			List<Ability> list11 = list5;
			EvolveParams evolveParams = null;
			string text4 = null;
			TailParams tailParams = null;
			IceCubeParams iceCubeParams = null;
			bool flag2 = false;

			CardInfo myCard = CardManager.New("mag", text, text2, num, num2, text3)

					.SetCost(bloodCost: 0, gemsCost: list2)
					.SetPortrait(Tools.getImage("mag_goobert.png"))
					.AddAbilities(list5[0])
					.AddMetaCategories(list[0])
					.SetRare();
			myCard.temple = CardTemple.Wizard;
		}
		public static void AddBossExclusive()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			List<CardAppearanceBehaviour.Appearance> list2 = new List<CardAppearanceBehaviour.Appearance>();
			list2.Add(CardAppearanceBehaviour.Appearance.TerrainBackground);
			List<CardAppearanceBehaviour.Appearance> list3 = new List<CardAppearanceBehaviour.Appearance>();
			list3.Add(CardAppearanceBehaviour.Appearance.RareCardBackground);
			List<Trait> list4 = new List<Trait>();
			list4.Add(Trait.Uncuttable);
			List<Trait> list5 = new List<Trait>();
			list5.Add(Trait.Uncuttable);
			list5.Add(Trait.Giant);
			List<SpecialTriggeredAbility> list6 = new List<SpecialTriggeredAbility>();
			list6.Add(SpecialTriggeredAbility.GiantCard);
			List<Ability> list7 = new List<Ability>();
			list7.Add(SigilCode.GoobertDebuff.ability);
			List<Ability> list8 = new List<Ability>();
			list8.Add(Ability.Sharp);
			List<Ability> list9 = new List<Ability>();
			list9.Add(SigilCode.Stimulation.ability);
			List<Ability> list10 = new List<Ability>();
			list10.Add(SigilCode.StimulationHP.ability);
			list10.Add(Ability.WhackAMole);
			List<Ability> list11 = new List<Ability>();
			list11.Add(SigilCode.Stimulation.ability);
			list11.Add(Ability.PreventAttack);
			List<Ability> list12 = new List<Ability>();
			list12.Add(SigilCode.ImprovedSteelTrap.ability);
			List<Ability> list13 = new List<Ability>();
			list13.Add(SigilCode.GoobertDebuff.ability);
			list13.Add(Ability.WhackAMole);
			List<Ability> list14 = new List<Ability>();
			list14.Add(Ability.Sharp);
			list14.Add(Ability.WhackAMole);
			List<Ability> list15 = new List<Ability>();
			list15.Add(SigilCode.Stimulation.ability);
			list15.Add(Ability.WhackAMole);
			List<Ability> list16 = new List<Ability>();
			list16.Add(Ability.AllStrike);
			list16.Add(Ability.Reach);
			string text3 = "";
			string text = "mag_goo";
			string text2 = "Goo";
			int num = 0;
			int num2 = 1;
			List<CardMetaCategory> list17 = list;

			CardInfo myCard = CardManager.New("mag", text, text2, num, num2, text3)

					.SetCost()
					.SetPortrait(Tools.getImage("mag_goo.png"))
					.AddAbilities(list7[0])
					.AddMetaCategories();
			myCard.metaCategories = new List<CardMetaCategory>();
			CardInfo myCard2 = CardManager.New("mag", "mag_scarecrow", "Scarecrow", 1, 1, "")

					.SetCost()
					.SetPortrait(Tools.getImage("mag_scarecrow.png"))
					.AddAbilities(SigilCode.MagDropSpear.ability)
					.AddMetaCategories();
			myCard2.metaCategories = new List<CardMetaCategory>();
			string text5 = "mag_BOSSspear";
			string text6 = "Spear";
			int num6 = 0;
			int num7 = 1;
			List<CardMetaCategory> list25 = list;
			CardComplexity cardComplexity2 = CardComplexity.Simple;
			CardTemple cardTemple2 = CardTemple.Nature;
			string text7 = "";
			bool flag4 = false;
			int num8 = 0;
			int num9 = 0;
			int num10 = 0;
			List<GemType> list26 = null;
			SpecialStatIcon specialStatIcon2 = SpecialStatIcon.None;
			List<Tribe> list27 = null;
			List<Trait> list28 = null;
			List<SpecialTriggeredAbility> list29 = null;
			List<Ability> list30 = list8;
			EvolveParams evolveParams2 = null;
			string text8 = null;
			TailParams tailParams2 = null;
			IceCubeParams iceCubeParams2 = null;
			bool flag5 = false;
			bool flag6 = false;
			CardInfo myCard3 = CardManager.New("mag", text5, text6, num6, num7, text3)

					.SetCost()
					.SetPortrait(Tools.getImage("mag_spear.png"))
					.AddAbilities(list8[0])
					.SetTraits(Trait.Terrain)
					.AddAppearances(CardAppearanceBehaviour.Appearance.TerrainBackground)
					.AddMetaCategories();
			myCard3.metaCategories = new List<CardMetaCategory>();
			CardInfo myCard4 = CardManager.New("mag", "mag_triplescarecrow", "Scarecrow Twins", 2, 2, text3)

					.SetCost()
					.SetPortrait(Tools.getImage("mag_threescarecrow.png"))
					.AddAbilities(SigilCode.MagDropSpear.ability)
					.AddMetaCategories();
			myCard4.metaCategories = new List<CardMetaCategory>();
			List<GemType> gemcoststim = new List<GemType> { GemType.Blue };
			CardInfo myCard5 = CardManager.New("mag", "mag_BOSSstimmage", "Stim Sage", 1, 2, text3)

					.SetCost(bloodCost: 0, gemsCost: gemcoststim)
					.SetPortrait(Tools.getImage("boss stimmage.png"))
					.AddAbilities(list9[0])
					.AddMetaCategories();
			myCard5.metaCategories = new List<CardMetaCategory>();
			string text9 = "mag_BOSSlonelymage";
			string text10 = "Lonely Mage";
			int num11 = 2;
			int num12 = 9;
			List<CardMetaCategory> list33 = list;
			CardComplexity cardComplexity3 = CardComplexity.Simple;
			CardTemple cardTemple3 = CardTemple.Nature;
			string text11 = "";
			bool flag7 = false;
			int num13 = 0;
			int num14 = 0;
			int num15 = 0;
			List<GemType> list34 = null;
			SpecialStatIcon specialStatIcon3 = SpecialStatIcon.None;
			List<Tribe> list35 = null;
			List<Trait> list36 = null;
			List<SpecialTriggeredAbility> list37 = null;
			List<Ability> list38 = list10;
			string text17 = "mag_BOSStrapspear";
			string text18 = "Spear";
			List<GemType> list50 = null;
			SpecialStatIcon specialStatIcon5 = SpecialStatIcon.None;
			List<Tribe> list51 = null;
			List<Trait> list52 = null;
			List<SpecialTriggeredAbility> list53 = null;
			List<Ability> list54 = new List<Ability>();
			EvolveParams evolveParams5 = null;

			CardInfo myCard8 = CardManager.New("mag", text17, "Enchanted Spear", 0, 1, text3)

					.SetCost()
					.SetPortrait(Tools.getImage("mag_enchspear.png"))
					.SetTraits(Trait.Terrain)
					.AddAbilities(Ability.Sharp)
					.AddAppearances(CardAppearanceBehaviour.Appearance.TerrainBackground)
					.AddMetaCategories();
			myCard8.metaCategories = new List<CardMetaCategory>();

			//NewCard.Add(text30, text31, num41, num42, list68, cardComplexity9, cardTemple9, text32, flag19, num43, num44, num45, list69, specialStatIcon9, list70, list5, list6, list60, null, null, null, null, null, null, false, false, list61, texture2D10, null, null, null, null, null, null, null, null, null);
		}

		public static void AddPortraitMage()
		{

			CardInfo myCard = CardManager.New("mag", "mag_portraitmage", "Portrait Mage", 0, 0, "Your own creation.. How did it get here?")

					.SetPortrait(Tools.getImage("invisible card.png"))
					.AddAppearances(CardAppearanceBehaviour.Appearance.AnimatedPortrait)
					.AddSpecialAbilities(MagMod.CustomPortrait);

			myCard.metaCategories = new List<CardMetaCategory>();
		}
		public static void AddDeathCard()
		{
			
			CardInfo myCard = CardManager.New("mag", "mag_deathcardbase", "", 0, 0, "")

					.SetPortrait(Tools.getImage("invisible card.png"))
					.AddSpecialAbilities(MagMod.DeathCardPortrait);

			myCard.metaCategories = new List<CardMetaCategory>();
		}

		public static void AddHPspell()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { Plugin.SpellPool };
			List<CardAppearanceBehaviour.Appearance> appearanceBehaviours = new List<CardAppearanceBehaviour.Appearance> { CardAppearanceBehaviour.Appearance.TerrainLayout };

			List<Trait> traits = new List<Trait> { Trait.EatsWarrens };

			List<Ability> list5 = new List<Ability>();
			list5.Add(SigilCode.HPSpell.ability);

			CardInfo myCard = CardManager.New("mag", "mag_hpspell", "Revitilization", 0, 1, "This spell casts several healing auras to all of your cards.")

					.SetPortrait(Tools.getImage("health_spell.png"))
					.AddAbilities(list5[0])
					.SetBloodCost(0)
					.AddTraits(traits[0])
					.AddAppearances(appearanceBehaviours[0]);

            myCard.SetExtendedProperty("TargetedSpell", true);
            myCard.SetExtendedProperty("TargetAllSpell", false);
            myCard.SetExtendedProperty("ManaCost", true);
			myCard.metaCategories = list;
		}

		public static void AddATKspell()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { Plugin.SpellPool };
			List<CardAppearanceBehaviour.Appearance> appearanceBehaviours = new List<CardAppearanceBehaviour.Appearance> { CardAppearanceBehaviour.Appearance.TerrainLayout };

			List<Trait> traits = new List<Trait> { Trait.EatsWarrens };

			List<Ability> list5 = new List<Ability>();
			list5.Add(SigilCode.ATKSpell.ability);

			CardInfo myCard = CardManager.New("mag", "mag_atkspell", "Carnage", 0, 1, "This spell channels raw hellcow energy unto your cards.. Boosting their attack.")

					.SetPortrait(Tools.getImage("attack_spell.png"))
					.AddAbilities(list5[0])
					.SetBloodCost(1)
					.AddTraits(traits[0])
					.AddAppearances(appearanceBehaviours[0]);

            myCard.SetExtendedProperty("TargetedSpell", true);
            myCard.SetExtendedProperty("TargetAllSpell", false);
            myCard.SetExtendedProperty("ManaCost", true);
			myCard.metaCategories = list;
		}


		public static void AddFrostspell()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { Plugin.SpellPool };
			List<CardAppearanceBehaviour.Appearance> appearanceBehaviours = new List<CardAppearanceBehaviour.Appearance> { CardAppearanceBehaviour.Appearance.TerrainLayout };

			List<Trait> traits = new List<Trait> { Trait.EatsWarrens };
			List<Texture> list4 = new List<Texture>();

			List<Ability> list5 = new List<Ability>();
			list5.Add(SigilCode.FrostSpell.ability);

			CardInfo myCard = CardManager.New("mag", "mag_frostspell", "Blizzard", 0, 1, "Freeze over the battle with a mighty blizzard..")

					.SetPortrait(Tools.getImage("spell of frost.png"))
					.AddAbilities(list5[0])
					.AddTraits(traits[0])
					.SetBloodCost(0)
					.AddAppearances(appearanceBehaviours[0]);

            myCard.SetExtendedProperty("TargetedSpell", true);
            myCard.SetExtendedProperty("TargetAllSpell", false);
            myCard.SetExtendedProperty("ManaCost", true);
			myCard.metaCategories = list;
		}

		public static void AddWindspell()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { Plugin.SpellPool };
			List<CardAppearanceBehaviour.Appearance> appearanceBehaviours = new List<CardAppearanceBehaviour.Appearance> { CardAppearanceBehaviour.Appearance.TerrainLayout };

			List<Trait> traits = new List<Trait> { Trait.EatsWarrens };
			List<Texture> list4 = new List<Texture>();

			List<Ability> list5 = new List<Ability>();
			list5.Add(SigilCode.WindSpell.ability);

			CardInfo myCard = CardManager.New("mag", "mag_windspell", "Cyclone", 0, 1, "This spell shall summon a whirlwind that boosts your cards into the air.")

					.SetPortrait(Tools.getImage("spell of wind.png"))
					.AddAbilities(list5[0])
					.AddTraits(traits[0])
					.SetBloodCost(0)
					
					.AddAppearances(appearanceBehaviours[0]);

            myCard.SetExtendedProperty("TargetedSpell", true);
            myCard.SetExtendedProperty("TargetAllSpell", false);
            myCard.SetExtendedProperty("ManaCost", true);
			myCard.metaCategories = list;
		}

		public static void AddWaterspell()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { Plugin.SpellPool };
			List<CardAppearanceBehaviour.Appearance> appearanceBehaviours = new List<CardAppearanceBehaviour.Appearance> { CardAppearanceBehaviour.Appearance.TerrainLayout };

			List<Trait> traits = new List<Trait> { Trait.EatsWarrens };
			List<Texture> list4 = new List<Texture>();

			List<Ability> list5 = new List<Ability>();
			list5.Add(SigilCode.WaterSpell.ability);

			CardInfo myCard = CardManager.New("mag", "mag_waterspell", "Flood", 0, 1, "When used, it will summon a tsunami that wipes away the sigils of every card on the board.")

					.SetPortrait(Tools.getImage("spell of water.png"))
					.AddAbilities(list5[0])
					.AddTraits(traits[0])
					.SetBloodCost(0)
					
					.AddAppearances(appearanceBehaviours[0]);
            myCard.SetExtendedProperty("TargetedSpell", true);
            myCard.SetExtendedProperty("TargetAllSpell", false);
            myCard.SetExtendedProperty("ManaCost", true);
			myCard.metaCategories = list;
		}

		public static void AddTargetFlameSpell()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { Plugin.SpellPool };
			List<CardAppearanceBehaviour.Appearance> appearanceBehaviours = new List<CardAppearanceBehaviour.Appearance> { CardAppearanceBehaviour.Appearance.TerrainLayout };
			List<Trait> traits = new List<Trait> { Trait.EatsWarrens };

			CardInfo myCard = CardManager.New("mag", "mag_tarflamespell", "Engulf", 0, 1, "Set the whole battle ablaze, and watch it burn.")

					.SetPortrait(Tools.getImage("spell of flame.png"))
					.AddAbilities(SigilCode.Engulf.ability)
					.AddTraits(traits[0])
					.SetBloodCost(0)
					
					.AddAppearances(appearanceBehaviours[0]);
			myCard.SetExtendedProperty("TargetedSpell", true);
			myCard.SetExtendedProperty("TargetAllSpell", false);
			myCard.SetExtendedProperty("ManaCost", true);
			myCard.metaCategories = list;
		}
		public static void AddMagnusspell()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { Plugin.SpellPool };
			List<CardAppearanceBehaviour.Appearance> appearanceBehaviours = new List<CardAppearanceBehaviour.Appearance> { CardAppearanceBehaviour.Appearance.TerrainLayout };

			List<Trait> traits = new List<Trait> { Trait.Gem, Trait.EatsWarrens };

			List<Texture> list4 = new List<Texture>();

			List<Ability> list5 = new List<Ability>();
			list5.Add(Ability.GainGemGreen);
			list5.Add(Ability.GainGemOrange);
			list5.Add(Ability.GainGemBlue);

			CardInfo myCard = CardManager.New("mag", "mag_magnusspell", "Ethereal Gems", 0, 1, "A frail spirit of a late magnus mox.. Only sustains for a turn.")

					.SetPortrait(Tools.getImage("spell of magnus mox.png"))
					.AddAbilities(SigilCode.MagGainGemTriple.ability)
					.AddTraits(traits[0], traits[1])
					.SetBloodCost(0)
					
					.AddAppearances(appearanceBehaviours[0]);
			myCard.SetExtendedProperty("ManaCost", true);
			myCard.SetExtendedProperty("PhysicalSpell", true);
			myCard.metaCategories = list;
		}

		public static void AddVaseofgreed()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { Plugin.SpellPool };
			List<CardAppearanceBehaviour.Appearance> appearanceBehaviours = new List<CardAppearanceBehaviour.Appearance> { CardAppearanceBehaviour.Appearance.TerrainLayout };

			List<Trait> traits = new List<Trait> { Trait.EatsWarrens };
			List<Texture> list4 = new List<Texture>();

			List<Ability> list5 = new List<Ability>();
			list5.Add(SigilCode.VaseofGreed.ability);

			CardInfo myCard = CardManager.New("mag", "mag_vaseofgreed", "Vase of Greed", 0, 1, "The vase of greed.. Look at its smug face..")

					.SetPortrait(Tools.getImage("vase of greed.png"))
					.AddAbilities(list5[0])
					.AddTraits(traits[0])
					.SetBloodCost(0)
					
					.AddAppearances(appearanceBehaviours[0]);

            myCard.SetExtendedProperty("TargetedSpell", true);
            myCard.SetExtendedProperty("TargetAllSpell", false);
            myCard.SetExtendedProperty("ManaCost", true);
			myCard.metaCategories = list;
		}

		public static void AddTrasmogification()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { Plugin.SpellPool };
			List<CardAppearanceBehaviour.Appearance> appearanceBehaviours = new List<CardAppearanceBehaviour.Appearance> { CardAppearanceBehaviour.Appearance.TerrainLayout };

			List<Trait> traits = new List<Trait> { Trait.EatsWarrens };
			List<Texture> list4 = new List<Texture>();

			List<Ability> list5 = new List<Ability>();
			list5.Add(SigilCode.GnomeSpell.ability);

			CardInfo myCard = CardManager.New("mag", "mag_gnomespell", "Gnomification", 0, 1, "Conjure a plain old garden gnome on the board..")

					.SetPortrait(Tools.getImage("trasmogification spell.png"))
					.SetPixelPortrait(Tools.getSprite("pixelportrait_gnome.png"))
					.AddAbilities(list5[0])
					.AddTraits(traits[0])
					.SetBloodCost(0)
					
					.AddAppearances(appearanceBehaviours[0]);
			myCard.SetExtendedProperty("TargetedSpell", true);
			myCard.SetExtendedProperty("TargetAllSpell", true);
			myCard.SetExtendedProperty("ManaCost", true);
			myCard.metaCategories = list;
		}

		public static void AddCursedSkull()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { Plugin.SpellPool };
			List<CardAppearanceBehaviour.Appearance> appearanceBehaviours = new List<CardAppearanceBehaviour.Appearance> { CardAppearanceBehaviour.Appearance.TerrainLayout };

			List<Trait> traits = new List<Trait> { Trait.EatsWarrens };


			CardInfo myCard = CardManager.New("mag", "mag_cursedskull", "Cursed Skull", 0, 1, "Hmm, a cursed skull. Handle it with care.")

					.SetPortrait(Tools.getImage("cursed skull.png"))
					.AddAbilities(Ability.ExplodeOnDeath)
					.AddTraits(traits[0])
					.SetBloodCost(0)
					
					.AddAppearances(appearanceBehaviours[0]);
			myCard.SetExtendedProperty("ManaCost", true);
			myCard.metaCategories = list;
		}
		
		public static void AddOrluSpell()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { Plugin.SpellPool };
			List<CardAppearanceBehaviour.Appearance> appearanceBehaviours = new List<CardAppearanceBehaviour.Appearance> { CardAppearanceBehaviour.Appearance.TerrainLayout };
			List<Trait> traits = new List<Trait> { Trait.EatsWarrens };

			List<Ability> list5 = new List<Ability>();
			list5.Add(SigilCode.OrluInspiration.ability);

			CardInfo myCard = CardManager.New("mag", "mag_orluinspiration", "Inspiration", 0, 1, "A culmination of the great Master Orlu's essence.")

					.SetPortrait(Tools.getImage("spell_orlusinsperation.png"))
					.AddAbilities(list5[0])
					.AddTraits(traits[0])
					.SetBloodCost(0)
					
					.AddAppearances(appearanceBehaviours[0]);
			myCard.SetExtendedProperty("TargetedSpell", true);
			myCard.SetExtendedProperty("ManaCost", true);
			myCard.metaCategories = list;
		}

		public static void AddGoranjSpell()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { Plugin.SpellPool };
			List<CardAppearanceBehaviour.Appearance> appearanceBehaviours = new List<CardAppearanceBehaviour.Appearance> { CardAppearanceBehaviour.Appearance.TerrainLayout };
			List<Trait> traits = new List<Trait> { Trait.EatsWarrens };

			List<Ability> list5 = new List<Ability>();
			list5.Add(SigilCode.GoranjRage.ability);

			CardInfo myCard = CardManager.New("mag", "mag_goranjrage", "Rage", 0, 1, "The embodiement of the tenacious Master Goranj.")

					.SetPortrait(Tools.getImage("spell_goranjrage.png"))
					.AddAbilities(list5[0])
					.AddTraits(traits[0])
					.SetBloodCost(0)
					
					.AddAppearances(appearanceBehaviours[0]);
			myCard.SetExtendedProperty("TargetedSpell", true);
			myCard.SetExtendedProperty("TargetAllSpell", true);
			myCard.SetExtendedProperty("ManaCost", true);
			myCard.metaCategories = list;
		}

		public static void AddBleeneSpell()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { Plugin.SpellPool };
			List<CardAppearanceBehaviour.Appearance> appearanceBehaviours = new List<CardAppearanceBehaviour.Appearance> { CardAppearanceBehaviour.Appearance.TerrainLayout };
			List<Trait> traits = new List<Trait> { Trait.EatsWarrens };
			
			List<Ability> list5 = new List<Ability>();
			list5.Add(SigilCode.BleeneCalculus.ability);

			CardInfo myCard = CardManager.New("mag", "mag_bleenecalculus", "Calculus", 0, 1, "The spirit of the brave Master Bleene.")

					.SetPortrait(Tools.getImage("spell_bleenecalculus.png"))
					.AddAbilities(list5[0])
					.AddTraits(traits[0])
					.SetBloodCost(0)
					
					.AddAppearances(appearanceBehaviours[0]);
			myCard.SetExtendedProperty("TargetedSpell", true);
			myCard.SetExtendedProperty("TargetAllSpell", true);
			myCard.SetExtendedProperty("ManaCost", true);
			myCard.metaCategories = list;
		}

		public static void AddFireball()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { Plugin.SpellPool };
			List<CardAppearanceBehaviour.Appearance> appearanceBehaviours = new List<CardAppearanceBehaviour.Appearance> { CardAppearanceBehaviour.Appearance.TerrainLayout };
			List<Trait> traits = new List<Trait> { Trait.EatsWarrens };

			List<Ability> list5 = new List<Ability>();
			list5.Add(SigilCode.Fireball.ability);

			CardInfo myCard = CardManager.New("mag", "mag_fireball", "Fireball", 0, 1, "Conjure up a fireball, and shoot it towards your enemy.")

					.SetPortrait(Tools.getImage("fireball.png"))
					.AddAbilities(list5[0])
					.AddTraits(traits[0])
					.SetBloodCost(0)
					
					.AddAppearances(appearanceBehaviours[0]);
			myCard.SetExtendedProperty("TargetedSpell", true);
			myCard.SetExtendedProperty("TargetAllSpell", true);
			myCard.SetExtendedProperty("ManaCost", true);
			myCard.metaCategories = list;
		}

		public static void AddMushroomMage()
		{
            List<CardMetaCategory> list = new List<CardMetaCategory>();

			CardInfo myCard = CardManager.New("mag", "mag_mushroommage", "Amalgamage", 0, 0, "The ninth chamber.")

					.SetPortrait(Tools.getImage("mergeman.png"))
					.SetBloodCost(0);
            myCard.SetExtendedProperty("ManaCost", true);
            myCard.metaCategories = list;
        }

		public static void AddPotion()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> ();
			List<CardAppearanceBehaviour.Appearance> appearanceBehaviours = new List<CardAppearanceBehaviour.Appearance> { CardAppearanceBehaviour.Appearance.TerrainLayout };
			List<Trait> traits = new List<Trait> { Trait.EatsWarrens };

			List<Ability> list5 = new List<Ability>();

			CardInfo myCard = CardManager.New("mag", "mag_potion", "Potion", 0, 0, "Conjure up a fireball, and shoot it towards your enemy.")

					.SetPortrait(Tools.getImage("potion_green.png"))
					.AddTraits(traits[0])
					.SetBloodCost(0)
					.AddSpecialAbilities(Plugin.PotionStuff)
					.SetExtendedProperty("ManaCost", true)
					.AddAppearances(appearanceBehaviours[0]);
			myCard.SetExtendedProperty("TargetedSpell", true);
			myCard.SetExtendedProperty("TargetAllSpell", true);
			myCard.metaCategories = list;
		}

		public static void AddGnome()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			List<CardAppearanceBehaviour.Appearance> appearanceBehaviours = new List<CardAppearanceBehaviour.Appearance> { CardAppearanceBehaviour.Appearance.TerrainLayout };

			List<Trait> traits = new List<Trait> { };
			List<Texture> list4 = new List<Texture>();

			List<Ability> list5 = new List<Ability>();

			CardInfo myCard = CardManager.New("mag", "mag_gnome", "Gnome", 0, 1, "joem")
					.SetAffectedByTidalLock(true)
					.SetPortrait(Tools.getImage("gnome.png"));
			myCard.metaCategories = list;

			myCard.metaCategories = list;
		}

		public static void AddScubaGnome()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			List<CardAppearanceBehaviour.Appearance> appearanceBehaviours = new List<CardAppearanceBehaviour.Appearance> { CardAppearanceBehaviour.Appearance.TerrainLayout };

			List<Trait> traits = new List<Trait> { };
			List<Texture> list4 = new List<Texture>();

			List<Ability> list5 = new List<Ability>();

			CardInfo myCard = CardManager.New("mag", "mag_scubagnome", "Scuba Gnome", 0, 1, "Huber")
					.AddAbilities(Ability.Submerge)
					.SetPortrait(Tools.getImage("gnomesubmerge.png"));
			myCard.metaCategories = list;

			myCard.metaCategories = list;
		}
	}
}
