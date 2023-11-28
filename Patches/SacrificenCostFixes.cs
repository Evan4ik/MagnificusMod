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
	public class SacrificeAndCostFixes
	{
		[HarmonyPatch(typeof(PlayableCard), "CanPlay")]
		public class fixSacrificesHeHe
		{
			public static bool Prefix(ref PlayableCard __instance, ref bool __result)
			{
				if (SceneLoader.ActiveSceneName != "finale_magnificus")
				{
					return true;
				}
				bool manaCheck = __instance.Info.GetExtendedPropertyAsBool("ManaCost") == true;
				bool bloodCheck = !manaCheck && __instance.Info.BloodCost <= MagGetValueOfSacrifices(Singleton<BoardManager>.Instance.playerSlots.FindAll((CardSlot x) => x.Card != null && !x.Card.HasTrait(Trait.Gem) && MagCanBeSacrificed(x.Card, false)), false) || manaCheck && __instance.Info.BloodCost <= MagGetValueOfSacrifices(Singleton<BoardManager>.Instance.playerSlots.FindAll((CardSlot x) => x.Card != null && x.Card.HasTrait(Trait.Gem) && MagCanBeSacrificed(x.Card, true)), true);
				__result = __instance.Info.BloodCost <= Singleton<BoardManager>.Instance.AvailableSacrificeValue && __instance.Info.BonesCost <= Singleton<ResourcesManager>.Instance.PlayerBones && __instance.EnergyCost <= Singleton<ResourcesManager>.Instance.PlayerEnergy && __instance.GemsCostRequirementMet() && Singleton<BoardManager>.Instance.SacrificesCreateRoomForCard(__instance, Singleton<BoardManager>.Instance.PlayerSlotsCopy);
				return false;
			}
		}


		public static bool MagCanBeSacrificed(PlayableCard instance, bool isMana)
		{
			if (SceneLoader.ActiveSceneName != "finale_magnificus")
            {
				return !instance.FaceDown && (instance.Info.Sacrificable || instance.HasAbility(Ability.TripleBlood));
			}
			bool isManaHeart = false;
			if (SaveManager.saveFile.ascensionActive && MagnificusMod.Generation.challenges.Contains("AllMana"))
			{
				isManaHeart = true;
			}
			int boardCards = 0;
			int boardRequirement = 1;
			bool targetedSpell = Singleton<PlayerHand>.Instance.ChoosingSlotCard != null ? Singleton<PlayerHand>.Instance.ChoosingSlotCard.Info.GetExtendedPropertyAsBool("TargetedSpell") == true : false;
			if (targetedSpell)
			{
				boardRequirement = Singleton<PlayerHand>.Instance.ChoosingSlotCard.Info.BloodCost;
				foreach (CardSlot slot in Singleton<BoardManager>.Instance.PlayerSlotsCopy)
				{
					if (slot.Card != null)
					{
						boardCards++;
					}
				}
				if (Singleton<PlayerHand>.Instance.ChoosingSlotCard.Info.GetExtendedPropertyAsBool("TargetAllSpell") != null)
				{
					foreach (CardSlot slot in Singleton<BoardManager>.Instance.OpponentSlotsCopy)
					{
						if (slot.Card != null)
						{
							boardCards++;
						}
					}
				}
			}
			bool checkIfTargetedSpell = targetedSpell && boardCards > boardRequirement;
			if (!isMana)
			{
				return !instance.FaceDown && !instance.Info.HasTrait(Trait.Gem) && instance.Info.Sacrificable;
			}
			else
			{
				return !instance.FaceDown && instance.Info.HasTrait(Trait.Gem) && !targetedSpell || !instance.FaceDown && isManaHeart && !targetedSpell || !instance.FaceDown && instance.Info.HasTrait(Trait.Gem) && checkIfTargetedSpell && targetedSpell;
			}
		}

		public static int MagGetValueOfSacrifices(List<CardSlot> sacrifices, bool isMana)
		{
			int num = 0;
			foreach (CardSlot cardSlot in sacrifices)
			{
				bool isManaHeart = false;
				if (SaveManager.saveFile.ascensionActive && MagnificusMod.Generation.challenges.Contains("AllMana"))
				{
					isManaHeart = true;
				}
				if (cardSlot != null && cardSlot.Card != null && isMana)
				{
					if (SceneLoader.ActiveSceneName != "finale_magnificus")
					{
						if (cardSlot.Card.HasAbility(Ability.TripleBlood))
						{
							ProgressionData.SetAbilityLearned(Ability.TripleBlood);
							num += 3;
						}
						else
						{
							num++;
						}
						continue;
					}
					if (!cardSlot.Card.HasTrait(Trait.Gem)) { continue; }
					if (cardSlot.Card.Info.HasAbility(Ability.GainGemBlue) && cardSlot.Card.Info.HasAbility(Ability.GainGemGreen) || cardSlot.Card.Info.HasAbility(Ability.GainGemGreen) && cardSlot.Card.Info.HasAbility(Ability.GainGemOrange) || cardSlot.Card.Info.HasAbility(Ability.GainGemOrange) && cardSlot.Card.Info.HasAbility(Ability.GainGemBlue))
					{
						num += 2;
					}
					else if (cardSlot.Card.Info.HasAbility(Ability.GainGemBlue) && cardSlot.Card.Info.HasAbility(Ability.GainGemGreen) && cardSlot.Card.Info.HasAbility(Ability.GainGemOrange))
					{
						num += 3;
					}
					else if (cardSlot.Card.Info.HasAbility(Ability.GainGemBlue) || cardSlot.Card.Info.HasAbility(Ability.GainGemGreen) || cardSlot.Card.Info.HasAbility(Ability.GainGemOrange))
					{
						num++;
					}
					else if (isManaHeart)
					{
						num++;
					}
				}
				else if (cardSlot != null && cardSlot.Card != null && !isMana)
				{
					if (cardSlot.Card.HasTrait(Trait.Gem)) { continue; }
					if (cardSlot.Card.HasAbility(Ability.TripleBlood))
					{
						num += 3;
					}
					else
					{
						num++;
					}
				}
			}
			return num;
		}


		/*
		 * 
		 * 			GameObject sacrificeMarker = GameObject.Instantiate(Resources.Load("prefabs/cards/SacrificeMarker") as GameObject);
			sacrificeMarker.name = "sacrificeMarker";

			Debug.Log(Singleton<CardSpawner>.Instance.playableCardPrefab);
			Debug.Log(Singleton<CardSpawner>.Instance.playableCardPrefab.transform.childCount);
			sacrificeMarker.transform.parent = Singleton<CardSpawner>.Instance.playableCardPrefab.transform.GetChild(0).GetChild(0);
			sacrificeMarker.transform.localPosition = new Vector3(0, 0f, -0.04f);
		 * 
		 */


		[HarmonyPatch(typeof(CardSlot), "OnCursorEnter")]
		public class showHoveringMarker
		{
			public static bool Prefix(ref CardSlot __instance)
			{
				if (SceneLoader.ActiveSceneName != "finale_magnificus") { return true; }
				if (__instance.Card != null)
				{
					bool isMana = Singleton<PlayerHand>.Instance.ChoosingSlotCard != null ? Singleton<PlayerHand>.Instance.ChoosingSlotCard.Info.GetExtendedPropertyAsBool("ManaCost") == true : false;
					if (Singleton<BoardManager>.Instance.ChoosingSacrifices && MagCanBeSacrificed(__instance.Card, isMana))
					{
						__instance.Card.Anim.gameObject.transform.GetChild(0).GetChild(0).Find("MagSacrificeMarker").gameObject.SetActive(true);
						if (!__instance.Card.HasTrait(Trait.Gem) && !isMana) {
							__instance.Card.Anim.gameObject.transform.GetChild(0).GetChild(0).Find("MagSacrificeMarker").gameObject.GetComponent<MeshRenderer>().material.color = new Color(0.4f, 0, 0, 0);
							__instance.Card.Anim.gameObject.transform.GetChild(0).GetChild(0).Find("MagSacrificeMarker").GetChild(1).gameObject.GetComponent<ParticleSystem>().startColor = new Color(0.3961f, 0.1098f, 0.2275f, 1);//this is just a lie
							__instance.Card.Anim.gameObject.transform.GetChild(0).GetChild(0).Find("MagSacrificeMarker").gameObject.GetComponent<LerpAlpha>().intendedAlpha = 1;
							__instance.Card.Anim.gameObject.transform.GetChild(0).GetChild(0).Find("MagSacrificeMarker").GetChild(0).gameObject.SetActive(true);//0.3961 0.1098 0.2275 1
						} else if (isMana)
						{
							Color renderColor = new Color(1, 1, 1, 0);
							__instance.Card.Anim.gameObject.transform.GetChild(0).GetChild(0).Find("MagSacrificeMarker").gameObject.GetComponent<LerpAlpha>().intendedAlpha = 1;
							__instance.Card.Anim.gameObject.transform.GetChild(0).GetChild(0).Find("MagSacrificeMarker").GetChild(0).gameObject.SetActive(false);
							if (__instance.Card.HasAbility(Ability.GainGemBlue) && __instance.Card.HasAbility(Ability.GainGemOrange))
							{
								renderColor = new Color(0.45f, 0, 1, 0);
							} else if (__instance.Card.HasAbility(Ability.GainGemGreen) && __instance.Card.HasAbility(Ability.GainGemOrange))
							{
								renderColor = new Color(0.58f, 0.28f, 0, 0);
							}
							else if (__instance.Card.HasAbility(Ability.GainGemGreen) && __instance.Card.HasAbility(Ability.GainGemBlue))
							{
								renderColor = new Color(0, 1, 1, 0);
							}
							else if (__instance.Card.HasAbility(Ability.GainGemGreen))
							{
								renderColor = new Color(0.5f, 1, 0, 0);
							}
							else if (__instance.Card.HasAbility(Ability.GainGemOrange))
							{
								renderColor = new Color(1f, 0.4f, 0, 0);
							}
							else if (__instance.Card.HasAbility(Ability.GainGemBlue))
							{
								renderColor = new Color(0, 0.36f, 1, 0);
							}
							Color particleColor = renderColor;
							particleColor.a = 1;
							__instance.Card.Anim.gameObject.transform.GetChild(0).GetChild(0).Find("MagSacrificeMarker").GetChild(1).gameObject.GetComponent<ParticleSystem>().startColor = particleColor;
							__instance.Card.Anim.gameObject.transform.GetChild(0).GetChild(0).Find("MagSacrificeMarker").gameObject.GetComponent<MeshRenderer>().material.color = renderColor;
						}
					}
					__instance.OnCursorEnterWithCard();
					return false;
				}
				__instance.PlaySound();
				if (__instance.Chooseable)
				{
					__instance.ShowState(HighlightedInteractable.State.Highlighted, false, 0.15f);
					return false;
				}
				__instance.ShowState(HighlightedInteractable.State.Highlighted, true, 0.15f);
				return false;
			}
		}

		[HarmonyPatch(typeof(CardSlot), "OnCursorExit")]
		public class hideHoveringMarker
		{
			public static bool Prefix(ref CardSlot __instance)
			{
				if (SceneLoader.ActiveSceneName != "finale_magnificus") { return true; }
				if (__instance.Card != null)
				{
					__instance.Card.Anim.gameObject.transform.GetChild(0).GetChild(0).Find("MagSacrificeMarker").gameObject.GetComponent<LerpAlpha>().intendedAlpha = 0;
					__instance.Card.Anim.gameObject.transform.GetChild(0).GetChild(0).Find("MagSacrificeMarker").GetChild(0).gameObject.SetActive(false);
					if (__instance.Card.Anim.gameObject.transform.GetChild(0).GetChild(0).Find("MagSacrificeMarker").gameObject.activeSelf)
					{
						__instance.StartCoroutine(MagnificusMod.Generation.WaitThenDisable(__instance.Card.Anim.gameObject.transform.GetChild(0).GetChild(0).Find("MagSacrificeMarker").gameObject, 2f));
					}
				}
				__instance.ShowState(HighlightedInteractable.State.Interactable, false, 0.15f);
				return false;
			}
		}

		[HarmonyPatch(typeof(CardAnimationController), "PlaySacrificeSound")]
		public class addSacrificeSound
		{
			public static bool Prefix(ref CardAnimationController __instance)
			{
				if (SceneLoader.ActiveSceneName != "finale_magnificus") { return true; }
				AudioController.Instance.PlaySound2D("sacrifice_default", MixerGroup.TableObjectsSFX);
				return false;
			}
		}

		[HarmonyPatch(typeof(CardAnimationController), "SetMarkedForSacrifice")]
		public class addSacrificMark
		{
			public static bool Prefix(ref CardAnimationController __instance, bool marked)
			{
				if (SceneLoader.ActiveSceneName != "finale_magnificus") { return true; }
				if (marked)
				{
					bool isMana = Singleton<PlayerHand>.Instance.ChoosingSlotCard != null ? Singleton<PlayerHand>.Instance.ChoosingSlotCard.Info.GetExtendedPropertyAsBool("ManaCost") == true : false;
					if (__instance.Card.Info.HasTrait(Trait.Gem) && !isMana || !__instance.Card.Info.HasTrait(Trait.Gem) && isMana)
                    {
						HintsHandler.OnNonsacrificableCardClicked(__instance.PlayableCard);
						return false;
                    }
					AudioController.Instance.PlaySound2D("sacrifice_mark", MixerGroup.TableObjectsSFX);
				}
				return false;
			}
		}

		[HarmonyPatch(typeof(BoardManager), "ChooseSacrificesForCard")]
		public class fixBeingAbleToSacrificeNonManaCardsIHope
		{
			public static void Prefix(ref BoardManager __instance, out BoardManager __state)
			{
				__state = __instance;
			}

			public static IEnumerator Postfix(IEnumerator enumeratr, BoardManager __state, List<CardSlot> validSlots, PlayableCard card)
			{
				if (SceneLoader.ActiveSceneName != "finale_magnificus")
                {
					Singleton<ViewManager>.Instance.Controller.LockState = ViewLockState.Unlocked;
					Singleton<ViewManager>.Instance.SwitchToView(__state.BoardView, false, false);
					Singleton<InteractionCursor>.Instance.ForceCursorType(CursorType.Sacrifice);
					__state.cancelledPlacementWithInput = false;
					__state.currentValidSlots = validSlots;
					__state.currentSacrificeDemandingCard = card;
					__state.CancelledSacrifice = false;
					__state.LastSacrificesInfo.Clear();
					__state.SetQueueSlotsEnabled(false);
					foreach (CardSlot cardSlot in __state.AllSlots)
					{
						if (!cardSlot.IsPlayerSlot || cardSlot.Card == null)
						{
							cardSlot.SetEnabled(false);
							cardSlot.ShowState(HighlightedInteractable.State.NonInteractable, false, 0.15f);
						}
						if (cardSlot.IsPlayerSlot && cardSlot.Card != null && cardSlot.Card.CanBeSacrificed)
						{
							cardSlot.Card.Anim.SetShaking(true);
						}
					}
					yield return __state.SetSacrificeMarkersShown(card.Info.BloodCost);
					while (__state.GetValueOfSacrifices(__state.currentSacrifices) < card.Info.BloodCost && !__state.cancelledPlacementWithInput)
					{
						__state.SetSacrificeMarkersValue(__state.currentSacrifices.Count);
						yield return new WaitForEndOfFrame();
					}
					foreach (CardSlot cardSlot2 in __state.AllSlots)
					{
						cardSlot2.SetEnabled(false);
						if (cardSlot2.IsPlayerSlot && cardSlot2.Card != null)
						{
							cardSlot2.Card.Anim.SetShaking(false);
						}
					}
					foreach (CardSlot cardSlot3 in __state.currentSacrifices)
					{
						__state.LastSacrificesInfo.Add(cardSlot3.Card.Info);
					}
					if (__state.cancelledPlacementWithInput || !__state.SacrificesCreateRoomForCard(card, __state.currentSacrifices))
					{
						__state.HideSacrificeMarkers();
						if (!__state.SacrificesCreateRoomForCard(card, __state.currentSacrifices))
						{
							yield return new WaitForSeconds(0.25f);
						}
						foreach (CardSlot cardSlot4 in __state.GetSlots(true))
						{
							if (cardSlot4.Card != null)
							{
								cardSlot4.Card.Anim.SetSacrificeHoverMarkerShown(false);
								if (__state.currentSacrifices.Contains(cardSlot4))
								{
									cardSlot4.Card.Anim.SetMarkedForSacrifice(false);
								}
							}
						}
						Singleton<ViewManager>.Instance.SwitchToView(__state.defaultView, false, false);
						Singleton<InteractionCursor>.Instance.ClearForcedCursorType();
						__state.CancelledSacrifice = true;
					}
					else
					{
						__state.SetSacrificeMarkersValue(__state.GetValueOfSacrifices(__state.currentSacrifices));
						yield return new WaitForSeconds(0.2f);
						__state.HideSacrificeMarkers();
						foreach (CardSlot cardSlot5 in __state.currentSacrifices)
						{
							if (cardSlot5.Card != null && !cardSlot5.Card.Dead)
							{
								int sacrificesMade__stateTurn = __state.SacrificesMadeThisTurn;
								__state.SacrificesMadeThisTurn = __state.SacrificesMadeThisTurn + 1;
								yield return cardSlot5.Card.Sacrifice();
								Singleton<ViewManager>.Instance.SwitchToView(__state.BoardView, false, false);
							}
						}
						List<CardSlot>.Enumerator enumerator2 = default(List<CardSlot>.Enumerator);
					}
					__state.SetQueueSlotsEnabled(true);
					foreach (CardSlot cardSlot6 in __state.AllSlots)
					{
						cardSlot6.SetEnabled(true);
						cardSlot6.ShowState(HighlightedInteractable.State.Interactable, false, 0.15f);
					}
					__state.currentSacrificeDemandingCard = null;
					__state.currentSacrifices.Clear();
					yield break;
				}
				bool isMana = card.Info.GetExtendedPropertyAsBool("ManaCost") == true;
				Singleton<ViewManager>.Instance.Controller.LockState = ViewLockState.Unlocked;
				Singleton<ViewManager>.Instance.SwitchToView(__state.BoardView, false, false);
				Singleton<InteractionCursor>.Instance.ForceCursorType(CursorType.Sacrifice);
				__state.cancelledPlacementWithInput = false;
				__state.currentValidSlots = validSlots;
				__state.currentSacrificeDemandingCard = card;
				__state.CancelledSacrifice = false;
				__state.LastSacrificesInfo.Clear();
				__state.SetQueueSlotsEnabled(false);
				foreach (CardSlot cardSlot in __state.AllSlots)
				{
					if (!cardSlot.IsPlayerSlot || cardSlot.Card == null)
					{
						cardSlot.SetEnabled(false);
						cardSlot.ShowState(HighlightedInteractable.State.NonInteractable, false, 0.15f);
					}
					if (cardSlot.IsPlayerSlot && cardSlot.Card != null && MagCanBeSacrificed(card, isMana))
					{
						cardSlot.Card.Anim.SetShaking(true);
					}
				}
				yield return __state.SetSacrificeMarkersShown(card.Info.BloodCost);
				while (MagGetValueOfSacrifices(__state.currentSacrifices, isMana) < card.Info.BloodCost && !__state.cancelledPlacementWithInput)
				{
					__state.SetSacrificeMarkersValue(__state.currentSacrifices.Count);
					yield return new WaitForEndOfFrame();
				}
				foreach (CardSlot cardSlot2 in __state.AllSlots)
				{
					cardSlot2.SetEnabled(false);
					if (cardSlot2.IsPlayerSlot && cardSlot2.Card != null)
					{
						cardSlot2.Card.Anim.SetShaking(false);
					}
				}
				foreach (CardSlot cardSlot3 in __state.currentSacrifices)
				{
					__state.LastSacrificesInfo.Add(cardSlot3.Card.Info);
				}
				bool flag = !__state.SacrificesCreateRoomForCard(card, __state.currentSacrifices);
				if (__state.cancelledPlacementWithInput || flag)
				{
					__state.HideSacrificeMarkers();
					if (flag)
					{
						yield return new WaitForSeconds(0.25f);
					}
					foreach (CardSlot cardSlot4 in __state.GetSlots(true))
					{
						if (cardSlot4.Card != null)
						{
							cardSlot4.Card.Anim.SetSacrificeHoverMarkerShown(false);
							if (__state.currentSacrifices.Contains(cardSlot4))
							{
								cardSlot4.Card.Anim.SetMarkedForSacrifice(false);
							}
						}
					}
					Singleton<ViewManager>.Instance.SwitchToView(__state.defaultView, false, false);
					Singleton<InteractionCursor>.Instance.ClearForcedCursorType();
					__state.CancelledSacrifice = true;
				}
				else
				{
					__state.SetSacrificeMarkersValue(MagGetValueOfSacrifices(__state.currentSacrifices, isMana));
					yield return new WaitForSeconds(0.2f);
					__state.HideSacrificeMarkers();
					foreach (CardSlot cardSlot5 in __state.currentSacrifices)
					{
						if (cardSlot5.Card != null && !cardSlot5.Card.Dead)
						{
							if (isMana && !cardSlot5.Card.Info.HasTrait(Trait.Gem) || !isMana && cardSlot5.Card.Info.HasTrait(Trait.Gem)) { continue; }
							int sacrificesMade__stateTurn = __state.SacrificesMadeThisTurn;
							__state.SacrificesMadeThisTurn = sacrificesMade__stateTurn + 1;
							yield return cardSlot5.Card.Sacrifice();
							Singleton<ViewManager>.Instance.SwitchToView(__state.BoardView, false, false);
						}
					}
					List<CardSlot>.Enumerator enumerator2 = default(List<CardSlot>.Enumerator);
				}
				__state.SetQueueSlotsEnabled(true);
				foreach (CardSlot cardSlot6 in __state.AllSlots)
				{
					cardSlot6.SetEnabled(true);
					cardSlot6.ShowState(HighlightedInteractable.State.Interactable, false, 0.15f);
				}
				__state.currentSacrificeDemandingCard = null;
				__state.currentSacrifices.Clear();
				yield break;
			}
		}
	

        [HarmonyPatch(typeof(PlayableCard), "Sacrifice")]
		public class addSacrificeAnimation
		{
			public static void Prefix(ref PlayableCard __instance, out PlayableCard __state)
			{
				__state = __instance;
			}

			public static IEnumerator Postfix(IEnumerator enumeratr, PlayableCard __state)
            {
				AscensionStatsData.TryIncrementStat(AscensionStat.Type.SacrificesMade);
				__state.Anim.PlaySacrificeSound();
				if (__state.HasAbility(Ability.Sacrificial))
				{
					if (SceneLoader.ActiveSceneName != "finale_magnificus")
					{
						__state.Anim.SetSacrificeHoverMarkerShown(false);
						__state.Anim.SetMarkedForSacrifice(false);
						__state.Anim.PlaySacrificeParticles();
						ProgressionData.SetAbilityLearned(Ability.Sacrificial);
					} else
                    {
						__state.Anim.gameObject.transform.GetChild(0).GetChild(0).Find("MagSacrificeMarker").GetChild(1).gameObject.SetActive(true);
						__state.Anim.gameObject.transform.GetChild(0).GetChild(0).Find("MagSacrificeMarker").gameObject.GetComponent<LerpAlpha>().intendedAlpha = 0;
						__state.Anim.gameObject.transform.GetChild(0).GetChild(0).Find("MagSacrificeMarker").GetChild(0).gameObject.SetActive(false);
					}
					if (__state.TriggerHandler.RespondsToTrigger(Trigger.Sacrifice, Array.Empty<object>()))
					{
						yield return __state.TriggerHandler.OnTrigger(Trigger.Sacrifice, Array.Empty<object>());
					}
				}
				else
				{
					if (SceneLoader.ActiveSceneName == "finale_magnificus")
					{
						__state.Anim.gameObject.transform.GetChild(0).GetChild(0).Find("MagSacrificeMarker").GetChild(1).gameObject.SetActive(true);
						__state.Anim.gameObject.transform.GetChild(0).GetChild(0).Find("MagSacrificeMarker").GetChild(0).gameObject.SetActive(false);
						__state.Anim.gameObject.transform.GetChild(0).GetChild(0).Find("MagSacrificeMarker").gameObject.GetComponent<LerpAlpha>().intendedAlpha = 0;
						__state.StartCoroutine(MagnificusMod.Generation.WaitThenDisable(__state.Anim.gameObject.transform.GetChild(0).GetChild(0).Find("MagSacrificeMarker").gameObject, 2f));
					} else
                    {
						__state.Anim.DeactivateSacrificeHoverMarker();
					}
					if (__state.TriggerHandler.RespondsToTrigger(Trigger.Sacrifice, Array.Empty<object>()))
					{
						yield return __state.TriggerHandler.OnTrigger(Trigger.Sacrifice, Array.Empty<object>());
					}
					yield return __state.Die(true, null, true);
				}
				yield break;
            }
		}

		[HarmonyPatch(typeof(HintsHandler), "OnNonplayableCardClicked")]
		public class FixDoubleGemCost
		{
			public static bool Prefix(PlayableCard card, List<PlayableCard> cardsInHand)
			{
				bool hasDoubleCost = false;
				GemType doubleCost = GemType.Blue;
				if (card.Info.gemsCost.Count > 1)
				{
					if (card.Info.gemsCost[0] == card.Info.gemsCost[1])
					{
						doubleCost = card.Info.gemsCost[0];
						hasDoubleCost = true;
					}
				}
				if (hasDoubleCost)
				{
					int gemsOfSame = 0;
					foreach (GemType gem in Singleton<ResourcesManager>.Instance.gems)
					{
						if (gem == doubleCost)
						{
							gemsOfSame++;
						}
					}
					if (gemsOfSame < card.Info.gemsCost.Count)
					{
						int bitch = UnityEngine.Random.Range(0, 100);
						if (bitch < 25)
						{
							Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(Singleton<TextDisplayer>.Instance.ShowUntilInput("You don't have two " + HintsHandler.GetColorCodeForGem(doubleCost) + Localization.Translate(doubleCost.ToString()) + "</color> gems to play that.", 0, 0));
						}
						else if (bitch < 50)
						{
							Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(Singleton<TextDisplayer>.Instance.ShowUntilInput("You'll need two " + HintsHandler.GetColorCodeForGem(doubleCost) + Localization.Translate(doubleCost.ToString()) + "</color> gems to play your " + card.Info.DisplayedNameLocalized + ".", 0, 0));
						}
						else if (bitch < 75)
						{
							Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(Singleton<TextDisplayer>.Instance.ShowUntilInput("You don't have enough " + HintsHandler.GetColorCodeForGem(doubleCost) + Localization.Translate(doubleCost.ToString()) + "</color> gems on the board to play that " + card.Info.DisplayedNameLocalized + ".", 0, 0));
						}
						else
						{
							Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(Singleton<TextDisplayer>.Instance.ShowUntilInput("You need two " + HintsHandler.GetColorCodeForGem(doubleCost) + Localization.Translate(doubleCost.ToString()) + "</color> gems on the board.", 0, 0));
						}
						return false;
					}
				}
				if (card.Info.name == "mag_potion")
                {
					Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(Singleton<TextDisplayer>.Instance.ShowUntilInput("You don't have any cards to use that [c:g1]potion[c:] on."));
					return false;
				}
				return true;
			}
		}

		[HarmonyPatch(typeof(HintsHandler), "OnNonsacrificableCardClicked")]
		public class fixSacrificeHint
		{
			public static bool Prefix(PlayableCard card)
			{
				bool manaCost = Singleton<PlayerHand>.Instance.ChoosingSlotCard != null ? Singleton<PlayerHand>.Instance.ChoosingSlotCard.Info.GetExtendedPropertyAsBool("ManaCost") != null : false;
				if (SceneLoader.ActiveSceneName != "finale_magnificus" || !manaCost)
				{
					return true;
				}
				bool targetedSpell = Singleton<PlayerHand>.Instance.ChoosingSlotCard != null ? Singleton<PlayerHand>.Instance.ChoosingSlotCard.Info.GetExtendedPropertyAsBool("TargetedSpell") == true : false;
				if (card.Info.HasTrait(Trait.Gem) && targetedSpell == true)
                {
					Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(Singleton<TextDisplayer>.Instance.ShowUntilInput("You won't have any cards to use that spell on."));
					return false;
				}
				int bitch = UnityEngine.Random.Range(0, 100);
				if (bitch < 25)
				{
					Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(Singleton<TextDisplayer>.Instance.ShowUntilInput("Your " + card.Info.DisplayedNameLocalized + " wields no mana."));
				}
				else if (bitch < 50)
				{
					Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(Singleton<TextDisplayer>.Instance.ShowUntilInput("That doesn't have any mana."));
				}
				else if (bitch < 75)
				{
					Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(Singleton<TextDisplayer>.Instance.ShowUntilInput("The " + card.Info.DisplayedNameLocalized + " has no mana."));
				}
				else
				{
					Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(Singleton<TextDisplayer>.Instance.ShowUntilInput("You can not draw mana from that."));
				}
				return false;
			}
		}

		[HarmonyPatch(typeof(PlayableCard), "GemsCostRequirementMet")]
		public class addDoubleMoxCost
		{
			public static bool Prefix(ref PlayableCard __instance, ref bool __result)
			{
				bool hasDoubleCost = false;
				GemType doubleCost = GemType.Blue;
				List<GemType> gems = new List<GemType>();
				if (__instance.Info.gemsCost.Count > 1)
				{
					if (__instance.Info.gemsCost[0] == __instance.Info.gemsCost[1])
					{
						doubleCost = __instance.Info.gemsCost[0];
						hasDoubleCost = true;
					}
				}
				if (hasDoubleCost)
				{
					int gemsOfSame = 0;
					foreach (GemType gem in Singleton<ResourcesManager>.Instance.gems)
					{
						if (gem == doubleCost)
						{
							gemsOfSame++;
						}
					}
					if (gemsOfSame < __instance.Info.gemsCost.Count)
					{
						__result = false;
						return false;
					}
				}
				else
				{
					foreach (GemType gem in __instance.Info.GemsCost)
					{
						if (!Singleton<ResourcesManager>.Instance.HasGem(gem))
						{
							__result = false;
							return false;
						}
					}
				}
				__result = true;
				return false;
			}
		}

		public static List<float> getSplashData(CardInfo info)
        {
			List<float> data = new List<float> { 1f, 1f, 1f };
			if (info.BloodCost > 0 && info.GetExtendedProperty("ManaCost") != null)
            {
				data[1] -= 0.5f;
            } else if (info.BloodCost > 0)
            {
				data[1] -= 1f;
				data[2] -= 1f;
            }
			if (info.GemsCost.Contains(GemType.Blue) && info.GemsCost.Contains(GemType.Orange) || info.HasAbility(Ability.GainGemBlue) && info.HasAbility(Ability.GainGemOrange))
			{
				data = new List<float> { 0.45f, 0f, 1f };
			}
			else if (info.GemsCost.Contains(GemType.Green) && info.GemsCost.Contains(GemType.Orange) || info.HasAbility(Ability.GainGemOrange) && info.HasAbility(Ability.GainGemGreen))
			{
				data = new List<float> { 0.58f, 0.28f, 0 };
			}
			else if (info.GemsCost.Contains(GemType.Green) && info.GemsCost.Contains(GemType.Blue) || info.HasAbility(Ability.GainGemBlue) && info.HasAbility(Ability.GainGemGreen))
			{
				data = new List<float> { 0f, 1f, 1f };
			}
			else if (info.GemsCost.Contains(GemType.Green) || info.HasAbility(Ability.GainGemGreen))
			{
				data = new List<float> { 0.5f, 1f, 0f };
			}
			else if (info.GemsCost.Contains(GemType.Orange) || info.HasAbility(Ability.GainGemOrange))
			{
				data = new List<float> { 1f, 0.4f, 0f };
			}
			else if (info.GemsCost.Contains(GemType.Blue) || info.HasAbility(Ability.GainGemBlue))
			{
				data = new List<float> { 0f, 0.5f, 1f };
			}
			float rot = UnityEngine.Random.RandomRangeInt(-14, 14);
			data.Add(rot);
			float flipX = UnityEngine.Random.RandomRangeInt(0, 100) > 50 ? 1 : 0;
			float flipY = UnityEngine.Random.RandomRangeInt(0, 100) > 50 ? 1 : 0;
			data.Add(flipX);
			data.Add(flipY);
			return data;
        }

		[HarmonyPatch(typeof(CardDisplayer), "GetCostSpriteForCard")]
		public class displayCustomCosts
		{
			public static bool Prefix(ref CardDisplayer __instance, ref Sprite __result, CardInfo card)
			{
				if (SceneLoader.ActiveSceneName == "finale_magnificus" && SavedVars.PaintSplashes)
                {
						List<float> data = getSplashData(card);
						__instance.gameObject.transform.Find("PaintSplashes").gameObject.GetComponent<SpriteRenderer>().color = new Color(data[0], data[1], data[2], 1);
						__instance.gameObject.transform.Find("PaintSplashes").rotation = Quaternion.Euler(0, 0, data[3]);
						__instance.gameObject.transform.Find("PaintSplashes").gameObject.GetComponent<SpriteRenderer>().flipX = data[4] > 0 ? true : false;
						__instance.gameObject.transform.Find("PaintSplashes").gameObject.GetComponent<SpriteRenderer>().flipY = data[5] > 0 ? true : false;
					
				}
				if (card.BloodCost > 0 && (card.BonesCost > 0 || card.energyCost > 0 || card.gemsCost.Count > 0) && SceneLoader.ActiveSceneName == "finale_magnificus")
                {
					if (card.GetExtendedProperty("ManaCost") != null)
					{
						__instance.gameObject.transform.Find("AdditionalManaCost").gameObject.GetComponent<SpriteRenderer>().sprite = Generation.manaCostTextures[card.BloodCost];
					}
					else
					{
						__instance.gameObject.transform.Find("AdditionalManaCost").gameObject.GetComponent<SpriteRenderer>().sprite = __instance.costTextures[card.BloodCost];
					}

				} else if (card.BonesCost > 0 && (card.BloodCost > 0 || card.energyCost > 0 || card.gemsCost.Count > 0) && SceneLoader.ActiveSceneName == "finale_magnificus")
				{
					__instance.gameObject.transform.Find("AdditionalManaCost").gameObject.GetComponent<SpriteRenderer>().sprite = __instance.boneCostTextures[card.BonesCost - 1];

				}
				else if (card.energyCost > 0 && (card.BloodCost > 0 || card.bonesCost > 0 || card.gemsCost.Count > 0) && SceneLoader.ActiveSceneName == "finale_magnificus")
				{
					__instance.gameObject.transform.Find("AdditionalManaCost").gameObject.GetComponent<SpriteRenderer>().sprite = __instance.energyCostTextures[card.EnergyCost - 1];

				}
				else if (SceneLoader.ActiveSceneName == "finale_magnificus")
                {
					__instance.gameObject.transform.Find("AdditionalManaCost").gameObject.GetComponent<SpriteRenderer>().sprite = null;
                }
				if (card.BonesCost > 0)
				{
					__result = __instance.boneCostTextures[card.BonesCost - 1];
					return false;
				}
				if (card.GemsCost.Count > 0 && __instance.gemCostTextures != null && __instance.gemCostTextures.Length != 0)
				{
					int num = 0;
					if (card.GemsCost.Count == 1)
					{
						num = (int)card.GemsCost[0];
					}
					else if (card.GemsCost.Count == 2)
					{
						if (card.GemsCost.Contains(GemType.Green) && card.GemsCost.Contains(GemType.Orange))
						{
							num = 3;
						}
						else if (card.GemsCost.Contains(GemType.Orange) && card.GemsCost.Contains(GemType.Blue))
						{
							num = 4;
						}
						else if (card.GemsCost.Contains(GemType.Green) && card.GemsCost.Contains(GemType.Blue))
						{
							num = 5;
						}
						else
						{
							bool hasDoubleCost = false;
							GemType doubleCost = GemType.Blue;
							if (card.gemsCost[0] == card.gemsCost[1])
							{
								hasDoubleCost = true;
								doubleCost = card.gemsCost[0];
							}

							if (hasDoubleCost)
							{
								if (doubleCost == GemType.Green)
								{
									num = 6;
								}
								else if (doubleCost == GemType.Orange)
								{
									num = 7;
								}
								else
								{
									num = 8;
								}
							}
						}
					}
					else
					{
						num = 9;
					}
					__result = __instance.gemCostTextures[num];
					return false;
				}
				if (card.EnergyCost > 0 && __instance.energyCostTextures != null && __instance.energyCostTextures.Length != 0)
				{
					__result = __instance.energyCostTextures[card.EnergyCost - 1];
					return false;
				}
				if (card.GetExtendedProperty("ManaCost") != null)
                {
					__result = Generation.manaCostTextures[card.BloodCost];
					if (SceneLoader.ActiveSceneName.Contains("Ascension") || SceneLoader.ActiveSceneName.Contains("GBC"))
                    {
						__result = Plugin.GBCmanaCostTextures[card.BloodCost];
					}
					return false;
                }
				__result = __instance.costTextures[card.BloodCost];
				return false;
			}
		}
	}
}
