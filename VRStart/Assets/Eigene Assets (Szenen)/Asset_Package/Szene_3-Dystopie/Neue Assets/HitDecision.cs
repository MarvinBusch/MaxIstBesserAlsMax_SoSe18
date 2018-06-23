// Script für die Entscheidung an Kreuzungen in BladeRunner

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
		Schrift_de_1.SetActive(false);												// Schrift wird deaktiviert.
		PfeilWirdNichtAngesehen ();             									// Pfeile werden inaktiv (näheres bei der Funktion) gemacht.
		Raumschiff.GetComponent<Animator> ().SetFloat ("PlayMulti", 1f);			// Die Geschwindigkeit der Animationen wird auf "normal Geschwindikeit" gestellt. (Multipikator im Animator)
	}

	// Wenn das Raumschiff (Collider im vorderen Rad) auf die HitBox trifft.
	void OnTriggerEnter(Collider other){ 

		// Die Pfeile werden nur dann aktiviert, wenn auch die Möglichkeit besteht an der Kreuzung abzubiegen. (Funktionsweise im FarbwechselPfeile.cs Script.)
		if(Decision < 4) {Pfeil_li.GetComponent<FarbwechselPfeile> ().Aktivieren ();}	// Bist auf Entscheidung 4 & 5 kann man Links abbiegen. 
		if(Decision == 6) {Pfeil_li.GetComponent<FarbwechselPfeile> ().Aktivieren ();}	 
		Pfeil_mi.GetComponent<FarbwechselPfeile> ().Aktivieren ();						// Man kann immer geradeaus fahren.
		if(Decision!=6) {Pfeil_re.GetComponent<FarbwechselPfeile> ().Aktivieren ();}	// Nur bei Entscheidung 6 kann man nicht rechts abbiegen.

		if (Decision==1){Schrift_de_1.SetActive(true);}									// Der Hinweistext wird nur bei Entscheidung 1 aktiviert.
		Raumschiff.GetComponent<Animator>().SetFloat("PlayMulti", 0f);						// Wenn das Raumschiff die HitBox triffe, dann wird die Animation Pausiert.
		if(Decision!=1){Feuer.GetComponent<Animator> ().SetFloat ("Feuer_Speed", 0.4f);}	// Das Feuer wird auf 40% der Geschweindigkeit gedrosselt. (Bei Entscheidung 1 bewegt sich das Feuer noch nicht, bleibt also bei 0)
	}

	// Wenn das Raumschiff aus der Box hinaus fährt.
	void OnTriggerExit(Collider other){
		Pfeil_li.GetComponent<FarbwechselPfeile> ().Deaktivieren ();					//Die Pfeile werden deaktiviert. (Funktionsweise im FarbwechselPfeile.cs Script.)
		Pfeil_mi.GetComponent<FarbwechselPfeile> ().Deaktivieren ();
		Pfeil_re.GetComponent<FarbwechselPfeile> ().Deaktivieren ();
		Raumschiff.GetComponent<Animator> ().SetInteger ("State", 0);					// Die Entscheidungsstates des Raumschiffes wird zurückgesetzt.
		if(Decision!=1){Feuer.GetComponent<Animator> ().SetFloat ("Feuer_Speed", 1f);}	// Die Geschwindigkeit des Feuers wird wieder auf Volles Tempo angehoben.
		Schrift_de_1.SetActive(false);													// Die Schrift wird deaktiviert.
	}

	// Wird bei jedem Frame aufgerufen.
	void Update(){
		// Wenn einer der Pfeile angesehen wird, fängt die Zeit an zu laufen.
		if (Ansehen == true) {
			Mytime += Time.deltaTime;	// Zeit wird mit der Zeit addiert, die seit dem letzten Frame vergangen ist.

			// Wenn die Zeit, seit der Auswahl eines Pfeils größer ist, als die Zeit, die man zur Auswahl braucht:
			if (Mytime >= Duration) {
				
				Pfeil_li.GetComponent<FarbwechselPfeile> ().Deaktivieren ();
				Pfeil_mi.GetComponent<FarbwechselPfeile> ().Deaktivieren ();
				Pfeil_re.GetComponent<FarbwechselPfeile> ().Deaktivieren ();		// Die Pfeile werden wieder deaktiviert.

				if(Links==true){Raumschiff.GetComponent<Animator> ().SetInteger ("State",1);Pfeil_li.GetComponent<FarbwechselPfeile> ().TotallyWatching ();}
				if(Mitte==true){Raumschiff.GetComponent<Animator> ().SetInteger ("State",2);Pfeil_mi.GetComponent<FarbwechselPfeile> ().TotallyWatching ();}
				if(Rechts==true){Raumschiff.GetComponent<Animator> ().SetInteger ("State",3);Pfeil_re.GetComponent<FarbwechselPfeile> ().TotallyWatching ();}
																					// Je nachdem, welcher Pfeil ausgewählt wurde wird die Farbe des jeweiligen Pfeils verändert. Näheres im Script: "FarbwechselPfeile.cs"
				Raumschiff.GetComponent<Animator> ().SetFloat ("PlayMulti", 1f);	// Die Animation des Fahrens wird wieder aktiviert.
				PfeilWirdNichtAngesehen ();											// Die Entscheidung welcher Pfeil ausgewählt wurde wird wieder rückgängig gemacht.
			}
		}
	}

	// Öffentliche Funktionen. Werden durch HitBoxen auf den Pfeilen und den Blick aktiviert.
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

	// Die Pfeile werden bei dieser Reset-Funktion auf "Falsch" gesetzt. Auch die Zeit wird zurückgesetzt.
	public void PfeilWirdNichtAngesehen(){
		Ansehen = false;
		Links = false;
		Mitte = false;
		Rechts = false;
		Mytime = 0f;
	}
}
