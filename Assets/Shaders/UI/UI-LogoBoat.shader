Shader "Boat Attack/UI/Boat"
{
    Properties
    {
        _Speed ("Speed", float) = 20.0
    }
    SubShader
    {
        Tags{"Queue"="Transparent" "RenderPipeline" = "Universal"}
        LOD 100
        
        Cull Off
        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            float4 RotateAroundYInDegrees (float4 vertex, float degrees)
             {
                 float alpha = degrees * PI / 180.0;
                 float sina, cosa;
                 sincos(alpha, sina, cosa);
                 float2x2 m = float2x2(cosa, -sina, sina, cosa);
                 return float4(mul(m, vertex.xz), vertex.yw).xzyw;
             }
            
            struct Attributes
            {
                float4 positionOS : POSITION;
                float2 uv : TEXCOORD0;
                half4 color : COLOR;
            };

            struct Varyings
            {
                float4 positionCS : SV_POSITION;
                float2 uv : TEXCOORD0;
                half4 color : COLOR;
            };

            half _Speed;
            float4 _ClipRect;
            
            Varyings vert (Attributes input)
            {
                Varyings output = (Varyings)0;

                //input.positionOS = RotateAroundYInDegrees(input.positionOS, _Time.x * 1000);
                const VertexPositionInputs vertexInput = GetVertexPositionInputs(input.positionOS.xyz);
                output.positionCS = vertexInput.positionCS;
                output.uv = input.uv;
                
                output.color = input.color;
                
                return output;
            }

            half4 frag (Varyings input) : SV_Target
            {
                half4 output = input.color;
                
                //return output;
                return _ClipRect;
                return half4(input.uv, 0, 1);
            }
            ENDHLSL
        }
    }
}
