using UnityEngine;
using System.Collections;

public class DestWall : MonoBehaviour {

	public GameObject destParent;
	
	// Update is called once per frame
	void Update () {
		if (destParent == null) {
			Destroy (gameObject);
		}
	}
}
