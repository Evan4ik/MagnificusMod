using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Tools = MagnificusMod.Tools;

namespace MagnificusMod
{
    public class WallTextures
    {
        public static Texture2D none;
        public static Texture2D goo;
        public static Texture gooNormal;
        public static List<Sprite> gooDrips = new List<Sprite>();
        public static Texture2D dungeon;
        public static Texture dungeonNormal;
        public static Texture2D lava;
        public static Texture2D lavaNormal;
        public static Texture2D bookShelf;
        public static Texture2D lavafloor;
        public static Sprite manhole;
        public static Texture2D trapdoor;
        public static List<Sprite> runes = new List<Sprite>();
        public static Sprite minimapNode;
        public static List<Sprite> gridTiles = new List<Sprite>();
        public static List<Texture2D> cardBackTextures = new List<Texture2D>();
        public static void getImages()
        {
            none = Tools.getImage("blank.png");
            goo = (Resources.Load("art/generictexture3d/goo/Goo_Color") as Texture2D);
            gooNormal = (Resources.Load("art/generictexture3d/goo/Goo_Normal") as Texture);
            gooDrips = new List<Sprite>();
            for (int i = 1; i < 12; i++)
            {
                gooDrips.Add(Tools.getSprite("goo_drip" + i + ".png"));
            }
            runes = new List<Sprite>();
            for (int i = 1; i < 17; i++)
            {
                runes.Add(Tools.getSprite("runes" + i + ".png"));
            }
            lava = Tools.getImage("LavaWall.png");
            lavaNormal = Tools.getImage("LavaWallNormal.png");
            dungeon = (Resources.Load("art/generictexture3d/stonewall/Stone_Wall_001_COLOR") as Texture2D);
            dungeonNormal = (Resources.Load("art/generictexture3d/stonewall/Stone_Wall_001_NRM") as Texture);
            bookShelf = Tools.getImage("Bookshelf.png");
            lavafloor = Tools.getImage("LavaFloor.png");
            manhole = Tools.getSprite("manhole.png");
            trapdoor = Tools.getImage("trapdoor.png");
            minimapNode = Tools.getSprite("node.png");
            gridTiles.Add(Tools.getSprite("gridtile.png"));
            gridTiles.Add(Tools.getSprite("gridtile1.png"));

            cardBackTextures.Add(Tools.getImage("model_default.png"));
            cardBackTextures.Add(Tools.getImage("model_rare.png"));
            cardBackTextures.Add(Tools.getImage("model_terrain.png"));
        }
    }
}
