Shader "Hidden/PostFX/PseudoLensFlare"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    HLSLINCLUDE
    
    #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
    
    TEXTURE2D(_MainTex); SAMPLER(sampler_MainTex);
    float _Blend;
    
    struct Attributes
    {
        float3 vertex : POSITION;
    };
    
    struct Varyings
    {
        float4 vertex : SV_POSITION;
        float2 texcoord : TEXCOORD0;
    };
    
    float4 Frag(Varyings i) : SV_Target
    {
    float4 color = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord);
    float luminance = dot(color.rgb, float3(0.2126729, 0.7151522, 0.0721750));
    color.rgb = lerp(color.rgb, luminance.xxx, _Blend.xxx);
    return color;
    }
    
    ENDHLSL
    
    SubShader
    {
        Cull Off ZWrite Off ZTest Always
        
        Pass
        {
            HLSLPROGRAM
            
            #pragma vertex VertDefault
            #pragma fragment Frag
            
            Varyings VertDefault(Attributes v)
            {
                Varyings o;
                o.vertex = float4(v.vertex.xy * 2.0 - 1.0, 0.0, 1.0);
                o.texcoord = v.vertex.xy;
                return o;
            }
            
            ENDHLSL
        }
    }
}
