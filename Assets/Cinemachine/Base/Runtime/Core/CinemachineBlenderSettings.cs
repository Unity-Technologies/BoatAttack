using UnityEngine;
using System;

namespace Cinemachine
{
    /// <summary>
    /// Asset that defines the rules for blending between Virtual Cameras.
    /// </summary>
    [DocumentationSorting(10, DocumentationSortingAttribute.Level.UserRef)]
    [Serializable]
    public sealed class CinemachineBlenderSettings : ScriptableObject
    {
        /// <summary>
        /// Container specifying how two specific Cinemachine Virtual Cameras
        /// blend together.
        /// </summary>
        [DocumentationSorting(10.1f, DocumentationSortingAttribute.Level.UserRef)]
        [Serializable]
        public struct CustomBlend
        {
            [Tooltip("When blending from this camera")]
            public string m_From;

            [Tooltip("When blending to this camera")]
            public string m_To;

            [Tooltip("Blend curve definition")]
            public CinemachineBlendDefinition m_Blend;
        }
        /// <summary>The array containing explicitly defined blends between two Virtual Cameras</summary>
        [Tooltip("The array containing explicitly defined blends between two Virtual Cameras")]
        public CustomBlend[] m_CustomBlends = null;

        /// <summary>Internal API for the inspector editopr: a label to represent any camera</summary>
        public const string kBlendFromAnyCameraLabel = "**ANY CAMERA**";

        /// <summary>
        /// Attempts to find a blend curve which matches the to and from cameras as specified.
        /// If no match is found, the function returns either the
        /// default blend for this Blender or NULL depending on the state
        /// of <b>returnDefaultOnNoMatch</b>.
        /// </summary>
        /// <param name="fromCameraName">The game object name of the from camera</param>
        /// <param name="toCameraName">The game object name of the to camera</param>
        /// <param name="defaultCurve">Curve to return if no curve found.  Can be NULL.</param>
        /// <returns></returns>
        public AnimationCurve GetBlendCurveForVirtualCameras(
            string fromCameraName, string toCameraName, AnimationCurve defaultCurve)
        {
            AnimationCurve anyToMe = null;
            AnimationCurve meToAny = null;
            if (m_CustomBlends != null)
            {
                for (int i = 0; i < m_CustomBlends.Length; ++i)
                {
                    // Attempt to find direct name first
                    CustomBlend blendParams = m_CustomBlends[i];
                    if ((blendParams.m_From == fromCameraName)
                        && (blendParams.m_To == toCameraName))
                    {
                        return blendParams.m_Blend.BlendCurve;
                    }
                    // If we come across default applicable wildcards, remember them
                    if (blendParams.m_From == kBlendFromAnyCameraLabel)
                    {
                        if (!string.IsNullOrEmpty(toCameraName)
                            && blendParams.m_To == toCameraName)
                        {
                            anyToMe = blendParams.m_Blend.BlendCurve;
                        }
                        else if (blendParams.m_To == kBlendFromAnyCameraLabel)
                            defaultCurve = blendParams.m_Blend.BlendCurve;
                    }
                    else if (blendParams.m_To == kBlendFromAnyCameraLabel
                             && !string.IsNullOrEmpty(fromCameraName)
                             && blendParams.m_From == fromCameraName)
                    {
                        meToAny = blendParams.m_Blend.BlendCurve;
                    }
                }
            }

            // If nothing is found try to find wild card blends from any
            // camera to our new one
            if (anyToMe != null)
                return anyToMe;

            // Still have nothing? Try from our camera to any camera
            if (meToAny != null)
                return meToAny;

            return defaultCurve;
        }
    }
}
