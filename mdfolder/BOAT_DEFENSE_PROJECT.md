# ⚓ Boat Defense: Multi-Agent Self-Play Project

## 1. 프로젝트 개요

- **기반 환경**: Unity Boat Attack (Universal RP)
- **학습 방식**: ML-Agents Multi-Agent Post-Optimization (MA-POCA) 및 Self-Play
- **시나리오**: 해상 공성전 - 아군(6대)은 모선을 방어하고, 적군(10대)은 모선을 파괴하는 비대칭 전투

## 2. 에이전트 구성 (Team Setup)

### Team A: Defenders (방어팀 - 6 Boats)
- **목표**: 모선 근처에서 방어 진형 형성 및 적선 격침
- **전략**: 모선 주변에서 순찰하며 적의 접근 차단
- **보상**: 모선 체력 유지, 적선 격침, 모선과의 거리 유지

### Team B: Attackers (공격팀 - 10 Boats)
- **목표**: 모선에 접근하여 화력 집중
- **전략**: 협력하여 모선에 집중 공격
- **보상**: 모선 데미지, 생존, 모선과의 거리 감소

### Mother Ship (모선)
- **역할**: 방어 대상 (Static/Target)
- **시스템**: 체력(HP) 시스템, 데미지 처리
- **위치**: 맵 중앙 고정 또는 제한된 이동 범위

## 3. 개발 로드맵

### Phase 1: 환경 이식 및 Prefab화 ✅
- [x] Boat Attack 에셋을 멀티 에이전트 환경으로 이식
- [x] 보트 Prefab 생성 및 팀별 구분
- [x] 씬 구조 설계 (학습/플레이 모드 분리)

### Phase 2: 전투 시스템 구현
- [ ] 선박 간 충돌 처리 시스템
- [ ] 원거리 공격(Projectile) 시스템 구현
  - 발사체 생성 및 물리
  - 데미지 계산
  - 충돌 감지
- [ ] 모선 HP 시스템 및 데미지 처리
- [ ] 팀별 구분 및 팀 인식 시스템

### Phase 3: ML-Agents 통합
- [ ] ML-Agents Agent 스크립트 작성
- [ ] 관측(Observation) 시스템 구현
  - Raycast를 통한 주변 장애물 감지
  - 모선/상대방과의 상대 위치 정보
  - 속도, 방향, 체력 정보
- [ ] 행동(Action) 시스템 구현
  - 가속/감속
  - 좌우 회전
  - 공격 (발사)
- [ ] 보상 함수 구현 (`REWARD_DESIGN.md` 참조)
  - 방어팀 보상: 모선 체력 유지, 적 격침, 거리 유지
  - 공격팀 보상: 모선 데미지, 생존, 접근

### Phase 4: 학습 설정 및 실행
- [ ] `trainer_config.yaml` 설정
  - MA-POCA 알고리즘 설정
  - Self-Play 설정
  - 하이퍼파라미터 튜닝
- [ ] 학습 환경 최적화
- [ ] 학습 실행 및 모니터링

## 4. 기술적 제약 사항 및 설계 결정

### 물리 엔진
- **부력 시스템**: Boat Attack의 기존 부력 시스템 유지
- **충돌 처리**: Unity Physics 기반
- **성능**: 멀티 에이전트 환경 최적화 필요

### 관측(Observation) 시스템
- **Raycast 기반**: 주변 장애물, 적, 모선 감지
- **상대 위치**: 모선/상대방과의 거리 및 각도
- **자체 상태**: 속도, 방향, 체력, 탄약
- **팀 정보**: 아군 위치 및 상태

### 행동(Action) 시스템
- **연속 행동 공간**:
  - 가속/감속: [-1, 1] (뒤로/앞으로)
  - 좌우 회전: [-1, 1] (왼쪽/오른쪽)
  - 공격: [0, 1] (발사 여부)

### 모드 전환 시스템
- **플레이 모드**: 키보드로 직접 조작 가능
- **학습 모드**: ML-Agents 에이전트가 제어
- **전환**: 런타임 또는 씬별 분리

## 5. 씬 구조

