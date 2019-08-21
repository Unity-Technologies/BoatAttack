using System;
using static Unity.Mathematics.math;

namespace Unity.Mathematics
{
    
    [System.Serializable]
    public struct MinMaxAABB : IEquatable<MinMaxAABB>
    {
        public float3 Min;
        public float3 Max;

        public bool IsEmpty
        {
            get { return this.Equals(Empty); }
        }

        public static MinMaxAABB Empty
        {
            get { return new MinMaxAABB { Min = float3(float.PositiveInfinity), Max = float3(float.NegativeInfinity) }; }
        }

        public void Encapsulate(MinMaxAABB aabb)
        {
            Min = math.min(Min, aabb.Min);
            Max = math.max(Max, aabb.Max);
        }
        
        public void Encapsulate(float3 point)
        {
            Min = math.min(Min, point);
            Max = math.max(Max, point);
        }
                
        public static implicit operator MinMaxAABB(AABB aabb)
        {
            return new MinMaxAABB {Min = aabb.Center - aabb.Extents, Max = aabb.Center + aabb.Extents};
        }
        
        public static implicit operator AABB(MinMaxAABB aabb)
        {
            return new AABB { Center = (aabb.Min + aabb.Max) * 0.5F, Extents = (aabb.Max - aabb.Min) * 0.5F};
        }

        public bool Equals(MinMaxAABB other)
        {
            return Min.Equals(Min) && Max.Equals(other.Max);
        }
    }
}