using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitStone : MonoBehaviour {
	public string scenename = "Limbus";

	void Start(){
		GetComponent<Animator> ().SetFloat ("Kooperation_Multi", (((9f / (SaveVariable.kooperation + 7f)) / 9f)+0.8f));
	}

	void OnTriggerEnter(Collider other){
		SaveVariable.SceneChange(scenename);
	}
}
