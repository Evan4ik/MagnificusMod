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
using SavedVars = MagnificusMod.SaveVariables;

namespace MagnificusMod
{
    public class SpellPile : ManagedBehaviour
    {
		public bool initializing = false;

		public virtual IEnumerator initialize(Vector3 pos, float time = 3.3f, bool dosine = true)
        {
			if (initializing) { yield break; }
			initializing = true;
			this.gameObject.GetComponent<SineWaveMovement>().enabled = false;
			this.transform.localPosition = pos + new Vector3(0, 15f, 0);
			Tween.LocalPosition(this.transform, pos, time - 0.05f, 0);
			yield return new WaitForSeconds(time);
			initializing = false;
			if (!SavedVars.LearnedMechanics.Contains("spellbook;") && base.transform.parent.gameObject.name == "CardBattle_Magnificus")
			{
				Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(MagnificusMod.Generation.spellBookTutorial());
			}
			if (dosine)
			{
				this.gameObject.GetComponent<SineWaveMovement>().originalPosition = pos;
				this.gameObject.GetComponent<SineWaveMovement>().enabled = true;
			}
			yield break;
        }



		public void initializeItems()
        {

			bool makeSmall = SaveManager.saveFile.ascensionActive && Generation.challenges.Contains("SmallSpellbook");

			GameObject spellCardDrawPile = this.gameObject;

			GameObject spellBook = GameObject.Instantiate(Resources.Load("prefabs/rulebook/TableRuleBook") as GameObject);
			GameObject.Destroy(spellBook.gameObject.GetComponent<TableRuleBook>());
			spellBook.transform.parent = this.transform;
			spellBook.name = "spellBook";
			spellBook.transform.Find("Interactable").gameObject.SetActive(false);
			spellBook.transform.localPosition = Vector3.zero;
			spellBook.transform.localScale = !makeSmall ? new Vector3(1.8f, 1.5f, 1.8f) : new Vector3(1.8f, 0.75f, 0.9f);
			spellBook.transform.localRotation = Quaternion.Euler(300f, 5f, 180f);

			GameObject bookClosed = new GameObject("bookClosed");
			bookClosed.transform.parent = spellBook.transform;
			bookClosed.transform.localPosition = Vector3.zero;
			bookClosed.transform.localRotation = Quaternion.Euler(Vector3.zero);

			while (spellBook.transform.childCount > 0)
			{
				if (spellBook.transform.GetChild(0).gameObject == bookClosed) { break; }
				spellBook.transform.GetChild(0).parent = bookClosed.transform;
			}


			GameObject spellBookOpen = GameObject.Instantiate(Resources.Load("prefabs/rulebook/RuleBook") as GameObject);
			spellBookOpen.name = "bookOpen";
			spellBookOpen.transform.parent = spellBook.transform;
			GameObject.Destroy(spellBookOpen.GetComponentInChildren<RulebookPageFlipper>().transform.Find("BookPage_1").gameObject);
			GameObject.Destroy(spellBookOpen.GetComponentInChildren<RulebookPageFlipper>().transform.Find("BookPage_2").gameObject);


			GameObject bookOpen = spellBookOpen.GetComponentInChildren<RulebookPageFlipper>().transform.Find("BookOpen").gameObject;
			bookOpen.layer = 0;

			for (int i = 0; i < bookOpen.transform.childCount; i++)
			{
				bookOpen.transform.GetChild(i).gameObject.layer = 0;
			}

			spellBookOpen.transform.localPosition = new Vector3(-0.215f, 0.35f, 1.15f);
			spellBookOpen.transform.localScale = new Vector3(0.5f, 1f, 1.15f);
			spellBookOpen.transform.localRotation = Quaternion.Euler(0f, 0f, 201.5f);


			bookClosed.transform.Find("BookCover01").gameObject.GetComponent<MeshRenderer>().material.mainTexture = Tools.getImage("spellbook.png");
			spellBook.SetActive(true);

			GameObject selectableSpells = new GameObject("selectableSpells");
			selectableSpells.transform.parent = spellCardDrawPile.transform;
			selectableSpells.transform.localPosition = Vector3.zero;
			selectableSpells.transform.localRotation = Quaternion.Euler(Vector3.zero);


			CardInfo card = CardLoader.GetCardByName("JuniorSage");//Singleton<SelectableCardArray>.Instance.TweenInCard(component.transform, new Vector3(-1.5f + a, 5.03f, -1.5f), 0, true);
			for (int i = 0; i < (!makeSmall ? 8 : 4); i++)
			{
				float a = 1.25f;
				GameObject gameObject = GameObject.Instantiate<GameObject>(Singleton<SelectableCardArray>.Instance.selectableCardPrefab);
				gameObject.transform.SetParent(selectableSpells.transform);
				SelectableCard component = gameObject.GetComponent<SelectableCard>();
				component.Anim.SetFaceDown(false);
				component.SetEnabled(false);

				component.GetComponent<Collider>().enabled = true;

				component.SetCardback(Tools.getImage("magcardback.png"));

				component.CursorEntered = (Action<MainInputInteractable>)Delegate.Combine(component.CursorEntered, new Action<MainInputInteractable>(delegate (MainInputInteractable m)
				{
					Tween.LocalPosition(component.transform.Find("Quad").Find("CardBase"), new Vector3(0, 0, -0.2f), 0.1f, 0);
				}));
				component.CursorExited = (Action<MainInputInteractable>)Delegate.Combine(component.CursorExited, new Action<MainInputInteractable>(delegate (MainInputInteractable m)
				{
					Tween.LocalPosition(component.transform.Find("Quad").Find("CardBase"), Vector3.zero, 0.1f, 0);
				}));

				gameObject.SetActive(false);
			}

			Tween.LocalRotation(spellBook.transform, Quaternion.Euler(300f, 5f, 180f), 0f, 3);
			Tween.LocalPosition(spellBook.transform, new Vector3(0f, -0.24f, 0), 0f, 3);

			spellCardDrawPile.AddComponent<SineWaveMovement>();
			spellCardDrawPile.GetComponent<SineWaveMovement>().originalPosition = new Vector3(8.75f, 5.5f, 5.55f);
			spellCardDrawPile.GetComponent<SineWaveMovement>().speed = 0.5f;
			spellCardDrawPile.GetComponent<SineWaveMovement>().yMagnitude = 0.25f;
			spellCardDrawPile.GetComponent<SineWaveMovement>().enabled = false;

			bookClosed.SetActive(false);
		}


