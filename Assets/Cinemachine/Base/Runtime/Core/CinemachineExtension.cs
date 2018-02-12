using System.Collections.Generic;
using UnityEngine;

namespace Cinemachine
{
    /// <summary>
    /// Base class for a Cinemachine Virtual Camera extension module.
    /// Hooks into the Cinemachine Pipeline.
    /// </summary>
    [DocumentationSorting(23, DocumentationSortingAttribute.Level.API)]
    public abstract class CinemachineExtension : MonoBehaviour
    {
        /// <summary>Useful constant for very small floats</summary>
        protected const float Epsilon = Utility.UnityVectorExtensions.Epsilon;

        /// <summary>Get the associated CinemachineVirtualCameraBase</summary>
        public CinemachineVirtualCameraBase VirtualCamera 
        { 
            get
            {
                if (m_vcamOwner == null)
                    m_vcamOwner = GetComponent<CinemachineVirtualCameraBase>();
                return m_vcamOwner;
            }
        }
        CinemachineVirtualCameraBase m_vcamOwner;

        /// <summary>Connect to virtual camera pipeline.
        /// Override implementations must call this base implementation</summary>
        protected virtual void Awake()
        {
            ConnectToVcam();
        }

        /// <summary>Disconnect from virtual camera pipeline.
        /// Override implementations must call this base implementation</summary>
        protected virtual void OnDestroy()
        {
            if (VirtualCamera != null)
                VirtualCamera.RemovePostPipelineStageHook(PostPipelineStageCallback);
        }

        void ConnectToVcam()
        {
            if (VirtualCamera == null)
                Debug.LogError("CinemachineExtension requires a Cinemachine Virtual Camera component");
            else
                VirtualCamera.AddPostPipelineStageHook(PostPipelineStageCallback);
            mExtraState = null;
        }

        /// <summary>
        /// This callback will be called after the virtual camera has implemented
        /// each stage in the pipeline.  This method may modify the referenced state.
        /// If deltaTime less than 0, reset all state info and perform no damping. 
        /// </summary>
        protected abstract void PostPipelineStageCallback(
            CinemachineVirtualCameraBase vcam,
            CinemachineCore.Stage stage, ref CameraState state, float deltaTime);

        /// <summary>Because extensions can be placed on manager cams and will in that
        /// case be called for all the vcam children, vcam-specific state information
        /// should be stored here.  Just define a class to hold your state info
        /// and use it exclusively when calling this.</summary>
        protected T GetExtraState<T>(ICinemachineCamera vcam) where T : class, new()
        {
            if (mExtraState == null)
                mExtraState = new Dictionary<ICinemachineCamera, System.Object>();
            System.Object extra = null;
            if (!mExtraState.TryGetValue(vcam, out extra))
                extra = mExtraState[vcam] = new T();
            return extra as T;
        }

        /// <summary>Ineffeicient method to get all extra state infor for all vcams.  
        /// Intended for Editor use only, not runtime!
        /// </summary>
        protected List<T> GetAllExtraStates<T>() where T : class, new()
        {
            var list = new List<T>();
            if (mExtraState != null)
                foreach (var v in mExtraState)
                    list.Add(v.Value as T);
            return list;
        }

        private Dictionary<ICinemachineCamera, System.Object> mExtraState;
    }
}
