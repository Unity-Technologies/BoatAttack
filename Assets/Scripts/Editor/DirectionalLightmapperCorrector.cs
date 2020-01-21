using UnityEditor;
using UnityEngine;

public class DirectionalLightmapperCorrector : AssetPostprocessor
{
    private void OnPostprocessTexture(Texture2D texture)
    {
        if (!(assetPath.Contains("Lightmap-") && assetPath.Contains("_comp_dir")))
            return;
    
        Color[] c = texture.GetPixels();

        for (int i = 0; i < c.Length; i++)
        {
            c[i].a = Mathf.Max(c[i].a, 0.1f);
        }
        texture.SetPixels(c);
        texture.Apply(true);
    }
}
