using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class updateElevation : MonoBehaviour {
    public GameObject peak;
    public WeatherController weatherController;
    public Text elevation;
    public double elev;
    public AudioSource breathingAud;
    private int elevationLevel = 0;
	
	void Update () {
		// South col math
		// Start = 17k, end = 29025, diff = 12025
		// unity: start = 254 end = 562, diff = 308
		// we elevate at a speed of 39.04 ft/unit
        // elev = 29029.0 - (peak.transform.position.y-transform.position.y)*3.28084;
        elev = 17000 + (transform.position.y - 254) * 39.04;
        elev = Math.Round(elev) - (Math.Round(elev) % 10);
        String temp = weatherController.currentWeather.temp.ToString();
        elevation.text = elev.ToString() + " feet, " + temp + "°F";
        if (elev > 27000) {
            
            if (elevationLevel != 3) {
                breathingAud.Stop();
                breathingAud.volume = 0.013f;
                breathingAud.Play();
                elevationLevel = 3;
            }

            
        }
        else if (elev > 24000) {
            
            if (elevationLevel != 2) {
                breathingAud.Stop();
                breathingAud.volume = 0.011f;
                breathingAud.Play();
                elevationLevel = 2;
            }
            
        }
        else if (elev > 21000) {
            
            if (elevationLevel != 1) {
                breathingAud.Stop();
                breathingAud.volume = 0.009f;
                breathingAud.Play();
                elevationLevel = 1;
            }
            
        }
        else {
            
            if (elevationLevel != 0) {
                breathingAud.Stop();
                breathingAud.volume = 0.003f;
                breathingAud.Play();
                elevationLevel = 0;
            }
            
        }

	}
}
