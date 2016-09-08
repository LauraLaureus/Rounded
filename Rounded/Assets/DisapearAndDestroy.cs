using UnityEngine;
using System.Collections;

public class DisapearAndDestroy : MonoBehaviour {

	public GameObject enemy;

	void LateUpdate(){
		if (Vector3.Distance (transform.position, enemy.transform.position) > 38f)
			Destroy (gameObject);
	}
}
