using UnityEngine;
using System.Collections;
using SynchronizerData;

public class enemy : MonoBehaviour {

	private BeatObserver beatObserver;
	private float down;
	private float up;
	private float off;
	private float on;
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
			//Debug.Log(on);
			on++;
		}
	}
}
