using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using System.IO;
using DiskCardGame;
using SavedVars = MagnificusMod.SaveVariables;
using Random = UnityEngine.Random;

namespace MagnificusMod
{
    public static class RoomGen
    {
        public static List<List<string>> empty = new List<List<string>>
            {
            new List<string> { " ", " ", " ", " ", " ", " ", " " },
            new List<string> { " ", " ", " ", " ", " ", " ", " " },
            new List<string> { " ", " ", " ", " ", " ", " ", " " },
            new List<string> { " ", " ", " ", " ", " ", " ", " " },
            new List<string> { " ", " ", " ", " ", " ", " ", " " },
            new List<string> { " ", " ", " ", " ", " ", " ", " " },
            new List<string> { " ", " ", " ", " ", " ", " ", " " },
            };

        public static List<List<List<string>>> shop = new List<List<List<string>>>
            {
            new List<List<string>>
        {
             new List<string> { "W3C", "W3N", "W3J","W3D","W3J","W3N","W3C" },
            new List<string> { "W3E", "N2",   "-",  "-",  "-",  "-", "W3W" },
            new List<string> { "W3K",  "-",   "-",  "-",  "-",  "-", "W3K" },
            new List<string> { "W3d",  "-",   "-", "S","-",  "-", "W3d" },
            new List<string> { "W3H",  "-",   "P4",  "SK",  "P4",  "-", "W3K" },
            new List<string> { "W3E",  "-",   "-",  "-",  "-",  "-", "W3W" },
            new List<string> { "W3C", "W3S","W3H", "W3D","W3H","W3S", "W3C" }
            },
            new List<List<string>>
        {
             new List<string> { "W3C", "W3N", "W3J","W3D","W3J","W3N","W3C" },
            new List<string> { "W3E",  "A1E",   "-",  "-",  "N2",  "A2W", "W3W" },
            new List<string> { "W3K", "-",   "-",  "-",  "-",  "-", "W3K" },
            new List<string> { "W3d",  "-",   "-", "S","-",  "-", "W3d" },
            new List<string> { "W3H",  "-",   "-",  "SK",  "-",  "-", "W3K" },
            new List<string> { "W3E",  "A1E",   "-",  "-",  "-",  "A2W", "W3W" },
            new List<string> { "W3C", "W3S","W3H", "W3D","W3H","W3S", "W3C" }
           },
            new List<List<string>>
        {
             new List<string> { "W8C", "W8N", "W8J","W8D","W8J","W8N","W8C" },
            new List<string> { "W8E", "-",   "-",  "-",  "-",  "-", "W8W" },
            new List<string> { "W8K",  "-",   "-",  "-",  "TO2",  "-", "W8K" },
            new List<string> { "W8d",  "-",   "-", "S","-",  "-", "W8d" },
            new List<string> { "W8H",  "-",   "TO2",  "SK",  "-",  "-", "W8K" },
            new List<string> { "W8E",  "N2",   "-",  "-",  "-",  "-", "W8W" },
            new List<string> { "W8C", "W8S","W8H", "W8D","W8H","W8S", "W8C" }
            },
            };

        public static List<List<string>> b1 = new List<List<string>>
            {
             new List<string> { "WgC", "WgN", "WgJ","WgD","WgJ","WgN","WgC" },
            new List<string> { "WgE",  "-",   "-",  "-",  "-",  "-", "WgW" },
            new List<string> { "WgK",  "-",   "-",  "-",  "-",  "-", "WgK" },
            new List<string> { "Wgd",  "-",   "-", "B1","-",  "-", "Wgd" },
            new List<string> { "WgH",  "-",   "-",  "-",  "-",  "-", "WgK" },
            new List<string> { "WgE",  "-",   "-",  "-",  "-",  "-", "WgW" },
            new List<string> { "WgC", "WgS","WgH", "WgD","WgH","WgS", "WgC" }
            };
        public static List<List<string>> b2 = new List<List<string>>
            {
             new List<string> { "W5C", "W5N", "W5J","W5D","W5J","W5N","W5C" },
            new List<string> { "W5E",  "PK",   "SWR",  "SWR",  "SWR",  "PK", "W5W" },
            new List<string> { "W5K",  "-",   "PK",  "-",  "PK",  "-", "W5K" },
            new List<string> { "W5d",  "-",   "SWR", "B2","SWR",  "-", "W5d" },
            new List<string> { "W5H",  "-",   "SWR",  "-",  "SWR",  "-", "W5K" },
            new List<string> { "W5E",  "-",   "-",  "-",  "-",  "-", "W5W" },
            new List<string> { "W5C", "W5S","W5H", "W5S","W5H","W5S", "W5C" }
            };
        public static List<List<string>> b3 = new List<List<string>>
            {
             new List<string> { "WnC", "WnN", "WnJ","WnD","WnJ","WnN","WnC" },
            new List<string> { "WnE",  "-",   "-",  "-",  "-",  "-", "WnW" },
            new List<string> { "WnK",  "-",   "-",  "-",  "-",  "-", "WnK" },
            new List<string> { "Wnd",  "-",   "-", "B3","-",  "-", "Wnd" },
            new List<string> { "WnH",  "-",   "-",  "-",  "-",  "-", "WnK" },
            new List<string> { "WnE",  "-",   "-",  "-",  "-",  "-", "WnW" },
            new List<string> { "WnC", "WnS","WnH", "WnS","WnH","WnS", "WnC" }
            };

