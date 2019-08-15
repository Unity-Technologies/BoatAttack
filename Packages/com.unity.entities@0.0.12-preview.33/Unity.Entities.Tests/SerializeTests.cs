using NUnit.Framework;
using Unity.Collections;
using System;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities.Serialization;
using Unity.Jobs;

namespace Unity.Entities.Tests
{
    public unsafe struct TestBinaryReader : BinaryReader
    {
        NativeList<byte> content;
        int position;
        public TestBinaryReader(TestBinaryWriter writer)
        {
            position = 0;
            content = writer.content;
            writer.content = new NativeList<byte>();

        }

        public void Dispose()
        {
            content.Dispose();
        }

        public void ReadBytes(void* data, int bytes)
        {
            UnsafeUtility.MemCpy(data, (byte*)content.GetUnsafePtr() + position, bytes);
            position += bytes;
        }
    }

    public unsafe class TestBinaryWriter : BinaryWriter
    {
        internal NativeList<byte> content = new NativeList<byte>(Allocator.TempJob);

        public void Dispose()
        {
            content.Dispose();
        }

        public void WriteBytes(void* data, int bytes)
        {
            int length = content.Length;
            content.ResizeUninitialized(length + bytes);
            UnsafeUtility.MemCpy((byte*)content.GetUnsafePtr() + length, data, bytes);
        }

    }

    struct DeserializeJob : IJob
    {
        public ExclusiveEntityTransaction Transaction;
        public TestBinaryReader Reader { get; set; }
        public int SharedCount;

        public void Execute()
        {
            SerializeUtility.DeserializeWorld(Transaction, Reader, SharedCount);
            for (int i = 0; i < SharedCount; ++i)
                Transaction.ManagedComponentStore.RemoveReference(i+1);
        }
    }

    class SerializeTests : ECSTestsFixture
    {
        public struct TestComponentData1 : IComponentData
        {
            public int value;
            public Entity referencedEntity;
        }

        public struct TestComponentData2 : IComponentData
        {
            public int value;
            public Entity referencedEntity;
        }

        [InternalBufferCapacity(16)]
        public struct TestBufferElement : IBufferElementData
        {
            public Entity entity;
            public int value;
        }


        [Test]
        public void SerializeIntoExistingWorldThrows()
        {
            m_Manager.CreateEntity(typeof(EcsTestData));

            // disposed via reader
            var writer = new TestBinaryWriter();
            int[] sharedData;
            SerializeUtility.SerializeWorld(m_Manager, writer, out sharedData);

            var reader = new TestBinaryReader(writer);

            Assert.Throws<ArgumentException>(()=>
                SerializeUtility.DeserializeWorld(m_Manager.BeginExclusiveEntityTransaction(), reader, 0)
            );
            reader.Dispose();
        }

