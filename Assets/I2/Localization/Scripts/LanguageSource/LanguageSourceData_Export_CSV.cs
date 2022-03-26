using UnityEngine;
using System.Text;

namespace I2.Loc
{
	public partial class LanguageSourceData
	{
		#region I2CSV format

		public string Export_I2CSV( string Category, char Separator = ',', bool specializationsAsRows=true )
		{
			StringBuilder Builder = new StringBuilder ();

			//--[ Header ]----------------------------------
			Builder.Append ("Key[*]Type[*]Desc");
			foreach (LanguageData langData in mLanguages)
			{
				Builder.Append ("[*]");
				if (!langData.IsEnabled())
					Builder.Append('$');
				Builder.Append ( GoogleLanguages.GetCodedLanguage(langData.Name, langData.Code) );
			}
			Builder.Append ("[ln]");
			
			mTerms.Sort((a, b) => string.CompareOrdinal(a.Term, b.Term));

			int nLanguages = (mLanguages.Count);
			bool firstLine = true;
			foreach (TermData termData in mTerms)
			{
				string Term;
				
				if (string.IsNullOrEmpty(Category) || (Category==EmptyCategory && termData.Term.IndexOfAny(CategorySeparators)<0))
					Term = termData.Term;
				else
					if (termData.Term.StartsWith(Category + @"/") && Category!=termData.Term)
						Term = termData.Term.Substring(Category.Length+1);
				else
					continue;   // Term doesn't belong to this category


				if (!firstLine) Builder.Append("[ln]");
                firstLine = false;

                if (!specializationsAsRows)
                {
                    AppendI2Term(Builder, nLanguages, Term, termData, Separator, null);
                }
                else
                {
                    var allSpecializations = termData.GetAllSpecializations();
                    for (int i=0; i< allSpecializations.Count; ++i)
                    {
                        if (i!=0)
                            Builder.Append("[ln]");
                        var specialization = allSpecializations[i];
                        AppendI2Term(Builder, nLanguages, Term, termData, Separator, specialization);
                    }
                }

            }
            return Builder.ToString();
		}

		static void AppendI2Term( StringBuilder Builder, int nLanguages, string Term, TermData termData, char Separator, string forceSpecialization )
		{
            //--[ Key ] --------------
            AppendI2Text(Builder, Term);
            if (!string.IsNullOrEmpty(forceSpecialization) && forceSpecialization != "Any")
            {
                Builder.Append("[");
                Builder.Append(forceSpecialization);
                Builder.Append("]");
            }
            Builder.Append ("[*]");

			//--[ Type and Description ] --------------
			Builder.Append (termData.TermType.ToString());
			Builder.Append ("[*]");
			Builder.Append (termData.Description);

			//--[ Languages ] --------------
			for (int i=0; i<Mathf.Min (nLanguages, termData.Languages.Length); ++i)
			{
				Builder.Append ("[*]");
				
				string translation = termData.Languages[i];
                if (!string.IsNullOrEmpty(forceSpecialization))
                    translation = termData.GetTranslation(i, forceSpecialization);

                //bool isAutoTranslated = ((termData.Flags[i]&FlagBitMask)>0);

                /*if (translation == null)
                    translation = string.Empty;
                else
                if (translation == "")
                	translation = "-";*/
                //if (isAutoTranslated) Builder.Append("[i2auto]");
                AppendI2Text(Builder, translation);
			}
		}

        static void AppendI2Text(StringBuilder Builder, string text)
        {
            if (string.IsNullOrEmpty(text))
                return;

            if (text.StartsWith("\'") || text.StartsWith("="))
                Builder.Append('\'');
            Builder.Append(text);
        }


        #endregion

        #region Language Cache format

        string Export_Language_to_Cache( int langIndex, bool fillTermWithFallback )
        {
            if (!mLanguages[langIndex].IsLoaded())
                return null;

            StringBuilder sb = new StringBuilder();

            for (int i=0; i<mTerms.Count; ++i)
            {
                if (i > 0)
                    sb.Append("[i2t]");
                var term = mTerms[i];
                sb.Append(term.Term);
                sb.Append("=");

                string translation = term.Languages[langIndex];
                if (OnMissingTranslation==MissingTranslationAction.Fallback && string.IsNullOrEmpty(translation))
                {
                    if (TryGetFallbackTranslation(term, out translation, langIndex, skipDisabled: true))
                    {
                        sb.Append("[i2fb]");
                        if (fillTermWithFallback) term.Languages[langIndex] = translation;
                    }
                }
                if (!string.IsNullOrEmpty(translation))
                    sb.Append(translation);
            }

            return sb.ToString();
        }

