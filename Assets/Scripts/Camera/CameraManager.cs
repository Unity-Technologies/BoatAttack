using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Cinemachine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour {

	public CameraModes _camModes;

	public PlayableDirector _cutsceneDirector;
	public List<CinemachineVirtualCamera> _cutsceneCameras = new List<CinemachineVirtualCamera>();
	public CinemachineVirtualCamera _droneCamera;
	public CinemachineVirtualCamera _raceCamera;
	public CinemachineClearShot _replayShots;
	public Text _staticCamText;
	private int _curStaticCam = 0;

	private void Start() {
		Application.targetFrameRate = 60;
	}

	public void PlayCutscene()
	{
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
		// Lower other camera priorities
		DisableCutscene();
		_raceCamera.Priority = 5;
		_replayShots.Priority = 5;
		// activate drone
		_droneCamera.Priority = 15;
	}

	public void RaceCam()
	{
		// Lower other camera priorities
		DisableCutscene();
		_droneCamera.Priority = 5;		
		_replayShots.Priority = 5;
		// activate drone
		_raceCamera.Priority = 15;
	}

	public void ReplayCam()
	{
		// Lower other camera priorities
		DisableCutscene();
		_droneCamera.Priority = 5;		
		_raceCamera.Priority = 5;
		// activate drone
		_replayShots.Priority = 15;
	}

	public void StaticCams()
	{
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
		if(_curStaticCam == _cutsceneCameras.Count)
			_curStaticCam = 0;
		SetStaticCam(_curStaticCam);
	}

	public void PrevStaticCam()
	{
		_curStaticCam--;
		if(_curStaticCam < 0)
			_curStaticCam = _cutsceneCameras.Count - 1;
		SetStaticCam(_curStaticCam);
	}

	void SetStaticCam(int cameraIndex)
	{
		for(var i = 0; i < _cutsceneCameras.Count; i++)
		{
			if(i != cameraIndex)
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
