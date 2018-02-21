using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using WaterSystem;
using UnityEngine.Profiling;

namespace BoatTutorial
{
    //Generates the mesh that's below the water
    public class ModifyBoatMesh
    {
        //The boat transform needed to get the global position of a vertice
        private Transform boatTrans;
        //Coordinates of all vertices in the original boat
        Vector3[] boatVertices;
        //Positions in allVerticesArray, such as 0, 3, 5, to build triangles
        int[] boatTriangles;

        //So we only need to make the transformation from local to global once
        public Vector3[] boatVerticesGlobal;
        //Find all the distances to water once because some triangles share vertices, so reuse
        float[] allDistancesToWater;

        //The triangles belonging to the part of the boat that's under water
        public List<TriangleData> underWaterTriangleData = new List<TriangleData>();

        //List that will store the data we need to sort the vertices based on distance to water
        VertexData[] vertexData = new VertexData[3];

        public ModifyBoatMesh(GameObject boatObj, Mesh mesh)
        {
            //Get the transform
            boatTrans = boatObj.transform;

            //Init the arrays and lists
			boatVertices = mesh.vertices;
            boatTriangles = mesh.triangles;

            //The boat vertices in global position
            boatVerticesGlobal = new Vector3[boatVertices.Length];
            //Find all the distances to water once because some triangles share vertices, so reuse
            allDistancesToWater = new float[boatVertices.Length];

            vertexData[0] = new VertexData();
            vertexData[1] = new VertexData();
            vertexData[2] = new VertexData();
        }

        //Generate the underwater mesh
        public void GenerateUnderwaterMesh()
        {
            //Reset
            underWaterTriangleData.Clear();

            //Find all the distances to water once because some triangles share vertices, so reuse
            for (int j = 0; j < boatVertices.Length; j++)
            {
                //The coordinate should be in global position
                Vector3 globalPos = boatTrans.TransformPoint(boatVertices[j]);

                //Save the global position so we only need to calculate it once here
                //And if we want to debug we can convert it back to local
                boatVerticesGlobal[j] = globalPos;
                if(j%2==0)
                {
                    allDistancesToWater[j] = -Water.Instance.GetWaterHeight(globalPos);
                }
                else
                {
                    allDistancesToWater[j] = allDistancesToWater[j-1];
                }
            }//Water.Instance.GetWaterHeights(new Vector3[]{Vector3.zero, Vector3.zero});

            //Add the triangles that are below the water
            Profiler.BeginSample("AddTriangles");
            AddTriangles();
            Profiler.EndSample();
        }

        //Add all the triangles that's part of the underwater mesh
        private void AddTriangles()
        {
            //Loop through all the triangles (3 vertices at a time = 1 triangle)
            int i = 0;
            while(i < boatTriangles.Length)
            {
                int countAboveWater = 3;
                //Loop through the 3 vertices
                for (int x = 0; x < 3; x++)
                {
                    //Save the data we need
                    vertexData[x].distance = allDistancesToWater[boatTriangles[i]];

                    if(vertexData[x].distance < 0f)
                        countAboveWater--;

                    vertexData[x].index = x;

                    vertexData[x].globalVertexPos = boatVerticesGlobal[boatTriangles[i]];
                    i++;
                }

                // if(countAboveWater < 2)
                // {
                //     Vector3 p1 = vertexData[0].globalVertexPos;
                //     Vector3 p2 = vertexData[1].globalVertexPos;
                //     Vector3 p3 = vertexData[2].globalVertexPos;
                //     //Save the triangle
                //     underWaterTriangleData.Add(new TriangleData(p1, p2, p3));
                // }
                // else
                // {
                //     break;
                // }
                //Debug.Log(countAboveWater);
                switch(countAboveWater)
                {
                    case 3:
                    break;
                    case 0:
                    {
                        Vector3 p1 = vertexData[0].globalVertexPos;
                        Vector3 p2 = vertexData[1].globalVertexPos;
                        Vector3 p3 = vertexData[2].globalVertexPos;
                        Vector3 d = new Vector3(vertexData[0].distance, vertexData[1].distance, vertexData[2].distance);
                        //Save the triangle
                        underWaterTriangleData.Add(new TriangleData(p1, p2, p3, d, true));
                    }
                    break;
                    case 1:
                    {
                        Array.Sort(vertexData, delegate(VertexData v1, VertexData v2){return v2.distance.CompareTo(v1.distance);});
                        Profiler.BeginSample("AddTrianglesOneAboveWater");
                        AddTrianglesOneAboveWater();
                        Profiler.EndSample();
                    }
                    break;
                    case 2:
                    {
                        Array.Sort(vertexData, delegate(VertexData v1, VertexData v2){return v2.distance.CompareTo(v1.distance);});
                        Profiler.BeginSample("AddTrianglesTwoAboveWater");
                        AddTrianglesTwoAboveWater();
                        Profiler.EndSample();
                    }
                    break;
                }
            }
        }

