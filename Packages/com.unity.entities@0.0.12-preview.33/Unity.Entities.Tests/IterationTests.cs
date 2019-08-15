using System;
using NUnit.Framework;
using Unity.Collections;
using System.Collections.Generic;

namespace Unity.Entities.Tests
{
	class IterationTests : ECSTestsFixture
	{
		[Test]
		public void CreateEntityQuery()
		{
			var archetype = m_Manager.CreateArchetype(typeof(EcsTestData), typeof(EcsTestData2));

			var group = m_Manager.CreateEntityQuery(typeof(EcsTestData), typeof(EcsTestData2));
			Assert.AreEqual(0, group.CalculateLength());

			var entity = m_Manager.CreateEntity(archetype);
            m_Manager.SetComponentData(entity, new EcsTestData(42));
			var arr = group.ToComponentDataArray<EcsTestData>(Allocator.TempJob);
			Assert.AreEqual(1, arr.Length);
			Assert.AreEqual(42, arr[0].value);

			arr.Dispose();
			m_Manager.DestroyEntity(entity);
		}

	    struct TempComponentNeverInstantiated : IComponentData
	    {
	        private int m_Internal;
	    }
	    
		[Test]
		public void IterateEmptyArchetype()
		{
			var group = m_Manager.CreateEntityQuery(typeof(TempComponentNeverInstantiated));
			Assert.AreEqual(0, group.CalculateLength());

			var archetype = m_Manager.CreateArchetype(typeof(TempComponentNeverInstantiated));
			Assert.AreEqual(0, group.CalculateLength());

			Entity ent = m_Manager.CreateEntity(archetype);
			Assert.AreEqual(1, group.CalculateLength());
			m_Manager.DestroyEntity(ent);
			Assert.AreEqual(0, group.CalculateLength());
		}
		[Test]
		public void IterateChunkedEntityQuery()
		{
			var archetype1 = m_Manager.CreateArchetype(typeof(EcsTestData));
			var archetype2 = m_Manager.CreateArchetype(typeof(EcsTestData), typeof(EcsTestData2));

			var group = m_Manager.CreateEntityQuery(typeof(EcsTestData));
			Assert.AreEqual(0, group.CalculateLength());

            Entity[] entities = new Entity[10000];
            for (int i = 0; i < entities.Length/2;i++)
            {
				entities[i] = m_Manager.CreateEntity(archetype1);
				m_Manager.SetComponentData(entities[i], new EcsTestData(i));
            }
            for (int i = entities.Length/2; i < entities.Length;i++)
            {
				entities[i] = m_Manager.CreateEntity(archetype2);
				m_Manager.SetComponentData(entities[i], new EcsTestData(i));
            }

			var arr = group.ToComponentDataArray<EcsTestData>(Allocator.TempJob);
			Assert.AreEqual(entities.Length, arr.Length);
			HashSet<int> values = new HashSet<int>();
            for (int i = 0; i < arr.Length;i++)
			{
				int val = arr[i].value;
				Assert.IsFalse(values.Contains(i));
				Assert.IsTrue(val >= 0);
				Assert.IsTrue(val < entities.Length);
				values.Add(i);
			}

            arr.Dispose();
            for (int i = 0; i < entities.Length;i++)
				m_Manager.DestroyEntity(entities[i]);
		}
		[Test]
		public void IterateChunkedComponentGroupBackwards()
		{
			var archetype1 = m_Manager.CreateArchetype(typeof(EcsTestData));
			var archetype2 = m_Manager.CreateArchetype(typeof(EcsTestData), typeof(EcsTestData2));

			var group = m_Manager.CreateEntityQuery(typeof(EcsTestData));
			Assert.AreEqual(0, group.CalculateLength());

            Entity[] entities = new Entity[10000];
            for (int i = 0; i < entities.Length/2;i++)
            {
				entities[i] = m_Manager.CreateEntity(archetype1);
				m_Manager.SetComponentData(entities[i], new EcsTestData(i));
            }
            for (int i = entities.Length/2; i < entities.Length;i++)
            {
				entities[i] = m_Manager.CreateEntity(archetype2);
				m_Manager.SetComponentData(entities[i], new EcsTestData(i));
            }

			var arr = group.ToComponentDataArray<EcsTestData>(Allocator.TempJob);
			Assert.AreEqual(entities.Length, arr.Length);
			HashSet<int> values = new HashSet<int>();
            for (int i = arr.Length-1; i >= 0;i--)
			{
				int val = arr[i].value;
				Assert.IsFalse(values.Contains(i));
				Assert.IsTrue(val >= 0);
				Assert.IsTrue(val < entities.Length);
				values.Add(i);
			}

            arr.Dispose();
            for (int i = 0; i < entities.Length;i++)
				m_Manager.DestroyEntity(entities[i]);
		}



