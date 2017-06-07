using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Shooting : MonoBehaviour {
//how much damge the shot will do.
		public float damage = 25f;

//how much range the gunshot has.
		public float range = 100f;

//a reference to the player.
		public GameObject player;

//maximum ammo the player can have.
		public int maxAmmo = 15;

//this references the current amount of ammo the player has.
		private int currentAmmo;

// this is the time it takes to reload.
		public float reloadTime = 1f;

//used to make the gun only reload when out of ammo.
		private bool isReloading = false;

// allows the ammo count to be displayed on the screen.
		public Text AmmoCount;

// A reference to the particle system
		public ParticleSystem muzzleFlash;

// A reference to the particle system
		public ParticleSystem impactEffect;

	//Reloading text
	public Text reloadingText;

//a parent for the particles to be attached to so they dont clog up the heirachy
	public Transform particleParent;


//-----------------------------------------------------------------------------
//Start()
//called on the first frame of the game to run the functions listed with in it.
//
//Param:
//		none
//Return:
//		Void
//-------------------------------------------------------------------------------
	void Start (){
	//makes current ammo the value of maxAmmo	
	currentAmmo = maxAmmo;
		//calling the ammoCounter function
		AmmoCounter ();
		}
//-----------------------------------------------------------------------------
//AmmoCounter()
//keeps track of how much ammo the player and displays it in the UI.
//
//Param:
//		AmmoCount.text - a Text object that is attached to the UI
//Return:
//		void
//-------------------------------------------------------------------------------
		private void AmmoCounter(){
		//the text attached to the AmmoCount.text object shows the value of the currentAmmo variable
		AmmoCount.text = currentAmmo.ToString ();
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
	void Update (){
		//when the player is reloading the rest if the function does not run.
		if (isReloading)
			return;
		//when the player is out of ammo they will begin reloading
		if (currentAmmo <= 0)
		{
//-------------------------------------------------------------------------------
//StartCoroutine()
//used to make the reload function begin within a single frame
//
//Param:
//		Reload () - makes the player reload adding more bullets to use and stopping them shooting till completed
//Return:
//		Void
//--------------------------------------------------------------------------------
			StartCoroutine(Reload());
			//sends the code to run at the top of the Update 
			return;
		}
		// this is calling the funtion of "shooting" as soon as the "A" button is pressed on the xbox controller
		if (XboxCtrlrInput.XCI.GetButtonDown(XboxCtrlrInput.XboxButton.A)){
			//calling the shoot function
			Shoot ();
		}
}
//-------------------------------------------------------------------------------
//IEumerator()
//used to make the reload function begin take a period of time rather then being completed in a frame
//
//Param:
//		Reload () - makes the player reload adding more bullets to use and stopping them shooting till completed
//Return:
//		void
//--------------------------------------------------------------------------------
	IEnumerator Reload ()
	{
		
		//when the player begins to reload they cannot shoot for a period of time.
		isReloading = true;
		reloadingText.gameObject.SetActive (true); 
		Debug.Log("reloading...");
		yield return new WaitForSeconds (reloadTime);
		reloadingText.gameObject.SetActive (false);
		//when the current ammo is back to max ammo the reloading ends.
		currentAmmo = maxAmmo;
		isReloading = false;
		//sends the total ammo avalible to the UI
		AmmoCounter ();
	
	}
	//-------------------------------------------------------------------------------
	//Shoot()
	//Allows the player to shoot and kill targets by causing damage 
	//
	//Param:
	//		none
	//		
	//Return:
	//		Void
	//--------------------------------------------------------------------------------
	void Shoot()
	{
		//plays a particle effect
		muzzleFlash.Play ();
		//updates the currentAmmo by taking -1 for every time shoot is called
		currentAmmo--;
		//sends the number of Ammo remaining to the UI
		AmmoCounter ();
		// this will send a raycast out from the player and towards the left hand side of the screen.
		RaycastHit hit;
		if (Physics.Raycast (player.transform.position, player.transform.right, out hit, range)) {
			//this lets us know what the raycast hit.
			Debug.Log (hit.transform.name);		
			//a variable so that it will only damage things labled enemy
			Enemy enemy = hit.transform.GetComponent<Enemy> ();
			if (enemy != null) {
				enemy.takeDamage (damage);
			}
			//-------------------------------------------------------------------------------
			//Instantiate ()
			//spawns a particle effect based on where it hit the object
			//
			//Param:
			//		impactEffect - the particle effect that plays.
			//		hit.point - the spot in space where the ray cast hit the collider
			//		Quateranion.LookRotation - calculates all rotations the particle can spawn on.
			//		hit.normal - makes the ray hit the normal of the surface. 
			//Return:
			//		Void
			//--------------------------------------------------------------------------------
			ParticleSystem GO = Instantiate (impactEffect, hit.point, Quaternion.LookRotation (hit.normal));
			GO.transform.SetParent (particleParent);
		
		}
		}

	}

