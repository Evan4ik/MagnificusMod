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

namespace MagnificusMod
{
    public class BossPedestalRotator : MainInputInteractable
    {
		public int IconIndex { get; set; }
		public override CursorType CursorType
		{
			get
			{
				return CursorType.Rotate;
			}
		}


		public override void OnCursorSelectStart()
		{
			if (!this.rotating)
			{
				if (GameObject.Find("Cursor").transform.position.x < 0)
				{
						this.rotating = true;
						AudioController.Instance.PlaySound3D("stone_object_short#4", MixerGroup.ExplorationSFX, base.transform.position, 1f, 0f, new AudioParams.Pitch(AudioParams.Pitch.Variation.Small), null, null, null, false);
						var instance = this;
						Tween.Rotate(this.rotator, new Vector3(0f, -90f, 0f), Space.Self, 0.2f, 0f, Tween.EaseOut, Tween.LoopType.None, null, delegate
						{
							instance.rotating = false;
						}, true);
						this.IconIndex = IconIndex - 1;
						if (this.IconIndex < 0)
						{
							this.IconIndex = this.iconTextures.Count - 1;
						}
						this.rendererIndex--;
						if (this.rendererIndex < 0)
						{
							this.rendererIndex = this.iconRenderers.Count - 1;
						}
						this.UpdateIcon();
						Action rotated2 = this.Rotated;
						if (rotated2 == null)
						{
							return;
						}
						rotated2();
						return;
				}
				this.rotating = true;
				AudioController.Instance.PlaySound3D("stone_object_short#4", MixerGroup.ExplorationSFX, base.transform.position, 1f, 0f, new AudioParams.Pitch(AudioParams.Pitch.Variation.Small), null, null, null, false);
				Tween.Rotate(this.rotator, new Vector3(0f, 90f, 0f), Space.Self, 0.2f, 0f, Tween.EaseOut, Tween.LoopType.None, null, delegate
				{
					this.rotating = false;
				}, true);
				this.IconIndex = IconIndex + 1;
				if (this.IconIndex >= this.iconTextures.Count)
				{
					this.IconIndex = 0;
				}
				this.rendererIndex++;
				if (this.rendererIndex >= this.iconRenderers.Count)
				{
					this.rendererIndex = 0;
				}
				this.UpdateIcon();
				Action rotated = this.Rotated;
				if (rotated == null)
				{
					return;
				}
				rotated();
			}
		}

		public void UpdateIcon()
		{
			this.iconRenderers[this.rendererIndex].material.mainTexture = this.iconTextures[this.IconIndex];
		}



		public IEnumerator deleteTheUseless(GameObject rotator)
        {
			rotator.GetComponent<BoxCollider>().size = new Vector3(0, 0, 0);
			yield return new WaitForSeconds(0.5f);
			rotator.GetComponent<GemPedestalRotator3D>().enabled = false;
			rotator.GetComponent<MagnificusMod.BossPedestalRotator>().iconTextures = rotator.GetComponent<GemPedestalRotator3D>().iconTextures;
			rotator.GetComponent<MagnificusMod.BossPedestalRotator>().rotator = rotator.GetComponent<GemPedestalRotator3D>().rotator;
			rotator.GetComponent<MagnificusMod.BossPedestalRotator>().iconRenderers = rotator.GetComponent<GemPedestalRotator3D>().iconRenderers;
			switch (base.gameObject.name)
			{
				case "Rotator_Top":
					this.startIndex = 0;
					break;
				case "Rotator_Mid":
					this.startIndex = 1;
					break;
				case "Rotator_Bot":
					this.startIndex = 2;
					break;
			}
			this.IconIndex = this.startIndex;
			DestroyImmediate(rotator.GetComponent<GemPedestalRotator3D>());
			rotator.GetComponent<BoxCollider>().size = new Vector3(4, 2, 4);
			this.UpdateIcon();
			yield break;
        }

		public Action Rotated;

		[Header("Gem Pedestal")]
		[SerializeField]
		public int startIndex;

		[SerializeField]
		public List<Renderer> iconRenderers;

		[SerializeField]
		public List<Texture> iconTextures;

		[SerializeField]
		public Transform rotator;

		public bool rotating;

		public int rendererIndex;
	}
}
