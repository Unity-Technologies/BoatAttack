using UnityEngine;
using System.Collections;
using UnityEngine.Experimental.Rendering;

namespace BoatAttack
{
    public class AppSettings : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {
            Application.targetFrameRate = 60;
        }
    }
}
