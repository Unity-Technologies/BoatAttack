using UnityEditor.IMGUI.Controls;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
#if UNITY_2019_3_OR_NEWER
using UnityEngine.LowLevel;
#else
using UnityEngine.Experimental.LowLevel;
#endif
using UnityEngine.Profiling;

namespace Unity.Entities.Editor
{

    internal delegate void SystemSelectionCallback(ComponentSystemBase manager, World world);

    internal class SystemListView : TreeView
    {
        private class AverageRecorder
        {
            private readonly Recorder recorder;
            private int frameCount;
            private int totalNanoseconds;
            private float lastReading;

            public AverageRecorder(Recorder recorder)
            {
                this.recorder = recorder;
            }

            public void Update()
            {
                ++frameCount;
                totalNanoseconds += (int)recorder.elapsedNanoseconds;
            }

            public float ReadMilliseconds()
            {
                if (frameCount > 0)
                {
                    lastReading = (totalNanoseconds/1e6f) / frameCount;
                    frameCount = totalNanoseconds = 0;
                }

                return lastReading;
            }
        }
        internal readonly Dictionary<int, ComponentSystemBase> managersById = new Dictionary<int, ComponentSystemBase>();
        private readonly Dictionary<int, World> worldsById = new Dictionary<int, World>();
        private readonly Dictionary<ComponentSystemBase, AverageRecorder> recordersByManager = new Dictionary<ComponentSystemBase, AverageRecorder>();
        private readonly Dictionary<int, HideNode> hideNodesById = new Dictionary<int, HideNode>();

        private const float kToggleWidth = 22f;
        private const float kTimingWidth = 70f;
        private const int kAllEntitiesItemId = 0;

        private readonly SystemSelectionCallback systemSelectionCallback;
        private readonly WorldSelectionGetter getWorldSelection;
        private readonly ShowInactiveSystemsGetter getShowInactiveSystems;

        private static GUIStyle RightAlignedLabel
        {
            get
            {
                if (rightAlignedText == null)
                {
                    rightAlignedText = new GUIStyle(GUI.skin.label)
                    {
                        alignment = TextAnchor.MiddleRight
                    };
                }

                return rightAlignedText;
            }
        }

        private static GUIStyle rightAlignedText;

        internal static MultiColumnHeaderState GetHeaderState()
        {
            var columns = new[]
            {
                new MultiColumnHeaderState.Column
                {
                    headerContent = GUIContent.none,
                    contextMenuText = "Enabled",
                    headerTextAlignment = TextAlignment.Left,
                    canSort = false,
                    width = kToggleWidth,
                    minWidth = kToggleWidth,
                    maxWidth = kToggleWidth,
                    autoResize = false,
                    allowToggleVisibility = false
                },
                new MultiColumnHeaderState.Column
                {
                    headerContent = new GUIContent("System Name"),
                    headerTextAlignment = TextAlignment.Left,
                    sortingArrowAlignment = TextAlignment.Right,
                    canSort = true,
                    sortedAscending = true,
                    width = 100,
                    minWidth = 100,
                    maxWidth = 2000,
                    autoResize = true,
                    allowToggleVisibility = false
                },
                new MultiColumnHeaderState.Column
                {
                    headerContent = new GUIContent("main (ms)"),
                    headerTextAlignment = TextAlignment.Right,
                    canSort = false,
                    width = kTimingWidth,
                    minWidth = kTimingWidth,
                    maxWidth = kTimingWidth,
                    autoResize = false,
                    allowToggleVisibility = false
                }
            };

            return new MultiColumnHeaderState(columns);
        }

        private static TreeViewState GetStateForWorld(World world, List<TreeViewState> states, List<string> stateNames)
        {
            if (world == null)
                return new TreeViewState();

            var currentWorldName = world.Name;

            var stateForCurrentWorld = states.Where((t, i) => stateNames[i] == currentWorldName).FirstOrDefault();
            if (stateForCurrentWorld != null)
                return stateForCurrentWorld;

            stateForCurrentWorld = new TreeViewState();
            states.Add(stateForCurrentWorld);
            stateNames.Add(currentWorldName);
            return stateForCurrentWorld;
        }

