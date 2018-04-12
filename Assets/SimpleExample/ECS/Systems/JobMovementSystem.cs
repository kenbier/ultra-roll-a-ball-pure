using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Jobs;
using Unity.Collections;
using Unity.Mathematics;
using Unity.Transforms;

namespace SimpleExample.ECS
{	
	public class JobMovementSystem : JobComponentSystem
	{
		[ComputeJobOptimization]
		struct MovementJob : IJobProcessComponentData<Position, ICDMovementSpeed, ICDMovementWaveType>
		{
			public float time;

			public void Execute(ref Position position, [ReadOnly]ref ICDMovementSpeed speed, [ReadOnly] ref ICDMovementWaveType type)
			{
				switch (type.WaveType)
				{
					case 1:
						position.Value.y = math.sin(time * speed.Value + math.radians(position.Value.z)) * 4f;
						break;
					case 2:
						position.Value.y = math.cos(time * speed.Value + math.radians(position.Value.z)) * 4f;
						break;
					case 3:
						position.Value.y = math.tan(time * speed.Value + math.radians(position.Value.z)) * 4f;
						break;
					default:
						position.Value.y = math.sin(time * speed.Value + math.radians(position.Value.z)) * 4f;
						break;
				}
			}
		}

		protected override JobHandle OnUpdate(JobHandle inputDeps)
		{
			var job = new MovementJob() { time = Time.timeSinceLevelLoad };
			var handle = job.Schedule(this, 64, inputDeps); 
			return handle;
		} 
	}
}
