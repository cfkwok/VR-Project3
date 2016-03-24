using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using DigitalRuby.RainMaker;

public class WeatherController : MonoBehaviour {

	private DateTime firstDay = new DateTime(2016, 3, 23, 6, 0, 0);
	private Dictionary<DateTime, WeatherData> weatherOracle12k = new Dictionary<DateTime, WeatherData>();
	private WeatherData currentWeather;

	public TimeController timeController;
	public BaseRainScript baseRainScript;
	public BaseRainScript baseSnowScript;
	public GameObject Sun;

	private float sunLocation = 0f;

	// Use this for initialization
	void Start () {
		populateWeatherData();
		StartCoroutine(DoWeatherCheck());
	}
	
	// Update is called once per frame
	void Update () {
		//updateCurrWeather();
		Sun.transform.eulerAngles = new Vector3(sunLocation, 0f, 0f);
		sunLocation += 1;

	}

	public DateTime getFirstDay () {
		return firstDay;
	}


	public void updateCurrWeather() {
		DateTime currTime = timeController.getSimTime();

		if (weatherOracle12k.ContainsKey(currTime)) {
			currentWeather = weatherOracle12k[currTime];
			print("KEY CONTAINED: " + currTime + "   With Value: " + weatherOracle12k[currTime].toString());
			
			updateDay();
			applyWeatherScene();
			
		}
	}

	public void updateDay() {

	}

	public void applyWeatherScene() {
		int windSpeed = 0;
		String windString = Regex.Match(currentWeather.wind, @"\d+").Value;
		Int32.TryParse(windString, out windSpeed);
		
		if (baseRainScript.audioSourceWind != null) {
			if (windSpeed >= 40) {
				// Play strong wind sounds and animation
				baseRainScript.audioSourceWind.Stop();
				baseRainScript.WindSoundVolumeModifier = 1.0f;
				baseRainScript.audioSourceWind.Play((baseRainScript.WindZone.windMain / baseRainScript.WindSpeedRange.z) * baseRainScript.WindSoundVolumeModifier);

			}
			else if (windSpeed >= 25) {
				// Play moderate wind sounds and animation
				baseRainScript.audioSourceWind.Stop();
				baseRainScript.WindSoundVolumeModifier = 0.65f;
				baseRainScript.audioSourceWind.Play((baseRainScript.WindZone.windMain / baseRainScript.WindSpeedRange.z) * baseRainScript.WindSoundVolumeModifier);
			}
			else if (windSpeed >= 15) {
				// Play light wind sounds and animation
				baseRainScript.audioSourceWind.Stop();
				baseRainScript.WindSoundVolumeModifier = 0.3f;
				baseRainScript.audioSourceWind.Play((baseRainScript.WindZone.windMain / baseRainScript.WindSpeedRange.z) * baseRainScript.WindSoundVolumeModifier);
			}
			else {
				baseRainScript.audioSourceWind.Stop();
				baseRainScript.WindSoundVolumeModifier = 0.1f;
				baseRainScript.audioSourceWind.Play((baseRainScript.WindZone.windMain / baseRainScript.WindSpeedRange.z) * baseRainScript.WindSoundVolumeModifier);
			}
		}
		

		if (currentWeather.snow >= 6) {
			// Display heavy snow animation
			baseSnowScript.RainIntensity = 0.08f;

		}
		else if (currentWeather.snow >= 3) {
			// Display moderate snow animation
			baseSnowScript.RainIntensity = 0.04f;
		}
		else if (currentWeather.snow >= 1) {
			// Display light snow animation
			baseSnowScript.RainIntensity = 0.02f;
		}
		else {
			baseSnowScript.RainIntensity = 0.0f;
		}

		if (currentWeather.rain >= 6) {
			// Display heavy rain animation
			baseRainScript.RainIntensity = 0.75f;
		}
		else if (currentWeather.rain >= 3) {
			// Display moderate rain animation
			baseRainScript.RainIntensity = 0.4f;
		}
		else if (currentWeather.rain >= 1) {
			// Display light rain animation
			baseRainScript.RainIntensity = 0.2f;
		}
		else {
			baseRainScript.RainIntensity = 0f;
		}
	}

	IEnumerator DoWeatherCheck() {
	    for(;;) {
	        updateCurrWeather();
	        yield return new WaitForSeconds(.1f);
	    }
	}

