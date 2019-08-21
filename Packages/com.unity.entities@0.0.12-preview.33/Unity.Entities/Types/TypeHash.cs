#if !NET_DOTS
using System;
using System.Linq;
using System.Reflection;

namespace Unity.Entities
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

        public static ulong CalculateStableTypeHash(Type type)
        {

            ulong asmNameHash = FNV1A64(type.AssemblyQualifiedName);
            ulong typeHash = HashType(type);
            ulong versionHash = HashVersionAttribute(type);

            return CombineFNV1A64(asmNameHash, typeHash, versionHash);
        }

        public static ulong CalculateMemoryOrdering(Type type)
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

            return CalculateStableTypeHash(type);
        }
    }
}
#endif
