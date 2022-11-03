using System;
using Cinemachine;
using UnityEngine;
using Random = UnityEngine.Random;

namespace BoatAttack
{
    public class ReplayCamera : MonoBehaviour
    {
        public static ReplayCamera Instance;
        private static bool _spectatorEnabled;
        private static BoatData _focusedBoat;
        private Transform _focusPoint;
        public CinemachineClearShot clearShot;
        public CinemachineVirtualCamera droneCam;
        private CinemachineTrackedDolly droneDolly;
        private CinemachinePathBase droneTrack;
        private ICinemachineCamera currentCam;
        private float timeSinceCut;

        private void OnEnable()
        {
            Instance = this;
            currentCam = clearShot.LiveChild;
            if (droneCam)
            {
                droneDolly = droneCam.GetCinemachineComponent<CinemachineTrackedDolly>();
                droneTrack = droneDolly.m_Path;
            }
        }

        private void LateUpdate()
        {
            if (_spectatorEnabled && _focusedBoat == null)
            {
                SetTarget(0);
            }

            if (timeSinceCut > 3f)
            {
                timeSinceCut = 0;
                clearShot.ResetRandomization();
            }

            if (currentCam != clearShot.LiveChild)
            {
                if (Random.value >= 0.5f) { SetRandomTarget(); }
                currentCam = clearShot.LiveChild;
            }

            timeSinceCut += Time.deltaTime;
        }

        public void EnableSpectatorMode()
        {
            _spectatorEnabled = true;
            SetRandomTarget();
        }

        public void DisableSpectatorMode()
        {
            _spectatorEnabled = false;
        }

        void SetRandomTarget() => SetTarget(Random.Range(0, RaceManager.RaceData.boatCount));

        public void SetTarget(int boatIndex)
        {
            _focusedBoat = RaceManager.RaceData.boats[boatIndex];
            if (_focusedBoat != null)
            {
                _focusPoint = _focusedBoat.BoatObject.transform;
                SetReplayTarget(_focusPoint);
            }
            else
            {
                DisableSpectatorMode();
            }
        }

        private void SetReplayTarget(GameObject go) => SetReplayTarget(go.transform);

        private void SetReplayTarget(Transform target)
        {
            if (!clearShot && target) return;
            clearShot.Priority = 100;
            clearShot.PreviousStateIsValid = false;
            clearShot.Follow = clearShot.LookAt = _focusPoint = target;
        }
    }
}
