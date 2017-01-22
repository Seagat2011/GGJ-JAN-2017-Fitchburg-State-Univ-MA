using UnityEngine;
using System.Collections;
using System.Collections.Generic;       //Allows us to use Lists. 
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

	//public static GameManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
	public static int HighScore;

	public Text ScoreText;
	public static int Score;

	public float TimeStamp;
	public int TScore;

	public bool isPlayingGame = true;


	void Start () {
		Score = 0;
		isPlayingGame = true;
		ScoreText.text = "Score: " + TScore.ToString ();

	} 

	void Update () {
		TimeStamp += Time.deltaTime;

		if (TimeStamp > 5) {
			TScore += 1;
			TimeStamp = 0;
		}
			
		Score = TScore;
		ScoreText.text = "Score: " + TScore.ToString ();
		HighScore = TScore;


	}

}// class GameManager //
