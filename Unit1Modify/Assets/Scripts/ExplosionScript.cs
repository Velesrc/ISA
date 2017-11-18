using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour {
	private SpriteRenderer sr;
	public Sprite[] heads;
	public AudioClip clip;
	public int health;
	public GameObject expl;
	// Use this for initialization
	void Start () {
		if (health <= 0)
			health = 3;
		sr = gameObject.GetComponent<SpriteRenderer> ();
		sr.sprite = heads[PlayerPrefs.GetInt("head", 0)];
		Debug.Log ("Enemy have " + health + " health"); 
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.Mouse0)) {
			gameObject.transform.localScale += new Vector3 (-0.2f, -0.2f, 0f);
			health--;
			Debug.Log ("Enemy have " + health + " health"); 
			if (health == 0) {
				Debug.Log("Destroy!");
				MonoBehaviour.Destroy (gameObject);
				MonoBehaviour.Instantiate (expl);
				AudioSource.PlayClipAtPoint (clip, gameObject.transform.position, 1f);
			}
		}
	}
}
