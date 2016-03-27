using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class updateElevation : MonoBehaviour {
    public GameObject peak;
    public Text elevation;
    private double elev;
	
	void Update () {
		// South col math
		// Start = 17k, end = 29025, diff = 12025
		// unity: start = 254 end = 562, diff = 308
		// we elevate at a speed of 39.04 ft/unit
        // elev = 29029.0 - (peak.transform.position.y-transform.position.y)*3.28084;
        elev = 17000 + (transform.position.y - 254) * 39.04;
        elev = Math.Round(elev) - (Math.Round(elev) % 10);
        elevation.text = elev.ToString() + " feet";
	}
}
