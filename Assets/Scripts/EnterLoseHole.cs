using UnityEngine;
using System.Collections;

public class EnterLoseHole : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		Debug.Log ("Player encounters lose hole");
		//pauses game
		Time.timeScale = 0.0f;
		GameManager.instance.GameOver ();
		//Display UI

		//PlayerController.Player.dead
		//Destroy(other.gameObject);
		//GameManager.RestartLevelOne
	}
}
