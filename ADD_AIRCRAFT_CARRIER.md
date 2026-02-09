# 항공모함(모선) 추가 가이드

## 🎯 목표
씬에 큰 항공모함 같은 구조물을 추가하여 방어 대상으로 사용

---

## 방법 1: 프리미티브로 간단하게 만들기 (가장 빠름)

### 단계:

1. **빈 GameObject 생성**
   - Hierarchy 우클릭 > Create Empty
   - 이름: "AircraftCarrier" 또는 "MotherShip"

2. **프리미티브 조합으로 만들기**:
   
   **선체 (Hull)**:
   - Create > 3D Object > Cube
   - 이름: "Hull"
   - Scale: (50, 5, 15) - 길이, 높이, 너비
   - Position: (0, 0, 0)
   - Material: 회색 또는 적절한 색상

   **갑판 (Deck)**:
   - Create > 3D Object > Cube
   - 이름: "Deck"
   - Scale: (50, 0.5, 15)
   - Position: (0, 2.5, 0) - 선체 위
   - Material: 어두운 회색

   **상부 구조물 (Superstructure)**:
   - Create > 3D Object > Cube
   - 이름: "Superstructure"
   - Scale: (8, 10, 6)
   - Position: (15, 5, 0) - 갑판 위, 한쪽 끝
   - Material: 회색

   **비행갑판 표시**:
   - Create > 3D Object > Plane
   - 이름: "FlightDeck"
   - Scale: (50, 1, 15)
   - Position: (0, 2.75, 0)
   - Material: 어두운 회색 또는 노란색 줄무늬

3. **모든 오브젝트를 AircraftCarrier의 자식으로**:
   - Hull, Deck, Superstructure, FlightDeck을 드래그하여 AircraftCarrier 하위로

4. **위치 배치**:
   - AircraftCarrier의 Transform 조정
   - Position: (0, 0, 0) 또는 원하는 위치
   - 물 위에 떠있도록 Y 위치 조정

5. **Collider 추가**:
   - AircraftCarrier에 Box Collider 추가
   - Size: (50, 5, 15)
   - Is Trigger: false (충돌 감지용)

---

## 방법 2: 보트 프리팹을 스케일 업해서 사용

### 단계:

1. **보트 프리팹 복사**:
   - `Assets/Objects/boats/_BoatBase.prefab` 선택
   - Ctrl+D (Duplicate)
   - 이름 변경: "AircraftCarrier"

2. **스케일 조정**:
   - Transform Scale: (5, 3, 5) 또는 원하는 크기
   - 예: (10, 5, 10) - 매우 큰 크기

3. **위치 조정**:
   - Position: (0, 0, 0) 또는 중앙
   - 물 위에 떠있도록 Y 위치 조정

4. **컴포넌트 조정**:
   - Rigidbody의 Mass 증가 (예: 100000)
   - Is Kinematic: true (고정된 모선)
   - 또는 부력 시스템 비활성화

5. **씬에 배치**:
   - 프리팹을 씬으로 드래그

---

## 방법 3: 스크립트로 자동 생성 (권장)

### MotherShipGenerator.cs 생성:

```csharp
using UnityEngine;

namespace BoatAttack
{
    /// <summary>
    /// 항공모함(모선)을 자동으로 생성하는 헬퍼 스크립트
    /// </summary>
    public class MotherShipGenerator : MonoBehaviour
    {
        [Header("Size Settings")]
        public float length = 50f;
        public float width = 15f;
        public float height = 5f;
        
        [Header("Position")]
        public Vector3 position = Vector3.zero;
        
        [Header("Materials")]
        public Material hullMaterial;
        public Material deckMaterial;
        
        [ContextMenu("Generate Aircraft Carrier")]
        public void GenerateAircraftCarrier()
        {
            // 부모 오브젝트 생성
            GameObject carrier = new GameObject("AircraftCarrier");
            carrier.transform.position = position;
            
            // 선체
            GameObject hull = CreateCube("Hull", new Vector3(0, 0, 0), 
                new Vector3(length, height, width), hullMaterial);
            hull.transform.SetParent(carrier.transform);
            
            // 갑판
            GameObject deck = CreateCube("Deck", new Vector3(0, height/2 + 0.25f, 0), 
                new Vector3(length, 0.5f, width), deckMaterial);
            deck.transform.SetParent(carrier.transform);
            
            // 상부 구조물
            GameObject superstructure = CreateCube("Superstructure", 
                new Vector3(length * 0.3f, height/2 + 5f, 0), 
                new Vector3(8f, 10f, 6f), hullMaterial);
            superstructure.transform.SetParent(carrier.transform);
            
            // Collider 추가
            BoxCollider collider = carrier.AddComponent<BoxCollider>();
            collider.size = new Vector3(length, height, width);
            collider.center = new Vector3(0, height/2, 0);
            
            // Rigidbody 추가 (선택적)
            Rigidbody rb = carrier.AddComponent<Rigidbody>();
            rb.isKinematic = true; // 고정된 모선
            rb.mass = 100000f;
            
            Debug.Log("항공모함 생성 완료!");
        }
        
        private GameObject CreateCube(string name, Vector3 position, Vector3 scale, Material mat)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.name = name;
            cube.transform.localPosition = position;
            cube.transform.localScale = scale;
            
            if (mat != null)
            {
                cube.GetComponent<Renderer>().material = mat;
            }
            
            return cube;
        }
    }
}
```

