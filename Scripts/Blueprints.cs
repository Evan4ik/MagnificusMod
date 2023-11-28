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
						card = CardLoader.GetCardByName("mag_jrsage")
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
						card = CardLoader.GetCardByName("mag_jrsage")
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
						card = CardLoader.GetCardByName("mag_stimmage")
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
						card = CardLoader.GetCardByName("mag_jrsage")
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
					card = CardLoader.GetCardByName("mag_greenmox")
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
					card = CardLoader.GetCardByName("mag_greenmox")
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
					card = CardLoader.GetCardByName("mag_greenmox")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_stimmage")
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
					card = CardLoader.GetCardByName("mag_greenmox")
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
					card = CardLoader.GetCardByName("mag_jrsage")
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
					card = CardLoader.GetCardByName("mag_orangemage")
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
					card = CardLoader.GetCardByName("mag_orangemage")
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
					card = CardLoader.GetCardByName("mag_orangemage")
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
					card = CardLoader.GetCardByName("mag_crystalworm")
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
					card = CardLoader.GetCardByName("mag_rubygolem")
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
					card = CardLoader.GetCardByName("mag_crystalworm")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_knightmage")
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
					card = CardLoader.GetCardByName("mag_practicemage")
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
					card = CardLoader.GetCardByName("mag_bluemox")
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
					card = CardLoader.GetCardByName("mag_hovermage")
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
					card = CardLoader.GetCardByName("mag_gemfiend")
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
					card = CardLoader.GetCardByName("mag_hovermage")
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
					card = CardLoader.GetCardByName("mag_rubymox")
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
					card = CardLoader.GetCardByName("mag_greenmox")
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
					card = CardLoader.GetCardByName("mag_greenmox")
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
					card = CardLoader.GetCardByName("mag_greenmox")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_orangemage")
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
					card = CardLoader.GetCardByName("mag_practicemage")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_bullfrog")
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
					card = CardLoader.GetCardByName("mag_moxlarva")
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

		public class secretFightBlueprint : EncounterBlueprintData
		{
			public secretFightBlueprint()
			{
				base.name = "secretFightBlueprint";
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
					card = CardLoader.GetCardByName("mag_greenmox")
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
					card = CardLoader.GetCardByName("mag_drake")
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
					card = CardLoader.GetCardByName("mag_almondcookie")
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
					card = CardLoader.GetCardByName("mag_invisimage")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_homunculus")
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
					card = CardLoader.GetCardByName("mag_crystalworm")
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
					card = CardLoader.GetCardByName("mag_duncemage")
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
					card = CardLoader.GetCardByName("mag_alchemist")
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
					card = CardLoader.GetCardByName("mag_forcemage")
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
					card = CardLoader.GetCardByName("mag_greenmox")
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
					card = CardLoader.GetCardByName("mag_greenmox")
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
					card = CardLoader.GetCardByName("mag_rubymox")
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
					card = CardLoader.GetCardByName("mag_bluemox")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_gemdetonator")
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
					card = CardLoader.GetCardByName("mag_gemdetonator")
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
					card = CardLoader.GetCardByName("mag_bluemox")
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
					card = CardLoader.GetCardByName("mag_gemdetonator")
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
					card = CardLoader.GetCardByName("mag_rubymox")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_gemdetonator")
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
					card = CardLoader.GetCardByName("mag_rubymox")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_gemshield")
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
					card = CardLoader.GetCardByName("mag_rubymox")
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
					card = CardLoader.GetCardByName("mag_rubymox")
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
					card = CardLoader.GetCardByName("mag_musclemage")
				},
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
					card = CardLoader.GetCardByName("mag_greenmox")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_musclemage")
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
					card = CardLoader.GetCardByName("mag_bunnymage")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_bullfrog")
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
					card = CardLoader.GetCardByName("mag_gemfiend")
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
					card = CardLoader.GetCardByName("mag_greenmox")
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
					card = CardLoader.GetCardByName("mag_greenmox")
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
					card = CardLoader.GetCardByName("mag_musclemage")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_jrsage")
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
					card = CardLoader.GetCardByName("mag_jrsage")
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
					card = CardLoader.GetCardByName("mag_musclemage")
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
					card = CardLoader.GetCardByName("mag_rubymox")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_greenmage")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_rubygolem")
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
					card = CardLoader.GetCardByName("mag_rubymox")
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
					card = CardLoader.GetCardByName("mag_hpspell")
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
					card = CardLoader.GetCardByName("mag_rubymox")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_greenmage")
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
						card = CardLoader.GetCardByName("mag_knightmage")
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
						card = CardLoader.GetCardByName("mag_knightmage")
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
						card = CardLoader.GetCardByName("mag_crystalworm")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_orangemage")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_rubymox")
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
						card = CardLoader.GetCardByName("mag_rubygolem")
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
						card = CardLoader.GetCardByName("mag_bluemox")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_hovermage")
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
						card = CardLoader.GetCardByName("mag_bluemox")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_gemfiend")
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
						card = CardLoader.GetCardByName("mag_hovermage")
					},
					new EncounterBlueprintData.CardBlueprint
					{
						card = CardLoader.GetCardByName("mag_hovermage")
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
						card = CardLoader.GetCardByName("mag_rubymox")
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
						card = CardLoader.GetCardByName("mag_greenmage")
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
						card = CardLoader.GetCardByName("mag_crystalworm")
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
					card = CardLoader.GetCardByName("mag_forcemage")
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
					card = CardLoader.GetCardByName("mag_forcemage")
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
					card = CardLoader.GetCardByName("mag_bluemox")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_gemfiend")
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
					card = CardLoader.GetCardByName("mag_hovermage")
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
					card = CardLoader.GetCardByName("mag_bluemox")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_bluemox")
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
					card = CardLoader.GetCardByName("mag_bluemox")
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
					card = CardLoader.GetCardByName("mag_gemfiend")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_hovermage")
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
					card = CardLoader.GetCardByName("mag_greenmage")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_greenmage")
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
					card = CardLoader.GetCardByName("mag_bluemox")
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
					card = CardLoader.GetCardByName("mag_orangemage")
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
					card = CardLoader.GetCardByName("mag_stimmage")
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
					card = CardLoader.GetCardByName("mag_alchemist")
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
					card = CardLoader.GetCardByName("mag_stimmage")
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
					card = CardLoader.GetCardByName("mag_bluemox")
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
					card = CardLoader.GetCardByName("mag_rubymox")
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
					card = CardLoader.GetCardByName("mag_orangemage")
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
					card = CardLoader.GetCardByName("mag_rubygolem")
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
					card = CardLoader.GetCardByName("mag_bluemox")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_gemfiend")
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
					card = CardLoader.GetCardByName("mag_bluemox")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_gemfiend")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_magepupil")
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
					card = CardLoader.GetCardByName("mag_knightmage")
				}
			});
				this.turns.Add(new List<EncounterBlueprintData.CardBlueprint>
			{
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_stimmage")
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
					card = CardLoader.GetCardByName("mag_bluemox")
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
					card = CardLoader.GetCardByName("mag_orangemage")
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
					card = CardLoader.GetCardByName("mag_orangemage")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_orangemage")
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
					card = CardLoader.GetCardByName("mag_gemfiend")
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
					card = CardLoader.GetCardByName("mag_knightmage")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_gemfiend")
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
					card = CardLoader.GetCardByName("mag_orangemage")
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
					card = CardLoader.GetCardByName("mag_bluemox")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_hovermage")
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
					card = CardLoader.GetCardByName("mag_bullfrog")
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
					card = CardLoader.GetCardByName("mag_stimmage")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_gemfiend")
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
					card = CardLoader.GetCardByName("mag_rubymox")
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
					card = CardLoader.GetCardByName("mag_jrsage")
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
					card = CardLoader.GetCardByName("mag_stimmage")
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
					card = CardLoader.GetCardByName("mag_musclemage")
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
					card = CardLoader.GetCardByName("mag_greenmox")
				},
				new EncounterBlueprintData.CardBlueprint
				{
					card = CardLoader.GetCardByName("mag_greenmox")
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
					card = CardLoader.GetCardByName("mag_greenmox")
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
					card = CardLoader.GetCardByName("mag_gemfiend")
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
					card = CardLoader.GetCardByName("mag_practicemage")
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
	}
}