using System;
using NUnit.Framework;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;


namespace Unity.Entities.Tests
{
    public class LockedEntitiesTests : ECSTestsFixture
    {
        [Test]
        public void LockedEntityUnlockAndDestroy()
        {
            var archetype = m_Manager.CreateArchetype(typeof(EcsTestData), typeof(EcsTestData2));
            var entities = new NativeArray<Entity>(10000, Allocator.Persistent);

            m_Manager.CreateEntity(archetype, entities);

            for (int i = 0; i < entities.Length; i++)
            {
                var chunk = m_Manager.GetChunk(entities[i]);
                m_Manager.LockChunk(chunk);
                Assert.Throws<InvalidOperationException>(() => m_Manager.DestroyEntity(entities[i]) );

                m_Manager.UnlockChunk(chunk);
                m_Manager.DestroyEntity(entities[i]);
            }            
            entities.Dispose();
        }
        
        [Test]
        public void LockChunkOrderDestroyGroup()
        {
            var archetype = m_Manager.CreateArchetype(typeof(EcsTestData));
            var chunkCapacity = archetype.ChunkCapacity;
            var entityCount = 10000;
            var chunkCount = (entityCount + (chunkCapacity-1)) / chunkCapacity;
            var chunks = new NativeArray<ArchetypeChunk>(chunkCount, Allocator.Persistent);

            m_Manager.CreateChunk(archetype, chunks, entityCount);

            var group = m_Manager.CreateEntityQuery(typeof(EcsTestData));
            m_Manager.LockChunkOrder(group);
            m_Manager.DestroyEntity(group);
            
            chunks.Dispose();
            group.Dispose();            
        }
        
        [Test]
        public void LockChunkOrderDestroyGroupStateTag()
        {
            var archetype = m_Manager.CreateArchetype(typeof(EcsTestData), typeof(EcsStateTag1));
            var chunkCapacity = archetype.ChunkCapacity;
            var entityCount = 10000;
            var chunkCount = (entityCount + (chunkCapacity-1)) / chunkCapacity;
            var chunks = new NativeArray<ArchetypeChunk>(chunkCount, Allocator.Persistent);

            m_Manager.CreateChunk(archetype, chunks, entityCount);

            var group = m_Manager.CreateEntityQuery(typeof(EcsTestData), typeof(EcsStateTag1));
            m_Manager.LockChunkOrder(group);
            m_Manager.DestroyEntity(group);
            m_Manager.RemoveComponent(group,typeof(EcsStateTag1));
            
            chunks.Dispose();
            group.Dispose();            
        }
        
        [Test]
        public void LockedEntityChunksNotAddToExistingChunks()
        {
            var archetype = m_Manager.CreateArchetype(typeof(EcsTestData), typeof(EcsTestData2));
            var chunkCapacity = archetype.ChunkCapacity;
            var entityCount = 10000;
            var chunkCount = (entityCount + (chunkCapacity-1)) / chunkCapacity;
            var chunks = new NativeArray<ArchetypeChunk>(chunkCount, Allocator.Persistent);

            var extraEntities = new NativeArray<Entity>(3, Allocator.Persistent);
            m_Manager.CreateEntity(archetype, extraEntities);      
            
            m_Manager.CreateChunk(archetype, chunks, entityCount);
            m_Manager.LockChunk(chunks);
            int count = 0;
            for (int i = 0; i < chunkCount; i++)
            {
                count += chunks[i].Count;
            }
            Assert.AreEqual(count,entityCount);

            var entityType = m_Manager.GetArchetypeChunkEntityType();

            count = 0;
            for (int i = 0; i < chunkCount; i++)
            {
                var chunk = chunks[i];
                var chunkEntities = chunk.GetNativeArray(entityType);
                count += chunkEntities.Length;
            }
            Assert.AreEqual(count,entityCount);

            chunks.Dispose();
            extraEntities.Dispose();
        }
        
        [Test]
        public void LockedEntityRestrictions()
        {
            var entity = m_Manager.CreateEntity(typeof(EcsTestData), typeof(EcsTestData2));
            var chunk = m_Manager.GetChunk(entity);
            m_Manager.LockChunk(chunk);

            Assert.Throws<InvalidOperationException>(() =>  m_Manager.AddComponentData(entity, new EcsTestTag()) );
            Assert.Throws<InvalidOperationException>(() =>  m_Manager.AddComponent(m_Manager.UniversalQuery, typeof(EcsTestTag)) );

            Assert.Throws<InvalidOperationException>(() =>  m_Manager.RemoveComponent<EcsTestData>(entity) );
            Assert.Throws<InvalidOperationException>(() =>  m_Manager.RemoveComponent(m_Manager.UniversalQuery, typeof(EcsTestData)));
            
            Assert.Throws<InvalidOperationException>(() =>  m_Manager.DestroyEntity(entity));
            Assert.Throws<InvalidOperationException>(() =>  m_Manager.DestroyEntity(m_Manager.UniversalQuery));
        }
        
