using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	//the amount of health the enemy has.
	public float health = 100f;
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
}
