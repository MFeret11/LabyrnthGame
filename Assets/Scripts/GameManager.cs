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
	public Canvas newHighScoreCanvas;

	//Tracks Highest Level and Time 
	public int highScore = 1;
	public int levelCount = 1;
	public float timer;


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

		//sets gametime & timer
		//Time.time;
		Time.timeScale = 1.0f;
		timer = (100f - Time.timeSinceLevelLoad);
		//timer = (100f - Time.time);

		highScore = PlayerPrefs.GetInt ("highscore", highScore);
		Debug.Log ("start: " + highScore);

		//De-Activates all floor triggers
		GameObject[] floors = GameObject.FindGameObjectsWithTag("Floor");
		foreach (var f in floors) {	
			f.GetComponent<MeshCollider> ().isTrigger = false;
			f.GetComponent<MeshCollider> ().convex = false;
		}
	}
				
	//called when player dies
	public void GameOver() {
		SetGameState(GameState.gameOver);
		levelCount = 1;
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
			newHighScoreCanvas.enabled = false;
		} else if (newGameState == GameState.gameOver) {
			//setup Unity scene for gameOver state
			menuCanvas.enabled = false;
			inGameCanvas.enabled = false;
			gameOverCanvas.enabled = true;
			 if(instance.highScore == instance.levelCount)
				newHighScoreCanvas.enabled = true;
		}
		currentGameState = newGameState;
	}
		
	// Update is called once per frame
	void Update () {
	}

	public void HighScore() {
		highScore ++;
	}
	public void LevelCount(){
		levelCount++;
		//int i = leve
		//int j;
		if(highScore <= levelCount)
			HighScore ();
		if (levelCount >= 6) {
			GameOver();
			Time.timeScale = 0.4f;
		}
	}

}
