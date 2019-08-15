using NUnit.Framework;
using Unity.Entities.Properties.Tests;
using Unity.PerformanceTesting;
using Unity.Properties;
using Unity.Properties.Reflection;

namespace Unity.Entities.Properties.PerformanceTests
{
    [TestFixture]
    internal sealed class EntityContainerPerformanceTests
    {
        private World 			m_PreviousWorld;
        private World 			m_World;
        private EntityManager   m_Manager;

        [SetUp]
        public void Setup()
        {
            m_PreviousWorld = World.Active;
            m_World = World.Active = new World ("Test World");
            m_Manager = m_World.EntityManager;

            PropertyBagResolver.RegisterProvider(new ReflectedPropertyBagProvider());
        }

        [TearDown]
        public void TearDown()
        {
            if (m_Manager != null)
            {
                m_World.Dispose();
                m_World = null;

                World.Active = m_PreviousWorld;
                m_PreviousWorld = null;
                m_Manager = null;
            }
        }


#if UNITY_2019_2_OR_NEWER
        [Test, Performance]
#else
        [PerformanceTest]
#endif
        public void PerformanceTest_VisitEntityContainer()
        {
            var entity = m_Manager.CreateEntity(typeof(TestComponent), typeof(TestBufferElementData));

            var testComponent = m_Manager.GetComponentData<TestComponent>(entity);
            testComponent.x = 123f;
            m_Manager.SetComponentData(entity, testComponent);

            var buffer = m_Manager.GetBuffer<TestBufferElementData>(entity);
            buffer.Add(new TestBufferElementData { flt = 1.2f });
            buffer.Add(new TestBufferElementData { flt = 3.4f });

            var visitor = new DebugVisitor();

            Measure.Method(() =>
                   {
                       PropertyContainer.Visit(ref testComponent, visitor);
                   })
                   .Definition("EntityContainerVisit")
                   .WarmupCount(1)
                   .MeasurementCount(100)
                   .GC()
                   .Run();
        }

        private class DebugVisitor : PropertyVisitor
        {
            protected override VisitStatus Visit<TProperty, TContainer, TValue>(TProperty property, ref TContainer container, ref TValue value, ref ChangeTracker changeTracker)
            {
                return VisitStatus.Handled;
            }
        }
    }
}
