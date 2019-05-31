#ifndef WATER_COMMON_INCLUDED
#define WATER_COMMON_INCLUDED

#define _MAIN_LIGHT_SHADOWS_CASCADE 1
#define SHADOWS_SCREEN 0

#include "Packages/com.unity.render-pipelines.lightweight/ShaderLibrary/Core.hlsl"
#include "WaterInput.hlsl"
#include "CommonUtilities.hlsl"
#include "GerstnerWaves.hlsl"
#include "WaterLighting.hlsl"

///////////////////////////////////////////////////////////////////////////////
//                  				Structs		                             //
///////////////////////////////////////////////////////////////////////////////

struct WaterVertexInput // vert struct 
{
	float4	vertex 					: POSITION;		// vertex positions
	float2	texcoord 				: TEXCOORD0;	// local UVs
	UNITY_VERTEX_INPUT_INSTANCE_ID
};

struct WaterVertexOutput // fragment struct
{
	float4	uv 						: TEXCOORD0;	// Geometric UVs stored in xy, and world(pre-waves) in zw
	float3	posWS					: TEXCOORD1;	// world position of the vertices
	half3 	normal 					: NORMAL;		// vert normals
	float3 	viewDir 				: TEXCOORD2;	// view direction
	float3	preWaveSP 				: TEXCOORD3;	// screen position of the verticies before wave distortion
	half2 	fogFactorNoise          : TEXCOORD4;	// x: fogFactor, y: noise
	float4	additionalData			: TEXCOORD5;	// x = distance to surface, y = distance to surface, z = normalized wave height, w = horizontal movement
	half4	shadowCoord				: TEXCOORD6;	// for ssshadows

	float4	clipPos					: SV_POSITION;
	UNITY_VERTEX_INPUT_INSTANCE_ID
	UNITY_VERTEX_OUTPUT_STEREO
};

///////////////////////////////////////////////////////////////////////////////
//          	   	      Water shading functions                            //
///////////////////////////////////////////////////////////////////////////////

half3 Scattering(half depth)
{
	return SAMPLE_TEXTURE2D(_AbsorptionScatteringRamp, sampler_AbsorptionScatteringRamp, half2(depth, 0.375h)).rgb;
}

half3 Absorption(half depth)
{
	return SAMPLE_TEXTURE2D(_AbsorptionScatteringRamp, sampler_AbsorptionScatteringRamp, half2(depth, 0.0h)).rgb;
}

float2 AdjustedDepth(half2 uvs, half4 additionalData)
{
	float rawD = SAMPLE_DEPTH_TEXTURE(_CameraDepthTexture, sampler_ScreenTextures_linear_clamp, uvs);
	float d = LinearEyeDepth(rawD, _ZBufferParams);
	return float2(d * additionalData.x - additionalData.y, (rawD * -_ProjectionParams.x) + (1-UNITY_REVERSED_Z));
}

float3 WaterDepth(float3 posWS, half2 texcoords, half4 additionalData, half2 screenUVs)// x = seafloor depth, y = water depth
{
	float3 outDepth = 0;
	outDepth.xz = AdjustedDepth(screenUVs, additionalData);
	float wd = (1 - SAMPLE_TEXTURE2D(_WaterDepthMap, sampler_WaterDepthMap_linear_clamp, texcoords).r) * 19.1;
	outDepth.y = (wd - 3.5) + posWS.y;
	return outDepth;
}

half3 Refraction(half2 distortion, half mip)
{
	half3 refrac = SAMPLE_TEXTURE2D_LOD(_CameraOpaqueTexture, sampler_CameraOpaqueTexture_linear_clamp, distortion, mip).rgb;
	return refrac;
}

half2 DistortionUVs(half depth, float3 normalWS)
{
    half3 viewNormal = mul((float3x3)GetWorldToHClipMatrix(), -normalWS).xyz;
    
    return viewNormal.xz * saturate((depth) * 0.005);
}

