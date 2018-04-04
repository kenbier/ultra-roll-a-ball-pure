using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour {

	public GameObject player;
	private Rigidbody rigidbody;

	private Vector3 offset;
	private float yAng;

	void Start () 
	{
		rigidbody = player.GetComponent<Rigidbody>();
		offset = transform.position - player.transform.position;
		yAng = rigidbody.rotation.y;
	}
	
	void Update () 
	{
		// FIXME: draai rustig mee achter de bal aan (Y angle!)
		var follow = offset + player.transform.position;
		transform.position = follow;
		transform.Rotate(0.0f, yAng, 0.0f);
	}
}
