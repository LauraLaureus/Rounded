using UnityEngine;
using System.Collections;

public class ConstantSpeed : MonoBehaviour {

	public Vector3 speed;
	public float difficulty;

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		speed = Vector3.forward;
		rb = this.gameObject.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rb.velocity = speed * difficulty;
	}
}
