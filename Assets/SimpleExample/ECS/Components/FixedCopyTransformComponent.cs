using System;
using UnityEngine;
using Unity.Entities;

namespace SimpleExample.ECS
{
	// the Unity version "CopyTransformToGameObjectSystem" would throw an error
	public struct FixedCopyTransform : IComponentData {}
    
	public class FixedCopyTransformComponent : ComponentDataWrapper<FixedCopyTransform>{}
}
