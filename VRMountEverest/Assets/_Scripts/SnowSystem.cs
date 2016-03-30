using UnityEngine;
using System.Collections;

public class SnowSystem : MonoBehaviour {
	public GameObject target;

	private ParticleSystem ps;


	// Use this for initialization
	void Start () {
		ps = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(target.transform.position.x, target.transform.position.y + 20, target.transform.position.z);
	
	}

	public void setSnowParticles(int count) {
		if (ps != null) {
			ps.maxParticles = count;
		}
	}
}