        //Build the new triangles where one of the old vertices is above the water
        private void AddTrianglesOneAboveWater()
        {
            //H is always at position 0
            Vector3 H = vertexData[0].globalVertexPos;

            //Left of H is M
            //Right of H is L

            //Find the index of M
            int M_index = vertexData[0].index - 1;
            if (M_index < 0)
            {
                M_index = 2;
            }

            //We also need the heights to water
            float h_H = vertexData[0].distance;
            float h_M = 0f;
            float h_L = 0f;

            Vector3 M = Vector3.zero;
            Vector3 L = Vector3.zero;

            //This means M is at position 1 in the List
            if (vertexData[1].index == M_index)
            {
                M = vertexData[1].globalVertexPos;
                L = vertexData[2].globalVertexPos;

                h_M = vertexData[1].distance;
                h_L = vertexData[2].distance;
            }
            else
            {
                M = vertexData[2].globalVertexPos;
                L = vertexData[1].globalVertexPos;

                h_M = vertexData[2].distance;
                h_L = vertexData[1].distance;
            }

			
            //Now we can calculate where we should cut the triangle to form 2 new triangles
            //because the resulting area will always form a square

            //Point I_M
            Vector3 MH = H - M;

            float t_M = -h_M / (h_H - h_M);

            Vector3 MI_M = t_M * MH;

            Vector3 I_M = MI_M + M;


            //Point I_L
            Vector3 LH = H - L;

            float t_L = -h_L / (h_H - h_L);

            Vector3 LI_L = t_L * LH;

            Vector3 I_L = LI_L + L;

            //Save the data, such as normal, area, etc      
            //2 triangles below the water  
            underWaterTriangleData.Add(new TriangleData(M, I_M, I_L, Vector3.zero, false));
            underWaterTriangleData.Add(new TriangleData(M, I_L, L, Vector3.zero, false));
        }

        //Build the new triangles where two of the old vertices are above the water
        private void AddTrianglesTwoAboveWater()
        {
            //H and M are above the water
            //H is after the vertice that's below water, which is L
            //So we know which one is L because it is last in the sorted list
            Vector3 L = vertexData[2].globalVertexPos;

            //Find the index of H
            int H_index = vertexData[2].index + 1;
            if (H_index > 2)
            {
                H_index = 0;
            }


            //We also need the heights to water
            float h_L = vertexData[2].distance;
            float h_H = 0f;
            float h_M = 0f;

            Vector3 H = Vector3.zero;
            Vector3 M = Vector3.zero;

            //This means that H is at position 1 in the list
            if (vertexData[1].index == H_index)
            {
                H = vertexData[1].globalVertexPos;
                M = vertexData[0].globalVertexPos;

                h_H = vertexData[1].distance;
                h_M = vertexData[0].distance;
            }
            else
            {
                H = vertexData[0].globalVertexPos;
                M = vertexData[1].globalVertexPos;

                h_H = vertexData[0].distance;
                h_M = vertexData[1].distance;
            }


            //Now we can find where to cut the triangle

            //Point J_M
            Vector3 LM = M - L;

            float t_M = -h_L / (h_M - h_L);

            Vector3 LJ_M = t_M * LM;

            Vector3 J_M = LJ_M + L;


            //Point J_H
            Vector3 LH = H - L;

            float t_H = -h_L / (h_H - h_L);

            Vector3 LJ_H = t_H * LH;

            Vector3 J_H = LJ_H + L;


            //Save the data, such as normal, area, etc
            //1 triangle below the water
            underWaterTriangleData.Add(new TriangleData(L, J_H, J_M, Vector3.zero, false));
        }

        //Help class to store triangle data so we can sort the distances
        private class VertexData
        {
            //The distance to water from this vertex
            public float distance;
            //An index so we can form clockwise triangles
            public int index;
            //The global Vector3 position of the vertex
            public Vector3 globalVertexPos;
        }

        //Display the underwater mesh
        public void DisplayMesh(Mesh mesh, string name, List<TriangleData> triangesData)
        {
            List<Vector3> vertices = new List<Vector3>();
            List<int> triangles = new List<int>();

            //Build the mesh
            for (int i = 0; i < triangesData.Count; i++)
            {
                //From global coordinates to local coordinates
                Vector3 p1 = boatTrans.InverseTransformPoint(triangesData[i].p1);
                Vector3 p2 = boatTrans.InverseTransformPoint(triangesData[i].p2);
                Vector3 p3 = boatTrans.InverseTransformPoint(triangesData[i].p3);

                vertices.Add(p1);
                triangles.Add(vertices.Count - 1);

                vertices.Add(p2);
                triangles.Add(vertices.Count - 1);

                vertices.Add(p3);
                triangles.Add(vertices.Count - 1);
            }

            //Remove the old mesh
            mesh.Clear();

            //Give it a name
            mesh.name = name;

            //Add the new vertices and triangles
            mesh.vertices = vertices.ToArray();

            mesh.triangles = triangles.ToArray();

            mesh.RecalculateBounds();
        }
    }

	//To save space so we don't have to send millions of parameters to each method
    public struct TriangleData
    {
        //The corners of this triangle in global coordinates
        public Vector3 p1;
        public Vector3 p2;
        public Vector3 p3;

        //The center of the triangle
        public Vector3 center;

        //The distance to the surface from the center of the triangle
        public float distanceToSurface;

        //The normal to the triangle
        public Vector3 normal;

        //The area of the triangle
        public float area;

        public TriangleData(Vector3 p1, Vector3 p2, Vector3 p3, Vector3 distances, bool full)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;

            //Center of the triangle
            this.center = (p1 + p2 + p3) / 3f;

            //Distance to the surface from the center of the triangle, we average it if triangle uncut
            if(full)
                this.distanceToSurface = Mathf.Abs((distances.x + distances.y + distances.z) / 3f);
            else
                this.distanceToSurface = Mathf.Abs(Water.Instance.GetWaterHeight(this.center));

            //Normal to the triangle
            this.normal = Vector3.Cross(p2 - p1, p3 - p1).normalized;

            //Area of the triangle
            float a = Vector3.Distance(p1, p2);

            float c = Vector3.Distance(p3, p1);

            this.area = (a * c * Mathf.Sin(Vector3.Angle(p2 - p1, p3 - p1) * Mathf.Deg2Rad)) / 2f;
        }
    }
}