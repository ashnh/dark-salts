using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	// player object
	public GameObject player;

	bool inBox;

	// left, right, up, and down constraints
	public float groundLevelElevation;
	public float roofLevelElevation;
	public float leftWallConstraint;
	public float rightWallConstraint;

	public float groundIn;
	public float roofIn;
	public float leftIn;
	public float rightIn;

	// floats for camera positions
	float cameraX;
	float cameraY;
	
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

		if (player.transform.position.y > groundIn && player.transform.position.y < roofIn && player.transform.position.x > leftIn && player.transform.position.x < rightIn) {
			inBox = true;
		} else {
			inBox = false;
		}

		// camera positioning
		if (inBox) {
			transform.position = new Vector3 (cameraX, cameraY, -20);
		}
	}
}
