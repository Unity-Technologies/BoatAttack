using System.Collections;
using System.Collections.Generic;
using BoatAttack;
using UnityEngine;


namespace Boat
{
    public class EngineCameraState : MonoBehaviour
    {
        public Engine engine;
        public Animator anim;
//        private int slowHash = Animator.StringToHash("Main.Slow");
//        private int fastHash = Animator.StringToHash("Main.Fast");


        void Update()
        {
            anim.SetFloat("EngineSpeed", engine.VelocityMag);
        }
    }
}