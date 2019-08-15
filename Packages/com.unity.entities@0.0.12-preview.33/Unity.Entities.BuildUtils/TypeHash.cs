using System;
using System.Linq;
using System.Reflection;
using Mono.Cecil;

namespace Unity.Entities.BuildUtils
{
    public class TypeHash
    {
        // http://www.isthe.com/chongo/src/fnv/hash_64a.c
        // with basis and prime:
        const ulong kFNV1A64OffsetBasis = 14695981039346656037;
        const ulong kFNV1A64Prime = 1099511628211;

        public static ulong FNV1A64(string text)
        {
            ulong result = kFNV1A64OffsetBasis;
            foreach (var c in text)
            {
                result = kFNV1A64Prime * (result ^ (byte)(c & 255));
                result = kFNV1A64Prime * (result ^ (byte)(c >> 8));
            }
            return result;
        }

        public static ulong FNV1A64(int val)
        {
            ulong result = kFNV1A64OffsetBasis;
            unchecked
            {
                result = (((ulong)(val & 0x000000FF) >>  0) ^ result) * kFNV1A64Prime;
                result = (((ulong)(val & 0x0000FF00) >>  8) ^ result) * kFNV1A64Prime;
                result = (((ulong)(val & 0x00FF0000) >> 16) ^ result) * kFNV1A64Prime;
                result = (((ulong)(val & 0xFF000000) >> 24) ^ result) * kFNV1A64Prime;
            }

            return result;
        }

        public static ulong CombineFNV1A64(ulong hash, params ulong[] values)
        {
            foreach (var value in values)
            {
                hash ^= value;
                hash *= kFNV1A64Prime;
            }

            return hash;
        }

        public static ulong HashType(TypeDefinition typeDef, int fieldIndex = 0)
        {
            ulong hash = kFNV1A64OffsetBasis;

            foreach (var field in typeDef.Fields)
            {
                if (!field.IsStatic)
                {
                    hash = CombineFNV1A64(hash, FNV1A64(field.FieldType.FullName));
                    hash = CombineFNV1A64(hash, FNV1A64(fieldIndex));
                    ++fieldIndex;
                }
            }

            return hash;
        }

        public static ulong HashType(Type type, int fieldIndex = 0)
        {
            ulong hash = kFNV1A64OffsetBasis;

            foreach (var field in type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
            {
                if (!field.IsStatic)
                {
                    var fieldName = field.FieldType.FullName;
                    hash = CombineFNV1A64(hash, FNV1A64(fieldName));
                    hash = CombineFNV1A64(hash, FNV1A64(fieldIndex));
                    ++fieldIndex;
                }
            }

            return hash;
        }

        public static ulong HashVersionAttribute(TypeDefinition typeDef)
        {
            int version = 0;
            if (typeDef.CustomAttributes.Count > 0)
            {
                var versionAttribute = typeDef.CustomAttributes.FirstOrDefault(ca => ca.Constructor.DeclaringType.Name == "TypeVersionAttribute");
                if (versionAttribute != null)
                {
                    version = (int)versionAttribute.ConstructorArguments
                        .First(arg => arg.Type.Name == "Int32")
                        .Value;
                }
            }

            return FNV1A64(version);
        }

        private static unsafe ulong HashVersionAttribute(Type type)
        {
            int version = 0;
            if (type.CustomAttributes.Count() > 0)
            {
                var versionAttribute = type.CustomAttributes.FirstOrDefault(ca => ca.Constructor.DeclaringType.Name == "TypeVersionAttribute");
                if (versionAttribute != null)
                {
                    version = (int)versionAttribute.ConstructorArguments
                        .First(arg => arg.ArgumentType.Name == "Int32")
                        .Value;
                }
            }

            return FNV1A64(version);
        }

        public static ulong CalculateStableTypeHash(TypeDefinition typeDef)
        {
            ulong asmNameHash = FNV1A64(Assembly.CreateQualifiedName(typeDef.Module.Assembly.FullName, typeDef.FullName));
            ulong typeHash = HashType(typeDef);
            ulong versionHash = HashVersionAttribute(typeDef);

            return CombineFNV1A64(asmNameHash, typeHash, versionHash);
        }

        // Note: We do not use method overloading for Type/TypeDefinition because overloading the method would force users
        // of the method to require an assembly reference on System.Reflection AND Mono.Cecil
        public static ulong CalculateStableTypeHashRefl(Type type)
        {

            ulong asmNameHash = FNV1A64(type.AssemblyQualifiedName);
            ulong typeHash = HashType(type);
            ulong versionHash = HashVersionAttribute(type);

            return CombineFNV1A64(asmNameHash, typeHash, versionHash);
        }

        public static ulong CalculateMemoryOrdering(TypeDefinition typeDef)
        {
            if (typeDef == null || typeDef.IsEntityType())
            {
                return 0;
            }

            if (typeDef.CustomAttributes.Count > 0)
            {
                var forcedMemoryOrderAttribute = typeDef.CustomAttributes.FirstOrDefault(ca => ca.Constructor.DeclaringType.Name == "ForcedMemoryOrderingAttribute");
                if (forcedMemoryOrderAttribute != null)
                {
                    ulong memoryOrder = (ulong)forcedMemoryOrderAttribute.ConstructorArguments
                        // despite the field being a 'ulong', Mono.Cecil says it's a UInt64. Not a big issue but a possible inconsistency so we check for either
                        .First(arg => arg.Type.Name == "UInt64" || arg.Type.Name == "ulong")
                        .Value;

                    return memoryOrder;
                }
            }

            return CalculateStableTypeHash(typeDef);
        }

        // Note: We do not use method overloading for Type/TypeDefinition because overloading the method would force users
        // of the method to require an assembly reference on System.Reflection AND Mono.Cecil
        public static ulong CalculateMemoryOrderingRefl(Type type)
        {
            if (type == null || type.FullName == "Unity.Entities.Entity")
            {
                return 0;
            }

            if (type.CustomAttributes.Count() > 0)
            {
                var forcedMemoryOrderAttribute = type.CustomAttributes.FirstOrDefault(ca => ca.Constructor.DeclaringType.Name == "ForcedMemoryOrderingAttribute");
                if (forcedMemoryOrderAttribute != null)
                {
                    ulong memoryOrder = (ulong)forcedMemoryOrderAttribute.ConstructorArguments
                        .First(arg => arg.ArgumentType.Name == "UInt64" || arg.ArgumentType.Name == "ulong")
                        .Value;

                    return memoryOrder;
                }
            }

            return CalculateStableTypeHashRefl(type);
        }
    }
}
