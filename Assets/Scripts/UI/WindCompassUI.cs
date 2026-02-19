using UnityEngine;
using UnityEngine.UI;

namespace BoatAttack
{
    /// <summary>
    /// 바람 방향 나침반 UI (MaskableGraphic 프로시저럴)
    /// 원형 나침반 + 방향 화살표 + 풍속 비례 길이
    /// </summary>
    [RequireComponent(typeof(CanvasRenderer))]
    public class WindCompassUI : MaskableGraphic
    {
        [Header("=== Wind Data ===")]
        public float windDirection = 0f; // 0=North, 90=East
        public float windStrength = 0f;
        public float maxStrength = 30f;

        [Header("=== Colors ===")]
        public Color compassColor = new Color(0.15f, 0.4f, 0.15f, 0.6f);
        public Color arrowColor = new Color(0.3f, 1f, 0.5f, 1f);
        public Color tickColor = new Color(0.4f, 0.6f, 0.4f, 0.8f);
        public Color centerColor = new Color(0.2f, 0.5f, 0.25f, 0.8f);

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
            float cx = rect.center.x;
            float cy = rect.center.y;
            float radius = Mathf.Min(rect.width, rect.height) * 0.45f;

            if (radius < 5f) return;

            // 외곽 원
            DrawCircleOutline(vh, cx, cy, radius, 1.5f, compassColor, 48);

            // 8방향 눈금
            for (int i = 0; i < 8; i++)
            {
                float angle = i * 45f * Mathf.Deg2Rad;
                bool isMajor = (i % 2 == 0);
                float innerR = radius * (isMajor ? 0.8f : 0.87f);
                float outerR = radius * 0.98f;
                float w = isMajor ? 2f : 1f;

                DrawLine(vh,
                    cx + Mathf.Sin(angle) * innerR, cy + Mathf.Cos(angle) * innerR,
                    cx + Mathf.Sin(angle) * outerR, cy + Mathf.Cos(angle) * outerR,
                    w, tickColor);
            }

            // N 마커 (상단 삼각형)
            float nY = cy + radius * 0.72f;
            float nSize = radius * 0.08f;
            int nIdx = vh.currentVertCount;
            AddVert(vh, cx, nY + nSize, arrowColor);
            AddVert(vh, cx - nSize * 0.6f, nY - nSize * 0.3f, arrowColor);
            AddVert(vh, cx + nSize * 0.6f, nY - nSize * 0.3f, arrowColor);
            vh.AddTriangle(nIdx, nIdx + 1, nIdx + 2);

            // 중심 점
            DrawFilledCircle(vh, cx, cy, 3f, centerColor, 12);

            // 바람 방향 화살표
            float strength01 = Mathf.Clamp01(windStrength / maxStrength);
            float arrowLen = radius * 0.65f * Mathf.Max(0.3f, strength01);
            float windRad = windDirection * Mathf.Deg2Rad;

            float tipX = cx + Mathf.Sin(windRad) * arrowLen;
            float tipY = cy + Mathf.Cos(windRad) * arrowLen;

            // 화살표 몸통
            float bodyWidth = 2f + strength01 * 2f;
            DrawLine(vh, cx, cy, tipX, tipY, bodyWidth, arrowColor);

            // 화살표 머리 (삼각형)
            float headSize = radius * 0.18f;
            float ha1 = windRad + Mathf.PI * 0.85f;
            float ha2 = windRad - Mathf.PI * 0.85f;

            int hi = vh.currentVertCount;
            AddVert(vh, tipX, tipY, arrowColor);
            AddVert(vh, tipX + Mathf.Sin(ha1) * headSize, tipY + Mathf.Cos(ha1) * headSize,
                new Color(arrowColor.r, arrowColor.g, arrowColor.b, 0.6f));
            AddVert(vh, tipX + Mathf.Sin(ha2) * headSize, tipY + Mathf.Cos(ha2) * headSize,
                new Color(arrowColor.r, arrowColor.g, arrowColor.b, 0.6f));
            vh.AddTriangle(hi, hi + 1, hi + 2);
        }

        public void SetWind(float direction, float strength)
        {
            windDirection = direction;
            windStrength = strength;
            SetVerticesDirty();
        }

        #region Drawing Helpers

        void DrawCircleOutline(VertexHelper vh, float cx, float cy, float r, float w, Color col, int seg)
        {
            for (int i = 0; i < seg; i++)
            {
                float a1 = (float)i / seg * Mathf.PI * 2f;
                float a2 = (float)(i + 1) / seg * Mathf.PI * 2f;
                DrawLine(vh,
                    cx + Mathf.Cos(a1) * r, cy + Mathf.Sin(a1) * r,
                    cx + Mathf.Cos(a2) * r, cy + Mathf.Sin(a2) * r,
                    w, col);
            }
        }

        void DrawFilledCircle(VertexHelper vh, float cx, float cy, float r, Color col, int seg)
        {
            int ci = AddVert(vh, cx, cy, col);
            int fi = vh.currentVertCount;
            for (int i = 0; i <= seg; i++)
            {
                float a = (float)i / seg * Mathf.PI * 2f;
                AddVert(vh, cx + Mathf.Cos(a) * r, cy + Mathf.Sin(a) * r, col);
                if (i > 0) vh.AddTriangle(ci, fi + i - 1, fi + i);
            }
        }

        void DrawLine(VertexHelper vh, float x1, float y1, float x2, float y2, float w, Color col)
        {
            float dx = x2 - x1, dy = y2 - y1;
            float len = Mathf.Sqrt(dx * dx + dy * dy);
            if (len < 0.001f) return;
            float nx = -dy / len * w * 0.5f, ny = dx / len * w * 0.5f;
            int idx = vh.currentVertCount;
            AddVert(vh, x1 + nx, y1 + ny, col);
            AddVert(vh, x1 - nx, y1 - ny, col);
            AddVert(vh, x2 - nx, y2 - ny, col);
            AddVert(vh, x2 + nx, y2 + ny, col);
            vh.AddTriangle(idx, idx + 1, idx + 2);
            vh.AddTriangle(idx, idx + 2, idx + 3);
        }

        int AddVert(VertexHelper vh, float x, float y, Color col)
        {
            int idx = vh.currentVertCount;
            UIVertex v = UIVertex.simpleVert;
            v.position = new Vector3(x, y, 0);
            v.color = col;
            vh.AddVert(v);
            return idx;
        }

        #endregion
    }
}
