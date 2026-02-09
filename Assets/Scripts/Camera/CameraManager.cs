using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;
using UnityEngine.UI;
using Cinemachine;

namespace BoatAttack
{
	/// <summary>
	/// This is an overall camera manager for the demo(mainly for testing/debugging purposes) it hooks up to teh UI interface
	/// </summary>
    public class CameraManager : MonoBehaviour
    {
        public GameObject UI;
        public CameraModes _camModes;
        public PlayableDirector _cutsceneDirector;
        public List<CinemachineVirtualCamera> _cutsceneCameras = new List<CinemachineVirtualCamera>();
        public CinemachineVirtualCamera _droneCamera;
        public CinemachineVirtualCamera _raceCamera;
        public CinemachineClearShot _replayShots;
        public Text _staticCamText;
        private int _curStaticCam = 0;

        private void Start()
        {
            
        }

        private void Update()
        {
            Keyboard keyboard = Keyboard.current;
            if (keyboard == null) return;
            
            if (keyboard.spaceKey.wasPressedThisFrame)
            {
                if (_camModes == CameraModes.Cutscene)
                    StaticCams();
                else
                    PlayCutscene();
            }

            if (keyboard.leftArrowKey.wasPressedThisFrame)
                NextStaticCam();

            if (keyboard.rightArrowKey.wasPressedThisFrame)
                PrevStaticCam();

            // H 키 또는 터치 이벤트 (터치는 Input System에서 별도 처리 필요)
            if (keyboard.hKey.wasPressedThisFrame)
                UI.SetActive(!UI.activeSelf);
            
            // 터치 이벤트는 Touchscreen.current 사용 (필요시)
            // if (Touchscreen.current != null && Touchscreen.current.touches.Count > 0)
            // {
            //     var touch = Touchscreen.current.touches[0];
            //     if (touch.tapCount.ReadValue() == 2)
            //         UI.SetActive(!UI.activeSelf);
            // }
        }
        public void PlayCutscene()
        {
            _camModes = CameraModes.Cutscene;
            // Lower other camera priorities
            _droneCamera.Priority = 5;
            _raceCamera.Priority = 5;
            _replayShots.Priority = 5;
            // activate cutscene
            _cutsceneDirector.enabled = true;
            _cutsceneDirector.Stop();
            _cutsceneDirector.Play();
        }

        void DisableCutscene()
        {
            _cutsceneDirector.enabled = false;
            _cutsceneDirector.Stop();
        }

        public void DroneCam()
        {
            _camModes = CameraModes.Drone;
            // Lower other camera priorities
            DisableCutscene();
            _raceCamera.Priority = 5;
            _replayShots.Priority = 5;
            // activate drone
            _droneCamera.Priority = 15;
        }

        public void RaceCam()
        {
            _camModes = CameraModes.Race;
            // Lower other camera priorities
            DisableCutscene();
            _droneCamera.Priority = 5;
            _replayShots.Priority = 5;
            // activate drone
            _raceCamera.Priority = 15;
        }

        public void ReplayCam()
        {
            _camModes = CameraModes.Replay;
            // Lower other camera priorities
            DisableCutscene();
            _droneCamera.Priority = 5;
            _raceCamera.Priority = 5;
            // activate drone
            _replayShots.Priority = 15;
        }

        public void StaticCams()
        {
            _camModes = CameraModes.Static;
            // Lower other camera priorities
            DisableCutscene();
            _droneCamera.Priority = 5;
            _raceCamera.Priority = 5;
            _replayShots.Priority = 5;
            SetStaticCam(_curStaticCam);
        }

        public void NextStaticCam()
        {
            _curStaticCam++;
            if (_curStaticCam == _cutsceneCameras.Count)
                _curStaticCam = 0;
            SetStaticCam(_curStaticCam);
        }

        public void PrevStaticCam()
        {
            _curStaticCam--;
            if (_curStaticCam < 0)
                _curStaticCam = _cutsceneCameras.Count - 1;
            SetStaticCam(_curStaticCam);
        }

        void SetStaticCam(int cameraIndex)
        {
            for (var i = 0; i < _cutsceneCameras.Count; i++)
            {
                if (i != cameraIndex)
                {
                    _cutsceneCameras[i].Priority = 5;
                }
                else
                {
                    _cutsceneCameras[i].Priority = 11;
                    _staticCamText.text = _cutsceneCameras[i].gameObject.name.Substring(9);
                }
            }
        }

        public enum CameraModes
        {
            Cutscene,
            Race,
            Drone,
            Replay,
            Static
        }
    }
}
