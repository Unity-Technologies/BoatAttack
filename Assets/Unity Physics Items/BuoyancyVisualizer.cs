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
		if (!Application.isPlaying || (boat == Entity.Null))
			return;


		DynamicBuffer<VoxelHeight> heights = World.Active.EntityManager.GetBuffer<VoxelHeight>(boat);
		DynamicBuffer<VoxelOffset> offsets = World.Active.EntityManager.GetBuffer<VoxelOffset>(boat);

        // engine at first position
        {
            Gizmos.color = Color.green;
            var enginePos = transform.TransformPoint(offsets[0].Value);
            var waterPos = transform.TransformPoint(offsets[0].Value.x, heights[0].Value.y, offsets[0].Value.z);
            Gizmos.DrawSphere(waterPos, .15f);
            Gizmos.DrawLine(waterPos, enginePos);
        }

        {
            Gizmos.color = Color.red;
            for (int i = 1; i < heights.Length; i++)
            {
                var waterPos = transform.TransformPoint(offsets[0].Value.x, heights[0].Value.y, offsets[0].Value.z);
                Gizmos.DrawSphere(transform.TransformPoint(offsets[i].Value.x, heights[i].Value.y, offsets[i].Value.z), .1f);
            }
        }
    }

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
	{
		if (boat == Entity.Null)
		{
			boat = conversionSystem.GetPrimaryEntity(transform.parent);
		}
	}
}