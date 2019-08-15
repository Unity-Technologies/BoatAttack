using System;
using UnityEditor.IMGUI.Controls;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

namespace Unity.Entities.Editor
{

    internal delegate void EntitySelectionCallback(Entity selection);
    internal delegate World WorldSelectionGetter();
    internal delegate ComponentSystemBase SystemSelectionGetter();
    internal delegate void ChunkArrayAssignmentCallback(NativeArray<ArchetypeChunk> chunkArray);

    internal class EntityListView : TreeView, IDisposable {

        public EntityListQuery SelectedEntityQuery
        {
            get { return selectedEntityQuery; }
            set
            {
                if (value == null || selectedEntityQuery != value)
                {
                    selectedEntityQuery = value;
                    chunkFilter = null;
                    Reload();
                }
            }
        }

        private EntityListQuery selectedEntityQuery;

        private ChunkFilter chunkFilter;
        public void SetFilter(ChunkFilter filter)
        {
            chunkFilter = filter;
            Reload();
        }

        private readonly EntitySelectionCallback setEntitySelection;
        private readonly WorldSelectionGetter getWorldSelection;
        private readonly SystemSelectionGetter getSystemSelection;
        private readonly ChunkArrayAssignmentCallback setChunkArray;

        private readonly EntityArrayListAdapter rows;

        public NativeArray<ArchetypeChunk> ChunkArray => chunkArray;
        private NativeArray<ArchetypeChunk> chunkArray;

        public EntityListView(TreeViewState state, EntityListQuery entityQuery, EntitySelectionCallback entitySelectionCallback, WorldSelectionGetter getWorldSelection, SystemSelectionGetter getSystemSelection, ChunkArrayAssignmentCallback setChunkArray) : base(state)
        {
            this.setEntitySelection = entitySelectionCallback;
            this.getWorldSelection = getWorldSelection;
            this.getSystemSelection = getSystemSelection;
            this.setChunkArray = setChunkArray;
            selectedEntityQuery = entityQuery;
            rows = new EntityArrayListAdapter();
            getNewSelectionOverride = (item, selection, shift) => new List<int>() {item.id};
            Reload();
        }

        internal bool ShowingSomething => getWorldSelection() != null &&
                                       (selectedEntityQuery != null || !(getSystemSelection() is ComponentSystemBase));

        private int lastVersion = -1;

        public bool NeedsReload => ShowingSomething && getWorldSelection().EntityManager.Version != lastVersion;
        
        public void ReloadIfNecessary()
        {
            if (NeedsReload)
                Reload();
        }

        public int EntityCount => rows.Count;

        protected override TreeViewItem BuildRoot()
        {
            var root  = new TreeViewItem { id = 0, depth = -1, displayName = "Root" };

            return root;
        }

        protected override IList<TreeViewItem> BuildRows(TreeViewItem root)
        {
            if (!ShowingSomething)
                return new List<TreeViewItem>();
            
            var entityManager = getWorldSelection().EntityManager;
            
            if (chunkArray.IsCreated)
                chunkArray.Dispose();

            entityManager.CompleteAllJobs();

            var group = SelectedEntityQuery?.Group;

            if (group == null)
            {
                var query = SelectedEntityQuery?.QueryDesc;
                if (query == null)
                    group = entityManager.UniversalQuery;
                else
                {
                    group = entityManager.CreateEntityQuery(query);
                }
            }

            chunkArray = group.CreateArchetypeChunkArray(Allocator.Persistent);

            rows.SetSource(chunkArray, entityManager, chunkFilter);
            setChunkArray(chunkArray);

            lastVersion = entityManager.Version;

            return rows;
        }

        protected override IList<int> GetAncestors(int id)
        {
            return id == 0 ? new List<int>() : new List<int>() {0};
        }

        protected override IList<int> GetDescendantsThatHaveChildren(int id)
        {
            return new List<int>();
        }

        public override void OnGUI(Rect rect)
        {
            if (getWorldSelection()?.EntityManager.IsCreated == true)
                base.OnGUI(rect);
        }

        public void OnEntitySelected(Entity entity)
        {
            setEntitySelection(entity);
        }

        protected override void SelectionChanged(IList<int> selectedIds)
        {
            if (selectedIds.Count > 0)
            {
                Entity selectedEntity;
                if (rows.GetById(selectedIds[0], out selectedEntity))
                    setEntitySelection(selectedEntity);
            }
            else
            {
                setEntitySelection(Entity.Null);
            }
        }

        protected override bool CanMultiSelect(TreeViewItem item)
        {
            return false;
        }

        protected override bool CanRename(TreeViewItem item)
        {
            return true;
        }

        protected override void RenameEnded(RenameEndedArgs args)
        {
            if (args.acceptedRename)
            {
                var manager = getWorldSelection()?.EntityManager;
                if (manager != null)
                {
                    Entity entity;
                    if (rows.GetById(args.itemID, out entity))
                    {
                        manager.SetName(entity, args.newName);
                    }
                }
            }
        }

        public void SelectNothing()
        {
            SetSelection(new List<int>());
        }

        public void SetEntitySelection(Entity entitySelection)
        {
            if (entitySelection != Entity.Null && getWorldSelection().EntityManager.Exists(entitySelection))
                SetSelection(new List<int>{EntityArrayListAdapter.IndexToItemId(entitySelection.Index)});
        }

        public void TouchSelection()
        {
            SetSelection(
                GetSelection()
                , TreeViewSelectionOptions.RevealAndFrame);
        }

        public void FrameSelection()
        {
            var selection = GetSelection();
            if (selection.Count > 0)
            {
                FrameItem(selection[0]);
            }
        }

        public void Dispose()
        {
            if (chunkArray.IsCreated)
                chunkArray.Dispose();
        }
    }
}
