using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

//the amount of health the enemy has.
	public float health = 100f;
//how far the enemy can see.
	public float detectionRange =12;
// recognising the players game object
	public GameObject player;
// allowing the script to access the Nav agent.
	private NavMeshAgent navAgent;
// the total amount of points awarded to the player for killing the enemy
	public float enemyScore = 50;
	//particle effect played on death
	public GameObject deathEffect;
	//the parent for the death particle to keep the heirachy clean
	public Transform particleParent;
	public Transform particleSpawn;

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
		// Lets the object know to look for the gameobject with the tag "Player"
	        player = GameObject.FindGameObjectWithTag ("Player");
		//makes the navagent call the NavMeshAgent
	        navAgent = GetComponent<NavMeshAgent> ();
			
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
		// if the player is not found the rest of the script will not run
		if(player != null){
		// every frame the enemy will look for the players position and if in range head towards it.
			if (Vector3.Distance (transform.position, player.transform.position) < detectionRange) {
				navAgent.destination = player.transform.position;
			}
		}

	}
//--------------------------------------------------------------------------------
//takeDamage()
//called when the object hits something that has a Damage variable and adjusts the objects health acordingly. adding points to the players score
//
//Param:
//		health - the amount of damage the object can take before dying
//		amount - the damage of to the object that adjusts the health
//		
//Return:
//		Void
//--------------------------------------------------------------------------------
	public void takeDamage (float amount){
//health is adjusted based on how much damage is taken.
		health -= amount;
//if health is lower or equal to zero the Die function is called.
		if (health <= 0f) {
			GameObject GO = Instantiate (deathEffect, particleSpawn.position, Quaternion.identity) as GameObject;
			GO.transform.SetParent (particleParent);
			Die ();
			GameObject.Find("Player").GetComponent<Score>().score += enemyScore;
		}
	}
//--------------------------------------------------------------------------------
//Die()
//called to destroy the object removing it from the scene
//
//Param:
//		Destroy - Remove somthing from the scene
//		gameObject - the object in the scene that is being destroyed
//
//Return:
//		Void
//--------------------------------------------------------------------------------
	void Die ()	{
//when the death function is called the game object is destroyed.
	
		Destroy (gameObject);{
	

	}
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
		//when the collider hits another and it has a tag of obstacle it calls the Die function.
		if (other.tag == "Obstacle") {
			Die ();
		}

	}

}