        [Test]
        public unsafe void SerializeEntities()
        {
            var dummyEntity = CreateEntityWithDefaultData(0); //To ensure entity indices are offset
            var e1 = CreateEntityWithDefaultData(1);
            var e2 = CreateEntityWithDefaultData(2);
            var e3 = CreateEntityWithDefaultData(3);
            m_Manager.AddComponentData(e1, new TestComponentData1{ value = 10, referencedEntity = e2 });
            m_Manager.AddComponentData(e2, new TestComponentData2{ value = 20, referencedEntity = e1 });
            m_Manager.AddComponentData(e3, new TestComponentData1{ value = 30, referencedEntity = Entity.Null });
            m_Manager.AddComponentData(e3, new TestComponentData2{ value = 40, referencedEntity = Entity.Null });
            m_Manager.AddBuffer<EcsIntElement>(e1);
            m_Manager.RemoveComponent<EcsTestData2>(e3);
            m_Manager.AddBuffer<EcsIntElement>(e3);

            m_Manager.GetBuffer<EcsIntElement>(e1).CopyFrom(new EcsIntElement[] { 1, 2, 3 }); // no overflow
            m_Manager.GetBuffer<EcsIntElement>(e3).CopyFrom(new EcsIntElement[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }); // overflow into heap

            var e4 = m_Manager.CreateEntity();
            m_Manager.AddBuffer<EcsComplexEntityRefElement>(e4);
            var ebuf = m_Manager.GetBuffer<EcsComplexEntityRefElement>(e4);
            ebuf.Add(new EcsComplexEntityRefElement { Entity = e1, Dummy = 1 });
            ebuf.Add(new EcsComplexEntityRefElement { Entity = e2, Dummy = 2 });
            ebuf.Add(new EcsComplexEntityRefElement { Entity = e3, Dummy = 3 });

            m_Manager.DestroyEntity(dummyEntity);
            // disposed via reader
            var writer = new TestBinaryWriter();

            int[] sharedData;
            SerializeUtility.SerializeWorld(m_Manager, writer, out sharedData);
            var reader = new TestBinaryReader(writer);

            var deserializedWorld = new World("SerializeEntities Test World 3");
            var entityManager = deserializedWorld.EntityManager;

            SerializeUtility.DeserializeWorld(entityManager.BeginExclusiveEntityTransaction(), reader, 0);
            entityManager.EndExclusiveEntityTransaction();

            try
            {
                var allEntities = entityManager.GetAllEntities(Allocator.Temp);
                var count = allEntities.Length;
                allEntities.Dispose();

                Assert.AreEqual(4, count);

                var group1 = entityManager.CreateEntityQuery(typeof(EcsTestData), typeof(EcsTestData2),
                    typeof(TestComponentData1));
                var group2 = entityManager.CreateEntityQuery(typeof(EcsTestData), typeof(EcsTestData2),
                    typeof(TestComponentData2));
                var group3 = entityManager.CreateEntityQuery(typeof(EcsTestData),
                    typeof(TestComponentData1), typeof(TestComponentData2));
                var group4 = entityManager.CreateEntityQuery(typeof(EcsComplexEntityRefElement));

                Assert.AreEqual(1, group1.CalculateLength());
                Assert.AreEqual(1, group2.CalculateLength());
                Assert.AreEqual(1, group3.CalculateLength());
                Assert.AreEqual(1, group4.CalculateLength());

                var everythingGroup = entityManager.CreateEntityQuery(Array.Empty<ComponentType>());
                var chunks = everythingGroup.CreateArchetypeChunkArray(Allocator.TempJob);
                Assert.AreEqual(4, chunks.Length);
                everythingGroup.Dispose();

                var entityType = entityManager.GetArchetypeChunkEntityType();
                Assert.AreEqual(1, chunks[0].GetNativeArray(entityType).Length);
                Assert.AreEqual(1, chunks[1].GetNativeArray(entityType).Length);
                Assert.AreEqual(1, chunks[2].GetNativeArray(entityType).Length);
                Assert.AreEqual(1, chunks[3].GetNativeArray(entityType).Length);
                chunks.Dispose();

                var entities1 = group1.ToEntityArray(Allocator.TempJob);
                var entities2 = group2.ToEntityArray(Allocator.TempJob);
                var entities3 = group3.ToEntityArray(Allocator.TempJob);
                var entities4 = group4.ToEntityArray(Allocator.TempJob);

                var new_e1 = entities1[0];
                var new_e2 = entities2[0];
                var new_e3 = entities3[0];
                var new_e4 = entities4[0];

                entities1.Dispose();
                entities2.Dispose();
                entities3.Dispose();
                entities4.Dispose();

                Assert.AreEqual(1, entityManager.GetComponentData<EcsTestData>(new_e1).value);
                Assert.AreEqual(-1, entityManager.GetComponentData<EcsTestData2>(new_e1).value0);
                Assert.AreEqual(-1, entityManager.GetComponentData<EcsTestData2>(new_e1).value1);
                Assert.AreEqual(10, entityManager.GetComponentData<TestComponentData1>(new_e1).value);

                Assert.AreEqual(2, entityManager.GetComponentData<EcsTestData>(new_e2).value);
                Assert.AreEqual(-2, entityManager.GetComponentData<EcsTestData2>(new_e2).value0);
                Assert.AreEqual(-2, entityManager.GetComponentData<EcsTestData2>(new_e2).value1);
                Assert.AreEqual(20, entityManager.GetComponentData<TestComponentData2>(new_e2).value);

                Assert.AreEqual(3, entityManager.GetComponentData<EcsTestData>(new_e3).value);
                Assert.AreEqual(30, entityManager.GetComponentData<TestComponentData1>(new_e3).value);
                Assert.AreEqual(40, entityManager.GetComponentData<TestComponentData2>(new_e3).value);

                Assert.IsTrue(entityManager.Exists(entityManager.GetComponentData<TestComponentData1>(new_e1).referencedEntity));
                Assert.IsTrue(entityManager.Exists(entityManager.GetComponentData<TestComponentData2>(new_e2).referencedEntity));
                Assert.AreEqual(new_e2 , entityManager.GetComponentData<TestComponentData1>(new_e1).referencedEntity);
                Assert.AreEqual(new_e1 , entityManager.GetComponentData<TestComponentData2>(new_e2).referencedEntity);

                var buf1 = entityManager.GetBuffer<EcsIntElement>(new_e1);
                Assert.AreEqual(3, buf1.Length);
                Assert.AreNotEqual((UIntPtr)m_Manager.GetBuffer<EcsIntElement>(e1).GetUnsafePtr(), (UIntPtr)buf1.GetUnsafePtr());

                for (int i = 0; i < 3; ++i)
                {
                    Assert.AreEqual(i + 1, buf1[i].Value);
                }

                var buf3 = entityManager.GetBuffer<EcsIntElement>(new_e3);
                Assert.AreEqual(10, buf3.Length);
                Assert.AreNotEqual((UIntPtr)m_Manager.GetBuffer<EcsIntElement>(e3).GetUnsafePtr(), (UIntPtr)buf3.GetUnsafePtr());

                for (int i = 0; i < 10; ++i)
                {
                    Assert.AreEqual(i + 1, buf3[i].Value);
                }

                var buf4 = entityManager.GetBuffer<EcsComplexEntityRefElement>(new_e4);
                Assert.AreEqual(3, buf4.Length);

                Assert.AreEqual(1, buf4[0].Dummy);
                Assert.AreEqual(new_e1, buf4[0].Entity);

                Assert.AreEqual(2, buf4[1].Dummy);
                Assert.AreEqual(new_e2, buf4[1].Entity);

                Assert.AreEqual(3, buf4[2].Dummy);
                Assert.AreEqual(new_e3, buf4[2].Entity);
            }
            finally
            {
                deserializedWorld.Dispose();
                reader.Dispose();
            }
        }

