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

	public class Blueprints
	{


		public static List<List<EncounterBlueprintData>> blueprintData = new List<List<EncounterBlueprintData>>
		{
			new List<EncounterBlueprintData>
			{
			ScriptableObject.CreateInstance<MagnificusMod.Blueprints.region1blueprint1>(),
			ScriptableObject.CreateInstance<MagnificusMod.Blueprints.region1blueprint2>(),
			ScriptableObject.CreateInstance<MagnificusMod.Blueprints.region1blueprint3>(),
			ScriptableObject.CreateInstance<MagnificusMod.Blueprints.region1blueprint4>(),
			ScriptableObject.CreateInstance<MagnificusMod.Blueprints.region1blueprint5>(),
			ScriptableObject.CreateInstance<MagnificusMod.Blueprints.region1blueprint6>(),
			ScriptableObject.CreateInstance<MagnificusMod.Blueprints.region1blueprint7>(),
			ScriptableObject.CreateInstance<MagnificusMod.Blueprints.region1blueprint8>(),
			ScriptableObject.CreateInstance<MagnificusMod.Blueprints.region1blueprint9>(),
			ScriptableObject.CreateInstance<MagnificusMod.Blueprints.region1blueprint10>(),
			ScriptableObject.CreateInstance<MagnificusMod.Blueprints.region1blueprint11>(),
			ScriptableObject.CreateInstance<MagnificusMod.Blueprints.region1blueprint12>(),
			ScriptableObject.CreateInstance<MagnificusMod.Blueprints.region1blueprint13>(),
			ScriptableObject.CreateInstance<MagnificusMod.Blueprints.region1blueprint14>(),
			ScriptableObject.CreateInstance<MagnificusMod.Blueprints.region1blueprint15>(),
			ScriptableObject.CreateInstance<MagnificusMod.Blueprints.region1blueprint16>(),
			ScriptableObject.CreateInstance<MagnificusMod.Blueprints.region1blueprint17>()
			},
			new List<EncounterBlueprintData>
			{
			ScriptableObject.CreateInstance<MagnificusMod.Blueprints.region2blueprint1>(),
			ScriptableObject.CreateInstance<MagnificusMod.Blueprints.region2blueprint2>(),
			ScriptableObject.CreateInstance<MagnificusMod.Blueprints.region2blueprint3>(),
			ScriptableObject.CreateInstance<MagnificusMod.Blueprints.region2blueprint4>(),
			ScriptableObject.CreateInstance<MagnificusMod.Blueprints.region2blueprint5>(),
			ScriptableObject.CreateInstance<MagnificusMod.Blueprints.region2blueprint6>(),
			ScriptableObject.CreateInstance<MagnificusMod.Blueprints.region2blueprint7>(),
			ScriptableObject.CreateInstance<MagnificusMod.Blueprints.region2blueprint8>(),
			ScriptableObject.CreateInstance<MagnificusMod.Blueprints.region2blueprint9>(),
			ScriptableObject.CreateInstance<MagnificusMod.Blueprints.region2blueprint10>(),
			ScriptableObject.CreateInstance<MagnificusMod.Blueprints.region2blueprint11>(),
			ScriptableObject.CreateInstance<MagnificusMod.Blueprints.region2blueprint12>(),
			ScriptableObject.CreateInstance<MagnificusMod.Blueprints.region2blueprint13>(),
			ScriptableObject.CreateInstance<MagnificusMod.Blueprints.region2blueprint14>(),
			ScriptableObject.CreateInstance<MagnificusMod.Blueprints.region2blueprint15>(),
			ScriptableObject.CreateInstance<MagnificusMod.Blueprints.region2blueprint16>()
			},
			new List<EncounterBlueprintData>
			{
			ScriptableObject.CreateInstance<MagnificusMod.Blueprints.region3blueprint1>(),
			ScriptableObject.CreateInstance<MagnificusMod.Blueprints.region3blueprint2>(),
			ScriptableObject.CreateInstance<MagnificusMod.Blueprints.region3blueprint3>(),
			ScriptableObject.CreateInstance<MagnificusMod.Blueprints.region3blueprint4>(),
			ScriptableObject.CreateInstance<MagnificusMod.Blueprints.region3blueprint5>(),
			ScriptableObject.CreateInstance<MagnificusMod.Blueprints.region3blueprint6>(),
			ScriptableObject.CreateInstance<MagnificusMod.Blueprints.region3blueprint7>(),
			ScriptableObject.CreateInstance<MagnificusMod.Blueprints.region3blueprint8>(),
			ScriptableObject.CreateInstance<MagnificusMod.Blueprints.region3blueprint9>(),
			ScriptableObject.CreateInstance<MagnificusMod.Blueprints.region3blueprint10>(),
			ScriptableObject.CreateInstance<MagnificusMod.Blueprints.region3blueprint11>(),
			ScriptableObject.CreateInstance<MagnificusMod.Blueprints.region3blueprint12>(),
			ScriptableObject.CreateInstance<MagnificusMod.Blueprints.region3blueprint13>(),
			ScriptableObject.CreateInstance<MagnificusMod.Blueprints.region3blueprint14>(),
			ScriptableObject.CreateInstance<MagnificusMod.Blueprints.region3blueprint15>(),
			ScriptableObject.CreateInstance<MagnificusMod.Blueprints.region3blueprint16>()
			}
		};


		public class region1blueprint1 : EncounterBlueprintData
		{
			public region1blueprint1()
			{
				base.name = "region1blueprint1";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("JuniorSage")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("FlyingMage")
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
						card = CardLoader.GetCardByName("JuniorSage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("RubyGolem")
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
						card = CardLoader.GetCardByName("MuscleMage")
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
						card = CardLoader.GetCardByName("StimMage")
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

					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("JuniorSage")
					}
				});
			}
		}

		public class region1blueprint2 : EncounterBlueprintData
		{
			public region1blueprint2()
			{
				base.name = "region1blueprint2";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxEmerald")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("GreenMage")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("GreenMage")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxEmerald")
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
					card = CardLoader.GetCardByName("GreenMage")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_crystalworm")
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
					card = CardLoader.GetCardByName("MoxEmerald")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxEmerald")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("GreenMage")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxEmerald")
				}
			});
			}
		}
		public class region1blueprint3 : EncounterBlueprintData
		{
			public region1blueprint3()
			{
				base.name = "region1blueprint3";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxEmerald")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("StimMage")
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
					card = CardLoader.GetCardByName("MoxEmerald")
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
					card = CardLoader.GetCardByName("MoxEmerald")
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
					card = CardLoader.GetCardByName("StimMage")
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
					card = CardLoader.GetCardByName("mag_BOSSstimmage")
				}
			});
			}
		}

		public class region1blueprint4 : EncounterBlueprintData
		{
			public region1blueprint4()
			{
				base.name = "region1blueprint4";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxEmerald")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_duncemage")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_duncemage")
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
					card = CardLoader.GetCardByName("JuniorSage")
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
					card = CardLoader.GetCardByName("mag_duncemage")
				}
			});
			}
		}

		public class region1blueprint5 : EncounterBlueprintData
		{
			public region1blueprint5()
			{
				base.name = "region1blueprint5";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("OrangeMage")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_crystalworm")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("OrangeMage")
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
					card = CardLoader.GetCardByName("JuniorSage")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("OrangeMage")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_crystalworm")
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

				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MageKnight")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxRuby")
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
					card = CardLoader.GetCardByName("mag_duncemage")
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
					card = CardLoader.GetCardByName("OrangeMage")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_crystalworm")
				}
			});
			}
		}

		public class region1blueprint6 : EncounterBlueprintData
		{
			public region1blueprint6()
			{
				base.name = "region1blueprint6";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MageKnight")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxRuby")
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
					card = CardLoader.GetCardByName("OrangeMage")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_crystalworm")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("OrangeMage")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("RubyGolem")
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
					card = CardLoader.GetCardByName("RubyGolem")
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
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MageKnight")
				}
			});
			}
		}

		public class region1blueprint7 : EncounterBlueprintData
		{
			public region1blueprint7()
			{
				base.name = "region1blueprint7";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("PracticeMage")
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
					card = CardLoader.GetCardByName("JuniorSage")
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
					card = CardLoader.GetCardByName("mag_duncemage")
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
					card = CardLoader.GetCardByName("StimMage")
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
					card = CardLoader.GetCardByName("mag_crystalworm")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_alchemist")
				}
			});
			}
		}

		public class region1blueprint8 : EncounterBlueprintData
		{
			public region1blueprint8()
			{
				base.name = "region1blueprint8";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxSapphire")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("FlyingMage")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("FlyingMage")
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
					card = CardLoader.GetCardByName("MoxSapphire")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_astralprojector")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("GemFiend")
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
					card = CardLoader.GetCardByName("FlyingMage")
				}
			});
			}
		}

		public class region1blueprint9 : EncounterBlueprintData
		{
			public region1blueprint9()
			{
				base.name = "region1blueprint9";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_crystalworm")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_gemshield")
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
					card = CardLoader.GetCardByName("MoxRuby")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_gemabsorber")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxRuby")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("OrangeMage")
				}
			});
			}
		}

		public class region1blueprint10 : EncounterBlueprintData
		{
			public region1blueprint10()
			{
				base.name = "region1blueprint10";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxEmerald")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("GreenMage")
				},
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxEmerald")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_emeraldfiend")
				},
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
					card = CardLoader.GetCardByName("mag_gemshield")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxEmerald")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("OrangeMage")
				}
			});
			}
		}
		public class region1blueprint11 : EncounterBlueprintData
		{
			public region1blueprint11()
			{
				base.name = "region1blueprint11";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("PracticeMage")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("JuniorSage")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_sabesage")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxRuby")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_moxlarva")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("PracticeMage")
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
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MageKnight")
				}
			});
			}
		}

		public class region1blueprint12 : EncounterBlueprintData
		{
			public region1blueprint12()
			{
				base.name = "region1blueprint12";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_crystalworm")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_erraticscholar")
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
					card = CardLoader.GetCardByName("mag_crystalworm")
				},
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxRuby")
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
					card = CardLoader.GetCardByName("mag_almondcookie")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>());
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_crystalsage")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_crystalsage")
				}
			});
			}
		}

		public class region1blueprint13 : EncounterBlueprintData
		{
			public region1blueprint13()
			{
				base.name = "region1blueprint13";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("MuscleMage")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("MarrowMage")
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
						card = CardLoader.GetCardByName("StimMage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("PracticeMage")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("RubyGolem")
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
						card = CardLoader.GetCardByName("MuscleMage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("StimMage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("MarrowMage")
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

					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("JuniorSage")
					}
				});
			}
		}

		public class region1blueprint14 : EncounterBlueprintData
		{
			public region1blueprint14()
			{
				base.name = "region1blueprint14";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxEmerald")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("GreenMage")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("OrangeMage")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxRuby")
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
					card = CardLoader.GetCardByName("mag_almondcookie")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxRuby")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MageKnight")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_crystalsage")
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
					card = CardLoader.GetCardByName("mag_duncemage")
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
			}
		}

		public class region1blueprint15 : EncounterBlueprintData
		{
			public region1blueprint15()
			{
				base.name = "region1blueprint15";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxSapphire")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_bunnymage")
				},
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_erraticscholar")
				},
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("GreenMage")
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
					card = CardLoader.GetCardByName("mag_erraticscholar")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("GemFiend")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_emeraldfiend")
				}
			});
			}
		}

		public class region1blueprint16 : EncounterBlueprintData
		{
			public region1blueprint16()
			{
				base.name = "region1blueprint16";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxEmerald")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_gemdetonator")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxEmerald")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("GreenMage")
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
					card = CardLoader.GetCardByName("OrangeMage")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_gemabsorber")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxEmerald")
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
					card = CardLoader.GetCardByName("MoxEmerald")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_gemdetonator")
				}
			});
			}
		}

		public class region1blueprint17 : EncounterBlueprintData
		{
			public region1blueprint17()
			{
				base.name = "region1blueprint17";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxEmerald")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("JuniorSage")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MageKnight")
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
					card = CardLoader.GetCardByName("JuniorSage")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxEmerald")
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
					card = CardLoader.GetCardByName("MageKnight")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("OrangeMage")
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
					card = CardLoader.GetCardByName("RubyGolem")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxRuby")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MageKnight")
				}
			});
			}
		}

		public class region2blueprint1 : EncounterBlueprintData
		{
			public region2blueprint1()
			{
				base.name = "region2blueprint1";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("ForceMage")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_wolf")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_sabesage")
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

				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_sabesage")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_moxlarva")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_crystalworm")
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
					card = CardLoader.GetCardByName("mag_homunculus")
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
					card = CardLoader.GetCardByName("mag_wolf")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_wolf")
				}
			});
			}
		}

		public class region2blueprint2 : EncounterBlueprintData
		{
			public region2blueprint2()
			{
				base.name = "region2blueprint2";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxEmerald")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_skelejrsage")
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
					card = CardLoader.GetCardByName("MoxEmerald")
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
					card = CardLoader.GetCardByName("mag_skelejrsage")
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

				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxRuby")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_gemshield")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_skelemage")
				}
			});
			}
		}

		public class region2blueprint3 : EncounterBlueprintData
		{
			public region2blueprint3()
			{
				base.name = "region2blueprint3";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxSapphire")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_gemdetonator")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxSapphire")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_gemabsorber")
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
					card = CardLoader.GetCardByName("MoxSapphire")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("OrangeMage")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_gemdetonator")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxSapphire")
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
					card = CardLoader.GetCardByName("MoxRuby")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("OrangeMage")
				}
			});
			}
		}

		public class region2blueprint4 : EncounterBlueprintData
		{
			public region2blueprint4()
			{
				base.name = "region2blueprint4";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxRuby")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_gemshield")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxRuby")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_gemabsorber")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxRuby")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxRuby")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("OrangeMage")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxRuby")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_gemabsorber")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint()
			});
			}
		}

		public class region2blueprint5 : EncounterBlueprintData
		{
			public region2blueprint5()
			{
				base.name = "region2blueprint5";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MuscleMage")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("JuniorSage")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MuscleMage")
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
					card = CardLoader.GetCardByName("JuniorSage")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_skelejrsage")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxEmerald")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MuscleMage")
				}
			});
			}
		}

		public class region2blueprint6 : EncounterBlueprintData
		{
			public region2blueprint6()
			{
				base.name = "region2blueprint6";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxSapphire")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("GemFiend")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_bunnymage")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_wolf")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxSapphire")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("GemFiend")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_magimorph")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxSapphire")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("GemFiend")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("GemFiend")
				}
			});
			}
		}

		public class region2blueprint7 : EncounterBlueprintData
		{
			public region2blueprint7()
			{
				base.name = "region2blueprint7";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_duncemage")
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

				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_duncemage")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxEmerald")
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
					card = CardLoader.GetCardByName("MoxEmerald")
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
					card = CardLoader.GetCardByName("mag_emeraldfiend")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MuscleMage")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("JuniorSage")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_duncemage")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("JuniorSage")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_duncemage")
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
					card = CardLoader.GetCardByName("MuscleMage")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_duncemage")
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
					card = CardLoader.GetCardByName("mag_duncemage")
				}
			});
			}
		}

		public class region2blueprint8 : EncounterBlueprintData
		{
			public region2blueprint8()
			{
				base.name = "region2blueprint8";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxRuby")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("GreenMage")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("RubyGolem")
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
					card = CardLoader.GetCardByName("GreenMage")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("GreenMage")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxRuby")
				}

			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxRuby")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxRuby")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_hpspell")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("GreenMage")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxRuby")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("GreenMage")
				}
			});
			}
		}

		public class region2blueprint9 : EncounterBlueprintData
		{
			public region2blueprint9()
			{
				base.name = "region2blueprint9";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_crystalworm")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("MageKnight")
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
						card = CardLoader.GetCardByName("MageKnight")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("RubyGolem")
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
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("OrangeMage")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("MoxRuby")
					},
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
						card = CardLoader.GetCardByName("mag_alchemist")
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
						card = CardLoader.GetCardByName("RubyGolem")
					}
				});
			}
		}

		public class region2blueprint10 : EncounterBlueprintData
		{
			public region2blueprint10()
			{
				base.name = "region2blueprint10";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("MoxSapphire")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("FlyingMage")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("FlyingMage")
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
						card = CardLoader.GetCardByName("mag_frostspell")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("FlyingMage")
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
						card = CardLoader.GetCardByName("MoxSapphire")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("GemFiend")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("FlyingMage")
					},
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
						card = CardLoader.GetCardByName("FlyingMage")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("FlyingMage")
					}
				});
			}
		}

		public class region2blueprint11 : EncounterBlueprintData
		{
			public region2blueprint11()
			{
				base.name = "region2blueprint11";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_whitesmith")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("MoxRuby")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("MoxRuby")
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
						card = CardLoader.GetCardByName("OrangeMage")
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
						card = CardLoader.GetCardByName("GreenMage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("GemFiend")
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
						card = CardLoader.GetCardByName("GemFiend")
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
						card = CardLoader.GetCardByName("GreenMage")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("GreenMage")
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

		public class region2blueprint12 : EncounterBlueprintData
		{
			public region2blueprint12()
			{
				base.name = "region2blueprint12";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("MageKnight")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("MoxRuby")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("RubyGolem")
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
						card = CardLoader.GetCardByName("MoxRuby")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("OrangeMage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("MoxRuby")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_rubymenace")
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
						card = CardLoader.GetCardByName("mag_rubyfiend")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("MoxRuby")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("RubyGolem")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("RubyGolem")
					}
				});
			}
		}


		public class region2blueprint13 : EncounterBlueprintData
		{
			public region2blueprint13()
			{
				base.name = "region2blueprint13";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
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
					card = CardLoader.GetCardByName("mag_BellMage")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxRuby")
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
					card = CardLoader.GetCardByName("RubyGolem")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("FlyingMage")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxSapphire")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MageKnight")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("RubyGolem")
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
					card = CardLoader.GetCardByName("FlyingMage")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxSapphire")
				}
			});
			}
		}

		public class region2blueprint14 : EncounterBlueprintData
		{
			public region2blueprint14()
			{
				base.name = "region2blueprint14";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("FlyingMage")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_sapphiremech")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MarrowMage")
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

				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("RubyGolem")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_skelejrsage")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
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
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_sapphiremech")
				}
			});
			}
		}

		public class region2blueprint15 : EncounterBlueprintData
		{
			public region2blueprint15()
			{
				base.name = "region2blueprint15";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("RubyGolem")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("FlyingMage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("PracticeMage")
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
						card = CardLoader.GetCardByName("mag_valkyrie")
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
						card = CardLoader.GetCardByName("mag_rubymenace")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("FlyingMage")
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
						card = CardLoader.GetCardByName("mag_valkyrie")
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
						card = CardLoader.GetCardByName("RubyGolem")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("RubyGolem")
					}
				});
			}
		}

		public class region2blueprint16 : EncounterBlueprintData
		{
			public region2blueprint16()
			{
				base.name = "region2blueprint16";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("MoxEmerald")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("JuniorSage")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("OrangeMage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("MageKnight")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("MoxRuby")
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
						card = CardLoader.GetCardByName("mag_duncemage")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_duncemage")
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
						card = CardLoader.GetCardByName("mag_orcunderling")
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
						card = CardLoader.GetCardByName("RubyGolem")
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

					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("MuscleMage")
					}
				});
			}
		}



		public class region3blueprint1 : EncounterBlueprintData
		{
			public region3blueprint1()
			{
				base.name = "region3blueprint1";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("ForceMage")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_alchemist")
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
					card = CardLoader.GetCardByName("mag_wolf")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("ForceMage")
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
				new EncounterBlueprintData.CardBlueprint()
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_bleenehound")
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
					card = CardLoader.GetCardByName("MoxSapphire")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("GemFiend")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_alchemist")
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
					card = CardLoader.GetCardByName("mag_alchemist")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("FlyingMage")
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
					card = CardLoader.GetCardByName("mag_alchemist")
				}
			});
			}
		}

		public class region3blueprint2 : EncounterBlueprintData
		{
			public region3blueprint2()
			{
				base.name = "region3blueprint2";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxSapphire")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxSapphire")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("GreenMage")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("GreenMage")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxSapphire")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("OrangeMage")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("GemFiend")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("FlyingMage")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxSapphire")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("GreenMage")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("OrangeMage")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("GreenMage")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("GreenMage")
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
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxSapphire")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("GreenMage")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("GreenMage")
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
					card = CardLoader.GetCardByName("MoxSapphire")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("OrangeMage")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("OrangeMage")
				}
			});
			}
		}

		public class region3blueprint3 : EncounterBlueprintData
		{
			public region3blueprint3()
			{
				base.name = "region3blueprint3";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_BOSSstimmage")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("StimMage")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("MoxSapphire")
					}
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
					card = CardLoader.GetCardByName("mag_alchemist")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MuscleMage")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("StimMage")
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
					card = CardLoader.GetCardByName("MoxSapphire")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_moxlarva")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_alchemist")
				}
			});
			}
		}

		public class region3blueprint4 : EncounterBlueprintData
		{
			public region3blueprint4()
			{
				base.name = "region3blueprint4";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_crystalworm")
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
					card = CardLoader.GetCardByName("mag_skelemage")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_gemshield")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_almondcookie")
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
					card = CardLoader.GetCardByName("mag_crystalworm")
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
				new EncounterBlueprintData.CardBlueprint()
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
					card = CardLoader.GetCardByName("mag_skelemage")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_almondcookie")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>());
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_skelemage")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_almondcookie")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxRuby")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_crystalworm")
				}
			});
			}
		}

		public class region3blueprint5 : EncounterBlueprintData
		{
			public region3blueprint5()
			{
				base.name = "region3blueprint5";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_crystalworm")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_moxlarva")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_moxlarva")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("OrangeMage")
				},
				new EncounterBlueprintData.CardBlueprint()
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_moxbeast")
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
					card = CardLoader.GetCardByName("mag_skelemage")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_moxlarva")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("RubyGolem")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxRuby")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_moxlarva")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_moxbeast")
				},
				new EncounterBlueprintData.CardBlueprint()
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_crystalworm")
				}
			});
			}
		}

		public class region3blueprint6 : EncounterBlueprintData
		{
			public region3blueprint6()
			{
				base.name = "region3blueprint6";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxSapphire")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("GemFiend")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxSapphire")
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
					card = CardLoader.GetCardByName("mag_coffeemage")
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
					card = CardLoader.GetCardByName("MoxSapphire")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("GemFiend")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("Pupil")
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
					card = CardLoader.GetCardByName("MageKnight")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("StimMage")
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
					card = CardLoader.GetCardByName("MoxSapphire")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_alchemist")
				}
			});
			}
		}

		public class region3blueprint7 : EncounterBlueprintData
		{
			public region3blueprint7()
			{
				base.name = "region3blueprint7";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_crystalworm")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("OrangeMage")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_gemshield")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("OrangeMage")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("OrangeMage")
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
					card = CardLoader.GetCardByName("GemFiend")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("GemFiend")
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
					card = CardLoader.GetCardByName("mag_gemshield")
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
					card = CardLoader.GetCardByName("MageKnight")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("GemFiend")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_skelemage")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint()
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint()
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("OrangeMage")
				}
			});
			}
		}


		public class region3blueprint8 : EncounterBlueprintData
		{
			public region3blueprint8()
			{
				base.name = "region3blueprint8";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_magimorph")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_magimorph")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_magimorph")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxSapphire")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("FlyingMage")
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
					card = CardLoader.GetCardByName("mag_crystalworm")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_magimorph")
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
					card = CardLoader.GetCardByName("mag_magimorph")
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
					card = CardLoader.GetCardByName("StimMage")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("GemFiend")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint()
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
				}
			});
			}
		}

		public class region3blueprint9 : EncounterBlueprintData
		{
			public region3blueprint9()
			{
				base.name = "region3blueprint9";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_coffeemage")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxRuby")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxEmerald")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("JuniorSage")
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
					card = CardLoader.GetCardByName("mag_alchemist")
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
					card = CardLoader.GetCardByName("StimMage")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxEmerald")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MuscleMage")
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
					card = CardLoader.GetCardByName("MoxEmerald")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxEmerald")
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
					card = CardLoader.GetCardByName("mag_srsage")
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
					card = CardLoader.GetCardByName("MoxEmerald")
				}
			});
			}
		}

		public class region3blueprint10 : EncounterBlueprintData
		{
			public region3blueprint10()
			{
				base.name = "region3blueprint10";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("PracticeMage")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("PracticeMage")
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
				new EncounterBlueprintData.CardBlueprint()
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
					card = CardLoader.GetCardByName("mag_alchemist")
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
					card = CardLoader.GetCardByName("mag_puppeteer")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_jester")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxSapphire")
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
					card = CardLoader.GetCardByName("GemFiend")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxRuby")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("PracticeMage")
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
					card = CardLoader.GetCardByName("mag_wolf")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_crystalworm")
				}
			});
			}
		}


		public class region3blueprint11 : EncounterBlueprintData
		{
			public region3blueprint11()
			{
				base.name = "region3blueprint11";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxSapphire")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("GemFiend")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("GemFiend")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxSapphire")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_bunnymage")
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
					card = CardLoader.GetCardByName("FlyingMage")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("GemFiend")
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
					card = CardLoader.GetCardByName("mag_magimorph")
				},
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
					card = CardLoader.GetCardByName("GemFiend")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_crystalworm")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxSapphire")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("GemFiend")
					}
				});
			}
		}

		public class region3blueprint12 : EncounterBlueprintData
		{
			public region3blueprint12()
			{
				base.name = "region3blueprint12";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_sapphiremech")
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
					card = CardLoader.GetCardByName("StimMage")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_sapphiremech")
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
					card = CardLoader.GetCardByName("StimMage")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxEmerald")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MarrowMage")
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
				new EncounterBlueprintData.CardBlueprint()
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_sapphiremech")
				}
			});
			}
		}

		public class region3blueprint13 : EncounterBlueprintData
		{
			public region3blueprint13()
			{
				base.name = "region3blueprint13";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_erraticscholar")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_gemdetonator")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxSapphire")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxEmerald")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_gemdetonator")
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
					card = CardLoader.GetCardByName("mag_gemabsorber")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_sapphiremech")
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
					card = CardLoader.GetCardByName("mag_erraticscholar")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_gemshield")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_whitesmith")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxRuby")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxEmerald")
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
					card = CardLoader.GetCardByName("mag_sapphiremech")
				}
			});
			}
		}

		public class region3blueprint14 : EncounterBlueprintData
		{
			public region3blueprint14()
			{
				base.name = "region3blueprint14";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_valkyrie")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxSapphire")
				}
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
					card = CardLoader.GetCardByName("FlyingMage")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("FlyingMage")
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
					card = CardLoader.GetCardByName("mag_valkyrie")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("RubyGolem")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_magimorph")
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
					card = CardLoader.GetCardByName("FlyingMage")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_valkyrie")
				}
			});
			}
		}

		public class region3blueprint15 : EncounterBlueprintData
		{
			public region3blueprint15()
			{
				base.name = "region3blueprint15";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxEmerald")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_bleenesmonster")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxSapphire")
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
					card = CardLoader.GetCardByName("mag_bleenehound")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("GreenMage")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxSapphire")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("GreenMage")
				}

			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("MoxEmerald")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_sodamage")
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
					card = CardLoader.GetCardByName("mag_sodamage")
				}
			});
			}
		}

		public class region3blueprint16 : EncounterBlueprintData
		{
			public region3blueprint16()
			{
				base.name = "region3blueprint16";
				this.turns = new List<List<EncounterBlueprintData.CardBlueprint>>();
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_rubyfiend")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_crystalworm")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("MageKnight")
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
						card = CardLoader.GetCardByName("StimMage")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("RubyGolem")
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
						card = CardLoader.GetCardByName("MuscleMage")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_rubyfiend")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("MarrowMage")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_alchemist")
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
						card = CardLoader.GetCardByName("mag_alchemist")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_rubyfiend")
					}
				});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
				{
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("JuniorSage")
					}
				});
			}
		}

	}
}