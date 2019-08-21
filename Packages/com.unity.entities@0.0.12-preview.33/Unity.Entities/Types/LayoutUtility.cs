using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace Unity.Entities
{
#if !NET_DOTS
    public struct SOAFieldInfo
    {
        public ushort Size;
        public ushort Offset;
    }

    public struct LayoutUtilityManaged
    {
        public static NativeArray<SOAFieldInfo> CreateDescriptor(Type type, Allocator allocator)
        {
            var fieldList = new List<SOAFieldInfo>();
            FindFields(fieldList, type, 0, 1);
            return new NativeArray<SOAFieldInfo>(fieldList.ToArray(), allocator);
        }

        private static void FindFields(List<SOAFieldInfo> result, Type type, int parentOffset, int outerFixedArrayLength)
        {
            if (!type.IsValueType)
                throw new ArgumentException($"Only value types are supported");

            if (type.IsGenericTypeDefinition)
                throw new ArgumentException($"Only concrete types are supported");

            var fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            foreach (var field in fields)
            {
                int offset = parentOffset + UnsafeUtility.GetFieldOffset(field);

                if (field.FieldType.IsPrimitive || field.FieldType.IsPointer)
                {
                    int sizeOf = -1;

                    if (field.FieldType.IsPointer)
                        sizeOf = UnsafeUtility.SizeOf<IntPtr>();
                    else
                        sizeOf = UnsafeUtility.SizeOf(field.FieldType);

                    switch (sizeOf)
                    {
                        case 1: break;
                        case 2: break;
                        case 4: break;
                        case 8: break;
                        default: throw new ArgumentException($"Field {type}.{field} has an unsupported size {sizeOf}");
                    }

                    if (offset + sizeOf * outerFixedArrayLength > ushort.MaxValue)
                        throw new ArgumentException($"Structures larger than 64k are not supported");

                    for (int i = 0; i < outerFixedArrayLength; ++i)
                    {
                        result.Add(new SOAFieldInfo {Offset = (ushort) offset, Size = (ushort) sizeOf});
                        offset += sizeOf;
                    }
                }
                else
                {
                    int fixedArrayLength = 1;
                    var fixedAttr = field.GetCustomAttribute<FixedBufferAttribute>();

                    if (fixedAttr != null)
                    {
                        fixedArrayLength = fixedAttr.Length;
                    }

                    FindFields(result, field.FieldType, offset, fixedArrayLength);
                }
            }
        }
    }

    /// <summary>
    /// Low-level utility functions for AOS->SOA (scatter) and SOA->AOS (gather) conversions.
    /// </summary>
    public struct LayoutUtility
    {
        /// <summary>
        /// Gather AOS data from fully parallel arrays of fields.
        /// </summary>
        /// <param name="fields">Struct type descriptor</param>
        /// <param name="sourceBaseAddress">Pointer to first byte of source SOA array</param>
        /// <param name="target">Pointer to target AOS struct instance to be gathered into</param>
        /// <param name="sourceIndex">The index of the SOA element to be gathered</param>
        /// <param name="sourceArraySize">The number of elements in the SOA data</param>
        public static unsafe void GatherFullSOA(NativeArray<SOAFieldInfo> fields, byte* sourceBaseAddress, void* target, int sourceIndex, int sourceArraySize)
        {
            byte* sourceRow = sourceBaseAddress;

            for (int fieldIndex = 0; fieldIndex < fields.Length; ++fieldIndex)
            {
                var fieldSize = fields[fieldIndex].Size;
                var fieldOffset = fields[fieldIndex].Offset;

                byte* source = sourceRow + fieldSize * sourceIndex;
                MiniMemCpy((byte*)target + fieldOffset, source, fieldSize);

                sourceRow += sourceArraySize * fieldSize;
            }
        }

        public static unsafe void ScatterFullSOA(NativeArray<SOAFieldInfo> fields, byte* targetBaseAddress, void* source, int targetIndex, int targetArraySize)
        {
            byte* targetRow = targetBaseAddress;

            for (int fieldIndex = 0; fieldIndex < fields.Length; ++fieldIndex)
            {
                var fieldSize = fields[fieldIndex].Size;
                var fieldOffset = fields[fieldIndex].Offset;

                byte* target = targetRow + fieldSize * targetIndex;
                MiniMemCpy(target, (byte*)source + fieldOffset, fieldSize);

                targetRow += targetArraySize * fieldSize;
            }
        }

        public static unsafe void GatherChunkedSOA8(NativeArray<SOAFieldInfo> fields, int fieldSizeSum, byte* sourceBaseAddress, void* target, int sourceIndex)
        {
            int packetIndex = sourceIndex >> 3;
            int packetOffset = sourceIndex & 7;
            int packetSizeBytes = fieldSizeSum * 8;

            byte* sourceRow = sourceBaseAddress + packetIndex * packetSizeBytes;

            for (int fieldIndex = 0; fieldIndex < fields.Length; ++fieldIndex)
            {
                var fieldSize = fields[fieldIndex].Size;
                var fieldOffset = fields[fieldIndex].Offset;

                byte* source = sourceRow + fieldSize * packetOffset;
                MiniMemCpy((byte*)target + fieldOffset, source, fieldSize);

                sourceRow += 8 * fieldSize;
            }
        }

        public static unsafe void ScatterChunkedSOA8(NativeArray<SOAFieldInfo> fields, int fieldSizeSum, byte* targetBaseAddress, void* source, int targetIndex)
        {
            int packetIndex = targetIndex >> 3;
            int packetOffset = targetIndex & 7;
            int packetSizeBytes = fieldSizeSum * 8;

            byte* targetRow = targetBaseAddress + packetIndex * packetSizeBytes;

            for (int fieldIndex = 0; fieldIndex < fields.Length; ++fieldIndex)
            {
                var fieldSize = fields[fieldIndex].Size;
                var fieldOffset = fields[fieldIndex].Offset;

                byte* target = targetRow + fieldSize * packetOffset;
                MiniMemCpy(target, (byte*)source + fieldOffset, fieldSize);

                targetRow += 8 * fieldSize;
            }
        }

        private static unsafe void MiniMemCpy(byte* target, byte* source, ushort fieldSize)
        {
            switch (fieldSize)
            {
                case 1: *target = *source; break;
                case 2: *(ushort*)target = *(ushort*)source; break;
                case 4: *(uint*)target = *(uint*)source; break;
                case 8: *(ulong*)target = *(ulong*)source; break;
            }
        }
    }

#endif
}
