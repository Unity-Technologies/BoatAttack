Shader "BoatAttack/Water"
{
	Properties
	{
		_TessellationEdgeLength ("Tessellation Edge Length", Range(5, 100)) = 50
		[NoScaleOffset]
		_BumpMap("Detail Wave Normal", 2D) = "bump" {}
		_BumpScale("Detail Wave Amount", Range(0, 1)) = 0.2//fine detail multiplier
		[NoScaleOffset]
		_FoamMap("Foam Texture", 2D) = "black" {}
		[KeywordEnum(Cubemap, Probes, PlanarReflection)]
		_Reflection ("ReflectionMode", float) = 0
		[Header(Debug)]
		[Toggle(_DEBUG)]
        _Debug ("Debug Rendering", Float) = 0
		[KeywordEnum(Final, Reflection, Color, Depth, WaterFX, Normals, Fresnel, Specular, Temporary)]
		_DebugPass ("Debug Mode", Float) = 0
		// Remove after testing
		[Header(Performance)]
		[Toggle(_PERF_REF)]
		_Perf_Ref ("Perf Reflection", float) = 0
		[Toggle(_PERF_COL)]
		_Perf_Col ("Perf Color", float) = 0
		[Toggle(_PERF_DEPTH)]
		_Perf_Depth ("Perf Depth", float) = 0
		[Toggle(_PERF_VERT)]
		_Perf_Vert ("Perf Vert", float) = 0
		[Toggle(_PERF_LIGHTING)]
		_Perf_Light ("Perf Lighting", float) = 0
		[Toggle(_PERF_FRESNEL)]
		_Perf_Fres ("Perf Fresnel", float) = 0
		[Toggle(_PERF_GERSTNER)]
		_Perf_Gerstner ("Perf Gerstner Waves", float) = 0
		[Toggle(_PERF_FOAM)]
		_Perf_Foam ("Perf Foam", float) = 0
	}
	SubShader
	{
		Tags { "RenderType"="Transparent" "Queue"="Transparent" "RenderPipeline" = "LightweightPipeline" }
		LOD 300
		ZWrite Off

		Pass
		{
			Name "WaterShading"

			HLSLPROGRAM

			/////////////////SHADER FEATURES//////////////////
			#pragma shader_feature _ _TESSELLATION
			#define _TESSELLATION 0
			#pragma shader_feature _ _DEBUG

			#pragma multi_compile _REFLECTION_CUBEMAP _REFLECTION_PROBES _REFLECTION_PLANARREFLECTION
			#pragma multi_compile _ FOG_LINEAR FOG_EXP2

			///////////////PERF SHADER FEATURES///////////////
			#pragma multi_compile _ _PERF_REF 
			#pragma multi_compile _ _PERF_COL
			#pragma multi_compile _ _PERF_DEPTH
			#pragma multi_compile _ _PERF_VERT
			#pragma multi_compile _ _PERF_LIGHTING
			#pragma multi_compile _ _PERF_FRESNEL 
			#pragma multi_compile _ _PERF_GERSTNER
			#pragma multi_compile _ _PERF_FOAM

			////////////////////INCLUDES//////////////////////
			#include "WaterCommon.hlsl"

			//non-tess
			#pragma vertex WaterVertex
			#pragma fragment WaterFragment

			////////////////////STRUCTS///////////////////////
			//vert struct
			// struct appdata
			// {
			// 	float4 vertex : POSITION;
			// 	float2 uv : TEXCOORD0;//TODO - May not need later
			// 	float4 uv2 : TEXCOORD1;//lightmap
			// };
			// //passing struct
			// struct midStruct
			// {
			// 	float4 vertex : POS;
			// 	float2 uv :TEXCOORD0;
			// 	float4 uv2 : TEXCOORD1;//lightmap
			// };
			// //tess CP
			// struct tessCP
			// {
			// 	float4 vertex : INTERNALTESSPOS;
			// 	float2 uv : TEXCOORD0;
			// 	float4 uv2 : TEXCOORD1;//lightmap
			// };
			// //frag struct
			// struct v2f
			// {
			// 	float4 uvs : TEXCOORD0;//Geometric UVs stored in xy, and world(pre-waves) in zw
			// 	float2 uv2 : TEXCOORD1;//lightmapUVs
			// 	float4 worldPos : TEXCOORD4;//world position of the vertices
			// 	float4 viewDir : TEXCOORD2;//screen position of the verticies after wave distortion
            //     float2 screenPosPreVert : TEXCOORD3;//screen position of the verticies before wave distortion
			// 	half4 normal : NORMAL;//vert normals(not used right now)
			// 	half4 diff : COLOR0; // diffuse lighting color
			// 	half3 spec : TEXCOORD5;//for spec data
			// 	//UNITY_FOG_COORDS(6)
			// 	float4 vertex : SV_POSITION;
			// };

			// //Hull Constant struct
			// struct HS_ConstantOutput
    		// {
       		// 	float TessFactor[3]    : SV_TessFactor;
        	// 	float InsideTessFactor : SV_InsideTessFactor;
    		// };

			//////////////////New variables final//////////////////
			
			//Gerstner Wave variables
			// uniform int _WaveCount;//how many waves, set via the water component
			// uniform float4 _WaveData[10];//the data for the waves, x=amplitude, y=direction, z=wavelength, w=omniDir set via the water component
			// uniform float4 _WaveData2[10];//more data, x=omnidirX, y=omnidirZ

			// //Screen-based textures/samplers
			// Texture2D _PlanarReflectionTexture;//screen-based planar reflection
			// Texture2D _WaterDisplacementTexture;//screen-based displacement pass
			// SamplerState sampler_PlanarReflectionTexture;//screen-based sampler, clamped for no repetition/edge issues

			// //Tiling textures/samplers
			// Texture2D _BumpMap;//Detailed normalmap for high frequence details
			// sampler2D _FoamMap;//Foam map for crest whitecaps, etc..
			// sampler2D _WaterDepthMap;//The captured depth map under the water
			// sampler2D _CameraDepthTexture;//depth texture
			// sampler2D _ColorRamp;
			// SamplerState sampler_BumpMap;//Tiling sampler, has repeat wrap mode

			// float _MaxDepth;
			// float _MaxWaveHeight;
			// half _BumpValue;

			////////////////////////Tesselation shader///////////////////////////
			// half _TessellationEdgeLength;

			// float TessellationEdgeFactor (float3 p0, float3 p1) 
			// {
			// 	float edgeLength = distance(p0, p1);

			// 	float3 edgeCenter = (p0 + p1) * 0.5;
			// 	float viewDistance = distance(edgeCenter, _WorldSpaceCameraPos);

			// 	return edgeLength * _ScreenParams.y / (_TessellationEdgeLength * viewDistance);
			// }

			// tessCP vert( appdata Input )
    		// {
        	// 	tessCP Output;
        	// 	Output.vertex = Input.vertex;
			// 	Output.uv = Input.uv;
			// 	Output.uv2 = Input.uv2;
        	// 	return Output;
    		// }

			// HS_ConstantOutput HSConstant( InputPatch<tessCP, 3> Input )
    		// {
			// 	float3 p0 = mul(unity_ObjectToWorld, Input[0].vertex).xyz;
			// 	float3 p1 = mul(unity_ObjectToWorld, Input[1].vertex).xyz;
			// 	float3 p2 = mul(unity_ObjectToWorld, Input[2].vertex).xyz;
        	// 	HS_ConstantOutput Output = (HS_ConstantOutput)0;
        	// 	Output.TessFactor[0] = TessellationEdgeFactor(p1, p2);
			// 	Output.TessFactor[1] = TessellationEdgeFactor(p2, p0);
			// 	Output.TessFactor[2] = TessellationEdgeFactor(p0, p1);
        	// 	Output.InsideTessFactor = (TessellationEdgeFactor(p1, p2) + 
			// 								TessellationEdgeFactor(p2, p0) + 
			// 								TessellationEdgeFactor(p0, p1)) * (1 / 3.0);
        	// 	return Output;
    		// }

			// [domain("tri")]
    		// [partitioning("fractional_odd")]
    		// [outputtopology("triangle_cw")]
    		// [patchconstantfunc("HSConstant")]
    		// [outputcontrolpoints(3)]
    		// tessCP hull( InputPatch<tessCP, 3> Input, uint uCPID : SV_OutputControlPointID )
    		// {
        	// 	tessCP Output = (tessCP)0;
        	// 	Output.vertex = Input[uCPID].vertex;
			// 	Output.uv = Input[uCPID].uv;
			// 	Output.uv2 = Input[uCPID].uv2;
        	// 	return Output;
    		// }

			////////////////////////////VERT SHADER////////////////////////////
			// [domain("tri")]
			// v2f domain( HS_ConstantOutput HSConstantData, 
    		// 			const OutputPatch<tessCP, 3> Input, 
    		// 			float3 BarycentricCoords : SV_DomainLocation)
			// {
			// 	v2f Output = (v2f)0;//initialize OUT
			// 	/////////////////////Tessellation////////////////////////
			// 	//DS_Output Output = (DS_Output)0;
     
        	// 	float fU = BarycentricCoords.x;
        	// 	float fV = BarycentricCoords.y;
        	// 	float fW = BarycentricCoords.z;
       
        	// 	float4 vertex = Input[0].vertex * fU + Input[1].vertex * fV + Input[2].vertex * fW;
			// 	float2 uv = Input[0].uv * fU + Input[1].uv * fV + Input[2].uv * fW;
			// 	float4 uv2 = Input[0].uv2 * fU + Input[1].uv2 * fV + Input[2].uv2 * fW;

			// 	///////////////////////Pre-waves/////////////////////////
			// 	Output.worldPos.xyz = TransformObjectToWorld(vertex.xyz);
			// 	float4 screenPosRaw = TransformObjectToHClip(vertex.xyz);
			// 	Output.screenPosPreVert = ComputeNormalizedDeviceCoordinates(screenPosRaw.xyz);//screen uvs pre-waves
			// 	Output.uvs.xy = uv;//geometry UVs
			// 	Output.uvs.zw = Output.worldPos.xz * 0.1;//worldspace UVs
			// 	Output.uv2 = uv2.xy;// * unity_LightmapST.xy + unity_LightmapST.zw;;
			// 	Output.normal = float4(0, 0, 1, 0);//intialize tangent normals
			// 	half waterDepth = (tex2Dlod(_WaterDepthMap, float4(Output.uvs.xy, 0, 0)).r * _MaxDepth) *0.05;//get depth map
			// 	///////////////////////Gerstner Waves/////////////////////
			// 	// #ifdef GERSTNER_WAVES
			// 	// WaveStructOut waves[10];
			// 	// for(int i = 0; i < _WaveCount; i++)
			// 	// {
			// 	// 	waves[i] = GerstnerWave(Output.worldPos.xyz, _WaveCount, _WaveData[i].x * (1-clamp(waterDepth, 0, 1)), _WaveData[i].y, _WaveData[i].z, _WaveData[i].w, half2(_WaveData2[i].x, _WaveData2[i].y));//calculate the wave
			// 	// 	vertex.xyz += waves[i].pos;//add the position to the vertices
			// 	// 	Output.normal.xyz += waves[i].normal;//add to the normal
			// 	// 	Output.diff.w += length(abs(waves[i].pos.xz));
			// 	// }
			// 	// Output.normal.xyz = normalize(Output.normal.xyz);//normalize the normal :D
			// 	// Output.normal.w = vertex.y;//encode wave height into w component of normal
			// 	// #endif
			// 	//////////////////////Post-waves//////////////////////////
			// 	//vertex.y += _WaterDisplacementTexture.SampleLevel(sampler_PlanarReflectionTexture, float4(Output.screenPosPreVert, 0, 0), 0).r;//added displacement pass
			// 	Output.vertex = TransformWorldToHClip(vertex);//calculate the vertices for rendering
			// 	//Output.screenPos = ComputeScreenPos(Output.vertex);//create screenUVs that ignore wave disp
			// 	Output.worldPos.xyz = mul(unity_ObjectToWorld, vertex).xyz;//recalculate the world pos
			// 	Output.worldPos.w = 1;// length(ObjSpaceViewDir(vertex)); TODO
			// 	float3 viewPos = TransformWorldToView(Output.worldPos.xyz);
			// 	Output.viewDir.w = length(viewPos / viewPos.z);
			// 	////////////////////Lighting info/////////////////////////
			// 	half3 lightDirectionWS;
			// 	//LightInput mainLight;
    		// 	//INITIALIZE_MAIN_LIGHT(mainLight);

			// 	//half realtimeMainLightAtten = GetMainLightDirectionAndRealtimeAttenuation(mainLight, Output.normal.xzy, Output.worldPos, lightDirectionWS);
			// 	//half NdotL = saturate(dot(Output.normal.xzy, lightDirectionWS));
			// 	Output.diff.x = 0.5;// mainLight.color * NdotL;

			// 	half3 viewDir = SafeNormalize(_WorldSpaceCameraPos - Output.worldPos.xyz);
			// 	Output.viewDir.xyz = viewDir;
			// 	Output.spec = 0; //normalize(lightDirectionWS + viewDir);
			// 	//float nh = max(0, dot(Output.normal.xzy, h));
			// 	//Output.diff.y = pow(nh, 128.0) * 128;

			// 	//UNITY_TRANSFER_FOG(Output, Output.vertex);//Do fog
			// 	return Output;
			// }
			////////////////////////////FRAG SHADER///////////////////////////

			// half4 frag (v2f IN) : SV_Target
			// {
			// 	half3 waveNormals = IN.normal.xyz; //0;
			// 	half waveHeight = IN.normal.w;
			// 	float2 reflectionUV = ComputeNormalizedDeviceCoordinates(IN.vertex.xyz);//screen UVs
			// 	reflectionUV = float2(reflectionUV.x, 1-reflectionUV.y);
			// 	///////////////////////Gerstner Waves/////////////////////
			// 	// #ifdef GERSTNER_WAVES
			// 	// WaveStructOut waves[10];
			// 	// for(int i = 0; i < _WaveCount; i++)
			// 	// {
			// 	// 	waves[i] = GerstnerWave(IN.worldPos, _WaveCount, _WaveData[i].x, _WaveData[i].y, _WaveData[i].z);//calculate the wave
			// 	// 	waveNormals += waves[i].normal;//add to the normal
			// 	// 	waveHeight += waves[i].pos.y;
			// 	// }
			// 	// waveNormals = normalize(waveNormals);
			// 	// #endif
			// 	///////////////////////////Normals////////////////////////
			// 	//Tangent normals
			// 	half roughness = saturate(_BumpValue + (snoise(IN.worldPos.xz * 0.01) * 0.1));
			// 	half3 bump1 = UnpackNormal(_BumpMap.Sample(sampler_BumpMap, ((IN.uvs.zw) + frac(_Time.y * 0.05)))) * roughness;//detail01
			// 	half3 bump2 = UnpackNormal(_BumpMap.Sample(sampler_BumpMap, ((IN.uvs.zw * 3) + frac(_Time.yy * -0.05)))) * roughness;//detail02
			// 	half3 dispNormal = HeightToNormal(_WaterDisplacementTexture, sampler_PlanarReflectionTexture, IN.screenPosPreVert.xy, 2) * 0.4;//convert displacement pass to normal
            //     half3 normal = bump1 + bump2 + dispNormal + waveNormals;//combine all the normals
			// 	//World normals
			// 	half3 worldNormal = normal.xzy;//we can cheat here since the water is always facing up, we can convert tangent to world with a swizzle
			// 	///////////////////////Fresnel////////////////////////////
			// 	half3 worldViewDir = IN.viewDir.xyz;
			// 	half fresnel = 0.02 + 0.97 * pow(1.0 - saturate(dot (normalize(worldViewDir), worldNormal)), 5);//fresnel
			// 	/////////////////////Lighting////////////////////////////
			// 	// half3 lighting = DecodeLightmap(tex2D(unity_Lightmap, IN.uv2));
			// 	// half spec = pow(max(0, dot(normal.xzy, IN.spec)), 128) * 12;
			// 	// half translucency = (-IN.diff.w * 0.5 + waveHeight) * IN.diff.x;
			// 	// translucency *= fresnel;
	///////////////////////Depth/Refraction////////////////////
			// 	float d = tex2D(_CameraDepthTexture, (ComputeNormalizedDeviceCoordinates(IN.vertex.xyz))).r;
			// 	float depth = LinearEyeDepth(d, _ZBufferParams) * IN.viewDir.w - IN.worldPos.w;
			// 	half waterDepth = (tex2D(_WaterDepthMap, IN.uvs.xy).r * _MaxDepth);
			// 	waterDepth += IN.worldPos.y;
			// 	////////////////////////////Edgeing///////////////////////
			// 	half edging = 0;
			// 	//////////////////////////Colouring///////////////////////
			// 	half4 disp = _WaterDisplacementTexture.Sample(sampler_PlanarReflectionTexture, IN.screenPosPreVert.xy);//sample displacement pass
			// 	half3 col = tex2D(_ColorRamp, float2(saturate(depth * 0.01), 0));
			// 	//col += saturate(translucency) * half3(0, 0.75, 0.5);
			// 	//col *= lighting * (1.2-fresnel);
			// 	reflection *= length(1-col.rgb) * fresnel;
			// 	float3 blend = col + reflection.xyz;
			// 	//half foam = _FoamMap.Sample(sampler_BumpMap, IN.uvs.zw + frac(_Time.y * 0.05)).r;
			// 	half foam = tex2D(_FoamMap, (IN.uvs.zw * 0.25) + frac(_Time.y * 0.01) + (snoise(IN.uvs.xy) * 0.1)).r;
			// 	foam += max(waveHeight / _MaxWaveHeight + disp.y, pow(waterDepth / _MaxDepth, 4) + 0.15);
			// 	foam = saturate(Remap(foam, half4(1.2, 2.2, 0, 1)));// * lighting;
			// 	//foam = clamp(Remap(foam + waveHeight + (disp.y * 2), float4(0.75, 1, 0, 1)), 0, 2); //lerp(0, foam, saturate((i.worldPos.y * 2 - 1) + (disp * 2)));
			// 	//UNITY_APPLY_FOG(IN.fogCoord, blend);
			// 	///////////////////////DEBUG OUTPUTS//////////////////////
			// 	//return float4(frac(depth * 0.01), frac(IN.worldPos.w * 0.01), 0, 1);
			// 	//return float4(reflection.rgb, 1);
			// 	//return float4(col, 1);
			// 	//return float4(waveHeight, 0, 0, 1);
			// 	return float4(blend + foam, 1);
			// }
			ENDHLSL
		}
	}
	//Fallback "LightweightPipeline/Standard (Physically Based)"
}
