using UnityEngine;
using System.Collections;

public class DifficultyController : MonoBehaviour {

	public delegate void DifficultyEvent(float d);
	public static event DifficultyEvent shareDifficulty;

	public float difficulty;


	void Start () {
		difficulty = 1f;
	}
	

	void FixedUpdate () {
		difficulty += 0.0000001f; 
		if(shareDifficulty != null)
			shareDifficulty(difficulty);
	}
}
