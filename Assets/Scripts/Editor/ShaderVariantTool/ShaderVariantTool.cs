using UnityEditor;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;

namespace GfxQA.ShaderVariantTool
{
    public class ShaderVariantTool : EditorWindow
    {
        Vector2 scrollPosition;

        public static string folderPath = "";
        public static string savedFile = "";
        
        //ColumnSetup
        Color columnColor1 = new Color(0.3f,0.3f,0.3f,1);
        Color columnColor2 = new Color(0.28f,0.28f,0.28f,1);
        float[] widthScale = new float[]
        {
            0, //we don't show shader name

            0.9f,
            1.8f,
            1f,

            1.5f,

            0.6f,
            0.8f,
            0.5f,

            0.8f,
    
            2.1f,
            0.5f,
            //0.5f,
            //0.5f,
            //0.5f,

            0.4f,
        };

        [MenuItem("Window/ShaderVariantTool")]
        public static void ShowWindow ()
        {
            var window = EditorWindow.GetWindow (typeof(ShaderVariantTool));
            window.name = "ShaderVariantTool";
            window.titleContent = new GUIContent("ShaderVariantTool");
        }

        // public void Awake()
        // {
        // }

        // public void OnDestroy()
        // {
        // }

        void OnGUI () 
        {
            Color originalBackgroundColor = GUI.backgroundColor;

            //Width for the columns & style
            float currentSize = this.position.width;
            float widthForEach = currentSize / (SVL.columns.Length-1+currentSize*0.0002f);
            GUIStyle background = new GUIStyle 
            { 
                normal = 
                { 
                    background = Texture2D.whiteTexture,
                    textColor = Color.white
                } 
            };

            //Title
            GUI.color = Color.cyan;
            GUILayout.Label ("Build the player and see the variants list here.", EditorStyles.wordWrappedLabel);
            ShaderVariantTool_BuildPreprocess.deletePlayerCacheBeforeBuild = GUILayout.Toggle(ShaderVariantTool_BuildPreprocess.deletePlayerCacheBeforeBuild,"Delete PlayerCache Before Build");
            GUILayout.Space(10);
            GUI.color = Color.white;

            if(savedFile != "")
            {
                GUI.color = Color.green;

                GUILayout.Label ( "Build Time: " + SVL.buildTimeString, EditorStyles.wordWrappedLabel );

                GUILayout.Space(5);

                //Result - Shader
                GUI.color = Color.white;
                GUILayout.Label ( "Shader" , EditorStyles.boldLabel );
                GUILayout.Label ( "Shader Count: " + SVL.normalShaderCount, EditorStyles.wordWrappedLabel );
                GUILayout.Label ( "Shader Variant Count before Stripping: " + SVL.variantBeforeStrippingCount, EditorStyles.wordWrappedLabel );
                GUILayout.Label ( "Shader Variant Count in Build: " + SVL.variantFromShader+  
                " (cached:" + SVL.variantInCache + " compiled:" + SVL.variantCompiledCount +")", EditorStyles.wordWrappedLabel );

                GUILayout.Space(5);

                //Result - ComputeShader
                GUI.color = Color.white;
                GUILayout.Label ( "ComputeShader" , EditorStyles.boldLabel );
                GUILayout.Label ( "ComputeShader Count: " + SVL.computeShaderCount, EditorStyles.wordWrappedLabel );
                GUILayout.Label ( "ComputeShader Variant Count in Build: " + SVL.variantFromCompute, EditorStyles.wordWrappedLabel );

                GUILayout.Space(10);

                //Saved file path
                GUI.color = Color.green;
                GUILayout.Label ( "Saved: "+savedFile, EditorStyles.wordWrappedLabel);

                //Show folder button
                GUI.color = Color.white;
                if (GUILayout.Button ("Show in explorer",GUILayout.Width(200)))
                {
                    EditorUtility.RevealInFinder(savedFile.Replace(@"/", @"\"));
                    //System.Diagnostics.Process.Start("explorer.exe", "/select,"+savedFile.Replace(@"/", @"\")); // explorer doesn't like front slashes
                }
            }
            GUI.color = Color.white;
            GUILayout.Space(15);

            //Column Titles
            EditorGUILayout.BeginHorizontal();
            for(int i=1;i<SVL.columns.Length;i++)
            {
                int al = i%2;
                GUI.backgroundColor = al ==0 ? columnColor1 :columnColor2;
                GUILayoutOption[] columnLayoutOption = new GUILayoutOption[]
                {
                    GUILayout.Width(Mathf.RoundToInt(widthForEach*widthScale[i])),
                    GUILayout.Height(55)
                };
                EditorGUILayout.LabelField (SVL.columns[i].Replace(" ","\n"),background,columnLayoutOption);
            }
            EditorGUILayout.EndHorizontal();

            //Reset color
            GUI.backgroundColor = originalBackgroundColor;
            GUI.color = Color.white;

            //Scroll Start
            scrollPosition = GUILayout.BeginScrollView(scrollPosition,GUILayout.Width(0),GUILayout.Height(0));      

            //Display result
            if(SVL.shaderlist.Count >0 && SVL.rowData.Count > 0)
            {
                for(int k=1; k < SVL.rowData.Count; k++) //first row is title so start with 1
                {
                    string shaderName = SVL.rowData[k][0];
                    int shaderIndex = SVL.shaderlist.FindIndex( o=> o.name == shaderName );
                    CompiledShader currentShader = SVL.shaderlist[shaderIndex];
                    
                    if(shaderName != SVL.rowData[k-1][0]) //show title
                    {
                        GUI.backgroundColor = originalBackgroundColor;
                        currentShader.guiEnabled = EditorGUILayout.Foldout( currentShader.guiEnabled, shaderName + " (" + currentShader.noOfVariantsForThisShader + ")" );
                        SVL.shaderlist[shaderIndex] = currentShader;
                    }

                    //Show the shader variants
                    if( currentShader.guiEnabled )
                    {
                        EditorGUILayout.BeginHorizontal();
                        for(int i=1;i<SVL.columns.Length;i++)
                        {
                            string t = SVL.rowData[k][i];

                            int al = i%2;
                            GUI.backgroundColor = al ==0 ? columnColor1 :columnColor2;
                            if(t == "True") background.normal.textColor = Color.green;
                            else if(t == "False") background.normal.textColor = Color.red;
                            else if(t.Contains("[Global]")) background.normal.textColor = Color.cyan;
                            else if(t.Contains("[Local]")) background.normal.textColor = Color.yellow;
                            else background.normal.textColor = Color.white;

                            EditorGUILayout.LabelField (t,background,GUILayout.Width(widthForEach*widthScale[i]));
                        }
                        EditorGUILayout.EndHorizontal();
                    }
                    GUI.backgroundColor = originalBackgroundColor;
                }
            }

            //Scroll End
            GUILayout.FlexibleSpace();
            GUILayout.EndScrollView();
            EditorGUILayout.Separator();
        }
    }
    //===================================================================================================
    public static class SVL
    {
        //build process indicators
        public static string buildProcessIDTitleStart = "ShaderVariantTool_Start:";
        public static string buildProcessIDTitleEnd = "ShaderVariantTool_End:";
        public static string buildProcessID = ""; //For recognising position in EditorLog
        public static bool buildProcessStarted = false;

        //the big total
        public static double buildTime = 0;
        public static string buildTimeString = "";
        public static int compiledTotalCount = 0; //The number of data that the tool processed
        public static int variantTotalCount = 0; //shader variant count + compute variant count

        //shader variant
        public static int variantBeforeStrippingCount = 0;
        public static int variantCompiledCount = 0;
        public static int variantInCache = 0;
        public static int normalShaderCount = 0;
        public static int variantFromShader = 0;

        //compute shader variant
        public static int variantFromCompute = 0;
        public static int computeShaderCount = 0;

        //invalid or disabled keywords for final error logging
        public static string invalidKey = "";
        public static string disabledKey = "";
        
        //data
        public static List<CompiledShaderVariant> variantlist = new List<CompiledShaderVariant>();
        public static List<CompiledShader> shaderlist = new List<CompiledShader>();
        public static List<string[]> rowData = new List<string[]>();
        public static string[] columns = new string[] 
        {
            "Shader",
            "PassType",
            "PassName",
            "ShaderType",
            "KernelName",
            "GfxTier",
            "Build Target",
            "Compiler Platform",
            //"Require",
            "Platform Keywords",
            "Keyword Name",
            "Keyword Type",
            //"Keyword Index",
            //"Keyword Valid",
            //"Keyword Enabled",
            "Compiled Count"
        };

        public static void ResetBuildList()
        {
            if(!buildProcessStarted)
            {
                shaderlist.Clear();
                variantlist.Clear();
                buildTime = 0;
                buildTimeString = "";
                compiledTotalCount = 0;
                variantTotalCount = 0;
                variantBeforeStrippingCount = 0;
                variantCompiledCount = 0;
                variantInCache = 0;
                variantFromCompute = 0;
                variantFromShader = 0;
                computeShaderCount = 0;
                normalShaderCount = 0;

                //For reading EditorLog, we can extract the contents
                buildProcessID = System.DateTime.Now.ToString("yyyyMMdd_hh-mm-ss");
                Debug.LogFormat(LogType.Log, LogOption.NoStacktrace, null, buildProcessIDTitleStart+buildProcessID);

                buildProcessStarted = true;
            }
        }

        public static void Sorting()
        {
            //sort the list according to shader name
            variantlist = variantlist.OrderBy(o=>o.shaderName).ThenBy(o=>o.shaderType).ThenBy(o=>o.shaderKeywordName).ToList();

            //Unique item and duplicate counts
            Dictionary<CompiledShaderVariant, int> uniqueSet = new Dictionary<CompiledShaderVariant, int>();

            //count duplicates
            for(int i=0; i<variantlist.Count; i++)
            {
                //is a duplicate
                if( uniqueSet.ContainsKey(variantlist[i]) )
                {
                    //add to duplicate count
                    uniqueSet[variantlist[i]]++;
                }
                //new unique item
                else
                {
                    //add to unique list
                    uniqueSet.Add(variantlist[i],1);
                }
            }

            //remove duplicates
            variantlist = variantlist.Distinct().ToList();

            //make string lists
            rowData.Clear();
            rowData.Add(columns);
            for(int k=0; k < variantlist.Count; k++)
            {
                rowData.Add(new string[] {
                    variantlist[k].shaderName,
                    variantlist[k].passType,
                    variantlist[k].passName,
                    variantlist[k].shaderType,
                    variantlist[k].kernelName,
                    variantlist[k].graphicsTier,
                    variantlist[k].buildTarget,
                    variantlist[k].shaderCompilerPlatform,
                    //variantlist[k].shaderRequirements,
                    variantlist[k].platformKeywords,
                    variantlist[k].shaderKeywordName,
                    variantlist[k].shaderKeywordType,
                    //variantlist[k].shaderKeywordIndex,
                    //variantlist[k].isShaderKeywordValid,
                    //variantlist[k].isShaderKeywordEnabled,
                    uniqueSet[variantlist[k]].ToString()});
            }

            //clean up
            variantlist.Clear();
        }
    }
    //===================================================================================================
    public struct CompiledShader
    {
        public string name;
        public bool guiEnabled;
        public int noOfVariantsForThisShader;
        public int editorLog_originalVariantCount;
        public int editorLog_remainingVariantCount;
        public int editorLog_compiledVariantCount;
        public int editorLog_variantInCacheCount;
        public float editorLog_totalProcessTime;
    };
    public struct CompiledShaderVariant
    {
        //shader
        public string shaderName;

        //snippet
        public string passType;
        public string passName;
        public string shaderType;

        //compute kernel
        public string kernelName;

        //data
        public string graphicsTier;
        public string buildTarget; 
        public string shaderCompilerPlatform;
        //public string shaderRequirements;

        //data - PlatformKeywordSet
        public string platformKeywords;
        //public string isplatformKeywordEnabled; //from PlatformKeywordSet

        //data - ShaderKeywordSet
        public string shaderKeywordName; //ShaderKeyword.GetKeywordName
        public string shaderKeywordType; //ShaderKeyword.GetKeywordType
        //public string shaderKeywordIndex; //ShaderKeyword.index
        //public string isShaderKeywordValid; //from ShaderKeyword.IsValid()
        //public string isShaderKeywordEnabled; //from ShaderKeywordSet
    };

}
