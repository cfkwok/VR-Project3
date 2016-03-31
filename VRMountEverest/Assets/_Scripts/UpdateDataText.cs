using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class UpdateDataText : MonoBehaviour {

	public Text dataText;
	//public Texture texture;
	private bool showText = false;

	// Use this for initialization
	void Start () {
		dataText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider other) {
		// starting point data
		if (other.gameObject.name == "BaseCamp") {
			dataText.text = "Over 3000 summiters started their adventure here at the South Col! This pass is so popular that many people sent up camps here!";
		} else if (other.gameObject.name == "Checkpoint1") {
			dataText.text = "The second most common starting point of summiters is the North Col with at least 1900 summiters!";
		} else if (other.gameObject.name == "Falling") {
			// 68 deaths by fall
			dataText.text = "Cause of Death: Falling |         68 Recorded Deaths";
		} else if (other.gameObject.name == "Avalanche") {
			// 47 deaths by avalanche
			dataText.text = "Cause of Death: Avalanche | 47 Recorded Deaths";
		} else if (other.gameObject.name == "Frostbite") {
			// 24 deaths by exposure/frostbite
			dataText.text = "Cause of Death: Frostbite |   24 Recorded Deaths ";
		} else if (other.gameObject.name == "Exhaustion") {
			// 13 deaths by exhaustion
			dataText.text = "Cause of Death: Exhaustion|   13 Recorded Deaths ";
		} else if (other.gameObject.name == "Peak") {
			// 5113 summiters; 219 deaths
			dataText.text = "Congratulations! You are the 5114th summiter of 5332 attempts!";
		}

	}

	void OnTriggerExit (Collider other) {
		dataText.text = "";
	}

	/*void OnGUI () {
		GUI.DrawTexture (new Rect (Screen.width/2-512, Screen.height/2-384, 1024, 768), texture, ScaleMode.ScaleToFit);
	}
	*/
}
