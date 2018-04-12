using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Jobs;
using Unity.Collections;

namespace SimpleExample.ECS
{
	public class ClassicMovementSystem : ComponentSystem 
	{
		struct Group
		{
			public ComponentArray<Transform> transformArray;
			public ComponentArray<MonoMovementSpeed> movementSpeedArray;
			public int Length;
		}
		
		[Inject] private Group m_Group; 
		
		protected override void OnUpdate()
		{
			float time = Time.timeSinceLevelLoad;
			
			for (int i = 0; i < m_Group.Length; i++)
			{
				var position = m_Group.transformArray[i].position;
				var speed = m_Group.movementSpeedArray[i].Value;
				position.y = Mathf.Sin(time * speed + position.z * Mathf.Deg2Rad) * 4f;
				m_Group.transformArray[i].position = position;
			}
		}
	}	
}
