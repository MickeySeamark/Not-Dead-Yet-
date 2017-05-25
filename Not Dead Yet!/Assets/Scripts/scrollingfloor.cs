using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollingfloor : MonoBehaviour {

	public float scrollSpeed = 0.01F;
	public Material materialToAnimate;
	public Material materialToAnimate2;

	void Update() {
		float offset = Time.deltaTime * scrollSpeed;
		materialToAnimate.mainTextureOffset -= new Vector2 (-offset, 0);
		materialToAnimate2.mainTextureOffset -= new Vector2 (-offset, 0);
	}

}
