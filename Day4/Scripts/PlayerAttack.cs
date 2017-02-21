using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	public int attackPower = 1;

	public float timeBetweenAttacks = 0.1f;
	//How many seconds to wait before attacking again.

	float timer = 0;
	//Timer for waiting.
	bool isAttacking;
	//Are we currently attacking someone?


	ParticleSystem attackParticles;

	Rigidbody rb;

	RaycastHit jumpHit;

	public LayerMask enemyLayer;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		attackParticles = GetComponentInChildren<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		timer += Time.deltaTime;
		if (timer >= timeBetweenAttacks) {
			timer = 0;
			Attack ();
		}
	}

	void Attack() {
		//When the player jumps on top of an enemy, it should get hurt.

		Vector3 centerPoint = transform.position;
		//We store our current position.
		centerPoint.y += 1f;
		//Since the position is calculated at this character's feet, we'll need to add to the y-value to get the center of the character.


		//We'll use a Raycast again. This time, we can use a different way of raycasting that also gives us information about what it hit.
		//The order is: start point, direction, RaycastHit, maxDistance, and LayerMask.
		//The "out" keyword here is special and allows the Raycast function to change this variable and give it back to us.
		//This way, we can get information about what we hit.
		if(Physics.Raycast(centerPoint, -Vector3.up, out jumpHit, 1.1f, enemyLayer)) {
			//We get the enemy's health.
			EnemyHealth enemyHealth = jumpHit.collider.GetComponent<EnemyHealth>();
			//If the enemy's health is not null (meaning it exists)...
			if (enemyHealth != null) {
				//The enemy takes damage.
				enemyHealth.TakeDamage (attackPower);
			}

			//The attack particles should play.
			attackParticles.Stop ();
			attackParticles.Play ();

			//The player should bounce up.
			rb.AddForce(Vector3.up * 200f, ForceMode.Impulse);
		}
	}
}
