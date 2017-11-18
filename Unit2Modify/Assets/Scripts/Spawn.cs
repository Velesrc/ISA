using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {
	private Vector3 pos;
	public GameObject grape;

	// info 
	 public float ShowTimeEachSecond;
	[SerializeField] private float SpawnTime;
	[SerializeField] private const float sTime = 5;
	// Use this for initialization
	void Start () {
		SpawnTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
		

		SpawnTime -= Time.deltaTime;
		ShowTimeEachSecond += Time.deltaTime;
		if (SpawnTime <= 0) {
			SpawnGrape ();
			SpawnTime = sTime;
		}

		if (ShowTimeEachSecond <= 0) {
			Debug.Log ((int) ShowTimeEachSecond);
			ShowTimeEachSecond = 1;
		}
	}

	void SpawnGrape () {
		
		pos = new Vector3(Random.Range(-8,9),Random.Range(-4,4), 0f);
		MonoBehaviour.Instantiate (grape, pos, Quaternion.identity);
	}
}
