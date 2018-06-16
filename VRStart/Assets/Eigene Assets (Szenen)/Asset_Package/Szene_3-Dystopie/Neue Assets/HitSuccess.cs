using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSuccess : MonoBehaviour {

	public GameObject FadeInSphere;
	public string NewScene;

	void OnTriggerEnter(Collider other){
		FadeInSphere.GetComponent<FadeIn> ().BeginFadeOut (1);
	}

	void OnTriggerExit(Collider other){
		SaveVariable.SceneChange (NewScene);
	}
}
