using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Rendering;

namespace UnityEditor.TestTools.Graphics
{
    public class ShaderVariantList : ScriptableObject
    {
        public class KeywordSet : HashSet<ShaderKeyword> { }
        
        public class VariantList : Dictionary<(ShaderType shaderType, string passName), List<KeywordSet>> { }
        
        public class ComputeVariantList : Dictionary<string, List<KeywordSet>> { }
    
        public Dictionary<string, VariantList> variantListPerShader = new Dictionary<string, VariantList>();
        
        public Dictionary<string, ComputeVariantList> variantListPerComputeShader = new Dictionary<string, ComputeVariantList>();
    
        [System.Serializable]
        public struct SerializedShaderVariant
        {
            public string shaderName;
            public string passName;
            public ShaderType stage;
            public List<string> keywords;
        }
    
        [System.Serializable]
        public struct SerializedComputeShaderVariant
        {
            public string computeShaderName;
            public string kernelName;
            public List<string> keywords;
        }
        
        [System.Serializable]
        public class Settings
        {
            public ShaderCompilerPlatform targetPlatform;
            public bool xr;
            public bool enabled = true;
        }
    
        [HideInInspector]
        public Settings settings = new Settings();
        public List<SerializedShaderVariant> serializedShaderVariants = new List<SerializedShaderVariant>();
        public List<SerializedComputeShaderVariant> serializedComputeShaderVariants = new List<SerializedComputeShaderVariant>();
    
        void BuildFastAccessStructures()
        {
            foreach (var variant in serializedShaderVariants)
            {
                if (!variantListPerShader.TryGetValue(variant.shaderName, out var variantList))
                    variantList = variantListPerShader[variant.shaderName] = new VariantList();
                var key = (variant.stage, variant.passName);
                if (!variantList.TryGetValue(key, out var keywordSetList))
                    keywordSetList = variantList[key] = new List<KeywordSet>();
                var keywordSet = new KeywordSet();
                foreach (var keyword in variant.keywords)
                    keywordSet.Add(new ShaderKeyword(keyword));
                keywordSetList.Add(keywordSet);
            }
            
            foreach (var variant in serializedComputeShaderVariants)
            {
                if (!variantListPerComputeShader.TryGetValue(variant.computeShaderName, out var variantList))
                    variantList = variantListPerComputeShader[variant.computeShaderName] = new ComputeVariantList();
                if (!variantList.TryGetValue(variant.kernelName, out var keywordSetList))
                    keywordSetList = variantList[variant.kernelName] = new List<KeywordSet>();
                var keywordSet = new KeywordSet();
                foreach (var keyword in variant.keywords)
                    keywordSet.Add(new ShaderKeyword(keyword));
                keywordSetList.Add(keywordSet);
            }
        }
    
        public void OnEnable()
        {
            BuildFastAccessStructures();
        }

        public bool MatchSettings(ShaderCompilerPlatform targetPlatform, bool xr)
            => settings.xr == xr && settings.targetPlatform == targetPlatform;
    }
}