half4 AdditionalData(float3 postionWS, WaveStruct wave)
{
    half4 data = half4(0.0, 0.0, 0.0, 0.0);
    float3 viewPos = TransformWorldToView(postionWS);
	data.x = length(viewPos / viewPos.z);// distance to surface
    data.y = length(GetCameraPositionWS().xyz - postionWS); // local position in camera space
	data.z = wave.position.y / _MaxWaveHeight; // encode the normalized wave height into additional data
	data.w = wave.position.x + wave.position.z;
	return data;
}

WaterVertexOutput WaveVertexOperations(WaterVertexOutput input)
{
    input.normal = float3(0, 1, 0);
    input.uv.zw = input.posWS.xz;
	input.fogFactorNoise.y = ((noise((input.posWS.xz * 0.5) + _GlobalTime) + noise((input.posWS.xz * 1) + _GlobalTime)) * 0.25 - 0.5) + 1;

	half4 screenUV = ComputeScreenPos(TransformWorldToHClip(input.posWS));
	screenUV.xyz /= screenUV.w;

    // shallows mask
    half waterDepth = (1 - SAMPLE_TEXTURE2D_LOD(_WaterDepthMap, sampler_WaterDepthMap_linear_clamp, (input.posWS.xz * half2(0.002, -0.002)) + 0.5, 1).r) * 19.1;
    waterDepth = waterDepth - 4.1;
    input.posWS.y += saturate((1-waterDepth) * 0.6 - 0.5);

	//Gerstner here
	WaveStruct wave;
	SampleWaves(input.posWS, saturate((waterDepth * 0.25)) + 0.1, wave);
	input.normal = normalize(wave.normal.xzy);
    input.posWS += wave.position;

    // Dynamic displacement
	half4 waterFX = SAMPLE_TEXTURE2D_LOD(_WaterFXMap, sampler_ScreenTextures_linear_clamp, screenUV.xy, 0);
	input.posWS.y += waterFX.w * 2 - 1;

	// After waves
	input.clipPos = TransformWorldToHClip(input.posWS);
	input.shadowCoord = ComputeScreenPos(input.clipPos);
    input.viewDir = SafeNormalize(_WorldSpaceCameraPos - input.posWS);

    // Fog
	input.fogFactorNoise.x = ComputeFogFactor(input.clipPos.z);
	input.preWaveSP = screenUV.xyz; // pre-displaced screenUVs
	
	// Additional data
	input.additionalData = AdditionalData(input.posWS, wave);

	// distance blend
	half distanceBlend = saturate(input.additionalData.y * 0.005);

	input.normal = lerp(input.normal, half3(0, 1, 0), distanceBlend);
	
	return input;
}

///////////////////////////////////////////////////////////////////////////////
//               	   Vertex and Fragment functions                         //
///////////////////////////////////////////////////////////////////////////////

// Vertex: Used for Standard non-tessellated water
WaterVertexOutput WaterVertex(WaterVertexInput v)
{
    WaterVertexOutput o;// = (WaterVertexOutput)0;
	UNITY_SETUP_INSTANCE_ID(v);
    UNITY_TRANSFER_INSTANCE_ID(v, o);
	UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);

    o.uv.xy = v.texcoord; // geo uvs
    o.posWS = TransformObjectToWorld(v.vertex.xyz);

	o = WaveVertexOperations(o);
    return o;
}

