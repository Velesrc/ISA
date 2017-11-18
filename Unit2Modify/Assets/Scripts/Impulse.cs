using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impulse : MonoBehaviour {
	public bool log = false;
	public float y, x;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D other) {
		if(log == true)
			Debug.Log ("Collision with Wall");
		other.rigidbody.AddForce (new Vector2 (x, y), ForceMode2D.Impulse);
	}
}
