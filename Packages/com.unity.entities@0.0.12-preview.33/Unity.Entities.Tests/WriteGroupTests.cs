using System;
using NUnit.Framework;
using Unity.Collections;

namespace Unity.Entities.Tests
{
    [TestFixture]
    class WriteGroupTests : ECSTestsFixture
    {
        // 
        //     +-----------+        +----------+
        //     |TestOutputA<--------+TestInputB|
        //     +-----------+    ^   +----------+
        //          ^           |   +----------+
        //          |           +---+TestInputC|
        //     +-----------+    ^   +----------+
        //     |TestOutputB<----+   +----------+
        //     +-----------+    +---+TestInputD|
        //                          +----------+

        struct TestOutputA : IComponentData
        {
        }

        [WriteGroup(typeof(TestOutputA))]
        struct TestOutputB : IComponentData
        {
        }

        [WriteGroup(typeof(TestOutputA))]
        [WriteGroup(typeof(TestOutputB))]
        struct TestInputB : IComponentData
        {
        }

        [WriteGroup(typeof(TestOutputA))]
        [WriteGroup(typeof(TestOutputB))]
        struct TestInputC : IComponentData
        {
        }

        [WriteGroup(typeof(TestOutputA))]
        [WriteGroup(typeof(TestOutputB))]
        struct TestInputD : IComponentData
        {
        }


        [Test]
        public void WG_AllOnlyMatchesExplicit()
        {
            var archetype0 = m_Manager.CreateArchetype(typeof(TestOutputA), typeof(TestInputB), typeof(TestInputC));
            var archetype1 = m_Manager.CreateArchetype(typeof(TestOutputA), typeof(TestInputB), typeof(TestInputC),
                typeof(TestInputD));
            var group0 = m_Manager.CreateEntityQuery(new EntityQueryDesc()
            {
                All = new ComponentType[]
                {
                    typeof(TestOutputA),
                    ComponentType.ReadOnly<TestInputB>(),
                    ComponentType.ReadOnly<TestInputC>(),
                },
                Options = EntityQueryOptions.FilterWriteGroup
            });

            m_Manager.CreateEntity(archetype0);
            m_Manager.CreateEntity(archetype1);

            var results0 = group0.ToEntityArray(Allocator.TempJob);
            Assert.AreEqual(1, results0.Length);
            results0.Dispose();

            group0.Dispose();
        }

        [Test]
        public void WG_AllOnlyMatchesExplicitLateDefinition()
        {
            var group0 = m_Manager.CreateEntityQuery(new EntityQueryDesc()
            {
                All = new ComponentType[]
                {
                    typeof(TestOutputA),
                    ComponentType.ReadOnly<TestInputB>(),
                    ComponentType.ReadOnly<TestInputC>(),
                },
                Options = EntityQueryOptions.FilterWriteGroup
            });

            var archetype0 = m_Manager.CreateArchetype(typeof(TestOutputA), typeof(TestInputB), typeof(TestInputC));
            var archetype1 = m_Manager.CreateArchetype(typeof(TestOutputA), typeof(TestInputB), typeof(TestInputC),
                typeof(TestInputD));

            m_Manager.CreateEntity(archetype0);
            m_Manager.CreateEntity(archetype1);

            var results0 = group0.ToEntityArray(Allocator.TempJob);
            Assert.AreEqual(1, results0.Length);
            results0.Dispose();

            group0.Dispose();
        }

        [Test]
        public void WG_AllOnlyMatchesExtended()
        {
            var archetype0 = m_Manager.CreateArchetype(typeof(TestOutputA), typeof(TestInputB), typeof(TestInputC));
            var archetype1 = m_Manager.CreateArchetype(typeof(TestOutputA), typeof(TestInputB), typeof(TestInputC),
                typeof(TestInputD));
            var group0 = m_Manager.CreateEntityQuery(new EntityQueryDesc()
            {
                All = new ComponentType[]
                {
                    typeof(TestOutputA),
                    ComponentType.ReadOnly<TestInputB>(),
                    ComponentType.ReadOnly<TestInputC>(),
                    ComponentType.ReadOnly<TestInputD>(),
                },
                Options = EntityQueryOptions.FilterWriteGroup
            });

            m_Manager.CreateEntity(archetype0);
            m_Manager.CreateEntity(archetype1);

            var results0 = group0.ToEntityArray(Allocator.TempJob);
            Assert.AreEqual(1, results0.Length);
            results0.Dispose();

            group0.Dispose();
        }

        [Test]
        public void WG_AnyOnlyMatchesExplicit()
        {
            var archetype0 = m_Manager.CreateArchetype(typeof(TestOutputA), typeof(TestInputB), typeof(TestInputC));
            var archetype1 = m_Manager.CreateArchetype(typeof(TestOutputA), typeof(TestInputB), typeof(TestInputC),
                typeof(TestInputD));
            var group0 = m_Manager.CreateEntityQuery(new EntityQueryDesc()
            {
                Any = new ComponentType[]
                {
                    typeof(TestOutputA),
                    ComponentType.ReadOnly<TestInputB>(),
                    ComponentType.ReadOnly<TestInputC>(),
                },
                Options = EntityQueryOptions.FilterWriteGroup
            });

            m_Manager.CreateEntity(archetype0);
            m_Manager.CreateEntity(archetype1);

            var results0 = group0.ToEntityArray(Allocator.TempJob);
            Assert.AreEqual(1, results0.Length);
            results0.Dispose();

            group0.Dispose();
        }

