using System;
using System.Linq;
using NUnit.Framework;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace Unity.Entities.Tests
{
    [StandaloneFixme] // MultiWorlds
    class MoveEntitiesFromTests : ECSTestsFixture
    {
        [Test]
        public void MoveEntitiesToSameEntityManagerThrows()
        {
            Assert.Throws<ArgumentException>(() => { m_Manager.MoveEntitiesFrom(m_Manager); });
        }

        [Test]
        public void MoveEntities()
        {
            var creationWorld = new World("CreationWorld");
            var creationManager = creationWorld.EntityManager;

            var archetype = creationManager.CreateArchetype(typeof(EcsTestData), typeof(EcsTestData2));

            var entities = new NativeArray<Entity>(10000, Allocator.Temp);
            creationManager.CreateEntity(archetype, entities);
            for (int i = 0; i != entities.Length; i++)
                creationManager.SetComponentData(entities[i], new EcsTestData(i));

            m_Manager.Debug.CheckInternalConsistency();
            creationManager.Debug.CheckInternalConsistency();

            m_Manager.MoveEntitiesFrom(creationManager);

            for (int i = 0;i != entities.Length;i++)
                Assert.IsFalse(creationManager.Exists(entities[i]));

            m_Manager.Debug.CheckInternalConsistency();
            creationManager.Debug.CheckInternalConsistency();

            var group = m_Manager.CreateEntityQuery(typeof(EcsTestData));
            Assert.AreEqual(entities.Length, group.CalculateLength());
            Assert.AreEqual(0, creationManager.CreateEntityQuery(typeof(EcsTestData)).CalculateLength());

            // We expect that the order of the crated entities is the same as in the creation scene
            var testDataArray = group.ToComponentDataArray<EcsTestData>(Allocator.TempJob);
            for (int i = 0; i != testDataArray.Length; i++)
                Assert.AreEqual(i, testDataArray[i].value);

            testDataArray.Dispose();
            entities.Dispose();
            creationWorld.Dispose();
        }

        [Test]
        public void MoveEntitiesWithSharedComponentData()
        {
            var creationWorld = new World("CreationWorld");
            var creationManager = creationWorld.EntityManager;

            var archetype = creationManager.CreateArchetype(typeof(EcsTestData), typeof(EcsTestData2), typeof(SharedData1));

            var entities = new NativeArray<Entity>(10000, Allocator.Temp);
            creationManager.CreateEntity(archetype, entities);
            for (int i = 0; i != entities.Length; i++)
            {
                creationManager.SetComponentData(entities[i], new EcsTestData(i));
                creationManager.SetSharedComponentData(entities[i], new SharedData1(i % 5));
            }

            m_Manager.Debug.CheckInternalConsistency();
            creationManager.Debug.CheckInternalConsistency();

            m_Manager.MoveEntitiesFrom(creationManager);

            m_Manager.Debug.CheckInternalConsistency();
            creationManager.Debug.CheckInternalConsistency();

            var group = m_Manager.CreateEntityQuery(typeof(EcsTestData), typeof(SharedData1));
            Assert.AreEqual(entities.Length, group.CalculateLength());
            Assert.AreEqual(0, creationManager.CreateEntityQuery(typeof(EcsTestData)).CalculateLength());

            // We expect that the shared component data matches the correct entities
            var chunks = group.CreateArchetypeChunkArray(Allocator.TempJob);
            for (int i = 0; i < chunks.Length; ++i)
            {
                var chunk = chunks[i];
                var shared = chunk.GetSharedComponentData(m_Manager.GetArchetypeChunkSharedComponentType<SharedData1>(), m_Manager);
                var testDataArray = chunk.GetNativeArray(m_Manager.GetArchetypeChunkComponentType<EcsTestData>(true));
                for (int j = 0; j < testDataArray.Length; ++j)
                {
                    Assert.AreEqual(shared.value, testDataArray[i].value % 5);
                }
            }

            chunks.Dispose();
            entities.Dispose();
            creationWorld.Dispose();
        }

        [Test]
        public void MoveEntitiesWithChunkComponents()
        {
            var creationWorld = new World("CreationWorld");
            var creationManager = creationWorld.EntityManager;

            var archetype = creationManager.CreateArchetype(typeof(EcsTestData), ComponentType.ChunkComponent<EcsTestData2>());

            var entities = new NativeArray<Entity>(10000, Allocator.Temp);
            creationManager.CreateEntity(archetype, entities);
            ArchetypeChunk currentChunk = ArchetypeChunk.Null;
            int chunkCount = 0;
            for (int i = 0; i != entities.Length; i++)
            {
                if (creationManager.GetChunk(entities[i]) != currentChunk)
                {
                    currentChunk = creationManager.GetChunk(entities[i]);
                    creationManager.SetChunkComponentData(currentChunk, new EcsTestData2(++chunkCount));
                }
                creationManager.SetComponentData(entities[i], new EcsTestData(chunkCount));
            }

            m_Manager.Debug.CheckInternalConsistency();
            creationManager.Debug.CheckInternalConsistency();

            m_Manager.MoveEntitiesFrom(creationManager);

            m_Manager.Debug.CheckInternalConsistency();
            creationManager.Debug.CheckInternalConsistency();

            var group = m_Manager.CreateEntityQuery(typeof(EcsTestData), ComponentType.ChunkComponent<EcsTestData2>());
            Assert.AreEqual(entities.Length, group.CalculateLength());
            Assert.AreEqual(0, creationManager.CreateEntityQuery(typeof(EcsTestData)).CalculateLength());

            var movedEntities = group.ToEntityArray(Allocator.TempJob);
            for (int i = 0; i < movedEntities.Length; ++i)
            {
                var entity = movedEntities[i];
                var valueFromComponent = m_Manager.GetComponentData<EcsTestData>(entity).value;
                var valueFromChunkComponent = m_Manager.GetChunkComponentData<EcsTestData2>(entity).value0;
                Assert.AreEqual(valueFromComponent, valueFromChunkComponent);
            }

            movedEntities.Dispose();
            entities.Dispose();
            creationWorld.Dispose();
        }

        [Test]
        public void MoveEntitiesWithEntityQuery()
        {
            var creationWorld = new World("CreationWorld");
            var creationManager = creationWorld.EntityManager;

            var archetype = creationManager.CreateArchetype(typeof(EcsTestData), typeof(EcsTestData2), typeof(SharedData1));

            var entities = new NativeArray<Entity>(10000, Allocator.Temp);
            creationManager.CreateEntity(archetype, entities);
            for (int i = 0; i != entities.Length; i++)
            {
                creationManager.SetComponentData(entities[i], new EcsTestData(i));
                creationManager.SetSharedComponentData(entities[i], new SharedData1(i % 5));
            }

            m_Manager.Debug.CheckInternalConsistency();
            creationManager.Debug.CheckInternalConsistency();

            var filteredComponentGroup = creationManager.CreateEntityQuery(typeof(EcsTestData), typeof(SharedData1));
            filteredComponentGroup.SetFilter(new SharedData1(2));

            var entityRemapping = creationManager.CreateEntityRemapArray(Allocator.TempJob);
            m_Manager.MoveEntitiesFrom(creationManager, filteredComponentGroup, entityRemapping);

            filteredComponentGroup.Dispose();


            m_Manager.Debug.CheckInternalConsistency();
            creationManager.Debug.CheckInternalConsistency();

            var group = m_Manager.CreateEntityQuery(typeof(EcsTestData), typeof(SharedData1));
            Assert.AreEqual(2000, group.CalculateLength());
            Assert.AreEqual(8000, creationManager.CreateEntityQuery(typeof(EcsTestData)).CalculateLength());

            // We expect that the shared component data matches the correct entities
            var chunks = group.CreateArchetypeChunkArray(Allocator.TempJob);
            for (int i = 0; i < chunks.Length; ++i)
            {
                var chunk = chunks[i];
                var shared = chunk.GetSharedComponentData(m_Manager.GetArchetypeChunkSharedComponentType<SharedData1>(), m_Manager);
                var testDataArray = chunk.GetNativeArray(m_Manager.GetArchetypeChunkComponentType<EcsTestData>(true));
                for (int j = 0; j < testDataArray.Length; ++j)
                {
                    Assert.AreEqual(shared.value, testDataArray[i].value % 5);
                }

                for (int j = 0;j != testDataArray.Length; ++j)
                    Assert.AreEqual(shared.value, 2);
            }

            chunks.Dispose();
            entityRemapping.Dispose();
            entities.Dispose();
            creationWorld.Dispose();
        }

        [Test]
        public void MoveEntitiesWithComponentGroupMovesChunkComponents()
        {
            var creationWorld = new World("CreationWorld");
            var creationManager = creationWorld.EntityManager;
            var archetype = creationManager.CreateArchetype(typeof(EcsTestData), ComponentType.ChunkComponent<EcsTestData2>(), typeof(SharedData1));

            var entities = new NativeArray<Entity>(10000, Allocator.Temp);
            creationManager.CreateEntity(archetype, entities);
            for (int i = 0; i != entities.Length; i++)
            {
                creationManager.SetComponentData(entities[i], new EcsTestData(i));
                creationManager.SetSharedComponentData(entities[i], new SharedData1(i % 5));
            }

            var srcGroup = creationManager.CreateEntityQuery(typeof(EcsTestData), ComponentType.ChunkComponent<EcsTestData2>(), typeof(SharedData1));

            var chunksPerValue = new int[5];
            var chunks = srcGroup.CreateArchetypeChunkArray(Allocator.TempJob);

            var sharedData1Type = creationManager.GetArchetypeChunkSharedComponentType<SharedData1>();
            var ecsTestData2Type = creationManager.GetArchetypeChunkComponentType<EcsTestData2>(false);

            foreach(var chunk in chunks)
            {
                int sharedIndex = chunk.GetSharedComponentIndex(sharedData1Type);
                var shared = creationManager.GetSharedComponentData<SharedData1>(sharedIndex);
                chunk.SetChunkComponentData(ecsTestData2Type, new EcsTestData2{value0 = shared.value, value1 = 47*shared.value});
                chunksPerValue[shared.value]++;
            }
            chunks.Dispose();

            m_Manager.Debug.CheckInternalConsistency();
            creationManager.Debug.CheckInternalConsistency();

            var filteredComponentGroup = creationManager.CreateEntityQuery(typeof(EcsTestData), typeof(SharedData1));
            filteredComponentGroup.SetFilter(new SharedData1(2));

            var entityRemapping = creationManager.CreateEntityRemapArray(Allocator.TempJob);
            m_Manager.MoveEntitiesFrom(creationManager, filteredComponentGroup, entityRemapping);

            filteredComponentGroup.Dispose();


            m_Manager.Debug.CheckInternalConsistency();
            creationManager.Debug.CheckInternalConsistency();

            var dstGroup = m_Manager.CreateEntityQuery(typeof(EcsTestData), ComponentType.ChunkComponent<EcsTestData2>(), typeof(SharedData1));
            Assert.AreEqual(2000, dstGroup.CalculateLength());
            Assert.AreEqual(8000, creationManager.CreateEntityQuery(typeof(EcsTestData)).CalculateLength());

            int expectedMovedChunkCount = chunksPerValue[2];
            int expectedRemainingChunkCount = chunksPerValue.Sum() - expectedMovedChunkCount;

            var movedChunkHeaderGroup = m_Manager.CreateEntityQuery(typeof(EcsTestData2), typeof(ChunkHeader));
            var remainingChunkHeaderGroup = creationManager.CreateEntityQuery(typeof(EcsTestData2), typeof(ChunkHeader));
            Assert.AreEqual(expectedMovedChunkCount, movedChunkHeaderGroup.CalculateLength());
            Assert.AreEqual(expectedRemainingChunkCount, remainingChunkHeaderGroup.CalculateLength());


            var dstEntityArray = dstGroup.ToEntityArray(Allocator.TempJob);
            for (int i = 0; i != dstEntityArray.Length; i++)
            {
                var chunkComponent = m_Manager.GetChunkComponentData<EcsTestData2>(dstEntityArray[i]);
                int expectedValue = m_Manager.GetComponentData<EcsTestData>(dstEntityArray[i]).value % 5;
                Assert.AreEqual(2, expectedValue);
                Assert.AreEqual(expectedValue, m_Manager.GetSharedComponentData<SharedData1>(dstEntityArray[i]).value);
                Assert.AreEqual(expectedValue, chunkComponent.value0);
                Assert.AreEqual(expectedValue*47, chunkComponent.value1);
            }

            var srcEntityArray = srcGroup.ToEntityArray(Allocator.TempJob);
            for (int i = 0; i != srcEntityArray.Length; i++)
            {
                var chunkComponent = creationManager.GetChunkComponentData<EcsTestData2>(srcEntityArray[i]);
                int expectedValue = creationManager.GetComponentData<EcsTestData>(srcEntityArray[i]).value % 5;
                Assert.AreNotEqual(2, expectedValue);
                Assert.AreEqual(expectedValue, creationManager.GetSharedComponentData<SharedData1>(srcEntityArray[i]).value);
                Assert.AreEqual(expectedValue, chunkComponent.value0);
                Assert.AreEqual(expectedValue*47, chunkComponent.value1);
            }

            dstGroup.Dispose();
            srcGroup.Dispose();
            movedChunkHeaderGroup.Dispose();
            remainingChunkHeaderGroup.Dispose();
            dstEntityArray.Dispose();
            srcEntityArray.Dispose();
            entityRemapping.Dispose();
            entities.Dispose();
            creationWorld.Dispose();
        }

        [Test]
        public void MoveEntitiesWithChunkHeaderChunksThrows()
        {
            var creationWorld = new World("CreationWorld");
            var creationManager = creationWorld.EntityManager;

            var archetype = creationManager.CreateArchetype(typeof(EcsTestData), ComponentType.ChunkComponent<EcsTestData2>());

            var entities = new NativeArray<Entity>(10000, Allocator.Temp);
            creationManager.CreateEntity(archetype, entities);
            entities.Dispose();

            m_Manager.Debug.CheckInternalConsistency();
            creationManager.Debug.CheckInternalConsistency();

            var componentGroupToMove = creationManager.CreateEntityQuery(typeof(EcsTestData2), typeof(ChunkHeader));
            var entityRemapping = creationManager.CreateEntityRemapArray(Allocator.TempJob);

            Assert.Throws<ArgumentException>(() => m_Manager.MoveEntitiesFrom(creationManager, componentGroupToMove, entityRemapping));
            Assert.Throws<ArgumentException>(() => m_Manager.MoveEntitiesFrom(out var output, creationManager, componentGroupToMove, entityRemapping));

            entityRemapping.Dispose();
            componentGroupToMove.Dispose();
            creationWorld.Dispose();
        }

        [Test]
        public void MoveEntitiesAppendsToExistingEntities()
        {
            int numberOfEntitiesPerManager = 10000;

            var targetArchetype = m_Manager.CreateArchetype(typeof(EcsTestData), typeof(EcsTestData2));
            var targetEntities = new NativeArray<Entity>(numberOfEntitiesPerManager, Allocator.Temp);
            m_Manager.CreateEntity(targetArchetype, targetEntities);
            for (int i = 0; i != targetEntities.Length; i++)
                m_Manager.SetComponentData(targetEntities[i], new EcsTestData(i));

            var sourceWorld = new World("SourceWorld");
            var sourceManager = sourceWorld.EntityManager;
            var sourceArchetype = sourceManager.CreateArchetype(typeof(EcsTestData), typeof(EcsTestData2));
            var sourceEntities = new NativeArray<Entity>(numberOfEntitiesPerManager, Allocator.Temp);
            sourceManager.CreateEntity(sourceArchetype, sourceEntities);
            for (int i = 0; i != sourceEntities.Length; i++)
                sourceManager.SetComponentData(sourceEntities[i], new EcsTestData(numberOfEntitiesPerManager + i));

            m_Manager.Debug.CheckInternalConsistency();
            sourceManager.Debug.CheckInternalConsistency();

            m_Manager.MoveEntitiesFrom(sourceManager);

            m_Manager.Debug.CheckInternalConsistency();
            sourceManager.Debug.CheckInternalConsistency();

            var group = m_Manager.CreateEntityQuery(typeof(EcsTestData));
            Assert.AreEqual(numberOfEntitiesPerManager * 2, group.CalculateLength());
            Assert.AreEqual(0, sourceManager.CreateEntityQuery(typeof(EcsTestData)).CalculateLength());

            // We expect that the order of the crated entities is the same as in the creation scene
            var testDataArray = group.ToComponentDataArray<EcsTestData>(Allocator.TempJob);
            for (int i = 0; i != testDataArray.Length; i++)
                Assert.AreEqual(i, testDataArray[i].value);

            testDataArray.Dispose();
            targetEntities.Dispose();
            sourceEntities.Dispose();
            sourceWorld.Dispose();
        }

        [Test]
        public void MoveEntitiesPatchesEntityReferences()
        {
            int numberOfEntitiesPerManager = 10000;

            var targetArchetype = m_Manager.CreateArchetype(typeof(EcsTestDataEntity));
            var targetEntities = new NativeArray<Entity>(numberOfEntitiesPerManager, Allocator.Temp);
            m_Manager.CreateEntity(targetArchetype, targetEntities);
            for (int i = 0; i != targetEntities.Length; i++)
                m_Manager.SetComponentData(targetEntities[i], new EcsTestDataEntity(i, targetEntities[i]));

            var sourceWorld = new World("SourceWorld");
            var sourceManager = sourceWorld.EntityManager;
            var sourceArchetype = sourceManager.CreateArchetype(typeof(EcsTestDataEntity));
            var sourceEntities = new NativeArray<Entity>(numberOfEntitiesPerManager, Allocator.Temp);
            sourceManager.CreateEntity(sourceArchetype, sourceEntities);
            for (int i = 0; i != sourceEntities.Length; i++)
                sourceManager.SetComponentData(sourceEntities[i], new EcsTestDataEntity(numberOfEntitiesPerManager + i, sourceEntities[i]));

            m_Manager.Debug.CheckInternalConsistency();
            sourceManager.Debug.CheckInternalConsistency();

            m_Manager.MoveEntitiesFrom(sourceManager);

            m_Manager.Debug.CheckInternalConsistency();
            sourceManager.Debug.CheckInternalConsistency();

            var group = m_Manager.CreateEntityQuery(typeof(EcsTestDataEntity));
            Assert.AreEqual(numberOfEntitiesPerManager * 2, group.CalculateLength());
            Assert.AreEqual(0, sourceManager.CreateEntityQuery(typeof(EcsTestDataEntity)).CalculateLength());

            var testDataArray = group.ToComponentDataArray<EcsTestDataEntity>(Allocator.TempJob);
            for (int i = 0; i != testDataArray.Length; i++)
                Assert.AreEqual(testDataArray[i].value0, m_Manager.GetComponentData<EcsTestDataEntity>(testDataArray[i].value1).value0);

            testDataArray.Dispose();
            targetEntities.Dispose();
            sourceEntities.Dispose();
            sourceWorld.Dispose();
        }

        [Test]
        [Ignore("This behaviour is currently not intended. It prevents streaming efficiently.")]
        public void MoveEntitiesPatchesEntityReferencesInSharedComponentData()
        {
            int numberOfEntitiesPerManager = 10000;
            int frequency = 5;

            var targetArchetype = m_Manager.CreateArchetype(typeof(EcsTestData), typeof(EcsTestSharedCompEntity));
            var targetEntities = new NativeArray<Entity>(numberOfEntitiesPerManager, Allocator.Temp);
            m_Manager.CreateEntity(targetArchetype, targetEntities);
            for (int i = 0; i != targetEntities.Length; i++)
            {
                m_Manager.SetComponentData(targetEntities[i], new EcsTestData(i));
                m_Manager.SetSharedComponentData(targetEntities[i], new EcsTestSharedCompEntity(targetEntities[i % frequency]));
            }

            var sourceWorld = new World("SourceWorld");
            var sourceManager = sourceWorld.EntityManager;
            var sourceArchetype = sourceManager.CreateArchetype(typeof(EcsTestData), typeof(EcsTestSharedCompEntity));
            var sourceEntities = new NativeArray<Entity>(numberOfEntitiesPerManager, Allocator.Temp);
            sourceManager.CreateEntity(sourceArchetype, sourceEntities);
            for (int i = 0; i != sourceEntities.Length; i++)
            {
                sourceManager.SetComponentData(sourceEntities[i], new EcsTestData(numberOfEntitiesPerManager + i));
                sourceManager.SetSharedComponentData(sourceEntities[i], new EcsTestSharedCompEntity(sourceEntities[i % frequency]));
            }

            m_Manager.Debug.CheckInternalConsistency();
            sourceManager.Debug.CheckInternalConsistency();

            m_Manager.MoveEntitiesFrom(sourceManager);

            m_Manager.Debug.CheckInternalConsistency();
            sourceManager.Debug.CheckInternalConsistency();

            var group = m_Manager.CreateEntityQuery(typeof(EcsTestData), typeof(EcsTestSharedCompEntity));
            Assert.AreEqual(numberOfEntitiesPerManager * 2, group.CalculateLength());
            Assert.AreEqual(0, sourceManager.CreateEntityQuery(typeof(EcsTestData)).CalculateLength());

            var testDataArray = group.ToComponentDataArray<EcsTestData>(Allocator.TempJob);
            var entities = group.ToEntityArray(Allocator.TempJob);

            for (int i = 0; i != numberOfEntitiesPerManager; i++)
                Assert.AreEqual(testDataArray[i].value % frequency,
                    m_Manager.GetComponentData<EcsTestData>(m_Manager.GetSharedComponentData<EcsTestSharedCompEntity>(entities[i]).value).value);
            for (int i = numberOfEntitiesPerManager; i != numberOfEntitiesPerManager * 2; i++)
                Assert.AreEqual(numberOfEntitiesPerManager + testDataArray[i].value % frequency,
                    m_Manager.GetComponentData<EcsTestData>(m_Manager.GetSharedComponentData<EcsTestSharedCompEntity>(entities[i]).value).value);

            testDataArray.Dispose();
            entities.Dispose();
            targetEntities.Dispose();
            sourceEntities.Dispose();
            sourceWorld.Dispose();
        }

        [Test]
        public void MoveEntitiesFromCanReturnEntities()
        {
            var creationWorld = new World("CreationWorld");
            var creationManager = creationWorld.EntityManager;

            var archetype = creationManager.CreateArchetype(typeof(EcsTestData), typeof(EcsTestData2));

            int numberOfEntitiesWeCreated = 10000;
            var entities = new NativeArray<Entity>(numberOfEntitiesWeCreated, Allocator.Temp);
            creationManager.CreateEntity(archetype, entities);
            for (int i = 0; i != entities.Length; i++)
                creationManager.SetComponentData(entities[i], new EcsTestData(i));

            m_Manager.Debug.CheckInternalConsistency();
            creationManager.Debug.CheckInternalConsistency();

            NativeArray<Entity> movedEntities;
            m_Manager.MoveEntitiesFrom(out movedEntities, creationManager);

            // make sure that the count of moved entities matches the count of entities we initially created

            Assert.AreEqual(numberOfEntitiesWeCreated, movedEntities.Length);

            // make sure that each of the entities made the journey, and none were duplicated

            var references = new NativeArray<int>(numberOfEntitiesWeCreated, Allocator.Temp);
            for (int i = 0; i < numberOfEntitiesWeCreated; ++i)
            {
                var data = m_Manager.GetComponentData<EcsTestData>(movedEntities[i]);
                Assert.AreEqual(0, references[data.value]);
                ++references[data.value];
            }
            for (int i = 0; i < numberOfEntitiesWeCreated; ++i)
            {
                Assert.AreEqual(1, references[i]);
            }

            references.Dispose();
            movedEntities.Dispose();
            entities.Dispose();
            creationWorld.Dispose();
        }

        [Test]
        public unsafe void MoveEntitiesArchetypeChunkCountMatches()
        {
            var creationWorld = new World("CreationWorld");
            var creationManager = creationWorld.EntityManager;

            var archetype = creationManager.CreateArchetype(typeof(EcsTestData), typeof(EcsTestData2));

            var entities = new NativeArray<Entity>(10000, Allocator.Temp);
            creationManager.CreateEntity(archetype, entities);
            for (int i = 0; i != entities.Length; i++)
                creationManager.SetComponentData(entities[i], new EcsTestData(i));

            m_Manager.Debug.CheckInternalConsistency();
            creationManager.Debug.CheckInternalConsistency();

            var chunkData = archetype.Archetype->Chunks;
            int sizeOfBuffer = sizeof(int) * chunkData.Count;
            var chunkDataCopy =
                (int*)UnsafeUtility.Malloc(sizeOfBuffer, 64, Allocator.Temp);
            UnsafeUtility.MemCpy(chunkDataCopy, chunkData.GetChunkEntityCountArray(), sizeOfBuffer);

            m_Manager.MoveEntitiesFrom(creationManager);

            var archetypeAfter = m_Manager.CreateArchetype(typeof(EcsTestData), typeof(EcsTestData2));
            var chunkDataAfter = archetypeAfter.Archetype->Chunks;

            Assert.IsTrue(UnsafeUtility.MemCmp(chunkDataCopy, chunkDataAfter.GetChunkEntityCountArray(), sizeOfBuffer) == 0);

            m_Manager.Debug.CheckInternalConsistency();
            creationManager.Debug.CheckInternalConsistency();

            entities.Dispose();
            creationWorld.Dispose();
        }

        [Test]
        public void MoveEntitiesFromChunksAreConsideredChangedOnlyOnce()
        {
            var creationWorld = new World("CreationWorld");
            var creationManager = creationWorld.EntityManager;
            var entity = creationManager.CreateEntity();
            creationManager.AddComponentData(entity, new EcsTestData(42));

            var system = World.GetOrCreateSystem<TestEcsChangeSystem>();
            Assert.AreEqual(0, system.NumChanged);

            m_Manager.MoveEntitiesFrom(creationManager);

            system.Update();
            Assert.AreEqual(1, system.NumChanged);

            system.Update();
            Assert.AreEqual(0, system.NumChanged);
        }
    }
}
