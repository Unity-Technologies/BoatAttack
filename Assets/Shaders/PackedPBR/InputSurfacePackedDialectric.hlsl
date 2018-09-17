#ifndef LIGHTWEIGHT_INPUT_PACKED_DIALECTRIC_INCLUDED
#define LIGHTWEIGHT_INPUT_PACKED_DIALECTRIC_INCLUDED

#include "Packages/com.unity.render-pipelines.lightweight/ShaderLibrary/Core.hlsl"
#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/CommonMaterial.hlsl"
#include "Packages/com.unity.render-pipelines.lightweight/ShaderLibrary/InputSurfaceCommon.hlsl"

CBUFFER_START(UnityPerMaterial)
float4 _MainTex_ST;
half4 _Color; // only temp
half _Cutoff; // only temp
half _BumpScale;
CBUFFER_END

inline void InitializeStandardLitSurfaceData(float2 uv, out SurfaceData outSurfaceData)
{
    half4 albedoRoughness = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, uv);
    outSurfaceData.alpha = 1;

    outSurfaceData.albedo = albedoRoughness.rgb;

    outSurfaceData.metallic = 0;
    outSurfaceData.specular = half3(0.0h, 0.0h, 0.0h);

    outSurfaceData.smoothness = albedoRoughness.a;
    half4 normalAO = SAMPLE_TEXTURE2D(_BumpMap, sampler_BumpMap, uv);
    outSurfaceData.normalTS = normalAO.rgb * 2 - 1;
    outSurfaceData.occlusion = normalAO.a;
    outSurfaceData.emission = 0;
}

#endif // LIGHTWEIGHT_INPUT_PACKED_DIALECTRIC_INCLUDED