	private void populateWeatherData() {
		// Data for elevation at 12k feet
		DateTime day0_am = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day, 6, 0, 0);
		WeatherData w0_am = new WeatherData(day0_am, "35 ESE (mph)", "clear", 0, 0, 23);
		DateTime day0_pm = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day, 14, 0, 0);
		WeatherData w0_pm = new WeatherData(day0_pm, "25 E (mph)", "clear", 0, 0, 25);
		DateTime day0_night = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day, 20, 0, 0);
		WeatherData w0_night = new WeatherData(day0_night, "15 SE (mph)", "clear", 0, 0, 21);
		DateTime day1_am = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day + 1, 6, 0, 0);
		WeatherData w1_am = new WeatherData(day1_am, "35 ESE (mph)", "clear", 0, 0, 30);
		DateTime day1_pm = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day + 1, 14, 0, 0);
		WeatherData w1_pm = new WeatherData(day1_pm, "55 SSE (mph)", "clear", 0, 0, 30);
		DateTime day1_night = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day + 1, 20, 0, 0);
		WeatherData w1_night = new WeatherData(day1_night, "30 ESE (mph)", "clear", 0, 0, 28);
		DateTime day2_am = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day + 2, 6, 0, 0);
		WeatherData w2_am = new WeatherData(day2_am, "35 SE (mph)", "clear", 0, 0, 37);
		DateTime day2_pm = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day + 2, 14, 0, 0);
		WeatherData w2_pm = new WeatherData(day2_pm, "35 SSE (mph)", "clear", 0, 0, 36);
		DateTime day2_night = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day + 2, 20, 0, 0);
		WeatherData w2_night = new WeatherData(day2_night, "30 SE (mph)", "clear", 0, 0, 37);
		DateTime day3_am = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day + 3, 6, 0, 0);
		WeatherData w3_am = new WeatherData(day3_am, "15 ESE (mph)", "clear", 0, 0, 43);
		DateTime day3_pm = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day + 3, 14, 0, 0);
		WeatherData w3_pm = new WeatherData(day3_pm, "25 SE (mph)", "clear", 0, 0, 41);
		DateTime day3_night = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day + 3, 20, 0, 0);
		WeatherData w3_night = new WeatherData(day3_night, "15 E (mph)", "clear", 0, 0, 41);
		DateTime day4_am = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day + 4, 6, 0, 0);
		WeatherData w4_am = new WeatherData(day4_am, "30 E (mph)", "clear", 0, 0, 45);
		DateTime day4_pm = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day + 4, 14, 0, 0);
		WeatherData w4_pm = new WeatherData(day4_pm, "35 E (mph)", "some clouds", 0, 0, 41);
		DateTime day4_night = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day + 4, 20, 0, 0);
		WeatherData w4_night = new WeatherData(day4_night, "35 E (mph)", "clear", 0, 0, 36);
		DateTime day5_am = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day + 5, 6, 0, 0);
		WeatherData w5_am = new WeatherData(day5_am, "20 ENE (mph)", "clear", 0, 0, 41);
		DateTime day5_pm = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day + 5, 14, 0, 0);
		WeatherData w5_pm = new WeatherData(day5_pm, "30 NE (mph)", "snow showers", 2.4, 0, 36);
		DateTime day5_night = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day + 5, 20, 0, 0);
		WeatherData w5_night = new WeatherData(day5_night, "35 ENE (mph)", "snow showers", 1.6, 0, 32);

		weatherOracle12k.Add(day0_am, w0_am);
		weatherOracle12k.Add(day0_pm, w0_pm);
		weatherOracle12k.Add(day0_night, w0_night);
		weatherOracle12k.Add(day1_am, w1_am);
		weatherOracle12k.Add(day1_pm, w1_pm);
		weatherOracle12k.Add(day1_night, w1_night);
		weatherOracle12k.Add(day2_am, w2_am);
		weatherOracle12k.Add(day2_pm, w2_pm);
		weatherOracle12k.Add(day2_night, w2_night);
		weatherOracle12k.Add(day3_am, w3_am);
		weatherOracle12k.Add(day3_pm, w3_pm);
		weatherOracle12k.Add(day3_night, w3_night);
		weatherOracle12k.Add(day4_am, w4_am);
		weatherOracle12k.Add(day4_pm, w4_pm);
		weatherOracle12k.Add(day4_night, w4_night);
		weatherOracle12k.Add(day5_am, w5_am);
		weatherOracle12k.Add(day5_pm, w5_pm);
		weatherOracle12k.Add(day5_night, w5_night);

		foreach (KeyValuePair<DateTime, WeatherData> kvp in weatherOracle12k) {
			print(kvp.Value.toString());
		}
	}
}
