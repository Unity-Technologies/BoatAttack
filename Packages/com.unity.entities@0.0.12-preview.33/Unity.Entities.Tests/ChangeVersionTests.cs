using NUnit.Framework;
using Unity.Collections;
using Unity.Jobs;

namespace Unity.Entities.Tests
{
    class ChangeVersionTests : ECSTestsFixture
    {
#if !UNITY_DOTSPLAYER
        class BumpVersionSystemInJob : ComponentSystem
        {
            public EntityQuery m_Group;

            struct UpdateData : IJobForEach<EcsTestData, EcsTestData2>
            {
                public void Execute(ref EcsTestData data, ref EcsTestData2 data2)
                {
                    data2 = new EcsTestData2 {value0 = 10};
                }
            }

            protected override void OnUpdate()
            {
                var updateDataJob = new UpdateData{};
                var updateDataJobHandle = updateDataJob.Schedule(m_Group);
                updateDataJobHandle.Complete();
            }

            protected override void OnCreate()
            {
                m_Group = GetEntityQuery(ComponentType.ReadWrite<EcsTestData>(),
                    ComponentType.ReadWrite<EcsTestData2>());
            }
        }
#endif

        class BumpVersionSystem : ComponentSystem
        {
            public EntityQuery m_Group;

            protected override void OnUpdate()
            {
                var data = m_Group.ToComponentDataArray<EcsTestData>(Allocator.TempJob);
                var data2 = m_Group.ToComponentDataArray<EcsTestData2>(Allocator.TempJob);

                for (int i = 0; i < data.Length; ++i)
                {
                    var d2 = data2[i];
                    d2.value0 = 10;
                    data2[i] = d2;
                }

                m_Group.CopyFromComponentDataArray(data);
                m_Group.CopyFromComponentDataArray(data2);

                data.Dispose();
                data2.Dispose();
            }

            protected override void OnCreate()
            {
                m_Group = GetEntityQuery(ComponentType.ReadWrite<EcsTestData>(),
                    ComponentType.ReadWrite<EcsTestData2>());
            }
        }

        class BumpChunkTypeVersionSystem : ComponentSystem
        {
            struct UpdateChunks : IJobParallelFor
            {
                public NativeArray<ArchetypeChunk> Chunks;
                public ArchetypeChunkComponentType<EcsTestData> EcsTestDataType;

                public void Execute(int chunkIndex)
                {
                    var chunk = Chunks[chunkIndex];
                    var ecsTestData = chunk.GetNativeArray(EcsTestDataType);
                    for (int i = 0; i < chunk.Count; i++)
                    {
                        ecsTestData[i] = new EcsTestData {value = ecsTestData[i].value + 1};
                    }
                }
            }

            EntityQuery m_Group;
            private bool m_LastAllChanged;

            protected override void OnCreate()
            {
                m_Group = GetEntityQuery(typeof(EcsTestData));
                m_LastAllChanged = false;
            }

            protected override void OnUpdate()
            {
                var chunks = m_Group.CreateArchetypeChunkArray(Allocator.TempJob);
                var ecsTestDataType = GetArchetypeChunkComponentType<EcsTestData>();
                var updateChunksJob = new UpdateChunks
                {
                    Chunks = chunks,
                    EcsTestDataType = ecsTestDataType
                };
                var updateChunksJobHandle = updateChunksJob.Schedule(chunks.Length, 32);
                updateChunksJobHandle.Complete();

                // LastSystemVersion bumped after update. Check for change
                // needs to occur inside system update.
                m_LastAllChanged = true;
                for (int i = 0; i < chunks.Length; i++)
                {
                    m_LastAllChanged &= chunks[i].DidChange(ecsTestDataType,LastSystemVersion);
                }

                chunks.Dispose();
            }

            public bool AllEcsTestDataChunksChanged()
            {
                return m_LastAllChanged;
            }
        }

        [Test]
        public void CHG_BumpValueChangesChunkTypeVersion()
        {
            m_Manager.CreateEntity(typeof(EcsTestData), typeof(EcsTestData2));

            var bumpChunkTypeVersionSystem = World.CreateSystem<BumpChunkTypeVersionSystem>();

            bumpChunkTypeVersionSystem.Update();
            Assert.AreEqual(true, bumpChunkTypeVersionSystem.AllEcsTestDataChunksChanged());

            bumpChunkTypeVersionSystem.Update();
            Assert.AreEqual(true, bumpChunkTypeVersionSystem.AllEcsTestDataChunksChanged());
        }

        [Test]
        public void CHG_SystemVersionZeroWhenNotRun()
        {
            m_Manager.CreateEntity(typeof(EcsTestData), typeof(EcsTestData2));
            var system = World.CreateSystem<BumpVersionSystem>();
            Assert.AreEqual(0, system.LastSystemVersion);
            system.Update();
            Assert.AreNotEqual(0, system.LastSystemVersion);
        }

#if !UNITY_DOTSPLAYER
        [Test]
        public void CHG_SystemVersionJob()
        {
            m_Manager.CreateEntity(typeof(EcsTestData), typeof(EcsTestData2));
            var system = World.CreateSystem<BumpVersionSystemInJob>();
            Assert.AreEqual(0, system.LastSystemVersion);
            system.Update();
            Assert.AreNotEqual(0, system.LastSystemVersion);
        }
#endif
    }
}
