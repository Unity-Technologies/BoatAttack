using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace BoatAttack
{
    /// <summary>
    /// CIC 스타일 원형 레이더 (MaskableGraphic 기반)
    /// - 삼각형 선박 마커 (방향 표시)
    /// - 섬 지형 렌더링 (Island 태그)
    /// - 범위 밖 선박 자동 숨김
    /// - 원형 좌표계
    /// </summary>
    [RequireComponent(typeof(CanvasRenderer))]
    public class RadarDisplay : MaskableGraphic
    {
        [Header("=== References ===")]
        public DefenseEnvController envController;

        [Header("=== Radar Settings ===")]
        [Tooltip("레이더 탐지 반경 (미터)")]
        public float radarRange = 1000f;

        [Tooltip("자동 범위 맞춤")]
        public bool autoFitRange = false;

        [Range(1.1f, 2.0f)]
        public float autoFitMargin = 1.3f;

        [Header("=== Marker Size ===")]
        public float friendlyMarkerSize = 16f;
        public float enemyMarkerSize = 14f;
        public float mothershipMarkerSize = 20f;

        [Header("=== Colors ===")]
        public Color friendlyColor = new Color(0.2f, 0.85f, 1f, 1f);
        public Color enemyColor = new Color(1f, 0.25f, 0.2f, 1f);
        public Color mothershipColor = new Color(0.85f, 0.85f, 1f, 1f);
        public Color webLineColor = new Color(0.3f, 1f, 0.5f, 0.6f);
        public Color ringColor = new Color(0.15f, 0.4f, 0.15f, 0.4f);
        public Color sweepColor = new Color(0.2f, 1f, 0.3f, 0.25f);
        public Color gridColor = new Color(0.1f, 0.25f, 0.1f, 0.3f);
        public Color bgCircleColor = new Color(0.02f, 0.04f, 0.02f, 0.95f);
        public Color islandColor = new Color(0.12f, 0.25f, 0.1f, 0.7f);

        [Header("=== Sweep ===")]
        public float sweepSpeed = 60f;

        [Header("=== Range Rings ===")]
        public int ringCount = 4;

        [Header("=== Island ===")]
        [Tooltip("섬 메시 최대 삼각형 수")]
        public int maxIslandTriangles = 300;

        struct IslandMeshData
        {
            public Vector2[] vertices;
            public int[] triangles;
        }

        struct ShipRenderData
        {
            public Vector3 worldPos;
            public float heading;
            public Color markerColor;
            public float size;
            public bool isMothership;
        }

        List<IslandMeshData> _islandCache = new List<IslandMeshData>();
        List<ShipRenderData> _shipData = new List<ShipRenderData>();

        float _sweepAngle;
        Vector3 _radarWorldCenter;
        float _pixelRadius;
        bool _islandsCached;
        bool _hasWebLine;
        Vector2 _webP1, _webP2;

        protected override void Start()
        {
            base.Start();
            color = Color.white;
            raycastTarget = false;
            CacheIslands();
        }

        void LateUpdate()
        {
            if (envController == null) return;
            if (!_islandsCached) CacheIslands();

            CollectShipData();
            _sweepAngle += sweepSpeed * Time.unscaledDeltaTime;
            if (_sweepAngle >= 360f) _sweepAngle -= 360f;
            SetVerticesDirty();
        }

        protected override void OnPopulateMesh(VertexHelper vh)
        {
            vh.Clear();

            Rect rect = rectTransform.rect;
            _pixelRadius = Mathf.Min(rect.width, rect.height) * 0.5f;
            float cx = rect.center.x;
            float cy = rect.center.y;

            if (envController == null || _pixelRadius < 1f) return;

            if (envController.motherShip != null)
                _radarWorldCenter = envController.motherShip.transform.position;

            if (autoFitRange) CalculateAutoRange();

            // 1. 배경 원
            DrawFilledCircle(vh, cx, cy, _pixelRadius, bgCircleColor, 64);

            // 2. 격자 (십자선)
            DrawLine(vh, cx - _pixelRadius * 0.9f, cy, cx + _pixelRadius * 0.9f, cy, 1f, gridColor);
            DrawLine(vh, cx, cy - _pixelRadius * 0.9f, cx, cy + _pixelRadius * 0.9f, 1f, gridColor);

            // 3. 거리 링
            for (int i = 1; i <= ringCount; i++)
            {
                float frac = (float)i / (ringCount + 1);
                DrawCircleOutline(vh, cx, cy, _pixelRadius * frac, 1f, ringColor, 48);
            }
            DrawCircleOutline(vh, cx, cy, _pixelRadius - 1f, 1.5f, ringColor * 1.5f, 64);

            // 4. 섬 지형
            DrawIslands(vh, cx, cy);

            // 5. 웹 라인 (범위 내만)
            if (_hasWebLine)
            {
                float d1 = new Vector2(_webP1.x - cx, _webP1.y - cy).magnitude;
                float d2 = new Vector2(_webP2.x - cx, _webP2.y - cy).magnitude;
                if (d1 < _pixelRadius && d2 < _pixelRadius)
                    DrawLine(vh, _webP1.x, _webP1.y, _webP2.x, _webP2.y, 2f, webLineColor);
            }

            // 6. 선박 마커
            foreach (var ship in _shipData)
            {
                Vector2 rp = WorldToLocal(ship.worldPos, cx, cy);
                float dist = new Vector2(rp.x - cx, rp.y - cy).magnitude;
                if (dist > _pixelRadius - 2f) continue; // 범위 밖 → 숨김

                if (ship.isMothership)
                    DrawDiamond(vh, rp.x, rp.y, ship.size, ship.markerColor);
                else
                    DrawTriangleMarker(vh, rp.x, rp.y, ship.heading, ship.size, ship.markerColor);
            }

            // 7. 스위프 라인
            float sweepRad = _sweepAngle * Mathf.Deg2Rad;
            float sx = cx + Mathf.Sin(sweepRad) * _pixelRadius * 0.9f;
            float sy = cy + Mathf.Cos(sweepRad) * _pixelRadius * 0.9f;
            DrawLine(vh, cx, cy, sx, sy, 2f, sweepColor);
        }

        #region Data Collection

        void CollectShipData()
        {
            _shipData.Clear();
            _hasWebLine = false;

            Rect rect = rectTransform.rect;
            float cx = rect.center.x;
            float cy = rect.center.y;

            if (envController.motherShip != null)
            {
                _shipData.Add(new ShipRenderData
                {
                    worldPos = envController.motherShip.transform.position,
                    heading = envController.motherShip.transform.eulerAngles.y,
                    markerColor = mothershipColor,
                    size = mothershipMarkerSize,
                    isMothership = true
                });
            }

            AddShipAgent(envController.defenseAgent1, friendlyColor, friendlyMarkerSize);
            AddShipAgent(envController.defenseAgent2, friendlyColor, friendlyMarkerSize);

            if (envController.defenseAgent1 != null && envController.defenseAgent2 != null)
            {
                _webP1 = WorldToLocal(envController.defenseAgent1.transform.position, cx, cy);
                _webP2 = WorldToLocal(envController.defenseAgent2.transform.position, cx, cy);
                _hasWebLine = true;
            }

            if (envController.enemyShips != null)
            {
                foreach (var enemy in envController.enemyShips)
                {
                    if (enemy != null && enemy.activeInHierarchy)
                        AddShip(enemy, enemyColor, enemyMarkerSize);
                }
            }
        }

        void AddShipAgent(DefenseAgent agent, Color col, float size)
        {
            if (agent == null) return;
            _shipData.Add(new ShipRenderData
            {
                worldPos = agent.transform.position,
                heading = agent.transform.eulerAngles.y,
                markerColor = col,
                size = size,
                isMothership = false
            });
        }

        void AddShip(GameObject ship, Color col, float size)
        {
            if (ship == null) return;
            _shipData.Add(new ShipRenderData
            {
                worldPos = ship.transform.position,
                heading = ship.transform.eulerAngles.y,
                markerColor = col,
                size = size,
                isMothership = false
            });
        }

        #endregion

        #region Island Cache

        void CacheIslands()
        {
            _islandCache.Clear();
            _islandsCached = true;

            GameObject[] islands = null;
            try { islands = GameObject.FindGameObjectsWithTag("Island"); }
            catch (UnityException) { return; }
            if (islands == null || islands.Length == 0) return;

            foreach (var island in islands)
            {
                var terrain = island.GetComponent<Terrain>();
                if (terrain != null) { CacheTerrainIsland(terrain); continue; }

                foreach (var mf in island.GetComponentsInChildren<MeshFilter>())
                {
                    if (mf.sharedMesh != null) CacheMeshIsland(mf);
                }
            }
            Debug.Log($"[RadarDisplay] 섬 {_islandCache.Count}개 캐시됨");
        }

        void CacheMeshIsland(MeshFilter mf)
        {
            var mesh = mf.sharedMesh;
            var verts = mesh.vertices;
            var tris = mesh.triangles;
            var tf = mf.transform;

            int totalTris = tris.Length / 3;
            int step = Mathf.Max(1, totalTris / maxIslandTriangles);

            var xzList = new List<Vector2>();
            var triList = new List<int>();
            var map = new Dictionary<int, int>();

            for (int t = 0; t < totalTris; t += step)
            {
                int i0 = tris[t * 3], i1 = tris[t * 3 + 1], i2 = tris[t * 3 + 2];
                triList.Add(MapVert(i0, verts, tf, xzList, map));
                triList.Add(MapVert(i1, verts, tf, xzList, map));
                triList.Add(MapVert(i2, verts, tf, xzList, map));
            }

            if (xzList.Count > 0)
                _islandCache.Add(new IslandMeshData { vertices = xzList.ToArray(), triangles = triList.ToArray() });
        }

        int MapVert(int idx, Vector3[] verts, Transform tf, List<Vector2> list, Dictionary<int, int> map)
        {
            if (map.TryGetValue(idx, out int i)) return i;
            Vector3 wp = tf.TransformPoint(verts[idx]);
            int ni = list.Count;
            list.Add(new Vector2(wp.x, wp.z));
            map[idx] = ni;
            return ni;
        }

        void CacheTerrainIsland(Terrain terrain)
        {
            var td = terrain.terrainData;
            var pos = terrain.transform.position;
            int samples = 25;
            var pts = new List<Vector2>();

            for (int z = 0; z < samples; z++)
            {
                for (int x = 0; x < samples; x++)
                {
                    float nx = (float)x / (samples - 1);
                    float nz = (float)z / (samples - 1);
                    if (td.GetInterpolatedHeight(nx, nz) > 0.5f)
                        pts.Add(new Vector2(pos.x + nx * td.size.x, pos.z + nz * td.size.z));
                }
            }
            if (pts.Count > 0)
                _islandCache.Add(new IslandMeshData { vertices = pts.ToArray(), triangles = null });
        }

        #endregion

        #region Draw Islands

        void DrawIslands(VertexHelper vh, float cx, float cy)
        {
            foreach (var island in _islandCache)
            {
                if (island.triangles != null && island.triangles.Length > 0)
                {
                    int baseIdx = vh.currentVertCount;
                    foreach (var v in island.vertices)
                    {
                        Vector2 rp = XZToLocal(v, cx, cy);
                        AddVert(vh, rp.x, rp.y, islandColor);
                    }
                    for (int i = 0; i < island.triangles.Length; i += 3)
                    {
                        vh.AddTriangle(
                            baseIdx + island.triangles[i],
                            baseIdx + island.triangles[i + 1],
                            baseIdx + island.triangles[i + 2]);
                    }
                }
                else
                {
                    float dot = Mathf.Max(2f, _pixelRadius * 0.015f);
                    foreach (var v in island.vertices)
                    {
                        Vector2 rp = XZToLocal(v, cx, cy);
                        if (new Vector2(rp.x - cx, rp.y - cy).magnitude < _pixelRadius - 2f)
                            DrawFilledRect(vh, rp.x - dot, rp.y - dot, rp.x + dot, rp.y + dot, islandColor);
                    }
                }
            }
        }

        #endregion

        #region Coordinate Conversion

        Vector2 WorldToLocal(Vector3 wp, float cx, float cy)
        {
            float scale = _pixelRadius / radarRange;
            return new Vector2(cx + (wp.x - _radarWorldCenter.x) * scale,
                               cy + (wp.z - _radarWorldCenter.z) * scale);
        }

        Vector2 XZToLocal(Vector2 xz, float cx, float cy)
        {
            float scale = _pixelRadius / radarRange;
            return new Vector2(cx + (xz.x - _radarWorldCenter.x) * scale,
                               cy + (xz.y - _radarWorldCenter.z) * scale);
        }

        #endregion

        #region Auto Range

        void CalculateAutoRange()
        {
            float maxDist = 100f;
            if (envController.defenseAgent1 != null)
                maxDist = Mathf.Max(maxDist, HDist(envController.defenseAgent1.transform.position));
            if (envController.defenseAgent2 != null)
                maxDist = Mathf.Max(maxDist, HDist(envController.defenseAgent2.transform.position));
            if (envController.enemyShips != null)
                foreach (var e in envController.enemyShips)
                    if (e != null && e.activeInHierarchy)
                        maxDist = Mathf.Max(maxDist, HDist(e.transform.position));
            radarRange = Mathf.Max(1000f, maxDist * autoFitMargin);
        }

        float HDist(Vector3 wp)
        {
            float dx = wp.x - _radarWorldCenter.x, dz = wp.z - _radarWorldCenter.z;
            return Mathf.Sqrt(dx * dx + dz * dz);
        }

        #endregion

        #region Drawing Primitives

        void DrawTriangleMarker(VertexHelper vh, float px, float py, float heading, float size, Color col)
        {
            float rad = -heading * Mathf.Deg2Rad;
            float cos = Mathf.Cos(rad), sin = Mathf.Sin(rad);

            Vector2 tip = Rot(0, size * 0.6f, cos, sin);
            Vector2 left = Rot(-size * 0.35f, -size * 0.35f, cos, sin);
            Vector2 right = Rot(size * 0.35f, -size * 0.35f, cos, sin);

            int idx = vh.currentVertCount;
            AddVert(vh, px + tip.x, py + tip.y, col);
            AddVert(vh, px + left.x, py + left.y, col * 0.7f);
            AddVert(vh, px + right.x, py + right.y, col * 0.7f);
            vh.AddTriangle(idx, idx + 1, idx + 2);
        }

        void DrawDiamond(VertexHelper vh, float px, float py, float size, Color col)
        {
            float h = size * 0.5f;
            int idx = vh.currentVertCount;
            AddVert(vh, px, py + h, col);
            AddVert(vh, px + h, py, col);
            AddVert(vh, px, py - h, col);
            AddVert(vh, px - h, py, col);
            vh.AddTriangle(idx, idx + 1, idx + 2);
            vh.AddTriangle(idx, idx + 2, idx + 3);
        }

        Vector2 Rot(float x, float y, float cos, float sin)
        {
            return new Vector2(x * cos - y * sin, x * sin + y * cos);
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

        void DrawFilledRect(VertexHelper vh, float l, float b, float r, float t, Color col)
        {
            int idx = vh.currentVertCount;
            AddVert(vh, l, b, col);
            AddVert(vh, r, b, col);
            AddVert(vh, r, t, col);
            AddVert(vh, l, t, col);
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
