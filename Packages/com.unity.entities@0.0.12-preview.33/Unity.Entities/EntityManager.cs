using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Assertions;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine.Profiling;
using UnityEngine.Scripting;

[assembly: InternalsVisibleTo("Unity.Entities.Hybrid")]
[assembly: InternalsVisibleTo("Unity.Entities.Properties")]
[assembly: InternalsVisibleTo("Unity.Tiny.Core")]
[assembly: InternalsVisibleTo("Unity.Editor")]

namespace Unity.Entities
{
    //@TODO: There is nothing prevent non-main thread (non-job thread) access of EntityManager.
    //       Static Analysis or runtime checks?

    //@TODO: safety?

    /// <summary>
    /// The EntityManager manages entities and components in a World.
    /// </summary>
    /// <remarks>
    /// The EntityManager provides an API to create, read, update, and destroy entities.
    ///
    /// A <see cref="World"/> has one EntityManager, which manages all the entities for that World.
    ///
    /// Many EntityManager operations result in *structural changes* that change the layout of entities in memory.
    /// Before it can perform such operations, the EntityManager must wait for all running Jobs to complete, an event
    /// called a *sync point*. A sync point both blocks the main thread and prevents the application from taking
    /// advantage of all available cores as the running Jobs wind down.
    ///
    /// Although you cannot prevent sync points entirely, you should avoid them as much as possible. To this end, the ECS
    /// framework provides the <see cref="EntityCommandBuffer"/>, which allows you to queue structural changes so that
    /// they all occur at one time in the frame.
    /// </remarks>
    [Preserve]
    [DebuggerTypeProxy(typeof(EntityManagerDebugView))]
    public sealed unsafe partial class EntityManager : EntityManagerBaseInterfaceForObsolete
    {
        ComponentJobSafetyManager*  m_ComponentJobSafetyManager;
        EntityComponentStore*       m_EntityComponentStore;
        ManagedComponentStore       m_ManagedComponentStore;
        EntityGroupManager          m_EntityGroupManager;
        ExclusiveEntityTransaction  m_ExclusiveEntityTransaction;
        World                       m_World;
        EntityArchetype             m_EntityOnlyArchetype;
        EntityQuery                 m_UniversalQuery; // matches all components
        EntityManagerDebug          m_Debug;

#if ENABLE_UNITY_COLLECTIONS_CHECKS
        int m_InsideForEach;
        internal bool IsInsideForEach => m_InsideForEach != 0;

        internal struct InsideForEach : IDisposable
        {
            EntityManager m_Manager;

            public InsideForEach(EntityManager manager)
            {
                m_Manager = manager;
                ++m_Manager.m_InsideForEach;
            }

            public void Dispose()
                => --m_Manager.m_InsideForEach;
        }
#endif

        internal EntityComponentStore* EntityComponentStore => m_EntityComponentStore;
        internal ComponentJobSafetyManager* ComponentJobSafetyManager => m_ComponentJobSafetyManager;
        internal EntityGroupManager EntityGroupManager => m_EntityGroupManager;
        internal ManagedComponentStore ManagedComponentStore => m_ManagedComponentStore;

        /// <summary>
        /// The <see cref="World"/> of this EntityManager.
        /// </summary>
        /// <value>A World has one EntityManager and an EntityManager manages the entities of one World.</value>
        public World World => m_World;

        /// <summary>
        /// The latest entity generational version.
        /// </summary>
        /// <value>This is the version number that is assigned to a new entity. See <see cref="Entity.Version"/>.</value>
        public int Version => IsCreated ? m_EntityComponentStore->EntityOrderVersion : 0;

        /// <summary>
        /// A counter that increments after every system update.
        /// </summary>
        /// <remarks>
        /// The ECS framework uses the GlobalSystemVersion to track changes in a conservative, efficient fashion.
        /// Changes are recorded per component per chunk.
        /// </remarks>
        /// <seealso cref="ArchetypeChunk.DidChange"/>
        /// <seealso cref="ChangedFilterAttribute"/>
        public uint GlobalSystemVersion => IsCreated ? EntityComponentStore->GlobalSystemVersion : 0;

        /// <summary>
        /// Reports whether the EntityManager has been initialized yet.
        /// </summary>
        /// <value>True, if the EntityManager's OnCreateManager() function has finished.</value>
        public bool IsCreated => m_EntityComponentStore != null;

        /// <summary>
        /// The capacity of the internal entities array.
        /// </summary>
        /// <value>The number of entities the array can hold before it must be resized.</value>
        /// <remarks>
        /// The entities array automatically resizes itself when the entity count approaches the capacity.
        /// You should rarely need to set this value directly.
        ///
        /// **Important:** when you set this value (or when the array automatically resizes), the EntityManager
        /// first ensures that all Jobs finish. This can prevent the Job scheduler from utilizing available CPU
        /// cores and threads, resulting in a temporary performance drop.
        /// </remarks>
        public int EntityCapacity => EntityComponentStore->EntitiesCapacity;

        /// <summary>
        /// The Job dependencies of the exclusive entity transaction.
        /// </summary>
        /// <value></value>
        public JobHandle ExclusiveEntityTransactionDependency
        {
            get { return ComponentJobSafetyManager->ExclusiveTransactionDependency; }
            set { ComponentJobSafetyManager->ExclusiveTransactionDependency = value; }
        }
        
        /// <summary>
        /// A EntityQuery instance that matches all components.
        /// </summary>
        public EntityQuery UniversalQuery => m_UniversalQuery;

        /// <summary>
        /// An object providing debugging information and operations.
        /// </summary>
        public EntityManagerDebug Debug => m_Debug ?? (m_Debug = new EntityManagerDebug(this));

        internal EntityManager(World world)
        {
            TypeManager.Initialize();

            m_World = world;

            m_ComponentJobSafetyManager =
                (ComponentJobSafetyManager*) UnsafeUtility.Malloc(sizeof(ComponentJobSafetyManager), 64,
                    Allocator.Persistent);
            m_ComponentJobSafetyManager->OnCreate();

            m_EntityComponentStore = Entities.EntityComponentStore.Create(world.SequenceNumber << 32);
            m_ManagedComponentStore = new ManagedComponentStore();
            m_EntityGroupManager = new EntityGroupManager(m_ComponentJobSafetyManager);

            m_ExclusiveEntityTransaction = new ExclusiveEntityTransaction(EntityGroupManager,
                m_ManagedComponentStore, EntityComponentStore);

            m_UniversalQuery = CreateEntityQuery(
                new EntityQueryDesc
                {
                    Options = EntityQueryOptions.IncludePrefab | EntityQueryOptions.IncludeDisabled
                }
            );
        }

        internal void DestroyInstance()
        {
            EndExclusiveEntityTransaction();

            m_ComponentJobSafetyManager->PreDisposeCheck();

            m_UniversalQuery.Dispose();
            m_UniversalQuery = null;

            m_ComponentJobSafetyManager->Dispose();
            UnsafeUtility.Free(m_ComponentJobSafetyManager, Allocator.Persistent);
            m_ComponentJobSafetyManager = null;

            Entities.EntityComponentStore.Destroy(m_EntityComponentStore);

            m_EntityComponentStore = null;
            m_EntityGroupManager.Dispose();
            m_EntityGroupManager = null;
            m_ExclusiveEntityTransaction.OnDestroy();

            m_ManagedComponentStore.Dispose();

            m_World = null;
            m_Debug = null;

            TypeManager.Shutdown();
        }

        private EntityManager()
        {
            // for tests only
        }

        internal static EntityManager CreateEntityManagerInUninitializedState()
        {
            return new EntityManager();
        }
    }
}
