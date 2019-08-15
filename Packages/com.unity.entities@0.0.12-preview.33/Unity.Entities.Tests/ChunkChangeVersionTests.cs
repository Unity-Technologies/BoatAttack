using System;
using NUnit.Framework;
using Unity.Collections;
using Unity.Jobs;

namespace Unity.Entities.Tests
{
    class ChunkChangeVersionTests : ECSTestsFixture
    {
        const uint OldVersion = 42;
        const uint NewVersion = 43;

        public override void Setup()
        {
            base.Setup();
            m_Manager.Debug.SetGlobalSystemVersion(OldVersion);
        }

        void BumpGlobalSystemVersion()
        {
            m_Manager.Debug.SetGlobalSystemVersion(NewVersion);
        }

        void AssertSameChunk(Entity e0, Entity e1)
        {
            Assert.AreEqual(m_Manager.GetChunk(e0), m_Manager.GetChunk(e1));
        }

        void AssertHasVersion<T>(Entity e, uint version) where T : struct, IComponentData
        {
            var type = m_Manager.GetArchetypeChunkComponentType<T>(true);
            var chunk = m_Manager.GetChunk(e);
            Assert.AreEqual(version, chunk.GetComponentVersion(type));
            Assert.IsFalse(chunk.DidChange(type, version));
            Assert.IsTrue(chunk.DidChange(type, version-1));
        }

        void AssertHasBufferVersion<T>(Entity e, uint version) where T : struct, IBufferElementData
        {
            var type = m_Manager.GetArchetypeChunkBufferType<T>(true);
            var chunk = m_Manager.GetChunk(e);
            Assert.AreEqual(version, chunk.GetComponentVersion(type));
            Assert.IsFalse(chunk.DidChange(type, version));
            Assert.IsTrue(chunk.DidChange(type, version-1));
        }

        void AssertHasSharedVersion<T>(Entity e, uint version) where T : struct, ISharedComponentData
        {
            var type = m_Manager.GetArchetypeChunkSharedComponentType<T>();
            var chunk = m_Manager.GetChunk(e);
            Assert.AreEqual(version, chunk.GetComponentVersion(type));
            Assert.IsFalse(chunk.DidChange(type, version));
            Assert.IsTrue(chunk.DidChange(type, version-1));
        }

        [Test]
        public void NewlyCreatedChunkGetsCurrentVersion()
        {
            var e0 = m_Manager.CreateEntity(typeof(EcsTestData), typeof(EcsTestData2));
            AssertHasVersion<EcsTestData>(e0, OldVersion);
            AssertHasVersion<EcsTestData2>(e0, OldVersion);
            BumpGlobalSystemVersion();
            var e1 = m_Manager.CreateEntity(typeof(EcsTestData3));
            AssertHasVersion<EcsTestData3>(e1, NewVersion);
        }

        [Test]
        public void CreateEntityMarksDestChunkAsChanged()
        {
            var e0 = m_Manager.CreateEntity(typeof(EcsTestData), typeof(EcsTestData2));
            BumpGlobalSystemVersion();
            var e1 = m_Manager.CreateEntity(typeof(EcsTestData), typeof(EcsTestData2));
            AssertSameChunk(e0, e1);
            AssertHasVersion<EcsTestData>(e0, NewVersion);
            AssertHasVersion<EcsTestData>(e1, NewVersion);
        }

        [Test]
        public void AddComponentMarksSrcAndDestChunkAsChanged()
        {
            var e0 = m_Manager.CreateEntity(typeof(EcsTestData), typeof(EcsTestData2));
            var e1 = m_Manager.CreateEntity(typeof(EcsTestData), typeof(EcsTestData2));
            BumpGlobalSystemVersion();
            m_Manager.AddComponentData(e1, new EcsTestData3(7));
            AssertHasVersion<EcsTestData>(e0, NewVersion);
            AssertHasVersion<EcsTestData2>(e0, NewVersion);
            AssertHasVersion<EcsTestData>(e1, NewVersion);
            AssertHasVersion<EcsTestData2>(e1, NewVersion);
            AssertHasVersion<EcsTestData3>(e1, NewVersion);
        }

        [Test]
        public void AddTagMarksSrcAndDestChunkAsChanged()
        {
            var e0 = m_Manager.CreateEntity(typeof(EcsTestData), typeof(EcsTestData2));
            var e1 = m_Manager.CreateEntity(typeof(EcsTestData), typeof(EcsTestData2));
            BumpGlobalSystemVersion();
            m_Manager.AddComponentData(e1, new EcsTestTag());
            AssertHasVersion<EcsTestData>(e0, NewVersion);
            AssertHasVersion<EcsTestData2>(e0, NewVersion);
            AssertHasVersion<EcsTestData>(e1, NewVersion);
            AssertHasVersion<EcsTestData2>(e1, NewVersion);
            AssertHasVersion<EcsTestTag>(e1, NewVersion);
        }

        [Test]
        public void AddComponentWithDefaultValueMarksSrcAndDestChunkAsChanged()
        {
            var e0 = m_Manager.CreateEntity(typeof(EcsTestData), typeof(EcsTestData2));
            var e1 = m_Manager.CreateEntity(typeof(EcsTestData), typeof(EcsTestData2));
            BumpGlobalSystemVersion();
            m_Manager.AddComponent(e1, typeof(EcsTestData3));
            AssertHasVersion<EcsTestData>(e0, NewVersion);
            AssertHasVersion<EcsTestData2>(e0, NewVersion);
            AssertHasVersion<EcsTestData>(e1, NewVersion);
            AssertHasVersion<EcsTestData2>(e1, NewVersion);
            AssertHasVersion<EcsTestData3>(e1, NewVersion);
        }
        
