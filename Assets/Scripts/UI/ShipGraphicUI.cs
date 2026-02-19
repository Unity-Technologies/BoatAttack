using UnityEngine;
using UnityEngine.UI;

namespace BoatAttack
{
    /// <summary>
    /// 선박 실루엣 그래픽 (uGUI 프로시저럴 메시)
    /// Top-down view 군함 실루엣 - 스프라이트 없이 순수 코드로 그림
    /// </summary>
    [RequireComponent(typeof(CanvasRenderer))]
    public class ShipGraphicUI : MaskableGraphic
    {
        [Header("=== Ship Colors ===")]
        public Color hullColor = new Color(0.15f, 0.4f, 0.55f, 0.9f);
        public Color hullOutlineColor = new Color(0.2f, 0.85f, 1f, 1f);
        public Color bridgeColor = new Color(0.25f, 0.35f, 0.5f, 0.8f);
        public Color deckDetailColor = new Color(0.3f, 0.7f, 0.9f, 0.3f);

        [Header("=== Ship Shape ===")]
        [Range(0.15f, 0.4f)]
        [Tooltip("선폭 비율 (높이 대비)")]
        public float beamRatio = 0.22f;

        [Range(0.15f, 0.35f)]
        [Tooltip("선수 길이 비율")]
        public float bowRatio = 0.25f;

        [Range(0.05f, 0.15f)]
        [Tooltip("선미 길이 비율")]
        public float sternRatio = 0.08f;

        [Header("=== Outline ===")]
        [Range(1f, 5f)]
        public float outlineWidth = 2f;

        [Header("=== Style ===")]
        [Tooltip("true = 적군 스타일 (빨강계), false = 아군 스타일 (파랑계)")]
        public bool isEnemy = false;

