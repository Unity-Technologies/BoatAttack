using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

[UpdateInGroup(typeof(GameObjectBeforeConversionGroup))]
class TransformConversion : GameObjectConversionSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((Transform transform) =>
        {
            var entity = GetPrimaryEntity(transform);

            DstEntityManager.AddComponentData(entity, new LocalToWorld { Value = transform.localToWorldMatrix});
            if (DstEntityManager.HasComponent<Static>(entity))
                return;
            
            var hasParent = HasPrimaryEntity(transform.parent);          
            if (hasParent)
            {
                DstEntityManager.AddComponentData(entity, new Translation { Value = transform.localPosition });
                DstEntityManager.AddComponentData(entity, new Rotation { Value = transform.localRotation });
            
                if (transform.localScale != Vector3.one)
                    DstEntityManager.AddComponentData(entity, new NonUniformScale{ Value = transform.localScale });

                DstEntityManager.AddComponentData(entity, new Parent { Value = GetPrimaryEntity(transform.parent) });
                DstEntityManager.AddComponentData(entity, new LocalToParent());
            }
            else
            {
                DstEntityManager.AddComponentData(entity, new Translation { Value = transform.position });
                DstEntityManager.AddComponentData(entity, new Rotation { Value = transform.rotation });
                if (transform.lossyScale != Vector3.one)
                    DstEntityManager.AddComponentData(entity, new NonUniformScale{ Value = transform.lossyScale });
            }
        });
    }
}