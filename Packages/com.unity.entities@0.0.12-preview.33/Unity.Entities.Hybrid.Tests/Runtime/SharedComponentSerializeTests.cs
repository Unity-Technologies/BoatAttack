//#define WRITE_TO_DISK

using System;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using Unity.Entities.Serialization;
using Object = UnityEngine.Object;
#pragma warning disable 649

namespace Unity.Entities.Tests
{
    class SharedComponentSerializeTests : ECSTestsFixture
    {
        [Test]
        public void SerializingSharedComponent_WhenMoreThanOne_AndProxyHasDisallowMultiple_DoesNotCrash()
        {
            for (var i = 0; i < 20; ++i)
            {
                var entity = m_Manager.CreateEntity();
                m_Manager.AddSharedComponentData(entity, new MockSharedDisallowMultiple { Value = i });
                m_Manager.AddComponentData(entity, new EcsTestData(i));
            }

            var writer = new TestBinaryWriter();
            GameObject sharedComponents = null;

            try
            {
                Assert.That(
                    () => SerializeUtilityHybrid.Serialize(m_Manager, writer, out sharedComponents),
                    Throws.ArgumentException.With.Message.Matches(@"\bDisallowMultipleComponent\b")
                );
            }
            finally
            {
                writer.Dispose();
                if (sharedComponents != null)
                    GameObject.DestroyImmediate(sharedComponents);
            }
        }

        [Test]
        public void SharedComponentSerialize()
        {
            for (int i = 0; i != 20; i++)
            {
                var entity = m_Manager.CreateEntity();
                m_Manager.AddSharedComponentData(entity, new MockSharedData { Value = i });
                m_Manager.AddComponentData(entity, new EcsTestData(i));
                var buffer = m_Manager.AddBuffer<EcsIntElement>(entity);
                foreach (var val in Enumerable.Range(i, i + 5))
                    buffer.Add(new EcsIntElement { Value = val });
            }

            var writer = new TestBinaryWriter();

            GameObject sharedComponents;
            SerializeUtilityHybrid.Serialize(m_Manager, writer, out sharedComponents);

            var reader = new TestBinaryReader(writer);

            var world = new World("temp");
            SerializeUtilityHybrid.Deserialize (world.EntityManager, reader, sharedComponents);

            var newWorldEntities = world.EntityManager;

            {
                var entities = newWorldEntities.GetAllEntities();

                Assert.AreEqual(20, entities.Length);

                for (int i = 0; i != 20; i++)
                {
                    Assert.AreEqual(i, newWorldEntities.GetComponentData<EcsTestData>(entities[i]).value);
                    Assert.AreEqual(i, newWorldEntities.GetSharedComponentData<MockSharedData>(entities[i]).Value);
                    var buffer = newWorldEntities.GetBuffer<EcsIntElement>(entities[i]);
                    Assert.That(
                        buffer.AsNativeArray().ToArray(),
                        Is.EqualTo(Enumerable.Range(i, i + 5).Select(x => new EcsIntElement { Value = x }))
                    );
                }
                for (int i = 0; i != 20; i++)
                    newWorldEntities.DestroyEntity(entities[i]);

                entities.Dispose();
            }

            Assert.IsTrue(newWorldEntities.Debug.IsSharedComponentManagerEmpty());

            world.Dispose();
            reader.Dispose();

            Object.DestroyImmediate(sharedComponents);
        }
    }
}
