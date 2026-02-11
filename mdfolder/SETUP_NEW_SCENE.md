# 새 씬 설정 가이드: 바다와 보트 추가하기

## 🎯 목표
새로운 씬에 Boat Attack의 물 시스템과 보트를 추가하는 방법

---

## 1단계: 물(Water) 시스템 추가

### 방법 1: 기존 씬에서 복사 (가장 간단)

1. **기존 씬 열기**: `scenes/demo_Island.unity` 또는 `scenes/_levels/level_Island.unity`
2. **Hierarchy에서 Water 오브젝트 찾기**
   - 보통 "Water" 또는 "WaterSystem"이라는 이름
3. **복사**: Ctrl+C
4. **새 씬으로 전환**: `scenes/ml_agents/defense_play.unity` (또는 만든 씬)
5. **붙여넣기**: Ctrl+V

### 방법 2: 수동으로 생성

1. **빈 GameObject 생성**
   - Hierarchy에서 우클릭 > Create Empty
   - 이름: "Water"

2. **Water 컴포넌트 추가**
   - `Water.cs` 스크립트 추가 (WaterSystem 네임스페이스)
   - 위치: `Packages/com.verasl.water-system/Scripts/Water.cs`

3. **필수 설정**
   - **Water Settings Data**: ScriptableObject 참조 필요
   - **Water Surface Data**: ScriptableObject 참조 필요
   - **Water Resources**: Resources 폴더에서 로드됨

4. **위치 설정**
   - Transform: Position (0, 0, 0)
   - Scale: (1, 1, 1) 또는 원하는 크기

### 물 시스템 확인사항

✅ **Water 컴포넌트**가 있는 GameObject
✅ **WaterSettingsData** ScriptableObject 참조
✅ **WaterSurfaceData** ScriptableObject 참조
✅ 씬에 **Directional Light** (태양광)

---

## 2단계: 보트 추가하기

### 방법 1: Addressables를 통한 동적 로딩 (권장)

#### 보트 프리팹 위치 확인:
```
Assets/Objects/boats/
├── _BoatBase.prefab
├── renegade/_Renegade.prefab
└── (다른 보트 프리팹들)
```

#### 코드로 보트 추가:

```csharp
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class SimpleBoatSpawner : MonoBehaviour
{
    [Header("Boat Prefab Reference")]
    public AssetReference boatPrefab; // Inspector에서 할당
    
    [Header("Spawn Settings")]
    public int boatCount = 3;
    public float spawnRadius = 10f;
    public Vector3 centerPosition = Vector3.zero;

    void Start()
    {
        SpawnBoats();
    }

    async void SpawnBoats()
    {
        for (int i = 0; i < boatCount; i++)
        {
            // 원형으로 배치
            float angle = (360f / boatCount) * i;
            Vector3 position = centerPosition + new Vector3(
                Mathf.Sin(angle * Mathf.Deg2Rad) * spawnRadius,
                0,
                Mathf.Cos(angle * Mathf.Deg2Rad) * spawnRadius
            );
            
            // 보트 인스턴스 생성
            var handle = Addressables.InstantiateAsync(boatPrefab, position, Quaternion.identity);
            await handle.Task;
            
            GameObject boat = handle.Result;
            
            // 보트 설정 (선택적)
            if (boat.TryGetComponent<BoatAttack.Boat>(out var boatComponent))
            {
                // 첫 번째 보트는 플레이어, 나머지는 AI
                bool isPlayer = (i == 0);
                boatComponent.Setup(i + 1, isPlayer, GetRandomLivery());
            }
        }
    }

    BoatAttack.BoatLivery GetRandomLivery()
    {
        return new BoatAttack.BoatLivery
        {
            primaryColor = BoatAttack.ConstantData.GetRandomPaletteColor,
            trimColor = BoatAttack.ConstantData.GetRandomPaletteColor
        };
    }
}
```

### 방법 2: 씬에 직접 배치 (간단)

1. **보트 프리팹 찾기**
   - Project 창: `Assets/Objects/boats/_BoatBase.prefab`
   - 또는 `Assets/Objects/boats/renegade/_Renegade.prefab`

2. **씬에 드래그 앤 드롭**
   - 프리팹을 Hierarchy로 드래그
   - 원하는 위치로 이동

3. **보트 설정**
   - `Boat.cs` 컴포넌트 확인
   - `Engine.cs` 컴포넌트 확인
   - `Rigidbody` 컴포넌트 확인

4. **플레이어 보트 설정**
   - `HumanController.cs` 컴포넌트 추가
   - `GameModeManager.IsPlayMode`일 때만 활성화

---

## 3단계: 필수 오브젝트 추가

