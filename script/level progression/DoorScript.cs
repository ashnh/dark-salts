using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {

	int players;
	float firstTime;

	public bool autoTurnOn;

	// contains warp information
	public int levelInt;

	void Start () {
		players = 0;
		firstTime = -10000;
	}

	void Update() {
		if (players > 0 && (Input.GetKey (KeyCode.Space) || autoTurnOn) && firstTime == -10000) {
			firstTime = Time.timeSinceLevelLoad;
		}
		if (firstTime > Time.timeSinceLevelLoad - 2) {
			gameObject.transform.localScale = new Vector3 (transform.localScale.x + 1f, transform.localScale.y + 1f, 0f);
		} else if (firstTime != -10000) {
			UnityEngine.SceneManagement.SceneManager.LoadScene (levelInt);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			players++;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Player") {
			players--;
		}
	}

}
