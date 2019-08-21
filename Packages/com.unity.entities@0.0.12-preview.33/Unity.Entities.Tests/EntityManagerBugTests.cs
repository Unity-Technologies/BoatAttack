using System;
using Unity.Collections;
using NUnit.Framework;
using System.Collections.Generic;

namespace Unity.Entities.Tests
{
    public struct Issue149Data : IComponentData
    {
        public int a;
        public int b;
    }

    public struct Issue476Data : IComponentData
    {
        public int a;
        public int b;
    }

    class Bug149 : ECSTestsFixture
    {
        EntityArchetype m_Archetype;

        const int kBatchCount = 512;

        class EntityBag
        {
            public NativeArray<Entity> Entities;
            public int ValidVersion;
        }

        EntityBag[] Bags = new EntityBag[3];

        [Test]
        public void TestIssue149()
        {
            m_OurTypes = new ComponentType[] {typeof(Issue149Data)};

            m_Archetype = m_Manager.CreateArchetype(typeof(Issue149Data));

            for (int i = 0; i < Bags.Length; ++i)
            {
                Bags[i] = new EntityBag();
            }

            var a = Bags[0];
            var b = Bags[1];
            var c = Bags[2];

            try
            {
                RecycleEntities(a);
                RecycleEntities(b);
                RecycleEntities(c);
                RecycleEntities(a);
                RecycleEntities(b);
                RecycleEntities(a);
                RecycleEntities(c);
                RecycleEntities(a);
                RecycleEntities(a);
                RecycleEntities(b);
                RecycleEntities(a);
                RecycleEntities(c);
                RecycleEntities(a);
            }
            finally
            {
                // To get rid of leak errors in the log when the test fails.
                a.Entities.Dispose();
                b.Entities.Dispose();
                c.Entities.Dispose();
            }
        }

        void RecycleEntities(EntityBag bag)
        {
            if (bag.Entities.Length > 0)
            {
                m_Manager.DestroyEntity(bag.Entities);
                bag.Entities.Dispose();
            }

            bag.ValidVersion++;

            // Sanity check all arrays.
            SanityCheckVersions();

            bag.Entities = new NativeArray<Entity>(kBatchCount, Allocator.Persistent);

            for (int i = 0; i < bag.Entities.Length; ++i)
            {
                bag.Entities[i] = m_Manager.CreateEntity(m_Archetype);
            }
        }

        private ComponentType[] m_OurTypes;

        // Walk all accessible entity data and check that the versions match what we
        // believe the generation numbers should be.
        private void SanityCheckVersions()
        {
            var group = m_Manager.CreateEntityQuery(new EntityQueryDesc
            {
                Any = Array.Empty<ComponentType>(),
                None = Array.Empty<ComponentType>(),
                All = m_OurTypes,
            });
            var chunks = group.CreateArchetypeChunkArray(Allocator.TempJob);
            group.Dispose();

            ArchetypeChunkEntityType entityType = m_Manager.GetArchetypeChunkEntityType();

            for (int i = 0; i < chunks.Length; ++i)
            {
                ArchetypeChunk chunk = chunks[i];
                var entitiesInChunk = chunk.GetNativeArray(entityType);

                for (int k = 0; k < chunk.Count; ++k)
                {
                    Entity e = entitiesInChunk[k];
                    int index = e.Index;
                    int version = e.Version;

                    int ourArray = index / kBatchCount;
                    int ourVersion = Bags[ourArray].ValidVersion;

                    Assert.IsTrue(ourVersion == version);
                }
            }

            chunks.Dispose();
        }
    }

    class Bug476 : ECSTestsFixture
    {
        [Test]
        public void EntityArchetypeQueryMembersHaveSensibleDefaults()
        {
            ComponentType[] types = {typeof(Issue476Data)};
            var group = m_Manager.CreateEntityQuery(types);
            var temp = group.CreateArchetypeChunkArray(Allocator.TempJob);
            group.Dispose();
            temp.Dispose();
        }
    }

    class Bug148
    {
        [Test]
        public void Test1()
        {
#if !UNITY_DOTSPLAYER
            World w = new World("TestWorld");
#else
            World w = DefaultTinyWorldInitialization.Initialize("TestWorld");
#endif
            World.Active = w;
            EntityManager em = World.Active.EntityManager;
            List<Entity> remember = new List<Entity>();
            for (int i = 0; i < 5; i++)
            {
                remember.Add(em.CreateEntity());
            }

            var allEnt = em.GetAllEntities(Allocator.Temp);
            allEnt.Dispose();
            foreach (Entity e in remember)
            {
                Assert.IsTrue(em.Exists(e));
            }

            foreach (Entity e in remember)
            {
                em.DestroyEntity(e);
            }
        }

        [Test]
        public void Test2()
        {
#if !UNITY_DOTSPLAYER
            World w = new World("TestWorld");
#else
            World w = DefaultTinyWorldInitialization.Initialize("TestWorld");
#endif
            World.Active = w;
            EntityManager em = World.Active.EntityManager;

            List<Entity> remember = new List<Entity>();
            for (int i = 0; i < 5; i++)
            {
                remember.Add(em.CreateEntity());
            }

            w = null;
            World.DisposeAllWorlds();

#if !UNITY_DOTSPLAYER
            w = new World("TestWorld2");
#else
            w = DefaultTinyWorldInitialization.Initialize("TestWorld");
#endif
            World.Active = w;
            em = World.Active.EntityManager;
            var allEnt = em.GetAllEntities(Allocator.Temp);
            Assert.AreEqual(0, allEnt.Length);
            allEnt.Dispose();

            foreach (Entity e in remember)
            {
                bool exists = em.Exists(e);
                Assert.IsFalse(exists);
            }

            foreach (Entity e in remember)
            {
                if (em.Exists(e))
                {
                    em.DestroyEntity(e);
                }
            }

            World.DisposeAllWorlds();
        }
    }
}
