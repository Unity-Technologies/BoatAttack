using NUnit.Framework;
using Unity.Properties;
using Unity.Properties.Reflection;
using UnityEngine;

namespace Unity.Entities.Properties.Tests
{
    [TestFixture]
    internal sealed class EntityContainerTests
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

        [Test]
        public void VisitEntityContainer()
        {
            var entity = m_Manager.CreateEntity(typeof(TestComponent), typeof(TestBufferElementData));

            var testComponent = m_Manager.GetComponentData<TestComponent>(entity);
            testComponent.x = 123f;
            m_Manager.SetComponentData(entity, testComponent);

            var buffer = m_Manager.GetBuffer<TestBufferElementData>(entity);
            buffer.Add(new TestBufferElementData { flt = 1.2f });
            buffer.Add(new TestBufferElementData { flt = 3.4f });

            var container = new EntityContainer(m_Manager, entity);

            PropertyContainer.Visit(container, new EntityVisitor());
        }

        private class EntityVisitor : PropertyVisitor
        {
            protected override VisitStatus BeginContainer<TProperty, TContainer, TValue>(TProperty property, ref TContainer container, ref TValue value, ref ChangeTracker changeTracker)
            {
                Debug.Log($"BeginContainer [{typeof(TContainer)}] [{typeof(TValue)}]");
                return VisitStatus.Handled;
            }

            protected override VisitStatus BeginCollection<TProperty, TContainer, TValue>(TProperty property, ref TContainer container, ref TValue value, ref ChangeTracker changeTracker)
            {
                Debug.Log($"BeginCollection [{typeof(TContainer)}] [{typeof(TValue)}]");
                return VisitStatus.Handled;
            }

            protected override VisitStatus Visit<TProperty, TContainer, TValue>(TProperty property, ref TContainer container, ref TValue value, ref ChangeTracker changeTracker)
            {
                Debug.Log($"Visit [{typeof(TContainer)}] [{typeof(TValue)}]");
                return VisitStatus.Handled;
            }
        }
    }
}
