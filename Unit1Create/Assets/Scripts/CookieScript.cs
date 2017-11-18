using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CookieScript : MonoBehaviour {
	Text score;
	public AudioSource Asource;
	public GameObject[] objects;
	[SerializeField] private int PlayerScore;
	// Use this for initialization
	void Start () {
		
		foreach(GameObject elem in objects){
			elem.GetComponent<SpriteRenderer> ().enabled = false;
		}
		Asource = gameObject.GetComponent<AudioSource>();
		PlayerScore = 0;
		score = GameObject.Find ("ScoreText").GetComponent<Text> ();
		score.text = "0";
	}

	// Update is called once per frame
	void Update () {
		gameObject.transform.Rotate( new Vector3 (0f, 0f, 0.5f));
	}

	void OnMouseDown(){
		Asource.Play ();
		//Debug.Log ("Clicked");
		PlayerScore++;

	switch(PlayerScore){
		case 10:
			Debug.Log ("You got a cursor! It begin making additional cookies!");
			objects [0].GetComponent<SpriteRenderer> ().enabled = true;

			break;
		case 20:
			Debug.Log ("You got a Grandma! She begin making additional cookies!");
			objects [1].GetComponent<SpriteRenderer> ().enabled = true;

			break;
		case 30:
			Debug.Log ("You got a cookie farm! It begin making additional cookies!");
			objects [2].GetComponent<SpriteRenderer> ().enabled = true;

			break;
		default:
			break;


	}
		score.text = PlayerScore.ToString ();
	}


}