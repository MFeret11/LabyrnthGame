using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ViewGameOver : MonoBehaviour
{

	public Text scoreLabel;
	public Text levelCountLabel;
	public Text highscoreLabel;
	public float timer;
	public float holder;


	void Update ()
	{
		if (GameManager.instance.currentGameState == GameState.inGame) {
			//Shows this game's particular timer.
			timer = ((100f + holder) - Time.time); 
			scoreLabel.text = timer.ToString ("f00");
			levelCountLabel.text = GameManager.instance.levelCount.ToString ();
			highscoreLabel.text = GameManager.instance.highScore.ToString ();
		}
		if (GameManager.instance.currentGameState == GameState.gameOver || GameManager.instance.currentGameState == GameState.menu)
		{
			holder = Time.time; //fixes UI timer bug
		}
	}

}