        [Test]
        public void AddComponentWithDefaultValueMarksSrcAndDestChunkAsChangedEntityArray()
        {
            var e0 = m_Manager.CreateEntity(typeof(EcsTestData), typeof(EcsTestData2));
            var e1 = m_Manager.CreateEntity(typeof(EcsTestData), typeof(EcsTestData2));
            BumpGlobalSystemVersion();
            var entities = new NativeArray<Entity>(1, Allocator.TempJob);
            entities[0] = e1;
            m_Manager.AddComponent(entities, typeof(EcsTestData3));
            AssertHasVersion<EcsTestData>(e0, NewVersion);
            AssertHasVersion<EcsTestData2>(e0, NewVersion);
            AssertHasVersion<EcsTestData>(e1, NewVersion);
            AssertHasVersion<EcsTestData2>(e1, NewVersion);
            AssertHasVersion<EcsTestData3>(e1, NewVersion);
            entities.Dispose();
        }

        [Test]
        public void SetComponentDataMarksOnlySetTypeAsChanged()
        {
            var e0 = m_Manager.CreateEntity(typeof(EcsTestData), typeof(EcsTestData2));
            var e1 = m_Manager.CreateEntity(typeof(EcsTestData), typeof(EcsTestData2));
            BumpGlobalSystemVersion();
            m_Manager.SetComponentData(e1, new EcsTestData(1));
            AssertSameChunk(e0, e1);
            AssertHasVersion<EcsTestData>(e0, NewVersion);
            AssertHasVersion<EcsTestData2>(e0, OldVersion);
        }

        [Test]
        public void ModifyingBufferComponentMarksOnlySetTypeAsChanged()
        {
            var e0 = m_Manager.CreateEntity(typeof(EcsTestData), typeof(EcsIntElement));
            var e1 = m_Manager.CreateEntity(typeof(EcsTestData), typeof(EcsIntElement));
            BumpGlobalSystemVersion();
            var buffer = m_Manager.GetBuffer<EcsIntElement>(e1);
            buffer.Add(7);
            AssertSameChunk(e0, e1);
            AssertHasVersion<EcsTestData>(e0, OldVersion);
            AssertHasBufferVersion<EcsIntElement>(e0, NewVersion);
        }

        [Test]
        public void AddSharedComponentMarksSrcAndDestChunkAsChanged()
        {
            var e0 = m_Manager.CreateEntity(typeof(EcsTestData), typeof(EcsTestData2));
            var e1 = m_Manager.CreateEntity(typeof(EcsTestData), typeof(EcsTestData2));
            BumpGlobalSystemVersion();
            m_Manager.AddSharedComponentData(e1, new EcsTestSharedComp(7));
            AssertHasVersion<EcsTestData>(e0, NewVersion);
            AssertHasVersion<EcsTestData2>(e0, NewVersion);
            AssertHasVersion<EcsTestData>(e1, NewVersion);
            AssertHasVersion<EcsTestData2>(e1, NewVersion);
            AssertHasSharedVersion<EcsTestSharedComp>(e1, NewVersion);
        }

        [Test]
        public void SetSharedComponentMarksSrcAndDestChunkAsChanged()
        {
            var e0 = m_Manager.CreateEntity(typeof(EcsTestData), typeof(EcsTestSharedComp));
            var e1 = m_Manager.CreateEntity(typeof(EcsTestData), typeof(EcsTestSharedComp));
            BumpGlobalSystemVersion();
            m_Manager.SetSharedComponentData(e1, new EcsTestSharedComp(7));
            AssertHasVersion<EcsTestData>(e0, NewVersion);
            AssertHasSharedVersion<EcsTestSharedComp>(e0, NewVersion);
            AssertHasVersion<EcsTestData>(e1, NewVersion);
            AssertHasSharedVersion<EcsTestSharedComp>(e1, NewVersion);
        }

        [Test]
        public void SwapComponentsMarksSrcAndDestChunkAsChanged()
        {
            var e0 = m_Manager.CreateEntity(typeof(EcsTestData), typeof(EcsTestSharedComp));
            var e1 = m_Manager.CreateEntity(typeof(EcsTestData), typeof(EcsTestSharedComp));

            m_Manager.SetSharedComponentData(e0, new EcsTestSharedComp(1));
            m_Manager.SetSharedComponentData(e1, new EcsTestSharedComp(2));

            var chunk0 = m_Manager.GetChunk(e0);
            var chunk1 = m_Manager.GetChunk(e1);

            Assert.AreNotEqual(chunk0, chunk1);
            BumpGlobalSystemVersion();

            m_Manager.SwapComponents(chunk0, 0, chunk1, 0);
            AssertHasVersion<EcsTestData>(e0, NewVersion);
            AssertHasSharedVersion<EcsTestSharedComp>(e0, NewVersion);
            AssertHasVersion<EcsTestData>(e1, NewVersion);
            AssertHasSharedVersion<EcsTestSharedComp>(e1, NewVersion);
        }

        [Test]
        public void AddChunkComponentMarksSrcAndDestChunkAsChanged()
        {
            var e0 = m_Manager.CreateEntity(typeof(EcsTestData), typeof(EcsTestData2));
            var e1 = m_Manager.CreateEntity(typeof(EcsTestData), typeof(EcsTestData2));
            BumpGlobalSystemVersion();
            m_Manager.AddChunkComponentData<EcsTestData3>(e1);
            AssertHasVersion<EcsTestData>(e0, NewVersion);
            AssertHasVersion<EcsTestData2>(e0, NewVersion);
            AssertHasVersion<EcsTestData>(e1, NewVersion);
            AssertHasVersion<EcsTestData2>(e1, NewVersion);
        }
    }
}
