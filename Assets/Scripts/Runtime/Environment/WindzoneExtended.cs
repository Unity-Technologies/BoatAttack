using UnityEngine;

[ExecuteAlways]
public class WindzoneExtended : MonoBehaviour
{
    public WindZone zone;
    // vector for wind, x = radian, y = strength, z = turbulence, w = frequency
    private Vector4 _windVector = Vector4.zero;
    public string shaderProp = "_WindZone_Vector";
    public float test;
    
    // Update is called once per frame
    void Update()
    {
        if (!zone) return;
        
        //Do Wind things
        SetDirection();
        
        Shader.SetGlobalVector(shaderProp, _windVector);
    }

    void SetDirection()
    {
        var vec = transform.forward;
        vec.y = 0;
        var sign = Vector3.Dot(Vector3.left, vec) < 0 ? -1f : 1f;
        _windVector.x = (Vector3.Angle(Vector3.forward, vec) / 180f * Mathf.PI) * sign;
        test = _windVector.x;
    }
}
