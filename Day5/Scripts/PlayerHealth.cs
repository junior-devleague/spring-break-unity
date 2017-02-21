using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public int startingHealth;
	//How much health do we start this level with?
	public Slider healthbar;
	//A reference to the health bar we made in the UI, so we can change it when our health changes.

	int currentHealth;
	//We make our currentHealth private because we don't want it being changed directly.
	MovePlayer movePlayer;
	//We need to reference MovePlayer so we can stop the player from moving when they run out of health.
	bool isDead = false;
	//Finally, keep track of whether we've already died, so we don't keep taking damage.

	// Use this for initialization
	void Start () {
		currentHealth = startingHealth;
		//Set the current health to the starting health for this level.
		movePlayer = GetComponent<MovePlayer> ();
	}
	
	// Update is called once per frame
	void Update () {
		healthbar.value = currentHealth;
		//Keep our healthbar updated with the player's current health.
	}

	public void TakeDamage(int amount) {
		//We make this function public so that enemies can have access to this function to give us damage.
		if (!isDead) {
			currentHealth -= amount;
			//Take away health
			if (currentHealth <= 0) {
				//If we are at 0 or less health remaining, set health to zero. We can't have negative health.
				currentHealth = 0;
				//Finally, call a function to handle the player dying.
				Die ();
			}
		}
	}

	void Die() {
		//When the player dies...
		isDead = true;
		//isDead is true.
		movePlayer.enabled = false;
		//The player cannot move when they are dead.
		LevelOverManager.LoseLevel();
		//Now we tell our Level Over Manager that the player has lost.
	}
}
