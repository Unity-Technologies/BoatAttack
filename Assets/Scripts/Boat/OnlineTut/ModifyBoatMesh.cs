using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using WaterSystem;
using UnityEngine.Profiling;
using Unity.Jobs;
using Unity.Collections;

namespace BoatTutorial
{
    //Generates the mesh that's below the water
    public class ModifyBoatMesh
    {
        //The boat transform needed to get the global position of a vertice
        private Transform boatTrans;
        //The triangles belonging to the part of the boat that's under water
        public TriangleData[] underWaterTriangleData;
        //GerstnerWave specifics
        Vector4[] _waveData;
        int _waveCount;
        bool _processing;
        //ModifyBoatMesh specifics
        Matrix4x4 boatTransformMatrix;
        //Native Arrays
        NativeArray<Vector3>    boatVerts; // vert positions original mesh
        NativeArray<int>        boatTris; // list of vert indices making up the tris
        NativeArray<Water.Wave>    waveData; // Wave data from teh water system
        NativeArray<Vector3>    wavePos; // Array to stor post wave position calculation
        NativeArray<Vector3>    globalVertChecklist; // array for positions to height check
        NativeArray<TriangleData> triData; // Final output of the job run, data used by boat physics
        NativeArray<TriangleDataBase> triDataBase; // Intermediate output for the cut triangles
        NativeArray<int>        triDataBaseCount; // List of counts of triangles to calculate
        NativeArray<VertexDataSet> oneAbove;
        NativeArray<VertexDataSet> twoAbove;
        NativeArray<Vector3> finalHightPosCheck;
        JobHandle triDataFinalHandle; // final handle for job flow, needed for early cleanup/termination

        public ModifyBoatMesh(GameObject boatObj, Mesh mesh)
        {
            //Wave data
            _waveCount = Water.Instance._waves.Count;
            waveData = new NativeArray<Water.Wave>(_waveCount, Allocator.Persistent);
            for (var i = 0; i < waveData.Length; i++)
            {
                waveData[i] = Water.Instance._waves[i];
            }

            //Boat specific
            boatTrans = boatObj.transform;
            boatVerts = new NativeArray<Vector3>(mesh.vertices.Length, Allocator.Persistent);
            for(var i = 0; i < boatVerts.Length; i++)
                boatVerts[i] = mesh.vertices[i];

            boatTris = new NativeArray<int>(mesh.triangles.Length, Allocator.Persistent);
            for(var i = 0; i < boatTris.Length; i++)
                boatTris[i] = mesh.triangles[i];

            boatTransformMatrix = boatTrans.localToWorldMatrix;

            //Jobs specific
            wavePos = new NativeArray<Vector3>(128, Allocator.Persistent); // To store the waves between calcs
            globalVertChecklist = new NativeArray<Vector3>(boatVerts.Length, Allocator.Persistent); // array to check initial verts(size )
            triData = new NativeArray<TriangleData>(128, Allocator.Persistent);
            triDataBase = new NativeArray<TriangleDataBase>(128, Allocator.Persistent);
            triDataBaseCount = new NativeArray<int>(3, Allocator.Persistent); // 0=base, 1=one above, 2=two above
            //VertexData for both one above and two above
            oneAbove = new NativeArray<VertexDataSet>(32, Allocator.Persistent);
            twoAbove = new NativeArray<VertexDataSet>(32, Allocator.Persistent);
            finalHightPosCheck = new NativeArray<Vector3>(128, Allocator.Persistent);
        }
        public void BufferCleanup() 
        {
            triDataFinalHandle.Complete();
            boatVerts.Dispose();
            boatTris.Dispose();
            waveData.Dispose();
            globalVertChecklist.Dispose();
            wavePos.Dispose();
            triData.Dispose();
            triDataBase.Dispose();
            triDataBaseCount.Dispose();
            oneAbove.Dispose();
            twoAbove.Dispose();
            finalHightPosCheck.Dispose();
        }