		[Test]
		public void IterateChunkedComponentGroupAfterDestroy()
		{
			var archetype1 = m_Manager.CreateArchetype(typeof(EcsTestData));
			var archetype2 = m_Manager.CreateArchetype(typeof(EcsTestData), typeof(EcsTestData2));

			var group = m_Manager.CreateEntityQuery(typeof(EcsTestData));
			Assert.AreEqual(0, group.CalculateLength());

            Entity[] entities = new Entity[10000];
            for (int i = 0; i < entities.Length/2;i++)
            {
				entities[i] = m_Manager.CreateEntity(archetype1);
				m_Manager.SetComponentData(entities[i], new EcsTestData(i));
            }
            for (int i = entities.Length/2; i < entities.Length;i++)
            {
				entities[i] = m_Manager.CreateEntity(archetype2);
				m_Manager.SetComponentData(entities[i], new EcsTestData(i));
            }
            for (int i = 0; i < entities.Length;i++)
			{
				if (i%2 != 0)
				{
					m_Manager.DestroyEntity(entities[i]);
				}
			}

			var arr = group.ToComponentDataArray<EcsTestData>(Allocator.TempJob);
			Assert.AreEqual(entities.Length/2, arr.Length);
			HashSet<int> values = new HashSet<int>();
            for (int i = 0; i < arr.Length;i++)
			{
				int val = arr[i].value;
				Assert.IsFalse(values.Contains(i));
				Assert.IsTrue(val >= 0);
				Assert.IsTrue(val%2 == 0);
				Assert.IsTrue(val < entities.Length);
				values.Add(i);
			}

            for (int i = entities.Length/2; i < entities.Length;i++)
            {
				if (i%2 == 0)
					m_Manager.RemoveComponent<EcsTestData>(entities[i]);
            }
            arr.Dispose();
			arr = group.ToComponentDataArray<EcsTestData>(Allocator.TempJob);
			Assert.AreEqual(entities.Length/4, arr.Length);
			values = new HashSet<int>();
            for (int i = 0; i < arr.Length;i++)
			{
				int val = arr[i].value;
				Assert.IsFalse(values.Contains(i));
				Assert.IsTrue(val >= 0);
				Assert.IsTrue(val%2 == 0);
				Assert.IsTrue(val < entities.Length/2);
				values.Add(i);
			}

            for (int i = 0; i < entities.Length;i++)
			{
				if (i%2 == 0)
					m_Manager.DestroyEntity(entities[i]);
			}
            arr.Dispose();
		}
        
        [Test]
        public void GroupCopyFromNativeArray()
        {
            var archetype = m_Manager.CreateArchetype(typeof(EcsTestData));
            var entities = new NativeArray<Entity>(10, Allocator.Persistent);
            m_Manager.CreateEntity(archetype, entities);
            
            var dataToCopyA = new NativeArray<EcsTestData>(10, Allocator.Persistent);
            var dataToCopyB = new NativeArray<EcsTestData>(5, Allocator.Persistent);

            for (int i = 0; i < dataToCopyA.Length; ++i)
            {
                dataToCopyA[i] = new EcsTestData{value = 2};
            }
            
            for (int i = 0; i < dataToCopyB.Length; ++i)
            {
                dataToCopyA[i] = new EcsTestData{value = 3};

            }
            
            var group = m_Manager.CreateEntityQuery(typeof(EcsTestData));
            group.CopyFromComponentDataArray(dataToCopyA);

            for (int i = 0; i < dataToCopyA.Length; ++i)
            {
                Assert.AreEqual(m_Manager.GetComponentData<EcsTestData>(entities[i]).value, dataToCopyA[i].value);
            }
            
            Assert.Throws<ArgumentException>(() => { group.CopyFromComponentDataArray(dataToCopyB); });
            
            group.Dispose();           
            entities.Dispose();
            dataToCopyA.Dispose();
            dataToCopyB.Dispose();
        }
        
