using System;
using NUnit.Framework;
using Unity.Collections;

namespace Unity.Entities.Tests
{
	class DisableComponentTests : ECSTestsFixture
	{
		[Test]
		public void DIS_DontFindDisabledInEntityQuery()
		{
		    var archetype0 = m_Manager.CreateArchetype(typeof(EcsTestData));
			var archetype1 = m_Manager.CreateArchetype(typeof(EcsTestData), typeof(Disabled));

		    var group = m_Manager.CreateEntityQuery(typeof(EcsTestData));

			var entity0 = m_Manager.CreateEntity(archetype0);
			var entity1 = m_Manager.CreateEntity(archetype1);

			Assert.AreEqual(1, group.CalculateLength());
            group.Dispose();

			m_Manager.DestroyEntity(entity0);
			m_Manager.DestroyEntity(entity1);
		}

	    [Test]
	    public void DIS_DontFindDisabledInChunkIterator()
	    {
	        var archetype0 = m_Manager.CreateArchetype(typeof(EcsTestData));
	        var archetype1 = m_Manager.CreateArchetype(typeof(EcsTestData), typeof(Disabled));

	        var entity0 = m_Manager.CreateEntity(archetype0);
	        var entity1 = m_Manager.CreateEntity(archetype1);

            var group = m_Manager.CreateEntityQuery(ComponentType.ReadWrite<EcsTestData>());
	        var chunks = group.CreateArchetypeChunkArray(Allocator.TempJob);
            group.Dispose();
	        var count = ArchetypeChunkArray.CalculateEntityCount(chunks);
	        chunks.Dispose();

	        Assert.AreEqual(1, count);

	        m_Manager.DestroyEntity(entity0);
	        m_Manager.DestroyEntity(entity1);
	    }

		[Test]
		public void DIS_FindDisabledIfRequestedInEntityQuery()
		{
		    var archetype0 = m_Manager.CreateArchetype(typeof(EcsTestData));
			var archetype1 = m_Manager.CreateArchetype(typeof(EcsTestData), typeof(Disabled));

            var group = m_Manager.CreateEntityQuery(ComponentType.ReadWrite<EcsTestData>(), ComponentType.ReadWrite<Disabled>());

			var entity0 = m_Manager.CreateEntity(archetype0);
			var entity1 = m_Manager.CreateEntity(archetype1);
			var entity2 = m_Manager.CreateEntity(archetype1);

			Assert.AreEqual(2, group.CalculateLength());

            group.Dispose();
			m_Manager.DestroyEntity(entity0);
			m_Manager.DestroyEntity(entity1);
			m_Manager.DestroyEntity(entity2);
		}

	    [Test]
	    public void DIS_FindDisabledIfRequestedInChunkIterator()
	    {
	        var archetype0 = m_Manager.CreateArchetype(typeof(EcsTestData));
	        var archetype1 = m_Manager.CreateArchetype(typeof(EcsTestData), typeof(Disabled));

	        var entity0 = m_Manager.CreateEntity(archetype0);
	        var entity1 = m_Manager.CreateEntity(archetype1);
	        var entity2 = m_Manager.CreateEntity(archetype1);

            var group = m_Manager.CreateEntityQuery(ComponentType.ReadWrite<EcsTestData>(), ComponentType.ReadWrite<Disabled>());
	        var chunks = group.CreateArchetypeChunkArray(Allocator.TempJob);
            group.Dispose();
	        var count = ArchetypeChunkArray.CalculateEntityCount(chunks);
	        chunks.Dispose();

	        Assert.AreEqual(2, count);

	        m_Manager.DestroyEntity(entity0);
	        m_Manager.DestroyEntity(entity1);
	        m_Manager.DestroyEntity(entity2);
	    }

	    [Test]
	    public void DIS_GetAllIncludesDisabled()
	    {
	        var archetype0 = m_Manager.CreateArchetype(typeof(EcsTestData));
	        var archetype1 = m_Manager.CreateArchetype(typeof(EcsTestData), typeof(Disabled));

	        var entity0 = m_Manager.CreateEntity(archetype0);
	        var entity1 = m_Manager.CreateEntity(archetype1);
	        var entity2 = m_Manager.CreateEntity(archetype1);

	        var entities = m_Manager.GetAllEntities();
	        Assert.AreEqual(3,entities.Length);
	        entities.Dispose();

	        m_Manager.DestroyEntity(entity0);
	        m_Manager.DestroyEntity(entity1);
	        m_Manager.DestroyEntity(entity2);
	    }
        
        [Test]
        public void PrefabAndDisabledQueryOptions()
        {
            m_Manager.CreateEntity();
            m_Manager.CreateEntity(typeof(EcsTestData), typeof(Prefab));
            m_Manager.CreateEntity(typeof(EcsTestData), typeof(Disabled));
            m_Manager.CreateEntity(typeof(EcsTestData), typeof(Disabled), typeof(Prefab));

            CheckPrefabAndDisabledQueryOptions(EntityQueryOptions.Default, 0);
            CheckPrefabAndDisabledQueryOptions(EntityQueryOptions.IncludePrefab, 1);
            CheckPrefabAndDisabledQueryOptions(EntityQueryOptions.IncludeDisabled, 1);
            CheckPrefabAndDisabledQueryOptions(EntityQueryOptions.IncludeDisabled | EntityQueryOptions.IncludePrefab, 3);
        }

        void CheckPrefabAndDisabledQueryOptions(EntityQueryOptions options, int expected)
        {
            var group = m_Manager.CreateEntityQuery(new EntityQueryDesc { All = new[] {ComponentType.ReadWrite<EcsTestData>()}, Options = options });
            Assert.AreEqual(expected, group.CalculateLength());
            group.Dispose();
        }
    }
}
