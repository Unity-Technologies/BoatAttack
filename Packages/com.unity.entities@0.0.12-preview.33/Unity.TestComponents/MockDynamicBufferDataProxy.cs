using System;
using UnityEngine;

namespace Unity.Entities.Tests
{
    [Serializable]
    public struct MockDynamicBufferData : IBufferElementData
    {
        public int Value;
    }

    [DisallowMultipleComponent]
    public class MockDynamicBufferDataProxy : DynamicBufferProxy<MockDynamicBufferData>
    {

    }
}