using System;
using Unity.Mathematics;

namespace Unity.Entities
{
    [Serializable]
    public struct SceneData : IComponentData
    {
        public Hash128          SceneGUID;
        public int              SubSectionIndex;
        public int              FileSize;
        public int              SharedComponentCount;
        public MinMaxAABB       BoundingVolume;

        //public int              IsLiveLink;
    }

    [System.Serializable]
    public struct SceneSection : ISharedComponentData, IEquatable<SceneSection>
    {
        public Hash128        SceneGUID;
        public int            Section;

        public bool Equals(SceneSection other)
        {
            return SceneGUID.Equals(other.SceneGUID) && Section == other.Section;
        }

        public override int GetHashCode()
        {
            return (SceneGUID.GetHashCode() * 397) ^ Section;
        }
    }
    
    public struct RequestSceneLoaded : IComponentData
    {
        //public int             Priority;
    }
}
