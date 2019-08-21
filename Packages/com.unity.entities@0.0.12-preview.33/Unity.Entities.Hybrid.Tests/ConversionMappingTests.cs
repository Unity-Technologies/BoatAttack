using System.Linq;
using NUnit.Framework;
using Unity.Entities;
using Unity.Entities.Tests;

namespace UnityEngine.Entities.Tests
{
    class ConversionMappingTests : ECSTestsFixture
    {
        World                             dstWorld;
        GameObjectConversionMappingSystem mappingSystem;
        
        [SetUp]
        public override void Setup()
        {
            base.Setup();
            dstWorld = new World("Test dst world");
            mappingSystem = World.CreateSystem<GameObjectConversionMappingSystem>(dstWorld, default(Unity.Entities.Hash128), GameObjectConversionUtility.ConversionFlags.None);
        }

        [TearDown]
        public override void TearDown()
        {
            base.TearDown();
            dstWorld.Dispose();
        }
        
        
        [Test]
        public void GetPrimaryEntity()
        {
            var go = new GameObject(TestContext.CurrentContext.Test.Name);

            
            mappingSystem.CreatePrimaryEntity(go);
            var entity = mappingSystem.GetPrimaryEntity(go);
            Assert.AreEqual(entity, mappingSystem.GetPrimaryEntity(go));
            
            var array = mappingSystem.GetEntities(go).ToArray();
            Assert.AreEqual(1, array.Length);
            Assert.AreEqual(entity, array[0]);
            
            GameObject.DestroyImmediate(go);
        }

        [Test]
        public void AdditionalEntity()
        {
            var go = new GameObject(TestContext.CurrentContext.Test.Name);
            var go2 = new GameObject(TestContext.CurrentContext.Test.Name);

            mappingSystem.CreatePrimaryEntity(go);
            mappingSystem.CreatePrimaryEntity(go2);
            
            var entity = mappingSystem.GetPrimaryEntity(go);
            var entity2 = mappingSystem.GetPrimaryEntity(go2);
            var additional0 = mappingSystem.CreateAdditionalEntity(go);
            var additional1 = mappingSystem.CreateAdditionalEntity(go);
            
            Assert.AreNotEqual(entity, additional0);
            Assert.AreNotEqual(entity, entity2);
            Assert.AreNotEqual(entity, additional1);
            Assert.AreNotEqual(additional0, additional1);
            Assert.AreEqual(entity, mappingSystem.GetPrimaryEntity(go));
            Assert.AreEqual(entity2, mappingSystem.GetPrimaryEntity(go2));
            
            var entities = mappingSystem.GetEntities(go).ToArray();
            Assert.AreEqual(new [] { entity, additional0, additional1 }, entities);
            
            var entities2 = mappingSystem.GetEntities(go2).ToArray();
            Assert.AreEqual(new [] { entity2 }, entities2);
            
            GameObject.DestroyImmediate(go);
            GameObject.DestroyImmediate(go2);
        }
        
    }
}