        public static SystemListView CreateList(List<TreeViewState> states, List<string> stateNames, SystemSelectionCallback systemSelectionCallback, WorldSelectionGetter worldSelectionGetter, ShowInactiveSystemsGetter showInactiveSystemsGetter)
        {
            var state = GetStateForWorld(worldSelectionGetter(), states, stateNames);
            var header = new MultiColumnHeader(GetHeaderState());
            return new SystemListView(state, header, systemSelectionCallback, worldSelectionGetter, showInactiveSystemsGetter);
        }

        internal SystemListView(TreeViewState state, MultiColumnHeader header, SystemSelectionCallback systemSelectionCallback, WorldSelectionGetter worldSelectionGetter, ShowInactiveSystemsGetter showInactiveSystemsGetter) : base(state, header)
        {
            this.getWorldSelection = worldSelectionGetter;
            this.systemSelectionCallback = systemSelectionCallback;
            this.getShowInactiveSystems = showInactiveSystemsGetter;
            columnIndexForTreeFoldouts = 1;
            RebuildNodes();
        }

        private HideNode CreateNodeForManager(int id, ComponentSystemBase system)
        {
            var active = true;
            if (!(system is ComponentSystemGroup))
            {
                managersById.Add(id, system);
                worldsById.Add(id, system.World);
                var recorder = Recorder.Get($"{system.World.Name} {system.GetType().FullName}");
                recordersByManager.Add(system, new AverageRecorder(recorder));
                recorder.enabled = true;
                active = false;
            }
            var name = getWorldSelection() == null ? $"{system.GetType().Name} ({system.World.Name})" : system.GetType().Name;
            var item = new TreeViewItem { id = id, displayName = name };

            var hideNode = new HideNode(item) { Active = active };
            hideNodesById.Add(id, hideNode);
            return hideNode;
        }

        private PlayerLoopSystem lastPlayerLoop;

        private class HideNode
        {
            public readonly TreeViewItem Item;
            public bool Active = true;
            public List<HideNode> Children;

            public HideNode(TreeViewItem item)
            {
                Item = item;
            }

            public void AddChild(HideNode child)
            {
                if (Children == null)
                    Children = new List<HideNode>();
                Children.Add(child);
            }

            public TreeViewItem BuildList(bool showInactiveSystems)
            {
                if (showInactiveSystems || Active)
                {
                    Item.children = null;
                    if (Children != null)
                    {
                        Item.children = new List<TreeViewItem>();
                        foreach (var child in Children)
                        {
                            var childItem = child.BuildList(showInactiveSystems);
                            if (childItem != null)
                                Item.children.Add(childItem);
                        }
                    }
                    return Item;

                }
                else
                {
                    return null;
                }
            }
        }

        private HideNode rootNode;

        private void RebuildNodes()
        {
            rootNode = null;
            Reload();
        }

        private void AddNodeIgnoreNulls(ref List<HideNode> list, HideNode node)
        {
            if (node == null)
                return;
            if (list == null)
                list = new List<HideNode>();
            list.Add(node);
        }

        private HideNode BuildNodesForPlayerLoopSystem(PlayerLoopSystem system, ref int currentId)
        {
            List<HideNode> children = null;
            if (system.subSystemList != null)
            {
                foreach (var subSystem in system.subSystemList)
                {
                    AddNodeIgnoreNulls(ref children, BuildNodesForPlayerLoopSystem(subSystem, ref currentId));
                }
            }
            else
            {
                var executionDelegate = system.updateDelegate;
                ScriptBehaviourUpdateOrder.DummyDelegateWrapper dummy;
                if (executionDelegate != null &&
                    (dummy = executionDelegate.Target as ScriptBehaviourUpdateOrder.DummyDelegateWrapper) != null)
                {
                    var rootSystem = dummy.System;
                    return BuildNodesForComponentSystem(rootSystem, ref currentId);
                }
            }

            if (children != null || getWorldSelection() == null)
            {
                var systemNode = new HideNode(new TreeViewItem() {id = currentId++, displayName = system.type?.Name});
                systemNode.Children = children;
                return systemNode;
            }

            return null;
        }

