using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace BoatAttack
{
    /// <summary>
    /// CIC 스타일 원형 레이더 (MaskableGraphic 기반)
    /// - 삼각형 선박 마커 (방향 표시)
    /// - 섬 지형 렌더링 (Island 태그) - 공유 버텍스 그리드
    /// - 범위 밖 선박 자동 숨김
    /// - 원형 좌표계
    /// - 65000 버텍스 제한 준수
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
        [Tooltip("지형 샘플 해상도 (낮을수록 가벼움)")]
        public int terrainSamples = 6;
        [Tooltip("섬 메시 최대 삼각형 수 (개별)")]
        public int maxIslandTriangles = 15;
        [Tooltip("전체 섬 최대 버텍스 수")]
        public int maxTotalIslandVerts = 5000;

        // 공유 버텍스 기반 섬 데이터
        struct IslandMeshData
        {
            public Vector2[] vertices;  // XZ 월드좌표
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
        int _totalIslandVerts;

        float _sweepAngle;
        Vector3 _radarWorldCenter;
        float _pixelRadius;
        bool _islandsCached;
        bool _hasWebLine;
        Vector2 _webP1, _webP2;

        // 레이더 기본 요소 버텍스 예산 (원, 격자, 링, 스위프, 마커 등)
        const int RADAR_BASE_VERTS = 2000;

        protected override void Start()
        {
            base.Start();
            color = Color.white;
            raycastTarget = false;
            CacheIslands();
        }

        void LateUpdate()
        {
            _sweepAngle += sweepSpeed * Time.unscaledDeltaTime;
            if (_sweepAngle >= 360f) _sweepAngle -= 360f;

            if (envController == null)
            {
                SetVerticesDirty();
                return;
            }

            if (!_islandsCached) CacheIslands();
            CollectShipData();
            SetVerticesDirty();
        }

        protected override void OnPopulateMesh(VertexHelper vh)
        {
            vh.Clear();

            Rect rect = rectTransform.rect;
            _pixelRadius = Mathf.Min(rect.width, rect.height) * 0.5f;
            float cx = rect.center.x;
            float cy = rect.center.y;

            if (_pixelRadius < 1f) return;

            // 1. 배경 원 (항상 표시)
            DrawFilledCircle(vh, cx, cy, _pixelRadius, bgCircleColor, 32);

            // 2. 격자 (십자선)
            DrawLine(vh, cx - _pixelRadius * 0.9f, cy, cx + _pixelRadius * 0.9f, cy, 1f, gridColor);
            DrawLine(vh, cx, cy - _pixelRadius * 0.9f, cx, cy + _pixelRadius * 0.9f, 1f, gridColor);

            // 3. 거리 링
            for (int i = 1; i <= ringCount; i++)
            {
                float frac = (float)i / (ringCount + 1);
                DrawCircleOutline(vh, cx, cy, _pixelRadius * frac, 1f, ringColor, 24);
            }
            DrawCircleOutline(vh, cx, cy, _pixelRadius - 1f, 1.5f, ringColor * 1.5f, 32);

            // 스위프 라인 (항상 표시)
            float sweepRad = _sweepAngle * Mathf.Deg2Rad;
            float sx = cx + Mathf.Sin(sweepRad) * _pixelRadius * 0.9f;
            float sy = cy + Mathf.Cos(sweepRad) * _pixelRadius * 0.9f;
            DrawLine(vh, cx, cy, sx, sy, 2f, sweepColor);

            if (envController == null) return;

            if (envController.motherShip != null)
                _radarWorldCenter = envController.motherShip.transform.position;

            if (autoFitRange) CalculateAutoRange();

            // 4. 섬 지형 (버텍스 예산 체크 포함)
            DrawIslands(vh, cx, cy);

            // 5. 웹 라인
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
                if (dist > _pixelRadius - 2f) continue;

                if (ship.isMothership)
                    DrawDiamond(vh, rp.x, rp.y, ship.size, ship.markerColor);
                else
                    DrawTriangleMarker(vh, rp.x, rp.y, ship.heading, ship.size, ship.markerColor);
            }
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
            _totalIslandVerts = 0;

            GameObject[] islands = null;
            try { islands = GameObject.FindGameObjectsWithTag("Island"); }
            catch (UnityException) { return; }
            if (islands == null || islands.Length == 0) return;

            foreach (var island in islands)
            {
                if (_totalIslandVerts >= maxTotalIslandVerts) break;

                var terrain = island.GetComponent<Terrain>();
                if (terrain != null)
                {
                    CacheTerrainIsland(terrain);
                    continue;
                }

                var meshFilters = island.GetComponentsInChildren<MeshFilter>();
                if (meshFilters.Length > 0)
                {
                    foreach (var mf in meshFilters)
                    {
                        if (_totalIslandVerts >= maxTotalIslandVerts) break;
                        if (mf.sharedMesh != null) CacheMeshIsland(mf);
                    }
                }
                else
                {
                    // MeshFilter도 Terrain도 없으면 Renderer bounds 사용
                    var renderer = island.GetComponentInChildren<Renderer>();
                    if (renderer != null)
                        CacheBoundsIsland(renderer.bounds);
                }
            }
            Debug.Log($"[RadarDisplay] 섬 {_islandCache.Count}개 캐시됨 (총 버텍스: {_totalIslandVerts})");
        }

        void CacheMeshIsland(MeshFilter mf)
        {
            var mesh = mf.sharedMesh;
            if (mesh == null)
                return;

            // 메시가 읽기 불가능 → Renderer bounds로 사각형 폴백
            if (!mesh.isReadable)
            {
                var renderer = mf.GetComponent<Renderer>();
                if (renderer != null)
                    CacheBoundsIsland(renderer.bounds);
                return;
            }

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
                if (_totalIslandVerts + xzList.Count > maxTotalIslandVerts) break;

                int i0 = tris[t * 3], i1 = tris[t * 3 + 1], i2 = tris[t * 3 + 2];
                triList.Add(MapVert(i0, verts, tf, xzList, map));
                triList.Add(MapVert(i1, verts, tf, xzList, map));
                triList.Add(MapVert(i2, verts, tf, xzList, map));
            }

            if (xzList.Count > 0)
            {
                _islandCache.Add(new IslandMeshData { vertices = xzList.ToArray(), triangles = triList.ToArray() });
                _totalIslandVerts += xzList.Count;
            }
        }

        /// <summary>
        /// 메시 읽기 불가능 시 Renderer bounds로 불규칙 타원 생성
        /// 자연스러운 섬 형태 (10 segments, sin 변조로 울퉁불퉁)
        /// </summary>
        void CacheBoundsIsland(Bounds b)
        {
            const int seg = 10;
            if (_totalIslandVerts + seg + 1 > maxTotalIslandVerts) return;

            float cx = (b.min.x + b.max.x) * 0.5f;
            float cz = (b.min.z + b.max.z) * 0.5f;
            float rx = (b.max.x - b.min.x) * 0.5f;
            float rz = (b.max.z - b.min.z) * 0.5f;

            // 너무 작은 바운드는 무시
            if (rx < 1f && rz < 1f) return;

            var verts = new Vector2[seg + 1];
            verts[0] = new Vector2(cx, cz); // 중심점

            // bounds 크기 기반 시드 → 섬마다 다른 형태
            float seed = (cx * 0.13f + cz * 0.07f) % 6.28f;

            for (int i = 0; i < seg; i++)
            {
                float angle = i * Mathf.PI * 2f / seg;
                // 불규칙 변조: 0.8 ~ 1.0 범위로 들쭉날쭉
                float wobble = 0.82f + 0.18f * Mathf.Sin(angle * 3f + seed)
                                      + 0.08f * Mathf.Cos(angle * 5f + seed * 1.7f);
                verts[i + 1] = new Vector2(
                    cx + Mathf.Cos(angle) * rx * wobble,
                    cz + Mathf.Sin(angle) * rz * wobble);
            }

            // Fan triangulation (중심 → 둘레)
            var tris = new int[seg * 3];
            for (int i = 0; i < seg; i++)
            {
                tris[i * 3] = 0;
                tris[i * 3 + 1] = i + 1;
                tris[i * 3 + 2] = (i + 1) % seg + 1;
            }

            _islandCache.Add(new IslandMeshData { vertices = verts, triangles = tris });
            _totalIslandVerts += verts.Length;
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

        /// <summary>
        /// Terrain을 공유 버텍스 그리드로 캐시 (N*N 버텍스, 셀 단위 삼각형)
        /// </summary>
        void CacheTerrainIsland(Terrain terrain)
        {
            var td = terrain.terrainData;
            var pos = terrain.transform.position;
            int n = Mathf.Clamp(terrainSamples, 4, 20);

            // 버텍스 예산 체크
            if (_totalIslandVerts + n * n > maxTotalIslandVerts)
                n = Mathf.Max(4, (int)Mathf.Sqrt(maxTotalIslandVerts - _totalIslandVerts));

            // 높이 그리드 + 공유 버텍스 생성
            bool[,] isLand = new bool[n, n];
            Vector2[] gridVerts = new Vector2[n * n];
            int landCount = 0;

            for (int z = 0; z < n; z++)
            {
                for (int x = 0; x < n; x++)
                {
                    float nx = (float)x / (n - 1);
                    float nz = (float)z / (n - 1);

                    gridVerts[z * n + x] = new Vector2(
                        pos.x + nx * td.size.x,
                        pos.z + nz * td.size.z);

                    isLand[x, z] = td.GetInterpolatedHeight(nx, nz) > 0.5f;
                    if (isLand[x, z]) landCount++;
                }
            }
            if (landCount == 0) return;

            // 셀 단위 삼각형 생성 (공유 버텍스 참조)
            var tris = new List<int>();
            for (int z = 0; z < n - 1; z++)
            {
                for (int x = 0; x < n - 1; x++)
                {
                    if (!isLand[x, z] && !isLand[x + 1, z] &&
                        !isLand[x, z + 1] && !isLand[x + 1, z + 1])
                        continue;

                    int bl = z * n + x;
                    int br = z * n + x + 1;
                    int tl = (z + 1) * n + x;
                    int tr = (z + 1) * n + x + 1;

                    tris.Add(bl); tris.Add(tl); tris.Add(br);
                    tris.Add(br); tris.Add(tl); tris.Add(tr);
                }
            }

            if (tris.Count > 0)
            {
                _islandCache.Add(new IslandMeshData { vertices = gridVerts, triangles = tris.ToArray() });
                _totalIslandVerts += gridVerts.Length;
            }
        }

        #endregion

        #region Draw Islands

        void DrawIslands(VertexHelper vh, float cx, float cy)
        {
            int vertBudget = 64000 - vh.currentVertCount;

            foreach (var island in _islandCache)
            {
                if (island.vertices.Length > vertBudget) break;

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

                vertBudget -= island.vertices.Length;
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
