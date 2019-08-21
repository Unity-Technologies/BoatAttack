
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Unity.Entities.Editor
{
    internal static class EntityQueryGUI
    {

        internal static int CompareTypes(ComponentType x, ComponentType y)
        {
            var accessModeOrder = SortOrderFromAccessMode(x.AccessModeType).CompareTo(SortOrderFromAccessMode(y.AccessModeType));
            return accessModeOrder != 0 ? accessModeOrder : String.Compare(x.GetManagedType().Name, y.GetManagedType().Name, StringComparison.InvariantCulture);
        }

        private static int SortOrderFromAccessMode(ComponentType.AccessMode mode)
        {
            switch (mode)
            {
                case ComponentType.AccessMode.ReadOnly:
                    return 0;
                case ComponentType.AccessMode.ReadWrite:
                    return 1;
                case ComponentType.AccessMode.Exclude:
                    return 2;
                default:
                    throw new ArgumentException("Unrecognized AccessMode");
            }
        }

        public static string SpecifiedTypeName(Type type)
        {
            return SpecifiedTypeName(type, new Queue<Type>(type.GetGenericArguments()));
        }

        static string SpecifiedTypeName(Type type, Queue<Type> args)
        {
            var name = type.Name;

            if (type.IsGenericParameter)
            {
                return name;
            }
            if (type.IsNested)
            {
                name = $"{SpecifiedTypeName(type.DeclaringType, args)}.{name}";
            }
            if (type.IsGenericType)
            {
                var tickIndex = name.IndexOf('`');
                if (tickIndex > -1)
                    name = name.Remove(tickIndex);
                var genericTypes = type.GetGenericArguments();

                var genericTypeNames = new StringBuilder();
                for (var i = 0; i < genericTypes.Length && args.Count > 0; i++)
                {
                    if (i != 0)
                        genericTypeNames.Append(", ");
                    genericTypeNames.Append(SpecifiedTypeName(args.Dequeue()));
                }

                if (genericTypeNames.Length > 0)
                {
                    name = $"{name}<{genericTypeNames}>";
                }
            }

            return name;
        }

        internal static GUIStyle StyleForAccessMode(ComponentType.AccessMode mode, bool archetypeQueryMode)
        {
            switch (mode)
            {
                case ComponentType.AccessMode.ReadOnly:
                    return EntityDebuggerStyles.ComponentReadOnly;
                case ComponentType.AccessMode.ReadWrite:
                    return EntityDebuggerStyles.ComponentReadWrite;
                case ComponentType.AccessMode.Exclude:
                    return EntityDebuggerStyles.ComponentExclude;
                default:
                    throw new ArgumentException("Unrecognized access mode");
            }
        }
    }
}
