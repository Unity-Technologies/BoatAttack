using UnityEngine;

// This class is an example of how to setup a Popup with all the languages in NGUI

#if NGUI
namespace I2.Loc
{

    public class NGUI_LanguagePopup : MonoBehaviour 
	{
		public LanguageSource Source;

		void Start ()
		{
			UIPopupList mList = GetComponent<UIPopupList>();
			mList.items = Source.mSource.GetLanguages();

			EventDelegate.Add(mList.onChange, OnValueChange);
			int idx = mList.items.IndexOf(LocalizationManager.CurrentLanguage);
			mList.value = mList.items[idx>=0 ? idx : 0];
		}

		public void OnValueChange ()
		{
			LocalizationManager.CurrentLanguage = UIPopupList.current.value;
		}
	}
}
#endif