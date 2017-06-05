using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour {
	//displays the current highscore
	public Text highscoreText;

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
		highscoreText.text = "Highscore : " + ((int)PlayerPrefs.GetFloat ("Highscore")).ToString ();
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
		
	}

	//-------------------------------------------------------------------------------
	//ToGame()
	//when activated the it loads the games main scene.
	//
	//Param:
	//		None
	//Return:
	//		Void
	//--------------------------------------------------------------------------------
	public void ToGame(){
		SceneManager.LoadScene("Main");
	}
}
