using Unity.Entities;

namespace Unity.Transforms
{
    /// <summary>
    /// Copy Transform from GameObject associated with Entity to TransformMatrix.
    /// </summary>
    [WriteGroup(typeof(LocalToWorld))]
    public struct CopyTransformFromGameObject : IComponentData { }

    [UnityEngine.DisallowMultipleComponent]
    public class CopyTransformFromGameObjectProxy : ComponentDataProxy<CopyTransformFromGameObject> { } 
}
