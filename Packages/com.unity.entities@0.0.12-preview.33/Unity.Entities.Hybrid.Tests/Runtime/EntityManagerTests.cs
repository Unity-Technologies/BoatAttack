using NUnit.Framework;
using UnityEngine;

namespace Unity.Entities.Tests
{
    [DisallowMultipleComponent]
    [UnityEngine.AddComponentMenu("Hidden/DontUse")]
    public class EcsFooTestProxy : ComponentDataProxy<EcsFooTest> { }
    [DisallowMultipleComponent]
    [UnityEngine.AddComponentMenu("Hidden/DontUse")]
    public class EcsTestProxy : ComponentDataProxy<EcsTestData> { }

    class EntityManagerTests : ECSTestsFixture
    {
        [Test]
        public void GetComponentObjectReturnsTheCorrectType()
        {
            var go = new GameObject();
            go.AddComponent<EcsTestProxy>();

            var component = m_Manager.GetComponentObject<Transform>(go.GetComponent<GameObjectEntity>().Entity);

            Assert.NotNull(component, "EntityManager.GetComponentObject returned a null object");
            Assert.AreEqual(typeof(Transform), component.GetType(), "EntityManager.GetComponentObject returned the wrong component type.");
            Assert.AreEqual(go.transform, component, "EntityManager.GetComponentObject returned a different copy of the component.");
        }

        [Test]
        public void GetComponentObjectThrowsIfComponentDoesNotExist()
        {
            var go = new GameObject();
            go.AddComponent<EcsTestProxy>();

            Assert.Throws<System.ArgumentException>(() => m_Manager.GetComponentObject<Rigidbody>(go.GetComponent<GameObjectEntity>().Entity));
        }
    }
}
