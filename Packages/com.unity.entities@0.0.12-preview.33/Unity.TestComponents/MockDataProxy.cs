using System;
using UnityEngine;

namespace Unity.Entities.Tests
{
    [Serializable]
    public struct MockData : IComponentData
    {
        public int Value;
    }

    [DisallowMultipleComponent]
    [UnityEngine.AddComponentMenu("Hidden/DontUse")]
    public class MockDataProxy : ComponentDataProxy<MockData>
    {
    }
}