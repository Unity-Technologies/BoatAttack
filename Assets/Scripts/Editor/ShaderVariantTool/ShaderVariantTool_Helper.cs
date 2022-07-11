using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using System;
using System.IO;

namespace GfxQA.ShaderVariantTool
{
    public static class Helper
    {
        public static string TimeFormatString (double timeInSeconds)
        {
            float t = (float)timeInSeconds;

            float hour = t / 3600f;
            hour = Mathf.Floor(hour);
            t -= hour*3600f;

            float minute = t / 60f;
            minute = Mathf.Floor(minute);
            t -= minute*60f;

            float second = t;

            string timeString = "";

            if(hour > 0) timeString += hour + "hr ";
            if(minute > 0) timeString += minute + "m ";
            timeString += second.ToString("0.0") + "s";

            return timeString;
        }

        public static string GetRemainingString(string line, string from)
        {
            int index = line.IndexOf(from) + from.Length;
            return line.Substring( index , line.Length - index);
        }

        public static string ExtractString(string line, string from, string to, bool takeLastIndexOfTo = true)
        {
            int pFrom = 0;
            if(from != "")
            {
                int index = line.IndexOf(from);
                if(index >= 0) pFrom = index + from.Length;
            }
            
            int pTo = line.Length;
            if(to != "")
            {
                int index = line.LastIndexOf(to);
                if(!takeLastIndexOfTo)
                {
                    index = line.IndexOf(to);
                }

                if(index >= 0) pTo = index;
            }

            return line.Substring(pFrom, pTo - pFrom);
        }

        public static void DebugLog(string msg)
        {
            Debug.LogFormat(LogType.Log, LogOption.NoStacktrace, null, msg);
        }

        public static string GetPlatformKeywordList(PlatformKeywordSet pks)
        {
            string enabledPKeys = "";
            foreach(BuiltinShaderDefine sd in System.Enum.GetValues(typeof(BuiltinShaderDefine))) 
            {
                //Only pay attention to SHADER_API_MOBILE, SHADER_API_DESKTOP and SHADER_API_GLES30
                if( sd.ToString().Contains("SHADER_API") && pks.IsEnabled(sd) )
                {
                    if(enabledPKeys != "") enabledPKeys += " ";
                    enabledPKeys += sd.ToString();
                }
            }
            return enabledPKeys;
        }

        public static string GetEditorLogPath()
        {
            string editorLogPath = "";
            switch(Application.platform)
            {
                case RuntimePlatform.WindowsEditor: editorLogPath=Environment.GetEnvironmentVariable("AppData").Replace("Roaming","")+"Local\\Unity\\Editor\\Editor.log"; break;
                case RuntimePlatform.OSXEditor: editorLogPath=Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Library")+"/Logs/Unity/Editor.log"; break;
                case RuntimePlatform.LinuxEditor: editorLogPath="~/.config/unity3d/Editor.log"; break;
            }
            return editorLogPath;
        }
    }
}