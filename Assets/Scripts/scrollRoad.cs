using UnityEngine;
using System.Collections;

public class scrollRoad : MonoBehaviour {

	public float scrollSpeed;
	public float tileSizeZ;
	private Vector3 startPosition;//gets updated, more like previous position
	private Vector3 foreverStart;//doesnt change

	private float roadTriggeredFlag = 0.0f;

	void Start () 
	{
		foreverStart = transform.position;
		startPosition = transform.position;
	}

	void Update () 
	{
		if(roadTriggeredFlag == 1.0f)//when the road hits the trigger, it should go back to the top
		{
			transform.position = foreverStart + Vector3.up * 10;
		}
		else
		{
			float newPosition = Mathf.Repeat(Time.deltaTime * scrollSpeed, tileSizeZ);
			transform.position = startPosition + Vector3.down * newPosition;
		}
		startPosition = transform.position;
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		if(other.gameObject.name == "road trigger")
		{
			roadTriggeredFlag = 1.0f;
		}
	}

	void OnTriggerExit2D(Collider2D other) 
	{
		if(other.gameObject.name == "road trigger")
		{
			roadTriggeredFlag = 0.0f;
		}
	}
}