using UnityEngine;
using System.Collections;

public class SliderObject : MonoBehaviour {
	// true : right; false: left
	public bool leftOrRight;

	public float movingSpeedX;

	public float leftConstraint;
	public float rightContraint;


	public Collider2D player;

	float initPosX;

	// Use this for initialization
	void Start () {
		initPosX = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {

		// decides horizontal direction
		if (transform.position.x < leftConstraint) {
			leftOrRight = true;
		} else if (transform.position.x > rightContraint) {
			leftOrRight = false;
		}

		// handles x velocity
		if (leftOrRight) {
			GetComponent <Rigidbody2D> ().velocity = new Vector2 (movingSpeedX, GetComponent <Rigidbody2D> ().velocity.y);
		} else {
			GetComponent <Rigidbody2D> ().velocity = new Vector2 (-movingSpeedX, GetComponent <Rigidbody2D> ().velocity.y);
		}

		if (movingSpeedX == 0) { 
			transform.position = new Vector2 (initPosX, transform.position.y);
		}

		//handles player groundspeed
		if (gameObject.GetComponent <Collider2D> ().IsTouching (player)) {
			player.gameObject.GetComponent <Player> ().groundSpeedX = GetComponent <Rigidbody2D> ().velocity.x;
			Debug.Log ("using velocity");
		} else if (player.gameObject.GetComponentInChildren<JumpBox> ().sliders <= 0) {
			player.gameObject.GetComponent <Player> ().groundSpeedX = 0;
			Debug.Log ("isn't touching");
		} else {
			Debug.Log ("thinks it's in other sliders");
		}

	}

}
