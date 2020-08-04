Shader "Hidden/PostFX/PseudoLensFlare"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _StarTexture ("StarTex", 2D) = "gray" {}
    }
    HLSLINCLUDE

    #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

    TEXTURE2D(_MainTex); SAMPLER(sampler_MainTex);
    TEXTURE2D(_StarTexture); SAMPLER(sampler_StarTexture);
    #define SampleScene(uv) SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, uv)
    #define Half2Half half2(0.5, 0.5)
    float4 _MainTex_TexelSize;
    float _Power;
    float _Offset;
    float _GhostSpacing;
    const uint _GhostCount;
    float _HaloWidth;

    struct Attributes
    {
        float3 vertex : POSITION;
    };

    struct Varyings
    {
        float4 vertex : SV_POSITION;
        float2 texcoord : TEXCOORD0;
    };

    Varyings VertDefault(Attributes v)
    {
        Varyings o;
        o.vertex = float4(v.vertex.xy * 2.0 - 1.0, 0.0, 1.0);
        o.vertex.y = -o.vertex.y;
        o.texcoord = v.vertex.xy;
        return o;
    }

    ENDHLSL

    SubShader
    {
        Cull Off
        ZWrite Off
        ZTest Always

        Pass
        {
            Name "PseudoFlare"
            Blend One One

            HLSLPROGRAM

            #pragma vertex VertDefault
            #pragma fragment Frag

            half3 Threshold(float3 color, float offset, float power)
            {
                //return color;
                return max(half3(0.0, 0.0, 0.0), color + offset) * power;
            }

            half3 Threshold(float3 color)
            {
                //return color;
                return Threshold(color, _Offset, _Power);
            }

            half3 ChromaticSample(float2 uv, float2 direction, half3 distortion)
            {
                return half3(
                    SampleScene(uv + direction * distortion.r).r,
                    SampleScene(uv + direction * distortion.g).g,
                    SampleScene(uv + direction * distortion.b).b
                );
            }

            half3 GenerateFeatures(float2 uv)
            {
                uv = 1.0 - uv;
                half2 texelSize = _MainTex_TexelSize.xy;

                half2 ghostVec = (Half2Half - uv) * _GhostSpacing;
                half3 result = 0.0;
                for (int i = 0; i < _GhostCount; ++i)
                {
                    half2 offset = frac(uv + ghostVec * float(i));
                    float weight = length(Half2Half - offset) / length(Half2Half);
                    weight = pow(1.0 - weight, 5.0);

                    result += Threshold(SampleScene(offset).xyz) * weight;
                }

                half star = SAMPLE_TEXTURE2D(_StarTexture, sampler_StarTexture, uv);

                half uDistortion = 3.0;
                half3 distortion = half3(-texelSize.x * uDistortion, 0.0, texelSize.x * uDistortion);
                half2 direction = normalize(ghostVec);

                half v = _ScreenParams.y / _ScreenParams.x;
                uv.y = (uv.y - 0.5) * v + 0.5;
                ghostVec.y = ghostVec.y * v;


                float2 haloVec = normalize(ghostVec) * _HaloWidth;
                float weight = length(Half2Half - frac(uv + haloVec)) * 2;
                weight = pow(1.0 - weight, 5.0) * star;
                result += Threshold(ChromaticSample(uv + haloVec, direction, distortion), _Offset, 2 * _Power) * weight;


                return result;
            }

            float4 Frag(Varyings i) : SV_Target
            {
                half3 color = GenerateFeatures(i.texcoord);
                return half4(color, 1.0);
            }

            ENDHLSL
        }

        Pass
        {
            Name "DownscaleBlur"
            HLSLPROGRAM

            #pragma vertex VertDefault
            #pragma fragment Frag

            float _BlurOffset;

            half3 Blur(TEXTURE2D_PARAM(tex, samplerTex), float2 uv, float2 texelSize, float offset)
            {
                float i = offset;

                half3 col;
                col.rgb = SAMPLE_TEXTURE2D( tex, samplerTex, uv ).rgb;
                col.rgb += SAMPLE_TEXTURE2D( tex, samplerTex, uv + float2( i, i ) * texelSize ).rgb;
                col.rgb += SAMPLE_TEXTURE2D( tex, samplerTex, uv + float2( i, -i ) * texelSize ).rgb;
                col.rgb += SAMPLE_TEXTURE2D( tex, samplerTex, uv + float2( -i, i ) * texelSize ).rgb;
                col.rgb += SAMPLE_TEXTURE2D( tex, samplerTex, uv + float2( -i, -i ) * texelSize ).rgb;
                col.rgb /= 5.0f;

                return col;
            }

            float4 Frag(Varyings i) : SV_Target
            {
                half3 color = Blur(_MainTex, sampler_MainTex, i.texcoord, _MainTex_TexelSize.xy, _BlurOffset);
                return half4(color, 1.0);
            }

            ENDHLSL
        }
    }
}
