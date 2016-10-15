using UnityEngine;
using System.Collections;

public class IteractionBox : MonoBehaviour {
	// false for left, true for right
	public bool leftOrRight;

	// enemy list initialization (might want to move to void start)
	ArrayList enemies = new ArrayList();

	int enemiesTouching;

	// Update is called once per frame
	void Update () {
		// determination of right or left box
		if (!leftOrRight && (Input.GetMouseButtonDown (0) || Input.GetKeyDown (KeyCode.LeftArrow))) {
			//destroys all enemies in the arraylist
			foreach (Collider2D enemy in enemies) {
				// prevents null entries from stopping the loop
				if (enemy != null) {
					if (enemy.IsTouching (GetComponentInParent <Collider2D> ())) {
						enemiesTouching++;
					}
					Destroy (enemy.gameObject);
				}
			}
			// clears list for next click
			enemies.Clear ();

			GetComponentInParent <Player> ().triggersIn -= GetComponentInParent <Player> ().leftDestructibleTriggersIn;
			GetComponentInParent <Player> ().triggersIn -= GetComponentInParent <Player> ().bothDestructibleTriggersIn;
			GetComponentInParent <Player> ().bothDestructibleTriggersIn = 0;
			GetComponentInParent <Player> ().leftDestructibleTriggersIn = 0;
		} else if (leftOrRight && (Input.GetMouseButtonDown (1) || Input.GetKeyDown (KeyCode.RightArrow))) {
			//destroys all enemies in the arraylist
			foreach (Collider2D enemy in enemies) {
				// prevents null entries from stopping the loop
				if (enemy != null) {
					if (enemy.IsTouching (GetComponentInParent <Collider2D> ())) {
						enemiesTouching++;
					}
					Destroy (enemy.gameObject);
				}
			}
			// clears list for next click
			enemies.Clear ();

			GetComponentInParent <Player> ().triggersIn -= GetComponentInParent <Player> ().rightDestructibleTriggersIn;
			GetComponentInParent <Player> ().triggersIn -= GetComponentInParent <Player> ().bothDestructibleTriggersIn;
			GetComponentInParent <Player> ().bothDestructibleTriggersIn = 0;
			GetComponentInParent <Player> ().rightDestructibleTriggersIn = 0;

		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		// enemy collision detection
		if (other.tag == "enemy") {
			enemies.Add (other);
		}
		if (other.tag == "leftEnemy" && !leftOrRight) {
			enemies.Add (other);
		} else if (other.tag == "rightEnemy" && leftOrRight) {
			enemies.Add (other);
		}
		GetComponentInParent <Player> ().triggersIn --;
		if (other.tag == "enemy" ) {
			GetComponentInParent <Player> ().bothDestructibleTriggersIn--;
		}
		if (other.tag == "rightEnemy") {
			GetComponentInParent <Player> ().rightDestructibleTriggersIn--;
		}
		if (other.tag == "leftEnemy") {
			GetComponentInParent <Player> ().leftDestructibleTriggersIn--;
		}
		if (other.tag == "sliderObject") {
			GetComponentInParent <Player> ().sliderObjectsIn--;
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		GetComponentInParent <Player> ().triggersIn ++;
		if (other.tag == "enemy" ) {
			GetComponentInParent <Player> ().bothDestructibleTriggersIn++;
		}
		if (other.tag == "rightEnemy") {
			GetComponentInParent <Player> ().rightDestructibleTriggersIn++;
		}
		if (other.tag == "leftEnemy") {
			GetComponentInParent <Player> ().leftDestructibleTriggersIn++;
		}
		if (other.tag == "sliderObject") {
			GetComponentInParent <Player> ().sliderObjectsIn++;
		}
	}

}
