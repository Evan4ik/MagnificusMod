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
using MagNodes = MagnificusMod.MagNodes;
using WallTextures = MagnificusMod.WallTextures;
using Generation = MagnificusMod.Generation;

namespace MagnificusMod
{


	public class setupStuff : Generation
    {

        public void setupCardDisplayers()
        {
			GameObject.Destroy(GameObject.Find("Singletons3D_Finale").transform.Find("CardRenderCamera_Grimora").gameObject);

			if (config.oldCardDesigns)
			{
				GameObject.Find("CardElements").transform.Find("Name").transform.position = new Vector3(80f, 3.3672f, 4.998f);
				GameObject.Find("CardElements").transform.Find("Name").transform.localScale = new Vector3(1.5f, 1f, 1f);
				GameObject.Find("CardElements").transform.Find("CardAbilityIcons_Part3").transform.position = new Vector3(80f, -2.6219f, 4.996f);
				GameObject.Find("CardElements").transform.Find("Portrait").GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
			} else
            {
				GameObject.Find("CardElements").transform.Find("CardAbilityIcons_Part3").transform.localPosition = new Vector3(0, -0.315f, 0);
			}
			GameObject.Find("CardElements").transform.Find("CardStatIcons_Part3").gameObject.SetActive(false);
			GameObject.Instantiate(Resources.Load("prefabs/cards/cardsurfaceinteraction/CardStatIcons")).name = "CardStatIcons";
			GameObject.Find("CardStatIcons").transform.parent = GameObject.Find("CardElements").transform;

			Transform abilities2 = GameObject.Find("CardElements").transform.Find("CardAbilityIcons_Part3").Find("DefaultIcons_2Abilities");
			abilities2.Find("Ability_1").transform.localPosition =  new Vector3(-0.175f, -0.09f, -4.5f);
			abilities2.Find("Ability_2").transform.localPosition = (!config.oldCardDesigns) ? new Vector3(0.1275f, 0.055f, -4.25f) : new Vector3(0.1273f, 0.195f, -4.2815f);

			for (int i = 0; i < abilities2.childCount; i++)
            {
				abilities2.GetChild(i).localScale = new Vector3(0.3f, 0.3f, 1);
			}

			Transform abilities3 = GameObject.Find("CardElements").transform.Find("CardAbilityIcons_Part3").Find("DefaultIcons_3Abilities");
			abilities3.Find("Ability_1").transform.localPosition = new Vector3(-0.2f, -0.1f, 0);
			abilities3.Find("Ability_2").transform.localPosition = new Vector3(0, 0.09f, 0);
			abilities3.Find("Ability_3").transform.localPosition = new Vector3(0.2f, -0.1f, 0);

			for (int i = 0; i < abilities3.childCount; i++)
			{
				abilities3.GetChild(i).localScale = new Vector3(0.23f, 0.23f, 1);
			}

			Transform abilities4 = GameObject.Find("CardElements").transform.Find("CardAbilityIcons_Part3").Find("DefaultIcons_4Abilities");
			abilities4.Find("Ability_1").transform.localPosition = new Vector3(-0.145f, 0.1f, 0);
			abilities4.Find("Ability_2").transform.localPosition = new Vector3(-0.145f, -0.15f, 0);
			abilities4.Find("Ability_3").transform.localPosition = new Vector3(0.145f, 0.1f, 0);
			abilities4.Find("Ability_4").transform.localPosition = new Vector3(0.145f, -0.15f, 0);

			for (int i = 0; i < abilities4.childCount; i++)
			{
				abilities4.GetChild(i).localScale = new Vector3(0.235f, 0.235f, 1);
			}

			GameObject.Find("CardElements").transform.Find("Cost").gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
			GameObject.Find("CardElements").transform.Find("Portrait").gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
			GameObject manaCostSprite = GameObject.Instantiate(GameObject.Find("CardElements").transform.Find("Cost").gameObject);
			manaCostSprite.transform.parent = GameObject.Find("CardElements").transform;
			manaCostSprite.name = "AdditionalManaCost";
			manaCostSprite.transform.localPosition = new Vector3(0.2475f, 0.15f, 0);
			manaCostSprite.transform.localScale = new Vector3(0.6351f, 0.4269f, 0.546f);
			manaCostSprite.GetComponent<SpriteRenderer>().sprite = null;

			GameObject paintSplotches = GameObject.Instantiate(GameObject.Find("CardElements").transform.Find("Cost").gameObject);
			paintSplotches.transform.parent = GameObject.Find("CardElements").transform;
			paintSplotches.name = "PaintSplashes";
			paintSplotches.transform.localPosition = new Vector3(0f, 0f, 0);
			paintSplotches.transform.localScale = (config.paintSplashes) ? new Vector3(0.6473f, 0.5f, 0.546f) : Vector3.zero;
			paintSplotches.GetComponent<SpriteRenderer>().sprite = Tools.getSprite("paint splotches.png");
			paintSplotches.GetComponent<SpriteRenderer>().sortingOrder = 0;

			//damage renderer

			GameObject newDamageRenderer = GameObject.Find("CardStatIcons").transform.Find("Damage_Icon").gameObject;
			newDamageRenderer.name = "Damage_Graphic";
			newDamageRenderer.transform.localScale = new Vector3(1.6f, 1.6f, 1);
			newDamageRenderer.transform.position = new Vector3(78.0871f, -3.137f, 4.998f);
			newDamageRenderer.GetComponent<MeshRenderer>().material.mainTexture = null;
			newDamageRenderer.layer = 13;
			GameObject newHealthRenderer = GameObject.Find("CardStatIcons").transform.Find("Health_Icon").gameObject;
			newHealthRenderer.name = "Health_Graphic";
			newHealthRenderer.transform.position = new Vector3(81.9128f, -3.137f, 5f);
			newHealthRenderer.transform.localScale = new Vector3(1.6f, 1.6f, 1);
			newHealthRenderer.GetComponent<MeshRenderer>().material.mainTexture = null;
			newHealthRenderer.layer = 13;



			//cost sprites

			Sprite sprite = new Sprite();
			Texture2D image = Tools.getImage("mana cost1.png");
			sprite = Sprite.Create(image, new Rect(0f, 0f, 64f, 64f), new Vector2(0.5f, 0.5f));

			Sprite sprite2 = new Sprite();
			Texture2D image2 = Tools.getImage("mana cost2.png");
			sprite2 = Sprite.Create(image2, new Rect(0f, 0f, 64f, 64f), new Vector2(0.5f, 0.5f));

			Sprite sprite3 = new Sprite();
			Texture2D image3 = Tools.getImage("mana cost3plz.png");
			sprite3 = Sprite.Create(image3, new Rect(0f, 0f, 64f, 64f), new Vector2(0.5f, 0.5f));

			Generation.manaCostTextures = new Sprite[5];
			Generation.manaCostTextures[1] = sprite;
			Generation.manaCostTextures[2] = sprite2;
			Generation.manaCostTextures[3] = sprite3;
			Generation.manaCostTextures[4] = sprite2;

			Singleton<CardDisplayer>.Instance.costTextures = new Sprite[5];

			for (int i = 1; i < 5; i++)
			{
				Sprite blood = Tools.convertToSprite(Resources.Load("art/cards/costs/cost_" + i + "blood") as Texture2D);
				Singleton<CardDisplayer>.Instance.costTextures[i] = blood;
			}

			Singleton<CardDisplayer>.Instance.boneCostTextures = new Sprite[10];

			for (int i = 0; i < 10; i++)
			{
				Sprite bone = Tools.convertToSprite(Resources.Load("art/cards/costs/cost_" + (i + 1) + "bone") as Texture2D);
				Singleton<CardDisplayer>.Instance.boneCostTextures[i] = bone;
			}

			Singleton<CardDisplayer>.Instance.energyCostTextures = new Sprite[6];

			for (int i = 0; i < 6; i++)
			{
				Sprite energy = Tools.getSprite("energy_cost_" + (i + 1) + ".png");
				Singleton<CardDisplayer>.Instance.energyCostTextures[i] = energy;
			}

			Sprite greenCost = new Sprite();
			Texture2D greenCost1 = (Resources.Load("art/cards/costs/cost_greengem") as Texture2D);
			greenCost = Sprite.Create(greenCost1, new Rect(0f, 0f, 64f, 64f), new Vector2(0.5f, 0.5f));
			greenCost.name = "cost_green";

			Sprite blueCost = new Sprite();
			Texture2D blueCost1 = (Resources.Load("art/cards/costs/cost_bluegem") as Texture2D);
			blueCost = Sprite.Create(blueCost1, new Rect(0f, 0f, 64f, 64f), new Vector2(0.5f, 0.5f));
			blueCost.name = "cost_blue";

			Sprite orangeCost = new Sprite();
			Texture2D orangeCost1 = (Resources.Load("art/cards/costs/cost_orangegem") as Texture2D);
			orangeCost = Sprite.Create(orangeCost1, new Rect(0f, 0f, 64f, 64f), new Vector2(0.5f, 0.5f));
			orangeCost.name = "cost_orange";

			//double cost vanilla

			Sprite goranjCost = new Sprite();
			Texture2D goranjCost1 = Tools.getImage("cost_goranj.png");
			goranjCost = Sprite.Create(goranjCost1, new Rect(0f, 0f, 64f, 64f), new Vector2(0.5f, 0.5f));
			goranjCost.name = "cost_goranj";

			Sprite bleenCost = new Sprite();
			Texture2D bleenCost1 = Tools.getImage("cost_bleene.png");
			bleenCost = Sprite.Create(bleenCost1, new Rect(0f, 0f, 64f, 64f), new Vector2(0.5f, 0.5f));
			bleenCost.name = "cost_bleene";

			Sprite orluCost = new Sprite();
			Texture2D orluCost1 = Tools.getImage("cost_orlu.png");
			orluCost = Sprite.Create(orluCost1, new Rect(0f, 0f, 64f, 64f), new Vector2(0.5f, 0.5f));
			orluCost.name = "cost_orlu";

			// double o de same

			Sprite green2 = new Sprite();
			Texture2D green21 = Tools.getImage("cost_2green.png");
			green2 = Sprite.Create(green21, new Rect(0f, 0f, 64f, 64f), new Vector2(0.5f, 0.5f));
			green2.name = "cost_green2";

			Sprite blue2 = new Sprite();
			Texture2D blue21 = Tools.getImage("cost_2blue.png");
			blue2 = Sprite.Create(blue21, new Rect(0f, 0f, 64f, 64f), new Vector2(0.5f, 0.5f));
			blue2.name = "cost_blue2";

			Sprite orange2 = new Sprite();
			Texture2D orange21 = Tools.getImage("cost_2orange.png");
			orange2 = Sprite.Create(orange21, new Rect(0f, 0f, 64f, 64f), new Vector2(0.5f, 0.5f));
			orange2.name = "cost_orange2";

			// weird al yancovic cost

			Sprite allMox = new Sprite();
			Texture2D allMox1 = Tools.getImage("all mox.png");
			allMox = Sprite.Create(allMox1, new Rect(0f, 0f, 64f, 64f), new Vector2(0.5f, 0.5f));
			allMox.name = "cost_all";

			Singleton<CardDisplayer>.Instance.gemCostTextures = new Sprite[10];
			Singleton<CardDisplayer>.Instance.gemCostTextures[0] = greenCost;
			Singleton<CardDisplayer>.Instance.gemCostTextures[1] = orangeCost;
			Singleton<CardDisplayer>.Instance.gemCostTextures[2] = blueCost;
			Singleton<CardDisplayer>.Instance.gemCostTextures[3] = goranjCost;
			Singleton<CardDisplayer>.Instance.gemCostTextures[4] = orluCost;
			Singleton<CardDisplayer>.Instance.gemCostTextures[5] = bleenCost;
			Singleton<CardDisplayer>.Instance.gemCostTextures[6] = green2;
			Singleton<CardDisplayer>.Instance.gemCostTextures[7] = orange2;
			Singleton<CardDisplayer>.Instance.gemCostTextures[8] = blue2;
			Singleton<CardDisplayer>.Instance.gemCostTextures[9] = allMox;

			if (!config.oldCardDesigns)
			{

				Generation.cardframe.LoadAllAssets();
				var cardframePrefab = Generation.cardframe.LoadAssetWithSubAssets("cardframe")[0];
				GameObject cardframeObj = GameObject.Instantiate((GameObject)cardframePrefab);

				//cardframeObj.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material.shader = Shader.Find("Standard");
				cardframeObj.name = "cardFrameInstance";
				cardframeObj.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
				cardframeObj.transform.parent = GameObject.Find("MagnificusEnvironment").transform;
				cardframeObj.transform.localPosition = new Vector3(0, 0, 0);

				for (int i = 0; i < cardframeObj.transform.childCount; i++)
				{
					cardframeObj.transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().material.shader = Shader.Find("Standard");
				}

				GameObject frameGemsParent = new GameObject("frameGemsParent");
				frameGemsParent.transform.parent = cardframeObj.transform;
				frameGemsParent.transform.localPosition = Vector3.zero;
				for (int i = 0; i < 3; i++)
				{
					string str = "emerald";
					switch (i)
					{
						case 1:
							str = "ruby"; break;
						case 2:
							str = "sapphire"; break;

					}

					GameObject gemPref = GameObject.Instantiate(GameObject.Find(str + "MoxPref"));
					gemPref.transform.parent = frameGemsParent.transform;

					switch (str)
					{
						case "emerald":
							gemPref.transform.localPosition = new Vector3(0.63f, 0, 0.0675f);
							gemPref.transform.localScale = new Vector3(0.065f, 0.0505f, 0.05f);
							gemPref.transform.localRotation = Quaternion.Euler(0, 0, 90);
							break;
						case "ruby":
							gemPref.transform.localPosition = new Vector3(-0.63f, 0f, 0.0575f);//-0.63 0 0.0575
							gemPref.transform.localScale = new Vector3(0.075f, 0.075f, 0.05f);
							gemPref.transform.localRotation = Quaternion.Euler(0, 0, 0);
							break;
						case "sapphire":
							gemPref.transform.localPosition = new Vector3(0f, -1.185f, 0.07f);
							gemPref.transform.localScale = new Vector3(0.075f, 0.075f, 0.065f);
							gemPref.transform.localRotation = Quaternion.Euler(0, 0, 0);
							break;
					}
				}

				frameGemsParent.SetActive(false);


				cardframeObj.AddComponent<MagCardFrame>();

				GameObject cardFrame = GameObject.Instantiate(cardframeObj);
				cardFrame.transform.parent = Singleton<SelectableCardArray>.Instance.selectableCardPrefab.transform.Find("Quad").Find("CardBase").Find("RenderStatsLayer");
				cardFrame.transform.localPosition = new Vector3(-0.0025f, 0.0125f, 0);
				cardFrame.transform.localScale = new Vector3(0.1785f, 0.1045f, 0.135f);
				cardFrame.transform.localRotation = Quaternion.Euler(0, 180, 0);

				GameObject cardBackFrame = GameObject.Instantiate(cardFrame);
				cardBackFrame.name = "cardBackFrame";
				cardBackFrame.transform.parent = Singleton<CardPile>.Instance.cardbackPrefab.transform;
				cardBackFrame.transform.localRotation = Quaternion.Euler(0, 0, 0);
				cardBackFrame.transform.localScale = new Vector3(0.173f, 0.1045f, 0.001f);
				cardBackFrame.transform.localPosition = new Vector3(-0.0019f, 0.0141f, 0);

				GameObject cardBackFrame2 = GameObject.Instantiate(cardFrame);
				cardBackFrame2.name = "cardBackFrame";
				cardBackFrame2.transform.parent = (Resources.Load("prefabs/cards/CardBack_Magnificus") as GameObject).transform;
				cardBackFrame2.transform.localRotation = Quaternion.Euler(0, 0, 0);
				cardBackFrame2.transform.localScale = new Vector3(0.173f, 0.1045f, 0.001f);
				cardBackFrame2.transform.localPosition = new Vector3(-0.0019f, 0.0141f, 0);

				GameObject playableCardFrame = GameObject.Instantiate(cardFrame);
				playableCardFrame.name = "playableCardFrame";
				playableCardFrame.transform.parent = (Resources.Load("prefabs/cards/PlayableCard_Magnificus") as GameObject).transform.Find("Quad").Find("CardBase").Find("RenderStatsLayer");
				playableCardFrame.transform.localRotation = Quaternion.Euler(0, 180, 0);
				playableCardFrame.transform.localScale = new Vector3(0.1785f, 0.1045f, 0.035f);
				playableCardFrame.transform.localPosition = new Vector3(0f, 0.0141f, 0);
			}
			//talking card renderer


			GameObject newCardElements = GameObject.Instantiate(Singleton<CardDisplayer>.Instance.gameObject);
			GameObject liveRenderer = Singleton<CardRenderCamera>.Instance.liveCardCameraPrefab.gameObject;
			if (liveRenderer.transform.Find("CardsPlane").GetChild(0).GetChild(0).gameObject.activeSelf)
			{
				liveRenderer.transform.Find("EmissionRenderCamera").gameObject.SetActive(false);
				liveRenderer.transform.Find("CardsPlane").GetChild(0).GetChild(0).gameObject.GetComponent<CardDisplayer>().enabled = false;
				liveRenderer.transform.Find("CardsPlane").GetChild(0).GetChild(0).gameObject.SetActive(false);
			}

			newCardElements.transform.parent = liveRenderer.transform.Find("CardsPlane").transform.Find("CardBase");
			newCardElements.name = "CardElements";
			newCardElements.transform.localPosition = Singleton<CardDisplayer>.Instance.transform.localPosition;
			newCardElements.transform.localScale = Singleton<CardDisplayer>.Instance.transform.localScale;
			if (config.oldCardDesigns) newCardElements.transform.Find("Name").transform.localPosition = new Vector3(0f, 0.3542f, -0.002f);
			newCardElements.transform.Find("Name").gameObject.AddComponent<Animator>();
			newCardElements.transform.Find("Name").gameObject.AddComponent<SequentialText>();

			Singleton<CardRenderCamera>.Instance.liveCardCameraPrefab = liveRenderer;
		}


