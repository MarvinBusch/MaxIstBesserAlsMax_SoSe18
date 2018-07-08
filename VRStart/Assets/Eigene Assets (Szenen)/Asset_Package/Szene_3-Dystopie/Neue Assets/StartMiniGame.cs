using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Dieses Script wird benutzt um das MiniGame in BladeRunner zu starten. 
public class StartMiniGame : MonoBehaviour {

	public GameObject Durchsage;
	public GameObject Feuersbrunst;
	public GameObject Radio;
	bool DurchsageStart = false;
	float mytime = 0;

	// Reset zum Start.
	void Start(){
		Feuersbrunst.GetComponent<Animator> ().SetFloat ("Feuer_Speed", 0f);	// Feuer wird gestoppt.
		DurchsageStart = false;													
	}

	void Update(){
		if (DurchsageStart) {													// Wenn der Collider fürs Minigame getroffen wurde:
			mytime += Time.deltaTime;											// Zeit wird hochgezählt.
			if (mytime >= Durchsage.GetComponent<AudioSource> ().clip.length) {	// Wenn die Länge des DurchsagenAudios erreicht ist:
				Radio.GetComponent<RadioScript> ().Radio = false;				// Das Radio wird zurückgesetzt.
				Radio.GetComponent<RadioScript> ().RadioAn();					// Das Radio wird angeschaltet.
				DurchsageStart = false;											// Durchsage ist beendet.
			}
		}
	}

	// Wenn das Raumschiff durch den Collider fährt:
	void OnTriggerEnter(Collider other){							
		RadioOn ();																// Radio wird angeschaltet.
		Feuersbrunst.GetComponent<Animator> ().SetFloat ("Feuer_Speed", 1f);	// Feuer wird gestartet und bewegt sich gen Westen.
	}

	public void RadioOn(){
		Durchsage.GetComponent<AudioSource> ().Play ();							// Durchsage wird gestartet.
		Radio.GetComponent<RadioScript> ().Transition = true;					// Radio wird angeschaltet (Leiser gemacht, wenn es spielt).
		Radio.GetComponent<RadioScript> ().Radio = true;
		Radio.GetComponent<RadioScript> ().RadioAus();
		Radio.GetComponent<Renderer> ().material = Radio.GetComponent<RadioScript> ().AnMaterial;	// Radio Material wird angemacht.
		DurchsageStart = true;
		mytime = 0;
	}
}
