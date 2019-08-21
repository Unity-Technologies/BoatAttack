using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;

namespace Unity.Entities
{
    public partial class World : IDisposable
    {
        public static World Active { get; set; }

        static readonly List<World> allWorlds = new List<World>();

#if UNITY_DOTSPLAYER
        public static World[] AllWorlds => allWorlds.ToArray();
        public ComponentSystemBase[] Systems => m_Systems.ToArray();

        List<ComponentSystemBase> m_Systems = new List<ComponentSystemBase>();
#else
        public static ReadOnlyCollection<World> AllWorlds => new ReadOnlyCollection<World>(allWorlds);
        public IEnumerable<ComponentSystemBase> Systems => new ReadOnlyCollection<ComponentSystemBase>(m_Systems);

        Dictionary<Type, ComponentSystemBase> m_SystemLookup = new Dictionary<Type, ComponentSystemBase>();
        List<ComponentSystemBase> m_Systems = new List<ComponentSystemBase>();
#endif
#if ENABLE_UNITY_COLLECTIONS_CHECKS
        bool m_AllowGetSystem = true;
#endif

        private EntityManager m_EntityManager;
        ulong m_SequenceNumber;

        static int ms_SystemIDAllocator = 0;
        static ulong ms_NextSequenceNumber = 0;

        public string Name { get; }

        public override string ToString()
        {
            return Name;
        }

        public int Version { get; private set; }

        public EntityManager EntityManager => m_EntityManager;

        public bool IsCreated => m_Systems != null;

        public ulong SequenceNumber => m_SequenceNumber;

        public World(string name)
        {
            m_SequenceNumber = ms_NextSequenceNumber;
            ms_NextSequenceNumber++;

            // Debug.LogError("Create World "+ name + " - " + GetHashCode());
            Name = name;
            allWorlds.Add(this);

            m_EntityManager = new EntityManager(this);
        }

        public void Dispose()
        {
            if (!IsCreated)
                throw new ArgumentException("The World has already been Disposed.");
            // Debug.LogError("Dispose World "+ Name + " - " + GetHashCode());

            if (allWorlds.Contains(this))
                allWorlds.Remove(this);

#if ENABLE_UNITY_COLLECTIONS_CHECKS
            m_AllowGetSystem = false;
#endif
            // Destruction should happen in reverse order to construction
            for (int i = m_Systems.Count - 1; i >= 0; --i)
            {
                try
                {
                    m_Systems[i].DestroyInstance();
                }
                catch (Exception e)
                {
                    Debug.LogException(e);
                }
            }

            // Destroy EntityManager last
            m_EntityManager.DestroyInstance();
            m_EntityManager = null;

            m_Systems.Clear();
            m_Systems = null;

#if !UNITY_DOTSPLAYER
            m_SystemLookup.Clear();
            m_SystemLookup = null;
#endif

            if (Active == this)
                Active = null;
        }

        public static void DisposeAllWorlds()
        {
            while (allWorlds.Count != 0)
                allWorlds[0].Dispose();
        }

        void AddTypeLookup(Type type, ComponentSystemBase system)
        {
#if !UNITY_DOTSPLAYER
            while (type != typeof(ComponentSystemBase))
            {
                if (!m_SystemLookup.ContainsKey(type))
                    m_SystemLookup.Add(type, system);

                type = type.BaseType;
            }
#endif
        }


#if UNITY_DOTSPLAYER
        private ComponentSystemBase CreateSystemInternal<T>() where T : new()
        {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
            if (!m_AllowGetSystem)
                throw new ArgumentException(
                    "During destruction of a system you are not allowed to create more systems.");

            m_AllowGetSystem = true;
#endif
            ComponentSystemBase system;
            try
            {
#if !NET_DOTS
                system = new T() as ComponentSystemBase;
#else
                system = TypeManager.ConstructSystem(typeof(T));
#endif
            }
            catch
            {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
                m_AllowGetSystem = false;
#endif
                throw;
            }

            return AddSystem(system);
        }

        private ComponentSystemBase GetExistingSystemInternal<T>()
        {
            return GetExistingSystem(typeof(T));
        }

        private ComponentSystemBase GetExistingSystemInternal(Type type)
        {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
            if (!IsCreated)
                throw new ArgumentException("During destruction ");
            if (!m_AllowGetSystem)
                throw new ArgumentException(
                    "During destruction of a system you are not allowed to get or create more systems.");
#endif

            for (int i = 0; i < m_Systems.Count; ++i) {
                var mgr = m_Systems[i];
                if (type.IsAssignableFrom(mgr.GetType()))
                    return mgr;
            }

            return null;
        }

        private ComponentSystemBase GetOrCreateSystemInternal<T>() where T : new()
        {
            var system = GetExistingSystemInternal<T>();
            return system ?? CreateSystemInternal<T>();
        }

        public T CreateSystem<T>() where T : ComponentSystemBase, new()
        {
            return (T) CreateSystemInternal<T>();
        }