		public void setupCustomObjects()
        {

			//make mox prefab

			for (int i = 0; i < 3; i++)
			{
				string str = "Emerald";
				switch(i)
                {
					case 1:
						str = "Ruby"; break;
					case 2:
						str = "Sapphire"; break;
					
                }
				GameObject gameObject = GameObject.Instantiate<GameObject>(ResourceBank.Get<GameObject>("prefabs/finalemagnificus/Wizard3DPortrait_Mox" + str));
				gameObject.transform.Find("SineWaveMove").Find("Anim").position = new Vector3(0f, -900f, 0f);
				gameObject.transform.Find("SineWaveMove").gameObject.GetComponent<SineWaveMovement>().enabled = false;
				gameObject.transform.Find("SineWaveMove").Find("Anim").gameObject.SetActive(true);
				gameObject.transform.Find("SineWaveMove").position = new Vector3(0f, 0f, 0f);
				gameObject.transform.Find("SineWaveMove").Find("Anim").gameObject.GetComponent<Animator>().enabled = false;
				gameObject = gameObject.transform.Find("SineWaveMove").Find("Anim").gameObject;
				gameObject.name = str.ToLower() + "MoxPref";
				gameObject.transform.parent = GameObject.Find("MagnificusEnvironment").transform;
			}

			GameObject manaT = GameObject.Instantiate(GameObject.Find("emeraldMoxPref").transform.Find("Gem").gameObject);
			manaT.name = "mana1";
			manaT.transform.parent = GameObject.Find("MagnificusEnvironment").transform;
			manaT.GetComponent<MeshRenderer>().material.mainTexture = Tools.getImage("mana.png");
			manaT.transform.position = new Vector3(0, -90, 0);

			GameObject manaS = GameObject.Instantiate(GameObject.Find("sapphireMoxPref").transform.Find("Gem").gameObject);
			manaS.name = "mana2";
			manaS.transform.parent = GameObject.Find("MagnificusEnvironment").transform;
			manaS.GetComponent<MeshRenderer>().material.mainTexture = Tools.getImage("mana.png");
			manaS.transform.position = new Vector3(0, -90, 0);


			GameObject crates = GameObject.Instantiate(Resources.Load("prefabs/environment/tableeffects/CratesTableEffects") as GameObject);
			crates.name = "crates";
			crates.transform.position = new Vector3(0, -90, 0);
			GameObject.Destroy(crates.transform.Find("CratesLeft").gameObject);
			crates.transform.Find("CratesRight").localPosition = new Vector3(0, 0, 0);
			crates.transform.Find("CratesRight").localScale = new Vector3(1.5f, 1.5f, 1.5f);
			crates.transform.parent = GameObject.Find("MagnificusEnvironment").transform;



			GameObject gooBottle = GameObject.Instantiate(Resources.Load("prefabs/items/GooBottleItem") as GameObject);
			gooBottle.name = "gooBottle";
			gooBottle.transform.position = new Vector3(0, -90, 0);
			gooBottle.GetComponent<Animator>().enabled = false;
			gooBottle.GetComponent<GooBottleItem>().enabled = false;
			gooBottle.transform.Find("GooWizardBottle").gameObject.GetComponent<Animator>().enabled = false;
			gooBottle.transform.Find("GooWizardBottle").gameObject.GetComponent<GooWizardAnimationController>().enabled = false;
			gooBottle.transform.localScale = new Vector3(3, 3, 3);
			GameObject gooBottle2 = GameObject.Instantiate(gooBottle);
			gooBottle2.name = "gooBottle2";
			gooBottle2.transform.Find("GooWizardBottle").Find("GooWizard").Find("Bottle").gameObject.SetActive(false);
			gooBottle2.transform.Find("GooWizardBottle").Find("GooWizard").Find("Cork").gameObject.SetActive(false);
			gooBottle2.transform.rotation = Quaternion.Euler(0, 180, 0);
			gooBottle2.transform.parent = gooBottle.transform;
			gooBottle2.transform.localPosition = new Vector3(0, 0, 0.08f);
			gooBottle.transform.parent = GameObject.Find("MagnificusEnvironment").transform;

			GameObject floatingBook = GameObject.Instantiate(Resources.Load("prefabs/factoryindoors/FactoryFloatingBook") as GameObject);
			floatingBook.name = "floatingBook";
			floatingBook.transform.position = new Vector3(0, -90, 0);
			floatingBook.GetComponent<ActiveIfHoloMapZone>().enabled = false;
			floatingBook.transform.Find("Book").gameObject.SetActive(true);
			floatingBook.transform.Find("Book").transform.localScale = new Vector3(0.49f, 0.33f, 0.09f);
			GameObject book2 = GameObject.Instantiate(floatingBook.transform.Find("Book").gameObject);
			book2.transform.parent = floatingBook.transform;
			book2.transform.localPosition = new Vector3(-8.5f, 3, 0);
			book2.transform.localRotation = Quaternion.Euler(11.9f, 80.5f, 302.9f);
			book2.GetComponent<MeshRenderer>().material.color = new Color(0.65f, 1f, 0.65f, 1);
			GameObject book3 = GameObject.Instantiate(floatingBook.transform.Find("Book").gameObject);
			book3.transform.parent = floatingBook.transform;
			book3.transform.localPosition = new Vector3(-4.25f, 5.5f, -4.18f);
			book3.transform.localRotation = Quaternion.Euler(5.7f, 359.35f, 267.6f);
			book3.GetComponent<MeshRenderer>().material.color = new Color(0.65f, 0.65f, 1, 1);
			floatingBook.transform.parent = GameObject.Find("MagnificusEnvironment").transform;

			GameObject shrooms = GameObject.Instantiate(Resources.Load("prefabs/specialnodesequences/Mushroom_CardChoice") as GameObject);
			shrooms.name = "shroom";
			shrooms.transform.localScale = new Vector3(5, 5, 5);
			shrooms.transform.position = new Vector3(0, -90, 0);
			shrooms.transform.parent = GameObject.Find("MagnificusEnvironment").transform;

			GameObject eyes = GameObject.Instantiate(Resources.Load("prefabs/specialnodesequences/EyeBall") as GameObject);
			eyes.name = "eyeball";
			eyes.transform.localScale = new Vector3(15, 15, 15);
			GameObject.Destroy(eyes.GetComponent<Rigidbody>());
			GameObject.Destroy(eyes.GetComponent<EyeballInteractable>());
			eyes.transform.parent = GameObject.Find("MagnificusEnvironment").transform;
			eyes.transform.localPosition = new Vector3(0, 0, 0);

			//font break

			Generation.fontmanager.LoadAllAssets();
			var fontPrefab = Generation.fontmanager.LoadAssetWithSubAssets("Fonts")[0];
			GameObject fontObj = GameObject.Instantiate((GameObject)fontPrefab);

			fontObj.transform.parent = GameObject.Find("MagnificusEnvironment").transform;
			fontObj.transform.localPosition = new Vector3(0, 0, 0);
			fontObj.name = "Fonts";

			/*
			var stimmyFont = Generation.fontmanager.LoadAssetWithSubAssets("StimFont")[0];
			GameObject stimmyFontObj = GameObject.Instantiate((GameObject)stimmyFont);

			stimmyFontObj.transform.parent = GameObject.Find("MagnificusEnvironment").transform;
			stimmyFontObj.transform.localPosition = new Vector3(0, 0, 0);
			stimmyFontObj.name = "StimmyFont";*/

			//custom ones

			Generation.pike.LoadAllAssets();
			var pikePrefab = Generation.pike.LoadAssetWithSubAssets("newPike")[0];
			GameObject pikeStick = GameObject.Instantiate((GameObject)pikePrefab);

			pikeStick.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material.shader = Shader.Find("Standard");
			pikeStick.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().materials[1].shader = Shader.Find("Standard");//0.75 0.7 0.85 1
			pikeStick.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().materials[1].color = new Color(0.55f, 0.4f, 0.45f, 1);
			pikeStick.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().materials[2].shader = Shader.Find("Standard");
			pikeStick.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().materials[2].color = new Color(0.75f, 0.7f, 0.85f, 1);
			pikeStick.name = "PikeModel";
			pikeStick.transform.localScale = new Vector3(2, 2, 2);
			pikeStick.transform.parent = GameObject.Find("MagnificusEnvironment").transform;
			pikeStick.transform.localPosition = new Vector3(0, 0, 0);

			Generation.sword.LoadAllAssets();
			var swordPrefab = Generation.sword.LoadAssetWithSubAssets("sword")[0];
			GameObject swordObj = GameObject.Instantiate((GameObject)swordPrefab);

			swordObj.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material.shader = Shader.Find("Standard");
			swordObj.name = "swordModel";
			swordObj.transform.localScale = new Vector3(5, 5, 5);
			swordObj.transform.parent = GameObject.Find("MagnificusEnvironment").transform;
			swordObj.transform.localPosition = new Vector3(0, 0, 0);

			Generation.dummy.LoadAllAssets();
			var dummyPrefab = Generation.dummy.LoadAssetWithSubAssets("danny")[0];
			GameObject dummyObj = GameObject.Instantiate((GameObject)dummyPrefab);

			dummyObj.GetComponent<MeshRenderer>().material.shader = Shader.Find("Standard");
			dummyObj.name = "trainingDummy";
			dummyObj.transform.localScale = new Vector3(500, 500, 500);
			dummyObj.transform.parent = GameObject.Find("MagnificusEnvironment").transform;
			dummyObj.transform.localPosition = new Vector3(0, 0, 0);

			GameObject archeryDummy = GameObject.Instantiate(Resources.Load("art/assets3d/wizardbattle/practicemage/ArcheryTarget") as GameObject);
			archeryDummy.name = "archeryDummy";
			archeryDummy.transform.localScale = new Vector3(2.2f, 2.2f, 2.2f);
			archeryDummy.transform.parent = GameObject.Find("MagnificusEnvironment").transform;
			archeryDummy.transform.localPosition = new Vector3(0, 0, 0);

			Generation.cauldron.LoadAllAssets();
			var cauldronPrefab = Generation.cauldron.LoadAssetWithSubAssets("cauldronModel")[0];
			GameObject cauldronObj = GameObject.Instantiate((GameObject)cauldronPrefab);

			cauldronObj.name = "cauldron";
			for (int i = 0; i < cauldronObj.transform.childCount; i++)
			{
				cauldronObj.transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().material.shader = Shader.Find("Standard");
			}
			for (int i = 0; i < cauldronObj.transform.GetChild(4).gameObject.GetComponent<MeshRenderer>().materials.Length; i++)
			{
				cauldronObj.transform.GetChild(4).gameObject.GetComponent<MeshRenderer>().materials[i].shader = Shader.Find("Standard");
			}
			cauldronObj.transform.parent = GameObject.Find("MagnificusEnvironment").transform;
			cauldronObj.transform.localPosition = new Vector3(0, 0, 0);



			Generation.picnic.LoadAllAssets();
			var hubert3D = Generation.picnic.LoadAssetWithSubAssets("hubert")[0];
			var cloth = Generation.picnic.LoadAssetWithSubAssets("picnic")[0];
			GameObject hubertObj = GameObject.Instantiate((GameObject)hubert3D);
			GameObject clothObj = GameObject.Instantiate((GameObject)cloth);

			for (int i = 0; i < hubertObj.transform.childCount; i++)
			{
				hubertObj.transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().material.shader = Shader.Find("Standard");
			}

			for (int i = 0; i < clothObj.transform.childCount; i++)
			{
				clothObj.transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().material.shader = Shader.Find("Standard");
			}
			clothObj.name = "cloth3D";
			hubertObj.transform.parent = clothObj.transform;
			hubertObj.name = "hubert3D";
			hubertObj.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
			hubertObj.transform.rotation = Quaternion.Euler(0, 129, 0);
			hubertObj.AddComponent<BoxCollider>();
			hubertObj.GetComponent<BoxCollider>().center = new Vector3(0, 0.6f, 0);
			hubertObj.GetComponent<BoxCollider>().size = new Vector3(5, 5, 5);
			hubertObj.AddComponent<hubertbooper>();
			clothObj.transform.parent = GameObject.Find("MagnificusEnvironment").transform;
			clothObj.transform.localPosition = new Vector3(0, 0, 0);
			clothObj.transform.localScale = new Vector3(5, 5, 5);

			Generation.towerwalls.LoadAllAssets();
			var towerRing = Generation.towerwalls.LoadAssetWithSubAssets("towerwalls")[0];
			GameObject towerObj = GameObject.Instantiate((GameObject)towerRing);

			towerObj.GetComponentInChildren<MeshRenderer>().material.shader = Shader.Find("Standard");
			towerObj.name = "towerWalls";
			towerObj.transform.localScale = new Vector3(5, 5, 5);
			towerObj.transform.parent = GameObject.Find("MagnificusEnvironment").transform;
			towerObj.transform.localPosition = new Vector3(0, 0, 0);

			var towerRing3 = Generation.towerwalls.LoadAssetWithSubAssets("towerwall3")[0];
			GameObject towerObj3 = GameObject.Instantiate((GameObject)towerRing3);

			towerObj3.GetComponentInChildren<MeshRenderer>().material.shader = Shader.Find("Standard");
			towerObj3.name = "towerWall3";
			towerObj3.transform.localScale = new Vector3(5, 5, 5);
			towerObj3.transform.parent = GameObject.Find("MagnificusEnvironment").transform;
			towerObj3.transform.localPosition = new Vector3(0, 0, 0);

			var finalfloor = Generation.towerwalls.LoadAssetWithSubAssets("towerwalls4")[0];
			GameObject finalFloorObj = GameObject.Instantiate((GameObject)finalfloor);

			finalFloorObj.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material.shader = Shader.Find("Standard");
			finalFloorObj.transform.GetChild(1).gameObject.GetComponent<MeshRenderer>().material.shader = Shader.Find("Standard");
			finalFloorObj.transform.GetChild(1).localScale = new Vector3(100, 100, 102);
			finalFloorObj.transform.GetChild(1).gameObject.GetComponent<MeshRenderer>().material.color = new Color(0.8f, 0.8f, 0.8f, 1);
			finalFloorObj.transform.GetChild(2).gameObject.GetComponent<MeshRenderer>().material.shader = Shader.Find("Standard");

			finalFloorObj.transform.GetChild(2).localScale = new Vector3(230, 230, 350);
			finalFloorObj.name = "towerWall4";
			finalFloorObj.transform.localScale = new Vector3(0, 0, 0);
			finalFloorObj.transform.parent = GameObject.Find("MagnificusEnvironment").transform;
			finalFloorObj.transform.localPosition = new Vector3(0, 0, 0);


			

			tablecloth.LoadAllAssets();
			var tableclothPrefab = tablecloth.LoadAssetWithSubAssets("tablecloth")[0];
			GameObject tableclothObj = GameObject.Instantiate((GameObject)tableclothPrefab);

			tableclothObj.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material.shader = Shader.Find("Standard");//0.5 0 0.16 1
			tableclothObj.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().materials[1].shader = Shader.Find("Standard");

			tableclothObj.name = "tableCloth";
			tableclothObj.transform.localScale = new Vector3(7.75f, 7.75f, 7.75f);
			tableclothObj.transform.parent = GameObject.Find("tbPillar").transform;
			tableclothObj.transform.localPosition = new Vector3(0, 4.025f, 0);

			setTableClothColor(new Color(0.5f, 0, 0.16f, 1));

			GameObject easel = GameObject.Instantiate(GameObject.Find("CopyCardSequencer").transform.Find("EaselWithCard").gameObject);
			easel.name = "easel";
			easel.transform.position = new Vector3(0, -90, 0);
			easel.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
			easel.gameObject.SetActive(true);
			easel.transform.parent = GameObject.Find("MagnificusEnvironment").transform;

			GameObject light = GameObject.Instantiate(new GameObject());

			light.AddComponent<Light>();
			light.name = "light";
			light.GetComponent<Light>().intensity = 0.6f;
			light.GetComponent<Light>().shape = LightShape.Cone;
			light.GetComponent<Light>().spotAngle = 30f;
			light.GetComponent<Light>().range = 50f;
			light.transform.localPosition = new Vector3(0f, 20.63f, -1f);
			light.GetComponent<Light>().color = new Color(0.9137255f, 0.9137255f, 0.9137255f, 1f);
			GameObject deckLight = GameObject.Instantiate(light);
			deckLight.name = "deckLight";
			deckLight.transform.parent = light.transform;
			deckLight.GetComponent<Light>().intensity = 1.8f;
			deckLight.transform.localPosition = new Vector3(0, 0, -15f);
			light.transform.parent = GameObject.Find("GameTable").transform;
			light.transform.localPosition = new Vector3(0, 0, 0);

			//update stuff


			//characters

			goober.LoadAllAssets();

			var gooberPrefab = goober.LoadAssetWithSubAssets("Goober")[0];

			GameObject goob = GameObject.Instantiate((GameObject)gooberPrefab);
			goob.transform.GetChild(0).localScale = new Vector3(1, 1, 1);
			goob.transform.GetChild(0).gameObject.GetComponent<SkinnedMeshRenderer>().materials[0].shader = Shader.Find("Standard");
			goob.transform.GetChild(0).gameObject.GetComponent<SkinnedMeshRenderer>().materials[1].shader = Shader.Find("Standard");

			goob.name = "Goober";
			goob.transform.localScale = new Vector3(5, 5, 5);
			goob.transform.parent = GameObject.Find("GameTable").transform;
			goob.transform.localPosition = new Vector3(0, 6, 26);
			goob.transform.rotation = Quaternion.Euler(0, 180, 0);
			goob.SetActive(false);

			espeara.LoadAllAssets();

			var espearaPrefab = espeara.LoadAssetWithSubAssets("PikeMage")[0];

			GameObject pikeMage = GameObject.Instantiate((GameObject)espearaPrefab);
			pikeMage.transform.localScale = new Vector3(1, 1, 1);
			for (int i = 0; i < pikeMage.transform.childCount; i++)
			{
				if (pikeMage.transform.GetChild(i).gameObject.name != "Empty")
				{
					pikeMage.transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().material.shader = Shader.Find("Standard");
				}
				if (pikeMage.transform.GetChild(i).gameObject.name == "Sphere")
				{
					pikeMage.transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().materials[1].shader = Shader.Find("Standard");
				}
			}

			pikeMage.name = "Espeara";
			pikeMage.transform.localScale = new Vector3(5, 5, 5);
			pikeMage.transform.parent = GameObject.Find("GameTable").transform;
			pikeMage.transform.localPosition = new Vector3(0, -10f, 45f);
			pikeMage.transform.rotation = Quaternion.Euler(0, 270, 0);
			pikeMage.SetActive(false);

			stimothy.LoadAllAssets();

			var stimothyPrefab = stimothy.LoadAssetWithSubAssets("Stimothy")[0];

			GameObject lonelyMage = GameObject.Instantiate((GameObject)stimothyPrefab);
			lonelyMage.name = "LonelyMage";
			lonelyMage.transform.GetChild(1).gameObject.GetComponent<SkinnedMeshRenderer>().materials[0].shader = Shader.Find("Standard");
			lonelyMage.transform.GetChild(2).GetChild(0).GetChild(0).GetChild(1).GetChild(1).gameObject.GetComponent<MeshRenderer>().materials[0].shader = Shader.Find("Standard");
			lonelyMage.transform.GetChild(2).GetChild(0).GetChild(0).GetChild(1).GetChild(1).gameObject.GetComponent<MeshRenderer>().materials[1].shader = Shader.Find("Standard");
			lonelyMage.transform.GetChild(2).GetChild(0).GetChild(0).GetChild(2).GetChild(1).gameObject.GetComponent<MeshRenderer>().materials[0].shader = Shader.Find("Standard");
			lonelyMage.transform.GetChild(2).GetChild(0).GetChild(0).GetChild(2).GetChild(1).gameObject.GetComponent<MeshRenderer>().materials[1].shader = Shader.Find("Standard");
			lonelyMage.transform.GetChild(2).GetChild(0).GetChild(0).GetChild(4).gameObject.GetComponent<MeshRenderer>().materials[0].shader = Shader.Find("Standard");

			lonelyMage.transform.GetChild(2).GetChild(0).GetChild(0).GetChild(3).GetChild(0).gameObject.GetComponent<MeshRenderer>().materials[0].shader = Shader.Find("Standard");
			lonelyMage.transform.GetChild(2).GetChild(0).GetChild(0).GetChild(3).GetChild(2).gameObject.GetComponent<MeshRenderer>().materials[0].shader = Shader.Find("Standard");
			lonelyMage.transform.GetChild(2).GetChild(0).GetChild(0).GetChild(3).GetChild(2).gameObject.GetComponent<MeshRenderer>().materials[1].shader = Shader.Find("Standard");

			lonelyMage.transform.localScale = new Vector3(3, 3, 3);
			lonelyMage.transform.parent = GameObject.Find("GameTable").transform;
			lonelyMage.transform.localPosition = new Vector3(0, 1, 15);
			lonelyMage.transform.rotation = Quaternion.Euler(0, 0, 0);
			lonelyMage.SetActive(false);
		}


