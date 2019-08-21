#if !UNITY_DOTSPLAYER
using System;
using NUnit.Framework;
using Unity.Collections;
using Unity.Jobs;

namespace Unity.Entities.Tests
{
    [TestFixture]
    class ComponentGroupDelta : ECSTestsFixture
    {
        private static Entity[] nothing = {};
        // * TODO: using out of date version cached ComponentDataArray should give exception... (We store the System order version in it...)
        // * TODO: Using monobehaviour as delta inputs?
        // * TODO: Self-delta-mutation doesn't trigger update (ComponentDataFromEntity.cs)
        // /////@TODO: GlobalSystemVersion can't be pulled from m_Entities... indeterministic
        // * TODO: Chained delta works
        // How can this work? Need to use specialized job type because the number of entities to be
        // processed isn't known until running the job... Need some kind of late binding of parallel for length etc...
        // How do we prevent incorrect usage / default...

        public class DeltaCheckSystem : ComponentSystem
        {
            public Entity[] Expected;

            protected override void OnUpdate()
            {
                var group = GetEntityQuery(typeof(EcsTestData));
                group.SetFilterChanged(typeof(EcsTestData));

                var actualEntityArray = group.ToEntityArray(Allocator.TempJob);
                var systemVersion = GlobalSystemVersion;
                var lastSystemVersion = LastSystemVersion;

                CollectionAssert.AreEqual(Expected, actualEntityArray);
                actualEntityArray.Dispose();
            }

            public void UpdateExpectedResults(Entity[] expected)
            {
                Expected = expected;
                Update();
            }
        }


        [Test]
        public void CreateEntityTriggersChange()
        {
            Entity[] entity = new Entity[] { m_Manager.CreateEntity(typeof(EcsTestData)) };
            var deltaCheckSystem = World.CreateSystem<DeltaCheckSystem>();
            deltaCheckSystem.UpdateExpectedResults(entity);
        }

        public enum ChangeMode
        {
            SetComponentData,
            SetComponentDataFromEntity,
        }

#pragma warning disable 649
        unsafe struct GroupRW
        {
            public EcsTestData* Data;
        }

        unsafe struct GroupRO
        {
            [ReadOnly]
            public EcsTestData* Data;
        }
#pragma warning restore 649

        // Running SetValue should change the chunk version for the data it's writing to.
        unsafe void SetValue(int index, int value, ChangeMode mode)
        {
            EmptySystem.Update();
            var entityArray = EmptySystem.GetEntityQuery(typeof(EcsTestData)).ToEntityArray(Allocator.TempJob);
            var entity = entityArray[index];

            if (mode == ChangeMode.SetComponentData)
            {
                m_Manager.SetComponentData(entity, new EcsTestData(value));
            }
            else if (mode == ChangeMode.SetComponentDataFromEntity)
            {
                //@TODO: Chaining correctness... Definitely not implemented right now...
                var array = EmptySystem.GetComponentDataFromEntity<EcsTestData>(false);
                array[entity] = new EcsTestData(value);
            }
            
            entityArray.Dispose();
        }

        // Running GetValue should not trigger any changes to chunk version.
        void GetValue(ChangeMode mode)
        {
            EmptySystem.Update();
            var entityArray = EmptySystem.GetEntityQuery(typeof(EcsTestData)).ToEntityArray(Allocator.TempJob);

            if (mode == ChangeMode.SetComponentData)
            {
                for(int i = 0;i != entityArray.Length;i++)
                    m_Manager.GetComponentData<EcsTestData>(entityArray[i]);
            }
            else if (mode == ChangeMode.SetComponentDataFromEntity)
            {
                for(int i = 0;i != entityArray.Length;i++)
                    m_Manager.GetComponentData<EcsTestData>(entityArray[i]);
            }
            entityArray.Dispose();
        }

