using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ViewInGame : MonoBehaviour {

	public Text scoreLabel;
	public Text levelCountLabel;
	public Text highscoreLabel;


	void Update() {
		if (GameManager.instance.currentGameState == GameState.inGame) {
			scoreLabel.text = Time.time.ToString("f0");
			levelCountLabel.text = GameManager.instance.highScore.ToString();
			highscoreLabel.text = PlayerPrefs.GetFloat("highscore", 0).ToString("f0");
		}
	}
}