		public void setupTable()
        {
			GameObject.Instantiate(new GameObject()).name = "GameTable";
			GameObject.Instantiate(new GameObject()).name = "SpecialNodeHandler";
			GameObject.Instantiate(Resources.Load("prefabs/cardbattle/Deck")).name = "DeckReviewCardArray";
			GameObject.Instantiate(Resources.Load("prefabs/specialnodesequences/CardChoiceSelector")).name = "CardChoiceSelector";
			GameObject.Instantiate(Resources.Load("prefabs/specialnodesequences/RareCardChoiceSelector")).name = "RareCardChoiceSelector";
			GameObject.Instantiate(Resources.Load("prefabs/specialnodesequences/BuyPeltsSequencer")).name = "BuyPeltsSequencer";
			GameObject.Instantiate(Resources.Load("prefabs/specialnodesequences/TradePeltsSequencer")).name = "TradePeltsSequencer";
			GameObject.Instantiate(Resources.Load("prefabs/specialnodesequences/CardStatBoostSequencer")).name = "CardStatBoostSequencer";
			GameObject.Instantiate(Resources.Load("prefabs/specialnodesequences/DuplicateMerger")).name = "DuplicateMerger";
			GameObject.Instantiate(Resources.Load("prefabs/specialnodesequences/CopyCardSequencer")).name = "CopyCardSequencer";
			GameObject.Find("DeckReviewCardArray").transform.parent = GameObject.Find("GameTable").transform;
			GameObject.Find("SpecialNodeHandler").transform.parent = GameObject.Find("GameTable").transform;
			GameObject.Find("SpecialNodeHandler").AddComponent<SpecialNodeHandler>();
			GameObject.Find("BuyPeltsSequencer").transform.parent = GameObject.Find("SpecialNodeHandler").transform;
			GameObject.Find("TradePeltsSequencer").transform.parent = GameObject.Find("SpecialNodeHandler").transform;
			GameObject.Find("CardStatBoostSequencer").transform.parent = GameObject.Find("SpecialNodeHandler").transform;
			GameObject.Find("CardChoiceSelector").transform.parent = GameObject.Find("SpecialNodeHandler").transform;
			GameObject.Find("RareCardChoiceSelector").transform.parent = GameObject.Find("SpecialNodeHandler").transform;
			GameObject.Find("DuplicateMerger").transform.parent = GameObject.Find("SpecialNodeHandler").transform;
			GameObject.Find("CopyCardSequencer").transform.parent = GameObject.Find("SpecialNodeHandler").transform;
			Singleton<MagnificusGameFlowManager>.Instance.cardbattleParent.transform.parent = GameObject.Find("GameTable").transform;
			Singleton<MagnificusGameFlowManager>.Instance.cardbattleParent.transform.Find("RuleBookRig_Magnificus").parent = GameObject.Find("GameTable").transform;

			Singleton<SpecialNodeHandler>.Instance.buyPeltsSequencer = GameObject.Find("BuyPeltsSequencer").GetComponent<BuyPeltsSequencer>();
			Singleton<SpecialNodeHandler>.Instance.tradePeltsSequencer = GameObject.Find("TradePeltsSequencer").GetComponent<TradePeltsSequencer>();
			Singleton<SpecialNodeHandler>.Instance.cardChoiceSequencer = GameObject.Find("CardChoiceSelector").GetComponent<CardSingleChoicesSequencer>();
			Singleton<SpecialNodeHandler>.Instance.rareCardChoiceSequencer = GameObject.Find("RareCardChoiceSelector").GetComponent<RareCardChoicesSequencer>();
			Singleton<SpecialNodeHandler>.Instance.duplicateMerger = GameObject.Find("DuplicateMerger").GetComponent<DuplicateMergeSequencer>();

			GameObject.Instantiate(Resources.Load("prefabs/finalemagnificus/MarbleColumn")).name = "tbPillar";
			GameObject.Find("tbPillar").transform.parent = GameObject.Find("GameTable").transform;
			GameObject.Find("tbPillar").transform.position = new Vector3(0.88f, -5f, -1f);
			GameObject.Find("tbPillar").transform.localScale = new Vector3(2.25f, 1f, 2.25f);


        }


