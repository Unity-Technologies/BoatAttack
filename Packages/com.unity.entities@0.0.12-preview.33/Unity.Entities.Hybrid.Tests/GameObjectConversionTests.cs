using System.ComponentModel;
using System.Text.RegularExpressions;
using NUnit.Framework;
using Unity.Entities;
using Unity.Entities.Tests;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using static Unity.Entities.GameObjectConversionUtility;

namespace UnityEngine.Entities.Tests
{
    class GameObjectConversionTests : ECSTestsFixture
    {
        public static void ConvertSceneAndApplyDiff(Scene scene, World previousStateShadowWorld, World dstEntityWorld)
        {
            using (var cleanConvertedEntityWorld = new World("Clean Entity Conversion World"))
            {
                ConvertScene(scene, default(Unity.Entities.Hash128), cleanConvertedEntityWorld, ConversionFlags.AddEntityGUID);
                WorldDiffer.DiffAndApply(cleanConvertedEntityWorld, previousStateShadowWorld, dstEntityWorld);
            }
        }
        
        [Test]
        public void ConvertGameObject_HasOnlyTransform_ProducesEntityWithPositionAndRotation([Values]bool useDiffing)
        {
            // Prepare scene
            var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
            SceneManager.SetActiveScene(scene);
            
            var go = new GameObject("Test Conversion");
            go.transform.localPosition = new Vector3(1, 2, 3);
            
            // Convert
            if (useDiffing)
            {
                var shadowWorld = new World("Shadow");
                ConvertSceneAndApplyDiff(scene, shadowWorld, m_Manager.World);
                shadowWorld.Dispose();
            }
            else
            {
                ConvertScene(scene, default(Unity.Entities.Hash128), m_Manager.World);
            }
            
            // Check
            var entities = m_Manager.GetAllEntities();
            Assert.AreEqual(1, entities.Length);
            var entity = entities[0];

            Assert.AreEqual(useDiffing ? 4 : 3, m_Manager.GetComponentCount(entity));
            Assert.IsTrue(m_Manager.HasComponent<Translation>(entity));
            Assert.IsTrue(m_Manager.HasComponent<Rotation>(entity));
            if (useDiffing)
                Assert.IsTrue(m_Manager.HasComponent<EntityGuid>(entity));

            Assert.AreEqual(new float3(1, 2, 3), m_Manager.GetComponentData<Translation>(entity).Value);
            Assert.AreEqual(quaternion.identity, m_Manager.GetComponentData<Rotation>(entity).Value);
            var localToWorld = m_Manager.GetComponentData<LocalToWorld>(entity).Value;
            Assert.IsTrue(localToWorld.Equals(go.transform.localToWorldMatrix));
            
            // Unload
            EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
        }
        
        [Test]
        public void ConversionIgnoresMissingMonoBehaviour()
        {
            TestTools.LogAssert.Expect(LogType.Warning, new Regex("missing"));
            
            var entity = ConvertGameObjectHierarchy(AssetDatabase.LoadAssetAtPath<GameObject>("Packages/com.unity.entities/Unity.Entities.Hybrid.Tests/Conversion_Prefab_MissingMB.prefab"), World);

            Assert.IsTrue(m_Manager.Exists(entity));
        }
        
        [Test]
        public void ConversionOfGameObject()
        {
            var gameObject = new GameObject();
            var entity = ConvertGameObjectHierarchy(gameObject, World);

            Assert.IsFalse(m_Manager.HasComponent<Prefab>(entity));
            Assert.IsFalse(m_Manager.HasComponent<Static>(entity));
            Assert.IsFalse(m_Manager.HasComponent<Disabled>(entity));

            Object.DestroyImmediate(gameObject);
        }
        
        [Test]
        public void ConversionOfStatic()
        {
            var gameObject = new GameObject("", typeof(StaticOptimizeEntity));
            var entity = ConvertGameObjectHierarchy(gameObject, World);

            Assert.IsTrue(m_Manager.HasComponent<Static>(entity));
            Assert.IsFalse(m_Manager.HasComponent<Translation>(entity));
            Assert.IsFalse(m_Manager.HasComponent<Rotation>(entity));
            Object.DestroyImmediate(gameObject);
        }

        [Test]
        public void ConversionOfComponentDataProxy()
        {
            var gameObject = new GameObject();
            gameObject.AddComponent<EcsTestProxy>().Value = new EcsTestData(5);
            
            var entity = ConvertGameObjectHierarchy(gameObject, World);

            Assert.AreEqual(5, m_Manager.GetComponentData<EcsTestData>(entity).value);
            Object.DestroyImmediate(gameObject);
        }
        
        [Test]
        public void ConversionOfPrefabIsEntityPrefab()
        {
            var entity = ConvertGameObjectHierarchy(AssetDatabase.LoadAssetAtPath<GameObject>("Packages/com.unity.entities/Unity.Entities.Hybrid.Tests/Conversion_Prefab.prefab"), World);
            Assert.IsTrue(m_Manager.HasComponent<Prefab>(entity));
            Assert.IsFalse(m_Manager.HasComponent<Disabled>(entity));
        }

        [Test]
        public void ConversionOfNullReference()
        {
            var go = new GameObject();
            go.AddComponent<EntityRefTestDataComponent>();
            
            var entity = ConvertGameObjectHierarchy(go, World);
            Assert.AreEqual(Entity.Null, m_Manager.GetComponentData<EntityRefTestData>(entity).Value);
            
            Object.DestroyImmediate(go);        
        }

