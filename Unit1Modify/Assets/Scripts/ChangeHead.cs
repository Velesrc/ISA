using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeHead : MonoBehaviour {
	private SpriteRenderer sp;
	public Sprite[] headArray;
	[SerializeField] private int ArrayElement;
	// Use this for initialization
	void Start () {
		ArrayElement = 0;
		sp = gameObject.GetComponent<SpriteRenderer> ();
		sp.sprite = headArray[ArrayElement];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PrevClicked() {
		if (ArrayElement > 0)
			ArrayElement -= 1;
		else
			ArrayElement = 2;
		sp.sprite = headArray [ArrayElement];
	}

	public void NextClicked() {
		if (ArrayElement < 2)
			ArrayElement += 1;
		else
			ArrayElement = 0;
		sp.sprite = headArray [ArrayElement];
	}

	public void OnStart() {
		PlayerPrefs.SetInt ("head", ArrayElement);
		UnityEngine.SceneManagement.SceneManager.LoadScene (1);
	}
}
