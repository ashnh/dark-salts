using UnityEngine;
using System.Collections;

public class SpinningFixedPlatform : MonoBehaviour {

	public SpinningScript parent;

	void Update () {
		transform.Rotate (0, 0, -parent.rotationSpeed);
	}
}
