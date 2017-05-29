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
		//makes the players health adjust as it takes damage. once its reached 0 or below 
		//it destroys the game object using the Die function 
			health -= amount;
			if (health <= 0f)
			{
			// calls the die function
				Die ();
			}
		}

		void Die ()
	//when the die function is called it destroys the gameobject.
		{
			Destroy (gameObject);
	}
	// when the collider hits another and the tag is called obstacle the die function is called.
	void OnTriggerEnter(Collider other){
		if (other.tag == "Obstacle") {
			Die ();

		}
		// as above but with the hazard tag.
		if (other.tag == "Hazard") {
			Die ();
		}
//
//	}
//	void Respawn() {
//		transform.position = Vector3.zero;
	}
}
