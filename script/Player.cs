using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float jumpSpeed;
	public float runSpeed;

	public int health;

	public int triggersIn;
	public int leftDestructibleTriggersIn;
	public int rightDestructibleTriggersIn;
	public int bothDestructibleTriggersIn;
	public int sliderObjectsIn;

	public int levelInt;

	public int exitTriggersIn;
	public int levelTo;

	public float groundSpeed;

	// Use this for initialization
	void Start () {
		triggersIn = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	// movement
		// jump movement
		if (Input.GetKeyDown (KeyCode.W)) {
			if (triggersIn > 0) {
				GetComponent <Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jumpSpeed);
			}
		}
		// left and right movement
		if (Input.GetKey (KeyCode.A)) {
			GetComponent <Rigidbody2D> ().velocity = new Vector2 (-runSpeed + groundSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		} else if (Input.GetKey (KeyCode.D)) {
			GetComponent <Rigidbody2D> ().velocity = new Vector2 (runSpeed + groundSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		} else {
			GetComponent <Rigidbody2D> ().velocity = new Vector2 (groundSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		}

		// prototype respawn
		if (health <= 0 || Input.GetKey (KeyCode.R)) {
			UnityEngine.SceneManagement.SceneManager.LoadScene (levelInt);
		}

		// exit use
		if (exitTriggersIn > 0 && Input.GetKeyDown (KeyCode.Space)) {
			UnityEngine.SceneManagement.SceneManager.LoadScene (levelTo);
		}

		if (Input.GetKey (KeyCode.R)) {
			UnityEngine.SceneManagement.SceneManager.LoadScene (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
		}


	}

	// jump tally system (somewhat overcomplicated but prevents large mess ups)
	void OnTriggerEnter2D (Collider2D other) {
		// prevents wall climbing
		if (other.tag != "wall") {
			triggersIn++;
		}
		// tallies enemy + type
		if (other.tag == "leftEnemy") {
			leftDestructibleTriggersIn++;
		}
		if (other.tag == "rightEnemy") {
			rightDestructibleTriggersIn++;
		}
		if (other.tag == "enemy") {
			bothDestructibleTriggersIn++;
		}
		if (other.tag == "sliderObject") {
			sliderObjectsIn++;
		}
		// exit detection
		if (other.tag == "exit") {
			exitTriggersIn++;
			levelTo = other.GetComponentInParent <DoorScript> ().levelInt;
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		// prevents wall climbing
		if (other.tag != "wall") {
			triggersIn--;
		}
		if (other.tag == "leftEnemy") {
			leftDestructibleTriggersIn--;
		}
		if (other.tag == "rightEnemy") {
			rightDestructibleTriggersIn--;
		}
		if (other.tag == "enemy") {
			bothDestructibleTriggersIn--;
		}
		if (other.tag == "sliderObject") {
			sliderObjectsIn--;
		}
		// exit detection
		if (other.tag == "exit") {
			exitTriggersIn--;
		}
	}
	
}
