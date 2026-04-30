using UnityEngine;
using System.Collections;


namespace TMPro.Examples
{

    public class ObjectSpin : MonoBehaviour
    {
        #pragma warning disable 0414
        public enum MotionType { Rotation, SearchLight, Translation };
        public MotionType Motion;

        public Vector3 TranslationDistance = new Vector3(5, 0, 0);
        public float TranslationSpeed = 1.0f;
        public float SpinSpeed = 5;
        public int RotationRange = 15;
        private Transform m_transform;

        private float m_time;
        private Vector3 m_prevPOS;
        private Vector3 m_initial_Rotation;
        private Vector3 m_initial_Position;
        private Color32 m_lightColor;

        void Awake()
        {
            m_transform = transform;
            m_initial_Rotation = m_transform.rotation.eulerAngles;
            m_initial_Position = m_transform.position;

            Light light = GetComponent<Light>();
            m_lightColor = light != null ? light.color : Color.black;
        }


        // Update is called once per frame
        void Update()
        {
            switch (Motion)
            {
                case MotionType.Rotation:
                    m_transform.Rotate(0, SpinSpeed * Time.deltaTime, 0);
                    break;
                case MotionType.SearchLight:
                    m_time += SpinSpeed * Time.deltaTime;
                    m_transform.rotation = Quaternion.Euler(m_initial_Rotation.x, Mathf.Sin(m_time) * RotationRange + m_initial_Rotation.y, m_initial_Rotation.z);
                    break;
                case MotionType.Translation:
                    m_time += TranslationSpeed * Time.deltaTime;

                    float x = TranslationDistance.x * Mathf.Cos(m_time);
                    float y = TranslationDistance.y * Mathf.Sin(m_time) * Mathf.Cos(m_time * 1f);
                    float z = TranslationDistance.z * Mathf.Sin(m_time);

                    m_transform.position = m_initial_Position + new Vector3(x, z, y);

                    // Drawing light patterns because they can be cool looking.
                    //if (Time.frameCount > 1)
                    //    Debug.DrawLine(m_transform.position, m_prevPOS, m_lightColor, 100f);

                    m_prevPOS = m_transform.position;
                    break;
            }
        }
    }
}