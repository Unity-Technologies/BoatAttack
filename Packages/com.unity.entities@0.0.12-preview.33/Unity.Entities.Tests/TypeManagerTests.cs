using System;
using NUnit.Framework;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.Tests;
#pragma warning disable 649

[assembly: RegisterGenericComponentType(typeof(TypeManagerTests.GenericComponent<int>))]
[assembly: RegisterGenericComponentType(typeof(TypeManagerTests.GenericComponent<short>))]

namespace Unity.Entities
{
    // mock type
    class GameObjectEntity
    {
    }
}

namespace Unity.Entities.Tests
{
    class TypeManagerTests : ECSTestsFixture
    {
        struct TestType1 : IComponentData
        {
            int empty;
        }
        struct TestType2 : IComponentData
        {
            int empty;
        }
        struct TestTypeWithBool : IComponentData, IEquatable<TestTypeWithBool>
        {
            bool empty;

            public bool Equals(TestTypeWithBool other)
            {
                return other.empty == empty;
            }

            public override int GetHashCode()
            {
                return empty.GetHashCode();
            }
        }
        struct TestTypeWithChar : IComponentData, IEquatable<TestTypeWithChar>
        {
            char empty;

            public bool Equals(TestTypeWithChar other)
            {
                return empty == other.empty;
            }

            public override int GetHashCode()
            {
                return empty.GetHashCode();
            }
        }

        public struct GenericComponent<T> : IComponentData
        {
            T value;
        }

        [Test]
        public void CreateArchetypes()
        {
            var archetype1 = m_Manager.CreateArchetype(ComponentType.ReadWrite<TestType1>(), ComponentType.ReadWrite<TestType2>());
            var archetype1Same = m_Manager.CreateArchetype(ComponentType.ReadWrite<TestType1>(), ComponentType.ReadWrite<TestType2>());
            Assert.AreEqual(archetype1, archetype1Same);

            var archetype2 = m_Manager.CreateArchetype(ComponentType.ReadWrite<TestType1>());
            var archetype2Same = m_Manager.CreateArchetype(ComponentType.ReadWrite<TestType1>());
            Assert.AreEqual(archetype2Same, archetype2Same);

            Assert.AreNotEqual(archetype1, archetype2);
        }

        [Test]
        public void TestPrimitiveButNotBlittableTypesAllowed()
        {
            Assert.AreEqual(1, TypeManager.GetTypeInfo<TestTypeWithBool>().SizeInChunk);
            Assert.AreEqual(2, TypeManager.GetTypeInfo<TestTypeWithChar>().SizeInChunk);
        }

        // We need to decide whether this should actually be allowed; for now, add a test to make sure
        // we don't break things more than they already are.
        

        [Test]
        [StandaloneFixme] // dots runtime doesn't support generic components
        public void TestGenericComponents()
        {
            var index1 = TypeManager.GetTypeIndex<GenericComponent<int>>();
            var index2 = TypeManager.GetTypeIndex<GenericComponent<short>>();

            Assert.AreNotEqual(index1, index2);
        }
        
