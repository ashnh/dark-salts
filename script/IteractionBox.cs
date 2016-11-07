using UnityEngine;
using System.Collections;

public class IteractionBox : MonoBehaviour {

	public JumpBox jumpBox;

	// false for left, true for right
	public bool leftOrRight;

	// enemy list initialization (might want to move to void start)
	ArrayList enemies = new ArrayList();

	// Update is called once per frame
	void Update () {
		// determination of right or left box
		if (!leftOrRight && (Input.GetMouseButtonDown (0) || Input.GetKeyDown (KeyCode.LeftArrow))) {
			//destroys all enemies in the arraylist
			foreach (Collider2D enemy in enemies) {
				// prevents null entries from stopping the loop
				if (enemy != null) {
					Destroy (enemy.gameObject);
				}
			}
			// clears list for next click
			enemies.Clear ();

			foreach (Collider2D collider in jumpBox.collidersTouching) {
				if (collider == null) {
					jumpBox.collidersTouching.Remove (collider);
				}
			}
				
		} else if (leftOrRight && (Input.GetMouseButtonDown (1) || Input.GetKeyDown (KeyCode.RightArrow))) {
			//destroys all enemies in the arraylist
			foreach (Collider2D enemy in enemies) {
				// prevents null entries from stopping the loop
				if (enemy != null) {
					Destroy (enemy.gameObject);
				}
			}
			// clears list for next click
			enemies.Clear ();

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

	}

	void OnTriggerExit2D (Collider2D other) {

	}

}
