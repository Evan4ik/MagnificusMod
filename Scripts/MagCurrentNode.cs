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
using SavedVars = MagnificusMod.SaveVariables;
using KayceeStorage = MagnificusMod.KayceeStorage;

namespace MagnificusMod
{
	public class MagCurrentNode
	{
		public static void getCleared()
		{
			string text;
			try
			{
				text = File.ReadAllText(SaveManager.SaveFolderPath + "MagnificusModSave.gwsave");
			}
			catch
			{
				MagCurrentNode.SaveNode("x4 y7");
				File.WriteAllText(SaveManager.SaveFolderPath + "MagnificusModSave.gwsave", SaveManager.ToJSON(MagCurrentNode.GetNodeStuff(false, true)));
				text = File.ReadAllText(SaveManager.SaveFolderPath + "MagnificusModSave.gwsave");
			}
			string[] array = text.Split(new char[]
			{
					'x'
			}, 2);
			string text2 = "x" + array[1];
			string[] array2 = text2.Split(new char[]
			{
					'C'
			});
			string[] array3 = array2[1].Split(new char[]
			{
					','
			});
			for (int i = 0; i < array3.Length; i++)
			{
				bool flag = !Utility.IsNullOrWhiteSpace(array3[i]);
				if (flag)
				{
					MagCurrentNode.clearedNode.Add(array3[i]);
				}
			}
		}
		public static string GetCoords()
		{
			string text;
			try
			{
				text = File.ReadAllText(SaveManager.SaveFolderPath + "MagnificusModSave.gwsave");
			}
			catch
			{
				MagCurrentNode.SaveNode("x4 y7");
				File.WriteAllText(SaveManager.SaveFolderPath + "MagnificusModSave.gwsave", SaveManager.ToJSON(MagCurrentNode.GetNodeStuff(false, true)));
				text = File.ReadAllText(SaveManager.SaveFolderPath + "MagnificusModSave.gwsave");
			}
			string[] array = text.Split(new char[]
			{
					'x'
			}, 2);
			string text2 = "x" + array[1];
			string[] array2 = text2.Split(new char[]
			{
					'C'
			});
			string[] array3 = array2[0].Split(new char[]
			{
					','
			});
			MagCurrentNode.SaveNode(array3[0]);
			return array3[0];
		}

		public static string GetLayout()
		{
			string text = File.ReadAllText(SaveManager.SaveFolderPath + "MagnificusModSave.gwsave");
			string[] array = text.Split(new char[]
			{
					'L'
			});
			string roomreturn = array[1];
			layout = roomreturn;
			string[] test;
			string elArray = array[1];
			if (elArray.Contains('\\'))
			{
				test = array[1].Split('\\');
				layout = test[0];
				roomreturn = test[0];
			}
			return roomreturn;
		}

		public static void GetSideDeck()
		{
			string text = File.ReadAllText(SaveManager.SaveFolderPath + "MagnificusModSave.gwsave");
			string[] array = text.Split(new char[]
			{
					'R'
			});
			array = array[1].Split(new char[]
			{
					','
			});
			string[] array2 = array[2].Split(new char[]
			{
					'"'
			});
			MagCurrentNode.sideDeck[0] = int.Parse(array[0]);
			MagCurrentNode.sideDeck[1] = int.Parse(array[1]);
			MagCurrentNode.sideDeck[2] = int.Parse(array2[0]);
		}

		public static void GetRoomLayout()
		{
			string text = File.ReadAllText(SaveManager.SaveFolderPath + "MagnificusModSave.gwsave");
			string[] array = text.Split(new char[]
			{
					'L'
			});
			string[] array2 = array[2].Split(new char[]
			{
					'"'
			});
			MagCurrentNode.layout = array2[0];
		}

		public static void SaveLayout(string layout)
		{
			MagCurrentNode.layout = layout;
		}

		public static void SaveNode(string nodeName)
		{
			MagCurrentNode.currentNodeName = nodeName;
		}

		public static void ClearNode(string nodeName)
		{
			MagCurrentNode.clearedNode.Add(nodeName);
		}

		public static void editSideDeck(int r, int g, int b)
		{
			List<int> list = MagCurrentNode.sideDeck;
			list[0] = list[0] + r;
			list = MagCurrentNode.sideDeck;
			list[1] = list[1] + g;
			list = MagCurrentNode.sideDeck;
			list[2] = list[2] + b;
		}

		public static string GetNodeStuff(bool clear, bool clearSideDeck = true)
		{
			string text = MagCurrentNode.currentNodeName;
			text += "C";
			string result;
			if (clear)
			{
				MagCurrentNode.clearedNode = new List<string>();
				if (clearSideDeck)
				{
					MagCurrentNode.sideDeck = new List<int>
						{
							3,
							4,
							3
						};
					text = "x4 y7CR3,4,3,L";
				}
				else
				{
					text = "x4 y7CR";
					for (int i = 0; i < MagCurrentNode.sideDeck.Count; i++)
					{
						text = text + MagCurrentNode.sideDeck[i].ToString() + ",";
					}
					text += "L";
				}
				result = text;
			}
			else
			{
				string text2 = "";
				for (int j = 0; j < MagCurrentNode.clearedNode.Count; j++)
				{
					bool flag = !Utility.IsNullOrWhiteSpace(MagCurrentNode.clearedNode[j]) && MagCurrentNode.clearedNode[j].ToLower().Contains('x') && !text2.ToLower().Contains(MagCurrentNode.clearedNode[j].ToLower());
					if (flag)
					{
						text2 = text2 + MagCurrentNode.clearedNode[j] + ",";
						text = text + MagCurrentNode.clearedNode[j] + ",";
					}
				}
				text += "R";
				for (int k = 0; k < MagCurrentNode.sideDeck.Count; k++)
				{
					text = text + MagCurrentNode.sideDeck[k].ToString() + ",";
				}
				text += "L" + layout;
				result = text;
			}
			return result;
		}

		[SerializeField]
		public static string currentNodeName = "";

		[SerializeField]
		public static string layout = "";

		[SerializeField]
		public static List<string> clearedNode = new List<string>();

		[SerializeField]
		public static List<int> sideDeck = new List<int>
			{
				3,
				4,
				3
			};
	}
}