        public IEnumerator ModifyBoatData()
        {
            while(_processing) yield return null;
            _processing = true;

            for (var i = 0; i < triDataBaseCount.Length; i++) triDataBaseCount[i] = 0;
            ///setup jobs
            boatTransformMatrix = boatTrans.localToWorldMatrix;
            ///JOB01
            //globalPos of verts
            var localToWorld = new GlobalVertConversion(){inPos = boatVerts, outPos = globalVertChecklist, matrix = boatTransformMatrix};
            //>>pass globalVertChecklist data to job2 for distance
            var localToWorldHandle = localToWorld.Schedule(boatVerts.Length, 32);

            // ///JOB02 - dependant on job1
            // //Height of all global verts
            // //>>pass data to job3
            var heightPass1 = new GerstnerWavesJobs.HeightJob()
            {
                waveData = waveData,
                waveCount = _waveCount,
                position = globalVertChecklist,
                time = Time.time,
                outPosition = wavePos
            };
            //>>pass wavePos to job2
            var heightPass1Handle = heightPass1.Schedule(globalVertChecklist.Length, 4, localToWorldHandle);

            ///JOB03 - dependant on job2
            //Add triangles
            //>>pass data to job4/minijob1/minijob2
            var addTris = new AddTriangles()
            {
                wavePositions = wavePos,
                globalVertexPos = globalVertChecklist,
                boatTris = boatTris,
                triDataBase = triDataBase,
                triDataBaseCount = triDataBaseCount,
                OneAbove = oneAbove,
                TwoAbove = twoAbove
            };
            var addTrisHandle = addTris.Schedule(heightPass1Handle);

            ///Mini job - add triagles 1 above
            var addOne = new OneAbove()
            {
                input = oneAbove,
                inputCount = triDataBaseCount,
                output = triDataBase
            };
            var addOneHandle = addOne.Schedule(addTrisHandle);
            ///Mini job - add triangles 2 above
            var addTwo = new TwoAbove()
            {
                input = twoAbove,
                inputCount = triDataBaseCount,
                output = triDataBase
            };
            var addTwoHandle = addTwo.Schedule(addOneHandle);

            var triDataSorting = new TriangleDataSorting()
            {
                input = triDataBase,
                count = triDataBaseCount,
                output = triData,
                outputPos = finalHightPosCheck
            };
            var dependancy = JobHandle.CombineDependencies(addTrisHandle, addOneHandle, addTwoHandle);
            var triDataSortingHandle = triDataSorting.Schedule(triDataBase.Length, 4, dependancy);

            //Height of all add tirangles
            
            var heightPass2 = new GerstnerWavesJobs.HeightJob()
            {
                waveData = waveData,
                waveCount = _waveCount,
                position = finalHightPosCheck,
                time = Time.time,
                outPosition = wavePos
            };
            var heightPass2Handle = heightPass2.Schedule(triData.Length, 4, triDataSortingHandle);

            //Final height assignment
            var triDataFinal = new TriangleFinalize()
            {
                inputPos = wavePos,
                data = triData
            };
            triDataFinalHandle = triDataFinal.Schedule(triData.Length, 16, heightPass2Handle);

            while(!triDataFinalHandle.IsCompleted) yield return new WaitForFixedUpdate();

            triDataFinalHandle.Complete();
            ///JOB04 - dependant on job3/minijob1/minijob2
            ///Wait for job 03
            //Grab job 03's data
            int len = addTris.triDataBaseCount[0] + (addTris.triDataBaseCount[1] * 2) + addTris.triDataBaseCount[2];
            //Debug.Log("Triangles to process " + len + " Datasample=" + addTris.triDataBaseCount[0] + "," + addTris.triDataBaseCount[1] + "," + addTris.triDataBaseCount[2]);
            NativeSlice<TriangleData> triSlice = new NativeSlice<TriangleData>(triData, 0, len);
            underWaterTriangleData = triSlice.ToArray();
            _processing = false;
            //Do it again
        }

        //Job Get global positions to check
        struct GlobalVertConversion : IJobParallelFor
        {
            [ReadOnly]
            public NativeArray<Vector3> inPos;
            public NativeArray<Vector3> outPos;
            [ReadOnly]
            public Matrix4x4 matrix;

            public void Execute(int i)
            {
                outPos[i] = matrix.MultiplyPoint(inPos[i]);
            }
        }

        struct AddTriangles : IJob
        {
            [ReadOnly]
            public NativeArray<Vector3> wavePositions;
            [ReadOnly]
            public NativeArray<Vector3> globalVertexPos;
            [ReadOnly]
            public NativeArray<int> boatTris;
            public NativeArray<TriangleDataBase> triDataBase;
            public NativeArray<int> triDataBaseCount;

            //Two vert data out, one for add1 above and one for add two above
            public NativeArray<VertexDataSet> OneAbove;
            public NativeArray<VertexDataSet> TwoAbove;

