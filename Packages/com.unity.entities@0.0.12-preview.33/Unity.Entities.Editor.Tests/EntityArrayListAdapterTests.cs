using NUnit.Framework;
using Unity.Collections;
using Unity.Entities.Tests;

namespace Unity.Entities.Editor.Tests
{
    class EntityArrayListAdapterTests : ECSTestsFixture
    {
        private NativeArray<ArchetypeChunk> m_ChunkArray;

        public override void Setup()
        {
            base.Setup();
            
            var archetype = m_Manager.CreateArchetype(new ComponentType[] {typeof(EcsTestData), typeof(EcsTestData2), typeof(EcsTestData3),
                typeof(EcsTestData4)});
            using (var entities = new NativeArray<Entity>(100000, Allocator.Temp))
            {
                m_Manager.CreateEntity(archetype, entities);
            }

            var query = new EntityQueryDesc()
            {
                Any = new ComponentType[0],
                All = new ComponentType[0],
                None = new ComponentType[0]
            };

            var group = m_Manager.CreateEntityQuery(query);
            m_ChunkArray = group.CreateArchetypeChunkArray(Allocator.TempJob);
        }

        public override void TearDown()
        {
            m_ChunkArray.Dispose();
            base.TearDown();
        }

        [Test]
        public void EntityArrayListAdapter_SequentialAccessConsistent()
        {
            var adapter = new EntityArrayListAdapter();
            adapter.SetSource(m_ChunkArray, m_Manager, null);
            var e1 = adapter[50001].id;
            var e2 = adapter[50002].id;
            var e3 = adapter[50003].id;
            var e2Again = adapter[50002].id;
            var e1Again = adapter[50001].id;
            Assert.AreNotEqual(e1, e2);
            Assert.AreNotEqual(e1, e2Again);
            Assert.AreNotEqual(e2, e1Again);
            Assert.AreEqual(e1, e1Again);
            Assert.AreEqual(e2, e2Again);
            
        }

        [Test]
        public void EntityArrayListAdapter_Enumerator_Resets()
        {
            var adapter = new EntityArrayListAdapter();
            adapter.SetSource(m_ChunkArray, m_Manager, null);
            using (var iterator = adapter.GetEnumerator())
            {
                var ids = new int[5];
                for (var i = 0; i < ids.Length; ++i)
                {
                    Assert.IsTrue(iterator.MoveNext());
                    ids[i] = iterator.Current.id;
                }
                iterator.Reset();
                for (var i = 0; i < ids.Length; ++i)
                {
                    Assert.IsTrue(iterator.MoveNext());
                    Assert.AreEqual(ids[i], iterator.Current.id);
                }
            }
        }
    }
}