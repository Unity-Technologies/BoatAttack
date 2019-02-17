using UnityEngine;
using System.Collections;

namespace BoatAttack.Boat
{
    /// <summary>
    /// This is an overall controller for a boat
    /// </summary>
    public class BoatController : MonoBehaviour
    {
        //Boat stats
        public bool Human; // Is human
        public Color PrimaryColor; // Boat primary colour
        public Color TrimColor; // Boat secondary colour
        public Renderer boatRenderer; // The renderer for the boat mesh

        void OnValidate()
        {
            Colourize(); // Update the colour material property block
        }

        // Use this for initialization
        void Start()
        {
            Colourize();
            if (Human == true)
                gameObject.AddComponent<HumanController>(); // Adds a human controller if human
            else
                gameObject.AddComponent<AIcontroller>(); // Adds an AI controller if AI
        }

        /// <summary>
        /// This sets both the primary and secondary colour and assigns via a MPB
        /// </summary>
        void Colourize()
        {
            if (boatRenderer)
            {
                if (Application.isEditor)
                {
                    MaterialPropertyBlock mpb = new MaterialPropertyBlock();
                    mpb.SetColor("_Color1", PrimaryColor);
                    mpb.SetColor("_Color2", TrimColor);
                    boatRenderer.SetPropertyBlock(mpb);
                }
                else
                {
                    boatRenderer.material.SetColor("_Color1", PrimaryColor);
                    boatRenderer.material.SetColor("_Color2", TrimColor);
                }
            }
        }
    }
}