        [Test]
        public void ConversionOfPrefabReferenceOtherPrefab()
        {
            var go = new GameObject();
            go.AddComponent<EntityRefTestDataComponent>().Value = AssetDatabase.LoadAssetAtPath<GameObject>("Packages/com.unity.entities/Unity.Entities.Hybrid.Tests/Conversion_Prefab_Reference_Prefab.prefab");
            
            var entity = ConvertGameObjectHierarchy(go, World);
            Assert.IsFalse(m_Manager.HasComponent<Prefab>(entity));
            var referenced = m_Manager.GetComponentData<EntityRefTestData>(entity).Value;
            
            // Conversion_Prefab_Reference_Prefab.prefab
            Assert.IsTrue(m_Manager.HasComponent<Prefab>(referenced));
            Assert.AreEqual(1, m_Manager.GetComponentData<MockData>(referenced).Value);
            
            // Conversion_Prefab.prefab
            var referenced2 = m_Manager.GetComponentData<EntityRefTestData>(referenced).Value;
            Assert.IsTrue(m_Manager.HasComponent<Prefab>(referenced2));
            Assert.AreEqual(0, m_Manager.GetComponentData<MockData>(referenced2).Value);
            
            Object.DestroyImmediate(go);
        }

        [Test]
        public void ConversionOfPrefabSelfReference()
        {
            var go = new GameObject();
            go.AddComponent<EntityRefTestDataComponent>().Value = AssetDatabase.LoadAssetAtPath<GameObject>("Packages/com.unity.entities/Unity.Entities.Hybrid.Tests/Conversion_Prefab_Reference_Self.prefab");

            var entity = ConvertGameObjectHierarchy(go, World);
            var referenced = m_Manager.GetComponentData<EntityRefTestData>(entity).Value;
            Assert.IsTrue(m_Manager.HasComponent<Prefab>(referenced));
            Assert.AreEqual(referenced, m_Manager.GetComponentData<EntityRefTestData>(referenced).Value);
                        
            Object.DestroyImmediate(go);
        }
        
        [Test]
        public void ReferenceOutsideConvertedGroupWarning()
        {
            TestTools.LogAssert.Expect(LogType.Warning, new Regex("not included in the conversion"));
            var go = new GameObject();
            
            var notIncluded = new GameObject();
            go.AddComponent<EntityRefTestDataComponent>().Value = notIncluded;

            var entity = ConvertGameObjectHierarchy(go, World);
            
            Assert.AreEqual(1, m_Manager.Debug.EntityCount);
            Assert.AreEqual(Entity.Null, m_Manager.GetComponentData<EntityRefTestData>(entity).Value);
                        
            Object.DestroyImmediate(go);
            Object.DestroyImmediate(notIncluded);
        }

        [Test]
        public void SetEnabledOnPrefabOnCompleteSet()
        {
            var entity = ConvertGameObjectHierarchy(AssetDatabase.LoadAssetAtPath<GameObject>("Packages/com.unity.entities/Unity.Entities.Hybrid.Tests/Conversion_Prefab_Hierarchy.prefab"), World);

            var mockQuery = m_Manager.CreateEntityQuery(typeof(MockData));
            var instance = m_Manager.Instantiate(entity);
            Assert.AreEqual(2, mockQuery.CalculateLength());
            
            m_Manager.SetEnabled(instance, false);
            Assert.AreEqual(0, mockQuery.CalculateLength());
            
            m_Manager.SetEnabled(instance, true);
            Assert.AreEqual(2, mockQuery.CalculateLength());
        }

        
        [Test]
        public void InactiveHierarchyBecomesPartOfLinkedEntityGroupSet()
        {
            var go = new GameObject();
            var child = new GameObject();
            var childChild = new GameObject();

            child.SetActive(false);
            go.AddComponent<EntityRefTestDataComponent>().Value = child;
            child.transform.parent = go.transform;
            childChild.transform.parent = child.transform;
            
            var query = m_Manager.CreateEntityQuery(new EntityQueryDesc());
            
            var entity = ConvertGameObjectHierarchy(go, World);
            
            Assert.AreEqual(1, query.CalculateLength());
            // Conversion will automatically add a LinkedEntityGroup to all inactive children
            // so that when enabling them, the whole hierarchy will get enabled
            m_Manager.SetEnabled(m_Manager.GetComponentData<EntityRefTestData>(entity).Value, true);
            Assert.AreEqual(3, query.CalculateLength());

            Object.DestroyImmediate(go);
        }
        
        [Test]
        public void InactiveConversion()
        {
            var gameObject = new GameObject();
            var child = new GameObject();
            child.transform.parent = gameObject.transform;
            gameObject.gameObject.SetActive(false);
            
            ConvertGameObjectHierarchy(gameObject, World);

            Assert.AreEqual(0, m_Manager.CreateEntityQuery(typeof(Translation)).CalculateLength());
            Assert.AreEqual(2, m_Manager.UniversalQuery.CalculateLength());
            
            Object.DestroyImmediate(gameObject);
        }

        [Test]
        public void DisabledBehaviourStripping()
        {
            var gameObject = new GameObject();
            gameObject.AddComponent<MockDataProxy>().enabled = false;
            gameObject.AddComponent<EntityRefTestDataComponent>().enabled = false;

            var entity = ConvertGameObjectHierarchy(gameObject, World);
            Object.DestroyImmediate(gameObject);

            Assert.AreEqual(1, m_Manager.Debug.EntityCount);
            Assert.IsFalse(m_Manager.HasComponent<EntityRefTestData>(entity));
            Assert.IsFalse(m_Manager.HasComponent<MockData>(entity));
        }
    }
}
