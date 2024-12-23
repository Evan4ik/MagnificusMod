using System;
using System.Collections.Generic;
using UnityEngine;

namespace MagnificusMod
{
    public class RoomGenRooms
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
            new List<string> { "W3E", "-",   "-",  "-",  "-",  "-", "W3W" },
            new List<string> { "W3K",  "-",   "-",  "-",  "-",  "-", "W3K" },
            new List<string> { "W3d",  "-",   "-", "S","-",  "-", "W3d" },
            new List<string> { "W3H",  "-",   "P4",  "SK",  "P4",  "-", "W3K" },
            new List<string> { "W3E",  "-",   "-",  "-",  "-",  "-", "W3W" },
            new List<string> { "W3C", "W3S","W3H", "W3D","W3H","W3S", "W3C" }
            },
            new List<List<string>>
        {
             new List<string> { "W3C", "W3N", "W3J","W3D","W3J","W3N","W3C" },
            new List<string> { "W3E",  "A1E",   "-",  "-",  "-",  "A2W", "W3W" },
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
            new List<string> { "W8E",  "-",   "-",  "-",  "-",  "-", "W8W" },
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
            new List<string> { "WgC", "WgS","WgH", "B","WgH","WgS", "WgC" }
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
            new List<string> { "W1H",  "W1S", "W1S", "W1S",  "W1S",  "W1S", "W1W", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W1E", " ", " ", " ", " ", " ", "W1W" },
            new List<string> { "W1E",  "W1S",   "W1S",  "W1S",  "W1S",  "W1S", "W1W", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W1E", "-", "-", "-", "-", "-", "W1W" },
            new List<string> { "W1C", "W1S","W1H", "W1N","W1H","W1S", "W1C", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W1C", "W1S", "W1S", "W1S", "W1S", "W1S", "W1C" }
        },
            new List<List<string>>
        {
             new List<string> { "W4C", "W4N", "W4J","W4C","W4J","W4N","W4C", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W4C", "W4N", "W4N","W4N","W4N","W4N","W4C" },
            new List<string> { "W4E",  "W4N", "W5N", "W4N", "W4N", "W4N", "W4W", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W4E", "-", "-", "-", "-", "-", "W4W" },
            new List<string> { "W4K",  "W4N", "W5N","W4N",  "W4N",  "W5C", "W5W", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W4E", " ", " ", " ", " ", " ", "W4W" },
            new List<string> { "W4d",  "-",   "-",   "-",    "-",  "EX1", "W4W", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W4E", "-", "-", "-", "-", "EXA", "W4W" },
            new List<string> { "W5H",  "W4S", "W5S", "W4S",  "W5S",  "W4S", "W4W", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W4E", " ", " ", " ", " ", " ", "W4W" },
            new List<string> { "W4E",  "W4S",   "W5S",  "W4S",  "W4S",  "W4S", "W4W", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W4E", "-", "-", "-", "-", "-", "W4W" },
            new List<string> { "W4C", "W4S","W4H", "W4N","W4H","W4S", "W4C", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W4C", "W4S", "W4S", "W4S", "W4S", "W4S", "W4C" }
        },
            new List<List<string>>
        {
            new List<string> { "W8C", "W8N", "W8J","W8C","W8J","W8N","W8C", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W8C", "W8N", "W8N","W8N","W8N","W8N","W8C" },
            new List<string> { "W8E",  "W8N", "W8N", "W8N", "W8N", "W8N", "W8W", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W8E", "-", "-", "-", "-", "-", "W8W" },
            new List<string> { "W8K",  "W8N", "W8N","W8N",  "W8N",  "W8N", "W8W", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W8E", " ", " ", " ", " ", " ", "W8W" },
            new List<string> { "W8d",  "-",   "-",   "-",    "-",  "EX1", "W8W", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W8E", "-", "-", "-", "-", "EXA", "W8W" },
            new List<string> { "W8H",  "W8S", "W8S", "W8S",  "W8S",  "W8S", "W8W", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "W8E", " ", " ", " ", " ", " ", "W8W" },
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
            new List<string> { "W1E",  "P2",   "-",  "-",  "P1",  "-", "W1W" },
            new List<string> { "W1K",  "-",   "P3",  "-",  "WgP",  "-", "W1K" },
            new List<string> { "W1d",  "-",   "-",  "EVN",  "-",  "-", "W1d" },
            new List<string> { "W1H",  "-",   "P1",  "-",  "P2",  "-", "W1K" },
            new List<string> { "W1E",  "P2",   "-",  "-",  "P3",  "-", "W1W" },
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
            new List<string> { "W1E", "P1", "W1F",  "-", "W1F",  "P1", "W1W" },
            new List<string> { "W1K", "W1F", "W1F",  "-", "W1F",  "-", "W1K" },
            new List<string> { "W1d",  "-",   "-",  "B",  "-",  "-", "W1d" },
            new List<string> { "W1H", "P2", "W1F",  "-", "W1F",  "-", "W1K" },
            new List<string> { "W1E", "W1F", "W1F",  "-", "W1F",  "P3", "W1W" },
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
            new List<string> { "W1E",  "B",   "-",  "-",  "-",  "P1", "W1W" },
            new List<string> { "W1K",  "-",   "W1P",  "-",  "W1P",  "-", "W1K" },
            new List<string> { "W1d",  "-",   "-",  "EVN",  "-",  "-", "W1d" },
            new List<string> { "W1H",  "-",   "W1P",  "-",  "W1P",  "-", "W1K" },
            new List<string> { "W1E",  "P2",   "-",  "-",  "-",  "B", "W1W" },
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
            new List<string> { "W1E",  "W3F",   "-",  "-",  "-", "W3F", "W1W" },
            new List<string> { "W1K",  "-",   "C",  "-",  "-",  "-", "W2K" },
            new List<string> { "W1d",  "-",   "-", "P3","-",  "-", "W1d" },
            new List<string> { "W1H",  "-",   "-",  "-",  "EN",  "-", "W1K" },
            new List<string> { "W1E", "W3F",   "-",  "-",  "-", "W3F", "W1W" },
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
            new List<string> { "W1d",  "-",   "B", "EVN","P1",  "-", "W1d" },
            new List<string> { "W1H",  "-",   "-",  "W1P",  "-",  "-", "W1K" },
            new List<string> { "W1E",  "-",   "-",  "-",  "-",  "-", "W1W" },
            new List<string> { "W1C", "W1S","W1H", "W1D","W1H","W1S", "W1C" }
        },
          new List<List<string>>
        {
            new List<string> { "W1C", "W2N", "W1J","W1D","W1J","W1N","W1C" },
            new List<string> { "W1E",  "-",   "-",  "-",  "-",  "-", "W1W" },
            new List<string> { "W1K",  "-",   "-",  "WgP",  "-",  "-", "W2K" },
            new List<string> { "W1d",  "-",   "B", "EVN","P3",  "-", "W1d" },
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
            new List<string> { "W2E",  "-",   "P2",  "-",  "-",  "-", "W2W" },
            new List<string> { "W2K",  "-",   "-",  "WgP",  "-",  "-", "W2K" },
            new List<string> { "W2d",  "-",   "-", "CR","-",  "-", "W2d" },
            new List<string> { "W2H",  "-",   "-",  "W1P",  "-",  "-", "W2K" },
            new List<string> { "W2E",  "-",   "-",  "-",  "P3",  "-", "W2W" },
            new List<string> { "W2C", "W2S","W2H", "W2D","W2H","W2S", "W2C" }
        },
          new List<List<string>>
        {
            new List<string> { "W2C", "W1N", "W2J","W1D","W2J","W1N","W2C" },
            new List<string> { "W1E",  "P2",   "-",  "-",  "-",  "P3", "W1W" },
            new List<string> { "W2K",  "W1P",   "-",  "-",  "-",  "W1P", "W2K" },
            new List<string> { "W1d",  "-",    "CR",  "EVN",   "CS",  "-", "W1d" },
            new List<string> { "W2H",  "W1P",   "-",  "-",  "-",  "W1P", "W2K" },
            new List<string> { "W1E",  "P3",   "-",  "-",  "-",  "P2", "W1W" },
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
            new List<string> { "W1E",  "P2",   "-",  "-",  "-",  "CR", "W1W" },
            new List<string> { "W1K",  "-",   "P1",  "-",  "P1",  "-", "W2K" },
            new List<string> { "W1d",  "-",   "-", "B","-",  "-", "W1d" },
            new List<string> { "W1H",  "-",   "P1",  "-",  "P1",  "-", "W1K" },
            new List<string> { "W1E",  "-",   "-",  "-",  "-",  "P2", "W1W" },
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
            new List<string> { "W1E",  "CR",   "-",  "-",  "-",  "-", "W1W" },
            new List<string> { "W1K",  "B",   "W1F",  "W1F",  "W1F",  "-", "W2K" },
            new List<string> { "W1d",  "-",   "-",    "EVN",    "W1F",   "EVN", "W1d" },
            new List<string> { "W1H",  "B",   "W1P",    "-",  "W1F",  "W1F", "W1K" },
            new List<string> { "W1E",  "CS",   "P1",    "-",  "W1F",  "W1F", "W1W" },
            new List<string> { "W1C", "W1S","W2H", "W1D","W1H","W1S", "W1C" }
        },
        new List<List<string>>
        {
            new List<string> { "W2C", "W2N", "W2J","W1D","W1J","W1N","W1C" },
            new List<string> { "W2E",  "W2P", "-",  "-",  "-", "W3F", "W1W" },
            new List<string> { "W2K",  "-",   "-",  "-", "W3F",  "CS", "W1K" },
            new List<string> { "W1d",  "-",   "-", "B","-",  "-", "W1d" },
            new List<string> { "W1H",  "CR", "W3F", "-",  "-",  "-", "W2K" },
            new List<string> { "W1E", "W3F", "-",  "-",  "-",  "W2P", "W2W" },
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
            new List<string> { "WgK",  "-",   "-",  "-",  "-",  "CS", "WgK" },
            new List<string> { "Wgd",  "-", "W3F", "B", "W3F",  "-", "Wgd" },
            new List<string> { "WgH",  "WgP",   "-",  "-",  "-",  "-", "WgK" },
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
         new List<List<string>>
        {
            new List<string> { "WgC", "WgN", "WgJ","WgD","WgJ","WgN","WgC" },
            new List<string> { "WgE",  "-",   "EVN",  "-",  "-",  "-", "WgW" },
            new List<string> { "WgK",  "-",   "P2",  "-",  "-",  "P1", "WgK" },
            new List<string> { "Wgd",  "-",   "P2", "B","P1",  "-", "Wgd" },
            new List<string> { "WgH",  "WgP",   "-",  "-",  "P1",  "-", "WgK" },
            new List<string> { "WgE",  "-",   "-",  "-",  "-",  "CR", "WgW" },
            new List<string> { "WgC", "WgS","WgH", "WgD","WgH","WgS", "WgC" }
        },
         new List<List<string>>
        {
            new List<string> { "W1C", "W1N", "W1J","W1D","W1J","W1N","W1C" },
            new List<string> { "W1E", "W2C",   "W1E",  "-",  "-",  "W1C", "W1W" },
            new List<string> { "W1K",  "W1N",   "W2C",  "-",  "CR",  "-", "W1K" },
            new List<string> { "W1d",  "-",   "-", "-","W1F",  "-", "W1d" },
            new List<string> { "W1H",  "W2F",   "-",  "W1F",  "W2C",  "W1S", "W1K" },
            new List<string> { "W1E",  "W1C",   "CS",  "-",  "-",  "W2W", "W1W" },
            new List<string> { "W1C", "W1S","W1H", "W1D","W1H","W1S", "W1C" }
        },
         new List<List<string>>
        {
            new List<string> { "W1C", "W2N", "W1J","W2D","W1J","W1N","W1C" },
            new List<string> { "W1E",  "-",   "-",  "-",  "-",  "CRT", "W1W" },
            new List<string> { "W2K",  "-",   "P1",  "P2",  "-",  "-", "W2K" },
            new List<string> { "W2d",  "-",   "-", "CS","-",  "-", "W2d" },
            new List<string> { "W1H",  "-",   "P2",  "-",  "P3",  "-", "W1K" },
            new List<string> { "W1E",  "CRT",   "-",  "-",  "-",  "-", "W1W" },
            new List<string> { "W1C", "W1S","W2H", "W2D","W1H","W2S", "W1C" }
        },
         new List<List<string>>
        {
            new List<string> { "W1C", "W2N", "W1J","W2D","W1J","W1N","W1C" },
            new List<string> { "W1E",  "-",   "-",  "-",  "-",  "CR", "W1W" },
            new List<string> { "W2K",  "-",   "W1F",  "-",  "W1F",  "-", "W2K" },
            new List<string> { "W2d",  "-",   "-", "B","-",  "-", "W2d" },
            new List<string> { "W1H",  "-",   "W1F",  "-",  "W1F",  "-", "W1K" },
            new List<string> { "W1E",  "CR",   "-",  "-",  "-",  "-", "W1W" },
            new List<string> { "W1C", "W1S","W2H", "W2D","W1H","W2S", "W1C" }
        },
        new List<List<string>>
        {
            new List<string> { "W2C", "W2N", "W2J","W1D","W1J","W1N","W1C" },
            new List<string> { "W2E",  "W2P", "-",  "-",  "-", "W3F", "W1W" },
            new List<string> { "W2K",  "-",   "-",  "-", "W3F",  "CS", "W1K" },
            new List<string> { "W1d",  "-",   "-", "-","-",  "-", "W1d" },
            new List<string> { "W1H",  "-", "-", "-",  "-",  "-", "W2K" },
            new List<string> { "W1E", "W3F", "-",  "-",  "-",  "W2P", "W2W" },
            new List<string> { "W1C", "W1S","W1H", "W1D","W2H","W2S", "W2C" }
        },
        new List<List<string>>
        {
            new List<string> { "W2C", "W2N", "W2J","W1D","W1J","W1N","W1C" },
            new List<string> { "W2E",  "EVN", "-",  "-",  "-", "-", "W1W" },
            new List<string> { "W2K",  "-",   "W1F",  "W1F", "W1F",  "-", "W1K" },
            new List<string> { "W1d",  "-",   "W1F", "W2P","W1F",  "-", "W1d" },
            new List<string> { "W1H",  "-", "W1F", "W1F",  "W1F",  "-", "W2K" },
            new List<string> { "W1E", "-", "-",  "-",  "-",  "B", "W2W" },
            new List<string> { "W1C", "W1S","W1H", "W1D","W2H","W2S", "W2C" }
        },
        new List<List<string>>
        {
            new List<string> { "W2C", "W2N", "W2J","W1D","W1J","W1N","W1C" },
            new List<string> { "W2E",  "W2P", "TO1",  "-",  "-", "W3F", "W1W" },
            new List<string> { "W2K",  "TO1",   "-",  "-", "P2",  "-", "W1K" },
            new List<string> { "W1d",  "-",   "-", "CR","-",  "-", "W1d" },
            new List<string> { "W1H",  "-", "-", "-",  "-",  "-", "W2K" },
            new List<string> { "W1E", "W3F", "-",  "-",  "TO1",  "W2P", "W2W" },
            new List<string> { "W1C", "W1S","W1H", "W1D","W2H","W2S", "W2C" }
        },
        new List<List<string>>
        {
            new List<string> { "W2C", "W1N", "W2J","W1D","W2J","W1N","W2C" },
            new List<string> { "W1E",  "P2",   "-",  "-",  "-",  "P3", "W1W" },
            new List<string> { "W2K",  "TO1",   "-",  "-",  "-",  "W1P", "W2K" },
            new List<string> { "W1d",  "-",    "B",  "TO1",   "CS",  "-", "W1d" },
            new List<string> { "W2H",  "W1P",   "-",  "-",  "-",  "TO1", "W2K" },
            new List<string> { "W1E",  "P3",   "-",  "-",  "-",  "P2", "W1W" },
            new List<string> { "W2C", "W1S","W2H", "W1D","W2H","W1S", "W2C" }
        },
        new List<List<string>>
        {
            new List<string> { "W1C", "W2N", "W1J","W1D","W1J","W1N","W1C" },
            new List<string> { "W1E",  "P1",   "TO1",  "-",  "-",  "-", "W1W" },
            new List<string> { "W1K",  "TO1",   "-",  "P2",  "-",  "-", "W2K" },
            new List<string> { "W1d",  "-",   "-", "CR","-",  "-", "W1d" },
            new List<string> { "W1H",  "-",   "-",  "P2",  "-",  "-", "W1K" },
            new List<string> { "W1E",  "-",   "-",  "-",  "-",  "TO1", "W1W" },
            new List<string> { "W1C", "W1S","W1H", "W1D","W1H","W1S", "W1C" }
        },
         new List<List<string>>
        {
            new List<string> { "W1C", "W1N", "W1J","W1D","W1J","W1N","W1C" },
            new List<string> { "W1E",  "-",   "-",  "-",  "-",  "-", "W1W" },
            new List<string> { "W1K",  "-",   "P1",  "-",  "P3",  "-", "W1K" },
            new List<string> { "W1d",  "-",   "-",  "CR",  "-",  "-", "W1d" },
            new List<string> { "W1H",  "-",   "P2",  "-",  "P1",  "-", "W1K" },
            new List<string> { "W1E",  "-",   "-",  "-",  "-",  "-", "W1W" },
            new List<string> { "W1C", "W1S","W1H", "W1D","W1H","W1S", "W1C" }
        },
        new List<List<string>>
        {
            new List<string> { "W1C", "W2N", "W1J","W1D","W1J","W1N","W1C" },
            new List<string> { "W1E",  "CRT",   "-",  "-",  "-",  "-", "W1W" },
            new List<string> { "W1K",  "TO1",   "-",  "-",  "-",  "-", "W2K" },
            new List<string> { "W1d",  "-",   "P1", "EVN","TO1",  "-", "W1d" },
            new List<string> { "W1H",  "-",   "-",  "-",  "TO1",  "TO1", "W1K" },
            new List<string> { "W1E",  "-",   "-",  "-",  "CRT",  "TO1", "W1W" },
            new List<string> { "W1C", "W1S","W1H", "W1D","W1H","W1S", "W1C" }
        },
         new List<List<string>>
        {
            new List<string> { "W2C", "W1N", "W2J","W1D","W2J","W1N","W2C" },
            new List<string> { "W1E",  "P2",   "-",  "-",  "-",  "P3", "W1W" },
            new List<string> { "W2K",  "TO1",   "-",  "-",  "-",  "W1P", "W2K" },
            new List<string> { "W1d",  "-",    "B",  "TO1",   "CR",  "-", "W1d" },
            new List<string> { "W2H",  "W1P",   "-",  "-",  "-",  "TO1", "W2K" },
            new List<string> { "W1E",  "P3",   "-",  "-",  "-",  "P2", "W1W" },
            new List<string> { "W2C", "W1S","W2H", "W1D","W2H","W1S", "W2C" }
        },
          new List<List<string>>
        {
            new List<string> { "W1C", "W2N", "W1J","W1D","W1J","W1N","W1C" },
            new List<string> { "W1E",  "CRT",   "-",  "-",  "-",  "-", "W1W" },
            new List<string> { "W1K",  "TO1",   "-",  "-",  "-",  "-", "W2K" },
            new List<string> { "W1d",  "-",   "P1", "CR","TO1",  "-", "W1d" },
            new List<string> { "W1H",  "-",   "-",  "-",  "TO1",  "TO1", "W1K" },
            new List<string> { "W1E",  "-",   "-",  "-",  "CRT",  "TO1", "W1W" },
            new List<string> { "W1C", "W1S","W1H", "W1D","W1H","W1S", "W1C" }
        },
        };

        public static List<List<List<string>>> LavaRooms = new List<List<List<string>>>
        {
        new List<List<string>>
        {
            new List<string> { "W4C", "W5N", "W4J","W4D","W4J","W4N","W4C", "W4N", "W4N","W4N","W5C","W4C" },
            new List<string> { "W4E", "MR1",   "MR1",  "MR2",  "MR1",  "MR1", "W4W", " ",   " ",  " ",  " ", "W4W" },
            new List<string> { "W4K",  "MR1",   "PK",  "MR1",  "PK",  "MR1", "W5W", "PK",   " ",  "PK",  " ", "W4W" },
            new List<string> { "W4d",  "MR2",   "-", "SPWN","MR1",  "MR1", "W4W", " ",   " ", " "," ",  "W4W" },
            new List<string> { "W4H",  "MR1",   "PK",  "MR1",  "PK",  "MR1", "W4W",  "PK",   " ",  "PK",  " ", "W4W" },
            new List<string> { "W4E",  "MR1",   "MR1",  "MR1",  "MR1",  "MR1", "MRR", " ",   " ",  " ",  " ", "W4W" },
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
            new List<string> { "W4H",  "W1F",   "W1F",  "-",  "W1F",  "W1F", "W4K" },
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
            new List<string> { "W6d",  "-",   "W1F",  "-",  "PK",  "-", "W6d" },
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
            new List<string> { "W4E",  "-",   "A2S",  "-",  "A2S",  "-", "W4W" },
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
            new List<string> { "W4d",  "-",   "CRT",  "-",  "B",  "-", "W4d" },
            new List<string> { "W4H",  "CR",   "-",  "-",  "CRT",  "CRT", "W4K" },
            new List<string> { "W4E",  "PK",   "CS",  "-",  "CRT",  "PK", "W4W" },
            new List<string> { "W4C", "W4S","W4H", "W4D","W4H","W4S", "W4C" }
        },
         new List<List<string>>
        {
            new List<string> { "W5C", "W6N", "W5J","W6D","W5J","W6N","W5C" },
            new List<string> { "W6E",  "W1F",   "SWR",  "-",  "SWR",  "W1F", "W6W" },
            new List<string> { "W5K",  "SWR",   "B",  "-",  "SWR",  "SWR", "W5K" },
            new List<string> { "W6d",  "-",      "-",   "EVN",  "-",  "-", "W6d" },
            new List<string> { "W5H",  "SWR",   "SWR",  "-",  "SWR",  "SWR", "W5K" },
            new List<string> { "W6E",  "W1F",   "SWR",  "-",  "SWR",  "W1F", "W6W" },
            new List<string> { "W5C", "W6S","W5H", "W6D","W5H","W6S", "W5C" }
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
            new List<string> { "W4E",  "-",   "A2S",  "-",  "-",  "A2E", "W4W" },
            new List<string> { "W4K",  "SWR",   "-",  "CRT",  "-",  "SWR", "W4K" },
            new List<string> { "W6d",  "-",   "-",  "CR",  "-",  "-", "W6d" },
            new List<string> { "W4H",  "CRT",   "-",  "CRT",  "-",  "CRT", "W4K" },
            new List<string> { "W4E",  "PK",   "PK",  "-",  "-",  "PK", "W4W" },
            new List<string> { "W4C", "W4S","W4H", "W6D","W4H","W4S", "W4C" }
        },
         new List<List<string>>
        {
            new List<string> { "W4C", "W4N", "W4J","W5D","W4J","W4N","W4C" },
            new List<string> { "W4E",  "-",   "-",  "-",  "-",  "-", "W4W" },
            new List<string> { "W4K",  "-",   "W1F",  "W1F",  "W1F",  "-", "W4K" },
            new List<string> { "W5d",  "-",   "W1F",  "EVN",  "W1F",  "-", "W5d" },
            new List<string> { "W4H",  "-",   "W1F",  "-",  "B",  "-", "W4K" },
            new List<string> { "W4E",  "CS",   "W1F",  "-",  "W1F",  "-", "W4W" },
            new List<string> { "W4C", "W4S","W4H", "W5D","W4H","W4S", "W4C" }
        },
         new List<List<string>>
        {
            new List<string> { "W4C", "W6N", "W4J","W6D","W4J","W6N","W4C" },
            new List<string> { "W6E",  "W1F",   "-",  "-",  "-",  "W1F", "W6W" },
            new List<string> { "W4K",  "-",   "-",  "-",  "-",  "-", "W4K" },
            new List<string> { "W6d",  "-",   "PK",  "CR",  "PK",  "-", "W6d" },
            new List<string> { "W4H",  "-",   "-",  "A1N",  "-",  "-", "W4K" },
            new List<string> { "W6E",  "W1F",   "-",  "-",  "-",  "W1F", "W6W" },
            new List<string> { "W4C", "W6S","W4H", "W6D","W4H","W6S", "W4C" }
        },
         new List<List<string>>
        {
            new List<string> { "W4C", "W5N", "W5J","W4D","W5J","W4N","W4C" },
            new List<string> { "W4E",  "W1F",   "A2E",  "-",  "A1W",  "W1F", "W4W" },
            new List<string> { "W5K",  "A2S", "SWR",  "-",  "PK",  "A1S", "W6K" },
            new List<string> { "W4d",  "-",   "-",  "B",  "-",  "-", "W4d" },
            new List<string> { "W6H",  "A1N",   "CR",  "-", "PK",  "A2N", "W4K" },
            new List<string> { "W4E",  "W1F",   "-",  "-",  "A2W",  "W1F", "W4W" },
            new List<string> { "W4C", "W4S","W5H", "W4D","W6H","W5S", "W4C" }
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
            new List<string> { "W4d",  "-",   "-",  "CR",  "-",  "-", "W4d" },
            new List<string> { "W5H",  "-",   "W1F",  "-",  "W1F",  "-", "W4K" },
            new List<string> { "W4E",  "A2N",   "-",  "-",  "-",  "-", "W4W" },
            new List<string> { "W4C", "W4S","W5H", "W4D","W4H","W5S", "W4C" }
        },
            new List<List<string>>
        {
            new List<string> { "W4C", "W7N", "W4J","W4D","W4J","W4N","W4C" },
            new List<string> { "W4E",  "-",   "CRT",  "-",  "PK",  "PK", "W4W" },
            new List<string> { "W5K",  "-",   "-",  "-",  "-",  "PK", "W5K" },
            new List<string> { "W4d",  "-",   "-",   "CR", "-",  "-", "W4d" },
            new List<string> { "W4H",  "PK",   "-",  "-",  "-",  "-", "W5K" },
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

         new List<List<string>>
        {
            new List<string> { "W4C", "W4N", "W4J","W6D","W4J","W7N","W4C" },
            new List<string> { "W4E",  "CRT",   "-",  "-",  "-",  "-", "W4W" },
            new List<string> { "W4K",  "-",   "EVN",  "-",  "-",  "-", "W4K" },
            new List<string> { "W6d",  "-",   "-",  "PK",  "-",  "-", "W6d" },
            new List<string> { "W4H",  "-",   "-",  "-",  "CS",  "-", "W4K" },
            new List<string> { "W4E",  "-",   "-",  "-",  "-",  "CRT", "W4W" },
            new List<string> { "W4C", "W4S","W4H", "W6D","W4H","W4S", "W4C" }
        },
         new List<List<string>>
        {
            new List<string> { "W4C", "W5N", "W6J","W4D","W4J","W7N","W4C" },
            new List<string> { "W4E",  "PK",   "A2E",  "-",  "-",  "SWR", "W4W" },
            new List<string> { "W5K",  "A2S", "SWR",  "-",  "PK",  "A1S", "W6K" },
            new List<string> { "W4d",  "-",   "-",  "EVN",  "-",  "-", "W4d" },
            new List<string> { "W6H",  "A1N",   "PK",  "-", "SWR",  "A2N", "W4K" },
            new List<string> { "W4E",  "SWR",   "A1E",  "-",  "A2W",  "PK", "W4W" },
            new List<string> { "W4C", "W4S","W5H", "W4D","W6H","W5S", "W4C" }
        },
         new List<List<string>>
        {
            new List<string> { "W4C", "W6N", "W7J","W6D","W6J","W6N","W4C" },
            new List<string> { "W6E",  "CRT",   "-",  "-",  "-",  "CRT", "W6W" },
            new List<string> { "W6K",  "-",   "-",  "-",  "-",  "-", "W6K" },
            new List<string> { "W6d",  "-",   "-",  "CS",  "-",  "-", "W6d" },
            new List<string> { "W6H",  "-",   "-",  "-",  "-",  "-", "W6K" },
            new List<string> { "W6E",  "CRT",   "-",  "-",  "-",  "CRT", "W6W" },
            new List<string> { "W4C", "W6S","W6H", "W6D","W6H","W6S", "W4C" }
        },
         new List<List<string>>
        {
            new List<string> { "W4C", "W6N", "W4J","W6D","W7J","W6N","W4C" },
            new List<string> { "W6E",  "W1F",   "-",  "-",  "-",  "W1F", "W6W" },
            new List<string> { "W4K",  "-",   "-",  "-",  "-",  "-", "W4K" },
            new List<string> { "W6d",  "-",   "PK",  "CR",  "PK",  "-", "W6d" },
            new List<string> { "W4H",  "-",   "-",  "A1N",  "-",  "-", "W4K" },
            new List<string> { "W6E",  "W1F",   "-",  "-",  "-",  "W1F", "W6W" },
            new List<string> { "W4C", "W6S","W4H", "W6D","W4H","W6S", "W4C" }
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
            new List<string> { "W8H",  "W8C",   "P3",  "B",  "P3",  "W8C", "W8K" },
            new List<string> { "W8E",  "-",   "-",  "-",  "-",  "-", "W8W" },
            new List<string> { "W8C", "W8S","W8H", "W8D","W8H","W8S", "W8C" }
        },
       new List<List<string>>
        {
            new List<string> { "W8C", "W8N", "W8J","W8D","W8J","W8N","W8C" },
            new List<string> { "W8E", "-",   "-",  "-",  "-",  "-", "W8W" },
            new List<string> { "W8K",  "W8C",   "RUNE",  "-",  "-",  "W8C", "W8K" },
            new List<string> { "W8d",  "-",   "-", "B","-",  "-", "W8d" },
            new List<string> { "W8H",  "W8C",   "RUNE",  "-",  "RUNE",  "W8C", "W8K" },
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
            new List<string> { "W8C", "W8N", "W8J","W8D","W8J","W8N","W8C" },
            new List<string> { "W8E",  "-",   "-",  "-",  "-",  "B", "W8W" },
            new List<string> { "W8K",  "-",   "PK",  "-",  "W1F",  "-", "W8K" },
            new List<string> { "W8d",  "-",   "-",  "TO3",  "-",  "-", "W8d" },
            new List<string> { "W8H",  "-",   "W1F",  "-",  "TO1",  "-", "W8K" },
            new List<string> { "W8E",  "CR",   "-",  "-",  "-",  "-", "W8W" },
            new List<string> { "W8C", "W8S","W8H", "W8D","W8H","W8S", "W8C" }
        },
       new List<List<string>>
        {
            new List<string> { "W8C", "W8N", "W8J","W8D","W8J","W8N","W8C" },
            new List<string> { "W8E",  "-",   "-",  "-",  "-",  "-", "W8W" },
            new List<string> { "W8K",  "-",   "PK",  "W1F",  "-",  "-", "W8K" },
            new List<string> { "W8d",  "-",   "E",  "TO3",  "CC",  "TO1", "W8d" },
            new List<string> { "W8H",  "-",   "W1F",  "W1F",  "W1F",  "-", "W8K" },
            new List<string> { "W8E",  "-",   "-",  "-",  "-",  "-", "W8W" },
            new List<string> { "W8C", "W8S","W8H", "W8D","W8H","W8S", "W8C" }
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

        new List<List<string>>
        {
            new List<string> { "W8C", "W8N", "W8J","W8D","W8J","W8N","W8C" },
            new List<string> { "W8E",  "-",   "P2",  "-",  "-",  "-", "W8W" },
            new List<string> { "W8K",  "-",   "-",  "W8P",  "-",  "-", "W8K" },
            new List<string> { "W8d",  "-",   "-", "B","-",  "-", "W8d" },
            new List<string> { "W8H",  "-",   "-",  "W8P",  "-",  "-", "W8K" },
            new List<string> { "W8E",  "-",   "-",  "-",  "P3",  "-", "W8W" },
            new List<string> { "W8C", "W8S","W8H", "W8D","W8H","W8S", "W8C" }
        },
        new List<List<string>>
        {
            new List<string> { "W8C", "W8N", "W8J","W8D","W8J","W8N","W8C" },
            new List<string> { "W8E",  "-",   "-",  "-",  "-",  "B", "W8W" },
            new List<string> { "W8K",  "-",   "RUNE",  "W1F",  "W1F",  "-", "W8K" },
            new List<string> { "W8d",  "-",   "W1F",  "RUNE",  "W1F",  "-", "W8d" },
            new List<string> { "W8H",  "-",   "W1F",  "RUNE",  "W1F",  "-", "W8K" },
            new List<string> { "W8E",  "RUNE",   "-",  "-",  "-",  "-", "W8W" },
            new List<string> { "W8C", "W8S","W8H", "W8D","W8H","W8S", "W8C" }
        },
        new List<List<string>>
        {
            new List<string> { "W8C", "W8N", "W8J","W8D","W8J","W8N","W8C" },
            new List<string> { "W8E",  "EVN",   "W1F",  "-",  "-",  "-", "W8W" },
            new List<string> { "W8K",  "B",   "W1F",  "W1F",  "W1F",  "-", "W8K" },
            new List<string> { "W8d",  "-",   "-", "-","-",  "-", "W8d" },
            new List<string> { "W8H",  "-",   "W1F",  "-",  "W1F",  "-", "W8K" },
            new List<string> { "W8E",  "-",   "W1F",  "-",  "CR",  "W1F", "W8W" },
            new List<string> { "W8C", "W8S","W8H", "W8D","W8H","W8S", "W8C" }
        },
        new List<List<string>>
        {
            new List<string> { "W8C", "W8N", "W8J","W8D","W8J","W8N","W8C" },
            new List<string> { "W8E",  "RUNE",   "TO3",  "-",  "-",  "RUNE", "W8W" },
            new List<string> { "W8K",  "-",   "CR",  "-",  "-",  "-", "W8K" },
            new List<string> { "W8d",  "-",   "-",  "TO3",  "-",  "-", "W8d" },
            new List<string> { "W8H",  "-",   "-",  "-",  "EVN",  "-", "W8K" },
            new List<string> { "W8E",  "RUNE",   "-",  "-",  "TO3",  "RUNE", "W8W" },
            new List<string> { "W8C", "W8S","W8H", "W8D","W8H","W8S", "W8C" }
        },
        new List<List<string>>
        {
            new List<string> { "W8C", "W8N", "W8J","W8D","W8J","W8N","W8C" },
            new List<string> { "W8E",  "EVN",   "-",  "-",  "-",  "-", "W8W" },
            new List<string> { "W8K",  "W8P",   "W8P",  "-",  "W8P",  "W8P", "W8K" },
            new List<string> { "W8d",  "-",   "W8P",  "-",  "-",  "-", "W8d" },
            new List<string> { "W8H",  "-",   "W8P",  "-",  "W8P",  "-", "W8K" },
            new List<string> { "W8E",  "-",   "B",  "-",  "W8P",  "CRT", "W8W" },
            new List<string> { "W8C", "W8S","W8H", "W8D","W8H","W8S", "W8C" }
        },
        new List<List<string>>
        {
            new List<string> { "W8C", "W8N", "W8J","W8D","W8J","W8N","W8C" },
            new List<string> { "W8E",  "EVN",   "B",  "-",  "-",  "-", "W8W" },
            new List<string> { "W8K",  "CRT",   "RUNE",  "-",  "-",  "W8C", "W8K" },
            new List<string> { "W8d",  "-",   "-",  "RUNE",  "-",  "-", "W8d" },
            new List<string> { "W8H",  "W8C",   "-",  "-",  "-",  "-", "W8K" },
            new List<string> { "W8E",  "TO3",   "TO3",  "-",  "CRT",  "CR", "W8W" },
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
            new List<string> { "W8d",  "-",   "-", "BRUNE","-",  "-", "W8d" },
            new List<string> { "W8H",  "RUNE",   "-",  "-",  "RUNE",  "W8C", "W8K" },
            new List<string> { "W8E",  "-",   "-",  "-",  "-",  "-", "W8W" },
            new List<string> { "W8C", "W8S","W8H", "W8D","W8H","W8S", "W8C" }
        },
       new List<List<string>>
        {
            new List<string> { "W8C", "W8N", "W8J","W8D","W8J","W8N","W8C" },
            new List<string> { "W8E", "-",   "-",  "-",  "-",  "CR", "W8W" },
            new List<string> { "W8K",  "-",   "-",  "RUNEH",  "-",  "W8C", "W8K" },
            new List<string> { "W8d",  "-",   "-", "BRUNE", "-",  "-", "W8d" },
            new List<string> { "W8H",  "-",   "-",  "RUNE",  "-",  "W8C", "W8K" },
            new List<string> { "W8E",  "-",   "-",  "-",  "-",  "RUNE", "W8W" },
            new List<string> { "W8C", "W8S","W8H", "W8D","W8H","W8S", "W8C" }
        },
       new List<List<string>>
        {
            new List<string> { "W8C", "W8N", "W8J","W8D","W8J","W8N","W8C" },
            new List<string> { "W8E", "RUNE",   "-",  "-",  "-",  "P2", "W8W" },
            new List<string> { "W8K",  "RUNE",   "-",  "RUNEH",  "-",  "-", "W8K" },
            new List<string> { "W8d",  "-",   "-", "BRUNE", "RUNE",  "-", "W8d" },
            new List<string> { "W8H",  "-",   "RUNE",  "-",  "-",  "TO2", "W8K" },
            new List<string> { "W8E",  "EVN",   "-",  "-",  "RUNE",  "-", "W8W" },
            new List<string> { "W8C", "W8S","W8H", "W8D","W8H","W8S", "W8C" }
        },
       new List<List<string>>
        {
            new List<string> { "W8C", "W8N", "W8J","W8D","W8J","W8N","W8C" },
            new List<string> { "W8E",  "-",   "-",  "-",  "-",  "-", "W8W" },
            new List<string> { "W8K",  "-",   "W1F",  "RUNEH",  "W1F",  "-", "W8K" },
            new List<string> { "W8d",  "-",   "RUNE", "BRUNE",  "-",  "-", "W8d" },
            new List<string> { "W8H",  "-",   "W1F",  "-",  "W1F",  "-", "W8K" },
            new List<string> { "W8E",  "-",   "-",  "EVN",  "-",  "-", "W8W" },
            new List<string> { "W8C", "W8S","W8H", "W8D","W8H","W8S", "W8C" }
        },
        new List<List<string>>
        {
            new List<string> { "W8C", "W8N", "W8J","W8D","W8J","W8N","W8C" },
            new List<string> { "W8E",  "TO2",   "-",  "-",  "-",  "-", "W8W" },
            new List<string> { "W8K",  "-",   "-",  "-",  "RUNEH",  "-", "W8K" },
            new List<string> { "W8d",  "-",   "-", "BRUNE",  "-",  "-", "W8d" },
            new List<string> { "W8H",  "CRT",   "CRT",  "CRT",  "CRT",  "-", "W8K" },
            new List<string> { "W8E",  "EVN",   "-",  "-",  "-",  "-", "W8W" },
            new List<string> { "W8C", "W8S","W8H", "W8D","W8H","W8S", "W8C" }
        },
         new List<List<string>>
        {
            new List<string> { "W8C", "W8N", "W8J","W8D","W8J","W8N","W8C" },
            new List<string> { "W8E",  "-",   "W1F",  "-",  "W1F", "RUNEH", "W8W" },
            new List<string> { "W8K",  "W1F",   "TO3",  "-",  "W1F",  "W1F", "W8K" },
            new List<string> { "W8d",  "-",   "-", "BRUNE",  "-",  "-", "W8d" },
            new List<string> { "W8H",  "TO2",   "W1F",  "-",  "W1F",  "W1F", "W8K" },
            new List<string> { "W8E",  "RUNE",   "W1F",  "-",  "TO3",  "-", "W8W" },
            new List<string> { "W8C", "W8S","W8H", "W8D","W8H","W8S", "W8C" }
        },
          new List<List<string>>
        {
            new List<string> { "W8C", "W8N", "W8J","W8D","W8J","W8N","W8C" },
            new List<string> { "W8E",  "RUNE",   "-",  "-",  "-",  "-", "W8W" },
            new List<string> { "W8K",  "-",   "-",  "RUNEH",  "-",  "-", "W8K" },
            new List<string> { "W8d",  "-",   "-", "BRUNE",  "-",  "-", "W8d" },
            new List<string> { "W8H",  "-",   "-",  "-",  "RUNE",  "-", "W8K" },
            new List<string> { "W8E",  "RUNE",   "-",  "-",  "-",  "RUNE", "W8W" },
            new List<string> { "W8C", "W8S","W8H", "W8D","W8H","W8S", "W8C" }
        },
          new List<List<string>>
        {
            new List<string> { "W8C", "W8N", "W8J","W8D","W8J","W8N","W8C" },
            new List<string> { "W8E",  "RUNE",   "-",  "-",  "-",  "RUNE", "W8W" },
            new List<string> { "W8K",  "CS",   "-",  "RUNEH",  "RUNE",  "-", "W8K" },
            new List<string> { "W8d",  "-",   "-", "BRUNE",  "-",  "-", "W8d" },
            new List<string> { "W8H",  "-",   "RUNE",  "-",  "RUNE",  "-", "W8K" },
            new List<string> { "W8E",  "RUNE",   "-",  "-",  "EVN",  "RUNE", "W8W" },
            new List<string> { "W8C", "W8S","W8H", "W8D","W8H","W8S", "W8C" }
        },
          new List<List<string>>
        {
            new List<string> { "W8C", "W8N", "W8J","W8D","W8J","W8N","W8C" },
            new List<string> { "W8E", "W1F",   "-",  "-",  "-",  "CUNE", "W8W" },
            new List<string> { "W8K",  "-",   "-",  "RUNEH",  "-",  "RUNE", "W8K" },
            new List<string> { "W8d",  "-",   "-", "BRUNE", "-",  "-", "W8d" },
            new List<string> { "W8H",  "RUNE",   "-",  "RUNE",  "-",  "RUNE", "W8K" },
            new List<string> { "W8E",  "W1F",   "-",  "-",  "-",  "W1F", "W8W" },
            new List<string> { "W8C", "W8S","W8H", "W8D","W8H","W8S", "W8C" }
        },
          new List<List<string>>
        {
            new List<string> { "W8C", "W8N", "W8J","W8D","W8J","W8N","W8C" },
            new List<string> { "W8E",  "-",   "-",  "-",  "-",  "-", "W8W" },
            new List<string> { "W8K",  "-",   "RUNE",  "RUNEH",  "W1F",  "-", "W8K" },
            new List<string> { "W8d",  "-",   "-",  "BRUNE",  "-",  "-", "W8d" },
            new List<string> { "W8H",  "-",   "W1F",  "-",  "W1F",  "-", "W8K" },
            new List<string> { "W8E",  "RUNE",   "-",  "-",  "-",  "RUNE", "W8W" },
            new List<string> { "W8C", "W8S","W8H", "W8D","W8H","W8S", "W8C" }
        },
          new List<List<string>>
        {
            new List<string> { "W8C", "W8N", "W8J","W8D","W8J","W8N","W8C" },
            new List<string> { "W8E",  "-",   "RUNE",  "-",  "-",  "-", "W8W" },
            new List<string> { "W8K",  "-",   "-",  "RUNEH",  "RUNE",  "-", "W8K" },
            new List<string> { "W8d",  "-",   "RUNE",  "BRUNE",  "P3",  "-", "W8d" },
            new List<string> { "W8H",  "-",   "CR",  "-",  "-",  "-", "W8K" },
            new List<string> { "W8E",  "-",   "P3",  "-",  "P3",  "-", "W8W" },
            new List<string> { "W8C", "W8S","W8H", "W8D","W8H","W8S", "W8C" }
        },
        };

    }
}

