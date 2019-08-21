using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEditor.IMGUI.Controls;
using UnityEngine.Serialization;

namespace Unity.Entities.Editor
{
    internal class EntityDebugger : EditorWindow
    {
        private const float kSystemListWidth = 350f;
        private const float kChunkInfoViewWidth = 250f;

        public bool ShowingChunkInfoView
        {
            get { return showingChunkInfoView; }
            set
            {
                if (showingChunkInfoView != value)
                {
                    showingChunkInfoView = value;
                    if (!showingChunkInfoView)
                    {
                        chunkInfoListView.ClearSelection();
                    }
                }
            }
        }
        private bool showingChunkInfoView = true;

        private float CurrentEntityViewWidth =>
            Mathf.Max(100f, position.width - kSystemListWidth - (showingChunkInfoView ? kChunkInfoViewWidth : 0f));

        [MenuItem("Window/Analysis/Entity Debugger", false)]
        private static void OpenWindow()
        {
            GetWindow<EntityDebugger>("Entity Debugger");
        }

        private static GUIStyle LabelStyle
        {
            get
            {
                return labelStyle ?? (labelStyle = new GUIStyle(EditorStyles.label)
                {
                    margin = EditorStyles.boldLabel.margin,
                    richText = true
                });
            }
        }

        private static GUIStyle labelStyle;

        private static GUIStyle BoxStyle
        {
            get
            {
                return boxStyle ?? (boxStyle = new GUIStyle(GUI.skin.box)
                {
                    margin = new RectOffset(),
                    padding = new RectOffset(1, 0, 1, 0),
                    overflow = new RectOffset(0, 1, 0, 1)
                });
            }
        }

        private static GUIStyle boxStyle;

        public ComponentSystemBase SystemSelection { get; private set; }

        public World SystemSelectionWorld
        {
            get { return systemSelectionWorld?.IsCreated == true ? systemSelectionWorld : null; }
            private set { systemSelectionWorld = value; }
        }

        public void SetSystemSelection(ComponentSystemBase manager, World world, bool updateList, bool propagate)
        {
            if (manager != null && world == null)
                throw new ArgumentNullException("System cannot have null world");
            SystemSelection = manager;
            SystemSelectionWorld = world;
            if (updateList)
                systemListView.SetSystemSelection(manager, world);
            CreateEntityQueryListView();
            if (propagate)
            {
                if (SystemSelection is ComponentSystemBase)
                    entityQueryListView.TouchSelection();
                else
                    ApplyAllEntitiesFilter();
            }
        }

        public EntityListQuery EntityListQuerySelection { get; private set; }

        public void SetEntityListSelection(EntityListQuery newSelection, bool updateList, bool propagate)
        {
            chunkInfoListView.ClearSelection();
            EntityListQuerySelection = newSelection;
            if (updateList)
                entityQueryListView.SetEntityListSelection(newSelection);
            entityListView.SelectedEntityQuery = newSelection;
            if (propagate)
                entityListView.TouchSelection();
        }

        public Entity EntitySelection => selectionProxy.Entity;

        internal void SetEntitySelection(Entity newSelection, bool updateList)
        {
            if (updateList)
                entityListView.SetEntitySelection(newSelection);

            var world = WorldSelection ?? (SystemSelection as ComponentSystemBase)?.World;
            if (world != null && newSelection != Entity.Null)
            {
                selectionProxy.SetEntity(world, newSelection);
                Selection.activeObject = selectionProxy;
            }
            else if (Selection.activeObject == selectionProxy)
            {
                Selection.activeObject = null;
            }
        }

        internal static void SetAllSelections(World world, ComponentSystemBase system, EntityListQuery entityQuery,
            Entity entity)
        {
            if (Instance == null)
                OpenWindow();
            Instance.SetWorldSelection(world, false);
            Instance.SetSystemSelection(system, world, true, false);
            Instance.SetEntityListSelection(entityQuery, true, false);
            Instance.SetEntitySelection(entity, true);
            Instance.entityListView.FrameSelection();
        }

        private static EntityDebugger Instance { get; set; }

        private EntitySelectionProxy selectionProxy;

        [FormerlySerializedAs("componentGroupListStates")]
        [SerializeField] private List<TreeViewState> entityQueryListStates = new List<TreeViewState>();
        [FormerlySerializedAs("componentGroupListStateNames")]
        [SerializeField] private List<string> entityQueryListStateNames = new List<string>();
        private EntityQueryListView entityQueryListView;

        [SerializeField] private List<TreeViewState> systemListStates = new List<TreeViewState>();
        [SerializeField] private List<string> systemListStateNames = new List<string>();
        internal SystemListView systemListView;

        [SerializeField] private TreeViewState entityListState = new TreeViewState();
        private EntityListView entityListView;

        [SerializeField] private ChunkInfoListView.State chunkInfoListState = new ChunkInfoListView.State();
        private ChunkInfoListView chunkInfoListView;

        internal WorldPopup m_WorldPopup;

        private ComponentTypeFilterUI filterUI;

        public World WorldSelection
        {
            get
            {
                if (worldSelection != null && worldSelection.IsCreated)
                    return worldSelection;
                return null;
            }
        }

