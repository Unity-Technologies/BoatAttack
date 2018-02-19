#ifndef WATER_INPUT_INCLUDED
#define WATER_INPUT_INCLUDED

#include "LWRP/ShaderLibrary/Core.hlsl"


// //Screen-based textures/samplers
// Texture2D _WaterDisplacementTexture;//screen-based displacement pass

// //Tiling textures/samplers
// sampler2D _WaterDepthMap;//The captured depth map under the water

// float _MaxDepth;
// float _MaxWaveHeight;

CBUFFER_START(MaterialProperties)
half _BumpScale;
half _MaxDepth;
int _DebugPass;
half4 _depthCamZParams;
CBUFFER_END

// Effects textures
TEXTURE2D(_PlanarReflectionTexture); SAMPLER(sampler_PlanarReflectionTexture);
TEXTURE2D(_WaterFXMap); SAMPLER(sampler_WaterFXMap);
TEXTURE2D(_CameraDepthTexture); SAMPLER(sampler_CameraDepthTexture);
TEXTURE2D(_WaterDepthMap); SAMPLER(sampler_WaterDepthMap);
//TEXTURE2D(_CameraColorTexture); SAMPLER(sampler_CameraColorTexture); // TODO - Grabpass temp replacement 

// Surface textures
TEXTURE2D(_AbsorptionScatteringRamp); SAMPLER(sampler_AbsorptionScatteringRamp);
TEXTURE2D(_BumpMap); SAMPLER(sampler_BumpMap);
TEXTURE2D(_FoamMap); SAMPLER(sampler_FoamMap);
TEXTURE2D(_FoamBlend); SAMPLER(sampler_FoamBlend);

// Must match Lightweigth ShaderGraph master node
struct SurfaceData
{
    half3 absorption;
	half3 scattering;
    half3 normal;
    half  foam;
};

#endif // WATER_INPUT_INCLUDED