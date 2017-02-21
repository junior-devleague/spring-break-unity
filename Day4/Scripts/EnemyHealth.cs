using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	Rigidbody rb;
	EnemyMove enemyMove;
	//We need these to keep our enemy from moving once it is dead.
	EnemyAttack enemyAttack;
	//We also don't want it attacking once it's dead.

	public int startingHealth;
	public int pointsWorth = 10;

	int currentHealth;

	bool isDead;

	// Use this for initialization
	void Start () {
		currentHealth = startingHealth;
		enemyMove = GetComponent<EnemyMove> ();
		enemyAttack = GetComponent<EnemyAttack> ();
		enemyAudio = GetComponent<AudioSource> ();
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isDead) {
			//If this enemy is dead, then start pushing it down through the floor.
			transform.Translate (0, -0.1f, 0);
		}
	}

	public void TakeDamage(int amount) {
		if (!isDead) {
			//If this enemy is not dead yet...
			currentHealth -= amount;
			//Subtract from its health.
			if (currentHealth <= 0) {
				//If health would be negative, set it back to zero.
				currentHealth = 0;
				//Call a function that handles what happens when the enemy dies.
				Die ();
			}
		}
	}

	void Die() {
		isDead = true;
		//Enemy is now dead.
		enemyAttack.enabled = false;
		//Don't allow it to keep attacking when it's dead.
		rb.velocity = Vector3.zero;
		//Set its velocity to zero because it is no longer moving.
		enemyMove.enabled = false;
		//Stop it from moving entirely.
		rb.useGravity = false;
		//Don't use gravity, we'll make it slowly sink into the floor.
		rb.isKinematic = true;
		//A Rigidbody that is kinematic is controlled by something that is not the physics engine.
		//We're having it be controlled directly by us instead.
		ScoreManager.AddToScore(pointsWorth);
		//Add to our score when we kill an enemy.

		Destroy (gameObject, 2f);
		//We will destroy this enemy after 2 seconds have passed.
	}
}