        [Test]
        public void ChangeEntity([Values]ChangeMode mode)
        {
            var entity0 = m_Manager.CreateEntity(typeof(EcsTestData));
            var entity1 = m_Manager.CreateEntity(typeof(EcsTestData), typeof(EcsTestData2));

            var deltaCheckSystem0 = World.CreateSystem<DeltaCheckSystem>();
            var deltaCheckSystem1 = World.CreateSystem<DeltaCheckSystem>();

            // Chunk versions are considered changed upon creation and until after they're first updated.
            deltaCheckSystem0.UpdateExpectedResults(new Entity[] { entity0, entity1 });

            // First update of chunks.
            SetValue(0, 2, mode);
            SetValue(1, 2, mode);
            deltaCheckSystem0.UpdateExpectedResults(new Entity[] { entity0, entity1 });

            // Now that everything has been updated, the change filter won't trigger until we explicitly change something.
            deltaCheckSystem0.UpdateExpectedResults(nothing);

            // Change entity0's chunk.
            SetValue(0, 3, mode);
            deltaCheckSystem0.UpdateExpectedResults(new Entity[] { entity0 });

            // Change entity1's chunk.
            SetValue(1, 3, mode);
            deltaCheckSystem0.UpdateExpectedResults(new Entity[] { entity1 });

            // Already did the initial changes to these chunks in another system, so a change in this context is based on the system's change version.
            deltaCheckSystem1.UpdateExpectedResults(new Entity[] { entity0, entity1 });

            deltaCheckSystem0.UpdateExpectedResults(nothing);
            deltaCheckSystem1.UpdateExpectedResults(nothing);
        }

        [Test]
        public void GetEntityDataDoesNotChange([Values]ChangeMode mode)
        {
            var entity0 = m_Manager.CreateEntity(typeof(EcsTestData));
            var entity1 = m_Manager.CreateEntity(typeof(EcsTestData), typeof(EcsTestData2));
            var deltaCheckSystem = World.CreateSystem<DeltaCheckSystem>();

            // First update of chunks after creation.
            SetValue(0, 2, mode);
            SetValue(1, 2, mode);
            deltaCheckSystem.UpdateExpectedResults(new Entity[] { entity0, entity1 });
            deltaCheckSystem.UpdateExpectedResults(nothing);

            // Now ensure that GetValue does not trigger a change on the EntityQuery.
            GetValue(mode);
            deltaCheckSystem.UpdateExpectedResults(nothing);
        }

        [Test]
        public void ChangeEntityWrap()
        {
           m_Manager.Debug.SetGlobalSystemVersion(uint.MaxValue-3);

            var entity = m_Manager.CreateEntity(typeof(EcsTestData));

            var deltaCheckSystem = World.CreateSystem<DeltaCheckSystem>();

            for (int i = 0; i != 7; i++)
            {
                SetValue(0, 1, ChangeMode.SetComponentData);
                deltaCheckSystem.UpdateExpectedResults(new Entity[] { entity });
            }

            deltaCheckSystem.UpdateExpectedResults(nothing);
        }

        [Test]
        public void NoChangeEntityWrap()
        {
            m_Manager.Debug.SetGlobalSystemVersion(uint.MaxValue - 3);

            var entity = m_Manager.CreateEntity(typeof(EcsTestData));
            SetValue(0, 2, ChangeMode.SetComponentData);

            var deltaCheckSystem = World.CreateSystem<DeltaCheckSystem>();
            deltaCheckSystem.UpdateExpectedResults(new Entity[] { entity });

            for (int i = 0; i != 7; i++)
                deltaCheckSystem.UpdateExpectedResults(nothing);
        }

        public class DeltaProcessComponentSystem : JobComponentSystem
        {
            struct DeltaJob : IJobForEach<EcsTestData, EcsTestData2>
            {
                public void Execute([ChangedFilter][ReadOnly]ref EcsTestData input, ref EcsTestData2 output)
                {
                    output.value0 += input.value + 100;
                }
            }

            protected override JobHandle OnUpdate(JobHandle deps)
            {
                return new DeltaJob().Schedule(this, deps);
            }
        }


        [Test]
        public void IJobProcessComponentDeltaWorks()
        {
            var entity0 = m_Manager.CreateEntity(typeof(EcsTestData), typeof(EcsTestData2), typeof(EcsTestData3));
            var entity1 = m_Manager.CreateEntity(typeof(EcsTestData), typeof(EcsTestData2));

            var deltaSystem = World.CreateSystem<DeltaProcessComponentSystem>();

            // First update of chunks after creation.
            SetValue(0, -100, ChangeMode.SetComponentData);
            SetValue(1, -100, ChangeMode.SetComponentData);
            deltaSystem.Update();
            Assert.AreEqual(0, m_Manager.GetComponentData<EcsTestData2>(entity0).value0);
            Assert.AreEqual(0, m_Manager.GetComponentData<EcsTestData2>(entity1).value0);

            // Change entity0's chunk.
            SetValue(0, 2, ChangeMode.SetComponentData);

            // Test [ChangedFilter] for real now.
            deltaSystem.Update();

            // Only entity0 should have changed.
            Assert.AreEqual(100 + 2, m_Manager.GetComponentData<EcsTestData2>(entity0).value0);

            // entity1.value0 should be unchanged from 0.
            Assert.AreEqual(0, m_Manager.GetComponentData<EcsTestData2>(entity1).value0);
        }


