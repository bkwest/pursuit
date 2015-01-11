using UnityEngine;
using System.Collections;
using SynchronizerData;

public class enemySpawner : MonoBehaviour {

	private BeatObserver beatObserver;
	private float down;
	private float up;
	private float off;
	private float on;

	private Object currEnemy = null;
	public GameObject player;
	public GameObject enemyToSpawn;
	// Use this for initialization
	void Start () {

		beatObserver = GetComponent<BeatObserver>();
		down = 0;
		up = 0;
		off = 0;
		on = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if ((beatObserver.beatMask & BeatType.DownBeat) == BeatType.DownBeat) {
			//do stuff
			//Debug.Log(up + " | " + down);
			down++;
		}
		if ((beatObserver.beatMask & BeatType.UpBeat) == BeatType.UpBeat) {
			//do stuff
			//Debug.Log(up + " | " + down);
			up++;
		}
		if ((beatObserver.beatMask & BeatType.OffBeat) == BeatType.OffBeat) {
			//do stuff
		//	Debug.Log(off);
			off++;
		}
		if ((beatObserver.beatMask & BeatType.OnBeat) == BeatType.OnBeat) {
			//do stuff
			//*************instantiate enemy***************************todo

			float randomAngle = Random.Range ( 0, 2 * Mathf.PI ); //0 degrees to 360 degrees
			float radius = 2.0f;
			//Calculating the raycast direction
      		Vector3 dir = new Vector3(
       			radius * Mathf.Cos( randomAngle ),
       		    radius * Mathf.Sin( randomAngle ),
				0
      	 	);
         
        	//Make the direction match the transform
         	//It is like converting the Vector3.forward to transform.forward
         	dir = transform.TransformDirection( dir.normalized );
         
			//RaycastHit2D direction = Physics2D.Raycast(player.transform.position, dir);
			//direction.point(0.3f) or direction.GetPoint (0.3f)
			Ray direction = new Ray(player.transform.position, dir);
			currEnemy = Instantiate (enemyToSpawn, direction.GetPoint (10.3f), Quaternion.identity);//Euler(-rcamX, rcamY-540, 0));
			//((GameObject)currEnemy).transform.localScale += new Vector3(0.111f, -0.04f, 0.0f);

			//Debug.Log(on);
			on++;
		}
	}
}
