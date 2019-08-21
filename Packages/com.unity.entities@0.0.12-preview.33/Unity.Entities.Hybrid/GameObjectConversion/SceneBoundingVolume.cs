using Unity.Entities;
using Unity.Mathematics;

namespace Unity.Entities
{
    public struct SceneBoundingVolume : IComponentData
    {
        public MinMaxAABB Value;
    }
}