        [Test]
        [StandaloneFixme]
        public void ComponentGroupFilteredEntityIndexWithMultipleArchetypes()
        {
            var archetypeA = m_Manager.CreateArchetype(typeof(EcsTestData), typeof(EcsTestData2), typeof(EcsTestSharedComp));
            var archetypeB = m_Manager.CreateArchetype(typeof(EcsTestData), typeof(EcsTestSharedComp));

            var group = m_Manager.CreateEntityQuery(typeof(EcsTestData), typeof(EcsTestSharedComp));

            var entity1A = m_Manager.CreateEntity(archetypeA);
            var entity2A = m_Manager.CreateEntity(archetypeA);
            var entityB  = m_Manager.CreateEntity(archetypeB);

            m_Manager.SetSharedComponentData(entity1A, new EcsTestSharedComp{ value = 1});
            m_Manager.SetSharedComponentData(entity2A, new EcsTestSharedComp{ value = 2});

            m_Manager.SetSharedComponentData(entityB, new EcsTestSharedComp{ value = 1});

            group.SetFilter(new EcsTestSharedComp{value = 1});

            var iterator = group.GetComponentChunkIterator();
            iterator.MoveToChunkWithoutFiltering(2); // 2 is index of chunk
            iterator.GetCurrentChunkRange(out var begin, out var end );

            Assert.AreEqual(1, begin); // 1 is index of entity in filtered EntityQuery

            group.Dispose();
        }
        
        [Test]
        [StandaloneFixme]
        public void ComponentGroupFilteredChunkCount()
        {
            var archetypeA = m_Manager.CreateArchetype(typeof(EcsTestData), typeof(EcsTestData2), typeof(EcsTestSharedComp));

            var group = m_Manager.CreateEntityQuery(typeof(EcsTestData), typeof(EcsTestSharedComp));

            for (int i = 0; i < archetypeA.ChunkCapacity * 2; ++i)
            {
                var entityA = m_Manager.CreateEntity(archetypeA);
                m_Manager.SetSharedComponentData(entityA, new EcsTestSharedComp{ value = 1});
            }

            var entityB  = m_Manager.CreateEntity(archetypeA);
            m_Manager.SetSharedComponentData(entityB, new EcsTestSharedComp{ value = 2});
            
            group.SetFilter(new EcsTestSharedComp{value = 1});
            {
                var iterator = group.GetComponentChunkIterator();

                int begin, end;
                iterator.MoveToChunkWithoutFiltering(0);
                iterator.GetCurrentChunkRange(out begin, out end);
                Assert.AreEqual(0, begin);

                iterator.MoveToChunkWithoutFiltering(1);
                iterator.GetCurrentChunkRange(out begin, out end);
                Assert.AreEqual(archetypeA.ChunkCapacity, begin);

                iterator.MoveToChunkWithoutFiltering(2);
                Assert.Throws<InvalidOperationException>(() => { iterator.GetCurrentChunkRange(out begin, out end); });

            }

            group.SetFilter(new EcsTestSharedComp{value = 2});
            {
                var iterator = group.GetComponentChunkIterator();

                int begin, end;
                iterator.MoveToChunkWithoutFiltering(0);
                Assert.Throws<InvalidOperationException>(() => { iterator.GetCurrentChunkRange(out begin, out end); });

                iterator.MoveToChunkWithoutFiltering(1);
                Assert.Throws<InvalidOperationException>(() => { iterator.GetCurrentChunkRange(out begin, out end); });

                iterator.MoveToChunkWithoutFiltering(2);
                iterator.GetCurrentChunkRange(out begin, out end);
                Assert.AreEqual(0, begin);
            }

            group.Dispose();
        }
		
	}
}
