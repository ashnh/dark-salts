using UnityEngine;
using System.Collections;

public class LoadBlock : MonoBehaviour {

	public GameObject player;
	public GameObject childSelf;

	public float rightX;
	public float leftX;
	public float upY;
	public float downY;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (player.transform.position.x <= rightX && player.transform.position.x >= leftX && player.transform.position.y <= upY && player.transform.position.y >= downY) {
			childSelf.SetActive (true);
		} else {
			childSelf.SetActive (false);
		}
	}
}
