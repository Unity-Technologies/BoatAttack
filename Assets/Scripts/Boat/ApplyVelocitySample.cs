using UnityEngine;
using Unity.Collections;
using Unity.Jobs;
 
class ApplyVelocitySample : MonoBehaviour
{
    struct VelocityJob : IJob
    {
        // Jobs declare all data that will be accessed in the job
        // By declaring it as read only, multiple jobs are allowed to access the data in parallel
        [ReadOnly]
        public NativeArray<Vector3> velocity;
 
        // By default containers are assumed to be read & write
        public NativeArray<Vector3> position;
 
        // Delta time must be copied to the job since jobs generally don't have concept of a frame.
        // The main thread waits for the job on the same frame or the next frame, but the job should
        // perform work in a deterministic and independent way when running on worker threads.
        public float deltaTime;
 
        // The code actually running on the job
        public void Execute()
        {
            // Move the positions based on delta time and velocity
            for (var i = 0; i < position.Length; i++)
                position[i] = position[i] + velocity[i] * deltaTime;
        }
    }
 
    public void Update()
    {
        var position = new NativeArray<Vector3>(500, Allocator.Persistent);
 
        var velocity = new NativeArray<Vector3>(500, Allocator.Persistent);
        for (var i = 0; i < velocity.Length; i++)
            velocity[i] = new Vector3(0, 10, 0);
 
 
        // Initialize the job data
        var job = new VelocityJob()
        {
            deltaTime = Time.deltaTime,
            position = position,
            velocity = velocity
        };
 
        // Schedule the job, returns the JobHandle which can be waited upon later on
        JobHandle jobHandle = job.Schedule();
 
        // Ensure the job has completed
        // It is not recommended to Complete a job immediately,
        // since that gives you no actual parallelism.
        // You optimally want to schedule a job early in a frame and then wait for it later in the frame.
        jobHandle.Complete();
 
        Debug.Log(job.position[0]);
 
        // Native arrays must be disposed manually
        position.Dispose();
        velocity.Dispose();
    }
}
 