        //测试

        public struct 测试 : IComponentData
        {
            public int value;
        }

        [Test]
        public void SerializeEntitiesSupportsNonASCIIComponentTypeNames()
        {
            var e1 = m_Manager.CreateEntity();
            m_Manager.AddComponentData(e1, new 测试{ value = 7 });

            // disposed via reader
            var writer = new TestBinaryWriter();
            int[] sharedData;
            SerializeUtility.SerializeWorld(m_Manager, writer, out sharedData);
            var reader = new TestBinaryReader(writer);

            var deserializedWorld = new World("SerializeEntitiesSupportsNonASCIIComponentTypeNames Test World");
            var entityManager = deserializedWorld.EntityManager;

            SerializeUtility.DeserializeWorld(entityManager.BeginExclusiveEntityTransaction(), reader, 0);
            entityManager.EndExclusiveEntityTransaction();

            try
            {
                var allEntities = entityManager.GetAllEntities(Allocator.Temp);
                var count = allEntities.Length;
                allEntities.Dispose();

                Assert.AreEqual(1, count);

                var group1 = entityManager.CreateEntityQuery(typeof(测试));

                Assert.AreEqual(1, group1.CalculateLength());

                var entities = group1.ToEntityArray(Allocator.TempJob);
                var new_e1 = entities[0];
                entities.Dispose();

                Assert.AreEqual(7, entityManager.GetComponentData<测试>(new_e1).value);
            }
            finally
            {
                deserializedWorld.Dispose();
                reader.Dispose();
            }

        }