        [Test]
        [StandaloneFixme] // dots runtime doesn't support generic components
        public void TestGenericComponentsThrowsOnUnregisteredGeneric()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                TypeManager.GetTypeIndex<GenericComponent<long>>();
            });
        }

        [InternalBufferCapacity(99)]
        public struct IntElement : IBufferElementData
        {
            public int Value;
        }

        [Test]
        public void BufferTypeClassificationWorks()
        {
            var t  = TypeManager.GetTypeInfo<IntElement>();
            Assert.AreEqual(TypeManager.TypeCategory.BufferData, t.Category);
            Assert.AreEqual(99, t.BufferCapacity);
            Assert.AreEqual(UnsafeUtility.SizeOf<BufferHeader>() + 99 * sizeof(int), t.SizeInChunk);
        }

        [Test]
        public void TestTypeManager()
        {
            var entityType = ComponentType.ReadWrite<Entity>();
            var testDataType = ComponentType.ReadWrite<EcsTestData>();

            Assert.AreEqual(entityType, ComponentType.ReadWrite<Entity>());
            Assert.AreEqual(entityType, new ComponentType(typeof(Entity)));
            Assert.AreEqual(testDataType, ComponentType.ReadWrite<EcsTestData>());
            Assert.AreEqual(testDataType, new ComponentType(typeof(EcsTestData)));
            Assert.AreNotEqual(ComponentType.ReadWrite<Entity>(), ComponentType.ReadWrite<EcsTestData>());

            Assert.AreEqual(ComponentType.AccessMode.ReadOnly, ComponentType.ReadOnly<EcsTestData>().AccessModeType);
            Assert.AreEqual(ComponentType.AccessMode.ReadOnly, ComponentType.ReadOnly(typeof(EcsTestData)).AccessModeType);

            Assert.AreEqual(typeof(Entity), entityType.GetManagedType());
        }

        [Test]
        public void TestAlignUp_Align0ToPow2()
        {
            Assert.AreEqual(0, TypeManager.AlignUp(0, 1));
            Assert.AreEqual(0, TypeManager.AlignUp(0, 2));
            Assert.AreEqual(0, TypeManager.AlignUp(0, 4));
            Assert.AreEqual(0, TypeManager.AlignUp(0, 8));
            Assert.AreEqual(0, TypeManager.AlignUp(0, 16));
            Assert.AreEqual(0, TypeManager.AlignUp(0, 32));
            Assert.AreEqual(0, TypeManager.AlignUp(0, 64));
            Assert.AreEqual(0, TypeManager.AlignUp(0, 128));
        }
        
        [Test]
        public void TestAlignUp_AlignMultipleOfAlignment()
        {
            Assert.AreEqual(2, TypeManager.AlignUp(2, 1));
            Assert.AreEqual(4, TypeManager.AlignUp(4, 2));
            Assert.AreEqual(8, TypeManager.AlignUp(8, 4));
            Assert.AreEqual(16, TypeManager.AlignUp(16, 8));
            Assert.AreEqual(32, TypeManager.AlignUp(32, 16));
            Assert.AreEqual(64, TypeManager.AlignUp(64, 32));
            Assert.AreEqual(128, TypeManager.AlignUp(128, 64));
            Assert.AreEqual(256, TypeManager.AlignUp(256, 128));
        }
        
        [Test]
        public void TestAlignUp_Align1ToPow2()
        {
            Assert.AreEqual(1, TypeManager.AlignUp(1, 1));
            Assert.AreEqual(2, TypeManager.AlignUp(1, 2));
            Assert.AreEqual(4, TypeManager.AlignUp(1, 4));
            Assert.AreEqual(8, TypeManager.AlignUp(1, 8));
            Assert.AreEqual(16, TypeManager.AlignUp(1, 16));
            Assert.AreEqual(32, TypeManager.AlignUp(1, 32));
            Assert.AreEqual(64, TypeManager.AlignUp(1, 64));
            Assert.AreEqual(128, TypeManager.AlignUp(1, 128));
        }
        
        [Test]
        public void TestAlignUp_Align3ToPow2()
        {
            Assert.AreEqual(3, TypeManager.AlignUp(3, 1));
            Assert.AreEqual(4, TypeManager.AlignUp(3, 2));
            Assert.AreEqual(4, TypeManager.AlignUp(3, 4));
            Assert.AreEqual(8, TypeManager.AlignUp(3, 8));
            Assert.AreEqual(16, TypeManager.AlignUp(3, 16));
            Assert.AreEqual(32, TypeManager.AlignUp(3, 32));
            Assert.AreEqual(64, TypeManager.AlignUp(3, 64));
            Assert.AreEqual(128, TypeManager.AlignUp(3, 128));
        }
        
        [Test]
        public void TestAlignUp_Align15ToPow2()
        {
            Assert.AreEqual(15, TypeManager.AlignUp(15, 1));
            Assert.AreEqual(16, TypeManager.AlignUp(15, 2));
            Assert.AreEqual(16, TypeManager.AlignUp(15, 4));
            Assert.AreEqual(16, TypeManager.AlignUp(15, 8));
            Assert.AreEqual(16, TypeManager.AlignUp(15, 16));
            Assert.AreEqual(32, TypeManager.AlignUp(15, 32));
            Assert.AreEqual(64, TypeManager.AlignUp(15, 64));
            Assert.AreEqual(128, TypeManager.AlignUp(15, 128));
        }
        
        [Test]
        public void TestAlignUp_Align63ToPow2()
        {
            Assert.AreEqual(63, TypeManager.AlignUp(63, 1));
            Assert.AreEqual(64, TypeManager.AlignUp(63, 2));
            Assert.AreEqual(64, TypeManager.AlignUp(63, 4));
            Assert.AreEqual(64, TypeManager.AlignUp(63, 8));
            Assert.AreEqual(64, TypeManager.AlignUp(63, 16));
            Assert.AreEqual(64, TypeManager.AlignUp(63, 32));
            Assert.AreEqual(64, TypeManager.AlignUp(63, 64));
            Assert.AreEqual(128, TypeManager.AlignUp(63, 128));
        }
        
        [Test]
        public void TestAlignUp_ZeroAlignment()
        {
            for (int value = 0; value < 512; ++value)
            {
                Assert.AreEqual(value, TypeManager.AlignUp(value, 0));
            }
        }

