using UnityEngine;

namespace Cinemachine.Utility
{
    internal static class SplineHelpers
    {
        public static Vector3 Bezier3(
            float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
        {
            t = Mathf.Clamp01(t);
            float d = 1f - t;
            return d * d * d * p0 + 3f * d * d * t * p1
                + 3f * d * t * t * p2 + t * t * t * p3;
        }

        public static Vector3 BezierTangent3(
            float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
        {
            t = Mathf.Clamp01(t);
            return (-3f * p0 + 9f * p1 - 9f * p2 + 3f * p3) * t * t
                +  (6f * p0 - 12f * p1 + 6f * p2) * t
                -  3f * p0 + 3f * p1;
        }

        public static float Bezier1(float t, float p0, float p1, float p2, float p3)
        {
            t = Mathf.Clamp01(t);
            float d = 1f - t;
            return d * d * d * p0 + 3f * d * d * t * p1
                + 3f * d * t * t * p2 + t * t * t * p3;
        }

        public static float BezierTangent1(
            float t, float p0, float p1, float p2, float p3)
        {
            t = Mathf.Clamp01(t);
            return (-3f * p0 + 9f * p1 - 9f * p2 + 3f * p3) * t * t
                +  (6f * p0 - 12f * p1 + 6f * p2) * t
                -  3f * p0 + 3f * p1;
        }

        public static void ComputeSmoothControlPoints(
            ref Vector4[] knot, ref Vector4[] ctrl1, ref Vector4[] ctrl2)
        {
            int numPoints = knot.Length;
            if (numPoints <= 2)
            {
                if (numPoints == 2)
                {
                    ctrl1[0] = Vector4.Lerp(knot[0], knot[1], 0.33333f);
                    ctrl2[0] = Vector4.Lerp(knot[0], knot[1], 0.66666f);
                }
                else if (numPoints == 1)
                    ctrl1[0] = ctrl2[0] = knot[0];
                return;
            }

            var a = new float[numPoints];
            var b = new float[numPoints];
            var c = new float[numPoints];
            var r = new float[numPoints];
            for (int axis = 0; axis < 4; ++axis)
            {
                int n = numPoints - 1;

                // Linear into the first segment 
                a[0] = 0;
                b[0] = 2;
                c[0] = 1;
                r[0] = knot[0][axis] + 2 * knot[1][axis];

                // Internal segments
                for (int i = 1; i < n - 1; ++i)
                {
                    a[i] = 1;
                    b[i] = 4;
                    c[i] = 1;
                    r[i] = 4 * knot[i][axis] + 2 * knot[i+1][axis];
                }

                // Linear out of the last segment 
                a[n - 1] = 2;
                b[n - 1] = 7;
                c[n - 1] = 0;
                r[n - 1] = 8 * knot[n - 1][axis] + knot[n][axis];

                // Solve with Thomas algorithm
                for (int i = 1; i < n; ++i)
                {
                    float m = a[i] / b[i-1];
                    b[i] = b[i] - m * c[i-1];
                    r[i] = r[i] - m * r[i-1];
                }

                // Compute ctrl1
                ctrl1[n-1][axis] = r[n-1] / b[n-1];
                for (int i = n - 2; i >= 0; --i)
                    ctrl1[i][axis] = (r[i] - c[i] * ctrl1[i + 1][axis]) / b[i];

                // Compute ctrl2 from ctrl1
                for (int i = 0; i < n; i++)
                    ctrl2[i][axis] = 2 * knot[i + 1][axis] - ctrl1[i + 1][axis];
                ctrl2[n - 1][axis] = 0.5f * (knot[n][axis] + ctrl1[n - 1][axis]);
            }
        }

        public static void ComputeSmoothControlPointsLooped(
            ref Vector4[] knot, ref Vector4[] ctrl1, ref Vector4[] ctrl2)
        {
            int numPoints = knot.Length;
            if (numPoints < 2)
            {
                if (numPoints == 1)
                    ctrl1[0] = ctrl2[0] = knot[0];
                return;
            }

            int margin = Mathf.Min(4, numPoints-1);
            Vector4[] knotLooped = new Vector4[numPoints + 2 * margin];
            Vector4[] ctrl1Looped = new Vector4[numPoints + 2 * margin];
            Vector4[] ctrl2Looped = new Vector4[numPoints + 2 * margin];
            for (int i = 0; i < margin; ++i)
            {
                knotLooped[i] = knot[numPoints-(margin-i)];
                knotLooped[numPoints+margin+i] = knot[i];
            }
            for (int i = 0; i < numPoints; ++i)
                knotLooped[i + margin] = knot[i];
            ComputeSmoothControlPoints(ref knotLooped, ref ctrl1Looped, ref ctrl2Looped);
            for (int i = 0; i < numPoints; ++i)
            {
                ctrl1[i] = ctrl1Looped[i + margin];
                ctrl2[i] = ctrl2Looped[i + margin];
            }
        }
    }
}
