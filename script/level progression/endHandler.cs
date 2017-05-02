using UnityEngine;
using System.Collections;

public class endHandler : MonoBehaviour {

	public GameObject player;
	public GameObject camera;

	public float removeControlPoint;

	public float stopPoint;

	float currentTime;

	public Sprite one;
	public Sprite two;
	public Sprite three;
	public Sprite four;
	public Sprite five;
	public Sprite six;
	public Sprite seven;

	bool hasMoved;

	// Use this for initialization
	void Start () {
		currentTime = -1;
		hasMoved = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (player.transform.position.x > removeControlPoint && player.transform.position.x < stopPoint) {
			player.GetComponent <Player> ().SetMoveRight (true);
		} else {
			player.GetComponent <Player> ().SetMoveRight (false);
		}

		if (player.transform.position.x < stopPoint + 1 && player.transform.position.x > stopPoint - 1) {
			hasMoved = true;
			player.GetComponent <Animator> ().enabled = false;
		}

		if (hasMoved && currentTime == -1) {
			currentTime = Time.timeSinceLevelLoad;
		}

		Debug.Log (hasMoved);

		if (currentTime < Time.timeSinceLevelLoad - 12F && currentTime != -1) {
			camera.transform.position = new Vector3 (1000, 1000, -20);
		} else if (currentTime < Time.timeSinceLevelLoad - 11F && currentTime != -1) {
			player.GetComponent <SpriteRenderer> ().sprite = seven;
		} else if (currentTime < Time.timeSinceLevelLoad - 10F && currentTime != -1) {
			player.GetComponent <SpriteRenderer> ().sprite = six;
		} else if (currentTime < Time.timeSinceLevelLoad - 9F && currentTime != -1) {
			player.GetComponent <SpriteRenderer> ().sprite = five;
		} else if (currentTime < Time.timeSinceLevelLoad - 8F && currentTime != -1) {
			player.GetComponent <SpriteRenderer> ().sprite = four;
		} else if (currentTime < Time.timeSinceLevelLoad - 7F && currentTime != -1) {
			player.GetComponent <SpriteRenderer> ().sprite = three;
		} else if (currentTime < Time.timeSinceLevelLoad - 6F && currentTime != -1) {
			player.GetComponent <SpriteRenderer> ().sprite = two;
		} else if (currentTime < Time.timeSinceLevelLoad - 5F && currentTime != -1) {
			player.GetComponent <SpriteRenderer> ().sprite = one;
		}

	}
}
