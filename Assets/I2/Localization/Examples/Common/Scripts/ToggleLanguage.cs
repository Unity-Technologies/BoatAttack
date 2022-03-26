using UnityEngine;
using System.Collections.Generic;

namespace I2.Loc
{
	public class ToggleLanguage : MonoBehaviour 
	{
		void Start () 
		{
			Invoke("test", 3);
		}

		void test()
		{
			//--  to move into the next language ----

				List<string> languages = LocalizationManager.GetAllLanguages();
				int Index = languages.IndexOf(LocalizationManager.CurrentLanguage);
				if (Index<0)
					Index = 0;
				else
					Index = (Index+1) % languages.Count;

			//-- Call this function again in 3 seconds

				Invoke("test", 3);
		}
	}
}