using UnityEngine;
using System.Collections;

public class arcShieldScript : MonoBehaviour {

	private Vector3 startPosition;
	public float lifeSpanDist = 25f;//was 10

	void Start () {
		startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		/*Vector3 distanceTraveled = transform.position - startPosition;
		float distTraveled = distanceTraveled.magnitude;
		if(distTraveled >= lifeSpanDist)
		{
			DestroyObject(gameObject);
			Destroy(this);
		}*/
		if(lifeSpanDist < 0)
		{
			DestroyObject(gameObject);
			Destroy(this);
		}
		lifeSpanDist--;
	}

	void OnCollisionEnter2D(Collision2D other) //doesnt work when using triggers
	{
		if(other.gameObject.name.Contains("shieldArc"))
		{
			//Debug.Log("nooooooooooooooo");
		}
	}
}
