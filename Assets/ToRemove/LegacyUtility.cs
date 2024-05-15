using UnityEngine;
using System;
using System.Collections.Generic;

namespace LegacyUtility
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ManagerDefaultPrefabAttribute : Attribute
    {
        private string m_Prefab;

        public string prefab => m_Prefab;

        public ManagerDefaultPrefabAttribute(string prefabName)
        {
            m_Prefab = prefabName;
        }
    }

    public static class TypeUtility
    {
        public static Type[] GetConcreteTypes<T>()
        {
            List<Type> types = new List<Type>();
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                Type[] assemblyTypes = null;

                try
                {
                    assemblyTypes = assembly.GetTypes();
                }
                catch
                {
                    Debug.LogError($"Could not load types from assembly : {assembly.FullName}");
                }

                if (assemblyTypes != null)
                {
                    foreach (Type t in assemblyTypes)
                    {
                        if (typeof(T).IsAssignableFrom(t) && !t.IsAbstract)
                        {
                            types.Add(t);
                        }
                    }
                }

            }
            return types.ToArray();
        }
    }


    public abstract class Manager : MonoBehaviour
    {
        private static Dictionary<Type, Manager> s_Managers = new Dictionary<Type, Manager>();

        private static readonly Type[] kAllManagerTypes = TypeUtility.GetConcreteTypes<Manager>();

        public static bool TryGet<T>(out T manager) where T : Manager
        {
            manager = null;
            if (s_Managers.ContainsKey(typeof(T)))
            {
                manager = (T)s_Managers[typeof(T)];
                return true;
            }

            return false;
        }

        public static T Get<T>() where T : Manager
        {
            if (s_Managers.ContainsKey(typeof(T)))
            {
                return (T)s_Managers[typeof(T)];
            }

            Debug.LogError($"Manager of type '{typeof(T)}' could not be accessed. Check the excludedManagers list in your GameplayIngredientsSettings configuration file.");
            return null;
        }

        public static bool Has<T>() where T : Manager
        {
            return s_Managers.ContainsKey(typeof(T));
        }

        private static T GetCustomAttribute<T>(Type type) where T : Attribute
        {
            object[] attributes = type.GetCustomAttributes(typeof(T), true);

            if (attributes != null && attributes.Length > 0)
            {
                return (T)attributes[0];
            }
            else
            {
                return null;
            }
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void AutoCreateAll()
        {
            s_Managers.Clear();

            Type[] array = kAllManagerTypes;
            foreach (Type type in array)
            {
                Debug.Log("Manager : " + type.Name + " is being created");
                ManagerDefaultPrefabAttribute customAttribute = GetCustomAttribute<ManagerDefaultPrefabAttribute>(type);
                GameObject gameObject2;
                if (customAttribute != null)
                {
                    GameObject gameObject = Resources.Load<GameObject>(customAttribute.prefab);
                    if (gameObject == null)
                    {
                        gameObject = Resources.Load<GameObject>("Default_" + customAttribute.prefab);
                    }

                    if (!(gameObject != null))
                    {
                        Debug.LogError("Could not instantiate default prefab for " + type.ToString() + " : No prefab '" + customAttribute.prefab + "' found in resources folders. Ignoring...");
                        continue;
                    }

                    gameObject2 = Instantiate(gameObject);
                }
                else
                {
                    gameObject2 = new GameObject();
                    gameObject2.AddComponent(type);
                }

                gameObject2.name = type.Name;
                DontDestroyOnLoad(gameObject2);
                Manager value = (Manager)gameObject2.GetComponent(type);
                s_Managers.Add(type, value);
            }
        }
    }
}
