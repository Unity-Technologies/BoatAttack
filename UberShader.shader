Shader "hidden/preview"
{
    Properties
    {
        [NoScaleOffset] Texture_CA4EFDF0("Normal", 2D) = "white" {}
    }
    HLSLINCLUDE
    #define USE_LEGACY_UNITY_MATRIX_VARIABLES
    #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Common.hlsl"
    #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Packing.hlsl"
    #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
    #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/UnityInstancing.hlsl"
    #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/EntityLighting.hlsl"
    #include "ShaderGraphLibrary/ShaderVariables.hlsl"
    #include "ShaderGraphLibrary/ShaderVariablesFunctions.hlsl"
    #include "ShaderGraphLibrary/Functions.hlsl"
    float Vector1_859364E;
    TEXTURE2D(Texture_CA4EFDF0); SAMPLER(samplerTexture_CA4EFDF0);
    float4 _SampleTexture2D_C5B52E0_UV;
    struct SurfaceInputs{
    	half4 uv0;
    };
    struct GraphVertexInput
    {
    	float4 vertex : POSITION;
    	float3 normal : NORMAL;
    	float4 tangent : TANGENT;
    	float4 texcoord0 : TEXCOORD0;
    	UNITY_VERTEX_INPUT_INSTANCE_ID
    };
    struct SurfaceDescription{
    	float4 PreviewOutput;
    };
    GraphVertexInput PopulateVertexData(GraphVertexInput v){
    	return v;
    }
    SurfaceDescription PopulateSurfaceData(SurfaceInputs IN) {
    	SurfaceDescription surface = (SurfaceDescription)0;
    	float4 _SampleTexture2D_C5B52E0_RGBA = SAMPLE_TEXTURE2D(Texture_CA4EFDF0, samplerTexture_CA4EFDF0, IN.uv0.xy);
    	_SampleTexture2D_C5B52E0_RGBA.rgb = UnpackNormalmapRGorAG(_SampleTexture2D_C5B52E0_RGBA);
    	float _SampleTexture2D_C5B52E0_R = _SampleTexture2D_C5B52E0_RGBA.r;
    	float _SampleTexture2D_C5B52E0_G = _SampleTexture2D_C5B52E0_RGBA.g;
    	float _SampleTexture2D_C5B52E0_B = _SampleTexture2D_C5B52E0_RGBA.b;
    	float _SampleTexture2D_C5B52E0_A = _SampleTexture2D_C5B52E0_RGBA.a;
    	if (Vector1_859364E == 2) { surface.PreviewOutput = half4(_SampleTexture2D_C5B52E0_RGBA.x, _SampleTexture2D_C5B52E0_RGBA.y, _SampleTexture2D_C5B52E0_RGBA.z, 1.0); return surface; }
    	return surface;
    }
    ENDHLSL

    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            struct GraphVertexOutput
            {
                float4 position : POSITION;
                half4 uv0 : TEXCOORD;

            };

            GraphVertexOutput vert (GraphVertexInput v)
            {
                v = PopulateVertexData(v);

                GraphVertexOutput o;
                float3 positionWS = TransformObjectToWorld(v.vertex);
                o.position = TransformWorldToHClip(positionWS);
                o.uv0 = v.texcoord0;

                return o;
            }

            float4 frag (GraphVertexOutput IN) : SV_Target
            {
                float4 uv0 = IN.uv0;


                SurfaceInputs surfaceInput = (SurfaceInputs)0;;
                surfaceInput.uv0 = uv0;


                SurfaceDescription surf = PopulateSurfaceData(surfaceInput);
                return surf.PreviewOutput;

            }
            ENDHLSL
        }
    }
}