### 사용 방법:

1. **빈 GameObject 생성**
   - 이름: "CarrierGenerator"

2. **MotherShipGenerator 스크립트 추가**

3. **설정 조정** (Inspector):
   - Length: 50
   - Width: 15
   - Height: 5
   - Position: (0, 0, 0)

4. **생성**:
   - GameObject 우클릭 > "Generate Aircraft Carrier"
   - 또는 Play 모드에서 자동 생성되도록 `Start()`에 추가

---

## 방법 4: Unity Asset Store에서 가져오기

### 단계:

1. **Asset Store 열기**: Window > Asset Store

2. **검색**: "Aircraft Carrier" 또는 "Warship"

3. **무료 에셋 다운로드**:
   - "Military Ship" 등 검색
   - 무료 에셋 선택
   - Import

4. **씬에 배치**:
   - 다운로드한 프리팹을 씬으로 드래그
   - 크기 및 위치 조정

---

## 방법 5: 간단한 Low-Poly 모델 만들기

### Blender 또는 다른 3D 툴 사용:

1. **기본 모델링**:
   - 긴 박스 형태의 선체
   - 평평한 갑판
   - 상부 구조물

2. **Export**:
   - FBX 형식으로 내보내기

3. **Unity에 Import**:
   - Assets 폴더에 드래그
   - Material 생성 및 할당

4. **Prefab 생성**:
   - 씬에 배치 후 Prefab으로 저장

---

## 🎨 디테일 추가 (선택사항)

### 시각적 개선:

1. **Material 추가**:
   - 회색 메탈릭 재질
   - 갑판용 어두운 재질
   - 노란색 줄무늬 (비행갑판)

2. **조명**:
   - 항공모함 위에 Spot Light 추가
   - 조명 효과

3. **파티클 효과**:
   - 배기 연기
   - 물 보트 웨이크

4. **디테일 오브젝트**:
   - 안테나 (Cylinder)
   - 함포 (Cylinder)
   - 항공기 (간단한 프리미티브)

---

## ⚙️ 기능 추가

### 체력 시스템 (나중에):

```csharp
public class MotherShip : MonoBehaviour
{
    public float maxHealth = 1000f;
    private float currentHealth;
    
    void Start()
    {
        currentHealth = maxHealth;
    }
    
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            DestroyShip();
        }
    }
    
    private void DestroyShip()
    {
        // 파괴 효과
        Destroy(gameObject);
    }
}
```

### 충돌 감지:

- Box Collider 추가
- OnCollisionEnter로 충돌 감지
- 보트와의 충돌 처리

---

## 📋 최종 체크리스트

- [ ] 항공모함 오브젝트 생성됨
- [ ] 물 위에 올바르게 배치됨
- [ ] Collider 추가됨
- [ ] 크기가 적절함 (보트보다 훨씬 큼)
- [ ] 위치가 적절함 (중앙 또는 전략적 위치)
- [ ] Material 적용됨
- [ ] Rigidbody 설정됨 (Kinematic 권장)

---

## 💡 추천 방법

**빠른 프로토타입**: 방법 1 (프리미티브)
**자동화**: 방법 3 (스크립트)
**최종 결과물**: 방법 4 (Asset Store) 또는 방법 5 (커스텀 모델)

---

## 🎯 다음 단계

항공모함을 추가한 후:
1. **체력 시스템** 추가
2. **방어 시스템** 구현
3. **보트 스폰 포인트** 설정
4. **ML-Agents 타겟**으로 설정
