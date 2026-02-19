using UnityEngine;
using UnityEditor;

/// <summary>
/// Not ideal code, use at own peril...
/// </summary>
[ExecuteInEditMode]
public class CreateTexture2DArrayAsset : MonoBehaviour {

    public TextureFormat texFormat;
    public bool mipmaps;
    public Texture2D[] textures = new Texture2D[0];
    public Cubemap[] cubeMaps = new Cubemap[0];

    [ContextMenu("Create Texture2D Array asset")]
    void CreateTexture2DAsset()
    {
        //Texture2DArray array = new Texture2DArray(textures[0].width, textures[0].height, textures.Length, GraphicsFormatUtility.GetGraphicsFormat(TextureFormat.ARGB32, false), TextureCreationFlags.None);
        Texture2DArray array = new Texture2DArray(textures[0].width, textures[0].height, textures.Length, texFormat, mipmaps);
        Debug.Log(array);
        Debug.Log(array.format);
        for (int i = 0; i < textures.Length; i++)
            array.SetPixels(textures[i].GetPixels(), i);

        array.Apply();
        AssetDatabase.CreateAsset(array, "Assets/TextureArray.asset");
    }

    [ContextMenu("Create Cubemap Array asset")]
    void CreateCubeArrayAsset()
    {
        //Texture2DArray array = new Texture2DArray(textures[0].width, textures[0].height, textures.Length, GraphicsFormatUtility.GetGraphicsFormat(TextureFormat.ARGB32, false), TextureCreationFlags.None);
        TextureFormat tf = cubeMaps[0].format;
        int mipLevel = cubeMaps[0].mipmapCount;

        CubemapArray array = new CubemapArray(cubeMaps[0].width, cubeMaps.Length, texFormat, mipmaps);
        

        for (int i = 0; i < 6; i++) //iterate for each cube face
        {
            for (int j = 0; j < cubeMaps.Length; j++)
            {
                for (int m = 0; m < mipLevel; m++)
                {
                    CubemapFace face = (CubemapFace)i;
                    array.SetPixels(cubeMaps[j].GetPixels(face), face, j, m);
                }
            }       
        }

        for (int j = 0; j < 6; j++)
        {
            //CubemapFace face = (CubemapFace)i;
            // array.SetPixels(textures[j].GetPixels(), face, j);
            for (int i = 0; i < mipLevel; i++)
            {
                //for()
               // Graphics.CopyTexture(textures[j], 0, i, array, j, i);
            }
            
        }

        array.Apply();
        AssetDatabase.CreateAsset(array, "Assets/CubemapArray.asset");
    }
}
