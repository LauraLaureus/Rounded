using UnityEngine;
using System.Collections;

public class FloorSpawn : MonoBehaviour {

	public GameObject floorPrefab;

	void FixedUpdate () {
		Instantiate (floorPrefab,this.transform.position,Quaternion.identity);
	}
}
