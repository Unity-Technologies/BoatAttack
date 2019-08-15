using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEditor.IMGUI.Controls;

namespace Unity.Entities.Editor
{
    internal class EntityArrayListAdapter : IList<TreeViewItem>
    {

        internal static int IndexToItemId(int index)
        {
            return -1 - index;
        }
        internal static int ItemIdToIndex(int id)
        {
            return -id - 1;
        }
        
        private readonly TreeViewItem currentItem = new TreeViewItem();

        private NativeArray<ArchetypeChunk> chunkArray;

        private EntityManager entityManager;

        private ChunkFilter chunkFilter;

        public int Count { get; private set; }

        private Enumerator indexIterator;

        public void SetSource(NativeArray<ArchetypeChunk> newChunkArray, EntityManager newEntityManager, ChunkFilter newChunkFilter)
        {
            chunkArray = newChunkArray;
            chunkFilter = newChunkFilter;
            Count = 0;
            if (chunkArray.IsCreated)
            {
                for (var i = 0; i < chunkArray.Length; ++i)
                {
                    if (chunkFilter == null || (i >= chunkFilter.firstIndex && i <= chunkFilter.lastIndex))
                    {
                        Count += chunkArray[i].Count;
                    }
                }
            }
            entityManager = newEntityManager;
            indexIterator = new Enumerator(this);
        }

        class Enumerator : IEnumerator<TreeViewItem>
        {
            private int currentLinearIndex;
            private int currentIndexInChunk;
            private int currentChunk;

            private readonly EntityArrayListAdapter adapter;

            public Enumerator(EntityArrayListAdapter adapter)
            {
                this.adapter = adapter;
                Reset();
            }
            
            private void UpdateIndexInChunk()
            {
                while (adapter.chunkArray[currentChunk].Count <= currentIndexInChunk)
                    currentIndexInChunk -= adapter.chunkArray[currentChunk++].Count;
            }

            internal void MoveToIndex(int newLinearIndex)
            {
                if (newLinearIndex >= currentLinearIndex)
                {
                    currentIndexInChunk += newLinearIndex - currentLinearIndex;
                    currentLinearIndex = newLinearIndex;
                    UpdateIndexInChunk();
                }
                else
                {
                    Reset(newLinearIndex);
                }
            }
            
            public bool MoveNext()
            {
                ++currentIndexInChunk;
                ++currentLinearIndex;
                
                if (currentLinearIndex >= adapter.Count)
                    return false;

                UpdateIndexInChunk();
                return true;
            }

            private void SetLinearIndex(int newLinearIndex)
            {
                currentLinearIndex = currentIndexInChunk = newLinearIndex;
                currentChunk = 0;
                if (adapter.chunkFilter != null && currentChunk < adapter.chunkFilter.firstIndex)
                    currentChunk = adapter.chunkFilter.firstIndex;
            }

            public void Reset()
            {
                SetLinearIndex(-1);
            }

            private void Reset(int index)
            {
                SetLinearIndex(index);
                UpdateIndexInChunk();
            }

            public TreeViewItem Current
            {
                get
                {
                    var entityArray = adapter.chunkArray[currentChunk].GetNativeArray(adapter.entityManager.GetArchetypeChunkEntityType());
                    var entity = entityArray[currentIndexInChunk];
            
                    adapter.currentItem.id = IndexToItemId(entity.Index);
                    var name = adapter.entityManager.GetName(entity);
                    if (string.IsNullOrEmpty(name))
                        name = $"Entity {entity.Index}";
                    adapter.currentItem.displayName = name;
                    return adapter.currentItem;
                }
            }

            object IEnumerator.Current => Current;

            public void Dispose() {}
        }

        public TreeViewItem this[int linearIndex]
        {
            get
            {
                indexIterator.MoveToIndex(linearIndex);
                return indexIterator.Current;
            }
            set { throw new System.NotImplementedException(); }
        }

        public bool IsReadOnly => false;

        public bool GetById(int id, out Entity foundEntity)
        {
            var index = ItemIdToIndex(id);
            foreach (var chunk in chunkArray)
            {
                var array = chunk.GetNativeArray(entityManager.GetArchetypeChunkEntityType());
                foreach (var entity in array)
                {
                    if (entity.Index == index)
                    {
                        foundEntity = entity;
                        return true;
                    }
                }
            }
            
            foundEntity = Entity.Null;
            
            return false;
        }

        public bool Contains(TreeViewItem item)
        {
            throw new NotImplementedException();
        }
        
        public IEnumerator<TreeViewItem> GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(TreeViewItem item)
        {
            throw new System.NotImplementedException();
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

        public void CopyTo(TreeViewItem[] array, int arrayIndex)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(TreeViewItem item)
        {
            throw new System.NotImplementedException();
        }

        public int IndexOf(TreeViewItem item)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(int index, TreeViewItem item)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new System.NotImplementedException();
        }
    }
}