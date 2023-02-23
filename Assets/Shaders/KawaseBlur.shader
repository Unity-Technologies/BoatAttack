Shader "Custom/RenderFeature/KawaseBlur"
{
    Properties
    {
        [MainTexture]_BlitTexture ("Texture", 2D) = "white" {}
    }

    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            HLSLPROGRAM
            #pragma vertex Vert
            #pragma fragment Frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.core/Runtime/Utilities/Blit.hlsl"

            float4 _BlitTexture_TexelSize;
            float4 _BlitTexture_ST;
            
            float _offset;
            
            half4 Frag (Varyings Input) : SV_Target
            {
                float2 res = _BlitTexture_TexelSize.xy;
                float i = _offset;
    
                half4 col = 1;                
                col.rgb = SAMPLE_TEXTURE2D_X(_BlitTexture, sampler_LinearClamp, Input.texcoord ).rgb;
                col.rgb += SAMPLE_TEXTURE2D_X(_BlitTexture, sampler_LinearClamp, Input.texcoord + float2( i, i ) * res ).rgb;
                col.rgb += SAMPLE_TEXTURE2D_X(_BlitTexture, sampler_LinearClamp, Input.texcoord + float2( i, -i ) * res ).rgb;
                col.rgb += SAMPLE_TEXTURE2D_X(_BlitTexture, sampler_LinearClamp, Input.texcoord + float2( -i, i ) * res ).rgb;
                col.rgb += SAMPLE_TEXTURE2D_X(_BlitTexture, sampler_LinearClamp, Input.texcoord + float2( -i, -i ) * res ).rgb;
                col.rgb /= 5.0f;
                
                return col;
            }
            ENDHLSL
        }
    }
}