        [Test]
        public void LockedEntityOrderRestrictions()
        {
            var entity = m_Manager.CreateEntity(typeof(EcsTestData), typeof(EcsTestData2), typeof(EcsTestTag));
            var chunk = m_Manager.GetChunk(entity);
            m_Manager.LockChunkOrder(chunk);

            Assert.Throws<InvalidOperationException>(() =>  m_Manager.AddComponentData(entity, new EcsFooTest()));
            Assert.Throws<InvalidOperationException>(() =>  m_Manager.AddComponent(m_Manager.UniversalQuery, typeof(EcsFooTest)));

            Assert.Throws<InvalidOperationException>(() =>  m_Manager.RemoveComponent<EcsTestData>(entity) );
            Assert.Throws<InvalidOperationException>(() =>  m_Manager.RemoveComponent(m_Manager.UniversalQuery, typeof(EcsTestData)));
            
            Assert.Throws<InvalidOperationException>(() =>  m_Manager.DestroyEntity(entity));
        }
        
        [Test]
        public void LockedEntityOrderAllowsNonMovingOperations()
        {
            var entity = m_Manager.CreateEntity(typeof(EcsTestData), typeof(EcsTestData2));
            var chunk = m_Manager.GetChunk(entity);
            m_Manager.LockChunkOrder(chunk);

            m_Manager.AddComponent(m_Manager.UniversalQuery, typeof(EcsTestTag));
            m_Manager.RemoveComponent(m_Manager.UniversalQuery, typeof(EcsTestTag));
            m_Manager.AddChunkComponentData(m_Manager.UniversalQuery, new EcsFooTest());
            m_Manager.DestroyEntity(m_Manager.UniversalQuery);
        }
        
        [Test]
        public void LockedEntityDoesNotAddToChunk()
        {
            var archetype = m_Manager.CreateArchetype(typeof(EcsTestData), typeof(EcsTestData2));
            var chunkCapacity = archetype.ChunkCapacity;
            var entityCount = 10000;
            var chunkCount = (entityCount + (chunkCapacity-1)) / chunkCapacity;
            var chunks = new NativeArray<ArchetypeChunk>(chunkCount, Allocator.Persistent);
            
            m_Manager.CreateChunk(archetype, chunks, entityCount);
            m_Manager.LockChunk(chunks);

            var extraEntities = new NativeArray<Entity>(3, Allocator.Persistent);
            m_Manager.CreateEntity(archetype, extraEntities);      

            int count = 0;
            for (int i = 0; i < chunkCount; i++)
            {
                count += chunks[i].Count;
            }
            Assert.AreEqual(count,entityCount);

            var entityType = m_Manager.GetArchetypeChunkEntityType();

            count = 0;
            for (int i = 0; i < chunkCount; i++)
            {
                var chunk = chunks[i];
                var chunkEntities = chunk.GetNativeArray(entityType);
                count += chunkEntities.Length;
            }
            Assert.AreEqual(count,entityCount);

            chunks.Dispose();
            extraEntities.Dispose();
        }
        
        
        
        [Test]
        public void LockedEntityAddsEntitytoUnlockedChunk()
        {
            var archetype = m_Manager.CreateArchetype(typeof(EcsTestData), typeof(EcsTestData2));
            var chunkCapacity = archetype.ChunkCapacity;
            var entityCount = 10000;
            var chunkCount = (entityCount + (chunkCapacity-1)) / chunkCapacity;
            var chunks = new NativeArray<ArchetypeChunk>(chunkCount, Allocator.Persistent);
            
            m_Manager.CreateChunk(archetype, chunks, entityCount);
            
            var extraEntities = new NativeArray<Entity>(3, Allocator.Persistent);
            m_Manager.CreateEntity(archetype, extraEntities);

            var totalEntityCount = entityCount + extraEntities.Length;

            int count = 0;
            for (int i = 0; i < chunkCount; i++)
            {
                count += chunks[i].Count;
            }
            Assert.AreEqual(count,totalEntityCount);

            var entityType = m_Manager.GetArchetypeChunkEntityType();

            count = 0;
            for (int i = 0; i < chunkCount; i++)
            {
                var chunk = chunks[i];
                var chunkEntities = chunk.GetNativeArray(entityType);
                count += chunkEntities.Length;
            }
            Assert.AreEqual(count,totalEntityCount);

            chunks.Dispose();
            extraEntities.Dispose();
        }
        
