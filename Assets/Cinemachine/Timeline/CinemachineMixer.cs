using UnityEngine;
using UnityEngine.Playables;

namespace Cinemachine.Timeline
{
    public sealed class CinemachineMixer : PlayableBehaviour
    {
        // The brain that this track controls
        private CinemachineBrain mBrain;
        private int mBrainOverrideId = -1;
        private bool mPlaying;

        public override void OnGraphStop(Playable playable)
        {
            if (mBrain != null)
                mBrain.ReleaseCameraOverride(mBrainOverrideId); // clean up
            mBrainOverrideId = -1;
        }

        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            base.ProcessFrame(playable, info, playerData);

            // Get the brain that this track controls.
            // Older versions of timeline sent the gameObject by mistake.
            GameObject go = playerData as GameObject;
            if (go == null)
                mBrain = (CinemachineBrain)playerData;
            else
                mBrain = go.GetComponent<CinemachineBrain>();
            if (mBrain == null)
                return;

            // Find which clips are active.  We can process a maximum of 2.
            // In the case that the weights don't add up to 1, the outgoing weight
            // will be calculated as the inverse of the incoming weight.
            int activeInputs = 0;
            ICinemachineCamera camA = null;
            ICinemachineCamera camB = null;
            float camWeight = 1f;
            for (int i = 0; i < playable.GetInputCount(); ++i)
            {
                CinemachineShotPlayable shot
                    = ((ScriptPlayable<CinemachineShotPlayable>)playable.GetInput(i)).GetBehaviour();
                float weight = playable.GetInputWeight(i);
                if (shot != null && shot.VirtualCamera != null
                    && playable.GetPlayState() == PlayState.Playing
                    && weight > 0.0001f)
                {
                    if (activeInputs == 1)
                        camB = camA;
                    camWeight = weight;
                    camA = shot.VirtualCamera;
                    ++activeInputs;
                    if (activeInputs == 2)
                        break;
                }
            }

            float deltaTime = info.deltaTime;
            if (!mPlaying)
            {
                if (mBrainOverrideId < 0)
                    mLastOverrideFrame = -1;
                float time = Time.realtimeSinceStartup;
                deltaTime = Time.unscaledDeltaTime;
                if (!Application.isPlaying && (mLastOverrideFrame < 0 || time - mLastOverrideFrame > Time.maximumDeltaTime))
                    deltaTime = -1;
                mLastOverrideFrame = time;
            }

            // Override the Cinemachine brain with our results
            mBrainOverrideId = mBrain.SetCameraOverride(
                    mBrainOverrideId, camB, camA, camWeight, deltaTime);

        }
        float mLastOverrideFrame;

        public override void PrepareFrame(Playable playable, FrameData info)
        {
            mPlaying = info.evaluationType == FrameData.EvaluationType.Playback;
        }
    }
}
