using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Profiling;

namespace BoatTutorial
{
    public class BoatPhysics : MonoBehaviour
    {
		public Mesh boatHull;

        //Script that's doing everything needed with the boat mesh, such as finding out which part is above the water
        private ModifyBoatMesh modifyBoatMesh;

        //public ModifyBoatMesh.TriangleData[] triangleData;

        //Mesh for debugging
        private Mesh underWaterMesh;

        //The boats rigidbody
        private Rigidbody boatRB;

        //The density of the water the boat is traveling in
        private float rhoWater = 1000f;

		public Vector3 centerOfMass;

		public float multiplier = 1f;

		public bool debugMesh = false;

        void Start()
        {
            //Get the boat's rigidbody
            boatRB = gameObject.GetComponent<Rigidbody>();
			boatRB.centerOfMass = centerOfMass;

            //Init the script that will modify the boat mesh
            modifyBoatMesh = new ModifyBoatMesh(gameObject, boatHull);

			//Meshes that are below and above the water
			Mesh mesh = new Mesh();
			mesh.vertices = boatHull.vertices;
			mesh.normals = boatHull.normals;
			mesh.triangles = boatHull.triangles;

            underWaterMesh = mesh;
        }

        void FixedUpdate()
        {
            Profiler.BeginSample("AddUnderwaterForces");
            //boatRB.drag = 0.25f;
            //Add forces to the part of the boat that's below the water
            if (modifyBoatMesh.underWaterTriangleData?.Length > 0)
            {
                AddUnderWaterForces();
            }
            Profiler.EndSample();
        }

        void Update()
        {
            StartCoroutine(modifyBoatMesh.ModifyBoatData());
            //triangleData = modifyBoatMesh.underWaterTriangleData.ToArray();
            //Display the under water mesh
			//if(debugMesh)
            	//modifyBoatMesh.DisplayMesh(underWaterMesh, "UnderWater Mesh", modifyBoatMesh.underWaterTriangleData);
        }

        //Add all forces that act on the squares below the water
        void AddUnderWaterForces()
        {
            //Get all triangles
            ModifyBoatMesh.TriangleData[] underWaterTriangleData = modifyBoatMesh.underWaterTriangleData;

            for (int i = 0; i < underWaterTriangleData.Length; i++)
            {
                //This triangle
                ModifyBoatMesh.TriangleData triangleData = underWaterTriangleData[i];

                //Calculate the buoyancy force
                Vector3 buoyancyForce = BuoyancyForce(rhoWater, triangleData);

                //Add the force to the boat
                boatRB.AddForceAtPosition(buoyancyForce * multiplier, triangleData.center);
                //boatRB.drag += triangleData.area * 0.075f;

                //Debug
				if(debugMesh)
				{
					//Normal
					Debug.DrawRay(triangleData.center, triangleData.normal, Color.white);
                    //Buoyancy
                    //Debug.DrawRay(triangleData.center, buoyancyForce.normalized, Color.blue);
                    Debug.DrawRay(triangleData.center, Vector3.up * triangleData.distanceToSurface, Color.blue);
				}
            }
        }

        //The buoyancy force so the boat can float
        private Vector3 BuoyancyForce(float rho, ModifyBoatMesh.TriangleData triangleData)
        {
            //Buoyancy is a hydrostatic force - it's there even if the water isn't flowing or if the boat stays still

            // F_buoyancy = rho * g * V
            // rho - density of the mediaum you are in
            // g - gravity
            // V - volume of fluid directly above the curved surface 

            // V = z * S * n 
            // z - distance to surface
            // S - surface area
            // n - normal to the surface
            Vector3 buoyancyForce = rho * Physics.gravity.y * triangleData.distanceToSurface * triangleData.area * triangleData.normal;

            //The vertical component of the hydrostatic forces don't cancel out but the horizontal do
            buoyancyForce.x = 0f;
            buoyancyForce.z = 0f;

            return buoyancyForce;
        }

        void OnDisable()
        {
            modifyBoatMesh.BufferCleanup();
        }

		void OnDrawGizmos()
		{
			// if(underWaterMesh && debugMesh)
			// {
			// 	Gizmos.color = Color.red;
			// 	Gizmos.DrawMesh(underWaterMesh, transform.position, transform.rotation);
			// }
			Gizmos.color = Color.green;
			Gizmos.DrawSphere(transform.TransformPoint(centerOfMass), 0.5f);
		}
    }
}