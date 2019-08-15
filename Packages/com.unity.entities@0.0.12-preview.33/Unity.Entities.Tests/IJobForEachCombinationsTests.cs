using System;
using NUnit.Framework;
using Unity.Collections;

namespace Unity.Entities.Tests
{
    class IJobForEachCombinationsTests : ECSTestsFixture
    {
        struct Process1 : IJobForEach<EcsTestData>
        {
            public void Execute(ref EcsTestData value)
            {
                value.value++;
            }
        }

        struct Process2 : IJobForEach<EcsTestData, EcsTestData2>
        {
            public void Execute([ReadOnly]ref EcsTestData src, ref EcsTestData2 dst)
            {
                dst.value1 = src.value;
            }
        }

        struct Process3 : IJobForEach<EcsTestData, EcsTestData2, EcsTestData3>
        {
            public void Execute([ReadOnly]ref EcsTestData src, ref EcsTestData2 dst1, ref EcsTestData3 dst2)
            {
                dst1.value1 = dst2.value2 = src.value;
            }
        }
        
        struct Process4 : IJobForEach<EcsTestData, EcsTestData2, EcsTestData3, EcsTestData4>
        {
            public void Execute([ReadOnly]ref EcsTestData src, ref EcsTestData2 dst1, ref EcsTestData3 dst2, ref EcsTestData4 dst3)
            {
                dst1.value1 = dst2.value2 = dst3.value3 = src.value;
            }
        }
        
        struct Process1Entity : IJobForEachWithEntity<EcsTestData>
        {
            public void Execute(Entity entity, int index, ref EcsTestData value)
            {
                value.value += entity.Index + index;
            }
        }

        struct Process2Entity  : IJobForEachWithEntity<EcsTestData, EcsTestData2>
        {
            public void Execute(Entity entity, int index, [ReadOnly]ref EcsTestData src, ref EcsTestData2 dst)
            {
                dst.value1 = src.value + entity.Index + index;
            }
        }

        struct Process3Entity  : IJobForEachWithEntity<EcsTestData, EcsTestData2, EcsTestData3>
        {
            public void Execute(Entity entity, int index, [ReadOnly]ref EcsTestData src, ref EcsTestData2 dst1, ref EcsTestData3 dst2)
            {
                dst1.value1 = dst2.value2 = src.value + index + entity.Index;
            }
        }
        
        struct Process4Entity  : IJobForEachWithEntity<EcsTestData, EcsTestData2, EcsTestData3, EcsTestData4>
        {
            public void Execute(Entity entity, int index, [ReadOnly]ref EcsTestData src, ref EcsTestData2 dst1, ref EcsTestData3 dst2, ref EcsTestData4 dst3)
            {
                dst1.value1 = dst2.value2 = dst3.value3 = src.value + index + entity.Index;
            }
        }

        struct Process1Buffer : IJobForEach_B<EcsIntElement>
        {
            public void Execute(DynamicBuffer<EcsIntElement> value)
            {
                value.Add(new EcsIntElement {Value = 1});
            }
        }

        struct Process2Buffer : IJobForEach_BB<EcsIntElement, EcsIntElement2>
        {
            public void Execute(DynamicBuffer<EcsIntElement> v0, DynamicBuffer<EcsIntElement2> v1)
            {
                v0.Add(new EcsIntElement { Value = 1 });
                v1.Add(new EcsIntElement2 { Value0 = 1, Value1 = 1});
            }
        }

        struct Process3Buffer : IJobForEach_BBB<EcsIntElement, EcsIntElement2, EcsIntElement3>
        {
            public void Execute(DynamicBuffer<EcsIntElement> v0, DynamicBuffer<EcsIntElement2> v1, DynamicBuffer<EcsIntElement3> v2)
            {
                v0.Add(new EcsIntElement { Value = 1 });
                v1.Add(new EcsIntElement2 { Value0 = 1, Value1 = 1 });
                v2.Add(new EcsIntElement3 { Value0 = 1, Value1 = 1, Value2 = 1 });
            }
        }

        struct Process4Buffer : IJobForEach_BBBB<EcsIntElement, EcsIntElement2, EcsIntElement3, EcsIntElement4>
        {
            public void Execute(DynamicBuffer<EcsIntElement> v0, DynamicBuffer<EcsIntElement2> v1, DynamicBuffer<EcsIntElement3> v2, DynamicBuffer<EcsIntElement4> v3)
            {
                v0.Add(new EcsIntElement { Value = 1 });
                v1.Add(new EcsIntElement2 { Value0 = 1, Value1 = 1 });
                v2.Add(new EcsIntElement3 { Value0 = 1, Value1 = 1, Value2 = 1 });
                v3.Add(new EcsIntElement4 { Value0 = 1, Value1 = 1, Value2 = 1, Value3 = 1});
            }
        }

