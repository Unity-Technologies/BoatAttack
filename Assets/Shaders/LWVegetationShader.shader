Shader "BoatAttack/LWVegetationShader"
{
    Properties
    {
        // Specular vs Metallic workflow
        [HideInInspector] _WorkflowMode("WorkflowMode", Float) = 1.0

        _Color("Color", Color) = (1,1,1,1)
        _MainTex("Albedo", 2D) = "white" {}

        _Cutoff("Alpha Cutoff", Range(0.0, 1.0)) = 0.5

        _Glossiness("Smoothness", Range(0.0, 1.0)) = 0.5
        _GlossMapScale("Smoothness Scale", Range(0.0, 1.0)) = 1.0
        _SmoothnessTextureChannel("Smoothness texture channel", Float) = 0

        [Gamma] _Metallic("Metallic", Range(0.0, 1.0)) = 0.0
        _MetallicGlossMap("Metallic", 2D) = "white" {}

        _SpecColor("Specular", Color) = (0.2, 0.2, 0.2)
        _SpecGlossMap("Specular", 2D) = "white" {}

        [ToggleOff] _SpecularHighlights("Specular Highlights", Float) = 1.0
        [ToggleOff] _GlossyReflections("Glossy Reflections", Float) = 1.0

        _BumpScale("Scale", Float) = 1.0
        _BumpMap("Normal Map", 2D) = "bump" {}

        _OcclusionStrength("Strength", Range(0.0, 1.0)) = 1.0
        _OcclusionMap("Occlusion", 2D) = "white" {}

        _EmissionColor("Color", Color) = (0,0,0)
        _EmissionMap("Emission", 2D) = "white" {}

        // Blending state
        [HideInInspector] _Mode("__mode", Float) = 0.0
        [HideInInspector] _SrcBlend("__src", Float) = 1.0
        [HideInInspector] _DstBlend("__dst", Float) = 0.0
        [HideInInspector] _ZWrite("__zw", Float) = 1.0
    }

    SubShader
    {
        // Lightweight Pipeline tag is required. If Lightweight pipeline is not set in the graphics settings
        // this Subshader will fail. One can add a subshader below or fallback to Standard built-in to make this
        // material work with both Lightweight Pipeline and Builtin Unity Pipeline
        Tags{"RenderType" = "Opaque" "RenderPipeline" = "LightweightPipeline"}

        // ------------------------------------------------------------------
        //  Base forward pass (directional light, emission, lightmaps, ...)
        Pass
        {
            // Lightmode matches the ShaderPassName set in LightweightPipeline.cs. SRPDefaultUnlit and passes with
            // no LightMode tag are also rendered by Lightweight Pipeline
            Tags{"LightMode" = "LightweightForward"}

            Blend[_SrcBlend][_DstBlend]
            ZWrite[_ZWrite]
            Cull Off

            HLSLPROGRAM
            // Required to compile gles 2.0 with standard SRP library
            // All shaders must be compiled with HLSLcc and currently only gles is not using HLSLcc by default
            #pragma prefer_hlslcc gles
            #pragma target 3.0

            // -------------------------------------
            // Material Keywords
            #pragma shader_feature _NORMALMAP
            #pragma shader_feature _ _ALPHATEST_ON _ALPHABLEND_ON _ALPHAPREMULTIPLY_ON
            #pragma shader_feature _EMISSION
            #pragma shader_feature _METALLICSPECGLOSSMAP
            #pragma shader_feature _SMOOTHNESS_TEXTURE_ALBEDO_CHANNEL_A
            #define _OCCLUSIONMAP

            #pragma shader_feature _SPECULARHIGHLIGHTS_OFF
            #pragma shader_feature _GLOSSYREFLECTIONS_OFF
            #pragma shader_feature _SPECULAR_SETUP

            // -------------------------------------
            // Lightweight Pipeline keywords
            #pragma multi_compile _ _ADDITIONAL_LIGHTS
            #pragma multi_compile _ _VERTEX_LIGHTS
            #pragma multi_compile _ _MIXED_LIGHTING_SUBTRACTIVE
            #pragma multi_compile _ FOG_LINEAR FOG_EXP2

            // -------------------------------------
            // Unity defined keywords
            #pragma multi_compile _ DIRLIGHTMAP_COMBINED
            #pragma multi_compile _ LIGHTMAP_ON

            //--------------------------------------
            // GPU Instancing
            #pragma multi_compile_instancing

            // LW doesn't support dynamic GI. So we save 30% shader variants if we assume
            // LIGHTMAP_ON when DIRLIGHTMAP_COMBINED is set
            #ifdef DIRLIGHTMAP_COMBINED
            #define LIGHTMAP_ON
            #endif

            // Including the following two function is enought for shading with Lightweight Pipeline. Everything is included in them.
            // Core.hlsl will include SRP shader library, all constant buffers not related to materials (perobject, percamera, perframe).
            // It also includes matrix/space conversion functions and fog.
            // Lighting.hlsl will include the light functions/data to abstract light constants. You should use GetMainLight and GetLight functions
            // that initialize Light struct. Lighting.hlsl also include GI, Light BDRF functions. It also includes Shadows.
            #include "LWRP/ShaderLibrary/Core.hlsl"
            #include "LWRP/ShaderLibrary/Lighting.hlsl"

			#pragma vertex VegetationVertex
			#pragma fragment LitPassFragment
        
			float4 SmoothCurve( float4 x ) {
				return x * x *( 3.0 - 2.0 * x );
			}

			float4 TriangleWave( float4 x ) {
				return abs( frac( x + 0.5 ) * 2.0 - 1.0 );
			}

			float4 SmoothTriangleWave( float4 x ) {
				return SmoothCurve( TriangleWave( x ) );
			}

			struct LightweightVertexInput
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
				float4 tangent : TANGENT;
				float2 texcoord : TEXCOORD0;
				float2 lightmapUV : TEXCOORD1;
				float4 color : COLOR;
                UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct VegetationVertexOutput
			{
				float3 uv                       : TEXCOORD0;//z holds vert AO
				float4 lightmapUVOrVertexSH     : TEXCOORD1; // holds either lightmapUV or vertex SH. depending on LIGHTMAP_ON
				float3 positionWS               : TEXCOORD2;
				half3  normal                   : TEXCOORD3;

			#if _NORMALMAP
				half3 tangent                   : TEXCOORD4;
				half3 binormal                  : TEXCOORD5;
			#endif

				half3 viewDir                   : TEXCOORD6;
				half4 fogFactorAndVertexLight   : TEXCOORD7; // x: fogFactor, yzw: vertex light

				float4 clipPos                  : SV_POSITION;
                half occlusion                  : TEXCOORD8;
                UNITY_VERTEX_INPUT_INSTANCE_ID
			};

            // Not required but included here for simplicity. This defines all material related constants for the Standard surface shader like _Color, _MainTex, and so on.
            // These are specific to this shader. You should define your own constants.
            #include "LWRP/ShaderLibrary/InputSurface.hlsl"

            UNITY_INSTANCING_BUFFER_START(Props)
                UNITY_DEFINE_INSTANCED_PROP(half4, _Position)
            UNITY_INSTANCING_BUFFER_END(Props)

			//vert
			VegetationVertexOutput VegetationVertex(LightweightVertexInput v)
			{
				VegetationVertexOutput o = (VegetationVertexOutput)0;

                UNITY_SETUP_INSTANCE_ID(v);
    	        UNITY_TRANSFER_INSTANCE_ID(v, o);
                // Pretty much same as builtin Unity shader library.
				o.uv.xy = TRANSFORM_TEX(v.texcoord, _MainTex);

                // SRP shader library adds some functions to convert between spaces.
                // TransformObjectToHClip and some other functions are defined.
                o.positionWS = TransformObjectToWorld(v.vertex.xyz);
                o.clipPos = TransformWorldToHClip(o.positionWS);

				/////////////////////////////////////vegetation stuff//////////////////////////////////////////////////
                //half phaseOffset = UNITY_ACCESS_INSTANCED_PROP(Props, _PhaseOffset);
                float4 objectOrigin = UNITY_ACCESS_INSTANCED_PROP(Props, _Position);

				///////Main Bending
				float fBendScale = 0.05;//main bend opacity
				float fLength = length(v.vertex.xyz);//distance to origin
				float2 vWind = float2(sin(_Time.y + objectOrigin.x) * 0.1, sin(_Time.y + objectOrigin.z) * 0.1);//wind direction

				// Bend factor - Wind variation is done on the CPU.
				float fBF = v.vertex.y * fBendScale;
				// Smooth bending factor and increase its nearby height limit.
				fBF += 1.0;
				fBF *= fBF;
				fBF = fBF * fBF - fBF;
				// Displace position
				float3 vNewPos = v.vertex.xyz;
				vNewPos.xz += vWind.xy * fBF;
				// Rescale
				v.vertex.xyz = normalize(vNewPos.xyz) * fLength;

				////////Detail blending
				float fSpeed = 0.25;//leaf occil
				float fDetailFreq = 0.3;//detail leaf occil
				float fEdgeAtten = v.color.x;//leaf stiffness(red)
				float fDetailAmp = 0.1;//leaf edge amplitude of movement
				float fBranchAtten = 1 - v.color.z;//branch stiffness(blue)
				float fBranchAmp = 1.5;//branch amplitude of movement
				float fBranchPhase = v.color.y * 3.3;//leaf phase(green)

				// Phases (object, vertex, branch)
				float fObjPhase = dot(objectOrigin.xyz, 1);
				fBranchPhase += fObjPhase;
				float fVtxPhase = dot(v.vertex.xyz, v.color.y + fBranchPhase);
				// x is used for edges; y is used for branches
				float2 vWavesIn = _Time.y + float2(fVtxPhase, fBranchPhase );
				// 1.975, 0.793, 0.375, 0.193 are good frequencies
				float4 vWaves = (frac( vWavesIn.xxyy * float4(1.975, 0.793, 0.375, 0.193) ) * 2.0 - 1.0 ) * fSpeed * fDetailFreq;
				vWaves = SmoothTriangleWave( vWaves );
				float2 vWavesSum = vWaves.xz + vWaves.yw;
				// Edge (xy) and branch bending (z)
				v.vertex.xyz += vWavesSum.xyx * float3(fEdgeAtten * fDetailAmp * v.normal.x, fBranchAtten * fBranchAmp, fEdgeAtten * fDetailAmp * v.normal.z);


				//////////////////////////////////////////////////////////////////////////////////////////////////////

				o.positionWS = TransformObjectToWorld(v.vertex.xyz);
				o.clipPos = TransformWorldToHClip(o.positionWS);
				o.viewDir = SafeNormalize(_WorldSpaceCameraPos - o.positionWS);

				// initializes o.normal and if _NORMALMAP also o.tangent and o.binormal
                #ifdef _NORMALMAP
                                OutputTangentToWorld(v.tangent, v.normal, o.tangent, o.binormal, o.normal);
                #else
                                o.normal = TransformObjectToWorldNormal(v.normal);
                #endif

				// We either sample GI from lightmap or SH. lightmap UV and vertex SH coefficients
				// are packed in lightmapUVOrVertexSH to save interpolator.
				// The following funcions initialize
				OUTPUT_LIGHTMAP_UV(v.lightmapUV, unity_LightmapST, o.lightmapUVOrVertexSH);
				OUTPUT_SH(o.normal, o.lightmapUVOrVertexSH);

				half3 vertexLight = VertexLighting(o.positionWS, o.normal);
				half fogFactor = ComputeFogFactor(o.clipPos.z);
				o.fogFactorAndVertexLight = half4(fogFactor, vertexLight);

                o.occlusion = v.color.a;

				return o;
			}

			//frag
            half4 LitPassFragment(VegetationVertexOutput IN, half facing : VFACE) : SV_Target
			{
                UNITY_SETUP_INSTANCE_ID(IN);
				SurfaceData surfaceData;
				InitializeStandardLitSurfaceData(IN.uv.xy, surfaceData);

			#if _NORMALMAP
				half3 normalWS = TangentToWorldNormal(surfaceData.normalTS, IN.tangent, IN.binormal, IN.normal);
			#else
				half3 normalWS = normalize(IN.normal);
			#endif

                half3 bakedGI = SampleSH(normalWS);

                surfaceData.albedo *= IN.occlusion;

                BRDFData brdfData;
                InitializeBRDFData(surfaceData.albedo, surfaceData.metallic, surfaceData.specular, surfaceData.smoothness, surfaceData.alpha, brdfData);

                Light mainLight = GetMainLight(IN.positionWS);

				half3 color = GlobalIllumination(brdfData, bakedGI, surfaceData.occlusion, normalWS * facing, IN.viewDir);

				float fogFactor = IN.fogFactorAndVertexLight.x;

                color += LightingPhysicallyBased(brdfData, mainLight, normalWS * facing, IN.viewDir);
				
                // Computes fog factor per-vertex
				ApplyFog(color.rgb, fogFactor);
				return half4(color, surfaceData.alpha);
			}

            ENDHLSL
        }

Pass
        {
            Tags{"LightMode" = "ShadowCaster"}

            ZWrite On
            ZTest LEqual

            HLSLPROGRAM
            // Required to compile gles 2.0 with standard srp library
            #pragma prefer_hlslcc gles
            #pragma target 2.0
            
            // -------------------------------------
            // Material Keywords
            #pragma shader_feature _NORMALMAP
            #pragma shader_feature _ _ALPHATEST_ON _ALPHABLEND_ON _ALPHAPREMULTIPLY_ON
            #pragma shader_feature _EMISSION
            #pragma shader_feature _METALLICSPECGLOSSMAP
            #pragma shader_feature _SMOOTHNESS_TEXTURE_ALBEDO_CHANNEL_A
            #pragma shader_feature _OCCLUSIONMAP

            #pragma shader_feature _SPECULARHIGHLIGHTS_OFF
            #pragma shader_feature _GLOSSYREFLECTIONS_OFF
            #pragma shader_feature _SPECULAR_SETUP

            //--------------------------------------
            // GPU Instancing
            #pragma multi_compile_instancing

            #pragma vertex ShadowPassVertex
            #pragma fragment ShadowPassFragment

            #include "LWRP/ShaderLibrary/LightweightPassShadow.hlsl"
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
            
            // -------------------------------------
            // Material Keywords
            #pragma shader_feature _NORMALMAP
            #pragma shader_feature _ _ALPHATEST_ON _ALPHABLEND_ON _ALPHAPREMULTIPLY_ON
            #pragma shader_feature _EMISSION
            #pragma shader_feature _METALLICSPECGLOSSMAP
            #pragma shader_feature _SMOOTHNESS_TEXTURE_ALBEDO_CHANNEL_A
            #pragma shader_feature _OCCLUSIONMAP

            #pragma shader_feature _SPECULARHIGHLIGHTS_OFF
            #pragma shader_feature _GLOSSYREFLECTIONS_OFF
            #pragma shader_feature _SPECULAR_SETUP

            //--------------------------------------
            // GPU Instancing
            #pragma multi_compile_instancing

            #pragma vertex DepthOnlyVertex
            #pragma fragment DepthOnlyFragment

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

            #pragma vertex LightweightVertexMeta
            #pragma fragment LightweightFragmentMeta

            #pragma shader_feature _SPECULAR_SETUP
            #pragma shader_feature _EMISSION
            #pragma shader_feature _METALLICSPECGLOSSMAP
            #pragma shader_feature _ _SMOOTHNESS_TEXTURE_ALBEDO_CHANNEL_A
            #pragma shader_feature EDITOR_VISUALIZATION

            #pragma shader_feature _SPECGLOSSMAP

            #include "LWRP/ShaderLibrary/LightweightPassMeta.hlsl"
            ENDHLSL
        }

    }
    FallBack "Hidden/InternalErrorShader"
}
