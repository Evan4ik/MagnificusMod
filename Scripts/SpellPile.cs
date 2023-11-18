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

namespace MagnificusMod
{
    public class SpellPile : ManagedBehaviour
    {

		public Deck SpellDeck;

        public List<CardInfo> spellList = new List<CardInfo>();

		public List<CardInfo> spellData = new List<CardInfo>();





		public IEnumerator Initialize()
		{
			//getSpellData();
			this.SpellDeck = this.SpawnDeckObject(this.spellData);
			yield break;
		}

		public Deck SpawnDeckObject(List<CardInfo> cardList)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(ResourceBank.Get<GameObject>("Prefabs/CardBattle/Deck"));
			gameObject.transform.parent = GameObject.Find("SpellPile").transform;
			gameObject.GetComponent<Deck>().Initialize(cardList, SaveManager.SaveFile.GetCurrentRandomSeed());
			return gameObject.GetComponent<Deck>();
		}

		public void refreshDeck(List<CardInfo> cardList)
        {
			SpellDeck.Initialize(cardList, SaveManager.SaveFile.GetCurrentRandomSeed());
		}

		public IEnumerator DrawFromSpellPile()
		{
			SelectableCard selectedCard = null;
			CardInfo selectedInfo = null;
			if (this.spellData.Count > 1)
			{
				Singleton<ViewManager>.Instance.SwitchToView(View.Default, false, true);
				GameObject.Find("SelectableCardArray").transform.localPosition = new Vector3(-0.72f, 6.685f, 4.059f);
				Tween.LocalPosition(GameObject.Find("SelectableCardArray").transform, new Vector3(-0.72f, 2.5f, 4.059f), 1.25f, 0f);
				Tween.LocalRotation(GameObject.Find("SelectableCardArray").transform, Quaternion.Euler(290, 0, 0), 0.5f, (0.1f * this.spellData.Count));
				yield return Singleton<BoardManager>.Instance.CardSelector.SelectCardFrom(this.spellData, (Singleton<CardDrawPiles>.Instance as CardDrawPiles3D).Pile, delegate (SelectableCard x)
				{
					selectedCard = x;
				}, null, true);
				Tween.LocalRotation(GameObject.Find("SelectableCardArray").transform, Quaternion.Euler(0, 0, 0), 0.5f, 0f);
				Tween.Position(selectedCard.transform, selectedCard.transform.position + Vector3.back * 4f, 0.1f, 0f, Tween.EaseIn, Tween.LoopType.None, null, null, true);
				UnityEngine.Object.Destroy(selectedCard.gameObject, 0.1f);
				selectedInfo = selectedCard.Info;
			} else
            {
				selectedInfo = this.spellData[0];
            }
			spellData.Remove(selectedInfo);
			spellList.Remove(selectedInfo);
			yield return Singleton<CardSpawner>.Instance.SpawnCardToHand(selectedInfo, new List<CardModificationInfo>(), new Vector3(0,0, 0), 0.15f, null);
			yield break;
		}
	}
}
