using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFramerateLock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		//Basic for now. Replace with the platform logic
		Application.targetFrameRate = (int)(1f / Time.fixedDeltaTime);
	}
}
