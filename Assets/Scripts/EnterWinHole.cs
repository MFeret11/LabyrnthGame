using UnityEngine;
using System.Collections;

public class EnterWinHole : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		Debug.Log ("Player encounters win hole");
		GameManager.instance.LevelCount();
		//updates speed and time.
		PlayerController.instance.speed +=2.2f;
		this.GetComponentInParent<MeshCollider> ().convex = true;
		this.GetComponentInParent<MeshCollider> ().isTrigger = true;
	}
}
