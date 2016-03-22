using System;
using UnityEngine;
using System.Collections;

public class TimeController : MonoBehaviour {

	private DateTime currentTime = (new WeatherController()).getFirstDay();
	private DateTime simTime;

	// Use this for initialization
	void Start () {
		simTime = currentTime;
		InvokeRepeating("UpdateTime", 1, 1.0F);
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown("g")) {
			print("G was pressed. 1 hour forward");
			simTime = simTime.AddHours(1.00);
		}
		if (Input.GetKeyDown("f")) {
			print("F was pressed. 1 hour backward");
			simTime = simTime.AddHours(-1.00);
		}
		if (Input.GetKeyDown("t")) {
			print("T was pressed. Next time period");
			simTime = nextTimePeriod(simTime);
		}
		if (Input.GetKeyDown("r")) {
			print("R was pressed. Previous time period");
			simTime = prevTimePeriod(simTime);
		}
	}

	public DateTime getCurrentTime() {
		return currentTime;
	}

	public DateTime getSimTime() {
		return simTime;
	}

	public DateTime nextTimePeriod(DateTime t) {
		DateTime newTime = t;
		if (newTime.Hour < 6 || newTime.Hour >= 20) {
			if (newTime.Hour >= 20) {
				newTime = new DateTime(t.Year, t.Month, t.Day + 1, 6, 0, 0);
			}
			else {
				newTime = new DateTime(t.Year, t.Month, t.Day, 6, 0, 0);
			}
		}
		else if (newTime.Hour < 14) {
			newTime = new DateTime(t.Year, t.Month, t.Day, 14, 0, 0);
		}
		else {
			newTime = new DateTime(t.Year, t.Month, t.Day, 20, 0, 0);
		}

		return newTime;
	}

	public DateTime prevTimePeriod(DateTime t) {
		DateTime newTime = t;
		if (newTime.Hour <= 6) {
			newTime = new DateTime(t.Year, t.Month, t.Day - 1, 20, 0, 0);
		}
		else if (newTime.Hour <= 14) {
			newTime = new DateTime(t.Year, t.Month, t.Day, 6, 0, 0);
		}
		else {
			newTime = new DateTime(t.Year, t.Month, t.Day, 14, 0, 0);
		}

		return newTime;
	}


	public void UpdateTime() {
		simTime = simTime.AddHours(0.016666667);
		print(simTime);
	}
}
