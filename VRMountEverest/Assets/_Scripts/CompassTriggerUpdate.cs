using UnityEngine;
using System.Collections;

public class CompassTriggerUpdate : MonoBehaviour {
	public targetingUpdate tUpdate;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		tUpdate.target = GameObject.Find("Cube2");
	}
}
