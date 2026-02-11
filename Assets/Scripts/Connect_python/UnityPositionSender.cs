using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.SideChannels;
using System.Collections;

/// <summary>
/// Unity 씬의 객체 위치를 수집하여 Python으로 전송하는 스크립트
/// 이 스크립트를 빈 GameObject에 추가하고 추적할 객체들을 설정하세요.
/// </summary>
public class UnityPositionSender : MonoBehaviour
{
    [Tooltip("추적할 GameObject들 (비어있으면 자동으로 찾음)")]
    public GameObject[] trackedObjects;

    [Tooltip("위치 업데이트 간격 (초)")]
    public float updateInterval = 0.05f; // 50ms

    [Tooltip("자동으로 특정 태그를 가진 객체들을 찾을지 여부")]
    public bool autoFindByTag = false;

    [Tooltip("자동 찾기 시 사용할 태그")]
    public string targetTag = "Untagged";

    [Tooltip("자동으로 특정 타입의 컴포넌트를 가진 객체들을 찾을지 여부")]
    public bool autoFindByComponent = false;

    [Tooltip("자동 찾기 시 사용할 컴포넌트 타입 (예: Rigidbody, Collider 등)")]
    public string componentType = "Rigidbody";

    private PositionSideChannel positionChannel;
    private float lastUpdateTime = 0f;
    private static PositionSideChannel staticChannel; // 싱글톤 패턴
    
    // FixedUpdate를 사용하므로 fixedTime을 사용해야 함

    void Start()
    {
        // PositionSideChannel 초기화 (싱글톤 패턴)
        if (staticChannel == null)
        {
            staticChannel = new PositionSideChannel();
            Debug.Log($"[UnityPositionSender] PositionSideChannel 초기화 완료. ChannelId: {staticChannel.ChannelId}");
            Debug.Log("[UnityPositionSender] Python 측에서 같은 UUID로 Side Channel을 등록했는지 확인하세요.");
            
            // 중요: Unity ML-Agents의 Side Channel은 Python에서 등록하면 Unity가 자동으로 인식합니다.
            // Unity C#에서는 같은 UUID로 Side Channel을 생성하고 메시지를 보내기만 하면 됩니다.
            // 하지만 실제로는 Unity C#에서도 명시적으로 등록해야 할 수 있습니다.
            // Academy가 초기화될 때까지 대기한 후 등록 시도
            StartCoroutine(WaitForAcademyAndRegister());
        }
        positionChannel = staticChannel;

        // 추적할 객체 설정
        SetupTrackedObjects();

        if (trackedObjects == null || trackedObjects.Length == 0)
        {
            Debug.LogWarning("[UnityPositionSender] 추적할 객체가 없습니다!");
        }
        else
        {
            Debug.Log($"[UnityPositionSender] {trackedObjects.Length}개의 객체를 추적합니다.");
        }
    }

    void SetupTrackedObjects()
    {
        // 수동으로 설정된 객체가 있으면 사용
        if (trackedObjects != null && trackedObjects.Length > 0)
        {
            return;
        }

        System.Collections.Generic.List<GameObject> foundObjects = 
            new System.Collections.Generic.List<GameObject>();

        // 태그로 찾기
        if (autoFindByTag && !string.IsNullOrEmpty(targetTag))
        {
            GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag(targetTag);
            foundObjects.AddRange(taggedObjects);
            Debug.Log($"[UnityPositionSender] 태그 '{targetTag}'로 {taggedObjects.Length}개 객체 발견");
        }

        // 컴포넌트로 찾기
        if (autoFindByComponent && !string.IsNullOrEmpty(componentType))
        {
            System.Type compType = System.Type.GetType(componentType);
            if (compType == null)
            {
                // Unity 네임스페이스에서 찾기 시도
                compType = System.Type.GetType($"UnityEngine.{componentType}");
            }

            if (compType != null)
            {
                // FindObjectsOfType의 제네릭 버전 사용 또는 명시적 캐스팅
                Object[] foundComponents = FindObjectsOfType(compType);
                foreach (Object obj in foundComponents)
                {
                    Component comp = obj as Component;
                    if (comp != null && comp.gameObject != null)
                    {
                        foundObjects.Add(comp.gameObject);
                    }
                }
                Debug.Log($"[UnityPositionSender] 컴포넌트 '{componentType}'로 {foundComponents.Length}개 객체 발견");
            }
            else
            {
                Debug.LogWarning($"[UnityPositionSender] 컴포넌트 타입 '{componentType}'를 찾을 수 없습니다.");
            }
        }

        // 기본값: 씬의 모든 활성 GameObject 찾기 (선택사항)
        if (foundObjects.Count == 0 && !autoFindByTag && !autoFindByComponent)
        {
            Debug.Log("[UnityPositionSender] 추적할 객체를 수동으로 설정하거나 자동 찾기 옵션을 활성화하세요.");
        }

        trackedObjects = foundObjects.ToArray();
    }

