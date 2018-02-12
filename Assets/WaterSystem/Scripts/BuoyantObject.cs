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

namespace WaterSystem
{
    public class BuoyantObject : MonoBehaviour
    {
        public float density;
        public float volume;
        public int slicesPerAxis = 2;
        public float voxelResolution = 0.51f;
        private Bounds voxelBounds;
        private Vector3 com;
        public Vector3 centerOfMass = Vector3.zero;
        public bool isConcave = false;
        public int voxelsLimit = 16;

        private const float DAMPFER = 0.1f;
        private const float WATER_DENSITY = 1000;

        private float voxelHalfHeight;
        private Vector3 localArchimedesForce;
		[SerializeField]
        List<Vector3> voxels;
        float[] heights;
        private int curVoxel = 0;
        private bool isMeshCollider;
        Collider coll;
        Rigidbody RB;
        Water water;
        private List<Vector3[]> forces; // For drawing force gizmos
        private List<Vector3> upForces = new List<Vector3>();
        public float percentSubmerged = 0f;

		void Initialize()
		{
            SliceIntoVoxels();
        }

        /// <summary>
        /// Provides initialization.
        /// </summary>
        private void Start()
        {
            forces = new List<Vector3[]>(); // For drawing force gizmos

            // Store original rotation and position
            var originalRotation = transform.rotation;
            var originalPosition = transform.position;
            transform.rotation = Quaternion.identity;
            transform.position = Vector3.zero;

            // The object must have a coll
            coll = GetComponent<Collider>();
            if (coll == null)
            {
                gameObject.AddComponent<MeshCollider>();
                Debug.LogWarning(string.Format("[Buoyancy.cs] Object \"{0}\" had no coll. MeshCollider has been added.", name));
            }
            isMeshCollider = GetComponent<MeshCollider>() != null;

            var bounds = coll.bounds;
            if (bounds.size.x < bounds.size.y)
            {
                voxelHalfHeight = bounds.size.x;
            }
            else
            {
                voxelHalfHeight = bounds.size.y;
            }
            if (bounds.size.z < voxelHalfHeight)
            {
                voxelHalfHeight = bounds.size.z;
            }
            voxelHalfHeight /= 2 * slicesPerAxis;

			SliceIntoVoxels();
            heights = new float[voxels.Count];

            // The object must have a RidigBody
            RB = GetComponent<Rigidbody>();
            if (RB == null)
            {
                RB = gameObject.AddComponent<Rigidbody>();
                Debug.LogWarning(string.Format("[Buoyancy.cs] Object \"{0}\" had no Rigidbody. Rigidbody has been added.", name));
            }
            RB.centerOfMass = com;

            // Restore original rotation and position
            transform.rotation = originalRotation;
            transform.position = originalPosition;

            //float volume = RB.mass / density;

            float archimedesForceMagnitude = WATER_DENSITY * Mathf.Abs(Physics.gravity.y) * volume;
            localArchimedesForce = new Vector3(0, archimedesForceMagnitude, 0) / voxels.Count;

            for(int f = 0; f < voxels.Count; f++)
            {
                upForces.Add(Vector3.zero);
            }

            water = Water.Instance;
            Debug.Log(string.Format("[Buoyancy.cs] Name=\"{0}\" volume={1:0.0}, mass={2:0.0}, density={3:0.0}", name, volume, RB.mass, density));
        }

