Shader "Hidden/BoatAttack/Caustics"
{
    Properties
    {
        //Vector1_F3303B3C("Speed", Float) = 0.5
        _Size("Size", Float) = 0.5
        [NoScaleOffset]_CausticMap("Caustics", 2D) = "white" {}
        _WaterLevel("WaterLevel", Float) = -0.25
        _BlendDistance("BlendDistance", Float) = 0.1
        //Vector1_CD857B77("CausticsRGB Split", Float) = 2
    }
    SubShader
    {
        // No culling or depth
        Cull Off
        ZWrite Off
        ZTest Always

        Pass
        {
            Blend DstColor Zero, One Zero
            HLSLPROGRAM
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            
            #pragma vertex vert
            #pragma fragment frag
            
            struct Attributes
            {
                float4 positionOS : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct Varyings
            {
                float2 uv : TEXCOORD0;
                float4 positionOS : SV_POSITION;
            };
            
            TEXTURE2D(_CameraDepthTexture); SAMPLER(sampler_CameraDepthTexture);
            TEXTURE2D(_CausticMap); SAMPLER(sampler_CausticMap);
            
            half _Size;
            half _WaterLevel;
            half _BlendDistance;
            
            float3 ReconstructWorldPos(half2 screenPos, float depth)
            {
                // World Pos reconstriction
                float4 raw = mul(UNITY_MATRIX_I_VP, float4(screenPos * 2 - 1, depth, 1));
                float3 worldPos = raw.rgb / raw.a;
                return worldPos;
            }
            
            // Can be done per-vertex
            float2 CausticUVs(float2 rawUV, float2 offset)
            {            
                //anim
                float2 uv = rawUV * _Size + float2(_Time.y, _Time.x) * 0.1;
                return uv + offset * 0.25;
            }

            Varyings vert (Attributes input)
            {
                Varyings output;
                output.positionOS = float4(input.positionOS.xyz, 1.0);
                output.uv = float2(input.uv.x, 1.0 - input.uv.y);
                return output;
            }

            sampler2D _MainTex;

            real4 frag (Varyings input) : SV_Target
            {
                real depth = SAMPLE_DEPTH_TEXTURE( _CameraDepthTexture, sampler_CameraDepthTexture, input.uv);
                
                float3 worldPos = ReconstructWorldPos(input.uv, depth);
                float waveOffset = SAMPLE_TEXTURE2D(_CausticMap, sampler_CausticMap, worldPos.xz * 0.025 + _Time.x * 0.25).w - 0.5;
                
                float2 causticUV = CausticUVs(worldPos.xz, waveOffset);
                
                float3 caustics = SAMPLE_TEXTURE2D(_CausticMap, sampler_CausticMap, causticUV).bbb;
                
                half upperMask = saturate(-worldPos.y + _WaterLevel);
                half lowerMask = saturate((worldPos.y - _WaterLevel) / _BlendDistance + _BlendDistance);
                
                caustics *= min(upperMask, lowerMask) * 1.5;
                
                //return half4(waveOffset.xx, 0, 1);
                return half4(caustics + 1, 1);
            }
            ENDHLSL
        }
    }
}
