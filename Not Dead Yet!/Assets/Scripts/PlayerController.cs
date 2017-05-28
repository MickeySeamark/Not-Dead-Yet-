using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class PlayerController : MonoBehaviour {
	//allowing the script to recognise the Xbox Controller as being named controller.
	public XboxController controller;
	//setting the players movement speed.
	public float movementSpeed = 0.1f;
	//setting the players health

	public float health = 100;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Move player along the X and Z Axis using the left analog stick on the Xbox Controller.
		float axisX = XCI.GetAxis (XboxAxis.LeftStickX, controller);
		float axisZ = XCI.GetAxis (XboxAxis.LeftStickY, controller);
		Vector3 movement = new Vector3 (axisX, 0, axisZ);
		transform.Translate (movement * movementSpeed * Time.deltaTime);
	}
		//allows the enemy to take damage
		public void takeDamage (float amount)
		{
			health -= amount;
			if (health <= 0f)
			{
				Die ();
			}
		}

		void Die ()
		{
			Destroy (gameObject);
	}
	void OnTriggerEnter(Collider other){
		if (other.tag == "Obstacle") {
			Destroy (this.gameObject);
//			Respawn();
		}
		if (other.tag == "Hazard") {
			Destroy (this.gameObject);
		}
//
//	}
//	void Respawn() {
//		transform.position = Vector3.zero;
	}
}
