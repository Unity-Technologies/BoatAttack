using UnityEngine;
using UnityEngine.UI;

public class UI_Mesh : Graphic
{
    public Mesh mesh;
    public float scale = 1.0f;
 
    protected override void OnPopulateMesh(VertexHelper vh)
    {
        vh.Clear();
 
        if (mesh == null)
        {
            return;
        }
 
        UIVertex vert = new UIVertex();
        vert.color = color;
 
        Vector3[] verts = mesh.vertices;
        int[] tris = mesh.triangles;
        
        var maxCoord = 0.0001f;
        for (var i = 0; i < verts.Length; i++)
        {
            maxCoord = Mathf.Max(Mathf.Abs(verts[i].x), Mathf.Abs(verts[i].y), maxCoord);
        }
 
        Vector2 meshScaler = scale * (0.5f * rectTransform.rect.size) / maxCoord;
 
        for (var i = 0; i < verts.Length; i++)
        {
            verts[i].z *= meshScaler.x;
            verts[i].y *= meshScaler.y;
            verts[i].x *= meshScaler.x;
            vert.position = verts[i];
            vh.AddVert(vert);
        }
 
        for (int i = 0; i < tris.Length; i += 3)
        {
            vh.AddTriangle(tris[i], tris[i + 1], tris[i + 2]);
        }
    }
 
    protected override void OnRectTransformDimensionsChange()
    {
        base.OnRectTransformDimensionsChange();
 
        SetVerticesDirty();
        SetMaterialDirty();
    }
}