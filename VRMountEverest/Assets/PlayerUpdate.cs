using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerUpdate : MonoBehaviour {
    public Text timeText, weatherText, trailText;
    public string time, weather, trail;
    

	// Use this for initialization
	void Start () {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (time != "") { timeText.text = time; }
            if (weather != "") { weatherText.text = weather; }
            if (trail != "") { trailText.text = trail; }
        }
    }



	// Update is called once per frame
	void Update () {
	
	}
}
