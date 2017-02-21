using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		//When you have a collider set to "Is Trigger", it no longer pushes other objects away from itself.
		//Instead of being "solid", other objects can now enter its bounds.
		//When another object does so, this OnTriggerEnter function is automatically called.
		//We can write our own code to go inside of this function, and run when this event happens.
		if (other.CompareTag ("Player")) {
			//We can look at the tag of an object that touches this collider to make sure we're acting on the right one.
			//We don't care if enemies touch this goal, or if other parts of the level come into contact with it.
			//We only care what happens when the player touches it, so this if-statement will only fire on object tagged "Player".
			//This isn't done for you, so make sure you select the "Player" tag on your Player object!
			Debug.Log ("You found the goal!");
			//This will print a message to the console when the player touches this object.
			//If you look at your Console tab, or the bottom edge of your Game view, you should see this message when your player touches this goal.
			//We will do more with this later... soon, this will take you to the next level, or a victory screen!
		}
	}

	void OnTriggerStay(Collider other) {
		//OnTriggerStay works the same, but will fire every frame that the collider is inside the trigger.
		if(other.CompareTag("Player")) {
			Debug.Log("You are hanging out in the goal.");
		}
	}

	void OnTriggerExit(Collider other) {
		//And OnTriggerExit fires when an object that had entered the trigger leaves it.
		if(other.CompareTag("Player")) {
			Debug.Log("You have left the goal.");
		}
	}
}
