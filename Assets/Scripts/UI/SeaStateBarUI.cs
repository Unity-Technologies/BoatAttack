using UnityEngine;
using UnityEngine.UI;

namespace BoatAttack
{
    /// <summary>
    /// 해상 상태 바 UI (MaskableGraphic 프로시저럴)
    /// 세그먼트 바 + 색상 그라데이션 (Calm→Moderate→Storm)
    /// </summary>
    [RequireComponent(typeof(CanvasRenderer))]
    public class SeaStateBarUI : MaskableGraphic
    {
        [Header("=== Sea State Data ===")]
        [Range(0, 5)]
        public float value = 0f;
        public float maxValue = 5f;

        [Header("=== Colors ===")]
        public Color bgColor = new Color(0.08f, 0.08f, 0.12f, 0.8f);
        public Color calmColor = new Color(0.2f, 0.8f, 0.3f, 1f);
        public Color moderateColor = new Color(1f, 0.85f, 0.2f, 1f);
        public Color stormColor = new Color(1f, 0.2f, 0.15f, 1f);
        public Color borderColor = new Color(0.3f, 0.3f, 0.4f, 0.5f);

        [Header("=== Style ===")]
        public int segmentCount = 10;
        public float barPadding = 3f;

        protected override void Start()
        {
            base.Start();
            color = Color.white;
            raycastTarget = false;
        }

        protected override void OnPopulateMesh(VertexHelper vh)
        {
            vh.Clear();

            Rect rect = rectTransform.rect;
            float left = rect.xMin, right = rect.xMax;
            float bottom = rect.yMin, top = rect.yMax;

            // 배경
            DrawRect(vh, left, bottom, right, top, bgColor);

            // 테두리
            float bw = 1f;
            DrawRect(vh, left, bottom, right, bottom + bw, borderColor);
            DrawRect(vh, left, top - bw, right, top, borderColor);
            DrawRect(vh, left, bottom, left + bw, top, borderColor);
            DrawRect(vh, right - bw, bottom, right, top, borderColor);

            // 세그먼트 바
            float fill = Mathf.Clamp01(value / maxValue);
            float barL = left + barPadding;
            float barB = bottom + barPadding;
            float barT = top - barPadding;
            float totalW = right - left - barPadding * 2;
            float segW = totalW / segmentCount;
            float gap = 2f;
            int filledSegs = Mathf.CeilToInt(fill * segmentCount);

            for (int i = 0; i < filledSegs; i++)
            {
                float t = (float)i / segmentCount;
                Color segColor = t < 0.4f
                    ? Color.Lerp(calmColor, moderateColor, t / 0.4f)
                    : Color.Lerp(moderateColor, stormColor, (t - 0.4f) / 0.6f);

                float sl = barL + i * segW + gap * 0.5f;
                float sr = barL + (i + 1) * segW - gap * 0.5f;
                sr = Mathf.Min(sr, barL + totalW * fill);
                if (sl >= sr) continue;

                DrawRect(vh, sl, barB, sr, barT, segColor);
            }
        }

        public void SetValue(float v)
        {
            value = v;
            SetVerticesDirty();
        }

        public string GetSeaStateLabel()
        {
            if (value < 0.5f) return "Calm";
            if (value < 1.0f) return "Light";
            if (value < 2.0f) return "Moderate";
            if (value < 3.0f) return "Rough";
            return "Storm";
        }

        void DrawRect(VertexHelper vh, float l, float b, float r, float t, Color col)
        {
            int idx = vh.currentVertCount;
            UIVertex vert = UIVertex.simpleVert;
            vert.color = col;
            vert.position = new Vector3(l, b, 0); vh.AddVert(vert);
            vert.position = new Vector3(r, b, 0); vh.AddVert(vert);
            vert.position = new Vector3(r, t, 0); vh.AddVert(vert);
            vert.position = new Vector3(l, t, 0); vh.AddVert(vert);
            vh.AddTriangle(idx, idx + 1, idx + 2);
            vh.AddTriangle(idx, idx + 2, idx + 3);
        }
    }
}
