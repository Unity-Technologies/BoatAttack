Shader "PBR Master"
{
	Properties
	{
				[NoScaleOffset] Texture_4CCF661D("splat01", 2D) = "white" {}
				[NoScaleOffset] Texture_E3D097C6("Bush", 2D) = "white" {}
				[NoScaleOffset] Texture_2D2A40E("BushNormal", 2D) = "white" {}
		
	}
	SubShader
	{
		Tags{ "RenderPipeline" = "LightweightPipeline"}
		Tags
		{
			"RenderType"="Opaque"
			"Queue"="Geometry"
		}
		
		Pass
		{
			Tags{"LightMode" = "LightweightForward"}
			
					Blend One Zero
		
					Cull Back
		
					ZTest LEqual
		
					ZWrite On
		
		
			HLSLPROGRAM
		    // Required to compile gles 2.0 with standard srp library
		    #pragma prefer_hlslcc gles
			#pragma target 2.0
		
			// -------------------------------------
			// Lightweight Pipeline keywords
			#pragma multi_compile _ _ADDITIONAL_LIGHTS
			#pragma multi_compile _ _VERTEX_LIGHTS
			#pragma multi_compile _ _MIXED_LIGHTING_SUBTRACTIVE
			#pragma multi_compile _ _SHADOWS_ENABLED
		
			// -------------------------------------
			// Unity defined keywords
			#pragma multi_compile _ DIRLIGHTMAP_COMBINED
			#pragma multi_compile _ LIGHTMAP_ON
			#pragma multi_compile_fog
		
			//--------------------------------------
			// GPU Instancing
			#pragma multi_compile_instancing
		
		    #pragma vertex vert
			#pragma fragment frag
		
			
		
			#include "LWRP/ShaderLibrary/Core.hlsl"
			#include "LWRP/ShaderLibrary/Lighting.hlsl"
			#include "CoreRP/ShaderLibrary/Color.hlsl"
			#include "CoreRP/ShaderLibrary/UnityInstancing.hlsl"
			#include "ShaderGraphLibrary/Functions.hlsl"
		
								TEXTURE2D(Texture_4CCF661D); SAMPLER(samplerTexture_4CCF661D);
							TEXTURE2D(Texture_E3D097C6); SAMPLER(samplerTexture_E3D097C6);
							TEXTURE2D(Texture_2D2A40E); SAMPLER(samplerTexture_2D2A40E);
					
							struct SurfaceInputs{
								float3 ObjectSpaceNormal;
								float3 TangentSpaceNormal;
								float3 ObjectSpaceTangent;
								float3 ObjectSpaceBiTangent;
								float3 WorldSpacePosition;
							};
					
					
					        void Unity_Combine_float(float R, float G, float B, float A, out float4 RGBA, out float3 RGB, out float2 RG)
					        {
					            RGBA = float4(R, G, B, A);
					            RGB = float3(R, G, B);
					            RG = float2(R, G);
					        }
					
							struct GraphVertexInput
							{
								float4 vertex : POSITION;
								float3 normal : NORMAL;
								float4 tangent : TANGENT;
								float4 texcoord1 : TEXCOORD1;
								UNITY_VERTEX_INPUT_INSTANCE_ID
							};
					
							struct SurfaceDescription{
								float3 Albedo;
								float3 Normal;
								float3 Emission;
								float Metallic;
								float Smoothness;
								float Occlusion;
								float Alpha;
								float AlphaClipThreshold;
							};
					
							GraphVertexInput PopulateVertexData(GraphVertexInput v){
								return v;
							}
					
							SurfaceDescription PopulateSurfaceData(SurfaceInputs IN) {
								SurfaceDescription surface = (SurfaceDescription)0;
								float _Split_67AEB824_R = IN.WorldSpacePosition[0];
								float _Split_67AEB824_G = IN.WorldSpacePosition[1];
								float _Split_67AEB824_B = IN.WorldSpacePosition[2];
								float _Split_67AEB824_A = 0;
								float4 _Combine_77E891A3_RGBA;
								float3 _Combine_77E891A3_RGB;
								float2 _Combine_77E891A3_RG;
								Unity_Combine_float(_Split_67AEB824_R, _Split_67AEB824_B, 0, 0, _Combine_77E891A3_RGBA, _Combine_77E891A3_RGB, _Combine_77E891A3_RG);
								float4 _SampleTexture2D_DC0075E6_RGBA = SAMPLE_TEXTURE2D(Texture_E3D097C6, samplerTexture_E3D097C6, _Combine_77E891A3_RG);
								float _SampleTexture2D_DC0075E6_R = _SampleTexture2D_DC0075E6_RGBA.r;
								float _SampleTexture2D_DC0075E6_G = _SampleTexture2D_DC0075E6_RGBA.g;
								float _SampleTexture2D_DC0075E6_B = _SampleTexture2D_DC0075E6_RGBA.b;
								float _SampleTexture2D_DC0075E6_A = _SampleTexture2D_DC0075E6_RGBA.a;
								surface.Albedo = (_SampleTexture2D_DC0075E6_RGBA.xyz);
								surface.Normal = IN.TangentSpaceNormal;
								surface.Emission = IsGammaSpace() ? float3(0, 0, 0) : SRGBToLinear(float3(0, 0, 0));
								surface.Metallic = 0;
								surface.Smoothness = 0.5;
								surface.Occlusion = 1;
								surface.Alpha = 1;
								surface.AlphaClipThreshold = 0;
								return surface;
							}
					
		
		
			struct GraphVertexOutput
		    {
		        float4 clipPos                : SV_POSITION;
		        DECLARE_LIGHTMAP_OR_SH(lightmapUV, vertexSH, 0);
				half4 fogFactorAndVertexLight : TEXCOORD1; // x: fogFactor, yzw: vertex light
		    	#ifdef _SHADOWS_ENABLED
					float4 shadowCoord              : TEXCOORD2;
				#endif
		        			float3 WorldSpaceNormal : TEXCOORD3;
					float3 WorldSpaceTangent : TEXCOORD4;
					float3 WorldSpaceBiTangent : TEXCOORD5;
					float3 WorldSpaceViewDirection : TEXCOORD6;
					float3 WorldSpacePosition : TEXCOORD7;
					half4 uv1 : TEXCOORD8;
		
		        UNITY_VERTEX_INPUT_INSTANCE_ID
		    };
		
		    GraphVertexOutput vert (GraphVertexInput v)
			{
			    v = PopulateVertexData(v);
		
		        GraphVertexOutput o = (GraphVertexOutput)0;
		
		        UNITY_SETUP_INSTANCE_ID(v);
		    	UNITY_TRANSFER_INSTANCE_ID(v, o);
		
		        			o.WorldSpaceNormal = mul(v.normal,(float3x3)UNITY_MATRIX_I_M);
					o.WorldSpaceTangent = mul((float3x3)UNITY_MATRIX_M,v.tangent);
					o.WorldSpaceBiTangent = normalize(cross(o.WorldSpaceNormal, o.WorldSpaceTangent.xyz) * v.tangent.w);
					o.WorldSpaceViewDirection = SafeNormalize(_WorldSpaceCameraPos.xyz - mul(GetObjectToWorldMatrix(), float4(v.vertex.xyz, 1.0)).xyz);
					o.WorldSpacePosition = mul(UNITY_MATRIX_M,v.vertex);
					o.uv1 = v.texcoord1;
		
		
				float3 lwWNormal = TransformObjectToWorldNormal(v.normal);
				float3 lwWorldPos = TransformObjectToWorld(v.vertex.xyz);
				float4 clipPos = TransformWorldToHClip(lwWorldPos);
		
		 		// We either sample GI from lightmap or SH.
			    // Lightmap UV and vertex SH coefficients use the same interpolator ("float2 lightmapUV" for lightmap or "half3 vertexSH" for SH)
		        // see DECLARE_LIGHTMAP_OR_SH macro.
			    // The following funcions initialize the correct variable with correct data
			    OUTPUT_LIGHTMAP_UV(v.texcoord1, unity_LightmapST, o.lightmapUV);
			    OUTPUT_SH(lwWNormal, o.vertexSH);
		
			    half3 vertexLight = VertexLighting(lwWorldPos, lwWNormal);
			    half fogFactor = ComputeFogFactor(clipPos.z);
			    o.fogFactorAndVertexLight = half4(fogFactor, vertexLight);
			    o.clipPos = clipPos;
		
			    #ifdef _SHADOWS_ENABLED
				#if SHADOWS_SCREEN
					o.shadowCoord = ComputeShadowCoord(o.clipPos);
				#else
					o.shadowCoord = TransformWorldToShadowCoord(posWS);
				#endif
				#endif
				return o;
			}
		
			half4 frag (GraphVertexOutput IN) : SV_Target
		    {
		    	UNITY_SETUP_INSTANCE_ID(IN);
		
		    				float3 WorldSpaceNormal = normalize(IN.WorldSpaceNormal);
					float3 WorldSpaceTangent = IN.WorldSpaceTangent;
					float3 WorldSpaceBiTangent = IN.WorldSpaceBiTangent;
					float3 WorldSpaceViewDirection = normalize(IN.WorldSpaceViewDirection);
					float3 WorldSpacePosition = IN.WorldSpacePosition;
					float3x3 tangentSpaceTransform = float3x3(WorldSpaceTangent,WorldSpaceBiTangent,WorldSpaceNormal);
					float3 ObjectSpaceNormal = mul(WorldSpaceNormal,(float3x3)UNITY_MATRIX_M);
					float3 TangentSpaceNormal = mul(WorldSpaceNormal,(float3x3)tangentSpaceTransform);
					float3 ObjectSpaceTangent = mul((float3x3)UNITY_MATRIX_I_M,WorldSpaceTangent);
					float3 ObjectSpaceBiTangent = mul((float3x3)UNITY_MATRIX_I_M,WorldSpaceBiTangent);
					float4 uv1 = IN.uv1;
		
		
		        SurfaceInputs surfaceInput = (SurfaceInputs)0;
		        			surfaceInput.ObjectSpaceNormal = ObjectSpaceNormal;
					surfaceInput.TangentSpaceNormal = TangentSpaceNormal;
					surfaceInput.ObjectSpaceTangent = ObjectSpaceTangent;
					surfaceInput.ObjectSpaceBiTangent = ObjectSpaceBiTangent;
					surfaceInput.WorldSpacePosition = WorldSpacePosition;
		
		
		        SurfaceDescription surf = PopulateSurfaceData(surfaceInput);
		
				float3 Albedo = float3(0.5, 0.5, 0.5);
				float3 Specular = float3(0, 0, 0);
				float Metallic = 1;
				float3 Normal = float3(0, 0, 1);
				float3 Emission = 0;
				float Smoothness = 0.5;
				float Occlusion = 1;
				float Alpha = 1;
				float AlphaClipThreshold = 0;
		
		        			Albedo = surf.Albedo;
					Normal = surf.Normal;
					Emission = surf.Emission;
					Metallic = surf.Metallic;
					Smoothness = surf.Smoothness;
					Occlusion = surf.Occlusion;
					Alpha = surf.Alpha;
					AlphaClipThreshold = surf.AlphaClipThreshold;
		
		
				InputData inputData;
				inputData.positionWS = WorldSpacePosition;
		
		#ifdef _NORMALMAP
			    inputData.normalWS = TangentToWorldNormal(Normal, WorldSpaceTangent, WorldSpaceBiTangent, WorldSpaceNormal);
		#else
		    #if !SHADER_HINT_NICE_QUALITY
		        inputData.normalWS = WorldSpaceNormal;
		    #else
			    inputData.normalWS = normalize(WorldSpaceNormal);
		    #endif
		#endif
		
		#if !SHADER_HINT_NICE_QUALITY
			    // viewDirection should be normalized here, but we avoid doing it as it's close enough and we save some ALU.
			    inputData.viewDirectionWS = WorldSpaceViewDirection;
		#else
			    inputData.viewDirectionWS = normalize(WorldSpaceViewDirection);
		#endif
		
		#ifdef _SHADOWS_ENABLED
		    inputData.shadowCoord = IN.shadowCoord;
		#else
		    inputData.shadowCoord = float4(0, 0, 0, 0);
		#endif
		
			    inputData.fogCoord = IN.fogFactorAndVertexLight.x;
			    inputData.vertexLighting = IN.fogFactorAndVertexLight.yzw;
			    inputData.bakedGI = SAMPLE_GI(IN.lightmapUV, IN.vertexSH, inputData.normalWS);
		
				half4 color = LightweightFragmentPBR(
					inputData, 
					Albedo, 
					Metallic, 
					Specular, 
					Smoothness, 
					Occlusion, 
					Emission, 
					Alpha);
		
				// Computes fog factor per-vertex
		    	ApplyFog(color.rgb, IN.fogFactorAndVertexLight.x);
		
		#if _AlphaClip
				clip(Alpha - AlphaClipThreshold);
		#endif
				return color;
		    }
		
			ENDHLSL
		}
		
		Pass
		{
			Tags{"LightMode" = "ShadowCaster"}
		
			ZWrite On
			ZTest LEqual
					Cull Back
		
		
			HLSLPROGRAM
			// Required to compile gles 2.0 with standard srp library
			#pragma prefer_hlslcc gles
			#pragma target 2.0
		
			//--------------------------------------
			// GPU Instancing
			#pragma multi_compile_instancing
		
			#pragma vertex ShadowPassVertex
			#pragma fragment ShadowPassFragment
		
			#include "LWRP/ShaderLibrary/InputSurfacePBR.hlsl"
			#include "LWRP/ShaderLibrary/LightweightPassShadow.hlsl"
		
			ENDHLSL
		}
		
		Pass
		{
			Tags{"LightMode" = "DepthOnly"}
		
			ZWrite On
					Cull Back
		
			ColorMask 0
		
			HLSLPROGRAM
			// Required to compile gles 2.0 with standard srp library
			#pragma prefer_hlslcc gles
			#pragma target 2.0
		
			#pragma vertex DepthOnlyVertex
			#pragma fragment DepthOnlyFragment
		
			//--------------------------------------
			// GPU Instancing
			#pragma multi_compile_instancing
		
			#include "LWRP/ShaderLibrary/InputSurfacePBR.hlsl"
			#include "LWRP/ShaderLibrary/LightweightPassDepthOnly.hlsl"
			ENDHLSL
		}
		
		// This pass it not used during regular rendering, only for lightmap baking.
		Pass
		{
			Tags{"LightMode" = "Meta"}
		
			Cull Off
		
			HLSLPROGRAM
			// Required to compile gles 2.0 with standard srp library
			#pragma prefer_hlslcc gles
		
			#pragma shader_feature _SPECULAR_SETUP
			#pragma shader_feature _EMISSION
			#pragma shader_feature _METALLICSPECGLOSSMAP
			#pragma shader_feature _ _SMOOTHNESS_TEXTURE_ALBEDO_CHANNEL_A
			#pragma shader_feature EDITOR_VISUALIZATION
		
			#pragma vertex LightweightVertexMeta
			#pragma fragment LightweightFragmentMeta
		
			#pragma shader_feature _SPECGLOSSMAP
		
			 // new
		
			//#include "LWRP/ShaderLibrary/InputSurfacePBR.hlsl"
			#include "LWRP/ShaderLibrary/Core.hlsl"
			#include "LWRP/ShaderLibrary/LightweightPassMetaCommon.hlsl"
			#include "CoreRP/ShaderLibrary/Color.hlsl"
			#include "CoreRP/ShaderLibrary/UnityInstancing.hlsl"
			#include "ShaderGraphLibrary/Functions.hlsl"
			//#include "LWRP/ShaderLibrary/LightweightPassMetaPBR.hlsl"
		
								TEXTURE2D(Texture_4CCF661D); SAMPLER(samplerTexture_4CCF661D);
							TEXTURE2D(Texture_E3D097C6); SAMPLER(samplerTexture_E3D097C6);
							TEXTURE2D(Texture_2D2A40E); SAMPLER(samplerTexture_2D2A40E);
					
							struct SurfaceInputs{
								float3 ObjectSpaceNormal;
								float3 TangentSpaceNormal;
								float3 ObjectSpaceTangent;
								float3 ObjectSpaceBiTangent;
								float3 WorldSpacePosition;
							};
					
					
					        void Unity_Combine_float(float R, float G, float B, float A, out float4 RGBA, out float3 RGB, out float2 RG)
					        {
					            RGBA = float4(R, G, B, A);
					            RGB = float3(R, G, B);
					            RG = float2(R, G);
					        }
					
							struct GraphVertexInput
							{
								float4 vertex : POSITION;
								float3 normal : NORMAL;
								float4 tangent : TANGENT;
								float4 texcoord1 : TEXCOORD1;
								UNITY_VERTEX_INPUT_INSTANCE_ID
							};
					
							struct SurfaceDescription{
								float3 Albedo;
								float3 Normal;
								float3 Emission;
								float Metallic;
								float Smoothness;
								float Occlusion;
								float Alpha;
								float AlphaClipThreshold;
							};
					
							GraphVertexInput PopulateVertexData(GraphVertexInput v){
								return v;
							}
					
							SurfaceDescription PopulateSurfaceData(SurfaceInputs IN) {
								SurfaceDescription surface = (SurfaceDescription)0;
								float _Split_67AEB824_R = IN.WorldSpacePosition[0];
								float _Split_67AEB824_G = IN.WorldSpacePosition[1];
								float _Split_67AEB824_B = IN.WorldSpacePosition[2];
								float _Split_67AEB824_A = 0;
								float4 _Combine_77E891A3_RGBA;
								float3 _Combine_77E891A3_RGB;
								float2 _Combine_77E891A3_RG;
								Unity_Combine_float(_Split_67AEB824_R, _Split_67AEB824_B, 0, 0, _Combine_77E891A3_RGBA, _Combine_77E891A3_RGB, _Combine_77E891A3_RG);
								float4 _SampleTexture2D_DC0075E6_RGBA = SAMPLE_TEXTURE2D(Texture_E3D097C6, samplerTexture_E3D097C6, _Combine_77E891A3_RG);
								float _SampleTexture2D_DC0075E6_R = _SampleTexture2D_DC0075E6_RGBA.r;
								float _SampleTexture2D_DC0075E6_G = _SampleTexture2D_DC0075E6_RGBA.g;
								float _SampleTexture2D_DC0075E6_B = _SampleTexture2D_DC0075E6_RGBA.b;
								float _SampleTexture2D_DC0075E6_A = _SampleTexture2D_DC0075E6_RGBA.a;
								surface.Albedo = (_SampleTexture2D_DC0075E6_RGBA.xyz);
								surface.Normal = IN.TangentSpaceNormal;
								surface.Emission = IsGammaSpace() ? float3(0, 0, 0) : SRGBToLinear(float3(0, 0, 0));
								surface.Metallic = 0;
								surface.Smoothness = 0.5;
								surface.Occlusion = 1;
								surface.Alpha = 1;
								surface.AlphaClipThreshold = 0;
								return surface;
							}
					
		 // new
		
			half4 LightweightFragmentMeta(MetaVertexOuput IN) : SV_Target
			{
				float4 uv0 = float4(IN.uv, 0, 0);
		
		        SurfaceInputs surfaceInput = (SurfaceInputs)0;
		        			surfaceInput.ObjectSpaceNormal = ObjectSpaceNormal;
					surfaceInput.TangentSpaceNormal = TangentSpaceNormal;
					surfaceInput.ObjectSpaceTangent = ObjectSpaceTangent;
					surfaceInput.ObjectSpaceBiTangent = ObjectSpaceBiTangent;
					surfaceInput.WorldSpacePosition = WorldSpacePosition;
		
		
		        SurfaceDescription surf = PopulateSurfaceData(surfaceInput);
		
				float3 Albedo = float3(0.5, 0.5, 0.5);
				float3 Specular = float3(0, 0, 0);
				float Metallic = 1;
				float3 Normal = float3(0, 0, 1);
				float3 Emission = 0;
				float Smoothness = 0.5;
				float Occlusion = 1;
				float Alpha = 1;
				float AlphaClipThreshold = 0;
		
		        			Albedo = surf.Albedo;
					Normal = surf.Normal;
					Emission = surf.Emission;
					Metallic = surf.Metallic;
					Smoothness = surf.Smoothness;
					Occlusion = surf.Occlusion;
					Alpha = surf.Alpha;
					AlphaClipThreshold = surf.AlphaClipThreshold;
		

				MetaInput o;
				o.Albedo = surf.Albedo;
				o.SpecularColor = 0;
				o.Emission = surf.Emission;
		
				return MetaFragment(o);
			}
		
			ENDHLSL
		}
		
	}
	
	FallBack "Hidden/InternalErrorShader"
}