        public void setupNodes()
        {
            //make nodebase
            GameObject.Find("MagnificusEnvironment").transform.Find("GiantPainting").gameObject.SetActive(true);
            GameObject.Find("GiantPainting").transform.position = new Vector3(349.1401f, -100f, -211.7801f);
            GameObject.DestroyImmediate(GameObject.Find("GiantPainting").GetComponent<GiantPaintingAnim>());
            GameObject.Find("GiantPainting").transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
            GameObject.Find("GiantPainting").transform.Find("Frame").rotation = Quaternion.Euler(0f, 180f, 90f);
            GameObject.Find("GiantPainting").transform.Find("Frame").localScale = new Vector3(13.8847f, 8.089f, 1f);
            GameObject.Find("GiantPainting").transform.Find("Frame").localPosition = new Vector3(1.4f, 23f, 0f);
            GameObject gameObject2 = GameObject.Find("GiantPainting");
            gameObject2.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().lightmapIndex = -1;
            gameObject2.name = "nodeIconBase";
            gameObject2.transform.Find("RenderCamera").gameObject.SetActive(false);
            gameObject2.transform.Find("RenderCamera").parent = GameObject.Find("MagnificusEnvironment").transform;


			//setup life manager

			GameObject lifeCounter = GameObject.Instantiate(GameObject.Find("nodeIconBase"));
			lifeCounter.name = "LifePainting";
			lifeCounter.transform.Find("Frame").Find("canvas_low").gameObject.SetActive(false);
			lifeCounter.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = Tools.getImage("lifepainting" + SaveManager.saveFile.currentRun.playerLives + ".png");
			lifeCounter.transform.parent = GameObject.Find("GameTable").transform;
			lifeCounter.transform.localPosition = new Vector3(7.5f, 6.72f, 3.5f);
			lifeCounter.transform.localRotation = Quaternion.Euler(0, 45, 0);
			lifeCounter.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);

