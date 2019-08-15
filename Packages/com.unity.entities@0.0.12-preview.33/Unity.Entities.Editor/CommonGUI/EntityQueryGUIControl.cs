
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Unity.Entities.Editor
{
    internal class EntityQueryGUIControl
    {
        internal List<GUIStyle> styles;
        private List<GUIContent> names;
        private List<Rect> rects;
        private float height;
        private float width;

        public float Height
        {
            get { return height; }
        }

        public EntityQueryGUIControl(IEnumerable<ComponentType> types, bool archetypeQueryMode)
        {
            CalculateDrawingParts(types, null, archetypeQueryMode);
        }

        public EntityQueryGUIControl(IEnumerable<ComponentType> types, IEnumerable<ComponentType> readWriteTypes, bool archetypeQueryMode)
        {
            CalculateDrawingParts(types, readWriteTypes, archetypeQueryMode);
        }
        
        void CalculateDrawingParts(IEnumerable<ComponentType> types, IEnumerable<ComponentType> readWriteTypes, bool archetypeQueryMode)
        {
            var typeList = types.ToList();
            typeList.Sort((Comparison<ComponentType>) EntityQueryGUI.CompareTypes);
            styles = new List<GUIStyle>(typeList.Count);
            names = new List<GUIContent>(typeList.Count);
            rects = new List<Rect>(typeList.Count);
            foreach (var type in typeList)
            {
                GUIStyle style = null;
                if (readWriteTypes != null)
                {
                    if (type.AccessModeType == ComponentType.AccessMode.Exclude)
                    {
                        style = EntityDebuggerStyles.ComponentExclude;
                    }
                    else
                    {
                        foreach (var readWriteType in readWriteTypes)
                        {
                            if (readWriteType.TypeIndex == type.TypeIndex)
                            {
                            style = EntityQueryGUI.StyleForAccessMode(readWriteType.AccessModeType, archetypeQueryMode);
                                break;
                            }
                        }

                        if (style == null)
                        {
                            style = EntityDebuggerStyles.ComponentRequired;
                        }
                    }
                }
                else
                {
                    style = EntityQueryGUI.StyleForAccessMode(type.AccessModeType, archetypeQueryMode);
                }
                var content = new GUIContent((string) EntityQueryGUI.SpecifiedTypeName(type.GetManagedType()));

                styles.Add(style);
                names.Add(content);
            }
        }
        
        public void OnGUI(Vector2 position)
        {
            if (Event.current.type == EventType.Repaint)
            {
                for (var i = 0; i < rects.Count; ++i)
                {
                    var typeRect = rects[i];
                    typeRect.position += position;
                    styles[i].Draw(typeRect, names[i], false, false, false, false);
                }
            }
        }

        public void OnGUILayout(float width)
        {
            if (this.width != width)
                UpdateSize(width);
            var rect = GUILayoutUtility.GetRect(width, height);
            OnGUI(rect.position);
        }

        public void UpdateSize(float newWidth)
        {
            width = newWidth;
            
            rects.Clear();
            var x = 0f;
            var y = 0f;
            for (var i = 0; i < styles.Count; ++i)
            {
                var rect = new Rect(new Vector2(x, y), styles[i].CalcSize(names[i]));
                if (rect.xMax > width && x != 0f)
                {
                    rect.x = 0f;
                    rect.y += rect.height + 2f;
                }

                x = rect.xMax + 2f;
                y = rect.y;

                rects.Add(rect);
            }

            height = rects.Last().yMax;
        }
    }
}