        [Test]
        public void WG_AnyMatchesAll()
        {
            var archetype0 = m_Manager.CreateArchetype(typeof(TestOutputA), typeof(TestInputB), typeof(TestInputC));
            var archetype1 = m_Manager.CreateArchetype(typeof(TestOutputA), typeof(TestInputB), typeof(TestInputC),
                typeof(TestInputD));
            var group0 = m_Manager.CreateEntityQuery(new EntityQueryDesc()
            {
                Any = new ComponentType[]
                {
                    typeof(TestOutputA),
                    ComponentType.ReadOnly<TestInputB>(),
                    ComponentType.ReadOnly<TestInputC>(),
                    ComponentType.ReadOnly<TestInputD>(),
                },
                Options = EntityQueryOptions.FilterWriteGroup
            });

            m_Manager.CreateEntity(archetype0);
            m_Manager.CreateEntity(archetype1);

            var results0 = group0.ToEntityArray(Allocator.TempJob);
            Assert.AreEqual(2, results0.Length);
            results0.Dispose();

            group0.Dispose();
        }

        [Test]
        public void WG_AnyExplicitlyExcludesExtension()
        {
            var archetype0 = m_Manager.CreateArchetype(typeof(TestOutputA), typeof(TestInputB), typeof(TestInputC));
            var archetype1 = m_Manager.CreateArchetype(typeof(TestOutputA), typeof(TestInputB), typeof(TestInputC),
                typeof(TestInputD));
            var group0 = m_Manager.CreateEntityQuery(new EntityQueryDesc()
            {
                Any = new ComponentType[]
                {
                    typeof(TestOutputA),
                    ComponentType.ReadOnly<TestInputB>(),
                    ComponentType.ReadOnly<TestInputC>(),
                },
                None = new ComponentType[]
                {
                    ComponentType.ReadOnly<TestInputD>(),
                },
                Options = EntityQueryOptions.FilterWriteGroup
            });

            m_Manager.CreateEntity(archetype0);
            m_Manager.CreateEntity(archetype1);

            var results0 = group0.ToEntityArray(Allocator.TempJob);
            Assert.AreEqual(1, results0.Length);
            results0.Dispose();

            group0.Dispose();
        }

        [Test]
        public void WG_AllAllowsDependentWriteGroups()
        {
            var archetype0 = m_Manager.CreateArchetype(typeof(TestOutputA), typeof(TestOutputB), typeof(TestInputB),
                typeof(TestInputC));
            var archetype1 = m_Manager.CreateArchetype(typeof(TestOutputA), typeof(TestOutputB), typeof(TestInputB),
                typeof(TestInputC), typeof(TestInputD));
            var group0 = m_Manager.CreateEntityQuery(new EntityQueryDesc()
            {
                All = new ComponentType[]
                {
                    typeof(TestOutputA),
                    ComponentType.ReadOnly<TestOutputB>()
                },
                Options = EntityQueryOptions.FilterWriteGroup
            });

            m_Manager.CreateEntity(archetype0);
            m_Manager.CreateEntity(archetype1);

            var results0 = group0.ToEntityArray(Allocator.TempJob);
            Assert.AreEqual(2, results0.Length);
            results0.Dispose();

            group0.Dispose();
        }

        [Test]
        public void WG_AllExcludesFromDependentWriteGroup()
        {
            var archetype0 = m_Manager.CreateArchetype(typeof(TestOutputA), typeof(TestOutputB), typeof(TestInputB),
                typeof(TestInputC));
            var archetype1 = m_Manager.CreateArchetype(typeof(TestOutputA), typeof(TestOutputB), typeof(TestInputB),
                typeof(TestInputC), typeof(TestInputD));
            var group0 = m_Manager.CreateEntityQuery(new EntityQueryDesc()
            {
                All = new ComponentType[]
                {
                    typeof(TestOutputA),
                    ComponentType.ReadOnly<TestInputB>()
                },
                Options = EntityQueryOptions.FilterWriteGroup
            });

            m_Manager.CreateEntity(archetype0);
            m_Manager.CreateEntity(archetype1);

            var results0 = group0.ToEntityArray(Allocator.TempJob);
            Assert.AreEqual(0, results0.Length);
            results0.Dispose();

            group0.Dispose();
        }
        
        [Test]
        public void WG_NotExcludesWhenOverrideWriteGroup()
        {
            var archetype0 = m_Manager.CreateArchetype(typeof(TestOutputA), typeof(TestOutputB), typeof(TestInputB),
                typeof(TestInputC));
            var archetype1 = m_Manager.CreateArchetype(typeof(TestOutputA), typeof(TestOutputB), typeof(TestInputB),
                typeof(TestInputC), typeof(TestInputD));
            // Not specified Options = EntityQueryOptions.FilterWriteGroup means that WriteGroup is being overridden (ignored)
            var group0 = m_Manager.CreateEntityQuery(new EntityQueryDesc()
            {
                All = new ComponentType[]
                {
                    typeof(TestOutputA),
                    ComponentType.ReadOnly<TestInputB>()
                }
            });

            m_Manager.CreateEntity(archetype0);
            m_Manager.CreateEntity(archetype1);

            var results0 = group0.ToEntityArray(Allocator.TempJob);
            Assert.AreEqual(2, results0.Length);
            results0.Dispose();

            group0.Dispose();
        }
    }
}
