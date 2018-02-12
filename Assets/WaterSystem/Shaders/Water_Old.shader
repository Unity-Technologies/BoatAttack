// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'


Shader "Water_Old"
{
	Properties
	{
		_TessellationEdgeLength ("Tessellation Edge Length", Range(5, 100)) = 50
		_Color ("SeaCol", Color) = (1, 1, 1, 1)
		_Color2 ("SeaCol2", Color) = (1, 1, 1, 1)
		//[NoScaleOffset]
		//_ColorRamp("Color Ramp", 2D) = "grey" {}
		[NoScaleOffset]
		_BumpMap("Detail Wave Normal", 2D) = "bump" {}
		_BumpValue("Detail Wave Amount", Range(0, 1)) = 0.2//fine detail multiplier
		[NoScaleOffset]
		_FoamMap("Foam Texture", 2D) = "black" {}
	}
	SubShader
	{
		//normal pass
		Tags {"Queue"="Transparent" "RenderPipeline" = "LightweightPipeline"}
		Pass
		{
			LOD 100
			ZWrite Off

			CGPROGRAM
			//tesselation stuff
			#pragma hull hull
			#pragma domain domain
			//normal stuff
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog
			#pragma shader_feature GERSTNER_WAVES
			#pragma target 4.0
			#pragma require tessellation tessHW
			
			////////////////////INCLUDES//////////////////////
			#include "UnityCG.cginc"
			//Import the Gerstner Waves function
			#include "GerstnerWaves.cginc"

			////////////////////STRUCTS///////////////////////
			//vert struct
			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;//TODO - May not need later
				float4 uv2 : TEXCOORD1;//lightmap
			};
			//passing struct
			struct midStruct
			{
				float4 vertex : POS;
				float2 uv :TEXCOORD0;
				float4 uv2 : TEXCOORD1;//lightmap
			};
			//tess CP
			struct tessCP
			{
				float4 vertex : INTERNALTESSPOS;
				float2 uv : TEXCOORD0;
				float4 uv2 : TEXCOORD1;//lightmap
			};
			//frag struct
			struct v2f
			{
				float4 uvs : TEXCOORD0;//Geometric UVs stored in xy, and world(pre-waves) in zw
				float2 uv2 : TEXCOORD1;//lightmapUVs
				float4 worldPos : TEXCOORD4;//world position of the vertices
				float4 screenPos : TEXCOORD2;//screen position of the verticies after wave distortion
                float2 screenPosPreVert : TEXCOORD3;//screen position of the verticies before wave distortion
				half4 normal : NORMAL;//vert normals(not used right now)
				fixed4 diff : COLOR0; // diffuse lighting color
				fixed3 spec : TEXCOORD5;//for spec data
				UNITY_FOG_COORDS(6)
				float4 vertex : SV_POSITION;
			};

			//Hull Constant struct
			struct HS_ConstantOutput
    		{
       			float TessFactor[3]    : SV_TessFactor;
        		float InsideTessFactor : SV_InsideTessFactor;
    		};

			//////////////////New variables final//////////////////
			
			//Gerstner Wave variables
			//uniform int _WaveCount;//how many waves, set via the water component
			//uniform float4 _WaveData[10];//the data for the waves, x=amplitude, y=direction, z=wavelength, w=omniDir set via the water component
			//uniform float4 _WaveData2[10];//more data, x=omnidirX, y=omnidirZ

			//Screen-based textures/samplers
			Texture2D _WaterDisplacementTexture;//screen-based displacement pass
			Texture2D _PlanarReflectionTexture;//screen-based planar reflection
			SamplerState sampler_PlanarReflectionTexture_repeat_bilinear;//screen-based sampler, clamped for no repetition/edge issues

			//Tiling textures/samplers
			Texture2D _BumpMap;//Detailed normalmap for high frequence details
			sampler2D _FoamMap;//Foam map for crest whitecaps, etc..
			sampler2D _WaterDepthMap;//The captured depth map under the water
			sampler2D _CameraDepthTexture;//depth texture
			sampler2D _AbsorptionScatteringRamp;
			SamplerState sampler_BumpMap;//Tiling sampler, has repeat wrap mode

			//Color lookups - TODO - should be a gradient lut
			float4 _Color;
			float4 _Color2;
			float _MaxDepth;
			float _MaxWaveHeight;
			half _BumpValue;

			/////////////////Utility Functions////////////////// - TODO - Moved to separate CGinc file
			
			float Remap(half value, half4 remap)//remaps a value based on a in:min/max and out:min/max
			{
				return remap.z + (value - remap.x) * (remap.w - remap.z) / (remap.y - remap.x);
			}

			float3 HeightToNormal(Texture2D _tex, SamplerState _sampler, float2 uv, half intensity)//converts height to normal
			{
				float3 bumpSamples;
				bumpSamples.x = _tex.Sample(_sampler, uv).x; // Sample center
				bumpSamples.y = _tex.Sample(_sampler, float2(uv.x + intensity / _ScreenParams.x, uv.y)).x; // Sample U
				bumpSamples.z = _tex.Sample(_sampler, float2(uv.x, uv.y + intensity / _ScreenParams.y)).x; // Sample V
				half dHdU = bumpSamples.z - bumpSamples.x;//bump U offset
				half dHdV = bumpSamples.y - bumpSamples.x;//bump V offset
				return float3(-dHdU, dHdV, 0.5);//return tangent normal
			}
			////////////////////////Tesselation shader///////////////////////////
			half _TessellationEdgeLength;

			float TessellationEdgeFactor (float3 p0, float3 p1) 
			{
				float edgeLength = distance(p0, p1);

				float3 edgeCenter = (p0 + p1) * 0.5;
				float viewDistance = distance(edgeCenter, _WorldSpaceCameraPos);

				return edgeLength * _ScreenParams.y / (_TessellationEdgeLength * viewDistance);
			}

			tessCP vert( appdata Input )
    		{
        		tessCP Output;
        		Output.vertex = Input.vertex;
				Output.uv = Input.uv;
				Output.uv2 = Input.uv2;
        		return Output;
    		}

			HS_ConstantOutput HSConstant( InputPatch<tessCP, 3> Input )
    		{
				float3 p0 = mul(unity_ObjectToWorld, Input[0].vertex).xyz;
				float3 p1 = mul(unity_ObjectToWorld, Input[1].vertex).xyz;
				float3 p2 = mul(unity_ObjectToWorld, Input[2].vertex).xyz;
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
        		tessCP Output = (tessCP)0;
        		Output.vertex = Input[uCPID].vertex;
				Output.uv = Input[uCPID].uv;
				Output.uv2 = Input[uCPID].uv2;
        		return Output;
    		}

			////////////////////////////VERT SHADER////////////////////////////
			[domain("tri")]
			v2f domain( HS_ConstantOutput HSConstantData, 
    					const OutputPatch<tessCP, 3> Input, 
    					float3 BarycentricCoords : SV_DomainLocation)
			{
				v2f Output = (v2f)0;//initialize OUT
				/////////////////////Tessellation////////////////////////
				//DS_Output Output = (DS_Output)0;
     
        		float fU = BarycentricCoords.x;
        		float fV = BarycentricCoords.y;
        		float fW = BarycentricCoords.z;
       
        		float4 vertex = Input[0].vertex * fU + Input[1].vertex * fV + Input[2].vertex * fW;
				float2 uv = Input[0].uv * fU + Input[1].uv * fV + Input[2].uv * fW;
				float4 uv2 = Input[0].uv2 * fU + Input[1].uv2 * fV + Input[2].uv2 * fW;

				///////////////////////Pre-waves/////////////////////////
				Output.worldPos.xyz = mul(unity_ObjectToWorld, vertex).xyz;
				float4 screenPosRaw = ComputeScreenPos(UnityObjectToClipPos(vertex));
				Output.screenPosPreVert.xy = screenPosRaw.xy / screenPosRaw.w;//screen uvs pre-waves
				Output.uvs.xy = uv;//geometry UVs
				Output.uvs.zw = Output.worldPos.xz * 0.1;//worldspace UVs
				Output.uv2 = uv2.xy * unity_LightmapST.xy + unity_LightmapST.zw;;
				Output.normal = float4(0, 0, 1, 0);//intialize tangent normals
				///////////////////////Gerstner Waves/////////////////////
				WaveStruct wave;
				SampleWaves(vertex.xyz, 1, wave);
				half waterDepth = tex2Dlod(_WaterDepthMap, half4(Output.uvs.xy, 0, 0)).r;
				half val = 1-clamp(waterDepth, 0, 1);
				vertex.xyz = wave.position.xyz;// * half3(1, val, 1);
				Output.normal.xyz = wave.normal.xyz * half3(val, 1, val);//normalize the normal :D
				Output.normal.w = vertex.y;//encide wave height into w component of normal
				//////////////////////Post-waves//////////////////////////
				//vertex.y += _WaterDisplacementTexture.SampleLevel(sampler_PlanarReflectionTexture_repeat_bilinear, float4(Output.screenPosPreVert.xy, 0, 0), 0);//added displacement pass
				Output.vertex = UnityObjectToClipPos(vertex);//calculate the vertices for rendering
				Output.screenPos = ComputeScreenPos(Output.vertex);//create screenUVs that ignore wave disp
				Output.worldPos.xyz = mul(unity_ObjectToWorld, vertex).xyz;//recalculate the world pos
				Output.worldPos.w = length(ObjSpaceViewDir(vertex));
				float3 viewPos = UnityObjectToViewPos(vertex);
				Output.screenPos.z = length(viewPos / viewPos.z);
				////////////////////Lighting info/////////////////////////
				half3 lightDirectionWS;
				//LightInput mainLight;
    			//INITIALIZE_MAIN_LIGHT(mainLight);

				//half realtimeMainLightAtten = GetMainLightDirectionAndRealtimeAttenuation(mainLight, Output.normal.xzy, Output.worldPos, lightDirectionWS);
				//half NdotL = saturate(dot(Output.normal.xzy, lightDirectionWS));
				Output.diff.x = 0.5;// mainLight.color * NdotL;

				half3 viewDir = normalize(_WorldSpaceCameraPos.xyz - Output.worldPos);
				Output.spec = 0; //normalize(lightDirectionWS + viewDir);
				//float nh = max(0, dot(Output.normal.xzy, h));
				//Output.diff.y = pow(nh, 128.0) * 128;

				UNITY_TRANSFER_FOG(Output, Output.vertex);//Do fog
				return Output;
			}
			////////////////////////////FRAG SHADER///////////////////////////

			fixed4 frag (v2f IN) : SV_Target
			{
				half3 waveNormals = IN.normal.xyz; //0;
				half waveHeight = IN.normal.w;
				float2 reflectionUV = IN.screenPos.xy / IN.screenPos.w;//screen UVs
				reflectionUV = float2(reflectionUV.x, 1-reflectionUV.y);
				///////////////////////Gerstner Waves/////////////////////
				// #ifdef GERSTNER_WAVES
				// WaveStructOut waves[10];
				// for(int i = 0; i < _WaveCount; i++)
				// {
				// 	waves[i] = GerstnerWave(IN.worldPos, _WaveCount, _WaveData[i].x, _WaveData[i].y, _WaveData[i].z);//calculate the wave
				// 	waveNormals += waves[i].normal;//add to the normal
				// 	waveHeight += waves[i].pos.y;
				// }
				// waveNormals = normalize(waveNormals);
				// #endif
				///////////////////////////Normals////////////////////////
				//Tangent normals
				half roughness = saturate(_BumpValue);
				half3 bump1 = UnpackNormal(_BumpMap.Sample(sampler_BumpMap, ((IN.uvs.zw * 0.5) + frac(_Time.y * 0.01)))) * roughness;//detail01
				half3 bump2 = UnpackNormal(_BumpMap.Sample(sampler_BumpMap, ((IN.uvs.zw * 2) + frac(_Time.yy * -0.05)))) * roughness;//detail02
				half3 dispNormal = HeightToNormal(_WaterDisplacementTexture, sampler_PlanarReflectionTexture_repeat_bilinear, IN.screenPosPreVert.xy, 2) * 0.4;//convert displacement pass to normal
                half3 normal = bump1 + bump2 + waveNormals;//combine all the normals
				//World normals
				half3 worldNormal = normal.xzy;//we can cheat here since the water is always facing up, we can convert tangent to world with a swizzle
				///////////////////////Fresnel////////////////////////////
				half3 worldViewDir = normalize(UnityWorldSpaceViewDir(IN.worldPos));
				half fresnel = 0.02 + 0.97 * pow(1.0 - saturate(dot (normalize(worldViewDir), worldNormal)), 5);//fresnel
				/////////////////////Lighting////////////////////////////
				half3 lighting = DecodeLightmap(UNITY_SAMPLE_TEX2D(unity_Lightmap, IN.uv2));
				half spec = pow(max(0, dot(normal.xzy, IN.spec)), 128) * 12;
				half translucency = (-IN.diff.w * 0.5 + waveHeight) * IN.diff.x;
				translucency *= fresnel;
				//////////////////////Planar refelction///////////////////
				//create a flattened view dir
				float3 viewDir = UNITY_MATRIX_IT_MV[2].xyz;
				viewDir.y = 0;
				viewDir = normalize(viewDir);
				//create view normal
				half3 viewNormal = mul( UNITY_MATRIX_V, float4(worldNormal,0) ).xyz;
				//calculate screen-spaced UV offset for planar reflections
				half2 refOffset = 0;
				refOffset.x = viewNormal.x * 0.02;
				refOffset.y = dot(viewDir, worldNormal) * 0.15;
				half rimFade = (1-(fresnel * 1)) + 0.25;//value to smooth out reflection distortion on glancing/distant angles
				refOffset *= rimFade;
				fixed4 reflection = _PlanarReflectionTexture.Sample(sampler_PlanarReflectionTexture_repeat_bilinear, reflectionUV + refOffset);//planar reflection
				///////////////////////Depth/Refraction////////////////////
				float d = tex2D(_CameraDepthTexture, half2(reflectionUV.x, 1-reflectionUV.y)).r;
				float depth = LinearEyeDepth(d) * IN.screenPos.z - IN.worldPos.w;
				half waterDepth = (tex2D(_WaterDepthMap, IN.uvs.xy).r * _MaxDepth);
				//waterDepth += IN.worldPos.y;
				////////////////////////////Edgeing///////////////////////
				half edging = 0;
				//////////////////////////Colouring///////////////////////
				half4 disp = _WaterDisplacementTexture.Sample(sampler_PlanarReflectionTexture_repeat_bilinear, IN.screenPosPreVert.xy);//sample displacement pass
				fixed3 col = tex2D(_AbsorptionScatteringRamp, float2(saturate(depth * 0.01), 0));
				//col += saturate(translucency) * half3(0, 0.75, 0.5);
				//col *= lighting * (1.2-fresnel);
				reflection *= length(1-col.rgb) * clamp(fresnel, 0, 0.5);
				//fixed3 col = lerp(_Color2.rgb, _Color.rgb, 1-saturate(pow(waterDepth * 0.05, 0.25)));// - pow(fresnel, 5) - (IN.worldPos.y * -0.5)));// saturate((-IN.worldPos.y * 0.5) + pow(fresnel, 0.5)));
				float3 blend = col + reflection.xyz;
				//half foam = _FoamMap.Sample(sampler_BumpMap, IN.uvs.zw + frac(_Time.y * 0.05)).r;
				half foam = tex2D(_FoamMap, (IN.uvs.zw * 0.25) + frac(_Time.y * 0.01)).r;
				foam += waveHeight / _MaxWaveHeight + disp.y;
				foam = saturate(Remap(foam, half4(0.8, 1.5, 0, 1)));// * lighting;
				//foam = clamp(Remap(foam + waveHeight + (disp.y * 2), float4(0.75, 1, 0, 1)), 0, 2); //lerp(0, foam, saturate((i.worldPos.y * 2 - 1) + (disp * 2)));
				UNITY_APPLY_FOG(IN.fogCoord, blend);
				///////////////////////DEBUG OUTPUTS//////////////////////
				//return float4(frac(depth * 0.01), frac(IN.worldPos.w * 0.01), 0, 1);
				//return float4(reflection.rgb, 1);
				//return float4(waterDepth, 0, 0, 1);
				//return float4(waveHeight, 0, 0, 1);
				return float4(saturate(blend + foam), 1);
			}
			ENDCG
		}

		//meta pass
		Pass
        {
            Name "META"
            Tags {"LightMode"="Meta"}
            Cull Off
            CGPROGRAM
 
            #include "UnityStandardMeta.cginc"

            float4 frag_meta2 (v2f_meta i): SV_Target
            {
                // We're interested in diffuse & specular colors
                // and surface roughness to produce final albedo.
               
                //FragmentCommonData data = UNITY_SETUP_BRDF_INPUT (i.uv);
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT(UnityMetaInput, o);
                fixed4 c = fixed4(0, 0.2, 0.4, 0.5);
                o.Albedo = c.rgb;
                o.Emission = c.rgb;
                return UnityMetaFragment(o);
            }
           
            #pragma vertex vert_meta
            #pragma fragment frag_meta2
            #pragma shader_feature _EMISSION
            #pragma shader_feature _METALLICGLOSSMAP
            ENDCG
        }
	}
	//Fallback "LightweightPipeline/Standard (Physically Based)"
}
