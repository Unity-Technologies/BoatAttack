using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace Unity.Entities.Tests
{
    class GameObjectEntity_EntityManager_IntegrationTests
    {
        public enum ActivateTestObject { Child, Parent }

        GameObjectEntity m_GameObjectEntity;
        Dictionary<ActivateTestObject, GameObject> m_TestObjects = new Dictionary<ActivateTestObject, GameObject>();

        Entity Entity { get { return m_GameObjectEntity.Entity; } }

        [SetUp]
        public void SetUp()
        {
            var parent = new GameObject($"{TestContext.CurrentContext.Test.Name}-PARENT");
            m_TestObjects[ActivateTestObject.Parent] = parent;
            m_GameObjectEntity =
                new GameObject(TestContext.CurrentContext.Test.Name, typeof(GameObjectEntity), typeof(MockDataProxy)).GetComponent<GameObjectEntity>();
            m_GameObjectEntity.gameObject.transform.SetParent(parent.transform);
            m_TestObjects[ActivateTestObject.Child] = m_GameObjectEntity.gameObject;

        }

        [TearDown]
        public void TearDown()
        {
            foreach (var go in m_TestObjects.Values)
            {
                if (go != null)
                    GameObject.DestroyImmediate(go);
            }
        }

        [Test]
        public void DeactivateGameObjectEntity_EntityManagerEntityDoesNotExist([Values]ActivateTestObject testObject)
        {
            var manager = m_GameObjectEntity.EntityManager;
            Assume.That(manager.Exists(Entity), Is.True);

            m_TestObjects[testObject].SetActive(false);

            Assert.That(manager.Exists(Entity), Is.False, $"Entity exists after deactivating {testObject}");
        }

        [Test]
        public void ReactivateGameObjectEntity_EntityManagerHasComponent([Values]ActivateTestObject testObject)
        {
            var manager = m_GameObjectEntity.EntityManager;
            m_TestObjects[testObject].SetActive(false);
            Assume.That(manager.Exists(Entity), Is.False, $"Entity exists after deactivating {testObject}");

            m_TestObjects[testObject].SetActive(true);
            Assume.That(manager.Exists(Entity), Is.True, $"Entity does not exist after reactivating {testObject}");

            Assert.That(manager.HasComponent(Entity, typeof(MockData)), Is.True, $"MockData not exist after reactivating {testObject}.");
        }
    }
}
