using System;
using UnityEngine;

namespace Unity.Entities
{
    [Obsolete("SharedComponentDataWrapper has been renamed to SharedComponentDataProxy", true)]
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public abstract class SharedComponentDataWrapper<T> : ComponentDataProxyBase where T : struct, ISharedComponentData
    {
    }


    public abstract class SharedComponentDataProxy<T> : ComponentDataProxyBase where T : struct, ISharedComponentData
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
            manager.SetSharedComponentData(entity, m_SerializedData);
        }

        internal override void UpdateSerializedData(EntityManager manager, Entity entity)
        {
            m_SerializedData = manager.GetSharedComponentData<T>(entity);
        }

        internal override int InsertSharedComponent(EntityManager manager)
        {
            return manager.ManagedComponentStore.InsertSharedComponent(m_SerializedData);
        }

        internal override void UpdateSerializedData(EntityManager manager, int sharedComponentIndex)
        {
            m_SerializedData = manager.ManagedComponentStore.GetSharedComponentData<T>(sharedComponentIndex);
        }
    }
}