using UnityEngine;
using System.Collections;

public class MobilePlatform : MonoBehaviour {

	public Collider2D player;

	public GameObject Parent;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

		GetComponent <Rigidbody2D> ().velocity = Parent.GetComponent <Rigidbody2D> ().velocity;

		//handles player groundspeed
		if (gameObject.GetComponent <Collider2D> ().IsTouching (player)) {
			
			player.gameObject.GetComponent <Player> ().groundSpeedX = GetComponent <Rigidbody2D> ().velocity.x;

		} else if (player.gameObject.GetComponentInChildren<JumpBox> ().sliders <= 0) {
			
			player.gameObject.GetComponent <Player> ().groundSpeedX = 0;

		}

	}

}
