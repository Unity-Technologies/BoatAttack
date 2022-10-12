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
    
    public IEnumerator DemoCountdown()
    {
        var waitTime = idleTime;
            
        var listener = InputSystem.onEvent.Call(_ => waitTime = idleTime);

        while (waitTime > 0)
        {
            Debug.Log($"demo countdown {waitTime}");
            waitTime--;
            yield return new WaitForSeconds(1f);
        }
        listener.Dispose();
            
        RaceManager.SetGameType(RaceManager.GameType.Spectator);
        RaceManager.SetLevel(ref AppSettings.Instance.levels[0]);
        RaceManager.LoadGame();
    }
}
