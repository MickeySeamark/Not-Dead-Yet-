using UnityEngine;
using System.Collections;


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

	// Use this for initialization
	void Start () 
	{
		//makes the players ammo count minus 1 per bullet shot.
		if (currentAmmo == -1)
			currentAmmo = maxAmmo;
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		//when the player is reloading the rest if the function does not run.
		if (isReloading)
			return;
		//when the player is out of ammo they will begin reloading
		if (currentAmmo <= 0)
		{
			StartCoroutine(Reload());
			return;
		}
		// this is calling the funtion of "shooting" as soon as the button is pressed
		if (XboxCtrlrInput.XCI.GetButtonDown(XboxCtrlrInput.XboxButton.A))
		{
			Shoot ();
		}
}
	IEnumerator Reload ()
	{
		//when the player begins to reload they cannot shoot for a period of time.
		isReloading = true;
		Debug.Log("reloading...");
		yield return new WaitForSeconds (reloadTime);
	
		//when the current ammo is back to max ammo the reloading ends.
		currentAmmo = maxAmmo;
		isReloading = false;
	}
	void Shoot()
	{
		currentAmmo--;
		// this will send a raycast out from the player and towards the left hand side of the screen.
		RaycastHit hit;
		if (Physics.Raycast(player.transform.position, player.transform.right, out hit, range))
		{
			//this lets us know what the raycast hit.
			Debug.Log (hit.transform.name);
		
			//a variable so that it will only damage things labled enemy
			Enemy enemy = hit.transform.GetComponent<Enemy>();
			if (enemy != null )
			{
				enemy.takeDamage (damage);
			}
		}
	}
}
