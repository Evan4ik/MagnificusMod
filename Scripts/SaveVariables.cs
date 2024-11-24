using System;
using System.Collections.Generic;
using System.Text;
using APIPlugin;
using InscryptionAPI.Saves;

namespace MagnificusMod
{
   public class SaveVariables
    {
        private const string PluginGuid = "silenceman.inscryption.magnificusmod";
        public static bool HasMap
        {
            get { return ModdedSaveManager.SaveData.GetValueAsBoolean(PluginGuid, "HasMap");  }
            set { ModdedSaveManager.SaveData.SetValue(PluginGuid, "HasMap", value); }
        }

        public static bool HasMapIcons
        {
            get { return ModdedSaveManager.SaveData.GetValueAsBoolean(PluginGuid, "HasMapIcons"); }
            set { ModdedSaveManager.SaveData.SetValue(PluginGuid, "HasMapIcons", value); }
        }
        public static int[] BossTeleportSolution
        {
            get 
            {
                int[] solutionRow = new int[] { ModdedSaveManager.SaveData.GetValueAsInt(PluginGuid, "Top"), ModdedSaveManager.SaveData.GetValueAsInt(PluginGuid, "Mid"), ModdedSaveManager.SaveData.GetValueAsInt(PluginGuid, "Bot") };
                return solutionRow;
            }
            set 
            { 
                ModdedSaveManager.SaveData.SetValue(PluginGuid, "Top", value[0]);
                ModdedSaveManager.SaveData.SetValue(PluginGuid, "Mid", value[1]);
                ModdedSaveManager.SaveData.SetValue(PluginGuid, "Bot", value[2]);
            }
        }

        public static string KilledCards
        {
            get { return ModdedSaveManager.SaveData.GetValue(PluginGuid, "KilledCards"); }
            set { ModdedSaveManager.SaveData.SetValue(PluginGuid, "KilledCards", value); }
        }

        public static int NodesCleared
        {
            get { return ModdedSaveManager.SaveData.GetValueAsInt(PluginGuid, "NodesCleared"); }
            set { ModdedSaveManager.SaveData.SetValue(PluginGuid, "NodesCleared", value); }
        }

        public static int LastBlueprint
        {
            get { return ModdedSaveManager.SaveData.GetValueAsInt(PluginGuid, "LastBlueprint"); }
            set { ModdedSaveManager.SaveData.SetValue(PluginGuid, "LastBlueprint", value); }
        }

        public static string GeneratedEvents
        {
            get { return ModdedSaveManager.SaveData.GetValue(PluginGuid, "GeneratedEvents"); }
            set { ModdedSaveManager.SaveData.SetValue(PluginGuid, "GeneratedEvents", value); }
        }

        public static string LearnedMechanics
        {
            get { return ModdedSaveManager.SaveData.GetValue(PluginGuid, "LearnedMechanics"); }
            set { ModdedSaveManager.SaveData.SetValue(PluginGuid, "LearnedMechanics", value); }
        }
    }
}
