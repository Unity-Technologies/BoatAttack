# 수동 조종 디버깅 체크리스트

## 즉시 확인할 사항

### 1. DecisionRequester 컴포넌트 확인 ⚠️ 필수
1. Unity 에디터에서 DefenseAgent GameObject 선택
2. Inspector에서 **Decision Requester** 컴포넌트가 있는지 확인
3. 없으면: **Add Component → Decision Requester** 추가
4. 설정 확인:
   - **Decision Period**: 5 (또는 1~10)
   - **Take Actions Between Decisions**: 체크 해제 (권장)
   - **Behavior Type**: **Heuristic Only** (테스트 시)

### 2. Behavior Parameters 확인
1. DefenseAgent GameObject 선택
2. Inspector에서 **Behavior Parameters** 컴포넌트 확인
3. **Behavior Type**이 **Heuristic Only**로 설정되어 있는지 확인
   - Default → Heuristic Only로 변경

### 3. Engine 컴포넌트 확인
1. DefenseAgent GameObject에 **Boat** 컴포넌트가 있는지 확인
2. Boat 컴포넌트의 **engine** 필드가 할당되어 있는지 확인
3. Engine GameObject에 **Rigidbody** 컴포넌트가 있는지 확인

### 4. 디버그 로그 활성화
1. DefenseAgent의 Inspector에서
2. **Enable Debug Log** 체크
3. Play 모드에서 Console 창 확인
4. 다음 로그들이 나타나는지 확인:
   - `[DefenseAgent] DecisionRequester 확인됨`
   - `[DefenseAgent] Engine 확인됨`
   - `[DefenseAgent] Heuristic 호출됨 - 키 입력 감지`
   - `[DefenseAgent] OnActionReceived`
   - `[DefenseAgent] Engine 제어`

---

## 단계별 디버깅

### Step 1: 컴포넌트 확인
```
✅ DecisionRequester 있음
✅ Behavior Parameters 있음
✅ Behavior Type = Heuristic Only
✅ Boat 컴포넌트 있음
✅ Engine 할당됨
✅ Rigidbody 있음
```

### Step 2: 키보드 입력 확인
1. Play 모드 진입
2. 키보드 입력 (WASD 또는 화살표 키)
3. Console에서 다음 로그 확인:
   - `[DefenseAgent] Heuristic 호출됨 - 키 입력 감지`
   - `[DefenseAgent] Heuristic 액션 값: Linear=..., Angular=...`

**문제**: 로그가 나타나지 않음
- **원인**: DecisionRequester가 없거나 Behavior Type이 잘못됨
- **해결**: Step 1 다시 확인

### Step 3: OnActionReceived 확인
Console에서 다음 로그 확인:
- `[DefenseAgent] OnActionReceived: ..., Linear=..., Angular=...`

**문제**: 로그가 나타나지 않음
- **원인**: DecisionRequester의 Decision Period가 너무 큼
- **해결**: Decision Period를 1로 설정

### Step 4: Engine 제어 확인
Console에서 다음 로그 확인:
- `[DefenseAgent] Engine 제어: ..., Throttle=..., Steering=...`

**문제**: 로그가 나타나지 않음
- **원인**: _engine이 null이거나 RB가 null
- **해결**: Engine 컴포넌트 확인

**문제**: 로그는 나타나지만 움직이지 않음
- **원인**: Engine.Accelerate() 또는 Engine.Turn()이 작동하지 않음
- **해결**: Engine 스크립트 확인

---

## 일반적인 문제와 해결책

### 문제 1: 아무 로그도 나타나지 않음
**원인**: enableDebugLog가 false
**해결**: DefenseAgent의 Inspector에서 Enable Debug Log 체크

### 문제 2: "DecisionRequester 컴포넌트가 없습니다" 에러
**원인**: DecisionRequester가 없음
**해결**: Add Component → Decision Requester 추가

### 문제 3: "Engine이 null입니다" 에러
**원인**: Boat 컴포넌트가 없거나 engine 필드가 할당되지 않음
**해결**: 
1. Boat 컴포넌트 추가
2. Boat의 engine 필드에 Engine GameObject 할당

### 문제 4: "Engine.RB (Rigidbody)가 null입니다" 에러
**원인**: Engine GameObject에 Rigidbody가 없음
**해결**: Engine GameObject에 Rigidbody 컴포넌트 추가

### 문제 5: Heuristic은 호출되지만 OnActionReceived가 호출되지 않음
**원인**: DecisionRequester의 Decision Period가 너무 큼
**해결**: Decision Period를 1~5로 설정

### 문제 6: OnActionReceived는 호출되지만 Engine 제어 로그가 나타나지 않음
**원인**: throttle과 steering 값이 0에 가까움
**해결**: 
1. 키 입력이 제대로 되는지 확인
2. maxLinearVelocity, maxAngularVelocity 값 확인
3. velocityControlGain, angularVelocityControlGain 값 확인

### 문제 7: 모든 로그는 정상이지만 배가 움직이지 않음
**원인**: Engine.Accelerate() 또는 Engine.Turn() 메서드 문제
**해결**: 
1. Engine 스크립트 확인
2. Rigidbody의 constraints 확인 (Freeze Position이 체크되어 있지 않은지)
3. Rigidbody의 isKinematic이 false인지 확인

---

## 빠른 테스트 스크립트

DefenseAgent GameObject에 다음 스크립트를 임시로 추가하여 테스트:

```csharp
using UnityEngine;
using UnityEngine.InputSystem;

public class ManualControlTest : MonoBehaviour
{
    public Engine engine;
    
    void Update()
    {
        if (engine == null) return;
        
        Keyboard keyboard = Keyboard.current;
        if (keyboard == null) return;
        
        if (keyboard.wKey.isPressed)
        {
            engine.Accelerate(1f);
            Debug.Log("W 키 입력 - 전진");
        }
        if (keyboard.sKey.isPressed)
        {
            engine.Accelerate(-0.5f);
            Debug.Log("S 키 입력 - 후진");
        }
        if (keyboard.aKey.isPressed)
        {
            engine.Turn(-1f);
            Debug.Log("A 키 입력 - 좌회전");
        }
        if (keyboard.dKey.isPressed)
        {
            engine.Turn(1f);
            Debug.Log("D 키 입력 - 우회전");
        }
    }
}
```

**⚠️ 중요**: 이 프로젝트는 Unity의 새로운 Input System을 사용합니다.
- `Input.GetKey()` 대신 `Keyboard.current.wKey.isPressed` 사용
- `using UnityEngine.InputSystem;` 추가 필요

이 스크립트로 직접 Engine을 제어하여 움직이는지 확인하세요.
움직이면 → ML-Agents 설정 문제
움직이지 않으면 → Engine 또는 Rigidbody 문제
