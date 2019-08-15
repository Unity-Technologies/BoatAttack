using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using Unity.PerformanceTesting;
using Unity.Entities;

namespace Unity.Entities.PerformanceTests
{
    [TestFixture]
    [Category("Performance")]
    public sealed class EntityCommandBufferPerformanceTests
    {
        private World m_PreviousWorld;
        private World m_World;
        private EntityManager m_Manager;

        [SetUp]
        public void Setup()
        {
            m_PreviousWorld = World.Active;
            m_World = World.Active = new World("Test World");
            m_Manager = m_World.EntityManager;
        }

        public struct EcsTestData : IComponentData
        {
            public int value;
        }

        private void FillWithEcsTestData(EntityCommandBuffer cmds, int repeat)
        {
            for (int i = repeat; i != 0; --i)
            {
                var e = cmds.CreateEntity();
                cmds.AddComponent(e, new EcsTestData {value = i});
            }
        }

        #if UNITY_2019_2_OR_NEWER
        [Test, Performance]
        #else
        [PerformanceTest]
        #endif
        public void EntityCommandBuffer_512SimpleEntities()
        {
            const int kCreateLoopCount = 512;
            const int kPlaybackLoopCount = 1000;

            var ecbs = new List<EntityCommandBuffer>(kPlaybackLoopCount);
            Measure.Method(
                () =>
                {
                    for (int repeat = 0; repeat < kPlaybackLoopCount; ++repeat)
                    {
                        var cmds = new EntityCommandBuffer(Allocator.TempJob);
                        FillWithEcsTestData(cmds, kCreateLoopCount);
                        ecbs.Add(cmds);
                    }
                })
                .Definition("CreateEntities")
                .WarmupCount(0)
                .MeasurementCount(1)
                .Run();

            Measure.Method(
                () =>
                {
                    for (int repeat = 0; repeat < kPlaybackLoopCount; ++repeat)
                    {
                        ecbs[repeat].Playback(m_Manager);
                    }
                })
                .Definition("Playback")
                .WarmupCount(0)
                .MeasurementCount(1)
                .CleanUp(() =>
                {
                })
                .Run();

            foreach (var ecb in ecbs)
            {
                ecb.Dispose();
            }
        }

        struct EcsTestDataWithEntity : IComponentData
        {
            public int value;
            public Entity entity;
        }

        private void FillWithEcsTestDataWithEntity(EntityCommandBuffer cmds, int repeat)
        {
            for (int i = repeat; i != 0; --i)
            {
                var e = cmds.CreateEntity();
                cmds.AddComponent(e, new EcsTestDataWithEntity {value = i});
            }
        }

        #if UNITY_2019_2_OR_NEWER
        [Test, Performance]
        #else
        [PerformanceTest]
        #endif
        public void EntityCommandBuffer_512EntitiesWithEmbeddedEntity()
        {
            const int kCreateLoopCount = 512;
            const int kPlaybackLoopCount = 1000;

            var ecbs = new List<EntityCommandBuffer>(kPlaybackLoopCount);
            Measure.Method(
                    () =>
                    {
                        for (int repeat = 0; repeat < kPlaybackLoopCount; ++repeat)
                        {
                            var cmds = new EntityCommandBuffer(Allocator.TempJob);
                            FillWithEcsTestDataWithEntity(cmds, kCreateLoopCount);
                            ecbs.Add(cmds);
                        }
                    })
                .Definition("CreateEntities")
                .WarmupCount(0)
                .MeasurementCount(1)
                .Run();
            Measure.Method(
                    () =>
                    {
                        for (int repeat = 0; repeat < kPlaybackLoopCount; ++repeat)
                        {
                            ecbs[repeat].Playback(m_Manager);
                        }
                    })
                .Definition("Playback")
                .WarmupCount(0)
                .MeasurementCount(1)
                .Run();
            foreach (var ecb in ecbs)
            {
                ecb.Dispose();
            }
        }

#if UNITY_2019_2_OR_NEWER
        [Test, Performance]
        #else
        [PerformanceTest]
        #endif
        public void EntityCommandBuffer_OneEntityWithEmbeddedEntityAnd512SimpleEntities()
        {
            // This test should not be any slower than EntityCommandBuffer_SimpleEntities_512x1000
            // It shows that adding one component that needs fix up will not make the fast
            // path any slower

            const int kCreateLoopCount = 512;
            const int kPlaybackLoopCount = 1000;


            var ecbs = new List<EntityCommandBuffer>(kPlaybackLoopCount);
            Measure.Method(
                    () =>
                    {
                        for (int repeat = 0; repeat < kPlaybackLoopCount; ++repeat)
                        {
                            var cmds = new EntityCommandBuffer(Allocator.TempJob);
                            Entity e0 = cmds.CreateEntity();
                            cmds.AddComponent(e0, new EcsTestDataWithEntity {value = -1, entity = e0 });
                            FillWithEcsTestData(cmds, kCreateLoopCount);
                            ecbs.Add(cmds);
                        }
                    })
                .Definition("CreateEntities")
                .WarmupCount(0)
                .MeasurementCount(1)
                .Run();
            Measure.Method(
                    () =>
                    {
                        for (int repeat = 0; repeat < kPlaybackLoopCount; ++repeat)
                            ecbs[repeat].Playback(m_Manager);
                    })
                .Definition("Playback")
                .WarmupCount(0)
                .MeasurementCount(1)
                .Run();
            foreach (var ecb in ecbs)
            {
                ecb.Dispose();
            }
        }
    }
}

