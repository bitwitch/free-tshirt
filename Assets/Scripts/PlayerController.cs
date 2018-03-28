using System.Collections; 
using System.Collections.Generic;
using UnityEngine;
using System; 

public class PlayerController : MonoBehaviour {

	public event Action<int> AttackHit;

	Vector3 movement, direction, velocity, moveAmount;
	Rigidbody myRigidbody;
	float verticalVelocity;
	float health; 
	public float speed = 15f;
	public Collider[] attackHitboxes; 
	
	void Start() {
		myRigidbody = GetComponent<Rigidbody>();
	}

	void OnTriggerEnter(Collider triggerCollider) {
		// print(triggerCollider.gameObject.name);
	}

	void LaunchAttack(Collider collider) {
		Collider[] colliders = Physics.OverlapBox(collider.bounds.center,
			collider.bounds.extents, collider.transform.rotation, LayerMask.GetMask("EnemyHurtbox"));

		foreach(Collider c in colliders) {
			if (c.name == "Head") {
				AttackHit?.Invoke(10);
				Debug.Log("hit head"); 
			} else if (c.name == "Torso") {
				AttackHit?.Invoke(7);
				Debug.Log("hit torso");
			} else if (c.name == "Feet") {
				AttackHit?.Invoke(4);
				Debug.Log("hit feet");
			} 
		}
	}

	void Update() {

		// Attack 
		// Bitch Slap 
		if (Input.GetKeyDown(KeyCode.J)) {
			LaunchAttack(attackHitboxes[0]);
		// Gut Poke 
		} else if (Input.GetKeyDown(KeyCode.K)) {
			LaunchAttack(attackHitboxes[1]);
		// Low Kick 
		} else if (Input.GetKeyDown(KeyCode.L)) {
			LaunchAttack(attackHitboxes[2]); 
		}

		// Movement
		
		// TODO: Jumping

		// Horizontal
		movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")); 
		direction = movement.normalized; 
		velocity = direction * speed; 
		moveAmount = velocity * Time.deltaTime;

		transform.Translate(moveAmount);
	}

	void FixedUpdate() {
		myRigidbody.position += velocity * Time.fixedDeltaTime;  
	}
}
