using UnityEngine;
using System.Collections;

public enum Swipe { None, Up, Down, Left, Right };

public class PlayerScript : MonoBehaviour {

	public GameObject projectile;
	public float pushRate = 0.25f;//how often you can swipe
	public float projSpeed = 3.0f;
	private float nextPush = 0.0f;

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
				Object theForce = Instantiate(projectile, transform.position, Quaternion.Euler(0, 0, angle));
				((GameObject)theForce).rigidbody2D.velocity = currentSwipe * projSpeed;//sends the arc in the direction we want at a specified speed
				swipeDirection = Swipe.None;
			}
		}
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

			if (Vector2.Distance(firstPressPos,secondPressPos) > 0.5f){
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
			Debug.Log("mouse down");
		}
		if(Input.GetMouseButtonUp(0))
		{
			mouseDown = false;
			Debug.Log("mouse up");
		}
    }

}
