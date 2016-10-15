using UnityEngine;
using System.Collections;

public class SliderEnemy : MonoBehaviour {
	// movestates enum
	public enum moveStates {
		LEFT,
		RIGHT,
		NONE
	}

	// false for left, true for right
	public bool startLeftOrRight;

	//speed
	public float movingSpeed;

	// state initialization (might want to put in void Start)
	public moveStates state = new moveStates ();

	// Use this for initialization
	void Start () {
		//initial direction decision
		if (startLeftOrRight) {
			state = moveStates.RIGHT;
		} else {
			state = moveStates.LEFT;
		}
	}
	
	// Update is called once per frame
	void Update () {
		// movestate to velocity
		if (state == moveStates.LEFT) {
			GetComponent <Rigidbody2D> ().velocity = new Vector2 ( -movingSpeed, 0);
		} else {
			GetComponent <Rigidbody2D> ().velocity = new Vector2 ( movingSpeed, 0);
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		// players & enemies don't bounce (possible change needed)
		if (other.tag != "interactionBox") {
			// turns slider (need to flip sprite, possible change needed)
			transform.Rotate (0, 0, 180);
			// direction decision
			if (state == moveStates.LEFT) {
				state = moveStates.RIGHT;
			} else {
				state = moveStates.LEFT;
			}
		}
			
	}

	// might need later. remove if not
	void OnTriggerExit2D (Collider2D other) {
		
	}
}
