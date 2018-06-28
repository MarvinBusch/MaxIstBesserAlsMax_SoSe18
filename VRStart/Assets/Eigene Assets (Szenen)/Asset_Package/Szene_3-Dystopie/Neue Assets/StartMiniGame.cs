using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMiniGame : MonoBehaviour {

	public GameObject Durchsage;
	public GameObject Feuersbrunst;
	public GameObject Radio;
	bool DurchsageStart = false;
	float mytime = 0;

	void Start(){
		Feuersbrunst.GetComponent<Animator> ().SetFloat ("Feuer_Speed", 0f);
		DurchsageStart = false;
	}

	void Update(){
		if (DurchsageStart) {
			mytime += Time.deltaTime;
			if (mytime >= Durchsage.GetComponent<AudioSource> ().clip.length) {
				Radio.GetComponent<RadioScript> ().Radio = false;
				Radio.GetComponent<RadioScript> ().RadioAn();
				DurchsageStart = false;
			}
		}
	}

	void OnTriggerEnter(Collider other){
		RadioOn ();
		Feuersbrunst.GetComponent<Animator> ().SetFloat ("Feuer_Speed", 1f);
	}

	public void RadioOn(){
		Durchsage.GetComponent<AudioSource> ().Play ();
		Radio.GetComponent<RadioScript> ().Transition = true;
		Radio.GetComponent<RadioScript> ().Radio = true;
		Radio.GetComponent<RadioScript> ().RadioAus();
		Radio.GetComponent<Renderer> ().material = Radio.GetComponent<RadioScript> ().AnMaterial;
		DurchsageStart = true;
		mytime = 0;
	}
}
