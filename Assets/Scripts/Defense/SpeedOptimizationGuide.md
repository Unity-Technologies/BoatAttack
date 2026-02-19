# 전진 속도 최적화 가이드

## 수정된 파라미터

### DefenseAgent.cs

#### 1. velocityControlGain
- **이전**: `1.0f`
- **현재**: `2.5f`
- **효과**: 속도 오차에 대한 반응 강도 증가 (2.5배 빠른 가속)

#### 2. maxLinearAcceleration
- **이전**: `5f` (m/s²)
- **현재**: `12f` (m/s²)
- **효과**: 최대 가속도 제한 완화 (2.4배 빠른 가속)

#### 3. inputSmoothing
- **이전**: `0.2f`
- **현재**: `0.4f`
- **효과**: 입력 반응 속도 증가 (2배 빠른 반응)

#### 4. Throttle 계산 개선
- **이전**: 속도 오차만 사용
- **현재**: 속도 오차 + 목표 속도 비례 결합
- **효과**: 목표 속도가 높을수록 더 강한 throttle 적용

---

## 추가 최적화 옵션

### Unity Inspector에서 조정 가능한 값들:

#### DefenseAgent 컴포넌트:
1. **maxLinearVelocity** (기본: 20 m/s)
   - 더 빠르게 하려면: `25 ~ 30`으로 증가
   - 주의: 너무 높으면 제어가 어려워질 수 있음

2. **velocityControlGain** (기본: 2.5)
   - 더 빠른 가속: `3.0 ~ 4.0`으로 증가
   - 주의: 너무 높으면 불안정할 수 있음

3. **maxLinearAcceleration** (기본: 12 m/s²)
   - 더 빠른 가속: `15 ~ 20`으로 증가
   - 주의: 물리적으로 비현실적일 수 있음

4. **inputSmoothing** (기본: 0.4)
   - 더 빠른 반응: `0.5 ~ 0.7`로 증가
   - 주의: 너무 높으면 부드러움이 떨어짐

#### Engine 컴포넌트 (Boat GameObject):
1. **horsePower** (기본: 18)
   - 더 강한 엔진: `25 ~ 30`으로 증가
   - 주의: 너무 높으면 제어가 어려워질 수 있음

---

## 속도 테스트 방법

### 1. 현재 속도 확인
- Console에서 `[DefenseAgent] Engine 제어` 로그 확인
- `CurrentVel` 값이 `maxLinearVelocity`에 가까워지는지 확인

### 2. 가속도 확인
- 키를 누르고 있을 때 속도가 빠르게 증가하는지 확인
- `Throttle` 값이 1.0에 가까워지는지 확인

### 3. 반응 속도 확인
- 키를 누르는 즉시 배가 반응하는지 확인
- 지연이 느껴지면 `inputSmoothing` 증가

---

## 권장 설정 값

### 빠른 속도 (권장):
```
maxLinearVelocity: 25
velocityControlGain: 3.0
maxLinearAcceleration: 15
inputSmoothing: 0.5
horsePower: 25
```

### 균형잡힌 속도 (기본):
```
maxLinearVelocity: 20
velocityControlGain: 2.5
maxLinearAcceleration: 12
inputSmoothing: 0.4
horsePower: 18
```

### 부드러운 속도:
```
maxLinearVelocity: 18
velocityControlGain: 2.0
maxLinearAcceleration: 10
inputSmoothing: 0.3
horsePower: 18
```

---

## 문제 해결

### 여전히 느린 경우:
1. **Engine의 horsePower 확인**
   - Boat GameObject의 Engine 컴포넌트에서 `horsePower` 값 확인
   - 18보다 작으면 증가 필요

2. **Rigidbody 설정 확인**
   - Mass가 너무 크지 않은지 확인 (1 ~ 5 권장)
   - Drag가 너무 크지 않은지 확인 (0.5 ~ 1.0 권장)

3. **물리 타임스텝 확인**
   - Edit → Project Settings → Time
   - Fixed Timestep: 0.02 (기본값)

4. **가속도 제한 확인**
   - `maxLinearAcceleration`이 너무 작으면 속도 증가가 제한됨
   - 12 이상 권장

### 너무 빠른 경우:
1. **velocityControlGain 감소** (2.0 ~ 2.5)
2. **maxLinearAcceleration 감소** (8 ~ 10)
3. **inputSmoothing 감소** (0.2 ~ 0.3)

---

## 디버그 로그 확인

Console에서 다음 로그를 확인하세요:
```
[DefenseAgent] Engine 제어: ..., Throttle=..., CurrentVel=...
```

- **Throttle**: 1.0에 가까울수록 최대 가속
- **CurrentVel**: `maxLinearVelocity`에 가까워질수록 최대 속도

Throttle이 1.0에 도달하지 못하면:
- `velocityControlGain` 증가
- `maxLinearAcceleration` 증가
- `horsePower` 증가
