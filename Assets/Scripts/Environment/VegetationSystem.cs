using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace BoatAttack
{
    public class VegetationSystem : MonoBehaviour
    {
        MaterialPropertyBlock props; // material propery block for instance value setting

        void Start()
        {
            props = new MaterialPropertyBlock();
            SetProperties(transform);
        }

        /// <summary>
        /// Sets the properties for the vegetations shader
        /// </summary>
        /// <param name="t">Transform to use</param>
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
                if (child.childCount > 0)
                    SetProperties(child);
            }
        }
    }
}
