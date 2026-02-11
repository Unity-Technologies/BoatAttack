# 빠른 시작 가이드

## 현재 구현 상태

✅ **완료된 항목**:
1. 프로젝트 계획 문서 (`BOAT_DEFENSE_PROJECT.md`)
2. 씬 설정 가이드 (`SCENE_SETUP.md`)
3. `GameModeManager` - 학습/플레이 모드 전환 시스템
4. `HumanController` - 모드 전환 지원 추가

## 다음 단계

### 1. 씬 생성 (즉시 가능)

Unity 에디터에서:

1. **학습용 씬 생성**:
   ```
   File > New Scene > Basic
   저장: Assets/scenes/ml_agents/defense_training.unity
   ```

2. **플레이용 씬 생성**:
   ```
   File > New Scene > Basic  
   저장: Assets/scenes/ml_agents/defense_play.unity
   ```

3. **씬에 GameModeManager 추가**:
   - 빈 GameObject 생성
   - `GameModeManager.cs` 컴포넌트 추가
   - 학습 씬: Mode를 `Training`으로 설정
   - 플레이 씬: Mode를 `Play`로 설정

### 2. 테스트 방법

**플레이 모드 테스트**:
1. `defense_play.unity` 씬 열기
2. 기존 보트 Prefab 추가
3. `HumanController` 컴포넌트 추가
4. Play 모드 실행
5. 키보드로 조작 가능 (WASD 또는 화살표 키)

**모드 전환 테스트**:
- 런타임에서 `GameModeManager`의 Context Menu 사용:
  - "Switch to Play Mode"
  - "Switch to Training Mode"
- 또는 코드에서:
  ```csharp
  GameModeManager.Instance.SetMode(GameMode.Play);
  GameModeManager.Instance.SetMode(GameMode.Training);
  ```

### 3. 다음 구현 항목

**Phase 2 준비**:
- [ ] `DefenseManager.cs` - 게임 로직 관리
- [ ] `MotherShip.cs` - 모선 스크립트
- [ ] `HealthSystem.cs` - 체력 시스템
- [ ] `TeamManager.cs` - 팀 관리
- [ ] `Projectile.cs` - 발사체 시스템

**Phase 3 준비**:
- [ ] ML-Agents 패키지 설치
- [ ] `DefenseAgent.cs` - ML-Agents Agent
- [ ] `DefenseAcademy.cs` - Academy 설정
- [ ] 관측(Observation) 시스템
- [ ] 행동(Action) 시스템
- [ ] 보상 함수 구현

## 파일 구조

```
BoatAttack/
├── BOAT_DEFENSE_PROJECT.md      # 프로젝트 계획 문서
├── SCENE_SETUP.md                # 씬 설정 가이드
├── QUICK_START.md                # 이 파일
├── Assets/
│   ├── Scripts/
│   │   ├── GameSystem/
│   │   │   ├── GameModeManager.cs    # ✅ 모드 전환 매니저
│   │   │   └── ...
│   │   ├── Boat/
│   │   │   ├── HumanController.cs    # ✅ 모드 전환 지원 추가
│   │   │   └── ...
│   │   └── MLAgents/                 # 📝 Phase 3에서 생성
│   │       └── (예정)
│   └── scenes/
│       └── ml_agents/                # 📝 생성 필요
│           ├── defense_training.unity
│           └── defense_play.unity
```

## 사용 예시

### 플레이 모드에서 조작

```csharp
// HumanController가 자동으로 플레이 모드에서만 입력 처리
// 학습 모드일 때는 입력 무시됨
```

### 모드 확인

```csharp
if (GameModeManager.IsPlayMode)
{
    // 플레이 모드 로직
}

if (GameModeManager.IsTrainingMode)
{
    // 학습 모드 로직
}
```

## 문제 해결

**Q: 모드 전환이 안 돼요**
- `GameModeManager`가 씬에 있는지 확인
- Singleton 패턴이므로 씬당 하나만 있어야 함

**Q: 플레이 모드에서도 입력이 안 돼요**
- `HumanController` 컴포넌트가 있는지 확인
- Input System이 제대로 설정되어 있는지 확인

**Q: 학습 모드에서도 입력이 작동해요**
- `GameModeManager`의 Current Mode가 Training인지 확인
- `HumanController`의 `FixedUpdate`에서 모드 체크가 제대로 되는지 확인

## 참고 문서

- `BOAT_DEFENSE_PROJECT.md` - 전체 프로젝트 계획
- `SCENE_SETUP.md` - 씬 설정 상세 가이드
- `README.md` - 원본 Boat Attack 프로젝트 설명
