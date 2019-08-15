using System;
using System.Reflection;
using Unity.Collections;
using Unity.Jobs;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs.LowLevel.Unsafe;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using UnityEngine;

namespace Unity.Entities
{

    [DebuggerTypeProxy(typeof(IntListDebugView))]
    internal unsafe struct IntList
    {
        public int* p;
        public int Count;
        public int Capacity;
    }

    /// <summary>
    /// A system provides behavior in an ECS architecture.
    /// </summary>
    /// <remarks>
    /// A typical system operates on a set of entities that have specific components. The system identifies
    /// the components of interest using an <seealso cref="EntityQuery"/> (JobComponentSystem) or
    /// <seealso cref="EntityQueryBuilder"/> (ComponentSystem). The system then finds the entities matching the query
    /// and iterates over them, reading and writing data, and performing other entity operations as appropriate. A
    /// <seealso cref="ComponentSystem"/> is designed to perform its work on the main thread; a
    /// <seealso cref="JobComponentSystem"/> is designed to work with ECS-specific Jobs, such as
    /// <see cref="IJobForEach{T0}"/> and <see cref="IJobChunk"/> or with general-purpose
    /// [C# Jobs](https://docs.unity3d.com/2019.2/Documentation/Manual/JobSystem.html).
    ///
    /// You can implement a set of system lifecycle event functions when you implement a system. The ECS invokes these
    /// functions in the following order:
    ///
    /// * <see cref="OnCreate"/> -- called when the system is created.
    /// * <see cref="OnStartRunning"/> -- before the first OnUpdate and whenever the system resumes running.
    /// * `OnUpdate` -- every frame as long as the system has work to do (see <see cref="ShouldRunSystem"/>) and the
    ///    system is <see cref="Enabled"/>. Note that the OnUpdate function is defined in the subclasses of
    ///    ComponentSystemBase; each system class can define its own update behavior.
    /// * <see cref="OnStopRunning"/> -- whenever the system stops updating because it finds no entities matching its
    ///   queries. Also called before OnDestroy.
    /// * <see cref="OnDestroy"/> -- when the system is destroyed.
    ///
    /// All of these functions are executed on the main thread. Note that you can schedule Jobs from the
    /// <see cref="JobComponentSystem.OnUpdate"/> function of a JobComponentSystem to perform work on
    /// background threads.
    ///
    /// The runtime executes systems in the order determined by their <see cref="ComponentSystemGroup"/>. Place a system
    /// in a group using <seealso cref="UpdateInGroupAttribute"/>. Use <seealso cref="UpdateBeforeAttribute"/> and
    /// <seealso cref="UpdateAfterAttribute"/> to specify the execution order within a group.
    ///
    /// If you do not explicitly place a system in a specific group, the runtime places it in the Default World
    /// <see cref="SimulationSystemGroup"/>. By default, all systems are discovered, instantiated, and added to the
    /// default World. You can use the <seealso cref="DisableAutoCreationAttribute"/> to prevent a system from being
    /// created automatically.
    /// </remarks>
    public unsafe abstract partial class ComponentSystemBase
    {
        EntityQuery[] m_EntityQueries;
        EntityQuery[] m_RequiredEntityQueries;

        internal IntList m_JobDependencyForReadingSystems;
        internal IntList m_JobDependencyForWritingSystems;

        uint m_LastSystemVersion;

        internal ComponentJobSafetyManager* m_SafetyManager;
        internal EntityManager m_EntityManager;
        World m_World;

        bool m_AlwaysUpdateSystem;
        internal bool m_PreviouslyEnabled;

        /// <summary>
        /// Controls whether this system executes when its OnUpdate function is called.
        /// </summary>
        /// <value>True, if the system is enabled.</value>
        /// <remarks>The Enabled property is intended for debugging so that you can easily turn on and off systems
        /// from the Entity Debugger window. A system with Enabled set to false will not update, even if its
        /// <see cref="ShouldRunSystem"/> function returns true.</remarks>
        public bool Enabled { get; set; } = true;

        /// <summary>
        /// The query objects cached by this system.
        /// </summary>
        /// <remarks>A system caches any queries it implicitly creates through the IJob interfaces or
        /// <see cref="EntityQueryBuilder"/>, that you create explicitly by calling <see cref="GetEntityQuery"/>, or
        /// that you add to the system as a required query with <see cref="RequireForUpdate"/>.
        /// Implicit queries may be created lazily and not exist before a system has run for the first time.</remarks>
        /// <value>A read-only array of the cached <see cref="EntityQuery"/> objects.</value>
        public EntityQuery[] EntityQueries => m_EntityQueries;

        /// <summary>
        /// The current change version number in this <see cref="World"/>.
        /// </summary>
        /// <remarks>The system updates the component version numbers inside any <see cref="ArchetypeChunk"/> instances
        /// that this system accesses with write permissions to this value.</remarks>
        public uint GlobalSystemVersion => m_EntityManager.GlobalSystemVersion;

        /// <summary>
        /// The current version of this system.
        /// </summary>
        /// <remarks>
        /// LastSystemVersion is updated to match the <see cref="GlobalSystemVersion"/> whenever a system runs.
        ///
        /// When you use <seealso cref="EntityQuery.SetFilterChanged"/>
        /// or <seealso cref="ArchetypeChunk.DidChange"/>, LastSystemVersion provides the basis for determining
        /// whether a component could have changed since the last time the system ran.
        ///
        /// When a system accesses a component and has write permission, it updates the change version of that component
        /// type to the current value of LastSystemVersion. The system updates the component type's version whether or not
        /// it actually modifies data in any instances of the component type -- this is one reason why you should
        /// specify read-only access to components whenever possible.
        ///
        /// For efficiency, ECS tracks the change version of component types by chunks, not by individual entities. If a system
        /// updates the component of a given type for any entity in a chunk, then ECS assumes that the components of all
        /// entities in that chunk could have been changed. Change filtering allows you to save processing time by
        /// skipping all entities in an unchanged chunk, but does not support skipping individual entities in a chunk
        /// that does contain changes.
        /// </remarks>
        /// <value>The <see cref="GlobalSystemVersion"/> the last time this system ran.</value>
        public uint LastSystemVersion => m_LastSystemVersion;

        /// <summary>
        /// The EntityManager object of the <see cref="World"/> in which this system exists.
        /// </summary>
        /// <value>The EntityManager for this system.</value>
        public EntityManager EntityManager => m_EntityManager;

        /// <summary>
        /// The World in which this system exists.
        /// </summary>
        /// <value>The World of this system.</value>
        public World World => m_World;

