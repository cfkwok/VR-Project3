using UnityEngine;
using System;
using System.Collections;

public class targetingUpdate : MonoBehaviour {
    public GameObject target, player, image;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        var angle = Vector3.Angle(player.transform.forward, target.transform.position - player.transform.position);
        print(angle);
        image.transform.localRotation = Quaternion.Euler(0, 0, (float)angle);       
	}
}
