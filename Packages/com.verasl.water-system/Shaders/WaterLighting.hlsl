#ifndef WATER_LIGHTING_INCLUDED
#define WATER_LIGHTING_INCLUDED

#include "Packages/com.unity.render-pipelines.lightweight/ShaderLibrary/Lighting.hlsl"

half CalculateFresnelTerm(half3 normalWS, half3 viewDirectionWS)
{
    return Pow4(1.0 - saturate(dot(normalWS, viewDirectionWS)));//fresnel TODO - find a better place
}

///////////////////////////////////////////////////////////////////////////////
//                         Lighting Calculations                             //
///////////////////////////////////////////////////////////////////////////////

//diffuse
half4 VertexLightingAndFog(half3 normalWS, half3 posWS, half3 clipPos)
{
    half3 vertexLight = VertexLighting(posWS, normalWS);
    half fogFactor = ComputeFogFactor(clipPos.z);
    return half4(fogFactor, vertexLight);
}

//specular
half3 Highlights(half3 positionWS, half roughness, half3 normalWS, half3 viewDirectionWS)
{
    Light mainLight = GetMainLight();

    half roughness2 = roughness * roughness;
    half3 halfDir = SafeNormalize(mainLight.direction + viewDirectionWS);
    half NoH = saturate(dot(normalize(normalWS), halfDir));
    half LoH = saturate(dot(mainLight.direction, halfDir));
    // GGX Distribution multiplied by combined approximation of Visibility and Fresnel
    // See "Optimizing PBR for Mobile" from Siggraph 2015 moving mobile graphics course
    // https://community.arm.com/events/1155
    half d = NoH * NoH * (roughness2 - 1.h) + 1.0001h;
    half LoH2 = LoH * LoH;
    half specularTerm = roughness2 / ((d * d) * max(0.1h, LoH2) * (roughness + 0.5h) * 4);
    // on mobiles (where half actually means something) denominator have risk of overflow
    // clamp below was added specifically to "fix" that, but dx compiler (we convert bytecode to metal/gles)
    // sees that specularTerm have only non-negative terms, so it skips max(0,..) in clamp (leaving only min(100,...))
#if defined (SHADER_API_MOBILE)
    specularTerm = specularTerm - HALF_MIN;
    specularTerm = clamp(specularTerm, 0.0, 5.0); // Prevent FP16 overflow on mobiles
#endif
    return specularTerm * mainLight.color * mainLight.distanceAttenuation;
}

///////////////////////////////////////////////////////////////////////////////
//                           Reflection Modes                                //
///////////////////////////////////////////////////////////////////////////////

half3 SampleReflections(half3 normalWS, half3 viewDirectionWS, half2 screenUV, half fresnelTerm, half roughness)
{
    half3 reflection = 0;
    half2 refOffset = 0;

#if _REFLECTION_CUBEMAP
    half3 reflectVector = reflect(-viewDirectionWS, normalWS);
    reflection = SAMPLE_TEXTURECUBE(_CubemapTexture, sampler_CubemapTexture, reflectVector).rgb;
#elif _REFLECTION_PROBES
    half3 reflectVector = reflect(-viewDirectionWS, normalWS);
    reflection = GlossyEnvironmentReflection(reflectVector, 0, 1);
#elif _REFLECTION_PLANARREFLECTION
    refOffset += (normalWS.xx * normalWS.zz) * half2(0.2, 4);
    half rimFade = (1-fresnelTerm);//value to smooth out reflection distortion on glancing/distant angles
    half2 reflectionUV = screenUV + refOffset * rimFade;
    reflection += SAMPLE_TEXTURE2D_LOD(_PlanarReflectionTexture, sampler_ScreenTextures_linear_clamp, reflectionUV, 6 * roughness).rgb;//planar reflection
#endif
    //do backup
    return reflection * fresnelTerm;
}

#endif // WATER_LIGHTING_INCLUDED