
// FIXME: learn what resides where and why.
using System;
// using System.Collections;
// using System.Collections.Generic;
// using System.ComponentModel;
using UnityEngine;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;

[Serializable]
public struct SpawnCollectibles : ISharedComponentData
{
	public GameObject collectible;
	public int count;
}

public class SpawnCollectiblesComponent : SharedComponentDataWrapper<SpawnCollectibles> {}
