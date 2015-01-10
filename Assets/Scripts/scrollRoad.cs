using UnityEngine;
using System.Collections;

public class scrollRoad : MonoBehaviour {

	public float scrollSpeed;
	public float tileSizeZ;
	private Vector3 startPosition;

	void Start () 
	{
		startPosition = transform.position;
	}

	void Update () 
	{
		float newPosition = Mathf.Repeat(Time.deltaTime * scrollSpeed, tileSizeZ);
		transform.position = startPosition + Vector3.down * newPosition;
		startPosition = transform.position;
	}

}