        [SerializeField] private string lastEditModeWorldSelection = WorldPopup.kNoWorldName;
        [SerializeField] private string lastPlayModeWorldSelection = WorldPopup.kNoWorldName;
        [SerializeField] private bool showingPlayerLoop;

        public void SetWorldSelection(World selection, bool propagate)
        {
            if (worldSelection != selection)
            {
                worldSelection = selection;
                showingPlayerLoop = worldSelection == null;
                if (worldSelection != null)
                {
                    if (EditorApplication.isPlaying)
                        lastPlayModeWorldSelection = worldSelection.Name;
                    else
                        lastEditModeWorldSelection = worldSelection.Name;
                }

                CreateSystemListView();
                if (propagate)
                    systemListView.TouchSelection();
            }
        }

        public void SetEntityListChunkFilter(ChunkFilter filter)
        {
            entityListView.SetFilter(filter);
        }

        private void CreateEntityListView()
        {
            entityListView?.Dispose();

            entityListView = new EntityListView(
                entityListState,
                EntityListQuerySelection,
                x => SetEntitySelection(x, false),
                () => SystemSelectionWorld ?? WorldSelection,
                () => SystemSelection,
                x => chunkInfoListView.SetChunkArray(x)
                );
        }

        private void CreateSystemListView()
        {
            systemListView = SystemListView.CreateList(systemListStates, systemListStateNames, (system, world) => SetSystemSelection(system, world, false, true), () => WorldSelection, () => ShowInactiveSystems);
            systemListView.multiColumnHeader.ResizeToFit();
        }

        private void CreateEntityQueryListView()
        {
            entityQueryListView = EntityQueryListView.CreateList(SystemSelection as ComponentSystemBase, entityQueryListStates, entityQueryListStateNames, x => SetEntityListSelection(x, false, true), () => SystemSelectionWorld);
        }

        [SerializeField] private bool ShowInactiveSystems;

        private void CreateWorldPopup()
        {
            m_WorldPopup = new WorldPopup(
                () => WorldSelection,
                x => SetWorldSelection(x, true),
                () => ShowInactiveSystems,
                () =>
                {
                    ShowInactiveSystems = !ShowInactiveSystems;
                    systemListView.Reload();
                }
                );
        }

        private void CreateChunkInfoListView()
        {
            chunkInfoListView = new ChunkInfoListView(chunkInfoListState, SetEntityListChunkFilter);
        }

        private World worldSelection;

        private void OnEnable()
        {
            Instance = this;
            filterUI = new ComponentTypeFilterUI(SetAllEntitiesFilter, () => WorldSelection);

            CreateEntitySelectionProxy();
            CreateWorldPopup();
            CreateSystemListView();
            CreateEntityQueryListView();
            CreateEntityListView();
            CreateChunkInfoListView();
            systemListView.TouchSelection();

            EditorApplication.playModeStateChanged += OnPlayModeStateChange;
        }

        private void CreateEntitySelectionProxy()
        {
            selectionProxy = ScriptableObject.CreateInstance<EntitySelectionProxy>();
            selectionProxy.hideFlags = HideFlags.HideAndDontSave;

            selectionProxy.EntityControlDoubleClick += entity =>
            {
                entityListView?.OnEntitySelected(entity);
            };
        }

        private void OnDestroy()
        {
            entityListView?.Dispose();
        }

        private void OnDisable()
        {
            entityListView?.Dispose();
            chunkInfoListView?.Dispose();
            if (Instance == this)
                Instance = null;
            if (selectionProxy)
                DestroyImmediate(selectionProxy);

            EditorApplication.playModeStateChanged -= OnPlayModeStateChange;
        }

        private void OnPlayModeStateChange(PlayModeStateChange change)
        {
            if (change == PlayModeStateChange.ExitingPlayMode)
                SetAllEntitiesFilter(null);
            if (change == PlayModeStateChange.ExitingPlayMode && Selection.activeObject == selectionProxy)
                Selection.activeObject = null;
        }

        private readonly RepaintLimiter repaintLimiter = new RepaintLimiter();

        private void Update()
        {
            systemListView.UpdateTimings();



            if (repaintLimiter.SimulationAdvanced())
            {
                Repaint();
            }
            else if (!Application.isPlaying)
            {
                if (systemListView.NeedsReload || entityQueryListView.NeedsReload || entityListView.NeedsReload || !filterUI.TypeListValid())
                    Repaint();
            }
        }

        private void ShowWorldPopup()
        {
            m_WorldPopup.OnGUI(showingPlayerLoop, EditorApplication.isPlaying ? lastPlayModeWorldSelection : lastEditModeWorldSelection);
        }

        private void SystemList()
        {
            var rect = GUIHelpers.GetExpandingRect();
            if (World.AllWorlds.Count != 0)
            {
                systemListView.OnGUI(rect);
            }
            else
            {
                GUIHelpers.ShowCenteredNotification(rect, "No systems (Try pushing Play)");
            }
        }

        private void SystemHeader()
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label("Systems", EditorStyles.boldLabel);
            GUILayout.FlexibleSpace();
            ShowWorldPopup();
            GUILayout.EndHorizontal();
        }

