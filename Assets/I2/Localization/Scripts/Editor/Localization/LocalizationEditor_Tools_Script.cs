using UnityEditor;
using UnityEngine;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace I2.Loc
{
	public partial class LocalizationEditor
	{
		#region Variables

		int Script_Tool_MaxVariableLength = 50;

		#endregion
		
		#region GUI Generate Script
		
		void OnGUI_Tools_Script()
		{
			OnGUI_KeysList (false, 200, false);

			//GUILayout.Space (5);
			
			GUI.backgroundColor = Color.Lerp (Color.gray, Color.white, 0.2f);
			GUILayout.BeginVertical(LocalizeInspector.GUIStyle_OldTextArea, GUILayout.Height(1));
			GUI.backgroundColor = Color.white;
			
			EditorGUILayout.HelpBox("This tool creates the ScriptLocalization.cs with the selected terms.\nThis allows for Compile Time Checking on the used Terms referenced in scripts", MessageType.Info);
			
			GUILayout.Space (5);

			GUILayout.BeginHorizontal ();
				GUILayout.FlexibleSpace();
				EditorGUIUtility.labelWidth = 240;
				EditorGUILayout.IntField("Max Length of the Generated Term IDs:", Script_Tool_MaxVariableLength);
				EditorGUIUtility.labelWidth = 0;
				GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();

			GUILayout.Space (10);
			
			GUILayout.BeginHorizontal ();
				GUILayout.FlexibleSpace();
                if (GUILayout.Button(new GUIContent("Select Baked Terms", "Selects all the terms previously built in ScriptLocalization.cs")))
                    SelectTermsFromScriptLocalization();

				if (GUILayout.Button("Build Script with Selected Terms"))
					EditorApplication.update += BuildScriptWithSelectedTerms;
				GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();
			
			GUILayout.EndVertical();
		}

        void SelectTermsFromScriptLocalization()
        {
            var ScriptFile = GetPathToGeneratedScriptLocalization();

            try
            {
                var text = System.IO.File.ReadAllText(ScriptFile, Encoding.UTF8);

                mSelectedKeys.Clear();
                foreach (Match match in Regex.Matches(text, "\".+\""))
                {
                    var term = match.Value.Substring(1, match.Value.Length - 2);

                    if (!mSelectedKeys.Contains(term))
                    {
                        mSelectedKeys.Add(term);
                    }
                }
            }
            catch(System.Exception)
            { }
        }

		#endregion

		#region Generate Script File

		void BuildScriptWithSelectedTerms()
		{
			EditorApplication.update -= BuildScriptWithSelectedTerms;
            var sbTrans = new StringBuilder();
            var sbTerms = new StringBuilder();
            sbTrans.AppendLine( "using UnityEngine;" );
            sbTrans.AppendLine();
            sbTrans.AppendLine( "namespace I2.Loc" );
            sbTrans.AppendLine( "{" );
            sbTrans.AppendLine( "	public static class ScriptLocalization" );
            sbTrans.AppendLine( "	{" );


            sbTerms.AppendLine();
            sbTerms.AppendLine("    public static class ScriptTerms");
            sbTerms.AppendLine("	{");



            BuildScriptWithSelectedTerms( sbTrans, sbTerms );
            sbTrans.AppendLine("	}");    // Closing both classes
            sbTerms.AppendLine("	}");


            string ScriptFile = GetPathToGeneratedScriptLocalization ();
			Debug.Log ("Generating: " + ScriptFile);

            var filePath = Application.dataPath + ScriptFile.Substring("Assets".Length);
            string fileText = sbTrans.ToString() + sbTerms.ToString() + "}";

            System.IO.File.WriteAllText(filePath, fileText, Encoding.UTF8);

			AssetDatabase.ImportAsset(ScriptFile);
		}

		static string GetPathToGeneratedScriptLocalization()
		{
			string[] assets = AssetDatabase.FindAssets("ScriptLocalization");
			if (assets.Length>0)
            {
                try
                {
                    string FilePath = AssetDatabase.GUIDToAssetPath(assets[0]);
                    return FilePath;
                }
                catch(System.Exception)
                { }
            }
            
			return "Assets/ScriptLocalization.cs";
        }

		void BuildScriptWithSelectedTerms( StringBuilder sbTrans, StringBuilder sbTerms )
		{
			List<string> Categories = LocalizationManager.GetCategories();
			foreach (string Category in Categories)
			{
				List<string> CategoryTerms = ScriptTool_GetSelectedTermsInCategory(Category);
				if (CategoryTerms.Count<=0)
					continue;

				List<string> AdjustedCategoryTerms = new List<string>(CategoryTerms);
				for (int i=0, imax=AdjustedCategoryTerms.Count; i<imax; ++i)
					AdjustedCategoryTerms[i] = ScriptTool_AdjustTerm( AdjustedCategoryTerms[i] );
				ScriptTool_EnumerateDuplicatedTerms(AdjustedCategoryTerms);

                sbTrans.AppendLine();
                sbTerms.AppendLine();
                if (Category != LanguageSourceData.EmptyCategory)
				{
                    sbTrans.AppendLine("		public static class " + ScriptTool_AdjustTerm(Category,true));
                    sbTrans.AppendLine("		{");

                    sbTerms.AppendLine("		public static class " + ScriptTool_AdjustTerm(Category, true));
                    sbTerms.AppendLine("		{");
                }

                BuildScriptCategory( sbTrans, sbTerms, Category, AdjustedCategoryTerms, CategoryTerms );

				if (Category != LanguageSourceData.EmptyCategory)
				{
                    sbTrans.AppendLine("		}");
                    sbTerms.AppendLine("		}");
                }
            }
		}

		List<string> ScriptTool_GetSelectedTermsInCategory( string Category )
		{
			List<string> list = new List<string>();
			foreach (string FullKey in mSelectedKeys)
			{
				string categ =  LanguageSourceData.GetCategoryFromFullTerm(FullKey);
				if (categ == Category && ShouldShowTerm(FullKey))
				{
					list.Add(  LanguageSourceData.GetKeyFromFullTerm(FullKey) );
				}
			}

			return list;
		}

		void BuildScriptCategory( StringBuilder sbTrans, StringBuilder sbTerms, string Category, List<string> AdjustedTerms, List<string> Terms )
		{
			if (Category==LanguageSourceData.EmptyCategory)
			{
                for (int i = 0; i < Terms.Count; ++i)
                {
                    sbTrans.AppendLine( "		public static string " + AdjustedTerms[i] + " \t\t{ get{ return LocalizationManager.GetTranslation (\"" + Terms[i] + "\"); } }");
                    sbTerms.AppendLine("		public const string " + AdjustedTerms[i] + " = \"" + Terms[i] + "\";");
                }
            }
			else
			for (int i=0; i<Terms.Count; ++i)
			{
				sbTrans.AppendLine("			public static string "+AdjustedTerms[i]+ " \t\t{ get{ return LocalizationManager.GetTranslation (\"" + Category+"/"+Terms[i]+"\"); } }");
                sbTerms.AppendLine("		    public const string " + AdjustedTerms[i] + " = \"" + Category + "/" + Terms[i] + "\";");
			}
		}

		string ScriptTool_AdjustTerm( string Term, bool allowFullLength = false )
		{
            Term = I2Utils.GetValidTermName(Term);

			// C# IDs can't start with a number
			if (I2Utils.NumberChars.IndexOf(Term[0])>=0)
				Term = "_"+Term;
			
			if (!allowFullLength && Term.Length>Script_Tool_MaxVariableLength)
				Term = Term.Substring(0, Script_Tool_MaxVariableLength);
			
			// Remove invalid characters
			char[] chars = Term.ToCharArray();
			for (int i=0, imax=chars.Length; i<imax; ++i)
				if (I2Utils.ValidChars.IndexOf(chars[i])<0)
					chars[i]='_';
			return new string(chars);
		}

		void ScriptTool_EnumerateDuplicatedTerms(List<string> AdjustedTerms)
		{
			string lastTerm = "$";
			int Counter = 1;
			for (int i=0, imax=AdjustedTerms.Count; i<imax; ++i)
			{
				string currentTerm = AdjustedTerms[i];
				if (lastTerm == currentTerm || (i<imax-1 && currentTerm==AdjustedTerms[i+1]))
				{
					AdjustedTerms[i] = AdjustedTerms[i] + "_" + Counter;
					Counter++;
				}
				else
					Counter = 1;

				lastTerm = currentTerm;
			}
		}

		#endregion
	}
}
