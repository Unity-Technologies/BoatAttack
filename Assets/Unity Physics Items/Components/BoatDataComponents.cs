using Unity.Entities;
using Unity.Mathematics;
using static WaterSystem.BuoyantObject_DOTS;

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

public struct VoxelOffset : IBufferElementData
{
	public float3 Value;
}
public struct VoxelHeight : IBufferElementData
{
	public float3 Value;
}

public struct DrivingData : IComponentData
{
	public bool isHuman;
	public float torque;
	public float horsePower;
	public float3 engineOffset;
	public float throttle;
	public float steering;
}