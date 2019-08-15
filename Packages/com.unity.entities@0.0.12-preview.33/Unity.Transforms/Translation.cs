using System;
using System.ComponentModel;
using Unity.Entities;
using Unity.Mathematics;

namespace Unity.Transforms
{
    [Obsolete("Position has been renamed. Use Translation instead (UnityUpgradable) -> Translation", true)]
    [System.ComponentModel.EditorBrowsable(EditorBrowsableState.Never)]
    public struct Position : IComponentData { public float3 Value; }

    [Serializable]
    [WriteGroup(typeof(LocalToWorld))]
    [WriteGroup(typeof(LocalToParent))]
    public struct Translation : IComponentData
    {
        public float3 Value;
    }
}
