using System;
using NUnit.Framework;
using Unity.Collections;

// ******* COPY AND PASTE WARNING *************
// NOTE: Duplicate tests (with only type differences)
// - SystemStateComponentTests.cs and SystemStateBufferElementTests.cs
// - Any change to this file should be reflected in the other file.
// Changes between two files:
// - s/SystemStateComponentTests/SystemStateBufferElementTests/
// - s/EcsState1/EcsIntStateElement/g
// - Add VerifyBufferCount to SystemStateBufferElementTests
// - SystemStateBufferElementTests calls VerifyBufferCount instead of VerifyComponentCount on EcsIntStateElement
// - SetSharedComponent in SystemStateComponentTests:
//               m_Manager.SetComponentData(entity, new EcsState1(2));
//   Replaced with GetBuffer:
//               var buffer = m_Manager.GetBuffer<EcsIntStateElement>(entity);
//               buffer.Add(2);
// ******* COPY AND PASTE WARNING *************

namespace Unity.Entities.Tests
{
    [TestFixture]
    class SystemStateBufferElementTests : ECSTestsFixture
    {
        void VerifyComponentCount<T>(int expectedCount)
            where T : IComponentData
        {
            var group = m_Manager.CreateEntityQuery(ComponentType.ReadWrite<T>());
            var chunks = group.CreateArchetypeChunkArray(Allocator.TempJob);
            group.Dispose();
            Assert.AreEqual(expectedCount, ArchetypeChunkArray.CalculateEntityCount(chunks));
            chunks.Dispose();
        }

        void VerifyBufferCount<T>(int expectedCount)
            where T : ISystemStateBufferElementData
        {
            var group = m_Manager.CreateEntityQuery(ComponentType.ReadWrite<T>());
            var chunks = group.CreateArchetypeChunkArray(Allocator.TempJob);
            group.Dispose();
            Assert.AreEqual(expectedCount, ArchetypeChunkArray.CalculateEntityCount(chunks));
            chunks.Dispose();
        }

        void VerifyQueryCount(EntityQuery group, int expectedCount)
        {
            var chunks = group.CreateArchetypeChunkArray(Allocator.TempJob);
            Assert.AreEqual(expectedCount, ArchetypeChunkArray.CalculateEntityCount(chunks));
            chunks.Dispose();
        }

        [Test]
        [StandaloneFixme] // ISharedComponentData
        public void DeleteWhenEmpty()
        {
            var entity = m_Manager.CreateEntity(
                typeof(EcsTestData),
                typeof(EcsTestSharedComp),
                typeof(EcsIntStateElement)
            );

            m_Manager.SetComponentData(entity, new EcsTestData(1));
            var buffer = m_Manager.GetBuffer<EcsIntStateElement>(entity);
            buffer.Add(2);
            m_Manager.SetSharedComponentData(entity, new EcsTestSharedComp(3));

            VerifyComponentCount<EcsTestData>(1);

            m_Manager.DestroyEntity(entity);

            VerifyComponentCount<EcsTestData>(0);
            VerifyBufferCount<EcsIntStateElement>(1);

            m_Manager.RemoveComponent<EcsIntStateElement>(entity);

            VerifyBufferCount<EcsIntStateElement>(0);

            Assert.IsFalse(m_Manager.Exists(entity));
        }

        [Test]
        [StandaloneFixme] // ISharedComponentData
        public void DeleteWhenEmptyArray()
        {
            var entities = new Entity[512];

            for (var i = 0; i < 512; i++)
            {
                var entity = m_Manager.CreateEntity(
                    typeof(EcsTestData),
                    typeof(EcsTestSharedComp),
                    typeof(EcsIntStateElement)
                );
                entities[i] = entity;

                m_Manager.SetComponentData(entity, new EcsTestData(i));
                var buffer = m_Manager.GetBuffer<EcsIntStateElement>(entity);
                buffer.Add(2);
                m_Manager.SetSharedComponentData(entity, new EcsTestSharedComp(i % 7));
            }

            VerifyComponentCount<EcsTestData>(512);

            for (var i = 0; i < 512; i += 2)
            {
                var entity = entities[i];
                m_Manager.DestroyEntity(entity);
            }

            VerifyComponentCount<EcsTestData>(256);
            VerifyBufferCount<EcsIntStateElement>(512);
            VerifyQueryCount(m_Manager.CreateEntityQuery(
                ComponentType.Exclude<EcsTestData>(),
                ComponentType.ReadWrite<EcsIntStateElement>()), 256);

            for (var i = 0; i < 512; i += 2)
            {
                var entity = entities[i];
                m_Manager.RemoveComponent<EcsIntStateElement>(entity);
            }

            VerifyBufferCount<EcsIntStateElement>(256);

            for (var i = 0; i < 512; i += 2)
            {
                var entity = entities[i];
                Assert.IsFalse(m_Manager.Exists(entity));
            }

            for (var i = 1; i < 512; i += 2)
            {
                var entity = entities[i];
                Assert.IsTrue(m_Manager.Exists(entity));
            }
        }

