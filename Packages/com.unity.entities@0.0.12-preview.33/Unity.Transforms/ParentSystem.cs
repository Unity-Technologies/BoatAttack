using System;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine.Profiling;

namespace Unity.Transforms
{
   public abstract class ParentSystem : ComponentSystem
   {
        private EntityQuery m_NewParentsGroup;
        private EntityQuery m_RemovedParentsGroup;
        private EntityQuery m_ExistingParentsGroup;
        private EntityQuery m_DeletedParentsGroup;

        void AddChildToParent(Entity childEntity, Entity parentEntity)
        {
            EntityManager.SetComponentData(childEntity, new PreviousParent {Value = parentEntity});

            if (!EntityManager.HasComponent(parentEntity, typeof(Child)))
            {
                var children = EntityManager.AddBuffer<Child>(parentEntity);
                children.Add(new Child {Value = childEntity});
            }
            else
            {
                var children = EntityManager.GetBuffer<Child>(parentEntity);
                children.Add(new Child {Value = childEntity});
            }
        }
        
        int FindChildIndex(DynamicBuffer<Child> children, Entity entity)
        {
            for (int i = 0; i < children.Length; i++)
            {
                if (children[i].Value == entity)
                    return i;
            }

            throw new InvalidOperationException("Child entity not in parent");
        }

        void RemoveChildFromParent(Entity childEntity, Entity parentEntity)
        {
            if (!EntityManager.HasComponent<Child>(parentEntity))
                return;

            var children = EntityManager.GetBuffer<Child>(parentEntity);
            var childIndex = FindChildIndex(children, childEntity);
            children.RemoveAt(childIndex);
            if (children.Length == 0)
            {
                EntityManager.RemoveComponent(parentEntity, typeof(Child));
            }
        }

        struct ChangedParent
        {
            public Entity ChildEntity;
            public Entity PreviousParentEntity;
            public Entity ParentEntity;
        }

        [BurstCompile]
        struct FilterChangedParents : IJob
        {
            public NativeList<ChangedParent> ChangedParents;
            [ReadOnly] public NativeArray<ArchetypeChunk> Chunks;
            [ReadOnly] public ArchetypeChunkComponentType<PreviousParent> PreviousParentType;
            [ReadOnly] public ArchetypeChunkComponentType<Parent> ParentType;
            [ReadOnly] public ArchetypeChunkEntityType EntityType;

            public void Execute()
            {
                for (int i = 0; i < Chunks.Length; i++)
                {
                    var chunk = Chunks[i];
                    if (chunk.DidChange(ParentType, chunk.GetComponentVersion(PreviousParentType)))
                    {
                        var chunkPreviousParents = chunk.GetNativeArray(PreviousParentType);
                        var chunkParents = chunk.GetNativeArray(ParentType);
                        var chunkEntities = chunk.GetNativeArray(EntityType);

                        for (int j = 0; j < chunk.Count; j++)
                        {
                            if (chunkParents[j].Value != chunkPreviousParents[j].Value)
                                ChangedParents.Add(new ChangedParent
                                {
                                    ChildEntity = chunkEntities[j],
                                    ParentEntity = chunkParents[j].Value,
                                    PreviousParentEntity = chunkPreviousParents[j].Value
                                });
                        }
                    }
                }
            }
        }

        protected override void OnCreate()
        {
            m_NewParentsGroup = GetEntityQuery(new EntityQueryDesc
            {
                All = new ComponentType[]
                {
                    ComponentType.ReadOnly<Parent>(), 
                    ComponentType.ReadOnly<LocalToWorld>(), 
                    ComponentType.ReadOnly<LocalToParent>()
                },
                None = new ComponentType[]
                {
                    typeof(PreviousParent)
                },
                Options = EntityQueryOptions.FilterWriteGroup
            });
            m_RemovedParentsGroup = GetEntityQuery(new EntityQueryDesc
            {
                All = new ComponentType[]
                {
                    typeof(PreviousParent)
                },
                None = new ComponentType[]
                {
                    typeof(Parent)
                },
                Options = EntityQueryOptions.FilterWriteGroup
            });
            m_ExistingParentsGroup = GetEntityQuery(new EntityQueryDesc
            {
                All = new ComponentType[]
                {
                    ComponentType.ReadOnly<Parent>(), 
                    ComponentType.ReadOnly<LocalToWorld>(), 
                    ComponentType.ReadOnly<LocalToParent>(),
                    typeof(PreviousParent)
                },
                Options = EntityQueryOptions.FilterWriteGroup
            });
            m_DeletedParentsGroup = GetEntityQuery(new EntityQueryDesc
            {
                All = new ComponentType[]
                {
                    typeof(Child)
                },
                None = new ComponentType[]
                {
                    typeof(LocalToWorld)
                },
                Options = EntityQueryOptions.FilterWriteGroup
            });
        }

