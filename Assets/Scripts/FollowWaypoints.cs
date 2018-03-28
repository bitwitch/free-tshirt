using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWaypoints : MonoBehaviour {
	public Transform[] waypoints; 
	
	void Start () {
		StartCoroutine(FollowPath()); 
	}

	IEnumerator FollowPath() {
		int len = waypoints.Length; 
		for (int i = 0; i < len; i++) {
			yield return StartCoroutine(Move(waypoints[i].position, 30));
			if (i == len - 1) {
				i = -1; 
			}
		}
	}

	IEnumerator Move(Vector3 target, float speed) {
		while (transform.position != target) {
			transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime); 
			yield return null;
		}
	}
}
