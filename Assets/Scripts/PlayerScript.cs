using UnityEngine;
using System.Collections;

public enum Swipe { None, Up, Down, Left, Right };

public class PlayerScript : MonoBehaviour {

	public GameObject projectile;
	public float pushRate = 0.25f;//how often you can swipe
	public float projSpeed = 3.0f;
	private float nextPush = 0.0f;
	public float swipeThreshold = 2.0f;

	public int howManyArcs = 15;
	public float arcTheta = 60.0f;//degrees

	public float minSwipeLength = 50f;
	private Vector2 firstPressPos;
	private Vector2 secondPressPos;
	private Vector2 currentSwipe;
	private bool mouseDown = false;
	private float swipeTime;

	public static Swipe swipeDirection;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > nextPush)//to make sure they arn't rapid fire pushing
		{
			DetectSwipe();//sets the swipeDirection and currentSwipe vector
			if(swipeDirection != Swipe.None)
			{
				nextPush = Time.time + pushRate;
				float angle = Vector2.Angle(Vector2.right, currentSwipe);//angle from 0 to 180, which ever angle is closest
				//Debug.Log(angle);
				if(currentSwipe.y < 0)//allows us to get values past 180
				{
					angle = 360 - angle;
				}
				makeArc(angle);
				swipeDirection = Swipe.None;
			}
		}
	}

	public void makeArc(float angle)//one arc facing right = 0degrees, width=0.3 and height=0.55
	{
		float size = 12.0f;//degrees of one arc

		//Object theForce = Instantiate(projectile, transform.position, Quaternion.Euler(0, 0, angle));
		//((GameObject)theForce).rigidbody2D.velocity = currentSwipe * projSpeed;//sends the arc in the direction we want at a specified speed

		//int howManyArcs = (int)Mathf.Ceil(arcTheta / size);
		angle += (arcTheta / 2);
		for(int i = 0; i < howManyArcs; i++)//s = r0
		{
			angle -= ((arcTheta/howManyArcs));

			Object theForce = Instantiate(projectile, transform.position, Quaternion.Euler(0, 0, angle));
			float x = Mathf.Cos(Mathf.Deg2Rad * angle);
			float y = Mathf.Sin(Mathf.Deg2Rad * angle);
			Vector2 currentDir = new Vector2(x, y);
			((GameObject)theForce).rigidbody2D.velocity = currentDir * projSpeed;//sends the arc in the direction we want at a specified speed

		}

		/* Test for size of one arc
		 * float x = ((GameObject)theForce).collider2D.bounds.max.x - ((GameObject)theForce).collider2D.bounds.min.x;
		float y = ((GameObject)theForce).collider2D.bounds.max.y - ((GameObject)theForce).collider2D.bounds.min.y;
		Debug.Log ("X width: " + x + " | Y height: " + y);*/
	}

	public void DetectSwipe()
    {
        if (Input.touches.Length > 0) 
		{
             Touch t = Input.GetTouch(0);
   
             if (t.phase == TouchPhase.Began) {
                 firstPressPos = new Vector2(t.position.x, t.position.y);
             }
   
             if (t.phase == TouchPhase.Ended) {
                secondPressPos = new Vector2(t.position.x, t.position.y);
                currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
               
                // Make sure it was a legit swipe, not a tap
                if (currentSwipe.magnitude < minSwipeLength) {
                    swipeDirection = Swipe.None;
                    return;
                }
               
                currentSwipe.Normalize();
   
				//Below: unused statements to set the swipeDirection
                // Swipe up
                if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f) {
                    swipeDirection = Swipe.Up;
                // Swipe down
				} else if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f) {
                    swipeDirection = Swipe.Down;
                // Swipe left
				} else if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f) {
                    swipeDirection = Swipe.Left;
                // Swipe right
				} else if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f) {
                    swipeDirection = Swipe.Right;
                }
             }
        } 
		else 
		{
            swipeDirection = Swipe.None;   
        }

		if (mouseDown == true) {
			secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
			float swipeDist = Vector2.Distance(firstPressPos,secondPressPos);
			Debug.Log("SD: " + swipeDist);
			if (swipeDist > swipeThreshold){

				currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
				
				currentSwipe.Normalize();
				
				// Swipe up
				if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f) {
					swipeDirection = Swipe.Up;
					// Swipe down
				} else if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f) {
					swipeDirection = Swipe.Down;
					// Swipe left
				} else if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f) {
					swipeDirection = Swipe.Left;
					// Swipe right
				} else if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f) {
					swipeDirection = Swipe.Right;
				}
				mouseDown = false;
			}else if (Time.time - swipeTime > 0.1f){
				mouseDown = false;
			}

		}

		//same thing as above but with mouse press
		if(Input.GetMouseButtonDown(0))
		{
			firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
			mouseDown = true;
			swipeTime = Time.time;
			//Debug.Log("mouse down");
		}
		if(Input.GetMouseButtonUp(0))
		{
			mouseDown = false;
			//Debug.Log("mouse up");
		}
    }

}
