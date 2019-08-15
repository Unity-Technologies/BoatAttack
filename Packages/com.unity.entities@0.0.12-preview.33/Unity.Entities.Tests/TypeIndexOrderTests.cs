using System;
using NUnit.Framework;
#pragma warning disable 649

namespace Unity.Entities.Tests
{
    class TypeIndexOrderTests : ECSTestsFixture
    {
        struct ComponentData1 : IComponentData
        {
            public int data;
        }

        struct SystemState1 : ISystemStateComponentData
        {
            public byte data;
        }

        struct Buffer1 : IBufferElementData
        {
            public short data;
        }

        struct SystemBuffer1 : ISystemStateBufferElementData
        {
            public float data;
        }

        struct Tag1 : IComponentData
        {}

        struct SystemTag1 : ISystemStateComponentData
        {}

        struct Shared1 : ISharedComponentData
        {
            public long data;
        }

        struct SystemShared1 : ISystemStateSharedComponentData
        {
            public int data;
        }

        struct ComponentData2 : IComponentData
        {
            public int data;
        }

        struct SystemState2 : ISystemStateComponentData
        {
            public byte data;
        }

        struct Buffer2 : IBufferElementData
        {
            public short data;
        }

        struct SystemBuffer2 : ISystemStateBufferElementData
        {
            public float data;
        }

        struct Tag2 : IComponentData
        {}

        struct SystemTag2 : ISystemStateComponentData
        {}

        struct Shared2 : ISharedComponentData
        {
            public long data;
        }

        struct SystemShared2 : ISystemStateSharedComponentData
        {
            public int data;
        }

        ComponentType chunk<T>() => ComponentType.ChunkComponent<T>();

        void MatchesTypes<A, B>(params ComponentTypeInArchetype[] types)
        {
            var expected = new ComponentTypeInArchetype[]
            {
                new ComponentTypeInArchetype(typeof(A)),
                new ComponentTypeInArchetype(typeof(B))
            };
            CollectionAssert.AreEquivalent(expected, types);
        }

        void MatchesChunkTypes<A, B>(params ComponentTypeInArchetype[] types)
        {
            var expected = new ComponentTypeInArchetype[]
            {
                new ComponentTypeInArchetype(ComponentType.ChunkComponent<A>()),
                new ComponentTypeInArchetype(ComponentType.ChunkComponent<B>())
            };
            CollectionAssert.AreEquivalent(expected, types);
        }

        void MatchesChunkTypes<A, B, C, D>(params ComponentTypeInArchetype[] types)
        {
            var expected = new ComponentTypeInArchetype[]
            {
                new ComponentTypeInArchetype(ComponentType.ChunkComponent<A>()),
                new ComponentTypeInArchetype(ComponentType.ChunkComponent<B>()),
                new ComponentTypeInArchetype(ComponentType.ChunkComponent<C>()),
                new ComponentTypeInArchetype(ComponentType.ChunkComponent<D>())
            };
            CollectionAssert.AreEquivalent(expected, types);
        }

        [Test]
        public unsafe void TypesInArchetypeAreOrderedAsExpected()
        {
            var archetype = m_Manager.CreateArchetype(
                typeof(ComponentData1), typeof(SystemState1), typeof(Buffer1), typeof(SystemBuffer1),
                typeof(Tag1), typeof(SystemTag1), typeof(Shared1), typeof(SystemShared1),
                chunk<ComponentData1>(), chunk<SystemState1>(), chunk<Buffer1>(), chunk<SystemBuffer1>(),
                chunk<Tag1>(), chunk<SystemTag1>(),

                typeof(ComponentData2), typeof(SystemState2), typeof(Buffer2), typeof(SystemBuffer2),
                typeof(Tag2), typeof(SystemTag2), typeof(Shared2), typeof(SystemShared2),
                chunk<ComponentData2>(), chunk<SystemState2>(), chunk<Buffer2>(), chunk<SystemBuffer2>(),
                chunk<Tag2>(), chunk<SystemTag2>());


            Assert.AreEqual(29, archetype.Archetype->TypesCount);

            var entityType = new ComponentTypeInArchetype(typeof(Entity));

            //Expected order: Entity, ComponentData*, SystemState*, Buffer*, SystemBuffer*, Tag*, SystemTag*,
            // Shared*, SystemShared*, ChunkComponentData* and ChunkTag*, ChunkSystemState* and ChunkSystemTag*,
            // ChunkBuffer*, ChunkSystemBuffer*

            var t = archetype.Archetype->Types;

            Assert.AreEqual(entityType, t[0]);

            MatchesTypes<ComponentData1, ComponentData2>(t[1], t[2]);
            MatchesTypes<SystemState1, SystemState2>(t[3], t[4]);
            MatchesTypes<Buffer1, Buffer2>(t[5], t[6]);
            MatchesTypes<SystemBuffer1, SystemBuffer2>(t[7], t[8]);
            MatchesTypes<Tag1, Tag2>(t[9], t[10]);
            MatchesTypes<SystemTag1, SystemTag2>(t[11], t[12]);
            MatchesTypes<Shared1, Shared2>(t[13], t[14]);
            MatchesTypes<SystemShared1, SystemShared2>(t[15], t[16]);

            MatchesChunkTypes<ComponentData1, ComponentData2, Tag1, Tag2>(t[17], t[18], t[19], t[20]);
            MatchesChunkTypes<SystemState1, SystemState2, SystemTag1, SystemTag2>(t[21], t[22], t[23], t[24]);

            MatchesChunkTypes<Buffer1, Buffer2>(t[25], t[26]);
            MatchesChunkTypes<SystemBuffer1, SystemBuffer2>(t[27], t[28]);
        }

    }
}
