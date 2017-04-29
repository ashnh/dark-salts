using UnityEngine;
using System.Collections;

public class StartingHandler : MonoBehaviour {

	public Player player;

	public GameObject barrier;
	public DoorScript door;

	int loaded;

	// Use this for initialization
	void Start () {
		loaded = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag != "interactionBox" && other.tag != "jumpBox" && other.tag == "Player") {
			Destroy (barrier);
		}

		while (PlayerPrefs.GetInt ("level " + loaded + " loaded") == 1) {
			loaded++;
		}
		door.levelInt = loaded;

	}
}