        [Test]
        public unsafe void SerializeEntitiesRemapsEntitiesInBuffers()
        {
            var dummyEntity = CreateEntityWithDefaultData(0); //To ensure entity indices are offset

            var e1 = m_Manager.CreateEntity();
            m_Manager.AddComponentData(e1, new EcsTestData(1));
            var e2 = m_Manager.CreateEntity();
            m_Manager.AddComponentData(e2, new EcsTestData2(2));

            m_Manager.AddBuffer<TestBufferElement>(e1);
            var buffer1 = m_Manager.GetBuffer<TestBufferElement>(e1);
            for(int i=0;i<1024;++i)
                buffer1.Add(new TestBufferElement {entity = e2, value = 2});

            m_Manager.AddBuffer<TestBufferElement>(e2);
            var buffer2 = m_Manager.GetBuffer<TestBufferElement>(e2);
            for(int i=0;i<8;++i)
                buffer2.Add(new TestBufferElement {entity = e1, value = 1});

            m_Manager.DestroyEntity(dummyEntity);
            // disposed via reader
            var writer = new TestBinaryWriter();

            int[] sharedData;
            SerializeUtility.SerializeWorld(m_Manager, writer, out sharedData);
            var reader = new TestBinaryReader(writer);

            var deserializedWorld = new World("SerializeEntities Test World 3");
            var entityManager = deserializedWorld.EntityManager;

            SerializeUtility.DeserializeWorld(entityManager.BeginExclusiveEntityTransaction(), reader, 0);
            entityManager.EndExclusiveEntityTransaction();

            try
            {

                var group1 = entityManager.CreateEntityQuery(typeof(EcsTestData), typeof(TestBufferElement));
                var group2 = entityManager.CreateEntityQuery(typeof(EcsTestData2), typeof(TestBufferElement));

                Assert.AreEqual(1, group1.CalculateLength());
                Assert.AreEqual(1, group2.CalculateLength());

                var entities1 = group1.ToEntityArray(Allocator.TempJob);
                var entities2 = group2.ToEntityArray(Allocator.TempJob);

                var new_e1 = entities1[0];
                var new_e2 = entities2[0];

                entities1.Dispose();
                entities2.Dispose();

                var newBuffer1 = entityManager.GetBuffer<TestBufferElement>(new_e1);
                Assert.AreEqual(1024, newBuffer1.Length);
                for (int i = 0; i < 1024; ++i)
                {
                    Assert.AreEqual(new_e2, newBuffer1[i].entity);
                    Assert.AreEqual(2, newBuffer1[i].value);
                }

                var newBuffer2 = entityManager.GetBuffer<TestBufferElement>(new_e2);
                Assert.AreEqual(8, newBuffer2.Length);
                for (int i = 0; i < 8; ++i)
                {
                    Assert.AreEqual(new_e1, newBuffer2[i].entity);
                    Assert.AreEqual(1, newBuffer2[i].value);
                }
            }
            finally
            {
                deserializedWorld.Dispose();
                reader.Dispose();
            }
        }

        [Test]
        public unsafe void SerializeEntitiesWorksWithChunkComponents()
        {
            var dummyEntity = CreateEntityWithDefaultData(0); //To ensure entity indices are offset

            var e1 = m_Manager.CreateEntity();
            m_Manager.AddComponentData(e1, new EcsTestData(1));
            m_Manager.AddChunkComponentData<EcsTestData3>(e1);
            m_Manager.SetChunkComponentData(m_Manager.GetChunk(e1), new EcsTestData3(42));
            var e2 = m_Manager.CreateEntity();
            m_Manager.AddComponentData(e2, new EcsTestData2(2));
            m_Manager.AddChunkComponentData<EcsTestData3>(e2);
            m_Manager.SetChunkComponentData(m_Manager.GetChunk(e2), new EcsTestData3(57));

            m_Manager.DestroyEntity(dummyEntity);
            // disposed via reader
            var writer = new TestBinaryWriter();

            int[] sharedData;
            SerializeUtility.SerializeWorld(m_Manager, writer, out sharedData);
            var reader = new TestBinaryReader(writer);

            var deserializedWorld = new World("SerializeEntities Test World 3");
            var entityManager = deserializedWorld.EntityManager;

            SerializeUtility.DeserializeWorld(entityManager.BeginExclusiveEntityTransaction(), reader, 0);
            entityManager.EndExclusiveEntityTransaction();

            try
            {
                var group1 = entityManager.CreateEntityQuery(typeof(EcsTestData));
                var group2 = entityManager.CreateEntityQuery(typeof(EcsTestData2));

                Assert.AreEqual(1, group1.CalculateLength());
                Assert.AreEqual(1, group2.CalculateLength());

                var entities1 = group1.ToEntityArray(Allocator.TempJob);
                var entities2 = group2.ToEntityArray(Allocator.TempJob);

                var new_e1 = entities1[0];
                var new_e2 = entities2[0];

                entities1.Dispose();
                entities2.Dispose();

                Assert.AreEqual(1, entityManager.GetComponentData<EcsTestData>(new_e1).value);
                Assert.AreEqual(42, entityManager.GetChunkComponentData<EcsTestData3>(new_e1).value0);

                Assert.AreEqual(2, entityManager.GetComponentData<EcsTestData2>(new_e2).value0);
                Assert.AreEqual(57, entityManager.GetChunkComponentData<EcsTestData3>(new_e2).value0);
            }
            finally
            {
                deserializedWorld.Dispose();
                reader.Dispose();
            }
        }