        // ============

#if UNITY_EDITOR
        private UnityEngine.Profiling.CustomSampler m_Sampler;
#endif

#if !NET_DOTS
#if ENABLE_UNITY_COLLECTIONS_CHECKS
        private static HashSet<Type> s_ObsoleteAPICheckedTypes = new HashSet<Type>();

        void CheckForObsoleteAPI()
        {
            var type = this.GetType();
            while (type != typeof(ComponentSystemBase))
            {
                if (s_ObsoleteAPICheckedTypes.Contains(type))
                    break;

                if (type.GetMethod("OnCreateManager", BindingFlags.DeclaredOnly | BindingFlags.Instance) != null)
                {
                    Debug.LogWarning($"The OnCreateManager overload in {type} is obsolete; please rename it to OnCreate.  OnCreateManager will stop being called in a future release.");
                }

                if (type.GetMethod("OnDestroyManager", BindingFlags.DeclaredOnly | BindingFlags.Instance) != null)
                {
                    Debug.LogWarning($"The OnDestroyManager overload in {type} is obsolete; please rename it to OnDestroy.  OnDestroyManager will stop being called in a future release.");
                }

                s_ObsoleteAPICheckedTypes.Add(type);

                type = type.BaseType;
            }
        }

        /// <summary>
        /// Base class constructor.
        /// </summary>
        protected ComponentSystemBase()
        {
             CheckForObsoleteAPI();
        }
#endif
#endif

        internal void CreateInstance(World world)
        {
            OnBeforeCreateInternal(world);
            try
            {
                OnCreateManager(); // DELETE after obsolete period!
                OnCreate();
#if UNITY_EDITOR
                var type = GetType();
                m_Sampler = UnityEngine.Profiling.CustomSampler.Create($"{world.Name} {type.FullName}");
#endif
            }
            catch
            {
                OnBeforeDestroyInternal();
                OnAfterDestroyInternal();
                throw;
            }
        }

        internal void DestroyInstance()
        {
            OnBeforeDestroyInternal();
            OnDestroy();
            OnDestroyManager(); // DELETE after obsolete period!
            OnAfterDestroyInternal();
        }

        /// <summary>
        /// Deprecated. Use <see cref="OnCreate"/>.
        /// </summary>
        protected virtual void OnCreateManager()
        {
        }

        /// <summary>
        /// Deprecated. Use <see cref="OnDestroy"/>.
        /// </summary>
        protected virtual void OnDestroyManager()
        {
        }

        /// <summary>
        /// Called when this system is created.
        /// </summary>
        /// <remarks>
        /// Implement an OnCreate() function to set up system resources when it is created.
        ///
        /// OnCreate is invoked before the the first time <see cref="OnStartRunning"/> and OnUpdate are invoked.
        /// </remarks>
        protected virtual void OnCreate()
        {
        }

        /// <summary>
        /// Called before the first call to OnUpdate and when a system resumes updating after being stopped or disabled.
        /// </summary>
        /// <remarks>If the <see cref="EntityQuery"/> objects defined for a system do not match any existing entities
        /// then the system skips updates until a successful match is found. Likewise, if you set <see cref="Enabled"/>
        /// to false, then the system stops running. In both cases, <see cref="OnStopRunning"/> is
        /// called when a running system stops updating; OnStartRunning is called when it starts updating again.
        /// </remarks>
        protected virtual void OnStartRunning()
        {
        }

        /// <summary>
        /// Called when this system stops running because no entities match the system's <see cref="EntityQuery"/>
        /// objects or because you change the system <see cref="Enabled"/> property to false.
        /// </summary>
        /// <remarks>If the <see cref="EntityQuery"/> objects defined for a system do not match any existing entities
        /// then the system skips updating until a successful match is found. Likewise, if you set <see cref="Enabled"/>
        /// to false, then the system stops running. In both cases, <see cref="OnStopRunning"/> is
        /// called when a running system stops updating; OnStartRunning is called when it starts updating again.
        /// </remarks>
        protected virtual void OnStopRunning()
        {
        }

        /// <summary>
        /// Called when this system is destroyed.
        /// </summary>
        /// <remarks>Systems are destroyed when the application shuts down, the World is destroyed, or you
        /// call <see cref="World.DestroySystem"/>. In the Unity Editor, system destruction occurs when you exit
        /// Play Mode and when scripts are reloaded.</remarks>
        protected virtual void OnDestroy()
        {
        }

        /// <summary>
        /// Executes the system immediately.
        /// </summary>
        /// <remarks>The exact behavior is determined by this system's specific subclass.</remarks>
        /// <seealso cref="ComponentSystem"/>
        /// <seealso cref="JobComponentSystem"/>
        /// <seealso cref="ComponentSystemGroup"/>
        /// <seealso cref="EntityCommandBufferSystem"/>
        public void Update()
        {
#if UNITY_EDITOR
            m_Sampler?.Begin();
#endif
            InternalUpdate();

#if UNITY_EDITOR
            m_Sampler?.End();
#endif
        }

        // ===================

#if ENABLE_UNITY_COLLECTIONS_CHECKS
        internal int                        m_SystemID;
        static internal ComponentSystemBase ms_ExecutingSystem;

        internal ComponentSystemBase GetSystemFromSystemID(World world, int systemID)
        {
            foreach(var m in world.Systems)
            {
                var system = m as ComponentSystemBase;
                if (system == null)
                    continue;
                if (system.m_SystemID == systemID)
                    return system;
            }

            return null;
        }
#endif

        ref UnsafeList JobDependencyForReadingSystemsUnsafeList =>
            ref *(UnsafeList*) UnsafeUtility.AddressOf(ref m_JobDependencyForReadingSystems);

        ref UnsafeList JobDependencyForWritingSystemsUnsafeList =>
            ref *(UnsafeList*) UnsafeUtility.AddressOf(ref m_JobDependencyForWritingSystems);

