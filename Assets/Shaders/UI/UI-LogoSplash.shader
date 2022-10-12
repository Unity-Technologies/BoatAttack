Shader "Boat Attack/UI/Splash"
{
    Properties
    {
        [MainTexture]_BaseMap ("Texture", 2D) = "white" {}
        _Speed ("Speed", float) = 20.0
        _Offset ("Offset", float) = 12
        _Threshold ("Threshold", float) = 0.5
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
                float4 animUV : TEXCOORD1;
                half4 color : COLOR;
            };

            TEXTURE2D(_BaseMap); SAMPLER(sampler_BaseMap);
            half4 _BaseMap_ST;
            half _Speed;
            half _Threshold;
            half _Offset;
            
            Varyings vert (Attributes input)
            {
                Varyings output = (Varyings)0;
                
                const VertexPositionInputs vertexInput = GetVertexPositionInputs(input.positionOS.xyz);
                output.positionCS = vertexInput.positionCS;
                output.uv = input.uv;
                output.animUV = TRANSFORM_TEX(input.uv, _BaseMap).xyxy;
                output.animUV.xz += _Offset;
                output.animUV.x += _Time.x * _Speed;
                output.animUV.z += _Time.x * _Speed * 0.7;
                
                output.color = input.color;
                
                return output;
            }

            half4 frag (Varyings input) : SV_Target
            {
                half4 output = input.color;

                half2 uv = input.uv;
                half accel = pow(uv.x * 1.6, 0.6);
                input.animUV.xz = frac(input.animUV.xz) - accel * 0.25;
                
                //input.animUV.xz = frac(input.animUV.xz);
                half a = 1 - SAMPLE_TEXTURE2D(_BaseMap, sampler_BaseMap, input.animUV.xy).x;
                
                half frontFade = saturate((1-uv.x) * 3 + 0.5);
                half rearFade = pow(saturate(uv.x * 0.8 + 0.2), 0.6) + 0.15;
                
                a *= min(frontFade, rearFade - 0.2);
                
                output.a *= smoothstep(_Threshold, _Threshold + 0.01, pow(a, 4));
                
                half frame = smoothstep(0.97, 0.98, max(abs(uv.x * 2 - 1),abs(uv.y * 2 - 1)));
                
                return output;// + frame;
                return half4(input.animUV.xy, 0, 1) + frame;
            }
            ENDHLSL
        }
    }
}
