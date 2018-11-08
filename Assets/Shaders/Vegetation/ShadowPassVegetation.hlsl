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

float4 GetShadowPositionHClip(VertexInput input)
{
    VertexPositionInputs vertexPosition = GetVertexPositionInputs(input.positionOS);
    
    float3 normalWS = TransformObjectToWorldNormal(input.normalOS);
    float4 clipPos = TransformWorldToHClip(ApplyShadowBias(vertexPosition.positionWS, normalWS, _LightDirection));


#if UNITY_REVERSED_Z
    clipPos.z = min(clipPos.z, clipPos.w * UNITY_NEAR_CLIP_VALUE);
#else
    clipPos.z = max(clipPos.z, clipPos.w * UNITY_NEAR_CLIP_VALUE);
#endif

    return clipPos;
}

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
    output.clipPos = GetShadowPositionHClip(input);
    return output;
}

half4 ShadowPassVegetationFragment(VertexOutput IN) : SV_TARGET
{
    half alpha = SampleAlbedoAlpha(IN.uv, TEXTURE2D_PARAM(_MainTex, sampler_MainTex)).a;
    clip(alpha - _Cutoff);
    return 0;
}

#endif // SHADOW_PASS_VEGETATION_INCLUDED
