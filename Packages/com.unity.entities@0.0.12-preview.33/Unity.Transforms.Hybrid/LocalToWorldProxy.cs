using System;
using Unity.Entities;

namespace Unity.Transforms
{
    [UnityEngine.DisallowMultipleComponent]
    [UnityEngine.AddComponentMenu("DOTS/Deprecated/LocalToWorldProxy-Deprecated")]
    public class LocalToWorldProxy : ComponentDataProxy<LocalToWorld>
    {
    }
}
