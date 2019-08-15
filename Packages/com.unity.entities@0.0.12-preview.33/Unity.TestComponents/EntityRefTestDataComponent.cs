using System.Collections.Generic;
using UnityEngine;

namespace Unity.Entities.Tests
{
    public struct EntityRefTestData : IComponentData
    {
        public Entity Value;
    }

    public class EntityRefTestDataComponent : MonoBehaviour, IConvertGameObjectToEntity, IDeclareReferencedPrefabs
    {
        public GameObject Value;
        
        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            dstManager.AddComponentData(entity, new EntityRefTestData {Value = conversionSystem.GetPrimaryEntity(Value)});
        }

        public void DeclareReferencedPrefabs(List<GameObject> referencedPrefabs)
        {
            referencedPrefabs.Add(Value);
        }

        // Empty Update function makes it so that unity shows the UI for the checkbox. 
        // We use it for testing stripping of components.
        void Update() { }
    }
    
}
