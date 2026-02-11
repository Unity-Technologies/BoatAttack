# 씬 생성 가이드 (단계별)

## ⚠️ 중요: 폴더와 씬이 아직 생성되지 않았습니다

현재 `Assets/scenes/ml_agents/` 폴더가 존재하지 않으므로, 다음 단계를 따라 생성해야 합니다.

---

## 방법 1: Unity 에디터에서 수동 생성 (권장)

### 1단계: 폴더 생성

1. Unity 에디터에서 **Project** 창 열기
2. `Assets/scenes` 폴더를 우클릭
3. **Create > Folder** 선택
4. 폴더 이름: `ml_agents`

### 2단계: 플레이 씬 생성

1. `Assets/scenes/ml_agents` 폴더를 우클릭
2. **Create > Scene** 선택
3. 씬 이름: `defense_play`
4. 저장 위치 확인: `Assets/scenes/ml_agents/defense_play.unity`

### 3단계: 학습 씬 생성

1. `Assets/scenes/ml_agents` 폴더를 우클릭
2. **Create > Scene** 선택
3. 씬 이름: `defense_training`
4. 저장 위치 확인: `Assets/scenes/ml_agents/defense_training.unity`

### 4단계: 씬 설정

각 씬을 열고 다음을 추가:

**defense_play.unity**:
1. 빈 GameObject 생성 (이름: `GameModeManager`)
2. `GameModeManager.cs` 컴포넌트 추가
3. **Current Mode**를 `Play`로 설정

**defense_training.unity**:
1. 빈 GameObject 생성 (이름: `GameModeManager`)
2. `GameModeManager.cs` 컴포넌트 추가
3. **Current Mode**를 `Training`으로 설정

---

## 방법 2: 기존 씬 복사 후 수정 (빠른 방법)

### 1단계: 폴더 생성
- 위의 "방법 1" 1단계 참조

### 2단계: 기존 씬 복사

1. `Assets/scenes/demo_Island.unity` 파일 선택
2. **Ctrl+C** (복사)
3. `Assets/scenes/ml_agents` 폴더 선택
4. **Ctrl+V** (붙여넣기)
5. 이름 변경: `defense_play.unity`

### 3단계: 씬 수정

1. `defense_play.unity` 씬 열기
2. 불필요한 오브젝트 제거 (RaceManager 등)
3. `GameModeManager` 추가 (위 4단계 참조)

---

## 방법 3: 임시로 기존 씬 경로 사용

폴더를 만들기 전에 테스트하려면, 코드에서 임시로 기존 씬 경로를 사용할 수 있습니다:

```csharp
// 임시 경로 (폴더 생성 전까지 사용)
AppSettings.LoadScene("scenes/demo_Island");  // 플레이용
AppSettings.LoadScene("scenes/demo_Island");  // 학습용 (나중에 분리)
```

---

## 생성 후 확인사항

✅ **폴더 구조 확인**:
```
Assets/
└── scenes/
    └── ml_agents/
        ├── defense_play.unity
        ├── defense_play.unity.meta
        ├── defense_training.unity
        └── defense_training.unity.meta
```

✅ **씬 파일 확인**:
- Unity Project 창에서 파일이 보이는지 확인
- 씬을 더블클릭하여 열 수 있는지 확인

✅ **Build Settings 확인**:
1. **File > Build Settings** 열기
2. 씬들이 목록에 있는지 확인 (선택사항)

---

## 문제 해결

### Q: 폴더를 만들 수 없어요
- Unity 에디터가 씬을 저장할 권한이 있는지 확인
- Project 창에서 올바른 위치를 선택했는지 확인

### Q: 씬을 저장할 수 없어요
- Unity 에디터가 파일 시스템에 쓰기 권한이 있는지 확인
- 씬 이름에 특수문자가 없는지 확인

### Q: 씬이 보이지 않아요
- Unity 에디터를 새로고침 (Ctrl+R)
- Project 창에서 `Assets/scenes/ml_agents` 폴더로 이동

---

## 다음 단계

씬을 생성한 후:

1. **씬에 기본 오브젝트 추가** (SCENE_SETUP.md 참조)
2. **GameModeManager 설정**
3. **테스트**: 씬 로드가 정상 작동하는지 확인

```csharp
// 테스트 코드
AppSettings.LoadScene("scenes/ml_agents/defense_play");
```
