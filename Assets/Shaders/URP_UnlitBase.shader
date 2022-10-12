Shader "Unlit/URP_UnlitBase"
{
    Properties
    {
        [MainTexture]_BaseMap ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags{"RenderType" = "Opaque" "RenderPipeline" = "Universal" "IgnoreProjector" = "True"}
        LOD 100

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
            };

            struct Varyings
            {
                float4 positionCS : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            TEXTURE2D(_BaseMap); SAMPLER(sampler_BaseMap);
            
            Varyings vert (Attributes input)
            {
                Varyings output = (Varyings)0;
                
                const VertexPositionInputs vertexInput = GetVertexPositionInputs(input.positionOS.xyz);
                output.positionCS = vertexInput.positionCS;
                output.uv = input.uv;
                
                return output;
            }

            half4 frag (Varyings input) : SV_Target
            {
                half4 baseMap = SAMPLE_TEXTURE2D(_BaseMap, sampler_BaseMap, input.uv);
                return baseMap;
            }
            ENDHLSL
        }
    }
}
