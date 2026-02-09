# Unity Scene 설정 가이드 (단계별)

## 🎯 핵심: DefenseEnvController와 DefenseRewardCalculator 할당 위치

### ✅ 정답: **같은 GameObject에 함께 추가**

---

## 📋 단계별 설정 방법

### Step 1: 빈 GameObject 생성

1. Unity Hierarchy 창에서 **우클릭**
2. **Create Empty** 선택
3. 이름을 **"DefenseEnvController"**로 변경
   - 이 GameObject가 환경 관리의 중심이 됩니다

---

### Step 2: 컴포넌트 추가

**DefenseEnvController GameObject를 선택한 상태에서:**

1. **Inspector 창**에서 **Add Component** 클릭
2. 다음 컴포넌트들을 **순서대로** 추가:

#### ① SimpleMultiAgentGroup
- **⚠️ 중요**: 이것은 Unity ML-Agents 패키지에서 제공하는 컴포넌트입니다
- **별도 파일을 만들 필요 없습니다!**
- 검색: `SimpleMultiAgentGroup`
- 추가 후 설정:
  - **Behavior Name**: Behavior Config 이름 입력 (예: "DefenseBehavior")

**만약 SimpleMultiAgentGroup을 찾을 수 없다면:**
1. **Window → Package Manager** 열기
2. **Unity Registry** 선택
3. **ML-Agents** 검색
4. **com.unity.ml-agents** 패키지 설치 확인
5. 설치되어 있지 않다면 **Install** 클릭

#### ② DefenseEnvController
- 검색: `DefenseEnvController`
- 추가 후 설정 (아래 Step 3 참고)

#### ③ DefenseRewardCalculator
- 검색: `DefenseRewardCalculator`
- 추가 후 설정 (아래 Step 4 참고)

---

### Step 3: DefenseEnvController 설정

**DefenseEnvController 컴포넌트**의 Inspector에서:

#### Agents 섹션:
- **Defense Agent 1**: 
  - Hierarchy에서 DefenseAgent 1 GameObject를 드래그 앤 드롭
- **Defense Agent 2**: 
  - Hierarchy에서 DefenseAgent 2 GameObject를 드래그 앤 드롭

#### Components 섹션:
- **M Agent Group**: 
  - **같은 GameObject의 SimpleMultiAgentGroup**을 드래그 앤 드롭
  - 또는 Inspector에서 드롭다운으로 선택
- **Reward Calculator**: 
  - **같은 GameObject의 DefenseRewardCalculator**를 드래그 앤 드롭
  - 또는 Inspector에서 드롭다운으로 선택

#### Settings 섹션:
- **Mother Ship**: 
  - Hierarchy에서 모선 GameObject를 드래그 앤 드롭
- **Enemy Ships**: 
  - 배열 크기 설정 (예: 5)
  - 각 요소에 적군 선박 GameObject들을 드래그 앤 드롭
- **Web Object**: 
  - Hierarchy에서 Web GameObject를 드래그 앤 드롭

---

### Step 4: DefenseRewardCalculator 설정

**DefenseRewardCalculator 컴포넌트**는 기본값으로 작동하지만, 필요시 보상 값을 조정할 수 있습니다:

- **Heading Sync Reward**: 0.0002 (기본값)
- **Speed Sync Reward**: 0.0002 (기본값)
- **Distance Maintain Reward**: 0.0002 (기본값)
- **Net Tension Reward**: 0.0005 (기본값)
- 등등...

---

### Step 5: SimpleMultiAgentGroup 설정

**SimpleMultiAgentGroup 컴포넌트**의 Inspector에서:

- **Agents**: 
  - 배열 크기: 2
  - [0]: DefenseAgent 1 드래그 앤 드롭
  - [1]: DefenseAgent 2 드래그 앤 드롭
- **Behavior Name**: 
  - Behavior Config 이름 입력 (예: "DefenseBehavior")

---

## 📸 시각적 구조

