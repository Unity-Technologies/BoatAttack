using System;

namespace Unity.Entities
{
    public sealed unsafe partial class EntityManager
    {
        // ----------------------------------------------------------------------------------------------------------
        // PUBLIC
        // ----------------------------------------------------------------------------------------------------------
        
        //@TODO: Not clear to me what this method is really for...
        /// <summary>
        /// Waits for all Jobs to complete.
        /// </summary>
        /// <remarks>Calling CompleteAllJobs() blocks the main thread until all currently running Jobs finish.</remarks>
        public void CompleteAllJobs()
        {
            ComponentJobSafetyManager->CompleteAllJobsAndInvalidateArrays();
        }

        // ----------------------------------------------------------------------------------------------------------
        // INTERNAL
        // ----------------------------------------------------------------------------------------------------------

        private void BeforeStructuralChange()
        {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
            if (ComponentJobSafetyManager->IsInTransaction)
                throw new InvalidOperationException(
                    "Access to EntityManager is not allowed after EntityManager.BeginExclusiveEntityTransaction(); has been called.");

            if (m_InsideForEach != 0)
                throw new InvalidOperationException(
                    "EntityManager.AddComponent/RemoveComponent/CreateEntity/DestroyEntity are not allowed during Entities.ForEach. Please use PostUpdateCommandBuffer to delay applying those changes until after ForEach.");

#endif
            ComponentJobSafetyManager->CompleteAllJobsAndInvalidateArrays();
        }
    }
}
