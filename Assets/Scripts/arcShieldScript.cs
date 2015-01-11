using UnityEngine;
using System.Collections;

public class arcShieldScript : MonoBehaviour {

	private Vector3 startPosition;
	public float lifeSpanDist = 10f;

	void Start () {
		startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 distanceTraveled = transform.position - startPosition;
		float distTraveled = distanceTraveled.magnitude;
		if(distTraveled >= lifeSpanDist)
		{
			DestroyObject(gameObject);
			Destroy(this);
		}
	}
}
