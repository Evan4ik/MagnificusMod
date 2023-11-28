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
using SigilCode = MagnificusMod.SigilCode;

namespace MagnificusMod
{
    class MagSigils
    {
		public static void ChangeMox()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Blank Mox", "When a card bearing this sigil is drawn, it will materialize into a random Mox Crystal. \n When on another card, the card will generate a random Mox Crystal.", typeof(SigilCode.MoxRandom), Tools.GetTexture("random mox icon.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.GetTexture("random mox icon.png"));
			SigilCode.MoxRandom.ability = newAbility.ability;

		}

		public static void DropRuby()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Ruby Heart", "When a card bearing this sigil perishes, it creates a Ruby Mox in its place.", typeof(SigilCode.MagDropRubyOnDeath), Tools.GetTexture("mag_dropruby.png"))
				.SetDefaultPart1Ability()
				.SetPixelAbilityIcon(Resources.Load("art/gbc/cards/pixelabilityicons/pixelability_droprubyondeath") as Texture2D)
				.SetIcon(Tools.GetTexture("mag_dropruby.png"));
			SigilCode.MagDropRubyOnDeath.ability = newAbility.ability;
		}

		public static void Stimulate()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Stimulation", "At the end of every turn, a card bearing this sigils gains 1 power, maxes out at 4.", typeof(SigilCode.Stimulation), Tools.GetTexture("stimulationability.png"))
				.SetDefaultPart1Ability()
				.SetPixelAbilityIcon(Tools.GetTexture("stimulation_pixel.png"))
				.SetIcon(Tools.GetTexture("stimulationability.png"));
			SigilCode.Stimulation.ability = newAbility.ability;
		}

		public static void StimulateHP()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Stimulation (Health)", "At the end of every turn, a card bearing this sigils gains 2 health, maxes out at 10.", typeof(SigilCode.StimulationHP), Tools.GetTexture("stimulationhealth.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.GetTexture("stimulationhealth.png"));
			SigilCode.StimulationHP.ability = newAbility.ability;
		}

		public static void Bleene()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Dead Draw", "When a card dies, draw two cards from your deck.", typeof(SigilCode.BleeneDraw), Tools.GetTexture("mag_bleeneability.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.GetTexture("mag_bleeneability.png"));
			SigilCode.BleeneDraw.ability = newAbility.ability;
		}

		public static void DropEmerald()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Emerald Heart", "When a card bearing this sigil perishes, it creates an Emerald Mox in its place.", typeof(SigilCode.MagDropEmeraldOnDeath), Tools.GetTexture("mag_dropemerald.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.GetTexture("mag_dropemerald.png"));
			SigilCode.MagDropEmeraldOnDeath.ability = newAbility.ability;
		}

		public static void Goobert()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Gooey", "When a card bearing this sigil is struck, the striker loses 1 attack.", typeof(SigilCode.GoobertDebuff), Tools.GetTexture("mag_goobertability.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.GetTexture("mag_goobertability.png"));
			newAbility.canStack = true;
			SigilCode.GoobertDebuff.ability = newAbility.ability;
		}

		public static void BMDraw()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Mental Gemnastics", "When a card bearing this sigil is played, draw cards from your deck based on how many Gems are on the board.", typeof(SigilCode.BlueMageDraw), Tools.GetTexture("mag_bluemagedraw.png"))

				.SetDefaultPart1Ability()
				.SetPixelAbilityIcon(Resources.Load("art/gbc/cards/pixelabilityicons/pixelability_gemsdraw") as Texture2D)
				.SetIcon(Tools.GetTexture("mag_bluemagedraw.png"));
			newAbility.canStack = true;
			SigilCode.BlueMageDraw.ability = newAbility.ability;
		}

		public static void LootOrlu()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Loot", "When a card bearing this sigil deals direct damage, draw cards from your deck based on how much damage was dealt.", typeof(SigilCode.OrluHit), Tools.GetTexture("mag_loot.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.GetTexture("mag_loot.png"));
			SigilCode.OrluHit.ability = newAbility.ability;
		}

		public static void AddLifeSteal()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Life Steal", "When a card bearing this sigil deals direct damage, the amount dealt will be healed to the owner of this card.", typeof(SigilCode.LifeSteal), Tools.GetTexture("lifesteal.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.GetTexture("lifesteal.png"));
			SigilCode.LifeSteal.ability = newAbility.ability;
		}

		public static void SharkoHit()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Knockback Hit", "When a card bearing this sigil hits an opposing card, the opposing card will be kicked in the direction inscrybed in the sigil.", typeof(SigilCode.sharkoKick), Tools.GetTexture("sharko_kick.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.GetTexture("sharko_kick.png"));
			SigilCode.sharkoKick.ability = newAbility.ability;
		}
		public static void DropSpear()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Impaled", "When a card bearing this sigil perishes, it creates a Spear in its placed. A spear is defined as Sharp, 0 power, 3 health.", typeof(SigilCode.MagDropSpear), Tools.GetTexture("mag_impaled.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.GetTexture("mag_impaled.png"));
			SigilCode.MagDropSpear.ability = newAbility.ability;
		}

		public static void MagGainGemTriple()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Magnus Mox", "While a card bearing this sigil is on the board, it provides an orange gem, a blue gem and a green gem to its owner.", typeof(SigilCode.MagGainGemTriple), Tools.GetTexture("gaingemtriple.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.GetTexture("gaingemtriple.png"));
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
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "1 Up", "When a card bearing this sigil is played, and another card on the board perishes, the dead card will be brought back to life, but this card loses 3 health.", typeof(SigilCode.LifeUpOmega), Tools.GetTexture("1up.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.GetTexture("1up.png"));
			SigilCode.LifeUpOmega.ability = newAbility.ability;
		}

		public static void ReRoll()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Rerolls", "At the end of every turn, a card bearing this sigils' power will be randomized.", typeof(SigilCode.RandomPower), Tools.GetTexture("diceability.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.GetTexture("diceability.png"));
			SigilCode.RandomPower.ability = newAbility.ability;
		}

		public static void ImprovedTrap()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Steel Trap", "When a card bearing this sigil perishes, the opposing card also perishes.", typeof(SigilCode.ImprovedSteelTrap), Tools.GetTexture("ability_steeltrap.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.GetTexture("ability_steeltrap.png"));
			newAbility.powerLevel = 10;
			SigilCode.ImprovedSteelTrap.ability = newAbility.ability;
		}

		public static void GemGuard()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Gem Shield", "When a card bearing this sigil is played, all gems on the board gain a shield.", typeof(SigilCode.GemGuardianFix), Tools.GetTexture("ability_shieldgems.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.GetTexture("ability_shieldgems.png"));
			SigilCode.GemGuardianFix.ability = newAbility.ability;
		}

		public static void PlatingWork()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Plating Work", "When a card bearing this sigil is played, all gems on the board gain the Sharp sigil, and 2 health.", typeof(SigilCode.PlatingWork), Tools.GetTexture("whitesmith_A.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.GetTexture("whitesmith_A.png"));
			SigilCode.PlatingWork.ability = newAbility.ability;
		}

		public static void Animator()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Animator", "While a card bearing this sigil is on the board, all non-mox cards with 0 power gain 2 power", typeof(SigilCode.Animator), Tools.GetTexture("animator.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.GetTexture("animator.png"));
			SigilCode.Animator.ability = newAbility.ability;
		}

		public static void GemAbsorb()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Gem Absorber", "When a card bearing this sigil is played, all gems on the board will perish. For each gem absorbed, gain 1 power and 2 health.", typeof(SigilCode.GemAbsorber), Tools.GetTexture("ability_absorbgems.png"))
				.SetDefaultPart1Ability()
				.SetPixelAbilityIcon(Tools.GetTexture("pixelability_absorbgems.png"))
				.SetIcon(Tools.GetTexture("ability_absorbgems.png"));
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
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Submerge", "At the end of the turn, a card bearing this sigil will submerge. Upon resubmerging, this card will become a random Tentacle Card.", typeof(SigilCode.submergekraken), Tools.GetTexture("krakensubmerge.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.GetTexture("krakensubmerge.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			SigilCode.submergekraken.ability = newAbility.ability;
		}

		public static void Familiar()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Familiar", "A card bearing this sigil will perish if there are no non-gem cards on the board.", typeof(SigilCode.FamiliarA), Tools.GetTexture("familiar.png"))
				.SetDefaultPart1Ability()
				.SetPixelAbilityIcon(Tools.GetTexture("pixelability_familiar.png"))
				.SetIcon(Tools.GetTexture("familiar.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			SigilCode.FamiliarA.ability = newAbility.ability;
		}

		public static void Fading()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Fading", "A card bearing this sigil will perish at the end of the turn.", typeof(SigilCode.FadingA), Tools.GetTexture("fading.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.GetTexture("fading.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			SigilCode.FadingA.ability = newAbility.ability;
		}

		public static void DittoAbility()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Morph", "When a card bearing this sigil is played, it will mimic the card opposing it. If there is no card opposing it, this card will perish.", typeof(SigilCode.Ditto), Tools.GetTexture("transformability.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.GetTexture("transformability.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			SigilCode.Ditto.ability = newAbility.ability;
		}

		public static void FecundityCycleAbility()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Multiplication", "When a card bearing this sigil is played, draw another of this card, but with a different gem cost.", typeof(SigilCode.FecundityCycle), Tools.GetTexture("multiply.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.GetTexture("multiply.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			SigilCode.FecundityCycle.ability = newAbility.ability;
		}

		public static void MoxCycle()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Mox Cycle", "At the end of every turn, all the mox on the board will cycle into different gems.", typeof(SigilCode.MoxCycling), Tools.GetTexture("moxcycle.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.GetTexture("moxcycle.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			SigilCode.MoxCycling.ability = newAbility.ability;
		}

		public static void MoxStrf()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Mox Strafe", "At the end of the turn, this card will move to the direction inscrybed on the sigil, and leave behind a mox.", typeof(SigilCode.MoxStrafe), Tools.GetTexture("moxstrafe.png"))
				.SetDefaultPart1Ability()
				.SetPixelAbilityIcon(Tools.GetTexture("pixelability_moxstrafe.png"))
				.SetIcon(Tools.GetTexture("moxstrafe.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			SigilCode.MoxStrafe.ability = newAbility.ability;
		}

		public static void Purity()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Purist", "Any card directly opposing this one will have all it's sigils removed.", typeof(SigilCode.NullifySigils), Tools.GetTexture("purist.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.GetTexture("purist.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			SigilCode.NullifySigils.ability = newAbility.ability;
		}

		public static void Brewery()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Brewery", "At the end of every turn, you automatically draw a mox card from your side deck.", typeof(SigilCode.DrawMoxFromSideDeck), Tools.GetTexture("brewery.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.GetTexture("brewery.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			SigilCode.DrawMoxFromSideDeck.ability = newAbility.ability;
		}
		public static void Ignition()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Ignite", "When a card bearing this sigil is played, every empty opposing slot will be filled with flames. A flame is defined as a 0/1, Annoying.", typeof(SigilCode.Ignite), Tools.GetTexture("igniteability.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.GetTexture("igniteability.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			SigilCode.Ignite.ability = newAbility.ability;
		}

		public static void SpellBookSigil()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Spell Book", "When a card bearing this sigil is played, draw a random spell card.", typeof(SigilCode.DrawSpell), Tools.GetTexture("spellbooksigil.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.GetTexture("spellbooksigil.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			SigilCode.DrawSpell.ability = newAbility.ability;
		}

		public static void MidasTouch()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Midas' Touch", "When a card bearing this sigil attacks another card, the attacked card will gain 2 health, lose all of it's attack and turn to gold.", typeof(SigilCode.MidasTouchA), Tools.GetTexture("midas touch.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.GetTexture("midas touch.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			SigilCode.MidasTouchA.ability = newAbility.ability;
		}

		public static void MadeOfGold()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Made of Gold", "When a card bearing this sigil perishes, the killer will gain 2 mana crystals.", typeof(SigilCode.DropMana), Tools.GetTexture("goldenA.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.GetTexture("goldenA.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			SigilCode.DropMana.ability = newAbility.ability;
		}

		public static void SummonRunes()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Summon Runes", "When a card bearing this sigil is played, it will summon two runes beside it. A rune is defined as 0 power, 1 health, Detonator.", typeof(SigilCode.SummonRunes), Tools.GetTexture("spawnrunes.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.GetTexture("spawnrunes.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			SigilCode.SummonRunes.ability = newAbility.ability;
		}

		public static void HPSpellAbility()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Spell of Health", "When a spell bearing this sigil is played, all cards on your side of the board gain +2 health.", typeof(SigilCode.HPSpell), Tools.GetTexture("hpspell_ability.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.GetTexture("hpspell_ability.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			newAbility.powerLevel = 10;
			SigilCode.HPSpell.ability = newAbility.ability;
		}

		public static void ATKSpellAbility()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Spell of Attack", "When a spell bearing this sigil is played, all cards on your side of the board gain +1 attack.", typeof(SigilCode.ATKSpell), Tools.GetTexture("atkspell_ability.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.GetTexture("atkspell_ability.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			newAbility.powerLevel = 10;
			SigilCode.ATKSpell.ability = newAbility.ability;
		}

		public static void FrostSpellAbility()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Frost Spell", "When a spell bearing this sigil is played, all cards belonging to the opponent will have their attack set to 0, but given +2 health.", typeof(SigilCode.FrostSpell), Tools.GetTexture("spell of frost_ability.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.GetTexture("spell of frost_ability.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			newAbility.powerLevel = 10;
			SigilCode.FrostSpell.ability = newAbility.ability;
		}

		public static void TargetFrostSpellAbility()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Spell of Frost", "Select a side of the board to freeze over, all cards belonging to the selected side will have their attack set to 0, but given +2 health.", typeof(SigilCode.TargetFrost), Tools.GetTexture("spell of frost_ability.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.GetTexture("spell of frost_ability.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			newAbility.powerLevel = 10;
			SigilCode.TargetFrost.ability = newAbility.ability;
		}

		public static void GoldSpellAbility()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Gold Rush", "When a spell bearing this sigil is played, all cards belonging to the opponent will have their attack set to 0, but given +2 health and the Made Of Gold sigil.", typeof(SigilCode.GoldSpell), Tools.GetTexture("spell of gold_ability.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.GetTexture("spell of gold_ability.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			newAbility.powerLevel = 10;
			SigilCode.GoldSpell.ability = newAbility.ability;
		}

		public static void WindSpellAbility()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Spell of Wind", "When a spell bearing this sigil is played, all cards on your side of the board will become airborne.", typeof(SigilCode.WindSpell), Tools.GetTexture("spell of wind_ability.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.GetTexture("spell of wind_ability.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			newAbility.powerLevel = 10;
			SigilCode.WindSpell.ability = newAbility.ability;
		}

		public static void WhirlwindSpellAbility()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Spell of Whirlwind", "When a spell bearing this sigil is played, all cards on the board will move clockwise.", typeof(SigilCode.WhirlwindSpell), Tools.GetTexture("spell of whirlwind.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.GetTexture("spell of whirlwind.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			newAbility.powerLevel = 10;
			SigilCode.WhirlwindSpell.ability = newAbility.ability;
		}

		public static void WaterSpellAbility()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Spell of Water", "When a spell bearing this sigil is played, every card on the board will have their sigils erased.", typeof(SigilCode.WaterSpell), Tools.GetTexture("spell of water_ability.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.GetTexture("spell of water_ability.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			newAbility.powerLevel = 10;
			SigilCode.WaterSpell.ability = newAbility.ability;
		}

		public static void FlameSpellAbility()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Flame Spell", "When a spell bearing this sigil is played, every opponent card will have their health set to 1, but have their attack increased by 1.", typeof(SigilCode.FlameSpell), Tools.GetTexture("spell of flame_ability.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.GetTexture("spell of flame_ability.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			newAbility.powerLevel = 10;
			SigilCode.FlameSpell.ability = newAbility.ability;
		}

		public static void TargetFlameSpellAbility()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Spell of Flame", "Select a side of the board, every card on that side will have their health set to 1, but have their attack increased by 1.", typeof(SigilCode.TargetFlame), Tools.GetTexture("spell of flame_ability.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.GetTexture("spell of flame_ability.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			newAbility.powerLevel = 10;
			SigilCode.TargetFlame.ability = newAbility.ability;
		}

		public static void MagnusSpellAbility()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "One Time Spell", "When the turn ends, a spell bearing this sigil will perish and be removed from your deck.", typeof(SigilCode.OneTimeSpell), Tools.GetTexture("spellclock.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.GetTexture("spellclock.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			newAbility.powerLevel = 10;
			SigilCode.OneTimeSpell.ability = newAbility.ability;
		}

		public static void VaseofGreedAbility()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Vase of Greed", "When a spell bearing this sigil is played, discard your current hand and draw 4 new cards.", typeof(SigilCode.VaseofGreed), Tools.GetTexture("vase of greed_ability.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.GetTexture("vase of greed_ability.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			newAbility.powerLevel = 10;
			SigilCode.VaseofGreed.ability = newAbility.ability;
		}

		public static void GnomeAbility()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Trasgnomification", "When a spell bearing this sigil is played, a gnome will be placed in the opposing slot, any cards in the opposing slot will be replaced.", typeof(SigilCode.GnomeSpell), Tools.GetTexture("trasgnomification.png"))
				.SetDefaultPart1Ability()
				.SetPixelAbilityIcon(Tools.GetTexture("pixelability_trasgnomification.png"))
				.SetIcon(Tools.GetTexture("trasgnomification.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			newAbility.powerLevel = 10;
			SigilCode.GnomeSpell.ability = newAbility.ability;
		}

		public static void CursedAbility()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Cursed", "When a spell bearing this sigil is played, it will immediately perish.", typeof(SigilCode.Cursed), Tools.GetTexture("cursed ability.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.GetTexture("cursed ability.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			newAbility.powerLevel = 10;
			SigilCode.Cursed.ability = newAbility.ability;
		}

		public static void InspirationAbility()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Inspiration", "Select a card to give Airborne + Looter for 1 turn.", typeof(SigilCode.OrluInspiration), Tools.GetTexture("spell_orlusinsperationA.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.GetTexture("spell_orlusinsperationA.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			newAbility.powerLevel = 10;
			SigilCode.OrluInspiration.ability = newAbility.ability;
		}

		public static void CalculusAbility()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Calculus", "Select a card to swap stats.", typeof(SigilCode.BleeneCalculus), Tools.GetTexture("spell_bleenecalculusA.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.GetTexture("spell_bleenecalculusA.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			newAbility.powerLevel = 10;
			SigilCode.BleeneCalculus.ability = newAbility.ability;
		}

		public static void RageAbility()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Rage", "Select a card to kill. The opponent of the card will recieve damage equal to the amount of health the card had.", typeof(SigilCode.GoranjRage), Tools.GetTexture("spell_goranjrageA.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.GetTexture("spell_goranjrageA.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			newAbility.powerLevel = 10;
			SigilCode.GoranjRage.ability = newAbility.ability;
		}

		public static void FireballAbility()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Fireball", "Select a card to take 1 damage, twice.", typeof(SigilCode.Fireball), Tools.GetTexture("fireballA.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.GetTexture("fireballA.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			newAbility.powerLevel = 10;
			SigilCode.Fireball.ability = newAbility.ability;
		}

		public static void FrostyAbility()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Frosty", "When a card bearing this sigils attack another card, that card will lose 1 attack.", typeof(SigilCode.FrostyA), Tools.GetTexture("frosty.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.GetTexture("frosty.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			newAbility.powerLevel = 4;
			SigilCode.FrostyA.ability = newAbility.ability;
		}

		public static void StrongPullAbility()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Strong Pull", "Every opposing card will be inclined to hit this card instead of any other.", typeof(SigilCode.StrongPull), Tools.GetTexture("strongpull.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.GetTexture("strongpull.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			newAbility.powerLevel = 10;
			SigilCode.StrongPull.ability = newAbility.ability;
		}

		public static void Displacement()
		{
			AbilityInfo newAbility = AbilityManager.New(Plugin.PluginGuid, "Displacement", "When a card bearing this sigil is drawn, another of this card will be added randomly into your deck", typeof(SigilCode.AddCardToDeck), Tools.GetTexture("displacement.png"))
				.SetDefaultPart1Ability()
				.SetPixelAbilityIcon(Tools.GetTexture("displacement_pixel.png"))
				.SetIcon(Tools.GetTexture("displacement.png"));
			newAbility.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
			SigilCode.AddCardToDeck.ability = newAbility.ability;
		}

	}
}
