Shader "BoatAttack/Water"
{
	Properties
	{
		_BumpScale("Detail Wave Amount", Range(0, 2)) = 0.2//fine detail multiplier
	}
	SubShader
	{
		Tags { "RenderType"="Transparent" "Queue"="Transparent-100" "RenderPipeline" = "LightweightPipeline" }
		ZWrite On

		Pass
		{
			Name "WaterShading"
			Tags{"LightMode" = "LightweightForward"}

			HLSLPROGRAM
			#pragma prefer_hlslcc gles
			/////////////////SHADER FEATURES//////////////////
			#pragma shader_feature _REFLECTION_CUBEMAP _REFLECTION_PROBES _REFLECTION_PLANARREFLECTION
			#pragma multi_compile _ FOG_LINEAR FOG_EXP2
			#pragma multi_compile _ USE_STRUCTURED_BUFFER

			//--------------------------------------
            // GPU Instancing
            #pragma multi_compile_instancing

			////////////////////INCLUDES//////////////////////
			#include "WaterCommon.hlsl"

			//non-tess
			#pragma vertex WaterVertex
			#pragma fragment WaterFragment

			ENDHLSL
		}
	}
	FallBack "Hidden/InternalErrorShader"
}
