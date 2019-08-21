using System;
using System.Diagnostics;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace Unity.Entities
{
    /// <summary>
    /// An EntityArchetype is a unique combination of component types. The <see cref="EntityManager"/>
    /// uses the archetype to group all entities that have the same sets of components.
    /// </summary>
    /// <remarks>
    /// An entity can change archetype fluidly over its lifespan. For example, when you add or
    /// remove components, the archetype of the affected entity changes.
    ///
    /// An archetype object is not a container; rather it is an identifier to each unique combination
    /// of component types that an application has created at run time, either directly or implicitly.
    ///
    /// You can create archetypes directly using <see cref="EntityManager.CreateArchetype(ComponentType[])"/>.
    /// You also implicitly create archetypes whenever you add or remove a component from an entity. An EntityArchetype
    /// object is an immutable singleton; creating an archetype with the same set of components, either directly or
    /// implicitly, results in the same archetype for a given EntityManager.
    ///
    /// The ECS framework uses archetypes to group entities that have the same structure together. The ECS framework
    /// stores component data in blocks of memory called *chunks*. A given chunk stores only entities having the same
    /// archetype. You can get the EntityArchetype object for a chunk from its <see cref="ArchetypeChunk.Archetype"/>
    /// property.
    /// </remarks>
    [DebuggerTypeProxy(typeof(EntityArchetypeDebugView))]
    public unsafe struct EntityArchetype : IEquatable<EntityArchetype>
    {
        [NativeDisableUnsafePtrRestriction] internal Archetype* Archetype;

        /// <summary>
        /// Reports whether this EntityArchetype instance references a non-null archetype.
        /// </summary>
        /// <value>True, if the archetype is valid.</value>
        public bool Valid => Archetype != null;

        /// <summary>
        /// Compares the archetypes for equality.
        /// </summary>
        /// <param name="lhs">A EntityArchetype object.</param>
        /// <param name="rhs">Another EntityArchetype object.</param>
        /// <returns>True, if these EntityArchetype instances reference the same archetype.</returns>
        public static bool operator ==(EntityArchetype lhs, EntityArchetype rhs)
        {
            return lhs.Archetype == rhs.Archetype;
        }

        /// <summary>
        /// Compares the archetypes for inequality.
        /// </summary>
        /// <param name="lhs">A EntityArchetype object.</param>
        /// <param name="rhs">Another EntityArchetype object.</param>
        /// <returns>True, if these EntityArchetype instances reference different archetypes.</returns>
        public static bool operator !=(EntityArchetype lhs, EntityArchetype rhs)
        {
            return lhs.Archetype != rhs.Archetype;
        }

        /// <summary>
        /// Reports whether this EntityArchetype references the same archetype as another object.
        /// </summary>
        /// <param name="compare">The object to compare.</param>
        /// <returns>True, if the compare parameter is a EntityArchetype instance that points to the same
        /// archetype.</returns>
        public override bool Equals(object compare)
        {
            return this == (EntityArchetype) compare;
        }

        /// <summary>
        /// Compares archetypes for equality.
        /// </summary>
        /// <param name="entityArchetype">The EntityArchetype to compare.</param>
        /// <returns>Returns true, if both EntityArchetype instances reference the same archetype.</returns>
        public bool Equals(EntityArchetype entityArchetype)
        {
            return Archetype == entityArchetype.Archetype;
        }

        /// <summary>
        /// Returns the hash of the archetype.
        /// </summary>
        /// <remarks>Two EntityArchetype instances referencing the same archetype return the same hash.</remarks>
        /// <returns>An integer hash code.</returns>
        public override int GetHashCode()
        {
            return (int) Archetype;
        }

        /// <summary>
        /// Gets the types of the components making up this archetype.
        /// </summary>
        /// <remarks>The set of component types in an archetype cannot change; adding components to an entity or
        /// removing components from an entity changes the archetype of that entity (possibly resulting in the
        /// creation of a new archetype). The original archetype remains unchanged.</remarks>
        /// <param name="allocator">The allocation type to use for the returned NativeArray.</param>
        /// <returns>A native array containing the <see cref="ComponentType"/> objects of this archetype.</returns>
        public NativeArray<ComponentType> GetComponentTypes(Allocator allocator = Allocator.Temp)
        {
            var types = new NativeArray<ComponentType>(Archetype->TypesCount, allocator);
            for (var i = 0; i < types.Length; ++i)
                types[i] = Archetype->Types[i].ToComponentType();
            return types;
        }

        /// <summary>
        /// The current number of chunks storing entities having this archetype.
        /// </summary>
        /// <value>The number of chunks.</value>
        /// <remarks>This value can change whenever structural changes occur.
        /// Structural changes include creating or destroying entities, adding components to or removing them from
        /// an entity, and changing the value of shared components, all of which alter where entities are stored.
        /// </remarks>
        public int ChunkCount => Archetype->Chunks.Count;

        /// <summary>
        /// The number of entities having this archetype that can fit into a single chunk of memory.
        /// </summary>
        /// <value>Capacity is determined by the fixed, 16KB size of the memory blocks allocated by the ECS framework
        /// and the total storage size of all the component types in the archetype.</value>
        public int ChunkCapacity => Archetype->ChunkCapacity;
    }

}
