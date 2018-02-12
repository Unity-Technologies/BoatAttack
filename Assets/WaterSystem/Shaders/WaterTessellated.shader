Shader "BoatAttack/WaterTessellated"
{
	Properties
	{
		_TessellationEdgeLength ("Tessellation Edge Length", Range(5, 100)) = 50
		//[NoScaleOffset]
		//_ColorRamp("Color Ramp", 2D) = "grey" {}
		[NoScaleOffset]
		_BumpMap("Detail Wave Normal", 2D) = "bump" {}
		_BumpScale("Detail Wave Amount", Range(0, 1)) = 0.2//fine detail multiplier
		[NoScaleOffset]
		_FoamMap("Foam Texture", 2D) = "black" {}
		[KeywordEnum(Cubemap, Probes, PlanarReflection)]
		_Reflection ("ReflectionMode", float) = 0
	}
	SubShader
	{
		Tags { "RenderType"="Transparent" "Queue"="Transparent" "RenderPipeline" = "LightweightPipeline" }
		LOD 300
		ZWrite Off

		Pass
		{
			Name "WaterShading"

			HLSLPROGRAM 
			#pragma require tessellation tessHW

			/////////////////SHADER FEATURES//////////////////
			#pragma shader_feature _ _TESSELLATION
			
			#pragma shader_feature _REFLECTION_CUBEMAP _REFLECTION_PROBES _REFLECTION_PLANARREFLECTION
			#pragma multi_compile _ FOG_LINEAR FOG_EXP2

			#define _TESSELLATION 1

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
