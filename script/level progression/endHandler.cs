using UnityEngine;
using System.Collections;

public class endHandler : MonoBehaviour {

	public GameObject player;
	public GameObject camera;
	public GameObject barriers;
	public SpriteRenderer eye;

	public Sprite open;
	public Sprite closed;

	public GameObject dummyPlayer;

	public float spawnX;
	public float spawnY;
	public float spawnZ;

	public float removeControlPoint;

	public float stopPoint;

	public float stopTime;

	float currentTime;
	float fromStopTime;

	GameObject inSceneDummyPlayer;

	public float timeUntilBlack;
	float timeToBlack;

	//bool hasMoved;

	// Use this for initialization
	void Start () {
		currentTime = -1;
		fromStopTime = -1;
		timeToBlack = -1;
		//hasMoved = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (player.transform.position.x > removeControlPoint && player.transform.position.x < stopPoint) {
			player.GetComponent <Player> ().SetMoveRight (true);
			fromStopTime = Time.timeSinceLevelLoad;
			player.GetComponent <Player> ().setControl (false);
		} else {
			player.GetComponent <Player> ().SetMoveRight (false);
		}

		if (player.transform.position.x < stopPoint + 0.2 && player.transform.position.x > stopPoint - 0.2) {
			eye.sprite = closed;
		}

		if (fromStopTime + stopTime < Time.timeSinceLevelLoad && fromStopTime != -1) {
			barriers.SetActive (false);
			player.GetComponent <Player> ().SetMoveRight (true);
		}

		if (inSceneDummyPlayer != null) {
			inSceneDummyPlayer.GetComponent <Player> ().SetMoveLeft (true);
			eye.sprite = open;
		}

		if (timeToBlack != -1 && timeToBlack + timeUntilBlack < Time.timeSinceLevelLoad) {
			camera.transform.position = new Vector3 (100, 100, -20);
		}

	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag != "jumpBox" && inSceneDummyPlayer == null) {
			inSceneDummyPlayer = (GameObject) Instantiate (dummyPlayer, new Vector3 (spawnX, spawnY, spawnZ), dummyPlayer.transform.rotation);
			timeToBlack = Time.timeSinceLevelLoad;
			//eye.sprite = open;
			//inSceneDummyPlayer.GetComponent <Rigidbody2D> ().velocity = new Vector2 (-12, inSceneDummyPlayer.GetComponent <Rigidbody2D> ().velocity.y);
		}
	}
}
