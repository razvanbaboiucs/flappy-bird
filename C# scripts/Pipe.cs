//Checks if the bird went trough a set of pipes by using a box collider and scores points if true

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour {

	private void OnTriggerEnter2D (Collider2D other) {
		if (other.GetComponent<Bird> () != null) {
			GameControl.instance.BirdScored ();
		}
	}
}
