using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;

    public Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

		GetComponent<Rigidbody>().AddForce(movement * speed);

        // IDEA 1: make it a rule that player contact gives you a certain amount of points.
        // IDEA 2: make it a rule that inter-collectible contact does something points-wise or perhaps your goal is to knock 'em out of the arena?
    }
}
