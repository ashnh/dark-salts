using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public Animator anim;

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

	// false left, true right
	bool facing;

	bool moveLeft;
	bool moveRight;

	bool playerControls;

	int loaded;

	public void SetMoveLeft (bool set) {
		moveLeft = set;
	}

	public void SetMoveRight (bool set) {
		moveRight = set;
	}

	public void setControl (bool set) {
		playerControls = set;
	}

	void Start () {
		playerControls = true;
		loaded = 0;
		if (PlayerPrefs.GetFloat ("checkY") != 0 && PlayerPrefs.GetFloat ("checkX") != 0) {
			transform.position = new Vector3 (PlayerPrefs.GetFloat("checkX"), PlayerPrefs.GetFloat("checkY"), 0);
		}
		facing = true;
		moveLeft = false;
		moveRight = false;
	}

	// Update is called once per frame
	void Update () {

	// movement

		// left and right movement
		if ((Input.GetKey (KeyCode.A) && playerControls) || moveLeft) {
			GetComponent <Rigidbody2D> ().velocity = new Vector2 (-runSpeed + groundSpeedX, GetComponent<Rigidbody2D> ().velocity.y);
			facing = false;
		} else if ((Input.GetKey (KeyCode.D) && playerControls) || moveRight) {
			GetComponent <Rigidbody2D> ().velocity = new Vector2 (runSpeed + groundSpeedX, GetComponent<Rigidbody2D> ().velocity.y);
			facing = true;
		} else {
			GetComponent <Rigidbody2D> ().velocity = new Vector2 (groundSpeedX, GetComponent<Rigidbody2D> ().velocity.y);
		}

		if (Input.GetKey (KeyCode.LeftBracket)) {
			while (loaded <= 30) {
				loaded++;
				PlayerPrefs.SetInt ("level " + loaded + " loaded", 0);
			}
		}

		// jump movement
		if ((Input.GetKeyDown (KeyCode.W) && playerControls)) {
			if (jumpBox.collidersTouching.Count > 0) {
				GetComponent <Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jumpSpeed);

			}
		}

		//animation controller
		if ((Input.GetKeyDown (KeyCode.W) && playerControls)) {
			if (facing) {
				anim.Play ("jump start");
			} else {
				anim.Play ("jump start left");
			}
		} else if (GetComponent<Rigidbody2D> ().velocity.y < 0 && !(jumpBox.collidersTouching.Count > 0)) {
			if (facing) {
				anim.Play ("transistion");
			} else {
				anim.Play ("transistion left");
			}
		} else if ((anim.GetCurrentAnimatorStateInfo (0).IsName("transistion") || anim.GetCurrentAnimatorStateInfo (0).IsName("transistion left") || anim.GetCurrentAnimatorStateInfo (0).IsName("descending") || anim.GetCurrentAnimatorStateInfo (0).IsName("descending left")) && jumpBox.collidersTouching.Count > 0) {
			if (facing) {
				anim.Play ("landing");
			} else {
				anim.Play ("landing left");
			}
		} else if (((Input.GetKey (KeyCode.A) && playerControls) || moveLeft) && !anim.GetCurrentAnimatorStateInfo (0).IsName("left continuous")) {
			anim.Play ("left start");
		} else if (((Input.GetKey (KeyCode.D) && playerControls) || moveRight) && !anim.GetCurrentAnimatorStateInfo (0).IsName("right continuous")) {
			anim.Play ("right start");
		} else if ((anim.GetCurrentAnimatorStateInfo (0).IsName("right start") || anim.GetCurrentAnimatorStateInfo (0).IsName("right continuous")) && !((Input.GetKey (KeyCode.D) && playerControls) || moveRight)) {
			anim.Play ("right end");
		} else if ((anim.GetCurrentAnimatorStateInfo (0).IsName("left start") || anim.GetCurrentAnimatorStateInfo (0).IsName("left continuous")) && !((Input.GetKey (KeyCode.A) && playerControls) || moveLeft)) {
			anim.Play ("left stop");
		}

		//respawn
		if (health <= 0 || (Input.GetKey (KeyCode.R) && playerControls)) {
			UnityEngine.SceneManagement.SceneManager.LoadScene (UnityEngine.SceneManagement.SceneManager.GetActiveScene ().buildIndex);
		}

		// exit use
		if (exitTriggersIn > 0 && ((Input.GetKeyDown (KeyCode.Space) && playerControls))) {
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
