using UnityEngine;
using System.Collections;

public class SnowSystem : MonoBehaviour {
	public GameObject target;


	// Use this for initialization
	void Start () {
		ParticleSystem ps = GetComponent<ParticleSystem>();
		var em = ps.emission;
		em.enabled = true;

		em.type = ParticleSystemEmissionType.Time;

		em.SetBursts(
			new ParticleSystem.Burst[]{
				new ParticleSystem.Burst(2.0f, 100),
				new ParticleSystem.Burst(4.0f, 100)
			});
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(target.transform.position.x, target.transform.position.y + 20, target.transform.position.z);
	
	}
}
