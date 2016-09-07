using UnityEngine;
using System.Collections;

public class FloorSpawn : MonoBehaviour {

	public GameObject floorPrefab;

	public float distanceToActivate;
	private Vector3 lastPosition;



	public delegate void BuildLevelEvent();
	public static event BuildLevelEvent OnNewPositionReached;
	public short distanceToBuild = 0;

	void Start(){
		lastPosition = transform.position;
	}


	void FixedUpdate () {
		if (Vector3.Distance (transform.position, lastPosition) > distanceToActivate) {
			lastPosition = transform.position;
			Instantiate (floorPrefab,this.transform.position,Quaternion.identity);
			distanceToBuild += 1;
			if (OnNewPositionReached != null && distanceToBuild == 4) {
				OnNewPositionReached ();
				distanceToBuild = 0;
			}
		}
	}


}
