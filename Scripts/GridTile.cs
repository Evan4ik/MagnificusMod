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

namespace MagnificusMod
{
    public class GridTile : ManagedBehaviour
    {
        public bool checkOffset = false;
        public List<LookDirection> checkFrom;
        public LookDirection direction;

        public NavigationZone getZoneToCheckFrom(NavigationZone based)
        {
            if (checkOffset)
            {
                NavigationZone toReturn = NavigationGrid.instance.GetZoneInDirection(checkFrom[0], based);
                direction = checkFrom[1];
                if (toReturn == null) { 
                    toReturn = NavigationGrid.instance.GetZoneInDirection(checkFrom[1], based);
                    direction = checkFrom[0];
                }
                return toReturn;
            } else { return based; }
        }
    }
}
