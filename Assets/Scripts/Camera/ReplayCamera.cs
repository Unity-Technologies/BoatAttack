using System;
using Cinemachine;
using UnityEngine;

namespace BoatAttack
{
    public class ReplayCamera : MonoBehaviour
    {
        public static ReplayCamera Instance;
        private static bool _spectatorEnabled;
        private static BoatData _focusedBoat;
        private Transform _focusPoint;
        public CinemachineVirtualCamera droneCamera;
        //public CinemachineVirtualCamera[] levelCameras;
        public CinemachineClearShot clearShot;

        private void OnEnable()
        {
            Instance = this;
        }

        private void LateUpdate()
        {
            if (_spectatorEnabled && _focusedBoat == null)
            {
                _focusedBoat = RaceManager.RaceData.boats[0];
                _focusPoint = _focusedBoat.BoatObject.transform;
                SetReplayTarget(_focusPoint);
            }
        }

        public void EnableSpectatorMode()
        {
            _spectatorEnabled = true;
            //droneCamera.Priority = 100;
        }

        public void DisableSpectatorMode()
        {
            droneCamera.Priority = -100;
        }

        private void SetReplayTarget(GameObject go)
        {
            SetReplayTarget(go.transform);
        }

        private void SetReplayTarget(Transform target)
        {
            _focusPoint = target;
            
            if (clearShot)
            {
                clearShot.Priority = 100;
                clearShot.LookAt = _focusPoint;
            }
            
            droneCamera.Follow = _focusPoint;
            droneCamera.LookAt = _focusPoint;
        }
    }
}
