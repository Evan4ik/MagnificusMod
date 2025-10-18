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
            get { return ModdedSaveManager.SaveData.GetValueAsBoolean(PluginGuid, "HasMap"); }
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

        public static int[] AscensionStats
        {
            get
            {
                int[] stats = new int[] { ModdedSaveManager.SaveData.GetValueAsInt(PluginGuid, "AS_Mox"), ModdedSaveManager.SaveData.GetValueAsInt(PluginGuid, "AS_DamageTaken"),
                  ModdedSaveManager.SaveData.GetValueAsInt(PluginGuid, "AS_DamageDealt"), ModdedSaveManager.SaveData.GetValueAsInt(PluginGuid, "AS_Nodes"), ModdedSaveManager.SaveData.GetValueAsInt(PluginGuid, "AS_Brilliance") };
                return stats;
            }
            set
            {
                ModdedSaveManager.SaveData.SetValue(PluginGuid, "AS_Mox", value[0]);
                ModdedSaveManager.SaveData.SetValue(PluginGuid, "AS_DamageTaken", value[1]);
                ModdedSaveManager.SaveData.SetValue(PluginGuid, "AS_DamageDealt", value[2]);
                ModdedSaveManager.SaveData.SetValue(PluginGuid, "AS_Nodes", value[3]);
                ModdedSaveManager.SaveData.SetValue(PluginGuid, "AS_Brilliance", value[4]);

            }
        }


        public static int AS_Mox
        {
            get { return ModdedSaveManager.SaveData.GetValueAsInt(PluginGuid, "AS_Mox"); }
            set { ModdedSaveManager.SaveData.SetValue(PluginGuid, "AS_Mox", value); }
        }

        public static int AS_DamageTaken
        {
            get { return ModdedSaveManager.SaveData.GetValueAsInt(PluginGuid, "AS_DamageTaken"); }
            set { ModdedSaveManager.SaveData.SetValue(PluginGuid, "AS_DamageTaken", value); }
        }

        public static int AS_DamageDealt
        {
            get { return ModdedSaveManager.SaveData.GetValueAsInt(PluginGuid, "AS_DamageDealt"); }
            set { ModdedSaveManager.SaveData.SetValue(PluginGuid, "AS_DamageDealt", value); }
        }

        public static int AS_Nodes
        {
            get { return ModdedSaveManager.SaveData.GetValueAsInt(PluginGuid, "AS_Nodes"); }
            set { ModdedSaveManager.SaveData.SetValue(PluginGuid, "AS_Nodes", value); }
        }

        public static int AS_Brilliance
        {
            get { return ModdedSaveManager.SaveData.GetValueAsInt(PluginGuid, "AS_Brilliance"); }
            set { ModdedSaveManager.SaveData.SetValue(PluginGuid, "AS_Brilliance", value); }
        }



    }
}