        struct Process6Mixed : IJobForEachWithEntity_EBBBCCC<EcsIntElement, EcsIntElement2, EcsIntElement3, EcsTestData, EcsTestData2, EcsTestData3>
        {
            public void Execute(Entity entity, int index, DynamicBuffer<EcsIntElement> v0, DynamicBuffer<EcsIntElement2> v1, DynamicBuffer<EcsIntElement3> v2, ref EcsTestData v3, ref EcsTestData2 v4, ref EcsTestData3 v5)
            {
                v0.Add(new EcsIntElement { Value = 1 });
                v1.Add(new EcsIntElement2 { Value0 = 1, Value1 = 1 });
                v2.Add(new EcsIntElement3 { Value0 = 1, Value1 = 1, Value2 = 1 });
                v3.value = v4.value1 = v5.value2 = index + entity.Index;
            }
        }

        public enum ProcessMode
        {
            Single,
            Parallel,
            Run
        }

        public enum CallMode
        {
            System,
            Query
        }

#if false
        // This code, though much simpler, won't compile on ZEROPLAYER
        void Schedule<T>(ProcessMode mode) where T : struct, JobForEachExtensions.IBaseJobForEach
        {
            if (mode == ProcessMode.Parallel)
                new T().Schedule(EmptySystem).Complete();
            else if (mode == ProcessMode.Run)
                new T().Run(EmptySystem);
            else 
                new T().ScheduleSingle(EmptySystem).Complete();
        }
#endif

        NativeArray<Entity> PrepareData(int entityCount)
        {
            var archetype = m_Manager.CreateArchetype(typeof(EcsTestData), typeof(EcsTestData2), typeof(EcsTestData3), typeof(EcsTestData4));

            var entities = new NativeArray<Entity>(entityCount, Allocator.Temp);
            m_Manager.CreateEntity(archetype, entities);
            for (int i = 0;i<entities.Length;i++)
                m_Manager.SetComponentData(entities[i], new EcsTestData(i));

            return entities;
        }

        NativeArray<Entity> PrepareData_Buffer(int entityCount)
        {
            var archetype = m_Manager.CreateArchetype(typeof(EcsIntElement), typeof(EcsIntElement2), typeof(EcsIntElement3), typeof(EcsIntElement4));

            var entities = new NativeArray<Entity>(entityCount, Allocator.Temp);
            m_Manager.CreateEntity(archetype, entities);

            return entities;
        }

        EntityQuery PrepareQuery(int entityCount)
        {
            switch (entityCount)
            {
                case 1:
                    return m_Manager.CreateEntityQuery(typeof(EcsTestData));
                case 2:
                    return m_Manager.CreateEntityQuery(typeof(EcsTestData), typeof(EcsTestData2));
                case 3:
                    return m_Manager.CreateEntityQuery(typeof(EcsTestData), typeof(EcsTestData2), typeof(EcsTestData3));
                case 4:
                    return m_Manager.CreateEntityQuery(typeof(EcsTestData), typeof(EcsTestData2), typeof(EcsTestData3), typeof(EcsTestData4));
                default:
                    throw new Exception("Test case setup error.");
            }
        }

        EntityQuery PrepareQuery_Buffer(int entityCount)
        {
            switch (entityCount)
            {
                case 1:
                    return m_Manager.CreateEntityQuery(typeof(EcsIntElement));
                case 2:
                    return m_Manager.CreateEntityQuery(typeof(EcsIntElement), typeof(EcsIntElement2));
                case 3:
                    return m_Manager.CreateEntityQuery(typeof(EcsIntElement), typeof(EcsIntElement2), typeof(EcsIntElement3));
                case 4:
                    return m_Manager.CreateEntityQuery(typeof(EcsIntElement), typeof(EcsIntElement2), typeof(EcsIntElement3), typeof(EcsIntElement4));
                default:
                    throw new Exception("Test case setup error.");
            }
        }


