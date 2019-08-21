using System;
using System.Collections;
using System.Linq;
using System.Text.RegularExpressions;
using NUnit.Framework;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.TestTools;

namespace Unity.Entities.Tests
{
    class ComponentSystemGroupTests : ECSTestsFixture
    {
        class TestGroup : ComponentSystemGroup
        {

        }

#if NET_DOTS
        private class TestSystemBase :ComponentSystem
        {
            protected override void OnUpdate() => throw new System.NotImplementedException();
        }

#else
        private class TestSystemBase : JobComponentSystem
        {
            protected override JobHandle OnUpdate(JobHandle inputDeps) => throw new System.NotImplementedException();
        }
#endif

        [Test]
        public void SortEmptyParentSystem()
        {
            var parent = new TestGroup();
            Assert.DoesNotThrow(() => { parent.SortSystemUpdateList(); });
        }

        class TestSystem : TestSystemBase
        {
        }

        [Test]
        public void SortOneChildSystem()
        {
            var parent = World.CreateSystem<TestGroup>();
            var child = World.CreateSystem<TestSystem>();
            parent.AddSystemToUpdateList(child);
            parent.SortSystemUpdateList();
            CollectionAssert.AreEqual(new[] {child}, parent.Systems);
        }

        [UpdateAfter(typeof(Sibling2System))]
        class Sibling1System : TestSystemBase
        {
        }
        class Sibling2System : TestSystemBase
        {
        }

        [Test]
        public void SortTwoChildSystems_CorrectOrder()
        {
            var parent = World.CreateSystem<TestGroup>();
            var child1 = World.CreateSystem<Sibling1System>();
            var child2 = World.CreateSystem<Sibling2System>();
            parent.AddSystemToUpdateList(child1);
            parent.AddSystemToUpdateList(child2);
            parent.SortSystemUpdateList();
            CollectionAssert.AreEqual(new TestSystemBase[] {child2, child1}, parent.Systems);
        }

        // This test constructs the following system dependency graph:
        // 1 -> 2 -> 3 -> 4 -v
        //           ^------ 5 -> 6
        // The expected results of topologically sorting this graph:
        // - systems 1 and 2 are properly sorted in the system update list.
        // - systems 3, 4, and 5 form a cycle (in that order, or equivalent).
        // - system 6 is not sorted AND is not part of the cycle.
        [UpdateBefore(typeof(Circle2System))]
        class Circle1System : TestSystemBase
        {
        }
        [UpdateBefore(typeof(Circle3System))]
        class Circle2System : TestSystemBase
        {
        }
        [UpdateAfter(typeof(Circle5System))]
        class Circle3System : TestSystemBase
        {
        }
        [UpdateAfter(typeof(Circle3System))]
        class Circle4System : TestSystemBase
        {
        }
        [UpdateAfter(typeof(Circle4System))]
        class Circle5System : TestSystemBase
        {
        }
        [UpdateAfter(typeof(Circle5System))]
        class Circle6System : TestSystemBase
        {
        }

        [Test]
#if NET_DOTS
        [Ignore("Tiny pre-compiles systems. Many tests will fail if they exist, not just this one.")]
#endif
        public void DetectCircularDependency_Throws()
        {
            var parent = World.CreateSystem<TestGroup>();
            var child1 = World.CreateSystem<Circle1System>();
            var child2 = World.CreateSystem<Circle2System>();
            var child3 = World.CreateSystem<Circle3System>();
            var child4 = World.CreateSystem<Circle4System>();
            var child5 = World.CreateSystem<Circle5System>();
            var child6 = World.CreateSystem<Circle6System>();
            parent.AddSystemToUpdateList(child3);
            parent.AddSystemToUpdateList(child6);
            parent.AddSystemToUpdateList(child2);
            parent.AddSystemToUpdateList(child4);
            parent.AddSystemToUpdateList(child1);
            parent.AddSystemToUpdateList(child5);
            var e = Assert.Throws<CircularSystemDependencyException>(() => parent.SortSystemUpdateList());
            // Make sure the system upstream of the cycle was properly sorted
            CollectionAssert.AreEqual(new TestSystemBase[] {child1, child2}, parent.Systems);
            // Make sure the cycle expressed in e.Chain is the one we expect, even though it could start at any node
            // in the cycle.
            var expectedCycle = new TestSystemBase[] {child5, child3, child4};
            var cycle = e.Chain.ToList();
            bool foundCycleMatch = false;
            for (int i = 0; i < cycle.Count; ++i)
            {
                var offsetCycle = new System.Collections.Generic.List<ComponentSystemBase>(cycle.Count);
                offsetCycle.AddRange(cycle.GetRange(i, cycle.Count - i));
                offsetCycle.AddRange(cycle.GetRange(0, i));
                Assert.AreEqual(cycle.Count, offsetCycle.Count);
                if (expectedCycle.SequenceEqual(offsetCycle))
                {
                    foundCycleMatch = true;
                    break;
                }
            }
            Assert.IsTrue(foundCycleMatch);
        }


