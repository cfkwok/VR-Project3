using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class TransportTrigger : MonoBehaviour {
    public GameObject playerObj;
    public Text currentLocation;
    private String currentLocationStr;
    private String savedPrevBeforePeak;
    

	// Use this for initialization
	void Start () {
		savedPrevBeforePeak = "South";

    }

    // Update is called once per frame
	void Update () {
		currentLocationStr = currentLocation.text;
		GameObject camp1 = GameObject.Find("/SouthColPath/BaseCamp");
		GameObject nCp1 = GameObject.Find("/NorthColPath/Checkpoint1");
    	// Next elevation
		if (Input.GetKeyDown("x") || Input.GetButtonDown("PS4_Circle")) {
	   		if (currentLocationStr.Contains("South Col")) {
		   		GameObject camp2 = GameObject.Find("/SouthColPath/Camp2");
		   		GameObject camp3 = GameObject.Find("/SouthColPath/Camp3");
		   		GameObject camp4 = GameObject.Find("/SouthColPath/Camp4");
		   		GameObject peak = GameObject.Find("Peak");
		   		if (playerObj.transform.position.y >= camp4.transform.position.y) {
		   			playerObj.transform.position = new Vector3(peak.transform.position.x, peak.transform.position.y, peak.transform.position.z);
		   			savedPrevBeforePeak = "South";
		   		}
		   		// Camp 4 go to peak?
		   		else if (playerObj.transform.position.y + 2 >= camp3.transform.position.y) {
		   			playerObj.transform.position = new Vector3(camp4.transform.position.x, camp4.transform.position.y, camp4.transform.position.z);
		   		}
		   		// At elevations 21k to 24k ft
		   		else if (playerObj.transform.position.y >= camp2.transform.position.y) {
		   			playerObj.transform.position = new Vector3(camp3.transform.position.x, camp3.transform.position.y, camp3.transform.position.z);
		   		}
		   		// At elevations 18k to 21k ft
		   		else if (playerObj.transform.position.y >= camp1.transform.position.y) {
		   			playerObj.transform.position = new Vector3(camp2.transform.position.x, camp2.transform.position.y, camp2.transform.position.z);
		   		}
		   		else {
		   			playerObj.transform.position = new Vector3(camp1.transform.position.x, camp1.transform.position.y, camp1.transform.position.z);
		   		}
	   		}
	   		else if (currentLocationStr.Contains("North Col")) {
	   			GameObject camp2 = GameObject.Find("Checkpoint2");
		   		GameObject camp3 = GameObject.Find("Checkpoint3");
		   		GameObject camp4 = GameObject.Find("Checkpoint4");
		   		GameObject camp5 = GameObject.Find("Checkpoint5");
		   		GameObject peak = GameObject.Find("Peak");
		   		if (playerObj.transform.position.y >= camp5.transform.position.y) {
		   			playerObj.transform.position = new Vector3(peak.transform.position.x, peak.transform.position.y, peak.transform.position.z);
		   			savedPrevBeforePeak = "North";
		   		}
		   		else if (playerObj.transform.position.y >= camp4.transform.position.y) {
		   			playerObj.transform.position = new Vector3(camp5.transform.position.x, camp5.transform.position.y, camp5.transform.position.z);
		   		}
		   		else if (playerObj.transform.position.y >= camp3.transform.position.y) {
		   			playerObj.transform.position = new Vector3(camp4.transform.position.x, camp4.transform.position.y, camp4.transform.position.z);
		   		}
		   		else if (playerObj.transform.position.y >= camp2.transform.position.y) {
		   			playerObj.transform.position = new Vector3(camp3.transform.position.x, camp3.transform.position.y, camp3.transform.position.z);
		   		}
		   		else if (playerObj.transform.position.y + 2 >= nCp1.transform.position.y) {
		   			playerObj.transform.position = new Vector3(camp2.transform.position.x, camp2.transform.position.y, camp2.transform.position.z);
		   		}
		   		else {
		   			playerObj.transform.position = new Vector3(nCp1.transform.position.x, nCp1.transform.position.y, nCp1.transform.position.z);
		   		}
	   		}
       }

       // Prev elevation
		if (Input.GetKeyDown("z")  || Input.GetButtonDown("PS4_Square")) {
	   		if (currentLocationStr.Contains("South Col")) {
		   		GameObject camp2 = GameObject.Find("/SouthColPath/Camp2");
		   		GameObject camp3 = GameObject.Find("/SouthColPath/Camp3");
		   		GameObject camp4 = GameObject.Find("/SouthColPath/Camp4");
		   		GameObject peak = GameObject.Find("Peak");
		   		if (playerObj.transform.position.y >= camp4.transform.position.y + 1) {
		   			playerObj.transform.position = new Vector3(camp4.transform.position.x, camp4.transform.position.y, camp4.transform.position.z);
		   		}
		   		else if (playerObj.transform.position.y > camp3.transform.position.y) {
		   			playerObj.transform.position = new Vector3(camp3.transform.position.x, camp3.transform.position.y, camp3.transform.position.z);
		   		}
		   		else if (playerObj.transform.position.y >= camp2.transform.position.y + 1) {
		   			playerObj.transform.position = new Vector3(camp2.transform.position.x, camp2.transform.position.y, camp2.transform.position.z);
		   		}
		   		else {
		   			playerObj.transform.position = new Vector3(camp1.transform.position.x, camp1.transform.position.y, camp1.transform.position.z);
		   		}
		   	}

		   	else if (currentLocationStr.Contains("North Col")) {
	   			GameObject camp2 = GameObject.Find("Checkpoint2");
		   		GameObject camp3 = GameObject.Find("Checkpoint3");
		   		GameObject camp4 = GameObject.Find("Checkpoint4");
		   		GameObject camp5 = GameObject.Find("Checkpoint5");
		   		if (playerObj.transform.position.y >= camp5.transform.position.y + 1) {
		   			playerObj.transform.position = new Vector3(camp5.transform.position.x, camp5.transform.position.y, camp5.transform.position.z);
		   		}
		   		else if (playerObj.transform.position.y >= camp4.transform.position.y + 1) {
		   			playerObj.transform.position = new Vector3(camp4.transform.position.x, camp4.transform.position.y, camp4.transform.position.z);
		   		}
		   		else if (playerObj.transform.position.y >= camp3.transform.position.y + 1) {
		   			playerObj.transform.position = new Vector3(camp3.transform.position.x, camp3.transform.position.y, camp3.transform.position.z);
		   		}
		   		else if (playerObj.transform.position.y >= camp2.transform.position.y + 1) {
		   			playerObj.transform.position = new Vector3(camp2.transform.position.x, camp2.transform.position.y, camp2.transform.position.z);
		   		}
		   		else {
		   			playerObj.transform.position = new Vector3(nCp1.transform.position.x, nCp1.transform.position.y, nCp1.transform.position.z);
		   		}
	   		}

	   		else if (currentLocationStr.Contains("Peak")) {
	   			if (savedPrevBeforePeak.Contains("South")) {
	   				GameObject camp4 = GameObject.Find("/SouthColPath/Camp4");
	   				playerObj.transform.position = new Vector3(camp4.transform.position.x, camp4.transform.position.y, camp4.transform.position.z);		   		
	   			}
	   			else if (savedPrevBeforePeak.Contains("North")) {
	   				GameObject camp5 = GameObject.Find("Checkpoint5");
	   				playerObj.transform.position = new Vector3(camp5.transform.position.x, camp5.transform.position.y, camp5.transform.position.z);
	   			}
	   		}
       }

       // Switch paths
		if (Input.GetKeyDown("q") || Input.GetButtonDown("PS4_X")) {
       		if (currentLocationStr.Contains("South Col")) {
       			print("IM IN SOUTH COL");
       			playerObj.transform.position = new Vector3(nCp1.transform.position.x, nCp1.transform.position.y, nCp1.transform.position.z);
       		}
       		else if (currentLocationStr.Contains("North Col")) {
       			print("IM IN NORTH COL");
       			playerObj.transform.position = new Vector3(camp1.transform.position.x, camp1.transform.position.y, camp1.transform.position.z);
       		}

       }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerObj.transform.position = new Vector3(0, 0, 0);
        }
    }
}
