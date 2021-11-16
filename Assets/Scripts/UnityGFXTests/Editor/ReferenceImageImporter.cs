using UnityEditor;

public class ReferenceImageImporter : AssetPostprocessor
{
    private void OnPreprocessTexture()
    {
        if (assetPath.Contains("ReferenceImages") || assetPath.Contains("ActualImages"))
        {
            TextureImporter textureImporter  = (TextureImporter)assetImporter;
            textureImporter.compressionQuality = 0;
            textureImporter.mipmapEnabled = false;
            textureImporter.isReadable = true;
            textureImporter.npotScale = TextureImporterNPOTScale.None;
        }
    }
}
