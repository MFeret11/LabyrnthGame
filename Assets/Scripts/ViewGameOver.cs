using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ViewGameOver : MonoBehaviour {

	public Text scoreLabel;
	public Text levelCountLabel;

	void Update() {
		if (GameManager.instance.currentGameState == GameState.inGame) {
			scoreLabel.text = Time.time.ToString("f0");
			levelCountLabel.text = GameManager.instance.highScore.ToString();
		}
	}
}



