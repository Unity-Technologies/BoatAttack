# MA-PPO 구현 가이드

## 생성된 스크립트 목록

### 팀 스크립트 (그룹 보상 분배)
1. **DefenseRewardCalculator.cs** - 보상 계산 중앙화
   - 협동 기동 보상 계산 (헤딩/속도 동기화, 간격 유지, 그물 장력)
   - 전술 기동 보상 계산 (수직 차단, 추적 이득)
   - 안전 및 제약 페널티 계산

2. **DefenseEnvController.cs** - 환경 관리 및 그룹 보상 분배
   - `SimpleMultiAgentGroup` 관리
   - 매 프레임 보상 계산 및 분배
   - 임무 성과 보상 처리 (포획, 모선 방어, 방어선 침범)
   - 모선 충돌 처리 (Game Over)

3. **MotherShipCollisionDetector.cs** - 모선 충돌 감지
   - 모선 GameObject에 부착
   - 적군-모선 충돌 감지 및 알림

### 개인 스크립트 (에이전트)
4. **DefenseAgent.cs** (개선됨) - 개별 에이전트
   - 목표 속도 기반 액션
   - 상대 좌표 기반 관측
   - 적군 거리 기반 정렬
   - 개별 보상 제거 (그룹 보상으로 전환)

### 수정된 스크립트
5. **WebCollisionDetector.cs** (수정됨)
   - `DefenseEnvController`를 통한 그룹 보상 처리
   - 적의 위치 전달

6. **DefenseBoatManager.cs** (수정됨)
   - `DefenseEnvController`와 통합
   - 타임아웃 시 그룹 보상 처리

---

## Unity 설정 가이드

### 1. Scene 설정

#### Step 1: SimpleMultiAgentGroup 추가
1. 빈 GameObject 생성 (이름: "DefenseEnvController")
2. `SimpleMultiAgentGroup` 컴포넌트 추가
3. `DefenseEnvController` 컴포넌트 추가
4. `DefenseRewardCalculator` 컴포넌트 추가

#### Step 2: DefenseEnvController 설정
- **defenseAgent1**: 방어 에이전트 1 할당
- **defenseAgent2**: 방어 에이전트 2 할당
- **m_AgentGroup**: 같은 GameObject의 `SimpleMultiAgentGroup` 할당
- **rewardCalculator**: 같은 GameObject의 `DefenseRewardCalculator` 할당
- **motherShip**: 모선 GameObject 할당
- **enemyShips**: 적군 선박 배열 할당 (최대 5대)
- **webObject**: Web GameObject 할당

#### Step 3: DefenseAgent 설정
각 DefenseAgent에 다음 설정:
- **enemyShips**: 적군 선박 배열 (DefenseEnvController와 동일하게)
- **maxEnemyCount**: 5 (또는 적군 수에 맞게)
- **partnerAgent**: 파트너 DefenseAgent 할당
- **motherShip**: 모선 GameObject 할당
- **webObject**: Web GameObject 할당
- **maxLinearVelocity**: 20 (m/s)
- **maxAngularVelocity**: 90 (deg/s)

**⚠️ 중요: DecisionRequester 추가**
- 각 DefenseAgent GameObject에 `DecisionRequester` 컴포넌트 추가
- **Decision Period**: 5 (또는 원하는 값, 낮을수록 더 자주 결정)
- **Take Actions Between Decisions**: 체크 해제 (권장)
- **Behavior Type**: 
  - 테스트 시: **Heuristic Only** (키보드 입력 테스트)
  - 학습 시: **Default** (또는 Behavior Config에서 설정)

#### Step 4: SimpleMultiAgentGroup 설정
- **Agents**: defenseAgent1, defenseAgent2 추가
- **Behavior Name**: Behavior Config 이름 설정

#### Step 5: 모선 충돌 감지 설정
1. 모선 GameObject 선택
2. `MotherShipCollisionDetector` 컴포넌트 추가
3. **envController**: DefenseEnvController 할당
4. **enemyTag**: "attack_boat" 설정

#### Step 6: WebCollisionDetector 설정
1. Web GameObject 선택
2. `WebCollisionDetector` 컴포넌트 확인
3. **envController**: DefenseEnvController 할당

---

### 2. Behavior Config 설정

#### Observation Space
- **크기**: `11 + (4 × maxEnemyCount)`
  - 예: maxEnemyCount = 5 → 31개
  - 예: maxEnemyCount = 3 → 23개
  - 예: maxEnemyCount = 1 → 15개

#### Action Space
- **크기**: 2개 (연속 액션)
  - `actions[0]`: 목표 선속도 (-1~1)
  - `actions[1]`: 목표 각속도 (-1~1)

#### Hyperparameters
- **Algorithm**: PPO
- **Learning Rate**: 3e-4
- **Batch Size**: 128
- **Buffer Size**: 2048
- **Beta (entropy)**: 0.01
- **Epsilon (clipping)**: 0.2
- **Lambda (GAE)**: 0.95
- **Gamma (discount)**: 0.99

---

### 3. 보상 값 튜닝 가이드

#### 기본 보상 값 (계획서 기준)
- **협동 기동**: 0.0002 (헤딩/속도/간격 동기화)
- **그물 장력**: 0.0005
- **전술 기동**: 0.0002~0.0005 (수직 차단, 추적 이득)
- **임무 성과**: 1.0 (포획), 0.5 (모선 방어)
- **패널티**: -1.75 (모선 충돌), -1.0 (아군 충돌), -0.1 (경계선 침범)

