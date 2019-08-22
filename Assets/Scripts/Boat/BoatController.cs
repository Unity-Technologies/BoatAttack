using System;
using UnityEngine;
using System.Collections;
using Cinemachine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace BoatAttack.Boat
{
    /// <summary>
    /// This is an overall controller for a boat
    /// </summary>
    public class BoatController : MonoBehaviour
    {
        //Boat stats
        public bool Human; // Is human
        public bool RandomizeColors = true;
        public Color PrimaryColor; // Boat primary colour
        public Color TrimColor; // Boat secondary colour
        public Renderer boatRenderer; // The renderer for the boat mesh
       
        public CinemachineVirtualCamera cam;
        
        void OnValidate()
        {
            Colourize(); // Update the colour material property block
        }


		void Awake()
		{
			Colourize();
		}
		// Use this for initialization
		void Start()
        {
            if (Human)
            {
                gameObject.AddComponent<HumanController>(); // Adds a human controller if human
            }
            else
            {
                gameObject.AddComponent<AIcontroller>(); // Adds an AI controller if AI
            }
        }

        /// <summary>
        /// This sets both the primary and secondary colour and assigns via a MPB
        /// </summary>
        void Colourize()
        {
            if (RandomizeColors)
                Randomize();
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

        void Randomize()
        {
            Random.InitState(this.gameObject.GetInstanceID() + DateTime.Now.Millisecond + DateTime.UtcNow.Second);

            var H = Random.Range(0f, 1f);
            var S = 0f;
            var V = 0.9f;
            
            var rand = Random.insideUnitCircle;

            if (rand.x > 0.5f)
                S = 0f;
            else
                S = 0.9f;
            
            if (rand.y > 0.8f)
                V = 0f;
            else
                V = Random.Range(0.5f, 0.9f);

            var h2 = Mathf.Repeat(H + (rand.x + rand.y > 0 ? 0.5f : 0f), 1f);
            var s2 = S <= 0.1f ? 0.9f : Random.Range(0.5f, 0.9f);
            
            PrimaryColor = Color.HSVToRGB(H, S, V);
            TrimColor = Color.HSVToRGB(h2, s2, 1f - V);
        }
    }

    [Serializable]
    public class BoatData
    {
        public string boatName;
        //public BoatType boatType = BoatType.Interceptor;
        public Object boatPrefab;
        public bool Human = false;
    }

    [Serializable]
    public enum BoatType
    {
        Interceptor,
        Classic,
    }
}
