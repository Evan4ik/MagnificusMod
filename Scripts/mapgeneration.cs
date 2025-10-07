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

namespace MagnificusMod
{


	public class Generation
	{ 

		public static LookDirection lastView = LookDirection.North;

		public static bool allcardssummoned = false;
		public static int damageDoneThisTurn = 0;//ughhh

		public static NavigationEvent edaxioNode = new NavigationEvent();

		public static NavigationEvent shop = new NavigationEvent();

		public static NavigationEvent cardBattle = new NavigationEvent();

		public static NavigationEvent drafting = new NavigationEvent();
		public static NavigationEvent bleach = new NavigationEvent();
		public static NavigationEvent costChange = new NavigationEvent();
		public static NavigationEvent enchant = new NavigationEvent();
		public static NavigationEvent spellUpgrade = new NavigationEvent();
		public static NavigationEvent cauldronEvent = new NavigationEvent();
		public static NavigationEvent mergeCard = new NavigationEvent();
		public static NavigationEvent copyCard = new NavigationEvent();
		public static NavigationEvent removeCard = new NavigationEvent();
		public static NavigationEvent cardPainting = new NavigationEvent();

		public static NavigationEvent cardSelect = new NavigationEvent();
		public static NavigationEvent costSelect = new NavigationEvent();
		public static NavigationEvent spellSelect = new NavigationEvent();


		public static NavigationEvent towerWarp = new NavigationEvent();
		public static NavigationEvent towerWarpTwo = new NavigationEvent();
		public static NavigationEvent towerWarpThree = new NavigationEvent();
		public static NavigationEvent finalWarp = new NavigationEvent();

		public static NavigationEvent gameOver = new NavigationEvent();
		public static NavigationEvent edaxioTrapdoor = new NavigationEvent();
		public static NavigationEvent leshyCardDialogue = new NavigationEvent();
		public static NavigationEvent pedestalGuide = new NavigationEvent();
		public static NavigationEvent getMonocle = new NavigationEvent();
		public static NavigationEvent dummyFight = new NavigationEvent();

		public static NavigationEvent mirrorIn = new NavigationEvent();
		public static NavigationEvent mirrorClose = new NavigationEvent();
		public static NavigationEvent mirrorExit = new NavigationEvent();

		public static Texture2D edaxioTex;
		public static Texture2D shopTex;
		public static Texture2D cardTex;
		public static Texture2D costTex;
		public static Texture2D spellTex;
		public static Texture2D battleTex;
		public static Texture2D draftingTex;
		public static Texture2D bleachTex;
		public static Texture2D copyTex;
		public static Texture2D removeTex;
		public static Texture2D paintTex;
		public static Texture2D mergeTex;
		public static Texture2D costchngTex;
		public static Texture2D enchantTex;
		public static Texture2D spellUpgradeTex;
		public static Texture2D cauldronTex;


		public static NavigationEvent bleachBattle = new NavigationEvent();

		public static NavigationEvent gooBattle = new NavigationEvent();
		public static NavigationEvent pikeBattle = new NavigationEvent();
		public static NavigationEvent stimBattle = new NavigationEvent();

		public static List<NavigationEvent> nodeEvents = new List<NavigationEvent> { drafting, bleach, cardBattle, shop, edaxioNode, costChange, enchant, spellUpgrade, cauldronEvent, mergeCard, copyCard, removeCard, cardPainting, cardSelect, costSelect, spellSelect, gooBattle, pikeBattle, stimBattle, bleachBattle };
		public static List<NavigationEvent> transitionnodes = new List<NavigationEvent> { cardBattle, gooBattle, pikeBattle, stimBattle, cauldronEvent, cardPainting, copyCard, spellUpgrade, bleachBattle };


		public static NavigationEvent magBattle = new NavigationEvent();


		public static NavigationEvent deathCard = new NavigationEvent();

		public static Texture2D bleachbattleTex;
		public static Texture2D goobossTex;
		public static Texture2D pikebossTex;
		public static Texture2D stimbossTex;

		public static List<GameObject> nodes = new List<GameObject>();
		public static bool minimap = false;

		public static AssetBundle assetBundle;

		public static List<AudioClip> addedSfx = new List<AudioClip>();
		public static List<AudioClip> voiceClips = new List<AudioClip>();
		public static bool setupSfx = false;

		public static string[] challenges { get; set; }

		public static Sprite[] manaCostTextures = new Sprite[5];

		public static Texture2D[] slotTextures = new Texture2D[6];

		//bundlees

		public static AssetBundle fontmanager;

		public static AssetBundle goober;

		public static AssetBundle pike;

		public static AssetBundle stimothy;

		public static AssetBundle sword;

		public static AssetBundle dummy;

		public static AssetBundle picnic;

		public static AssetBundle espeara;

		public static AssetBundle towerwalls;

		public static AssetBundle cauldron;

		public static AssetBundle tablecloth;

		public static AssetBundle cardframe;
		public static void GetResources()
		{

			
			using (Stream manifestResourceStream = Tools.CurrentAssembly.GetManifestResourceStream("MagnificusMod.Resources.magmodmusic"))
			{
				assetBundle = AssetBundle.LoadFromStream(manifestResourceStream);
				addedSfx = new List<AudioClip>
				{
					assetBundle.LoadAsset<AudioClip>("School_of_Magicks"),
					assetBundle.LoadAsset<AudioClip>("Goo_Mage"),
					assetBundle.LoadAsset<AudioClip>("TheArtOfMagicks"),
					assetBundle.LoadAsset<AudioClip>("Pike_Mage"),
					assetBundle.LoadAsset<AudioClip>("Lonely_Mage")
				};
			}

			using (Stream manifestResourceStream = Tools.CurrentAssembly.GetManifestResourceStream("MagnificusMod.Resources.magvoiceclips"))
			{
				assetBundle = AssetBundle.LoadFromStream(manifestResourceStream);
				voiceClips = new List<AudioClip>
				{
					assetBundle.LoadAsset<AudioClip>("hoo"),
					assetBundle.LoadAsset<AudioClip>("stimmyvoice_calm#1"),
					assetBundle.LoadAsset<AudioClip>("stimmyvoice_calm#2"),
					assetBundle.LoadAsset<AudioClip>("stimmyvoice_calm#3"),
					assetBundle.LoadAsset<AudioClip>("ambervoice_calm#1"),
					assetBundle.LoadAsset<AudioClip>("ambervoice_calm#2"),
					assetBundle.LoadAsset<AudioClip>("ambervoice_calm#3"),
					assetBundle.LoadAsset<AudioClip>("pikespawn"),
				};
			}

			using (var s = Assembly.GetExecutingAssembly().GetManifestResourceStream("MagnificusMod.Resources.maggoobertrise"))
			{
				goober = AssetBundle.LoadFromStream(s);
			}

			using (var s = Assembly.GetExecutingAssembly().GetManifestResourceStream("MagnificusMod.Resources.pike"))
			{
				pike = AssetBundle.LoadFromStream(s);
			}

			using (var s = Assembly.GetExecutingAssembly().GetManifestResourceStream("MagnificusMod.Resources.sword"))
			{
				sword = AssetBundle.LoadFromStream(s);
			}

			using (var s = Assembly.GetExecutingAssembly().GetManifestResourceStream("MagnificusMod.Resources.dummy"))
			{
				dummy = AssetBundle.LoadFromStream(s);
			}

			using (var s = Assembly.GetExecutingAssembly().GetManifestResourceStream("MagnificusMod.Resources.fonts"))
			{
				fontmanager = AssetBundle.LoadFromStream(s);
			}

			using (var s = Assembly.GetExecutingAssembly().GetManifestResourceStream("MagnificusMod.Resources.hubertpicnic"))
			{
				picnic = AssetBundle.LoadFromStream(s);
			}

			using (var s = Assembly.GetExecutingAssembly().GetManifestResourceStream("MagnificusMod.Resources.moxbundle"))
			{
				espeara = AssetBundle.LoadFromStream(s);
			}

			using (var s = Assembly.GetExecutingAssembly().GetManifestResourceStream("MagnificusMod.Resources.stimothy"))
			{
				stimothy = AssetBundle.LoadFromStream(s);
			}

			using (var s = Assembly.GetExecutingAssembly().GetManifestResourceStream("MagnificusMod.Resources.towerwalls"))
			{
				towerwalls = AssetBundle.LoadFromStream(s);
			}

			using (var s = Assembly.GetExecutingAssembly().GetManifestResourceStream("MagnificusMod.Resources.cauldron"))
			{
				cauldron = AssetBundle.LoadFromStream(s);
			}

			using (var s = Assembly.GetExecutingAssembly().GetManifestResourceStream("MagnificusMod.Resources.tablecloth"))
			{
				tablecloth = AssetBundle.LoadFromStream(s);
			}

			using (var s = Assembly.GetExecutingAssembly().GetManifestResourceStream("MagnificusMod.Resources.cardframe"))
			{
				cardframe = AssetBundle.LoadFromStream(s);
			}
		}

		public static string Directory;


		/*/the zoomer guide
		 * example: W0E - Wall, Style 0, rotation: east
		 * P(1-3) - Pillar, Arch-CollumBase-ColumnFull :Glee:
		 * " " - nothin'
		 * "-" - walkable tile
		 * "N1" - first node (trader / card choice)
		 * "E" - event (merge, bleach, etc..)
		 * "C" - card choice node
		 * "B" - card battle
		 * "P" - pillar fight (?) 
		 * "S" - shop
		 * "T(NUM)" - tower pedestal (1-3)
		 * "EX" - exit
		 */

	

		public class conectedNodes : MonoBehaviour
		{
			public int group;
		}

		public static IEnumerator generateMap(List<List<string>> map, bool loading)
		{
			if (SavedVars.GeneratedEvents == null) { SavedVars.GeneratedEvents = ""; SaveManager.SaveToFile(); }
			if (!loading) { SavedVars.GeneratedEvents = ""; }
			int pedestalClues = 0;
			nodes.Clear();
			int[] size = { 0, 0 };
			size[1] = map.Count;
			int length = 0;
			for (int i = 0; i < map.Count; i++)
			{
				if (map[i].Count > length)
				{
					length = map[i].Count;
				}
			}
			size[0] = length;
			GameObject zones = GameObject.Find("NavigationGrid");
			NavigationGrid navigationGrid = zones.GetComponent<NavigationGrid>();
			GameObject.Find("NavigationGrid").GetComponent<NavigationGrid>().zones = new NavigationZone[size[0], size[1]];
			for (int i = 0; i < zones.transform.childCount; i++)
			{
				GameObject.Destroy(zones.transform.GetChild(i).gameObject);
			}
			List<string> connectedNodes = new List<string>();
			int nodesLoaded = 0;
			string[] allNodes = new string[0];
			if (loading)
            {
				allNodes = SavedVars.GeneratedEvents.Split(';');
            }
			for (int y = 0; y < size[1]; y++)
			{
				for (int x = 0; x < map[y].Count; x++)
				{
					if (map[y][x][0] == 'W')
					{
						GameObject gameObject = GameObject.Instantiate(GameObject.Find("wall"));
						gameObject.name = "x" + x.ToString() + " y" + y.ToString();
						gameObject.transform.parent = GameObject.Find("walls").transform;
						gameObject.transform.Find("BrickGround").localPosition = new Vector3(0, 0, 0);
						gameObject.transform.position = new Vector3((float)(x * 20), 6f, (float)(y * -20 + -9));
						switch (map[y][x][1])
						{
							case 'n':
								gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.color = new Color(0f, 0f, 0f, 1);
								gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTexture = WallTextures.none;
								gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.shaderKeywords = new string[0];
								gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().lightmapIndex = 0;
								break;
							case 'g':
								gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.color = new Color(0.51f, 1f, 0.51f, 1);
								gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTexture = WallTextures.goo;
								gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.SetTexture("_BumpMap", WallTextures.gooNormal);
								break;
							case 'z':
								gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTexture = WallTextures.lava;
								gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.SetTexture("_BumpMap", WallTextures.lavaNormal);
								gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTextureOffset = new Vector2(0, 0);
								break;
							case '0':
								//gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTexture = Tools.getImage("brickwall.png");
								break;
							case '1':
								gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.color = new Color(1, 0.6866f, 0.1936f, 1);
								gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().lightmapIndex = 0;
								break;
							case '2':
								gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.color = new Color(1, 0.6866f, 0.1936f, 1);
								gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().lightmapIndex = 0;
								GameObject gooWall = new GameObject("GooWall");
								gooWall.transform.parent = gameObject.transform;
								gooWall.AddComponent<SpriteRenderer>();
								int rand = Random.RandomRangeInt(0, 11);
								gooWall.GetComponent<SpriteRenderer>().sprite = WallTextures.gooDrips[rand];
								gooWall.GetComponent<SpriteRenderer>().receiveShadows = true;
								gooWall.GetComponent<SpriteRenderer>().lightmapIndex = 0;
								gooWall.transform.localScale = new Vector3(0.137f, 0.063f, 0.1f);
								if (rand != 9 && rand != 10)
								{
									gooWall.GetComponent<SpriteRenderer>().color = new Color(0.5f, 1, 0.5f, 1);
								}
								gooWall.transform.localPosition = new Vector3(0, 0.175f, 0f);
								switch (map[y][x][2])
								{
									case 'N':
										gooWall.transform.localPosition = new Vector3(0, 0.175f, -0.01f);
										break;
									case 'S':
										gooWall.transform.localPosition = new Vector3(0, 0.175f, -0.01f);
										break;
									case 'W':
										gooWall.transform.localPosition = new Vector3(-0, 0.175f, 0.01f);
										break;
									case 'E':
										gooWall.transform.localPosition = new Vector3(0, 0.175f, -0.01f);
										break;
								}
								break;
							case '3':
								//1 0.7487 0.1241 1
								gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.color = new Color(1f, 0.7487f, 0.1241f, 1);
								break;
							case '4':
								gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.color = new Color(0.3f, 0.3f, 0.3f, 1);
								gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTexture = WallTextures.dungeon;
								gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.SetTexture("_BumpMap", WallTextures.dungeonNormal);
								gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().lightmapIndex = 0;
								break;
							case '5':
								gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTexture = WallTextures.lava;
								gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.SetTexture("_BumpMap", WallTextures.lavaNormal);
								gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTextureOffset = new Vector2(0, 0);
								if (UnityEngine.Random.RandomRangeInt(0, 100) > 93 && y > 6)
								{
									gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTextureOffset = new Vector2(0, 0.25f);
									gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.color = new Color(0.3f, 0.3f, 0.3f, 1);
									gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTexture = WallTextures.dungeon;
									gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.SetTexture("_BumpMap", WallTextures.dungeonNormal);
									gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().lightmapIndex = 0;
									GameObject shrooms = new GameObject("shrooms");
									shrooms.transform.parent = gameObject.transform;
									shrooms.transform.localPosition = new Vector3(0, 0, 0);
									for (int i = 0; i < 3; i++)
									{
										GameObject shroom = GameObject.Instantiate(GameObject.Find("shroom"));
										shroom.name = "wallShroom";
										shroom.transform.parent = shrooms.transform;
										switch (i)
										{
											case 0:
												shroom.transform.localPosition = new Vector3(-2.8f, UnityEngine.Random.RandomRangeInt(-2, 5), 0.58f);
												break;
											case 1:
												shroom.transform.localPosition = new Vector3(2.8201f, 1.9f + UnityEngine.Random.RandomRangeInt(-3, 5), 0.58f);
												break;
											case 2:
												shroom.transform.localPosition = new Vector3(1.1601f, 6.76f + UnityEngine.Random.RandomRangeInt(-6, 5), 0.58f);
												break;
										}
										shroom.transform.rotation = Quaternion.Euler(UnityEngine.Random.RandomRangeInt(270, 320), UnityEngine.Random.RandomRangeInt(-50, 50), 0);
									}
								}
								break;
							case '6':
								gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.color = new Color(0.3f, 0.3f, 0.3f, 1);
								gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTexture = WallTextures.dungeon;
								gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.SetTexture("_BumpMap", WallTextures.dungeonNormal);
								gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().lightmapIndex = 0;
								GameObject sword = GameObject.Instantiate(GameObject.Find("swordModel"));
								sword.transform.parent = gameObject.transform;
								sword.transform.localPosition = new Vector3(0f, 0.3f, -0.2f);
								sword.transform.rotation = Quaternion.Euler(180, 0, 0);
								break;
							case '7':
								gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.color = new Color(0.3f, 0.3f, 0.3f, 1);
								gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTexture = WallTextures.dungeon;
								gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.SetTexture("_BumpMap", WallTextures.dungeonNormal);
								gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().lightmapIndex = 0;
								GameObject pedestalClue = new GameObject("pedestalClue");
								pedestalClue.transform.parent = gameObject.transform;
								pedestalClue.transform.localPosition = new Vector3(0, 0, -0.2f);
								GameObject pedestalSprite = new GameObject("pedestalSprite");
								pedestalSprite.transform.parent = pedestalClue.transform;
								pedestalSprite.AddComponent<SpriteRenderer>();
								pedestalSprite.GetComponent<SpriteRenderer>().sprite = Tools.getSprite("pedestal_clue_dot.png");
								pedestalSprite.transform.localScale = new Vector3(2, 2, 2);
								pedestalSprite.transform.localPosition = new Vector3(0, 18, 0);
								pedestalSprite.transform.rotation = Quaternion.Euler(0, 0, Random.RandomRangeInt(0, 360));
								float colorE = Random.RandomRangeInt(0, 6);
								colorE /= 10;
								if (pedestalClues == 0)
								{
									makePedestalClue(pedestalSprite, pedestalClues);
								}
								pedestalSprite.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1 - colorE);
								for (int i = 1; i < 3; i++)
								{
									GameObject pedestalSprite2 = GameObject.Instantiate(pedestalSprite);
									pedestalSprite2.transform.parent = pedestalClue.transform;
									int offset = 3 * i;
									pedestalSprite2.transform.localScale = new Vector3(2, 2, 2);
									pedestalSprite2.transform.localPosition = new Vector3(0, 18 - offset, 0);
									pedestalSprite2.GetComponent<SpriteRenderer>().sprite = Tools.getSprite("pedestal_clue_dot.png");
									pedestalSprite2.transform.rotation = Quaternion.Euler(0, 0, Random.RandomRangeInt(0, 360));
									if (pedestalClues == i)
									{
										makePedestalClue(pedestalSprite2, pedestalClues);
									}
									colorE = Random.RandomRangeInt(0, 6);
									colorE /= 10;
									pedestalSprite2.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1 - colorE);
								}

								if(config.isometricMode)
                                {
									GameObject ceilPedestal = GameObject.Instantiate(pedestalSprite);
									ceilPedestal.name = "ceilHint";
									ceilPedestal.transform.parent = pedestalClue.transform;
									ceilPedestal.GetComponent<SpriteRenderer>().sprite = Tools.getSprite("puzzlehint_unknown.png");
									ceilPedestal.transform.localScale = new Vector3(8, 8, 8);
									ceilPedestal.transform.localPosition = new Vector3(0, 26, 10);
									ceilPedestal.transform.rotation = Quaternion.Euler(90, 0, 0);

								}


								pedestalClues++;
								break;
							case '8':
								gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.color = new Color(1f, 1f, 1f, 1);
								gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTexture = WallTextures.bookShelf;
								gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.shaderKeywords = new string[0];
								gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().lightmapIndex = 0;
								break;

						}
						switch (map[y][x][2])
						{
							case 'N':
								gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
								gameObject.transform.position -= new Vector3(0, 0, 10);
								break;
							case 'S':
								gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
								gameObject.transform.position += new Vector3(0, 0, 10);
								break;
							case 'E':
								gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 270, 0));
								gameObject.transform.position -= new Vector3(-10, 0, 0);
								break;
							case 'W':
								gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
								gameObject.transform.position += new Vector3(-10, 0, 0);
								break;
							case 'D':
							case 'd':
							case 'H':
							case 'J'://stupid offsets ugghh
							case 'K':
							case 'L':
							case 'l':
								for (int i = 0; i < 4; i++)
								{
									if (map[y][x][2] == 'D' && i == 1 || map[y][x][2] == 'D' && i == 3 || map[y][x][2] == 'L' && i == 1 || map[y][x][2] == 'L' && i == 3)
									{
										continue;
									}
									if (map[y][x][2] == 'd' && i == 0 || map[y][x][2] == 'd' && i == 2 || map[y][x][2] == 'l' && i == 0 || map[y][x][2] == 'l' && i == 2)
									{
										continue;
									}
									if (map[y][x][2] == 'J' && i == 0) {
										gameObject.transform.position -= new Vector3(0, 0, 10);
										continue; 
									}

									GameObject wall = GameObject.Instantiate(gameObject);
									wall.transform.rotation = Quaternion.Euler(new Vector3(0, 90 * i, 0));
									wall.transform.parent = GameObject.Find("walls").transform;
									wall.transform.position = new Vector3((float)(x * 20), 6f, (float)(y * -20 + -9));
									if (i == 3)
									{
										float xOffset = UnityEngine.Random.RandomRangeInt(-10, 10);
										xOffset /= 100;
										wall.transform.position += new Vector3(9.998f + xOffset, 0, 0);
									}
									else if (i == 1)
									{
										float xOffset = UnityEngine.Random.RandomRangeInt(-10, 10);
										xOffset /= 100;
										wall.transform.position -= new Vector3(9.99f + xOffset, 0, -0);
									}
									else if (i == 2)
									{
										wall.transform.position += new Vector3(0, 0, 9.998f);
									}
									else if (i == 0)
									{
										wall.transform.position += new Vector3(0, 0, -10);
									}
									if (map[y][x][1] == '2')
									{
										switch (90 * i)
										{
											case 0:
												wall.transform.Find("GooWall").localPosition = new Vector3(0, 0.175f, -0.01f);
												break;
											case 180:
												wall.transform.Find("GooWall").localPosition = new Vector3(0, 0.175f, -0.01f);
												break;
											case 270:
												wall.transform.Find("GooWall").localPosition = new Vector3(-0, 0.175f, 0.01f);
												break;
											case 90:
												wall.transform.Find("GooWall").localPosition = new Vector3(0, 0.175f, -0.01f);
												break;
										}
										int rand = Random.RandomRangeInt(0, 11);
										wall.transform.Find("GooWall").gameObject.GetComponent<SpriteRenderer>().sprite = WallTextures.gooDrips[rand];
										if (rand == 9 || rand == 10)
										{
											wall.transform.Find("GooWall").gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
										} else
										{
											wall.transform.Find("GooWall").gameObject.GetComponent<SpriteRenderer>().color = new Color(0.5f, 1, 0.5f, 1);
										}
									}
								}
								break;
							case 'C':
								for (int i = 0; i < 4; i++)
								{
									GameObject wall = GameObject.Instantiate(gameObject);
									wall.transform.rotation = Quaternion.Euler(new Vector3(0, 90 * i, 0));
									wall.transform.parent = GameObject.Find("walls").transform;
									wall.transform.position = new Vector3((float)(x * 20), 6f, (float)(y * -20 + -9));
									if (i == 3)
									{
										wall.transform.position += new Vector3(10, 0, 0);
									}
									else if (i == 1)
									{
										wall.transform.position -= new Vector3(10, 0, 0);
									}
									else if (i == 2)
									{
										wall.transform.position += new Vector3(0, 0, 10);
									}
									else if (i == 0)
									{
										wall.transform.position -= new Vector3(0, 0, 10);
									}
								if (map[y][x][1] == '2')
									{
										switch (90 * i)
										{
											case 0:
												wall.transform.Find("GooWall").localPosition = new Vector3(0, 0.175f, -0.01f);
												break;
											case 180:
												wall.transform.Find("GooWall").localPosition = new Vector3(0, 0.175f, -0.01f);
												break;
											case 270:
												wall.transform.Find("GooWall").localPosition = new Vector3(-0, 0.175f, 0.01f);
												break;
											case 90:
												wall.transform.Find("GooWall").localPosition = new Vector3(0, 0.175f, -0.01f);
												break;
										}
										int rand = Random.RandomRangeInt(0, 11);
										wall.transform.Find("GooWall").gameObject.GetComponent<SpriteRenderer>().sprite = WallTextures.gooDrips[rand];
										if (rand == 9 || rand == 10)
										{
											wall.transform.Find("GooWall").gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
										}
										else
										{
											wall.transform.Find("GooWall").gameObject.GetComponent<SpriteRenderer>().color = new Color(0.5f, 1, 0.5f, 1);
										}
									}
								}
								break;
							case 'P':
								for (int i = 0; i < 4; i++)
								{
									GameObject wall = GameObject.Instantiate(gameObject);
									wall.transform.rotation = Quaternion.Euler(new Vector3(0, 90 * i, 0));
									wall.transform.parent = GameObject.Find("walls").transform;
									wall.transform.position = new Vector3((float)(x * 20), 6f, (float)(y * -20 + -9));
									if (i == 3)
									{
										wall.transform.localScale = new Vector3(10.5f, 50, 1);
										wall.transform.position += new Vector3(10, 0, 5.1f);
									}
									else if (i == 1)
									{
										wall.transform.localScale = new Vector3(10.5f, 50, 1);
										wall.transform.position -= new Vector3(10, 0, -5.1f);
									}
									else if (i == 2)
									{
										wall.transform.position += new Vector3(0, 0, 10);
									}
									if (map[y][x][1] == '2')
									{
										switch (90 * i)
										{
											case 0:
												wall.transform.Find("GooWall").localPosition = new Vector3(0, 0.175f, -0.01f);
												break;
											case 180:
												wall.transform.Find("GooWall").localPosition = new Vector3(0, 0.175f, -0.01f);
												break;
											case 270:
												wall.transform.Find("GooWall").localPosition = new Vector3(0, 0.175f, -0.01f);
												break;
											case 90:
												wall.transform.Find("GooWall").localPosition = new Vector3(0, 0.175f, -0.01f);
												break;
										}
										int rand = Random.RandomRangeInt(0, 11);
										wall.transform.Find("GooWall").gameObject.GetComponent<SpriteRenderer>().sprite = WallTextures.gooDrips[rand];
										if (rand ==9 || rand == 10)
										{
											wall.transform.Find("GooWall").gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
										}
										else
										{
											wall.transform.Find("GooWall").gameObject.GetComponent<SpriteRenderer>().color = new Color(0.5f, 1, 0.5f, 1);
										}
									}
								}
								break;
							case 'F':
								gameObject.transform.rotation = Quaternion.Euler(new Vector3(90, 0, 0));
								gameObject.transform.localScale = new Vector3(20f, 20f, 1);
								if (map[y][x][1] == '2')
								{
									//gameObject.transform.localScale = new Vector3(20f, 25f, 1);
									GameObject.Destroy(gameObject.transform.Find("GooWall").gameObject);
								}
								gameObject.transform.position += new Vector3(0f, 0, 0.5f);
								float offset = UnityEngine.Random.Range(0.001f, .0150f);
								gameObject.transform.position = new Vector3(gameObject.transform.position.x, offset, gameObject.transform.position.z);
								if (map[y][x][1] != '3')
								{
									gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0, 1);
									gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTexture = WallTextures.none;
									if (RunState.Run.regionTier == 2)
									{
										gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1, 1);
										gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTexture = WallTextures.lavafloor;
										gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTextureScale = new Vector2(1, 1);
										gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTextureOffset = new Vector2(0, 0);
										gameObject.transform.Find("BrickGround").gameObject.AddComponent<Light>().range = 50;
										gameObject.transform.Find("BrickGround").gameObject.GetComponent<Light>().color = new Color(1, 0.5f, 0, 1);
										gameObject.transform.Find("BrickGround").gameObject.GetComponent<Light>().intensity = 2;
									}
									gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.shaderKeywords = new string[0];
								} else
								{
									GameObject manHole = new GameObject("ManHole");
									GameObject.Destroy(gameObject.transform.Find("BrickGround").gameObject);
									manHole.transform.parent = gameObject.transform;
									manHole.AddComponent<SpriteRenderer>();
									manHole.GetComponent<SpriteRenderer>().sprite = WallTextures.manhole;
									manHole.transform.localPosition = new Vector3(0, -0.1f, 0);
									manHole.transform.localRotation = Quaternion.Euler(0, 0, 0);
									manHole.transform.localScale = new Vector3(0.065f, 0.065f, 0.065f);
								}
								break;
						}
						if (map[y][x].Length > 3)
						{
							switch (map[y][x][3])//postfix
							{
								case 'S':
									gameObject.transform.position += new Vector3(0, 0, 20);
									break;
							}
						}
						if (config.isometricMode == true && map[y][x][2] != 'F' && map[y][x][2] != 'D' && map[y][x][2] != 'L') {
							GameObject wallcover = GameObject.Instantiate(gameObject);
							wallcover.name = "x" + x.ToString() + " y" + y.ToString() + " cover";
							wallcover.transform.parent = GameObject.Find("walls").transform;
							wallcover.transform.Find("BrickGround").localPosition = new Vector3(0, 0, 0);
							Vector3 offset = new Vector3(0, 0, 0);
							if (map[y][x][2] == 'N') { offset = new Vector3(0, 0, 10); } else if (map[y][x][2] == 'E') { offset = new Vector3(-10, 0, 0); } else if (map[y][x][2] == 'S') { offset = new Vector3(0, 0, -10); } else if (map[y][x][2] == 'W') { offset = new Vector3(10, 0, 0); } else if (map[y][x][2] == 'J') { offset = new Vector3(0, 0, 10); } else if (map[y][x][2] == 'P') { offset = new Vector3(0, 0, 5); }
							float yOffset = UnityEngine.Random.Range(0.0000f, .0150f);
							wallcover.transform.position = new Vector3(gameObject.transform.position.x, 31f + yOffset, gameObject.transform.position.z) + offset;
							wallcover.transform.localScale = new Vector3(20, 20, 1);
							wallcover.transform.localRotation = Quaternion.Euler(90, 0, 0);
							if (map[y][x][2] == 'P') { wallcover.transform.localScale = new Vector3(20, 10, 1); }
							wallcover.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTextureScale = new Vector2(1, 1);
							if (wallcover.transform.childCount >= 4)
                            {
								GameObject.Destroy(wallcover.transform.GetChild(3).gameObject);
                            }
							if (map[y][x][2] == 'S')
                            {
								GameObject gameObject2 = GameObject.Instantiate(gameObject);
								gameObject2.name = "x" + x.ToString() + " y" + y.ToString();
								gameObject2.transform.parent = GameObject.Find("walls").transform;
								gameObject2.transform.Find("BrickGround").localPosition = new Vector3(0, 0, 0);
								gameObject2.transform.position = gameObject.transform.position + new Vector3(0, 0, -20);
								gameObject2.transform.rotation = Quaternion.Euler(0, 0, 0);
							} else if (map[y][x][2] == 'E')
							{
								GameObject gameObject2 = GameObject.Instantiate(gameObject);
								gameObject2.name = "x" + x.ToString() + " y" + y.ToString();
								gameObject2.transform.parent = GameObject.Find("walls").transform;
								gameObject2.transform.Find("BrickGround").localPosition = new Vector3(0, 0, 0);
								gameObject2.transform.position = gameObject.transform.position + new Vector3(-20, 0, 0);
								gameObject2.transform.rotation = Quaternion.Euler(0, 90, 0);
							} else if (map[y][x][2] == 'N')
							{
								GameObject gameObject2 = GameObject.Instantiate(gameObject);
								gameObject2.name = "x" + x.ToString() + " y" + y.ToString();
								gameObject2.transform.parent = GameObject.Find("walls").transform;
								gameObject2.transform.Find("BrickGround").localPosition = new Vector3(0, 0, 0);
								gameObject2.transform.position = gameObject.transform.position + new Vector3(0, 0, 20);
								gameObject2.transform.rotation = Quaternion.Euler(0, 180, 0);
							}
							else if (map[y][x][2] == 'W')
							{
								GameObject gameObject2 = GameObject.Instantiate(gameObject);
								gameObject2.name = "x" + x.ToString() + " y" + y.ToString();
								gameObject2.transform.parent = GameObject.Find("walls").transform;
								gameObject2.transform.Find("BrickGround").localPosition = new Vector3(0, 0, 0);
								gameObject2.transform.position = gameObject.transform.position + new Vector3(20, 0, 0);
								gameObject2.transform.rotation = Quaternion.Euler(0, 270, 0);
							}
							else if ((map[y][x][2] == 'J' || map[y][x][2] == 'H') && map[y][x + 1][0] == 'W')
							{
								bool ignore = false;
								if (map[y][x + 1][2] != 'D' && map[y][x + 1][2] != 'L') { ignore = true; }
								if (!ignore)
								{
									GameObject cover2 = GameObject.Instantiate(wallcover);
									cover2.name = "x" + x.ToString() + " y" + y.ToString() + " cover2";
									cover2.transform.parent = GameObject.Find("walls").transform;
									cover2.transform.Find("BrickGround").localPosition = new Vector3(0, 0, 0);
									yOffset = UnityEngine.Random.Range(0, 10);
									yOffset /= 100;
									cover2.transform.position = wallcover.transform.position + new Vector3(20, 0, 0);
									if (cover2.transform.childCount >= 4)
									{
										GameObject.Destroy(cover2.transform.GetChild(3).gameObject);
									}
								}
							}
							/*
							else if (map[y][x][2] == 'C')
							{
								bool checkRight = true;
								bool dontCheck = false;
								if (map[y].Count <= x + 1 || map[y][x + 1][0] != 'W' || map[y][x + 1][2] == 'C')
								{
									checkRight = false;
									if (map[y][x - 1][0] != 'W') { dontCheck = true;  }
								}
								if (!dontCheck)
								{
									int checkX = checkRight ? x + 1 : x - 1;
									if (map[y][checkX][2] == 'N')
									{
										wallcover.transform.position += new Vector3(0, 0, 5);
										wallcover.transform.localScale = new Vector3(20, 30, 1);
										wallcover.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTextureScale = new Vector2(1, 2);
									}
								}
							}*/
							gameObject.AddComponent<BoxCollider>().size = new Vector3(1, 1f, 1f);
							gameObject.GetComponent<BoxCollider>().center = new Vector3(0, -0.65f, 0);
						}
						continue;
					}
					else if (map[y][x] == "PK")
					{
						GameObject pike = GameObject.Instantiate(GameObject.Find("PikeModel"));
						pike.transform.position = new Vector3((float)(x * 20), 9.5f, (float)(y * -20));
						pike.transform.rotation = Quaternion.Euler(UnityEngine.Random.RandomRangeInt(-10, 10), UnityEngine.Random.RandomRangeInt(0, 360), UnityEngine.Random.RandomRangeInt(-10, 10));
						pike.transform.parent = GameObject.Find("scenery").transform;
						continue;
					} else if (map[y][x] == "htr")
					{
						GameObject huber = GameObject.Instantiate(GameObject.Find("cloth3D"));
						huber.transform.position = new Vector3((float)(x * 20), 0.15f, (float)(y * -20));
						huber.transform.parent = GameObject.Find("scenery").transform;
						continue;
					}
					else if (map[y][x][0] == 'P')
					{
						switch (map[y][x][1])
						{
							case '1':
								GameObject arch = GameObject.Instantiate(GameObject.Find("AncientRuins_ArchBroken"));
								arch.transform.position = new Vector3((float)(x * 20), 0f, (float)(y * -20));
								arch.transform.rotation = Quaternion.Euler(280.2758f, UnityEngine.Random.RandomRangeInt(0, 360), 89.9996f);
								arch.transform.parent = GameObject.Find("scenery").transform;
								break;
							case '2':
								GameObject ColumnBase = GameObject.Instantiate(GameObject.Find("AncientRuins_ColumnBase"));
								ColumnBase.transform.position = new Vector3((float)(x * 20), 0f, (float)(y * -20));
								ColumnBase.transform.rotation = Quaternion.Euler(280.2758f, UnityEngine.Random.RandomRangeInt(0, 360), 89.9996f);
								ColumnBase.transform.parent = GameObject.Find("scenery").transform;
								break;
							case '3':
								GameObject FullColumn = GameObject.Instantiate(GameObject.Find("AncientRuins_FullColumn"));
								FullColumn.transform.position = new Vector3((float)(x * 20), 0f, (float)(y * -20));
								FullColumn.transform.rotation = Quaternion.Euler(280.2758f, UnityEngine.Random.RandomRangeInt(0, 360), 89.9996f);
								FullColumn.transform.parent = GameObject.Find("scenery").transform;
								break;
							case '4':
								GameObject FullGoldColumn = GameObject.Instantiate(GameObject.Find("AncientRuins_FullColumn"));
								FullGoldColumn.transform.position = new Vector3((float)(x * 20), 0f, (float)(y * -20));
								FullGoldColumn.transform.rotation = Quaternion.Euler(280.2758f, UnityEngine.Random.RandomRangeInt(0, 360), 89.9996f);
								FullGoldColumn.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 0);
								FullGoldColumn.transform.parent = GameObject.Find("scenery").transform;
								break;
						}
						continue;
					}
					else if (map[y][x][0] == 'A')
					{
						Vector3 baseRot = new Vector3(0, 0, 0);
						GameObject dunny = GameObject.Find("trainingDummy");
						switch (map[y][x][1])
						{
							case '1':
								dunny = GameObject.Instantiate(GameObject.Find("trainingDummy"));
								dunny.name = "x" + x + " y" + y + " dummy";
								dunny.transform.position = new Vector3((float)(x * 20), 0f, (float)(y * -20));
								dunny.transform.parent = GameObject.Find("scenery").transform;
								//dunny.transform.rotation.x = 270;
								baseRot = new Vector3(270, 0, 0);
								break;
							case '2':
								dunny = GameObject.Instantiate(GameObject.Find("archeryDummy"));
								dunny.name = "x" + x + " y" + y + " dummy";
								dunny.transform.position = new Vector3((float)(x * 20), 0f, (float)(y * -20));
								dunny.transform.parent = GameObject.Find("scenery").transform;
								break;
						}
						int rotY = 0;
						switch (map[y][x][2])
						{
							case 'S':
								rotY = 180;
								break;
							case 'E':
								rotY = 90;
								break;
							case 'W':
								rotY = 270;
								break;
						}

						if (RunState.Run.regionTier > 0) { rotY += Random.RandomRangeInt(-30, 30); }
						baseRot.y = rotY;
						if (dummy.name != "trainingDummy")
						{
							dunny.transform.rotation = Quaternion.Euler(baseRot);
						}
						continue;
					}
					else if (map[y][x] == "SK")
					{
						List<string> shopKeepers = new List<string>
						{
							"Wizard3DPortrait_JuniorSage",
							"Wizard3DPortrait_OrangeMage",
							"Wizard3DPortrait_BlueMage"
						};
						int keeper = RunState.Run.regionTier - 1;
						GameObject shopkeeper = GameObject.Instantiate(Resources.Load("Prefabs/finalemagnificus/" + shopKeepers[keeper]) as GameObject);
						shopkeeper.transform.position = new Vector3((float)(x * 20), 0f, (float)(y * -20));
						if (keeper == 0)
						{
							for (int i = 0; i < shopkeeper.transform.Find("Anim").gameObject.transform.childCount; i++)
							{
								shopkeeper.transform.Find("Anim").gameObject.transform.GetChild(i).transform.rotation = Quaternion.Euler(shopkeeper.transform.Find("Anim").gameObject.transform.GetChild(i).transform.eulerAngles.x, 180, shopkeeper.transform.Find("Anim").gameObject.transform.GetChild(i).transform.eulerAngles.z);
							}
						}
						else if (keeper == 1)
						{
							shopkeeper.transform.Find("Anim").transform.localRotation = Quaternion.Euler(0, 130, 0);
						} else if (keeper == 2)
						{
							shopkeeper.transform.Find("Anim").transform.localRotation = Quaternion.Euler(0, 180, 0);
						}
						shopkeeper.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
						nodes.Add(shopkeeper);
						shopkeeper.transform.parent = GameObject.Find("scenery").transform;
						shopkeeper.name = "shopKeeper";
						continue;
					}
					else if (map[y][x] == "SWR")
					{
						GameObject sword = GameObject.Instantiate(GameObject.Find("swordModel"));
						sword.transform.position = new Vector3((float)(x * 20), 9.5f, (float)(y * -20));
						sword.transform.rotation = Quaternion.Euler(UnityEngine.Random.RandomRangeInt(-10, 10), UnityEngine.Random.RandomRangeInt(0, 360), 180);
						sword.transform.parent = GameObject.Find("scenery").transform;
						continue;
					}
					else if (map[y][x] == "CRT")
					{
						GameObject crate = GameObject.Instantiate(GameObject.Find("crates"));
						crate.transform.position = new Vector3((float)(x * 20) + 3, 4.5f, (float)(y * -20));
						crate.transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
						crate.transform.rotation = Quaternion.Euler(UnityEngine.Random.RandomRangeInt(-5, 5), UnityEngine.Random.RandomRangeInt(0, 360), UnityEngine.Random.RandomRangeInt(-5, 5));
						crate.transform.parent = GameObject.Find("scenery").transform;
						if (crate.transform.childCount > 1)
						{
							GameObject.Destroy(crate.transform.Find("CratesLeft").gameObject);
						}
						if (RunState.Run.regionTier == 3 || RunState.Run.regionTier == 0)
                        {
							for (int i = 0; i < crate.transform.Find("CratesRight").childCount; i++)
                            {
								if (RunState.Run.regionTier == 3)
								{
									crate.transform.Find("CratesRight").GetChild(i).gameObject.GetComponentInChildren<MeshRenderer>().material.color = new Color(0.337f, 0.2943f, 0.2198f, 1);
								}
								crate.transform.Find("CratesRight").GetChild(i).GetChild(0).gameObject.GetComponent<MeshRenderer>().lightmapIndex = 0;
							}
                        }
						continue;
					}
					else if (map[y][x] == "EYE")
					{
						GameObject eye = GameObject.Instantiate(GameObject.Find("eyeball"));
						try
						{
							GameObject.Destroy(eye.GetComponent<Rigidbody>());
							GameObject.Destroy(eye.GetComponent<EyeballInteractable>());
						} catch { }
						eye.transform.localScale = new Vector3(15f, 15f, 15f);
						GameObject eyeParent = new GameObject("eyeBallParent");
						eyeParent.transform.parent = GameObject.Find("scenery").transform;
						eye.transform.parent = eyeParent.transform;
						eyeParent.transform.position = new Vector3((float)(x * 20), 9.5f, (float)(y * -20));
						eye.transform.localPosition = new Vector3(0, 0, 0);
						eye.transform.localRotation = Quaternion.Euler(0, 90, 0);
						nodes.Add(eyeParent);
						continue;
					}
					else if (map[y][x] == "RUNE")
					{
						GameObject runes = new GameObject("runes");
						runes.transform.parent = GameObject.Find("scenery").transform;
						float yOff = Random.Range(-2f, 2f);
						runes.transform.position = new Vector3((float)(x * 20), 16.5f + yOff, (float)(y * -20));
						runes.transform.localRotation = Quaternion.Euler(0, 90, 0);
						runes.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
						runes.AddComponent<SineWaveMovement>();
						runes.GetComponent<SineWaveMovement>().originalPosition = new Vector3((float)(x * 20), 16.5f + yOff, (float)(y * -20));
						runes.GetComponent<SineWaveMovement>().speed = 0.1f + (Random.RandomRangeInt(1, 2) / 10f);
						runes.GetComponent<SineWaveMovement>().yMagnitude = 1;
						runes.AddComponent<SpriteRenderer>();
						runes.GetComponent<SpriteRenderer>().sprite = WallTextures.runes[Random.RandomRangeInt(0, WallTextures.runes.Count)];
						nodes.Add(runes);
						continue;
					}
					else if (map[y][x].Contains("RUNEH"))
					{
						string id = map[y][x].Split(';')[1];
						Debug.Log("runeh id: " + id);
						GameObject pedestalClue = new GameObject("pedestalClue" + id);
						pedestalClue.AddComponent<RuneHint>();
						pedestalClue.transform.parent = GameObject.Find("scenery").transform;
						pedestalClue.transform.localRotation = Quaternion.Euler(0, 90, 0);
						pedestalClue.transform.position = new Vector3((float)(x * 20), 2f, (float)(y * -20));
						GameObject pedestalSprite = new GameObject("pedestalSprite");
						pedestalSprite.transform.parent = pedestalClue.transform;
						pedestalSprite.AddComponent<SpriteRenderer>();
						pedestalSprite.GetComponent<SpriteRenderer>().sprite = Tools.getSprite("puzzlehint_unknown.png");
						pedestalSprite.transform.localScale = new Vector3(5.5f, 5.5f, 5.5f);
						pedestalSprite.transform.localPosition = new Vector3(0, 18, 0);
						pedestalSprite.transform.localRotation = Quaternion.Euler(0, 0, Random.RandomRangeInt(-25, 25));
						float colorE = Random.RandomRangeInt(0, 6);
						colorE /= 10;
						if (pedestalClues == 0)
						{
							pedestalClue.GetComponent<RuneHint>().solutionIdx = 0;
							makePedestalClue(pedestalSprite, pedestalClues);
						}
						pedestalSprite.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1 - colorE);
						for (int i = 1; i < 3; i++)
						{
							GameObject pedestalSprite2 = GameObject.Instantiate(pedestalSprite);
							pedestalSprite2.transform.parent = pedestalClue.transform;
							int offset = 3 * i;
							pedestalSprite2.GetComponent<SpriteRenderer>().sprite = Tools.getSprite("puzzlehint_unknown.png");
							pedestalSprite2.transform.localScale = new Vector3(5.5f, 5.5f, 5.5f);
							pedestalSprite2.transform.localPosition = new Vector3(0, 18 - offset, 0);
							pedestalSprite2.transform.localRotation = Quaternion.Euler(0, 0, Random.RandomRangeInt(-25, 25));
							if (pedestalClues == i)
							{
								pedestalClue.GetComponent<RuneHint>().solutionIdx = i;
								makePedestalClue(pedestalSprite2, pedestalClues);
							}
							colorE = Random.RandomRangeInt(0, 6);
							colorE /= 10;
							pedestalSprite2.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1 - colorE);
						}
						pedestalClues++;
						pedestalClue.AddComponent<SineWaveMovement>();
						pedestalClue.GetComponent<SineWaveMovement>().originalPosition = new Vector3((float)(x * 20), 1.5f, (float)(y * -20));
						pedestalClue.GetComponent<SineWaveMovement>().speed = 0.1f;
						pedestalClue.GetComponent<SineWaveMovement>().yMagnitude = 1;
						nodes.Add(pedestalClue);
						continue;
					}
					else if (map[y][x] == "CRT1")
					{
						GameObject crate = GameObject.Instantiate(GameObject.Find("crates"));
						crate.transform.position = new Vector3((float)(x * 20), 4.8f, (float)(y * -20));
						crate.transform.rotation = Quaternion.Euler(UnityEngine.Random.RandomRangeInt(-5, 5), UnityEngine.Random.RandomRangeInt(0, 360), UnityEngine.Random.RandomRangeInt(-5, 5));
						crate.transform.parent = GameObject.Find("scenery").transform;
						if (crate.transform.childCount > 1)
						{
							GameObject.Destroy(crate.transform.Find("CratesLeft").gameObject);
						}
						if (RunState.Run.regionTier == 0)
						{
							for (int i = 0; i < crate.transform.Find("CratesRight").childCount; i++)
							{
								crate.transform.Find("CratesRight").GetChild(i).GetChild(0).gameObject.GetComponent<MeshRenderer>().lightmapIndex = 0;
							}
						}
						continue;
					}
					else if (map[y][x] == "CRTG")
					{
						GameObject crate = GameObject.Instantiate(GameObject.Find("crates"));
						crate.transform.position = new Vector3((float)(x * 20) + 3, 4.5f, (float)(y * -20));
						crate.transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
						crate.transform.rotation = Quaternion.Euler(UnityEngine.Random.RandomRangeInt(-5, 5), UnityEngine.Random.RandomRangeInt(0, 360), UnityEngine.Random.RandomRangeInt(-5, 5));
						crate.transform.parent = GameObject.Find("scenery").transform;
						if (crate.transform.childCount > 1)
						{
							GameObject.Destroy(crate.transform.Find("CratesLeft").gameObject);
						}
						GameObject bottle = GameObject.Instantiate(GameObject.Find("gooBottle"));
						bottle.transform.parent = crate.transform;
						bool isOrigin = true;
						float yOffset = Random.RandomRangeInt(-2, 2);
						yOffset /= 10;
						bottle.transform.localPosition = new Vector3(5.8f, 5.7f + yOffset, 0);
						if (Random.RandomRangeInt(0, 100) > 50)
						{
							isOrigin = false;
							bottle.transform.localPosition = new Vector3(-0.55f, 5.7f + yOffset, 3.5f);
						}
						bottle.transform.rotation = Quaternion.Euler(Random.RandomRangeInt(-5, 5), Random.RandomRangeInt(0, 360), Random.RandomRangeInt(-5, 5));
						if (Random.RandomRangeInt(0, 100) > 50)
						{
							GameObject bottle2 = GameObject.Instantiate(GameObject.Find("gooBottle"));
							bottle2.transform.parent = crate.transform;
							bottle2.transform.localPosition = new Vector3(-0.52f, 5.8f, 3.25f);
							if (!isOrigin)
							{
								bottle2.transform.localPosition = new Vector3(5.3f, 5.6f, 0.25f);
							}
							bottle2.transform.rotation = Quaternion.Euler(Random.RandomRangeInt(-5, 5), Random.RandomRangeInt(0, 360), Random.RandomRangeInt(-5, 5));
						}
						if (RunState.Run.regionTier == 0)
						{
							for (int i = 0; i < crate.transform.Find("CratesRight").childCount; i++)
							{
								crate.transform.Find("CratesRight").GetChild(i).GetChild(0).gameObject.GetComponent<MeshRenderer>().lightmapIndex = 0;
							}
						}
						continue;
					}
					else if (map[y][x].Contains("TO"))
					{
						switch (map[y][x][2])
						{
							case '1':
								GameObject bottles = new GameObject("gooBottles");
								bottles.transform.parent = GameObject.Find("scenery").transform;
								bottles.transform.localPosition = new Vector3((float)(x * 20), -0.25f, (float)(y * -20));
								GameObject bottle = GameObject.Instantiate(GameObject.Find("gooBottle"));
								bottle.transform.parent = bottles.transform;
								bottle.transform.localScale = new Vector3(2.8f, 2.8f, 2.8f);
								bottle.transform.localPosition = new Vector3(0, -0.2f, 0);
								bottle.transform.rotation = Quaternion.Euler(Random.RandomRangeInt(-12, 12), Random.RandomRangeInt(0, 360), Random.RandomRangeInt(-9, 9));
								GameObject bottle2 = GameObject.Instantiate(GameObject.Find("gooBottle"));
								bottle2.transform.parent = bottles.transform;
								bottle2.transform.localPosition = new Vector3(-1.7f, -0.2f, -3.25f);
								bottle2.transform.rotation = Quaternion.Euler(Random.RandomRangeInt(-12, 12), Random.RandomRangeInt(0, 360), Random.RandomRangeInt(-9, 9));
								GameObject bottle3 = GameObject.Instantiate(GameObject.Find("gooBottle"));
								bottle3.transform.parent = bottles.transform;
								bottle3.transform.localPosition = new Vector3(2.4f, -0.2f, -3.25f);
								bottle3.transform.rotation = Quaternion.Euler(Random.RandomRangeInt(-12, 12), Random.RandomRangeInt(0, 360), Random.RandomRangeInt(-9, 9));
								bottles.transform.rotation = Quaternion.Euler(Random.RandomRangeInt(-5, 5), Random.RandomRangeInt(0, 360), Random.RandomRangeInt(-5, 5));
								break;
							case '2':
								GameObject flyingbooks = GameObject.Instantiate(GameObject.Find("floatingBook"));
								flyingbooks.transform.parent = GameObject.Find("scenery").transform;
								flyingbooks.transform.localPosition = new Vector3((float)(x * 20), 9.5f, (float)(y * -20));
								flyingbooks.transform.rotation = Quaternion.Euler(Random.RandomRangeInt(-10, 10), Random.RandomRangeInt(0, 360), Random.RandomRangeInt(-10, 10));
								for (int i = 0; i < flyingbooks.transform.childCount; i++)
								{
									flyingbooks.transform.GetChild(i).gameObject.GetComponent<SineWaveMovement>().originalPosition.x += Random.RandomRangeInt(-3, 3);
									flyingbooks.transform.GetChild(i).gameObject.GetComponent<SineWaveMovement>().originalPosition.y += Random.RandomRangeInt(-3, 3);
									flyingbooks.transform.GetChild(i).gameObject.GetComponent<SineWaveMovement>().originalPosition.z += Random.RandomRangeInt(-3, 3);
									List<Color> colors = new List<Color> { new Color(1, 1, 1, 1), new Color(0.65f, 1, 0.65f, 1), new Color(1, 0.65f, 0.65f, 1), new Color(0.65f, 0.65f, 1, 1) };
									flyingbooks.transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().material.color = colors[Random.RandomRangeInt(0, colors.Count)];
								}
								break;
							case '3':
								GameObject gameObject = GameObject.Instantiate(GameObject.Find("wall"));
								gameObject.name = "x" + x.ToString() + " y" + y.ToString();
								gameObject.transform.parent = GameObject.Find("walls").transform;
								gameObject.transform.Find("BrickGround").localPosition = new Vector3(0, 0, 0);
								gameObject.transform.position = new Vector3((float)(x * 20), 6f, (float)(y * -20 + -9));
								flyingbooks = GameObject.Instantiate(GameObject.Find("floatingBook"));
								flyingbooks.transform.parent = GameObject.Find("scenery").transform;
								flyingbooks.transform.localPosition = new Vector3((float)(x * 20), 9.5f, (float)(y * -20));
								flyingbooks.transform.rotation = Quaternion.Euler(Random.RandomRangeInt(-10, 10), Random.RandomRangeInt(0, 360), Random.RandomRangeInt(-10, 10));
								for (int i = 0; i < flyingbooks.transform.childCount; i++)
								{
									flyingbooks.transform.GetChild(i).gameObject.GetComponent<SineWaveMovement>().originalPosition.x += Random.RandomRangeInt(-3, 3);
									flyingbooks.transform.GetChild(i).gameObject.GetComponent<SineWaveMovement>().originalPosition.y += Random.RandomRangeInt(-3, 3);
									flyingbooks.transform.GetChild(i).gameObject.GetComponent<SineWaveMovement>().originalPosition.z += Random.RandomRangeInt(-3, 3);
									List<Color> colors = new List<Color> { new Color(1, 1, 1, 1), new Color(0.65f, 1, 0.65f, 1), new Color(1, 0.65f, 0.65f, 1), new Color(0.65f, 0.65f, 1, 1) };
									flyingbooks.transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().material.color = colors[Random.RandomRangeInt(0, colors.Count)];
								}
								gameObject.transform.rotation = Quaternion.Euler(new Vector3(90, 0, 0));
								gameObject.transform.localScale = new Vector3(20f, 20f, 1);
								gameObject.transform.position += new Vector3(0f, 0, 0.5f);
								float offset = UnityEngine.Random.Range(0.001f, .0150f);
								gameObject.transform.position = new Vector3(gameObject.transform.position.x, offset, gameObject.transform.position.z);
								gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0, 1);
								gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTexture = WallTextures.none;
								gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.shaderKeywords = new string[0];
								break;
							case '4':
								GameObject easel = GameObject.Instantiate(GameObject.Find("easel"));
								easel.transform.position = new Vector3((float)(x * 20) + 3, 11f, (float)(y * -20));
								easel.transform.localScale = new Vector3(7.5f, 7.5f, 7.5f);
								easel.transform.rotation = Quaternion.Euler(0, 222, 0);
								easel.transform.Find("Easel").Find("EaselAnim").GetChild(3).gameObject.GetComponent<BoxCollider>().size = new Vector3(0, 0, 0);
								easel.transform.Find("Easel").Find("EaselAnim").GetChild(3).Find("Quad").Find("CardBase").Find("RenderStatsLayer").Find("BendableCard").Find("Mesh").gameObject.GetComponent<SkinnedMeshRenderer>().materials[0].mainTexture = Tools.getImage("finalecardback.png");
								easel.transform.Find("Easel").Find("EaselAnim").GetChild(3).Find("Quad").Find("CardBase").Find("RenderStatsLayer").Find("BendableCard").Find("Mesh").gameObject.GetComponent<SkinnedMeshRenderer>().materials[1].mainTexture = Tools.getImage("finalecardbacknobars.png");
								easel.transform.parent = GameObject.Find("scenery").transform;
								easel.transform.Find("Easel").Find("EaselAnim").GetChild(3).gameObject.name = "DeathCard";
								break;
							case '5':
								GameObject magnificus = GameObject.Find("MagnificusAnim");
								magnificus.transform.position = new Vector3((float)(x * 20) + 0.3f, 15f, (float)(y * -20));
								magnificus.transform.localScale = new Vector3(2.75f, 2.75f, 2.75f);
								magnificus.transform.rotation = Quaternion.Euler(0, 0, 0);
								break;
							case '6':
								string text = File.ReadAllText(SaveManager.SaveFolderPath + "MagnificusModSave.gwsave");
								string[] array = text.Split(new char[]
								{
					'x'
								}, 2);
								string text2 = "x" + array[1];
								string[] array2 = text2.Split(new char[]
								{
					'C'
								});
								string[] cleared = array2[1].Split(new char[]
								{
					','
								});
								GameObject node = GameObject.Instantiate(new GameObject());
								node.name = "x" + x.ToString() + " y" + y.ToString();
								node.transform.parent = zones.transform;
								NavigationZone3D navigationZone3D = node.AddComponent<NavigationZone3D>();
								node.transform.position = new Vector3((float)(x * 20), -9.72f, (float)(y * -20));
								navigationGrid.zones[x, y] = navigationZone3D;
								node.GetComponentInChildren<NavigationZone3D>().events = new List<NavigationEvent> { Generation.deathCard };
								break;
						}
						continue;
					}


					if (map[y][x] != " ")
					{
						string text = File.ReadAllText(SaveManager.SaveFolderPath + "MagnificusModSave.gwsave");
						string[] array = text.Split(new char[]
						{
					'x'
						}, 2);
						string text2 = "x" + array[1];
						string[] array2 = text2.Split(new char[]
						{
					'C'
						});
						string[] cleared = array2[1].Split(new char[]
						{
					','
						});
						GameObject node = GameObject.Instantiate(new GameObject());
						node.name = "x" + x.ToString() + " y" + y.ToString();
						node.transform.parent = zones.transform;
						NavigationZone3D navigationZone3D = node.AddComponent<NavigationZone3D>();
						node.transform.position = new Vector3((float)(x * 20), -9.72f, (float)(y * -20));
						navigationGrid.zones[x, y] = navigationZone3D;

						if (map[y][x] == "-")
						{
							node.GetComponent<NavigationZone3D>().events = new List<NavigationEvent>();
						}

						if (map[y][x] == "MCL")
						{
							/*GameObject monocle = new GameObject("Monocle");
							monocle.transform.parent = GameObject.Find("GameEnvironment").transform;
							monocle.AddComponent<SpriteRenderer>();
							monocle.GetComponent<SpriteRenderer>().sprite = Tools.getSprite("monocle.png");
							monocle.transform.localScale = new Vector3(5, 5, 5);
							monocle.transform.rotation = Quaternion.Euler(89.5f, 262, 0);
							monocle.transform.position = new Vector3(25.35f, 11.02f, -16.75f);*/
							node.GetComponent<NavigationZone3D>().events.Add(getMonocle);
						} else if (map[y][x] == "DMY" && !cleared.Contains("x" + x + " y" + y))
						{
							GameObject monocle = new GameObject("Monocle");
							monocle.transform.parent = GameObject.Find("x4 y1 dummy").transform;
							monocle.AddComponent<SpriteRenderer>();
							monocle.GetComponent<SpriteRenderer>().sprite = Tools.getSprite("monocle.png");
							monocle.transform.localScale = new Vector3(0.006f, 0.006f, 0.006f);
							monocle.transform.rotation = Quaternion.Euler(0f, 353f, 0f);
							monocle.transform.position = new Vector3(81.25f, 19.2f, -21.5f);
							node.GetComponent<NavigationZone3D>().events.Add(dummyFight);
						}

						if (map[y][x].Contains("EX"))
						{
							if (map[y][x] == "EX1")
							{
								GameObject gameObject = GameObject.Instantiate(GameObject.Find("wall"));
								gameObject.name = "trapdoor";
								gameObject.transform.parent = GameObject.Find("walls").transform;
								gameObject.transform.Find("BrickGround").localPosition = new Vector3(0, 0, 0);
								gameObject.transform.position = new Vector3((float)(x * 20), 6f, (float)(y * -20) - 9);
								gameObject.transform.rotation = Quaternion.Euler(new Vector3(90, 90, 0));
								gameObject.transform.localScale = new Vector3(15f, 15f, 1);
								gameObject.transform.position += new Vector3(-2.5f, 0, 0f);
								gameObject.transform.position = new Vector3(gameObject.transform.position.x, 0.01f, gameObject.transform.position.z);
								gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1, 1);
								gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTextureOffset = new Vector2(0, 0);
								gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTextureScale = new Vector2(1, 1);
								gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTexture = WallTextures.trapdoor;
								gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.SetTexture("_BumpMap", Tools.getImage("trapdoornormal.png"));
								node.GetComponentInChildren<NavigationZone3D>().events.Add(Generation.edaxioTrapdoor);
							} else if (map[y][x] == "EXA")
							{
								GameObject icon2 = GameObject.Instantiate<GameObject>(GameObject.Find("nodeIconBase"));
								icon2.name = "nodeIcon";
								icon2.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = edaxioTex;
								icon2.transform.position = new Vector3(node.transform.position.x, 13f, node.transform.position.z);
								nodes.Add(icon2);
								icon2.transform.position = new Vector3(node.transform.position.x + 1f, 13f, node.transform.position.z);
								node.GetComponentInChildren<NavigationZone3D>().events.Add(Generation.edaxioNode);
								icon2.transform.parent = node.transform;
							}
						} else if (map[y][x] == "MRR")
						{
							GameObject gameObject = GameObject.Instantiate(GameObject.Find("wall"));
							gameObject.name = "x" + x.ToString() + " y" + y.ToString();
							gameObject.transform.parent = GameObject.Find("walls").transform;
							gameObject.transform.Find("BrickGround").localPosition = new Vector3(0, 0, 0);
							gameObject.transform.position = new Vector3((float)(x * 20), 15.15f, (float)(y * -20 + -9));
							gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
							gameObject.transform.position += new Vector3(-10, 0, 0);
							gameObject.transform.localScale = new Vector3(20, 30.5f, 20.4f);
							GameObject.Destroy(gameObject.transform.Find("BrickGround").gameObject);
							GameObject mirrorFrame = new GameObject("mirrorFrame");
							mirrorFrame.transform.parent = gameObject.transform;
							mirrorFrame.transform.localPosition = new Vector3(0, 0.015f, 0);
							mirrorFrame.transform.localScale = new Vector3(0.825f, 0.54f, 1);
							mirrorFrame.transform.rotation = Quaternion.Euler(0, 0, 0);
							gameObject.transform.Find("mirrorFrame").gameObject.AddComponent<SpriteRenderer>();
							gameObject.transform.Find("mirrorFrame").gameObject.GetComponent<SpriteRenderer>().sprite = Tools.getSprite("mirror.png");
							mirrorFrame.transform.localRotation = Quaternion.Euler(0, 0, 0);
							GameObject reflection = GameObject.Instantiate(Resources.Load("prefabs/map/CompositeFigurine") as GameObject);
							reflection.transform.parent = GameObject.Find("GameEnvironment").transform;
							reflection.name = "reflection";
							reflection.transform.localScale = new Vector3(25, 25, 25);
							reflection.transform.position = new Vector3((float)(x * 20), -1.5f, (float)(y * -40));
							reflection.transform.rotation = Quaternion.Euler(0, 270, 0);
							node.name = "mirror";
							reflection.GetComponent<CompositeFigurine>().Generate(RunState.Run.playerAvatarHead, RunState.Run.playerAvatarArms, RunState.Run.playerAvatarBody);
							node.GetComponent<NavigationZone3D>().events.Add(mirrorIn);
							if (config.isometricMode)
                            {
								GameObject wallcover = GameObject.Instantiate(gameObject);
								wallcover.name = "x" + x.ToString() + " y" + y.ToString() + " cover";
								wallcover.transform.parent = GameObject.Find("walls").transform;
								wallcover.transform.Find("BrickGround").localPosition = new Vector3(0, 0, 0);
								Vector3 offset = new Vector3(10, 0, 0);
								float yOffset = UnityEngine.Random.Range(0.0000f, .0150f);
								wallcover.transform.position = new Vector3(gameObject.transform.position.x, 31f + yOffset, gameObject.transform.position.z) + offset;
								wallcover.transform.localScale = new Vector3(20, 20, 1);
								wallcover.transform.localRotation = Quaternion.Euler(90, 0, 0);
								wallcover.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTextureScale = new Vector2(1, 1);
								wallcover.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.color = new Color(0.3f, 0.3f, 0.3f, 1);
								wallcover.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTexture = WallTextures.dungeon;
								wallcover.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.SetTexture("_BumpMap", WallTextures.dungeonNormal);
								wallcover.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().lightmapIndex = 1;
								GameObject.Destroy(wallcover.transform.GetChild(3).gameObject);


								GameObject ceiling = GameObject.Instantiate(GameObject.Find("DungeonFloor"));
								ceiling.name = "mirrorCeiling";
								ceiling.transform.parent = mirrorFrame.transform;

								ceiling.transform.localRotation = Quaternion.Euler(90, 0, 0);
								ceiling.transform.localPosition = new Vector3(-2.5f, 0.95f, 3);
								ceiling.transform.localScale = new Vector3(6.5f, 4.5f, 1);
								ceiling.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTextureScale = new Vector2(5, 5);

							}
						} else if (map[y][x] == "MR1")
						{
							node.GetComponent<NavigationZone3D>().events.Add(mirrorClose);
						}
						else if (map[y][x] == "MR2")
						{
							node.GetComponent<NavigationZone3D>().events.Add(mirrorExit);
						}
						/*
						if (Random.RandomRangeInt(0, 100) > 35 && RunState.Run.regionTier == 1)
						{
							GameObject theHole = GameObject.Instantiate(GameObject.Find("wall"));
							theHole.name = "x" + x.ToString() + " y" + y.ToString() + " floor";
							theHole.transform.parent = GameObject.Find("walls").transform;
							theHole.transform.Find("BrickGround").localPosition = new Vector3(0, 0, 0);
							theHole.transform.position = new Vector3((float)(x * 20), 6f, (float)(y * -20 + -9));
							theHole.transform.rotation = Quaternion.Euler(new Vector3(90, 0, 0));
							theHole.transform.localScale = new Vector3(20f, 20f, 1);
							theHole.transform.position += new Vector3(0f, 0, 0f);
							int yModif = Random.RandomRangeInt(0, 50);
							float yModif2 = yModif /= 100;
							theHole.transform.position = new Vector3(theHole.transform.position.x, 0.01f + yModif, theHole.transform.position.z);
							theHole.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.color = new Color(0.4f, 0.4f, 0.4f, 1);
							theHole.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTexture = (Resources.Load("art/generictexture3d/roughrock/Rough_rock_003_COLOR") as Texture2D);
							theHole.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.shaderKeywords = new string[0];
							node.GetComponent<NodeFootstepSound>().FootstepSound = FirstPersonController.FootstepSound.Stone;
						}
						*/
						if (cleared.Contains("x" + x + " y" + y))
						{
							if (map[y][x] == "EVN" || map[y][x] == "CR")
							{
								nodesLoaded++;
							}
							if(map[y][x].Contains("BRUNE"))
                            {
								string id = map[y][x].Split(';')[1];
								Debug.Log(id);
								node.AddComponent<RuneBattle>().runes = GameObject.Find("pedestalClue" + (id)).GetComponent<RuneHint>();
								node.GetComponent<RuneBattle>().runes.revealSolution();
							}
							continue;
						}
						switch (map[y][x])
						{
							case "S":
								GameObject icon2 = GameObject.Instantiate<GameObject>(GameObject.Find("nodeIconBase"));
								icon2.name = "nodeIcon";
								icon2.transform.localRotation = Quaternion.Euler(0, 180, 0);
								icon2.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = shopTex;
								icon2.transform.position = new Vector3(node.transform.position.x, 13f, node.transform.position.z);
								nodes.Add(icon2);
								icon2.transform.position = new Vector3(node.transform.position.x + 1f, 13f, node.transform.position.z);
								node.GetComponentInChildren<NavigationZone3D>().events.Add(Generation.shop);
								icon2.transform.parent = node.transform;
								break;
							case "B":
								icon2 = GameObject.Instantiate<GameObject>(GameObject.Find("nodeIconBase"));
								icon2.name = "nodeIcon";
								icon2.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = battleTex;
								icon2.transform.position = new Vector3(node.transform.position.x, 13f, node.transform.position.z);
								Generation.nodes.Add(icon2);
								icon2.transform.position = new Vector3(node.transform.position.x + 1f, 13f, node.transform.position.z);
								node.GetComponentInChildren<NavigationZone3D>().events.Add(Generation.cardBattle);
								icon2.transform.parent = node.transform;
								if (RunState.Run.regionTier == 0 && MagSave.layout.Contains("3"))
								{
									icon2.transform.position = new Vector3(node.transform.position.x, 34.28f, node.transform.position.z);
								}
								break;
							case "B1":
								icon2 = GameObject.Instantiate<GameObject>(GameObject.Find("nodeIconBase"));
								icon2.name = "nodeIcon";
								icon2.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = goobossTex;
								icon2.transform.position = new Vector3(node.transform.position.x, 13f, node.transform.position.z);
								Generation.nodes.Add(icon2);
								icon2.transform.position = new Vector3(node.transform.position.x + 1f, 13f, node.transform.position.z);
								node.GetComponentInChildren<NavigationZone3D>().events.Add(Generation.gooBattle);
								icon2.transform.parent = node.transform;
								break;
							case "B2":
								icon2 = GameObject.Instantiate<GameObject>(GameObject.Find("nodeIconBase"));
								icon2.name = "nodeIcon";
								icon2.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = pikebossTex;
								icon2.transform.position = new Vector3(node.transform.position.x, 13f, node.transform.position.z);
								Generation.nodes.Add(icon2);
								icon2.transform.position = new Vector3(node.transform.position.x + 1f, 13f, node.transform.position.z);
								node.GetComponentInChildren<NavigationZone3D>().events.Add(Generation.pikeBattle);
								icon2.transform.parent = node.transform;
								break;
							case "B3":
								icon2 = GameObject.Instantiate<GameObject>(GameObject.Find("nodeIconBase"));
								icon2.name = "nodeIcon";
								icon2.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = stimbossTex;
								icon2.transform.position = new Vector3(node.transform.position.x, 13f, node.transform.position.z);
								Generation.nodes.Add(icon2);
								icon2.transform.position = new Vector3(node.transform.position.x + 1f, 13f, node.transform.position.z);
								node.GetComponentInChildren<NavigationZone3D>().events.Add(Generation.stimBattle);
								icon2.transform.parent = node.transform;
								break;
							case "B4":
								GameObject.Find("MagnificusAnim").transform.position = new Vector3(node.transform.position.x + 0.575f, 25.7f, node.transform.position.z + 20);
								node.GetComponentInChildren<NavigationZone3D>().events.Add(Generation.magBattle);
								break;
							case "E":
								icon2 = GameObject.Instantiate<GameObject>(GameObject.Find("nodeIconBase"));
								icon2.name = "nodeIcon";
								icon2.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = bleachTex;
								icon2.transform.position = new Vector3(node.transform.position.x, 13f, node.transform.position.z);
								Generation.nodes.Add(icon2);
								icon2.transform.position = new Vector3(node.transform.position.x + 1f, 13f, node.transform.position.z);
								node.GetComponentInChildren<NavigationZone3D>().events.Add(Generation.bleach);
								icon2.transform.parent = node.transform;
								break;
							case "EN":
								icon2 = GameObject.Instantiate<GameObject>(GameObject.Find("nodeIconBase"));
								icon2.name = "nodeIcon";
								icon2.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = enchantTex;
								icon2.transform.position = new Vector3(node.transform.position.x, 13f, node.transform.position.z);
								Generation.nodes.Add(icon2);
								icon2.transform.position = new Vector3(node.transform.position.x + 1f, 13f, node.transform.position.z);
								node.GetComponentInChildren<NavigationZone3D>().events.Add(Generation.enchant);
								icon2.transform.parent = node.transform;
								break;
							case "EVN":
								icon2 = GameObject.Instantiate<GameObject>(GameObject.Find("nodeIconBase"));
								icon2.name = "nodeIcon";
								icon2.transform.position = new Vector3(node.transform.position.x, 13f, node.transform.position.z);
								Generation.nodes.Add(icon2);
								icon2.transform.position = new Vector3(node.transform.position.x + 1f, 13f, node.transform.position.z);
								icon2.transform.parent = node.transform;

								if (loading)
								{
									switch (allNodes[nodesLoaded])
									{
										default:
											icon2.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = bleachTex;
											node.GetComponentInChildren<NavigationZone3D>().events.Add(Generation.bleach);
											break;
										case "enchant":
											icon2.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = enchantTex;
											node.GetComponentInChildren<NavigationZone3D>().events = new List<NavigationEvent> { Generation.enchant };
											break;
										case "costchng":
											icon2.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = costchngTex;
											node.GetComponentInChildren<NavigationZone3D>().events = new List<NavigationEvent> { Generation.costChange };
											break;
										case "goobert":
											icon2.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = copyTex;
											node.GetComponentInChildren<NavigationZone3D>().events = new List<NavigationEvent> { Generation.copyCard };
											break;
										case "merge":
											icon2.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = mergeTex;
											node.GetComponentInChildren<NavigationZone3D>().events = new List<NavigationEvent> { Generation.mergeCard };
											break;
										case "spellupgrade":
											icon2.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = spellUpgradeTex;
											node.GetComponentInChildren<NavigationZone3D>().events = new List<NavigationEvent> { Generation.spellUpgrade };
											break;
										case "cauldron":
											icon2.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = cauldronTex;
											node.GetComponentInChildren<NavigationZone3D>().events = new List<NavigationEvent> { Generation.cauldronEvent };
											break;
										case "painting":
											icon2.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = paintTex;
											node.GetComponentInChildren<NavigationZone3D>().events = new List<NavigationEvent> { Generation.cardPainting };
											break;
									}
									nodesLoaded++;
									break;
								}

								int random = UnityEngine.Random.RandomRangeInt(0, 100);
								icon2.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = bleachTex;
								node.GetComponentInChildren<NavigationZone3D>().events.Add(Generation.bleach);
								if (RunState.Run.regionTier == 1)
								{
									if (random < 33)
									{
										if (!loading) { SavedVars.GeneratedEvents += "bleach;"; }
										icon2.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = bleachTex;
										node.GetComponentInChildren<NavigationZone3D>().events = new List<NavigationEvent> { Generation.bleach };
									}
									else if (random < 63)
									{
										if (!loading) { SavedVars.GeneratedEvents += "enchant;"; }
										icon2.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = enchantTex;
										node.GetComponentInChildren<NavigationZone3D>().events = new List<NavigationEvent> { Generation.enchant };
									}
									else if (random< 101)
									{
										random = UnityEngine.Random.RandomRangeInt(0, 100);
										if (random< 45)
										{
											if (!loading) { SavedVars.GeneratedEvents += "costchng;"; }
											icon2.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = costchngTex;
											node.GetComponentInChildren<NavigationZone3D>().events = new List<NavigationEvent> {Generation.costChange };
										} else
                                        {
											random = UnityEngine.Random.RandomRangeInt(0, 66);//SHITTY NESTED CODE! BUT ITS NECCESSARY
											if (SavedVars.LearnedMechanics.Contains("beatamber;"))
											{ random = UnityEngine.Random.RandomRangeInt(0, 100); }
											if (random < 35)
											{
												if (!loading) { SavedVars.GeneratedEvents += "goobert;"; }
												icon2.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = copyTex;
												node.GetComponentInChildren<NavigationZone3D>().events = new List<NavigationEvent> { Generation.copyCard };
											}
											else if (random < 66)
											{
												if (!loading) { SavedVars.GeneratedEvents += "spellupgrade;"; }
												icon2.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = spellUpgradeTex;
												node.GetComponentInChildren<NavigationZone3D>().events = new List<NavigationEvent> { Generation.spellUpgrade };
											}
											else
											{
												if (!loading) { SavedVars.GeneratedEvents += "painting;"; }
												icon2.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = paintTex;
												node.GetComponentInChildren<NavigationZone3D>().events = new List<NavigationEvent> { Generation.cardPainting };
											}
										}
									}
								} else if (RunState.Run.regionTier == 2)
                                {
									if (random < 33)
									{
										if (!loading) { SavedVars.GeneratedEvents += "bleach;"; }
										icon2.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = bleachTex;
										node.GetComponentInChildren<NavigationZone3D>().events = new List<NavigationEvent> { Generation.bleach };
									}
									else if (random < 62)
									{
										if (!loading) { SavedVars.GeneratedEvents += "enchant;"; }
										icon2.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = enchantTex;
										node.GetComponentInChildren<NavigationZone3D>().events = new List<NavigationEvent> { Generation.enchant };
									}
									else if (random < 101)
									{
										random = UnityEngine.Random.RandomRangeInt(0, 100);

										if (random < 33)
										{
											if (!loading) { SavedVars.GeneratedEvents += "costchng;"; }
											icon2.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = costchngTex;
											node.GetComponentInChildren<NavigationZone3D>().events = new List<NavigationEvent> { Generation.costChange };
										}
										else if (random < 66)
                                        {
											if (!loading) { SavedVars.GeneratedEvents += "merge;"; }
											icon2.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = mergeTex;
											node.GetComponentInChildren<NavigationZone3D>().events = new List<NavigationEvent> { Generation.mergeCard };
										} else
                                        {
											random = UnityEngine.Random.RandomRangeInt(0, 66);
											if (SavedVars.LearnedMechanics.Contains("beatlonely;"))
											{random = UnityEngine.Random.RandomRangeInt(0, 100);}
											if (random < 35)
											{
												if (!loading) { SavedVars.GeneratedEvents += "goobert;"; }
												icon2.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = copyTex;
												node.GetComponentInChildren<NavigationZone3D>().events = new List<NavigationEvent> { Generation.copyCard };
											}
											else if (random < 66)
											{
												if (!loading) { SavedVars.GeneratedEvents += "spellupgrade;"; }
												icon2.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = spellUpgradeTex;
												node.GetComponentInChildren<NavigationZone3D>().events = new List<NavigationEvent> { Generation.spellUpgrade };
											}
											else
											{
												if (!loading) { SavedVars.GeneratedEvents += "cauldron;"; }
												icon2.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = cauldronTex;
												node.GetComponentInChildren<NavigationZone3D>().events = new List<NavigationEvent> { Generation.cauldronEvent };
											}
										}
									}
								}
								else if (RunState.Run.regionTier == 3)
								{
									if (random < 28)
									{
										if (!loading) { SavedVars.GeneratedEvents += "bleach;"; }
										icon2.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = bleachTex;
										node.GetComponentInChildren<NavigationZone3D>().events = new List<NavigationEvent> { Generation.bleach };
									}
									else if (random < 50)
									{
										if (!loading) { SavedVars.GeneratedEvents += "enchant;"; }
										icon2.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = enchantTex;
										node.GetComponentInChildren<NavigationZone3D>().events = new List<NavigationEvent> { Generation.enchant };
									}
									else if (random < 101)
									{
										random = UnityEngine.Random.RandomRangeInt(0, 100);

										if (random < 32)
										{
											if (!loading) { SavedVars.GeneratedEvents += "costchng;"; }
											icon2.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = costchngTex;
											node.GetComponentInChildren<NavigationZone3D>().events = new List<NavigationEvent> { Generation.costChange };
										}
										else if (random < 60)
										{
											if (!loading) { SavedVars.GeneratedEvents += "painting;"; }
											icon2.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = paintTex;
											node.GetComponentInChildren<NavigationZone3D>().events = new List<NavigationEvent> { Generation.cardPainting };
										}
										else
										{
											random = UnityEngine.Random.RandomRangeInt(0, 100);
											if (random < 33)
											{
												if (!loading) { SavedVars.GeneratedEvents += "goobert;"; }
												icon2.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = copyTex;
												node.GetComponentInChildren<NavigationZone3D>().events = new List<NavigationEvent> { Generation.copyCard };
											}
											else if (random < 66)
											{
												if (!loading) { SavedVars.GeneratedEvents += "spellupgrade;"; }
												icon2.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = spellUpgradeTex;
												node.GetComponentInChildren<NavigationZone3D>().events = new List<NavigationEvent> { Generation.spellUpgrade };
											} else
                                            {
												if (!loading) { SavedVars.GeneratedEvents += "cauldron;"; }
												icon2.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = cauldronTex;
												node.GetComponentInChildren<NavigationZone3D>().events = new List<NavigationEvent> { Generation.cauldronEvent };
											}
										}
									}
								}
								nodesLoaded++;
								break;
							case "N1":
								if (SaveManager.saveFile.ascensionActive)
								{
									icon2 = GameObject.Instantiate<GameObject>(GameObject.Find("nodeIconBase"));
									icon2.name = "nodeIcon";
									icon2.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = draftingTex;
									icon2.transform.position = new Vector3(node.transform.position.x, 13f, node.transform.position.z);
									Generation.nodes.Add(icon2);
									icon2.transform.position = new Vector3(node.transform.position.x + 1f, 13f, node.transform.position.z);
									node.GetComponentInChildren<NavigationZone3D>().events.Add(Generation.drafting);
									icon2.transform.parent = node.transform;
								} else
                                {
									icon2 = GameObject.Instantiate<GameObject>(GameObject.Find("nodeIconBase"));
									icon2.name = "nodeIcon";
									icon2.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = cardTex;
									icon2.transform.position = new Vector3(node.transform.position.x, 13f, node.transform.position.z);
									Generation.nodes.Add(icon2);
									icon2.transform.position = new Vector3(node.transform.position.x + 1f, 13f, node.transform.position.z);
									node.GetComponentInChildren<NavigationZone3D>().events.Add(Generation.cardSelect);
									icon2.transform.parent = node.transform;
								}
								break;
							case "N2":
								if (SaveManager.saveFile.ascensionActive)
								{
									icon2 = GameObject.Instantiate<GameObject>(GameObject.Find("nodeIconBase"));
									icon2.name = "nodeIcon";
									icon2.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = draftingTex;
									icon2.transform.position = new Vector3(node.transform.position.x, 13f, node.transform.position.z);
									Generation.nodes.Add(icon2);
									icon2.transform.position = new Vector3(node.transform.position.x + 1f, 13f, node.transform.position.z);
									node.GetComponentInChildren<NavigationZone3D>().events.Add(Generation.drafting);
									icon2.transform.parent = node.transform;
								}
								break;
							case "C":
								icon2 = GameObject.Instantiate<GameObject>(GameObject.Find("nodeIconBase"));
								icon2.name = "nodeIcon";
								icon2.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = cardTex;
								icon2.transform.position = new Vector3(node.transform.position.x, 13f, node.transform.position.z);
								Generation.nodes.Add(icon2);
								icon2.transform.position = new Vector3(node.transform.position.x + 1f, 13f, node.transform.position.z);
								node.GetComponentInChildren<NavigationZone3D>().events.Add(Generation.cardSelect);
								icon2.transform.parent = node.transform;
								break;
							case "FC":
								bool hasEdaxio = false;
								foreach (CardInfo card in RunState.Run.playerDeck.Cards)
								{
									if (card.name == "mag_edaxioarms")
									{
										hasEdaxio = true;
									}
								}
								if (hasEdaxio)
                                {
									icon2 = GameObject.Instantiate<GameObject>(GameObject.Find("nodeIconBase"));
									icon2.name = "nodeIcon";
									icon2.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = edaxioTex;
									icon2.transform.position = new Vector3(node.transform.position.x, 13f, node.transform.position.z);
									nodes.Add(icon2);
									icon2.transform.position = new Vector3(node.transform.position.x + 1f, 13f, node.transform.position.z);
									node.GetComponentInChildren<NavigationZone3D>().events.Add(Generation.edaxioNode);
									icon2.transform.parent = node.transform;
								} else
                                {
									icon2 = GameObject.Instantiate<GameObject>(GameObject.Find("nodeIconBase"));
									icon2.name = "nodeIcon";
									icon2.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = spellTex;
									icon2.transform.position = new Vector3(node.transform.position.x, 13f, node.transform.position.z);
									Generation.nodes.Add(icon2);
									icon2.transform.position = new Vector3(node.transform.position.x + 1f, 13f, node.transform.position.z);
									node.GetComponentInChildren<NavigationZone3D>().events.Add(Generation.spellSelect);
									icon2.transform.parent = node.transform;
								}
								break;
							case "CC":
								icon2 = GameObject.Instantiate<GameObject>(GameObject.Find("nodeIconBase"));
								icon2.name = "nodeIcon";
								icon2.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = costTex;
								icon2.transform.position = new Vector3(node.transform.position.x, 13f, node.transform.position.z);
								Generation.nodes.Add(icon2);
								icon2.transform.position = new Vector3(node.transform.position.x + 1f, 13f, node.transform.position.z);
								node.GetComponentInChildren<NavigationZone3D>().events.Add(Generation.costSelect);
								icon2.transform.parent = node.transform;
								break;
							case "CS":
								icon2 = GameObject.Instantiate<GameObject>(GameObject.Find("nodeIconBase"));
								icon2.name = "nodeIcon";
								icon2.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = spellTex;
								icon2.transform.position = new Vector3(node.transform.position.x, 13f, node.transform.position.z);
								Generation.nodes.Add(icon2);
								icon2.transform.position = new Vector3(node.transform.position.x + 1f, 13f, node.transform.position.z);
								node.GetComponentInChildren<NavigationZone3D>().events.Add(Generation.spellSelect);
								icon2.transform.parent = node.transform;
								break;
							case "CR":
								icon2 = GameObject.Instantiate<GameObject>(GameObject.Find("nodeIconBase"));
								icon2.name = "nodeIcon";
								icon2.transform.position = new Vector3(node.transform.position.x, 13f, node.transform.position.z);
								Generation.nodes.Add(icon2);
								icon2.transform.position = new Vector3(node.transform.position.x + 1f, 13f, node.transform.position.z);
								icon2.transform.parent = node.transform;
								int rand = UnityEngine.Random.RandomRangeInt(0, 100);
								if (loading)
                                {
									switch(allNodes[nodesLoaded])
                                    {
										case "spellselect":
											icon2.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = spellTex;
											node.GetComponentInChildren<NavigationZone3D>().events.Add(Generation.spellSelect);
											break;
										case "costselect":
											icon2.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = costTex;
											node.GetComponentInChildren<NavigationZone3D>().events.Add(Generation.costSelect);
											break;
										default:
											icon2.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = cardTex;
											node.GetComponentInChildren<NavigationZone3D>().events.Add(Generation.cardSelect);
											break;
									}
									nodesLoaded++;
									break;
                                }
								if (rand < 7)
								{
									icon2.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = spellTex;
									node.GetComponentInChildren<NavigationZone3D>().events.Add(Generation.spellSelect);
									if (!loading) { SavedVars.GeneratedEvents += "spellselect;"; }
								} else if (rand < 34)
								{
									icon2.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = costTex;
									node.GetComponentInChildren<NavigationZone3D>().events.Add(Generation.costSelect);
									if (!loading) { SavedVars.GeneratedEvents += "costselect;"; }
								}
								else if (rand < 101)
								{
									icon2.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = cardTex;
									node.GetComponentInChildren<NavigationZone3D>().events.Add(Generation.cardSelect);
									if (!loading) { SavedVars.GeneratedEvents += "cardselect;"; }
								}
								nodesLoaded++;
								break;
							case "T1":
							case "T2":
							case "T3":
								GameObject goobertWarp = GameObject.Instantiate<GameObject>(ResourceBank.Get<GameObject>("prefabs/factoryindoors/GemPedestal3D"));
								goobertWarp.AddComponent<BossTeleporter3D>();
								goobertWarp.transform.parent = GameObject.Find("GameEnvironment").transform;
								goobertWarp.transform.position = new Vector3((float)(x * 20), 5.4975f, (float)(y * -20));
								goobertWarp.transform.rotation = Quaternion.Euler(0, 270, 0);
								goobertWarp.transform.Find("Rotators").gameObject.SetActive(false);
								goobertWarp.transform.Find("Shadow").gameObject.SetActive(true);
								goobertWarp.transform.Find("Shadow").gameObject.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0, 1);
								goobertWarp.transform.Find("Shadow").localRotation = Quaternion.Euler(90, 0, 0);
								goobertWarp.transform.Find("Shadow").position = new Vector3(80f, 0f, -80);
								goobertWarp.transform.Find("Gem").gameObject.SetActive(false);
								goobertWarp.transform.localScale = new Vector3(1, 1, 1);
								string prefab = "emeraldMoxPref";
								Color lightColor = new Color(0.8f, 1, 0.8f, 1);
								if (map[y][x] == "T2")
                                {
									prefab = "rubyMoxPref";
									lightColor = new Color(1f, 0.9f, 0.8f, 1);
								} else if (map[y][x] == "T3")
								{
									prefab = "sapphireMoxPref";
									lightColor = new Color(0.8f, 0.8f, 0.1f, 1);
								}
								GameObject mox = GameObject.Instantiate(GameObject.Find(prefab));
								mox.name = "pedestalMox";
								mox.transform.parent = goobertWarp.transform;
								mox.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
								if (map[y][x] == "T3")
                                {
									mox.transform.localScale = new Vector3(1.8f, 1.8f, 1.8f);
								}
								mox.transform.localPosition = new Vector3(0, 13.63f, 0);

								GameObject frontMox = GameObject.Instantiate(mox);
								frontMox.transform.parent = goobertWarp.transform;
								frontMox.transform.localPosition = new Vector3(-2.15f, 5f, 0);
								frontMox.transform.localRotation = Quaternion.Euler(new Vector3(0, 90, 0));
								frontMox.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
								frontMox.transform.Find("Gem").gameObject.GetComponent<MeshRenderer>().material = (Resources.Load("art/assets3d/gametable/robomodules/Unlit_Gems") as Material);

								mox.AddComponent<SineWaveMovement>();
								mox.GetComponent<SineWaveMovement>().originalPosition = new Vector3(0, 13.63f, 0);
								mox.GetComponent<SineWaveMovement>().speed = 1;
								mox.GetComponent<SineWaveMovement>().yMagnitude = 1;
								mox.AddComponent<Light>().shadows = LightShadows.Hard;
								mox.GetComponent<Light>().type = LightType.Point;
								mox.GetComponent<Light>().intensity = 1;
								mox.GetComponent<Light>().range = 250;
								mox.GetComponent<Light>().color = lightColor;
								if (map[y][x] == "T3") { mox.GetComponent<Light>().range = 200; }
								mox.GetComponent<Light>().color = new Color(1, 1, 1, 1);
								goobertWarp.GetComponent<ActiveIfStoryFlag>().enabled = false;
								goobertWarp.SetActive(true);
								GameObject.Destroy(node.GetComponent<NavigationZone3D>());
								nodes.Add(mox);
								goobertWarp.transform.Find("Shadow").position = new Vector3(80, 0.01f, -80);
								goobertWarp.transform.Find("Shadow").localScale = new Vector3(30, 30, 42);
								break;
							case "T21":
							case "T22":
								GameObject bossWarp = GameObject.Instantiate<GameObject>(ResourceBank.Get<GameObject>("prefabs/factoryindoors/GemPedestal3D"));
								bossWarp.AddComponent<BossTeleporter3D>();
								GemPedestal3D instance = bossWarp.GetComponent<GemPedestal3D>();
								List<MagnificusMod.BossPedestalRotator> rotators2 = new List<MagnificusMod.BossPedestalRotator>();
								for (int i = 0; i < 3; i++)
								{
									GameObject rotator = bossWarp.gameObject.transform.Find("Rotators").GetChild(i).gameObject;
									rotator.AddComponent<MagnificusMod.BossPedestalRotator>();

									List<Texture> textureOverrides = new List<Texture>(rotator.GetComponent<GemPedestalRotator3D>().iconTextures);

									textureOverrides[1] = Singleton<MagnificusMod.BossTeleporter3D>.Instance.textureOverrides[0];
									textureOverrides[6] = Singleton<MagnificusMod.BossTeleporter3D>.Instance.textureOverrides[1];
									textureOverrides[7] = Singleton<MagnificusMod.BossTeleporter3D>.Instance.textureOverrides[2];
									textureOverrides[9] = Singleton<MagnificusMod.BossTeleporter3D>.Instance.textureOverrides[3];
									textureOverrides[11] = Singleton<MagnificusMod.BossTeleporter3D>.Instance.textureOverrides[4];

									rotator.GetComponent<MagnificusMod.BossPedestalRotator>().iconTextures = textureOverrides;

									rotator.GetComponent<MagnificusMod.BossPedestalRotator>().startIndex = Random.RandomRangeInt(0, rotator.GetComponent<MagnificusMod.BossPedestalRotator>().iconTextures.Count);
									rotator.GetComponent<MagnificusMod.BossPedestalRotator>().IconIndex = rotator.GetComponent<MagnificusMod.BossPedestalRotator>().startIndex;

									rotator.GetComponent<MagnificusMod.BossPedestalRotator>().rotator = instance.gameObject.transform.Find("Rotators").GetChild(i).gameObject.GetComponent<GemPedestalRotator3D>().rotator;
									rotator.GetComponent<MagnificusMod.BossPedestalRotator>().iconRenderers = instance.gameObject.transform.Find("Rotators").GetChild(i).gameObject.GetComponent<GemPedestalRotator3D>().iconRenderers;
									rotator.GetComponent<MagnificusMod.BossPedestalRotator>().startIndex = instance.gameObject.transform.Find("Rotators").GetChild(i).gameObject.GetComponent<GemPedestalRotator3D>().startIndex;
									rotator.GetComponent<GemPedestalRotator3D>().enabled = false;

									rotator.transform.Find("Icon_1").gameObject.GetComponent<MeshRenderer>().material.mainTexture = rotator.GetComponent<MagnificusMod.BossPedestalRotator>().iconTextures[rotator.GetComponent<MagnificusMod.BossPedestalRotator>().startIndex];

									rotators2.Add(rotator.GetComponent<MagnificusMod.BossPedestalRotator>());
								}
								rotators2.ForEach(delegate (MagnificusMod.BossPedestalRotator x)
								{
									x.Rotated = (Action)Delegate.Combine(x.Rotated, new Action(instance.OnAnyRotatorPressed));
									x.UpdateIcon();
								});
								bossWarp.GetComponent<BossTeleporter3D>().rotators2 = rotators2;
								bossWarp.GetComponent<BossTeleporter3D>().Solution = SavedVars.BossTeleportSolution;
								bossWarp.transform.parent = GameObject.Find("GameEnvironment").transform;
								bossWarp.transform.position = new Vector3((float)(x * 20), 5.4975f, (float)(y * -20));
								bossWarp.transform.rotation = Quaternion.Euler(0, 270, 0);
								//bossWarp.transform.Find("Rotators").gameObject.SetActive(false);
								bossWarp.transform.Find("Shadow").gameObject.SetActive(false);
								bossWarp.transform.Find("Gem").gameObject.SetActive(false);
								bossWarp.transform.localScale = new Vector3(1, 1, 1);
								prefab = "emeraldMoxPref";
								if (map[y][x] == "T21")
								{
									prefab = "rubyMoxPref";
								} else if (map[y][x] == "T22")
								{
									prefab = "sapphireMoxPref";
								}
								mox = GameObject.Instantiate(GameObject.Find(prefab));
								mox.name = "pedestalMox";
								mox.transform.parent = bossWarp.transform;
								mox.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
								mox.transform.localPosition = new Vector3(0, 13.63f, 0);
								mox.AddComponent<SineWaveMovement>();
								mox.GetComponent<SineWaveMovement>().originalPosition = new Vector3(0, 13.63f, 0);
								mox.GetComponent<SineWaveMovement>().speed = 1;
								mox.GetComponent<SineWaveMovement>().yMagnitude = 1;
								bossWarp.GetComponent<ActiveIfStoryFlag>().enabled = false;
								bossWarp.SetActive(true);
								GameObject.Destroy(node.GetComponent<NavigationZone3D>());
								nodes.Add(mox);
								bossWarp.name = "bossTeleporter";
								GameObject nodeName = new GameObject("x" + x + "y" + y);
								nodeName.transform.parent = bossWarp.transform;
								break;
							case "TR1":
								node.GetComponentInChildren<NavigationZone3D>().events.Add(Generation.towerWarp);
								break;
							case "TR2":
								node.GetComponentInChildren<NavigationZone3D>().events.Add(Generation.towerWarpTwo);
								break;
							case "TR3":
								node.GetComponentInChildren<NavigationZone3D>().events.Add(Generation.towerWarpThree);
								break;
							case "TR4":
								node.GetComponentInChildren<NavigationZone3D>().events.Add(Generation.finalWarp);
								break;
							case "1v1":
								node.GetComponentInChildren<NavigationZone3D>().events.Add(Generation.leshyCardDialogue);
								break;
							case "MXPDG":
								node.GetComponentInChildren<NavigationZone3D>().events.Add(Generation.pedestalGuide);
								break;
							case "SPWN":
								node.AddComponent<OcclusionArea>();
								break;
							case "MAGNR":
								
								node.GetComponentInChildren<NavigationZone3D>().events.Add(Generation.gameOver);
								break;
							case "EXTD":
								GameObject gameObject = GameObject.Instantiate(GameObject.Find("wall"));
								gameObject.name = "door";
								gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.shaderKeywords = new string[0];
								gameObject.transform.Find("BrickGround").localPosition = new Vector3(0, 0, 0);
								gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTextureOffset = new Vector2(0, 0);
								gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTextureScale = new Vector2(1, 1);
								gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1, 0);
								gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTexture = WallTextures.none;
								gameObject.transform.position = new Vector3((float)(x * 20), 4.72f, (float)(y * -20 + -9));
								gameObject.transform.localScale = new Vector3(7.25f, 10, 1);
								gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
								Generation.nodes.Add(gameObject);
								break;
						}
						if (map[y][x].Contains("BL"))
                        {
							string[] ah = map[y][x].Split('L');
							string group = ah[1];
							GameObject icon2 = GameObject.Instantiate<GameObject>(GameObject.Find("nodeIconBase"));
							if (!connectedNodes.Contains(group))
                            {
								connectedNodes.Add(group);
								connectedNodes.Add("N1");
                            } else
                            {
								int num = int.Parse(connectedNodes[connectedNodes.IndexOf(group) + 1].Split('N')[1]);
								num++;
								connectedNodes[connectedNodes.IndexOf(group) + 1] = "N" + num;

							}
							string connectNodeNum = connectedNodes[connectedNodes.IndexOf(group) + 1].ToString();
							icon2.name = "nodeIconBL" + group + ";" + connectNodeNum;
							icon2.AddComponent<conectedNodes>();
							icon2.GetComponent<conectedNodes>().group = int.Parse(group);
							icon2.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = battleTex;
							icon2.transform.position = new Vector3(node.transform.position.x, 13f, node.transform.position.z);
							Generation.nodes.Add(icon2);
							icon2.transform.position = new Vector3(node.transform.position.x + 1f, 13f, node.transform.position.z);
							node.GetComponentInChildren<NavigationZone3D>().events.Add(Generation.cardBattle);
							icon2.transform.parent = node.transform;
						}
						else if (map[y][x].Contains("BRUNE"))
						{
							string id = map[y][x].Split(';')[1];
							Debug.Log("brune id: " + id);
							GameObject icon2 = GameObject.Instantiate<GameObject>(GameObject.Find("nodeIconBase"));
							icon2 = GameObject.Instantiate<GameObject>(GameObject.Find("nodeIconBase"));
							icon2.name = "nodeIcon";
							icon2.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = bleachbattleTex;
							icon2.transform.position = new Vector3(node.transform.position.x, 13f, node.transform.position.z);
							Generation.nodes.Add(icon2);
							icon2.transform.position = new Vector3(node.transform.position.x + 1f, 13f, node.transform.position.z);
							node.GetComponentInChildren<NavigationZone3D>().events.Add(Generation.bleachBattle);
							icon2.transform.parent = node.transform;
							node.AddComponent<RuneBattle>().runes = GameObject.Find("pedestalClue" + (id)).GetComponent<RuneHint>();
						}
					}
				}
			}

			if (RunState.Run.regionTier == 1)
			{
				GameObject lanterns = new GameObject("lights");
				lanterns.transform.parent = GameObject.Find("scenery").transform;
				lanterns.transform.localPosition = new Vector3(0, 0, 0);
				for (int y = 0; y < size[1] / 7; y++)
				{
					for (int x = 0; x < map[y].Count / 4; x++)
					{
						GameObject lantern = GameObject.Instantiate(GameObject.Find("LightSource"));
						lantern.transform.parent = lanterns.transform;
						lantern.transform.position = new Vector3(x * 140 + 60, -16f, y * -140 + -60);
						lantern.transform.localScale = new Vector3(2, 2, 2);

					}
				}
			}else if (RunState.Run.regionTier == 2 || RunState.Run.regionTier == 3)
            {
				string nodename = GameObject.Find("bossTeleporter").transform.GetChild(5).gameObject.name;
				string[] namey = nodename.Split('x');
				string[] namei = namey[1].Split('y');
				int newY = int.Parse(namei[1]);
				int targetY = int.Parse(namei[1]);
				newY += 1;
				targetY -= 5;
				GameObject.Find("bossTeleporter").transform.Find("Rotators").Find("ZoomInteractable").gameObject.GetComponent<ZoomInteractable>().interactableFromDirections = new List<LookDirection> { LookDirection.North };
				if (config.isometricActive)
                {
					GameObject.Find("bossTeleporter").transform.Find("Rotators").Find("ZoomInteractable").gameObject.GetComponent<ZoomInteractable>().interactableFromDirections = new List<LookDirection> { LookDirection.North, LookDirection.East, LookDirection.South, LookDirection.West };
				}
				GameObject.Find("bossTeleporter").transform.Find("Rotators").Find("ZoomInteractable").gameObject.GetComponent<ZoomInteractable>().interactableFromZones.Add(GameObject.Find("x" + namei[0] + " y" + newY).GetComponent<NavigationZone3D>());
				GameObject.Find("bossTeleporter").GetComponent<GemPedestal3D>().teleportTarget = GameObject.Find("x" + namei[0] + " y" + targetY).GetComponent<NavigationZone3D>();
				GameObject.Find("bossTeleporter").GetComponent<GemPedestal3D>().teleportReturnTarget = GameObject.Find("x" + namei[0] + " y" + newY).GetComponent<NavigationZone3D>();
				for (int i = 1; i < 5; i++)
                {
					GameObject.Find("Rotator_Top").transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1, 1);
					GameObject.Find("Rotator_Mid").transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1, 1);
					GameObject.Find("Rotator_Bot").transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1, 1);
				}
				if (RunState.Run.regionTier == 2)
				{
					GameObject lanterns = new GameObject("lanterns");
					lanterns.transform.parent = GameObject.Find("scenery").transform;
					lanterns.transform.localPosition = new Vector3(0, 0, 0);
					for (int y = 0; y < size[1] / 7;  y++)
                    {
						for (int x = 0; x < (map[y].Count / 4) + 1; x++)
                        {
							GameObject lantern = GameObject.Instantiate(GameObject.Find("Lantern"));
							lantern.transform.parent = lanterns.transform;
							lantern.transform.position = new Vector3(x * 140 + 60, 25f, y * -140 + -60);
							lantern.transform.localScale = new Vector3(2, 2, 2);

						}
                    }
				}
			}
			yield break;
		}

		public static void makePedestalClue(GameObject pedestalSprite, int pedestalClues)
        {
			pedestalSprite.transform.localRotation = Quaternion.Euler(0, 0, 0);
			int[] solution = SavedVars.BossTeleportSolution;
			int solutionSprite = solution[pedestalClues];
			pedestalSprite.transform.localScale = new Vector3(6, 6, 6);
			string solutionName = Singleton<GemPedestalRotator3D>.Instance.iconTextures[solutionSprite].name;
			if (solutionName.Contains("_black"))
			{
				string[] splitName = solutionName.Split(new string[] { "_black" }, StringSplitOptions.None);
				solutionName = splitName[0] + splitName[1];
			}
			pedestalSprite.GetComponent<SpriteRenderer>().sprite = (RunState.Run.regionTier != 3) ? Tools.getSprite(solutionName + ".png") : Tools.getSprite("puzzlehint_unknown.png");
		}

		public static void makeBattleRoom(List<List<string>> map)
		{
			int[] size = { 0, 0 };
			size[1] = map.Count;
			int length = 0;
			for (int i = 0; i < map.Count; i++)
			{
				if (map[i].Count > length)
				{
					length = map[i].Count;
				}
			}
			size[0] = length;
			GameObject battleRoom = GameObject.Instantiate(new GameObject());
			battleRoom.name = "battleRoom";
			for (int y = 0; y < size[1]; y++)
			{
				for (int x = 0; x < map[y].Count; x++)
				{
					if (map[y][x][0] == 'W')
					{
						GameObject gameObject = GameObject.Instantiate(GameObject.Find("wall"));
						gameObject.name = "x" + x.ToString() + " y" + y.ToString();
						gameObject.transform.parent = GameObject.Find("battleRoom").transform;
						gameObject.transform.Find("BrickGround").localPosition = new Vector3(0, 0, 0);
						gameObject.transform.position = new Vector3((float)(x * 20), 6f, (float)(y * -20 + -9));
						switch (map[y][x][1])//THIS IS THE BATTLE ROOM DUNNY
						{
							case 'n':
								gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.color = new Color(0f, 0f, 0f, 1);
								gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTexture = WallTextures.none;
								gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.shaderKeywords = new string[0];
								break;
							case 'g':
								gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.color = new Color(0.51f, 1f, 0.51f, 1);
								gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTexture = WallTextures.goo;
								gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.SetTexture("_BumpMap", WallTextures.gooNormal);
								break;
							case '0':
								//gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTexture = Tools.getImage("brickwall.png");
								break;
							case '1':
								gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.color = new Color(0.51f, 0.5266001f, 0.51f, 1);
								break;
							case '2':
								gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.color = new Color(0.51f, 0.5266001f, 0.51f, 1);
								GameObject gooWall = new GameObject("GooWall");
								gooWall.transform.parent = gameObject.transform;
								gooWall.AddComponent<SpriteRenderer>();
								int rand = Random.RandomRangeInt(0, 11);
								gooWall.GetComponent<SpriteRenderer>().sprite = WallTextures.gooDrips[rand];
								gooWall.transform.localScale = new Vector3(0.137f, 0.063f, 0.1f);
								if (rand != 9 && rand != 10)
								{
									gooWall.GetComponent<SpriteRenderer>().color = new Color(0.5f, 1, 0.5f, 1);
								}
								gooWall.transform.localPosition = new Vector3(0, 0.18f, 0f);
								switch (map[y][x][2])
								{
									case 'N':
										gooWall.transform.localPosition = new Vector3(0, 0.175f, -0.01f);
										break;
									case 'S':
										gooWall.transform.localPosition = new Vector3(0, 0.175f, -0.01f);
										break;
									case 'W':
										gooWall.transform.localPosition = new Vector3(-0, 0.175f, 0.01f);
										break;
									case 'E':
										gooWall.transform.localPosition = new Vector3(0, 0.175f, -0.01f);
										break;
								}
								break;
							case '3':
								//1 0.7487 0.1241 1
								gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.color = new Color(1f, 0.7487f, 0.1241f, 1);
								break;
							case '4':
								gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.color = new Color(0.3f, 0.3f, 0.3f, 1);
								gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTexture = WallTextures.dungeon;
								gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.SetTexture("_BumpMap", WallTextures.dungeonNormal);
								break;
							case '5':
								gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTexture = WallTextures.lava;
								gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTextureOffset = new Vector2(0, 0);
								gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.SetTexture("_BumpMap", WallTextures.lavaNormal);
								break;
							case '8':
								gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.color = new Color(1f, 1f, 1f, 1);
								gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTexture = WallTextures.bookShelf;
								gameObject.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.shaderKeywords = new string[0];
								break;
						}
						switch (map[y][x][2])
						{
							case 'N':
								gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
								break;
							case 'S':
								gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
								gameObject.transform.position += new Vector3(0, 0, 10);
								break;
							case 'E':
								gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 270, 0));
								gameObject.transform.position -= new Vector3(-10, 0, 0);
								break;
							case 'W':
								gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
								gameObject.transform.position += new Vector3(-10, 0, 0);
								break;
							case 'C':
								for (int i = 0; i < 4; i++)
								{
									GameObject wall = GameObject.Instantiate(gameObject);
									wall.transform.rotation = Quaternion.Euler(new Vector3(0, 90 * i, 0));
									wall.transform.parent = GameObject.Find("battleRoom").transform;
									wall.transform.position = new Vector3((float)(x * 20), 6f, (float)(y * -20 + -9));
									if (i == 3)
									{
										wall.transform.position += new Vector3(10, 0, 0);
									}
									else if (i == 1)
									{
										wall.transform.position -= new Vector3(10, 0, 0);
									}
									else if (i == 2)
									{
										wall.transform.position += new Vector3(0, 0, 10);
									} else if (i == 0)
                                    {
										wall.transform.position -= new Vector3(0, 0, 10);
									}
								}
								break;
						}
					}
				}
			}

			battleRoom.transform.position = new Vector3(0, -100, 0);
		}

            public static void makeLayer(int layers)
		{
			for (int i = 1; i < layers; i++)
			{
				GameObject walls = GameObject.Instantiate(GameObject.Find("walls"));
				int oi = i + 1;
				walls.name = "walls layer " + oi;
				walls.transform.position = new Vector3(0, 50, 0);
				walls.transform.parent = GameObject.Find("GameEnvironment").transform;
			}
		}


		[HarmonyPatch(typeof(Scales3D), "AddDamage")]
		public class afasfadfefrgbdsgfdbf
		{
			public static bool Prefix(ref int damage, int numWeights, bool toPlayer, GameObject alternatePrefab)
			{
				if (SceneLoader.ActiveSceneName == "finale_magnificus")
				{
					Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(LifeManagerStuff(damage, toPlayer));
					return false;
				}
				if (toPlayer) {
					Singleton<LifeManager>.Instance.PlayerDamage += damage;
				} else
                {
					Singleton<LifeManager>.Instance.OpponentDamage += damage;
				}
				return true;
			}


		}



		public static IEnumerator LifeManagerStuff(int damage, bool toPlayer)
		{
			Singleton<ViewManager>.Instance.SwitchToView(View.Default, false, false);
			if (SaveManager.saveFile.ascensionActive && MagnificusMod.Generation.challenges.Contains("ShieldedMox") && !toPlayer && damage > 4)
			{
				ChallengeActivationUI.TryShowActivation(KayceeFixes.ChallengeManagement.ShieldedMox);
				damage = 4;
			}
			for (int i = 0; i < damage; i++)
			{
				if (toPlayer)
				{
					Singleton<MagnificusLifeManager>.Instance.playerLife--;
				}
				else
				{
					Singleton<MagnificusLifeManager>.Instance.opponentLife--;
				}
				(toPlayer ? Singleton<MagnificusLifeManager>.Instance.playerLifeCounter : Singleton<MagnificusLifeManager>.Instance.opponentLifeCounter).ShowValue(toPlayer ? Singleton<MagnificusLifeManager>.Instance.playerLife : Singleton<MagnificusLifeManager>.Instance.opponentLife, false);
				float wait = 0.12f;
				if (damage >= 4) { wait = 0.08f; }
				yield return new WaitForSeconds(wait);
			}
			yield break;
		}

		[HarmonyPatch(typeof(Part1GameFlowManager), "Awake")]
		public class cabinZonething0
		{
			public static void Prefix(ref Part1GameFlowManager __instance)
			{
				WeightUtil.part1Prefab = GameObject.Find("CurrencyBowl").transform.Find("Weights").Find("Weight").gameObject;
				Singleton<CombatPhaseManager3D>.Instance.weightPrefab = GameObject.Find("CurrencyBowl").transform.Find("Weights").Find("Weight").gameObject;

				
			}
		}
		


		[HarmonyAfter(new string[]{"cyantist.inscryption.api"})]
		[HarmonyPatch(typeof(MagnificusGameFlowManager), "Awake")]
		public class cabinZonething2
		{
			public static bool Prefix(ref MagnificusGameFlowManager __instance)
			{
				setupStuff setup = new setupStuff();

				SaveManager.saveFile.currentScene = "finale_magnificus";

				Dictionary<string, string> autocorrect = new Dictionary<string, string> { { "Wolf", "" }, { "Stinkbug_Talking", "" }, { "Bullfrog", "" }, { "mag_magepupil", "Pupil" }, { "mag_jrsage", "JuniorSage" }, { "mag_rubygolem", "RubyGolem" }, { "mag_hovermage", "FlyingMage" },
				{"mag_bluemage", "BlueMage"}, {"mag_sporebluemage", "BlueMage_Fused"}, {"mag_musclemage", "MuscleMage"}, {"mag_greenmage", "GreenMage"}, {"mag_forcemage", "ForceMage"}, {"mag_gemfiend", "GemFiend"}, {"mag_knightmage", "MageKnight"}, {"mag_orangemage", "OrangeMage"}, {"mag_practicemage", "PracticeMage"}, {"mag_stimmage", "StimMage"}, 
					{"mag_mastergo", "MasterGoranj"}, {"mag_masterbg", "MasterBleene"}, {"mag_masterob", "MasterOrlu"}, {"mag_bleenemox", "DualMoxBG"}, {"mag_goranjmox", "DualMoxGO"}, {"mag_gemfrog", "mag_moxmage"}, {"mag_orlumox", "DualMoxOB"}, { "mag_rascal", "mag_astralprojector" }, { "mag_drake", "MasterGoranj" } };
	
				for (int i = 0; i < RunState.Run.playerDeck.cardIds.Count; i++)
				{
					if (autocorrect.ContainsKey(RunState.Run.playerDeck.cardIds[i]))
					{
						
						string name = (RunState.Run.playerDeck.cardIds[i]);
						RunState.Run.playerDeck.cardIds.Remove(name);

						if (autocorrect[name] == "") { continue; }

						RunState.Run.playerDeck.cardIds.Add(autocorrect[name]);

						int count = RunState.Run.playerDeck.cardIds.Where(x => x.Equals(autocorrect[name])).Count();

						string keyName = name;
						if (count > 1) { keyName += "#" + (count - 1); }

						i--;
						if (!RunState.Run.playerDeck.cardIdModInfos.ContainsKey(keyName)) { continue; }

						List<CardModificationInfo> modValues = RunState.Run.playerDeck.cardIdModInfos[keyName];
						RunState.Run.playerDeck.cardIdModInfos.Remove(keyName);

						RunState.Run.playerDeck.cardIdModInfos.Add(autocorrect[name] + "#" + (count - 1), modValues);
					}

				}

				IsometricStuff.moveDisabled = false;
				CardPileFixes.setUpSacrificeMarker = false;
				MenuButtonFixes.viewingDeck = false;

				if (SaveManager.saveFile.currentScene == "Part1_Cabin") { return false; }
				if (!setupSfx)
				{
					foreach (AudioClip clip in addedSfx)
					{
						AudioController.Instance.Loops.Add(clip);
					}
					foreach (AudioClip clip in voiceClips)
					{
						AudioController.Instance.SFX.Add(clip);
					}
					setupSfx = true;
				}
				allcardssummoned = false;
				__instance.startInFirstPerson = false;

				//load all the stuff


				GameObject sacrificeMarker = GameObject.Instantiate(Resources.Load("prefabs/cards/SacrificeMarker") as GameObject);
				sacrificeMarker.name = "MagSacrificeMarker";

				//GameObject.Find("CardElements").transform.Find("CardAbilityIcons_Part3").Find("DefaultIcons_4Abilities").Find("Ability_4").gameObject.GetComponent<BoxCollider>().size = new Vector3(3, 3, 3);
				GameObject map = GameObject.Instantiate(new GameObject());
				map.name = "mapReal";
				map.AddComponent<GameMap>();
				map.AddComponent<TableRuleBook>();
				map.AddComponent<InscryptionAPI.Card.OpponentGemsManager>();
				map.AddComponent<ConduitCircuitManager>();
				map.SetActive(true);

				GameObject.Find("FirstPersonController").name = "Player";
				GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().enabled = false;
				GameObject.Find("Player").GetComponentInChildren<ViewManager>().CurrentView = View.FirstPerson;
				GameObject.Find("Player").GetComponentInChildren<ViewManager>().enabled = false;
				GameObject.Find("Player").GetComponentInChildren<ViewController>().enabled = false;
				Singleton<FirstPersonController>.Instance.enabled = false;

				GameObject environment = GameObject.Find("Environment");
				environment.transform.position = new Vector3(-1000.1f, -1000.94f, -1000.8f);
				environment.name = "MagnificusEnvironment";//this goes above everything
				Generation.nodes = new List<GameObject>();


				//setup battle
				setup.setupBattleStuff();

				//setup table
				setup.setupTable();

				//setup nodes
				setup.setupNodes();

				//make the room deco objects
				setup.setupCustomObjects();

				//setup cardrenderer
				setup.setupCardDisplayers();


				//setup spell card pile
				/*
				GameObject spellCardDrawPile = GameObject.Instantiate(__instance.duelDiskParent.transform.Find("CardDrawPiles").gameObject);
				spellCardDrawPile.name = "SpellCardDrawPiles";
				spellCardDrawPile.transform.parent = __instance.duelDiskParent.transform;
				GameObject.Destroy(spellCardDrawPile.GetComponent<MagnificusCardDrawPiles>());
				spellCardDrawPile.AddComponent<SpellCardDrawPiles>();
				*/

				GameObject.Destroy(GameObject.Find("DeckReviewCardArray"));
				GameObject.Instantiate(Resources.Load("prefabs/cards/DeckReviewCardArray_Part1")).name = "DeckReviewCardArray";
				//generate tower

				GameObject wall = GameObject.Instantiate<GameObject>(GameObject.Find("MagnificusSceneGround"));
				wall.name = "wall";
				wall.transform.parent = GameObject.Find("MagnificusEnvironment").transform;
				wall.transform.Find("Background").gameObject.SetActive(false);
				//wall.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTexture = Tools.getImage("brickwall.png");
				//wall.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.shaderKeywords = new string[0];
				wall.transform.Find("Floor_Mask").gameObject.SetActive(false);
				// emo mode wall.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().lightmapIndex = 1;
				wall.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTextureScale = new Vector2(1f, 2f);
				GameObject.Find("Directional Light").GetComponent<Light>().intensity = 0f;
				GameObject.Find("Directional Light").GetComponent<Light>().range = 500;
				GameObject.Find("Directional Light").GetComponent<Light>().type = LightType.Point;
				GameObject.Find("Directional Light").GetComponent<Light>().shadows = LightShadows.Soft;
				GameObject.Find("Directional Light").transform.parent = Singleton<FirstPersonController>.Instance.transform;
				GameObject.Find("Directional Light").transform.localPosition = new Vector3(0, -9.5f, 0);
				wall.transform.localScale = new Vector3(20, 50f, 1f);
				wall.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
				wall.transform.position = new Vector3(-1000, -1000, -1000);


				MagSave.GetSideDeck();
				MagSave.getCleared();
				string layout = MagSave.GetLayout();
				//0,0,0 - north, 0,270,0 - west, 0,90,0 - east, 0,180,0 - south

				if (SaveManager.saveFile.ascensionActive)
				{
					string chalenge = KayceeStorage.ActiveChallenges;
					challenges = chalenge.Split(',');
					
				} else
                {
					challenges = new string[1];
					challenges[0] = "none";
                }

				
				GameObject.Find("MagnificusAnim").transform.position = new Vector3(0, -90, 0);

				switch (RunState.Run.regionTier)
				{
					case 0:
						setTableClothColor(new Color(0.5f, 0, 0.16f, 1));
						__instance.StartCoroutine(getMap("tower", true));
						makeLayer(2);
						Singleton<FirstPersonController>.Instance.footstepSound = FirstPersonController.FootstepSound.Wood;
						break;
					case 1:
						setTableClothColor(new Color(0f, 0.4f, 0f, 1));
						__instance.StartCoroutine(getMap("goobert", true));
						Singleton<FirstPersonController>.Instance.footstepSound = FirstPersonController.FootstepSound.Goo;
						break;
					case 2:
						setTableClothColor(new Color(0.5f, 0.15f, 0, 1));
						__instance.StartCoroutine(getMap("espeara", true));
						Singleton<FirstPersonController>.Instance.footstepSound = FirstPersonController.FootstepSound.Stone;
						break;
					case 3:
						setTableClothColor(new Color(0, 0.715f, 0.55f, 1));
						__instance.StartCoroutine(getMap("lonely", true));
						Singleton<FirstPersonController>.Instance.footstepSound = FirstPersonController.FootstepSound.Wood;
						break;
					case 4:
						setTableClothColor(new Color(0.5f, 0, 0.4f, 1));
						__instance.StartCoroutine(getMap("finale", true));
						Singleton<FirstPersonController>.Instance.footstepSound = FirstPersonController.FootstepSound.Stone;
						break;
					case 972:

						if (SaveManager.saveFile.ascensionActive)
                        {
							AscensionMenuScreens.ReturningFromSuccessfulRun = false;
							AscensionMenuScreens.ReturningFromFailedRun = true;
							KayceeStorage.IsMagRun = false;
							SaveManager.SaveToFile(false);
							SceneLoader.Load("Ascension_Configure");
							break;
						}

						__instance.StartCoroutine(getMap("depths", true));
						Singleton<FirstPersonController>.Instance.footstepSound = FirstPersonController.FootstepSound.Grass;
						break;
				}


				Singleton<ViewManager>.Instance.SwitchToView(View.FirstPerson, false, true);
				string coords = MagSave.GetCoords();
				string y = coords.Split('y')[1];
				if (int.Parse(y) < 7 && RunState.Run.regionTier == 3)
				{
					GameObject.Find("DungeonFloor").transform.Find("BrickGround").gameObject.SetActive(false);
					if (!config.isometricMode) { Singleton<FirstPersonController>.Instance.GetComponentInChildren<Camera>().farClipPlane = 75f; }
					GameObject.Find("Player").transform.Find("Directional Light").gameObject.GetComponent<Light>().intensity = 0;
				}
				Singleton<FirstPersonController>.Instance.currentZone = GameObject.Find(coords).GetComponent<NavigationZone3D>();
				GameObject.Find("Player").transform.position = new Vector3(GameObject.Find(coords).transform.position.x, 9.5f, GameObject.Find(coords).transform.position.z);
				if (config.isometricMode == true)
				{
					Tween.LocalPosition(GameObject.Find("PixelCameraParent").transform, new Vector3(0, 45, -50), 1.7f, 0.5f);
					Tween.LocalRotation(GameObject.Find("PixelCameraParent").transform, Quaternion.Euler(40f, 0, 0), 1.5f, 0.5f);
					GameObject figure = GameObject.Instantiate(Resources.Load("prefabs/map/CompositeFigurine") as GameObject);
					figure.transform.parent = GameObject.Find("GameEnvironment").transform;
					figure.name = "figure";
					figure.GetComponent<CompositeFigurine>().Generate(RunState.Run.playerAvatarHead, RunState.Run.playerAvatarArms, RunState.Run.playerAvatarBody);
					figure.transform.localScale = new Vector3(20, 20, 20);
					figure.transform.rotation = Quaternion.Euler(0, 0, 0);
					figure.transform.parent = Singleton<FirstPersonController>.Instance.gameObject.transform;
					figure.transform.localPosition = new Vector3(0, -10, 0);
					GameObject transitionIcon = GameObject.Instantiate<GameObject>(GameObject.Find("nodeIconBase"));
					transitionIcon.name = "transitionIcon";
					transitionIcon.transform.parent = GameObject.Find("PixelCameraParent").transform;
					transitionIcon.transform.localPosition = new Vector3(2, 13, 2);
					transitionIcon.transform.Find("Frame").Find("CanvasQuad").localPosition = new Vector3(-0.321f, 0f, -0.013f);
					transitionIcon.transform.localScale = new Vector3(0.13f, 0.13f, 0.13f);
					GameObject figureThruWalls = GameObject.Instantiate(GameObject.Find("ChallengeActivationUI"));
					figureThruWalls.transform.SetParent(GameObject.Find("OrthographicUICamera").transform);
					GameObject.Destroy(figureThruWalls.GetComponentByName("DiskCardGame.ChallengeActivationUI"));
					figureThruWalls.name = "WallFigure";
					GameObject uiFigure = GameObject.Find("WallFigure").transform.Find("VisibleParent").gameObject;
					uiFigure.SetActive(true);
					uiFigure.transform.Find("Footer").gameObject.SetActive(false);
					uiFigure.transform.Find("Header").Find("IconSprite").Find("Back").gameObject.SetActive(false);
					uiFigure.transform.Find("Header").Find("IconSprite").Find("Activated").gameObject.SetActive(false);
					GameObject.Destroy(uiFigure.transform.Find("Header").Find("IconSprite").gameObject.GetComponentByName("DiskCardGame.AscensionIconBlinkEffect"));
					uiFigure.transform.Find("Header").Find("IconSprite").gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
					uiFigure.transform.Find("Header").Find("IconSprite").gameObject.GetComponent<SpriteRenderer>().sprite = Tools.getSprite("walloverlay.png");
					uiFigure.transform.Find("Header").Find("IconSprite").localScale = new Vector3(0.24f, 0.2f, 1);
					GameObject.Destroy(uiFigure.transform.Find("Header").gameObject.GetComponent<ViewportRelativePosition>());
					uiFigure.transform.Find("Header").Find("IconSprite").localPosition = new Vector3(1.79f, -1.03f, 0);
					setUpClickToMove();
					uiFigure.transform.position = new Vector3(0, 0, 0);
				}
				else
				{
					float x = GameObject.Find("PixelCameraParent").transform.position.x;
					float z = GameObject.Find("PixelCameraParent").transform.position.z;
					GameObject.Find("PixelCameraParent").transform.position = new Vector3(x, 16.5f, z);
					Tween.Position(GameObject.Find("PixelCameraParent").transform, new Vector3(x, 16.5f, z), 0.1f, 0.5f);
					Tween.Rotation(GameObject.Find("PixelCameraParent").transform, Quaternion.Euler(0, 0, 0), 0.1f, 0.5f);
				}
				__instance.StartCoroutine(WAKEUP());
				GameObject.Find("GameTable").transform.position = new Vector3(0, -900, 0);
				GameObject.Find("DeckReviewCardArray").transform.parent = GameObject.Find("GameTable").transform;

				GameObject cardSelector = GameObject.Instantiate(Singleton<SelectableCardArray>.Instance.gameObject);
				cardSelector.name = "SelectableCardArray";
				cardSelector.transform.parent = __instance.duelDiskParent.gameObject.transform.Find("BoardManager").transform;

				if (cardSelector.GetComponent<SelectableCardPairArray>() != null)
				{
					GameObject.DestroyImmediate(cardSelector.GetComponent<SelectableCardPairArray>());
					cardSelector.AddComponent<SelectableCardArray>().selectableCardPrefab = Singleton<SelectableCardArray>.Instance.selectableCardPrefab;
				}


				__instance.duelDiskParent.gameObject.transform.Find("BoardManager").gameObject.GetComponent<BoardManager>().cardSelector = cardSelector.GetComponent<SelectableCardArray>();


				if (SavedVars.HasMap == true && RunState.Run.regionTier > 0 && RunState.Run.regionTier != 4)
				{
					CreateMiniMap();
				}

				return true;
			}
		}
			
		public static void setUpClickToMove()
        {
			GameObject clickToMove = new GameObject("clickToMove");
			clickToMove.transform.parent = GameObject.Find("Player").transform;
			clickToMove.transform.localPosition = new Vector3(0, 0, 1);
			List<string> directionsToCreate = new List<string> { "North", "South", "East", "West" };
			for (int i = 0; i < directionsToCreate.Count; i++)
			{
				GameObject dir = new GameObject("click" + directionsToCreate[i]);
				dir.transform.parent = clickToMove.transform;
				dir.AddComponent<MainInputInteractable>();
				dir.GetComponent<MainInputInteractable>().CursorEntered = (Action<MainInputInteractable>)Delegate.Combine(dir.GetComponent<MainInputInteractable>().CursorEntered, new Action<MainInputInteractable>(delegate (MainInputInteractable j)
				{
					IsometricStuff.lastDir = j.gameObject.name.Split('k')[1];
					if (checkIfShouldDisplayPointIcon(j.gameObject.name.Split('k')[1])) {Singleton<InteractionCursor>.Instance.ForceCursorType(CursorType.Point); }
				}));
				dir.GetComponent<MainInputInteractable>().CursorExited = (Action<MainInputInteractable>)Delegate.Combine(dir.GetComponent<MainInputInteractable>().CursorExited, new Action<MainInputInteractable>(delegate (MainInputInteractable j)
				{
					IsometricStuff.lastDir = "none";
					Singleton<InteractionCursor>.Instance.ClearForcedCursorType();
				}));
				dir.layer = 2;
				dir.AddComponent<BoxCollider>().size = new Vector3(9, 9, 9);
			}
			List<Vector3> directionPos = new List<Vector3> { new Vector3(0f, -9.3f, 20), new Vector3(20f, -9.3f, 0f), new Vector3(0f, -9.3f, -20), new Vector3(-20f, -9.3f, 0f) };
			if (config.gridActive)
			{
				GameObject clickGrid = new GameObject("clickGrid");
				clickGrid.transform.parent = GameObject.Find("Player").transform;
				clickGrid.transform.localPosition = new Vector3(0, 0, 0);
				IsometricStuff.gridTileObj = new List<GameObject>();
				IsometricStuff.gridMove = 0;
				for (int i = -1; i < 8; i++)
				{
					GameObject gameObject = new GameObject("gridtile" + i);
					gameObject.transform.parent = clickGrid.transform;
					gameObject.transform.localScale = new Vector3(7.5f, 7.5f, 1);
					if (i < directionPos.Count && i >= 0)
					{
						gameObject.transform.localPosition = directionPos[i];
						gameObject.AddComponent<GridTile>().direction = LookDirection.North + i;
					}
					else if (i >= 0)
					{
						int j = i - 4;
						int jPos = j % 2 == 0 ? 3 : 1;
						if (j <= 1)
						{
							gameObject.transform.localPosition = new Vector3(directionPos[jPos].x, -9.3f, directionPos[0].z);
							gameObject.AddComponent<GridTile>().checkFrom = new List<LookDirection> { LookDirection.North, LookDirection.North + jPos };
							gameObject.GetComponent<GridTile>().checkOffset = true;
						}
						else
						{
							gameObject.transform.localPosition = new Vector3(directionPos[jPos].x, -9.3f, directionPos[2].z);
							gameObject.AddComponent<GridTile>().checkFrom = new List<LookDirection> { LookDirection.South, LookDirection.North + jPos };
							gameObject.GetComponent<GridTile>().checkOffset = true;
						}
					}
					else
					{
						gameObject.transform.localPosition = new Vector3(0, -9.3f, 0);
						gameObject.AddComponent<GridTile>().direction = LookDirection.North;
					}
					gameObject.transform.rotation = Quaternion.Euler(new Vector3(90, 0, 0));
					GameObject gridTile = new GameObject("gridTile");
					gridTile.transform.parent = gameObject.transform;
					gridTile.AddComponent<SpriteRenderer>();
					gridTile.GetComponent<SpriteRenderer>().sprite = WallTextures.gridTiles[1];
					gridTile.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
					if (i >= directionPos.Count) { gridTile.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.25f); }
					gridTile.transform.localPosition = new Vector3(0, -0.1f, 0);
					gridTile.transform.localRotation = Quaternion.Euler(0, 0, 0);
					gridTile.transform.localScale = new Vector3(1, 1, 1);
					IsometricStuff.gridTileObj.Add(gameObject);
				}
				for (int i = 8; i < 12; i++)
				{
					GameObject gameObject = new GameObject("gridtile" + i);
					gameObject.transform.parent = clickGrid.transform;
					gameObject.transform.localScale = new Vector3(7.5f, 7.5f, 1);
					int j = i - 8;
					gameObject.transform.localPosition = new Vector3(directionPos[j].x * 2, -9.3f, directionPos[j].z * 2);
					gameObject.AddComponent<GridTile>().direction = LookDirection.North + j;
					gameObject.GetComponent<GridTile>().checkFrom = new List<LookDirection> { LookDirection.North + j, LookDirection.North + j };
					gameObject.GetComponent<GridTile>().checkOffset = true;
					gameObject.transform.rotation = Quaternion.Euler(new Vector3(90, 0, 0));
					GameObject gridTile = new GameObject("gridTile");
					gridTile.transform.parent = gameObject.transform;
					gridTile.AddComponent<SpriteRenderer>();
					gridTile.GetComponent<SpriteRenderer>().sprite = WallTextures.gridTiles[1];
					gridTile.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.25f);
					gridTile.transform.localPosition = new Vector3(0, -0.1f, 0);
					gridTile.transform.localRotation = Quaternion.Euler(0, 0, 0);
					gridTile.transform.localScale = new Vector3(1, 1, 1);
					IsometricStuff.gridTileObj.Add(gameObject);
				}
			}
			Singleton<InteractionCursor>.Instance.ClearForcedCursorType();
			GameObject northMove = GameObject.Find("clickNorth");
			northMove.GetComponent<MainInputInteractable>().CursorSelectStarted = (Action<MainInputInteractable>)Delegate.Combine(northMove.GetComponent<MainInputInteractable>().CursorSelectStarted, new Action<MainInputInteractable>(delegate (MainInputInteractable i)
			{
				if (GameObject.Find("Player").transform.Find("figure").gameObject.activeSelf)
				{
					Singleton<FirstPersonController>.Instance.SetZone(NavigationGrid.instance.GetZoneInDirection(Singleton<FirstPersonController>.Instance.LookDirection, Singleton<FirstPersonController>.Instance.currentZone) as NavigationZone3D, false);
					Tween.LocalRotation(GameObject.Find("Player").transform.Find("figure").transform, Quaternion.Euler(0, 0, 0), 0.15f, 0);
					if (MagnificusMod.Generation.minimap && RunState.Run.regionTier > 0)
					{
						GameObject playerIcon = GameObject.Find("playerMapNode");
						Tween.Rotation(playerIcon.transform.Find("Header").Find("IconSprite"), Quaternion.Euler(0, 0, 0), 0.25f, 0);
					}
				}
			}));
			northMove.transform.localScale = new Vector3(1.25f, 1, 1.35f);
			northMove.transform.localPosition = new Vector3(0f, 0, 9f);
			GameObject southMove = GameObject.Find("clickSouth");
			southMove.transform.localPosition = new Vector3(0f, 0f, -22.5f);
			southMove.transform.localScale = new Vector3(1.25f, 1f, 1.3f);
			southMove.GetComponent<MainInputInteractable>().CursorSelectStarted = (Action<MainInputInteractable>)Delegate.Combine(southMove.GetComponent<MainInputInteractable>().CursorSelectStarted, new Action<MainInputInteractable>(delegate (MainInputInteractable i)
			{
				if (GameObject.Find("Player").transform.Find("figure").gameObject.activeSelf) 
				{
					Singleton<FirstPersonController>.Instance.SetZone(NavigationGrid.instance.GetZoneInDirection(Singleton<FirstPersonController>.Instance.GetOppositeDirection(Singleton<FirstPersonController>.Instance.LookDirection), Singleton<FirstPersonController>.Instance.currentZone) as NavigationZone3D, false);
					Tween.LocalRotation(GameObject.Find("Player").transform.Find("figure").transform, Quaternion.Euler(0, 180, 0), 0.15f, 0);
				}
			}));
			GameObject westMove = GameObject.Find("clickWest");
			westMove.transform.localPosition = new Vector3(-23f, 0, -8f);
			westMove.transform.localScale = new Vector3(1.35f, 1f, 1);
			westMove.GetComponent<MainInputInteractable>().CursorSelectStarted = (Action<MainInputInteractable>)Delegate.Combine(westMove.GetComponent<MainInputInteractable>().CursorSelectStarted, new Action<MainInputInteractable>(delegate (MainInputInteractable i)
			{
				if (GameObject.Find("Player").transform.Find("figure").gameObject.activeSelf)
				{
					Singleton<FirstPersonController>.Instance.SetZone(NavigationGrid.instance.GetZoneInDirection(Singleton<FirstPersonController>.Instance.GetLeftOfDirection(Singleton<FirstPersonController>.Instance.LookDirection), Singleton<FirstPersonController>.Instance.currentZone) as NavigationZone3D, false);
					Tween.LocalRotation(GameObject.Find("Player").transform.Find("figure").transform, Quaternion.Euler(0, 270, 0), 0.15f, 0);
				}
			}));
			GameObject eastMove = GameObject.Find("clickEast");
			eastMove.transform.localPosition = new Vector3(15f, 0, -8);
			eastMove.transform.localScale = new Vector3(1.35f, 1f, 1f);
			eastMove.GetComponent<MainInputInteractable>().CursorSelectStarted = (Action<MainInputInteractable>)Delegate.Combine(eastMove.GetComponent<MainInputInteractable>().CursorSelectStarted, new Action<MainInputInteractable>(delegate (MainInputInteractable i)
			{
				if (GameObject.Find("Player").transform.Find("figure").gameObject.activeSelf)
				{
					Singleton<FirstPersonController>.Instance.SetZone(NavigationGrid.instance.GetZoneInDirection(Singleton<FirstPersonController>.Instance.GetRightOfDirection(Singleton<FirstPersonController>.Instance.LookDirection), Singleton<FirstPersonController>.Instance.currentZone) as NavigationZone3D, false);
					Tween.LocalRotation(GameObject.Find("Player").transform.Find("figure").transform, Quaternion.Euler(0, 90, 0), 0.15f, 0);
				}
			}));
		}

		public static int getRotationFromDirection(string direction)
		{
			List<string> directionsToCreate = new List<string> { "North", "East", "South", "West" };
			return directionsToCreate.IndexOf(direction) * 90;
		}
		public static bool checkIfShouldDisplayPointIcon(string direction, NavigationZone3D overridezone = null)
        {
			bool nodeInDirectionExists = false;
			List<string> directions = new List<string> { "North", "East", "South", "West" };
			NavigationZone3D zone = overridezone != null ? overridezone : Singleton<FirstPersonController>.Instance.currentZone;
			if (NavigationGrid.instance.GetZoneInDirection((LookDirection)((int)(Singleton<FirstPersonController>.Instance.LookDirection + directions.IndexOf(direction)) % 4), zone) != null) { nodeInDirectionExists = true; }
			return nodeInDirectionExists && GameObject.Find("Player").transform.Find("figure").gameObject.activeSelf;
        }

		public static void SetBigOpponentSlotHitboxes(bool set, GameObject boardManager, bool setPlayer = false)
        {
			float y = set ? 47f : 1f;
			for (int i = 0; i < 4; i++)
			{
				float xOffset = 2.1f * i;
				boardManager.transform.Find("OpponentSlots").GetChild(i).gameObject.GetComponent<BoxCollider>().size = new Vector3(1.4f, y, 2.1f);
			}
			if (setPlayer)
            {
				for (int i = 0; i < 4; i++)
				{
					float xOffset = 2.2f * i;
					if (set)
					{
						if (RunState.Run.regionTier == 4)
						{
							xOffset = 5.175f * i;
							boardManager.transform.Find("PlayerSlots").GetChild(i).localScale = new Vector3(2.75f, 2.75f, 2.75f);
							boardManager.transform.Find("PlayerSlots").GetChild(i).localPosition = new Vector3(-8.75f + xOffset, -8f, 22f);
							continue;
						}
						boardManager.transform.Find("PlayerSlots").GetChild(i).localPosition = new Vector3(-4.1f + xOffset, -23.2f, 7.85f);
						boardManager.transform.Find("PlayerSlots").GetChild(i).gameObject.GetComponent<BoxCollider>().size = new Vector3(1.4f, y + 0.5f, 2.1f);
					} else
                    {
						xOffset = 1.48f * i;
						boardManager.transform.Find("PlayerSlots").GetChild(i).localScale = new Vector3(1f, 1f, 1f);
						boardManager.transform.Find("PlayerSlots").GetChild(i).localPosition = new Vector3(-2.88f + xOffset, 0.15f, 1.39f);
						boardManager.transform.Find("PlayerSlots").GetChild(i).gameObject.GetComponent<BoxCollider>().size = new Vector3(1.4f, 0.2f, 2.1f);
					}
				}
			}
		}
		public static void CreateMiniMap(bool wIcons = false, bool doAnimation = false)
        {
			SavedVars.HasMap = true;
			minimap = true;
			if (wIcons) {
				SavedVars.HasMapIcons = true;
				try
                {
					if (GameObject.Find("MapParent") != null) { GameObject.DestroyImmediate(GameObject.Find("MapParent")); }
                }
                catch { }
			}
			GameObject mapParent = GameObject.Instantiate(GameObject.Find("ChallengeActivationUI"));
			mapParent.transform.SetParent(GameObject.Find("PerspectiveUICamera").transform);
			GameObject.Destroy(mapParent.GetComponentByName("DiskCardGame.ChallengeActivationUI"));
			mapParent.name = "MapParent";
			GameObject mapNode = GameObject.Find("MapParent").transform.Find("VisibleParent").gameObject;
			mapNode.SetActive(true);
			mapNode.transform.Find("Footer").gameObject.SetActive(false);
			mapNode.transform.Find("Header").Find("IconSprite").Find("Back").gameObject.SetActive(false);
			mapNode.transform.Find("Header").Find("IconSprite").Find("Activated").gameObject.SetActive(false);
			GameObject.Destroy(mapNode.transform.Find("Header").Find("IconSprite").gameObject.GetComponentByName("DiskCardGame.AscensionIconBlinkEffect"));
			mapNode.transform.Find("Header").Find("IconSprite").gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
			mapNode.transform.Find("Header").Find("IconSprite").gameObject.GetComponent<SpriteRenderer>().sprite = WallTextures.minimapNode;
			mapNode.transform.Find("Header").Find("IconSprite").localScale = new Vector3(0.1f, 0.1f, 0.1f);
			mapNode.transform.Find("Header").Find("IconSprite").localPosition = new Vector3(-0.15f, 0.15f, 0);
			mapNode.transform.Find("Header").Find("IconSprite").gameObject.GetComponent<PixelSnapSprite>().enabled = false;
			mapNode.transform.position = new Vector3(0, 0, 0);
			mapNode.name = "mapNodeBase";

			string[] allNodes = new string[0];
			allNodes = SavedVars.GeneratedEvents.Split(';');
			string text = File.ReadAllText(SaveManager.SaveFolderPath + "MagnificusModSave.gwsave");
			string proto = text.Split('C')[1];
			string proto2 = proto.Split('R')[0];
			string[] cleared = proto2.Split(',');
			List <List<string>> map = RoomGen.DecompileLayout(MagSave.layout);
			for (int y = 0; y < map.Count; y++)
            {
				float yPos = 0.15f * y;
				for (int x = 0; x < map[y].Count; x++)
                {
					float xPos = 0.15f * x;
					if (map[y][x] != "-" && !Utility.IsNullOrWhiteSpace(map[y][x]) && map[y][x] != " ")
					{
						GameObject node = GameObject.Instantiate(mapNode);
						node.transform.SetParent(GameObject.Find("MapParent").transform);
						node.transform.position = new Vector3(0, 0, 1);
						node.transform.Find("Header").Find("IconSprite").localPosition = new Vector3(-0.15f + xPos, 0.15f - yPos, 0);
						node.name = "mapnode x" + x + " y" + y;
						if (x != map[y].Count - 1)
						{
							if (map[y][x + 1] != "-" && !Utility.IsNullOrWhiteSpace(map[y][x + 1]) && map[y][x + 1] != " " && map[y][x] != "e")
							{
								GameObject xBridge = GameObject.Instantiate(node.transform.Find("Header").gameObject);
								xBridge.name = "xBridge";
								xBridge.transform.parent = node.transform;
								xBridge.transform.Find("IconSprite").localScale = new Vector3(0.015f, 0.025f, 0.1f);
								xBridge.transform.Find("IconSprite").position = new Vector3(node.transform.Find("Header").Find("IconSprite").transform.position.x + 0.15f, node.transform.Find("Header").Find("IconSprite").transform.position.y, 1);
								if (map[y][x + 1].Contains("bl") && (SavedVars.HasMapIcons || wIcons) || map[y][x].Contains("bl") && (SavedVars.HasMapIcons || wIcons))
								{
									xBridge.transform.Find("IconSprite").gameObject.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0f, 0f, 1);
								}
							}
						}
						if (y != map.Count - 1)
						{
							if (x < map[y + 1].Count)
							{
								if (map[y + 1][x] != "-" && !Utility.IsNullOrWhiteSpace(map[y + 1][x]) && map[y + 1][x] != " " && map[y][x] != "e" && map[y + 1][x] != "e" && map[y + 1][x] != "p0")
								{
									GameObject yBridge = GameObject.Instantiate(node.transform.Find("Header").gameObject);
									yBridge.name = "yBridge";
									yBridge.transform.parent = node.transform;
									yBridge.transform.Find("IconSprite").localScale = new Vector3(0.025f, 0.015f, 0.1f);
									yBridge.transform.Find("IconSprite").position = new Vector3(node.transform.Find("Header").Find("IconSprite").transform.position.x, node.transform.Find("Header").Find("IconSprite").transform.position.y - 0.15f, 1);
									if (map[y + 1][x].Contains("bl") && (SavedVars.HasMapIcons || wIcons) || map[y][x].Contains("bl") && (SavedVars.HasMapIcons || wIcons))
									{
										yBridge.transform.Find("IconSprite").gameObject.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0f, 0f, 1);
									}
								}
							}
						}
						if (map[y][x] == "0")
                        {
							node.transform.Find("Header").Find("IconSprite").gameObject.GetComponent<SpriteRenderer>().color = new Color(0.75f, 0.75f, 1f, 1);
						} else if (map[y][x] == "s")
                        {
							node.transform.Find("Header").Find("IconSprite").gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 0.65f, 0, 1);
							GameObject mapIcon = GameObject.Instantiate(mapNode);
							mapIcon.name = "shopIcon";
							mapIcon.transform.SetParent(GameObject.Find("MapParent").transform);
							mapIcon.transform.position = new Vector3(0, 0, 1);
							mapIcon.transform.localScale = (doAnimation) ? Vector3.zero : new Vector3(1, 1, 1);
							mapIcon.transform.Find("Header").Find("IconSprite").gameObject.GetComponent<SpriteRenderer>().sprite = Tools.getSprite("shop_icon.png");
							mapIcon.transform.Find("Header").Find("IconSprite").localPosition = new Vector3(-0.15f + xPos, 0.15f - yPos, 0);
							mapIcon.transform.Find("Header").Find("IconSprite").gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
							if (doAnimation)
								Tween.LocalScale(mapIcon.transform, new Vector3(1f, 1f, 1f), 0.75f, 1f, Tween.EaseIn);
						}
						else if (map[y][x] == "e")
						{
							node.transform.Find("Header").Find("IconSprite").gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0f, 0, 1);
						}
						else if (map[y][x] == "p0" && RunState.Run.eyeState == EyeballState.Wizard)
                        {
							GameObject mapIcon = GameObject.Instantiate(mapNode);
							mapIcon.name = "gemPillarRoom";
							mapIcon.transform.SetParent(GameObject.Find("MapParent").transform);
							mapIcon.transform.position = new Vector3(0, 0, 1);
							mapIcon.transform.localScale = (doAnimation) ? Vector3.zero : new Vector3(1, 1, 1);
							mapIcon.transform.Find("Header").Find("IconSprite").gameObject.GetComponent<SpriteRenderer>().sprite = Tools.getSprite("puzzleicon0.png");
							mapIcon.transform.Find("Header").Find("IconSprite").localPosition = new Vector3(-0.15f + xPos, 0.15f - yPos, 0);
							mapIcon.transform.Find("Header").Find("IconSprite").gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);

							if (doAnimation)
								Tween.LocalScale(mapIcon.transform, new Vector3(1f, 1f, 1f), 0.75f, 1f, Tween.EaseIn);
						}
						else if (map[y][x].Contains("p") && RunState.Run.eyeState == EyeballState.Wizard)
						{
							GameObject mapIcon = GameObject.Instantiate(mapNode);
							mapIcon.name = "gemSigilRoom";
							mapIcon.transform.SetParent(GameObject.Find("MapParent").transform);
							mapIcon.transform.position = new Vector3(0, 0, 1);
							mapIcon.transform.localScale = (doAnimation) ? Vector3.zero : new Vector3(1, 1, 1);
							mapIcon.transform.Find("Header").Find("IconSprite").gameObject.GetComponent<SpriteRenderer>().sprite = Tools.getSprite("puzzleicon1.png");
							mapIcon.transform.Find("Header").Find("IconSprite").localPosition = new Vector3(-0.15f + xPos, 0.15f - yPos, 0);
							mapIcon.transform.Find("Header").Find("IconSprite").gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);

							if (doAnimation)
								Tween.LocalScale(mapIcon.transform, new Vector3(1f, 1f, 1f), 0.75f, 1f, Tween.EaseIn);
						}
						else if (map[y][x] == "b")
						{
							GameObject mapIcon = GameObject.Instantiate(mapNode);
							mapIcon.name = "gooBossIcon";
							mapIcon.transform.SetParent(GameObject.Find("MapParent").transform);
							mapIcon.transform.position = new Vector3(0, 0, 1);
							mapIcon.transform.localScale = (doAnimation) ? Vector3.zero : new Vector3(1, 1, 1);
							mapIcon.transform.Find("Header").Find("IconSprite").localPosition = new Vector3(-0.15f + xPos, 0.15f - yPos, 0);
							mapIcon.transform.Find("Header").Find("IconSprite").gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
							if (RunState.Run.regionTier == 1)
							{
								node.transform.Find("Header").Find("IconSprite").gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 1f, 0, 1);
								mapIcon.transform.Find("Header").Find("IconSprite").gameObject.GetComponent<SpriteRenderer>().sprite = Tools.getSprite("boss goo_icon.png");
							} else if  (RunState.Run.regionTier == 2)
                            {
								node.transform.Find("Header").Find("IconSprite").gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1);
								mapIcon.transform.Find("Header").Find("IconSprite").gameObject.GetComponent<SpriteRenderer>().sprite = Tools.getSprite("boss pike_icon.png");
							}
							else if (RunState.Run.regionTier == 3)
							{
								node.transform.Find("Header").Find("IconSprite").gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0.5f, 1f, 1);
								mapIcon.transform.Find("Header").Find("IconSprite").gameObject.GetComponent<SpriteRenderer>().sprite = Tools.getSprite("boss stim_icon.png");
							}

							if (doAnimation)
								Tween.LocalScale(mapIcon.transform, new Vector3(1f, 1f, 1f), 0.75f, 1f, Tween.EaseIn);

						} else if (SavedVars.HasMapIcons == true || wIcons)
                        {
							string mapId = map[y][x];
							if (mapId.Contains("bl"))
                            {
								mapId = mapId.Split('b')[0];
							}
							bool puzzle = false;
							if (mapId.Contains('p'))
                            {
								puzzle = true;
								mapId = mapId.Split('p')[1];
                            }
							int roomId = int.Parse(mapId);
							List<List<List<string>>> rooms = RoomGen.GooRooms;
							if (RunState.Run.regionTier == 2)
                            {
								rooms = RoomGen.LavaRooms;
								if (puzzle) { rooms = RoomGen.LavaPuzzleRooms; }
                            } else if (RunState.Run.regionTier == 3)
                            {
								rooms = RoomGen.VoidRooms;
								if (puzzle) { rooms = RoomGen.VoidPuzzleRooms; }
							}
							List<NavigationEvent> cevent = new List<NavigationEvent>();
							for (int rY = 0; rY < rooms[roomId].Count; rY++)
							{
								for (int rX = 0; rX < rooms[roomId][rY].Count; rX++)
								{
									int trueX = x * 7 + rX;
									int trueY = y * 7 + rY;
									if ((rooms[roomId][rY][rX] == "EVN" || rooms[roomId][rY][rX] == "EN" || rooms[roomId][rY][rX] == "E" || rooms[roomId][rY][rX] == "CR" || rooms[roomId][rY][rX] == "C" || rooms[roomId][rY][rX] == "CC" || rooms[roomId][rY][rX] == "CS") && !cleared.Contains("x" + trueX + " y" + trueY) && cevent.Count < 1)
									{
										cevent = GameObject.Find("x" + trueX + " y" + trueY).GetComponent<NavigationZone3D>().events;
									}
								}
							}
							if (cevent.Count > 0)
                            {
								GameObject mapIcon = GameObject.Instantiate(mapNode);
								mapIcon.name = "nodeIcon";
								mapIcon.transform.SetParent(GameObject.Find("MapParent").transform);
								mapIcon.transform.position = new Vector3(0, 0, 1);
								mapIcon.transform.Find("Header").Find("IconSprite").localScale = new Vector3(0.275f, 0.25f, 1);
								mapIcon.transform.Find("Header").Find("IconSprite").localPosition = new Vector3(-0.15f + xPos, 0.15f - yPos, 0);
								mapIcon.transform.Find("Header").Find("IconSprite").gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
								if (cevent.Contains(enchant))
                                {
									mapIcon.transform.Find("Header").Find("IconSprite").gameObject.GetComponent<SpriteRenderer>().sprite = Tools.getSprite("map_enchant.png");
								} else if (cevent.Contains(bleach))
                                {
									mapIcon.transform.Find("Header").Find("IconSprite").gameObject.GetComponent<SpriteRenderer>().sprite = Tools.getSprite("map_bleach.png");
								} else if (cevent.Contains(costChange))
                                {
									mapIcon.transform.Find("Header").Find("IconSprite").gameObject.GetComponent<SpriteRenderer>().sprite = Tools.getSprite("map_costchange.png");
								} else if (cevent.Contains(copyCard))
                                {
									mapIcon.transform.Find("Header").Find("IconSprite").gameObject.GetComponent<SpriteRenderer>().sprite = Tools.getSprite("map_copycard.png");
								} else if (cevent.Contains(spellUpgrade))
                                {
									mapIcon.transform.Find("Header").Find("IconSprite").gameObject.GetComponent<SpriteRenderer>().sprite = Tools.getSprite("map_spellupgrade.png");
								} else if (cevent.Contains(cauldronEvent))
                                {
									mapIcon.transform.Find("Header").Find("IconSprite").gameObject.GetComponent<SpriteRenderer>().sprite = Tools.getSprite("map_potion.png");
								} else if (cevent.Contains(mergeCard))
                                {
									mapIcon.transform.Find("Header").Find("IconSprite").gameObject.GetComponent<SpriteRenderer>().sprite = Tools.getSprite("map_merge.png");
								} else if (cevent.Contains(cardPainting))
                                {
									mapIcon.transform.Find("Header").Find("IconSprite").gameObject.GetComponent<SpriteRenderer>().sprite = Tools.getSprite("map_painting.png");
								}
								else if (cevent.Contains(spellSelect))
								{
									mapIcon.transform.Find("Header").Find("IconSprite").gameObject.GetComponent<SpriteRenderer>().sprite = Tools.getSprite("map_spellchoice.png");
								}
								else if (cevent.Contains(costSelect))
								{
									mapIcon.transform.Find("Header").Find("IconSprite").gameObject.GetComponent<SpriteRenderer>().sprite = Tools.getSprite("map_costchoice.png");
								}
								else
                                {
									mapIcon.transform.Find("Header").Find("IconSprite").gameObject.GetComponent<SpriteRenderer>().sprite = Tools.getSprite("map_cardchoice.png");
								}
							}
                        }
						node.transform.localScale = doAnimation ? new Vector3(0, 0, 1) : new Vector3(1, 1, 1);
						if (doAnimation)
							Tween.LocalScale(node.transform, new Vector3(1, 1, 1), 0.75f, y * 0.15f, Tween.EaseIn);
					}
                }
            }
			string nodeName = Singleton<FirstPersonController>.Instance.currentZone.gameObject.name;
			string[] x1 = nodeName.Split('x');
			string[] x2 = x1[1].Split(' ');
			int xP = int.Parse(x2[0]);
			string[] y2 = x2[1].Split('y');
			int yP = int.Parse(y2[1]);
			xP /= 7;
			yP /= 7;
			float yPos2 = 0.15f * yP;
			float xPos2 = 0.15f * xP;
			GameObject playerIcon = GameObject.Instantiate(mapNode);
			playerIcon.name = "playerMapNode";
			playerIcon.transform.SetParent(GameObject.Find("MapParent").transform);
			playerIcon.transform.position = new Vector3(0, 0, 1);
			playerIcon.transform.Find("Header").Find("IconSprite").gameObject.GetComponent<SpriteRenderer>().sprite = Tools.getSprite("mapplayer.png");
			playerIcon.transform.Find("Header").Find("IconSprite").localPosition = new Vector3(-0.15f + xPos2, 0.15f - yPos2, 0);
			playerIcon.transform.Find("Header").Find("IconSprite").gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);

			playerIcon.transform.localScale = doAnimation ? new Vector3(0, 0, 1) : new Vector3(1, 1, 1);
			if (doAnimation)
				Tween.LocalScale(playerIcon.transform, new Vector3(1, 1, 1), 0.75f, 1f, Tween.EaseIn);
		}

		//coroutines
		private static IEnumerator WAKEUP()
		{
			
			AudioController.Instance.StopAllLoops();
			IsometricStuff.moveDisabled = false;
			Singleton<FirstPersonController>.Instance.enabled = false;
			yield return new WaitForSeconds(1f);
			if (RunState.Run.regionTier == 1 || RunState.Run.regionTier == 2 || RunState.Run.regionTier == 3)
			{
				GameObject.Find("walls").transform.position = new Vector3(0, 0, 9);
			}
			float x = GameObject.Find("PixelCameraParent").transform.position.x;
			float z = GameObject.Find("PixelCameraParent").transform.position.z;
			//Tween.Position(GameObject.Find("PixelCameraParent").transform, new Vector3(x, 16.5f, z), 1.7f, 0.5f);
			//Tween.Rotation(GameObject.Find("PixelCameraParent").transform, Quaternion.Euler(0, 0, 0), 1.5f, 0.5f);
			if (config.isometricMode == true)
            {
				Tween.LocalPosition(GameObject.Find("PixelCameraParent").transform, new Vector3(0, 45, -50), 1.7f, 0.5f);
				Tween.LocalRotation(GameObject.Find("PixelCameraParent").transform, Quaternion.Euler(40f, 0, 0), 1.5f, 0.5f);
			} else
            {
				Tween.Position(GameObject.Find("PixelCameraParent").transform, new Vector3(x, 16.5f, z), 1.7f, 0.5f);
				Tween.Rotation(GameObject.Find("PixelCameraParent").transform, Quaternion.Euler(0, 0, 0), 1.5f, 0.5f);
			}
			yield return new WaitForSeconds(1.5f);
			Singleton<FirstPersonController>.Instance.enabled = true;
			if (RunState.Run.regionTier < 4 && RunState.Run.regionTier > 0 || RunState.Run.regionTier == 0 && !MagSave.layout.Contains("4") && !MagSave.layout.Contains("5"))
			{
				AudioController.Instance.StopAllLoops();
				AudioController.Instance.SetLoopAndPlay("School_of_Magicks", 0, true, true);
				AudioController.Instance.SetLoopVolumeImmediate(0.45f);
			} else
			{
				AudioController.Instance.SetLoopAndPlay("wind_blow", 1, true, true);
				AudioController.Instance.SetLoopVolumeImmediate(0.5f, 1);
				AudioController.Instance.FadeInLoop(15f, 0.6f, new int[]
				{
					1
				});
			}
			if (RunState.Run.regionTier == 0 && MagSave.layout.Contains("1") && !SaveManager.saveFile.ascensionActive)
            {
				SavedVars.NodesCleared = 0;
				SaveManager.saveFile.part3Data.deck.cardIdModInfos = new Dictionary<string, List<CardModificationInfo>>();
				SavedVars.KilledCards = "";
				SavedVars.HasMap = true;
				SavedVars.HasMapIcons = false;
				Singleton<FirstPersonController>.Instance.enabled = false;
				SavedVars.KilledCards = "";
				if (!SavedVars.LearnedMechanics.Contains("introdialogue")) 
				{
					SavedVars.LearnedMechanics += "introdialogue;";
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Hmmm. It seems a new student is woven onto my canvas.", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
					Singleton<FirstPersonController>.Instance.enabled = true;
					Singleton<FirstPersonController>.Instance.LookAtDirection(LookDirection.South);
					Singleton<FirstPersonController>.Instance.enabled = false;
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("If you look behind yourself, you may see a [c:g1]shop[c:].", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("You may view your deck and rearange your side deck.", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Though, do not be alarmed. You may find a shop later on your adventures.", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
					Singleton<FirstPersonController>.Instance.enabled = true;
					Singleton<FirstPersonController>.Instance.LookAtDirection(LookDirection.North);
					Singleton<FirstPersonController>.Instance.enabled = false;
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("If you are ready to proceed, you may step forth and enter into the unknown.", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
				}
				else if(!SavedVars.LearnedMechanics.Contains("beatgoobert"))
				{
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Hmm.. A young student appears,", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("So foolish, your predesscor didn't even manage to get past my [c:g1]Goo Mage[c:].", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Ah well.. Maybe you will manage such a feat.", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
					SaveManager.SaveToFile();
				}
				else if (!SavedVars.LearnedMechanics.Contains("beatamber"))
				{
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Another appears.", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Maybe you will manage to get further than those before you.", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("You young understudies still have much to learn.", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
					SaveManager.SaveToFile();
				}
				else if (!SavedVars.LearnedMechanics.Contains("beatlonely"))
				{
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Ah. I had expectations for my previous mage,", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("They even managed to get past my [c:g2]Pike Mage[c:].", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("A great feat, it seems now you must follow in their footsteps...", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
					SaveManager.SaveToFile();
				}
				else if (!SavedVars.LearnedMechanics.Contains("finalintrodialogue"))
				{
					SavedVars.LearnedMechanics += "finalintrodialogue;";
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("So, yet another steps up to be my student.", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("You must learn yourself, to overcome my many obstacles and challenges.", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("If you do succeed, I shall bestow upon you a great honour..", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
					SaveManager.SaveToFile();
				}
				Singleton<FirstPersonController>.Instance.enabled = true;
			} else if (RunState.Run.regionTier == 0 && SaveManager.saveFile.ascensionActive && MagSave.layout.Contains("1"))
            {
				SavedVars.NodesCleared = 0;
				KayceeStorage.FleetingLife = 75;
				SavedVars.HasMap = true;
				SavedVars.HasMapIcons = false;
				if (SaveManager.saveFile.ascensionActive && challenges.Contains("FadingMox"))
					RunState.Run.playerLives = 1;
				SaveManager.saveFile.part3Data.deck.cardIdModInfos = new Dictionary<string, List<CardModificationInfo>>();
				SavedVars.KilledCards = "";
				if (!KayceeStorage.DialogueEvent1)
                {
					KayceeStorage.DialogueEvent1 = true;
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Hmm.. Something feels off..", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Have you [c:g1]modded[c:] my game, challenger?", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Hmph! How disrespectful!", -1.5f, 0.5f, Emotion.Anger, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Was my game not enough for you?", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Alas, I have no choice but to allow it..", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);

				}
			} else if (RunState.Run.regionTier == 0 && !MagSave.layout.Contains("1") && !MagSave.layout.Contains("4") && !MagSave.layout.Contains("5"))
            {
				yield return fadeText("~ Tower of Magicks ~");
			}
			if (SaveManager.saveFile.ascensionActive) { KayceeStorage.IsKaycee = true; KayceeStorage.IsMagRun = true;  } else { KayceeStorage.IsKaycee = false; }
			if (!KayceeStorage.IsMagRun && SaveManager.saveFile.ascensionActive) { KayceeStorage.IsMagRun = true; }
			SaveManager.SaveToFile();
			yield break;
		}

		public static IEnumerator gameoversequence()
		{
			yield return new WaitForSeconds(0.5f);
			if (!SavedVars.LearnedMechanics.Contains("died"))
				SavedVars.LearnedMechanics += "died;";
			yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Greetings, challenger.", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
			yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("It appears that all of your mox has been erased.", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
			switch (RunState.Run.currentNodeId)
			{
				case 0:
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Curiosity killed the cat..", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
					break;
				case 1:
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("It's a shame you got defeated so early..", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
					break;
				case 2:
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("It's a shame you got defeated so easily.", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
					break;
				case 3:
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("It's a shame you got defeated so far in.", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
					break;
				case 4:
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("I had such high hopes, but you lost it all..", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
					break;
				case 101:
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("It seems my slime mage got the best of you. How dissapointing.", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
					break;
				case 102:
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("It looks like my pike mage tactically took you out..", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
					break;
				case 103:
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Looks like that lonely mage got to you..", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
					break;
				case 104:
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("I had such high hopes, but you lost it all..", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
					break;
			}
			yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Though it does not matter.", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
			yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("I do not have any more use for you.", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
			Tween.Position(GameObject.Find("MagnificusAnim").transform, new Vector3(87f, 9.72f, -12), 1.25f, 0);
			Tween.Rotation(GameObject.Find("MagnificusAnim").transform, Quaternion.Euler(0, 215f, 0), 1.25f, 0);
			Tween.Position(GameObject.Find("door").transform, new Vector3(GameObject.Find("door").transform.position.x, 14.72f, GameObject.Find("door").transform.position.z), 3f, 0);
			yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Please, take your leave.", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
			while (GameObject.Find("door").transform.position.y < 14.70f)
			{
				yield return new WaitForSeconds(0.5f);
			}
			yield return new WaitForSeconds(0.5f);
			Tween.Position(GameObject.Find("Player").transform, new Vector3(80, 9.5f, -5f), 5f, 0);
			for (int i = 0; i < 501; i++)
			{
				float modify = 0.0035f * i;
				Singleton<UIManager>.Instance.Effects.GetEffect<ScreenColorEffect>().SetColor(GameColors.Instance.brightNearWhite);
				Singleton<UIManager>.Instance.Effects.GetEffect<ScreenColorEffect>().SetIntensity(modify, float.MaxValue);
				yield return new WaitForSeconds(0.01f);
			}
			yield return new WaitForSeconds(0.5f);
			File.WriteAllText(SaveManager.SaveFolderPath + "MagnificusModSave.gwsave", SaveManager.ToJSON(MagSave.GetNodeStuff(true, true)));
			AudioController.Instance.StopAllLoops();
			Singleton<UIManager>.Instance.Effects.GetEffect<ScreenColorEffect>().SetColor(GameColors.Instance.nearBlack);
			Singleton<UIManager>.Instance.Effects.GetEffect<ScreenColorEffect>().SetIntensity(1f, float.MaxValue);
			yield return new WaitForSeconds(0.5f);
			ResetMagRun();
		}


		public static void setupBattle(MagnificusGameFlowManager instance, bool removeMap = false)
        {
			Generation.lastView = GameObject.Find("Player").GetComponent<FirstPersonController>().LookDirection;
			GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().LookAtDirection(LookDirection.North, true);
			SaveManager.saveFile.randomSeed += 9;

			GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().LookAtDirection(LookDirection.North, true);
			GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().enabled = false;
			GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().LookAtDirection(LookDirection.North, true);
			GameObject.Find("Player").GetComponentInChildren<ViewManager>().enabled = true;
			GameObject.Find("Player").GetComponentInChildren<ViewController>().enabled = true;
			GameObject.Find("GameTable").transform.position = new Vector3(GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().currentZone.transform.position.x, 9.72f, GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().currentZone.transform.position.z);
			GameObject.Find("tbPillar").transform.position = new Vector3(GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().currentZone.transform.position.x, 9.72f - 6.83f, GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().currentZone.transform.position.z + 6.5f);
			
			if (MagnificusMod.Generation.minimap && removeMap)
			{
				MagnificusMod.Generation.minimap = true;
				SavedVars.HasMap = true;
				SavedVars.HasMapIcons = false;
				GameObject.Destroy(GameObject.Find("MapParent"));
			}
			
			if (!instance.cardbattleParent.activeSelf)
			{
				instance.cardbattleParent.SetActive(true);
			}
			
			GameObject.Find("Player").GetComponentInChildren<ViewManager>().SwitchToView(View.WizardBattleUnits, true, false);
			NavigationZone3D currentZone2 = GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().currentZone;
			string name2 = currentZone2.name;
			bool flag120 = GameObject.Find(name2).transform.Find("nodeIcon") != null;
			if (flag120)
			{
				nodes.Remove(GameObject.Find(name2).transform.Find("nodeIcon").gameObject);
				GameObject.Destroy(GameObject.Find(name2).transform.Find("nodeIcon").gameObject);
			}

			GameObject.Find("Player").GetComponentInChildren<ViewManager>().SwitchToView(View.WizardBattleUnits, true, false);

			Singleton<ViewController>.Instance.SwitchToControlMode(ViewController.ControlMode.WizardBattleDefault);
			Singleton<ViewManager>.Instance.SwitchToView(View.WizardBattleUnits);
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
			instance.combatBell.SetBesideBoard(false, true);

			Tween.Rotation(GameObject.Find("Player").transform, Quaternion.Euler(0, 0, 0), 0.25f, 1);

			Singleton<MagnificusDuelDisk>.Instance.basePosition = new Vector3(0.89f, 4.2424f, -2.8576f);
			instance.duelDiskParent.transform.localPosition = new Vector3(0.89f, 4.2424f, -2.8576f);
			instance.playerHand.transform.localPosition = new Vector3(1.42f, 3.12f, -5.47f);
			GameObject.Find("3DPortraitSlots").transform.localPosition = new Vector3(0, 3.62f, 4.14f);
			GameObject.Find("3DPortraitSlots").transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
			Singleton<ViewManager>.Instance.SwitchToView(View.WizardBattleSlots, false, false);
			instance.cardbattleParent.gameObject.transform.Find("Part1Scales").gameObject.SetActive(true);
			Singleton<MagnificusCardDrawPiles>.Instance.Awake();
		}

		public static void setupNodeStuff(MagnificusGameFlowManager instance, bool doBattleRoom = false)
		{
			if (doBattleRoom)
            {
				GameObject.Find("walls").SetActive(false);
				GameObject.Find("GameEnvironment").transform.Find("battleRoom").gameObject.SetActive(true);
				GameObject.Find("GameEnvironment").transform.Find("battleRoom").position = new Vector3(GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().currentZone.transform.position.x - 60, 0, GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().currentZone.transform.position.z + 100);
			}
			Generation.lastView = GameObject.Find("Player").GetComponent<FirstPersonController>().LookDirection;
			SaveManager.saveFile.randomSeed *= 2;
			SaveManager.saveFile.randomSeed += 5;

			GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().LookAtDirection(LookDirection.North, true);
			GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().enabled = false;
			GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().LookAtDirection(LookDirection.North, true);
			GameObject.Find("Player").GetComponentInChildren<ViewManager>().enabled = true;
			GameObject.Find("Player").GetComponentInChildren<ViewController>().enabled = true;
			GameObject.Find("GameTable").transform.position = new Vector3(GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().currentZone.transform.position.x, -9.72f, GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().currentZone.transform.position.z);
			Tween.Position(GameObject.Find("GameTable").transform, new Vector3(GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().currentZone.transform.position.x, 9.72f, GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().currentZone.transform.position.z), 0.5f, 0.1f, null, Tween.LoopType.None, null, null, true);

			NavigationZone3D currentZone2 = GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().currentZone;
			string name2 = currentZone2.name;
			if (GameObject.Find(name2).transform.Find("nodeIcon") != null)
			{
				nodes.Remove(GameObject.Find(name2).transform.Find("nodeIcon").gameObject);
				GameObject.Destroy(GameObject.Find(name2).transform.Find("nodeIcon").gameObject);
			}
			Tween.Rotation(GameObject.Find("Player").transform, Quaternion.Euler(0, 0, 0), 0.25f, 1);
		}

		public static void updateDuelDiskGems(bool reset = false)
		{
			MagnificusResourcesManager resourceManager = Singleton<MagnificusResourcesManager>.Instance;
			List<GemType> gems = new List<GemType> { GemType.Green, GemType.Orange, GemType.Blue };
			foreach (GemType gem in gems) resourceManager.SetGemLit(gem, lit: reset ? false : resourceManager.HasGem(gem));
		}

		public static IEnumerator isometricTransition(Texture icon, bool doPainting = true)
        {
			Singleton<InteractionCursor>.Instance.ClearForcedCursorType();
			GameObject.Find("deckLight").GetComponent<Light>().enabled = false;
			GameObject.Find("Player").transform.Find("figure").gameObject.SetActive(true);
			GameObject.Find("WallFigure").transform.Find("VisibleParent").transform.localPosition = new Vector3(0, 0, -1);
			if (doPainting)
			{
				GameObject.Find("transitionIcon").transform.localPosition = new Vector3(-0.25f, 5f, 2.55f);
				GameObject.Find("transitionIcon").transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = icon;
				GameObject.Find("transitionIcon").transform.localRotation = Quaternion.Euler(0, 0, 0);
				Tween.LocalPosition(GameObject.Find("transitionIcon").transform, new Vector3(-0.25f, -1.5f, 2f), 0.3f, 0);
				Tween.LocalPosition(GameObject.Find("transitionIcon").transform, new Vector3(-0.25f, -5.5f, 2f), 0.65f, 0.3f);
				Tween.LocalPosition(GameObject.Find("transitionIcon").transform, new Vector3(-0.25f, -16f, 2f), 0.3f, 0.95f);
			} 
			Singleton<ViewController>.Instance.LockState = ViewLockState.Locked;
			yield return new WaitForSeconds(0.15f);
			GameObject.Find("WallFigure").transform.Find("VisibleParent").Find("Header").Find("IconSprite").gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
			GameObject.Find("Player").transform.Find("figure").gameObject.SetActive(false);
			GameObject.Find("Player").transform.Find("clickToMove").gameObject.SetActive(false);
			if (config.gridActive) { GameObject.Find("Player").transform.Find("clickGrid").gameObject.SetActive(false); }
			yield return new WaitForSeconds(0.3f);
			GameObject.Find("Player").transform.localRotation = Quaternion.Euler(0, 0, 0);
			yield return new WaitForSeconds(0.45f);
			foreach (GameObject gameObject in MagnificusMod.Generation.nodes)
			{
				if (gameObject == null) { continue; }
				if (gameObject.name.Contains("nodeIcon"))
				{
					float oldRot = gameObject.transform.eulerAngles.y;
					float xRot = gameObject.transform.eulerAngles.x;
					float zRot = gameObject.transform.eulerAngles.z;
					gameObject.transform.LookAt(2f * gameObject.transform.position - GameObject.Find("Player").GetComponent<FirstPersonController>().currentZone.gameObject.transform.position);
					float newRot = gameObject.transform.eulerAngles.y;
					gameObject.transform.localRotation = Quaternion.Euler(0, newRot, zRot);
					//gameObject.transform.localPosition = new Vector3(1f, 22.72f, 0);
				}
			}
			GameObject.Find("GameTable").transform.Find("light").Find("deckLight").gameObject.GetComponent<Light>().enabled = true;
			Singleton<ViewController>.Instance.LockState = ViewLockState.Unlocked;
            Singleton<FirstPersonController>.Instance.enabled = false;
            yield break;
        }
		public static IEnumerator unIsometricTransition(float delay = 0f, bool doPainting = true)
		{
			Singleton<FirstPersonController>.Instance.enabled = false;
			GameObject.Find("Player").GetComponentInChildren<ViewController>().allowedViews = new List<View>();
			Singleton<FirstPersonController>.Instance.enabled = false;
			yield return new WaitForSeconds(delay);
			if(Singleton<ViewManager>.Instance.CurrentView == View.Candles) { yield break; }
			if (doPainting)
			{
				GameObject.Find("transitionIcon").transform.localPosition = new Vector3(-0.25f, -12.5f, 2.55f);
				GameObject.Find("transitionIcon").transform.localRotation = Quaternion.Euler(0, 0, 0);
				Tween.LocalPosition(GameObject.Find("transitionIcon").transform, new Vector3(-0.25f, -4.5f, 2f), 0.3f, 0);
				Tween.LocalPosition(GameObject.Find("transitionIcon").transform, new Vector3(-0.25f, -1f, 2f), 0.65f, 0.3f);
				Tween.LocalPosition(GameObject.Find("transitionIcon").transform, new Vector3(-0.25f, 5f, 2f), 0.3f, 0.95f);
				yield return new WaitForSeconds(0.15f);
				Tween.FieldOfView(GameObject.Find("PixelCameraParent").transform.Find("Pixel Camera").gameObject.GetComponent<Camera>(), 65f, 0.25f, 0.3f);
			} else
            {
				Tween.LocalPosition(GameObject.Find("PixelCameraParent").transform, new Vector3(0, 45, -50), 0.25f, 0.5f);
				Tween.LocalRotation(GameObject.Find("PixelCameraParent").transform, Quaternion.Euler(40, 0, 0), 0.25f, 0.5f);
				Tween.FieldOfView(GameObject.Find("PixelCameraParent").transform.Find("Pixel Camera").gameObject.GetComponent<Camera>(), 65f, 0.25f, 0.5f);
			}
			GameObject.Find("GameTable").transform.Find("light").Find("deckLight").gameObject.GetComponent<Light>().enabled = false;
			Singleton<ViewController>.Instance.LockState = ViewLockState.Locked;
			yield return new WaitForSeconds(0.3f);
			if (Singleton<ViewManager>.Instance.CurrentView == View.Candles) { yield break; }
			GameObject.Find("Player").GetComponentInChildren<ViewController>().allowedViews = new List<View>();
			GameObject.Find("Player").GetComponentInChildren<ViewManager>().CurrentView = View.FirstPerson;
			foreach (GameObject gameObject in MagnificusMod.Generation.nodes)
			{
				if (gameObject == null) { continue; }
				if (gameObject.name.Contains("nodeIcon"))
				{
					gameObject.transform.localRotation = Quaternion.Euler(30, (float)Singleton<FirstPersonController>.Instance.LookDirection * 90, 0);
				}
			}
			yield return new WaitForSeconds(0.1f);
			GameObject.Find("Player").transform.localRotation = Quaternion.Euler(0, (float)lastView * 90, 0);
			Singleton<FirstPersonController>.Instance.enabled = true;
			GameObject.Find("PixelCameraParent").transform.localPosition = new Vector3(0, 45, -50);
			GameObject.Find("PixelCameraParent").transform.localRotation = Quaternion.Euler(40, 0, 0);
			IsometricStuff.moveDisabled = false;
			if (doPainting) 
				yield return new WaitForSeconds(0.45f);
			lastView = LookDirection.North;
			Tween.LocalPosition(GameObject.Find("PixelCameraParent").transform, new Vector3(0, 45, -50), 0f, 0.15f);
			GameObject.Find("Player").transform.Find("figure").gameObject.SetActive(true);
			GameObject.Find("Player").transform.Find("clickToMove").gameObject.SetActive(true);
			Singleton<ViewController>.Instance.LockState = ViewLockState.Unlocked;
			GameObject.Find("GameTable").transform.Find("light").Find("deckLight").gameObject.GetComponent<Light>().enabled = true;
			if (config.gridActive) { GameObject.Find("Player").transform.Find("clickGrid").gameObject.SetActive(true); }
			yield break;
		}

		public static void ResetMagRun()
        {
			SaveManager.saveFile.pastRuns.Add(SaveManager.saveFile.currentRun);
			SaveManager.saveFile.currentRun = new RunState();
			SaveManager.saveFile.currentRun.Initialize();
			SaveManager.saveFile.currentRun.InitializeStarterDeckAndItems();
			SaveManager.saveFile.currentScene = "finale_magnificus";
			SaveManager.saveFile.currentRun.maxPlayerLives = 3;
			SaveManager.saveFile.currentRun.playerLives = 3;
			minimap = true;
			SavedVars.HasMap = true;
			SavedVars.HasMapIcons = false;

			KayceeStorage.IsKaycee = false;
			AscensionSaveData.Data.currentRun = null;
			SaveManager.SaveFile.NewPart1Run();
			SaveManager.saveFile.currentRun.playerDeck.InitializeAsPlayerDeck();

			SaveManager.SaveFile.deathCardMods = DefaultDeathCards.CreateDefaultCardMods();

			MagSave.SaveLayout("1");
			RunState.Run.regionTier = 0;
			SaveManager.SaveToFile(false);


			SceneLoader.Load("finale_magnificus");
		}

		public static IEnumerator fadeText(string message)
        {
			Singleton<TextDisplayer>.Instance.ShowMessage(message, Emotion.Laughter, TextDisplayer.LetterAnimation.WavyJitter);
			Singleton<TextDisplayer>.Instance.SetTextColor(new Color(1, 1, 1, 0.5f));
			AudioController.Instance.PlaySound2D("dueldisk_snap_shut", MixerGroup.ExplorationSFX, 0.25f, 0f);
			for (float i = 0.01f; i < 0.51f; i += 0.01f)
			{
				Singleton<TextDisplayer>.Instance.SetTextColor(new Color(1, 1, 1, 0.5f + i));
				yield return new WaitForSeconds(0.01f);
			}

			yield return new WaitForSeconds(0.5f);
			for (float i = 0.01f; i < 1.01f; i += 0.01f)
			{
				if (!Singleton<TextDisplayer>.Instance.textMesh.text.ToLower().Contains(message.ToLower())) { Singleton<TextDisplayer>.Instance.SetTextColor(new Color(1, 1, 1, 1f)); yield break; }
				Singleton<TextDisplayer>.Instance.SetTextColor(new Color(1, 1, 1, 1f - i));
				yield return new WaitForSeconds(0.01f);
			}
			yield return new WaitForSeconds(0.5f);

			if (!Singleton<TextDisplayer>.Instance.textMesh.text.ToLower().Contains(message.ToLower())) { Singleton<TextDisplayer>.Instance.SetTextColor(new Color(1, 1, 1, 1f)); yield break; }

			Singleton<TextDisplayer>.Instance.Clear();
			yield break;
		}

		public static IEnumerator setBg()
		{
			yield return new WaitForSeconds(6f);
			GameObject.Find("DungeonFloor").transform.GetChild(0).gameObject.SetActive(false);
			GameObject.Find("DungeonFloor").transform.GetChild(2).gameObject.SetActive(false);
			Singleton<FirstPersonController>.Instance.GetComponentInChildren<Camera>().backgroundColor = new Color(0.9333f, 0.9569f, 0.7765f, 1f);
			for (int i = 0; i < 120; i++)
			{
				GameObject.Find("DungeonFloor").transform.GetChild(1).gameObject.GetComponent<MeshRenderer>().material.color = new Color(0.9333f - i / 100f, 0.9569f - i / 100f, 0.7765f - i / 120f, 1f);
				Singleton<FirstPersonController>.Instance.GetComponentInChildren<Camera>().backgroundColor = new Color(0.9333f - i / 100f, 0.9569f - i / 100f, 0.7765f - i / 120f, 1f);
				yield return new WaitForSeconds(0.025f);
			}
			GameObject.Find("DungeonFloor").transform.GetChild(1).gameObject.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0, 1f);
			Singleton<FirstPersonController>.Instance.GetComponentInChildren<Camera>().backgroundColor = new Color(0f, 0f, 0f, 1f);
			GameObject bgStars = GameObject.Instantiate(GameObject.Find("wall"));
			GameObject starParent = new GameObject("bgStarParent");
			GameObject moon = GameObject.Instantiate(GameObject.Find("THE MOOON"));
			moon.transform.parent = starParent.transform;
			moon.transform.localScale = new Vector3(1000, 1000, 1000);
			moon.transform.localPosition = new Vector3(0.575f, 26.5f, 60.75f);
			starParent.transform.position = new Vector3(80, 130f, -32f);
			bgStars.transform.parent = starParent.transform;
			bgStars.name = "bgStars";
			bgStars.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTexture = Tools.getImage("stars.png");
			bgStars.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.shaderKeywords = new string[0];
			bgStars.transform.Find("BrickGround").gameObject.AddComponent<UVScroller>();
			bgStars.transform.Find("BrickGround").gameObject.GetComponent<UVScroller>().XscrollSpeed = 0.025f;
			bgStars.transform.localPosition = new Vector3(0.1f, 0f, 212.75f);
			bgStars.transform.rotation = Quaternion.Euler(325, 0, 0);
			bgStars.transform.localScale = new Vector3(200, 150, 1);
			GameObject stars2 = GameObject.Instantiate(bgStars);
			stars2.transform.parent = starParent.transform;
			stars2.transform.localPosition = new Vector3(-101.95f, 0f, 201.5f);
			stars2.transform.rotation = Quaternion.Euler(325, 290f, 0);
			GameObject stars3 = GameObject.Instantiate(bgStars);
			stars3.transform.parent = starParent.transform;
			stars3.transform.localPosition = new Vector3(106f, 0f, 136.75f);
			stars3.transform.rotation = Quaternion.Euler(325, 70f, 0);
			Tween.Position(starParent.transform, new Vector3(80, 7, -32f), 7.5f, 0);
			yield break;
		}

		public static IEnumerator deathCardEvent()
		{
			GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().enabled = false;
			yield return new WaitForSeconds(2.5f);
			yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Welcome back.", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);

			MagNodes.DeathCardEvent triggeringNodeData2 = new MagNodes.DeathCardEvent();
			GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().LookAtDirection(LookDirection.South, false);
			GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().enabled = false;
			GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().LookAtDirection(LookDirection.South, false);
			GameObject.Find("Player").GetComponentInChildren<ViewManager>().enabled = true;
			GameObject.Find("Player").GetComponentInChildren<ViewController>().enabled = true;
			yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("You're the first in a while to get this far.", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
			yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("I will now bestow upon you, the highest honour I can possibly give.", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
			yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("To be painted, and immortalised forever, as a card.", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);

			//GameObject.Find("Player").GetComponentInChildren<ViewManager>().SwitchToView(View.Choices, false, false);
			//GameObject.Find("GameTable").transform.position = new Vector3(GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().currentZone.transform.position.x, -9.72f, GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().currentZone.transform.position.z);
			//Tween.Position(GameObject.Find("GameTable").transform, new Vector3(GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().currentZone.transform.position.x, 9.72f, GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().currentZone.transform.position.z), 0.5f, 0.1f, null, Tween.LoopType.None, null, null, true);
			yield return Singleton<MagnificusGameFlowManager>.Instance.TransitionTo(GameState.SpecialCardSequence, triggeringNodeData2, true, true);
			NavigationZone3D currentZone2 = GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().currentZone;
			string name2 = currentZone2.name;
			GameObject.Find("GameTable").transform.position = new Vector3(80, 10.5f, -60.5f);
			GameObject.Find("GameTable").transform.localRotation = Quaternion.Euler(0, 180, 0);
			GameObject.Find("GameTable").transform.Find("tbPillar").gameObject.SetActive(false);
			Tween.Rotation(GameObject.Find("Player").transform, Quaternion.Euler(0, 180, 0), 0.25f, 1);
			yield break;
		}

		public static IEnumerator FinalBossTime()
		{
			yield return new WaitForSeconds(0.25f);
			bool isPainting = false;
			if (!SaveManager.saveFile.ascensionActive || SaveManager.saveFile.ascensionActive && !Generation.challenges.Contains("MasterBosses"))
			{
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("So you finally arrive..", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Hopefully you have prepared yourself well enough to face the Scrybe of Magicks.", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("This will be your final exam.", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Let us dance.", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
			}
			else if (Generation.challenges.Contains("MasterBosses"))
			{
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("[c:g2]You[c:] are finally here.", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("I hope you realise that this is truly it.", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("You may have removed my student's battles,", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("You may have tampered with my entire game..", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
				Singleton<ViewManager>.Instance.OffsetFOV(-1.5f, 0.15f, true);
				Singleton<UIManager>.Instance.Effects.GetEffect<EyelidMaskEffect>().SetIntensity(0.5f, 0.15f);
				yield return Singleton<TextDisplayer>.Instance.ShowThenClear("But you'll [c:g2]NEVER[c:] delete me, the Scrybe of Magicks!", 1f, 0f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
				Singleton<ViewManager>.Instance.OffsetFOV(0f, 0.15f, true);
				Singleton<UIManager>.Instance.Effects.GetEffect<EyelidMaskEffect>().SetIntensity(0f, 0.15f);
				GlitchOutAssetEffect.GlitchModel(GameObject.Find("MagnificusAnim").transform, false, true);
				ChallengeActivationUI.TryShowActivation(KayceeFixes.ChallengeManagement.MasterBosses);
				CustomTextDisplayerStuff.setBaseTextDisplayerOn(true);
				GameObject.DestroyImmediate(Singleton<TextDisplayer>.Instance.gameObject);
				GameObject.Find("TextDisplayer").GetComponent<TextDisplayer>().alternateSpeakerStyles[1].color = new Color(1, 1, 1, 1);
				GameObject.Find("TextDisplayer").GetComponent<TextDisplayer>().alternateSpeakerStyles[1].voiceSoundIdPrefix = "bonelord";
				GameObject.Find("TextDisplayer").GetComponent<TextDisplayer>().defaultStyle = GameObject.Find("TextDisplayer").GetComponent<TextDisplayer>().alternateSpeakerStyles[1];
				yield return new WaitForSeconds(2.5f);
				GameObject bossPainting = GameObject.Instantiate(GameObject.Find("GameTable").transform.Find("LifePainting").gameObject);
				bossPainting.name = "MagnificusAnim";
				bossPainting.SetActive(true);
				bossPainting.transform.position = new Vector3(80.3f, 35, 0);
				bossPainting.transform.localRotation = Quaternion.Euler(0, 0, 0);
				bossPainting.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
				bossPainting.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = Tools.getImage("magnusboss.png");
				bossPainting.transform.Find("Frame").Find("Glow_Edge_Right").gameObject.SetActive(true);
				bossPainting.transform.Find("Frame").Find("Glow_Edge_Left").gameObject.SetActive(true);
				bossPainting.transform.Find("Frame").Find("Glow_Edge_Right").gameObject.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1, 1f);
				bossPainting.transform.Find("Frame").Find("Glow_Edge_Left").gameObject.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1, 1f);
				bossPainting.GetComponent<SineWaveMovement>().originalPosition = new Vector3(0f, 5.5f, 13.5f);
				bossPainting.GetComponent<SineWaveMovement>().enabled = false;
				Tween.Position(bossPainting.transform, new Vector3(80.3f, 17f, 0f), 3.5f, 0f);
				yield return new WaitForSeconds(3.5f);
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("It is time.", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.PirateSkull, null);
				isPainting = true;
			}
			yield return new WaitForSeconds(0.15f);
			GameObject PlayerColum = GameObject.Find("MarbleColumn_Player");
			PlayerColum.transform.position = new Vector3(80, 15.5f, -25);

			GameObject MagnificusColum = GameObject.Find("MarbleColumn_Opponent");
			MagnificusColum.transform.position = new Vector3(80.5f, 15.5f, 0);
			MagnificusColum.transform.localScale = new Vector3(1.5f, 1, 1.5f);
			MagnificusColum.transform.Find("Shadow").gameObject.SetActive(false);

			Tween.Position(MagnificusColum.transform, new Vector3(80.5f, 25, 0), 6, 0);
			MagnificusColum.transform.Find("Smoke").gameObject.SetActive(true);
			if (!isPainting)
			{
				Tween.Position(GameObject.Find("MagnificusAnim").transform, new Vector3(80.575f, 19, 0), 6, 0);
				Tween.Position(MagnificusColum.transform, new Vector3(80.5f, 31, 12), 6, 6);
				Tween.Position(GameObject.Find("MagnificusAnim").transform, new Vector3(80.575f, 25, 12), 6, 6);
			} else
            {
				Tween.Position(GameObject.Find("MagnificusAnim").transform, new Vector3(80.3f, 23, 0), 6, 0);
				Tween.Position(MagnificusColum.transform, new Vector3(80.5f, 31, 12), 6, 6);
				Tween.Position(GameObject.Find("MagnificusAnim").transform, new Vector3(80.3f, 28, 12), 6, 6);
			}

			Tween.Position(PlayerColum.transform, new Vector3(80f, 25f, -25f), 6, 0);
			Tween.Position(GameObject.Find("Player").transform, new Vector3(80f, 15.9f, -20f), 6, 0);
			Tween.Position(PlayerColum.transform, new Vector3(80f, 27.5f, -38f), 6, 6);
			Tween.Position(GameObject.Find("Player").transform, new Vector3(80f, 22f, -32f), 6, 6);
			Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(Generation.setBg());
			yield return new WaitForSeconds(12f);

			for (int i = 0; i < 4; i++)
			{
				float xOffset = 5.175f * i;

				Singleton<MagnificusGameFlowManager>.Instance.duelDiskParent.transform.Find("BoardManager").Find("OpponentSlots").GetChild(i).localScale = new Vector3(2.75f, 2.75f, 2.75f);
				Singleton<MagnificusGameFlowManager>.Instance.duelDiskParent.transform.Find("BoardManager").Find("OpponentSlots").GetChild(i).localPosition = new Vector3(-8.75f + xOffset, -25f, -1973.65f);
				Singleton<MagnificusGameFlowManager>.Instance.duelDiskParent.transform.Find("BoardManager").Find("OpponentSlots").GetChild(i).gameObject.GetComponent<BoxCollider>().size = new Vector3(1.4f, 1f, 2.1f);
			}

			GameObject.Find("gooBottle").SetActive(false);
			GameObject.Find("tbPillar").transform.Find("Shadow").gameObject.SetActive(false);
			GameObject.Find("GameTable").transform.position = new Vector3(GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().currentZone.transform.position.x, 22f, GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().currentZone.transform.position.z - 12);
			GameObject.Find("tbPillar").transform.localPosition = new Vector3(0, -12.5f, 18.5f);
			GameObject.Find("tbPillar").transform.localScale = new Vector3(4, 1, 4);

			MagnificusColum.transform.Find("Smoke").gameObject.SetActive(false);
			if (!Singleton<MagnificusGameFlowManager>.Instance.cardbattleParent.activeSelf)
			{
				Singleton<MagnificusGameFlowManager>.Instance.cardbattleParent.SetActive(true);
				//instance.combatBell.anim.StopPlayback();
			}

			//Tween.LocalPosition(GameObject.Find("Hand").transform, new Vector3(4.3555f, -11.0099f, 2.0401f), 0f, 0f);
			BossBattleNodeData bossBattleNodeData = new BossBattleNodeData();
			bossBattleNodeData.specialBattleId = "MagnificusSequencer";
			if (isPainting) { bossBattleNodeData.specialBattleId = "MagnusSequencer"; }
			Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(Singleton<MagnificusGameFlowManager>.Instance.TransitionTo(GameState.CardBattle, bossBattleNodeData, true, true));

			GameObject.Find("Player").GetComponentInChildren<ViewManager>().SwitchToView(View.Default, true, false);
			NavigationZone3D currentZone2 = GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().currentZone;
			string name2 = currentZone2.name;

			GameObject.Find("Player").GetComponentInChildren<ViewManager>().SwitchToView(View.Default, true, false);

			Singleton<ViewController>.Instance.SwitchToControlMode(ViewController.ControlMode.WizardBattleDefault);
			Singleton<ViewManager>.Instance.SwitchToView(View.Default);
			Singleton<MagnificusGameFlowManager>.Instance.duelDiskParent.SetActive(true);
			Singleton<Part3ItemsManager>.Instance.gameObject.transform.parent = Singleton<MagnificusGameFlowManager>.Instance.duelDiskParent.transform;
			Singleton<Part3ItemsManager>.Instance.gameObject.transform.localPosition = new Vector3(3.74f, 0.5f, 5.1599f);
			Singleton<Part3ItemsManager>.Instance.gameObject.SetActive(false);
			Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(startHammer());
			Singleton<MagnificusGameFlowManager>.Instance.playerHand.SetActive(true);
			Singleton<MagnificusGameFlowManager>.Instance.combatBell.transform.Find("Anim").localPosition = new Vector3(0, 0, 0);
			GameObject.Find("Hand").transform.Find("Anim").Find("HandModel_Female").localPosition = new Vector3(4.349f, -11.0045f, 2.0401f);
			GameObject.Find("Hand").transform.Find("Anim").Find("HandModel_Male").localPosition = new Vector3(4.349f, -11.0045f, 2.5801f);
			Singleton<MagnificusGameFlowManager>.Instance.combatBell.transform.localPosition = new Vector3(-9.95f, 9.75f, 6.4f);
			Singleton<MagnificusGameFlowManager>.Instance.combatBell.transform.Find("Anim").gameObject.SetActive(true);
			Singleton<MagnificusGameFlowManager>.Instance.combatBell.gameObject.SetActive(true);
			Singleton<MagnificusGameFlowManager>.Instance.combatBell.SetBesideBoard(false, true);

			Singleton<MagnificusDuelDisk>.Instance.basePosition = new Vector3(0.89f, 4.5f, -2.8576f);
			Singleton<MagnificusDuelDisk>.Instance.gameObject.transform.Find("Anim").gameObject.GetComponent<Animator>().speed = 999;
			Singleton<MagnificusGameFlowManager>.Instance.duelDiskParent.transform.localPosition = new Vector3(0.89f, 4.5f, -2.8576f);
			Singleton<MagnificusGameFlowManager>.Instance.playerHand.transform.localPosition = new Vector3(1.42f, 3.12f, -5.47f);
			GameObject.Find("3DPortraitSlots").transform.localPosition = new Vector3(0f, -2.5f, 18f);
			GameObject.Find("3DPortraitSlots").transform.localScale = new Vector3(0.65f, 0.65f, 0.65f);
			Singleton<ViewManager>.Instance.SwitchToView(View.WizardBattleSlots, false, false);
			Singleton<MagnificusGameFlowManager>.Instance.cardbattleParent.gameObject.transform.Find("Part1Scales").gameObject.SetActive(true);
			Singleton<MagnificusCardDrawPiles>.Instance.Awake();

			Tween.Rotation(GameObject.Find("Player").transform, Quaternion.Euler(0, 0, 0), 0.25f, 1);
			yield break;
		}

		public static IEnumerator leshyDialogue()
		{
			if (!SavedVars.LearnedMechanics.Contains("secretfight") && !SaveManager.saveFile.ascensionActive)
			{
				SavedVars.LearnedMechanics += "secretfight;";
				Singleton<FirstPersonController>.Instance.enabled = false;
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Hmph.. I did not intend for you to get out here..", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("I have forseen it though. Despite my best attempts you persist.", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("We shall duel here..", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
				Tween.LocalPosition(GameObject.Find("x7 y14").transform.Find("nodeIcon"), new Vector3(0, 22f, 0), 3.0f, 0);
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Though, lets up the stakes.", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("If you lose here, your entire [c:g1]life painting[c:] will get bleached..", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Step forth if you dare.", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
				while (GameObject.Find("x7 y14").transform.Find("nodeIcon").localPosition.y > 23f)
				{
					yield return new WaitForSeconds(0.1f);
				}
				Singleton<FirstPersonController>.Instance.enabled = true;
				yield break;
			} else
            {
				Singleton<FirstPersonController>.Instance.enabled = false;
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("You persist again?", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
				Tween.LocalPosition(GameObject.Find("x7 y14").transform.Find("nodeIcon"), new Vector3(0, 22f, 0), 3.0f, 0);
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("I see..", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("We shall duel again!", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
				while (GameObject.Find("x7 y14").transform.Find("nodeIcon").localPosition.y > 23f)
				{
					yield return new WaitForSeconds(0.1f);
				}
				Singleton<FirstPersonController>.Instance.enabled = true;
				yield break;
			}
		}

		public static IEnumerator magnificusPreFinalDialogue()
		{
			Singleton<FirstPersonController>.Instance.LookAtDirection(LookDirection.North);
			Singleton<FirstPersonController>.Instance.enabled = false;
			yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Ah.. Finally, you arrive.", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
			Tween.LocalRotation(GameObject.Find("MagnificusAnim").transform, new Vector3(0, 180, 0), 1f, 0);
			yield return new WaitForSeconds(1f);
			if (!SaveManager.saveFile.ascensionActive || !MagnificusMod.Generation.challenges.Contains("MasterBosses") && SaveManager.saveFile.ascensionActive)
			{
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("I've been watching you from up here, for your entire journey.", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("You've come a long way, challenger.", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Unfortunately, that will all come to an end here.", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("One last duel, to decide your fate..", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
			} else if (MagnificusMod.Generation.challenges.Contains("MasterBosses"))
            {
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("It is time to put an end to this.. [c:g1]foolery[c:] of yours.", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("If you consider these cheats fair, then I might as well use some cheats of my own.", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Normally, I would have you expelled right on the spot.. But I'm feeling generous.", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Let us duel.", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
			}
			yield return  transition("finale", "spin");
			yield break;
			
		}

		public static IEnumerator pedestalDialogue()
		{
			if (!SavedVars.LearnedMechanics.Contains("pedestal;"))
			{
				SavedVars.LearnedMechanics += "pedestal;";
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Whats the matter? Stumped?", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Try searching around the dungeon.. There may be certain [c:g1]markings[c:] you missed..", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
				SaveManager.SaveToFile();
				yield break;
			}
		}

		public static IEnumerator getMap(string which, bool loading = false)
		{
			List<List<string>> map = new List<List<string>>();
			switch (which)
			{
				case "tower":
					int level = 1;
					bool dOoor = true;

					map =
					new List<List<string>> {
						new List<string>{ " ", " ", " ", "CRT", "TO2", "CRT", " ", " ", " " },
						new List<string>{ " ", "CRT1", "MCL",  "-",   "TO2",   "CRTG",    "CC",  "CRT1", " " },
						new List<string>{ " ", "CRTG", "TO2",  "-",   "-",   "TO1",    "-",  "CRT", " " },
						new List<string>{ "-", "TO1", "-",  "-",   "-",   "-",    "-",  "-", "-" },
						new List<string>{ "-", "-", "-",  "-",   "T1",   "-",    "-",  "-", "TO1" },
						new List<string>{ "-", "TO2", "-",  "-",   "TR1",   "-",    "-",  "-", "CRT" },
						new List<string>{ " ", "-", "-",  "-",   "-",   "-",    "-",  "-", " " },
						new List<string>{ " ", "CRT", "TO1",  "-",   "-",   "-",    "TO2",  "-", " " },
						new List<string>{ " ", " ", " ", "TO2", "S", "TO1", " ", " ", " " },
						new List<string>{ " ", " ", " ",     " ", " ", " ", " ", " ", " " }
					};
					string towerLevel = MagSave.layout;
					if (towerLevel.Contains("2")) 
					{
						level = 2;
						dOoor = false;

						map = new List<List<string>> {
						new List<string>{ " ", " ", " ", "CRT", "CRT", "CRT", " ", " ", " " },
						new List<string>{ " ", "-", "TO2",  "PK",   "A1N",   "PK",    "TO2",  "-", " " },
						new List<string>{ " ", "SWR", "-",  "-",   "DMY",   "-",    "-",  "SWR", " " },
						new List<string>{ "-", "-", "-",  "-",   "-",   "-",    "-",  "-", "CRT" },
						new List<string>{ "-", "-", "-",  "-",   "T2",   "-",    "-",  "-", "TO2" },
						new List<string>{ "-", "-", "-",  "-",   "TR2",   "-",    "-",  "-", "-" },
						new List<string>{ " ", "TO2", "-",  "-",   "-",   "-",    "-",  "-", " " },
						new List<string>{ " ", "CRT", "CRT",  "TO2",   "-",   "-",    "-",  "-", " " },
						new List<string>{ " ", " ", " ", "-", "S", "-", " ", " ", " " },
						new List<string>{ " ",     " ", " ",   " ", " ", " ", "-", "-", " " }
					};
					}
					else if (towerLevel.Contains("3"))
                    {
						level = 3;
						dOoor = false;

						map = new List<List<string>> {
						new List<string>{ " ", " ", " ", "-", "-", "-", " ", " ", " " },
						new List<string>{ " ", "-", "-",  "-",   "-",   "-", "-",  "-", " " },
						new List<string>{ " ", "-", "-",  "-",   "-",   "-",    "-",  "-", " " },
						new List<string>{ "-", "-", "-",  "-",   "-",   "-",    "-",  "-", "-" },
						new List<string>{ "-", "-", "-",  "-",   "T3",   "-",    "-",  "-", "-" },
						new List<string>{ "-", "-", "-",  "-",   "TR3",   "-",    "-",  "-", " " },
						new List<string>{ " ", "-", "-",  "-",   "-",   "-",    "-",  "-", " " },
						new List<string>{ " ", "-", "-",  "-",   "-",   "-",    "-",  "-", " " },
						new List<string>{ " ", " ", " ", "-", "S", "-", " ", " ", " " },
						new List<string>{ " ",     " ", " ",   " ", " ", " ", "-", "-", " " } };
					} else if (towerLevel.Contains("4") || towerLevel.Contains("5"))
					{
						level = 4;
						map = new List<List<string>> {
						new List<string>{ " ", " ", " ", "CRT", "TO2", "CRT", " ", " ", " " },
						new List<string>{ " ", "TO2", "-",  "-",   "-",   "TO2",    "-",  "CRT1", " " },
						new List<string>{ " ", "CRT", "TO2",  "-",   "-",   "-",    "-",  "CRT", " " },
						new List<string>{ "-", "-", "-",  "-",   "TO6",   "-",    "-",  "-", "-" },
						new List<string>{ "-", "-", "-",  "TO4",   "TO5",   "CRT",    "-",  "-", "-" },
						new List<string>{ "-", "-", "-",  "-",   "-",   "-",    "-",  "-", "-" },
						new List<string>{ " ", "TR4", "TR4",  "TR4",   "TR4",   "TR4",    "TR4",  "TR4", " " },
						new List<string>{ " ", "TO2", "-",  "TO2",   "-",   "TO2",    "-",  "TO2", " " },
						new List<string>{ " ", " ", " ", "-", "-", "-", " ", " ", " " },
						new List<string>{ " ",     " ", " ",   " ", " ", " ", "-", "-", " " }
					};
					}

					List<List<string>> battleRoom = new List<List<string>>
					{
						new List<string> { "WnC", "WnN", "WnN","WnN","WnN","WnN","WnC" },
						new List<string> { "WnE",  "-",   "-",  "-",  "-",  "-", "WnW" },
						new List<string> { "WnE",  "-",   "-",  "-",  "-",  "-", "WnW" },
						new List<string> { "WnE",  "-",   "-",  "-",  "-",  "-", "WnW" },
						new List<string> { "WnE",  "-",   "-",  "-",  "-",  "-", "WnW" },
						new List<string> { "WnE",  "-",   "-",  "-",  "-",  "-", "WnW" },
						new List<string> { "WnC", "WnS","WnS", "WnS","WnS","WnS", "WnC" }
					};

					makeBattleRoom(battleRoom);

					GameObject environment = GameObject.Instantiate(new GameObject());
					environment.name = "GameEnvironment";
					GameObject walls = GameObject.Instantiate(new GameObject()); walls.name = "walls";
					walls.transform.parent = environment.transform;
					GameObject scenery = GameObject.Instantiate(new GameObject()); scenery.name = "scenery";
					scenery.transform.parent = environment.transform;
			
					GameObject.Find("battleRoom").transform.parent = environment.transform;
					GameObject.Find("battleRoom").SetActive(false);
		
					GameObject floor = GameObject.Instantiate(GameObject.Find("wall"));
					floor.name = "floor";
					floor.transform.rotation = Quaternion.Euler(90, 0, 90);
					floor.transform.parent = environment.transform;
					floor.transform.position = new Vector3(80, 0, -80);
					floor.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTextureScale = new Vector2(1, 1);
					floor.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTextureOffset = new Vector2(0, 0);
					floor.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTexture = Tools.getImage("temple_floor.png");
					floor.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().lightmapIndex = 0;
					//floor.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.shaderKeywords = new string[0];
					floor.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.SetTexture("_BumpMap", Tools.getImage("temple_floor_nrm.png"));
					floor.transform.localScale = new Vector3(350, 250, 1);
				
					GameObject roof = GameObject.Instantiate(GameObject.Find("wall"));
					roof.name = "roof";
					roof.transform.parent = environment.transform;
					roof.transform.rotation = Quaternion.Euler(270, 90, 0);
					roof.transform.position = new Vector3(80, 46, -80);
					roof.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTextureScale = new Vector2(1, 1);
					roof.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTextureOffset = new Vector2(0, 0);
					roof.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTexture = Tools.getImage("temple_floor.png");
					roof.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.SetTexture("_BumpMap", Tools.getImage("temple_floor_nrm.png"));
					//roof.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.shaderKeywords = new string[0];
					roof.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().lightmapIndex = 0;
					roof.transform.localScale = new Vector3(350, 250, 1);
	
					GameObject towerLight = GameObject.Instantiate(GameObject.Find("GameTable").transform.Find("light").gameObject);
					towerLight.transform.parent = environment.transform;
					towerLight.transform.position = new Vector3(80, 20, -80);
					towerLight.GetComponent<Light>().intensity = 0f;
					towerLight.GetComponent<Light>().type = LightType.Directional;
					towerLight.transform.rotation = Quaternion.Euler(90, 0, 0);
					towerLight.GetComponent<Light>().range = 1000;

					if (dOoor)
					{
						GameObject door = GameObject.Instantiate(Resources.Load("prefabs/cabinindoors/Door") as GameObject);
						door.name = "Door";
						door.transform.parent = environment.transform;
						door.transform.localPosition = (towerLevel.Contains("1")) ? new Vector3(-9.3f, -0.7f, -79.75f) : new Vector3(169.3f, -0.7f, -80f);
						door.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
						door.transform.localRotation = (towerLevel.Contains("1")) ? Quaternion.Euler(0, 180, 0) : Quaternion.Euler(0, 0, 0);
						door.transform.Find("FlickerAnim").Find("Objects").GetChild(2).gameObject.SetActive(false);
						door.transform.Find("HingeAnim").GetChild(0).GetChild(0).gameObject.GetComponent<MeshRenderer>().lightmapIndex = 0;
						GameObject.DestroyImmediate(door.transform.Find("HingeAnim").GetChild(0).GetChild(0).Find("PastVictoryDeathcards").gameObject);

						if (towerLevel.Contains("1"))
							door.transform.Find("FlickerAnim").gameObject.SetActive(false);

						for (int i = 0; i < door.transform.Find("HingeAnim").GetChild(0).GetChild(0).childCount; i++)
						{
							door.transform.Find("HingeAnim").GetChild(0).GetChild(0).GetChild(i).gameObject.GetComponent<MeshRenderer>().lightmapIndex = 0;
						}

						door.transform.Find("Shadow").gameObject.SetActive(false);

						door.transform.Find("HingeAnim").GetChild(0).GetChild(0).GetChild(2).transform.localScale = new Vector3(1, 1.5f, 1);
						door.transform.Find("HingeAnim").GetChild(0).GetChild(0).GetChild(2).transform.localPosition = new Vector3(0, -42, 0);

						if (towerLevel.Contains("1"))
                        {
							GameObject shopDoor = GameObject.Instantiate(door);
							shopDoor.name = "shopDoor";
							shopDoor.transform.parent = environment.transform;
							shopDoor.transform.localPosition = new Vector3(80.1f, -0.7f, -169.3f);
							shopDoor.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
							shopDoor.transform.localRotation = Quaternion.Euler(0, 90, 0);
						}

					}

					GameObject.Find("GameTable").transform.Find("light").localPosition = new Vector3(0, 17, 0);
					GameObject.Find("GameTable").transform.Find("light").gameObject.GetComponent<Light>().intensity = 1.2f;

					if (level < 4)
                    {
						GameObject rug = GameObject.Instantiate(GameObject.Find("wall"));
						rug.name = "rug";
						rug.transform.rotation = Quaternion.Euler(90, 0, 0);
						rug.transform.parent = environment.transform;
						rug.transform.position = new Vector3(80, 0.001f, -90);
						rug.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTextureScale = new Vector2(1, 1);
						rug.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTextureOffset = new Vector2(0, 0);
						rug.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTexture = Tools.getImage("templerug"+ level + ".png");
						rug.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().lightmapIndex = 0;
						//floor.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.shaderKeywords = new string[0];
						rug.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.SetTexture("_BumpMap", Tools.getImage("templerug_normal.png"));
						rug.transform.localScale = new Vector3(10, 10, 1);
					}
					if (level >= 4)
                    {
						GameObject tWalls4 = GameObject.Instantiate(GameObject.Find("towerWall4"));
						tWalls4.transform.parent = environment.transform;
						tWalls4.transform.rotation = Quaternion.Euler(0, 270, 0);
						tWalls4.transform.position = new Vector3(80f, 13.5f, -80f);
						tWalls4.transform.localScale = new Vector3(13f, 8.85f, 13f);
						tWalls4.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material.mainTexture = (Resources.Load("art/generictexture3d/brick/Pavement_Brick_002_COLOR") as Texture2D);
						tWalls4.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().lightmapIndex = 1;
						tWalls4.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material.SetTexture("_BumpMap", Resources.Load("art/generictexture3d/brick/Pavement_Brick_002_NRM") as Texture);
						tWalls4.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material.color = new Color(0.7642f, 0.5087f, 0.3641f, 1);
						tWalls4.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material.mainTextureScale = new Vector2(2.5f, 2.5f);
						floor.transform.localScale = new Vector3(300, 200, 1);
						floor.transform.rotation = Quaternion.Euler(90, 0, 0);
						floor.transform.position = new Vector3(80, 0, -80);
						//floor.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().lightmapIndex = -1;
						roof.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().lightmapIndex = -1;
						roof.transform.localScale = new Vector3(180, 185, 1);

						towerLight.GetComponent<Light>().intensity = 1.5f;
						towerLight.transform.position = new Vector3(80f, 100f, -20);
						towerLight.transform.localRotation = Quaternion.Euler(40, 180, 0);
						towerLight.GetComponent<Light>().color = new Color(0.66f, 0, 0.66f, 1f);
						towerLight.GetComponent<Light>().range = 2000;
						towerLight.GetComponent<Light>().type = LightType.Point;
						/*
						GameObject towerLightPart2 = GameObject.Instantiate(towerLight);
						towerLightPart2.transform.parent = environment.transform;
						towerLightPart2.transform.position = new Vector3(80, 20, -80);
						towerLightPart2.transform.rotation = Quaternion.Euler(270, 0, 0);
						towerLightPart2.GetComponent<Light>().intensity = 0.4f;*/

						Singleton<FirstPersonController>.Instance.GetComponentInChildren<Camera>().farClipPlane = 900f;
						Singleton<FirstPersonController>.Instance.GetComponentInChildren<Camera>().backgroundColor = new Color(0, 0, 0, 1f);
						GameObject towerStars = new GameObject("bgStarParent");
						towerStars.transform.position = new Vector3(80, -73.5f, -40);
						towerStars.transform.parent = environment.transform;
						GameObject towerBg = GameObject.Instantiate(GameObject.Find("wall"));
						towerBg.transform.parent = towerStars.transform;
						towerBg.name = "bgStars";
						towerBg.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTexture = Tools.getImage("stars.png");
						towerBg.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.shaderKeywords = new string[0];
						towerBg.transform.Find("BrickGround").gameObject.AddComponent<UVScroller>();
						towerBg.transform.Find("BrickGround").gameObject.GetComponent<UVScroller>().XscrollSpeed = 0.01f;
						towerBg.transform.localPosition = new Vector3(0.1f, 93.3f, 212.75f);
						towerBg.transform.rotation = Quaternion.Euler(325, 0, 0);
						towerBg.transform.localScale = new Vector3(275.5f, 180, 1);
						GameObject towerBg2 = GameObject.Instantiate(towerBg);
						towerBg2.transform.parent = towerStars.transform;
						towerBg2.transform.localPosition = new Vector3(-113f, 91.3f, 79);
						towerBg2.transform.rotation = Quaternion.Euler(325, 290f, 0);
						GameObject towerBg3 = GameObject.Instantiate(towerBg);
						towerBg3.transform.parent = towerStars.transform;
						towerBg3.transform.localPosition = new Vector3(123f, 91.3f, 79);
						towerBg3.transform.rotation = Quaternion.Euler(325, 70f, 0);
						GameObject blockUgley = GameObject.Instantiate(towerBg);
						blockUgley.transform.parent = towerStars.transform;
						blockUgley.transform.position = new Vector3(-0.25f, 45f, -2.1f);
						blockUgley.transform.rotation = Quaternion.Euler(270f, 270, 0);
						blockUgley.transform.localScale = new Vector3(23f, 22f, 10f);
						GameObject blockUgley2 = GameObject.Instantiate(blockUgley);
						blockUgley2.transform.parent = towerStars.transform;
						blockUgley2.transform.position = new Vector3(158.7f, 45f, -2.3f);
						blockUgley2.transform.localScale = new Vector3(24f, 32.75f, 10);
						if (towerLevel.Contains("5"))
                        {
							tWalls4.transform.Find("THE MOOON").gameObject.SetActive(false);
                        } else
                        {
							tWalls4.transform.Find("THE MOOON").gameObject.AddComponent<Light>().color = new Color(1f, 0.25f, 0.3875f, 1);
							tWalls4.transform.Find("THE MOOON").gameObject.GetComponent<Light>().intensity = 5;
							tWalls4.transform.Find("THE MOOON").gameObject.GetComponent<Light>().range = 200;
						}

						floor.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTexture = Tools.getImage("temple_topfloor.png");
						floor.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.SetTexture("_BumpMap", Tools.getImage("temple_topfloor_nrm.png"));
					}
					else if (level != 3 || SavedVars.LearnedMechanics.Contains("druid;"))
					{
						GameObject tWalls = GameObject.Instantiate(GameObject.Find("towerWalls"));
						tWalls.transform.parent = environment.transform;
						tWalls.transform.rotation = Quaternion.Euler(270, 350.75f, 0);
						tWalls.transform.position = new Vector3(80, 20, -80);
						tWalls.transform.localScale = new Vector3(1300, 1300, 1300);
						tWalls.GetComponent<MeshRenderer>().material.mainTexture = (Resources.Load("art/generictexture3d/brick/Pavement_Brick_002_COLOR") as Texture2D);
						tWalls.GetComponent<MeshRenderer>().material.SetTexture("_BumpMap", Resources.Load("art/generictexture3d/brick/Pavement_Brick_002_NRM") as Texture);
						tWalls.GetComponent<MeshRenderer>().material.color = new Color(0.7642f, 0.5087f, 0.3641f, 1);
						tWalls.GetComponent<MeshRenderer>().material.mainTextureScale = new Vector2(2.5f, 2.5f);
						tWalls.GetComponent<MeshRenderer>().lightmapIndex = 0;
						/*GameObject shadows = GameObject.Instantiate(GameObject.Find("towerWalls"));
						shadows.name = "shadows";
						shadows.transform.parent = environment.transform;
						shadows.transform.rotation = Quaternion.Euler(270, 350.75f, 0);
						shadows.transform.position = new Vector3(80, 1.5f, -80);
						shadows.transform.localScale = new Vector3(1290f, 1290f, 50);
						shadows.GetComponent<MeshRenderer>().material.shader = GameObject.Find("tbPillar").transform.Find("Shadow").gameObject.GetComponent<MeshRenderer>().material.shader;
						shadows.GetComponent<MeshRenderer>().material.shaderKeywords = GameObject.Find("tbPillar").transform.Find("Shadow").gameObject.GetComponent<MeshRenderer>().material.shaderKeywords;
						shadows.GetComponent<MeshRenderer>().material.mainTexture = Tools.getImage("shadow_glow.png");
						shadows.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1, 1);
						shadows.GetComponent<MeshRenderer>().material.mainTextureScale = new Vector2(1, 1f);
						shadows.GetComponent<MeshRenderer>().lightmapIndex = 0;*/
					}
					else
                    {
						GameObject tWalls = GameObject.Instantiate(GameObject.Find("towerWall3"));
						tWalls.transform.parent = environment.transform;
						tWalls.transform.rotation = Quaternion.Euler(270, 350.75f, 0);
						tWalls.transform.position = new Vector3(80, 20, -80);
						tWalls.transform.localScale = new Vector3(1300, 1300, 1300);
						tWalls.GetComponent<MeshRenderer>().material.mainTexture = (Resources.Load("art/generictexture3d/brick/Pavement_Brick_002_COLOR") as Texture2D);
						tWalls.GetComponent<MeshRenderer>().material.SetTexture("_BumpMap", Resources.Load("art/generictexture3d/brick/Pavement_Brick_002_NRM") as Texture);
						tWalls.GetComponent<MeshRenderer>().material.color = new Color(0.7642f, 0.5087f, 0.3641f, 1);
						tWalls.GetComponent<MeshRenderer>().material.mainTextureScale = new Vector2(2.5f, 2.5f);
						tWalls.GetComponent<MeshRenderer>().lightmapIndex = 0;

						GameObject voidWall1 = GameObject.Instantiate(GameObject.Find("wall"));
						voidWall1.name = "voidwall";
						voidWall1.transform.parent = GameObject.Find("walls").transform;
						voidWall1.transform.Find("BrickGround").localPosition = new Vector3(0, 0, 0);
						voidWall1.transform.position = new Vector3(122.3f, 25f, -172.4f);
						voidWall1.transform.localRotation = Quaternion.Euler(0, 225, 0);
						voidWall1.transform.localScale = new Vector3(22, 50, 0);
						voidWall1.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.color = new Color(0f, 0f, 0f, 1);
						voidWall1.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTexture = Tools.getImage("blank.png");
						voidWall1.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.shaderKeywords = new string[0];

						GameObject voidWall2 = GameObject.Instantiate(voidWall1);
						voidWall2.name = "voidwall2";
						voidWall2.transform.parent = GameObject.Find("walls").transform;
						voidWall2.transform.position = new Vector3(148.75f, 22f, -154.1f);
						voidWall2.transform.localRotation = Quaternion.Euler(0, 83.5f, 0);

						GameObject voidFloor = GameObject.Instantiate(voidWall1);
						voidFloor.name = "voidfloor";
						voidFloor.transform.parent = GameObject.Find("scenery").transform;
						voidFloor.transform.position = new Vector3(132.8f, 0.1f, -220.8f);
						voidFloor.transform.localRotation = Quaternion.Euler(90f, 344f, 0);
						voidFloor.transform.localScale = new Vector3(115f, 114.5f, 1);

						GameObject voidRoof = GameObject.Instantiate(voidFloor);
						voidRoof.name = "voidroof";
						voidRoof.transform.parent = GameObject.Find("scenery").transform;
						voidRoof.transform.position = new Vector3(132.8f, 45.86f, -220.8f);
						voidRoof.transform.localRotation = Quaternion.Euler(270f, 344f, 0);
						voidRoof.transform.localScale = new Vector3(115f, 114.5f, 1);
					}
					GameObject.Find("Player").transform.Find("Directional Light").gameObject.SetActive(true);
					GameObject.Find("Player").transform.Find("Directional Light").GetComponent<Light>().intensity = 0f;
					Singleton<FirstPersonController>.Instance.GetComponentInChildren<Camera>().farClipPlane = 400f;
					Singleton<FirstPersonController>.Instance.GetComponentInChildren<Camera>().backgroundColor = new Color(0.9333f, 0.9569f, 0.7765f, 1f);
					if (level == 3)
                    {
						GameObject darkWall = GameObject.Instantiate(GameObject.Find("wall"));
						darkWall.name = "border1";
						darkWall.transform.localScale = new Vector3(90, 50, 1);
						darkWall.transform.Find("BrickGround").localPosition = new Vector3(0, 0, 0);
						darkWall.transform.position = new Vector3(143.75f, 62.4f, -219.18f);
						darkWall.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.color = new Color(0f, 0f, 0f, 1);
						darkWall.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTexture = Tools.getImage("blank.png");
						darkWall.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.shaderKeywords = new string[0];
						GameObject darkWall2 = GameObject.Instantiate(darkWall);
						darkWall2.transform.position = new Vector3(143.75f, -24.82f, -205);
						darkWall.transform.parent = environment.transform;
						darkWall2.transform.parent = environment.transform;
						Singleton<FirstPersonController>.Instance.GetComponentInChildren<Camera>().backgroundColor = new Color(0f, 0f, 0f, 1f);
					}
					if (level >= 4)
                    {
						Singleton<FirstPersonController>.Instance.GetComponentInChildren<Camera>().backgroundColor = new Color(0, 0, 0, 1f);
					}

					//floor.SetActive(false);

					break;

				case "goobert":

					List<List<string>> mapId = new List<List<string>>();
					if (loading)
					{
						mapId = RoomGen.DecompileLayout(MagSave.GetLayout());
					} else
					{
						mapId = RoomGen.generateMapId("goobert");
					}

					map = RoomGen.generateMap(mapId, "goobert");

					battleRoom = new List<List<string>>
					{
						new List<string> { "W1C", "W2N", "W1N","W1N","W1N","W1N","W1C" },
						new List<string> { "W1E",  "-",   "-",  "-",  "-",  "-", "W1W" },
						new List<string> { "W1E",  "-",   "-",  "-",  "-",  "-", "W2W" },
						new List<string> { "W1E",  "-",   "-",  "-","-",  "-", "W1W" },
						new List<string> { "W1E",  "-",   "-",  "-",  "-",  "-", "W1W" },
						new List<string> { "W1E",  "-",   "-",  "-",  "-",  "-", "W1W" },
						new List<string> { "W1C", "W1S","W1S", "W1S","W1S","W1S", "W1W" }
					};

					makeBattleRoom(battleRoom);

					environment = GameObject.Instantiate(new GameObject());
					environment.name = "GameEnvironment";
					GameObject.Find("battleRoom").transform.parent = environment.transform;
					GameObject.Find("battleRoom").SetActive(false);

					walls = GameObject.Instantiate(new GameObject()); walls.name = "walls";
					walls.transform.parent = environment.transform;
					scenery = GameObject.Instantiate(new GameObject()); scenery.name = "scenery";
					scenery.transform.parent = environment.transform;

					floor = GameObject.Instantiate(GameObject.Find("wall"));
					floor.name = "floor";
					floor.transform.parent = environment.transform;

					/*
					towerLight = GameObject.Instantiate(GameObject.Find("light"));
					towerLight.transform.parent = environment.transform;
					towerLight.transform.position = new Vector3(80, 80, -160);
					towerLight.GetComponent<Light>().intensity = 0.6f;
					towerLight.GetComponent<Light>().type = LightType.Directional;
					towerLight.GetComponent<Light>().color = new Color(1f, 1, 1, 1);
					towerLight.GetComponent<Light>().shadows = LightShadows.Soft;
					towerLight.transform.rotation = Quaternion.Euler(90, 0, 0);
					towerLight.GetComponent<Light>().range = 1000;
					*/
					GameObject path = GameObject.Instantiate(floor);
					path.transform.rotation = Quaternion.Euler(90, 0, 0);
					path.transform.parent = environment.transform;
					path.transform.position = new Vector3(340, 0, -600);
					path.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.color = new Color(0.5f, 1f, 0.5f);
					path.transform.localScale = new Vector3(5000, 5000, 1);
					path.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTextureScale = new Vector2(15f, 15f);
					path.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTexture = (Resources.Load("art/generictexture3d/goo/Goo_Color") as Texture2D);
					path.transform.Find("BrickGround").localRotation = Quaternion.Euler(0, 0, 270);
					path.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTextureScale = new Vector2(65, 65);
					path.name = "DungeonFloor";
					path.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.SetTexture("_BumpMap", Resources.Load("art/generictexture3d/goo/Goo_Normal") as Texture);

					/*
					GameObject.Instantiate(Resources.Load("prefabs/cabinindoors/GooWizardBottle")).name = "Goobert";
					GameObject goober = GameObject.Find("Goobert");
					goober.transform.Find("GooWizard").Find("Bottle").gameObject.SetActive(false);
					goober.transform.Find("GooWizard").Find("Cork").gameObject.SetActive(false);
					goober.transform.position = new Vector3(80f, 9.9651f, -0f);
					goober.transform.parent = environment.transform;
					goober.transform.rotation = new Quaternion(0f, 0.7045f, 0f, -0.7097f);
					goober.transform.localScale = new Vector3(5f, 5f, 5f);
					GameObject.Instantiate(Resources.Load("art/assets3d/wizardbattle/practicemage/WizardHat", typeof(GameObject)), new Vector3(0f, 1.45f, 0f), Quaternion.Euler(279.9129f, 244.4183f, 345.9203f), goober.transform).name = "goobhat";
					GameObject goobhat = GameObject.Find("goobhat");
					goobhat.transform.localScale = new Vector3(0.45f, 0.45f, 0.45f);
					goobhat.transform.localPosition = new Vector3(0f, 1.45f, 0f);
					goobhat.GetComponent<MeshRenderer>().material.color = new Color(0.7072f, 0f, 1f, 1f);
					
					GameObject.Instantiate(GameObject.Find("AncientRuins_ArchBroken (1)")).name = "Arch2";
					GameObject.Find("Arch2").transform.parent = environment.transform;
					GameObject.Find("Arch2").transform.localRotation = Quaternion.Euler(279.0093f, 116.0881f, 0.0012f);
					GameObject.Find("Arch2").transform.localPosition = new Vector3(55f, -1.94f, -554.4606f);
					*/
					GameObject LightSource = new GameObject("LightSource");
					LightSource.transform.parent = environment.transform;
					LightSource.transform.localRotation = Quaternion.Euler(0, 0, 0);
					LightSource.AddComponent<Light>().intensity = 1.5f;
					LightSource.GetComponent<Light>().range = 175;
					LightSource.GetComponent<Light>().color = new Color(0.8f, 1, 0.8f, 1);
					LightSource.GetComponent<Light>().renderMode = LightRenderMode.ForcePixel;

					GameObject.Find("deckLight").transform.parent.localPosition = new Vector3(0f, 14f, 5);
					GameObject.Find("deckLight").transform.parent.gameObject.GetComponent<Light>().color = new Color(0.8f, 1, 0.8f, 1);
					GameObject.Find("deckLight").transform.parent.gameObject.GetComponent<Light>().intensity = 5;

					GameObject.Find("deckLight").transform.localPosition = new Vector3(0f, 0, -20);
					GameObject.Find("deckLight").GetComponent<Light>().color = new Color(0.8f, 1, 0.8f, 1);
					GameObject.Find("deckLight").GetComponent<Light>().intensity = 1.75f;
					GameObject.Find("deckLight").GetComponent<Light>().renderMode = LightRenderMode.ForcePixel;
					GameObject.Find("deckLight").GetComponent<Light>().shadows = LightShadows.Soft;

					GameObject.Find("Directional Light").GetComponent<Light>().intensity = 0f;
					Singleton<FirstPersonController>.Instance.GetComponentInChildren<Camera>().farClipPlane = 320 - getClippingPlaneQualityAdjustment();
					Singleton<FirstPersonController>.Instance.GetComponentInChildren<Camera>().backgroundColor = new Color(0, 0, 0, 1f);
					GameObject starParent = new GameObject("bgStarParent");
					starParent.transform.parent = GameObject.Find("Player").transform;
					starParent.transform.localPosition = new Vector3(0, 0, 0);
					if (config.isometricMode)
                    {
						starParent.transform.localPosition = new Vector3(0, 0, -100);
						starParent.transform.localRotation = Quaternion.Euler(0, 45, 0);
					}
					GameObject bgStars = GameObject.Instantiate(GameObject.Find("wall"));
					bgStars.transform.parent = starParent.transform;
					bgStars.name = "bgStars";
					bgStars.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTexture = Tools.getImage("stars.png");
					bgStars.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.shaderKeywords = new string[0];
					bgStars.transform.Find("BrickGround").gameObject.AddComponent<UVScroller>();
					bgStars.transform.Find("BrickGround").gameObject.GetComponent<UVScroller>().XscrollSpeed = 0.025f;
					bgStars.transform.localPosition = new Vector3(0.1f, 93.3f, 212.75f);
					bgStars.transform.rotation = Quaternion.Euler(325, 0, 0);
					bgStars.transform.localScale = new Vector3(200, 150, 1);
					GameObject stars2 = GameObject.Instantiate(bgStars);
					stars2.transform.parent = starParent.transform;
					stars2.transform.localPosition = new Vector3(-101.95f, 93.3f, 201.5f);
					stars2.transform.rotation = Quaternion.Euler(325, 290f, 0);
					GameObject stars3 = GameObject.Instantiate(bgStars);
					stars3.transform.parent = starParent.transform;
					stars3.transform.localPosition = new Vector3(106f, 93.3f, 136.75f);
					stars3.transform.rotation = Quaternion.Euler(325, 70f, 0);
					floor.SetActive(false);
					break;
				case "espeara":
					mapId = new List<List<string>>();
					if (loading)
					{
						mapId = RoomGen.DecompileLayout(MagSave.GetLayout());
					}
					else
					{
						mapId = RoomGen.generateMapId("espeara");
					}

					map = RoomGen.generateMap(mapId, "espeara");

					battleRoom = new List<List<string>>
					{
						new List<string> { "W4C", "W5N", "W4N","W4N","W4N","W4N","W4C" },
						new List<string> { "W4E",  "-",   "-",  "-",  "-",  "-", "W4W" },
						new List<string> { "W4E",  "-",   "-",  "-",  "-",  "-", "W5W" },
						new List<string> { "W4E",  "-",   "-",  "-","-",  "-", "W4W" },
						new List<string> { "W4E",  "-",   "-",  "-",  "-",  "-", "W4W" },
						new List<string> { "W4E",  "-",   "-",  "-",  "-",  "-", "W4W" },
						new List<string> { "W4C", "W4S","W4S", "W4S","W4S","W4S", "W4W" }
					};

					makeBattleRoom(battleRoom);

					environment = GameObject.Instantiate(new GameObject());
					environment.name = "GameEnvironment";
					GameObject.Find("battleRoom").transform.parent = environment.transform;
					GameObject.Find("battleRoom").SetActive(false);

					walls = GameObject.Instantiate(new GameObject()); walls.name = "walls";
					walls.transform.parent = environment.transform;
					scenery = GameObject.Instantiate(new GameObject()); scenery.name = "scenery";
					scenery.transform.parent = environment.transform;

					floor = GameObject.Instantiate(GameObject.Find("wall"));
					floor.name = "floor";
					floor.transform.localScale = new Vector3(1000, 1000, 1);
					floor.transform.position = new Vector3(80, -0.25f, -160);
					floor.transform.rotation = Quaternion.Euler(90, 0, 90);
					floor.transform.parent = environment.transform;
					floor.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTextureScale = new Vector2(6, 6);
					floor.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTextureOffset = new Vector2(0, 0);
					floor.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.color = new Color(0f, 0f, 0f, 1f);
					floor.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTexture = Tools.getImage("blank.png");

					/*towerLight = GameObject.Instantiate(GameObject.Find("light"));
					towerLight.transform.parent = environment.transform;
					towerLight.transform.position = new Vector3(80, 80, -160);
					towerLight.GetComponent<Light>().intensity = 0.6f;
					towerLight.GetComponent<Light>().type = LightType.Directional;
					towerLight.GetComponent<Light>().shadows = LightShadows.Soft;
					towerLight.transform.rotation = Quaternion.Euler(90, 0, 0);
					towerLight.GetComponent<Light>().range = 1000;*/

					path = GameObject.Instantiate(floor);
					path.transform.parent = environment.transform;
					path.transform.position = new Vector3(340, 0, -600);
					path.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.color = new Color(0.25f, 0.25f, 0.25f);
					path.transform.localScale = new Vector3(5000, 5000, 1);
					path.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTextureScale = new Vector2(15f, 15f);
					path.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTexture = (Resources.Load("art/generictexture3d/roughrock/Rough_rock_003_COLOR") as Texture2D);
					path.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.SetTexture("_BumpMap", Resources.Load("art/generictexture3d/roughrock/Rough_rock_003_NRM") as Texture2D);
					path.transform.Find("BrickGround").localRotation = Quaternion.Euler(0, 0, 270);
					path.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTextureScale = new Vector2(55, 55);
					path.name = "DungeonFloor";

					GameObject ceiling = GameObject.Instantiate(path);
					ceiling.transform.rotation = Quaternion.Euler(270, 0, 0);
					ceiling.name = "ceiling";
					ceiling.transform.parent = environment.transform;
					ceiling.transform.position = new Vector3(340, 30.5f, -600);

					GameObject lantern = GameObject.Instantiate(Resources.Load("prefabs/cabinindoors/HangingLantern") as GameObject);
					lantern.name = "Lantern";
					lantern.transform.parent = environment.transform;
					GameObject.DestroyImmediate(lantern.transform.Find("Light").gameObject.GetComponent<FlickerLight>());
					lantern.transform.Find("Light").gameObject.GetComponent<Light>().intensity = 2f;
					lantern.transform.Find("Light").gameObject.GetComponent<Light>().range = 185;
					lantern.transform.Find("Light").gameObject.GetComponent<Light>().renderMode = LightRenderMode.ForcePixel;
					lantern.transform.localPosition = new Vector3(-90, -90, 0);

					GameObject.Find("Directional Light").GetComponent<Light>().intensity = 0f;
					Singleton<FirstPersonController>.Instance.GetComponentInChildren<Camera>().farClipPlane = 325 - getClippingPlaneQualityAdjustment();
					Singleton<FirstPersonController>.Instance.GetComponentInChildren<Camera>().backgroundColor = new Color(0.0784f, 0.1024f, 0.058f, 1);

					GameObject.Find("deckLight").transform.parent.localPosition = new Vector3(0, 25, 0);
					GameObject.Find("deckLight").transform.parent.gameObject.GetComponent<Light>().intensity = 0f;
					GameObject.Find("deckLight").GetComponent<Light>().range = 100;
					GameObject.Find("deckLight").GetComponent<Light>().color = new Color(0.98f, 0.34f, 0, 1);
					GameObject.Find("deckLight").GetComponent<Light>().intensity = 0;
					GameObject.Find("deckLight").GetComponent<Light>().renderMode = LightRenderMode.ForcePixel;
					floor.SetActive(false);
					break;
				case "lonely":

					mapId = new List<List<string>>();
					if (loading)
					{
						mapId = RoomGen.DecompileLayout(MagSave.GetLayout());
					}
					else
					{
						mapId = RoomGen.generateMapId("lonely");
					}

					map = RoomGen.generateMap(mapId, "lonely");

					battleRoom = new List<List<string>>
					{
						new List<string> { "W8C", "W8N", "W8N","W8N","W8N","W8N","W8C" },
						new List<string> { "W8E",  "-",   "-",  "-",  "-",  "-", "W8W" },
						new List<string> { "W8E",  "-",   "-",  "-",  "-",  "-", "W8W" },
						new List<string> { "W8E",  "-",   "-",  "-","-",  "-", "W8W" },
						new List<string> { "W8E",  "-",   "-",  "-",  "-",  "-", "W8W" },
						new List<string> { "W8E",  "-",   "-",  "-",  "-",  "-", "W8W" },
						new List<string> { "W8C", "W8S","W8S", "W8S","W8S","W8S", "W8W" }
					};

					makeBattleRoom(battleRoom);

					environment = GameObject.Instantiate(new GameObject());
					environment.name = "GameEnvironment";
					GameObject.Find("battleRoom").transform.parent = environment.transform;
					GameObject.Find("battleRoom").SetActive(false);

					walls = GameObject.Instantiate(new GameObject()); walls.name = "walls";
					walls.transform.parent = environment.transform;
					scenery = GameObject.Instantiate(new GameObject()); scenery.name = "scenery";
					scenery.transform.parent = environment.transform;

					floor = GameObject.Instantiate(GameObject.Find("wall"));
					floor.name = "floor";
					floor.transform.parent = environment.transform;

					path = GameObject.Instantiate(floor);
					path.transform.rotation = Quaternion.Euler(90, 0, 0);
					path.transform.parent = environment.transform;
					path.transform.position = new Vector3(340, 0, -600);
					path.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.color = new Color(0.6f, 0.6f, 0.8f);
					path.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTextureScale = new Vector2(100f, 100f);
					path.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().lightmapIndex = 0;
					path.transform.localScale = new Vector3(5000, 5000, 1);
					path.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTexture = (Resources.Load("art/assets3d/cabin/floor/woodenFloor_albedo") as Texture2D);
					path.transform.Find("BrickGround").localRotation = Quaternion.Euler(0, 0, 270);
					path.name = "DungeonFloor";

					Singleton<FirstPersonController>.Instance.GetComponentInChildren<Camera>().farClipPlane = 175 - (getClippingPlaneQualityAdjustment() / 2);
					Singleton<FirstPersonController>.Instance.GetComponentInChildren<Camera>().backgroundColor = new Color(0f, 0f, 0f, 1f);
					GameObject.Find("Directional Light").GetComponent<Light>().intensity = 1.5f;
					GameObject.Find("Directional Light").GetComponent<Light>().range = 175f;
					GameObject.Find("Directional Light").transform.localPosition = new Vector3(0, 3.5f, 0f);

					GameObject voidParent = new GameObject("bgStarParent");
					voidParent.transform.parent = GameObject.Find("Player").transform;
					voidParent.transform.localPosition = new Vector3(0, 0, 125);
					GameObject bgVoid = GameObject.Instantiate(GameObject.Find("wall"));
					bgVoid.transform.parent = voidParent.transform;
					bgVoid.name = "bgVoid";
					bgVoid.transform.Find("BrickGround").gameObject.SetActive(false);
					bgVoid.transform.localPosition = new Vector3(0, 0, 0);
					GameObject fade = new GameObject("starFade");
					fade.AddComponent<SpriteRenderer>().sprite = Tools.getSprite("stars.png");
					fade.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
					fade.transform.parent = bgVoid.transform;
					fade.transform.localPosition = new Vector3(0f,0f,0f);
					fade.transform.rotation = Quaternion.Euler(0, 0, 0);
					fade.transform.localScale = new Vector3(200, 150, 1);


					GameObject voidStars = GameObject.Instantiate(GameObject.Find("wall"));
					voidStars.transform.parent = voidParent.transform;
					voidStars.name = "bgStars";
					voidStars.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTexture = Tools.getImage("stars.png");
					voidStars.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.shaderKeywords = new string[0];
					voidStars.transform.Find("BrickGround").gameObject.AddComponent<UVScroller>();
					voidStars.transform.Find("BrickGround").gameObject.GetComponent<UVScroller>().YscrollSpeed = 0.025f;
					voidStars.transform.localPosition = new Vector3(0f, 52f, 25f);
					voidStars.transform.rotation = Quaternion.Euler(325, 0, 0);
					voidStars.transform.localScale = new Vector3(200, 150, 1);
					if (config.isometricActive)
                    {
						voidParent.transform.localPosition = new Vector3(50, 0, 50);
						voidParent.transform.localRotation = Quaternion.Euler(0, 45, 0);
                    }

					GameObject.Find("deckLight").transform.localPosition = new Vector3(0, 0, -10f);
					GameObject.Find("deckLight").transform.parent.localPosition = new Vector3(0, 10, 0f);
					GameObject.Find("deckLight").transform.parent.gameObject.GetComponent<Light>().shadows = LightShadows.Soft;
					GameObject.Find("deckLight").transform.parent.gameObject.GetComponent<Light>().intensity = 0.75f;
					GameObject.Find("deckLight").gameObject.GetComponent<Light>().intensity = 0.8f;

					GameObject floorLight = GameObject.Instantiate(GameObject.Find("deckLight"));
					floorLight.name = "floorLight";
					floorLight.transform.parent = GameObject.Find("deckLight").transform.parent;
					floorLight.transform.localPosition = new Vector3(0, 13, 45);
					floorLight.GetComponent<Light>().color = new Color(0.6537f, 0.8737f, 0.9137f, 1);
					floorLight.GetComponent<Light>().intensity = 4;
					floorLight.GetComponent<Light>().range = 80;
					break;
				case "depths":
					map =
					new List<List<string>> {
						new List<string>{ "-", "-", "-",  " ",   "EXTD", " ", "-", "-", "-" },
						new List<string>{ "-", "-", "-",  " ",   "MAGNR",   " ",    "-",  "-", "-" },
						new List<string>{ "-", "-", "-",  " ",   "-",   " ",    "-",  "-", "-" },
						new List<string>{ "-", "-", "-",  " ",   "-",   " ",    "-",  "-", "-" },
						new List<string>{ "-", "-", "-",  " ",   "-",   " ",    "-",  "-", "-" },
						new List<string>{ "-", "-", "-",  " ",   "-",   " ",    "-",  "-", "-" },
						new List<string>{ "-", "-", "-",  " ",   "-",  " ",    "-",  "-", "-" },
						new List<string>{ "-", "-", "-",  " ",   "-",   " ",    "-",  "-", "-" },
						new List<string>{ "-", "-", "-",  " ",   "-",   " ",    "-",  "-", "-" },
						new List<string>{ "-", "-", "-",  " ",   "-",   " ",    "-",  "-", "-" },
						new List<string>{ "-", "-", "-",  " ",   "-",   " ",    "-",  "-", "-" },
						new List<string>{ "-", "-", "-",  " ",   "-",   " ",    "-",  "-", "-" },
						new List<string>{ "-", "-", "-",  " ",   " ",  " ",    "-",  "-", "-" },

					};
					environment = GameObject.Instantiate(new GameObject());
					environment.name = "GameEnvironment";

					GameObject tiltedWall = GameObject.Instantiate(GameObject.Find("wall"));
					tiltedWall.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTextureScale = new Vector2(10, 10);
					tiltedWall.transform.rotation = Quaternion.Euler(11.5402f, 177.54f, 0);
					tiltedWall.transform.localPosition = new Vector3(80f, 3.5f, -280.5195f);
					tiltedWall.transform.localScale = new Vector3(500f, 150f, 150f);
					tiltedWall.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0.25f);

					path = GameObject.Instantiate(GameObject.Find("wall"));
					path.name = "floor";
					path.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0.25f);
					path.transform.localPosition = new Vector3(0, 9.72f, 0);
					path.transform.localScale = new Vector3(5000f, 1f, 5000f);
					path.transform.Find("BrickGround").transform.rotation = Quaternion.Euler(90, 0, 0);
					path.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.shaderKeywords = new string[0];
					path.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTextureScale = new Vector2(15f, 15f);
					path.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTexture = (Tools.getImage("sandtexture.png"));
					path.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTextureScale = new Vector2(35, 35);
					path.name = "DungeonFloor";


					towerLight = GameObject.Instantiate(GameObject.Find("light"));
					towerLight.transform.parent = environment.transform;
					towerLight.transform.position = new Vector3(80, 20, -80);
					towerLight.GetComponent<Light>().intensity = 0.6f;
					towerLight.GetComponent<Light>().type = LightType.Directional;
					towerLight.transform.rotation = Quaternion.Euler(90, 0, 0);
					towerLight.GetComponent<Light>().range = 1000;
					GameObject towerLight2 = GameObject.Instantiate(towerLight);
					towerLight.GetComponent<Light>().shadows = LightShadows.Soft;
					towerLight2.transform.rotation = Quaternion.Euler(270, 0, 0);
					towerLight2.transform.parent = environment.transform;//X11 Y5
					try
					{
						GameObject.Find("hammerStuff").SetActive(false);
					} catch { }
					GameObject.Find("MagnificusAnim").transform.position = new Vector3(80.3f, 25.42f, -12);


					Singleton<FirstPersonController>.Instance.GetComponentInChildren<Camera>().farClipPlane = 125f;
					Singleton<FirstPersonController>.Instance.GetComponentInChildren<Camera>().backgroundColor = new Color(0f, 0f, 0.65f, 1f);

					GameObject.Find("Directional Light").GetComponent<Light>().intensity = 2.5f;
					GameObject.Find("Directional Light").GetComponent<Light>().range = 175f;
					GameObject.Find("Directional Light").transform.localPosition = new Vector3(0, -9f, 0f);

					break;
				case "finale":
					map =
					new List<List<string>> {
						new List<string>{ "-", "-", "-",  " ",   " ", " ", "-", "-", "-" },
						new List<string>{ "-", "-", "-",  " ",   "B4",   " ",    "-",  "-", "-" },
						new List<string>{ "-", "-", "-",  " ",   "-",   " ",    "-",  "-", "-" },
						new List<string>{ "-", "-", "-",  " ",   "-",   " ",    "-",  "-", "-" },
						new List<string>{ "-", "-", "-",  " ",   "EN",   " ",    "-",  "-", "-" },
						new List<string>{ "-", "-", "-",  " ",   "-",   " ",    "-",  "-", "-" },
						new List<string>{ "-", "-", "-",  " ",   "E",  " ",    "-",  "-", "-" },
						new List<string>{ "-", "-", "-",  " ",   "-",   " ",    "-",  "-", "-" },
						new List<string>{ "-", "-", "-",  " ",   "FC",   " ",    "-",  "-", "-" },
						new List<string>{ "-", "-", "-",  " ",   "-",   " ",    "-",  "-", "-" },
						new List<string>{ "-", "-", "-",  " ",   "SPWN",   " ",    "-",  "-", "-" },
						new List<string>{ "-", "-", "-",  " ",   "S",   " ",    "-",  "-", "-" },
						new List<string>{ "-", "-", "-",  " ",   " ",  " ",    "-",  "-", "-" },

					};
					environment = GameObject.Instantiate(new GameObject());
					environment.name = "GameEnvironment";

					path = GameObject.Instantiate(GameObject.Find("wall"));
					path.name = "floor";
					//path.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0.25f);
					path.transform.localPosition = new Vector3(81f, 10f, 0);
					path.transform.localRotation = Quaternion.Euler(90, 90, 0);
					path.transform.localScale = new Vector3(5000f, 1f, 5000f);
					path.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTexture = (Resources.Load("art/generictexture3d/brick/Pavement_Brick_002_COLOR") as Texture2D);
					path.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.SetTexture("_BumpMap", Resources.Load("art/generictexture3d/brick/Pavement_Brick_002_NRM") as Texture);
					path.transform.Find("BrickGround").localRotation = Quaternion.Euler(0, 0, 270);
					path.transform.Find("BrickGround").localScale = new Vector3(12.5f, 1, 1);
					path.transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTextureScale = new Vector2(1, 150);
					path.transform.Find("Floor_Mask").gameObject.SetActive(true);
					path.transform.Find("Floor_Mask").localScale = new Vector3(1, 27.5f, 1f);
					path.transform.Find("Floor_Mask").position = new Vector3(80.8f, 10.01f, 0);
					path.transform.Find("Background").gameObject.GetComponent<MeshRenderer>().material.mainTexture = Tools.getImage("finalefloor.png");
					path.transform.Find("Background").gameObject.GetComponent<MeshRenderer>().material.color = new Color(0.9333f, 0.9569f, 0.7765f, 1f);
					path.transform.Find("Background").gameObject.GetComponent<MeshRenderer>().material.shaderKeywords = new string[0];
					path.transform.Find("Background").position = new Vector3(81f, 9.72f, 0);
					path.transform.Find("Background").localScale = new Vector3(500f, 500, 1);
					path.transform.Find("Background").gameObject.SetActive(true);
					path.transform.Find("Background").gameObject.GetComponent<MeshRenderer>().material.mainTextureScale = new Vector2(1, 150);
					path.name = "DungeonFloor";


					towerLight = GameObject.Instantiate(GameObject.Find("light"));
					towerLight.transform.parent = environment.transform;
					towerLight.transform.position = new Vector3(80, 20, -80);
					towerLight.GetComponent<Light>().intensity = 0.4f;
					towerLight.GetComponent<Light>().type = LightType.Directional;
					towerLight.transform.rotation = Quaternion.Euler(90, 0, 0);
					towerLight.GetComponent<Light>().range = 1000;
					towerLight2 = GameObject.Instantiate(towerLight);
					towerLight.GetComponent<Light>().shadows = LightShadows.Soft;
					towerLight2.transform.rotation = Quaternion.Euler(270, 0, 0);
					towerLight2.transform.parent = environment.transform;//X11 Y5
					try
					{
						GameObject.Find("hammerStuff").SetActive(false);
					}
					catch { }
					GameObject.Find("MagnificusAnim").transform.position = new Vector3(80.65f, 10f, -12f);
					GameObject.Find("MagnificusAnim").transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);


					Singleton<FirstPersonController>.Instance.GetComponentInChildren<Camera>().farClipPlane = 200;
					Singleton<FirstPersonController>.Instance.GetComponentInChildren<Camera>().backgroundColor = new Color(0.9333f, 0.9569f, 0.7765f, 1f);
					GameObject.Find("Player").transform.Find("Directional Light").gameObject.GetComponent<Light>().intensity = 1.15f;

					loading = true;
					break;
			}
			yield return generateMap(map, loading);
			yield break;
		}

		public static IEnumerator transition(string location, string transition)
		{
			Singleton<FirstPersonController>.Instance.enabled = false;
			yield return new WaitForSeconds(0.6f);
			if (minimap)
            {
				GameObject.Destroy(GameObject.Find("MapParent"));
            }
			for (int i = 0; i < 5000; i++)
            {
				try
                {
					GameObject.Destroy(GameObject.Find("New Game Object"));
                } catch { Debug.Log("oops"); }
            }
			yield return new WaitForSeconds(0.2f);
			minimap = false;

			switch (transition)
			{
				case "spin":
					for (int i = 0; i < 11; i++)
					{
						switch (Singleton<FirstPersonController>.Instance.LookDirection)
						{
							case LookDirection.North:
								Singleton<FirstPersonController>.Instance.LookAtDirection(LookDirection.East);
								break;
							case LookDirection.East:
								Singleton<FirstPersonController>.Instance.LookAtDirection(LookDirection.South);
								break;
							case LookDirection.South:
								Singleton<FirstPersonController>.Instance.LookAtDirection(LookDirection.West);
								break;
							case LookDirection.West:
								Singleton<FirstPersonController>.Instance.LookAtDirection(LookDirection.North);
								break;
						}
						float modify = 0.1f * i;
						GameObject.Find("Player").transform.position = new Vector3(GameObject.Find("Player").transform.position.x, 9.5f + modify, GameObject.Find("Player").transform.position.z);
						Singleton<UIManager>.Instance.Effects.GetEffect<ScreenColorEffect>().SetColor(GameColors.Instance.brightNearWhite);
						Singleton<UIManager>.Instance.Effects.GetEffect<ScreenColorEffect>().SetIntensity(modify, float.MaxValue);
						yield return new WaitForSeconds(0.385f - modify);
					}
					break;
				case "whiteout":
					for (int i = 0; i < 101; i++)
					{
						float modify = 0.03f * i;
						Singleton<UIManager>.Instance.Effects.GetEffect<ScreenColorEffect>().SetColor(GameColors.Instance.brightNearWhite);
						Singleton<UIManager>.Instance.Effects.GetEffect<ScreenColorEffect>().SetIntensity(modify, float.MaxValue);
						yield return new WaitForSeconds(0.01f);
					}
					break;
				case "none":
					yield return new WaitForSeconds(0.2f);
					break;
				case "unspin":
					for (int i = 0; i < 11; i++)
					{
						switch (Singleton<FirstPersonController>.Instance.LookDirection)
						{
							case LookDirection.North:
								Singleton<FirstPersonController>.Instance.LookAtDirection(LookDirection.East);
								break;
							case LookDirection.East:
								Singleton<FirstPersonController>.Instance.LookAtDirection(LookDirection.South);
								break;
							case LookDirection.South:
								Singleton<FirstPersonController>.Instance.LookAtDirection(LookDirection.West);
								break;
							case LookDirection.West:
								Singleton<FirstPersonController>.Instance.LookAtDirection(LookDirection.North);
								break;
						}
						float modify = 0.1f * i;
						GameObject.Find("Player").transform.position = new Vector3(GameObject.Find("Player").transform.position.x, 9.5f - modify, GameObject.Find("Player").transform.position.z);
						Singleton<UIManager>.Instance.Effects.GetEffect<ScreenColorEffect>().SetColor(GameColors.Instance.nearBlack);
						Singleton<UIManager>.Instance.Effects.GetEffect<ScreenColorEffect>().SetIntensity(modify, float.MaxValue);
						yield return new WaitForSeconds(0.385f - modify);
					}
					break;
			}
			GameObject.Destroy(GameObject.Find("GameEnvironment"));
			SavedVars.GeneratedEvents = "";
			if (location == "goobert") { RunState.Run.regionTier = 1; }
			if (location == "espeara") { RunState.Run.regionTier = 2; }
			if (location == "lonely") { RunState.Run.regionTier = 3; }
			if (location == "finale") { RunState.Run.regionTier = 4; }
			if (location == "tower") { RunState.Run.regionTier = 0; SavedVars.HasMap = false; SavedVars.HasMapIcons = false; }
			if (location == "depths") {
				Singleton<TextDisplayer>.Instance.Clear();

				if (SaveManager.saveFile.ascensionActive)
				{
					yield return new WaitForSeconds(1.5f);
					AscensionMenuScreens.ReturningFromSuccessfulRun = false;
					AscensionMenuScreens.ReturningFromFailedRun = true;
					KayceeStorage.IsMagRun = false;
					SaveManager.SaveToFile(false);
					SceneLoader.Load("Ascension_Configure");
					yield break;
				}

				if (RunState.Run.currentNodeId == 4 || RunState.Run.currentNodeId == 104)
				{
					GameObject.Find("DungeonFloor").SetActive(false);
					GameObject.Find("bgStarParent").SetActive(false);
					GameObject.Find("MarbleColumn_Player").SetActive(false);
					GameObject.Find("MarbleColumn_Opponent").SetActive(false);
				}
				RunState.Run.regionTier = 972; 
			}
			yield return new WaitForSeconds(0.2f);
			nodes.Clear();
			if (location != "tower")
			{
				yield return new WaitForSeconds(0.6f);
				yield return new WaitForSeconds(0.2f);
			}
			yield return getMap(location, false);
			if (location != "tower")
			{
				yield return new WaitForSeconds(1f);
			}
			List<GameObject> whoToKill = new List<GameObject>();
			foreach(GameObject node in nodes)
            {
				if (node == null)
                {
					whoToKill.Add(node);
                }
            }

			foreach(GameObject node in whoToKill)
            {
				nodes.Remove(node);
            }

			if (location == "goobert" || location == "espeara" || location == "lonely") { GameObject.Find("walls").transform.position = new Vector3(0, 0, 9); }

			string coords = "x4 y4";
			Vector3 spawn = new Vector3(80, 9.5f, -80);
			switch (location)
			{
				case "tower":
					//GameObject.Find("GameEnvironment").transform.position = new Vector3(0, -7, 0);
					setTableClothColor(new Color(0.5f, 0, 0.16f, 1));
					RunState.Run.regionTier = 0;
					coords = "x4 y7";
					spawn = new Vector3(80, 9.5f, -140f);
					if (MagSave.layout.Contains("5"))
					{
						coords = "x4 y3";
						spawn = new Vector3(80, 9.5f, -60f);
					}
					Singleton<FirstPersonController>.Instance.footstepSound = FirstPersonController.FootstepSound.Wood;
					makeLayer(2);
					yield return new WaitForSeconds(0.25f);
					GameObject.Find("walls layer 2").transform.localPosition = new Vector3(0, 50, 0);
					break;
				case "goobert":
					RunState.Run.regionTier = 1;
					setTableClothColor(new Color(0f, 0.4f, 0f, 1));
					coords = GameObject.Find("NavigationGrid").GetComponentInChildren<OcclusionArea>().gameObject.name;
					GameObject spawnObj = GameObject.Find("NavigationGrid").GetComponentInChildren<OcclusionArea>().gameObject;
					spawn = new Vector3(spawnObj.transform.position.x, 9.5f, spawnObj.transform.position.z);
					Singleton<FirstPersonController>.Instance.footstepSound = FirstPersonController.FootstepSound.Goo;
					break;
				case "espeara":
					RunState.Run.regionTier = 2;
					setTableClothColor(new Color(0.5f, 0.15f, 0, 1));
					coords = GameObject.Find("NavigationGrid").GetComponentInChildren<OcclusionArea>().gameObject.name;
					spawnObj = GameObject.Find("NavigationGrid").GetComponentInChildren<OcclusionArea>().gameObject;
					spawn = new Vector3(spawnObj.transform.position.x, 9.5f, spawnObj.transform.position.z);
					Singleton<FirstPersonController>.Instance.footstepSound = FirstPersonController.FootstepSound.Stone;
					break;
				case "lonely":
					RunState.Run.regionTier = 3;
					setTableClothColor(new Color(0, 0.715f, 0.55f, 1));
					coords = GameObject.Find("NavigationGrid").GetComponentInChildren<OcclusionArea>().gameObject.name;
					spawnObj = GameObject.Find("NavigationGrid").GetComponentInChildren<OcclusionArea>().gameObject;
					spawn = new Vector3(spawnObj.transform.position.x, 9.5f, spawnObj.transform.position.z);
					Singleton<FirstPersonController>.Instance.footstepSound = FirstPersonController.FootstepSound.Wood;
					break;
				case "finale":
					RunState.Run.regionTier = 4;
					setTableClothColor(new Color(0.5f, 0, 0.4f, 1));
					coords = GameObject.Find("NavigationGrid").GetComponentInChildren<OcclusionArea>().gameObject.name;
					spawnObj = GameObject.Find("NavigationGrid").GetComponentInChildren<OcclusionArea>().gameObject;
					spawn = new Vector3(spawnObj.transform.position.x, 9.5f, spawnObj.transform.position.z);
					Singleton<FirstPersonController>.Instance.footstepSound = FirstPersonController.FootstepSound.Stone;
					if (GameObject.Find("x4 y6").GetComponentInChildren<NavigationZone3D>().events.Count < 1)
					{
						GameObject icon2 = GameObject.Instantiate<GameObject>(GameObject.Find("nodeIconBase"));
						icon2.name = "nodeIcon";
						icon2.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = bleachTex;
						icon2.transform.position = new Vector3(GameObject.Find("x4 y6").transform.position.x, 13f, GameObject.Find("x4 y6").transform.position.z);
						Generation.nodes.Add(icon2);
						icon2.transform.position = new Vector3(GameObject.Find("x4 y6").transform.position.x, 13f, GameObject.Find("x4 y6").transform.position.z);
						GameObject.Find("x4 y6").GetComponentInChildren<NavigationZone3D>().events.Add(Generation.bleach);
						icon2.transform.parent = GameObject.Find("x4 y6").transform;
					}
					if (GameObject.Find("x4 y8").GetComponentInChildren<NavigationZone3D>().events.Count < 1)
					{
						bool hasEdaxio = false;
						foreach (CardInfo card in RunState.Run.playerDeck.Cards)
						{
							if (card.name == "mag_edaxioarms")
							{
								hasEdaxio = true;
							}
						}
						if (hasEdaxio)
						{
							GameObject icon2 = GameObject.Instantiate<GameObject>(GameObject.Find("nodeIconBase"));
							icon2.name = "nodeIcon";
							icon2.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = edaxioTex;
							icon2.transform.position = new Vector3(GameObject.Find("x4 y8").transform.position.x, 13f, GameObject.Find("x4 y8").transform.position.z);
							Generation.nodes.Add(icon2);
							icon2.transform.position = new Vector3(GameObject.Find("x4 y8").transform.position.x, 13f, GameObject.Find("x4 y8").transform.position.z);
							GameObject.Find("x4 y8").GetComponentInChildren<NavigationZone3D>().events.Add(Generation.edaxioNode);
							icon2.transform.parent = GameObject.Find("x4 y8").transform;
						}
						else
						{
							GameObject icon2 = GameObject.Instantiate<GameObject>(GameObject.Find("nodeIconBase"));
							icon2.name = "nodeIcon";
							icon2.transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = spellTex;
							icon2.transform.position = new Vector3(GameObject.Find("x4 y8").transform.position.x, 13f, GameObject.Find("x4 y8").transform.position.z);
							Generation.nodes.Add(icon2);
							icon2.transform.position = new Vector3(GameObject.Find("x4 y8").transform.position.x, 13f, GameObject.Find("x4 y8").transform.position.z);
							GameObject.Find("x4 y8").GetComponentInChildren<NavigationZone3D>().events.Add(Generation.spellSelect);
							icon2.transform.parent = GameObject.Find("x4 y8").transform;
						}
					}
					GameObject.Find("MagnificusAnim").transform.position = new Vector3(GameObject.Find("x4 y1").transform.position.x + 0.575f, 10f, GameObject.Find("x4 y1").transform.position.z + 20);
					if (GameObject.Find("x4 y1").GetComponentInChildren<NavigationZone3D>().events.Count < 1)
                    {
						GameObject.Find("x4 y1").GetComponentInChildren<NavigationZone3D>().events.Add(Generation.magBattle);
					}
					break;
				case "depths":
					RunState.Run.regionTier = 972;
					coords = "x4 y11";
					spawn = new Vector3(80f, 9.5f, -220f);
					Singleton<FirstPersonController>.Instance.footstepSound = FirstPersonController.FootstepSound.Grass;
					GameObject.Find("MagnificusAnim").transform.position = new Vector3(80.3f, 10f, -12f);
					break;
			}
			if (config.isometricActive && (location == "goobert" || location == "espeara" || location == "lonely"))
			{
				IsometricStuff.moveDisabled = true;
				GameObject figure = GameObject.Instantiate(Resources.Load("prefabs/map/CompositeFigurine") as GameObject);
				figure.transform.parent = GameObject.Find("GameEnvironment").transform;
				figure.name = "figure";
				figure.GetComponent<CompositeFigurine>().Generate(RunState.Run.playerAvatarHead, RunState.Run.playerAvatarArms, RunState.Run.playerAvatarBody);
				figure.transform.localScale = new Vector3(20, 20, 20);
				figure.transform.rotation = Quaternion.Euler(0, 0, 0);
				figure.transform.parent = Singleton<FirstPersonController>.Instance.gameObject.transform;
				figure.transform.localPosition = new Vector3(0, -10, 0);
				GameObject transitionIcon = GameObject.Instantiate<GameObject>(GameObject.Find("nodeIconBase"));
				transitionIcon.name = "transitionIcon";
				transitionIcon.transform.parent = GameObject.Find("PixelCameraParent").transform;
				transitionIcon.transform.localPosition = new Vector3(2, 13, 2);
				transitionIcon.transform.Find("Frame").Find("CanvasQuad").localPosition = new Vector3(-0.321f, 0f, -0.013f);
				transitionIcon.transform.localScale = new Vector3(0.13f, 0.13f, 0.13f);
				GameObject figureThruWalls = GameObject.Instantiate(GameObject.Find("ChallengeActivationUI"));
				figureThruWalls.transform.SetParent(GameObject.Find("PerspectiveUICamera").transform);
				GameObject.Destroy(figureThruWalls.GetComponentByName("DiskCardGame.ChallengeActivationUI"));
				figureThruWalls.name = "WallFigure";
				GameObject uiFigure = GameObject.Find("WallFigure").transform.Find("VisibleParent").gameObject;
				uiFigure.SetActive(true);
				uiFigure.transform.Find("Footer").gameObject.SetActive(false);
				uiFigure.transform.Find("Header").Find("IconSprite").Find("Back").gameObject.SetActive(false);
				uiFigure.transform.Find("Header").Find("IconSprite").Find("Activated").gameObject.SetActive(false);
				GameObject.Destroy(uiFigure.transform.Find("Header").Find("IconSprite").gameObject.GetComponentByName("DiskCardGame.AscensionIconBlinkEffect"));
				uiFigure.transform.Find("Header").Find("IconSprite").gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
				uiFigure.transform.Find("Header").Find("IconSprite").gameObject.GetComponent<SpriteRenderer>().sprite = Tools.getSprite("walloverlay.png");
				uiFigure.transform.Find("Header").Find("IconSprite").localScale = new Vector3(0.24f, 0.2f, 1);
				GameObject.Destroy(uiFigure.transform.Find("Header").gameObject.GetComponent<ViewportRelativePosition>());
				setUpClickToMove();
				uiFigure.transform.Find("Header").Find("IconSprite").localPosition = new Vector3(1.79f, -1.03f, 0);
				uiFigure.transform.Find("Header").localPosition = new Vector3(-3.5356f, 1.77f, 0);
				uiFigure.transform.position = new Vector3(0, 0, 0);
				GameObject.Find("Player").transform.localRotation = Quaternion.Euler(0, 0, 0);
				Singleton<FirstPersonController>.Instance.LookDirection = LookDirection.North;

				GameObject.Find("Pixel Camera").transform.localPosition = new Vector3(0, 3, -38.14f);
				GameObject.Find("Pixel Camera").transform.localRotation = Quaternion.Euler(3, 0, 0);
			}
			MagSave.SaveNode(coords);
			MagSave.clearedNode = new List<string>();
			SavedVars.LastBlueprint = 0;
			File.WriteAllText(SaveManager.SaveFolderPath + "MagnificusModSave.gwsave", SaveManager.ToJSON(MagSave.GetNodeStuff(false, false)));
			GameObject.Find("Player").transform.position = spawn;
			GameObject.Find("Player").transform.Find("PixelCameraParent").transform.localPosition = new Vector3(0, 7, -6.86f);
			switch (transition)
			{
				case "spin":
					if (location != "tower")
					{
						for (int i = 0; i < 11; i++)
						{
							float modify = 0.1f * i;
							if (!(config.isometricActive && (location == "goobert" || location == "espeara" || location == "lonely")))
							{
								switch (Singleton<FirstPersonController>.Instance.LookDirection)
								{
									case LookDirection.North:
										Singleton<FirstPersonController>.Instance.LookAtDirection(LookDirection.West);
										break;
									case LookDirection.West:
										Singleton<FirstPersonController>.Instance.LookAtDirection(LookDirection.South);
										break;
									case LookDirection.South:
										Singleton<FirstPersonController>.Instance.LookAtDirection(LookDirection.East);
										break;
									case LookDirection.East:
										Singleton<FirstPersonController>.Instance.LookAtDirection(LookDirection.North);
										break;
								}
								GameObject.Find("Player").transform.position = new Vector3(GameObject.Find("Player").transform.position.x, 10.5f - modify, GameObject.Find("Player").transform.position.z);
							}
							else
							{
								Tween.LocalPosition(GameObject.Find("Player").transform.Find("figure"), new Vector3(0, 0 - (modify * 10), 0), 0.085f + modify / 3, 0);
								Tween.Rotation(GameObject.Find("Player").transform.Find("figure"), Quaternion.Euler(0, GameObject.Find("Player").transform.Find("figure").transform.rotation.eulerAngles.y + 90, 0), 0.05f, 0); 
							}
							Singleton<UIManager>.Instance.Effects.GetEffect<ScreenColorEffect>().SetColor(GameColors.Instance.brightNearWhite);
							Singleton<UIManager>.Instance.Effects.GetEffect<ScreenColorEffect>().SetIntensity(1 - modify, float.MaxValue);
							yield return new WaitForSeconds(0.085f + modify / 3);
						}
					}
					break;
				case "whiteout":
					for (int i = 0; i < 101; i++)
					{
						float modify = 0.01f * i;
						Singleton<UIManager>.Instance.Effects.GetEffect<ScreenColorEffect>().SetColor(GameColors.Instance.brightNearWhite);
						Singleton<UIManager>.Instance.Effects.GetEffect<ScreenColorEffect>().SetIntensity(1 - modify, float.MaxValue);
						yield return new WaitForSeconds(0.01f);
					}
					break;
				case "none":
					yield return new WaitForSeconds(0.2f);
					break;
				case "unspin":
					for (int i = 0; i < 11; i++)
					{
						switch (Singleton<FirstPersonController>.Instance.LookDirection)
						{
							case LookDirection.North:
								Singleton<FirstPersonController>.Instance.LookAtDirection(LookDirection.West);
								break;
							case LookDirection.West:
								Singleton<FirstPersonController>.Instance.LookAtDirection(LookDirection.South);
								break;
							case LookDirection.South:
								Singleton<FirstPersonController>.Instance.LookAtDirection(LookDirection.East);
								break;
							case LookDirection.East:
								Singleton<FirstPersonController>.Instance.LookAtDirection(LookDirection.North);
								break;
						}
						float modify = 0.1f * i;
						GameObject.Find("Player").transform.position = new Vector3(GameObject.Find("Player").transform.position.x, 16.5f - modify, GameObject.Find("Player").transform.position.z);
						Singleton<UIManager>.Instance.Effects.GetEffect<ScreenColorEffect>().SetColor(GameColors.Instance.nearBlack);
						if (!SaveManager.saveFile.ascensionActive)
						{
							Singleton<UIManager>.Instance.Effects.GetEffect<ScreenColorEffect>().SetIntensity(1 - modify, float.MaxValue);
						}
						yield return new WaitForSeconds(0.085f + modify / 3);
					}
					break;
			}
			Singleton<FirstPersonController>.Instance.currentZone = GameObject.Find(coords).GetComponent<NavigationZone3D>();
			yield return new WaitForSeconds(0.2f);
			SaveManager.SaveToFile();
			string text = File.ReadAllText(SaveManager.SaveFolderPath + "MagnificusModSave.gwsave");
			string[] array = text.Split(new char[]
			{
					'x'
			}, 2);
			string text2 = "x" + array[1];
			string[] array2 = text2.Split(new char[]
			{
					'C'
			});
			string[] cleared = array2[1].Split(new char[]
			{
					','
			});
			yield return new WaitForSeconds(0.2f);
			string levelTitle = "~ ~";

			if (config.isometricActive && (location == "goobert" || location == "espeara" || location == "lonely"))
			{
				IsometricStuff.moveDisabled = false;
				GameObject.Find("Player").transform.Find("clickToMove").localRotation = Quaternion.Euler(0, 0, 0);
				if (config.gridActive) { GameObject.Find("Player").transform.Find("clickGrid").localRotation = Quaternion.Euler(0, 0, 0); }
			}
			if (location == "goobert")
			{
				levelTitle = "~ Goo Dungeon ~";
				if (!config.isometricActive)
				{ Tween.LocalRotation(GameObject.Find("bgStarParent").transform, Quaternion.Euler(0, 0, 0), 0.5f, 0); } 
				else
				{ 
					Tween.LocalRotation(GameObject.Find("bgStarParent").transform, Quaternion.Euler(0, 45, 0), 0.5f, 0);
					Tween.LocalPosition(GameObject.Find("bgStarParent").transform, new Vector3(0, 0, -100), 0.5f, 0);
				}

				if (!SavedVars.LearnedMechanics.Contains("goodungeonintro;"))
				{
					Singleton<FirstPersonController>.Instance.enabled = false;
					SavedVars.LearnedMechanics += "goodungeonintro;";
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("You land in a sticky puddle of goo, stretching out into what seems like an endless void..", -0.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Ruined pillars and ancient walls surround your vision, overtaken by yet more slime..", -0.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("The glistening heavens above shine brightly unto you.", -0.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("You arrive in the..", -0.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
					yield return new WaitForSeconds(0.15f);
					Singleton<FirstPersonController>.Instance.enabled = true;
				}

			} else if (location == "espeara")
			{
				levelTitle = "~ Lava Dungeon ~";

				if (!SavedVars.LearnedMechanics.Contains("lavadungeonintro"))
				{
					Singleton<FirstPersonController>.Instance.enabled = false;
					SavedVars.LearnedMechanics += "lavadungeonintro;";
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("A sudden influx of heat surrounds you..", -0.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Dimly lit and dingy chambers spread out as far as you can see.", -0.25f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Long forgotten echoes of ancient sparring fill the room.", -0.15f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("You find yourself in the..", -0.25f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
					yield return new WaitForSeconds(0.15f);
					Singleton<FirstPersonController>.Instance.enabled = true;
				}
			}
			else if (location == "lonely")
			{
				levelTitle = "~ Void Dungeon ~";
				GameObject.Find("bgStarParent").transform.localPosition = new Vector3(0, 500, 125);
				if (!config.isometricActive) { 
					Tween.LocalRotation(GameObject.Find("bgStarParent").transform, Quaternion.Euler(0, 0, 0), 0.5f, 0);
					Tween.LocalPosition(GameObject.Find("bgStarParent").transform, new Vector3(0, 0, 125), 0.5f, 0);
					Tween.LocalPosition(GameObject.Find("starFade").transform, new Vector3(0, 0, 0), 0.5f, 0);
				} else
                {
					Tween.LocalRotation(GameObject.Find("bgStarParent").transform, Quaternion.Euler(0, 45, 0), 0.5f, 0);
					Tween.LocalPosition(GameObject.Find("bgStarParent").transform, new Vector3(50, 0, 50), 0.5f, 0);
					Tween.LocalPosition(GameObject.Find("starFade").transform, new Vector3(0, 0, 0), 0.5f, 0);
				}

				if (!SavedVars.LearnedMechanics.Contains("voiddungeonintro"))
				{
					Singleton<FirstPersonController>.Instance.enabled = false;
					SavedVars.LearnedMechanics += "voiddungeonintro;";
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("A dusty old smell fills your nostrills..", -0.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Hundreds of walls containing books, laying untouched for eons, fill the quiet landscape.", -0.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Ethereal runes, containing lost, forbidden knowledge surround you.", -0.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
					yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("You awake in the..", -0.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
					yield return new WaitForSeconds(0.15f);
					Singleton<FirstPersonController>.Instance.enabled = true;
				}

			}
			else if (location == "finale")
			{
				levelTitle = "~ ??? ~";

				if (SaveManager.saveFile.ascensionActive) {
					int cards = 0;
					foreach (CardInfo card in RunState.Run.playerDeck.Cards)
                    {
						if (!card.HasTrait(Trait.EatsWarrens)) { cards++; }
                    }
					if (cards <= 10) { AchievementManager.Unlock(Achievements.CardofSacrifice); }
				}
			}
			else if (location == "tower")
			{
				SceneLoader.Load(SceneLoader.ActiveSceneName);
			} else if (location == "depths")
			{
				levelTitle = SaveManager.saveFile.ascensionActive ? "~ ~" : "~ ??? ~";

				if (!SaveManager.saveFile.ascensionActive)
				{
					WaitThenEnablePlayer(0f);
					GameObject.Find("x4 y1").GetComponentInChildren<NavigationZone3D>().events.Add(Generation.gameOver);
					GameObject.Find("MagnificusAnim").transform.position = new Vector3(80.3f, 9.72f, -12);
					Singleton<FirstPersonController>.Instance.LookAtDirection(LookDirection.North, false);
					Singleton<ViewManager>.Instance.SwitchToView(View.FirstPerson, false);
				} else
                {
					SceneLoader.Load("Ascension_Configure");
				}
			}

			if (config.isometricMode && !SavedVars.LearnedMechanics.Contains("isometricTutorial") && RunState.Run.regionTier < 4)
			{
				GameObject.Find("ControlsHint_Left").GetComponent<AnimatingSprite>().frames = new List<Sprite> { Plugin.ControlsHintFrames[2], Plugin.ControlsHintFrames[3] };
				Singleton<UIManager>.Instance.SetControlsHintShown(shown: true, false);
				Singleton<UIManager>.Instance.leftHintShown = true;
				GameObject.Find("ControlsHint_Right").GetComponent<AnimatingSprite>().frames = new List<Sprite> { Tools.convertToSprite(Resources.Load("art/ui/controlshint_wasd") as Texture2D), Tools.convertToSprite(Resources.Load("art/ui/controlshint_wasd") as Texture2D) };
				Singleton<UIManager>.Instance.SetControlsHintShown(shown: true);
			}

			Singleton<FirstPersonController>.Instance.enabled = true;

			if (config.isometricActive)
			{
				GameObject.Find("Pixel Camera").transform.localPosition = Vector3.zero;
				GameObject.Find("Pixel Camera").transform.localRotation = Quaternion.Euler(Vector3.zero);
			}

			if (levelTitle != "~ ~") yield return fadeText(levelTitle);
			else yield return new WaitForSeconds(2.5f);

			if (GameObject.Find("GameTable").transform.position.y <= 0 && !config.isometricMode)
			{
				GameObject.Find("Player").transform.Find("PixelCameraParent").transform.localPosition = new Vector3(0, 7, -6.86f);
			}
			if (location != "finale" && location != "tower" && location != "depths")
            {
				minimap = true;
				CreateMiniMap(false, true);
				SaveManager.SaveToFile();
            }
			yield break;
		}

		public static IEnumerator warp(string location, string transition)
		{
			Singleton<FirstPersonController>.Instance.enabled = false;
			if (transition != "spin")
			{
				yield return new WaitForSeconds(0.6f);
			} else
            {
				yield return new WaitForSeconds(0.2f);
				if (config.isometricMode) { 
					GameObject.Find("WallFigure").transform.Find("VisibleParent").Find("Header").Find("IconSprite").gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
					Tween.LocalPosition(GameObject.Find("reflection").transform, new Vector3(GameObject.Find("reflection").transform.localPosition.x, 2.5f + UnityEngine.Random.Range(-0.50f, 0.50f), GameObject.Find("reflection").transform.localPosition.z), 0.1f, 0);
					Tween.LocalPosition(GameObject.Find("reflection").transform, new Vector3(GameObject.Find("reflection").transform.localPosition.x, -1.5f, GameObject.Find("reflection").transform.localPosition.z), 0.1f, 0.1f);
				}
			}
			switch (transition)
			{
				case "spin":
					Singleton<FirstPersonController>.Instance.LookAtDirection(LookDirection.North);
					RunState.Run.playerAvatarHead = (CompositeFigurine.FigurineType)Random.RandomRangeInt(0, 8);
					RunState.Run.playerAvatarArms = (CompositeFigurine.FigurineType)Random.RandomRangeInt(0, 8);
					RunState.Run.playerAvatarBody = (CompositeFigurine.FigurineType)Random.RandomRangeInt(0, 8);
					for (int i = 0; i < 2; i++)
					{
						switch (Singleton<FirstPersonController>.Instance.LookDirection)
						{
							case LookDirection.North:
								Singleton<FirstPersonController>.Instance.LookAtDirection(LookDirection.East);
								break;
							case LookDirection.East:
								Singleton<FirstPersonController>.Instance.LookAtDirection(LookDirection.South);
								break;
							case LookDirection.South:
								Singleton<FirstPersonController>.Instance.LookAtDirection(LookDirection.West);
								break;
							case LookDirection.West:
								Singleton<FirstPersonController>.Instance.LookAtDirection(LookDirection.North);
								break;
						}
						GameObject.Find("Player").transform.position = new Vector3(GameObject.Find("Player").transform.position.x - 10, 9.5f, GameObject.Find("Player").transform.position.z);
						GameObject.Find("reflection").GetComponent<CompositeFigurine>().Generate(RunState.Run.playerAvatarHead, RunState.Run.playerAvatarArms, RunState.Run.playerAvatarBody);
						if (config.isometricMode && i == 1) { 
							GameObject.Find("Player").transform.Find("figure").GetComponent<CompositeFigurine>().Generate(RunState.Run.playerAvatarHead, RunState.Run.playerAvatarArms, RunState.Run.playerAvatarBody);
							Tween.Position(GameObject.Find("Player").transform, new Vector3(GameObject.Find(location).transform.position.x, 9.5f, GameObject.Find(location).transform.position.z), 0.2f, 0f);
							Tween.LocalRotation(GameObject.Find("Player").transform.Find("figure").transform, Quaternion.Euler(0, 270, 0), 0.2f, 0);
							Tween.LocalRotation(GameObject.Find("reflection").transform, Quaternion.Euler(0, 90, 0), 0.2f, 0);
							yield return new WaitForSeconds(0.2f);
						}
					}
					break;
				case "whiteout":
					for (int i = 0; i < 101; i++)
					{
						float modify = 0.03f * i;
						Singleton<UIManager>.Instance.Effects.GetEffect<ScreenColorEffect>().SetColor(GameColors.Instance.brightNearWhite);
						Singleton<UIManager>.Instance.Effects.GetEffect<ScreenColorEffect>().SetIntensity(modify, float.MaxValue);
						if (i == 50)
						{
							GameObject.Find("walls").transform.position = new Vector3(0, 0, 9);
							AudioController.Instance.SetLoopAndPlay("School_of_Magicks", 0, true, true);
							AudioController.Instance.SetLoopVolumeImmediate(0.55f);
							GameObject.Find("GameTable").transform.Find("tbPillar").Find("tableCloth").gameObject.SetActive(true);
							GameObject.Find("GameTable").transform.Find("tbPillar").Find("Anim").gameObject.SetActive(true);
							if (RunState.Run.regionTier == 1)
							{
								GameObject.Find("PixelCameraParent").transform.Find("Pixel Camera").gameObject.GetComponent<Camera>().backgroundColor = new Color(0, 0, 0, 1f);
								GameObject.Find("PixelCameraParent").transform.Find("Pixel Camera").gameObject.GetComponent<Camera>().farClipPlane = 320 - getClippingPlaneQualityAdjustment();
								GameObject.Find("DungeonFloor").transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.color = new Color(0.5f, 1f, 0.5f);
								GameObject.Find("DungeonFloor").transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTexture = (Resources.Load("art/generictexture3d/goo/Goo_Color") as Texture2D);
								GameObject.Find("Player").transform.Find("Directional Light").gameObject.SetActive(true);
								Singleton<FirstPersonController>.Instance.footstepSound = FirstPersonController.FootstepSound.Goo;
								GameObject.Find("Player").transform.Find("bgStarParent").gameObject.SetActive(true);
								GameObject.Find("GameTable").transform.Find("light").gameObject.SetActive(true);
							}
							else if (RunState.Run.regionTier == 2)
                            {
								GameObject.Find("PixelCameraParent").transform.Find("Pixel Camera").gameObject.GetComponent<Camera>().backgroundColor = new Color(0.07843138f, 0.1023529f, 0.2180392f, 1f);
								GameObject.Find("PixelCameraParent").transform.Find("Pixel Camera").gameObject.GetComponent<Camera>().farClipPlane = 325f - getClippingPlaneQualityAdjustment();
								GameObject.Find("PixelCameraParent").transform.Find("Pixel Camera").gameObject.GetComponent<Camera>().backgroundColor = new Color(0.0784f, 0.1024f, 0.058f, 1);
								GameObject.Find("DungeonFloor").transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTexture = (Resources.Load("art/generictexture3d/roughrock/Rough_rock_003_COLOR") as Texture2D);
								GameObject.Find("DungeonFloor").transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.color = new Color(0.25f, 0.25f, 0.25f);
								GameObject.Find("Player").transform.Find("Directional Light").gameObject.SetActive(true);
								GameObject.Find("lanterns").transform.position = new Vector3(0, 0, 0);
								Singleton<FirstPersonController>.Instance.footstepSound = FirstPersonController.FootstepSound.Stone;
								GameObject.Find("GameTable").transform.Find("light").gameObject.SetActive(true);
							}
							else if (RunState.Run.regionTier == 3)
							{
								Singleton<FirstPersonController>.Instance.GetComponentInChildren<Camera>().farClipPlane = 175 - (getClippingPlaneQualityAdjustment() / 2);
								Singleton<FirstPersonController>.Instance.GetComponentInChildren<Camera>().backgroundColor = new Color(0f, 0f, 0f, 1f);
								GameObject.Find("DungeonFloor").transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.color = new Color(0.6f, 0.6f, 0.8f);
								GameObject.Find("DungeonFloor").transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTexture = (Resources.Load("art/assets3d/cabin/floor/woodenFloor_albedo") as Texture2D);
								GameObject.Find("Player").transform.Find("Directional Light").gameObject.SetActive(true);
								Singleton<FirstPersonController>.Instance.footstepSound = FirstPersonController.FootstepSound.Wood;
								GameObject.Find("GameTable").transform.Find("light").gameObject.SetActive(true);
							}
						}
						yield return new WaitForSeconds(0.01f);
					}
					break;
				case "blackout":
					for (int i = 0; i < 101; i++)
					{
						float modify = 0.03f * i;
						Singleton<UIManager>.Instance.Effects.GetEffect<ScreenColorEffect>().SetColor(GameColors.Instance.nearBlack);
						Singleton<UIManager>.Instance.Effects.GetEffect<ScreenColorEffect>().SetIntensity(modify, float.MaxValue);
						float posModify = config.isometricMode ? modify * 10 : modify;
						GameObject.Find("Player").transform.position = new Vector3(GameObject.Find("Player").transform.position.x, 9.5f - posModify, GameObject.Find("Player").transform.position.z);
						if (i == 50)
                        {
							GameObject.Find("walls").transform.position = new Vector3(0, -90, 9);
							AudioController.Instance.FadeOutLoop(0.75f, Array.Empty<int>());
							GameObject.Find("PixelCameraParent").transform.Find("Pixel Camera").gameObject.GetComponent<Camera>().backgroundColor = new Color(0, 0, 0, 1);
							GameObject.Find("PixelCameraParent").transform.Find("Pixel Camera").gameObject.GetComponent<Camera>().farClipPlane = 140;
							GameObject.Find("DungeonFloor").transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0.25f);
							GameObject.Find("DungeonFloor").transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.mainTexture = (Tools.getImage("sandtexture.png"));
							GameObject.Find("GameTable").transform.Find("tbPillar").Find("tableCloth").gameObject.SetActive(false);
							GameObject.Find("GameTable").transform.Find("tbPillar").Find("Anim").gameObject.SetActive(false);
							Singleton<FirstPersonController>.Instance.footstepSound = FirstPersonController.FootstepSound.Grass;
							if (RunState.Run.regionTier == 1)
                            {
								GameObject.Find("Player").transform.Find("bgStarParent").gameObject.SetActive(false);
								GameObject.Find("DungeonFloor").transform.Find("BrickGround").gameObject.GetComponent<MeshRenderer>().material.shaderKeywords = new string[0];
							} else if (RunState.Run.regionTier == 2)
                            {
								GameObject.Find("lanterns").transform.position = new Vector3(0, 100, 0);
							}
						}
						yield return new WaitForSeconds(0.01f);
					}
					break;
				case "unspin":
					for (int i = 0; i < 11; i++)
					{
						if (!config.isometricMode)
						{
							switch (Singleton<FirstPersonController>.Instance.LookDirection)
							{
								case LookDirection.North:
									Singleton<FirstPersonController>.Instance.LookAtDirection(LookDirection.East);
									break;
								case LookDirection.East:
									Singleton<FirstPersonController>.Instance.LookAtDirection(LookDirection.South);
									break;
								case LookDirection.South:
									Singleton<FirstPersonController>.Instance.LookAtDirection(LookDirection.West);
									break;
								case LookDirection.West:
									Singleton<FirstPersonController>.Instance.LookAtDirection(LookDirection.North);
									break;
							}
						}
						float modify = 0.1f * i;
						GameObject.Find("Player").transform.position = new Vector3(GameObject.Find("Player").transform.position.x, 9.5f - modify, GameObject.Find("Player").transform.position.z);
						Singleton<UIManager>.Instance.Effects.GetEffect<ScreenColorEffect>().SetColor(GameColors.Instance.nearBlack);
						Singleton<UIManager>.Instance.Effects.GetEffect<ScreenColorEffect>().SetIntensity(modify, float.MaxValue);
						yield return new WaitForSeconds(0.385f - modify);
					}
					break;
			}
			Singleton<FirstPersonController>.Instance.currentZone = GameObject.Find(location).GetComponent<NavigationZone3D>();
			GameObject.Find("Player").transform.position = new Vector3(GameObject.Find(location).transform.position.x, 9.5f, GameObject.Find(location).transform.position.z);
			switch (transition)
			{
				case "spin":
					SaveManager.SaveToFile();
					/*
					for (int i = 0; i < 11; i++)
					{
						switch (Singleton<FirstPersonController>.Instance.LookDirection)
						{
							case LookDirection.North:
								Singleton<FirstPersonController>.Instance.LookAtDirection(LookDirection.West);
								break;
							case LookDirection.West:
								Singleton<FirstPersonController>.Instance.LookAtDirection(LookDirection.South);
								break;
							case LookDirection.South:
								Singleton<FirstPersonController>.Instance.LookAtDirection(LookDirection.East);
								break;
							case LookDirection.East:
								Singleton<FirstPersonController>.Instance.LookAtDirection(LookDirection.North);
								break;
						}
						float modify = 0.1f * i;
						GameObject.Find("Player").transform.position = new Vector3(GameObject.Find("Player").transform.position.x, 10.5f - modify, GameObject.Find("Player").transform.position.z);
						Singleton<UIManager>.Instance.Effects.GetEffect<ScreenColorEffect>().SetColor(GameColors.Instance.brightNearWhite);
						Singleton<UIManager>.Instance.Effects.GetEffect<ScreenColorEffect>().SetIntensity(1 - modify, float.MaxValue);
						yield return new WaitForSeconds(0.085f + modify / 3);
						Singleton<FirstPersonController>.Instance.enabled = true;
					*/
					break;
				case "whiteout":
					for (int i = 0; i < 101; i++)
					{
						float modify = 0.01f * i;
						Singleton<UIManager>.Instance.Effects.GetEffect<ScreenColorEffect>().SetColor(GameColors.Instance.brightNearWhite);
						Singleton<UIManager>.Instance.Effects.GetEffect<ScreenColorEffect>().SetIntensity(1 - modify, float.MaxValue);
						yield return new WaitForSeconds(0.01f);
					}
					break;
				case "blackout":
					if (config.isometricMode) { GameObject.Find("WallFigure").transform.Find("VisibleParent").Find("Header").Find("IconSprite").gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f); }
					for (int i = 0; i < 101; i++)
					{
						float modify = 0.01f * i;
						Singleton<UIManager>.Instance.Effects.GetEffect<ScreenColorEffect>().SetColor(GameColors.Instance.nearBlack);
						Singleton<UIManager>.Instance.Effects.GetEffect<ScreenColorEffect>().SetIntensity(1 - modify, float.MaxValue);
						GameObject.Find("Player").transform.position = new Vector3(GameObject.Find("Player").transform.position.x, 10.5f - modify, GameObject.Find("Player").transform.position.z);
						yield return new WaitForSeconds(0.01f);
					}
					break;
				case "unspin":
					for (int i = 0; i < 11; i++)
					{
						if (!config.isometricMode)
						{
							switch (Singleton<FirstPersonController>.Instance.LookDirection)
							{
								case LookDirection.North:
									Singleton<FirstPersonController>.Instance.LookAtDirection(LookDirection.West);
									break;
								case LookDirection.West:
									Singleton<FirstPersonController>.Instance.LookAtDirection(LookDirection.South);
									break;
								case LookDirection.South:
									Singleton<FirstPersonController>.Instance.LookAtDirection(LookDirection.East);
									break;
								case LookDirection.East:
									Singleton<FirstPersonController>.Instance.LookAtDirection(LookDirection.North);
									break;
							}
						}
						float modify = 0.1f * i;
						GameObject.Find("Player").transform.position = new Vector3(GameObject.Find("Player").transform.position.x, 10.5f - modify, GameObject.Find("Player").transform.position.z);
						Singleton<UIManager>.Instance.Effects.GetEffect<ScreenColorEffect>().SetColor(GameColors.Instance.nearBlack);
						Singleton<UIManager>.Instance.Effects.GetEffect<ScreenColorEffect>().SetIntensity(1 - modify, float.MaxValue);
						yield return new WaitForSeconds(0.085f + modify / 3);
						Singleton<FirstPersonController>.Instance.enabled = true;
					}
					break;
			}
			yield return new WaitForSeconds(0.2f);
			GameObject.Find("Player").transform.position = new Vector3(GameObject.Find(location).transform.position.x, 9.5f, GameObject.Find(location).transform.position.z);
			Singleton<FirstPersonController>.Instance.enabled = false;
			if (!config.isometricMode)
			{
				if (transition != "spin")
				{
					Singleton<FirstPersonController>.Instance.LookAtDirection(LookDirection.East);
				}
				else
				{
					Singleton<FirstPersonController>.Instance.LookAtDirection(LookDirection.West);
				}
			}
			Singleton<FirstPersonController>.Instance.enabled = true;
			yield break;
		}

		public static IEnumerator reflectionRotate(GameObject reflection)
		{
			yield return new WaitForSeconds(0.15f);
			if (GameObject.Find("Player").transform.Find("figure").transform.rotation.eulerAngles.y == 270 || GameObject.Find("Player").transform.Find("figure").transform.rotation.eulerAngles.y == 90)
			{
				Tween.Rotation(reflection.transform, new Vector3(0, GameObject.Find("Player").transform.Find("figure").transform.rotation.eulerAngles.y + 180, 0), 0.15f, 0);
			} else
            {
				Tween.Rotation(reflection.transform, new Vector3(0, GameObject.Find("Player").transform.Find("figure").transform.rotation.eulerAngles.y, 0), 0.15f, 0);
			}
			yield break;
		}


		public static IEnumerator startHammer()
		{
			yield return new WaitForSeconds(2f);
			if (!SavedVars.LearnedMechanics.Contains("liferace;") && !SaveManager.saveFile.ascensionActive)
            {yield return new WaitForSeconds(3f);}
			GameObject.Find("WizardBattleDuelDisk").transform.Find("hammerStuff").gameObject.SetActive(true);
			GameObject.Find("hammerStuff").GetComponent<SineWaveMovement>().originalPosition = new Vector3(3.74f, 0.5f, 5.1599f);
			GameObject.Find("hammerStuff").GetComponent<SineWaveMovement>().speed = 2;
			GameObject.Find("hammerStuff").GetComponent<SineWaveMovement>().yMagnitude = 0.15f;
			GameObject.Find("hammerStuff").GetComponent<SineWaveMovement>().enabled = true;
			GameObject.Find("hammerStuff").GetComponent<SineWaveMovement>().Start();
			for (int i = 0; i < GameObject.Find("hammerStuff").transform.childCount; i++)
			{
				if (GameObject.Find("hammerStuff").transform.GetChild(i).name == "ConsumableSlot")
                {
					GameObject.Find("hammerStuff").transform.GetChild(i).gameObject.SetActive(false);

				}

			}
			yield break;
		}

		public static void setTableClothColor(Color color)
        {
			GameObject tableclothObj = GameObject.Find("tableCloth");

			tableclothObj.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material.color = color;
			tableclothObj.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().materials[1].color = color;
		}


		//OTHER PATCHES




		public static IEnumerator SpinThisMan(GameObject who, float rotation)
		{
			float startRot = rotation;
			float startY = who.transform.position.y;
			for (int i = 0; i < 21; i++)
			{
				rotation += 90;
				if (rotation >= 360)
				{
					rotation = 0;
				}
				Tween.LocalRotation(who.transform, Quaternion.Euler(0, rotation, 0), 0.2f, 0f);
				float modify = 0.1f * i;
				who.transform.position = new Vector3(who.transform.position.x, startY + modify, who.transform.position.z);
				yield return new WaitForSeconds(0.285f - modify);
			}
			Tween.LocalRotation(who.transform, Quaternion.Euler(0, startRot, 0), 0.2f, 0f);
			Tween.Position(who.transform, new Vector3(who.transform.position.x, 50, who.transform.position.z), 0.5f, 0.25f);
			Tween.Position(who.transform, new Vector3(0, -20, 0), 0.01f, 0.95f);
		}

		public static IEnumerator leshyCardGetSequence()
        {
			Singleton<FirstPersonController>.Instance.enabled = false;
			yield return new WaitForSeconds(0.75f);
			if (Singleton<ViewManager>.Instance.CurrentView == View.Candles)
            {
				yield break;
            }
			Singleton<FirstPersonController>.Instance.enabled = false;
			SavedVars.LearnedMechanics += "druid;";
			GameObject gameObject = GameObject.Instantiate<GameObject>(Singleton<SelectableCardArray>.Instance.selectableCardPrefab);
			gameObject.transform.SetParent(GameObject.Find("GameTable").transform);
			SelectableCard component = gameObject.GetComponent<SelectableCard>();
			component.SetInfo(CardLoader.GetCardByName("mag_druid"));
			//component.Initialize(component.Info, new Action<SelectableCard>(Singleton<SelectableCardArray>.Instance.OnCardSelected), null, false, new Action<SelectableCard>(Singleton<SelectableCardArray>.Instance.OnCardInspected));
			component.SetEnabled(false);
			Singleton<SelectableCardArray>.Instance.displayedCards.Add(component);
			Singleton<SelectableCardArray>.Instance.TweenInCard(component.transform, new Vector3(0, 56.5f, 2.5f), 0, false);
			component.gameObject.transform.rotation = Quaternion.Euler(8.5f, 180, 0);
			component.Anim.PlayQuickRiffleSound();
			component.SetCardback(Tools.getImage("magcardback.png"));
			//component.Initialize(component.Info, new Action<SelectableCard>(this.pickUpEdaxio), null, false, null);
			yield return new WaitForSeconds(Time.deltaTime);
			component.GetComponent<Collider>().enabled = true;
			yield return new WaitForSeconds(Time.deltaTime * 0f);
			yield return new WaitForSeconds(Time.deltaTime);
			Singleton<FirstPersonController>.Instance.enabled = false;
			Tween.LocalPosition(component.gameObject.transform, new Vector3(0, 36.5f, 2.5f), 0.75f, 0);
			yield return new WaitForSeconds(0.8f);
			Singleton<FirstPersonController>.Instance.enabled = false;
			component.gameObject.AddComponent<SineWaveMovement>();
			component.gameObject.GetComponent<SineWaveMovement>().originalPosition = new Vector3(0, 35.5f, 2.5f);
			component.gameObject.GetComponent<SineWaveMovement>().speed = 0.7f;
			component.gameObject.GetComponent<SineWaveMovement>().yMagnitude = 0.5f;
			yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Look at what you've unleashed..", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
			yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Was it truly worth finding?", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
			RunState.Run.playerDeck.AddCard(component.Info);
			SaveManager.SaveToFile();
			Singleton<FirstPersonController>.Instance.enabled = true;
			yield return new WaitForSeconds(0.25f);
			component.gameObject.GetComponent<SineWaveMovement>().enabled = false;
			component.ExitBoard(0.75f, Vector3.zero);
			yield return new WaitForSeconds(0.8f);
			GameObject.Find("GameEnvironment").transform.Find("towerWall3(Clone)").gameObject.SetActive(true);
			GameObject.Find("GameTable").transform.position = new Vector3(0, -50, 0);
			yield break;
        }

		public static IEnumerator getMonocleSequence()
		{
			if (!SavedVars.LearnedMechanics.Contains("monoclemove;"))
			{
				SavedVars.LearnedMechanics += "monoclemove;";
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Looking for something?", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("I'm afraid the object you seek has been.. [c:g1]relocated[c:]..", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
				SaveManager.SaveToFile();
			}
			yield break;
		}

		public static IEnumerator dummyWinSequence()
		{
			Singleton<FirstPersonController>.Instance.enabled = false;
			yield return new WaitForSeconds(1f);
			Singleton<FirstPersonController>.Instance.enabled = false;
			if (Singleton<ViewManager>.Instance.CurrentView == View.Candles) { yield break; }
			Singleton<ViewManager>.Instance.SwitchToView(View.Default, false, true);
			Singleton<FirstPersonController>.Instance.enabled = false;
			yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("The dummy's hinges creak back into position, and it returns to it's lifeless stare.", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
			Singleton<FirstPersonController>.Instance.enabled = false;
			Tween.Position(GameObject.Find("Monocle").transform, new Vector3(81f, 16.65f, -45.8f), 0.5f, 0);
			yield return new WaitForSeconds(0.4f);
			GameObject.Find("ScreenEffects").transform.Find("WizardEyeEffect").gameObject.SetActive(true);
			Singleton<UIManager>.Instance.Effects.GetEffect<WizardEyeEffect>().SetIntensity(1f, 0f);
			RunState.Run.eyeState = EyeballState.Wizard;
			yield return new WaitForSeconds(0.2f);
			GameObject.Destroy(GameObject.Find("Monocle"));
			Singleton<FirstPersonController>.Instance.enabled = true;
			SaveManager.SaveToFile();
			yield break;
		}

		public static IEnumerator dummyFightSequence()
		{
			Singleton<FirstPersonController>.Instance.enabled = false;
			yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("The dummy stares lifelessly back at you.", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
			yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Then, suddenly it springs to motion!", -1.5f, 0.5f, Emotion.Anger, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
			GameObject.Find("x4 y1 dummy").transform.localRotation = Quaternion.Euler(270.9999f, 180f, 180);
			Tween.LocalRotation(GameObject.Find("x4 y1 dummy").transform, Quaternion.Euler(290, 180, 180), 0.2f, 0);
			Tween.LocalRotation(GameObject.Find("x4 y1 dummy").transform, Quaternion.Euler(270.9999f, 180f, 180), 0.2f, 0.2f);
			Tween.LocalPosition(GameObject.Find("x4 y1 dummy").transform, new Vector3(80, 3.2f, -20), 0.2f, 0.2f);
			Tween.LocalScale(GameObject.Find("x4 y1 dummy").transform, new Vector3(400, 400, 400), 0.2f, 0.2f);
			setupBattle(Singleton<MagnificusGameFlowManager>.Instance, false);

			CardBattleNodeData cardBattleNodeData = new CardBattleNodeData();

			cardBattleNodeData.blueprint = ScriptableObject.CreateInstance<MagnificusMod.BossBlueprints.DummyBlueprint>();

			GameObject.Find("Player").GetComponentInChildren<ViewManager>().SwitchToView(View.FirstPerson, true, false);
			Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(Singleton<MagnificusGameFlowManager>.Instance.TransitionTo(GameState.CardBattle, cardBattleNodeData, true, true));
			yield return new WaitForSeconds(0.35f);
			GameObject.Find("Player").GetComponentInChildren<ViewManager>().SwitchToView(View.Default, false, false);
			yield break;
		}

		public static void chooseBetweenLifeandRare(SelectableCard component)
        {
			if (component.gameObject.transform.localPosition.x == -1.5f)
            {
				Tween.LocalPosition(component.transform, new Vector3(1.5f, 15f, 1), 0.75f, 0);
				Tween.LocalPosition(GameObject.Find("LifePainting").transform, new Vector3(1.5f, 15f, 1), 0.75f, 0);
				Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(WaitThenDestroy(GameObject.Find("lifePaintingJr"), 0.2f));
				Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(WaitThenDestroy(component.gameObject, 0.8f));
				Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(WaitThenDisable(GameObject.Find("LifePainting"), 0.8f));

				GameObject.Destroy(component.gameObject);
				Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(Singleton<TextDisplayer>.Instance.ShowThenClear("How reckless.", 2f, 0f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null));
				Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(createRareCards());
			} else
            {
				Tween.LocalPosition(component.transform, new Vector3(1.5f, 15f, 1), 0.75f, 0);
				Tween.LocalPosition(GameObject.Find("rareChoice").transform, new Vector3(1.5f, 15f, 1), 0.75f, 0);
				Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(WaitThenDestroy(GameObject.Find("rareChoice"), 0.6f));
				//Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(WaitThenDestroy(component.gameObject, 0.6f));
				Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(Singleton<TextDisplayer>.Instance.ShowThenClear("Hmm.. I see..", 2f, 0f, Emotion.None, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null));
				Tween.LocalPosition(GameObject.Find("LifePainting").transform, new Vector3(0.05f, 5.74f, 0.24f), 0.75f, 0);
				Singleton<MagnificusGameFlowManager>.Instance.StartCoroutine(refreshLifePaintingAnim(component));
				Singleton<ViewManager>.Instance.SwitchToView(View.Default, false, false);
				Tween.Rotation(GameObject.Find("LifePainting").transform, Quaternion.Euler(0, 0, 0), 1.5f, 0);
				Tween.Rotation(GameObject.Find("LifePainting").transform, Quaternion.Euler(0, 180, 0), 1.5f, 1.6f);
				Tween.Rotation(GameObject.Find("LifePainting").transform, Quaternion.Euler(0, 0, 0), 1.5f, 3.1f);
				Tween.Rotation(GameObject.Find("LifePainting").transform, Quaternion.Euler(71, 0, 0), 0.75f, 4.6f);
			}
		}

		public static IEnumerator createRareCards()
        {
			yield return new WaitForSeconds(0.5f);
			RareCardChoicesSequencer state = Singleton<RareCardChoicesSequencer>.Instance;
			state.selectableCards = state.SpawnCards(3, GameObject.Find("GameTable").transform, new Vector3(-1.55f, 5.4f, 0.5f), 1.5f);
			int randomSeed = SaveManager.saveFile.GetCurrentRandomSeed();
			List<CardChoice> list = new List<CardChoice>();
			for (int i = 0; i < 3; i++)
			{
				List<CardInfo> unlockedCards = CardLoader.GetUnlockedCards(CardMetaCategory.Rare, CardTemple.Wizard);
				unlockedCards.RemoveAll((CardInfo x) => x.name == "MoxTriple" && x.HasTrait(Trait.Gem));
				unlockedCards.RemoveAll((CardInfo x) => !x.appearanceBehaviour.Contains(CardAppearanceBehaviour.Appearance.RareCardBackground));
				CardInfo card = CardLoader.Clone(unlockedCards[SeededRandom.Range(0, unlockedCards.Count, randomSeed)]);
				if (unlockedCards.Count >= 3)
				{
					randomSeed++;
					while (list.Exists((CardChoice x) => x.CardInfo.name == card.name) || card.metaCategories.Contains(CardMetaCategory.GBCPack))
					{
						card = CardLoader.Clone(unlockedCards[SeededRandom.Range(0, unlockedCards.Count, randomSeed)]);
						randomSeed++;
					}
				}
				list.Add(new CardChoice
				{
					CardInfo = card
				});
			}
			int num;
			for (int i = 0; i < state.selectableCards.Count; i = num + 1)
			{
				state.selectableCards[i].gameObject.SetActive(true);
				state.selectableCards[i].ChoiceInfo = list[i];
				state.selectableCards[i].Initialize(list[i].CardInfo, new Action<SelectableCard>(state.OnRewardChosen), new Action<SelectableCard>(state.OnCardFlipped), true, new Action<SelectableCard>(state.OnCardInspected));
				state.selectableCards[i].SetEnabled(false);
				state.selectableCards[i].SetFaceDown(true, true);
				Vector3 pos = state.selectableCards[i].gameObject.transform.localPosition;
				pos.y += 5;
				state.selectableCards[i].gameObject.transform.localPosition = pos;
				pos.y -= 5;
				Tween.LocalPosition(state.selectableCards[i].gameObject.transform, pos, 0.25f, 0);
				num = i;
				yield return new WaitForSeconds(0.1f);
			}
			Singleton<InteractionCursor>.Instance.InteractionDisabled = false;
			state.SetCollidersEnabled(true);
			state.gamepadGrid.enabled = true;
			state.chosenReward = null;
			yield break;
        }

		public static IEnumerator refreshLifePaintingAnim(SelectableCard card)
		{
			yield return new WaitForSeconds(2.9f);
			AudioController.Instance.PlaySound2D("magnificus_brush_splatter_color", MixerGroup.None, 0.5f, 0f, null, null, null, null, false);
			RunState.Run.playerLives = 3;
			GameObject.Find("LifePainting").transform.Find("Frame").Find("CanvasQuad").gameObject.GetComponent<MeshRenderer>().material.mainTexture = Tools.getImage("lifepainting" + RunState.Run.playerLives + ".png");
			yield return new WaitForSeconds(1.8f);
			Singleton<RareCardChoicesSequencer>.Instance.chosenReward = card;
			yield break;
		}

		//finale fixes

		public static IEnumerator spellBookTutorial()
        {
			if (!SavedVars.LearnedMechanics.Contains("spellbook"))
			{
				Singleton<ViewManager>.Instance.SwitchToView(View.Consumables, false, true);
				Singleton<SpellPile>.Instance.initializing = true;
				SavedVars.LearnedMechanics += "spellbook;";
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Hmm?", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Are you wondering what this book is for?", -2.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("That is your [c:g1]spell book[c:]. You may use it to draw one of your [c:g3]spell cards[c:].", -2.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("But only [c:g1]one[c:] per turn..", -2.5f, 0.15f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
				Singleton<SpellPile>.Instance.initializing = false;
				Singleton<ViewManager>.Instance.SwitchToView(View.WizardBattleUnits, false, false);
				Singleton<ViewController>.Instance.LockState = ViewLockState.Unlocked;
			}
			yield break;
        }






            //card select





            public class StartGameMagnificus
		{
			public static IEnumerator GetIn()
			{
				yield return new WaitForSeconds(0.85f);
				LoadingScreenManager.LoadScene("finale_magnificus");
				Time.timeScale = 1f;
				FrameLoopManager.Instance.SetIterationDisabled(false);
				RunState.Run.maxPlayerLives = 3;
				RunState.Run.playerLives = 3;
				SaveManager.SaveToFile();
				yield break;
			}
		}

		public static IEnumerator WaitThenDestroy(GameObject whotokill, float wait)
		{
			yield return new WaitForSeconds(wait);
			GameObject.Destroy(whotokill);
			yield break;
		}

		public static IEnumerator WaitThenDisable(GameObject whotodenable, float wait, bool denable = false)
		{
			yield return new WaitForSeconds(wait);
			try
			{
				whotodenable.SetActive(denable);
			} catch { }
			yield break;
		}

		public static IEnumerator WaitThenEnablePlayer(float wait)
		{
			if (config.isometricMode == false){Singleton<FirstPersonController>.Instance.LookAtDirection(Generation.lastView, false); Generation.lastView = LookDirection.North; }
			yield return new WaitForSeconds(wait);
			if (Singleton<ViewManager>.Instance.CurrentView != View.Candles)
			{
				GameObject.Find("Player").GetComponentInChildren<ViewManager>().CurrentView = View.FirstPerson;
				if (!config.isometricMode)
				{
					float x = GameObject.Find("PixelCameraParent").transform.position.x;
					float z = GameObject.Find("PixelCameraParent").transform.position.z;
					GameObject.Find("PixelCameraParent").transform.position = new Vector3(x, 16.5f, z);
					Tween.Position(GameObject.Find("PixelCameraParent").transform, new Vector3(x, 16.5f, z), 0f, 0f, null, Tween.LoopType.None, null, null, true);
				}
				Tween.FieldOfView(GameObject.Find("PixelCameraParent").transform.Find("Pixel Camera").gameObject.GetComponent<Camera>(), 65f, 0.05f, 0);
				GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().enabled = true;
				GameObject.Find("Player").GetComponentInChildren<ViewController>().allowedViews = new List<View>();
			}
			yield break;
		}

		public static IEnumerator FlashCard(GameObject card, float wait, GemType color = GemType.Orange, bool mana = true)
		{
			yield return new WaitForSeconds(wait);
			if (card == null) { yield break; }
			if (card.GetComponent<Card>() == null)
            {
				card = card.transform.parent.GetChild(6).gameObject;
            }

			if (card != null)
			{
				AudioController.Instance.PlaySound3D("wizard_cast", MixerGroup.TableObjectsSFX, card.transform.position, 0.25f, 0f, new AudioParams.Pitch(AudioParams.Pitch.Variation.Medium), null, new AudioParams.Randomization(noRepeating: false)).spatialBlend = 0.05f;

				Color flashcolor = new Color(1, 1, 1);
				switch (color)
				{
					case GemType.Orange:
						if (mana)
						{
							flashcolor = new Color(0.392f, 0.0156f, 0.549f, 0.5f);
							break;
						}
						flashcolor = new Color(1, 0.572f, 0.149f, 0.5f);
						break;
					case GemType.Green:
						flashcolor = new Color(0.643f, 0.8f, 0.345f, 0.5f);
						break;
					case GemType.Blue:
						flashcolor = new Color(0, 0.619f, 0.462f, 0.5f);
						break;
				}
				card.transform.Find("RenderStatsLayer").Find("Quad").gameObject.SetActive(true);
				card.transform.Find("RenderStatsLayer").Find("Quad").GetComponent<MeshRenderer>().material.color = flashcolor;
				yield return new WaitForSeconds(0.25f);
				card.transform.Find("RenderStatsLayer").Find("Quad").gameObject.SetActive(false);//0.9333 0.9569 0.7765 1
				card.transform.Find("RenderStatsLayer").Find("Quad").GetComponent<MeshRenderer>().material.color = new Color(0.9333f, 0.9569f, 0.7765f, 1f);
			}
			yield break;
		}




		public static IEnumerator SummonGoodCard(WizardBattlePortraitSlot instance, PlayableCard card, GameObject cardModel2, bool queuedCardSummon)
		{
			instance.transform.localPosition = new Vector3(instance.transform.localPosition.x, -15, 0);
			instance.transform.Find("Border").localPosition = new Vector3(instance.transform.Find("Border").localPosition.x, 15, -0.205f);
			if (queuedCardSummon)
			{
				instance.queueCard.ClearAppearanceBehaviours();
				instance.queueCardParent.transform.localPosition = new Vector3(instance.queueCardParent.localPosition.x, 22.02f, instance.queueCardParent.localPosition.z);
				if (card.Info.name != "Starvation")
				{
					instance.queueCardAnim.Play("summon", 0, 0f);
				}
				yield return new WaitForSeconds(0.6f);
				yield return new WaitForSeconds(0.001f);
				instance.gameObject.transform.GetChild(6).position = new Vector3(0, -100, 0);
			}
			if (!card.HasTrait(Trait.Giant)) { 
				cardModel2.transform.localPosition = new Vector3(0, 15f, 0);
				cardModel2.transform.localScale = new Vector3(5, 5, 5.6f);
			} else
            {
				cardModel2.transform.localPosition = new Vector3(12.1f, 25f, 8.5f);
				cardModel2.transform.localScale = new Vector3(20f, 17, 5.6f);
			}
			cardModel2.AddComponent<WizardBattle3DPortrait>();
			if (card.Info.HasSpecialAbility(MagnificusMod.Plugin.CustomPortrait))
            {
				cardModel2.AddComponent<MagnificusMod.SpecialAbilities.CustomPortraited>();
			}
			if (card.Info.HasSpecialAbility(MagnificusMod.Plugin.DeathCardPortrait))
			{
				cardModel2.AddComponent<MagnificusMod.SpecialAbilities.MagDeathCard>();
			}
			cardModel2.name = card.Info.displayedName + " Portrait";
			cardModel2.AddComponent<MagnificusMod.DisplayedStats>();

			if (queuedCardSummon)
			{
				Tween.LocalPosition(cardModel2.transform, new Vector3(0, 19.435f, -0.9f), 0.25f, 0);
				Tween.LocalRotation(cardModel2.transform, Quaternion.Euler(61, 0, 0), 0.25f, 0);
				yield return new WaitForSeconds(0.3f);
				instance.queueCardParent.gameObject.SetActive(false);

			}
			else if (!card.OpponentCard)//1.435 0.9924
			{
				Tween.LocalPosition(cardModel2.transform, new Vector3(0, 16.435f, -0.2076f), 0.25f, 0);
				Tween.LocalRotation(cardModel2.transform, Quaternion.Euler(71, 180, 0), 0.25f, 0);
				yield return new WaitForSeconds(0.25f);
			}
			else if (!card.OriginatedFromQueue)
			{
				if (!card.HasTrait(Trait.Giant))
				{
					Tween.LocalPosition(cardModel2.transform, new Vector3(0, 19.435f, -0.9f), 0.25f, 0);
				} else
                {
					Tween.LocalPosition(cardModel2.transform, new Vector3(12.1f, 7.715f, 8.5f), 0.25f, 0);
				}
				Tween.LocalRotation(cardModel2.transform, Quaternion.Euler(61, 0, 0), 0.5f, 0);
				yield return new WaitForSeconds(0.25f);
			}
			card.gameObject.transform.localRotation = Quaternion.Euler(90, 0, 0);
			
			

			instance.transform.localPosition = new Vector3(instance.transform.localPosition.x, 0, 0);
			instance.transform.Find("Border").localPosition = new Vector3(instance.transform.Find("Border").localPosition.x, 0, -0.205f);
			if (!card.OpponentCard)
			{
				cardModel2.transform.localPosition = new Vector3(0, 1.435f, -0.2076f);
			}
			else
			{
				instance.queueCardParent.transform.localPosition = new Vector3(instance.queueCardParent.localPosition.x, 7.02f, instance.queueCardParent.localPosition.z);
				instance.queueCard.gameObject.SetActive(true);
				cardModel2.transform.localPosition = (!card.HasTrait(Trait.Giant)) ? new Vector3(0, 4.435f, -0.9f) : new Vector3(12.1f, 7.715f, 8.5f);
			}

			if (card.HasAbility(Ability.Flying))
            {
				Vector3 flight = cardModel2.transform.position;
				flight.y += (0.75f + ((RunState.Run.regionTier == 4) ?  2.5f : 0f) );
				Tween.Position(cardModel2.transform, flight, 0.65f, 0);
				Tween.Rotation(cardModel2.transform, Quaternion.Euler((!card.OpponentCard) ? 45 : 41, 0, 0), 0.35f, 0);
				yield return new WaitForSeconds(0.35f);
				cardModel2.AddComponent<SineWaveMovement>();
				cardModel2.GetComponent<SineWaveMovement>().originalPosition = cardModel2.transform.localPosition;
				cardModel2.GetComponent<SineWaveMovement>().speed = 1.5f;
				cardModel2.GetComponent<SineWaveMovement>().yMagnitude = 0.46f;

			}
			cardModel2.GetComponent<Card>().RenderCard();
			yield break;
		}



		public static IEnumerator WizardDeathAnim(GameObject model)
		{
			yield return new WaitForSeconds(0.51f);
			for (int i = 5; i < model.transform.parent.childCount; i++)
			{
				if (model.transform.parent.GetChild(i).gameObject.GetComponent<Card>() != null)
				{
					model = model.transform.parent.GetChild(i).gameObject;

				}
			}
			model.transform.Find("RenderStatsLayer").Find("Quad").gameObject.SetActive(true);
			model.transform.Find("RenderStatsLayer").Find("Quad").GetComponent<MeshRenderer>().material.color = new Color(0.9333f, 0.9569f, 0.7765f, 1f);
			Tween.LocalPosition(model.transform, new Vector3(0, 8, 0.9924f), 0.15f, 0);
			Tween.LocalScale(model.transform.Find("RenderStatsLayer"), new Vector3(0.835f, 1.3f, 0.4378f), 0.15f, 0, null, Tween.LoopType.None, new Action(delegate {
				if (!config.oldCardDesigns) model.transform.Find("RenderStatsLayer").Find("cardFrame").gameObject.SetActive(false); 
			})
				);
			//yield return new WaitForSeconds(0.4f);
			//GameObject.Destroy(model.gameObject);
			yield break;
		}


		public static IEnumerator currencyTutorial()
        {
			if (!SavedVars.LearnedMechanics.Contains("overkill") && !SaveManager.saveFile.ascensionActive)
			{
				SavedVars.LearnedMechanics += "overkill;";
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("With a blaze of Magick, you end the battle. You managed to deal more damage than needed.", -1.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null);
				yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("The excess Magick you cast turns into [c:g3] Crystals. [c:] You may spend them at any meek store you happen to find.", -2.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
			}
			yield break;
		}

		public static int getClippingPlaneQualityAdjustment(int qualityOverride = -5)
        {
			int quality = QualitySettings.GetQualityLevel();
			if (qualityOverride > -5)
				quality = qualityOverride;
			quality -= 2;
			if (quality < 0)
				quality *= -1;
			quality *= 50;
			return quality;
        }
      
	


	}
}