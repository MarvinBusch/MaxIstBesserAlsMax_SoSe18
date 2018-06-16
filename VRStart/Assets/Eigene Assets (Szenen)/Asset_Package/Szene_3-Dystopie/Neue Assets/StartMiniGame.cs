using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMiniGame : MonoBehaviour {

	public GameObject Durchsage;
	public GameObject Feuersbrunst;

	void Start(){
		Feuersbrunst.GetComponent<Animator> ().SetFloat ("Feuer_Speed",0f);
	}

	void OnTriggerEnter(Collider other){
		RadioOn ();
		Feuersbrunst.GetComponent<Animator> ().SetFloat ("Feuer_Speed",1f);
	}

	public void RadioOn(){
		Durchsage.GetComponent<AudioSource> ().Play ();
	}
}