        public class DeltaProcessComponentSystemUsingRun : ComponentSystem
        {
            struct DeltaJob : IJobForEach<EcsTestData, EcsTestData2>
            {
                public void Execute([ChangedFilter][ReadOnly]ref EcsTestData input, ref EcsTestData2 output)
                {
                    output.value0 += input.value + 100;
                }
            }

            protected override void OnUpdate()
            {
               new DeltaJob().Run(this);
            }
        }

        [Test]
        public void IJobProcessComponentDeltaWorksWhenUsingRun()
        {
            var entity0 = m_Manager.CreateEntity(typeof(EcsTestData), typeof(EcsTestData2), typeof(EcsTestData3));
            var entity1 = m_Manager.CreateEntity(typeof(EcsTestData), typeof(EcsTestData2));

            var deltaSystem = World.CreateSystem<DeltaProcessComponentSystemUsingRun>();

            // First update of chunks after creation.
            SetValue(0, -100, ChangeMode.SetComponentData);
            SetValue(1, -100, ChangeMode.SetComponentData);

            deltaSystem.Update();

            // Test [ChangedFilter] for real now.
            SetValue(0, 2, ChangeMode.SetComponentData);

            deltaSystem.Update();

            // Only entity0 should have changed.
            Assert.AreEqual(100 + 2, m_Manager.GetComponentData<EcsTestData2>(entity0).value0);

            // entity1.value0 should be unchanged from 0.
            Assert.AreEqual(0, m_Manager.GetComponentData<EcsTestData2>(entity1).value0);
        }


#if false
        [Test]
        public void IJobProcessComponentDeltaWorksWhenSetSharedComponent()
        {
            var entity0 = m_Manager.CreateEntity(typeof(EcsTestData), typeof(EcsTestData2), typeof(EcsTestData3), typeof(EcsTestSharedComp));
            var entity1 = m_Manager.CreateEntity(typeof(EcsTestData), typeof(EcsTestData2));

            var deltaSystem = World.CreateManager<DeltaProcessComponentSystem>();

            SetValue(0, 2, ChangeMode.SetComponentData);
            m_Manager.SetSharedComponentData(entity0,new EcsTestSharedComp(50));

            deltaSystem.Update();

            Assert.AreEqual(100 + 2, m_Manager.GetComponentData<EcsTestData2>(entity0).value0);
            Assert.AreEqual(0, m_Manager.GetComponentData<EcsTestData2>(entity1).value0);
        }
#endif

        public class ModifyComponentSystem1Comp : JobComponentSystem
        {
            public EntityQuery m_Group;
            public EcsTestSharedComp m_sharedComp;

            struct DeltaJob : IJobForEach<EcsTestData>
            {
                public void Execute(ref EcsTestData data)
                {
                    data = new EcsTestData(100);
                }
            }

            protected override JobHandle OnUpdate(JobHandle deps)
            {
                m_Group = GetEntityQuery(
                    typeof(EcsTestData),
                    ComponentType.ReadOnly(typeof(EcsTestSharedComp)));

                m_Group.SetFilter(m_sharedComp);

                DeltaJob job = new DeltaJob();
                return job.Schedule(m_Group, deps);
            }
        }

        public class DeltaModifyComponentSystem1Comp : JobComponentSystem
        {
            struct DeltaJobFirstRunAfterCreation : IJobForEach<EcsTestData>
            {
                public void Execute([ChangedFilter]ref EcsTestData output)
                {
                    output.value = 0;
                }
            }
            struct DeltaJob : IJobForEach<EcsTestData>
            {
                public void Execute([ChangedFilter]ref EcsTestData output)
                {
                    output.value += 150;
                }
            }

            protected override JobHandle OnUpdate(JobHandle deps)
            {
                if (LastSystemVersion == 0)
                {
                    return new DeltaJobFirstRunAfterCreation().Schedule(this, deps);
                }
                return new DeltaJob().Schedule(this, deps);
            }
        }

