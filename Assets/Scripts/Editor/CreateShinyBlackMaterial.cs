using UnityEngine;
using UnityEditor;

namespace BoatAttack
{
    /// <summary>
    /// 윤기나는 검정색 Material을 생성하는 에디터 스크립트
    /// </summary>
    public class CreateShinyBlackMaterial : EditorWindow
    {
        private Texture2D gradientTexture;
        private float metallic = 0.8f;
        private float smoothness = 0.9f;
        private string materialName = "Shiny_Black_Gradient";
        private string savePath = "Assets/Materials";

        [MenuItem("Tools/Create Shiny Black Material")]
        public static void ShowWindow()
        {
            GetWindow<CreateShinyBlackMaterial>("Shiny Material Creator");
        }

        private void OnGUI()
        {
            GUILayout.Label("윤기나는 검정색 Material 생성기", EditorStyles.boldLabel);
            EditorGUILayout.Space();

            materialName = EditorGUILayout.TextField("Material 이름", materialName);
            gradientTexture = (Texture2D)EditorGUILayout.ObjectField("그라데이션 텍스처", gradientTexture, typeof(Texture2D), false);
            
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("물리적 속성", EditorStyles.boldLabel);
            metallic = EditorGUILayout.Slider("Metallic", metallic, 0f, 1f);
            smoothness = EditorGUILayout.Slider("Smoothness", smoothness, 0f, 1f);

            EditorGUILayout.Space();

            if (GUILayout.Button("Material 생성"))
            {
                CreateMaterial();
            }

            EditorGUILayout.Space();
            EditorGUILayout.HelpBox("Standard Shader를 사용하여 윤기나는 효과를 만듭니다.", MessageType.Info);
        }

        private void CreateMaterial()
        {
            Material mat = new Material(Shader.Find("Universal Render Pipeline/Lit"));
            mat.name = materialName;

            // 텍스처 설정
            if (gradientTexture != null)
            {
                mat.SetTexture("_BaseMap", gradientTexture);
                mat.SetColor("_BaseColor", Color.white);
            }
            else
            {
                // 텍스처가 없으면 검정색으로 설정
                mat.SetColor("_BaseColor", Color.black);
            }

            // Metallic 설정
            mat.SetFloat("_Metallic", metallic);
            
            // Smoothness 설정
            mat.SetFloat("_Smoothness", smoothness);

            // 디렉토리가 없으면 생성
            if (!AssetDatabase.IsValidFolder(savePath))
            {
                string[] folders = savePath.Split('/');
                string currentPath = folders[0];
                for (int i = 1; i < folders.Length; i++)
                {
                    if (!AssetDatabase.IsValidFolder(currentPath + "/" + folders[i]))
                    {
                        AssetDatabase.CreateFolder(currentPath, folders[i]);
                    }
                    currentPath += "/" + folders[i];
                }
            }

            // Material 저장
            string fullPath = savePath + "/" + materialName + ".mat";
            AssetDatabase.CreateAsset(mat, fullPath);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            Debug.Log($"Material 생성 완료: {fullPath}");
            
            // 생성된 Material 선택
            Selection.activeObject = mat;
            EditorGUIUtility.PingObject(mat);
        }
    }
}