        struct ChunksFixedGrid2DTranspose : IJob
        {
            public ExclusiveEntityTransaction entities;
            public ChunksFixedGrid2D fixedGrid;

            public void Execute()
            {
                int width = fixedGrid.Width;
                int height = fixedGrid.Height;
                
                Assert.AreEqual(width,height);
                
                for (int y=0;y<width;y++)
                for (int x = y+1; x < width; x++)
                {
                    var leftChunkInstanceIndex = fixedGrid.ChunkinstanceIndex(x, y);
                    var leftChunk = fixedGrid.Chunks[fixedGrid.ChunkIndex(x, y)];
                    var rightChunkInstanceIndex = fixedGrid.ChunkinstanceIndex(y,x);
                    var rightChunk = fixedGrid.Chunks[fixedGrid.ChunkIndex(y,x)];

                    entities.SwapComponents(leftChunk,leftChunkInstanceIndex,rightChunk,rightChunkInstanceIndex);
                }
            }
        }

        struct ChunksFixedGrid2D
        {
            public NativeArray<ArchetypeChunk> Chunks;
            public int Width;
            public int Height;
            public int ChunkCapacity;
            public int ChunkCount => Chunks.Length;

            public ChunksFixedGrid2D(NativeArray<ArchetypeChunk> chunks, int width, int height)
            {
                Assert.IsTrue(chunks.Length > 0);
                 
                Chunks = chunks;
                Width = width;
                Height = height;
                ChunkCapacity = chunks[0].Capacity;
                
                int instanceCount = width * height;
                int chunkCount = instanceCount / chunks[0].Capacity;
                EntityArchetype expectedArchetype = chunks[0].Archetype;

                Assert.IsTrue(chunks.Length >= chunkCount);
                for (int i = 0; i < chunkCount-1; i++)
                {
                    var chunkArchetype = chunks[i].Archetype;
                    Assert.AreEqual(expectedArchetype,chunkArchetype);
                    // Only the last chunk can be not full.
                    Assert.IsTrue(chunks[i].Full);
                }
                if (chunkCount > 1)
                    Assert.AreEqual(expectedArchetype,chunks[chunkCount-1].Archetype);
            }

            public int InstanceIndex(int x, int y) => (y * Width) + x;
            public int ChunkIndex(int x, int y) => InstanceIndex(x, y) / ChunkCapacity;
            public int ChunkinstanceIndex(int x, int y) => InstanceIndex(x, y) - (ChunkIndex(x, y) * ChunkCapacity);
        }

        unsafe struct ComponentFixedGrid2D<T> : IDisposable
            where T : struct, IComponentData
        {
            public ArchetypeChunkComponentType<T> Type;
            public int ChunkCount;
            public ChunksFixedGrid2D ChunkGrid;
            public NativeArray<UIntPtr> ChunkComponentData;
            
            public ComponentFixedGrid2D(ArchetypeChunkComponentType<T> type, ChunksFixedGrid2D chunkGrid)
            {
                Type = type;
                ChunkGrid = chunkGrid;
                ChunkCount = chunkGrid.ChunkCount;
                ChunkComponentData = new NativeArray<UIntPtr>(ChunkCount, Allocator.Persistent);
                for (int i = 0; i < ChunkCount; i++)
                {
                    ChunkComponentData[i] = (UIntPtr)chunkGrid.Chunks[i].GetNativeArray(type).GetUnsafePtr();
                }
            }

            public void Dispose()
            {
                ChunkComponentData.Dispose();                
            }
            
            public T this[int x, int y]
            {
                get
                {
                    var chunkIndex = ChunkGrid.ChunkIndex(x, y);
                    var chunkComponentBuffer = ChunkComponentData[chunkIndex];
                    var chunkInstanceIndex = ChunkGrid.ChunkinstanceIndex(x, y);
                    var componentValue = UnsafeUtility.ReadArrayElement<T>((void*) chunkComponentBuffer, chunkInstanceIndex);
                    return componentValue;                    
                }
                set
                {
                    var chunkIndex = ChunkGrid.ChunkIndex(x, y);
                    var chunkComponentBuffer = ChunkComponentData[chunkIndex];
                    var chunkInstanceIndex = ChunkGrid.ChunkinstanceIndex(x, y);
                    UnsafeUtility.WriteArrayElement((void*)chunkComponentBuffer,chunkInstanceIndex,value);
                }
            }
        }            
        
