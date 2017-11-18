using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
	public float DownSpeed;
	// Use this for initialization
	void Start () {
		if (DownSpeed <= 0)
			DownSpeed = -3;
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Translate (new Vector3(0f,DownSpeed,0f) * Time.deltaTime);
	}

	void OnCollisionEnter2D()
	{
		MonoBehaviour.Destroy (gameObject);
	}
}