        [Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
        internal void CheckExists()
        {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
            if (World == null || !World.IsCreated)
            {
                if (m_SystemID == 0)
                {
                    throw new InvalidOperationException(
                        $"{GetType()}.m_systemID is zero (invalid); This usually means it was not created with World.GetOrCreateSystem<{GetType()}>().");
                }
                else
                {
                    throw new InvalidOperationException(
                        $"{GetType()} has already been destroyed. It may not be used anymore.");
                }
            }
#endif
        }

        /// <summary>
        /// Reports whether any of this system's entity queries currently match any chunks. This function is used
        /// internally to determine whether the system's OnUpdate function can be skipped.
        /// </summary>
        /// <returns>True, if the queries in this system match existing entities or the system has the
        /// <see cref="AlwaysUpdateSystemAttribute"/>.</returns>
        /// <remarks>A system without any queries also returns true. Note that even if this function returns true,
        /// other factors may prevent a system from updating. For example, a system will not be updated if its
        /// <see cref="Enabled"/> property is false.</remarks>
        public bool ShouldRunSystem()
        {
            CheckExists();

            if (m_AlwaysUpdateSystem)
                return true;

            if (m_RequiredEntityQueries != null)
            {
                for (int i = 0; i != m_RequiredEntityQueries.Length; i++)
                {
                    if (m_RequiredEntityQueries[i].IsEmptyIgnoreFilter)
                        return false;
                }

                return true;
            }
            else
            {
                // Systems without queriesDesc should always run. Specifically,
                // IJobForEach adds its queriesDesc the first time it's run.
                var length = m_EntityQueries != null ? m_EntityQueries.Length : 0;
                if (length == 0)
                    return true;

                // If all the queriesDesc are empty, skip it.
                // (There’s no way to know what the key value is without other markup)
                for (int i = 0; i != length; i++)
                {
                    if (!m_EntityQueries[i].IsEmptyIgnoreFilter)
                        return true;
                }

                return false;
            }
        }

        internal virtual void OnBeforeCreateInternal(World world)
        {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
            m_SystemID = World.AllocateSystemID();
#endif
            m_World = world;
            m_EntityManager = world.EntityManager;
            m_SafetyManager = m_EntityManager.ComponentJobSafetyManager;

            m_EntityQueries = new EntityQuery[0];
#if !NET_DOTS
            m_AlwaysUpdateSystem = GetType().GetCustomAttributes(typeof(AlwaysUpdateSystemAttribute), true).Length != 0;
#else
            m_AlwaysUpdateSystem = true;
#endif
        }

        internal void OnAfterDestroyInternal()
        {
            foreach (var query in m_EntityQueries)
            {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
                query.DisallowDisposing = null;
#endif
                query.Dispose();
            }

            m_EntityQueries = null;
            m_EntityManager = null;
            m_World = null;
            m_SafetyManager = null;

            JobDependencyForReadingSystemsUnsafeList.Dispose<int>();
            JobDependencyForWritingSystemsUnsafeList.Dispose<int>();
        }

        internal abstract void InternalUpdate();

        internal virtual void OnBeforeDestroyInternal()
        {
            if (m_PreviouslyEnabled)
            {
                m_PreviouslyEnabled = false;
                OnStopRunning();
            }
        }

        internal void BeforeUpdateVersioning()
        {
            m_EntityManager.EntityComponentStore->IncrementGlobalSystemVersion();
            foreach (var query in m_EntityQueries)
                query.SetFilterChangedRequiredVersion(m_LastSystemVersion);
        }

        internal void AfterUpdateVersioning()
        {
            m_LastSystemVersion = EntityManager.EntityComponentStore->GlobalSystemVersion;
        }

        // TODO: this should be made part of UnityEngine?
        static void ArrayUtilityAdd<T>(ref T[] array, T item)
        {
            Array.Resize(ref array, array.Length + 1);
            array[array.Length - 1] = item;
        }

        /// <summary>
        /// Gets the run-time type information required to access an array of component data in a chunk.
        /// </summary>
        /// <param name="isReadOnly">Whether the component data is only read, not written. Access components as
        /// read-only whenever possible.</param>
        /// <typeparam name="T">A struct that implements <see cref="IComponentData"/>.</typeparam>
        /// <returns>An object representing the type information required to safely access component data stored in a
        /// chunk.</returns>
        /// <remarks>Pass an <see cref="ArchetypeChunkComponentType"/> instance to a job that has access to chunk data,
        /// such as an <see cref="IJobChunk"/> job, to access that type of component inside the job.</remarks>
        public ArchetypeChunkComponentType<T> GetArchetypeChunkComponentType<T>(bool isReadOnly = false)
        {
            AddReaderWriter(isReadOnly ? ComponentType.ReadOnly<T>() : ComponentType.ReadWrite<T>());
            return EntityManager.GetArchetypeChunkComponentType<T>(isReadOnly);
        }

        /// <summary>
        /// Gets the run-time type information required to access an array of buffer components in a chunk.
        /// </summary>
        /// <param name="isReadOnly">Whether the data is only read, not written. Access data as
        /// read-only whenever possible.</param>
        /// <typeparam name="T">A struct that implements <see cref="IBufferElementData"/>.</typeparam>
        /// <returns>An object representing the type information required to safely access buffer components stored in a
        /// chunk.</returns>
        /// <remarks>Pass a GetArchetypeChunkBufferType instance to a job that has access to chunk data, such as an
        /// <see cref="IJobChunk"/> job, to access that type of buffer component inside the job.</remarks>
        public ArchetypeChunkBufferType<T> GetArchetypeChunkBufferType<T>(bool isReadOnly = false)
            where T : struct, IBufferElementData
        {
            AddReaderWriter(isReadOnly ? ComponentType.ReadOnly<T>() : ComponentType.ReadWrite<T>());
            return EntityManager.GetArchetypeChunkBufferType<T>(isReadOnly);
        }

        /// <summary>
        /// Gets the run-time type information required to access a shared component data in a chunk.
        /// </summary>
        /// <typeparam name="T">A struct that implements <see cref="ISharedComponentData"/>.</typeparam>
        /// <returns>An object representing the type information required to safely access shared component data stored in a
        /// chunk.</returns>
        public ArchetypeChunkSharedComponentType<T> GetArchetypeChunkSharedComponentType<T>()
            where T : struct, ISharedComponentData
        {
            return EntityManager.GetArchetypeChunkSharedComponentType<T>();
        }

        /// <summary>
        /// Gets the run-time type information required to access the array of <see cref="Entity"/> objects in a chunk.
        /// </summary>
        /// <returns>An object representing the type information required to safely access Entity instances stored in a
        /// chunk.</returns>
        public ArchetypeChunkEntityType GetArchetypeChunkEntityType()
        {
            return EntityManager.GetArchetypeChunkEntityType();
        }

        /// <summary>
        /// Gets an array-like container containing all components of type T, indexed by Entity.
        /// </summary>
        /// <param name="isReadOnly">Whether the data is only read, not written. Access data as
        /// read-only whenever possible.</param>
        /// <typeparam name="T">A struct that implements <see cref="IComponentData"/>.</typeparam>
        /// <returns>All component data of type T.</returns>
        public ComponentDataFromEntity<T> GetComponentDataFromEntity<T>(bool isReadOnly = false)
            where T : struct, IComponentData
        {
            AddReaderWriter(isReadOnly ? ComponentType.ReadOnly<T>() : ComponentType.ReadWrite<T>());
            return EntityManager.GetComponentDataFromEntity<T>(isReadOnly);
        }

        /// <summary>
        /// Adds a query that must return entities for the system to run. You can add multiple required queries to a
        /// system; all of them must match at least one entity for the system to run.
        /// </summary>
        /// <param name="query">A query that must match entities this frame in order for this system to run.</param>
        /// <remarks>Any queries added through RequireforUpdate override all other queries cached by this system.
        /// In other words, if any required query does not find matching entities, the update is skipped even
        /// if another query created for the system (either explicitly or implicitly) does match entities and
        /// vice versa.</remarks>
        public void RequireForUpdate(EntityQuery query)
        {
            if (m_RequiredEntityQueries == null)
                m_RequiredEntityQueries = new EntityQuery[1] {query};
            else
                ArrayUtilityAdd(ref m_RequiredEntityQueries, query);
        }

        /// <summary>
        /// Require that a specific singleton component exist for this system to run.
        /// </summary>
        /// <typeparam name="T">The <see cref="IComponentData"/> subtype of the singleton component.</typeparam>
        public void RequireSingletonForUpdate<T>()
        {
            var type = ComponentType.ReadOnly<T>();
            var query = GetEntityQueryInternal(&type, 1);
            RequireForUpdate(query);
        }

        /// <summary>
        /// Checks whether a singelton component of the specified type exists.
        /// </summary>
        /// <typeparam name="T">The <see cref="IComponentData"/> subtype of the singleton component.</typeparam>
        /// <returns>True, if a singleton of the secified type exists in the current <see cref="World"/>.</returns>
        public bool HasSingleton<T>()
            where T : struct, IComponentData
        {
            var type = ComponentType.ReadOnly<T>();
            var query = GetEntityQueryInternal(&type, 1);
            return !query.IsEmptyIgnoreFilter;
        }

        /// <summary>
        /// Gets the value of a singleton component.
        /// </summary>
        /// <typeparam name="T">The <see cref="IComponentData"/> subtype of the singleton component.</typeparam>
        /// <returns>The component.</returns>
        /// <seealso cref="EntityQuery.GetSingleton{T}"/>
        public T GetSingleton<T>()
            where T : struct, IComponentData
        {
            var type = ComponentType.ReadOnly<T>();
            var query = GetEntityQueryInternal(&type, 1);

            return query.GetSingleton<T>();
        }

        /// <summary>
        /// Sets the value of a singleton component.
        /// </summary>
        /// <param name="value">A component containing the value to assign to the singleton.</param>
        /// <typeparam name="T">The <see cref="IComponentData"/> subtype of the singleton component.</typeparam>
        /// <seealso cref="EntityQuery.SetSingleton{T}"/>
        public void SetSingleton<T>(T value)
            where T : struct, IComponentData
        {
            var type = ComponentType.ReadWrite<T>();
            var query = GetEntityQueryInternal(&type, 1);
            query.SetSingleton(value);
        }

        /// <summary>
        /// Gets the Entity instance for a singleton.
        /// </summary>
        /// <typeparam name="T">The IComponentData subtype of the singleton component.</typeparam>
        /// <returns>The entity associated with the specified singleton component.</returns>
        /// <seealso cref="EntityQuery.GetSingletonEntity"/>
        public Entity GetSingletonEntity<T>()
            where T : struct, IComponentData
        {
            var type = ComponentType.ReadOnly<T>();
            var query = GetEntityQueryInternal(&type, 1);

            return query.GetSingletonEntity();
        }

        internal void AddReaderWriter(ComponentType componentType)
        {
            if (CalculateReaderWriterDependency.Add(componentType, ref JobDependencyForReadingSystemsUnsafeList,
                ref JobDependencyForWritingSystemsUnsafeList))
            {
                CompleteDependencyInternal();
            }
        }

        internal void AddReaderWriters(EntityQuery query)
        {
            if (query.AddReaderWritersToLists(ref JobDependencyForReadingSystemsUnsafeList,
                ref JobDependencyForWritingSystemsUnsafeList))
            {
                CompleteDependencyInternal();
            }
        }

        internal EntityQuery GetEntityQueryInternal(ComponentType* componentTypes, int count)
        {
            for (var i = 0; i != m_EntityQueries.Length; i++)
            {
                if (m_EntityQueries[i].CompareComponents(componentTypes, count))
                    return m_EntityQueries[i];
            }

            var query = EntityManager.CreateEntityQuery(componentTypes, count);

            AddReaderWriters(query);
            AfterQueryCreated(query);

            return query;
        }

        internal EntityQuery GetEntityQueryInternal(ComponentType[] componentTypes)
        {
            fixed (ComponentType* componentTypesPtr = componentTypes)
            {
                return GetEntityQueryInternal(componentTypesPtr, componentTypes.Length);
            }
        }

        internal EntityQuery GetEntityQueryInternal(EntityQueryDesc[] desc)
        {
            for (var i = 0; i != m_EntityQueries.Length; i++)
            {
                if (m_EntityQueries[i].CompareQuery(desc))
                    return m_EntityQueries[i];
            }

            var query = EntityManager.CreateEntityQuery(desc);

            AddReaderWriters(query);
            AfterQueryCreated(query);

            return query;
        }

        void AfterQueryCreated(EntityQuery query)
        {
            query.SetFilterChangedRequiredVersion(m_LastSystemVersion);
#if ENABLE_UNITY_COLLECTIONS_CHECKS
            query.DisallowDisposing =
 "EntityQuery.Dispose() may not be called on a EntityQuery created with ComponentSystem.GetEntityQuery. The EntityQuery will automatically be disposed by the ComponentSystem.";
#endif

            ArrayUtilityAdd(ref m_EntityQueries, query);
        }

        /// <summary>
        /// Gets the cached query for the specified component types, if one exists; otherwise, creates a new query
        /// instance and caches it.
        /// </summary>
        /// <param name="componentTypes">An array or comma-separated list of component types.</param>
        /// <returns>The new or cached query.</returns>
        protected internal EntityQuery GetEntityQuery(params ComponentType[] componentTypes)
        {
            return GetEntityQueryInternal(componentTypes);
        }

        /// <summary>
        /// Gets the cached query for the specified component types, if one exists; otherwise, creates a new query
        /// instance and caches it.
        /// </summary>
        /// <param name="componentTypes">An array of component types.</param>
        /// <returns>The new or cached query.</returns>
        protected EntityQuery GetEntityQuery(NativeArray<ComponentType> componentTypes)
        {
            return GetEntityQueryInternal((ComponentType*) componentTypes.GetUnsafeReadOnlyPtr(),
                componentTypes.Length);
        }

        /// <summary>
        /// Combines an array of query description objects into a single query.
        /// </summary>
        /// <remarks>This function looks for a cached query matching the combined query descriptions, and returns it
        /// if one exists; otherwise, the function creates a new query instance and caches it.</remarks>
        /// <returns>The new or cached query.</returns>
        /// <param name="queryDesc">An array of query description objects to be combined to define the query.</param>
        protected internal EntityQuery GetEntityQuery(params EntityQueryDesc[] queryDesc)
        {
            return GetEntityQueryInternal(queryDesc);
        }

        internal void CompleteDependencyInternal()
        {
            m_SafetyManager->CompleteDependenciesNoChecks(m_JobDependencyForReadingSystems.p,
                m_JobDependencyForReadingSystems.Count, m_JobDependencyForWritingSystems.p,
                m_JobDependencyForWritingSystems.Count);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("GetEntities has been deprecated. Use Entities.ForEach to access managed components. More information: https://forum.unity.com/threads/api-deprecation-faq-0-0-23.636994/", true)]
        protected void GetEntities<T>() where T : struct { }
    }

