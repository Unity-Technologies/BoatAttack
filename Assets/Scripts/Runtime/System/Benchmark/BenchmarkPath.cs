using System;
using UnityEngine;
using Cinemachine;

public class BenchmarkPath : MonoBehaviour
{
    public CinemachineVirtualCamera cam;
    CinemachineTrackedDolly dolly;

    public int frameLength = 2000;

    private void OnEnable()
    {
        dolly = cam.GetCinemachineComponent<CinemachineTrackedDolly>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dolly)
        {
            dolly.m_PathPosition += 1f / frameLength;
            dolly.m_PathPosition = Mathf.Repeat(dolly.m_PathPosition, 1f);
        }
    }
}