        void CheckResultsAndDispose(NativeArray<Entity> entities, int processCount, bool withEntity)
        {
            m_Manager.CreateArchetype(typeof(EcsTestData), typeof(EcsTestData2), typeof(EcsTestData3), typeof(EcsTestData4));

            for (int i = 0; i < entities.Length; i++)
            {
                // These values should remain untouched...
                if (processCount >= 2)
                    Assert.AreEqual(0, m_Manager.GetComponentData<EcsTestData2>(entities[i]).value0);
                if (processCount >= 3)
                    Assert.AreEqual(0, m_Manager.GetComponentData<EcsTestData3>(entities[i]).value1);
                if (processCount >= 4)
                    Assert.AreEqual(0, m_Manager.GetComponentData<EcsTestData4>(entities[i]).value2);

                int expectedResult;
                if (withEntity)
                    expectedResult = i + entities[i].Index + i;
                else
                    expectedResult = i;
                
                if (processCount >= 2)
                    Assert.AreEqual(expectedResult, m_Manager.GetComponentData<EcsTestData2>(entities[i]).value1);
                if (processCount >= 3)
                    Assert.AreEqual(expectedResult, m_Manager.GetComponentData<EcsTestData3>(entities[i]).value2);
                if (processCount >= 4)
                    Assert.AreEqual(expectedResult, m_Manager.GetComponentData<EcsTestData4>(entities[i]).value3);
            }

            entities.Dispose();
        }

        void CheckResultsAndDispose_Buffer(NativeArray<Entity> entities, int processCount)
        {
            m_Manager.CreateArchetype(typeof(EcsIntElement), typeof(EcsIntElement2), typeof(EcsIntElement3), typeof(EcsIntElement4));

            for (int i = 0; i < entities.Length; i++)
            {
                // These values should remain untouched...
                if (processCount < 4)
                    Assert.AreEqual(0, m_Manager.GetBuffer<EcsIntElement4>(entities[i]).Length);
                if (processCount < 3)
                    Assert.AreEqual(0, m_Manager.GetBuffer<EcsIntElement3>(entities[i]).Length);
                if (processCount < 2)
                    Assert.AreEqual(0, m_Manager.GetBuffer<EcsIntElement2>(entities[i]).Length);

                var expectedResult = 1;

                if (processCount >= 4)
                    Assert.AreEqual(expectedResult, m_Manager.GetBuffer<EcsIntElement4>(entities[i]).Length);
                if (processCount >= 3)
                    Assert.AreEqual(expectedResult, m_Manager.GetBuffer<EcsIntElement3>(entities[i]).Length);
                if (processCount >= 2)
                    Assert.AreEqual(expectedResult, m_Manager.GetBuffer<EcsIntElement2>(entities[i]).Length);
            }

            entities.Dispose();
        }

        [Test]
        public void JobProcessStress_1([Values]CallMode call, [Values]ProcessMode mode, [Values(0, 1, 1000)]int entityCount)
        {
            var archetype = m_Manager.CreateArchetype(typeof(EcsTestData));
            var entities = new NativeArray<Entity>(entityCount, Allocator.Temp);
            m_Manager.CreateEntity(archetype, entities);

            if (call == CallMode.System)
            {
                if (mode == ProcessMode.Parallel)
                    (new Process1()).Schedule(EmptySystem).Complete();
                else if (mode == ProcessMode.Run)
                    (new Process1()).Run(EmptySystem);
                else
                    (new Process1()).ScheduleSingle(EmptySystem).Complete();
            }
            else
            {
                var query = PrepareQuery(1);
                if (mode == ProcessMode.Parallel)
                    (new Process1()).Schedule(query).Complete();
                else if (mode == ProcessMode.Run)
                    (new Process1()).Run(query);
                else
                    (new Process1()).ScheduleSingle(query).Complete();
            }

            for (int i = 0; i < entities.Length; i++)
                Assert.AreEqual(1, m_Manager.GetComponentData<EcsTestData>(entities[i]).value);

            entities.Dispose();
        }