        [Test]
        public void SerializeDoesntRemapOriginalHeapBuffers()
        {
            var dummyEntity = CreateEntityWithDefaultData(0); //To ensure entity indices are offset

            var e1 = m_Manager.CreateEntity();
            m_Manager.AddComponentData(e1, new EcsTestData(1));
            var e2 = m_Manager.CreateEntity();
            m_Manager.AddComponentData(e2, new EcsTestData2(2));

            m_Manager.AddBuffer<TestBufferElement>(e1);
            var buffer1 = m_Manager.GetBuffer<TestBufferElement>(e1);
            for(int i=0;i<1024;++i)
                buffer1.Add(new TestBufferElement {entity = e2, value = 2});

            m_Manager.AddBuffer<TestBufferElement>(e2);
            var buffer2 = m_Manager.GetBuffer<TestBufferElement>(e2);
            for(int i=0;i<8;++i)
                buffer2.Add(new TestBufferElement {entity = e1, value = 1});

            m_Manager.DestroyEntity(dummyEntity);
            // disposed via reader
            var writer = new TestBinaryWriter();

            int[] sharedData;
            SerializeUtility.SerializeWorld(m_Manager, writer, out sharedData);

            buffer1 = m_Manager.GetBuffer<TestBufferElement>(e1);
            for (int i = 0; i < buffer1.Length; ++i)
            {
                Assert.AreEqual(e2, buffer1[i].entity);
                Assert.AreEqual(2, buffer1[i].value);
            }

            buffer2 = m_Manager.GetBuffer<TestBufferElement>(e2);
            for (int i = 0; i < buffer2.Length; ++i)
            {
                Assert.AreEqual(e1, buffer2[i].entity);
                Assert.AreEqual(1, buffer2[i].value);
            }

            writer.Dispose();
        }

        struct ExternalSharedComponentValue
        {
            public object obj;
            public int hashcode;
            public int typeIndex;
        }

        ExternalSharedComponentValue[] ExtractSharedComponentValues(int[] indices, EntityManager manager)
        {
            var values = new ExternalSharedComponentValue[indices.Length];
            for (int i = 0; i < indices.Length; ++i)
            {
                object value = manager.ManagedComponentStore.GetSharedComponentDataNonDefaultBoxed(indices[i]);
                int typeIndex = TypeManager.GetTypeIndex(value.GetType());
                int hash = TypeManager.GetHashCode(value, typeIndex);
                values[i] = new ExternalSharedComponentValue {obj = value, hashcode = hash, typeIndex = typeIndex};
            }
            return values;
        }

        void InsertSharedComponentValues(ExternalSharedComponentValue[] values, EntityManager manager)
        {
            for (int i = 0; i < values.Length; ++i)
            {
                ExternalSharedComponentValue value = values[i];
                int index = manager.ManagedComponentStore.InsertSharedComponentAssumeNonDefault(value.typeIndex,
                    value.hashcode, value.obj);
                Assert.AreEqual(i+1, index);
            }
        }

