using UnityEditor;
using UnityEngine.AI;

namespace BoatAttack
{
    [CustomEditor(typeof(AiController))]
    public class AiControllerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            var ai = target as AiController;

            base.OnInspectorGUI();

            if(EditorApplication.isPlaying) Repaint();

            EditorGUILayout.LabelField("Current WP", ai.CurWp.ToString());

            var path = ai.NavPath;
            EditorGUILayout.LabelField("Path Status", path == null ? "N/A" : path.status.ToString());
        }
    }
}