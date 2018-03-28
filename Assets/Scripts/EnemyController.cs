using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public float health = 100,
		attackStrength = 1,
		defense = 1;

	public Transform targetTransform;
	public float speed = 12.5f;

	void Start()	{
		FindObjectOfType<PlayerController>().AttackHit += TakeDamage; 
	}

	void TakeDamage(int damage) {
		this.health -= damage;
		Debug.Log(string.Format("Enemy health: {0}", this.health));
	}

	void Update () {
		// Vector3 displacementFromTarget = (targetTransform.position - transform.position); 
		// Vector3 directionToTarget = displacementFromTarget.normalized;
		// Vector3 velocity = directionToTarget * speed;
		// float distanceToTarget = displacementFromTarget.magnitude; 

		// if (distanceToTarget > 5) {
		// 	transform.Translate(velocity * Time.deltaTime); 
		// }
	}
}
