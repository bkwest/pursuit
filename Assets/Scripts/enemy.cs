using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {

	public GameObject player;
	private float speed = 5.0f; // move speed
	private Vector3 direction;
	private bool directionFlip = false;
	private float t = 0.0f;
	private bool stopMoving = false;
	private float orginX;
	private float stayOrGoCounter = 2.0f;

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
		else
		{
			if(stayOrGoCounter % 50 == 0)//time to choose
			{
				int rand = Random.Range(0, 3);//they leave
				Debug.Log(rand);
				if(rand == 1)
				{
					direction.y = -2;
					direction.x = 0;
					stopMoving = false;
				}
				else if(rand == 0)//they come back for more
				{
					direction = player.transform.position;
					stopMoving = false;
				}
				else//they stay
				{
					//do nothing
				}
				stayOrGoCounter = 0.0f;//set to 0 so that the next line sets it to 1, and so it doesnt do the next if statement
			}
			stayOrGoCounter++;
		}

		if(directionFlip && !stopMoving && stayOrGoCounter != 1.0f)//makes the enemies do a curve to below the player and wait
		{
			direction.x = -0.25f* (Mathf.Pow(t-2, 2) - 4);
			if(orginX > 0)
			{
				direction.x *= -1;
			}

			direction.y = -1 * (Mathf.Sin((t-2)/1.4f) + 1);

			if(t < 6)//was 4
			{
				t +=0.05f;
			}
			else
			{
				stopMoving = true;
			}
		}

		if(transform.position.y < -9)//kills them when they go out of screen in the y direction
		{
			//Debug.Log("destroied");
			DestroyObject(gameObject);
			Destroy(this);
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
