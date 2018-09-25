// Buoyancy.cs
// by Alex Zhdankin
// Version 2.1
//
// http://forum.unity3d.com/threads/72974-Buoyancy-script
//
// Terms of use: do whatever you like
//
// Further tweaks by Andre McGrail
//
//
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

namespace WaterSystem
{
    public class BuoyantObject : MonoBehaviour
    {
        public BuoyancyType _buoyancyType; // type of buoyancy to calculate
        public float density; // density of the object, this is calculated off it's volume and mass
        public float volume; // volume of the object, this is calculated via it's colliders
        public float voxelResolution = 0.51f; // voxel resolution, represents the half size of a voxel when creating the voxel representation
        private Bounds voxelBounds; // bounds of the voxels
        public Vector3 centerOfMass = Vector3.zero; // Center Of Mass offset

        private const float DAMPFER = 0.005f;
        private const float WATER_DENSITY = 1000;

        private float baseDrag; // reference to original drag
        private float baseAngularDrag; // reference to original angular drag
        private int _guid; // GUID for the height system
        private Vector3 localArchimedesForce;

		[SerializeField]
        private Vector3[] voxels; // voxel position
        private float3[] samplePoints; // sample points for height calc
        private float3[] heights; // water height array(only size of 1 when simple or non-physical)
        private float3[] normals; // water normal array(only used when non-physical and size of 1 also when simple)
        [SerializeField]
        Collider[] colliders; // colliders attatched ot this object
        Rigidbody RB;
        private DebugDrawing[] debugInfo; // For drawing force gizmos
        public float percentSubmerged = 0f;

        [ContextMenu("Initialize")]
		void Init()
        {
            voxels = null;
		    
            if(_buoyancyType == BuoyancyType.NonPhysicalVoxel || _buoyancyType == BuoyancyType.PhysicalVoxel) // If voxel based we need colliders and voxels
            {
                SetupColliders();
                SliceIntoVoxels();
                samplePoints = new float3[voxels.Length];
            }

            if (_buoyancyType == BuoyancyType.Physical || _buoyancyType == BuoyancyType.PhysicalVoxel) // If physical, then we need a rigidbody
            {
                // The object must have a RidigBody
                RB = GetComponent<Rigidbody>();
                if (RB == null)
                {
                    RB = gameObject.AddComponent<Rigidbody>();
                    Debug.LogError(string.Format("Buoyancy:Object \"{0}\" had no Rigidbody. Rigidbody has been added.", name));
                }
                RB.centerOfMass = centerOfMass + voxelBounds.center;
                baseDrag = RB.drag;
                baseAngularDrag = RB.angularDrag;
                samplePoints = new float3[voxels.Length];
            }

            if (_buoyancyType == BuoyancyType.NonPhysical || _buoyancyType == BuoyancyType.Physical)
            {
                voxels = new Vector3[1];
                voxels[0] = centerOfMass;
                samplePoints = new float3[1];
            }

            float archimedesForceMagnitude = WATER_DENSITY * Mathf.Abs(Physics.gravity.y) * volume;
            localArchimedesForce = new Vector3(0, archimedesForceMagnitude, 0) / samplePoints.Length;
        }

        private void Start()
        {
            _guid = gameObject.GetInstanceID();

            Init();

            if(_buoyancyType == BuoyancyType.NonPhysical || _buoyancyType == BuoyancyType.Physical)
            {
                debugInfo = new DebugDrawing[1];
                heights = new float3[1];// new NativeSlice<float3>();
                normals = new float3[1];//new NativeSlice<float3>();
            }
            else
            {
                debugInfo = new DebugDrawing[voxels.Length];
                heights = new float3[voxels.Length]; //new NativeSlice<float3>();
            }
        }

        void SetupColliders()
        {
            // The object must have a Collider
            colliders = GetComponentsInChildren<Collider>();
            if(colliders.Length == 0)
            {
                colliders = new Collider[1];
                colliders[0] = gameObject.AddComponent<BoxCollider>();
                Debug.LogError(string.Format("Buoyancy:Object \"{0}\" had no coll. BoxCollider has been added.", name));
            }
        }

        void Update()
        {

        }

