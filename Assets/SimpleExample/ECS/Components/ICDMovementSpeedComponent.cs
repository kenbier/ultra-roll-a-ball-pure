using System;
using UnityEngine;
using Unity.Entities;

namespace SimpleExample.ECS
{
	[Serializable]
	public struct ICDMovementSpeed : IComponentData   
	{
		public float Value;
	}
    
	public class ICDMovementSpeedComponent : ComponentDataWrapper<ICDMovementSpeed>{}
}