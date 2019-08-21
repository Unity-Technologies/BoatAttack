using System;
using NUnit.Framework;
using Unity.Jobs;
using Unity.Collections;
using UnityEngine;
#if !UNITY_DOTSPLAYER
using System.Text.RegularExpressions;
#endif
using UnityEngine.TestTools;

namespace Unity.Entities.Tests
{
    [StandaloneFixme] // Asserts on JobDebugger in constructor
    class EntityTransactionTests : ECSTestsFixture
    {
        EntityQuery m_Group;

        public EntityTransactionTests()
        {
            Assert.IsTrue(Unity.Jobs.LowLevel.Unsafe.JobsUtility.JobDebuggerEnabled, "JobDebugger must be enabled for these tests");
        }

        [SetUp]
        public override void Setup()
        {
            base.Setup();

            m_Group = m_Manager.CreateEntityQuery(typeof(EcsTestData));

            // Archetypes can't be created on a job
            m_Manager.CreateArchetype(typeof(EcsTestData));
        }

        struct CreateEntityAddToListJob : IJob
        {
            public ExclusiveEntityTransaction entities;
            public NativeList<Entity> createdEntities;

            public void Execute()
            {
                var entity = entities.CreateEntity(ComponentType.ReadWrite<EcsTestData>());
                entities.SetComponentData(entity, new EcsTestData(42));
                Assert.AreEqual(42, entities.GetComponentData<EcsTestData>(entity).value);

                createdEntities.Add(entity);
            }
        }

        struct CreateEntityJob : IJob
        {
            public ExclusiveEntityTransaction entities;

            public void Execute()
            {
                var entity = entities.CreateEntity(ComponentType.ReadWrite<EcsTestData>());
                entities.SetComponentData(entity, new EcsTestData(42));
                Assert.AreEqual(42, entities.GetComponentData<EcsTestData>(entity).value);
            }
        }

        [Test]
        public void CreateEntitiesChainedJob()
        {
            var job = new CreateEntityAddToListJob();
            job.entities = m_Manager.BeginExclusiveEntityTransaction();
            job.createdEntities = new NativeList<Entity>(0, Allocator.TempJob);

            m_Manager.ExclusiveEntityTransactionDependency = job.Schedule(m_Manager.ExclusiveEntityTransactionDependency);
            m_Manager.ExclusiveEntityTransactionDependency = job.Schedule(m_Manager.ExclusiveEntityTransactionDependency);

            m_Manager.EndExclusiveEntityTransaction();

            var data = m_Group.ToComponentDataArray<EcsTestData>(Allocator.TempJob);
            Assert.AreEqual(2, m_Group.CalculateLength());
            Assert.AreEqual(42, data[0].value);
            Assert.AreEqual(42, data[1].value);

            Assert.IsTrue(m_Manager.Exists(job.createdEntities[0]));
            Assert.IsTrue(m_Manager.Exists(job.createdEntities[1]));

            job.createdEntities.Dispose();
            data.Dispose();
        }


        [Test]
        public void CommitAfterNotRegisteredTransactionJobLogsError()
        {
            var job = new CreateEntityJob();
            job.entities = m_Manager.BeginExclusiveEntityTransaction();

            /*var jobHandle =*/ job.Schedule(m_Manager.ExclusiveEntityTransactionDependency);

            // Commit transaction expects an error nt exception otherwise errors might occurr after a system has completed...
            #if !UNITY_DOTSPLAYER
            LogAssert.Expect(LogType.Error, new Regex("ExclusiveEntityTransaction job has not been registered"));
            #endif
            m_Manager.EndExclusiveEntityTransaction();
        }

        [Test]
        public void EntityManagerAccessDuringTransactionThrows()
        {
            var job = new CreateEntityAddToListJob();
            job.entities = m_Manager.BeginExclusiveEntityTransaction();

            Assert.Throws<InvalidOperationException>(() => { m_Manager.CreateEntity(typeof(EcsTestData)); });
            
            //@TODO:
            //Assert.Throws<InvalidOperationException>(() => { m_Manager.Exists(new Entity()); });
        }

