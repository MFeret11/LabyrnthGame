using UnityEngine;
using System.Collections;

public class EnterWinHole : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		
		Debug.Log ("Player encounters win hole");
		GameManager.instance.HighScore();

		this.GetComponentInParent<MeshCollider> ().convex = true;
		this.GetComponentInParent<MeshCollider> ().isTrigger = true;


	}

}
