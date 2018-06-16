using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLimbus : MonoBehaviour {

	public GameObject TV;
	public GameObject Licht_Tür;
	public float PlaySpeed = 0.5f;
	public float InverseMultiplier = 2;
	public string sceneName= "End";
	public float EndeNach = 15;
	private bool AnimUnderZero = false;

	void Start(){
		GetComponent<Animator>().SetFloat("AnimationSpeed", 0);
		AnimUnderZero = false;
		Licht_Tür.GetComponent<Light> ().intensity = 0;
	}

	void Update(){		
		if (EndeNach <= TV.GetComponent<DisplayTime> ().myTime) {
			if (Licht_Tür.GetComponent<Light> ().intensity < 1) {Licht_Tür.GetComponent<Light> ().intensity += Time.deltaTime / 10;}
			else {TV.GetComponent<DisplayTime> ().changeColor (Color.red);}
		}
		if (GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).normalizedTime > 0 && !GetComponent<Animator>().IsInTransition(0)&&AnimUnderZero==true) {GetComponent<Animator>().SetFloat("AnimationSpeed", 0);AnimUnderZero = false;}

		if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime < 0 && !GetComponent<Animator>().IsInTransition(0)){GetComponent<Animator>().SetFloat("AnimationSpeed", PlaySpeed);AnimUnderZero = true;}

		if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !GetComponent<Animator>().IsInTransition(0)){SaveVariable.SceneChange (sceneName);}
	}
	public void LookAtAnimStart(){
		if(EndeNach<=TV.GetComponent<DisplayTime>().myTime){
			GetComponent<Animator>().SetFloat("AnimationSpeed", PlaySpeed);
		}
	}

	public void LookNOTAtAnimStart(){
		GetComponent<Animator>().SetFloat("AnimationSpeed", - InverseMultiplier * PlaySpeed);
	}

}
