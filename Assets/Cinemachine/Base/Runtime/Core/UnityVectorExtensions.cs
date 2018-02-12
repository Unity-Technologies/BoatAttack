using UnityEngine;

namespace Cinemachine.Utility
{
    /// <summary>Extensions to the Vector3 class, used by Cinemachine</summary>
    public static class UnityVectorExtensions
    {
        /// <summary>A useful Epsilon</summary>
        public const float Epsilon = 0.0001f;

        /// <summary>
        /// Get the closest point on a line segment.
        /// </summary>
        /// <param name="p">A point in space</param>
        /// <param name="s0">Start of line segment</param>
        /// <param name="s1">End of line segment</param>
        /// <returns>The interpolation parameter representing the point on the segment, with 0==s0, and 1==s1</returns>
        public static float ClosestPointOnSegment(this Vector3 p, Vector3 s0, Vector3 s1)
        {
            Vector3 s = s1 - s0;
            float len2 = Vector3.SqrMagnitude(s);
            if (len2 < Epsilon)
                return 0; // degenrate segment
            return Mathf.Clamp01(Vector3.Dot(p - s0, s) / len2);
        }

        /// <summary>
        /// Get the closest point on a line segment.
        /// </summary>
        /// <param name="p">A point in space</param>
        /// <param name="s0">Start of line segment</param>
        /// <param name="s1">End of line segment</param>
        /// <returns>The interpolation parameter representing the point on the segment, with 0==s0, and 1==s1</returns>
        public static float ClosestPointOnSegment(this Vector2 p, Vector2 s0, Vector2 s1)
        {
            Vector2 s = s1 - s0;
            float len2 = Vector2.SqrMagnitude(s);
            if (len2 < Epsilon)
                return 0; // degenrate segment
            return Mathf.Clamp01(Vector2.Dot(p - s0, s) / len2);
        }

        /// <summary>
        /// Returns a non-normalized projection of the supplied vector onto a plane
        /// as described by its normal
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="planeNormal">The normal that defines the plane.  Cannot be zero-length.</param>
        /// <returns>The component of the vector that lies in the plane</returns>
        public static Vector3 ProjectOntoPlane(this Vector3 vector, Vector3 planeNormal)
        {
            return (vector - Vector3.Dot(vector, planeNormal) * planeNormal);
        }

        /// <summary>Is the vector within Epsilon of zero length?</summary>
        /// <param name="v"></param>
        /// <returns>True if the square magnitude of the vector is within Epsilon of zero</returns>
        public static bool AlmostZero(this Vector3 v)
        {
            return v.sqrMagnitude < (Epsilon * Epsilon);
        }

        /// <summary>Get a signed angle between two vectors</summary>
        /// <param name="from">Start direction</param>
        /// <param name="to">End direction</param>
        /// <param name="refNormal">This is needed in order to determine the sign.
        /// For example, if from an to lie on the XZ plane, then this would be the
        /// Y unit vector, or indeed any vector which, when dotted with Y unit vector,
        /// would give a positive result.</param>
        /// <returns>The signed angle between the vectors</returns>
        public static float SignedAngle(Vector3 from, Vector3 to, Vector3 refNormal)
        {
            from.Normalize();
            to.Normalize();
            float dot = Vector3.Dot(Vector3.Cross(from, to), refNormal);
            if (Mathf.Abs(dot) < -Epsilon)
                return Vector3.Dot(from, to) < 0 ? 180 : 0;
            float angle = Vector3.Angle(from, to);
            if (dot < 0)
                return -angle;
            return angle;
        }

        /// <summary>This is a slerp that mimics a camera operator's movement in that
        /// it chooses a path that avoids the lower hemisphere, as defined by
        /// the up param</summary>
        /// <param name="vA">First direction</param>
        /// <param name="vB">Second direction</param>
        /// <param name="t">Interpolation amoun t</param>
        /// <param name="up">Defines the up direction</param>
        public static Vector3 SlerpWithReferenceUp(
            Vector3 vA, Vector3 vB, float t, Vector3 up)
        {
            float dA = vA.magnitude;
            float dB = vB.magnitude;
            if (dA < Epsilon || dB < Epsilon)
                return Vector3.Lerp(vA, vB, t);

            Vector3 dirA = vA / dA;
            Vector3 dirB = vB / dB;
            Quaternion qA = Quaternion.LookRotation(dirA, up);
            Quaternion qB = Quaternion.LookRotation(dirB, up);
            Quaternion q = UnityQuaternionExtensions.SlerpWithReferenceUp(qA, qB, t, up);
            Vector3 dir = q * Vector3.forward;
            return dir * Mathf.Lerp(dA, dB, t);
        }
    }

