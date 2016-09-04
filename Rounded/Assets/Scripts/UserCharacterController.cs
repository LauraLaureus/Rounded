using UnityEngine;
using System.Collections;

public class UserCharacterController : MonoBehaviour {

	public float jumpAdjustement;
	public float forwardAdjustement;
	public float fallingAdjustment;

	private Rigidbody rb;
	private Animator animator;
	private float distanceToFloor;
	private bool isJumping;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody> ();
		animator = gameObject.GetComponent<Animator> ();
		isJumping = false;
		distanceToFloor = gameObject.GetComponent<Collider> ().bounds.extents.y;
	}

	void Update(){
		animator.SetFloat ("ForwardAdjustement", forwardAdjustement);
	}

	// Update is called once per frame
	void FixedUpdate () {
		rb.velocity = Vector3.forward*forwardAdjustement + Vector3.down*fallingAdjustment;
		if (Input.GetKeyDown (KeyCode.UpArrow) && !isJumping) {
			rb.velocity += Vector3.up*jumpAdjustement;
			isJumping = true;
		}
		if (Physics.Raycast(transform.position,Vector3.down,distanceToFloor+0.1f))
			isJumping = false;

	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.name == "Enemy") {
			Destroy (this.gameObject);
		}
	}
}
