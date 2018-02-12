using System;
using UnityEngine;

namespace Cinemachine.Utility
{
    internal abstract class GaussianWindow1d<T>
    {
        protected T[] mData;
        protected float[] mKernel;
        protected float mKernelSum;
        protected int mCurrentPos;

        public float Sigma { get; private set; }   // Filter strength: bigger numbers are stronger.  0.5 is minimal.
        public int KernelSize { get { return mKernel.Length; } }

        void GenerateKernel(float sigma, int maxKernelRadius)
        {
            // Weight is close to 0 at a distance of sigma*3, so let's just cut it off a little early
            int kernelRadius = Math.Min(maxKernelRadius, Mathf.FloorToInt(Mathf.Abs(sigma) * 2.5f));
            mKernel = new float[2 * kernelRadius + 1];
            mKernelSum = 0;
            if (kernelRadius == 0)
                mKernelSum = mKernel[0] = 1;
            else for (int i = -kernelRadius; i <= kernelRadius; ++i)
            {
                mKernel[i + kernelRadius]
                    = (float)(Math.Exp(-(i * i) / (2 * sigma * sigma)) / Math.Sqrt(2.0 * Math.PI * sigma));
                mKernelSum += mKernel[i + kernelRadius];
            }
            Sigma = sigma;
        }

        protected abstract T Compute(int windowPos);

        public GaussianWindow1d(float sigma, int maxKernelRadius = 10)
        {
            GenerateKernel(sigma, maxKernelRadius);
            mCurrentPos = 0;
        }

        public void Reset() { mData = null; }

        public bool IsEmpty() { return mData == null; }

        public void AddValue(T v)
        {
            if (mData == null)
            {
                mData = new T[KernelSize];
                for (int i = 0; i < KernelSize; ++i)
                    mData[i] = v;
                mCurrentPos = Mathf.Min(1, KernelSize-1);
            }
            mData[mCurrentPos] = v;
            if (++mCurrentPos == KernelSize)
                mCurrentPos = 0;
        }

        public T Filter(T v)
        {
            if (KernelSize < 3)
                return v;
            AddValue(v);
            return Value();    
        }

        /// Returned value will be kernelRadius old
        public T Value() { return Compute(mCurrentPos); }
    }

    internal class GaussianWindow1D_Vector3 : GaussianWindow1d<Vector3>
    {
        public GaussianWindow1D_Vector3(float sigma, int maxKernelRadius = 10)
            : base(sigma, maxKernelRadius) {}

        protected override Vector3 Compute(int windowPos)
        {
            Vector3 sum = Vector3.zero;
            for (int i = 0; i < KernelSize; ++i)
            {
                sum += mData[windowPos] * mKernel[i];
                if (++windowPos == KernelSize)
                    windowPos = 0;
            }
            return sum / mKernelSum;
        }
    }

    internal class GaussianWindow1D_Quaternion : GaussianWindow1d<Quaternion>
    {
        public GaussianWindow1D_Quaternion(float sigma, int maxKernelRadius = 10)
            : base(sigma, maxKernelRadius) {}
        protected override Quaternion Compute(int windowPos)
        {
            Quaternion sum = new Quaternion(0, 0, 0, 0);
            Quaternion q = mData[mCurrentPos];
            Quaternion qInverse = Quaternion.Inverse(q);
            for (int i = 0; i < KernelSize; ++i)
            {
                // Make sure the quaternion is in the same hemisphere, or averaging won't work
                float scale = mKernel[i];
                Quaternion q2 = qInverse * mData[windowPos];
                if (Quaternion.Dot(Quaternion.identity, q2) < 0)
                    scale = -scale;
                sum.x += q2.x * scale;
                sum.y += q2.y * scale;
                sum.z += q2.z * scale;
                sum.w += q2.w * scale;

                if (++windowPos == KernelSize)
                    windowPos = 0;
            }
            return q * sum;
        }
    }

    internal class GaussianWindow1D_CameraRotation : GaussianWindow1d<Vector2>
    {
        public GaussianWindow1D_CameraRotation(float sigma, int maxKernelRadius = 10)
            : base(sigma, maxKernelRadius) {}

        protected override Vector2 Compute(int windowPos)
        {
            Vector2 sum = Vector2.zero;
            Vector2 v = mData[mCurrentPos];
            for (int i = 0; i < KernelSize; ++i)
            {
                Vector2 v2 = mData[windowPos] - v;
                if (v2.y > 180f)
                    v2.y -= 360f;
                if (v2.y < -180f)
                    v2.y += 360f;
                sum += v2 * mKernel[i];
                if (++windowPos == KernelSize)
                    windowPos = 0;
            }
            return v + (sum / mKernelSum);
        }
    }
}
