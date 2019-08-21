using System.Linq;
using NUnit.Framework;
using Unity.Collections;
using Unity.Jobs;

namespace Unity.Entities.Tests
{

#if NET_DOTS
    public class EmptySystem : ComponentSystem
    {
        protected override void OnUpdate()
        {

        }
        public new EntityQuery GetEntityQuery(params EntityQueryDesc[] queriesDesc)
        {
            return base.GetEntityQuery(queriesDesc);
        }

        public new EntityQuery GetEntityQuery(params ComponentType[] componentTypes)
        {
            return base.GetEntityQuery(componentTypes);
        }
        public new EntityQuery GetEntityQuery(NativeArray<ComponentType> componentTypes)
        {
            return base.GetEntityQuery(componentTypes);
        }
        public BufferFromEntity<T> GetBufferFromEntity<T>(bool isReadOnly = false) where T : struct, IBufferElementData
        {
            AddReaderWriter(isReadOnly ? ComponentType.ReadOnly<T>() : ComponentType.ReadWrite<T>());
            return EntityManager.GetBufferFromEntity<T>(isReadOnly);
        }
    }
#else
    public class EmptySystem : JobComponentSystem
    {
        protected override JobHandle OnUpdate(JobHandle dep) { return dep; }


        new public EntityQuery GetEntityQuery(params EntityQueryDesc[] queriesDesc)
        {
            return base.GetEntityQuery(queriesDesc);
        }

        new public EntityQuery GetEntityQuery(params ComponentType[] componentTypes)
        {
            return base.GetEntityQuery(componentTypes);
        }
        new public EntityQuery GetEntityQuery(NativeArray<ComponentType> componentTypes)
        {
            return base.GetEntityQuery(componentTypes);
        }
    }
#endif
    public abstract class ECSTestsFixture
    {
        protected World m_PreviousWorld;
        protected World World;
        protected EntityManager m_Manager;
        protected EntityManager.EntityManagerDebug m_ManagerDebug;

        protected int StressTestEntityCount = 1000;

        [SetUp]
        public virtual void Setup()
        {
            m_PreviousWorld = World.Active;
#if !UNITY_DOTSPLAYER
            World = World.Active = new World("Test World");
#else
            World = DefaultTinyWorldInitialization.Initialize("Test World");
#endif

            m_Manager = World.EntityManager;
            m_ManagerDebug = new EntityManager.EntityManagerDebug(m_Manager);

#if !UNITY_DOTSPLAYER
#if !UNITY_2019_2_OR_NEWER
            // Not raising exceptions can easily bring unity down with massive logging when tests fail.
            // From Unity 2019.2 on this field is always implicitly true and therefore removed.

            UnityEngine.Assertions.Assert.raiseExceptions = true;
#endif  // #if !UNITY_2019_2_OR_NEWER
#endif  // #if !UNITY_DOTSPLAYER
        }

        [TearDown]
        public virtual void TearDown()
        {
            if (m_Manager != null && m_Manager.IsCreated)
            {
                // Clean up systems before calling CheckInternalConsistency because we might have filters etc
                // holding on SharedComponentData making checks fail
                while (World.Systems.ToArray().Length > 0)
                {
                    World.DestroySystem(World.Systems.ToArray()[0]);
                }

                m_ManagerDebug.CheckInternalConsistency();

                World.Dispose();
                World = null;

                World.Active = m_PreviousWorld;
                m_PreviousWorld = null;
                m_Manager = null;
            }
        }

        public void AssertDoesNotExist(Entity entity)
        {
            Assert.IsFalse(m_Manager.HasComponent<EcsTestData>(entity));
            Assert.IsFalse(m_Manager.HasComponent<EcsTestData2>(entity));
            Assert.IsFalse(m_Manager.HasComponent<EcsTestData3>(entity));
            Assert.IsFalse(m_Manager.Exists(entity));
        }

        public void AssertComponentData(Entity entity, int index)
        {
            Assert.IsTrue(m_Manager.HasComponent<EcsTestData>(entity));
            Assert.IsTrue(m_Manager.HasComponent<EcsTestData2>(entity));
            Assert.IsFalse(m_Manager.HasComponent<EcsTestData3>(entity));
            Assert.IsTrue(m_Manager.Exists(entity));

            Assert.AreEqual(-index, m_Manager.GetComponentData<EcsTestData2>(entity).value0);
            Assert.AreEqual(-index, m_Manager.GetComponentData<EcsTestData2>(entity).value1);
            Assert.AreEqual(index, m_Manager.GetComponentData<EcsTestData>(entity).value);
        }

        public Entity CreateEntityWithDefaultData(int index)
        {
            var entity = m_Manager.CreateEntity(typeof(EcsTestData), typeof(EcsTestData2));

            // HasComponent & Exists setup correctly
            Assert.IsTrue(m_Manager.HasComponent<EcsTestData>(entity));
            Assert.IsTrue(m_Manager.HasComponent<EcsTestData2>(entity));
            Assert.IsFalse(m_Manager.HasComponent<EcsTestData3>(entity));
            Assert.IsTrue(m_Manager.Exists(entity));

            // Create must initialize values to zero
            Assert.AreEqual(0, m_Manager.GetComponentData<EcsTestData2>(entity).value0);
            Assert.AreEqual(0, m_Manager.GetComponentData<EcsTestData2>(entity).value1);
            Assert.AreEqual(0, m_Manager.GetComponentData<EcsTestData>(entity).value);

            // Setup some non zero default values
            m_Manager.SetComponentData(entity, new EcsTestData2(-index));
            m_Manager.SetComponentData(entity, new EcsTestData(index));

            AssertComponentData(entity, index);

            return entity;
        }

        public EmptySystem EmptySystem
        {
            get
            {
                return World.Active.GetOrCreateSystem<EmptySystem>();
            }
        }
    }
}
