using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class Instancer : MonoBehaviour
{
    public GameObject prefab;
    public float range = 50f;
    public bool randomRotation = true;
    public int count = 100;

    [ContextMenu("Spawn")]
    void Instance()
    {
        for (int i = 0; i < count; i++)
        {   
            var obj = PrefabUtility.InstantiatePrefab(prefab, transform) as GameObject;
            var randomCircle = Random.insideUnitCircle;
            var randomVec = Random.onUnitSphere;
            obj.transform.localPosition = new Vector3(randomCircle.x * range, 0f, randomCircle.y * range);
            if(randomRotation)
                obj.transform.rotation = Quaternion.Euler(randomVec.x * 5f, randomVec.y * 180f, randomVec.z * 5f);
        }
    }

    [ContextMenu("Delete All")]
    void DeleteAll()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            DestroyImmediate(transform.GetChild(0).gameObject);
        }
    }
}
