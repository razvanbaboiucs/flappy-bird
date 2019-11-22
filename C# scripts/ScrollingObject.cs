//Scrolls the object backward with a global scrolling speed

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour {

	private Rigidbody2D scrollerBody;

	//Initializes the rigid body which we want to move and sets it's velocity: moves only on the x axis with a global scroll speed 
	void Start () {
		scrollerBody = GetComponent<Rigidbody2D> ();
		scrollerBody.velocity = new Vector2 (GameControl.instance.scrollSpeed, 0);
	}
	
	//Checks if the game is over and if it is it stops the scroll of the object
	void Update () {
		if (GameControl.instance.gameOver == true) {
			scrollerBody.velocity = Vector2.zero;
		}
	}
}
