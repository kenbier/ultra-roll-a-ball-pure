using System;
using UnityEngine;
using Unity.Entities;

namespace SimpleExample.ECS
{
	public class SpawnSettings : MonoBehaviour
    {
	    public GameObject Prefab;
	    public int Count;
	    public bool UseECSEntity;
	    public int WaveType;
    }
}
