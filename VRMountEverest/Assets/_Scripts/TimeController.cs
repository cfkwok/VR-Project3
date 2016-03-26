using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeController : MonoBehaviour {

    public Text timeText;
    public GameObject Sun;
    private DateTime currentTime = (new WeatherController()).getFirstDay();
	private DateTime simTime;
	private float sunLocation = 0.0f;		

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
			sunLocation += (0.25f * 60);
			Sun.transform.eulerAngles = new Vector3(sunLocation, 0f, 0f);
			
		}
		if (Input.GetKeyDown("f")) {
			print("F was pressed. 1 hour backward");
			simTime = simTime.AddHours(-1.00);
			sunLocation += (0.25f * -60);
			Sun.transform.eulerAngles = new Vector3(sunLocation, 0f, 0f);
		}
		if (Input.GetKeyDown("t")) {
			print("T was pressed. Next time period");
			simTime = nextTimePeriod(simTime);
		}
		if (Input.GetKeyDown("r")) {
			print("R was pressed. Previous time period");
			simTime = prevTimePeriod(simTime);
		}
		
		
        timeText.text = simTime.ToString();
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
                if (newTime.Day < DateTime.DaysInMonth(newTime.Year, newTime.Month)) { newTime = new DateTime(t.Year, t.Month, t.Day + 1, 6, 0, 0); }
                else { newTime = new DateTime(t.Year, t.Month + 1, 1, 6, 0, 0); }
			}
			else {
				newTime = new DateTime(t.Year, t.Month, t.Day, 6, 0, 0);
			}
			sunLocation = 0;
			Sun.transform.eulerAngles = new Vector3(sunLocation, 0f, 0f);
		}
		else if (newTime.Hour < 14) {
			newTime = new DateTime(t.Year, t.Month, t.Day, 14, 0, 0);
			sunLocation = (0.25f * 60) * 8;
			Sun.transform.eulerAngles = new Vector3(sunLocation, 0f, 0f);
		}
		else {
			newTime = new DateTime(t.Year, t.Month, t.Day, 20, 0, 0);
			sunLocation = (0.25f * 60) * 14;
			Sun.transform.eulerAngles = new Vector3(sunLocation, 0f, 0f);
		}

		return newTime;
	}

	public DateTime prevTimePeriod(DateTime t) {
		DateTime newTime = t;
		if (newTime.Hour <= 6) {
			sunLocation = (0.25f * 60) * 14;
			Sun.transform.eulerAngles = new Vector3(sunLocation, 0f, 0f);
            if (newTime.Day != 1) { newTime = new DateTime(t.Year, t.Month, t.Day - 1, 20, 0, 0); }
            else { newTime = new DateTime(t.Year, t.Month - 1, DateTime.DaysInMonth(newTime.Year, newTime.Month), 20, 0, 0); }
        }
		else if (newTime.Hour <= 14) {
			newTime = new DateTime(t.Year, t.Month, t.Day, 6, 0, 0);
			sunLocation = 0;
			Sun.transform.eulerAngles = new Vector3(sunLocation, 0f, 0f);
		}
		else {
			newTime = new DateTime(t.Year, t.Month, t.Day, 14, 0, 0);
			sunLocation = (0.25f * 60) * 8;
			Sun.transform.eulerAngles = new Vector3(sunLocation, 0f, 0f);
		}

		return newTime;
	}


	public void UpdateTime() {
		simTime = simTime.AddHours(0.016666667);
        timeText.text = simTime.ToString();
		print(simTime);
		Sun.transform.eulerAngles = new Vector3(sunLocation, 0f, 0f);
		sunLocation += (0.25f);
	}
}