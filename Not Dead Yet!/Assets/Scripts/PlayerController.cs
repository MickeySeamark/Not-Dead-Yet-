using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class PlayerController : MonoBehaviour {
	public XboxController controller;
	public float movementSpeed = 0.1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Move player along the X and Z Axis using the left analog stick on the Xbox Controller.
		float axisX = XCI.GetAxis (XboxAxis.LeftStickX, controller);
		float axisZ = XCI.GetAxis (XboxAxis.LeftStickY, controller);
		Vector3 movement = new Vector3 (axisX, 0, axisZ);
		transform.Translate (movement * movementSpeed * Time.deltaTime);
	}
}
