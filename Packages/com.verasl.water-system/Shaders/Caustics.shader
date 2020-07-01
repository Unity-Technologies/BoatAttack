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
        ZWrite Off

        Pass
        {
            Blend [_SrcBlend] [_DstBlend], One Zero

            HLSLPROGRAM
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/DeclareDepthTexture.hlsl"

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
                float3 positionWS : TEXCOORD2;
            };

            TEXTURE2D(_CausticMap); SAMPLER(sampler_CausticMap);
            TEXTURE2D(_AbsorptionScatteringRamp); SAMPLER(sampler_AbsorptionScatteringRamp);

            half _Size;
            half _WaterLevel;
            half _MaxDepth;
            half _BlendDistance;
            half4x4 _MainLightDir;

            float3 ReconstructWorldPos(half2 screenPos, float depth)
            {
#ifdef UNITY_REVERSED_Z
                depth = 1 - depth;
#endif
                // World Pos reconstriction
                float4 raw = mul(UNITY_MATRIX_I_VP, float4(screenPos * 2 - 1, depth * 2 - 1, 1));
                float3 worldPos = raw.rgb / raw.a;                
                return worldPos;
            }

            // Can be done per-vertex
            float2 CausticUVs(float2 rawUV, float2 offset)
            {
                //anim
                float2 uv = rawUV * _Size;
                return uv + offset * 0.1;
            }

            Varyings vert (Attributes input)
            {
                Varyings output;
                VertexPositionInputs vertexInput = GetVertexPositionInputs(input.positionOS.xyz);
                output.positionOS = vertexInput.positionCS;
                output.positionWS = vertexInput.positionWS;
                output.screenpos = ComputeScreenPos(output.positionOS);
                output.uv = float2(input.uv.x, 1.0 - input.uv.y);
                return output;
            }

            sampler2D _MainTex;

            real4 frag (Varyings input) : SV_Target
            {
                float4 screenPos = input.screenpos / input.screenpos.w;

                real depth = SampleSceneDepth(screenPos.xy);
                float4 WorldPos = ReconstructWorldPos(screenPos.xy, depth).xyzz;
                
                Light mainLight = GetMainLight();
                float3 lightPos = mul(WorldPos, _MainLightDir).xyz;

                float2 uv = WorldPos.xz * 0.025 + _Time.x * 0.25;
                float waveOffset = SAMPLE_TEXTURE2D(_CausticMap, sampler_CausticMap, uv).w - 0.5;

                float2 causticUV = CausticUVs(lightPos.xy, waveOffset);

                half upperMask = saturate(-WorldPos.y + _WaterLevel);
                half lowerMask = saturate((WorldPos.y - _WaterLevel) / _BlendDistance + _BlendDistance);

                float4 ref1 = SAMPLE_TEXTURE2D_LOD(_CausticMap, sampler_CausticMap, causticUV + _Time.x, abs(WorldPos.y - _WaterLevel) * 4 / _BlendDistance);
                float4 ref2 = SAMPLE_TEXTURE2D_LOD(_CausticMap, sampler_CausticMap, causticUV * 2, abs(WorldPos.y - _WaterLevel) * 4 / _BlendDistance);
                
                float ref = (ref1.z * ref2.z) * 10 + ref1.z + ref2.z;
                float3 caustics = ref * min(upperMask, lowerMask);
                caustics *= float3(ref1.w * 0.5, ref2.w * 0.75, ref2.x) * mainLight.color;
                
                half3 output = caustics + 1;
#ifdef _DEBUG
                return real4(caustics, 1);
#endif
                return real4(output, 1);
            }
            ENDHLSL
        }
    }
}
