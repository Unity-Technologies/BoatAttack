using System;
using System.Collections;
using BoatAttack;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class DemoRun : MonoBehaviour
{
    public bool autoRun = true;
    public bool timedRun = false;
    public int idleTime = 30;
    private int waitTime;

    private IDisposable m_EventListener;
    
    private void Start()
    {
        if (autoRun)
        {
            StartCoroutine(RaceManager.SetupRace());
        }

        if (timedRun)
        {
            StartCoroutine(DemoCountdown());
        }
    }

    private void OnDisable()
    {
        m_EventListener?.Dispose();
    }

    public IEnumerator DemoCountdown()
    {
        waitTime = idleTime;
            
        m_EventListener = InputSystem.onAnyButtonPress.Call(ResetWaitTime);

        while (waitTime > 0)
        {
            Debug.Log($"demo countdown {waitTime}");
            if (Pointer.current.delta.EvaluateMagnitude() > 0.1f)
                waitTime = idleTime;
            waitTime--;
            yield return new WaitForSeconds(1f);
        }
        m_EventListener.Dispose();
            
        RaceManager.SetGameType(RaceManager.GameType.Spectator);
        RaceManager.SetLevel(ref AppSettings.Instance.levels[0]);
        RaceManager.LoadGame();
    }

    private void ResetWaitTime(InputControl _)
    {
        waitTime = idleTime;
    }
}
