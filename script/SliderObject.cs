using UnityEngine;
using System.Collections;

public class SliderObject : MonoBehaviour {
	// true : right; false: left
	public bool leftOrRight;

	public float movingSpeed;

	public float leftConstraint;
	public float rightContraint;

	public Collider2D player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position.x < leftConstraint) {
			leftOrRight = true;
		} else if (transform.position.x > rightContraint) {
			leftOrRight = false;
		}

		if (leftOrRight) {
			GetComponent <Rigidbody2D> ().velocity = new Vector2 (movingSpeed, 0);
		} else {
			GetComponent <Rigidbody2D> ().velocity = new Vector2 (-movingSpeed, 0);
		}

		if (gameObject.GetComponent <Collider2D> ().IsTouching (player)) {
			player.gameObject.GetComponent <Player> ().groundSpeed = GetComponent <Rigidbody2D> ().velocity.x;
		} else if (player.gameObject.GetComponentInChildren<JumpBox> ().sliders <= 0) {
			player.gameObject.GetComponent <Player> ().groundSpeed = 0;
		}

	}

	void OnTriggerEnter2D (Collider2D other) {

	}

	void OnTriggerExit2D (Collider2D other) {

	}
}
