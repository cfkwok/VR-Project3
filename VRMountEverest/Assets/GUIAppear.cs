using UnityEngine;
using System.Collections;

public class GUIAppear : MonoBehaviour {

	public Text data;
	private bool guiShow = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay (Collider col) {
		if (col.tag == "Player") {
			guiShow = true;
		}
	}

	void OnTriggerExit (Collider col) {
		if (col.tag == "Player") {
			guiShow = false;
		}
	}

	void onGUI() {
		if (guiShow == true) {
			GUI.DrawTexture(Rect(Screen.width / 4.5, Screen.height / 4, 1024, 512, data));
		}
	}

}
