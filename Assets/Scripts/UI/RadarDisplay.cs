using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace BoatAttack
{
    /// <summary>
    /// 원형 레이더 디스플레이 - CIC 스타일 전장 시각화
    /// 원형 좌표계, 선박 헤딩 표시, 스위프 라인, 거리 링
    /// </summary>
    public class RadarDisplay : MonoBehaviour
    {
        [Header("=== References ===")]
        public DefenseEnvController envController;

        [Header("=== Radar Area ===")]
        [Tooltip("레이더 영역 RectTransform (정사각형 권장)")]
        public RectTransform radarRect;

        [Tooltip("레이더 표시 반경 (Unity 미터)")]
        public float radarRange = 500f;

        [Tooltip("모든 오브젝트 자동 맞춤")]
        public bool autoFitRange = true;

        [Range(1.1f, 2.0f)]
        public float autoFitMargin = 1.3f;

        [Header("=== Marker Size ===")]
        public float friendlyMarkerSize = 14f;
        public float enemyMarkerSize = 12f;
        public float mothershipMarkerSize = 18f;
        [Tooltip("방향 표시선 길이 배율 (마커 크기 대비)")]
        public float headingLineScale = 2.0f;

        [Header("=== Colors ===")]
        public Color friendlyColor = new Color(0.2f, 0.85f, 1f, 1f);
        public Color enemyColor = new Color(1f, 0.25f, 0.2f, 1f);
        public Color mothershipColor = new Color(0.85f, 0.85f, 1f, 1f);
        public Color webLineColor = new Color(0.3f, 1f, 0.5f, 0.6f);
        public Color ringColor = new Color(0.15f, 0.4f, 0.15f, 0.4f);
        public Color sweepColor = new Color(0.2f, 1f, 0.3f, 0.25f);
        public Color gridColor = new Color(0.1f, 0.25f, 0.1f, 0.3f);

        [Header("=== Sweep ===")]
        [Tooltip("스위프 라인 회전 속도 (도/초)")]
        public float sweepSpeed = 60f;

        [Header("=== Range Rings ===")]
        [Tooltip("거리 링 개수")]
        public int ringCount = 3;

        // 마커 풀 (dot + headingLine 쌍)
        private struct ShipMarker
        {
            public RectTransform root;
            public Image dot;
            public Image headingLine;
        }

        private List<ShipMarker> _markerPool = new List<ShipMarker>();
        private int _activeMarkerCount = 0;

        // 웹 라인
        private Image _webLine;

        // 스위프 라인
        private RectTransform _sweepLine;
        private float _sweepAngle = 0f;

        // 거리 링
        private List<Image> _rings = new List<Image>();

        // 십자선
        private Image _crossH;
        private Image _crossV;

        // 레이더 반지름 (픽셀)
        private float _radarPixelRadius;
        private Vector3 _radarCenter;

        private bool _initialized = false;

        private void Start()
        {
            BuildRadarOverlays();
            _initialized = true;
        }

        private void LateUpdate()
        {
            if (envController == null || radarRect == null) return;

            if (!_initialized) return;

            _radarPixelRadius = Mathf.Min(radarRect.rect.width, radarRect.rect.height) * 0.5f;

            // 레이더 중심 = 모선 위치
            if (envController.motherShip != null)
                _radarCenter = envController.motherShip.transform.position;

            if (autoFitRange)
                CalculateAutoRange();

            // 스위프 애니메이션
            AnimateSweep();

            // 마커 그리기
            _activeMarkerCount = 0;

            // 모선
            if (envController.motherShip != null)
            {
                var ms = envController.motherShip;
                DrawShipMarker(ms.transform.position, ms.transform.eulerAngles.y,
                    mothershipColor, mothershipMarkerSize, true);
            }

            // 아군
            if (envController.defenseAgent1 != null)
            {
                DrawShipMarker(envController.defenseAgent1.transform.position,
                    envController.defenseAgent1.transform.eulerAngles.y,
                    friendlyColor, friendlyMarkerSize);
            }
            if (envController.defenseAgent2 != null)
            {
                DrawShipMarker(envController.defenseAgent2.transform.position,
                    envController.defenseAgent2.transform.eulerAngles.y,
                    friendlyColor, friendlyMarkerSize);
            }

            // 적군
            if (envController.enemyShips != null)
            {
                foreach (var enemy in envController.enemyShips)
                {
                    if (enemy != null && enemy.activeInHierarchy)
                    {
                        DrawShipMarker(enemy.transform.position,
                            enemy.transform.eulerAngles.y,
                            enemyColor, enemyMarkerSize);
                    }
                }
            }

            // 웹 라인 (아군 2대 연결)
            UpdateWebLine();

            // 미사용 마커 숨기기
            for (int i = _activeMarkerCount; i < _markerPool.Count; i++)
                _markerPool[i].root.gameObject.SetActive(false);
        }

        #region Draw Ship Marker

        private void DrawShipMarker(Vector3 worldPos, float heading, Color color, float size, bool isMothership = false)
        {
            // 원형 좌표 변환
            Vector2 radarPos = WorldToRadar(worldPos);

            // 원형 클리핑: 레이더 원 바깥이면 가장자리에 클램프
            float dist = radarPos.magnitude;
            float maxRadius = _radarPixelRadius - size;
            if (dist > maxRadius && maxRadius > 0)
            {
                radarPos = radarPos.normalized * maxRadius;
            }

            ShipMarker marker = GetOrCreateMarker();

            // 위치
            marker.root.anchoredPosition = radarPos;

            // 헤딩 회전 (Unity Y축 → UI Z축 역방향)
            if (!isMothership)
            {
                marker.root.localRotation = Quaternion.Euler(0, 0, -heading);
                marker.headingLine.gameObject.SetActive(true);
            }
            else
            {
                marker.root.localRotation = Quaternion.Euler(0, 0, 45f); // 모선은 다이아몬드
                marker.headingLine.gameObject.SetActive(false);
            }

            // 크기
            marker.dot.rectTransform.sizeDelta = new Vector2(size, size);

            // 방향선 크기
            float lineLen = size * headingLineScale;
            marker.headingLine.rectTransform.sizeDelta = new Vector2(2f, lineLen);
            marker.headingLine.rectTransform.anchoredPosition = new Vector2(0, size * 0.5f + lineLen * 0.5f);

            // 색상
            marker.dot.color = color;
            marker.headingLine.color = new Color(color.r, color.g, color.b, 0.7f);

            marker.root.gameObject.SetActive(true);
        }

        private ShipMarker GetOrCreateMarker()
        {
            if (_activeMarkerCount < _markerPool.Count)
            {
                return _markerPool[_activeMarkerCount++];
            }

            // Root
            var rootObj = new GameObject($"Marker_{_markerPool.Count}");
            rootObj.transform.SetParent(radarRect, false);
            var rootRt = rootObj.AddComponent<RectTransform>();
            rootRt.anchorMin = new Vector2(0.5f, 0.5f);
            rootRt.anchorMax = new Vector2(0.5f, 0.5f);
            rootRt.pivot = new Vector2(0.5f, 0.5f);
            rootRt.sizeDelta = Vector2.zero;

            // Dot (중심 마커)
            var dotObj = new GameObject("Dot");
            dotObj.transform.SetParent(rootObj.transform, false);
            var dotRt = dotObj.AddComponent<RectTransform>();
            dotRt.anchorMin = new Vector2(0.5f, 0.5f);
            dotRt.anchorMax = new Vector2(0.5f, 0.5f);
            dotRt.pivot = new Vector2(0.5f, 0.5f);
            dotRt.anchoredPosition = Vector2.zero;
            var dotImg = dotObj.AddComponent<Image>();
            dotImg.raycastTarget = false;

            // Heading Line (방향 표시선 - 위쪽으로 돌출)
            var lineObj = new GameObject("HeadingLine");
            lineObj.transform.SetParent(rootObj.transform, false);
            var lineRt = lineObj.AddComponent<RectTransform>();
            lineRt.anchorMin = new Vector2(0.5f, 0.5f);
            lineRt.anchorMax = new Vector2(0.5f, 0.5f);
            lineRt.pivot = new Vector2(0.5f, 0.5f);
            var lineImg = lineObj.AddComponent<Image>();
            lineImg.raycastTarget = false;

            var marker = new ShipMarker
            {
                root = rootRt,
                dot = dotImg,
                headingLine = lineImg
            };

            _markerPool.Add(marker);
            _activeMarkerCount++;
            return marker;
        }

        #endregion

        #region Web Line

        private void UpdateWebLine()
        {
            if (envController.defenseAgent1 == null || envController.defenseAgent2 == null)
            {
                if (_webLine != null) _webLine.gameObject.SetActive(false);
                return;
            }

            if (_webLine == null)
            {
                var lineObj = new GameObject("WebLine");
                lineObj.transform.SetParent(radarRect, false);
                lineObj.transform.SetAsFirstSibling(); // 마커 뒤에 렌더링
                var rt = lineObj.AddComponent<RectTransform>();
                rt.anchorMin = new Vector2(0.5f, 0.5f);
                rt.anchorMax = new Vector2(0.5f, 0.5f);
                rt.pivot = new Vector2(0.5f, 0.5f);
                _webLine = lineObj.AddComponent<Image>();
                _webLine.raycastTarget = false;
                _webLine.color = webLineColor;
            }

            Vector2 p1 = WorldToRadar(envController.defenseAgent1.transform.position);
            Vector2 p2 = WorldToRadar(envController.defenseAgent2.transform.position);

            Vector2 mid = (p1 + p2) * 0.5f;
            float length = Vector2.Distance(p1, p2);
            float angle = Mathf.Atan2(p2.y - p1.y, p2.x - p1.x) * Mathf.Rad2Deg;

            _webLine.rectTransform.anchoredPosition = mid;
            _webLine.rectTransform.sizeDelta = new Vector2(length, 2f);
            _webLine.rectTransform.localRotation = Quaternion.Euler(0, 0, angle);
            _webLine.gameObject.SetActive(true);
        }

        #endregion

        #region Sweep Animation

        private void AnimateSweep()
        {
            if (_sweepLine == null) return;
            _sweepAngle += sweepSpeed * Time.unscaledDeltaTime;
            if (_sweepAngle >= 360f) _sweepAngle -= 360f;
            _sweepLine.localRotation = Quaternion.Euler(0, 0, -_sweepAngle);
        }

        #endregion

        #region Radar Overlays (rings, sweep, crosshair)

        private void BuildRadarOverlays()
        {
            if (radarRect == null) return;

            float pixelRadius = Mathf.Min(radarRect.rect.width, radarRect.rect.height) * 0.5f;

            // 십자선
            _crossH = CreateOverlayImage("CrossH", radarRect, Vector2.zero,
                new Vector2(pixelRadius * 1.8f, 1f), gridColor);
            _crossV = CreateOverlayImage("CrossV", radarRect, Vector2.zero,
                new Vector2(1f, pixelRadius * 1.8f), gridColor);

            // 거리 링
            for (int i = 1; i <= ringCount; i++)
            {
                float frac = (float)i / (ringCount + 1);
                float ringSize = pixelRadius * 2f * frac;

                var ringObj = new GameObject($"Ring_{i}");
                ringObj.transform.SetParent(radarRect, false);
                ringObj.transform.SetAsFirstSibling();

                var rt = ringObj.AddComponent<RectTransform>();
                rt.anchorMin = new Vector2(0.5f, 0.5f);
                rt.anchorMax = new Vector2(0.5f, 0.5f);
                rt.pivot = new Vector2(0.5f, 0.5f);
                rt.anchoredPosition = Vector2.zero;
                rt.sizeDelta = new Vector2(ringSize, ringSize);

                var img = ringObj.AddComponent<Image>();
                img.color = ringColor;
                img.fillCenter = false;
                img.raycastTarget = false;
                // Note: 원형 링 표시를 위해서는 원형 스프라이트 필요
                // 기본 Image로는 사각형 테두리만 가능하므로 Outline으로 대체
                var outline = ringObj.AddComponent<Outline>();
                outline.effectColor = ringColor;
                outline.effectDistance = new Vector2(1, 1);
                img.color = new Color(0, 0, 0, 0); // 배경 투명

                _rings.Add(img);
            }

            // 스위프 라인
            var sweepObj = new GameObject("SweepLine");
            sweepObj.transform.SetParent(radarRect, false);
            _sweepLine = sweepObj.AddComponent<RectTransform>();
            _sweepLine.anchorMin = new Vector2(0.5f, 0.5f);
            _sweepLine.anchorMax = new Vector2(0.5f, 0.5f);
            _sweepLine.pivot = new Vector2(0.5f, 0f); // 하단 중심 기준 회전
            _sweepLine.anchoredPosition = Vector2.zero;
            _sweepLine.sizeDelta = new Vector2(2f, pixelRadius * 0.9f);

            var sweepImg = sweepObj.AddComponent<Image>();
            sweepImg.color = sweepColor;
            sweepImg.raycastTarget = false;
        }

        private Image CreateOverlayImage(string name, RectTransform parent,
            Vector2 pos, Vector2 size, Color color)
        {
            var obj = new GameObject(name);
            obj.transform.SetParent(parent, false);
            obj.transform.SetAsFirstSibling();

            var rt = obj.AddComponent<RectTransform>();
            rt.anchorMin = new Vector2(0.5f, 0.5f);
            rt.anchorMax = new Vector2(0.5f, 0.5f);
            rt.pivot = new Vector2(0.5f, 0.5f);
            rt.anchoredPosition = pos;
            rt.sizeDelta = size;

            var img = obj.AddComponent<Image>();
            img.color = color;
            img.raycastTarget = false;
            return img;
        }

        #endregion

        #region Coordinate Conversion

        /// <summary>
        /// 월드 좌표 → 레이더 로컬 좌표 (원형 좌표계)
        /// </summary>
        private Vector2 WorldToRadar(Vector3 worldPos)
        {
            float dx = worldPos.x - _radarCenter.x;
            float dz = worldPos.z - _radarCenter.z;

            // 정규화
            float nx = dx / radarRange;
            float nz = dz / radarRange;

            // 원형 레이더 → 픽셀 좌표 (z+ = 화면 위)
            return new Vector2(nx * _radarPixelRadius, nz * _radarPixelRadius);
        }

        #endregion

        #region Auto Range

        private void CalculateAutoRange()
        {
            float maxDist = 50f;

            if (envController.defenseAgent1 != null)
                maxDist = Mathf.Max(maxDist, HorizontalDist(envController.defenseAgent1.transform.position));
            if (envController.defenseAgent2 != null)
                maxDist = Mathf.Max(maxDist, HorizontalDist(envController.defenseAgent2.transform.position));

            if (envController.enemyShips != null)
            {
                foreach (var enemy in envController.enemyShips)
                {
                    if (enemy != null && enemy.activeInHierarchy)
                        maxDist = Mathf.Max(maxDist, HorizontalDist(enemy.transform.position));
                }
            }

            radarRange = maxDist * autoFitMargin;
        }

        private float HorizontalDist(Vector3 worldPos)
        {
            float dx = worldPos.x - _radarCenter.x;
            float dz = worldPos.z - _radarCenter.z;
            return Mathf.Sqrt(dx * dx + dz * dz); // 원형이므로 유클리드 거리 사용
        }

        #endregion
    }
}
