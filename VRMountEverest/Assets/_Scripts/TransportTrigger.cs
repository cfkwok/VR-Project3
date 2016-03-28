using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TransportTrigger : MonoBehaviour {
    public GameObject playerObj;
    

	// Use this for initialization
	void Start () {

    }

    // Update is called once per frame
	void Update () {
    	// Next elevation
	   if (Input.GetKeyDown("x")) {
	   		GameObject camp1 = GameObject.Find("/SouthColPath/BaseCamp");
	   		GameObject camp2 = GameObject.Find("/SouthColPath/Camp2");
	   		GameObject camp3 = GameObject.Find("/SouthColPath/Camp3");
	   		GameObject camp4 = GameObject.Find("/SouthColPath/Camp4");
	   		GameObject peak = GameObject.Find("Peak");
	   		if (playerObj.transform.position.y >= camp4.transform.position.y) {
	   			playerObj.transform.position = new Vector3(peak.transform.position.x, peak.transform.position.y, peak.transform.position.z);
	   		}
	   		// Camp 4 go to peak?
	   		else if (playerObj.transform.position.y >= camp3.transform.position.y) {
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

       // Prev elevation
	   if (Input.GetKeyDown("z")) {
	   		// At max peak
	   		if (playerObj.transform.position.y >= 15) {
	   			// Replace vector positions with mountain location...
	   			playerObj.transform.position = new Vector3(playerObj.transform.position.x, 15, playerObj.transform.position.z);
	   		}
	   		// At elevations 24k to 30k ft
	   		else if (playerObj.transform.position.y >= 10) {
	   			// Replace vector positions with mountain location...
	   			playerObj.transform.position = new Vector3(playerObj.transform.position.x, 10, playerObj.transform.position.z);
	   		}
	   		// At elevations 18k to 24k ft
	   		else if (playerObj.transform.position.y >= 5) {
	   			// Replace vector positions with mountain location...
	   			playerObj.transform.position = new Vector3(playerObj.transform.position.x, 5, playerObj.transform.position.z);
	   		}
	   		// At elevations 12k to 18k ft
	   		else {
	   			// Replace vector positions with mountain location...
	   			playerObj.transform.position = new Vector3(playerObj.transform.position.x, 0, playerObj.transform.position.z);
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
