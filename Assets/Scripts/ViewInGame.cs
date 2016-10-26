using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ViewInGame : MonoBehaviour {

	public Text scoreLabel;
	public Text levelCountLabel;
	public Text highscoreLabel;
	public float timer;

	void Update() {
		if (GameManager.instance.currentGameState == GameState.inGame) {
			//Shows this game's particular timer.
			timer = (100f - Time.time); 
			scoreLabel.text = timer.ToString("f00");
			if (timer <= 0.0f)
				GameManager.instance.SetGameState (GameState.gameOver);
			levelCountLabel.text = GameManager.instance.levelCount.ToString();
			highscoreLabel.text = PlayerPrefs.GetInt ("highscore", GameManager.instance.highScore).ToString("f0");
		}
	}
}