        [Test]
        public void JobProcessStress_1_WithEntity([Values]CallMode call, [Values]ProcessMode mode, [Values(0, 1, 1000)]int entityCount)
        {
            var archetype = m_Manager.CreateArchetype(typeof(EcsTestData));
            var entities = new NativeArray<Entity>(entityCount, Allocator.Temp);
            m_Manager.CreateEntity(archetype, entities);
            
            if (call == CallMode.System)
            {
                if (mode == ProcessMode.Parallel)
                    (new Process1Entity()).Schedule(EmptySystem).Complete();
                else if (mode == ProcessMode.Run)
                    (new Process1Entity()).Run(EmptySystem);
                else
                    (new Process1Entity()).ScheduleSingle(EmptySystem).Complete();
            }
            else
            {
                var query = PrepareQuery(1);
                if (mode == ProcessMode.Parallel)
                    (new Process1Entity()).Schedule(query).Complete();
                else if (mode == ProcessMode.Run)
                    (new Process1Entity()).Run(query);
                else
                    (new Process1Entity()).ScheduleSingle(query).Complete();
            }

            for (int i = 0; i < entities.Length; i++)
                Assert.AreEqual(i + entities[i].Index, m_Manager.GetComponentData<EcsTestData>(entities[i]).value);

            entities.Dispose();
        }
        
        [Test]
        public void JobProcessStress_2([Values]CallMode call, [Values]ProcessMode mode, [Values(0, 1, 1000)]int entityCount)
        {
            var entities = PrepareData(entityCount);

            if (call == CallMode.System)
            {
                if (mode == ProcessMode.Parallel)
                    (new Process2()).Schedule(EmptySystem).Complete();
                else if (mode == ProcessMode.Run)
                    (new Process2()).Run(EmptySystem);
                else
                    (new Process2()).ScheduleSingle(EmptySystem).Complete();
            }
            else
            {
                var query = PrepareQuery(2);
                if (mode == ProcessMode.Parallel)
                    (new Process2()).Schedule(query).Complete();
                else if (mode == ProcessMode.Run)
                    (new Process2()).Run(query);
                else
                    (new Process2()).ScheduleSingle(query).Complete();
            }

            CheckResultsAndDispose(entities, 2, false);
        }

        [Test]
        public void JobProcessStress_2_WithEntity([Values]CallMode call, [Values]ProcessMode mode, [Values(0, 1, 1000)]int entityCount)
        {
            var entities = PrepareData(entityCount);

            if (call == CallMode.System)
            {
                if (mode == ProcessMode.Parallel)
                    (new Process2Entity()).Schedule(EmptySystem).Complete();
                else if (mode == ProcessMode.Run)
                    (new Process2Entity()).Run(EmptySystem);
                else
                    (new Process2Entity()).ScheduleSingle(EmptySystem).Complete();
            }
            else
            {
                var query = PrepareQuery(2);
                if (mode == ProcessMode.Parallel)
                    (new Process2Entity()).Schedule(query).Complete();
                else if (mode == ProcessMode.Run)
                    (new Process2Entity()).Run(query);
                else
                    (new Process2Entity()).ScheduleSingle(query).Complete();
            }

            CheckResultsAndDispose(entities, 2, true);

        }
        
        [Test]
        public void JobProcessStress_3([Values]CallMode call, [Values]ProcessMode mode, [Values(0, 1, 1000)]int entityCount)
        {
            var entities = PrepareData(entityCount);

            if (call == CallMode.System)
            {
                if (mode == ProcessMode.Parallel)
                    (new Process3()).Schedule(EmptySystem).Complete();
                else if (mode == ProcessMode.Run)
                    (new Process3()).Run(EmptySystem);
                else
                    (new Process3()).ScheduleSingle(EmptySystem).Complete();
            }
            else
            {
                var query = PrepareQuery(3);
                if (mode == ProcessMode.Parallel)
                    (new Process3()).Schedule(query).Complete();
                else if (mode == ProcessMode.Run)
                    (new Process3()).Run(query);
                else
                    (new Process3()).ScheduleSingle(query).Complete();
            }

            CheckResultsAndDispose(entities, 3, false);
        }
        
        [Test]
        public void JobProcessStress_3_WithEntity([Values]CallMode call, [Values]ProcessMode mode, [Values(0, 1, 1000)]int entityCount)
        {
            var entities = PrepareData(entityCount);

            if (call == CallMode.System)
            {
                if (mode == ProcessMode.Parallel)
                    (new Process3Entity()).Schedule(EmptySystem).Complete();
                else if (mode == ProcessMode.Run)
                    (new Process3Entity()).Run(EmptySystem);
                else
                    (new Process3Entity()).ScheduleSingle(EmptySystem).Complete();
            }
            else
            {
                var query = PrepareQuery(3);
                if (mode == ProcessMode.Parallel)
                    (new Process3Entity()).Schedule(query).Complete();
                else if (mode == ProcessMode.Run)
                    (new Process3Entity()).Run(query);
                else
                    (new Process3Entity()).ScheduleSingle(query).Complete();
            }

            CheckResultsAndDispose(entities, 3, true);
        }
        
