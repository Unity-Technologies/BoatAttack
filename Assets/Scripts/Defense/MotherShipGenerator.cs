using UnityEngine;

namespace BoatAttack
{
    /// <summary>
    /// 항공모함(모선)을 자동으로 생성하는 헬퍼 스크립트
    /// Inspector에서 설정 후 Context Menu로 생성하거나 Start()에서 자동 생성
    /// </summary>
    public class MotherShipGenerator : MonoBehaviour
    {
        [Header("Size Settings")]
        [Tooltip("항공모함 길이")]
        public float length = 50f;
        
        [Tooltip("항공모함 너비")]
        public float width = 15f;
        
        [Tooltip("항공모함 높이")]
        public float height = 5f;
        
        [Header("Position")]
        [Tooltip("항공모함 위치 (World 좌표)")]
        public Vector3 position = Vector3.zero;
        
        [Header("Materials")]
        [Tooltip("선체 재질 (없으면 기본 재질 사용)")]
        public Material hullMaterial;
        
        [Tooltip("갑판 재질 (없으면 기본 재질 사용)")]
        public Material deckMaterial;
        
        [Header("Physics")]
        [Tooltip("고정된 모선인지 (Kinematic)")]
        public bool isKinematic = true;
        
        [Tooltip("질량 (Kinematic이 아닐 경우)")]
        public float mass = 100000f;
        
        [Header("Auto Generate")]
        [Tooltip("시작 시 자동 생성")]
        public bool generateOnStart = false;

        void Start()
        {
            if (generateOnStart)
            {
                GenerateAircraftCarrier();
            }
        }

        /// <summary>
        /// 항공모함 생성 (Context Menu에서 호출 가능)
        /// </summary>
        [ContextMenu("Generate Aircraft Carrier")]
        public void GenerateAircraftCarrier()
        {
            // 기존 항공모함이 있으면 제거
            GameObject existing = GameObject.Find("AircraftCarrier");
            if (existing != null)
            {
                if (Application.isPlaying)
                {
                    Destroy(existing);
                }
                else
                {
                    DestroyImmediate(existing);
                }
            }

            // 부모 오브젝트 생성
            GameObject carrier = new GameObject("AircraftCarrier");
            carrier.transform.position = position;
            carrier.tag = "MotherShip"; // 태그 추가 (나중에 찾기 쉽게)

            // 선체 (Hull)
            GameObject hull = CreateCube("Hull", new Vector3(0, 0, 0),
                new Vector3(length, height, width), hullMaterial);
            hull.transform.SetParent(carrier.transform);

            // 갑판 (Deck)
            GameObject deck = CreateCube("Deck", new Vector3(0, height / 2 + 0.25f, 0),
                new Vector3(length, 0.5f, width), deckMaterial);
            deck.transform.SetParent(carrier.transform);

            // 상부 구조물 (Superstructure) - 오른쪽 끝
            GameObject superstructure = CreateCube("Superstructure",
                new Vector3(length * 0.3f, height / 2 + 5f, 0),
                new Vector3(8f, 10f, 6f), hullMaterial);
            superstructure.transform.SetParent(carrier.transform);

            // 비행갑판 표시 (Flight Deck) - 평면
            GameObject flightDeck = GameObject.CreatePrimitive(PrimitiveType.Plane);
            flightDeck.name = "FlightDeck";
            flightDeck.transform.SetParent(carrier.transform);
            flightDeck.transform.localPosition = new Vector3(0, height / 2 + 0.3f, 0);
            flightDeck.transform.localScale = new Vector3(length / 10f, 1f, width / 10f);
            flightDeck.transform.localRotation = Quaternion.Euler(0, 0, 0);
            if (deckMaterial != null)
            {
                flightDeck.GetComponent<Renderer>().material = deckMaterial;
            }

            // Collider 추가
            BoxCollider collider = carrier.AddComponent<BoxCollider>();
            collider.size = new Vector3(length, height, width);
            collider.center = new Vector3(0, height / 2, 0);

            // Rigidbody 추가
            Rigidbody rb = carrier.AddComponent<Rigidbody>();
            rb.isKinematic = isKinematic;
            if (!isKinematic)
            {
                rb.mass = mass;
            }

            Debug.Log($"항공모함 생성 완료! 위치: {position}, 크기: {length}x{width}x{height}");
        }

        /// <summary>
        /// 큐브 생성 헬퍼 메서드
        /// </summary>
        private GameObject CreateCube(string name, Vector3 localPosition, Vector3 scale, Material mat)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.name = name;
            cube.transform.localPosition = localPosition;
            cube.transform.localScale = scale;

            if (mat != null)
            {
                cube.GetComponent<Renderer>().material = mat;
            }
            else
            {
                // 기본 회색 재질
                Material defaultMat = new Material(Shader.Find("Standard"));
                defaultMat.color = new Color(0.5f, 0.5f, 0.5f);
                cube.GetComponent<Renderer>().material = defaultMat;
            }

            return cube;
        }

        /// <summary>
        /// Gizmo로 항공모함 위치 표시 (에디터에서만)
        /// </summary>
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireCube(position + new Vector3(0, height / 2, 0),
                new Vector3(length, height, width));
            
            // 중심점 표시
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(position, 2f);
        }
    }
}
