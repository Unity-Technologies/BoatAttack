using System;
using System.Linq;
using NUnit.Framework;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;

namespace Unity.Entities.Tests
{
    [TestFixture]
    class ComponentGroupTests : ECSTestsFixture
    {
            ArchetypeChunk[] CreateEntitiesAndReturnChunks(EntityArchetype archetype, int entityCount, Action<Entity> action = null)
        {
            var entities = new NativeArray<Entity>(entityCount, Allocator.Temp);
            m_Manager.CreateEntity(archetype, entities);
#if NET_DOTS
            var managedEntities = new Entity[entities.Length];
            for (int i = 0; i < entities.Length; i++)
            {
                managedEntities[i] = entities[i];
            }
#else
            var managedEntities = entities.ToArray();
#endif
            entities.Dispose();

            if(action != null)
                foreach(var e in managedEntities)
                    action(e);

            return managedEntities.Select(e => m_Manager.GetChunk(e)).Distinct().ToArray();
        }

        [Test]
        public void CreateArchetypeChunkArray()
        {
            var archetype1 = m_Manager.CreateArchetype(typeof(EcsTestData));
            var archetype2 = m_Manager.CreateArchetype(typeof(EcsTestData2));
            var archetype12 = m_Manager.CreateArchetype(typeof(EcsTestData), typeof(EcsTestData2));

            var createdChunks1 = CreateEntitiesAndReturnChunks(archetype1, 5000);
            var createdChunks2 = CreateEntitiesAndReturnChunks(archetype2, 5000);
            var createdChunks12 = CreateEntitiesAndReturnChunks(archetype12, 5000);

            var allCreatedChunks = createdChunks1.Concat(createdChunks2).Concat(createdChunks12);

            var group1 = m_Manager.CreateEntityQuery(typeof(EcsTestData));
            var group12 = m_Manager.CreateEntityQuery(typeof(EcsTestData), typeof(EcsTestData2));

            var queriedChunks1 = group1.CreateArchetypeChunkArray(Allocator.TempJob);
            var queriedChunks12 = group12.CreateArchetypeChunkArray(Allocator.TempJob);
            var queriedChunksAll = m_Manager.GetAllChunks(Allocator.TempJob);

            CollectionAssert.AreEquivalent(createdChunks1.Concat(createdChunks12), queriedChunks1);
            CollectionAssert.AreEquivalent(createdChunks12, queriedChunks12);
            CollectionAssert.AreEquivalent(allCreatedChunks,queriedChunksAll);

            queriedChunks1.Dispose();
            queriedChunks12.Dispose();
            queriedChunksAll.Dispose();
        }

        void SetShared(Entity e, int i)
        {
            m_Manager.SetSharedComponentData(e, new EcsTestSharedComp(i));
        }

        [Test]
        public void CreateArchetypeChunkArray_FiltersSharedComponents()
        {
            var archetype1 = m_Manager.CreateArchetype(typeof(EcsTestData), typeof(EcsTestSharedComp));
            var archetype2 = m_Manager.CreateArchetype(typeof(EcsTestData2), typeof(EcsTestSharedComp));

            var createdChunks1 = CreateEntitiesAndReturnChunks(archetype1, 5000, e => SetShared(e, 1));
            var createdChunks2 = CreateEntitiesAndReturnChunks(archetype2, 5000, e => SetShared(e, 1));
            var createdChunks3 = CreateEntitiesAndReturnChunks(archetype1, 5000, e => SetShared(e, 2));
            var createdChunks4 = CreateEntitiesAndReturnChunks(archetype2, 5000, e => SetShared(e, 2));

            var group = m_Manager.CreateEntityQuery(typeof(EcsTestSharedComp));

            group.SetFilter(new EcsTestSharedComp(1));

            var queriedChunks1 = group.CreateArchetypeChunkArray(Allocator.TempJob);

            group.SetFilter(new EcsTestSharedComp(2));

            var queriedChunks2 = group.CreateArchetypeChunkArray(Allocator.TempJob);

            CollectionAssert.AreEquivalent(createdChunks1.Concat(createdChunks2), queriedChunks1);
            CollectionAssert.AreEquivalent(createdChunks3.Concat(createdChunks4), queriedChunks2);

            group.Dispose();
            queriedChunks1.Dispose();
            queriedChunks2.Dispose();
        }

