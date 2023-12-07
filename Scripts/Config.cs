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

        private static ConfigEntry<bool> _configUnlockAllKaycee;
        private static ConfigEntry<bool> _isometricMode;
        public static bool unlockAllKaycee => _configUnlockAllKaycee.Value;
        public static bool isometricMode = false;//=> _isometricMode.Value;

        private static readonly ConfigFile magConfig = new ConfigFile(Path.Combine(Paths.ConfigPath, "magnificus_mod_config.cfg"), true);
        public static void bindConfig()
        {

            _configUnlockAllKaycee = magConfig.Bind("Kaycee",
                "UnlockAllKaycee",
                false,
                "Automatically unlocks every challenge and starter deck in Magnificus' Kaycees Mod. This does NOT change your magnificus challenge point value. If you have a change of heart and decide to unlock the challenges fairly, your challenge points will remain the same.");
            //_isometricMode = magConfig.Bind("Isometric",
             // "IsometricMode",
              //false,
              //"new experimental isometric mode");
              //disabled for this patch, will be reneabled later
        }
    }
}
