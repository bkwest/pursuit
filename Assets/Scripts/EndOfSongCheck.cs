using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class EndOfSongCheck: MonoBehaviour {

	public GameObject blackScreen;
	private float alpha = 0.0f;
	private bool audioHasBegun = false;
	public float trueRate = 10.0f;
	private float rate = 0.1f;
	private float counter = 0.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(audio.isPlaying)
		{
			audioHasBegun = true;
		}
		if(audioHasBegun && !audio.isPlaying)//fade to black
		{
			Color tempcolor = blackScreen.renderer.material.color;
			tempcolor.a = alpha; //0 is invis, 1 is fully visible
			blackScreen.renderer.material.color = tempcolor;
			if(counter % trueRate == 0 && alpha < 1.0f)
			{
				alpha += rate;
			}
			counter++;
		}
	}
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               