using System;
using Cinemachine;
using UnityEngine;

namespace BoatAttack.Benchmark
{
    public class BenchmarkCamera : MonoBehaviour
    {
        public BenchmarkCameraSettings[] cameras;
        private int Frames = 1000;

        private void Awake()
        {
            if (Benchmark.Current != null)
            {
                Frames = Benchmark.Current.runLength;
            }

            foreach (var cam in cameras)
            {
                switch (cam.type)
                {
                    case BenchmarkCameraType.Static:
                        break;
                    case BenchmarkCameraType.FlyThrough:
                        cam.Dolly = cam.camera.GetCinemachineComponent<CinemachineTrackedDolly>();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                cam.camera.enabled = true;
            }
        }

        private void LateUpdate()
        {
            foreach (var benchCam in cameras)
            {
                if (benchCam.type == BenchmarkCameraType.FlyThrough)
                {
                    if (!benchCam.Dolly) continue;

                    benchCam.Dolly.m_PathPosition += 1f / Frames;
                    benchCam.Dolly.m_PathPosition = Mathf.Repeat(benchCam.Dolly.m_PathPosition, 1f);
                }
            }
        }

        [Serializable]
        public class BenchmarkCameraSettings
        {
            public BenchmarkCameraType type;
            public CinemachineVirtualCamera camera;

            // public but not saved
            [NonSerialized] public CinemachineTrackedDolly Dolly;
        }
    }
}