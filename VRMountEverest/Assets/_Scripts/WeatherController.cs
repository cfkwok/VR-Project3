using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using DigitalRuby.RainMaker;

enum intensity { None, Light, Medium, Heavy };

public class WeatherController : MonoBehaviour {

	private DateTime firstDay = new DateTime(2016, 3, 27, 6, 0, 0);
	private Dictionary<DateTime, WeatherData> weatherOracle18k = new Dictionary<DateTime, WeatherData>();
	private Dictionary<DateTime, WeatherData> weatherOracle21k = new Dictionary<DateTime, WeatherData>();
	private Dictionary<DateTime, WeatherData> weatherOracle24k = new Dictionary<DateTime, WeatherData>();
	private Dictionary<DateTime, WeatherData> weatherOracle27k = new Dictionary<DateTime, WeatherData>();	
    private intensity snowIntensity = intensity.None, rainIntensity = intensity.None, windIntensity = intensity.None;
    private string weatherOutput;
    private DateTime currentTimeEvent;

	public TimeController timeController;
	public BaseRainScript baseRainScript;
	public BaseRainScript baseSnowScript;	
    public Text weatherText; //usage weatherText.text = "text"; 
    public updateElevation upElev;
    public WeatherData currentWeather;

	

	// Use this for initialization
	void Start () {
		populateWeatherData();
		StartCoroutine(DoWeatherCheck());
	}
	
	// Update is called once per frame
	void Update () {
		//updateCurrWeather();		
		

	}

	public DateTime getFirstDay () {
		return firstDay;
	}


