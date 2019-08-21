using System;
using Unity.Collections;
using NUnit.Framework;
using UnityEngine;

namespace Unity.Entities.Tests
{
    interface IEcsFooInterface
    {
        int value { get; set; }

    }
    public struct EcsFooTest : IComponentData, IEcsFooInterface
    {
        public int value { get; set; }

        public EcsFooTest(int inValue) { value = inValue; }
    }

    interface IEcsNotUsedInterface
    {
        int value { get; set; }

    }
    class EntityManagerTests : ECSTestsFixture
    {
#if UNITY_EDITOR
        [Test]
        public void NameEntities()
        {
            WordStorage.Setup();
            var archetype = m_Manager.CreateArchetype(typeof(EcsTestData));
            var count = 1024;
            var array = new NativeArray<Entity>(count, Allocator.Temp);
            m_Manager.CreateEntity (archetype, array);
            for (int i = 0; i < count; i++)
            {
                m_Manager.SetName(array[i], "Name" + i);
            }
            for (int i = 0; i < count; ++i)
            {
                Assert.AreEqual(m_Manager.GetName(array[i]), "Name" + i);
            }
            // even though we've made 1024 entities, the string table should contain only two entries:
            // "", and "Name"
            Assert.IsTrue(WordStorage.Instance.Entries == 2);
            array.Dispose();
        }

        [Test]
        public void InstantiateKeepsName()
        {
            WordStorage.Setup();
            var entity = m_Manager.CreateEntity ();
            m_Manager.SetName(entity, "Blah");

            var instance = m_Manager.Instantiate(entity);
            Assert.AreEqual("Blah", m_Manager.GetName(instance));
        }
#endif

        [Test]
        public void IncreaseEntityCapacity()
        {
            var archetype = m_Manager.CreateArchetype(typeof(EcsTestData));
            var count = 1024;
            var array = new NativeArray<Entity>(count, Allocator.Temp);
            m_Manager.CreateEntity (archetype, array);
            for (int i = 0; i < count; i++)
            {
                Assert.AreEqual(i, array[i].Index);
            }
            array.Dispose();
        }
        
        [Test]
        public void AddComponentEmptyNativeArray()
        {
            var array = new NativeArray<Entity>(0, Allocator.Temp);
            m_Manager.AddComponent(array, typeof(EcsTestData));
            array.Dispose();
        }

        [Test]
        public void FoundComponentInterface()
        {
            var fooTypes = m_Manager.GetAssignableComponentTypes(typeof(IEcsFooInterface));
            Assert.AreEqual(1,fooTypes.Count);
            Assert.AreEqual(typeof(EcsFooTest),fooTypes[0]);

            var barTypes = m_Manager.GetAssignableComponentTypes(typeof(IEcsNotUsedInterface));
            Assert.AreEqual(0,barTypes.Count);
        }

        [Test]
        public void VersionIsConsistent()
        {
            Assert.AreEqual(0, m_Manager.Version);

            var entity = m_Manager.CreateEntity(typeof(EcsTestData));
            Assert.AreEqual(1, m_Manager.Version);

            m_Manager.AddComponentData(entity, new EcsTestData2(0));
            Assert.AreEqual(3, m_Manager.Version);

            m_Manager.SetComponentData(entity, new EcsTestData2(5));
            Assert.AreEqual(3, m_Manager.Version); // Shouldn't change when just setting data

            m_Manager.RemoveComponent<EcsTestData2>(entity);
            Assert.AreEqual(5, m_Manager.Version);

            m_Manager.DestroyEntity(entity);
            Assert.AreEqual(6, m_Manager.Version);
        }

        [Test]
        public void GetChunkVersions_ReflectsChange()
        {
            m_Manager.Debug.SetGlobalSystemVersion(1);

            var entity = m_Manager.CreateEntity(typeof(EcsTestData));

            m_Manager.Debug.SetGlobalSystemVersion(2);

            var version = m_Manager.GetChunkVersionHash(entity);

            m_Manager.SetComponentData(entity, new EcsTestData());

            var version2 = m_Manager.GetChunkVersionHash(entity);

            Assert.AreNotEqual(version, version2);
        }


        interface TestInterface
        {
        }

        struct TestInterfaceComponent : TestInterface, IComponentData
        {
            public int Value;
        }
        
        [Test]
        [StandaloneFixme]
        public void GetComponentBoxedSupportsInterface()
        {
            var entity = m_Manager.CreateEntity();
            
            m_Manager.AddComponentData(entity, new TestInterfaceComponent {Value = 5});
            var obj = m_Manager.Debug.GetComponentBoxed(entity, typeof(TestInterface));

            Assert.AreEqual(typeof(TestInterfaceComponent), obj.GetType());
            Assert.AreEqual(5, ((TestInterfaceComponent)obj).Value);
        }

