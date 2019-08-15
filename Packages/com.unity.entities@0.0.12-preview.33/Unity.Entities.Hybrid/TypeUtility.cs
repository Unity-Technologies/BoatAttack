using System;
using System.Collections.Generic;
using System.Reflection;

namespace Unity.Entities
{
    static class TypeUtility
    {
        static readonly Dictionary<Type, Type> s_ComponentToProxy = new Dictionary<Type, Type>();
        static readonly HashSet<Assembly> s_VisitedAssemblies = new HashSet<Assembly>();
        static readonly List<string> s_ErrorAssemblyNames = new List<string>(8);

        public static Type GetProxyForDataType(Type componentDataType)
        {
            s_ErrorAssemblyNames.Clear();
            Type proxyType;
            if (!s_ComponentToProxy.TryGetValue(componentDataType, out proxyType))
            {
                foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
                {
                    if (s_VisitedAssemblies.Contains(assembly))
                        continue;

                    try
                    {
                        foreach (var type in assembly.GetTypes())
                        {
                            if (!typeof(ComponentDataProxyBase).IsAssignableFrom(type) || type.IsAbstract)
                                continue;

                            var t = type;
                            while (t.BaseType != typeof(ComponentDataProxyBase))
                                t = t.BaseType;
                            s_ComponentToProxy[t.GetGenericArguments()[0]] = type;
                        }
                    }
                    catch (ReflectionTypeLoadException)
                    {
                        s_ErrorAssemblyNames.Add(assembly.GetName().Name);
                    }

                    s_VisitedAssemblies.Add(assembly);
                }

                s_ComponentToProxy.TryGetValue(componentDataType, out proxyType);
            }
            if (proxyType == null && s_ErrorAssemblyNames.Count > 0)
                Debug.LogWarning($"Found no Proxy class for {proxyType}, but was also unable to load the following assemblies, so it may be in one of them.\n- {string.Join("\n- ", s_ErrorAssemblyNames)}");

            return proxyType;
        }
    }
}
