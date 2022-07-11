Shader "Boat Attack/UI/ButtonExtrusion"
{
    Properties
    {
        [HideInInspector][NoScaleOffset]_MainTex("MainTex", 2D) = "white" {}
        [Toggle(_SCREEN_FADE)] _FadeEdges("Fade Screen Edges", Float) = 0
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
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            Cull Off

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma shader_feature _SCREEN_FADE

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            CBUFFER_START(UnityPerMaterial)
            half2 _Offset;
            half2 _Size;
            half2 _SelfSize;
            half2 _Skew;
            CBUFFER_END
            
            float2 ProcessUV(float2 UV, float2 input)
            {
                return UV - (input / _Size - _Skew.yx);
            }
            
            float2 Rotate(float2 UV, float Rotation)
            {
                //rotation matrix
                float s = sin(Rotation);
                float c = cos(Rotation);
            
                //center rotation matrix
                float2x2 rMatrix = float2x2(c, -s, s, c);
                rMatrix *= 0.5;
                rMatrix += 0.5;
                rMatrix = rMatrix*2 - 1;
            
                //multiply the UVs by the rotation matrix
                UV.xy = mul(UV.xy, rMatrix);
            
                return UV;
            }

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

            half ProcessCorner(float2 UV, float Rotation)
            {
                //half edge = ceil(Rotate(UV, Rotation).y);
                half edge = smoothstep(-0.005, 0.0, Rotate(UV, Rotation).y);
                return saturate(edge);
            }

            struct Attributes
            {
                float4 positionOS : POSITION;
                float2 uv : TEXCOORD0;
                float4 color : COLOR;
            };

            struct Varyings
            {
                float2 uv : TEXCOORD0;
                float4 screenPos : TEXCOORD1;
                float4 color : TEXCOORD2;
                float4 positionCS : SV_POSITION;
            };
            
            Varyings vert (Attributes input)
            {
                Varyings output;
                VertexPositionInputs vertexInput = GetVertexPositionInputs(input.positionOS.xyz);

                output.positionCS = vertexInput.positionCS;
                output.uv = input.uv;
                output.color = input.color;
                output.screenPos = ComputeScreenPos(vertexInput.positionCS);
                return output;
            }

            real4 frag (Varyings input) : SV_Target
            {
                real4 color = input.color;

                // UVs
                float2 uvA = ProcessUV(input.uv, _SelfSize + _Offset);
                float2 uvB = ProcessUV(input.uv, _Offset);

                // Rotation
                float rotation = dot(normalize(_Offset), half2(0, 1)) * HALF_PI;
                
                // outer edge
                half outer = saturate(length(smoothstep(half2(-0.001, -0.01), 0, uvA)));

                // corners
                half cornerA = ProcessCorner(float2(uvA.x, uvB.y), rotation);
                half cornerB = ProcessCorner(float2(uvB.x, uvA.y), rotation);

                // soft edge
                half softEdge = Rectangle(input.uv, 1 - DDXY(input.uv));

                #ifdef _SCREEN_FADE
                // fade screen edges
                half screenFade = pow(1 - saturate(abs(input.screenPos.x * 2 - 1) * 4 - 2), 2.2);
                color.a *= screenFade;
                #endif
                                
                color.a *= (1 - max(outer, cornerB)) * cornerA * softEdge;
                return color;
            }
            ENDHLSL
        }
    }
    FallBack "Hidden/InternalErrorShader"
}
