using Unity.Entities;
using Unity.Mathematics;
using static WaterSystem.BuoyantObject2;

public struct BuoyantData : IComponentData
{
	public BuoyancyType type;
	public float voxelResolution;
	public float3 normal;
	public float3 localArchimedesForce;
	public float percentSubmerged;
	public float baseDrag;
	public float baseAngularDrag;
}
//you can't have two buffers of the same type on an entity, so you need a new struct for each float3 you want to map.
public struct VoxelOffset : IBufferElementData
{
	public float3 Value;
}
public struct VoxelHeight : IBufferElementData
{
	public float3 Value;
}
//Now, your query needs to check for BuoyantData, VoxelOffset and VoxelHeight
//Your component itself doesn't define the behaviour, your query does. And your query probably will have several components in it.