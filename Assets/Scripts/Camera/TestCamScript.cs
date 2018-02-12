using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TestCamScript : MonoBehaviour {
private bool oldCulling;
    public void OnPreRender()
    {
        oldCulling = GL.invertCulling;
        GL.invertCulling = true;
        Debug.Log("On pre render");
    }

    public void OnPostRender()
    {
        GL.invertCulling = oldCulling;
		Debug.Log("On post render");
    }
}
