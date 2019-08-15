using System;
using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;

namespace Unity.Entities.BuildUtils
{
    public static class MonoExtensions
    {
        public static bool IsCppBasicType(this TypeDefinition type)
        {
            return type.MetadataType == MetadataType.Boolean || type.MetadataType == MetadataType.Void
                || type.MetadataType == MetadataType.SByte || type.MetadataType == MetadataType.Byte
                || type.MetadataType == MetadataType.Int16 || type.MetadataType == MetadataType.UInt16 || type.MetadataType == MetadataType.Char
                || type.MetadataType == MetadataType.Int32 || type.MetadataType == MetadataType.UInt32
                || type.MetadataType == MetadataType.Int64 || type.MetadataType == MetadataType.UInt64
                || type.MetadataType == MetadataType.Single || type.MetadataType == MetadataType.Double
                || type.MetadataType == MetadataType.IntPtr || type.MetadataType == MetadataType.UIntPtr;
        }

        public static Type GetSystemReflectionType(this TypeReference type)
        {
            return Type.GetType(type.GetReflectionName(), true);
        }

        public static string GetReflectionName(this TypeReference type)
        {
            if (type.IsGenericInstance)
            {
                var genericInstance = (GenericInstanceType)type;
                return string.Format("{0}.{1}[{2}]", genericInstance.Namespace, type.Name,
                    String.Join(",", genericInstance.GenericArguments.Select(p => p.GetReflectionName()).ToArray()));
            }

            return type.FullName;
        }

        public static TypeReference DynamicArrayElementType(this TypeReference typeRef)
        {
            var type = typeRef.Resolve();

            if (!type.IsDynamicArray())
                throw new ArgumentException("Expected DynamicArray type reference.");

            GenericInstanceType genericInstance = (GenericInstanceType)typeRef;
            return genericInstance.GenericArguments[0];
        }

        public static TypeDefinition FixedSpecialType(this TypeReference typeRef)
        {
            TypeDefinition type = typeRef.Resolve();
            if (type.MetadataType == MetadataType.IntPtr) return type.Module.TypeSystem.IntPtr.Resolve();
            if (type.MetadataType == MetadataType.Void) return type.Module.TypeSystem.Void.Resolve();
            if (type.MetadataType == MetadataType.String) return type.Module.TypeSystem.String.Resolve();
            if (IsCppBasicType(type)) return type;
            else return null;
        }

        public static bool IsStructValueType(this TypeReference type)
        {
            if (!type.IsValueType)
                return false;
            if (type.Resolve().IsEnum || type.IsPrimitive)
                return false;
            if (type.IsDynamicArray())
                return false;
            if (type.FixedSpecialType() != null)
                return false;
            if (type.MetadataType == MetadataType.IntPtr)
                return false;
            return true;
        }

        public static bool IsStructValueType(this TypeDefinition type)
        {
            if (!type.IsValueType)
                return false;
            if (type.IsEnum || type.IsPrimitive)
                return false;
            if (type.FixedSpecialType() != null)
                return false;
            if (type.IsComponentType())
                return false;
            if (type.MetadataType == MetadataType.IntPtr)
                return false;
            return true;
        }

        public static bool IsEntityType(this TypeReference typeRef)
        {
            return (typeRef.FullName == "Unity.Entities.Entity");
        }

        public static bool IsManagedType(this TypeReference typeRef)
        {
            // We must check this before calling Resolve() as cecil loses this property otherwise
            if (typeRef.IsPointer)
                return false;

            if (typeRef.IsArray || typeRef.IsGenericParameter)
                return true;

            var type = typeRef.Resolve();

            if (type.IsDynamicArray())
                return true;

            TypeDefinition fixedSpecialType = type.FixedSpecialType();
            if (fixedSpecialType != null)
            {
                if (fixedSpecialType.MetadataType == MetadataType.String)
                    return true;
                return false;
            }

            if (type.IsEnum)
                return false;

            if (type.IsValueType)
            {
                // if none of the above check the type's fields
                foreach (var field in type.Fields)
                {
                    if (field.IsStatic)
                        continue;

                    if (field.FieldType.IsManagedType())
                        return true;
                }

                return false;
            }

            return true;
        }