        protected override void OnPopulateMesh(VertexHelper vh)
        {
            vh.Clear();

            Rect rect = rectTransform.rect;
            float w = rect.width;
            float h = rect.height;
            float cx = rect.center.x;
            float cy = rect.center.y;

            // 선박이 세로 방향 (위 = 선수)
            float halfBeam = w * beamRatio;
            float bowY = cy + h * 0.48f;
            float sternY = cy - h * 0.48f;
            float bowEndY = bowY - h * bowRatio;
            float sternStartY = sternY + h * sternRatio;

            // ========= Hull (선체) =========
            // 중심점 (fan triangulation 기준)
            int centerIdx = AddVertex(vh, cx, cy, hullColor);

            // 선수 (뾰족한 V자형)
            int bowTip = AddVertex(vh, cx, bowY, hullColor);
            int bowR1 = AddVertex(vh, cx + halfBeam * 0.15f, bowY - h * 0.06f, hullColor);
            int bowR2 = AddVertex(vh, cx + halfBeam * 0.45f, bowEndY + h * 0.04f, hullColor);
            int bowR3 = AddVertex(vh, cx + halfBeam * 0.75f, bowEndY, hullColor);

            // 중앙부 우현
            int midR1 = AddVertex(vh, cx + halfBeam * 0.95f, bowEndY - h * 0.05f, hullColor);
            int midR2 = AddVertex(vh, cx + halfBeam, cy - h * 0.02f, hullColor);
            int midR3 = AddVertex(vh, cx + halfBeam * 0.98f, cy - h * 0.15f, hullColor);

            // 선미 우현
            int sternR1 = AddVertex(vh, cx + halfBeam * 0.9f, sternStartY + h * 0.05f, hullColor);
            int sternR2 = AddVertex(vh, cx + halfBeam * 0.75f, sternStartY, hullColor);
            int sternR3 = AddVertex(vh, cx + halfBeam * 0.5f, sternY + h * 0.02f, hullColor);

            // 선미 중앙
            int sternCenter = AddVertex(vh, cx, sternY + h * 0.01f, hullColor);

            // 선미 좌현 (대칭)
            int sternL3 = AddVertex(vh, cx - halfBeam * 0.5f, sternY + h * 0.02f, hullColor);
            int sternL2 = AddVertex(vh, cx - halfBeam * 0.75f, sternStartY, hullColor);
            int sternL1 = AddVertex(vh, cx - halfBeam * 0.9f, sternStartY + h * 0.05f, hullColor);

            // 중앙부 좌현
            int midL3 = AddVertex(vh, cx - halfBeam * 0.98f, cy - h * 0.15f, hullColor);
            int midL2 = AddVertex(vh, cx - halfBeam, cy - h * 0.02f, hullColor);
            int midL1 = AddVertex(vh, cx - halfBeam * 0.95f, bowEndY - h * 0.05f, hullColor);

            // 선수 좌현
            int bowL3 = AddVertex(vh, cx - halfBeam * 0.75f, bowEndY, hullColor);
            int bowL2 = AddVertex(vh, cx - halfBeam * 0.45f, bowEndY + h * 0.04f, hullColor);
            int bowL1 = AddVertex(vh, cx - halfBeam * 0.15f, bowY - h * 0.06f, hullColor);

            // Fan triangulation (center → 순서대로)
            vh.AddTriangle(centerIdx, bowTip, bowR1);
            vh.AddTriangle(centerIdx, bowR1, bowR2);
            vh.AddTriangle(centerIdx, bowR2, bowR3);
            vh.AddTriangle(centerIdx, bowR3, midR1);
            vh.AddTriangle(centerIdx, midR1, midR2);
            vh.AddTriangle(centerIdx, midR2, midR3);
            vh.AddTriangle(centerIdx, midR3, sternR1);
            vh.AddTriangle(centerIdx, sternR1, sternR2);
            vh.AddTriangle(centerIdx, sternR2, sternR3);
            vh.AddTriangle(centerIdx, sternR3, sternCenter);
            vh.AddTriangle(centerIdx, sternCenter, sternL3);
            vh.AddTriangle(centerIdx, sternL3, sternL2);
            vh.AddTriangle(centerIdx, sternL2, sternL1);
            vh.AddTriangle(centerIdx, sternL1, midL3);
            vh.AddTriangle(centerIdx, midL3, midL2);
            vh.AddTriangle(centerIdx, midL2, midL1);
            vh.AddTriangle(centerIdx, midL1, bowL3);
            vh.AddTriangle(centerIdx, bowL3, bowL2);
            vh.AddTriangle(centerIdx, bowL2, bowL1);
            vh.AddTriangle(centerIdx, bowL1, bowTip);

            // ========= Hull Outline (선체 외곽선) =========
            DrawOutlineSegments(vh, cx, cy, halfBeam, bowY, bowEndY, sternY, sternStartY, h);

            // ========= Bridge / Superstructure (함교) =========
            float bridgeW = halfBeam * 0.45f;
            float bridgeBottom = cy + h * 0.02f;
            float bridgeTop = cy + h * 0.18f;
            DrawFilledRect(vh, cx - bridgeW, bridgeBottom, cx + bridgeW, bridgeTop, bridgeColor);

            // 함교 상부 (더 작은 사각형)
            float bridge2W = halfBeam * 0.25f;
            float bridge2Bottom = bridgeTop - h * 0.01f;
            float bridge2Top = bridgeTop + h * 0.06f;
            DrawFilledRect(vh, cx - bridge2W, bridge2Bottom, cx + bridge2W, bridge2Top,
                new Color(bridgeColor.r + 0.1f, bridgeColor.g + 0.1f, bridgeColor.b + 0.1f, bridgeColor.a));

            // ========= Deck Details (갑판 디테일) =========
            // 전방 갑판 라인
            float lineH = h * 0.004f;
            DrawFilledRect(vh, cx - halfBeam * 0.5f, bowEndY - h * 0.02f,
                cx + halfBeam * 0.5f, bowEndY - h * 0.02f + lineH, deckDetailColor);

            // 후방 갑판 라인
            DrawFilledRect(vh, cx - halfBeam * 0.6f, cy - h * 0.08f,
                cx + halfBeam * 0.6f, cy - h * 0.08f + lineH, deckDetailColor);

            DrawFilledRect(vh, cx - halfBeam * 0.55f, cy - h * 0.2f,
                cx + halfBeam * 0.55f, cy - h * 0.2f + lineH, deckDetailColor);

            // 중심선 (center line)
            float clW = outlineWidth * 0.4f;
            DrawFilledRect(vh, cx - clW, bowEndY + h * 0.01f, cx + clW, cy - h * 0.01f,
                new Color(deckDetailColor.r, deckDetailColor.g, deckDetailColor.b, deckDetailColor.a * 0.5f));

            // ========= Stern Platform (선미 구조물) =========
            float sternPlatW = halfBeam * 0.35f;
            float sternPlatBottom = sternStartY - h * 0.02f;
            float sternPlatTop = sternStartY + h * 0.04f;
            DrawFilledRect(vh, cx - sternPlatW, sternPlatBottom, cx + sternPlatW, sternPlatTop,
                new Color(bridgeColor.r * 0.8f, bridgeColor.g * 0.8f, bridgeColor.b * 0.8f, bridgeColor.a * 0.6f));

            // ========= Bow Gun (선수 포대) =========
            float gunSize = halfBeam * 0.15f;
            float gunY = bowEndY + h * 0.06f;
            DrawFilledRect(vh, cx - gunSize, gunY - gunSize, cx + gunSize, gunY + gunSize, bridgeColor);
            // 포신
            float barrelW = outlineWidth * 0.6f;
            DrawFilledRect(vh, cx - barrelW, gunY + gunSize, cx + barrelW, gunY + gunSize + h * 0.05f, hullOutlineColor * 0.7f);
        }

