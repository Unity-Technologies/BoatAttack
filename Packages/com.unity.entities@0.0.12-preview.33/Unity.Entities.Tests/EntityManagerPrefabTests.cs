using NUnit.Framework;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace Unity.Entities.Tests
{
    class LinkedGroupInstantiateTests : ECSTestsFixture
    {
        public Entity PrepareLinkedGroup(Entity external, int count = 4)
        {
            // Scramble allocation order intentionally
            var e2 = m_Manager.CreateEntity(typeof(EcsTestDataEntity), typeof(Prefab));
            var e0 = m_Manager.CreateEntity(typeof(EcsTestDataEntity), typeof(Prefab), typeof(LinkedEntityGroup));
            var e1 = m_Manager.CreateEntity(typeof(EcsTestDataEntity), typeof(Prefab));

            var linkedBuf = m_Manager.GetBuffer<LinkedEntityGroup>(e0);
            linkedBuf.Add(e0);
            linkedBuf.Add(e1);
            linkedBuf.Add(e2);
            m_Manager.SetComponentData(e0, new EcsTestDataEntity { value0 = 0, value1 = external});
            m_Manager.SetComponentData(e1, new EcsTestDataEntity { value0 = 1, value1 = Entity.Null});
            m_Manager.SetComponentData(e2, new EcsTestDataEntity { value0 = 2, value1 = e1});

            for (int i = 3; i < count; i++)
            {
                var e = m_Manager.CreateEntity(typeof(EcsTestDataEntity), typeof(Prefab));
                linkedBuf = m_Manager.GetBuffer<LinkedEntityGroup>(e0);
                
                m_Manager.SetComponentData(e, new EcsTestDataEntity { value0 = i, value1 = linkedBuf[i-1].Value});

                linkedBuf.Add(e);
            }
                
            return e0;
        }
        
        public void CheckLinkedGroup(Entity clone, NativeArray<Entity> srcLinked, Entity external, int count = 4)
        {
            var output = m_Manager.GetBuffer<LinkedEntityGroup>(clone).Reinterpret<Entity>().AsNativeArray();

            Assert.AreEqual(clone, output[0]);
            Assert.AreEqual(count, output.Length);

            Assert.AreNotEqual(srcLinked[0], output[0]);
            Assert.AreEqual(0, m_Manager.GetComponentData<EcsTestDataEntity>(output[0]).value0);
            Assert.AreEqual(external, m_Manager.GetComponentData<EcsTestDataEntity>(output[0]).value1);

            Assert.AreNotEqual(srcLinked[1], output[1]);
            Assert.AreEqual(1, m_Manager.GetComponentData<EcsTestDataEntity>(output[1]).value0);
            Assert.AreEqual(Entity.Null, m_Manager.GetComponentData<EcsTestDataEntity>(output[1]).value1);

            for (int i = 2; i < count; i++)
            {
                Assert.AreNotEqual(srcLinked[i], output[i]);                
                Assert.AreEqual(i, m_Manager.GetComponentData<EcsTestDataEntity>(output[i]).value0);
                Assert.AreEqual(output[i - 1], m_Manager.GetComponentData<EcsTestDataEntity>(output[i]).value1);
            }
        }
        
        [Test]
        public void InstantiateLinkedGroup()
        {
            var external = m_Manager.CreateEntity();

            var srcRoot = PrepareLinkedGroup(external);
            var srcLinked = new NativeArray<Entity>(m_Manager.GetBuffer<LinkedEntityGroup>(srcRoot).Reinterpret<Entity>().AsNativeArray(), Allocator.Persistent);

            var clone = m_Manager.Instantiate(srcRoot);

            CheckLinkedGroup(clone, srcLinked, external);
            
            // Make sure that instantiated objects are found by component group (They are no longer prefabs)
            Assert.AreEqual(4, m_Manager.CreateEntityQuery(typeof(EcsTestDataEntity)).CalculateLength());
            
            srcLinked.Dispose();
        }
        
        [Test]
        public void InstantiateLinkedGroupStressTest([Values(1, 1023)]int count)
        {
            var external = m_Manager.CreateEntity();
            var srcRoot = PrepareLinkedGroup(external);
            var srcLinked = new NativeArray<Entity>(m_Manager.GetBuffer<LinkedEntityGroup>(srcRoot).Reinterpret<Entity>().AsNativeArray(), Allocator.Persistent);

            var clones = new NativeArray<Entity>(count, Allocator.Persistent);
            for (int iter = 0; iter != 3; iter++)
            {
                m_Manager.Instantiate(srcRoot, clones);
                for (int i = 0; i != clones.Length;i++)
                    CheckLinkedGroup(clones[i], srcLinked, external);
            }

            // Make sure that instantiated objects are found by component group (They are no longer prefabs)
            Assert.AreEqual(3 * 4 * count, m_Manager.CreateEntityQuery(typeof(EcsTestDataEntity)).CalculateLength());
            
            clones.Dispose();
            srcLinked.Dispose();
        }
        
        [Test]
        public void DestroyLinkedGroupStressTest()
        {
            var external = m_Manager.CreateEntity();
            
            var roots = new NativeArray<Entity>(20, Allocator.Temp);
            for (int i = 0; i < 10; i++)
            {
                roots[i*2] = PrepareLinkedGroup(external, 5 + i * 3);
                roots[i*2+1] = PrepareLinkedGroup(external, 5 + i * 3);
            }
            
            m_Manager.DestroyEntity(roots);
            
            Assert.AreEqual(1, m_Manager.Debug.EntityCount);
            Assert.IsTrue(m_Manager.Exists(external));
        }
    }
}