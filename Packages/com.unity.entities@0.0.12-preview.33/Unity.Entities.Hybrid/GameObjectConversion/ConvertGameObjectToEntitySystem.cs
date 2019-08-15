using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace Unity.Entities
{
    public interface IConvertGameObjectToEntity
    {
        void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem);
    }

    public interface IDeclareReferencedPrefabs
    {
        void DeclareReferencedPrefabs(List<GameObject> referencedPrefabs);
    }

    public class RequiresEntityConversionAttribute : System.Attribute
    {

    }

    class ConvertGameObjectToEntitySystem : GameObjectConversionSystem
    {
        protected override void OnUpdate()
        {
            var convertibles = new List<IConvertGameObjectToEntity>();

            Entities.ForEach((Transform transform) =>
            {
                transform.GetComponents(convertibles);

                foreach (var c in convertibles)
                {
                    var behaviour = c as Behaviour;
                    if (behaviour != null && !behaviour.enabled)
                        continue;
                        
                    var entity = GetPrimaryEntity((Component) c);
                    c.Convert(entity, DstEntityManager, this);
                }
            });
        }
    }

    [UpdateInGroup(typeof(GameObjectBeforeConversionGroup))]
    class ComponentDataProxyToEntitySystem : GameObjectConversionSystem
    {
        protected override void OnUpdate()
        {
            Entities.ForEach((Transform transform) =>
            {
                GameObjectConversionMappingSystem.CopyComponentDataProxyToEntity(DstEntityManager, transform.gameObject, GetPrimaryEntity(transform));
            });
        }
    }

}