        public static List<List<List<string>>> EdaxioRooms = new List<List<List<string>>>
        {
            new List<List<string>>
        {
            new List<string> { "W1C", "W1N", "W1J","W1C","W1J","W1N","W1C", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W1C", "W1N", "W1N","W1N","W1N","W1N","W1C" },
            new List<string> { "W1E",  "W1N", "W1N", "W1N", "W1N", "W1N", "W1W", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W1E", "-", "-", "-", "-", "-", "W1W" },
            new List<string> { "W1K",  "W1N", "W1N","W1N",  "W1N",  "W1N", "W1W", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W1E", " ", " ", " ", " ", " ", "W1W" },
            new List<string> { "W1d",  "-",   "-",   "-",    "-",  "EX1", "W1W", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W1E", "-", "-", "-", "-", "EXA", "W1W" },
            new List<string> { "W1H",  "W1S", "W1S", "W1C",  "P3",  "W1C", "W1W", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W1E", " ", " ", " ", " ", " ", "W1W" },
            new List<string> { "W1E",  "W1S",   "W1S",  "W1S",  "W1S",  "W1S", "W1W", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W1E", "-", "-", "-", "-", "-", "W1W" },
            new List<string> { "W1C", "W1S","W1H", "W1N","W1H","W1S", "W1C", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W1C", "W1S", "W1S", "W1S", "W1S", "W1S", "W1C" }
        },
            new List<List<string>>
        {
             new List<string> { "W4C", "W4N", "W4J","W4C","W4J","W4N","W4C", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W4C", "W4N", "W4N","W4N","W4N","W4N","W4C" },
            new List<string> { "W4E",  "W4N", "W5N", "W4N", "W4N", "W4N", "W4W", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W4E", "-", "-", "-", "-", "-", "W4W" },
            new List<string> { "W4K",  "W4N", "W5N","W4N",  "W4N",  "W5C", "W5W", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W4E", " ", " ", " ", " ", " ", "W4W" },
            new List<string> { "W4d",  "-",   "-",   "-",    "-",  "EX1", "W4W", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W4E", "-", "-", "-", "-", "EXA", "W4W" },
            new List<string> { "W5H",  "W4S", "W5S", "W4S",  "PK",  "W4C", "W4W", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W4E", " ", " ", " ", " ", " ", "W4W" },
            new List<string> { "W4E",  "W4S",   "W5S",  "W4S",  "W4S",  "W4S", "W4W", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W4E", "-", "-", "-", "-", "-", "W4W" },
            new List<string> { "W4C", "W4S","W4H", "W4N","W4H","W4S", "W4C", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W4C", "W4S", "W4S", "W4S", "W4S", "W4S", "W4C" }
        },
            new List<List<string>>
        {
            new List<string> { "W8C", "W8N", "W8J","W8C","W8J","W8N","W8C", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W8C", "W8N", "W8N","W8N","W8N","W8N","W8C" },
            new List<string> { "W8E",  "W8N", "W8N", "W8N", "W8N", "W8N", "W8W", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W8E", "-", "-", "-", "-", "-", "W8W" },
            new List<string> { "W8K",  "W8N", "W8N","W8N",  "W8N",  "W8N", "W8W", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W8E", " ", " ", " ", " ", " ", "W8W" },
            new List<string> { "W8d",  "-",   "-",   "-",    "-",  "EX1", "W8W", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W8E", "-", "-", "-", "-", "EXA", "W8W" },
            new List<string> { "W8H",  "W8S", "W8S", "W8C",  "RUNE",  "W8C", "W8W", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W8E", " ", " ", " ", " ", " ", "W8W" },
            new List<string> { "W8E",  "W8S",   "W8S",  "W8S",  "W8S",  "W8S", "W8W", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W8E", "-", "-", "-", "-", "-", "W8W" },
            new List<string> { "W8C", "W8S","W8H", "W8N","W8H","W8S", "W8C", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W8C", "W8S", "W8S", "W8S", "W8S", "W8S", "W8C" }
        }
         };
        public static List<List<List<string>>> GooRooms = new List<List<List<string>>>
        {
        new List<List<string>>
        {
            new List<string> { "W1C", "W2N", "W1J","W1D","W1J","W1N","W1C" },
            new List<string> { "W1E", "-",   "-",  "-",  "-",  "-", "W1W" },
            new List<string> { "W1K",  "-",   "P3",  "-",  "P3",  "-", "W2K" },
            new List<string> { "W1d",  "-",   "-", "SPWN","-",  "-", "W1d" },
            new List<string> { "W1H",  "-",   "P3",  "-",  "P3",  "-", "W1K" },
            new List<string> { "W1E",  "-",   "-",  "-",  "-",  "-", "W1W" },
            new List<string> { "W1C", "W1S","W1H", "W1D","W1H","W1S", "W1C" }
        },
        new List<List<string>>
        {
            new List<string> { "W1C", "W2N", "W1J","W1D","W1J","W1N","W1C" },
            new List<string> { "W1E",  "-",   "-",  "-",  "-",  "-", "W1W" },
            new List<string> { "W1K",  "-",   "P1",  "-",  "P1",  "-", "W2K" },
            new List<string> { "W1d",  "-",   "-", "C","-",  "-", "W1d" },
            new List<string> { "W1H",  "-",   "P1",  "-",  "P1",  "-", "W1K" },
            new List<string> { "W1E",  "-",   "-",  "-",  "-",  "-", "W1W" },
            new List<string> { "W1C", "W1S","W1H", "W1D","W1H","W1S", "W1C" }
        },
       new List<List<string>>
        {
            new List<string> { "W1C", "W2N", "W1J","W1D","W1J","W1N","W1C" },
            new List<string> { "W1E",  "-",   "-",  "-",  "-",  "-", "W1W" },
            new List<string> { "W1K",  "-",   "WgP",  "-",  "-",  "-", "W2K" },
            new List<string> { "W1d",  "-",   "-",  "C",  "-",  "-", "W1d" },
            new List<string> { "W1H",  "-",   "-",  "-",  "WgP",  "-", "W1K" },
            new List<string> { "W1E",  "-",   "-",  "-",  "-",  "-", "W1W" },
            new List<string> { "W1C", "W1S","W1H", "W1D","W1H","W1S", "W1C" }
        },
       new List<List<string>>
        {
            new List<string> { "W1C", "W2N", "W1J","W1D","W1J","W1N","W1C" },
            new List<string> { "W1E",  "-",   "-",  "-",  "-",  "-", "W1W" },
            new List<string> { "W1K",  "-",   "EVN",  "-",  "-",  "-", "W2K" },
            new List<string> { "W1d",  "-",   "-",  "WgP",  "-",  "-", "W1d" },
            new List<string> { "W1H",  "-",   "-",  "-",  "CR",  "-", "W1K" },
            new List<string> { "W1E",  "-",   "-",  "-",  "-",  "-", "W1W" },
            new List<string> { "W1C", "W1S","W1H", "W1D","W1H","W1S", "W1C" }
        },
        new List<List<string>>
        {
            new List<string> { "WgC", "WgN", "WgJ","WgD","WgJ","WgN","WgC" },
            new List<string> { "WgE",  "-",   "-",  "-",  "-",  "-", "WgW" },
            new List<string> { "WgK",  "-",   "-",  "-",  "-",  "-", "WgK" },
            new List<string> { "Wgd",  "-",   "W1P",  "EVN",  "W1P",  "-", "Wgd" },
            new List<string> { "WgH",  "-",   "-",  "-",  "-",  "-", "WgK" },
            new List<string> { "WgE",  "-",   "-",  "-",  "-",  "-", "WgW" },
            new List<string> { "WgC", "WgS","WgH", "WgD","WgH","WgS", "WgC" }
        },
        new List<List<string>>
        {
            new List<string> { "W1C", "W2N", "W1J","W1D","W1J","W1N","W1C" },
            new List<string> { "W1E", "W1F", "W1F",  "-", "W1F", "W1F", "W1W" },
            new List<string> { "W1K", "W1F",   "W1F",  "-", "W1F", "W1F", "W2K" },
            new List<string> { "W1d",  "-",   "-",  "-",  "-",  "-", "W1d" },
            new List<string> { "W1H", "W1F", "W1F",  "-", "W1F", "W1F", "W1K" },
            new List<string> { "W1E", "W1F", "W1F",  "-", "W1F", "W1F", "W1W" },
            new List<string> { "W1C", "W1S","W1H", "W1D","W1H","W1S", "W1C" }
        },
        new List<List<string>>
        {
            new List<string> { "W1C", "W1N", "W1J","W1D","W1J","W1N","W1C" },
            new List<string> { "W1E",  "-",   "-",  "-",  "-",  "-", "W1W" },
            new List<string> { "W1K",  "-",   "-",  "-",  "-",  "-", "W1K" },
            new List<string> { "W1d",  "-",   "P2",  "B",  "P2",  "-", "W1d" },
            new List<string> { "W1H",  "-",   "-",  "-",  "-",  "-", "W1K" },
            new List<string> { "W1E",  "-",   "-",  "-",  "-",  "-", "W1W" },
            new List<string> { "W1C", "W1S","W1H", "W1D","W1H","W1S", "W1C" }
        },
        new List<List<string>>
        {
            new List<string> { "W1C", "W1N", "W1J","W1D","W1J","W1N","W1C" },
            new List<string> { "W1E",  "-",   "-",  "-",  "-",  "-", "W1W" },
            new List<string> { "W1K",  "-",   "P1",  "-",  "P3",  "-", "W1K" },
            new List<string> { "W1d",  "-",   "-",  "CS",  "-",  "-", "W1d" },
            new List<string> { "W1H",  "-",   "P2",  "-",  "P1",  "-", "W1K" },
            new List<string> { "W1E",  "-",   "-",  "-",  "-",  "-", "W1W" },
            new List<string> { "W1C", "W1S","W1H", "W1D","W1H","W1S", "W1C" }
        },
        new List<List<string>>
        {
            new List<string> { "W1C", "W1N", "W1J","W1D","W1J","W1N","W1C" },
            new List<string> { "W1E",  "-",   "-",  "-",  "-",  "-", "W1W" },
            new List<string> { "W1K",  "-",   "-",  "-",  "-",  "-", "W1K" },
            new List<string> { "W1d",  "-",   "-",  "B",  "-",  "-", "W1d" },
            new List<string> { "W1H",  "-",   "-",  "-",  "-",  "-", "W1K" },
            new List<string> { "W1E",  "-",   "-",  "-",  "-",  "-", "W1W" },
            new List<string> { "W1C", "W1S","W1H", "W1D","W1H","W1S", "W1C" }
        },
        new List<List<string>>
        {
            new List<string> { "W1C", "W1N", "W1J","W1D","W1J","W1N","W1C" },
            new List<string> { "W1E",  "-",   "-",  "-",  "P1",  "-", "W1W" },
            new List<string> { "W1K",  "-",   "-",  "-",  "-",  "-", "W1K" },
            new List<string> { "W1d",  "-",   "-",  "CR",  "-",  "-", "W1d" },
            new List<string> { "W1H",  "-",   "-",  "-",  "-",  "P3", "W1K" },
            new List<string> { "W1E",  "-",   "P2",  "-",  "-",  "-", "W1W" },
            new List<string> { "W1C", "W1S","W1H", "W1D","W1H","W1S", "W1C" }
        },
         new List<List<string>>
        {
            new List<string> { "W1C", "W1N", "W1J","W1D","W1J","W1N","W1C" },
            new List<string> { "W1E",  "-",   "-",  "-",  "-",  "-", "W1W" },
            new List<string> { "W1K",  "-",   "P1",  "-",  "P3",  "-", "W1K" },
            new List<string> { "W1d",  "-",   "-",  "C",  "-",  "-", "W1d" },
            new List<string> { "W1H",  "-",   "P2",  "-",  "P1",  "-", "W1K" },
            new List<string> { "W1E",  "-",   "-",  "-",  "-",  "-", "W1W" },
            new List<string> { "W1C", "W1S","W1H", "W1D","W1H","W1S", "W1C" }
        },
        new List<List<string>>
        {
            new List<string> { "W1C", "W1N", "W1J","W1D","W1J","W1N","W1C" },
            new List<string> { "W1E",  "-",   "-",  "-",  "P1",  "-", "W1W" },
            new List<string> { "W1K",  "-",   "-",  "-",  "-",  "-", "W1K" },
            new List<string> { "W1d",  "-",   "-",  "CC",  "-",  "-", "W1d" },
            new List<string> { "W1H",  "-",   "-",  "-",  "-",  "P3", "W1K" },
            new List<string> { "W1E",  "-",   "P2",  "-",  "-",  "-", "W1W" },
            new List<string> { "W1C", "W1S","W1H", "W1D","W1H","W1S", "W1C" }
        },
        new List<List<string>>
        {
            new List<string> { "W1C", "W1N", "W1J","W1D","W1J","W1N","W1C" },
            new List<string> { "W1E",  "-",   "P3",  "-",  "P3",  "-", "W1W" },
            new List<string> { "W1K",  "P3",   "-",  "-",  "-",  "P3", "W1K" },
            new List<string> { "W1d",  "-",   "-",  "CS",  "-",  "-", "W1d" },
            new List<string> { "W1H",  "P2",   "-",  "-",  "-",  "P2", "W1K" },
            new List<string> { "W1E",  "-",   "P3",  "-",  "P3",  "-", "W1W" },
            new List<string> { "W1C", "W1S","W1H", "W1D","W1H","W1S", "W1C" }
        },
       new List<List<string>>
        {
            new List<string> { "W1C", "W1N", "W1J","W1D","W1J","W1N","W1C" },
            new List<string> { "W1E",  "-",   "P3",  "-",  "P3",  "-", "W1W" },
            new List<string> { "W1K",  "P3",   "-",  "-",  "-",  "P3", "W1K" },
            new List<string> { "W1d",  "-",   "-",  "CR",  "-",  "-", "W1d" },
            new List<string> { "W1H",  "P2",   "-",  "-",  "-",  "P2", "W1K" },
            new List<string> { "W1E",  "-",   "P3",  "-",  "P3",  "-", "W1W" },
            new List<string> { "W1C", "W1S","W1H", "W1D","W1H","W1S", "W1C" }
        },
       new List<List<string>>
        {
            new List<string> { "W1C", "W1N", "W1J","W1D","W1J","W1N","W1C" },
            new List<string> { "W1E",  "-",   "-",  "-",  "-",  "-", "W1W" },
            new List<string> { "W1K",  "-",   "W1P",  "-",  "W1P",  "-", "W1K" },
            new List<string> { "W1d",  "-",   "-",  "EVN",  "-",  "-", "W1d" },
            new List<string> { "W1H",  "-",   "W1P",  "-",  "W1P",  "-", "W1K" },
            new List<string> { "W1E",  "-",   "-",  "-",  "-",  "-", "W1W" },
            new List<string> { "W1C", "W1S","W1H", "W1D","W1H","W1S", "W1C" }
        },
       new List<List<string>>
        {
            new List<string> { "W1C", "W1N", "W1J","W1D","W1J","W1N","W1C" },
            new List<string> { "W1E",  "C",   "-",  "-",  "-",  "EN", "W1W" },
            new List<string> { "W1K",  "-", "W1F", "W1F", "W1F",  "-", "W1K" },
            new List<string> { "W1d",  "-", "W1F",  "W1F", "W1F",  "-", "W1d" },
            new List<string> { "W1H",  "-", "W1F", "W1F", "W1F",  "-", "W1K" },
            new List<string> { "W1E",  "B",   "-",  "-",  "-",  "E", "W1W" },
            new List<string> { "W1C", "W1S","W1H", "W1D","W1H","W1S", "W1C" }
        },
       new List<List<string>>
        {
            new List<string> { "W1C", "W2N", "W1J","W1D","W1J","W1N","W1C" },
            new List<string> { "W1E", "W1F", "W1F",  "-", "W1F", "W1F", "W1W" },
            new List<string> { "W1K", "W1F",   "W1F",  "-", "W1F", "W1F", "W2K" },
            new List<string> { "W1d",  "-",   "-",  "EVN",  "-",  "-", "W1d" },
            new List<string> { "W1H", "W1F", "W1F",  "-", "W1F", "W1F", "W1K" },
            new List<string> { "W1E", "W1F", "W1F",  "-", "W1F", "W1F", "W1W" },
            new List<string> { "W1C", "W1S","W1H", "W1D","W1H","W1S", "W1C" }
        },
              new List<List<string>>
        {
            new List<string> { "W1C", "W2N", "W1J","W1D","W1J","W1N","W1C" },
            new List<string> { "W1E",  "W1F",   "-",  "-",  "-",  "W1F", "W1W" },
            new List<string> { "W1K",  "-",   "C",  "-",  "-",  "-", "W2K" },
            new List<string> { "W1d",  "-",   "-", "P3","-",  "-", "W1d" },
            new List<string> { "W1H",  "-",   "-",  "-",  "EN",  "-", "W1K" },
            new List<string> { "W1E",  "W1F",   "-",  "-",  "-",  "W1F", "W1W" },
            new List<string> { "W1C", "W1S","W1H", "W1D","W1H","W1S", "W1C" }
        },
        new List<List<string>>
        {
            new List<string> { "W1C", "W2N", "W1J","W1D","W1J","W1N","W1C" },
            new List<string> { "W1E",  "-",   "-",  "-",  "-",  "-", "W1W" },
            new List<string> { "W1K",  "-",   "P2",  "-",  "P3",  "-", "W2K" },
            new List<string> { "W1d",  "-",   "-", "CS","-",  "-", "W1d" },
            new List<string> { "W1H",  "-",   "P3",  "-",  "P3",  "-", "W1K" },
            new List<string> { "W1E",  "-",   "-",  "-",  "-",  "-", "W1W" },
            new List<string> { "W1C", "W1S","W1H", "W1D","W1H","W1S", "W1C" }
        },
        new List<List<string>>
        {
            new List<string> { "W1C", "W2N", "W1J","W1D","W1J","W1N","W1C" },
            new List<string> { "W1E",  "-",   "-",  "-",  "-",  "-", "W1W" },
            new List<string> { "W1K",  "-",   "-",  "P2",  "-",  "-", "W2K" },
            new List<string> { "W1d",  "-",   "-", "CC","-",  "-", "W1d" },
            new List<string> { "W1H",  "-",   "-",  "P2",  "-",  "-", "W1K" },
            new List<string> { "W1E",  "-",   "-",  "-",  "-",  "-", "W1W" },
            new List<string> { "W1C", "W1S","W1H", "W1D","W1H","W1S", "W1C" }
        },
         new List<List<string>>
        {
            new List<string> { "W1C", "W2N", "W1J","W1D","W1J","W1N","W1C" },
            new List<string> { "W1E",  "-",   "-",  "-",  "-",  "-", "W1W" },
            new List<string> { "W1K",  "-",   "-",  "-",  "-",  "-", "W2K" },
            new List<string> { "W1d",  "-",   "P1", "C","P1",  "-", "W1d" },
            new List<string> { "W1H",  "-",   "-",  "-",  "-",  "-", "W1K" },
            new List<string> { "W1E",  "-",   "-",  "-",  "-",  "-", "W1W" },
            new List<string> { "W1C", "W1S","W1H", "W1D","W1H","W1S", "W1C" }
        },
         new List<List<string>>
        {
            new List<string> { "W1C", "W2N", "W1J","W1D","W1J","W1N","W1C" },
            new List<string> { "W1E",  "-",   "-",  "-",  "-",  "-", "W1W" },
            new List<string> { "W1K",  "-",   "-",  "-",  "-",  "-", "W2K" },
            new List<string> { "W1d",  "-",   "W3F", "CR","W3F",  "-", "W1d" },
            new List<string> { "W1H",  "-",   "-",  "-",  "-",  "-", "W1K" },
            new List<string> { "W1E",  "-",   "-",  "-",  "-",  "-", "W1W" },
            new List<string> { "W1C", "W1S","W1H", "W1D","W1H","W1S", "W1C" }
        },
         new List<List<string>>
        {
            new List<string> { "W1C", "W2N", "W1J","W1D","W1J","W1N","W1C" },
            new List<string> { "W1E",  "-",   "-",  "-",  "-",  "-", "W1W" },
            new List<string> { "W1K",  "-",   "-",  "W1P",  "-",  "-", "W2K" },
            new List<string> { "W1d",  "-",   "B", "EVN","B",  "-", "W1d" },
            new List<string> { "W1H",  "-",   "-",  "W1P",  "-",  "-", "W1K" },
            new List<string> { "W1E",  "-",   "-",  "-",  "-",  "-", "W1W" },
            new List<string> { "W1C", "W1S","W1H", "W1D","W1H","W1S", "W1C" }
        },
          new List<List<string>>
        {
            new List<string> { "W1C", "W2N", "W1J","W1D","W1J","W1N","W1C" },
            new List<string> { "W1E",  "-",   "-",  "-",  "-",  "-", "W1W" },
            new List<string> { "W1K",  "-",   "-",  "WgP",  "-",  "-", "W2K" },
            new List<string> { "W1d",  "-",   "B", "EVN","B",  "-", "W1d" },
            new List<string> { "W1H",  "-",   "-",  "WgP",  "-",  "-", "W1K" },
            new List<string> { "W1E",  "-",   "-",  "-",  "-",  "-", "W1W" },
            new List<string> { "W1C", "W1S","W1H", "W1D","W1H","W1S", "W1C" }
        },
          new List<List<string>>
        {
            new List<string> { "W1C", "W2N", "W1J","W1D","W1J","W1N","W1C" },
            new List<string> { "W1E",  "-",   "-",  "-",  "-",  "-", "W1W" },
            new List<string> { "W1K",  "-",   "-",  "P3",  "-",  "-", "W2K" },
            new List<string> { "W1d",  "-",   "-",  "CR",  "-",  "-", "W2d" },
            new List<string> { "W1H",  "-",   "-",  "P3",  "-",  "-", "W1K" },
            new List<string> { "W1E",  "-",   "-",  "-",  "-",  "-", "W1W" },
            new List<string> { "W1C", "W1S","W1H", "W1D","W1H","W1S", "W1C" }
        },
          new List<List<string>>//troll
        {
            new List<string> { "W1C", "W2N", "W1J","W1D","W1J","W2N","W1C" },
            new List<string> { "W2E",  "-", "W3F",  "-",  "-",  "-", "W2W" },
            new List<string> { "W1K",  "-",   "-", "W3F",  "-",  "-", "W1K" },
            new List<string> { "W1d",  "-",   "-",  "EVN",  "-",  "-", "W1d" },
            new List<string> { "W1H",  "-",   "-", "W3F",  "-",  "-", "W1K" },
            new List<string> { "W2E",  "-",   "-",  "-", "W3F",  "-", "W2W" },
            new List<string> { "W1C", "W2S","W1H", "W1D","W1H","W2S", "W1C" }
        },
          new List<List<string>>
        {
            new List<string> { "W2C", "W2N", "W2J","W2D","W2J","W2N","W2C" },
            new List<string> { "W2E",  "-",   "-",  "-",  "-",  "-", "W2W" },
            new List<string> { "W2K",  "-",   "-",  "WgP",  "-",  "-", "W2K" },
            new List<string> { "W2d",  "-",   "-", "EVN","-",  "-", "W2d" },
            new List<string> { "W2H",  "-",   "-",  "W1P",  "-",  "-", "W2K" },
            new List<string> { "W2E",  "-",   "-",  "-",  "-",  "-", "W2W" },
            new List<string> { "W2C", "W2S","W2H", "W2D","W2H","W2S", "W2C" }
        },
          new List<List<string>>
        {
            new List<string> { "W2C", "W1N", "W2J","W1D","W2J","W1N","W2C" },
            new List<string> { "W1E",  "P2",   "-",  "B",  "-",  "P3", "W1W" },
            new List<string> { "W2K",  "W1P",   "-",  "-",  "-",  "W1P", "W2K" },
            new List<string> { "W1d",  "-",    "CR",  "EVN",   "CS",  "-", "W1d" },
            new List<string> { "W2H",  "W1P",   "-",  "-",  "-",  "W1P", "W2K" },
            new List<string> { "W1E",  "P3",   "-",  "B",  "-",  "P2", "W1W" },
            new List<string> { "W2C", "W1S","W2H", "W1D","W2H","W1S", "W2C" }
        },
          new List<List<string>>
        {
            new List<string> { "W1C", "W1N", "W1J","W1D","W1J","W1N","W1C" },
            new List<string> { "W1E",  "EVN",   "WgP",  "-",  "WgP",  "-", "W1W" },
            new List<string> { "W1K",  "B",   "-",  "-",  "-",  "-", "W1K" },
            new List<string> { "W1d",  "-",   "-", "P3","-",  "C", "W1d" },
            new List<string> { "W1H",  "-",   "-",  "-",  "-",  "W1F", "W1K" },
            new List<string> { "W1E",  "-",   "WgP",  "CR",  "W1F",  "W1F", "W1W" },
            new List<string> { "W1C", "W1S","W1H", "W1D","W1H","W1S", "W1C" }
        },
        new List<List<string>>
        {
            new List<string> { "W1C", "W2N", "W1J","W1D","W1J","W1N","W1C" },
            new List<string> { "W1E",  "-",   "-",  "-",  "-",  "-", "W1W" },
            new List<string> { "W1K",  "-",   "P1",  "-",  "P1",  "-", "W2K" },
            new List<string> { "W1d",  "-",   "-", "EVN","-",  "-", "W1d" },
            new List<string> { "W1H",  "-",   "P1",  "-",  "P1",  "-", "W1K" },
            new List<string> { "W1E",  "-",   "-",  "-",  "-",  "-", "W1W" },
            new List<string> { "W1C", "W1S","W1H", "W1D","W1H","W1S", "W1C" }
        },
       new List<List<string>>
        {
            new List<string> { "W1C", "W2N", "W1J","W1D","W1J","W1N","W1C" },
            new List<string> { "W1E",  "-",   "-",  "-",  "-",  "-", "W1W" },
            new List<string> { "W1K",  "-",   "W3F",  "-",  "W3F",  "-", "W2K" },
            new List<string> { "W1d",  "-",   "P3", "EVN","P3",  "-", "W1d" },
            new List<string> { "W1H",  "-",   "W3F",  "-",  "W3F",  "-", "W1K" },
            new List<string> { "W1E",  "-",   "-",  "-",  "-",  "-", "W1W" },
            new List<string> { "W1C", "W1S","W1H", "W1D","W1H","W1S", "W1C" }
        },
       new List<List<string>>
        {
            new List<string> { "W1C", "W2N", "W1J","W1D","W1J","W2N","W1C" },
            new List<string> { "W2E",  "CR",   "W3F",  "-",  "-",  "-", "W2W" },
            new List<string> { "W1K",  "B",   "-",  "-",  "-",  "-", "W1K" },
            new List<string> { "W1d",  "-",   "-", "EVN","-",  "-", "W1d" },
            new List<string> { "W1H",  "-",   "-",  "-",  "-",  "B", "W1K" },
            new List<string> { "W2E",  "-",   "-",  "-",  "W3F",  "CR", "W2W" },
            new List<string> { "W1C", "W2S","W1H", "W1D","W1H","W2S", "W1C" }
        },
        new List<List<string>>
        {
            new List<string> { "W1C", "W2N", "W1J","W1D","W1J","W1N","W1C" },
            new List<string> { "W1E",  "-",   "-",  "-",  "-",  "-", "W1W" },
            new List<string> { "W1K",  "-",   "-",  "-",  "-",  "-", "W2K" },
            new List<string> { "W1d",  "-",   "P1", "EVN","P1",  "-", "W1d" },
            new List<string> { "W1H",  "-",   "-",  "-",  "-",  "-", "W1K" },
            new List<string> { "W1E",  "-",   "-",  "-",  "-",  "-", "W1W" },
            new List<string> { "W1C", "W1S","W1H", "W1D","W1H","W1S", "W1C" }
        },
        new List<List<string>>
        {
            new List<string> { "W1C", "W2N", "W1J","W1D","W1J","W1N","W1C" },
            new List<string> { "W1E",  "-",   "WgP",  "-",  "P3",  "-", "W1W" },
            new List<string> { "W1K",  "-",   "-",  "-",  "-",  "-", "W2K" },
            new List<string> { "W1d",  "-",   "-", "CS","-",  "-", "W1d" },
            new List<string> { "W1H",  "-",   "-",  "-",  "-",  "-", "W1K" },
            new List<string> { "W1E",  "-",   "P2",  "-",  "P3",  "-", "W1W" },
            new List<string> { "W1C", "W1S","W1H", "W1D","W1H","W1S", "W1C" }
        },
        new List<List<string>>
        {
            new List<string> { "W1C", "W2N", "W1J","W1D","W1J","W1N","W1C" },
            new List<string> { "W1E",  "CR",   "-",  "-",  "-",  "B", "W1W" },
            new List<string> { "W1K",  "B",   "W1F",  "W1F",  "W1F",  "-", "W2K" },
            new List<string> { "W1d",  "-",   "-",    "EVN",    "W1F",   "EVN", "W1d" },
            new List<string> { "W1H",  "B",   "W1P",    "-",  "W1F",  "W1F", "W1K" },
            new List<string> { "W1E",  "CS",   "P1",    "-",  "W1F",  "W1F", "W1W" },
            new List<string> { "W1C", "W1S","W2H", "W1D","W1H","W1S", "W1C" }
        },
        new List<List<string>>
        {
            new List<string> { "W2C", "W2N", "W2J","W1D","W1J","W1N","W1C" },
            new List<string> { "W2E",  "W2P", "-",  "-",  "-",  "W1F", "W1W" },
            new List<string> { "W2K",  "-",   "B",  "-",  "W1F",  "CS", "W1K" },
            new List<string> { "W1d",  "-",   "-", "-","-",  "-", "W1d" },
            new List<string> { "W1H",  "CR",   "W1F","-",  "B",  "-", "W2K" },
            new List<string> { "W1E",  "W1F","-",  "-",  "-",  "W2P", "W2W" },
            new List<string> { "W1C", "W1S","W1H", "W1D","W2H","W2S", "W2C" }
        },
         new List<List<string>>
        {
            new List<string> { "WgC", "WgN", "WgJ","WgD","WgJ","WgN","WgC" },
            new List<string> { "WgE",  "-",   "-",  "-",  "-",  "-", "WgW" },
            new List<string> { "WgK",  "-",   "-",  "P3",  "-",  "-", "WgK" },
            new List<string> { "Wgd",  "-",   "P3", "CR","P3",  "-", "Wgd" },
            new List<string> { "WgH",  "P2",   "-",  "B",  "-",  "-", "WgK" },
            new List<string> { "WgE",  "-",   "-",  "-",  "-",  "-", "WgW" },
            new List<string> { "WgC", "WgS","WgH", "WgD","WgH","WgS", "WgC" }
        },
         new List<List<string>>
        {
            new List<string> { "W1C", "W1N", "W1J","W1D","W1J","W1N","W1C" },
            new List<string> { "W1E",  "P3",   "W3F",  "-",  "W3F",  "P2", "W1W" },
            new List<string> { "W1K",  "-",   "-",  "-",  "-",  "-", "W1K" },
            new List<string> { "W1d",  "-",   "-", "EVN","-",  "-", "W1d" },
            new List<string> { "W1H",  "-",   "-",  "-",  "-",  "-", "W1K" },
            new List<string> { "W1E",  "P3",   "W3F",  "-",  "W3F",  "P2", "W1W" },
            new List<string> { "W1C", "W1S","W1H", "W1D","W1H","W1S", "W1C" }
        },
         new List<List<string>>
        {
            new List<string> { "WgC", "WgN", "WgJ","WgD","WgJ","WgN","WgC" },
            new List<string> { "WgE",  "-",   "-",  "-",  "-",  "-", "WgW" },
            new List<string> { "WgK",  "-",   "-",  "-",  "-",  "-", "WgK" },
            new List<string> { "Wgd",  "-",   "-", "B","-",  "-", "Wgd" },
            new List<string> { "WgH",  "-",   "-",  "-",  "-",  "-", "WgK" },
            new List<string> { "WgE",  "-",   "-",  "-",  "-",  "-", "WgW" },
            new List<string> { "WgC", "WgS","WgH", "WgD","WgH","WgS", "WgC" }
        },
         new List<List<string>>
        {
            new List<string> { "W1C", "W1N", "W1J","W1D","W1J","W1N","W1C" },
            new List<string> { "W1E",  "W1F",   "-",  "-",  "W1F",  "W1F", "W1W" },
            new List<string> { "W1K",  "W1F",   "EVN",  "W1F",  "W1F",  "W1F", "W1K" },
            new List<string> { "W1d",  "-",   "-",  "-",  "-",  "CR", "W1d" },
            new List<string> { "W1H",  "W1F",   "W1F",  "W1F",  "-",  "W1F", "W1K" },
            new List<string> { "W1E",  "W1F",   "W1F",  "CS",  "-",  "W1F", "W1W" },
            new List<string> { "W1C", "W1S","W1H", "W1D","W1H","W1S", "W1C" }
        },
        };

        public static List<List<List<string>>> LavaRooms = new List<List<List<string>>>
        {
        new List<List<string>>
        {
            new List<string> { "W4C", "W5N", "W4J","W4D","W4J","W4N","W4C", "W4N", "W4N","W4N","W4C","W4C" },
            new List<string> { "W4E", "MR1",   "MR1",  "MR2",  "MR1",  "MR1", "MRR", " ",   " ",  " ",  " ", "W4W" },
            new List<string> { "W4K",  "MR1",   "PK",  "MR1",  "PK",  "MR1", "W5W", "PK",   " ",  "PK",  " ", "W4W" },
            new List<string> { "W4d",  "MR2",   "-", "SPWN","MR1",  "MR1", "W4W", " ",   " ", " "," ",  "W4W" },
            new List<string> { "W4H",  "-",   "PK",  "-",  "PK",  "MR1", "W4W",  "PK",   " ",  "PK",  " ", "W4W" },
            new List<string> { "W4E",  "-",   "-",  "-",  "MR1",  "MR1", "W4W", " ",   " ",  " ",  " ", "W4W" },
            new List<string> { "W4C", "W4S","W4S", "W4S","W4S","W4S", "W4S", "W4S","W4S", "W4S","W4S","W4C" }
        },
         new List<List<string>>
        {
            new List<string> { "W4C", "W5N", "W4J","W4D","W4J","W4N","W4C" },
            new List<string> { "W4E",  "-",   "-",  "-",  "-",  "-", "W4W" },
            new List<string> { "W5K",  "-",   "SWR",  "-",  "-",  "-", "W5K" },
            new List<string> { "W4d",  "-",   "-", "EVN","-",  "-", "W4d" },
            new List<string> { "W4H",  "-",   "-",  "-",  "SWR",  "-", "W4K" },
            new List<string> { "W4E",  "-",   "-",  "-",  "-",  "-", "W4W" },
            new List<string> { "W4C", "W4S","W5H", "W4D","W4H","W5S", "W4C" }
        },
         new List<List<string>>
        {
            new List<string> { "W4C", "W5N", "W4J","W4D","W4J","W4N","W4C" },
            new List<string> { "W4E",  "-",   "-",  "-",  "-",  "-", "W4W" },
            new List<string> { "W5K",  "-",   "PK",  "-",  "-",  "-", "W5K" },
            new List<string> { "W4d",  "-",   "-", "CR","-",  "-", "W4d" },
            new List<string> { "W4H",  "-",   "-",  "-",  "PK",  "-", "W4K" },
            new List<string> { "W4E",  "-",   "-",  "-",  "-",  "-", "W4W" },
            new List<string> { "W4C", "W4S","W5H", "W4D","W4H","W5S", "W4C" }
        },
         new List<List<string>>
        {
            new List<string> { "W4C", "W5N", "W4J","W6D","W4J","W4N","W4C" },
            new List<string> { "W4E",  "-",   "-",  "-",  "-",  "CRT", "W4W" },
            new List<string> { "W5K",  "-",   "SWR",  "PK",  "-",  "-", "W5K" },
            new List<string> { "W6d",  "-",   "-", "CS","-",  "-", "W6d" },
            new List<string> { "W4H",  "-",   "PK",  "-",  "SWR",  "-", "W4K" },
            new List<string> { "W4E",  "CRT",   "-",  "-",  "-",  "-", "W4W" },
            new List<string> { "W4C", "W4S","W5H", "W6D","W4H","W5S", "W4C" }
        },
       new List<List<string>>
        {
            new List<string> { "W4C", "W5N", "W4J","W4D","W4J","W4N","W4C" },
            new List<string> { "W5E",  "-",   "W1F",  "-",  "W1F",  "-", "W5W" },
            new List<string> { "W5K",  "W1F",   "SWR",  "-",  "PK",  "W1F", "W5K" },
            new List<string> { "W4d",  "-",   "-", "B","-",  "-", "W4d" },
            new List<string> { "W4H",  "W1F",   "PK",  "-",  "SWR",  "W1F", "W4K" },
            new List<string> { "W4E",  "-",   "W1F",  "-",  "W1F",  "-", "W4W" },
            new List<string> { "W4C", "W5S","W5H", "W4D","W4H","W5S", "W4C" }
        },
       new List<List<string>>//troll room p2
        {
            new List<string> { "W4C", "W5N", "W4J","W4D","W4J","W4N","W4C" },
            new List<string> { "W5E",  "-",   "-",  "-",  "-",  "-", "W5W" },
            new List<string> { "W5K",  "-", "W1F", "W1F", "W1F",  "-", "W5K" },
            new List<string> { "W4d",  "-", "W1F", "htr", "W1F",  "-", "W4d" },
            new List<string> { "W4H",  "-", "W1F", "W1F", "W1F",  "-", "W4K" },
            new List<string> { "W4E",  "-",   "-",  "-",  "-",  "-", "W4W" },
            new List<string> { "W4C", "W5S","W5H", "W4D","W4H","W5S", "W4C" }
        },
       new List<List<string>>
        {
            new List<string> { "W4C", "W5N", "W4J","W4D","W4J","W4N","W4C" },
            new List<string> { "W4E",  "CRT",   "-",  "-",  "-",  "CS", "W4W" },
            new List<string> { "W5K",  "-",   "CRT",  "-",  "CRT",  "-", "W5K" },
            new List<string> { "W4d",  "-",   "-", "B","-",  "-", "W4d" },
            new List<string> { "W4H",  "W1F",   "W1F",  "W1F",  "W1F",  "W1F", "W4K" },
            new List<string> { "W4E",  "CRT",   "-",  "-",  "EVN",  "CRT", "W4W" },
            new List<string> { "W4C", "W4S","W5H", "W4D","W4H","W5S", "W4C" }
        },
       new List<List<string>>
        {
            new List<string> { "W4C", "W5N", "W4J","W4D","W4J","W4N","W4C" },
            new List<string> { "W4E",  "P2",   "CRT",  "-",  "P2",  "P3", "W4W" },
            new List<string> { "W5K",  "CRT",   "-",  "-",  "CRT",  "CRT", "W5K" },
            new List<string> { "W4d",  "-",   "-", "SWR","-",  "-", "W4d" },
            new List<string> { "W4H",  "CR",   "-",  "-",  "-",  "PK", "W4K" },
            new List<string> { "W4E",  "CRT",   "CS",  "-",  "CRT",  "CRT", "W4W" },
            new List<string> { "W4C", "W4S","W5H", "W4D","W4H","W5S", "W4C" }
        },
       new List<List<string>>
        {
            new List<string> { "W5C", "W5N", "W5J","W5D","W5J","W5N","W5C" },
            new List<string> { "W5E",  "-",   "-",  "-",  "-",  "-", "W5W" },
            new List<string> { "W5K",  "-",   "WzC",  "WzS",  "WzC",  "-", "W5K" },
            new List<string> { "W5d",  "-",   "WzW", "htr","WzE",  "-", "W5d" },
            new List<string> { "W5H",  "-",   "WzC",  "WzN",  "WzC",  "-", "W5K" },
            new List<string> { "W5E",  "-",   "-",  "-",  "-",  "-", "W5W" },
            new List<string> { "W5C", "W5S","W5H", "W5D","W5H","W5S", "W5C" }
        },
       new List<List<string>>
        {
            new List<string> { "W4C", "W4N", "W4J","W4D","W4J","W4N","W5C" },
            new List<string> { "W4E",  "-",   "SWR",  "-",  "B",  "EVN", "W5W" },
            new List<string> { "W5K",  "-",   "-",  "-",  "W1F",  "W5C", "W5K" },
            new List<string> { "W4d",  "-",   "-", "-","PK",  "-", "W5d" },
            new List<string> { "W5H",  "-",   "-",  "-",  "-",  "-", "W5K" },
            new List<string> { "W4E",  "CS",   "CRT",  "-",  "W5C",  "-", "W5W" },
            new List<string> { "W4C", "W4S","W4H", "W5D","W5H","W5S", "W5C" }
        },
       new List<List<string>>
        {
            new List<string> { "W4C", "W5N", "W4J","W4D","W4J","W4N","W4C" },
            new List<string> { "W4E",  "PK",   "PK",  "-",  "PK",  "PK", "W4W" },
            new List<string> { "W5K",  "PK",   "-",  "-",  "-",  "PK", "W5K" },
            new List<string> { "W4d",  "-",   "-",   "CR", "-",  "-", "W4d" },
            new List<string> { "W4H",  "PK",   "-",  "-",  "-",  "PK", "W4K" },
            new List<string> { "W4E",  "PK",   "PK",  "-",  "PK",  "PK", "W4W" },
            new List<string> { "W4C", "W4S","W5H", "W4D","W4H","W5S", "W4C" }
        },
       new List<List<string>>
        {
            new List<string> { "W4C", "W4N", "W4J","W6D","W4J","W4N","W4C" },
            new List<string> { "W6E",  "CRT",   "A1S",  "-",  "A1S",  "CRT", "W6W" },
            new List<string> { "W4K",  "CRT",   "-",  "-",  "-",  "CRT", "W4K" },
            new List<string> { "W6d",  "-",   "SWR", "EVN","SWR",  "-", "W6d" },
            new List<string> { "W4H",  "-",   "-",  "-",  "-",  "-", "W4K" },
            new List<string> { "W6E",  "CRT",   "A2N",  "-",  "A2N",  "CRT", "W6W" },
            new List<string> { "W4C", "W4S","W4H", "W6D","W4H","W4S", "W4C" }
        },
       new List<List<string>>
        {
            new List<string> { "W4C", "W5N", "W4J","W4D","W4J","W4N","W4C" },
            new List<string> { "W4E",  "-",   "W1F",  "-",  "-",  "EVN", "W4W" },
            new List<string> { "W5K",  "-",   "W1F",  "-",  "W1F",  "-", "W5K" },
            new List<string> { "W4d",  "-",   "W1F", "-","W1F",  "-", "W4d" },
            new List<string> { "W4H",  "-",   "W1F",  "-",  "W1F",  "-", "W4K" },
            new List<string> { "W4E",  "CR",   "-",  "-",  "W1F",  "-", "W4W" },
            new List<string> { "W4C", "W4S","W5H", "W4D","W4H","W5S", "W4C" }
        },
       new List<List<string>>
        {
            new List<string> { "W4C", "W5N", "W6J","W4D","W6J","W4N","W4C" },
            new List<string> { "W4E",  "CR",   "B",  "-",  "-",  "-", "W4W" },
            new List<string> { "W6K",  "SWR",   "SWR",  "-",  "-",  "-", "W6K" },
            new List<string> { "W4d",  "-",   "-", "-","-",  "-", "W4d" },
            new List<string> { "W6H",  "-",   "-",  "-",  "PK",  "PK", "W6K" },
            new List<string> { "W4E",  "-",   "-",  "-",  "B",  "CS", "W4W" },
            new List<string> { "W4C", "W4S","W6H", "W4D","W6H","W5S", "W4C" }
        },
       new List<List<string>>
        {
            new List<string> { "W4C", "W5N", "W4J","W4D","W6J","W4N","W4C" },
            new List<string> { "W4E",  "PK",   "A2E",  "-",  "A1W",  "SWR", "W4W" },
            new List<string> { "W6K",  "A2S",   "SWR",  "-",  "PK",  "A1S", "W5K" },
            new List<string> { "W4d",  "-",   "-",  "CR",  "-",  "-", "W4d" },
            new List<string> { "W4H",  "A1N",   "PK",  "-",  "SWR",  "A2N", "W6K" },
            new List<string> { "W4E",  "SWR",   "A1E",  "-",  "A2W",  "PK", "W4W" },
            new List<string> { "W4C", "W4S","W6H", "W4D","W4H","W5S", "W4C" }
        },
       new List<List<string>>
        {
            new List<string> { "W4C", "W5N", "W6J","W4D","W4J","W4N","W4C" },
            new List<string> { "W4E",  "PK",   "A2E",  "-",  "A1W",  "SWR", "W4W" },
            new List<string> { "W5K",  "A2S", "SWR",  "-",  "PK",  "A1S", "W6K" },
            new List<string> { "W4d",  "-",   "-",  "EVN",  "-",  "-", "W4d" },
            new List<string> { "W6H",  "A1N",   "PK",  "-", "SWR",  "A2N", "W4K" },
            new List<string> { "W4E",  "SWR",   "A1E",  "-",  "A2W",  "PK", "W4W" },
            new List<string> { "W4C", "W4S","W5H", "W4D","W6H","W5S", "W4C" }
        },
        new List<List<string>>
        {
            new List<string> { "W4C", "W5N", "W4J","W4D","W4J","W4N","W4C" },
            new List<string> { "W4E",  "-",   "-",  "-",  "-",  "A1N", "W4W" },
            new List<string> { "W5K",  "-",   "W1F",  "-",  "W1F",  "-", "W5K" },
            new List<string> { "W4d",  "-",   "-",  "B",  "-",  "-", "W4d" },
            new List<string> { "W4H",  "-",   "W1F",  "-",  "W1F",  "-", "W4K" },
            new List<string> { "W4E",  "A2N",   "-",  "-",  "-",  "-", "W4W" },
            new List<string> { "W4C", "W4S","W5H", "W4D","W4H","W5S", "W4C" }
        },
         new List<List<string>>
        {
            new List<string> { "W4C", "W4N", "W4J","W6D","W4J","W4N","W4C" },
            new List<string> { "W4E",  "-",   "-",  "-",  "-",  "-", "W4W" },
            new List<string> { "W4K",  "-",   "-",  "-",  "-",  "-", "W4K" },
            new List<string> { "W6d",  "-",   "-",  "A1N",  "-",  "-", "W6d" },
            new List<string> { "W4H",  "-",   "-",  "-",  "-",  "-", "W4K" },
            new List<string> { "W4E",  "-",   "-",  "-",  "-",  "-", "W4W" },
            new List<string> { "W4C", "W4S","W4H", "W6D","W4H","W4S", "W4C" }
        },
         new List<List<string>>
        {
            new List<string> { "W4C", "W4N", "W4J","W5D","W4J","W4N","W4C" },
            new List<string> { "W4E",  "CRT",   "-",  "-",  "-",  "CRT", "W4W" },
            new List<string> { "W4K",  "CRT",   "-",  "CRT",  "-",  "CRT", "W4K" },
            new List<string> { "W5d",  "-",   "B",  "CRT",  "EVN",  "-", "W5d" },
            new List<string> { "W4H",  "CRT",   "-",  "-",  "-",  "CRT", "W4K" },
            new List<string> { "W4E",  "CRT",   "CRT",  "-",  "CRT",  "CRT", "W4W" },
            new List<string> { "W4C", "W4S","W4H", "W5D","W4H","W4S", "W4C" }
        },
          new List<List<string>>
        {
            new List<string> { "W4C", "W4N", "W5J","W5D","W5J","W4N","W4C" },
            new List<string> { "W4E",  "-",   "W1F",  "-",  "CR",  "-", "W4W" },
            new List<string> { "W5K",  "-",   "W1F",  "-",  "W1F",  "-", "W5K" },
            new List<string> { "W5d",  "-",   "W1F",  "-",  "W1F",  "-", "W5d" },
            new List<string> { "W5H",  "-",   "W1F",  "-",  "W1F",  "-", "W5K" },
            new List<string> { "W4E",  "-",   "EVN",  "-",  "W1F",  "-", "W4W" },
            new List<string> { "W4C", "W4S","W5H", "W5D","W5H","W4S", "W4C" }
        },
          new List<List<string>>
        {
            new List<string> { "W4C", "W6N", "W6J","W6D","W6J","W6N","W4C" },
            new List<string> { "W6E",  "CRT",   "-",  "-",  "-",  "CRT", "W6W" },
            new List<string> { "W6K",  "-",   "-",  "-",  "-",  "-", "W6K" },
            new List<string> { "W6d",  "-",   "-",  "CS",  "-",  "-", "W6d" },
            new List<string> { "W6H",  "-",   "-",  "-",  "-",  "-", "W6K" },
            new List<string> { "W6E",  "CRT",   "-",  "-",  "-",  "CRT", "W6W" },
            new List<string> { "W4C", "W6S","W6H", "W6D","W6H","W6S", "W4C" }
        },
          new List<List<string>>
        {
            new List<string> { "W4C", "W6N", "W6J","W6D","W6J","W6N","W4C" },
            new List<string> { "W6E",  "CRT",   "-",  "-",  "-",  "CRT", "W6W" },
            new List<string> { "W6K",  "-",   "-",  "-",  "-",  "-", "W6K" },
            new List<string> { "W6d",  "-",   "-",  "EVN",  "-",  "-", "W6d" },
            new List<string> { "W6H",  "-",   "-",  "-",  "-",  "-", "W6K" },
            new List<string> { "W6E",  "CRT",   "-",  "-",  "-",  "CRT", "W6W" },
            new List<string> { "W4C", "W6S","W6H", "W6D","W6H","W6S", "W4C" }
        },
          new List<List<string>>
        {
            new List<string> { "W4C", "W4N", "W5J","W6D","W4J","W4N","W4C" },
            new List<string> { "W4E",  "PK",   "-",  "-",  "-",  "-", "W4W" },
            new List<string> { "W5K",  "-",   "-",  "-",  "SWR",  "-", "W4K" },
            new List<string> { "W6d",  "-",   "-",  "EVN",  "-",  "-", "W6d" },
            new List<string> { "W4H",  "-",   "SWR",  "-",  "-",  "-", "W5K" },
            new List<string> { "W4E",  "-",   "-",  "-",  "-",  "PK", "W4W" },
            new List<string> { "W4C", "W4S","W4H", "W6D","W5H","W4S", "W4C" }
        },
          new List<List<string>>
        {
            new List<string> { "W4C", "W5N", "W6J","W4D","W6J","W4N","W4C" },
            new List<string> { "W4E",  "W1F",   "-",  "-",  "-",  "W1F", "W4W" },
            new List<string> { "W6K",  "-",   "-",  "SWR",  "-",  "-", "W6K" },
            new List<string> { "W4d",  "-",   "B", "EVN","B",  "-", "W4d" },
            new List<string> { "W6H",  "-",   "-",  "PK",  "-",  "-", "W6K" },
            new List<string> { "W4E",  "W1F",   "-",  "-",  "-",  "W1F", "W4W" },
            new List<string> { "W4C", "W4S","W6H", "W4D","W6H","W5S", "W4C" }
        },
         new List<List<string>>
        {
            new List<string> { "W4C", "W4N", "W4J","W5D","W4J","W4N","W4C" },
            new List<string> { "W4E",  "EVN",   "-",  "-",  "-",  "-", "W4W" },
            new List<string> { "W4K",  "-",   "W1F",  "W1F",  "W1F",  "B", "W4K" },
            new List<string> { "W5d",  "-",   "W1F",  "CR",  "-",  "-", "W5d" },
            new List<string> { "W4H",  "-",   "W1F",  "-",  "-",  "-", "W4K" },
            new List<string> { "W4E",  "-",   "W1F",  "-",  "-",  "-", "W4W" },
            new List<string> { "W4C", "W4S","W4H", "W5D","W4H","W4S", "W4C" }
        },
         new List<List<string>>
        {
            new List<string> { "W4C", "W5N", "W4J","W4D","W4J","W4N","W4C" },
            new List<string> { "W4E",  "-",   "W1F",  "-",  "W1F",  "PK", "W4W" },
            new List<string> { "W5K",  "-",   "W1F",  "-",  "W1F",  "-", "W5K" },
            new List<string> { "W4d",  "-",   "-",   "EVN","-",  "-", "W4d" },
            new List<string> { "W4H",  "-",   "W1F",  "-",  "W1F",  "-", "W4K" },
            new List<string> { "W4E",  "SWR",   "W1F",  "-",  "W1F",  "-", "W4W" },
            new List<string> { "W4C", "W4S","W5H", "W4D","W4H","W5S", "W4C" }
        },
         new List<List<string>>
        {
            new List<string> { "W4C", "W5N", "W4J","W6D","W4J","W4N","W4C" },
            new List<string> { "W4E",  "CS",   "-",  "-",  "W1F",  "CS", "W5W" },
            new List<string> { "W4K",  "-",   "-",  "W1F",  "-",  "-", "W4K" },
            new List<string> { "W6d",  "-",   "W1F",  "CS",  "PK",  "-", "W6d" },
            new List<string> { "W4H",  "B",   "SWR",  "-",  "-",  "-", "W4K" },
            new List<string> { "W5E",  "-",   "-",  "-",  "PK",  "-", "W4W" },
            new List<string> { "W4C", "W4S","W4H", "W6D","W4H","W5S", "W4C" }
        },
         new List<List<string>>
        {
            new List<string> { "W5C", "W5N", "W5J","W5D","W5J","W5N","W5C" },
            new List<string> { "W5E",  "-",   "-",  "-",  "-",  "-", "W5W" },
            new List<string> { "W5K",  "-",   "W1F",  "-",  "W1F",  "-", "W5K" },
            new List<string> { "W5d",  "-",   "EN",  "SWR",  "C",  "-", "W6d" },
            new List<string> { "W5H",  "-",   "W1F",  "-",  "W1F",  "-", "W5K" },
            new List<string> { "W5E",  "-",   "-",  "-",  "-",  "-", "W5W" },
            new List<string> { "W5C", "W5S","W5H", "W5D","W5H","W5S", "W5C" }
        },
         new List<List<string>>
        {
            new List<string> { "W4C", "W4N", "W4J","W6D","W4J","W4N","W4C" },
            new List<string> { "W4E",  "-",   "A2N",  "-",  "A2N",  "-", "W4W" },
            new List<string> { "W4K",  "SWR",   "-",  "-",  "-",  "SWR", "W4K" },
            new List<string> { "W6d",  "-",   "-",  "EVN",  "-",  "-", "W6d" },
            new List<string> { "W4H",  "CRT",   "-",  "-",  "-",  "CRT", "W4K" },
            new List<string> { "W4E",  "PK",   "PK",  "-",  "PK",  "PK", "W4W" },
            new List<string> { "W4C", "W4S","W4H", "W6D","W4H","W4S", "W4C" }
        },
         new List<List<string>>
        {
            new List<string> { "W4C", "W4N", "W6J","W6D","W6J","W4N","W4C" },
            new List<string> { "W4E",  "PK",   "-",  "EVN",  "-",  "PK", "W4W" },
            new List<string> { "W6K",  "-",   "-",  "PK",  "-",  "-", "W6K" },
            new List<string> { "W6d",  "-",   "PK",  "PK",  "PK",  "-", "W6d" },
            new List<string> { "W6H",  "-",   "-",  "PK",  "-",  "-", "W6K" },
            new List<string> { "W4E",  "PK",   "-",  "CR",  "-",  "PK", "W4W" },
            new List<string> { "W4C", "W4S","W6H", "W6D","W6H","W4S", "W4C" }
        },
         new List<List<string>>
        {
            new List<string> { "W4C", "W4N", "W4J","W4D","W4J","W4N","W4C" },
            new List<string> { "W4E",  "PK",   "CRT",  "-",  "CRT",  "PK", "W4W" },
            new List<string> { "W4K",  "CRT",   "CRT",  "-",  "CRT",  "CRT", "W4K" },
            new List<string> { "W4d",  "-",   "CRT",  "-",  "-",  "-", "W4d" },
            new List<string> { "W4H",  "CR",   "-",  "-",  "CRT",  "CRT", "W4K" },
            new List<string> { "W4E",  "PK",   "CS",  "-",  "CRT",  "PK", "W4W" },
            new List<string> { "W4C", "W4S","W4H", "W4D","W4H","W4S", "W4C" }
        },
        };

        public static List<List<List<string>>> LavaPuzzleRooms = new List<List<List<string>>>
        {
            new List<List<string>>
            {
                new List<string> { "W4C", "W5N", "W5J","W4N","W5J","W5N","W4C" },
                new List<string> { "W5E", "-", "-", "-", "-", "-", "W5W" },
                new List<string> { "W5K", "-", "SWR", "-", "-", "-", "W5K" },
                new List<string> { "W4d", "-", "-", "T21", "-", "-", "W4d" },
                new List<string> { "W5H", "-", "-", "-", "SWR", "-", "W5K" },
                new List<string> { "W5E", "-", "-", "-", "-", "-", "W5W" },
                new List<string> { "W4C", "W5S", "W5H", "W4D", "W5H", "W5S", "W4C" }
            },
            new List<List<string>>
            {
                new List<string> { "W4C", "W5N", "W4J","W4D","W4J", "W7N", "W4C" },
                new List<string> { "W4E",  "-",   "-",  "-",  "EVN",  "CRT", "W4W" },
                new List<string> { "W5K",  "W1F",   "W1F",  "-",  "W1F",  "W1F", "W5K" },
                new List<string> { "W4d",  "-",   "-", "-","-",  "-", "W4d" },
                new List<string> { "W4H",  "-",   "CRT",  "-",  "CRT",  "-", "W4K" },
                new List<string> { "W4E",  "CRT",   "-",  "-",  "-",  "CS", "W4W" },
                new List<string> { "W4C", "W4S","W4H", "W4D","W4H","W5S", "W4C" }
            },
            new List<List<string>>
        {
            new List<string> { "W4C", "W7N", "W4J","W6D","W4J","W4N","W4C" },
            new List<string> { "W4E",  "-",   "-",  "-",  "-",  "-", "W4W" },
            new List<string> { "W4K",  "-",   "-",  "-",  "-",  "-", "W4K" },
            new List<string> { "W6d",  "-",   "-",  "A1N",  "-",  "-", "W6d" },
            new List<string> { "W4H",  "-",   "-",  "-",  "-",  "-", "W4K" },
            new List<string> { "W4E",  "-",   "-",  "-",  "-",  "-", "W4W" },
            new List<string> { "W4C", "W4S","W4H", "W6D","W4H","W4S", "W4C" }
        },
            new List<List<string>>
        {
            new List<string> { "W4C", "W4N", "W5J","W6D","W4J","W4N","W4C" },
            new List<string> { "W4E",  "PK",   "-",  "-",  "-",  "-", "W7W" },
            new List<string> { "W5K",  "-",   "-",  "-",  "SWR",  "-", "W4K" },
            new List<string> { "W6d",  "-",   "-",  "EVN",  "-",  "-", "W6d" },
            new List<string> { "W4H",  "-",   "SWR",  "-",  "-",  "-", "W5K" },
            new List<string> { "W4E",  "-",   "-",  "-",  "-",  "PK", "W4W" },
            new List<string> { "W4C", "W4S","W4H", "W6D","W5H","W4S", "W4C" }
        },
            new List<List<string>>
        {
            new List<string> { "W4C", "W7N", "W4J","W4D","W4J","W4N","W4C" },
            new List<string> { "W4E",  "-",   "-",  "-",  "-",  "A1N", "W4W" },
            new List<string> { "W5K",  "-",   "W1F",  "-",  "W1F",  "-", "W5K" },
            new List<string> { "W4d",  "-",   "-",  "B",  "-",  "-", "W4d" },
            new List<string> { "W5H",  "-",   "W1F",  "-",  "W1F",  "-", "W4K" },
            new List<string> { "W4E",  "A2N",   "-",  "-",  "-",  "-", "W4W" },
            new List<string> { "W4C", "W4S","W5H", "W4D","W4H","W5S", "W4C" }
        },
            new List<List<string>>
        {
            new List<string> { "W4C", "W5N", "W4J","W4D","W4J","W4N","W4C" },
            new List<string> { "W4E",  "-",   "CRT",  "-",  "PK",  "PK", "W4W" },
            new List<string> { "W5K",  "-",   "-",  "-",  "-",  "PK", "W5K" },
            new List<string> { "W4d",  "-",   "-",   "CR", "-",  "-", "W4d" },
            new List<string> { "W4H",  "PK",   "-",  "-",  "-",  "-", "W7K" },
            new List<string> { "W4E",  "PK",   "PK",  "-",  "CRT",  "-", "W4W" },
            new List<string> { "W4C", "W4S","W5H", "W4D","W4H","W4S", "W4C" }
        },
            new List<List<string>>
        {
            new List<string> { "W4C", "W5N", "W4J","W4D","W4J","W4N","W4C" },
            new List<string> { "W4E",  "-",   "-",  "-",  "-",  "-", "W7W" },
            new List<string> { "W5K",  "-",   "PK",  "-",  "-",  "-", "W5K" },
            new List<string> { "W4d",  "-",   "-", "CR","-",  "-", "W4d" },
            new List<string> { "W4H",  "-",   "-",  "-",  "PK",  "-", "W4K" },
            new List<string> { "W4E",  "-",   "-",  "-",  "-",  "-", "W4W" },
            new List<string> { "W4C", "W4S","W5H", "W4D","W4H","W5S", "W4C" }
        },
         new List<List<string>>
        {
            new List<string> { "W4C", "W5N", "W4J","W6D","W4J","W4N","W4C" },
            new List<string> { "W4E",  "-",   "-",  "-",  "-",  "CRT", "W4W" },
            new List<string> { "W5K",  "-",   "SWR",  "PK",  "-",  "-", "W5K" },
            new List<string> { "W6d",  "-",   "-", "CS","-",  "-", "W6d" },
            new List<string> { "W4H",  "-",   "PK",  "-",  "SWR",  "-", "W4K" },
            new List<string> { "W4E",  "CRT",   "-",  "-",  "-",  "-", "W7W" },
            new List<string> { "W4C", "W4S","W5H", "W6D","W4H","W5S", "W4C" }
        },
        };

        public static List<List<List<string>>> VoidRooms = new List<List<List<string>>>
        {
        new List<List<string>>
        {
            new List<string> { "W8C", "W8N", "W8J","W8D","W8J","W8N","W8C" },
            new List<string> { "W8E", "RUNE",   "-",  "-",  "-",  "-", "W8W" },
            new List<string> { "W8K",  "-",   "TO2",  "-",  "CRT",  "-", "W8K" },
            new List<string> { "W8d",  "-",   "-", "SPWN","-",  "-", "W8d" },
            new List<string> { "W8H",  "-",   "CRT",  "-",  "TO2",  "-", "W8K" },
            new List<string> { "W8E",  "-",   "-",  "-",  "-",  "-", "W8W" },
            new List<string> { "W8C", "W8S","W8H", "W8D","W8H","W8S", "W8C" }
        },
        new List<List<string>>
        {
            new List<string> { "W8C", "W8N", "W8J","W8D","W8J","W8N","W8C" },
            new List<string> { "W8E", "-",   "-",  "-",  "-",  "-", "W8W" },
            new List<string> { "W8K",  "W8C",   "P3",  "-",  "P3",  "W8C", "W8K" },
            new List<string> { "W8d",  "-",   "-", "C","-",  "-", "W8d" },
            new List<string> { "W8H",  "W8C",   "P3",  "-",  "P3",  "W8C", "W8K" },
            new List<string> { "W8E",  "-",   "-",  "-",  "-",  "-", "W8W" },
            new List<string> { "W8C", "W8S","W8H", "W8D","W8H","W8S", "W8C" }
        },
       new List<List<string>>
        {
            new List<string> { "W8C", "W8N", "W8J","W8D","W8J","W8N","W8C" },
            new List<string> { "W8E", "-",   "-",  "-",  "-",  "-", "W8W" },
            new List<string> { "W8K",  "W8C",   "RUNE",  "-",  "-",  "W8C", "W8K" },
            new List<string> { "W8d",  "-",   "-", "B","-",  "-", "W8d" },
            new List<string> { "W8H",  "W8C",   "-",  "-",  "RUNE",  "W8C", "W8K" },
            new List<string> { "W8E",  "-",   "-",  "-",  "-",  "-", "W8W" },
            new List<string> { "W8C", "W8S","W8H", "W8D","W8H","W8S", "W8C" }
        },
       new List<List<string>>
        {
            new List<string> { "W8C", "W8N", "W8J","W8D","W8J","W8N","W8C" },
            new List<string> { "W8E", "W8C",   "RUNE",  "-",  "-",  "W8C", "W8W" },
            new List<string> { "W8K",  "W8N",   "W8C",  "-",  "C",  "-", "W8K" },
            new List<string> { "W8d",  "-",   "-", "-","RUNE",  "-", "W8d" },
            new List<string> { "W8H",  "RUNE",   "-",  "RUNE",  "W8C",  "W8S", "W8K" },
            new List<string> { "W8E",  "W8C",   "CS",  "-",  "-",  "W8W", "W8W" },
            new List<string> { "W8C", "W8S","W8H", "W8D","W8H","W8S", "W8C" }
        },
       new List<List<string>>
        {
            new List<string> { "W8C", "W8N", "W8J","W8D","W8J","W8N","W8C" },
            new List<string> { "W8E",  "-",   "-",  "-",  "-",  "-", "W8W" },
            new List<string> { "W8K",  "-",   "EVN",  "-",  "CRT",  "-", "W8K" },
            new List<string> { "W8d",  "-",   "-",  "TO2",  "-",  "-", "W8d" },
            new List<string> { "W8H",  "-",   "CRT",  "-",  "CR",  "-", "W8K" },
            new List<string> { "W8E",  "-",   "-",  "-",  "-",  "-", "W8W" },
            new List<string> { "W8C", "W8S","W8H", "W8D","W8H","W8S", "W8C" }
        },
       new List<List<string>>
        {
            new List<string> { "W8C", "W8N", "W8J","W8D","W8J","W8N","W8C" },
            new List<string> { "W8E",  "-",   "-",  "-",  "W1F",  "-", "W8W" },
            new List<string> { "W8K",  "-",   "RUNE",  "TO2",  "W1F",  "-", "W8K" },
            new List<string> { "W8d",  "-",   "B",  "EVN",  "RUNE",  "-", "W8d" },
            new List<string> { "W8H",  "-",   "-",  "RUNE",  "-",  "-", "W8K" },
            new List<string> { "W8E",  "CR",   "-",  "-",  "-",  "RUNE", "W8W" },
            new List<string> { "W8C", "W8S","W8H", "W8D","W8H","W8S", "W8C" }
        },
       new List<List<string>>
        {
            new List<string> { "W8C", "W8N", "W8J","W8D","W8J","W8N","W8C" },//TROLL ROOM DE FINALE
            new List<string> { "W8E",  "-",   "-",  "-",  "B",  "EVN", "W8W" },
            new List<string> { "W8K",  "-",   "-",  "-",  "TO3",  "W1F", "W8K" },
            new List<string> { "W8d",  "-",   "-",  "-",  "-",  "-", "W8d" },
            new List<string> { "W8H",  "W1F",   "TO3",  "-",  "-",  "-", "W8K" },
            new List<string> { "W8E",  "EVN",   "B",  "-",  "-",  "-", "W8W" },
            new List<string> { "W8C", "W8S","W8H", "W8D","W8H","W8S", "W8C" }
        },
       new List<List<string>>
        {
            new List<string> { "W8C", "W8N", "W8J","W8D","W8J","W8N","W8C" },
            new List<string> { "W8E",  "-",   "W8C",  "-",  "W8C",  "-", "W8W" },
            new List<string> { "W8K",  "W8C",   "B",  "-",  "-",  "W8C", "W8K" },
            new List<string> { "W8d",  "-",   "-",  "TO2",  "-",  "-", "W8d" },
            new List<string> { "W8H",  "W8C",   "RUNE",  "-",  "EVN",  "W8C", "W8K" },
            new List<string> { "W8E",  "-",   "W8C",  "-",  "W8C",  "-", "W8W" },
            new List<string> { "W8C", "W8S","W8H", "W8D","W8H","W8S", "W8C" }
        },
       new List<List<string>>
        {
            new List<string> { "W8C", "W8N", "W8J","W8D","W8J","W8N","W8C" },
            new List<string> { "W8E",  "EVN",   "W8C",  "-",  "B",  "-", "W8W" },
            new List<string> { "W8K",  "B",   "CR",  "-",  "W8C",  "-", "W8K" },
            new List<string> { "W8d",  "-",   "-",  "-",  "W1F",  "-", "W8d" },
            new List<string> { "W8H",  "-",   "W8C",  "W8C",  "W1F",  "W8C", "W8K" },
            new List<string> { "W8E",  "-",   "-",  "-",  "-",  "CS", "W8W" },
            new List<string> { "W8C", "W8S","W8H", "W8D","W8H","W8S", "W8C" }
        },
       new List<List<string>>
        {
            new List<string> { "W8C", "W8N", "W8J","W8D","W8J","W8N","W8C" },
            new List<string> { "W8E",  "-",   "-",  "-",  "-",  "-", "W8W" },
            new List<string> { "W8K",  "-",   "EVN",  "-",  "CRT",  "-", "W8K" },
            new List<string> { "W8d",  "-",   "-",  "TO2",  "-",  "-", "W8d" },
            new List<string> { "W8H",  "-",   "CRT",  "-",  "CR",  "-", "W8K" },
            new List<string> { "W8E",  "-",   "-",  "-",  "-",  "-", "W8W" },
            new List<string> { "W8C", "W8S","W8H", "W8D","W8H","W8S", "W8C" }
        },
       new List<List<string>>
        {
            new List<string> { "W8C", "W8N", "W8J","W8D","W8J","W8N","W8C" },
            new List<string> { "W8E",  "-",   "-",  "-",  "-",  "-", "W8W" },
            new List<string> { "W8K",  "TO3",   "W1F",  "-",  "W1F",  "W1F", "W8K" },
            new List<string> { "W8d",  "-",   "-",  "-",  "-",  "-", "W8d" },
            new List<string> { "W8H",  "W1F",   "W1F",  "-",  "TO3",  "W1F", "W8K" },
            new List<string> { "W8E",  "-",   "-",  "-",  "-",  "-", "W8W" },
            new List<string> { "W8C", "W8S","W8H", "W8D","W8H","W8S", "W8C" }
        },
       new List<List<string>>
        {
            new List<string> { "W8C", "W8N", "W8J","W8D","W8J","W8N","W8C" },
            new List<string> { "W8E",  "-",   "-",  "B",  "-",  "-", "W8W" },
            new List<string> { "W8K",  "-",   "W1F",  "-",  "W1F",  "-", "W8K" },
            new List<string> { "W8d",  "-",   "-",  "RUNE",  "-",  "-", "W8d" },
            new List<string> { "W8H",  "-",   "W1F",  "-",  "W1F",  "-", "W8K" },
            new List<string> { "W8E",  "-",   "-",  "CR",  "-",  "-", "W8W" },
            new List<string> { "W8C", "W8S","W8H", "W8D","W8H","W8S", "W8C" }
        },
        new List<List<string>>
        {
            new List<string> { "W8C", "W8N", "W8J","W8D","W8J","W8N","W8C" },
            new List<string> { "W8E",  "-",   "-",  "B",  "-",  "-", "W8W" },
            new List<string> { "W8K",  "-",   "W1F",  "-",  "W1F",  "-", "W8K" },
            new List<string> { "W8d",  "-",   "-",  "RUNE",  "-",  "-", "W8d" },
            new List<string> { "W8H",  "-",   "W1F",  "-",  "W1F",  "-", "W8K" },
            new List<string> { "W8E",  "-",   "-",  "EVN",  "-",  "-", "W8W" },
            new List<string> { "W8C", "W8S","W8H", "W8D","W8H","W8S", "W8C" }
        },
       new List<List<string>>
        {
            new List<string> { "W8C", "W8N", "W8J","W8D","W8J","W8N","W8C" },
            new List<string> { "W8E",  "CRT",   "-",  "-",  "-",  "-", "W8W" },
            new List<string> { "W8K",  "-",   "W8P",  "-",  "W8P",  "-", "W8K" },
            new List<string> { "W8d",  "-",   "-",  "B",  "-",  "-", "W8d" },
            new List<string> { "W8H",  "-",   "W8P",  "-",  "W8P",  "-", "W8K" },
            new List<string> { "W8E",  "-",   "-",  "-",  "-",  "CRT", "W8W" },
            new List<string> { "W8C", "W8S","W8H", "W8D","W8H","W8S", "W8C" }
        },
       new List<List<string>>
        {
            new List<string> { "W8C", "W8N", "W8J","W8D","W8J","W8N","W8C" },
            new List<string> { "W8E",  "CRT",   "-",  "-",  "P3",  "-", "W8W" },
            new List<string> { "W8K",  "-",   "CRT",  "-",  "TO2",  "P2", "W8K" },
            new List<string> { "W8d",  "-",   "TO2",  "EVN",  "-",  "-", "W8d" },
            new List<string> { "W8H",  "-",   "CRT",  "CRT",  "W8P",  "-", "W8K" },
            new List<string> { "W8E",  "-",   "-",  "-",  "-",  "-", "W8W" },
            new List<string> { "W8C", "W8S","W8H", "W8D","W8H","W8S", "W8C" }
        },
       new List<List<string>>
        {
            new List<string> { "W8C", "W8N", "W8J","W8D","W8J","W8N","W8C" },
            new List<string> { "W8E",  "B",   "-",  "-",  "-",  "EVN", "W8W" },
            new List<string> { "W8K",  "-",   "CRT",  "-",  "CRT",  "-", "W8K" },
            new List<string> { "W8d",  "-",   "-",  "W8C",  "-",  "-", "W8d" },
            new List<string> { "W8H",  "-",   "CRT",  "-",  "CRT",  "-", "W8K" },
            new List<string> { "W8E",  "CS",   "-",  "-",  "-",  "B", "W8W" },
            new List<string> { "W8C", "W8S","W8H", "W8D","W8H","W8S", "W8C" }
        },
       new List<List<string>>
        {
            new List<string> { "W8C", "W8N", "W8J","W8D","W8J","W8N","W8C" },
            new List<string> { "W8E",  "EVN",   "B",  "-",  "-",  "-", "W8W" },
            new List<string> { "W8K",  "W8C",   "-",  "-",  "-",  "W8C", "W8K" },
            new List<string> { "W8d",  "-",   "-",  "RUNE",  "-",  "-", "W8d" },
            new List<string> { "W8H",  "W8C",   "-",  "-",  "-",  "W8C", "W8K" },
            new List<string> { "W8E",  "-",   "-",  "-",  "-",  "CR", "W8W" },
            new List<string> { "W8C", "W8S","W8H", "W8D","W8H","W8S", "W8C" }
        },
       new List<List<string>>
        {
            new List<string> { "W8C", "W8N", "W8J","W8D","W8J","W8N","W8C" },
            new List<string> { "W8E",  "-",   "-",  "B",  "-",  "-", "W8W" },
            new List<string> { "W8K",  "-",   "-",  "CRT",  "-",  "-", "W8K" },
            new List<string> { "W8d",  "-",   "P3", "EVN","P3",  "-", "W8d" },
            new List<string> { "W8H",  "-",   "-",  "B",  "-",  "-", "W8K" },
            new List<string> { "W8E",  "-",   "-",  "-",  "TO3",  "-", "W8W" },
            new List<string> { "W8C", "W8S","W8H", "W8D","W8H","W8S", "W8C" }
        },
       new List<List<string>>
        {
            new List<string> { "W8C", "W8N", "W8J","W8D","W8J","W8N","W8C" },
            new List<string> { "W8E",  "TO2",   "-",  "-",  "-",  "-", "W8W" },
            new List<string> { "W8K",  "-",   "-",  "-",  "RUNE",  "-", "W8K" },
            new List<string> { "W8d",  "-",   "-",  "-",  "-",  "-", "W8d" },
            new List<string> { "W8H",  "CRT",   "CRT",  "CRT",  "CRT",  "-", "W8K" },
            new List<string> { "W8E",  "EVN",   "-",  "-",  "B",  "-", "W8W" },
            new List<string> { "W8C", "W8S","W8H", "W8D","W8H","W8S", "W8C" }
        },
       new List<List<string>>
        {
            new List<string> { "W8C", "W8N", "W8J","W8D","W8J","W8N","W8C" },
            new List<string> { "W8E",  "-",   "TO2",  "-",  "TO2",  "P3", "W8W" },
            new List<string> { "W8K",  "RUNE",   "CRT",  "-",  "CRT",  "RUNE", "W8K" },
            new List<string> { "W8d",  "-",   "-",  "-",  "B",  "-", "W8d" },
            new List<string> { "W8H",  "RUNE",   "CRT",  "-",  "CRT",  "RUNE", "W8K" },
            new List<string> { "W8E",  "P3",   "TO2",  "-",  "TO2",  "-", "W8W" },
            new List<string> { "W8C", "W8S","W8H", "W8D","W8H","W8S", "W8C" }
        },
       new List<List<string>>
        {
            new List<string> { "W8C", "W8N", "W8J","W8D","W8J","W8N","W8C" },
            new List<string> { "W8E",  "RUNE",   "W1F",  "-",  "W1F",  "-", "W8W" },
            new List<string> { "W8K",  "W1F",   "TO3",  "-",  "W1F",  "W1F", "W8K" },
            new List<string> { "W8d",  "-",   "-",  "EVN",  "-",  "-", "W8d" },
            new List<string> { "W8H",  "TO3",   "W1F",  "-",  "W1F",  "W1F", "W8K" },
            new List<string> { "W8E",  "-",   "W1F",  "-",  "TO3",  "RUNE", "W8W" },
            new List<string> { "W8C", "W8S","W8H", "W8D","W8H","W8S", "W8C" }
        },
       new List<List<string>>
        {
            new List<string> { "W8C", "W8N", "W8J","W8D","W8J","W8N","W8C" },
            new List<string> { "W8E",  "RUNE",   "-",  "-",  "-",  "RUNE", "W8W" },
            new List<string> { "W8K",  "-",   "-",  "-",  "-",  "-", "W8K" },
            new List<string> { "W8d",  "-",   "-",  "TO3",  "-",  "-", "W8d" },
            new List<string> { "W8H",  "-",   "-",  "-",  "-",  "-", "W8K" },
            new List<string> { "W8E",  "RUNE",   "-",  "-",  "-",  "RUNE", "W8W" },
            new List<string> { "W8C", "W8S","W8H", "W8D","W8H","W8S", "W8C" }
        },
       new List<List<string>>
        {
            new List<string> { "W8C", "W8N", "W8J","WgD","W8J","W8N","W8C" },
            new List<string> { "W8E",  "-",   "-",  "-",  "-",  "B", "W8W" },
            new List<string> { "W8K",  "-",   "W1F",  "-",  "W1F",  "-", "W8K" },
            new List<string> { "W5d",  "-",   "-",  "TO3",  "-",  "-", "W5Sd" },
            new List<string> { "W8H",  "-",   "W1F",  "-",  "W1F",  "-", "W8K" },
            new List<string> { "W8E",  "CR",   "-",  "-",  "-",  "-", "W8W" },
            new List<string> { "W8C", "W8S","W8H", "WgD","W8H","W8S", "W8C" }
        },
       new List<List<string>>
        {
            new List<string> { "W8C", "W8N", "W8J","WgD","W8J","W8N","W8C" },
            new List<string> { "W8E",  "-",   "-",  "-",  "-",  "-", "W8W" },
            new List<string> { "W8K",  "-",   "W1F",  "W1F",  "W1F",  "-", "W8K" },
            new List<string> { "W5d",  "-",   "E",  "TO3",  "CC",  "-", "W5Sd" },
            new List<string> { "W8H",  "-",   "W1F",  "W1F",  "W1F",  "-", "W8K" },
            new List<string> { "W8E",  "-",   "-",  "-",  "-",  "-", "W8W" },
            new List<string> { "W8C", "W8S","W8H", "WgD","W8H","W8S", "W8C" }
        },
       new List<List<string>>
        {
            new List<string> { "W8C", "W8N", "W8J","W8D","W8J","W8N","W8C" },
            new List<string> { "W8E",  "RUNE",   "-",  "-",  "-",  "RUNE", "W8W" },
            new List<string> { "W8K",  "CS",   "RUNE",  "-",  "RUNE",  "-", "W8K" },
            new List<string> { "W8d",  "-",   "-",  "B",  "-",  "-", "W8d" },
            new List<string> { "W8H",  "-",   "RUNE",  "-",  "RUNE",  "-", "W8K" },
            new List<string> { "W8E",  "RUNE",   "-",  "-",  "EVN",  "RUNE", "W8W" },
            new List<string> { "W8C", "W8S","W8H", "W8D","W8H","W8S", "W8C" }
        },
       new List<List<string>>
        {
            new List<string> { "W8C", "W8N", "W8J","W8D","W8J","W8N","W8C" },
            new List<string> { "W8E",  "EVN",   "-",  "-",  "TO2",  "TO2", "W8W" },
            new List<string> { "W8K",  "TO2",   "TO2",  "-",  "B",  "TO2", "W8K" },
            new List<string> { "W8d",  "-",   "-",  "TO2",  "-",  "-", "W8d" },
            new List<string> { "W8H",  "TO2",   "-",  "TO2",  "-",  "TO2", "W8K" },
            new List<string> { "W8E",  "CR",   "-",  "-",  "-",  "CS", "W8W" },
            new List<string> { "W8C", "W8S","W8H", "W8D","W8H","W8S", "W8C" }
        },
       new List<List<string>>
        {
            new List<string> { "W8C", "W8N", "W8J","W8D","W8J","W8N","W8C" },
            new List<string> { "W8E",  "-",   "-",  "-",  "-",  "-", "W8W" },
            new List<string> { "W8K",  "-",   "-",  "W8P",  "CS",  "-", "W8K" },
            new List<string> { "W8d",  "-",   "W8P",  "W8C",  "W8P",  "-", "W8d" },
            new List<string> { "W8H",  "-",   "CR",  "W8P",  "-",  "-", "W8K" },
            new List<string> { "W8E",  "-",   "-",  "-",  "-",  "-", "W8W" },
            new List<string> { "W8C", "W8S","W8H", "W8D","W8H","W8S", "W8C" }
        },
       new List<List<string>>
        {
            new List<string> { "W8C", "W8N", "W8J","W8D","W8J","W8N","W8C" },
            new List<string> { "W8E",  "-",   "-",  "B",  "-",  "-", "W8W" },
            new List<string> { "W8K",  "-",   "P3",  "EVN",  "P3",  "-", "W8K" },
            new List<string> { "W8d",  "-",   "P3",  "P3",  "P3",  "-", "W8d" },
            new List<string> { "W8H",  "-",   "-",  "-",  "-",  "-", "W8K" },
            new List<string> { "W8E",  "-",   "P3",  "CR",  "P3",  "-", "W8W" },
            new List<string> { "W8C", "W8S","W8H", "W8D","W8H","W8S", "W8C" }
        },
       new List<List<string>>
        {
            new List<string> { "W8C", "W8N", "W8J","W8D","W8J","W8N","W8C" },
            new List<string> { "W8E",  "TO2",   "-",  "-",  "-",  "-", "W8W" },
            new List<string> { "W8K",  "-",   "-",  "-",  "TO2",  "-", "W8K" },
            new List<string> { "W8d",  "-",   "-",  "EVN",  "-",  "-", "W8d" },
            new List<string> { "W8H",  "-",   "-",  "-",  "-",  "RUNE", "W8K" },
            new List<string> { "W8E",  "-",   "TO2",  "-",  "-",  "-", "W8W" },
            new List<string> { "W8C", "W8S","W8H", "W8D","W8H","W8S", "W8C" }
        },
       new List<List<string>>
        {
            new List<string> { "W8C", "W8N", "W8J","W8D","W8J","W8N","W8C" },
            new List<string> { "W8E",  "P3",   "CRT",  "-",  "CRT",  "P3", "W8W" },
            new List<string> { "W8K",  "CRT",   "CRT",  "-",  "CRT",  "CRT", "W8K" },
            new List<string> { "W8d",  "-",   "CRT",  "-",  "-",  "-", "W8d" },
            new List<string> { "W8H",  "CR",   "-",  "-",  "CRT",  "CRT", "W8K" },
            new List<string> { "W8E",  "P3",   "CS",  "-",  "CRT",  "P3", "W8W" },
            new List<string> { "W8C", "W8S","W8H", "W8D","W8H","W8S", "W8C" }
        },
        };

        public static List<List<List<string>>> VoidPuzzleRooms = new List<List<List<string>>>
        {
        new List<List<string>>
            {
                new List<string> { "W8C", "W8N", "W8J","W8N","W8J","W8N","W8C" },
                new List<string> { "W8E", "-", "-", "-", "-", "-", "W8W" },
                new List<string> { "W8K", "-", "TO2", "-", "-", "-", "W8K" },
                new List<string> { "W8d", "-", "-", "T22", "-", "-", "W8d" },
                new List<string> { "W8H", "-", "-", "-", "CRT", "-", "W8K" },
                new List<string> { "W8E", "-", "-", "-", "-", "-", "W8W" },
                new List<string> { "W8C", "W8S", "W8H", "W8D", "W8H", "W8S", "W8C" }
            },
        new List<List<string>>
        {
            new List<string> { "W8C", "W8N", "W8J","W8D","W8J","W8N","W8C" },
            new List<string> { "W8E", "-",   "-",  "-",  "-",  "-", "W8W" },
            new List<string> { "W8K",  "W8C",   "RUNEH",  "-",  "TO2",  "W8C", "W8K" },
            new List<string> { "W8d",  "-",   "-", "C","-",  "-", "W8d" },
            new List<string> { "W8H",  "W8C",   "CRT",  "-",  "RUNE",  "W8C", "W8K" },
            new List<string> { "W8E",  "-",   "-",  "-",  "-",  "-", "W8W" },
            new List<string> { "W8C", "W8S","W8H", "W8D","W8H","W8S", "W8C" }
        },
       new List<List<string>>
        {
            new List<string> { "W8C", "W8N", "W8J","W8D","W8J","W8N","W8C" },
            new List<string> { "W8E", "-",   "-",  "-",  "-",  "CR", "W8W" },
            new List<string> { "W8K",  "-",   "-",  "P2",  "-",  "W8C", "W8K" },
            new List<string> { "W8d",  "-",   "TO2", "RUNEH","-",  "-", "W8d" },
            new List<string> { "W8H",  "-",   "-",  "P3",  "-",  "W8C", "W8K" },
            new List<string> { "W8E",  "-",   "-",  "-",  "-",  "-", "W8W" },
            new List<string> { "W8C", "W8S","W8H", "W8D","W8H","W8S", "W8C" }
        },
       new List<List<string>>
        {
            new List<string> { "W8C", "W8N", "W8J","W8D","W8J","W8N","W8C" },
            new List<string> { "W8E", "-",   "RUNE",  "-",  "-",  "P2", "W8W" },
            new List<string> { "W8K",  "RUNE",   "-",  "-",  "-",  "-", "W8K" },
            new List<string> { "W8d",  "-",   "-", "-", "RUNEH",  "-", "W8d" },
            new List<string> { "W8H",  "-",   "RUNE",  "-",  "-",  "TO2", "W8K" },
            new List<string> { "W8E",  "EVN",   "-",  "-",  "RUNE",  "-", "W8W" },
            new List<string> { "W8C", "W8S","W8H", "W8D","W8H","W8S", "W8C" }
        },
       new List<List<string>>
        {
            new List<string> { "W8C", "W8N", "W8J","W8D","W8J","W8N","W8C" },
            new List<string> { "W8E",  "-",   "-",  "B",  "-",  "-", "W8W" },
            new List<string> { "W8K",  "-",   "W1F",  "-",  "W1F",  "-", "W8K" },
            new List<string> { "W8d",  "-",   "-",  "RUNEH",  "-",  "-", "W8d" },
            new List<string> { "W8H",  "-",   "W1F",  "-",  "W1F",  "-", "W8K" },
            new List<string> { "W8E",  "-",   "-",  "EVN",  "-",  "-", "W8W" },
            new List<string> { "W8C", "W8S","W8H", "W8D","W8H","W8S", "W8C" }
        },
        new List<List<string>>
        {
            new List<string> { "W8C", "W8N", "W8J","W8D","W8J","W8N","W8C" },
            new List<string> { "W8E",  "TO2",   "-",  "-",  "-",  "-", "W8W" },
            new List<string> { "W8K",  "-",   "-",  "-",  "RUNEH",  "-", "W8K" },
            new List<string> { "W8d",  "-",   "-",  "-",  "-",  "-", "W8d" },
            new List<string> { "W8H",  "CRT",   "CRT",  "CRT",  "CRT",  "-", "W8K" },
            new List<string> { "W8E",  "EVN",   "-",  "-",  "-",  "-", "W8W" },
            new List<string> { "W8C", "W8S","W8H", "W8D","W8H","W8S", "W8C" }
        },
         new List<List<string>>
        {
            new List<string> { "W8C", "W8N", "W8J","W8D","W8J","W8N","W8C" },
            new List<string> { "W8E",  "-",   "W1F",  "-",  "W1F", "RUNEH", "W8W" },
            new List<string> { "W8K",  "W1F",   "TO3",  "-",  "W1F",  "W1F", "W8K" },
            new List<string> { "W8d",  "-",   "-",  "CR",  "-",  "-", "W8d" },
            new List<string> { "W8H",  "TO2",   "W1F",  "-",  "W1F",  "W1F", "W8K" },
            new List<string> { "W8E",  "RUNE",   "W1F",  "-",  "TO3",  "-", "W8W" },
            new List<string> { "W8C", "W8S","W8H", "W8D","W8H","W8S", "W8C" }
        },
          new List<List<string>>
        {
            new List<string> { "W8C", "W8N", "W8J","W8D","W8J","W8N","W8C" },
            new List<string> { "W8E",  "RUNE",   "-",  "-",  "-",  "RUNEH", "W8W" },
            new List<string> { "W8K",  "-",   "-",  "-",  "-",  "-", "W8K" },
            new List<string> { "W8d",  "-",   "-",  "TO3",  "-",  "-", "W8d" },
            new List<string> { "W8H",  "-",   "-",  "-",  "-",  "-", "W8K" },
            new List<string> { "W8E",  "RUNE",   "-",  "-",  "-",  "RUNE", "W8W" },
            new List<string> { "W8C", "W8S","W8H", "W8D","W8H","W8S", "W8C" }
        },
          new List<List<string>>
        {
            new List<string> { "W8C", "W8N", "W8J","W8D","W8J","W8N","W8C" },
            new List<string> { "W8E",  "RUNE",   "-",  "-",  "-",  "RUNE", "W8W" },
            new List<string> { "W8K",  "CS",   "RUNE",  "-",  "RUNEH",  "-", "W8K" },
            new List<string> { "W8d",  "-",   "-",  "B",  "-",  "-", "W8d" },
            new List<string> { "W8H",  "-",   "RUNE",  "-",  "RUNE",  "-", "W8K" },
            new List<string> { "W8E",  "RUNE",   "-",  "-",  "EVN",  "RUNE", "W8W" },
            new List<string> { "W8C", "W8S","W8H", "W8D","W8H","W8S", "W8C" }
        },
        };


        public static List<List<string>> generateMapId(string room)
        {
            string ids = "";
            List<List<string>> id2 = new List<List<string>>
            {
                new List<string>()
            };
            string lastChar = "null";
            switch (room)
            {
                case "goobert":
                    int limit = Random.Range(-1, 1);
                    for (int y = 0; y < 5 + limit; y++)
                    {
                        for (int x = 0; x < 5 + Random.Range(-1, 1); x++)
                        {
                            if (lastChar == "/" && Random.Range(0, 100) > 75)
                            {
                                lastChar = "-";
                                id2[y].Add("-");
                                continue;
                            } else if (lastChar != "-" && Random.Range(0, 100) > 85 && y > 1 && y < (5 + limit) - 1)
                            {
                                lastChar = "-";
                                id2[y].Add("-");
                                continue;
                            }
                            int room2add = Random.Range(1, GooRooms.Count);
                            while (room2add.ToString() == lastChar)
                            {
                                room2add = Random.Range(1, GooRooms.Count);
                            }
                            lastChar = room2add.ToString();
                            string room2add2 = room2add.ToString();
                            if (Random.RandomRangeInt(0, 100) > 82)
                            {
                                room2add2 += "bl";
                            }
                            id2[y].Add(room2add2);
                        }
                        if (y != 5 + limit - 1)
                        {
                            id2.Add(new List<string>());
                        }
                    }
                    break;
                case "espeara":
                    limit = Random.Range(-1, 1);
                    for (int y = 0; y < 5 + limit; y++)
                    {
                        for (int x = 0; x < 5 + Random.Range(-1, 2); x++)
                        {
                            if (lastChar == "/" && Random.Range(0, 100) > 75)
                            {
                                lastChar = "-";
                                id2[y].Add("-");
                                continue;
                            }
                            else if (lastChar != "-" && Random.Range(0, 100) > 85 && y > 1 && y < (5 + limit) - 1)
                            {
                                lastChar = "-";
                                id2[y].Add("-");
                                continue;
                            }
                            int room2add = Random.Range(1, LavaRooms.Count);
                            while (room2add.ToString() == lastChar)
                            {
                                room2add = Random.Range(1, LavaRooms.Count);
                            }
                            lastChar = room2add.ToString();
                            string room2add2 = room2add.ToString();
                            if (Random.RandomRangeInt(0, 100) > 75)
                            {
                                room2add2 += "bl";
                            }
                            id2[y].Add(room2add2);
                        }
                        if (y != 5 + limit - 1)
                        {
                            id2.Add(new List<string>());
                        }
                    }
                    break;
                case "lonely":
                    limit = Random.Range(-1, 1);
                    for (int y = 0; y < 6 + limit; y++)
                    {
                        for (int x = 0; x < 5 + Random.Range(-1, 2); x++)
                        {
                            if (lastChar == "/" && Random.Range(0, 100) > 75)
                            {
                                lastChar = "-";
                                id2[y].Add("-");
                                continue;
                            }
                            else if (lastChar != "-" && Random.Range(0, 100) > 85 && y > 1 && y < (6 + limit) - 1)
                            {
                                lastChar = "-";
                                id2[y].Add("-");
                                continue;
                            }
                            int room2add = Random.Range(1, VoidRooms.Count);
                            while (room2add.ToString() == lastChar)
                            {
                                room2add = Random.Range(1, VoidRooms.Count);
                            }
                            lastChar = room2add.ToString();
                            string room2add2 = room2add.ToString();
                            if (Random.RandomRangeInt(0, 100) > 75)
                            {
                                room2add2 += "bl";
                            }
                            id2[y].Add(room2add2);
                        }
                        if (y != 6 + limit - 1)
                        {
                            id2.Add(new List<string>());
                        }
                    }
                    break;
            }

            if (Random.Range(0, 100) > 51)//make spawn (also messy)
            {
                List<string> lastRow = id2[id2.Count - 1];
                if (lastRow[lastRow.Count - 1] != "-")
                {
                    id2[id2.Count - 1].Add("0");
                }
                else
                {
                    id2[id2.Count - 1][id2[id2.Count - 1].Count - 1] = "0";
                }
            } else
            {
                List<string> lastRow = id2[id2.Count - 1];
                int spawnLoc = Random.Range(0, lastRow.Count);
                if (room == "espeara")
                {
                    spawnLoc = lastRow.Count - 1;
                }
                if (id2[id2.Count - 1][spawnLoc] != "-")
                {
                    int lastestRow = id2.Count;
                    id2.Add(new List<string>());
                    for (int i = 0; i < lastRow.Count; i++)
                    {
                        if (i != spawnLoc)
                        {
                            id2[lastestRow].Add("-");
                        } else
                        {
                            id2[lastestRow].Add("0");
                        }
                    }
                } else
                {
                    id2[id2.Count - 1][spawnLoc] = "0";
                }
            }

            if (Random.Range(0, 100) > 51)//append shop (not that messy ( i think ))
            {
                List<string> shopRow = id2[id2.Count - 2];
                int randomThing = Random.RandomRangeInt(0, shopRow.Count);
                id2[id2.Count - 2][randomThing] = "s";
            }
            else
            {
                List<string> shopRow = id2[id2.Count - 2];
                if (shopRow[shopRow.Count - 1] == "-") 
                {
                    shopRow[shopRow.Count - 1] = "s";
                } 
                else 
                {
                    shopRow.Add("s");
                }
            }

            bool hasEdaxio = false;

            if (room == "espeara")
            {
                foreach(CardInfo card in RunState.Run.playerDeck.Cards)
                {
                    if (card.name == "mag_edaxiolegs")
                    {
                        hasEdaxio = true;
                    }
                }
            }
            if (room == "lonely")
            {
                foreach (CardInfo card in RunState.Run.playerDeck.Cards)
                {
                    if (card.name == "mag_edaxiotorso")
                    {
                        hasEdaxio = true;
                    }
                }
            }

            if (room == "goobert" && SavedVars.LearnedMechanics.Contains("died") && !SaveManager.saveFile.ascensionActive || room == "espeara" && hasEdaxio || room == "lonely" && hasEdaxio)//add edaxio
            {
                int row = Random.RandomRangeInt(0, id2.Count - 1);
                List<string> edaxioRow = id2[row];
                if( edaxioRow[edaxioRow.Count - 1] == "-")
                {
                    id2[row][edaxioRow.Count - 1] = "e";
                } else
                {
                    id2[row].Add("e");
                }
            }

            List<string> firstRow = id2[0];//make boss room (not messy)
            List<string> newRow = new List<string>();
            int theBoss = Random.RandomRangeInt(1, firstRow.Count);
            while (firstRow[theBoss] == "-" || firstRow[theBoss] == "e")
            {
                theBoss = Random.RandomRangeInt(1, firstRow.Count);
            }
            if (room == "goobert")
            {
                for (int i = 0; i < firstRow.Count; i++)
                {
                    if (i != theBoss)
                    {
                        newRow.Add("-");
                    }
                    else
                    {
                        newRow.Add("b");
                    }
                }
                id2.Insert(0, newRow);
            } else
            {
                for (int i = 0; i < 3; i ++)
                {
                    //int room2add = Random.Range(1, GooRooms.Count);
                    int replaceY = Random.RandomRangeInt(0, id2.Count);
                    int replaceX = Random.RandomRangeInt(0, id2[replaceY].Count);
                    while (id2[replaceY][replaceX] == "s" || id2[replaceY][replaceX] == "e" || id2[replaceY][replaceX] == "0" || id2[replaceY][replaceX].Contains("p"))
                    {
                        replaceX = Random.RandomRangeInt(0, id2[replaceY].Count);
                    }
                    int room2replace = Random.Range(1, LavaPuzzleRooms.Count);
                    id2[replaceY][replaceX] = "p" + room2replace.ToString();
                }
                for (int i = 0; i < firstRow.Count; i++)
                {
                    if (i != theBoss)
                    {
                        newRow.Add("-");
                    }
                    else
                    {
                        int[] gemSolution = new int[] { Random.RandomRangeInt(0, 12), Random.RandomRangeInt(0, 12), Random.RandomRangeInt(0, 12) };
                        SavedVars.BossTeleportSolution = gemSolution;
                        newRow.Add("p0");
                    }
                }
                id2.Insert(0, newRow);
                newRow = new List<string>();
                for (int i = 0; i < firstRow.Count; i++)
                {
                    if (i != theBoss)
                    {
                        newRow.Add("-");
                    }
                    else
                    {
                        newRow.Add("b");
                    }
                }
                id2.Insert(0, newRow);
            }

            foreach (List<string> strings in id2)
            {
                string strings2 = "";
                foreach(string stringa in strings)
                {
                    strings2 += stringa;
                    strings2 += ",";
                }
            }

            List<List<List<string>>> RoomT = GooRooms;
            if (room == "espeara")
            {
                RoomT = LavaRooms;
            }
            else if (room == "lonely")
            {
                RoomT = VoidRooms;
            }

            if (id2[id2.Count - 2].IndexOf("-") > 0)
            {
                id2[id2.Count - 2][id2[id2.Count - 2].IndexOf("-")] = Random.Range(1, RoomT.Count).ToString();
            }

            for (int y = 0; y < id2.Count; y++)//check for unreachables (messy af)
            {
                int loc = 0;
                if (y == 0)
                {
                    loc = 1;
                } else if (y == id2.Count - 1)
                {
                    loc = 2;
                }
                for (int x = 0; x < id2[y].Count; x++)
                {
                    bool unreachableH = false;
                    bool unreachable = false;
                    if (id2[y][x] != "-" && x == id2[y].Count - 1)//at the edge of the map
                    {
                        if (id2[y][x - 1] == "-")//is unreachable from that x pos
                        {
                            unreachableH = true;
                        }
                    } else if (id2[y][x] != "-" && x == 0)//at the start of the map
                    {
                        if (id2[y][x + 1] == "-")
                        {
                            unreachableH = true;
                        }
                    } else if (id2[y][x] != "-")//just chillin
                    {
                        if (id2[y][x + 1] == "-" && id2[y][x - 1] == "-")
                        {
                            unreachableH = true;
                        }
                    }

                    if (unreachableH)
                    {
                        if (loc == 0 && id2[y - 1].Count > x && id2[y - 1][x] == "-" || loc == 0 && id2[y - 1].Count < x)//if room north of this doesnt exist
                        {
                            if (loc == 0 && id2[y + 1].Count > x && id2[y + 1][x] == "-" || loc == 0 && id2[y + 1].Count < x)//if room south of this doesnt exist
                            {
                                unreachable = true;
                            }
                        }

                        if (loc == 1 && id2[y + 1].Count > x && id2[y + 1][x] == "-" || loc == 1 && id2[y + 1].Count < x)//room is at top and south is not real
                        {
                            unreachable = true;
                        }
                        else if (loc == 2 && id2[y - 1].Count > x && id2[y - 1][x] == "-" || loc == 2 && id2[y - 1].Count < x)//room is at bottom and north is not real
                        {
                            unreachable = true;
                        }
                    }

                    if (unreachable)
                    {
                        if (loc == 1 && id2[y + 1].Count > x && id2[y + 1][x] == "-")//check if south exists
                        {
                            id2[y + 1][x] = Random.Range(1, RoomT.Count).ToString();
                        } else if (loc == 1 && id2[y].Count > x)//check right
                        {
                            id2[y][x + 1] = Random.Range(1, RoomT.Count).ToString();
                        } else if (loc == 1)//check left
                        {
                            id2[y][x - 1] = Random.Range(1, RoomT.Count).ToString();
                        }

                        if (loc == 2 && id2[y - 1].Count > x && id2[y - 1][x] == "-")//check if north exists
                        {
                            id2[y - 1][x] = Random.Range(1, RoomT.Count).ToString();
                        }
                        else if (loc == 2 && id2[y].Count > x)
                        {
                            id2[y][x + 1] = Random.Range(1, RoomT.Count).ToString();
                        }
                        else if (loc == 2)
                        {
                            id2[y][x - 1] = Random.Range(1, RoomT.Count).ToString();
                        }

                        if (loc == 0 && id2[y - 1].Count > x && id2[y - 1][x] == "-")//check all
                        {
                            id2[y - 1][x] = Random.Range(1, RoomT.Count).ToString();
                        } else if (loc == 0 && id2[y + 1].Count > x && id2[y + 1][x] == "-")
                        {
                            id2[y + 1][x] = Random.Range(1, RoomT.Count).ToString();
                        }
                        else if (loc == 0 && id2[y].Count > x)
                        {
                            id2[y][x + 1] = Random.Range(1, RoomT.Count).ToString();
                        }
                        else if (loc == 0)
                        {
                            id2[y][x - 1] = Random.Range(1, RoomT.Count).ToString();
                        }
                    }
                }
            }
          
            for (int y = 0; y < id2.Count; y++)//generate id(finally)
            {
                for (int x = 0; x < id2[y].Count; x++)
                {
                    ids += id2[y][x] + ",";
                }
                if (y != id2.Count - 1)
                {
                    ids += "/";
                }
            }

            MagnificusMod.MagCurrentNode.SaveLayout(ids);
            return id2;
        }

        public static List<List<string>> generateMap(List<List<string>> ids, string region)
        {
            List<List<string>> map = new List<List<string>>();
            for (int i = 0; i < ids.Count * 7; i++)//create vertical dimensions
            {
                map.Add(new List<string>());
            }

            List<List<List<string>>> rooms = new List<List<List<string>>>();

            List<List<string>> bossRoom = new List<List<string>>();

            switch (region)//what rooms to use
            {
                case "goobert":
                    rooms = GooRooms;
                    bossRoom = b1;
                    break;
                case "espeara":
                    rooms = LavaRooms;
                    bossRoom = b2;
                    break;
                case "lonely":
                    rooms = VoidRooms;
                    bossRoom = b3;
                    break;
            }

            List<List<int>> blockedByBattle = new List<List<int>>();

            int group = 0;
        
            for (int i = 0; i < ids.Count; i ++)
            {
                for (int x = 0; x < ids[i].Count; x++)
                {
                    List<List<string>> room = new List<List<string>>();//get room
                    if (ids[i][x] == "-")
                    {
                        room = empty;
                    }
                    else if (ids[i][x] == "s")
                    {
                        room = shop[RunState.Run.regionTier - 1];
                    }
                    else if (ids[i][x].Contains("p"))
                    {
                        string[] roomide = ids[i][x].Split('p');
                        int puzzleId = int.Parse(roomide[1]);
                        room = LavaPuzzleRooms[puzzleId];
                        if (region == "lonely")
                        {
                            room = VoidPuzzleRooms[puzzleId];
                        }
                    }
                    else if (ids[i][x] == "b")
                    {
                        room = bossRoom;
                    } else if (ids[i][x] == "e")
                    {
                        if (region == "goobert")
                        {
                            room = EdaxioRooms[0];
                        } else if (region == "espeara")
                        {
                            room = EdaxioRooms[1];
                        }
                        else if (region == "lonely")
                        {
                            room = EdaxioRooms[2];
                        }
                    }
                    else
                    {
                        if (ids[i][x] != "")
                        {
                            string thinglol = ids[i][x];
                            List<List<string>> roomlol = new List<List<string>>();
                            bool bl = false;
                            if (thinglol.Contains("bl"))
                            {
                                group++;
                                blockedByBattle.Add(new List<int> { i, x, group });
                                string[] tes = thinglol.Split('b');
                                thinglol = tes[0];
                                bl = true;
                            }

                            foreach(List<string> monRovia in rooms[int.Parse(thinglol)])
                            {
                                roomlol.Add(monRovia);
                            }

                            if (bl)//room blocked by battle (Messy!!!)
                            {
                                for (int y = 0; y < roomlol.Count; y++)
                                {
                                    for (int xD = 0; xD < roomlol[y].Count; xD++)
                                    {
                                        if (roomlol[y][xD].ToLower().Contains("d"))
                                        {
                                            string newRoom = "";
                                            for (int el = 0; el <2;el ++)
                                            {
                                                newRoom += roomlol[y][xD][el];
                                            }
                                            if (roomlol[y][xD].Contains("D"))
                                            {
                                                newRoom += "L";
                                            } else
                                            {
                                                newRoom += "l";
                                            }
                                            newRoom += x +";" + y + ";";
                                            newRoom += group;
                                            roomlol[y][xD] = newRoom;


                                        }
                                    }
                                }
                            }
                            room = roomlol;
                        }
                    }

                    for (int b = 0; b < room.Count; b++)//add room to map
                    {
                        foreach (string block in room[b])
                        {
                            map[i * 7 + b].Add(block);
                        }
                    }
                }
            }

            List<List<int>> doorsToOpen = new List<List<int>>();
            List<List<int>> lockedByBattle = new List<List<int>>();
            List<string> doneThisOne = new List<string>();
            List<int> battleGroups = new List<int>();

            for ( int y = 0; y < map.Count; y++)//create doors (also messy (srry))
            {
                List<string> room = map[y];
                for (int i = 0; i < room.Count; i ++)
                {
                    string block = room[i];
                    if (block.ToLower().Contains("d"))
                    {
                        int bdex = y;
                        int ddex = i;
                        bool connected = false;
                        if (bdex != 0 && bdex != map.Count - 1 && ddex != 0 && ddex != room.Count - 1)//check if the door is valid
                        {
                            if (room[ddex + 1] != " " && room[ddex - 1] != " ")
                            {
                                if (map[bdex + 1].Count > ddex && map[bdex - 1].Count > ddex && map[bdex + 1][ddex] != " " && map[bdex - 1][ddex] != " ") 
                                {
                                    connected = true;
                                }
                            }
                        }

                        if (connected)
                        {
                            doorsToOpen.Add(new List<int> { bdex, ddex });
                        }
                    }
                    else if (block.Contains("L") || block.Contains("l"))
                    {
                        int bdex = y;
                        int ddex = i;
                        bool connected = false;
                        if (bdex != 0 && bdex != map.Count - 1 && ddex != 0 && ddex != room.Count - 1)//check if the door is valid
                        {
                            if (room[ddex + 1] != " " && room[ddex - 1] != " ")
                            {
                                if (map[bdex + 1].Count > ddex && map[bdex - 1].Count > ddex && map[bdex + 1][ddex] != " " && map[bdex - 1][ddex] != " ")
                                {
                                    connected = true;
                                }
                            }
                        }

                        if (connected)
                        {
                            string[] argh;
                            if (block.Contains("L")) {
                                argh = block.Split('L');
                            } else
                            {
                                argh = block.Split('l');
                            }
                            string[] aargh = argh[1].Split(';');
                            int grorp = int.Parse(aargh[2]);
                            int notit = doneThisOne.IndexOf(argh[1]);
                            if (notit < 0)
                            {
                                doneThisOne.Add(argh[1]);
                                lockedByBattle.Add(new List<int> { bdex, ddex });
                                battleGroups.Add(grorp);
                            } else
                            {
                                doorsToOpen.Add(new List<int> { bdex, ddex });
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < doorsToOpen.Count; i ++)
            {
               map[doorsToOpen[i][0]][doorsToOpen[i][1]] = "-";
            }
            for (int i = 0; i < lockedByBattle.Count; i++)
            {
                map[lockedByBattle[i][0]][lockedByBattle[i][1]] = "BL" + battleGroups[i];
            }
            return map;
        }
        
        public static List<List<string>> DecompileLayout(string id)
        {
            Debug.Log(id);
            string[] ids = id.Split(',');
            List<List<string>> id2 = new List<List<string>> { new List<string>() };
            int y = 0;
            for (int i = 0; i < ids.Length; i ++)
            {
                if (!ids[i].Contains("/") && !ids[i].Contains("}") && !ids[i].Contains("\r"))
                {
                    id2[y].Add(ids[i]);
                } else if (ids[i].Contains("/"))
                {
                    string[] newLayer = ids[i].Split('/');
                    id2.Add(new List<string>());
                    y++;
                    id2[y].Add(newLayer[1]);
                }
            }
            return id2;
        }

    }
}

