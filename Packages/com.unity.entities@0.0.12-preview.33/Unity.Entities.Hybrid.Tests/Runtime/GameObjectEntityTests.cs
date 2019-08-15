using System;
using NUnit.Framework;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Unity.Entities.Tests
{
    //@TODO: Test for prevent adding proxy component to type system...

    class GameObjectEntityTests : ECSTestsFixture
    {
        [Test]
        [Ignore("not implemented")]
        public void ComponentArrayWithParentClass() { }


        [Test]
        public void TransformAccessArrayTests()
        {

        }

        [Test]
        public void GameObjectEntityNotAdded()
        {
            var go = new GameObject("test", typeof(GameObjectEntity));
            var entity = GameObjectEntity.AddToEntityManager(m_Manager, go);
            Assert.Throws<ArgumentException>(() => { m_Manager.HasComponent<GameObjectEntity>(entity); });
        }

        unsafe struct MyEntity
        {
#pragma warning disable 649
            public Light              light;
            public Rigidbody          rigidbody;

            public EcsTestData*       testData;
            public EcsTestData2*      testData2;
#pragma warning restore 649
        }

        [Test]
        [Ignore("TODO")]
        public void ComponentEnumeratorInvalidChecks()
        {
            //* Check for string in MyEntity and other illegal constructs...
        }

        [Test]
        [Ignore("TODO")]
        public void AddComponentDuringForeachProtection()
        {
            //* Check for string in MyEntity and other illegal constructs...
        }
                
        [Test]
        public void AddRemoveGetComponentObject()
        {
            var go = new GameObject("test", typeof(Rigidbody));
            var rb = go.GetComponent<Rigidbody>();
            
            var entity = m_Manager.CreateEntity();

            m_Manager.AddComponentObject(entity, go.GetComponent<Rigidbody>());
            
            Assert.AreEqual(rb, m_Manager.GetComponentObject<Rigidbody>(entity));;

            m_Manager.RemoveComponent<Rigidbody>(entity);
            
            Assert.Throws<ArgumentException>(()=> m_Manager.GetComponentObject<Rigidbody>(entity));
            
            Object.DestroyImmediate(go);
        }
        
        [Test]
        public void AddNullObjectThrows()
        {
            var entity = m_Manager.CreateEntity();
            Assert.Throws<ArgumentNullException>(()=> m_Manager.AddComponentObject(entity, null));
        }
    }
}
