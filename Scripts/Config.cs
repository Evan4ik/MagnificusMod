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

namespace MagnificusMod
{
   public class config
    {
        private const string PluginGuid = "silenceman.inscryption.magnificusmod";

        private static ConfigEntry<bool> _kayceeProgression;
        private static ConfigEntry<bool> _conifgCardBalance;
        private static ConfigEntry<bool> _oldCardDesigns;
        private static ConfigEntry<bool> _paintSplashes;
        private static ConfigEntry<bool> _isometricMode;
        private static ConfigEntry<bool> _visibleGrid;
        public static bool kayceeProgression => _kayceeProgression.Value;

        public static bool classicCardBalance => _conifgCardBalance.Value;
        public static bool oldCardDesigns => _oldCardDesigns.Value;
        public static bool paintSplashes => _paintSplashes.Value;
        public static bool isometricActive => _isometricMode.Value;
        public static bool gridActive => _visibleGrid.Value;
        public static bool isometricMode
        {
            get
            {
                return SceneLoader.ActiveSceneName == "finale_magnificus" && isometricActive && RunState.Run.regionTier > 0 && RunState.Run.regionTier < 4;
            }
        }

        private static readonly ConfigFile magConfig = new ConfigFile(Path.Combine(Paths.ConfigPath, "magnificus_mod_config.cfg"), true);
        public static void bindConfig()
        {

            _kayceeProgression = magConfig.Bind("Kaycee",
                "KayceeProgression",
                false,
                "Enable to play through a sort of campaign mode in Kaycee's Mod, where you have to unlock each challenge and deck like in the vanilla game.");
           
            _conifgCardBalance = magConfig.Bind("Cards",
                 "OriginalCardBalance",
                 false,
                 "Base wizard cards from act 2 will keep their original statlines.");
            _oldCardDesigns = magConfig.Bind("Cards",
             "OldCardDesigns",
             false,
             "Use the old 2D flat card designs instead of the new 3D models.");
            _paintSplashes = magConfig.Bind("Cards",
            "Paint Splashes",
            false,
            "Add paint splashes to the background of every card (like in the original magnificus finale).");

            _isometricMode = magConfig.Bind("Tabletop",
              "TabletopMode",
              true,
              "Third person perspective for magnificus' game. Disable if you want the classic first person experience.");
            _visibleGrid = magConfig.Bind("Tabletop",
              "VisibleGrid",
              true,
              "Show a grid around the player in tabletop mode.");

        }
    }
}
