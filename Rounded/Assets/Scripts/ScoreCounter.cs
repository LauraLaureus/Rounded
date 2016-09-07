using UnityEngine;
using System.Collections;

public class ScoreCounter : MonoBehaviour {

	public GameObject enemy;
	public double score = 0;


	
	// Update is called once per frame
	void FixedUpdate () {
		float distance = Vector3.Distance (enemy.transform.position, transform.position);
		score += distance * Time.fixedDeltaTime;
	}
}
