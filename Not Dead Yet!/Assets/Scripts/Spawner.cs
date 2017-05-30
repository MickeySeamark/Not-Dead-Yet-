using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
	//gameObject to be spawned
	public GameObject spawnPrefab1;
	//the position of the parent of the spawned object
	public Transform ObjectParent;
	//maximum time it will take to spawn 
	public float maxTime = 5;
	//minimum time it will take to spawn
	public float minTime = 2;
	//a float to represent the current time 
	private float time;
	//float to represent the spawn time
	private float spawnTime;

	//-----------------------------------------------------------------------------
	//Start()
	//called on the first frame of the game to run the functions listed with in it.
	//
	//Param:
	//		none
	//Return:
	//		Void
	//-------------------------------------------------------------------------------
	void Start () {
		SetRandomTime ();
		time = minTime;

	}
	
	//-------------------------------------------------------------------------------
	//FixedUpdate()
	//called every fixed framerate frame to deal with rigidbody updates.
	//
	//Param:
	//		None
	//Return:
	//		Void
	//--------------------------------------------------------------------------------
	void FixedUpdate () {
		time += Time.deltaTime;
		if (time >= spawnTime){
			SpawnObject();
			SetRandomTime();

		}

	}
	//-------------------------------------------------------------------------------
	//SpawnObject()
	//Creates an object when called
	//
	//Param:
	//		None
	//Return:
	//		Void
	//--------------------------------------------------------------------------------
	void SpawnObject(){
		time = 0;
		GameObject GO = Instantiate (spawnPrefab1, transform.position, spawnPrefab1.transform.rotation);
		GO.transform.SetParent (ObjectParent);
	}
	//-------------------------------------------------------------------------------
	//SetRandomTime()
	//creates a function that will activate at random intervals in a set time frame
	//
	//Param:
	//		None
	//Return:
	//		Void
	//--------------------------------------------------------------------------------
	void SetRandomTime(){
		spawnTime = Random.Range (minTime, maxTime);
	}
}
