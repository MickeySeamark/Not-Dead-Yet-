using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

//	public Transform spawnOne;
//	public Transform spawnTwo;
//	public Transform spawnThree;
//	public Transform spawnFour;
	public GameObject spawnPrefab1;
//	public float spawnSpeed = 10f; 
	public Transform ObjectParent;
	public float maxTime = 5;
	public float minTime = 2;
	private float time;
	private float spawnTime;

	// Use this for initialization
	void Start () {
		SetRandomTime ();
		time = minTime;
//		spawnPrefab1.transform.position = spawnOne.transform.position;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		time += Time.deltaTime;
		if (time >= spawnTime){
			SpawnObject();
			SetRandomTime();

		}
//		
//			GameObject GO = Instantiate (spawnPrefab1, spawnOne.position, Quaternion.identity) as GameObject;
//			GO.GetComponent<Rigidbody> ().AddForce (spawnOne.transform.right * spawnSpeed, ForceMode.Impulse);
//		GO.transform.SetParent (ObstacleParent);

	}
	void SpawnObject(){
		time = 0;
		Instantiate (spawnPrefab1, transform.position, spawnPrefab1.transform.rotation);
	}
	void SetRandomTime(){
		spawnTime = Random.Range (minTime, maxTime);
	}
}
