# ROONSHOOT.unity 씬 구조 분석

## 📋 씬 개요

**씬 파일**: `Assets/scenes/ROONSHOOT.unity`

이 씬은 메인 메뉴 레벨 프리팹과 보트를 포함한 기본 테스트 씬입니다.

---

## 🏗️ 씬 구조

### 1. Prefab Instances (프리팹 인스턴스)

#### 1.1 MainMenuLevel (메인 메뉴 레벨)
- **Prefab GUID**: `705cc40ed7b2348689ba68fd4bc915b3`
- **Prefab 경로**: `Assets/Objects/Levels/main_menu/MainMenuLevel.prefab`
- **위치**: (0, 0, 0)
- **상태**: 활성화됨

**포함된 주요 요소**:
- **Water** (물 시스템)
  - Water 컴포넌트 포함
  - 위치: (6.25, -0.25, 50) - MainMenuLevel의 자식
  - Layer: 4
  - `computeOverride: true` 설정됨
  - `_depthTex` 할당됨 (씬에 RenderTexture로 존재)

- **서퍼 오브젝트들** (WindsurferManager에 의해 관리)
  - 여러 서퍼들이 배치되어 있음

- **UniversalAdditionalLightData** 컴포넌트 추가됨

#### 1.2 _BoatBase (보트)
- **Prefab GUID**: `fc3ffb83d6eafb1489a5b23bc82d25b6`
- **Prefab 경로**: `Assets/Objects/boats/_BoatBase.prefab`
- **위치**: (71.88, 16.41, 2.44)
- **이름**: "_BoatBase"
- **카메라 위치 수정됨**: (1.7, -3) 상대 위치

---

### 2. 일반 GameObject들

#### 2.1 Directional Light (방향광)
- **위치**: (0, 3, 0)
- **회전**: (50°, -30°, 0°)
- **색상**: (1, 0.957, 0.839) - 따뜻한 햇빛 색상
- **Intensity**: 1.0
- **Shadow Type**: Soft Shadows
- **UniversalAdditionalLightData** 컴포넌트 포함

#### 2.2 Main Camera (메인 카메라)
- **위치**: (0, 1, -10)
- **회전**: (0, 0, 0)
- **FOV**: 60°
- **Near**: 0.3
- **Far**: 1000
- **HDR**: 활성화
- **AudioListener** 포함

#### 2.3 GameObject (빈 오브젝트)
- **위치**: (99.65, 50.51, 4.16)
- **컴포넌트**: Transform만 있음
- **용도**: 불명확 (추가 설정 필요할 수 있음)

---

### 3. Assets (에셋)

#### 3.1 RenderTexture: WaterDepthMap
- **크기**: 1024 x 1024
- **Depth Format**: 24-bit
- **용도**: 물 시스템의 깊이 맵
- **상태**: 씬에 직접 생성됨

---

## 📊 씬 계층 구조 (Hierarchy)

```
ROONSHOOT.unity
├── MainMenuLevel (Prefab Instance)
│   ├── [서퍼 오브젝트들]
│   ├── Water (자식)
│   │   └── Water Component
│   └── [기타 레벨 오브젝트들]
├── _BoatBase (Prefab Instance)
│   └── [보트 하위 구조]
├── Directional Light
├── Main Camera
└── GameObject (빈 오브젝트)
```

---

## ⚙️ 주요 설정

### Render Settings
- **Fog**: 비활성화
- **Ambient Sky Color**: (0.212, 0.227, 0.259) - 어두운 하늘
- **Ambient Equator Color**: (0.114, 0.125, 0.133)
- **Ambient Ground Color**: (0.047, 0.043, 0.035)
- **Skybox**: 기본 스카이박스

### Lightmap Settings
- **Baked Lightmaps**: 활성화
- **Resolution**: 2
- **Bake Resolution**: 40
- **Atlas Size**: 1024

### Occlusion Culling
- **Smallest Occluder**: 5
- **Smallest Hole**: 0.25
- **Backface Threshold**: 100

---

## 🔍 주요 특징

### ✅ 포함된 기능
1. **물 시스템**: MainMenuLevel 프리팹에 포함된 Water 오브젝트
2. **보트**: _BoatBase 프리팹이 씬에 배치됨
3. **조명**: Directional Light 설정됨
4. **카메라**: 기본 메인 카메라

### ⚠️ 주의사항
1. **Water 위치**: MainMenuLevel의 자식으로 (6.25, -0.25, 50)에 위치
2. **보트 위치**: (71.88, 16.41, 2.44) - 물 위에 배치되어야 함
3. **빈 GameObject**: (99.65, 50.51, 4.16) 위치의 빈 오브젝트 - 용도 불명확

---

## 🛠️ 개선 제안

### 1. 보트 위치 조정
보트가 물 위에 제대로 떠있도록 Y 위치 확인 필요:
- 현재: Y = 16.41
- 물 높이: Y = -0.25 (MainMenuLevel 기준) + 0 (World 기준) = 약 0
- **권장**: 보트 Y 위치를 물 위로 조정 (예: 1~2 정도)

### 2. 빈 GameObject 처리
- 용도가 불명확한 빈 GameObject 제거 또는 용도 명확화
- 또는 GameModeManager 등 필요한 컴포넌트 추가

### 3. Water 설정 확인
- Water 컴포넌트의 `WaterSettingsData`와 `WaterSurfaceData` 할당 확인
- `computeOverride: true` 설정이 의도된 것인지 확인

### 4. 추가 필요한 컴포넌트
- **GameModeManager**: 학습/플레이 모드 전환
- **AppSettings**: 씬 로딩 및 설정 관리
- **HumanController**: 보트에 추가 (플레이어 조작용)

---

## 📝 씬 사용 방법

### 현재 상태
- 물 시스템: ✅ 포함됨 (MainMenuLevel 내부)
- 보트: ✅ 배치됨
- 조명: ✅ 설정됨
- 카메라: ✅ 기본 카메라

### 다음 단계
1. 보트에 `HumanController` 추가하여 조작 가능하게 만들기
2. `GameModeManager` 추가하여 모드 전환 시스템 구축
3. 보트 위치를 물 위로 조정
4. 필요시 추가 보트 배치

---

## 🔗 관련 파일

- **MainMenuLevel Prefab**: `Assets/Objects/Levels/main_menu/MainMenuLevel.prefab`
- **Boat Prefab**: `Assets/Objects/boats/_BoatBase.prefab`
- **Water Component**: `Packages/com.verasl.water-system/Scripts/Water.cs`
