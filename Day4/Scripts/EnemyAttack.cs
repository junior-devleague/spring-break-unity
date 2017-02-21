using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

	public int damage;
	//How much damage this enemy will do.

	public float timeBetweenAttacks;
	//How many seconds to wait before attacking again.

	float timer = 0;
	//Timer for waiting.
	bool isAttacking;
	//Are we currently attacking someone?

	EnemyMove enemyMove;
	//We'll use isWaiting from our EnemyMove to have the enemy stop chasing us right after it attacks.

	// Use this for initialization
	void Start () {
		enemyMove = GetComponent<EnemyMove> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (isAttacking) {
			timer += Time.deltaTime;
			//If we are attacking, increase the timer.
		}
		if (timer >= timeBetweenAttacks) {
			//If we've waited long enough, reset the timer and stop attacking.
			timer = 0;
			isAttacking = false;
			enemyMove.isWaiting = false;
			//Allow this enemy to move again.
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("Player")) {
			//If a player comes within range...
			isAttacking = true;
			//We attack it.
			enemyMove.isWaiting = true;
			//Stop chasing once you attack.
			PlayerHealth pH = other.GetComponent<PlayerHealth> ();
			//Get the PlayerHealth so we can make this player take damage.
			pH.TakeDamage (damage);
			//Use our damage value to give damage to the player.
		}
	}
}
