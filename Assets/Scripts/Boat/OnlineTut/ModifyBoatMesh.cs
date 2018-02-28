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

            ///New stuff
            _waveCount = Water.Instance._waves.Count;
            _waveData = Water.Instance.GetWaveData();

            //This specific
            boatVerts = new NativeArray<Vector3>(mesh.vertices.Length, Allocator.Persistent);
            for(var i = 0; i < boatVerts.Length; i++)
                boatVerts[i] = mesh.vertices[i];

            boatTris = new NativeArray<int>(mesh.triangles.Length, Allocator.Persistent);
            for(var i = 0; i < boatTris.Length; i++)
                boatTris[i] = mesh.triangles[i];

            boatTransformMatrix = boatTrans.localToWorldMatrix;
        }

        void OnDisable()
        {
            boatVerts.Dispose();
            boatTris.Dispose();
        }
        
        //GerstnerWave specifics
        Vector4[] _waveData;
        int _waveCount;
        //ModifyBoatMesh specifics
        NativeArray<Vector3> boatVerts; // vert positions original mesh
        NativeArray<int> boatTris;
        Matrix4x4 boatTransformMatrix;

        public IEnumerator ModifyBoatData()
        {
            ///setup jobs
            ///Waves specfic
            NativeArray<Vector4> waveData = new NativeArray<Vector4>(_waveData.Length, Allocator.Temp);
            for(var i = 0; i < _waveData.Length; i++)
            {
                waveData[i] = _waveData[i];
            }

            NativeArray<Vector3> wavePos = new NativeArray<Vector3>(128, Allocator.Temp); // To store the waves between calcs

            ///ModifyBoatMesh specific
            //Triangledata array, finalDatapoint
            NativeArray<TriangleData> triData = new NativeArray<TriangleData>(128, Allocator.Temp);

            boatTransformMatrix = boatTrans.localToWorldMatrix;

            //Triangledatabase array, intermediate point
            NativeArray<TriangleDataBase> triDataBase = new NativeArray<TriangleDataBase>(128, Allocator.TempJob);
            int triDataBaseCount = 0;

            //VertexData for both one above and two above
            NativeArray<VertexDataSet> oneAbove = new NativeArray<VertexDataSet>(32, Allocator.TempJob);
            int oneAboveCount = 0;
            NativeArray<VertexDataSet> twoAbove = new NativeArray<VertexDataSet>(32, Allocator.TempJob);
            int twoAboveCount = 0;

            NativeArray<Vector3> globalVertChecklist = new NativeArray<Vector3>(boatVerts.Length, Allocator.Temp);

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
                OneAboveCount = oneAboveCount,
                TwoAbove = twoAbove,
                TwoAboveCount = twoAboveCount
            };
            var addTrisHandle = addTris.Schedule(heightPass1Handle);

            ///Mini job - add triagles 1 above
            var addOne = new OneAbove()
            {
                input = oneAbove,
                inputCount = oneAboveCount,
                output = triDataBase
            };
            var addOneHandle = addOne.Schedule(addTrisHandle);
            ///Mini job - add triangles 2 above
            var addTwo = new TwoAbove()
            {
                input = twoAbove,
                inputCount = twoAboveCount,
                output = triDataBase
            };
            var addTwoHandle = addTwo.Schedule(addOneHandle);

            var triDataSorting = new TriangleDataSorting()
            {
                input = triDataBase,
                output = triData
            };
            var dependancy = JobHandle.CombineDependencies(addTrisHandle, addOneHandle, addTwoHandle);
            var triDataSortingHandle = triDataSorting.Schedule(triDataBase.Length, 4, dependancy);

            while(!triDataSortingHandle.IsCompleted) yield return new WaitForEndOfFrame();

            triDataSortingHandle.Complete();
            ///JOB04 - dependant on job3/minijob1/minijob2
            //Height of all add tirangles
            // var heightPass2 = new GerstnerWavesJobs.HeightJob()
            // {
            //     waveData = waveData,
            //     waveCount = _waveCount,
            //     position = inPos,
            //     time = Time.time,
            //     outPosition = outPos
            // };

            //Schedule all jobs
            
            underWaterTriangleData.Clear();
            ///Wait for job 03
            //Grab job 03's data
            int len = addTris.triDataBaseCount + (addTris.OneAboveCount * 2) + addTris.TwoAboveCount;
            Debug.Log("Triangles to process " + len + " Datasample=" + addTris.boatTris[0]);
            NativeSlice<TriangleData> triSlice = new NativeSlice<TriangleData>(triData, 0, len);
            underWaterTriangleData.AddRange(triSlice.ToArray());
            ///Wait for job 04
            //Assign data to job 03's data

            //Do it again
            waveData.Dispose();
            wavePos.Dispose();
            triData.Dispose();
            triDataBase.Dispose();
            oneAbove.Dispose();
            twoAbove.Dispose();
            globalVertChecklist.Dispose();

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

        //Generate the underwater mesh
        // public void GenerateUnderwaterMesh()
        // {
        //     //Reset
        //     underWaterTriangleData.Clear();
        //     //Find all the distances to water once because some triangles share vertices, so reuse
        //     for (int j = 0; j < boatVertices.Length; j++)
        //     {
        //         //The coordinate should be in global position
        //         Vector3 globalPos = boatTrans.TransformPoint(boatVertices[j]);

        //         //Save the global position so we only need to calculate it once here
        //         //And if we want to debug we can convert it back to local
        //         boatVerticesGlobal[j] = globalPos;
        //         if(j%2==0)
        //         {
        //             allDistancesToWater[j] = -Water.Instance.GetWaterHeight(globalPos);
                    
        //         }
        //         else
        //         {
        //             allDistancesToWater[j] = allDistancesToWater[j-1];
        //         }
        //     }

        //     //Add the triangles that are below the water
        //     Profiler.BeginSample("AddTriangles");
        //     AddTriangles();
        //     Profiler.EndSample();
        // }

        struct AddTriangles : IJob
        {
            [ReadOnly]
            public NativeArray<Vector3> wavePositions;
            [ReadOnly]
            public NativeArray<Vector3> globalVertexPos;
            [ReadOnly]
            public NativeArray<int> boatTris;
            public NativeArray<TriangleDataBase> triDataBase;
            public int triDataBaseCount;

            //Two vert data out, one for add1 above and one for add two above
            public NativeArray<VertexDataSet> OneAbove;
            public int OneAboveCount;
            public NativeArray<VertexDataSet> TwoAbove;
            public int TwoAboveCount;
            public float skipped;

            public void Execute() // this has to process 3 verts at a time to make a tri calculation
            {
                skipped += 1;
                for(var i = 0; i < boatTris.Length; i += 3)
                {
                    VertexData[] vertData = new VertexData[3];
                    TriangleDataBase triangle = new TriangleDataBase();
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
                            triDataBase[triDataBaseCount] = triangle;
                            triDataBaseCount++;
                        }
                        break;
                    case 1:
                        {
                            Array.Sort(vertData, delegate(VertexData v1, VertexData v2){return v2.distance.CompareTo(v1.distance);});
                            VertexDataSet vs = new VertexDataSet();
                            vs.v1 = vertData[0];
                            vs.v2 = vertData[1];
                            vs.v3 = vertData[2];
                            OneAbove[OneAboveCount] = vs;
                            OneAboveCount++;
                        }
                        break;
                    case 2:
                        {
                            Array.Sort(vertData, delegate(VertexData v1, VertexData v2){return v2.distance.CompareTo(v1.distance);});
                            VertexDataSet vs = new VertexDataSet();
                            vs.v1 = vertData[0];
                            vs.v2 = vertData[1];
                            vs.v3 = vertData[2];
                            TwoAbove[TwoAboveCount] = vs;
                            TwoAboveCount++;
                        }
                        break;
                    }
                }
            }
        }

        //Add all the triangles that's part of the underwater mesh
        // private void AddTriangles()
        // {
        //     //Loop through all the triangles (3 vertices at a time = 1 triangle)
        //     int i = 0;
        //     while(i < boatTriangles.Length)
        //     {
        //         int countAboveWater = 3;
        //         //Loop through the 3 vertices
        //         for (int x = 0; x < 3; x++)
        //         {
        //             //Save the data we need
        //             vertexData[x].distance = allDistancesToWater[boatTriangles[i]];

        //             if(vertexData[x].distance < 0f)
        //                 countAboveWater--;

        //             vertexData[x].index = x;

        //             vertexData[x].globalVertexPos = boatVerticesGlobal[boatTriangles[i]];
        //             i++;
        //         }

        //         switch(countAboveWater)
        //         {
        //             case 3:
        //             break;
        //             case 0:
        //             {
        //                 Vector3 p1 = vertexData[0].globalVertexPos;
        //                 Vector3 p2 = vertexData[1].globalVertexPos;
        //                 Vector3 p3 = vertexData[2].globalVertexPos;
        //                 Vector3 d = new Vector3(vertexData[0].distance, vertexData[1].distance, vertexData[2].distance);
        //                 //Save the triangle
        //                 underWaterTriangleData.Add(new TriangleData(p1, p2, p3, d, true));
        //             }
        //             break;
        //             case 1:
        //             {
        //                 Array.Sort(vertexData, delegate(VertexData v1, VertexData v2){return v2.distance.CompareTo(v1.distance);});
        //                 Profiler.BeginSample("AddTrianglesOneAboveWater");
        //                 AddTrianglesOneAboveWater();
        //                 Profiler.EndSample();
        //             }
        //             break;
        //             case 2:
        //             {
        //                 Array.Sort(vertexData, delegate(VertexData v1, VertexData v2){return v2.distance.CompareTo(v1.distance);});
        //                 Profiler.BeginSample("AddTrianglesTwoAboveWater");
        //                 AddTrianglesTwoAboveWater();
        //                 Profiler.EndSample();
        //             }
        //             break;
        //         }
        //     }
        // }

        struct OneAbove : IJob
        {
            [ReadOnly]
            public NativeArray<VertexDataSet> input;
            [ReadOnly]
            public int inputCount;

            public NativeArray<TriangleDataBase> output;

            public void Execute()
            {
                for(var i = 0; i < input.Length; i++)
                {
                VertexDataSet vds = input[i];
                //H is always at position 0
                Vector3 H = vds.v1.globalVertexPos;

                //Left of H is M
                //Right of H is L

                //Find the index of M
                int M_index = vds.v1.index - 1;
                if (M_index < 0)
                {
                    M_index = 2;
                }

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
                tri1.p2 = I_L;
                tri1.distance = Vector3.zero;
                tri1.full = 0;
                output[inputCount + i*2] = tri1;
                TriangleDataBase tri2 = new TriangleDataBase();
                tri2.p1 = M;
                tri2.p2 = I_L;
                tri2.p2 = L;
                tri2.distance = Vector3.zero;
                tri2.full = 0;
                output[inputCount + i*2 + 1] = tri2;
                }
            }
        }

        struct TwoAbove : IJob
        {
            [ReadOnly]
            public NativeArray<VertexDataSet> input;
            [ReadOnly]
            public int inputCount;
            public int oneAboveCount;

            public NativeArray<TriangleDataBase> output;

            public void Execute()
            {
                for(var i = 0; i < input.Length; i++)
                {
                VertexDataSet vds = input[i];
                //H and M are above the water
                //H is after the vertice that's below water, which is L
                //So we know which one is L because it is last in the sorted list
                Vector3 L = vds.v3.globalVertexPos;

                //Find the index of H
                int H_index = vds.v3.index + 1;
                if (H_index > 2)
                {
                    H_index = 0;
                }


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

                //Save the data, such as normal, area, etc      
                //1 triangles below the water
                TriangleDataBase tri1 = new TriangleDataBase();
                tri1.p1 = L;
                tri1.p2 = J_H;
                tri1.p2 = J_M;
                tri1.distance = Vector3.zero;
                tri1.full = 0;
                output[inputCount + oneAboveCount * 2 + i] = tri1;
            }
            }
        }

        struct TriangleDataSorting : IJobParallelFor
        {
            [ReadOnly]
            public NativeArray<TriangleDataBase> input;
            public NativeArray<TriangleData> output;

            public void Execute(int i)
            {
                TriangleData triangleData = new TriangleData();
                triangleData.p1 = input[i].p1;
                triangleData.p2 = input[i].p2;
                triangleData.p3 = input[i].p3;

                //Center of the triangle
                triangleData.center = (input[i].p1 + input[i].p2 + input[i].p3) * 0.3333f;

                //Distance to the surface from the center of the triangle, we average it if triangle uncut
                if(input[i].full == 1)
                    triangleData.distanceToSurface = Math.Abs((input[i].distance.x + input[i].distance.y + input[i].distance.z) * 0.3333f);
                else
                    triangleData.distanceToSurface = 1234;

                //Normal to the triangle
                triangleData.normal = Vector3.Cross(input[i].p2 - input[i].p1, input[i].p3 - input[i].p1).normalized;

                //Area of the triangle
                float a = Vector3.Distance(input[i].p1, input[i].p2);

                float c = Vector3.Distance(input[i].p3, input[i].p1);

                triangleData.area = (a * c * Mathf.Sin(Vector3.Angle(input[i].p2 - input[i].p1, input[i].p3 - input[i].p1) * Mathf.Deg2Rad)) * 0.5f;
                triangleData.underWater = 1;
                output[i] = triangleData;
            }
        }

        //Build the new triangles where one of the old vertices is above the water
        // private void AddTrianglesOneAboveWater()
        // {
        //     //H is always at position 0
        //     Vector3 H = vertexData[0].globalVertexPos;

        //     //Left of H is M
        //     //Right of H is L

        //     //Find the index of M
        //     int M_index = vertexData[0].index - 1;
        //     if (M_index < 0)
        //     {
        //         M_index = 2;
        //     }

        //     //We also need the heights to water
        //     float h_H = vertexData[0].distance;
        //     float h_M = 0f;
        //     float h_L = 0f;

        //     Vector3 M = Vector3.zero;
        //     Vector3 L = Vector3.zero;

        //     //This means M is at position 1 in the List
        //     if (vertexData[1].index == M_index)
        //     {
        //         M = vertexData[1].globalVertexPos;
        //         L = vertexData[2].globalVertexPos;

        //         h_M = vertexData[1].distance;
        //         h_L = vertexData[2].distance;
        //     }
        //     else
        //     {
        //         M = vertexData[2].globalVertexPos;
        //         L = vertexData[1].globalVertexPos;

        //         h_M = vertexData[2].distance;
        //         h_L = vertexData[1].distance;
        //     }

			
        //     //Now we can calculate where we should cut the triangle to form 2 new triangles
        //     //because the resulting area will always form a square

        //     //Point I_M
        //     Vector3 MH = H - M;

        //     float t_M = -h_M / (h_H - h_M);

        //     Vector3 MI_M = t_M * MH;

        //     Vector3 I_M = MI_M + M;


        //     //Point I_L
        //     Vector3 LH = H - L;

        //     float t_L = -h_L / (h_H - h_L);

        //     Vector3 LI_L = t_L * LH;

        //     Vector3 I_L = LI_L + L;

        //     //Save the data, such as normal, area, etc      
        //     //2 triangles below the water  
        //     underWaterTriangleData.Add(new TriangleData(M, I_M, I_L, Vector3.zero, false));
        //     underWaterTriangleData.Add(new TriangleData(M, I_L, L, Vector3.zero, false));
        // }

        // //Build the new triangles where two of the old vertices are above the water
        // private void AddTrianglesTwoAboveWater()
        // {
        //     //H and M are above the water
        //     //H is after the vertice that's below water, which is L
        //     //So we know which one is L because it is last in the sorted list
        //     Vector3 L = vertexData[2].globalVertexPos;

        //     //Find the index of H
        //     int H_index = vertexData[2].index + 1;
        //     if (H_index > 2)
        //     {
        //         H_index = 0;
        //     }


        //     //We also need the heights to water
        //     float h_L = vertexData[2].distance;
        //     float h_H = 0f;
        //     float h_M = 0f;

        //     Vector3 H = Vector3.zero;
        //     Vector3 M = Vector3.zero;

        //     //This means that H is at position 1 in the list
        //     if (vertexData[1].index == H_index)
        //     {
        //         H = vertexData[1].globalVertexPos;
        //         M = vertexData[0].globalVertexPos;

        //         h_H = vertexData[1].distance;
        //         h_M = vertexData[0].distance;
        //     }
        //     else
        //     {
        //         H = vertexData[0].globalVertexPos;
        //         M = vertexData[1].globalVertexPos;

        //         h_H = vertexData[0].distance;
        //         h_M = vertexData[1].distance;
        //     }


        //     //Now we can find where to cut the triangle

        //     //Point J_M
        //     Vector3 LM = M - L;

        //     float t_M = -h_L / (h_M - h_L);

        //     Vector3 LJ_M = t_M * LM;

        //     Vector3 J_M = LJ_M + L;


        //     //Point J_H
        //     Vector3 LH = H - L;

        //     float t_H = -h_L / (h_H - h_L);

        //     Vector3 LJ_H = t_H * LH;

        //     Vector3 J_H = LJ_H + L;


        //     //Save the data, such as normal, area, etc
        //     //1 triangle below the water
        //     underWaterTriangleData.Add(new TriangleData(L, J_H, J_M, Vector3.zero, false));
        // }

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