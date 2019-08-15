using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Properties;
using Unity.Properties.Reflection;

namespace Unity.Entities
{
    public readonly struct EntityContainer
    {
        static EntityContainer()
        {
            PropertyBagResolver.Register(new EntityContainerPropertyBag());
            PropertyBagResolver.RegisterProvider(new ReflectedPropertyBagProvider());
        }

        internal readonly EntityManager EntityManager;
        internal readonly Entity Entity;
        internal readonly bool IsReadOnly;

        public int GetComponentCount() => EntityManager.GetComponentCount(Entity);

        public EntityContainer(EntityManager entityManager, Entity entity, bool readOnly = true)
        {
            EntityManager = entityManager;
            Entity = entity;
            IsReadOnly = readOnly;
        }
    }

    public class EntityContainerPropertyBag : PropertyBag<EntityContainer>
    {
        private struct EntityProperty : IProperty<EntityContainer, Entity>
        {
            public string GetName() => "Entity";

            public bool IsReadOnly => true;
            public bool IsContainer => true;
            public IPropertyAttributeCollection Attributes { get; }
            public Entity GetValue(ref EntityContainer container) => container.Entity;
            public void SetValue(ref EntityContainer container, Entity value)
                => throw new NotSupportedException("Property is ReadOnly");

            public EntityProperty(params Attribute[] attributes)
            {
                Attributes = new PropertyAttributeCollection(attributes);
            }
        }

        /// <summary>
        /// Dynamic property to handle returning all components from an entity.
        /// </summary>
        private struct ComponentsProperty : ICollectionProperty<EntityContainer, IEnumerable<object>>
        {
            private struct GetComponentDataCallback<TCallback> : IContainerTypeCallback
                where TCallback : ICollectionElementGetter<EntityContainer>
            {
                public TCallback Callback;
                public EntityContainer Container;
                public int Index;
                public int TypeIndex;
                public IPropertyAttributeCollection Attributes => null;

                public void Invoke<TComponent>()
                {
                    Callback.VisitProperty<ComponentDataProperty<TComponent>, TComponent>(new ComponentDataProperty<TComponent>(Index, TypeIndex, Container.IsReadOnly), ref Container);
                }
            }

            private struct GetSharedComponentDataCallback<TCallback> : IContainerTypeCallback
                where TCallback : ICollectionElementGetter<EntityContainer>
            {
                public TCallback Callback;
                public EntityContainer Container;
                public int Index;
                public int TypeIndex;
                public IPropertyAttributeCollection Attributes => null;

                public void Invoke<TComponent>()
                {
                    Callback.VisitProperty<SharedComponentDataProperty<TComponent>, TComponent>(new SharedComponentDataProperty<TComponent>(Index, TypeIndex), ref Container);
                }
            }

            private struct GetBufferElementDataCallback<TCallback> : IContainerTypeCallback
                where TCallback : ICollectionElementGetter<EntityContainer>
            {
                public TCallback Callback;
                public EntityContainer Container;
                public int Index;
                public int TypeIndex;

                public void Invoke<TBuffer>()
                {
                    Callback.VisitProperty<DynamicBufferProperty<TBuffer>, DynamicBufferContainer<TBuffer>>(new DynamicBufferProperty<TBuffer>(Index, TypeIndex, Container.IsReadOnly), ref Container);
                }
            }

            public struct ComponentDataProperty<TValue> : ICollectionElementProperty<EntityContainer, TValue>
            {
                private readonly int m_Index;
                private readonly int m_TypeIndex;
                private readonly bool m_IsReadOnly;

                public string GetName() => typeof(TValue).Name;
                public bool IsReadOnly => TypeManager.GetTypeInfo(m_TypeIndex).IsZeroSized || m_IsReadOnly;
                public bool IsContainer => true;
                public IPropertyAttributeCollection Attributes => null;
                public int Index => m_Index;

                public ComponentDataProperty(int index, int typeIndex, bool isReadOnly)
                {
                    m_Index = index;
                    m_TypeIndex = typeIndex;
                    m_IsReadOnly = isReadOnly;
                }

                public unsafe TValue GetValue(ref EntityContainer container)
                {
                    if (!TypeManager.GetTypeInfo(m_TypeIndex).IsZeroSized)
                    {
                        return Unsafe.AsRef<TValue>(container.EntityManager.GetComponentDataRawRO(container.Entity, m_TypeIndex));
                    }

                    return default;
                }

                public unsafe void SetValue(ref EntityContainer container, TValue value)
                {
                    if (TypeManager.GetTypeInfo(m_TypeIndex).IsZeroSized)
                    {
                        throw new InvalidOperationException("Property is ReadOnly");
                    }

                    Unsafe.Copy(container.EntityManager.GetComponentDataRawRW(container.Entity, m_TypeIndex), ref value);
                }
            }

            public struct SharedComponentDataProperty<TValue> : ICollectionElementProperty<EntityContainer, TValue>
            {
                private readonly int m_Index;
                private readonly int m_TypeIndex;

