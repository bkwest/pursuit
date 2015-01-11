using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {

	public GameObject player;
	private float speed = 5.0f; // move speed
	private Vector3 direction;

	// Use this for initialization
	void Start () {
		Vector3 heading;
		heading = player.transform.position - transform.position;
		float distance;
		distance = heading.magnitude;
		direction = heading / distance;

	}
	
	// Update is called once per frame
	void Update () {

		//transform.position = Vector3.MoveTowards(transform.position, destination, speed*Time.deltaTime);
		transform.Translate (direction * speed * Time.deltaTime);
	}



	void OnCollisionEnter2D(Collision2D other) 
	{
		Debug.Log (other.gameObject.name);
		/*if(other.gameObject == player || other.gameObject.name == "conifer")
		{
			DestroyObject(gameObject);
			Destroy(this);
		}*/
		if (other.gameObject.tag == "sheildArc"){
			Debug.Log("hit");
			direction = direction * -1;
		}
	}
}
