using UnityEngine;

namespace I2.Loc
{
	public class Example_ChangeLanguage : MonoBehaviour 
	{
		public void SetLanguage_English()
		{
			SetLanguage("English");
		}

		public void SetLanguage_French()
		{
			SetLanguage("French");
		}

		public void SetLanguage_Spanish()
		{
			SetLanguage("Spanish");
		}


		public void SetLanguage( string LangName )
		{
			if( LocalizationManager.HasLanguage(LangName))
			{
				LocalizationManager.CurrentLanguage = LangName;
			}
		}

	}
}