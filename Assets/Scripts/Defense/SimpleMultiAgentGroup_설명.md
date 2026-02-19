# SimpleMultiAgentGroup 설명

## ❓ SimpleMultiAgentGroup이란?

**SimpleMultiAgentGroup**은 Unity ML-Agents 패키지에서 제공하는 **컴포넌트**입니다.

### ✅ 중요한 사실:
- **별도 파일을 만들 필요 없습니다!**
- **스크립트를 작성할 필요 없습니다!**
- Unity ML-Agents 패키지에 이미 포함되어 있습니다.

---

## 📦 ML-Agents 패키지 확인 방법

### 1. Package Manager에서 확인
1. Unity 에디터에서 **Window → Package Manager** 열기
2. **In Project** 탭 선택
3. 검색창에 `ml-agents` 입력
4. `com.unity.ml-agents` 패키지가 설치되어 있는지 확인

### 2. manifest.json에서 확인
프로젝트 루트의 `Packages/manifest.json` 파일에서:
```json
{
  "dependencies": {
    "com.unity.ml-agents": "..."
  }
}
```
이 줄이 있으면 ML-Agents 패키지가 설치된 것입니다.

---

## 🔧 SimpleMultiAgentGroup 사용 방법

### Unity Inspector에서:
1. GameObject 선택
2. **Add Component** 클릭
3. 검색창에 `SimpleMultiAgentGroup` 입력
4. **SimpleMultiAgentGroup** 컴포넌트 추가

### 코드에서 사용:
```csharp
using Unity.MLAgents;

public class DefenseEnvController : MonoBehaviour
{
    public SimpleMultiAgentGroup m_AgentGroup;  // Inspector에서 할당
    
    void Start()
    {
        // 자동으로 찾기
        m_AgentGroup = GetComponent<SimpleMultiAgentGroup>();
    }
}
```

---

## ⚠️ SimpleMultiAgentGroup을 찾을 수 없는 경우

### 문제 1: Add Component에서 검색되지 않음
**해결 방법:**
1. Unity 에디터 재시작
2. Assets → Reimport All
3. Library 폴더 삭제 후 Unity 재시작 (최후의 수단)

### 문제 2: ML-Agents 패키지가 설치되지 않음
**해결 방법:**
1. Window → Package Manager
2. + → Add package by name
3. `com.unity.ml-agents` 입력
4. Install 클릭

### 문제 3: 패키지 버전 호환성 문제
**확인 사항:**
- Unity 버전이 ML-Agents와 호환되는지 확인
- ML-Agents 패키지 버전 확인

---

## 📚 참고 자료

- Unity ML-Agents 공식 문서: https://github.com/Unity-Technologies/ml-agents
- SimpleMultiAgentGroup API: Unity ML-Agents 패키지 내 문서

---

## 💡 요약

**SimpleMultiAgentGroup은:**
- ✅ Unity ML-Agents 패키지의 일부
- ✅ 별도 파일/스크립트 불필요
- ✅ Add Component로 추가 가능
- ❌ 직접 만들 필요 없음

**만약 찾을 수 없다면:**
1. ML-Agents 패키지 설치 확인
2. Unity 에디터 재시작
3. Library 폴더 삭제 후 재시작
