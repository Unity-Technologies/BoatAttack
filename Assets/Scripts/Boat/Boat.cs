using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Cinemachine;
using BoatAttack.UI;
using Object = UnityEngine.Object;

namespace BoatAttack
{
    /// <summary>
    /// This is an overall controller for a boat
    /// </summary>
    public class Boat : MonoBehaviour
    {
        // Boat stats
        public bool human; // Is human
        public Renderer boatRenderer; // The renderer for the boat mesh
        public Renderer engineRenderer; // The renderer for the boat mesh
        public Engine engine;
        private Matrix4x4 _spawnPosition;
        
        // RaceStats
        [NonSerialized] public float LapPercentage;
        [NonSerialized] public int LapCount;
        [NonSerialized] public int Place = 0;
        private int _wpCount = -1;

        [NonSerialized] public float TotalTime;
        [NonSerialized] public readonly List<float> SplitTimes = new List<float>();
        
        public CinemachineVirtualCamera cam;
        public float camFovVel;
        [NonSerialized] public RaceUI RaceUi;
        private Object _controller;
        
        // Shader Props
        private static readonly int LiveryPrimary = Shader.PropertyToID("_Color1");
        private static readonly int LiveryTrim = Shader.PropertyToID("_Color2");

        void Awake()
		{
            _spawnPosition = transform.localToWorldMatrix;
            TryGetComponent(out engine.RB);
        }

        public void Setup(int player = 1, bool isHuman = true, BoatLivery livery = new BoatLivery())
        {
            cam.gameObject.layer = LayerMask.NameToLayer("Player" + player); // assign player layer
            SetupController(isHuman); // create or change controller
            Colorize(livery);
        }

        void SetupController(bool isHuman)
        {
            var controllerType = isHuman ? typeof(HumanController) : typeof(AiController);
            // If controller exists then make sure it's teh right one, if not add it
            if (_controller)
            {
                if (_controller.GetType() == controllerType) return;
                Destroy(_controller);
                _controller = gameObject.AddComponent(controllerType);
            }
            else
            {
                _controller = gameObject.AddComponent(controllerType);
            }
        }

        private void LateUpdate()
        {
            TotalTime = Time.time;
            
            UpdateLaps();
            
            if (RaceUi)
            {
                RaceUi.UpdatePlaceCounter(Place);
                RaceUi.UpdateSpeed(engine.VelocityMag);
            }

            if (cam)
            {
                var fov = Mathf.SmoothStep(80f, 100f, engine.VelocityMag * 0.005f);
                cam.m_Lens.FieldOfView = Mathf.SmoothDamp(cam.m_Lens.FieldOfView, fov, ref camFovVel, 0.5f);
            }
        }

        private void UpdateLaps()
        {
            LapPercentage = (float)_wpCount / WaypointGroup.Instance.WPs.Count;
            LapPercentage += WaypointGroup.Instance.GetCurrentSegmentPercentage(_wpCount, transform.position) /
                             WaypointGroup.Instance.WPs.Count;
            
            if (RaceUi)
            {
                RaceUi.UpdateLapCounter(LapCount);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("waypoint"))
            {
                var wp = WaypointGroup.Instance.GetTriggersWaypoint(other as BoxCollider);
                var wpIndex = WaypointGroup.Instance.GetWaypointIndex(wp);
                EnteredWaypoint(wpIndex);
            }
        }

        private void EnteredWaypoint(int index)
        {
            var count = WaypointGroup.Instance.WPs.Count;
            var nextWp = (int) Mathf.Repeat(_wpCount + 1, count);

            if (nextWp != index) return;
            _wpCount = nextWp;
            if (index != 0) return;
            LapCount++;
            if(LapCount > 1) SplitTimes.Add(TotalTime);
        }

        [ContextMenu("Randomize")]
        private void ColorizeInvoke()
        {
            Colorize(Color.black, Color.black, true);
        }

        private void Colorize(Color primaryColor, Color trimColor, bool random = false)
        {
            var livery = new BoatLivery
            {
                primaryColor = random ? ConstantData.GetRandomPaletteColor : primaryColor,
                trimColor = random ? ConstantData.GetRandomPaletteColor : trimColor
            };
            Colorize(livery);
        }

        /// <summary>
        /// This sets both the primary and secondary colour and assigns via a MPB
        /// </summary>
        private void Colorize(BoatLivery livery)
        {
            boatRenderer?.material?.SetColor(LiveryPrimary, livery.primaryColor);
            engineRenderer?.material?.SetColor(LiveryPrimary, livery.primaryColor);
            boatRenderer?.material?.SetColor(LiveryTrim, livery.trimColor);
            engineRenderer?.material?.SetColor(LiveryTrim, livery.trimColor);
        }

        public void ResetPosition()
        {
            if (WaypointGroup.Instance)
            {
                var resetMatrix = WaypointGroup.Instance.GetClosestPointOnWaypoint(transform.position);
                var resetPoint = resetMatrix.GetColumn(3);
                resetPoint.y = _spawnPosition.GetColumn(3).y;
                engine.RB.velocity = Vector3.zero;
                engine.RB.angularVelocity = Vector3.zero;
                engine.RB.position = resetPoint;
                engine.RB.rotation = resetMatrix.rotation;
            }
        }
    }

    [Serializable]
    public class BoatData
    {
        public string boatName;
        public AssetReference boatPrefab;
        public BoatLivery livery;
        public bool human;
        [NonSerialized] public Boat Boat;
        [NonSerialized] public GameObject BoatObject;

        public void SetController(GameObject boat, Boat controller)
        {
            BoatObject = boat;
            this.Boat = controller;
        }
    }

    [Serializable]
    public struct BoatLivery
    {
        [ColorUsage(false)] public Color primaryColor;
        [ColorUsage(false)] public Color trimColor;
    }
}