        void SetShared(Entity e, int i, int j)
        {
            m_Manager.SetSharedComponentData(e, new EcsTestSharedComp(i));
            m_Manager.SetSharedComponentData(e, new EcsTestSharedComp2(j));
        }

        [Test]
        public void CreateArchetypeChunkArray_FiltersTwoSharedComponents()
        {
            var archetype1 = m_Manager.CreateArchetype(typeof(EcsTestData), typeof(EcsTestSharedComp), typeof(EcsTestSharedComp2));
            var archetype2 = m_Manager.CreateArchetype(typeof(EcsTestData2), typeof(EcsTestSharedComp), typeof(EcsTestSharedComp2));

            var createdChunks1 = CreateEntitiesAndReturnChunks(archetype1, 5000, e => SetShared(e, 1,7));
            var createdChunks2 = CreateEntitiesAndReturnChunks(archetype2, 5000, e => SetShared(e, 1,7));
            var createdChunks3 = CreateEntitiesAndReturnChunks(archetype1, 5000, e => SetShared(e, 2,7));
            var createdChunks4 = CreateEntitiesAndReturnChunks(archetype2, 5000, e => SetShared(e, 2,7));
            var createdChunks5 = CreateEntitiesAndReturnChunks(archetype1, 5000, e => SetShared(e, 1,8));
            var createdChunks6 = CreateEntitiesAndReturnChunks(archetype2, 5000, e => SetShared(e, 1,8));
            var createdChunks7 = CreateEntitiesAndReturnChunks(archetype1, 5000, e => SetShared(e, 2,8));
            var createdChunks8 = CreateEntitiesAndReturnChunks(archetype2, 5000, e => SetShared(e, 2,8));

            var group = m_Manager.CreateEntityQuery(typeof(EcsTestSharedComp), typeof(EcsTestSharedComp2));

            group.SetFilter(new EcsTestSharedComp(1), new EcsTestSharedComp2(7));
            var queriedChunks1 = group.CreateArchetypeChunkArray(Allocator.TempJob);

            group.SetFilter(new EcsTestSharedComp(2), new EcsTestSharedComp2(7));
            var queriedChunks2 = group.CreateArchetypeChunkArray(Allocator.TempJob);

            group.SetFilter(new EcsTestSharedComp(1), new EcsTestSharedComp2(8));
            var queriedChunks3 = group.CreateArchetypeChunkArray(Allocator.TempJob);

            group.SetFilter(new EcsTestSharedComp(2), new EcsTestSharedComp2(8));
            var queriedChunks4 = group.CreateArchetypeChunkArray(Allocator.TempJob);


            CollectionAssert.AreEquivalent(createdChunks1.Concat(createdChunks2), queriedChunks1);
            CollectionAssert.AreEquivalent(createdChunks3.Concat(createdChunks4), queriedChunks2);
            CollectionAssert.AreEquivalent(createdChunks5.Concat(createdChunks6), queriedChunks3);
            CollectionAssert.AreEquivalent(createdChunks7.Concat(createdChunks8), queriedChunks4);

            group.Dispose();
            queriedChunks1.Dispose();
            queriedChunks2.Dispose();
            queriedChunks3.Dispose();
            queriedChunks4.Dispose();
        }

        void SetData(Entity e, int i)
        {
            m_Manager.SetComponentData(e, new EcsTestData(i));
        }

