# 윤기나는 검정색 그라데이션 텍스처 만들기

## 🎨 목표
윤기나는 검정색 그라데이션 텍스처를 만들고 Material에 적용하기

---

## 방법 1: 에디터 스크립트 사용 (가장 쉬움)

### 1단계: 텍스처 생성

1. **Unity 메뉴 열기**:
   - `Tools > Create Gradient Texture`

2. **설정 조정**:
   - **텍스처 이름**: `Gradient_Black_Shiny`
   - **너비/높이**: 512 x 512 (또는 원하는 크기)
   - **저장 경로**: `Assets/Textures`
   - **그라데이션**: 검정색 계열로 조정

3. **그라데이션 커스터마이징**:
   - Gradient 필드에서 색상 조정
   - 예: 검정 → 어두운 회색 → 검정
   - 또는: 검정 → 약간 밝은 검정 → 검정

4. **텍스처 생성 버튼 클릭**

### 2단계: Material 생성

1. **Unity 메뉴 열기**:
   - `Tools > Create Shiny Black Material`

2. **설정**:
   - **Material 이름**: `Shiny_Black_Gradient`
   - **그라데이션 텍스처**: 위에서 만든 텍스처 선택
   - **Metallic**: 0.8 (금속성)
   - **Smoothness**: 0.9 (매끄러움)

3. **Material 생성 버튼 클릭**

### 3단계: Material 적용

1. **생성된 Material 찾기**:
   - `Assets/Materials/Shiny_Black_Gradient.mat`

2. **오브젝트에 적용**:
   - Material을 오브젝트로 드래그 앤 드롭
   - 또는 Inspector에서 Material 슬롯에 드래그

---

## 방법 2: Unity 에디터에서 직접 만들기

### 텍스처 생성:

1. **Project 창에서 우클릭**
2. **Create > Texture2D**
3. **이름**: `Gradient_Black`
4. **Inspector에서 설정**:
   - **Width/Height**: 512
   - **Format**: RGBA 32 bit
   - **Filter Mode**: Bilinear

5. **텍스처 편집** (외부 도구 필요):
   - Photoshop, GIMP 등에서 그라데이션 만들기
   - 검정색 그라데이션 적용
   - PNG로 저장 후 Unity에 Import

### Material 생성:

1. **Project 창에서 우클릭**
2. **Create > Material**
3. **이름**: `Shiny_Black`
4. **Shader 변경**: 
   - `Universal Render Pipeline/Lit` 선택
5. **설정**:
   - **Base Map**: 위에서 만든 텍스처 할당
   - **Base Color**: 흰색 (1, 1, 1)
   - **Metallic**: 0.8
   - **Smoothness**: 0.9

---

## 방법 3: 코드로 런타임 생성

### 스크립트 예시:

```csharp
using UnityEngine;

public class CreateGradientTexture : MonoBehaviour
{
    void Start()
    {
        Texture2D texture = CreateGradient(512, 512);
        
        // Material에 적용
        Material mat = GetComponent<Renderer>().material;
        mat.SetTexture("_BaseMap", texture);
        mat.SetFloat("_Metallic", 0.8f);
        mat.SetFloat("_Smoothness", 0.9f);
    }
    
    Texture2D CreateGradient(int width, int height)
    {
        Texture2D texture = new Texture2D(width, height);
        
        for (int y = 0; y < height; y++)
        {
            float t = (float)y / height;
            Color color = Color.Lerp(Color.black, new Color(0.1f, 0.1f, 0.1f), t);
            
            for (int x = 0; x < width; x++)
            {
                texture.SetPixel(x, y, color);
            }
        }
        
        texture.Apply();
        return texture;
    }
}
```

---

## 🎨 그라데이션 패턴 예시

### 1. 수직 그라데이션 (위→아래)
```
검정 → 어두운 회색 → 검정
```

### 2. 수평 그라데이션 (좌→우)
```
검정 → 어두운 회색 → 검정
```

### 3. 방사형 그라데이션 (중앙→외곽)
```
중앙: 밝은 검정
외곽: 검정
```

### 4. 대각선 그라데이션
```
좌상단: 검정
우하단: 어두운 회색
```

---

## ⚙️ Material 설정 가이드

### 윤기나는 효과를 위한 설정:

**Standard/Lit Shader**:
- **Metallic**: 0.7 ~ 0.9 (금속성)
- **Smoothness**: 0.8 ~ 1.0 (매끄러움)
- **Base Color**: 검정 또는 어두운 회색

**Unlit Shader** (간단한 경우):
- 윤기 효과 없음
- 단순한 그라데이션만 표시

---

## 📋 체크리스트

- [ ] 텍스처 생성됨
- [ ] 그라데이션이 원하는 대로 적용됨
- [ ] Material 생성됨
- [ ] Metallic/Smoothness 설정됨
- [ ] 오브젝트에 적용됨
- [ ] 윤기나는 효과 확인됨

---

## 💡 팁

### 더 윤기나게 만들기:
- **Smoothness**: 1.0 (최대)
- **Metallic**: 0.9 (높게)
- **환경 반사**: Reflection Probe 추가

### 그라데이션 조정:
- Gradient 필드에서 색상 키 추가/제거
- 위치 조정으로 그라데이션 방향 변경
- 여러 색상으로 복잡한 그라데이션 만들기

---

## 🔧 Unlit_Blocker.mat 수정하기

기존 Material을 수정하려면:

1. **Material 선택**: `Assets/Materials/Unlit_Blocker.mat`
2. **Shader 변경**: `Universal Render Pipeline/Lit`
3. **텍스처 할당**: 생성한 그라데이션 텍스처
4. **Metallic/Smoothness 설정**

또는 새 Material을 만들어서 사용하는 것을 권장합니다.
