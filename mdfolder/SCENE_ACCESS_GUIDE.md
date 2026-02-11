# 씬 접근 방법 가이드

## 🎮 Defense 씬에 접근하는 방법

새로운 `defense_training.unity`와 `defense_play.unity` 씬에 접근하는 여러 가지 방법을 설명합니다.

---

## 방법 1: Unity 에디터에서 직접 열기 (가장 간단)

### 단계:
1. Unity 에디터에서 **Project** 창 열기
2. `Assets/scenes/ml_agents/` 폴더로 이동
3. `defense_play.unity` 또는 `defense_training.unity` 더블클릭
4. **Play** 버튼 클릭

**장점**: 가장 빠르고 간단함  
**단점**: 메인 메뉴를 거치지 않음

---

## 방법 2: 코드로 직접 로딩

### 스크립트에서 호출:

```csharp
// 플레이 씬 로드
AppSettings.LoadScene("scenes/ml_agents/defense_play");

// 학습 씬 로드
AppSettings.LoadScene("scenes/ml_agents/defense_training");
```

### 사용 예시:

**새로운 헬퍼 스크립트 생성** (`DefenseSceneLoader.cs`):

```csharp
using UnityEngine;

namespace BoatAttack
{
    public class DefenseSceneLoader : MonoBehaviour
    {
        public void LoadPlayScene()
        {
            AppSettings.LoadScene("scenes/ml_agents/defense_play");
        }

        public void LoadTrainingScene()
        {
            AppSettings.LoadScene("scenes/ml_agents/defense_training");
        }
    }
}
```

이 스크립트를 빈 GameObject에 추가하고, UI 버튼의 OnClick 이벤트에 연결하면 됩니다.

---

## 방법 3: 메인 메뉴에 버튼 추가 (권장)

### 단계:

1. **메인 메뉴 씬 열기**: `scenes/main_menu.unity`

2. **UI 버튼 추가**:
   - Canvas 하위에 새 Button 생성
   - 이름: "Defense Play" 또는 "Defense Training"

3. **스크립트 연결**:
   - `MainMenuHelper.cs`에 메서드 추가하거나
   - 새 `DefenseSceneLoader.cs` 스크립트 생성 후 버튼에 연결

### MainMenuHelper에 추가 예시:

```csharp
// MainMenuHelper.cs에 추가
public void LoadDefensePlay()
{
    AppSettings.LoadScene("scenes/ml_agents/defense_play");
}

public void LoadDefenseTraining()
{
    AppSettings.LoadScene("scenes/ml_agents/defense_training");
}
```

그리고 버튼의 OnClick 이벤트에 연결합니다.

---

## 방법 4: 커맨드 라인 인자 사용

### AppSettings.cs에 커맨드 라인 처리 추가:

`AppSettings.cs`의 `CmdArgs()` 메서드에 추가:

```csharp
case "-loaddefenseplay":
    LoadScene("scenes/ml_agents/defense_play");
    break;
case "-loaddefensetraining":
    LoadScene("scenes/ml_agents/defense_training");
    break;
```

### 사용 방법:

빌드된 실행 파일 실행 시:
```bash
BoatAttack.exe -loaddefenseplay
BoatAttack.exe -loaddefensetraining
```

---

## 방법 5: Build Settings에 추가

### 단계:

1. **File > Build Settings** 열기
2. **Add Open Scenes** 클릭하여 현재 열린 씬 추가
3. 또는 **Add...** 버튼으로 씬 파일 직접 추가:
   - `Assets/scenes/ml_agents/defense_play.unity`
   - `Assets/scenes/ml_agents/defense_training.unity`

4. 빌드 후 씬 인덱스로 접근 가능:
```csharp
AppSettings.LoadScene(씬인덱스);
```

---

## 방법 6: 런타임 씬 전환 (디버그용)

### 게임 내에서 씬 전환:

```csharp
// 현재 씬에서 다른 씬으로 전환
AppSettings.LoadScene("scenes/ml_agents/defense_play");
```

### 예시: 키 입력으로 씬 전환

```csharp
using UnityEngine;

public class SceneSwitcher : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            AppSettings.LoadScene("scenes/ml_agents/defense_play");
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            AppSettings.LoadScene("scenes/ml_agents/defense_training");
        }
    }
}
```

---

## 추천 워크플로우

### 개발 단계별 추천:

1. **초기 개발**: 방법 1 (에디터에서 직접 열기)
2. **테스트**: 방법 2 (코드로 로딩) 또는 방법 6 (런타임 전환)
3. **최종 통합**: 방법 3 (메인 메뉴에 버튼 추가)

---

## 씬 접근 전 확인사항

씬을 로드하기 전에 다음을 확인하세요:

✅ **씬 파일 존재 확인**:
- `Assets/scenes/ml_agents/defense_play.unity` 존재 여부
- `Assets/scenes/ml_agents/defense_training.unity` 존재 여부

✅ **필수 컴포넌트 확인**:
- `GameModeManager` 오브젝트 존재
- 모드 설정 확인 (Play/Training)

✅ **의존성 확인**:
- 필요한 Prefab들이 Addressables에 등록되어 있는지
- 필요한 스크립트들이 컴파일되었는지

---

## 문제 해결

### Q: 씬을 찾을 수 없다는 에러가 나요
- 씬 경로가 정확한지 확인 (`scenes/ml_agents/defense_play`)
- 씬 파일이 실제로 존재하는지 확인
- Build Settings에 씬이 추가되어 있는지 확인

### Q: 씬은 로드되지만 게임이 작동하지 않아요
- `GameModeManager`가 씬에 있는지 확인
- 필요한 컴포넌트들이 모두 있는지 확인
- 콘솔에 에러 메시지가 있는지 확인

### Q: 메인 메뉴에서 버튼이 작동하지 않아요
- 버튼의 OnClick 이벤트가 제대로 연결되었는지 확인
- 스크립트 메서드가 public인지 확인
- 씬 경로가 정확한지 확인

---

## 빠른 참조

### 씬 경로:
```
플레이 씬: "scenes/ml_agents/defense_play"
학습 씬: "scenes/ml_agents/defense_training"
```

### 코드 예시:
```csharp
// 직접 로딩
AppSettings.LoadScene("scenes/ml_agents/defense_play");

// 인덱스로 로딩 (Build Settings에 추가된 경우)
AppSettings.LoadScene(씬인덱스);
```

### 모드 확인:
```csharp
if (GameModeManager.IsPlayMode) { /* 플레이 모드 */ }
if (GameModeManager.IsTrainingMode) { /* 학습 모드 */ }
```