        [Test]
        public unsafe void SerializeEntitiesWorksWithBlobAssetReferences()
        {
            var archetype1 = m_Manager.CreateArchetype(typeof(EcsTestSharedComp), typeof(EcsTestData));
            var archetype2 = m_Manager.CreateArchetype(typeof(EcsTestSharedComp2), typeof(EcsTestData2));
            var dummyEntity = CreateEntityWithDefaultData(0); //To ensure entity indices are offset

            var builder = new BlobBuilder(Allocator.Temp);
            ref var blobArray = ref builder.ConstructRoot<BlobArray<float>>();
            var array = builder.Allocate(5, ref blobArray);
            array[0] = 1.7f;
            array[1] = 2.6f;
            array[2] = 3.5f;
            array[3] = 4.4f;
            array[4] = 5.3f;

            var arrayComponent = new EcsTestDataBlobAssetArray {array = builder.CreateBlobAssetReference<BlobArray<float>>(Allocator.Temp)};
            builder.Dispose();

            const int entityCount = 1000;
            var entities = new NativeArray<Entity>(entityCount, Allocator.Temp);

            m_Manager.CreateEntity(archetype1, entities);
            for (int i = 0; i < entityCount; ++i)
            {
                m_Manager.AddComponentData(entities[i], arrayComponent);
                m_Manager.SetSharedComponentData(entities[i], new EcsTestSharedComp(i%4));
            }

            var intComponents = new NativeArray<EcsTestDataBlobAssetRef>(entityCount/5, Allocator.Temp);
            for(int i=0; i<intComponents.Length; ++i)
                intComponents[i] = new EcsTestDataBlobAssetRef {value = BlobAssetReference<int>.Create(i)};


            m_Manager.CreateEntity(archetype2, entities);
            for (int i = 0; i < entityCount; ++i)
            {
                var intComponent = intComponents[i % intComponents.Length];
                m_Manager.AddComponentData(entities[i], intComponent);
                m_Manager.SetComponentData(entities[i], new EcsTestData2(intComponent.value.Value));
                m_Manager.SetSharedComponentData(entities[i], new EcsTestSharedComp2(i%3));
            }

            m_Manager.DestroyEntity(dummyEntity);
            // disposed via reader
            var writer = new TestBinaryWriter();

            int[] sharedData;
            SerializeUtility.SerializeWorld(m_Manager, writer, out sharedData);

            var sharedComponents = ExtractSharedComponentValues(sharedData, m_Manager);

            m_Manager.DestroyEntity(m_Manager.UniversalQuery);

            arrayComponent.array.Release();
            for(int i=0; i<intComponents.Length; ++i)
                intComponents[i].value.Release();

            var reader = new TestBinaryReader(writer);

            var deserializedWorld = new World("SerializeEntities Test World 3");
            var entityManager = deserializedWorld.EntityManager;

            InsertSharedComponentValues(sharedComponents, entityManager);

            var job = new DeserializeJob {Transaction = entityManager.BeginExclusiveEntityTransaction(), Reader = reader, SharedCount = sharedData.Length};
            job.Schedule().Complete();
            entityManager.EndExclusiveEntityTransaction();

            entityManager.Debug.CheckInternalConsistency();
            Assert.IsTrue(entityManager.ManagedComponentStore.AllSharedComponentReferencesAreFromChunks(entityManager.EntityComponentStore));

            try
            {
                var group1 = entityManager.CreateEntityQuery(typeof(EcsTestDataBlobAssetArray));
                var group2 = entityManager.CreateEntityQuery(typeof(EcsTestDataBlobAssetRef));

                var entities1 = group1.ToEntityArray(Allocator.TempJob);
                Assert.AreEqual(entityCount, entities1.Length);
                var new_e1 = entities1[0];
                arrayComponent = entityManager.GetComponentData<EcsTestDataBlobAssetArray>(new_e1);
                var a = arrayComponent.array;
                Assert.AreEqual(1.7f, a.Value[0]);
                Assert.AreEqual(2.6f, a.Value[1]);
                Assert.AreEqual(3.5f, a.Value[2]);
                Assert.AreEqual(4.4f, a.Value[3]);
                Assert.AreEqual(5.3f, a.Value[4]);
                entities1.Dispose();

                var entities2 = group2.ToEntityArray(Allocator.TempJob);
                Assert.AreEqual(entityCount, entities2.Length);
                for (int i = 0; i < entityCount; ++i)
                {
                    var val = entityManager.GetComponentData<EcsTestData2>(entities2[i]).value0;
                    Assert.AreEqual(val, entityManager.GetComponentData<EcsTestDataBlobAssetRef>(entities2[i]).value.Value);
                }
                entities2.Dispose();
            }
            finally
            {
                deserializedWorld.Dispose();
                reader.Dispose();
            }

            float f = 1.0f;
            Assert.Throws<InvalidOperationException>(() => f = arrayComponent.array.Value[0]);
        }

