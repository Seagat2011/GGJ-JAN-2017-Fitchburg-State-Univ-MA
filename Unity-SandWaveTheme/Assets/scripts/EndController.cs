using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndController : MonoBehaviour {

	public Text scoreText;
	private int score;

	// Use this for initialization
	void Start () {
		score = GameManager.Score;
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = score.ToString ();
	}
}
