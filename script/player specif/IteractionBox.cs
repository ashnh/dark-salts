using UnityEngine;
using System.Collections;

public class IteractionBox : MonoBehaviour {

	public JumpBox jumpBox;

	// false for left, true for right
	public bool leftOrRight;

	// enemy list initialization
	ArrayList enemies;

	float firstTime;

	void Start() {
		enemies = new ArrayList();
		firstTime = -100f;
	}

	// Update is called once per frame
	void Update () {
		// determination of right or left box
		if (!leftOrRight && (Input.GetKeyDown (KeyCode.LeftArrow))) {
			//destroys all enemies in the arraylist
			foreach (Collider2D enemy in enemies) {
				// prevents null entries from stopping the loop
				if (enemy != null) {
					Destroy (enemy.gameObject);
				}
			}

			GetComponent <SpriteRenderer> ().color = new Color (255f, 0f, 0f, 0.38f);

			firstTime = Time.timeSinceLevelLoad;

			// clears list for next click
			enemies.Clear ();
				
		} else if (leftOrRight && (Input.GetKeyDown (KeyCode.RightArrow))) {
			//destroys all enemies in the arraylist
			foreach (Collider2D enemy in enemies) {
				// prevents null entries from stopping the loop
				if (enemy != null) {
					Destroy (enemy.gameObject);
				}
			}
				
			GetComponent <SpriteRenderer> ().color = new Color (0f, 255f, 255f, 0.38f);

			firstTime = Time.timeSinceLevelLoad;

			// clears list for next click
			enemies.Clear ();

		} else if (firstTime < Time.timeSinceLevelLoad - 0.1f) {
			GetComponent <SpriteRenderer> ().color = new Color (255f, 255f, 255f, 0.38f);
		}

	}

	void OnTriggerEnter2D (Collider2D other) {
		// enemy collision detection
		if (other.tag == "enemy") {
			enemies.Add (other);
			other.GetComponentInParent <DestAnims> ().setOn ();
		}
		if (other.tag == "leftEnemy" && !leftOrRight) {
			enemies.Add (other);
			other.GetComponentInParent <DestAnims> ().setOn ();
		} else if (other.tag == "rightEnemy" && leftOrRight) {
			enemies.Add (other);
			other.GetComponentInParent <DestAnims> ().setOn ();
		}

	}


}
