// code based off Unity Answers comment.
// http://answers.unity.com/comments/1871625/view.html
using UnityEngine.UI;
using UnityEngine;
 
public class SkewedImage : Image
{
    [SerializeField] public float skewX;
    [SerializeField] public float skewY;
 
    protected override void OnPopulateMesh(VertexHelper vh)
    {
        base.OnPopulateMesh(vh);

        var rect = rectTransform.rect;
        var height = rect.height;
        var width = rect.width;
        var xskew = height * Mathf.Tan(Mathf.Deg2Rad * skewX);
        var yskew = width * Mathf.Tan(Mathf.Deg2Rad * skewY);
 
        var ymin = rect.yMin;
        var xmin = rect.xMin;
        var v = new UIVertex();
        for (var i = 0; i < vh.currentVertCount; i++)
        {
            vh.PopulateUIVertex(ref v, i);
            v.position += new Vector3(Mathf.Lerp(0, xskew, (v.position.y - ymin) / height), Mathf.Lerp(0, yskew, (v.position.x - xmin) / width), 0);
            vh.SetUIVertex(v, i);
        }
 
    }

    protected override void UpdateMaterial()
    {
        base.UpdateMaterial();
    }
}
