using UnityEngine;
using System.Collections;

public class OnInvisibleDestroyMonoBehaviour : MonoBehaviour {

	void OnBecameInvisible(){
		Debug.Log ("I became invisible");
		Destroy(this.gameObject);
	}
}
