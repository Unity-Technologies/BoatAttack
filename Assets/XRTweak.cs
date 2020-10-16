using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Management;


namespace BoatAttack
{
	public class XRTweak : MonoBehaviour
	{
		public Material BuiltinSky;
		public GameObject water;
		public GameObject waterXR;

		private static bool disableRaceUI = false;
		public static bool DisableRaceUI()
		{
			return disableRaceUI;
		}
		
		// Tweak project for XR		
		void Start()
		{
			if(XRGeneralSettings.Instance.InitManagerOnStart)
			{
				// URP XR requires built-in shader includes. Swap skybox material to use builtin skybox
				RenderSettings.skybox = BuiltinSky;
				
				// Disable Screenspace Canvas for XR because it is not supported.
				disableRaceUI = true;

				// Current planar reflection feature does not work in XR. Switch to cubemap
				water.SetActive(false);
				waterXR.SetActive(true);
			}
		}

		// Update is called once per frame
		void Update()
		{
			
		}
	}
}