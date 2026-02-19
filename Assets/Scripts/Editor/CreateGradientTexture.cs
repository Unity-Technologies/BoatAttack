using UnityEngine;
using UnityEditor;
using System.IO;

namespace BoatAttack
{
    /// <summary>
    /// 윤기나는 검정색 그라데이션 텍스처를 생성하는 에디터 스크립트
    /// </summary>
    public class CreateGradientTexture : EditorWindow
    {
        private int textureWidth = 512;
        private int textureHeight = 512;
        private Gradient gradient = new Gradient();
        private string textureName = "Gradient_Black_Shiny";
        private string savePath = "Assets/Textures";

        [MenuItem("Tools/Create Gradient Texture")]
        public static void ShowWindow()
        {
            GetWindow<CreateGradientTexture>("Gradient Texture Creator");
        }

        private void OnEnable()
        {
            // 기본 그라데이션 설정 (검정색 계열)
            gradient.SetKeys(
                new GradientColorKey[] 
                { 
                    new GradientColorKey(Color.black, 0.0f),
                    new GradientColorKey(new Color(0.1f, 0.1f, 0.1f), 0.5f),
                    new GradientColorKey(Color.black, 1.0f)
                },
                new GradientAlphaKey[] 
                { 
                    new GradientAlphaKey(1.0f, 0.0f),
                    new GradientAlphaKey(1.0f, 1.0f)
                }
            );
        }

        private void OnGUI()
        {
            GUILayout.Label("그라데이션 텍스처 생성기", EditorStyles.boldLabel);
            EditorGUILayout.Space();

            textureName = EditorGUILayout.TextField("텍스처 이름", textureName);
            textureWidth = EditorGUILayout.IntField("너비", textureWidth);
            textureHeight = EditorGUILayout.IntField("높이", textureHeight);
            savePath = EditorGUILayout.TextField("저장 경로", savePath);

            EditorGUILayout.Space();
            EditorGUILayout.LabelField("그라데이션 설정");
            gradient = EditorGUILayout.GradientField(gradient);

            EditorGUILayout.Space();

            if (GUILayout.Button("텍스처 생성"))
            {
                CreateTexture();
            }

            EditorGUILayout.Space();
            EditorGUILayout.HelpBox("생성된 텍스처는 지정된 경로에 저장됩니다.", MessageType.Info);
        }

        private void CreateTexture()
        {
            Texture2D texture = new Texture2D(textureWidth, textureHeight, TextureFormat.RGBA32, true);

            // 그라데이션 생성 (위에서 아래로)
            for (int y = 0; y < textureHeight; y++)
            {
                float t = (float)y / textureHeight;
                Color color = gradient.Evaluate(t);
                
                for (int x = 0; x < textureWidth; x++)
                {
                    texture.SetPixel(x, y, color);
                }
            }

            texture.Apply();

            // 파일로 저장
            byte[] pngData = texture.EncodeToPNG();
            string fullPath = Path.Combine(savePath, textureName + ".png");
            
            // 디렉토리가 없으면 생성
            if (!Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }

            File.WriteAllBytes(fullPath, pngData);
            AssetDatabase.Refresh();

            Debug.Log($"텍스처 생성 완료: {fullPath}");
            
            // 생성된 텍스처 선택
            Object asset = AssetDatabase.LoadAssetAtPath<Texture2D>(fullPath);
            Selection.activeObject = asset;
            EditorGUIUtility.PingObject(asset);
        }
    }
}
