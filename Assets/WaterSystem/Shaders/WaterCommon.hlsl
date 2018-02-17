#ifndef WATER_COMMON_INCLUDED
#define WATER_COMMON_INCLUDED

#define _SHADOWS_SOFT
#define _SHADOWS_ENABLED

#include "WaterInput.hlsl"
#include "CommonUtilities.hlsl"
#include "GerstnerWaves.cginc"
#include "WaterLighting.hlsl"

///////////////////////////////////////////////////////////////////////////////
//                  				Structs		                             //
///////////////////////////////////////////////////////////////////////////////

struct WaterVertexInput // vert struct 
{
	float4	vertex 					: POSITION;		// vertex positions
	float2	texcoord 				: TEXCOORD0;	// local UVs
	float4	lightmapUV 				: TEXCOORD1;	// lightmap UVs
	float4	color					: COLOR;		// vertex colors
};

struct WaterVertexOutput // fragment struct
{
	float4	uv 						: TEXCOORD0;	// Geometric UVs stored in xy, and world(pre-waves) in zw
	float4	lightmapUVOrVertexSH	: TEXCOORD1;	// holds either lightmapUV or vertex SH. depending on LIGHTMAP_ON - TODO
	float3	posWS					: TEXCOORD2;	// world position of the vertices
	half3 	normal 					: NORMAL;		// vert normals

	float3 	viewDir 				: TEXCOORD3;	// view direction
	float2	preWaveSP 				: TEXCOORD4;	// screen position of the verticies before wave distortion
	half4 	fogFactorAndVertexLight : TEXCOORD5;	// x: fogFactor, yzw: vertex light

	half4	additionalData			: TEXCOORD6;	// x = distance to surface, y = distance to surface??
	half4	vertColor				: TEXCOORD7;

	float4	clipPos					: SV_POSITION;
};

///////////////////////////////////////////////////////////////////////////////
//          	   	      Water shading functions                            //
///////////////////////////////////////////////////////////////////////////////

half3 Scattering(half depth)
{
	return _AbsorptionScatteringRamp.Sample(sampler_AbsorptionScatteringRamp, float2(saturate(depth * 0.01), 0.75));
}

half3 Absorption(half depth)
{
	return _AbsorptionScatteringRamp.Sample(sampler_AbsorptionScatteringRamp, float2(saturate(depth * 0.01), 0.25));
}

half2 WaterDepth(half3 posWS, half3 viewDir, half2 texcoords, half4 additionalData, half2 screenUVs)// x = seafloor depth, y = water depth
{
	half2 outDepth = 0;
	half d = _CameraDepthTexture.Sample(sampler_CameraDepthTexture, screenUVs).r;
	outDepth.x = LinearEyeDepth(d, _ZBufferParams) * additionalData.x - additionalData.y;
	half wd = 1-_WaterDepthMap.Sample(sampler_WaterDepthMap, texcoords).r;
	outDepth.y = ((wd * _depthCamZParams.y) - 4 - _depthCamZParams.x) + posWS.y;
	//outDepth.y += posWS.y;
	return outDepth;
}

//temp
inline float3 ObjSpaceViewDir( in float4 v )
{
    float3 objSpaceCameraPos = mul(GetWorldToObjectMatrix(), float4(GetCameraPositionWS(), 1)).xyz;
    return objSpaceCameraPos - v.xyz;
}

///////////////////////////////////////////////////////////////////////////////
//               	   Vertex and Fragment functions                         //
///////////////////////////////////////////////////////////////////////////////

// Vertex: Used for Standard non-tessellated water
WaterVertexOutput WaterVertex(WaterVertexInput v)
{
    WaterVertexOutput o = (WaterVertexOutput)0;

    o.uv.xy = v.texcoord; // geo uvs

	// initializes o.normal
    o.normal = float3(0, 1, 0);

    o.posWS = TransformObjectToWorld(v.vertex.xyz);
	o.uv.zw = o.posWS.xz;
    o.clipPos = TransformWorldToHClip(o.posWS);
    o.viewDir = SafeNormalize(_WorldSpaceCameraPos - o.posWS);
	o.vertColor = v.color;

    // We either sample GI from lightmap or SH. lightmap UV and vertex SH coefficients
    // are packed in lightmapUVOrVertexSH to save interpolator.
    // The following funcions initialize
    OUTPUT_LIGHTMAP_UV(v.lightmapUV, unity_LightmapST, o.lightmapUVOrVertexSH);
    OUTPUT_SH(o.normal, o.lightmapUVOrVertexSH);

    o.fogFactorAndVertexLight = VertexLightingAndFog(o.normal, o.posWS, o.clipPos);

	// Additional data
	//o.additionalData.y = length(ObjSpaceViewDir(v.vertex));

    return o;
}

