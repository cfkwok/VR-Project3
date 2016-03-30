using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class UpdateDataText : MonoBehaviour {

	public Text dataText;
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
			dataText.text = "Over 3000 summiters started their adventure here at the South Col. This pass is so popular that many people sent up camps here.";
		} else if (other.gameObject.name == "Checkpoint1") {
			dataText.text = "The second most common starting point of summiters is the North Col with at least 1900 summiters.";
		} else if (other.gameObject.name == "Fall") {
			dataText.text = "59+7+1+1";
		} else if (other.gameObject.name == "Avalanche") {
			dataText.text = "45+1+1";
		} else if (other.gameObject.name == "Exposure/Frostbite") {
			dataText.text = "7/17";
		} else if (other.gameObject.name == "Exhaustion") {
			dataText.text = "13";
		} else if (other.gameObject.name == "Peak") {
			dataText.text = "Since Sir Edmund Percival Hillary's first successful summit to the top of Mount Everest in 1950, thousands of summiters has followed him. The number of summiters per decade has been growing at an exponential rate with a total of 5113 summiters as of 2011.";
		}

	}

	void OnTriggerExit (Collider other) {
		dataText.text = "";
	}
}
