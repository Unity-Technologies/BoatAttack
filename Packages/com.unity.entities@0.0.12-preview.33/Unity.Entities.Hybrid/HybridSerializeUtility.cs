using System;
using Unity.Collections;
using UnityEditor;
using UnityEngine;

namespace Unity.Entities.Serialization
{
    public class SerializeUtilityHybrid
    {
        public static void Serialize(EntityManager manager, BinaryWriter writer, out GameObject sharedData)
        {
            int[] sharedComponentIndices;
            SerializeUtility.SerializeWorld(manager, writer, out sharedComponentIndices);
            sharedData = SerializeSharedComponents(manager, sharedComponentIndices);
        }

        public static void Serialize(EntityManager manager, BinaryWriter writer, out GameObject sharedData, NativeArray<EntityRemapUtility.EntityRemapInfo> entityRemapInfos)
        {
            int[] sharedComponentIndices;
            SerializeUtility.SerializeWorld(manager, writer, out sharedComponentIndices, entityRemapInfos);
            sharedData = SerializeSharedComponents(manager, sharedComponentIndices);
        }

        public static void Deserialize(EntityManager manager, BinaryReader reader, GameObject sharedData)
        {
            int sharedComponentCount = DeserializeSharedComponents(manager, sharedData, "");
            var transaction = manager.BeginExclusiveEntityTransaction();
            SerializeUtility.DeserializeWorld(transaction, reader, sharedComponentCount);
            ReleaseSharedComponents(transaction, sharedComponentCount);
            manager.EndExclusiveEntityTransaction();
        }

        public static void ReleaseSharedComponents(ExclusiveEntityTransaction transaction, int sharedComponentCount)
        {
            // Chunks have now taken over ownership of the shared components (reference counts have been added)
            // so remove the ref that was added on deserialization
            for (int i = 0; i < sharedComponentCount; ++i)
            {
                transaction.ManagedComponentStore.RemoveReference(i+1);
            }
        }

        public static GameObject SerializeSharedComponents(EntityManager manager, int[] sharedComponentIndices)
        {
            if (sharedComponentIndices.Length == 0)
                return null;

            var go = new GameObject("SharedComponents");
            go.SetActive(false);

            for (int i = 0; i != sharedComponentIndices.Length; i++)
            {
                var sharedData = manager.ManagedComponentStore.GetSharedComponentDataNonDefaultBoxed(sharedComponentIndices[i]);

                var proxyType = TypeUtility.GetProxyForDataType(sharedData.GetType());
                if (proxyType == null)
                    throw new ArgumentException($"{sharedData.GetType()} has no valid proxy shared component data. Please create one..");
                if (Attribute.IsDefined(proxyType, typeof(DisallowMultipleComponent), true))
                    throw new ArgumentException($"{proxyType} is marked with {typeof(DisallowMultipleComponent)}, but current implementation of {nameof(SerializeSharedComponents)} serializes all shared components on a single GameObject.");

                var com = go.AddComponent(proxyType) as ComponentDataProxyBase;
                #if UNITY_EDITOR
                if (!EditorUtility.IsPersistent(MonoScript.FromMonoBehaviour(com)))
                    throw new ArgumentException($"{proxyType.Name} must be defined in a file named {proxyType.Name}.cs");
                #endif
                com.UpdateSerializedData(manager, sharedComponentIndices[i]);
            }

            
            return go;
        }

        public static int DeserializeSharedComponents(EntityManager manager, GameObject gameobject, string debugSceneName)
        {
            if (gameobject == null)
                return 0;

            manager.ManagedComponentStore.PrepareForDeserialize();

            var sharedData = gameobject.GetComponents<ComponentDataProxyBase>();


            for (int i = 0; i != sharedData.Length; i++)
            {
#pragma warning disable 219
                int index = sharedData[i].InsertSharedComponent(manager);
#pragma warning restore 219
#if ENABLE_UNITY_COLLECTIONS_CHECKS
                if (index != i + 1)
                {
                    var newComponent = sharedData[i];
                    object existingComponent = null;
                    if (index != 0)
                    {
                        existingComponent = manager.ManagedComponentStore.GetSharedComponentDataNonDefaultBoxed(index);
                        throw new ArgumentException($"While loading {debugSceneName}. Shared Component {i} was inserted but got a different index {index} at load time than at build time. \n{newComponent} vs {existingComponent}");
                    }
                    else
                    {
                        throw new ArgumentException($"While loading {debugSceneName}. Shared Component {i} was inserted index 0 meaning default value. It should not have been serialized in the first place. \n{newComponent}");
                    }
                }
#endif
            }

            return sharedData.Length;
        }
    }
}
