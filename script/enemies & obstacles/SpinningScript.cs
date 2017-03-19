using UnityEngine;
using System.Collections;

public class SpinningScript : MonoBehaviour {

	public float rotationSpeed;
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0, 0, rotationSpeed);
	}
}
