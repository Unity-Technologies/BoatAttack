using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoatAttack
{
    /// <summary>
    /// Simple scripts sets a random HUE on a shader with the property '_Hue'
    /// </summary>
    public class RandomHue : MonoBehaviour
    {
        public MeshRenderer[] renderers;
        void OnValidate()
        {
            float hue = Random.Range(0f, 1f);
            MaterialPropertyBlock mtb = new MaterialPropertyBlock();
            mtb.SetFloat("_Hue", hue);

            if (renderers.Length > 0)
            {
                for (int i = 0; i < renderers.Length; i++)
                {
                    renderers[i].SetPropertyBlock(mtb);
                }
                
            }
        }
    }
}
