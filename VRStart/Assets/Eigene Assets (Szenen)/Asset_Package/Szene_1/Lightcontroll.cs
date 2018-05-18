﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightcontroll : MonoBehaviour {

	private Vector3[] angles;
	private int index;
	private Vector3 centerAngle;
	public GameObject responsiveObject;
	public GameObject Camera;
	public bool Kopf_Eingabe = false;

	void Start(){
		ResetGesture ();
	}

	void Update(){
		if (Kopf_Eingabe == true) {
			if (index == 0) {ResetGesture ();}
			angles[index] = Camera.GetComponent<Transform>().eulerAngles;
			index++;
			if (index == 60) {
				CheckMovement ();
				ResetGesture ();
				Kopf_Eingabe = false;
			}
		}
	}


	void CheckMovement(){
		bool right = false, left = false, up = false, down = false;

		for (int i = 0; i < 60; i++) {
			if (angles [i].x < centerAngle.x - 20.0f && !up) {
				up = true;
			} else if(angles [i].x > centerAngle.x + 20.0f && !down){
				down=true;
			}

			if (angles [i].y < centerAngle.y - 20.0f && !left) {
				left = true;
			} else if(angles [i].y > centerAngle.y + 20.0f && !right){
				right=true;
			}

			if (left && right && !(up && down)) {
				Debug.Log ("response = No");
				responsiveObject.GetComponent<Renderer> ().material.color = Color.red;
			}
			if (up && down && !(left && right)) {
				Debug.Log ("response = Yes");
				responsiveObject.GetComponent<Renderer> ().material.color = Color.green;
			}
		}
	}
		
	void ResetGesture(){
		angles = new Vector3[60];
		index = 0;
		centerAngle = Camera.GetComponent<Transform>().eulerAngles;
	}

	public void SetEingabeTrue(){
		Kopf_Eingabe = true;
	}
/*
public float StartTime = 5.0f;
public float DurationLampe = 5.0f;
protected float MyTime = 0f;

public Transform Türe;
public float WaitTime = 5.0f;
public float DurationTuere = 5f;

public GameObject MenschTüre;
private Animator MenschAnim;
public GameObject MenschTisch;

public Transform[] Lights;
public float LightIntensity = 1f;

public Transform Flare;
public float FlareIntensity = 1000f;
public float FlareBrightness = 5f;

public GameObject Audio;
public GameObject Lampe;

private bool StartTuere = false;
private bool TuereAuf = false;
private bool EndTuere=false;
private bool Go = false;
private bool end = false;
private bool FlareIsShown = false;
private bool Collides = false;
private bool AudioPlay = false;

	// Use this for initialization
	void Start () {
		StartTuere=false;
		TuereAuf = false;
		EndTuere=false;
		Go=false;
		end=false;
		FlareIsShown = false;
		Collides = false;
		AudioPlay = false;
		MyTime=0f;
		Flare.GetComponent<Light>().intensity = 0f;
		Flare.GetComponent<LensFlare>().brightness = 0f;
		for(int i=0; i<Lights.Length; i++){
				Lights[i].GetComponent<Light>().intensity = 0f;
		}
		Flare.GetComponent<LensFlare>().fadeSpeed = 1000;
		MenschTisch.SetActive(false);
		MenschTüre.SetActive(false);
		MenschAnim = MenschTisch.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (EndTuere==false)
		{
			MyTime += Time.deltaTime;
			
			if(MyTime>WaitTime&&StartTuere==false){
				MyTime=0;
				StartTuere=true;
				MenschTüre.SetActive(true);
			}
			if(MyTime>DurationTuere&&StartTuere==true){
				EndTuere=true;
				Türe.eulerAngles = new Vector3(0, 0, 0);
				MyTime=0;
				MenschTisch.SetActive(true);
				MenschTüre.SetActive(false);
				StartTuere=false;
			}		
			if(StartTuere==true)
			{
				if(TuereAuf == false){
					if(MyTime>(DurationTuere/2)){TuereAuf=true;}
					else{Türe.eulerAngles = new Vector3(0, -90 * (MyTime/(DurationTuere/2)), 0);}
				}
				if(TuereAuf == true){
					Türe.eulerAngles = new Vector3(0, 180 + (90 * (MyTime/(DurationTuere/2))), 0);
				}
			}
		}
		else{		
			if(FlareIsShown==true)
			{
				Flare.GetComponent<LensFlare>().fadeSpeed = 0;
			}
			if(end==false){
				MyTime += Time.deltaTime;
				if(MyTime>WaitTime&&Go==false){
					Lampe.GetComponent<AudioSource>().Play();
					MyTime=0;
					Go=true;
					Flare.GetComponent<Light>().intensity = FlareIntensity;
					Flare.GetComponent<LensFlare>().brightness = FlareBrightness;
					if(Collides==true) {FlareIsShown = true;}
				}
				if(MyTime>DurationLampe&&Go==true){
					end=true;
				}
				if(Go==true){
					for(int i=0; i<Lights.Length; i++){
						Lights[i].GetComponent<Light>().intensity = LightIntensity * (MyTime/DurationLampe);
					}
				}
			}
		}
		if (end==true){
			if(AudioPlay==false){
				Audio.GetComponent<AudioSource>().Play();
				MyTime=0;
				MenschAnim.SetBool("PlayBool", true);
				AudioPlay=true;
				}
			else{MyTime+= Time.deltaTime;}
			if (MyTime>3f){MenschAnim.enabled = false;}
			if (MyTime>Audio.GetComponent<AudioSource>().clip.length - 1f){MenschAnim.enabled = true; MenschAnim.speed = 2.5f;}
			if(MyTime>Audio.GetComponent<AudioSource>().clip.length)
			{	SaveVariable.SceneChange ("Matrix");}
		}

	}
	
	public void DetectCollision(){
		Collides = true;
		if(Go==true&&MyTime>0){
		FlareIsShown = true;
		}
	}
	public void DetectDeCollision(){
		Collides = false;
	}*/

}
