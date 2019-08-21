using System;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace Unity.Entities.Tests
{
    public class WorldTests
    {
        World m_PreviousWorld;

        [SetUp]
        public virtual void Setup()
        {
            m_PreviousWorld = World.Active;
        }

        [TearDown]
        public virtual void TearDown()
        {
            World.Active = m_PreviousWorld;
        }


        [Test]
        [StandaloneFixme]
        public void ActiveWorldResets()
        {
            int count = World.AllWorlds.Count();
            var worldA = new World("WorldA");
            var worldB = new World("WorldB");

            World.Active = worldB;

            Assert.AreEqual(worldB, World.Active);
            Assert.AreEqual(count + 2, World.AllWorlds.Count());
            Assert.AreEqual(worldA, World.AllWorlds[World.AllWorlds.Count()-2]);
            Assert.AreEqual(worldB, World.AllWorlds[World.AllWorlds.Count()-1]);

            worldB.Dispose();

            Assert.IsFalse(worldB.IsCreated);
            Assert.IsTrue(worldA.IsCreated);
            Assert.AreEqual(null, World.Active);

            worldA.Dispose();

            Assert.AreEqual(count, World.AllWorlds.Count());
        }

        class TestManager : ComponentSystem
        {
            protected override void OnUpdate() {}
        }

        [Test]
        [StandaloneFixme]
        public void WorldVersionIsConsistent()
        {
            var world = new World("WorldX");

            Assert.AreEqual(0, world.Version);

            var version = world.Version;
            world.GetOrCreateSystem<TestManager>();
            Assert.AreNotEqual(version, world.Version);

            version = world.Version;
            var manager = world.GetOrCreateSystem<TestManager>();
            Assert.AreEqual(version, world.Version);

            version = world.Version;
            world.DestroySystem(manager);
            Assert.AreNotEqual(version, world.Version);

            world.Dispose();
        }

        [Test]
        [StandaloneFixme]
        public void UsingDisposedWorldThrows()
        {
            var world = new World("WorldX");
            world.Dispose();

            Assert.Throws<ArgumentException>(() => world.GetExistingSystem<TestManager>());
        }

        class AddWorldDuringConstructorThrowsSystem : ComponentSystem
        {
            public AddWorldDuringConstructorThrowsSystem()
            {
                Assert.AreEqual(null, World);
                World.Active.AddSystem(this);
            }

            protected override void OnUpdate() { }
        }
        [Test]
        [StandaloneFixme]
        public void AddWorldDuringConstructorThrows ()
        {
            var world = new World("WorldX");
            World.Active = world;
            // Adding a manager during construction is not allowed
            Assert.Throws<TargetInvocationException>(() => world.CreateSystem<AddWorldDuringConstructorThrowsSystem>());
            // The manager will not be added to the list of managers if throws
            Assert.AreEqual(0, world.Systems.Count());

            world.Dispose();
        }

        class SystemThrowingInOnCreateIsRemovedSystem : ComponentSystem
        {
            protected override void OnCreate()
            {
                throw new AssertionException("");
            }

            protected override void OnUpdate() { }
        }
        [Test]
        [StandaloneFixme]
        public void SystemThrowingInOnCreateIsRemoved()
        {
            var world = new World("WorldX");
            Assert.AreEqual(0, world.Systems.Count());

            Assert.Throws<AssertionException>(() => world.GetOrCreateSystem<SystemThrowingInOnCreateIsRemovedSystem>());

            // throwing during OnCreateManager does not add the manager to the behaviour manager list
            Assert.AreEqual(0, world.Systems.Count());

            world.Dispose();
        }

        class SystemIsAccessibleDuringOnCreateManagerSystem : ComponentSystem
        {
            protected override void OnCreate()
            {
                Assert.AreEqual(this, World.GetOrCreateSystem<SystemIsAccessibleDuringOnCreateManagerSystem>());
            }

            protected override void OnUpdate() { }
        }
        [Test]
        [StandaloneFixme]
        public void SystemIsAccessibleDuringOnCreateManager ()
        {
            var world = new World("WorldX");
            Assert.AreEqual(0, world.Systems.Count());
            world.CreateSystem<SystemIsAccessibleDuringOnCreateManagerSystem>();
            Assert.AreEqual(1, world.Systems.Count());

            world.Dispose();
        }

        //@TODO: Test for adding a manager from one world to another.
        
        [Test]
        [StandaloneFixme]
        public unsafe void WorldNoOverlappingChunkSequenceNumbers()
        {
            var worldA = new World("WorldA");
            var worldB = new World("WorldB");

            World.Active = worldB;

            worldA.EntityManager.CreateEntity();
            worldB.EntityManager.CreateEntity();

            var worldAChunks = worldA.EntityManager.GetAllChunks();
            var worldBChunks = worldB.EntityManager.GetAllChunks();

            for (int i = 0; i < worldAChunks.Length; i++)
            {
                var chunkA = worldAChunks[i].m_Chunk;
                for (int j = 0; j < worldBChunks.Length; j++)
                {
                    var chunkB = worldBChunks[i].m_Chunk;
                    var sequenceNumberDiff = chunkA->SequenceNumber - chunkB->SequenceNumber;
                    
                    // Any chunk sequence numbers in different worlds should be separated by at least 32 bits
                    Assert.IsTrue(sequenceNumberDiff > 1<<32 );
                }
            }

            worldAChunks.Dispose();
            worldBChunks.Dispose();
        }
        
        [Test]
        [StandaloneFixme]
        public unsafe void WorldChunkSequenceNumbersNotReused()
        {
            var worldA = new World("WorldA");

            ulong lastChunkSequenceNumber = 0;
            {
                var entity = worldA.EntityManager.CreateEntity();
                var chunk = worldA.EntityManager.GetChunk(entity);
                lastChunkSequenceNumber = chunk.m_Chunk->SequenceNumber;
                                
                worldA.EntityManager.DestroyEntity(entity);
            }
            
            for (int i = 0; i < 1000; i++)
            {
                var entity = worldA.EntityManager.CreateEntity();
                var chunk = worldA.EntityManager.GetChunk(entity);
                var chunkSequenceNumber = chunk.m_Chunk->SequenceNumber;
                
                // Sequence numbers should be increasing and should not be reused when chunk is re-used (after zero count)
                Assert.IsTrue(chunkSequenceNumber > lastChunkSequenceNumber );
                lastChunkSequenceNumber = chunkSequenceNumber;
                
                worldA.EntityManager.DestroyEntity(entity);
            }

        }
    }
}