    /// <summary>
    /// An abstract class to implement in order to create a system.
    /// </summary>
    /// <remarks>Implement a ComponentSystem subclass for systems that perform their work on the main thread or that
    /// use Jobs not specifically optimized for ECS. To use the ECS-specific Jobs, such as <see cref="IJobForEach{T0}"/> or
    /// <see cref="IJobChunk"/>, implement <seealso cref="JobComponentSystem"/> instead.</remarks>
    public abstract partial class ComponentSystem : ComponentSystemBase
    {
        EntityCommandBuffer m_DeferredEntities;
        EntityQueryCache m_EntityQueryCache;

        /// <summary>
        /// This system's <see cref="EntityCommandBuffer"/>.
        /// </summary>
        /// <value>A queue of entity-related commands to playback after the system's update function finishes.</value>
        /// <remarks>When iterating over a collection of entities with <see cref="ComponentSystem.Entities"/>, the system
        /// prohibits structural changes that would invalidate that collection. Such changes include creating and
        /// destroying entities, adding or removing components, and changing the value of shared components.
        ///
        /// Instead, add structural change commands to this PostUpdateCommands command buffer. The system executes
        /// commands added to this command buffer in order after this system's <see cref="OnUpdate"/> function returns.</remarks>
        public EntityCommandBuffer PostUpdateCommands => m_DeferredEntities;

