using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace UnityEngine.TestTools.Graphics
{
    /// <summary>
    /// Represents one automatically-generated graphics test case.
    /// </summary>
    public class GraphicsTestCase
    {
        private readonly string _name;
        private readonly string _scenePath;
        private readonly CodeBasedGraphicsTestAttribute _codeBasedGraphicsTestAttribute;
        private readonly Texture2D _referenceImage;
        private readonly RenderPipelineAsset _srpAsset;

        public GraphicsTestCase(string scenePath, Texture2D referenceImage, RenderPipelineAsset srpAsset = null)
        {
            var nameExt = string.Empty;
            if (srpAsset != null)
            {
                nameExt = $"_{srpAsset.name}";
            }
            _name = System.IO.Path.GetFileNameWithoutExtension(scenePath) + nameExt;
            _scenePath = scenePath;
            _codeBasedGraphicsTestAttribute = null;
            _referenceImage = referenceImage;
            _srpAsset = srpAsset;
        }

        public GraphicsTestCase(string name, CodeBasedGraphicsTestAttribute codeBasedGraphicsTestAttrib, Texture2D referenceImage, RenderPipelineAsset srpAsset = null)
        {
            var nameExt = string.Empty;
            if (srpAsset != null)
            {
                nameExt = $"_{srpAsset.name}";
            }
            _name = name + nameExt;
            _scenePath = null;
            _codeBasedGraphicsTestAttribute = codeBasedGraphicsTestAttrib;
            _referenceImage = referenceImage;
            _srpAsset = srpAsset;
        }
        
        /// <summary>
        /// The path to the scene to be used for this test case.
        /// </summary>
        public string ScenePath { get { return _scenePath; } }

        /// <summary>
        /// The name of the test to be displayed in the TestRunner window and the Graphics Test Results window.
        /// </summary>
        public string Name => _name;

        /// <summary>
        /// The associated <see cref="CodeBasedGraphicsTestAttribute"/> if the test case is code based.
        /// </summary>
        public CodeBasedGraphicsTestAttribute CodeBasedGraphicsTestAttribute => _codeBasedGraphicsTestAttribute;

        /// <summary>
        /// The reference image that represents the expected output for this test case.
        /// </summary>
        public Texture2D ReferenceImage {  get { return _referenceImage; } }

        /// <summary>
        /// The Scriptable Render Pipeline Asset used for this test case.
        /// </summary>
        public RenderPipelineAsset SRPAsset => _srpAsset;
    }
}