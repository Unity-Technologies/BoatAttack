using System;
using Unity.Entities;

namespace Unity.Transforms
{
    /// <summary>
    /// Copy Transform from GameObject associated with Entity to TransformMatrix.
    /// Once only. Component is removed after copy.
    /// </summary>
    public struct CopyInitialTransformFromGameObject : IComponentData { }

    [UnityEngine.DisallowMultipleComponent]
    public class CopyInitialTransformFromGameObjectProxy : ComponentDataProxy<CopyInitialTransformFromGameObject> { } 
}
