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
    public class MagCardFrame : ManagedBehaviour
    {
           //light color, darker color
        public Dictionary<string, List<Color>> styles = new Dictionary<string, List<Color>> { { "default", new List<Color> { new Color(0.8f, 0.8f, 0.8f, 1), new Color(0.5f, 0.5f, 0.5f, 1)}}, { "spell", new List<Color> { new Color(1f, 0.2f, 0.8f, 1f), new Color(0.8f, 0.2f, 0.5f, 1)}},
        { "rare", new List<Color> { new Color(0.86f, 0.86f, 0.65f, 1), new Color(0.8f, 0.8f, 0.8f, 1)}}, { "terrain", new List<Color> { new Color(0.4f, 0.35f, 0.35f, 1), new Color(0.5f, 0.5f, 0.5f, 1)}} };
        //default, rare
        public Dictionary<string, List<int>> textureOverride = new Dictionary<string, List<int>> { { "default", new List<int> { 0,0}}, { "spell",new List<int> { 0,0}},
        { "rare",new List<int> { 1, 0 } }, { "terrain",new List<int> { 2, 0 } }};

        public List<string> lightElements = new List<string> { "canvasHold", "cardbar" };
		public void setCardBars(bool active)
        {
            base.transform.Find("cardbar").gameObject.SetActive(active);
        }

        public void setTheme(string theme)
        {
            List<Color> themeColors = styles[theme];

            for (int i = 0; i < base.transform.childCount; i ++)
            {
                string name = base.transform.GetChild(i).gameObject.name;

                if (name.Contains("frameGemsParent")) continue;

                int isLight = (name.Contains("canvasHold") || name.Contains("cardbar") || name.Contains("edgedeco")) ? 0 : 1;
                Color color = themeColors[isLight];
                Texture2D texOverride = WallTextures.cardBackTextures[textureOverride[theme][isLight]];
                base.transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().material.color = color;
                base.transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().material.mainTexture = texOverride;
            }
        }

        public void setGems(bool active)
        {

            base.transform.Find("frameGemsParent").gameObject.SetActive(active);
            /*
            for (int i = 0; i < base.transform.childCount; i++)
            {
                string name = base.transform.GetChild(i).gameObject.name;

                if(!name.Contains("edgedeco")) continue;
                Transform edgeDeco = base.transform.GetChild(i);
                edgeDeco.localPosition = new Vector3(edgeDeco.localPosition.x, edgeDeco.localPosition.y, (active && !name.Contains(".003")) ? -0.0105f : -0.097f);
            }*/


        }

	}
}