        [Test]
        public void ChangedFilterJobAfterAnotherJob1Comp()
        {
            var archetype = m_Manager.CreateArchetype(typeof(EcsTestData), typeof(EcsTestSharedComp));
            var entities = new NativeArray<Entity>(10000, Allocator.Persistent);
            m_Manager.CreateEntity(archetype, entities);

            var modifSystem = World.CreateSystem<ModifyComponentSystem1Comp>();
            var deltaSystem = World.CreateSystem<DeltaModifyComponentSystem1Comp>();

            // First update of chunks after creation.
            modifSystem.Update();
            deltaSystem.Update();

            modifSystem.m_sharedComp = new EcsTestSharedComp(456);
            for (int i = 123; i < entities.Length; i += 345)
            {
                m_Manager.SetSharedComponentData(entities[i], modifSystem.m_sharedComp);
            }

            modifSystem.Update();
            deltaSystem.Update();

            foreach (var entity in entities)
            {
                if (m_Manager.GetSharedComponentData<EcsTestSharedComp>(entity).value == 456)
                {
                    Assert.AreEqual(250, m_Manager.GetComponentData<EcsTestData>(entity).value);
                }
                else
                {
                    Assert.AreEqual(0, m_Manager.GetComponentData<EcsTestData>(entity).value);
                }
            }

            entities.Dispose();
        }

        public class ModifyComponentSystem2Comp : JobComponentSystem
        {
            public EntityQuery m_Group;
            public EcsTestSharedComp m_sharedComp;

            struct DeltaJob : IJobForEach<EcsTestData, EcsTestData2>
            {
                public void Execute(ref EcsTestData data, ref EcsTestData2 data2)
                {
                    data = new EcsTestData(100);
                    data2 = new EcsTestData2(102);                }
            }

            protected override JobHandle OnUpdate(JobHandle deps)
            {
                m_Group = GetEntityQuery(
                    typeof(EcsTestData),
                    typeof(EcsTestData2),
                    ComponentType.ReadOnly(typeof(EcsTestSharedComp)));

                m_Group.SetFilter(m_sharedComp);

                DeltaJob job = new DeltaJob();
                return job.Schedule(m_Group, deps);
            }
        }

        public class DeltaModifyComponentSystem2Comp : JobComponentSystem
        {
            struct DeltaJobFirstRunAfterCreation : IJobForEach<EcsTestData, EcsTestData2>
            {
                public void Execute(ref EcsTestData output, ref EcsTestData2 output2)
                {
                    output.value = 0;
                    output2.value0 = 0;
                }
            }

            struct DeltaJobChanged0 : IJobForEach<EcsTestData, EcsTestData2>
            {
                public void Execute([ChangedFilter]ref EcsTestData output, ref EcsTestData2 output2)
                {
                    output.value += 150;
                    output2.value0 += 152;
                }
            }

            struct DeltaJobChanged1 : IJobForEach<EcsTestData, EcsTestData2>
            {
                public void Execute(ref EcsTestData output, [ChangedFilter]ref EcsTestData2 output2)
                {
                    output.value += 150;
                    output2.value0 += 152;
                }
            }

            public enum Variant
            {
                FirstComponentChanged,
                SecondComponentChanged,
            }

            public Variant variant;

            protected override JobHandle OnUpdate(JobHandle deps)
            {
                if(LastSystemVersion == 0)
                {
                    return new DeltaJobFirstRunAfterCreation().Schedule(this, deps);
                }
                switch (variant)
                {
                    case Variant.FirstComponentChanged:
                        return new DeltaJobChanged0().Schedule(this, deps);
                    case Variant.SecondComponentChanged:
                        return new DeltaJobChanged1().Schedule(this, deps);
                }

                throw new NotImplementedException();
            }
        }

        [Test]
        public void ChangedFilterJobAfterAnotherJob2Comp([Values]DeltaModifyComponentSystem2Comp.Variant variant)
        {
            var archetype = m_Manager.CreateArchetype(typeof(EcsTestData), typeof(EcsTestData2), typeof(EcsTestSharedComp));
            var entities = new NativeArray<Entity>(10000, Allocator.Persistent);
            m_Manager.CreateEntity(archetype, entities);

            // All entities have just been created, so they're all technically "changed".
            var modifSystem = World.CreateSystem<ModifyComponentSystem2Comp>();
            var deltaSystem = World.CreateSystem<DeltaModifyComponentSystem2Comp>();

            // First update of chunks after creation.
            modifSystem.Update();
            deltaSystem.Update();

            deltaSystem.variant = variant;

            modifSystem.m_sharedComp = new EcsTestSharedComp(456);
            for (int i = 123; i < entities.Length; i += 345)
            {
                m_Manager.SetSharedComponentData(entities[i], modifSystem.m_sharedComp);
            }

            modifSystem.Update();
            deltaSystem.Update();

            foreach (var entity in entities)
            {
                if (m_Manager.GetSharedComponentData<EcsTestSharedComp>(entity).value == 456)
                {
                    Assert.AreEqual(250, m_Manager.GetComponentData<EcsTestData>(entity).value);
                    Assert.AreEqual(254, m_Manager.GetComponentData<EcsTestData2>(entity).value0);
                }
                else
                {
                    Assert.AreEqual(0, m_Manager.GetComponentData<EcsTestData>(entity).value);
                }
            }

            entities.Dispose();
        }

