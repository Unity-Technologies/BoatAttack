namespace Unity.Entities
{
    public sealed unsafe partial class EntityManager
    {
        // ----------------------------------------------------------------------------------------------------------
        // PUBLIC
        // ----------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Begins an exclusive entity transaction, which allows you to make structural changes inside a Job.
        /// </summary>
        /// <remarks>
        /// <see cref="ExclusiveEntityTransaction"/> allows you to create & destroy entities from a job. The purpose is
        /// to enable procedural generation scenarios where instantiation on big scale must happen on jobs. As the
        /// name implies it is exclusive to any other access to the EntityManager.
        ///
        /// An exclusive entity transaction should be used on a manually created <see cref="World"/> that acts as a
        /// staging area to construct and setup entities.
        ///
        /// After the job has completed you can end the transaction and use
        /// <see cref="MoveEntitiesFrom(EntityManager)"/> to move the entities to an active <see cref="World"/>.
        /// </remarks>
        /// <returns>A transaction object that provides an functions for making structural changes.</returns>
        public ExclusiveEntityTransaction BeginExclusiveEntityTransaction()
        {
            ComponentJobSafetyManager->BeginExclusiveTransaction();
#if ENABLE_UNITY_COLLECTIONS_CHECKS
            m_ExclusiveEntityTransaction.SetAtomicSafetyHandle(ComponentJobSafetyManager->ExclusiveTransactionSafety);
#endif
            return m_ExclusiveEntityTransaction;
        }

        /// <summary>
        /// Ends an exclusive entity transaction.
        /// </summary>
        /// <seealso cref="ExclusiveEntityTransaction"/>
        /// <seealso cref="BeginExclusiveEntityTransaction()"/>
        public void EndExclusiveEntityTransaction()
        {
            ComponentJobSafetyManager->EndExclusiveTransaction();
        }
        
        // ----------------------------------------------------------------------------------------------------------
        // INTERNAL
        // ----------------------------------------------------------------------------------------------------------
 
    }
}
