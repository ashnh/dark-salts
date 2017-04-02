using UnityEngine;
using System.Collections;

public class ChackpointScript : MonoBehaviour {

	public Sprite off;
	public Sprite on;

	bool isOn;

	// Use this for initialization
	void Start () {
		isOn = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (isOn) {
			GetComponent <SpriteRenderer> ().sprite = on;
		} else {
			GetComponent <SpriteRenderer> ().sprite = off;
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Player") {
			PlayerPrefs.SetFloat ("checkY", transform.position.y);
			PlayerPrefs.SetFloat ("checkX", transform.position.x);
			isOn = true;
		}
	}

}
