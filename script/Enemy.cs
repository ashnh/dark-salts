using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	// very possible need to change in the future

	// boolean for invisibility time
	bool entered;

	// damages on enter
	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Player" && !entered) {
			other.GetComponentInParent <Player> ().health = 0;
			entered = true;
		}
	}

	// resets on exit
	void OnTriggerExit2D (Collider2D other) {
		if (other.tag == "Player") {
			entered = false;
		}
	}
}
