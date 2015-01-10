using UnityEngine;
using System.Collections;

public class rust : MonoBehaviour {

	public GameObject player;
	private float speed = 5.0f; // move speed
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed*Time.deltaTime);
	}

	void OnCollisionEnter2D(Collision2D other) 
	{
		if(other.gameObject == player)
		{
			DestroyObject(gameObject);
			Destroy(this);
		}
	}
}
