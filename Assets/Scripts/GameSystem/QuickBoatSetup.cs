using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace BoatAttack
{
    /// <summary>
    /// 씬에 보트를 빠르게 추가하는 헬퍼 스크립트
    /// Inspector에서 보트 프리팹을 할당하고 실행하면 자동으로 배치됩니다
    /// </summary>
    public class QuickBoatSetup : MonoBehaviour
    {
        [Header("Boat Settings")]
        [Tooltip("보트 프리팹들 (Addressables 또는 직접 프리팹)")]
        public AssetReference[] boatPrefabs;
        
        [Tooltip("생성할 보트 개수")]
        public int boatCount = 3;
        
        [Tooltip("보트 배치 반경")]
        public float spawnRadius = 20f;
        
        [Tooltip("보트 배치 중심 위치")]
        public Vector3 spawnCenter = new Vector3(0, 0, 0);
        
        [Header("Player Settings")]
        [Tooltip("첫 번째 보트를 플레이어로 설정")]
        public bool firstBoatIsPlayer = true;

        [Header("Debug")]
        [Tooltip("시작 시 자동으로 보트 생성")]
        public bool spawnOnStart = true;

        void Start()
        {
            if (spawnOnStart)
            {
                SpawnBoats();
            }
        }

        /// <summary>
        /// 보트들을 원형으로 배치하여 생성
        /// </summary>
        [ContextMenu("Spawn Boats")]
        public void SpawnBoats()
        {
            if (boatPrefabs == null || boatPrefabs.Length == 0)
            {
                Debug.LogWarning($"[QuickBoatSetup] 보트 프리팹이 할당되지 않았습니다! " +
                               $"Inspector에서 boatPrefabs 배열에 보트 프리팹을 할당해주세요.");
                return;
            }

            Debug.Log($"[QuickBoatSetup] {boatCount}개의 보트 생성 시작...");

            for (int i = 0; i < boatCount; i++)
            {
                SpawnBoat(i);
            }
        }

        private void SpawnBoat(int index)
        {
            // 원형 배치 계산
            float angle = (360f / boatCount) * index * Mathf.Deg2Rad;
            Vector3 position = spawnCenter + new Vector3(
                Mathf.Sin(angle) * spawnRadius,
                0, // Y는 나중에 물 위로 조정
                Mathf.Cos(angle) * spawnRadius
            );

            // 보트 프리팹 선택 (순환)
            var prefabRef = boatPrefabs[index % boatPrefabs.Length];

            // 비동기 생성
            prefabRef.InstantiateAsync(position, Quaternion.identity).Completed += handle =>
            {
                if (handle.Status == AsyncOperationStatus.Succeeded)
                {
                    GameObject boat = handle.Result;
                    SetupBoat(boat, index);
                    Debug.Log($"[QuickBoatSetup] 보트 {index + 1} 생성 완료: {boat.name}");
                }
                else
                {
                    Debug.LogError($"[QuickBoatSetup] 보트 {index + 1} 생성 실패: {handle.OperationException}");
                }
            };
        }

        private void SetupBoat(GameObject boatObj, int index)
        {
            if (boatObj.TryGetComponent<Boat>(out var boat))
            {
                bool isPlayer = firstBoatIsPlayer && index == 0;
                
                // 보트 설정
                boat.Setup(index + 1, isPlayer, GetRandomLivery());

                // 플레이어 보트에 HumanController 추가
                if (isPlayer && !boatObj.TryGetComponent<HumanController>(out _))
                {
                    boatObj.AddComponent<HumanController>();
                    Debug.Log($"[QuickBoatSetup] 플레이어 보트에 HumanController 추가됨");
                }
            }
            else
            {
                Debug.LogWarning($"[QuickBoatSetup] {boatObj.name}에 Boat 컴포넌트가 없습니다!");
            }
        }

        private BoatLivery GetRandomLivery()
        {
            return new BoatLivery
            {
                primaryColor = ConstantData.GetRandomPaletteColor,
                trimColor = ConstantData.GetRandomPaletteColor
            };
        }

        /// <summary>
        /// 모든 보트 제거 (디버그용)
        /// </summary>
        [ContextMenu("Clear All Boats")]
        public void ClearAllBoats()
        {
            Boat[] boats = FindObjectsOfType<Boat>();
            foreach (var boat in boats)
            {
                if (Application.isPlaying)
                {
                    Destroy(boat.gameObject);
                }
                else
                {
                    DestroyImmediate(boat.gameObject);
                }
            }
            Debug.Log($"[QuickBoatSetup] {boats.Length}개의 보트 제거됨");
        }

        /// <summary>
        /// Gizmo로 스폰 위치 표시 (에디터에서만)
        /// </summary>
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(spawnCenter, spawnRadius);

            // 보트 위치 표시
            Gizmos.color = Color.yellow;
            for (int i = 0; i < boatCount; i++)
            {
                float angle = (360f / boatCount) * i * Mathf.Deg2Rad;
                Vector3 pos = spawnCenter + new Vector3(
                    Mathf.Sin(angle) * spawnRadius,
                    0,
                    Mathf.Cos(angle) * spawnRadius
                );
                Gizmos.DrawWireSphere(pos, 2f);
            }
        }
    }
}
