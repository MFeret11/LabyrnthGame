using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public static PlayerController instance;

	public float speed;
	private Vector3 startingPosition;

	private Rigidbody rigidBody;

	void Awake() {
		instance = this;
		rigidBody = GetComponent<Rigidbody>();
		startingPosition = this.transform.position;

	}

	public void StartGame()
	{
		//rigidBody = GetComponent<Rigidbody>();
		this.transform.position = startingPosition;
	}

	void Update () {
		if (GameManager.instance.currentGameState == GameState.inGame) 
		{
			float moveHorizontal = Input.GetAxis ("Horizontal");
			float moveVertical = Input.GetAxis ("Vertical");

			Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

			rigidBody.AddForce (movement * speed);
		}
	}

	void FixedUpdate() {
		if (GameManager.instance.currentGameState == GameState.inGame) 
		{
			float moveHorizontal = Input.GetAxis ("Horizontal");
			float moveVertical = Input.GetAxis ("Vertical");

			Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

			rigidBody.AddForce (movement * speed);
		}
	}

	public void Kill() {
		GameManager.instance.GameOver();
		//check if highscore save if it is
		if (PlayerPrefs.GetFloat("highscore", 0) < (100-Time.time)) {
			//save new highscore
			PlayerPrefs.SetFloat("highscore", (100-Time.time));
		}
	}
		
}