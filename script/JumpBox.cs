using UnityEngine;
using System.Collections;

public class JumpBox : MonoBehaviour {

	public ArrayList collidersTouching = new ArrayList();

	public bool triggersIn;
	public int sliders;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other) {

		collidersTouching.Add (other);

		if (other.tag == "sliderObject") {
			sliders++;
		}

	}

	void OnTriggerExit2D (Collider2D other) {

		if (other.tag == "sliderObject") {
			sliders--;
		}

		foreach (Collider2D collider in collidersTouching) {

			if (collider.Equals (other)) {
				collidersTouching.Remove (collider);
			}

		}

	}

}
