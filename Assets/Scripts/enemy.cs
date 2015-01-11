using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {

	public GameObject player;
	private float speed = 5.0f; // move speed
	private Vector3 direction;
	private bool directionFlip = false;
	private float t = 0.0f;
	private float a = 5.0f;
	private bool stopMoving = false;
	private float orginX;

	// Use this for initialization
	void Start () {
		Vector3 heading;
		heading = player.transform.position - transform.position;
		float distance;
		distance = heading.magnitude;
		direction = heading / distance;
		orginX = direction.x;
	}
	
	// Update is called once per frame
	void Update () {
		if(!stopMoving)
		{
			//transform.position = Vector3.MoveTowards(transform.position, destination, speed*Time.deltaTime);
			transform.Translate (direction * speed * Time.deltaTime);
		}

		if(directionFlip)
		{
			//direction.x = a * Mathf.Cos (t * Mathf.Rad2Deg);
			//direction.y = a * Mathf.Sin (t * Mathf.Rad2Deg);

			direction.x = -0.25f* (Mathf.Pow(t-2, 2) - 4);
			if(orginX > 0)
			{
				direction.x *= -1;
			}

			direction.y = -1 * (Mathf.Sin((t-2)/1.4f) + 1);

			if(transform.position.y < -50)
			{
				stopMoving = true;
			}

			if(t < 6)//was 4
			{
				t +=0.05f;
			}
			else
			{
				stopMoving = true;
			}
		}

	}



	void OnTriggerEnter2D(Collider2D other) 
	{
		//Debug.Log (other.gameObject.name);
		/*if(other.gameObject == player || other.gameObject.name == "conifer")
		{
			DestroyObject(gameObject);
			Destroy(this);
		}*/
		if (directionFlip == false && other.gameObject.tag == "sheildArc"){
			//Debug.Log("hit");
			direction = direction * -1;
			directionFlip = true;
		}
	}
}
