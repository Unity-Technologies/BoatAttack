using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using UnityEditor.Experimental.SceneManagement;
using UnityEngine;
using UnityEngine.TestTools;

namespace Unity.Entities.Tests
{
    class ComponentDataProxy_Prefab_IntegrationTests
    {
        static readonly TestCaseData[] proxyTypeTestCases =
        {
            new TestCaseData(
                "Packages/com.unity.entities/Unity.Entities.Hybrid.Tests/Prefab_With_ComponentDataProxy.prefab",
                (Func<ComponentDataProxyBase, object>)(proxy => {
                    var v = (proxy as MockDataProxy).Value; ++v.Value; (proxy as MockDataProxy).Value = v; return v;
                }),
                (Func<GameObjectEntity, object>)(goe => goe.EntityManager.GetComponentData<MockData>(goe.Entity))
            ).Returns(null).SetName("Prefab ComponentDataProxy"),
            new TestCaseData(
                "Packages/com.unity.entities/Unity.Entities.Hybrid.Tests/Prefab_With_SharedComponentDataProxy.prefab",
                (Func<ComponentDataProxyBase, object>)(proxy => {
                    var v = (proxy as MockSharedDataProxy).Value; ++v.Value; (proxy as MockSharedDataProxy).Value = v; return v;
                }),
                (Func<GameObjectEntity, object>)(goe => goe.EntityManager.GetSharedComponentData<MockSharedData>(goe.Entity))
            ).Returns(null).SetName("Prefab SharedComponentDataProxy"),
            new TestCaseData(
                "Packages/com.unity.entities/Unity.Entities.Hybrid.Tests/Prefab_With_DynamicBufferDataProxy.prefab",
                (Func<ComponentDataProxyBase, object>)(proxy => {
                    var v = (proxy as MockDynamicBufferDataProxy).Value.ToList(); v.Add(new MockDynamicBufferData { Value = 1 }); (proxy as MockDynamicBufferDataProxy).SetValue(v); return v;
                }),
                (Func<GameObjectEntity, object>)(goe => goe.EntityManager.GetBuffer<MockDynamicBufferData>(goe.Entity).AsNativeArray().ToArray())
            ).Returns(null).SetName("Prefab DynamicBufferProxy")
        };

        static readonly MethodInfo k_OpenPrefab =
            typeof(PrefabStageUtility).GetMethod("OpenPrefab", BindingFlags.Static | BindingFlags.NonPublic, null, new[] { typeof(string) }, Array.Empty<ParameterModifier>());

        [Ignore("Disabled for now since it enters playmode and we need to avoid those tests")]
        [UnityTest, TestCaseSource(nameof(proxyTypeTestCases))]
        public IEnumerator ComponentDataProxy_WhenEnterPlayMode_ThenEditPrefab_ThenExitPlayMode_StillSynchronizesWithEntityManager(
            string prefabPath,
            Func<ComponentDataProxyBase, object> mutateValueOnProxy,
            Func<GameObjectEntity, object> getComponentDataValueFromEntityManager
        )
        {
            yield return new EnterPlayMode();
            k_OpenPrefab.Invoke(null, new object[] { prefabPath });
            yield return new ExitPlayMode();

            var go = PrefabStageUtility.GetCurrentPrefabStage().prefabContentsRoot;
            var proxy = go.GetComponent<ComponentDataProxyBase>();
            var expected = mutateValueOnProxy(proxy);
            var valueFromEntityManager = getComponentDataValueFromEntityManager(go.GetComponent<GameObjectEntity>());

            Assert.That(valueFromEntityManager, Is.EqualTo(expected), $"{proxy} is no longer synchronizing with EntityManager");
        }
    }
}
