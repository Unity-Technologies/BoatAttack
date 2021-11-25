using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

[CreateAssetMenu(fileName = "SpriteMeshGenerator.asset", menuName = "2D/Sprite Mesh Generator", order = 1)]
public class SpriteMeshGenerator : ScriptableObject
{
    public Sprite[] sprites;
    [SerializeField] private string hash;
    private void OnValidate()
    {
        if (sprites == null || sprites.Length <= 0) return;
        
        var curHash = "";
        foreach (var sprite in sprites)
        {
            if (AssetDatabase.TryGetGUIDAndLocalFileIdentifier(sprite, out var guid, out long _))
            {
                curHash += guid;
            }
        }

        if (hash == curHash) return;
        GenerateAndSaveMesh();
        hash = curHash;
    }

    private void GenerateAndSaveMesh()
    {
        try
        {
            AssetDatabase.StartAssetEditing();
            CleanSubassets();
            foreach (var sprite in sprites)
            {
                if(sprite == null) continue;
                var mesh = GenerateMeshFromSprite(sprite);
                AssetDatabase.AddObjectToAsset(mesh, this);
            }
        }
        finally
        {
            AssetDatabase.StopAssetEditing();
        }
    }

    public static Mesh GenerateMeshFromSprite(Sprite sprite)
    {
        // verts
        var verts = new List<Vector3>();
        sprite.vertices.ToList().ForEach(x => verts.Add(new Vector3(x.x, x.y, 0.0f)));
        // triangles
        var tris = new List<int>();
        sprite.triangles.ToList().ForEach(x => tris.Add(x));
        // normals
        var normals = new Vector3[verts.Count];
        for (var index = 0; index < normals.Length; index++)
        {
            normals[index] = Vector3.forward;
        }

        var mesh = new Mesh
        {
            name = sprite.name.Replace('.', '_'),
            vertices = verts.ToArray(),
            triangles = tris.ToArray(),
            normals = normals.ToArray(),
            colors32 = new Color32[verts.Count],
            uv = sprite.uv
        };

        return mesh;
    }

    private void CleanSubassets()
    {
        var subassets = AssetDatabase.LoadAllAssetsAtPath(AssetDatabase.GetAssetPath(this));

        foreach (var t in subassets)
        {
            if(t == this) continue;
            Debug.Log(t);
            DestroyImmediate(t, true);
        }
    }
}