        private void FixedUpdate()
        {
            //// previously from update ////
            
            for(var i = 0; i < samplePoints.Length; i++)
            {
                samplePoints[i] = transform.TransformPoint(voxels[i]);
            }
            
            if(_buoyancyType == BuoyancyType.PhysicalVoxel || _buoyancyType == BuoyancyType.Physical) // if acurate the are more points so only heights are needed
            {
                GerstnerWavesJobs.UpdateSamplePoints(samplePoints, _guid, false);
                GerstnerWavesJobs.GetData(_guid, ref heights);
            }
            else
            {
                GerstnerWavesJobs.UpdateSamplePoints(samplePoints, _guid, true);
                GerstnerWavesJobs.GetSimpleData(_guid, ref heights, ref normals);

                if(_buoyancyType == BuoyancyType.NonPhysical)
                {
                    Vector3 vec  = transform.position;
                    vec.y = heights[0].y;
                    transform.position = vec;
                    transform.up = Vector3.Slerp(transform.up, normals[0], Time.deltaTime);
                }
                else if(_buoyancyType == BuoyancyType.NonPhysicalVoxel)
                {
                    // do the voxel non-physical
                }
            }
            
            ///////////////////////////////
            
            
            float submergedAmount = 0f;

            if(_buoyancyType == BuoyancyType.PhysicalVoxel)
            {
                for(var i = 0; i < voxels.Length; i++) BuoyancyForce(voxels[i], heights[i].y, ref submergedAmount, ref debugInfo[i]);
                UpdateDrag(submergedAmount);
            }
            else if(_buoyancyType == BuoyancyType.Physical)
            {
                BuoyancyForce(Vector3.zero, heights[0].y, ref submergedAmount, ref debugInfo[0]);
                UpdateDrag(submergedAmount);
            }
        }

        private void BuoyancyForce(Vector3 position, float waterHeight, ref float submergedAmount, ref DebugDrawing _debug)
        {
            var wp = transform.TransformPoint(position);
            float waterLevel = waterHeight;

            _debug.position = wp;
            _debug.waterHeight = waterLevel;
            _debug.force = Vector3.zero;

            if (wp.y - voxelResolution < waterLevel)
            {
                float k = (waterLevel - (wp.y - voxelResolution)) / (voxelResolution * 2f);
                if (k > 1)
                {
                    k = 1f;
                }
                else if (k < 0)
                {
                    k = 0f;
                }
                submergedAmount += k / voxels.Length;//(math.clamp(waterLevel - (wp.y - voxelResolution), 0f, voxelResolution * 2f) / (voxelResolution * 2f)) / voxels.Count;

                var velocity = RB.GetPointVelocity(wp);
                velocity.y *= 2f;
                var localDampingForce = -velocity * DAMPFER * RB.mass;
                var force = localDampingForce + Mathf.Sqrt(k) * localArchimedesForce;//\
                RB.AddForceAtPosition(force, wp);

                _debug.force = force; // For drawing force gizmos
            }
        }

        private void UpdateDrag(float submergedAmount)
        {
            percentSubmerged = Mathf.Lerp(percentSubmerged, submergedAmount, 0.25f);
            RB.drag = baseDrag + (baseDrag * (percentSubmerged * 10f));
            RB.angularDrag = baseAngularDrag + (percentSubmerged * 0.5f);
        }

        private void SliceIntoVoxels()
        {
			UnityEngine.Quaternion rot = transform.rotation;
            Vector3 pos = transform.position;
            Vector3 size = transform.localScale;
            transform.SetPositionAndRotation(Vector3.zero, UnityEngine.Quaternion.identity);
            transform.localScale = Vector3.one;

            voxels = null;
            var points = new List<Vector3>();

            var rawBounds = VoxelBounds();
            voxelBounds = rawBounds;
            voxelBounds.size = RoundVector(rawBounds.size, voxelResolution);
            for (float ix = -voxelBounds.extents.x; ix < voxelBounds.extents.x; ix += voxelResolution)
            {
                for (float iy = -voxelBounds.extents.y; iy < voxelBounds.extents.y; iy += voxelResolution)
                {
                    for (float iz = -voxelBounds.extents.z; iz < voxelBounds.extents.z; iz += voxelResolution)
                    {
                        float x = (voxelResolution * 0.5f) + ix;
                        float y = (voxelResolution * 0.5f) + iy;
                        float z = (voxelResolution * 0.5f) + iz;

                        var p = new Vector3(x, y, z) + voxelBounds.center;

                        bool inside = false;
                        for(var i = 0; i < colliders.Length; i++)
                        {
                            if (PointIsInsideCollider(colliders[i], p))
                            {
                                inside = true;
                            }
                        }
                        if(inside)
                            points.Add(p);
					}
				}
            }

            voxels = points.ToArray();
			transform.SetPositionAndRotation(pos, rot);
            transform.localScale = size;
            var voxelVolume = Mathf.Pow(voxelResolution, 3f) * voxels.Length;
            var rawVolume = rawBounds.size.x * rawBounds.size.y * rawBounds.size.z;
            volume = Mathf.Min(rawVolume, voxelVolume);
            density = gameObject.GetComponent<Rigidbody>().mass / volume;
        }

