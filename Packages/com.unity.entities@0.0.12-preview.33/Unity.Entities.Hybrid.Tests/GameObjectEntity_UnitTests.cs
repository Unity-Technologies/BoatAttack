using System;
using NUnit.Framework;
using UnityEngine;

namespace Unity.Entities.Tests
{
    class GameObjectEntity_UnitTests
    {
        GameObjectEntity m_GameObjectEntity;

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

        static TestCaseData[] k_AccessorTestCases =
        {
            new TestCaseData((Func<GameObjectEntity, object>)(goe => goe.EntityManager)).Returns(null).SetName("EntityManager"),
            new TestCaseData((Func<GameObjectEntity, object>)(goe => goe.Entity)).Returns(default(Entity)).SetName("Entity")
        };

        [TestCaseSource(nameof(k_AccessorTestCases))]
        public object Accessors_WhenGameObjectEntityDisabled_ReturnDefaultValues(Func<GameObjectEntity, object> accessor)
        {
            m_GameObjectEntity.enabled = false;

            return accessor(m_GameObjectEntity);
        }

        [TestCaseSource(nameof(k_AccessorTestCases))]
        public object Accessors_WhenGameObjectEntityDeactivated_ReturnDefaultValues(Func<GameObjectEntity, object> accessor)
        {
            m_GameObjectEntity.gameObject.SetActive(false);

            return accessor(m_GameObjectEntity);
        }
    }
}