        private HideNode BuildNodesForComponentSystem(ComponentSystemBase manager, ref int currentId)
        {
            switch (manager)
            {
                case ComponentSystemGroup group:
                    List<HideNode> children = null;
                    if (group.Systems != null)
                    {
                        foreach (var child in group.Systems)
                        {
                            AddNodeIgnoreNulls(ref children, BuildNodesForComponentSystem(child, ref currentId));
                        }
                    }

                    if (children != null || getWorldSelection() == null || getWorldSelection() == group.World)
                    {
                        var groupNode = CreateNodeForManager(currentId++, group);
                        groupNode.Children = children;
                        return groupNode;
                    }
                    break;
                case ComponentSystemBase system:
                {
                    if (getWorldSelection() == null || getWorldSelection() == system.World)
                    {
                        return CreateNodeForManager(currentId++, system);
                    }
                }
                    break;
            }

            return null;
        }

        private void BuildNodeTree()
        {
            managersById.Clear();
            worldsById.Clear();
            recordersByManager.Clear();
            hideNodesById.Clear();

            var currentID = kAllEntitiesItemId + 1;

            lastPlayerLoop = ScriptBehaviourUpdateOrder.CurrentPlayerLoop;

            rootNode = BuildNodesForPlayerLoopSystem(ScriptBehaviourUpdateOrder.CurrentPlayerLoop, ref currentID)
                       ?? new HideNode(new TreeViewItem {id = currentID, displayName = "Root"});
            return;
        }

        private bool GetDefaultExpandedIds(HideNode parent, List<int> ids)
        {
            var shouldExpand = managersById.ContainsKey(parent.Item.id);
            if (parent.Children != null)
            {
                foreach (var child in parent.Children)
                {
                    shouldExpand |= GetDefaultExpandedIds(child, ids);
                }

                if (shouldExpand)
                {
                    ids.Add(parent.Item.id);
                }
            }

            return shouldExpand;
        }

        protected override TreeViewItem BuildRoot()
        {
            if (rootNode == null)
            {
                BuildNodeTree();
                var expanded = new List<int>();
                GetDefaultExpandedIds(rootNode, expanded);
                expanded.Sort();
                state.expandedIDs = expanded;
            }

            var root = rootNode.BuildList(getShowInactiveSystems());

            if (!root.hasChildren)
                root.children = new List<TreeViewItem>(0);

            if (getWorldSelection() != null)
            {
                root.children.Insert(0, new TreeViewItem(kAllEntitiesItemId, 0, $"All Entities ({getWorldSelection().Name})"));
            }

            root.depth = -1;

            SetupDepthsFromParentsAndChildren(root);
            return root;
        }

        protected override void BeforeRowsGUI()
        {
            var becameVisible = false;
            foreach (var idManagerPair in managersById)
            {
                var componentSystemBase = idManagerPair.Value;
                var hideNode = hideNodesById[idManagerPair.Key];
                if (componentSystemBase.LastSystemVersion != 0 && !hideNode.Active)
                {
                    hideNode.Active = true;
                    becameVisible = true;
                }
            }
            if (becameVisible)
                Reload();
            base.BeforeRowsGUI();
        }

