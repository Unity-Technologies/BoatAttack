using System;
using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
public class ExtrusionHelper : MonoBehaviour
{
    public RectTransform parent;
    public RectTransform self;
    public Image img;
    private Material mat;
    public Material baseMaterial;

    private Vector2 baseOffset;
    private Vector2 targetOffset;
    private Vector2 offsetVel;

    private void Start()
    {
        baseOffset = targetOffset = self.anchoredPosition;
    }

    private void OnEnable()
    {
        if (mat && !Application.isPlaying)
        {
            DestroyMat();
        }
        
        
        
        if (!self) TryGetComponent(out self);
        
        if (baseMaterial && img && !mat)
        {
            mat = new Material(baseMaterial);
            mat.name += $"-temp-{gameObject.GetInstanceID()}";
            img.material = mat;
        }
    }

    private void OnDestroy()
    {
        if (mat)
        {
            DestroyMat();
        }
    }

    private void DestroyMat()
    {
        if (Application.isPlaying)
        {
            Destroy(mat);
        }
        else
        {
            DestroyImmediate(mat);
        }
    }

    private void OnDisable()
    {
        self.anchoredPosition = targetOffset = baseOffset;
    }

    private void Update()
    {
        if (self.anchoredPosition != targetOffset && Application.isPlaying)
        {
            self.anchoredPosition = Vector2.SmoothDamp(self.anchoredPosition, targetOffset, ref offsetVel, 0.05f);
        }
    }

    private void LateUpdate()
    {
        if (parent && self && mat && img)
        {
            var rect = parent.rect;
            
            mat.SetVector("_Offset", self.anchoredPosition);
            mat.SetVector("_Size", rect.size);
            mat.SetVector("_SelfSize", self.rect.size);

            Vector2 v = self.anchoredPosition / rect.size;
            Vector2 skew = Vector2.zero;
            if (img.GetType() == typeof(SkewedImage))
            {
                var sImg = img as SkewedImage;
                skew = new Vector2(sImg.skewX, sImg.skewY);
            }

            v.x *= skew.y == 0f ? 0f : rect.width / (skew.y * 100f);
            v.y *= skew.x == 0f ? 0f : rect.height / (skew.x * 100f);
            
            mat.SetVector("_Skew", v);
        }
    }

    public void Hover()
    {
        targetOffset = baseOffset * 2f;
    }

    public void Press()
    {
        targetOffset = baseOffset * 0.25f;
    }

    public void Exit()
    {
        targetOffset = baseOffset;
    }
}
