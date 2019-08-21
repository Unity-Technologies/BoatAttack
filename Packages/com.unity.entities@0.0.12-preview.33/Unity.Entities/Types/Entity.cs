using System;

namespace Unity.Entities
{
    /// <summary>
    /// Identifies an entity.
    /// </summary>
    /// <remarks>
    /// The entity is a fundamental part of the Entity Component System. Everything in your game that has data or an
    /// identity of its own is an entity. However, an entity does not contain either data or behavior itself. Instead,
    /// the data is stored in the components and the behavior is provided by the systems that process those
    /// components. The entity acts as an identifier or key to the data stored in components.
    ///
    /// Entities are managed by the <see cref="EntityManager"/> class and exist within a <see cref="World"/>. An
    /// Entity struct refers to an entity, but is not a reference. Rather the Entity struct contains an
    /// <see cref="Index"/> used to access entity data and a <see cref="Version"/> used to check whether the Index is
    /// still valid. Note that you generally do not use the Index or Version values directly, but instead pass the
    /// Entity struct to the relevant API methods.
    ///
    /// Pass an Entity struct to methods of the <see cref="EntityManager"/>, the <see cref="EntityCommandBuffer"/>,
    /// or the <see cref="ComponentSystem"/> in order to add or remove components, to access components, or to destroy
    /// the entity.
    /// </remarks>
    public struct Entity : IEquatable<Entity>
    {
        /// <summary>
        /// The ID of an entity.
        /// </summary>
        /// <value>The index into the internal list of entities.</value>
        /// <remarks>
        /// Entity indexes are recycled when an entity is destroyed. When an entity is destroyed, the
        /// EntityManager increments the version identifier. To represent the same entity, both the Index and the
        /// Version fields of the Entity object must match. If the Index is the same, but the Version is different,
        /// then the entity has been recycled.
        /// </remarks>
        public int Index;
        /// <summary>
        /// The generational version of the entity.
        /// </summary>
        /// <remarks>The Version number can, theoretically, overflow and wrap around within the lifetime of an
        /// application. For this reason, you cannot assume that an Entity instance with a larger Version is a more
        /// recent incarnation of the entity than one with a smaller Version (and the same Index).</remarks>
        /// <value>Used to determine whether this Entity object still identifies an existing entity.</value>
        public int Version;

        /// <summary>
        /// Entity instances are equal if they refer to the same entity.
        /// </summary>
        /// <param name="lhs">An Entity object.</param>
        /// <param name="rhs">Another Entity object.</param>
        /// <returns>True, if both Index and Version are identical.</returns>
        public static bool operator ==(Entity lhs, Entity rhs)
        {
            return lhs.Index == rhs.Index && lhs.Version == rhs.Version;
        }

        /// <summary>
        /// Entity instances are equal if they refer to the same entity.
        /// </summary>
        /// <param name="lhs">An Entity object.</param>
        /// <param name="rhs">Another Entity object.</param>
        /// <returns>True, if either Index or Version are different.</returns>
        public static bool operator !=(Entity lhs, Entity rhs)
        {
            return !(lhs == rhs);
        }

        /// <summary>
        /// Entity instances are equal if they refer to the same entity.
        /// </summary>
        /// <param name="compare">The object to compare to this Entity.</param>
        /// <returns>True, if the compare parameter contains an Entity object having the same Index and Version
        /// as this Entity.</returns>
        public override bool Equals(object compare)
        {
            return this == (Entity) compare;
        }

        /// <summary>
        /// A hash used for comparisons.
        /// </summary>
        /// <returns>A unique hash code.</returns>
        public override int GetHashCode()
        {
            return Index;
        }

        /// <summary>
        /// A "blank" Entity object that does not refer to an actual entity.
        /// </summary>
        public static Entity Null => new Entity();

        /// <summary>
        /// Entity instances are equal if they represent the same entity.
        /// </summary>
        /// <param name="entity">The other Entity.</param>
        /// <returns>True, if the Entity instances have the same Index and Version.</returns>
        public bool Equals(Entity entity)
        {
            return entity.Index == Index && entity.Version == Version;
        }

        /// <summary>
        /// Provides a debugging string.
        /// </summary>
        /// <returns>A string containing the entity index and generational version.</returns>
        public override string ToString()
        {
            return Equals(Entity.Null) ? "Entity.Null" : $"Entity({Index}:{Version})";
        }
    }
}
