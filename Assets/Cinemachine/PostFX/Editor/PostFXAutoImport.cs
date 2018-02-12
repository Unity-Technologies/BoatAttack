
namespace Cinemachine.PostFX
{
    /// <summary>Integrates Cinemachine with PostProcessing V1 stack.</summary>
    /// Since PostPorcessing V1 does not create a define in Player settings the
    /// way V2 does, we do it ourselves if we detect the presence of PostProcessing V1
    class PostFXAutoImport
    {
        [UnityEditor.InitializeOnLoad]
        class EditorInitialize 
        {
            static EditorInitialize() 
            {
#if UNITY_POST_PROCESSING_STACK_V2
                // We have PPv2
                CinemachinePostProcessing.InitializeModule();
#else
                // Check for PostProcessing V1.  Define symbol if we have it.
                if (Cinemachine.Utility.ReflectionHelpers.TypeIsDefined("UnityEngine.PostProcessing.PostProcessingBehaviour"))
                {
                    if (Cinemachine.Editor.ScriptableObjectUtility.AddDefineForAllBuildTargets("UNITY_POST_PROCESSING_STACK_V1"))
                    {
                        string path = Cinemachine.Editor.ScriptableObjectUtility.CinemachineInstallAssetPath + "/PostFX/CinemachinePostFX.cs";
                        UnityEditor.AssetDatabase.ImportAsset(path, UnityEditor.ImportAssetOptions.ForceUpdate);
                    }
                }
    #if UNITY_POST_PROCESSING_STACK_V1
                // We have PPv1
                CinemachinePostFX.InitializeModule(); 
    #endif
#endif
            } 
        }
    }
}
