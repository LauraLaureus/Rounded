using UnityEngine;
using System.Collections;

public class FactoryMovement : MonoBehaviour {

	public float forwardAdjustement;

	private Rigidbody rb;

	void Start(){
		rb = this.gameObject.GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		Debug.DrawRay (this.transform.position, Vector3.up, Color.red);
		Vector3 movement = Vector3.forward*forwardAdjustement;
		rb.velocity += movement;
	}
}
