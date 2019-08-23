using System;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using Unity.Entities;

public class BuoyancyVisualizer : MonoBehaviour, IConvertGameObjectToEntity
{
	public Entity boat;

	private void OnDrawGizmos()
	{
		if (!Application.isPlaying)
			return;

		DynamicBuffer<VoxelHeight> heights = World.Active.EntityManager.GetBuffer<VoxelHeight>(boat);

	

		Gizmos.color = Color.red;



		for (int i = 0; i < heights.Length; i++)
			Gizmos.DrawSphere(heights[i].Value, .1f);
	}

	public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
	{
		
		if (boat == Entity.Null)
		{
			boat = conversionSystem.GetPrimaryEntity(transform.parent);
		}
	}
}