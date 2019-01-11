#ifndef SHADOW_PASS_VEGETATION_INCLUDED
#define SHADOW_PASS_VEGETATION_INCLUDED

#include "Packages/com.unity.render-pipelines.lightweight/ShaderLibrary/Core.hlsl"
#include "Packages/com.unity.render-pipelines.lightweight/ShaderLibrary/Shadows.hlsl"

float3 _LightDirection;

struct VertexInput
{
    float4 positionOS   : POSITION;
    float3 normalOS     : NORMAL;
    float2 texcoord     : TEXCOORD0;
    half3 color         : COLOR;
    UNITY_VERTEX_INPUT_INSTANCE_ID
};

struct VertexOutput
{
    float2 uv           : TEXCOORD0;
    float4 clipPos      : SV_POSITION;
};

VertexOutput ShadowPassVegetationVertex(VertexInput input)
{
    VertexOutput output;
    UNITY_SETUP_INSTANCE_ID(input);
    
    #if _VERTEXANIMATION
    /////////////////////////////////////vegetation stuff//////////////////////////////////////////////////
    float3 objectOrigin = UNITY_ACCESS_INSTANCED_PROP(Props, _Position).xyz;
    input.positionOS.xyz = VegetationDeformation(input.positionOS, objectOrigin, input.normalOS, input.color.x, input.color.z, input.color.y);
    //////////////////////////////////////////////////////////////////////////////////////////////////////
    #endif
    
    output.uv = input.texcoord;

    float3 positionWS = TransformObjectToWorld(input.positionOS.xyz);
    float3 normalWS = TransformObjectToWorldDir(input.normalOS);

    output.clipPos = TransformWorldToHClip(ApplyShadowBias(positionWS, normalWS, _LightDirection));

#if UNITY_REVERSED_Z
    output.clipPos.z = min(output.clipPos.z, output.clipPos.w * UNITY_NEAR_CLIP_VALUE);
#else
    output.clipPos.z = max(output.clipPos.z, output.clipPos.w * UNITY_NEAR_CLIP_VALUE);
#endif
    return output;
}

half4 ShadowPassVegetationFragment(VertexOutput IN) : SV_TARGET
{
    half alpha = SampleAlbedoAlpha(IN.uv, TEXTURE2D_PARAM(_BaseMap, sampler_BaseMap)).a;
    clip(alpha - _Cutoff);
    return 1;
}

#endif // SHADOW_PASS_VEGETATION_INCLUDED
