using UnityEngine;
using Unity.Mathematics;
using WaterSystem;

public class BuoyManager : MonoBehaviour
{
    private Transform[] buoys;
    private float3[] samplePoints; // sample points for height calc
    private float3[] heights; // water height array(only size of 1 when simple or non-physical)
    private float3[] normals; // water normal array(only used when non-physical and size of 1 also when simple)

    private int _guid;
    // Start is called before the first frame update
    void Start()
    {
        _guid = gameObject.GetInstanceID();

        buoys = new Transform[transform.childCount];
        samplePoints = new float3[buoys.Length];
        heights = new float3[buoys.Length];
        normals = new float3[buoys.Length];

        for (int i = 0; i < buoys.Length; i++)
        {
            buoys[i] = transform.GetChild(i);
            samplePoints[i] = buoys[i].position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        GerstnerWavesJobs.UpdateSamplePoints(samplePoints, _guid);
        GerstnerWavesJobs.GetData(_guid, ref heights, ref normals);
        
        for (int i = 0; i < buoys.Length; i++)
        {
            Vector3 vec  = buoys[i].position;
            vec.y = heights[i].y;
            buoys[i].position = vec;
            buoys[i].up = Vector3.Slerp(buoys[i].up, normals[i], Time.deltaTime);
        }
    }
}
