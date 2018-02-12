#ifndef GERSTNER_WAVES_INCLUDED
#define GERSTNER_WAVES_INCLUDED

uniform int 	_WaveCount; // how many waves, set via the water component
uniform float4	_WaveData[10]; // the data for the waves, x=amplitude, y=direction, z=wavelength, w=omniDir set via the water component
uniform float4	_WaveData2[10]; // more data, x=omnidirX, y=omnidirZ

struct WaveStruct
{
	float3 position;
	float3 normal;
};

WaveStruct GerstnerWave(half2 pos, int numWaves, float amplitude, half direction, half wavelength, int omni, half2 omniPos)
{
	WaveStruct waveOut;

		////////////////////////////////wave value calculations//////////////////////////
		half3 wave = 0; // wave vector
		half wSpeed = sqrt(9.8 * (6.28318 / wavelength)); // frequency of the wave based off wavelength
		half w = 6.28318 / wavelength; // 2pi over wavelength(hardcoded)
		half peak = 1; // peak value, 1 is the sharpest peaks
		half qi = peak / (amplitude * w * numWaves);

		float2 windDir = 0;
		float dir = 0;
		if(omni == 0)
		{
			//// Linear waves
			direction = radians(direction); // convert the incoming degrees to radians
			windDir = normalize(float2(sin(direction), cos(direction))); // calculate wind direction - TODO - currently radians
			dir = dot(windDir, pos); // calculate a gradient along the wind direction
		}
		else
		{
			//// Omnidirectional waves
			windDir = normalize(pos - omniPos);
			dir = dot(windDir, pos - omniPos); // calculate a gradient along the wind direction
		}

		////////////////////////////position output calculations/////////////////////////
		half calc = dir * w + -_Time.y * wSpeed; // the wave calculation
		float cosCalc = cos(calc); // cosine version(used for horizontal undulation)
		float sinCalc = sin(calc); // sin version(used for vertical undulation)

		// calculate the offsets for the current point
		wave.x = qi * amplitude * windDir.x * cosCalc;
		wave.z = qi * amplitude * windDir.y * cosCalc;
		wave.y = (((sinCalc * 0.5 + 0.5) * amplitude) - amplitude * 0.5)/numWaves;// the height is divided by the number of waves 
		
		////////////////////////////normal output calculations/////////////////////////
		half wa = w * amplitude;
		// normal vector
		float3 n = float3(-(windDir.x * wa * cosCalc),
						-(windDir.y * wa * cosCalc),
						1-(qi * wa * sinCalc));

		////////////////////////////////assign to output///////////////////////////////
		waveOut.position = wave * clamp(amplitude * 10000, 0, 1);
		waveOut.normal = (n / numWaves) * amplitude;

	return waveOut;
}

inline void SampleWaves(float3 position, half opacity, out WaveStruct waveOut)
{
	half2 pos = position.xz;
	WaveStruct waves[10];
	waveOut.position = 0;
	
	for(int i = 0; i < _WaveCount; i++)
	{
		waves[i] = GerstnerWave(pos, _WaveCount, _WaveData[i].x, _WaveData[i].y, _WaveData[i].z, _WaveData[i].w, half2(_WaveData2[i].x, _WaveData2[i].y)); // calculate the wave
		waveOut.position += waves[i].position; // add the position
		waveOut.normal += waves[i].normal; // add the normal
	}
}

#endif // GERSTNER_WAVES_INCLUDED