        class Unconstrained1System : TestSystemBase
        {
        }
        class Unconstrained2System : TestSystemBase
        {
        }
        class Unconstrained3System : TestSystemBase
        {
        }
        class Unconstrained4System : TestSystemBase
        {
        }
        [Test]
        public void SortUnconstrainedSystems_IsDeterministic()
        {
            var parent = World.CreateSystem<TestGroup>();
            var child1 = World.CreateSystem<Unconstrained1System>();
            var child2 = World.CreateSystem<Unconstrained2System>();
            var child3 = World.CreateSystem<Unconstrained3System>();
            var child4 = World.CreateSystem<Unconstrained4System>();
            parent.AddSystemToUpdateList(child2);
            parent.AddSystemToUpdateList(child4);
            parent.AddSystemToUpdateList(child3);
            parent.AddSystemToUpdateList(child1);
            parent.SortSystemUpdateList();
            CollectionAssert.AreEqual(parent.Systems, new TestSystemBase[] {child1, child2, child3, child4});
        }

        private class UpdateCountingSystemBase : ComponentSystem
        {
            public int CompleteUpdateCount = 0;
            protected override void OnUpdate()
            {
                ++CompleteUpdateCount;
            }
        }
        class NonThrowing1System : UpdateCountingSystemBase
        {
        }
        class NonThrowing2System : UpdateCountingSystemBase
        {
        }
        class ThrowingSystem : UpdateCountingSystemBase
        {
            public string ExceptionMessage = "I should always throw!";
            protected override void OnUpdate()
            {
                if (CompleteUpdateCount == 0)
                {
                    throw new InvalidOperationException(ExceptionMessage);
                }
                base.OnUpdate();
            }
        }

#if !NET_DOTS // Tiny precompiles systems, and lacks a Regex overload for LogAssert.Expect()
        [Test]
        public void SystemInGroupThrows_LaterSystemsRun()
        {
            var parent = World.CreateSystem<TestGroup>();
            var child1 = World.CreateSystem<NonThrowing1System>();
            var child2 = World.CreateSystem<ThrowingSystem>();
            var child3 = World.CreateSystem<NonThrowing2System>();
            parent.AddSystemToUpdateList(child1);
            parent.AddSystemToUpdateList(child2);
            parent.AddSystemToUpdateList(child3);
            parent.Update();
            LogAssert.Expect(LogType.Exception, new Regex(child2.ExceptionMessage));
            Assert.AreEqual(1, child1.CompleteUpdateCount);
            Assert.AreEqual(0, child2.CompleteUpdateCount);
            Assert.AreEqual(1, child3.CompleteUpdateCount);
        }
#endif

#if !NET_DOTS // Tiny precompiles systems, and lacks a Regex overload for LogAssert.Expect()
        [Test]
        public void RemoveSystemFromGroup_Succeeds()
        {
            var parent = World.CreateSystem<TestGroup>();
            var child = World.CreateSystem<TestSystem>();
            // Updating the parent with the child added should log an exception (child doesn't implement OnUpdate).
            parent.AddSystemToUpdateList(child);
            parent.SortSystemUpdateList();
            parent.Update();
            LogAssert.Expect(LogType.Exception, new Regex("NotImplementedException"));

            // After removing the child system, updating the parent should not reference it in its update pass.
            Assert.DoesNotThrow(() => { parent.RemoveSystemFromUpdateList(child);});
            parent.SortSystemUpdateList();
            World.DestroySystem(child);
            Assert.DoesNotThrow(() => { parent.Update(); });
            LogAssert.NoUnexpectedReceived();
        }
#endif

#if !NET_DOTS // Tiny precompiles systems, and lacks a Regex overload for LogAssert.Expect()
        [UpdateAfter(typeof(NonSibling2System))]
        class NonSibling1System : TestSystemBase
        {
        }
        [UpdateBefore(typeof(NonSibling1System))]
        class NonSibling2System : TestSystemBase
        {
        }
        