            public void Execute() // this has to process 3 verts at a time to make a tri calculation
            {
                VertexData[] vertData = new VertexData[3];
                var triangle = new TriangleDataBase();
                var vs = new VertexDataSet();

                for(var i = 0; i < boatTris.Length; i += 3)
                {
                    int countAboveWater = 3;
                    int id = i;

                    for (int x = 0; x < 3; x++)
                    {
                        //Save the data we need
                        vertData[x].distance = globalVertexPos[boatTris[id]].y - wavePositions[boatTris[id]].y;

                        if(vertData[x].distance < 0f)
                            countAboveWater--;

                        vertData[x].index = x;

                        vertData[x].globalVertexPos = globalVertexPos[boatTris[id]];
                        id++;
                    }

                    switch(countAboveWater)
                    {
                    case 3:
                        break;
                    case 0:
                        {
                            Vector3 p1 = vertData[0].globalVertexPos;
                            Vector3 p2 = vertData[1].globalVertexPos;
                            Vector3 p3 = vertData[2].globalVertexPos;
                            Vector3 d = new Vector3(vertData[0].distance, vertData[1].distance, vertData[2].distance);
                            //Save the triangle
                            triangle.p1 = p1;
                            triangle.p2 = p2;
                            triangle.p3 = p3;
                            triangle.distance = d;
                            triangle.full = 1;
                            triDataBase[triDataBaseCount[0]] = triangle;
                            triDataBaseCount[0]++;
                        }
                        break;
                    case 1:
                        {
                            Array.Sort(vertData, delegate(VertexData v1, VertexData v2){return v2.distance.CompareTo(v1.distance);});
                            vs.v1 = vertData[0];
                            vs.v2 = vertData[1];
                            vs.v3 = vertData[2];
                            OneAbove[triDataBaseCount[1]] = vs;
                            triDataBaseCount[1]++;
                        }
                        break;
                    case 2:
                        {
                            Array.Sort(vertData, delegate(VertexData v1, VertexData v2){return v2.distance.CompareTo(v1.distance);});
                            vs.v1 = vertData[0];
                            vs.v2 = vertData[1];
                            vs.v3 = vertData[2];
                            TwoAbove[triDataBaseCount[2]] = vs;
                            triDataBaseCount[2]++;
                        }
                        break;
                    }
                }
            }
        }

        struct OneAbove : IJob
        {
            [ReadOnly]
            public NativeArray<VertexDataSet> input;
            [ReadOnly]
            public NativeArray<int> inputCount;
            public NativeArray<TriangleDataBase> output;

            public void Execute()
            {
                for(var i = 0; i < inputCount[1]; i++)
                {
                    VertexDataSet vds = input[i];
                    //H is always at position 0
                    Vector3 H = vds.v1.globalVertexPos;
                    //Left of H is M
                    //Right of H is L
                    //Find the index of M
                    int M_index = vds.v1.index - 1;
                    if (M_index < 0)
                        M_index = 2;
                    //We also need the heights to water
                    float h_H = vds.v1.distance;
                    float h_M = 0f;
                    float h_L = 0f;
                    Vector3 M = Vector3.zero;
                    Vector3 L = Vector3.zero;
                    //This means M is at position 1 in the List
                    if (vds.v2.index == M_index)
                    {
                        M = vds.v2.globalVertexPos;
                        L = vds.v3.globalVertexPos;
                        h_M = vds.v2.distance;
                        h_L = vds.v3.distance;
                    }
                    else
                    {
                        M = vds.v3.globalVertexPos;
                        L = vds.v2.globalVertexPos;
                        h_M = vds.v3.distance;
                        h_L = vds.v2.distance;
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
                    TriangleDataBase tri1 = new TriangleDataBase();
                    tri1.p1 = M;
                    tri1.p2 = I_M;
                    tri1.p3 = I_L;
                    tri1.distance = Vector3.zero;
                    tri1.full = 0;
                    output[inputCount[0] + i*2] = tri1;
                    TriangleDataBase tri2 = new TriangleDataBase();
                    tri2.p1 = M;
                    tri2.p2 = I_L;
                    tri2.p3 = L;
                    tri2.distance = Vector3.zero;
                    tri2.full = 0;
                    output[inputCount[0] + i*2 + 1] = tri2;
                }
            }
        }

        struct TwoAbove : IJob
        {
            [ReadOnly]
            public NativeArray<VertexDataSet> input;
            [ReadOnly]
            public NativeArray<int> inputCount;

