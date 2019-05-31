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

        private void OnEnable()
        {
            RandomizeHUE();
        }

        private void OnValidate()
        {
            RandomizeHUE();
        }

        void RandomizeHUE()
        {
            float hue = Random.Range(0f, 1f);
            
            if (renderers != null || renderers.Length > 0)
            {
                for (int i = 0; i < renderers.Length; i++)
                {
                    if (renderers[i] != null)
                    {
                        // Set as MPB in editor but in playmode(runtime) create instance for SRP batcher to work
                        if (Application.isPlaying)
                        {
                            renderers[i].material.SetFloat("_Hue", hue);
                        }
                        else
                        {
                            MaterialPropertyBlock mtb = new MaterialPropertyBlock();
                            mtb.SetFloat("_Hue", hue);
                            renderers[i].SetPropertyBlock(mtb);
                        }
                    }
                }
            }
        }
    }
}
