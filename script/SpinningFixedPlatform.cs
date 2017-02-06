using UnityEngine;
using System.Collections;

public class SpinningFixedPlatform : MonoBehaviour {

	public float distFromPlayer;

	public GameObject player;

	public Collider2D jumpBox;

	public SpinningScript parent;

	bool inTrigger;

	public SpinningFixedPlatform () {
		inTrigger = false;
	}

	void Update () {
		transform.Rotate (0, 0, -parent.rotationSpeed);

		if (inTrigger && !(Input.GetKey (KeyCode.W))) {

			player.transform.position = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y + distFromPlayer, 0);

			player.GetComponent <Rigidbody2D> ().velocity = new Vector2 (0, 0);

		}

	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "jumpBox") {
			inTrigger = true;
		}

	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.tag == "jumpBox") {
			inTrigger = false;
		}
	}

}