// Fragment for water
half4 WaterFragment(WaterVertexOutput IN) : SV_Target
{
	UNITY_SETUP_INSTANCE_ID(IN);
	half3 screenUV = IN.shadowCoord.xyz / IN.shadowCoord.w;//screen UVs

	half4 waterFX = SAMPLE_TEXTURE2D(_WaterFXMap, sampler_ScreenTextures_linear_clamp, IN.preWaveSP.xy);

	half animT = frac(_GlobalTime) * 16; // amination value for caustics(16 frames)
	
	// Detail waves
	half t = _Time.x;
	half2 detailBump = SAMPLE_TEXTURE2D(_SurfaceMap, sampler_SurfaceMap, IN.uv.zw * 0.25h + t + (IN.fogFactorNoise.y * 0.1)).xy; // TODO - check perf
	
	IN.normal += (half3(detailBump.x, 0.5h, detailBump.y) * 2 - 1) * _BumpScale;
	IN.normal += half3(1-waterFX.y, 0.5h, 1-waterFX.z) - 0.5;

	// Depth
	float3 depth = WaterDepth(IN.posWS, (IN.posWS.xz * half2(0.002, -0.002)) + 0.5, IN.additionalData, screenUV.xy);// TODO - hardcoded shore depth UVs

	// Distortion
	half2 distortion = DistortionUVs(depth.x, IN.normal);
	distortion = screenUV.xy + distortion;// * clamp(depth.x, 0, 5);
	float d = depth.x;
	depth.xz = AdjustedDepth(distortion, IN.additionalData);
	distortion = depth.x < 0 ? screenUV.xy : distortion;
	depth.x = depth.x < 0 ? d : depth.x;

	// Fresnel
	half fresnelTerm = CalculateFresnelTerm(IN.normal, IN.viewDir.xyz);

	// Shadows
	half shadow = MainLightRealtimeShadow(TransformWorldToShadowCoord(IN.posWS));
	
	// Specular
	half3 spec = Highlights(IN.posWS, 0.001, IN.normal, IN.viewDir) * shadow;
	Light mainLight = GetMainLight();

	// Foam
	float2 foamMapUV = (IN.uv.zw * 0.1) + (detailBump.xy * 0.0025) + half2(IN.fogFactorNoise.y * 0.1, (1-IN.fogFactorNoise.y) * 0.1) + _GlobalTime * 0.05;
	half3 foamMap = SAMPLE_TEXTURE2D(_FoamMap, sampler_FoamMap, foamMapUV).rgb; //r=thick, g=medium, b=light
	half shoreMask = pow(((1-depth.y + 9) * 0.1), 6);
	half foamMask = (IN.additionalData.z);
	half shoreWave = (sin(_Time.z + (depth.y * 10) + IN.fogFactorNoise.y) * 0.5 + 0.5) * saturate((1-depth.x) + 1);
	foamMask = max(max((foamMask + shoreMask) - IN.fogFactorNoise.y * 0.25, waterFX.r * 2), shoreWave);
	half3 foamBlend = SAMPLE_TEXTURE2D(_AbsorptionScatteringRamp, sampler_AbsorptionScatteringRamp, half2(foamMask, 0.66)).rgb;

	half3 foam = length(foamMap * foamBlend).rrr;

	// Reflections
	half3 reflection = SampleReflections(IN.normal, IN.viewDir.xyz, screenUV.xy, fresnelTerm, 0.0);
	reflection = reflection + spec;
	reflection *= 1 - saturate(foam * 2);

	// Refraction
	half3 refraction = Refraction(distortion, depth.x * 0.25);

	// Final Colouring
	half depthMulti = 1 / _MaxDepth;
    half3 color = refraction;
	color *= Absorption((depth.x) * depthMulti);
	color += Scattering(depth.x * depthMulti) * (shadow * 0.5 + 0.5);// * saturate(1-length(reflection));// TODO - scattering from main light(maybe additional lights too depending on cost)
	color *= 1 - saturate(foam);
	//color *= 1-saturate(length(reflection));

	// Foam lighting
	foam *= (shadow * 0.9 + 0.1) * mainLight.color;

	// Do compositing
	half3 comp = lerp(refraction, color + reflection + foam, 1-saturate(1-depth.x * 25));
	
	// Fog
    float fogFactor = IN.fogFactorNoise.x;
    comp = MixFog(comp, fogFactor);
	return half4(comp, 1);
	//return half4(frac(IN.posWS.yyy), 1); // debug line
	//return half4(frac(IN.posWS.yyy), 1); // debug line
}

#endif // WATER_COMMON_INCLUDED