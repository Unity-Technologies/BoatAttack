using UnityEngine;
using System;

namespace Cinemachine
{
    /// <summary>
    /// This is an asset that defines a noise profile.  A noise profile is the 
    /// shape of the noise as a function of time.  You can build arbitrarily complex shapes by
    /// combining different base perlin noise frequencies at different amplitudes.
    /// 
    /// The frequencies and amplitudes should be chosen with care, to ensure an interesting
    /// noise quality that is not obviously repetitive.
    /// 
    /// As a mathematical side-note, any arbitrary periodic curve can be broken down into a 
    /// series of fixed-amplitude sine-waves added together.  This is called fourier decomposition,
    /// and is the basis of much signal processing.  It doesn't really have much to do with this
    /// asset, but it's super interesting!
    /// </summary>
    [DocumentationSorting(9, DocumentationSortingAttribute.Level.UserRef)]
    public sealed class NoiseSettings : ScriptableObject
    {
        /// <summary>
        /// Describes the behaviour for a channel of noise
        /// </summary>
        [DocumentationSorting(9.1f, DocumentationSortingAttribute.Level.UserRef)]
        [Serializable]
        public struct NoiseParams
        {
            /// <summary>The amplitude of the noise for this channel.  Larger numbers vibrate higher</summary>
            [Tooltip("The amplitude of the noise for this channel.  Larger numbers vibrate higher.")]
            public float Amplitude;
            /// <summary>The frequency of noise for this channel.  Higher magnitudes vibrate faster</summary>
            [Tooltip("The frequency of noise for this channel.  Higher magnitudes vibrate faster.")]
            public float Frequency;
        }

        /// <summary>
        /// Contains the behaviour of noise for the noise module for all 3 cardinal axes of the camera
        /// </summary>
        [DocumentationSorting(9.2f, DocumentationSortingAttribute.Level.UserRef)]
        [Serializable]
        public struct TransformNoiseParams
        {
            /// <summary>Noise definition for X-axis</summary>
            [Tooltip("Noise definition for X-axis")]
            public NoiseParams X;
            /// <summary>Noise definition for Y-axis</summary>
            [Tooltip("Noise definition for Y-axis")]
            public NoiseParams Y;
            /// <summary>Noise definition for Z-axis</summary>
            [Tooltip("Noise definition for Z-axis")]
            public NoiseParams Z;
        }

        [SerializeField]
        [Tooltip("These are the noise channels for the virtual camera's position. Convincing noise setups typically mix low, medium and high frequencies together, so start with a size of 3")]
        private TransformNoiseParams[] m_Position = new TransformNoiseParams[0];

        /// <summary>
        /// Gets the array of positional noise channels for this <c>NoiseSettings</c>
        /// </summary>
        public TransformNoiseParams[] PositionNoise { get { return m_Position; } }

        [SerializeField]
        [Tooltip("These are the noise channels for the virtual camera's orientation. Convincing noise setups typically mix low, medium and high frequencies together, so start with a size of 3")]
        private TransformNoiseParams[] m_Orientation = new TransformNoiseParams[0];

        /// <summary>
        /// Gets the array of orientation noise channels for this <c>NoiseSettings</c>
        /// </summary>
        public TransformNoiseParams[] OrientationNoise { get { return m_Orientation; } }

        /// <summary>Clones the contents of the other asset into this one</summary>
        public void CopyFrom(NoiseSettings other)
        {
            m_Position = new TransformNoiseParams[other.m_Position.Length];
            other.m_Position.CopyTo(m_Position, 0);
            m_Orientation = new TransformNoiseParams[other.m_Orientation.Length];
            other.m_Orientation.CopyTo(m_Orientation, 0);
        }
    }
}
