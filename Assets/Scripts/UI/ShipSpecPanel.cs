using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace BoatAttack
{
    /// <summary>
    /// 선박 재원 패널 - 아군/적군 선박 스펙 표시 및 슬라이더 편집
    /// 사진 참고: Max Speed, Fuel, Engine(RPM/Thruster), Rudder(Angle/Speed), Missile, Bullet
    /// </summary>
    public class ShipSpecPanel : MonoBehaviour
    {
        [Header("=== Mode ===")]
        [Tooltip("true면 적군 선박, false면 아군 선박")]
        public bool isEnemy = false;

        [Header("=== References ===")]
        public DefenseEnvController envController;

        [Header("=== Ship Parameter Sliders ===")]
        public Slider sliderMaxSpeed;
        public Text textMaxSpeed;

        public Slider sliderMaxThrust;
        public Text textMaxThrust;

        public Slider sliderMinRPM;
        public Text textMinRPM;

        public Slider sliderMaxRPM;
        public Text textMaxRPM;

        public Slider sliderMaxAngle;
        public Text textMaxAngle;

        public Slider sliderAngleSpeed;
        public Text textAngleSpeed;

        [Header("=== Display Only ===")]
        public Text textFuelPercent;
        public Text textMissileCount;
        public Text textBulletCount;

        [Header("=== Realtime Info ===")]
        public Text textCurrentSpeed;
        public Text textCurrentHeading;
        public Text textShipName;

        [Header("=== Ship Spec Defaults ===")]
        [Tooltip("연료 (표시용)")]
        public float fuelPercent = 100f;
        [Tooltip("미사일 수")]
        public int missileCount = 0;
        [Tooltip("탄환 수")]
        public int bulletCount = 0;

        // 캐싱된 엔진들
        private List<Engine> _engines = new List<Engine>();
        private List<Rigidbody> _rigidbodies = new List<Rigidbody>();
        private bool _listenersActive = false;

        private void OnEnable()
        {
            CacheTargetEngines();
            InitSliderValues();
            UpdateDisplayValues();
            BindListeners();
        }

        private void OnDisable()
        {
            UnbindListeners();
        }

        private void Update()
        {
            UpdateRealtimeInfo();
        }

        private void CacheTargetEngines()
        {
            _engines.Clear();
            _rigidbodies.Clear();
            if (envController == null) return;

            if (isEnemy)
            {
                if (envController.enemyShips != null)
                {
                    foreach (var enemy in envController.enemyShips)
                    {
                        if (enemy != null)
                        {
                            var eng = enemy.GetComponentInChildren<Engine>();
                            if (eng != null) _engines.Add(eng);
                            var rb = enemy.GetComponent<Rigidbody>();
                            if (rb != null) _rigidbodies.Add(rb);
                        }
                    }
                }
            }
            else
            {
                if (envController.defenseAgent1 != null)
                {
                    var eng = envController.defenseAgent1.GetComponentInChildren<Engine>();
                    if (eng != null) _engines.Add(eng);
                    var rb = envController.defenseAgent1.GetComponent<Rigidbody>();
                    if (rb != null) _rigidbodies.Add(rb);
                }
                if (envController.defenseAgent2 != null)
                {
                    var eng = envController.defenseAgent2.GetComponentInChildren<Engine>();
                    if (eng != null) _engines.Add(eng);
                    var rb = envController.defenseAgent2.GetComponent<Rigidbody>();
                    if (rb != null) _rigidbodies.Add(rb);
                }
            }
        }

        private void InitSliderValues()
        {
            float hp = 5800f;
            float st = 5f;
            float mass = 1000f;

            if (_engines.Count > 0 && _engines[0] != null)
            {
                hp = _engines[0].horsePower;
                st = _engines[0].steeringTorque;
            }
            if (_rigidbodies.Count > 0 && _rigidbodies[0] != null)
            {
                mass = _rigidbodies[0].mass;
            }

            // Max Speed (knots) = horsePower → 추정속도 (hp/200 근사)
            if (sliderMaxSpeed != null)
            {
                sliderMaxSpeed.minValue = 5f;
                sliderMaxSpeed.maxValue = 80f;
                sliderMaxSpeed.value = hp / 200f;
            }

            // Max Thrust = horsePower 직접
            if (sliderMaxThrust != null)
            {
                sliderMaxThrust.minValue = 1000f;
                sliderMaxThrust.maxValue = 15000f;
                sliderMaxThrust.value = hp;
            }

            // Min RPM (표시용)
            if (sliderMinRPM != null)
            {
                sliderMinRPM.minValue = 100f;
                sliderMinRPM.maxValue = 2000f;
                sliderMinRPM.value = 500f;
            }

            // Max RPM = horsePower 비례 (hp/4 근사)
            if (sliderMaxRPM != null)
            {
                sliderMaxRPM.minValue = 500f;
                sliderMaxRPM.maxValue = 5000f;
                sliderMaxRPM.value = hp / 4f;
            }

            // Max Angle = steeringTorque → 각도 (torque * 7 근사)
            if (sliderMaxAngle != null)
            {
                sliderMaxAngle.minValue = 5f;
                sliderMaxAngle.maxValue = 90f;
                sliderMaxAngle.value = st * 7f;
            }

            // Angle Speed = steeringTorque 직접
            if (sliderAngleSpeed != null)
            {
                sliderAngleSpeed.minValue = 1f;
                sliderAngleSpeed.maxValue = 20f;
                sliderAngleSpeed.value = st;
            }

            UpdateAllLabels();
        }

        private void UpdateDisplayValues()
        {
            if (textFuelPercent != null) textFuelPercent.text = $"{fuelPercent:F0}%";
            if (textMissileCount != null) textMissileCount.text = $"{missileCount}";
            if (textBulletCount != null) textBulletCount.text = $"{bulletCount}";
            if (textShipName != null) textShipName.text = isEnemy ? "ENEMY VESSEL" : "FRIENDLY VESSEL";
        }

        private void UpdateRealtimeInfo()
        {
            if (_rigidbodies.Count == 0) return;

            // 첫 번째 선박 기준 실시간 정보
            var rb = _rigidbodies[0];
            if (rb == null) return;

            float speedMs = rb.velocity.magnitude;
            float speedKnots = speedMs * 1.944f; // m/s → knots

            if (textCurrentSpeed != null)
                textCurrentSpeed.text = $"{speedKnots:F1} kn ({speedMs:F1} m/s)";

            if (textCurrentHeading != null)
                textCurrentHeading.text = $"{rb.transform.eulerAngles.y:F0}\u00b0";
        }

        #region Slider Listeners

        private void BindListeners()
        {
            if (_listenersActive) return;
            _listenersActive = true;

            if (sliderMaxSpeed != null) sliderMaxSpeed.onValueChanged.AddListener(OnMaxSpeedChanged);
            if (sliderMaxThrust != null) sliderMaxThrust.onValueChanged.AddListener(OnMaxThrustChanged);
            if (sliderMaxRPM != null) sliderMaxRPM.onValueChanged.AddListener(OnMaxRPMChanged);
            if (sliderMaxAngle != null) sliderMaxAngle.onValueChanged.AddListener(OnMaxAngleChanged);
            if (sliderAngleSpeed != null) sliderAngleSpeed.onValueChanged.AddListener(OnAngleSpeedChanged);
            if (sliderMinRPM != null) sliderMinRPM.onValueChanged.AddListener(OnMinRPMChanged);
        }

        private void UnbindListeners()
        {
            if (!_listenersActive) return;
            _listenersActive = false;

            if (sliderMaxSpeed != null) sliderMaxSpeed.onValueChanged.RemoveListener(OnMaxSpeedChanged);
            if (sliderMaxThrust != null) sliderMaxThrust.onValueChanged.RemoveListener(OnMaxThrustChanged);
            if (sliderMaxRPM != null) sliderMaxRPM.onValueChanged.RemoveListener(OnMaxRPMChanged);
            if (sliderMaxAngle != null) sliderMaxAngle.onValueChanged.RemoveListener(OnMaxAngleChanged);
            if (sliderAngleSpeed != null) sliderAngleSpeed.onValueChanged.RemoveListener(OnAngleSpeedChanged);
            if (sliderMinRPM != null) sliderMinRPM.onValueChanged.RemoveListener(OnMinRPMChanged);
        }

        private void OnMaxSpeedChanged(float value)
        {
            // knots → horsePower (value * 200)
            float hp = value * 200f;
            foreach (var eng in _engines)
                if (eng != null) eng.horsePower = hp;

            // 연동: Max Thrust, Max RPM 슬라이더도 업데이트
            if (sliderMaxThrust != null) sliderMaxThrust.SetValueWithoutNotify(hp);
            if (sliderMaxRPM != null) sliderMaxRPM.SetValueWithoutNotify(hp / 4f);
            UpdateAllLabels();
        }

        private void OnMaxThrustChanged(float value)
        {
            foreach (var eng in _engines)
                if (eng != null) eng.horsePower = value;

            if (sliderMaxSpeed != null) sliderMaxSpeed.SetValueWithoutNotify(value / 200f);
            if (sliderMaxRPM != null) sliderMaxRPM.SetValueWithoutNotify(value / 4f);
            UpdateAllLabels();
        }

        private void OnMinRPMChanged(float value)
        {
            if (textMinRPM != null) textMinRPM.text = $"{value:F0}";
        }

        private void OnMaxRPMChanged(float value)
        {
            // RPM → horsePower (value * 4)
            float hp = value * 4f;
            foreach (var eng in _engines)
                if (eng != null) eng.horsePower = hp;

            if (sliderMaxSpeed != null) sliderMaxSpeed.SetValueWithoutNotify(hp / 200f);
            if (sliderMaxThrust != null) sliderMaxThrust.SetValueWithoutNotify(hp);
            UpdateAllLabels();
        }

        private void OnMaxAngleChanged(float value)
        {
            // angle → steeringTorque (value / 7)
            float st = value / 7f;
            foreach (var eng in _engines)
                if (eng != null) eng.steeringTorque = st;

            if (sliderAngleSpeed != null) sliderAngleSpeed.SetValueWithoutNotify(st);
            UpdateAllLabels();
        }

        private void OnAngleSpeedChanged(float value)
        {
            foreach (var eng in _engines)
                if (eng != null) eng.steeringTorque = value;

            if (sliderMaxAngle != null) sliderMaxAngle.SetValueWithoutNotify(value * 7f);
            UpdateAllLabels();
        }

        #endregion

        private void UpdateAllLabels()
        {
            if (sliderMaxSpeed != null && textMaxSpeed != null)
                textMaxSpeed.text = $"{sliderMaxSpeed.value:F1} kn";
            if (sliderMaxThrust != null && textMaxThrust != null)
                textMaxThrust.text = $"{sliderMaxThrust.value:F0}";
            if (sliderMinRPM != null && textMinRPM != null)
                textMinRPM.text = $"{sliderMinRPM.value:F0}";
            if (sliderMaxRPM != null && textMaxRPM != null)
                textMaxRPM.text = $"{sliderMaxRPM.value:F0}";
            if (sliderMaxAngle != null && textMaxAngle != null)
                textMaxAngle.text = $"{sliderMaxAngle.value:F0}\u00b0";
            if (sliderAngleSpeed != null && textAngleSpeed != null)
                textAngleSpeed.text = $"{sliderAngleSpeed.value:F1}";
        }
    }
}
