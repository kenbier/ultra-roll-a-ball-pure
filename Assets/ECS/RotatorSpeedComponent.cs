
// FIXME: learn what resides where and why.
using System;
using System.Collections;
// using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using Unity.Transforms;
using Unity.Entities;
using Unity.Jobs;

// Speed component.
[Serializable]
public struct RotatorSpeed : IComponentData
{
	public float Value;
}

public class RotatorSpeedComponent : ComponentDataWrapper<RotatorSpeed> {} 
