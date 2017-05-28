using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public Transform spawnOne;
	public Transform spawnTwo;
	public Transform spawnThree;
	public Transform spawnFour;
	public GameObject spawnPrefab1;
	public float spawnSpeed = 10f; 
	public Transform ObstacleParent;

	// Use this for initialization
	void Start () {
//		spawnPrefab1.transform.position = spawnOne.transform.position;

	}
	
	// Update is called once per frame
	void Update () {
		
			GameObject GO = Instantiate (spawnPrefab1, spawnOne.position, Quaternion.identity) as GameObject;
			GO.GetComponent<Rigidbody> ().AddForce (spawnOne.transform.right * spawnSpeed, ForceMode.Impulse);
		GO.transform.SetParent (ObstacleParent);

	}
}
