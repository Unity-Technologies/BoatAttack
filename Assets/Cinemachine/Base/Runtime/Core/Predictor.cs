using System;
using System.Collections.Generic;
using UnityEngine;

namespace Cinemachine.Utility
{
    internal class PositionPredictor
    {
        Vector3 m_Position;

        const float kSmoothingDefault = 10;
        float mSmoothing = kSmoothingDefault;
        public float Smoothing 
        {
            get { return mSmoothing; }
            set 
            {
                if (value != mSmoothing)
                {
                    mSmoothing = value;
                    int maxRadius = Mathf.Max(10, Mathf.FloorToInt(value * 1.5f));
                    m_Velocity = new GaussianWindow1D_Vector3(mSmoothing, maxRadius);
                    m_Accel = new GaussianWindow1D_Vector3(mSmoothing, maxRadius);
                }
            }
        }

        GaussianWindow1D_Vector3 m_Velocity = new GaussianWindow1D_Vector3(kSmoothingDefault);
        GaussianWindow1D_Vector3 m_Accel = new GaussianWindow1D_Vector3(kSmoothingDefault);

        public bool IsEmpty { get { return m_Velocity.IsEmpty(); } }

        public void Reset()
        {
            m_Velocity.Reset();
            m_Accel.Reset();
        }

        public void AddPosition(Vector3 pos)
        {
            if (IsEmpty)
                m_Velocity.AddValue(Vector3.zero);
            else
            {
                Vector3 vel = m_Velocity.Value();
                Vector3 vel2 = (pos - m_Position) / Time.deltaTime;
                m_Velocity.AddValue(vel2);
                m_Accel.AddValue(vel2 - vel);
            }
            m_Position = pos;
        }

        public Vector3 PredictPosition(float lookaheadTime)
        {
            int numSteps = Mathf.Min(Mathf.RoundToInt(lookaheadTime / Time.deltaTime), 6);
            float dt = lookaheadTime / numSteps;
            Vector3 pos = m_Position;
            Vector3 vel = m_Velocity.IsEmpty() ? Vector3.zero : m_Velocity.Value();
            Vector3 accel = m_Accel.IsEmpty() ? Vector3.zero : m_Accel.Value();
            for (int i = 0; i < numSteps; ++i)
            {
                pos += vel * dt;
                Vector3 vel2 = vel + (accel * dt);
                accel = Quaternion.FromToRotation(vel, vel2) * accel;
                vel = vel2;
            }
            return pos;
        }
    }

    /// <summary>Utility to perform realistic damping of float or Vector3 values.
    /// The algorithm is based on exponentially decaying the delta until only
    /// a negligible amount remains.</summary>
    public static class Damper
    {
        const float Epsilon = UnityVectorExtensions.Epsilon;

        // Get the decay constant that would leave a given residual after a given time
        static float DecayConstant(float time, float residual)
        {
            return Mathf.Log(1f / residual) / time;
        }

        // Exponential decay: decay a given quantity opver a period of time
        static float Decay(float initial, float decayConstant, float deltaTime)
        {
            return initial /  Mathf.Exp(decayConstant * deltaTime);
        }

        /// <summary>Standard residual</summary>
        public const float kNegligibleResidual = 0.01f;

        /// <summary>Get a damped version of a quantity.  This is the portion of the
        /// quantity that will take effect over the given time.</summary>
        /// <param name="initial">The amount that will be damped</param>
        /// <param name="dampTime">The rate of damping.  This is the time it would 
        /// take to reduce the original amount to a negligible percentage</param>
        /// <param name="deltaTime">The time over which to damp</param>
        /// <returns>The damped amount.  This will be the original amount scaled by 
        /// a value between 0 and 1.</returns>
        public static float Damp(float initial, float dampTime, float deltaTime)
        {
            if (dampTime < Epsilon || Mathf.Abs(initial) < Epsilon)
                return initial;
            if (deltaTime < Epsilon)
                return 0;
            return initial - Decay(
                initial, DecayConstant(dampTime, kNegligibleResidual), deltaTime);
        }

        /// <summary>Get a damped version of a quantity.  This is the portion of the
        /// quantity that will take effect over the given time.</summary>
        /// <param name="initial">The amount that will be damped</param>
        /// <param name="dampTime">The rate of damping.  This is the time it would 
        /// take to reduce the original amount to a negligible percentage</param>
        /// <param name="deltaTime">The time over which to damp</param>
        /// <returns>The damped amount.  This will be the original amount scaled by 
        /// a value between 0 and 1.</returns>
        public static Vector3 Damp(Vector3 initial, Vector3 dampTime, float deltaTime)
        {
            for (int i = 0; i < 3; ++i)
                initial[i] = Damp(initial[i], dampTime[i], deltaTime);
            return initial;
        }

        /// <summary>Get a damped version of a quantity.  This is the portion of the
        /// quantity that will take effect over the given time.</summary>
        /// <param name="initial">The amount that will be damped</param>
        /// <param name="dampTime">The rate of damping.  This is the time it would 
        /// take to reduce the original amount to a negligible percentage</param>
        /// <param name="deltaTime">The time over which to damp</param>
        /// <returns>The damped amount.  This will be the original amount scaled by 
        /// a value between 0 and 1.</returns>
        public static Vector3 Damp(Vector3 initial, float dampTime, float deltaTime)
        {
            for (int i = 0; i < 3; ++i)
                initial[i] = Damp(initial[i], dampTime, deltaTime);
            return initial;
        }
    }
}
