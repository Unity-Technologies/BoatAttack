using System;
using System.Linq;
using NUnit.Framework;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;

namespace Unity.Entities.Tests
{
#if !UNITY_EDITOR
    // Editor manages its own SystemGroups, so this test case is meaningless there.

    class Issue1792 : ECSTestsFixture
    {
        static bool aCreated = false;
        static bool bCreated = false;
        private static bool systemBWasCreated = false;

        [UpdateBefore(typeof(SystemB))]
        class SystemA : ComponentSystem
        {
            SystemB OtherSystem;

            protected override void OnCreate()
            {
                aCreated = true;
                base.OnCreate();
                OtherSystem = World.GetOrCreateSystem<SystemB>();
                systemBWasCreated = bCreated;
            }
            protected override void OnUpdate()
            {
            }
        }

        [UpdateAfter(typeof(SystemA))]
        class SystemB : ComponentSystem
        {
            protected override void OnCreate()
            {
                bCreated = true;
                base.OnCreate();
            }

            protected override void OnUpdate()
            {
            }
        }

        [Test]
        public void Test1792()
        {
            Assert.NotNull(World.GetExistingSystem<SystemA>());
            Assert.NotNull(World.GetExistingSystem<SystemB>());

            var sim = World.GetExistingSystem<SimulationSystemGroup>();
            Assert.NotNull(sim.Systems.FirstOrDefault(i => i.GetType() == typeof(SystemA)));
            Assert.NotNull(sim.Systems.FirstOrDefault(i => i.GetType() == typeof(SystemB)));
            Assert.IsTrue(aCreated);
            Assert.IsTrue(bCreated);
            Assert.IsTrue(systemBWasCreated);
        }
    }
#endif

    class CircleOfDoom : ECSTestsFixture
    {
        internal class SystemA : ComponentSystem
        {
            protected override void OnCreate()
            {
                base.OnCreate();
                World.GetOrCreateSystem<SystemC>();
            }

            protected override void OnUpdate()
            {
            }
        }

        internal class SystemB : ComponentSystem
        {
            protected override void OnCreate()
            {
                base.OnCreate();
                World.GetOrCreateSystem<SystemA>();
            }

            protected override void OnUpdate()
            {
            }
        }

        internal class SystemC : ComponentSystem
        {
            protected override void OnCreate()
            {
                base.OnCreate();
                World.GetOrCreateSystem<SystemB>();
            }

            protected override void OnUpdate()
            {
            }
        }

        [Test]
        public void TestCircleOfDoom()
        {
#if UNITY_EDITOR
            World.CreateSystem<SystemA>();    // Everyone else should auto-create.
#endif

            Assert.NotNull(World.GetExistingSystem<SystemA>(), "Test A not null");
            Assert.NotNull(World.GetExistingSystem<SystemB>(), "Test B not null");
            Assert.NotNull(World.GetExistingSystem<SystemC>(), "Test C not null");

#if !UNITY_EDITOR
            // Editor manages its own SystemGroups.
            var sim = World.GetExistingSystem<SimulationSystemGroup>();
            Assert.NotNull(sim.Systems.FirstOrDefault(i => i.GetType() == typeof(SystemA)), "Query A not null");
            Assert.NotNull(sim.Systems.FirstOrDefault(i => i.GetType() == typeof(SystemB)), "Query B not null");
            Assert.NotNull(sim.Systems.FirstOrDefault(i => i.GetType() == typeof(SystemC)), "QueryC not null");
#endif
        }
    }
}
