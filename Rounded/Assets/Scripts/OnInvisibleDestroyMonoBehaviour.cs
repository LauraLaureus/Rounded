using UnityEngine;
using System.Collections;

public class OnInvisibleDestroyMonoBehaviour : MonoBehaviour {


	/*void OnBecameInvisible(){
		Destroy(gameObject);
	}*/

	void OnCollisionExit(Collision col){
		if (col.collider.gameObject.name == "Enemy")
			Destroy (gameObject);
	}
}
