using UnityEngine;
using WaterSystem;
using Unity.Mathematics;
using Unity.Collections;

namespace BoatAttack
{
    /// <summary>
    /// This controls the logic for the wind surfer
    /// </summary>
    public class WindsurferManager : MonoBehaviour
    {
        public Transform[] surfers;
        private NativeArray<float3> _points; // point to sample wave height
        private float3[] _heights; // height sameple from water system
        private float3[] _normals; // height sameple from water system
        private Vector3[] _smoothPositions; // the smoothed position
        private int _guid; // the objects GUID for wave height lookup

        // Use this for initialization
        private void Start()
        {
            // surfers 배열이 비어있으면 초기화하지 않음
            if (surfers == null || surfers.Length == 0)
            {
                Debug.LogWarning($"[WindsurferManager] surfers 배열이 비어있습니다. {gameObject.name}");
                return;
            }
            
            _guid = gameObject.GetInstanceID();

            _heights = new float3[surfers.Length];
            _normals = new float3[surfers.Length];
            _smoothPositions = new Vector3[surfers.Length];

            for (var i = 0; i < surfers.Length; i++)
            {
                if (surfers[i] != null)
                {
                    _smoothPositions[i] = surfers[i].position;
                }
            }
            _points = new NativeArray<float3>(surfers.Length, Allocator.Persistent);
        }

        private void OnDisable()
        {
            if (_points.IsCreated)
            {
                _points.Dispose();
            }
        }

        // TODO - need to validate logic here (not smooth at all in demo)
        private void Update()
        {
            // ⚠️ 안전 체크: surfers 배열과 _points 배열이 유효한지 확인
            if (surfers == null || surfers.Length == 0 || _points.Length == 0)
            {
                return;
            }
            
            // ⚠️ 배열 크기 불일치 방지: 모든 surfers의 위치를 _points에 설정
            for (int i = 0; i < surfers.Length && i < _points.Length; i++)
            {
                if (surfers[i] != null)
                {
                    _points[i] = surfers[i].position;
                }
            }
            
            // ⚠️ 안전 체크: _heights와 _normals 배열 크기 확인
            if (_heights == null || _normals == null || 
                _heights.Length != surfers.Length || _normals.Length != surfers.Length)
            {
                Debug.LogWarning($"[WindsurferManager] 배열 크기 불일치! heights={_heights?.Length}, normals={_normals?.Length}, surfers={surfers.Length}");
                return;
            }
            
            try
            {
                GerstnerWavesJobs.UpdateSamplePoints(ref _points, _guid);
                GerstnerWavesJobs.GetData(_guid, ref _heights, ref _normals);
            }
            catch (System.ArgumentException e)
            {
                Debug.LogError($"[WindsurferManager] GerstnerWavesJobs 에러: {e.Message}\n" +
                              $"points.Length={_points.Length}, heights.Length={_heights.Length}, normals.Length={_normals.Length}, surfers.Length={surfers.Length}");
                return;
            }

            for (int i = 0; i < surfers.Length; i++)
            {
                if (surfers[i] == null) continue;
                
                _smoothPositions[i] = surfers[i].position;
                
                // ⚠️ 안전 체크: 배열 인덱스 범위 확인
                if (i < _heights.Length && i < _normals.Length)
                {
                    // Sample the water height at the current position
                    if (_heights[i].y > _smoothPositions[i].y)
                        _smoothPositions[i].y += Time.deltaTime;
                    else
                        _smoothPositions[i].y -= Time.deltaTime * 0.25f;
#if !STATIC_EVERYTHING
                    surfers[i].position = _smoothPositions[i];
#endif
                }
            }
        }
    }
}
