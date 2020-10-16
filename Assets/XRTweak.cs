using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Management;


namespace BoatAttack
{
	public class XRTweak : MonoBehaviour
	{
		public Material BuiltinSky;
		private static bool disableRaceUI = false;
		public static bool DisableRaceUI()
		{
			return disableRaceUI;
		}

				
		// Start is called before the first frame update
		void Start()
		{
			if(XRGeneralSettings.Instance.InitManagerOnStart)
			{
				// URP XR requires built-in shader includes. Swap skybox material to use builtin skybox
				RenderSettings.skybox = BuiltinSky;
				
				// Disable Screenspace Canvas for XR because it is not supported.
				disableRaceUI = true;
			}
		}

		// Update is called once per frame
		void Update()
		{
			
		}
	}
}