using UnityEngine;
using System.Collections;

public class HubTwoScript : MonoBehaviour {

	public GameObject map;
	public GameObject gate;

	public Sprite oneTwoThree;
	public Sprite oneTwo;
	public Sprite oneThree;
	public Sprite TwoThree;
	public Sprite one;
	public Sprite two;
	public Sprite three;
	public Sprite zero;

	public int levelOneNumber;
	public int levelTwoNumber;
	public int levelThreeNumber;

	bool lOneDone;
	bool lTwoDone;
	bool lThreeDone;

	// Use this for initialization
	void Start () {
		lOneDone = 0 < PlayerPrefs.GetInt ("level " + levelOneNumber + " loaded");
		lTwoDone = 0 < PlayerPrefs.GetInt ("level " + levelTwoNumber + " loaded");
		lThreeDone = 0 < PlayerPrefs.GetInt ("level " + levelThreeNumber + " loaded");
		if (lOneDone) {
			if (lTwoDone) {
				if (lThreeDone) {
					//load 1,2,3 & open gate
					map.GetComponent <SpriteRenderer> ().sprite = oneTwoThree;
					Destroy (gate);
				} else {
					//load 1,2
					map.GetComponent <SpriteRenderer> ().sprite = oneTwo;
				}
			} else {
				if (lThreeDone) {
					//load 1,3
					map.GetComponent <SpriteRenderer> ().sprite = oneThree;
				} else {
					//load 1
					map.GetComponent <SpriteRenderer> ().sprite = one;
				}
			}
		} else {
			if (lTwoDone) {
				if (lThreeDone) {
					//load 2,3
					map.GetComponent <SpriteRenderer> ().sprite = TwoThree;
				} else {
					//load 2
					map.GetComponent <SpriteRenderer> ().sprite = two;
				}
			} else {
				if (lThreeDone) {
					//load 3
					map.GetComponent <SpriteRenderer> ().sprite = three;
				} else {
					//load 0
					map.GetComponent <SpriteRenderer> ().sprite = zero;
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			PlayerPrefs.SetInt ("level " + levelOneNumber + " loaded", 0);
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			PlayerPrefs.SetInt ("level " + levelTwoNumber + " loaded", 0);
		}
		if (Input.GetKeyDown (KeyCode.Alpha3)) {
			PlayerPrefs.SetInt ("level " + levelThreeNumber + " loaded", 0);
		}
		if (Input.GetKeyDown (KeyCode.Alpha4)) {
			PlayerPrefs.SetInt ("level " + levelOneNumber + " loaded", 1);
		}
		if (Input.GetKeyDown (KeyCode.Alpha5)) {
			PlayerPrefs.SetInt ("level " + levelTwoNumber + " loaded", 1);
		}
		if (Input.GetKeyDown (KeyCode.Alpha6)) {
			PlayerPrefs.SetInt ("level " + levelThreeNumber + " loaded", 1);
		}
	}
}