        /// <summary>
        /// Initializes this system's internal cache of <see cref="EntityQuery"/> objects to the specified number of
        /// queries.
        /// </summary>
        /// <param name="cacheSize">The initial capacity of the system's <see cref="EntityQuery"/> array.</param>
        /// <remarks>A system's entity query cache expands automatically as you add additional queries. However,
        /// initializing the cache to the correct size when you initialize a system is more efficient and avoids
        /// unnecessary, garbage-collected memory allocations.</remarks>
        protected internal void InitEntityQueryCache(int cacheSize) =>
            m_EntityQueryCache = new EntityQueryCache(cacheSize);

        internal EntityQueryCache EntityQueryCache => m_EntityQueryCache;

        internal EntityQueryCache GetOrCreateEntityQueryCache()
            => m_EntityQueryCache ?? (m_EntityQueryCache = new EntityQueryCache());

        /// <summary>
        /// This system's query builder object.
        /// </summary>
        /// <value>Use to select and iterate over entities.</value>
        protected internal EntityQueryBuilder Entities => new EntityQueryBuilder(this);

        unsafe void BeforeOnUpdate()
        {
            BeforeUpdateVersioning();
            CompleteDependencyInternal();

            m_DeferredEntities = new EntityCommandBuffer(Allocator.TempJob, -1);
        }

        void AfterOnUpdate()
        {
            AfterUpdateVersioning();

            JobHandle.ScheduleBatchedJobs();

#if ENABLE_UNITY_COLLECTIONS_CHECKS
            try
            {
                m_DeferredEntities.Playback(EntityManager);
            }
            catch (Exception e)
            {
                m_DeferredEntities.Dispose();
                var error = $"{e.Message}\nEntityCommandBuffer was recorded in {GetType()} using PostUpdateCommands.\n" + e.StackTrace;
                throw new System.ArgumentException(error);
            }
#else
            m_DeferredEntities.Playback(EntityManager);
#endif
            m_DeferredEntities.Dispose();
        }

        internal sealed override void InternalUpdate()
        {
            if (Enabled && ShouldRunSystem())
            {
                if (!m_PreviouslyEnabled)
                {
                    m_PreviouslyEnabled = true;
                    OnStartRunning();
                }

                BeforeOnUpdate();

#if ENABLE_UNITY_COLLECTIONS_CHECKS
                var oldExecutingSystem = ms_ExecutingSystem;
                ms_ExecutingSystem = this;
#endif

                try
                {
                    OnUpdate();
                }
                finally
                {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
                    ms_ExecutingSystem = oldExecutingSystem;
#endif
                    AfterOnUpdate();
                }
            }
            else if (m_PreviouslyEnabled)
            {
                m_PreviouslyEnabled = false;
                OnStopRunning();
            }
        }

        internal sealed override void OnBeforeCreateInternal(World world)
        {
            base.OnBeforeCreateInternal(world);
        }

        internal sealed override void OnBeforeDestroyInternal()
        {
            base.OnBeforeDestroyInternal();
        }

        /// <summary>Implement OnUpdate to perform the major work of this system.</summary>
        /// <remarks>
        /// The system invokes OnUpdate once per frame on the main thread when any of this system's
        /// EntityQueries match existing entities, or if the system has the <see cref="AlwaysUpdateSystemAttribute"/>.
        /// </remarks>
        /// <seealso cref="ComponentSystemBase.ShouldRunSystem"/>
        protected abstract void OnUpdate();

    }

    /// <summary>
    /// An abstract class to implement in order to create a system that uses ECS-specific Jobs.
    /// </summary>
    /// <remarks>Implement a JobComponentSystem subclass for systems that perform their work using
    /// <see cref="IJobForEach{T0}"/> or <see cref="IJobChunk"/>.</remarks>
    /// <seealso cref="ComponentSystem"/>
    public abstract class JobComponentSystem : ComponentSystemBase
    {
        JobHandle m_PreviousFrameDependency;