		public IEnumerator disappear()
		{
			if (initializing) { yield break; }
			initializing = true;
			this.gameObject.GetComponent<SineWaveMovement>().enabled = false;
			this.transform.localPosition = new Vector3(8.75f, 5.5f, 5.55f);
			Tween.LocalPosition(this.transform, new Vector3(8.75f, 25.5f, 5.55f), 3.25f, 0);
			yield return new WaitForSeconds(3.3f);
			initializing = false;
			yield break;
		}

		public void refreshSpellBookCards(List<CardInfo> spells)
		{
			bool makeSmall = SaveManager.saveFile.ascensionActive && Generation.challenges.Contains("SmallSpellbook");
			setBook(true);
			GameObject spellCards = this.gameObject.transform.Find("selectableSpells").gameObject;

			for (int i = 0; i < spellCards.transform.childCount; i++)
			{
				float a = 1f;
				a *= (i % 2);
				if (spells.Count <= i) { spellCards.transform.GetChild(i).gameObject.SetActive(false); continue; }
				spellCards.transform.GetChild(i).gameObject.SetActive(true);
				SelectableCard component = spellCards.transform.GetChild(i).gameObject.GetComponent<SelectableCard>();

				component.renderInfo.portraitOverride = null;
				component.Initialize(spells[i], new Action<SelectableCard>(this.pickSpell), null, false, null);
				component.SetEnabled(true);
				component.RenderCard();
				component.gameObject.transform.localRotation = Quaternion.Euler(30, 5, 0);

				bool side2 = (i > 1 && i < 4) || (i > 5 && i < 8);

				float initX = (i >= 4) ? 0.8f : -1.4f;
				float initZ = (i >= 4) ? 0.3f : 0.4f;

				component.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);

				

				component.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);

				if (!makeSmall) component.transform.localPosition = new Vector3(initX + (a), (!side2) ? 0.5f : -0.75f, initZ - (!side2 ? 0 : 1));
				else
                {

					a = 1.05f;
					a *= (i % 2);

					initX = (i >= 2) ? 0.65f : -1.5f;
					component.transform.localPosition = new Vector3(initX + (a), -0.15f, (i < 2 ? 0 : -0.15f));
				}

				if (makeSmall) ChallengeActivationUI.TryShowActivation(KayceeFixes.ChallengeManagement.ItemSpells);
			}

		}

		public void senableCards(bool enable)
		{
			GameObject spellCards = this.gameObject.transform.Find("selectableSpells").gameObject;
			for (int i = 0; i < spellCards.transform.childCount; i++)
			{
				SelectableCard component = spellCards.transform.GetChild(i).gameObject.GetComponent<SelectableCard>();

				if (!component.gameObject.activeSelf) { continue; }

				component.SetEnabled(enable);
			}

		}

		public virtual void pickSpell(SelectableCard component)
		{
			base.StartCoroutine(pickSpellIE(component));
		}

		public IEnumerator pickSpellIE(SelectableCard component)
        {
			if (!Singleton<TurnManager>.Instance.IsPlayerTurn || !Singleton<CombatBell>.Instance.Pressable) yield break;
			senableCards(false);
			yield return new WaitForSeconds(0.15f);
			Tween.LocalRotation(this.transform, Quaternion.Euler(0, 15f, 0), 0.3f, 0f);//7.75 6.455 7.5
			Tween.LocalPosition(this.transform, new Vector3(7.75f, 6.455f, 7.5f), 0.3f, 0f, Tween.EaseInOut, Tween.LoopType.None, null, new Action(delegate {
				Singleton<SpellPile>.Instance.gameObject.GetComponent<SineWaveMovement>().enabled = true;
			}));
			Singleton<ViewManager>.Instance.SwitchToView(View.WizardBattleHand, false, true);
			yield return Singleton<CardSpawner>.Instance.SpawnCardToHand(component.Info);


			if (component.Info.name != "mag_potion" && component.Info.Health <= 1) 
				RunState.Run.playerDeck.RemoveCardByName(component.Info.name);
			component.gameObject.SetActive(false);
			yield return new WaitForSeconds(0.3f);
			setBook(false);

			Singleton<ViewManager>.Instance.SwitchToView(View.WizardBattleHand, false, false);
			Singleton<ViewController>.Instance.LockState = ViewLockState.Unlocked;
			senableCards(true);
		}

		public void setBook(bool open)
        {
			GameObject selectableSpells = this.transform.Find("selectableSpells").gameObject;
			GameObject bookClosed = this.transform.Find("spellBook").Find("bookClosed").gameObject;
			GameObject bookOpen = this.transform.Find("spellBook").Find("bookOpen").gameObject;
			bookOpen.SetActive(open);
			bookClosed.SetActive(!open);
			selectableSpells.SetActive(open);
		}

	}
}
