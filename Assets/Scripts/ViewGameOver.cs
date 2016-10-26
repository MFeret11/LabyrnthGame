using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ViewGameOver : MonoBehaviour
{

	public Text scoreLabel;
	public Text levelCountLabel;
	public Text highscoreLabel;
	public float timer;


	void Update ()
	{
		if (GameManager.instance.currentGameState == GameState.inGame) {
			//Shows this game's particular timer.
			timer = (100f - Time.time); 
			scoreLabel.text = timer.ToString ("f00");
			levelCountLabel.text = GameManager.instance.levelCount.ToString ();
			//levelCountLabel.text = GameManager.instance.highScore.ToString();
			if (timer > PlayerPrefs.GetFloat ("highscore", 1))
				highscoreLabel.text = GameManager.instance.highScore.ToString ();
		}
	}
}



