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
using SavedVars = MagnificusMod.SaveVariables;
using KayceeStorage = MagnificusMod.KayceeStorage;

namespace MagnificusMod
{
    class CustomTextDisplayerStuff
    {
		public static IEnumerator fixTheTringleByForce()
		{
			yield return new WaitForSeconds(1f);
			GameObject.Find("PerspectiveUICamera").transform.Find("TextDisplayer").gameObject.GetComponent<TextDisplayer>().baseTrianglePos = new Vector2(0, 5.1f);
			try
			{
				GameObject.Find("PerspectiveUICamera").transform.Find("TextDisplayer_Magnificus").gameObject.GetComponent<TextDisplayer>().baseTrianglePos = new Vector2(0, 4.9f);
				GameObject.Find("PerspectiveUICamera").transform.Find("TextDisplayer_Magnificus").Find("TextCanvas").Find("DialogueTriangle").transform.localPosition = new Vector3(0, 4.9f, 0);
				GameObject.Find("PerspectiveUICamera").transform.Find("TextDisplayer_Magnificus").Find("TextCanvas").Find("DialogueTriangle").gameObject.SetActive(false);
			}
			catch
			{
				Singleton<TextDisplayer>.Instance.gameObject.GetComponent<TextDisplayer>().baseTrianglePos = new Vector2(0, 5.3f);
			}
			yield break;
		}
		public static void setBaseTextDisplayerOn(bool on)
		{
			if (on)
			{
				Singleton<TextDisplayer>.Instance.gameObject.SetActive(false);
				GameObject.Find("PerspectiveUICamera").transform.Find("TextDisplayer").gameObject.SetActive(true);
				GameObject.Find("PerspectiveUICamera").transform.Find("TextDisplayer").gameObject.GetComponent<TextDisplayer>().baseTrianglePos = new Vector2(0, 5.1f);
			}
			else
			{
				GameObject.Find("TextDisplayer").SetActive(false);
				GameObject.Find("PerspectiveUICamera").transform.Find("TextDisplayer_Magnificus").gameObject.SetActive(true);
				GameObject.Find("PerspectiveUICamera").transform.Find("TextDisplayer_Magnificus").gameObject.GetComponent<TextDisplayer>().baseTrianglePos = new Vector2(0, 4.9f);
			}
			Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(fixTheTringleByForce());
		}

		public static void switchToSpeakerStyle(int styled)//0 - base, 1 - espeara, 2 - stimmy
		{
			TextDisplayer.SpeakerTextStyle style = new TextDisplayer.SpeakerTextStyle();
			switch (styled)
			{
				case 0:
					style = GameObject.Find("TextDisplayer_Magnificus").GetComponent<TextDisplayer>().defaultStyle;
					break;
				case 1:
					style = new TextDisplayer.SpeakerTextStyle();
					style.voiceSoundIdPrefix = "amber";
					style.voiceSoundVolume = 1f;
					style.color = new Color(1, 0.6f, 0.23f);
					style.font = GameObject.Find("AmberFont").GetComponent<UnityEngine.UI.Text>().font;
					style.fontSizeChange = 10;
					style.speaker = DialogueEvent.Speaker.Single;
					style.triangleSprite = Tools.getSprite("dialogue_triangle.png");
					break;
				case 2:
					style = new TextDisplayer.SpeakerTextStyle();
					style.voiceSoundIdPrefix = "stimmy";
					style.voiceSoundVolume = 0.6f;
					style.color = new Color(0, 0.7f, 1f);
					style.font = GameObject.Find("StimmyFont").GetComponent<UnityEngine.UI.Text>().font;
					style.fontSizeChange = 10;
					style.speaker = DialogueEvent.Speaker.Single;
					style.triangleSprite = Tools.getSprite("dialogue_triangle.png");
					break;
			}
			GameObject.Find("TextDisplayer_Magnificus").GetComponent<TextDisplayer>().alternateSpeakerStyles = new List<TextDisplayer.SpeakerTextStyle>();
			GameObject.Find("TextDisplayer_Magnificus").GetComponent<TextDisplayer>().alternateSpeakerStyles.Add(style);
			GameObject.Find("TextDisplayer_Magnificus").GetComponent<TextDisplayer>().SetTextStyle(style);
		}

	}
}