        public T GetOrCreateSystem<T>() where T : ComponentSystemBase, new()
        {
            return (T) GetOrCreateSystemInternal<T>();
        }

#else
        ComponentSystemBase CreateSystemInternal(Type type, object[] constructorArguments)
        {
            if (!typeof(ComponentSystemBase).IsAssignableFrom(type))
            {
                throw new ArgumentException($"Type {type} must be derived from ComponentSystem or JobComponentSystem.");
            }

#if ENABLE_UNITY_COLLECTIONS_CHECKS

            if (constructorArguments != null && constructorArguments.Length != 0)
            {
                var constructors =
                    type.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                if (constructors.Length == 1 && constructors[0].IsPrivate)
                    throw new MissingMethodException(
                        $"Constructing {type} failed because the constructor was private, it must be public.");
            }

            m_AllowGetSystem = false;
#endif
            ComponentSystemBase system;
            try
            {
                system = Activator.CreateInstance(type, constructorArguments) as ComponentSystemBase;
            }
            catch (MissingMethodException)
            {
                throw new MissingMethodException($"Constructing {type} failed because CreateSystem " +
                                $"parameters did not match its constructor.  [Job]ComponentSystem {type} must " +
                                "be mentioned in a link.xml file, or annotated with a [Preserve] attribute to " +
                                "prevent its constructor from being stripped.  See " +
                                "https://docs.unity3d.com/Manual/ManagedCodeStripping.html for more information.");
            }
            finally
            {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
                m_AllowGetSystem = true;
#endif
            }

            return AddSystem(system);
        }

        ComponentSystemBase GetExistingSystemInternal(Type type)
        {
            ComponentSystemBase system;
            if (m_SystemLookup.TryGetValue(type, out system))
                return system;

            return null;
        }

        ComponentSystemBase GetOrCreateSystemInternal(Type type)
        {
            var system = GetExistingSystemInternal(type);

            return system ?? CreateSystemInternal(type, null);
        }

        public ComponentSystemBase CreateSystem(Type type, params object[] constructorArguments)
        {
            CheckGetOrCreateSystem();

            return CreateSystemInternal(type, constructorArguments);
        }

        public T CreateSystem<T>(params object[] constructorArguments) where T : ComponentSystemBase
        {
            CheckGetOrCreateSystem();

            return (T) CreateSystemInternal(typeof(T), constructorArguments);
        }

        public T GetOrCreateSystem<T>() where T : ComponentSystemBase
        {
            CheckGetOrCreateSystem();

            return (T) GetOrCreateSystemInternal(typeof(T));
        }

        public ComponentSystemBase GetOrCreateSystem(Type type)
        {
            CheckGetOrCreateSystem();

            return GetOrCreateSystemInternal(type);
        }
#endif

        private void RemoveSystemInternal(ComponentSystemBase system)
        {
            if (!m_Systems.Remove(system))
                throw new ArgumentException($"System does not exist in the world");
            ++Version;

#if !UNITY_DOTSPLAYER
            var type = system.GetType();
            while (type != typeof(ComponentSystemBase))
            {
                if (m_SystemLookup[type] == system)
                {
                    m_SystemLookup.Remove(type);

                    foreach (var otherSystem in m_Systems)
                        if (otherSystem.GetType().IsSubclassOf(type))
                            AddTypeLookup(otherSystem.GetType(), otherSystem);
                }

                type = type.BaseType;
            }
#endif
        }

        void CheckGetOrCreateSystem()
        {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
            if (!IsCreated)
                throw new ArgumentException("The World has already been Disposed.");
            if (!m_AllowGetSystem)
                throw new ArgumentException(
                    "You are not allowed to get or create more systems during destruction and constructor of a system.");
#endif
        }

        void CheckCreated()
        {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
            if (!IsCreated)
                throw new ArgumentException("The World has already been Disposed.");
#endif
        }


        public T AddSystem<T>(T system) where T : ComponentSystemBase
        {
            CheckGetOrCreateSystem();

            m_Systems.Add(system);
            AddTypeLookup(system.GetType(), system);

            try
            {
                system.CreateInstance(this);
            }
            catch
            {
                RemoveSystemInternal(system);
                throw;
            }
            ++Version;
            return system;
        }

        public T GetExistingSystem<T>() where T : ComponentSystemBase
        {
            CheckGetOrCreateSystem();

            return (T) GetExistingSystemInternal(typeof(T));
        }

        public ComponentSystemBase GetExistingSystem(Type type)
        {
            CheckGetOrCreateSystem();

            return GetExistingSystemInternal(type);
        }

        public void DestroySystem(ComponentSystemBase system)
        {
            CheckGetOrCreateSystem();

            RemoveSystemInternal(system);
            system.DestroyInstance();
        }

        internal static int AllocateSystemID()
        {
            return ++ms_SystemIDAllocator;
        }

        public bool QuitUpdate { get; set; }

        public void Update()
        {
            InitializationSystemGroup initializationSystemGroup =
                GetExistingSystem(typeof(InitializationSystemGroup)) as InitializationSystemGroup;
            SimulationSystemGroup simulationSystemGroup =
                GetExistingSystem(typeof(SimulationSystemGroup)) as SimulationSystemGroup;
            PresentationSystemGroup presentationSystemGroup =
                GetExistingSystem(typeof(PresentationSystemGroup)) as PresentationSystemGroup;

            initializationSystemGroup?.Update();
            simulationSystemGroup?.Update();
            presentationSystemGroup?.Update();
        }
    }
}
