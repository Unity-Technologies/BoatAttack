using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Unity.Entities.Editor
{
    
    internal delegate void WorldSelectionSetter(World world);

    internal delegate bool ShowInactiveSystemsGetter();
    
    internal class WorldPopup
    {
        public const string kNoWorldName = "\n\n\n";

        private const string kPlayerLoopName = "Show Full Player Loop";
        private const string kShowInactiveSystemsName = "Show Inactive Systems";

        private GenericMenu Menu
        {
            get
            {
                var currentSelection = getWorldSelection();
                var menu = new GenericMenu();
                if (World.AllWorlds.Count > 0)
                {
                    foreach (var world in World.AllWorlds)
                    {
                        menu.AddItem(new GUIContent(world.Name), currentSelection == world, () => setWorldSelection(world));
                    }
                }
                else
                {
                    menu.AddDisabledItem(new GUIContent("No Worlds"));
                }
                menu.AddSeparator("");
                menu.AddItem(new GUIContent(kPlayerLoopName), currentSelection == null, () => setWorldSelection(null));
                menu.AddSeparator("");
                menu.AddItem(new GUIContent(kShowInactiveSystemsName), getShowInactiveSystems(), setShowInactiveSystems);
                return menu;
            }
        }

        private readonly WorldSelectionGetter getWorldSelection;
        private readonly WorldSelectionSetter setWorldSelection;
        
        private readonly ShowInactiveSystemsGetter getShowInactiveSystems;
        private readonly GenericMenu.MenuFunction setShowInactiveSystems;
        
        

        public WorldPopup(WorldSelectionGetter getWorld, WorldSelectionSetter setWorld, ShowInactiveSystemsGetter getShowSystems, GenericMenu.MenuFunction setShowSystems)
        {
            getWorldSelection = getWorld;
            setWorldSelection = setWorld;

            getShowInactiveSystems = getShowSystems;
            setShowInactiveSystems = setShowSystems;
        }
        
        public void OnGUI(bool showingPlayerLoop, string lastSelectedWorldName)
        {
            TryRestorePreviousSelection(showingPlayerLoop, lastSelectedWorldName);

            var worldName = getWorldSelection()?.Name ?? kPlayerLoopName;
            if (EditorGUILayout.DropdownButton(new GUIContent(worldName), FocusType.Passive))
            {
                Menu.ShowAsContext();
            }
        }

        internal void TryRestorePreviousSelection(bool showingPlayerLoop, string lastSelectedWorldName)
        {
            if (!showingPlayerLoop && ScriptBehaviourUpdateOrder.CurrentPlayerLoop.subSystemList != null)
            {
                if (lastSelectedWorldName == kNoWorldName)
                {
                    if (World.AllWorlds.Count > 0)
                        setWorldSelection(World.AllWorlds[0]);
                }
                else
                {
                    var namedWorld = World.AllWorlds.FirstOrDefault(x => x.Name == lastSelectedWorldName);
                    if (namedWorld != null)
                        setWorldSelection(namedWorld);
                }
            }
        }
    }
}
