using UnityEngine;
using System.Collections;

public class EnterLoseHole : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		Debug.Log ("Player encounters lose hole");
		//pauses game
		Time.timeScale = 0.0f;

		//Display UI
		GameManager.instance.GameOver ();

		//PlayerController.Player.dead
		//Destroy(other.gameObject);
		//GameManager.RestartLevelOne

	}
}
