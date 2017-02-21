using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	Vector3 offset;
	//We need to know how far away the camera needs to be from the object.

	public Transform target;
	//What is this camera focusing on?

	// Use this for initialization
	void Start () {
		offset = transform.position - target.position;
		//This makes sure the camera always stays the same relative to where you put it in the Inspector.
		//When you move the player, your camera should keep focused on it from the same distance away.
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position = target.position + offset;
		//The camera's position is constantly being set to follow the target's position.
		//We add the offset back in so it stays far enough back for us to see our scene.
	}
}
