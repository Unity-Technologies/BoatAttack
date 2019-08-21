using NUnit.Framework;
using Unity.Collections;
using Unity.Entities.Tests;
using Unity.PerformanceTesting;

namespace Unity.Entities.PerformanceTests
{
    public sealed unsafe class ComponentJobSafetyManagerPerformanceTests : ECSTestsFixture
    {
        #if UNITY_2019_2_OR_NEWER
        [Test, Performance]
        #else
        [PerformanceTest]
        #endif
        public void AddGetBufferComponentLoop()
        {
            const int entityCount = 16 * 1024;
            var entities = new NativeArray<Entity>(entityCount, Allocator.Temp);
            var archetype = m_Manager.CreateArchetype(typeof(EcsTestData));
            Measure.Method(() =>
                {
                    for (int i = 0; i < entityCount; ++i)
                    {
                        var entity = entities[i];
                        m_Manager.AddBuffer<EcsIntElement>(entity);
                        var buffer = m_Manager.GetBuffer<EcsIntElement>(entity);
                        buffer.Add(i);
                    }
                })
                .SetUp(() =>
                {
                    m_Manager.CreateEntity(archetype, entities);
                })
                .CleanUp(() =>
                {
                    m_Manager.DestroyEntity(entities);
                })
                .Run();

            entities.Dispose();
        }
    }
}
