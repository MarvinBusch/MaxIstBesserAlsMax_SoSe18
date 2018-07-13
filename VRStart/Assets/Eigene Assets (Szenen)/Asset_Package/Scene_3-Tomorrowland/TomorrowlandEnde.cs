using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script liegt auf einem BoxCollider in welchen de Kugel rollt.
public class TomorrowlandEnde : MonoBehaviour {

	float mytime = 0f;
	bool Ende = false;
	public float WarteEnde = 1f;

	void Update(){
		// Wenn Die Kugel den Collider Trifft ist Ende == True.
		if (Ende) {
			mytime += Time.deltaTime;							// Zeit wird hochgezählt.
			if (mytime >= WarteEnde) {							// Wartezeit abwarten.
				SaveVariable.SceneChange ("Interrogation2");	// Szenenwechsel zurück.	
			}
		}
	}

	// Wenn die Kugel die Box trifft wird das Ende aktiviert.
	void OnTriggerEnter(Collider other){
		Ende = true;
		mytime = 0f;
	}

}
