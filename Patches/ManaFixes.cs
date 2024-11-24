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
using MagSave = MagnificusMod.MagCurrentNode;
using SavedVars = MagnificusMod.SaveVariables;
using KayceeStorage = MagnificusMod.KayceeStorage;

namespace MagnificusMod
{
    class ManaFixes
    {
		[HarmonyPatch(typeof(WeightUtil), "WeightPrefab", MethodType.Getter)]
		public class MANASCALES
		{
			public static void Prefix()
			{
				WeightUtil.part1Prefab = ResourceBank.Get<GameObject>("Prefabs/Environment/ScaleWeights/Weight");
				if (SceneLoader.ActiveSceneName == "finale_magnificus")
				{
					WeightUtil.part1Prefab = ResourceBank.Get<GameObject>("Prefabs/Environment/ScaleWeights/Weight");

					bool flag2 = GameObject.Find("mana") == null;
					GameObject gameObject;
					if (flag2)
					{
						GameObject.Instantiate(Resources.Load("prefabs/finalemagnificus/Wizard3DPortrait_MoxRuby")).name = "rox";
						gameObject = GameObject.Find("rox").transform.Find("SineWaveMove").Find("Anim").Find("Gem").gameObject;
						gameObject.transform.parent = GameObject.Find("MagnificusEnvironment").transform;
						GameObject.Destroy(GameObject.Find("rox"));
						gameObject.GetComponent<MeshRenderer>().material.mainTexture = Tools.getImage("mana.png");
						gameObject.transform.position = new Vector3(0f, -85f, 0f);
						gameObject.name = "mana";
					}
					else
					{
						gameObject = GameObject.Find("mana");
					}
					WeightUtil.part1Prefab.gameObject.GetComponent<MeshFilter>().mesh = gameObject.gameObject.GetComponent<MeshFilter>().mesh;
					WeightUtil.part1Prefab.gameObject.GetComponent<MeshRenderer>().material = gameObject.GetComponent<MeshRenderer>().material;
					WeightUtil.part1Prefab.gameObject.GetComponent<BoxCollider>().size = new Vector3(0.3f, 0.3f, 0.3f);
					WeightUtil.part1Prefab.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
				}
			}
		}

		[HarmonyPatch(typeof(WeightUtil), "DropWeight")]
		public class MANASCALES2
		{
			public static IEnumerator Postfix(IEnumerator enumerator, GameObject weight)
			{
				weight.GetComponent<Rigidbody>().useGravity = false;
				yield return new WaitForSeconds(0.12f);
				weight.GetComponent<Rigidbody>().useGravity = true;
				weight.GetComponent<Rigidbody>().AddForce(UnityEngine.Random.onUnitSphere * 7f);
				weight.GetComponent<Rigidbody>().AddForce(Vector3.down * 10f, ForceMode.Impulse);
				yield break;
			}
		}
	}
}
