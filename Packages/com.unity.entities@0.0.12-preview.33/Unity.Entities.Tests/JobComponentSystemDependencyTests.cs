#if !UNITY_DOTSPLAYER
using NUnit.Framework;
using Unity.Collections;
using Unity.Jobs;
#pragma warning disable 649

namespace Unity.Entities.Tests
{
    class JobComponentSystemDependencyTests : ECSTestsFixture
    {
        public class ReadSystem1 : JobComponentSystem
        {
            public EntityQuery m_ReadGroup;

            struct ReadJob : IJobForEach<EcsTestData>
            {
                public void Execute([ReadOnly]ref EcsTestData c0)
                {
                }
            }

            protected override JobHandle OnUpdate(JobHandle input)
            {
                var job = new ReadJob() {};
                return job.Schedule(m_ReadGroup);
            }

            protected override void OnCreate()
            {
                m_ReadGroup = GetEntityQuery(ComponentType.ReadOnly<EcsTestData>());
            }
        }

        public class ReadSystem2 : JobComponentSystem
        {
            public EntityQuery m_ReadGroup;

            public bool returnWrongJob = false;
            public bool ignoreInputDeps = false;

            private struct ReadJob : IJobForEach<EcsTestData>
            {
                public void Execute([ReadOnly]ref EcsTestData c0)
                {
                }
            }

            protected override JobHandle OnUpdate(JobHandle input)
            {
                JobHandle h;

                var job = new ReadJob() {};

                if (ignoreInputDeps)
                {
                    h = job.Schedule(m_ReadGroup);
                }
                else
                {
                    h = job.Schedule(m_ReadGroup, input);
                }

                return returnWrongJob ? input : h;
            }

            protected override void OnCreate()
            {
                m_ReadGroup = GetEntityQuery(ComponentType.ReadOnly<EcsTestData>());
            }
        }

        public class ReadSystem3 : JobComponentSystem
        {
            public EntityQuery m_ReadGroup;

            protected override JobHandle OnUpdate(JobHandle input)
            {
                return input;
            }

            protected override void OnCreate()
            {
                m_ReadGroup = GetEntityQuery(ComponentType.ReadOnly<EcsTestData>());
            }
        }

        public class WriteSystem : JobComponentSystem
        {
            public EntityQuery m_WriteGroup;

            public bool SkipJob = false;

            private struct WriteJob : IJobForEach<EcsTestData>
            {
                public void Execute(ref EcsTestData c0)
                {
                }
            }

            protected override JobHandle OnUpdate(JobHandle input)
            {
                if (!SkipJob)
                {
                    var job = new WriteJob() {};
                    return job.Schedule(m_WriteGroup);
                }
                else
                {
                    return input;
                }
            }

            protected override void OnCreate()
            {
                m_WriteGroup = GetEntityQuery(ComponentType.ReadWrite<EcsTestData>());
            }
        }

        [Test]
        public void ReturningWrongJobThrowsInCorrectSystemUpdate()
        {
            var entity = m_Manager.CreateEntity (typeof(EcsTestData));
            m_Manager.SetComponentData(entity, new EcsTestData(42));
            ReadSystem1 rs1 = World.GetOrCreateSystem<ReadSystem1>();
            ReadSystem2 rs2 = World.GetOrCreateSystem<ReadSystem2>();

            rs2.returnWrongJob = true;

            rs1.Update();
            Assert.Throws<System.InvalidOperationException>(() => { rs2.Update(); });
        }

        [Test]
        public void IgnoredInputDepsThrowsInCorrectSystemUpdate()
        {
            var entity = m_Manager.CreateEntity (typeof(EcsTestData));
            m_Manager.SetComponentData(entity, new EcsTestData(42));
            WriteSystem ws1 = World.GetOrCreateSystem<WriteSystem>();
            ReadSystem2 rs2 = World.GetOrCreateSystem<ReadSystem2>();

            rs2.ignoreInputDeps = true;

            ws1.Update();
            Assert.Throws<System.InvalidOperationException>(() => { rs2.Update(); });
        }

        [Test]
        public void NotSchedulingWriteJobIsHarmless()
        {
            var entity = m_Manager.CreateEntity (typeof(EcsTestData));
            m_Manager.SetComponentData(entity, new EcsTestData(42));
            WriteSystem ws1 = World.GetOrCreateSystem<WriteSystem>();

            ws1.Update();
            ws1.SkipJob = true;
            ws1.Update();
        }

        [Test]
        public void NotUsingDataIsHarmless()
        {
            var entity = m_Manager.CreateEntity (typeof(EcsTestData));
            m_Manager.SetComponentData(entity, new EcsTestData(42));
            ReadSystem1 rs1 = World.GetOrCreateSystem<ReadSystem1>();
            ReadSystem3 rs3 = World.GetOrCreateSystem<ReadSystem3>();

            rs1.Update();
            rs3.Update();
        }

        [Test]
        public void ReadAfterWrite_JobForEachGroup_Works()
        {
            var entity = m_Manager.CreateEntity (typeof(EcsTestData));
            m_Manager.SetComponentData(entity, new EcsTestData(42));
            var ws = World.GetOrCreateSystem<WriteSystem>();
            var rs = World.GetOrCreateSystem<ReadSystem2>();

            ws.Update();
            rs.Update();
        }

        class UseEcsTestDataFromEntity: JobComponentSystem
        {
            public struct MutateEcsTestDataJob : IJob
            {
                public ComponentDataFromEntity<EcsTestData> data;

                public void Execute()
                {

                }
            }

            protected override JobHandle OnUpdate(JobHandle dep)
            {
                var job = new MutateEcsTestDataJob { data = GetComponentDataFromEntity<EcsTestData>() };
                return job.Schedule(dep);
            }
        }

        // The writer dependency on EcsTestData is not predeclared during
        // OnCreate, but we still expect the code to work correctly.
        // This should result in a sync point when adding the dependency for the first time.
        [Test]
        public void AddingDependencyTypeDuringOnUpdateSyncsDependency()
        {
            var systemA = World.CreateSystem<UseEcsTestDataFromEntity>();
            var systemB = World.CreateSystem<UseEcsTestDataFromEntity>();

            systemA.Update();
            systemB.Update();
        }
        class EmptyJobComponentSystem: JobComponentSystem
        {
            protected override JobHandle OnUpdate(JobHandle dep)
            {
                return dep;
            }
        }

        class JobComponentSystemWithJobChunkJob : JobComponentSystem
        {
            public struct EmptyJob : IJobChunk
            {
                public ArchetypeChunkComponentType<EcsTestData> TestDataType;
                public void Execute(ArchetypeChunk chunk, int chunkIndex, int firstEntityIndex)
                {
                }
            }

            protected override JobHandle OnUpdate(JobHandle dep)
            {
                var handle = new EmptyJob
                {
                    TestDataType = GetArchetypeChunkComponentType<EcsTestData>()
                }.Schedule(m_EntityManager.UniversalQuery, dep);
                return handle;
            }
        }

        [Test]
        public void EmptySystemAfterNonEmptySystemDoesntThrow()
        {
            m_Manager.CreateEntity(typeof(EcsTestData));

            var systemA = World.CreateSystem<JobComponentSystemWithJobChunkJob>();
            var systemB = World.CreateSystem<EmptyJobComponentSystem>();

            systemA.Update();
            systemB.Update();
        }
    }
}
#endif
