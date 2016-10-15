using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	// player object
	public GameObject player;

	// left, right, up, and down constraints
	public float groundLevelElevation;
	public float roofLevelElevation;
	public float leftWallConstraint;
	public float rightWallConstraint;

	// floats for camera positions
	float cameraX;
	float cameraY;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// y camera constraints
		if (player.transform.position.y < groundLevelElevation) {
			cameraY = groundLevelElevation;
		} else if (player.transform.position.y > roofLevelElevation) {
			cameraY = roofLevelElevation;
		} else {
			cameraY = player.transform.position.y;
		}
		// x camera constraints
		if (player.transform.position.x < leftWallConstraint) {
			cameraX = leftWallConstraint;
		} else if (player.transform.position.x > rightWallConstraint) {
			cameraX = rightWallConstraint;
		} else {
			cameraX = player.transform.position.x;
		}
		// camera positioning
		transform.position = new Vector3 (cameraX, cameraY, -10);
	}
}
