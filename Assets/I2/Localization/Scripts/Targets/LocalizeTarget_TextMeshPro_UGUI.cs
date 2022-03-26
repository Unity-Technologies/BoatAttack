using System;
using UnityEngine;

#if TextMeshPro
namespace I2.Loc
{
    #if UNITY_EDITOR
    [UnityEditor.InitializeOnLoad] 
    #endif

    public class LocalizeTarget_TextMeshPro_UGUI : LocalizeTarget<TMPro.TextMeshProUGUI>
    {
        static LocalizeTarget_TextMeshPro_UGUI() { AutoRegister(); }
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)] static void AutoRegister() { LocalizationManager.RegisterTarget(new LocalizeTargetDesc_Type<TMPro.TextMeshProUGUI, LocalizeTarget_TextMeshPro_UGUI>() { Name = "TextMeshPro UGUI", Priority = 100 }); }

        public TMPro.TextAlignmentOptions mAlignment_RTL = TMPro.TextAlignmentOptions.Right;
        public TMPro.TextAlignmentOptions mAlignment_LTR = TMPro.TextAlignmentOptions.Left;
        public bool mAlignmentWasRTL;
        public bool mInitializeAlignment = true;

        public override eTermType GetPrimaryTermType(Localize cmp) { return eTermType.Text; }
        public override eTermType GetSecondaryTermType(Localize cmp) { return eTermType.TextMeshPFont; }
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
            {
                //--[ Localize Font Object ]----------
                TMPro.TMP_FontAsset newFont = cmp.GetSecondaryTranslatedObj<TMPro.TMP_FontAsset>(ref mainTranslation, ref secondaryTranslation);

                if (newFont != null)
                {
                    LocalizeTarget_TextMeshPro_Label.SetFont(mTarget, newFont);
                }
                else
                {
                    //--[ Localize Font Material ]----------
                    Material newMat = cmp.GetSecondaryTranslatedObj<Material>(ref mainTranslation, ref secondaryTranslation);
                    if (newMat != null && mTarget.fontMaterial != newMat)
                    {
                        if (!newMat.name.StartsWith(mTarget.font.name, StringComparison.Ordinal))
                        {
                            newFont = LocalizeTarget_TextMeshPro_Label.GetTMPFontFromMaterial(cmp, secondaryTranslation.EndsWith(newMat.name, StringComparison.Ordinal) ? secondaryTranslation : newMat.name);
                            if (newFont != null)
                                LocalizeTarget_TextMeshPro_Label.SetFont(mTarget, newFont);
                        }
                        LocalizeTarget_TextMeshPro_Label.SetMaterial( mTarget, newMat );
                    }
                }
            }

            if (mInitializeAlignment)
            {
                mInitializeAlignment = false;
                mAlignmentWasRTL = LocalizationManager.IsRight2Left;
                LocalizeTarget_TextMeshPro_Label.InitAlignment_TMPro(mAlignmentWasRTL, mTarget.alignment, out mAlignment_LTR, out mAlignment_RTL);
            }
            else
            {
                TMPro.TextAlignmentOptions alignRTL, alignLTR;
                LocalizeTarget_TextMeshPro_Label.InitAlignment_TMPro(mAlignmentWasRTL, mTarget.alignment, out alignLTR, out alignRTL);

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
    }
}
#endif