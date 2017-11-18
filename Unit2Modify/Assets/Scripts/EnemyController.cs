using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyController : MonoBehaviour {
	[SerializeField] private float ChangeDirectionEveryCountSeconds;
	[SerializeField] private Vector2 move;
	private Text ScoreText;
	Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		ScoreText = GameObject.Find ("Score").GetComponent<Text> ();
		ChangeDirectionEveryCountSeconds = 0;
		rb = this.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		ChangeDirectionEveryCountSeconds -= Time.deltaTime;

		if (ChangeDirectionEveryCountSeconds <= 0f) {
			move = new Vector2 (Random.Range (-1f, 1f), Random.Range (-1f, 1f));
		}

		rb.AddForce (move);
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player") {
			ScoreText.text = "YOU LOSE!!!";
			MonoBehaviour.Destroy (other.gameObject);
		}
	}
}
