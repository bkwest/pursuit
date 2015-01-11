using UnityEngine;
using System.Collections;

public class arcShieldScript : MonoBehaviour {

	private Vector3 startPosition;
	public float lifeSpanDist = 1.0f;

	void Start () {
		startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 distanceTraveled = transform.position - startPosition;
		float distTraveled = distanceTraveled.magnitude;
		Debug.Log (distTraveled);
		if(distTraveled >= lifeSpanDist)
		{
			DestroyObject(gameObject);
			Destroy(this);
		}
	}
}
