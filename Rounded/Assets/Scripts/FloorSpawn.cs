using UnityEngine;
using System.Collections;

public class FloorSpawn : MonoBehaviour {

	public GameObject floorPrefab;

	public float distanceToActivate;
	private Vector3 lastPosition;

	void Start(){
		lastPosition = transform.position;
	}


	void FixedUpdate () {
		if (Vector3.Distance (transform.position, lastPosition) > distanceToActivate) {
			lastPosition = transform.position;
			Instantiate (floorPrefab,this.transform.position,Quaternion.identity);
		}

	}
}
