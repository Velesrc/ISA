using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Eaten : MonoBehaviour {
	public bool log = false;
	private Text ScoreText;
	private PlayerController pc;
	// Use this for initialization
	void Start () {
		ScoreText = GameObject.Find ("Score").GetComponent<Text> ();
		pc = GameObject.Find ("pacman").GetComponent<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Player") {
			pc.PlayerScore += 1;
			ScoreText.text = "Score: " + pc.PlayerScore.ToString ();
			if (log == true)
				Debug.Log ("Collision with grape");
			MonoBehaviour.Destroy (gameObject);
		}
	}
}
