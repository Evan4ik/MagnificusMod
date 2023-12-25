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
    public static class SigilCode
    {

		public class MoxRandom : AbilityBehaviour
		{
			public override Ability Ability
			{
				get
				{
					return MoxRandom.ability;
				}
			}

			public override bool RespondsToDrawn()
			{
				return true;
			}

			public override IEnumerator OnDrawn()
			{
				base.Card.SetInfo(CardLoader.GetCardByName(ChooseAbility()));
				yield return new WaitForSeconds(0.5f);
				yield break;
			}

			private void AddMod()
			{
				base.Card.Status.hiddenAbilities.Add(this.Ability);
			}

			private string ChooseAbility()
			{
				List<string> list = new List<string>
				{
					"red",
					"green",
					"blue",
					"red",
					"green",
					"blue"
				};

				string text = base.Card.Info.ToString();
				string[] array = text.Split(new char[]
				{
					' '
				}, 2);
				text = array[0];

				string text2 = list[UnityEngine.Random.Range(0, list.Count)];
				while (text2 == Plugin.lastMox)
				{
					text2 = list[UnityEngine.Random.Range(0, list.Count)];
				}
				Plugin.lastMox = text2;
				string result = "mag_rubymox";
				switch (text2)
				{
					case "green":
						{
							result = "mag_greenmox";
							break;
						}
					case "red":
						{
							result = "mag_rubymox";
							break;
						}
					case "blue":
						{
							result = "mag_bluemox";
							break;
						}
				}
				return result;

			}

			public static Ability ability;
		}

		public class bluecommon : AbilityBehaviour
		{
			public override Ability Ability
			{
				get
				{
					return bluecommon.ability;
				}
			}

			public static Ability ability;
		}

		public class greencommon : AbilityBehaviour
		{
			public override Ability Ability
			{
				get
				{
					return greencommon.ability;
				}
			}

			public static Ability ability;
		}

		public class orangecommon : AbilityBehaviour
		{
			public override Ability Ability
			{
				get
				{
					return orangecommon.ability;
				}
			}

			public static Ability ability;
		}

		public class MagDropRubyOnDeath : AbilityBehaviour
		{
			public override Ability Ability
			{
				get
				{
					return MagDropRubyOnDeath.ability;
				}
			}

			public override bool RespondsToOtherCardDie(PlayableCard card, CardSlot deathSlot, bool fromCombat, PlayableCard killer)
			{
				return card == base.Card && fromCombat && base.Card.OnBoard;
			}

			public override IEnumerator OnOtherCardDie(PlayableCard card, CardSlot deathSlot, bool fromCombat, PlayableCard killer)
			{
				yield return base.PreSuccessfulTriggerSequence();
				yield return new WaitForSeconds(0.1f);
				if (base.Card.HasAbility(SigilCode.MagDropEmeraldOnDeath.ability))
                {
					yield return Singleton<BoardManager>.Instance.CreateCardInSlot(CardLoader.GetCardByName("mag_goranjmox"), base.Card.Slot, 0.1f, true);
					yield break;
				}
				bool flag = card.Info.name != "mag_moxbeast";
				if (flag)
				{
					yield return Singleton<BoardManager>.Instance.CreateCardInSlot(CardLoader.GetCardByName("mag_rubymox"), base.Card.Slot, 0.1f, true);
				}
				else
				{
					yield return Singleton<BoardManager>.Instance.CreateCardInSlot(CardLoader.GetCardByName("mag_crystalworm"), base.Card.Slot, 0.1f, true);
				}
				yield return base.LearnAbility(0.5f);
				yield break;
			}

			public static Ability ability;
		}

		public class MagDropEmeraldOnDeath : AbilityBehaviour
		{
			public override Ability Ability
			{
				get
				{
					return MagDropEmeraldOnDeath.ability;
				}
			}

			public override bool RespondsToOtherCardDie(PlayableCard card, CardSlot deathSlot, bool fromCombat, PlayableCard killer)
			{
				return card == base.Card && fromCombat && base.Card.OnBoard && !base.Card.HasAbility(SigilCode.MagDropRubyOnDeath.ability);
			}

			public override IEnumerator OnOtherCardDie(PlayableCard card, CardSlot deathSlot, bool fromCombat, PlayableCard killer)
			{
				yield return base.PreSuccessfulTriggerSequence();
				yield return new WaitForSeconds(0.1f);
				yield return Singleton<BoardManager>.Instance.CreateCardInSlot(CardLoader.GetCardByName("mag_greenmox"), base.Card.Slot, 0.1f, true);
				yield return base.LearnAbility(0.5f);
				yield break;
			}

			public static Ability ability;
		}

		public class Stimulation : AbilityBehaviour
		{
			public override Ability Ability
			{
				get
				{
					return Stimulation.ability;
				}
			}

			public override bool RespondsToTurnEnd(bool playerTurnEnd)
			{
				return base.Card.OpponentCard != playerTurnEnd;
			}

			public override IEnumerator OnTurnEnd(bool playerTurnEnd)
			{
				int attack = 0;
				foreach (CardModificationInfo mod in base.Card.temporaryMods)
				{
					bool flag = mod.singletonId == "stim";
					if (flag)
					{
						attack = mod.attackAdjustment;
					}
				}
				List<CardModificationInfo>.Enumerator enumerator = default(List<CardModificationInfo>.Enumerator);
				string title = base.Card.Info.name;
				bool flag2 = base.Card.Attack < base.Card.Info.baseAttack + 4 || title == "mag_lonelymage" || (title == "mag_BOSSlonelymage2" && base.Card.Attack < 10) || (title == "mag_BOSSmagnificuslonelymage" && base.Card.Attack < 10);
				if (flag2)
				{
					CardModificationInfo cardModificationInfo = new CardModificationInfo();
					cardModificationInfo.nonCopyable = false;
					cardModificationInfo.attackAdjustment = 1 + attack;
					cardModificationInfo.healthAdjustment = 0;
					cardModificationInfo.singletonId = "stim";
					base.Card.AddTemporaryMod(cardModificationInfo);
					cardModificationInfo = null;
				}
				yield break;
			}

			public static Ability ability;

			private CardModificationInfo mod;
		}

		public class StimulationHP : AbilityBehaviour
		{
			public override Ability Ability
			{
				get
				{
					return StimulationHP.ability;
				}
			}

			public override bool RespondsToTurnEnd(bool playerTurnEnd)
			{
				return base.Card.OpponentCard != playerTurnEnd;
			}

			public override IEnumerator OnTurnEnd(bool playerTurnEnd)
			{
				int health = 0;
				foreach (CardModificationInfo mod in base.Card.temporaryMods)
				{
					bool flag = mod.singletonId == "stimhp";
					if (flag)
					{
						health = mod.healthAdjustment;
					}
				}
				CardModificationInfo cardModificationInfo = new CardModificationInfo();
				cardModificationInfo.nonCopyable = false;
				cardModificationInfo.attackAdjustment = 0;
				cardModificationInfo.healthAdjustment = 2 + health;
				cardModificationInfo.singletonId = "stimhp";
				if (base.Card.Health <= 10)
				{
					base.Card.AddTemporaryMod(cardModificationInfo);
				}
				yield break;
			}

			public static Ability ability;
		}

		public class BlueMageDraw : AbilityBehaviour
		{
			public override Ability Ability
			{
				get
				{
					return BlueMageDraw.ability;
				}
			}

			public override bool RespondsToOtherCardResolve(PlayableCard otherCard)
			{
				return otherCard == base.Card;
			}

			public override IEnumerator OnOtherCardResolve(PlayableCard otherCard)
			{
				if (this.originalDeckCards == null)
				{
					this.originalDeckCards = Singleton<CardDrawPiles>.Instance.Deck.cards;
				}
				yield return base.PreSuccessfulTriggerSequence();
				yield return new WaitForSeconds(0.1f);
				int numGems = Singleton<BoardManager>.Instance.PlayerSlotsCopy.FindAll((CardSlot x) => x.Card != null && x.Card.Info.HasTrait(Trait.Gem)).Count;
				int num;
				for (int i = 0; i < numGems; i = num + 1)
				{
					if (Singleton<CardDrawPiles>.Instance.Deck.cards.Count > 0)
					{
						yield return Singleton<CardDrawPiles>.Instance.DrawCardFromDeck(null, null);
					}
					num = i;

				}
				bool flag = numGems > 0;
				if (flag)
				{
					yield return base.LearnAbility(0.5f);
				}
				yield return Singleton<CardDrawPiles3D>.Instance.pile.DestroyCards(0.5f);
				Singleton<CardDrawPiles>.Instance.Deck.cards = this.originalDeckCards;
				yield return Singleton<CardDrawPiles3D>.Instance.pile.SpawnCards(this.originalDeckCards.Count, 0.5f);
				yield return base.LearnAbility(0.5f);
				Singleton<ViewManager>.Instance.Controller.LockState = ViewLockState.Unlocked;
				yield break;
			}

			public static Ability ability;

			private List<CardInfo> originalDeckCards;
		}

		public class DrawSpell : DrawCreatedCard
		{
			public static Ability ability;
			public override Ability Ability
			{
				get
				{
					return DrawSpell.ability;
				}
			}
			public override CardInfo CardToDraw
			{
				get
				{
					List<CardInfo> spellCards = new List<CardInfo>();
					foreach (CardInfo carde in CardLoader.allData)
					{
						if (carde.HasTrait(Trait.EatsWarrens))
						{
							spellCards.Add(CardLoader.GetCardByName(carde.name));
						}
					}
					List<CardInfo> selectedCards = new List<CardInfo>();
					for (int i = 0; i < 1; i++)
					{
						int selected = Random.RandomRangeInt(0, spellCards.Count);
						selectedCards.Add(spellCards[selected]);
						spellCards.Remove(spellCards[selected]);
					}
					if (selectedCards[0].name == "mag_potion")
                    {
						CardModificationInfo potionbuff = new CardModificationInfo(1, 2);
						selectedCards[0].mods.Add(potionbuff);
                    }
					return selectedCards[0];
				}
			}

			public override bool RespondsToResolveOnBoard()
			{
				return true;
			}

			public override IEnumerator OnResolveOnBoard()
			{
				yield return base.PreSuccessfulTriggerSequence();
				yield return base.CreateDrawnCard();
				yield return base.LearnAbility(0f);
				yield break;
			}
		}

		public class BlueMageDraw2 : AbilityBehaviour
		{
			public override Ability Ability
			{
				get
				{
					return BlueMageDraw2.ability;
				}
			}

			public override bool RespondsToOtherCardResolve(PlayableCard otherCard)
			{
				return otherCard == base.Card;
			}

			public override IEnumerator OnOtherCardResolve(PlayableCard otherCard)
			{
				if (this.originalDeckCards == null)
				{
					this.originalDeckCards = Singleton<CardDrawPiles>.Instance.Deck.cards;
				}
				yield return base.PreSuccessfulTriggerSequence();
				yield return new WaitForSeconds(0.1f);
				int numGems = Singleton<BoardManager>.Instance.PlayerSlotsCopy.FindAll((CardSlot x) => x.Card != null && x.Card.Info.HasTrait(Trait.Gem)).Count;
				int num;
				for (int i = 0; i < numGems; i = num + 1)
				{
					yield return Singleton<CardDrawPiles>.Instance.DrawCardFromDeck(null, null);
					num = i;
				}
				bool flag = numGems > 0;
				if (flag)
				{
					yield return base.LearnAbility(0.5f);
				}
				yield return Singleton<CardDrawPiles3D>.Instance.pile.DestroyCards(0.5f);
				Singleton<CardDrawPiles>.Instance.Deck.cards = this.originalDeckCards;
				yield return Singleton<CardDrawPiles3D>.Instance.pile.SpawnCards(this.originalDeckCards.Count, 0.5f);
				yield return base.LearnAbility(0.5f);
				Singleton<ViewManager>.Instance.Controller.LockState = ViewLockState.Unlocked;
				yield break;
			}

			public static Ability ability;

			private List<CardInfo> originalDeckCards;
		}

		public class BleeneDraw : AbilityBehaviour
		{
			public override Ability Ability
			{
				get
				{
					return BleeneDraw.ability;
				}
			}

			public override bool RespondsToOtherCardDie(PlayableCard card, CardSlot deathSlot, bool fromCombat, PlayableCard killer)
			{
				return base.Card.OnBoard && deathSlot.Card != null && deathSlot.Card.OpponentCard == base.Card.OpponentCard && deathSlot.Card != base.Card && !this.currentlyResurrectingCards.Contains(deathSlot.Card.Info) && deathSlot.Card == card;
			}

			public override IEnumerator OnOtherCardDie(PlayableCard card, CardSlot deathSlot, bool fromCombat, PlayableCard killer)
			{
				if (this.originalDeckCards == null)
				{
					this.originalDeckCards = Singleton<CardDrawPiles>.Instance.Deck.cards;
				}
				yield return base.PreSuccessfulTriggerSequence();
				yield return new WaitForSeconds(0.1f);
				base.Card.Anim.PlaySacrificeParticles();
				int numGems = 2;
				for (int i = 0; i < numGems; i ++)
				{
					if (Singleton<CardDrawPiles>.Instance.Deck.cards.Count > 0)
					{
						yield return Singleton<CardDrawPiles>.Instance.DrawCardFromDeck(null, null);
					}
				}
				this.currentlyResurrectingCards.Clear();
				yield return Singleton<CardDrawPiles3D>.Instance.pile.DestroyCards(0.5f);
				Singleton<CardDrawPiles>.Instance.Deck.cards = this.originalDeckCards;
				yield return Singleton<CardDrawPiles3D>.Instance.pile.SpawnCards(this.originalDeckCards.Count, 0.5f);
				yield return base.LearnAbility(0.5f);
				Singleton<ViewManager>.Instance.Controller.LockState = ViewLockState.Unlocked;
				yield break;
			}

			public static Ability ability;

			private List<CardInfo> originalDeckCards;

			private List<CardInfo> currentlyResurrectingCards = new List<CardInfo>();
		}

		public class GoobertDebuff : AbilityBehaviour
		{
			public override Ability Ability
			{
				get
				{
					return GoobertDebuff.ability;
				}
			}

			public override bool RespondsToTakeDamage(PlayableCard source)
			{
				return source != null && source.Health > 0;
			}

			public override IEnumerator OnTakeDamage(PlayableCard source)
			{
				bool flag2 = source.name != "mag_BOSSbignificus";
				if (flag2)
				{
					bool flag3 = source != null && source.Attack > 0;
					if (flag3)
					{
						int debuf = 0;
						foreach (CardModificationInfo mod in source.temporaryMods)
						{
							bool flag4 = mod.singletonId == "goodebuff";
							if (flag4)
							{
								debuf = mod.attackAdjustment;
							}
						}
						List<CardModificationInfo>.Enumerator enumerator = default(List<CardModificationInfo>.Enumerator);
						CardModificationInfo cardModificationInfo = new CardModificationInfo();
						cardModificationInfo.attackAdjustment = -1 + debuf;
						cardModificationInfo.singletonId = "goodebuff";
						source.AddTemporaryMod(cardModificationInfo);
						cardModificationInfo = null;
					}
					yield break;
				}
				bool flag = !base.HasLearned;
				bool flag5 = flag;
				if (flag5)
				{
					base.StartCoroutine(Singleton<TextDisplayer>.Instance.ShowUntilInput("What is this? Trying to weaken me with my own [c:blGr]Goo Mage[c:]? \n How foolish..", -2.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true));
					yield return base.LearnAbility(0.4f);
				}
				yield break;
			}

			public static Ability ability;

			private CardModificationInfo mod;
		}

		public class OrluHit : AbilityBehaviour
		{
			public override Ability Ability
			{
				get
				{
					return OrluHit.ability;
				}
			}

			public override bool RespondsToDealDamageDirectly(int amount)
			{
				return amount > 0 && base.Card.HasAbility(SigilCode.OrluHit.ability);
			}

			public IEnumerator fixCardBacks()
			{
				yield return new WaitForSeconds(0.1f * Singleton<Deck>.Instance.CardsInDeck);
				for (int i = 0; i < GameObject.Find("SelectableCardArray").transform.childCount; i++)
				{
					GameObject.Find("SelectableCardArray").transform.GetChild(i).gameObject.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].mainTexture = Tools.getImage("magcardback.png");
					GameObject.Find("SelectableCardArray").transform.GetChild(i).gameObject.GetComponent<BoxCollider>().size = new Vector3(0, 0, 0);
				}
				yield break;
			}

			public override IEnumerator OnDealDamageDirectly(int amount)
			{
				if (!base.Card.slot.IsPlayerSlot)
                {
					if (Singleton<Deck>.Instance.cards.Count < 1) { yield break; }
					GameObject stolen = GameObject.Instantiate<GameObject>(Singleton<SelectableCardArray>.Instance.selectableCardPrefab);
					stolen.name = "stolencard";
					stolen.transform.SetParent(GameObject.Find("GameTable").transform);
					stolen.transform.localPosition = new Vector3(3.6f, 5.6f, -3.15f);
					stolen.transform.localScale = new Vector3(1f, 1f, 1f);
					stolen.transform.localRotation = Quaternion.Euler(0, 180, 0);
					SelectableCard component10 = stolen.GetComponent<SelectableCard>();
					component10.Anim.PlayQuickRiffleSound();
					component10.Initialize(CardLoader.GetCardByName("mag_jrsage"));
					component10.ExitBoard(1.25f, new Vector3(0f, 0.5f, 2.5f));
					CardInfo selected = Singleton<Deck>.Instance.cards[UnityEngine.Random.RandomRangeInt(0, Singleton<Deck>.Instance.cards.Count)];
					Singleton<Deck>.Instance.cards.Remove(selected);
					yield break;
				}
				if (this.originalDeckCards == null)
				{
					this.originalDeckCards = Singleton<CardDrawPiles>.Instance.Deck.cards;
				}
				yield return base.PreSuccessfulTriggerSequence();
				yield return new WaitForSeconds(0.1f);
				for (int i = 0; i < amount; i++)
				{
					if (Singleton<CardDrawPiles>.Instance.Deck.cards.Count > 0) {
						yield return Singleton<CardDrawPiles>.Instance.DrawCardFromDeck(null, null);
					}
				}
				yield return Singleton<CardDrawPiles3D>.Instance.pile.DestroyCards(0.5f);
				Singleton<CardDrawPiles>.Instance.Deck.cards = this.originalDeckCards;
				yield return Singleton<CardDrawPiles3D>.Instance.pile.SpawnCards(this.originalDeckCards.Count, 0.5f);
				yield return base.LearnAbility(0.5f);
				Singleton<ViewManager>.Instance.Controller.LockState = ViewLockState.Unlocked;
				yield break;
			}

			public override bool RespondsToTurnEnd(bool playerTurnEnd)
			{
				return playerTurnEnd;
			}
			public override IEnumerator OnTurnEnd(bool playerTurnEnd)
			{
				List<int> removeAbilitiesAt = new List<int>();
				for (int i = 0; i < base.Card.temporaryMods.Count; i++)
				{
					if (base.Card.temporaryMods[i].singletonId == "inspiration")
					{
						removeAbilitiesAt.Add(i);
					}
				}
				foreach (int i in removeAbilitiesAt)
				{
					base.Card.temporaryMods.RemoveAt(i);
				}

				if (!base.Card.Dead)
				{
					base.Card.RenderCard();
					int dex;
					dex = base.Card.slot.Index;
					string slotName = base.Card.slot.IsPlayerSlot ? "PlayerSlots" : "OpponentSlots";
					if (GameObject.Find(slotName).transform.GetChild(dex).childCount > 5)
					{
						GameObject model = GameObject.Find(slotName).transform.GetChild(dex).GetChild(5).gameObject;
						model.GetComponent<Card>().RenderCard();
					}
				}
				yield break;
			}

			public static Ability ability;

			private List<CardInfo> originalDeckCards;
		}

		public class LifeSteal : AbilityBehaviour
		{
			public override Ability Ability
			{
				get
				{
					return LifeSteal.ability;
				}
			}

			public override bool RespondsToDealDamageDirectly(int amount)
			{
				return amount > 0;
			}

			public override IEnumerator OnDealDamageDirectly(int amount)
			{
				if (base.Card.slot.IsPlayerSlot)
                {
					Singleton<MagnificusLifeManager>.Instance.playerLife += amount;
                } else
                {
					Singleton<MagnificusLifeManager>.Instance.opponentLife += amount;
				}
				Singleton<MagnificusLifeManager>.Instance.OpponentCounter.ShowValue(Singleton<MagnificusLifeManager>.Instance.opponentLife);
				Singleton<MagnificusLifeManager>.Instance.PlayerCounter.ShowValue(Singleton<MagnificusLifeManager>.Instance.playerLife);//card_attack_damage
				AudioController.Instance.PlaySound2D("card_attack_damage", MixerGroup.None, 0.5f, 0f, null, null, null, null, false);
				yield break;
			}

			public static Ability ability;
		}

		public class sharkoKick : AbilityBehaviour
		{
			public override Ability Ability
			{
				get
				{
					return sharkoKick.ability;
				}
			}


			//yield return Singleton<TurnManager>.Instance.Opponent.ReturnCardToQueue(this.hookTargetSlot.opposingSlot.Card, 0.25f);
			public override bool RespondsToDealDamage(int amount, PlayableCard target)
			{
				return amount > 0 && target != null && !target.Dead && !target.HasTrait(Trait.Giant);
			}

			public override IEnumerator OnDealDamage(int amount, PlayableCard target)
			{
				CardSlot toLeft = Singleton<BoardManager>.Instance.GetAdjacent(target.Slot, true);
				CardSlot toRight = Singleton<BoardManager>.Instance.GetAdjacent(target.Slot, false);
				bool movingLeft = false;
				bool leftExists = toLeft != null;
				bool rightExists = toRight != null;
				if (movingLeft && !leftExists)
				{
					movingLeft = false;
				}
				if (!movingLeft && !rightExists)
				{
					movingLeft = true;
				}
				CardSlot cardSlot = movingLeft ? toLeft : toRight;
				if (leftExists && toLeft.Card != null || !leftExists)
                {
					if (rightExists && toRight.Card != null || !rightExists)
                    {
						yield break;
                    }
                }
				PlayableCard swappedCard = cardSlot.Card;
				if (swappedCard != null)
				{
					base.Card.Anim.StrongNegationEffect();
					float x = (swappedCard.Slot.transform.position.x + base.Card.Slot.transform.position.x) / 2f;
					float y = swappedCard.transform.position.y + 0.35f;
					float z = swappedCard.transform.position.z;
					Tween.Position(swappedCard.transform, new Vector3(x, y, z), 0.3f, 0f, Tween.EaseOut, Tween.LoopType.None, null, null, true);
				}
				CardSlot originalSlot = target.Slot;
				if (cardSlot != null && true)
				{
					CardSlot oldSlot = target.Slot;
					yield return Singleton<BoardManager>.Instance.AssignCardToSlot(target, cardSlot, 0.2f, null, true);
					yield return new WaitForSeconds(0.25f);
				}
				else
				{
					target.Anim.StrongNegationEffect();
					yield return new WaitForSeconds(0.15f);
				}
				base.Card.RenderInfo.SetAbilityFlipped(this.Ability, movingLeft);
				base.Card.RenderCard();
				bool didSwapCard = false;
				if (swappedCard != null && !swappedCard.Dead)
				{
					didSwapCard = true;
					yield return Singleton<BoardManager>.Instance.AssignCardToSlot(swappedCard, originalSlot, 0.2f, null, true);
				}
				if (didSwapCard)
				{
					yield return base.PreSuccessfulTriggerSequence();
					yield return base.LearnAbility(0f);
				}
				yield break;
			}
			public static Ability ability;
		}

		public class MagDropSpear : AbilityBehaviour
		{
			public override Ability Ability
			{
				get
				{
					return MagDropSpear.ability;
				}
			}

			public override bool RespondsToOtherCardDie(PlayableCard card, CardSlot deathSlot, bool fromCombat, PlayableCard killer)
			{
				return card == base.Card && fromCombat && base.Card.OnBoard;
			}

			public override IEnumerator OnOtherCardDie(PlayableCard card, CardSlot deathSlot, bool fromCombat, PlayableCard killer)
			{
				yield return base.PreSuccessfulTriggerSequence();
				yield return new WaitForSeconds(0.1f);
				yield return Singleton<BoardManager>.Instance.CreateCardInSlot(CardLoader.GetCardByName("mag_spear"), base.Card.Slot, 0.1f, true);
				yield return base.LearnAbility(0.5f);
				yield break;
			}

			public static Ability ability;
		}

		public class MoxStrafe : Strafe
		{
			public static Ability ability;

			public string lastMox = "mag_rubymox";
			public override Ability Ability
			{
				get
				{
					return Ability.SkeletonStrafe;
				}
			}

			public override IEnumerator PostSuccessfulMoveSequence(CardSlot cardSlot)
			{
				if (cardSlot.Card == null)
				{
					string moxToDrop = "mag_greenmox";
					switch(lastMox)
                    {
						case "mag_rubymox":
							moxToDrop = "mag_greenmox";
							break;
						case "mag_greenmox":
							moxToDrop = "mag_bluemox";
							break;
						case "mag_bluemox":
							moxToDrop = "mag_rubymox";
							break;
					}
					lastMox = moxToDrop;
					yield return Singleton<BoardManager>.Instance.CreateCardInSlot(CardLoader.GetCardByName(moxToDrop), cardSlot, 0.1f, true);
				}
				yield break;
			}
		}

		public class Untransferable : AbilityBehaviour
		{
			public override Ability Ability
			{
				get
				{
					return Untransferable.ability;
				}
			}

			public override bool RespondsToTurnEnd(bool playerTurnEnd)
			{
				return base.Card.OpponentCard != playerTurnEnd;
			}

			public override IEnumerator OnTurnEnd(bool playerTurnEnd)
			{
				string title = base.Card.Info.ToString();
				string[] res = title.Split(new char[]
				{
					' '
				}, 2);
				title = res[0];
				bool flag = title != "mag_forcemage";
				if (flag)
				{
					yield return base.PreSuccessfulTriggerSequence();
					bool flag2 = base.Card != null && !base.Card.Dead;
					if (flag2)
					{
						bool flag3 = !SaveManager.SaveFile.IsPart2;
						if (flag3)
						{
							Singleton<ViewManager>.Instance.SwitchToView(View.Board, false, false);
							yield return new WaitForSeconds(0.1f);
						}
						yield return base.Card.Die(false, null, true);
						yield return base.LearnAbility(0.25f);
						bool flag4 = !SaveManager.SaveFile.IsPart2;
						if (flag4)
						{
							yield return new WaitForSeconds(0.1f);
						}
					}
				}
				yield break;
			}

			public static Ability ability;
		}

		public class HealthForAnts : VariableStatBehaviour
		{
			public static SpecialTriggeredAbilityManager.FullSpecialTriggeredAbility FullSpecial;
			public static StatIconManager.FullStatIcon FullStatIcon;
			public static AbilityInfo ability;
			public override SpecialStatIcon IconType => FullStatIcon.Id;


			public override int[] GetStatValues()
			{
				List<CardSlot> source = base.PlayableCard.Slot.IsPlayerSlot ? Singleton<BoardManager>.Instance.PlayerSlotsCopy : Singleton<BoardManager>.Instance.OpponentSlotsCopy;
				int num = (from slot in source
						   where slot.Card != null
						   select slot).Count((CardSlot cardSlot) => cardSlot.Card.Info.HasTrait(Trait.Gem));
				int[] array = new int[2];
				array[0] = num;
				return array;
			}

			public static AbilityInfo MoxPowerBypass;

			public static StatIconManager.FullStatIcon InitStatIconAndAbility()
			{
				MoxPowerBypass = AbilityManager.New(Plugin.PluginGuid, "Mox Power", "The value represented with this sigil will be equal to the number of Mox Cards that the owner has on their side of the table.", typeof(SigilCode.HealthForAnts), Tools.GetTexture("mox empowered.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.GetTexture("mox empowered.png"));
				MoxPowerBypass.powerLevel = 10;
				HealthForAnts.ability = MoxPowerBypass;

				StatIconInfo info = ScriptableObject.CreateInstance<StatIconInfo>();
				info.appliesToAttack = true;
				info.appliesToHealth = false;
				info.rulebookName = "Mox Power";
				info.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
				info.rulebookDescription =
					"The value represented with this sigil will be equal to the number of Mox Cards that the owner has on their side of the table.";
				info.gbcDescription = MoxPowerBypass.ability.ToString();

				info.iconGraphic = Tools.GetTexture("mox empowered.png");
				info.pixelIconGraphic = Tools.getSprite("moxempowered_pixel.png");

				FullStatIcon = StatIconManager.Add(Plugin.PluginGuid, info, typeof(HealthForAnts));
				FullSpecial = SpecialTriggeredAbilityManager.Add(Plugin.PluginGuid, info.rulebookName, typeof(HealthForAnts));
				return FullStatIcon;
			}

			private static SpecialStatIcon specialStatIcon;
		}

		public class MoxHp : VariableStatBehaviour
		{
			public static AbilityInfo ability;

			public static SpecialTriggeredAbilityManager.FullSpecialTriggeredAbility FullSpecial;
			public static StatIconManager.FullStatIcon FullStatIcon;

			public override SpecialStatIcon IconType => FullStatIcon.Id;
			public override int[] GetStatValues()
			{
				List<CardSlot> source = base.PlayableCard.Slot.IsPlayerSlot ? Singleton<BoardManager>.Instance.PlayerSlotsCopy : Singleton<BoardManager>.Instance.OpponentSlotsCopy;
				int num = (from slot in source
						   where slot.Card != null
						   select slot).Count((CardSlot cardSlot) => cardSlot.Card.Info.HasTrait(Trait.Gem));
				int[] array = new int[2];
				array[1] = num;
				if (num < 1 && !Singleton<TurnManager>.Instance.GameIsOver() && !Singleton<TurnManager>.Instance.Opponent.Queue.Exists((PlayableCard x) => x != null && x.Info.HasTrait(Trait.Gem)) && base.PlayableCard.Health <= 0)
				{
					Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(base.PlayableCard.Die(false));
				} else
                {
					base.PlayableCard.renderInfo.healthTextColor = new Color(0f, 0.4844f, 0.6415f, 1f);
                }
				
				return array;
			}

			public static StatIconManager.FullStatIcon InitStatIconAndAbility()
			{


				AbilityInfo MoxHealthBypass = AbilityManager.New(Plugin.PluginGuid, "Mox Power", "The value represented with this sigil will be equal to the number of Mox Cards that the owner has on their side of the table.", typeof(SigilCode.MoxHp), Tools.GetTexture("mox empowered.png"))
					.SetDefaultPart1Ability()
					.SetIcon(Tools.GetTexture("mox empowered.png"));
				MoxHp.ability = MoxHealthBypass;

				StatIconInfo info = ScriptableObject.CreateInstance<StatIconInfo>();
				info.appliesToAttack = false;
				info.appliesToHealth = true;
				info.rulebookName = "Mox Health";
				info.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
				info.rulebookDescription =
					"The value represented with this sigil will be equal to the number of Mox Cards that the owner has on their side of the table.";
				info.gbcDescription = SigilCode.HealthForAnts.MoxPowerBypass.ability.ToString();

				info.iconGraphic = Tools.GetTexture("mox empowered.png");
				info.pixelIconGraphic = Tools.getSprite("moxempowered_pixel.png");

				FullStatIcon = StatIconManager.Add(Plugin.PluginGuid, info, typeof(MoxHp));
				FullSpecial = SpecialTriggeredAbilityManager.Add(Plugin.PluginGuid, info.rulebookName, typeof(MoxHp));
				return FullStatIcon;
			}

			private static SpecialStatIcon specialStatIcon;
		}

		public class CandleSquid : VariableStatBehaviour
		{
			public static SpecialTriggeredAbilityManager.FullSpecialTriggeredAbility FullSpecial;
			public static StatIconManager.FullStatIcon FullStatIcon;

			public override SpecialStatIcon IconType => FullStatIcon.Id;

			public override int[] GetStatValues()
			{
				List<CardSlot> list = base.PlayableCard.Slot.IsPlayerSlot ? Singleton<BoardManager>.Instance.PlayerSlotsCopy : Singleton<BoardManager>.Instance.OpponentSlotsCopy;
				int index = base.PlayableCard.Slot.Index;
				int[] array = new int[2];
				array[0] = index;
				return array;
			}



			public static StatIconManager.FullStatIcon InitStatIconAndAbility()
			{
				StatIconInfo info = ScriptableObject.CreateInstance<StatIconInfo>();
				info.appliesToAttack = true;
				info.appliesToHealth = false;
				info.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.Part1Rulebook };
				info.rulebookName = "Candle Proximity";
				info.rulebookDescription =
					"The value represented with this sigil will be equal to how close this card is to the Candle on the table.";

				info.iconGraphic = Tools.GetTexture("candle proximity.png");

				FullStatIcon = StatIconManager.Add(Plugin.PluginGuid, info, typeof(CandleSquid));
				FullSpecial = SpecialTriggeredAbilityManager.Add(Plugin.PluginGuid, info.rulebookName, typeof(CandleSquid));

				return FullStatIcon;
			}

			private static SpecialStatIcon specialStatIcon;
		}

		/*
		public class BoneSquid : VariableStatBehaviour
		{
			public static SpecialTriggeredAbilityManager.FullSpecialTriggeredAbility FullSpecial;
			public static StatIconManager.FullStatIcon FullStatIcon;

			public override SpecialStatIcon IconType => FullStatIcon.Id;

			public override int[] GetStatValues()
			{
				List<CardSlot> list = base.PlayableCard.Slot.IsPlayerSlot ? Singleton<BoardManager>.Instance.PlayerSlotsCopy : Singleton<BoardManager>.Instance.OpponentSlotsCopy;
				int num = Mathf.FloorToInt((float)Singleton<ResourcesManager>.Instance.PlayerBones / 2f);
				int[] array = new int[2];
				array[0] = num;
				return array;
			}


			public static StatIconManager.FullStatIcon InitStatIconAndAbility()
			{
				StatIconInfo info = ScriptableObject.CreateInstance<StatIconInfo>();
				info.appliesToAttack = true;
				info.appliesToHealth = false;
				info.rulebookName = "Bone Power";
				info.rulebookDescription =
					"The value represented with this sigil will be equal to how many bones the card's owner has, divided by two.";

				info.iconGraphic = Tools.GetTexture("bone_stat_icon.png");

				FullStatIcon = StatIconManager.Add(uid, info, typeof(BoneSquid));
				FullSpecial = SpecialTriggeredAbilityManager.Add(uid, info.rulebookName, typeof(BoneSquid));

				return FullStatIcon;
			}

			private static SpecialStatIcon specialStatIcon;
		}

		*/
		public class KillSquid : VariableStatBehaviour
		{
			public static AbilityInfo ability;
			public static SpecialTriggeredAbilityManager.FullSpecialTriggeredAbility FullSpecial;
			public static StatIconManager.FullStatIcon FullStatIcon;

			public override SpecialStatIcon IconType => FullStatIcon.Id;

			public override int[] GetStatValues()
			{
				List<CardSlot> list = base.PlayableCard.Slot.IsPlayerSlot ? Singleton<BoardManager>.Instance.PlayerSlotsCopy : Singleton<BoardManager>.Instance.OpponentSlotsCopy;
				int num = 0;
				foreach (CardSlot cardSlot in Singleton<BoardManager>.Instance.PlayerSlotsCopy)
				{
					bool flag = cardSlot.Card != null && cardSlot.Card != base.Card && cardSlot.Card.Info.specialAbilities != base.Card.Info.specialAbilities;
					if (flag)
					{
						num += cardSlot.Card.Attack;
					}
				}
				int num2 = Mathf.CeilToInt(num / 2);
				int[] array = new int[2];
				array[0] = num2;
				return array;
			}

			public static StatIconManager.FullStatIcon InitStatIconAndAbility()
			{
				AbilityInfo KillSquide = AbilityManager.New(Plugin.PluginGuid, "Murder Power", "The value represented with this sigil will be equal to half the total amount of power on your board.", typeof(SigilCode.KillSquid), Tools.GetTexture("killsquid_icon.png"))
					.SetDefaultPart1Ability()
					.SetIcon(Tools.GetTexture("killsquid_icon.png"));
				KillSquide.powerLevel = 10;
				KillSquid.ability = KillSquide;

				StatIconInfo info = ScriptableObject.CreateInstance<StatIconInfo>();
				info.appliesToAttack = true;
				info.appliesToHealth = false;
				info.rulebookName = "Murder Power";
				info.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.Part1Rulebook };
				info.rulebookDescription =
					"The value represented with this sigil will be equal to half the total amount of power on your board.";
				info.gbcDescription = KillSquide.ability.ToString();

				info.iconGraphic = Tools.GetTexture("killsquid_icon.png");

				FullStatIcon = StatIconManager.Add(Plugin.PluginGuid, info, typeof(KillSquid));
				FullSpecial = SpecialTriggeredAbilityManager.Add(Plugin.PluginGuid, info.rulebookName, typeof(KillSquid));
				return FullStatIcon;
			}

			private static SpecialStatIcon specialStatIcon;
		}

		public class SpellPower : VariableStatBehaviour
		{
			public static AbilityInfo ability;
			public static SpecialTriggeredAbilityManager.FullSpecialTriggeredAbility FullSpecial;
			public static StatIconManager.FullStatIcon FullStatIcon;

			public override SpecialStatIcon IconType => FullStatIcon.Id;

			public override int[] GetStatValues()
			{
				int[] array = new int[2];
				array[0] = Convert.ToInt32( Math.Floor(MagnificusMod.Plugin.spellsPlayed * 1.5f) );
				return array;
			}

			public static StatIconManager.FullStatIcon InitStatIconAndAbility()
			{
				AbilityInfo SpellPowere = AbilityManager.New(Plugin.PluginGuid, "Spell Power", "The value represented with this sigil will be equal to total amount of spells played during the battles, times 1.5.", typeof(SigilCode.SpellPower), Tools.GetTexture("spellpower.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.GetTexture("spellpower.png"));
				SpellPowere.powerLevel = 10;
				SpellPower.ability = SpellPowere;
				StatIconInfo info = ScriptableObject.CreateInstance<StatIconInfo>();
				info.appliesToAttack = true;
				info.appliesToHealth = false;
				info.rulebookName = "Spell Power";
				info.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.Part1Rulebook };
				info.rulebookDescription =
					"The value represented with this sigil will be equal to total amount of spells played during the battle, times 1.5.";
				info.gbcDescription = SpellPowere.ability.ToString();

				info.iconGraphic = Tools.GetTexture("spellpower.png");

				FullStatIcon = StatIconManager.Add(Plugin.PluginGuid, info, typeof(SpellPower));
				FullSpecial = SpecialTriggeredAbilityManager.Add(Plugin.PluginGuid, info.rulebookName, typeof(SpellPower));

				return FullStatIcon;
			}

			private static SpecialStatIcon specialStatIcon;
		}

		public class CounterBatteryPower : VariableStatBehaviour
		{
			public static AbilityInfo ability;
			public static SpecialTriggeredAbilityManager.FullSpecialTriggeredAbility FullSpecial;
			public static StatIconManager.FullStatIcon FullStatIcon;

			public override SpecialStatIcon IconType => FullStatIcon.Id;

			public override int[] GetStatValues()
			{
				int[] array = new int[2];
				int hp = Singleton<MagnificusLifeManager>.Instance.playerLife;
				float damage = 10 - hp;
				if (KayceeStorage.IsKaycee && MagnificusMod.Generation.challenges.Contains("FadingMox"))
				{
					damage = KayceeStorage.FleetingLife - hp;
				}
				array[0] = Convert.ToInt32(Math.Floor(damage / 2));
				return array;
			}

			public static StatIconManager.FullStatIcon InitStatIconAndAbility()
			{
				AbilityInfo BPowere = AbilityManager.New(Plugin.PluginGuid, "Counterbattery Power", "The value represented with this sigil will be equal to the amount of damage taken by you this battle, divided by two.", typeof(SigilCode.CounterBatteryPower), Tools.GetTexture("spellpower.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.GetTexture("batterypower.png"));
				BPowere.powerLevel = 10;
				CounterBatteryPower.ability = BPowere;

				StatIconInfo info = ScriptableObject.CreateInstance<StatIconInfo>();
				info.appliesToAttack = true;
				info.appliesToHealth = false;
				info.rulebookName = "Counterbattery Power";
				info.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.Part1Rulebook };
				info.rulebookDescription =
					"The value represented with this sigil will be equal to the amount of damage taken by you this battle, divided by two.";
				info.gbcDescription = BPowere.ability.ToString();

				info.iconGraphic = Tools.GetTexture("batterypower.png");

				FullStatIcon = StatIconManager.Add(Plugin.PluginGuid, info, typeof(CounterBatteryPower));
				FullSpecial = SpecialTriggeredAbilityManager.Add(Plugin.PluginGuid, info.rulebookName, typeof(CounterBatteryPower));
				
				return FullStatIcon;
			}

			private static SpecialStatIcon specialStatIcon;
		}

		[HarmonyPatch(typeof(StatIconInteractable), "OnAlternateSelectStarted")]
		public class finallyMakeStatIconsRuleBookWork
		{
			public static bool Prefix(ref StatIconInteractable __instance)
			{
				if (SceneLoader.ActiveSceneName != "finale_magnificus") { return true; }
				Singleton<RuleBookController>.Instance.OpenToAbilityPage(StatIconInfo.GetIconInfo(__instance.statIcon).gbcDescription, __instance.card);
				return false;
			}
		}

		public class LifeUpOmega : AbilityBehaviour
		{
			public override Ability Ability
			{
				get
				{
					return LifeUpOmega.ability;
				}
			}

			public bool HasGems(bool onResolve)
			{
				if (onResolve && base.Card.OpponentCard)
				{
					if (Singleton<TurnManager>.Instance.Opponent.Queue.Exists((PlayableCard x) => x != null && x.Info.HasTrait(Trait.Gem) && x.Slot.Card == null))
					{
						return true;
					}
				}
				return (base.Card.OpponentCard ? Singleton<BoardManager>.Instance.OpponentSlotsCopy : Singleton<BoardManager>.Instance.PlayerSlotsCopy).Exists((CardSlot x) => x.Card != null && x.Card.Info.HasTrait(Trait.Gem));
			}

			public override bool RespondsToOtherCardDie(PlayableCard card, CardSlot deathSlot, bool fromCombat, PlayableCard killer)
			{
				return base.Card.OnBoard && deathSlot.Card != null && deathSlot.Card.OpponentCard == base.Card.OpponentCard && deathSlot.Card != base.Card && !this.currentlyResurrectingCards.Contains(deathSlot.Card.Info) && deathSlot.Card == card && !(card.HasAbility(Ability.GemDependant) && !HasGems(false)) && !card.HasTrait(Trait.EatsWarrens);
			}

			public override IEnumerator OnOtherCardDie(PlayableCard card, CardSlot deathSlot, bool fromCombat, PlayableCard killer)
			{
				yield return base.PreSuccessfulTriggerSequence();
				this.currentlyResurrectingCards.Add(deathSlot.Card.Info);
				yield return Singleton<BoardManager>.Instance.CreateCardInSlot(deathSlot.Card.Info, deathSlot, 0.1f, true);
				yield return new WaitForSeconds(0.1f);
				yield return base.LearnAbility(0.5f);
				this.currentlyResurrectingCards.Clear();
				bool flag = base.Card != null && !base.Card.Dead;
				if (flag)
				{
					bool flag2 = !SaveManager.SaveFile.IsPart2;
					if (flag2)
					{
						Singleton<ViewManager>.Instance.SwitchToView(View.Board, false, false);
						yield return new WaitForSeconds(0.1f);
					}
					CardModificationInfo mod = new CardModificationInfo();
					mod.healthAdjustment = -3;
					int predict = base.Card.Health - 3;
					if (predict <= 0)
					{
						yield return base.Card.Die(false);

					}
					else
					{
						base.Card.AddTemporaryMod(mod);
					}
					yield return base.LearnAbility(0.25f);
					bool flag3 = !SaveManager.SaveFile.IsPart2;
					if (flag3)
					{
						yield return new WaitForSeconds(0.1f);
					}
				}
				yield break;
			}

			public static Ability ability;

			private List<CardInfo> currentlyResurrectingCards = new List<CardInfo>();
		}

		public class RandomPower : AbilityBehaviour
		{
			public override Ability Ability
			{
				get
				{
					return RandomPower.ability;
				}
			}
			

			public override bool RespondsToTurnEnd(bool playerTurnEnd)
			{
				return base.Card.OpponentCard != playerTurnEnd;
			}

			public override IEnumerator OnTurnEnd(bool playerTurnEnd)
			{
				int baseAttack = base.Card.Attack;
				int negative = 0 - baseAttack;
				List<int> attackRange = new List<int>();
				bool alreadyMod = false;
				int selectedAttack = 0;
				foreach (CardModificationInfo mod in base.Card.temporaryMods)
                {
					if (mod.singletonId is null) { continue; }
					if (mod.singletonId.Contains("randompower"))
                    {
						alreadyMod = true;
						baseAttack = int.Parse(mod.singletonId.Split('|')[1]);
						negative = 0 - baseAttack;
						for (int i = 0; i < baseAttack + 1; i++)
						{
							if (i == 0 && baseAttack == 0)
							{
								attackRange.Add(1);
							}
							attackRange.Add(i);
						}
						selectedAttack = attackRange[Random.RandomRangeInt(0, attackRange.Count)];
						if (selectedAttack == Card.Attack)
						{
							attackRange.Remove(selectedAttack);
							selectedAttack = attackRange[Random.RandomRangeInt(0, attackRange.Count)];
						}
						negative += selectedAttack;
						mod.attackAdjustment = negative;
					}
                }

				if (alreadyMod) { yield break; }
				for (int i = 0; i < baseAttack + 1; i++)
				{
					if (i == 0 && baseAttack == 0)
                    {
						attackRange.Add(1);
                    }
					attackRange.Add(i);
				}
				selectedAttack = attackRange[Random.RandomRangeInt(0, attackRange.Count)];
				if (selectedAttack == Card.Attack)
                {
					attackRange.Remove(selectedAttack);
					selectedAttack = attackRange[Random.RandomRangeInt(0, attackRange.Count)];
				}
				negative += selectedAttack;
				CardModificationInfo cardModificationInfo = new CardModificationInfo();
				cardModificationInfo.nonCopyable = true;
				cardModificationInfo.singletonId = "randompower|" + baseAttack;
				cardModificationInfo.attackAdjustment = negative;
				cardModificationInfo.healthAdjustment = 0;
				base.Card.AddTemporaryMod(cardModificationInfo);
				yield break;
			}

			public static Ability ability;

			private CardModificationInfo mod;
		}

		public class ImprovedSteelTrap : AbilityBehaviour
		{
			public override Ability Ability
			{
				get
				{
					return ImprovedSteelTrap.ability;
				}
			}

			public override bool RespondsToTakeDamage(PlayableCard source)
			{
				return Singleton<BoardManager>.Instance is BoardManager3D;
			}

			public override bool RespondsToDie(bool wasSacrifice, PlayableCard killer)
			{
				return !wasSacrifice && base.Card.OnBoard;
			}

			public override IEnumerator OnDie(bool wasSacrifice, PlayableCard killer)
			{
				bool flag = base.Card.Slot.opposingSlot.Card != null;
				if (flag)
				{
					yield return base.PreSuccessfulTriggerSequence();
					yield return new WaitForSeconds(0.25f);
					yield return base.Card.Slot.opposingSlot.Card.Die(false, base.Card, true);
					bool flag2 = Singleton<BoardManager>.Instance is BoardManager3D;
					if (flag2)
					{
						yield return new WaitForSeconds(0.5f);
						yield return base.LearnAbility(0.5f);
					}
				}
				yield break;
			}

			public static Ability ability;
		}

		public class SummonRunes : CreateCardsAdjacent
		{
			public override Ability Ability
			{
				get
				{
					return SummonRunes.ability;
				}
			}

			public override string SpawnedCardId
			{
				get
				{
					return "mag_runes";
				}
			}

			public override string CannotSpawnDialogue
			{
				get
				{
					return "It appears that there is no room for the runes.";
				}
			}

			public static Ability ability;
		}

		public class PlatingWork : AbilityBehaviour
		{
			public override Ability Ability
			{
				get
				{
					return PlatingWork.ability;
				}
			}

			public override bool RespondsToResolveOnBoard()
			{
				return true;
			}

			public override IEnumerator OnResolveOnBoard()
			{
				List<CardSlot> list = Singleton<BoardManager>.Instance.PlayerSlotsCopy.FindAll((CardSlot x) => x.Card != null);
				bool flag = !base.Card.slot.IsPlayerSlot;
				if (flag)
				{
					list = Singleton<BoardManager>.Instance.opponentSlots.FindAll((CardSlot x) => x.Card != null);
				}
				yield return base.PreSuccessfulTriggerSequence();
				CardModificationInfo mod = new CardModificationInfo();
				mod.abilities.Add(Ability.Sharp);
				mod.healthAdjustment = 2;
				foreach (CardSlot slot in list)
				{
					bool flag2 = slot.Card.Info.HasTrait(Trait.Gem);
					if (flag2)
					{
						bool flag3 = slot.Card != null;
						if (flag3)
						{
							slot.Card.AddTemporaryMod(mod);
						}
					}
				}
				list = Singleton<BoardManager>.Instance.GetSlots(base.Card.slot.IsPlayerSlot);
				string slotName = base.Card.slot.IsPlayerSlot ? "PlayerSlots" : "OpponentSlots";
				foreach (CardSlot slot in list)
				{
					if (slot.Card != null && slot.Card.Info != base.Card.Info)
					{
						int dex;
						dex = slot.Index;
						if (GameObject.Find(slotName).transform.GetChild(dex).childCount > 5)
						{
							GameObject model = GameObject.Find(slotName).transform.GetChild(dex).GetChild(5).gameObject;
							model.GetComponent<Card>().RenderCard();
						}
					}
				}
				List<CardSlot>.Enumerator enumerator = default(List<CardSlot>.Enumerator);
				yield return base.LearnAbility(0f);
				yield break;
			}

			public override bool RespondsToOtherCardResolve(PlayableCard otherCard)
			{
				return (otherCard.slot.IsPlayerSlot && base.Card.slot.IsPlayerSlot) || (base.Card.OpponentCard && otherCard.OpponentCard);
			}

			public override IEnumerator OnOtherCardResolve(PlayableCard otherCard)
			{
				CardModificationInfo mod = new CardModificationInfo();
				mod.abilities.Add(Ability.Sharp);
				mod.healthAdjustment = 2;
				bool flag = otherCard.Info.HasTrait(Trait.Gem);
				if (flag)
				{
					otherCard.AddTemporaryMod(mod);
				}
				yield return base.LearnAbility(0f);
				yield break;
			}

			public static Ability ability;
		}

		public class Animator : AbilityBehaviour
		{
			public override Ability Ability
			{
				get
				{
					return Animator.ability;
				}
			}

			public override bool RespondsToResolveOnBoard()
			{
				return true;
			}

			public override IEnumerator OnResolveOnBoard()
			{
				List<CardSlot> list = Singleton<BoardManager>.Instance.PlayerSlotsCopy.FindAll((CardSlot x) => x.Card != null);
				if (!base.Card.slot.IsPlayerSlot)
				{
					list = Singleton<BoardManager>.Instance.opponentSlots.FindAll((CardSlot x) => x.Card != null);
				}
				yield return base.PreSuccessfulTriggerSequence();
				CardModificationInfo mod = new CardModificationInfo();
				mod.attackAdjustment = 2;
				mod.singletonId = "puppet";
				foreach (CardSlot slot in list)
				{
					if (slot.Card != null && slot.Card.Attack == 0 && !slot.Card.HasTrait(Trait.Gem) && slot.Card != base.Card)
					{
						slot.Card.AddTemporaryMod(mod);
					}
				}
				yield return base.LearnAbility(0f);
				yield break;
			}

			public override bool RespondsToOtherCardResolve(PlayableCard otherCard)
			{
				return (otherCard.slot.IsPlayerSlot && base.Card.slot.IsPlayerSlot) || (base.Card.OpponentCard && otherCard.OpponentCard);
			}

			public override IEnumerator OnOtherCardResolve(PlayableCard otherCard)
			{
				CardModificationInfo mod = new CardModificationInfo();
				mod.attackAdjustment = 2;
				mod.singletonId = "puppet";
				if (otherCard.Attack == 0 && !otherCard.HasTrait(Trait.Gem))
				{
					otherCard.AddTemporaryMod(mod);
				}
				yield return base.LearnAbility(0f);
				yield break;
			}

			public override bool RespondsToDie(bool wasSacrifice, PlayableCard killer)
			{
				return true;
			}

			public override IEnumerator OnDie(bool wasSacrifice, PlayableCard killer)
			{
				List<CardSlot> list = Singleton<BoardManager>.Instance.PlayerSlotsCopy.FindAll((CardSlot x) => x.Card != null);
				if (!base.Card.slot.IsPlayerSlot)
				{
					list = Singleton<BoardManager>.Instance.opponentSlots.FindAll((CardSlot x) => x.Card != null);
				}
				foreach (CardSlot slot in list)
				{
					if (slot.Card != null)
                    {
						for (int i = 0; i < slot.Card.temporaryMods.Count; i++)
                        {
							if (slot.Card.temporaryMods[i].singletonId != null)
                            {
								if (slot.Card.temporaryMods[i].singletonId == "puppet")
                                {
									slot.Card.temporaryMods.RemoveAt(i);
									break;
                                }
                            }
                        }
                    }
				}
				yield return base.LearnAbility(0f);
				yield break;
			}

			public static Ability ability;
		}

		public class GemGuardianFix : AbilityBehaviour
		{
			public override Ability Ability
			{
				get
				{
					return GemGuardianFix.ability;
				}
			}

			public override bool RespondsToResolveOnBoard()
			{
				return true;
			}

			public override IEnumerator OnResolveOnBoard()
			{
				List<CardSlot> list = Singleton<BoardManager>.Instance.PlayerSlotsCopy.FindAll((CardSlot x) => x.Card != null);
				bool flag = !base.Card.slot.IsPlayerSlot;
				if (flag)
				{
					list = Singleton<BoardManager>.Instance.opponentSlots.FindAll((CardSlot x) => x.Card != null);
				}
				yield return base.PreSuccessfulTriggerSequence();
				CardModificationInfo mod = new CardModificationInfo();
				mod.abilities.Add(Ability.DeathShield);
				foreach (CardSlot slot in list)
				{
					bool flag2 = slot.Card.Info.HasTrait(Trait.Gem);
					if (flag2)
					{
						bool flag3 = slot.Card != null;
						if (flag3)
						{
							slot.Card.AddTemporaryMod(mod);
						}
					}
				}
				list = Singleton<BoardManager>.Instance.GetSlots(base.Card.slot.IsPlayerSlot);
				string slotName = base.Card.slot.IsPlayerSlot ? "PlayerSlots" : "OpponentSlots";
				foreach (CardSlot slot in list)
				{
					if (slot.Card != null && slot.Card.Info != base.Card.Info)
					{
						int dex;
						dex = slot.Index;
						if (GameObject.Find(slotName).transform.GetChild(dex).childCount > 5)
						{
							GameObject model = GameObject.Find(slotName).transform.GetChild(dex).GetChild(5).gameObject;
							model.GetComponent<Card>().RenderCard();
						}
					}
				}
				List<CardSlot>.Enumerator enumerator = default(List<CardSlot>.Enumerator);
				yield return base.LearnAbility(0f);
				yield break;
			}

			public override bool RespondsToOtherCardResolve(PlayableCard otherCard)
			{
				return (otherCard.slot.IsPlayerSlot && base.Card.slot.IsPlayerSlot) || (base.Card.OpponentCard && otherCard.OpponentCard);
			}

			public override IEnumerator OnOtherCardResolve(PlayableCard otherCard)
			{
				CardModificationInfo mod = new CardModificationInfo();
				mod.abilities.Add(Ability.DeathShield);
				bool flag = otherCard.Info.HasTrait(Trait.Gem);
				if (flag)
				{
					otherCard.AddTemporaryMod(mod);
				}
				yield return base.LearnAbility(0f);
				yield break;
			}

			public static Ability ability;
		}

		public class GemAbsorber : AbilityBehaviour
		{
			public override Ability Ability
			{
				get
				{
					return GemAbsorber.ability;
				}
			}

			public override bool RespondsToResolveOnBoard()
			{
				return true;
			}

			public override IEnumerator OnResolveOnBoard()
			{
				yield return base.PreSuccessfulTriggerSequence();
				int numGems = base.Card.slot.IsPlayerSlot ? Singleton<BoardManager>.Instance.PlayerSlotsCopy.FindAll((CardSlot x) => x.Card != null && x.Card.Info.HasTrait(Trait.Gem)).Count : Singleton<BoardManager>.Instance.OpponentSlotsCopy.FindAll((CardSlot x) => x.Card != null && x.Card.Info.HasTrait(Trait.Gem)).Count;
				List<CardSlot> list = base.Card.slot.IsPlayerSlot ? Singleton<BoardManager>.Instance.PlayerSlotsCopy.FindAll((CardSlot x) => x.Card != null) : Singleton<BoardManager>.Instance.OpponentSlotsCopy.FindAll((CardSlot x) => x.Card != null);
				int attack = numGems;
				int health = numGems * 2;
				foreach (CardSlot slot in list)
				{
					if (slot.Card != null)
					{
						bool flag = slot.Card.Info.HasTrait(Trait.Gem);
						if (flag)
						{
							yield return slot.Card.Die(false, null, true);
						}
					}
				}
				List<CardSlot>.Enumerator enumerator = default(List<CardSlot>.Enumerator);
				bool flag2 = numGems > 0;
				if (flag2)
				{
					CardModificationInfo cardModificationInfo = new CardModificationInfo();
					cardModificationInfo.nonCopyable = true;
					cardModificationInfo.singletonId = "zeroout";
					cardModificationInfo.attackAdjustment = attack;
					cardModificationInfo.healthAdjustment = health;
					base.Card.AddTemporaryMod(cardModificationInfo);
					this.mod = new CardModificationInfo();
					this.mod.nonCopyable = true;
					this.mod.singletonId = "statswap";
					this.mod.attackAdjustment = 0;
					this.mod.healthAdjustment = 0;
					base.Card.AddTemporaryMod(this.mod);
					yield break;
				}
				yield return base.LearnAbility(0f);
				yield break;
			}

			public static Ability ability;

			private CardModificationInfo mod;
		}

		public class Multiplication : AbilityBehaviour
		{
			public override Ability Ability
			{
				get
				{
					return Multiplication.ability;
				}
			}

			public override bool RespondsToResolveOnBoard()
			{
				return true;
			}

			public override IEnumerator OnResolveOnBoard()
			{
				Singleton<ViewManager>.Instance.SwitchToView(View.Board, false, false);
				CardSlot toLeft = Singleton<BoardManager>.Instance.GetAdjacent(base.Card.Slot, true);
				CardSlot toRight = Singleton<BoardManager>.Instance.GetAdjacent(base.Card.Slot, false);
				CardSlot opposingSlot = base.Card.slot.opposingSlot;
				bool toLeftValid = toLeft != null && toLeft.Card == null;
				bool toRightValid = toRight != null && toRight.Card == null;
				bool opposing = opposingSlot != null && base.Card.slot.opposingSlot.Card == null;
				yield return base.PreSuccessfulTriggerSequence();
				bool flag = toLeftValid;
				if (flag)
				{
					yield return new WaitForSeconds(0.1f);
					yield return this.SpawnCardOnSlot(toLeft);
				}
				bool flag2 = toRightValid;
				if (flag2)
				{
					yield return new WaitForSeconds(0.1f);
					yield return this.SpawnCardOnSlot(toRight);
				}
				bool flag3 = opposing;
				if (flag3)
				{
					yield return new WaitForSeconds(0.1f);
					yield return this.SpawnCardOnSlot(opposingSlot);
				}
				bool flag4 = toLeftValid || toRightValid;
				if (flag4)
				{
					yield return base.LearnAbility(0f);
				}
				yield break;
			}

			private IEnumerator SpawnCardOnSlot(CardSlot slot)
			{
				yield return Singleton<BoardManager>.Instance.CreateCardInSlot(CardLoader.GetCardByName(base.Card.Info.name), slot, 0.15f, true);
				yield break;
			}

			public static Ability ability;
		}

		public class submergekraken : Submerge
		{
			public override Ability Ability
			{
				get
				{
					return submergekraken.ability;
				}
			}

			public override void OnResurface()
			{
				base.Card.SetInfo(CardLoader.GetCardByName(submergekraken.SQUIDS[UnityEngine.Random.Range(0, submergekraken.SQUIDS.Length)]));
			}

			public static Ability ability;

			private static readonly string[] SQUIDS = new string[]
			{
				"mag_killsquid",
				"mag_spellsquid",
				"mag_counterbatterysquid"
			};
		}

		public class FamiliarA : AbilityBehaviour
		{
			public override Ability Ability
			{
				get
				{
					return FamiliarA.ability;
				}
			}

			public override bool RespondsToUpkeep(bool playerUpkeep)
			{
				return base.Card != null && base.Card.OpponentCard != playerUpkeep && !base.Card.Dead && !this.HasNonSac(false);
			}

			public override IEnumerator OnUpkeep(bool playerUpkeep)
			{
				yield return base.PreSuccessfulTriggerSequence();
				yield return base.Card.Die(false, null, true);
				yield break;
			}

			public override bool RespondsToResolveOnBoard()
			{
				return base.Card != null && !base.Card.Dead && !this.HasNonSac(true);
			}

			public override IEnumerator OnResolveOnBoard()
			{
				yield return base.PreSuccessfulTriggerSequence();
				if (!base.Card.slot.IsPlayerSlot && base.Card.OriginatedFromQueue)
				{
					GameObject.Find("OpponentSlots").transform.GetChild(base.Card.slot.Index).transform.Find("QueuedCardFrame").gameObject.SetActive(false);
				}
				yield return base.Card.Die(false, null, true);
				yield return base.LearnAbility(0.25f);
				yield break;
			}

			private bool HasNonSac(bool onResolve = false)
			{
				bool flag = onResolve && base.Card.OpponentCard;
				if (flag)
				{
					bool flag2 = Singleton<TurnManager>.Instance.Opponent.Queue.Exists((PlayableCard x) => x != null && !x.Info.HasTrait(Trait.Terrain) && x.Slot.Card == null && !x.Info.HasAbility(FamiliarA.ability) && !x.Info.HasTrait(Trait.Gem) || x != null && x.Info.HasTrait(Trait.KillsSurvivors));
					if (flag2)
					{
						return true;
					}
				}
				return (base.Card.OpponentCard ? Singleton<BoardManager>.Instance.OpponentSlotsCopy : Singleton<BoardManager>.Instance.PlayerSlotsCopy).Exists((CardSlot x) => x.Card != null && !x.Card.Info.HasAbility(FamiliarA.ability) && x.Card != null && !x.Card.Info.HasTrait(Trait.Terrain) && x.Card != null && !x.Card.Info.HasTrait(Trait.Gem) && !x.Card.Info.ModAbilities.Contains(FamiliarA.ability) || x.Card != null && x.Card.Info.HasTrait(Trait.KillsSurvivors));
			}

			public static Ability ability;
		}



		public class Ditto : AbilityBehaviour
		{
			public override Ability Ability
			{
				get
				{
					return ability;
				}
			}

			public override bool RespondsToResolveOnBoard()
			{
				return true;
			}
			public override IEnumerator OnResolveOnBoard()
			{
				if (base.Card.slot.opposingSlot.Card != null)
				{
					Singleton<ViewManager>.Instance.SwitchToView(View.WizardBattleSlots);
					CardInfo cardLol = CardLoader.GetCardByName(base.Card.slot.opposingSlot.Card.Info.name);
					base.Card.SetInfo(cardLol);
					if (cardLol.name == "mag_giantmoon" || cardLol.name == "mag_giantearth")
                    {
						base.Card.SetInfo(CardLoader.GetCardByName("mag_giantmoonshards"));
                    } else if (cardLol.name == "mag_giantmagnus")
					{
						base.Card.SetInfo(CardLoader.GetCardByName("mag_mastertriple3"));
					}
					foreach (CardModificationInfo mod in base.Card.slot.opposingSlot.Card.Info.Mods)
					{
						base.Card.AddTemporaryMod(mod);
					}
					base.Card.Anim.PlayTransformAnimation();
					if (base.Card.Info.Abilities.Contains(Ability.GainGemGreen))
                    {
						yield return Singleton<ResourcesManager>.Instance.AddGem(GemType.Green);
					}
					if (base.Card.Info.Abilities.Contains(Ability.GainGemBlue))
					{
						yield return Singleton<ResourcesManager>.Instance.AddGem(GemType.Blue);
					}
					if (base.Card.Info.Abilities.Contains(Ability.GainGemOrange))
					{
						yield return Singleton<ResourcesManager>.Instance.AddGem(GemType.Orange);
					}
				}
				else
				{
					yield return base.Card.Die(false);
				}
				yield break;
			}

			public static Ability ability;
		}


		public class FecundityCycle : DrawCreatedCard
		{
			public override Ability Ability
			{
				get
				{
					return ability;
				}
			}

			public override CardInfo CardToDraw
			{
				get
				{
					return base.Card.Info;
				}
			}

			public override List<CardModificationInfo> CardToDrawTempMods
			{
				get
				{
					return new List<CardModificationInfo>();
				}
			}
			public override bool RespondsToResolveOnBoard()
			{
				return true;
			}
			public override IEnumerator OnResolveOnBoard()
			{
				if (base.Card.Info.BloodCost < 1 && base.Card.Info.GemsCost.Count > 0)
				{
					List<GemType> baseCost = base.Card.Info.gemsCost;
					CardModificationInfo mod = new CardModificationInfo();
					List<GemType> newGem = new List<GemType>();
					mod.nullifyGemsCost = true;

					switch (baseCost[0])
					{
						case GemType.Blue:
							newGem = new List<GemType> { GemType.Orange };
							if (baseCost.Count > 1)
							{
								newGem.Add(GemType.Blue);
							}
							break;
						case GemType.Orange:
							newGem = new List<GemType> { GemType.Green };
							if (baseCost.Count > 1)
							{
								newGem.Add(GemType.Orange);
							}
							break;
						case GemType.Green:
							newGem = new List<GemType> { GemType.Blue };
							if (baseCost.Count > 1)
							{
								newGem.Add(GemType.Green);
							}
							break;
					}

					mod.addGemCost = newGem;
					CardInfo info = Instantiate(base.Card.Info);

					List<CardModificationInfo> modList = new List<CardModificationInfo> { mod };
					info.mods.Add(mod);

					foreach(CardModificationInfo baseMod in base.Card.Info.mods)
                    {
						modList.Add(baseMod);
                    }
					foreach (CardModificationInfo tempMod in base.Card.temporaryMods)
					{
						modList.Add(tempMod);
					}
					yield return base.PreSuccessfulTriggerSequence();
					yield return Singleton<CardSpawner>.Instance.SpawnCardToHand(info, modList, 0.25f, null);
				}
				else
				{
					CardInfo info = Instantiate(base.Card.Info);
					yield return base.PreSuccessfulTriggerSequence();
					List<CardModificationInfo> modList = new List<CardModificationInfo>();
					foreach (CardModificationInfo baseMod in base.Card.Info.mods)
					{
						modList.Add(baseMod);
					}
					foreach (CardModificationInfo tempMod in base.Card.temporaryMods)
					{
						modList.Add(tempMod);
					}
					if (base.Card.Info.GetExtendedProperty("ManaCost") == null)
					{
						info.SetExtendedProperty("ManaCost", base.Card.Info.GetExtendedProperty("ManaCost") == null);
					}
					yield return Singleton<CardSpawner>.Instance.SpawnCardToHand(info, modList, 0.25f, null);
					if (base.Card.Info.GetExtendedProperty("ManaCost") != null && !SavedVars.LearnedMechanics.Contains("bloodcycle;"))
					{
						SavedVars.LearnedMechanics += "bloodcycle;";
						yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("... Curious.", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
						yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("I thought I had completely removed this.. [c:g2]filth[c:].", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
					}
				}
				yield return base.LearnAbility(0f);
				yield break;
			}

			public static Ability ability;
		}

		public class MoxCycling : AbilityBehaviour
		{
			public override Ability Ability
			{
				get
				{
					return ability;
				}
			}

			public override bool RespondsToUpkeep(bool playerUpkeep)
			{
				return playerUpkeep;
			}

			public override IEnumerator OnUpkeep(bool playerUpkeep)
			{
				List<CardSlot> slots = Singleton<BoardManager>.Instance.GetSlots(base.Card.slot.IsPlayerSlot);
				foreach (CardSlot slot in slots)
				{
					if (slot.Card != null)
					{
						if (slot.Card.Info.HasTrait(Trait.Gem) && slot.Card.Info.name != "mag_crystalworm")
						{
							slot.Card.SetCardback(Tools.getImage("magcardback.png"));
							if (slot.Card.Info.abilities.Count == 1)
							{
								slot.Card.Anim.SetFaceDown(true);
								CardInfo info = slot.Card.Info;
								switch (slot.Card.Info.abilities[0])
								{
									case Ability.GainGemGreen:
										info = CardLoader.GetCardByName("mag_bluemox");
										break;
									case Ability.GainGemBlue:
										info = CardLoader.GetCardByName("mag_rubymox");
										break;
									case Ability.GainGemOrange:
										info = CardLoader.GetCardByName("mag_greenmox");
										break;
								}
								slot.Card.SetInfo(info);
								yield return new WaitForSeconds(0.25f);
								slot.Card.Anim.SetFaceDown(false);
							}
							else if (slot.Card.Info.abilities.Count == 2)
							{
								slot.Card.Anim.SetFaceDown(true);
								CardInfo info = slot.Card.Info;
								if (slot.Card.Info.abilities.Contains(Ability.GainGemGreen) && slot.Card.Info.abilities.Contains(Ability.GainGemOrange))
								{
									info = CardLoader.GetCardByName("mag_orlumox");
								}
								else if (slot.Card.Info.abilities.Contains(Ability.GainGemBlue) && slot.Card.Info.abilities.Contains(Ability.GainGemOrange))
								{
									info = CardLoader.GetCardByName("mag_bleenemox");
								}
								else if (slot.Card.Info.abilities.Contains(Ability.GainGemBlue) && slot.Card.Info.abilities.Contains(Ability.GainGemGreen))
								{
									info = CardLoader.GetCardByName("mag_goranjmox");
								}
								slot.Card.SetInfo(info);
								yield return new WaitForSeconds(0.25f);
								slot.Card.Anim.SetFaceDown(false);
							}
							Singleton<ResourcesManager>.Instance.ForceGemsUpdate();
						}
					}
				}
				yield break;
			}


			public static Ability ability;
		}

		public class Ignite : AbilityBehaviour
		{
			public override Ability Ability
			{
				get
				{
					return ability;
				}
			}

			public override bool RespondsToResolveOnBoard()
			{
				return true;
			}
			public override IEnumerator OnResolveOnBoard()
			{
				List<CardSlot> slots = base.Card.slot.IsPlayerSlot ? Singleton<BoardManager>.Instance.opponentSlots : Singleton<BoardManager>.Instance.playerSlots;
				foreach (CardSlot slot in slots)
                {
					if (slot.Card == null)
                    {
						yield return Singleton<BoardManager>.Instance.CreateCardInSlot(CardLoader.GetCardByName("mag_orluflame"), slot, 0.1f, true);
					}
                }
				yield break;
			}


			public static Ability ability;
		}

		public class NullifySigils : AbilityBehaviour
		{
			public override Ability Ability
			{
				get
				{
					return ability;
				}
			}

			public override bool RespondsToOtherCardResolve(PlayableCard otherCard)
			{
				return otherCard.slot.opposingSlot.Card == base.Card && otherCard != null && !otherCard.Dead;
			}

			public override IEnumerator OnOtherCardResolve(PlayableCard otherCard)
			{
				CardModificationInfo nullify = new CardModificationInfo();
				nullify.negateAbilities = base.Card.slot.opposingSlot.Card.Info.abilities;
				base.Card.slot.opposingSlot.Card.AddTemporaryMod(nullify);
				string slotName = base.Card.slot.IsPlayerSlot ? "OpponentSlots" : "PlayerSlots";
				foreach (CardSlot slot in Singleton<BoardManager>.Instance.OpponentSlotsCopy)
				{
					if (slot.Card != null && slot.Card.Info != base.Card.Info)
					{
						int dex;
						dex = slot.Index;
						if (GameObject.Find(slotName).transform.GetChild(dex).childCount > 5)
						{
							GameObject model = GameObject.Find(slotName).transform.GetChild(dex).GetChild(5).gameObject;
							model.GetComponent<Card>().RenderCard();
						}
					}
				}
				yield break;
			}

			public override bool RespondsToResolveOnBoard()
			{
				return true;
			}
			public override IEnumerator OnResolveOnBoard()
			{
				if (base.Card.slot.opposingSlot.Card != null)
				{
					CardModificationInfo nullify = new CardModificationInfo();
					nullify.negateAbilities = base.Card.slot.opposingSlot.Card.Info.abilities;
					base.Card.slot.opposingSlot.Card.AddTemporaryMod(nullify);
					string slotName = base.Card.slot.IsPlayerSlot ? "OpponentSlots" : "PlayerSlots";
					foreach (CardSlot slot in Singleton<BoardManager>.Instance.OpponentSlotsCopy)
					{
						if (slot.Card != null && slot.Card.Info != base.Card.Info)
						{
							int dex;
							dex = slot.Index;
							if (GameObject.Find(slotName).transform.GetChild(dex).childCount > 5)
							{
								GameObject model = GameObject.Find(slotName).transform.GetChild(dex).GetChild(5).gameObject;
								model.GetComponent<Card>().RenderCard();
							}
						}
					}
				}
				yield break;
			}


			public static Ability ability;
		}

		public class DrawMoxFromSideDeck : AbilityBehaviour
		{
			public override Ability Ability
			{
				get
				{
					return ability;
				}
			}

			public override bool RespondsToUpkeep(bool playerUpkeep)
			{
				return playerUpkeep;
			}

			public override IEnumerator OnUpkeep(bool playerUpkeep)
			{
				if (Singleton<CardDrawPiles3D>.Instance.SideDeck.CardsInDeck > 0)
				{
					yield return Singleton<CardDrawPiles3D>.Instance.DrawFromSidePile();
				}
				yield break;
			}


			public static Ability ability;
		}

		public class FadingA : AbilityBehaviour
		{
			public override Ability Ability
			{
				get
				{
					return ability;
				}
			}

			public override bool RespondsToUpkeep(bool playerUpkeep)
			{
				return playerUpkeep;
			}

			public override IEnumerator OnUpkeep(bool playerUpkeep)
			{
				if (!base.Card.Dead)
				{
					ChallengeActivationUI.TryShowActivation(KayceeFixes.ChallengeManagement.FadingMox);
					yield return base.Card.Die(false);
				}
				yield break;
			}


			public static Ability ability;
		}

		public class MidasTouchA : AbilityBehaviour
		{
			public override Ability Ability
			{
				get
				{
					return MidasTouchA.ability;
				}
			}

			public override bool RespondsToDealDamage(int amount, PlayableCard target)
			{
				return amount > 0 && target != null && !target.Dead && !target.HasAbility(DropMana.ability) && !target.InOpponentQueue;
			}

			public override IEnumerator OnDealDamage(int amount, PlayableCard target)
			{
				yield return new WaitForSeconds(0.15f);
				if (target.Dead || target == null || target.InOpponentQueue) { yield break; }
				CardModificationInfo mod = new CardModificationInfo();
				mod.attackAdjustment = -target.Attack;
				mod.healthAdjustment = 2;
				mod.abilities.Add(DropMana.ability);
				yield return new WaitForSeconds(0.15f);
				int dex;
				dex = target.slot.Index;
				if (GameObject.Find("OpponentSlots").transform.GetChild(dex).childCount > 5)
				{
					GameObject model = GameObject.Find("OpponentSlots").transform.GetChild(dex).GetChild(5).gameObject;
					for (int i = 5; i < model.transform.parent.childCount; i++)
					{
						if (model.transform.parent.GetChild(i).gameObject.GetComponent<Card>() != null)
						{
							model = model.transform.parent.GetChild(i).gameObject;

						}
					}
					target.AddTemporaryMod(mod);
					model.transform.Find("RenderStatsLayer").Find("Quad").gameObject.SetActive(true);
					model.transform.Find("RenderStatsLayer").Find("Quad").GetComponent<MeshRenderer>().material.color = new Color(0.94f, 0.6792f, 0, 0.5f);
				}
				yield break;
			}

			public static Ability ability;
		}


			public class FrostyA : AbilityBehaviour
			{
				public override Ability Ability
				{
					get
					{
						return FrostyA.ability;
					}
				}

				public override bool RespondsToDealDamage(int amount, PlayableCard target)
				{
					return amount > 0 && target != null && !target.Dead && target.Attack > 0;
				}

				public override IEnumerator OnDealDamage(int amount, PlayableCard target)
				{
					yield return new WaitForSeconds(0.15f);
					int debuf = 0;
					foreach (CardModificationInfo mod in target.temporaryMods)
					{
						bool flag4 = mod.singletonId == "frostdebuff";
						if (flag4)
						{
							debuf = mod.attackAdjustment;
						}
					}
					CardModificationInfo cardModificationInfo = new CardModificationInfo();
					cardModificationInfo.attackAdjustment = -1 + debuf;
					cardModificationInfo.singletonId = "frostdebuff";
					target.AddTemporaryMod(cardModificationInfo);
					yield break;
				}

				public static Ability ability;
			}

		public class StrongPull : AbilityBehaviour
		{
			public override Ability Ability
			{
				get
				{
					return StrongPull.ability;
				}
			}

			public static Ability ability;
		}


		public class DropMana : AbilityBehaviour
		{
			public override Ability Ability
			{
				get
				{
					return DropMana.ability;
				}
			}

			public override bool RespondsToOtherCardDie(PlayableCard card, CardSlot deathSlot, bool fromCombat, PlayableCard killer)
			{
				return card == base.Card && fromCombat && base.Card.OnBoard;
			}
			public override IEnumerator OnOtherCardDie(PlayableCard card, CardSlot deathSlot, bool fromCombat, PlayableCard killer)
			{
				yield return base.PreSuccessfulTriggerSequence();
				yield return new WaitForSeconds(0.1f);
				RunState.Run.currency += 2;
				yield return base.LearnAbility(0.5f);
				yield break;
			}

			public static Ability ability;
		}

		public class HPSpell : AbilityBehaviour
		{
			public static Ability ability;
			public override Ability Ability
			{
				get
				{
					return ability;
				}
			}
			public override bool RespondsToResolveOnBoard()
			{
				return true;
			}
			public override IEnumerator OnResolveOnBoard()
			{
				List<CardSlot> list = Singleton<BoardManager>.Instance.GetSlots(base.Card.slot.IsPlayerSlot);
				CardModificationInfo mod = new CardModificationInfo();
				mod.healthAdjustment = 2 + (base.Card.Attack * 2);
				foreach (CardSlot slot in list)
				{
					if (slot.Card != null)
					{
						slot.Card.AddTemporaryMod(mod);
					}
				}
				yield return new WaitForSeconds(0.3f);
				yield return base.Card.Die(false);
				yield break;
			}

		}

		public class ATKSpell : AbilityBehaviour
		{
			public static Ability ability;
			public override Ability Ability
			{
				get
				{
					return ability;
				}
			}
			public override bool RespondsToResolveOnBoard()
			{
				return true;
			}
			public override IEnumerator OnResolveOnBoard()
			{
				List<CardSlot> list = Singleton<BoardManager>.Instance.GetSlots(base.Card.slot.IsPlayerSlot);
				CardModificationInfo mod = new CardModificationInfo();
				mod.attackAdjustment = 1 + base.Card.Attack;
				foreach (CardSlot slot in list)
				{
					if (slot.Card != null)
					{
						slot.Card.AddTemporaryMod(mod);
					}
				}
				yield return new WaitForSeconds(0.3f);
				yield return base.Card.Die(false);
				yield break;
			}

		}

		public class FrostSpell : AbilityBehaviour
		{
			public static Ability ability;
			public override Ability Ability
			{
				get
				{
					return ability;
				}
			}

			public override bool RespondsToResolveOnBoard()
			{
				return true;
			}

			public override IEnumerator OnResolveOnBoard()
			{
				List<CardSlot> list = Singleton<BoardManager>.Instance.GetSlots(!base.Card.slot.IsPlayerSlot);
				string slotName = base.Card.slot.IsPlayerSlot ? "OpponentSlots" : "PlayerSlots";
				foreach (CardSlot slot in list)
				{
					if (slot.Card != null && slot.Card.Info.name != "mag_frostspell")
					{
						int dex;
						dex = slot.Index;
						if (GameObject.Find(slotName).transform.GetChild(dex).childCount > 5)
						{
							GameObject model = GameObject.Find(slotName).transform.GetChild(dex).GetChild(5).gameObject;
							for (int i = 5; i < model.transform.parent.childCount; i++)
							{
								if (model.transform.parent.GetChild(i).gameObject.GetComponent<Card>() != null)
								{
									model = model.transform.parent.GetChild(i).gameObject;

								}
							}
							model.transform.Find("RenderStatsLayer").Find("Quad").gameObject.SetActive(true);
							model.transform.Find("RenderStatsLayer").Find("Quad").GetComponent<MeshRenderer>().material.color = new Color(0.329f, 0.682f, 1f, 0.5f);
						}
						CardModificationInfo mod = new CardModificationInfo();
						mod.attackAdjustment = -slot.Card.Attack;
						if (base.Card.Attack < 1)
						{
							mod.healthAdjustment = 2;
						}
						slot.Card.AddTemporaryMod(mod);
					}
				}
				yield return new WaitForSeconds(0.3f);
				yield return base.Card.Die(false);
				yield break;
			}

		}

		public class GoldSpell : AbilityBehaviour
		{
			public static Ability ability;
			public override Ability Ability
			{
				get
				{
					return ability;
				}
			}

			public override bool RespondsToResolveOnBoard()
			{
				return true;
			}

			public override IEnumerator OnResolveOnBoard()
			{
				List<CardSlot> list = Singleton<BoardManager>.Instance.GetSlots(false);
				foreach (CardSlot slot in list)
				{
					if (slot.Card != null &&  slot.Card.Info.name != "mag_goldspell")
					{
						int dex;
						dex = slot.Index;
						if (GameObject.Find("OpponentSlots").transform.GetChild(dex).childCount > 5)
						{
							GameObject model = GameObject.Find("OpponentSlots").transform.GetChild(dex).GetChild(5).gameObject;
							for (int i = 5; i < model.transform.parent.childCount; i++)
							{
								if (model.transform.parent.GetChild(i).gameObject.GetComponent<Card>() != null)
								{
									model = model.transform.parent.GetChild(i).gameObject;

								}
							}
							model.transform.Find("RenderStatsLayer").Find("Quad").gameObject.SetActive(true);
							model.transform.Find("RenderStatsLayer").Find("Quad").GetComponent<MeshRenderer>().material.color = new Color(1f, 0.85f, 0.3f, 0.5f);
						}
						CardModificationInfo mod = new CardModificationInfo();
						mod.attackAdjustment = -slot.Card.Attack;
						if (base.Card.Attack < 1)
						{
							mod.healthAdjustment = 2;
						}
						mod.abilities = new List<Ability> { SigilCode.DropMana.ability };
						slot.Card.AddTemporaryMod(mod);
					}
				}
				yield return new WaitForSeconds(0.3f);
				yield return base.Card.Die(false);
				yield break;
			}

		}
		public class WindSpell : AbilityBehaviour
		{
			public static Ability ability;
			public override Ability Ability
			{
				get
				{
					return ability;
				}
			}

			public override bool RespondsToResolveOnBoard()
			{
				return true;
			}

			public override IEnumerator OnResolveOnBoard()
			{
				List<CardSlot> list = Singleton<BoardManager>.Instance.GetSlots(true);
				CardModificationInfo mod = new CardModificationInfo();
				mod.abilities.Add(Ability.Flying);
				foreach (CardSlot slot in list)
				{
					if (slot.Card != null)
					{
						slot.Card.AddTemporaryMod(mod);
					}
				}
				yield return new WaitForSeconds(0.3f);
				yield return base.Card.Die(false);
				yield break;
			}

		}

		public class WhirlwindSpell : AbilityBehaviour
		{
			public static Ability ability;
			public override Ability Ability
			{
				get
				{
					return ability;
				}
			}

			public override bool RespondsToResolveOnBoard()
			{
				return true;
			}

			public override IEnumerator OnResolveOnBoard()
			{
					Singleton<ViewManager>.Instance.SwitchToView(View.Board, false, true);
					yield return new WaitForSeconds(0.75f);
					List<CardSlot> playerSlots = Singleton<BoardManager>.Instance.PlayerSlotsCopy;
					for (int i = 0; i < playerSlots.Count; i++)
					{
						if (playerSlots[i].Card != null && !playerSlots[i].Card.Info.HasTrait(Trait.EatsWarrens))
						{
							GameObject cardObj = GameObject.Find("PlayerSlots").transform.GetChild(i).gameObject.GetComponentInChildren<Card>().gameObject;
							Vector3 safePos = cardObj.transform.position;
							if (i > 0)
							{
								cardObj.transform.parent = GameObject.Find("PlayerSlots").transform.GetChild(i - 1);
								GameObject.Find("PlayerSlots").transform.GetChild(i).transform.GetChild(5).transform.parent = GameObject.Find("PlayerSlots").transform.GetChild(i + 1);
								cardObj.transform.position = safePos;
								Tween.LocalPosition(cardObj.transform, new Vector3(0, 1.435f, -0.2076f), 0.5f, 0);
							}
							else if (i == 0)
							{
								cardObj.transform.parent = GameObject.Find("OpponentSlots").transform.GetChild(0);
								GameObject.Find("PlayerSlots").transform.GetChild(i).transform.GetChild(5).transform.parent = GameObject.Find("OpponentSlots").transform.GetChild(0);
								cardObj.transform.position = safePos;
								Tween.LocalPosition(cardObj.transform, new Vector3(0f, 4.435f, -0.9f), 0.5f, 0);
								Tween.LocalRotation(cardObj.transform, new Vector3(61, 0, 0), 0.5f, 0.5f);
							}
						}
					}
					List<CardSlot> opponentSlots = Singleton<BoardManager>.Instance.OpponentSlotsCopy;
					for (int i = 0; i < opponentSlots.Count; i++)
					{
						if (opponentSlots[i].Card != null)
						{
							GameObject cardObj = GameObject.Find("OpponentSlots").transform.GetChild(i).gameObject.GetComponentInChildren<Card>().gameObject;
							Vector3 safePos = cardObj.transform.position;
							if (i < 3)
							{
								cardObj.transform.parent = GameObject.Find("OpponentSlots").transform.GetChild(i + 1);
								GameObject.Find("OpponentSlots").transform.GetChild(i).transform.GetChild(5).transform.parent = GameObject.Find("OpponentSlots").transform.GetChild(i + 1);
								cardObj.transform.position = safePos;
								Tween.LocalPosition(cardObj.transform, new Vector3(0f, 4.435f, -0.9f), 0.5f, 0);
							}
							else if (i == 3)
							{
								cardObj.transform.parent = GameObject.Find("PlayerSlots").transform.GetChild(3);
								GameObject.Find("OpponentSlots").transform.GetChild(i).transform.GetChild(5).transform.parent = GameObject.Find("PlayerSlots").transform.GetChild(3);
								cardObj.transform.position = safePos;
								Tween.LocalPosition(cardObj.transform, new Vector3(0, 1.435f, -0.2076f), 0.5f, 0);
								Tween.LocalRotation(cardObj.transform, new Vector3(71f, 180f, 0), 0.5f, 0.5f);
							}
						}
					}
					yield return Singleton<BoardManager>.Instance.MoveAllCardsClockwise();
					yield return new WaitForSeconds(1f);
					yield return new WaitForSeconds(0.3f);
					yield return base.Card.Die(false);
					yield break;
			}

		}

		public class WaterSpell : AbilityBehaviour
		{
			public static Ability ability;
			public override Ability Ability
			{
				get
				{
					return ability;
				}
			}

			public override bool RespondsToResolveOnBoard()
			{
				return true;
			}

			public override IEnumerator OnResolveOnBoard()
			{
				AudioController.Instance.PlaySound2D("magnificus_brush_splatter_bleach", MixerGroup.None, 0.5f, 0f, null, null, null, null, false);
				List<CardSlot> list = Singleton<BoardManager>.Instance.GetSlots(false);
				foreach (CardSlot slot in list)
				{
					if (slot.Card != null && slot.Card.Info.name != "mag_waterspell")
					{
						int dex;
						dex = slot.Index;
						RemoveCardAbilities(slot.Card);
						if (GameObject.Find("OpponentSlots").transform.GetChild(dex).childCount > 5)
						{
							GameObject model = GameObject.Find("OpponentSlots").transform.GetChild(dex).GetChild(5).gameObject;
							model.transform.Find("RenderStatsLayer").Find("Quad").gameObject.SetActive(true);
							model.transform.Find("RenderStatsLayer").Find("Quad").GetComponent<MeshRenderer>().material.color = new Color(0.72f, 0.8f, 1f, 0.5f);
							model.GetComponent<Card>().RenderCard();
						}
					}
				}
				list = Singleton<BoardManager>.Instance.GetSlots(true);
				foreach (CardSlot slot in list)
				{
					if (slot.Card != null && slot.Card.Info.name != "mag_waterspell")
					{
						int dex;
						dex = slot.Index;
						RemoveCardAbilities(slot.Card);
						if (GameObject.Find("PlayerSlots").transform.GetChild(dex).childCount > 5)
						{
							GameObject model = GameObject.Find("PlayerSlots").transform.GetChild(dex).GetChild(5).gameObject;
							model.transform.Find("RenderStatsLayer").Find("Quad").gameObject.SetActive(true);
							model.transform.Find("RenderStatsLayer").Find("Quad").GetComponent<MeshRenderer>().material.color = new Color(0.72f, 0.8f, 1f, 0.5f);
							model.GetComponent<Card>().RenderCard();
						}
					}
				}
				yield return new WaitForSeconds(0.3f);
				yield return base.Card.Die(false);
				yield break;
			}

			private void RemoveCardAbilities(PlayableCard card)
			{
				CardModificationInfo cardModificationInfo = new CardModificationInfo();
				cardModificationInfo.negateAbilities = new List<Ability>();
				foreach (CardModificationInfo cardModificationInfo2 in card.TemporaryMods)
				{
					cardModificationInfo.negateAbilities.AddRange(cardModificationInfo2.abilities);
				}
				cardModificationInfo.negateAbilities.AddRange(card.Info.Abilities);
				card.AddTemporaryMod(cardModificationInfo);
			}

		}

		public class FlameSpell : AbilityBehaviour
		{
			public static Ability ability;
			public override Ability Ability
			{
				get
				{
					return ability;
				}
			}

			public override bool RespondsToResolveOnBoard()
			{
				return true;
			}

			public override IEnumerator OnResolveOnBoard()
			{
				List<CardSlot> list = Singleton<BoardManager>.Instance.GetSlots(!base.Card.slot.IsPlayerSlot);
				string slotName = base.Card.slot.IsPlayerSlot ? "OpponentSlots" : "PlayerSlots";
				foreach (CardSlot slot in list)
				{
					if (slot.Card != null && slot.Card.Info.name != "mag_flamespell")
					{
						CardModificationInfo mod = new CardModificationInfo();
						if (base.Card.Attack < 1)
						{
							mod.attackAdjustment = 1;
						}
						int dex;
						dex = slot.Index;
						if (GameObject.Find(slotName).transform.GetChild(dex).childCount > 5)
						{
							GameObject model = GameObject.Find(slotName).transform.GetChild(dex).GetChild(5).gameObject;
							for (int i = 5; i < model.transform.parent.childCount; i++)
							{
								if (model.transform.parent.GetChild(i).gameObject.GetComponent<Card>() != null)
								{
									model = model.transform.parent.GetChild(i).gameObject;

								}
							}
							model.transform.Find("RenderStatsLayer").Find("Quad").gameObject.SetActive(true);
							model.transform.Find("RenderStatsLayer").Find("Quad").GetComponent<MeshRenderer>().material.color = new Color(1f, 0.31f, 0f, 0.5f);
						}
						int healthAdj = slot.Card.Health;
						healthAdj -= 1;
						mod.healthAdjustment = -healthAdj;
						slot.Card.AddTemporaryMod(mod);
					}
				}
				yield return new WaitForSeconds(0.3f);
				if (base.Card.Info.HasTrait(Trait.EatsWarrens))
				{
					yield return base.Card.Die(false);
				}
				yield break;
			}

		}

		public class TargetFlame : TargetedSpell
		{
			public override bool TargetAlly
			{
				get
				{
					return true;
				}
			}

			public override bool TargetAll
			{
				get
				{
					return true;
				}
			}
			public override bool ConditionForOnPlayFromHand() => false;
			public override bool ConditionForOnDie(bool wasSacrifice, PlayableCard killer) => false;
			public override bool ConditionForOnSlotTargetedForAttack(CardSlot slot, PlayableCard attacker)
			{
				if (slot != null)
					return slot != null;

				return false;
			}

			public static Ability ability;
			public override Ability Ability
			{
				get
				{
					return ability;
				}
			}

			public override bool RespondsToSlotTargetedForAttack(CardSlot slot, PlayableCard attacker)
			{
				if (slot != null)
				{
					return slot != null;
				}

				return false;
			}



			public override IEnumerator OnSlotTargetedForAttack(CardSlot slot, PlayableCard attacker)
			{
				AudioController.Instance.PlaySound2D("wizard_opponent_summon", MixerGroup.TableObjectsSFX, 1f, 0f, null, null, null, null, false);
				List<CardSlot> list = Singleton<BoardManager>.Instance.GetSlots(slot.IsPlayerSlot);
				string slotName = !slot.IsPlayerSlot ? "OpponentSlots" : "PlayerSlots";
				foreach (CardSlot sloot in list)
				{
					if (sloot.Card != null && sloot.Card.Info.name != "mag_tarflamespell")
					{
						CardModificationInfo mod = new CardModificationInfo();
						if (base.Card.Attack < 1)
						{
							mod.attackAdjustment = 1;
						}
						int dex;
						dex = sloot.Index;
						if (GameObject.Find(slotName).transform.GetChild(dex).childCount > 5)
						{
							GameObject model = GameObject.Find(slotName).transform.GetChild(dex).GetChild(5).gameObject;
							for (int i = 5; i < model.transform.parent.childCount; i++)
							{
								if (model.transform.parent.GetChild(i).gameObject.GetComponent<Card>() != null)
								{
									model = model.transform.parent.GetChild(i).gameObject;

								}
							}
							model.transform.Find("RenderStatsLayer").Find("Quad").gameObject.SetActive(true);
							model.transform.Find("RenderStatsLayer").Find("Quad").GetComponent<MeshRenderer>().material.color = new Color(1f, 0.31f, 0f, 0.5f);
						}
						int healthAdj = sloot.Card.Health;
						healthAdj -= 1;
						mod.healthAdjustment = -healthAdj;
						sloot.Card.AddTemporaryMod(mod);
					}
				}
				yield break;
			}
		}

		public class OneTimeSpell : AbilityBehaviour
		{
			public static Ability ability;
			public override Ability Ability
			{
				get
				{
					return ability;
				}
			}

			public override bool RespondsToTurnEnd(bool playerTurnEnd)
			{
				return base.Card.Attack <= 0;
			}

			public override IEnumerator OnTurnEnd(bool playerTurnEnd)
			{
				yield return new WaitForSeconds(0.5f);
				DeckInfo currentDeck = SaveManager.SaveFile.CurrentDeck;
				CardInfo card = currentDeck.Cards.Find((CardInfo x) => x.name == base.Card.Info.name);
				currentDeck.RemoveCard(card);
				yield return new WaitForSeconds(0.3f);
				yield return base.Card.Die(false, null, true);
				yield break;
			}

			public override bool RespondsToResolveOnBoard()
			{
				return base.Card.Attack > 0 || KayceeStorage.IsKaycee && MagnificusMod.Generation.challenges.Contains("ItemSpells");
			}

			public override IEnumerator OnResolveOnBoard()
			{
				yield return new WaitForSeconds(0.25f);
				DeckInfo currentDeck = SaveManager.SaveFile.CurrentDeck;
				CardInfo card = currentDeck.Cards.Find((CardInfo x) => x.name == base.Card.Info.name);
				currentDeck.RemoveCard(card);
			}

		}

		public class VaseofGreed : AbilityBehaviour
		{
			public static Ability ability;
			public override Ability Ability
			{
				get
				{
					return ability;
				}
			}

			public override bool RespondsToResolveOnBoard()
			{
				return true;
			}

			public override IEnumerator OnResolveOnBoard()
			{
				yield return new WaitForSeconds(0.25f);
				if (this.originalDeckCards == null)
				{
					this.originalDeckCards = Singleton<CardDrawPiles>.Instance.Deck.cards;
				}
				List<PlayableCard> list = Singleton<PlayerHand>.Instance.CardsInHand.FindAll((PlayableCard x) => x != Singleton<PlayerHand>.Instance.ChoosingSlotCard);
				while (list.Count > 0)
				{
					list[0].SetInteractionEnabled(false);
					list[0].Anim.PlayDeathAnimation(true);
					UnityEngine.Object.Destroy(list[0].gameObject, 1f);
					Singleton<PlayerHand>.Instance.RemoveCardFromHand(list[0]);
					list.RemoveAt(0);
				}
				yield return new WaitForSeconds(0.5f);
				for (int i = 0; i < 4 + base.Card.Attack * 2; i++)
				{
					if (Singleton<CardDrawPiles>.Instance.Deck.cards.Count > 0)
					{
						yield return Singleton<CardDrawPiles>.Instance.DrawCardFromDeck(null, null);
					}
				}
				yield return Singleton<CardDrawPiles3D>.Instance.pile.DestroyCards(0.5f);
				Singleton<CardDrawPiles>.Instance.Deck.cards = this.originalDeckCards;
				yield return Singleton<CardDrawPiles3D>.Instance.pile.SpawnCards(this.originalDeckCards.Count, 0.5f);
				yield return base.LearnAbility(0.5f);
				Singleton<ViewManager>.Instance.Controller.LockState = ViewLockState.Unlocked;
				yield return new WaitForSeconds(0.3f);
				yield return base.Card.Die(false, null, true);
			}

			List<CardInfo> originalDeckCards;
		}

		public class GnomeSpell : AbilityBehaviour
		{
			public static Ability ability;
			public override Ability Ability
			{
				get
				{
					return ability;
				}
			}

			public override bool RespondsToResolveOnBoard()
			{
				return true;
			}

			public override IEnumerator OnResolveOnBoard()
			{
				if (base.Card.slot.opposingSlot.Card != null)
				{
					yield return base.Card.slot.opposingSlot.Card.Die(false);
				}
				string cardName = "mag_gnome";
				if (base.Card.Attack > 0)
                {
					cardName = "mag_scubagnome";
                }
				yield return Singleton<BoardManager>.Instance.CreateCardInSlot(CardLoader.GetCardByName(cardName), base.Card.slot.opposingSlot, 0.1f, true);
				yield return base.Card.Die(false, null, true);
			}
		}

		public class Cursed : AbilityBehaviour
		{
			public static Ability ability;
			public override Ability Ability
			{
				get
				{
					return ability;
				}
			}

			public override bool RespondsToResolveOnBoard()
			{
				return true;
			}

			public override IEnumerator OnResolveOnBoard()
			{
				if (base.Card.Attack > 0 && base.Card.slot.opposingSlot.Card == null && base.Card.Info.name == "mag_cursedskull")
                {
					base.Card.SetIsOpponentCard(true);
					CardSlot ogSlot = base.Card.slot;
					yield return Singleton<BoardManager>.Instance.AssignCardToSlot(base.Card, base.Card.slot.opposingSlot, 0.25f, null, true);
					yield return new WaitForSeconds(0.25f);
					ogSlot.Card = null;
				}
				yield return new WaitForSeconds(0.2f);
				yield return base.Card.Die(false, null, true);
			}
		}
		public abstract class TargetedSpell : AbilityBehaviour
		{

			public abstract bool TargetAlly { get; }

			public abstract bool TargetAll { get; }
			public virtual bool ConditionForOnPlayFromHand() => true;
			public virtual bool ConditionForOnDie(bool wasSacrifice, PlayableCard killer) => true;
			public virtual bool ConditionForOnSlotTargetedForAttack(CardSlot slot, PlayableCard attacker) => true;

			public override IEnumerator OnSacrifice()
			{
				yield break;
			}
			public override IEnumerator OnPlayFromHand()
			{
				yield break;
			}
			public override IEnumerator OnDie(bool wasSacrifice, PlayableCard killer)
			{
				yield break;
			}
			public override IEnumerator OnSlotTargetedForAttack(CardSlot slot, PlayableCard attacker)
			{
				yield break;
			}

			public override bool RespondsToSacrifice() => true;
			public override bool RespondsToPlayFromHand() => ConditionForOnPlayFromHand();
			public override bool RespondsToDie(bool wasSacrifice, PlayableCard killer) => ConditionForOnDie(wasSacrifice, killer);
			public override bool RespondsToSlotTargetedForAttack(CardSlot slot, PlayableCard attacker)
			{
				if (ConditionForOnSlotTargetedForAttack(slot, attacker) && slot.Card != null)
					return TargetAlly ? !slot.Card.OpponentCard : slot.Card.OpponentCard;

				return false;
			}
		}

		public class Fireball : TargetedSpell
		{
			public override bool TargetAlly
			{
				get
				{
					return true;
				}
			}

			public override bool TargetAll
			{
				get
				{
					return true;
				}
			}
			public override bool ConditionForOnPlayFromHand() => false;
			public override bool ConditionForOnDie(bool wasSacrifice, PlayableCard killer) => false;
			public override bool ConditionForOnSlotTargetedForAttack(CardSlot slot, PlayableCard attacker)
			{
				if (slot.Card != null)
					return slot.Card != null;

				return false;
			}

			public static Ability ability;
			public override Ability Ability
			{
				get
				{
					return ability;
				}
			}


			public override bool RespondsToSlotTargetedForAttack(CardSlot slot, PlayableCard attacker)
			{
				if (slot.Card != null)
				{
					return slot.Card != null;
				}

				return false;
			}

			public override IEnumerator OnSlotTargetedForAttack(CardSlot slot, PlayableCard attacker)
			{
				if (slot.Card != null)
				{
					AudioController.Instance.PlaySound2D("wizard_opponent_summon", MixerGroup.TableObjectsSFX, 1f, 0f, null, null, null, null, false);
					int overkill = slot.Card.Health < 2 + base.Card.Attack * 2 ? slot.Card.Health - (2 + base.Card.Attack * 2) : 0;


					for (int i = 0; i < (2 + base.Card.Attack * 2) + overkill; i++)
                    {
						if (!slot.Card.Dead)
						{
							yield return slot.Card.TakeDamage(1, null);
						}
                    }
				}
				yield break;
			}
		}

		public class GoranjRage : TargetedSpell
		{
			public override bool TargetAlly
			{
				get
				{
					return true;
				}
			}

			public override bool TargetAll
			{
				get
				{
					return true;
				}
			}
			public override bool ConditionForOnPlayFromHand() => false;
			public override bool ConditionForOnDie(bool wasSacrifice, PlayableCard killer) => false;
			public override bool ConditionForOnSlotTargetedForAttack(CardSlot slot, PlayableCard attacker)
			{
				if (slot.Card != null)
					return slot.Card != null;

				return false;
			}

			public static Ability ability;
			public override Ability Ability
			{
				get
				{
					return ability;
				}
			}

			public override bool RespondsToSlotTargetedForAttack(CardSlot slot, PlayableCard attacker)
			{
				if (slot.Card != null)
				{
					return slot.Card != null;
				}

				return false;
			}



			public override IEnumerator OnSlotTargetedForAttack(CardSlot slot, PlayableCard attacker)
			{
				if (slot.Card != null)
				{
					AudioController.Instance.PlaySound2D("wizard_opponent_summon", MixerGroup.TableObjectsSFX, 1f, 0f, null, null, null, null, false);
					int health = slot.Card.Health;
					yield return slot.Card.Die(false);
					if (base.Card.Attack > 0) { health *= 2; }
					yield return Singleton<MagnificusLifeManager>.Instance.ShowLifeLoss(!slot.IsPlayerSlot, health);
					if (Singleton<MagnificusLifeManager>.Instance.playerLife < 0)
                    {
						Singleton<MagnificusLifeManager>.Instance.playerLife = 0;

					} else if (Singleton<MagnificusLifeManager>.Instance.opponentLife < 0)
					{
						Singleton<MagnificusLifeManager>.Instance.opponentLife = 0;

					}
				}
				yield break;
			}
		}

		public class BleeneCalculus : TargetedSpell
		{
			public override bool TargetAlly
			{
				get
				{
					return true;
				}
			}

			public override bool TargetAll
			{
				get
				{
					return true;
				}
			}
			public override bool ConditionForOnPlayFromHand() => false;
			public override bool ConditionForOnDie(bool wasSacrifice, PlayableCard killer) => false;
			public override bool ConditionForOnSlotTargetedForAttack(CardSlot slot, PlayableCard attacker)
			{
				if (slot.Card != null)
					return slot.Card != null;

				return false;
			}

			public static Ability ability;
			public override Ability Ability
			{
				get
				{
					return ability;
				}
			}

			public override bool RespondsToSlotTargetedForAttack(CardSlot slot, PlayableCard attacker)
			{
				if (slot.Card != null)
				{
					return slot.Card != null;
				}

				return false;
			}



			public override IEnumerator OnSlotTargetedForAttack(CardSlot slot, PlayableCard attacker)
			{
				if (slot.Card != null)
				{
					int attack = slot.Card.Attack;
					int health = slot.Card.Health;
					CardModificationInfo cardModificationInfo = new CardModificationInfo();
					cardModificationInfo.nonCopyable = true;
					cardModificationInfo.singletonId = "zeroout";
					cardModificationInfo.attackAdjustment = -attack;
					cardModificationInfo.healthAdjustment = -health;
					slot.Card.AddTemporaryMod(cardModificationInfo);
					CardModificationInfo mod0 = new CardModificationInfo();
					mod0.nonCopyable = true;
					mod0.singletonId = "statswap";
					mod0.attackAdjustment = attack;
					mod0.healthAdjustment = health;
					slot.Card.AddTemporaryMod(mod0);
					AudioController.Instance.PlaySound2D("wizard_opponent_summon", MixerGroup.TableObjectsSFX, 1f, 0f, null, null, null, null, false);
					//slot.Card.HealDamage(slot.Card.Status.damageTaken);
					mod0.attackAdjustment = health;
					mod0.healthAdjustment = attack;
					slot.Card.OnStatsChanged();
					yield return new WaitForSeconds(0.25f);
					if (slot.Card.Health <= 0)
					{
						if (base.Card.Attack < 1)
						{
							yield return slot.Card.Die(false, null, true);
						} else
                        {
							CardModificationInfo mod2 = new CardModificationInfo();
							mod2.healthAdjustment = 1;
							slot.Card.AddTemporaryMod(mod2);
						}
					}
				}
				yield break;
			}
		}

		public class TargetFrost : TargetedSpell
		{
			public override bool TargetAlly
			{
				get
				{
					return true;
				}
			}

			public override bool TargetAll
			{
				get
				{
					return true;
				}
			}
			public override bool ConditionForOnPlayFromHand() => false;
			public override bool ConditionForOnDie(bool wasSacrifice, PlayableCard killer) => false;
			public override bool ConditionForOnSlotTargetedForAttack(CardSlot slot, PlayableCard attacker)
			{
				if (slot != null)
					return slot != null;

				return false;
			}

			public static Ability ability;
			public override Ability Ability
			{
				get
				{
					return ability;
				}
			}

			public override bool RespondsToSlotTargetedForAttack(CardSlot slot, PlayableCard attacker)
			{
				if (slot != null)
				{
					return slot != null;
				}

				return false;
			}



			public override IEnumerator OnSlotTargetedForAttack(CardSlot slot, PlayableCard attacker)
			{
				AudioController.Instance.PlaySound2D("wizard_opponent_summon", MixerGroup.TableObjectsSFX, 1f, 0f, null, null, null, null, false);
				List<CardSlot> list = Singleton<BoardManager>.Instance.GetSlots(slot.IsPlayerSlot);
				string slotName = !slot.IsPlayerSlot ? "OpponentSlots" : "PlayerSlots";
				foreach (CardSlot sloot in list)
				{
					if (sloot.Card != null && sloot.Card.Info.name != "mag_tarfrostspell")
					{
						int dex;
						dex = sloot.Index;
						if (GameObject.Find(slotName).transform.GetChild(dex).childCount > 5)
						{
							GameObject model = GameObject.Find(slotName).transform.GetChild(dex).GetChild(5).gameObject;
							for (int i = 5; i < model.transform.parent.childCount; i++)
							{
								if (model.transform.parent.GetChild(i).gameObject.GetComponent<Card>() != null)
								{
									model = model.transform.parent.GetChild(i).gameObject;

								}
							}
							model.transform.Find("RenderStatsLayer").Find("Quad").gameObject.SetActive(true);
							model.transform.Find("RenderStatsLayer").Find("Quad").GetComponent<MeshRenderer>().material.color = new Color(0.329f, 0.682f, 1f, 0.5f);
						}
						CardModificationInfo mod = new CardModificationInfo();
						mod.attackAdjustment = -sloot.Card.Attack;
						if (base.Card.Attack < 1)
						{
							mod.healthAdjustment = 2;
						}
						sloot.Card.AddTemporaryMod(mod);
					}
				}
				yield break;
			}
		}

		public class OrluInspiration : TargetedSpell
		{
			public override bool TargetAlly
			{
				get
				{
					return true;
				}
			}

			public override bool TargetAll
			{
				get
				{
					return false;
				}
			}
			public override bool ConditionForOnPlayFromHand() => false;
			public override bool ConditionForOnDie(bool wasSacrifice, PlayableCard killer) => false;
			public override bool ConditionForOnSlotTargetedForAttack(CardSlot slot, PlayableCard attacker)
			{
				if (slot.Card != null)
					return base.Card.OpponentCard== slot.Card.OpponentCard;

				return false;
			}

			public static Ability ability;
			public override Ability Ability
			{
				get
				{
					return ability;
				}
			}


			public override bool RespondsToSlotTargetedForAttack(CardSlot slot, PlayableCard attacker)
			{
				if (slot.Card != null)
				{
					return base.Card.OpponentCard == slot.Card.OpponentCard;
				}

				return false;
			}

			public override IEnumerator OnSlotTargetedForAttack(CardSlot slot, PlayableCard attacker)
			{
				if (slot.Card != null)
                {
					AudioController.Instance.PlaySound2D("wizard_opponent_summon", MixerGroup.TableObjectsSFX, 1f, 0f, null, null, null, null, false);
					CardModificationInfo mod = new CardModificationInfo();
					mod.AddAbilities(SigilCode.OrluHit.ability, Ability.Flying);
					if (base.Card.Attack < 1)
					{
						mod.singletonId = "inspiration";
					}
					slot.Card.AddTemporaryMod(mod);
					string slotName = slot.IsPlayerSlot ? "PlayerSlots" : "OpponentSlots";
					foreach (CardSlot slot2 in Singleton<BoardManager>.Instance.PlayerSlotsCopy)
					{
						if (slot2.Card != null && slot2.Card.Info != base.Card.Info)
						{
							int dex;
							dex = slot.Index;
							GameObject model = GameObject.Find(slotName).transform.GetChild(dex).GetChild(5).gameObject;
							model.GetComponent<Card>().RenderCard();
						}
					}
				}
				yield break;
			}
		}

		public static List<CardSlot> GetAffectedSlots(this CardSlot slot, PlayableCard card)
		{
			if (card.HasAbility(Ability.AllStrike))
				return Singleton<BoardManager>.Instance.AllSlotsCopy.FindAll(s => IsValidTarget(s, card));

			List<CardSlot> retval = new();

			if (card.HasAnyOfAbilities(Ability.SplitStrike, Ability.TriStrike))
			{
				CardSlot leftSlot = Singleton<BoardManager>.Instance.GetAdjacent(slot, true);
				CardSlot rightSlot = Singleton<BoardManager>.Instance.GetAdjacent(slot, false);

				if (leftSlot != null)
					retval.Add(leftSlot);

				if (rightSlot != null)
					retval.Add(rightSlot);

				if (card.HasAbility(Ability.TriStrike))
					retval.Add(slot);
			}
			else
			{
				retval.Add(slot);
			}

			retval.Sort((CardSlot a, CardSlot b) => a.Index - b.Index);
			return retval;
		}
		public static bool IsValidTarget(this CardSlot slot, PlayableCard card, bool checkSingleSlot = false)
		{
			if (checkSingleSlot)
			{
				if (card.TriggerHandler.RespondsToTrigger(Trigger.ResolveOnBoard, Array.Empty<object>()))
					return true;

				if (card.TriggerHandler.RespondsToTrigger(Trigger.SlotTargetedForAttack, new object[] { slot, card }))
					return true;

				return false;
			}
			else
			{
				// We need to test all possible slots
				return GetAffectedSlots(slot, card).Exists(subSlot => IsValidTarget(subSlot, card, true));
			}
		}
		public static bool HasValidTarget(this PlayableCard card)
		{
			List<CardSlot> allSlots = Singleton<BoardManager>.Instance.AllSlotsCopy;
			foreach (CardSlot slot in allSlots)
			{
				if (IsValidTarget(slot, card)) { 
					return true; // There is at least one slot that responds to this trigger, so leave the result as-is
				}
			}

			// If we got this far without finding a slot that the card responds to, then...no good
			return false;
		}

		[HarmonyPatch(typeof(PlayableCard), "CanPlay")]
		public class TargetSpellsMustHaveValidTarget
		{
			public static void Postfix(ref bool __result, ref PlayableCard __instance)
			{
				
				if (__instance.Info.HasTrait(Trait.EatsWarrens) && __instance.Info.name == "mag_potion")
                {
					int boardCards = 0;
					foreach(CardSlot card in Singleton<BoardManager>.Instance.PlayerSlotsCopy)
                    {
						if (card.Card != null) { boardCards ++; }
                    }
					if (boardCards > 0)
					{
						__result = true;
					} else
                    {
						__result = false;
                    }
					return;
                }
				if (!__result) // Don't do anything if the result's already false
					return;
				if (__instance.Info.GetExtendedPropertyAsBool("TargetedSpell") == true && !HasValidTarget(__instance))
					__result = false;
			}
		}
		[HarmonyPatch(typeof(PlayerHand), "SelectSlotForCard")]
		public class SpellsResolveDifferently
		{
			public static IEnumerator Postfix(IEnumerator sequenceResult, PlayableCard card)
			{
				if (card != null && card.Info.GetExtendedPropertyAsBool("TargetedSpell") == null)
				{
					while (sequenceResult.MoveNext())
						yield return sequenceResult.Current;

					yield break;
				}

				// The rest of this comes from the original code in PlayerHand.SelectSlotForCard
				Singleton<PlayerHand>.Instance.CardsInHand.ForEach(delegate (PlayableCard x)
				{
					x.SetEnabled(enabled: false);
				});
				yield return new WaitWhile(() => Singleton<PlayerHand>.Instance.ChoosingSlot);

				Singleton<PlayerHand>.Instance.OnSelectSlotStartedForCard(card);

				if (Singleton<RuleBookController>.Instance != null)
					Singleton<RuleBookController>.Instance.SetShown(shown: false);

				Singleton<BoardManager>.Instance.CancelledSacrifice = false;

				Singleton<PlayerHand>.Instance.choosingSlotCard = card;

				if (card != null && card.Anim != null)
					card.Anim.SetSelectedToPlay(selected: true);

				Singleton<BoardManager>.Instance.ShowCardNearBoard(card, showNearBoard: true);

				if (Singleton<TurnManager>.Instance.SpecialSequencer != null)
					yield return Singleton<TurnManager>.Instance.SpecialSequencer.CardSelectedFromHand(card);

				bool cardWasPlayed = false;
				bool requiresSacrifices = card.Info.BloodCost > 0;
				if (requiresSacrifices)
				{
					List<CardSlot> validSlots = Singleton<BoardManager>.Instance.PlayerSlotsCopy.FindAll((CardSlot x) => x.Card != null);
					yield return Singleton<BoardManager>.Instance.ChooseSacrificesForCard(validSlots, card);
				}

				// All card slots
				List<CardSlot> allSlots = Singleton<BoardManager>.Instance.AllSlotsCopy;
				Vector3 playerPos = GameObject.Find("Player").transform.position;
				if (card.Info.GetExtendedPropertyAsBool("TargetAllSpell") != null)
				{
					Singleton<ViewController>.Instance.LockState = ViewLockState.Locked;
					int zOffset = RunState.Run.regionTier == 4 ? 7 : 0;
					Tween.Position(GameObject.Find("Player").transform, new Vector3(GameObject.Find("Player").transform.position.x, GameObject.Find("Player").transform.position.y + 3, playerPos.z + 7f + zOffset), 0.25f, 0f);
					Generation.SetBigOpponentSlotHitboxes(true, GameObject.Find("BoardManager"), true);
				}
				if (!Singleton<BoardManager>.Instance.CancelledSacrifice)
				{
					IEnumerator chooseSlotEnumerator = Singleton<BoardManager>.Instance.ChooseSlot(allSlots, !requiresSacrifices);
					chooseSlotEnumerator.MoveNext();

					// Mark which slots can be targeted before letting the code continue
					foreach (CardSlot slot in allSlots)
					{
						bool isValidTarget;
						if (card.Info.GetExtendedPropertyAsBool("TargetedSpell") == true)
							isValidTarget = IsValidTarget(slot, card);
						else
							isValidTarget = true;

						slot.SetEnabled(isValidTarget);
						slot.ShowState(isValidTarget ? HighlightedInteractable.State.Interactable : HighlightedInteractable.State.NonInteractable);
						slot.Chooseable = isValidTarget;
					}
					yield return chooseSlotEnumerator.Current;

					// Run through the rest of the code to determine what slot has been targeted
					while (chooseSlotEnumerator.MoveNext())
						yield return chooseSlotEnumerator.Current;

					if (!Singleton<BoardManager>.Instance.cancelledPlacementWithInput)
					{
						cardWasPlayed = true;
						card.Anim.SetSelectedToPlay(false);
						// Now we take care of actually playing the card
						if (Singleton<PlayerHand>.Instance.CardsInHand.Contains(card))
						{
							if (card.Info.BonesCost > 0)
								yield return Singleton<ResourcesManager>.Instance.SpendBones(card.Info.BonesCost);

							if (card.EnergyCost > 0)
								yield return Singleton<ResourcesManager>.Instance.SpendEnergy(card.EnergyCost);

							Singleton<PlayerHand>.Instance.RemoveCardFromHand(card);

							// PlayFromHand
							if (card.TriggerHandler.RespondsToTrigger(Trigger.PlayFromHand, Array.Empty<object>()))
								yield return card.TriggerHandler.OnTrigger(Trigger.PlayFromHand, Array.Empty<object>());

							// ResolveOnBoard - recreates full behaviour
							if (card.TriggerHandler.RespondsToTrigger(Trigger.ResolveOnBoard, Array.Empty<object>()))
							{
								List<CardSlot> resolveSlots;
								if (card.Info.GetExtendedPropertyAsBool("TargetedSpell") == true)
									resolveSlots = GetAffectedSlots(Singleton<BoardManager>.Instance.LastSelectedSlot, card);
								else
									resolveSlots = new List<CardSlot>() { null }; // For global spells, just resolve once, globally

								foreach (CardSlot slot in resolveSlots)
								{
									card.Slot = slot;

									IEnumerator resolveTrigger = card.TriggerHandler.OnTrigger(Trigger.ResolveOnBoard, Array.Empty<object>());
									for (bool active = true; active;)
									{
										try // Catch exceptions only on executing/resuming the iterator function
										{
											active = resolveTrigger.MoveNext();
										}
										catch (Exception ex)
										{
											Debug.Log("IteratorFunction() threw exception: " + ex);
										}

										if (active) // Yielding and other loop logic is moved outside of the try-catch
											yield return resolveTrigger.Current;
									}

									card.Slot = null;
								}
							}

							// SlotTargetedForAttack (targeted spells only)
							if (card.Info.GetExtendedPropertyAsBool("TargetedSpell") == true)
							{
								foreach (CardSlot targetSlot in GetAffectedSlots(Singleton<BoardManager>.Instance.LastSelectedSlot, card))
								{
									object[] targetArgs = new object[] { targetSlot, card };
									yield return card.TriggerHandler.OnTrigger(Trigger.SlotTargetedForAttack, targetArgs);
								}
							}

							card.Dead = true;
							card.Anim.PlayDeathAnimation(false);

							// Die
							object[] diedArgs = new object[] { true, null };
							if (card.TriggerHandler.RespondsToTrigger(Trigger.Die, diedArgs))
								yield return card.TriggerHandler.OnTrigger(Trigger.Die, diedArgs);

							yield return new WaitUntil(() => Singleton<GlobalTriggerHandler>.Instance.StackSize == 0);

							if (Singleton<TurnManager>.Instance.IsPlayerTurn)
								Singleton<BoardManager>.Instance.playerCardsPlayedThisRound.Add(card.Info);

							Singleton<InteractionCursor>.Instance.ClearForcedCursorType();
							if (card.Info.GetExtendedPropertyAsBool("TargetAllSpell") != null)
							{
								Tween.Position(GameObject.Find("Player").transform, playerPos, 0.2f, 0f);
								Singleton<ViewManager>.Instance.SwitchToView(View.Default, false, false);
								Singleton<ViewController>.Instance.LockState = ViewLockState.Unlocked;
								Generation.SetBigOpponentSlotHitboxes(false, GameObject.Find("BoardManager"), true);
							}
							yield return new WaitForSeconds(0.6f);
							GameObject.Destroy(card.gameObject, 0.5f);
							Singleton<ViewManager>.Instance.SwitchToView(View.Default);
						}
					} 
				}
				if (card.Info.GetExtendedPropertyAsBool("TargetAllSpell") != null)
				{
					Tween.Position(GameObject.Find("Player").transform, playerPos, 0.2f, 0f);
					Singleton<ViewManager>.Instance.SwitchToView(View.Default, false, false);
					Generation.SetBigOpponentSlotHitboxes(false, GameObject.Find("BoardManager"), true);
				}
				if (!cardWasPlayed)
				{
					Singleton<BoardManager>.Instance.ShowCardNearBoard(card, false);
					Singleton<ViewController>.Instance.LockState = ViewLockState.Unlocked;
				} else
                {
					Plugin.spellsPlayed++;
				}

				Singleton<PlayerHand>.Instance.choosingSlotCard = null;

				if (card != null && card.Anim != null)
					card.Anim.SetSelectedToPlay(false);

				Singleton<PlayerHand>.Instance.CardsInHand.ForEach(delegate (PlayableCard x)
				{
					x.SetEnabled(true);
				});

				// Enable every slot
				foreach (CardSlot slot in allSlots)
				{
					slot.SetEnabled(true);
					slot.ShowState(HighlightedInteractable.State.Interactable);
					slot.Chooseable = false;
				}
				

				yield break;
			}
		}

		public class AddCardToDeck : AbilityBehaviour
		{
			public static Ability ability;
			public override Ability Ability
			{
				get
				{
					return ability;
				}
			}
			public override bool RespondsToDrawn()
			{
				return !base.Card.Info.IsOfTribe(Tribe.Hooved);
			}
			public override IEnumerator OnDrawn()
			{
				this.originalDeckCards = Singleton<CardDrawPiles>.Instance.Deck.cards;
				yield return new WaitForSeconds(0.1f);
				int rand = Random.RandomRangeInt(0, originalDeckCards.Count);
				CardInfo info = Instantiate(base.Card.Info);
				foreach(CardModificationInfo mod in base.Card.Info.mods)
                {
					info.mods.Add(mod);
                }
				info.AddTribes(Tribe.Hooved);
				Singleton<CardDrawPiles>.Instance.Deck.cards.Insert(rand, info);
				this.originalDeckCards = Singleton<CardDrawPiles>.Instance.Deck.cards;
				yield return Singleton<CardDrawPiles3D>.Instance.pile.DestroyCards(0.5f);
				yield return Singleton<CardDrawPiles3D>.Instance.pile.SpawnCards(this.originalDeckCards.Count, 0.5f);
				Singleton<ViewManager>.Instance.Controller.LockState = ViewLockState.Unlocked;
				yield return new WaitForSeconds(0.8f);
				yield break;
			}

			List<CardInfo> originalDeckCards;
		}

		public class MagGainGemTriple : AbilityBehaviour
		{
			public static Ability ability;
			public override Ability Ability
			{
				get
				{
					return ability;
				}
			}

			public override bool RespondsToResolveOnBoard()
			{
				return true;
			}

			public override IEnumerator OnResolveOnBoard()
			{
				if (!base.Card.OpponentCard)
				{
					yield return Singleton<ResourcesManager>.Instance.AddGem(GemType.Green);
					yield return Singleton<ResourcesManager>.Instance.AddGem(GemType.Orange);
					yield return Singleton<ResourcesManager>.Instance.AddGem(GemType.Blue);
				}
				yield break;
			}

			public override bool RespondsToDie(bool wasSacrifice, PlayableCard killer)
			{
				return true;
			}

			public override IEnumerator OnDie(bool wasSacrifice, PlayableCard killer)
			{
				if (!base.Card.OpponentCard)
				{
					yield return Singleton<ResourcesManager>.Instance.LoseGem(GemType.Green);
					yield return Singleton<ResourcesManager>.Instance.LoseGem(GemType.Orange);
					yield return Singleton<ResourcesManager>.Instance.LoseGem(GemType.Blue);
				}
				yield break;
			}
		}
	}
}
