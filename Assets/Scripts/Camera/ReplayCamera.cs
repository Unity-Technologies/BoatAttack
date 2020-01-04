using Cinemachine;
using UnityEngine;

namespace BoatAttack
{
    public class ReplayCamera : MonoBehaviour
    {
        public static ReplayCamera Instance;
        public CinemachineVirtualCamera droneCamera;

        private void OnEnable()
        {
            Instance = this;
        }

        public void EnableSpectatorMode(GameObject focus)
        {
            SetReplayTarget(focus);
            droneCamera.Priority = 100;
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
            droneCamera.Follow = target;
            droneCamera.LookAt = target;
        }
    }
}
