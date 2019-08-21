using System;
using NUnit.Framework;
using Unity.Collections;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace Unity.Entities.Tests
{
    [TestFixture]
    class TransformTests : ECSTestsFixture
    {
        const float k_Tolerance = 0.01f;

        [Test]
        public void TRS_ChildPosition()
        {
            var parent = m_Manager.CreateEntity(typeof(LocalToWorld));
            var child = m_Manager.CreateEntity(typeof(LocalToWorld), typeof(Parent), typeof(LocalToParent));

            m_Manager.SetComponentData(parent, new LocalToWorld {Value = float4x4.identity});
            m_Manager.SetComponentData(child, new Parent { Value = parent });
            m_Manager.SetComponentData(child, new LocalToParent
            {
                Value = math.mul( float4x4.RotateY((float)math.PI), float4x4.Translate( new float3(0.0f, 0.0f, 1.0f)))
            });
            
            World.GetOrCreateSystem<EndFrameParentSystem>().Update();
            World.GetOrCreateSystem<EndFrameLocalToParentSystem>().Update();
            m_Manager.CompleteAllJobs();   
           
            var childWorldPosition = m_Manager.GetComponentData<LocalToWorld>(child).Position;
            
            Assert.That(childWorldPosition.x, Is.EqualTo(0f).Within(k_Tolerance));
            Assert.That(childWorldPosition.y, Is.EqualTo(0f).Within(k_Tolerance));
            Assert.That(childWorldPosition.z, Is.EqualTo(-1f).Within(k_Tolerance));
        }
        
        [Test]
        public void TRS_RemovedParentDoesNotAffectChildPosition()
        {
            var parent = m_Manager.CreateEntity(typeof(LocalToWorld));
            var child = m_Manager.CreateEntity(typeof(LocalToWorld), typeof(Parent), typeof(LocalToParent));

            m_Manager.SetComponentData(parent, new LocalToWorld {Value = float4x4.identity});
            m_Manager.SetComponentData(child, new Parent { Value = parent });
            m_Manager.SetComponentData(child, new LocalToParent
            {
                Value = math.mul( float4x4.RotateY((float)math.PI), float4x4.Translate( new float3(0.0f, 0.0f, 1.0f)))
            });
            
            World.GetOrCreateSystem<EndFrameParentSystem>().Update();
            World.GetOrCreateSystem<EndFrameLocalToParentSystem>().Update();
            m_Manager.CompleteAllJobs();   

            var expectedChildWorldPosition = m_Manager.GetComponentData<LocalToWorld>(child).Position;
                       
            m_Manager.RemoveComponent<Parent>(child);
            
            m_Manager.SetComponentData(parent, new LocalToWorld
            {
                Value = math.mul( float4x4.RotateY((float)math.PI), float4x4.Translate( new float3(0.0f, 0.0f, 1.0f)))
            });
            
            World.GetOrCreateSystem<EndFrameParentSystem>().Update();
            World.GetOrCreateSystem<EndFrameLocalToParentSystem>().Update();

            var childWorldPosition = m_Manager.GetComponentData<LocalToWorld>(child).Position;

            Assert.That(childWorldPosition.x, Is.EqualTo(expectedChildWorldPosition.x).Within(k_Tolerance));
            Assert.That(childWorldPosition.y, Is.EqualTo(expectedChildWorldPosition.y).Within(k_Tolerance));
            Assert.That(childWorldPosition.z, Is.EqualTo(expectedChildWorldPosition.z).Within(k_Tolerance));
        }

        class TestHierarchy : IDisposable
        {
            private World World;
            private EntityManager m_Manager;
            
            private quaternion[] rotations;
            private float3[] translations;
            
            int[] rotationIndices;
            int[] translationIndices;
            int[] parentIndices;

            private NativeArray<Entity> bodyEntities;

            public void Dispose()
            {
                bodyEntities.Dispose();
            }
            
            public TestHierarchy(World world, EntityManager manager)
            {
                World = world;
                m_Manager = manager;
                
                rotations = new quaternion[]
                {
                    quaternion.EulerYZX(new float3(0.125f * (float)math.PI, 0.0f, 0.0f)),
                    quaternion.EulerYZX(new float3(0.5f * (float)math.PI, 0.0f, 0.0f)),
                    quaternion.EulerYZX(new float3((float)math.PI, 0.0f, 0.0f)),
                };
                translations = new float3[]
                {
                    new float3(0.0f, 0.0f, 1.0f),
                    new float3(0.0f, 1.0f, 0.0f),
                    new float3(1.0f, 0.0f, 0.0f),
                    new float3(0.5f, 0.5f, 0.5f),
                };
                
                //  0: R:[0] T:[0]
                //  1:  - R:[1] T:[1]
                //  2:    - R:[2] T:[0]
                //  3:    - R:[2] T:[1]
                //  4:    - R:[2] T:[2]
                //  5:      - R:[1] T:[0]
                //  6:      - R:[1] T:[1]
                //  7:      - R:[1] T:[2]
                //  8:  - R:[2] T:[2]
                //  9:    - R:[1] T:[0]
                // 10:    - R:[1] T:[1]
                // 11:    - R:[1] T:[2]
                // 12:      - R:[0] T:[0]
                // 13:        - R:[0] T:[1]
                // 14:          - R:[0] T:[2]
                // 15:            - R:[0] T:[2]

                rotationIndices = new int[] {0, 1, 2, 2, 2, 1, 1, 1, 2, 1, 1, 1, 0, 0, 0, 0};
                translationIndices = new int[] {0, 1, 0, 1, 2, 0, 1, 2, 2, 0, 1, 2, 0, 1, 2, 2};
                parentIndices = new int[] {-1, 0, 1, 1, 1, 4, 4, 4, 0, 8, 8, 8, 11, 12, 13, 14};
            }

            public int Count => rotationIndices.Length;
            public NativeArray<Entity> Entities => bodyEntities;

            public float4x4[] ExpectedLocalToParent()
            {
                var expectedLocalToParent = new float4x4[16];
                for (int i = 0; i < 16; i++)
                {
                    var rotationIndex = rotationIndices[i];
                    var translationIndex = translationIndices[i];
                    var localToParent = new float4x4(rotations[rotationIndex], translations[translationIndex]);
                    expectedLocalToParent[i] = localToParent;
                }

                return expectedLocalToParent;
            }

            public float4x4[] ExpectedLocalToWorld(float4x4[] expectedLocalToParent)
            {
                var expectedLocalToWorld = new float4x4[16];
                for (int i = 0; i < 16; i++)
                {
                    var parentIndex = parentIndices[i];
                    if (parentIndex == -1)
                    {
                        expectedLocalToWorld[i] = expectedLocalToParent[i];                        
                    }
                    else
                    {
                        expectedLocalToWorld[i] = math.mul(expectedLocalToWorld[parentIndex], expectedLocalToParent[i]);                        
                    }
                }

                return expectedLocalToWorld;
            }
            
            public void Create()
            {
                var rootArchetype = m_Manager.CreateArchetype(typeof(LocalToWorld), typeof(Rotation),
                    typeof(NonUniformScale), typeof(Translation));
                var bodyArchetype = m_Manager.CreateArchetype(typeof(LocalToWorld), typeof(Rotation),
                    typeof(NonUniformScale), typeof(Translation), typeof(Parent), typeof(LocalToParent));
              
                CreateInternal(bodyArchetype, rootArchetype, 1.0f);
            }

            private void CreateInternal(EntityArchetype bodyArchetype, EntityArchetype rootArchetype, float scaleValue)
            {
                bodyEntities = new NativeArray<Entity>(16, Allocator.TempJob);

                m_Manager.CreateEntity(bodyArchetype, bodyEntities);

                // replace the first one for loop convenience below
                m_Manager.DestroyEntity(bodyEntities[0]);
                bodyEntities[0] = m_Manager.CreateEntity(rootArchetype);

                for (int i = 0; i < 16; i++)
                {
                    var rotationIndex = rotationIndices[i];
                    var translationIndex = translationIndices[i];

                    var rotation = new Rotation() {Value = rotations[rotationIndex]};
                    var translation = new Translation() {Value = translations[translationIndex]};
                    var scale = new NonUniformScale() {Value = new float3(scaleValue)};

                    m_Manager.SetComponentData(bodyEntities[i], rotation);
                    m_Manager.SetComponentData(bodyEntities[i], translation);
                    m_Manager.SetComponentData(bodyEntities[i], scale);
                }

                for (int i = 1; i < 16; i++)
                {
                    var parentIndex = parentIndices[i];
                    m_Manager.SetComponentData(bodyEntities[i], new Parent() {Value = bodyEntities[parentIndex]});
                }
            }

            public void CreateWithWorldToLocal()
            {
                var rootArchetype = m_Manager.CreateArchetype(typeof(LocalToWorld), typeof(Rotation),
                    typeof(NonUniformScale), typeof(Translation), typeof(WorldToLocal));
                var bodyArchetype = m_Manager.CreateArchetype(typeof(LocalToWorld), typeof(Rotation),
                    typeof(NonUniformScale), typeof(Translation), typeof(Parent), typeof(LocalToParent), typeof(WorldToLocal));
              
                CreateInternal(bodyArchetype, rootArchetype, 1.0f);
            }
            
            public void CreateWithCompositeRotation()
            {
                var rootArchetype = m_Manager.CreateArchetype(typeof(LocalToWorld), typeof(CompositeRotation), typeof(Rotation),
                    typeof(NonUniformScale), typeof(Translation));
                var bodyArchetype = m_Manager.CreateArchetype(typeof(LocalToWorld), typeof(CompositeRotation), typeof(Rotation),
                    typeof(NonUniformScale), typeof(Translation), typeof(Parent), typeof(LocalToParent));
                          
                CreateInternal(bodyArchetype, rootArchetype, 1.0f);
            }
           
            public void CreateWithParentScaleInverse()
            {
                var rootArchetype = m_Manager.CreateArchetype(typeof(LocalToWorld), typeof(CompositeRotation), typeof(Rotation),
                    typeof(NonUniformScale), typeof(Translation));
                var bodyArchetype = m_Manager.CreateArchetype(typeof(LocalToWorld), typeof(CompositeRotation), typeof(Rotation),
                    typeof(NonUniformScale), typeof(Translation), typeof(Parent), typeof(LocalToParent), typeof(ParentScaleInverse));
                          
                CreateInternal(bodyArchetype, rootArchetype, 2.0f);
            }
            
            public void CreateWithCompositeScaleParentScaleInverse()
            {
                var rootArchetype = m_Manager.CreateArchetype(typeof(LocalToWorld), typeof(CompositeRotation), typeof(Rotation),
                    typeof(NonUniformScale), typeof(Translation), typeof(CompositeScale));
                var bodyArchetype = m_Manager.CreateArchetype(typeof(LocalToWorld), typeof(CompositeRotation), typeof(Rotation),
                    typeof(NonUniformScale), typeof(Translation), typeof(CompositeScale), typeof(Parent), typeof(LocalToParent), typeof(ParentScaleInverse));
                          
                CreateInternal(bodyArchetype, rootArchetype, 2.0f);
            }
            
            public void Update()
            {
                World.GetOrCreateSystem<EndFrameParentSystem>().Update();
                World.GetOrCreateSystem<EndFrameCompositeRotationSystem>().Update();
                World.GetOrCreateSystem<EndFrameCompositeScaleSystem>().Update();
                World.GetOrCreateSystem<EndFrameParentScaleInverseSystem>().Update();
                World.GetOrCreateSystem<EndFrameTRSToLocalToWorldSystem>().Update();
                World.GetOrCreateSystem<EndFrameTRSToLocalToParentSystem>().Update();
                World.GetOrCreateSystem<EndFrameLocalToParentSystem>().Update();
                World.GetOrCreateSystem<EndFrameWorldToLocalSystem>().Update();
                
                // Force complete so that main thread (tests) can have access to direct editing.
                m_Manager.CompleteAllJobs();                
            }
            
            unsafe bool AssertCloseEnough(float4x4 a, float4x4 b)
            {
                float* ap = (float*) &a.c0.x;
                float* bp = (float*) &b.c0.x;
                for (int i = 0; i < 16; i++)
                {
                    Assert.That(bp[i], Is.EqualTo(ap[i]).Within(k_Tolerance));
                }
                return true;
            }

            public void TestExpectedLocalToParent()
            {
                var expectedLocalToParent = ExpectedLocalToParent();
   
                // Check all non-root LocalToParent
                for (int i = 0; i < 16; i++)
                {
                    var entity = Entities[i];
                    var parentIndex = parentIndices[i];
                    if (parentIndex == -1)
                    {
                        Assert.IsFalse(m_Manager.HasComponent<Parent>(entity));
                        Assert.IsFalse(m_Manager.HasComponent<LocalToParent>(entity));
                        continue;
                    }
                    var localToParent = m_Manager.GetComponentData<LocalToParent>(entity).Value;
                
                    AssertCloseEnough(expectedLocalToParent[i], localToParent);
                }
            }
            
            public void TestExpectedLocalToWorld()
            {
                var expectedLocalToParent = ExpectedLocalToParent();
                var expectedLocalToWorld = ExpectedLocalToWorld(expectedLocalToParent);

                for (int i = 0; i < 16; i++)
                {
                    var entity = Entities[i];
                    if (m_Manager.Exists(entity))
                    {
                        var localToWorld = m_Manager.GetComponentData<LocalToWorld>(entity).Value;
                        AssertCloseEnough(expectedLocalToWorld[i], localToWorld);
                    }
                }
            }

            public void TestExpectedWorldToLocal()
            {
                var expectedLocalToParent = ExpectedLocalToParent();
                var expectedLocalToWorld = ExpectedLocalToWorld(expectedLocalToParent);

                for (int i = 0; i < 16; i++)
                {
                    var entity = Entities[i];
                    if (m_Manager.Exists(entity))
                    {
                        var worldToLocal = m_Manager.GetComponentData<WorldToLocal>(entity).Value;
                        AssertCloseEnough(math.inverse(expectedLocalToWorld[i]), worldToLocal);
                    }
                }
            }
            
            public void RemoveSomeParents()
            {
                parentIndices[1] = -1;
                parentIndices[8] = -1;
                
                m_Manager.RemoveComponent<Parent>(Entities[1]);
                m_Manager.RemoveComponent<Parent>(Entities[8]);
                m_Manager.RemoveComponent<LocalToParent>(Entities[1]);
                m_Manager.RemoveComponent<LocalToParent>(Entities[8]);
            }
            
            public void ChangeSomeParents()
            {
                parentIndices[4] = 3;
                parentIndices[8] = 7;
                
                m_Manager.SetComponentData<Parent>(Entities[4], new Parent{ Value = Entities[3]});
                m_Manager.SetComponentData<Parent>(Entities[8], new Parent{ Value = Entities[7]});
            }
            
            public void DeleteSomeParents()
            {
                // Effectively puts children of 0 at the root 
                parentIndices[1] = -1;
                parentIndices[8] = -1;

                m_Manager.DestroyEntity(Entities[0]);
            }
            
            public void DestroyAll()
            {
                m_Manager.DestroyEntity(Entities);
            }
        }
        
        [Test]
        public void TRS_TestHierarchyFirstUpdate()
        {
            var testHierarchy = new TestHierarchy(World, m_Manager);

            testHierarchy.Create();
            testHierarchy.Update();

            testHierarchy.TestExpectedLocalToParent();
            testHierarchy.TestExpectedLocalToWorld();

            testHierarchy.Dispose();
        }
        
        [Test]
        public void TRS_TestHierarchyFirstUpdateWithWorldtoLocal()
        {
            var testHierarchy = new TestHierarchy(World, m_Manager);

            testHierarchy.CreateWithWorldToLocal();
            testHierarchy.Update();

            testHierarchy.TestExpectedLocalToParent();
            testHierarchy.TestExpectedLocalToWorld();
            testHierarchy.TestExpectedWorldToLocal();

            testHierarchy.Dispose();
        }
                       
        [Test]
        public void TRS_TestHierarchyFirstUpdateWithCompositeRotation()
        {
            var testHierarchy = new TestHierarchy(World, m_Manager);

            testHierarchy.CreateWithCompositeRotation();
            testHierarchy.Update();

            testHierarchy.TestExpectedLocalToParent();
            testHierarchy.TestExpectedLocalToWorld();

            testHierarchy.Dispose();
        }
        
        [Test]
        public void TRS_TestHierarchyFirstUpdateWitParentScaleInverse()
        {
            var testHierarchy = new TestHierarchy(World, m_Manager);

            testHierarchy.CreateWithParentScaleInverse();
            testHierarchy.Update();

            testHierarchy.TestExpectedLocalToParent();

            testHierarchy.Dispose();
        }

        [Test]
        public void TRS_TestHierarchyFirstUpdateWitCompositeScaleParentScaleInverse()
        {
            var testHierarchy = new TestHierarchy(World, m_Manager);

            testHierarchy.CreateWithCompositeScaleParentScaleInverse();
            testHierarchy.Update();

            testHierarchy.TestExpectedLocalToParent();

            testHierarchy.Dispose();
        }
          
        [Test]
        public void TRS_TestHierarchyAfterParentRemoval()
        {
            var testHierarchy = new TestHierarchy(World, m_Manager);

            testHierarchy.Create();
            testHierarchy.Update();
            
            testHierarchy.RemoveSomeParents();
            testHierarchy.Update();

            testHierarchy.TestExpectedLocalToParent();
            testHierarchy.TestExpectedLocalToWorld();

            testHierarchy.Dispose();
        }
        
                
        [Test]
        public void TRS_TestHierarchyAfterParentChange()
        {
            var testHierarchy = new TestHierarchy(World, m_Manager);

            testHierarchy.Create();
            testHierarchy.Update();
            
            testHierarchy.ChangeSomeParents();
            testHierarchy.Update();

            testHierarchy.TestExpectedLocalToParent();
            testHierarchy.TestExpectedLocalToWorld();

            testHierarchy.Dispose();
        }
        
        [Test]
        public void TRS_TestHierarchyAfterParentDeleted()
        {
            var testHierarchy = new TestHierarchy(World, m_Manager);

            testHierarchy.Create();
            testHierarchy.Update();
            
            testHierarchy.DeleteSomeParents();
            testHierarchy.Update();

            testHierarchy.TestExpectedLocalToParent();
            testHierarchy.TestExpectedLocalToWorld();

            testHierarchy.Dispose();
        }
        
        [Test]
        public void TRS_TestHierarchyDestroyAll()
        {
            var testHierarchy = new TestHierarchy(World, m_Manager);

            testHierarchy.Create();
            testHierarchy.Update();
            
            // Make sure can handle destroying all parents and children on same frame
            testHierarchy.DestroyAll();
            testHierarchy.Update();
            
            // Make sure remaining cleanup handled cleanly.
            testHierarchy.Update();
            
            var entities = m_Manager.GetAllEntities();
            Assert.IsTrue(entities.Length == 0);

            testHierarchy.Dispose();
        }
    }
}