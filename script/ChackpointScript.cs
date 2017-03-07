using UnityEngine;
using System.Collections;

public class ChackpointScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Player") {
			PlayerPrefs.SetFloat ("checkY", transform.position.y);
			PlayerPrefs.SetFloat ("checkX", transform.position.x);
		}
	}

}
