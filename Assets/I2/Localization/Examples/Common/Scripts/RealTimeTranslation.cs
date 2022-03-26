using UnityEngine;
using System.Collections.Generic;

namespace I2.Loc
{
    public class RealTimeTranslation : MonoBehaviour
    {
        string OriginalText = "This is an example showing how to use the google translator to translate chat messages within the game.\nIt also supports multiline translations.",
               TranslatedText = string.Empty;
        bool IsTranslating = false;

        public void OnGUI()
        {
            GUILayout.Label("Translate:");
            OriginalText = GUILayout.TextArea(OriginalText, GUILayout.Width(Screen.width));

            GUILayout.Space(10);

            GUILayout.BeginHorizontal();
                if (GUILayout.Button("English -> Español", GUILayout.Height(100))) StartTranslating("en", "es");
                if (GUILayout.Button("Español -> English", GUILayout.Height(100))) StartTranslating("es", "en");
            GUILayout.EndHorizontal();

            GUILayout.Space(10);

            GUILayout.BeginHorizontal();
                GUILayout.TextArea("Multiple Translation with 1 call:\n'This is an example' -> en,zh\n'Hola' -> en");
                if (GUILayout.Button("Multi Translate", GUILayout.ExpandHeight(true))) ExampleMultiTranslations_Async();
            GUILayout.EndHorizontal();


            GUILayout.TextArea(TranslatedText, GUILayout.Width(Screen.width));

            GUILayout.Space(10);


            if (IsTranslating)
            {
                GUILayout.Label("Contacting Google....");
            }
        }

        public void StartTranslating(string fromCode, string toCode)
        {
            IsTranslating = true;

            // fromCode could be "auto" to autodetect the language
            GoogleTranslation.Translate(OriginalText, fromCode, toCode, OnTranslationReady);

            // can also use the ForceTranslate version: (it will block the main thread until the translation is returned)
            //var translation = GoogleTranslation.ForceTranslate(OriginalText, fromCode, toCode);
            //Debug.Log(translation);
        }

        void OnTranslationReady(string Translation, string errorMsg)
        {
            IsTranslating = false;

            if (errorMsg != null)
                Debug.LogError(errorMsg);
            else
                TranslatedText = Translation;
        }

        public void ExampleMultiTranslations_Blocking()
        {
            // This shows how to ask for many translations 
            var dict = new System.Collections.Generic.Dictionary<string, TranslationQuery>();
            GoogleTranslation.AddQuery("This is an example", "en", "es", dict);
            GoogleTranslation.AddQuery("This is an example", "auto", "zh", dict);
            GoogleTranslation.AddQuery("Hola", "es", "en", dict);

            if (!GoogleTranslation.ForceTranslate(dict))
                return;

            Debug.Log(GoogleTranslation.GetQueryResult("This is an example", "en", dict));
            Debug.Log(GoogleTranslation.GetQueryResult("This is an example", "zh", dict));
            Debug.Log(GoogleTranslation.GetQueryResult("This is an example", "", dict));  // This returns ANY translation of that text (in this case, the first one 'en')
            Debug.Log(dict["Hola"].Results[0]); // example of getting the translation directly from the Results
        }

        public void ExampleMultiTranslations_Async()
        {
            IsTranslating = true;

            // This shows how to ask for many translations 
            var dict = new Dictionary<string, TranslationQuery>();
            GoogleTranslation.AddQuery("This is an example", "en", "es", dict);
            GoogleTranslation.AddQuery("This is an example", "auto", "zh", dict);
            GoogleTranslation.AddQuery("Hola", "es", "en", dict);

            GoogleTranslation.Translate(dict, OnMultitranslationReady);
        }

        void OnMultitranslationReady(Dictionary<string, TranslationQuery> dict, string errorMsg)
        {
            if (!string.IsNullOrEmpty(errorMsg))
            {
                Debug.LogError(errorMsg);
                return;
            }

            IsTranslating = false;
            TranslatedText = "";

            TranslatedText += GoogleTranslation.GetQueryResult("This is an example", "es", dict) + "\n";
            TranslatedText += GoogleTranslation.GetQueryResult("This is an example", "zh", dict) + "\n";
            TranslatedText += GoogleTranslation.GetQueryResult("This is an example", "", dict) + "\n";    // This returns ANY translation of that text (in this case, the first one 'en')
            TranslatedText += dict["Hola"].Results[0];                                                    // example of getting the translation directly from the Results
        }

        #region This methods are used in the publisher's Unity Tests

        public bool IsWaitingForTranslation()
        {
            return IsTranslating;
        }

        public string GetTranslatedText()
        {
            return TranslatedText;
        }

        public void SetOriginalText( string text )
        {
            OriginalText = text;
        }

        #endregion

    }
}