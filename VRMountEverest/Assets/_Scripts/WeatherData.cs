using UnityEngine;
using System.Collections;
using System;

public class WeatherData : MonoBehaviour {
	public DateTime timePeriod;
	public String wind;
	public String summary;
	public double snow;
	public double rain;
	public double temp;

	public WeatherData (DateTime t, String w, String s, double snow, double rain, double temp) {
		timePeriod = t;
		wind = w;
		summary = s;
		this.snow = snow;
		this.rain = rain;
		this.temp = temp;
	}

	public String toString() {
		return timePeriod.ToString("G") + "\nWinds: " + wind + " Skies: " + summary + " Snow: " + snow.ToString() + " Rain: " + rain.ToString() + " Temp: " + temp.ToString();
	}
}
