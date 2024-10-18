using UnityEngine;
using Unity.Cinemachine;

public class BenchmarkPath : MonoBehaviour
{
    public CinemachineCamera cam;
    CinemachineSplineDolly dolly;

    public int frameLength = 2000;

    private void OnEnable()
    {
        dolly = cam.GetComponent<CinemachineSplineDolly>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dolly)
        {
            dolly.SplineSettings.Position += 1f / frameLength;
            dolly.SplineSettings.Position = Mathf.Repeat(dolly.SplineSettings.Position, 1f);
        }
    }
}