        public unsafe struct ComponentWithPointer : IComponentData
        {
            int m_Pad;
            byte* m_Data;
        }

        [Test]
        public void SerializeComponentWithPointerField()
        {
            var e1 = m_Manager.CreateEntity();
            m_Manager.AddComponentData(e1, new ComponentWithPointer());

            using (var writer = new TestBinaryWriter())
            {
                int[] sharedData;
                Assert.Throws<ArgumentException>(() =>
                    SerializeUtility.SerializeWorld(m_Manager, writer, out sharedData)
                );
            }
        }

        public struct ComponentWithIntPtr : IComponentData
        {
            int m_Pad;
            IntPtr m_Data;
        }

        [Test]
        public void SerializeComponentWithIntPtrField()
        {
            var e1 = m_Manager.CreateEntity();
            m_Manager.AddComponentData(e1, new ComponentWithIntPtr());

            using (var writer = new TestBinaryWriter())
            {
                int[] sharedData;
                Assert.Throws<ArgumentException>(() =>
                    SerializeUtility.SerializeWorld(m_Manager, writer, out sharedData)
                );
            }
        }

        public unsafe struct TypeWithPointer
        {
            int m_Pad;
            byte* m_Data;
        }

        public struct TypeWithNestedPointer
        {
            int m_Pad;
            TypeWithPointer m_Data;
            int m_Pad1;
        }

        public struct ComponentWithNestedPointer : IComponentData
        {
            int m_Pad;
            TypeWithNestedPointer m_PointerField;
            int m_Pad1;
        }

        [Test]
        public void SerializeComponentWithNestedPointerField()
        {
            var e1 = m_Manager.CreateEntity();
            m_Manager.AddComponentData(e1, new ComponentWithNestedPointer());

            using (var writer = new TestBinaryWriter())
            {
                int[] sharedData;
                Assert.Throws<ArgumentException>(() =>
                    SerializeUtility.SerializeWorld(m_Manager, writer, out sharedData)
                );
            }
        }

        public struct TypeWithNestedWhiteListType
        {
            int m_Pad;
            ChunkHeader m_Header; // whitelisted pointer type
            int m_Pad1;
        }

        public struct ComponentWithNestedPointerAndNestedWhiteListType : IComponentData
        {
            TypeWithNestedPointer m_PointerField;
            TypeWithNestedWhiteListType m_NestedWhitelistField;
        }

        [Test]
        public void EnsureSerializationWhitelistingDoesNotTrumpValidation()
        {
            var e1 = m_Manager.CreateEntity();
            m_Manager.AddComponentData(e1, new ComponentWithNestedPointerAndNestedWhiteListType());

            using (var writer = new TestBinaryWriter())
            {
                int[] sharedData;
                Assert.Throws<ArgumentException>(() =>
                    SerializeUtility.SerializeWorld(m_Manager, writer, out sharedData)
                );
            }
        }

        [Test]
        public void DeserializedChunksAreConsideredChangedOnlyOnce()
        {
            TestBinaryReader CreateSerializedData()
            {
                var world = new World("DeserializedChunksAreConsideredChangedOnlyOnce World");
                var manager = world.EntityManager;
                var entity = manager.CreateEntity();
                manager.AddComponentData(entity, new EcsTestData(42));

                // owned by caller via reader
                var writer = new TestBinaryWriter();
                SerializeUtility.SerializeWorld(manager, writer, out var sharedData);
                world.Dispose();
                return new TestBinaryReader(writer);
            }

            var reader = CreateSerializedData();

            var deserializedWorld = new World("DeserializedChunksAreConsideredChangedOnlyOnce World 2");
            var deserializedManager = deserializedWorld.EntityManager;
            var system = deserializedWorld.GetOrCreateSystem<TestEcsChangeSystem>();

            Assert.AreEqual(0, system.NumChanged);

            SerializeUtility.DeserializeWorld(deserializedManager.BeginExclusiveEntityTransaction(), reader, 0);
            deserializedManager.EndExclusiveEntityTransaction();
            reader.Dispose();

            system.Update();
            Assert.AreEqual(1, system.NumChanged);

            system.Update();
            Assert.AreEqual(0, system.NumChanged);

            deserializedWorld.Dispose();
        }
    }
}