```
Hierarchy:
├── DefenseEnvController (GameObject)
│   ├── SimpleMultiAgentGroup (컴포넌트)
│   ├── DefenseEnvController (컴포넌트)
│   │   ├── defenseAgent1 → DefenseAgent 1 GameObject
│   │   ├── defenseAgent2 → DefenseAgent 2 GameObject
│   │   ├── m_AgentGroup → 같은 GameObject의 SimpleMultiAgentGroup
│   │   ├── rewardCalculator → 같은 GameObject의 DefenseRewardCalculator
│   │   ├── motherShip → 모선 GameObject
│   │   ├── enemyShips[0~4] → 적군 선박들
│   │   └── webObject → Web GameObject
│   └── DefenseRewardCalculator (컴포넌트)
│       └── (보상 값 설정)
├── DefenseAgent 1 (GameObject)
│   └── DefenseAgent (컴포넌트)
├── DefenseAgent 2 (GameObject)
│   └── DefenseAgent (컴포넌트)
├── MotherShip (GameObject)
│   └── MotherShipCollisionDetector (컴포넌트)
│       └── envController → DefenseEnvController GameObject
└── Web (GameObject)
    └── WebCollisionDetector (컴포넌트)
        └── envController → DefenseEnvController GameObject
```

---

## ⚠️ 중요 체크리스트

### DefenseEnvController GameObject:
- [ ] SimpleMultiAgentGroup 컴포넌트 추가됨
- [ ] DefenseEnvController 컴포넌트 추가됨
- [ ] DefenseRewardCalculator 컴포넌트 추가됨
- [ ] defenseAgent1 할당됨
- [ ] defenseAgent2 할당됨
- [ ] m_AgentGroup이 같은 GameObject의 SimpleMultiAgentGroup을 참조
- [ ] rewardCalculator가 같은 GameObject의 DefenseRewardCalculator를 참조
- [ ] motherShip 할당됨
- [ ] enemyShips 배열에 적군들 할당됨
- [ ] webObject 할당됨

### SimpleMultiAgentGroup:
- [ ] Agents 배열에 defenseAgent1, defenseAgent2 추가됨
- [ ] Behavior Name 설정됨

---

## 🔍 자동 찾기 기능

`DefenseEnvController.cs`의 `Start()` 메서드에서 일부 참조를 자동으로 찾습니다:

```csharp
// 자동으로 찾는 것들:
- SimpleMultiAgentGroup (같은 GameObject에서)
- DefenseRewardCalculator (같은 GameObject에서)
- MotherShip (태그로 찾기)
```

하지만 **수동으로 할당하는 것이 더 안전하고 명확**합니다!

---

## 🐛 문제 해결

### 문제: "SimpleMultiAgentGroup을 찾을 수 없습니다" 에러

#### 원인 1: 컴포넌트가 추가되지 않음
- **해결**: DefenseEnvController GameObject에 SimpleMultiAgentGroup 컴포넌트 추가
- Add Component → `SimpleMultiAgentGroup` 검색

#### 원인 2: ML-Agents 패키지가 설치되지 않음
- **확인 방법**: 
  1. Window → Package Manager 열기
  2. In Project 탭에서 `com.unity.ml-agents` 검색
  3. 설치되어 있는지 확인
- **해결**: 
  - 패키지가 없다면: Package Manager → + → Add package by name → `com.unity.ml-agents` 입력
  - 또는 Unity Registry에서 ML-Agents 검색하여 설치

#### 원인 3: Add Component에서 SimpleMultiAgentGroup을 찾을 수 없음
- **해결**: 
  1. Unity 에디터 재시작
  2. Assets → Reimport All (필요시)
  3. Library 폴더 삭제 후 Unity 재시작 (최후의 수단)

### 문제: "DefenseRewardCalculator를 찾을 수 없습니다" 에러
- **원인**: 같은 GameObject에 DefenseRewardCalculator가 없음
- **해결**: DefenseEnvController GameObject에 DefenseRewardCalculator 추가

### 문제: 보상이 분배되지 않음
- **원인**: m_AgentGroup이 null이거나 에이전트가 등록되지 않음
- **해결**: 
  1. m_AgentGroup이 할당되었는지 확인
  2. SimpleMultiAgentGroup의 Agents 배열에 에이전트가 추가되었는지 확인

---

## 💡 요약

**핵심 정리:**
1. **빈 GameObject 생성** → 이름: "DefenseEnvController"
2. **3개 컴포넌트 추가**:
   - SimpleMultiAgentGroup
   - DefenseEnvController
   - DefenseRewardCalculator
3. **DefenseEnvController 컴포넌트 설정**:
   - defenseAgent1, defenseAgent2 할당
   - m_AgentGroup → 같은 GameObject의 SimpleMultiAgentGroup
   - rewardCalculator → 같은 GameObject의 DefenseRewardCalculator
   - motherShip, enemyShips, webObject 할당
4. **SimpleMultiAgentGroup 설정**:
   - Agents 배열에 defenseAgent1, defenseAgent2 추가

**모든 것이 같은 GameObject에 있어야 합니다!**
