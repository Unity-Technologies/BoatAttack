using System;
using System.Collections.Generic;
using Unity.Properties;

namespace Unity.Entities
{
    public interface IDynamicBufferContainer
    {
        Type ElementType { get; }
    }

    public struct DynamicBufferContainer<T> : IDynamicBufferContainer
    {
        static DynamicBufferContainer()
        {
            PropertyBagResolver.Register(new PropertyBag());
        }

        private readonly unsafe byte* m_Buffer;
        private readonly int m_Length;
        private readonly int m_Size;

        public int Length => m_Length;

        public Type ElementType => typeof(T);

        public unsafe DynamicBufferContainer(void* buffer, int length, int size)
        {
            m_Buffer = (byte*) buffer;
            m_Length = length;
            m_Size = size;
        }

        private class PropertyBag : PropertyBag<DynamicBufferContainer<T>>
        {
            private struct ElementsProperty : ICollectionProperty<DynamicBufferContainer<T>, IEnumerable<T>>
            {
                public string GetName() => "Elements";
                public bool IsReadOnly => true;
                public bool IsContainer => false;
                public IPropertyAttributeCollection Attributes => null;

                public IEnumerable<T> GetValue(ref DynamicBufferContainer<T> container) => default;
                public void SetValue(ref DynamicBufferContainer<T> container, IEnumerable<T> value) => throw new InvalidOperationException("Property is ReadOnly");
                public int GetCount(ref DynamicBufferContainer<T> container) => container.Length;
                public void SetCount(ref DynamicBufferContainer<T> container, int count) => throw new InvalidOperationException("Property is ReadOnly");
                public void Clear(ref DynamicBufferContainer<T> container) => throw new InvalidOperationException("Property is ReadOnly");

                public void GetPropertyAtIndex<TGetter>(ref DynamicBufferContainer<T> container, int index, ref ChangeTracker changeTracker, TGetter getter) where TGetter : ICollectionElementGetter<DynamicBufferContainer<T>>
                {
                    getter.VisitProperty<BufferElementProperty, T>(new BufferElementProperty { Index = index }, ref container);
                }
            }

            private struct BufferElementProperty : ICollectionElementProperty<DynamicBufferContainer<T>, T>
            {
                public string GetName() => $"[{Index}]";

                public int Index { get; internal set; }
                public bool IsReadOnly => false;
                public bool IsContainer => true;
                public IPropertyAttributeCollection Attributes => null;

                public unsafe T GetValue(ref DynamicBufferContainer<T> container)
                {
                    var ptr = container.m_Buffer + container.m_Size * Index;
                    return System.Runtime.CompilerServices.Unsafe.AsRef<T>(ptr);
                }

                public unsafe void SetValue(ref DynamicBufferContainer<T> container, T value)
                {
                    var ptr = container.m_Buffer + container.m_Size * Index;
                    System.Runtime.CompilerServices.Unsafe.Copy(ptr, ref value);
                }
            }

            private readonly ElementsProperty m_Elements = new ElementsProperty();

            public override void Accept<TVisitor>(ref DynamicBufferContainer<T> container, TVisitor visitor, ref ChangeTracker changeTracker)
            {
                visitor.VisitCollectionProperty<ElementsProperty, DynamicBufferContainer<T>, IEnumerable<T>>(m_Elements, ref container, ref changeTracker);
            }

            public override bool FindProperty<TAction>(string name, ref DynamicBufferContainer<T> container, ref ChangeTracker changeTracker, ref TAction action)
            {
                if (name.Equals(typeof(T).Name))
                {
                    action.VisitCollectionProperty<ElementsProperty, IEnumerable<T>>(m_Elements, ref container, ref changeTracker);
                    return true;
                }

                return false;
            }
        }
    }
}