			GameObject lifeCounterB = GameObject.Instantiate(lifeCounter);
			lifeCounterB.transform.parent = lifeCounter.transform;
			lifeCounterB.transform.localPosition = new Vector3(0, 0, -0.1f);
			lifeCounterB.transform.localRotation = Quaternion.Euler(0, 180, 0);
			lifeCounterB.transform.localScale = new Vector3(1, 1, 1);
			lifeCounterB.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = Tools.getImage("paintingback.png");

			lifeCounter.transform.localPosition = new Vector3(7.5f, 16.72f, 3.5f);
			lifeCounter.AddComponent<SineWaveMovement>();
			lifeCounter.GetComponent<SineWaveMovement>().enabled = false;
			lifeCounter.GetComponent<SineWaveMovement>().originalPosition = new Vector3(7.5f, 16.22f, 3.5f);
			lifeCounter.GetComponent<SineWaveMovement>().speed = 1;
			lifeCounter.GetComponent<SineWaveMovement>().yMagnitude = 0.5f;
			lifeCounter.SetActive(false);

			lifeCounter.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = Tools.getImage("lifepainting" + SaveManager.saveFile.currentRun.playerLives + ".png");


			edaxioTex = Tools.getImage("edaxionode.png");

            shopTex = Tools.getImage("moxshop.png");
            battleTex = Tools.getImage("cardbattlenode.png");
            cardTex = Tools.getImage("cardchoicenode.png");
            costTex = Tools.getImage("cardcostchoice.png");
            spellTex = Tools.getImage("cardspellchoice.png");
            draftingTex = Tools.getImage("draftingmodnode.png");
            bleachTex = Tools.getImage("bleachnode.png");
            copyTex = Tools.getImage("copycardnode.png");
            paintTex = Tools.getImage("paintingevent.png");
            removeTex = Tools.getImage("removecardnode.png");
            mergeTex = Tools.getImage("mergenode.png");
            costchngTex = Tools.getImage("changecost.png");
            enchantTex = Tools.getImage("enchantnode.png");
            spellUpgradeTex = Tools.getImage("spellenchanter.png");
            cauldronTex = Tools.getImage("cauldronnode.png");

			bleachbattleTex = Tools.getImage("specialbleachbattlenode.png");
            goobossTex = Tools.getImage("boss goo.png");
            pikebossTex = Tools.getImage("boss pike.png");
            stimbossTex = Tools.getImage("boss stim.png");


			MagnificusGameFlowManager instance = Singleton<MagnificusGameFlowManager>.Instance;


			edaxioNode.triggerOnEnter = true;
			edaxioNode.eventToTrigger = delegate ()
			{
				MagNodes.EdaxioNode triggeringNodeData2 = new MagNodes.EdaxioNode();
				Singleton<FirstPersonController>.Instance.LookAtDirection(LookDirection.North, true);
				Singleton<FirstPersonController>.Instance.enabled = false;
				Singleton<FirstPersonController>.Instance.LookAtDirection(LookDirection.North, true);
				Singleton<FirstPersonController>.Instance.GetComponentInChildren<ViewManager>().enabled = true;
				Singleton<FirstPersonController>.Instance.GetComponentInChildren<ViewController>().enabled = true;
				Singleton<FirstPersonController>.Instance.GetComponentInChildren<ViewManager>().SwitchToView(View.Choices, false, false);
				Tween.Position(GameObject.Find("GameTable").transform, new Vector3(Singleton<FirstPersonController>.Instance.currentZone.transform.position.x, 9.72f, Singleton<FirstPersonController>.Instance.currentZone.transform.position.z), 0.1f, 0.1f, null, Tween.LoopType.None, null, null, true);
				instance.StartCoroutine(instance.TransitionTo(GameState.SpecialCardSequence, triggeringNodeData2, true, true));
				NavigationZone3D currentZone2 = Singleton<FirstPersonController>.Instance.currentZone;
				string name2 = currentZone2.name;
				if (GameObject.Find(name2).transform.Find("nodeIcon") != null)
				{
					GameObject.Find(name2).transform.Find("nodeIcon").transform.position = new Vector3(0f, -900f, 0f);
				}
				GameObject.Find("Player").transform.position = new Vector3(Singleton<FirstPersonController>.Instance.currentZone.transform.position.x, 2f, Singleton<FirstPersonController>.Instance.currentZone.transform.position.z);
			};

			shop.triggerOnEnter = true;
			shop.triggerOnLook = false;
			shop.eventToTrigger = delegate ()
			{
				MagNodes.CustomNode2 triggeringNodeData2 = new MagNodes.CustomNode2();
				Generation.lastView = GameObject.Find("Player").GetComponent<FirstPersonController>().LookDirection;
				if (!config.isometricMode) { Singleton<FirstPersonController>.Instance.LookAtDirection(LookDirection.North); }
				Singleton<FirstPersonController>.Instance.enabled = false;
				Singleton<FirstPersonController>.Instance.GetComponentInChildren<ViewManager>().enabled = true;
				Singleton<FirstPersonController>.Instance.GetComponentInChildren<ViewController>().enabled = true;
				Singleton<FirstPersonController>.Instance.GetComponentInChildren<ViewManager>().SwitchToView(View.Choices, false, false);
				Tween.Position(GameObject.Find("GameTable").transform, new Vector3(Singleton<FirstPersonController>.Instance.currentZone.transform.position.x, 9.72f, Singleton<FirstPersonController>.Instance.currentZone.transform.position.z), 0.1f, 0.1f, null, Tween.LoopType.None, null, null, true);
				instance.StartCoroutine(instance.TransitionTo(GameState.SpecialCardSequence, triggeringNodeData2, true, true));
				NavigationZone3D currentZone2 = Singleton<FirstPersonController>.Instance.currentZone;
				string name2 = currentZone2.name;
				if (GameObject.Find(name2).transform.Find("nodeIcon") != null)
				{
					GameObject.Find(name2).transform.Find("nodeIcon").transform.position = new Vector3(0f, -900f, 0f);
				}
				GameObject.Find("Player").transform.position = new Vector3(Singleton<FirstPersonController>.Instance.currentZone.transform.position.x, 2f, Singleton<FirstPersonController>.Instance.currentZone.transform.position.z);
				Tween.Rotation(GameObject.Find("Player").transform, Quaternion.Euler(0, 0, 0), 0.25f, 1);
			};

			Generation.cardSelect.triggerOnEnter = true;
			Generation.cardSelect.eventToTrigger = delegate ()
			{
				setupNodeStuff(instance);

				CardChoicesNodeData cardChoicesNodeData = new CardChoicesNodeData();
				cardChoicesNodeData.choicesType = CardChoicesType.Random;
				instance.StartCoroutine(instance.TransitionTo(GameState.SpecialCardSequence, cardChoicesNodeData, true, true));
			};

			Generation.costSelect.triggerOnEnter = true;
			Generation.costSelect.eventToTrigger = delegate ()
			{
				setupNodeStuff(instance);

				CardChoicesNodeData cardChoicesNodeData = new CardChoicesNodeData();
				cardChoicesNodeData.choicesType = CardChoicesType.Cost;
				instance.StartCoroutine(instance.TransitionTo(GameState.SpecialCardSequence, cardChoicesNodeData, true, true));

			};

			Generation.spellSelect.triggerOnEnter = true;
			Generation.spellSelect.eventToTrigger = delegate ()
			{
				setupNodeStuff(instance);

				MagNodes.SpellCardChoice triggeringData = new MagNodes.SpellCardChoice();
				instance.StartCoroutine(instance.TransitionTo(GameState.SpecialCardSequence, triggeringData, true, true));
			};

			Generation.drafting.triggerOnEnter = true;
			Generation.drafting.eventToTrigger = delegate ()
			{
				setupNodeStuff(instance);

				TradePeltsNodeData triggeringNodeData2 = new TradePeltsNodeData();
				instance.StartCoroutine(instance.TransitionTo(GameState.SpecialCardSequence, triggeringNodeData2, true, true));
			};

			Generation.bleach.triggerOnEnter = true;
			Generation.bleach.eventToTrigger = delegate ()
			{
				setupNodeStuff(instance);

				MagNodes.CustomNode3 triggeringNodeData2 = new MagNodes.CustomNode3();
				instance.StartCoroutine(instance.TransitionTo(GameState.SpecialCardSequence, triggeringNodeData2, true, true));
			};

			Generation.costChange.triggerOnEnter = true;
			Generation.costChange.eventToTrigger = delegate ()
			{
				setupNodeStuff(instance);

				MagNodes.CustomNode1 triggeringNodeData2 = new MagNodes.CustomNode1();
				instance.StartCoroutine(instance.TransitionTo(GameState.SpecialCardSequence, triggeringNodeData2, true, true));
			};


			Generation.enchant.triggerOnEnter = true;
			Generation.enchant.eventToTrigger = delegate ()
			{
				setupNodeStuff(instance);

				MagNodes.CustomNode14 triggeringNodeData2 = new MagNodes.CustomNode14();
				instance.StartCoroutine(instance.TransitionTo(GameState.SpecialCardSequence, triggeringNodeData2, true, true));
			};

