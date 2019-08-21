using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Unity.Collections;

#pragma warning disable 0649
#pragma warning disable 0219 // assigned but its value is never used

namespace Unity.Entities.Tests
{
    public class BufferElementDataInstantiateTests : ECSTestsFixture
    {
        [Test]
        public unsafe void InstantiateCreatesCopyOverflow()
        {
            var original = m_Manager.CreateEntity(typeof(EcsIntElement));
            var buffer = m_Manager.GetBuffer<EcsIntElement>(original);
            buffer.CopyFrom(new EcsIntElement[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }); // greater than 8
            var clone = m_Manager.Instantiate(original);

            buffer = m_Manager.GetBuffer<EcsIntElement>(original);
            var buffer2 = m_Manager.GetBuffer<EcsIntElement>(clone);

            Assert.AreNotEqual((UIntPtr)buffer.GetUnsafePtr(), (UIntPtr)buffer2.GetUnsafePtr());
            Assert.AreEqual(buffer.Length, buffer2.Length);
            for (int i = 0; i < buffer.Length; ++i)
            {
                Assert.AreEqual(buffer[i].Value, buffer2[i].Value);
            }
        }

        [Test]
        public unsafe void InstantiateCreatesCopyInternal()
        {
            var original = m_Manager.CreateEntity(typeof(EcsIntElement));
            var buffer = m_Manager.GetBuffer<EcsIntElement>(original);
            buffer.CopyFrom(new EcsIntElement[] { 1, 2, 3 }); // smaller than 8

            var clone = m_Manager.Instantiate(original);

            buffer = m_Manager.GetBuffer<EcsIntElement>(original);
            var buffer2 = m_Manager.GetBuffer<EcsIntElement>(clone);

            Assert.AreNotEqual((UIntPtr)buffer.GetUnsafePtr(), (UIntPtr)buffer2.GetUnsafePtr());
            Assert.AreEqual(buffer.Length, buffer2.Length);
            for (int i = 0; i < buffer.Length; ++i)
            {
                Assert.AreEqual(buffer[i].Value, buffer2[i].Value);
            }
        }

        struct MockData0 : IComponentData { public double Value; }

	    struct MockData1 : IComponentData { public double Value; }

	    [InternalBufferCapacity(BufferCapacity)]
	    struct MockElement : IBufferElementData
	    {
	        public const int BufferCapacity = 5;
	        public byte Value;
	    }

	    [Test]
	    public void DuplicatingEntity_WhenPrototypeHasDynamicBuffer_DoesNotWriteOutOfBounds()
	    {
	        // ensure there are two different archetypes
	        var prototype0 = m_Manager.CreateEntity();
	        m_Manager.AddComponent(prototype0, typeof(MockData0));
	        var buffer = m_Manager.AddBuffer<MockElement>(prototype0);
	        for (var i = 0; i < MockElement.BufferCapacity; ++i)
	            buffer.Add(new MockElement { Value = 0 });

	        var prototype1 = m_Manager.CreateEntity();
	        m_Manager.AddComponent(prototype1, typeof(MockData1));
	        buffer = m_Manager.AddBuffer<MockElement>(prototype1);
	        for (var i = 0; i < MockElement.BufferCapacity; ++i)
	            buffer.Add(new MockElement { Value = 0 });

	        // set up test data
	        var prototypes = (IReadOnlyList<Entity>)new[] { prototype0, prototype1 };
	        var duplicates = (IReadOnlyList<NativeArray<Entity>>)new []
	        {
	            new NativeArray<Entity>(100, Allocator.Temp),
	            new NativeArray<Entity>(100, Allocator.Temp)
	        };
	        var testValuesEven = (IReadOnlyList<IReadOnlyList<byte>>)new[]
	        {
	            Enumerable.Range(0, MockElement.BufferCapacity).Select(e => (byte)13).ToArray(),
	            Enumerable.Range(0, MockElement.BufferCapacity).Select(e => (byte)17).ToArray()
	        };
	        var testValuesOdd = (IReadOnlyList<IReadOnlyList<byte>>)new[] { testValuesEven[1], testValuesEven[0] };

	        var verifiedDuplicates = new HashSet<Entity>();

	        try
	        {
	            // alternate duplicating each different prototype so chunks are adjusted between duplications
	            for (var iteration = 0; iteration < 3; ++iteration)
	            {
	                // alternate values written to each set of duplicates with each iteration to detect out-of-bounds writing
	                var testValues = (iteration & 1) == 0 ? testValuesEven : testValuesOdd;

	                // first duplicate both of the prototypes
	                for (var prototypeIndex = 0; prototypeIndex < prototypes.Count; ++prototypeIndex)
	                {
	                    // write test values to prototype
	                    var prototype = prototypes[prototypeIndex];
	                    buffer = m_Manager.GetBuffer<MockElement>(prototype);
	                    var testValue = testValues[prototypeIndex];
	                    for (var i = 0; i < testValue.Count; ++i)
	                        buffer[i] = new MockElement { Value = testValue[i] };

	                    // duplicate prototype
	                    m_Manager.Instantiate(prototype, duplicates[prototypeIndex]);
	                }

	                // verify duplicates' buffers have expected values
	                for (var prototypeIndex = 0; prototypeIndex < prototypes.Count; ++prototypeIndex)
	                {
	                    var testValue = testValues[prototypeIndex];
	                    foreach (var duplicate in duplicates[prototypeIndex])
	                    {
	                        Assert.That(verifiedDuplicates, Has.None.EqualTo(duplicate));
	                        verifiedDuplicates.Add(duplicate);

	                        var b = m_Manager.GetBuffer<MockElement>(duplicate);
	                        Assert.That(
	                            Enumerable.Range(0, b.Length).Select(i => b[i].Value).ToArray(), Is.EqualTo(testValue),
	                            $"Invalid data for duplicate of prototype {prototypeIndex} on iteration {iteration}."
	                        );
	                    }
	                }
	            }
	        }
	        finally
	        {
	            foreach (var duplicate in duplicates)
	                duplicate.Dispose();
	        }
	    }
    }
}

#pragma warning restore 0649
#pragma warning restore 0219 // assigned but its value is never used


