using UnityEngine;
using System.Collections;

public class UserCharacterController : MonoBehaviour {

	public float jumpAdjustement;
	public float forwardAdjustement;

	private Rigidbody rb;
	private Animator animator;
	private float distanceToFloor;

	public enum PlayerState
	{
		Forward,
		Jump,
		Fall
	}

	public PlayerState state = PlayerState.Forward;
	private bool landed = false;
	public int jumps;
	public int maxJumps = 2;



	void OnEnable(){
		DifficultyController.shareDifficulty += updateDifficulty;
	}

	void updateDifficulty(float d){
		forwardAdjustement = d;
	}

	void OnDisable(){
		DifficultyController.shareDifficulty += updateDifficulty;
	}

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody> ();
		animator = gameObject.GetComponent<Animator> ();
		distanceToFloor = gameObject.GetComponent<Collider> ().bounds.extents.y;
		StartCoroutine (FSM ());
	}

	IEnumerator FSM(){
		while (true)
			yield return StartCoroutine (state.ToString ());
	}

	void ChangeState(PlayerState st){
		state = st;
	}

	IEnumerator Forward(){
		
		while(state == PlayerState.Forward){
			animator.SetFloat ("ForwardAdjustement", forwardAdjustement);
			moveForward ();
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				ChangeState (PlayerState.Jump);
				landed = false;
			}
			else if (!Physics.Raycast(transform.position,Vector3.down,distanceToFloor+0.1f)){
				ChangeState (PlayerState.Fall);
			}
			yield return 0;
		}
	}

	void moveForward(){
		rb.MovePosition(Vector3.MoveTowards(rb.position,rb.position+Vector3.forward,Time.deltaTime*forwardAdjustement));
	}

	IEnumerator Jump(){
		if (jumps < maxJumps) {
			rb.velocity = new Vector3 (rb.velocity.x, jumpAdjustement, rb.velocity.z);
			if (!landed)
				jumps+=1;
		}
		ChangeState (PlayerState.Fall);
		yield return 0;
	}

	IEnumerator Fall(){
		while (state == PlayerState.Fall) {
			
			animator.SetBool("Falling", true);
			moveForward ();
			if (landed) {
				animator.SetBool("Falling", false);
				ChangeState (PlayerState.Forward);
			}
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				animator.SetBool("Falling", false);
				ChangeState (PlayerState.Jump);
			}
			yield return 0;
		}

	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.name == "Enemy") {
			Destroy (this.gameObject);
		}
		if (col.gameObject.CompareTag ("Terrain")) {
			landed = true;
			animator.SetBool("Falling", false);
			animator.SetFloat ("ForwardAdjustement", forwardAdjustement);
		}
	}
}
