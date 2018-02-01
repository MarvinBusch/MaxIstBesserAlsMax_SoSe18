using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour {

	protected float MyTime = 0f;
	public GameObject Flare;
	protected float brightness;
	protected bool AudioEnded=false;
	public GameObject Türe;
	public GameObject Mensch;
	public GameObject Lampe;
	
	void Start() {
		brightness = Flare.GetComponent<LensFlare>().brightness;
		AudioEnded = false;
	}
	
	// Update is called once per frame
	void Update () {
		MyTime += Time.deltaTime;
		if(Flare.GetComponent<LensFlare>().brightness != brightness)
		{
			//Lampe.GetComponent<PlayAudio>().Playing();
			MyTime=0f;
			AudioEnded=true;
		}
		if(MyTime>Lampe.GetComponent<AudioSource>().clip.length&&AudioEnded==true)
		{	
			//GetComponent<AudioSource>().Play();
			AudioEnded=false;
			MyTime=0;
		}
		if(MyTime>GetComponent<AudioSource>().clip.length)
		{	
			Application.LoadLevel("Matrix");
		}
	}
}
