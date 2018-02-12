Shader "Unlit/LWBasicTess"
{
	Properties
	{
		[Toggle(_LW)]
        _LW ("LightWeight vs Legacy", Float) = 0
		_TessellationEdgeLength ("Tessellation Edge Length", FLoat) = 35
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" "RenderPipeline" = "LightweightPipeline"}
		LOD 100

		Pass
		{
			HLSLPROGRAM
			#pragma vertex vert
			#pragma hull hull
			#pragma domain domain
			#pragma fragment frag

			#pragma shader_feature _LW
			
			#ifdef _LW
			#include "LWRP/ShaderLibrary/Core.hlsl"
			#else
			#include "UnityCG.cginc"
			#endif

			struct appdata
			{
				float4 vertex : POSITION;
			};

			struct tessCP
			{
				float4 vertex : INTERNALTESSPOS;
			};

			struct HS_ConstantOutput
    		{
       			float TessFactor[3]    : SV_TessFactor;
        		float InsideTessFactor : SV_InsideTessFactor;
    		};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				float3 col : TEXCOORD0;
			};

			//tess//
			half _TessellationEdgeLength;

			float TessellationEdgeFactor (float3 p0, float3 p1) 
			{
				float edgeLength = distance(p0, p1);

				float3 edgeCenter = (p0 + p1) * 0.5;
				float viewDistance = 10; // distance(edgeCenter, _WorldSpaceCameraPos);

				return edgeLength * _ScreenParams.y / (_TessellationEdgeLength * viewDistance);
			}

			tessCP vert( appdata Input )
    		{
        		tessCP Output;
        		Output.vertex = Input.vertex;
        		return Output;
    		}

			HS_ConstantOutput HSConstant( InputPatch<tessCP, 3> Input )
    		{
				float3 p0 = mul(UNITY_MATRIX_M, Input[0].vertex).xyz;
				float3 p1 = mul(UNITY_MATRIX_M, Input[1].vertex).xyz;
				float3 p2 = mul(UNITY_MATRIX_M, Input[2].vertex).xyz;
        		HS_ConstantOutput Output = (HS_ConstantOutput)0;
        		Output.TessFactor[0] = TessellationEdgeFactor(p1, p2);
				Output.TessFactor[1] = TessellationEdgeFactor(p2, p0);
				Output.TessFactor[2] = TessellationEdgeFactor(p0, p1);
        		Output.InsideTessFactor = (TessellationEdgeFactor(p1, p2) + 
											TessellationEdgeFactor(p2, p0) + 
											TessellationEdgeFactor(p0, p1)) * (1 / 3.0);
        		return Output;
    		}

			[domain("tri")]
    		[partitioning("fractional_odd")]
    		[outputtopology("triangle_cw")]
    		[patchconstantfunc("HSConstant")]
    		[outputcontrolpoints(3)]
    		tessCP hull( InputPatch<tessCP, 3> Input, uint uCPID : SV_OutputControlPointID )
    		{
        		return Input[uCPID];
    		}

			////////////////////////////VERT SHADER////////////////////////////
			[domain("tri")]
			v2f domain( HS_ConstantOutput HSConstantData, const OutputPatch<tessCP, 3> Input, float3 BarycentricCoords : SV_DomainLocation)
			{
				v2f Output = (v2f)0;
        		float fU = BarycentricCoords.x;
        		float fV = BarycentricCoords.y;
        		float fW = BarycentricCoords.z;
        		float4 vertex = Input[0].vertex * fU + Input[1].vertex * fV + Input[2].vertex * fW;

				vertex.y += sin(_Time.w + vertex.x * 4) * 0.2;
				Output.col = vertex.xyz;

				#ifdef _LW
				Output.vertex = mul(UNITY_MATRIX_VP, mul(UNITY_MATRIX_M, float4(vertex.xyz, 1.0))); //TransformObjectToHClip(vertex);//calculate the vertices for rendering
				#else
				Output.vertex = mul(UNITY_MATRIX_VP, mul(UNITY_MATRIX_M, float4(vertex.xyz, 1.0))); // UnityObjectToClipPos(vertex);//calculate the vertices for rendering
				#endif				

				return Output;
			}
			
			float4 frag (v2f i) : SV_Target
			{
				float4 col = float4(i.col, 1);
				return col;
			}
			ENDHLSL
		}
	}
}
