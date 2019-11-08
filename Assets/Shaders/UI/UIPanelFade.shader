Shader "UIPanelFade"
{
    Properties
    {
        [NoScaleOffset]_MainTex("Texture2D", 2D) = "white" {}
        Vector1_7563C2A4("Rotate", Range(-1, 1)) = 0
        Vector1_68A27D51("Vertical Position", Range(-1, 1)) = 0
        Vector1_5A14D1F("Horizontal Position", Range(-1, 1)) = 0
        Vector1_C4B0954B("Width", Range(0.001, 0.5)) = 0.5
        [Toggle]BOOLEAN_6EC3160E("Mirror", Float) = 0
    }
    SubShader
    {
        Tags
        {
            "RenderPipeline"="UniversalPipeline"
            "RenderType"="Transparent"
            "Queue"="Transparent+0"
        }
        
        Pass
        {
            Name "Pass"
           
            // Render State
            Blend SrcAlpha OneMinusSrcAlpha, One OneMinusSrcAlpha
            ZTest LEqual
            ZWrite Off
        
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
        
            // Debug
            // <None>
        
            // --------------------------------------------------
            // Pass
        
            // Pragmas
            #pragma prefer_hlslcc gles
            #pragma exclude_renderers d3d11_9x
            #pragma target 2.0
            #pragma multi_compile_instancing
        
            // Keywords
            #pragma multi_compile_local _ BOOLEAN_6EC3160E_ON
            
            #if defined(BOOLEAN_6EC3160E_ON)
                #define KEYWORD_PERMUTATION_0
            #else
                #define KEYWORD_PERMUTATION_1
            #endif

            // Includes
            #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.shadergraph/ShaderGraphLibrary/Functions.hlsl" 
        
            // --------------------------------------------------
            // Graph
        
            // Graph Properties
            CBUFFER_START(UnityPerMaterial)
            float Vector1_7563C2A4;
            float Vector1_68A27D51;
            float Vector1_5A14D1F;
            float Vector1_C4B0954B;
            CBUFFER_END
            TEXTURE2D(_MainTex); SAMPLER(sampler_MainTex); float4 _MainTex_TexelSize;

            // Graph Functions
            
            void Unity_Multiply_float (float4 A, float4 B, out float4 Out)
            {
                Out = A * B;
            }
            
            void DoubleOffset_float(float Base, float Difference, float Spread, out float2 Output1, out float2 Output2)
            {
                float a = Base - Difference;
                float b = Base + Difference;
                Output1 = float2(a - Spread, a + Spread);
                Output2 = float2(b - Spread, b + Spread);
            }
            
            void Unity_Combine_float(float R, float G, float B, float A, out float4 RGBA, out float3 RGB, out float2 RG)
            {
                RGBA = float4(R, G, B, A);
                RGB = float3(R, G, B);
                RG = float2(R, G);
            }
            
            void Unity_Add_float2(float2 A, float2 B, out float2 Out)
            {
                Out = A + B;
            }
            
            void Unity_Multiply_float (float A, float B, out float Out)
            {
                Out = A * B;
            }
            
            void Unity_Sine_float(float In, out float Out)
            {
                Out = sin(In);
            }
            
            void Unity_Cosine_float(float In, out float Out)
            {
                Out = cos(In);
            }
            
            void Unity_DotProduct_float2(float2 A, float2 B, out float Out)
            {
                Out = dot(A, B);
            }
            
            void Unity_Negate_float(float In, out float Out)
            {
                Out = -1 * In;
            }
            
            void Unity_Remap_float(float In, float2 InMinMax, float2 OutMinMax, out float Out)
            {
                Out = OutMinMax.x + (In - InMinMax.x) * (OutMinMax.y - OutMinMax.x) / (InMinMax.y - InMinMax.x);
            }
            
            void Unity_Subtract_float(float A, float B, out float Out)
            {
                Out = A - B;
            }
            
            void Unity_Absolute_float(float In, out float Out)
            {
                Out = abs(In);
            }
            
            void Unity_OneMinus_float(float In, out float Out)
            {
                Out = 1 - In;
            }
            
            void Unity_Fraction_float(float In, out float Out)
            {
                Out = frac(In);
            }
            
            void Unity_TilingAndOffset_float(float2 UV, float2 Tiling, float2 Offset, out float2 Out)
            {
                Out = UV * Tiling + Offset;
            }
            
            void Unity_Fraction_float2(float2 In, out float2 Out)
            {
                Out = frac(In);
            }
            
            void Unity_Distance_float2(float2 A, float2 B, out float Out)
            {
                Out = distance(A, B);
            }
            
            void Unity_Smoothstep_float(float Edge1, float Edge2, float In, out float Out)
            {
                Out = smoothstep(Edge1, Edge2, In);
            }
            
            void Unity_Lerp_float(float A, float B, float T, out float Out)
            {
                Out = lerp(A, B, T);
            }
        
            // Graph Vertex
            // GraphVertex: <None>
            
            // Graph Pixel
            struct SurfaceDescriptionInputs
            {
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                float3 WorldSpacePosition;
                #endif
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                float4 ScreenPosition;
                #endif
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                float4 uv0;
                #endif
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                float4 VertexColor;
                #endif
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                float3 TimeParameters;
                #endif
            };
            
            struct SurfaceDescription
            {
                float3 Color;
                float Alpha;
                float AlphaClipThreshold;
            };
            
            SurfaceDescription SurfaceDescriptionFunction(SurfaceDescriptionInputs IN)
            {
                SurfaceDescription surface = (SurfaceDescription)0;
                
                float4 _SampleTexture2D_3F8012CB_RGBA_0 = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, IN.uv0.xy);
                
                float4 _Multiply_DC665A75_Out_2 = _SampleTexture2D_3F8012CB_RGBA_0 * IN.VertexColor;
                
                float2 _CustomFunction_7C9152A9_Output1_3;
                float2 _CustomFunction_7C9152A9_Output2_4;
                DoubleOffset_float(0.5, 0.1, 0.025, _CustomFunction_7C9152A9_Output1_3, _CustomFunction_7C9152A9_Output2_4);

                float _Split_EEFEE03_R_1 = _CustomFunction_7C9152A9_Output1_3[0];
                float _Split_EEFEE03_G_2 = _CustomFunction_7C9152A9_Output1_3[1];

                float4 _ScreenPosition_12892564_Out_0 = float4(IN.ScreenPosition.xy / IN.ScreenPosition.w * 2 - 1, 0, 0);

                float _Property_5C60C246_Out_0 = Vector1_5A14D1F;

                float _Property_3F977C49_Out_0 = Vector1_68A27D51;


                float2 _Combine_E68203FD_RG_6 = float2(_Property_5C60C246_Out_0, _Property_3F977C49_Out_0);

                float2 _Add_FEFB160D_Out_2 = _ScreenPosition_12892564_Out_0.xy + _Combine_E68203FD_RG_6;

                float _Property_6A5FA02B_Out_0 = Vector1_7563C2A4;

                float Constant_84BE6CB2 = 3.141593;
                float _Multiply_166E8FF_Out_2 = _Property_6A5FA02B_Out_0 * 3.141593;
                
                float _Sine_56DCCE92_Out_1 = sin(_Multiply_166E8FF_Out_2);
                float _Cosine_6C98699_Out_1 = cos(_Multiply_166E8FF_Out_2);
                
                float2 _Combine_68A71F78_RG_6 = float2(_Sine_56DCCE92_Out_1, _Cosine_6C98699_Out_1);
                
                float _DotProduct_4DFAA7CA_Out_2 = dot(_Add_FEFB160D_Out_2, _Combine_68A71F78_RG_6);
                
                float _Property_24F8BD8_Out_0 = Vector1_C4B0954B;
                
                float _Negate_4B7B6518_Out_1 = -_Property_24F8BD8_Out_0;
                
                float2 _Combine_AF3296E0_RG_6 = float2(_Negate_4B7B6518_Out_1, _Property_24F8BD8_Out_0);
                
                float _Remap_BF9AE274_Out_3;
                Unity_Remap_float(_DotProduct_4DFAA7CA_Out_2, _Combine_AF3296E0_RG_6, float2 (0, 1), _Remap_BF9AE274_Out_3);
                
                float _Subtract_44AA391B_Out_2 = _Remap_BF9AE274_Out_3 - _Property_24F8BD8_Out_0;
                
                float _Absolute_9E656538_Out_1 = abs(_Subtract_44AA391B_Out_2);
                
                float _OneMinus_24EECD6E_Out_1 = 1 - _Absolute_9E656538_Out_1;
                #if defined(BOOLEAN_6EC3160E_ON)
                float _Mirror_9ABF97A9_Out_0 = _OneMinus_24EECD6E_Out_1;
                #else
                float _Mirror_9ABF97A9_Out_0 = _Remap_BF9AE274_Out_3;
                #endif
                
                float4 _ScreenPosition_91DE393A_Out_0 = frac(float4((IN.ScreenPosition.x / IN.ScreenPosition.w * 2 - 1) * _ScreenParams.x / _ScreenParams.y, IN.ScreenPosition.y / IN.ScreenPosition.w * 2 - 1, 0, 0));

                float _Vector1_90CE3AFA_Out_0 = 10;
                
                float _Fraction_961F0992_Out_1 = frac(IN.TimeParameters.x);
                
                float _OneMinus_47E6415F_Out_1 = 1 - _Fraction_961F0992_Out_1;
                
                float2 _Combine_34F01114_RG_6 = float2(_OneMinus_47E6415F_Out_1, 0);
                
                float2 _TilingAndOffset_820AA504_Out_3;
                Unity_TilingAndOffset_float((_ScreenPosition_91DE393A_Out_0.xy), (_Vector1_90CE3AFA_Out_0.xx), _Combine_34F01114_RG_6, _TilingAndOffset_820AA504_Out_3);

                float2 _Fraction_85BF219B_Out_1 = frac(_TilingAndOffset_820AA504_Out_3);
                
                float _Vector1_A80C0185_Out_0 = 0.5;
                
                float _Distance_7440F14A_Out_2 = distance(_Fraction_85BF219B_Out_1, _Vector1_A80C0185_Out_0.xx);
                
                float _Remap_52B43685_Out_3;
                Unity_Remap_float(_Distance_7440F14A_Out_2, float2 (0.5, 1), float2 (1, 0), _Remap_52B43685_Out_3);
                
                float _Multiply_7481105A_Out_2 = _Mirror_9ABF97A9_Out_0 * _Remap_52B43685_Out_3;
                
                float _Smoothstep_FC6FA553_Out_3 = smoothstep(_Split_EEFEE03_R_1, _Split_EEFEE03_G_2, _Multiply_7481105A_Out_2);

                float _Smoothstep_1D4A479B_Out_3 = smoothstep(_CustomFunction_7C9152A9_Output2_4.x, _CustomFunction_7C9152A9_Output2_4.y, _Multiply_7481105A_Out_2);

                float _Lerp_C33B85D8_Out_3 = lerp(_Smoothstep_FC6FA553_Out_3, _Smoothstep_1D4A479B_Out_3, 0.5);

                surface.Color = _Multiply_DC665A75_Out_2.xyz;
                surface.Alpha = _Multiply_DC665A75_Out_2.a * _Lerp_C33B85D8_Out_3;
                surface.AlphaClipThreshold = 0;
                return surface;
            }
        
            // --------------------------------------------------
            // Structs and Packing
        
            // Generated Type: Attributes
            struct Attributes
            {
                float3 positionOS : POSITION;
                float3 normalOS : NORMAL;
                float4 tangentOS : TANGENT;
                float4 uv0 : TEXCOORD0;
                float4 color : COLOR;
            };
        
            // Generated Type: Varyings
            struct Varyings
            {
                float4 positionCS : SV_Position;
                float3 positionWS;
                float4 texCoord0;
                float4 color;
            };
            
            // Generated Type: PackedVaryings
            struct PackedVaryings
            {
                float4 positionCS : SV_Position;
                float3 interp00 : TEXCOORD0;
                float4 interp01 : TEXCOORD1;
                float4 interp02 : TEXCOORD2;
            };
            
            // Packed Type: Varyings
            PackedVaryings PackVaryings(Varyings input)
            {
                PackedVaryings output;
                output.positionCS = input.positionCS;
                output.interp00.xyz = input.positionWS;
                output.interp01.xyzw = input.texCoord0;
                output.interp02.xyzw = input.color;
                #if UNITY_ANY_INSTANCING_ENABLED
                output.instanceID = input.instanceID;
                #endif
                #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
                output.cullFace = input.cullFace;
                #endif
                return output;
            }
            
            // Unpacked Type: Varyings
            Varyings UnpackVaryings(PackedVaryings input)
            {
                Varyings output;
                output.positionCS = input.positionCS;
                output.positionWS = input.interp00.xyz;
                output.texCoord0 = input.interp01.xyzw;
                output.color = input.interp02.xyzw;
                #if UNITY_ANY_INSTANCING_ENABLED
                output.instanceID = input.instanceID;
                #endif
                #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
                output.cullFace = input.cullFace;
                #endif
                return output;
            }
        
            // --------------------------------------------------
            // Build Graph Inputs
        
            SurfaceDescriptionInputs BuildSurfaceDescriptionInputs(Varyings input)
            {
                SurfaceDescriptionInputs output;
                ZERO_INITIALIZE(SurfaceDescriptionInputs, output);
            output.WorldSpacePosition =          input.positionWS;
            output.ScreenPosition =              ComputeScreenPos(TransformWorldToHClip(input.positionWS), _ProjectionParams.x);
            output.uv0 =                         input.texCoord0;
            output.VertexColor =                 input.color;
            output.TimeParameters =              _TimeParameters.xyz; // This is mainly for LW as HD overwrite this value
                return output;
            }
            
        
            // --------------------------------------------------
            // Main
        
            #include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/Varyings.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/UnlitPass.hlsl"
        
            ENDHLSL
        }
    }
    FallBack "Hidden/InternalErrorShader"
}
