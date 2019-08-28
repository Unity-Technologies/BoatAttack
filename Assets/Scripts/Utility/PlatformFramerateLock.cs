using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFramerateLock : MonoBehaviour
{
	public int highEndRate = 60;
	public int highEndPhysRate = 60;
	public int lowEndRate = 30;
	public int lowEndPhysRate = 30;


    void Start()
    {
		int rate = 60;
		int physRate = 50;
#if UNITY_STANDALONE || UNITY_EDITOR || UNITY_XBOXONE || UNITY_PS4
		rate = highEndRate;
		physRate = highEndPhysRate;
#else
		rate = lowEndRate;
		physRate = lowEndPhysRate;
#endif

		Time.fixedDeltaTime = 1 / physRate;
		Application.targetFrameRate = 1 / rate;
	}
}
