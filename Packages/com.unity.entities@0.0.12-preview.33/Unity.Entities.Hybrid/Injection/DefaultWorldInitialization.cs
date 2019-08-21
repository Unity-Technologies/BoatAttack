using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
#if UNITY_2019_3_OR_NEWER
using UnityEngine.LowLevel;
using UnityEngine.PlayerLoop;
#else
using UnityEngine.Experimental.LowLevel;
using UnityEngine.Experimental.PlayerLoop;
#endif

namespace Unity.Entities
{
    public interface ICustomBootstrap
    {
        // returns the systems which should be handled by the default bootstrap process
        // if null is returned the default world will not be created at all, empty list creates default world and entrypoints
        List<Type> Initialize(List<Type> systems);
    }

    public static class DefaultWorldInitialization
    {
        static void DomainUnloadShutdown()
        {
            World.DisposeAllWorlds();

            WordStorage.Instance.Dispose();
            WordStorage.Instance = null;
            ScriptBehaviourUpdateOrder.UpdatePlayerLoop(null);
        }

        static ComponentSystemBase GetOrCreateManagerAndLogException(World world, Type type)
        {
            try
            {
                return world.GetOrCreateSystem(type);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                return null;
            }
        }

        public static void Initialize(string worldName, bool editorWorld)
        {
            PlayerLoopManager.RegisterDomainUnload(DomainUnloadShutdown, 10000);

            var world = new World(worldName);
            World.Active = world;
            var systems = GetAllSystems(WorldSystemFilterFlags.Default);
            if (systems == null)
            {
                world.Dispose();
                if (World.Active == world)
                {
                    World.Active = null;
                }
                return;
            }

            // create presentation system and simulation system
            InitializationSystemGroup initializationSystemGroup = world.GetOrCreateSystem<InitializationSystemGroup>();
            SimulationSystemGroup simulationSystemGroup = world.GetOrCreateSystem<SimulationSystemGroup>();
            PresentationSystemGroup presentationSystemGroup = world.GetOrCreateSystem<PresentationSystemGroup>();
            // Add systems to their groups, based on the [UpdateInGroup] attribute.
            foreach (var type in systems)
            {
                // Skip the built-in root-level systems
                if (type == typeof(InitializationSystemGroup) ||
                    type == typeof(SimulationSystemGroup) ||
                    type == typeof(PresentationSystemGroup))
                {
                    continue;
                }
                if (editorWorld)
                {
                    if (Attribute.IsDefined(type, typeof(ExecuteInEditMode)))
                        Debug.LogError(
                            $"{type} is decorated with {typeof(ExecuteInEditMode)}. Support for this attribute will be deprecated. Please use {typeof(ExecuteAlways)} instead.");
                    if (!Attribute.IsDefined(type, typeof(ExecuteAlways)))
                        continue;
                }

                var groups = type.GetCustomAttributes(typeof(UpdateInGroupAttribute), true);
                if (groups.Length == 0)
                {
                    simulationSystemGroup.AddSystemToUpdateList(GetOrCreateManagerAndLogException(world, type) as ComponentSystemBase);
                }

                foreach (var g in groups)
                {
                    var group = g as UpdateInGroupAttribute;
                    if (group == null)
                        continue;

                    if (!(typeof(ComponentSystemGroup)).IsAssignableFrom(group.GroupType))
                    {
                        Debug.LogError($"Invalid [UpdateInGroup] attribute for {type}: {group.GroupType} must be derived from ComponentSystemGroup.");
                        continue;
                    }

                    var groupMgr = GetOrCreateManagerAndLogException(world, group.GroupType);
                    if (groupMgr == null)
                    {
                        Debug.LogWarning(
                            $"Skipping creation of {type} due to errors creating the group {group.GroupType}. Fix these errors before continuing.");
                        continue;
                    }
                    var groupSys = groupMgr as ComponentSystemGroup;
                    if (groupSys != null)
                    {
                        groupSys.AddSystemToUpdateList(GetOrCreateManagerAndLogException(world, type) as ComponentSystemBase);
                    }
                }
            }

            // Update player loop
            initializationSystemGroup.SortSystemUpdateList();
            simulationSystemGroup.SortSystemUpdateList();
            presentationSystemGroup.SortSystemUpdateList();
            ScriptBehaviourUpdateOrder.UpdatePlayerLoop(world);
        }