        public class ModifyComponentSystem3Comp : JobComponentSystem
        {
            public EntityQuery m_Group;
            public EcsTestSharedComp m_sharedComp;

            struct DeltaJob : IJobForEach<EcsTestData, EcsTestData2, EcsTestData3>
            {
                public void Execute(ref EcsTestData data, ref EcsTestData2 data2, ref EcsTestData3 data3)
                {
                    data = new EcsTestData(100);
                    data2 = new EcsTestData2(102);
                    data3 = new EcsTestData3(103);                }
            }

            protected override JobHandle OnUpdate(JobHandle deps)
            {
                m_Group = GetEntityQuery(
                    typeof(EcsTestData),
                    typeof(EcsTestData2),
                    typeof(EcsTestData3),
                    ComponentType.ReadOnly(typeof(EcsTestSharedComp)));

                m_Group.SetFilter(m_sharedComp);

                DeltaJob job = new DeltaJob();
                return job.Schedule(m_Group, deps);
            }
        }

        public class DeltaModifyComponentSystem3Comp : JobComponentSystem
        {
            struct DeltaJobChanged0 : IJobForEach<EcsTestData, EcsTestData2, EcsTestData3>
            {
                public void Execute([ChangedFilter]ref EcsTestData output, ref EcsTestData2 output2, ref EcsTestData3 output3)
                {
                    output.value += 150;
                    output2.value0 += 152;
                    output3.value0 += 153;
                }
            }

            struct DeltaJobChanged1 : IJobForEach<EcsTestData, EcsTestData2, EcsTestData3>
            {
                public void Execute(ref EcsTestData output, [ChangedFilter]ref EcsTestData2 output2, ref EcsTestData3 output3)
                {
                    output.value += 150;
                    output2.value0 += 152;
                    output3.value0 += 153;
                }
            }

            struct DeltaJobChanged2 : IJobForEach<EcsTestData, EcsTestData2, EcsTestData3>
            {
                public void Execute(ref EcsTestData output, ref EcsTestData2 output2, [ChangedFilter]ref EcsTestData3 output3)
                {
                    output.value += 150;
                    output2.value0 += 152;
                    output3.value0 += 153;
                }
            }

            public enum Variant
            {
                FirstComponentChanged,
                SecondComponentChanged,
                ThirdComponentChanged,
            }

            public Variant variant;

            protected override JobHandle OnUpdate(JobHandle deps)
            {
                switch (variant)
                {
                    case Variant.FirstComponentChanged:
                        return new DeltaJobChanged0().Schedule(this, deps);
                    case Variant.SecondComponentChanged:
                        return new DeltaJobChanged1().Schedule(this, deps);
                    case Variant.ThirdComponentChanged:
                        return new DeltaJobChanged2().Schedule(this, deps);
                }

                throw new NotImplementedException();
            }
        }

        public void ChangedFilterJobAfterAnotherJob3Comp([Values]DeltaModifyComponentSystem3Comp.Variant variant)
        {
            var archetype = m_Manager.CreateArchetype(typeof(EcsTestData), typeof(EcsTestData2), typeof(EcsTestData3), typeof(EcsTestSharedComp));
            var entities = new NativeArray<Entity>(10000, Allocator.Persistent);
            m_Manager.CreateEntity(archetype, entities);

            var modifSystem = World.CreateSystem<ModifyComponentSystem3Comp>();
            var deltaSystem = World.CreateSystem<DeltaModifyComponentSystem3Comp>();

            deltaSystem.variant = variant;

            modifSystem.m_sharedComp = new EcsTestSharedComp(456);
            for (int i = 123; i < entities.Length; i += 345)
            {
                m_Manager.SetSharedComponentData(entities[i], modifSystem.m_sharedComp);
            }

            modifSystem.Update();
            deltaSystem.Update();

            foreach (var entity in entities)
            {
                if (m_Manager.GetSharedComponentData<EcsTestSharedComp>(entity).value == 456)
                {
                    Assert.AreEqual(250, m_Manager.GetComponentData<EcsTestData>(entity).value);
                    Assert.AreEqual(254, m_Manager.GetComponentData<EcsTestData2>(entity).value0);
                    Assert.AreEqual(256, m_Manager.GetComponentData<EcsTestData3>(entity).value0);
                }
                else
                {
                    Assert.AreEqual(0, m_Manager.GetComponentData<EcsTestData>(entity).value);
                }
            }

            entities.Dispose();
        }

