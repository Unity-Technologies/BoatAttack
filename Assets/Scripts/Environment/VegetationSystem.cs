using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

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

    [ContextMenu("FixPlacement")]
    void FixPlacement()
    {
        foreach (Transform child in transform)
        {
            Vector3 oldPos = Vector3.zero;
            Vector3 oldSize = Vector3.zero;
            Quaternion oldRot = Quaternion.identity;
            
            foreach (Transform lod in child)
            {
                if(lod.position.x != 0)
                {
                    oldPos = lod.localPosition;
                    oldSize = lod.localScale;
                    oldRot = lod.localRotation;
                    lod.localPosition = Vector3.zero;
                    lod.localRotation = Quaternion.identity;
                    lod.localScale = Vector3.one;
                }
                //PrefabUtility.ResetToPrefabState(lod);
                //PrefabUtility.ResetToPrefabState(lod.gameObject);
            }
            child.localPosition = oldPos;
            child.localRotation = oldRot;
            child.localScale = oldSize;
        }
    }

    [ContextMenu("Uniform Scale")]
    void SetUniformScale()
    {
        foreach (Transform child in transform)
        {
            float size = ((float)(Mathf.RoundToInt(child.localScale.x * 100))) / 100;
            child.localScale = Vector3.one * size;
        }
    }

}
