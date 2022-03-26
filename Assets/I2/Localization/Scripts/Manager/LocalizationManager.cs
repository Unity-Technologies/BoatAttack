using UnityEngine;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Globalization;
using System.Collections;

namespace I2.Loc
{
    public static partial class LocalizationManager
    {

        #region Variables: Misc

        #endregion

        public static void InitializeIfNeeded()
        {
            #if UNITY_EDITOR
                #if UNITY_2017_2_OR_NEWER
                                UnityEditor.EditorApplication.playModeStateChanged -= OnEditorPlayModeStateChanged;
                                UnityEditor.EditorApplication.playModeStateChanged += OnEditorPlayModeStateChanged;
                #else
                            UnityEditor.EditorApplication.playmodeStateChanged -= OldOnEditorPlayModeStateChanged;
                            UnityEditor.EditorApplication.playmodeStateChanged += OldOnEditorPlayModeStateChanged;
                #endif
            #endif

            if (string.IsNullOrEmpty(mCurrentLanguage) || Sources.Count == 0)
            {
                AutoLoadGlobalParamManagers();
                UpdateSources();
                SelectStartupLanguage();
            }
        }

        public static string GetVersion()
		{
			return "2.8.13 f1";
		}

		public static int GetRequiredWebServiceVersion()
		{
			return 5;
		}

		public static string GetWebServiceURL( LanguageSourceData source = null )
		{
			if (source != null && !string.IsNullOrEmpty(source.Google_WebServiceURL))
				return source.Google_WebServiceURL;

            InitializeIfNeeded();
			for (int i = 0; i < Sources.Count; ++i)
				if (Sources[i] != null && !string.IsNullOrEmpty(Sources[i].Google_WebServiceURL))
					return Sources[i].Google_WebServiceURL;
			return string.Empty;
		}

#if UNITY_EDITOR
    #if UNITY_2017_2_OR_NEWER
        static void OnEditorPlayModeStateChanged( UnityEditor.PlayModeStateChange stateChange )
        {
            if (stateChange != UnityEditor.PlayModeStateChange.ExitingPlayMode)
                return;
    #else
        static void OldOnEditorPlayModeStateChanged()
        {
            if (UnityEditor.EditorApplication.isPlayingOrWillChangePlaymode)
                        return;
    #endif

            OnLocalizeEvent = null;

            foreach (var source in Sources)
            {
                source.LoadAllLanguages(true);
            }
            try
            {
                var tempPath = Application.temporaryCachePath;

                foreach (var file in System.IO.Directory.GetFiles(tempPath).Where(f => f.Contains("LangSource_") && f.EndsWith(".loc")))
                {
                    System.IO.File.Delete(file);
                }
            }
            catch(System.Exception)
            {
            }
        }
#endif
    }
}
