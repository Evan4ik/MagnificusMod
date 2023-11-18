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
using Tools = MagnificusMod.Tools;

namespace MagnificusMod
{
	public class LavaOrbSpawner : TimedBehaviour
	{
		Texture2D LavaOrb;
		public void Start()
		{
			LavaOrb = Tools.getImage("LavaFloor.png");
			this.SpawnLava(1f + UnityEngine.Random.value * 3f);
			this.SpawnLava(7f + UnityEngine.Random.value * 3f);
			this.SpawnLava(11f + UnityEngine.Random.value * 3f);
		}
		public override void OnTimerReached()
		{
			this.SpawnLava(0f);
		}

		public void SpawnLava(float startHeight = 0f)
		{
			GameObject orb = Instantiate(Resources.Load("prefabs/factoryindoors/gooplane3d/GooOrb") as GameObject);
			orb.transform.Find("Anim").gameObject.GetComponent<MeshRenderer>().material = new Material(Shader.Find("Standard"));
			orb.transform.Find("Anim").gameObject.GetComponent<MeshRenderer>().material.mainTexture = LavaOrb;
			orb.transform.Find("Anim").gameObject.GetComponent<MeshRenderer>().material.shaderKeywords = new string[0];
			orb.transform.parent = base.transform;
			float d = this.orbScale - 0.25f + UnityEngine.Random.value * 0.25f;
			Vector2 vector = UnityEngine.Random.insideUnitCircle * 20f;
			Vector3 vector2 = new Vector3(base.transform.position.x + vector.x, base.transform.position.y + startHeight, base.transform.position.z + vector.y);
			orb.transform.position = vector2;
			if (startHeight == 0f)
			{
				orb.transform.localScale = Vector3.one * d * 2f;
				Tween.LocalScale(orb.transform, Vector3.one * d, 0.25f, 0f, Tween.EaseBounce, Tween.LoopType.None, null, null, true);
			}
			else
			{
				orb.transform.localScale = Vector3.one * d;
			}
			Tween.Position(orb.transform, vector2 + Vector3.up * 1f, 0.2f, 0f, Tween.EaseIn, Tween.LoopType.None, null, null, true);
			Tween.Position(orb.transform, vector2 + Vector3.up * 7.5f, 12.5f, 0.2f, Tween.EaseOut, Tween.LoopType.None, null, delegate ()
			{
				Tween.Position(orb.transform, vector2 + Vector3.up * -36f, 2.5f, 0f, Tween.EaseOut, Tween.LoopType.None, null, delegate ()
				{
					UnityEngine.Object.Destroy(orb);
				}, true);
			}, true);
		}

		[SerializeField]
		public float orbScale;
	}
}
