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
    class SpecialAbilities
    {
		public class ManaCost : SpecialCardBehaviour
		{
			public override bool RespondsToDrawn()
			{
				return !SavedVars.LearnedMechanics.Contains("mana;");
			}

			public override IEnumerator OnDrawn()
			{
				(Singleton<PlayerHand>.Instance as PlayerHand3D).MoveCardAboveHand(base.PlayableCard);
				Singleton<ViewManager>.Instance.SwitchToView(View.Default);
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Ah.. It appears you have drawn a card with a [c:g3]special cost[c:].", -1.5f, 0f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("These cards require [c:g1]mana shards[c:] to play..", -1.5f, 0f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("[c:g1]Mana shards[c:] are gained from 'Sacrificing' mox cards..", -3.5f, 0f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput(".. So, when played you will need to destroy " + base.Card.Info.BloodCost + " mox.", -3.5f, 0f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("It's all quite simple..", -1.5f, 0f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
				yield return new WaitForSeconds(0.4f);
				SavedVars.LearnedMechanics += "mana;";
				yield break;
			}
		}

		public class Lesbiane : SpecialCardBehaviour
		{
			public override bool RespondsToResolveOnBoard()
			{
				return true;
			}

			public override IEnumerator OnResolveOnBoard()
			{
				List<CardSlot> slots = Singleton<BoardManager>.Instance.PlayerSlotsCopy;
				for (int i = 0; i < slots.Count; i++)
				{
					if (slots[i].Card != null)
					{
						if (slots[i].Card.Info.name == "mag_teamage" && base.PlayableCard.Info.name == "mag_coffeemage" || slots[i].Card.Info.name == "mag_coffeemage" && base.PlayableCard.Info.name == "mag_teamage")
						{
							string partnerWhere = "idk";
							if (slots[i].Index == 0 && slots[1].Card == null)
							{
								yield return Singleton<BoardManager>.Instance.AssignCardToSlot(base.PlayableCard, slots[1], 0.11f, null, true);
								partnerWhere = "left";
								yield return new WaitForSeconds(0.2f);
							}
							else if (slots[i].Index == 0 && slots[1].Card != null)
							{
								CardSlot baseSlot = base.PlayableCard.slot;
								yield return Singleton<BoardManager>.Instance.AssignCardToSlot(base.PlayableCard, slots[1], 0.11f, null, true);
								yield return Singleton<BoardManager>.Instance.AssignCardToSlot(slots[1].Card, baseSlot, 0.11f, null, true);
								partnerWhere = "left";
							}

							if (slots[i].Index == 3 && slots[2].Card == null)
							{
								partnerWhere = "right";
								yield return Singleton<BoardManager>.Instance.AssignCardToSlot(base.PlayableCard, slots[2], 0.11f, null, true);
								yield return new WaitForSeconds(0.2f);
							}
							else if (slots[i].Index == 3 && slots[2].Card != null)
							{
								partnerWhere = "right";
								CardSlot baseSlot = base.PlayableCard.slot;
								yield return Singleton<BoardManager>.Instance.AssignCardToSlot(slots[2].Card, baseSlot, 0.11f, null, true);
								yield return Singleton<BoardManager>.Instance.AssignCardToSlot(base.PlayableCard, slots[2], 0.11f, null, true);
								yield return new WaitForSeconds(0.2f);
							}

							if (slots[i].Index != 3 && slots[i].Index != 0)
							{
								int dex = slots[i].Index;
								if (slots[dex - 1].Card != null && slots[dex + 1].Card == null)
								{
									partnerWhere = "left";
									yield return Singleton<BoardManager>.Instance.AssignCardToSlot(base.PlayableCard, slots[dex + 1], 0.11f, null, true);
								}
								else if (slots[dex - 1].Card == null && slots[dex + 1].Card != null)
								{
									partnerWhere = "right";
									yield return Singleton<BoardManager>.Instance.AssignCardToSlot(base.PlayableCard, slots[dex - 1], 0.11f, null, true);
								}
								else if (slots[dex - 1].Card != null && slots[dex + 1].Card != null)
								{
									partnerWhere = "right";
									CardSlot baseSlot = base.PlayableCard.slot;
									yield return Singleton<BoardManager>.Instance.AssignCardToSlot(slots[dex - 1].Card, baseSlot, 0.11f, null, true);
									yield return Singleton<BoardManager>.Instance.AssignCardToSlot(base.PlayableCard, slots[dex - 1], 0.11f, null, true);
									yield return new WaitForSeconds(0.2f);
								}

							}

							if (base.PlayableCard.Info.name == "mag_coffeemage" && partnerWhere == "left")
							{
								base.PlayableCard.renderInfo.flippedPortrait = true;
								slots[base.PlayableCard.slot.Index - 1].Card.renderInfo.flippedPortrait = true;
							}
							else if (base.PlayableCard.Info.name == "mag_teamage" && partnerWhere == "right")
							{
								base.PlayableCard.renderInfo.flippedPortrait = true;
								slots[base.PlayableCard.slot.Index + 1].Card.renderInfo.flippedPortrait = true;
							}
						}
					}
				}
				yield break;
			}
		}



		public class OuroRandomize : SpecialCardBehaviour
		{
			public override bool RespondsToDrawn()
			{
				return true;
			}
			public override IEnumerator OnDrawn()
			{
				AddMod();
				yield break;
			}

			private void AddMod()
			{
				List<GemType> baseCosts = new List<GemType> { GemType.Green, GemType.Orange, GemType.Blue };
				CardModificationInfo mod = new CardModificationInfo();
				List<GemType> newGem = new List<GemType>();
				mod.nullifyGemsCost = true;
				GemType rand = baseCosts[Random.RandomRangeInt(0, baseCosts.Count)];
				switch (rand)
				{
					case GemType.Blue:
						newGem = new List<GemType> { GemType.Orange };
						base.PlayableCard.renderInfo.portraitOverride = Tools.getPortraitSprite("mag_oroborous1.png");
						break;
					case GemType.Orange:
						newGem = new List<GemType> { GemType.Green };
						base.PlayableCard.renderInfo.portraitOverride = Tools.getPortraitSprite("mag_oroborous.png");
						break;
					case GemType.Green:
						newGem = new List<GemType> { GemType.Blue };
						base.PlayableCard.renderInfo.portraitOverride = Tools.getPortraitSprite("mag_oroborous2.png");
						break;
				}
				mod.addGemCost = newGem;

				List<CardModificationInfo> whoToKill = new List<CardModificationInfo>();

				foreach (CardModificationInfo modinfo in base.PlayableCard.Info.mods)
				{
					if (modinfo.nullifyGemsCost)
					{
						whoToKill.Add(modinfo);
					}
				}

				foreach (CardModificationInfo modinfo in whoToKill)
				{
					base.PlayableCard.Info.mods.Remove(modinfo);
				}

				base.PlayableCard.Info.mods.Add(mod);
				base.PlayableCard.RenderCard();
			}
		}

		public class Potion : SpecialCardBehaviour
		{
			public void Awake()
			{
				if (base.Card.Info.mods.Count > 0)
				{
					Sprite portraitOverride;
					switch (base.Card.Info.mods[0].decalIds[0])
					{
						default:
							portraitOverride = Tools.getSprite("potion_green.png");
							break;
						case "mana":
							portraitOverride = Tools.getSprite("potion_mana.png");
							break;
						case "blue":
							portraitOverride = Tools.getSprite("potion_blue.png");
							break;
						case "orange":
							portraitOverride = Tools.getSprite("potion_orange.png");
							break;
					}
					base.Card.renderInfo.portraitOverride = portraitOverride;
					base.Card.RenderCard();
				}
			}

			public override bool RespondsToSlotTargetedForAttack(CardSlot slot, PlayableCard attacker)
			{
				if (slot.Card != null)
				{
					return slot.Card != null && slot.IsPlayerSlot;
				}

				return false;
			}

			public override IEnumerator OnSlotTargetedForAttack(CardSlot slot, PlayableCard attacker)
			{
				if (slot.Card != null)
				{
					AudioController.Instance.PlaySound2D("wizard_opponent_summon", MixerGroup.TableObjectsSFX, 1f, 0f, null, null, null, null, false);
					CardModificationInfo tempMod = new CardModificationInfo();
					tempMod.abilities.AddRange(base.PlayableCard.Info.Abilities);
					tempMod.attackAdjustment = base.Card.Info.Attack;
					tempMod.healthAdjustment = base.Card.Info.Health;
					slot.Card.AddTemporaryMod(tempMod);
					if (!slot.Card.Dead)
					{
						slot.Card.RenderCard();
						int dex;
						dex = slot.Index;
						string slotName = slot.IsPlayerSlot ? "PlayerSlots" : "OpponentSlots";
						if (GameObject.Find(slotName).transform.GetChild(dex).childCount > 5)
						{
							GameObject model = GameObject.Find(slotName).transform.GetChild(dex).GetChild(5).gameObject;
							model.GetComponent<Card>().RenderCard();
						}
					}
				}
				yield break;
			}
		}

		public class MagDeathCard : SpecialCardBehaviour
		{
			public void Awake()
			{
				if (base.Card.Info.mods.Count > 0)
				{
					GameObject headTex = GameObject.Instantiate(new GameObject());
					headTex.name = "head";
					headTex.transform.parent = base.Card.gameObject.transform;
					headTex.transform.localPosition = new Vector3(0f, -0.01f, 0.2f);
					headTex.transform.localScale = new Vector3(0.75f, 0.85f, 1f);
					headTex.transform.localRotation = Quaternion.Euler(0, 0, 0);

					if (base.Card.gameObject.transform.GetChild(0).gameObject.name == "DustParticles")
					{
						headTex.transform.parent = base.Card.gameObject.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(0).GetChild(0);
						headTex.transform.localRotation = Quaternion.Euler(270, 180, 0);
						headTex.transform.localPosition = new Vector3(0f, -0.01f, 0.2f);
					}
					else if (base.Card.gameObject.GetComponent<WizardBattle3DPortrait>() == null)
					{
						headTex.transform.parent = base.Card.gameObject.transform.GetChild(0).GetChild(0);
						headTex.transform.localRotation = Quaternion.Euler(0, 180, 0);
						headTex.transform.localPosition = new Vector3(0f, 0.1f, -0.01f);
					}
					else
					{
						headTex.transform.localRotation = Quaternion.Euler(0, 180, 0);
						headTex.transform.localPosition = new Vector3(0, 0.2f, -0.01f);
					}
					headTex.AddComponent<SpriteRenderer>().sprite = Tools.getSprite("deathcardhead" + base.Card.Info.mods[0].buildACardPortraitInfo.spriteIndices[0] + ".png");

					GameObject bodyTex = GameObject.Instantiate(headTex);
					bodyTex.name = "body";
					bodyTex.transform.parent = headTex.transform.parent;
					bodyTex.transform.localScale = headTex.transform.localScale;
					bodyTex.transform.localRotation = headTex.transform.localRotation;
					if (base.Card.gameObject.transform.GetChild(0).gameObject.name == "DustParticles")
					{
						bodyTex.transform.localPosition = new Vector3(0f, -0.01f, 0.1575f);
					}
					else if (base.Card.gameObject.GetComponent<WizardBattle3DPortrait>() == null)
					{
						bodyTex.transform.localPosition = new Vector3(0, 0.085f, -0.001f);
					}
					else
					{
						bodyTex.transform.localPosition = new Vector3(0f, 0.16f, -0.001f);
					}

					bodyTex.GetComponent<SpriteRenderer>().sprite = Tools.getSprite("deathcardbody" + base.Card.Info.mods[0].buildACardPortraitInfo.spriteIndices[1] + ".png");
				}
			}

		}

		public class CustomPortraited : SpecialCardBehaviour
		{
			public void Awake()
			{
				GameObject paintSplotch = Instantiate(new GameObject());
				paintSplotch.AddComponent<SpriteRenderer>().sprite = Tools.getSprite("paint.png");
				paintSplotch.name = "paintSplotch";
				List<Color> random = new List<Color> { new Color(1, 0.5f, 0, 1), new Color(0, 0.5f, 1, 1), new Color(0, 1, 0.1f, 1) };
				List<GemType> gemTypes = new List<GemType> { GemType.Orange, GemType.Blue, GemType.Green };

				paintSplotch.GetComponent<SpriteRenderer>().color = random[gemTypes.IndexOf(base.Card.Info.mods[0].addGemCost[0])];
				paintSplotch.transform.position = new Vector3(0, 0, 0);
				paintSplotch.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
				GameObject splotches = Instantiate(new GameObject());
				splotches.name = "splotches";
				splotches.transform.parent = base.Card.gameObject.transform;
				splotches.transform.localPosition = new Vector3(0, -0.25f, 0f);

				if (base.Card.gameObject.transform.GetChild(0).gameObject.name == "DustParticles")
				{
					splotches.transform.parent = base.Card.gameObject.transform.GetChild(1).GetChild(0);
				}
				else if (base.Card.gameObject.GetComponent<WizardBattle3DPortrait>() == null)
				{
					splotches.transform.parent = base.Card.gameObject.transform.GetChild(0).GetChild(0);
				}
				else
				{
					splotches.transform.localRotation = Quaternion.Euler(270, 0, 0);
					splotches.transform.localPosition = new Vector3(0f, -0.25f, -0.01f);
				}
				Sprite smallSplotch = Tools.getSprite("smallpaint.png");

				for (int i = 0; i < base.Card.Info.mods[0].decalIds.Count; i++)
				{
					string[] splotchData = base.Card.Info.mods[0].decalIds[i].Split(',');
					if (splotchData.Length == 5)
					{
						string[] newSplotchData = new string[4];
						newSplotchData[0] = splotchData[0];
						newSplotchData[1] = Convert.ToString(float.Parse(splotchData[1]) + (float.Parse(splotchData[2]) / 100f));
						if (splotchData[1][0] == '-') { newSplotchData[1] = Convert.ToString(-float.Parse(newSplotchData[1])); }
						newSplotchData[2] = splotchData[3];
						newSplotchData[3] = splotchData[4];
						int yDecimalIdx = 2;
						if (float.Parse(newSplotchData[1]) > 8)
						{
							newSplotchData[0] = Convert.ToString(float.Parse(splotchData[0]) + (float.Parse(splotchData[1]) / 100f));
							newSplotchData[1] = splotchData[2];
							yDecimalIdx = 1;
						}
						if (splotchData[yDecimalIdx].Length < 2)
						{
							string newDecimal = splotchData[yDecimalIdx] + '0';
							if (yDecimalIdx == 2) { newSplotchData[1] = Convert.ToString(float.Parse(splotchData[1]) + (float.Parse(newDecimal) / 100f)); }
							else { Convert.ToString(float.Parse(splotchData[0]) + (float.Parse(newDecimal) / 100f)); }
						}
						splotchData = newSplotchData;
					}
					else if (splotchData.Length == 6)
					{
						string[] newSplotchData = new string[4];
						newSplotchData[0] = Convert.ToString(float.Parse(splotchData[0]) + (float.Parse(splotchData[1]) / 100f));
						if (splotchData[0][0] == '-') { newSplotchData[0] = Convert.ToString(-float.Parse(newSplotchData[0])); }
						newSplotchData[1] = Convert.ToString(float.Parse(splotchData[2]) + (float.Parse(splotchData[3]) / 100f));
						if (splotchData[2][0] == '-') { newSplotchData[1] = Convert.ToString(-float.Parse(newSplotchData[1])); }
						newSplotchData[2] = splotchData[4];
						newSplotchData[3] = splotchData[5];
						if (splotchData[3].Length < 2)
						{
							string newDecimal = splotchData[3] + '0';
							newSplotchData[1] = Convert.ToString(float.Parse(splotchData[2]) + (float.Parse(newDecimal) / 100f));
						}
						splotchData = newSplotchData;
					}
					paintSplotch.transform.localScale = new Vector3(Convert.ToInt32(splotchData[2]) * 0.1f, Convert.ToInt32(splotchData[2]) * 0.1f, Convert.ToInt32(splotchData[2]) * 0.1f);
					if (Convert.ToInt32(splotchData[2]) > 2)
					{
						paintSplotch.transform.localScale = new Vector3(2 * 0.1f, 2 * 0.1f, 2 * 0.1f);
					}
					GameObject splotch = Instantiate(paintSplotch);

					splotch.name = "splotch";
					if (Convert.ToInt32(splotchData[2]) < 2)
					{
						splotch.GetComponent<SpriteRenderer>().sprite = smallSplotch;
					}
					switch (splotchData[3])
					{
						case "0":
							splotch.GetComponent<SpriteRenderer>().color = random[gemTypes.IndexOf(base.Card.Info.mods[0].addGemCost[0])];
							break;
						case "1":
							splotch.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1);
							break;
						case "2":
							splotch.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
							break;
					}
					splotch.transform.parent = splotches.transform;
					splotch.transform.localRotation = Quaternion.Euler(90, 0, UnityEngine.Random.RandomRangeInt(0, 180));
					splotch.transform.localPosition = new Vector3(float.Parse(splotchData[0]), 0.01f + (0.01f * Convert.ToInt32(splotchData[3])), (float.Parse(splotchData[1]) - 6.1f));
				}
				splotches.transform.localPosition = new Vector3(0, -0.25f, -0.01f);
			}
		}
	}
}
