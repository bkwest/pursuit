using UnityEngine;
using System.Collections;

public class roadtrigger : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter2D(Collision2D other) 
	{
	//works:	Debug.Log ("you entered the trigger" + other.gameObject.transform.position);
		//other.gameObject.transform.position = Vector3 (0, 0, 0);
		//other.gameObject.transform.position = Vector3 (0,0,0);
	}
}