        public static void DefaultLazyEditModeInitialize()
        {
#if UNITY_EDITOR
            if (World.Active == null)
            {
                // * OnDisable (Serialize monobehaviours in temporary backup)
                // * unload domain
                // * load new domain
                // * OnEnable (Deserialize monobehaviours in temporary backup)
                // * mark entered playmode / load scene
                // * OnDisable / OnDestroy
                // * OnEnable (Loading object from scene...)
                if (UnityEditor.EditorApplication.isPlayingOrWillChangePlaymode)
                {
                    // We are just gonna ignore this enter playmode reload.
                    // Can't see a situation where it would be useful to create something inbetween.
                    // But we really need to solve this at the root. The execution order is kind if crazy.
                    if (UnityEditor.EditorApplication.isPlaying)
                        Debug.LogError("Loading GameObjectEntity in Playmode but there is no active World");
                }
                else
                {
#if !UNITY_DISABLE_AUTOMATIC_SYSTEM_BOOTSTRAP
                    Initialize("Editor World", true);
#endif
                }
            }
#endif
        }

        public static List<Type> GetAllSystems(WorldSystemFilterFlags filterFlags)
        {
            var systemTypes = new List<Type>();
            ICustomBootstrap bootstrap = null;

            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (!TypeManager.IsAssemblyReferencingEntities(assembly))
                    continue;

                IReadOnlyList<Type> allTypes;
                try
                {
                    allTypes = assembly.GetTypes();
                }
                catch (ReflectionTypeLoadException e)
                {
                    allTypes = e.Types.Where(t => t != null).ToList();
                    Debug.LogWarning(
                        $"DefaultWorldInitialization failed loading assembly: {(assembly.IsDynamic ? assembly.ToString() : assembly.Location)}");
                }

                var bootstrapTypes = allTypes.Where(t =>
                    typeof(ICustomBootstrap).IsAssignableFrom(t) &&
                    !t.IsAbstract &&
                    !t.ContainsGenericParameters);

                // TODO: should multiple bootstrap classes be allowed?
                foreach (var boot in bootstrapTypes)
                {
                    if (bootstrap == null)
                        bootstrap = Activator.CreateInstance(boot) as ICustomBootstrap;
                    else
                    {
                        Debug.LogError("Multiple custom bootstrappers specified, ignoring " + boot);
                    }
                }

                // the entire assembly can be marked for no-auto-creation (test assemblies are good candidates for this)
                var disableAllAutoCreation = assembly.GetCustomAttribute<DisableAutoCreationAttribute>() != null;

                bool FilterSystemType(Type type)
                {
                    // IMPORTANT: keep this logic in sync with SystemTypeGen.cs for DOTS Runtime

                    var disableTypeAutoCreation = type.GetCustomAttribute<DisableAutoCreationAttribute>(false) != null;

                    // only derivatives of ComponentSystemBase are systems
                    if (!type.IsSubclassOf(typeof(ComponentSystemBase)))
                    {
                        if (disableTypeAutoCreation)
                            Debug.LogWarning($"Invalid [DisableAutoCreation] on {type.FullName} (only makes sense for {nameof(ComponentSystemBase)}-derived types)");

                        return false;
                    }

                    // these types obviously cannot be instantiated
                    if (type.IsAbstract || type.ContainsGenericParameters)
                    {
                        if (disableTypeAutoCreation)
                            Debug.LogWarning($"Invalid [DisableAutoCreation] on {type.FullName} (only concrete types can be instantiated)");

                        return false;
                    }

                    // the auto-creation system instantiates using the default ctor, so if we can't find one, exclude from list
                    if (type.GetConstructors().All(c => c.GetParameters().Length != 0))
                    {
                        // we want users to be explicit
                        if (!disableTypeAutoCreation && !disableAllAutoCreation)
                            Debug.LogWarning($"Missing default ctor on {type.FullName} (or if you don't want this to be auto-creatable, tag it with [DisableAutoCreation])");

                        return false;
                    }

                    if (disableTypeAutoCreation || disableAllAutoCreation)
                    {
                        if (disableTypeAutoCreation && disableAllAutoCreation)
                            Debug.LogWarning($"Redundant [DisableAutoCreation] on {type.FullName} (attribute is already present on assembly {assembly.GetName().Name}");

                        return false;
                    }

                    var systemFlags = WorldSystemFilterFlags.Default;
                    var attrib = type.GetCustomAttribute<WorldSystemFilterAttribute>(true);
                    if (attrib != null)
                        systemFlags = attrib.FilterFlags;

                    return (filterFlags & systemFlags) != 0;
                }

                systemTypes.AddRange(allTypes.Where(FilterSystemType));
            }

            if (bootstrap != null)
            {
                systemTypes = bootstrap.Initialize(systemTypes);
            }

            return systemTypes;
        }
    }
}
