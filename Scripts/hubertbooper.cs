using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using DiskCardGame;
using Pixelplacement;

namespace MagnificusMod
{
	public class hubertbooper : MainInputInteractable
	{
		public override void OnCursorSelectStart()
		{
			Tween.LocalScale(base.gameObject.transform, new Vector3(0.25f, 0.2f, 0.25f), 0.25f, 0);
			Tween.LocalScale(base.gameObject.transform, new Vector3(0.25f, 0.25f, 0.25f), 0.25f, 0.251f);
			AudioController.Instance.PlaySound3D("hoo", MixerGroup.TableObjectsSFX, base.transform.position, 10f, 0f, new AudioParams.Pitch(AudioParams.Pitch.Variation.VerySmall), null, null, null, false);
		}
	}
}