        private void DrawOutlineSegments(VertexHelper vh, float cx, float cy,
            float halfBeam, float bowY, float bowEndY, float sternY, float sternStartY, float h)
        {
            float ow = outlineWidth;
            Color oc = hullOutlineColor;

            // 선수 우현 외곽선
            DrawLine(vh, cx, bowY, cx + halfBeam * 0.75f, bowEndY, ow, oc);
            // 우현 측면
            DrawLine(vh, cx + halfBeam * 0.75f, bowEndY, cx + halfBeam, cy - h * 0.02f, ow, oc);
            DrawLine(vh, cx + halfBeam, cy - h * 0.02f, cx + halfBeam * 0.75f, sternStartY, ow, oc);
            // 선미 우현
            DrawLine(vh, cx + halfBeam * 0.75f, sternStartY, cx, sternY + h * 0.01f, ow, oc);
            // 선미 좌현
            DrawLine(vh, cx, sternY + h * 0.01f, cx - halfBeam * 0.75f, sternStartY, ow, oc);
            // 좌현 측면
            DrawLine(vh, cx - halfBeam * 0.75f, sternStartY, cx - halfBeam, cy - h * 0.02f, ow, oc);
            DrawLine(vh, cx - halfBeam, cy - h * 0.02f, cx - halfBeam * 0.75f, bowEndY, ow, oc);
            // 선수 좌현
            DrawLine(vh, cx - halfBeam * 0.75f, bowEndY, cx, bowY, ow, oc);
        }

        private void DrawLine(VertexHelper vh, float x1, float y1, float x2, float y2, float width, Color col)
        {
            float dx = x2 - x1;
            float dy = y2 - y1;
            float len = Mathf.Sqrt(dx * dx + dy * dy);
            if (len < 0.001f) return;

            float nx = -dy / len * width * 0.5f;
            float ny = dx / len * width * 0.5f;

            int idx = vh.currentVertCount;
            AddVertex(vh, x1 + nx, y1 + ny, col);
            AddVertex(vh, x1 - nx, y1 - ny, col);
            AddVertex(vh, x2 - nx, y2 - ny, col);
            AddVertex(vh, x2 + nx, y2 + ny, col);

            vh.AddTriangle(idx, idx + 1, idx + 2);
            vh.AddTriangle(idx, idx + 2, idx + 3);
        }

        private void DrawFilledRect(VertexHelper vh, float left, float bottom, float right, float top, Color col)
        {
            int idx = vh.currentVertCount;
            AddVertex(vh, left, bottom, col);
            AddVertex(vh, right, bottom, col);
            AddVertex(vh, right, top, col);
            AddVertex(vh, left, top, col);

            vh.AddTriangle(idx, idx + 1, idx + 2);
            vh.AddTriangle(idx, idx + 2, idx + 3);
        }

        private int AddVertex(VertexHelper vh, float x, float y, Color col)
        {
            int idx = vh.currentVertCount;
            UIVertex vert = UIVertex.simpleVert;
            vert.position = new Vector3(x, y, 0);
            vert.color = col;
            vh.AddVert(vert);
            return idx;
        }

        /// <summary>
        /// 아군/적군 스타일 프리셋 적용
        /// </summary>
        public void ApplyFriendlyStyle()
        {
            isEnemy = false;
            hullColor = new Color(0.12f, 0.3f, 0.5f, 0.9f);
            hullOutlineColor = new Color(0.2f, 0.85f, 1f, 1f);
            bridgeColor = new Color(0.2f, 0.35f, 0.5f, 0.8f);
            deckDetailColor = new Color(0.3f, 0.7f, 0.9f, 0.3f);
            SetVerticesDirty();
        }

        public void ApplyEnemyStyle()
        {
            isEnemy = true;
            hullColor = new Color(0.45f, 0.15f, 0.12f, 0.9f);
            hullOutlineColor = new Color(1f, 0.3f, 0.25f, 1f);
            bridgeColor = new Color(0.5f, 0.2f, 0.2f, 0.8f);
            deckDetailColor = new Color(1f, 0.4f, 0.3f, 0.3f);
            SetVerticesDirty();
        }
    }
}
