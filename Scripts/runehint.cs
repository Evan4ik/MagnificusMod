using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using DiskCardGame;
using Pixelplacement;
using SavedVars = MagnificusMod.SaveVariables;

namespace MagnificusMod
{
	public class RuneHint : MainInputInteractable
	{
		public int solutionIdx = 0;

		public void revealSolution()
        {
			for (int i = 0; i < 3; i++)
			{
				GameObject pedestalSprite2 = base.transform.GetChild(i).gameObject;
				int savedI = (i);
				Tween.LocalScale(pedestalSprite2.transform, Vector3.zero, 0.75f, 0.5f * i, null, Tween.LoopType.None, null, new Action(delegate {

					if (savedI != solutionIdx)
					{
						pedestalSprite2.GetComponent<SpriteRenderer>().sprite = Tools.getSprite("pedestal_clue_dot.png");
                    } else
                    {
						int[] solution = SavedVars.BossTeleportSolution;
						int solutionSprite = solution[solutionIdx];
						string solutionName = Singleton<GemPedestalRotator3D>.Instance.iconTextures[solutionSprite].name;
						if (solutionName.Contains("_black"))
						{
							string[] splitName = solutionName.Split(new string[] { "_black" }, StringSplitOptions.None);
							solutionName = splitName[0] + splitName[1];
						}
						pedestalSprite2.GetComponent<SpriteRenderer>().sprite = Tools.getSprite(solutionName + ".png");
					}
					

				}));
				Tween.LocalScale(pedestalSprite2.transform, (i == solutionIdx) ? new Vector3(6, 6, 6) : new Vector3(2, 2, 2), 0.55f, 1.35f * (i + 1));
			}
		}

	}
}
