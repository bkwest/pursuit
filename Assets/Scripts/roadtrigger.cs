using UnityEngine;
using System.Collections;

public class roadtrigger : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter2D(Collision2D other) //doesnt work when using triggers
	{
		//Debug.Log ("you entered the trigger" + other.gameObject.transform.position);
		//other.gameObject.transform.position = Vector3 (0, 0, 0);
		//other.gameObject.transform.position = Vector3 (0,0,0);
	}

	void OnTriggerEnter2D(Collider2D other) //this one works, but not necessary anymore
	{
		/*if(other.gameObject.name == "Road")
		{
			//Debug.Log (other.gameObject.name);
			Debug.Log (other.gameObject.transform.position);
			other.gameObject.transform.position += Vector3.up * -10;
			Debug.Log (other.gameObject.transform.position);
		}*/
	}
}
