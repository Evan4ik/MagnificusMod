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

namespace MagnificusMod
{
    class RipIdle
    {
		//rotate the nodes


		[HarmonyPatch(typeof(SpiderIdleEvent), "EventSequence")]
		public class spiderlol
		{
			// Token: 0x060000CA RID: 202 RVA: 0x0000D9E5 File Offset: 0x0000BBE5
			public static IEnumerator Postfix(IEnumerator enumerator)
			{
				yield break;
			}
		}

		// Token: 0x0200003D RID: 61
		[HarmonyPatch(typeof(LookOffIdleEvent), "EventSequence")]
		public class spiderlol2
		{
			// Token: 0x060000CC RID: 204 RVA: 0x0000D9FD File Offset: 0x0000BBFD
			public static IEnumerator Postfix(IEnumerator enumerator)
			{
				yield break;
			}
		}

		// Token: 0x0200003E RID: 62
		[HarmonyPatch(typeof(FingerTappingIdleEvent), "EventSequence")]
		public class spiderlol3
		{
			// Token: 0x060000CE RID: 206 RVA: 0x0000DA15 File Offset: 0x0000BC15
			public static IEnumerator Postfix(IEnumerator enumerator)
			{
				yield break;
			}
		}
	}
}