			Generation.mergeCard.triggerOnEnter = true;
			Generation.mergeCard.eventToTrigger = delegate ()
			{
				setupNodeStuff(instance);

				MagNodes.MergeNode triggeringNodeData2 = new MagNodes.MergeNode();
				instance.StartCoroutine(instance.TransitionTo(GameState.SpecialCardSequence, triggeringNodeData2, true, true));
			};

			Generation.copyCard.triggerOnEnter = true;
			Generation.copyCard.eventToTrigger = delegate ()
			{
				setupNodeStuff(instance, true);

				MagNodes.CopyNode triggeringNodeData2 = new MagNodes.CopyNode();
				instance.StartCoroutine(instance.TransitionTo(GameState.SpecialCardSequence, triggeringNodeData2, true, true));
			};

			Generation.cardPainting.triggerOnEnter = true;
			Generation.cardPainting.eventToTrigger = delegate ()
			{
				setupNodeStuff(instance, true);

				MagNodes.PaintingEvent triggeringNodeData2 = new MagNodes.PaintingEvent();
				instance.StartCoroutine(instance.TransitionTo(GameState.SpecialCardSequence, triggeringNodeData2, true, true));
			};

			Generation.spellUpgrade.triggerOnEnter = true;
			Generation.spellUpgrade.eventToTrigger = delegate ()
			{
				setupNodeStuff(instance, true);

				MagNodes.UpgradeSpellNode triggeringNodeData2 = new MagNodes.UpgradeSpellNode();
				instance.StartCoroutine(instance.TransitionTo(GameState.SpecialCardSequence, triggeringNodeData2, true, true));
			};

			Generation.cauldronEvent.triggerOnEnter = true;
			Generation.cauldronEvent.eventToTrigger = delegate ()
			{
				setupNodeStuff(instance, true);

				MagNodes.Cauldron triggeringNodeData2 = new MagNodes.Cauldron();
				instance.StartCoroutine(instance.TransitionTo(GameState.SpecialCardSequence, triggeringNodeData2, true, true));
			};

			Generation.cardBattle.triggerOnEnter = true;
			Generation.cardBattle.eventToTrigger = delegate ()
			{
				if (GameObject.Find("GameTable").transform.position.y < 1)
				{
          GameObject.Find("NavigationGrid").transform.position = Vector3.up * -50;
          
          for (int i = 0; i < GameObject.Find("scenery").transform.childCount; i++) {
            GameObject.Find("scenery").transform.GetChild(i).gameObject.SetActive(GameObject.Find("scenery").transform.GetChild(i).name == "lights");
          }

          //	GameObject.Find("GameEnvironment").transform.Find("battleRoom").gameObject.SetActive(true);
					//GameObject.Find("GameEnvironment").transform.Find("battleRoom").position = new Vector3(GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().currentZone.transform.position.x - 60, 0, GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().currentZone.transform.position.z + 100);
					if (RunState.Run.regionTier == 0)
					{
						GameObject.Find("roof").SetActive(false);
						GameObject.Find("floor").SetActive(false);
						GameObject.Find("towerWall3(Clone)").SetActive(false);
					}
					else if (RunState.Run.regionTier == 2)
					{
						Singleton<FirstPersonController>.Instance.GetComponentInChildren<Camera>().farClipPlane = 150f;
						GameObject.Find("deckLight").GetComponent<Light>().intensity = 1.5f;
						GameObject.Find("deckLight").transform.parent.gameObject.GetComponent<Light>().intensity = 1.5f;
					}
					else if (RunState.Run.regionTier == 1)
					{
						Singleton<FirstPersonController>.Instance.GetComponentInChildren<Camera>().farClipPlane = 150f;
					}

					Generation.lastView = GameObject.Find("Player").GetComponent<FirstPersonController>().LookDirection;
					GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().LookAtDirection(LookDirection.North, true);

					CardBattleNodeData cardBattleNodeData = new CardBattleNodeData();
					//EncounterBlueprintData blueprint = list3[SeededRandom.Range(0, list3.Count, SaveManager.saveFile.GetCurrentRandomSeed())];
					BoardManager3D boardManager3D = GameObject.FindObjectOfType<BoardManager3D>();

					List<List<EncounterBlueprintData>> blueprintData = new List<List<EncounterBlueprintData>>(Blueprints.blueprintData);
					if (RunState.Run.regionTier > 0)
					{
						int tier = RunState.Run.regionTier - 1;

						blueprintData[tier].RemoveAt(SavedVars.LastBlueprint);
						int blueprintIdx = SeededRandom.Range(0, blueprintData[tier].Count, SaveManager.saveFile.GetCurrentRandomSeed());
						SavedVars.LastBlueprint = blueprintIdx;

						EncounterBlueprintData blueprint = blueprintData[tier][blueprintIdx];
						cardBattleNodeData.blueprint = blueprint;
						SaveManager.saveFile.randomSeed++;
					}

					GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().LookAtDirection(LookDirection.North, true);
					GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().enabled = false;
					GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().LookAtDirection(LookDirection.North, true);
					GameObject.Find("Player").GetComponentInChildren<ViewManager>().enabled = true;
					GameObject.Find("Player").GetComponentInChildren<ViewController>().enabled = true;
					GameObject.Find("Player").transform.Find("Directional Light").gameObject.SetActive(false);
					GameObject.Find("GameTable").transform.position = new Vector3(GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().currentZone.transform.position.x, 9.72f, GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().currentZone.transform.position.z);
					GameObject.Find("tbPillar").transform.position = new Vector3(GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().currentZone.transform.position.x, 9.72f - 6.83f, GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().currentZone.transform.position.z + 6.5f);

					if (!instance.cardbattleParent.activeSelf)
						instance.cardbattleParent.SetActive(true);

					/*
					foreach (GameObject item in kanyeWest)
					{
						item.transform.position = new Vector3(GameObject.Find("tbPillar").transform.position.x, -20f, GameObject.Find("tbPillar").transform.position.z);
					}*/
					//Tween.LocalPosition(GameObject.Find("Hand").transform, new Vector3(4.3555f, -11.0099f, 2.0401f), 0f, 0f);
					GameObject.Find("Player").GetComponentInChildren<ViewManager>().SwitchToView(View.Default, true, false);
					Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(Singleton<MagnificusGameFlowManager>.Instance.TransitionTo(GameState.CardBattle, cardBattleNodeData, true, true));
					List<string> wizardOpponents = new List<string>
						{
							"Wizard3DPortrait_JuniorSage",
							"Wizard3DPortrait_OrangeMage",
							"Wizard3DPortrait_BlueMage",
							"Wizard3DPortrait_RubyGolem"
						};
					if (RunState.Run.regionTier != 0)
					{
						int index = UnityEngine.Random.Range(0, wizardOpponents.Count);
						try
						{
							GameObject.Find(wizardOpponents[index]).transform.position = new Vector3(GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().currentZone.transform.position.x, 9.72f, GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().currentZone.transform.position.z + 16);
						}
						catch
						{
							GameObject.Instantiate(Resources.Load("Prefabs/finalemagnificus/" + wizardOpponents[index])).name = wizardOpponents[index];
							GameObject.Find(wizardOpponents[index]).transform.position = new Vector3(GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().currentZone.transform.position.x, 9.72f, GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().currentZone.transform.position.z + 16);
							GameObject.Find(wizardOpponents[index]).transform.Find("Anim").gameObject.SetActive(true);
							GameObject.Find(wizardOpponents[index]).transform.parent = GameObject.Find("GameTable").transform;
						}


						foreach (string wizard in wizardOpponents)
						{
							if (wizard == wizardOpponents[index]) continue;
							try
							{
								if (GameObject.Find("GameTable").transform.Find(wizard) != null)
									GameObject.Find("GameTable").transform.Find(wizard).position = new Vector3(0f, -20f, 0f);
							}
                            catch { }
						}
						GameObject.Find(wizardOpponents[index]).transform.position = new Vector3(GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().currentZone.transform.position.x, 9.72f, GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().currentZone.transform.position.z + 16);
					}

					NavigationZone3D currentZone2 = GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().currentZone;
					string name2 = currentZone2.name;
					if (GameObject.Find(name2).transform.Find("nodeIcon") != null)
					{
						nodes.Remove(GameObject.Find(name2).transform.Find("nodeIcon").gameObject);
						GameObject.Destroy(GameObject.Find(name2).transform.Find("nodeIcon").gameObject);
					}
					else if (GameObject.Find(name2).transform.childCount > 0 && GameObject.Find(name2).transform.GetChild(0).gameObject.name.Contains("nodeIconBL"))
					{
						string theSplit = GameObject.Find(name2).transform.GetChild(0).gameObject.name.Split(';')[0];
						for (int i = 1; i < 9; i++)
						{
							try
							{
								if (GameObject.Find(theSplit + ";N" + i) != null)
								{
									nodes.Remove(GameObject.Find(theSplit + ";N" + i));
									GameObject.Find(theSplit + ";N" + i).transform.position = new Vector3(0, -900, 0);
								}
							}
							catch { }
						}
					}

					Singleton<ViewController>.Instance.SwitchToControlMode(ViewController.ControlMode.WizardBattleDefault);
					Singleton<ViewManager>.Instance.SwitchToView(View.Default);
					instance.duelDiskParent.SetActive(true);
					GameObject.Find("hammerStuff").transform.parent = instance.duelDiskParent.transform;
					GameObject.Find("hammerStuff").transform.localPosition = new Vector3(3.74f, 0.5f, 5.1599f);
					GameObject.Find("hammerStuff").SetActive(false);
					instance.StartCoroutine(startHammer());
					instance.playerHand.SetActive(true);
					instance.combatBell.transform.Find("Anim").localPosition = new Vector3(0, 0, 0);
					GameObject.Find("Hand").transform.Find("Anim").Find("HandModel_Female").localPosition = new Vector3(4.349f, -11.0045f, 2.0401f);
					GameObject.Find("Hand").transform.Find("Anim").Find("HandModel_Male").localPosition = new Vector3(4.349f, -11.0045f, 2.5801f);
					instance.combatBell.transform.localPosition = new Vector3(-7.64f, 9.75f, 6.42f);
					instance.combatBell.transform.Find("Anim").gameObject.SetActive(true);
					instance.combatBell.gameObject.SetActive(true);
					instance.combatBell.SetBesideBoard(false, false);

					Singleton<MagnificusDuelDisk>.Instance.basePosition = new Vector3(0.89f, 4.2424f, -2.8576f);
					instance.duelDiskParent.transform.localPosition = new Vector3(0.89f, 4.2424f, -2.8576f);
					instance.playerHand.transform.localPosition = new Vector3(1.42f, 3.12f, -5.47f);
					GameObject.Find("3DPortraitSlots").transform.localPosition = new Vector3(0, 3.62f, 4.14f);
					GameObject.Find("3DPortraitSlots").transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
					Singleton<ViewManager>.Instance.SwitchToView(View.WizardBattleSlots, false, false);
					instance.cardbattleParent.gameObject.transform.Find("Part1Scales").gameObject.SetActive(true);
					Singleton<MagnificusCardDrawPiles>.Instance.Awake();

					Tween.Rotation(GameObject.Find("Player").transform, Quaternion.Euler(0, 0, 0), 0.25f, 1);
					Tween.LocalPosition(GameObject.Find("tbPillar").transform, new Vector3(0, -6.83f, 6.5f), 0.25f, 1);

          GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
          obj.transform.parent = GameObject.Find("GameTable").transform;
          obj.name = "battlebg";
          MeshFilter meshCollider = obj.GetComponent<MeshFilter>();

          var mesh = meshCollider.mesh;
          mesh.triangles = mesh.triangles.Reverse().ToArray();
          mesh.normals = mesh.normals.Select(n => -n).ToArray();

          obj.GetComponent<MeshRenderer>().material.mainTexture = Tools.getImage("stars.png");
					obj.GetComponent<MeshRenderer>().material.shaderKeywords = new string[0];
          obj.GetComponent<MeshRenderer>().material.mainTextureScale = new Vector2(4, 4);
					obj.gameObject.AddComponent<UVScroller>();
					obj.GetComponent<UVScroller>().XscrollSpeed = 0.005f;
          obj.GetComponent<UVScroller>().YscrollSpeed = 0.0001f;
					obj.transform.localPosition = new Vector3(0f, 0f, 7f);
					obj.transform.localScale =  Vector3.one * 500;

          Tween.LocalScale(obj.transform,  new Vector3(107, 100, 100), 2.5f, 0f, Tween.EaseIn);
          Tween.LocalPosition(GameObject.Find("walls").transform, new Vector3(0, -45f, 9), 5f, 0f, Tween.EaseOut);
				}
			};