        [Test]
        public void JobProcessStress_4([Values]CallMode call, [Values]ProcessMode mode, [Values(0, 1, 1000)]int entityCount)
        {
            var entities = PrepareData(entityCount);

            if (call == CallMode.System)
            {
                if (mode == ProcessMode.Parallel)
                    (new Process4()).Schedule(EmptySystem).Complete();
                else if (mode == ProcessMode.Run)
                    (new Process4()).Run(EmptySystem);
                else
                    (new Process4()).ScheduleSingle(EmptySystem).Complete();
            }
            else
            {
                var query = PrepareQuery(4);
                if (mode == ProcessMode.Parallel)
                    (new Process4()).Schedule(query).Complete();
                else if (mode == ProcessMode.Run)
                    (new Process4()).Run(query);
                else
                    (new Process4()).ScheduleSingle(query).Complete();
            }

            CheckResultsAndDispose(entities, 4, false);
        }
        
        [Test]
        public void JobProcessStress_4_WithEntity([Values]CallMode call, [Values]ProcessMode mode, [Values(0, 1, 1000)]int entityCount)
        {
            var entities = PrepareData(entityCount);

            if (call == CallMode.System)
            {
                if (mode == ProcessMode.Parallel)
                    (new Process4Entity()).Schedule(EmptySystem).Complete();
                else if (mode == ProcessMode.Run)
                    (new Process4Entity()).Run(EmptySystem);
                else
                    (new Process4Entity()).ScheduleSingle(EmptySystem).Complete();
            }
            else
            {
                var query = PrepareQuery(4);
                if (mode == ProcessMode.Parallel)
                    (new Process4Entity()).Schedule(query).Complete();
                else if (mode == ProcessMode.Run)
                    (new Process4Entity()).Run(query);
                else
                    (new Process4Entity()).ScheduleSingle(query).Complete();
            }
            CheckResultsAndDispose(entities, 4, true);
        }

#if !UNITY_ZEROPLAYER
        [Test]
        public void JobProcessBufferStress_1([Values]CallMode call, [Values]ProcessMode mode, [Values(0, 1, 1000)]int entityCount)
        {
            var entities = PrepareData_Buffer(entityCount);

            if (call == CallMode.System)
            {
                if (mode == ProcessMode.Parallel)
                    (new Process1Buffer()).Schedule(EmptySystem).Complete();
                else if (mode == ProcessMode.Run)
                    (new Process1Buffer()).Run(EmptySystem);
                else
                    (new Process1Buffer()).ScheduleSingle(EmptySystem).Complete();
            }
            else
            {
                var query = PrepareQuery_Buffer(1);
                if (mode == ProcessMode.Parallel)
                    (new Process1Buffer()).Schedule(query).Complete();
                else if (mode == ProcessMode.Run)
                    (new Process1Buffer()).Run(query);
                else
                    (new Process1Buffer()).ScheduleSingle(query).Complete();
            }

            for (int i = 0; i < entities.Length; i++)
                Assert.AreEqual(1, m_Manager.GetBuffer<EcsIntElement>(entities[i]).Length);

            entities.Dispose();
        }

        [Test]
        public void JobProcessBufferStress_2([Values]CallMode call, [Values]ProcessMode mode, [Values(0, 1, 1000)]int entityCount)
        {
            var entities = PrepareData_Buffer(entityCount);

            if (call == CallMode.System)
            {
                if (mode == ProcessMode.Parallel)
                    (new Process2Buffer()).Schedule(EmptySystem).Complete();
                else if (mode == ProcessMode.Run)
                    (new Process2Buffer()).Run(EmptySystem);
                else
                    (new Process2Buffer()).ScheduleSingle(EmptySystem).Complete();
            }
            else
            {
                var query = PrepareQuery_Buffer(2);
                if (mode == ProcessMode.Parallel)
                    (new Process2Buffer()).Schedule(query).Complete();
                else if (mode == ProcessMode.Run)
                    (new Process2Buffer()).Run(query);
                else
                    (new Process2Buffer()).ScheduleSingle(query).Complete();
            }

            CheckResultsAndDispose_Buffer(entities, 2);

            entities.Dispose();
        }

