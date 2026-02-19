using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace BoatAttack
{
    /// <summary>
    /// 3D 선박 프리뷰 렌더러
    /// RenderTexture + Camera로 선박 프리팹을 UI에 실시간 3D 표시
    /// 마우스 드래그: 회전, 스크롤: 줌, 우클릭 드래그: 상하 각도
    /// </summary>
    public class ShipPreviewRenderer : MonoBehaviour,
        IPointerDownHandler, IDragHandler, IScrollHandler
    {
        [Header("=== References ===")]
        public RawImage targetImage;
        public DefenseEnvController envController;

        [Header("=== Settings ===")]
        public bool isEnemy = false;
        public int textureSize = 512;
        public Color backgroundColor = new Color(0.04f, 0.06f, 0.1f, 1f);

        [Header("=== Camera ===")]
        public float cameraDistance = 15f;
        public float cameraHeight = 8f;
        public float minDistance = 5f;
        public float maxDistance = 40f;
        public float minHeight = 1f;
        public float maxHeight = 20f;

        [Header("=== Interaction ===")]
        [Tooltip("드래그 회전 감도")]
        public float dragRotateSpeed = 0.5f;
        [Tooltip("드래그 상하 감도")]
        public float dragHeightSpeed = 0.05f;
        [Tooltip("스크롤 줌 감도")]
        public float scrollZoomSpeed = 2f;
        [Tooltip("자동 회전 속도 (0이면 정지)")]
        public float autoRotateSpeed = 5f;

        Camera _previewCam;
        RenderTexture _renderTex;
        GameObject _shipClone;
        float _orbitAngle = 30f;
        bool _setupDone;
        bool _isDragging;

        static int _instanceCounter = 0;
        int _instanceId;

        Vector3 PreviewCenter => new Vector3(_instanceId * 60f, 500f, 0f);

        void Awake()
        {
            _instanceId = _instanceCounter++;
        }

        void OnEnable()
        {
            if (!_setupDone)
                Invoke(nameof(SetupPreview), 0.5f);
            else if (_previewCam != null)
                _previewCam.enabled = true;
        }

        void OnDisable()
        {
            CancelInvoke();
            if (_previewCam != null)
                _previewCam.enabled = false;
        }

        void OnDestroy()
        {
            Cleanup();
            _instanceCounter = Mathf.Max(0, _instanceCounter - 1);
        }

        void SetupPreview()
        {
            if (_setupDone) return;

            GameObject source = GetSourceShip();
            if (source == null)
            {
                Debug.LogWarning($"[ShipPreview] {(isEnemy ? "적군" : "아군")} 선박을 찾을 수 없습니다");
                return;
            }

            _renderTex = new RenderTexture(textureSize, textureSize, 24);
            _renderTex.antiAliasing = 2;

            var camObj = new GameObject($"PreviewCam_{(isEnemy ? "Enemy" : "Friendly")}");
            _previewCam = camObj.AddComponent<Camera>();
            _previewCam.targetTexture = _renderTex;
            _previewCam.clearFlags = CameraClearFlags.SolidColor;
            _previewCam.backgroundColor = backgroundColor;
            _previewCam.nearClipPlane = 0.5f;
            _previewCam.farClipPlane = 100f;
            _previewCam.fieldOfView = 30f;
            _previewCam.depth = -10;

            _shipClone = Instantiate(source, PreviewCenter, Quaternion.Euler(0, 30, 0));
            _shipClone.name = $"PreviewShip_{(isEnemy ? "Enemy" : "Friendly")}";
            DisableNonVisual(_shipClone);

            if (targetImage != null)
                targetImage.texture = _renderTex;

            UpdateCameraOrbit();
            _setupDone = true;
        }

        GameObject GetSourceShip()
        {
            if (envController == null) return null;
            if (isEnemy)
            {
                if (envController.enemyShips != null && envController.enemyShips.Length > 0)
                    return envController.enemyShips[0];
            }
            else
            {
                if (envController.defenseAgent1 != null)
                    return envController.defenseAgent1.gameObject;
            }
            return null;
        }

        void Update()
        {
            if (_shipClone == null || _previewCam == null) return;

            // 드래그 안 할 때만 자동 회전
            if (!_isDragging && autoRotateSpeed > 0)
                _orbitAngle += autoRotateSpeed * Time.unscaledDeltaTime;

            UpdateCameraOrbit();
        }

        void UpdateCameraOrbit()
        {
            if (_previewCam == null) return;
            float rad = _orbitAngle * Mathf.Deg2Rad;
            Vector3 offset = new Vector3(
                Mathf.Sin(rad) * cameraDistance,
                cameraHeight,
                Mathf.Cos(rad) * cameraDistance);

            _previewCam.transform.position = PreviewCenter + offset;
            _previewCam.transform.LookAt(PreviewCenter + Vector3.up * 2f);
        }

        #region Pointer Events (마우스 조작)

        public void OnPointerDown(PointerEventData eventData)
        {
            _isDragging = true;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                // 좌클릭 드래그: 수평 회전
                _orbitAngle -= eventData.delta.x * dragRotateSpeed;
            }

            if (eventData.button == PointerEventData.InputButton.Right)
            {
                // 우클릭 드래그: 상하 각도
                cameraHeight -= eventData.delta.y * dragHeightSpeed;
                cameraHeight = Mathf.Clamp(cameraHeight, minHeight, maxHeight);
            }

            // 좌클릭 + 세로 드래그도 높이 조절
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                cameraHeight -= eventData.delta.y * dragHeightSpeed * 0.5f;
                cameraHeight = Mathf.Clamp(cameraHeight, minHeight, maxHeight);
            }
        }

        public void OnScroll(PointerEventData eventData)
        {
            // 스크롤: 줌 인/아웃
            cameraDistance -= eventData.scrollDelta.y * scrollZoomSpeed;
            cameraDistance = Mathf.Clamp(cameraDistance, minDistance, maxDistance);
        }

        void LateUpdate()
        {
            // 마우스 버튼 떼면 자동 회전 복귀
            if (_isDragging && !Input.GetMouseButton(0) && !Input.GetMouseButton(1))
                _isDragging = false;
        }

        #endregion

        void DisableNonVisual(GameObject obj)
        {
            foreach (var rb in obj.GetComponentsInChildren<Rigidbody>(true))
            {
                rb.isKinematic = true;
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
            foreach (var col in obj.GetComponentsInChildren<Collider>(true))
                col.enabled = false;
            foreach (var mb in obj.GetComponentsInChildren<MonoBehaviour>(true))
                mb.enabled = false;
            foreach (var ps in obj.GetComponentsInChildren<ParticleSystem>(true))
                ps.gameObject.SetActive(false);
            foreach (var audio in obj.GetComponentsInChildren<AudioSource>(true))
                audio.enabled = false;
        }

        void Cleanup()
        {
            if (_shipClone != null) { Destroy(_shipClone); _shipClone = null; }
            if (_previewCam != null) { Destroy(_previewCam.gameObject); _previewCam = null; }
            if (_renderTex != null) { _renderTex.Release(); Destroy(_renderTex); _renderTex = null; }
            _setupDone = false;
        }
    }
}
