using Unity.Jobs;

namespace Unity.Entities.Tests
{
    [AlwaysUpdateSystem]
    public class TestEcsChangeSystem : JobComponentSystem
    {
        public int NumChanged;
        EntityQuery ChangeGroup;
        protected override void OnCreate()
        {
            ChangeGroup = GetEntityQuery(typeof(EcsTestData));
            ChangeGroup.SetFilterChanged(typeof(EcsTestData));
        }

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            NumChanged = ChangeGroup.CalculateLength();
            return inputDeps;
        }
    }
}
