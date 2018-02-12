using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GerstnerWaves
{
    public static class GerstnerWaves
    {
        public static int _WaveCount;
        public static Vector4[] _WaveData = new Vector4[10];
        public static Vector4[] _WaveData2 = new Vector4[10];

        static WaveStruct tempWave = new WaveStruct();
        public static WaveStruct GerstnerWave(Vector2 pos, int numWaves, float amplitude, float direction, float wavelength, bool omni, Vector2 omniPos)
        {
            //float noise = SimplexNoise2D.snoise(new Vector2(pos.x, pos.z) * 0.01f) * 2f;
            //pos += new Vector3(noise, 0f, noise);// add noise here
            ////////////////////////////////wave value calculations//////////////////////////
            Vector3 wave = Vector3.zero;//wave vector
            float wSpeed = Mathf.Sqrt(9.8f * (6.28318f / wavelength));//frequency of the wave based off wavelength
            float w = 6.28318f / wavelength;//2pi over wavelength(hardcoded)
            float peak = 1;//peak value, 1 is the sharpest peaks
            float qi = peak / (w * amplitude * numWaves);

            Vector2 windDir = Vector2.zero;
            float dir = 0;
            if (!omni)
            {
                direction = direction * Mathf.Deg2Rad;//convert the incoming degrees to radians
                windDir = new Vector2(Mathf.Sin(direction), Mathf.Cos(direction)).normalized;//calculate wind direction - TODO - currently radians
                dir = Vector2.Dot(pos, windDir);//calculate a gradient along the wind direction
            }
            else
            {
                windDir = (pos - omniPos).normalized;
                dir = Vector2.Dot(windDir, (pos - omniPos));
            }
            
            ////////////////////////////position output calculations/////////////////////////
            float calc = dir * w + -Time.time * wSpeed;//the wave calculation
            float cosCalc = Mathf.Cos(calc);//cosine version(used for horizontal undulation)
            float sinCalc = Mathf.Sin(calc);//sin version(used for vertical undulation)

            //calculate the offsets for the current point
            wave.x = qi * amplitude * windDir.x * cosCalc;
            wave.z = qi * amplitude * windDir.y * cosCalc;
            wave.y = (((sinCalc * 0.5f + 0.5f) * amplitude) - amplitude * 0.5f) / numWaves;//the height is divided by the number of waves 

            ////////////////////////////normal output calculations/////////////////////////
            float wa = w * amplitude;
            //normal vector
            Vector3 n = new Vector3(-(windDir.x * wa * cosCalc),
                            -(windDir.y * wa * cosCalc),
                            1 - (qi * wa * sinCalc));

            ////////////////////////////////assign to output///////////////////////////////
            tempWave.position = wave * Mathf.Clamp01(amplitude * 10000);
            tempWave.normal = (n / numWaves) * amplitude;
            
            return tempWave;
        }

        static Vector2 tempPos = new Vector2();
        static WaveStruct[] tempWaves = new WaveStruct[10];
        static WaveStruct tempWaveOut = new WaveStruct();

        public static WaveStruct SampleWaves(Vector3 position, float opacity)
        {
            tempPos.x = position.x;
            tempPos.y = position.z;
            tempWaveOut.position = Vector3.zero;
            tempWaveOut.normal = Vector3.zero;

            for (int i = 0; i < _WaveCount; i++)
            {
                tempWaves[i] = GerstnerWave(tempPos, _WaveCount, _WaveData[i].x * opacity, _WaveData[i].y, _WaveData[i].z, _WaveData[i].w == 0 ? false : true, new Vector2(_WaveData2[i].x, _WaveData2[i].y)); // calculate the wave
                tempWaveOut.position += tempWaves[i].position; // add the position
                tempWaveOut.normal += tempWaves[i].normal; // add the normal
            }
            return tempWaveOut;
        }

    }

	public class WaveStruct
    {
        public Vector3 position;
        public Vector3 normal;
    }
}
