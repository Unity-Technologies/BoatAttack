using System;
using System.Threading;
using NUnit.Framework;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using Unity.PerformanceTesting;
using Unity.Entities;
using Unity.Entities.Tests;

namespace Unity.Entities.PerformanceTests
{
    [TestFixture]
    [NUnit.Framework.Category("Performance")]
    public sealed class JobForEachPrefilteringPerformanceTests
    {
        private World m_PreviousWorld;
        private World m_World;
        private EntityManager m_Manager;

        private struct ProcessJob : IJobForEach<EcsTestData>
        {
            public void Execute(ref EcsTestData c0)
            {
                c0 = new EcsTestData {value = 10};
            }
        }

        [SetUp]
        public void Setup()
        {
            m_PreviousWorld = World.Active;
            m_World = World.Active = new World("Test World");
            m_Manager = m_World.EntityManager;
        }

        #if UNITY_2019_2_OR_NEWER
        [Test, Performance]
        #else
        [PerformanceTest]
        #endif
        public void Prefiltering_SingleArchetype_SingleChunk_Unfiltered()
        {
            const int kEntityCount = 10;

            var archetype = m_Manager.CreateArchetype(ComponentType.ReadWrite<EcsTestData>(), ComponentType.ReadWrite<EcsTestData2>());
            var group = m_Manager.CreateEntityQuery(ComponentType.ReadWrite<EcsTestData>(),ComponentType.ReadWrite<EcsTestData2>());
            var entities = new NativeArray<Entity>(kEntityCount, Allocator.TempJob);
            m_Manager.CreateEntity(archetype, entities);

            var dependsOn = new JobHandle();

            Measure.Method(
                    () =>
                    {
                        dependsOn = new ProcessJob().Schedule(group, dependsOn);
                    })
                .Definition("Scheduling")
                .Run();

            dependsOn.Complete();

            Measure.Method(
                    () =>
                    {
                        var job = new ProcessJob().Schedule(group);
                        job.Complete();
                    })
                .Definition("ScheduleAndRun")
                .Run();

            entities.Dispose();
        }

#if UNITY_2019_2_OR_NEWER
        [Test, Performance]
#else
        [PerformanceTest]
#endif
        public void Prefiltering_SingleArchetype_TwoChunks_Filtered()
        {
            const int kEntityCount = 10;

            var archetype = m_Manager.CreateArchetype(
                ComponentType.ReadWrite<EcsTestData>(),
                ComponentType.ReadWrite<EcsTestData2>(),
                ComponentType.ReadWrite<EcsTestSharedComp>());

            var group = m_Manager.CreateEntityQuery(
                ComponentType.ReadWrite<EcsTestData>(),
                ComponentType.ReadWrite<EcsTestData2>(),
                ComponentType.ReadWrite<EcsTestSharedComp>());

            var entities = new NativeArray<Entity>(kEntityCount, Allocator.TempJob);
            m_Manager.CreateEntity(archetype, entities);
            for (int i = kEntityCount / 2; i < kEntityCount; ++i)
            {
                m_Manager.SetSharedComponentData(entities[i], new EcsTestSharedComp{value = 10});
            }

            var dependsOn = new JobHandle();
            group.SetFilter(new EcsTestSharedComp {value = 10});

            Measure.Method(
                    () =>
                    {
                        dependsOn = new ProcessJob().Schedule(group, dependsOn);
                    })
                .Definition("Scheduling")
                .Run();

            dependsOn.Complete();

            Measure.Method(
                    () =>
                    {
                        var job = new ProcessJob().Schedule(group);
                        job.Complete();
                    })
                .Definition("ScheduleAndRun")
                .Run();

            entities.Dispose();
        }

#if UNITY_2019_2_OR_NEWER
        [Test, Performance]
#else
        [PerformanceTest]
#endif
        public void Prefiltering_SingleArchetype_MultipleChunks_Filtered()
        {
            const int kEntityCount = 10000;

            var archetype = m_Manager.CreateArchetype(
                ComponentType.ReadWrite<EcsTestData>(),
                ComponentType.ReadWrite<EcsTestData2>(),
                ComponentType.ReadWrite<EcsTestSharedComp>());

            var group = m_Manager.CreateEntityQuery(
                ComponentType.ReadWrite<EcsTestData>(),
                ComponentType.ReadWrite<EcsTestData2>(),
                ComponentType.ReadWrite<EcsTestSharedComp>());

            var entities = new NativeArray<Entity>(kEntityCount, Allocator.TempJob);
            m_Manager.CreateEntity(archetype, entities);

            for (int i = 0; i < kEntityCount; ++i)
            {
                m_Manager.SetSharedComponentData(entities[i], new EcsTestSharedComp {value = i % 10 } );
            }

            var dependsOn = new JobHandle();
            group.SetFilter(new EcsTestSharedComp{value = 0});

            Measure.Method(
                    () =>
                    {
                        dependsOn = new ProcessJob().Schedule(group, dependsOn);
                    })
                .Definition("Scheduling")
                .Run();

            dependsOn.Complete();

            Measure.Method(
                    () =>
                    {
                        var job = new ProcessJob().Schedule(group);
                        job.Complete();
                    })
                .Definition("ScheduleAndRun")
                .Run();

            entities.Dispose();
        }

#if UNITY_2019_2_OR_NEWER
        [Test, Performance]
#else
        [PerformanceTest]
#endif
        public void Prefiltering_MultipleArchetype_MultipleChunks_Filtered()
        {
            var allTypes = new ComponentType[5];
            allTypes[0] = ComponentType.ReadWrite<EcsTestSharedComp>();
            allTypes[1] = ComponentType.ReadWrite<EcsTestData>();
            allTypes[2] = ComponentType.ReadWrite<EcsTestData2>();
            allTypes[3] = ComponentType.ReadWrite<EcsTestData3>();
            allTypes[4] = ComponentType.ReadWrite<EcsTestData4>();

            var allArchetypes = new EntityArchetype[8];
            allArchetypes[0] = m_Manager.CreateArchetype(allTypes[0], allTypes[1]);
            allArchetypes[1] = m_Manager.CreateArchetype(allTypes[0], allTypes[1], allTypes[2]);
            allArchetypes[2] = m_Manager.CreateArchetype(allTypes[0], allTypes[1], allTypes[3]);
            allArchetypes[3] = m_Manager.CreateArchetype(allTypes[0], allTypes[1], allTypes[4]);
            allArchetypes[4] = m_Manager.CreateArchetype(allTypes[0], allTypes[1], allTypes[2], allTypes[3]);
            allArchetypes[5] = m_Manager.CreateArchetype(allTypes[0], allTypes[1], allTypes[2], allTypes[4]);
            allArchetypes[6] = m_Manager.CreateArchetype(allTypes[0], allTypes[1], allTypes[3], allTypes[4]);
            allArchetypes[7] = m_Manager.CreateArchetype(allTypes);

            const int kEntityCountPerArchetype = 1000;
            for (int i = 0; i < 8; ++i)
            {
                var entities = new NativeArray<Entity>(kEntityCountPerArchetype, Allocator.TempJob);
                m_Manager.CreateEntity(allArchetypes[i], entities);

                for (int j = 0; j < kEntityCountPerArchetype; ++j)
                {
                    m_Manager.SetSharedComponentData(entities[i], new EcsTestSharedComp {value = i % 10 } );
                }

                entities.Dispose();
            }

            var dependsOn = new JobHandle();
            var group = m_Manager.CreateEntityQuery(
                ComponentType.ReadWrite<EcsTestData>(),
                ComponentType.ReadWrite<EcsTestSharedComp>());
            group.SetFilter(new EcsTestSharedComp{value = 0});

            Measure.Method(
                    () =>
                    {
                        dependsOn = new ProcessJob().Schedule(group, dependsOn);
                    })
                .Definition("Scheduling")
                .Run();

            dependsOn.Complete();

            Measure.Method(
                    () =>
                    {
                        var job = new ProcessJob().Schedule(group);
                        job.Complete();
                    })
                .Definition("ScheduleAndRun")
                .Run();

        }
    }
}

