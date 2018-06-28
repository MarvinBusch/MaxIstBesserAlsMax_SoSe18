using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomorrowlandEnde : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		SaveVariable.SceneChange("Interrogation2");
	}

}
