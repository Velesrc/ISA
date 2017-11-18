using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour {
	public float UpSpeed;
	public float liveTime;
	// Use this for initialization
	void Start () {
		liveTime = 2;
		if (UpSpeed <= 0)
			UpSpeed = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
		liveTime -= Time.deltaTime;
		if (liveTime <= 0)
			MonoBehaviour.Destroy (gameObject);
		gameObject.transform.Translate(new Vector3 (0f, UpSpeed, 0f));
	}

	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.tag == "enemy")
		MonoBehaviour.Destroy (gameObject);
	}
}
