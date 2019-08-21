using Unity.Entities;

namespace Unity.Transforms
{
    [UnityEngine.ExecuteAlways]
    public class TransformSystemGroup : ComponentSystemGroup
    {
    }

    [UnityEngine.ExecuteAlways]
    [UpdateInGroup(typeof(TransformSystemGroup))]
    public class EndFrameParentSystem : ParentSystem
    {
    }
    
    [UnityEngine.ExecuteAlways]
    [UpdateInGroup(typeof(TransformSystemGroup))]
    public class EndFrameCompositeScaleSystem : CompositeScaleSystem
    {
    }
    
    [UnityEngine.ExecuteAlways]
    [UpdateInGroup(typeof(TransformSystemGroup))]
    public class EndFrameRotationEulerSystem : RotationEulerSystem
    {
    }
    
    [UnityEngine.ExecuteAlways]
    [UpdateInGroup(typeof(TransformSystemGroup))]
    public class EndFramePostRotationEulerSystem : PostRotationEulerSystem
    {
    }
    
    [UnityEngine.ExecuteAlways]
    [UpdateInGroup(typeof(TransformSystemGroup))]
    [UpdateAfter(typeof(EndFrameRotationEulerSystem))]
    public class EndFrameCompositeRotationSystem : CompositeRotationSystem
    {
    }
    
    [UnityEngine.ExecuteAlways]
    [UpdateInGroup(typeof(TransformSystemGroup))]
    [UpdateAfter(typeof(EndFrameCompositeRotationSystem))]
    [UpdateAfter(typeof(EndFrameCompositeScaleSystem))]
    [UpdateBefore(typeof(EndFrameLocalToParentSystem))]
    public class EndFrameTRSToLocalToWorldSystem : TRSToLocalToWorldSystem
    {
    }
    
    [UnityEngine.ExecuteAlways]
    [UpdateInGroup(typeof(TransformSystemGroup))]
    [UpdateAfter(typeof(EndFrameParentSystem))]
    [UpdateAfter(typeof(EndFrameCompositeRotationSystem))]
    public class EndFrameParentScaleInverseSystem : ParentScaleInverseSystem
    {        
    }
    
    [UnityEngine.ExecuteAlways]
    [UpdateInGroup(typeof(TransformSystemGroup))]
    [UpdateAfter(typeof(EndFrameCompositeRotationSystem))]
    [UpdateAfter(typeof(EndFrameCompositeScaleSystem))]
    [UpdateAfter(typeof(EndFrameParentScaleInverseSystem))]
    public class EndFrameTRSToLocalToParentSystem : TRSToLocalToParentSystem
    {
    }
    
    [UnityEngine.ExecuteAlways]
    [UpdateInGroup(typeof(TransformSystemGroup))]
    [UpdateAfter(typeof(EndFrameTRSToLocalToParentSystem))]
    public class EndFrameLocalToParentSystem : LocalToParentSystem
    {
    }
    
    [UnityEngine.ExecuteAlways]
    [UpdateInGroup(typeof(TransformSystemGroup))]
    [UpdateAfter(typeof(EndFrameTRSToLocalToWorldSystem))]
    [UpdateAfter(typeof(EndFrameLocalToParentSystem))]
    public class EndFrameWorldToLocalSystem : WorldToLocalSystem
    {
    }
}