### 학습용 씬
- `scenes/ml_agents/defense_training.unity`
  - ML-Agents 학습 전용 씬
  - 최소한의 시각 효과 (성능 최적화)
  - 자동 리셋 및 에피소드 관리

### 플레이/테스트용 씬
- `scenes/ml_agents/defense_play.unity`
  - 키보드 조작 가능한 플레이 모드
  - 학습된 모델 테스트
  - 시각 효과 포함

### 기존 씬 (참고용)
- `scenes/demo_Island.unity`: 원본 레이싱 씬
- `scenes/_levels/level_Island.unity`: 메인 레벨

## 6. 파일 구조

```
Assets/
├── Scripts/
│   ├── MLAgents/
│   │   ├── DefenseAgent.cs          # ML-Agents Agent 스크립트
│   │   ├── DefenseAcademy.cs        # Academy 설정
│   │   └── DefenseArea.cs           # 학습 영역 관리
│   ├── Defense/
│   │   ├── DefenseManager.cs        # 방어 게임 로직 관리
│   │   ├── MotherShip.cs            # 모선 스크립트
│   │   ├── Projectile.cs            # 발사체 스크립트
│   │   ├── HealthSystem.cs          # 체력 시스템
│   │   └── TeamManager.cs           # 팀 관리
│   ├── Boat/
│   │   ├── HumanController.cs       # 플레이어 조작 (기존 + 모드 전환)
│   │   └── ... (기존 파일들)
│   └── GameSystem/
│       ├── GameModeManager.cs       # 학습/플레이 모드 전환
│       └── ... (기존 파일들)
├── scenes/
│   └── ml_agents/
│       ├── defense_training.unity    # 학습용 씬
│       └── defense_play.unity       # 플레이용 씬
└── ml-agents/
    └── config/
        └── trainer_config.yaml      # 학습 설정 파일
```

## 7. 보상 설계 (요약)

### 방어팀 (Team A) 보상
- `+0.1`: 모선 체력 유지 (시간당)
- `+1.0`: 적선 격침
- `+0.05`: 모선과 적절한 거리 유지 (너무 가까우면 페널티)
- `-0.1`: 모선 체력 감소시 페널티
- `-0.5`: 자체 격침시 페널티

### 공격팀 (Team B) 보상
- `+0.5`: 모선에 데미지 입힘
- `+0.1`: 모선에 접근 (거리 기반)
- `+1.0`: 모선 파괴 (팀 전체 보상)
- `-0.5`: 자체 격침시 페널티
- `-0.1`: 시간당 작은 페널티 (빠른 승리 유도)

### 공통
- `+0.01`: 생존 보너스 (시간당)
- 에피소드 종료: 승리/패배에 따른 추가 보상

## 8. 학습 설정 (MA-POCA)

### 알고리즘
- **MA-POCA**: Multi-Agent Post-Optimization with Curriculum Adaptation
- **Self-Play**: 적대적 팀 간 경쟁을 통한 학습

### 하이퍼파라미터 (예상)
- Learning Rate: 3e-4
- Batch Size: 1024
- Buffer Size: 10240
- Beta: 0.01 (entropy coefficient)
- Epsilon: 0.2 (clipping)
- Lambda: 0.95 (GAE lambda)

## 9. 다음 단계

1. **즉시 구현**:
   - GameModeManager 생성
   - DefenseManager 기본 구조
   - 학습/플레이 씬 생성

2. **단기 목표**:
   - 프로젝타일 시스템
   - 체력 시스템
   - 팀 관리 시스템

3. **중기 목표**:
   - ML-Agents 통합
   - 관측/행동 시스템
   - 보상 함수 구현

4. **장기 목표**:
   - 학습 실행 및 튜닝
   - 모델 평가 및 개선

## 10. 참고 자료

- [ML-Agents Documentation](https://github.com/Unity-Technologies/ml-agents)
- [MA-POCA Paper](https://arxiv.org/abs/2103.01948)
- [Boat Attack 원본 프로젝트](https://github.com/Verasl/BoatAttack)

---

**작성일**: 2024
**프로젝트 상태**: Phase 1 진행 중
