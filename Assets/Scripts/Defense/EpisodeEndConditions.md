# 에피소드 종료 조건

## 📋 에피소드가 종료되는 경우

### 1. ✅ 적 포획 성공 (성공 종료)
**위치**: `DefenseEnvController.OnEnemyCaptured()`

**조건**:
- 적 USV가 Web 오브젝트와 충돌 (WebCollisionDetector 감지)

**동작**:
1. 포획 보상 부여: `captureReward` (기본: +1.0)
2. 위치 보너스 계산: 그물 중심에 가까울수록 추가 보상 (최대 +0.3)
3. 보상 분배 (그룹 또는 개별)
4. **즉시 에피소드 종료**
5. 0.5초 후 새 에피소드 시작

**로그**:
```
[DefenseEnvController] 적 포획 성공! 보상: 1.xxx
```

---

### 2. ❌ 모선 충돌 (Game Over - 즉시 종료)
**위치**: `DefenseEnvController.OnMotherShipCollision()`

**조건**:
- 적 USV가 모선(MotherShip)과 충돌
- MotherShipCollisionDetector가 감지

**동작**:
1. 큰 패널티 부여: `motherShipCollisionPenalty` (기본: -1.75)
2. 보상 분배 (그룹 또는 개별)
3. **즉시 에피소드 종료** (가장 심각한 실패)
4. 0.5초 후 새 에피소드 시작

**로그**:
```
[DefenseEnvController] 모선 충돌! Game Over. 패널티: -1.75
```

---

### 3. ❌ 아군 충돌 (즉시 종료)
**위치**: `DefenseEnvController.OnFriendlyCollision()`

**조건**:
- 아군-아군 충돌 (DefenseAgent 1 ↔ DefenseAgent 2)
- 아군-모선 충돌 (DefenseAgent ↔ MotherShip)
- DefenseAgent.OnCollisionEnter()에서 감지

**동작**:
1. 충돌 패널티 부여: `collisionPenalty` (기본: -1.0)
2. 보상 분배 (그룹 또는 개별)
3. **즉시 에피소드 종료**
4. 0.5초 후 새 에피소드 시작

**로그**:
```
[DefenseEnvController] 아군 충돌! 패널티: -1.0
```

---

### 4. ⏱️ 타임아웃 (시간 초과)
**위치**: `DefenseBoatManager.Update()`

**조건**:
- 에피소드 시작 후 `maxEpisodeTime` 초 경과 (기본: 120초)

**동작**:
1. 타임아웃 패널티 부여: `timeoutPenalty` (기본: -1.0)
2. 보상 분배 (그룹 또는 개별)
3. **에피소드 종료**
4. 0.5초 후 새 에피소드 시작

**로그**:
```
[DefenseBoatManager] 에피소드 타임아웃
```

**설정**:
- Inspector에서 `maxEpisodeTime` 조절 가능 (초 단위)

---

### 5. ✅ 모선 방어 성공 (정상 종료)
**위치**: `DefenseEnvController.OnEpisodeEnd()`

**조건**:
- 에피소드가 다른 이유로 종료될 때
- 적이 모선 방어 존(`motherShipDefenseRadius`)에 진입하지 않았을 때

**동작**:
1. 모선 방어 성공 보상 부여: `motherShipDefenseReward` (기본: +0.5)
2. 보상 분배 (그룹 또는 개별)
3. 에피소드 종료

**로그**:
```
[DefenseEnvController] 모선 방어 성공! 보상: 0.5
```

**주의**: 이것은 다른 종료 조건과 함께 발생할 수 있습니다 (예: 타임아웃 후 모선 방어 성공 체크)

---

## 🔄 에피소드 종료 후 동작

### 자동 재시작
1. **에피소드 종료** → `EndCurrentEpisode()` 호출
2. **0.5초 대기** → `Invoke(nameof(StartNewEpisode), 0.5f)`
3. **새 에피소드 시작** → `StartNewEpisode()` 호출
   - 위치 리셋 (랜덤 스폰 포함)
   - WebDetector 리셋
   - DefenseEnvController.OnEpisodeBegin() 호출

---

## 📊 종료 조건 우선순위

### 즉시 종료 (가장 높은 우선순위):
1. **모선 충돌** (-1.75) - Game Over
2. **아군 충돌** (-1.0)
3. **적 포획 성공** (+1.0~1.3)

### 시간 기반 종료:
4. **타임아웃** (-1.0) - 120초 경과

### 종료 시 추가 보상:
5. **모선 방어 성공** (+0.5) - 다른 종료 조건과 함께 체크

---

## ⚙️ Inspector 설정

### DefenseBoatManager:
- **Max Episode Time**: 120 (초) - 타임아웃 시간

### DefenseEnvController:
- **Capture Reward**: 1.0 - 포획 성공 보상
- **Capture Center Bonus**: 0.3 - 위치 보너스 최대값
- **Mother Ship Defense Reward**: 0.5 - 모선 방어 성공 보상
- **Mother Ship Collision Penalty**: -1.75 - 모선 충돌 패널티
- **Collision Penalty**: -1.0 - 아군 충돌 패널티
- **Timeout Penalty**: -1.0 - 타임아웃 패널티 (DefenseBoatManager에서 설정)

---

## 🔍 디버깅

### 에피소드 종료 확인:
1. **Console 로그 확인**:
   - `[DefenseEnvController] 적 포획 성공!`
   - `[DefenseEnvController] 모선 충돌! Game Over.`
   - `[DefenseEnvController] 아군 충돌!`
   - `[DefenseBoatManager] 에피소드 타임아웃`
   - `[DefenseEnvController] 모선 방어 성공!`

2. **enableDebugLog 활성화**:
   - DefenseEnvController의 `enableDebugLog` 체크
   - DefenseBoatManager의 `enableDebugLog` 체크

3. **에피소드 재시작 확인**:
   - 0.5초 후 선박들이 랜덤 위치로 재생성되는지 확인
   - 모선은 위치가 유지되는지 확인

---

## 💡 요약

**에피소드가 종료되는 경우:**
1. ✅ 적 포획 성공
2. ❌ 모선 충돌 (Game Over)
3. ❌ 아군 충돌
4. ⏱️ 타임아웃 (120초)
5. ✅ 모선 방어 성공 (종료 시 추가 보상)

**종료 후:**
- 0.5초 대기
- 새 에피소드 시작 (랜덤 스폰)
- 모든 선박 위치 리셋 (모선 제외)
