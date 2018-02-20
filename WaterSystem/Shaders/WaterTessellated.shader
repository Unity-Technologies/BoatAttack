Shader "BoatAttack/WaterTessellated"
{
	Properties
	{
		_TessellationEdgeLength ("Tessellation Edge Length", Range(5, 100)) = 50
		[NoScaleOffset]
		_BumpMap("Detail Wave Normal", 2D) = "bump" {}
		_BumpScale("Detail Wave Amount", Range(0, 1)) = 0.2//fine detail multiplier
		[NoScaleOffset]
		_FoamMap("Foam Texture", 2D) = "black" {}
		[KeywordEnum(Cubemap, Probes, PlanarReflection)]
		_Reflection ("ReflectionMode", float) = 0
		[Header(Debug)]
		[Toggle(_DEBUG)]
        _Debug ("Debug Rendering", Float) = 0
		[KeywordEnum(Final, Reflection, Color, Depth, WaterFX, Normals, Fresnel, Specular, Temporary)]
		_DebugPass ("Debug Mode", Float) = 0
		// Remove after testing
		[Toggle(_PERF_REF)]
		_Perf_Ref ("Perf Reflection", float) = 0
		[Toggle(_PERF_COL)]
		_Perf_Col ("Perf Color", float) = 0
		[Toggle(_PERF_DEPTH)]
		_Perf_Depth ("Perf Depth", float) = 0
		[Toggle(_PERF_VERT)]
		_Perf_Vert ("Perf Vert", float) = 0
		[Toggle(_PERF_LIGHTING)]
		_Perf_Light ("Perf Lighting", float) = 0
		[Toggle(_PERF_FRESNEL)]
		_Perf_Fres ("Perf Fresnel", float) = 0
		[Toggle(_PERF_GERSTNER)]
		_Perf_Gerstner ("Perf Gerstner Waves", float) = 0
		[Toggle(_PERF_FOAM)]
		_Perf_Foam ("Perf Foam", float) = 0
	}
	SubShader
	{
		Tags { "RenderType"="Transparent" "Queue"="Transparent-500" "RenderPipeline" = "LightweightPipeline" }
		LOD 300
		ZWrite Off

		Pass
		{
			Name "WaterShading"

			HLSLPROGRAM 
			#pragma require tessellation tessHW

			/////////////////SHADER FEATURES//////////////////
			#pragma shader_feature _ _TESSELLATION
			#define _TESSELLATION 1
			#pragma shader_feature _ _DEBUG
			
			#pragma shader_feature _REFLECTION_CUBEMAP _REFLECTION_PROBES _REFLECTION_PLANARREFLECTION
			#pragma multi_compile _ FOG_LINEAR FOG_EXP2

			///////////////PERF SHADER FEATURES///////////////
			#pragma multi_compile _ _PERF_REF 
			#pragma multi_compile _ _PERF_COL
			#pragma multi_compile _ _PERF_DEPTH
			#pragma multi_compile _ _PERF_VERT
			#pragma multi_compile _ _PERF_LIGHTING
			#pragma multi_compile _ _PERF_FRESNEL 
			#pragma multi_compile _ _PERF_GERSTNER
			#pragma multi_compile _ _PERF_FOAM

			////////////////////INCLUDES//////////////////////
			#include "WaterCommon.hlsl"
			#include "WaterTessellation.hlsl"

			#pragma vertex TessellationVertex
			#pragma hull Hull
			#pragma domain Domain
			#pragma fragment WaterFragment

			ENDHLSL
		}
	}
	Fallback "BoatAttack/Water"
}
