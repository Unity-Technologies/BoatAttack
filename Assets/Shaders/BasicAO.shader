Shader "Hidden/Post/BasicAO"
{
    HLSLINCLUDE
        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

        TEXTURE2D(_MainTex); SAMPLER(sampler_MainTex);
        TEXTURE2D(_NoiseTex); SAMPLER(sampler_NoiseTex);
        TEXTURE2D(_CameraDepthTexture); SAMPLER(sampler_CameraDepthTexture);
        
        float _Blend;
        float _Intensity;
        
        float3 normal_from_depth(float depth, float2 texcoords) 
        {
          const float2 offset1 = float2(0.0,0.001);
          const float2 offset2 = float2(0.001,0.0);
          
          float depth1 = LinearEyeDepth(SAMPLE_DEPTH_TEXTURE(_CameraDepthTexture, sampler_CameraDepthTexture, texcoords + offset1).r);
          float depth2 = LinearEyeDepth(SAMPLE_DEPTH_TEXTURE(_CameraDepthTexture, sampler_CameraDepthTexture, texcoords + offset2).r);
          
          float3 p1 = float3(offset1, depth1 - depth);
          float3 p2 = float3(offset2, depth2 - depth);
          
          float3 normal = cross(p1, p2);
          normal.z = -normal.z;
          
          return normalize(normal);
        }

        float4 Frag(VaryingsDefault i) : SV_Target
        {
            float side = round(1-i.texcoord.x);
//            
//            float3 d1 = Linear01Depth(SAMPLE_DEPTH_TEXTURE(_CameraDepthTexture, sampler_CameraDepthTexture, i.texcoord).rrr) * (1 - side);
//            float3 d2 = LinearEyeDepth(SAMPLE_DEPTH_TEXTURE(_CameraDepthTexture, sampler_CameraDepthTexture, i.texcoord).rrr) * side;
//            d2 /= 10000;
//            
//            d1.x = frac(d1.x);
//            d1.z = frac(d1.z * 10);
//            d2.x = frac(d2.x);
//            d2.z = frac(d2.z * 10);
//            
//            return float4(d1 + d2, 1);
        
            /*float4 color = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord);
            float luminance = dot(color.rgb, float3(0.2126729, 0.7151522, 0.0721750));
            color.rgb = lerp(color.rgb, luminance.xxx, _Blend.xxx);
            return color;*/
            float4 color = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord) * (1 - side);
            
            const float base = 0.1;
            
            const float area = 50;
            const float falloff = 0.5;
            
            const float radius = 2;
            
            const int samples = 16;
            float3 sample_sphere[samples] = {
                float3( 0.5381, 0.1856,-0.4319), float3( 0.1379, 0.2486, 0.4430),
                float3( 0.3371, 0.5679,-0.0057), float3(-0.6999,-0.0451,-0.0019),
                float3( 0.0689,-0.1598,-0.8547), float3( 0.0560, 0.0069,-0.1843),
                float3(-0.0146, 0.1402, 0.0762), float3( 0.0100,-0.1924,-0.0344),
                float3(-0.3577,-0.5301,-0.4358), float3(-0.3169, 0.1063, 0.0158),
                float3( 0.0103,-0.5869, 0.0046), float3(-0.0897,-0.4940, 0.3287),
                float3( 0.7119,-0.0154,-0.0918), float3(-0.0533, 0.0596,-0.5411),
                float3( 0.0352,-0.0631, 0.5460), float3(-0.4776, 0.2847,-0.0271)
            };
            
            float3 random = SAMPLE_TEXTURE2D(_NoiseTex, sampler_NoiseTex, i.texcoord * 6.0).rgb;
            
            float depth = LinearEyeDepth(SAMPLE_DEPTH_TEXTURE(_CameraDepthTexture, sampler_CameraDepthTexture, i.texcoord).r);
            
            float3 position = float3(i.texcoord, depth);
            float3 normal = normal_from_depth(depth, i.texcoord);
            
            float radius_depth = radius/depth;
            float occlusion = 0.0;
            
            for(int i=0; i < samples; i++) {
            
              float3 ray = radius_depth * reflect(sample_sphere[i], random);
              float3 hemi_ray = position + sign(dot(ray,normal)) * ray;
              
              float occ_depth = LinearEyeDepth(SAMPLE_DEPTH_TEXTURE(_CameraDepthTexture, sampler_CameraDepthTexture, saturate(hemi_ray.xy)).r);
              float difference = depth - occ_depth;
              
              occlusion += step(falloff, difference) * (1.0-smoothstep(falloff, area, difference));
            }
              
            float ao = 1.0 - _Intensity * occlusion * (1.0 / samples);
            
            return saturate(ao + base) * (color + side);
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

            ENDHLSL
        }
    }
}