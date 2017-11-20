using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
	//private 
	private Vector2 randomPosition;
	private GameObject MyPlat, MyCoin;
	public float lowestY;
	//Public
	public int blockCount = 10;
	public GameObject coin;
	public GameObject block;
	public GameObject saw;
	public int SawCount = 3;

	public float HorMin = 10, HorMax = 14;
	public float VerMin = -2, VerMax = 2;
	// Use this for initialization
	public Vector2 origPos; 
	void Start () {
		lowestY = -30;
		origPos = new Vector2 (0f, 0f);;
		Spawn ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Spawn(){
		for (int i = 0; i < blockCount; i++) {
			randomPosition = origPos + new Vector2 (Random.Range(HorMin, HorMax), Random.Range(VerMin, VerMax));

			MonoBehaviour.Instantiate (coin, randomPosition + new Vector2(0f, 2), Quaternion.identity);
			MonoBehaviour.Instantiate (saw, randomPosition + new Vector2(Random.Range(-3,3), 0f), Quaternion.identity);
			//MyCoin.transform.parent = GameObject.Find ("Coins").transform;
			MonoBehaviour.Instantiate (block, randomPosition, Quaternion.identity);
			//MyPlat.transform.parent = GameObject.Find("Platforms").transform;
			origPos = randomPosition;

		}
	}
}
