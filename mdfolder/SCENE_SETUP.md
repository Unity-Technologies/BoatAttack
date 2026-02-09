# 씬 설정 가이드

## 씬 구조 개요

Boat Defense 프로젝트는 학습 모드와 플레이 모드를 분리하여 관리합니다.

## 씬 목록

### 1. 학습용 씬 (Training Scenes)

#### `scenes/ml_agents/defense_training.unity`
- **목적**: ML-Agents 학습 전용 씬
- **특징**:
  - 최소한의 시각 효과 (성능 최적화)
  - 자동 리셋 및 에피소드 관리
  - GameModeManager가 Training 모드로 설정됨
  - ML-Agents Academy 및 Agent들이 활성화됨

**구성 요소**:
- `GameModeManager` (Training 모드)
- `DefenseManager` (게임 로직)
- `MotherShip` (모선)
- `DefenseArea` (학습 영역)
- ML-Agents `Academy`
- ML-Agents `Agent` (방어팀 6대, 공격팀 10대)

### 2. 플레이/테스트용 씬 (Play Scenes)

#### `scenes/ml_agents/defense_play.unity`
- **목적**: 키보드 조작 가능한 플레이 모드
- **특징**:
  - 시각 효과 포함 (풀 그래픽)
  - HumanController로 직접 조작 가능
  - 학습된 모델 테스트 가능
  - GameModeManager가 Play 모드로 설정됨

**구성 요소**:
- `GameModeManager` (Play 모드)
- `DefenseManager` (게임 로직)
- `MotherShip` (모선)
- `HumanController` (플레이어 조작)
- AI 보트들 (선택적)

### 3. 기존 씬 (Reference)

#### `scenes/demo_Island.unity`
- 원본 레이싱 씬 (참고용)

#### `scenes/_levels/level_Island.unity`
- 메인 레벨 씬 (참고용)

## 씬 생성 방법

### 학습용 씬 생성

1. Unity 에디터에서 새 씬 생성:
   - `File > New Scene > Basic (Built-in)`
   - 저장: `Assets/scenes/ml_agents/defense_training.unity`

2. 필수 오브젝트 추가:
   ```
   - GameModeManager (GameObject)
     └─ GameModeManager.cs 컴포넌트
        └─ Current Mode: Training
   
   - DefenseManager (GameObject)
     └─ DefenseManager.cs 컴포넌트
   
   - MotherShip (GameObject)
     └─ MotherShip.cs 컴포넌트
     └─ Collider (모선 충돌)
     └─ HealthSystem.cs 컴포넌트
   
   - DefenseArea (GameObject)
     └─ DefenseArea.cs 컴포넌트
     └─ Collider (학습 영역)
   
   - Academy (GameObject)
     └─ DefenseAcademy.cs 컴포넌트 (ML-Agents)
   
   - Agents (Parent GameObject)
     ├─ Defender_1 ~ Defender_6 (방어팀)
     │  └─ DefenseAgent.cs 컴포넌트
     │  └─ Boat.cs 컴포넌트
     │  └─ Team: Defender
     └─ Attacker_1 ~ Attacker_10 (공격팀)
        └─ DefenseAgent.cs 컴포넌트
        └─ Boat.cs 컴포넌트
        └─ Team: Attacker
   ```

3. 환경 설정:
   - 물 (Water System)
   - 조명 (Lighting)
   - 카메라 (Cinemachine - 선택적)

### 플레이용 씬 생성

1. 학습용 씬을 복사:
   - `defense_training.unity` 복사
   - 이름 변경: `defense_play.unity`

2. 모드 변경:
   - `GameModeManager`의 Current Mode를 `Play`로 변경

3. 플레이어 보트 추가:
   ```
   - PlayerBoat (GameObject)
     └─ HumanController.cs 컴포넌트
     └─ Boat.cs 컴포넌트
     └─ Camera (Cinemachine Virtual Camera)
   ```

4. ML-Agents 비활성화 (선택적):
   - Academy 비활성화 또는 제거
   - Agent 스크립트 비활성화

## 씬 전환 방법

### 런타임 전환

```csharp
// GameModeManager를 통해 모드 전환
GameModeManager.Instance.SetMode(GameMode.Play);
GameModeManager.Instance.SetMode(GameMode.Training);
```

### 씬 로딩

```csharp
// 학습 씬 로드
AppSettings.LoadScene("scenes/ml_agents/defense_training");

// 플레이 씬 로드
AppSettings.LoadScene("scenes/ml_agents/defense_play");
```

## Build Settings 설정

1. `File > Build Settings` 열기
2. 다음 씬들을 추가:
   - `scenes/ml_agents/defense_training.unity` (학습용)
   - `scenes/ml_agents/defense_play.unity` (플레이용)

## 주의사항

1. **학습 씬**:
   - 시각 효과 최소화 (성능)
   - 자동 리셋 필수
   - ML-Agents Academy 필수

2. **플레이 씬**:
   - HumanController 활성화
   - 시각 효과 포함 가능
   - ML-Agents 선택적

3. **모드 전환**:
   - 런타임 전환은 디버그용
   - 일반적으로 씬별로 모드 분리 권장

## 다음 단계

1. 씬 생성 후 `DefenseManager` 구현
2. `MotherShip` 스크립트 구현
3. ML-Agents `DefenseAgent` 구현
4. 프로젝타일 시스템 추가