			Generation.gooBattle.triggerOnEnter = true;
			Generation.gooBattle.eventToTrigger = delegate ()
			{
				if (GameObject.Find("GameTable").transform.position.y < 1)
				{
					setupBattle(instance, true);

					BossBattleNodeData bossBattleNodeData = new BossBattleNodeData();
					bossBattleNodeData.specialBattleId = "GoobertSequencer";
					if (SaveManager.saveFile.ascensionActive && challenges.Contains("MasterBosses"))
					{
						bossBattleNodeData.specialBattleId = "GoranjSequencer";
					}

					instance.StartCoroutine(instance.TransitionTo(GameState.CardBattle, bossBattleNodeData, true, true));


					GameObject gooOrbSpawner = GameObject.Instantiate(Resources.Load("prefabs/factoryindoors/gooplane3d/GooOrbSpawner") as GameObject);
					gooOrbSpawner.transform.parent = GameObject.Find("GameTable").transform;
					gooOrbSpawner.transform.localPosition = new Vector3(-16.25f, 0f, 9.5f);
					gooOrbSpawner.GetComponent<GooOrbSpawner>().frequency = 1.5f;
					gooOrbSpawner.GetComponent<GooOrbSpawner>().originalFrequency = 1.5f;
					gooOrbSpawner.GetComponent<GooOrbSpawner>().orbScale = 1f;
					gooOrbSpawner.name = "gooOrbSpawner1";

					GameObject gooOrbSpawner2 = GameObject.Instantiate(gooOrbSpawner);
					gooOrbSpawner2.transform.parent = GameObject.Find("GameTable").transform;
					gooOrbSpawner2.transform.localPosition = new Vector3(16.25f, 0f, 9.5f);
					gooOrbSpawner2.name = "gooOrbSpawner2";

					GameObject.Find("bgStarParent").transform.localRotation = Quaternion.Euler(0, 0, 0);
					Tween.Rotation(GameObject.Find("Player").transform, Quaternion.Euler(0, 0, 0), 0.25f, 1);
					Tween.LocalPosition(GameObject.Find("walls").transform, new Vector3(0, -31, 9), 5f, 10f);
					float height = config.isometricMode ? -30f : -43;
					Tween.LocalPosition(GameObject.Find("bgStarParent").transform, new Vector3(0, height, 0), 5f, 10f);
					Tween.LocalPosition(GameObject.Find("walls").transform, new Vector3(0, -255, 9), 0.25f, 15f);
				}
			};

			Generation.pikeBattle.triggerOnEnter = true;
			Generation.pikeBattle.eventToTrigger = delegate ()
			{
				if (GameObject.Find("GameTable").transform.position.y < 1)
				{
					setupBattle(instance, true);

					BossBattleNodeData bossBattleNodeData = new BossBattleNodeData();
					bossBattleNodeData.specialBattleId = "EspeararaSequencer";
					if (SaveManager.saveFile.ascensionActive && challenges.Contains("MasterBosses"))
					{
						bossBattleNodeData.specialBattleId = "OrluSequencer";
					}

					instance.StartCoroutine(instance.TransitionTo(GameState.CardBattle, bossBattleNodeData, true, true));

					if (!challenges.Contains("MasterBosses"))
					{
						GameObject lavaOrbSpawner = GameObject.Instantiate(Resources.Load("prefabs/factoryindoors/gooplane3d/GooOrbSpawner") as GameObject);
						lavaOrbSpawner.transform.parent = GameObject.Find("GameTable").transform;
						lavaOrbSpawner.transform.localPosition = new Vector3(0, 2.18f, 43.32f);
						lavaOrbSpawner.GetComponent<GooOrbSpawner>().enabled = false;
						lavaOrbSpawner.AddComponent<LavaOrbSpawner>();
						lavaOrbSpawner.GetComponent<LavaOrbSpawner>().frequency = 1.5f;
						lavaOrbSpawner.GetComponent<LavaOrbSpawner>().originalFrequency = 1.5f;
						lavaOrbSpawner.GetComponent<LavaOrbSpawner>().orbScale = 1f;
						lavaOrbSpawner.name = "lavaOrbSpawner1";
					}

					Tween.Rotation(GameObject.Find("Player").transform, Quaternion.Euler(0, 0, 0), 0.25f, 1);
					Tween.LocalPosition(GameObject.Find("walls").transform, new Vector3(0, -33, 9), 5f, 10f);
					Tween.LocalPosition(GameObject.Find("ceiling").transform, new Vector3(340f, 250f, -600f), 5f, 10f);
					Tween.LocalPosition(GameObject.Find("walls").transform, new Vector3(0, -255, 9), 0.25f, 15f);
				}
			};

			Generation.stimBattle.triggerOnEnter = true;//FOR LONELY MAGE, DISABLE THE TBPILLAR SHADOW
			Generation.stimBattle.eventToTrigger = delegate ()
			{
				if (GameObject.Find("GameTable").transform.position.y < 1)
				{
					setupBattle(instance, true);

					BossBattleNodeData bossBattleNodeData = new BossBattleNodeData();
					bossBattleNodeData.specialBattleId = "LonelyMageSequencer";
					if (SaveManager.saveFile.ascensionActive && challenges.Contains("MasterBosses"))
					{
						bossBattleNodeData.specialBattleId = "BleeneSequencer";
					}

					instance.StartCoroutine(instance.TransitionTo(GameState.CardBattle, bossBattleNodeData, true, true));

					GameObject.Find("tbPillar").transform.Find("Shadow").gameObject.SetActive(false);
					GameObject.Find("floorLight").SetActive(false);

					Tween.Rotation(GameObject.Find("Player").transform, Quaternion.Euler(0, 0, 0), 0.25f, 1);
					Tween.LocalPosition(GameObject.Find("walls").transform, new Vector3(0, -900, 9), 0f, 0f);

				}
			};


			Generation.magBattle.triggerOnEnter = true;
			Generation.magBattle.eventToTrigger = delegate ()
			{
				if (GameObject.Find("GameTable").transform.position.y < 1)
				{
					Generation.lastView = GameObject.Find("Player").GetComponent<FirstPersonController>().LookDirection;
					GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().LookAtDirection(LookDirection.North, true);
					SaveManager.saveFile.randomSeed += 9;

					GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().LookAtDirection(LookDirection.North, true);
					GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().enabled = false;
					GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().LookAtDirection(LookDirection.North, true);
					GameObject.Find("Player").GetComponentInChildren<ViewManager>().enabled = true;
					GameObject.Find("Player").GetComponentInChildren<ViewController>().enabled = true;

					instance.StartCoroutine(FinalBossTime());

				}
			};


			Generation.bleachBattle.triggerOnEnter = true;
			Generation.bleachBattle.eventToTrigger = delegate ()
			{
				if (GameObject.Find("GameTable").transform.position.y < 1)
				{
					setupBattle(instance);

					BossBattleNodeData bossBattleNodeData = new BossBattleNodeData();
					bossBattleNodeData.specialBattleId = "BleachBattleSequencer";

					instance.StartCoroutine(instance.TransitionTo(GameState.CardBattle, bossBattleNodeData, true, true));
				}
			};

			Generation.deathCard.triggerOnEnter = true;
			Generation.deathCard.eventToTrigger = delegate ()
			{
				instance.StartCoroutine(deathCardEvent());
			};
			instance.combatBell.gameObject.GetComponent<SphereCollider>().radius = 3;

			GameObject.Find("FinaleDeletionCanvas").SetActive(false);

			cardBattle.triggerOnLook = false;

			towerWarp.triggerOnEnter = true;
			towerWarp.eventToTrigger = delegate ()
			{
				if (Singleton<FirstPersonController>.Instance.LookDirection == LookDirection.North)
				{
					instance.StartCoroutine(transition("goobert", "spin"));
				}
			};

			towerWarpTwo.triggerOnEnter = true;
			towerWarpTwo.eventToTrigger = delegate ()
			{
				if (Singleton<FirstPersonController>.Instance.LookDirection == LookDirection.North)
				{
					instance.StartCoroutine(transition("espeara", "spin"));
				}
			};

			towerWarpThree.triggerOnEnter = true;
			towerWarpThree.eventToTrigger = delegate ()
			{
				if (Singleton<FirstPersonController>.Instance.LookDirection == LookDirection.North)
				{
					instance.StartCoroutine(transition("lonely", "spin"));
				}
			};

			finalWarp.triggerOnEnter = true;
			finalWarp.eventToTrigger = delegate ()
			{
				instance.StartCoroutine(magnificusPreFinalDialogue());
			};

			edaxioTrapdoor.triggerOnEnter = true;
			edaxioTrapdoor.eventToTrigger = delegate ()
			{
				bool hasEdaxio = false;
				foreach (CardInfo card in RunState.Run.playerDeck.Cards)
				{
					if (RunState.Run.regionTier == 1 && card.name == "mag_edaxiolegs" || RunState.Run.regionTier == 2 && card.name == "mag_edaxiotorso" || RunState.Run.regionTier == 3 && card.name == "mag_edaxioarms")
					{
						hasEdaxio = true;
					}
				}
				if (!hasEdaxio)
				{
					string nodeName = Singleton<FirstPersonController>.Instance.currentZone.gameObject.name;
					string[] x1 = nodeName.Split('x');
					string[] x2 = x1[1].Split(' ');
					int x = int.Parse(x2[0]);
					string[] y = x2[1].Split('y');
					x += 18;
					instance.StartCoroutine(warp("x" + x + " y" + y[1], "blackout"));
				}
			};

