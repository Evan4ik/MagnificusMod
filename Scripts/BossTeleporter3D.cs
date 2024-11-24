using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using DiskCardGame;

namespace MagnificusMod
{
    public class BossTeleporter3D : ManagedBehaviour
    {
		public List<MagnificusMod.BossPedestalRotator> rotators2 = new List<MagnificusMod.BossPedestalRotator>();

		public int[] Solution = new int[]
		{
			0,
			10,
			2
		};

		public List<Texture> textureOverrides = new List<Texture>();

		private void Awake()
		{
			textureOverrides = new List<Texture> { Tools.getImage("ability_drawcopyondeath_scratched_black.png"), Tools.getImage("ability_strafepush_scratched_black.png"), Tools.getImage("ability_tripleblood_scratched_black.png"),
			Tools.getImage("ability_whackamole_scratched_black.png"), Tools.getImage("ability_submerge_scratched_black.png")};

			List<Texture> textureOverrides2 = new List<Texture>(Singleton<GemPedestalRotator3D>.Instance.iconTextures);
			textureOverrides2[1] = Singleton<MagnificusMod.BossTeleporter3D>.Instance.textureOverrides[0];
			textureOverrides2[6] = Singleton<MagnificusMod.BossTeleporter3D>.Instance.textureOverrides[1];
			textureOverrides2[7] = Singleton<MagnificusMod.BossTeleporter3D>.Instance.textureOverrides[2];
			textureOverrides2[9] = Singleton<MagnificusMod.BossTeleporter3D>.Instance.textureOverrides[3];
			textureOverrides2[11] = Singleton<MagnificusMod.BossTeleporter3D>.Instance.textureOverrides[4];

			Singleton<GemPedestalRotator3D>.Instance.iconTextures = textureOverrides2;

		}

	}
}