        void UpdateNewParents()
        {
            var childEntities = m_NewParentsGroup.ToEntityArray(Allocator.TempJob);
            var parents = m_NewParentsGroup.ToComponentDataArray<Parent>(Allocator.TempJob);
            
            EntityManager.AddComponent(m_NewParentsGroup, typeof(PreviousParent));

            for (int i = 0; i < childEntities.Length; i++)
            {
                var childEntity = childEntities[i];
                var parentEntity = parents[i].Value;
                    
                AddChildToParent(childEntity, parentEntity);
            }
            
            childEntities.Dispose();
            parents.Dispose();
        }

        void UpdateRemoveParents()
        {
            var childEntities = m_RemovedParentsGroup.ToEntityArray(Allocator.TempJob);
            var previousParents = m_RemovedParentsGroup.ToComponentDataArray<PreviousParent>(Allocator.TempJob);
            
            for (int i = 0; i < childEntities.Length; i++)
            {
                var childEntity = childEntities[i];
                var previousParentEntity = previousParents[i].Value;

                RemoveChildFromParent(childEntity, previousParentEntity);
            }
            
            EntityManager.RemoveComponent(m_RemovedParentsGroup, typeof(PreviousParent));            
            childEntities.Dispose();
            previousParents.Dispose();
        }

        void UpdateChangeParents()
        {
            var changeParentsChunks = m_ExistingParentsGroup.CreateArchetypeChunkArray(Allocator.TempJob);
            if (changeParentsChunks.Length > 0)
            {
                var parentType = GetArchetypeChunkComponentType<Parent>(true);
                var previousParentType = GetArchetypeChunkComponentType<PreviousParent>(true);
                var entityType = GetArchetypeChunkEntityType();
                var changedParents = new NativeList<ChangedParent>(Allocator.TempJob);
    
                var filterChangedParentsJob = new FilterChangedParents
                {
                    Chunks = changeParentsChunks,
                    ChangedParents = changedParents,
                    ParentType = parentType,
                    PreviousParentType = previousParentType,
                    EntityType = entityType
                };
                var filterChangedParentsJobHandle = filterChangedParentsJob.Schedule();
                filterChangedParentsJobHandle.Complete();
                
                for (int i = 0; i < changedParents.Length; i++)
                {
                    var childEntity = changedParents[i].ChildEntity;
                    var previousParentEntity = changedParents[i].PreviousParentEntity;
                    var parentEntity = changedParents[i].ParentEntity;
              
                    RemoveChildFromParent(childEntity, previousParentEntity);
                    AddChildToParent(childEntity, parentEntity);
                }    
                changedParents.Dispose();
            }
            changeParentsChunks.Dispose();
        }

        void UpdateDeletedParents()
        {
            var previousParents = m_DeletedParentsGroup.ToEntityArray(Allocator.TempJob);
            
            for (int i = 0; i < previousParents.Length; i++)
            {
                var parentEntity = previousParents[i];
                var childEntitiesSource = EntityManager.GetBuffer<Child>(parentEntity).AsNativeArray();
                var childEntities = new NativeArray<Entity>(childEntitiesSource.Length, Allocator.Temp);
                for (int j = 0; j < childEntitiesSource.Length; j++)
                    childEntities[j] = childEntitiesSource[j].Value;
                
                for (int j = 0; j < childEntities.Length; j++)
                {
                    var childEntity = childEntities[j];
                    
                    if (!EntityManager.Exists(childEntity))
                        continue;
                    
                    if (EntityManager.HasComponent(childEntity, typeof(Parent)))
                        EntityManager.RemoveComponent(childEntity, typeof(Parent));
                    if (EntityManager.HasComponent(childEntity, typeof(PreviousParent)))
                        EntityManager.RemoveComponent(childEntity, typeof(PreviousParent));
                    if (EntityManager.HasComponent(childEntity, typeof(LocalToParent)))
                        EntityManager.RemoveComponent(childEntity, typeof(LocalToParent));
                }
                
                childEntities.Dispose();
            }
            EntityManager.RemoveComponent(m_DeletedParentsGroup, typeof(Child));            
            previousParents.Dispose();
        }
        
        protected override void OnUpdate()
        {
            Profiler.BeginSample("UpdateDeletedParents");
            UpdateDeletedParents();
            Profiler.EndSample();
            
            Profiler.BeginSample("UpdateRemoveParents");
            UpdateRemoveParents();
            Profiler.EndSample();

            Profiler.BeginSample("UpdateChangeParents");
            UpdateChangeParents();
            Profiler.EndSample();

            Profiler.BeginSample("UpdateNewParents");
            UpdateNewParents(); 
            Profiler.EndSample();
        }
    }
}