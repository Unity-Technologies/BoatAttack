using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using UnityEditor;
using UnityEngine;

namespace Unity.Entities.Tests
{
    class ComponentDataProxy_EntityManager_IntegrationTests
    {
        GameObjectEntity m_GameObjectEntity;
        Entity Entity { get { return m_GameObjectEntity.Entity; } }
        EntityManager Manager { get { return m_GameObjectEntity.EntityManager; } }

        [SetUp]
        public void SetUp()
        {
            m_GameObjectEntity =
                new GameObject(TestContext.CurrentContext.Test.Name, typeof(GameObjectEntity)).GetComponent<GameObjectEntity>();
        }

        [TearDown]
        public void TearDown()
        {
            if (m_GameObjectEntity.gameObject != null)
                GameObject.DestroyImmediate(m_GameObjectEntity.gameObject);
        }

        public delegate object MockGetter(ComponentDataProxyBase proxy);

        static object GetMockData(ComponentDataProxyBase proxy) =>
            (proxy as MockDataProxy).Value;

        static object GetMockSharedData(ComponentDataProxyBase proxy) =>
            (proxy as MockSharedDataProxy).Value;

        static object GetMockDynamicBufferData(ComponentDataProxyBase proxy) =>
            (proxy as MockDynamicBufferDataProxy).Value;

        public delegate void MockSetter(ComponentDataProxyBase proxy, object value);

        static void SetMockData(ComponentDataProxyBase proxy, object value) =>
            (proxy as MockDataProxy).Value = (MockData)value;

        static void SetMockSharedData(ComponentDataProxyBase proxy, object value) =>
            (proxy as MockSharedDataProxy).Value = (MockSharedData)value;

        static void SetMockDynamicBufferData(ComponentDataProxyBase proxy, object value) =>
            (proxy as MockDynamicBufferDataProxy).SetValue((IReadOnlyList<MockDynamicBufferData>)value);

        static readonly TestCaseData[] k_SetValueSyncTestCases =
        {
            new TestCaseData(
                typeof(MockDataProxy),
                Is.EqualTo(default(MockData)),
                new MockData { Value = 1 },
                (MockSetter)SetMockData, (MockGetter)GetMockData
            ).SetName("Sync ComponentDataProxy"),
            new TestCaseData(
                typeof(MockSharedDataProxy),
                Is.EqualTo(default(MockSharedData)),
                new MockSharedData { Value = 1 },
                (MockSetter)SetMockSharedData, (MockGetter)GetMockSharedData
            ).SetName("Sync SharedComponentDataProxy"),
            new TestCaseData(
                typeof(MockDynamicBufferDataProxy),
                Is.Empty,
                Enumerable.Range(1, 3).Select(i => new MockDynamicBufferData { Value = i }).ToArray(),
                (MockSetter)SetMockDynamicBufferData, (MockGetter)GetMockDynamicBufferData
            ).SetName("Sync DynamicBufferProxy")
        };

        [TestCaseSource(nameof(k_SetValueSyncTestCases))]
        public void ComponentDataProxy_SetValue_SynchronizesWithEntityManager(
            Type proxyType, Constraint isDefaultValue, object expectedValue, MockSetter setValue, MockGetter getValue
        )
        {
            var proxy = m_GameObjectEntity.gameObject.AddComponent(proxyType) as ComponentDataProxyBase;
            EntityManager entityManager;
            Entity entity;
            Assume.That(
                proxy.CanSynchronizeWithEntityManager(out entityManager, out entity), Is.True,
                "EntityManager is not in correct state in arrangement for synchronization to occur"
            );
            var defaultValue = getValue(proxy);
            Assume.That(
                defaultValue, isDefaultValue,
                $"{proxy.GetType()} did not initialize with default value in arrangement"
            );

            setValue(proxy, expectedValue);
            new SerializedObject(proxy);

            var actual = getValue(proxy);
            Assert.That(actual, Is.EqualTo(expectedValue), $"Value was reset after deserializing {proxyType}");
        }

        static readonly FieldInfo k_EntityManagerBackingField =
            typeof(GameObjectEntity).GetField("m_EntityManager", BindingFlags.Instance | BindingFlags.NonPublic);

