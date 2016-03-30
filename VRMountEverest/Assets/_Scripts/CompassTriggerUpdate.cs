using UnityEngine;
using System.Collections;

public class CompassTriggerUpdate : MonoBehaviour {
	public targetingUpdate tUpdate;
	public GameObject targetLocation;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		tUpdate.target = targetLocation;
	}
}
