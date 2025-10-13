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
using SigilCode = MagnificusMod.SigilCode;

namespace MagnificusMod
{
    class MagSigils
    {
		public static void ChangeMox()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Blank Mox", "When a card bearing this sigil is drawn, it will materialize into a random Mox Crystal. \n When on another card, the card will generate a random Mox Crystal.", typeof(SigilCode.MoxRandom), Tools.getImage("random mox icon.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.getImage("random mox icon.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> ();
			newAbility.powerLevel = 10;
			SigilCode.MoxRandom.ability = newAbility.ability;

		}

		public static void SelectMox()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Undecided Mox", "When a card bearing this sigil is played, select a mox type for this card to provide.", typeof(SigilCode.MoxSelect), Tools.getImage("random mox icon.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.getImage("random mox icon.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			newAbility.powerLevel = 3;
			SigilCode.MoxSelect.ability = newAbility.ability;

		}

		public static void DropRuby()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Ruby Heart", "When a card bearing this sigil perishes, it creates a Ruby Mox in its place.", typeof(SigilCode.MagDropRubyOnDeath), Tools.getImage("mag_dropruby.png"))
				.SetDefaultPart1Ability()
				.SetPixelAbilityIcon(Resources.Load("art/gbc/cards/pixelabilityicons/pixelability_droprubyondeath") as Texture2D)
				.SetIcon(Tools.getImage("mag_dropruby.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			newAbility.powerLevel = 2;
			SigilCode.MagDropRubyOnDeath.ability = newAbility.ability;
		}

		public static void DropSapphire()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Sapphire Heart", "When a card bearing this sigil perishes, it creates a Sapphire Mox in its place.", typeof(SigilCode.MagDropSapphireOnDeath), Tools.getImage("mag_dropsapphire.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.getImage("mag_dropsapphire.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			newAbility.powerLevel = 2;
			SigilCode.MagDropSapphireOnDeath.ability = newAbility.ability;
		}

		public static void BoneMarrows()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Bone Marrow", "When one of your cards perishes, a card bearing this sigil gains 1 power, maxing out at 5.", typeof(SigilCode.BoneMarrow), Tools.getImage("bonemarrow.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.getImage("bonemarrow.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			newAbility.powerLevel = 3;
			SigilCode.BoneMarrow.ability = newAbility.ability;
		}

		public static void Stimulate()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Stimulation", "At the end of every turn, a card bearing this sigil gains 1 power, maxing out at 4.", typeof(SigilCode.Stimulation), Tools.getImage("stimulationability.png"))
				.SetDefaultPart1Ability()
				.SetPixelAbilityIcon(Tools.getImage("stimulation_pixel.png"))
				.SetIcon(Tools.getImage("stimulationability.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			newAbility.powerLevel = 3;
			SigilCode.Stimulation.ability = newAbility.ability;
		}

		public static void StimulateHP()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Stimulation (Health)", "At the end of every turn, a card bearing this sigil gains 2 health, maxes out at 10.", typeof(SigilCode.StimulationHP), Tools.getImage("stimulationhealth.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.getImage("stimulationhealth.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			newAbility.powerLevel = 5;
			SigilCode.StimulationHP.ability = newAbility.ability;
		}

		public static void Bleene()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Dead Draw", "When a non-gem card dies, draw a card from your deck.", typeof(SigilCode.BleeneDraw), Tools.getImage("mag_bleeneability.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.getImage("mag_bleeneability.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			newAbility.powerLevel = 3;
			SigilCode.BleeneDraw.ability = newAbility.ability;
		}

		public static void DropEmerald()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Emerald Heart", "When a card bearing this sigil perishes, it creates an Emerald Mox in its place.", typeof(SigilCode.MagDropEmeraldOnDeath), Tools.getImage("mag_dropemerald.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.getImage("mag_dropemerald.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			newAbility.powerLevel = 2;
			SigilCode.MagDropEmeraldOnDeath.ability = newAbility.ability;
		}

		public static void Goobert()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Gooey", "When a card bearing this sigil is struck, the striker loses 1 attack.", typeof(SigilCode.GoobertDebuff), Tools.getImage("mag_goobertability.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.getImage("mag_goobertability.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			newAbility.powerLevel = 3;
			newAbility.canStack = true;
			SigilCode.GoobertDebuff.ability = newAbility.ability;
		}

		public static void BMDraw()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Mental Gemnastics", "When a card bearing this sigil is played, draw cards from your deck based on how many Gems are on the board.", typeof(SigilCode.BlueMageDraw), Tools.getImage("mag_bluemagedraw.png"))

				.SetDefaultPart1Ability()
				.SetPixelAbilityIcon(Resources.Load("art/gbc/cards/pixelabilityicons/pixelability_gemsdraw") as Texture2D)
				.SetIcon(Tools.getImage("mag_bluemagedraw.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			newAbility.powerLevel = 3;
			newAbility.canStack = true;
			SigilCode.BlueMageDraw.ability = newAbility.ability;
		}

		public static void LootOrlu()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Loot", "When a card bearing this sigil deals direct damage, draw cards from your deck based on how much damage was dealt.", typeof(SigilCode.OrluHit), Tools.getImage("mag_loot.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.getImage("mag_loot.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			newAbility.powerLevel = 3;
			SigilCode.OrluHit.ability = newAbility.ability;
		}

		public static void AddLifeSteal()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Life Steal", "When a card bearing this sigil deals direct damage, the amount dealt will be healed to the owner of this card.", typeof(SigilCode.LifeSteal), Tools.getImage("lifesteal.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.getImage("lifesteal.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			newAbility.powerLevel = 2;
			SigilCode.LifeSteal.ability = newAbility.ability;
		}

		public static void SharkoHit()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Knockback Hit", "When a card bearing this sigil hits an opposing card, the opposing card will be kicked in the direction inscrybed in the sigil.", typeof(SigilCode.sharkoKick), Tools.getImage("sharko_kick.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.getImage("sharko_kick.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			newAbility.powerLevel = 2;
			SigilCode.sharkoKick.ability = newAbility.ability;
		}
		public static void DropSpear()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Impaled", "When a card bearing this sigil perishes, it creates a Spear in its placed. A spear is defined as Sharp, 0 power, 3 health.", typeof(SigilCode.MagDropSpear), Tools.getImage("mag_impaled.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.getImage("mag_impaled.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			newAbility.powerLevel = 2;
			SigilCode.MagDropSpear.ability = newAbility.ability;
		}

		public static void MagGainGemTriple()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Magnus Mox", "While a card bearing this sigil is on the board, it provides an orange gem, a blue gem and a green gem to its owner.", typeof(SigilCode.MagGainGemTriple), Tools.getImage("gaingemtriple.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.getImage("gaingemtriple.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			newAbility.powerLevel = 5;
			SigilCode.MagGainGemTriple.ability = newAbility.ability;
		}
		/*
		public static void Repulsive2()
		{
			AbilityInfo abilityInfo = ScriptableObject.CreateInstance<AbilityInfo>();
			abilityInfo.powerLevel = 5;
			abilityInfo.rulebookName = "Untransferrable";
			abilityInfo.rulebookDescription = "When a card bearing this sigil is transfered onto another card, it will perish at the end of the turn.";
			abilityInfo.metaCategories = new List<AbilityMetaCategory>
			{
				AbilityMetaCategory.Part1Rulebook
			};
			byte[] data = File.ReadAllBytes(Path.Combine(base.Info.Location.Replace("MagnificusMod.dll", ""), "mag_repulsivesigil.png"));
			Texture2D texture2D = new Texture2D(2, 2);
			texture2D.LoadImage(data);
		}*/

		public static void LIFEUP()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Resurrection", "When a non-gem card perishes, the dead card will be brought back to life, but this card loses 3 health.", typeof(SigilCode.LifeUpOmega), Tools.getImage("1up.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.getImage("1up.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			newAbility.powerLevel = 0;
			SigilCode.LifeUpOmega.ability = newAbility.ability;
		}

		public static void ReRoll()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Rerolls", "At the end of every turn, a card bearing this sigils' base power will be increased by a random value between 0 and 3.", typeof(SigilCode.RandomPower), Tools.getImage("diceability.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.getImage("diceability.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			newAbility.powerLevel = 1;
			SigilCode.RandomPower.ability = newAbility.ability;
		}

		public static void ImprovedTrap()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Steel Trap", "When a card bearing this sigil perishes, the opposing card also perishes.", typeof(SigilCode.ImprovedSteelTrap), Tools.getImage("ability_steeltrap.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.getImage("ability_steeltrap.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			newAbility.powerLevel = 2;
			SigilCode.ImprovedSteelTrap.ability = newAbility.ability;
		}

		public static void GemGuard()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Gem Shield", "When a card bearing this sigil is played, all gems on the board gain a shield.", typeof(SigilCode.GemGuardianFix), Tools.getImage("ability_shieldgems.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.getImage("ability_shieldgems.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			newAbility.powerLevel = 2;
			SigilCode.GemGuardianFix.ability = newAbility.ability;
		}
		public static void PlatingWork()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Plating Work", "While a card bearing this sigil is on the board, all gems on your side of the board gain the Sharp Quills sigil, and 2 health.", typeof(SigilCode.PlatingWork), Tools.getImage("whitesmith_A.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.getImage("whitesmith_A.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			newAbility.powerLevel = 2;
			SigilCode.PlatingWork.ability = newAbility.ability;
		}

		public static void Animator()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Animator", "While a card bearing this sigil is on the board, all non-mox cards with 0 power gain 2 power", typeof(SigilCode.Animator), Tools.getImage("animator.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.getImage("animator.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			newAbility.powerLevel = 3;
			SigilCode.Animator.ability = newAbility.ability;
		}

		public static void GemAbsorb()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Gem Absorber", "When a card bearing this sigil is played, all gems on your side of the board will perish. For each gem absorbed, gain 1 power and 2 health.", typeof(SigilCode.GemAbsorber), Tools.getImage("ability_absorbgems.png"))
				.SetDefaultPart1Ability()
				.SetPixelAbilityIcon(Tools.getImage("pixelability_absorbgems.png"))
				.SetIcon(Tools.getImage("ability_absorbgems.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			newAbility.powerLevel = 2;
			SigilCode.GemAbsorber.ability = newAbility.ability;
		}

		/*
		public static void Multipliy()
		{
			AbilityInfo abilityInfo = ScriptableObject.CreateInstance<AbilityInfo>();
			abilityInfo.powerLevel = 8;
			abilityInfo.rulebookName = "Multiply";
			abilityInfo.rulebookDescription = "When a card bearing this sigil is played, create a copy adjacent, and opposing to it.";
			abilityInfo.metaCategories = new List<AbilityMetaCategory>
			{
				AbilityMetaCategory.Part1Rulebook,
				AbilityMetaCategory.Part1Modular
			};
			byte[] data = File.ReadAllBytes(Path.Combine(Plugin.Info.Location.Replace("MagnificusMod.dll", ""), "ability_absorbgems.png"));
			Texture2D texture2D = new Texture2D(2, 2);
			texture2D.LoadImage(data);
		}
		*/
		/*
		public static void BlueCommon()
		{
			byte[] data = File.ReadAllBytes(Path.Combine(base.Info.Location.Replace("MagnificusMod.dll", ""), "sapphire_common.png"));
			Texture2D texture2D = new Texture2D(2, 2);
			texture2D.LoadImage(data);
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Sapphire Increase", "This mox card will be more likely to transform into a Sapphire Mox.", typeof(Plugin.bluecommon), texture2D)
				.SetDefaultPart1Ability()
				.SetIcon(texture2D);

			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.Part1Rulebook };
			bluecommon.ability = newAbility.ability;
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00007C78 File Offset: 0x00005E78
		public static void GreenCommon()
		{
			byte[] data = File.ReadAllBytes(Path.Combine(base.Info.Location.Replace("MagnificusMod.dll", ""), "emerald_common.png"));
			Texture2D texture2D = new Texture2D(2, 2);
			texture2D.LoadImage(data);
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Emerald Increase", "This mox card will be more likely to transform into a Emerald Mox.", typeof(Plugin.greencommon), texture2D)
				.SetDefaultPart1Ability()
				.SetIcon(texture2D);
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.Part1Rulebook };
			greencommon.ability = newAbility.ability;
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00007D24 File Offset: 0x00005F24
		public static void OrangeCommon()
		{
			byte[] data = File.ReadAllBytes(Path.Combine(base.Info.Location.Replace("MagnificusMod.dll", ""), "ruby_common.png"));
			Texture2D texture2D = new Texture2D(2, 2);
			texture2D.LoadImage(data);
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Ruby Increase", "This mox card will be more likely to transform into a Ruby Mox.", typeof(Plugin.orangecommon), texture2D)
				.SetDefaultPart1Ability()
				.SetIcon(texture2D);
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.Part1Rulebook };
			orangecommon.ability = newAbility.ability;
		}

		*/
		public static void KrakenSubmerge()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Submerge", "At the end of the turn, a card bearing this sigil will submerge. Upon resubmerging, this card will become a random Tentacle Card.", typeof(SigilCode.submergekraken), Tools.getImage("krakensubmerge.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.getImage("krakensubmerge.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			newAbility.powerLevel = 3;
			SigilCode.submergekraken.ability = newAbility.ability;
		}

		public static void Familiar()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Familiar", "A card bearing this sigil will perish if there are no non-gem cards on the board.", typeof(SigilCode.FamiliarA), Tools.getImage("familiar.png"))
				.SetDefaultPart1Ability()
				.SetPixelAbilityIcon(Tools.getImage("pixelability_familiar.png"))
				.SetIcon(Tools.getImage("familiar.png"));
			newAbility.powerLevel = -2;
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			SigilCode.FamiliarA.ability = newAbility.ability;
		}

		public static void Fading()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Fading", "A card bearing this sigil will perish at the end of the turn.", typeof(SigilCode.FadingA), Tools.getImage("fading.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.getImage("fading.png"));
			newAbility.powerLevel = -4;
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			SigilCode.FadingA.ability = newAbility.ability;
		}

