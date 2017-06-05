using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {

	//setting the speed that the object will move
	public float speed = 1f;
	public float scoreValue = 15;

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
		
	}
	//-------------------------------------------------------------------------------
	//Update()
	//called every frame to see if any of the functions listed within it need to be called.
	//
	//Param:
	//		None
	//Return:
	//		Void
	//--------------------------------------------------------------------------------
	void Update () {
		transform.Translate (-speed * Time.deltaTime, 0, 0);
	}
	//--------------------------------------------------------------------------------
	//OnTriggerEnter()
	//Trigger Detection, Detects when the object passes through a triggerbox and then destroys itself.
	//
	//Param:
	//		Collider other - the collider of any other objects that pass into this triger.
	//Return:
	//		Void
	//--------------------------------------------------------------------------------
	void OnTriggerEnter(Collider other){
		if (other.tag == "KillZone") {
			Destroy (this.gameObject);
	}
		if (other.tag == "Player") {
			Destroy (this.gameObject);
	}
		if (other.tag == "Hazard") {
			Destroy (this.gameObject);
		}
	}
}