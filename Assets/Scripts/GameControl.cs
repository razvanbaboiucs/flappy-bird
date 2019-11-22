//Controls the entire game: initializations of an instance in the awake state, reseting the game, quitting the game, keeping track of the score & ending the game when the player dies

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameControl : MonoBehaviour {

	public static GameControl instance; // Creates an instance of the game controller which can be called from any other script
	public GameObject gameOverText;
	public Text scoreText;
	public bool gameOver = false;
	public float scrollSpeed = -1000f; // A variable that can be used in any script and represents the speed at which the background objects move in regard with the static player

	private int score = 0;

	//Checks if there is already an instance of the game running and reacts responsibly by destroying it if it does not correspond with the new one
	void Awake () {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
	}
	
	//Checks if the game is over and if it gets user input so it can restart the game
	//Checks if the user wants to quit the game by pressing escape
	void Update () {
		if (gameOver == true && Input.GetMouseButtonDown (0)) {
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
		}
		if (Input.GetKey ("escape")) {
			Application.Quit ();
		}
	}

	//If called the function adds a point to the player score and prints the current score
	public void BirdScored() {
		if (gameOver == true) {
			return;
		} else {
			score++;
			scoreText.text = "Score: " + score.ToString ();
		}
	}

	//If called the function shows the game over text and sets the game current state to over
	public void BirdDied() {
		gameOverText.SetActive (true);
		gameOver = true;
	}
}
