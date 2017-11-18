using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float minX,maxX;
	public Vector3 LEFT,RIGHT;
	public GameObject shot;
	// Use this for inditialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.LeftArrow) && gameObject.transform.position.x > minX)
			gameObject.transform.Translate (LEFT * Time.deltaTime);
		if (Input.GetKey (KeyCode.RightArrow) && gameObject.transform.position.x < maxX)
			gameObject.transform.Translate (RIGHT * Time.deltaTime);
		if (Input.GetKey (KeyCode.Space))
			MonoBehaviour.Instantiate (shot, transform.position, Quaternion.identity);
	}

	void OnCollisionEnter2D(Collision2D other){
		Debug.Log ("Touched");
		if (other.gameObject.tag == "enemy")
			MonoBehaviour.Destroy (gameObject);
	}
}
