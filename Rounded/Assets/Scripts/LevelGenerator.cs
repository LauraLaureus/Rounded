using UnityEngine;
using System.Collections;

public class LevelGenerator : MonoBehaviour {

	public GameObject prefab;
	private float lastYPosition = 3.5f;


	void OnEnable(){
		FloorSpawn.OnNewPositionReached += generate; 
	}

	void OnDisable(){
		FloorSpawn.OnNewPositionReached -= generate;
	}

	void generate(){
		float r = Random.value;
		if (r < f ()) {
			genPlatform ();
		} 
		else{
			lastYPosition = 3.5f;
		}
	}

	float f(){
		return 0.5f;
	}

	float f2(){
		return 0.5f;
	}


	void genPlatform(){
		float r = Random.value;
		if (r < f2 ()) {
			Instantiate (prefab, new Vector3 (6, lastYPosition, gameObject.transform.position.z), Quaternion.identity);
		} 
		else {
			float newY = swapLastYPosition ();
			Instantiate (prefab, new Vector3 (6, newY, gameObject.transform.position.z), Quaternion.identity);
			lastYPosition = newY;
		}
	}

	float swapLastYPosition(){
	
		if (lastYPosition == 3.5f) {
			return 7f;
		} else {
			return 3.5f;
		}
	}
}
