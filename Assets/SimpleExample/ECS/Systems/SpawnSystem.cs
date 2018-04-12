using System;
using System.Collections;
using System.Collections.Generic;
using System.Management.Instrumentation;
using UnityEngine;
using Unity.Entities;
using Unity.Jobs;
using Unity.Collections;
using Unity.Transforms;
using Unity.Rendering;

namespace SimpleExample.ECS
{
	public class SpawnSystem : ComponentSystem 
	{
		struct Group
		{
			public ComponentArray<Transform> TransformArray;
			public ComponentArray<SpawnSettings> SpawnSettingsArray;
			public int Length;
		}
		
		[Inject] private Group m_Group; 
		
		bool IsFinished = false;
		
		protected override void OnUpdate()
		{
			if (!IsFinished)
			{
				EntityArchetype cubeD = EntityManager.CreateArchetype(typeof(ICDMovementSpeed), typeof(Position), typeof(TransformMatrix),
					typeof(ICDMovementWaveType));
				
				for (int i = 0; i < m_Group.Length; i++)
				{
					var prefab = m_Group.SpawnSettingsArray[i].Prefab;
					var count = m_Group.SpawnSettingsArray[i].Count;
					var useEntity = m_Group.SpawnSettingsArray[i].UseECSEntity;
					var waveType = m_Group.SpawnSettingsArray[i].WaveType;
					var parent = m_Group.TransformArray[i].transform;
					var position = parent.position;
					
					MeshInstanceRenderer meshInstanceRenderer = new MeshInstanceRenderer();
					if (useEntity)
					{
						var proto = GameObject.Instantiate(prefab);
						meshInstanceRenderer = proto.GetComponent<MeshInstanceRendererComponent>().Value;
						GameObject.Destroy(proto);
					}
					
					for (int j = 0; j < count; j++)
					{
						position.z = j;
						if (useEntity)
						{
							var e = EntityManager.CreateEntity(cubeD);
							var speed = new ICDMovementSpeed{Value = 2};
							var type = new ICDMovementWaveType{WaveType= waveType};
							var posData = new Position();
							posData.Value.xyz = position;
							EntityManager.SetComponentData<Position>(e, posData);
							EntityManager.SetComponentData<ICDMovementSpeed>(e, speed);
							EntityManager.SetComponentData<ICDMovementWaveType>(e, type);
							EntityManager.AddSharedComponentData(e, meshInstanceRenderer);
						}
						else
						{
							var go = GameObject.Instantiate(prefab, parent);
							go.name = parent.name + "_" + j;
							go.transform.position = position;
						}
					}
				}	
			}
			
			IsFinished = true;
		}
	}

	
}
