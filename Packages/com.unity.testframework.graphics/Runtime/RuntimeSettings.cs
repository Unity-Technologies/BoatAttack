using System;

namespace UnityEngine.TestTools.Graphics
{
    /// <summary>
    /// Helper class for runtime automated graphics tests.
    /// </summary>
    public static class RuntimeSettings
    {
        /// <summary>
        /// Use this property to check if standard images (non-XR) should be used as reference when running tests in XR mode.
        /// </summary>
        public static bool reuseTestsForXR { get; } = _reuseTestsForXR;

        // Cache result to avoid GC.
        private static bool _reuseTestsForXR
        {
#if UNITY_EDITOR
            get => Array.Exists(Environment.GetCommandLineArgs(), arg => arg == "-xr-reuse-tests");
#elif XR_REUSE_TESTS_STANDALONE
            get => true;
#else
            get => false;
#endif
        }
        
        /// <summary>
        /// Use this property to check if standard images (non-RG) should be used as reference when running tests in RenderGraph mode.
        /// </summary>
        public static bool reuseTestsForRenderGraph { get; } = _reuseTestsForRenderGraph;
        
        // Cache result to avoid GC.
        private static bool _reuseTestsForRenderGraph
        {
#if UNITY_EDITOR
            get => Array.Exists(Environment.GetCommandLineArgs(), arg => arg == "-render-graph-reuse-tests");
#elif RENDER_GRAPH_REUSE_TESTS_STANDALONE
            get => true;
#else
            get => false;
#endif
        }

        /// <summary>
        /// Use this property to check if all actual images should be saved when running tests.
        /// </summary>
        public static bool saveActualImages {get; } = _saveActualImages;

        private static bool _saveActualImages
        {
#if UNITY_EDITOR
            get => Array.Exists(Environment.GetCommandLineArgs(), arg => arg == "-save-actual-images") || UnityEditor.EditorPrefs.GetBool("SaveActualImages");
#elif SAVE_ACTUAL_IMAGES_STANDALONE
            get => true;
#else   
            get => false;
#endif
        }
    }
}
