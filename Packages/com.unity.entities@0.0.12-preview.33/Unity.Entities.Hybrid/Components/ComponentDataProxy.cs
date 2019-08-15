using System;
using UnityEngine;

namespace Unity.Entities
{
    [Obsolete("ComponentDataWrapper has been renamed to ComponentDataProxy", true)]
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public abstract class ComponentDataWrapper<T> : ComponentDataProxyBase where T : struct, IComponentData
    {
    }


    public abstract class ComponentDataProxy<T> : ComponentDataProxyBase where T : struct, IComponentData
    {
        internal override void ValidateSerializedData()
        {
            ValidateSerializedData(ref m_SerializedData);
        }

        protected virtual void ValidateSerializedData(ref T serializedData) {}

        [SerializeField, WrappedComponentData]
        T m_SerializedData;

        public T Value
        {
            get
            {
                return m_SerializedData;
            }
            set
            {
                ValidateSerializedData(ref value);
                m_SerializedData = value;

                EntityManager entityManager;
                Entity entity;

                if (CanSynchronizeWithEntityManager(out entityManager, out entity))
                    UpdateComponentData(entityManager, entity);
            }
        }

        internal override ComponentType GetComponentType()
        {
            return ComponentType.ReadWrite<T>();
        }

        internal override void UpdateComponentData(EntityManager manager, Entity entity)
        {
            if (!ComponentType.ReadWrite<T>().IsZeroSized)
                manager.SetComponentData(entity, m_SerializedData);
        }

        internal override void UpdateSerializedData(EntityManager manager, Entity entity)
        {
            if (!ComponentType.ReadWrite<T>().IsZeroSized)
                m_SerializedData = manager.GetComponentData<T>(entity);
        }

        internal override int InsertSharedComponent(EntityManager manager)
        {
            throw new InvalidOperationException();
        }

        internal override void UpdateSerializedData(EntityManager manager, int sharedComponentIndex)
        {
            throw new InvalidOperationException();
        }
    }
}