        unsafe JobHandle BeforeOnUpdate()
        {
            BeforeUpdateVersioning();

            // We need to wait on all previous frame dependencies, otherwise it is possible that we create infinitely long dependency chains
            // without anyone ever waiting on it
            m_PreviousFrameDependency.Complete();

            return GetDependency();
        }

        unsafe void AfterOnUpdate(JobHandle outputJob, bool throwException)
        {
            AfterUpdateVersioning();

            JobHandle.ScheduleBatchedJobs();

            AddDependencyInternal(outputJob);

#if ENABLE_UNITY_COLLECTIONS_CHECKS

            if (!JobsUtility.JobDebuggerEnabled)
                return;

            // Check that all reading and writing jobs are a dependency of the output job, to
            // catch systems that forget to add one of their jobs to the dependency graph.
            //
            // Note that this check is not strictly needed as we would catch the mistake anyway later,
            // but checking it here means we can flag the system that has the mistake, rather than some
            // other (innocent) system that is doing things correctly.

            //@TODO: It is not ideal that we call m_SafetyManager.GetDependency,
            //       it can result in JobHandle.CombineDependencies calls.
            //       Which seems like debug code might have side-effects

            string dependencyError = null;
            for (var index = 0; index < m_JobDependencyForReadingSystems.Count && dependencyError == null; index++)
            {
                var type = m_JobDependencyForReadingSystems.p[index];
                dependencyError = CheckJobDependencies(type);
            }

            for (var index = 0; index < m_JobDependencyForWritingSystems.Count && dependencyError == null; index++)
            {
                var type = m_JobDependencyForWritingSystems.p[index];
                dependencyError = CheckJobDependencies(type);
            }

            if (dependencyError != null)
            {
                EmergencySyncAllJobs();

                if (throwException)
                    throw new System.InvalidOperationException(dependencyError);
            }
#endif
        }

        internal sealed override void InternalUpdate()
        {
            if (Enabled && ShouldRunSystem())
            {
                if (!m_PreviouslyEnabled)
                {
                    m_PreviouslyEnabled = true;
                    OnStartRunning();
                }

                var inputJob = BeforeOnUpdate();
                JobHandle outputJob = new JobHandle();

#if ENABLE_UNITY_COLLECTIONS_CHECKS
                var oldExecutingSystem = ms_ExecutingSystem;
                ms_ExecutingSystem = this;
#endif
                try
                {
                    outputJob = OnUpdate(inputJob);
                }
                catch
                {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
                    ms_ExecutingSystem = oldExecutingSystem;
#endif

                    AfterOnUpdate(outputJob, false);
                    throw;
                }

                AfterOnUpdate(outputJob, true);
            }
            else if (m_PreviouslyEnabled)
            {
                m_PreviouslyEnabled = false;
                OnStopRunning();
            }
        }

        internal sealed override void OnBeforeDestroyInternal()
        {
            base.OnBeforeDestroyInternal();
            m_PreviousFrameDependency.Complete();
        }

        /// <summary>
        /// Gets a BufferFromEntity&lt;T&gt; object that can access a <seealso cref="DynamicBuffer{T}"/>.
        /// </summary>
        /// <remarks>Assign the returned object to a field of your Job struct so that you can access the
        /// contents of the buffer in a Job.</remarks>
        /// <param name="isReadOnly">Whether the buffer data is only read or is also written. Access data in
        /// a read-only fashion whenever possible.</param>
        /// <typeparam name="T">The type of <see cref="IBufferElementData"/> stored in the buffer.</typeparam>
        /// <returns>An array-like object that provides access to buffers, indexed by <see cref="Entity"/>.</returns>
        /// <seealso cref="ComponentDataFromEntity{T}"/>
        public BufferFromEntity<T> GetBufferFromEntity<T>(bool isReadOnly = false) where T : struct, IBufferElementData
        {
            AddReaderWriter(isReadOnly ? ComponentType.ReadOnly<T>() : ComponentType.ReadWrite<T>());
            return EntityManager.GetBufferFromEntity<T>(isReadOnly);
        }

        /// <summary>Implement OnUpdate to perform the major work of this system.</summary>
        /// <remarks>
        /// The system invokes OnUpdate once per frame on the main thread when any of this system's
        /// EntityQueries match existing entities, or if the system has the AlwaysUpdate
        /// attribute.
        ///
        /// To run a Job, create an instance of the Job struct, assign appropriate values to the struct fields and call
        /// one of the Job schedule functions. The system passes any current dependencies between Jobs -- which can include Jobs
        /// internal to this system, such as gathering entities or chunks, as well as Jobs external to this system,
        /// such as Jobs that write to the components read by this system -- in the `inputDeps` parameter. Your function
        /// must combine the input dependencies with any dependencies of the Jobs created in OnUpdate and return the
        /// combined <see cref="JobHandle"/> object.
        /// </remarks>
        /// <param name="inputDeps">Existing dependencies for this system.</param>
        /// <returns>A Job handle that contains the dependencies of the Jobs in this system.</returns>
        protected abstract JobHandle OnUpdate(JobHandle inputDeps);

#if ENABLE_UNITY_COLLECTIONS_CHECKS
        unsafe string CheckJobDependencies(int type)
        {
            var h = m_SafetyManager->GetSafetyHandle(type, true);

            var readerCount = AtomicSafetyHandle.GetReaderArray(h, 0, IntPtr.Zero);
            JobHandle* readers = stackalloc JobHandle[readerCount];
            AtomicSafetyHandle.GetReaderArray(h, readerCount, (IntPtr) readers);

            for (var i = 0; i < readerCount; ++i)
            {
                if (!m_SafetyManager->HasReaderOrWriterDependency(type, readers[i]))
                    return $"The system {GetType()} reads {TypeManager.GetType(type)} via {AtomicSafetyHandle.GetReaderName(h, i)} but that type was not returned as a job dependency. To ensure correct behavior of other systems, the job or a dependency of it must be returned from the OnUpdate method.";
            }

            if (!m_SafetyManager->HasReaderOrWriterDependency(type, AtomicSafetyHandle.GetWriter(h)))
                return $"The system {GetType()} writes {TypeManager.GetType(type)} via {AtomicSafetyHandle.GetWriterName(h)} but that was not returned as a job dependency. To ensure correct behavior of other systems, the job or a dependency of it must be returned from the OnUpdate method.";

            return null;
        }