		private Bounds VoxelBounds()
		{
            Bounds bounds = new Bounds();
            foreach (Collider nextCollider in colliders)
            {
                bounds.Encapsulate(nextCollider.bounds);
            }
            return bounds;
		}

		static Vector3 RoundVector(Vector3 vec, float rounding)
		{
            return new Vector3(Mathf.Ceil(vec.x / rounding) * rounding, Mathf.Ceil(vec.y / rounding) * rounding, Mathf.Ceil(vec.z / rounding) * rounding);
        }

        private bool PointIsInsideCollider(Collider c, Vector3 p)
        {
            Vector3 cp = Physics.ClosestPoint(p, c, Vector3.zero, UnityEngine.Quaternion.identity);
			return Vector3.Distance(cp, p) < 0.01f ? true : false;
        }

        private void OnDrawGizmosSelected()
        {
			const float gizmoSize = 0.05f;
			var matrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.lossyScale);
            Gizmos.matrix = matrix;

            if (voxels != null)
            {
                Gizmos.color = Color.yellow;

                foreach (var p in voxels)
                {
                    Gizmos.DrawCube(p, new Vector3(gizmoSize, gizmoSize, gizmoSize));
                }
            }

			if (voxelResolution >= 0.1f)
			{
                Gizmos.DrawWireCube(voxelBounds.center, voxelBounds.size);
                Vector3 center = voxelBounds.center;
                float y = center.y - voxelBounds.extents.y;
                for (float x = -voxelBounds.extents.x; x < voxelBounds.extents.x; x += voxelResolution)
				{
                    Gizmos.DrawLine(new Vector3(x, y, -voxelBounds.extents.z + center.z), new Vector3(x, y, voxelBounds.extents.z + center.z));
                }
				for (float z = -voxelBounds.extents.z; z < voxelBounds.extents.z; z += voxelResolution)
                {
					Gizmos.DrawLine(new Vector3(-voxelBounds.extents.x, y, z + center.z), new Vector3(voxelBounds.extents.x, y, z + center.z));
                }
            }
			else
                voxelBounds = VoxelBounds();

            Gizmos.color = Color.red;
            Gizmos.DrawSphere(voxelBounds.center + centerOfMass, 0.2f);

            Gizmos.matrix = Matrix4x4.identity;Gizmos.matrix = Matrix4x4.identity;

            if (debugInfo != null)
            {
                foreach (DebugDrawing debug in debugInfo)
                {
                    Gizmos.color = Color.cyan;
                    Gizmos.DrawCube(debug.position, new Vector3(gizmoSize, gizmoSize, gizmoSize)); // drawCenter
                    Vector3 water = debug.position;
                    water.y = debug.waterHeight;
                    Gizmos.DrawLine(debug.position, water); // draw the water line
                    Gizmos.DrawSphere(water, gizmoSize * 4f);
                    if(_buoyancyType == BuoyancyType.Physical || _buoyancyType == BuoyancyType.PhysicalVoxel)
                    {
                        Gizmos.color = Color.red;
                        Gizmos.DrawRay(debug.position, debug.force / RB.mass); // draw force
                    }
                }
            }

        }

        struct DebugDrawing
        {
            public Vector3 force;
            public Vector3 position;
            public float waterHeight;
        }

        public enum BuoyancyType
        {
            NonPhysical,
            NonPhysicalVoxel,
            Physical,
            PhysicalVoxel
        }
    }
}