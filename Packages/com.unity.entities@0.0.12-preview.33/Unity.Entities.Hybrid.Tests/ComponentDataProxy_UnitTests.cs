using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using UnityEngine;

namespace Unity.Entities.Tests
{
    class ComponentDataProxy_UnitTests
    {
        static bool IsSubclassOfOpenGenericType(Type type, Type genericType)
        {
            if (type.IsSubclassOf(genericType))
                return true;
            while (type != null && type != typeof(object))
            {
                var cur = type.IsGenericType ? type.GetGenericTypeDefinition() : type;
                if (genericType == cur)
                    return true;
                type = type.BaseType;
            }
            return false;
        }

        static IEnumerable<Type> GetAllSubTypes(Type genericType)
        {
            var result = new List<Type>();
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                try
                {
                    result.AddRange(
                        assembly.GetTypes()
                            .Where(t =>
                                !t.IsAbstract
                                && !t.IsGenericType
                                && IsSubclassOfOpenGenericType(t, genericType)
                            )
                    );
                }
                // ignore if error loading some type from a dll
                catch (ReflectionTypeLoadException) { }
            }
            return result;
        }

        static readonly IEnumerable k_AllComponentDataProxyTypes =
            GetAllSubTypes(typeof(ComponentDataProxy<>)).Select(t => new TestCaseData(t).SetName(t.FullName));

        [TestCaseSource(nameof(k_AllComponentDataProxyTypes))]
        public void AllComponentDataProxies_DisallowMultipleComponent(Type type)
        {
            Assert.That(Attribute.IsDefined(type, typeof(DisallowMultipleComponent)), Is.True);
        }

        static readonly IEnumerable k_AllSharedComponentDataProxyTypes =
            GetAllSubTypes(typeof(SharedComponentDataProxy<>))
                .Where(t => t != typeof(MockSharedDisallowMultipleProxy)) // ignore mock for other test
                .Select(t => new TestCaseData(t).SetName(t.FullName));

        // currently enforced due to implementation of SerializeUtilityHybrid
        // ideally all types should ultimately have DisallowMultipleComponent
        [TestCaseSource(nameof(k_AllSharedComponentDataProxyTypes))]
        public void NoSharedComponentDataProxies_DisallowMultipleComponent(Type type)
        {
            Assert.That(Attribute.IsDefined(type, typeof(DisallowMultipleComponent)), Is.False);
        }

        static readonly IEnumerable k_AllDynamicBufferProxyTypes =
            GetAllSubTypes(typeof(DynamicBufferProxy<>)).Select(t => new TestCaseData(t).SetName(t.FullName));

        [TestCaseSource(nameof(k_AllDynamicBufferProxyTypes))]
        public void AllDynamicBufferProxies_DisallowMultipleComponent(Type type)
        {
            Assert.That(Attribute.IsDefined(type, typeof(DisallowMultipleComponent)), Is.True);
        }
    }
}
