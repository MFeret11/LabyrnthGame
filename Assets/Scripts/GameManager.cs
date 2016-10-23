using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public enum GameState {
	menu,
	inGame,
	gameOver,
}
	
public class GameManager : MonoBehaviour {

	public static GameManager instance;
	public GameState currentGameState = GameState.menu;

	public Canvas menuCanvas;
	public Canvas inGameCanvas;
	public Canvas gameOverCanvas;

	public int highScore = 0;

	void Awake() {
		instance = this;
	}

	void Start() {
		currentGameState = GameState.menu;
	}

	//called to start the game
	public void StartGame() {
		
		PlayerController.instance.StartGame();
		SetGameState(GameState.inGame);
		Time.timeScale = 1.0f;
	}

	//called when player dies
	public void GameOver() {
		SetGameState(GameState.gameOver);
	}
		
	//called when player decide to go back to the menu
	public void BackToMenu() {
		SetGameState(GameState.menu);
	}

	public void SetGameState (GameState newGameState) {

		if (newGameState == GameState.menu) {
			//setup Unity scene for menu state
			menuCanvas.enabled = true;
			inGameCanvas.enabled = false;
			gameOverCanvas.enabled = false;
		} else if (newGameState == GameState.inGame) {
			//setup Unity scene for inGame state
			menuCanvas.enabled = false;
			inGameCanvas.enabled = true;
			gameOverCanvas.enabled = false;
		} else if (newGameState == GameState.gameOver) {
			//setup Unity scene for gameOver state
			menuCanvas.enabled = false;
			inGameCanvas.enabled = false;
			gameOverCanvas.enabled = true;
		}
		currentGameState = newGameState;
	}
		
	// Update is called once per frame
	void Update () {
		//if (Input.GetButtonDown("s")) {
		//	StartGame();
		//}
	}
	public void HighScore() {
		highScore ++;
		Debug.Log (highScore);
	}

}
