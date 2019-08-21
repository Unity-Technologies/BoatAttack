using System;
using NUnit.Framework;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities.Tests;
using Unity.Mathematics;
using Unity.PerformanceTesting;

namespace Unity.Entities.PerformanceTests
{
    class InstantiatePerformanceTests : ECSTestsFixture
    {
        public enum EntityType
        {
            BasicData,
            EmptyHierarchy,
            Hierarchy_10,
        }

        Entity CreateEntity(EntityType type)
        {
            if (type == EntityType.BasicData)
                return m_Manager.CreateEntity(typeof(EcsTestData), typeof(EcsTestData2), typeof(EcsTestDataEntity), typeof(Prefab));
            else if (type == EntityType.EmptyHierarchy)
            {
                var entity = m_Manager.CreateEntity(typeof(EcsTestData), typeof(EcsTestData2), typeof(Prefab));
                m_Manager.AddBuffer<LinkedEntityGroup>(entity);
                m_Manager.GetBuffer<LinkedEntityGroup>(entity).Add(entity);
                return entity;
            }
            else if (type == EntityType.Hierarchy_10)
            {
                var entity = m_Manager.CreateEntity(typeof(EcsTestData), typeof(EcsTestData2), typeof(Prefab));
                m_Manager.AddBuffer<LinkedEntityGroup>(entity);
                m_Manager.GetBuffer<LinkedEntityGroup>(entity).Add(entity);

                for (int i = 0; i != 9; i++)
                {
                    var child = m_Manager.CreateEntity(typeof(EcsTestData), typeof(EcsTestData2), typeof(EcsTestDataEntity), typeof(Prefab));
                    m_Manager.GetBuffer<LinkedEntityGroup>(entity).Add(child);
                }

                return entity;
            }
            throw new NotImplementedException();
        }

        unsafe static NativeArray<T> ArraySlice<T>(NativeArray<T> array, int startIndex, int count) where T: struct
        {
            var ptr = (byte*) NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(array);
            var sliced = NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<T>(ptr + startIndex * UnsafeUtility.SizeOf<T>(), count, Allocator.Invalid);
            NativeArrayUnsafeUtility.SetAtomicSafetyHandle(ref sliced, NativeArrayUnsafeUtility.GetAtomicSafetyHandle(array));
            return sliced;
        }



        #if UNITY_2019_2_OR_NEWER
        [Test, Performance]
        #else
        [PerformanceTest]
        #endif
        public void InstantiateBatch_100k([Values(1, 10, 100, 1000)]int batchSize, [Values]EntityType entityType)
        {
            Entity srcEntity = default(Entity);

            var totalCount = 100 * 1000;
            if (entityType == EntityType.Hierarchy_10)
                totalCount /= 10;

            var entities = new NativeArray<Entity>(totalCount, Allocator.Temp);

            srcEntity = CreateEntity(entityType);

            Measure.Method(
                    () =>
                    {
                        for (int i = 0; i != totalCount; i += batchSize)
                        {
                            var actualBatchCount = math.min(batchSize, totalCount - i);
                            m_Manager.Instantiate(srcEntity, ArraySlice(entities, i, actualBatchCount));
                        }
                    })
                .CleanUp(() =>
                {
                    m_Manager.DestroyEntity(entities);
                    Assert.IsTrue(m_Manager.Debug.EntityCount <= 10);
                })
                .IterationsPerMeasurement(1) //@TODO: Ask gyntautas what the idea behind IterationsPerMeasurement is.
                .Run();

            entities.Dispose();
        }

        //@TODO: Couldn't figure out how to make this test be a single one with above...
        #if UNITY_2019_2_OR_NEWER
        [Test, Performance]
        #else
        [PerformanceTest]
        #endif
        public void DestroyBatch_100k([Values(1, 10, 100, 1000)]int batchSize, [Values]EntityType entityType)
        {
            Entity srcEntity = default(Entity);

            var totalCount = 100 * 1000;
            if (entityType == EntityType.Hierarchy_10)
                totalCount /= 10;

            var entities = new NativeArray<Entity>(totalCount, Allocator.Temp);

            srcEntity = CreateEntity(entityType);

            Measure.Method(
                    () =>
                    {
                        for (int i = 0; i != totalCount; i += batchSize)
                        {
                            var actualBatchCount = math.min(batchSize, totalCount - i);
                            m_Manager.DestroyEntity(ArraySlice(entities, i, actualBatchCount));
                        }
                    })
                .SetUp(() =>
                {
                    Assert.IsTrue(m_Manager.Debug.EntityCount <= 10);
                    m_Manager.Instantiate(srcEntity, entities);
                })
                .IterationsPerMeasurement(1) //@TODO: Ask gyntautas what the idea behind IterationsPerMeasurement is.
                .Run();

            entities.Dispose();
        }
    }
}