        [Test]
        public void ComponentSystemGroup_UpdateAfterTargetIsNotSibling_LogsWarning()
        {
            var parent = World.CreateSystem<TestGroup>();
            var child = World.CreateSystem<NonSibling1System>();
            parent.AddSystemToUpdateList(child);
            parent.SortSystemUpdateList();
            LogAssert.Expect(LogType.Warning, new Regex(@"Ignoring invalid \[UpdateAfter\].+NonSibling1System.+belongs to a different ComponentSystemGroup"));
        }

        [Test]
        public void ComponentSystemGroup_UpdateBeforeTargetIsNotSibling_LogsWarning()
        {
            var parent = World.CreateSystem<TestGroup>();
            var child = World.CreateSystem<NonSibling2System>();
            parent.AddSystemToUpdateList(child);
            parent.SortSystemUpdateList();
            LogAssert.Expect(LogType.Warning, new Regex(@"Ignoring invalid \[UpdateBefore\].+NonSibling2System.+belongs to a different ComponentSystemGroup"));
        }
        
        [UpdateAfter(typeof(NotEvenASystem))]
        class InvalidUpdateAfterSystem : TestSystemBase
        {
        }
        [UpdateBefore(typeof(NotEvenASystem))]
        class InvalidUpdateBeforeSystem : TestSystemBase
        {
        }
        class NotEvenASystem
        {
        }

        [Test]
        public void ComponentSystemGroup_UpdateAfterTargetIsNotSystem_LogsWarning()
        {
            var parent = World.CreateSystem<TestGroup>();
            var child = World.CreateSystem<InvalidUpdateAfterSystem>();
            parent.AddSystemToUpdateList(child);
            parent.SortSystemUpdateList();
            LogAssert.Expect(LogType.Warning, new Regex(@"Ignoring invalid \[UpdateAfter\].+InvalidUpdateAfterSystem.+NotEvenASystem is not a subclass of ComponentSystemBase"));
        }
        [Test]
        public void ComponentSystemGroup_UpdateBeforeTargetIsNotSystem_LogsWarning()
        {
            var parent = World.CreateSystem<TestGroup>();
            var child = World.CreateSystem<InvalidUpdateBeforeSystem>();
            parent.AddSystemToUpdateList(child);
            parent.SortSystemUpdateList();
            LogAssert.Expect(LogType.Warning, new Regex(@"Ignoring invalid \[UpdateBefore\].+InvalidUpdateBeforeSystem.+NotEvenASystem is not a subclass of ComponentSystemBase"));
        }
        
        [UpdateAfter(typeof(UpdateAfterSelfSystem))]
        class UpdateAfterSelfSystem : TestSystemBase
        {
        }
        [UpdateBefore(typeof(UpdateBeforeSelfSystem))]
        class UpdateBeforeSelfSystem : TestSystemBase
        {
        }

        [Test]
        public void ComponentSystemGroup_UpdateAfterTargetIsSelf_LogsWarning()
        {
            var parent = World.CreateSystem<TestGroup>();
            var child = World.CreateSystem<UpdateAfterSelfSystem>();
            parent.AddSystemToUpdateList(child);
            parent.SortSystemUpdateList();
            LogAssert.Expect(LogType.Warning, new Regex(@"Ignoring invalid \[UpdateAfter\].+UpdateAfterSelfSystem.+cannot be updated after itself"));
        }
        [Test]
        public void ComponentSystemGroup_UpdateBeforeTargetIsSelf_LogsWarning()
        {
            var parent = World.CreateSystem<TestGroup>();
            var child = World.CreateSystem<UpdateBeforeSelfSystem>();
            parent.AddSystemToUpdateList(child);
            parent.SortSystemUpdateList();
            LogAssert.Expect(LogType.Warning, new Regex(@"Ignoring invalid \[UpdateBefore\].+UpdateBeforeSelfSystem.+cannot be updated before itself"));
        }

        [Test]
        public void ComponentSystemGroup_AddNullToUpdateList_QuietNoOp()
        {
            var parent = World.CreateSystem<TestGroup>();
            Assert.DoesNotThrow(() => { parent.AddSystemToUpdateList(null); });
            Assert.IsEmpty(parent.Systems);
        }

        [Test]
        public void ComponentSystemGroup_AddSelfToUpdateList_Throws()
        {
            var parent = World.CreateSystem<TestGroup>();
            Assert.That(() => { parent.AddSystemToUpdateList(parent); },
                Throws.ArgumentException.With.Message.Contains("to its own update list"));
        }
#endif
    }
}
