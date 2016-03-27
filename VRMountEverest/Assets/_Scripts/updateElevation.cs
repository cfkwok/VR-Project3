using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class updateElevation : MonoBehaviour {
    public GameObject peak;
    public Text elevation;
    private double elev;
	
	void Update () {
        elev = 29029.0 - (peak.transform.position.y-transform.position.y)*3.28084;
        elev = Math.Round(elev, 1);
        elevation.text = elev.ToString() + " feet";
	}
}
