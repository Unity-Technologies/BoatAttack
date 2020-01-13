Shader "Boat Attack/UI/Halftone Fade"
{
    Properties
    {
        _Rotation("Rotate", Range(-1, 1)) = 0
        _OffsetX("Offset Horizontal", Range(-1, 1)) = 0
        _OffsetY("Offset Vertical", Range(-1, 1)) = 0
        _Width("Width", Range(0.01, 1)) = 0.1
    }
    SubShader
    {
        Tags
        {
            "RenderPipeline"="UniversalPipeline"
            "RenderType"="Transparent-10"
        }

        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha
            Cull Off

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            float Remap(float In, float2 InMinMax, float2 OutMinMax)
            {
                return OutMinMax.x + (In - InMinMax.x) * (OutMinMax.y - OutMinMax.x) / (InMinMax.y - InMinMax.x);
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

            half _Rotation;
            half _OffsetX;
            half _OffsetY;
            half _Width;

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
                // sample the texture
                real4 color = input.color;;

                // Halftone
                float2 centerScreenPos = float2((input.screenPos.x / input.screenPos.w * 2 - 1) * _ScreenParams.x / _ScreenParams.y, input.screenPos.y / input.screenPos.w * 2 - 1);
                float halftone = distance(frac((centerScreenPos + half2(-_Time.x, 0)) * 10), 0.5);
                halftone = Remap(halftone, float2(0.5, 1), float2(1, 0));

                // Gradient
                half rotate = _Rotation * 3.1425;
                half2 gradientCoords = input.uv; // ((input.screenPos.xy / input.screenPos.w) * 2 - 1;
                half gradient = dot(gradientCoords + half2(_OffsetX, _OffsetY), half2(sin(rotate), cos(rotate)));
                gradient = Remap(gradient, float2(-_Width, _Width), float2(0, 1));

                half base = 0.5;
                half diff = 0.1;
                half spread = 0.02;

                float a = smoothstep(base - diff - spread, base - diff + spread, halftone * gradient);
                float b = smoothstep(base + diff - spread, base + diff + spread, halftone * gradient);

                color.a *= lerp(a, b, 0.5);

                return color;
            }
            ENDHLSL
        }
    }
    FallBack "Hidden/InternalErrorShader"
}
