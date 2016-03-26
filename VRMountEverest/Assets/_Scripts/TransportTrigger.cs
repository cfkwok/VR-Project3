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
	   		// Start at elevation 12k ft, peaks at ~28k, and we have 3 levels of elevation
	   		// 28 - 12 = 16, 16 / 3 = 5.. increments of 5
	   		// Find current elevation...
	   		// Already at max peak
	   		if (playerObj.transform.position.y >= 15) {

	   		}
	   		// At elevations 24k to 30k ft
	   		else if (playerObj.transform.position.y >= 10) {
	   			// Replace vector positions with mountain location...
	   			playerObj.transform.position = new Vector3(playerObj.transform.position.x, 15, playerObj.transform.position.z);
	   		}
	   		// At elevations 18k to 24k ft
	   		else if (playerObj.transform.position.y >= 5) {
	   			// Replace vector positions with mountain location...
	   			playerObj.transform.position = new Vector3(playerObj.transform.position.x, 10, playerObj.transform.position.z);
	   		}
	   		// At elevations 12k to 18k ft
	   		else {
	   			// Replace vector positions with mountain location...
	   			playerObj.transform.position = new Vector3(playerObj.transform.position.x, 5, playerObj.transform.position.z);
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
