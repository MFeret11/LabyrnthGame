using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ViewGameOver : MonoBehaviour {

	public Text scoreLabel;
	public Text coinLabel;

	void Update() {
		if (GameManager.instance.currentGameState == GameState.inGame) {
			scoreLabel.text = PlayerController.instance.GetDistance().ToString("f0");
			coinLabel.text = GameManager.instance.highScore.ToString();
		}
	}
}