// Fragment for water
half4 WaterFragment(WaterVertexOutput IN) : SV_Target
{
#if defined (_PERF_VERT) // PERF
	half2 screenUV = ComputeNormalizedDeviceCoordinates(IN.clipPos);//screen UVs
	screenUV /= half2(_ScreenParams.x * 0.5, -_ScreenParams.y * 0.5);// TODO - might be a SRP fix
	half3 prePosWS = IN.posWS;

	half4 waterFX = _WaterFXMap.Sample(sampler_WaterFXMap, float2(screenUV.x, screenUV.y));

#if _TESSELLATION
	half3 normalWS = normalize(IN.normal);
#else
	//Do the gerstner waves in the pixel shader
	WaveStruct wave;
#if defined (_PERF_GERSTNER) // PERF
	SampleWaves(IN.posWS, 1, wave);
	//IN.posWS.xz -= wave.position.xz;
	IN.uv.zw -= wave.position.xz;
	SampleWaves(IN.posWS, 1, wave);
#else
	wave.position = 0;
	wave.normal = float3(0, 0, 1);
#endif

	IN.additionalData.y = length(ObjSpaceViewDir(half4(IN.posWS + wave.position, 1)));

	half3 normalWS = normalize(wave.normal.xzy);
	//half thing = (length(wave.position.xz) * (wave.position.y + 0.25)) / _WaveCount;
	//half thing = _PeakMap.Sample(sampler_PeakMap, float2(wave.position.y, 0));
	IN.posWS.y += wave.position.y; //thing;
	
	// Additional data(in vertex otherwise)
	float3 viewPos = TransformWorldToView(IN.posWS);
	IN.additionalData.x = length(viewPos / viewPos.z);// distance to surface
#endif

	//Detail waves
	half t = _Time.x;
	half3 detailBump = UnpackNormal(_BumpMap.Sample(sampler_BumpMap, IN.uv.zw * 0.05 + (t * 0.25)));
	detailBump += UnpackNormal(_BumpMap.Sample(sampler_BumpMap, (IN.uv.zw * 0.15) + (detailBump.xy * 0.01) - t));

	normalWS += half3(detailBump.x, 0, detailBump.y) * _BumpScale;

	// Depth
#if defined (_PERF_DEPTH) // PERF
	half2 depth = WaterDepth(IN.posWS, IN.viewDir, IN.uv.xy, IN.additionalData, half2(screenUV.x, screenUV.y));
#else
	half2 depth = 100;
#endif

	// Fresnel
#if defined (_PERF_FRESNEL) // PERF
	half fresnelTerm = CalculateFresnelTerm(lerp(normalWS, half3(0, 1, 0), 0.5), IN.viewDir.xyz);
#else
	half fresnelTerm = 0;
#endif

	// Shadows

	//float4 shadowCoord = ComputeShadowCoord(prePosWS);
	half shadow = RealtimeShadowAttenuation(prePosWS); //SampleShadowmap(shadowCoord);

	// Do diffuse/fog?
    half3 indirectDiffuse = SampleGI(IN.lightmapUVOrVertexSH, normalWS);
    float fogFactor = IN.fogFactorAndVertexLight.x;
	
	// Do specular
#if defined (_PERF_LIGHTING) // PERF
	half3 spec = Highlights(IN.posWS, 0.01, normalWS, IN.viewDir) * shadow;	
#else
	half3 spec = 0;
#endif

	// Do reflections
#if defined (_PERF_REF) // PERF
	half3 reflection = SampleReflections(normalWS, IN.viewDir.xyz, screenUV, fresnelTerm, 0.0);
#else
	half3 reflection = 0;
#endif
	reflection = max(reflection, spec);

	// Do Refractions
	//half3 refraction = _CameraColorTexture.Sample(sampler_CameraColorTexture, screenUV);

	// Do Foam
#if defined (_PERF_FOAM) // PERF
	half3 foamMap = _FoamMap.Sample(sampler_FoamMap, (IN.uv.zw * 0.025) + (detailBump.xy * 0.0025)); //r=thick, g=medium, b=light
	half shoreMask = saturate((1-depth.y + 1.25) * 0.35);//shore foam
	
	half foamMask = IN.posWS.y - 0.5;

	foamMask = saturate(foamMask + shoreMask + waterFX.r);

	half foamA = lerp(0, foamMap.b, saturate(foamMask * 4 - 1));
	half foamB = lerp(foamMap.g, foamMap.r, saturate(foamMask * 4 - 3));
	half foam = lerp(foamA, foamB, saturate(foamMask * 4 - 2)) * (shadow + 0.5);
#else
	half foam = 0;
#endif

	// Do colouring
    half3 color = 1;// TODO - get scene colour
#if defined (_PERF_COL) // PERF
	color *= Absorption(depth.x);// TODO - absoption
	color += Scattering(depth.x);// TODO - scattering
	color *=  saturate(min(shadow + 0.1, 1-fresnelTerm));
#else
	color = 0.5;
#endif

	// Do compositing
	half3 comp = color + (foam * 0.75) + (reflection * (1-(foam)));
    // Computes fog factor per-vertex
    ApplyFog(comp, fogFactor);

	//DebugViews
#if _DEBUG
	if(_DebugPass == 1)
	{
		return half4(reflection, 1); // Reflection debug
	}
	else if(_DebugPass == 2) // Color debug
	{
		return half4(color, 1);
	}
	else if(_DebugPass == 3) // Depth debug
	{
		return half4(depth, 0, 1);
	}
	else if(_DebugPass == 4) // WaterFX pass debug
	{
		return waterFX;
	}
	else if(_DebugPass == 5) // Normals debug
	{
		return half4(normalWS, 1);
	}
	else if(_DebugPass == 6) // Fresnel debug
	{
		return half4(fresnelTerm, 0, 0, 1);
	}
	else if(_DebugPass == 7) // Specular debug
	{
		return half4(spec, 1);
	}
	else if(_DebugPass == 8) // Temp debug
	{
		return half4(frac(IN.uv.zw), 0, 1);
	}
	else // fallback to output
	{
		return half4(comp, 1);
	}
#else
	return half4(comp, 1);
#endif
#else // vert perf
	return half4(0.5, 0.5, 0.5, 1);
#endif
}

#endif // WATER_COMMON_INCLUDED