		public static void DittoAbility()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Morph", "When a card bearing this sigil is played, it will mimic the card opposing it. If there is no card opposing it, this card will perish.", typeof(SigilCode.Ditto), Tools.getImage("transformability.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.getImage("transformability.png"));
			newAbility.powerLevel = 2;
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			SigilCode.Ditto.ability = newAbility.ability;
		}

		public static void FecundityCycleAbility()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Multiplication", "When a card bearing this sigil is played, draw another of this card, but with a different gem cost.", typeof(SigilCode.FecundityCycle), Tools.getImage("multiply.png"))
				.SetDefaultPart1Ability()
				.SetPixelAbilityIcon(Tools.getImage("pixelability_fecunditycycle.png"))
				.SetIcon(Tools.getImage("multiply.png"));
			newAbility.powerLevel = 4;
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			SigilCode.FecundityCycle.ability = newAbility.ability;
		}

		public static void MoxCycle()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Mox Cycle", "At the end of every turn, all the mox on the board will cycle into different gems.", typeof(SigilCode.MoxCycling), Tools.getImage("moxcycle.png"))
				.SetDefaultPart1Ability()
				.SetPixelAbilityIcon(Tools.getImage("pixelability_moxcycle.png"))
				.SetIcon(Tools.getImage("moxcycle.png"));
			newAbility.powerLevel = 0;
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			SigilCode.MoxCycling.ability = newAbility.ability;
		}

		public static void MoxStrf()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Mox Strafe", "At the end of the turn, this card will move to the direction inscrybed on the sigil, and leave behind a mox.", typeof(SigilCode.MoxStrafe), Tools.getImage("moxstrafe.png"))
				.SetDefaultPart1Ability()
				.SetPixelAbilityIcon(Tools.getImage("pixelability_moxstrafe.png"))
				.SetIcon(Tools.getImage("moxstrafe.png"));
			newAbility.powerLevel = 1;
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			SigilCode.MoxStrafe.ability = newAbility.ability;
		}

		public static void Purity()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Purist", "Any card directly opposing this one will have all it's sigils removed.", typeof(SigilCode.NullifySigils), Tools.getImage("purist.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.getImage("purist.png"));
			newAbility.powerLevel = 2;
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			SigilCode.NullifySigils.ability = newAbility.ability;
		}

		public static void Brewery()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Brewery", "At the end of every turn, you automatically draw a mox card from your side deck.", typeof(SigilCode.DrawMoxFromSideDeck), Tools.getImage("brewery.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.getImage("brewery.png"));
			newAbility.powerLevel = 3;
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			SigilCode.DrawMoxFromSideDeck.ability = newAbility.ability;
		}
		public static void Ignition()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Ignite", "When a card bearing this sigil is played, every empty opposing slot will be filled with flames. A flame is defined as a 0/1, Annoying.", typeof(SigilCode.Ignite), Tools.getImage("igniteability.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.getImage("igniteability.png"));
			newAbility.powerLevel = 3;
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			SigilCode.Ignite.ability = newAbility.ability;
		}

		public static void ProjectorSigil()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Projection", "When a card bearing this sigil is stuck, it will move and leave behind an astral projection of itself.", typeof(SigilCode.AstralProjection), Tools.getImage("projector.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.getImage("projector.png"));
			newAbility.powerLevel = 2;
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			SigilCode.AstralProjection.ability = newAbility.ability;
		}

		public static void SpellBookSigil()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Spell Book", "When a card bearing this sigil is played, draw a random spell card.", typeof(SigilCode.DrawSpell), Tools.getImage("spellbooksigil.png"))
				.SetDefaultPart1Ability()
				.SetPixelAbilityIcon(Tools.getImage("pixelability_spellbook.png"))
				.SetIcon(Tools.getImage("spellbooksigil.png"));
			newAbility.powerLevel = 3;
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			SigilCode.DrawSpell.ability = newAbility.ability;
		}

		public static void ScholarSigil()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Scholar", "When a card bearing this sigil is played, draw a random one of Bleene's Books.", typeof(SigilCode.DrawBook), Tools.getImage("scholarsigil.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.getImage("scholarsigil.png"));
			newAbility.powerLevel = 3;
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			SigilCode.DrawBook.ability = newAbility.ability;
		}

		public static void MidasTouch()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Midas' Touch", "When a card bearing this sigil attacks another card, the attacked card will lose all of it's attack and turn to gold.", typeof(SigilCode.MidasTouchA), Tools.getImage("midas touch.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.getImage("midas touch.png"));
			newAbility.powerLevel = 4;
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			SigilCode.MidasTouchA.ability = newAbility.ability;
		}

		public static void MadeOfGold()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Made of Gold", "When a card bearing this sigil perishes, the killer will gain 2 crystals.", typeof(SigilCode.DropMana), Tools.getImage("goldenA.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.getImage("goldenA.png"));
			newAbility.powerLevel = 1;
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			SigilCode.DropMana.ability = newAbility.ability;
		}

		public static void SummonRunes()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Summon Runes", "When a card bearing this sigil is played, it will summon two runes beside it. A rune is defined as 0 power, 1 health, Runic.", typeof(SigilCode.SummonRunes), Tools.getImage("spawnrunes.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.getImage("spawnrunes.png"));
			newAbility.powerLevel = 3;
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			SigilCode.SummonRunes.ability = newAbility.ability;
		}

	public static void RuneSigil()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Runic", "When a card bearing this sigil perishes, trigger 1 of 3 effects: Deal 1 Direct Damage; Heal 1 Health; Gain another rune card.", typeof(SigilCode.Runic), Tools.getImage("runic.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.getImage("runic.png"));
			newAbility.powerLevel = 2;
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			SigilCode.Runic.ability = newAbility.ability;
		}
    
		public static void HPSpellAbility()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Spell of Health", "When a spell bearing this sigil is played, all cards on your side of the board gain +2 health.", typeof(SigilCode.HPSpell), Tools.getImage("hpspell_ability.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.getImage("hpspell_ability.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			newAbility.powerLevel = 10;
			SigilCode.HPSpell.ability = newAbility.ability;
		}

		public static void ATKSpellAbility()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Spell of Attack", "When a spell bearing this sigil is played, all cards on your side of the board gain +1 attack.", typeof(SigilCode.ATKSpell), Tools.getImage("atkspell_ability.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.getImage("atkspell_ability.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			newAbility.powerLevel = 10;
			SigilCode.ATKSpell.ability = newAbility.ability;
		}

		public static void FrostSpellAbility()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Freeze", "When a spell bearing this sigil is played, both sides of the board will be immune to direct damage for a turn.", typeof(SigilCode.FrostSpell), Tools.getImage("spell of frost_ability.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.getImage("spell of frost_ability.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			newAbility.powerLevel = 10;
			SigilCode.FrostSpell.ability = newAbility.ability;
		}

		public static void WindSpellAbility()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Spell of Wind", "When a spell bearing this sigil is played, all cards on your side of the board will become airborne.", typeof(SigilCode.WindSpell), Tools.getImage("spell of wind_ability.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.getImage("spell of wind_ability.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			newAbility.powerLevel = 10;
			SigilCode.WindSpell.ability = newAbility.ability;
		}

		public static void WhirlwindSpellAbility()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Ruckus", "When a card bearing this sigil is played, all cards on the board will move clockwise.", typeof(SigilCode.WhirlwindSpell), Tools.getImage("spell of whirlwind.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.getImage("spell of whirlwind.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			newAbility.powerLevel = 3;
			SigilCode.WhirlwindSpell.ability = newAbility.ability;
		}

		public static void WaterSpellAbility()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Spell of Water", "When a spell bearing this sigil is played, every card on the board will have their sigils erased.", typeof(SigilCode.WaterSpell), Tools.getImage("spell of water_ability.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.getImage("spell of water_ability.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			newAbility.powerLevel = 10;
			SigilCode.WaterSpell.ability = newAbility.ability;
		}

		public static void FlameSpellAbility()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Engulf", "When a spell bearing this sigil is played, both players will take 1 direct damage for 3 turns, at the start of every turn.", typeof(SigilCode.Engulf), Tools.getImage("spell of flame_ability.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.getImage("spell of flame_ability.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			newAbility.powerLevel = 10;
			SigilCode.Engulf.ability = newAbility.ability;
		}

		public static void MagnusSpellAbility()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "One Time Spell", "When the turn ends, a spell bearing this sigil will perish and be removed from your deck.", typeof(SigilCode.OneTimeSpell), Tools.getImage("spellclock.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.getImage("spellclock.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			newAbility.powerLevel = 10;
			SigilCode.OneTimeSpell.ability = newAbility.ability;
		}

		public static void VaseofGreedAbility()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Vase of Greed", "When a spell bearing this sigil is played, discard your current hand and draw 4 new cards.", typeof(SigilCode.VaseofGreed), Tools.getImage("vase of greed_ability.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.getImage("vase of greed_ability.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			newAbility.powerLevel = 10;
			SigilCode.VaseofGreed.ability = newAbility.ability;
		}

		public static void GnomeAbility()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Gnomification", "Select a slot to summon a Gnome card in.", typeof(SigilCode.GnomeSpell), Tools.getImage("trasgnomification.png"))
				.SetDefaultPart1Ability()
				.SetPixelAbilityIcon(Tools.getImage("pixelability_trasgnomification.png"))
				.SetIcon(Tools.getImage("trasgnomification.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			newAbility.powerLevel = 10;
			SigilCode.GnomeSpell.ability = newAbility.ability;
		}

		public static void CursedAbility()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Cursed", "When a spell bearing this sigil is played, it will immediately perish.", typeof(SigilCode.Cursed), Tools.getImage("cursed ability.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.getImage("cursed ability.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			newAbility.powerLevel = 10;
			SigilCode.Cursed.ability = newAbility.ability;
		}

		public static void InspirationAbility()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Inspiration", "Select a card to give Airborne + Looter for 1 turn.", typeof(SigilCode.OrluInspiration), Tools.getImage("spell_orlusinsperationA.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.getImage("spell_orlusinsperationA.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			newAbility.powerLevel = 10;
			SigilCode.OrluInspiration.ability = newAbility.ability;
		}

		public static void CalculusAbility()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Calculus", "Select a card to swap stats.", typeof(SigilCode.BleeneCalculus), Tools.getImage("spell_bleenecalculusA.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.getImage("spell_bleenecalculusA.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			newAbility.powerLevel = 10;
			SigilCode.BleeneCalculus.ability = newAbility.ability;
		}

		public static void RageAbility()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Rage", "Select a card to kill. The opponent of the card will recieve damage equal to the amount of health the card had.", typeof(SigilCode.GoranjRage), Tools.getImage("spell_goranjrageA.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.getImage("spell_goranjrageA.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			newAbility.powerLevel = 10;
			SigilCode.GoranjRage.ability = newAbility.ability;
		}

		public static void FireballAbility()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Fireball", "Select a card to take 2 damage.", typeof(SigilCode.Fireball), Tools.getImage("fireballA.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.getImage("fireballA.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			newAbility.powerLevel = 10;
			SigilCode.Fireball.ability = newAbility.ability;
		}

		public static void FrostyAbility()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Cold to the Touch", "When a card bearing this sigils attack another card, that card will lose 1 attack.", typeof(SigilCode.FrostyA), Tools.getImage("frosty.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.getImage("frosty.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			newAbility.powerLevel = 4;
			SigilCode.FrostyA.ability = newAbility.ability;
		}

		public static void FrozenAbility()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Frozen", "At the end of each turn, this card will lose its frozen health. When all frozen health is depleted, or this card is struck, it will defrost.", typeof(SigilCode.Frozen), Tools.getImage("frozen.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.getImage("frozen.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			newAbility.powerLevel = -1;
			SigilCode.Frozen.ability = newAbility.ability;
		}

		public static void StrongPullAbility()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Strong Pull", "Every opposing card will be inclined to hit this card instead of any other.", typeof(SigilCode.StrongPull), Tools.getImage("strongpull.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.getImage("strongpull.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			newAbility.powerLevel = 10;
			SigilCode.StrongPull.ability = newAbility.ability;
		}

		public static void Displacement()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Displacement", "When a card bearing this sigil is drawn, another of this card will be added randomly into your deck", typeof(SigilCode.AddCardToDeck), Tools.getImage("displacement.png"))
				.SetDefaultPart1Ability()
				.SetPixelAbilityIcon(Tools.getImage("displacement_pixel.png"))
				.SetIcon(Tools.getImage("displacement.png"));
			newAbility.powerLevel = 2;
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			SigilCode.AddCardToDeck.ability = newAbility.ability;
		}

		public static void GemReckoning()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Gem Reckoning", "At the end of each turn, if the owner of this card does not control any gems, the leftmost card in your hand is discarded.", typeof(SigilCode.DiscardCards), Tools.getImage("ability_gemreckoning.png"))
				.SetDefaultPart1Ability()
				.SetPixelAbilityIcon(Tools.getImage("pixelability_gemreckoning.png"))
				.SetIcon(Tools.getImage("ability_gemreckoning.png"));
			newAbility.powerLevel = -3;
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			SigilCode.DiscardCards.ability = newAbility.ability;
		}

	}
}
