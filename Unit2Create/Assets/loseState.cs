using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loseState : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D() {
		Debug.Log ("GAME OVER");
		MonoBehaviour.Destroy (GameObject.Find ("player"));
	}
}
