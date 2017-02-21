using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {

	public float speed = 3.0f;
	//Speed.
	public Transform target;
	//What are we chasing?

	public bool isWaiting = false;
	//We can use this to pause our enemy's movement.

	Rigidbody rb;
	Vector3 movement;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!isWaiting) {
			//If this enemy is not waiting, then have it move.
			Move ();
		}
	}

	void Move() {
		movement = target.position - transform.position;
		//Get the distance between the target and where we are now.
		movement.y = 0f;
		//We don't want the enemy to fly into the air or sink through the floor, so we want no y-axis movement.
		rb.AddForce (movement.normalized * speed, ForceMode.VelocityChange);
		//Add force to the rigidbody to move it.
		//"Normalized" gives us a Vector3 with its values scaled to between -1 and 1. 
		//This makes it fair since the player's movement is calculated at the same scale.
		rb.velocity = Vector3.ClampMagnitude (rb.velocity, speed);
		//Finally, make sure it doesn't go faster than it is allowed to.
	}
}
