using UnityEngine;
using System.Collections;

public class FloatingPlatformHelp : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other) {

		if (other.gameObject.GetComponentInParent <Player> () != null && other.tag == "jumpBox") {
			other.gameObject.GetComponentInParent <Rigidbody2D> ().velocity = new Vector3 (0, 0, 0);
		}

	}

}
