using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ViewInGame : MonoBehaviour {

	public Text scoreLabel;
	public Text levelCountLabel;
	public Text highscoreLabel;


	void Update() {
		if (GameManager.instance.currentGameState == GameState.inGame) {
			float timer = (100f - Time.time); 
			scoreLabel.text = (100f - Time.time).ToString("f00");
			if (timer == 0f)
				GameManager.instance.SetGameState (GameState.gameOver);
			levelCountLabel.text = GameManager.instance.highScore.ToString();
			highscoreLabel.text = PlayerPrefs.GetFloat("highscore", 0).ToString("f0");
		}
	}
}