#### 튜닝 팁
1. 학습 초기에는 협동 보상을 약간 높게 (0.0003~0.0005)
2. 학습이 안정화되면 협동 보상을 낮춰서 최종 목표에 집중
3. 모선 충돌 패널티는 절대 낮추지 말 것 (최악의 결과)
4. 보상 비율 검증: 최종 목표 보상이 협동 보상 누적합보다 10배 이상 커야 함

---

### 4. 디버깅 체크리스트

#### 초기 설정 확인
- [ ] SimpleMultiAgentGroup이 두 에이전트를 등록했는지 확인
- [ ] DefenseEnvController가 m_AgentGroup을 참조하는지 확인
- [ ] DefenseRewardCalculator가 DefenseEnvController에 할당되었는지 확인
- [ ] 모선에 MotherShipCollisionDetector가 추가되었는지 확인
- [ ] WebCollisionDetector가 envController를 참조하는지 확인

#### 휴리스틱 테스트 확인 ⚠️ 중요
- [ ] **각 DefenseAgent에 DecisionRequester 컴포넌트가 추가되었는지 확인**
- [ ] **DecisionRequester의 Behavior Type이 Heuristic Only로 설정되었는지 확인** (테스트 시)
- [ ] **Decision Period가 적절한지 확인** (5 권장)
- [ ] 에이전트 이름에 "1" 또는 "2"가 포함되어 있는지 확인
- [ ] 키보드 입력이 작동하는지 확인 (WASD 또는 화살표 키)

#### 관측값 확인
- [ ] Observation Space 크기가 올바른지 확인 (11 + 4×적군수)
- [ ] 적군 배열이 올바르게 할당되었는지 확인
- [ ] 상대 좌표 계산이 올바른지 확인 (Gizmo로 시각화)

#### 액션 확인
- [ ] 목표 속도가 올바르게 throttle/steering으로 변환되는지 확인
- [ ] 가속도 제한이 작동하는지 확인
- [ ] 스무딩이 적절한지 확인

#### 보상 확인
- [ ] 그룹 보상이 두 에이전트 모두에 분배되는지 확인
- [ ] 개별 보상이 제거되었는지 확인 (DefenseAgent.CalculateReward 비활성화)
- [ ] 보상 값이 계획서와 일치하는지 확인

---

### 5. 학습 시작 전 확인사항

1. **Unity Editor에서 테스트**
   - Heuristic 모드로 두 에이전트가 정상 동작하는지 확인
   - 키보드 입력이 목표 속도로 변환되는지 확인

2. **보상 분배 테스트**
   - DefenseEnvController의 Update()가 정상 호출되는지 확인
   - 그룹 보상이 분배되는지 로그로 확인

3. **충돌 감지 테스트**
   - 모선 충돌이 정상 감지되는지 확인
   - Web 충돌이 정상 감지되는지 확인

4. **에피소드 관리 테스트**
   - 에피소드 시작/종료가 정상 작동하는지 확인
   - 리셋이 올바르게 되는지 확인

---

### 6. 문제 해결

#### 문제: 휴리스틱이 작동하지 않음 (움직이지 않음)
- **원인 1**: DecisionRequester 컴포넌트가 없음
- **해결**: 각 DefenseAgent에 DecisionRequester 추가
- **원인 2**: Behavior Type이 Heuristic Only로 설정되지 않음
- **해결**: DecisionRequester의 Behavior Type을 Heuristic Only로 설정
- **원인 3**: _engine이 null이거나 RB가 null
- **해결**: DefenseAgent가 Boat 컴포넌트를 가지고 있는지 확인
- **원인 4**: OnActionReceived가 호출되지 않음
- **해결**: DecisionRequester의 Decision Period 확인 (너무 크면 느림)

#### 문제: 그룹 보상이 분배되지 않음
- **원인**: SimpleMultiAgentGroup이 에이전트를 등록하지 않음
- **해결**: Start()에서 RegisterAgent() 호출 확인

#### 문제: 관측값 크기 불일치
- **원인**: maxEnemyCount와 실제 적군 수 불일치
- **해결**: Behavior Config의 Observation Space 크기 확인

#### 문제: 목표 속도가 적용되지 않음
- **원인**: 가속도 제한이 너무 엄격함
- **해결**: maxLinearAcceleration, maxAngularAcceleration 값 조정

#### 문제: 보상 해킹 발생
- **원인**: 협동 보상 값이 너무 큼
- **해결**: 협동 보상 값을 더 낮춤 (0.0001~0.0002)

---

### 7. 다음 단계

1. Unity Scene 설정 완료
2. Behavior Config 설정 완료
3. Heuristic 모드로 테스트
4. 학습 시작
5. 보상 값 튜닝
6. 성능 검증

---

## 참고 파일

- **계획서**: `MA_PPO_Implementation_Plan.md`
- **구현 스크립트**:
  - `DefenseRewardCalculator.cs`
  - `DefenseEnvController.cs`
  - `MotherShipCollisionDetector.cs`
  - `DefenseAgent.cs` (개선됨)
  - `WebCollisionDetector.cs` (수정됨)
  - `DefenseBoatManager.cs` (수정됨)
