using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.Entities
{
    public abstract class DynamicBufferProxy<T> : ComponentDataProxyBase where T : struct, IBufferElementData
    {
        internal override void ValidateSerializedData()
        {
            ValidateSerializedData(m_SerializedData);
        }

        protected virtual void ValidateSerializedData(List<T> serializedData) {}

        [SerializeField]
        List<T> m_SerializedData = new List<T>();

        public IEnumerable<T> Value { get { return m_SerializedData; } }

        public void SetValue(IReadOnlyList<T> value)
        {
            m_SerializedData.Clear();
            if (value == null)
                return;
            if (m_SerializedData.Capacity < value.Count)
                m_SerializedData.Capacity = value.Count;
            for (int i = 0, count = value.Count; i < count; ++i)
                m_SerializedData.Add(value[i]);
            ValidateSerializedData(m_SerializedData);

            EntityManager entityManager;
            Entity entity;

            if (CanSynchronizeWithEntityManager(out entityManager, out entity))
                UpdateComponentData(entityManager, entity);
        }

        internal override ComponentType GetComponentType()
        {
            return ComponentType.ReadWrite<T>();
        }

        internal override void UpdateComponentData(EntityManager manager, Entity entity)
        {
            var buffer = manager.GetBuffer<T>(entity);
            buffer.Clear();
            foreach (var element in m_SerializedData)
                buffer.Add(element);
        }

        internal override void UpdateSerializedData(EntityManager manager, Entity entity)
        {
            var buffer = manager.GetBuffer<T>(entity);
            var count = buffer.Length;
            m_SerializedData.Clear();
            if (m_SerializedData.Capacity < count)
                m_SerializedData.Capacity = count;
            for (var i = 0; i < count; ++i)
                m_SerializedData.Add(buffer[i]);
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