        public static bool IsComplex(this TypeReference typeRef)
        {
            // We must check this before calling Resolve() as cecil loses this property otherwise
            if (typeRef.IsPointer)
                return false;

            var type = typeRef.Resolve();

            if (TypeUtils.ValueTypeIsComplex[0].ContainsKey(type))
                return TypeUtils.ValueTypeIsComplex[0][type];

            if (type.IsDynamicArray())
                return true;

            TypeDefinition fixedSpecialType = type.FixedSpecialType();
            if (fixedSpecialType != null)
            {
                if (fixedSpecialType.MetadataType == MetadataType.String)
                    return true;
                return false;
            }

            if (type.IsEnum)
                return false;

            TypeUtils.PreprocessTypeFields(type, 0);

            return TypeUtils.ValueTypeIsComplex[0][type];
        }

        public static bool IsPodType(this TypeReference typeRef)
        {
            TypeDefinition type = typeRef.Resolve();
            if (type.IsCppBasicType() || type.IsEnum) return true;

            foreach (var f in type.Fields)
            {
                if (f.FieldType.MetadataType == MetadataType.String || f.FieldType.IsDynamicArray())
                    return false;
                bool recursiveIsPodType = IsPodType(f.FieldType.Resolve());
                if (!recursiveIsPodType)
                    return false;
            }

            return true;
        }

        public static bool IsDynamicArray(this TypeReference type)
        {
            return type.Name.StartsWith("DynamicArray`");
        }

        public static bool IsComponentType(this TypeReference typeRef)
        {
            if (!typeRef.IsValueType || typeRef.IsPrimitive)
                return false;

            return typeRef.Resolve().Interfaces.Any(i => i.InterfaceType.Name == "IComponentData") ||
                   IsSharedComponentType(typeRef) ||
                   IsSystemStateComponentType(typeRef) ||
                   IsBufferElementComponentType(typeRef);
        }

        public static bool IsBufferElementComponentType(this TypeReference typeRef)
        {
            if (!typeRef.IsValueType || typeRef.IsPrimitive)
                return false;

            return typeRef.Resolve().Interfaces.Any(i => i.InterfaceType.Name == "IBufferElementData");
        }

        public static bool IsSharedComponentType(this TypeReference typeRef)
        {
            if (!typeRef.IsValueType || typeRef.IsPrimitive)
                return false;

            return typeRef.Resolve().Interfaces.Any(i => i.InterfaceType.Name == "ISharedComponentData");
        }

        public static bool IsSystemStateComponentType(this TypeReference typeRef)
        {
            if (!typeRef.IsValueType || typeRef.IsPrimitive)
                return false;

            return typeRef.Resolve().Interfaces.Any(i => i.InterfaceType.Name == "ISystemStateComponentData");
        }

        public static bool IsSystemType(this TypeDefinition type)
        {
            if (!type.IsClass)
                return false;

            return type.Interfaces.Any(i => i.InterfaceType.Name == "IComponentSystem");
        }

        public static bool IsSystemFenceType(this TypeDefinition type)
        {
            if (!type.IsClass)
                return false;

            return type.Interfaces.Any(i => i.InterfaceType.Name == "IComponentSystemFence");
        }

        public static TypeDefinition[] GetSystemRunsBefore(this TypeDefinition type)
        {
            var deps = new List<TypeDefinition>();
            foreach (var attr in type.CustomAttributes)
            {
                if (attr.AttributeType.Name == "UpdateBeforeAttribute")
                {
                    TypeReference reference = (TypeReference)attr.ConstructorArguments[0].Value;
                    deps.Add(reference.Resolve());
                }
            }

            return deps.ToArray();
        }

        public static TypeDefinition[] GetSystemRunsAfter(this TypeDefinition type)
        {
            var deps = new List<TypeDefinition>();
            foreach (var attr in type.CustomAttributes)
            {
                if (attr.AttributeType.Name == "UpdateAfterAttribute")
                {
                    TypeReference reference = (TypeReference)attr.ConstructorArguments[0].Value;
                    deps.Add(reference.Resolve());
                }
            }

            return deps.ToArray();
        }

        public static ulong CalculateStableTypeHash(this TypeDefinition typeDef)
        {
            return TypeHash.CalculateStableTypeHash(typeDef);
        }

        public static ulong CalculateMemoryOrdering(this TypeDefinition typeDef)
        {
            return TypeHash.CalculateMemoryOrdering(typeDef);
        }
    }
}