        protected override void RowGUI (RowGUIArgs args)
        {
            if (args.item.depth == -1)
                return;
            var item = args.item;

            var enabled = GUI.enabled;

            if (managersById.ContainsKey(item.id))
            {
                var manager = managersById[item.id];
                var componentSystemBase = manager as ComponentSystemBase;
                if (componentSystemBase != null)
                {
                    var toggleRect = args.GetCellRect(0);
                    toggleRect.xMin = toggleRect.xMin + 4f;
                    componentSystemBase.Enabled = GUI.Toggle(toggleRect, componentSystemBase.Enabled, GUIContent.none);
                }

                if (componentSystemBase != null)
                {
                    var timingRect = args.GetCellRect(2);
                    if (componentSystemBase.ShouldRunSystem())
                    {
                        var recorder = recordersByManager[manager];
                        GUI.Label(timingRect, recorder.ReadMilliseconds().ToString("f2"), RightAlignedLabel);
                    }
                    else
                    {
                        GUI.enabled = false;
                        GUI.Label(timingRect, "not run", RightAlignedLabel);
                        GUI.enabled = enabled;
                    }
                }
            }
            else if (args.item.id == kAllEntitiesItemId)
            {

            }
            else
            {
                GUI.enabled = false;
            }

            var indent = GetContentIndent(item);
            var nameRect = args.GetCellRect(1);
            nameRect.xMin = nameRect.xMin + indent;
            GUI.Label(nameRect, item.displayName);
            GUI.enabled = enabled;
        }

        protected override void AfterRowsGUI()
        {
            base.AfterRowsGUI();
            if (Event.current.type == EventType.MouseDown)
            {
                SetSelection(new List<int>());
            }
        }

        protected override void SelectionChanged(IList<int> selectedIds)
        {
            if (selectedIds.Count > 0 && managersById.ContainsKey(selectedIds[0]))
            {
                systemSelectionCallback(managersById[selectedIds[0]], worldsById[selectedIds[0]]);
            }
            else
            {
                systemSelectionCallback(null, null);
                SetSelection(getWorldSelection() == null ? new List<int>() : new List<int> {kAllEntitiesItemId});
            }
        }

        protected override bool CanMultiSelect(TreeViewItem item)
        {
            return false;
        }

        public void TouchSelection()
        {
            SetSelection(GetSelection(), TreeViewSelectionOptions.FireSelectionChanged);
        }

        private bool PlayerLoopsMatch(PlayerLoopSystem a, PlayerLoopSystem b)
        {
            if (a.type != b.type)
                return false;
            if (a.subSystemList == b.subSystemList)
                return true;
            if (a.subSystemList == null || b.subSystemList == null)
                return false;
            if (a.subSystemList.Length != b.subSystemList.Length)
                return false;
            for (var i = 0; i < a.subSystemList.Length; ++i)
            {
                if (!PlayerLoopsMatch(a.subSystemList[i], b.subSystemList[i]))
                    return false;
            }

            return true;
        }

        public bool NeedsReload
        {
            get
            {
                if (!PlayerLoopsMatch(lastPlayerLoop, ScriptBehaviourUpdateOrder.CurrentPlayerLoop))
                    return true;

                foreach (var world in worldsById.Values)
                {
                    if (!world.IsCreated)
                        return true;
                }

                foreach (var manager in managersById.Values)
                {
                    if (manager is ComponentSystemBase system)
                    {
                        if (system.World == null || !system.World.Systems.Contains(manager))
                            return true;
                    }
                }

                return false;
            }
        }

        public void ReloadIfNecessary()
        {
            if (NeedsReload)
                RebuildNodes();
        }

        private int lastTimedFrame;

        public void UpdateTimings()
        {
            if (Time.frameCount == lastTimedFrame)
                return;

            foreach (var recorder in recordersByManager.Values)
            {
                recorder.Update();
            }

            lastTimedFrame = Time.frameCount;
        }

        public void SetSystemSelection(ComponentSystemBase manager, World world)
        {
            foreach (var pair in managersById)
            {
                if (pair.Value == manager)
                {
                    SetSelection(new List<int> {pair.Key});
                    return;
                }
            }
            SetSelection(new List<int>());
        }
    }
}
