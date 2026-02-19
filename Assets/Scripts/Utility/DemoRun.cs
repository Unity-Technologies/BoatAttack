using BoatAttack;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DemoRun : MonoBehaviour
{
    [Header("Auto Start Settings")]
    [Tooltip("레이스를 즉시 시작합니다 (대기 시간 없음)")]
    public bool startImmediately = true;
    
    [Tooltip("레이스 시작 대기 시간 (초)")]
    public float startDelay = 0f;

    private void Start()
    {
        StartCoroutine(SetupAndStartRace());
    }

    private IEnumerator SetupAndStartRace()
    {
        // RaceManager가 준비될 때까지 대기
        while (RaceManager.Instance == null)
        {
            yield return null;
        }

        // 레이스 설정 시작
        yield return StartCoroutine(RaceManager.SetupRace());

        // 즉시 시작 모드이거나 대기 시간이 0이면 바로 시작
        if (startImmediately || startDelay <= 0f)
        {
            // BeginRace()를 건너뛰고 바로 레이스 시작
            RaceManager.RaceStarted = true;
            RaceManager.raceStarted?.Invoke(true);
            Debug.Log("[DemoRun] 레이스 즉시 시작!");
        }
        else
        {
            // 지정된 시간만큼 대기 후 시작
            yield return new WaitForSeconds(startDelay);
            RaceManager.RaceStarted = true;
            RaceManager.raceStarted?.Invoke(true);
            Debug.Log($"[DemoRun] 레이스 시작 (대기 시간: {startDelay}초)");
        }
    }
}
