Shader "BoatAttack/WaterTessellated"
{
	Properties
	{
		_TessellationEdgeLength ("Tessellation Edge Length", Range(5, 100)) = 50
		_BumpScale("Detail Wave Amount", Range(0, 1)) = 0.2//fine detail multiplier
	}
	SubShader
	{
		Tags { "RenderType"="Transparent" "Queue"="Transparent-100" "RenderPipeline" = "LightweightPipeline" }
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
						
			#pragma shader_feature _REFLECTION_CUBEMAP _REFLECTION_PROBES _REFLECTION_PLANARREFLECTION
			#pragma multi_compile _ FOG_LINEAR FOG_EXP2

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
	fallback "BoatAttack/Water"
}
