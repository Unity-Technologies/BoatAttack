using System.Collections;
using NUnit.Framework;
using Unity.Entities;
using Unity.Entities.Tests;
using Unity.Scenes.Editor;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.TestTools;

namespace Unity.Scenes.Tests
{
    public class SaveAndLoadEndToEnd : ECSTestsFixture
    {
        // Load / unload scene
        // Enter live link
        // Close live link
        // Unload scene after live link
    
        [UnityTest]
        public IEnumerator EndToEnd()
        {
            var guid = GUID.Generate();
            var temp = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
            EditorSceneManager.SetActiveScene(temp);
            var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            var entitySceneData = EditorEntityScenes.WriteEntityScene(temp, guid, 0);
            Assert.AreEqual(1, entitySceneData.Length);
        
            var sceneEntity = m_Manager.CreateEntity();
            m_Manager.AddComponentData(sceneEntity, entitySceneData[0]);

            for (int i = 0; i != 10; i++)
            {
                m_Manager.AddComponentData(sceneEntity, new RequestSceneLoaded());

                Assert.AreEqual(1, m_Manager.Debug.EntityCount);

                for (int w = 0; w != 1000; w++)
                {
                    World.GetOrCreateSystem<SubSceneStreamingSystem>().Update();
                    if (1 != m_Manager.Debug.EntityCount)
                        break;

                    yield return null;
                }

                // 1. Scene entity
                // 2. Public ref array
                // 3. Mesh Renderer
                Assert.AreEqual(3, m_Manager.Debug.EntityCount);

                m_Manager.RemoveComponent<RequestSceneLoaded>(sceneEntity);
                World.GetOrCreateSystem<SubSceneStreamingSystem>().Update();

                Assert.AreEqual(1, m_Manager.Debug.EntityCount);
            }

        }
    }
}
