using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFramerateLock : MonoBehaviour
{
	public bool allowUmlimitedFPS = false;
	public int highEndFPS = 60;
	public float highEndFixedTimeStep = .02f;
	public int lowEndFPS = 30;
	public float lowEndFixedTimeStep = .033f;


    void Start()
    {
		int rate = 60;
		float physRate = .02f;
#if UNITY_STANDALONE || UNITY_EDITOR || UNITY_XBOXONE || UNITY_PS4
		rate = highEndFPS;
		physRate = highEndFixedTimeStep;
#else
		rate = lowEndFPS;
		physRate = lowEndFixedTimeStep;
#endif

		Time.fixedDeltaTime = physRate;

		if(!allowUmlimitedFPS)
			Application.targetFrameRate = rate;
	}
}