        [Test]
        public void  qCreateArchetypeChunkArray_FiltersChangeVersions()
        {
            var archetype1 = m_Manager.CreateArchetype(typeof(EcsTestData));
            var archetype2 = m_Manager.CreateArchetype(typeof(EcsTestData), typeof(EcsTestData2));
            var archetype3 = m_Manager.CreateArchetype(typeof(EcsTestData), typeof(EcsTestData3));

            m_ManagerDebug.SetGlobalSystemVersion(20);
            var createdChunks1 = CreateEntitiesAndReturnChunks(archetype1, 5000, e => SetData(e, 1));
            m_ManagerDebug.SetGlobalSystemVersion(30);
            var createdChunks2 = CreateEntitiesAndReturnChunks(archetype2, 5000, e => SetData(e, 2));
            m_ManagerDebug.SetGlobalSystemVersion(40);
            var createdChunks3 = CreateEntitiesAndReturnChunks(archetype3, 5000, e => SetData(e, 3));

            var group = m_Manager.CreateEntityQuery(typeof(EcsTestData));

            group.SetFilterChanged(typeof(EcsTestData));

            group.SetFilterChangedRequiredVersion(10);
            var queriedChunks1 = group.CreateArchetypeChunkArray(Allocator.TempJob);

            group.SetFilterChangedRequiredVersion(20);
            var queriedChunks2 = group.CreateArchetypeChunkArray(Allocator.TempJob);

            group.SetFilterChangedRequiredVersion(30);
            var queriedChunks3 = group.CreateArchetypeChunkArray(Allocator.TempJob);

            group.SetFilterChangedRequiredVersion(40);
            var queriedChunks4 = group.CreateArchetypeChunkArray(Allocator.TempJob);

            CollectionAssert.AreEquivalent(createdChunks1.Concat(createdChunks2).Concat(createdChunks3), queriedChunks1);
            CollectionAssert.AreEquivalent(createdChunks2.Concat(createdChunks3), queriedChunks2);
            CollectionAssert.AreEquivalent(createdChunks3, queriedChunks3);

            Assert.AreEqual(0, queriedChunks4.Length);

            group.Dispose();
            queriedChunks1.Dispose();
            queriedChunks2.Dispose();
            queriedChunks3.Dispose();
            queriedChunks4.Dispose();
        }

        void SetData(Entity e, int i, int j)
        {
            m_Manager.SetComponentData(e, new EcsTestData(i));
            m_Manager.SetComponentData(e, new EcsTestData2(j));
        }

        [Test]
        public void CreateArchetypeChunkArray_FiltersTwoChangeVersions()
        {
            var archetype1 = m_Manager.CreateArchetype(typeof(EcsTestData), typeof(EcsTestData2));
            var archetype2 = m_Manager.CreateArchetype(typeof(EcsTestData), typeof(EcsTestData2), typeof(EcsTestData3));
            var archetype3 = m_Manager.CreateArchetype(typeof(EcsTestData), typeof(EcsTestData2), typeof(EcsTestData4));

            m_ManagerDebug.SetGlobalSystemVersion(20);
            var createdChunks1 = CreateEntitiesAndReturnChunks(archetype1, 5000, e => SetData(e, 1, 4));
            m_ManagerDebug.SetGlobalSystemVersion(30);
            var createdChunks2 = CreateEntitiesAndReturnChunks(archetype2, 5000, e => SetData(e, 2, 5));
            m_ManagerDebug.SetGlobalSystemVersion(40);
            var createdChunks3 = CreateEntitiesAndReturnChunks(archetype3, 5000, e => SetData(e, 3, 6));

            var group = m_Manager.CreateEntityQuery(typeof(EcsTestData), typeof(EcsTestData2));

            group.SetFilterChanged(new ComponentType[]{typeof(EcsTestData), typeof(EcsTestData2)});

            group.SetFilterChangedRequiredVersion(30);

            var testType1 = m_Manager.GetArchetypeChunkComponentType<EcsTestData>(false);
            var testType2 = m_Manager.GetArchetypeChunkComponentType<EcsTestData2>(false);

            var queriedChunks1 = group.CreateArchetypeChunkArray(Allocator.TempJob);

            foreach (var chunk in createdChunks1)
            {
                var array = chunk.GetNativeArray(testType1);
                array[0] = new EcsTestData(7);
            }

            var queriedChunks2 = group.CreateArchetypeChunkArray(Allocator.TempJob);

            foreach (var chunk in createdChunks2)
            {
                var array = chunk.GetNativeArray(testType2);
                array[0] = new EcsTestData2(7);
            }

            var queriedChunks3 = group.CreateArchetypeChunkArray(Allocator.TempJob);


            CollectionAssert.AreEquivalent(createdChunks3, queriedChunks1);
            CollectionAssert.AreEquivalent(createdChunks1.Concat(createdChunks3), queriedChunks2);

            group.Dispose();
            queriedChunks1.Dispose();
            queriedChunks2.Dispose();
            queriedChunks3.Dispose();
        }

