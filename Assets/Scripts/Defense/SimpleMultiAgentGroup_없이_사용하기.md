# SimpleMultiAgentGroup 없이 사용하기

## ✅ 수정 완료

**DefenseEnvController**가 이제 SimpleMultiAgentGroup 없이도 작동합니다!

---

## 🔧 작동 방식

### SimpleMultiAgentGroup이 있는 경우:
- **그룹 보상 모드**: 두 에이전트가 동일한 보상을 받음
- `m_AgentGroup.AddGroupReward()` 사용
- `m_AgentGroup.EndGroupEpisode()` 사용

### SimpleMultiAgentGroup이 없는 경우:
- **개별 보상 모드**: 각 에이전트에 개별적으로 보상 부여
- `defenseAgent1.AddReward()` 사용
- `defenseAgent1.EndEpisode()` 사용

---

## 📋 설정 방법

### 방법 1: SimpleMultiAgentGroup 없이 사용 (현재 권장)

1. **DefenseEnvController GameObject 생성**
2. **컴포넌트 추가**:
   - ✅ DefenseEnvController
   - ✅ DefenseRewardCalculator
   - ❌ SimpleMultiAgentGroup (추가하지 않음)

3. **DefenseEnvController 설정**:
   - defenseAgent1, defenseAgent2 할당
   - rewardCalculator 할당 (같은 GameObject)
   - motherShip, enemyShips, webObject 할당
   - **m_AgentGroup은 비워둠** (null)

### 방법 2: SimpleMultiAgentGroup과 함께 사용

1. **DefenseEnvController GameObject 생성**
2. **컴포넌트 추가**:
   - ✅ SimpleMultiAgentGroup
   - ✅ DefenseEnvController
   - ✅ DefenseRewardCalculator

3. **설정**:
   - SimpleMultiAgentGroup의 Agents 배열에 defenseAgent1, defenseAgent2 추가
   - DefenseEnvController의 m_AgentGroup에 SimpleMultiAgentGroup 할당

---

## 🎯 랜덤 스폰 기능

### DefenseBoatManager 설정

**Inspector에서:**
- **Enable Random Spawn**: 체크 (랜덤 스폰 활성화)
- **Spawn Range**: 20 (기본값, 조절 가능)

### 동작 방식

에피소드가 시작될 때:
1. **모선은 제외** (위치 유지)
2. **아군 선박 (DefenseAgent 1, 2)**:
   - 기존 위치에서 ±spawnRange 범위로 랜덤 생성
   - 랜덤 회전 (0~360도)
3. **적군 선박들**:
   - 기존 위치에서 ±spawnRange 범위로 랜덤 생성
   - 랜덤 회전 (0~360도)
4. **Web 오브젝트**:
   - 두 아군 선박의 중간 위치로 자동 배치

---

## 📊 보상 분배 비교

### 그룹 보상 모드 (SimpleMultiAgentGroup 있음)
```
협동 보상 계산 → m_AgentGroup.AddGroupReward(0.0002)
→ defenseAgent1과 defenseAgent2 모두 +0.0002 받음
```

### 개별 보상 모드 (SimpleMultiAgentGroup 없음)
```
협동 보상 계산 → defenseAgent1.AddReward(0.0002)
                → defenseAgent2.AddReward(0.0002)
→ 각각 +0.0002 받음 (결과는 동일)
```

**결과적으로 보상 값은 동일하지만, MA-PPO 학습에는 그룹 보상이 더 효과적입니다.**

---

## ⚠️ 주의사항

### 개별 보상 모드의 한계:
- MA-PPO의 그룹 학습 최적화를 완전히 활용하지 못할 수 있음
- 하지만 기본적인 학습은 가능함

### 권장 사항:
- 가능하면 SimpleMultiAgentGroup 사용 (더 나은 협동 학습)
- 없어도 작동은 하지만, 그룹 보상이 더 효과적

---

## 🐛 문제 해결

### 문제: 보상이 분배되지 않음
- **확인**: DefenseEnvController의 enableDebugLog 활성화
- **확인**: Console에서 "[DefenseEnvController] 개별 보상 모드로 작동합니다" 메시지 확인

### 문제: 랜덤 스폰이 작동하지 않음
- **확인**: DefenseBoatManager의 enableRandomSpawn이 체크되어 있는지
- **확인**: spawnRange 값이 0보다 큰지

---

## 💡 요약

✅ **SimpleMultiAgentGroup 없이도 작동합니다!**
- 개별 보상 모드로 자동 전환
- 모든 기능 정상 작동

✅ **랜덤 스폰 기능 추가됨**
- 에피소드 시작 시 모선 제외 모든 선박 랜덤 재생성
- Inspector에서 range 조절 가능
