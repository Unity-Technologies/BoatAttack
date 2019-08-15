using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace Unity.Mathematics
{
    public struct GeneratePoints
    {
        struct PointsInSphere : IJob
        {
            public float Radius;
            public float3 Center;
            public NativeArray<float3> Points;
            
            public void Execute()
            {
                var radiusSquared = Radius * Radius;
                var pointsFound = 0;
                var count = Points.Length;
                var random = new Random(0x6E624EB7u);

                while (pointsFound < count)
                {
                    var p = random.NextFloat3() * new float3(Radius + Radius) - new float3(Radius);
                    if (math.lengthsq(p) < radiusSquared)
                    {
                        Points[pointsFound] = Center + p;
                        pointsFound++;
                    }
                }
            }
        }

        public static JobHandle RandomPointsInSphere(float3 center, float radius, NativeArray<float3> points,
            JobHandle inputDeps)
        {
            var pointsInSphereJob = new PointsInSphere
            {
                Radius = radius,
                Center = center,
                Points = points
            };
            var pointsInSphereJobHandle = pointsInSphereJob.Schedule(inputDeps);
            return pointsInSphereJobHandle;
        }

        public static void RandomPointsInSphere(float3 center, float radius, NativeArray<float3> points)
        {
            var randomPointsInSphereJobHandle = RandomPointsInSphere(center, radius, points, new JobHandle());
            randomPointsInSphereJobHandle.Complete();
        }
        
        public static void RandomPointsInUnitSphere(NativeArray<float3> points)
        {
            var randomPointsInSphereJobHandle = RandomPointsInSphere(0.0f, 1.0f, points, new JobHandle());
            randomPointsInSphereJobHandle.Complete();
        }
    }
}
