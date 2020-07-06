using BoatAttack;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DemoRun : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(RaceManager.SetupRace());
    }
}
