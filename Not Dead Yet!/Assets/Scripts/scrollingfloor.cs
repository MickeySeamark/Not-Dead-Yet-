using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollingfloor : MonoBehaviour {
	//setting the speed that the material will scroll
	public float scrollSpeed = 0.01F;
	//the material that needs to be scrolled
	public Material materialToAnimate;
	//the second material that needs to be scrolled
	public Material materialToAnimate2;
	//-------------------------------------------------------------------------------
	//Update()
	//called every frame to see if any of the functions listed within it need to be called.
	//
	//Param:
	//		None
	//Return:
	//		Void
	//--------------------------------------------------------------------------------
	void Update() {
		//sets the offset to be checked everyframe so it stays a consistant speed
		float offset = Time.deltaTime * scrollSpeed;
		//setting the offset to be scrolled on the x axis and not the Z
		materialToAnimate.mainTextureOffset -= new Vector2 (-offset, 0);
		materialToAnimate2.mainTextureOffset -= new Vector2 (-offset, 0);
	}

}
