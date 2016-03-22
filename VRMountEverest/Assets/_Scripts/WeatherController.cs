using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class WeatherController : MonoBehaviour {

	private DateTime firstDay = new DateTime(2016, 3, 23, 0, 0, 0);
	private Dictionary<DateTime, WeatherData> weatherOracle12k = new Dictionary<DateTime, WeatherData>();
	private WeatherData currentWeather;


	// Use this for initialization
	void Start () {
		DateTime day0_pm = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day, 14, 0, 0);
		WeatherData w0_pm = new WeatherData(day0_pm, "25 E (mph)", "clear", 0, 0, 25);
		DateTime day0_night = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day, 20, 0, 0);
		WeatherData w0_night = new WeatherData(day0_night, "15 SE (mph)", "clear", 0, 0, 21);
		DateTime day1_am = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day + 1, 14, 0, 0);
		WeatherData w1_am = new WeatherData(day1_am, "35 ESE (mph)", "clear", 0, 0, 30);
		DateTime day1_pm = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day + 1, 14, 0, 0);
		WeatherData w1_pm = new WeatherData(day1_pm, "55 SSE (mph)", "clear", 0, 0, 30);
		DateTime day1_night = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day + 1, 20, 0, 0);
		WeatherData w1_night = new WeatherData(day1_night, "30 ESE (mph)", "clear", 0, 0, 28);


		weatherOracle12k.Add(day0_pm, w0_pm);
		weatherOracle12k.Add(day1_am, w1_am);

		print(weatherOracle12k[day1_am].toString());


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public DateTime getFirstDay () {
		return firstDay;
	}
}
