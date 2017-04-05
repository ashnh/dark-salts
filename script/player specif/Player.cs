using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public JumpBox jumpBox;

	public float jumpSpeed;
	public float runSpeed;

	public int health;

	public int levelInt;

	// works exits and et c.
	public int exitTriggersIn;
	public int levelTo;

	// speed of the floating platform
	public float groundSpeedX;

	void Start () {
		if (PlayerPrefs.GetFloat ("checkY") != 0 && PlayerPrefs.GetFloat ("checkX") != 0) {
			transform.position = new Vector3 (PlayerPrefs.GetFloat("checkX"), PlayerPrefs.GetFloat("checkY"), 0);
		}
	}

	// Update is called once per frame
	void Update () {

	// movement
		// jump movement
		if (Input.GetKeyDown (KeyCode.W)) {
			if (jumpBox.collidersTouching.Count > 0) {
				GetComponent <Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jumpSpeed);
			}
		}
		// left and right movement
		if (Input.GetKey (KeyCode.A)) {
			GetComponent <Rigidbody2D> ().velocity = new Vector2 (-runSpeed + groundSpeedX, GetComponent<Rigidbody2D> ().velocity.y);
		} else if (Input.GetKey (KeyCode.D)) {
			GetComponent <Rigidbody2D> ().velocity = new Vector2 (runSpeed + groundSpeedX, GetComponent<Rigidbody2D> ().velocity.y);
		} else {
			GetComponent <Rigidbody2D> ().velocity = new Vector2 (groundSpeedX, GetComponent<Rigidbody2D> ().velocity.y);
		}

		//respawn
		if (health <= 0 || Input.GetKey (KeyCode.R)) {
			UnityEngine.SceneManagement.SceneManager.LoadScene (UnityEngine.SceneManagement.SceneManager.GetActiveScene ().buildIndex);
		}

		// exit use
		if (exitTriggersIn > 0 && (Input.GetKeyDown (KeyCode.Space))) {
			PlayerPrefs.SetInt ("level " + UnityEngine.SceneManagement.SceneManager.GetActiveScene ().buildIndex.ToString() + " loaded", 1);
			PlayerPrefs.SetFloat ("checkY", 0F);
			PlayerPrefs.SetFloat ("checkX", 0F);
		}

		if (Input.GetKey (KeyCode.C)) {
			PlayerPrefs.SetFloat ("checkY", 0);
			PlayerPrefs.SetFloat ("checkX", 0);
		}


	}

	void OnTriggerEnter2D (Collider2D other) {
		// exit detection
		if (other.tag == "exit") {
			exitTriggersIn++;
			levelTo = other.GetComponentInParent <DoorScript> ().levelInt;
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		// exit detection
		if (other.tag == "exit") {
			exitTriggersIn--;
		}
	}
	
}
