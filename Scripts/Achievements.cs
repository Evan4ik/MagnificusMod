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
        internal static Achievement CrowningOfTheEmperor { get; private set; }
        public static void addAchievements()
        {
            Debug.Log("added achievements");
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
                "Complete a run with every challenge active.",
                false,
                groupId,
                Tools.getImage("achievement_locked.png")
            ).ID;

            HumanoidSlime = ModdedAchievementManager.New(
                PluginGuid,
                "Humanoid Slime",
                "Defeat the first boss using only the cards that had their power reduced at the start of phase 2.",
                false,
                groupId,
                Tools.getImage("achievement_locked.png")
            ).ID;

            HeadlessKnight = ModdedAchievementManager.New(
                PluginGuid,
                "Headless Knight",
                "Defeat the second boss without triggering any Enchanted Spears.",
                false,
                groupId,
                Tools.getImage("achievement_locked.png")
            ).ID;

            QuickSummon = ModdedAchievementManager.New(
                PluginGuid,
                "Quick Summon",
                "Defeat the third boss without letting the turn timer expire once.",
                false,
                groupId,
                Tools.getImage("achievement_locked.png")
            ).ID;

            RushRecklessly = ModdedAchievementManager.New(
                PluginGuid,
                "Rush Recklessly",
                "Defeat the first boss after using only 3 or less events.",
                false,
                groupId,
                Tools.getImage("achievement_locked.png")
            ).ID;

            CrowningOfTheEmperor = ModdedAchievementManager.New(
                PluginGuid,
                "Crowning of the Emperor",
                "???",
                true,
                groupId,
                Tools.getImage("achievement_gnome.png")
            ).ID;
            Debug.Log(MagicalLabyrinth);
        }
    }
}
