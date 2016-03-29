using UnityEngine;
using System.Collections;

public class GamePadController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool GetHourForwardKey() {
		// g on keyboard or R1 on PS4
		return (Input.GetKeyDown ("g") || Input.GetButtonDown("R1"));
	}

	public bool GetHourBackwardKey() {
		// f on keyboard or L1 on PS4
		return (Input.GetKeyDown ("f") || Input.GetButtonDown("L1"));
	}

	public bool GetPeriodNextKey() {
		// t on keyboard or R2 on PS4
		return (Input.GetKeyDown ("t") || Input.GetButtonDown("R2"));
	}

	public bool GetPeriodPreviousKey() {
		// r on keyboard or L2 on PS4
		return (Input.GetKeyDown ("r") || Input.GetButtonDown("L2"));
	}

	public bool GetNextElevationKey() {
		return (Input.GetKeyDown ("x") || Input.GetButtonDown("Square"));
	}
}
