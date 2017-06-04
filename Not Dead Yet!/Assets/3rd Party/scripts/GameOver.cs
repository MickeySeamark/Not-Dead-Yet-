using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public Text scoreText;
	public Image backgroundImage;

	public bool isShown = false;

	private float transistion = 0.0f;

	// Use this for initialization
	void Start () {
		gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (!isShown)
			return;

		transistion += Time.deltaTime;
		backgroundImage.color = Color.Lerp (new Color (0, 0, 0, 0), Color.black, transistion);
	}

	public void ToggleGameOverScreen (float score){
		gameObject.SetActive (true);
		scoreText.text = ((int)score).ToString ();
		isShown = true;

	}

	public void Retry (){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);

	}

	public void ToMenu(){

		SceneManager.LoadScene("Menu");
	}
}