### AppSettings (필수)
- **위치**: `Assets/Resources/AppSettings.prefab`
- **방법**: 씬에 드래그 앤 드롭
- **역할**: 씬 로딩, 설정 관리

### GameModeManager (이미 추가했다면 생략)
- 빈 GameObject 생성
- `GameModeManager.cs` 컴포넌트 추가
- Mode 설정: Play 또는 Training

### 카메라 설정
- **Main Camera** 확인
- 또는 **Cinemachine Virtual Camera** 추가

---

## 4단계: 빠른 테스트 스크립트

간단한 테스트를 위한 헬퍼 스크립트:

```csharp
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace BoatAttack
{
    /// <summary>
    /// 씬에 보트를 빠르게 추가하는 헬퍼 스크립트
    /// </summary>
    public class QuickBoatSetup : MonoBehaviour
    {
        [Header("Boat Settings")]
        public AssetReference[] boatPrefabs; // Inspector에서 보트 프리팹 할당
        public int boatCount = 3;
        public float spawnRadius = 20f;
        public Vector3 spawnCenter = new Vector3(0, 0, 0);
        
        [Header("Player Settings")]
        public bool firstBoatIsPlayer = true;

        void Start()
        {
            if (boatPrefabs == null || boatPrefabs.Length == 0)
            {
                Debug.LogWarning("보트 프리팹이 할당되지 않았습니다!");
                return;
            }

            SpawnBoats();
        }

        void SpawnBoats()
        {
            for (int i = 0; i < boatCount; i++)
            {
                // 원형 배치
                float angle = (360f / boatCount) * i * Mathf.Deg2Rad;
                Vector3 pos = spawnCenter + new Vector3(
                    Mathf.Sin(angle) * spawnRadius,
                    0,
                    Mathf.Cos(angle) * spawnRadius
                );

                // 보트 프리팹 선택 (순환)
                var prefabRef = boatPrefabs[i % boatPrefabs.Length];
                
                // 비동기 생성
                prefabRef.InstantiateAsync(pos, Quaternion.identity).Completed += handle =>
                {
                    if (handle.Status == UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationStatus.Succeeded)
                    {
                        GameObject boat = handle.Result;
                        SetupBoat(boat, i);
                    }
                };
            }
        }

        void SetupBoat(GameObject boatObj, int index)
        {
            if (boatObj.TryGetComponent<Boat>(out var boat))
            {
                bool isPlayer = firstBoatIsPlayer && index == 0;
                boat.Setup(index + 1, isPlayer, GetRandomLivery());
            }
        }

        BoatLivery GetRandomLivery()
        {
            return new BoatLivery
            {
                primaryColor = ConstantData.GetRandomPaletteColor,
                trimColor = ConstantData.GetRandomPaletteColor
            };
        }
    }
}
```

---

## 5단계: 체크리스트

### 물 시스템 ✅
- [ ] Water GameObject 추가됨
- [ ] Water 컴포넌트 설정됨
- [ ] WaterSettingsData 할당됨
- [ ] WaterSurfaceData 할당됨
- [ ] Directional Light 있음

### 보트 ✅
- [ ] 보트 프리팹 할당됨 (Addressables 또는 직접)
- [ ] 보트가 물 위에 배치됨
- [ ] 플레이어 보트에 HumanController 추가됨
- [ ] AI 보트에 AiController 추가됨 (선택적)

### 필수 시스템 ✅
- [ ] AppSettings.prefab 씬에 있음
- [ ] GameModeManager 추가됨
- [ ] 카메라 설정됨
- [ ] 조명 설정됨

---

## 문제 해결

### Q: 물이 보이지 않아요
- Water GameObject의 위치 확인 (Y축이 0인지)
- Water 컴포넌트의 설정 데이터 할당 확인
- 카메라가 물을 볼 수 있는 위치인지 확인

### Q: 보트가 물에 떠있지 않아요
- 보트의 Y 위치를 물 위로 조정
- Engine 컴포넌트의 부력 시스템 확인
- Rigidbody가 있는지 확인

### Q: 보트를 조작할 수 없어요
- HumanController 컴포넌트가 있는지 확인
- GameModeManager가 Play 모드인지 확인
- Input System이 제대로 설정되었는지 확인

### Q: Addressables 에러가 나요
- Addressables 그룹에 보트 프리팹이 등록되어 있는지 확인
- Addressables 창에서 빌드가 완료되었는지 확인

---

## 다음 단계

1. **씬 저장**: Ctrl+S
2. **Play 모드 테스트**: 보트 조작 확인
3. **필요시 조정**: 보트 위치, 물 설정 등

---

## 참고

- 기존 씬 참고: `scenes/demo_Island.unity`
- 보트 프리팹: `Assets/Objects/boats/`
- 물 시스템: `Packages/com.verasl.water-system/`
