# 물 위치 수정 가이드: MainMenuLevel 자식에서 분리하기

## 🔍 현재 문제

물(Water) 오브젝트가 `MainMenuLevel` 프리팹의 자식으로 배치되어 있어서:
- MainMenuLevel을 삭제하면 물도 함께 삭제됨
- 물의 위치가 MainMenuLevel의 Transform에 종속됨
- 독립적으로 관리하기 어려움

## ✅ 해결 방법

### 방법 1: Unity 에디터에서 직접 이동 (가장 간단)

#### 단계:

1. **씬 열기**: `ROONSHOOT.unity`

2. **Hierarchy에서 Water 찾기**:
   ```
   MainMenuLevel
     └── Water  ← 이 오브젝트
   ```

3. **Water 오브젝트 선택**

4. **위치 확인**:
   - Inspector에서 Transform 확인
   - 현재 위치: (6.25, -0.25, 50) - 상대 위치

5. **World 위치 계산**:
   - MainMenuLevel 위치: (0, 0, 0)
   - Water 상대 위치: (6.25, -0.25, 50)
   - **World 위치**: (6.25, -0.25, 50)

6. **씬 루트로 이동**:
   - Hierarchy에서 **Water를 드래그**
   - **씬 루트(최상위)**로 드롭
   - 또는 **Cut (Ctrl+X)** → 씬 루트 선택 → **Paste (Ctrl+V)**

7. **위치 조정** (필요시):
   - Transform의 Position을 원하는 위치로 설정
   - 예: (0, 0, 0) 또는 원하는 위치

8. **씬 저장**: Ctrl+S

### 방법 2: Prefab 연결 해제 후 이동

만약 Water가 Prefab 인스턴스라면:

1. **Water 선택**
2. **Inspector 상단에서 "Unpack Prefab"** 클릭
3. **씬 루트로 이동** (위의 방법 1 참조)

### 방법 3: 새로 생성 (가장 확실)

기존 물을 삭제하고 새로 만들기:

1. **기존 Water 삭제**:
   - MainMenuLevel > Water 선택
   - Delete 키 또는 우클릭 > Delete

2. **새 Water 생성**:
   - Hierarchy에서 우클릭 > Create Empty
   - 이름: "Water"
   - 위치: (0, 0, 0) 또는 원하는 위치

3. **Water 컴포넌트 추가**:
   - Inspector에서 Add Component
   - `Water` 스크립트 검색 및 추가
   - (네임스페이스: `WaterSystem`)

4. **설정 데이터 할당**:
   - `Water Settings Data`: 기존 씬에서 참조하거나 새로 생성
   - `Water Surface Data`: 기존 씬에서 참조하거나 새로 생성

5. **기존 씬에서 설정 복사** (선택사항):
   - `demo_Island.unity` 씬 열기
   - Water 오브젝트의 설정 확인
   - 새 씬의 Water에 동일하게 설정

## 📋 체크리스트

### 이동 후 확인사항

- [ ] Water가 씬 루트에 있음 (MainMenuLevel의 자식 아님)
- [ ] Water의 Transform Position이 올바름
- [ ] Water 컴포넌트가 정상 작동함
- [ ] Play 모드에서 물이 정상적으로 보임
- [ ] 물이 카메라를 따라다니지 않음 (이전 문제 해결)

## 🎯 권장 최종 구조

```
ROONSHOOT.unity
├── MainMenuLevel (Prefab)
│   └── [서퍼 오브젝트들 등]
├── Water (독립 오브젝트) ← 씬 루트로 이동
│   └── Water Component
├── _BoatBase (Prefab)
├── Directional Light
├── Main Camera
└── GameObject
```

## ⚠️ 주의사항

### Prefab 수정 시

만약 MainMenuLevel 프리팹을 수정하면:
- 다른 씬에서 사용하는 MainMenuLevel도 영향을 받을 수 있음
- **Prefab 연결을 해제(Unpack)**하거나
- **씬에서만 수정**하도록 주의

### 위치 조정

물을 이동한 후:
- 보트가 물 위에 있는지 확인
- 카메라가 물을 볼 수 있는 위치인지 확인
- 필요시 위치 조정

## 🔧 추가 팁

### 물 위치 최적화

1. **중앙 배치**: (0, 0, 0)
2. **보트 주변**: 보트 위치를 기준으로 배치
3. **카메라 기준**: 카메라가 보기 좋은 위치

### 물 크기 조정

- Water GameObject의 **Scale** 조정
- 또는 **WaterSettingsData**의 `originOffset` 조정

### 물 높이 조정

- Transform의 **Position Y** 값 조정
- 예: (0, 0, 0) → 물이 Y=0에 위치
- 예: (0, 5, 0) → 물이 Y=5에 위치

## 💡 빠른 해결 (1분)

1. **Hierarchy에서 Water 선택**
2. **Ctrl+X** (잘라내기)
3. **씬 루트 선택** (아무것도 선택 안 된 상태)
4. **Ctrl+V** (붙여넣기)
5. **위치 조정**: Transform Position을 (0, 0, 0)으로 설정
6. **씬 저장**: Ctrl+S

이제 Water가 독립적으로 관리됩니다!
