using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayParticle : MonoBehaviour {
	//particle effect played on death
	public ParticleSystem deathEffect;
	//the parent for the death particle to keep the heirachy clean
	public Transform particleParent;
	public float destroyTime = 3f;

	// Use this for initialization
	void Start () {
		deathEffect.Play ();
		Destroy (this.gameObject, destroyTime);
	}
	
	// Update is called once per frame
	void Update () {

	}
}
