using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {

	public GameObject player;
	private float speed = 5.0f; // move speed
	private Vector3 destination;

	// Use this for initialization
	void Start () {
		destination = player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards(transform.position, destination, speed*Time.deltaTime);
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
			destination = new Vector3(-100,-100);
		}
	}
}
