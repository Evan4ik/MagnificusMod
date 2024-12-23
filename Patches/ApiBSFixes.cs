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

namespace MagnificusMod
{
    class FixTheAPIBullshit
    {
		//Hello, User! This file intends to add functionality to the API, The functions being: Making the API not cause crashes or softlocks in this mod! 
		//This is definetly per fault of Magnificus' Mod and in NO way part of the API.
		//Sorry for zee rudeness


		[HarmonyAfter(new string[] { "community.inscryption.patch" })]
		[HarmonyPatch(typeof(InscryptionCommunityPatch.Card.ActivatedAbilityIconFix), "FixActivatedAbilitiesOnAnyChange")]
		public class activatedCrashFix
		{
			public static bool Prefix()
			{
				if (SceneLoader.ActiveSceneName == "finale_magnificus") { return false; }
				return true;
			}
		}

		[HarmonyAfter(new string[] { "community.inscryption.patch" })]
		[HarmonyPatch(typeof(InscryptionCommunityPatch.ResourceManagers.EnergyDrone), "CurrentSceneCanHaveEnergyDrone", MethodType.Getter)]
		public class fixmoreapibullshit
		{
			public static bool Prefix(ref bool __result)
			{
				if (SceneLoader.ActiveSceneName != "finale_magnificus") { return true; }
				__result = false;
				return false;
			}
		}
	}
}
