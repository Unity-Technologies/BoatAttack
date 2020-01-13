Shader "Hidden/BoatAttack/Caustics"
{
    Properties
    {
        //Vector1_F3303B3C("Speed", Float) = 0.5
        _Size("Size", Float) = 0.5
        [NoScaleOffset]_CausticMap("Caustics", 2D) = "white" {}
        _WaterLevel("WaterLevel", Float) = 0
        _BlendDistance("BlendDistance", Float) = 3
        //Vector1_CD857B77("CausticsRGB Split", Float) = 2

        //Color blends
        [HideInInspector] _SrcBlend("__src", Float) = 2.0
        [HideInInspector] _DstBlend("__dst", Float) = 0.0
    }
    SubShader
    {
        // No culling or depth
        Cull Off
        ZWrite Off

        Pass
        {
            Blend [_SrcBlend] [_DstBlend], One Zero

            HLSLPROGRAM
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            #pragma shader_feature _DEBUG

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
                float4 screenpos : TEXCOORD1;
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
                VertexPositionInputs vertexInput = GetVertexPositionInputs(input.positionOS.xyz);
                output.positionOS = vertexInput.positionCS;
                output.screenpos = ComputeScreenPos(output.positionOS);
                output.uv = float2(input.uv.x, 1.0 - input.uv.y);
                return output;
            }

            sampler2D _MainTex;

            real4 frag (Varyings input) : SV_Target
            {
                float4 screenPos = input.screenpos / input.screenpos.w;

                real depth = SAMPLE_DEPTH_TEXTURE( _CameraDepthTexture, sampler_CameraDepthTexture, screenPos.xy);

                float3 worldPos = ReconstructWorldPos(screenPos.xy, depth);

                float2 uv = worldPos.xz * 0.025 + _Time.x * 0.25;
                float waveOffset = SAMPLE_TEXTURE2D(_CausticMap, sampler_CausticMap, uv).w - 0.5;

                float2 causticUV = CausticUVs(worldPos.xz, waveOffset);

                half upperMask = saturate(-worldPos.y + _WaterLevel);
                half lowerMask = saturate((worldPos.y - _WaterLevel) / _BlendDistance + _BlendDistance);

                float3 caustics = SAMPLE_TEXTURE2D_LOD(_CausticMap, sampler_CausticMap, causticUV, abs(worldPos.y - _WaterLevel) * 5 / _BlendDistance).bbb;
                //return real4(caustics, 1);
#ifdef _DEBUG
                return real4(caustics * min(upperMask, lowerMask), 1);
#endif
                caustics *= min(upperMask, lowerMask) * 2;

                return real4(caustics + 1, 1);
            }
            ENDHLSL
        }
    }
}
