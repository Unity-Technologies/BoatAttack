Shader "Boat Attack/UI/ButtonOutline"
{
    Properties
    {
        [HideInInspector]_MainTex("MainTex", 2D) = "white" {}
        _Thickness("Thickness", float) = 20
        [NoAlpha]_OutlineColor("Color", color) = (1, 1, 1)
        [Toggle(_SCREEN_FADE)] _FadeEdges("Fade Screen Edges", Float) = 0
        [Toggle(_IMAGE_COLOR)] _ImageColor("Use Image Color", Float) = 0
        [Toggle(_ALPHA_WIDTH)] _AlphaWidth("Alpha as Width", Float) = 0
    }
    SubShader
    {
        Tags
        {
            "RenderPipeline"="UniversalPipeline"
            "Queue"="Transparent"
        }
        Pass
        {
            Name "UI Outline"
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            Cull Off

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma shader_feature _SCREEN_FADE
            #pragma shader_feature _IMAGE_COLOR
            #pragma shader_feature _ALPHA_WIDTH

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            float2 DDXY(float2 In)
            {
                return abs(ddx(In)) + abs(ddy(In));
            }
            
            float Rectangle(float2 UV, float2 Size)
            {
                float2 d = abs(UV * 2 - 1) - Size;
                d = saturate(1 - d / fwidth(d));
                return min(d.x, d.y);
            }
            
            struct Attributes
            {
                float4 positionOS : POSITION;
                float2 uv : TEXCOORD0;
                float4 color : COLOR;
            };

            struct Varyings
            {
                float4 positionCS : SV_POSITION;
                float2 uv : TEXCOORD0;
                float4 color : TEXCOORD1;
                float3 positionNDC : TEXCOORD2;
            };

            CBUFFER_START(UnityPerMaterial)
            half _Thickness;
            half3 _OutlineColor;
            float4 _MainTex_ST;
            CBUFFER_END
            
            TEXTURE2D(_MainTex); SAMPLER(sampler_MainTex);

            Varyings vert (Attributes input)
            {
                Varyings output;
                VertexPositionInputs vertexInput = GetVertexPositionInputs(input.positionOS.xyz);

                output.positionCS = vertexInput.positionCS;
                output.positionNDC = vertexInput.positionNDC;
                output.uv = input.uv;
                output.color = input.color;
                return output;
            }

            real4 frag (Varyings input) : SV_Target
            {
                real4 color = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, input.uv);
                #ifndef _IMAGE_COLOR
                color *= input.color;
                #endif
                half alpha = color.a;
                

                half t = _Thickness;
                #ifdef _ALPHA_WIDTH
                t = input.color.a * 100;
                alpha = 1;
                #endif

                real2 ddxy = DDXY(input.uv);
                real2 rectUV = 1 - ddxy * t;
                half outline = 1 - Rectangle(input.uv, rectUV);

                // soft edge
                half softEdge = Rectangle(input.uv, 1 - ddxy * 2);
                
                #ifdef _SCREEN_FADE
                // fade screen edges
                half screenFade = pow(1 - saturate(abs(input.positionNDC.x * 2 - 1) * 4 - 2), 2.2);
                alpha *= screenFade;
                #endif

                #ifdef _IMAGE_COLOR
                half3 outlineColor = input.color.rgb;
                #else
                half3 outlineColor = _OutlineColor;
                #endif
                
                alpha *= softEdge;
                
                return real4(lerp(color.xyz, outlineColor, outline), alpha);
            }
            ENDHLSL
        }
    }
    FallBack "Hidden/InternalErrorShader"
}
