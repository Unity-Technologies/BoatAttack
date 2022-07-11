using UnityEngine;
using UnityEngine.UIElements;

public class SkewedElement : VisualElement
{
    private readonly Vertex[] _vertices = new Vertex[4];
    private readonly ushort[] _indices = {0, 1, 2, 2, 3, 0};
    public Texture2D Texture { get; private set; }
    public float SkewX { get; set; }
    public float SkewY { get; set; }

    public SkewedElement(Texture2D texture)
    {
        Texture = texture;
        generateVisualContent += OnGenerateVisualContent;

        _vertices[0].tint = Color.white;
        _vertices[1].tint = Color.white;
        _vertices[2].tint = Color.white;
        _vertices[3].tint = Color.white;
    }

    private void OnGenerateVisualContent(MeshGenerationContext mgc)
    {
        if (contentRect.width < 0.01f || contentRect.height < 0.01f)
            return;

        _vertices[0].position = new Vector3(contentRect.x, contentRect.height, Vertex.nearZ);
        _vertices[1].position = new Vector3(contentRect.x, contentRect.y, Vertex.nearZ);
        _vertices[2].position = new Vector3(contentRect.width, contentRect.y, Vertex.nearZ);
        _vertices[3].position = new Vector3(contentRect.width, contentRect.height, Vertex.nearZ);

        var mwd = mgc.Allocate(_vertices.Length, _indices.Length, Texture);

        var uvRegion = mwd.uvRegion;
        _vertices[0].uv = new Vector2(0, 0) * uvRegion.size + uvRegion.min;
        _vertices[1].uv = new Vector2(0, 1) * uvRegion.size + uvRegion.min;
        _vertices[2].uv = new Vector2(1, 1) * uvRegion.size + uvRegion.min;
        _vertices[3].uv = new Vector2(1, 0) * uvRegion.size + uvRegion.min;

        //Skew
        SkewImage(mwd.vertexCount);

        mwd.SetAllVertices(_vertices);
        mwd.SetAllIndices(_indices);
    }

    private void SkewImage(float vertexCount)
    {
        var xskew = contentRect.height * Mathf.Tan(Mathf.Deg2Rad * SkewX);
        var yskew = contentRect.width * Mathf.Tan(Mathf.Deg2Rad * SkewY);

        for (int i = 0; i < vertexCount; i++)
        {
            for (int j = 0; j < _vertices.Length; j++)
            {
                _vertices[j].position += new Vector3(
                    Mathf.Lerp(0, xskew, (_vertices[j].position.y - contentRect.y) / contentRect.height),
                    Mathf.Lerp(0, yskew, (_vertices[j].position.x - contentRect.x) / contentRect.width));
            }
        }
    }
}