                public string GetName() => typeof(TValue).Name;
                public bool IsReadOnly => true;
                public bool IsContainer => true;
                public IPropertyAttributeCollection Attributes => null;
                public int Index => m_Index;

                public SharedComponentDataProperty(int index, int typeIndex)
                {
                    m_Index = index;
                    m_TypeIndex = typeIndex;
                }

                public TValue GetValue(ref EntityContainer container)
                {
                    var obj = container.EntityManager.GetSharedComponentData(container.Entity, m_TypeIndex);
                    return (TValue) obj;
                }

                public void SetValue(ref EntityContainer container, TValue value)
                {
                    throw new InvalidOperationException("Property is ReadOnly");
                }
            }

            public struct DynamicBufferProperty<TValue> : ICollectionElementProperty<EntityContainer, DynamicBufferContainer<TValue>>
            {
                private readonly int m_Index;
                private readonly int m_TypeIndex;
                private readonly bool m_IsReadOnly;

                public string GetName() => typeof(TValue).Name;
                public bool IsReadOnly => m_IsReadOnly;
                public bool IsContainer => true;
                public IPropertyAttributeCollection Attributes => null;
                public int Index => m_Index;

                public DynamicBufferProperty(int index, int typeIndex, bool isReadOnly)
                {
                    m_Index = index;
                    m_TypeIndex = typeIndex;
                    m_IsReadOnly = isReadOnly;
                }

                public unsafe DynamicBufferContainer<TValue> GetValue(ref EntityContainer container)
                {
                    var ptr = m_IsReadOnly 
                        ? container.EntityManager.GetBufferRawRO(container.Entity, m_TypeIndex)
                        : container.EntityManager.GetBufferRawRW(container.Entity, m_TypeIndex);
                    var len = container.EntityManager.GetBufferLength(container.Entity, m_TypeIndex);
                    return new DynamicBufferContainer<TValue>(ptr, len, Unsafe.SizeOf<TValue>());
                }

                public void SetValue(ref EntityContainer container, DynamicBufferContainer<TValue> value)
                    => throw new NotSupportedException("Property is ReadOnly");
            }

            public string GetName() => "Components";
            public bool IsReadOnly => true;
            public bool IsContainer => false;
            public IPropertyAttributeCollection Attributes => null;

            public IEnumerable<object> GetValue(ref EntityContainer container) => default;
            public void SetValue(ref EntityContainer container, IEnumerable<object> value) => throw new InvalidOperationException("Property is ReadOnly");
            public void Clear(ref EntityContainer container) => throw new InvalidOperationException("Property is ReadOnly");
            public int GetCount(ref EntityContainer container) => container.GetComponentCount();
            public void SetCount(ref EntityContainer container, int count)=> throw new InvalidOperationException("Property is ReadOnly");

            public void GetPropertyAtIndex<TGetter>(ref EntityContainer container, int index, ref ChangeTracker changeTracker, TGetter getter)
                where TGetter : ICollectionElementGetter<EntityContainer>
            {
                var typeIndex = container.EntityManager.GetComponentTypeIndex(container.Entity, index);
                var type = TypeManager.GetType(typeIndex);

                if (typeof(IComponentData).IsAssignableFrom(type))
                {
                    PropertyBagResolver.Resolve(type)?.Cast(new GetComponentDataCallback<TGetter>
                    {
                        Callback = getter,
                        Container = container,
                        Index = index,
                        TypeIndex = typeIndex
                    });
                }
                else if (typeof(ISharedComponentData).IsAssignableFrom(type))
                {
                    PropertyBagResolver.Resolve(type)?.Cast(new GetSharedComponentDataCallback<TGetter>()
                    {
                        Callback = getter,
                        Container = container,
                        Index = index,
                        TypeIndex = typeIndex
                    });
                }
                else if (typeof(IBufferElementData).IsAssignableFrom(type))
                {
                    PropertyBagResolver.Resolve(type)?.Cast(new GetBufferElementDataCallback<TGetter>
                    {
                        Callback = getter,
                        Container = container,
                        Index = index,
                        TypeIndex = typeIndex
                    });
                }
            }
        }

        private readonly EntityProperty m_Entity = new EntityProperty(new NonSerializedAttribute());
        private readonly ComponentsProperty m_Components = new ComponentsProperty();

        public override void Accept<TVisitor>(ref EntityContainer container, TVisitor visitor, ref ChangeTracker changeTracker)
        {
            visitor.VisitProperty<EntityProperty, EntityContainer, Entity>(m_Entity, ref container, ref changeTracker);
            visitor.VisitCollectionProperty<ComponentsProperty, EntityContainer, IEnumerable<object>>(m_Components, ref container, ref changeTracker);
        }

        public override bool FindProperty<TAction>(string name, ref EntityContainer container, ref ChangeTracker changeTracker, ref TAction action)
        {
            if (name.Equals("Components"))
            {
                action.VisitCollectionProperty<ComponentsProperty, IEnumerable<object>>(m_Components, ref container, ref changeTracker);
                return true;
            }

            return false;
        }
    }
}