        class ChangeFilter1TestSystem : JobComponentSystem
        {
            struct ChangedFilterJob : IJobForEach<EcsTestData, EcsTestData2>
            {
                public void Execute(ref EcsTestData output, [ChangedFilter]ref EcsTestData2 output2)
                {
                    output.value = output2.value0;
                }
            }


            protected override JobHandle OnUpdate(JobHandle inputDeps)
            {
                return new ChangedFilterJob().Schedule(this, inputDeps);
            }
        }

        [Test]
        public void ChangeFilterWorksWithOneTypes()
        {
            var e = m_Manager.CreateEntity();
            var system = World.GetOrCreateSystem<ChangeFilter1TestSystem>();
            m_Manager.AddComponentData(e, new EcsTestData(0));
            m_Manager.AddComponentData(e, new EcsTestData2(1));

            system.Update();
            m_Manager.Debug.SetGlobalSystemVersion(10);

            Assert.AreEqual(1, m_Manager.GetComponentData<EcsTestData>(e).value);

            m_Manager.SetComponentData(e, new EcsTestData2(5));

            system.Update();
            m_Manager.Debug.SetGlobalSystemVersion(20);

            Assert.AreEqual(5, m_Manager.GetComponentData<EcsTestData>(e).value);

            m_Manager.SetComponentData(e, new EcsTestData(100));

            system.Update();
            m_Manager.Debug.SetGlobalSystemVersion(30);

            Assert.AreEqual(100, m_Manager.GetComponentData<EcsTestData>(e).value);
        }

        class ChangeFilter2TestSystem : JobComponentSystem
        {
            struct ChangedFilterJob : IJobForEach<EcsTestData, EcsTestData2, EcsTestData3>
            {
                public void Execute(ref EcsTestData output, [ChangedFilter]ref EcsTestData2 output2, [ChangedFilter]ref EcsTestData3 output3)
                {
                    output.value = output2.value0 + output3.value0;
                }
            }


            protected override JobHandle OnUpdate(JobHandle inputDeps)
            {
                return new ChangedFilterJob().Schedule(this, inputDeps);
            }
        }

        [Test]
        public void ChangeFilterWorksWithTwoTypes()
        {
            var e = m_Manager.CreateEntity();
            var system = World.GetOrCreateSystem<ChangeFilter2TestSystem>();
            m_Manager.AddComponentData(e, new EcsTestData(0));
            m_Manager.AddComponentData(e, new EcsTestData2(1));
            m_Manager.AddComponentData(e, new EcsTestData3(2));

            system.Update();
            m_Manager.Debug.SetGlobalSystemVersion(10);

            Assert.AreEqual(3, m_Manager.GetComponentData<EcsTestData>(e).value);

            m_Manager.SetComponentData(e, new EcsTestData2(5));

            system.Update();
            m_Manager.Debug.SetGlobalSystemVersion(20);

            Assert.AreEqual(7, m_Manager.GetComponentData<EcsTestData>(e).value);

            m_Manager.SetComponentData(e, new EcsTestData3(7));

            system.Update();
            m_Manager.Debug.SetGlobalSystemVersion(30);

            Assert.AreEqual(12, m_Manager.GetComponentData<EcsTestData>(e).value);

            m_Manager.SetComponentData(e, new EcsTestData2(8));
            m_Manager.SetComponentData(e, new EcsTestData3(9));

            system.Update();
            m_Manager.Debug.SetGlobalSystemVersion(40);

            Assert.AreEqual(17, m_Manager.GetComponentData<EcsTestData>(e).value);

            m_Manager.SetComponentData(e, new EcsTestData(100));

            system.Update();
            m_Manager.Debug.SetGlobalSystemVersion(50);

            Assert.AreEqual(100, m_Manager.GetComponentData<EcsTestData>(e).value);
        }
    }
}
#endif