        /// <summary>
        /// Slices the object into number of voxels represented by their center points.
        /// <param name="concave">Whether the object have a concave shape.</param>
        /// <returns>List of voxels represented by their center points.</returns>
        /// </summary>
		[ContextMenu("Voxelize")]
        private void SliceIntoVoxels()
        {
			Quaternion rot = transform.rotation;
            Vector3 pos = transform.position;
            Vector3 size = transform.localScale;
            transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
            transform.localScale = Vector3.one;

            voxels = null;
            var points = new List<Vector3>();

            voxelBounds = VoxelBounds();
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

						if (PointIsInsideCollider(coll, p))
						{
							points.Add(p);
						}
					}
				}
            }

			if (points.Count == 0)
            {
                //points.Add(bounds.center);
            }

            voxels = points;
			transform.SetPositionAndRotation(pos, rot);
            transform.localScale = size;
            volume = Mathf.Pow(voxelResolution * 0.75f, 3f) * voxels.Count;
            density = GetComponent<Rigidbody>().mass / volume;
        }

		Bounds VoxelBounds()
		{
            if (coll == null)
                coll = GetComponent<Collider>();
			Collider[] myColliders = GetComponentsInChildren<Collider>();
            Bounds bounds = coll.bounds;
            foreach (Collider nextCollider in myColliders)
            {
                bounds.Encapsulate(nextCollider.bounds);
            }
            bounds.size = RoundVector(bounds.size, voxelResolution);
            com = bounds.center + centerOfMass;
            return bounds;
		}

		static Vector3 RoundVector(Vector3 vec, float rounding)
		{
            return new Vector3(Mathf.Ceil(vec.x / rounding) * rounding, Mathf.Ceil(vec.y / rounding) * rounding, Mathf.Ceil(vec.z / rounding) * rounding);
        }

        /// <summary>
        /// Returns whether the point is inside the mesh coll.
        /// </summary>
        /// <param name="c">Mesh coll.</param>
        /// <param name="p">Point.</param>
        /// <returns>True - the point is inside the mesh coll. False - the point is outside of the mesh coll. </returns>
        private bool PointIsInsideCollider(Collider c, Vector3 p)
        {
            Vector3 cp = Physics.ClosestPoint(p, c, Vector3.zero, Quaternion.identity);
			
			if(Vector3.Distance(cp, p) < 0.001f)
            	return true;
			else
                return false;
        }

        /// <summary>
        /// Returns two closest points in the list.
        /// </summary>
        /// <param name="list">List of points.</param>
        /// <param name="firstIndex">Index of the first point in the list. It's always less than the second index.</param>
        /// <param name="secondIndex">Index of the second point in the list. It's always greater than the first index.</param>
        private static void FindClosestPoints(IList<Vector3> list, out int firstIndex, out int secondIndex)
        {
            float minDistance = float.MaxValue, maxDistance = float.MinValue;
            firstIndex = 0;
            secondIndex = 1;

            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    float distance = Vector3.Distance(list[i], list[j]);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        firstIndex = i;
                        secondIndex = j;
                    }
                    if (distance > maxDistance)
                    {
                        maxDistance = distance;
                    }
                }
            }
        }

        /// <summary>
        /// Welds closest points.
        /// </summary>
        /// <param name="list">List of points.</param>
        /// <param name="targetCount">Target number of points in the list.</param>
        private static void WeldPoints(IList<Vector3> list, int targetCount)
        {
            if (list.Count <= 2 || targetCount < 2)
            {
                return;
            }

            while (list.Count > targetCount)
            {
                int first, second;
                FindClosestPoints(list, out first, out second);

                var mixed = (list[first] + list[second]) * 0.5f;
                list.RemoveAt(second); // the second index is always greater that the first => removing the second item first
                list.RemoveAt(first);
                list.Add(mixed);
            }
        }

        void Update()
        {
            Vector3 point = transform.TransformPoint(voxels[curVoxel] + ((Vector3.up * voxelResolution) * 0.5f));
            heights[curVoxel] = water.GetWaterHeight(point);
            if(curVoxel < heights.Length - 1)
                curVoxel++;
            else
                curVoxel = 0;
        }

        /// <summary>
        /// Calculates physics.
        /// </summary>
        private void FixedUpdate()
        {
            forces.Clear(); // For drawing force gizmos
            int voxIndex = 0;
            float tempSub = 0f;
            foreach (var point in voxels)
            {
                var wp = transform.TransformPoint(point);
                float waterLevel = heights[voxIndex];

                if (wp.y - voxelHalfHeight < waterLevel)
                {
                    float k = (waterLevel - wp.y) / (2 * voxelHalfHeight) + 0.5f;
                    if (k > 1)
                    {
                        k = 1f;
                        tempSub += 1f / voxels.Count;
                    }
                    else if (k < 0)
                    {
                        k = 0f;
                    }

                    var velocity = RB.GetPointVelocity(wp) / voxels.Count;
                    var localDampingForce = -velocity * DAMPFER * RB.mass;
                    var tempForce = localDampingForce + Mathf.Sqrt(k) * localArchimedesForce;//
                    upForces[voxIndex] = Vector3.Lerp(upForces[voxIndex], tempForce, 0.1f);
                    RB.AddForceAtPosition(upForces[voxIndex], wp);

                    forces.Add(new[] { wp, upForces[voxIndex] }); // For drawing force gizmos
                }
                voxIndex++;
            }
            percentSubmerged = Mathf.Lerp(percentSubmerged, tempSub, Time.fixedDeltaTime * 5f);
            RB.drag = 0.25f + (percentSubmerged * 2f);
            RB.angularDrag = 0.5f + (percentSubmerged * 2f);
        }

        /// <summary>
        /// Draws gizmos.
        /// </summary>
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

			if (voxelBounds != null && voxelResolution >= 0.1f)
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

            //var matrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.lossyScale);
            Gizmos.matrix = Matrix4x4.identity;

            if (forces != null)
            {
                Gizmos.color = Color.cyan;

                foreach (var force in forces)
                {
                    Gizmos.DrawCube(force[0], new Vector3(gizmoSize, gizmoSize, gizmoSize));
                    Gizmos.DrawLine(force[0], force[0] + force[1] / RB.mass);
                }
            }

        }
    }
}