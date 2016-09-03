using UnityEngine;
using System.Collections;

public class OnInvisibleDestroyMonoBehaviour : MonoBehaviour {

	void OnBecameInvisible(){
		Destroy(gameObject);
	}
}
