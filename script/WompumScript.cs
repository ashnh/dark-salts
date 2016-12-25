using UnityEngine;
using System.Collections;

public class WompumScript : MonoBehaviour {

	// true for up, false for down
	public bool upOrDown;

	public GameObject player;

	public float stopPoint;
	public float startPoint;

	public float attackSpeed;
	public float recoilSpeed;

	public float proximityToReact;

	enum state { ATTACKING, RECOILING, INACTIVE};

	state theState;

	// Use this for initialization
	void Start () {
		theState = state.INACTIVE;
	}
	
	// Update is called once per frame
	void Update () {

		if ((player.transform.position.x <= transform.position.x + proximityToReact && player.transform.position.x >= transform.position.x - proximityToReact) && theState == state.INACTIVE) {
			theState = state.ATTACKING;
		}

		if (((transform.position.y >= stopPoint && upOrDown) || (transform.position.y <= stopPoint && !upOrDown)) && (theState == state.ATTACKING)) {
			theState = state.RECOILING;
		}

		if (((transform.position.y <= startPoint && upOrDown) || (transform.position.y >= startPoint && !upOrDown)) && (theState == state.RECOILING)) {
			theState = state.INACTIVE;
		}

		if (theState == state.INACTIVE) {
			GetComponent <Rigidbody2D> ().velocity = new Vector2 (0, 0);
		} else if (theState == state.ATTACKING) {
			GetComponent <Rigidbody2D> ().velocity = new Vector2 (0, attackSpeed);
		} else {
			GetComponent <Rigidbody2D> ().velocity = new Vector2 (0, recoilSpeed);
		}


	}
}
