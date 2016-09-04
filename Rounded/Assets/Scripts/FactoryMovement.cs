using UnityEngine;
using System.Collections;

public class FactoryMovement : MonoBehaviour {

	public float forwardAdjustement;

	private Rigidbody rb;

	void Start(){
		rb = this.gameObject.GetComponent<Rigidbody> ();
	}

	void OnEnable(){
		DifficultyController.shareDifficulty += updateDifficulty;
	}

	void updateDifficulty(float d){
		forwardAdjustement = d;
	}

	void OnDisable(){
		DifficultyController.shareDifficulty += updateDifficulty;
	}
	// Update is called once per frame
	void FixedUpdate () {
		Debug.DrawRay (this.transform.position, Vector3.up, Color.red);
		rb.velocity = Vector3.forward*forwardAdjustement;
	}
}
