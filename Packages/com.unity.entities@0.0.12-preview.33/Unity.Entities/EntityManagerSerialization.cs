using Unity.Assertions;

namespace Unity.Entities
{
    public sealed unsafe partial class EntityManager
    {
        // ----------------------------------------------------------------------------------------------------------
        // PUBLIC
        // ----------------------------------------------------------------------------------------------------------

        // @TODO documentation for serialization/deserialization
        /// <summary>
        /// Prepares an empty <see cref="World"/> to load serialized entities.
        /// </summary>
        public void PrepareForDeserialize()
        {
            Assert.AreEqual(0, Debug.EntityCount);
            m_ManagedComponentStore.PrepareForDeserialize();
        }
        
        // ----------------------------------------------------------------------------------------------------------
        // INTERNAL
        // ----------------------------------------------------------------------------------------------------------
   
    }
}
