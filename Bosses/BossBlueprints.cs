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

namespace MagnificusMod
{
    class BossBlueprints
    {
		public class GoobertP1Blueprint : EncounterBlueprintData
		{
			public GoobertP1Blueprint()
			{
				List<Card> list = new List<Card>();
				base.name = "GoobertP1Blueprint1";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_greenmox")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_greenmage")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_greenmage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{

					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_crystalworm")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_greenmage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_orangemage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{

					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_jrsage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_greenmox")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_sabesage")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_greenmox")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{

					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_greenmage")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_greenmage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_greenmox")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{

					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_orangemage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_greenmage")
					}
				});
				for (int i = 8; i < 100; i++)
				{
					if (i % 2 == 0)
					{
						this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
						{
							new EncounterBlueprintData.CardBlueprint
							{
								card = CardLoader.GetCardByName("mag_jrsage")
							}
						});
					}
				}
			}
		}

		public class GoobertP1BlueprintBUFF : EncounterBlueprintData
		{
			public GoobertP1BlueprintBUFF()
			{
				List<Card> list = new List<Card>();
				base.name = "GoobertP1Blueprint1BUFF";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_greenmox")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_greenmox")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_greenmox")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_greenmage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_greenmage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_jrsage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_greenmage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_skelejrsage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_goo")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_goo")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_greenmage")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_greenmox")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_greenmage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_greenmox")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_greenmage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_orangemage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_greenmage")
					}
				});
				for (int i = 8; i < 100; i++)
				{
					this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
					{
						new EncounterBlueprintData.CardBlueprint
						{
							card = CardLoader.GetCardByName("mag_jrsage")
						}
					});
				}
			}
		}

		public class GoobertP2Blueprint : EncounterBlueprintData
		{
			public GoobertP2Blueprint()
			{
				base.name = "GoobertP2Blueprint";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_goo")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_goo")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_goo")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_goo")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_greenmox")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_goo")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{

					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_musclemage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{

					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_goo")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_stimmage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_goo")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{

					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_musclemage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_greenmox")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_greenmox")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_greenmage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_greenmage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{

					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_orangemage")
					}
				});
				for (int i = 8; i < 100; i++)
				{
					if (i % 2 == 0)
					{
						this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
					{
						new EncounterBlueprintData.CardBlueprint
						{
							card = CardLoader.GetCardByName("mag_goo")
						}
					});
					}
				}
			}
		}

		public class GoobertP2BlueprintBUFF : EncounterBlueprintData
		{
			public GoobertP2BlueprintBUFF()
			{
				base.name = "GoobertP2BlueprintBUFF";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_goo")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_goo")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_goo")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_goo")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_crystalworm")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_greenmage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_wolf")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_musclemage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_goo")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_greenmox")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_BOSSstimmage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_greenmage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_musclemage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_greenmox")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_greenmox")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_greenmage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_greenmage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_orangemage")
					}
				});
				for (int i = 8; i < 100; i++)
				{
					this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
					{
						new EncounterBlueprintData.CardBlueprint
						{
							card = CardLoader.GetCardByName("mag_goo")
						}
					});
				}
			}
		}

		public class EspeararaP1Blueprint : EncounterBlueprintData
		{
			public EspeararaP1Blueprint()
			{
				base.name = "EspeararaP1Blueprint1";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_rubymox")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_knightmage")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_rubygolem")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_scarecrow")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{

					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_rubygolem")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{

					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{

					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_rubymox")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_orangemage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{

					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{

					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_scarecrow")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_orangemage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{

					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_scarecrow")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_BOSSspear")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_orangemage")
					}
				});
				for (int i = 8; i < 100; i++)
				{
					if (i % 2 == 0)
					{
						this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
						{
							new EncounterBlueprintData.CardBlueprint
							{
								card = CardLoader.GetCardByName("mag_scarecrow")
							}
						});
					} else
                    {
						this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
						{
							new EncounterBlueprintData.CardBlueprint
							{
								
							}
						});
					}
				}
			}
		}

		public class EspeararaP1BlueprintNERF : EncounterBlueprintData
		{
			public EspeararaP1BlueprintNERF()
			{
				base.name = "EspeararaP1BlueprintNERF";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_rubymox")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_knightmage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_scarecrow")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_rubygolem")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_rubymox")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_orangemage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_scarecrow")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_rubymox")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_orangemage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_BOSSspear")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_orangemage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_knightmage")
					}
				});
				for (int i = 8; i < 100; i++)
				{
					if (i % 2 == 0)
					{
						this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
					{
						new EncounterBlueprintData.CardBlueprint
						{

						}
					});
					}
					else
					{
						this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
						{
							new EncounterBlueprintData.CardBlueprint
							{
								card = CardLoader.GetCardByName("mag_scarecrow")
							}
						});
					}
				}
			}
		}

		public class EspeararaP2Blueprint : EncounterBlueprintData
		{
			public EspeararaP2Blueprint()
			{
				base.name = "EspeararaP2Blueprint1";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_triplescarecrow")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_spear")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_triplescarecrow")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_spear")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_scarecrow")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_rubymox")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_orangemage")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_atkspell")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint()
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_triplescarecrow")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_scarecrow")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_scarecrow")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_orangemage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_frostspell")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_flamespell")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint()
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_scarecrow")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_BOSSspear")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_orangemage")
					}
				});
				for (int i = 8; i < 100; i++)
				{

					if (i % 2 == 0)
					{
						this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
						{
							new EncounterBlueprintData.CardBlueprint
							{
								card = CardLoader.GetCardByName("mag_scarecrow")
							}
						});
					}
					else
					{
						this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
						{
							new EncounterBlueprintData.CardBlueprint
							{

							}
						});
					}
				}
			}
		}

		public class EspeararaP2BlueprintNERF : EncounterBlueprintData
		{
			public EspeararaP2BlueprintNERF()
			{
				base.name = "EspeararaP2BlueprintNERF";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_triplescarecrow")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_spear")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_scarecrow")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{

					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_rubymox")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_orangemage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_scarecrow")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_scarecrow")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_knightmage")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_rubymox")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_BOSSspear")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_orangemage")
					}
				});
				for (int i = 8; i < 100; i++)
				{
					if (i % 2 == 0)
					{
						this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
					{
						new EncounterBlueprintData.CardBlueprint
						{

						}
					});
					}
					else
					{
						this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
						{
							new EncounterBlueprintData.CardBlueprint
							{
								card = CardLoader.GetCardByName("mag_scarecrow")
							}
						});
					}
				}
			}
		}

		public class LonelyMageP1Blueprint : EncounterBlueprintData
		{
			public LonelyMageP1Blueprint()
			{
				base.name = "LonelyMageP1Blueprint1";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_bluemox")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_hovermage")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_gemfiend")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_hovermage")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_BOSSstimmage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint()
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_atkspell")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint()
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_bluemox")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_stimmage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_gemfiend")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_hpspell")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint()
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_bluemox")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_alchemist")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_skelemage")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_gemfiend")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_waterspell")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint()
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_BOSSstimmage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_bluemox")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_stimmage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_hovermage")
					}
				});
				for (int i = 8; i < 100; i++)
				{
					if (i % 2 == 0)
					{
						this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
					{
						new EncounterBlueprintData.CardBlueprint
						{
							card = CardLoader.GetCardByName("mag_BOSSstimmage")
						}
					});
					} else
                    {
						this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
					{
						new EncounterBlueprintData.CardBlueprint()
					});
					}
				}
			}
		}

		public class LonelyMageP1BlueprintNERF : EncounterBlueprintData
		{
			public LonelyMageP1BlueprintNERF()
			{
				base.name = "LonelyMageP1BlueprintNERF";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_bluemox")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_gemfiend")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{

					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_BOSSstimmage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_bluemox")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_stimmage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_gemfiend")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_bluemox")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_skelemage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{

					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_bluemox")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_stimmage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_hovermage")
					}
				});
				for (int i = 8; i < 100; i++)
				{
					this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
					{
						new EncounterBlueprintData.CardBlueprint
						{
							card = CardLoader.GetCardByName("mag_hovermage")
						}
					});
				}
			}
		}

		public class LonelyMageP2Blueprint : EncounterBlueprintData
		{
			public LonelyMageP2Blueprint()
			{
				base.name = "LonelyMageP2Blueprint1";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_bluemox")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_bluemox")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_BOSSstimmage")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_bluemox")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_gemfiend")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_skelemage")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_gemfiend")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_waterspell")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_bluemox")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint()
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_magimorph")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_hovermage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_atkspell")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_hpspell")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint()
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_bluemox")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_bluemage")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_greenmage")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_orangemage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_bluemox")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_bluemox")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_atkspell")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint()
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_stimmage")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_BOSSstimmage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint()
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_stimmachine")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint()
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_hpspell")
					}
				});
			}
		}

		public class LonelyMageP2BlueprintNERF : EncounterBlueprintData
		{
			public LonelyMageP2BlueprintNERF()
			{
				base.name = "LonelyMageP2BlueprintNERF";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_bluemox")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_bluemox")
					}
				});
			}
		}

		public class MagnificusP1Blueprint : EncounterBlueprintData
		{
			public MagnificusP1Blueprint()
			{
				base.name = "MagnificusP1Blueprint1";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_orangemage")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_greenmage")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_almondcookie")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_gemfiend")
					}
					
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_gemboundripper")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_goranjmox")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_mastergo")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{

					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_atkspell")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{

					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_skelemage")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_skelemage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{

					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_hpspell")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_BOSSstimmage")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_mastergo")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{

					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_BOSSstimmage")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_triplescarecrow")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_goo")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_frostspell")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{

					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_emeraldfiend")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_goranjmox")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_greenmage")
					},
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_drake")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_mastergo")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_gemboundripper")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_skelemage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_rubymox")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_rubyfiend")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_gemfiend")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_emeraldfiend")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_orangemage")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_greenmage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{

					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_bleenehound")
					}
				});
				for (int i = 8; i < 100; i++)
				{
					if (i % 2 == 0)
					{
						this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
					{
						new EncounterBlueprintData.CardBlueprint
						{
							card = CardLoader.GetCardByName("mag_skelejrsage")
						}
					});
					} else
                    {
						this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
					{
						new EncounterBlueprintData.CardBlueprint
						{
							
						}
					});
					}
				}
			}
		}

		public class MagnificusFinalBlueprint : EncounterBlueprintData
		{
			public MagnificusFinalBlueprint()
			{
				base.name = "MagnificusFinalBlueprint1";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_bluemox")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_bluemox")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_mastergo")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("Amalgam")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("Amalgam")
					}
				});
			}
		}

		public class GoranjP1Blueprint : EncounterBlueprintData
		{
			public GoranjP1Blueprint()
			{
				List<Card> list = new List<Card>();
				base.name = "GoranjP1Blueprint";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_goranjmox")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_greenmage")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_orangemage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_rubymox")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{

					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_rubygolem")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_orangemage")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_greenmox")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_rubymox")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{

					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_greenmox")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_emeraldfiend")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{

					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_musclemage")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_greenmox")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_greenmage")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_orangemage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_greenmox")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{

					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_orangemage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_greenmage")
					}
				});
				for (int i = 8; i < 100; i++)
				{
					if (i % 2 == 0)
					{
						this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
						{
							new EncounterBlueprintData.CardBlueprint
							{
								card = CardLoader.GetCardByName("mag_jrsage")
							}
						});
					}
				}
			}
		}

		public class GoranjP2Blueprint : EncounterBlueprintData
		{
			public GoranjP2Blueprint()
			{
				base.name = "GoranjP2Blueprint";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_goo")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_goo")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_goo")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_goo")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_greenmox")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_rubymox")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_emeraldfiend")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{

					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_musclemage")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_alchemist")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_sodamage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_stimmage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_greenmage")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_greenmox")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_jrsage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_musclemage")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_coffeemage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_rubymox")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_rubymox")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_orangemage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_greenmage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{

					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_orangemage")
					}
				});
			}
		}

		public class OrluP1Blueprint : EncounterBlueprintData
		{
			public OrluP1Blueprint()
			{
				List<Card> list = new List<Card>();
				base.name = "OrluP1Blueprint";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_orlumox")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_hovermage")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_rubygolem")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_bluemox")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_valkyrie")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_orangemage")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_gemfiend")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_coffeemage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_almondcookie")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_valkyrie")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_bluemox")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_gemfiend")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{

					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_orangemage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_spear")
					}
				});
			}
		}

		public class OrluP2Blueprint : EncounterBlueprintData
		{
			public OrluP2Blueprint()
			{
				List<Card> list = new List<Card>();
				base.name = "OrluP2Blueprint";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_orlumox")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_hovermage")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_rubygolem")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_orlumox")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_almondcookie")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_gemfiend")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_magimorph")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_hovermage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{

					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_knightmage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_practicemage")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_practicemage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_puppeteer")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_bluemox")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{

					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_wolf")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_practicemage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_knightmage")
					}
				});
			}
		}

		public class BleeneP1Blueprint : EncounterBlueprintData
		{
			public BleeneP1Blueprint()
			{
				List<Card> list = new List<Card>();
				base.name = "BleeneP1Blueprint";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_bleenemox")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_gemfiend")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_stimmage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_BOSSstimmage")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_bluemox")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_magimorph")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_puppeteer")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{

					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_hovermage")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_bluemox")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_bullfrog")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_greenmox")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_greenmage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{

					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_stimmage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_sodamage")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_musclemage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_gemfiend")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_jrsage")
					}
				});
			}
		}

		public class BleeneP2Blueprint : EncounterBlueprintData
		{
			public BleeneP2Blueprint()
			{
				List<Card> list = new List<Card>();
				base.name = "BleeneP2Blueprint";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_bleenemox")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_greenmage")
					}

				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{

					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_stimmage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{

					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_sodamage")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_greenmox")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_puppeteer")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{

					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_musclemage")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_greenmox")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{

					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_alchemist")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_emeraldfiend")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_musclemage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_alchemist")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_jrsage")
					}
				});
			}
		}

		public class MagnusP1Blueprint : EncounterBlueprintData
		{
			public MagnusP1Blueprint()
			{
				base.name = "MagnusP1Blueprint";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_orangemage")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_musclemage")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_BOSSstimmage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_gemboundripper")
					}

				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{

					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_rubymox")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_knightmage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_greenmage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_rubygolem")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_goranjmox")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_mastergo")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_almondcookie")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_hpspell")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_hpspell")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_rubygolem")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{

					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_atkspell")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_BOSSstimmage")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_triplescarecrow")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{

					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_BOSSstimmage")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_triplescarecrow")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_goo")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{

					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_emeraldfiend")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_orlumox")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_hovermage")
					},
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_pheonix")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{

					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_gemboundripper")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_skelemage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{

					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_bleenemox")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_stimmage")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_BOSSstimmage")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_emeraldfiend")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_bleenehound")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_greenmage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{

					}
				});
			}
		}

		public class DummyBlueprint : EncounterBlueprintData
		{
			public DummyBlueprint()
			{
				base.name = "DummyBlueprint";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_practicemage")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_forcemage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{

					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_alchemist")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_practicemage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_hpspell")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_puppeteer")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_practicemage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_almondcookie")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_alchemist")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_stimmachine")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_practicemage")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_puppeteer")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_hpspell")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{

					}
				});
			}
		}

	}
}
