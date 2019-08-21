using System.Collections.Generic;
using UnityEngine;

namespace Unity.Entities.Editor
{
    internal delegate void SetFilterAction(EntityListQuery entityQuery);

    internal class ComponentTypeFilterUI
    {
        private readonly WorldSelectionGetter getWorldSelection;
        private readonly SetFilterAction setFilter;

        private readonly List<bool> selectedFilterTypes = new List<bool>();
        private readonly List<ComponentType> filterTypes = new List<ComponentType>();

        private readonly List<EntityQuery> entityQueries = new List<EntityQuery>();

        public ComponentTypeFilterUI(SetFilterAction setFilter, WorldSelectionGetter worldSelectionGetter)
        {
            getWorldSelection = worldSelectionGetter;
            this.setFilter = setFilter;
        }

        internal bool TypeListValid()
        {
            return selectedFilterTypes.Count == 2 * (TypeManager.GetTypeCount() - 2); // First two entries are not ComponentTypes
        }

        internal void GetTypes()
        {
            if (getWorldSelection() == null) return;
            if (!TypeListValid())
            {
                filterTypes.Clear();
                selectedFilterTypes.Clear();
                var requiredTypes = new List<ComponentType>();
                var subtractiveTypes = new List<ComponentType>();
                var typeCount = TypeManager.GetTypeCount();
                filterTypes.Capacity = typeCount;
                selectedFilterTypes.Capacity = typeCount;
                foreach (var type in TypeManager.AllTypes)
                {
                    if (type.Type == typeof(Entity)) continue;
                    var typeIndex = TypeManager.GetTypeIndex(type.Type);
                    var componentType = ComponentType.FromTypeIndex(typeIndex);
                    if (componentType.GetManagedType() == null) continue;
                    requiredTypes.Add(componentType);
                    componentType.AccessModeType = ComponentType.AccessMode.Exclude;
                    subtractiveTypes.Add(componentType);
                    selectedFilterTypes.Add(false);
                    selectedFilterTypes.Add(false);
                }

                filterTypes.AddRange(requiredTypes);
                filterTypes.AddRange(subtractiveTypes);

                filterTypes.Sort(EntityQueryGUI.CompareTypes);
            }
        }

        public void OnGUI()
        {
            GUILayout.Label("Filter: ");
            var filterCount = 0;
            for (var i = 0; i < selectedFilterTypes.Count; ++i)
            {
                if (selectedFilterTypes[i])
                {
                    ++filterCount;
                    var style = filterTypes[i].AccessModeType == ComponentType.AccessMode.Exclude ? EntityDebuggerStyles.ComponentExclude : EntityDebuggerStyles.ComponentRequired;
                    GUILayout.Label(EntityQueryGUI.SpecifiedTypeName(filterTypes[i].GetManagedType()), style);
                }
            }
            if (filterCount == 0)
                GUILayout.Label("none");
            if (GUILayout.Button("Edit"))
            {
                ComponentTypeChooser.Open(GUIUtility.GUIToScreenPoint(GUILayoutUtility.GetLastRect().position), filterTypes, selectedFilterTypes, ComponentFilterChanged);
            }
            if (filterCount > 0)
            {
                if (GUILayout.Button("Clear"))
                {
                    for (var i = 0; i < selectedFilterTypes.Count; ++i)
                    {
                        selectedFilterTypes[i] = false;
                    }
                    ComponentFilterChanged();
                }
            }
        }

        internal EntityQuery GetExistingQuery(ComponentType[] components)
        {
            foreach (var existingGroup in entityQueries)
            {
                if (existingGroup.CompareComponents(components))
                    return existingGroup;
            }

            return null;
        }

        internal EntityQuery GetEntityQuery(ComponentType[] components)
        {
            var group = GetExistingQuery(components);
            if (group != null)
                return group;
            group = getWorldSelection().EntityManager.CreateEntityQuery(components);
            entityQueries.Add(group);

            return group;
        }

        private void ComponentFilterChanged()
        {
            var selectedTypes = new List<ComponentType>();
            for (var i = 0; i < selectedFilterTypes.Count; ++i)
            {
                if (selectedFilterTypes[i])
                    selectedTypes.Add(filterTypes[i]);
            }
            var group = GetEntityQuery(selectedTypes.ToArray());
            setFilter(new EntityListQuery(group));
        }
    }
}