#if !UNITY_DOTSPLAYER
        [DisableAutoTypeRegistration]
        struct NonBlittableComponentData : IComponentData
        {
            string empty;
        }

        [DisableAutoTypeRegistration]
        struct NonBlittableComponentData2 : IComponentData
        {
            IComponentData empty;
        }

        class ClassComponentData : IComponentData
        {
        }

        interface InterfaceComponentData : IComponentData
        {
        }

        [DisableAutoTypeRegistration]
        struct NonBlittableBuffer: IBufferElementData
        {
            string empty;
        }

        class ClassBuffer: IBufferElementData
        {
        }

        interface InterfaceBuffer : IBufferElementData
        {
        }

        class ClassShared : ISharedComponentData
        {
        }

        interface InterfaceShared : ISharedComponentData
        {
        }

        [TestCase(typeof(InterfaceComponentData), @"\binterface\b", TestName = "Interface implementing IComponentData")]
        [TestCase(typeof(ClassComponentData), @"\b(struct|class)\b", TestName = "Class implementing IComponentData")]
        [TestCase(typeof(NonBlittableComponentData), @"\bblittable\b", TestName = "Non-blittable component data (string)")]
        [TestCase(typeof(NonBlittableComponentData2), @"\bblittable\b", TestName = "Non-blittable component data (interface)")]

        [TestCase(typeof(InterfaceBuffer), @"\binterface\b", TestName = "Interface implementing IBufferElementData")]
        [TestCase(typeof(ClassBuffer), @"\b(struct|class)\b", TestName = "Class implementing IBufferElementData")]
        [TestCase(typeof(NonBlittableBuffer), @"\bblittable\b", TestName = "Non-blittable IBufferElementData")]

        [TestCase(typeof(InterfaceShared), @"\binterface\b", TestName = "Interface implementing ISharedComponentData")]
        [TestCase(typeof(ClassShared), @"\b(struct|class)\b", TestName = "Class implementing ISharedComponentData")]

        [TestCase(typeof(GameObjectEntity), nameof(GameObjectEntity), TestName = "GameObjectEntity type")]

        [TestCase(typeof(float), @"\b(not .*|in)valid\b", TestName = "Not valid component type")]
        public void BuildComponentType_ThrowsArgumentException_WithExpectedFailures(Type type, string keywordPattern)
        {
            Assert.That(
                () => TypeManager.BuildComponentType(type),
                Throws.ArgumentException.With.Message.Matches(keywordPattern)
            );
        }

        [Test]
        public void ManagedFieldLayoutWorks()
        {
            var t  = TypeManager.GetTypeInfo<EcsStringSharedComponent>();
            var layout = t.FastEqualityTypeInfo;
            Assert.IsNull(layout.Layouts);
            Assert.IsNotNull(layout.GetHashFn);
            Assert.IsNotNull(layout.EqualFn);
        }


        [TestCase(typeof(UnityEngine.Transform))]
        [TestCase(typeof(TypeManagerTests))]
        public void BuildComponentType_WithClass_WhenUnityEngineComponentTypeIsNull_ThrowsArgumentException(Type type)
        {
            var componentType = TypeManager.UnityEngineComponentType;
            TypeManager.UnityEngineComponentType = null;
            try
            {
                Assert.That(
                    () => TypeManager.BuildComponentType(type),
                    Throws.ArgumentException.With.Message.Matches($"\\bregister\\b.*\\b{nameof(TypeManager.UnityEngineComponentType)}\\b")
                );
            }
            finally
            {
                TypeManager.UnityEngineComponentType = componentType;
            }
        }

        [Test]
        public void BuildComponentType_WithNonComponent_WhenUnityEngineComponentTypeIsCorrect_ThrowsArgumentException()
        {
            var componentType = TypeManager.UnityEngineComponentType;
            TypeManager.UnityEngineComponentType = typeof(UnityEngine.Component);
            try
            {
                var type = typeof(TypeManagerTests);
                Assert.That(
                    () => TypeManager.BuildComponentType(type),
                    Throws.ArgumentException.With.Message.Matches($"\\bmust inherit {typeof(UnityEngine.Component)}\\b")
                );
            }
            finally
            {
                TypeManager.UnityEngineComponentType = componentType;
            }
        }

        [Test]
        public void BuildComponentType_WithComponent_WhenUnityEngineComponentTypeIsCorrect_DoesNotThrowException()
        {
            var componentType = TypeManager.UnityEngineComponentType;
            TypeManager.UnityEngineComponentType = typeof(UnityEngine.Component);
            try
            {
                TypeManager.BuildComponentType(typeof(UnityEngine.Transform));
            }
            finally
            {
                TypeManager.UnityEngineComponentType = componentType;
            }
        }

        [TestCase(null)]
        [TestCase(typeof(TestType1))]
        [TestCase(typeof(InterfaceShared))]
        [TestCase(typeof(ClassShared))]
        [TestCase(typeof(UnityEngine.Transform))]
        public void RegisterUnityEngineComponentType_WithWrongType_ThrowsArgumentException(Type type)
        {
            Assert.Throws<ArgumentException>(() => TypeManager.RegisterUnityEngineComponentType(type));
        }

        [Test]
        public void IsAssemblyReferencingEntities()
        {
            Assert.IsFalse(TypeManager.IsAssemblyReferencingEntities(typeof(UnityEngine.GameObject).Assembly));
            Assert.IsFalse(TypeManager.IsAssemblyReferencingEntities(typeof(System.Collections.Generic.List<>).Assembly));
            Assert.IsFalse(TypeManager.IsAssemblyReferencingEntities(typeof(Collections.NativeList<>).Assembly));

            Assert.IsTrue(TypeManager.IsAssemblyReferencingEntities(typeof(IComponentData).Assembly));
            Assert.IsTrue(TypeManager.IsAssemblyReferencingEntities(typeof(EcsTestData).Assembly));
        }
#endif
    }


}
