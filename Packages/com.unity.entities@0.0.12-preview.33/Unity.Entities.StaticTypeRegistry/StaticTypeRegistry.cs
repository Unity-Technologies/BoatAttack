using System;

namespace Unity.Entities.StaticTypeRegistry
{
    static internal unsafe class StaticTypeRegistry
    {
#pragma warning disable 0649
        // This field will be generated in the replacement assembly
        //static public readonly TypeManager.TypeInfo[] TypeInfos;

        static public readonly Type[] Types;
        static public readonly string[] TypeNames;  // Populated in non-release builds
        static public readonly int[] EntityOffsets;
        static public readonly int[] BlobAssetReferenceOffsets;
        static public readonly int[] WriteGroups;

        static public readonly Type[] Systems;
        static public readonly bool[] SystemIsGroup;
        static public readonly string[] SystemName;  // Populated in non-release builds
#pragma warning restore 0649

        public static void RegisterStaticTypes() {
            throw new NotImplementedException("This function should have been replaced by the TypeRegGen build step. Ensure TypeRegGen.exe is generating a new Unity.Entities.StaticTypeRegistry assembly.");
        }

        public static object CreateSystem(Type systemType)
        {
            throw new NotImplementedException("This function should have been replaced by the TypeRegGen build step. Ensure TypeRegGen.exe is generating a new Unity.Entities.StaticTypeRegistry assembly.");
        }

        public static Attribute[] GetSystemAttributes(Type systemType)
        {
            throw new NotImplementedException("This function should have been replaced by the TypeRegGen build step. Ensure TypeRegGen.exe is generating a new Unity.Entities.StaticTypeRegistry assembly.");
        }

        public static unsafe object ConstructComponentFromBuffer(int typeIndex, void* data)
        {
            throw new NotImplementedException("This function should have been replaced by the TypeRegGen build step. Ensure TypeRegGen.exe is generating a new Unity.Entities.StaticTypeRegistry assembly.");
        }

        public static bool Equals(void* lhs, void* rhs, int typeIndex)
        {
            throw new NotImplementedException("This function should have been replaced by the TypeRegGen build step. Ensure TypeRegGen.exe is generating a new Unity.Entities.StaticTypeRegistry assembly.");
        }

        public static bool Equals(object lhs, object rhs, int typeIndex)
        {
            throw new NotImplementedException("This function should have been replaced by the TypeRegGen build step. Ensure TypeRegGen.exe is generating a new Unity.Entities.StaticTypeRegistry assembly.");
        }

        public static bool Equals(object lhs, void* rhs, int typeIndex)
        {
            throw new NotImplementedException("This function should have been replaced by the TypeRegGen build step. Ensure TypeRegGen.exe is generating a new Unity.Entities.StaticTypeRegistry assembly.");
        }

        public static int GetHashCode(void* val, int typeIndex)
        {
            throw new NotImplementedException("This function should have been replaced by the TypeRegGen build step. Ensure TypeRegGen.exe is generating a new Unity.Entities.StaticTypeRegistry assembly.");
        }

        public static int BoxedGetHashCode(object val, int typeIndex)
        {
            throw new NotImplementedException("This function should have been replaced by the TypeRegGen build step. Ensure TypeRegGen.exe is generating a new Unity.Entities.StaticTypeRegistry assembly.");
        }
    }
}