    void FixedUpdate()
    {
        // FixedUpdate 사용: ML-Agents의 물리 엔진 주기와 동기화
        // Update() 대신 FixedUpdate()를 사용하면 데드락 문제를 피할 수 있음
        if (positionChannel == null)
        {
            return;
        }

        // 업데이트 간격 체크
        if (Time.fixedTime - lastUpdateTime < updateInterval)
        {
            return;
        }
        lastUpdateTime = Time.fixedTime;

        // 각 객체의 위치 수집
        int validObjectCount = 0;
        foreach (GameObject obj in trackedObjects)
        {
            if (obj == null)
            {
                continue;
            }

            Vector3 position = obj.transform.position;
            string key = obj.name;

            // 위치 데이터 설정
            positionChannel.SetPosition(key, position);
            validObjectCount++;
        }

        // 디버깅: 주기적으로 로그 출력
        if (Time.frameCount % 120 == 0) // 약 2초마다 (60fps 기준)
        {
            Debug.Log($"[UnityPositionSender] 추적 중인 객체 수: {validObjectCount}, 총 객체 수: {trackedObjects?.Length ?? 0}");
        }

        // 모든 위치 데이터를 Python으로 전송
        if (positionChannel != null && validObjectCount > 0)
        {
            positionChannel.SendPositionsToPython();
        }
    }
    
    private IEnumerator WaitForAcademyAndRegister()
    {
        // Academy가 초기화될 때까지 대기
        int maxWaitFrames = 120; // 최대 2초 대기 (60fps 기준)
        int frameCount = 0;
        
        while (Academy.Instance == null && frameCount < maxWaitFrames)
        {
            yield return null;
            frameCount++;
        }
        
        if (Academy.Instance != null)
        {
            Debug.Log("[UnityPositionSender] Academy 인스턴스 확인 완료.");
            
            // Unity ML-Agents의 Side Channel은 Python에서 등록하면 Unity가 자동으로 인식합니다.
            // Unity C#에서는 같은 UUID로 Side Channel을 생성하고 메시지를 보내기만 하면 됩니다.
            // 하지만 실제로는 Unity C#에서도 명시적으로 등록해야 할 수 있습니다.
            // 현재 Unity ML-Agents 버전에서는 Academy.SideChannels가 없으므로,
            // Python 측에서 등록한 Side Channel을 Unity가 자동으로 인식하는지 확인해야 합니다.
            
            Debug.Log($"[UnityPositionSender] Side Channel 등록 상태 확인:");
            Debug.Log($"  - ChannelId: {staticChannel.ChannelId}");
            Debug.Log($"  - Python 측 UUID와 일치하는지 확인: 621f0a70-4f87-11d2-a976-00c04f8e1488");
        }
        else
        {
            Debug.LogWarning("[UnityPositionSender] Academy 인스턴스를 찾을 수 없습니다. ML-Agents Academy가 씬에 있는지 확인하세요.");
        }
    }

    void OnDestroy()
    {
        // Side Channel 정리
        // Unity ML-Agents는 Python 연결이 끊기면 자동으로 처리됩니다.
        if (staticChannel != null && positionChannel == staticChannel)
        {
            staticChannel = null;
        }
    }
}
