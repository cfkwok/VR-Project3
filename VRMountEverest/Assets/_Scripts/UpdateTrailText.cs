using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class UpdateTrailText : MonoBehaviour {
	public Text trailText;

	// Use this for initialization
	void Start () {
	   
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
    {
        if (gameObject.name == "BaseCamp") {
        	trailText.text = "South Col, Base camp";
        }
        else if (gameObject.name == "Camp2") {
        	trailText.text = "South Col, Camp 2";
        }
        else if (gameObject.name == "Camp3") {
        	trailText.text = "South Col, Camp 3";
        }
        else if (gameObject.name == "Camp4") {
        	trailText.text = "South Col, Camp 4";
        }
        else if (gameObject.name == "Peak") {
        	trailText.text = "Peak of Mount Everest";
        }


        if (gameObject.name == "Checkpoint1") {
            trailText.text = "North Col, checkpoint 1";
        }
        else if (gameObject.name == "Checkpoint2") {
            trailText.text = "North Col, checkpoint 2";
        }
        else if (gameObject.name == "Checkpoint3") {
            trailText.text = "North Col, checkpoint 3";
        }
        else if (gameObject.name == "Checkpoint4") {
            trailText.text = "North Col, checkpoint 4";
        }
        else if (gameObject.name == "Checkpoint5") {
            trailText.text = "North Col, checkpoint 5";
        }
        

    }
}
