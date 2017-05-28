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

	    void Start () {
	        player = GameObject.FindGameObjectWithTag ("Player");
	        navAgent = GetComponent<NavMeshAgent> ();
	    }
	
	    void Update () {
// every frame the enemy will look for the players position and head towards it.
		if (Vector3.Distance (transform.position, player.transform.position) < detectionRange) {
			navAgent.destination = player.transform.position;
		}
	}

//allows the enemy to take damage
	public void takeDamage (float amount)
	{
//health is adjusted based on how much damage is taken.
		health -= amount;
//if health is lower or equal to zero they die.
		if (health <= 0f)
		{
			Die ();
		}
	}
//death function
	void Die ()
	{
//when the death function is called the game object is destroyed.
		Destroy (gameObject);

	}
	//when the collider hits another and it has a tag of obstacle it calls the Die function
	void OnTriggerEnter(Collider other){
		if (other.tag == "Obstacle") {
			Destroy (this.gameObject);

	}

	}

}
