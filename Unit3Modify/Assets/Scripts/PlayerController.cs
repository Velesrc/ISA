using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	//PRIVATE
	private bool facingRight;
	private UnityEngine.UI.Text SetText;
	private Rigidbody2D rb2d;
	private SpawnManager sm;
	// Temporary
	private float tmpHor;
	private Vector3 tmpPosition;
	public float showY;
	//PUBLIC
	public float Timer = 30;
	public int PlayerScore = 0;
	public Transform groundCheck;
	public bool jump = false;
	public  float moveForce = 60;
	public float maxSpeed = 5f;
	public float jumpForce = 400f;
	public bool grounded = false;
	// Use this for initialization
	void Awake () {
		
		sm = GameObject.Find ("SpawnManager").GetComponent<SpawnManager> ();
		rb2d = GetComponent<Rigidbody2D> ();
		SetText = GameObject.Find("Score").GetComponent<UnityEngine.UI.Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		showY = gameObject.transform.position.y;
		if (sm.lowestY > gameObject.transform.position.y) {
			SetText.text = "You fall!!!";
			Time.timeScale = 0.0f;
		}
		Timer -= Time.deltaTime;
		if (Timer <= 0 && PlayerScore < 10) {
			SetText.text = "You Lose :(";
		}
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

		if(Input.GetButtonDown("Jump") && grounded){
				jump = true;
			}
		}

	void FixedUpdate(){
		tmpHor = Input.GetAxis ("Horizontal");
		
		if (tmpHor > 0 && facingRight)
			Flip ();
		else if (tmpHor < 0 && !facingRight)
			Flip ();

		if (rb2d.velocity.x * tmpHor < maxSpeed)
			rb2d.AddForce (Vector2.right * tmpHor * moveForce);
								
		if (Mathf.Abs (rb2d.velocity.x) > maxSpeed) {
			rb2d.velocity = new Vector2 (Mathf.Sign (rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);

		if (jump) {
				rb2d.AddForce(new Vector2 (0f, jumpForce));
				jump = false;
		}
				
		}
	}
	void Flip(){
		facingRight = !facingRight;
		tmpPosition = transform.localScale;
		tmpPosition.x *= -1;
		gameObject.transform.localScale = tmpPosition;
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "coin") {
			PlayerScore++;
			SetText.text = "Score: " + PlayerScore.ToString ();

			if (PlayerScore == 10) {
				Time.timeScale = 0.0f;
				SetText.text = "You WIN!!!!!";
			}
		} else if (other.gameObject.tag == "damage") {
			gameObject.transform.Rotate (0f, 0f, 90);
			GameObject.Find ("Main Camera").transform.Rotate (0f, 0f, -90);
			Time.timeScale = 0.0f;
			SetText.text = "YOU DIED";
		}
	}
}
