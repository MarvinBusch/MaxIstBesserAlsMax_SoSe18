using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeAnimation : MonoBehaviour {

	public float PlaySpeed = 2;
	public float InverseMultiplier = 2;
	public string sceneName= "Interrogation";
	private bool AnimUnderZero = false;

	void Start(){
		GetComponent<Animator>().SetFloat("AnimationSpeed", 0);
		AnimUnderZero = false;
	}

	void Update(){		
		if (GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).normalizedTime > 0 && !GetComponent<Animator>().IsInTransition(0)&&AnimUnderZero==true) {GetComponent<Animator>().SetFloat("AnimationSpeed", 0);AnimUnderZero = false;}

		if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime < 0 && !GetComponent<Animator>().IsInTransition(0)){GetComponent<Animator>().SetFloat("AnimationSpeed", PlaySpeed);AnimUnderZero = true;}

		if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !GetComponent<Animator>().IsInTransition(0)){SaveVariable.SceneChange (sceneName);}
	}
	public void LookAtAnimStart(){
			GetComponent<Animator>().SetFloat("AnimationSpeed", PlaySpeed);
	}

	public void LookNOTAtAnimStart(){
		GetComponent<Animator>().SetFloat("AnimationSpeed", - InverseMultiplier * PlaySpeed);
	}

}
