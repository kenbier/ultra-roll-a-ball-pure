
// FIXME: learn what resides where and why.
using System;
using System.Collections;
// using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using Unity.Transforms;
using Unity.Mathematics;
using Unity.Entities;
using Unity.Jobs;

// Definition and execution of acutal job: ties components together.
// FIXME: rename to RotatorSystem?
public class RotatorSpeedSystem : JobComponentSystem
{
	// Job.
	[ComputeJobOptimization]
	struct Job : IJobProcessComponentData<Rotation, RotatorSpeed>
	{
		public float delta;

		public void Execute(ref Rotation rotation, ref RotatorSpeed speed)
		{
			rotation.Value = math.mul(math.normalize(rotation.Value), math.axisAngle(math.up(), speed.Value*delta));
		}
	}

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var job = new Job() { delta = Time.deltaTime };
        return job.Schedule(this, 64, inputDeps);
    } 
}