        unsafe void EmergencySyncAllJobs()
        {
            for (int i = 0;i != m_JobDependencyForReadingSystems.Count;i++)
            {
                int type = m_JobDependencyForReadingSystems.p[i];
                AtomicSafetyHandle.EnforceAllBufferJobsHaveCompleted(m_SafetyManager->GetSafetyHandle(type, true));
            }

            for (int i = 0;i != m_JobDependencyForWritingSystems.Count;i++)
            {
                int type = m_JobDependencyForWritingSystems.p[i];
                AtomicSafetyHandle.EnforceAllBufferJobsHaveCompleted(m_SafetyManager->GetSafetyHandle(type, true));
            }
        }
#endif

        unsafe JobHandle GetDependency ()
        {
            return m_SafetyManager->GetDependency(m_JobDependencyForReadingSystems.p, m_JobDependencyForReadingSystems.Count, m_JobDependencyForWritingSystems.p, m_JobDependencyForWritingSystems.Count);
        }

        unsafe void AddDependencyInternal(JobHandle dependency)
        {
            m_PreviousFrameDependency = m_SafetyManager->AddDependency(m_JobDependencyForReadingSystems.p, m_JobDependencyForReadingSystems.Count, m_JobDependencyForWritingSystems.p, m_JobDependencyForWritingSystems.Count, dependency);
        }


    }

    [Obsolete("BarrierSystem has been renamed. Use EntityCommandBufferSystem instead (UnityUpgradable) -> EntityCommandBufferSystem", true)]
    [System.ComponentModel.EditorBrowsable(EditorBrowsableState.Never)]
    public struct BarrierSystem { }

    /// <summary>
    /// A system that provides <seealso cref="EntityCommandBuffer"/> objects for other systems.
    /// </summary>
    /// <remarks>
    /// Each system that uses the EntityCommandBuffer provided by a command buffer system must call
    /// <see cref="CreateCommandBuffer"/> to create its own command buffer instance. This buffer system executes each of
    /// these separate command buffers in the order that you created them. The commands are executed during this system's
    /// <see cref="OnUpdate"/> function.
    ///
    /// When you write to a command buffer from a Job, you must add the <see cref="JobHandle"/> of that Job to the buffer
    /// system's dependency list with <see cref="AddJobHandleForProducer"/>.
    ///
    /// If you write to a command buffer from a Job that runs in
    /// parallel (and this includes both <see cref="IJobForEach{T0}"/> and <see cref="IJobChunk"/>), you must use the
    /// concurrent version of the command buffer (<seealso cref="EntityCommandBuffer.ToConcurrent"/>).
    ///
    /// Executing the commands in an EntityCommandBuffer invokes the corresponding functions of the
    /// <see cref="EntityManager"/>. Any structural change, such as adding or removing entities, adding or removing
    /// components from entities, or changing shared component values, creates a sync-point in your application.
    /// At a sync point, all Jobs accessing entity components must complete before new Jobs can start. Such sync points
    /// make it difficult for the Job scheduler to fully utilize available computing power. To avoid sync points,
    /// you should use as few entity command buffer systems as possible.
    ///
    /// The default ECS <see cref="World"/> code creates a <see cref="ComponentSystemGroup"/> setup with
    /// three main groups, <see cref="InitializationSystemGroup"/>, <see cref="SimulationSystemGroup"/>, and
    /// <see cref="PresentationSystemGroup"/>. Each of these main groups provides an existing EntityCommandBufferSystem
    /// executed at the start and the end of other, child systems.
    ///
    /// Note that unused command buffers systems do not create sync points because there are no commands to execute and
    /// thus no structural changes created.
    ///
    /// The EntityCommandBufferSystem class is abstract, so you must implement a subclass to create your own
    /// entity command buffer system. However, none of its methods are abstract, so you do not need to implement
    /// your own logic. Typically, you create an EntityCommandBufferSystem subclass to create a named buffer system
    /// for other systems to use and update it at an appropriate place in a custom <see cref="ComponentSystemGroup"/>
    /// setup.</remarks>
    public unsafe abstract class EntityCommandBufferSystem : ComponentSystem
    {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
        private List<EntityCommandBuffer> m_PendingBuffers;
        internal List<EntityCommandBuffer> PendingBuffers
        {
            get { return m_PendingBuffers; }
        }
#else
        private NativeList<EntityCommandBuffer> m_PendingBuffers;
        internal NativeList<EntityCommandBuffer> PendingBuffers
        {
            get { return m_PendingBuffers; }
        }
#endif

        private JobHandle m_ProducerHandle;

        /// <summary>
        /// Creates an <seealso cref="EntityCommandBuffer"/> and adds it to this system's list of command buffers.
        /// </summary>
        /// <remarks>
        /// This buffer system executes its list of command buffers during its <see cref="OnUpdate"/> function in the
        /// order you created the command buffers.
        ///
        /// If you write to a command buffer in a Job, you must add the
        /// Job as a dependency of this system by calling <see cref="AddJobHandleForProducer"/>. The dependency ensures
        /// that the buffer system waits for the Job to complete before executing the command buffer.
        ///
        /// If you write to a command buffer from a parallel Job, such as <see cref="IJobForEach{T0}"/> or
        /// <see cref="IJobChunk"/>, you must use the concurrent version of the command buffer, provided by
        /// <see cref="EntityCommandBuffer.Concurrent"/>.
        /// </remarks>
        /// <returns>A command buffer that will be executed by this system.</returns>
        public EntityCommandBuffer CreateCommandBuffer()
        {
            var cmds = new EntityCommandBuffer(Allocator.TempJob, -1);
#if ENABLE_UNITY_COLLECTIONS_CHECKS
            cmds.SystemID = ms_ExecutingSystem != null ? ms_ExecutingSystem.m_SystemID : 0;
#endif
            m_PendingBuffers.Add(cmds);

            return cmds;
        }

