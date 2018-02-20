using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Conversion of HLSL code from Noise Shader Library for Unity - https://github.com/keijiro/NoiseShader

public static class SimplexNoise2D
{
	static Vector4 C = new Vector4(0.211324865405187f,  // (3.0-sqrt(3.0))/6.0
                                 0.366025403784439f,  // 0.5*(sqrt(3.0)-1.0)
                                -0.577350269189626f,  // -1.0 + 2.0 * C.x
                                 0.024390243902439f); // 1.0 / 41.0
                                                     // First corner

	static Vector2 floorVec(Vector2 x)
	{
		return new Vector2(Mathf.Floor(x.x), Mathf.Floor(x.y));
	}

    static Vector3 floorVec(Vector3 x)
    {
        return new Vector3(Mathf.Floor(x.x), Mathf.Floor(x.y), Mathf.Floor(x.z));
    }

	static Vector3 fracVec(Vector3 x)
	{
        return new Vector3(x.x % 1f, x.y % 1f, x.z % 1f);
    }

	static Vector3 absVec(Vector3 x)
	{
        return new Vector3(Mathf.Abs(x.x), Mathf.Abs(x.y), Mathf.Abs(x.z));
    }

    static Vector3 mod289(Vector3 x)
    {
        return x - floorVec(x / 289.0f) * 289.0f;
    }

    static Vector2 mod289(Vector2 x)
    {
        return x - floorVec(x / 289.0f) * 289.0f;
    }

    static Vector3 permute(Vector3 x)
    {
        return mod289(Vector3.Scale((x * 34.0f + Vector3.one) , x));
    }

    static Vector3 taylorInvSqrt(Vector3 r)
    {
        return Vector3.one * 1.79284291400159f - 0.85373472095314f * r;
    }

	public static float snoise(Vector2 v)
    {
        Vector2 i = floorVec(v + Vector2.one * Vector2.Dot(v, Vector2.one * C.y));
        Vector2 x0 = v - i + Vector2.one * Vector2.Dot(i, Vector2.one * C.x);

        // Other corners
        Vector2 i1;
        i1.x = x0.y >= x0.x ? 1 : 0;
        i1.y = 1.0f - i1.x;

        // x1 = x0 - i1  + 1.0 * C.xx;
        // x2 = x0 - 1.0 + 2.0 * C.xx;
        Vector2 x1 = x0 + Vector2.one * C.x - i1;
        Vector2 x2 = x0 + Vector2.one * C.z;

        // Permutations
        i = mod289(i); // Avoid truncation effects in permutation
        Vector3 p =
          permute(permute(Vector3.one * i.y + new Vector3(0.0f, i1.y, 1.0f))
                        + Vector3.one * i.x + new Vector3(0.0f, i1.x, 1.0f));

        Vector3 m = Vector3.Max(Vector3.one * 0.5f - new Vector3(Vector2.Dot(x0, x0), Vector2.Dot(x1, x1), Vector2.Dot(x2, x2)), Vector3.zero);
        m = Vector3.Scale(m, m);
        m = Vector3.Scale(m, m);

        // Gradients: 41 points uniformly over a line, mapped onto a diamond.
        // The ring size 17*17 = 289 is close to a multiple of 41 (41*7 = 287)
        Vector3 x = 2.0f * fracVec(Vector3.Scale(p, (Vector3.one * C.w))) - Vector3.one * 1.0f;
        Vector3 h = absVec(x) - Vector3.one * 0.5f;
        Vector3 ox = floorVec(x + Vector3.one * 0.5f);
        Vector3 a0 = x - ox;

        // Normalise gradients implicitly by scaling m
        m = Vector3.Scale(m, taylorInvSqrt(Vector3.Scale(a0, a0) + Vector3.Scale(h, h)));

        // Compute final noise value at P
        Vector3 g;
        g.x = a0.x * x0.x + h.x * x0.y;
        g.y = a0.y * x1.x + h.y * x1.y;
        g.z = a0.z * x2.x + h.z * x2.y;
        return 130.0f * Vector3.Dot(m, g);
    }

    public static Vector3 snoise_grad(Vector2 v)
    {
        Vector2 i = floorVec(v + Vector2.one * Vector2.Dot(v, Vector2.one * C.y));
        Vector2 x0 = v - i + Vector2.one * Vector2.Dot(i, Vector2.one * C.x);

        // Other corners
        Vector2 i1;
        i1.x = x0.y >= x0.x ? 1 : 0;
        i1.y = 1.0f - i1.x;

        // x1 = x0 - i1  + 1.0 * C.xx;
        // x2 = x0 - 1.0 + 2.0 * C.xx;
        Vector2 x1 = x0 + Vector2.one * C.x - i1;
        Vector2 x2 = x0 + Vector2.one * C.z;

        // Permutations
        i = mod289(i); // Avoid truncation effects in permutation
        Vector3 p =
          permute(permute(Vector3.one * i.y + new Vector3(0.0f, i1.y, 1.0f))
                        + Vector3.one * i.x + new Vector3(0.0f, i1.x, 1.0f));

        Vector3 m = Vector3.Max(Vector3.one * 0.5f - new Vector3(Vector2.Dot(x0, x0), Vector2.Dot(x1, x1), Vector2.Dot(x2, x2)), Vector3.zero);
        Vector3 m2 = Vector3.Scale(m, m);
        Vector3 m3 = Vector3.Scale(m2, m);
        Vector3 m4 = Vector3.Scale(m2, m2);

        // Gradients: 41 points uniformly over a line, mapped onto a diamond.
        // The ring size 17*17 = 289 is close to a multiple of 41 (41*7 = 287)
        Vector3 x = 2.0f * fracVec(Vector3.Scale(p, (Vector3.one * C.w))) - Vector3.one * 1.0f;
        Vector3 h = absVec(x) - Vector3.one * 0.5f;
        Vector3 ox = floorVec(x + Vector3.one * 0.5f);
        Vector3 a0 = x - ox;

        // Normalise gradients
        Vector3 norm = taylorInvSqrt(Vector3.Scale(a0, a0) + Vector3.Scale(h, h));
        Vector2 g0 = new Vector2(a0.x, h.x) * norm.x;
        Vector2 g1 = new Vector2(a0.y, h.y) * norm.y;
        Vector2 g2 = new Vector2(a0.z, h.z) * norm.z;

        // Compute noise and gradient at P
        Vector2 grad =
          -6.0f * m3.x * x0 * Vector2.Dot(x0, g0) + m4.x * g0 +
          -6.0f * m3.y * x1 * Vector2.Dot(x1, g1) + m4.y * g1 +
          -6.0f * m3.z * x2 * Vector2.Dot(x2, g2) + m4.z * g2;
        Vector3 px = new Vector3(Vector2.Dot(x0, g0), Vector2.Dot(x1, g1), Vector2.Dot(x2, g2));
        return 130.0f * new Vector3(grad.x, grad.y, Vector3.Dot(m4, px));
    }


}
