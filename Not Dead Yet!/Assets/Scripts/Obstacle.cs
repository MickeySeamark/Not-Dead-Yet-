using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {
//setting the speed that the object will move
	public float speed = 1f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
//moves the player to the right of the screen based on the speed set in the float, 
//being checked each frame
		transform.Translate (-speed * Time.deltaTime, 0, 0);
	}
	//when the objects collider hits another with the tag "KillZone" it destroys itsef
	void OnTriggerEnter(Collider other){
		if (other.tag == "KillZone") {
			Destroy (this.gameObject);

		}
	} 
}
