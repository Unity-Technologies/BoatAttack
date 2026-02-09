using UnityEngine;
using UnityEditor;

namespace BoatAttack
{
    /// <summary>
    /// 윤기나는 검정색 그라데이션 Material을 즉시 생성하는 스크립트
    /// </summary>
    public class CreateShinyBlackMaterialQuick
    {
        [MenuItem("Tools/Create Shiny Black Material (Quick)")]
        public static void CreateMaterial()
        {
            // 텍스처 먼저 생성
            Texture2D gradientTexture = CreateGradientTexture(512, 512);
            
            // Material 생성
            Material mat = new Material(Shader.Find("Universal Render Pipeline/Lit"));
            mat.name = "Shiny_Black_Gradient";

            // 텍스처 설정
            mat.SetTexture("_BaseMap", gradientTexture);
            mat.SetColor("_BaseColor", Color.white);

            // Metallic 설정 (윤기나는 효과)
            mat.SetFloat("_Metallic", 0.8f);
            
            // Smoothness 설정 (매끄러운 표면)
            mat.SetFloat("_Smoothness", 0.9f);

            // 텍스처 저장
            string texturePath = "Assets/Textures/Gradient_Black_Shiny.png";
            if (!AssetDatabase.IsValidFolder("Assets/Textures"))
            {
                AssetDatabase.CreateFolder("Assets", "Textures");
            }
            byte[] pngData = gradientTexture.EncodeToPNG();
            System.IO.File.WriteAllBytes(texturePath, pngData);
            AssetDatabase.ImportAsset(texturePath);
            
            // 텍스처를 Material에 다시 할당 (에셋 참조로)
            Texture2D savedTexture = AssetDatabase.LoadAssetAtPath<Texture2D>(texturePath);
            mat.SetTexture("_BaseMap", savedTexture);

            // Material 저장
            string materialPath = "Assets/Materials/Shiny_Black_Gradient.mat";
            if (!AssetDatabase.IsValidFolder("Assets/Materials"))
            {
                AssetDatabase.CreateFolder("Assets", "Materials");
            }
            
            AssetDatabase.CreateAsset(mat, materialPath);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            Debug.Log($"Material 생성 완료: {materialPath}");
            Debug.Log($"텍스처 생성 완료: {texturePath}");
            
            // 생성된 Material 선택
            Selection.activeObject = mat;
            EditorGUIUtility.PingObject(mat);
        }

        private static Texture2D CreateGradientTexture(int width, int height)
        {
            Texture2D texture = new Texture2D(width, height, TextureFormat.RGBA32, true);

            // 검정색 그라데이션 생성 (위에서 아래로)
            for (int y = 0; y < height; y++)
            {
                float t = (float)y / height;
                
                // 검정 → 어두운 회색 → 검정 그라데이션
                Color color;
                if (t < 0.5f)
                {
                    // 위쪽: 검정 → 어두운 회색
                    color = Color.Lerp(Color.black, new Color(0.1f, 0.1f, 0.1f), t * 2f);
                }
                else
                {
                    // 아래쪽: 어두운 회색 → 검정
                    color = Color.Lerp(new Color(0.1f, 0.1f, 0.1f), Color.black, (t - 0.5f) * 2f);
                }
                
                for (int x = 0; x < width; x++)
                {
                    texture.SetPixel(x, y, color);
                }
            }

            texture.Apply();
            return texture;
        }
    }
}
