using UnityEngine;
using System.Collections;

public class DestAnims : MonoBehaviour {

	public Sprite off;
	public Sprite on;
	public Sprite down;

	bool isOn;
	bool isDown;

	public void setOn() {
		isOn = true;
	}

	public void setDown() {
		isDown = true;
	}

	// Use this for initialization
	void Start () {
		isOn = false;
		isDown = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (isOn) {
			GetComponent <SpriteRenderer> ().sprite = on;
		} else if (isDown) {
			GetComponent <SpriteRenderer> ().sprite = down;
		} else {
			GetComponent <SpriteRenderer> ().sprite = off;
		}
	}
}
