using System;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;

namespace Unity.Transforms
{
    [Serializable]
    [WriteGroup(typeof(LocalToWorld))]
    public struct Parent : IComponentData
    {
        public Entity Value;
    }

    [Serializable]
    public struct PreviousParent : ISystemStateComponentData
    {
        public Entity Value;
    }

    [Serializable]
    [InternalBufferCapacity(8)]
    [WriteGroup(typeof(ParentScaleInverse))]
    public struct Child : ISystemStateBufferElementData
    {
        public Entity Value;
    }
}