            public NativeArray<TriangleDataBase> output;

            public void Execute()
            {
                for(var i = 0; i < inputCount[2]; i++)
                {
                    VertexDataSet vds = input[i];
                    //H and M are above the water
                    //H is after the vertice that's below water, which is L
                    //So we know which one is L because it is last in the sorted list
                    Vector3 L = vds.v3.globalVertexPos;
                    //Find the index of H
                    int H_index = vds.v3.index + 1;
                    if (H_index > 2)
                        H_index = 0;
                    //We also need the heights to water
                    float h_L = vds.v3.distance;
                    float h_H = 0f;
                    float h_M = 0f;
                    Vector3 H = Vector3.zero;
                    Vector3 M = Vector3.zero;
                    //This means that H is at position 1 in the list
                    if (vds.v2.index == H_index)
                    {
                        H = vds.v2.globalVertexPos;
                        M = vds.v1.globalVertexPos;

                        h_H = vds.v2.distance;
                        h_M = vds.v1.distance;
                    }
                    else
                    {
                        H = vds.v1.globalVertexPos;
                        M = vds.v2.globalVertexPos;

                        h_H = vds.v1.distance;
                        h_M = vds.v2.distance;
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
                    //Save the data, to be calculated later     
                    //1 triangles below the water
                    TriangleDataBase tri1 = new TriangleDataBase();
                    tri1.p1 = L;
                    tri1.p2 = J_H;
                    tri1.p3 = J_M;
                    tri1.distance = Vector3.zero; // not original points so need to recalc distance later
                    tri1.full = 0; // is not made up of original points
                    int offset = inputCount[0] + inputCount[1] * 2; // Offset index, after teh base count and the one above count * 2 since one above adds two tris
                    output[i + offset] = tri1;
                }
            }
        }

        struct TriangleDataSorting : IJobParallelFor
        {
            [ReadOnly]
            public NativeArray<TriangleDataBase> input;
            [ReadOnly]
            public NativeArray<int> count;
            public NativeArray<TriangleData> output;
            public NativeArray<Vector3> outputPos;

            public void Execute(int i)
            {
                int num = count[0] + count[1] * 2 + count[2];
                if (i < num)
                {
                    TriangleData triangleData = new TriangleData();
                    triangleData.p1 = input[i].p1;
                    triangleData.p2 = input[i].p2;
                    triangleData.p3 = input[i].p3;

                    //Center of the triangle
                    triangleData.center = (input[i].p1 + input[i].p2 + input[i].p3) * 0.3333f;

                    triangleData.distanceToSurface = 0f;

                    //Normal to the triangle
                    triangleData.normal = Vector3.Cross(input[i].p2 - input[i].p1, input[i].p3 - input[i].p1).normalized;

                    //Area of the triangle
                    float a = Vector3.Distance(input[i].p1, input[i].p2);

                    float c = Vector3.Distance(input[i].p3, input[i].p1);

                    triangleData.area = (a * c * Mathf.Sin(Vector3.Angle(input[i].p2 - input[i].p1, input[i].p3 - input[i].p1) * Mathf.Deg2Rad)) * 0.5f;
                    triangleData.underWater = 1;
                    output[i] = triangleData;
                    outputPos[i] = triangleData.center;
                }
            }
        }

        struct TriangleFinalize : IJobParallelFor
        {
            [ReadOnly]
            public NativeArray<Vector3> inputPos;
            public NativeArray<TriangleData> data;

            public void Execute(int i)
            {
                TriangleData td = data[i];
                td.distanceToSurface = Math.Abs(td.center.y - inputPos[i].y);
                data[i] = td;
            }
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
        //Help class to store triangle data so we can sort the distances
        private struct VertexData
        {
            //The distance to water from this vertex
            public float distance;
            //An index so we can form clockwise triangles
            public int index;
            //The global Vector3 position of the vertex
            public Vector3 globalVertexPos;
        }

        private struct VertexDataSet
        {
            //set of vertdata to make tri
            public VertexData v1;
            public VertexData v2;
            public VertexData v3;
        }
//Intermediate TriangleDataBase
        public struct TriangleDataBase
        {
            public Vector3 p1;
            public Vector3 p2;
            public Vector3 p3;
            public Vector3 distance;
            public int full;
        }

        	//To save space so we don't have to send millions of parameters to each method
        [System.Serializable]
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
            public int underWater;
        }
    }
}