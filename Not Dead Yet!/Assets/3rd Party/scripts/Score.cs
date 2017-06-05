using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	// the total score 
	public float score = 0.0f;
	//the amount of points that the game gives the player per second 
	public float pointsPerSecond;
	//where the score is displayed
	public Text scoreText;
	public float zombieScore = 15; 
	public GameOver gameOver;
	//determines if the player is dead or not
	private bool isDead = false;

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
		score += pointsPerSecond * Time.deltaTime;
		scoreText.text = ((int)score).ToString ();
	}
	void OnTriggerEnter(Collider other){
		if (other.tag == "Zombie") {
			score += zombieScore;
		}
	}
	//-------------------------------------------------------------------------------
	//OnDeath()
	//when the players dies the final score achieved is displayed, if the score is reached a new highscore it is saved.
	//
	//Param:
	//		None
	//Return:
	//		Void
	//--------------------------------------------------------------------------------
	public void OnDeath(){
		isDead = true;
		if(PlayerPrefs.GetFloat("Highscore") < score)
			PlayerPrefs.SetFloat ("Highscore", score);
		gameOver.ToggleGameOverScreen (score);{
		}
	}

}