        [Test]
        [StandaloneFixme] // ISharedComponentData
        public void DeleteWhenEmptyArray2()
        {
            var entities = new Entity[512];

            for (var i = 0; i < 512; i++)
            {
                var entity = m_Manager.CreateEntity(
                    typeof(EcsTestData),
                    typeof(EcsTestSharedComp),
                    typeof(EcsIntStateElement)
                );
                entities[i] = entity;

                m_Manager.SetComponentData(entity, new EcsTestData(i));
                var buffer = m_Manager.GetBuffer<EcsIntStateElement>(entity);
                buffer.Add(i);
                m_Manager.SetSharedComponentData(entity, new EcsTestSharedComp(i % 7));
            }

            VerifyComponentCount<EcsTestData>(512);

            for (var i = 0; i < 256; i++)
            {
                var entity = entities[i];
                m_Manager.DestroyEntity(entity);
            }

            VerifyComponentCount<EcsTestData>(256);
            VerifyBufferCount<EcsIntStateElement>(512);
            VerifyQueryCount(m_Manager.CreateEntityQuery(
                ComponentType.Exclude<EcsTestData>(),
                ComponentType.ReadWrite<EcsIntStateElement>()), 256);

            for (var i = 0; i < 256; i++)
            {
                var entity = entities[i];
                m_Manager.RemoveComponent<EcsIntStateElement>(entity);
            }

            VerifyBufferCount<EcsIntStateElement>(256);

            for (var i = 0; i < 256; i++)
            {
                var entity = entities[i];
                Assert.IsFalse(m_Manager.Exists(entity));
            }

            for (var i = 256; i < 512; i++)
            {
                var entity = entities[i];
                Assert.IsTrue(m_Manager.Exists(entity));
            }
        }

        [Test]
        [StandaloneFixme] // ISharedComponentData
        public void DoNotInstantiateSystemState()
        {
            var entity0 = m_Manager.CreateEntity(
                typeof(EcsTestData),
                typeof(EcsTestSharedComp),
                typeof(EcsIntStateElement)
            );

            m_Manager.Instantiate(entity0);

            VerifyBufferCount<EcsIntStateElement>(1);
        }

        [Test]
        public void InstantiateResidueEntityThrows()
        {
            var entity0 = m_Manager.CreateEntity(
                typeof(EcsTestData),
                typeof(EcsIntStateElement)
            );

            m_Manager.DestroyEntity(entity0);
            Assert.Throws<ArgumentException>(() => m_Manager.Instantiate(entity0));
        }
        
        [Test]
        [StandaloneFixme] // Test Error
        public void DeleteFromEntity()
        {
            var entities = new Entity[512];

            for (var i = 0; i < 512; i++)
            {
                var entity = m_Manager.CreateEntity(
                    typeof(EcsTestData),
                    typeof(EcsIntStateElement)
                );
                entities[i] = entity;

                m_Manager.SetComponentData(entity, new EcsTestData(i));
                var buffer = m_Manager.GetBuffer<EcsIntStateElement>(entity);
                buffer.Add(i);          }

            VerifyComponentCount<EcsTestData>(512);

            for (var i = 0; i < 512; i++)
            {
                var entity = entities[i];
                m_Manager.DestroyEntity(entity);
            }

            VerifyComponentCount<EcsTestData>(0);
            VerifyBufferCount<EcsIntStateElement>(512);

            var group = m_Manager.CreateEntityQuery(
                ComponentType.Exclude<EcsTestData>(),
                ComponentType.ReadWrite<EcsIntStateElement>());
            
            for (var i = 0; i < 512; i++)
            {
                var entity = entities[i];
                m_Manager.RemoveComponent(entity,typeof(EcsIntStateElement));
            }
            
            VerifyBufferCount<EcsIntStateElement>(0);

            for (var i = 0; i < 512; i++)
            {
                var entity = entities[i];
                Assert.IsFalse(m_Manager.Exists(entity));
            }
        }
        
        [Test]
        public void DeleteFromEntityQuery()
        {
            var entities = new Entity[512];

            for (var i = 0; i < 512; i++)
            {
                var entity = m_Manager.CreateEntity(
                    typeof(EcsTestData),
                    typeof(EcsIntStateElement)
                );
                entities[i] = entity;

                m_Manager.SetComponentData(entity, new EcsTestData(i));
                var buffer = m_Manager.GetBuffer<EcsIntStateElement>(entity);
                buffer.Add(i);
            }

            VerifyComponentCount<EcsTestData>(512);

            for (var i = 0; i < 512; i++)
            {
                var entity = entities[i];
                m_Manager.DestroyEntity(entity);
            }

            VerifyComponentCount<EcsTestData>(0);
            VerifyBufferCount<EcsIntStateElement>(512);

            var group = m_Manager.CreateEntityQuery(
                ComponentType.Exclude<EcsTestData>(),
                ComponentType.ReadWrite<EcsIntStateElement>());
            
            m_Manager.RemoveComponent(group,typeof(EcsIntStateElement));
            
            VerifyBufferCount<EcsIntStateElement>(0);

            for (var i = 0; i < 512; i++)
            {
                var entity = entities[i];
                Assert.IsFalse(m_Manager.Exists(entity));
            }
        }

        [Test]
        public void DeleteTagFromEntityQuery()
        {
            var entities = new Entity[512];

            for (var i = 0; i < 512; i++)
            {
                var entity = m_Manager.CreateEntity(
                    typeof(EcsTestData),
                    typeof(EcsIntStateElement)
                );
                entities[i] = entity;

                m_Manager.SetComponentData(entity, new EcsTestData(i));
            }

            VerifyComponentCount<EcsTestData>(512);

            for (var i = 0; i < 512; i++)
            {
                var entity = entities[i];
                m_Manager.DestroyEntity(entity);
            }

            VerifyComponentCount<EcsTestData>(0);
            VerifyBufferCount<EcsIntStateElement>(512);

            var group = m_Manager.CreateEntityQuery(
                ComponentType.Exclude<EcsTestData>(),
                ComponentType.ReadWrite<EcsIntStateElement>());

            m_Manager.RemoveComponent(group,typeof(EcsIntStateElement));

            VerifyBufferCount<EcsIntStateElement>(0);

            for (var i = 0; i < 512; i++)
            {
                var entity = entities[i];
                Assert.IsFalse(m_Manager.Exists(entity));
            }
        }
    }
}