        [Test]
        public void JobProcessBufferStress_3([Values]CallMode call, [Values]ProcessMode mode, [Values(0, 1, 1000)]int entityCount)
        {
            var entities = PrepareData_Buffer(entityCount);

            if (call == CallMode.System)
            {
                if (mode == ProcessMode.Parallel)
                    (new Process3Buffer()).Schedule(EmptySystem).Complete();
                else if (mode == ProcessMode.Run)
                    (new Process3Buffer()).Run(EmptySystem);
                else
                    (new Process3Buffer()).ScheduleSingle(EmptySystem).Complete();
            }
            else
            {
                var query = PrepareQuery_Buffer(3);
                if (mode == ProcessMode.Parallel)
                    (new Process3Buffer()).Schedule(query).Complete();
                else if (mode == ProcessMode.Run)
                    (new Process3Buffer()).Run(query);
                else
                    (new Process3Buffer()).ScheduleSingle(query).Complete();
            }

            CheckResultsAndDispose_Buffer(entities, 3);

            entities.Dispose();
        }

        [Test]
        public void JobProcessBufferStress_4([Values]CallMode call, [Values]ProcessMode mode, [Values(0, 1, 1000)]int entityCount)
        {
            var entities = PrepareData_Buffer(entityCount);

            if (call == CallMode.System)
            {
                if (mode == ProcessMode.Parallel)
                    (new Process4Buffer()).Schedule(EmptySystem).Complete();
                else if (mode == ProcessMode.Run)
                    (new Process4Buffer()).Run(EmptySystem);
                else
                    (new Process4Buffer()).ScheduleSingle(EmptySystem).Complete();
            }
            else
            {
                var query = PrepareQuery_Buffer(4);
                if (mode == ProcessMode.Parallel)
                    (new Process4Buffer()).Schedule(query).Complete();
                else if (mode == ProcessMode.Run)
                    (new Process4Buffer()).Run(query);
                else
                    (new Process4Buffer()).ScheduleSingle(query).Complete();
            }

            CheckResultsAndDispose_Buffer(entities, 4);

            entities.Dispose();
        }

        [Test]
        public void JobProcessMixedStress_6([Values]CallMode call, [Values]ProcessMode mode, [Values(0, 1, 1000)]int entityCount)
        {
            var archetype = m_Manager.CreateArchetype(typeof(EcsIntElement), typeof(EcsIntElement2), typeof(EcsIntElement3), typeof(EcsTestData), typeof(EcsTestData2), typeof(EcsTestData3));

            var entities = new NativeArray<Entity>(entityCount, Allocator.Temp);
            m_Manager.CreateEntity(archetype, entities);

            if (call == CallMode.System)
            {
                if (mode == ProcessMode.Parallel)
                    (new Process6Mixed()).Schedule(EmptySystem).Complete();
                else if (mode == ProcessMode.Run)
                    (new Process6Mixed()).Run(EmptySystem);
                else
                    (new Process6Mixed()).ScheduleSingle(EmptySystem).Complete();
            }
            else
            {
                var query = m_Manager.CreateEntityQuery(typeof(EcsIntElement), typeof(EcsIntElement2), typeof(EcsIntElement3), typeof(EcsTestData), typeof(EcsTestData2), typeof(EcsTestData3));
                if (mode == ProcessMode.Parallel)
                    (new Process6Mixed()).Schedule(query).Complete();
                else if (mode == ProcessMode.Run)
                    (new Process6Mixed()).Run(query);
                else
                    (new Process6Mixed()).ScheduleSingle(query).Complete();
            }

            for (int i = 0; i < entities.Length; i++)
            {
                {
                    var expectedResult = 1;
                    Assert.AreEqual(expectedResult, m_Manager.GetBuffer<EcsIntElement>(entities[i]).Length);
                    Assert.AreEqual(expectedResult, m_Manager.GetBuffer<EcsIntElement2>(entities[i]).Length);
                    Assert.AreEqual(expectedResult, m_Manager.GetBuffer<EcsIntElement3>(entities[i]).Length);
                }

                {
                    var expectedResult = entities[i].Index + i;
                    Assert.AreEqual(expectedResult, m_Manager.GetComponentData<EcsTestData>(entities[i]).value);
                    Assert.AreEqual(expectedResult, m_Manager.GetComponentData<EcsTestData2>(entities[i]).value1);
                    Assert.AreEqual(expectedResult, m_Manager.GetComponentData<EcsTestData3>(entities[i]).value2);
                }
            }
            entities.Dispose();
        }
#endif
    }
}