        const float kChunkInfoButtonWidth = 60f;

        private void EntityHeader()
        {
            if (WorldSelection != null || SystemSelectionWorld != null)
            {
                var rect = new Rect(kSystemListWidth, 3f, CurrentEntityViewWidth, kLineHeight);
                if (SystemSelection == null)
                {
                    GUI.Label(rect, "All Entities", EditorStyles.boldLabel);
                }
                else
                {
                    var type = SystemSelection.GetType();
                    GUI.Label(rect, $"<b>{type.Namespace}</b>.{type.Name}", LabelStyle);
                }
            }
            if (!showingChunkInfoView)
            {
                ChunkInfoToggle(new Rect(kSystemListWidth + CurrentEntityViewWidth - kChunkInfoButtonWidth, 0f, kChunkInfoButtonWidth, kLineHeight));
            }
        }

        private void ChunkInfoToggle(Rect rect)
        {
            ShowingChunkInfoView = GUI.Toggle(rect, ShowingChunkInfoView, "Chunk Info", EditorStyles.miniButton);
        }

        private void EntityQueryList()
        {
            if (SystemSelection != null)
            {
                entityQueryListView.SetWidth(CurrentEntityViewWidth);
                var height = Mathf.Min(entityQueryListView.Height + BoxStyle.padding.vertical, position.height*0.5f);
                GUILayout.BeginVertical(BoxStyle, GUILayout.Height(height));

                entityQueryListView.OnGUI(GUIHelpers.GetExpandingRect());
                GUILayout.EndVertical();
            }
            else if (WorldSelection != null)
            {
                GUILayout.BeginHorizontal();
                filterUI.OnGUI();
                GUILayout.FlexibleSpace();
                GUILayout.Label(entityListView.EntityCount.ToString());
                GUILayout.EndHorizontal();
            }
        }

        private EntityListQuery filterQuery;
        private World systemSelectionWorld;
        private const float kLineHeight = 18f;

        public void SetAllEntitiesFilter(EntityListQuery entityQuery)
        {
            filterQuery = entityQuery;
            if (WorldSelection == null || SystemSelection != null)
                return;
            ApplyAllEntitiesFilter();
        }

        private void ApplyAllEntitiesFilter()
        {
            SetEntityListSelection(filterQuery, false, true);
        }

        void EntityList()
        {
            GUILayout.BeginVertical(BoxStyle);
            entityListView.OnGUI(GUIHelpers.GetExpandingRect());
            GUILayout.EndVertical();
        }

        private void ChunkInfoView()
        {
            GUILayout.BeginHorizontal(BoxStyle);
            if (entityListView.ShowingSomething)
            {
                GUILayout.Label($"Matching chunks: {entityListView.ChunkArray.Length}");
            }
            GUILayout.FlexibleSpace();
            ChunkInfoToggle(GUILayoutUtility.GetRect(kChunkInfoButtonWidth, kLineHeight));
            GUILayout.EndHorizontal();
            if (entityListView.ShowingSomething)
            {
                GUILayout.BeginHorizontal(BoxStyle);
                chunkInfoListView.OnGUI(GUIHelpers.GetExpandingRect());
                GUILayout.EndHorizontal();
                if (chunkInfoListView.HasSelection())
                {
                    GUILayout.BeginHorizontal();
                    GUILayout.FlexibleSpace();
                    if (GUILayout.Button("Clear Selection"))
                    {
                        chunkInfoListView.ClearSelection();
                        EditorGUIUtility.ExitGUI();
                    }
                    GUILayout.EndHorizontal();
                }
            }
        }

        private void OnSelectionChange()
        {
            if (Selection.activeObject != selectionProxy)
            {
                entityListView.SelectNothing();
            }
        }

        private void OnGUI()
        {
            if (Event.current.type == EventType.Layout)
            {
                systemListView.ReloadIfNecessary();
                filterUI.GetTypes();
                entityQueryListView.ReloadIfNecessary();
                entityListView.ReloadIfNecessary();
            }

            if (Selection.activeObject == selectionProxy)
            {
                if (!selectionProxy.Exists)
                {
                    Selection.activeObject = null;
                    entityListView.SelectNothing();
                }
            }
            GUILayout.BeginArea(new Rect(0f, 0f, kSystemListWidth, position.height)); // begin System side
            SystemHeader();

            GUILayout.BeginVertical(BoxStyle);
            SystemList();
            GUILayout.EndVertical();

            GUILayout.EndArea(); // end System side

            EntityHeader();

            GUILayout.BeginArea(new Rect(kSystemListWidth, kLineHeight, CurrentEntityViewWidth, position.height - kLineHeight));
            EntityQueryList();
            EntityList();
            GUILayout.EndArea();

            if (showingChunkInfoView)
            {
                GUILayout.BeginArea(new Rect(kSystemListWidth + CurrentEntityViewWidth, 0f, kChunkInfoViewWidth + 1, position.height));
                ChunkInfoView();
                GUILayout.EndArea();
            }

            repaintLimiter.RecordRepaint();
        }
    }
}
