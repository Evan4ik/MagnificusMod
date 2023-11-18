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
	class CardDesignFixes
	{
		[HarmonyPatch(typeof(CardDisplayer3D), "Awake")]
		public class cardtexhelp
		{
			public static void Postfix(ref CardDisplayer3D __instance)
			{
				if (SceneLoader.ActiveSceneName == "finale_magnificus" && !SavedVars.LoadWithFinaleCardBacks)
				{
					__instance.defaultCardBackground = Tools.getImage("magcardbackground.png");
					__instance.defaultPortraitScale = new Vector2(0.699f, 0.45f);
					__instance.portraitRenderer.transform.localScale = new Vector3(0.699f, 0.45f, 5f);
					__instance.emissivePortraitRenderer.transform.localScale = new Vector3(0.699f, 0.45f, 5f);
					__instance.defaultPortraitPos = new Vector2(0, 0.084f);
					__instance.portraitRenderer.transform.position = new Vector3(0, 0.084f, 0);
					__instance.portraitRenderer.color = Color.white;
				} else if (SavedVars.FinaleCardBacks && SceneLoader.ActiveSceneName == "finale_magnificus")
				{
					__instance.defaultCardBackground = Tools.getImage("finalecardback.png");
					__instance.defaultPortraitPos = new Vector2(0, 0.0855f);
					__instance.portraitRenderer.transform.position = new Vector3(0, 0.0855f, 0);
				}
			}
		}

		[HarmonyPatch(typeof(CardDisplayer3D), "DisplaySpecialStatIcons")]
		public class IamGoingToFixGreenMage
		{
			public static bool Prefix(ref CardDisplayer3D __instance, CardRenderInfo renderInfo, PlayableCard playableCard)
			{
				if (SceneLoader.ActiveSceneName != "finale_magnificus")
				{
					return true;
				}
				if (__instance.info.SpecialStatIcon != SpecialStatIcon.None && !renderInfo.showSpecialStats)
				{
					__instance.SetHealthAndAttackIconsActive(StatIconInfo.IconAppliesToAttack(__instance.info.SpecialStatIcon), StatIconInfo.IconAppliesToHealth(__instance.info.SpecialStatIcon));
					__instance.StatIcons.AssignStatIcon(__instance.info.SpecialStatIcon, playableCard);
					return false;
				}
				else if (__instance.info.SpecialStatIcon == SpecialStatIcon.None)
				{
					GameObject.Find("CardElements").transform.Find("Damage_Graphic").gameObject.SetActive(false);
					GameObject.Find("CardElements").transform.Find("Health_Graphic").gameObject.SetActive(false);
				}
				__instance.SetHealthAndAttackIconsActive(false, false);
				return false;
			}

		}

		[HarmonyPatch(typeof(CardStatIcons), "AssignStatIcon")]
		public class TryToFixGreenMageIDareYou
		{
			public static void Postfix(ref CardStatIcons __instance, SpecialStatIcon icon, PlayableCard playableCard)
			{
				bool flag = SceneLoader.ActiveSceneName == "finale_magnificus";
				if (flag)
				{
					bool flag2 = icon != SpecialStatIcon.None && playableCard == null;
					if (flag2)
					{
						bool flag3 = false;
						GameObject gameObject = GameObject.Find("GameTable").transform.Find("CardBattle_Magnificus").Find("CombatBell_Magnificus").gameObject;
						bool activeSelf = gameObject.activeSelf;
						if (activeSelf)
						{
							flag3 = true;
							GameObject.Find("CardElements").transform.Find("Damage_Graphic").gameObject.GetComponent<MeshRenderer>().material.mainTexture = null;
							GameObject.Find("CardElements").transform.Find("Health_Graphic").gameObject.GetComponent<MeshRenderer>().material.mainTexture = null;
							GameObject.Find("CardElements").transform.Find("Damage_Graphic").gameObject.SetActive(false);
							GameObject.Find("CardElements").transform.Find("Health_Graphic").gameObject.SetActive(false);
						}
						StatIconInfo iconInfo = StatIconInfo.GetIconInfo(icon);
						GameObject.Find("CardElements").transform.Find("Damage_Graphic").gameObject.SetActive(false);
						GameObject.Find("CardElements").transform.Find("Health_Graphic").gameObject.SetActive(false);
						bool flag4 = iconInfo.appliesToAttack && !flag3;
						if (flag4)
						{
							GameObject.Find("CardElements").transform.Find("Damage_Graphic").gameObject.SetActive(true);
							GameObject.Find("Damage_Graphic").gameObject.GetComponent<MeshRenderer>().material.mainTexture = iconInfo.iconGraphic;
							GameObject.Find("Damage_Graphic").transform.localScale = new Vector3(0.26f, 0.178f, 0.8852f);
						}
						bool flag5 = iconInfo.appliesToHealth && !flag3;
						if (flag5)
						{
							GameObject.Find("CardElements").transform.Find("Health_Graphic").gameObject.SetActive(true);
							GameObject.Find("Health_Graphic").gameObject.GetComponent<MeshRenderer>().material.mainTexture = iconInfo.iconGraphic;
							GameObject.Find("Health_Graphic").transform.localScale = new Vector3(0.26f, 0.178f, 0.8852f);
						}
					}
					else
					{
						GameObject.Find("CardElements").transform.Find("Damage_Graphic").gameObject.GetComponent<MeshRenderer>().material.mainTexture = null;
						GameObject.Find("CardElements").transform.Find("Health_Graphic").gameObject.GetComponent<MeshRenderer>().material.mainTexture = null;
						GameObject.Find("CardElements").transform.Find("Damage_Graphic").gameObject.SetActive(false);
						GameObject.Find("CardElements").transform.Find("Health_Graphic").gameObject.SetActive(false);
					}
				}
			}
		}

		[HarmonyPatch(typeof(CardDisplayer3D), "DisplayInfo")]
		public class cardtexhelpPlease
		{
			public static void Prefix(ref CardDisplayer3D __instance, CardRenderInfo renderInfo, PlayableCard playableCard)
			{
				if (SceneLoader.ActiveSceneName == "finale_magnificus")
				{
					renderInfo.defaultAbilityColor = Color.white;
					renderInfo.portraitColor = Color.white;
					__instance.portraitRenderer.color = Color.white;
				}
			}
		}


		/*
		[HarmonyPatch(typeof(CardPile), "CreateCard")]
		public class changeBack
		{
			public static bool Prefix(ref CardPile __instance, ref GameObject __result)
			{
				GameObject gameObject = GameObject.Instantiate<GameObject>(__instance.cardbackPrefab);
				gameObject.transform.SetParent(__instance.transform);
				__instance.AddToPile(gameObject.transform);
				bool flag = gameObject.name != "CardBack_Squirrel(Clone)";
				if (flag)
				{
					gameObject.transform.Find("BendableCard").Find("Mesh").gameObject.GetComponent<SkinnedMeshRenderer>().materials[1].mainTexture = Tools.getImage("magcardback.png");
				}
				else
				{
					gameObject.transform.Find("BendableCard").Find("Mesh").gameObject.GetComponent<SkinnedMeshRenderer>().materials[1].mainTexture = Tools.getImage("moxcardback.png");
				}
				__result = gameObject;
				return false;
			}
		}
		*/
		[HarmonyPatch(typeof(RareCardBackground), "ApplyAppearance")]
		public class rareChange
		{
			// Token: 0x06000108 RID: 264 RVA: 0x00019420 File Offset: 0x00017620
			public static bool Prefix(ref RareCardBackground __instance)
			{
				if (SceneLoader.ActiveSceneName != "finale_magnificus")
				{
					return true;
				}
				bool flag = !__instance.Card.Info.displayedName.ToLower().Contains("mox");
				if (flag)
				{
					__instance.Card.RenderInfo.baseTextureOverride = Tools.getImage("magrarecardbackground.png");
				}
				else
				{
					__instance.Card.RenderInfo.baseTextureOverride = Tools.getImage("magraremoxback.png");
				}
				if (SavedVars.LoadWithFinaleCardBacks)
				{
					__instance.Card.RenderInfo.baseTextureOverride = Tools.getImage("finalerarecard.png");
				}
				return false;
			}
		}

		[HarmonyPatch(typeof(TerrainBackground), "ApplyAppearance")]
		public class terrainChange
		{
			public static bool Prefix(ref TerrainBackground __instance)
			{
				if (SceneLoader.ActiveSceneName != "finale_magnificus")
				{
					return true;
				}
				if (SavedVars.LoadWithFinaleCardBacks) { __instance.Card.RenderInfo.baseTextureOverride = Tools.getImage("finalecardback.png"); return false; }
				bool flag = !__instance.Card.Info.displayedName.ToLower().Contains("mox");
				if (flag)
				{
					__instance.Card.RenderInfo.baseTextureOverride = Tools.getImage("magterraincardbackground.png");
				}
				else
				{
					__instance.Card.RenderInfo.baseTextureOverride = Tools.getImage("magmoxcardback.png");
				}
				return false;
			}
		}

		[HarmonyPatch(typeof(TerrainLayout), "UpdateAttackHidden")]
		public class spellShit
		{
			public static void Prefix(ref TerrainLayout __instance)
			{
				if (__instance.Card.Info.traits.Contains(Trait.EatsWarrens))
				{
					__instance.Card.renderInfo.hiddenHealth = true;
					__instance.Card.RenderInfo.baseTextureOverride = Tools.getImage("spellcardback.png");
					if (__instance.Card.Info.metaCategories.Contains(CardMetaCategory.Rare))
					{
						__instance.Card.RenderInfo.baseTextureOverride = Tools.getImage("spellcardbackrare.png");
					}
					if (SavedVars.LoadWithFinaleCardBacks)
					{
						__instance.Card.RenderInfo.baseTextureOverride = Tools.getImage("finalespellback.png");
					}
				}
			}
		}

		public static Sprite upgradedSpell = Tools.getPortraitSprite("spellupgrade.png");

		[HarmonyPatch(typeof(TerrainLayout), "ApplyAppearance")]
		public class spellShit2ftAra
		{
			public static bool Prefix(ref TerrainLayout __instance)
			{
				if (SceneLoader.ActiveSceneName != "finale_magnificus")
				{
					return true;
				}
				__instance.UpdateAttackHidden();
				__instance.Card.RenderInfo.healthTextOffset = new Vector2(-0.11f, 0f);
				if (__instance.Card.Info.HasTrait(Trait.EatsWarrens) && __instance.Card.Info.Attack > 0)
                {
					switch (__instance.Card.Info.name)
                    {
						case "mag_hpspell":
							__instance.Card.renderInfo.portraitOverride = Tools.getPortraitSprite("health_spellbuff.png");
							break;
						case "mag_atkspell":
							__instance.Card.renderInfo.portraitOverride = Tools.getPortraitSprite("attack_spellbuff.png");
							break;
					}
					GameObject upgradeTex = GameObject.Instantiate(new GameObject());
					upgradeTex.name = "upgradeDecal";
					upgradeTex.transform.parent = __instance.Card.gameObject.transform;
					upgradeTex.transform.localPosition = new Vector3(0f, -0.01f, 0.12f);
					upgradeTex.transform.localScale = new Vector3(0.75f, 0.85f, 1f);
					upgradeTex.transform.localRotation = Quaternion.Euler(0, 0, 0);

					if (__instance.Card.gameObject.transform.GetChild(0).gameObject.name == "DustParticles")
					{
						upgradeTex.transform.parent = __instance.Card.gameObject.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(0).GetChild(0);
						upgradeTex.transform.localRotation = Quaternion.Euler(270, 0, 0);
						upgradeTex.transform.localPosition = new Vector3(0f, -0.01f, 0.12f);
					}
					else if (__instance.Card.gameObject.GetComponent<WizardBattle3DPortrait>() == null)
					{
						upgradeTex.transform.parent = __instance.Card.gameObject.transform.GetChild(0).GetChild(0);
						upgradeTex.transform.localRotation = Quaternion.Euler(0, 0, 0);
						upgradeTex.transform.localPosition = new Vector3(0f, -0.01f, 0.12f);
					}
					else
					{
						upgradeTex.transform.localRotation = Quaternion.Euler(0, 0, 0);
						upgradeTex.transform.localPosition = new Vector3(0f, -0.01f, 0.12f);
					}
					upgradeTex.AddComponent<SpriteRenderer>().sprite = upgradedSpell;
				}
				//__instance.Card.RenderInfo.defaultAbilitiesOffset = this.ABILITIES_OFFSET;
				//__instance.Card.AbilityIcons.OffsetDefaultIconsPosition(this.ABILITIES_OFFSET);
				return false;
			}
		}
	

        [HarmonyPatch(typeof(CardChoicesSequencer), "SpawnCard")]
		public class cardBackFix
		{
			public static bool Prefix(ref CardChoicesSequencer __instance, ref SelectableCard __result, Transform parent)
			{
				if (SceneLoader.ActiveSceneName != "finale_magnificus")
				{
					return true;
				}
				GameObject gameObject = GameObject.Instantiate<GameObject>(__instance.selectableCardPrefab);
				gameObject.transform.SetParent(parent);
				gameObject.SetActive(false);
				__result = gameObject.GetComponent<SelectableCard>();
				gameObject.transform.Find("Quad").Find("CardBase").Find("RenderStatsLayer").Find("BendableCard").Find("Mesh").gameObject.GetComponent<SkinnedMeshRenderer>().materials[1].mainTexture = Tools.getImage("magcardback.png");
				return false;
			}
		}
	}
}
