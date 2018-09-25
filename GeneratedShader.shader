Shader "PBR Master"
{
	Properties
	{
				[NoScaleOffset] Texture_CA4EFDF0("Normal", 2D) = "white" {}
		
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
			#pragma target 3.0
		
		    // -------------------------------------
		    // Lightweight Pipeline keywords
		    // We have no good approach exposed to skip shader variants, e.g, ideally we would like to skip _CASCADE for all puctual lights
		    // Lightweight combines light classification and shadows keywords to reduce shader variants.
		    // Lightweight shader library declares defines based on these keywords to avoid having to check them in the shaders
		    // Core.hlsl defines _MAIN_LIGHT_DIRECTIONAL and _MAIN_LIGHT_SPOT (point lights can't be main light)
		    // Shadow.hlsl defines _SHADOWS_ENABLED, _SHADOWS_SOFT, _SHADOWS_CASCADE, _SHADOWS_PERSPECTIVE
		    #pragma multi_compile _ _MAIN_LIGHT_DIRECTIONAL_SHADOW _MAIN_LIGHT_DIRECTIONAL_SHADOW_CASCADE _MAIN_LIGHT_DIRECTIONAL_SHADOW_SOFT _MAIN_LIGHT_DIRECTIONAL_SHADOW_CASCADE_SOFT _MAIN_LIGHT_SPOT_SHADOW _MAIN_LIGHT_SPOT_SHADOW_SOFT
		    #pragma multi_compile _ _MAIN_LIGHT_COOKIE
		    #pragma multi_compile _ _ADDITIONAL_LIGHTS
		    #pragma multi_compile _ _VERTEX_LIGHTS
		    #pragma multi_compile _ _MIXED_LIGHTING_SUBTRACTIVE
		    #pragma multi_compile _ FOG_LINEAR FOG_EXP2
		
		    // -------------------------------------
		    // Unity defined keywords
		    #pragma multi_compile _ UNITY_SINGLE_PASS_STEREO STEREO_INSTANCING_ON STEREO_MULTIVIEW_ON
		    #pragma multi_compile _ DIRLIGHTMAP_COMBINED LIGHTMAP_ON
		
		    //--------------------------------------
		    // GPU Instancing
		    #pragma multi_compile_instancing
		
		    // LW doesn't support dynamic GI. So we save 30% shader variants if we assume
		    // LIGHTMAP_ON when DIRLIGHTMAP_COMBINED is set
		    #ifdef DIRLIGHTMAP_COMBINED
		    #define LIGHTMAP_ON
		    #endif
		
		    #pragma vertex vert
			#pragma fragment frag
		
						#define _NORMALMAP 1
		
		
			#include "Packages/com.unity.render-pipelines.lightweight/ShaderLibrary/Core.hlsl"
			#include "Packages/com.unity.render-pipelines.lightweight/ShaderLibrary/Lighting.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/UnityInstancing.hlsl"
			#include "ShaderGraphLibrary/Functions.hlsl"
		
								TEXTURE2D(Texture_CA4EFDF0); SAMPLER(samplerTexture_CA4EFDF0);
							float4 _SampleTexture2D_C5B52E0_UV;
							float4 _PBRMaster_98E8DF63_Albedo;
							float4 _PBRMaster_98E8DF63_Emission;
							float _PBRMaster_98E8DF63_Metallic;
							float _PBRMaster_98E8DF63_Smoothness;
							float _PBRMaster_98E8DF63_Occlusion;
							float _PBRMaster_98E8DF63_Alpha;
							float _PBRMaster_98E8DF63_AlphaClipThreshold;
					
							struct SurfaceInputs{
								half4 uv0;
							};
					
							struct GraphVertexInput
							{
								float4 vertex : POSITION;
								float3 normal : NORMAL;
								float4 tangent : TANGENT;
								float4 texcoord0 : TEXCOORD0;
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
								float4 _SampleTexture2D_C5B52E0_RGBA = SAMPLE_TEXTURE2D(Texture_CA4EFDF0, samplerTexture_CA4EFDF0, IN.uv0.xy);
								_SampleTexture2D_C5B52E0_RGBA.rgb = UnpackNormalmapRGorAG(_SampleTexture2D_C5B52E0_RGBA);
								float _SampleTexture2D_C5B52E0_R = _SampleTexture2D_C5B52E0_RGBA.r;
								float _SampleTexture2D_C5B52E0_G = _SampleTexture2D_C5B52E0_RGBA.g;
								float _SampleTexture2D_C5B52E0_B = _SampleTexture2D_C5B52E0_RGBA.b;
								float _SampleTexture2D_C5B52E0_A = _SampleTexture2D_C5B52E0_RGBA.a;
								surface.Albedo = _PBRMaster_98E8DF63_Albedo;
								surface.Normal = (_SampleTexture2D_C5B52E0_RGBA.xyz);
								surface.Emission = _PBRMaster_98E8DF63_Emission;
								surface.Metallic = _PBRMaster_98E8DF63_Metallic;
								surface.Smoothness = _PBRMaster_98E8DF63_Smoothness;
								surface.Occlusion = _PBRMaster_98E8DF63_Occlusion;
								surface.Alpha = _PBRMaster_98E8DF63_Alpha;
								surface.AlphaClipThreshold = _PBRMaster_98E8DF63_AlphaClipThreshold;
								return surface;
							}
					
		
		
			struct GraphVertexOutput
		    {
		        float4 clipPos                : SV_POSITION;
		        float4 lightmapUVOrVertexSH   : TEXCOORD0;
				half4 fogFactorAndVertexLight : TEXCOORD1; // x: fogFactor, yzw: vertex light
		    	float4 shadowCoord            : TEXCOORD2;
		        			float3 WorldSpaceNormal : TEXCOORD3;
					float3 WorldSpaceTangent : TEXCOORD4;
					float3 WorldSpaceBiTangent : TEXCOORD5;
					float3 WorldSpaceViewDirection : TEXCOORD6;
					float3 WorldSpacePosition : TEXCOORD7;
					half4 uv0 : TEXCOORD8;
					half4 uv1 : TEXCOORD9;
		
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
					o.uv0 = v.texcoord0;
					o.uv1 = v.texcoord1;
		
		
				float3 lwWNormal = TransformObjectToWorldNormal(v.normal);
				float3 lwWorldPos = TransformObjectToWorld(v.vertex.xyz);
				float4 clipPos = TransformWorldToHClip(lwWorldPos);
		
		 		// We either sample GI from lightmap or SH. lightmap UV and vertex SH coefficients
			    // are packed in lightmapUVOrVertexSH to save interpolator.
			    // The following funcions initialize
			    OUTPUT_LIGHTMAP_UV(v.texcoord1, unity_LightmapST, o.lightmapUVOrVertexSH);
			    OUTPUT_SH(lwWNormal, o.lightmapUVOrVertexSH);
		
			    half3 vertexLight = VertexLighting(lwWorldPos, lwWNormal);
			    half fogFactor = ComputeFogFactor(clipPos.z);
			    o.fogFactorAndVertexLight = half4(fogFactor, vertexLight);
			    o.clipPos = clipPos;
		
		#if defined(_SHADOWS_ENABLED) && !defined(_SHADOWS_CASCADE)
			    o.shadowCoord = ComputeShadowCoord(lwWorldPos);
		#else
				o.shadowCoord = float4(0, 0, 0, 0);
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
					float4 uv0 = IN.uv0;
					float4 uv1 = IN.uv1;
		
		
		        SurfaceInputs surfaceInput = (SurfaceInputs)0;
		        			surfaceInput.uv0 = uv0;
		
		
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
			    inputData.normalWS = normalize(WorldSpaceNormal);
		#endif
		
		#ifdef SHADER_API_MOBILE
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
			    inputData.bakedGI = SampleGI(IN.lightmapUVOrVertexSH, inputData.normalWS);
		
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
		
		    ZWrite On ZTest LEqual
		
		    HLSLPROGRAM
		    // Required to compile gles 2.0 with standard srp library
		    #pragma prefer_hlslcc gles
		    #pragma target 2.0
		
		    //--------------------------------------
		    // GPU Instancing
		    #pragma multi_compile_instancing
		
		    #pragma vertex ShadowPassVertex
		    #pragma fragment ShadowPassFragment
		
		    #include "Packages/com.unity.render-pipelines.lightweight/ShaderLibrary/LightweightPassShadow.hlsl"
		    ENDHLSL
		}
		
		Pass
		{
		    Tags{"LightMode" = "DepthOnly"}
		
		    ZWrite On
		    ColorMask 0
		
		    HLSLPROGRAM
		    // Required to compile gles 2.0 with standard srp library
		    #pragma prefer_hlslcc gles
		    #pragma target 2.0
		    #pragma vertex vert
		    #pragma fragment frag
		
		    #include "Packages/com.unity.render-pipelines.lightweight/ShaderLibrary/Core.hlsl"
		
		    float4 vert(float4 pos : POSITION) : SV_POSITION
		    {
		        return TransformObjectToHClip(pos.xyz);
		    }
		
		    half4 frag() : SV_TARGET
		    {
		        return 0;
		    }
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
		
		    #pragma vertex LightweightVertexMeta
		    #pragma fragment LightweightFragmentMeta
		
		    #pragma shader_feature _SPECULAR_SETUP
		    #pragma shader_feature _EMISSION
		    #pragma shader_feature _METALLICSPECGLOSSMAP
		    #pragma shader_feature _ _SMOOTHNESS_TEXTURE_ALBEDO_CHANNEL_A
		    #pragma shader_feature EDITOR_VISUALIZATION
		
		    #pragma shader_feature _SPECGLOSSMAP
		
		    #include "Packages/com.unity.render-pipelines.lightweight/ShaderLibrary/LightweightPassMeta.hlsl"
		    ENDHLSL
		}
	}
	
}
