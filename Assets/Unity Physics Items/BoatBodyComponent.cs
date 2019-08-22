using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;


public class BoatBodyComponent : MonoBehaviour//, IConvertGameObjectToEntity
{
	//Called by parent BuoyantObject_DOTS
	public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
	{
		dstManager.AddComponent(entity, typeof(CopyTransformToGameObject));
	}
}
