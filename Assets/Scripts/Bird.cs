//It controls the player's bird movements and it's phisics

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

	public float upwardForce = 200f; // the force that will push the bird upward

	private bool isDead = false; // is true when the player dies ( hits an object ) and false when it's alive
	private Rigidbody2D player;
	private Animator animationParameter; // controls the animations 

	//Initializing the player and the animator controller
	void Start () {
		player = GetComponent<Rigidbody2D> (); 
		animationParameter = GetComponent<Animator> ();
	}
	
	//Checks if the player is not dead and if it gets user input
	//If both are true the bird's velocity will get an upward impulse and the flap animation will start playing
	void Update () {
		if (isDead == false) {
			if (Input.GetMouseButtonDown (0)) {
				player.velocity = Vector2.zero;
				player.AddForce (new Vector2 (0, upwardForce));
				animationParameter.SetTrigger ("Flap");
			}
		}
	}

	//When the bird collides with another rigid body the player dies: player's movement stops and the death animations starts playing
	void OnCollisionEnter2D () {
		player.velocity = Vector2.zero;
		isDead = true;
		animationParameter.SetTrigger ("Die");
		GameControl.instance.BirdDied ();
	}
}
