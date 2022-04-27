using UnityEngine;

public class SpinLoad : MonoBehaviour
{
    public bool active = false;
    Vector3 rand1, rand2;
    void Update()
    {
        if (!active)
            return;

        rand1 = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1));
        rand2 = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1));
        transform.Rotate(Vector3.Cross(rand1, rand2));
    }
}
