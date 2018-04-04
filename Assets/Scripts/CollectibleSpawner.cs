using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using Unity.Transforms;

public class CollectibleSpawner : MonoBehaviour {

	public GameObject collectible;

	void Start () 
	{
		// FIXME: parametrize / move to ECS.
		const int numCircles = 16;
		const int cubesStep = 256;
		const float radiusStep = 3.5f;

		float radius = 4.0f;
		const float scale = 0.76f;

		int totalCubes = 0;
		for (int iCircle = 1; iCircle <= numCircles; ++iCircle) 
		{
			radius += radiusStep;

			int numCubes = cubesStep*iCircle;
			totalCubes += numCubes;

			float angStep = (2.0f*Mathf.PI)/numCubes;
			float angle = 0.0f;
			for (int iCube = 0; iCube < numCubes; ++iCube)
			{
				GameObject instance = Instantiate(collectible, new Vector3(Mathf.Cos(angle)*radius, 1.0f, Mathf.Sin(angle)*radius), Quaternion.identity);

				instance.transform.localScale = new Vector3(scale, scale, scale);

				// Hack: add this boy here to make any ECS transform visible (the prefab is read-only).
//				instance.AddComponent<Unity.Transforms.CopyTransformToGameObjectComponent>();

				// Hitch to parent.
//				instance.transform.parent = this.transform;

				angle += angStep;
			}
		}

		Debug.Log("Number of cubes total: " + totalCubes);
	}
}
