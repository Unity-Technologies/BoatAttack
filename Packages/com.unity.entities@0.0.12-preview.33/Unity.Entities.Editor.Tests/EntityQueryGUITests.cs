
using NUnit.Framework;
using Unity.Jobs;

namespace Unity.Entities.Editor.Tests
{
 
    public struct JustComponentNonExclude: IComponentData {}
    public struct ZeroSizedComponent: IComponentData {}
    public struct NonZeroSizedComponent : IComponentData
    {
        public float Value;
    }

    public class ExclusionGroupSampleSystem : ComponentSystem
    {
        public Unity.Entities.EntityQuery Group1;
        public Unity.Entities.EntityQuery Group2;
 
        protected override void OnCreateManager()
        {
            Group1 = GetEntityQuery(typeof(JustComponentNonExclude), ComponentType.Exclude<ZeroSizedComponent>());
            Group2 = GetEntityQuery(typeof(JustComponentNonExclude), ComponentType.Exclude<NonZeroSizedComponent>());
        }

        protected override void OnUpdate()
        {
            throw new System.NotImplementedException();
        }
    }
    
    class GenericClassTest<T>
    {
        public class InternalClass {}
        public class InternalGenericClass<U, V> {}
    }
    
    public class EntityQueryGUITests
    {
        
        [Test]
        public void EntityQueryGUI_SpecifiedTypeName_NestedTypeInGeneric()
        {
            var typeName = EntityQueryGUI.SpecifiedTypeName(typeof(GenericClassTest<object>.InternalClass));
            Assert.AreEqual("GenericClassTest<Object>.InternalClass", typeName);
        }
        
        [Test]
        public void EntityQueryGUI_SpecifiedTypeName_NestedGenericTypeInGeneric()
        {
            var typeName = EntityQueryGUI.SpecifiedTypeName(typeof(GenericClassTest<object>.InternalGenericClass<int, bool>));
            Assert.AreEqual("GenericClassTest<Object>.InternalGenericClass<Int32, Boolean>", typeName);
        }

        [Test]
        public void EntityQueryGUI_ExcludedTypesUnaffectedByLength()
        {
            using (var world = new World("Test"))
            {
                var system = world.CreateSystem<ExclusionGroupSampleSystem>();
                var ui1 = new EntityQueryGUIControl(system.Group1.GetQueryTypes(), system.Group1.GetReadAndWriteTypes(), false);
                Assert.AreEqual(EntityDebuggerStyles.ComponentExclude, ui1.styles[1]);
                var ui2 = new EntityQueryGUIControl(system.Group2.GetQueryTypes(), system.Group2.GetReadAndWriteTypes(), false);
                Assert.AreEqual(EntityDebuggerStyles.ComponentExclude, ui2.styles[1]);
            }
            
        }
    }
}