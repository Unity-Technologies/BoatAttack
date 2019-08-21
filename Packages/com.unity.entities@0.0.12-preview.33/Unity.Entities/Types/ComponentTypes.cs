using System;
using Unity.Collections;
using Unity.Mathematics;

namespace Unity.Entities
{
    public unsafe struct ComponentTypes
    {
        ResizableArray64Byte<int> m_sorted;

        public struct Masks
        {
            public UInt16 m_BufferMask;
            public UInt16 m_SystemStateComponentMask;
            public UInt16 m_SharedComponentMask;
            public UInt16 m_ZeroSizedMask;

            public bool IsSharedComponent(int index)
            {
                return (m_SharedComponentMask & (1 << index)) != 0;
            }

            public bool IsZeroSized(int index)
            {
                return (m_ZeroSizedMask & (1 << index)) != 0;
            }

            public int Buffers => math.countbits((UInt32) m_BufferMask);
            public int SystemStateComponents => math.countbits((UInt32) m_SystemStateComponentMask);
            public int SharedComponents => math.countbits((UInt32) m_SharedComponentMask);
            public int ZeroSizeds => math.countbits((UInt32) m_ZeroSizedMask);
        }

        public Masks m_masks;

        private void ComputeMasks()
        {
            for (var i = 0; i < m_sorted.Length; ++i)
            {
                var typeIndex = m_sorted[i];
                var mask = (UInt16) (1 << i);
                if (TypeManager.IsBuffer(typeIndex))
                    m_masks.m_BufferMask |= mask;
                if (TypeManager.IsSystemStateComponent(typeIndex))
                    m_masks.m_SystemStateComponentMask |= mask;
                if (TypeManager.IsSharedComponent(typeIndex))
                    m_masks.m_SharedComponentMask |= mask;
                if (TypeManager.IsZeroSized(typeIndex))
                    m_masks.m_ZeroSizedMask |= mask;
            }
        }

        public int Length
        {
            get => m_sorted.Length;
        }

        public int GetTypeIndex(int index)
        {
            return m_sorted[index];
        }

        public ComponentType GetComponentType(int index)
        {
            return TypeManager.GetType(m_sorted[index]);
        }

        public ComponentTypes(ComponentType a)
        {
            m_sorted = new ResizableArray64Byte<int>();
            m_masks = new Masks();
            m_sorted.Length = 1;
            var pointer = (int*) m_sorted.GetUnsafePointer();
            SortingUtilities.InsertSorted(pointer, 0, a.TypeIndex);
            ComputeMasks();
        }

        public ComponentTypes(ComponentType a, ComponentType b)
        {
            m_sorted = new ResizableArray64Byte<int>();
            m_masks = new Masks();
            m_sorted.Length = 2;
            var pointer = (int*) m_sorted.GetUnsafePointer();
            SortingUtilities.InsertSorted(pointer, 0, a.TypeIndex);
            SortingUtilities.InsertSorted(pointer, 1, b.TypeIndex);
            ComputeMasks();
        }

        public ComponentTypes(ComponentType a, ComponentType b, ComponentType c)
        {
            m_sorted = new ResizableArray64Byte<int>();
            m_masks = new Masks();
            m_sorted.Length = 3;
            var pointer = (int*) m_sorted.GetUnsafePointer();
            SortingUtilities.InsertSorted(pointer, 0, a.TypeIndex);
            SortingUtilities.InsertSorted(pointer, 1, b.TypeIndex);
            SortingUtilities.InsertSorted(pointer, 2, c.TypeIndex);
            ComputeMasks();
        }

        public ComponentTypes(ComponentType a, ComponentType b, ComponentType c, ComponentType d)
        {
            m_sorted = new ResizableArray64Byte<int>();
            m_masks = new Masks();
            m_sorted.Length = 4;
            var pointer = (int*) m_sorted.GetUnsafePointer();
            SortingUtilities.InsertSorted(pointer, 0, a.TypeIndex);
            SortingUtilities.InsertSorted(pointer, 1, b.TypeIndex);
            SortingUtilities.InsertSorted(pointer, 2, c.TypeIndex);
            SortingUtilities.InsertSorted(pointer, 3, d.TypeIndex);
            ComputeMasks();
        }

        public ComponentTypes(ComponentType a, ComponentType b, ComponentType c, ComponentType d, ComponentType e)
        {
            m_sorted = new ResizableArray64Byte<int>();
            m_masks = new Masks();
            m_sorted.Length = 5;
            var pointer = (int*) m_sorted.GetUnsafePointer();
            SortingUtilities.InsertSorted(pointer, 0, a.TypeIndex);
            SortingUtilities.InsertSorted(pointer, 1, b.TypeIndex);
            SortingUtilities.InsertSorted(pointer, 2, c.TypeIndex);
            SortingUtilities.InsertSorted(pointer, 3, d.TypeIndex);
            SortingUtilities.InsertSorted(pointer, 4, e.TypeIndex);
            ComputeMasks();
        }

        public ComponentTypes(ComponentType[] componentType)
        {
            m_sorted = new ResizableArray64Byte<int>();
            m_masks = new Masks();
            m_sorted.Length = componentType.Length;
            var pointer = (int*) m_sorted.GetUnsafePointer();
            for (var i = 0; i < componentType.Length; ++i)
                SortingUtilities.InsertSorted(pointer, i, componentType[i].TypeIndex);
            ComputeMasks();
        }
    }
}
