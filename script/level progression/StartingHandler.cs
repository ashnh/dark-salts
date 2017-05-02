using UnityEngine;
using System.Collections;

public class StartingHandler : MonoBehaviour {

	public Player player;

	public GameObject barrier;
	public DoorScript door;

	public float timeMoving;

	float currentTime;

	int loaded;

	// Use this for initialization
	void Start () {
		loaded = 0;
		currentTime = 0;

		while (PlayerPrefs.GetInt ("level " + loaded + " loaded") == 1) {
			loaded++;
		}


		door.levelInt = loaded;

	}
	
	// Update is called once per frame
	void Update () {
		currentTime = Time.timeSinceLevelLoad;
		if (currentTime < timeMoving) {
			player.SetMoveLeft (true);
		} else {
			player.SetMoveLeft (false);
			barrier.SetActive (true);
		}
	}

}