        #endregion

        #region CSV format

        public string Export_CSV( string Category, char Separator = ',', bool specializationsAsRows = true)
		{
			StringBuilder Builder = new StringBuilder();
			
			int nLanguages = (mLanguages.Count);
			Builder.AppendFormat ("Key{0}Type{0}Desc", Separator);

			foreach (LanguageData langData in mLanguages)
			{
				Builder.Append (Separator);
				if (!langData.IsEnabled())
					Builder.Append('$');
				AppendString ( Builder, GoogleLanguages.GetCodedLanguage(langData.Name, langData.Code), Separator );
			}
			Builder.Append ("\n");


            mTerms.Sort((a, b) => string.CompareOrdinal(a.Term, b.Term));

			foreach (TermData termData in mTerms)
			{
				string Term;

				if (string.IsNullOrEmpty(Category) || (Category==EmptyCategory && termData.Term.IndexOfAny(CategorySeparators)<0))
					Term = termData.Term;
				else
				if (termData.Term.StartsWith(Category + @"/") && Category!=termData.Term)
					Term = termData.Term.Substring(Category.Length+1);
				else
					continue;   // Term doesn't belong to this category

                if (specializationsAsRows)
                {
                    foreach (var specialization in termData.GetAllSpecializations())
                    {
                        AppendTerm(Builder, nLanguages, Term, termData, specialization, Separator);
                    }
                }
                else
                {
                    AppendTerm(Builder, nLanguages, Term, termData, null, Separator);
                }
            }
			return Builder.ToString();
		}

		static void AppendTerm(StringBuilder Builder, int nLanguages, string Term, TermData termData, string specialization, char Separator)
		{
			//--[ Key ] --------------				
			AppendString( Builder, Term, Separator );

			if (!string.IsNullOrEmpty(specialization) && specialization!="Any")
				Builder.AppendFormat( "[{0}]",specialization );
			
			//--[ Type and Description ] --------------
			Builder.Append (Separator);
			Builder.Append (termData.TermType.ToString());
			Builder.Append (Separator);
			AppendString(Builder, termData.Description, Separator);
			
			//--[ Languages ] --------------
			for (int i=0; i<Mathf.Min (nLanguages, termData.Languages.Length); ++i)
			{
				Builder.Append (Separator);

				string translation = termData.Languages[i];
                if (!string.IsNullOrEmpty(specialization))
                    translation = termData.GetTranslation(i, specialization);

                //bool isAutoTranslated = ((termData.Flags[i]&FlagBitMask)>0);

                //if (string.IsNullOrEmpty(s))
                //	s = "-";

                AppendTranslation(Builder, translation, Separator, /*isAutoTranslated ? "[i2auto]" : */null);
			}
			Builder.Append ("\n");
		}
		
		
		static void AppendString( StringBuilder Builder, string Text, char Separator )
		{
			if (string.IsNullOrEmpty(Text))
				return;
			Text = Text.Replace ("\\n", "\n");
			if (Text.IndexOfAny((Separator+"\n\"").ToCharArray())>=0)
			{
				Text = Text.Replace("\"", "\"\"");
				Builder.AppendFormat("\"{0}\"", Text);
			}
			else 
			{
				Builder.Append (Text);
			}
		}

		static void AppendTranslation( StringBuilder Builder, string Text, char Separator, string tags )
		{
			if (string.IsNullOrEmpty(Text))
				return;
			Text = Text.Replace ("\\n", "\n");
			if (Text.IndexOfAny((Separator+"\n\"").ToCharArray())>=0)
			{
				Text = Text.Replace("\"", "\"\"");
				Builder.AppendFormat("\"{0}{1}\"", tags, Text);
			}
			else 
			{
				Builder.Append (tags);
				Builder.Append (Text);
			}
		}


		#endregion
	}
}