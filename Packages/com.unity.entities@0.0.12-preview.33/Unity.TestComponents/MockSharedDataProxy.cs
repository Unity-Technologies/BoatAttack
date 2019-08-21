using System;

namespace Unity.Entities.Tests
{
    [Serializable]
    public struct MockSharedData : ISharedComponentData
    {
        public int Value;
    }

    [UnityEngine.AddComponentMenu("Hidden/DontUse")]
    public class MockSharedDataProxy : SharedComponentDataProxy<MockSharedData>
    {
    }
}