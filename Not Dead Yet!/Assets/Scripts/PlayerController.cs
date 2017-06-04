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

	private bool isDead = false;

	public ParticleSystem deathEffect;
	public Transform particleParent;


//	public float xMin, xMax, zMin, zMax;


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

		if (isDead)
			return;
		//Move player along the X and Z Axis using the left analog stick on the Xbox Controller.
		float axisX = XCI.GetAxis (XboxAxis.LeftStickX, controller);
		float axisZ = XCI.GetAxis (XboxAxis.LeftStickY, controller);
		Vector3 movement = new Vector3 (axisX, 0, axisZ);
		transform.Translate (movement * movementSpeed * Time.deltaTime);

//		{
//			Mathf.Clamp (Rigidbody.position.x, xmin, xmax);
//			0.0f;
//			Mathf.Clamp (Rigidbody.position.z, zxmin, zmax);
//	}
}
	//--------------------------------------------------------------------------------
	//takeDamage()
	//called when the object hits something that has a Damage variable and adjusts the objects health acordingly
	//
	//Param:
	//		health - the amount of damage the object can take before dying
	//		amount - the damage of to the object that adjusts the health
	//		
	//Return:
	//		Void
	//--------------------------------------------------------------------------------
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
	//--------------------------------------------------------------------------------
	//Die()
	//when called it destroys the gameobject
	//
	//Param:
	//		
	//		
	//Return:
	//		Void
	//--------------------------------------------------------------------------------
		void Die ()
	//when the die function is called it destroys the gameobject.
		{
		isDead = true;
		deathEffect.Play ();
		GetComponent<Score> ().OnDeath ();
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
		if (other.tag == "Obstacle") {
			Die ();

		}
		// as above but with the hazard tag.
		if (other.tag == "Hazard") {
			Die ();
		}

	}
}
