//Moves the background so that it cycles as much as the player is alive

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour {

	private BoxCollider2D groundCollider; 
	private float groundHorizontalLenght; // The lenght of the screen on the x axis 

	//Initializes the ground's box collider and gets its lenght
	void Start () {
		groundCollider = GetComponent<BoxCollider2D> ();
		groundHorizontalLenght = groundCollider.size.x;
	}
	
	//Checks if the current screen has escaped the camera view and calls it's reposition if true
	void Update () {
		if (transform.position.x < -groundHorizontalLenght) {
			RepositionBackground ();
		}
	}

	//Repositions the ground 
	private void RepositionBackground () {
		Vector2 groundOffset = new Vector2 (groundHorizontalLenght * 2f, 0);
		transform.position = (Vector2)transform.position + groundOffset;
	}
}
