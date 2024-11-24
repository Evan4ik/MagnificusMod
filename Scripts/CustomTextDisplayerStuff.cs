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
			GameObject.Find("PerspectiveUICamera").transform.Find("TextDisplayer_Magnificus").Find("TextCanvas").Find("DialogueTriangle").Find("DialogueTriangleAnim").gameObject.GetComponent<Animator>().SetTrigger("clear");
			yield return new WaitForSeconds(1f);
			GameObject.Find("PerspectiveUICamera").transform.Find("TextDisplayer").gameObject.GetComponent<TextDisplayer>().baseTrianglePos = new Vector2(0, 5.1f);
			try
			{
				GameObject.Find("PerspectiveUICamera").transform.Find("TextDisplayer_Magnificus").gameObject.GetComponent<TextDisplayer>().baseTrianglePos = new Vector2(0, 4.9f);
				GameObject.Find("PerspectiveUICamera").transform.Find("TextDisplayer_Magnificus").Find("TextCanvas").Find("DialogueTriangle").transform.localPosition = new Vector3(0, 4.9f, 0);
				GameObject.Find("PerspectiveUICamera").transform.Find("TextDisplayer_Magnificus").Find("TextCanvas").Find("DialogueTriangle").Find("DialogueTriangleAnim").gameObject.GetComponent<Animator>().SetTrigger("clear");
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
				Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(fixTheTringleByForce());
			}
			else
			{
				GameObject.Find("TextDisplayer").SetActive(false);
				GameObject.Find("PerspectiveUICamera").transform.Find("TextDisplayer_Magnificus").gameObject.SetActive(true);
				GameObject.Find("PerspectiveUICamera").transform.Find("TextDisplayer_Magnificus").gameObject.GetComponent<TextDisplayer>().baseTrianglePos = new Vector2(0, 4.9f);
				Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(fixTheTringleByForce());
			}
		}

		public static void switchToSpeakerStyle(int styled)//0 - base, 1 - espeara, 2 - stimmy, 3 - goranj, 4 - orlu
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
					style.font = GameObject.Find("Fonts").transform.Find("AmberFont").GetComponent<UnityEngine.UI.Text>().font;
					style.fontSizeChange = 10;
					style.speaker = DialogueEvent.Speaker.Single;
					style.triangleSprite = Tools.getSprite("dialogue_triangle.png");
					break;
				case 2:
					style = new TextDisplayer.SpeakerTextStyle();
					style.voiceSoundIdPrefix = "stimmy";
					style.voiceSoundVolume = 1f;
					style.color = new Color(0, 0.7f, 1f);
					style.font = GameObject.Find("Fonts").transform.Find("StimFont").GetComponent<UnityEngine.UI.Text>().font;
					style.fontSizeChange = 10;
					style.speaker = DialogueEvent.Speaker.Single;
					style.triangleSprite = Tools.getSprite("dialogue_triangle.png");
					break;
				case 3:
					style = new TextDisplayer.SpeakerTextStyle();
					style.voiceSoundIdPrefix = "magnificus";
					style.voiceSoundVolume = 1f;
					style.color = new Color(0.65f, 0.45f, 0, 1);
					style.font = GameObject.Find("Fonts").transform.Find("GoranjFont").GetComponent<UnityEngine.UI.Text>().font;
					style.fontSizeChange = 2;
					style.speaker = DialogueEvent.Speaker.Single;
					style.triangleSprite = Tools.getSprite("dialogue_triangle.png");
					break;
				case 4:
					style = new TextDisplayer.SpeakerTextStyle();
					style.voiceSoundIdPrefix = "magnificus";
					style.voiceSoundVolume = 1f;
					style.color = new Color(0.75f, 0.2f, 0.55f, 1);
					style.font = GameObject.Find("Fonts").transform.Find("OrluFont").GetComponent<UnityEngine.UI.Text>().font;
					style.fontSizeChange = 2;
					style.speaker = DialogueEvent.Speaker.Single;
					style.triangleSprite = Tools.getSprite("dialogue_triangle.png");
					break;
				case 5:
					style = new TextDisplayer.SpeakerTextStyle();
					style.voiceSoundIdPrefix = "magnificus";
					style.voiceSoundVolume = 1f;
					style.color = new Color(0, 0.75f, 1, 1);
					style.font = GameObject.Find("Fonts").transform.Find("BleeneFont").GetComponent<UnityEngine.UI.Text>().font;
					style.fontSizeChange = 2;
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
