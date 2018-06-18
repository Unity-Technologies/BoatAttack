half ComputeGlobalFogFactor(float3 wPos)
{
    half cHeightFalloff = 0.02;
	half cVolFogHeightDensityAtViewer = exp( -cHeightFalloff * cViewPos.z );
    half3 cameraToWorldPos = GetCameraPositionWS() - wPos;
	half fogInt = length( cameraToWorldPos ) * cVolFogHeightDensityAtViewer;

	const float cSlopeThreshold = 0.01;
	if( abs( cameraToWorldPos.z ) > cSlopeThreshold )
	{
		float t = cHeightFalloff * cameraToWorldPos.z;
		fogInt *= ( 1.0 - exp( -t ) ) / t;
	}	
	
	return exp( -unity_FogParams.x * fogInt );
}
