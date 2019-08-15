using System;
using Unity.Entities;
using Unity.Mathematics;

namespace Unity.Transforms
{
    [UnityEngine.DisallowMultipleComponent]
    [UnityEngine.AddComponentMenu("DOTS/Deprecated/Rotation-Deprecated")]
    public class RotationProxy : ComponentDataProxy<Rotation>
    {
        protected override void ValidateSerializedData(ref Rotation serializedData)
        {
            serializedData.Value = math.normalizesafe(serializedData.Value);
        }
    }
}
