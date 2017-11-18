using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public int PlayerScore;
	public bool log = false;
	public float speed = 4f;
	private int timeSeconds;
	[SerializeField] private float HorMov;
	[SerializeField] private float VerMove;
	// Use this for initialization
	private Rigidbody2D hero;
	void Start () {
		timeSeconds = 0;
		InvokeRepeating("SecondTime", 0f, 1f);
		hero = this.GetComponent<Rigidbody2D> ();	
		PlayerScore = 0;
	}
	
	// Update is called once per frame
	void Update () {
		HorMov = Input.GetAxis ("Horizontal");
		VerMove = Input.GetAxis ("Vertical");

		hero.AddForce (new Vector2 (HorMov * speed, VerMove * speed));
	}

	void OnCollisionEnter2D() {
		if (log == true)
		Debug.Log ("PlayerTouchSomething");
	}
	void SecondTime(){
		Debug.Log (timeSeconds);
		timeSeconds += 1;

	}
}