        [Test]
        public void LockedEntityFixedGrid2DAccess()
        {
            var archetype = m_Manager.CreateArchetype(typeof(EcsTestData), typeof(EcsTestData2));
            var chunkCapacity = archetype.ChunkCapacity;
            var width = 100;
            var height = 100;
            var entityCount = width * height;
            var chunkCount = (entityCount + (chunkCapacity-1)) / chunkCapacity;
            var chunks = new NativeArray<ArchetypeChunk>(chunkCount, Allocator.Persistent);

            m_Manager.CreateChunk(archetype, chunks, entityCount);
            m_Manager.LockChunk(chunks);
            
            var grid = new ChunksFixedGrid2D(chunks, width, height);
            var ecsTestDataType = m_Manager.GetArchetypeChunkComponentType<EcsTestData>(false);
            var ecsTestDataGrid = new ComponentFixedGrid2D<EcsTestData>(ecsTestDataType, grid);
                
            for (int y=0;y<height;y++)
                for (int x=0;x<width;x++)
                    ecsTestDataGrid[x,y] = new EcsTestData(x);

            for (int y=0;y<height;y++)
                for (int x = 0; x < width; x++)
                    Assert.AreEqual(x, ecsTestDataGrid[x, y].value);
           
            ecsTestDataGrid.Dispose();
            chunks.Dispose();
        }
        
        [Test]
        public void LockedEntityFixedGrid2DSort()
        {
            var archetype = m_Manager.CreateArchetype(typeof(EcsTestData), typeof(EcsTestData2));
            var chunkCapacity = archetype.ChunkCapacity;
            var width = 100;
            var height = 100;
            var entityCount = width * height;
            var chunkCount = (entityCount + (chunkCapacity-1)) / chunkCapacity;
            var chunks = new NativeArray<ArchetypeChunk>(chunkCount, Allocator.Persistent);

            m_Manager.CreateChunk(archetype, chunks, entityCount);
            m_Manager.LockChunk(chunks);

            var grid = new ChunksFixedGrid2D(chunks, width, height);
            var ecsTestDataType = m_Manager.GetArchetypeChunkComponentType<EcsTestData>(false);
            var ecsTestDataGrid = new ComponentFixedGrid2D<EcsTestData>(ecsTestDataType, grid);

            for (int y=0;y<height;y++)
            for (int x = 0; x < width; x++)
                ecsTestDataGrid[x, y] = new EcsTestData(y);

            // Transpose emulates whatever kind of sorting you might do...
            var job = new ChunksFixedGrid2DTranspose
            {
                entities = m_Manager.BeginExclusiveEntityTransaction(),
                fixedGrid = grid
            };
            m_Manager.ExclusiveEntityTransactionDependency = job.Schedule(m_Manager.ExclusiveEntityTransactionDependency);
            m_Manager.EndExclusiveEntityTransaction();
                
            for (int y = 0; y < height; y++)
            for (int x = 0; x < width; x++)
                Assert.AreEqual(x, ecsTestDataGrid[x, y].value);
           
            chunks.Dispose();
            ecsTestDataGrid.Dispose();
        }
        
        [Test]
        public void LockedEntityFixedGrid2DSortMainThread()
        {
            var archetype = m_Manager.CreateArchetype(typeof(EcsTestData), typeof(EcsTestData2));
            var chunkCapacity = archetype.ChunkCapacity;
            var width = 100;
            var height = 100;
            var entityCount = width * height;
            var chunkCount = (entityCount + (chunkCapacity-1)) / chunkCapacity;
            var chunks = new NativeArray<ArchetypeChunk>(chunkCount, Allocator.Persistent);

            m_Manager.CreateChunk(archetype, chunks, entityCount);
            m_Manager.LockChunk(chunks);

            var grid = new ChunksFixedGrid2D(chunks, width, height);
            var ecsTestDataType = m_Manager.GetArchetypeChunkComponentType<EcsTestData>(false);
            var ecsTestDataGrid = new ComponentFixedGrid2D<EcsTestData>(ecsTestDataType, grid);

            for (int y=0;y<height;y++)
            for (int x = 0; x < width; x++)
                ecsTestDataGrid[x, y] = new EcsTestData(y);

            Assert.AreEqual(width,height);
                
            // Transpose emulates whatever kind of sorting you might do...
            for (int y=0;y<width;y++)
            for (int x = y+1; x < width; x++)
            {
                var leftChunkInstanceIndex = grid.ChunkinstanceIndex(x, y);
                var leftChunk = grid.Chunks[grid.ChunkIndex(x, y)];
                var rightChunkInstanceIndex = grid.ChunkinstanceIndex(y,x);
                var rightChunk = grid.Chunks[grid.ChunkIndex(y,x)];

                m_Manager.SwapComponents(leftChunk,leftChunkInstanceIndex,rightChunk,rightChunkInstanceIndex);
            }
                
            for (int y = 0; y < height; y++)
            for (int x = 0; x < width; x++)
                Assert.AreEqual(x, ecsTestDataGrid[x, y].value);
           
            chunks.Dispose();
            ecsTestDataGrid.Dispose();
        }
    }
}