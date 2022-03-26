using System;
using UnityEngine;

#if TextMeshPro
namespace I2.Loc
{
    #if UNITY_EDITOR
    [UnityEditor.InitializeOnLoad] 
    #endif

    public class LocalizeTarget_TextMeshPro_Label : LocalizeTarget<TMPro.TextMeshPro>
    {
        static LocalizeTarget_TextMeshPro_Label() { AutoRegister(); }
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)] static void AutoRegister() { LocalizationManager.RegisterTarget(new LocalizeTargetDesc_Type<TMPro.TextMeshPro, LocalizeTarget_TextMeshPro_Label>() { Name = "TextMeshPro Label", Priority = 100 }); }

        TMPro.TextAlignmentOptions mAlignment_RTL = TMPro.TextAlignmentOptions.Right;
        TMPro.TextAlignmentOptions mAlignment_LTR = TMPro.TextAlignmentOptions.Left;
        bool mAlignmentWasRTL;
        bool mInitializeAlignment = true;

        public override eTermType GetPrimaryTermType(Localize cmp) { return eTermType.Text; }
        public override eTermType GetSecondaryTermType(Localize cmp) { return eTermType.Font; }
        public override bool CanUseSecondaryTerm() { return true; }
        public override bool AllowMainTermToBeRTL() { return true; }
        public override bool AllowSecondTermToBeRTL() { return false; }

        public override void GetFinalTerms ( Localize cmp, string Main, string Secondary, out string primaryTerm, out string secondaryTerm)
        {
            primaryTerm = mTarget ? mTarget.text : null;
            secondaryTerm = (mTarget.font != null ? mTarget.font.name : string.Empty);
        }

        public override void DoLocalize(Localize cmp, string mainTranslation, string secondaryTranslation)
        {
            //--[ Localize Font Object ]----------
            {
                TMPro.TMP_FontAsset newFont = cmp.GetSecondaryTranslatedObj<TMPro.TMP_FontAsset>(ref mainTranslation, ref secondaryTranslation);

                if (newFont != null)
                {
                    SetFont(mTarget, newFont);
                }
                else
                {
                    //--[ Localize Font Material ]----------
                    Material newMat = cmp.GetSecondaryTranslatedObj<Material>(ref mainTranslation, ref secondaryTranslation);
                    if (newMat != null && mTarget.fontMaterial != newMat)
                    {
                        if (!newMat.name.StartsWith(mTarget.font.name, StringComparison.Ordinal))
                        {
                            newFont = GetTMPFontFromMaterial(cmp, secondaryTranslation.EndsWith(newMat.name, StringComparison.Ordinal) ? secondaryTranslation : newMat.name);
                            if (newFont != null)
                                SetFont(mTarget, newFont);
                        }
                        SetMaterial(mTarget, newMat); 
                    }
                           
                }
            }
            if (mInitializeAlignment)
            {
                mInitializeAlignment = false;
                mAlignmentWasRTL = LocalizationManager.IsRight2Left;
                InitAlignment_TMPro(mAlignmentWasRTL, mTarget.alignment, out mAlignment_LTR, out mAlignment_RTL);
            }
            else
            {
                TMPro.TextAlignmentOptions alignRTL, alignLTR;
                InitAlignment_TMPro(mAlignmentWasRTL, mTarget.alignment, out alignLTR, out alignRTL);

                if ((mAlignmentWasRTL && mAlignment_RTL != alignRTL) ||
                    (!mAlignmentWasRTL && mAlignment_LTR != alignLTR))
                {
                    mAlignment_LTR = alignLTR;
                    mAlignment_RTL = alignRTL;
                }
                mAlignmentWasRTL = LocalizationManager.IsRight2Left;
            }

            if (mainTranslation != null && mTarget.text != mainTranslation)
            {
                if (mainTranslation != null && cmp.CorrectAlignmentForRTL)
                {
                    mTarget.alignment = (LocalizationManager.IsRight2Left ? mAlignment_RTL : mAlignment_LTR);
                    mTarget.isRightToLeftText = LocalizationManager.IsRight2Left;
                    if (LocalizationManager.IsRight2Left) mainTranslation = I2Utils.ReverseText(mainTranslation);
                }

                mTarget.text = mainTranslation;
            }
        }

        #region Tools
        internal static TMPro.TMP_FontAsset GetTMPFontFromMaterial(Localize cmp, string matName)
        {
            string splitChars = " .\\/-[]()";
            for (int i = matName.Length - 1; i > 0;)
            {
                // Find first valid character
                while (i > 0 && splitChars.IndexOf(matName[i]) >= 0)
                    i--;

                if (i <= 0) break;

                var fontName = matName.Substring(0, i + 1);
                var obj = cmp.GetObject<TMPro.TMP_FontAsset>(fontName);
                if (obj != null)
                    return obj;

                // skip this word
                while (i > 0 && splitChars.IndexOf(matName[i]) < 0)
                    i--;
            }

            return null;
        }

        internal static void InitAlignment_TMPro(bool isRTL, TMPro.TextAlignmentOptions alignment, out TMPro.TextAlignmentOptions alignLTR, out TMPro.TextAlignmentOptions alignRTL)
        {
            alignLTR = alignRTL = alignment;

            if (isRTL)
            {
                switch (alignment)
                {
                    case TMPro.TextAlignmentOptions.TopRight: alignLTR = TMPro.TextAlignmentOptions.TopLeft; break;
                    case TMPro.TextAlignmentOptions.Right: alignLTR = TMPro.TextAlignmentOptions.Left; break;
                    case TMPro.TextAlignmentOptions.BottomRight: alignLTR = TMPro.TextAlignmentOptions.BottomLeft; break;
                    case TMPro.TextAlignmentOptions.BaselineRight: alignLTR = TMPro.TextAlignmentOptions.BaselineLeft; break;
                    case TMPro.TextAlignmentOptions.MidlineRight: alignLTR = TMPro.TextAlignmentOptions.MidlineLeft; break;
                    case TMPro.TextAlignmentOptions.CaplineRight: alignLTR = TMPro.TextAlignmentOptions.CaplineLeft; break;

                    case TMPro.TextAlignmentOptions.TopLeft: alignLTR = TMPro.TextAlignmentOptions.TopRight; break;
                    case TMPro.TextAlignmentOptions.Left: alignLTR = TMPro.TextAlignmentOptions.Right; break;
                    case TMPro.TextAlignmentOptions.BottomLeft: alignLTR = TMPro.TextAlignmentOptions.BottomRight; break;
                    case TMPro.TextAlignmentOptions.BaselineLeft: alignLTR = TMPro.TextAlignmentOptions.BaselineRight; break;
                    case TMPro.TextAlignmentOptions.MidlineLeft: alignLTR = TMPro.TextAlignmentOptions.MidlineRight; break;
                    case TMPro.TextAlignmentOptions.CaplineLeft: alignLTR = TMPro.TextAlignmentOptions.CaplineRight; break;

                }
            }
            else
            {
                switch (alignment)
                {
                    case TMPro.TextAlignmentOptions.TopRight: alignRTL = TMPro.TextAlignmentOptions.TopLeft; break;
                    case TMPro.TextAlignmentOptions.Right: alignRTL = TMPro.TextAlignmentOptions.Left; break;
                    case TMPro.TextAlignmentOptions.BottomRight: alignRTL = TMPro.TextAlignmentOptions.BottomLeft; break;
                    case TMPro.TextAlignmentOptions.BaselineRight: alignRTL = TMPro.TextAlignmentOptions.BaselineLeft; break;
                    case TMPro.TextAlignmentOptions.MidlineRight: alignRTL = TMPro.TextAlignmentOptions.MidlineLeft; break;
                    case TMPro.TextAlignmentOptions.CaplineRight: alignRTL = TMPro.TextAlignmentOptions.CaplineLeft; break;

                    case TMPro.TextAlignmentOptions.TopLeft: alignRTL = TMPro.TextAlignmentOptions.TopRight; break;
                    case TMPro.TextAlignmentOptions.Left: alignRTL = TMPro.TextAlignmentOptions.Right; break;
                    case TMPro.TextAlignmentOptions.BottomLeft: alignRTL = TMPro.TextAlignmentOptions.BottomRight; break;
                    case TMPro.TextAlignmentOptions.BaselineLeft: alignRTL = TMPro.TextAlignmentOptions.BaselineRight; break;
                    case TMPro.TextAlignmentOptions.MidlineLeft: alignRTL = TMPro.TextAlignmentOptions.MidlineRight; break;
                    case TMPro.TextAlignmentOptions.CaplineLeft: alignRTL = TMPro.TextAlignmentOptions.CaplineRight; break;
                }
            }
        }

        internal static void SetFont(TMPro.TMP_Text label, TMPro.TMP_FontAsset newFont)
        {
            if (label.font != newFont)
            {
                label.font = newFont;
            }
            if (label.linkedTextComponent != null)
            {
                SetFont(label.linkedTextComponent, newFont);
            }
        }
        internal static void SetMaterial(TMPro.TMP_Text label, Material newMat)
        {
            if (label.fontSharedMaterial != newMat)
            {
                label.fontSharedMaterial = newMat;
            }
            if (label.linkedTextComponent != null)
            {
                SetMaterial(label.linkedTextComponent, newMat);
            }
        }
        #endregion
    }
}
#endif