    /// <summary>Extentions to the Quaternion class, usen in various places by Cinemachine</summary>
    public static class UnityQuaternionExtensions
    {
        /// <summary>This is a slerp that mimics a camera operator's movement in that
        /// it chooses a path that avoids the lower hemisphere, as defined by
        /// the up param</summary>
        /// <param name="qA">First direction</param>
        /// <param name="qB">Second direction</param>
        /// <param name="t">Interpolation amoun t</param>
        /// <param name="up">Defines the up direction</param>
        public static Quaternion SlerpWithReferenceUp(
            Quaternion qA, Quaternion qB, float t, Vector3 up)
        {
            Vector3 dirA = (qA * Vector3.forward).ProjectOntoPlane(up);
            Vector3 dirB = (qB * Vector3.forward).ProjectOntoPlane(up);
            if (dirA.AlmostZero() || dirB.AlmostZero())
                return Quaternion.Slerp(qA, qB, t);

            // Work on the plane, in eulers
            Quaternion qBase = Quaternion.LookRotation(dirA, up);
            Quaternion qA1 = Quaternion.Inverse(qBase) * qA;
            Quaternion qB1 = Quaternion.Inverse(qBase) * qB;
            Vector3 eA = qA1.eulerAngles;
            Vector3 eB = qB1.eulerAngles;
            return qBase * Quaternion.Euler(
                Mathf.LerpAngle(eA.x, eB.x, t),
                Mathf.LerpAngle(eA.y, eB.y, t),
                Mathf.LerpAngle(eA.z, eB.z, t));
        }

        /// <summary>Normalize a quaternion</summary>
        /// <param name="q"></param>
        /// <returns>The normalized quaternion.  Unit length is 1.</returns>
        public static Quaternion Normalized(this Quaternion q)
        {
            Vector4 v = new Vector4(q.x, q.y, q.z, q.w).normalized;
            return new Quaternion(v.x, v.y, v.z, v.w);
        }

        /// <summary>
        /// Get the rotations, first about world up, then about (travelling) local right,
        /// necessary to align the quaternion's forward with the target direction.
        /// This represents the tripod head movement needed to look at the target.
        /// This formulation makes it easy to interpolate without introducing spurious roll.
        /// </summary>
        /// <param name="orient"></param>
        /// <param name="lookAtDir">The worldspace target direction in which we want to look</param>
        /// <param name="worldUp">Which way is up</param>
        /// <returns>Vector2.y is rotation about worldUp, and Vector2.x is second rotation,
        /// about local right.</returns>
        public static Vector2 GetCameraRotationToTarget(
            this Quaternion orient, Vector3 lookAtDir, Vector3 worldUp)
        {
            if (lookAtDir.AlmostZero())
                return Vector2.zero;  // degenerate

            // Work in local space
            Quaternion toLocal = Quaternion.Inverse(orient);
            Vector3 up = toLocal * worldUp;
            lookAtDir = toLocal * lookAtDir;

            // Align yaw based on world up
            float angleH = 0;
            {
                Vector3 targetDirH = lookAtDir.ProjectOntoPlane(up);
                if (!targetDirH.AlmostZero())
                {
                    Vector3 currentDirH = Vector3.forward.ProjectOntoPlane(up);
                    if (currentDirH.AlmostZero())
                    {
                        // We're looking at the north or south pole
                        if (Vector3.Dot(currentDirH, up) > 0)
                            currentDirH = Vector3.down.ProjectOntoPlane(up);
                        else
                            currentDirH = Vector3.up.ProjectOntoPlane(up);
                    }
                    angleH = UnityVectorExtensions.SignedAngle(currentDirH, targetDirH, up);
                }
            }
            Quaternion q = Quaternion.AngleAxis(angleH, up);

            // Get local vertical angle
            float angleV = UnityVectorExtensions.SignedAngle(
                    q * Vector3.forward, lookAtDir, q * Vector3.right);

            return new Vector2(angleV, angleH);
        }

        /// <summary>
        /// Apply rotations, first about world up, then about (travelling) local right.
        /// rot.y is rotation about worldUp, and rot.x is second rotation, about local right.
        /// </summary>
        /// <param name="orient"></param>
        /// <param name="rot">Vector2.y is rotation about worldUp, and Vector2.x is second rotation,
        /// about local right.</param>
        /// <param name="worldUp">Which way is up</param>
        public static Quaternion ApplyCameraRotation(
            this Quaternion orient, Vector2 rot, Vector3 worldUp)
        {
            Quaternion q = Quaternion.AngleAxis(rot.x, Vector3.right);
            return (Quaternion.AngleAxis(rot.y, worldUp) * orient) * q;
        }
    }

    /// <summary>Ad-hoc xxtentions to the Rect structure, used by Cinemachine</summary>
    public static class UnityRectExtensions
    {
        /// <summary>Inflate a rect</summary>
        /// <param name="r"></param>
        /// <param name="delta">x and y are added/subtracted fto/from the edges of
        /// the rect, inflating it in all directions</param>
        /// <returns>The inflated rect</returns>
        public static Rect Inflated(this Rect r, Vector2 delta)
        {
            return new Rect(
                r.xMin - delta.x, r.yMin - delta.y,
                r.width + delta.x * 2, r.height + delta.y * 2);
        }
    }
}