        [Test]
        [StandaloneFixme]
        public void GetComponentBoxedThrowsWhenInterfaceNotFound()
        {
            var entity = m_Manager.CreateEntity();
            Assert.Throws<ArgumentException>(() => m_Manager.Debug.GetComponentBoxed(entity, typeof(TestInterface)));
        }
        
        [Test]
        [Ignore("NOT IMPLEMENTED")]
        public void UsingComponentGroupOrArchetypeorEntityFromDifferentEntityManagerGivesExceptions()
        {
        }

        [Test]
        public unsafe void ComponentsWithBool()
        {
            var archetype = m_Manager.CreateArchetype(typeof(EcsTestComponentWithBool));
            var count = 128;
            var array = new NativeArray<Entity>(count, Allocator.Temp);
            m_Manager.CreateEntity(archetype, array);

            var hash = new NativeHashMap<Entity, bool>(count, Allocator.Temp);

            var cg = m_Manager.CreateEntityQuery(ComponentType.ReadWrite<EcsTestComponentWithBool>());
            using (var chunks = cg.CreateArchetypeChunkArray(Allocator.TempJob))
            {
                var boolsType = m_Manager.GetArchetypeChunkComponentType<EcsTestComponentWithBool>(false);
                var entsType = m_Manager.GetArchetypeChunkEntityType();

                foreach (var chunk in chunks)
                {
                    var bools = chunk.GetNativeArray(boolsType);
                    var entities = chunk.GetNativeArray(entsType);

                    for (var i = 0; i < chunk.Count; ++i)
                    {
                        bools[i] = new EcsTestComponentWithBool {value = (entities[i].Index & 1) == 1};
                        Assert.IsTrue(hash.TryAdd(entities[i], bools[i].value));
                    }
                }
            }

            for (int i = 0; i < count; i++)
            {
                var data = m_Manager.GetComponentData<EcsTestComponentWithBool>(array[i]);
                Assert.AreEqual((array[i].Index & 1) == 1, data.value);
            }

            array.Dispose();
            hash.Dispose();
        }


        struct BigComponentWithAlign1A : IComponentData
        {
            NativeString4096 bs;
            unsafe fixed byte val[3];
        }

        struct ComponentWithAlign8 : IComponentData {
            double val;
        }

        struct BigComponentWithAlign1B : IComponentData {
            NativeString4096 bs;
            unsafe fixed byte val[3];
        }

        [Test]
        public unsafe void ChunkComponentRunIsAligned()
        {
            // We need to make sure that the stricter-alignment component (WithAlign8) comes after the simpler one
            Type oneByteAlignmentType = typeof(BigComponentWithAlign1A);
            int bigTypeIndex = TypeManager.GetTypeIndex<ComponentWithAlign8>();
            if ((TypeManager.GetTypeIndex<BigComponentWithAlign1A>() & TypeManager.ClearFlagsMask) >
                (bigTypeIndex & TypeManager.ClearFlagsMask))
            {
                // must be the other one
                oneByteAlignmentType = typeof(BigComponentWithAlign1B);
            }

            var oneByteInfo = TypeManager.GetTypeInfo(TypeManager.GetTypeIndex(oneByteAlignmentType));
            int bigAlignment = TypeManager.GetTypeInfo<ComponentWithAlign8>().AlignmentInBytes;

            //Assert.AreEqual(4, TypeManager.GetTypeInfo(TypeManager.GetTypeIndex(oneByteAlignmentType)).AlignmentInBytes);
            Assert.AreEqual(8, bigAlignment);

            // Create an entity
            var archetype = m_Manager.CreateArchetype(oneByteAlignmentType, typeof(ComponentWithAlign8));
            var entity = m_Manager.CreateEntity(archetype);
            // Get a pointer to the first bigger-aligned component
            var p2 = m_Manager.GetComponentDataRawRW(entity, bigTypeIndex);

            // p2 needs to be aligned properly
            Assert.AreEqual(0, (long)p2 & (bigAlignment - 1));

            // But let's verify that we didn't get lucky.  If you see this assertion fire due to a change,
            // it's because chunk layout chanked such that the 8-byte-aligned chunk would naturally fall
            // on its proper alignment.  Play with the BigComponent sizes (by adding/removing members) above
            // until you get this to pass.
            Assert.AreNotEqual(0, (archetype.Archetype->ChunkCapacity * oneByteInfo.SizeInChunk) % 8);
        }
    }
}
