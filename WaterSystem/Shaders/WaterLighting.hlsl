#ifndef WATER_LIGHTING_INCLUDED
#define WATER_LIGHTING_INCLUDED

#include "LWRP/ShaderLibrary/Lighting.hlsl"

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
    Light mainLight = GetMainLight(positionWS);


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
    half3 color = specularTerm * 0.1 * mainLight.color * mainLight.attenuation;



    // half3 tangentDir = mainLight.direction; //half3(0, 0, 1);

    // half _AlphaX = 0.5;
    // half _AlphaY = 0.1;

    // float3 halfwayVector = normalize(mainLight.direction + viewDirectionWS);
    // float3 binormalDirection = cross(normalWS, tangentDir);
    // float dotLN = dot(mainLight.direction, normalWS); 
    //         // compute this dot product only once

    // float3 specularReflection;

    // float dotHN = dot(halfwayVector, normalWS);
    // float dotVN = dot(viewDirectionWS, normalWS);
    // float dotHTAlphaX = dot(halfwayVector, tangentDir) / _AlphaX;
    // float dotHBAlphaY = dot(halfwayVector, binormalDirection) / _AlphaY;

    // specularReflection = mainLight.color * sqrt(max(0.0, dotLN / dotVN)) * exp(-2.0 * (dotHTAlphaX * dotHTAlphaX + dotHBAlphaY * dotHBAlphaY) / (1.0 + dotHN));

    // half3 color = clamp(specularReflection, 0, 100);


    return color;
}

///////////////////////////////////////////////////////////////////////////////
//                           Reflection Modes                                //
///////////////////////////////////////////////////////////////////////////////

half3 SampleReflections(half3 normalWS, half3 viewDirectionWS, half2 screenUV, half fresnelTerm, half roughness)
{
    half3 reflection = 0;
    half2 refOffset = 0;

#if _REFLECTION_CUBEMAP
    reflection = half3(1, 0, 0);
#elif _REFLECTION_PROBES
    half3 reflectVector = reflect(-viewDirectionWS, normalWS);
    reflection = GlossyEnvironmentReflection(reflectVector, 0, 1);
#elif _REFLECTION_PLANARREFLECTION
    //flattened viewdir
    half3 viewDir = UNITY_MATRIX_IT_MV[2].xyz;
    viewDir.y = 0;
    viewDir = normalize(viewDir);
    //create view normal
    half3 viewNormal = mul( UNITY_MATRIX_V, float4(normalWS,0) ).xyz;
    //calculate screen-spaced UV offset for planar reflections
    refOffset.x = viewNormal.x * 0.025;
    refOffset.y = dot(viewDir, normalWS) * 0.15;
    //half rimFade = (1-fresnelTerm) - 0.5;//value to smooth out reflection distortion on glancing/distant angles
    screenUV = half2(screenUV.x, 1-screenUV.y);
    half2 reflectionUV = screenUV + refOffset; // * rimFade;
    reflection += _PlanarReflectionTexture.SampleLevel(sampler_PlanarReflectionTexture, reflectionUV, 6 * roughness).rgb;//planar reflection
#endif
    //do backup
    return reflection * fresnelTerm;
}

#endif // WATER_LIGHTING_INCLUDED