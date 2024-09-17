using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Unity.Cinemachine;
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
        public Renderer boatRenderer; // The renderer for the boat mesh
        public Renderer engineRenderer; // The renderer for the boat mesh
        public Engine engine;
        private float _spawnHeight = 0f;

        // RaceStats
        [NonSerialized] public int Place = 0;
        [NonSerialized] public float LapPercentage;
        [NonSerialized] public int LapCount;
        [NonSerialized] public bool MatchComplete;
        [NonSerialized] private SortedSet<int> _completedCheckpointsThisLap;
        [NonSerialized] private SortedSet<int> _allCheckPoints;

        [NonSerialized] public readonly List<float> SplitTimes = new List<float>();

        public CinemachineCamera cam;
        private float _camFovVel;
        [NonSerialized] public RaceUI RaceUi;
        private Object _controller;
        private int _playerIndex;

        // Shader Props
        private static readonly int LiveryPrimary = Shader.PropertyToID("_Color1");
        private static readonly int LiveryTrim = Shader.PropertyToID("_Color2");

        // debug
        [SerializeField] internal bool debugControl = false;

        private void Awake()
		{
            if (debugControl)
            {
                Setup(1, true, RandomLivery());
            }
            _spawnHeight = transform.position.y;
            TryGetComponent(out engine.RB);
        }

        public void Setup(int player = 1, bool isHuman = true, BoatLivery livery = new BoatLivery())
        {
            _playerIndex = player - 1;
            cam.gameObject.layer = LayerMask.NameToLayer("Player" + player); // assign player layer
            SetupController(isHuman); // create or change controller
            Colorize(livery);
            _completedCheckpointsThisLap = new SortedSet<int>();
            _allCheckPoints = WaypointGroup.Instance.GetCheckpointIndices();
        }

        private void SwitchToAiController()
        {
            SetupController(false);
            (_controller as AiController)?.StartRace(true);
        }

        void SetupController(bool isHuman)
        {
            var controllerType = isHuman ? typeof(HumanController) : typeof(AiController);
            // If controller exists then make sure it's the right one, if not add it
            if (_controller)
            {
                if (_controller.GetType() == controllerType) return;
                Destroy(_controller);
            }
            _controller = gameObject.AddComponent(controllerType);
        }

        private void Update()
        {
            if (RaceManager.RaceStarted)
            {
                UpdateLaps();

                if (RaceUi)
                {
                    RaceUi.UpdatePlaceCounter(Place);
                    RaceUi.UpdateSpeed(engine.VelocityMag);
                }
            }
        }

        private void LateUpdate()
        {
            if (cam)
            {
                var fov = Mathf.SmoothStep(80f, 100f, engine.VelocityMag * 0.005f);
                cam.Lens.FieldOfView = Mathf.SmoothDamp(cam.Lens.FieldOfView, fov, ref _camFovVel, 0.5f);
            }
        }

        private void FixedUpdate()
        {
            if (!RaceManager.RaceStarted)
            {
                if(WaypointGroup.Instance) AlignBoatWithStartingLine();
            }
        }

        private void AlignBoatWithStartingLine()
        {
            // race not started, make sure to keep boat fairly aligned.
            var target = WaypointGroup.Instance.StartingPositions[_playerIndex];
            Vector3 targetPosition = target.GetColumn(3);
            Vector3 targetForward = target.GetColumn(2);
            var t = transform;
            var currentPosition = t.position;
            var currentForward = t.forward;

            targetPosition.y = currentPosition.y;
            engine.RB.AddForce((currentPosition - targetPosition) * 0.25f);

            engine.RB.MoveRotation(Quaternion.LookRotation(Vector3.Slerp(currentForward, targetForward, 0.1f * Time.fixedDeltaTime)));
        }

        private void UpdateLaps()
        {
            LapPercentage = WaypointGroup.Instance.GetPercentageAroundTrack(transform.position);
            if (RaceUi)
            {
                RaceUi.UpdateLapCounter(LapCount);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("waypoint") || MatchComplete) return;

            var wp = WaypointGroup.Instance.GetTriggersWaypoint(other as BoxCollider);
            EnteredWaypoint(wp);
        }

        private void EnteredWaypoint(WaypointGroup.Waypoint wp)
        {
            var wpIndex = WaypointGroup.Instance.GetWaypointIndex(wp);
            bool atStartLine = wpIndex == 0;
            bool lapZero = LapCount == 0;

            if (wp.isCheckpoint)
                _completedCheckpointsThisLap.Add(wpIndex);

            // Did lap finish ?
            if (atStartLine)
            {
                bool succesfulLap = _completedCheckpointsThisLap.SetEquals(_allCheckPoints) || (lapZero);
                _completedCheckpointsThisLap.Clear();
                if (!succesfulLap)
                    return;
                
                LapCount++;
                SplitTimes.Add(RaceManager.RaceTime);

                if (LapCount <= RaceManager.GetLapCount()) return;

                Debug.Log(
                    $"Boat {name} finished {RaceUI.OrdinalNumber(Place)} with time:{RaceUI.FormatRaceTime(SplitTimes.Last())}");
                RaceManager.BoatFinished(_playerIndex);
                if (_controller as HumanController != null)
                    SwitchToAiController();
                MatchComplete = true;
            }
        }

        [ContextMenu("Randomize")]
        private void ColorizeInvoke()
        {
            Colorize(RandomLivery());
        }

        private void Colorize(Color primaryColor, Color trimColor)
        {
            var livery = new BoatLivery
            {
                primaryColor = primaryColor,
                trimColor = trimColor
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
                var resetPoint = resetMatrix.GetPosition();
                resetPoint.y = _spawnHeight;
                engine.RB.linearVelocity = Vector3.zero;
                engine.RB.angularVelocity = Vector3.zero;
                engine.RB.position = resetPoint;
                engine.RB.rotation = resetMatrix.rotation;
            }
        }

        BoatLivery RandomLivery()
        {
            var livery = new BoatLivery
            {
                primaryColor = ConstantData.GetRandomPaletteColor,
                trimColor = ConstantData.GetRandomPaletteColor
            };
            return livery;
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
