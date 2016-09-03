using UnityEngine;
using System.Collections;

public class UserCharacterController : MonoBehaviour {

	public float jumpAdjustement;
	public float forwardAdjustement;

	private Rigidbody rb;
	private Animator animator;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody> ();
		animator = gameObject.GetComponent<Animator> ();
	}

	void Update(){
		animator.SetFloat ("ForwardAdjustement", forwardAdjustement);
	}

	// Update is called once per frame
	void FixedUpdate () {
		Vector3 movement = Vector3.forward*forwardAdjustement;
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			movement += Vector3.up * jumpAdjustement;
		}
		rb.velocity += movement;
	}
}
