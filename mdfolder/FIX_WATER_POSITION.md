# 물이 카메라를 따라다니는 문제 해결

## 🔍 문제 원인

Boat Attack의 물 시스템은 **무한 물 효과**를 위해 카메라 위치를 기반으로 물 메시를 렌더링합니다. 
`Water.cs`의 `BeginCameraRendering` 메서드에서 카메라 위치를 추적하여 물을 그립니다.

## ✅ 해결 방법

### 방법 1: Water GameObject 위치 고정 (권장)

1. **Hierarchy에서 Water GameObject 선택**
2. **Transform 확인**:
   - Position: `(0, 0, 0)` 또는 원하는 고정 위치
   - Rotation: `(0, 0, 0)`
   - Scale: `(1, 1, 1)` 또는 원하는 크기

3. **Water 컴포넌트 확인**:
   - `Water Settings Data` 할당 확인
   - `Water Surface Data` 할당 확인

4. **WaterSettingsData 확인**:
   - `isInfinite` 옵션이 켜져 있으면 물이 카메라를 따라다닐 수 있습니다
   - 하지만 이것은 셰이더 레벨의 설정이므로 Transform 위치는 여전히 중요합니다

### 방법 2: MainCameraAlign 컴포넌트 제거

만약 Water GameObject에 `MainCameraAlign` 컴포넌트가 있다면:

1. **Water GameObject 선택**
2. **Inspector에서 `MainCameraAlign` 컴포넌트 찾기**
3. **우클릭 > Remove Component** 또는 **제거 버튼 클릭**

이 컴포넌트는 물을 카메라에 정렬하는 역할을 합니다.

### 방법 3: WaterSettingsData 설정 확인

1. **Project 창에서 WaterSettingsData 찾기**
   - 보통 `Assets/Data/WaterSettingsData.asset`
2. **Inspector에서 확인**:
   - `isInfinite`: 무한 물 여부
   - `originOffset`: 원점 오프셋

### 방법 4: 새 WaterSettingsData 생성 (필요시)

기존 설정이 문제가 있다면:

1. **Project 창에서 우클릭**
2. **Create > WaterSystem > Settings**
3. **새로운 WaterSettingsData 생성**
4. **설정 조정**:
   - `isInfinite`: false (고정된 물)
   - `originOffset`: (0, 0, 0, 0)
5. **Water 컴포넌트에 새 설정 할당**

## 🔧 상세 해결 단계

### Step 1: Water GameObject 확인

```
Hierarchy:
└── Water (GameObject)
    ├── Transform
    │   ├── Position: (0, 0, 0)  ← 고정 위치
    │   ├── Rotation: (0, 0, 0)
    │   └── Scale: (1, 1, 1)
    └── Water (Component)
        ├── Water Settings Data: [할당됨]
        └── Water Surface Data: [할당됨]
```

### Step 2: 불필요한 컴포넌트 제거

Water GameObject에 다음 컴포넌트가 있다면 제거:
- ❌ `MainCameraAlign` (카메라 추적)
- ✅ `Water` (필수)

### Step 3: 테스트

1. **Play 모드 실행**
2. **카메라 이동** (씬 뷰에서)
3. **물이 고정되어 있는지 확인**

## 📝 참고사항

### 물 시스템의 동작 방식

Boat Attack의 물 시스템은 두 가지 방식으로 작동할 수 있습니다:

1. **고정 물 (Fixed Water)**:
   - Transform 위치가 고정됨
   - 물이 특정 영역에만 존재
   - 일반적인 게임에 적합

2. **무한 물 (Infinite Water)**:
   - 카메라를 따라다니는 것처럼 보임
   - 실제로는 카메라 위치를 기반으로 메시를 재배치
   - 큰 바다/오션에 적합

### 현재 문제

물이 카메라를 따라다니는 것은 **무한 물 효과** 때문입니다. 
하지만 물의 Transform 위치는 여전히 중요하며, 이를 고정하면 문제가 해결됩니다.

## 🎯 빠른 해결 (체크리스트)

- [ ] Water GameObject의 Position이 (0, 0, 0) 또는 고정 위치인지 확인
- [ ] MainCameraAlign 컴포넌트가 없거나 비활성화되어 있는지 확인
- [ ] Water 컴포넌트의 설정 데이터가 올바르게 할당되어 있는지 확인
- [ ] Play 모드에서 테스트하여 물이 고정되어 있는지 확인

## 💡 추가 팁

### 물 크기 조정

물의 크기를 조정하려면:
- **Water GameObject의 Scale 조정**
- 또는 **WaterSettingsData의 originOffset 조정**

### 물 높이 조정

물의 높이를 조정하려면:
- **Water GameObject의 Position Y 값 조정**
- 예: `(0, 5, 0)` → 물이 5유닛 높이에 위치

---

**문제가 계속되면**: Water GameObject를 삭제하고 기존 씬(`demo_Island.unity`)에서 다시 복사해보세요.
