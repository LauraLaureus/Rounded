using UnityEngine;
using System.Collections;

public class OnInvisibleDestroyMonoBehaviour : MonoBehaviour {

	private bool wasIVisible = false;

	void OnBecameVisible(){
		wasIVisible = true;
	}

	void OnBecameInvisible(){
		Debug.Log ("I became invisible");
		if(wasIVisible)
			Destroy(this.gameObject);
	}
}
