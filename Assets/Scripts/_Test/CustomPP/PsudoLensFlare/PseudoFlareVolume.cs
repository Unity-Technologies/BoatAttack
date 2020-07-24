using System;
using UnityEngine;
using UnityEngine.Rendering;

[Serializable, VolumeComponentMenu("Custom/Pseudo Lensflare")]
public class PseudoFlareVolume : VolumeComponent
{
    [Range(0f, 1f), Tooltip("Grayscale effect intensity")]
    public FloatParameter blend = new FloatParameter(0.5f);
}
