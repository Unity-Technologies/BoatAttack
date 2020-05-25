Shader "Unlit/SobelFilter"
{
	Properties 
	{
	    [HideInInspector]_MainTex ("Base (RGB)", 2D) = "white" {}
		_Delta ("Line Thickness", Range(0.0005, 0.0025)) = 0.001
		[Toggle(RAW_OUTLINE)]_Raw ("Outline Only", Float) = 0
		[Toggle(POSTERIZE)]_Poseterize ("Posterize", Float) = 0
		_PosterizationCount ("Count", float) = 8
	}
	SubShader 
	{
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		Pass
		{
            HLSLPROGRAM
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/SurfaceInput.hlsl"
            #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
            
            #pragma shader_feature RAW_OUTLINE
            #pragma shader_feature POSTERIZE
            
            TEXTURE2D(_CameraDepthTexture);
            SAMPLER(sampler_CameraDepthTexture);
            
#ifndef RAW_OUTLINE
            TEXTURE2D(_MainTex);
            SAMPLER(sampler_MainTex);
#endif
            float _Delta;
            int _PosterizationCount;
            
            struct Attributes
            {
                float4 positionOS       : POSITION;
                float2 uv               : TEXCOORD0;
            };

            struct Varyings
            {
                float2 uv        : TEXCOORD0;
                float4 vertex : SV_POSITION;
                UNITY_VERTEX_OUTPUT_STEREO
            };
            
            float SampleDepth(float2 uv)
            {
#if defined(UNITY_STEREO_INSTANCING_ENABLED) || defined(UNITY_STEREO_MULTIVIEW_ENABLED)
                return SAMPLE_TEXTURE2D_ARRAY(_CameraDepthTexture, sampler_CameraDepthTexture, uv, unity_StereoEyeIndex).r;
#else
                return SAMPLE_DEPTH_TEXTURE(_CameraDepthTexture, sampler_CameraDepthTexture, uv);
#endif
            }
            
            float sobel (float2 uv) 
            {
                float2 delta = float2(_Delta, _Delta);
                
                float hr = 0;
                float vt = 0;
                
                hr += SampleDepth(uv + float2(-1.0, -1.0) * delta) *  1.0;
                hr += SampleDepth(uv + float2( 1.0, -1.0) * delta) * -1.0;
                hr += SampleDepth(uv + float2(-1.0,  0.0) * delta) *  2.0;
                hr += SampleDepth(uv + float2( 1.0,  0.0) * delta) * -2.0;
                hr += SampleDepth(uv + float2(-1.0,  1.0) * delta) *  1.0;
                hr += SampleDepth(uv + float2( 1.0,  1.0) * delta) * -1.0;
                
                vt += SampleDepth(uv + float2(-1.0, -1.0) * delta) *  1.0;
                vt += SampleDepth(uv + float2( 0.0, -1.0) * delta) *  2.0;
                vt += SampleDepth(uv + float2( 1.0, -1.0) * delta) *  1.0;
                vt += SampleDepth(uv + float2(-1.0,  1.0) * delta) * -1.0;
                vt += SampleDepth(uv + float2( 0.0,  1.0) * delta) * -2.0;
                vt += SampleDepth(uv + float2( 1.0,  1.0) * delta) * -1.0;
                
                return sqrt(hr * hr + vt * vt);
            }
            
            Varyings vert(Attributes input)
            {
                Varyings output = (Varyings)0;
                UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(output);

                VertexPositionInputs vertexInput = GetVertexPositionInputs(input.positionOS.xyz);
                output.vertex = vertexInput.positionCS;
                output.uv = input.uv;
                
                return output;
            }
            
            half4 frag (Varyings input) : SV_Target 
            {
                UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(input);
                
                float s = pow(1 - saturate(sobel(input.uv)), 50);
#ifdef RAW_OUTLINE
                return half4(s.xxx, 1);
#else
                half4 col = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, input.uv);
#ifdef POSTERIZE
                col = pow(col, 0.4545);
                float3 c = RgbToHsv(col);
                c.z = round(c.z * _PosterizationCount) / _PosterizationCount;
                col = float4(HsvToRgb(c), col.a);
                col = pow(col, 2.2);
#endif
                return col * s;
#endif
            }
            
			#pragma vertex vert
			#pragma fragment frag
			
			ENDHLSL
		}
	} 
	FallBack "Diffuse"
}
