using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public float score = 0.0f;

	public float pointsPerSecond;

	public Text scoreText;

	public GameOver gameOver;

	private bool isDead = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (isDead)
			return;
		score += pointsPerSecond * Time.deltaTime;
		scoreText.text = ((int)score).ToString ();
	}
	public void OnDeath(){
		isDead = true;
		if(PlayerPrefs.GetFloat("Highscore") < score)
			PlayerPrefs.SetFloat ("Highscore", score);
		gameOver.ToggleGameOverScreen (score);{
	}
}

}