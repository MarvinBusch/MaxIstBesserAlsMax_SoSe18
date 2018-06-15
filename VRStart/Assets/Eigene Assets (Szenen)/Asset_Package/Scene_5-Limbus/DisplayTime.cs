using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayTime : MonoBehaviour {

	float myTime = 0f;

	void Start () {
		myTime = 0f;
		changeDisplayTime ();
	}

	void Update () {
		if (SaveVariable.Zeit_Seit_Start > 0) {myTime = SaveVariable.Zeit_Seit_Start;} 
		else {myTime += Time.deltaTime;}

		changeDisplayTime ();
	}

	void changeDisplayTime(){
		GetComponent<TextMesh> ().text = (Mathf.Floor(myTime/60)).ToString("F0") + ":" + (myTime%60).ToString("F1");
	}
}
