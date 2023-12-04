using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using BepInEx.Configuration;
using System.Reflection;
using APIPlugin;
using InscryptionAPI.Saves;
using HarmonyLib;
using InscryptionAPI.Helpers;
using BepInEx;
using DiskCardGame;
using UnityEngine;
using Infiniscryption.Achievements;
using InscryptionAPI.Sound;

namespace MagnificusMod
{
   public class Achievements
    {
        public const string PluginGuid = "silenceman.inscryption.magnificusmod";

        internal static Achievement MagicalLabyrinth { get; private set; }
        internal static Achievement BlackSkullDragon { get; private set; }
        internal static Achievement RushRecklessly { get; private set; }
        internal static Achievement HumanoidSlime { get; private set; }
        internal static Achievement HeadlessKnight { get; private set; }
        internal static Achievement QuickSummon { get; private set; }
        internal static Achievement MischiefOfTheTimeGoddess { get; private set; }
        internal static Achievement CrowningOfTheEmperor { get; private set; }
        internal static Achievement BlueEyesWhiteDragon { get; private set; }
        internal static Achievement CardofSacrifice { get; private set; }
        internal static Achievement OwloftheBlackForest { get; private set; }
        public static void addAchievements()
        {
            var groupId = ModdedAchievementManager.NewGroup(
                "silenceman.inscryption.magnificusmod",       // plugin guid
                "Magnificus Mod Achievements", // achievement group name
                "pixel_magnificus_greeting",              
                Tools.getImage("achievement_locked.png") 
            ).ID;

            
            MagicalLabyrinth = ModdedAchievementManager.New(
                PluginGuid,       
                "Magical Labyrinth",  
                "Defeat the final boss.", 
                false,                  
                groupId,
                Tools.getImage("achievement_magnificus.png")
            ).ID;
            
            BlackSkullDragon = ModdedAchievementManager.New(
                PluginGuid,
                "Crystal Skull",
                "Complete a run with every challenge active, and no anti challenges. (You may use the map)",
                false,
                groupId,
                Tools.getImage("achievement_crystalskull.png")
            ).ID;

            HumanoidSlime = ModdedAchievementManager.New(
                PluginGuid,
                "Humanoid Slime",
                "Defeat the first boss without having any cards get their power reduced at the start of phase 2.",
                false,
                groupId,
                Tools.getImage("achievement_goobert.png")
            ).ID;

            HeadlessKnight = ModdedAchievementManager.New(
                PluginGuid,
                "Headless Knight",
                "Defeat the second boss without triggering any Enchanted Spears.",
                false,
                groupId,
                Tools.getImage("achievement_amber.png")
            ).ID;

            QuickSummon = ModdedAchievementManager.New(
                PluginGuid,
                "Quick Summon",
                "Defeat the third boss without letting the turn timer expire once.",
                false,
                groupId,
                Tools.getImage("achievement_lonely.png")
            ).ID;

            MischiefOfTheTimeGoddess = ModdedAchievementManager.New(
                PluginGuid,
                "Mischief of the Time Goddess",
                "Let the third boss's timer run out 5 times, and still win the fight.",
                false,
                groupId,
                Tools.getImage("achievement_timegoddess.png")
            ).ID;

            RushRecklessly = ModdedAchievementManager.New(
                PluginGuid,
                "Rush Recklessly",
                "Defeat the first boss after using only 3 or less events.",
                false,
                groupId,
                Tools.getImage("achievement_rush.png")
            ).ID;

            CrowningOfTheEmperor = ModdedAchievementManager.New(
                PluginGuid,
                "Crowning of the Emperor",
                "???",
                true,
                groupId,
                Tools.getImage("achievement_gnome.png")
            ).ID;

            BlueEyesWhiteDragon = ModdedAchievementManager.New(
                PluginGuid,
                "Blue Eyes White Dragon",
                "Deal 10 damage in a single turn.",
                false,
                groupId,
                Tools.getImage("achievement_dragon.png")
            ).ID;

            CardofSacrifice = ModdedAchievementManager.New(
               PluginGuid,
               "Card of Sacrifice",
               "Have 10 or less cards by the time you reach the final boss.",
               false,
               groupId,
               Tools.getImage("achievement_sacrifice.png")
           ).ID;

            OwloftheBlackForest = ModdedAchievementManager.New(
                PluginGuid,
                "Owl of the Black Forest",
                "Banish the Ficticious Master Magnus.",
                true,
                groupId,
                Tools.getImage("achievement_magnus.png")
            ).ID;
        }
    }
}
