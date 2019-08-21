using System;
using Unity.Entities;

namespace Unity.Transforms
{
    [UnityEngine.DisallowMultipleComponent]
    [UnityEngine.AddComponentMenu("DOTS/Deprecated/Translation-Deprecated")]
    public class TranslationProxy : ComponentDataProxy<Translation>
    {
    }
}