        // https://github.com/Unity-Technologies/dots/issues/1098
        [Test]
        public void TestIssue1098()
        {
            m_Manager.CreateEntity(typeof(EcsTestData));

            using
            (
                var group = m_Manager.CreateEntityQuery
                (
                    new EntityQueryDesc
                    {
                        All = new ComponentType[] {typeof(EcsTestData)}
                    }
                )
            )
            // NB: EcsTestData != EcsTestData2
            Assert.Throws<InvalidOperationException>(() => group.ToComponentDataArray<EcsTestData2>(Allocator.TempJob));
        }

#if !UNITY_DOTSPLAYER

        [AlwaysUpdateSystem]
        public class WriteEcsTestDataSystem : JobComponentSystem
        {
            private struct WriteJob : IJobForEach<EcsTestData>
            {
                public void Execute(ref EcsTestData c0) {}
            }

            protected override JobHandle OnUpdate(JobHandle input)
            {
                var job = new WriteJob() {};
                return job.Schedule(this, input);
            }
        }

        [Test]
        public unsafe void CreateArchetypeChunkArray_SyncsChangeFilterTypes()
        {
            var group = m_Manager.CreateEntityQuery(typeof(EcsTestData));
            group.SetFilterChanged(typeof(EcsTestData));
            var ws1 = World.GetOrCreateSystem<WriteEcsTestDataSystem>();
            ws1.Update();
            var safetyHandle = m_Manager.ComponentJobSafetyManager->GetSafetyHandle(TypeManager.GetTypeIndex<EcsTestData>(), false);

            Assert.Throws<InvalidOperationException>(() => AtomicSafetyHandle.CheckWriteAndThrow(safetyHandle));
            var chunks = group.CreateArchetypeChunkArray(Allocator.TempJob);
            AtomicSafetyHandle.CheckWriteAndThrow(safetyHandle);

            chunks.Dispose();
            group.Dispose();
        }

        [Test]
        public unsafe void CalculateLength_SyncsChangeFilterTypes()
        {
            var group = m_Manager.CreateEntityQuery(typeof(EcsTestData));
            group.SetFilterChanged(typeof(EcsTestData));
            var ws1 = World.GetOrCreateSystem<WriteEcsTestDataSystem>();
            ws1.Update();
            var safetyHandle = m_Manager.ComponentJobSafetyManager->GetSafetyHandle(TypeManager.GetTypeIndex<EcsTestData>(), false);

            Assert.Throws<InvalidOperationException>(() => AtomicSafetyHandle.CheckWriteAndThrow(safetyHandle));
            group.CalculateLength();
            AtomicSafetyHandle.CheckWriteAndThrow(safetyHandle);

            group.Dispose();
        }
#endif

        [Test]
        public void ToEntityArrayOnFilteredGroup()
        {
            // Note - test is setup so that each entity is in its own chunk, this checks that entity indices are correct
            var a = m_Manager.CreateEntity(typeof(EcsTestSharedComp), typeof(EcsTestData));
            var b = m_Manager.CreateEntity(typeof(EcsTestSharedComp), typeof(EcsTestData2));
            var c = m_Manager.CreateEntity(typeof(EcsTestSharedComp), typeof(EcsTestData3));

            m_Manager.SetSharedComponentData(a, new EcsTestSharedComp {value = 123});
            m_Manager.SetSharedComponentData(b, new EcsTestSharedComp {value = 456});
            m_Manager.SetSharedComponentData(c, new EcsTestSharedComp {value = 123});

            using (var group = m_Manager.CreateEntityQuery(typeof(EcsTestSharedComp)))
            {
                group.SetFilter(new EcsTestSharedComp {value = 123});
                using (var entities = group.ToEntityArray(Allocator.TempJob))
                {
                    CollectionAssert.AreEquivalent(new[] {a, c}, entities);
                }
            }

            using (var group = m_Manager.CreateEntityQuery(typeof(EcsTestSharedComp)))
            {
                group.SetFilter(new EcsTestSharedComp {value = 456});
                using (var entities = group.ToEntityArray(Allocator.TempJob))
                {
                    CollectionAssert.AreEquivalent(new[] {b}, entities);
                }
            }
        }
    }
}
