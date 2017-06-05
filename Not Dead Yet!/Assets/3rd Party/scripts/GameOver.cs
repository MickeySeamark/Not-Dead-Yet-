using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {
	//displays the final score achieved 
	public Text scoreText;
	//allows the background image to be tweaked / animated
	public Image backgroundImage;
	//determines if the objects are visible or not
	public bool isShown = false;
	//makes the object go from one state to another eg color.
	private float transistion = 0.0f;

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
		gameObject.SetActive (false);
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
		if (!isShown)
			return;

		transistion += Time.deltaTime;
		backgroundImage.color = Color.Lerp (new Color (0, 0, 0, 0), Color.black, transistion);
	}
	//-------------------------------------------------------------------------------
	//ToggleGameOverScreen()
	//allows the game over screen to be viewed when the player dies. displaying final score
	//
	//Param:
	//		Float score - uses the float value from the score script and displays it.
	//Return:
	//		Void
	//--------------------------------------------------------------------------------
	public void ToggleGameOverScreen (float score){
		gameObject.SetActive (true);
		scoreText.text = ((int)score).ToString ();
		isShown = true;

	}
	//-------------------------------------------------------------------------------
	//Retry()
	//when activated it reloads the scene so the player can try again.
	//
	//Param:
	//		None
	//Return:
	//		Void
	//--------------------------------------------------------------------------------
	public void Retry (){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);

	}
	//-------------------------------------------------------------------------------
	//ToMenu()
	//when activated it allows the player to return to the title screen.
	//
	//Param:
	//		None
	//Return:
	//		Void
	//--------------------------------------------------------------------------------
	public void ToMenu(){

		SceneManager.LoadScene("Menu");
	}
}
