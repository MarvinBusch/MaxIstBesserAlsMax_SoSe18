using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDecision : MonoBehaviour {

	public int Decision;
	bool Ansehen = false;
	bool Links = false;
	bool Mitte = false;
	bool Rechts = false;
	float Mytime = 0f;
	public float Duration;

	public GameObject Raumschiff;
	public GameObject Feuer;

	public GameObject Schrift_de_1;

	public GameObject Pfeil_li;
	public GameObject Pfeil_mi;
	public GameObject Pfeil_re;

	void Start(){
		Schrift_de_1.SetActive(false);
		PfeilWirdNichtAngesehen ();
		Raumschiff.GetComponent<Animator> ().SetFloat ("PlayMulti", 1f);
	}

	void OnTriggerEnter(Collider other){
		
		if(Decision < 4) {Pfeil_li.GetComponent<FarbwechselPfeile> ().Aktivieren ();}
		Pfeil_mi.GetComponent<FarbwechselPfeile> ().Aktivieren ();
		if(Decision!=6) {Pfeil_re.GetComponent<FarbwechselPfeile> ().Aktivieren ();}
		if(Decision == 6) {Pfeil_li.GetComponent<FarbwechselPfeile> ().Aktivieren ();}

		if (Decision==1){Schrift_de_1.SetActive(true);}
		Raumschiff.GetComponent<Animator>().SetFloat("PlayMulti", 0f);
		Feuer.GetComponent<Animator>().SetFloat("Feuer_Speed", 0.4f);
	}

	void OnTriggerExit(Collider other){
		Pfeil_li.GetComponent<FarbwechselPfeile> ().Deaktivieren ();
		Pfeil_mi.GetComponent<FarbwechselPfeile> ().Deaktivieren ();
		Pfeil_re.GetComponent<FarbwechselPfeile> ().Deaktivieren ();
		Raumschiff.GetComponent<Animator> ().SetInteger ("State", 0);
		Feuer.GetComponent<Animator>().SetFloat("Feuer_Speed", 1f);
		Schrift_de_1.SetActive(false);
	}

	void Update(){
		if (Ansehen == true) {
			Mytime += Time.deltaTime;

			if (Mytime >= Duration) {
				
				Pfeil_li.GetComponent<FarbwechselPfeile> ().Deaktivieren ();
				Pfeil_mi.GetComponent<FarbwechselPfeile> ().Deaktivieren ();
				Pfeil_re.GetComponent<FarbwechselPfeile> ().Deaktivieren ();

				if(Links==true){Raumschiff.GetComponent<Animator> ().SetInteger ("State",1);Pfeil_li.GetComponent<FarbwechselPfeile> ().TotallyWatching ();}
				if(Mitte==true){Raumschiff.GetComponent<Animator> ().SetInteger ("State",2);Pfeil_mi.GetComponent<FarbwechselPfeile> ().TotallyWatching ();}
				if(Rechts==true){Raumschiff.GetComponent<Animator> ().SetInteger ("State",3);Pfeil_re.GetComponent<FarbwechselPfeile> ().TotallyWatching ();}
				Raumschiff.GetComponent<Animator> ().SetFloat ("PlayMulti", 1f);
				PfeilWirdNichtAngesehen ();
			}
		}
	}

	public void LinksWirdAngesehen(){
		Ansehen = true;
		Links = true;
	}

	public void MitteWirdAngesehen(){
		Ansehen = true;
		Mitte = true;
	}

	public void RechtsWirdAngesehen(){
		Ansehen = true;
		Rechts = true;
	}

	public void PfeilWirdNichtAngesehen(){
		Ansehen = false;
		Links = false;
		Mitte = false;
		Rechts = false;
		Mytime = 0f;
	}
}
