using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioScript : MonoBehaviour {

	public bool Radio = false; 
	public bool Transition = false; 
	public Material AnMaterial;
	public Material AusMaterial;

	public float FadeDuration = 0.2f;
	float mytime;
	float Multi = 1;


	// Use this for initialization
	void Start () {
		RadioAus ();
		GetComponent<AudioSource> ().volume = 0;
	}

	void Update(){
		if (Transition == true) {
			mytime += Time.deltaTime;
			if (mytime < FadeDuration) {
				GetComponent<AudioSource> ().volume += Multi * (0.6f / FadeDuration) * Time.deltaTime;
			} else {
				Transition = false;
				if (Radio) {
					Radio = false;
				} else {
					Radio = true;
				}
				mytime = 0;
				GetComponentInParent<BoxCollider>().enabled = true;
			}
		}

	}

	public void RadioAn(){
		Transition = true;
		GetComponentInParent<BoxCollider>().enabled = false;
		if (!Radio) {
			GetComponent<Renderer> ().material = AnMaterial;
			Multi = 1;
		} else {
			RadioAus ();
		}

	}

	public void RadioAus(){
		GetComponent<Renderer> ().material = AusMaterial;
		Multi = -1;
	}

}
