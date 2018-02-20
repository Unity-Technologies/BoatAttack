#ifndef GERSTNER_WAVES_INCLUDED
#define GERSTNER_WAVES_INCLUDED

uniform uint 	_WaveCount; // how many waves, set via the water component
uniform float4	_WaveData[10]; // the data for the waves, x=amplitude, y=direction, z=wavelength, w=omniDir set via the water component
uniform float4	_WaveData2[10]; // more data, x=omnidirX, y=omnidirZ

struct WaveStruct
{
	float3 position;
	float3 normal;
};

WaveStruct GerstnerWave(half2 pos, float waveCountMulti, float amplitude, half direction, half wavelength, float omni, half2 omniPos)
{
	WaveStruct waveOut;

	////////////////////////////////wave value calculations//////////////////////////
	half3 wave = 0; // wave vector
	half w = 6.28318 / wavelength; // 2pi over wavelength(hardcoded)
	half wSpeed = sqrt(9.8 * w); // frequency of the wave based off wavelength
	half peak = 1; // peak value, 1 is the sharpest peaks
	half qi = peak / (amplitude * w * _WaveCount);

	direction = radians(direction); // convert the incoming degrees to radians, for directional waves
	half2 dirWaveInput = float2(sin(direction), cos(direction)) * (1 - omni);
	half2 omniWaveInput = (pos - omniPos) * omni;

	half2 windDir = normalize(dirWaveInput + omniWaveInput); // calculate wind direction
	half dir = dot(windDir, pos - (omniPos * omni)); // calculate a gradient along the wind direction

	////////////////////////////position output calculations/////////////////////////
	half calc = dir * w + -_Time.y * wSpeed; // the wave calculation
	float cosCalc = cos(calc); // cosine version(used for horizontal undulation)
	float sinCalc = sin(calc); // sin version(used for vertical undulation)

	// calculate the offsets for the current point
	wave.xz = qi * amplitude * windDir.xy * cosCalc;
	wave.y = (((sinCalc * 0.5 + 0.5) * amplitude)) * waveCountMulti;// the height is divided by the number of waves
	
	////////////////////////////normal output calculations/////////////////////////
	half wa = w * amplitude;
	// normal vector
	float3 n = float3(-(windDir.xy * wa * cosCalc),
					1-(qi * wa * sinCalc));

	////////////////////////////////assign to output///////////////////////////////
	waveOut.position = wave * saturate(amplitude * 10000);
	waveOut.normal = (n * waveCountMulti) * amplitude;

	return waveOut;
}

inline void SampleWaves(float3 position, half opacity, out WaveStruct waveOut)
{
	half2 pos = position.xz;
	WaveStruct waves[10];
	waveOut.position = 0;
	half waveCountMulti = 1.0 / _WaveCount;
	
	for(uint i = 0; i < _WaveCount; i++)
	{
		waves[i] = GerstnerWave(pos, waveCountMulti, _WaveData[i].x, _WaveData[i].y, _WaveData[i].z, _WaveData[i].w, half2(_WaveData2[i].x, _WaveData2[i].y)); // calculate the wave
		waveOut.position += waves[i].position; // add the position
		waveOut.normal += waves[i].normal; // add the normal
	}
}

#endif // GERSTNER_WAVES_INCLUDED