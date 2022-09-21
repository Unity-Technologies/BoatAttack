Shader "Custom/RenderFeature/KawaseBlur"
{
    SubShader
    {
        Tags { "RenderType"="Opaque" "RenderPipeline" = "UniversalPipeline"}
        LOD 100
        ZWrite Off Cull Off
        Pass
        {
            Name "ColorBlitPass"

            HLSLPROGRAM
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            // The Blit.hlsl file provides the vertex shader (Vert),
            // input structure (Attributes) and output strucutre (Varyings)
            #include "Packages/com.unity.render-pipelines.core/Runtime/Utilities/Blit.hlsl"

            #pragma vertex Vert
            #pragma fragment frag

            //TEXTURE2D_X(_CameraOpaqueTexture);
            SAMPLER(sampler_BlitTexture);

            float4 _BlitTexture_TexelSize;
            float _offset;

            half4 frag (Varyings input) : SV_Target
            {
                UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(input);

                float2 res = _BlitTexture_TexelSize.xy;
                float i = _offset;
    
                float4 col = 0;
                col.rgb = SAMPLE_TEXTURE2D_X(_BlitTexture, sampler_LinearClamp, input.texcoord);
                col.rgb += SAMPLE_TEXTURE2D_X( _BlitTexture, sampler_LinearClamp, input.texcoord + float2( i, i ) * res ).rgb;
                col.rgb += SAMPLE_TEXTURE2D_X( _BlitTexture, sampler_LinearClamp, input.texcoord + float2( i, -i ) * res ).rgb;
                col.rgb += SAMPLE_TEXTURE2D_X( _BlitTexture, sampler_LinearClamp, input.texcoord + float2( -i, i ) * res ).rgb;
                col.rgb += SAMPLE_TEXTURE2D_X( _BlitTexture, sampler_LinearClamp, input.texcoord + float2( -i, -i ) * res ).rgb;
                col.rgb /= 5.0f;
                
                return col;
            }
            ENDHLSL
        }
    }
}