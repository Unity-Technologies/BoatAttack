using Unity.Entities;
using Unity.Mathematics;

public struct DrivingData : IComponentData
{
	public float torque;
	public float horsePower;
	public float3 engineOffset; 
}