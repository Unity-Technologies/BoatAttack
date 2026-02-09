# NaN 에러 완전 해결 가이드

## 수정 완료 사항

### 1. Engine.cs - 강화된 NaN 방지

#### FixedUpdate() 메서드
- **Rigidbody rotation NaN 체크 및 자동 리셋**
  - `RB.rotation`이 NaN이면 `Quaternion.identity`로 리셋
  - `RB.angularVelocity`를 `Vector3.zero`로 리셋
  - `transform.rotation`도 함께 리셋
  - `_currentAngle`, `_turnVel` 초기화
- **Rigidbody position NaN 체크**
  - `RB.position`이 NaN이면 현재 `transform.position`로 리셋
  - `RB.velocity`를 `Vector3.zero`로 리셋
- **Rigidbody velocity NaN 체크**
  - `RB.velocity`가 NaN이면 `Vector3.zero`로 리셋
- **_yHeight NaN 체크**
  - 물리 계산 결과가 NaN이면 0으로 설정

#### Turn() 메서드
- **modifier NaN 체크** (기존)
- **_currentAngle, _turnVel NaN 체크** (기존)
- **deltaTime NaN 체크** (기존)
- **targetAngle NaN 체크** (기존)
- **SmoothDampAngle 결과 NaN 체크** (기존)
- **eulerAngles 벡터 NaN 체크** (신규)
- **transform.rotation NaN 체크 및 리셋** (신규)
  - transform.rotation이 NaN이면 모든 관련 값 리셋

#### Accelerate() 메서드
- **modifier NaN 체크** (기존)
- **forward 벡터 NaN 체크** (기존)
- **RB null 체크** (기존)

---

### 2. DefenseAgent.cs - 입력 값 NaN 방지

#### OnActionReceived() 메서드
- **현재 속도 값 검증**
  - `currentLinearVelocity`, `currentAngularVelocity` NaN 체크
- **목표 속도 값 검증**
  - `targetLinearVelocity`, `targetAngularVelocity` NaN 체크
- **나눗셈 전 안전 체크**
  - `maxLinearVelocity > 0.01f` 확인 후 계산
  - `maxAngularVelocity > 0.01f` 확인 후 계산
- **throttle, steering NaN 체크**
  - 계산 결과가 NaN이면 0으로 설정
- **_smoothThrottle, _smoothSteering NaN 체크**
  - Lerp 전후 모두 검증
- **최종 값 검증**
  - `finalThrottle`, `finalSteering` NaN 체크
  - `finalSteering` 범위 제한 (-1 ~ 1)

---

## NaN 발생 원인 분석

### 가능한 원인들:
1. **0으로 나누기**: `velocityControlGain / maxLinearVelocity`에서 `maxLinearVelocity`가 0
2. **무한대 값**: 계산 과정에서 값이 무한대로 발산
3. **Rigidbody 물리 엔진 버그**: Unity 물리 엔진 자체의 문제
4. **Transform 회전 값 오염**: 이전 프레임의 NaN 값이 누적

---

## 해결 방법

### 즉시 적용된 해결책:
1. ✅ **모든 float 값에 NaN 체크 추가**
2. ✅ **Rigidbody rotation/position/velocity 직접 체크 및 리셋**
3. ✅ **나눗셈 전 분모 값 검증**
4. ✅ **Transform 회전 값 검증 및 리셋**
5. ✅ **계산 결과마다 NaN 체크**

### 추가 권장 사항:
1. **Unity 에디터 재시작** (캐시 문제 해결)
2. **Rigidbody 설정 확인**:
   - Constraints에서 Freeze Rotation이 체크되어 있지 않은지 확인
   - Interpolate 설정 확인
3. **물리 타임스텝 확인**:
   - Edit → Project Settings → Time
   - Fixed Timestep: 0.02 (기본값 권장)
4. **디버그 로그 모니터링**:
   - Console에서 `[Engine] ⚠️` 메시지 확인
   - NaN이 감지되면 자동으로 리셋됨

---

## 테스트 방법

### 1. Play 모드에서 테스트
1. Unity 에디터에서 Play 모드 진입
2. 키보드 입력 (WASD 또는 화살표 키)
3. Console 창 확인:
   - `[Engine] ⚠️ Rigidbody rotation이 NaN입니다!` 메시지가 나타나면 자동 리셋됨
   - 배가 정상적으로 움직이는지 확인

### 2. 로그 확인
- `[DefenseAgent] Engine 제어` 로그에서 `Throttle`, `Steering` 값이 NaN이 아닌지 확인
- `Input rotation is { NaN, NaN, NaN, NaN }` 에러가 더 이상 나타나지 않는지 확인

### 3. 배 동작 확인
- 배가 사라지지 않는지 확인
- 회전이 정상적으로 작동하는지 확인
- 조작이 즉각 반응하는지 확인

---

## 예상 결과

### ✅ 해결된 문제:
1. **"Input rotation is { NaN, NaN, NaN, NaN }" 에러 제거**
2. **배가 사라지는 현상 방지**
3. **조작이 먹히지 않는 현상 방지**
4. **회전이 이상한 현상 방지**

### ⚠️ 주의사항:
- NaN이 감지되면 자동으로 리셋되므로, 배가 잠깐 멈출 수 있습니다
- NaN이 자주 발생하면 근본 원인(물리 설정, Rigidbody 설정)을 확인해야 합니다
- 디버그 로그가 활성화되어 있으면 Console에 경고 메시지가 표시됩니다

---

## 추가 디버깅

### NaN이 계속 발생하는 경우:
1. **Rigidbody 설정 확인**:
   ```csharp
   // DefenseAgent GameObject의 Rigidbody 확인
   - Mass: 1 (너무 작거나 크지 않게)
   - Drag: 0.5 (적절한 값)
   - Angular Drag: 0.5 (적절한 값)
   - Constraints: 모두 해제 (Freeze Position/Rotation 체크 해제)
   ```

2. **물리 레이어 확인**:
   - 배가 다른 오브젝트와 충돌하면서 NaN이 발생할 수 있음
   - Physics Layers 설정 확인

3. **Time.fixedDeltaTime 확인**:
   - Edit → Project Settings → Time
   - Fixed Timestep이 0.02인지 확인

4. **에디터 재시작**:
   - Unity 에디터 완전 종료 후 재시작
   - Library 폴더 삭제 후 재컴파일 (최후의 수단)
