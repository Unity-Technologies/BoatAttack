using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegetationSystem : MonoBehaviour {

    MaterialPropertyBlock props;

    void Start()
    {
		props = new MaterialPropertyBlock();
        SetProperties(transform);
    }

	void SetProperties(Transform t)
	{
		MeshRenderer rend;
		foreach (Transform child in t)
        {
            rend = child.gameObject.GetComponent<MeshRenderer>();
            if (rend)
            {
				props.SetVector("_Position", child.position);
                rend.SetPropertyBlock(props);
            }
			if(child.childCount > 0)
                SetProperties(child);
        }
	}

}
