using NUnit.Framework;
using Unity.Collections;
using Unity.Entities.Tests;
using Unity.PerformanceTesting;

namespace Unity.Entities.PerformanceTests
{
    public sealed unsafe class EntityManagerPerformanceTests
    {
        World m_PreviousWorld;
        World m_World;
        EntityManager m_Manager;
        EntityArchetype archetype1;
        EntityArchetype archetype2;
        EntityArchetype archetype3;
        NativeArray<Entity> entities1;
        NativeArray<Entity> entities2;
        NativeArray<Entity> entities3;
        EntityQuery group;

        const int count = 1024 * 128;

        [SetUp]
        public void Setup()
        {
            m_PreviousWorld = World.Active;
            m_World = World.Active = new World("Test World");
            m_Manager = m_World.EntityManager;
            archetype1 = m_Manager.CreateArchetype(typeof(EcsTestData), typeof(EcsTestData2), typeof(EcsTestData3));
            archetype2 = m_Manager.CreateArchetype(typeof(EcsTestData), typeof(EcsTestData2));
            archetype3 = m_Manager.CreateArchetype(typeof(EcsTestData), typeof(EcsTestData3));
            entities1 = new NativeArray<Entity>(count, Allocator.Persistent);
            entities2 = new NativeArray<Entity>(count, Allocator.Persistent);
            entities3 = new NativeArray<Entity>(count, Allocator.Persistent);
            group = m_Manager.CreateEntityQuery(typeof(EcsTestData));
        }

        [TearDown]
        public void TearDown()
        {
            if (m_Manager != null)
            {
                entities1.Dispose();
                entities2.Dispose();
                entities3.Dispose();
                group.Dispose();

                m_World.Dispose();
                m_World = null;

                World.Active = m_PreviousWorld;
                m_PreviousWorld = null;
                m_Manager = null;
            }
        }

        void CreateEntities()
        {
            m_Manager.CreateEntity(archetype1, entities1);
            m_Manager.CreateEntity(archetype2, entities2);
            m_Manager.CreateEntity(archetype3, entities3);
        }

        void DestroyEntities()
        {
            m_Manager.DestroyEntity(entities1);
            m_Manager.DestroyEntity(entities2);
            m_Manager.DestroyEntity(entities3);
        }

        #if UNITY_2019_2_OR_NEWER
        [Test, Performance]
        #else
        [PerformanceTest]
        #endif
        public void AddComponentWithGroup()
        {
            Measure.Method(() =>
                {
                    m_Manager.AddComponent(group, typeof(EcsTestData4));
                })
                .SetUp(CreateEntities)
                .CleanUp(DestroyEntities)
                .Run();
        }

        #if UNITY_2019_2_OR_NEWER
        [Test, Performance]
        #else
        [PerformanceTest]
        #endif
        public void AddTagComponentWithGroup()
        {
            Measure.Method(() =>
                {
                    m_Manager.AddComponent(group, typeof(EcsTestTag));
                })
                .SetUp(CreateEntities)
                .CleanUp(DestroyEntities)
                .Run();
        }

        #if UNITY_2019_2_OR_NEWER
        [Test, Performance]
        #else
        [PerformanceTest]
        #endif
        public void AddSharedComponentWithGroup()
        {
            Measure.Method(() =>
                {
                    m_Manager.AddSharedComponentData(group, new EcsTestSharedComp(7));
                })
                .SetUp(CreateEntities)
                .CleanUp(DestroyEntities)
                .Run();
        }

        #if UNITY_2019_2_OR_NEWER
        [Test, Performance]
        #else
        [PerformanceTest]
        #endif
        public void AddChunkComponentWithGroup()
        {
            Measure.Method(() =>
                {
                    m_Manager.AddChunkComponentData(group, new EcsTestData4(7));
                })
                .SetUp(CreateEntities)
                .CleanUp(DestroyEntities)
                .Run();
        }

        #if UNITY_2019_2_OR_NEWER
        [Test, Performance]
        #else
        [PerformanceTest]
        #endif
        public void RemoveComponentWithGroup()
        {
            Measure.Method(() =>
                {
                    m_Manager.RemoveComponent(group, typeof(EcsTestData4));
                })
                .SetUp(() =>
                {
                    CreateEntities();
                    m_Manager.AddComponent(group, typeof(EcsTestData4));
                })
                .CleanUp(DestroyEntities)
                .Run();
        }

        #if UNITY_2019_2_OR_NEWER
        [Test, Performance]
        #else
        [PerformanceTest]
        #endif
        public void RemoveTagComponentWithGroup()
        {
            Measure.Method(() =>
                {
                    m_Manager.RemoveComponent(group, typeof(EcsTestTag));
                })
                .SetUp(() =>
                {
                    CreateEntities();
                    m_Manager.AddComponent(group, typeof(EcsTestTag));
                })
                .CleanUp(DestroyEntities)
                .Run();
        }

        #if UNITY_2019_2_OR_NEWER
        [Test, Performance]
        #else
        [PerformanceTest]
        #endif
        public void RemoveSharedComponentWithGroup()
        {
            Measure.Method(() =>
                {
                    m_Manager.RemoveComponent(group, typeof(EcsTestSharedComp));
                })
                .SetUp(() =>
                {
                    CreateEntities();
                    m_Manager.AddSharedComponentData(group, new EcsTestSharedComp(7));
                })
                .CleanUp(DestroyEntities)
                .Run();
        }

        #if UNITY_2019_2_OR_NEWER
        [Test, Performance]
        #else
        [PerformanceTest]
        #endif
        public void RemoveChunkComponentWithGroup()
        {
            Measure.Method(() =>
                {
                    m_Manager.RemoveChunkComponentData<EcsTestData4>(group);
                })
                .SetUp(() =>
                {
                    CreateEntities();
                    m_Manager.AddChunkComponentData(group, new EcsTestData4(7));
                })
                .CleanUp(DestroyEntities)
                .Run();
        }
    }
}