        static readonly TestCaseData[] k_InvalidManagerSyncTestCases =
        {
            new TestCaseData(
                typeof(MockDataProxy),
                new MockData { Value = 1 },
                (MockSetter)SetMockData, (MockGetter)GetMockData
            ).SetName("Sync ComponentDataProxy (Invalid Manager)"),
            new TestCaseData(
                typeof(MockSharedDataProxy),
                new MockSharedData { Value = 1 },
                (MockSetter)SetMockSharedData, (MockGetter)GetMockSharedData
            ).SetName("Sync SharedComponentDataProxy (Invalid Manager)"),
            new TestCaseData(
                typeof(MockDynamicBufferDataProxy),
                Enumerable.Range(1, 3).Select(i => new MockDynamicBufferData { Value = i }).ToArray(),
                (MockSetter)SetMockDynamicBufferData, (MockGetter)GetMockDynamicBufferData
            ).SetName("Sync DynamicBufferProxy (InvalidManager)")
        };

        [TestCaseSource(nameof(k_InvalidManagerSyncTestCases))]
        public void ComponentDataProxy_WhenEntityManagerIsInvalid_SynchronizesWithEntityManager(
            Type proxyType, object expectedValue, MockSetter setValue, MockGetter getValue
        )
        {
            var entityManager = EntityManager.CreateEntityManagerInUninitializedState();
            k_EntityManagerBackingField.SetValue(m_GameObjectEntity, entityManager);
            Assume.That(entityManager.IsCreated, Is.False, "EntityManager was not in correct state in test arrangement");
            var proxy = m_GameObjectEntity.gameObject.AddComponent(proxyType) as ComponentDataProxyBase;

            setValue(proxy, expectedValue);

            var actual = getValue(proxy);
            Assert.That(actual, Is.EqualTo(expectedValue), $"Setting value on {proxyType} failed");
        }

        [Test]
        public void AddComponentDataProxy_WhenGameObjectEntityAlreadyActive_EntityManagerHasComponent()
        {
            Assume.That(Manager.Exists(Entity));

            m_GameObjectEntity.gameObject.AddComponent<MockDataProxy>();

            Assert.That(Manager.HasComponent(Entity, typeof(MockData)), Is.True, "No data after adding proxy.");
        }

        [Test]
        public void DestroyComponentDataProxy_WhenGameObjectEntityAlreadyActive_EntityManagerDoesNotHaveComponent()
        {
            Assume.That(Manager.Exists(Entity));
            var c = m_GameObjectEntity.gameObject.AddComponent<MockDataProxy>();
            Assume.That(Manager.HasComponent(Entity, typeof(MockData)), Is.True, "No data after adding proxy.");

            Component.DestroyImmediate(c);

            Assert.That(Manager.HasComponent(Entity, typeof(MockData)), Is.False, "Data after destroying proxy.");
        }

        [Test]
        public void DisableComponentDataProxy_WhenGameObjectEntityAlreadyActive_EntityManagerDoesNotHaveComponent()
        {
            Assume.That(Manager.Exists(Entity));
            var c = m_GameObjectEntity.gameObject.AddComponent<MockDataProxy>();
            Assume.That(Manager.HasComponent(Entity, typeof(MockData)), Is.True, "No data after adding proxy.");

            c.enabled = false;

            Assert.That(Manager.HasComponent(Entity, typeof(MockData)), Is.False, "Data exists after disabling proxy.");
        }

        [Test]
        public void ReEnableComponentDataProxy_WhenGameObjectEntityAlreadyActive_EntityManagerHasComponent()
        {
            Assume.That(Manager.Exists(Entity));
            var c = m_GameObjectEntity.gameObject.AddComponent<MockDataProxy>();
            Assume.That(Manager.HasComponent(Entity, typeof(MockData)), Is.True, "No data after adding proxy.");
            c.enabled = false;
            Assume.That(Manager.HasComponent(Entity, typeof(MockData)), Is.False, "Data exists after disabling proxy.");

            c.enabled = true;

            Assert.That(Manager.HasComponent(Entity, typeof(MockData)), Is.True, "No data after re-enabling proxy.");
        }
    }
}
