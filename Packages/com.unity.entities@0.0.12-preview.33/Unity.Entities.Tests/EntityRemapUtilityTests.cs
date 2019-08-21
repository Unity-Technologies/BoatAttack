using NUnit.Framework;
using Unity.Collections;

namespace Unity.Entities.Tests
{
    public class EntityRemapUtilityTests
    {
        NativeArray<EntityRemapUtility.EntityRemapInfo> m_Remapping;

        [SetUp]
        public void Setup()
        {
            TypeManager.Initialize();
            m_Remapping = new NativeArray<EntityRemapUtility.EntityRemapInfo>(100, Allocator.Persistent);
        }

        [TearDown]
        public void TearDown()
        {
            m_Remapping.Dispose();
            TypeManager.Shutdown();
        }

        [Test]
        [Ignore("NOT IMPLEMENTED")]
        public void AddEntityRemappingThrowsForInvalidSource()
        {

        }

        [Test]
        [Ignore("NOT IMPLEMENTED")]
        public void RemapEntityThrowsForInvalidSource()
        {

        }

        [Test]
        public void RemapEntityMapsSourceToTarget()
        {
            var a = new Entity { Index = 1, Version = 2 };
            var b = new Entity { Index = 3, Version = 5 };
            EntityRemapUtility.AddEntityRemapping(ref m_Remapping, a, b);

            Assert.AreEqual(b, EntityRemapUtility.RemapEntity(ref m_Remapping, a));
        }

        [Test]
        public void RemapEntityMapsNonExistentSourceToNull()
        {
            var a = new Entity { Index = 1, Version = 2 };
            var b = new Entity { Index = 3, Version = 5 };
            var oldA = new Entity { Index = 1, Version = 1 };
            EntityRemapUtility.AddEntityRemapping(ref m_Remapping, a, b);

            Assert.AreEqual(Entity.Null, EntityRemapUtility.RemapEntity(ref m_Remapping, oldA));
        }

        [Test]
        public void RemapEntityMapsNullSourceToNull()
        {
            Assert.AreEqual(Entity.Null, EntityRemapUtility.RemapEntity(ref m_Remapping, Entity.Null));
        }

        struct EmptyStruct : IComponentData
        {
        }

        static TypeManager.EntityOffsetInfo[] GetEntityOffsets(System.Type type)
        {
#if !UNITY_DOTSPLAYER
            return EntityRemapUtility.CalculateEntityOffsets(type);
#else
            unsafe {
                var info = TypeManager.GetTypeInfo(TypeManager.GetTypeIndex(type));
                if (info.EntityOffsetCount > 0) {
                    TypeManager.EntityOffsetInfo[] ei = new TypeManager.EntityOffsetInfo[info.EntityOffsetCount];
                    for (var i = 0; i < info.EntityOffsetCount; ++i)
                        ei[i] = info.EntityOffsets[i];
                    return ei;
                }
                return null;
            }
#endif
        }

        [Test]
        public void CalculateEntityOffsetsReturnsNullIfNoEntities()
        {
            var offsets = GetEntityOffsets(typeof(EmptyStruct));
            Assert.AreEqual(null, offsets);
        }

        [Test]
        public void CalculateEntityOffsetsReturns0IfEntity()
        {
            var offsets = GetEntityOffsets(typeof(Entity));
            Assert.AreEqual(1, offsets.Length);
            Assert.AreEqual(0, offsets[0].Offset);
        }


        struct TwoEntityStruct : IComponentData
        {
            // The offsets of these fields are accessed through reflection
            #pragma warning disable CS0169  // field never used warning.
            Entity a;
            int b;
            Entity c;
            float d;
            #pragma warning restore CS0169
        }

        [Test]
        public void CalculateEntityOffsetsReturnsOffsetsOfEntities()
        {
            var offsets = GetEntityOffsets(typeof(TwoEntityStruct));
            Assert.AreEqual(2, offsets.Length);
            Assert.AreEqual(0, offsets[0].Offset);
            Assert.AreEqual(12, offsets[1].Offset);
        }

        struct EmbeddedEntityStruct
#if UNITY_DOTSPLAYER
            : IComponentData
#endif
        {
            // The offsets of these fields are accessed through reflection
            #pragma warning disable CS0169  // field never used warning.
            int a;
            TwoEntityStruct b;
            #pragma warning restore CS0169
        }

        [Test]
        public void CalculateEntityOffsetsReturnsOffsetsOfEmbeddedEntities()
        {
            var offsets = GetEntityOffsets(typeof(EmbeddedEntityStruct));
            Assert.AreEqual(2, offsets.Length);
            Assert.AreEqual(4, offsets[0].Offset);
            Assert.AreEqual(16, offsets[1].Offset);
        }
    }
}
