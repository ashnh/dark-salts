using UnityEngine;
using System.Collections;

public class LevelDoor : MonoBehaviour {

	public int levelComp1;
	public int levelComp2;
	public int levelComp3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.GetInt ("level " + levelComp1.ToString () + " loaded") == 1 && PlayerPrefs.GetInt ("level " + levelComp2.ToString () + " loaded") == 1 && PlayerPrefs.GetInt ("level " + levelComp3.ToString () + " loaded") == 1) {
			Destroy (gameObject);
		}
	}
}