        /// <summary>
        /// Adds the specified JobHandle to this system's list of dependencies.
        /// </summary>
        /// <remarks>
        /// When you write to a command buffer from a Job, you must add the <see cref="JobHandle"/> of that Job to this buffer
        /// system's dependency list by calling this function. Otherwise, the buffer system could execute the commands
        /// currently in the command buffer while the writing Job is still in progress.
        /// </remarks>
        /// <param name="producerJob">The JobHandle of a Job which this buffer system should wait for before playing back its
        /// pending command buffers.</param>
        /// <example>
        /// The following example illustrates how to use one of the default <see cref="EntityCommandBuffer"/> systems.
        /// The code selects all entities that have one custom component, in this case, `AsyncProcessInfo`, and
        /// processes each entity in the `Execute()` function of an <see cref="IJobForEachWithEntity{T0}"/> Job (the
        /// actual process is not shown since that part of the example is hypothetical). After processing, the Job
        /// uses an EntityCommandBuffer to remove the `ProcessInfo` component and add an `ProcessCompleteTag`
        /// component. Another system could use the `ProcessCompleteTag` to find entities that represent the end
        /// results of the process.
        /// <code>
        /// public struct ProcessInfo: IComponentData{ public float Value; }
        /// public struct ProcessCompleteTag : IComponentData{}
        ///
        /// public class AsyncProcessJobSystem : JobComponentSystem
        /// {
        ///     [BurstCompile]
        ///     public struct ProcessInBackgroundJob : IJobForEachWithEntity&lt;ProcessInfo&gt;
        ///     {
        ///         [ReadOnly]
        ///         public EntityCommandBuffer.Concurrent ConcurrentCommands;
        ///
        ///         public void Execute(Entity entity, int index, [ReadOnly] ref ProcessInfo info)
        ///         {
        ///             // Process based on the ProcessInfo component,
        ///             // then remove ProcessInfo and add a ProcessCompleteTag...
        ///
        ///             ConcurrentCommands.RemoveComponent&lt;ProcessInfo&gt;(index, entity);
        ///             ConcurrentCommands.AddComponent(index, entity, new ProcessCompleteTag());
        ///         }
        ///     }
        ///
        ///     protected override JobHandle OnUpdate(JobHandle inputDeps)
        ///     {
        ///         var job = new ProcessInBackgroundJob();
        ///
        ///         var ecbSystem =
        ///             World.GetOrCreateSystem&lt;EndSimulationEntityCommandBufferSystem&gt;();
        ///         job.ConcurrentCommands = ecbSystem.CreateCommandBuffer().ToConcurrent();
        ///
        ///         var handle = job.Schedule(this, inputDeps);
        ///         ecbSystem.AddJobHandleForProducer(handle);
        ///
        ///         return handle;
        ///     }
        /// }
        /// </code>
        /// </example>
        public void AddJobHandleForProducer(JobHandle producerJob)
        {
            m_ProducerHandle = JobHandle.CombineDependencies(m_ProducerHandle, producerJob);
        }

        /// <summary>
        /// Initializes this command buffer system.
        /// </summary>
        /// <remarks>If you override this method, you should call `base.OnCreate()` to retain the default
        /// initialization logic.</remarks>
        protected override void OnCreate()
        {
            base.OnCreate();

#if ENABLE_UNITY_COLLECTIONS_CHECKS
            m_PendingBuffers = new List<EntityCommandBuffer>();
#else
            m_PendingBuffers = new NativeList<EntityCommandBuffer>(Allocator.Persistent);
#endif
        }

        /// <summary>
        /// Destroys this system, executing any pending command buffers first.
        /// </summary>
        /// <remarks>If you override this method, you should call `base.OnDestroy()` to retain the default
        /// destruction logic.</remarks>
        protected override void OnDestroy()
        {
            FlushPendingBuffers(false);
            m_PendingBuffers.Clear();

#if !ENABLE_UNITY_COLLECTIONS_CHECKS
            m_PendingBuffers.Dispose();
#endif

            base.OnDestroy();
        }

        /// <summary>
        /// Executes the command buffers in this system in the order they were created.
        /// </summary>
        /// <remarks>If you override this method, you should call `base.OnUpdate()` to retain the default
        /// update logic.</remarks>
        protected override void OnUpdate()
        {
            FlushPendingBuffers(true);
            m_PendingBuffers.Clear();
        }

        internal void FlushPendingBuffers(bool playBack)
        {
            m_ProducerHandle.Complete();
            m_ProducerHandle = new JobHandle();

            int length;
#if ENABLE_UNITY_COLLECTIONS_CHECKS
            length = m_PendingBuffers.Count;
#else
            length = m_PendingBuffers.Length;
#endif

#if ENABLE_UNITY_COLLECTIONS_CHECKS
            List<string> playbackErrorLog = null;
            bool completeAllJobsBeforeDispose = false;
#endif
            for (int i = 0; i < length; ++i)
            {
                var buffer = m_PendingBuffers[i];
                if (!buffer.IsCreated)
                {
                    continue;
                }
                if (playBack)
                {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
                    try
                    {
                        buffer.Playback(EntityManager);
                    }
                    catch (Exception e)
                    {
                        var system = GetSystemFromSystemID(World, buffer.SystemID);
                        var systemType = system != null ? system.GetType().ToString() : "Unknown";
                        var error = $"{e.Message}\nEntityCommandBuffer was recorded in {systemType} and played back in {GetType()}.\n" + e.StackTrace;
                        if (playbackErrorLog == null)
                        {
                            playbackErrorLog = new List<string>();
                        }
                        playbackErrorLog.Add(error);
                        completeAllJobsBeforeDispose = true;
                    }
#else
                    buffer.Playback(EntityManager);
#endif
                }
#if ENABLE_UNITY_COLLECTIONS_CHECKS
                try
                {
                    if (completeAllJobsBeforeDispose)
                    {
                        // If we get here, there was an error during playback (potentially a race condition on the
                        // buffer itself), and we should wait for all jobs writing to this command buffer to complete before attempting
                        // to dispose of the command buffer to prevent a potential race condition.
                        buffer.WaitForWriterJobs();
                        completeAllJobsBeforeDispose = false;
                    }
                    buffer.Dispose();
                }
                catch (Exception e)
                {
                    var system = GetSystemFromSystemID(World, buffer.SystemID);
                    var systemType = system != null ? system.GetType().ToString() : "Unknown";
                    var error = $"{e.Message}\nEntityCommandBuffer was recorded in {systemType} and disposed in {GetType()}.\n" + e.StackTrace;
                    if (playbackErrorLog == null)
                    {
                        playbackErrorLog = new List<string>();
                    }
                    playbackErrorLog.Add(error);
                }
#else
                buffer.Dispose();
#endif
                m_PendingBuffers[i] = buffer;
            }

#if ENABLE_UNITY_COLLECTIONS_CHECKS
            if (playbackErrorLog != null)
            {
#if !NET_DOTS
                string exceptionMessage = playbackErrorLog.Aggregate((str1, str2) => str1 + "\n" + str2);
#else
                foreach (var err in playbackErrorLog)
                {
                    Console.WriteLine(err);
                }
                string exceptionMessage = "Errors occurred during ECB playback; see stdout";
#endif
                Exception exception = new System.ArgumentException(exceptionMessage);
                throw exception;
            }
#endif
        }
    }
}
