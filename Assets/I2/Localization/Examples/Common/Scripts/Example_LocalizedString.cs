using UnityEngine;

namespace I2.Loc
{
    public class Example_LocalizedString : MonoBehaviour
    {
        public LocalizedString _MyLocalizedString;      // This string sets a Term in the inspector, but returns its translation

        public string _NormalString;                    // This is regular string to see that the LocalizedString has a custom inspector, but this shows only a textField

        [TermsPopup]
        public string _StringWithTermPopup;             // Example of making a normal string that show as a popup with all the terms in the inspector

        public void Start()
        {
            // LocalizedString are strings that can be set to a Term, and when getting its value, return the Term's translation

            // Basic Example of using LocalizedString in the Inspector
            // Just change the Term in the inspector, and use this to access the term translation
            Debug.Log(_MyLocalizedString);
            Debug.Log(LocalizationManager.GetTranslation(_NormalString));         // regular strings need to manually call GetTranslation()
            Debug.Log(LocalizationManager.GetTranslation(_StringWithTermPopup));  // same here, given that this string just have a custom inspector



            // Example of setting the term in code to get its translation
            LocalizedString locString = "Term2";
            string translation = locString;   // returns the translation of Term2 to the current language
            Debug.Log(translation);  



            // Assigning a LocalizedString to another LocalizedString, copies the reference to its term
            LocalizedString locString1 = _MyLocalizedString;
            Debug.Log(locString1);




            // LocalizedString have settings to customize the result

            LocalizedString customString = "Term3";
            Debug.Log(customString);

            LocalizedString customNoRTL = "Term3";
            customNoRTL.mRTL_IgnoreArabicFix = true;
            Debug.Log(customNoRTL);


            LocalizedString customString1 = "Term3";
            customString1.mRTL_ConvertNumbers = true;
            customString1.mRTL_MaxLineLength = 20;
            Debug.Log(customString1);




            // Copying a LocalizedString also copies its settings
            LocalizedString customStringCopy = customString1;
            Debug.Log(customStringCopy);
        }
    }
}