        [Test]
        public void AccessTransactionAfterEndTransactionThrows()
        {
            var transaction = m_Manager.BeginExclusiveEntityTransaction();
            m_Manager.EndExclusiveEntityTransaction();

            Assert.Throws<InvalidOperationException>(() => { transaction.CreateEntity(typeof(EcsTestData)); });
        }

        [Test]
        public void AccessExistingEntityFromTransactionWorks()
        {
            var entity = m_Manager.CreateEntity(typeof(EcsTestData));
            m_Manager.SetComponentData(entity, new EcsTestData(42));
            
            var transaction = m_Manager.BeginExclusiveEntityTransaction();
            Assert.AreEqual(42, transaction.GetComponentData<EcsTestData>(entity).value);
        }

        [Test]
        public void MissingJobCreationDependency()
        {
            var job = new CreateEntityJob();
            job.entities = m_Manager.BeginExclusiveEntityTransaction();

            var jobHandle = job.Schedule();
            Assert.Throws<InvalidOperationException>(() => { job.Schedule(); });

            jobHandle.Complete();
        }

        [Test]
        public void CreationJobAndMainThreadNotAllowedInParallel()
        {
            var job = new CreateEntityJob();
            job.entities = m_Manager.BeginExclusiveEntityTransaction();

            var jobHandle = job.Schedule();

            Assert.Throws<InvalidOperationException>(() => { job.entities.CreateEntity(typeof(EcsTestData)); });

            jobHandle.Complete();
        }

        [Test]
        public void CreatingEntitiesBeyondCapacityInTransactionWorks()
        {
            var arch = m_Manager.CreateArchetype(typeof(EcsTestData));

            var transaction = m_Manager.BeginExclusiveEntityTransaction();
            var entities = new NativeArray<Entity>(1000, Allocator.Persistent);
            transaction.CreateEntity(arch, entities);
            entities.Dispose();
        }

        struct DynamicBufferElement : IBufferElementData
        {
            public int Value;
        }

        struct DynamicBufferJob : IJob
        {
            public ExclusiveEntityTransaction Transaction;
            public Entity OldEntity;
            public NativeArray<Entity> NewEntity;

            public void Execute()
            {
                NewEntity[0] = Transaction.CreateEntity(typeof(DynamicBufferElement));
                var newBuffer = Transaction.GetBuffer<DynamicBufferElement>(NewEntity[0]);

                var oldBuffer = Transaction.GetBuffer<DynamicBufferElement>(OldEntity);
                var oldArray = new NativeArray<DynamicBufferElement>(oldBuffer.Length, Allocator.Temp);
                oldBuffer.AsNativeArray().CopyTo(oldArray);

                foreach (var element in oldArray)
                {
                    newBuffer.Add(new DynamicBufferElement {Value = element.Value * 2});
                }

                oldArray.Dispose();
            }
        }

        [Test]
        public void DynamicBuffer([Values] bool mainThread)
        {
            var entity = m_Manager.CreateEntity(typeof(DynamicBufferElement));
            var buffer = m_Manager.GetBuffer<DynamicBufferElement>(entity);

            buffer.Add(new DynamicBufferElement {Value = 123});
            buffer.Add(new DynamicBufferElement {Value = 234});
            buffer.Add(new DynamicBufferElement {Value = 345});

            var newEntity = new NativeArray<Entity>(1, Allocator.TempJob);

            var job = new DynamicBufferJob();
            job.NewEntity = newEntity;
            job.Transaction = m_Manager.BeginExclusiveEntityTransaction();
            job.OldEntity = entity;

            if (mainThread)
            {
                job.Execute();
            }
            else
            {
                job.Schedule().Complete();
            }

            m_Manager.EndExclusiveEntityTransaction();

            Assert.AreNotEqual(entity, job.NewEntity[0]);

            var newBuffer = m_Manager.GetBuffer<DynamicBufferElement>(job.NewEntity[0]);

            Assert.AreEqual(3, newBuffer.Length);

            Assert.AreEqual(123 * 2, newBuffer[0].Value);
            Assert.AreEqual(234 * 2, newBuffer[1].Value);
            Assert.AreEqual(345 * 2, newBuffer[2].Value);

            newEntity.Dispose();
        }
    }
}
