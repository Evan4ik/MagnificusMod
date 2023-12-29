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
			List<Trait> list2 = new List<Trait>();
			list2.Add(Trait.Gem);
			List<Ability> list3 = new List<Ability>();
			list3.Add(Ability.GainGemOrange);
			List<Tribe> list4 = new List<Tribe>();

			List<CardAppearanceBehaviour.Appearance> bg = new List<CardAppearanceBehaviour.Appearance> { CardAppearanceBehaviour.Appearance.TerrainBackground };


			string text = "mag_rubymox";
			string text2 = "Ruby Mox";
			int num = 0;
			int num2 = 1;
			List<CardMetaCategory> list6 = list;
			CardComplexity cardComplexity = CardComplexity.Simple;
			CardTemple cardTemple = CardTemple.Nature;
			string text3 = "";
			bool flag = false;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			List<GemType> list7 = null;

			CardInfo myCard = CardManager.New("mag", text, text2, num, num2, text3)

				.SetCost()
				.SetPortrait(Tools.getImage("red mox card.png"))
				.AddAbilities(list3[0])
				.AddAppearances(bg[0])
				.SetTraits(list2[0]);

			myCard.metaCategories = new List<CardMetaCategory>();
		}

		public static void AddEmeraldMox()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			List<Trait> list2 = new List<Trait>();
			list2.Add(Trait.Gem);
			List<Ability> list3 = new List<Ability>();
			list3.Add(Ability.GainGemGreen);
			List<Tribe> list4 = new List<Tribe>();

			List<CardAppearanceBehaviour.Appearance> bg = new List<CardAppearanceBehaviour.Appearance> { CardAppearanceBehaviour.Appearance.TerrainBackground };

			string text = "mag_greenmox";
			string text2 = "Emerald Mox";
			int num = 0;
			int num2 = 1;
			List<CardMetaCategory> list6 = list;
			CardComplexity cardComplexity = CardComplexity.Simple;
			CardTemple cardTemple = CardTemple.Nature;
			string text3 = "";
			bool flag = false;
			int num3 = 0;
			int num4 = 0;

			CardInfo myCard = CardManager.New("mag", text, text2, num, num2, text3)

				.SetCost()
				.SetPortrait(Tools.getImage("green mox card.png"))
				.AddAbilities(list3[0])
				.AddAppearances(bg[0])
				.SetTraits(list2[0]);
			myCard.metaCategories = new List<CardMetaCategory>();
		}

		public static void AddSapphireMox()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			List<Trait> list2 = new List<Trait>();
			list2.Add(Trait.Gem);
			List<Ability> list3 = new List<Ability>();
			list3.Add(Ability.GainGemBlue);
			List<Tribe> list4 = new List<Tribe>();

			List<CardAppearanceBehaviour.Appearance> bg = new List<CardAppearanceBehaviour.Appearance> { CardAppearanceBehaviour.Appearance.TerrainBackground };

			string text = "mag_bluemox";
			string text2 = "Sapphire Mox";
			int num = 0;
			int num2 = 1;
			List<CardMetaCategory> list6 = list;
			CardComplexity cardComplexity = CardComplexity.Simple;
			CardTemple cardTemple = CardTemple.Nature;
			string text3 = "";
			bool flag = false;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			List<GemType> list7 = null;
			SpecialStatIcon specialStatIcon = SpecialStatIcon.None;

			CardInfo myCard = CardManager.New("mag", text, text2, num, num2, text3)

				.SetCost()
				.SetPortrait(Tools.getImage("blue mox card.png"))
				.AddAbilities(list3[0])
				.AddAppearances(bg[0])
				.SetTraits(list2[0]);
			myCard.metaCategories = new List<CardMetaCategory>();
		}

		public static void AddSpearCard()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			List<Trait> list2 = new List<Trait>();
			list2.Add(Trait.Terrain);
			List<CardAppearanceBehaviour.Appearance> list3 = new List<CardAppearanceBehaviour.Appearance>();
			list3.Add(CardAppearanceBehaviour.Appearance.TerrainBackground);
			List<Ability> list4 = new List<Ability>();
			list4.Add(Ability.Sharp);

			string text = "mag_spear";
			string text2 = "Spear";
			int num = 0;
			int num2 = 3;
			List<CardMetaCategory> list5 = list;
			CardComplexity cardComplexity = CardComplexity.Simple;
			CardTemple cardTemple = CardTemple.Nature;
			string text3 = "";
			bool flag = false;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			List<GemType> list6 = null;
			SpecialStatIcon specialStatIcon = SpecialStatIcon.None;
			List<Tribe> list7 = null;

			CardInfo myCard = CardManager.New("mag", text, text2, num, num2, text3)

				.SetCost()
				.SetPortrait(Tools.getImage("mag_spear.png"))
				.AddAbilities(list4[0])
				.AddAppearances(list3[0])
				.SetTraits(list2[0]);
			myCard.metaCategories = new List<CardMetaCategory>();
		}

		public static void AddMagePupil()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			list.Add(CardMetaCategory.ChoiceNode);
			List<Ability> list2 = new List<Ability>();
			list2.Add(Ability.GemDependant);
			Texture2D image = Tools.getImage("PupilEmmission.png");
			CardInfo myCard = CardManager.New("mag", "mag_magepupil", "Mage Pupil", 1, 1, "Though weak, it can always be useful in the right situation.")
				.SetCost()
				.SetPixelPortrait(Tools.convertToSprite(Resources.Load("art/gbc/cards/pixelportraits/pixelportrait_pupil") as Texture2D))
				.SetPortrait(Tools.getImage("magepupil.png"), image)
				.AddAbilities(list2[0])
				.AddMetaCategories(list[0]);

			myCard.temple = CardTemple.Wizard;
		}

		public static void AddJrSage()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			list.Add(CardMetaCategory.ChoiceNode);
			List<GemType> list2 = new List<GemType>();
			list2.Add(GemType.Green);
			List<Texture> list3 = new List<Texture>();
			Texture2D texture2D = Tools.getImage("green mox.png");
			list3.Add(texture2D);
			Texture2D image = Tools.getImage("JuniorSageEmmission.png");
			string text = "mag_jrsage";
			string text2 = "Junior Sage";
			int num = 1;
			int num2 = 2;
			string text3 = "Although simple, it can prove itself to be useful.";
			List<Texture> list13 = list3;
			CardInfo myCard = CardManager.New("mag", text, text2, num, num2, text3)
					.SetCost(bloodCost: 0, gemsCost: list2)
					.SetPortrait(Tools.getImage("juniorsage.png"), image)
					.SetPixelPortrait(Tools.convertToSprite(Resources.Load("art/gbc/cards/pixelportraits/pixelportrait_juniorsage") as Texture2D))
					.SetEvolve("mag_srsage", 1)
					.AddMetaCategories(list[0]);
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddMuscleMage()
		{
			List<CardMetaCategory> metaCategories = new List<CardMetaCategory>
			{
				CardMetaCategory.ChoiceNode
			};
			List<GemType> list = new List<GemType>
			{
				GemType.Green
			};
			CardInfo myCard = CardManager.New("mag", "mag_musclemage", "Muscle Mage", 1, 1, "The result of drinking too many potions of the alchemist..")
					.SetPixelPortrait(Tools.convertToSprite(Resources.Load("art/gbc/cards/pixelportraits/pixelportrait_musclemage") as Texture2D))
					.SetCost(gemsCost: new List<GemType> { GemType.Green })
					.SetPortrait(Tools.getImage("musclemage.png"))
					.AddAbilities(Ability.GainAttackOnKill)
					.AddMetaCategories(metaCategories[0]);
		}

		public static void AddGreenMage()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			list.Add(CardMetaCategory.ChoiceNode);

			List<Ability> list2 = new List<Ability>();
			List<GemType> list3 = new List<GemType>();
			list3.Add(GemType.Green);
			List<Texture> list4 = new List<Texture>();

			Texture2D image = Tools.getImage("GreenMageEmmission.png");
			string text = "mag_greenmage";
			string text2 = "Green Mage";
			int num = 0;
			int num2 = 2;
			List<CardMetaCategory> list6 = list;
			CardComplexity cardComplexity = CardComplexity.Simple;
			CardTemple cardTemple = CardTemple.Nature;
			string text3 = "It draws power from the mana of the mox on the board.";
			bool flag = false;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			List<GemType> list7 = list3;

			CardInfo myCard = CardManager.New("mag", text, text2, num, num2, text3)
					.SetPixelPortrait(Tools.convertToSprite(Resources.Load("art/gbc/cards/pixelportraits/pixelportrait_greenmage") as Texture2D))
					.SetCost(bloodCost: 0, gemsCost: list3)
					.SetPortrait(Tools.getImage("green mage.png"), image)
					.AddSpecialAbilities(SigilCode.HealthForAnts.FullSpecial.Id)
					.AddMetaCategories(list[0]);
			myCard.specialStatIcon = SigilCode.HealthForAnts.FullStatIcon.Id;

			myCard.temple = CardTemple.Wizard;
		}

		public static void AddBlueMage()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			list.Add(CardMetaCategory.ChoiceNode);

			List<GemType> list2 = new List<GemType>();
			list2.Add(GemType.Blue);
			List<Ability> list3 = new List<Ability>();
			list3.Add(SigilCode.BlueMageDraw.ability);

			CardInfo myCard = CardManager.New("mag", "mag_bluemage", "Blue Mage", 0, 2, "Never doubt its utility.")
					.SetPixelPortrait(Tools.convertToSprite(Resources.Load("art/gbc/cards/pixelportraits/pixelportrait_bluemage") as Texture2D))
					.SetCost(bloodCost: 0, gemsCost: list2)
					.SetPortrait(Tools.getImage("BlueMage.png"))
					.AddAbilities(list3[0])
					.AddMetaCategories(list[0]);

			myCard.temple = CardTemple.Wizard;
		}

		public static void AddBlueSporeMage()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();

			List<CardAppearanceBehaviour.Appearance> list2 = new List<CardAppearanceBehaviour.Appearance>();
			list2.Add(CardAppearanceBehaviour.Appearance.RareCardBackground);
			List<GemType> list3 = new List<GemType>();
			list3.Add(GemType.Blue);
			List<Ability> list4 = new List<Ability>();
			list4.Add(SigilCode.BlueMageDraw.ability);
			list4.Add(SigilCode.BlueMageDraw.ability);

			Texture2D image = Tools.getImage("BlueMageFusedEmmission.png");
			string text = "mag_sporebluemage";
			string text2 = "Blue SporeMage";
			int num = 0;
			int num2 = 2;
			List<CardMetaCategory> list6 = list;
			CardComplexity cardComplexity = CardComplexity.Simple;
			CardTemple cardTemple = CardTemple.Nature;
			string text3 = "Some say it is a failed experiment, others say the opposite";
			bool flag = false;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			List<GemType> list7 = list3;
			SpecialStatIcon specialStatIcon = SpecialStatIcon.None;
			List<Tribe> list8 = null;
			List<Trait> list9 = null;
			List<SpecialTriggeredAbility> list10 = null;

			CardInfo myCard = CardManager.New("mag", text, text2, num, num2, text3)

						.SetCost(bloodCost: 0, gemsCost: list3)
						.SetPortrait(Tools.getImage("BlueMageFused.png"), image)
						.AddAbilities(list4[0], list4[1])
						.SetRare();
			myCard.metaCategories = list;

		}

		public static void AddForceMage()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			list.Add(CardMetaCategory.ChoiceNode);

			List<GemType> list2 = new List<GemType>();
			list2.Add(GemType.Blue);
			List<Ability> list3 = new List<Ability>();
			list3.Add(Ability.PreventAttack);
			List<Trait> list4 = new List<Trait>();
			list4.Add(Trait.Fused);

			Texture2D image = Tools.getImage("ForceMageEmmission.png");
			string text = "mag_forcemage";
			string text2 = "Force Mage";
			int num = 0;
			int num2 = 1;
			List<CardMetaCategory> list6 = list;
			CardComplexity cardComplexity = CardComplexity.Simple;
			CardTemple cardTemple = CardTemple.Nature;
			string text3 = "Virtually nothing can hit it.";
			bool flag = false;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			List<GemType> list7 = list2;
			SpecialStatIcon specialStatIcon = SpecialStatIcon.None;
			List<Tribe> list8 = null;

			CardInfo myCard = CardManager.New("mag", text, text2, num, num2, text3)
					.SetPixelPortrait(Tools.convertToSprite(Resources.Load("art/gbc/cards/pixelportraits/pixelportrait_forcemage") as Texture2D))
					.SetCost(bloodCost: 0, gemsCost: list2)
					.SetPortrait(Tools.getImage("ForceMage.png"), image)
					.AddAbilities(list3[0])
					.AddMetaCategories(list[0]);
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddGemFiend()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			list.Add(CardMetaCategory.ChoiceNode);

			List<GemType> list2 = new List<GemType>();
			list2.Add(GemType.Blue);
			List<Ability> list3 = new List<Ability>();
			list3.Add(Ability.GemDependant);

			Texture2D image = Tools.getImage("GemFeindEmmission.png");
			string text = "mag_gemfiend";
			string text2 = "Gem Fiend";
			int num = 3;
			int num2 = 1;
			List<CardMetaCategory> list5 = list;
			CardComplexity cardComplexity = CardComplexity.Simple;
			CardTemple cardTemple = CardTemple.Nature;
			string text3 = "A terrible beast of gems. It can tear through anything.";
			bool flag = false;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			List<GemType> list6 = list2;
			SpecialStatIcon specialStatIcon = SpecialStatIcon.None;
			List<Tribe> list7 = null;
			List<Trait> list8 = null;

			CardInfo myCard = CardManager.New("mag", text, text2, num, num2, text3)
					.SetPixelPortrait(Tools.convertToSprite(Resources.Load("art/gbc/cards/pixelportraits/pixelportrait_gemfiend") as Texture2D))
					.SetCost(bloodCost: 0, gemsCost: list2)
					.SetPortrait(Tools.getImage("GemFeind.png"), image)
					.AddAbilities(list3[0])
					.AddMetaCategories(list[0]);
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddHoverMage()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			list.Add(CardMetaCategory.ChoiceNode);

			List<GemType> list2 = new List<GemType>();
			list2.Add(GemType.Blue);
			List<Ability> list3 = new List<Ability>();
			list3.Add(Ability.Flying);

			Texture2D image = Tools.getImage("FlyingMageEmmission.png");
			string text = "mag_hovermage";
			string text2 = "Hover Mage";
			int num = 2;
			int num2 = 1;
			List<CardMetaCategory> list5 = list;
			CardComplexity cardComplexity = CardComplexity.Simple;
			CardTemple cardTemple = CardTemple.Nature;
			string text3 = "Using its spells it soars high to hit directly.";
			bool flag = false;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			List<GemType> list6 = list2;
			SpecialStatIcon specialStatIcon = SpecialStatIcon.None;
			List<Tribe> list7 = null;

			CardInfo myCard = CardManager.New("mag", text, text2, num2, num, text3)
					.SetPixelPortrait(Tools.convertToSprite(Resources.Load("art/gbc/cards/pixelportraits/pixelportrait_flyingmage") as Texture2D))
					.SetCost(bloodCost: 0, gemsCost: list2)
					.SetPortrait(Tools.getImage("FlyingMage.png"), image)
					.AddAbilities(list3[0])
					.AddMetaCategories(list[0]);
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddKnightMage()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			list.Add(CardMetaCategory.ChoiceNode);

			List<GemType> list2 = new List<GemType>();
			list2.Add(GemType.Orange);
			List<Ability> list3 = new List<Ability>();
			list3.Add(Ability.GemDependant);

			Texture2D image = Tools.getImage("KnightMageEmmission.png");
			string text = "mag_knightmage";
			string text2 = "Mage Knight";
			int num = 1;
			int num2 = 4;
			List<CardMetaCategory> list5 = list;
			CardComplexity cardComplexity = CardComplexity.Simple;
			CardTemple cardTemple = CardTemple.Nature;
			string text3 = "The tower Knight Mage, a good defense.";
			bool flag = false;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			List<GemType> list6 = list2;
			SpecialStatIcon specialStatIcon = SpecialStatIcon.None;

			CardInfo myCard = CardManager.New("mag", text, text2, num, num2, text3)
				.SetPixelPortrait(Tools.convertToSprite(Resources.Load("art/gbc/cards/pixelportraits/pixelportrait_mageknight") as Texture2D))
					.SetCost(bloodCost: 0, gemsCost: list2)
					.SetPortrait(Tools.getImage("KnightMage.png"), image)
					.AddAbilities(list3[0])
					.AddMetaCategories(list[0]);
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddOrangeMage()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			list.Add(CardMetaCategory.ChoiceNode);

			List<GemType> list2 = new List<GemType>();
			list2.Add(GemType.Orange);
			List<Ability> list3 = new List<Ability>();
			list3.Add(Ability.BuffGems);

			Texture2D image = Tools.getImage("OrangeMageEmmission.png");
			string text = "mag_orangemage";
			string text2 = "Orange Mage";
			int num = 0;
			int num2 = 2;
			List<CardMetaCategory> list5 = list;
			CardComplexity cardComplexity = CardComplexity.Simple;
			CardTemple cardTemple = CardTemple.Nature;
			string text3 = "Using its spells, it boosts the damage of all Gems.";
			bool flag = false;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			List<GemType> list6 = list2;
			SpecialStatIcon specialStatIcon = SpecialStatIcon.None;

			CardInfo myCard = CardManager.New("mag", text, text2, num, num2, text3)
				.SetPixelPortrait(Tools.convertToSprite(Resources.Load("art/gbc/cards/pixelportraits/pixelportrait_orangemage") as Texture2D))
					.SetCost(bloodCost: 0, gemsCost: list2)
					.SetPortrait(Tools.getImage("OrangeMage.png"), image)
					.AddAbilities(list3[0])
					.AddMetaCategories(list[0]);
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddPracticeMage()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			list.Add(CardMetaCategory.ChoiceNode);

			List<GemType> list2 = new List<GemType>();
			list2.Add(GemType.Orange);
			List<Ability> list3 = new List<Ability>();
			list3.Add(Ability.Reach);

			Texture2D image = Tools.getImage("PracticeMageEmmission.png");
			string text = "mag_practicemage";
			string text2 = "Practice Mage";
			int num = 0;
			int num2 = 3;
			List<CardMetaCategory> list5 = list;
			CardComplexity cardComplexity = CardComplexity.Simple;
			CardTemple cardTemple = CardTemple.Nature;
			string text3 = "It stands tall enough to block any target.";
			bool flag = false;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			List<GemType> list6 = list2;
			SpecialStatIcon specialStatIcon = SpecialStatIcon.None;
			List<Tribe> list7 = null;
			List<Trait> list8 = null;

			CardInfo myCard = CardManager.New("mag", text, text2, num, num2, text3)

					.SetCost(bloodCost: 0, gemsCost: list2)
					.SetPortrait(Tools.getImage("PracticeMage.png"), image)
					.AddAbilities(list3[0])
					.AddMetaCategories(list[0]);
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddRubyGolem()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			list.Add(CardMetaCategory.ChoiceNode);

			List<GemType> list2 = new List<GemType>();
			list2.Add(GemType.Orange);
			List<Ability> list3 = new List<Ability>();
			list3.Add(SigilCode.MagDropRubyOnDeath.ability);

			Texture2D image = Tools.getImage("RubyGolemEmmission.png");
			string text = "mag_rubygolem";
			string text2 = "Ruby Golem";
			int num = 2;
			int num2 = 1;
			List<CardMetaCategory> list5 = list;
			CardComplexity cardComplexity = CardComplexity.Simple;
			CardTemple cardTemple = CardTemple.Nature;
			string text3 = "A construct powered by Mox. As it perishes it leaves behind parts of itself.";
			bool flag = false;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			List<GemType> list6 = list2;
			SpecialStatIcon specialStatIcon = SpecialStatIcon.None;
			List<Tribe> list7 = null;
			List<Trait> list8 = null;
			List<SpecialTriggeredAbility> list9 = null;

			CardInfo myCard = CardManager.New("mag", text, text2, num, num2, text3)
					.SetPixelPortrait(Tools.convertToSprite(Resources.Load("art/gbc/cards/pixelportraits/pixelportrait_rubygolem") as Texture2D))
					.SetCost(bloodCost: 0, gemsCost: list2)
					.SetPortrait(Tools.getImage("RubyGolem.png"), image)
					.AddAbilities(list3[0])
					.AddMetaCategories(list[0]);

			myCard.temple = CardTemple.Wizard;
		}

		public static void AddUrayuliWizard()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			list.Add(CardMetaCategory.Rare);
			List<CardAppearanceBehaviour.Appearance> list2 = new List<CardAppearanceBehaviour.Appearance>();
			list2.Add(CardAppearanceBehaviour.Appearance.RareCardBackground);
			List<GemType> list3 = new List<GemType>();
			list3.Add(GemType.Green);
			list3.Add(GemType.Orange);
			list3.Add(GemType.Blue);

			string text = "mag_wizardurayuli";
			string text2 = "Urayuli";
			int num = 7;
			int num2 = 7;
			List<CardMetaCategory> list5 = list;
			CardComplexity cardComplexity = CardComplexity.Simple;
			CardTemple cardTemple = CardTemple.Nature;
			string text3 = "I would fear it only if it could fly.";
			bool flag = false;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			List<GemType> list6 = list3;
			SpecialStatIcon specialStatIcon = SpecialStatIcon.None;
			List<Tribe> list7 = null;
			List<Trait> list8 = null;
			List<SpecialTriggeredAbility> list9 = null;
			List<Ability> list10 = null;
			EvolveParams evolveParams = null;
			string text4 = null;
			TailParams tailParams = null;
			IceCubeParams iceCubeParams = null;
			bool flag2 = false;
			bool flag3 = false;

			CardInfo myCard = CardManager.New("mag", text, text2, num, num2, text3)

						.SetCost(bloodCost: 0, gemsCost: list3)
						.SetPortrait(Tools.getImage("urayuli wizard.png"))
						//.AddAbilities(list3[0])
						.AddMetaCategories(list[0])
						.SetRare();
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddCandleSquid()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			list.Add(CardMetaCategory.ChoiceNode);

			List<GemType> list2 = new List<GemType>();
			list2.Add(GemType.Blue);
			List<Ability> list3 = new List<Ability>();
			list3.Add(Ability.GemDependant);

			string text = "mag_squidcandle";
			string text2 = "--~~--~~--";
			int num = 0;
			int num2 = 2;
			List<CardMetaCategory> list6 = list;
			CardComplexity cardComplexity = CardComplexity.Simple;
			CardTemple cardTemple = CardTemple.Nature;
			string text3 = "I foresaw its arrival.";
			bool flag = false;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			Texture2D texture2D3 = Tools.getImage("squid_title.png");
			CardInfo myCard = CardManager.New("mag", text, text2, num, num2, text3)

						.SetCost(bloodCost: 0, gemsCost: list2)
						.SetPortrait(Tools.getImage("squid_candle.png"))
						.AddSpecialAbilities(SigilCode.CandleSquid.FullSpecial.Id)
						.AddMetaCategories(list[0]);
			myCard.specialStatIcon = SigilCode.CandleSquid.FullStatIcon.Id;
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddBoneSquid()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			list.Add(CardMetaCategory.ChoiceNode);

			List<GemType> list2 = new List<GemType>();
			list2.Add(GemType.Green);
			List<Ability> list3 = new List<Ability>();
			list3.Add(Ability.GemDependant);

			Texture2D texture2D3 = Tools.getImage("squid_title.png");
			string text = "mag_bonesquid";
			string text2 = "--~~--~~--";
			int num = 0;
			int num2 = 3;
			List<CardMetaCategory> list6 = list;
			CardComplexity cardComplexity = CardComplexity.Simple;
			CardTemple cardTemple = CardTemple.Nature;
			string text3 = "Another here.";
			bool flag = false;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;

			CardInfo myCard = CardManager.New("mag", text, text2, num, num2, text3)

							.SetCost(bloodCost: 0, gemsCost: list2)
							.SetPortrait(Tools.getImage("squid_bones.png"))
							.AddMetaCategories(list[0]);
			myCard.specialStatIcon = SpecialStatIcon.Bones;
			myCard.temple = CardTemple.Wizard;
		}
		public static void AddMagnusMox()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			List<Trait> list2 = new List<Trait>();
			list2.Add(Trait.Gem);
			List<Tribe> tribes = new List<Tribe>();
			List<Ability> list3 = new List<Ability>();
			list3.Add(Ability.GainGemBlue);
			list3.Add(Ability.GainGemGreen);
			list3.Add(Ability.GainGemOrange);



			string text = "mag_BOSSmagnusmox";
			string text2 = "Magnus Mox";
			int num = 0;
			int num2 = 9;
			List<CardMetaCategory> list5 = list;

			CardInfo myCard = CardManager.New("mag", text, text2, num, num2, "almondus")

					.SetCost()
					.SetPortrait(Tools.getImage("Mox Triple.png"))
					.AddAbilities(list3[0], list3[1], list3[2])
					.AddMetaCategories()
					.AddTraits(list2[0]);
			myCard.metaCategories = new List<CardMetaCategory>();
		}


		public static void ChangeWolf()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { CardMetaCategory.ChoiceNode };
			List<Ability> list2 = new List<Ability>();
			list2.Add(SigilCode.FamiliarA.ability);

			List<GemType> gemCost = new List<GemType> { GemType.Orange };
			CardInfo myCard = CardManager.New("mag", "mag_wolf", "Wolf Familiar", 2, 2, "It rips into its enemies with little to no remorse.")
					.SetPixelPortrait(Tools.getImage("mag_wizwolf_pixel.png"))
					.SetPortrait(Tools.getImage("mag_wizwolf.png"))
					.SetCost(bloodCost: 0, gemsCost: gemCost)
					.AddAbilities(list2[0]);
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
			List<CardMetaCategory> list = new List<CardMetaCategory> { CardMetaCategory.ChoiceNode };
			List<Ability> list2 = new List<Ability>();
			list2.Add(Ability.GainGemOrange);

			List<GemType> gemCost = new List<GemType> { GemType.Orange };
			CardInfo myCard = CardManager.New("mag", "mag_crystalworm", "Crystal Worm", 0, 3, "Its body is made out of pure mox.")
					.SetPortrait(Tools.getImage("GemWorm.png"))
					.SetPixelPortrait(Tools.getSprite("pixelportrait_gemworm.png"))
					.SetCost(bloodCost: 0, gemsCost: gemCost)
					.AddAbilities(list2[0]);
			myCard.metaCategories = list;
			myCard.traits.Add(Trait.Gem);
			myCard.temple = CardTemple.Wizard;
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



		public static void ChangeBullFrog()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { CardMetaCategory.ChoiceNode };
			List<Ability> list2 = new List<Ability> { SigilCode.FamiliarA.ability, Ability.GainGemBlue };

			List<GemType> gemCost = new List<GemType> { GemType.Blue };
			CardInfo myCard = CardManager.New("mag", "mag_bullfrog", "Gem Frog", 1, 3, "What seems to be a regular frog, taken over by the gem inside it's body. It's pain might prove useful in certain circumstances.")

					.SetPortrait(Tools.getImage("WizFrog.png"))
					.SetCost(bloodCost: 0, gemsCost: gemCost)
					.AddTraits(Trait.Gem)
					.AddAppearances(CardAppearanceBehaviour.Appearance.TerrainBackground)
					.AddAbilities(list2[0], list2[1]);
			myCard.temple = CardTemple.Wizard;
			myCard.metaCategories = list;
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
					.AddSpecialAbilities(MagMod.ManaTutorial)
					.SetCost(bloodCost: 1);
			myCard.SetExtendedProperty("ManaCost", true);
			myCard.metaCategories = list;
		}


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

		public static void ChangeGeck()
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
		}


		public static void ChangePackrat()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { CardMetaCategory.Rare };
			List<Ability> list2 = new List<Ability> { SigilCode.DrawSpell.ability };

			List<GemType> gemCost = new List<GemType> { GemType.Blue };
			CardInfo myCard = CardManager.New("mag", "mag_spellcaster", "Spellcaster", 1, 3, "It reads out spells from its book and casts them directly to your hand.")
					.AddAppearances(CardAppearanceBehaviour.Appearance.RareCardBackground)
					.SetPixelPortrait(Tools.getSprite("pixelportrait_spellcaster.png"))
					.SetPortrait(Tools.getImage("pack mage.png"))
					.SetCost(bloodCost: 0, gemsCost: gemCost)
					.AddAbilities(list2[0]);
			myCard.temple = CardTemple.Wizard;
			myCard.metaCategories = list;

		}



		public static void ChangeAmalgam()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { CardMetaCategory.Rare };
			List<Ability> list2 = new List<Ability> { SigilCode.RandomPower.ability };

			List<GemType> gemCost = new List<GemType> { GemType.Green, GemType.Orange };
			CardInfo myCard = CardManager.New("mag", "mag_amalgam", "Amalgam", 3, 3, "A failed experiment to achieve greatness.")
					.AddAppearances(CardAppearanceBehaviour.Appearance.RareCardBackground)
					.SetPortrait(Tools.getImage("amalgam wiz.png"))
					.SetCost(bloodCost: 0, gemsCost: gemCost)
					.AddAbilities(list2[0]);
			myCard.temple = CardTemple.Wizard;
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
			CardInfo myCard = CardManager.New("mag", "mag_auspex", "Auspex", 0, 2, "It harnesses the power of the stars for you..")

					.SetPortrait(Tools.getImage("auspex.png"))
					.SetCost(bloodCost: 0, gemsCost: gemCost)
					.AddAbilities(list2[0]);
			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
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
			CardInfo myCard = CardManager.New("mag", "mag_stimmachine", "Stimbot", 2, 1, "Powered by stimulation, and steam..")

					.SetPortrait(Tools.getImage("stim machine.png"))
					.SetCost(bloodCost: 0, gemsCost: gemCost)
					.AddAppearances(CardAppearanceBehaviour.Appearance.RareCardBackground)
					.AddAbilities(list2[0]);
			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddMagimorph()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { CardMetaCategory.ChoiceNode };
			List<Ability> list2 = new List<Ability>();
			list2.Add(Ability.RandomAbility);
			List<GemType> gemCost = new List<GemType> { GemType.Blue };
			CardInfo myCard = CardManager.New("mag", "mag_magimorph", "Magimorph", 1, 1, "Its gross gooey body warps and distorts into distant forms. It's wonderous if you look at it right.")
					.SetPixelPortrait(Tools.getImage("pixelportrait_magimorph.png"))
					.SetPortrait(Tools.getImage("magimorph.png"))
					.SetCost(bloodCost: 0, gemsCost: gemCost)
					.AddAbilities(list2[0]);
			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}

		[HarmonyPatch(typeof(RandomAbility), "AddMod")]
		public class AmorphousFix
		{
			public static bool Prefix(ref RandomAbility __instance)
			{
				if (SceneLoader.ActiveSceneName == "finale_magnificus")
                {
					__instance.Card.Status.hiddenAbilities.Add(__instance.Ability);
					List<Ability> learnedAbilities = AbilitiesUtil.GetLearnedAbilities(false, 0, 5, AbilityMetaCategory.MagnificusRulebook);
					var instance = __instance;
					List<Ability> bannedAbilites = new List<Ability> { Ability.EdaxioArms, Ability.EdaxioHead, Ability.EdaxioLegs, Ability.EdaxioTorso, Ability.VirtualReality, Ability.GainGemBlue, Ability.GainGemGreen, Ability.GainGemOrange, Ability.DropRubyOnDeath, Ability.GemsDraw };
					if (__instance.Card.Info.HasTrait(Trait.EatsWarrens)) { bannedAbilites.Add(Ability.Tutor); }
					learnedAbilities.RemoveAll((Ability x) => x == Ability.RandomAbility || instance.Card.HasAbility(x) || bannedAbilites.Contains(x));
					Ability result = Ability.Sharp;
					if (learnedAbilities.Count > 0)
					{
						result = learnedAbilities[SeededRandom.Range(0, learnedAbilities.Count, Environment.TickCount)];
					}
					CardModificationInfo cardModificationInfo = new CardModificationInfo(result);
					CardModificationInfo cardModificationInfo2 = __instance.Card.TemporaryMods.Find((CardModificationInfo x) => x.HasAbility(instance.Ability));
					if (cardModificationInfo2 == null)
					{
						cardModificationInfo2 = __instance.Card.Info.Mods.Find((CardModificationInfo x) => x.HasAbility(instance.Ability));
					}
					if (cardModificationInfo2 != null)
					{
						cardModificationInfo.fromTotem = cardModificationInfo2.fromTotem;
						cardModificationInfo.fromCardMerge = cardModificationInfo2.fromCardMerge;
					}
					__instance.Card.AddTemporaryMod(cardModificationInfo);
					return false;
				}
				return true;
			}
		}

		public static void AddPerformer()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { CardMetaCategory.ChoiceNode };
			List<Ability> list2 = new List<Ability>();
			list2.Add(Ability.DrawRabbits);
			List<GemType> gemCost = new List<GemType> { GemType.Blue };
			CardInfo myCard = CardManager.New("mag", "mag_bunnymage", "Performer", 1, 1, "Watch it create a rabbit out of its wand..")

					.SetPortrait(Tools.getImage("bnuymage.png"))
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
			CardInfo myCard = CardManager.New("mag", "mag_srsage", "Senior Sage", 2, 2, "A Junior Sage that has mastered the art of Magicks.")
					.AddAppearances(CardAppearanceBehaviour.Appearance.RareCardBackground)
					.SetPortrait(Tools.getImage("two wiz.png"))
					.SetCost(bloodCost: 0, gemsCost: gemCost)
					.AddAbilities(list2[0]);
			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddCoffeMage()
		{
			List<SpecialTriggeredAbility> specialAbilities = new List<SpecialTriggeredAbility> { MagMod.Romance };
			List<CardMetaCategory> list = new List<CardMetaCategory> { CardMetaCategory.ChoiceNode };
			List<Ability> list2 = new List<Ability>();
			list2.Add(SigilCode.NullifySigils.ability);
			List<GemType> gemCost = new List<GemType> { GemType.Orange, GemType.Orange };
			CardInfo myCard = CardManager.New("mag", "mag_coffeemage", "Coffee Mage", 2, 2, "She pours scalding hot coffee onto the enemy to make them numb..")

					.SetPortrait(Tools.getImage("coffeemage.png"))
					.AddSpecialAbilities(specialAbilities[0])
					.SetCost(bloodCost: 0, gemsCost: gemCost)
					.AddAbilities(list2[0]);
			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddTeaMage()
		{
			List<SpecialTriggeredAbility> specialAbilities = new List<SpecialTriggeredAbility> { MagMod.Romance };
			List<CardMetaCategory> list = new List<CardMetaCategory> { CardMetaCategory.ChoiceNode };
			List<Ability> list2 = new List<Ability>();
			list2.Add(SigilCode.DrawMoxFromSideDeck.ability);
			List<GemType> gemCost = new List<GemType> { GemType.Blue, GemType.Blue };
			CardInfo myCard = CardManager.New("mag", "mag_teamage", "Tea Mage", 0, 4, "She passively sits and draws out mox for you..")

					.SetPortrait(Tools.getImage("teamage.png"))
					.AddSpecialAbilities(specialAbilities[0])
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
			CardInfo myCard = CardManager.New("mag", "mag_sodamage", "Soda Mage", 1, 3, "This pathetic mage melted away from drinking too much carbonated water.")

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
			CardInfo myCard = CardManager.New("mag", "mag_whitesmith", "Whitesmith", 0, 5, "Their life's work was dedicated to reinforcing gems.")

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
			CardInfo myCard = CardManager.New("mag", "mag_puppeteer", "Puppeteer", 1, 2, "Its mastery of control magicks lets even Practice Mages contribute.")

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
					.SetCost(bloodCost: 1)
					.AddAbilities(list2[0]);
			myCard.SetExtendedProperty("ManaCost", true);
			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddValkyrie()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { CardMetaCategory.ChoiceNode };
			List<GemType> gemCost = new List<GemType> { GemType.Orange, GemType.Blue };
			CardInfo myCard = CardManager.New("mag", "mag_valkyrie", "Valkyrie", 3, 1, "A student that has trained under Master Orlu. It has become an expert in airborne magicks.")

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
			CardInfo myCard = CardManager.New("mag", "mag_rubyfiend", "Ruby Daemon", 2, 1, "It casts a multiplication spell, and hides out in your deck..")
					.SetPixelPortrait(Tools.getImage("rubyfiend_pixel.png"))
					.SetPortrait(Tools.getImage("rubyfiend.png"))
					.AddAbilities(Ability.Brittle, SigilCode.AddCardToDeck.ability)
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
					.AddAbilities(list2[0]);
			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddInvisibleMage()
		{
			List<CardAppearanceBehaviour.Appearance> cardAppearanceBehaviour = new List<CardAppearanceBehaviour.Appearance> { CardAppearanceBehaviour.Appearance.SexyGoat };
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			list.Add(CardMetaCategory.ChoiceNode);
			List<Ability> list2 = new List<Ability>();
			list2.Add(Ability.Submerge);
			string text = "mag_invisimage";
			string text2 = "Invisible Mage";
			int num = 2;
			int num2 = 1;
			string text3 = "It drank the wrong potion and ended up invisible. How clumsy.";
			CardInfo myCard = CardManager.New("mag", text, text2, num, num2, text3)

					.SetCost(bloodCost: 1)
					.SetPortrait(Tools.getImage("invisible mage.png"))
					.AddAbilities(list2[0])
					.AddAppearances(cardAppearanceBehaviour[0])
					.AddMetaCategories(list[0]);
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
			CardInfo myCard = CardManager.New("mag", "mag_gemboundripper", "Gembound Ripper", 4, 1, "It is unstable, but such is the price for unending power.")

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
			Sprite pixelTex = Tools.getSprite("gemabsorber_pixel.png");
			CardInfo myCard = CardManager.New("mag", "mag_gemabsorber", "Gem Absorber", 1, 1, "It seeks out to consume all mana within Mox to grow stronger.")

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
			CardInfo myCard = CardManager.New("mag", "mag_skelemage", "Skelemagus", 4, 1, "Its incredibly powerful, but not for long.")

							.SetCost(bloodCost: 1)
							.SetPortrait(Tools.getImage("mag_skelemagus.png"))
							.AddAbilities(list2[0], list2[1])
							.SetPixelPortrait(pixelTex)
							.AddSpecialAbilities(MagMod.ManaTutorial)
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
			CardInfo myCard = CardManager.New("mag", "mag_skelejrsage", "Skelesage", 2, 3, "One of my own Junior Sages, lost and revived.")

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
			CardInfo myCard = CardManager.New("mag", "mag_erraticscholar", "Erratic Scholar", 1, 1, "A panicked scholar.. Always running.")

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
			list.Add(CardMetaCategory.ChoiceNode);

			Sprite pixelTex = Tools.getSprite("pixelportrait_skeletonmage.png");
			CardInfo myCard = CardManager.New("mag", "mag_moxmage", "Mox Mage", 1, 2, "A Mox disguised as a mage.. It's not going to fool anyone.")

							.SetCost(bloodCost: 0)
							.SetBloodCost(bloodCost: 1)
							.AddTraits(Trait.Gem)
							.SetPortrait(Tools.getImage("moxmage.png"))
							.AddAppearances(CardAppearanceBehaviour.Appearance.TerrainBackground)
							.AddAbilities(Ability.GainGemOrange)
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
							.SetPortrait(Tools.getImage("maux.png"))
							.AddAppearances(CardAppearanceBehaviour.Appearance.TerrainBackground)
							.AddMetaCategories(list[0]);
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddStimMage()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			list.Add(CardMetaCategory.ChoiceNode);

			List<GemType> list2 = new List<GemType>();
			list2.Add(GemType.Green);
			List<Texture> list3 = new List<Texture>();
			List<Ability> list4 = new List<Ability>();
			list4.Add(SigilCode.Stimulation.ability);
			Texture2D image = Tools.getImage("StimMageEmmission.png");
			string text = "mag_stimmage";
			string text2 = "Stim Mage";
			int num = 0;
			int num2 = 2;
			List<CardMetaCategory> list5 = list;
			CardComplexity cardComplexity = CardComplexity.Simple;
			CardTemple cardTemple = CardTemple.Nature;
			string text3 = "It strives to grow stronger, at the cost of its own health";
			bool flag = false;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;

			CardInfo myCard = CardManager.New("mag", text, text2, num, num2, text3)
					.SetPixelPortrait(Tools.convertToSprite(Resources.Load("art/gbc/cards/pixelportraits/pixelportrait_stimmage") as Texture2D))
					.SetCost(bloodCost: 0, gemsCost: list2)
					.SetPortrait(Tools.getImage("StimMage.png"), image)
					.AddAbilities(list4[0])
					.AddMetaCategories(list[0]);
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddDunceMage()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			list.Add(CardMetaCategory.ChoiceNode);

			List<Ability> list2 = new List<Ability>();
			list2.Add(Ability.SplitStrike);
			List<GemType> list3 = new List<GemType>();
			list3.Add(GemType.Green);
			List<Texture> list4 = new List<Texture>();

			string text = "mag_duncemage";
			string text2 = "The Wiz";
			int num = 1;
			int num2 = 1;

			string text3 = "This one can never seem to hit its target..";

			CardInfo myCard = CardManager.New("mag", text, text2, num, num2, text3)

					.SetCost(bloodCost: 0, gemsCost: list3)
					.SetPortrait(Tools.getImage("the wiz.png"))
					.AddAbilities(list2[0])
					.AddMetaCategories(list[0]);
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddSwordSage()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			list.Add(CardMetaCategory.ChoiceNode);

			List<GemType> list2 = new List<GemType>();
			list2.Add(GemType.Green);
			List<Texture> list3 = new List<Texture>();
			List<Ability> list4 = new List<Ability>();
			list4.Add(Ability.Deathtouch);
			list4.Add(SigilCode.FamiliarA.ability);

			string text = "mag_sabesage";
			string text2 = "Grootslang";
			int num = 1;
			int num2 = 2;
			List<CardMetaCategory> list5 = list;
			CardComplexity cardComplexity = CardComplexity.Simple;
			CardTemple cardTemple = CardTemple.Nature;
			string text3 = "The mere graze of its fangs is enough to kill any creature. No matter the size.";

			CardInfo myCard = CardManager.New("mag", text, text2, num, num2, text3)

					.SetCost(bloodCost: 0, gemsCost: list2)
					.SetPortrait(Tools.getImage("SaberSage.png"))
					.AddAbilities(list4[0], list4[1])
					.AddMetaCategories(list[0]);
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
								.AddSpecialAbilities(MagMod.ManaTutorial)
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
								.AddSpecialAbilities(MagMod.ManaTutorial)
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
								.AddAbilities(list2[0])
								.AddMetaCategories(list[0]);
			myCard.temple = CardTemple.Wizard;
		}
		public static void AddRunes()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			List<Ability> list2 = new List<Ability>();
			list2.Add(Ability.ExplodeOnDeath);

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

			CardInfo myCard = CardManager.New("mag", "mag_greenmoxrabbit", "Rabbit", 0, 1, "This is the last call, for booze.")
								.SetCost(bloodCost: 0)
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
								.SetPortrait(Tools.getImage("moxrabbitorange.png"))
								.AddTraits(Trait.Gem)
								.AddAppearances(CardAppearanceBehaviour.Appearance.TerrainBackground)
								.AddAbilities(list2[0]);
			myCard.temple = CardTemple.Wizard;
			myCard.metaCategories = new List<CardMetaCategory>();
		}



		[HarmonyPatch(typeof(DrawRabbits), "CardToDraw", MethodType.Getter)]
		public class RabbitFix
		{
			public static bool Prefix(ref DrawRabbits __instance, ref CardInfo __result)
			{
				if (SceneLoader.ActiveSceneName != "finale_magnificus") { return true; }
				List<string> cardToGet = new List<string>();
				Plugin.MagCurrentNode.GetSideDeck();
				string text = File.ReadAllText(SaveManager.SaveFolderPath + "MagnificusModSave.gwsave");
				string[] array3 = text.Split('R');
				array3 = array3[1].Split(',');
				for (int j = 0; j < int.Parse(array3[0]); j++)
				{cardToGet.Add("mag_orangemoxrabbit");}
				for (int k = 0; k < int.Parse(array3[1]); k++)
				{cardToGet.Add("mag_greenmoxrabbit");}
				for (int l = 0; l < int.Parse(array3[2]); l++)
				{cardToGet.Add("mag_moxrabbit");}
				CardInfo cardByName = CardLoader.GetCardByName(cardToGet[UnityEngine.Random.RandomRangeInt(0, cardToGet.Count)]);
				cardByName.Mods.AddRange(__instance.GetNonDefaultModsFromSelf(new Ability[]
				{
				__instance.Ability
				}));
				__result = cardByName;
				return false;
			}
		}

		[HarmonyPatch(typeof(AbilityBehaviour), "GetNonDefaultModsFromSelf")]
		public class RabbitFix2
		{
			public static bool Prefix(ref AbilityBehaviour __instance, ref List<CardModificationInfo> __result, params Ability[] exclude)
			{
				if (SceneLoader.ActiveSceneName != "finale_magnificus") { return true; }
				List<Ability> abilities = __instance.Card.Info.Abilities;
				foreach (CardModificationInfo cardModificationInfo in __instance.Card.TemporaryMods)
				{
					abilities.AddRange(cardModificationInfo.abilities);
				}
				foreach (Ability item in __instance.Card.Info.DefaultAbilities)
				{
					abilities.Remove(item);
				}
				foreach (Ability item2 in exclude)
				{
					abilities.Remove(item2);
				}
				if (abilities.Count == 0)
				{
					__result = new List<CardModificationInfo>();
					return false;
				}
				CardModificationInfo cardModificationInfo2 = new CardModificationInfo();
				if (SceneLoader.ActiveSceneName != "finale_magnificus") { cardModificationInfo2.fromCardMerge = true; }
				cardModificationInfo2.abilities.AddRange(abilities);
				__result =  new List<CardModificationInfo>
				{
					cardModificationInfo2
				}; 
				return false;
			}
		}

		[HarmonyPatch(typeof(CreateCardsAdjacent), "ModifySpawnedCard")]
		public class AdjacentCardsFix
		{
			public static bool Prefix(ref CreateCardsAdjacent __instance, CardInfo card)
			{
				List<Ability> abilities = __instance.Card.Info.Abilities;
				var instance = __instance;
				foreach (CardModificationInfo cardModificationInfo in __instance.Card.TemporaryMods)
				{
					abilities.AddRange(cardModificationInfo.abilities);
				}
				abilities.RemoveAll((Ability x) => x == instance.Ability);
				if (abilities.Count > 4)
				{
					abilities.RemoveRange(3, abilities.Count - 4);
				}
				CardModificationInfo cardModificationInfo2 = new CardModificationInfo();
				if (SceneLoader.ActiveSceneName != "finale_magnificus") { cardModificationInfo2.fromCardMerge = true; }
				cardModificationInfo2.abilities = abilities;
				card.Mods.Add(cardModificationInfo2);
				return false;
			}
		}

		public static void AddMasterGO()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			list.Add(CardMetaCategory.Rare);
			List<GemType> list2 = new List<GemType>();
			list2.Add(GemType.Green);
			list2.Add(GemType.Orange);
			List<CardAppearanceBehaviour.Appearance> list3 = new List<CardAppearanceBehaviour.Appearance>();
			list3.Add(CardAppearanceBehaviour.Appearance.RareCardBackground);

			List<Ability> list5 = new List<Ability>();
			list5.Add(Ability.GemDependant);

			Texture2D image = Tools.getImage("MasterGOEmmission.png");
			string text = "mag_mastergo";
			string text2 = "Master Goranj";
			int num = 2;
			int num2 = 6;
			List<CardMetaCategory> list6 = list;
			CardComplexity cardComplexity = CardComplexity.Simple;
			CardTemple cardTemple = CardTemple.Nature;
			string text3 = "The towering Master Goranj. Not only a caster of fearsome Magicks, but possessed of a sturdy poise as well. ";
			bool flag = false;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			List<GemType> list7 = list2;

			CardInfo myCard = CardManager.New("mag", text, text2, num, num2, text3)

					.SetCost(bloodCost: 0, gemsCost: list2)
					.SetPortrait(Tools.getImage("MasterGO.png"))
					.AddAbilities(list5[0])
					.AddMetaCategories(list[0])
					.SetRare();
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddMasterBG()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			list.Add(CardMetaCategory.Rare);
			List<GemType> list2 = new List<GemType>();
			list2.Add(GemType.Blue);
			list2.Add(GemType.Green);
			List<CardAppearanceBehaviour.Appearance> list3 = new List<CardAppearanceBehaviour.Appearance>();
			list3.Add(CardAppearanceBehaviour.Appearance.RareCardBackground);

			List<Ability> list5 = new List<Ability>();
			list5.Add(SigilCode.BleeneDraw.ability);

			Texture2D image = Tools.getImage("MasterBGEmmission.png");
			string text = "mag_masterbg";
			string text2 = "Master Bleene";
			int num = 0;
			int num2 = 4;
			List<CardMetaCategory> list6 = list;
			CardComplexity cardComplexity = CardComplexity.Simple;
			CardTemple cardTemple = CardTemple.Nature;
			string text3 = "The selfless Master Bleene. It shall help you in times of dire need… At the cost of its own ability to defend itself. Admirable.";
			bool flag = false;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			List<GemType> list7 = list2;

			CardInfo myCard = CardManager.New("mag", text, text2, num, num2, text3)

					.SetCost(bloodCost: 0, gemsCost: list2)
					.SetPortrait(Tools.getImage("MasterBG.png"))
					.AddAbilities(list5[0])
					.AddMetaCategories(list[0])
					.SetRare();
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddMasterOB()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			list.Add(CardMetaCategory.Rare);
			List<GemType> list2 = new List<GemType>();
			list2.Add(GemType.Orange);
			list2.Add(GemType.Blue);
			List<CardAppearanceBehaviour.Appearance> list3 = new List<CardAppearanceBehaviour.Appearance>();
			list3.Add(CardAppearanceBehaviour.Appearance.RareCardBackground);

			List<Ability> list5 = new List<Ability>();
			list5.Add(Ability.Flying);
			list5.Add(SigilCode.OrluHit.ability);

			Texture2D image = Tools.getImage("MasterOBEmmission.png");
			string text = "mag_masterob";
			string text2 = "Master Orlu";
			int num = 1;
			int num2 = 5;
			List<CardMetaCategory> list6 = list;
			CardComplexity cardComplexity = CardComplexity.Simple;
			CardTemple cardTemple = CardTemple.Nature;
			string text3 = "The great Master Orlu, soaring on pale wings, it attacks from above and draws in cards from below..";
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

			CardInfo myCard = CardManager.New("mag", text, text2, num, num2, text3)

					.SetCost(bloodCost: 0, gemsCost: list2)
					.SetPortrait(Tools.getImage("MasterOB.png"))
					.AddAbilities(list5[0], list5[1])
					.AddMetaCategories(list[0])
					.SetRare();
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddMasterMagnus()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			List<Ability> list2 = new List<Ability>();
			list2.Add(SigilCode.MagGainGemTriple.ability);
			list2.Add(Ability.MadeOfStone);
			List<CardAppearanceBehaviour.Appearance> list3 = new List<CardAppearanceBehaviour.Appearance>();
			list3.Add(CardAppearanceBehaviour.Appearance.RareCardBackground);
			CardInfo myCard = CardManager.New("mag", "mag_mastertriple1", "Master Magnus", 1, 4, "my name is.. Shake-Zula! The Mic rula! The Old Schoola! You want a trip? I'll bring it to ya...")

					.SetPortrait(Tools.getImage("MasterMagnus_1.png"))
					.SetCost(bloodCost: 0, gemsCost: new List<GemType> { GemType.Green })
					.AddAppearances(list3[0])
					.AddAbilities(list2[0], list2[1]);

			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddMasterMagnus2()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			List<Ability> list2 = new List<Ability>();
			list2.Add(SigilCode.MagGainGemTriple.ability);
			list2.Add(Ability.MadeOfStone);
			list2.Add(Ability.BuffGems);
			List<CardAppearanceBehaviour.Appearance> list3 = new List<CardAppearanceBehaviour.Appearance>();
			list3.Add(CardAppearanceBehaviour.Appearance.RareCardBackground);
			CardInfo myCard = CardManager.New("mag", "mag_mastertriple2", "Master Magnus", 2, 6, "Frylock yeah Im on top rock you like a cop, meatwad you're up next with your knock knock!")

					.SetPortrait(Tools.getImage("MasterMagnus_2.png"))
					.SetCost(bloodCost: 0, gemsCost: new List<GemType> { GemType.Orange })
					.AddAppearances(list3[0])
					.AddAbilities(list2[0], list2[1], list2[2]);

			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddMasterMagnus3()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			List<Ability> list2 = new List<Ability>();
			list2.Add(SigilCode.MagGainGemTriple.ability);
			list2.Add(Ability.MadeOfStone);
			list2.Add(Ability.BuffGems);
			list2.Add(Ability.ShieldGems);
			List<CardAppearanceBehaviour.Appearance> list3 = new List<CardAppearanceBehaviour.Appearance>();
			list3.Add(CardAppearanceBehaviour.Appearance.RareCardBackground);
			CardInfo myCard = CardManager.New("mag", "mag_mastertriple3", "Master Magnus", 2, 8, "Meatwad get the money, see. Meatwad get the honeys, G. ")

					.SetPortrait(Tools.getImage("MasterMagnus_3.png"))
					.SetCost(bloodCost: 0, gemsCost: new List<GemType> { GemType.Blue })
					.AddAppearances(list3[0])
					.AddAbilities(list2[0], list2[1], list2[2], list2[3]);

			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddPheonix()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { CardMetaCategory.Rare };
			List<Ability> list2 = new List<Ability>();
			list2.Add(Ability.Flying);
			list2.Add(SigilCode.Ignite.ability);
			list2.Add(SigilCode.FamiliarA.ability);
			List<CardAppearanceBehaviour.Appearance> list3 = new List<CardAppearanceBehaviour.Appearance>();
			list3.Add(CardAppearanceBehaviour.Appearance.RareCardBackground);
			CardInfo myCard = CardManager.New("mag", "mag_pheonix", "Orlu's Phoenix", 1, 3, "Majestic avian, summoned to channel Orlu's soul.")

					.SetPortrait(Tools.getImage("orlu pheonix.png"))
					.SetCost(bloodCost: 0, gemsCost: new List<GemType> { GemType.Orange, GemType.Blue })
					.AddAppearances(list3[0])
					.AddAbilities(list2[0], list2[1], list2[2]);

			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddBleenehound()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { CardMetaCategory.Rare };
			List<Ability> list2 = new List<Ability>();
			list2.Add(Ability.GuardDog);
			list2.Add(SigilCode.FamiliarA.ability);
			List<CardAppearanceBehaviour.Appearance> list3 = new List<CardAppearanceBehaviour.Appearance>();
			list3.Add(CardAppearanceBehaviour.Appearance.RareCardBackground);
			CardInfo myCard = CardManager.New("mag", "mag_bleenehound", "Bleenehound", 4, 3, "Loyalist canine, summoned to protect Bleene's mind.")

					.SetPortrait(Tools.getImage("bleenehound.png"))
					.SetCost(bloodCost: 0, gemsCost: new List<GemType> { GemType.Green, GemType.Blue })
					.AddAppearances(list3[0])
					.AddAbilities(list2[0], list2[1]);

			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddBleeneBooks()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();

			CardInfo alchemy = CardManager.New("mag", "mag_bleenebookalchemy", "Alchemy 101", 0, 2, "[c:g2]Alchemy 101[c:]\n[c:g3]I[c:] [c:g1]never[c:] [c:g3]was[c:] [c:g1]that[c:] [c:g3]great[c:] [c:g1]at[c:] [c:g3]alchemy..[c:]")

					.SetPortrait(Tools.getImage("bleenebook_alchemy.png"))
					.SetCost(bloodCost: 0, gemsCost: new List<GemType> { GemType.Green })
					.AddAbilities(Ability.BuffNeighbours);
			alchemy.metaCategories = list;
			CardInfo buffgems = CardManager.New("mag", "mag_bleenebookbuffgems", "Guide to Attack", 1, 1, "[c:g2]Guide to Attack[c:]\n[c:g3]One[c:] [c:g1]of[c:] [c:g3]the[c:] [c:g1]first[c:] [c:g3]books[c:] [c:g1]I[c:] [c:g3]ever[c:] [c:g1]read.[c:]")

					.SetPortrait(Tools.getImage("bleenebook_buffgems.png"))
					.SetCost(bloodCost: 0, gemsCost: new List<GemType> { GemType.Orange })
					.AddAbilities(Ability.BuffGems);
			buffgems.metaCategories = list;
			CardInfo impaled = CardManager.New("mag", "mag_bleenebookimpaled", "The art of Surprise", 1, 1, "[c:g2]The art of Surprise[c:]\n[c:g3]Looks[c:] [c:g1]like[c:] [c:g3]a[c:] [c:g1]frustrated[c:] [c:g3]mage[c:] [c:g1]stabbed[c:] [c:g3]it.[c:]")

					.SetPortrait(Tools.getImage("bleenebook_impaled.png"))
					.SetCost(bloodCost: 0, gemsCost: new List<GemType> { GemType.Orange })
					.AddAbilities(SigilCode.MagDropSpear.ability);
			impaled.metaCategories = list;
			CardInfo repulsive = CardManager.New("mag", "mag_bleenebookrepulsive", "Tome of Forbidden Secrets", 0, 1, "[c:g2]The Tome of Forbidden Secrets[c:]\n[c:g3]Quite[c:] [c:g1]tough[c:] [c:g3]to[c:] [c:g1]open.[c:]")

					.SetPortrait(Tools.getImage("bleenebook_repulsive.png"))
					.SetCost(bloodCost: 0, gemsCost: new List<GemType> { GemType.Blue })
					.AddAbilities(Ability.PreventAttack, Ability.GemDependant);
			repulsive.metaCategories = list;
			CardInfo revivor = CardManager.New("mag", "mag_bleenebookrevivor", "Secrets of Life and Death", 0, 3, "[c:g2]The Secrets of Life and Death[c:]\n[c:g3]A[c:] [c:g1]forbidden[c:] [c:g3]book,[c:] [c:g1]I[c:] [c:g3]had[c:] [c:g1]to[c:] [c:g3]read[c:] [c:g1]it[c:] [c:g3]in[c:] [c:g1]secret![c:]")

					.SetPortrait(Tools.getImage("bleenebook_revivor.png"))
					.SetCost(bloodCost: 1)
					.AddAbilities(SigilCode.LifeUpOmega.ability);
			revivor.metaCategories = list;
			CardInfo sharp = CardManager.New("mag", "mag_bleenebooksharp", "Book of War", 1, 2, "[c:g2]Book of War[c:]\n[c:g3]A[c:] [c:g1]painful,[c:] [c:g3]yet[c:] [c:g1]informative[c:] [c:g3]read.[c:]")

					.SetPortrait(Tools.getImage("bleenebook_sharp.png"))
					.SetCost(bloodCost: 0, gemsCost: new List<GemType> { GemType.Orange })
					.AddAbilities(Ability.Sharp);
			sharp.metaCategories = list;
			CardInfo gold = CardManager.New("mag", "mag_bleenebookgold", "Gold-Encrusted Codex", 0, 4, "[c:g2]Gold-Encrusted Codex[c:]\n[c:g3]Possibly[c:] [c:g1]the[c:] [c:g3]most[c:] [c:g1]valueable[c:] [c:g3]book[c:] [c:g1]I[c:] [c:g3]own.[c:]")

					.SetPortrait(Tools.getImage("bleenebook_gold.png"))
					.SetCost(bloodCost: 0, gemsCost: new List<GemType> { GemType.Orange })
					.AddAbilities(SigilCode.DropMana.ability);
			gold.metaCategories = list;
			CardInfo runes = CardManager.New("mag", "mag_bleenebookrunes", "Introduction to Runes", 0, 1, "[c:g2]Introduction to Runes[c:]\n[c:g3]'Twas[c:] [c:g1]an[c:] [c:g3]absolute[c:] [c:g1]nightmare[c:] [c:g3]learning[c:] [c:g1]all[c:] [c:g3]those[c:] [c:g1]runes.[c:]")

					.SetPortrait(Tools.getImage("bleenebook_runes.png"))
					.SetCost(bloodCost: 0, gemsCost: new List<GemType> { GemType.Blue })
					.AddAbilities(Ability.ExplodeOnDeath);
			runes.metaCategories = list;
			CardInfo slime = CardManager.New("mag", "mag_bleenebookslime", "Goo Covered Book", 0, 2, "[c:g2]A Brief Hist-[c:] [c:g3]Wait[c:] [c:g1]a[c:] [c:g3]minute..[c:] [c:g1]Some[c:] [c:g3]vandal[c:] [c:g1]ruined[c:] [c:g3]this[c:] [c:g1]one![c:]")

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
			CardInfo animator = CardManager.New("mag", "mag_bleenebookanimator", "The Art of Possesion", 0, 5, "[c:g2]The Art of Possesion[c:]\n[c:g3]Animating[c:] [c:g1]other[c:] [c:g3]mages[c:] [c:g1]was[c:] [c:g3]considered[c:] [c:g1]taboo[c:] [c:g3]back[c:] [c:g1]when[c:] [c:g3]I[c:] [c:g1]was[c:] [c:g3]around.[c:]")

					.SetPortrait(Tools.getImage("bleenebook_animator.png"))
					.AddAbilities(SigilCode.Animator.ability)
					.SetCost(bloodCost: 0, gemsCost: new List<GemType> { GemType.Blue });
			animator.metaCategories = list;
		}

		public static void AddDrake()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { CardMetaCategory.Rare };
			List<Ability> list2 = new List<Ability>();
			list2.Add(SigilCode.FlameSpell.ability);
			list2.Add(Ability.Reach);
			list2.Add(SigilCode.FamiliarA.ability);
			List<CardAppearanceBehaviour.Appearance> list3 = new List<CardAppearanceBehaviour.Appearance>();
			list3.Add(CardAppearanceBehaviour.Appearance.RareCardBackground);
			CardInfo myCard = CardManager.New("mag", "mag_drake", "Goranj's Drake", 2, 4, "Powerful reptile, summoned to complete Goranj's body.")

					.SetPortrait(Tools.getImage("goranjdrake.png"))
					.SetCost(bloodCost: 0, gemsCost: new List<GemType> { GemType.Green, GemType.Orange })
					.AddAppearances(list3[0])
					.AddAbilities(list2[0], list2[1], list2[2]);

			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddMoon()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			List<Ability> list2 = new List<Ability>();
			CardInfo myCard = CardManager.New("mag", "mag_giantmoon", "The Moon", 1, 15, "OH THE MOON O HTHEMOON OH THE MOON O H THE MOON.")

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
			CardInfo green = CardManager.New("mag", "mag_hydragreen", "Head of Emerald", 0, 5, "trogdor")

					.SetPortrait(Tools.getImage("hydragreen.png"))
					.SetCost(gemsCost: new List<GemType> { GemType.Green })
					.AddAbilities(Ability.Reach, Ability.DebuffEnemy, Ability.WhackAMole);
			green.metaCategories = list;
			CardInfo orange = CardManager.New("mag", "mag_hydraorange", "Head of Ruby", 2, 5, "haha goarnj")

					.SetPortrait(Tools.getImage("hydraorange.png"))
					.SetCost(gemsCost: new List<GemType> { GemType.Orange })
					.AddAbilities(Ability.Reach, Ability.GuardDog, Ability.BuffGems);
			orange.metaCategories = list;
			CardInfo blue = CardManager.New("mag", "mag_hydrablue", "Head of Sapphire", 1, 7, "mind gaames")

					.SetPortrait(Tools.getImage("hydrablue.png"))
					.SetCost(gemsCost: new List<GemType> { GemType.Blue })
					.AddAbilities(Ability.Reach, Ability.AllStrike, Ability.MadeOfStone);
			blue.metaCategories = list;
			CardInfo black = CardManager.New("mag", "mag_hydrablack", "Heads of Void", 0, 10, "evil")

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
			CardInfo myCard = CardManager.New("mag", "mag_giantmoonshards", "Moon Shards", 0, 7, "OH THE MOON O HTHEMOON OH THE MOON O H THE MOON.")

					.SetPortrait(Tools.getImage("moonshards.png"))
					.SetCost(bloodCost: 0)
					.AddAbilities(Ability.Reach, Ability.BuffGems, Ability.MadeOfStone);

			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;

			List<CardMetaCategory> list3 = new List<CardMetaCategory>();
			CardInfo myCard2 = CardManager.New("mag", "mag_giantmoonshards2", "Moon Shards", 0, 7, "OH THE MOON O HTHEMOON OH THE MOON O H THE MOON.")

					.SetPortrait(Tools.getImage("moonshards.png"))
					.SetCost(bloodCost: 0)
					.AddAbilities(Ability.Reach, Ability.DeathShield, Ability.MadeOfStone);

			myCard.metaCategories = list3;
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddVenus()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			List<Ability> list2 = new List<Ability>();
			CardInfo myCard = CardManager.New("mag", "mag_venus", "Venus", 1, 6, "Its a me venus!")

					.SetPortrait(Tools.getImage("venus.png"))
					.AddTraits(Trait.Gem)
					.SetCost(bloodCost: 0)
					.AddAppearances(CardAppearanceBehaviour.Appearance.TerrainBackground)
					.AddAbilities(Ability.Reach, Ability.MadeOfStone, Ability.Sharp);

			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}
		public static void AddMars()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			List<Ability> list2 = new List<Ability>();
			CardInfo myCard = CardManager.New("mag", "mag_mars", "Mars", 1, 4, "Its a me mars!")

					.SetPortrait(Tools.getImage("mars.png"))
					.AddAppearances(CardAppearanceBehaviour.Appearance.TerrainBackground)
					.AddTraits(Trait.Gem)
					.SetCost(bloodCost: 0)
					.AddAbilities(Ability.Reach, Ability.GainAttackOnKill, Ability.MadeOfStone);

			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddMercury()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			List<Ability> list2 = new List<Ability>();
			CardInfo myCard = CardManager.New("mag", "mag_mercury", "Mercury", 2, 4, "Its a me mercury!")

					.SetPortrait(Tools.getImage("mercury.png"))
					.AddTraits(Trait.Gem)
					.SetCost(bloodCost: 0)
					.AddAppearances(CardAppearanceBehaviour.Appearance.TerrainBackground)
					.AddAbilities(Ability.Reach, Ability.Deathtouch, Ability.MadeOfStone);

			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}
		public static void AddNeptune()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			List<Ability> list2 = new List<Ability>();
			CardInfo myCard = CardManager.New("mag", "mag_neptune", "Neptune", 1, 5, "Its a me neptune!")

					.SetPortrait(Tools.getImage("neptune.png"))
					.AddTraits(Trait.Gem)
					.AddAppearances(CardAppearanceBehaviour.Appearance.TerrainBackground)
					.SetCost(bloodCost: 0)
					.AddAbilities(Ability.Reach, SigilCode.FrostyA.ability);

			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddJupiter()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			List<Ability> list2 = new List<Ability>();
			CardInfo myCard = CardManager.New("mag", "mag_jupiter", "Jupiter", 0, 10, "Its a me jupiter!")

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
			CardInfo myCard = CardManager.New("mag", "mag_saturn", "Saturn", 1, 6, "Its a me saturn!")

					.SetPortrait(Tools.getImage("saturn.png"))
					.SetCost(bloodCost: 0)
					.AddAbilities(Ability.Reach, Ability.AllStrike);

			myCard.metaCategories = list;
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddMasterKraken()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			list.Add(CardMetaCategory.Rare);
			List<GemType> list2 = new List<GemType>();
			list2.Add(GemType.Blue);
			List<CardAppearanceBehaviour.Appearance> list3 = new List<CardAppearanceBehaviour.Appearance>();
			list3.Add(CardAppearanceBehaviour.Appearance.RareCardBackground);

			List<Ability> list5 = new List<Ability>();
			list5.Add(SigilCode.submergekraken.ability);

			Sprite pixelTex = Tools.getSprite("kraken_pixel.png");
			string text = "mag_masterkraken";
			string text2 = "Master Cephalo";
			int num = 2;
			int num2 = 1;
			List<CardMetaCategory> list6 = list;
			CardComplexity cardComplexity = CardComplexity.Simple;
			CardTemple cardTemple = CardTemple.Wizard;
			string text3 = "The mysterious Master Cephalo, it sinks down to the depths. Waiting.";
			bool flag = false;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			List<GemType> list7 = list2;

			CardInfo myCard = CardManager.New("mag", text, text2, num, num2, text3)

					.SetCost(bloodCost: 0, gemsCost: list2)
					.SetPortrait(Tools.getImage("master kraken.png"))
					.AddAbilities(list5[0])
					.AddMetaCategories(list[0])
					.SetPixelPortrait(pixelTex)
					.SetRare();
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
			List<CardAppearanceBehaviour.Appearance> list2 = new List<CardAppearanceBehaviour.Appearance>();
			list2.Add(CardAppearanceBehaviour.Appearance.RareCardBackground);
			List<Trait> list3 = new List<Trait>();
			list3.Add(Trait.Gem);
			List<Tribe> list4 = new List<Tribe>();
			List<Ability> list5 = new List<Ability>();
			list5.Add(Ability.GainGemBlue);
			list5.Add(Ability.GainGemGreen);

			string text = "mag_bleenemox";
			string text2 = "Bleene's Mox";
			int num = 0;
			int num2 = 3;
			List<CardMetaCategory> list7 = list;
			CardComplexity cardComplexity = CardComplexity.Simple;
			CardTemple cardTemple = CardTemple.Nature;
			string text3 = "Bleene's mox. It provides 2 gems, while only taking up 1 space.";
			bool flag = false;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;

			CardInfo myCard = CardManager.New("mag", text, text2, num, num2, text3)

					.SetCost()
					.SetPortrait(Tools.getImage("MoxGB.png"))
					.AddAbilities(list5[0], list5[1])
					.SetTraits(list3[0])
					.SetRare();
			myCard.metaCategories = new List<CardMetaCategory>();
		}

		public static void AddGOMox()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			List<CardAppearanceBehaviour.Appearance> list2 = new List<CardAppearanceBehaviour.Appearance>();
			list2.Add(CardAppearanceBehaviour.Appearance.RareCardBackground);
			List<Trait> list3 = new List<Trait>();
			list3.Add(Trait.Gem);
			List<Tribe> list4 = new List<Tribe>();
			List<Ability> list5 = new List<Ability>();
			list5.Add(Ability.GainGemGreen);
			list5.Add(Ability.GainGemOrange);

			string text = "mag_goranjmox";
			string text2 = "Goranj's Mox";
			int num = 0;
			int num2 = 3;
			List<CardMetaCategory> list7 = list;
			CardComplexity cardComplexity = CardComplexity.Simple;
			CardTemple cardTemple = CardTemple.Nature;
			string text3 = "Goranj's mox. It provides 2 gems, while only taking up 1 space.";
			bool flag = false;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			List<GemType> list8 = null;
			SpecialStatIcon specialStatIcon = SpecialStatIcon.None;

			CardInfo myCard = CardManager.New("mag", text, text2, num, num2, text3)

					.SetCost()
					.SetPortrait(Tools.getImage("MoxGO.png"))
					.AddAbilities(list5[0], list5[1])
					.SetTraits(list3[0])
					.SetRare();
			myCard.metaCategories = new List<CardMetaCategory>();
		}

		public static void AddBOMox()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			List<CardAppearanceBehaviour.Appearance> list2 = new List<CardAppearanceBehaviour.Appearance>();
			list2.Add(CardAppearanceBehaviour.Appearance.RareCardBackground);
			List<Trait> list3 = new List<Trait>();
			list3.Add(Trait.Gem);
			List<Tribe> list4 = new List<Tribe>();
			List<Ability> list5 = new List<Ability>();
			list5.Add(Ability.GainGemOrange);
			list5.Add(Ability.GainGemBlue);

			string text = "mag_orlumox";
			string text2 = "Orlu's Mox";
			int num = 0;
			int num2 = 3;
			List<CardMetaCategory> list7 = list;
			CardComplexity cardComplexity = CardComplexity.Simple;
			CardTemple cardTemple = CardTemple.Nature;
			string text3 = "Orlu's mox. It provides 2 gems, while only taking up 1 space.";
			bool flag = false;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;

			List<CardAppearanceBehaviour.Appearance> list12 = list2;
			CardInfo myCard = CardManager.New("mag", text, text2, num, num2, text3)

					.SetCost()
					.SetPortrait(Tools.getImage("MoxBO.png"))
					.AddAbilities(list5[0], list5[1])
					.SetTraits(list3[0])
					.SetRare();
			myCard.metaCategories = new List<CardMetaCategory>();
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

		public static void AddLonelyMage()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			list.Add(CardMetaCategory.Rare);
			List<GemType> list2 = new List<GemType>();
			list2.Add(GemType.Blue);
			List<CardAppearanceBehaviour.Appearance> list3 = new List<CardAppearanceBehaviour.Appearance>();
			list3.Add(CardAppearanceBehaviour.Appearance.RareCardBackground);

			List<Ability> list5 = new List<Ability>();
			list5.Add(Ability.MoveBeside);

			string text = "mag_lonelymage";
			string text2 = "Lonely Mage";
			int num = 3;
			int num2 = 1;
			List<CardMetaCategory> list6 = list;
			CardComplexity cardComplexity = CardComplexity.Simple;
			CardTemple cardTemple = CardTemple.Nature;
			string text3 = "A replica of one of my students.. Years of isolation unlocked his potential, but broke his mind.";
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
			CardInfo myCard = CardManager.New("mag", text, text2, num, num2, text3)

					.SetCost(bloodCost: 0, gemsCost: list2)
					.SetPortrait(Tools.getImage("mag_lonelymage.png"))
					.AddAbilities(list5[0])
					.AddMetaCategories(list[0])
					.SetRare();
			myCard.temple = CardTemple.Wizard;
		}

		public static void AddEspearara()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			list.Add(CardMetaCategory.Rare);
			List<GemType> list2 = new List<GemType>();
			list2.Add(GemType.Orange);
			List<CardAppearanceBehaviour.Appearance> list3 = new List<CardAppearanceBehaviour.Appearance>();
			list3.Add(CardAppearanceBehaviour.Appearance.RareCardBackground);
			List<Texture> list4 = new List<Texture>();

			List<Ability> list5 = new List<Ability>();
			list5.Add(SigilCode.MagDropSpear.ability);

			string text = "mag_espearara";
			string text2 = "Amber";
			int num = 2;
			int num2 = 2;
			List<CardMetaCategory> list6 = list;
			CardComplexity cardComplexity = CardComplexity.Simple;
			CardTemple cardTemple = CardTemple.Nature;
			string text3 = "A replica of one of my students..";
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
			CardInfo myCard = CardManager.New("mag", text, text2, num, num2, text3)

					.SetCost(bloodCost: 0, gemsCost: list2)
					.SetPortrait(Tools.getImage("mag_espearara.png"))
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
					.AddAbilities()
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
					.AddAbilities()
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

			CardInfo myCard6 = CardManager.New("mag", text9, text10, num11, num12, text3)

					.SetCost()
					.SetPortrait(Tools.getImage("mag_lonelymage.png"))
					.AddAbilities(list10[0], list10[1])
					.AddMetaCategories();
			myCard6.metaCategories = new List<CardMetaCategory>();
			string text13 = "mag_BOSSlonelymage2";
			string text14 = "Lonely Mage";
			int num16 = 2;
			int num17 = 2;
			List<CardMetaCategory> list41 = list;
			CardComplexity cardComplexity4 = CardComplexity.Simple;
			CardTemple cardTemple4 = CardTemple.Nature;
			string text15 = "";
			bool flag10 = false;
			int num18 = 0;
			int num19 = 0;
			int num20 = 0;
			List<GemType> list42 = null;
			SpecialStatIcon specialStatIcon4 = SpecialStatIcon.None;
			List<Tribe> list43 = null;
			List<Trait> list44 = null;
			List<SpecialTriggeredAbility> list45 = null;
			List<Ability> list46 = list11;
			EvolveParams evolveParams4 = null;
			string text16 = null;
			TailParams tailParams4 = null;
			IceCubeParams iceCubeParams4 = null;
			bool flag11 = false;
			bool flag12 = false;
			CardInfo myCard7 = CardManager.New("mag", text13, text14, num16, num17, text3)

					.SetCost()
					.SetPortrait(Tools.getImage("mag_lonelymage.png"))
					.AddAbilities(list11[0], list11[1])
					.AddMetaCategories();
			myCard7.metaCategories = new List<CardMetaCategory>();
			string text17 = "mag_BOSStrapspear";
			string text18 = "Spear";
			int num22 = 1;
			List<CardMetaCategory> list49 = list;
			CardComplexity cardComplexity5 = CardComplexity.Simple;
			CardTemple cardTemple5 = CardTemple.Nature;
			string text19 = "";
			bool flag13 = false;
			int num23 = 0;
			int num24 = 0;
			int num25 = 0;
			List<GemType> list50 = null;
			SpecialStatIcon specialStatIcon5 = SpecialStatIcon.None;
			List<Tribe> list51 = null;
			List<Trait> list52 = null;
			List<SpecialTriggeredAbility> list53 = null;
			List<Ability> list54 = new List<Ability>();
			EvolveParams evolveParams5 = null;

			CardInfo myCard8 = CardManager.New("mag", text17, "Enchanted Spear", 1, num22, text3)

					.SetCost()
					.SetPortrait(Tools.getImage("mag_enchspear.png"))
					.SetTraits(Trait.Terrain)
					.AddAbilities(Ability.Sharp)
					.AddAppearances(CardAppearanceBehaviour.Appearance.TerrainBackground)
					.AddMetaCategories();
			myCard8.metaCategories = new List<CardMetaCategory>();
			string text21 = "mag_BOSSgoobert";
			string text22 = "Goobert";
			int num26 = 1;
			int num27 = 4;
			List<CardMetaCategory> list57 = list;
			CardComplexity cardComplexity6 = CardComplexity.Simple;
			CardTemple cardTemple6 = CardTemple.Nature;
			string text23 = "";
			bool flag16 = false;
			int num28 = 0;
			int num29 = 0;
			int num30 = 0;

			List<CardAppearanceBehaviour.Appearance> list61 = list3;
			CardInfo myCard9 = CardManager.New("mag", text21, text22, num26, num27, text3)

					.SetCost()
					.SetPortrait(Tools.getImage("mag_goobert.png"))
					.AddAbilities(list13[0])
					.AddMetaCategories();
			myCard9.metaCategories = new List<CardMetaCategory>();
			string text24 = "mag_BOSSespearara";
			string text25 = "Espeara";
			int num31 = 2;
			int num32 = 8;
			List<CardMetaCategory> list62 = list;
			CardComplexity cardComplexity7 = CardComplexity.Simple;
			CardTemple cardTemple7 = CardTemple.Nature;
			string text26 = "";
			bool flag17 = false;
			int num33 = 0;
			int num34 = 0;
			int num35 = 0;

			list61 = list3;
			CardInfo myCard10 = CardManager.New("mag", text24, text25, num31, num32, text3)

					.SetCost()
					.SetPortrait(Tools.getImage("mag_espearara.png"))
					.AddAbilities(list14[0], list14[1])
					.AddMetaCategories();
			myCard10.metaCategories = new List<CardMetaCategory>();
			string text27 = "mag_BOSSmagnificuslonelymage";
			string text28 = "Lonely Mage";
			int num36 = 0;
			int num37 = 10;
			List<CardMetaCategory> list65 = list;
			CardComplexity cardComplexity8 = CardComplexity.Simple;
			CardTemple cardTemple8 = CardTemple.Nature;
			string text29 = "";
			bool flag18 = false;
			int num38 = 0;
			int num39 = 0;
			int num40 = 0;
			List<GemType> list66 = null;
			SpecialStatIcon specialStatIcon8 = SpecialStatIcon.None;

			list61 = list3;
			CardInfo myCard11 = CardManager.New("mag", text27, text28, num36, num37, text3)

					.SetCost()
					.SetPortrait(Tools.getImage("mag_lonelymage.png"))
					.AddAbilities(list15[0], list15[1])
					.AddMetaCategories();
			myCard11.metaCategories = new List<CardMetaCategory>();

			//NewCard.Add(text30, text31, num41, num42, list68, cardComplexity9, cardTemple9, text32, flag19, num43, num44, num45, list69, specialStatIcon9, list70, list5, list6, list60, null, null, null, null, null, null, false, false, list61, texture2D10, null, null, null, null, null, null, null, null, null);
		}

		public static void AddPortraitMage()
		{

			CardInfo myCard = CardManager.New("mag", "mag_portraitmage", "Portrait Mage", 0, 0, "Your own creation.. How did it get here?")

					.SetPortrait(Tools.getImage("invisible card.png"))
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

			CardInfo myCard = CardManager.New("mag", "mag_hpspell", "Spell of Health", 0, 1, "The spell of health, it casts several healing auras to all of your cards.")

					.SetPortrait(Tools.getImage("health_spell.png"))
					.AddAbilities(list5[0])
					.SetBloodCost(1)
					.AddTraits(traits[0])
					.AddSpecialAbilities(MagMod.ManaTutorial)
					.AddAppearances(appearanceBehaviours[0]);
			myCard.SetExtendedProperty("ManaCost", true);
			myCard.metaCategories = list;
		}

		public static void AddATKspell()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			List<CardAppearanceBehaviour.Appearance> appearanceBehaviours = new List<CardAppearanceBehaviour.Appearance> { CardAppearanceBehaviour.Appearance.TerrainLayout };

			List<Trait> traits = new List<Trait> { Trait.EatsWarrens };

			List<Ability> list5 = new List<Ability>();
			list5.Add(SigilCode.ATKSpell.ability);

			CardInfo myCard = CardManager.New("mag", "mag_atkspell", "Spell of Attack", 0, 1, "The spell of attack, it channels hellcow energy unto your card.")

					.SetPortrait(Tools.getImage("attack_spell.png"))
					.AddAbilities(list5[0])
					.SetBloodCost(2)
					.AddTraits(traits[0])
					.AddSpecialAbilities(MagMod.ManaTutorial)
					.AddAppearances(appearanceBehaviours[0]);
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

			CardInfo myCard = CardManager.New("mag", "mag_frostspell", "Spell of Frost", 0, 1, "The spell of frost. When used, the opponents side of the board will freeze over.")

					.SetPortrait(Tools.getImage("spell of frost.png"))
					.AddAbilities(list5[0])
					.AddTraits(traits[0])
					.SetBloodCost(1)
					.AddSpecialAbilities(MagMod.ManaTutorial)
					.AddAppearances(appearanceBehaviours[0]);
			myCard.SetExtendedProperty("ManaCost", true);
			myCard.metaCategories = list;
		}

		public static void AddTargetFrostSpell()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			List<CardAppearanceBehaviour.Appearance> appearanceBehaviours = new List<CardAppearanceBehaviour.Appearance> { CardAppearanceBehaviour.Appearance.TerrainLayout };
			List<Trait> traits = new List<Trait> { Trait.EatsWarrens };

			List<Ability> list5 = new List<Ability>();
			list5.Add(SigilCode.TargetFrost.ability);

			CardInfo myCard = CardManager.New("mag", "mag_tarfrostspell", "Spell of Frost", 0, 1, "The spell of frost. When used, select a side of the board to freeze over.")

					.SetPortrait(Tools.getImage("spell of frost.png"))
					.AddAbilities(list5[0])
					.AddTraits(traits[0])
					.SetBloodCost(2)
					.AddSpecialAbilities(MagMod.ManaTutorial)
					.AddAppearances(appearanceBehaviours[0]);
			myCard.SetExtendedProperty("TargetedSpell", true);
			myCard.SetExtendedProperty("TargetAllSpell", true);
			myCard.SetExtendedProperty("ManaCost", true);
			myCard.metaCategories = list;
		}

		public static void AddGoldspell()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory>();
			List<CardAppearanceBehaviour.Appearance> appearanceBehaviours = new List<CardAppearanceBehaviour.Appearance> { CardAppearanceBehaviour.Appearance.TerrainLayout };

			List<Trait> traits = new List<Trait> { Trait.EatsWarrens };
			List<Texture> list4 = new List<Texture>();

			List<Ability> list5 = new List<Ability>();
			list5.Add(SigilCode.GoldSpell.ability);

			CardInfo myCard = CardManager.New("mag", "mag_goldspell", "Gold Rush", 0, 1, "What en earth?")

					.SetPortrait(Tools.getImage("spell of gold.png"))
					.AddAbilities(list5[0])
					.AddTraits(traits[0])
					.SetBloodCost(2)
					.AddSpecialAbilities(MagMod.ManaTutorial)
					.AddAppearances(appearanceBehaviours[0]);
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

			CardInfo myCard = CardManager.New("mag", "mag_windspell", "Spell of Wind", 0, 1, "The spell of wind. When used, it will summon a whirlwind that boosts your cards into the air.")

					.SetPortrait(Tools.getImage("spell of wind.png"))
					.AddAbilities(list5[0])
					.AddTraits(traits[0])
					.SetBloodCost(1)
					.AddSpecialAbilities(MagMod.ManaTutorial)
					.AddAppearances(appearanceBehaviours[0]);
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

			CardInfo myCard = CardManager.New("mag", "mag_waterspell", "Spell of Water", 0, 1, "The spell of water. When used, it will summon a tsunami that wipes away the sigils of every card on the board.")

					.SetPortrait(Tools.getImage("spell of water.png"))
					.AddAbilities(list5[0])
					.AddTraits(traits[0])
					.SetBloodCost(1)
					.AddSpecialAbilities(MagMod.ManaTutorial)
					.AddAppearances(appearanceBehaviours[0]);
			myCard.SetExtendedProperty("ManaCost", true);
			myCard.metaCategories = list;
		}

		public static void AddFlamespell()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> ();
			List<CardAppearanceBehaviour.Appearance> appearanceBehaviours = new List<CardAppearanceBehaviour.Appearance> { CardAppearanceBehaviour.Appearance.TerrainLayout };

			List<Trait> traits = new List<Trait> { Trait.EatsWarrens };
			List<Texture> list4 = new List<Texture>();

			List<Ability> list5 = new List<Ability>();
			list5.Add(SigilCode.FlameSpell.ability);

			CardInfo myCard = CardManager.New("mag", "mag_flamespell", "Spell of Flame", 0, 1, "The spell of flame. When used, every opponent will be set ablaze.")

					.SetPortrait(Tools.getImage("spell of flame.png"))
					.AddAbilities(list5[0])
					.AddTraits(traits[0])
					.SetBloodCost(1)
					.AddSpecialAbilities(MagMod.ManaTutorial)
					.AddAppearances(appearanceBehaviours[0]);
			myCard.SetExtendedProperty("ManaCost", true);
			myCard.metaCategories = list;
		}

		public static void AddTargetFlameSpell()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { Plugin.SpellPool };
			List<CardAppearanceBehaviour.Appearance> appearanceBehaviours = new List<CardAppearanceBehaviour.Appearance> { CardAppearanceBehaviour.Appearance.TerrainLayout };
			List<Trait> traits = new List<Trait> { Trait.EatsWarrens };

			List<Ability> list5 = new List<Ability>();
			list5.Add(SigilCode.TargetFlame.ability);

			CardInfo myCard = CardManager.New("mag", "mag_tarflamespell", "Spell of Flame", 0, 1, "The spell of flame. When used, select a side of the board to be set ablaze.")

					.SetPortrait(Tools.getImage("spell of flame.png"))
					.AddAbilities(list5[0])
					.AddTraits(traits[0])
					.SetBloodCost(1)
					.AddSpecialAbilities(MagMod.ManaTutorial)
					.AddAppearances(appearanceBehaviours[0]);
			myCard.SetExtendedProperty("TargetedSpell", true);
			myCard.SetExtendedProperty("TargetAllSpell", true);
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
			list5.Add(SigilCode.OneTimeSpell.ability);

			CardInfo myCard = CardManager.New("mag", "mag_magnusspell", "Spell of Magnus Mox", 0, 3, "The spell of magnus mox.. It is able to sustain the spirit of a late magnus mox.. Only for a turn.")

					.SetPortrait(Tools.getImage("spell of magnus mox.png"))
					.AddAbilities(SigilCode.MagGainGemTriple.ability, list5[3])
					.AddTraits(traits[0], traits[1])
					.SetBloodCost(1)
					.AddSpecialAbilities(MagMod.ManaTutorial)
					.AddAppearances(appearanceBehaviours[0]);
			myCard.SetExtendedProperty("ManaCost", true);
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
					.SetBloodCost(1)
					.AddSpecialAbilities(MagMod.ManaTutorial)
					.AddAppearances(appearanceBehaviours[0]);
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

			CardInfo myCard = CardManager.New("mag", "mag_gnomespell", "Trasmogification Spell", 0, 1, "How did this get in here?")

					.SetPortrait(Tools.getImage("trasmogification spell.png"))
					.SetPixelPortrait(Tools.getSprite("pixelportrait_gnome.png"))
					.AddAbilities(list5[0])
					.AddTraits(traits[0])
					.SetBloodCost(1)
					.AddSpecialAbilities(MagMod.ManaTutorial)
					.AddAppearances(appearanceBehaviours[0]);
			myCard.SetExtendedProperty("ManaCost", true);
			myCard.metaCategories = list;
		}

		public static void AddCursedSkull()
		{
			List<CardMetaCategory> list = new List<CardMetaCategory> { Plugin.SpellPool };
			List<CardAppearanceBehaviour.Appearance> appearanceBehaviours = new List<CardAppearanceBehaviour.Appearance> { CardAppearanceBehaviour.Appearance.TerrainLayout };

			List<Trait> traits = new List<Trait> { Trait.EatsWarrens };
			List<Texture> list4 = new List<Texture>();

			List<Ability> list5 = new List<Ability>();
			list5.Add(SigilCode.Cursed.ability);

			CardInfo myCard = CardManager.New("mag", "mag_cursedskull", "Cursed Skull", 0, 1, "Hmm, a cursed skull. Handle it with care.")

					.SetPortrait(Tools.getImage("cursed skull.png"))
					.AddAbilities(list5[0], Ability.ExplodeOnDeath)
					.AddTraits(traits[0])
					.SetBloodCost(1)
					.AddSpecialAbilities(MagMod.ManaTutorial)
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

			CardInfo myCard = CardManager.New("mag", "mag_orluinspiration", "Orlu's Inspiration", 0, 1, "A culmination of the great Master Orlu's essence.")

					.SetPortrait(Tools.getImage("spell_orlusinsperation.png"))
					.AddAbilities(list5[0])
					.AddTraits(traits[0])
					.SetBloodCost(1)
					.AddSpecialAbilities(MagMod.ManaTutorial)
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

			CardInfo myCard = CardManager.New("mag", "mag_goranjrage", "Goranj's Rage", 0, 1, "The embodiement of the tenacious Master Goranj.")

					.SetPortrait(Tools.getImage("spell_goranjrage.png"))
					.AddAbilities(list5[0])
					.AddTraits(traits[0])
					.SetBloodCost(1)
					.AddSpecialAbilities(MagMod.ManaTutorial)
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

			CardInfo myCard = CardManager.New("mag", "mag_bleenecalculus", "Bleene's Calculus", 0, 1, "The spirit of the brave Master Bleene.")

					.SetPortrait(Tools.getImage("spell_bleenecalculus.png"))
					.AddAbilities(list5[0])
					.AddTraits(traits[0])
					.SetBloodCost(1)
					.AddSpecialAbilities(MagMod.ManaTutorial)
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
					.SetBloodCost(1)
					.AddSpecialAbilities(MagMod.ManaTutorial)
					.AddAppearances(appearanceBehaviours[0]);
			myCard.SetExtendedProperty("TargetedSpell", true);
			myCard.SetExtendedProperty("TargetAllSpell", true);
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
					.AddAppearances(appearanceBehaviours[0]);
			myCard.SetExtendedProperty("TargetedSpell", true);
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
