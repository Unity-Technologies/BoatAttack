using NUnit.Framework;
using Unity.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace Unity.Entities.Tests
{
    class ComponentSystemStartStopRunningTests : ECSTestsFixture
    {
        class TestSystem : ComponentSystem
        {
            public EntityQuery m_TestGroup;

            public const string OnStartRunningString =
                nameof(TestSystem) + ".OnStartRunning()";

            public const string OnStopRunningString =
                nameof(TestSystem) + ".OnStopRunning()";

            public NativeArray<int> StoredData;
            protected override void OnUpdate()
            {
                var componentData = m_TestGroup.ToComponentDataArray<EcsTestData>(Allocator.TempJob);
                var cd0 = componentData[0].value;
                var index = StoredData[0] + cd0 + 1;
                StoredData.Dispose();
                componentData.Dispose();

                StoredData = new NativeArray<int>(1, Allocator.Temp);
                StoredData[0] = index;
            }

            protected override void OnStartRunning()
            {
                UnityEngine.Debug.Log(OnStartRunningString);
                StoredData = new NativeArray<int>(1, Allocator.Temp);
                base.OnStartRunning();
            }

            protected override void OnStopRunning()
            {
                UnityEngine.Debug.Log(OnStopRunningString);
                StoredData.Dispose();
                base.OnStopRunning();
            }

            protected override void OnCreate()
            {
                m_TestGroup = GetEntityQuery(ComponentType.ReadWrite<EcsTestData>());
            }
        }

        TestSystem system;
        Entity runSystemEntity = Entity.Null;

        public void ShouldRunSystem(bool shouldRun)
        {
            if (runSystemEntity != Entity.Null)
            {
                m_Manager.DestroyEntity(runSystemEntity);
                runSystemEntity = Entity.Null;
            }

            if (shouldRun)
            {
                runSystemEntity = m_Manager.CreateEntity(typeof(EcsTestData));
            }
        }

        public override void Setup()
        {
            base.Setup();
            system = World.Active.GetOrCreateSystem<TestSystem>();
            ShouldRunSystem(true);
        }

        public override void TearDown()
        {
            if (runSystemEntity != Entity.Null)
            {
                m_Manager.DestroyEntity(runSystemEntity);
                runSystemEntity = Entity.Null;
            }
            if (system != null)
            {
                World.Active.DestroySystem(system);
                system = null;
            }

            base.TearDown();
        }

        [Test]
        public void TempAllocation_DisposedInOnStopRunning_IsDisposed()
        {
            system.Update();

            system.Enabled = false;

            system.Update();

            Assert.IsFalse(system.StoredData.IsCreated);
        }


        [Test]
        [StandaloneFixme] // UnityEngine.Debug.Log is at a very basic level in ZeroJobs
        public void OnStartRunning_FirstUpdate_CalledOnce()
        {
            LogAssert.Expect(LogType.Log, TestSystem.OnStartRunningString);
            system.Update();

            LogAssert.NoUnexpectedReceived();
        }

        [Test]
        [StandaloneFixme] // UnityEngine.Debug.Log is at a very basic level in ZeroJobs
        public void OnStartRunning_WhenReEnabled_CalledOnce()
        {
            system.Enabled = false;

            system.Update();

            LogAssert.Expect(LogType.Log, TestSystem.OnStartRunningString);
            system.Enabled = true;

            system.Update();

            LogAssert.NoUnexpectedReceived();
        }

        [Test]
        [StandaloneFixme] // UnityEngine.Debug.Log is at a very basic level in ZeroJobs
        public void OnStartRunning_WithEnabledAndShouldRun_CalledOnce()
        {
            LogAssert.Expect(LogType.Log, TestSystem.OnStartRunningString);
            system.Enabled = true;
            ShouldRunSystem(true);
            system.Update();

            LogAssert.NoUnexpectedReceived();
        }

        [Test]
        public void OnStartRunning_WithDisabledAndShouldRun_NotCalled()
        {
            system.Enabled = false;
            ShouldRunSystem(true);
            system.Update();

            LogAssert.NoUnexpectedReceived();
        }

        [Test]
        [StandaloneFixme] // Not obvious reasons
        public void OnStartRunning_WithEnabledAndShouldNotRun_NotCalled()
        {
            system.Enabled = true;
            ShouldRunSystem(false);
            system.Update();

            LogAssert.NoUnexpectedReceived();
        }

        [Test] // UnityEngine.Debug.Log is at a very basic level in ZeroJobs
        public void OnStartRunning_WithDisabledAndShouldNotRun_NotCalled()
        {
            system.Enabled = false;
            ShouldRunSystem(false);
            system.Update();

            LogAssert.NoUnexpectedReceived();
        }

        [Test]
        [StandaloneFixme] // UnityEngine.Debug.Log is at a very basic level in ZeroJobs
        public void OnStartRunning_EnablingWhenShouldRunSystemIsTrue_CalledOnce()
        {
            LogAssert.Expect(LogType.Log, TestSystem.OnStartRunningString);

            ShouldRunSystem(true);
            system.Enabled = false;
            system.Update();

            system.Enabled = true;
            system.Update();

            LogAssert.NoUnexpectedReceived();
        }

        [Test]
        [StandaloneFixme] // UnityEngine.Debug.Log is at a very basic level in ZeroJobs
        public void OnStartRunning_WhenShouldRunSystemBecomesTrue_CalledOnce()
        {
            LogAssert.Expect(LogType.Log, TestSystem.OnStartRunningString);
            ShouldRunSystem(true);
            system.Enabled = true;
            system.Update();

            LogAssert.Expect(LogType.Log, TestSystem.OnStopRunningString);
            ShouldRunSystem(false);
            system.Update();

            LogAssert.Expect(LogType.Log, TestSystem.OnStartRunningString);
            ShouldRunSystem(true);
            system.Update();

            LogAssert.NoUnexpectedReceived();
        }

        [Test]
        [StandaloneFixme] // UnityEngine.Debug.Log is at a very basic level in ZeroJobs
        public void OnStopRunning_WithEnabledAndShouldRun_NotCalled()
        {
            LogAssert.Expect(LogType.Log, TestSystem.OnStartRunningString);
            system.Update();

            system.Enabled = true;
            ShouldRunSystem(true);
            system.Update();

            LogAssert.NoUnexpectedReceived();
        }

        [Test]
        [StandaloneFixme] // UnityEngine.Debug.Log is at a very basic level in ZeroJobs
        public void OnStopRunning_WithDisabledAndShouldRun_CalledOnce()
        {
            LogAssert.Expect(LogType.Log, TestSystem.OnStartRunningString);
            system.Update();

            LogAssert.Expect(LogType.Log, TestSystem.OnStopRunningString);
            system.Enabled = false;
            ShouldRunSystem(true);
            system.Update();
            LogAssert.NoUnexpectedReceived();
        }

        [Test]
        [StandaloneFixme] // UnityEngine.Debug.Log is at a very basic level in ZeroJobs
        public void OnStopRunning_WithEnabledAndShouldNotRun_CalledOnce()
        {
            LogAssert.Expect(LogType.Log, TestSystem.OnStartRunningString);
            system.Update();

            LogAssert.Expect(LogType.Log, TestSystem.OnStopRunningString);
            system.Enabled = true;
            ShouldRunSystem(false);
            system.Update();
            LogAssert.NoUnexpectedReceived();
        }

        [Test]
        [StandaloneFixme] // UnityEngine.Debug.Log is at a very basic level in ZeroJobs
        public void OnStopRunning_WithDisabledAndShouldNotRun_CalledOnce()
        {
            LogAssert.Expect(LogType.Log, TestSystem.OnStartRunningString);
            system.Update();

            LogAssert.Expect(LogType.Log, TestSystem.OnStopRunningString);
            system.Enabled = false;
            ShouldRunSystem(false);
            system.Update();
            LogAssert.NoUnexpectedReceived();
        }

        [Test]
        public void OnStopRunning_WhenDisabledBeforeFirstUpdate_NotCalled()
        {
            system.Enabled = false;
            system.Update();

            LogAssert.NoUnexpectedReceived();
        }

        [Test]
        [StandaloneFixme] // UnityEngine.Debug.Log is at a very basic level in ZeroJobs
        public void OnStopRunning_WhenDestroyingActiveManager_CalledOnce()
        {
            LogAssert.Expect(LogType.Log, TestSystem.OnStartRunningString);
            system.Update();

            LogAssert.Expect(LogType.Log, TestSystem.OnStopRunningString);
            World.Active.DestroySystem(system);
            system = null;

            LogAssert.NoUnexpectedReceived();
        }

        [Test]
        public void OnStopRunning_WhenDestroyingInactiveManager_NotCalled()
        {
            system.Enabled = false;
            system.Update();

            World.Active.DestroySystem(system);
            system = null;

            LogAssert.NoUnexpectedReceived();
        }

        [Test]
        [StandaloneFixme] // UnityEngine.Debug.Log is at a very basic level in ZeroJobs
        public void OnStopRunning_WhenShouldRunSystemBecomesFalse_CalledOnce()
        {
            LogAssert.Expect(LogType.Log, TestSystem.OnStartRunningString);
            system.Update();

            LogAssert.Expect(LogType.Log, TestSystem.OnStopRunningString);
            system.Enabled = false;
            system.Update();

            LogAssert.NoUnexpectedReceived();
        }

        [Test]
        [StandaloneFixme] // UnityEngine.Debug.Log is at a very basic level in ZeroJobs
        public void OnStopRunning_DisablingWhenShouldRunSystemIsFalse_NotCalled()
        {
            LogAssert.Expect(LogType.Log, TestSystem.OnStartRunningString);
            system.Update();

            LogAssert.Expect(LogType.Log, TestSystem.OnStopRunningString);
            ShouldRunSystem(false);
            system.Update();

            system.Enabled = false;
            system.Update();

            LogAssert.NoUnexpectedReceived();
        }

    }
}
