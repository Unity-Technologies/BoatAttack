using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace BoatAttack
{
    [ExecuteAlways]
    public class GlobalWind : MonoBehaviour
    {
        public float strength = 5f;
        
        public static Vector2 WindVector;

        private static readonly int BaWindVector = Shader.PropertyToID("_BA_WindVector");

        // Update is called once per frame
        private void Update()
        {
            var forward = transform.forward;
            WindVector = new Vector2(Vector3.Dot(Vector3.right, forward), Vector3.Dot(Vector3.forward, forward)).normalized;
            WindVector *= strength;
            Shader.SetGlobalVector(BaWindVector, WindVector);
        }

        private void OnDrawGizmosSelected()
        {
            var arrowArm = new Vector3(1f, 1f, 4f);
            Gizmos.matrix = transform.localToWorldMatrix;
            Gizmos.DrawCube(Vector3.zero, arrowArm);
            Gizmos.DrawSphere(Vector3.forward * 2f, 1f);
        }
    }
}
