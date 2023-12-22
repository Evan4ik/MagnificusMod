using System;
using System.Collections.Generic;
using System.Text;
using APIPlugin;
using InscryptionAPI.Saves;
namespace MagnificusMod
{
	public class KayceeStorage
	{
		private const string GUID = "silenceman.inscryption.magnificusmodstarterdecks";
		public static CardTemple ScreenState
		{

			get
			{
				string value = ModdedSaveManager.SaveData.GetValue(GUID, "ScreenState");
				return string.IsNullOrEmpty(value) ? CardTemple.Nature : (CardTemple)Enum.Parse(typeof(CardTemple), value);
			}
			set => ModdedSaveManager.SaveData.SetValue(GUID, "ScreenState", value);
		}

		public static bool IsMagRun
		{
			get
			{
				return ModdedSaveManager.SaveData.GetValueAsBoolean(GUID, "IsMagRun");
			}
			set => ModdedSaveManager.SaveData.SetValue(GUID, "IsMagRun", value);
		}

		public static bool IsKaycee
		{
			get
			{
				return ModdedSaveManager.SaveData.GetValueAsBoolean(GUID, "IsKaycee");
			}
			set => ModdedSaveManager.SaveData.SetValue(GUID, "IsKaycee", value);
		}

		public static int ChallengeLevel
		{
			get
			{
				return ModdedSaveManager.SaveData.GetValueAsInt(GUID, "ChallengeLevel");
			}
			set => ModdedSaveManager.SaveData.SetValue(GUID, "ChallengeLevel", value);
		}
		public static string ActiveChallenges
		{
			get
			{
				return ModdedSaveManager.SaveData.GetValue(GUID, "MagChallenges");
			}
			set => ModdedSaveManager.SaveData.SetValue(GUID, "MagChallenges", value);
		}

		public static string draftcards
		{
			get
			{
				return ModdedSaveManager.SaveData.GetValue(GUID, "DraftCards");
			}
			set => ModdedSaveManager.SaveData.SetValue(GUID, "DraftCards", value);
		}


		public static bool DialogueEvent1
		{
			get
			{
				return ModdedSaveManager.SaveData.GetValueAsBoolean(GUID, "DialogueE1");
			}
			set => ModdedSaveManager.SaveData.SetValue(GUID, "DialogueE1", value);
		}

		public static bool DialogueEvent2
		{
			get
			{
				return ModdedSaveManager.SaveData.GetValueAsBoolean(GUID, "DialogueE2");
			}
			set => ModdedSaveManager.SaveData.SetValue(GUID, "DialogueE2", value);
		}

		public static int FleetingLife
		{
			get
			{
				return ModdedSaveManager.SaveData.GetValueAsInt(GUID, "FleetingLife");
			}
			set => ModdedSaveManager.SaveData.SetValue(GUID, "FleetingLife", value);
		}
	}
}
