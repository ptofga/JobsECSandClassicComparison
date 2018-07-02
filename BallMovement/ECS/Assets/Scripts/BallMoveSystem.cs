using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Transforms;
using Unity.Entities;
using Unity.Jobs;
using Unity.Collections;
using Unity.Mathematics;

class BallMoveSystem : JobComponentSystem
{
    [ComputeJobOptimization]
    public struct RotationJob : IJobProcessComponentData<Rotation,Position>
    {
        public float time;
        public Vector3 vector3;
        public float random;
        public void Execute(ref Rotation rot,ref Position pos)
        {
            rot.Value = Quaternion.AngleAxis(math.sin(time) * 100, vector3);
            // Position temp = pos;
            pos.Value.y = math.sin(time);// *random;
           // pos = temp;
            //rot = damnRot;
        }
        
    }
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var job = new RotationJob() { time = Time.timeSinceLevelLoad, vector3 = Vector3.up , random= Random.value};
        var handle = job.Schedule(this, 1, inputDeps);
        return handle;
    }

}