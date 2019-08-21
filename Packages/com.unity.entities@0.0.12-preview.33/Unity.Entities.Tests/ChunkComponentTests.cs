using System;
using Unity.Entities;
using NUnit.Framework;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace Unity.Entities.Tests
{
    struct ChunkBoundsComponent : IComponentData
    {
        public float3 boundsMin;
        public float3 boundsMax;
    }
    struct BoundsComponent : IComponentData
    {
        public float3 boundsMin;
        public float3 boundsMax;
    }
    
    struct SystemStateChunkComponent : ISystemStateComponentData
    {
    }
    
    public class ChunkComponentTests : ECSTestsFixture
    {
        [Test]
        public void CreateChunkComponentArchetype()
        {
            var entity = m_Manager.CreateEntity(ComponentType.ChunkComponent<EcsTestData>());
            Assert.IsTrue(m_Manager.HasComponent(entity, ComponentType.ChunkComponent<EcsTestData>()));
            Assert.IsFalse(m_Manager.HasComponent(entity, ComponentType.ReadWrite<EcsTestData>()));
        }

        [Test]
        public void SetChunkComponent()
        {
            var entity = m_Manager.CreateEntity(ComponentType.ChunkComponent<EcsTestData>());
            m_Manager.SetChunkComponentData(m_Manager.GetChunk(entity), new EcsTestData{value = 7});
            Assert.IsTrue(m_Manager.HasComponent(entity, ComponentType.ChunkComponent<EcsTestData>()));
            var val0 = m_Manager.GetChunkComponentData<EcsTestData>(entity).value;
            Assert.AreEqual(7, val0);
            var val1 = m_Manager.GetChunkComponentData<EcsTestData>(m_Manager.GetChunk(entity)).value;
            Assert.AreEqual(7, val1);
        }

        [Test]
        public void AddChunkComponentMovesEntity()
        {
            var entity0 = m_Manager.CreateEntity(ComponentType.ReadWrite<EcsTestData>());
            var entity1 = m_Manager.CreateEntity(ComponentType.ReadWrite<EcsTestData>());
            var chunk0 = m_Manager.GetChunk(entity0);
            var chunk1 = m_Manager.GetChunk(entity1);

            Assert.AreEqual(chunk0, chunk1);

            Assert.IsFalse(m_Manager.HasChunkComponent<EcsTestData2>(entity0));
            m_Manager.AddChunkComponentData<EcsTestData2>(entity0);
            Assert.IsTrue(m_Manager.HasChunkComponent<EcsTestData2>(entity0));
            chunk0 = m_Manager.GetChunk(entity0);

            Assert.AreNotEqual(chunk0, chunk1);

            Assert.IsTrue(m_Manager.HasComponent(entity0, ComponentType.ChunkComponent<EcsTestData2>()));
            Assert.IsFalse(m_Manager.HasComponent(entity1, ComponentType.ChunkComponent<EcsTestData2>()));
            Assert.IsTrue(m_Manager.Exists(m_Manager.Debug.GetMetaChunkEntity(entity0)));
            Assert.IsTrue(m_Manager.Debug.GetMetaChunkEntity(entity1) == default(Entity));
        }

        [Test]
        public void RemoveChunkComponent()
        {
            var arch0 = m_Manager.CreateArchetype(ComponentType.ChunkComponent<EcsTestData>(), typeof(EcsTestData2));
            var arch1 = m_Manager.CreateArchetype(typeof(EcsTestData2));

            var entity0 = m_Manager.CreateEntity(arch0);
            m_Manager.SetChunkComponentData(m_Manager.GetChunk(entity0), new EcsTestData{value = 7});
            m_Manager.SetComponentData(entity0, new EcsTestData2 {value0 = 1, value1 = 2});
            var metaEntity0 = m_Manager.Debug.GetMetaChunkEntity(entity0);

            var entity1 = m_Manager.CreateEntity(arch1);
            m_Manager.SetComponentData(entity1, new EcsTestData2 {value0 = 2, value1 = 3});

            m_Manager.RemoveChunkComponent<EcsTestData>(entity0);

            Assert.IsFalse(m_Manager.HasComponent(entity0, ComponentType.ChunkComponent<EcsTestData>()));
            Assert.IsFalse(m_Manager.Exists(metaEntity0));
        }

        [Test]
        public void UpdateChunkComponent()
        {
            var arch0 = m_Manager.CreateArchetype(ComponentType.ChunkComponent<EcsTestData>(), typeof(EcsTestData2));
            EntityQuery group0 = m_Manager.CreateEntityQuery(typeof(ChunkHeader), typeof(EcsTestData));

            var entity0 = m_Manager.CreateEntity(arch0);
            var chunk0 = m_Manager.GetChunk(entity0);
            EcsTestData testData = new EcsTestData{value = 7};

            Assert.AreEqual(1, group0.CalculateLength());

            m_Manager.SetChunkComponentData(chunk0, testData);

            Assert.AreEqual(1, group0.CalculateLength());

            Assert.AreEqual(7, m_Manager.GetChunkComponentData<EcsTestData>(entity0).value);

            m_Manager.SetComponentData(entity0, new EcsTestData2 {value0 = 1, value1 = 2});

            var entity1 = m_Manager.CreateEntity(arch0);
            var chunk1 = m_Manager.GetChunk(entity1);
            Assert.AreEqual(7, m_Manager.GetChunkComponentData<EcsTestData>(entity0).value);
            Assert.AreEqual(7, m_Manager.GetChunkComponentData<EcsTestData>(entity1).value);

            Assert.AreEqual(1, group0.CalculateLength());

            m_Manager.SetChunkComponentData(chunk1, testData);

            Assert.AreEqual(1, group0.CalculateLength());

            m_Manager.SetComponentData(entity1, new EcsTestData2 {value0 = 2, value1 = 3});

            Assert.AreEqual(1, group0.CalculateLength());

            m_Manager.SetChunkComponentData<EcsTestData>(chunk0, new EcsTestData{value = 10});

            Assert.AreEqual(10, m_Manager.GetChunkComponentData<EcsTestData>(entity0).value);

            Assert.AreEqual(1, group0.CalculateLength());
        }

        [Test]
        public void ProcessMetaChunkComponent()
        {
            var entity0 = m_Manager.CreateEntity(typeof(BoundsComponent), ComponentType.ChunkComponent<ChunkBoundsComponent>());
            m_Manager.SetComponentData(entity0, new BoundsComponent{boundsMin = new float3(-10,-10,-10), boundsMax = new float3(0,0,0)});
            var entity1 = m_Manager.CreateEntity(typeof(BoundsComponent), ComponentType.ChunkComponent<ChunkBoundsComponent>());
            m_Manager.SetComponentData(entity1, new BoundsComponent{boundsMin = new float3(0,0,0), boundsMax = new float3(10,10,10)});
            var metaGroup = m_Manager.CreateEntityQuery(typeof(ChunkBoundsComponent), typeof(ChunkHeader));
            var metaBoundsCount = metaGroup.CalculateLength();
            var metaChunkHeaders = metaGroup.ToComponentDataArray<ChunkHeader>(Allocator.TempJob);
            Assert.AreEqual(1, metaBoundsCount);
            for (int i = 0; i < metaBoundsCount; ++i)
            {
                var curBounds = new ChunkBoundsComponent { boundsMin = new float3(1000, 1000, 1000), boundsMax = new float3(-1000, -1000, -1000)};
                var boundsChunk = metaChunkHeaders[i].ArchetypeChunk;
                var bounds = boundsChunk.GetNativeArray(m_Manager.GetArchetypeChunkComponentType<BoundsComponent>(true));
                for (int j = 0; j < bounds.Length; ++j)
                {
                    curBounds.boundsMin = math.min(curBounds.boundsMin, bounds[j].boundsMin);
                    curBounds.boundsMax = math.max(curBounds.boundsMax, bounds[j].boundsMax);
                }

                var chunkBoundsType = m_Manager.GetArchetypeChunkComponentType<ChunkBoundsComponent>(false);

                boundsChunk.SetChunkComponentData(chunkBoundsType, curBounds);
                Assert.AreEqual(curBounds, boundsChunk.GetChunkComponentData(chunkBoundsType));
            }
            var val = m_Manager.GetChunkComponentData<ChunkBoundsComponent>(entity0);
            Assert.AreEqual(new float3(-10,-10,-10), val.boundsMin);
            Assert.AreEqual(new float3(10,10,10), val.boundsMax);
            
            metaChunkHeaders.Dispose();
        }

#if !UNITY_DOTSPLAYER
        [UpdateInGroup(typeof(PresentationSystemGroup))]
        private class ChunkBoundsUpdateSystem : JobComponentSystem
        {
            struct UpdateChunkBoundsJob : IJobForEach<ChunkBoundsComponent, ChunkHeader>
            {
                [ReadOnly] public ArchetypeChunkComponentType<BoundsComponent> chunkComponentType;
                
                public void Execute(ref ChunkBoundsComponent chunkBounds, [ReadOnly] ref ChunkHeader chunkHeader)
                {
                    var curBounds = new ChunkBoundsComponent { boundsMin = new float3(1000, 1000, 1000), boundsMax = new float3(-1000, -1000, -1000)};
                    var boundsChunk = chunkHeader.ArchetypeChunk;
                    var bounds = boundsChunk.GetNativeArray(chunkComponentType);
                    for (int j = 0; j < bounds.Length; ++j)
                    {
                        curBounds.boundsMin = math.min(curBounds.boundsMin, bounds[j].boundsMin);
                        curBounds.boundsMax = math.max(curBounds.boundsMax, bounds[j].boundsMax);
                    }

                    chunkBounds = curBounds;
                }
            }
            protected override JobHandle OnUpdate(JobHandle inputDeps)
            {
                var job = new UpdateChunkBoundsJob {chunkComponentType = EntityManager.GetArchetypeChunkComponentType<BoundsComponent>(true)};
                return job.Schedule(this, inputDeps);
            }
        }

        [Test]
        public void SystemProcessMetaChunkComponent()
        {
            var chunkBoundsUpdateSystem = World.GetOrCreateSystem<ChunkBoundsUpdateSystem> ();

            var entity0 = m_Manager.CreateEntity(typeof(BoundsComponent), ComponentType.ChunkComponent<ChunkBoundsComponent>());
            m_Manager.SetComponentData(entity0, new BoundsComponent{boundsMin = new float3(-10,-10,-10), boundsMax = new float3(0,0,0)});

            var entity1 = m_Manager.CreateEntity(typeof(BoundsComponent), ComponentType.ChunkComponent<ChunkBoundsComponent>());
            m_Manager.SetComponentData(entity1, new BoundsComponent{boundsMin = new float3(0,0,0), boundsMax = new float3(10,10,10)});

            chunkBoundsUpdateSystem.Update();

            var val = m_Manager.GetChunkComponentData<ChunkBoundsComponent>(entity0);
            Assert.AreEqual(new float3(-10,-10,-10), val.boundsMin);
            Assert.AreEqual(new float3(10,10,10), val.boundsMax);
        }
#endif

        [Test]
        public void ChunkHeaderMustBeQueriedExplicitly()
        {
            var arch0 = m_Manager.CreateArchetype(ComponentType.ChunkComponent<EcsTestData>(), typeof(EcsTestData2));
            var entity0 = m_Manager.CreateEntity(arch0);

            EntityQuery group0 = m_Manager.CreateEntityQuery(typeof(ChunkHeader), typeof(EcsTestData));
            EntityQuery group1 = m_Manager.CreateEntityQuery(typeof(EcsTestData));

            Assert.AreEqual(1, group0.CalculateLength());
            Assert.AreEqual(0, group1.CalculateLength());
        }
        
        [Test]
        public void DestroyEntityDestroysMetaChunk()
        {
            var entity = m_Manager.CreateEntity(ComponentType.ReadWrite<EcsTestData>(), ComponentType.ChunkComponent<ChunkBoundsComponent>());
            var metaEntity = m_Manager.Debug.GetMetaChunkEntity(entity);
            m_Manager.DestroyEntity(entity);
            Assert.IsFalse(m_Manager.Exists(metaEntity));
        }
        
        [Test]
        [Ignore("Fails on last Assert.IsFalse(m_Manager.Exists(metaEntity));")]
        public void SystemStateChunkComponentRemainsUntilRemoved()
        {
            var entity = m_Manager.CreateEntity(ComponentType.ReadWrite<EcsState1>(), ComponentType.ChunkComponent<SystemStateChunkComponent>());
            var metaEntity = m_Manager.Debug.GetMetaChunkEntity(entity);
            
            m_Manager.DestroyEntity(entity);

            Assert.IsTrue(m_Manager.HasComponent<EcsState1>(entity));
            Assert.IsTrue(m_Manager.HasChunkComponent<SystemStateChunkComponent>(entity));
            Assert.IsTrue(m_Manager.Exists(metaEntity));
            Assert.IsTrue(m_Manager.Exists(entity));

            m_Manager.RemoveComponent(entity, ComponentType.ReadWrite<EcsState1>());

            Assert.IsFalse(m_Manager.HasComponent<EcsState1>(entity));
            Assert.IsTrue(m_Manager.HasChunkComponent<SystemStateChunkComponent>(entity));
            Assert.IsTrue(m_Manager.Exists(metaEntity));
            Assert.IsTrue(m_Manager.Exists(entity));

            m_Manager.RemoveComponent(entity, ComponentType.ChunkComponent<SystemStateChunkComponent>());

            Assert.IsFalse(m_Manager.HasComponent<EcsState1>(entity));
            Assert.IsFalse(m_Manager.HasChunkComponent<SystemStateChunkComponent>(entity));
            Assert.IsFalse(m_Manager.Exists(metaEntity));
            Assert.IsFalse(m_Manager.Exists(entity));
        }
    }
}
