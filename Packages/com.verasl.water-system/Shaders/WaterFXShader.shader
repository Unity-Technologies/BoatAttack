Shader "BoatAttack/WaterFXShader"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		// Blend mode values
		[Enum(UnityEngine.Rendering.BlendMode)] _SrcBlend ("Src Blend mode", Float) = 0.0
		// Blend mode values
		[Enum(UnityEngine.Rendering.BlendMode)] _DstBlend ("Dst Blend mode", Float) = 0.0
		// Will set "_INVERT_ON" shader keyword when set
		[Toggle] _Invert ("Invert?", Float) = 0
	}
	SubShader
	{
		Tags { "RenderType"="Transparent" "Queue"="Transparent" "RenderPipeline" = "LightweightPipeline" }
		ZWrite Off
		Blend[_SrcBlend][_DstBlend]
		LOD 100

		Pass
		{
			Name "WaterFX"
			Tags{"LightMode" = "WaterFX"}
			HLSLPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma shader_feature _INVERT_ON

			#define _NORMALMAP 1
			
			#include "Packages/com.unity.render-pipelines.lightweight/ShaderLibrary/Core.hlsl"

			struct appdata
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
    			float4 tangent : TANGENT;
				half4 color : COLOR;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				half4 normal : TEXCOORD1;    // xyz: normal, w: viewDir.x
    			half4 tangent : TEXCOORD2;    // xyz: tangent, w: viewDir.y
    			half4 binormal : TEXCOORD3;    // xyz: binormal, w: viewDir.z
				half4 color : TEXCOORD4;
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			
			v2f vert (appdata v)
			{
				v2f o;
				half3 posWS = TransformObjectToWorld(v.vertex.xyz);
				o.vertex = TransformWorldToHClip(posWS);
				o.uv = v.uv;

				o.color = v.color;

				half3 viewDir = VertexViewDirWS(GetCameraPositionWS() - posWS);
				o.normal.w = viewDir.x;
    			o.tangent.w = viewDir.y;
    			o.binormal.w = viewDir.z;

				OUTPUT_NORMAL(v, o);

				return o;
			}
			
			half4 frag (v2f i) : SV_Target
			{
				half4 col = tex2D(_MainTex, i.uv);

				half foamMask = col.r * i.color.r;
				half disp = col.a * 2 - 1;

				disp *= i.color.a;

				half3 tNorm = half3(col.b, col.g, 1) * 2 - 1;

				half3 viewDir = half3(i.normal.w, i.tangent.w, i.binormal.w);
    			half3 normalWS = TangentToWorldNormal(tNorm, i.tangent.xyz, i.binormal.xyz, i.normal.xyz);

				normalWS = lerp(half3(0, 1, 0), normalWS, i.color.g);
				half4 comp = half4(foamMask, normalWS.xz, disp);

				#ifdef _INVERT_ON
				comp *= -1;
				#endif

				return comp;
			}
			ENDHLSL
		}
	}
}
