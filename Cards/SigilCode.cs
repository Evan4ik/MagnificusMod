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
				string result = "MoxRuby";
				switch (text2)
				{
					case "green":
						{
							result = "MoxEmerald";
							break;
						}
					case "red":
						{
							result = "MoxRuby";
							break;
						}
					case "blue":
						{
							result = "MoxSapphire";
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
				if (base.Card.HasAbility(SigilCode.MagDropSapphireOnDeath.ability) && base.Card.HasAbility(SigilCode.MagDropEmeraldOnDeath.ability))
				{
					yield return Singleton<BoardManager>.Instance.CreateCardInSlot(CardLoader.GetCardByName("mag_prismaticshards"), base.Card.Slot, 0.1f, true);
					yield break;
				}
				if (base.Card.HasAbility(SigilCode.MagDropEmeraldOnDeath.ability))
                {
					yield return Singleton<BoardManager>.Instance.CreateCardInSlot(CardLoader.GetCardByName("MoxDualGO"), base.Card.Slot, 0.1f, true);
					yield break;
				}
				if (base.Card.HasAbility(SigilCode.MagDropSapphireOnDeath.ability))
				{
					yield return Singleton<BoardManager>.Instance.CreateCardInSlot(CardLoader.GetCardByName("MoxDualOB"), base.Card.Slot, 0.1f, true);
					yield break;
				}
				yield return Singleton<BoardManager>.Instance.CreateCardInSlot(CardLoader.GetCardByName("MoxRuby"), base.Card.Slot, 0.1f, true);
				yield return base.LearnAbility(0.5f);
				yield break;
			}

			public static Ability ability;
		}

		public class MagDropSapphireOnDeath : AbilityBehaviour
		{
			public override Ability Ability
			{
				get
				{
					return MagDropSapphireOnDeath.ability;
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
					yield return Singleton<BoardManager>.Instance.CreateCardInSlot(CardLoader.GetCardByName("MoxDualBG"), base.Card.Slot, 0.1f, true);
					yield break;
				}
				yield return Singleton<BoardManager>.Instance.CreateCardInSlot(CardLoader.GetCardByName("MoxSapphire"), base.Card.Slot, 0.1f, true);
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
				yield return Singleton<BoardManager>.Instance.CreateCardInSlot(CardLoader.GetCardByName("MoxEmerald"), base.Card.Slot, 0.1f, true);
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
					base.Card.Anim.StrongNegationEffect();
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
				base.Card.Anim.StrongNegationEffect();
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

		public class BoneMarrow : AbilityBehaviour
		{
			public override Ability Ability
			{
				get
				{
					return BoneMarrow.ability;
				}
			}

			public override bool RespondsToOtherCardDie(PlayableCard card, CardSlot deathSlot, bool fromCombat, PlayableCard killer)
			{
				return base.Card.OnBoard && deathSlot.Card != null && deathSlot.Card.OpponentCard == base.Card.OpponentCard && deathSlot.Card != base.Card && !card.HasTrait(Trait.Gem) && !card.HasTrait(Trait.EatsWarrens);
			}

			public override IEnumerator OnOtherCardDie(PlayableCard card, CardSlot deathSlot, bool fromCombat, PlayableCard killer)
			{
				int attack = 0;
				foreach (CardModificationInfo mod in base.Card.temporaryMods)
				{
					if (mod.singletonId == "marrow")
					{
						attack = mod.attackAdjustment;
					}
				}
				if (base.Card.Attack < base.Card.Info.baseAttack + 5)
				{
					base.Card.Anim.StrongNegationEffect();
					CardModificationInfo cardModificationInfo = new CardModificationInfo();
					cardModificationInfo.nonCopyable = false;
					cardModificationInfo.attackAdjustment = 1 + attack;
					cardModificationInfo.healthAdjustment = 0;
					cardModificationInfo.singletonId = "marrow";
					base.Card.AddTemporaryMod(cardModificationInfo);
					cardModificationInfo = null;
				}
				yield break;
			}

			public static Ability ability;

			private List<CardInfo> currentlyResurrectingCards = new List<CardInfo>();
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
				return base.Card.OnBoard && deathSlot.Card != null && deathSlot.Card.OpponentCard == base.Card.OpponentCard && deathSlot.Card != base.Card && !card.HasTrait(Trait.Gem) && !this.currentlyResurrectingCards.Contains(deathSlot.Card.Info) && deathSlot.Card == card;
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
				if (Singleton<CardDrawPiles>.Instance.Deck.cards.Count > 0)
				{
						yield return Singleton<CardDrawPiles>.Instance.DrawCardFromDeck(null, null);
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
				if (source != null && source.Attack > 0)
				{
					int debuf = 0;
					foreach (CardModificationInfo mod in source.temporaryMods)
					{
						if (mod.singletonId == "goodebuff")
						{
							debuf = mod.attackAdjustment;
						}
					}
					CardModificationInfo cardModificationInfo = new CardModificationInfo();
					cardModificationInfo.attackAdjustment = -1 + debuf;
					cardModificationInfo.singletonId = "goodebuff";
					source.AddTemporaryMod(cardModificationInfo);

					GameObject model = GameObject.Find(source.slot.IsPlayerSlot ? "PlayerSlots" : "OpponentSlots").transform.GetChild(source.slot.Index).GetChild(5).gameObject;

					GameObject gooDecal = GameObject.Instantiate(model.transform.Find("RenderStatsLayer").Find("Quad").gameObject);
					gooDecal.transform.parent = model.transform.Find("RenderStatsLayer");
					gooDecal.name = "gooDecal";
					gooDecal.GetComponent<MeshRenderer>().material.mainTexture = Resources.Load("art/cards/decals/decal_paint_" + (Random.RandomRangeInt(1, 3))) as Texture2D;
					gooDecal.transform.localPosition = new Vector3(0, 0, -0.001f);
					gooDecal.transform.localRotation = Quaternion.Euler(0, 0, 0);
					gooDecal.transform.localScale = new Vector3(1.075f, 1.045f, 1);
					gooDecal.SetActive(true);

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
					component10.Initialize(CardLoader.GetCardByName("JuniorSage"));
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

			public string lastMox = "MoxRuby";
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
					string moxToDrop = "MoxEmerald";
					switch(lastMox)
                    {
						case "MoxRuby":
							moxToDrop = "MoxEmerald";
							break;
						case "MoxEmerald":
							moxToDrop = "MoxSapphire";
							break;
						case "MoxSapphire":
							moxToDrop = "MoxRuby";
							break;
					}
					lastMox = moxToDrop;
					yield return Singleton<BoardManager>.Instance.CreateCardInSlot(CardLoader.GetCardByName(moxToDrop), cardSlot, 0.1f, true);
				}
				yield break;
			}
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
				MoxPowerBypass = AbilityManager.New(Plugin.PluginGuid, "Mox Power", "The value represented with this sigil will be equal to the number of Mox Cards that the owner has on their side of the table.", typeof(SigilCode.HealthForAnts), Tools.getImage("mox empowered.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.getImage("mox empowered.png"));
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

				info.iconGraphic = Tools.getImage("mox empowered.png");
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
				if (!Singleton<TurnManager>.Instance.GameIsOver() && !(Singleton<TurnManager>.Instance.Opponent.Queue.Exists((PlayableCard x) => x != null && x.Info.HasTrait(Trait.Gem)) && Singleton<TurnManager>.Instance.Opponent.Queue.Exists((PlayableCard x) => x != null && x == base.PlayableCard)) && num < 1 && base.PlayableCard.Health <= 0 || (base.PlayableCard.Health <= 0 && base.PlayableCard.MaxHealth > 0))
				{
					if (!base.PlayableCard.Dead) Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(base.PlayableCard.Die(false));
				} else
                {
					base.PlayableCard.renderInfo.healthTextColor = new Color(0f, 0.4844f, 0.6415f, 1f);
                }
				
				return array;
			}

			public static StatIconManager.FullStatIcon InitStatIconAndAbility()
			{


				AbilityInfo MoxHealthBypass = AbilityManager.New(Plugin.PluginGuid, "Mox Power", "The value represented with this sigil will be equal to the number of Mox Cards that the owner has on their side of the table.", typeof(SigilCode.MoxHp), Tools.getImage("mox empowered.png"))
					.SetDefaultPart1Ability()
					.SetIcon(Tools.getImage("mox empowered.png"));
				MoxHp.ability = MoxHealthBypass;

				StatIconInfo info = ScriptableObject.CreateInstance<StatIconInfo>();
				info.appliesToAttack = false;
				info.appliesToHealth = true;
				info.rulebookName = "Mox Health";
				info.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.MagnificusRulebook };
				info.rulebookDescription =
					"The value represented with this sigil will be equal to the number of Mox Cards that the owner has on their side of the table.";
				info.gbcDescription = SigilCode.HealthForAnts.MoxPowerBypass.ability.ToString();

				info.iconGraphic = Tools.getImage("mox empowered.png");
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

				info.iconGraphic = Tools.getImage("candle proximity.png");

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

				info.iconGraphic = Tools.getImage("bone_stat_icon.png");

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
				List<CardSlot> list = !base.PlayableCard.Slot.IsPlayerSlot ? Singleton<BoardManager>.Instance.PlayerSlotsCopy : Singleton<BoardManager>.Instance.OpponentSlotsCopy;
				int num = 0;
				foreach (CardSlot cardSlot in list)
				{
					if (cardSlot.Card != null && cardSlot.Card != base.Card && cardSlot.Card.Info.specialAbilities != base.Card.Info.specialAbilities)
					{
						num += cardSlot.Card.Attack;
					}
				}
				int[] array = new int[2];
				array[0] = num;
				return array;
			}

			public static StatIconManager.FullStatIcon InitStatIconAndAbility()
			{
				AbilityInfo KillSquide = AbilityManager.New(Plugin.PluginGuid, "Murder Power", "The value represented with this sigil will be equal the total amount of power on the opponents board.", typeof(SigilCode.KillSquid), Tools.getImage("killsquid_icon.png"))
					.SetDefaultPart1Ability()
					.SetIcon(Tools.getImage("killsquid_icon.png"));
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

				info.iconGraphic = Tools.getImage("killsquid_icon.png");

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
				array[0] = Convert.ToInt32( MagnificusMod.Plugin.spellsPlayed * 1.5f );
				return array;
			}

			public static StatIconManager.FullStatIcon InitStatIconAndAbility()
			{
				AbilityInfo SpellPowere = AbilityManager.New(Plugin.PluginGuid, "Spell Power", "The value represented with this sigil will be equal to total amount of spells played during this battle, times 1.5 .", typeof(SigilCode.SpellPower), Tools.getImage("spellpower.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.getImage("spellpower.png"));
				SpellPowere.powerLevel = 10;
				SpellPower.ability = SpellPowere;
				StatIconInfo info = ScriptableObject.CreateInstance<StatIconInfo>();
				info.appliesToAttack = true;
				info.appliesToHealth = false;
				info.rulebookName = "Spell Power";
				info.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.Part1Rulebook };
				info.rulebookDescription =
					"The value represented with this sigil will be equal to total amount of spells played during the battle.";
				info.gbcDescription = SpellPowere.ability.ToString();

				info.iconGraphic = Tools.getImage("spellpower.png");

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
				int hp = base.PlayableCard.slot.IsPlayerSlot ? Singleton<MagnificusLifeManager>.Instance.playerLife : Singleton<MagnificusLifeManager>.Instance.opponentLife;
				float damage = 10 - hp;
				if (KayceeStorage.IsKaycee && MagnificusMod.Generation.challenges.Contains("FadingMox") && base.PlayableCard.slot.IsPlayerSlot)
				{
					damage = KayceeStorage.FleetingLife - hp;
				}
				array[0] = Convert.ToInt32(Math.Floor(damage / 2));
				return array;
			}

			public static StatIconManager.FullStatIcon InitStatIconAndAbility()
			{
				AbilityInfo BPowere = AbilityManager.New(Plugin.PluginGuid, "Counterbattery Power", "The value represented with this sigil will be equal to the amount of damage taken by you this battle, divided by two.", typeof(SigilCode.CounterBatteryPower), Tools.getImage("spellpower.png"))
				.SetDefaultPart1Ability()
				.SetIcon(Tools.getImage("batterypower.png"));
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

				info.iconGraphic = Tools.getImage("batterypower.png");

				FullStatIcon = StatIconManager.Add(Plugin.PluginGuid, info, typeof(CounterBatteryPower));
				FullSpecial = SpecialTriggeredAbilityManager.Add(Plugin.PluginGuid, info.rulebookName, typeof(CounterBatteryPower));
				
				return FullStatIcon;
			}

			private static SpecialStatIcon specialStatIcon;
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
				return base.Card.OnBoard && deathSlot.Card != null && !card.HasTrait(Trait.Gem) && deathSlot.Card.OpponentCard == base.Card.OpponentCard && deathSlot.Card != base.Card && !this.currentlyResurrectingCards.Contains(deathSlot.Card.Info) && deathSlot.Card == card && !(card.HasAbility(Ability.GemDependant) && !HasGems(false)) && !card.HasTrait(Trait.EatsWarrens);
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
				List<int> attackRange = new List<int> { 0, 1, 2, 3 };
				bool alreadyMod = false;
				int negative = 0 - base.Card.Attack;
				int selectedAttack = 0;
				foreach (CardModificationInfo mod in base.Card.temporaryMods)
                {
					if (mod.singletonId is null) { continue; }
					if (mod.singletonId.Contains("randompower"))
                    {
						alreadyMod = true;
						negative = 0 - base.Card.Attack;
						selectedAttack = attackRange[Random.RandomRangeInt(0, attackRange.Count)];
						negative += selectedAttack;
						mod.attackAdjustment = negative;
					}
                }

				if (alreadyMod) { yield break; }

				selectedAttack = attackRange[Random.RandomRangeInt(0, attackRange.Count)];
				negative += selectedAttack;
				CardModificationInfo cardModificationInfo = new CardModificationInfo();
				cardModificationInfo.nonCopyable = true;
				cardModificationInfo.singletonId = "randompower";
				cardModificationInfo.attackAdjustment = negative;
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
					return "";
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
				mod.healthAdjustment = 1;
				foreach (CardSlot slot in list)
				{
					if (slot.Card != null && slot.Card.Info.HasTrait(Trait.Gem)) slot.Card.AddTemporaryMod(mod);
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
				mod.healthAdjustment = 1;
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
					if (slot.Card != null && slot.Card.Info.HasTrait(Trait.Gem)) slot.Card.AddTemporaryMod(mod);
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
				int health = numGems;
				foreach (CardSlot slot in list)
				{
					if (slot.Card != null)
					{
						if (slot.Card.Info.HasTrait(Trait.Gem))
						{
							if (slot.Card.Health > 1)
								health += slot.Card.Health - 1;

							if (slot.Card.Info.name.Contains("MoxDual"))
								attack++;
							else if (slot.Card.Info.name == "mag_prismaticshards")
								attack += 2;


							yield return slot.Card.Die(false, null, true);
						}
					}
				}
				if (numGems > 0)
				{
					CardModificationInfo cardModificationInfo = new CardModificationInfo();
					cardModificationInfo.nonCopyable = true;
					cardModificationInfo.singletonId = "zeroout";
					cardModificationInfo.attackAdjustment = attack;
					cardModificationInfo.healthAdjustment = health;
					base.Card.AddTemporaryMod(cardModificationInfo);
					yield break;
				}
				yield return base.LearnAbility(0f);
				yield break;
			}

			public static Ability ability;
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
				CardInfo cardByName = CardLoader.GetCardByName(KRAKENITES[Random.Range(0, KRAKENITES.Length)]);
				CardModificationInfo abilityMod = new CardModificationInfo();
				abilityMod.abilities.AddRange(base.Card.AllAbilities());

				cardByName.mods.Add(abilityMod);

				base.Card.SetInfo(cardByName);
			}

			public static Ability ability;

			private static readonly string[] KRAKENITES = new string[]
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

					List<CardModificationInfo> mods = base.Card.slot.opposingSlot.Card.Info.Mods;
					mods.AddRange(base.Card.slot.opposingSlot.Card.temporaryMods);

					foreach (CardModificationInfo mod in mods)
					{
						base.Card.AddTemporaryMod(mod);
					}
					base.Card.Anim.PlayTransformAnimation();

					Singleton<ResourcesManager>.Instance.ForceGemsUpdate();
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
				return !base.Card.HasTrait(Trait.EatsWarrens);
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

					if (info.specialAbilities.Contains(Plugin.OuroChange))
						info.specialAbilities.Remove(Plugin.OuroChange);

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

				
				foreach (CardSlot slot in slots )
				{
					if (slot.Card != null && slot.Card.Info.HasTrait(Trait.Gem))
					{
						List<string> cardNames = new List<string> { "MoxSapphire", "MoxRuby", "MoxEmerald" };

						if ( slot.Card.Info.name.Contains("moxrabbit")) { cardNames = new List<string> { "mag_moxrabbit", "mag_orangemoxrabbit", "mag_greenmoxrabbit" }; }
						else if (slot.Card.Info.name.Contains("MoxDual")) { cardNames = new List<string> { "MoxDualOB", "MoxDualGO", "MoxDualBG" }; }
						else if (slot.Card.Info.name.Contains("mag_moxmage")) { cardNames = new List<string> { "mag_moxmage_sapphire", "mag_moxmage", "mag_moxmage_emerald" }; }
						else if (slot.Card.Info.name.Contains("mag_crystalworm")) { cardNames = new List<string> { "mag_crystalworm_blue", "mag_crystalworm_orange", "mag_crystalworm_green" }; }

						slot.Card.SetCardback(Tools.getImage("magcardback.png"));

						slot.Card.Anim.SetFaceDown(true);
						CardInfo info = slot.Card.Info;

						switch (slot.Card.Info.abilities[0])
						{
							case Ability.GainGemGreen:
								info = CardLoader.GetCardByName(cardNames[0]);
								break;
							case Ability.GainGemBlue:
								info = CardLoader.GetCardByName(cardNames[1]);
								break;
							case Ability.GainGemOrange:
								info = CardLoader.GetCardByName(cardNames[2]);
								break;
						}


						slot.Card.SetInfo(info);
						yield return new WaitForSeconds(0.25f);
						slot.Card.Anim.SetFaceDown(false);

						Singleton<ResourcesManager>.Instance.ForceGemsUpdate();
					}
				}
				yield break;
			}


			public static Ability ability;
		}

		public class MoxSelect : AbilityBehaviour
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
				List<CardInfo> possible = new List<CardInfo> { CardLoader.GetCardByName("mag_crystalworm_orange"), CardLoader.GetCardByName("mag_crystalworm_green"), CardLoader.GetCardByName("mag_crystalworm_blue") };

				CardInfo selectedCard = null;

				if (base.Card.slot.IsPlayerSlot)
				{

					Deck instanceDeck = new Deck();
					instanceDeck.cards = possible;

					yield return instanceDeck.ChooseCard(delegate (CardInfo c)
					{
						selectedCard = c;
					});

					Singleton<ViewManager>.Instance.SwitchToView(View.Default);
				} else
                {
					selectedCard = possible[SeededRandom.Range(0, possible.Count, SaveManager.saveFile.randomSeed)];

				}

				base.Card.SetCardback(Tools.getImage("magcardback.png"));

				base.Card.Anim.SetFaceDown(true);

				yield return new WaitForSeconds(0.05f);
				Singleton<ViewManager>.Instance.Controller.LockState = ViewLockState.Unlocked;
				if (base.Card.Info.name == "mag_crystalworm") base.Card.SetInfo(selectedCard);
				else
                {
					CardModificationInfo gemMod = new CardModificationInfo();
					gemMod.abilities = selectedCard.abilities;
					base.Card.AddTemporaryMod(gemMod);

				}
				yield return new WaitForSeconds(0.2f);

				Singleton<ResourcesManager>.Instance.ForceGemsUpdate();
				base.Card.Anim.SetFaceDown(false);


				Singleton<CardDrawPiles3D>.Instance.pile.DestroyCardsImmediate();
				yield return Singleton<CardDrawPiles3D>.Instance.pile.SpawnCards(Singleton<CardDrawPiles>.Instance.Deck.cards.Count, 0.05f);

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

		public class AstralProjection : TailOnHit
		{
			public static Ability ability;

			public override Ability Ability => ability;
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
						if (mod.singletonId == "frostdebuff")
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
				List<GameObject> summonedWeights = new List<GameObject>();
				yield return new WaitForSeconds(0.5f);
				List<GameObject> manaTypes = new List<GameObject> { GameObject.Find("mana"), GameObject.Find("mana1"), GameObject.Find("mana2") };
				GameObject slotPosition = GameObject.Find("OpponentSlots").transform.GetChild(deathSlot.Index).gameObject;
				for (int i = 0; i < 2; i++)
				{
					GameObject weightLol = GameObject.Instantiate(manaTypes[UnityEngine.Random.RandomRangeInt(0, manaTypes.Count)]);
					summonedWeights.Add(weightLol);
					weightLol.transform.parent = GameObject.Find("GameTable").transform;
					weightLol.transform.localScale = new Vector3(1.65f, 1.65f, 1.65f);
					weightLol.transform.position = slotPosition.transform.position + new Vector3(UnityEngine.Random.Range(-0.15f, 0.15f), 0.25f +  UnityEngine.Random.Range(1.50f, 1.70f), UnityEngine.Random.Range(-0.15f, 0.15f));
					weightLol.AddComponent<BoxCollider>();
					weightLol.GetComponent<BoxCollider>().size = new Vector3(0.3f, 0.3f, 0.3f);
					weightLol.AddComponent<Rigidbody>().mass = 0.25f;
					AudioController.Instance.PlaySound3D("metal_drop", MixerGroup.TableObjectsSFX, weightLol.transform.position, 1f, 0f, new AudioParams.Pitch(0.7f), null, new AudioParams.Randomization(true), null, false);
					yield return new WaitForSeconds(0.1f);
				}
				yield return new WaitForSeconds(0.55f);
				while(summonedWeights.Count > 0)
                {
					GameObject.DestroyImmediate(summonedWeights[0]);
					summonedWeights.RemoveAt(0);
				}
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
				yield break;
			}

		}

		public class Frozen : AbilityBehaviour
		{
			public static Ability ability;
			public override Ability Ability
			{
				get
				{
					return ability;
				}
			}

			public override bool RespondsToTakeDamage(PlayableCard source)
			{
				if (source != null)
				{
					return source.Health > 0 && base.Card.Health > 0;
				}
				return false;
			}

			public override IEnumerator OnTakeDamage(PlayableCard source)
			{
				string slotName = base.Card.OpponentCard ? "OpponentSlots" : "PlayerSlots";
				for (int i = 0; i < base.Card.temporaryMods.Count; i++)
				{
					if (base.Card.temporaryMods[i].singletonId != null && base.Card.temporaryMods[i].singletonId.Contains("frost"))
					{
						base.Card.temporaryMods[i].abilities = new List<Ability>();
						base.Card.temporaryMods[i].attackAdjustment = 0;
						base.Card.temporaryMods[i].healthAdjustment = 0;
						base.Card.temporaryMods[i].singletonId = "none";
						if (GameObject.Find(slotName).transform.GetChild(base.Card.slot.Index).childCount > 5)
						{
							GameObject model = GameObject.Find(slotName).transform.GetChild(base.Card.slot.Index).GetChild(5).gameObject;
							model.GetComponent<Card>().RenderCard();
							base.Card.RenderCard();
						}
					}
				}
				yield break;
			}

			public override bool RespondsToTurnEnd(bool playerTurnEnd)
			{
				return base.Card.OpponentCard == playerTurnEnd;
			}

			public override IEnumerator OnTurnEnd(bool playerTurnEnd)
			{
				string slotName = base.Card.OpponentCard ? "OpponentSlots" : "PlayerSlots";
				for (int i = 0; i < base.Card.temporaryMods.Count; i++)
				{
					if (base.Card.temporaryMods[i].singletonId != null && base.Card.temporaryMods[i].singletonId.Contains("frost"))
					{
						if (base.Card.temporaryMods[i].healthAdjustment <= 0)
						{
							base.Card.temporaryMods[i].abilities = new List<Ability>();
							base.Card.temporaryMods[i].attackAdjustment = 0;
							base.Card.temporaryMods[i].singletonId = "none";
							if (GameObject.Find(slotName).transform.GetChild(base.Card.slot.Index).childCount > 5)
							{
								GameObject model = GameObject.Find(slotName).transform.GetChild(base.Card.slot.Index).GetChild(5).gameObject;
								model.transform.Find("RenderStatsLayer").Find("Quad").gameObject.SetActive(false);
								model.transform.Find("RenderStatsLayer").Find("Quad").GetComponent<MeshRenderer>().material.color = new Color(0.329f, 0.682f, 1f, 0f);
								model.GetComponent<Card>().RenderCard();
								base.Card.RenderCard();
							}
						} else { base.Card.temporaryMods[i].healthAdjustment -= 1; }
					}
				}
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
					if (slot.Card != null && slot.Card.Info.name != "mag_frostspell" && slot.Card.Info.abilities.Count < 4)
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
						mod.singletonId = "frost";
						mod.abilities.Add(SigilCode.Frozen.ability);
						mod.attackAdjustment = -slot.Card.Attack;
						mod.healthAdjustment = 2;
						slot.Card.AddTemporaryMod(mod);
					}
				}
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
				yield return new WaitForSeconds(0.15f);

				List<List<GameObject>> cards = new List<List<GameObject>> { new List<GameObject>(), new List<GameObject>() };

				foreach(CardSlot slot in Singleton<BoardManager>.Instance.PlayerSlotsCopy)
                {
					if (slot.Card == null || slot.Card.Info.HasTrait(Trait.EatsWarrens) && slot.Card.Info.GetExtendedPropertyAsBool("PhysicalSpell") == null || slot.Card.Info == Card.Info) { cards[0].Add(null); continue; }
					GameObject WizardCardBoy = GameObject.Find("PlayerSlots").transform.GetChild(slot.Index).GetChild(5).gameObject;
					cards[0].Add(WizardCardBoy);
				}

				foreach (CardSlot slot in Singleton<BoardManager>.Instance.OpponentSlotsCopy)
				{
					if (slot.Card == null || slot.Card.Info.HasTrait(Trait.EatsWarrens) && slot.Card.Info.GetExtendedPropertyAsBool("PhysicalSpell") == null || slot.Card.Info == Card.Info) { cards[1].Add(null); continue; }
					GameObject WizardCardBoy = GameObject.Find("OpponentSlots").transform.GetChild(slot.Index).GetChild(5).gameObject;
					cards[1].Add(WizardCardBoy);
				}

				List<CardSlot> playerSlots = Singleton<BoardManager>.Instance.PlayerSlotsCopy;
				for (int i = 0; i < cards[0].Count; i++)
				{
					if (cards[0][i] == null) {continue; }

					GameObject cardObj = cards[0][i];
					Vector3 safePos = cardObj.transform.position;
					
					if (i > 0)
					{
						cardObj.transform.parent = GameObject.Find("PlayerSlots").transform.GetChild(i - 1);
						GameObject.Find("PlayerSlots").transform.GetChild(i).transform.GetChild(5).transform.parent = GameObject.Find("PlayerSlots").transform.GetChild(i - 1);
						cardObj.transform.position = safePos;
						Tween.LocalPosition(cardObj.transform, new Vector3(0, 1.435f, -0.2076f), 0.45f, 0);
					}
					else if (i == 0)
					{
						cardObj.transform.parent = GameObject.Find("OpponentSlots").transform.GetChild(0);
						GameObject.Find("PlayerSlots").transform.GetChild(i).transform.GetChild(5).transform.parent = GameObject.Find("OpponentSlots").transform.GetChild(0);
						cardObj.transform.position = safePos;
						Tween.LocalPosition(cardObj.transform, new Vector3(0f, 4.435f, -0.9f), 0.45f, 0);
						Tween.LocalRotation(cardObj.transform, new Vector3(61, 0, 0), 0.45f, 0.5f);
					}
				}
				List<CardSlot> opponentSlots = Singleton<BoardManager>.Instance.OpponentSlotsCopy;
				for (int i = 0; i < cards[1].Count; i++)
				{
					if (cards[1][i] == null) { continue; }

					GameObject cardObj = cards[1][i];
					Vector3 safePos = cardObj.transform.position;
					if (i < 3)
					{
						cardObj.transform.parent = GameObject.Find("OpponentSlots").transform.GetChild(i + 1);
						GameObject.Find("OpponentSlots").transform.GetChild(i).transform.GetChild(5).transform.parent = GameObject.Find("OpponentSlots").transform.GetChild(i + 1);
						cardObj.transform.position = safePos;
						Tween.LocalPosition(cardObj.transform, new Vector3(0f, 4.435f, -0.9f), 0.45f, 0);
					}
					else if (i == 3)
					{
						cardObj.transform.parent = GameObject.Find("PlayerSlots").transform.GetChild(3);
						GameObject.Find("OpponentSlots").transform.GetChild(i).transform.GetChild(5).transform.parent = GameObject.Find("PlayerSlots").transform.GetChild(3);
						cardObj.transform.position = safePos;
						Tween.LocalPosition(cardObj.transform, new Vector3(0, 1.435f, -0.2076f), 0.45f, 0);
						Tween.LocalRotation(cardObj.transform, new Vector3(71f, 180f, 0), 0.45f, 0.25f);
					}
				}
				yield return Singleton<BoardManager>.Instance.MoveAllCardsClockwise();
				Singleton<ResourcesManager>.Instance.ForceGemsUpdate();
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

		public class Flame : AbilityBehaviour
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
						mod.attackAdjustment = 1;
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
						mod.attackAdjustment = 1;
						mod.healthAdjustment = -2;
						int predict = base.Card.Health - 2;
						if (predict <= 0)
						{
							mod.healthAdjustment = (base.Card.Health * -1) + 1;

						}
						slot.Card.AddTemporaryMod(mod);
					}
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
				return true;
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
				return true;
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
						int hp = -2;
						int predict = base.Card.Health - 2;
						if (predict <= 0)
						{
							hp = (base.Card.Health * -1) + 1;

						}
						CardModificationInfo mod = new CardModificationInfo(1, hp);
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
				DeckInfo currentDeck = RunState.Run.playerDeck;
				CardInfo card = currentDeck.Cards.Find((CardInfo x) => x.name == base.Card.Info.name);
				currentDeck.RemoveCard(card);
				yield return new WaitForSeconds(0.3f);
				yield return base.Card.Die(false, null, true);
				yield break;
			}

			public override bool RespondsToResolveOnBoard()
			{
				return base.Card.Attack > 0;
			}

			public override IEnumerator OnResolveOnBoard()
			{
				yield return new WaitForSeconds(0.25f);
				DeckInfo currentDeck = RunState.Run.playerDeck;
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

		public class GnomeSpell : TargetedSpell
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
				if (slot.Card == null)
					return slot.Card == null;

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
				if (slot.Card == null)
				{
					return slot.Card == null;
				}

				return false;
			}

			public override IEnumerator OnSlotTargetedForAttack(CardSlot slot, PlayableCard attacker)
			{
				if (slot.Card != null)
					yield break;
				string cardName = (base.Card.Attack <= 0) ? "mag_gnome" : "mag_scubagnome";
				yield return Singleton<BoardManager>.Instance.CreateCardInSlot(CardLoader.GetCardByName(cardName), slot, 0.1f, true);
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
						if (slot.Card.Attack <= 1)
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
				CardModificationInfo negateMod = new CardModificationInfo();
				negateMod.negateAbilities.Add(SigilCode.AddCardToDeck.ability);
				info.mods.Add(negateMod);
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

		public class DiscardCards : AbilityBehaviour
		{
			public static Ability ability;
			public override Ability Ability
			{
				get
				{
					return ability;
				}
			}
			public override bool RespondsToUpkeep(bool playerUpkeep)
			{
				return base.Card != null && base.Card.OpponentCard == playerUpkeep && !base.Card.Dead && !this.HasGems() && Singleton<PlayerHand>.Instance.cardsInHand.Count > 0;
			}

			public override IEnumerator OnUpkeep(bool playerUpkeep)
			{
				PlayableCard discardCard = Singleton<PlayerHand>.Instance.cardsInHand[0];
				discardCard.Anim.PlayDeathAnimation();
				base.Card.Anim.PlaySacrificeParticles();
				base.Card.Anim.StrongNegationEffect();
				Singleton<PlayerHand>.Instance.cardsInHand.RemoveAt(0);
				yield return new WaitForSeconds(0.5f);
				GameObject.Destroy(discardCard.gameObject);
				yield break;
			}

			private bool HasGems()
			{
				return (base.Card.OpponentCard ? Singleton<BoardManager>.Instance.OpponentSlotsCopy : Singleton<BoardManager>.Instance.PlayerSlotsCopy).Exists((CardSlot x) => x.Card != null && x.Card.Info.HasTrait(Trait.Gem));
			}

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
