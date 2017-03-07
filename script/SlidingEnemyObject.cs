using UnityEngine;
using System.Collections;

public class SlidingEnemyObject : MonoBehaviour {
	// true : right; false: left
	public bool leftOrRight;

	public float movingSpeedX;

	public float leftConstraint;
	public float rightContraint;


	public Collider2D player;

	float currentRotation = 0;

	// Use this for initialization
	void Start () {
		
	}

	void rotate (float targetRotation) {
		gameObject.transform.Rotate (0, 0, 360 + currentRotation + targetRotation);
		currentRotation = targetRotation;
	}
	
	// Update is called once per frame

	public void Update () {

		// decides horizontal direction
		if (transform.position.x < leftConstraint) {
			leftOrRight = true;
		} else if (transform.position.x > rightContraint) {
			leftOrRight = false;
		}

		if (leftOrRight) {
			GetComponent <Rigidbody2D> ().velocity = new Vector2 (movingSpeedX, GetComponent <Rigidbody2D> ().velocity.y);
			rotate (180);
		} else {
			rotate (0);
			GetComponent <Rigidbody2D> ().velocity = new Vector2 (-movingSpeedX, GetComponent <Rigidbody2D> ().velocity.y);
		}

		if (gameObject.GetComponent <Collider2D> ().IsTouching (player)) {
			player.gameObject.GetComponent <Player> ().groundSpeedX = GetComponent <Rigidbody2D> ().velocity.x;
		} else if (player.gameObject.GetComponentInChildren<JumpBox> ().sliders <= 0) {
			player.gameObject.GetComponent <Player> ().groundSpeedX = 0;
		}

	}
}
