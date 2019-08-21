//#define WRITE_LOG

using System;
using UnityEngine;

namespace Unity.Entities
{
    public delegate void ConfigInit(World world);

    public static class DefaultTinyWorldInitialization
    {
        /// <summary>
        /// Initialize the Tiny World with all the boilerplate that needs to be done.
        /// ComponentSystems will be created and sorted into the high level ComponentSystemGroups.
        /// </summary>
        /// <remarks>
        /// The simple use case is:
        /// <code>
        /// world = DefaultTinyWorldInitialization.InitializeWorld("main");
        /// </code>
        /// However, it's common to need to set initialization data. That can be
        /// done with the following code:
        ///
        /// <code>
        ///   world = DefaultTinyWorldInitialization.InitializeWorld("main");
        ///   TinyEnvironment env = world.TinyEnvironment();
        ///   // set configuration variables...
        ///   DefaultTinyWorldInitialization.InitializeSystems(world);
        /// </code>
        /// </remarks>
        /// <seealso cref="InitializeWorld"/>
        /// <seealso cref="InitializeSystems"/>
        public static World Initialize(string worldName)
        {
            World world = InitializeWorld(worldName);
            InitializeSystems(world);
            // Note that System sorting is done by the individual ComponentSystemGroups, as needed.
            return world;
        }

        /// <summary>
        /// Initialize the World object. See <see cref="Initialize"/> for use.
        /// </summary>
        public static World InitializeWorld(string worldName)
        {
            var world = new World(worldName);
            World.Active = world;
            return world;
        }

        /// <summary>
        /// Initialize the ComponentSystems. See <see cref="Initialize"/> for use.
        /// </summary>
        public static void InitializeSystems(World world)
        {
            var allSystemTypes = TypeManager.GetSystems();
            var allSystemNames = TypeManager.SystemNames;

            if (allSystemTypes.Length == 0)
            {
                throw new InvalidOperationException("DefaultTinyWorldInitialization: No Systems found.");
            }

            // Create top level presentation system and simulation systems.
            InitializationSystemGroup initializationSystemGroup = new InitializationSystemGroup();
            world.AddSystem(initializationSystemGroup);

            SimulationSystemGroup simulationSystemGroup = new SimulationSystemGroup();
            world.AddSystem(simulationSystemGroup);

            PresentationSystemGroup presentationSystemGroup = new PresentationSystemGroup();
            world.AddSystem(presentationSystemGroup);

            // Create the working set of systems.
#if WRITE_LOG
            Console.WriteLine("--- Adding systems:");
#endif

            for (int i = 0; i < allSystemTypes.Length; i++)
            {
                if (TypeManager.GetSystemAttributes(allSystemTypes[i], typeof(DisableAutoCreationAttribute)).Length > 0)
                    continue;
                if (allSystemTypes[i] == initializationSystemGroup.GetType() ||
                    allSystemTypes[i] == simulationSystemGroup.GetType() ||
                    allSystemTypes[i] == presentationSystemGroup.GetType())
                {
                    continue;
                }

                // Subtle issue. If the System was created by GetOrCreateSystem at the "right" time
                // before its own initialization, then it will exist. GetExistingSystem will return a valid
                // object. BUT, that object will not have been put into a SystemGroup.
                var sys = world.GetExistingSystem(allSystemTypes[i]);
                if (sys != null)
                {
                    AddSystemToGroup(world, sys);
                    continue;
                }

#if WRITE_LOG
                Console.WriteLine(allSystemNames[i]);
#endif
                AddSystem(world, TypeManager.ConstructSystem(allSystemTypes[i]));
            }
        }

        /// <summary>
        /// Call this to add a System that was manually constructed; normally these
        /// Systems are marked with [DisableAutoCreation].
        /// </summary>
        public static void AddSystem(World world, ComponentSystemBase system)
        {
            if (world.GetExistingSystem(system.GetType()) != null)
                throw new ArgumentException("AddSystem: Error to add a duplicate system.");

            world.AddSystem(system);
            AddSystemToGroup(world, system);
        }


        private static void AddSystemToGroup(World world, ComponentSystemBase system)
        {
            var groups = TypeManager.GetSystemAttributes(system.GetType(), typeof(UpdateInGroupAttribute));
            if (groups.Length == 0)
            {
                var simulationSystemGroup = world.GetExistingSystem<SimulationSystemGroup>();
                simulationSystemGroup.AddSystemToUpdateList(system);
            }

            for (int g = 0; g < groups.Length; ++g)
            {
                var groupType = groups[g] as UpdateInGroupAttribute;
                var groupSystem = world.GetExistingSystem(groupType.GroupType) as ComponentSystemGroup;
                if (groupSystem == null)
                    throw new Exception("AddSystem failed to find existing SystemGroup.");

                groupSystem.AddSystemToUpdateList(system);
            }
        }
    }
}
