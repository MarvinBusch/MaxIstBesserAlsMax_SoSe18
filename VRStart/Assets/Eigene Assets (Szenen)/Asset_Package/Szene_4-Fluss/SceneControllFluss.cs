using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneControllFluss : MonoBehaviour {

	public GameObject Boot;
	public GameObject Schaedel;
	public GameObject Steg;
	public GameObject Player;
	
	public GameObject SoundUtopie;
	public GameObject SoundDystopie;
	public GameObject Wilhelm;
	public GameObject KinderLachen;
	public GameObject Regen;

	public GameObject FadingScriptObject;

	public GameObject[] Lichter;
	//public GameObject SceneEndObject;
	private AudioSource Audio;
	private AudioSource Audio2;
	public GameObject Erdbeben;
	private float MyTime=0f;
	private float step=0f;
	public float duration = 60.0F;
	
	private bool MusicTrigger=false;
	private bool MundGeschlossen=false;
	private bool startRegen=false;
	private bool kinder=false;

	
	private Color NewColor;

	
	// Use this for initialization
	void Start () {
		RenderSettings.skybox.SetColor("_Tint", Color.grey);
		MyTime = 0f;
		MusicTrigger = false;
		MundGeschlossen = false;
		startRegen = false;
		kinder = false;
		Regen.GetComponent<DigitalRuby.RainMaker.RainScript>().RainIntensity = 0;
		
		//SaveVariable.Utopie=true; // Testing Utopie Dystopie
		
		if(SaveVariable.Utopie==false){
			Audio = SoundDystopie.GetComponent<AudioSource>();
			Audio2 = Wilhelm.GetComponent<AudioSource>();
			NewColor = new Color (0.25f,0f,0f);
			Boot.GetComponent<Animator>().SetBool("Dystopie",true);
		}	
		else{
			Audio = SoundUtopie.GetComponent<AudioSource>();
			Audio2 = KinderLachen.GetComponent<AudioSource>();
			NewColor = new Color (0f,0.5f,0.5f);
			Boot.GetComponent<Animator>().SetBool("Utopie",true);
		}
	}
	
	// Update is called once per frame
	void Update () {
		MyTime += Time.deltaTime;
		if(MusicTrigger==true){
			RenderSettings.skybox.SetColor("_Tint", Color.Lerp(Color.grey, NewColor, step));
			step += Time.deltaTime / duration;
		}
		if(MundGeschlossen==true||kinder==true){
			if(MyTime>2){
				/*Audio.Stop();*/ Audio2.Play();				
				FadingScriptObject.GetComponent<FadeIn>().BeginFadeOut(1/Audio2.GetComponent<AudioSource>().clip.length);
			}
			if(MyTime>2+Audio2.GetComponent<AudioSource>().clip.length){/*RenderSettings.skybox.SetColor("_Tint", Color.grey);*/Application.LoadLevel("End");}
		}
		if(startRegen==true){
			if(MyTime<10){Regen.GetComponent<DigitalRuby.RainMaker.RainScript>().RainIntensity = 1 * (MyTime/10);}
		}
	}
	
	public void StartRegen(){
		startRegen=true;
	}
	public void MundOeffnen(){
		Schaedel.GetComponent<Animator>().SetBool("MundOeffnen", true);
	}
	public void ObjectRise(){
		Erdbeben.GetComponent<AudioSource>().Play();
		Steg.GetComponent<Animator>().SetBool("ObjectRise", true);
		Schaedel.GetComponent<Animator>().SetBool("ObjectRise", true);
		Player.GetComponent<Animator>().SetBool("ObjectRise", true);
	}
	public void StartMusic(){
	Audio.Play();
	MusicTrigger=true;
	}
	public void MundZu(){
		Schaedel.GetComponent<Animator>().SetBool("MundSchließen", true);
		MyTime = 0;
		MundGeschlossen = true;
	}
	
	public void Kinder(){
		kinder=true;	
		MyTime=0;
	}
	
}