			leshyCardDialogue.triggerOnEnter = true;
			leshyCardDialogue.eventToTrigger = delegate ()
			{
				Singleton<FirstPersonController>.Instance.currentZone.events.Clear();
				instance.StartCoroutine(leshyDialogue());
			};

			pedestalGuide.triggerOnEnter = true;
			pedestalGuide.eventToTrigger = delegate ()
			{
				Singleton<FirstPersonController>.Instance.currentZone.events.Clear();
				instance.StartCoroutine(pedestalDialogue());
			};

			gameOver.triggerOnEnter = true;
			gameOver.eventToTrigger = delegate ()
			{
				Singleton<FirstPersonController>.Instance.LookAtDirection(LookDirection.North);
				Singleton<FirstPersonController>.Instance.enabled = false;
				instance.StartCoroutine(gameoversequence());
			};

			mirrorClose.triggerOnEnter = true;
			mirrorClose.eventToTrigger = delegate ()
			{
				GameObject reflection = GameObject.Find("reflection");
				Vector3 pos = reflection.transform.position;
				reflection.transform.position = new Vector3(pos.x, -1.5f, pos.z);
				float mirrorPos = GameObject.Find("mirror").transform.position.x;
				float reflectionPos = Singleton<FirstPersonController>.Instance.currentZone.gameObject.transform.position.x;
				reflectionPos -= mirrorPos;
				reflectionPos = -reflectionPos;
				pos.x = mirrorPos + reflectionPos;
				pos.x -= 20;
				pos.z = Singleton<FirstPersonController>.Instance.currentZone.gameObject.transform.position.z;
				pos.y = -1.5f;
				if (config.isometricActive) { instance.StartCoroutine(reflectionRotate(reflection)); } else { reflection.transform.rotation = Quaternion.Euler(0, 270, 0); }
				Tween.Position(reflection.transform, pos, 0.25f, 0);
			};
			mirrorExit.triggerOnEnter = true;
			mirrorExit.eventToTrigger = delegate ()
			{
				GameObject reflection = GameObject.Find("reflection");
				Vector3 pos = reflection.transform.position;
				float mirrorPos = GameObject.Find("mirror").transform.position.x;
				float reflectionPos = Singleton<FirstPersonController>.Instance.currentZone.gameObject.transform.position.x;
				reflectionPos -= mirrorPos;
				reflectionPos = -reflectionPos;
				pos.x = mirrorPos + reflectionPos;
				pos.x -= 20;
				pos.z = Singleton<FirstPersonController>.Instance.currentZone.gameObject.transform.position.z;
				if (config.isometricActive) { instance.StartCoroutine(reflectionRotate(reflection)); } else { reflection.transform.rotation = Quaternion.Euler(0, 270, 0); }
				Tween.Position(reflection.transform, pos, 0.25f, 0);
				if (config.isometricActive)
				{
					pos.y = -25;
					Tween.Position(reflection.transform, pos, 0.01f, 0.25f);
				}
			};

			mirrorIn.triggerOnEnter = true;
			mirrorIn.eventToTrigger = delegate ()
			{
				string nodeName = GameObject.Find("mirrorFrame").transform.parent.gameObject.name;
				string[] x1 = nodeName.Split('x');
				string[] x2 = x1[1].Split(' ');
				int x = int.Parse(x2[0]);
				string[] y = x2[1].Split('y');
				x -= 1;
				if (config.isometricActive) { Tween.LocalRotation(GameObject.Find("reflection").transform, Quaternion.Euler(0, 270, 0), 0.15f, 0); }
				instance.StartCoroutine(warp("x" + x + " y" + y[1], "spin"));
			};

			getMonocle.triggerOnEnter = true;
			getMonocle.eventToTrigger = delegate ()
			{
				instance.StartCoroutine(getMonocleSequence());
			};

			dummyFight.triggerOnEnter = true;
			dummyFight.eventToTrigger = delegate ()
			{
				if (Singleton<FirstPersonController>.Instance.LookDirection == LookDirection.North)
				{
					instance.StartCoroutine(dummyFightSequence());
				}
				else
				{
					//270.9999 180 180
					GameObject.Find("x4 y1 dummy").transform.localRotation = Quaternion.Euler(270.9999f, 180f, 180);
					Tween.LocalRotation(GameObject.Find("x4 y1 dummy").transform, Quaternion.Euler(290, 180, 180), 0.1f, 0);
					Tween.LocalRotation(GameObject.Find("x4 y1 dummy").transform, Quaternion.Euler(270.9999f, 180f, 180), 0.2f, 0.1f);
				}
			};


		}

		public void setupBattleStuff()
        {
			GameObject.Instantiate(Resources.Load("prefabs/items/ItemsManager_Part3")).name = "hammerStuff";
			Singleton<Part3ItemsManager>.Instance.hammerSlot.InitializeHammer();
			GameObject.Find("hammerStuff").AddComponent<SineWaveMovement>();
			GameObject.Find("hammerStuff").GetComponent<SineWaveMovement>().enabled = false;
			/*


			GameObject.Instantiate(Resources.Load("prefabs/finalemagnificus/CombatBell_Magnificus")).name = "BigBen";
			GameObject.Find("BigBen").transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);//sorry
			GameObject.Find("BigBen").transform.parent = GameObject.Find("CombatBell").transform.Find("Anim").Find("Model");
			GameObject.Find("CombatBell").gameObject.GetComponent<SphereCollider>().enabled = false;
			GameObject.Find("CombatBell").gameObject.GetComponent<CombatBell3D>().enabled = false;
			GameObject.Find("BigBen").gameObject.GetComponent<SphereCollider>().center = new Vector3(0f, -2.5f, 0f);
			GameObject.Find("CombatBell").transform.Find("Anim").Find("Model").Find("BellFin").gameObject.SetActive(false);
			GameObject.Find("BigBen").transform.localPosition = new Vector3(0f, 0f, 0f);
			GameObject.Find("BigBen").GetComponent<SphereCollider>().radius = 2.3f;
			GameObject.Find("CombatBell").transform.Find("Anim").transform.localPosition = new Vector3(0f, 2.08f, 0f);
			GameObject.Find("CombatBell").transform.Find("Anim").Find("Shadow").gameObject.GetComponent<MeshRenderer>().enabled = false;
			*/

			for (int i = 0; i < GameObject.Find("CardBattle_Magnificus").transform.Find("3DPortraitSlots").Find("OpponentSlots").transform.childCount; i++)
			{
				GameObject portrait = GameObject.Find("CardBattle_Magnificus").transform.Find("3DPortraitSlots").Find("OpponentSlots").GetChild(i).GetChild(3).gameObject;
				for (int j = 0; j < portrait.transform.GetChild(0).GetChild(0).GetChild(1).childCount; j++)
				{
					portrait.transform.GetChild(0).GetChild(0).GetChild(1).GetChild(j).gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
				}
				portrait.transform.GetChild(0).GetChild(0).GetChild(1).Find("canvas_low").gameObject.GetComponent<MeshRenderer>().material.mainTexture = Tools.getImage("LargeFrame_albedo.png");
			}

			if (SavedVars.LearnedMechanics.Contains("liferace;") || SaveManager.saveFile.ascensionActive)
				Singleton<MagnificusGameFlowManager>.Instance.duelDiskParent.gameObject.transform.Find("Anim").gameObject.GetComponent<Animator>().speed = 999;


			for (int i = 0; i < 4; i++)
			{
				float xOffset = 2.1f * i;
				Singleton<MagnificusGameFlowManager>.Instance.duelDiskParent.transform.Find("BoardManager").Find("OpponentSlots").GetChild(i).localPosition = new Vector3(-4f + xOffset, -23.2f, -1990);
				Singleton<MagnificusGameFlowManager>.Instance.duelDiskParent.transform.Find("BoardManager").Find("OpponentSlots").GetChild(i).gameObject.GetComponent<BoxCollider>().size = new Vector3(1.4f, 1f, 2.1f);
			}//-0.1 0 2001

			slotTextures[0] = Tools.getImage("unselectedslot.png");
			slotTextures[1] = (Resources.Load("art/cards/card_slot_wizard_ground") as Texture2D);
			slotTextures[2] = Tools.getImage("1atkslot.png");
			slotTextures[3] = Tools.getImage("1atkslot_select.png");
			slotTextures[4] = Tools.getImage("2hpslot.png");
			slotTextures[5] = Tools.getImage("2hpslot_select.png");

			for (int i = 0; i < 4; i++)
			{
				GameObject.Find("PlayerSlots").transform.GetChild(i).Find("Border").gameObject.GetComponent<MeshRenderer>().material.mainTexture = slotTextures[0];
				GameObject.Find("PlayerSlots").transform.GetChild(i).Find("Border").gameObject.GetComponent<MeshRenderer>().material.name = "0;1";
				GameObject.Find("OpponentSlots").transform.GetChild(i).Find("Border").gameObject.GetComponent<MeshRenderer>().material.mainTexture = slotTextures[0];
				GameObject.Find("OpponentSlots").transform.GetChild(i).Find("Border").gameObject.GetComponent<MeshRenderer>().material.name = "0;1";
				GameObject.Find("OpponentSlots").transform.GetChild(i).Find("QueuedCardFrame").localPosition = new Vector3(0.03f, 7.02f, 7.5f);
			}//-0.1 0 2001

			Singleton<MagnificusGameFlowManager>.Instance.duelDiskParent.transform.Find("BoardManager").Find("OpponentSlots").localPosition = new Vector3(-0.1f, 0, 2001);


			//mana

			WeightUtil.part1Prefab = ResourceBank.Get<GameObject>("Prefabs/Environment/ScaleWeights/Weight");

			GameObject.Instantiate(Resources.Load("prefabs/finalemagnificus/Wizard3DPortrait_MoxRuby")).name = "rox";
			GameObject gameObject3 = GameObject.Find("rox").transform.Find("SineWaveMove").Find("Anim").Find("Gem").gameObject;
			gameObject3.transform.parent = GameObject.Find("MagnificusEnvironment").transform;
			GameObject.Destroy(GameObject.Find("rox"));
			gameObject3.GetComponent<MeshRenderer>().material.mainTexture = Tools.getImage("mana.png");
			gameObject3.transform.position = new Vector3(0f, -85f, 0f);
			gameObject3.name = "mana";
			WeightUtil.part1Prefab.gameObject.GetComponent<MeshFilter>().mesh = gameObject3.gameObject.GetComponent<MeshFilter>().mesh;
			WeightUtil.part1Prefab.gameObject.GetComponent<MeshRenderer>().material = gameObject3.GetComponent<MeshRenderer>().material;
			WeightUtil.part1Prefab.gameObject.GetComponent<BoxCollider>().size = new Vector3(0.3f, 0.3f, 0.3f);
			WeightUtil.part1Prefab.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

		}
	}
}