	public void updateCurrWeather() {
		DateTime currTime = timeController.getSimTime();
		
		if (upElev.elev >= 27000) {
			if (weatherOracle27k.ContainsKey(currTime)) {
				currentTimeEvent = currTime;
				currentWeather = weatherOracle27k[currTime];
				print("ELE 27k KEY CONTAINED: " + currTime + "   With Value: " + weatherOracle27k[currTime].toString());
			}
			else {
				currentWeather = weatherOracle27k[currentTimeEvent];
			}
			updateDay();
			applyWeatherScene();

		}

		else if (upElev.elev >= 24000) {
			if (weatherOracle24k.ContainsKey(currTime)) {
				currentTimeEvent = currTime;
				currentWeather = weatherOracle24k[currTime];
				print("ELE 24k KEY CONTAINED: " + currTime + "   With Value: " + weatherOracle24k[currTime].toString());
			}
			else {
				currentWeather = weatherOracle24k[currentTimeEvent];
			}
			updateDay();
			applyWeatherScene();
		}

		else if (upElev.elev >= 21000) {
			if (weatherOracle21k.ContainsKey(currTime)) {
				currentTimeEvent = currTime;
				currentWeather = weatherOracle21k[currTime];
				print("ELE 21k KEY CONTAINED: " + currTime + "   With Value: " + weatherOracle21k[currTime].toString());
			}
			else {
				currentWeather = weatherOracle21k[currentTimeEvent];
			}
			updateDay();
			applyWeatherScene();
		}

		else {
			if (weatherOracle18k.ContainsKey(currTime)) {
				currentTimeEvent = currTime;
				currentWeather = weatherOracle18k[currTime];
				print("ELE 18k KEY CONTAINED: " + currTime + "   With Value: " + weatherOracle18k[currTime].toString());
			}
			else {
				currentWeather = weatherOracle18k[currentTimeEvent];
			}
			updateDay();
			applyWeatherScene();
		}

        // start weather text update
        switch (windIntensity)
        {
            case intensity.Heavy:
                weatherOutput = "Strong winds";
                break;
            case intensity.Medium:
                weatherOutput = "Stiff winds";
                break;
            case intensity.Light:
                weatherOutput = "Light winds";
                break;
            case intensity.None:
                weatherOutput = "Gentle winds";
                break;
            default:
                break;
        }
        switch (rainIntensity)
        {
            case intensity.Heavy:
                weatherOutput += ", intense downpour";
                break;
            case intensity.Medium:
                weatherOutput += ", heavy rains";
                break;
            case intensity.Light:
                weatherOutput += ", light rains";
                break;
            case intensity.None:
            default:
                break;
        }
        switch (snowIntensity)
        {
            case intensity.Heavy:
                weatherOutput += ", intense downfall";
                break;
            case intensity.Medium:
                weatherOutput += ", heavy downfall";
                break;
            case intensity.Light:
                weatherOutput += ", light downfall";
                break;
            case intensity.None:
            default:
                break;
        }

        weatherText.text = weatherOutput;
        // end weather text update
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
                windIntensity = intensity.Heavy;
			}
			else if (windSpeed >= 25) {
				// Play moderate wind sounds and animation
				baseRainScript.audioSourceWind.Stop();
				baseRainScript.WindSoundVolumeModifier = 0.65f;
				baseRainScript.audioSourceWind.Play((baseRainScript.WindZone.windMain / baseRainScript.WindSpeedRange.z) * baseRainScript.WindSoundVolumeModifier);
                windIntensity = intensity.Medium;
			}
			else if (windSpeed >= 15) {
				// Play light wind sounds and animation
				baseRainScript.audioSourceWind.Stop();
				baseRainScript.WindSoundVolumeModifier = 0.3f;
				baseRainScript.audioSourceWind.Play((baseRainScript.WindZone.windMain / baseRainScript.WindSpeedRange.z) * baseRainScript.WindSoundVolumeModifier);
                windIntensity = intensity.Light;
			}
			else {
				baseRainScript.audioSourceWind.Stop();
				baseRainScript.WindSoundVolumeModifier = 0.1f;
				baseRainScript.audioSourceWind.Play((baseRainScript.WindZone.windMain / baseRainScript.WindSpeedRange.z) * baseRainScript.WindSoundVolumeModifier);
                windIntensity = intensity.None;
			}
		}
		

		if (currentWeather.snow >= 6) {
			// Display heavy snow animation
			baseSnowScript.RainIntensity = 0.08f;
            snowIntensity = intensity.Heavy;
		}
		else if (currentWeather.snow >= 3) {
			// Display moderate snow animation
			baseSnowScript.RainIntensity = 0.04f;
            snowIntensity = intensity.Medium;
		}
		else if (currentWeather.snow >= 1) {
			// Display light snow animation
			baseSnowScript.RainIntensity = 0.02f;
            snowIntensity = intensity.Light;
		}
		else {
			baseSnowScript.RainIntensity = 0.0f;
            snowIntensity = intensity.None;
		}

		if (currentWeather.rain >= 6) {
			// Display heavy rain animation
			baseRainScript.RainIntensity = 0.75f;
            rainIntensity = intensity.Heavy;
		}
		else if (currentWeather.rain >= 3) {
			// Display moderate rain animation
			baseRainScript.RainIntensity = 0.4f;
            rainIntensity = intensity.Medium;
		}
		else if (currentWeather.rain >= 1) {
			// Display light rain animation
			baseRainScript.RainIntensity = 0.2f;
            rainIntensity = intensity.Light;
		}
		else {
			baseRainScript.RainIntensity = 0f;
            rainIntensity = intensity.None;
		}
	}

	IEnumerator DoWeatherCheck() {
	    for(;;) {
	        updateCurrWeather();
	        yield return new WaitForSeconds(.1f);
	    }
	}

	private void populateWeatherData() {
		// Data for elevation at 18k feet
		DateTime day0_am = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day, 6, 0, 0);
		WeatherData w0_am = new WeatherData(day0_am, "5 SE (mph)", "clear", 0, 0, 8);
		DateTime day0_pm = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day, 14, 0, 0);
		WeatherData w0_pm = new WeatherData(day0_pm, "30 NE (mph)", "snow showers", 1.6, 0, 9);
		DateTime day0_night = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day, 20, 0, 0);
		WeatherData w0_night = new WeatherData(day0_night, "30 NE (mph)", "snow showers", 4.3, 0, 7);
		DateTime day1_am = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day + 1, 6, 0, 0);
		WeatherData w1_am = new WeatherData(day1_am, "25 NE (mph)", "heavy snow", 4.3, 0, 5);
		DateTime day1_pm = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day + 1, 14, 0, 0);
		WeatherData w1_pm = new WeatherData(day1_pm, "5 SE (mph)", "snow showers", 4.3, 0, 1);
		DateTime day1_night = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day + 1, 20, 0, 0);
		WeatherData w1_night = new WeatherData(day1_night, "30 SE (mph)", "snow showers", 0.8, 0, 1);
		DateTime day2_am = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day + 2, 6, 0, 0);
		WeatherData w2_am = new WeatherData(day2_am, "25 SE (mph)", "clear", 0, 0, 9);
		DateTime day2_pm = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day + 2, 14, 0, 0);
		WeatherData w2_pm = new WeatherData(day2_pm, "15 SE (mph)", "clear", 0, 0, 12);
		DateTime day2_night = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day + 2, 20, 0, 0);
		WeatherData w2_night = new WeatherData(day2_night, "15 NE (mph)", "clear", 0, 0, 9);
		DateTime day3_am = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day + 3, 6, 0, 0);
		WeatherData w3_am = new WeatherData(day3_am, "15 NE (mph)", "snow showers", 0.4, 0, 10);
		DateTime day3_pm = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day + 3, 14, 0, 0);
		WeatherData w3_pm = new WeatherData(day3_pm, "15 NE (mph)", "snow showers", 3.1, 0, 9);
		DateTime day3_night = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day + 3, 20, 0, 0);
		WeatherData w3_night = new WeatherData(day3_night, "5 SE (mph)", "snow showers", 1.6, 0, 5);
		DateTime day4_am = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day + 4, 6, 0, 0);
		WeatherData w4_am = new WeatherData(day4_am, "15 SE (mph)", "snow showers", 0.4, 0, 9);
		DateTime day4_pm = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day + 4, 14, 0, 0);
		WeatherData w4_pm = new WeatherData(day4_pm, "20 SE (mph)", "snow showers", 2.0, 0, 10);
		DateTime day4_night = new DateTime(firstDay.Year, firstDay.Month, 1, 20, 0, 0);
		WeatherData w4_night = new WeatherData(day4_night, "15 S (mph)", "snow showers", 0, 0, 7);
		DateTime day5_am = new DateTime(firstDay.Year, firstDay.Month + 1, 1, 6, 0, 0);
		WeatherData w5_am = new WeatherData(day5_am, "20 SE (mph)", "clear", 0, 0, 10);
		DateTime day5_pm = new DateTime(firstDay.Year, firstDay.Month + 1, 1, 14, 0, 0);
		WeatherData w5_pm = new WeatherData(day5_pm, "35 SE (mph)", "snow showers", 0.8, 0, 10);
		DateTime day5_night = new DateTime(firstDay.Year, firstDay.Month + 1, 1, 20, 0, 0);
		WeatherData w5_night = new WeatherData(day5_night, "30 SE (mph)", "clear", 0, 0, 10);

		weatherOracle18k.Add(day0_am, w0_am);
		weatherOracle18k.Add(day0_pm, w0_pm);
		weatherOracle18k.Add(day0_night, w0_night);
		weatherOracle18k.Add(day1_am, w1_am);
		weatherOracle18k.Add(day1_pm, w1_pm);
		weatherOracle18k.Add(day1_night, w1_night);
		weatherOracle18k.Add(day2_am, w2_am);
		weatherOracle18k.Add(day2_pm, w2_pm);
		weatherOracle18k.Add(day2_night, w2_night);
		weatherOracle18k.Add(day3_am, w3_am);
		weatherOracle18k.Add(day3_pm, w3_pm);
		weatherOracle18k.Add(day3_night, w3_night);
		weatherOracle18k.Add(day4_am, w4_am);
		weatherOracle18k.Add(day4_pm, w4_pm);
		weatherOracle18k.Add(day4_night, w4_night);
		weatherOracle18k.Add(day5_am, w5_am);
		weatherOracle18k.Add(day5_pm, w5_pm);
		weatherOracle18k.Add(day5_night, w5_night);

		foreach (KeyValuePair<DateTime, WeatherData> data in weatherOracle18k) {
			print(data.Value.toString());
		}
		populateWeatherData21k();
	}

	private void populateWeatherData21k() {
		// Data for elevation at 21k feet
		DateTime day0_am = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day, 6, 0, 0);
		WeatherData w0_am = new WeatherData(day0_am, "5 SE (mph)", "clear", 0, 0, -2);
		DateTime day0_pm = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day, 14, 0, 0);
		WeatherData w0_pm = new WeatherData(day0_pm, "30 NE (mph)", "snow showers", 1.6, 0, -2);
		DateTime day0_night = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day, 20, 0, 0);
		WeatherData w0_night = new WeatherData(day0_night, "30 NE (mph)", "snow showers", 4.3, 0, -6);
		DateTime day1_am = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day + 1, 6, 0, 0);
		WeatherData w1_am = new WeatherData(day1_am, "25 NE (mph)", "heavy snow", 4.3, 0, -8);
		DateTime day1_pm = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day + 1, 14, 0, 0);
		WeatherData w1_pm = new WeatherData(day1_pm, "5 SE (mph)", "snow showers", 4.3, 0, -11);
		DateTime day1_night = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day + 1, 20, 0, 0);
		WeatherData w1_night = new WeatherData(day1_night, "30 SE (mph)", "snow showers", 0.8, 0, -9);
		DateTime day2_am = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day + 2, 6, 0, 0);
		WeatherData w2_am = new WeatherData(day2_am, "25 SE (mph)", "clear", 0, 0, -4);
		DateTime day2_pm = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day + 2, 14, 0, 0);
		WeatherData w2_pm = new WeatherData(day2_pm, "15 SE (mph)", "clear", 0, 0, 0);
		DateTime day2_night = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day + 2, 20, 0, 0);
		WeatherData w2_night = new WeatherData(day2_night, "15 NE (mph)", "clear", 0, 0, 0);
		DateTime day3_am = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day + 3, 6, 0, 0);
		WeatherData w3_am = new WeatherData(day3_am, "15 NE (mph)", "snow showers", 0.4, 0, -2);
		DateTime day3_pm = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day + 3, 14, 0, 0);
		WeatherData w3_pm = new WeatherData(day3_pm, "15 NE (mph)", "snow showers", 3.1, 0, -2);
		DateTime day3_night = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day + 3, 20, 0, 0);
		WeatherData w3_night = new WeatherData(day3_night, "5 SE (mph)", "snow showers", 1.6, 0, -6);
		DateTime day4_am = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day + 4, 6, 0, 0);
		WeatherData w4_am = new WeatherData(day4_am, "15 SE (mph)", "snow showers", 0.4, 0, -4);
		DateTime day4_pm = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day + 4, 14, 0, 0);
		WeatherData w4_pm = new WeatherData(day4_pm, "20 SE (mph)", "snow showers", 2.0, 0, -2);
		DateTime day4_night = new DateTime(firstDay.Year, firstDay.Month, 1, 20, 0, 0);
		WeatherData w4_night = new WeatherData(day4_night, "15 S (mph)", "snow showers", 0, 0, -4);
		DateTime day5_am = new DateTime(firstDay.Year, firstDay.Month + 1, 1, 6, 0, 0);
		WeatherData w5_am = new WeatherData(day5_am, "20 SE (mph)", "clear", 0, 0, -4);
		DateTime day5_pm = new DateTime(firstDay.Year, firstDay.Month + 1, 1, 14, 0, 0);
		WeatherData w5_pm = new WeatherData(day5_pm, "35 SE (mph)", "snow showers", 0.8, 0, -2);
		DateTime day5_night = new DateTime(firstDay.Year, firstDay.Month + 1, 1, 20, 0, 0);
		WeatherData w5_night = new WeatherData(day5_night, "30 SE (mph)", "clear", 0, 0, -2);

		weatherOracle21k.Add(day0_am, w0_am);
		weatherOracle21k.Add(day0_pm, w0_pm);
		weatherOracle21k.Add(day0_night, w0_night);
		weatherOracle21k.Add(day1_am, w1_am);
		weatherOracle21k.Add(day1_pm, w1_pm);
		weatherOracle21k.Add(day1_night, w1_night);
		weatherOracle21k.Add(day2_am, w2_am);
		weatherOracle21k.Add(day2_pm, w2_pm);
		weatherOracle21k.Add(day2_night, w2_night);
		weatherOracle21k.Add(day3_am, w3_am);
		weatherOracle21k.Add(day3_pm, w3_pm);
		weatherOracle21k.Add(day3_night, w3_night);
		weatherOracle21k.Add(day4_am, w4_am);
		weatherOracle21k.Add(day4_pm, w4_pm);
		weatherOracle21k.Add(day4_night, w4_night);
		weatherOracle21k.Add(day5_am, w5_am);
		weatherOracle21k.Add(day5_pm, w5_pm);
		weatherOracle21k.Add(day5_night, w5_night);

		populateWeatherData24k();
	}

	private void populateWeatherData24k() {
		// Data for elevation at 24k feet
		DateTime day0_am = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day, 6, 0, 0);
		WeatherData w0_am = new WeatherData(day0_am, "5 SE (mph)", "clear", 0, 0, -16);
		DateTime day0_pm = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day, 14, 0, 0);
		WeatherData w0_pm = new WeatherData(day0_pm, "30 NE (mph)", "snow showers", 1.6, 0, -15);
		DateTime day0_night = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day, 20, 0, 0);
		WeatherData w0_night = new WeatherData(day0_night, "30 NE (mph)", "snow showers", 4.3, 0, -17);
		DateTime day1_am = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day + 1, 6, 0, 0);
		WeatherData w1_am = new WeatherData(day1_am, "25 NE (mph)", "heavy snow", 4.3, 0, -20);
		DateTime day1_pm = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day + 1, 14, 0, 0);
		WeatherData w1_pm = new WeatherData(day1_pm, "5 SE (mph)", "snow showers", 4.3, 0, -22);
		DateTime day1_night = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day + 1, 20, 0, 0);
		WeatherData w1_night = new WeatherData(day1_night, "30 SE (mph)", "snow showers", 0.8, 0, -20);
		DateTime day2_am = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day + 2, 6, 0, 0);
		WeatherData w2_am = new WeatherData(day2_am, "25 SE (mph)", "clear", 0, 0, -17);
		DateTime day2_pm = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day + 2, 14, 0, 0);
		WeatherData w2_pm = new WeatherData(day2_pm, "15 SE (mph)", "clear", 0, 0, -11);
		DateTime day2_night = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day + 2, 20, 0, 0);
		WeatherData w2_night = new WeatherData(day2_night, "15 NE (mph)", "clear", 0, 0, -11);
		DateTime day3_am = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day + 3, 6, 0, 0);
		WeatherData w3_am = new WeatherData(day3_am, "15 NE (mph)", "snow showers", 0.4, 0, -13);
		DateTime day3_pm = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day + 3, 14, 0, 0);
		WeatherData w3_pm = new WeatherData(day3_pm, "15 NE (mph)", "snow showers", 3.1, 0, -15);
		DateTime day3_night = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day + 3, 20, 0, 0);
		WeatherData w3_night = new WeatherData(day3_night, "5 SE (mph)", "snow showers", 1.6, 0, -17);
		DateTime day4_am = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day + 4, 6, 0, 0);
		WeatherData w4_am = new WeatherData(day4_am, "15 SE (mph)", "snow showers", 0.4, 0, -15);
		DateTime day4_pm = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day + 4, 14, 0, 0);
		WeatherData w4_pm = new WeatherData(day4_pm, "20 SE (mph)", "snow showers", 2.0, 0, -13);
		DateTime day4_night = new DateTime(firstDay.Year, firstDay.Month, 1, 20, 0, 0);
		WeatherData w4_night = new WeatherData(day4_night, "15 S (mph)", "snow showers", 0, 0, -15);
		DateTime day5_am = new DateTime(firstDay.Year, firstDay.Month + 1, 1, 6, 0, 0);
		WeatherData w5_am = new WeatherData(day5_am, "20 SE (mph)", "clear", 0, 0, -17);
		DateTime day5_pm = new DateTime(firstDay.Year, firstDay.Month + 1, 1, 14, 0, 0);
		WeatherData w5_pm = new WeatherData(day5_pm, "35 SE (mph)", "snow showers", 0.8, 0, -15);
		DateTime day5_night = new DateTime(firstDay.Year, firstDay.Month + 1, 1, 20, 0, 0);
		WeatherData w5_night = new WeatherData(day5_night, "30 SE (mph)", "clear", 0, 0, -13);

		weatherOracle24k.Add(day0_am, w0_am);
		weatherOracle24k.Add(day0_pm, w0_pm);
		weatherOracle24k.Add(day0_night, w0_night);
		weatherOracle24k.Add(day1_am, w1_am);
		weatherOracle24k.Add(day1_pm, w1_pm);
		weatherOracle24k.Add(day1_night, w1_night);
		weatherOracle24k.Add(day2_am, w2_am);
		weatherOracle24k.Add(day2_pm, w2_pm);
		weatherOracle24k.Add(day2_night, w2_night);
		weatherOracle24k.Add(day3_am, w3_am);
		weatherOracle24k.Add(day3_pm, w3_pm);
		weatherOracle24k.Add(day3_night, w3_night);
		weatherOracle24k.Add(day4_am, w4_am);
		weatherOracle24k.Add(day4_pm, w4_pm);
		weatherOracle24k.Add(day4_night, w4_night);
		weatherOracle24k.Add(day5_am, w5_am);
		weatherOracle24k.Add(day5_pm, w5_pm);
		weatherOracle24k.Add(day5_night, w5_night);

		populateWeatherData27k();
	}

	private void populateWeatherData27k() {
		// Data for elevation at 27k feet
		DateTime day0_am = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day, 6, 0, 0);
		WeatherData w0_am = new WeatherData(day0_am, "5 SE (mph)", "clear", 0, 0, -26);
		DateTime day0_pm = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day, 14, 0, 0);
		WeatherData w0_pm = new WeatherData(day0_pm, "30 NE (mph)", "snow showers", 1.6, 0, -26);
		DateTime day0_night = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day, 20, 0, 0);
		WeatherData w0_night = new WeatherData(day0_night, "30 NE (mph)", "snow showers", 4.3, 0, -26);
		DateTime day1_am = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day + 1, 6, 0, 0);
		WeatherData w1_am = new WeatherData(day1_am, "25 NE (mph)", "heavy snow", 4.3, 0, -31);
		DateTime day1_pm = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day + 1, 14, 0, 0);
		WeatherData w1_pm = new WeatherData(day1_pm, "5 SE (mph)", "snow showers", 4.3, 0, -33);
		DateTime day1_night = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day + 1, 20, 0, 0);
		WeatherData w1_night = new WeatherData(day1_night, "30 SE (mph)", "snow showers", 0.8, 0, -31);
		DateTime day2_am = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day + 2, 6, 0, 0);
		WeatherData w2_am = new WeatherData(day2_am, "25 SE (mph)", "clear", 0, 0, -29);
		DateTime day2_pm = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day + 2, 14, 0, 0);
		WeatherData w2_pm = new WeatherData(day2_pm, "15 SE (mph)", "clear", 0, 0, -20);
		DateTime day2_night = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day + 2, 20, 0, 0);
		WeatherData w2_night = new WeatherData(day2_night, "15 NE (mph)", "clear", 0, 0, -20);
		DateTime day3_am = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day + 3, 6, 0, 0);
		WeatherData w3_am = new WeatherData(day3_am, "15 NE (mph)", "snow showers", 0.4, 0, -24);
		DateTime day3_pm = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day + 3, 14, 0, 0);
		WeatherData w3_pm = new WeatherData(day3_pm, "15 NE (mph)", "snow showers", 3.1, 0, -24);
		DateTime day3_night = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day + 3, 20, 0, 0);
		WeatherData w3_night = new WeatherData(day3_night, "5 SE (mph)", "snow showers", 1.6, 0, -27);
		DateTime day4_am = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day + 4, 6, 0, 0);
		WeatherData w4_am = new WeatherData(day4_am, "15 SE (mph)", "snow showers", 0.4, 0, -26);
		DateTime day4_pm = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day + 4, 14, 0, 0);
		WeatherData w4_pm = new WeatherData(day4_pm, "20 SE (mph)", "snow showers", 2.0, 0, -24);
		DateTime day4_night = new DateTime(firstDay.Year, firstDay.Month, 1, 20, 0, 0);
		WeatherData w4_night = new WeatherData(day4_night, "15 S (mph)", "snow showers", 0, 0, -26);
		DateTime day5_am = new DateTime(firstDay.Year, firstDay.Month + 1, 1, 6, 0, 0);
		WeatherData w5_am = new WeatherData(day5_am, "20 SE (mph)", "clear", 0, 0, -24);
		DateTime day5_pm = new DateTime(firstDay.Year, firstDay.Month + 1, 1, 14, 0, 0);
		WeatherData w5_pm = new WeatherData(day5_pm, "35 SE (mph)", "snow showers", 0.8, 0, -26);
		DateTime day5_night = new DateTime(firstDay.Year, firstDay.Month + 1, 1, 20, 0, 0);
		WeatherData w5_night = new WeatherData(day5_night, "30 SE (mph)", "clear", 0, 0, -27);

		weatherOracle27k.Add(day0_am, w0_am);
		weatherOracle27k.Add(day0_pm, w0_pm);
		weatherOracle27k.Add(day0_night, w0_night);
		weatherOracle27k.Add(day1_am, w1_am);
		weatherOracle27k.Add(day1_pm, w1_pm);
		weatherOracle27k.Add(day1_night, w1_night);
		weatherOracle27k.Add(day2_am, w2_am);
		weatherOracle27k.Add(day2_pm, w2_pm);
		weatherOracle27k.Add(day2_night, w2_night);
		weatherOracle27k.Add(day3_am, w3_am);
		weatherOracle27k.Add(day3_pm, w3_pm);
		weatherOracle27k.Add(day3_night, w3_night);
		weatherOracle27k.Add(day4_am, w4_am);
		weatherOracle27k.Add(day4_pm, w4_pm);
		weatherOracle27k.Add(day4_night, w4_night);
		weatherOracle27k.Add(day5_am, w5_am);
		weatherOracle27k.Add(day5_pm, w5_pm);
		weatherOracle27k.Add(day5_night, w5_night);
	}

}
