using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {
	public float WinState;
	public float SpawnTime;
	private float Ftime;
	public GameObject enemy;
	// Use this for initialization
	void Start () {
		WinState = 30;
		if (SpawnTime <= 0)
			SpawnTime = 3;
		Ftime = SpawnTime;
	}
	
	// Update is called once per frame
	void Update () {
		WinState -= Time.deltaTime;
		if (WinState <= 0) {
			MonoBehaviour.Destroy (gameObject);
			Debug.Log ("You Win");
		}
		Ftime -= Time.deltaTime;
		if (Ftime <= 0) {
			Instantiate (enemy, new Vector3 (Random.Range (-7, 7), 6f, 0f), Quaternion.identity);
			Ftime = SpawnTime;		
		}
	}
}
