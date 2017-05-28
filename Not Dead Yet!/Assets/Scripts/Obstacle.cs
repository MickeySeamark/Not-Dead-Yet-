using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

	public float speed = 1f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate (-speed * Time.deltaTime, 0, 0);
	}
	void OnTriggerEnter(Collider other){
		if (other.tag == "KillZone") {
			Destroy (this.gameObject);

		}
	}
}
