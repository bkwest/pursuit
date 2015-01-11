using UnityEngine;
using System.Collections;
using SynchronizerData;

public class enemy : MonoBehaviour {

	public GameObject player;
	private float speed = 3.0f; // move speed
	private Vector3 direction;
	private bool directionFlip = false;
	private float t = 0.0f;
	private float a = 5.0f;
	private bool stopMoving = false;
	private float orginX;
	private bool passive = true;  //if the enemy is just minding it's own business.
	private bool look = false;  //whether the enemy wants to look at the player.
	private float on = 0;

	private BeatObserver beatObserver;

	// Use this for initialization
	void Start () {
		direction = Vector3.down;
		orginX = direction.x;

		beatObserver = GetComponent<BeatObserver>();

	}
	
	// Update is called once per frame
	void Update () {
		if (passive) {
			float rval = Random.value;
			Debug.Log(rval);
			if (Random.value > 0.995f && transform.position.y > 3.0f) {
				passive = false;
				aimForPlayer();
			}


		}
		if(!stopMoving)
		{
			//transform.position = Vector3.MoveTowards(transform.position, destination, speed*Time.deltaTime);
			transform.Translate (Vector3.down * speed * Time.deltaTime);
			if (!look){
				float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
				transform.rotation = Quaternion.AngleAxis(angle+90, Vector3.forward);
			}
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
				transform.rotation = Quaternion.AngleAxis(180, Vector3.forward);
			}

			if(t < 6)//was 4
			{
				t +=0.05f;
			}
			else
			{
				stopMoving = true;
				transform.rotation = Quaternion.AngleAxis(180, Vector3.forward);
			}
		}

	}

	void aimForPlayer(){
		Vector3 heading;
		heading = player.transform.position - transform.position;
		float distance;
		distance = heading.magnitude;
		direction = heading / distance;

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
